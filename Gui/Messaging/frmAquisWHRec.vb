Imports PSS.Data
Imports PSS.Data.Buisness
Imports PSS.Core.[Global]
Imports System.IO

Public Class frmAquisWHRec
    Inherits System.Windows.Forms.Form

    Private _objMessaging As Buisness.Messaging
    Private _booPopDataToCombo As Boolean = False
    Private _EndOfLife As Boolean
    Private _RF_ID As Integer = 0  'Recept From ID
    Private _WR_ID As Integer = 0  'Warehouse Receipt ID
    Private _WB_ID As Integer = 0 'Warehouse Box ID
    Private _WB_ModelID As Integer = 0 'Selected Warehouse Box Model
    Private _LaborCharge As Decimal = 0.0
    Private _Management_Type_ID As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objMessaging = New Buisness.Messaging()

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
    Friend WithEvents txtPagerNo As System.Windows.Forms.TextBox
    Friend WithEvents _lblPagerNo As System.Windows.Forms.Label
    Friend WithEvents _lblCarrier As System.Windows.Forms.Label
    Friend WithEvents _lblTrackingNo As System.Windows.Forms.Label
    Friend WithEvents txtTrackingNo As System.Windows.Forms.TextBox
    Friend WithEvents _lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents _lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents txtAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents _lblCase As System.Windows.Forms.Label
    Friend WithEvents _lblBatteryCover As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents _lblComment As System.Windows.Forms.Label
    Friend WithEvents txtSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents _lblCapCode As System.Windows.Forms.Label
    Friend WithEvents _lblSerial As System.Windows.Forms.Label
    Friend WithEvents txtCapCode As System.Windows.Forms.TextBox
    Friend WithEvents _lblBaudRate As System.Windows.Forms.Label
    Friend WithEvents _lblFrequency As System.Windows.Forms.Label
    Friend WithEvents _lbModel As System.Windows.Forms.Label
    Friend WithEvents cboCarrier As C1.Win.C1List.C1Combo
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    Friend WithEvents cboBatteryCoverCondition As C1.Win.C1List.C1Combo
    Friend WithEvents cboCaseCondition As C1.Win.C1List.C1Combo
    Friend WithEvents cboFrequency As C1.Win.C1List.C1Combo
    Friend WithEvents cboBaudRate As C1.Win.C1List.C1Combo
    Friend WithEvents cboHolderCondition As C1.Win.C1List.C1Combo
    Friend WithEvents _lblHolderCondition As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents _lbMB_BaudRate As System.Windows.Forms.Label
    Friend WithEvents _lbMB_Frequency As System.Windows.Forms.Label
    Friend WithEvents _lbMB_Model As System.Windows.Forms.Label
    Friend WithEvents dbgBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents gbCustInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cboStates As C1.Win.C1List.C1Combo
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents cboCountries As C1.Win.C1List.C1Combo
    Friend WithEvents _lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents _lblFirstName As System.Windows.Forms.Label
    Friend WithEvents _lblMIName As System.Windows.Forms.Label
    Friend WithEvents _lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents _lblFaxNumber As System.Windows.Forms.Label
    Friend WithEvents _lblPhoneNumber As System.Windows.Forms.Label
    Friend WithEvents _lblZipCode As System.Windows.Forms.Label
    Friend WithEvents _lblState As System.Windows.Forms.Label
    Friend WithEvents _lblCity As System.Windows.Forms.Label
    Friend WithEvents _lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents _lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents _lblLastName As System.Windows.Forms.Label
    Friend WithEvents _lblCountry As System.Windows.Forms.Label
    Friend WithEvents txtMiName As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents TabReceive As System.Windows.Forms.TabPage
    Friend WithEvents TabCustomerAddress As System.Windows.Forms.TabPage
    Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
    Friend WithEvents gbCustomerReceipt As System.Windows.Forms.GroupBox
    Friend WithEvents lblReceiptName As System.Windows.Forms.Label
    Friend WithEvents PnlReceipt As System.Windows.Forms.Panel
    Friend WithEvents gbPagerCondition As System.Windows.Forms.GroupBox
    Friend WithEvents gbReceiptItemDetails As System.Windows.Forms.GroupBox
    Friend WithEvents btnReceiptClose As System.Windows.Forms.Button
    Friend WithEvents btnReceiptCreate As System.Windows.Forms.Button
    Friend WithEvents dbgReceipt As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents rdbReturnMgt As System.Windows.Forms.RadioButton
    Friend WithEvents rdbInventoryMgt As System.Windows.Forms.RadioButton
    Friend WithEvents PnlReceiptItems As System.Windows.Forms.Panel
    Friend WithEvents btnCreateCustomerAddress As System.Windows.Forms.Button
    Friend WithEvents cboPhysicalAbuse As C1.Win.C1List.C1Combo
    Friend WithEvents _lblPhysicalAbuse As System.Windows.Forms.Label
    Friend WithEvents lstReceiptSN As System.Windows.Forms.ListBox
    Friend WithEvents lblReceiptQTY As System.Windows.Forms.Label
    Friend WithEvents btnReceiptReOpen As System.Windows.Forms.Button
    Friend WithEvents btnReceiptPrintLabel As System.Windows.Forms.Button
    Friend WithEvents btnReceiptRemove As System.Windows.Forms.Button
    Friend WithEvents gbCreateBox As System.Windows.Forms.GroupBox
    Friend WithEvents gbBoxItems As System.Windows.Forms.GroupBox
    Friend WithEvents lstBoxSN As System.Windows.Forms.ListBox
    Friend WithEvents txtBoxSN As System.Windows.Forms.TextBox
    Friend WithEvents _lblBoxSerialSN As System.Windows.Forms.Label
    Friend WithEvents lblBoxQTY As System.Windows.Forms.Label
    Friend WithEvents btnBoxRemove As System.Windows.Forms.Button
    Friend WithEvents btnBoxEmptyBox As System.Windows.Forms.Button
    Friend WithEvents btnBoxReprintLabel As System.Windows.Forms.Button
    Friend WithEvents btnBoxClose As System.Windows.Forms.Button
    Friend WithEvents PnlBox As System.Windows.Forms.Panel
    Friend WithEvents PnlBoxItems As System.Windows.Forms.Panel
    Friend WithEvents lblBoxName As System.Windows.Forms.Label
    Friend WithEvents btnBoxCreate As System.Windows.Forms.Button
    Friend WithEvents btnBoxReopen As System.Windows.Forms.Button
    Friend WithEvents cboBox_BaudRate As C1.Win.C1List.C1Combo
    Friend WithEvents cboBox_Frequency As C1.Win.C1List.C1Combo
    Friend WithEvents cboBox_Models As C1.Win.C1List.C1Combo
    Friend WithEvents cbPrintLabel As System.Windows.Forms.CheckBox
    Friend WithEvents _lblReceptBox As System.Windows.Forms.Label
    Friend WithEvents TabReport As System.Windows.Forms.TabPage
    Friend WithEvents _lblReportFromDate As System.Windows.Forms.Label
    Friend WithEvents _lblReportToDate As System.Windows.Forms.Label
    Friend WithEvents dtpReportToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReportFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnReportDetails As System.Windows.Forms.Button
    Friend WithEvents btnReportSummary As System.Windows.Forms.Button
    Friend WithEvents TabBox As System.Windows.Forms.TabPage
    Friend WithEvents _lblRMA As System.Windows.Forms.Label
    Friend WithEvents txtRMA As System.Windows.Forms.TextBox
    Friend WithEvents cboSelectedOpenBox As C1.Win.C1List.C1Combo
    Friend WithEvents TabTools As System.Windows.Forms.TabPage
    Friend WithEvents TabControlTools As System.Windows.Forms.TabControl
    Friend WithEvents TabToolsFreq As System.Windows.Forms.TabPage
    Friend WithEvents btnToolsAddFreq As System.Windows.Forms.Button
    Friend WithEvents _lblToolsAddFreq As System.Windows.Forms.Label
    Friend WithEvents mskToolsFreq As AxMSMask.AxMaskEdBox
    Friend WithEvents btnBoxDelete As System.Windows.Forms.Button
    Friend WithEvents btnReportWarehouseInventoryItems As System.Windows.Forms.Button
    Friend WithEvents lblCust As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAquisWHRec))
        Me.PnlReceipt = New System.Windows.Forms.Panel()
        Me._lblReceptBox = New System.Windows.Forms.Label()
        Me.cboSelectedOpenBox = New C1.Win.C1List.C1Combo()
        Me.dbgReceipt = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.gbCustomerReceipt = New System.Windows.Forms.GroupBox()
        Me._lblRMA = New System.Windows.Forms.Label()
        Me.txtRMA = New System.Windows.Forms.TextBox()
        Me.btnReceiptReOpen = New System.Windows.Forms.Button()
        Me.btnReceiptCreate = New System.Windows.Forms.Button()
        Me._lblAccountNo = New System.Windows.Forms.Label()
        Me._lblCustomerName = New System.Windows.Forms.Label()
        Me.txtAccountNo = New System.Windows.Forms.TextBox()
        Me._lblTrackingNo = New System.Windows.Forms.Label()
        Me.txtTrackingNo = New System.Windows.Forms.TextBox()
        Me._lblCarrier = New System.Windows.Forms.Label()
        Me.cboCarrier = New C1.Win.C1List.C1Combo()
        Me.cboCustomer = New C1.Win.C1List.C1Combo()
        Me.lblReceiptName = New System.Windows.Forms.Label()
        Me.gbReceiptItemDetails = New System.Windows.Forms.GroupBox()
        Me.rdbInventoryMgt = New System.Windows.Forms.RadioButton()
        Me.rdbReturnMgt = New System.Windows.Forms.RadioButton()
        Me._lblBaudRate = New System.Windows.Forms.Label()
        Me._lblFrequency = New System.Windows.Forms.Label()
        Me._lbModel = New System.Windows.Forms.Label()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.cboFrequency = New C1.Win.C1List.C1Combo()
        Me.cboBaudRate = New C1.Win.C1List.C1Combo()
        Me._lblPagerNo = New System.Windows.Forms.Label()
        Me.txtPagerNo = New System.Windows.Forms.TextBox()
        Me.txtSerialNo = New System.Windows.Forms.TextBox()
        Me._lblCapCode = New System.Windows.Forms.Label()
        Me._lblSerial = New System.Windows.Forms.Label()
        Me.txtCapCode = New System.Windows.Forms.TextBox()
        Me.gbPagerCondition = New System.Windows.Forms.GroupBox()
        Me.cbPrintLabel = New System.Windows.Forms.CheckBox()
        Me._lblPhysicalAbuse = New System.Windows.Forms.Label()
        Me.cboPhysicalAbuse = New C1.Win.C1List.C1Combo()
        Me._lblComment = New System.Windows.Forms.Label()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.cboBatteryCoverCondition = New C1.Win.C1List.C1Combo()
        Me._lblBatteryCover = New System.Windows.Forms.Label()
        Me.cboCaseCondition = New C1.Win.C1List.C1Combo()
        Me._lblCase = New System.Windows.Forms.Label()
        Me.cboHolderCondition = New C1.Win.C1List.C1Combo()
        Me._lblHolderCondition = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabReceive = New System.Windows.Forms.TabPage()
        Me.PnlReceiptItems = New System.Windows.Forms.Panel()
        Me.btnReceiptRemove = New System.Windows.Forms.Button()
        Me.btnReceiptPrintLabel = New System.Windows.Forms.Button()
        Me.lblReceiptQTY = New System.Windows.Forms.Label()
        Me.lstReceiptSN = New System.Windows.Forms.ListBox()
        Me.btnReceiptClose = New System.Windows.Forms.Button()
        Me.TabCustomerAddress = New System.Windows.Forms.TabPage()
        Me.gbCustInfo = New System.Windows.Forms.GroupBox()
        Me.btnCreateCustomerAddress = New System.Windows.Forms.Button()
        Me._lblCompanyName = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me._lblEmailAddress = New System.Windows.Forms.Label()
        Me.cboStates = New C1.Win.C1List.C1Combo()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me._lblFaxNumber = New System.Windows.Forms.Label()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me._lblPhoneNumber = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me._lblZipCode = New System.Windows.Forms.Label()
        Me._lblState = New System.Windows.Forms.Label()
        Me._lblCity = New System.Windows.Forms.Label()
        Me._lblAddress2 = New System.Windows.Forms.Label()
        Me._lblAddress1 = New System.Windows.Forms.Label()
        Me._lblLastName = New System.Windows.Forms.Label()
        Me._lblFirstName = New System.Windows.Forms.Label()
        Me._lblCountry = New System.Windows.Forms.Label()
        Me.cboCountries = New C1.Win.C1List.C1Combo()
        Me._lblMIName = New System.Windows.Forms.Label()
        Me.txtMiName = New System.Windows.Forms.TextBox()
        Me.TabBox = New System.Windows.Forms.TabPage()
        Me.PnlBox = New System.Windows.Forms.Panel()
        Me.gbCreateBox = New System.Windows.Forms.GroupBox()
        Me.btnBoxDelete = New System.Windows.Forms.Button()
        Me.cboBox_BaudRate = New C1.Win.C1List.C1Combo()
        Me.cboBox_Frequency = New C1.Win.C1List.C1Combo()
        Me._lbMB_Model = New System.Windows.Forms.Label()
        Me.cboBox_Models = New C1.Win.C1List.C1Combo()
        Me._lbMB_Frequency = New System.Windows.Forms.Label()
        Me._lbMB_BaudRate = New System.Windows.Forms.Label()
        Me.btnBoxCreate = New System.Windows.Forms.Button()
        Me.btnBoxReopen = New System.Windows.Forms.Button()
        Me.btnBoxReprintLabel = New System.Windows.Forms.Button()
        Me.dbgBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.PnlBoxItems = New System.Windows.Forms.Panel()
        Me.gbBoxItems = New System.Windows.Forms.GroupBox()
        Me.btnBoxClose = New System.Windows.Forms.Button()
        Me.btnBoxRemove = New System.Windows.Forms.Button()
        Me.lblBoxName = New System.Windows.Forms.Label()
        Me.lblBoxQTY = New System.Windows.Forms.Label()
        Me._lblBoxSerialSN = New System.Windows.Forms.Label()
        Me.txtBoxSN = New System.Windows.Forms.TextBox()
        Me.lstBoxSN = New System.Windows.Forms.ListBox()
        Me.btnBoxEmptyBox = New System.Windows.Forms.Button()
        Me.TabReport = New System.Windows.Forms.TabPage()
        Me.btnReportWarehouseInventoryItems = New System.Windows.Forms.Button()
        Me.btnReportSummary = New System.Windows.Forms.Button()
        Me.btnReportDetails = New System.Windows.Forms.Button()
        Me._lblReportToDate = New System.Windows.Forms.Label()
        Me._lblReportFromDate = New System.Windows.Forms.Label()
        Me.dtpReportToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpReportFromDate = New System.Windows.Forms.DateTimePicker()
        Me.TabTools = New System.Windows.Forms.TabPage()
        Me.TabControlTools = New System.Windows.Forms.TabControl()
        Me.TabToolsFreq = New System.Windows.Forms.TabPage()
        Me.mskToolsFreq = New AxMSMask.AxMaskEdBox()
        Me._lblToolsAddFreq = New System.Windows.Forms.Label()
        Me.btnToolsAddFreq = New System.Windows.Forms.Button()
        Me.lblCust = New System.Windows.Forms.Label()
        Me.PnlReceipt.SuspendLayout()
        CType(Me.cboSelectedOpenBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgReceipt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCustomerReceipt.SuspendLayout()
        CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReceiptItemDetails.SuspendLayout()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBaudRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPagerCondition.SuspendLayout()
        CType(Me.cboPhysicalAbuse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBatteryCoverCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCaseCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboHolderCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabReceive.SuspendLayout()
        Me.PnlReceiptItems.SuspendLayout()
        Me.TabCustomerAddress.SuspendLayout()
        Me.gbCustInfo.SuspendLayout()
        CType(Me.cboStates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCountries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabBox.SuspendLayout()
        Me.PnlBox.SuspendLayout()
        Me.gbCreateBox.SuspendLayout()
        CType(Me.cboBox_BaudRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBox_Frequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBox_Models, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBoxItems.SuspendLayout()
        Me.gbBoxItems.SuspendLayout()
        Me.TabReport.SuspendLayout()
        Me.TabTools.SuspendLayout()
        Me.TabControlTools.SuspendLayout()
        Me.TabToolsFreq.SuspendLayout()
        CType(Me.mskToolsFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlReceipt
        '
        Me.PnlReceipt.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.PnlReceipt.Controls.AddRange(New System.Windows.Forms.Control() {Me._lblReceptBox, Me.cboSelectedOpenBox, Me.dbgReceipt, Me.gbCustomerReceipt})
        Me.PnlReceipt.Location = New System.Drawing.Point(8, 8)
        Me.PnlReceipt.Name = "PnlReceipt"
        Me.PnlReceipt.Size = New System.Drawing.Size(304, 488)
        Me.PnlReceipt.TabIndex = 14
        '
        '_lblReceptBox
        '
        Me._lblReceptBox.ForeColor = System.Drawing.Color.Black
        Me._lblReceptBox.Location = New System.Drawing.Point(8, 448)
        Me._lblReceptBox.Name = "_lblReceptBox"
        Me._lblReceptBox.Size = New System.Drawing.Size(80, 20)
        Me._lblReceptBox.TabIndex = 26
        Me._lblReceptBox.Text = "WH Open Box:"
        Me._lblReceptBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSelectedOpenBox
        '
        Me.cboSelectedOpenBox.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboSelectedOpenBox.Caption = ""
        Me.cboSelectedOpenBox.CaptionHeight = 17
        Me.cboSelectedOpenBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSelectedOpenBox.ColumnCaptionHeight = 17
        Me.cboSelectedOpenBox.ColumnFooterHeight = 17
        Me.cboSelectedOpenBox.ContentHeight = 15
        Me.cboSelectedOpenBox.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboSelectedOpenBox.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboSelectedOpenBox.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSelectedOpenBox.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSelectedOpenBox.EditorHeight = 15
        Me.cboSelectedOpenBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSelectedOpenBox.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboSelectedOpenBox.ItemHeight = 15
        Me.cboSelectedOpenBox.Location = New System.Drawing.Point(96, 448)
        Me.cboSelectedOpenBox.MatchEntryTimeout = CType(2000, Long)
        Me.cboSelectedOpenBox.MaxDropDownItems = CType(5, Short)
        Me.cboSelectedOpenBox.MaxLength = 32767
        Me.cboSelectedOpenBox.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboSelectedOpenBox.Name = "cboSelectedOpenBox"
        Me.cboSelectedOpenBox.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboSelectedOpenBox.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboSelectedOpenBox.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboSelectedOpenBox.Size = New System.Drawing.Size(200, 21)
        Me.cboSelectedOpenBox.TabIndex = 27
        Me.cboSelectedOpenBox.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
        "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'dbgReceipt
        '
        Me.dbgReceipt.AllowColMove = False
        Me.dbgReceipt.AllowColSelect = False
        Me.dbgReceipt.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgReceipt.AllowSort = False
        Me.dbgReceipt.AllowUpdate = False
        Me.dbgReceipt.AllowUpdateOnBlur = False
        Me.dbgReceipt.AlternatingRows = True
        Me.dbgReceipt.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.dbgReceipt.Caption = "Open Receipts"
        Me.dbgReceipt.CaptionHeight = 19
        Me.dbgReceipt.CollapseColor = System.Drawing.Color.White
        Me.dbgReceipt.ExpandColor = System.Drawing.Color.White
        Me.dbgReceipt.FilterBar = True
        Me.dbgReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgReceipt.ForeColor = System.Drawing.Color.White
        Me.dbgReceipt.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgReceipt.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.dbgReceipt.Location = New System.Drawing.Point(8, 208)
        Me.dbgReceipt.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgReceipt.Name = "dbgReceipt"
        Me.dbgReceipt.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgReceipt.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgReceipt.PreviewInfo.ZoomFactor = 75
        Me.dbgReceipt.RowHeight = 20
        Me.dbgReceipt.Size = New System.Drawing.Size(288, 232)
        Me.dbgReceipt.TabIndex = 25
        Me.dbgReceipt.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
        "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
        "te;BackColor:InactiveCaption;}FilterBar{Font:Microsoft Sans Serif, 6.75pt, style" & _
        "=Bold;ForeColor:Black;BackColor:White;}Footer{}Caption{AlignHorz:Center;ForeColo" & _
        "r:White;BackColor:SteelBlue;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, s" & _
        "tyle=Bold;BackColor:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRo" & _
        "w{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{ForeColor:Black;B" & _
        "ackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;ForeColor:White;}Style" & _
        "13{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Ce" & _
        "nter;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;BackColor:Control" & _
        ";}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style16{}Style17{}S" & _
        "tyle1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fals" & _
        "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
        "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar" & _
        "=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=" & _
        """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>209</Height><Capt" & _
        "ionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5""" & _
        " /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBa" & _
        "r"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=" & _
        """Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRo" & _
        "wStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""" & _
        "Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent" & _
        "=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" />" & _
        "<Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 19, 284, 209</ClientRect><Bo" & _
        "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
        "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
        "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
        " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
        "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
        "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
        "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
        "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
        "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
        "17</DefaultRecSelWidth><ClientArea>0, 0, 284, 228</ClientArea><PrintPageHeaderSt" & _
        "yle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Bl" & _
        "ob>"
        '
        'gbCustomerReceipt
        '
        Me.gbCustomerReceipt.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.gbCustomerReceipt.Controls.AddRange(New System.Windows.Forms.Control() {Me._lblRMA, Me.txtRMA, Me.btnReceiptReOpen, Me.btnReceiptCreate, Me._lblAccountNo, Me._lblCustomerName, Me.txtAccountNo, Me._lblTrackingNo, Me.txtTrackingNo, Me._lblCarrier, Me.cboCarrier, Me.cboCustomer})
        Me.gbCustomerReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustomerReceipt.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.gbCustomerReceipt.Location = New System.Drawing.Point(8, 8)
        Me.gbCustomerReceipt.Name = "gbCustomerReceipt"
        Me.gbCustomerReceipt.Size = New System.Drawing.Size(288, 192)
        Me.gbCustomerReceipt.TabIndex = 7
        Me.gbCustomerReceipt.TabStop = False
        Me.gbCustomerReceipt.Text = "Customer Receipt"
        '
        '_lblRMA
        '
        Me._lblRMA.ForeColor = System.Drawing.Color.Black
        Me._lblRMA.Location = New System.Drawing.Point(8, 128)
        Me._lblRMA.Name = "_lblRMA"
        Me._lblRMA.Size = New System.Drawing.Size(104, 20)
        Me._lblRMA.TabIndex = 20
        Me._lblRMA.Text = "RMA# (Optional) :"
        Me._lblRMA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRMA
        '
        Me.txtRMA.BackColor = System.Drawing.Color.White
        Me.txtRMA.Location = New System.Drawing.Point(120, 128)
        Me.txtRMA.Name = "txtRMA"
        Me.txtRMA.Size = New System.Drawing.Size(160, 20)
        Me.txtRMA.TabIndex = 19
        Me.txtRMA.Text = ""
        '
        'btnReceiptReOpen
        '
        Me.btnReceiptReOpen.BackColor = System.Drawing.Color.Navy
        Me.btnReceiptReOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptReOpen.ForeColor = System.Drawing.Color.White
        Me.btnReceiptReOpen.Location = New System.Drawing.Point(8, 160)
        Me.btnReceiptReOpen.Name = "btnReceiptReOpen"
        Me.btnReceiptReOpen.Size = New System.Drawing.Size(104, 24)
        Me.btnReceiptReOpen.TabIndex = 18
        Me.btnReceiptReOpen.Text = "Re-Open"
        '
        'btnReceiptCreate
        '
        Me.btnReceiptCreate.BackColor = System.Drawing.Color.Green
        Me.btnReceiptCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptCreate.ForeColor = System.Drawing.Color.White
        Me.btnReceiptCreate.Location = New System.Drawing.Point(128, 160)
        Me.btnReceiptCreate.Name = "btnReceiptCreate"
        Me.btnReceiptCreate.Size = New System.Drawing.Size(136, 24)
        Me.btnReceiptCreate.TabIndex = 17
        Me.btnReceiptCreate.Text = "Create Receipt"
        '
        '_lblAccountNo
        '
        Me._lblAccountNo.ForeColor = System.Drawing.Color.Black
        Me._lblAccountNo.Location = New System.Drawing.Point(24, 56)
        Me._lblAccountNo.Name = "_lblAccountNo"
        Me._lblAccountNo.Size = New System.Drawing.Size(88, 20)
        Me._lblAccountNo.TabIndex = 9
        Me._lblAccountNo.Text = "Account # :"
        Me._lblAccountNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblCustomerName
        '
        Me._lblCustomerName.ForeColor = System.Drawing.Color.Black
        Me._lblCustomerName.Location = New System.Drawing.Point(16, 32)
        Me._lblCustomerName.Name = "_lblCustomerName"
        Me._lblCustomerName.Size = New System.Drawing.Size(96, 20)
        Me._lblCustomerName.TabIndex = 8
        Me._lblCustomerName.Text = "Customer Name :"
        Me._lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAccountNo
        '
        Me.txtAccountNo.BackColor = System.Drawing.Color.White
        Me.txtAccountNo.Location = New System.Drawing.Point(120, 56)
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(160, 20)
        Me.txtAccountNo.TabIndex = 2
        Me.txtAccountNo.Text = ""
        '
        '_lblTrackingNo
        '
        Me._lblTrackingNo.ForeColor = System.Drawing.Color.Black
        Me._lblTrackingNo.Location = New System.Drawing.Point(24, 104)
        Me._lblTrackingNo.Name = "_lblTrackingNo"
        Me._lblTrackingNo.Size = New System.Drawing.Size(88, 20)
        Me._lblTrackingNo.TabIndex = 5
        Me._lblTrackingNo.Text = "Tracking# :"
        Me._lblTrackingNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTrackingNo
        '
        Me.txtTrackingNo.BackColor = System.Drawing.Color.White
        Me.txtTrackingNo.Location = New System.Drawing.Point(120, 104)
        Me.txtTrackingNo.Name = "txtTrackingNo"
        Me.txtTrackingNo.Size = New System.Drawing.Size(160, 20)
        Me.txtTrackingNo.TabIndex = 4
        Me.txtTrackingNo.Text = ""
        '
        '_lblCarrier
        '
        Me._lblCarrier.ForeColor = System.Drawing.Color.Black
        Me._lblCarrier.Location = New System.Drawing.Point(8, 80)
        Me._lblCarrier.Name = "_lblCarrier"
        Me._lblCarrier.Size = New System.Drawing.Size(104, 20)
        Me._lblCarrier.TabIndex = 3
        Me._lblCarrier.Text = "Shipment Carrier :"
        Me._lblCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cboCarrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarrier.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCarrier.EditorHeight = 15
        Me.cboCarrier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarrier.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboCarrier.ItemHeight = 15
        Me.cboCarrier.Location = New System.Drawing.Point(120, 80)
        Me.cboCarrier.MatchEntryTimeout = CType(2000, Long)
        Me.cboCarrier.MaxDropDownItems = CType(5, Short)
        Me.cboCarrier.MaxLength = 32767
        Me.cboCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCarrier.Name = "cboCarrier"
        Me.cboCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCarrier.Size = New System.Drawing.Size(160, 21)
        Me.cboCarrier.TabIndex = 3
        Me.cboCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
        "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
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
        Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCustomer.EditorHeight = 15
        Me.cboCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboCustomer.ItemHeight = 15
        Me.cboCustomer.Location = New System.Drawing.Point(120, 32)
        Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomer.MaxDropDownItems = CType(5, Short)
        Me.cboCustomer.MaxLength = 32767
        Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomer.Size = New System.Drawing.Size(160, 21)
        Me.cboCustomer.TabIndex = 1
        Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
        "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'lblReceiptName
        '
        Me.lblReceiptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptName.Location = New System.Drawing.Point(328, 8)
        Me.lblReceiptName.Name = "lblReceiptName"
        Me.lblReceiptName.Size = New System.Drawing.Size(192, 23)
        Me.lblReceiptName.TabIndex = 10
        Me.lblReceiptName.Text = "Receipt Name"
        Me.lblReceiptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbReceiptItemDetails
        '
        Me.gbReceiptItemDetails.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.gbReceiptItemDetails.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCust, Me.rdbInventoryMgt, Me.rdbReturnMgt, Me._lblBaudRate, Me._lblFrequency, Me._lbModel, Me.cboModels, Me.cboFrequency, Me.cboBaudRate})
        Me.gbReceiptItemDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReceiptItemDetails.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.gbReceiptItemDetails.Location = New System.Drawing.Point(8, 8)
        Me.gbReceiptItemDetails.Name = "gbReceiptItemDetails"
        Me.gbReceiptItemDetails.Size = New System.Drawing.Size(312, 144)
        Me.gbReceiptItemDetails.TabIndex = 8
        Me.gbReceiptItemDetails.TabStop = False
        Me.gbReceiptItemDetails.Text = "Receipt Item Details"
        '
        'rdbInventoryMgt
        '
        Me.rdbInventoryMgt.Checked = True
        Me.rdbInventoryMgt.Location = New System.Drawing.Point(160, 32)
        Me.rdbInventoryMgt.Name = "rdbInventoryMgt"
        Me.rdbInventoryMgt.Size = New System.Drawing.Size(144, 24)
        Me.rdbInventoryMgt.TabIndex = 20
        Me.rdbInventoryMgt.TabStop = True
        Me.rdbInventoryMgt.Text = "Inventory Management"
        '
        'rdbReturnMgt
        '
        Me.rdbReturnMgt.Location = New System.Drawing.Point(8, 32)
        Me.rdbReturnMgt.Name = "rdbReturnMgt"
        Me.rdbReturnMgt.Size = New System.Drawing.Size(136, 24)
        Me.rdbReturnMgt.TabIndex = 19
        Me.rdbReturnMgt.Text = "Return Management"
        '
        '_lblBaudRate
        '
        Me._lblBaudRate.ForeColor = System.Drawing.Color.Black
        Me._lblBaudRate.Location = New System.Drawing.Point(16, 112)
        Me._lblBaudRate.Name = "_lblBaudRate"
        Me._lblBaudRate.Size = New System.Drawing.Size(88, 20)
        Me._lblBaudRate.TabIndex = 5
        Me._lblBaudRate.Text = "Baud Rate :"
        Me._lblBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblFrequency
        '
        Me._lblFrequency.ForeColor = System.Drawing.Color.Black
        Me._lblFrequency.Location = New System.Drawing.Point(-8, 88)
        Me._lblFrequency.Name = "_lblFrequency"
        Me._lblFrequency.Size = New System.Drawing.Size(112, 20)
        Me._lblFrequency.TabIndex = 3
        Me._lblFrequency.Text = "Frequency :"
        Me._lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lbModel
        '
        Me._lbModel.ForeColor = System.Drawing.Color.Black
        Me._lbModel.Location = New System.Drawing.Point(16, 64)
        Me._lbModel.Name = "_lbModel"
        Me._lbModel.Size = New System.Drawing.Size(88, 20)
        Me._lbModel.TabIndex = 2
        Me._lbModel.Text = "Model:"
        Me._lbModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboModels
        '
        Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboModels.Caption = ""
        Me.cboModels.CaptionHeight = 17
        Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModels.ColumnCaptionHeight = 17
        Me.cboModels.ColumnFooterHeight = 17
        Me.cboModels.ContentHeight = 15
        Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModels.EditorHeight = 15
        Me.cboModels.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(104, 64)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(5, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(200, 21)
        Me.cboModels.TabIndex = 15
        Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;" & _
        "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
        "ol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'cboFrequency
        '
        Me.cboFrequency.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboFrequency.Caption = ""
        Me.cboFrequency.CaptionHeight = 17
        Me.cboFrequency.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFrequency.ColumnCaptionHeight = 17
        Me.cboFrequency.ColumnFooterHeight = 17
        Me.cboFrequency.ContentHeight = 15
        Me.cboFrequency.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFrequency.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFrequency.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFrequency.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFrequency.EditorHeight = 15
        Me.cboFrequency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFrequency.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
        Me.cboFrequency.ItemHeight = 15
        Me.cboFrequency.Location = New System.Drawing.Point(104, 88)
        Me.cboFrequency.MatchEntryTimeout = CType(2000, Long)
        Me.cboFrequency.MaxDropDownItems = CType(5, Short)
        Me.cboFrequency.MaxLength = 32767
        Me.cboFrequency.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFrequency.Name = "cboFrequency"
        Me.cboFrequency.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFrequency.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFrequency.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFrequency.Size = New System.Drawing.Size(200, 21)
        Me.cboFrequency.TabIndex = 16
        Me.cboFrequency.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
        "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'cboBaudRate
        '
        Me.cboBaudRate.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboBaudRate.Caption = ""
        Me.cboBaudRate.CaptionHeight = 17
        Me.cboBaudRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBaudRate.ColumnCaptionHeight = 17
        Me.cboBaudRate.ColumnFooterHeight = 17
        Me.cboBaudRate.ContentHeight = 15
        Me.cboBaudRate.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBaudRate.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBaudRate.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBaudRate.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBaudRate.EditorHeight = 15
        Me.cboBaudRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBaudRate.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
        Me.cboBaudRate.ItemHeight = 15
        Me.cboBaudRate.Location = New System.Drawing.Point(104, 112)
        Me.cboBaudRate.MatchEntryTimeout = CType(2000, Long)
        Me.cboBaudRate.MaxDropDownItems = CType(5, Short)
        Me.cboBaudRate.MaxLength = 32767
        Me.cboBaudRate.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBaudRate.Name = "cboBaudRate"
        Me.cboBaudRate.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBaudRate.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBaudRate.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBaudRate.Size = New System.Drawing.Size(200, 21)
        Me.cboBaudRate.TabIndex = 17
        Me.cboBaudRate.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;" & _
        "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
        "ol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        '_lblPagerNo
        '
        Me._lblPagerNo.ForeColor = System.Drawing.Color.Black
        Me._lblPagerNo.Location = New System.Drawing.Point(32, 256)
        Me._lblPagerNo.Name = "_lblPagerNo"
        Me._lblPagerNo.Size = New System.Drawing.Size(72, 20)
        Me._lblPagerNo.TabIndex = 2
        Me._lblPagerNo.Text = "Pager Tel #:"
        Me._lblPagerNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPagerNo
        '
        Me.txtPagerNo.BackColor = System.Drawing.Color.White
        Me.txtPagerNo.Location = New System.Drawing.Point(104, 256)
        Me.txtPagerNo.Name = "txtPagerNo"
        Me.txtPagerNo.Size = New System.Drawing.Size(200, 20)
        Me.txtPagerNo.TabIndex = 23
        Me.txtPagerNo.Text = ""
        '
        'txtSerialNo
        '
        Me.txtSerialNo.BackColor = System.Drawing.Color.White
        Me.txtSerialNo.Location = New System.Drawing.Point(104, 288)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.Size = New System.Drawing.Size(200, 20)
        Me.txtSerialNo.TabIndex = 24
        Me.txtSerialNo.Text = ""
        '
        '_lblCapCode
        '
        Me._lblCapCode.ForeColor = System.Drawing.Color.Black
        Me._lblCapCode.Location = New System.Drawing.Point(16, 224)
        Me._lblCapCode.Name = "_lblCapCode"
        Me._lblCapCode.Size = New System.Drawing.Size(88, 20)
        Me._lblCapCode.TabIndex = 9
        Me._lblCapCode.Text = "Cap Code :"
        Me._lblCapCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblSerial
        '
        Me._lblSerial.ForeColor = System.Drawing.Color.Black
        Me._lblSerial.Location = New System.Drawing.Point(8, 288)
        Me._lblSerial.Name = "_lblSerial"
        Me._lblSerial.Size = New System.Drawing.Size(96, 20)
        Me._lblSerial.TabIndex = 8
        Me._lblSerial.Text = "Serial # :"
        Me._lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCapCode
        '
        Me.txtCapCode.BackColor = System.Drawing.Color.White
        Me.txtCapCode.Location = New System.Drawing.Point(104, 224)
        Me.txtCapCode.Name = "txtCapCode"
        Me.txtCapCode.Size = New System.Drawing.Size(200, 20)
        Me.txtCapCode.TabIndex = 22
        Me.txtCapCode.Text = ""
        '
        'gbPagerCondition
        '
        Me.gbPagerCondition.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.gbPagerCondition.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbPrintLabel, Me._lblPhysicalAbuse, Me.cboPhysicalAbuse, Me._lblComment, Me.txtComment, Me.cboBatteryCoverCondition, Me._lblBatteryCover, Me.cboCaseCondition, Me._lblCase, Me.cboHolderCondition, Me._lblHolderCondition, Me._lblSerial, Me.txtSerialNo, Me._lblCapCode, Me.txtCapCode, Me.txtPagerNo, Me._lblPagerNo})
        Me.gbPagerCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPagerCondition.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.gbPagerCondition.Location = New System.Drawing.Point(8, 152)
        Me.gbPagerCondition.Name = "gbPagerCondition"
        Me.gbPagerCondition.Size = New System.Drawing.Size(312, 320)
        Me.gbPagerCondition.TabIndex = 6
        Me.gbPagerCondition.TabStop = False
        Me.gbPagerCondition.Text = "Pager Condition"
        '
        'cbPrintLabel
        '
        Me.cbPrintLabel.Location = New System.Drawing.Point(104, 200)
        Me.cbPrintLabel.Name = "cbPrintLabel"
        Me.cbPrintLabel.TabIndex = 24
        Me.cbPrintLabel.Text = "Print Label"
        '
        '_lblPhysicalAbuse
        '
        Me._lblPhysicalAbuse.ForeColor = System.Drawing.Color.Black
        Me._lblPhysicalAbuse.Location = New System.Drawing.Point(8, 24)
        Me._lblPhysicalAbuse.Name = "_lblPhysicalAbuse"
        Me._lblPhysicalAbuse.Size = New System.Drawing.Size(104, 20)
        Me._lblPhysicalAbuse.TabIndex = 23
        Me._lblPhysicalAbuse.Text = "Physical Abuse:"
        Me._lblPhysicalAbuse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPhysicalAbuse
        '
        Me.cboPhysicalAbuse.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboPhysicalAbuse.Caption = ""
        Me.cboPhysicalAbuse.CaptionHeight = 17
        Me.cboPhysicalAbuse.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPhysicalAbuse.ColumnCaptionHeight = 17
        Me.cboPhysicalAbuse.ColumnFooterHeight = 17
        Me.cboPhysicalAbuse.ContentHeight = 15
        Me.cboPhysicalAbuse.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPhysicalAbuse.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPhysicalAbuse.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPhysicalAbuse.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPhysicalAbuse.EditorHeight = 15
        Me.cboPhysicalAbuse.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPhysicalAbuse.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
        Me.cboPhysicalAbuse.ItemHeight = 15
        Me.cboPhysicalAbuse.Location = New System.Drawing.Point(112, 24)
        Me.cboPhysicalAbuse.MatchEntryTimeout = CType(2000, Long)
        Me.cboPhysicalAbuse.MaxDropDownItems = CType(5, Short)
        Me.cboPhysicalAbuse.MaxLength = 32767
        Me.cboPhysicalAbuse.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPhysicalAbuse.Name = "cboPhysicalAbuse"
        Me.cboPhysicalAbuse.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPhysicalAbuse.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPhysicalAbuse.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPhysicalAbuse.Size = New System.Drawing.Size(192, 21)
        Me.cboPhysicalAbuse.TabIndex = 18
        Me.cboPhysicalAbuse.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
        "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        '_lblComment
        '
        Me._lblComment.ForeColor = System.Drawing.Color.Black
        Me._lblComment.Location = New System.Drawing.Point(0, 136)
        Me._lblComment.Name = "_lblComment"
        Me._lblComment.Size = New System.Drawing.Size(64, 20)
        Me._lblComment.TabIndex = 20
        Me._lblComment.Text = "Comment :"
        Me._lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtComment
        '
        Me.txtComment.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.txtComment.Location = New System.Drawing.Point(8, 152)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(296, 40)
        Me.txtComment.TabIndex = 19
        Me.txtComment.Text = ""
        '
        'cboBatteryCoverCondition
        '
        Me.cboBatteryCoverCondition.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboBatteryCoverCondition.Caption = ""
        Me.cboBatteryCoverCondition.CaptionHeight = 17
        Me.cboBatteryCoverCondition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBatteryCoverCondition.ColumnCaptionHeight = 17
        Me.cboBatteryCoverCondition.ColumnFooterHeight = 17
        Me.cboBatteryCoverCondition.ContentHeight = 15
        Me.cboBatteryCoverCondition.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBatteryCoverCondition.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBatteryCoverCondition.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBatteryCoverCondition.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBatteryCoverCondition.EditorHeight = 15
        Me.cboBatteryCoverCondition.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBatteryCoverCondition.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
        Me.cboBatteryCoverCondition.ItemHeight = 15
        Me.cboBatteryCoverCondition.Location = New System.Drawing.Point(112, 120)
        Me.cboBatteryCoverCondition.MatchEntryTimeout = CType(2000, Long)
        Me.cboBatteryCoverCondition.MaxDropDownItems = CType(5, Short)
        Me.cboBatteryCoverCondition.MaxLength = 32767
        Me.cboBatteryCoverCondition.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBatteryCoverCondition.Name = "cboBatteryCoverCondition"
        Me.cboBatteryCoverCondition.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBatteryCoverCondition.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBatteryCoverCondition.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBatteryCoverCondition.Size = New System.Drawing.Size(192, 21)
        Me.cboBatteryCoverCondition.TabIndex = 21
        Me.cboBatteryCoverCondition.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
        "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        '_lblBatteryCover
        '
        Me._lblBatteryCover.ForeColor = System.Drawing.Color.Black
        Me._lblBatteryCover.Location = New System.Drawing.Point(24, 120)
        Me._lblBatteryCover.Name = "_lblBatteryCover"
        Me._lblBatteryCover.Size = New System.Drawing.Size(88, 20)
        Me._lblBatteryCover.TabIndex = 17
        Me._lblBatteryCover.Text = "Battery Cover :"
        Me._lblBatteryCover.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCaseCondition
        '
        Me.cboCaseCondition.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCaseCondition.Caption = ""
        Me.cboCaseCondition.CaptionHeight = 17
        Me.cboCaseCondition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCaseCondition.ColumnCaptionHeight = 17
        Me.cboCaseCondition.ColumnFooterHeight = 17
        Me.cboCaseCondition.ContentHeight = 15
        Me.cboCaseCondition.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCaseCondition.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCaseCondition.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaseCondition.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCaseCondition.EditorHeight = 15
        Me.cboCaseCondition.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaseCondition.Images.Add(CType(resources.GetObject("resource.Images9"), System.Drawing.Bitmap))
        Me.cboCaseCondition.ItemHeight = 15
        Me.cboCaseCondition.Location = New System.Drawing.Point(112, 88)
        Me.cboCaseCondition.MatchEntryTimeout = CType(2000, Long)
        Me.cboCaseCondition.MaxDropDownItems = CType(5, Short)
        Me.cboCaseCondition.MaxLength = 32767
        Me.cboCaseCondition.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCaseCondition.Name = "cboCaseCondition"
        Me.cboCaseCondition.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCaseCondition.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCaseCondition.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCaseCondition.Size = New System.Drawing.Size(192, 21)
        Me.cboCaseCondition.TabIndex = 20
        Me.cboCaseCondition.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;" & _
        "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
        "ol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        '_lblCase
        '
        Me._lblCase.ForeColor = System.Drawing.Color.Black
        Me._lblCase.Location = New System.Drawing.Point(56, 88)
        Me._lblCase.Name = "_lblCase"
        Me._lblCase.Size = New System.Drawing.Size(56, 20)
        Me._lblCase.TabIndex = 15
        Me._lblCase.Text = "Case :"
        Me._lblCase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboHolderCondition
        '
        Me.cboHolderCondition.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboHolderCondition.Caption = ""
        Me.cboHolderCondition.CaptionHeight = 17
        Me.cboHolderCondition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboHolderCondition.ColumnCaptionHeight = 17
        Me.cboHolderCondition.ColumnFooterHeight = 17
        Me.cboHolderCondition.ContentHeight = 15
        Me.cboHolderCondition.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboHolderCondition.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboHolderCondition.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHolderCondition.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboHolderCondition.EditorHeight = 15
        Me.cboHolderCondition.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboHolderCondition.Images.Add(CType(resources.GetObject("resource.Images10"), System.Drawing.Bitmap))
        Me.cboHolderCondition.ItemHeight = 15
        Me.cboHolderCondition.Location = New System.Drawing.Point(112, 56)
        Me.cboHolderCondition.MatchEntryTimeout = CType(2000, Long)
        Me.cboHolderCondition.MaxDropDownItems = CType(5, Short)
        Me.cboHolderCondition.MaxLength = 32767
        Me.cboHolderCondition.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboHolderCondition.Name = "cboHolderCondition"
        Me.cboHolderCondition.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboHolderCondition.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboHolderCondition.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboHolderCondition.Size = New System.Drawing.Size(192, 21)
        Me.cboHolderCondition.TabIndex = 19
        Me.cboHolderCondition.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;" & _
        "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
        "ol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        '_lblHolderCondition
        '
        Me._lblHolderCondition.ForeColor = System.Drawing.Color.Black
        Me._lblHolderCondition.Location = New System.Drawing.Point(32, 56)
        Me._lblHolderCondition.Name = "_lblHolderCondition"
        Me._lblHolderCondition.Size = New System.Drawing.Size(80, 20)
        Me._lblHolderCondition.TabIndex = 11
        Me._lblHolderCondition.Text = "Holster/Clip:"
        Me._lblHolderCondition.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabReceive, Me.TabCustomerAddress, Me.TabBox, Me.TabReport, Me.TabTools})
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(856, 536)
        Me.TabControl1.TabIndex = 15
        '
        'TabReceive
        '
        Me.TabReceive.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.TabReceive.Controls.AddRange(New System.Windows.Forms.Control() {Me.PnlReceiptItems, Me.PnlReceipt})
        Me.TabReceive.Location = New System.Drawing.Point(4, 22)
        Me.TabReceive.Name = "TabReceive"
        Me.TabReceive.Size = New System.Drawing.Size(848, 510)
        Me.TabReceive.TabIndex = 1
        Me.TabReceive.Text = "Receiving"
        '
        'PnlReceiptItems
        '
        Me.PnlReceiptItems.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.PnlReceiptItems.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReceiptRemove, Me.btnReceiptPrintLabel, Me.lblReceiptQTY, Me.lstReceiptSN, Me.btnReceiptClose, Me.gbReceiptItemDetails, Me.gbPagerCondition, Me.lblReceiptName})
        Me.PnlReceiptItems.Location = New System.Drawing.Point(312, 8)
        Me.PnlReceiptItems.Name = "PnlReceiptItems"
        Me.PnlReceiptItems.Size = New System.Drawing.Size(528, 488)
        Me.PnlReceiptItems.TabIndex = 15
        '
        'btnReceiptRemove
        '
        Me.btnReceiptRemove.BackColor = System.Drawing.Color.Navy
        Me.btnReceiptRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptRemove.ForeColor = System.Drawing.Color.White
        Me.btnReceiptRemove.Location = New System.Drawing.Point(432, 400)
        Me.btnReceiptRemove.Name = "btnReceiptRemove"
        Me.btnReceiptRemove.Size = New System.Drawing.Size(80, 24)
        Me.btnReceiptRemove.TabIndex = 15
        Me.btnReceiptRemove.Text = "Remove SN"
        '
        'btnReceiptPrintLabel
        '
        Me.btnReceiptPrintLabel.BackColor = System.Drawing.Color.Purple
        Me.btnReceiptPrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptPrintLabel.ForeColor = System.Drawing.Color.White
        Me.btnReceiptPrintLabel.Location = New System.Drawing.Point(336, 400)
        Me.btnReceiptPrintLabel.Name = "btnReceiptPrintLabel"
        Me.btnReceiptPrintLabel.Size = New System.Drawing.Size(80, 24)
        Me.btnReceiptPrintLabel.TabIndex = 14
        Me.btnReceiptPrintLabel.Text = "Reprint"
        '
        'lblReceiptQTY
        '
        Me.lblReceiptQTY.BackColor = System.Drawing.Color.Black
        Me.lblReceiptQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptQTY.ForeColor = System.Drawing.Color.Green
        Me.lblReceiptQTY.Location = New System.Drawing.Point(368, 40)
        Me.lblReceiptQTY.Name = "lblReceiptQTY"
        Me.lblReceiptQTY.Size = New System.Drawing.Size(100, 32)
        Me.lblReceiptQTY.TabIndex = 13
        Me.lblReceiptQTY.Text = "0"
        Me.lblReceiptQTY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstReceiptSN
        '
        Me.lstReceiptSN.Location = New System.Drawing.Point(328, 72)
        Me.lstReceiptSN.Name = "lstReceiptSN"
        Me.lstReceiptSN.Size = New System.Drawing.Size(184, 316)
        Me.lstReceiptSN.TabIndex = 12
        '
        'btnReceiptClose
        '
        Me.btnReceiptClose.BackColor = System.Drawing.Color.Maroon
        Me.btnReceiptClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptClose.ForeColor = System.Drawing.Color.White
        Me.btnReceiptClose.Location = New System.Drawing.Point(336, 432)
        Me.btnReceiptClose.Name = "btnReceiptClose"
        Me.btnReceiptClose.Size = New System.Drawing.Size(176, 40)
        Me.btnReceiptClose.TabIndex = 11
        Me.btnReceiptClose.Text = "Close"
        '
        'TabCustomerAddress
        '
        Me.TabCustomerAddress.BackColor = System.Drawing.Color.RoyalBlue
        Me.TabCustomerAddress.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbCustInfo})
        Me.TabCustomerAddress.Location = New System.Drawing.Point(4, 22)
        Me.TabCustomerAddress.Name = "TabCustomerAddress"
        Me.TabCustomerAddress.Size = New System.Drawing.Size(848, 510)
        Me.TabCustomerAddress.TabIndex = 2
        Me.TabCustomerAddress.Text = "Customer Address"
        '
        'gbCustInfo
        '
        Me.gbCustInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCreateCustomerAddress, Me._lblCompanyName, Me.txtCompanyName, Me.txtEmail, Me._lblEmailAddress, Me.cboStates, Me.txtFax, Me._lblFaxNumber, Me.txtTel, Me._lblPhoneNumber, Me.txtZip, Me.txtCity, Me.txtAddress2, Me.txtAddress1, Me.txtLastName, Me.txtFirstName, Me._lblZipCode, Me._lblState, Me._lblCity, Me._lblAddress2, Me._lblAddress1, Me._lblLastName, Me._lblFirstName, Me._lblCountry, Me.cboCountries, Me._lblMIName, Me.txtMiName})
        Me.gbCustInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCustInfo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.gbCustInfo.Location = New System.Drawing.Point(32, 24)
        Me.gbCustInfo.Name = "gbCustInfo"
        Me.gbCustInfo.Size = New System.Drawing.Size(608, 296)
        Me.gbCustInfo.TabIndex = 3
        Me.gbCustInfo.TabStop = False
        Me.gbCustInfo.Text = "Customer Address Information"
        '
        'btnCreateCustomerAddress
        '
        Me.btnCreateCustomerAddress.BackColor = System.Drawing.Color.Purple
        Me.btnCreateCustomerAddress.Location = New System.Drawing.Point(256, 240)
        Me.btnCreateCustomerAddress.Name = "btnCreateCustomerAddress"
        Me.btnCreateCustomerAddress.Size = New System.Drawing.Size(192, 24)
        Me.btnCreateCustomerAddress.TabIndex = 12
        Me.btnCreateCustomerAddress.Text = "Create Customer Address"
        '
        '_lblCompanyName
        '
        Me._lblCompanyName.Location = New System.Drawing.Point(16, 32)
        Me._lblCompanyName.Name = "_lblCompanyName"
        Me._lblCompanyName.Size = New System.Drawing.Size(112, 16)
        Me._lblCompanyName.TabIndex = 34
        Me._lblCompanyName.Text = "Company:"
        Me._lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(136, 32)
        Me.txtCompanyName.MaxLength = 50
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(440, 20)
        Me.txtCompanyName.TabIndex = 0
        Me.txtCompanyName.Text = ""
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(136, 200)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(440, 20)
        Me.txtEmail.TabIndex = 11
        Me.txtEmail.Text = ""
        '
        '_lblEmailAddress
        '
        Me._lblEmailAddress.Location = New System.Drawing.Point(32, 200)
        Me._lblEmailAddress.Name = "_lblEmailAddress"
        Me._lblEmailAddress.Size = New System.Drawing.Size(96, 16)
        Me._lblEmailAddress.TabIndex = 32
        Me._lblEmailAddress.Text = "Email Address:"
        Me._lblEmailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboStates
        '
        Me.cboStates.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboStates.Caption = ""
        Me.cboStates.CaptionHeight = 17
        Me.cboStates.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboStates.ColumnCaptionHeight = 17
        Me.cboStates.ColumnFooterHeight = 17
        Me.cboStates.ContentHeight = 15
        Me.cboStates.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboStates.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboStates.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStates.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboStates.EditorHeight = 15
        Me.cboStates.Images.Add(CType(resources.GetObject("resource.Images11"), System.Drawing.Bitmap))
        Me.cboStates.ItemHeight = 15
        Me.cboStates.Location = New System.Drawing.Point(456, 128)
        Me.cboStates.MatchEntryTimeout = CType(2000, Long)
        Me.cboStates.MaxDropDownItems = CType(5, Short)
        Me.cboStates.MaxLength = 2
        Me.cboStates.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboStates.Name = "cboStates"
        Me.cboStates.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboStates.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboStates.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboStates.Size = New System.Drawing.Size(120, 21)
        Me.cboStates.TabIndex = 6
        Me.cboStates.Text = "TX"
        Me.cboStates.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(456, 176)
        Me.txtFax.MaxLength = 12
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(120, 20)
        Me.txtFax.TabIndex = 10
        Me.txtFax.Text = ""
        '
        '_lblFaxNumber
        '
        Me._lblFaxNumber.Location = New System.Drawing.Point(368, 176)
        Me._lblFaxNumber.Name = "_lblFaxNumber"
        Me._lblFaxNumber.Size = New System.Drawing.Size(80, 16)
        Me._lblFaxNumber.TabIndex = 30
        Me._lblFaxNumber.Text = "Fax Number:"
        Me._lblFaxNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(136, 176)
        Me.txtTel.MaxLength = 12
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(152, 20)
        Me.txtTel.TabIndex = 9
        Me.txtTel.Text = ""
        '
        '_lblPhoneNumber
        '
        Me._lblPhoneNumber.Location = New System.Drawing.Point(32, 176)
        Me._lblPhoneNumber.Name = "_lblPhoneNumber"
        Me._lblPhoneNumber.Size = New System.Drawing.Size(96, 16)
        Me._lblPhoneNumber.TabIndex = 27
        Me._lblPhoneNumber.Text = "Phone Number:"
        Me._lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(136, 152)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(104, 20)
        Me.txtZip.TabIndex = 7
        Me.txtZip.Text = ""
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(136, 128)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(272, 20)
        Me.txtCity.TabIndex = 5
        Me.txtCity.Text = ""
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(136, 104)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(440, 20)
        Me.txtAddress2.TabIndex = 4
        Me.txtAddress2.Text = ""
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(136, 80)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(440, 20)
        Me.txtAddress1.TabIndex = 3
        Me.txtAddress1.Text = ""
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(440, 56)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(136, 20)
        Me.txtLastName.TabIndex = 2
        Me.txtLastName.Text = ""
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(136, 56)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(128, 20)
        Me.txtFirstName.TabIndex = 1
        Me.txtFirstName.Text = ""
        '
        '_lblZipCode
        '
        Me._lblZipCode.Location = New System.Drawing.Point(72, 152)
        Me._lblZipCode.Name = "_lblZipCode"
        Me._lblZipCode.Size = New System.Drawing.Size(56, 16)
        Me._lblZipCode.TabIndex = 13
        Me._lblZipCode.Text = "Zip Code:"
        Me._lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblState
        '
        Me._lblState.Location = New System.Drawing.Point(416, 128)
        Me._lblState.Name = "_lblState"
        Me._lblState.Size = New System.Drawing.Size(40, 16)
        Me._lblState.TabIndex = 10
        Me._lblState.Text = "State:"
        Me._lblState.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCity
        '
        Me._lblCity.Location = New System.Drawing.Point(56, 128)
        Me._lblCity.Name = "_lblCity"
        Me._lblCity.Size = New System.Drawing.Size(72, 16)
        Me._lblCity.TabIndex = 11
        Me._lblCity.Text = "City:"
        Me._lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblAddress2
        '
        Me._lblAddress2.Location = New System.Drawing.Point(56, 104)
        Me._lblAddress2.Name = "_lblAddress2"
        Me._lblAddress2.Size = New System.Drawing.Size(72, 16)
        Me._lblAddress2.TabIndex = 16
        Me._lblAddress2.Text = "Address(2):"
        Me._lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblAddress1
        '
        Me._lblAddress1.Location = New System.Drawing.Point(56, 80)
        Me._lblAddress1.Name = "_lblAddress1"
        Me._lblAddress1.Size = New System.Drawing.Size(72, 16)
        Me._lblAddress1.TabIndex = 17
        Me._lblAddress1.Text = "Address(1):"
        Me._lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblLastName
        '
        Me._lblLastName.Location = New System.Drawing.Point(376, 56)
        Me._lblLastName.Name = "_lblLastName"
        Me._lblLastName.Size = New System.Drawing.Size(64, 16)
        Me._lblLastName.TabIndex = 14
        Me._lblLastName.Text = "Last Name:"
        Me._lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblFirstName
        '
        Me._lblFirstName.Location = New System.Drawing.Point(56, 56)
        Me._lblFirstName.Name = "_lblFirstName"
        Me._lblFirstName.Size = New System.Drawing.Size(72, 16)
        Me._lblFirstName.TabIndex = 15
        Me._lblFirstName.Text = "First Name:"
        Me._lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblCountry
        '
        Me._lblCountry.Location = New System.Drawing.Point(328, 152)
        Me._lblCountry.Name = "_lblCountry"
        Me._lblCountry.Size = New System.Drawing.Size(56, 16)
        Me._lblCountry.TabIndex = 12
        Me._lblCountry.Text = "Country:"
        Me._lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCountries
        '
        Me.cboCountries.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCountries.Caption = ""
        Me.cboCountries.CaptionHeight = 17
        Me.cboCountries.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCountries.ColumnCaptionHeight = 17
        Me.cboCountries.ColumnFooterHeight = 17
        Me.cboCountries.ContentHeight = 15
        Me.cboCountries.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCountries.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCountries.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCountries.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCountries.EditorHeight = 15
        Me.cboCountries.Images.Add(CType(resources.GetObject("resource.Images12"), System.Drawing.Bitmap))
        Me.cboCountries.ItemHeight = 15
        Me.cboCountries.Location = New System.Drawing.Point(392, 152)
        Me.cboCountries.MatchEntryTimeout = CType(2000, Long)
        Me.cboCountries.MaxDropDownItems = CType(5, Short)
        Me.cboCountries.MaxLength = 32767
        Me.cboCountries.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCountries.Name = "cboCountries"
        Me.cboCountries.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCountries.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCountries.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCountries.Size = New System.Drawing.Size(184, 21)
        Me.cboCountries.TabIndex = 8
        Me.cboCountries.Text = "C1Combo1"
        Me.cboCountries.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        '_lblMIName
        '
        Me._lblMIName.Location = New System.Drawing.Point(272, 56)
        Me._lblMIName.Name = "_lblMIName"
        Me._lblMIName.Size = New System.Drawing.Size(32, 16)
        Me._lblMIName.TabIndex = 16
        Me._lblMIName.Text = "MI:"
        Me._lblMIName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMiName
        '
        Me.txtMiName.Location = New System.Drawing.Point(304, 56)
        Me.txtMiName.Name = "txtMiName"
        Me.txtMiName.Size = New System.Drawing.Size(56, 20)
        Me.txtMiName.TabIndex = 15
        Me.txtMiName.Text = ""
        '
        'TabBox
        '
        Me.TabBox.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.TabBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.PnlBox, Me.PnlBoxItems})
        Me.TabBox.Location = New System.Drawing.Point(4, 22)
        Me.TabBox.Name = "TabBox"
        Me.TabBox.Size = New System.Drawing.Size(848, 510)
        Me.TabBox.TabIndex = 0
        Me.TabBox.Text = "Warehouse Box"
        '
        'PnlBox
        '
        Me.PnlBox.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.PnlBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbCreateBox, Me.dbgBoxes})
        Me.PnlBox.Location = New System.Drawing.Point(0, 8)
        Me.PnlBox.Name = "PnlBox"
        Me.PnlBox.Size = New System.Drawing.Size(408, 488)
        Me.PnlBox.TabIndex = 135
        '
        'gbCreateBox
        '
        Me.gbCreateBox.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.gbCreateBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBoxDelete, Me.cboBox_BaudRate, Me.cboBox_Frequency, Me._lbMB_Model, Me.cboBox_Models, Me._lbMB_Frequency, Me._lbMB_BaudRate, Me.btnBoxCreate, Me.btnBoxReopen, Me.btnBoxReprintLabel})
        Me.gbCreateBox.Location = New System.Drawing.Point(8, 8)
        Me.gbCreateBox.Name = "gbCreateBox"
        Me.gbCreateBox.Size = New System.Drawing.Size(392, 176)
        Me.gbCreateBox.TabIndex = 132
        Me.gbCreateBox.TabStop = False
        Me.gbCreateBox.Text = "Create New Box"
        '
        'btnBoxDelete
        '
        Me.btnBoxDelete.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.btnBoxDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoxDelete.ForeColor = System.Drawing.Color.White
        Me.btnBoxDelete.Location = New System.Drawing.Point(8, 24)
        Me.btnBoxDelete.Name = "btnBoxDelete"
        Me.btnBoxDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBoxDelete.Size = New System.Drawing.Size(80, 32)
        Me.btnBoxDelete.TabIndex = 132
        Me.btnBoxDelete.Text = "DELETE"
        '
        'cboBox_BaudRate
        '
        Me.cboBox_BaudRate.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboBox_BaudRate.Caption = ""
        Me.cboBox_BaudRate.CaptionHeight = 17
        Me.cboBox_BaudRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBox_BaudRate.ColumnCaptionHeight = 17
        Me.cboBox_BaudRate.ColumnFooterHeight = 17
        Me.cboBox_BaudRate.ContentHeight = 15
        Me.cboBox_BaudRate.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBox_BaudRate.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBox_BaudRate.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBox_BaudRate.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBox_BaudRate.EditorHeight = 15
        Me.cboBox_BaudRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBox_BaudRate.Images.Add(CType(resources.GetObject("resource.Images13"), System.Drawing.Bitmap))
        Me.cboBox_BaudRate.ItemHeight = 15
        Me.cboBox_BaudRate.Location = New System.Drawing.Point(176, 96)
        Me.cboBox_BaudRate.MatchEntryTimeout = CType(2000, Long)
        Me.cboBox_BaudRate.MaxDropDownItems = CType(5, Short)
        Me.cboBox_BaudRate.MaxLength = 32767
        Me.cboBox_BaudRate.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBox_BaudRate.Name = "cboBox_BaudRate"
        Me.cboBox_BaudRate.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBox_BaudRate.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBox_BaudRate.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBox_BaudRate.Size = New System.Drawing.Size(200, 21)
        Me.cboBox_BaudRate.TabIndex = 20
        Me.cboBox_BaudRate.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
        "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'cboBox_Frequency
        '
        Me.cboBox_Frequency.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboBox_Frequency.Caption = ""
        Me.cboBox_Frequency.CaptionHeight = 17
        Me.cboBox_Frequency.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBox_Frequency.ColumnCaptionHeight = 17
        Me.cboBox_Frequency.ColumnFooterHeight = 17
        Me.cboBox_Frequency.ContentHeight = 15
        Me.cboBox_Frequency.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBox_Frequency.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBox_Frequency.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBox_Frequency.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBox_Frequency.EditorHeight = 15
        Me.cboBox_Frequency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBox_Frequency.Images.Add(CType(resources.GetObject("resource.Images14"), System.Drawing.Bitmap))
        Me.cboBox_Frequency.ItemHeight = 15
        Me.cboBox_Frequency.Location = New System.Drawing.Point(176, 64)
        Me.cboBox_Frequency.MatchEntryTimeout = CType(2000, Long)
        Me.cboBox_Frequency.MaxDropDownItems = CType(5, Short)
        Me.cboBox_Frequency.MaxLength = 32767
        Me.cboBox_Frequency.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBox_Frequency.Name = "cboBox_Frequency"
        Me.cboBox_Frequency.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBox_Frequency.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBox_Frequency.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBox_Frequency.Size = New System.Drawing.Size(200, 21)
        Me.cboBox_Frequency.TabIndex = 19
        Me.cboBox_Frequency.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;" & _
        "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
        "ol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        '_lbMB_Model
        '
        Me._lbMB_Model.ForeColor = System.Drawing.Color.Black
        Me._lbMB_Model.Location = New System.Drawing.Point(96, 32)
        Me._lbMB_Model.Name = "_lbMB_Model"
        Me._lbMB_Model.Size = New System.Drawing.Size(72, 20)
        Me._lbMB_Model.TabIndex = 21
        Me._lbMB_Model.Text = "Model:"
        Me._lbMB_Model.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboBox_Models
        '
        Me.cboBox_Models.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboBox_Models.Caption = ""
        Me.cboBox_Models.CaptionHeight = 17
        Me.cboBox_Models.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBox_Models.ColumnCaptionHeight = 17
        Me.cboBox_Models.ColumnFooterHeight = 17
        Me.cboBox_Models.ContentHeight = 15
        Me.cboBox_Models.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBox_Models.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBox_Models.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBox_Models.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBox_Models.EditorHeight = 15
        Me.cboBox_Models.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBox_Models.Images.Add(CType(resources.GetObject("resource.Images15"), System.Drawing.Bitmap))
        Me.cboBox_Models.ItemHeight = 15
        Me.cboBox_Models.Location = New System.Drawing.Point(176, 32)
        Me.cboBox_Models.MatchEntryTimeout = CType(2000, Long)
        Me.cboBox_Models.MaxDropDownItems = CType(5, Short)
        Me.cboBox_Models.MaxLength = 32767
        Me.cboBox_Models.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBox_Models.Name = "cboBox_Models"
        Me.cboBox_Models.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBox_Models.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBox_Models.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBox_Models.Size = New System.Drawing.Size(200, 21)
        Me.cboBox_Models.TabIndex = 18
        Me.cboBox_Models.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
        ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
        "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
        "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
        "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
        "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
        "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
        "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        '_lbMB_Frequency
        '
        Me._lbMB_Frequency.ForeColor = System.Drawing.Color.Black
        Me._lbMB_Frequency.Location = New System.Drawing.Point(96, 64)
        Me._lbMB_Frequency.Name = "_lbMB_Frequency"
        Me._lbMB_Frequency.Size = New System.Drawing.Size(72, 20)
        Me._lbMB_Frequency.TabIndex = 22
        Me._lbMB_Frequency.Text = "Frequency :"
        Me._lbMB_Frequency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lbMB_BaudRate
        '
        Me._lbMB_BaudRate.ForeColor = System.Drawing.Color.Black
        Me._lbMB_BaudRate.Location = New System.Drawing.Point(96, 96)
        Me._lbMB_BaudRate.Name = "_lbMB_BaudRate"
        Me._lbMB_BaudRate.Size = New System.Drawing.Size(72, 20)
        Me._lbMB_BaudRate.TabIndex = 23
        Me._lbMB_BaudRate.Text = "Baud Rate :"
        Me._lbMB_BaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBoxCreate
        '
        Me.btnBoxCreate.BackColor = System.Drawing.Color.Green
        Me.btnBoxCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoxCreate.ForeColor = System.Drawing.Color.White
        Me.btnBoxCreate.Location = New System.Drawing.Point(112, 136)
        Me.btnBoxCreate.Name = "btnBoxCreate"
        Me.btnBoxCreate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBoxCreate.Size = New System.Drawing.Size(272, 32)
        Me.btnBoxCreate.TabIndex = 131
        Me.btnBoxCreate.Text = "CREATE BOX"
        '
        'btnBoxReopen
        '
        Me.btnBoxReopen.BackColor = System.Drawing.Color.Navy
        Me.btnBoxReopen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoxReopen.ForeColor = System.Drawing.Color.White
        Me.btnBoxReopen.Location = New System.Drawing.Point(8, 64)
        Me.btnBoxReopen.Name = "btnBoxReopen"
        Me.btnBoxReopen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBoxReopen.Size = New System.Drawing.Size(80, 32)
        Me.btnBoxReopen.TabIndex = 127
        Me.btnBoxReopen.Text = "RE-OPEN"
        '
        'btnBoxReprintLabel
        '
        Me.btnBoxReprintLabel.BackColor = System.Drawing.Color.Purple
        Me.btnBoxReprintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoxReprintLabel.ForeColor = System.Drawing.Color.White
        Me.btnBoxReprintLabel.Location = New System.Drawing.Point(8, 104)
        Me.btnBoxReprintLabel.Name = "btnBoxReprintLabel"
        Me.btnBoxReprintLabel.Size = New System.Drawing.Size(80, 32)
        Me.btnBoxReprintLabel.TabIndex = 129
        Me.btnBoxReprintLabel.Text = "RE-PRINT"
        '
        'dbgBoxes
        '
        Me.dbgBoxes.AllowColMove = False
        Me.dbgBoxes.AllowColSelect = False
        Me.dbgBoxes.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgBoxes.AllowSort = False
        Me.dbgBoxes.AllowUpdate = False
        Me.dbgBoxes.AllowUpdateOnBlur = False
        Me.dbgBoxes.AlternatingRows = True
        Me.dbgBoxes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgBoxes.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.dbgBoxes.Caption = "Open Boxes"
        Me.dbgBoxes.CaptionHeight = 19
        Me.dbgBoxes.CollapseColor = System.Drawing.Color.White
        Me.dbgBoxes.ExpandColor = System.Drawing.Color.White
        Me.dbgBoxes.FilterBar = True
        Me.dbgBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgBoxes.ForeColor = System.Drawing.Color.White
        Me.dbgBoxes.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgBoxes.Images.Add(CType(resources.GetObject("resource.Images16"), System.Drawing.Bitmap))
        Me.dbgBoxes.Location = New System.Drawing.Point(8, 192)
        Me.dbgBoxes.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgBoxes.Name = "dbgBoxes"
        Me.dbgBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgBoxes.PreviewInfo.ZoomFactor = 75
        Me.dbgBoxes.RowHeight = 20
        Me.dbgBoxes.Size = New System.Drawing.Size(392, 280)
        Me.dbgBoxes.TabIndex = 24
        Me.dbgBoxes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
        "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
        "te;BackColor:InactiveCaption;}FilterBar{Font:Microsoft Sans Serif, 6.75pt, style" & _
        "=Bold;ForeColor:Black;BackColor:White;}Footer{}Caption{AlignHorz:Center;ForeColo" & _
        "r:White;BackColor:SteelBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, s" & _
        "tyle=Bold;AlignVert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRo" & _
        "w{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{ForeColor:Black;B" & _
        "ackColor:LightSteelBlue;}RecordSelector{ForeColor:White;AlignImage:Center;}Style" & _
        "15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Ce" & _
        "nter;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;AlignVert:Center" & _
        ";}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}S" & _
        "tyle9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fals" & _
        "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
        "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar" & _
        "=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=" & _
        """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>257</Height><Capt" & _
        "ionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5""" & _
        " /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBa" & _
        "r"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=" & _
        """Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRo" & _
        "wStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""" & _
        "Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent" & _
        "=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" />" & _
        "<Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 19, 388, 257</ClientRect><Bo" & _
        "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
        "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
        "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
        " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
        "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
        "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
        "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
        "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
        "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
        "17</DefaultRecSelWidth><ClientArea>0, 0, 388, 276</ClientArea><PrintPageHeaderSt" & _
        "yle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Bl" & _
        "ob>"
        '
        'PnlBoxItems
        '
        Me.PnlBoxItems.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.PnlBoxItems.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbBoxItems})
        Me.PnlBoxItems.Location = New System.Drawing.Point(408, 8)
        Me.PnlBoxItems.Name = "PnlBoxItems"
        Me.PnlBoxItems.Size = New System.Drawing.Size(424, 488)
        Me.PnlBoxItems.TabIndex = 134
        '
        'gbBoxItems
        '
        Me.gbBoxItems.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
        Me.gbBoxItems.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBoxClose, Me.btnBoxRemove, Me.lblBoxName, Me.lblBoxQTY, Me._lblBoxSerialSN, Me.txtBoxSN, Me.lstBoxSN, Me.btnBoxEmptyBox})
        Me.gbBoxItems.Location = New System.Drawing.Point(8, 8)
        Me.gbBoxItems.Name = "gbBoxItems"
        Me.gbBoxItems.Size = New System.Drawing.Size(408, 464)
        Me.gbBoxItems.TabIndex = 133
        Me.gbBoxItems.TabStop = False
        Me.gbBoxItems.Text = "Box Items"
        '
        'btnBoxClose
        '
        Me.btnBoxClose.BackColor = System.Drawing.Color.Maroon
        Me.btnBoxClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoxClose.ForeColor = System.Drawing.Color.White
        Me.btnBoxClose.Location = New System.Drawing.Point(224, 392)
        Me.btnBoxClose.Name = "btnBoxClose"
        Me.btnBoxClose.Size = New System.Drawing.Size(176, 40)
        Me.btnBoxClose.TabIndex = 137
        Me.btnBoxClose.Text = "Close"
        '
        'btnBoxRemove
        '
        Me.btnBoxRemove.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.btnBoxRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoxRemove.ForeColor = System.Drawing.Color.White
        Me.btnBoxRemove.Location = New System.Drawing.Point(248, 128)
        Me.btnBoxRemove.Name = "btnBoxRemove"
        Me.btnBoxRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBoxRemove.Size = New System.Drawing.Size(112, 32)
        Me.btnBoxRemove.TabIndex = 136
        Me.btnBoxRemove.Text = "Remove Serial"
        '
        'lblBoxName
        '
        Me.lblBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxName.Location = New System.Drawing.Point(208, 16)
        Me.lblBoxName.Name = "lblBoxName"
        Me.lblBoxName.Size = New System.Drawing.Size(192, 23)
        Me.lblBoxName.TabIndex = 135
        Me.lblBoxName.Text = "Box Name"
        Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBoxQTY
        '
        Me.lblBoxQTY.BackColor = System.Drawing.Color.Black
        Me.lblBoxQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxQTY.ForeColor = System.Drawing.Color.Green
        Me.lblBoxQTY.Location = New System.Drawing.Point(256, 48)
        Me.lblBoxQTY.Name = "lblBoxQTY"
        Me.lblBoxQTY.Size = New System.Drawing.Size(100, 32)
        Me.lblBoxQTY.TabIndex = 134
        Me.lblBoxQTY.Text = "0"
        Me.lblBoxQTY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblBoxSerialSN
        '
        Me._lblBoxSerialSN.ForeColor = System.Drawing.Color.Black
        Me._lblBoxSerialSN.Location = New System.Drawing.Point(16, 24)
        Me._lblBoxSerialSN.Name = "_lblBoxSerialSN"
        Me._lblBoxSerialSN.Size = New System.Drawing.Size(176, 20)
        Me._lblBoxSerialSN.TabIndex = 133
        Me._lblBoxSerialSN.Text = "Serial # :"
        Me._lblBoxSerialSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxSN
        '
        Me.txtBoxSN.BackColor = System.Drawing.Color.White
        Me.txtBoxSN.Location = New System.Drawing.Point(16, 48)
        Me.txtBoxSN.Name = "txtBoxSN"
        Me.txtBoxSN.Size = New System.Drawing.Size(184, 20)
        Me.txtBoxSN.TabIndex = 132
        Me.txtBoxSN.Text = ""
        '
        'lstBoxSN
        '
        Me.lstBoxSN.Location = New System.Drawing.Point(16, 80)
        Me.lstBoxSN.Name = "lstBoxSN"
        Me.lstBoxSN.Size = New System.Drawing.Size(184, 368)
        Me.lstBoxSN.TabIndex = 131
        '
        'btnBoxEmptyBox
        '
        Me.btnBoxEmptyBox.BackColor = System.Drawing.Color.Red
        Me.btnBoxEmptyBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBoxEmptyBox.ForeColor = System.Drawing.Color.White
        Me.btnBoxEmptyBox.Location = New System.Drawing.Point(248, 176)
        Me.btnBoxEmptyBox.Name = "btnBoxEmptyBox"
        Me.btnBoxEmptyBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBoxEmptyBox.Size = New System.Drawing.Size(112, 32)
        Me.btnBoxEmptyBox.TabIndex = 128
        Me.btnBoxEmptyBox.Text = "Empty Box"
        '
        'TabReport
        '
        Me.TabReport.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.TabReport.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReportWarehouseInventoryItems, Me.btnReportSummary, Me.btnReportDetails, Me._lblReportToDate, Me._lblReportFromDate, Me.dtpReportToDate, Me.dtpReportFromDate})
        Me.TabReport.Location = New System.Drawing.Point(4, 22)
        Me.TabReport.Name = "TabReport"
        Me.TabReport.Size = New System.Drawing.Size(848, 510)
        Me.TabReport.TabIndex = 3
        Me.TabReport.Text = "Report"
        '
        'btnReportWarehouseInventoryItems
        '
        Me.btnReportWarehouseInventoryItems.BackColor = System.Drawing.Color.Purple
        Me.btnReportWarehouseInventoryItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnReportWarehouseInventoryItems.ForeColor = System.Drawing.Color.White
        Me.btnReportWarehouseInventoryItems.Location = New System.Drawing.Point(40, 224)
        Me.btnReportWarehouseInventoryItems.Name = "btnReportWarehouseInventoryItems"
        Me.btnReportWarehouseInventoryItems.Size = New System.Drawing.Size(336, 32)
        Me.btnReportWarehouseInventoryItems.TabIndex = 30
        Me.btnReportWarehouseInventoryItems.Text = "Warehouse Inventory Items"
        '
        'btnReportSummary
        '
        Me.btnReportSummary.BackColor = System.Drawing.Color.Blue
        Me.btnReportSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReportSummary.ForeColor = System.Drawing.Color.White
        Me.btnReportSummary.Location = New System.Drawing.Point(40, 96)
        Me.btnReportSummary.Name = "btnReportSummary"
        Me.btnReportSummary.Size = New System.Drawing.Size(336, 32)
        Me.btnReportSummary.TabIndex = 29
        Me.btnReportSummary.Text = "Warehouse Receive Summary"
        '
        'btnReportDetails
        '
        Me.btnReportDetails.BackColor = System.Drawing.Color.Teal
        Me.btnReportDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReportDetails.ForeColor = System.Drawing.Color.White
        Me.btnReportDetails.Location = New System.Drawing.Point(40, 160)
        Me.btnReportDetails.Name = "btnReportDetails"
        Me.btnReportDetails.Size = New System.Drawing.Size(336, 32)
        Me.btnReportDetails.TabIndex = 28
        Me.btnReportDetails.Text = "Warehouse Receive Details"
        '
        '_lblReportToDate
        '
        Me._lblReportToDate.Location = New System.Drawing.Point(224, 24)
        Me._lblReportToDate.Name = "_lblReportToDate"
        Me._lblReportToDate.Size = New System.Drawing.Size(24, 20)
        Me._lblReportToDate.TabIndex = 27
        Me._lblReportToDate.Text = "To:"
        '
        '_lblReportFromDate
        '
        Me._lblReportFromDate.Location = New System.Drawing.Point(32, 24)
        Me._lblReportFromDate.Name = "_lblReportFromDate"
        Me._lblReportFromDate.Size = New System.Drawing.Size(40, 20)
        Me._lblReportFromDate.TabIndex = 26
        Me._lblReportFromDate.Text = "From:"
        '
        'dtpReportToDate
        '
        Me.dtpReportToDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpReportToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReportToDate.Location = New System.Drawing.Point(248, 24)
        Me.dtpReportToDate.Name = "dtpReportToDate"
        Me.dtpReportToDate.Size = New System.Drawing.Size(104, 20)
        Me.dtpReportToDate.TabIndex = 1
        '
        'dtpReportFromDate
        '
        Me.dtpReportFromDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpReportFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReportFromDate.Location = New System.Drawing.Point(80, 24)
        Me.dtpReportFromDate.Name = "dtpReportFromDate"
        Me.dtpReportFromDate.Size = New System.Drawing.Size(96, 20)
        Me.dtpReportFromDate.TabIndex = 0
        '
        'TabTools
        '
        Me.TabTools.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControlTools})
        Me.TabTools.Location = New System.Drawing.Point(4, 22)
        Me.TabTools.Name = "TabTools"
        Me.TabTools.Size = New System.Drawing.Size(848, 510)
        Me.TabTools.TabIndex = 4
        Me.TabTools.Text = "Tools"
        '
        'TabControlTools
        '
        Me.TabControlTools.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabToolsFreq})
        Me.TabControlTools.Location = New System.Drawing.Point(16, 24)
        Me.TabControlTools.Name = "TabControlTools"
        Me.TabControlTools.SelectedIndex = 0
        Me.TabControlTools.Size = New System.Drawing.Size(728, 400)
        Me.TabControlTools.TabIndex = 0
        '
        'TabToolsFreq
        '
        Me.TabToolsFreq.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.TabToolsFreq.Controls.AddRange(New System.Windows.Forms.Control() {Me.mskToolsFreq, Me._lblToolsAddFreq, Me.btnToolsAddFreq})
        Me.TabToolsFreq.Location = New System.Drawing.Point(4, 22)
        Me.TabToolsFreq.Name = "TabToolsFreq"
        Me.TabToolsFreq.Size = New System.Drawing.Size(720, 374)
        Me.TabToolsFreq.TabIndex = 0
        Me.TabToolsFreq.Text = "Frequency"
        '
        'mskToolsFreq
        '
        Me.mskToolsFreq.ContainingControl = Me
        Me.mskToolsFreq.Location = New System.Drawing.Point(120, 32)
        Me.mskToolsFreq.Name = "mskToolsFreq"
        Me.mskToolsFreq.OcxState = CType(resources.GetObject("mskToolsFreq.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mskToolsFreq.Size = New System.Drawing.Size(160, 24)
        Me.mskToolsFreq.TabIndex = 7
        '
        '_lblToolsAddFreq
        '
        Me._lblToolsAddFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblToolsAddFreq.Location = New System.Drawing.Point(16, 32)
        Me._lblToolsAddFreq.Name = "_lblToolsAddFreq"
        Me._lblToolsAddFreq.Size = New System.Drawing.Size(88, 23)
        Me._lblToolsAddFreq.TabIndex = 2
        Me._lblToolsAddFreq.Text = "Enter Freq:"
        '
        'btnToolsAddFreq
        '
        Me.btnToolsAddFreq.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.btnToolsAddFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToolsAddFreq.Location = New System.Drawing.Point(120, 72)
        Me.btnToolsAddFreq.Name = "btnToolsAddFreq"
        Me.btnToolsAddFreq.Size = New System.Drawing.Size(160, 32)
        Me.btnToolsAddFreq.TabIndex = 0
        Me.btnToolsAddFreq.Text = "Add Frequency"
        '
        'lblCust
        '
        Me.lblCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCust.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
        Me.lblCust.Location = New System.Drawing.Point(8, 16)
        Me.lblCust.Name = "lblCust"
        Me.lblCust.Size = New System.Drawing.Size(296, 16)
        Me.lblCust.TabIndex = 21
        Me.lblCust.Text = "Customer"
        Me.lblCust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAquisWHRec
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(872, 550)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Name = "frmAquisWHRec"
        Me.Text = "frmAquisWHRec"
        Me.PnlReceipt.ResumeLayout(False)
        CType(Me.cboSelectedOpenBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgReceipt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCustomerReceipt.ResumeLayout(False)
        CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReceiptItemDetails.ResumeLayout(False)
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFrequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBaudRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPagerCondition.ResumeLayout(False)
        CType(Me.cboPhysicalAbuse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBatteryCoverCondition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCaseCondition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboHolderCondition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabReceive.ResumeLayout(False)
        Me.PnlReceiptItems.ResumeLayout(False)
        Me.TabCustomerAddress.ResumeLayout(False)
        Me.gbCustInfo.ResumeLayout(False)
        CType(Me.cboStates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCountries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabBox.ResumeLayout(False)
        Me.PnlBox.ResumeLayout(False)
        Me.gbCreateBox.ResumeLayout(False)
        CType(Me.cboBox_BaudRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBox_Frequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBox_Models, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgBoxes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBoxItems.ResumeLayout(False)
        Me.gbBoxItems.ResumeLayout(False)
        Me.TabReport.ResumeLayout(False)
        Me.TabTools.ResumeLayout(False)
        Me.TabControlTools.ResumeLayout(False)
        Me.TabToolsFreq.ResumeLayout(False)
        CType(Me.mskToolsFreq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Loading"

    '*************************************************************************************************************

    Private Sub frmAquisWHRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            LoadCustomers()
            LoadShipmentCarrier()
            LoadModels()
            LoadFrequencies()
            LoadBaudRates()
            LoadPhysicalAbuse()
            LoadHolderConditions()
            LoadCaseConditions()
            LoadBatteryCoverConditions()
            LoadCountryandState()

            PopulateOpenReceipt()
            PopulateOpenBoxes()

            Me.PnlReceiptItems.Visible = False
            Me.PnlBoxItems.Visible = False
            Me.TabControl1.SelectedIndex = 0

            'Hung Nguyen 12/22/2011 After discuss with management team, the box must be select in Receiving Tab,
            'Disable these button avoid operator from removing box that leaving serial without box name.  
            Me.btnBoxRemove.Visible = False
            Me.btnBoxEmptyBox.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmAquisWHRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try


    End Sub

    '*************************************************************************************************************
    Private Sub LoadCustomers()
        Dim dt As DataTable

        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetCustomersList(True, Me._objMessaging.Aquis_Loc_ID, Me._objMessaging.Aquis_Cust_ID)
            Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "FullName", "RF_ID")
            Me.cboCustomer.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadCustomers", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._booPopDataToCombo = False
        End Try
    End Sub

    '*************************************************************************************************************
    Private Sub LoadShipmentCarrier()
        Dim dt As DataTable

        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetShipmentCarrier(True)
            Misc.PopulateC1DropDownList(Me.cboCarrier, dt, "SC_Desc", "SC_ID")
            Me.cboCarrier.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadShipmentCarrier", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._booPopDataToCombo = False
        End Try
    End Sub

    '*************************************************************************************************************
    Private Sub LoadModels()
        Dim dt As DataTable

        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetModels(True)
            Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
            Me.cboModels.SelectedValue = 0

            Misc.PopulateC1DropDownList(Me.cboBox_Models, dt, "Model_Desc", "Model_ID")
            Me.cboBox_Models.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadModels", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._booPopDataToCombo = False
        End Try
    End Sub
    '*************************************************************************************************************
    Private Sub LoadFrequencies()
        Dim dt As DataTable

        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetFrequencies(True)
            Misc.PopulateC1DropDownList(Me.cboFrequency, dt, "freq_number", "freq_id")
            Me.cboFrequency.SelectedValue = 0

            Misc.PopulateC1DropDownList(Me.cboBox_Frequency, dt, "freq_number", "freq_id")
            Me.cboBox_Frequency.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadFrequencies", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._booPopDataToCombo = False
        End Try
    End Sub
    '*************************************************************************************************************
    Private Sub LoadBaudRates()
        Dim dt As DataTable

        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetBaudRate(True)
            Misc.PopulateC1DropDownList(Me.cboBaudRate, dt, "baud_number", "baud_id")
            Me.cboBaudRate.SelectedValue = 0

            Misc.PopulateC1DropDownList(Me.cboBox_BaudRate, dt, "baud_number", "baud_id")
            Me.cboBox_BaudRate.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadBaudRate", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._booPopDataToCombo = False
        End Try
    End Sub
  

    '*************************************************************************************************************
    Private Sub LoadPhysicalAbuse()
        Dim dt As DataTable

        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetPhysicalAbuse(True)
            Misc.PopulateC1DropDownList(Me.cboPhysicalAbuse, dt, "Dcode_Ldesc", "Dcode_id")
            Me.cboPhysicalAbuse.SelectedValue = Me._objMessaging.Aquis_NoPhysicalAbuse
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadPagerConditions", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._booPopDataToCombo = False
        End Try
    End Sub
    '*************************************************************************************************************
    Private Sub LoadHolderConditions()
        Dim dt As DataTable

        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetPagerConditions(True)
            Misc.PopulateC1DropDownList(Me.cboHolderCondition, dt, "Dcode_Ldesc", "Dcode_id")
            Me.cboHolderCondition.SelectedValue = Me._objMessaging.Aquis_NotRequired
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadPagerConditions", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._booPopDataToCombo = False
        End Try
    End Sub
    '*************************************************************************************************************
    Private Sub LoadCaseConditions()
        Dim dt As DataTable

        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetPagerConditions(True)
            Misc.PopulateC1DropDownList(Me.cboCaseCondition, dt, "Dcode_Ldesc", "Dcode_id")
            Me.cboCaseCondition.SelectedValue = Me._objMessaging.Aquis_NotRequired
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadCaseConditions", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._booPopDataToCombo = False
        End Try
    End Sub
    '*************************************************************************************************************
    Private Sub LoadBatteryCoverConditions()
        Dim dt As DataTable

        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetPagerConditions(True)
            Misc.PopulateC1DropDownList(Me.cboBatteryCoverCondition, dt, "Dcode_Ldesc", "Dcode_id")
            Me.cboBatteryCoverCondition.SelectedValue = Me._objMessaging.Aquis_NotRequired
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadBatteryCoverConditions", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            Me._booPopDataToCombo = False
        End Try
    End Sub
    '*************************************************************************************************************

    Private Sub LoadCountryandState()
        Dim dt As DataTable
        Dim objDC As New PSS.Data.Buisness.DriveCam()
        Try
            Me._booPopDataToCombo = True
            dt = objDC.GetState(True, False)
            Misc.PopulateC1DropDownList(Me.cboStates, dt, "State_Desc", "State_ID")
            Me.cboStates.SelectedValue = 0

            Generic.DisposeDT(dt)
            dt = objDC.GetCountry(True)
            Misc.PopulateC1DropDownList(Me.cboCountries, dt, "Cntry_Name", "Cntry_ID")
            Me.cboCountries.SelectedValue = 161
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadBatteryCoverConditions", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            objDC = Nothing
            Me._booPopDataToCombo = False

        End Try
    End Sub
    '*************************************************************************************************************
   
#End Region

#Region "Control,Combo,Textbox, dgb events"


    '*************************************************************************************************************
    Private Sub Contrls_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomer.KeyUp, txtSerialNo.KeyUp, txtPagerNo.KeyUp, txtCapCode.KeyUp, txtTrackingNo.KeyUp, txtBoxSN.KeyUp
        Try


            If sender.name = "cboCustomer" And e.KeyCode = Keys.Enter Then
                If Me.cboCustomer.SelectedValue = 0 Then
                    Me.TabControl1.SelectedIndex = 1
                Else
                    Me.txtAccountNo.SelectAll() : Me.txtAccountNo.Focus()
                End If
            ElseIf sender.name = "txtSerialNo" And e.KeyCode = Keys.Enter Then
                If Me.txtSerialNo.Text.Trim.Length > 0 Then
                    Me.ProcessReceiptSN()
                End If
            ElseIf sender.name = "txtAccountNo" And e.KeyCode = Keys.Enter Then
                If Me.txtAccountNo.Text.Trim.Length > 0 Then
                    Me.txtPagerNo.SelectAll() : Me.txtPagerNo.Focus()
                End If
            ElseIf sender.name = "txtPagerNo" And e.KeyCode = Keys.Enter Then
                If Me.txtPagerNo.Text.Trim.Length > 0 Then
                    If Me._EndOfLife = True Then
                        Me.ProcessReceiptSN()
                    Else
                        Me.txtSerialNo.SelectAll() : Me.txtSerialNo.Focus()
                    End If

                End If
            ElseIf sender.name = "txtCapCode" And e.KeyCode = Keys.Enter Then
                If Me.txtCapCode.Text.Trim.Length > 0 Then
                    Me.cboFrequency.Focus()
                End If
            ElseIf sender.name = "txtTrackingNo" And e.KeyCode = Keys.Enter Then
                If Me.txtTrackingNo.Text.Trim.Length > 0 Then
                    Me.btnReceiptCreate.Focus()
                End If
            ElseIf sender.name = "txtComment" And e.KeyCode = Keys.Enter Then
                If Me.txtComment.Text.Trim.Length > 0 Then
                    'Me.btnReceipt.Focus()
                End If
            ElseIf sender.name = "txtBoxSN" And e.KeyCode = Keys.Enter Then
                If Me.txtBoxSN.Text.Trim.Length > 0 Then
                    Me.ProcessBoxItems()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Contrls_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************************************************
    Private Sub Contrls_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.RowChange, cboCarrier.RowChange, cboModels.RowChange, cboFrequency.RowChange, cboBaudRate.RowChange, cboCaseCondition.RowChange, cboBatteryCoverCondition.RowChange, cboCarrier.RowChange, cboHolderCondition.RowChange, cboSelectedOpenBox.RowChange

        Try
            If Me._booPopDataToCombo = False Then
                If sender.name = "cboCustomer" Then
                    If Me.cboCustomer.SelectedValue = 0 Then
                        Me.TabControl1.SelectedIndex = 1
                    Else
                        Me.txtAccountNo.SelectAll() : Me.txtAccountNo.Focus()
                    End If
                ElseIf sender.name = "cboCarrier" Then
                    If Me.cboCarrier.SelectedValue > 0 Then
                        Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                    End If
                ElseIf sender.name = "cboSelectedOpenBox" Then
                    If Me.cboSelectedOpenBox.SelectedValue > 0 Then
                        Me.cboModels.SelectedValue = CInt(Me.cboSelectedOpenBox.DataSource.Table.Select("WB_ID = " & Me.cboSelectedOpenBox.SelectedValue)(0)("Model_ID"))
                        Me.cboFrequency.SelectedValue = CInt(Me.cboSelectedOpenBox.DataSource.Table.Select("WB_ID = " & Me.cboSelectedOpenBox.SelectedValue)(0)("Freq_ID"))
                        Me.cboBaudRate.SelectedValue = CInt(Me.cboSelectedOpenBox.DataSource.Table.Select("WB_ID = " & Me.cboSelectedOpenBox.SelectedValue)(0)("BaudRate_ID"))
                        Me.cboModels.Enabled = False
                        Me.cboFrequency.Enabled = False
                        Me.cboBaudRate.Enabled = False
                        Me.txtSerialNo.Focus()
                    Else
                        Me.cboModels.Enabled = True
                        Me.cboFrequency.Enabled = True
                        Me.cboBaudRate.Enabled = True
                    End If
                ElseIf sender.name = "cboModels" Then
                    If Me.cboModels.SelectedValue > 0 Then
                        Me._EndOfLife = CBool(Me.cboModels.DataSource.Table.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("EndOfLife"))
                        PopulateReceiptSNList()
                        Me.SelectionDefaults()
                    End If
                ElseIf sender.name = "cboFrequency" Then
                    If Me.cboFrequency.SelectedValue > 0 Then
                        Me.cboBaudRate.Focus()
                    End If
                ElseIf sender.name = "cboBaudRate" Then
                    If Me.cboBaudRate.SelectedValue > 0 Then
                        Me.cboPhysicalAbuse.Focus()
                    End If
                ElseIf sender.name = "cboHolderCondition" Then
                    If Me.cboHolderCondition.SelectedValue > 0 Then
                        Me.cboCaseCondition.Focus()
                    End If
                ElseIf sender.name = "cboCaseCondition" Then
                    If Me.cboCaseCondition.SelectedValue > 0 Then
                        Me.cboBatteryCoverCondition.Focus()
                    End If
                ElseIf sender.name = "cboBatteryCoverCondition" Then
                    If Me.cboBatteryCoverCondition.SelectedValue > 0 Then
                        Me.txtComment.SelectAll() : Me.txtComment.Focus()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Contrls_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************************************************

    Private Sub dbgReceipt_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgReceipt.DoubleClick

        Try
            If Me.dbgReceipt.RowCount > 0 AndAlso Me.dbgReceipt.Columns.Count > 0 Then
                Dim L_strCustName As String = CStr(Me.dbgReceipt.Columns("Customer Name").Value)
                Me._WR_ID = CInt(Me.dbgReceipt.Columns("WR_ID").Value)
                Me._RF_ID = CInt(Me.dbgReceipt.Columns("RF_ID").Value)

                'Me.lblReceiptName.Text = CStr(Me._WR_ID) + "-" + Me.dbgReceipt.Columns("Receipt Name").Value.ToString.Trim
                Me.lblReceiptName.Text = Me.dbgReceipt.Columns("Receipt Name").Value.ToString.Trim
                Me.SelectionDefaults()
                PopulateReceiptSNList()
                Me.lblCust.Text = L_strCustName
                If Me._RF_ID = 1 Then 'When Aquis Comunication, only Inventory Mgmt selected
                    Me.rdbInventoryMgt.Checked = True
                    Me.rdbReturnMgt.Enabled = False
                Else
                    Me.rdbReturnMgt.Enabled = True
                End If
                Me.PnlReceiptItems.Visible = True
                Me.txtSerialNo.Focus()

            Else
                PnlReceiptItems.Visible = False
                Me._WR_ID = 0
                Me._RF_ID = 0

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgReceipt_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************************************************

    Private Sub dbgBoxes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgBoxes.DoubleClick
        Try
            If Me.dbgBoxes.RowCount > 0 AndAlso Me.dbgBoxes.Columns.Count > 0 Then

                Me._WB_ID = CInt(Me.dbgBoxes.Columns("WB_ID").Value)
                Me._WB_ModelID = CInt(Me.dbgBoxes.Columns("Model_ID").Value)
                Me.lblBoxName.Text = Me.dbgBoxes.Columns("Box_Name").Value.ToString.Trim
                Me.PopulateBoxSNList()
                Me.PnlBoxItems.Visible = True
                Me.txtBoxSN.Focus()

            Else
                Me.PnlBoxItems.Visible = False
                Me._WB_ID = 0

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgBoxes_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

#End Region

#Region "Buttons Events"

    '*************************************************************************************************************

    Private Sub btnBoxCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxCreate.Click

        Dim dt As DataTable

        Try
            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            If Me.cboBox_Models.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.cboBox_Frequency.SelectedValue = 0 Then
                MessageBox.Show("Please select Frequency.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.cboBox_BaudRate.SelectedValue = 0 Then
                MessageBox.Show("Please select Baud Rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me._objMessaging.IsThereOpenBox(Me.cboBox_Models.SelectedValue, Me.cboBox_Frequency.SelectedValue, Me.cboBox_BaudRate.SelectedValue) = True Then
                MessageBox.Show("There is a Box with this Model=" & Me.cboBox_Models.Text & " , Freq=" & Me.cboBox_Frequency.Text & " , Baud Rate=" & Me.cboBox_BaudRate.Text & " still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                'Box prefix appre. : Aquis Communications = AC,
                Me._WB_ID = Me._objMessaging.CreateWareHouseBox("AC", Me._objMessaging.Aquis_Cust_ID, Me._objMessaging.Aquis_Loc_ID, Me.cboBox_Models.SelectedValue, Me.cboBox_Frequency.SelectedValue, Me.cboBox_BaudRate.SelectedValue, ApplicationUser.IDuser)
                If Me._WB_ID = 0 Then
                    MessageBox.Show("System has failed to create Warehouse Box ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.PopulateOpenBoxes()
                    Me.PnlBoxItems.Visible = False
                    Me.cboBox_Models.SelectedValue = 0
                    Me.cboBox_Frequency.SelectedValue = 0
                    Me.cboBox_BaudRate.SelectedValue = 0
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnBoxCreate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Me._objMessaging.DisposeDT(dt)
        End Try


    End Sub

    '*************************************************************************************************************
    Private Sub btnReopenBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxReopen.Click

        Dim strBoxName As String = ""
        Dim iWB_ID As Integer = 0
        Dim dt

        Try


            strBoxName = InputBox("Enter Warehouse Box Name:", "Reopen Box")
            If strBoxName = "" Then
                MessageBox.Show("Please enter box name to re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                dt = Me._objMessaging.GetWarehouseBoxByName(strBoxName, Me._objMessaging.Aquis_Loc_ID, Me._objMessaging.Aquis_Cust_ID)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Warehouse Box does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Warehouse Box existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("Box_ShipDate")) Then
                    MessageBox.Show("Warehouse Box has already been shipped. Not allow to re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("Closed") = 0 Then
                    MessageBox.Show("Warehouse Box is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    iWB_ID = Me._objMessaging.ReopenWarehouseBox(dt.Rows(0)("WB_ID"))
                    If iWB_ID = 0 Then
                        MessageBox.Show("System has failed to re-open the Warehouse Box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Me.PopulateOpenBoxes(iWB_ID)
                        Me.PnlBoxItems.Visible = False
                        Me.Enabled = True

                    End If 'Re-Open status 
                End If  'validate Box information
            End If  'Empty input
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReopenBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try

    End Sub

    '*************************************************************************************************************

    Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxReprintLabel.Click

        Dim strBoxName, strModel, StrFreq, strBaudRate, strQty As String
        Dim i As Integer = 0
        Dim dt As DataTable

        Try

            strBoxName = ""
            strBoxName = InputBox("Enter Box Name:", "Warehouse Box Name")

            If strBoxName = "" Then
                MessageBox.Show("Please enter Box name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else

                'Get label info for Box Name
                dt = Me._objMessaging.Label_GetLabelInfoByBoxName(strBoxName)


                If dt.Rows.Count = 0 Then
                    MessageBox.Show("The warehouse box name:" & strBoxName & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strModel = dt.Rows(0)("Model_Desc")
                    StrFreq = dt.Rows(0)("freq_number")
                    strBaudRate = dt.Rows(0)("baud_number")
                    strQty = dt.Rows(0)("box_QTY")
                    Me._objMessaging.Label_AquisBoxLabel(strBoxName, strModel, StrFreq, strBaudRate, strQty)
                    Me.txtBoxSN.Focus()
                End If

            End If  'Empty input
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReprintBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try


    End Sub
    '*************************************************************************************************************

    Private Sub btnBoxEmptyBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxEmptyBox.Click

        Dim i As Integer = 0

        Try
            If Me.dbgBoxes.RowCount = 0 OrElse Me.dbgBoxes.Columns.Count = 0 Then
                Exit Sub
            ElseIf Convert.ToInt32(Me.dbgBoxes.Columns("WB_ID").CellValue(Me.dbgBoxes.Row)) = 0 Then
                MessageBox.Show("Warehouse Box ID is missing for selected row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf MessageBox.Show("Are you sure you want to delete Warehouse Box: " & Me.dbgBoxes.Columns("Box_Name").Value & " ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            Else
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                i = Me._objMessaging.ClearWarehouseBox(Convert.ToInt32(Me.dbgBoxes.Columns("WB_ID").CellValue(Me.dbgBoxes.Row)), ApplicationUser.IDuser)
                If i > 0 Then
                    Me.PopulateBoxSNList()
                    MessageBox.Show("Items in Warehouse Box has been cleared.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtBoxSN.Focus()
                Else
                    MessageBox.Show("System has failed to delete warehouse box item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnBoxEmptyBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default : Me._booPopDataToCombo = False
        End Try

        Try

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnDeleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        End Try
    End Sub
    '*************************************************************************************************************

    Private Sub btnBoxDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxDelete.Click

        Dim strBoxName As String = ""
        Dim iWB_ID As Integer = 0
        Dim dtBox, dtItems As DataTable

        Try


            strBoxName = InputBox("Enter Warehouse Box Name:", "Delete Box")
            If strBoxName = "" Then
                MessageBox.Show("Please enter box name to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                dtBox = Me._objMessaging.GetWarehouseBoxByName(strBoxName, Me._objMessaging.Aquis_Loc_ID, Me._objMessaging.Aquis_Cust_ID)

                If dtBox.Rows.Count = 0 Then
                    MessageBox.Show("Warehouse Box does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtBox.Rows.Count > 1 Then
                    MessageBox.Show("Warehouse Box existed more than one in the system. Please contact IT immediately...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dtBox.Rows(0)("Box_ShipDate")) Then
                    MessageBox.Show("Warehouse Box has already been shipped. Not allow to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtBox.Rows(0)("Closed") = 1 Then
                    MessageBox.Show("Warehouse Box is already closed. You can not delete this box", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    iWB_ID = dtBox.Rows(0)("WB_ID")
                    dtItems = Me._objMessaging.GetWarehouseBoxItems(iWB_ID)
                    If dtItems.Rows.Count > 0 Then
                        MessageBox.Show("This Warehouse Box# " & strBoxName & " is not empty. Not allow to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        Me._objMessaging.DeleteWarehouseBox(iWB_ID)
                        Me.PopulateOpenBoxes()
                    End If

                    Me.PnlBoxItems.Visible = False
                    Me.Enabled = True

                End If  'validate Box information
            End If  'Empty input
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnBoxDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Generic.DisposeDT(dtBox)
            Generic.DisposeDT(dtItems)
        End Try

    End Sub

    '*************************************************************************************************************

    Private Sub btnCreateCustomerAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateCustomerAddress.Click

        Dim iRF_ID As Integer

        Try
            If Me.txtFirstName.Text = "" Then
                MessageBox.Show("Please enter customer's first name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Me.txtLastName.Text = "" Then
                MessageBox.Show("Please enter customer's last name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'ElseIf Me.txtAddress1.Text = "" Then
                'MessageBox.Show("Please enter customer's address1.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'ElseIf Me.txtCompanyName.Text = "" Then
                'MessageBox.Show("Please enter customer's company name. Enter customer's full name if company name is not available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Me.txtCity.Text = "" Then
                MessageBox.Show("Please enter customer's city.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Me.cboStates.SelectedValue = 0 Then
                MessageBox.Show("Please select customer's state.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Me.txtZip.Text = "" Then
                MessageBox.Show("Please enter customer's zip code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Me.cboCountries.SelectedValue = 0 Then
                MessageBox.Show("Please select customer's country.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'ElseIf Me.txtTel.Text = "" Then
                'MessageBox.Show("Please enter customer's telephone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                iRF_ID = Me._objMessaging.InsertCustomerAddress(Me.txtLastName.Text, _
                                                                      Me.txtFirstName.Text, _
                                                                      Me.txtMiName.Text, _
                                                                      Me.txtAddress1.Text, _
                                                                      Me.txtAddress2.Text, _
                                                                      Me.txtCity.Text, _
                                                                      Me.txtZip.Text, _
                                                                      Me.cboStates.SelectedValue, _
                                                                      Me.cboCountries.SelectedValue, _
                                                                      Me.txtTel.Text, _
                                                                      Me.txtFax.Text, _
                                                                      Me.txtEmail.Text, _
                                                                      Me._objMessaging.Aquis_Cust_ID, _
                                                                      Me._objMessaging.Aquis_Loc_ID, _
                                                                      Me.txtCompanyName.Text)
                If iRF_ID > 0 Then

                    Me.LoadCustomers()
                    Me.cboCustomer.SelectedValue = iRF_ID
                    Me.TabControl1.SelectedIndex = 0

                Else
                    MessageBox.Show("System has failed to create customer address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCreateCustmerAddress_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try


    End Sub

    '*************************************************************************************************************
    Private Sub btnReceiptCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptCreate.Click

        Dim dt As DataTable
        Dim iWR_ID As Integer

        Try
            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            If Me.cboCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.txtAccountNo.Text = "" Then
                MessageBox.Show("Please enter account number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.cboCarrier.SelectedValue = 0 Then
                MessageBox.Show("Please select shipment carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.txtTrackingNo.Text = "" Then
                MessageBox.Show("Please scan/enter tracking number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                'Receipt prefix appre. : Aquis Communications = AC,
                iWR_ID = Me._objMessaging.CreateWareHouseReceipt("AC", Me._objMessaging.Aquis_Cust_ID, Me._objMessaging.Aquis_Loc_ID, Me.cboCustomer.SelectedValue, Me.cboCarrier.SelectedValue, Trim(Me.txtTrackingNo.Text.ToUpper), Trim(Me.txtAccountNo.Text.ToUpper), ApplicationUser.IDuser, Trim(Me.txtRMA.Text.ToUpper))
                If iWR_ID = 0 Then
                    MessageBox.Show("System has failed to create warehouse customer receipt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.PopulateOpenReceipt(iWR_ID)
                    Me.PnlReceiptItems.Visible = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReceiptCreate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Me._objMessaging.DisposeDT(dt)
        End Try

    End Sub
    '*************************************************************************************************************

    Private Sub btnReceiptReOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptReOpen.Click
        Dim strReceiptName As String = ""
        Dim i As Integer = 0
        Dim dt, dt2 As DataTable

        Try


            strReceiptName = InputBox("Enter Warehouse Receipt Name:", "Reopen Warehouse Receipt")
            If strReceiptName = "" Then
                MessageBox.Show("Please enter warehouse receipt name to re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                dt = Me._objMessaging.GetWarehouseReceiptByName(strReceiptName, Me._objMessaging.Aquis_Loc_ID, Me._objMessaging.Aquis_Cust_ID)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Warehouse Box does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Warehouse Receipt existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("Closed") = 0 Then
                    MessageBox.Show("Warehouse Receipt is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = Me._objMessaging.ReopenWarehouseReceipt(dt.Rows(0)("WR_ID"))
                    If i = 0 Then
                        MessageBox.Show("System has failed to re-open the Warehouse Receipt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Me.PopulateOpenReceipt()
                        Me.Enabled = True

                    End If 'Re-Open status 
                End If  'validate Receipt information
            End If  'Empty input
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReceiptReOpen_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*************************************************************************************************************

    Private Sub rdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbReturnMgt.CheckedChanged, rdbInventoryMgt.CheckedChanged

        Try

            If sender.name = "rdbReturnMgt" Then
                If Me.rdbReturnMgt.Checked = True Then
                    Me.rdbInventoryMgt.Checked = False
                Else
                    Me.rdbInventoryMgt.Checked = True
                End If

            ElseIf sender.name = "rdbInventoryMgt" Then
                If Me.rdbInventoryMgt.Checked = True Then
                    Me.rdbReturnMgt.Checked = False
                Else
                    Me.rdbReturnMgt.Checked = True
                End If

            End If

            Me.SelectionDefaults()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "rdb_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************************************************

    'Private Sub btnReceiptReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptReceive.Click
    '    Dim iWI_ID As Integer
    '    Try
    '        If DoReceiptValidation() = True Then
    '            iWI_ID = Me._objMessaging.InsertWarehouseReceiptItems(Me.txtSerialNo.Text, Me.txtPagerNo.Text, Me.txtCapCode.Text, Me._RF_ID, Me.cboPhysicalAbuse.SelectedValue, Me.cboHolderCondition.SelectedValue, Me.cboCaseCondition.SelectedValue, Me.cboBatteryCoverCondition.SelectedValue, Me._WR_ID, Me._LaborCharge, Me.cboModels.SelectedValue, Me.cboFrequency.SelectedValue, Me.cboBaudRate.SelectedValue, Me.txtComment.Text)
    '            Me._objMessaging.MoveRecDocuments(iWI_ID)
    '            PrintReceivingLabel(iWI_ID)
    '            PopulateReceiptSNList()
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString, "btnReceiptReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '    End Try
    'End Sub
    '*************************************************************************************************************

    Private Sub btnReceiptPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptPrintLabel.Click

        Dim strModel, StrFreq, strBaudRate, strSerial As String
        Dim i As Integer = 0
        Dim dt As DataTable

        Try

            strSerial = ""
            strSerial = InputBox("Enter Serial or Pager number:", "Serial/Pager number")

            If strSerial = "" Then
                MessageBox.Show("Please enter serial/pager tel number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else

                'Get label info for either Serial and pager number
                dt = Me._objMessaging.Label_GetLabelInfoBySerialOrPager(strSerial)


                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Warehouse serial/pager does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    'For End Of Life product, the serial number field is empty, using pager number instead
                    strSerial = dt.Rows(0)("Serial")
                    If strSerial = "" Then
                        strSerial = dt.Rows(0)("Pager_Number")
                    End If
                    strModel = dt.Rows(0)("Model_Desc")
                    StrFreq = dt.Rows(0)("freq_number")
                    strBaudRate = dt.Rows(0)("baud_number")
                    Me._objMessaging.Label_AquisReceivingLabel(strModel, StrFreq, strBaudRate, strSerial)

                End If

            End If  'Empty input
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReceiptPrintLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try

    End Sub
    '*************************************************************************************************************

    Private Sub btnReceiptClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptClose.Click
        Dim Receipt_Qty As Integer
        Dim dt As DataTable
        Try

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            'Check scan document for Return Management
            If Me.rdbReturnMgt.Checked = True AndAlso Me._objMessaging.IsThereAReceiveDoc = False Then
                Exit Sub
            End If


            dt = Me._objMessaging.GetWarehouseOpenBoxes(Me._WR_ID)
            If dt.Rows.Count > 0 Then
                Dim BoxNameList As String = ""
                Dim dr As DataRow

                For Each dr In dt.Rows
                    BoxNameList += dr("Box_Name") & ","
                Next
                BoxNameList = BoxNameList.Remove(BoxNameList.Length - 1, 1)
                MessageBox.Show("These Box: " & BoxNameList & " still open. You need to close them first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                Receipt_Qty = Me.lstReceiptSN.Items.Count
                Me._objMessaging.CloseWarehouseReceipt(Me._WR_ID, Receipt_Qty)
                Me._objMessaging.MoveRecDocuments(Me._WR_ID)
                Me.PopulateOpenReceipt()
                Me.PnlReceiptItems.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReceiptClose_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try


    End Sub
    '*************************************************************************************************************

    Private Sub btnReceiptRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptRemove.Click
        Dim iWI_ID As Integer
        Dim strModel, StrFreq, strBaudRate, strSerial As String
        Dim i As Integer = 0
        Dim dt As DataTable
        Dim booRemove = False

        Try

            strSerial = ""
            strSerial = InputBox("Enter Serial or Pager number:", "Remove Pager Tel")



            If strSerial = "" Then
                MessageBox.Show("Please enter serial/pager tel to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.lstReceiptSN.Items.Count > 0 AndAlso Me._EndOfLife = True AndAlso Me.lstReceiptSN.DataSource.table.select("Pager_Number = '" & strSerial.Trim.ToUpper & "'").length > 0 Then
                booRemove = True
            ElseIf Me.lstReceiptSN.Items.Count > 0 AndAlso Me._EndOfLife = False AndAlso Me.lstReceiptSN.DataSource.table.select("Serial = '" & strSerial.Trim.ToUpper & "'").length > 0 Then
                booRemove = True
            End If

            If booRemove = True Then
                'Get items info for either Serial or pager number
                dt = Me._objMessaging.Label_GetLabelInfoBySerialOrPager(strSerial)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Warehouse serial/pager does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else

                    iWI_ID = dt.Rows(0)("WI_ID")
                    Me._objMessaging.DeleteWarehouseItem(iWI_ID)
                    Me.PopulateReceiptSNList()
                    Me.txtSerialNo.Focus()

                End If
            End If



        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReceiptRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try
    End Sub
    '*************************************************************************************************************
    Private Sub btnBoxRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxRemove.Click

        Dim iWI_ID As Integer
        Dim strModel, StrFreq, strBaudRate, strSerial As String
        Dim i As Integer = 0
        Dim dt As DataTable

        Try

            strSerial = ""
            strSerial = InputBox("Enter Serial number:", "Remove Pager Serial")



            If strSerial = "" Then
                MessageBox.Show("Please enter serial to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            ElseIf Me.lstBoxSN.Items.Count > 0 AndAlso Me.lstBoxSN.DataSource.table.select("Serial = '" & strSerial.Trim.ToUpper & "'").length > 0 Then
                'Get items info for either Serial or pager number
                dt = Me._objMessaging.Label_GetLabelInfoBySerialOrPager(strSerial)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Warehouse serial/pager does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else

                    iWI_ID = dt.Rows(0)("WI_ID")
                    Me._objMessaging.ClearWarehouseItemBoxID(iWI_ID)
                    Me.PopulateBoxSNList()
                    Me.txtBoxSN.Focus()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnBoxRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*************************************************************************************************************

    Private Sub btnBoxClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxClose.Click
        Dim Box_QTY As Integer
        Try
            Box_QTY = Me.lstBoxSN.Items.Count
            Me._objMessaging.CloseWarehouseBox(Me._WB_ID, Box_QTY)
            Me.PrintBoxLabel(Me._WB_ID)
            Me.PopulateOpenBoxes()
            Me.PnlBoxItems.Visible = False
            Me.cboModels.Enabled = True
            Me.cboFrequency.Enabled = True
            Me.cboBaudRate.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnBoxClose_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    '*************************************************************************************************************

    Private Sub dbgReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgReceipt.Click
        Me.PnlReceiptItems.Visible = False
    End Sub
    '*************************************************************************************************************

    Private Sub dbgBoxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgBoxes.Click
        Me.PnlBoxItems.Visible = False
    End Sub
    '*************************************************************************************************************




#End Region

#Region "Functions & Subs"
    '*************************************************************************************************************
    Private Sub PopulateOpenBoxes(Optional ByVal iWB_ID As Integer = 0)
        Dim dt As DataTable
        Dim i As Integer
        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetWarehouseOpenBoxes(Me._objMessaging.Aquis_Loc_ID, Me._objMessaging.Aquis_Cust_ID)
            'dt.Columns("Box_Name").ColumnName = "Box"
            'dt.Columns("Model_Desc").ColumnName = "Model" : dt.AcceptChanges()

            With Me.dbgBoxes
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To dt.Columns.Count - 1
                    'Make some columns invisible
                    .Splits(0).DisplayColumns(i).Visible = False
                Next i
                .Splits(0).DisplayColumns("Box_Name").Width = 120
                .Splits(0).DisplayColumns("Model").Width = 100
                .Splits(0).DisplayColumns("Freq").Width = 75
                .Splits(0).DisplayColumns("Baud").Width = 75

                .Splits(0).DisplayColumns("Box_Name").Visible = True
                .Splits(0).DisplayColumns("Model").Visible = True
                .Splits(0).DisplayColumns("Freq").Visible = True
                .Splits(0).DisplayColumns("Baud").Visible = True

                If iWB_ID > 0 Then
                    .MoveFirst()
                    For i = 0 To dt.Rows.Count - 1
                        If CInt(Me.dbgBoxes.Columns("WB_ID").Value.ToString) <> iWB_ID Then .MoveNext() Else Exit For
                    Next i
                End If
            End With


            dt.LoadDataRow(New Object() {"0", "--SELECT OPEN BOX--"}, False)
            Misc.PopulateC1DropDownList(Me.cboSelectedOpenBox, dt, "Box_Name", "WB_ID")
            Me.cboSelectedOpenBox.SelectedValue = 0



        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PopulateOpenBoxes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt) : Me._booPopDataToCombo = False
        End Try
    End Sub

    '*************************************************************************************************************
    Private Sub PopulateOpenReceipt(Optional ByVal iWR_ID As Integer = 0)
        Dim dt As DataTable
        Dim i As Integer
        Try
            Me._booPopDataToCombo = True
            dt = Me._objMessaging.GetWarehouseReceiptOpen(Me._objMessaging.Aquis_Loc_ID, Me._objMessaging.Aquis_Cust_ID)
            'dt.Columns("Box_Name").ColumnName = "Box"
            'dt.Columns("Model_Desc").ColumnName = "Model" : dt.AcceptChanges()

            With Me.dbgReceipt
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To dt.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).Visible = False
                Next i
                .Splits(0).DisplayColumns("Receipt Name").Width = 120
                .Splits(0).DisplayColumns("Customer Name").Width = 100
                .Splits(0).DisplayColumns("Tracking").Width = 75
                .Splits(0).DisplayColumns("Account").Width = 75

                .Splits(0).DisplayColumns("Receipt Name").Visible = True
                .Splits(0).DisplayColumns("Customer Name").Visible = True
                .Splits(0).DisplayColumns("Tracking").Visible = True
                .Splits(0).DisplayColumns("Account").Visible = True

                If iWR_ID > 0 Then
                    .MoveFirst()
                    For i = 0 To dt.Rows.Count - 1
                        If CInt(Me.dbgReceipt.Columns("WR_ID").Value.ToString) <> iWR_ID Then .MoveNext() Else Exit For
                    Next i
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PopulateOpenReceipt", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt) : Me._booPopDataToCombo = False
        End Try
    End Sub

    '*************************************************************************************************************
    Private Function DoReceiptValidation() As Boolean

        'Validation depend on Receiving/Inventory/EndOfLife

        Dim booPassValidation = False

        Try
            Me.txtSerialNo.Text = Me.txtSerialNo.Text.Trim.ToUpper

            'Check warehouse open box.
            If Me.cboSelectedOpenBox.SelectedValue = 0 Then
                MessageBox.Show("Please select Warehouse Open Box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                booPassValidation = False
            ElseIf Me._objMessaging.IsWareHouseBoxClose(Me.cboSelectedOpenBox.SelectedValue) = True Then
                'Check to made sure the box is not closed by other receiver on different PC.
                Dim BoxName As String
                BoxName = Me.cboSelectedOpenBox.DataSource.Table.Select("WB_ID = " & Me.cboSelectedOpenBox.SelectedValue)(0)("Box_Name")
                MessageBox.Show("This Box: " & BoxName & " has been closed. Please select another box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.PopulateOpenBoxes()
                booPassValidation = False
            ElseIf Me._objMessaging.IsWareHouseSerialExist(Me.txtSerialNo.Text) = True Then
                MessageBox.Show("Serial# " & Me.txtSerialNo.Text & " already existed in the Warehouse Inventory...", "Duplicate Serial !", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                booPassValidation = False
            ElseIf Me._EndOfLife = True Then
                Me._Management_Type_ID = Me._objMessaging.Aquis_Return_Retired_Product_Management
                If Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtPagerNo.Text = "" Then
                    MessageBox.Show("Please enter pager telephone number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboPhysicalAbuse.SelectedValue = 0 Then
                    MessageBox.Show("Please select physical abuse condition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstReceiptSN.Items.Count > 0 AndAlso Me.lstReceiptSN.DataSource.table.select("Pager_Number = '" & Me.txtPagerNo.Text.Trim.ToUpper & "'").length > 0 Then
                    MessageBox.Show("This Pager Telephone#" & Me.txtPagerNo.Text & " is already listed. Try another one.", "Duplicated Pager Telephone Number !", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPagerNo.Text = ""
                    Me.txtPagerNo.Focus()
                Else
                    booPassValidation = True
                End If

            ElseIf Me.rdbReturnMgt.Checked = True Then
                Me._Management_Type_ID = Me._objMessaging.Aquis_Return_Management

                If Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtSerialNo.Text = "" Then
                    MessageBox.Show("Please enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtCapCode.Text = "" Then
                    MessageBox.Show("Please enter cap code number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtPagerNo.Text = "" Then
                    MessageBox.Show("Please enter pager telephone number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboFrequency.SelectedValue = 0 Then
                    MessageBox.Show("Please select frequency.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboBaudRate.SelectedValue = 0 Then
                    MessageBox.Show("Please select baud rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboPhysicalAbuse.SelectedValue = 0 Then
                    MessageBox.Show("Please select physical abuse condition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboHolderCondition.SelectedValue = 0 Then
                    MessageBox.Show("Please select holder condition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboCaseCondition.SelectedValue = 0 Then
                    MessageBox.Show("Please select cases condition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboBatteryCoverCondition.SelectedValue = 0 Then
                    MessageBox.Show("Please select battery cover condition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstReceiptSN.DataSource.table.select("Serial = '" & Me.txtSerialNo.Text.Trim.ToUpper & "'").length > 0 Then
                    MessageBox.Show("This serial#" & Me.txtSerialNo.Text & " is already listed. Try another one.", "Duplicated Serial Number !", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerialNo.Text = ""
                    Me.txtSerialNo.Focus()
                Else
                    booPassValidation = True
                End If

            ElseIf Me.rdbInventoryMgt.Checked = True Then
                Me._Management_Type_ID = Me._objMessaging.Aquis_Inventory_Management

                If Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtSerialNo.Text = "" Then
                    MessageBox.Show("Please enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboFrequency.SelectedValue = 0 Then
                    MessageBox.Show("Please select frequency.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboBaudRate.SelectedValue = 0 Then
                    MessageBox.Show("Please select baud rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboPhysicalAbuse.SelectedValue = 0 Then
                    MessageBox.Show("Please select physical abuse condition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstReceiptSN.DataSource.table.select("Serial = '" & Me.txtSerialNo.Text.Trim.ToUpper & "'").length > 0 Then
                    MessageBox.Show("This serial#" & Me.txtSerialNo.Text & " is already listed. Try another one.", "Duplicated Serial Number !", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerialNo.Text = ""
                    Me.txtSerialNo.Focus()
                Else
                    booPassValidation = True
                End If

            End If

            Return booPassValidation

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "DoReceiptValidation", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    '********************************************************************************************************
    Private Sub PopulateReceiptSNList()
        Dim dt As DataTable
        Try

            '*******************************************
            'Get all devices from receipt ID
            dt = Me._objMessaging.GetWarehouseReceiptItems(Me._WR_ID)
            Me.lstReceiptSN.DataSource = dt.DefaultView
            Me.lstReceiptSN.ValueMember = dt.Columns("WI_ID").ToString
            If Me._EndOfLife = True Then
                Me.lstReceiptSN.DisplayMember = dt.Columns("Pager_Number").ToString
            Else
                Me.lstReceiptSN.DisplayMember = dt.Columns("Serial").ToString
            End If

            Me.lblReceiptQTY.Text = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                btnReceiptRemove.Enabled = True
                btnReceiptClose.Enabled = True
            Else
                btnReceiptRemove.Enabled = False
                btnReceiptClose.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        Finally

            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    '********************************************************************************************************
    Private Sub PopulateBoxSNList()
        Dim dt As DataTable
        Try

            '*******************************************
            'Get all devices from receipt ID
            dt = Me._objMessaging.GetWarehouseBoxItems(Me._WB_ID)
            Me.lstBoxSN.DataSource = dt.DefaultView
            Me.lstBoxSN.ValueMember = dt.Columns("WI_ID").ToString
            Me.lstBoxSN.DisplayMember = dt.Columns("Serial").ToString

            Me.lblBoxQTY.Text = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                btnBoxRemove.Enabled = True
                btnBoxClose.Enabled = True
                btnBoxEmptyBox.Enabled = True
            Else
                btnBoxEmptyBox.Enabled = False
                btnBoxRemove.Enabled = False
                btnBoxClose.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Me._EndOfLife = True Then
                Me.txtPagerNo.Focus()
            Else
                Me.txtSerialNo.Focus()
            End If

            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    '*************************************************************************************************************
    Private Sub DisableRequirementOptions()

        Try
            Me._LaborCharge = 0.0
            Me.txtSerialNo.Enabled = False
            Me.txtPagerNo.Enabled = False
            Me.txtCapCode.Enabled = False
            Me.cboFrequency.Enabled = False
            Me.cboBaudRate.Enabled = False
            Me.cboHolderCondition.Enabled = False
            Me.cboCaseCondition.Enabled = False
            Me.cboBatteryCoverCondition.Enabled = False
            Me.cboHolderCondition.SelectedValue = 0
            Me.cboCaseCondition.SelectedValue = 0
            Me.cboBatteryCoverCondition.SelectedValue = 0

            Me.txtCapCode.Visible = False
            Me.txtPagerNo.Visible = False
            Me.txtSerialNo.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "DisableOptions", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    '*************************************************************************************************************
    Private Sub EnableReturnMgtOptions()

        Try
            Me._LaborCharge = 2.67
            Me.txtSerialNo.Enabled = True
            Me.txtSerialNo.Text = ""
            Me.txtPagerNo.Enabled = True
            Me.txtPagerNo.Text = ""
            Me.txtCapCode.Enabled = True
            Me.txtCapCode.Text = ""
            Me.cboFrequency.Enabled = True
            Me.cboBaudRate.Enabled = True
            Me.cboHolderCondition.Enabled = True
            Me.cboCaseCondition.Enabled = True
            Me.cboBatteryCoverCondition.Enabled = True
            Me.cboHolderCondition.SelectedValue = 0
            Me.cboCaseCondition.SelectedValue = 0
            Me.cboBatteryCoverCondition.SelectedValue = 0
            Me.txtCapCode.Visible = True
            Me.txtPagerNo.Visible = True
            Me.txtSerialNo.Visible = True
            Me.txtSerialNo.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "DisableOptions", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    '*************************************************************************************************************
    Private Sub EnableInventoryMgtOptions()

        'For Inventory Management Process the Pager number and conditions is not required

        Try
            Me._LaborCharge = 1.5
            Me.txtSerialNo.Visible = True
            Me.txtSerialNo.Enabled = True
            Me.txtSerialNo.Text = ""
            'Me.txtPagerNo.Enabled = True
            Me.txtPagerNo.Text = ""
            'Me.txtCapCode.Enabled = True
            Me.txtCapCode.Text = ""
            Me.cboFrequency.Enabled = True
            Me.cboBaudRate.Enabled = True
            'Me.cboHolderCondition.Enabled = True
            'Me.cboCaseCondition.Enabled = True
            'Me.cboBatteryCoverCondition.Enabled = True
            Me.cboHolderCondition.SelectedValue = Me._objMessaging.Aquis_NotRequired
            Me.cboCaseCondition.SelectedValue = Me._objMessaging.Aquis_NotRequired
            Me.cboBatteryCoverCondition.SelectedValue = Me._objMessaging.Aquis_NotRequired

            Me.txtSerialNo.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "DisableOptions", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    '*************************************************************************************************************
    Private Sub EnableEOLMgtOptions()

        'For End Of Life Process the Serial number,Freq,Baud,Signal format, and conditions is not required
        Try
            Me._LaborCharge = 1.75
            'Me.txtSerialNo.Enabled = True
            Me.txtSerialNo.Text = ""
            Me.txtPagerNo.Visible = True
            Me.txtPagerNo.Enabled = True
            Me.txtPagerNo.Text = ""
            'Me.txtCapCode.Enabled = True
            Me.txtCapCode.Text = ""
            'Me.cboFrequency.Enabled = True
            'Me.cboBaudRate.Enabled = True
            Me.cboFrequency.SelectedValue = 0
            Me.cboBaudRate.SelectedValue = 0


            'Me.cboHolderCondition.Enabled = True
            'Me.cboCaseCondition.Enabled = True
            'Me.cboBatteryCoverCondition.Enabled = True
            Me.cboHolderCondition.SelectedValue = Me._objMessaging.Aquis_NotRequired
            Me.cboCaseCondition.SelectedValue = Me._objMessaging.Aquis_NotRequired
            Me.cboBatteryCoverCondition.SelectedValue = Me._objMessaging.Aquis_NotRequired

            Me.txtPagerNo.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "DisableOptions", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************************************************

    Private Sub SelectionDefaults()

        Me.DisableRequirementOptions()

        If Me._EndOfLife = True Then
            Me.EnableEOLMgtOptions()
        ElseIf Me.rdbReturnMgt.Checked = True Then
            Me.EnableReturnMgtOptions()
        ElseIf Me.rdbInventoryMgt.Checked = True Then
            Me.EnableInventoryMgtOptions()
        End If

        'Override Default Selection if Open Box is selected...
        If Me.cboSelectedOpenBox.SelectedValue > 0 Then
            Me.cboModels.SelectedValue = CInt(Me.cboSelectedOpenBox.DataSource.Table.Select("WB_ID = " & Me.cboSelectedOpenBox.SelectedValue)(0)("Model_ID"))
            Me.cboFrequency.SelectedValue = CInt(Me.cboSelectedOpenBox.DataSource.Table.Select("WB_ID = " & Me.cboSelectedOpenBox.SelectedValue)(0)("Freq_ID"))
            Me.cboBaudRate.SelectedValue = CInt(Me.cboSelectedOpenBox.DataSource.Table.Select("WB_ID = " & Me.cboSelectedOpenBox.SelectedValue)(0)("BaudRate_ID"))
            Me.cboModels.Enabled = False
            Me.cboFrequency.Enabled = False
            Me.cboBaudRate.Enabled = False
            Me.txtSerialNo.Focus()
        End If

    End Sub

    '*************************************************************************************************************
    Private Sub PrintReceivingLabel(ByVal iWI_ID)

        Dim strModel, StrFreq, strBaudRate, strSerial As String
        Dim dt As DataTable
        Dim dr As DataRow
        Try

            dt = Me._objMessaging.Label_GetLabelInfoByID(iWI_ID)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Warehouse Box does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If Me._EndOfLife = True Then
                    strSerial = dt.Rows(0)("Pager_Number")
                    strModel = dt.Rows(0)("Model_Desc")
                    StrFreq = "N/A"
                    strBaudRate = "N/A"
                Else
                    strSerial = dt.Rows(0)("Serial")
                    strModel = dt.Rows(0)("Model_Desc")
                    StrFreq = dt.Rows(0)("freq_number")
                    strBaudRate = dt.Rows(0)("baud_number")
                End If

                Me._objMessaging.Label_AquisReceivingLabel(strModel, StrFreq, strBaudRate, strSerial)

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PrintReceivingLabel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************************************************

    Private Sub PrintBoxLabel(ByVal iWB_ID)
        Dim strBoxName, strModel, StrFreq, strBaudRate, strQty As String
        Dim i As Integer = 0
        Dim dt As DataTable

        Try

            'Get label info for Box Name
            dt = Me._objMessaging.Label_GetLabelInfoByBoxID(iWB_ID)


            If dt.Rows.Count = 0 Then
                MessageBox.Show("Is warehouse box name:" & strBoxName & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                strBoxName = dt.Rows(0)("Box_Name")
                strModel = dt.Rows(0)("Model_Desc")
                StrFreq = dt.Rows(0)("freq_number")
                strBaudRate = dt.Rows(0)("baud_number")
                strQty = dt.Rows(0)("box_QTY")
                Me._objMessaging.Label_AquisBoxLabel(strBoxName, strModel, StrFreq, strBaudRate, strQty)

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PrintBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*************************************************************************************************************

    Private Sub ProcessBoxItems()
        Dim i As Integer
        Dim dt As DataTable

        Try


            Me.txtBoxSN.Text = Me.txtBoxSN.Text.Trim.ToUpper()

            If Me.txtBoxSN.Text = "" Then
                MessageBox.Show("Please enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.lstBoxSN.Items.Count > 0 AndAlso Me.lstBoxSN.DataSource.table.select("Serial = '" & Me.txtBoxSN.Text & "'").length > 0 Then
                MessageBox.Show("This serial#" & Me.txtBoxSN.Text & " is already listed. Try another one.", "Duplicated Serial Number !", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSerialNo.Text = ""
                Me.txtSerialNo.Focus()
            Else
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                dt = Me._objMessaging.Label_GetLabelInfoBySerial(Me.txtBoxSN.Text)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("This serial#" & Me.txtBoxSN.Text & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("This serial#" & Me.txtBoxSN.Text & " has been found more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("WB_ID")) > 0 Then
                    MessageBox.Show("This serial#" & Me.txtBoxSN.Text & " has been assigned to other box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("WR_Closed")) < 1 Then
                    MessageBox.Show("The Receiving Receipt for this serial#" & Me.txtBoxSN.Text & " is still open. You need to close the Receiving Receipt first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("Model_ID")) <> Me._WB_ModelID Then
                    MessageBox.Show("Model Mismatch ! Can not mix this serial#" & Me.txtBoxSN.Text & " model into the box:" + Me.lblBoxName.Text, "Model Mismatch !!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else

                    i = Me._objMessaging.UpdateWarehouseItemBoxID(CInt(dt.Rows(0)("WI_ID")), Me._WB_ID)
                    If i > 0 Then
                        Me.PopulateBoxSNList()
                        Me.txtSerialNo.Text = "" : Me.txtSerialNo.Focus()
                    Else
                        MessageBox.Show("System has failed to assign this serial#" & Me.txtBoxSN.Text & " to the box:" & Me.lblBoxName.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ProcessBoxItems", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
            Me.Enabled = True : Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************************************************
    Private Sub ProcessReceiptSN()
        Dim iWI_ID As Integer
        Try
            If DoReceiptValidation() = True Then
                'iWI_ID = Me._objMessaging.InsertWarehouseReceiptItems(Me.txtSerialNo.Text.ToUpper, Me.txtPagerNo.Text.ToUpper, Me.txtCapCode.Text.ToUpper, Me.cboSelectedOpenBox.SelectedValue, Me._RF_ID, Me.cboPhysicalAbuse.SelectedValue, Me.cboHolderCondition.SelectedValue, Me.cboCaseCondition.SelectedValue, Me.cboSelectedOpenBox.SelectedValue, Me._WR_ID, Me._LaborCharge, Me.cboModels.SelectedValue, Me.cboFrequency.SelectedValue, Me.cboBaudRate.SelectedValue, Me.txtComment.Text, Me._Management_Type_ID)
                iWI_ID = Me._objMessaging.InsertWarehouseReceiptItems(Me.txtSerialNo.Text.ToUpper, Me.txtPagerNo.Text.ToUpper, Me.txtCapCode.Text.ToUpper, Me._RF_ID, Me.cboPhysicalAbuse.SelectedValue, Me.cboHolderCondition.SelectedValue, Me.cboCaseCondition.SelectedValue, Me.cboBatteryCoverCondition.SelectedValue, Me.cboSelectedOpenBox.SelectedValue, Me._WR_ID, Me._LaborCharge, Me.cboModels.SelectedValue, Me.cboFrequency.SelectedValue, Me.cboBaudRate.SelectedValue, Me.txtComment.Text, Me._Management_Type_ID)

                If Me.cbPrintLabel.Checked = True Then
                    PrintReceivingLabel(iWI_ID)
                End If
                PopulateReceiptSNList()

                If Me._EndOfLife = True Then
                    Me.txtPagerNo.Text = "" : Me.txtPagerNo.Focus()
                ElseIf Me.rdbReturnMgt.Checked = True Then
                    Me.txtPagerNo.Text = "" : Me.txtSerialNo.Text = "" : Me.txtCapCode.Text = "" : Me.txtCapCode.Focus()
                ElseIf Me.rdbInventoryMgt.Checked = True Then
                    Me.txtPagerNo.Text = "" : Me.txtSerialNo.Text = "" : Me.txtSerialNo.Focus()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ProcessReceiptSN()", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    '*************************************************************************************************************

    '*************************************************************************************************************



#End Region

#Region "Reports"
    '*************************************************************************************************************

    Private Sub btnReportDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportDetails.Click

        Dim i As Integer = 0
        Dim strFromDate, strToDate As String

        Try
            Cursor.Current = Cursors.WaitCursor

            'Date Validation
            If Me.dtpReportFromDate.Text = "" Or Me.dtpReportToDate.Text = "" Then
                MsgBox("Please select 'Receipts Date From' and 'Received Date to'.", MsgBoxStyle.Information, "Warehouse Receipts Report")
                Exit Sub
            End If

            If Me.dtpReportToDate.Value < Me.dtpReportFromDate.Value Then
                MsgBox("'Receipts Date to' can't be before 'Receipts Date From'.", MsgBoxStyle.Information, "Warehouse Receipts Report")
                Exit Sub
            End If

            strFromDate = Me.dtpReportFromDate.Text & " 00:00:00"
            strToDate = Me.dtpReportToDate.Text & " 23:59:59"

            ' Generate Trimple Ship report
            i = Me._objMessaging.ReportReceiptDetails(strFromDate, strToDate)


        Catch ex As Exception
            MsgBox("btnReportDetails_Click" & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    '*************************************************************************************************************

    Private Sub btnReportSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportSummary.Click

        Dim i As Integer = 0
        Dim strFromDate, strToDate As String

        Try
            Cursor.Current = Cursors.WaitCursor

            'Date Validation
            If Me.dtpReportFromDate.Text = "" Or Me.dtpReportToDate.Text = "" Then
                MsgBox("Please select 'Receipts Date From' and 'Received Date to'.", MsgBoxStyle.Information, "Warehouse Receipts Report")
                Exit Sub
            End If

            If Me.dtpReportToDate.Value < Me.dtpReportFromDate.Value Then
                MsgBox("'Receipts Date to' can't be before 'Receipts Date From'.", MsgBoxStyle.Information, "Warehouse Receipts Report")
                Exit Sub
            End If

            strFromDate = Me.dtpReportFromDate.Text & " 00:00:00"
            strToDate = Me.dtpReportToDate.Text & " 23:59:59"

            ' Generate Trimple Ship report
            i = Me._objMessaging.ReportReceiptSummary(strFromDate, strToDate)

        Catch ex As Exception
            MsgBox("btnReportSummary_Click" & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************************************************

    Private Sub btnReportWarehouseInventoryItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportWarehouseInventoryItems.Click
        Dim i As Integer = 0


        Try
            Cursor.Current = Cursors.WaitCursor

            i = Me._objMessaging.ReportWarehouseInventoryItems()

        Catch ex As Exception
            MsgBox("btnReportWII_Click" & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Tools"

    '*************************************************************************************************************

    Private Sub btnToolsAddFreq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToolsAddFreq.Click

        Dim objMessLabel = New Buisness.MessLabel()

        Try

            If Me.mskToolsFreq.CtlText = "" Then
                MessageBox.Show("Please enter frequency..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If objMessLabel.IsFreqExisted(Trim(Me.mskToolsFreq.CtlText)) = False Then
                    objMessLabel.InsertFreq(Trim(Me.mskToolsFreq.CtlText), 0)
                    MessageBox.Show("The new Freq#" & Me.mskToolsFreq.CtlText & " has been added to the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("Duplicated Frequency ! This freq#" & Me.mskToolsFreq.CtlText & " already found in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnToolsAddFreq_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Finally
            objMessLabel = Nothing
        End Try


    End Sub

    '*************************************************************************************************************

#End Region



End Class
