Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmMobilio_ItemRec_Triage_Tech
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _objMRec As MobilioRec
        Private _strPCName As String = System.Net.Dns.GetHostName
        Private _iUserID As Integer = Core.ApplicationUser.IDuser
        Private _booLoadData As Boolean = False
        Private _booSeeAllHold As Boolean = False
        Private _booAllowSelRecordToRec As Boolean = False

        Private _iOrderID As Integer = 0
        Private _drDevAsn As DataRow = Nothing
        Private _dtAction As DataTable
        Private _dtDiscpTemp As DataTable
        Private _booNewItem As Boolean = False
        Private _iDeviceAsnID As Integer = 0

        Private _iDiscpFlag As Integer = 0
        Private _strDiscpRptFieldName As String = ""
        Private _iDiscpRptDispositionID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _objMRec = New MobilioRec()
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
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cboFile_OEM As C1.Win.C1List.C1Combo
        Friend WithEvents cboFile_Color As C1.Win.C1List.C1Combo
        Friend WithEvents cboFile_Carrier As C1.Win.C1List.C1Combo
        Friend WithEvents cboFile_BatteryDoorPresent As C1.Win.C1List.C1Combo
        Friend WithEvents cboFile_BatteryPresent As C1.Win.C1List.C1Combo
        Friend WithEvents cboFile_FindMyiPhone As C1.Win.C1List.C1Combo
        Friend WithEvents cboFile_Memory As C1.Win.C1List.C1Combo
        Friend WithEvents cboFile_CarrLockUnLock As C1.Win.C1List.C1Combo
        Friend WithEvents cboFile_Condition As C1.Win.C1List.C1Combo
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents cboRec_DataWip As C1.Win.C1List.C1Combo
        Friend WithEvents gbRecData As System.Windows.Forms.GroupBox
        Friend WithEvents cboRec_Condition As C1.Win.C1List.C1Combo
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents cboRec_CarrLockUnLock As C1.Win.C1List.C1Combo
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents cboRec_Memory As C1.Win.C1List.C1Combo
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents cboRec_FindMyiPhone As C1.Win.C1List.C1Combo
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents cboRec_Technology As C1.Win.C1List.C1Combo
        Friend WithEvents Label25 As System.Windows.Forms.Label
        Friend WithEvents cboRec_BatteryPresent As C1.Win.C1List.C1Combo
        Friend WithEvents Label26 As System.Windows.Forms.Label
        Friend WithEvents cboRec_BatteryDoorPresent As C1.Win.C1List.C1Combo
        Friend WithEvents Label27 As System.Windows.Forms.Label
        Friend WithEvents cboRec_Carrier As C1.Win.C1List.C1Combo
        Friend WithEvents Label28 As System.Windows.Forms.Label
        Friend WithEvents cboRec_Color As C1.Win.C1List.C1Combo
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents cboRec_Model As C1.Win.C1List.C1Combo
        Friend WithEvents Label30 As System.Windows.Forms.Label
        Friend WithEvents cboRec_OEM As C1.Win.C1List.C1Combo
        Friend WithEvents Label31 As System.Windows.Forms.Label
        Friend WithEvents btnReceive As System.Windows.Forms.Button
        Friend WithEvents btnClearAll As System.Windows.Forms.Button
        Friend WithEvents dbgOrderDetails As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents lblShipmentQty As System.Windows.Forms.Label
        Friend WithEvents lblOrderNo As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents btnCloseTote As System.Windows.Forms.Button
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpItemRecTech As System.Windows.Forms.TabPage
        Friend WithEvents tpOpenTotes As System.Windows.Forms.TabPage
        Friend WithEvents cboFile_Model As C1.Win.C1List.C1Combo
        Friend WithEvents btnOT_CloseSelectedTote As System.Windows.Forms.Button
        Friend WithEvents btnOT_Refresh As System.Windows.Forms.Button
        Friend WithEvents dbgOT_Totes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnR_GetData As System.Windows.Forms.Button
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents lblReceiptQty As System.Windows.Forms.Label
        Friend WithEvents lblDevDisposition As System.Windows.Forms.Label
        Friend WithEvents cboFile_EsnImeiChecked As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboRec_EsnImeiChecked As C1.Win.C1List.C1Combo
        Friend WithEvents dbgTote As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tpOpenOrders As System.Windows.Forms.TabPage
        Friend WithEvents dbgOB_OpenOrders As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnOO_Refresh As System.Windows.Forms.Button
        Friend WithEvents btnOO_CloseOrder As System.Windows.Forms.Button
        Friend WithEvents btnReprintItemLabel As System.Windows.Forms.Button
        Friend WithEvents chkPackageDamage As System.Windows.Forms.CheckBox
        Friend WithEvents tpHoldItems As System.Windows.Forms.TabPage
        Friend WithEvents btnH_Refresh As System.Windows.Forms.Button
        Friend WithEvents dbgHoldItems As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnH_AssignSelItemToTote As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dbgH_Tote As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnOT_AssignItemToTote As System.Windows.Forms.Button
        Friend WithEvents gbEsnImei As System.Windows.Forms.GroupBox
        Friend WithEvents txtRec_EsnImei_Internal As System.Windows.Forms.TextBox
        Friend WithEvents chkEsnImei_NoMatch As System.Windows.Forms.CheckBox
        Friend WithEvents txtRec_EsnImei_External As System.Windows.Forms.TextBox
        Friend WithEvents txtFile_EsnImei As System.Windows.Forms.TextBox
        Friend WithEvents chkEsnImeiTampered As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMobilio_ItemRec_Triage_Tech))
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cboFile_BatteryPresent = New C1.Win.C1List.C1Combo()
            Me.cboFile_BatteryDoorPresent = New C1.Win.C1List.C1Combo()
            Me.cboFile_Carrier = New C1.Win.C1List.C1Combo()
            Me.cboFile_Color = New C1.Win.C1List.C1Combo()
            Me.cboFile_Model = New C1.Win.C1List.C1Combo()
            Me.cboFile_OEM = New C1.Win.C1List.C1Combo()
            Me.txtDeviceID = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.lblShipmentQty = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblOrderNo = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cboFile_FindMyiPhone = New C1.Win.C1List.C1Combo()
            Me.cboFile_Memory = New C1.Win.C1List.C1Combo()
            Me.cboFile_CarrLockUnLock = New C1.Win.C1List.C1Combo()
            Me.cboFile_Condition = New C1.Win.C1List.C1Combo()
            Me.cboRec_DataWip = New C1.Win.C1List.C1Combo()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.gbRecData = New System.Windows.Forms.GroupBox()
            Me.cboRec_EsnImeiChecked = New C1.Win.C1List.C1Combo()
            Me.cboFile_EsnImeiChecked = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblDevDisposition = New System.Windows.Forms.Label()
            Me.btnReceive = New System.Windows.Forms.Button()
            Me.cboRec_Condition = New C1.Win.C1List.C1Combo()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.cboRec_CarrLockUnLock = New C1.Win.C1List.C1Combo()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.cboRec_Memory = New C1.Win.C1List.C1Combo()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.cboRec_FindMyiPhone = New C1.Win.C1List.C1Combo()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.cboRec_Technology = New C1.Win.C1List.C1Combo()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.cboRec_BatteryPresent = New C1.Win.C1List.C1Combo()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.cboRec_BatteryDoorPresent = New C1.Win.C1List.C1Combo()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.cboRec_Carrier = New C1.Win.C1List.C1Combo()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.cboRec_Color = New C1.Win.C1List.C1Combo()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.cboRec_Model = New C1.Win.C1List.C1Combo()
            Me.Label30 = New System.Windows.Forms.Label()
            Me.cboRec_OEM = New C1.Win.C1List.C1Combo()
            Me.Label31 = New System.Windows.Forms.Label()
            Me.dbgOrderDetails = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnClearAll = New System.Windows.Forms.Button()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.btnCloseTote = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpItemRecTech = New System.Windows.Forms.TabPage()
            Me.chkPackageDamage = New System.Windows.Forms.CheckBox()
            Me.btnReprintItemLabel = New System.Windows.Forms.Button()
            Me.dbgTote = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.gbEsnImei = New System.Windows.Forms.GroupBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtRec_EsnImei_Internal = New System.Windows.Forms.TextBox()
            Me.chkEsnImei_NoMatch = New System.Windows.Forms.CheckBox()
            Me.txtRec_EsnImei_External = New System.Windows.Forms.TextBox()
            Me.txtFile_EsnImei = New System.Windows.Forms.TextBox()
            Me.lblReceiptQty = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.btnR_GetData = New System.Windows.Forms.Button()
            Me.tpHoldItems = New System.Windows.Forms.TabPage()
            Me.dbgH_Tote = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnH_AssignSelItemToTote = New System.Windows.Forms.Button()
            Me.btnH_Refresh = New System.Windows.Forms.Button()
            Me.dbgHoldItems = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpOpenTotes = New System.Windows.Forms.TabPage()
            Me.btnOT_AssignItemToTote = New System.Windows.Forms.Button()
            Me.btnOT_Refresh = New System.Windows.Forms.Button()
            Me.btnOT_CloseSelectedTote = New System.Windows.Forms.Button()
            Me.dbgOT_Totes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpOpenOrders = New System.Windows.Forms.TabPage()
            Me.btnOO_Refresh = New System.Windows.Forms.Button()
            Me.btnOO_CloseOrder = New System.Windows.Forms.Button()
            Me.dbgOB_OpenOrders = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.chkEsnImeiTampered = New System.Windows.Forms.CheckBox()
            CType(Me.cboFile_BatteryPresent, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_BatteryDoorPresent, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_Carrier, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_Color, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_Model, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_OEM, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_FindMyiPhone, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_Memory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_CarrLockUnLock, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_Condition, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_DataWip, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbRecData.SuspendLayout()
            CType(Me.cboRec_EsnImeiChecked, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboFile_EsnImeiChecked, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_Condition, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_CarrLockUnLock, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_Memory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_FindMyiPhone, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_Technology, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_BatteryPresent, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_BatteryDoorPresent, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_Carrier, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_Color, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_Model, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboRec_OEM, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpItemRecTech.SuspendLayout()
            CType(Me.dbgTote, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbEsnImei.SuspendLayout()
            Me.tpHoldItems.SuspendLayout()
            CType(Me.dbgH_Tote, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgHoldItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpOpenTotes.SuspendLayout()
            CType(Me.dbgOT_Totes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpOpenOrders.SuspendLayout()
            CType(Me.dbgOB_OpenOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(0, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(80, 21)
            Me.Label5.TabIndex = 85
            Me.Label5.Text = "Device ID:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboFile_BatteryPresent
            '
            Me.cboFile_BatteryPresent.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_BatteryPresent.AutoCompletion = True
            Me.cboFile_BatteryPresent.AutoDropDown = True
            Me.cboFile_BatteryPresent.AutoSelect = True
            Me.cboFile_BatteryPresent.Caption = ""
            Me.cboFile_BatteryPresent.CaptionHeight = 17
            Me.cboFile_BatteryPresent.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_BatteryPresent.ColumnCaptionHeight = 17
            Me.cboFile_BatteryPresent.ColumnFooterHeight = 17
            Me.cboFile_BatteryPresent.ColumnHeaders = False
            Me.cboFile_BatteryPresent.ContentHeight = 15
            Me.cboFile_BatteryPresent.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_BatteryPresent.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_BatteryPresent.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_BatteryPresent.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_BatteryPresent.EditorHeight = 15
            Me.cboFile_BatteryPresent.Enabled = False
            Me.cboFile_BatteryPresent.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboFile_BatteryPresent.ItemHeight = 15
            Me.cboFile_BatteryPresent.Location = New System.Drawing.Point(552, 24)
            Me.cboFile_BatteryPresent.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_BatteryPresent.MaxDropDownItems = CType(10, Short)
            Me.cboFile_BatteryPresent.MaxLength = 32767
            Me.cboFile_BatteryPresent.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_BatteryPresent.Name = "cboFile_BatteryPresent"
            Me.cboFile_BatteryPresent.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_BatteryPresent.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_BatteryPresent.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_BatteryPresent.Size = New System.Drawing.Size(96, 21)
            Me.cboFile_BatteryPresent.TabIndex = 94
            Me.cboFile_BatteryPresent.TabStop = False
            Me.cboFile_BatteryPresent.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboFile_BatteryDoorPresent
            '
            Me.cboFile_BatteryDoorPresent.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_BatteryDoorPresent.AutoCompletion = True
            Me.cboFile_BatteryDoorPresent.AutoDropDown = True
            Me.cboFile_BatteryDoorPresent.AutoSelect = True
            Me.cboFile_BatteryDoorPresent.Caption = ""
            Me.cboFile_BatteryDoorPresent.CaptionHeight = 17
            Me.cboFile_BatteryDoorPresent.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_BatteryDoorPresent.ColumnCaptionHeight = 17
            Me.cboFile_BatteryDoorPresent.ColumnFooterHeight = 17
            Me.cboFile_BatteryDoorPresent.ColumnHeaders = False
            Me.cboFile_BatteryDoorPresent.ContentHeight = 15
            Me.cboFile_BatteryDoorPresent.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_BatteryDoorPresent.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_BatteryDoorPresent.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_BatteryDoorPresent.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_BatteryDoorPresent.EditorHeight = 15
            Me.cboFile_BatteryDoorPresent.Enabled = False
            Me.cboFile_BatteryDoorPresent.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboFile_BatteryDoorPresent.ItemHeight = 15
            Me.cboFile_BatteryDoorPresent.Location = New System.Drawing.Point(416, 24)
            Me.cboFile_BatteryDoorPresent.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_BatteryDoorPresent.MaxDropDownItems = CType(10, Short)
            Me.cboFile_BatteryDoorPresent.MaxLength = 32767
            Me.cboFile_BatteryDoorPresent.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_BatteryDoorPresent.Name = "cboFile_BatteryDoorPresent"
            Me.cboFile_BatteryDoorPresent.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_BatteryDoorPresent.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_BatteryDoorPresent.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_BatteryDoorPresent.Size = New System.Drawing.Size(120, 21)
            Me.cboFile_BatteryDoorPresent.TabIndex = 92
            Me.cboFile_BatteryDoorPresent.TabStop = False
            Me.cboFile_BatteryDoorPresent.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboFile_Carrier
            '
            Me.cboFile_Carrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_Carrier.AutoCompletion = True
            Me.cboFile_Carrier.AutoDropDown = True
            Me.cboFile_Carrier.AutoSelect = True
            Me.cboFile_Carrier.Caption = ""
            Me.cboFile_Carrier.CaptionHeight = 17
            Me.cboFile_Carrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_Carrier.ColumnCaptionHeight = 17
            Me.cboFile_Carrier.ColumnFooterHeight = 17
            Me.cboFile_Carrier.ColumnHeaders = False
            Me.cboFile_Carrier.ContentHeight = 15
            Me.cboFile_Carrier.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_Carrier.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_Carrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_Carrier.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_Carrier.EditorHeight = 15
            Me.cboFile_Carrier.Enabled = False
            Me.cboFile_Carrier.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboFile_Carrier.ItemHeight = 15
            Me.cboFile_Carrier.Location = New System.Drawing.Point(16, 88)
            Me.cboFile_Carrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_Carrier.MaxDropDownItems = CType(10, Short)
            Me.cboFile_Carrier.MaxLength = 32767
            Me.cboFile_Carrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_Carrier.Name = "cboFile_Carrier"
            Me.cboFile_Carrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_Carrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_Carrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_Carrier.Size = New System.Drawing.Size(168, 21)
            Me.cboFile_Carrier.TabIndex = 90
            Me.cboFile_Carrier.TabStop = False
            Me.cboFile_Carrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboFile_Color
            '
            Me.cboFile_Color.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_Color.AutoCompletion = True
            Me.cboFile_Color.AutoDropDown = True
            Me.cboFile_Color.AutoSelect = True
            Me.cboFile_Color.Caption = ""
            Me.cboFile_Color.CaptionHeight = 17
            Me.cboFile_Color.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_Color.ColumnCaptionHeight = 17
            Me.cboFile_Color.ColumnFooterHeight = 17
            Me.cboFile_Color.ColumnHeaders = False
            Me.cboFile_Color.ContentHeight = 15
            Me.cboFile_Color.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_Color.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_Color.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_Color.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_Color.EditorHeight = 15
            Me.cboFile_Color.Enabled = False
            Me.cboFile_Color.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboFile_Color.ItemHeight = 15
            Me.cboFile_Color.Location = New System.Drawing.Point(664, 24)
            Me.cboFile_Color.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_Color.MaxDropDownItems = CType(10, Short)
            Me.cboFile_Color.MaxLength = 32767
            Me.cboFile_Color.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_Color.Name = "cboFile_Color"
            Me.cboFile_Color.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_Color.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_Color.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_Color.Size = New System.Drawing.Size(208, 21)
            Me.cboFile_Color.TabIndex = 88
            Me.cboFile_Color.TabStop = False
            Me.cboFile_Color.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboFile_Model
            '
            Me.cboFile_Model.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_Model.AutoCompletion = True
            Me.cboFile_Model.AutoDropDown = True
            Me.cboFile_Model.AutoSelect = True
            Me.cboFile_Model.Caption = ""
            Me.cboFile_Model.CaptionHeight = 17
            Me.cboFile_Model.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_Model.ColumnCaptionHeight = 17
            Me.cboFile_Model.ColumnFooterHeight = 17
            Me.cboFile_Model.ColumnHeaders = False
            Me.cboFile_Model.ContentHeight = 15
            Me.cboFile_Model.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_Model.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_Model.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_Model.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_Model.EditorHeight = 15
            Me.cboFile_Model.Enabled = False
            Me.cboFile_Model.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboFile_Model.ItemHeight = 15
            Me.cboFile_Model.Location = New System.Drawing.Point(200, 24)
            Me.cboFile_Model.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_Model.MaxDropDownItems = CType(10, Short)
            Me.cboFile_Model.MaxLength = 32767
            Me.cboFile_Model.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_Model.Name = "cboFile_Model"
            Me.cboFile_Model.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_Model.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_Model.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_Model.Size = New System.Drawing.Size(200, 21)
            Me.cboFile_Model.TabIndex = 86
            Me.cboFile_Model.TabStop = False
            Me.cboFile_Model.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboFile_OEM
            '
            Me.cboFile_OEM.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_OEM.AutoCompletion = True
            Me.cboFile_OEM.AutoDropDown = True
            Me.cboFile_OEM.AutoSelect = True
            Me.cboFile_OEM.Caption = ""
            Me.cboFile_OEM.CaptionHeight = 17
            Me.cboFile_OEM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_OEM.ColumnCaptionHeight = 17
            Me.cboFile_OEM.ColumnFooterHeight = 17
            Me.cboFile_OEM.ColumnHeaders = False
            Me.cboFile_OEM.ContentHeight = 15
            Me.cboFile_OEM.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_OEM.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_OEM.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_OEM.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_OEM.EditorHeight = 15
            Me.cboFile_OEM.Enabled = False
            Me.cboFile_OEM.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboFile_OEM.ItemHeight = 15
            Me.cboFile_OEM.Location = New System.Drawing.Point(16, 24)
            Me.cboFile_OEM.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_OEM.MaxDropDownItems = CType(10, Short)
            Me.cboFile_OEM.MaxLength = 32767
            Me.cboFile_OEM.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_OEM.Name = "cboFile_OEM"
            Me.cboFile_OEM.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_OEM.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_OEM.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_OEM.Size = New System.Drawing.Size(168, 21)
            Me.cboFile_OEM.TabIndex = 84
            Me.cboFile_OEM.TabStop = False
            Me.cboFile_OEM.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'txtDeviceID
            '
            Me.txtDeviceID.BackColor = System.Drawing.Color.White
            Me.txtDeviceID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceID.Location = New System.Drawing.Point(88, 8)
            Me.txtDeviceID.MaxLength = 25
            Me.txtDeviceID.Name = "txtDeviceID"
            Me.txtDeviceID.Size = New System.Drawing.Size(200, 21)
            Me.txtDeviceID.TabIndex = 0
            Me.txtDeviceID.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(16, 104)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 21)
            Me.Label3.TabIndex = 92
            Me.Label3.Text = "Order Qty"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblOrderQty
            '
            Me.lblOrderQty.BackColor = System.Drawing.Color.Black
            Me.lblOrderQty.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.Lime
            Me.lblOrderQty.Location = New System.Drawing.Point(8, 128)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(72, 40)
            Me.lblOrderQty.TabIndex = 93
            Me.lblOrderQty.Text = "0"
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblShipmentQty
            '
            Me.lblShipmentQty.BackColor = System.Drawing.Color.Black
            Me.lblShipmentQty.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipmentQty.ForeColor = System.Drawing.Color.Lime
            Me.lblShipmentQty.Location = New System.Drawing.Point(104, 128)
            Me.lblShipmentQty.Name = "lblShipmentQty"
            Me.lblShipmentQty.Size = New System.Drawing.Size(80, 40)
            Me.lblShipmentQty.TabIndex = 95
            Me.lblShipmentQty.Text = "0"
            Me.lblShipmentQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(104, 104)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(88, 21)
            Me.Label6.TabIndex = 94
            Me.Label6.Text = "Shipment Qty"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblOrderNo
            '
            Me.lblOrderNo.BackColor = System.Drawing.Color.White
            Me.lblOrderNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderNo.ForeColor = System.Drawing.Color.Black
            Me.lblOrderNo.Location = New System.Drawing.Point(88, 40)
            Me.lblOrderNo.Name = "lblOrderNo"
            Me.lblOrderNo.Size = New System.Drawing.Size(200, 21)
            Me.lblOrderNo.TabIndex = 97
            Me.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(16, 40)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(64, 21)
            Me.Label8.TabIndex = 96
            Me.Label8.Text = "Order: "
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboFile_FindMyiPhone
            '
            Me.cboFile_FindMyiPhone.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_FindMyiPhone.AutoCompletion = True
            Me.cboFile_FindMyiPhone.AutoDropDown = True
            Me.cboFile_FindMyiPhone.AutoSelect = True
            Me.cboFile_FindMyiPhone.Caption = ""
            Me.cboFile_FindMyiPhone.CaptionHeight = 17
            Me.cboFile_FindMyiPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_FindMyiPhone.ColumnCaptionHeight = 17
            Me.cboFile_FindMyiPhone.ColumnFooterHeight = 17
            Me.cboFile_FindMyiPhone.ColumnHeaders = False
            Me.cboFile_FindMyiPhone.ContentHeight = 15
            Me.cboFile_FindMyiPhone.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_FindMyiPhone.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_FindMyiPhone.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_FindMyiPhone.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_FindMyiPhone.EditorHeight = 15
            Me.cboFile_FindMyiPhone.Enabled = False
            Me.cboFile_FindMyiPhone.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboFile_FindMyiPhone.ItemHeight = 15
            Me.cboFile_FindMyiPhone.Location = New System.Drawing.Point(896, 24)
            Me.cboFile_FindMyiPhone.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_FindMyiPhone.MaxDropDownItems = CType(10, Short)
            Me.cboFile_FindMyiPhone.MaxLength = 32767
            Me.cboFile_FindMyiPhone.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_FindMyiPhone.Name = "cboFile_FindMyiPhone"
            Me.cboFile_FindMyiPhone.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_FindMyiPhone.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_FindMyiPhone.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_FindMyiPhone.Size = New System.Drawing.Size(88, 21)
            Me.cboFile_FindMyiPhone.TabIndex = 98
            Me.cboFile_FindMyiPhone.TabStop = False
            Me.cboFile_FindMyiPhone.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboFile_Memory
            '
            Me.cboFile_Memory.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_Memory.AutoCompletion = True
            Me.cboFile_Memory.AutoDropDown = True
            Me.cboFile_Memory.AutoSelect = True
            Me.cboFile_Memory.Caption = ""
            Me.cboFile_Memory.CaptionHeight = 17
            Me.cboFile_Memory.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_Memory.ColumnCaptionHeight = 17
            Me.cboFile_Memory.ColumnFooterHeight = 17
            Me.cboFile_Memory.ColumnHeaders = False
            Me.cboFile_Memory.ContentHeight = 15
            Me.cboFile_Memory.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_Memory.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_Memory.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_Memory.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_Memory.EditorHeight = 15
            Me.cboFile_Memory.Enabled = False
            Me.cboFile_Memory.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.cboFile_Memory.ItemHeight = 15
            Me.cboFile_Memory.Location = New System.Drawing.Point(312, 88)
            Me.cboFile_Memory.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_Memory.MaxDropDownItems = CType(10, Short)
            Me.cboFile_Memory.MaxLength = 32767
            Me.cboFile_Memory.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_Memory.Name = "cboFile_Memory"
            Me.cboFile_Memory.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_Memory.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_Memory.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_Memory.Size = New System.Drawing.Size(88, 21)
            Me.cboFile_Memory.TabIndex = 100
            Me.cboFile_Memory.TabStop = False
            Me.cboFile_Memory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboFile_CarrLockUnLock
            '
            Me.cboFile_CarrLockUnLock.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_CarrLockUnLock.AutoCompletion = True
            Me.cboFile_CarrLockUnLock.AutoDropDown = True
            Me.cboFile_CarrLockUnLock.AutoSelect = True
            Me.cboFile_CarrLockUnLock.Caption = ""
            Me.cboFile_CarrLockUnLock.CaptionHeight = 17
            Me.cboFile_CarrLockUnLock.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_CarrLockUnLock.ColumnCaptionHeight = 17
            Me.cboFile_CarrLockUnLock.ColumnFooterHeight = 17
            Me.cboFile_CarrLockUnLock.ColumnHeaders = False
            Me.cboFile_CarrLockUnLock.ContentHeight = 15
            Me.cboFile_CarrLockUnLock.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_CarrLockUnLock.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_CarrLockUnLock.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_CarrLockUnLock.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_CarrLockUnLock.EditorHeight = 15
            Me.cboFile_CarrLockUnLock.Enabled = False
            Me.cboFile_CarrLockUnLock.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
            Me.cboFile_CarrLockUnLock.ItemHeight = 15
            Me.cboFile_CarrLockUnLock.Location = New System.Drawing.Point(416, 88)
            Me.cboFile_CarrLockUnLock.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_CarrLockUnLock.MaxDropDownItems = CType(10, Short)
            Me.cboFile_CarrLockUnLock.MaxLength = 32767
            Me.cboFile_CarrLockUnLock.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_CarrLockUnLock.Name = "cboFile_CarrLockUnLock"
            Me.cboFile_CarrLockUnLock.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_CarrLockUnLock.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_CarrLockUnLock.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_CarrLockUnLock.Size = New System.Drawing.Size(120, 21)
            Me.cboFile_CarrLockUnLock.TabIndex = 102
            Me.cboFile_CarrLockUnLock.TabStop = False
            Me.cboFile_CarrLockUnLock.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboFile_Condition
            '
            Me.cboFile_Condition.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_Condition.AutoCompletion = True
            Me.cboFile_Condition.AutoDropDown = True
            Me.cboFile_Condition.AutoSelect = True
            Me.cboFile_Condition.Caption = ""
            Me.cboFile_Condition.CaptionHeight = 17
            Me.cboFile_Condition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_Condition.ColumnCaptionHeight = 17
            Me.cboFile_Condition.ColumnFooterHeight = 17
            Me.cboFile_Condition.ColumnHeaders = False
            Me.cboFile_Condition.ContentHeight = 15
            Me.cboFile_Condition.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_Condition.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_Condition.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_Condition.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_Condition.EditorHeight = 15
            Me.cboFile_Condition.Enabled = False
            Me.cboFile_Condition.Images.Add(CType(resources.GetObject("resource.Images9"), System.Drawing.Bitmap))
            Me.cboFile_Condition.ItemHeight = 15
            Me.cboFile_Condition.Location = New System.Drawing.Point(552, 88)
            Me.cboFile_Condition.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_Condition.MaxDropDownItems = CType(10, Short)
            Me.cboFile_Condition.MaxLength = 32767
            Me.cboFile_Condition.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_Condition.Name = "cboFile_Condition"
            Me.cboFile_Condition.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_Condition.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_Condition.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_Condition.Size = New System.Drawing.Size(96, 21)
            Me.cboFile_Condition.TabIndex = 104
            Me.cboFile_Condition.TabStop = False
            Me.cboFile_Condition.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboRec_DataWip
            '
            Me.cboRec_DataWip.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_DataWip.AutoCompletion = True
            Me.cboRec_DataWip.AutoDropDown = True
            Me.cboRec_DataWip.AutoSelect = True
            Me.cboRec_DataWip.Caption = ""
            Me.cboRec_DataWip.CaptionHeight = 17
            Me.cboRec_DataWip.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_DataWip.ColumnCaptionHeight = 17
            Me.cboRec_DataWip.ColumnFooterHeight = 17
            Me.cboRec_DataWip.ColumnHeaders = False
            Me.cboRec_DataWip.ContentHeight = 15
            Me.cboRec_DataWip.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_DataWip.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_DataWip.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_DataWip.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_DataWip.EditorHeight = 15
            Me.cboRec_DataWip.Images.Add(CType(resources.GetObject("resource.Images10"), System.Drawing.Bitmap))
            Me.cboRec_DataWip.ItemHeight = 15
            Me.cboRec_DataWip.Location = New System.Drawing.Point(664, 112)
            Me.cboRec_DataWip.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_DataWip.MaxDropDownItems = CType(10, Short)
            Me.cboRec_DataWip.MaxLength = 32767
            Me.cboRec_DataWip.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_DataWip.Name = "cboRec_DataWip"
            Me.cboRec_DataWip.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_DataWip.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_DataWip.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_DataWip.Size = New System.Drawing.Size(88, 21)
            Me.cboRec_DataWip.TabIndex = 11
            Me.cboRec_DataWip.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label20
            '
            Me.Label20.BackColor = System.Drawing.Color.Transparent
            Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.Black
            Me.Label20.Location = New System.Drawing.Point(664, 72)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(88, 16)
            Me.Label20.TabIndex = 107
            Me.Label20.Text = "Data Wiped"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'gbRecData
            '
            Me.gbRecData.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboRec_EsnImeiChecked, Me.cboFile_EsnImeiChecked, Me.Label1, Me.lblDevDisposition, Me.btnReceive, Me.cboRec_Condition, Me.Label21, Me.cboRec_CarrLockUnLock, Me.Label22, Me.cboRec_Memory, Me.Label23, Me.cboRec_FindMyiPhone, Me.Label24, Me.cboRec_Technology, Me.Label25, Me.cboRec_BatteryPresent, Me.Label26, Me.cboRec_BatteryDoorPresent, Me.Label27, Me.cboRec_Carrier, Me.Label28, Me.cboRec_Color, Me.Label29, Me.cboRec_Model, Me.Label30, Me.cboRec_OEM, Me.Label31, Me.cboRec_DataWip, Me.Label20, Me.cboFile_OEM, Me.cboFile_Model, Me.cboFile_BatteryDoorPresent, Me.cboFile_BatteryPresent, Me.cboFile_Color, Me.cboFile_FindMyiPhone, Me.cboFile_Carrier, Me.cboFile_Memory, Me.cboFile_CarrLockUnLock, Me.cboFile_Condition})
            Me.gbRecData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbRecData.ForeColor = System.Drawing.Color.White
            Me.gbRecData.Location = New System.Drawing.Point(8, 176)
            Me.gbRecData.Name = "gbRecData"
            Me.gbRecData.Size = New System.Drawing.Size(992, 144)
            Me.gbRecData.TabIndex = 3
            Me.gbRecData.TabStop = False
            '
            'cboRec_EsnImeiChecked
            '
            Me.cboRec_EsnImeiChecked.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_EsnImeiChecked.AutoCompletion = True
            Me.cboRec_EsnImeiChecked.AutoDropDown = True
            Me.cboRec_EsnImeiChecked.AutoSelect = True
            Me.cboRec_EsnImeiChecked.Caption = ""
            Me.cboRec_EsnImeiChecked.CaptionHeight = 17
            Me.cboRec_EsnImeiChecked.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_EsnImeiChecked.ColumnCaptionHeight = 17
            Me.cboRec_EsnImeiChecked.ColumnFooterHeight = 17
            Me.cboRec_EsnImeiChecked.ColumnHeaders = False
            Me.cboRec_EsnImeiChecked.ContentHeight = 15
            Me.cboRec_EsnImeiChecked.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_EsnImeiChecked.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_EsnImeiChecked.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_EsnImeiChecked.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_EsnImeiChecked.EditorHeight = 15
            Me.cboRec_EsnImeiChecked.Enabled = False
            Me.cboRec_EsnImeiChecked.Images.Add(CType(resources.GetObject("resource.Images11"), System.Drawing.Bitmap))
            Me.cboRec_EsnImeiChecked.ItemHeight = 15
            Me.cboRec_EsnImeiChecked.Location = New System.Drawing.Point(784, 112)
            Me.cboRec_EsnImeiChecked.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_EsnImeiChecked.MaxDropDownItems = CType(10, Short)
            Me.cboRec_EsnImeiChecked.MaxLength = 32767
            Me.cboRec_EsnImeiChecked.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_EsnImeiChecked.Name = "cboRec_EsnImeiChecked"
            Me.cboRec_EsnImeiChecked.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_EsnImeiChecked.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_EsnImeiChecked.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_EsnImeiChecked.Size = New System.Drawing.Size(88, 21)
            Me.cboRec_EsnImeiChecked.TabIndex = 112
            Me.cboRec_EsnImeiChecked.TabStop = False
            Me.cboRec_EsnImeiChecked.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboFile_EsnImeiChecked
            '
            Me.cboFile_EsnImeiChecked.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboFile_EsnImeiChecked.AutoCompletion = True
            Me.cboFile_EsnImeiChecked.AutoDropDown = True
            Me.cboFile_EsnImeiChecked.AutoSelect = True
            Me.cboFile_EsnImeiChecked.Caption = ""
            Me.cboFile_EsnImeiChecked.CaptionHeight = 17
            Me.cboFile_EsnImeiChecked.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboFile_EsnImeiChecked.ColumnCaptionHeight = 17
            Me.cboFile_EsnImeiChecked.ColumnFooterHeight = 17
            Me.cboFile_EsnImeiChecked.ColumnHeaders = False
            Me.cboFile_EsnImeiChecked.ContentHeight = 15
            Me.cboFile_EsnImeiChecked.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboFile_EsnImeiChecked.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboFile_EsnImeiChecked.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboFile_EsnImeiChecked.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboFile_EsnImeiChecked.EditorHeight = 15
            Me.cboFile_EsnImeiChecked.Enabled = False
            Me.cboFile_EsnImeiChecked.Images.Add(CType(resources.GetObject("resource.Images12"), System.Drawing.Bitmap))
            Me.cboFile_EsnImeiChecked.ItemHeight = 15
            Me.cboFile_EsnImeiChecked.Location = New System.Drawing.Point(784, 88)
            Me.cboFile_EsnImeiChecked.MatchEntryTimeout = CType(2000, Long)
            Me.cboFile_EsnImeiChecked.MaxDropDownItems = CType(10, Short)
            Me.cboFile_EsnImeiChecked.MaxLength = 32767
            Me.cboFile_EsnImeiChecked.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboFile_EsnImeiChecked.Name = "cboFile_EsnImeiChecked"
            Me.cboFile_EsnImeiChecked.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboFile_EsnImeiChecked.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboFile_EsnImeiChecked.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboFile_EsnImeiChecked.Size = New System.Drawing.Size(88, 21)
            Me.cboFile_EsnImeiChecked.TabIndex = 110
            Me.cboFile_EsnImeiChecked.TabStop = False
            Me.cboFile_EsnImeiChecked.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(776, 72)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(120, 16)
            Me.Label1.TabIndex = 111
            Me.Label1.Text = "ESN/IMEI Checked"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblDevDisposition
            '
            Me.lblDevDisposition.BackColor = System.Drawing.Color.Black
            Me.lblDevDisposition.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevDisposition.ForeColor = System.Drawing.Color.Lime
            Me.lblDevDisposition.Location = New System.Drawing.Point(896, 87)
            Me.lblDevDisposition.Name = "lblDevDisposition"
            Me.lblDevDisposition.Size = New System.Drawing.Size(88, 21)
            Me.lblDevDisposition.TabIndex = 109
            Me.lblDevDisposition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReceive
            '
            Me.btnReceive.BackColor = System.Drawing.Color.DarkGreen
            Me.btnReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceive.Location = New System.Drawing.Point(896, 112)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.Size = New System.Drawing.Size(88, 21)
            Me.btnReceive.TabIndex = 108
            Me.btnReceive.Text = "Receive"
            '
            'cboRec_Condition
            '
            Me.cboRec_Condition.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_Condition.AutoCompletion = True
            Me.cboRec_Condition.AutoDropDown = True
            Me.cboRec_Condition.AutoSelect = True
            Me.cboRec_Condition.Caption = ""
            Me.cboRec_Condition.CaptionHeight = 17
            Me.cboRec_Condition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_Condition.ColumnCaptionHeight = 17
            Me.cboRec_Condition.ColumnFooterHeight = 17
            Me.cboRec_Condition.ColumnHeaders = False
            Me.cboRec_Condition.ContentHeight = 15
            Me.cboRec_Condition.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_Condition.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_Condition.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_Condition.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_Condition.EditorHeight = 15
            Me.cboRec_Condition.Images.Add(CType(resources.GetObject("resource.Images13"), System.Drawing.Bitmap))
            Me.cboRec_Condition.ItemHeight = 15
            Me.cboRec_Condition.Location = New System.Drawing.Point(552, 112)
            Me.cboRec_Condition.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_Condition.MaxDropDownItems = CType(10, Short)
            Me.cboRec_Condition.MaxLength = 32767
            Me.cboRec_Condition.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_Condition.Name = "cboRec_Condition"
            Me.cboRec_Condition.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_Condition.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_Condition.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_Condition.Size = New System.Drawing.Size(96, 21)
            Me.cboRec_Condition.TabIndex = 10
            Me.cboRec_Condition.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label21
            '
            Me.Label21.BackColor = System.Drawing.Color.Transparent
            Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.ForeColor = System.Drawing.Color.Black
            Me.Label21.Location = New System.Drawing.Point(552, 72)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(88, 16)
            Me.Label21.TabIndex = 105
            Me.Label21.Text = "Condition"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_CarrLockUnLock
            '
            Me.cboRec_CarrLockUnLock.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_CarrLockUnLock.AutoCompletion = True
            Me.cboRec_CarrLockUnLock.AutoDropDown = True
            Me.cboRec_CarrLockUnLock.AutoSelect = True
            Me.cboRec_CarrLockUnLock.Caption = ""
            Me.cboRec_CarrLockUnLock.CaptionHeight = 17
            Me.cboRec_CarrLockUnLock.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_CarrLockUnLock.ColumnCaptionHeight = 17
            Me.cboRec_CarrLockUnLock.ColumnFooterHeight = 17
            Me.cboRec_CarrLockUnLock.ColumnHeaders = False
            Me.cboRec_CarrLockUnLock.ContentHeight = 15
            Me.cboRec_CarrLockUnLock.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_CarrLockUnLock.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_CarrLockUnLock.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_CarrLockUnLock.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_CarrLockUnLock.EditorHeight = 15
            Me.cboRec_CarrLockUnLock.Images.Add(CType(resources.GetObject("resource.Images14"), System.Drawing.Bitmap))
            Me.cboRec_CarrLockUnLock.ItemHeight = 15
            Me.cboRec_CarrLockUnLock.Location = New System.Drawing.Point(416, 112)
            Me.cboRec_CarrLockUnLock.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_CarrLockUnLock.MaxDropDownItems = CType(10, Short)
            Me.cboRec_CarrLockUnLock.MaxLength = 32767
            Me.cboRec_CarrLockUnLock.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_CarrLockUnLock.Name = "cboRec_CarrLockUnLock"
            Me.cboRec_CarrLockUnLock.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_CarrLockUnLock.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_CarrLockUnLock.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_CarrLockUnLock.Size = New System.Drawing.Size(120, 21)
            Me.cboRec_CarrLockUnLock.TabIndex = 9
            Me.cboRec_CarrLockUnLock.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label22
            '
            Me.Label22.BackColor = System.Drawing.Color.Transparent
            Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.Black
            Me.Label22.Location = New System.Drawing.Point(416, 72)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(88, 16)
            Me.Label22.TabIndex = 103
            Me.Label22.Text = "Carr. Lock?"
            Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_Memory
            '
            Me.cboRec_Memory.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_Memory.AutoCompletion = True
            Me.cboRec_Memory.AutoDropDown = True
            Me.cboRec_Memory.AutoSelect = True
            Me.cboRec_Memory.Caption = ""
            Me.cboRec_Memory.CaptionHeight = 17
            Me.cboRec_Memory.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_Memory.ColumnCaptionHeight = 17
            Me.cboRec_Memory.ColumnFooterHeight = 17
            Me.cboRec_Memory.ColumnHeaders = False
            Me.cboRec_Memory.ContentHeight = 15
            Me.cboRec_Memory.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_Memory.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_Memory.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_Memory.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_Memory.EditorHeight = 15
            Me.cboRec_Memory.Images.Add(CType(resources.GetObject("resource.Images15"), System.Drawing.Bitmap))
            Me.cboRec_Memory.ItemHeight = 15
            Me.cboRec_Memory.Location = New System.Drawing.Point(312, 112)
            Me.cboRec_Memory.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_Memory.MaxDropDownItems = CType(10, Short)
            Me.cboRec_Memory.MaxLength = 32767
            Me.cboRec_Memory.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_Memory.Name = "cboRec_Memory"
            Me.cboRec_Memory.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_Memory.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_Memory.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_Memory.Size = New System.Drawing.Size(88, 21)
            Me.cboRec_Memory.TabIndex = 8
            Me.cboRec_Memory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label23
            '
            Me.Label23.BackColor = System.Drawing.Color.Transparent
            Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label23.ForeColor = System.Drawing.Color.Black
            Me.Label23.Location = New System.Drawing.Point(312, 72)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(88, 16)
            Me.Label23.TabIndex = 101
            Me.Label23.Text = "Memory"
            Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_FindMyiPhone
            '
            Me.cboRec_FindMyiPhone.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_FindMyiPhone.AutoCompletion = True
            Me.cboRec_FindMyiPhone.AutoDropDown = True
            Me.cboRec_FindMyiPhone.AutoSelect = True
            Me.cboRec_FindMyiPhone.Caption = ""
            Me.cboRec_FindMyiPhone.CaptionHeight = 17
            Me.cboRec_FindMyiPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_FindMyiPhone.ColumnCaptionHeight = 17
            Me.cboRec_FindMyiPhone.ColumnFooterHeight = 17
            Me.cboRec_FindMyiPhone.ColumnHeaders = False
            Me.cboRec_FindMyiPhone.ContentHeight = 15
            Me.cboRec_FindMyiPhone.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_FindMyiPhone.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_FindMyiPhone.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_FindMyiPhone.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_FindMyiPhone.EditorHeight = 15
            Me.cboRec_FindMyiPhone.Images.Add(CType(resources.GetObject("resource.Images16"), System.Drawing.Bitmap))
            Me.cboRec_FindMyiPhone.ItemHeight = 15
            Me.cboRec_FindMyiPhone.Location = New System.Drawing.Point(896, 48)
            Me.cboRec_FindMyiPhone.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_FindMyiPhone.MaxDropDownItems = CType(10, Short)
            Me.cboRec_FindMyiPhone.MaxLength = 32767
            Me.cboRec_FindMyiPhone.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_FindMyiPhone.Name = "cboRec_FindMyiPhone"
            Me.cboRec_FindMyiPhone.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_FindMyiPhone.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_FindMyiPhone.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_FindMyiPhone.Size = New System.Drawing.Size(88, 21)
            Me.cboRec_FindMyiPhone.TabIndex = 5
            Me.cboRec_FindMyiPhone.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label24
            '
            Me.Label24.BackColor = System.Drawing.Color.Transparent
            Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label24.ForeColor = System.Drawing.Color.Black
            Me.Label24.Location = New System.Drawing.Point(896, 8)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(96, 16)
            Me.Label24.TabIndex = 99
            Me.Label24.Text = "Find My iPhone"
            Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_Technology
            '
            Me.cboRec_Technology.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_Technology.AutoCompletion = True
            Me.cboRec_Technology.AutoDropDown = True
            Me.cboRec_Technology.AutoSelect = True
            Me.cboRec_Technology.Caption = ""
            Me.cboRec_Technology.CaptionHeight = 17
            Me.cboRec_Technology.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_Technology.ColumnCaptionHeight = 17
            Me.cboRec_Technology.ColumnFooterHeight = 17
            Me.cboRec_Technology.ColumnHeaders = False
            Me.cboRec_Technology.ContentHeight = 15
            Me.cboRec_Technology.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_Technology.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_Technology.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_Technology.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_Technology.EditorHeight = 15
            Me.cboRec_Technology.Images.Add(CType(resources.GetObject("resource.Images17"), System.Drawing.Bitmap))
            Me.cboRec_Technology.ItemHeight = 15
            Me.cboRec_Technology.Location = New System.Drawing.Point(200, 112)
            Me.cboRec_Technology.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_Technology.MaxDropDownItems = CType(10, Short)
            Me.cboRec_Technology.MaxLength = 32767
            Me.cboRec_Technology.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_Technology.Name = "cboRec_Technology"
            Me.cboRec_Technology.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_Technology.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_Technology.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_Technology.Size = New System.Drawing.Size(88, 21)
            Me.cboRec_Technology.TabIndex = 7
            Me.cboRec_Technology.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label25
            '
            Me.Label25.BackColor = System.Drawing.Color.Transparent
            Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label25.ForeColor = System.Drawing.Color.Black
            Me.Label25.Location = New System.Drawing.Point(200, 72)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(88, 16)
            Me.Label25.TabIndex = 97
            Me.Label25.Text = "Technology"
            Me.Label25.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_BatteryPresent
            '
            Me.cboRec_BatteryPresent.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_BatteryPresent.AutoCompletion = True
            Me.cboRec_BatteryPresent.AutoDropDown = True
            Me.cboRec_BatteryPresent.AutoSelect = True
            Me.cboRec_BatteryPresent.Caption = ""
            Me.cboRec_BatteryPresent.CaptionHeight = 17
            Me.cboRec_BatteryPresent.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_BatteryPresent.ColumnCaptionHeight = 17
            Me.cboRec_BatteryPresent.ColumnFooterHeight = 17
            Me.cboRec_BatteryPresent.ColumnHeaders = False
            Me.cboRec_BatteryPresent.ContentHeight = 15
            Me.cboRec_BatteryPresent.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_BatteryPresent.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_BatteryPresent.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_BatteryPresent.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_BatteryPresent.EditorHeight = 15
            Me.cboRec_BatteryPresent.Images.Add(CType(resources.GetObject("resource.Images18"), System.Drawing.Bitmap))
            Me.cboRec_BatteryPresent.ItemHeight = 15
            Me.cboRec_BatteryPresent.Location = New System.Drawing.Point(552, 48)
            Me.cboRec_BatteryPresent.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_BatteryPresent.MaxDropDownItems = CType(10, Short)
            Me.cboRec_BatteryPresent.MaxLength = 32767
            Me.cboRec_BatteryPresent.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_BatteryPresent.Name = "cboRec_BatteryPresent"
            Me.cboRec_BatteryPresent.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_BatteryPresent.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_BatteryPresent.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_BatteryPresent.Size = New System.Drawing.Size(96, 21)
            Me.cboRec_BatteryPresent.TabIndex = 3
            Me.cboRec_BatteryPresent.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label26
            '
            Me.Label26.BackColor = System.Drawing.Color.Transparent
            Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label26.ForeColor = System.Drawing.Color.Black
            Me.Label26.Location = New System.Drawing.Point(552, 8)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(104, 16)
            Me.Label26.TabIndex = 95
            Me.Label26.Text = "Batt. Present"
            Me.Label26.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_BatteryDoorPresent
            '
            Me.cboRec_BatteryDoorPresent.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_BatteryDoorPresent.AutoCompletion = True
            Me.cboRec_BatteryDoorPresent.AutoDropDown = True
            Me.cboRec_BatteryDoorPresent.AutoSelect = True
            Me.cboRec_BatteryDoorPresent.Caption = ""
            Me.cboRec_BatteryDoorPresent.CaptionHeight = 17
            Me.cboRec_BatteryDoorPresent.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_BatteryDoorPresent.ColumnCaptionHeight = 17
            Me.cboRec_BatteryDoorPresent.ColumnFooterHeight = 17
            Me.cboRec_BatteryDoorPresent.ColumnHeaders = False
            Me.cboRec_BatteryDoorPresent.ContentHeight = 15
            Me.cboRec_BatteryDoorPresent.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_BatteryDoorPresent.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_BatteryDoorPresent.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_BatteryDoorPresent.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_BatteryDoorPresent.EditorHeight = 15
            Me.cboRec_BatteryDoorPresent.Images.Add(CType(resources.GetObject("resource.Images19"), System.Drawing.Bitmap))
            Me.cboRec_BatteryDoorPresent.ItemHeight = 15
            Me.cboRec_BatteryDoorPresent.Location = New System.Drawing.Point(416, 48)
            Me.cboRec_BatteryDoorPresent.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_BatteryDoorPresent.MaxDropDownItems = CType(10, Short)
            Me.cboRec_BatteryDoorPresent.MaxLength = 32767
            Me.cboRec_BatteryDoorPresent.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_BatteryDoorPresent.Name = "cboRec_BatteryDoorPresent"
            Me.cboRec_BatteryDoorPresent.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_BatteryDoorPresent.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_BatteryDoorPresent.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_BatteryDoorPresent.Size = New System.Drawing.Size(120, 21)
            Me.cboRec_BatteryDoorPresent.TabIndex = 2
            Me.cboRec_BatteryDoorPresent.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label27
            '
            Me.Label27.BackColor = System.Drawing.Color.Transparent
            Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label27.ForeColor = System.Drawing.Color.Black
            Me.Label27.Location = New System.Drawing.Point(416, 8)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(136, 16)
            Me.Label27.TabIndex = 93
            Me.Label27.Text = "Batt. Door Present"
            Me.Label27.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_Carrier
            '
            Me.cboRec_Carrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_Carrier.AutoCompletion = True
            Me.cboRec_Carrier.AutoDropDown = True
            Me.cboRec_Carrier.AutoSelect = True
            Me.cboRec_Carrier.Caption = ""
            Me.cboRec_Carrier.CaptionHeight = 17
            Me.cboRec_Carrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_Carrier.ColumnCaptionHeight = 17
            Me.cboRec_Carrier.ColumnFooterHeight = 17
            Me.cboRec_Carrier.ColumnHeaders = False
            Me.cboRec_Carrier.ContentHeight = 15
            Me.cboRec_Carrier.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_Carrier.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_Carrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_Carrier.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_Carrier.EditorHeight = 15
            Me.cboRec_Carrier.Images.Add(CType(resources.GetObject("resource.Images20"), System.Drawing.Bitmap))
            Me.cboRec_Carrier.ItemHeight = 15
            Me.cboRec_Carrier.Location = New System.Drawing.Point(16, 112)
            Me.cboRec_Carrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_Carrier.MaxDropDownItems = CType(10, Short)
            Me.cboRec_Carrier.MaxLength = 32767
            Me.cboRec_Carrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_Carrier.Name = "cboRec_Carrier"
            Me.cboRec_Carrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_Carrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_Carrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_Carrier.Size = New System.Drawing.Size(168, 21)
            Me.cboRec_Carrier.TabIndex = 6
            Me.cboRec_Carrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label28
            '
            Me.Label28.BackColor = System.Drawing.Color.Transparent
            Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label28.ForeColor = System.Drawing.Color.Black
            Me.Label28.Location = New System.Drawing.Point(16, 72)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(130, 16)
            Me.Label28.TabIndex = 91
            Me.Label28.Text = "Carrier"
            Me.Label28.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_Color
            '
            Me.cboRec_Color.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_Color.AutoCompletion = True
            Me.cboRec_Color.AutoDropDown = True
            Me.cboRec_Color.AutoSelect = True
            Me.cboRec_Color.Caption = ""
            Me.cboRec_Color.CaptionHeight = 17
            Me.cboRec_Color.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_Color.ColumnCaptionHeight = 17
            Me.cboRec_Color.ColumnFooterHeight = 17
            Me.cboRec_Color.ColumnHeaders = False
            Me.cboRec_Color.ContentHeight = 15
            Me.cboRec_Color.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_Color.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_Color.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_Color.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_Color.EditorHeight = 15
            Me.cboRec_Color.Images.Add(CType(resources.GetObject("resource.Images21"), System.Drawing.Bitmap))
            Me.cboRec_Color.ItemHeight = 15
            Me.cboRec_Color.Location = New System.Drawing.Point(664, 48)
            Me.cboRec_Color.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_Color.MaxDropDownItems = CType(10, Short)
            Me.cboRec_Color.MaxLength = 32767
            Me.cboRec_Color.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_Color.Name = "cboRec_Color"
            Me.cboRec_Color.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_Color.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_Color.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_Color.Size = New System.Drawing.Size(208, 21)
            Me.cboRec_Color.TabIndex = 4
            Me.cboRec_Color.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label29
            '
            Me.Label29.BackColor = System.Drawing.Color.Transparent
            Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label29.ForeColor = System.Drawing.Color.Black
            Me.Label29.Location = New System.Drawing.Point(664, 8)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(130, 16)
            Me.Label29.TabIndex = 89
            Me.Label29.Text = "Color"
            Me.Label29.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_Model
            '
            Me.cboRec_Model.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_Model.AutoCompletion = True
            Me.cboRec_Model.AutoDropDown = True
            Me.cboRec_Model.AutoSelect = True
            Me.cboRec_Model.Caption = ""
            Me.cboRec_Model.CaptionHeight = 17
            Me.cboRec_Model.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_Model.ColumnCaptionHeight = 17
            Me.cboRec_Model.ColumnFooterHeight = 17
            Me.cboRec_Model.ColumnHeaders = False
            Me.cboRec_Model.ContentHeight = 15
            Me.cboRec_Model.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_Model.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_Model.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_Model.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_Model.EditorHeight = 15
            Me.cboRec_Model.Images.Add(CType(resources.GetObject("resource.Images22"), System.Drawing.Bitmap))
            Me.cboRec_Model.ItemHeight = 15
            Me.cboRec_Model.Location = New System.Drawing.Point(200, 48)
            Me.cboRec_Model.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_Model.MaxDropDownItems = CType(10, Short)
            Me.cboRec_Model.MaxLength = 32767
            Me.cboRec_Model.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_Model.Name = "cboRec_Model"
            Me.cboRec_Model.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_Model.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_Model.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_Model.Size = New System.Drawing.Size(200, 21)
            Me.cboRec_Model.TabIndex = 1
            Me.cboRec_Model.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label30
            '
            Me.Label30.BackColor = System.Drawing.Color.Transparent
            Me.Label30.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label30.ForeColor = System.Drawing.Color.Black
            Me.Label30.Location = New System.Drawing.Point(200, 8)
            Me.Label30.Name = "Label30"
            Me.Label30.Size = New System.Drawing.Size(130, 16)
            Me.Label30.TabIndex = 87
            Me.Label30.Text = "Model"
            Me.Label30.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_OEM
            '
            Me.cboRec_OEM.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_OEM.AutoCompletion = True
            Me.cboRec_OEM.AutoDropDown = True
            Me.cboRec_OEM.AutoSelect = True
            Me.cboRec_OEM.Caption = ""
            Me.cboRec_OEM.CaptionHeight = 17
            Me.cboRec_OEM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_OEM.ColumnCaptionHeight = 17
            Me.cboRec_OEM.ColumnFooterHeight = 17
            Me.cboRec_OEM.ColumnHeaders = False
            Me.cboRec_OEM.ContentHeight = 15
            Me.cboRec_OEM.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_OEM.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_OEM.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_OEM.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_OEM.EditorHeight = 15
            Me.cboRec_OEM.Images.Add(CType(resources.GetObject("resource.Images23"), System.Drawing.Bitmap))
            Me.cboRec_OEM.ItemHeight = 15
            Me.cboRec_OEM.Location = New System.Drawing.Point(16, 48)
            Me.cboRec_OEM.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_OEM.MaxDropDownItems = CType(10, Short)
            Me.cboRec_OEM.MaxLength = 32767
            Me.cboRec_OEM.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_OEM.Name = "cboRec_OEM"
            Me.cboRec_OEM.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_OEM.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_OEM.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_OEM.Size = New System.Drawing.Size(168, 21)
            Me.cboRec_OEM.TabIndex = 0
            Me.cboRec_OEM.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label31
            '
            Me.Label31.BackColor = System.Drawing.Color.Transparent
            Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label31.ForeColor = System.Drawing.Color.Black
            Me.Label31.Location = New System.Drawing.Point(16, 8)
            Me.Label31.Name = "Label31"
            Me.Label31.Size = New System.Drawing.Size(130, 16)
            Me.Label31.TabIndex = 85
            Me.Label31.Text = "OEM "
            Me.Label31.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'dbgOrderDetails
            '
            Me.dbgOrderDetails.AllowUpdate = False
            Me.dbgOrderDetails.AlternatingRows = True
            Me.dbgOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgOrderDetails.FilterBar = True
            Me.dbgOrderDetails.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgOrderDetails.Images.Add(CType(resources.GetObject("resource.Images24"), System.Drawing.Bitmap))
            Me.dbgOrderDetails.Location = New System.Drawing.Point(8, 328)
            Me.dbgOrderDetails.Name = "dbgOrderDetails"
            Me.dbgOrderDetails.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgOrderDetails.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgOrderDetails.PreviewInfo.ZoomFactor = 75
            Me.dbgOrderDetails.Size = New System.Drawing.Size(992, 136)
            Me.dbgOrderDetails.TabIndex = 8
            Me.dbgOrderDetails.TabStop = False
            Me.dbgOrderDetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "32</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 988, 132<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 988, 132</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnClearAll
            '
            Me.btnClearAll.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClearAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearAll.ForeColor = System.Drawing.Color.White
            Me.btnClearAll.Location = New System.Drawing.Point(624, 54)
            Me.btnClearAll.Name = "btnClearAll"
            Me.btnClearAll.Size = New System.Drawing.Size(88, 23)
            Me.btnClearAll.TabIndex = 8
            Me.btnClearAll.TabStop = False
            Me.btnClearAll.Text = "Clear All"
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(296, 8)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(32, 21)
            Me.Label7.TabIndex = 110
            Me.Label7.Text = "Tote ID: "
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCloseTote
            '
            Me.btnCloseTote.BackColor = System.Drawing.Color.DarkGreen
            Me.btnCloseTote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseTote.ForeColor = System.Drawing.Color.White
            Me.btnCloseTote.Location = New System.Drawing.Point(912, 8)
            Me.btnCloseTote.Name = "btnCloseTote"
            Me.btnCloseTote.Size = New System.Drawing.Size(88, 23)
            Me.btnCloseTote.TabIndex = 9
            Me.btnCloseTote.TabStop = False
            Me.btnCloseTote.Text = "Close Tote"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpItemRecTech, Me.tpHoldItems, Me.tpOpenTotes, Me.tpOpenOrders})
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1016, 504)
            Me.TabControl1.TabIndex = 113
            '
            'tpItemRecTech
            '
            Me.tpItemRecTech.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpItemRecTech.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPackageDamage, Me.btnReprintItemLabel, Me.dbgTote, Me.gbEsnImei, Me.lblReceiptQty, Me.Label9, Me.btnR_GetData, Me.lblOrderNo, Me.btnClearAll, Me.txtDeviceID, Me.Label5, Me.dbgOrderDetails, Me.gbRecData, Me.Label7, Me.Label8, Me.Label3, Me.lblOrderQty, Me.lblShipmentQty, Me.Label6, Me.btnCloseTote})
            Me.tpItemRecTech.Location = New System.Drawing.Point(4, 22)
            Me.tpItemRecTech.Name = "tpItemRecTech"
            Me.tpItemRecTech.Size = New System.Drawing.Size(1008, 478)
            Me.tpItemRecTech.TabIndex = 0
            Me.tpItemRecTech.Text = "Item Rec/Tech"
            '
            'chkPackageDamage
            '
            Me.chkPackageDamage.Enabled = False
            Me.chkPackageDamage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPackageDamage.ForeColor = System.Drawing.Color.Black
            Me.chkPackageDamage.Location = New System.Drawing.Point(88, 72)
            Me.chkPackageDamage.Name = "chkPackageDamage"
            Me.chkPackageDamage.Size = New System.Drawing.Size(160, 16)
            Me.chkPackageDamage.TabIndex = 116
            Me.chkPackageDamage.TabStop = False
            Me.chkPackageDamage.Text = "Package Damage"
            '
            'btnReprintItemLabel
            '
            Me.btnReprintItemLabel.BackColor = System.Drawing.Color.SlateBlue
            Me.btnReprintItemLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintItemLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintItemLabel.Location = New System.Drawing.Point(624, 118)
            Me.btnReprintItemLabel.Name = "btnReprintItemLabel"
            Me.btnReprintItemLabel.Size = New System.Drawing.Size(88, 24)
            Me.btnReprintItemLabel.TabIndex = 115
            Me.btnReprintItemLabel.Text = "Reprint Label"
            '
            'dbgTote
            '
            Me.dbgTote.AllowUpdate = False
            Me.dbgTote.AlternatingRows = True
            Me.dbgTote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgTote.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgTote.Images.Add(CType(resources.GetObject("resource.Images25"), System.Drawing.Bitmap))
            Me.dbgTote.Location = New System.Drawing.Point(336, 8)
            Me.dbgTote.Name = "dbgTote"
            Me.dbgTote.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgTote.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgTote.PreviewInfo.ZoomFactor = 75
            Me.dbgTote.Size = New System.Drawing.Size(544, 32)
            Me.dbgTote.TabIndex = 114
            Me.dbgTote.TabStop = False
            Me.dbgTote.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
            "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
            "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
            "le11{}OddRow{BackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:" & _
            "HighlightText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Sty" & _
            "le21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;" & _
            "}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:True;BackColor:Control;Border:Raise" & _
            "d,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft S" & _
            "ans Serif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Sty" & _
            "le8{}Style5{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDar" & _
            "k;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1Tru" & _
            "eDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordS" & _
            "electorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
            "oup=""1""><Height>30</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorS" & _
            "tyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" />" & _
            "<FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect" & _
            ">0, 0, 542, 30</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Border" & _
            "Style></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=" & _
            """Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foo" & _
            "ter"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inacti" & _
            "ve"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" " & _
            "/><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow""" & _
            " /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelect" & _
            "or"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group""" & _
            " /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Non" & _
            "e</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 542, 30</" & _
            "ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle " & _
            "parent="""" me=""Style21"" /></Blob>"
            '
            'gbEsnImei
            '
            Me.gbEsnImei.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkEsnImeiTampered, Me.Label10, Me.Label4, Me.Label14, Me.txtRec_EsnImei_Internal, Me.chkEsnImei_NoMatch, Me.txtRec_EsnImei_External, Me.txtFile_EsnImei})
            Me.gbEsnImei.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbEsnImei.Location = New System.Drawing.Point(336, 48)
            Me.gbEsnImei.Name = "gbEsnImei"
            Me.gbEsnImei.Size = New System.Drawing.Size(272, 128)
            Me.gbEsnImei.TabIndex = 2
            Me.gbEsnImei.TabStop = False
            Me.gbEsnImei.Text = "Esn/Imei"
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(8, 72)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(56, 21)
            Me.Label10.TabIndex = 118
            Me.Label10.Text = "External"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(8, 48)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(56, 21)
            Me.Label4.TabIndex = 116
            Me.Label4.Text = "Internal"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Black
            Me.Label14.Location = New System.Drawing.Point(32, 96)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(32, 21)
            Me.Label14.TabIndex = 125
            Me.Label14.Text = "File"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRec_EsnImei_Internal
            '
            Me.txtRec_EsnImei_Internal.BackColor = System.Drawing.Color.White
            Me.txtRec_EsnImei_Internal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRec_EsnImei_Internal.Location = New System.Drawing.Point(72, 48)
            Me.txtRec_EsnImei_Internal.MaxLength = 25
            Me.txtRec_EsnImei_Internal.Name = "txtRec_EsnImei_Internal"
            Me.txtRec_EsnImei_Internal.Size = New System.Drawing.Size(176, 21)
            Me.txtRec_EsnImei_Internal.TabIndex = 2
            Me.txtRec_EsnImei_Internal.Text = ""
            '
            'chkEsnImei_NoMatch
            '
            Me.chkEsnImei_NoMatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEsnImei_NoMatch.Location = New System.Drawing.Point(112, 16)
            Me.chkEsnImei_NoMatch.Name = "chkEsnImei_NoMatch"
            Me.chkEsnImei_NoMatch.Size = New System.Drawing.Size(152, 24)
            Me.chkEsnImei_NoMatch.TabIndex = 1
            Me.chkEsnImei_NoMatch.Text = "Internal does not match"
            '
            'txtRec_EsnImei_External
            '
            Me.txtRec_EsnImei_External.BackColor = System.Drawing.Color.White
            Me.txtRec_EsnImei_External.Enabled = False
            Me.txtRec_EsnImei_External.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRec_EsnImei_External.Location = New System.Drawing.Point(72, 72)
            Me.txtRec_EsnImei_External.MaxLength = 25
            Me.txtRec_EsnImei_External.Name = "txtRec_EsnImei_External"
            Me.txtRec_EsnImei_External.Size = New System.Drawing.Size(176, 21)
            Me.txtRec_EsnImei_External.TabIndex = 3
            Me.txtRec_EsnImei_External.Text = ""
            '
            'txtFile_EsnImei
            '
            Me.txtFile_EsnImei.BackColor = System.Drawing.Color.White
            Me.txtFile_EsnImei.Enabled = False
            Me.txtFile_EsnImei.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFile_EsnImei.Location = New System.Drawing.Point(72, 96)
            Me.txtFile_EsnImei.MaxLength = 25
            Me.txtFile_EsnImei.Name = "txtFile_EsnImei"
            Me.txtFile_EsnImei.Size = New System.Drawing.Size(176, 21)
            Me.txtFile_EsnImei.TabIndex = 115
            Me.txtFile_EsnImei.TabStop = False
            Me.txtFile_EsnImei.Text = ""
            '
            'lblReceiptQty
            '
            Me.lblReceiptQty.BackColor = System.Drawing.Color.Black
            Me.lblReceiptQty.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReceiptQty.ForeColor = System.Drawing.Color.Lime
            Me.lblReceiptQty.Location = New System.Drawing.Point(208, 128)
            Me.lblReceiptQty.Name = "lblReceiptQty"
            Me.lblReceiptQty.Size = New System.Drawing.Size(72, 40)
            Me.lblReceiptQty.TabIndex = 113
            Me.lblReceiptQty.Text = "0"
            Me.lblReceiptQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Black
            Me.Label9.Location = New System.Drawing.Point(208, 104)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(72, 21)
            Me.Label9.TabIndex = 112
            Me.Label9.Text = "Receipt Qty"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnR_GetData
            '
            Me.btnR_GetData.BackColor = System.Drawing.Color.DarkGreen
            Me.btnR_GetData.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnR_GetData.ForeColor = System.Drawing.Color.White
            Me.btnR_GetData.Location = New System.Drawing.Point(624, 86)
            Me.btnR_GetData.Name = "btnR_GetData"
            Me.btnR_GetData.Size = New System.Drawing.Size(88, 21)
            Me.btnR_GetData.TabIndex = 7
            Me.btnR_GetData.TabStop = False
            Me.btnR_GetData.Text = "Get Data"
            '
            'tpHoldItems
            '
            Me.tpHoldItems.BackColor = System.Drawing.Color.SteelBlue
            Me.tpHoldItems.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgH_Tote, Me.Label2, Me.btnH_AssignSelItemToTote, Me.btnH_Refresh, Me.dbgHoldItems})
            Me.tpHoldItems.Location = New System.Drawing.Point(4, 22)
            Me.tpHoldItems.Name = "tpHoldItems"
            Me.tpHoldItems.Size = New System.Drawing.Size(1008, 478)
            Me.tpHoldItems.TabIndex = 3
            Me.tpHoldItems.Text = "Hold"
            '
            'dbgH_Tote
            '
            Me.dbgH_Tote.AllowUpdate = False
            Me.dbgH_Tote.AlternatingRows = True
            Me.dbgH_Tote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgH_Tote.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgH_Tote.Images.Add(CType(resources.GetObject("resource.Images26"), System.Drawing.Bitmap))
            Me.dbgH_Tote.Location = New System.Drawing.Point(48, 8)
            Me.dbgH_Tote.Name = "dbgH_Tote"
            Me.dbgH_Tote.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgH_Tote.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgH_Tote.PreviewInfo.ZoomFactor = 75
            Me.dbgH_Tote.Size = New System.Drawing.Size(560, 32)
            Me.dbgH_Tote.TabIndex = 120
            Me.dbgH_Tote.TabStop = False
            Me.dbgH_Tote.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
            "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
            "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
            "le11{}OddRow{BackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:" & _
            "HighlightText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Sty" & _
            "le21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;" & _
            "}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised" & _
            ",,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft S" & _
            "ans Serif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Sty" & _
            "le8{}Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Cente" & _
            "r;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1Tru" & _
            "eDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordS" & _
            "electorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
            "oup=""1""><Height>30</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorS" & _
            "tyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" />" & _
            "<FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect" & _
            ">0, 0, 558, 30</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Border" & _
            "Style></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=" & _
            """Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foo" & _
            "ter"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inacti" & _
            "ve"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" " & _
            "/><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow""" & _
            " /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelect" & _
            "or"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group""" & _
            " /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Non" & _
            "e</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 558, 30</" & _
            "ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle " & _
            "parent="""" me=""Style21"" /></Blob>"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(32, 21)
            Me.Label2.TabIndex = 119
            Me.Label2.Text = "Tote ID: "
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnH_AssignSelItemToTote
            '
            Me.btnH_AssignSelItemToTote.BackColor = System.Drawing.Color.DarkGreen
            Me.btnH_AssignSelItemToTote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnH_AssignSelItemToTote.ForeColor = System.Drawing.Color.White
            Me.btnH_AssignSelItemToTote.Location = New System.Drawing.Point(784, 16)
            Me.btnH_AssignSelItemToTote.Name = "btnH_AssignSelItemToTote"
            Me.btnH_AssignSelItemToTote.Size = New System.Drawing.Size(200, 23)
            Me.btnH_AssignSelItemToTote.TabIndex = 118
            Me.btnH_AssignSelItemToTote.TabStop = False
            Me.btnH_AssignSelItemToTote.Text = "Assign Selected Device to A Tote"
            '
            'btnH_Refresh
            '
            Me.btnH_Refresh.BackColor = System.Drawing.Color.SteelBlue
            Me.btnH_Refresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnH_Refresh.ForeColor = System.Drawing.Color.White
            Me.btnH_Refresh.Location = New System.Drawing.Point(656, 16)
            Me.btnH_Refresh.Name = "btnH_Refresh"
            Me.btnH_Refresh.Size = New System.Drawing.Size(104, 23)
            Me.btnH_Refresh.TabIndex = 117
            Me.btnH_Refresh.Text = "Refresh List"
            '
            'dbgHoldItems
            '
            Me.dbgHoldItems.AllowUpdate = False
            Me.dbgHoldItems.AlternatingRows = True
            Me.dbgHoldItems.FilterBar = True
            Me.dbgHoldItems.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgHoldItems.Images.Add(CType(resources.GetObject("resource.Images27"), System.Drawing.Bitmap))
            Me.dbgHoldItems.Location = New System.Drawing.Point(16, 56)
            Me.dbgHoldItems.Name = "dbgHoldItems"
            Me.dbgHoldItems.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgHoldItems.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgHoldItems.PreviewInfo.ZoomFactor = 75
            Me.dbgHoldItems.Size = New System.Drawing.Size(968, 392)
            Me.dbgHoldItems.TabIndex = 115
            Me.dbgHoldItems.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "88</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 964, 388<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 964, 388</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'tpOpenTotes
            '
            Me.tpOpenTotes.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpOpenTotes.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnOT_AssignItemToTote, Me.btnOT_Refresh, Me.btnOT_CloseSelectedTote, Me.dbgOT_Totes})
            Me.tpOpenTotes.Location = New System.Drawing.Point(4, 22)
            Me.tpOpenTotes.Name = "tpOpenTotes"
            Me.tpOpenTotes.Size = New System.Drawing.Size(1008, 478)
            Me.tpOpenTotes.TabIndex = 1
            Me.tpOpenTotes.Text = "Open Totes"
            '
            'btnOT_AssignItemToTote
            '
            Me.btnOT_AssignItemToTote.BackColor = System.Drawing.Color.DarkGreen
            Me.btnOT_AssignItemToTote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOT_AssignItemToTote.ForeColor = System.Drawing.Color.White
            Me.btnOT_AssignItemToTote.Location = New System.Drawing.Point(496, 16)
            Me.btnOT_AssignItemToTote.Name = "btnOT_AssignItemToTote"
            Me.btnOT_AssignItemToTote.Size = New System.Drawing.Size(240, 23)
            Me.btnOT_AssignItemToTote.TabIndex = 119
            Me.btnOT_AssignItemToTote.TabStop = False
            Me.btnOT_AssignItemToTote.Text = "Assign Device to Selected Tote"
            '
            'btnOT_Refresh
            '
            Me.btnOT_Refresh.BackColor = System.Drawing.Color.SteelBlue
            Me.btnOT_Refresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOT_Refresh.ForeColor = System.Drawing.Color.White
            Me.btnOT_Refresh.Location = New System.Drawing.Point(8, 16)
            Me.btnOT_Refresh.Name = "btnOT_Refresh"
            Me.btnOT_Refresh.Size = New System.Drawing.Size(128, 23)
            Me.btnOT_Refresh.TabIndex = 114
            Me.btnOT_Refresh.Text = "Refresh List"
            '
            'btnOT_CloseSelectedTote
            '
            Me.btnOT_CloseSelectedTote.BackColor = System.Drawing.Color.DarkGreen
            Me.btnOT_CloseSelectedTote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOT_CloseSelectedTote.ForeColor = System.Drawing.Color.White
            Me.btnOT_CloseSelectedTote.Location = New System.Drawing.Point(160, 16)
            Me.btnOT_CloseSelectedTote.Name = "btnOT_CloseSelectedTote"
            Me.btnOT_CloseSelectedTote.Size = New System.Drawing.Size(136, 23)
            Me.btnOT_CloseSelectedTote.TabIndex = 113
            Me.btnOT_CloseSelectedTote.TabStop = False
            Me.btnOT_CloseSelectedTote.Text = "Close Selected Tote"
            '
            'dbgOT_Totes
            '
            Me.dbgOT_Totes.AllowUpdate = False
            Me.dbgOT_Totes.AlternatingRows = True
            Me.dbgOT_Totes.FilterBar = True
            Me.dbgOT_Totes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgOT_Totes.Images.Add(CType(resources.GetObject("resource.Images28"), System.Drawing.Bitmap))
            Me.dbgOT_Totes.Location = New System.Drawing.Point(8, 48)
            Me.dbgOT_Totes.Name = "dbgOT_Totes"
            Me.dbgOT_Totes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgOT_Totes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgOT_Totes.PreviewInfo.ZoomFactor = 75
            Me.dbgOT_Totes.Size = New System.Drawing.Size(928, 352)
            Me.dbgOT_Totes.TabIndex = 5
            Me.dbgOT_Totes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "48</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 924, 348<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 924, 348</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'tpOpenOrders
            '
            Me.tpOpenOrders.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpOpenOrders.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnOO_Refresh, Me.btnOO_CloseOrder, Me.dbgOB_OpenOrders})
            Me.tpOpenOrders.Location = New System.Drawing.Point(4, 22)
            Me.tpOpenOrders.Name = "tpOpenOrders"
            Me.tpOpenOrders.Size = New System.Drawing.Size(1008, 478)
            Me.tpOpenOrders.TabIndex = 2
            Me.tpOpenOrders.Text = "Open Orders"
            '
            'btnOO_Refresh
            '
            Me.btnOO_Refresh.BackColor = System.Drawing.Color.SteelBlue
            Me.btnOO_Refresh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOO_Refresh.ForeColor = System.Drawing.Color.White
            Me.btnOO_Refresh.Location = New System.Drawing.Point(8, 16)
            Me.btnOO_Refresh.Name = "btnOO_Refresh"
            Me.btnOO_Refresh.Size = New System.Drawing.Size(128, 23)
            Me.btnOO_Refresh.TabIndex = 116
            Me.btnOO_Refresh.Text = "Refresh List"
            '
            'btnOO_CloseOrder
            '
            Me.btnOO_CloseOrder.BackColor = System.Drawing.Color.DarkGreen
            Me.btnOO_CloseOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOO_CloseOrder.ForeColor = System.Drawing.Color.White
            Me.btnOO_CloseOrder.Location = New System.Drawing.Point(160, 16)
            Me.btnOO_CloseOrder.Name = "btnOO_CloseOrder"
            Me.btnOO_CloseOrder.Size = New System.Drawing.Size(136, 23)
            Me.btnOO_CloseOrder.TabIndex = 115
            Me.btnOO_CloseOrder.TabStop = False
            Me.btnOO_CloseOrder.Text = "Close Selected Order"
            '
            'dbgOB_OpenOrders
            '
            Me.dbgOB_OpenOrders.AllowUpdate = False
            Me.dbgOB_OpenOrders.AlternatingRows = True
            Me.dbgOB_OpenOrders.FilterBar = True
            Me.dbgOB_OpenOrders.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgOB_OpenOrders.Images.Add(CType(resources.GetObject("resource.Images29"), System.Drawing.Bitmap))
            Me.dbgOB_OpenOrders.Location = New System.Drawing.Point(8, 48)
            Me.dbgOB_OpenOrders.Name = "dbgOB_OpenOrders"
            Me.dbgOB_OpenOrders.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgOB_OpenOrders.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgOB_OpenOrders.PreviewInfo.ZoomFactor = 75
            Me.dbgOB_OpenOrders.Size = New System.Drawing.Size(592, 384)
            Me.dbgOB_OpenOrders.TabIndex = 6
            Me.dbgOB_OpenOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "80</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 588, 380<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 588, 380</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'chkEsnImeiTampered
            '
            Me.chkEsnImeiTampered.BackColor = System.Drawing.Color.LightSteelBlue
            Me.chkEsnImeiTampered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkEsnImeiTampered.ForeColor = System.Drawing.Color.Black
            Me.chkEsnImeiTampered.Location = New System.Drawing.Point(16, 21)
            Me.chkEsnImeiTampered.Name = "chkEsnImeiTampered"
            Me.chkEsnImeiTampered.Size = New System.Drawing.Size(80, 16)
            Me.chkEsnImeiTampered.TabIndex = 0
            Me.chkEsnImeiTampered.Text = "Tampered"
            '
            'frmMobilio_ItemRec_Triage_Tech
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1032, 526)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmMobilio_ItemRec_Triage_Tech"
            Me.Text = "frmMobilio_ItemRec_Triage_Tech.vb"
            CType(Me.cboFile_BatteryPresent, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_BatteryDoorPresent, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_Carrier, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_Color, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_Model, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_OEM, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_FindMyiPhone, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_Memory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_CarrLockUnLock, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_Condition, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_DataWip, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbRecData.ResumeLayout(False)
            CType(Me.cboRec_EsnImeiChecked, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboFile_EsnImeiChecked, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_Condition, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_CarrLockUnLock, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_Memory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_FindMyiPhone, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_Technology, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_BatteryPresent, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_BatteryDoorPresent, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_Carrier, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_Color, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_Model, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboRec_OEM, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpItemRecTech.ResumeLayout(False)
            CType(Me.dbgTote, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbEsnImei.ResumeLayout(False)
            Me.tpHoldItems.ResumeLayout(False)
            CType(Me.dbgH_Tote, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgHoldItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpOpenTotes.ResumeLayout(False)
            CType(Me.dbgOT_Totes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpOpenOrders.ResumeLayout(False)
            CType(Me.dbgOB_OpenOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Hold Items"

        '***********************************************************************************************************************************
        Private Sub tpHoldItems_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpHoldItems.VisibleChanged
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If tpHoldItems.Visible = True Then
                    btnH_Refresh_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpHoldItems_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnH_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnH_Refresh.Click
            Try
                LoadHoldItems() : Me.LoadOpenToteByUserWorkStation(Me.dbgH_Tote)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnH_Refresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub LoadHoldItems()
            Dim dt As DataTable
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                dt = Me._objMRec.GetHoldItems(Me._strPCName, Me._booSeeAllHold)
                With Me.dbgHoldItems
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                End With
            Catch ex As Exception
                Throw ex
            Finally
                dbgc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnH_AssignSelItemToTote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnH_AssignSelItemToTote.Click
            Dim i As Integer = 0, iToteID As Integer, iDeviceID As Integer

            Try
                If Me.dbgHoldItems.RowCount > 0 AndAlso Me.dbgHoldItems.Columns.Count > 0 AndAlso CInt(Me.dbgHoldItems.Columns("Device ID").CellValue(Me.dbgHoldItems.Row)) > 0 Then
                    iDeviceID = CInt(Me.dbgHoldItems.Columns("Device ID").CellValue(Me.dbgHoldItems.Row))

                    If MessageBox.Show("Are you sure you want to assign device id '" & iDeviceID & "' to tote?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                    iToteID = Me._objMRec.CreateToteID(Me._iUserID, Me._strPCName)
                    If Me.AssigningItemToTote(iDeviceID, iToteID, True) Then
                        btnH_Refresh_Click(Nothing, Nothing)
                    End If
                Else
                    MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnH_AssignSelItemToTote_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Public Function AssigningItemToTote(ByVal iDeviceID As Integer, ByVal iToteID As Integer, ByVal booHoldUnitOnly As Boolean) As Boolean
            Dim dt As DataTable
            Dim booUpdStatusToNewStatus As Boolean = False, booReturnVal As Boolean = False
            Dim i As Integer, iInitialActionID As Integer = 0
            Dim strSKU As String = ""

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                dt = Me._objMRec.GetDeviceData(iDeviceID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Device does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Device existed more than one. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf IsDBNull(dt.Rows(0)("ReceivedDate")) Then
                    MessageBox.Show("Device has not been through item received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("ShippedDate")) AndAlso dt.Rows(0)("ShippedDate").ToString.Length > 0 Then
                    MessageBox.Show("Device has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("mb_Tote_ID")) > 0 Then
                    MessageBox.Show("Device belongs to tote id " & dt.Rows(0)("mb_Tote_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("mb_MP_ID")) > 0 Then
                    MessageBox.Show("Device belongs to master pack id " & dt.Rows(0)("mb_MP_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("action_id")) = 0 Then
                    MessageBox.Show("Device missing disposition id. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf booHoldUnitOnly AndAlso dt.Rows(0)("Status").ToString.Trim.ToLower <> "hold" Then
                    MessageBox.Show("Device is not on hold.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("Status").ToString.Trim.ToLower = "hold" AndAlso CInt(dt.Rows(0)("response_action_id")) = 0 Then
                    MessageBox.Show("Device is on hold waiting for response from customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If dt.Rows(0)("RecSku").ToString.Trim.Length = 0 AndAlso dt.Rows(0)("NewStatus").ToString.Trim.ToLower <> "return" Then
                        strSKU = Me._objMRec.GetSKU(CInt(dt.Rows(0)("RecOemID")), CInt(dt.Rows(0)("RecModelID")), CInt(dt.Rows(0)("RecCarrierID")), CInt(dt.Rows(0)("RecColorID")) _
                                                   , CInt(dt.Rows(0)("RecMemID")), CInt(dt.Rows(0)("RecConditionID")), CInt(dt.Rows(0)("RecFindMyIphone")), CInt(dt.Rows(0)("RecCarrierLockID")))

                        If strSKU.Trim.Length = 0 Then Throw New Exception("Sku is missing.")
                    End If

                    If dt.Rows(0)("Status").ToString.Trim.ToLower = "hold" Then
                        booUpdStatusToNewStatus = True
                        If CInt(dt.Rows(0)("initial_action_id")) = 0 Then iInitialActionID = CInt(dt.Rows(0)("action_id"))
                    End If

                    i = Me._objMRec.AddItemToTote(CInt(dt.Rows(0)("mb_DeviceID")), iToteID, iInitialActionID, booUpdStatusToNewStatus, strSKU)
                    If i = 0 Then
                        MessageBox.Show("System has failed to add item into tote.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        i = Me._objMRec.SetOrderToBeReadyForReturn(CInt(dt.Rows(0)("mb_OrderID_Inbound")))
                        booReturnVal = True
                        btnH_Refresh_Click(Nothing, Nothing)
                    End If
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************

#End Region

#Region "Open Orders"

        '***********************************************************************************************************************************
        Private Sub tpOpenOrders_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpOpenOrders.VisibleChanged
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If tpOpenOrders.Visible = True Then LoadOpenOrders()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpOpenOrders_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnOO_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOO_Refresh.Click
            Try
                LoadOpenOrders()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnOO_Refresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub LoadOpenOrders()
            Dim dt As DataTable
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                dt = Me._objMRec.GetOpenItemReceiveOrders(Me._iMenuCustID)
                With Me.dbgOB_OpenOrders
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc

                    .Splits(0).DisplayColumns("mb_OrderID").Visible = False
                End With
            Catch ex As Exception
                Throw ex
            Finally
                dbgc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnOO_CloseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOO_CloseOrder.Click
            Dim i As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                With Me.dbgOB_OpenOrders
                    If .RowCount > 0 AndAlso .Columns.Count > 0 AndAlso CInt(.Columns("mb_OrderID").CellValue(.Row)) > 0 Then
                        If MessageBox.Show("Are you sure you want to close order '" & .Columns("mb_OrderID").CellValue(.Row) & "'?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                        i = Me._objMRec.CloseItemReceiveOrder(CInt(.Columns("mb_OrderID").CellValue(.Row)), Me._iUserID)
                        If i > 0 Then
                            Me.LoadOpenOrders()
                        End If
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnOO_CloseOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************

#End Region

#Region "Open Totes"

        '***********************************************************************************************************************************
        Private Sub tpOpenTotes_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpOpenTotes.VisibleChanged
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If tpOpenTotes.Visible = True Then LoadOpenTotes()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpOpenTotes_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnOT_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOT_Refresh.Click
            Try
                LoadOpenTotes()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnOT_Refresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub LoadOpenTotes()
            Dim dt As DataTable
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                dt = Me._objMRec.GetOpenTotes()
                With Me.dbgOT_Totes
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                End With
            Catch ex As Exception
                Throw ex
            Finally
                dbgc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnOT_CloseSelectedTote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOT_CloseSelectedTote.Click
            Dim i As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                With Me.dbgOT_Totes
                    If .RowCount > 0 AndAlso .Columns.Count > 0 AndAlso CInt(.Columns("Tote ID").CellValue(.Row)) > 0 Then
                        If MessageBox.Show("Are you sure you want to close Tote ID '" & .Columns("Tote ID").CellValue(.Row) & "'?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                        i = Me._objMRec.CloseTote(CInt(.Columns("Tote ID").CellValue(.Row)), Me._iUserID)
                        If i > 0 Then
                            Me.LoadOpenTotes()
                        End If
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnOT_CloseSelectedTote_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnOT_AssignItemToTote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOT_AssignItemToTote.Click
            Dim i As Integer, iToteID As Integer
            Dim dt As DataTable
            Dim strDeviceID As String

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                With Me.dbgOT_Totes
                    If .RowCount > 0 AndAlso .Columns.Count > 0 AndAlso CInt(.Columns("Tote ID").CellValue(.Row)) > 0 Then
                        strDeviceID = InputBox("Please enter device id:").Trim
                        iToteID = CInt(.Columns("Tote ID").CellValue(.Row))

                        If strDeviceID.Trim.Length = 0 Then
                            ' MessageBox.Show("You must enter device id.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        Else
                            dt = Me._objMRec.GetToteInfo(iToteID)
                            If dt.Rows.Count = 0 Then
                                MessageBox.Show("Tote ID " & iToteID & " does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf dt.Rows.Count > 1 Then
                                MessageBox.Show("Tote ID " & iToteID & " existed more than one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf dt.Rows(0)("Closed").ToString.Trim = "1" Then
                                MessageBox.Show("Tote ID " & iToteID & " is closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf Not IsDBNull(dt.Rows(0)("ClosedDate")) Then
                                MessageBox.Show("Tote ID " & iToteID & " is closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf Me.AssigningItemToTote(CInt(strDeviceID), CInt(dt.Rows(0)("mb_Tote_ID")), False) Then
                                Me.LoadOpenTotes()
                            End If
                        End If
                    Else
                        MessageBox.Show("No open tote.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnOT_AssignItemtoTote_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************

#End Region

#Region "Item Rec/Tech"

        '***********************************************************************************************************************************
        Private Sub frmMobilio_ItemRec_Triage_Tech_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                If Core.ApplicationUser.GetPermission("Mobilio-SeeAllHoldItems") > 0 Then _booSeeAllHold = True
                If Core.ApplicationUser.GetPermission("Mobilio-SelRecordToRec") > 0 Then _booAllowSelRecordToRec = True

                If Me._booSeeAllHold Then btnOT_AssignItemToTote.Visible = True

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                _dtAction = Generic.GetCodesDetailByMasterCode(False, 64)
                LoadOpenToteByUserWorkStation(Me.dbgTote)
                LoadDataToBeSelect()
                PSS.Core.Highlight.SetHighLight(Me)

                Me.Enabled = True : Me.txtDeviceID.SelectAll() : Me.txtDeviceID.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmMobilio_ItemRec_Triage_Tech_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub LoadOpenToteByUserWorkStation(ByRef dgbCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
            Dim dt As DataTable
            Dim i As Integer

            Try
                dt = Me._objMRec.GetOpenTotes(Me._strPCName)
                If dt.Rows.Count > 1 Then
                    MessageBox.Show("There are more than one open tote for this station. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = False : Exit Sub
                Else
                    With dgbCtrl
                        .DataSource = Nothing
                        .DataSource = dt.DefaultView

                        For i = 0 To .Columns.Count - 1
                            .Splits(0).DisplayColumns(i).Locked = True
                            .Splits(0).DisplayColumns(i).AutoSize()
                        Next i
                    End With
                End If

                Me.Enabled = True
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub LoadDataToBeSelect()
            Dim dt1, dt2 As DataTable

            Try
                _booLoadData = True
                Me.Enabled = False : Cursor.Current = Cursors.Default
                '***********************************************
                '1: OEM
                '***********************************************
                dt1 = Generic.GetCodesDetailByMasterCode(True, 68, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_OEM, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_OEM.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_OEM, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_OEM.SelectedValue = 0

                '***********************************************
                '2: Model
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 67, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_Model, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_Model.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_Model, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_Model.SelectedValue = 0

                '***********************************************
                '3: Battery Door Present
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 72, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_BatteryDoorPresent, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_BatteryDoorPresent.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_BatteryDoorPresent, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_BatteryDoorPresent.SelectedValue = 0

                '***********************************************
                '4: Battery Present
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 73, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_BatteryPresent, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_BatteryPresent.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_BatteryPresent, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_BatteryPresent.SelectedValue = 0

                '***********************************************
                '5: Color
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 69, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_Color, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_Color.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_Color, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_Color.SelectedValue = 0

                '***********************************************
                '6: Find iPhone
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 74, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_FindMyiPhone, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_FindMyiPhone.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_FindMyiPhone, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_FindMyiPhone.SelectedValue = 0

                '***********************************************
                '7: Carrier
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 65, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_Carrier, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_Carrier.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_Carrier, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_Carrier.SelectedValue = 0

                '***********************************************
                '8: Technology
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 75)
                Misc.PopulateC1DropDownList(Me.cboRec_Technology, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboRec_Technology.SelectedValue = 0

                '***********************************************
                '9: Memory
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 66, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_Memory, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_Memory.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_Memory, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_Memory.SelectedValue = 0

                '***********************************************
                '10: Carrier Lock/UnLock
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 70, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_CarrLockUnLock, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_CarrLockUnLock.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_CarrLockUnLock, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_CarrLockUnLock.SelectedValue = 0

                '***********************************************
                '11: Condition
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 63, "DCode_LDesc")
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_Condition, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_Condition.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_Condition, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_Condition.SelectedValue = 0

                '***********************************************
                '12: Data Wipe
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 76, "DCode_LDesc")
                Misc.PopulateC1DropDownList(Me.cboRec_DataWip, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboRec_DataWip.SelectedValue = 0

                '***********************************************
                '13: ESN/IMEI Checked
                '***********************************************
                dt1 = Nothing : dt2 = Nothing
                dt1 = Generic.GetCodesDetailByMasterCode(True, 71)
                dt2 = New DataTable() : dt2 = dt1.Copy
                Misc.PopulateC1DropDownList(Me.cboFile_EsnImeiChecked, dt1, "DCode_LDesc", "DCode_ID")
                Me.cboFile_EsnImeiChecked.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboRec_EsnImeiChecked, dt2, "DCode_LDesc", "DCode_ID")
                Me.cboRec_EsnImeiChecked.SelectedValue = 0

            Catch ex As Exception
                Throw ex
            Finally
                _booLoadData = False
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt1) : Generic.DisposeDT(dt2)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
            Try
                ClearAllInputData()
                Me.txtDeviceID.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClearAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub ClearAllInputData()
            Try
                _iOrderID = 0 : _booNewItem = False : _iDiscpFlag = 0
                _strDiscpRptFieldName = "" : _iDiscpRptDispositionID = 0 : _iDeviceAsnID = 0

                Me.txtDeviceID.Text = "" : Me.txtDeviceID.Enabled = True : Me.chkPackageDamage.Checked = False

                Me.txtRec_EsnImei_External.Text = "" : Me.txtFile_EsnImei.Text = ""
                Me.txtRec_EsnImei_Internal.Text = "" : Me.txtRec_EsnImei_Internal.Enabled = True : Me.txtRec_EsnImei_Internal.BackColor = Color.White

                Me.chkEsnImeiTampered.Checked = False : Me.chkEsnImei_NoMatch.Checked = False

                Me.gbEsnImei.Enabled = True

                Me.lblOrderNo.Text = ""
                Me.lblOrderQty.Text = ""
                Me.lblShipmentQty.Text = ""
                Me.lblReceiptQty.Text = ""

                Me.ResetItemData(True, True)

                Me.dbgOrderDetails.DataSource = Nothing

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub cbos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRec_OEM.KeyUp, cboRec_Model.KeyUp, cboRec_BatteryDoorPresent.KeyUp, _
            cboRec_BatteryPresent.KeyUp, cboRec_Color.KeyUp, cboRec_FindMyiPhone.KeyUp, cboRec_Carrier.KeyUp, cboRec_Carrier.KeyUp, cboRec_Technology.KeyUp, cboRec_Memory.KeyUp, _
            cboRec_CarrLockUnLock.KeyUp, cboRec_Condition.KeyUp, cboRec_DataWip.KeyUp

            Try
                If e.KeyCode = Keys.Enter Then
                    Select Case sender.name
                        Case "cboRec_OEM"
                            If cboRec_OEM.SelectedValue > 0 Then
                                cboRec_Model.SelectAll() : cboRec_Model.Focus()
                            End If
                        Case "cboRec_Model"
                            If cboRec_Model.SelectedValue > 0 Then
                                cboRec_BatteryDoorPresent.SelectAll() : cboRec_BatteryDoorPresent.Focus()
                            End If
                        Case "cboRec_BatteryDoorPresent"
                            If cboRec_BatteryDoorPresent.SelectedValue > 0 Then
                                cboRec_BatteryPresent.SelectAll() : cboRec_BatteryPresent.Focus()
                            End If
                        Case "cboRec_BatteryPresent"
                            If cboRec_BatteryPresent.SelectedValue > 0 Then
                                cboRec_Color.SelectAll() : cboRec_Color.Focus()
                            End If
                        Case "cboRec_Color"
                            If cboRec_Color.SelectedValue > 0 Then
                                If Me.cboRec_FindMyiPhone.Enabled = True Then
                                    cboRec_FindMyiPhone.SelectAll() : cboRec_FindMyiPhone.Focus()
                                Else
                                    cboRec_Carrier.SelectAll() : cboRec_Carrier.Focus()
                                End If
                            End If
                        Case "cboRec_FindMyiPhone"
                            If cboRec_FindMyiPhone.SelectedValue > 0 Then
                                cboRec_Carrier.SelectAll() : cboRec_Carrier.Focus()
                            End If
                        Case "cboRec_Carrier"
                            If cboRec_Carrier.SelectedValue > 0 Then
                                cboRec_Technology.SelectAll() : cboRec_Technology.Focus()
                            End If
                        Case "cboRec_Technology"
                            If cboRec_Technology.SelectedValue > 0 Then
                                cboRec_Memory.SelectAll() : cboRec_Memory.Focus()
                            End If
                        Case "cboRec_Memory"
                            If cboRec_Memory.SelectedValue > 0 Then
                                cboRec_CarrLockUnLock.SelectAll() : cboRec_CarrLockUnLock.Focus()
                            End If
                        Case "cboRec_CarrLockUnLock"
                            If cboRec_CarrLockUnLock.SelectedValue > 0 Then
                                cboRec_Condition.SelectAll() : cboRec_Condition.Focus()
                            End If
                        Case "cboRec_Condition"
                            If cboRec_Condition.SelectedValue > 0 Then
                                cboRec_DataWip.SelectAll() : cboRec_DataWip.Focus()
                            End If
                        Case "cboRec_DataWip"
                            'DO NOTHING
                    End Select
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub cboRec_OEM_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRec_OEM.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                If Me.cboRec_OEM.SelectedValue > 0 Then
                    If cboRec_OEM.Text.Trim.ToLower <> "apple" Then
                        Me.cboRec_FindMyiPhone.SelectedValue = 0 : Me.cboRec_FindMyiPhone.Enabled = False
                    Else
                        : Me.cboRec_FindMyiPhone.Enabled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboRec_OEM_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub cboRec_DataWip_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRec_DataWip.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                If Me.cboRec_DataWip.SelectedValue > 0 AndAlso Me.cboRec_DataWip.Text.Trim.ToLower = "fail" Then
                    Me.cboRec_Condition.SelectedValue = Me.cboRec_Condition.DataSource.Table.Select("DCode_LDesc = 'D-2'")(0)("DCode_ID")
                    cboRec_Condition.Enabled = False
                Else
                    cboRec_Condition.Enabled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboRec_DataWip_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub txtDeviceID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceID.KeyUp
            Dim strDeviceID As String = ""

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDeviceID.Text.Trim.Length > 0 Then
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        strDeviceID = Me.txtDeviceID.Text.Trim
                        Me.ClearAllInputData()
                        Me.txtDeviceID.Text = strDeviceID

                        If ProcessDeviceID(strDeviceID) = False Then
                            Me.txtDeviceID.SelectAll() : Me.txtDeviceID.Focus()
                        Else
                            LoadOrderDetail()
                            Me.txtDeviceID.Enabled = False
                            Me.chkEsnImei_NoMatch.Focus()
                        End If
                    End If 'has data
                End If 'enter key
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtDeviceID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Public Function ProcessDeviceID(ByVal strDeviceID As String) As Boolean
            Dim dt As DataTable

            Try
                ProcessDeviceID = False
                strDeviceID = Me.txtDeviceID.Text.Trim

                dt = Me._objMRec.GetDeviceData(strDeviceID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Device ID does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate device. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf CInt(dt.Rows(0)("closed")) = 0 Then
                    MessageBox.Show("Order has not completed at order receive screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("CompletedItemRecDate")) Then
                    MessageBox.Show("Order has been closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("ReceivedDate")) Then
                    MessageBox.Show("Device is received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("ShippedDate")) Then
                    MessageBox.Show("Device has been shepped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("mb_DeviceID")) AndAlso CInt(dt.Rows(0)("mb_DeviceID")) > 0 Then
                    MessageBox.Show("Device has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.txtDeviceID.Enabled = False
                    Me.lblOrderNo.Text = dt.Rows(0)("po_number").ToString.ToUpper
                    Me.lblOrderQty.Text = dt.Rows(0)("OrderQty").ToString
                    Me.lblShipmentQty.Text = dt.Rows(0)("ShipmentQty").ToString
                    _iOrderID = CInt(dt.Rows(0)("mb_OrderID_Inbound"))
                    Me.lblReceiptQty.Text = Me._objMRec.GetItemRecQty(_iOrderID)

                    If CInt(dt.Rows(0)("DamagedOnArrival")) = 1 Then Me.chkPackageDamage.Checked = True Else Me.chkPackageDamage.Checked = False

                    Return True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        Private Sub LoadOrderDetail()
            Dim dt As DataTable
            Dim i As Integer

            Try
                With Me.dbgOrderDetails
                    .DataSource = Nothing

                    If Me._iOrderID = 0 Then Throw New Exception("Can't define order id.")

                    dt = Me._objMRec.GetOrderDetails(Me._iOrderID)
                    .DataSource = dt.DefaultView

                    For i = 0 To .Columns.Count - 1
                        .Splits(0).DisplayColumns(i).Locked = True
                        .Splits(0).DisplayColumns(i).AutoSize()

                        Select Case .Columns(i).Caption
                            Case "mb_OrderID", "item_transaction_id", "item_transaction_type", "item_id", "action_id", "item_oem_id", "item_model_id" _
                            , "item_carrier_id", "item_findmyiphone_id", "item_carrier_lock_id", "item_condition_id", "item_memory_id", "item_color_id" _
                            , "item_esn_imei_check_id", "item_batterydoor_present_id", "item_battery_present_id"
                                .Splits(0).DisplayColumns(i).Visible = False
                        End Select
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub chkEsnImei_NoMatch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEsnImei_NoMatch.CheckedChanged
            Try
                If Me.chkEsnImei_NoMatch.Checked = True Then
                    Me.txtRec_EsnImei_External.Enabled = True
                    Me.txtRec_EsnImei_Internal.Focus()
                Else
                    Me.txtRec_EsnImei_External.Enabled = False
                    Me.txtRec_EsnImei_External.Text = Me.txtRec_EsnImei_Internal.Text.Trim
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "chkEsnImei_NoMatch_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnR_GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR_GetData.Click
            Dim booResult As Boolean

            Try
                If Me.txtRec_EsnImei_Internal.Text.Trim.Length = 0 Then
                    MessageBox.Show("Duplicate device asn. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    ResetItemData(True, True)
                    booResult = Me.PopulateAsnData(False)
                    If booResult Then
                        Me.cboRec_OEM.SelectAll() : Me.cboRec_OEM.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnR_GetData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub txtRec_ESN_IMEI_Internal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRec_EsnImei_Internal.KeyUp, txtRec_EsnImei_External.KeyUp
            Dim booResult As Boolean

            Try
                If e.KeyCode = Keys.Enter Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    Select Case sender.name
                        Case "txtRec_EsnImei_Internal"
                            If Me.txtRec_EsnImei_Internal.Text.Trim.Length > 0 Then
                                If Me.chkEsnImei_NoMatch.Checked = True Then
                                    Me.Enabled = True : Me.txtRec_EsnImei_External.SelectAll() : Me.txtRec_EsnImei_External.Focus()
                                Else
                                    ResetItemData(True, True)
                                    If booResult = Me.PopulateAsnData(False) Then
                                        Me.Enabled = True : Me.cboRec_OEM.SelectAll() : Me.cboRec_OEM.Focus()
                                    End If
                                End If
                            End If
                        Case "txtRec_EsnImei_External"
                            If Me.txtRec_EsnImei_External.Text.Trim.Length > 0 AndAlso Me.txtRec_EsnImei_Internal.Text.Trim.Length > 0 Then
                                ResetItemData(True, True)
                                If booResult = Me.PopulateAsnData(False) Then
                                    Me.Enabled = True : Me.cboRec_OEM.SelectAll() : Me.cboRec_OEM.Focus()
                                End If
                            End If
                    End Select
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtRec_ESN_IMEI_Internal_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Function PopulateAsnData(ByVal booDoValidateOnly As Boolean) As Boolean
            Dim dt As DataTable
            Dim strEsnImei As String = "", strDevAsnID As String = ""
            Dim booRetVal As Boolean = False
            Dim drDevAsn As DataRow

            Try
                _drDevAsn = Nothing : Generic.DisposeDT(Me._dtDiscpTemp)

                strEsnImei = Me.txtRec_EsnImei_Internal.Text.Trim.ToUpper

                '*******************************
                '1: validate user input
                '*******************************
                If Me._iOrderID = 0 Then
                    MessageBox.Show("System can't define order id.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Function
                ElseIf strEsnImei.Length = 0 Then
                    MessageBox.Show("Please enter either ESN/IMEI number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Function
                End If

                '*******************************
                '2: Get data base on user input
                '*******************************
                If booDoValidateOnly = False Then
                    dt = Me._objMRec.GetASNItem(_iOrderID, strEsnImei)
                    If dt.Rows.Count > 1 OrElse dt.Rows.Count = 0 Then 'Duplicate record & can't find record
                        If Me._booAllowSelRecordToRec = False Then
                            MessageBox.Show("You don't have permission to select record. Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If 'has permision to select record

                        If dt.Rows.Count = 0 AndAlso CInt(Me.lblShipmentQty.Text) = Me._objMRec.GetItemRecQty(_iOrderID) Then
                            MessageBox.Show("This is an extra item in order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me._booNewItem = True : booRetVal = True
                        Else
                            If dt.Rows.Count = 0 Then dt = Me._objMRec.GetASNItem(_iOrderID, )
                            drDevAsn = SelectAsnIDToRec(dt)
                            If IsNothing(drDevAsn) Then Return False
                            booRetVal = True : Me._booNewItem = False
                        End If

                        If Me.chkEsnImei_NoMatch.Checked = False Then Me.txtRec_EsnImei_External.Text = Me.txtRec_EsnImei_Internal.Text

                    Else 'Found record
                        booRetVal = True : Me._booNewItem = False
                        drDevAsn = dt.Rows(0)
                        Me._iDeviceAsnID = CInt(dt.Rows(0)("mb_AsnID"))
                    End If 'Asn data
                Else
                    If Me._booNewItem Then
                        booRetVal = True
                    Else
                        dt = Me._objMRec.GetASNItem(_iOrderID, )
                        drDevAsn = SelectAsnIDToRec(dt)
                        If IsNothing(drDevAsn) Then Return False Else booRetVal = True
                    End If
                End If

                If booRetVal AndAlso _booNewItem = False Then
                    If drDevAsn("item_discrepant_template_id").ToString.Trim.Length = 0 Then 'found record
                        MessageBox.Show("Discrepancy template is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(drDevAsn("mb_DeviceID")) AndAlso CInt(drDevAsn("mb_DeviceID")) > 0 Then
                        MessageBox.Show("Device has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf IsDBNull(drDevAsn("OrderRecDate")) Then
                        MessageBox.Show("Order has not completed order received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(drDevAsn("CompletedItemRecDate")) Then
                        MessageBox.Show("Order for this device has been completed. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me._dtDiscpTemp = Me._objMRec.GetDiscrepancyTemplate(drDevAsn("item_discrepant_template_id").ToString.Trim)

                        Me.cboFile_OEM.SelectedValue = drDevAsn("item_oem_id")
                        Me.cboFile_Model.SelectedValue = drDevAsn("item_model_id")
                        Me.cboFile_BatteryDoorPresent.SelectedValue = drDevAsn("item_batterydoor_present_id")
                        Me.cboFile_BatteryPresent.SelectedValue = drDevAsn("item_battery_present_id")
                        Me.cboFile_Color.SelectedValue = drDevAsn("item_color_id")
                        Me.cboFile_FindMyiPhone.SelectedValue = drDevAsn("item_findmyiphone_id")
                        Me.cboFile_Carrier.SelectedValue = drDevAsn("item_carrier_id")
                        Me.cboFile_Memory.SelectedValue = drDevAsn("item_memory_id")
                        Me.cboFile_CarrLockUnLock.SelectedValue = drDevAsn("item_carrier_lock_id")
                        Me.cboFile_Condition.SelectedValue = drDevAsn("item_condition_id")
                        Me.cboFile_EsnImeiChecked.SelectedValue = drDevAsn("item_esn_imei_check_id")

                        If booDoValidateOnly = False Then
                            Me.cboRec_OEM.SelectedValue = drDevAsn("item_oem_id")
                            Me.cboRec_Model.SelectedValue = drDevAsn("item_model_id")
                            Me.cboRec_BatteryDoorPresent.SelectedValue = drDevAsn("item_batterydoor_present_id")
                            Me.cboRec_BatteryPresent.SelectedValue = drDevAsn("item_battery_present_id")
                            Me.cboRec_Color.SelectedValue = drDevAsn("item_color_id")
                            Me.cboRec_FindMyiPhone.SelectedValue = drDevAsn("item_findmyiphone_id")
                            Me.cboRec_Carrier.SelectedValue = drDevAsn("item_carrier_id")
                            Me.cboRec_Memory.SelectedValue = drDevAsn("item_memory_id")
                            Me.cboRec_CarrLockUnLock.SelectedValue = drDevAsn("item_carrier_lock_id")
                            Me.cboRec_Condition.SelectedValue = drDevAsn("item_condition_id")
                            Me.cboRec_EsnImeiChecked.SelectedValue = drDevAsn("item_esn_imei_check_id")
                        End If 'populate controls

                        Me.txtFile_EsnImei.Text = drDevAsn("item_esn_imei")
                        If Me.chkEsnImei_NoMatch.Checked = False Then Me.txtRec_EsnImei_External.Text = Me.txtRec_EsnImei_Internal.Text

                        If Me.txtRec_EsnImei_Internal.Text.Trim.ToLower <> Me.txtFile_EsnImei.Text.Trim.ToLower Then Me.txtRec_EsnImei_Internal.BackColor = Color.Red Else Me.txtRec_EsnImei_Internal.BackColor = Color.White

                        Me.gbEsnImei.Enabled = False

                        Me._drDevAsn = drDevAsn
                    End If
                End If

                Return booRetVal
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : drDevAsn = Nothing
            End Try
        End Function

        '***********************************************************************************************************************************
        Private Function SelectAsnIDToRec(ByVal dt As DataTable) As DataRow
            Dim drDevAsn As DataRow = Nothing
            Dim strDevAsnID As String = ""

            Try
                If Me._iDeviceAsnID = 0 Then
                    strDevAsnID = InputBox("Enter record id:").Trim
                    If strDevAsnID.Trim.Length = 0 Then Exit Function 'user cancel
                Else
                    strDevAsnID = Me._iDeviceAsnID
                End If

                If dt.Select("mb_AsnID = " & strDevAsnID).Length = 0 Then
                    MessageBox.Show("Record id does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Function
                ElseIf dt.Select("mb_AsnID = " & strDevAsnID).Length > 1 Then
                    MessageBox.Show("Duplicate record id. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Function
                Else
                    drDevAsn = dt.Select("mb_AsnID = " & strDevAsnID)(0)
                    Me._iDeviceAsnID = CInt(strDevAsnID)
                End If 'find record base on input id

                Return drDevAsn
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***********************************************************************************************************************************
        Private Sub ResetItemData(ByVal booFile As Boolean, ByVal booRec As Boolean)
            Try
                If booFile Then
                    Me.cboFile_OEM.SelectedValue = 0
                    Me.cboFile_Model.SelectedValue = 0
                    Me.cboFile_BatteryDoorPresent.SelectedValue = 0
                    Me.cboFile_BatteryPresent.SelectedValue = 0
                    Me.cboFile_Color.SelectedValue = 0
                    Me.cboFile_FindMyiPhone.SelectedValue = 0
                    Me.cboFile_Carrier.SelectedValue = 0
                    Me.cboFile_Memory.SelectedValue = 0
                    Me.cboFile_CarrLockUnLock.SelectedValue = 0
                    Me.cboFile_Condition.SelectedValue = 0
                    Me.cboFile_EsnImeiChecked.SelectedValue = 0
                End If

                If booRec Then
                    Me.cboRec_OEM.SelectedValue = 0
                    Me.cboRec_Model.SelectedValue = 0
                    Me.cboRec_BatteryDoorPresent.SelectedValue = 0
                    Me.cboRec_BatteryPresent.SelectedValue = 0
                    Me.cboRec_Color.SelectedValue = 0
                    Me.cboRec_FindMyiPhone.SelectedValue = 0
                    Me.cboRec_Carrier.SelectedValue = 0
                    Me.cboRec_Technology.SelectedValue = 0
                    Me.cboRec_Memory.SelectedValue = 0
                    Me.cboRec_CarrLockUnLock.SelectedValue = 0
                    Me.cboRec_Condition.SelectedValue = 0
                    Me.cboRec_DataWip.SelectedValue = 0
                    Me.cboRec_EsnImeiChecked.SelectedValue = 0
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
            Dim strInEsnImei As String = "", strExEsnImei As String = "", strDispositionDesc As String = "", strSKU As String = ""
            Dim iOemID, iModelID, iTechnID, iCarrierID, iFindMyIphoneID, iEsnImeiTampered, iCarrierLockUnLocID, iCondID, iMemmoryID, iColorID As Integer
            Dim iEsnImeiCheckedID, iBattDoorPresentID, iBattPresentID, iDispositionID, iDataWip, iDiscrepFlag, iToteID, iAsnID As Integer
            Dim booSkipEval As Boolean = False
            Dim i As Integer

            Try
                If Me._booNewItem = False AndAlso (Me.cboFile_OEM.SelectedValue = 0 OrElse Me.cboFile_Model.SelectedValue = 0 OrElse Me.cboFile_Carrier.SelectedValue = 0) Then
                    MessageBox.Show("System can't define file data. Please click on get data button.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                lblDevDisposition.Text = "" : lblDevDisposition.Tag = 0 : _drDevAsn = Nothing : Generic.DisposeDT(Me._dtDiscpTemp)
                _iDiscpFlag = 0 : _strDiscpRptFieldName = "" : _iDiscpRptDispositionID = 0

                strInEsnImei = Me.txtRec_EsnImei_Internal.Text.Trim.ToUpper
                strExEsnImei = Me.txtRec_EsnImei_External.Text.Trim.ToUpper

                If Me.chkEsnImeiTampered.Checked = True Then iEsnImeiTampered = 1 Else iEsnImeiTampered = 0

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If ProcessDeviceID(Me.txtDeviceID.Text) = False Then
                    Exit Sub
                ElseIf PopulateAsnData(True) = False Then
                    Exit Sub
                ElseIf Me.CheckUserInput(strInEsnImei) = False Then
                    Exit Sub
                ElseIf CInt(Me.lblReceiptQty.Text) >= CInt(Me.lblShipmentQty.Text) Then
                    MessageBox.Show("Receipt quantity has exceeded shipment quantity. Please verify with your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '***********************************
                    '1: ESN/IMEI Check
                    '***********************************
                    VerifyEsnImei()
                    DefineDeviceDisposition("item_esn_imei_check", iDispositionID, strDispositionDesc, booSkipEval)
                    If Me.cboRec_EsnImeiChecked.SelectedValue = 0 Then
                        MessageBox.Show("Unable to determine ESN/IMEI checked.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    iEsnImeiCheckedID = Me.cboRec_EsnImeiChecked.SelectedValue

                    ''***********************************
                    ''3: Check user input
                    ''***********************************
                    'If booSkipEval = False AndAlso Me.CheckUserInput(strInEsn, strInImei) = False Then Exit Sub

                    '***********************************
                    '4: Check OEM
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("oem", Me.cboFile_OEM.SelectedValue, Me.cboRec_OEM.SelectedValue)
                            DefineDeviceDisposition("item_oem", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iOemID = Me.cboRec_OEM.SelectedValue
                    End If
                    '***********************************
                    '4: Check Model
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("model", Me.cboFile_Model.SelectedValue, Me.cboRec_Model.SelectedValue)
                            DefineDeviceDisposition("item_model", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iModelID = Me.cboRec_Model.SelectedValue
                    End If
                    ''***********************************
                    ''5: Check Technology
                    ''***********************************
                    'If booSkipEval = False Then
                    '    DefineDeviceDisposition("item_technology", iDispositionID, strDispositionDesc, booSkipEval)
                    iTechnID = Me.cboRec_Technology.SelectedValue
                    'End If
                    '***********************************
                    '6: Check Carrier
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("carrier", Me.cboFile_Carrier.SelectedValue, Me.cboRec_Carrier.SelectedValue)
                            DefineDeviceDisposition("item_carrier", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iCarrierID = Me.cboRec_Carrier.SelectedValue
                    End If
                    '***********************************
                    '7: Check Carrier Locl/Unlock
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("carrier_lock", Me.cboFile_CarrLockUnLock.SelectedValue, Me.cboRec_CarrLockUnLock.SelectedValue)
                            DefineDeviceDisposition("item_carrier_lock", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iCarrierLockUnLocID = Me.cboRec_CarrLockUnLock.SelectedValue
                    End If
                    '***********************************
                    '8: Find My iPhone
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("findmyiphone", Me.cboFile_FindMyiPhone.SelectedValue, Me.cboRec_FindMyiPhone.SelectedValue)
                            DefineDeviceDisposition("item_findmyiphone", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iFindMyIphoneID = Me.cboRec_FindMyiPhone.SelectedValue
                    End If

                    '***********************************
                    '9: Check Condition
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("condition", Me.cboFile_Condition.SelectedValue, Me.cboRec_Condition.SelectedValue)
                            DefineDeviceDisposition("item_condition", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iCondID = Me.cboRec_Condition.SelectedValue
                    End If

                    '***********************************
                    '10: Check Memmory
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("memory", Me.cboFile_Memory.SelectedValue, Me.cboRec_Memory.SelectedValue)
                            DefineDeviceDisposition("item_memory", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iMemmoryID = Me.cboRec_Memory.SelectedValue
                    End If
                    '***********************************
                    '11: Check Color
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("color", Me.cboFile_Color.SelectedValue, Me.cboRec_Color.SelectedValue)
                            DefineDeviceDisposition("item_color", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iColorID = Me.cboRec_Color.SelectedValue
                    End If
                    '***********************************
                    '12: Check Battery Door Present
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("batterydoor_present", Me.cboFile_BatteryDoorPresent.SelectedValue, Me.cboRec_BatteryDoorPresent.SelectedValue)
                            DefineDeviceDisposition("item_batterydoor_present", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iBattDoorPresentID = Me.cboRec_BatteryDoorPresent.SelectedValue
                    End If
                    '***********************************
                    '13: Check Battery Present
                    '***********************************
                    If booSkipEval = False Then
                        If Me._booNewItem = False Then
                            Me.VerifyDiscrepancyTemplate("battery_present", Me.cboFile_BatteryPresent.SelectedValue, Me.cboRec_BatteryPresent.SelectedValue)
                            DefineDeviceDisposition("item_battery_present", iDispositionID, strDispositionDesc, booSkipEval)
                        End If
                        iBattPresentID = Me.cboRec_BatteryPresent.SelectedValue
                    End If
                    '***********************************
                    '14: Check Data Wipe
                    '***********************************
                    If booSkipEval = False Then iDataWip = Me.cboRec_DataWip.SelectedValue
                    '***********************************

                    '***************************************************
                    '15: Get SKU & Validate ( Technology & condition)
                    '***************************************************
                    If Me.lblDevDisposition.Text.Trim.ToLower <> "return" Then
                        strSKU = Me._objMRec.GetSKU(iOemID, iModelID, iCarrierID, iColorID, iMemmoryID, iCondID, iFindMyIphoneID, iCarrierLockUnLocID)
                        If Me.lblDevDisposition.Text.Trim.ToLower = "process" AndAlso strSKU.Trim.Length = 0 Then Throw New Exception("System can't define SKU.") : Exit Sub

                        If Me.cboRec_Technology.SelectedValue = 0 Then
                            MessageBox.Show("Please select technology.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        ElseIf Me.cboRec_DataWip.SelectedValue = 0 Then
                            MessageBox.Show("Please select data wipe result.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    End If

                    '***************************************************
                    '16: Create Tote :LEAVE HOLD @ TECH TABLE
                    '***************************************************
                    If Me.lblDevDisposition.Text.Trim.ToLower = "hold" Then
                        iToteID = 0
                    Else
                        iToteID = Me._objMRec.CreateToteID(Me._iUserID, Me._strPCName)
                    End If

                    '***************************************************
                    '17: discrepancy flag
                    '***************************************************
                    If Me._booNewItem = False Then iAsnID = CInt(Me._drDevAsn("mb_AsnID")) Else Me._iDiscpFlag = 1

                    '***************************************************
                    '18: Write Data
                    '***************************************************
                    i = Me._objMRec.SaveItemReceiveData(Me._strPCName, Me._iUserID, Me._iOrderID, CInt(Me.lblShipmentQty.Text), iToteID, CInt(Me.txtDeviceID.Text), Me._iDiscpFlag _
                                    , iAsnID, strInEsnImei, strExEsnImei, iEsnImeiTampered, iOemID, iModelID _
                                    , iTechnID, iCarrierID, iFindMyIphoneID, iCarrierLockUnLocID, iCondID, iMemmoryID, iColorID, iEsnImeiCheckedID _
                                    , iBattDoorPresentID, iBattPresentID, iDispositionID, iDataWip, strSKU, Me._strDiscpRptFieldName, Me._iDiscpRptDispositionID)

                    If i > 0 Then
                        'Print Triage Label
                        Me._objMRec.PrintToteItemRecDeviceLabel(CInt(Me.txtDeviceID.Text))

                        LoadOpenToteByUserWorkStation(Me.dbgTote)

                        ClearAllInputData()
                        Me.Enabled = True : Me.txtDeviceID.Focus()
                    End If
                    '***************************************************
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Function VerifyDiscrepancyTemplate(ByVal strDiscpTempItem As String, ByVal iFileVal As Integer, ByVal iRecVal As Integer) As Boolean
            Dim dr() As DataRow
            Dim i, iActionID As Integer
            Dim booFoundMatch As Boolean = False
            Dim strAction As String = ""

            Try
                If iFileVal <> iRecVal Then
                    If Me._dtDiscpTemp.Select("Item = '" & strDiscpTempItem & "'").Length > 0 Then
                        dr = Me._dtDiscpTemp.Select("Item = '" & strDiscpTempItem & "' AND Desc_ID > 0")
                        For i = 0 To dr.Length - 1
                            If iRecVal = dr(i)("Desc_ID") Then
                                iActionID = dr(i)("Action_ID")
                                strAction = dr(i)("Action_Desc")
                                booFoundMatch = True : Exit For
                            End If
                        Next i

                        If booFoundMatch = False Then
                            dr = Me._dtDiscpTemp.Select("Item = '" & strDiscpTempItem & "' AND Desc_ID = 0") 'desc_id=0, action means "any"
                            If dr.Length > 1 Then
                                Throw New Exception("Discrepancy template " & _dtDiscpTemp.Rows(0)("discrepant_template_id") & " has more than one record of any. Can't be translated, please contact IT.")
                            ElseIf dr.Length = 0 Then
                                Throw New Exception("Discrepancy template " & _dtDiscpTemp.Rows(0)("discrepant_template_id") & " has nothing. Can't be translated, please contact IT.")
                            Else 'must be 1 record', action is "any",
                                iActionID = dr(0)("Action_ID")
                                strAction = dr(0)("Action_Desc")
                            End If
                        End If

                        'Only update if no disposition or disposition is process
                        If Me.lblDevDisposition.Text.Trim.Length = 0 OrElse Me.lblDevDisposition.Text.Trim.ToLower = "process" Then
                            Me.lblDevDisposition.Tag = iActionID
                            Me.lblDevDisposition.Text = strAction
                        End If

                    End If 'Template has criteria

                End If 'diff than file
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Private Sub VerifyEsnImei()
            Try
                If Me.chkEsnImeiTampered.Checked Then
                    Me.lblDevDisposition.Text = Me._dtAction.Select("DCode_LDesc = 'RETURN'")(0)("DCode_LDesc")
                    Me.lblDevDisposition.Tag = Me._dtAction.Select("DCode_LDesc = 'RETURN'")(0)("DCode_id")
                Else
                    If Me._booNewItem Then 'Does not Match PO
                        If Me.chkEsnImei_NoMatch.Checked = True Then
                            Me.lblDevDisposition.Text = Me._dtAction.Select("DCode_LDesc = 'RETURN'")(0)("DCode_LDesc")
                            Me.lblDevDisposition.Tag = Me._dtAction.Select("DCode_LDesc = 'RETURN'")(0)("DCode_id")
                        Else
                            Me.lblDevDisposition.Text = Me._dtAction.Select("DCode_LDesc = 'HOLD'")(0)("DCode_LDesc")
                            Me.lblDevDisposition.Tag = Me._dtAction.Select("DCode_LDesc = 'HOLD'")(0)("DCode_id")
                        End If
                    Else 'Match PO
                        If Me.chkEsnImei_NoMatch.Checked = True Then 'internal and external does not match
                            Me.lblDevDisposition.Text = Me._dtAction.Select("DCode_LDesc = 'HOLD'")(0)("DCode_LDesc")
                            Me.lblDevDisposition.Tag = Me._dtAction.Select("DCode_LDesc = 'HOLD'")(0)("DCode_id")
                        ElseIf Me.txtRec_EsnImei_Internal.Text.Trim.ToLower <> Me.txtFile_EsnImei.Text.Trim.ToLower Then  'internal and file does not match
                            Me.lblDevDisposition.Text = Me._dtAction.Select("DCode_LDesc = 'HOLD'")(0)("DCode_LDesc")
                            Me.lblDevDisposition.Tag = Me._dtAction.Select("DCode_LDesc = 'HOLD'")(0)("DCode_id")
                        Else
                            Me.lblDevDisposition.Text = Me._dtAction.Select("DCode_LDesc = 'PROCESS'")(0)("DCode_LDesc")
                            Me.lblDevDisposition.Tag = Me._dtAction.Select("DCode_LDesc = 'PROCESS'")(0)("DCode_id")
                        End If
                    End If
                End If

                If Me.lblDevDisposition.Text.Trim.ToUpper = "RETURN" OrElse Me.lblDevDisposition.Text.Trim.ToUpper = "HOLD" Then
                    Me.cboRec_EsnImeiChecked.SelectedValue = Me.cboRec_EsnImeiChecked.DataSource.Table.select("DCode_LDesc = 'FAIL'")(0)("DCode_ID")
                Else
                    Me.cboRec_EsnImeiChecked.SelectedValue = Me.cboRec_EsnImeiChecked.DataSource.Table.select("DCode_LDesc = 'PASS'")(0)("DCode_ID")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Function DefineDeviceDisposition(ByVal strInputType As String, ByRef iDispositionID As Integer, ByVal strDispositionDesc As String, ByRef booSkipEval As Boolean) As Boolean
            Try
                If Me.lblDevDisposition.Text = "RETURN" Then
                    Me._strDiscpRptFieldName = strInputType
                    _iDiscpRptDispositionID = Me.lblDevDisposition.Tag
                    iDispositionID = Me.lblDevDisposition.Tag
                    strDispositionDesc = Me.lblDevDisposition.Text
                    booSkipEval = True
                    Me._iDiscpFlag = 1
                ElseIf Me.lblDevDisposition.Text = "HOLD" Then
                    If Me._strDiscpRptFieldName.Trim.Length = 0 Then 'Pick the first HOLD
                        Me._strDiscpRptFieldName = strInputType
                        _iDiscpRptDispositionID = Me.lblDevDisposition.Tag
                        iDispositionID = Me.lblDevDisposition.Tag
                        strDispositionDesc = Me.lblDevDisposition.Text
                    End If
                    Me._iDiscpFlag = 1
                Else
                    If iDispositionID = 0 Then
                        iDispositionID = Me.lblDevDisposition.Tag
                        strDispositionDesc = Me.lblDevDisposition.Text
                    End If
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Private Function CheckUserInput(ByVal strInEsnImei As String) As Boolean
            Dim booRetVal As Boolean = False

            Try
                If Me.txtDeviceID.Text.Trim.Length = 0 Then
                    Exit Function
                ElseIf strInEsnImei.Length = 0 Then
                    MessageBox.Show("Please re-enter ESN/IMEI.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtRec_EsnImei_External.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter external ESN/IMEI.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._booNewItem = False AndAlso Me.txtFile_EsnImei.Text.Trim.Length = 0 Then
                    MessageBox.Show("Data is missing ESN/IMEI. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.chkEsnImei_NoMatch.Checked = True AndAlso Me.txtRec_EsnImei_Internal.Text.Trim.ToLower = Me.txtRec_EsnImei_External.Text.Trim.ToLower Then
                    MessageBox.Show("ESN/IMEI are the same. Please uncheck ESN/IMEI does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                ElseIf Me._booNewItem = False AndAlso IsNothing(Me._drDevAsn) Then
                    MessageBox.Show("System can't find record. Please re-enter ESN/IMEI.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._dtAction.Rows.Count = 0 Then
                    MessageBox.Show("Disposition list is empty. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._booNewItem = False AndAlso Me._dtDiscpTemp.Rows.Count = 0 Then
                    MessageBox.Show("Discrepancy template is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.chkEsnImeiTampered.Checked = False Then

                    If Me._booNewItem = False AndAlso Me.cboFile_OEM.SelectedValue = 0 Then
                        MessageBox.Show("OEM is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_Model.SelectedValue = 0 Then
                        MessageBox.Show("Model is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_BatteryDoorPresent.SelectedValue = 0 Then
                        MessageBox.Show("Battery door present is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_BatteryPresent.SelectedValue = 0 Then
                        MessageBox.Show("Battery present is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_Color.SelectedValue = 0 Then
                        MessageBox.Show("Color is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_OEM.Text.Trim.ToLower = "apple" AndAlso Me.cboFile_FindMyiPhone.SelectedValue = 0 Then
                        MessageBox.Show("Find my iPhone is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_Carrier.SelectedValue = 0 Then
                        MessageBox.Show("Carrier is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_Memory.SelectedValue = 0 Then
                        MessageBox.Show("Memory my iPhone is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_CarrLockUnLock.SelectedValue = 0 Then
                        MessageBox.Show("Carrier lock/unlock is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_Condition.SelectedValue = 0 Then
                        MessageBox.Show("Condition is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._booNewItem = False AndAlso Me.cboFile_EsnImeiChecked.SelectedValue = 0 Then
                        MessageBox.Show("ESN/IMEI check is missing in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    ElseIf Me.cboRec_OEM.SelectedValue = 0 Then
                        MessageBox.Show("Please select OEM.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.cboRec_Model.SelectedValue = 0 Then
                        MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.cboRec_BatteryDoorPresent.SelectedValue = 0 Then
                        MessageBox.Show("Please select battery door present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.cboRec_BatteryPresent.SelectedValue = 0 Then
                        MessageBox.Show("Please select battery present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.cboRec_Color.SelectedValue = 0 Then
                        MessageBox.Show("Please select color.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.cboRec_OEM.Text.Trim.ToLower = "apple" AndAlso Me.cboRec_FindMyiPhone.SelectedValue = 0 Then
                        MessageBox.Show("Please select find my iphone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.cboRec_Carrier.SelectedValue = 0 Then
                        MessageBox.Show("Please select carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.cboRec_Memory.SelectedValue = 0 Then
                        MessageBox.Show("Please select memory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.cboRec_CarrLockUnLock.SelectedValue = 0 Then
                        MessageBox.Show("Please select carrier lock/unlock.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.cboRec_Condition.SelectedValue = 0 Then
                        MessageBox.Show("Please select condition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        booRetVal = True
                    End If
                Else
                    booRetVal = True
                End If

                Return booRetVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************************************
        Private Sub btnCloseTote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseTote.Click
            Dim i As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                With Me.dbgTote
                    If .RowCount > 0 AndAlso .Columns.Count > 0 AndAlso CInt(.Columns("Tote ID").CellValue(.Row)) > 0 Then
                        If MessageBox.Show("Are you sure you want to close Tote ID '" & .Columns("Tote ID").CellValue(.Row) & "'?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                        i = Me._objMRec.CloseTote(CInt(.Columns("Tote ID").CellValue(.Row)), Me._iUserID)
                        If i > 0 Then Me.LoadOpenToteByUserWorkStation(Me.dbgTote)
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCloseTote_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnReprintItemLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintItemLabel.Click
            Dim iDeviceID As Integer
            Dim strDeviceID As String

            Try
                strDeviceID = InputBox("Enter Device ID):", "Reprint Item Receiving Label").Trim
                If strDeviceID.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Not IsNumeric(strDeviceID) Then
                    MessageBox.Show("Invalid Device ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iDeviceID = CInt(strDeviceID)
                    If iDeviceID > 0 Then
                        Me._objMRec.PrintToteItemRecDeviceLabel(iDeviceID)
                    Else
                        MessageBox.Show("Invalid Device ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnReprintDeviceLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************

#End Region

    End Class
End Namespace