Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports PSS.Data.Buisness

Public Class frmMessDBRNERManifest
    Inherits System.Windows.Forms.Form

    Private Const _iNER_BillcodeID As Integer = 89
    Private Const _iDBR_BillcodeID As Integer = 25
    Private _iDBRReasonDefaultID As Integer = 0
    Private _iNERReasonDefaultID As Integer = 0
    Private _objDBRManifest As Data.Buisness.DBRManifest
    Private _dtDBRUnits As DataTable
    Private _dtNERUnits As DataTable
    Private _strWork_Dt As String = Core.Global.ApplicationUser.Workdate
    Private _strTabPageTitle As String = ""
    Private _strDBRCustomer As String = ""
    Private _strNERCustomer As String = ""

    Private _objNameDBR() As String
    Private _objNameEnabledDBR() As Boolean
    Private _objNameNER() As String
    Private _objNameEnabledNER() As Boolean

    'Private _iMenuCustID As Integer
    'Private _iMenuLocID As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strTabPageTitle As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objDBRManifest = New Data.Buisness.DBRManifest()
        _strTabPageTitle = strTabPageTitle

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpDBR As System.Windows.Forms.TabPage
    Friend WithEvents btnRecreateDBRManifest As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents btnCreateDBRLot As System.Windows.Forms.Button
    Friend WithEvents rtfSNCount As System.Windows.Forms.RichTextBox
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lstNoneDBR As System.Windows.Forms.ListBox
    Friend WithEvents lblSN As System.Windows.Forms.Label
    Friend WithEvents lstSN As System.Windows.Forms.ListBox
    Friend WithEvents btnDeleteOne As System.Windows.Forms.Button
    Friend WithEvents lblNoneDBR As System.Windows.Forms.Label
    Friend WithEvents tpNER As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnNER_ReprintLotLabel As System.Windows.Forms.Button
    Friend WithEvents txtNER_SN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstNER_SNs As System.Windows.Forms.ListBox
    Friend WithEvents lblPageTitle As System.Windows.Forms.Label
    Friend WithEvents cboDBRReasons As C1.Win.C1List.C1Combo
    Friend WithEvents lblDBRNER As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cboNERReasons As C1.Win.C1List.C1Combo
    Friend WithEvents pnlReasonsDBR As System.Windows.Forms.Panel
    Friend WithEvents pnlReasonsNER As System.Windows.Forms.Panel
    Friend WithEvents lblDBR_SN As System.Windows.Forms.Label
    Friend WithEvents lblDBR_DeviceID As System.Windows.Forms.Label
    Friend WithEvents lblNER_DeviceID As System.Windows.Forms.Label
    Friend WithEvents lblNER_SN As System.Windows.Forms.Label
    Friend WithEvents btnDBR_Cancel As System.Windows.Forms.Button
    Friend WithEvents btnDBR_OK As System.Windows.Forms.Button
    Friend WithEvents btnNER_Cancel As System.Windows.Forms.Button
    Friend WithEvents btnNER_OK As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblAssignedDBRPallet As System.Windows.Forms.Label
    Friend WithEvents lstAssignedDBRPallet As System.Windows.Forms.ListBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCust_ID As System.Windows.Forms.Label
    Friend WithEvents lblLoc_ID As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnDBR_ReprintLotLabel As System.Windows.Forms.Button
    Friend WithEvents lblNERLoc_ID As System.Windows.Forms.Label
    Friend WithEvents lblNERCust_ID As System.Windows.Forms.Label
    Friend WithEvents lblNERCustomer As System.Windows.Forms.Label
    Friend WithEvents btnRecreateNERManifest As System.Windows.Forms.Button
    Friend WithEvents btnCreateNERLot As System.Windows.Forms.Button
    Friend WithEvents lblAssignedNERPallet As System.Windows.Forms.Label
    Friend WithEvents lblNoneNER As System.Windows.Forms.Label
    Friend WithEvents lstAssignedNERPallet As System.Windows.Forms.ListBox
    Friend WithEvents rtfNERSNCount As System.Windows.Forms.RichTextBox
    Friend WithEvents lstNoneNER As System.Windows.Forms.ListBox
    Friend WithEvents btnNERDeleteAll As System.Windows.Forms.Button
    Friend WithEvents btnNERDeleteOne As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessDBRNERManifest))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpDBR = New System.Windows.Forms.TabPage()
        Me.lblLoc_ID = New System.Windows.Forms.Label()
        Me.pnlReasonsDBR = New System.Windows.Forms.Panel()
        Me.lblDBR_DeviceID = New System.Windows.Forms.Label()
        Me.lblDBR_SN = New System.Windows.Forms.Label()
        Me.btnDBR_Cancel = New System.Windows.Forms.Button()
        Me.btnDBR_OK = New System.Windows.Forms.Button()
        Me.cboDBRReasons = New C1.Win.C1List.C1Combo()
        Me.lblDBRNER = New System.Windows.Forms.Label()
        Me.lblCust_ID = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.lblAssignedDBRPallet = New System.Windows.Forms.Label()
        Me.btnRecreateDBRManifest = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDBR_ReprintLotLabel = New System.Windows.Forms.Button()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.btnCreateDBRLot = New System.Windows.Forms.Button()
        Me.rtfSNCount = New System.Windows.Forms.RichTextBox()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lblSN = New System.Windows.Forms.Label()
        Me.lstSN = New System.Windows.Forms.ListBox()
        Me.btnDeleteOne = New System.Windows.Forms.Button()
        Me.lblNoneDBR = New System.Windows.Forms.Label()
        Me.lstAssignedDBRPallet = New System.Windows.Forms.ListBox()
        Me.lstNoneDBR = New System.Windows.Forms.ListBox()
        Me.tpNER = New System.Windows.Forms.TabPage()
        Me.lstNER_SNs = New System.Windows.Forms.ListBox()
        Me.pnlReasonsNER = New System.Windows.Forms.Panel()
        Me.lblNER_DeviceID = New System.Windows.Forms.Label()
        Me.lblNER_SN = New System.Windows.Forms.Label()
        Me.cboNERReasons = New C1.Win.C1List.C1Combo()
        Me.btnNER_Cancel = New System.Windows.Forms.Button()
        Me.btnNER_OK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAssignedNERPallet = New System.Windows.Forms.Label()
        Me.lblNoneNER = New System.Windows.Forms.Label()
        Me.btnRecreateNERManifest = New System.Windows.Forms.Button()
        Me.lblNERLoc_ID = New System.Windows.Forms.Label()
        Me.lblNERCust_ID = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblNERCustomer = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnNER_ReprintLotLabel = New System.Windows.Forms.Button()
        Me.btnNERDeleteAll = New System.Windows.Forms.Button()
        Me.btnCreateNERLot = New System.Windows.Forms.Button()
        Me.rtfNERSNCount = New System.Windows.Forms.RichTextBox()
        Me.txtNER_SN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnNERDeleteOne = New System.Windows.Forms.Button()
        Me.lstNoneNER = New System.Windows.Forms.ListBox()
        Me.lstAssignedNERPallet = New System.Windows.Forms.ListBox()
        Me.lblPageTitle = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tpDBR.SuspendLayout()
        Me.pnlReasonsDBR.SuspendLayout()
        CType(Me.cboDBRReasons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNER.SuspendLayout()
        Me.pnlReasonsNER.SuspendLayout()
        CType(Me.cboNERReasons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpDBR, Me.tpNER})
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(8, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(816, 640)
        Me.TabControl1.TabIndex = 12
        '
        'tpDBR
        '
        Me.tpDBR.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpDBR.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLoc_ID, Me.pnlReasonsDBR, Me.lblCust_ID, Me.Label3, Me.lblCustomer, Me.lblAssignedDBRPallet, Me.btnRecreateDBRManifest, Me.Label6, Me.btnDBR_ReprintLotLabel, Me.btnDeleteAll, Me.btnCreateDBRLot, Me.rtfSNCount, Me.txtSN, Me.lblSN, Me.lstSN, Me.btnDeleteOne, Me.lblNoneDBR, Me.lstAssignedDBRPallet, Me.lstNoneDBR})
        Me.tpDBR.Location = New System.Drawing.Point(4, 22)
        Me.tpDBR.Name = "tpDBR"
        Me.tpDBR.Size = New System.Drawing.Size(808, 614)
        Me.tpDBR.TabIndex = 0
        Me.tpDBR.Text = "DBR"
        '
        'lblLoc_ID
        '
        Me.lblLoc_ID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoc_ID.ForeColor = System.Drawing.Color.Blue
        Me.lblLoc_ID.Location = New System.Drawing.Point(352, 120)
        Me.lblLoc_ID.Name = "lblLoc_ID"
        Me.lblLoc_ID.Size = New System.Drawing.Size(64, 24)
        Me.lblLoc_ID.TabIndex = 25
        '
        'pnlReasonsDBR
        '
        Me.pnlReasonsDBR.BackColor = System.Drawing.Color.RoyalBlue
        Me.pnlReasonsDBR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlReasonsDBR.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDBR_DeviceID, Me.lblDBR_SN, Me.btnDBR_Cancel, Me.btnDBR_OK, Me.cboDBRReasons, Me.lblDBRNER})
        Me.pnlReasonsDBR.Location = New System.Drawing.Point(208, 424)
        Me.pnlReasonsDBR.Name = "pnlReasonsDBR"
        Me.pnlReasonsDBR.Size = New System.Drawing.Size(336, 168)
        Me.pnlReasonsDBR.TabIndex = 19
        '
        'lblDBR_DeviceID
        '
        Me.lblDBR_DeviceID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDBR_DeviceID.Location = New System.Drawing.Point(216, 136)
        Me.lblDBR_DeviceID.Name = "lblDBR_DeviceID"
        Me.lblDBR_DeviceID.Size = New System.Drawing.Size(104, 24)
        Me.lblDBR_DeviceID.TabIndex = 16
        '
        'lblDBR_SN
        '
        Me.lblDBR_SN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDBR_SN.Location = New System.Drawing.Point(24, 136)
        Me.lblDBR_SN.Name = "lblDBR_SN"
        Me.lblDBR_SN.Size = New System.Drawing.Size(160, 24)
        Me.lblDBR_SN.TabIndex = 15
        '
        'btnDBR_Cancel
        '
        Me.btnDBR_Cancel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBR_Cancel.Location = New System.Drawing.Point(72, 80)
        Me.btnDBR_Cancel.Name = "btnDBR_Cancel"
        Me.btnDBR_Cancel.Size = New System.Drawing.Size(72, 48)
        Me.btnDBR_Cancel.TabIndex = 14
        Me.btnDBR_Cancel.Text = "Cancel"
        '
        'btnDBR_OK
        '
        Me.btnDBR_OK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBR_OK.Location = New System.Drawing.Point(160, 80)
        Me.btnDBR_OK.Name = "btnDBR_OK"
        Me.btnDBR_OK.Size = New System.Drawing.Size(72, 48)
        Me.btnDBR_OK.TabIndex = 13
        Me.btnDBR_OK.Text = "OK"
        '
        'cboDBRReasons
        '
        Me.cboDBRReasons.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboDBRReasons.AutoCompletion = True
        Me.cboDBRReasons.AutoDropDown = True
        Me.cboDBRReasons.AutoSelect = True
        Me.cboDBRReasons.Caption = ""
        Me.cboDBRReasons.CaptionHeight = 17
        Me.cboDBRReasons.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDBRReasons.ColumnCaptionHeight = 17
        Me.cboDBRReasons.ColumnFooterHeight = 17
        Me.cboDBRReasons.ColumnHeaders = False
        Me.cboDBRReasons.ContentHeight = 15
        Me.cboDBRReasons.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDBRReasons.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDBRReasons.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDBRReasons.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDBRReasons.EditorHeight = 15
        Me.cboDBRReasons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDBRReasons.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboDBRReasons.ItemHeight = 15
        Me.cboDBRReasons.Location = New System.Drawing.Point(32, 32)
        Me.cboDBRReasons.MatchEntryTimeout = CType(2000, Long)
        Me.cboDBRReasons.MaxDropDownItems = CType(10, Short)
        Me.cboDBRReasons.MaxLength = 32767
        Me.cboDBRReasons.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDBRReasons.Name = "cboDBRReasons"
        Me.cboDBRReasons.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDBRReasons.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDBRReasons.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDBRReasons.Size = New System.Drawing.Size(288, 21)
        Me.cboDBRReasons.TabIndex = 11
        Me.cboDBRReasons.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'lblDBRNER
        '
        Me.lblDBRNER.BackColor = System.Drawing.Color.Transparent
        Me.lblDBRNER.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDBRNER.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDBRNER.Location = New System.Drawing.Point(32, 16)
        Me.lblDBRNER.Name = "lblDBRNER"
        Me.lblDBRNER.Size = New System.Drawing.Size(216, 11)
        Me.lblDBRNER.TabIndex = 12
        Me.lblDBRNER.Text = "DBR Reason:"
        Me.lblDBRNER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCust_ID
        '
        Me.lblCust_ID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCust_ID.ForeColor = System.Drawing.Color.Blue
        Me.lblCust_ID.Location = New System.Drawing.Point(352, 88)
        Me.lblCust_ID.Name = "lblCust_ID"
        Me.lblCust_ID.Size = New System.Drawing.Size(64, 24)
        Me.lblCust_ID.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(208, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Customer:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCustomer
        '
        Me.lblCustomer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.Blue
        Me.lblCustomer.Location = New System.Drawing.Point(208, 56)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(216, 24)
        Me.lblCustomer.TabIndex = 22
        '
        'lblAssignedDBRPallet
        '
        Me.lblAssignedDBRPallet.BackColor = System.Drawing.Color.Transparent
        Me.lblAssignedDBRPallet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssignedDBRPallet.ForeColor = System.Drawing.Color.Teal
        Me.lblAssignedDBRPallet.Location = New System.Drawing.Point(584, 8)
        Me.lblAssignedDBRPallet.Name = "lblAssignedDBRPallet"
        Me.lblAssignedDBRPallet.Size = New System.Drawing.Size(136, 16)
        Me.lblAssignedDBRPallet.TabIndex = 21
        Me.lblAssignedDBRPallet.Text = "Already in Pallet:"
        Me.lblAssignedDBRPallet.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblAssignedDBRPallet.Visible = False
        '
        'btnRecreateDBRManifest
        '
        Me.btnRecreateDBRManifest.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRecreateDBRManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecreateDBRManifest.ForeColor = System.Drawing.Color.White
        Me.btnRecreateDBRManifest.Location = New System.Drawing.Point(208, 240)
        Me.btnRecreateDBRManifest.Name = "btnRecreateDBRManifest"
        Me.btnRecreateDBRManifest.Size = New System.Drawing.Size(216, 40)
        Me.btnRecreateDBRManifest.TabIndex = 18
        Me.btnRecreateDBRManifest.Text = "Re-Create DBR Manifest"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(0, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(208, 24)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Build DBR Pallet"
        '
        'btnDBR_ReprintLotLabel
        '
        Me.btnDBR_ReprintLotLabel.BackColor = System.Drawing.Color.SteelBlue
        Me.btnDBR_ReprintLotLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBR_ReprintLotLabel.ForeColor = System.Drawing.Color.White
        Me.btnDBR_ReprintLotLabel.Location = New System.Drawing.Point(208, 288)
        Me.btnDBR_ReprintLotLabel.Name = "btnDBR_ReprintLotLabel"
        Me.btnDBR_ReprintLotLabel.Size = New System.Drawing.Size(216, 32)
        Me.btnDBR_ReprintLotLabel.TabIndex = 11
        Me.btnDBR_ReprintLotLabel.Text = "Reprint DBR Lot Label"
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackColor = System.Drawing.Color.Red
        Me.btnDeleteAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteAll.ForeColor = System.Drawing.Color.White
        Me.btnDeleteAll.Location = New System.Drawing.Point(208, 192)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(104, 24)
        Me.btnDeleteAll.TabIndex = 5
        Me.btnDeleteAll.Text = "Delete All"
        '
        'btnCreateDBRLot
        '
        Me.btnCreateDBRLot.BackColor = System.Drawing.Color.Orange
        Me.btnCreateDBRLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateDBRLot.ForeColor = System.Drawing.Color.Black
        Me.btnCreateDBRLot.Location = New System.Drawing.Point(208, 336)
        Me.btnCreateDBRLot.Name = "btnCreateDBRLot"
        Me.btnCreateDBRLot.Size = New System.Drawing.Size(216, 32)
        Me.btnCreateDBRLot.TabIndex = 3
        Me.btnCreateDBRLot.Text = "Create DBR Pallet (Ship Lot)"
        '
        'rtfSNCount
        '
        Me.rtfSNCount.BackColor = System.Drawing.Color.Black
        Me.rtfSNCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfSNCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfSNCount.ForeColor = System.Drawing.Color.Lime
        Me.rtfSNCount.Location = New System.Drawing.Point(208, 88)
        Me.rtfSNCount.Name = "rtfSNCount"
        Me.rtfSNCount.ReadOnly = True
        Me.rtfSNCount.Size = New System.Drawing.Size(88, 56)
        Me.rtfSNCount.TabIndex = 3
        Me.rtfSNCount.Text = "SN Count: 0"
        '
        'txtSN
        '
        Me.txtSN.BackColor = System.Drawing.Color.White
        Me.txtSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.Location = New System.Drawing.Point(16, 56)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(176, 20)
        Me.txtSN.TabIndex = 1
        Me.txtSN.Text = ""
        '
        'lblSN
        '
        Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSN.ForeColor = System.Drawing.Color.Black
        Me.lblSN.Location = New System.Drawing.Point(16, 40)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Size = New System.Drawing.Size(88, 16)
        Me.lblSN.TabIndex = 0
        Me.lblSN.Text = "Serial Number:"
        Me.lblSN.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lstSN
        '
        Me.lstSN.BackColor = System.Drawing.Color.White
        Me.lstSN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSN.ItemHeight = 15
        Me.lstSN.Location = New System.Drawing.Point(16, 80)
        Me.lstSN.Name = "lstSN"
        Me.lstSN.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstSN.Size = New System.Drawing.Size(176, 379)
        Me.lstSN.TabIndex = 2
        '
        'btnDeleteOne
        '
        Me.btnDeleteOne.BackColor = System.Drawing.Color.Red
        Me.btnDeleteOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteOne.ForeColor = System.Drawing.Color.White
        Me.btnDeleteOne.Location = New System.Drawing.Point(208, 160)
        Me.btnDeleteOne.Name = "btnDeleteOne"
        Me.btnDeleteOne.Size = New System.Drawing.Size(104, 24)
        Me.btnDeleteOne.TabIndex = 4
        Me.btnDeleteOne.Text = "Delete One"
        '
        'lblNoneDBR
        '
        Me.lblNoneDBR.BackColor = System.Drawing.Color.Transparent
        Me.lblNoneDBR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoneDBR.ForeColor = System.Drawing.Color.Crimson
        Me.lblNoneDBR.Location = New System.Drawing.Point(440, 8)
        Me.lblNoneDBR.Name = "lblNoneDBR"
        Me.lblNoneDBR.Size = New System.Drawing.Size(136, 16)
        Me.lblNoneDBR.TabIndex = 8
        Me.lblNoneDBR.Text = "Don't Meet DBR Criteria:"
        Me.lblNoneDBR.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblNoneDBR.Visible = False
        '
        'lstAssignedDBRPallet
        '
        Me.lstAssignedDBRPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lstAssignedDBRPallet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstAssignedDBRPallet.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAssignedDBRPallet.ForeColor = System.Drawing.Color.DimGray
        Me.lstAssignedDBRPallet.ItemHeight = 16
        Me.lstAssignedDBRPallet.Location = New System.Drawing.Point(584, 32)
        Me.lstAssignedDBRPallet.Name = "lstAssignedDBRPallet"
        Me.lstAssignedDBRPallet.Size = New System.Drawing.Size(224, 544)
        Me.lstAssignedDBRPallet.TabIndex = 20
        Me.lstAssignedDBRPallet.Visible = False
        '
        'lstNoneDBR
        '
        Me.lstNoneDBR.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lstNoneDBR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstNoneDBR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNoneDBR.ForeColor = System.Drawing.Color.DimGray
        Me.lstNoneDBR.ItemHeight = 15
        Me.lstNoneDBR.Location = New System.Drawing.Point(440, 32)
        Me.lstNoneDBR.Name = "lstNoneDBR"
        Me.lstNoneDBR.Size = New System.Drawing.Size(136, 555)
        Me.lstNoneDBR.TabIndex = 7
        Me.lstNoneDBR.Visible = False
        '
        'tpNER
        '
        Me.tpNER.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.tpNER.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstNER_SNs, Me.pnlReasonsNER, Me.lblAssignedNERPallet, Me.lblNoneNER, Me.btnRecreateNERManifest, Me.lblNERLoc_ID, Me.lblNERCust_ID, Me.Label8, Me.lblNERCustomer, Me.Label5, Me.btnNER_ReprintLotLabel, Me.btnNERDeleteAll, Me.btnCreateNERLot, Me.rtfNERSNCount, Me.txtNER_SN, Me.Label4, Me.btnNERDeleteOne, Me.lstNoneNER, Me.lstAssignedNERPallet})
        Me.tpNER.Location = New System.Drawing.Point(4, 22)
        Me.tpNER.Name = "tpNER"
        Me.tpNER.Size = New System.Drawing.Size(808, 614)
        Me.tpNER.TabIndex = 2
        Me.tpNER.Text = "NER"
        Me.tpNER.Visible = False
        '
        'lstNER_SNs
        '
        Me.lstNER_SNs.BackColor = System.Drawing.Color.White
        Me.lstNER_SNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNER_SNs.Location = New System.Drawing.Point(16, 80)
        Me.lstNER_SNs.Name = "lstNER_SNs"
        Me.lstNER_SNs.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstNER_SNs.Size = New System.Drawing.Size(176, 368)
        Me.lstNER_SNs.TabIndex = 2
        '
        'pnlReasonsNER
        '
        Me.pnlReasonsNER.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.pnlReasonsNER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlReasonsNER.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNER_DeviceID, Me.lblNER_SN, Me.cboNERReasons, Me.btnNER_Cancel, Me.btnNER_OK, Me.Label1})
        Me.pnlReasonsNER.Location = New System.Drawing.Point(208, 424)
        Me.pnlReasonsNER.Name = "pnlReasonsNER"
        Me.pnlReasonsNER.Size = New System.Drawing.Size(336, 168)
        Me.pnlReasonsNER.TabIndex = 18
        '
        'lblNER_DeviceID
        '
        Me.lblNER_DeviceID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNER_DeviceID.Location = New System.Drawing.Point(256, 136)
        Me.lblNER_DeviceID.Name = "lblNER_DeviceID"
        Me.lblNER_DeviceID.Size = New System.Drawing.Size(72, 24)
        Me.lblNER_DeviceID.TabIndex = 18
        '
        'lblNER_SN
        '
        Me.lblNER_SN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNER_SN.Location = New System.Drawing.Point(8, 136)
        Me.lblNER_SN.Name = "lblNER_SN"
        Me.lblNER_SN.Size = New System.Drawing.Size(192, 24)
        Me.lblNER_SN.TabIndex = 17
        '
        'cboNERReasons
        '
        Me.cboNERReasons.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboNERReasons.AutoCompletion = True
        Me.cboNERReasons.AutoDropDown = True
        Me.cboNERReasons.AutoSelect = True
        Me.cboNERReasons.Caption = ""
        Me.cboNERReasons.CaptionHeight = 17
        Me.cboNERReasons.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboNERReasons.ColumnCaptionHeight = 17
        Me.cboNERReasons.ColumnFooterHeight = 17
        Me.cboNERReasons.ColumnHeaders = False
        Me.cboNERReasons.ContentHeight = 15
        Me.cboNERReasons.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboNERReasons.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboNERReasons.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNERReasons.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboNERReasons.EditorHeight = 15
        Me.cboNERReasons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNERReasons.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboNERReasons.ItemHeight = 15
        Me.cboNERReasons.Location = New System.Drawing.Point(32, 32)
        Me.cboNERReasons.MatchEntryTimeout = CType(2000, Long)
        Me.cboNERReasons.MaxDropDownItems = CType(10, Short)
        Me.cboNERReasons.MaxLength = 32767
        Me.cboNERReasons.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboNERReasons.Name = "cboNERReasons"
        Me.cboNERReasons.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboNERReasons.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboNERReasons.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboNERReasons.Size = New System.Drawing.Size(288, 21)
        Me.cboNERReasons.TabIndex = 15
        Me.cboNERReasons.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'btnNER_Cancel
        '
        Me.btnNER_Cancel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNER_Cancel.Location = New System.Drawing.Point(72, 80)
        Me.btnNER_Cancel.Name = "btnNER_Cancel"
        Me.btnNER_Cancel.Size = New System.Drawing.Size(72, 48)
        Me.btnNER_Cancel.TabIndex = 14
        Me.btnNER_Cancel.Text = "Cancel"
        '
        'btnNER_OK
        '
        Me.btnNER_OK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNER_OK.Location = New System.Drawing.Point(160, 80)
        Me.btnNER_OK.Name = "btnNER_OK"
        Me.btnNER_OK.Size = New System.Drawing.Size(72, 48)
        Me.btnNER_OK.TabIndex = 13
        Me.btnNER_OK.Text = "OK"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 11)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "NER Reason:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAssignedNERPallet
        '
        Me.lblAssignedNERPallet.BackColor = System.Drawing.Color.Transparent
        Me.lblAssignedNERPallet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssignedNERPallet.ForeColor = System.Drawing.Color.Teal
        Me.lblAssignedNERPallet.Location = New System.Drawing.Point(584, 8)
        Me.lblAssignedNERPallet.Name = "lblAssignedNERPallet"
        Me.lblAssignedNERPallet.Size = New System.Drawing.Size(136, 16)
        Me.lblAssignedNERPallet.TabIndex = 34
        Me.lblAssignedNERPallet.Text = "Already in Pallet:"
        Me.lblAssignedNERPallet.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblAssignedNERPallet.Visible = False
        '
        'lblNoneNER
        '
        Me.lblNoneNER.BackColor = System.Drawing.Color.Transparent
        Me.lblNoneNER.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoneNER.ForeColor = System.Drawing.Color.Crimson
        Me.lblNoneNER.Location = New System.Drawing.Point(440, 8)
        Me.lblNoneNER.Name = "lblNoneNER"
        Me.lblNoneNER.Size = New System.Drawing.Size(136, 16)
        Me.lblNoneNER.TabIndex = 32
        Me.lblNoneNER.Text = "Don't Meet NER Criteria:"
        Me.lblNoneNER.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblNoneNER.Visible = False
        '
        'btnRecreateNERManifest
        '
        Me.btnRecreateNERManifest.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRecreateNERManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecreateNERManifest.ForeColor = System.Drawing.Color.White
        Me.btnRecreateNERManifest.Location = New System.Drawing.Point(208, 240)
        Me.btnRecreateNERManifest.Name = "btnRecreateNERManifest"
        Me.btnRecreateNERManifest.Size = New System.Drawing.Size(216, 40)
        Me.btnRecreateNERManifest.TabIndex = 30
        Me.btnRecreateNERManifest.Text = "Re-Create NER Manifest"
        '
        'lblNERLoc_ID
        '
        Me.lblNERLoc_ID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNERLoc_ID.ForeColor = System.Drawing.Color.Blue
        Me.lblNERLoc_ID.Location = New System.Drawing.Point(352, 120)
        Me.lblNERLoc_ID.Name = "lblNERLoc_ID"
        Me.lblNERLoc_ID.Size = New System.Drawing.Size(64, 24)
        Me.lblNERLoc_ID.TabIndex = 29
        '
        'lblNERCust_ID
        '
        Me.lblNERCust_ID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNERCust_ID.ForeColor = System.Drawing.Color.Blue
        Me.lblNERCust_ID.Location = New System.Drawing.Point(352, 88)
        Me.lblNERCust_ID.Name = "lblNERCust_ID"
        Me.lblNERCust_ID.Size = New System.Drawing.Size(64, 24)
        Me.lblNERCust_ID.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(208, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Customer:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNERCustomer
        '
        Me.lblNERCustomer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNERCustomer.ForeColor = System.Drawing.Color.Blue
        Me.lblNERCustomer.Location = New System.Drawing.Point(208, 56)
        Me.lblNERCustomer.Name = "lblNERCustomer"
        Me.lblNERCustomer.Size = New System.Drawing.Size(216, 24)
        Me.lblNERCustomer.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(0, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(328, 24)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Build NER Pallet"
        '
        'btnNER_ReprintLotLabel
        '
        Me.btnNER_ReprintLotLabel.BackColor = System.Drawing.Color.SteelBlue
        Me.btnNER_ReprintLotLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNER_ReprintLotLabel.ForeColor = System.Drawing.Color.White
        Me.btnNER_ReprintLotLabel.Location = New System.Drawing.Point(208, 288)
        Me.btnNER_ReprintLotLabel.Name = "btnNER_ReprintLotLabel"
        Me.btnNER_ReprintLotLabel.Size = New System.Drawing.Size(216, 32)
        Me.btnNER_ReprintLotLabel.TabIndex = 4
        Me.btnNER_ReprintLotLabel.Text = "Reprint NER Lot Label"
        '
        'btnNERDeleteAll
        '
        Me.btnNERDeleteAll.BackColor = System.Drawing.Color.Red
        Me.btnNERDeleteAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNERDeleteAll.ForeColor = System.Drawing.Color.White
        Me.btnNERDeleteAll.Location = New System.Drawing.Point(208, 192)
        Me.btnNERDeleteAll.Name = "btnNERDeleteAll"
        Me.btnNERDeleteAll.Size = New System.Drawing.Size(104, 24)
        Me.btnNERDeleteAll.TabIndex = 6
        Me.btnNERDeleteAll.Text = "Delete All"
        '
        'btnCreateNERLot
        '
        Me.btnCreateNERLot.BackColor = System.Drawing.Color.Orange
        Me.btnCreateNERLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateNERLot.ForeColor = System.Drawing.Color.Black
        Me.btnCreateNERLot.Location = New System.Drawing.Point(208, 336)
        Me.btnCreateNERLot.Name = "btnCreateNERLot"
        Me.btnCreateNERLot.Size = New System.Drawing.Size(216, 32)
        Me.btnCreateNERLot.TabIndex = 3
        Me.btnCreateNERLot.Text = "Create NER Pallet (Ship Lot)"
        '
        'rtfNERSNCount
        '
        Me.rtfNERSNCount.BackColor = System.Drawing.Color.Black
        Me.rtfNERSNCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfNERSNCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfNERSNCount.ForeColor = System.Drawing.Color.Lime
        Me.rtfNERSNCount.Location = New System.Drawing.Point(208, 88)
        Me.rtfNERSNCount.Name = "rtfNERSNCount"
        Me.rtfNERSNCount.ReadOnly = True
        Me.rtfNERSNCount.Size = New System.Drawing.Size(88, 56)
        Me.rtfNERSNCount.TabIndex = 15
        Me.rtfNERSNCount.Text = "SN Count: 0"
        '
        'txtNER_SN
        '
        Me.txtNER_SN.BackColor = System.Drawing.Color.White
        Me.txtNER_SN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNER_SN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNER_SN.Location = New System.Drawing.Point(16, 56)
        Me.txtNER_SN.Name = "txtNER_SN"
        Me.txtNER_SN.Size = New System.Drawing.Size(176, 20)
        Me.txtNER_SN.TabIndex = 1
        Me.txtNER_SN.Text = ""
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Serial Number:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnNERDeleteOne
        '
        Me.btnNERDeleteOne.BackColor = System.Drawing.Color.Red
        Me.btnNERDeleteOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNERDeleteOne.ForeColor = System.Drawing.Color.White
        Me.btnNERDeleteOne.Location = New System.Drawing.Point(208, 160)
        Me.btnNERDeleteOne.Name = "btnNERDeleteOne"
        Me.btnNERDeleteOne.Size = New System.Drawing.Size(104, 24)
        Me.btnNERDeleteOne.TabIndex = 5
        Me.btnNERDeleteOne.Text = "Delete One"
        '
        'lstNoneNER
        '
        Me.lstNoneNER.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lstNoneNER.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstNoneNER.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNoneNER.ForeColor = System.Drawing.Color.DimGray
        Me.lstNoneNER.ItemHeight = 15
        Me.lstNoneNER.Location = New System.Drawing.Point(440, 32)
        Me.lstNoneNER.Name = "lstNoneNER"
        Me.lstNoneNER.Size = New System.Drawing.Size(136, 555)
        Me.lstNoneNER.TabIndex = 31
        Me.lstNoneNER.Visible = False
        '
        'lstAssignedNERPallet
        '
        Me.lstAssignedNERPallet.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lstAssignedNERPallet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstAssignedNERPallet.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAssignedNERPallet.ForeColor = System.Drawing.Color.DimGray
        Me.lstAssignedNERPallet.ItemHeight = 16
        Me.lstAssignedNERPallet.Location = New System.Drawing.Point(584, 32)
        Me.lstAssignedNERPallet.Name = "lstAssignedNERPallet"
        Me.lstAssignedNERPallet.Size = New System.Drawing.Size(224, 544)
        Me.lstAssignedNERPallet.TabIndex = 33
        Me.lstAssignedNERPallet.Visible = False
        '
        'lblPageTitle
        '
        Me.lblPageTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageTitle.ForeColor = System.Drawing.Color.Blue
        Me.lblPageTitle.Name = "lblPageTitle"
        Me.lblPageTitle.Size = New System.Drawing.Size(256, 32)
        Me.lblPageTitle.TabIndex = 13
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(304, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 16)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Button3"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(432, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(64, 16)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Button4"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(552, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 16)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Button1"
        '
        'frmMessDBRNERManifest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(848, 694)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.Button4, Me.Button3, Me.lblPageTitle, Me.TabControl1})
        Me.Name = "frmMessDBRNERManifest"
        Me.Text = "frmMessDBRNERManifest"
        Me.TabControl1.ResumeLayout(False)
        Me.tpDBR.ResumeLayout(False)
        Me.pnlReasonsDBR.ResumeLayout(False)
        CType(Me.cboDBRReasons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNER.ResumeLayout(False)
        Me.pnlReasonsNER.ResumeLayout(False)
        CType(Me.cboNERReasons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmMessDBRNERManifest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSql As String = ""
        Dim strMsg As String = ""

        Try
            PSS.Core.Highlight.SetHighLight(Me)

            Me.lblCust_ID.Visible = False
            Me.lblLoc_ID.Visible = False
            Me.lblNERCust_ID.Visible = False
            Me.lblNERLoc_ID.Visible = False
            Me.Button1.Visible = False
            Me.Button3.Visible = False
            Me.Button4.Visible = False

            Me.lblPageTitle.Text = _strTabPageTitle
            TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
            TabControl1.SelectedTab = Me.tpDBR
            Me.pnlReasonsDBR.Visible = False
            Me.pnlReasonsNER.Visible = False
            Me.lblCustomer.Text = ""
            Me.lblCust_ID.Text = 0
            Me.lblLoc_ID.Text = 0
            Me.lblNERCustomer.Text = ""
            Me.lblNERCust_ID.Text = 0
            Me.lblNERLoc_ID.Text = 0

            rtfSNCount.Text = 0
            rtfNERSNCount.Text = 0

            'initialize datatable
            Me._dtDBRUnits = New DataTable()
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtDBRUnits, "Device_SN", "System.String", "")
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtDBRUnits, "Device_ID", "System.Int64", "0")
            Me._dtNERUnits = New DataTable()
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtNERUnits, "Device_SN", "System.String", "")
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtNERUnits, "Device_ID", "System.Int64", "0")

            LoadDBRNERCodes()
            UpdateCount()
            UpdateNERCount()
            SelectSNText()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************
    Private Sub getRptDirectoryInfo(ByVal iCust_ID As Integer, ByVal strCustomer As String, _
                                    ByVal strDBRNER As String, ByRef strRptTitle As String, _
                                    ByRef strRptDir As String)

        strRptTitle = strCustomer & " " & strDBRNER & " Manifest"
        strRptDir = ""
        Select Case iCust_ID
            Case PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID
                strRptDir = "P:\Dept\Messaging\DBR Manifest\"
            Case PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID
                strRptDir = "P:\Dept\Aquis\Pallet Packing List\"
            Case PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID
                strRptDir = "P:\Dept\Morris Communication\Pallet Packing List\"
            Case PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID
                strRptDir = "P:\Dept\Propage\Pallet Packing List\"
            Case PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID
                strRptDir = "P:\Dept\CookPager\Pallet Packing List\"
            Case PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID
                strRptDir = "P:\Dept\CriticalAlert\DBR Manifest\"
            Case PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID
                strRptDir = "P:\Dept\OtherMessageCustomers\Anna\DBR Manifest\"
            Case PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID
                strRptDir = "P:\Dept\OtherMessageCustomers\Lahey\DBR Manifest\"
            Case PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID
                strRptDir = "P:\Dept\OtherMessageCustomers\Masco\DBR Manifest\"
            Case PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID
                strRptDir = "P:\Dept\OtherMessageCustomers\Franciscan\DBR Manifest\"
            Case PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID
                strRptDir = "P:\Dept\OtherMessageCustomers\Maine\DBR Manifest\"
            Case PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID
                strRptDir = "P:\Dept\OtherMessageCustomers\SMHC\DBR Manifest\"
            Case PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID
                strRptDir = "P:\Dept\A1WirelessComm\Pallet Packing List\"
            Case PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID
                strRptDir = "P:\Dept\ATS\Pallet Packing List\"
        End Select

    End Sub

#Region "DBR"
    '*************************************************************************
    Private Sub txtSN_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSN.KeyDown
        Dim strSN, strSNStatus As String
        Dim iDevice_ID As Int64
        Dim iDCode_ID As Integer = 0   'DBR Failure Code
        ' Dim iModelID As Integer = 0    'DBR Failure Code
        Dim R1 As DataRow
        Dim dtBillingInfo, dtReason As DataTable
        Dim iPalletID As Integer = 0
        Dim strPalletName As String = ""
        Dim iCustID As Integer = 0
        Dim iLocID As Integer = 0

        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtSN.Text.Trim.Length > 0 Then
                    strSN = Me.txtSN.Text.Trim.ToUpper

                    If Not Me._dtDBRUnits.Rows.Count = Me.lstSN.Items.Count Then
                        MessageBox.Show("SN box count mismatches SN data table. See IT.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtSN.Text = ""
                        Exit Sub
                    End If

                    If Not Me._dtDBRUnits.Rows.Count > 0 Then
                        Me.lblCustomer.Text = "" : Me.lblCust_ID.Text = 0 : Me.lblLoc_ID.Text = 0
                    End If

                    '*****************************
                    'Check for limitation
                    '*****************************
                    If Me._dtDBRUnits.Rows.Count >= 100 Then
                        MessageBox.Show("You have reached the limit of 100 Devices.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtSN.Text = ""
                        Exit Sub
                    End If

                    '*****************************
                    'Check for duplicate in list
                    '*****************************
                    If Me.lstSN.Items.IndexOf(strSN) > -1 Then
                        MsgBox("This serial number '" & strSN & "' is already in the list.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "SN Listed")
                        SelectSNText()
                        Exit Sub
                    End If

                    '*****************************
                    'Check for device status
                    strSNStatus = Me._objDBRManifest.CheckMessDBRNERSerialNumber(strSN, Me._iDBR_BillcodeID, _
                                  Me._iNER_BillcodeID, "DBR", iDevice_ID, iPalletID, iCustID, _
                                  iLocID, strPalletName, Me._strDBRCustomer)

                    'Check customer
                    If strSNStatus.Length = 0 AndAlso Me.lblCust_ID.Text = 0 AndAlso Me.lblCustomer.Text.Trim.Length = 0 Then
                        Me.lblCust_ID.Text = iCustID : Me.lblLoc_ID.Text = iLocID
                        Me.lblCustomer.Text = Me._strDBRCustomer
                    ElseIf strSNStatus.Length = 0 AndAlso Me.lblCust_ID.Text <> 0 AndAlso Me.lblCustomer.Text.Trim.Length <> 0 Then
                        If Not Me.lblCust_ID.Text = iCustID Then
                            MsgBox("This device does no belong to " & Me.lblCustomer.Text & _
                                   ". It belongs to " & Me._strDBRCustomer & ".", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Invalid Device")
                            Me.txtSN.Text = "" : SelectSNText()
                            Exit Sub
                        End If
                    End If

                    'Check Status 
                    If strSNStatus.Length > 0 Then 'Stop it
                        If iPalletID > 0 Then
                            Dim strTemp As String = strSN & " (" & strPalletName & ")"
                            If Me.lstAssignedDBRPallet.Items.IndexOf(strTemp) < 0 Then
                                Me.lstAssignedDBRPallet.Items.Add(strTemp)
                            End If
                            Me.lstAssignedDBRPallet.Visible = True : Me.lblAssignedDBRPallet.Visible = True
                        Else
                            If Me.lstNoneDBR.Items.IndexOf(strSN) < 0 Then
                                Me.lstNoneDBR.Items.Add(strSN)
                                Me.lstNoneDBR.Visible = True : Me.lblNoneDBR.Visible = True
                            End If
                        End If

                        MsgBox(strSNStatus, MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Invalid Device")
                        Me.txtSN.Text = "" : SelectSNText()
                    Else
                        '***************************
                        'Get DBR Reason if missing
                        '***************************
                        'iDCode_ID = Me._objDBRManifest.GetDBRFailCode(iDevice_ID)
                        dtReason = Me._objDBRManifest.GetDBRNERFailCodeData(iDevice_ID)

                        If dtReason.Rows.Count = 0 Then  'Select a reason
                            Me.lblDBR_SN.Text = strSN
                            Me.lblDBR_DeviceID.Text = iDevice_ID.ToString
                            OpenSelectDBRReason()
                        ElseIf dtReason.Rows.Count > 1 Then 'Delete one or more reason. 1 reason is allowed only
                            Dim fm As New frmRemoveDBRNERReason(iDevice_ID, strSN, "DBR", dtReason)
                            'fm.ShowDialog() 'fm.ShowDialog(Me)
                            If fm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                                AddDBRUnitToList(strSN, iDevice_ID)
                            Else
                                MessageBox.Show("Failed to delete reason. Try to scan it again or see IT.", "Remove reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.txtSN.Text = "" : SelectSNText()
                            End If
                        Else
                            AddDBRUnitToList(strSN, iDevice_ID)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Processing Serial Number")
        Finally
            If Me.lstNoneDBR.Items.Count > 0 Then
                Me.lstNoneDBR.Visible = True
                Me.lblNoneDBR.Visible = True
            End If
            If Me.lstAssignedDBRPallet.Items.Count > 0 Then
                Me.lstAssignedDBRPallet.Visible = True
                Me.lstAssignedDBRPallet.Visible = True
            End If
            'Generic.DisposeDT(dtBillingInfo)
        End Try
    End Sub
    '*************************************************************************
    Private Sub btnDeleteOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteOne.Click
        Dim strSN As String = ""
        Dim R1 As DataRow
        Dim i As Integer = 0

        Try
            If Me.lstSN.Items.Count > 0 Then
                '*******************
                'Get Removed SN
                '*******************
                strSN = Trim(InputBox("Scan SN:", "Delete One SN From List", "", )).ToUpper
                If strSN = "" Then
                    Exit Sub
                End If

                '****************************************************
                'Removed SN from the main list and global datatable
                '****************************************************
                For Each R1 In Me._dtDBRUnits.Rows
                    If R1("Device_SN").ToString.ToUpper.Trim = strSN.ToUpper.Trim Then
                        R1.Delete()
                        Exit For
                    End If
                Next R1

                Me._dtDBRUnits.AcceptChanges()

                i = Me.lstSN.Items.IndexOf(strSN)
                If i > -1 Then
                    Me.lstSN.Items.RemoveAt(Me.lstSN.Items.IndexOf(strSN))
                    Me.lstSN.Refresh()
                Else
                    MessageBox.Show("SN is not listed.", "Remove One Item From List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSN.Focus()
                    Exit Sub
                End If

                If Me.lstSN.Items.Count = 0 Then
                    Me.lblAssignedDBRPallet.Visible = False
                    Me.lstAssignedDBRPallet.Items.Clear()
                    Me.lstAssignedDBRPallet.Refresh()

                    Me.lblNoneDBR.Visible = False
                    Me.lstNoneDBR.Items.Clear()
                    Me.lstNoneDBR.Refresh()
                    Me.lblCustomer.Text = "" : Me.lblCust_ID.Text = 0 : Me.lblLoc_ID.Text = 0
                End If

                '********************
                'Update counter
                '********************
                UpdateCount()
            End If

            SelectSNText()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Deleting Selected Serial Number")
        Finally
            R1 = Nothing
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnDeleteAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim i As Integer

        Try
            If Me.lstSN.Items.Count > 0 Then
                If MsgBox("Delete all serial numbers from list?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Delete All SNs") = MsgBoxResult.Yes Then

                    Me._dtDBRUnits.Rows.Clear()
                    Me.lstSN.Refresh()

                    Me.lstSN.Items.Clear()
                    Me.lstSN.Refresh()

                    Me.lblAssignedDBRPallet.Visible = False
                    Me.lstAssignedDBRPallet.Items.Clear()
                    Me.lstAssignedDBRPallet.Refresh()

                    Me.lblNoneDBR.Visible = False
                    Me.lstNoneDBR.Items.Clear()
                    Me.lstNoneDBR.Refresh()

                    Me.lblCustomer.Text = "" : Me.lblCust_ID.Text = 0 : Me.lblLoc_ID.Text = 0
                    UpdateCount()
                End If
            End If

            SelectSNText()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Deleting Serial Numbers")
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnCreateDBRLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDBRLot.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim strRptTitle As String = "" '"American Messaging DBR Manifest"
        Dim strRptDir As String = "" '"P:\Dept\Messaging\DBR Manifest\"
        Dim strDevice_IDsIN As String = ""
        Dim ArrLstDeviceIDs As New ArrayList()
        Dim dt, dtHasDBRPallet, dtShipPalletRpt As DataTable
        Dim R1 As DataRow
        Dim objExcelRpt As Data.ExcelReports
        Dim strDBRPallett_name As String = ""
        Dim objRpt As ReportDocument

        Try
            If Me.lstSN.Items.Count = 0 Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            If Not Me.lblCust_ID.Text > 0 Or Not Me.lblCustomer.Text.Trim.Length > 0 Then
                MessageBox.Show("No customer data!")
                Exit Sub
            End If

            'Get correct directory
            getRptDirectoryInfo(Me.lblCust_ID.Text, Me.lblCustomer.Text, "DBR", strRptTitle, strRptDir)

            If Not strRptDir.Trim.Length > 0 Then
                MessageBox.Show("No data file output directory.")
                Exit Sub
            End If

            '********************
            'Get Device_ID list
            '********************
            For Each R1 In Me._dtDBRUnits.Rows
                If strDevice_IDsIN.Length > 0 Then strDevice_IDsIN &= ", "
                strDevice_IDsIN &= R1("Device_ID")

                If Not ArrLstDeviceIDs.Contains(R1("Device_ID")) Then
                    ArrLstDeviceIDs.Add(R1("Device_ID"))
                End If
            Next R1

            '****************************************
            'Check again: Devices have DBR-Pallett asssigned
            '****************************************
            dtHasDBRPallet = Me._objDBRManifest.GetDevicesHasPalletData(strDevice_IDsIN)
            If dtHasDBRPallet.Rows.Count > 0 Then
                R1 = Nothing
                Me.lstAssignedDBRPallet.Items.Clear()
                For Each R1 In dtHasDBRPallet.Rows
                    Dim strTemp As String = R1("Device_SN") & " (" & R1("Pallett_Name") & ")"
                    If Me.lstAssignedDBRPallet.Items.IndexOf(strTemp) < 0 Then
                        Me.lstAssignedDBRPallet.Items.Add(strTemp)
                    End If
                Next R1
                Me.lstAssignedDBRPallet.Visible = True : Me.lblAssignedDBRPallet.Visible = True
                MessageBox.Show("Some devices in the list have DBR-Pallet. Please refer to ""Assigned DBR-Pallet"" list and remove them out from main list.")
                Exit Sub
            End If

            '************************************
            'Create and assigned Pallet to devices
            '************************************
            strDBRPallett_name = Me._objDBRManifest.PalletizeAMS_DBRNERPallet(lblLoc_ID.Text, lblCust_ID.Text, _
                                                                            ArrLstDeviceIDs, Me._strWork_Dt, _
                                                                            Me._dtDBRUnits.Rows.Count, "DBR", PSS.Core.ApplicationUser.IDShift)

            If strDBRPallett_name = "" Then
                Exit Sub    'Failed to create pallet
            End If

            '************************************
            'Create Excel Report
            '************************************
            dt = Me._objDBRManifest.GetDBRSNData(strDevice_IDsIN)

            objExcelRpt = New Data.ExcelReports()

            objExcelRpt.RunAMManifestReport(dt, strDBRPallett_name, strRptDir, strRptTitle, True)

            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strDBRPallett_name, dt.Rows.Count, "DBR", "Fail", New String() {"DBR Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If

            '************************************
            'Reset controls and global variables
            '************************************
            Me.lblNoneDBR.Visible = False
            Me.lstNoneDBR.Items.Clear()
            Me.lstNoneDBR.Refresh()
            Me.lstNoneDBR.Visible = False
            Me.lblAssignedDBRPallet.Visible = False
            Me.lstAssignedDBRPallet.Items.Clear()
            Me.lstAssignedDBRPallet.Refresh()
            Me.lstAssignedDBRPallet.Visible = False
            Me.btnDeleteAll.Enabled = False
            Me.btnDeleteOne.Enabled = False
            Me.btnCreateDBRLot.Enabled = False
            Me.lblLoc_ID.Text = 0
            Me.lblCust_ID.Text = 0
            Me.lblCustomer.Text = ""
            Me._dtDBRUnits.Rows.Clear()
            Me.lstSN.Items.Clear()
            Me.lstSN.Refresh()


            UpdateCount()
            SelectSNText()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating DBR Manifest")
        Finally
            objRpt = Nothing
            objExcelRpt = Nothing
            R1 = Nothing
            Generic.DisposeDT(dt)
            Generic.DisposeDT(dtHasDBRPallet)
            Generic.DisposeDT(dtShipPalletRpt)
            Me.Enabled = True
            Me.txtSN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    '*************************************************************************
    Private Sub btnRecreateDBRManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecreateDBRManifest.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim strRptTitle As String = ""
        Dim strRptDir As String = ""
        Dim strDevice_IDsIN As String = ""
        Dim dt, dt1 As DataTable
        Dim R1 As DataRow
        Dim objExcelRpt As Data.ExcelReports
        Dim strDBRPallett_name As String = ""
        Dim objRpt As ReportDocument
        Dim booPrintRpt As Boolean = True
        Dim iCust_ID As Integer = 0
        Dim iLoc_ID As Integer = 0
        Dim strCustomer As String = ""

        Try
            strDBRPallett_name = InputBox("Please enter Pallet Name:", "Information").Trim
            If strDBRPallett_name.Length = 0 Then Exit Sub

            If InStr(strDBRPallett_name.ToUpper, "DBR") = 0 Then
                MessageBox.Show("Invalid DBR pallet name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            dt = Me._objDBRManifest.GetDBRNERSNDataByPalletName(strDBRPallett_name)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Can't find data for this pallet. Please check Pallet Name again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                iCust_ID = dt.Rows(0).Item("Cust_ID")
                iLoc_ID = dt.Rows(0).Item("Loc_ID")
                strCustomer = dt.Rows(0).Item("Customer")
                dt.Columns.Remove("Customer")
                dt.Columns.Remove("Loc_ID")
                dt.Columns.Remove("Cust_ID")

                getRptDirectoryInfo(iCust_ID, strCustomer, "DBR", strRptTitle, strRptDir)

                If strRptDir.Trim.Length = 0 Then
                    MessageBox.Show("Invalid manifest report directory or file info.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf System.IO.File.Exists(strRptDir & strDBRPallett_name & ".xls") = True Then
                    MessageBox.Show("The manifest report file is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Cursor.Current = Cursors.WaitCursor : Me.Enabled = False

                    If MessageBox.Show("Do you want to print the report?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then booPrintRpt = False

                    objExcelRpt = New Data.ExcelReports()

                    objExcelRpt.RunAMManifestReport(dt, strDBRPallett_name, strRptDir, strRptTitle, True, booPrintRpt)

                    '************************************
                    'Reset controls and global variables
                    '************************************

                    SelectSNText()

                    MsgBox("Completed.", MsgBoxStyle.Information, "Information")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating DBR Manifest")
        Finally
            objRpt = Nothing
            objExcelRpt = Nothing
            R1 = Nothing
            Generic.DisposeDT(dt)
            Generic.DisposeDT(dt1)
            Me.Enabled = True
            Me.txtSN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnDBR_ReprintLotLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDBR_ReprintLotLabel.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim dt, dtShipPalletRpt As DataTable
        Dim strDBRPallett_name As String
        Dim objRpt As ReportDocument
        Dim objMisc As Data.Buisness.Misc
        Dim iPallettQty As Integer = 0

        Try
            strDBRPallett_name = ""

            strDBRPallett_name = InputBox("Enter DBR Pallet Name:", "Pallet", "").Trim.ToUpper

            If strDBRPallett_name.Trim.Length = 0 Then Exit Sub

            If InStr(strDBRPallett_name.ToUpper, "DBR") = 0 Then
                MessageBox.Show("Invalid DBR pallet name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            '************************************
            'Get Pallett information
            '************************************
            objMisc = New Data.Buisness.Misc()
            dt = objMisc.GetPalletInfo_ByPallettName(strDBRPallett_name)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Pallet name does not exist.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSN.Focus()
                Exit Sub
            End If

            If Not IsDBNull(dt.Rows(0)("Pallett_QTY")) Then
                iPallettQty = dt.Rows(0)("Pallett_QTY")
            Else
                iPallettQty = Me._objDBRManifest.GetDevCountByPalletID(dt.Rows(0)("Pallett_ID"))
            End If

            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strDBRPallett_name, iPallettQty, "DBR", "Fail", New String() {"DBR Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If

            SelectSNText()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Reprint Manifest Label")
        Finally
            objMisc = Nothing
            Me.Enabled = True
            Me.txtSN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************
    Private Sub UpdateCount()
        Dim iStart As Integer

        Try
            Me.rtfSNCount.Text = "SN Count: " & Me.lstSN.Items.Count.ToString

            Me.rtfSNCount.SelectionStart = 0
            Me.rtfSNCount.SelectionLength = Me.rtfSNCount.Text.Length
            Me.rtfSNCount.SelectionAlignment = HorizontalAlignment.Center

            iStart = Me.rtfSNCount.Text.IndexOf(":")

            If iStart > -1 Then
                iStart += 2

                Me.rtfSNCount.SelectionStart = iStart
                Me.rtfSNCount.SelectionLength = Me.rtfSNCount.Text.Length - iStart
                Me.rtfSNCount.SelectionFont = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
                Me.rtfSNCount.SelectionColor = Color.Green
            End If

            If Me.lstSN.Items.Count > 0 Then
                Me.btnDeleteOne.Enabled = True
                Me.btnDeleteAll.Enabled = True
                Me.btnCreateDBRLot.Enabled = True
            Else
                Me.btnDeleteOne.Enabled = False
                Me.btnDeleteAll.Enabled = False
                Me.btnCreateDBRLot.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*************************************************************************
    Private Sub AddDBRUnitToList(ByVal strSN As String, ByVal iDevice_ID As Integer)
        Dim R1 As DataRow
        '*******************
        'Add Record
        '*******************
        Try
            R1 = Nothing
            R1 = Me._dtDBRUnits.NewRow
            R1("Device_SN") = strSN
            R1("Device_ID") = iDevice_ID
            Me._dtDBRUnits.Rows.Add(R1)
            Me._dtDBRUnits.AcceptChanges()

            Me.lstSN.Items.Add(strSN)
            Me.lstSN.Refresh()

            If Me._dtDBRUnits.Rows.Count > 0 Then Me.btnCreateDBRLot.Enabled = True

            UpdateCount()

            Me.txtSN.Text = ""
            SelectSNText()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "AddDBRUnitToList", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    '*************************************************************************
    Private Sub SelectSNText()
        If Me.txtSN.Text.Trim.Length > 0 Then Me.txtSN.SelectAll()
        Me.txtSN.Focus()
    End Sub

    '*************************************************
    Private Sub ShowDBRReasonScreen(ByVal iDevice_ID As Integer)
        Dim objDBR As New Gui.Billing.frmDBRReason()
        Dim i As Integer = 0
        Try
            With objDBR
                .CustID = lblCust_ID.Text
                .DeviceID = iDevice_ID
                .ShowDialog()
                'Update the DB with the selected DBR reason
                i = .UPD
            End With
            'End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objDBR) Then
                objDBR.Dispose()
                objDBR = Nothing
            End If

        End Try
    End Sub

    '*******************************************************************
    Private Sub LoadDBRNERCodes()
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Dim objDBRManifest As New Data.Buisness.DBRManifest()
        Dim dt As DataTable
        Try
            'DBR Reasons
            dt = objMisc.GetDBRCodes(True)
            Misc.PopulateC1DropDownList(Me.cboDBRReasons, dt, "DispalyDesc", "Dcode_ID")
            'Me.cboDBRReasons.SelectedValue = 0 'Empty Row 
            If dt.Rows.Count >= 1 AndAlso dt.Rows.Count <= 2 Then
                Me.cboDBRReasons.SelectedValue = dt.Rows(0).Item("Dcode_ID")
                Me._iDBRReasonDefaultID = Me.cboDBRReasons.SelectedValue
            ElseIf dt.Rows.Count > 2 Then
                Me.cboDBRReasons.SelectedIndex = 0
                Me._iDBRReasonDefaultID = Me.cboDBRReasons.SelectedValue
            End If

            'NER Reasons
            dt = objDBRManifest.GetNERReasons(True, True, True)
            Misc.PopulateC1DropDownList(Me.cboNERReasons, dt, "DispalyDesc", "Dcode_ID")
            'Me.cboNERReasons.SelectedValue = 0 'Empty Row 
            If dt.Rows.Count >= 1 AndAlso dt.Rows.Count <= 2 Then
                Me.cboNERReasons.SelectedValue = dt.Rows(0).Item("Dcode_ID")
                Me._iNERReasonDefaultID = Me.cboNERReasons.SelectedValue
            ElseIf dt.Rows.Count > 2 Then
                Me.cboNERReasons.SelectedIndex = 0
                Me._iNERReasonDefaultID = Me.cboNERReasons.SelectedValue
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadDBRNERCodes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            dt = Nothing : objMisc = Nothing : objDBRManifest = Nothing
        End Try
    End Sub

    '***************************************************************************************************************
    Private Sub OpenSelectDBRReason()
        Dim ctrl As Control
        Dim i As Integer = 0
        Try
            ReDim Me._objNameDBR(Me.tpDBR.Controls.Count - 1)
            ReDim Me._objNameEnabledDBR(Me.tpDBR.Controls.Count - 1)

            For Each ctrl In Me.tpDBR.Controls
                If Not ctrl.Name.ToUpper = "pnlReasonsDBR".ToUpper Then
                    Me._objNameDBR(i) = ctrl.Name
                    Me._objNameEnabledDBR(i) = ctrl.Enabled

                    ctrl.Enabled = False
                    i += 1
                End If
            Next

            Me.pnlReasonsDBR.Left = Me.tpDBR.Width / 2 - Me.pnlReasonsDBR.Width / 2
            Me.pnlReasonsDBR.Top = Me.tpDBR.Height / 2 - Me.pnlReasonsDBR.Height / 2
            Me.pnlReasonsDBR.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "OpenSelectDBRReason", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    '***************************************************************************************************************
    Private Sub CloseSelectDBRReason()
        Dim ctrl As Control
        Dim i As Integer = 0
        Dim j As Integer = 0

        Try
            For Each ctrl In Me.tpDBR.Controls
                If Not ctrl.Name.ToUpper = "pnlReasonsDBR".ToUpper Then
                    For j = 0 To Me._objNameDBR.Length - 1
                        If ctrl.Name = Me._objNameDBR(j) Then
                            ctrl.Enabled = Me._objNameEnabledDBR(j)
                            Exit For
                        End If
                    Next j
                End If
            Next
            Me.pnlReasonsDBR.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CloseSelectDBRReason", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    '***************************************************************************************************************
    Private Sub CloseSelectNERReason()
        Dim ctrl As Control
        Dim i As Integer = 0
        Dim j As Integer = 0

        Try
            For Each ctrl In Me.tpDBR.Controls
                If Not ctrl.Name.ToUpper = "pnlReasonsNER".ToUpper Then
                    For j = 0 To Me._objNameNER.Length - 1
                        If ctrl.Name = Me._objNameNER(j) Then
                            ctrl.Enabled = Me._objNameEnabledNER(j)
                            Exit For
                        End If
                    Next j
                End If
            Next
            Me.pnlReasonsNER.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CloseSelectNERReason", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***************************************************************************************************************
    Private Sub btnDBR_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDBR_OK.Click
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            'Save DBR reason
            objMisc.UPD(Me.lblDBR_DeviceID.Text, Me.cboDBRReasons.SelectedValue)
            CloseSelectDBRReason()

            AddDBRUnitToList(Me.lblDBR_SN.Text, Me.lblDBR_DeviceID.Text)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnDBR_OK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***************************************************************************************************************
    Private Sub btnDBR_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDBR_Cancel.Click
        If MessageBox.Show("Do you want cancel?", "DBR Reason", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Me.txtSN.SelectAll()
            CloseSelectDBRReason()
        End If
    End Sub

#End Region

#Region "NER"

    '*************************************************************************
    Private Sub txtNER_SN_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNER_SN.KeyDown
        Dim strSN, strSNStatus As String
        Dim iDevice_ID As Int64
        Dim iDCode_ID As Integer = 0   'NER Failure Code
        Dim R1 As DataRow
        Dim dtBillingInfo, dtReason As DataTable
        Dim iPalletID As Integer = 0
        Dim strPalletName As String = ""
        Dim iCustID As Integer = 0
        Dim iLocID As Integer = 0

        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtNER_SN.Text.Trim.Length > 0 Then
                    strSN = Me.txtNER_SN.Text.Trim.ToUpper

                    If Not Me._dtNERUnits.Rows.Count = Me.lstNER_SNs.Items.Count Then
                        MessageBox.Show("SN box count mismatches SN data table. See IT.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtNER_SN.Text = ""
                        Exit Sub
                    End If

                    If Not Me._dtNERUnits.Rows.Count > 0 Then
                        Me.lblNERCustomer.Text = "" : Me.lblNERCust_ID.Text = 0 : Me.lblNERLoc_ID.Text = 0
                    End If

                    '*****************************
                    'Check for limitation
                    '*****************************
                    If Me._dtNERUnits.Rows.Count >= 100 Then
                        MessageBox.Show("You have reached the limit of 100 Devices.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtNER_SN.Text = ""
                        Exit Sub
                    End If

                    '*****************************
                    'Check for duplicate in list
                    '*****************************
                    If Me.lstNER_SNs.Items.IndexOf(strSN) > -1 Then
                        MsgBox("This serial number '" & strSN & "' is already in the list.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "SN Listed")
                        SelectNER_SNText()
                        Exit Sub
                    End If

                    '*****************************
                    'Check for device status
                    strSNStatus = Me._objDBRManifest.CheckMessDBRNERSerialNumber(strSN, Me._iDBR_BillcodeID, _
                                  Me._iNER_BillcodeID, "NER", iDevice_ID, iPalletID, iCustID, _
                                  iLocID, strPalletName, Me._strNERCustomer)


                    'Check customer
                    If strSNStatus.Length = 0 AndAlso Me.lblNERCust_ID.Text = 0 AndAlso Me.lblNERCustomer.Text.Trim.Length = 0 Then
                        Me.lblNERCust_ID.Text = iCustID : Me.lblNERLoc_ID.Text = iLocID
                        Me.lblNERCustomer.Text = Me._strNERCustomer
                    ElseIf strSNStatus.Length = 0 AndAlso Me.lblNERCust_ID.Text <> 0 AndAlso Me.lblNERCustomer.Text.Trim.Length <> 0 Then
                        If Not Me.lblNERCust_ID.Text = iCustID Then
                            MsgBox("This device does not belong to " & Me.lblNERCustomer.Text & _
                                   ". It belongs to " & Me._strNERCustomer & ".", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Invalid Device")
                            Me.txtNER_SN.Text = "" : SelectNER_SNText()
                            Exit Sub
                        End If
                    End If

                    'Check Status 
                    If strSNStatus.Length > 0 Then 'Stop it
                        If iPalletID > 0 Then
                            Dim strTemp As String = strSN & " (" & strPalletName & ")"
                            If Me.lstAssignedNERPallet.Items.IndexOf(strTemp) < 0 Then
                                Me.lstAssignedNERPallet.Items.Add(strTemp)
                            End If
                            Me.lstAssignedNERPallet.Visible = True : Me.lblAssignedNERPallet.Visible = True
                        Else
                            If Me.lstNoneNER.Items.IndexOf(strSN) < 0 Then
                                Me.lstNoneNER.Items.Add(strSN)
                                Me.lstNoneNER.Visible = True : Me.lblNoneNER.Visible = True
                            End If
                        End If

                        MsgBox(strSNStatus, MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Invalid Device")
                        Me.txtNER_SN.Text = "" : SelectNER_SNText()
                    Else
                        '***************************
                        'Get NER Reason if missing
                        '***************************
                        ' iDCode_ID = Me._objDBRManifest.GetDBRFailCode(iDevice_ID)
                        dtReason = Me._objDBRManifest.GetDBRNERFailCodeData(iDevice_ID)

                        If dtReason.Rows.Count = 0 Then  'Select a reason
                            Me.lblNER_SN.Text = strSN
                            Me.lblNER_DeviceID.Text = iDevice_ID.ToString
                            OpenSelectNERReason()
                        ElseIf dtReason.Rows.Count > 1 Then 'Delete one or more reason. 1 reason is allowed only
                            Dim fm As New frmRemoveDBRNERReason(iDevice_ID, strSN, "NER", dtReason)
                            'fm.ShowDialog() 'fm.ShowDialog(Me)
                            If fm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                                AddNERUnitToList(strSN, iDevice_ID)
                            Else
                                MessageBox.Show("Failed to delete reason. Try to scan it again or see IT.", "Remove reason", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.txtNER_SN.Text = "" : SelectNER_SNText()
                            End If
                        Else
                            AddNERUnitToList(strSN, iDevice_ID)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Processing Serial Number")
        Finally

            If Me.lstNoneNER.Items.Count > 0 Then
                Me.lstNoneNER.Visible = True
                Me.lblNoneNER.Visible = True
            End If
            If Me.lstAssignedNERPallet.Items.Count > 0 Then
                Me.lstAssignedNERPallet.Visible = True
                Me.lstAssignedNERPallet.Visible = True
            End If
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnNERDeleteOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNERDeleteOne.Click
        Dim strSN As String = ""
        Dim R1 As DataRow
        Dim i As Integer = 0

        Try
            If Me.lstNER_SNs.Items.Count > 0 Then
                '*******************
                'Get Removed SN
                '*******************
                strSN = Trim(InputBox("Scan SN:", "Delete One SN From List", "", )).ToUpper
                If strSN = "" Then
                    Exit Sub
                End If

                '****************************************************
                'Removed SN from the main list and global datatable
                '****************************************************
                For Each R1 In Me._dtNERUnits.Rows
                    If R1("Device_SN").ToString.ToUpper.Trim = strSN.ToUpper.Trim Then
                        R1.Delete()
                        Exit For
                    End If
                Next R1

                Me._dtNERUnits.AcceptChanges()

                i = Me.lstNER_SNs.Items.IndexOf(strSN)
                If i > -1 Then
                    Me.lstNER_SNs.Items.RemoveAt(Me.lstNER_SNs.Items.IndexOf(strSN))
                    Me.lstNER_SNs.Refresh()
                Else
                    MessageBox.Show("SN is not listed.", "Remove One Item From List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtNER_SN.Focus()
                    Exit Sub
                End If

                If Me.lstNER_SNs.Items.Count = 0 Then
                    Me.lblAssignedNERPallet.Visible = False
                    Me.lstAssignedNERPallet.Items.Clear()
                    Me.lstAssignedNERPallet.Refresh()

                    Me.lblNoneNER.Visible = False
                    Me.lstNoneNER.Items.Clear()
                    Me.lstNoneNER.Refresh()
                    Me.lblNERCustomer.Text = "" : Me.lblNERCust_ID.Text = 0 : Me.lblNERLoc_ID.Text = 0
                End If

                '********************
                'Update counter
                '********************
                UpdateNERCount()
            End If

            SelectNER_SNText()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Deleting Selected Serial Number")
        Finally
            R1 = Nothing
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnNERDeleteAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNERDeleteAll.Click
        Dim i As Integer

        Try
            If Me.lstNER_SNs.Items.Count > 0 Then
                If MsgBox("Delete all serial numbers from list?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Delete All SNs") = MsgBoxResult.Yes Then

                    Me._dtNERUnits.Rows.Clear()
                    Me.lstNER_SNs.Refresh()

                    Me.lstNER_SNs.Items.Clear()
                    Me.lstNER_SNs.Refresh()

                    Me.lblAssignedNERPallet.Visible = False
                    Me.lstAssignedNERPallet.Items.Clear()
                    Me.lstAssignedNERPallet.Refresh()

                    Me.lblNoneNER.Visible = False
                    Me.lstNoneNER.Items.Clear()
                    Me.lstNoneNER.Refresh()

                    Me.lblNERCustomer.Text = "" : Me.lblNERCust_ID.Text = 0 : Me.lblNERLoc_ID.Text = 0
                    UpdateNERCount()
                End If
            End If

            SelectSNText()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Deleting Serial Numbers")
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnCreateNERLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNERLot.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim strRptTitle As String = "" '"American Messaging DBR Manifest"
        Dim strRptDir As String = "" '"P:\Dept\Messaging\DBR Manifest\"
        Dim strDevice_IDsIN As String = ""
        Dim ArrLstDeviceIDs As New ArrayList()
        Dim dt, dtHasNERPallet, dtShipPalletRpt As DataTable
        Dim R1 As DataRow
        Dim objExcelRpt As Data.ExcelReports
        Dim strNERPallett_name As String = ""
        Dim objRpt As ReportDocument

        Try
            If Me.lstNER_SNs.Items.Count = 0 Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            If Not Me.lblNERCust_ID.Text > 0 Or Not Me.lblNERCustomer.Text.Trim.Length > 0 Then
                MessageBox.Show("No customer data!")
                Exit Sub
            End If

            'Get correct directory
            getRptDirectoryInfo(Me.lblNERCust_ID.Text, Me.lblNERCustomer.Text, "NER", strRptTitle, strRptDir)

            If Not strRptDir.Trim.Length > 0 Then
                MessageBox.Show("No data file output directory.")
                Exit Sub
            End If

            '********************
            'Get Device_ID list
            '********************
            For Each R1 In Me._dtNERUnits.Rows
                If strDevice_IDsIN.Length > 0 Then strDevice_IDsIN &= ", "
                strDevice_IDsIN &= R1("Device_ID")

                If Not ArrLstDeviceIDs.Contains(R1("Device_ID")) Then
                    ArrLstDeviceIDs.Add(R1("Device_ID"))
                End If
            Next R1

            '****************************************
            'Check again: Devices have NER-Pallett asssigned
            '****************************************
            dtHasNERPallet = Me._objDBRManifest.GetDevicesHasPalletData(strDevice_IDsIN)
            If dtHasNERPallet.Rows.Count > 0 Then
                R1 = Nothing
                Me.lstAssignedNERPallet.Items.Clear()
                For Each R1 In dtHasNERPallet.Rows
                    Dim strTemp As String = R1("Device_SN") & " (" & R1("Pallett_Name") & ")"
                    If Me.lstAssignedNERPallet.Items.IndexOf(strTemp) < 0 Then
                        Me.lstAssignedNERPallet.Items.Add(strTemp)
                    End If
                Next R1
                Me.lstAssignedNERPallet.Visible = True : Me.lblAssignedNERPallet.Visible = True
                MessageBox.Show("Some devices in the list have NER-Pallet. Please refer to ""Assigned NER-Pallet"" list and remove them out from main list.")
                Exit Sub
            End If

            '************************************
            'Create and assigned Pallet to devices
            '************************************
            strNERPallett_name = Me._objDBRManifest.PalletizeAMS_DBRNERPallet(lblNERLoc_ID.Text, lblNERCust_ID.Text, _
                                                                            ArrLstDeviceIDs, Me._strWork_Dt, _
                                                                            Me._dtNERUnits.Rows.Count, "NER", PSS.Core.ApplicationUser.IDShift)


            If strNERPallett_name = "" Then
                Exit Sub    'Failed to create pallet
            End If

            '************************************
            'Create Excel Report
            '************************************
            dt = Me._objDBRManifest.GetNER_SNData(strDevice_IDsIN)

            objExcelRpt = New Data.ExcelReports()

            objExcelRpt.RunAMManifestReport(dt, strNERPallett_name, strRptDir, strRptTitle, True)

            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strNERPallett_name, dt.Rows.Count, "NER", "Fail", New String() {"NER Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If

            '************************************
            'Reset controls and global variables
            '************************************
            Me.lblNoneNER.Visible = False
            Me.lstNoneNER.Items.Clear()
            Me.lstNoneNER.Refresh()
            Me.lstNoneNER.Visible = False
            Me.lblAssignedNERPallet.Visible = False
            Me.lstAssignedNERPallet.Items.Clear()
            Me.lstAssignedNERPallet.Refresh()
            Me.lstAssignedNERPallet.Visible = False
            Me.btnNERDeleteAll.Enabled = False
            Me.btnNERDeleteOne.Enabled = False
            Me.btnCreateNERLot.Enabled = False
            Me.lblNERLoc_ID.Text = 0
            Me.lblNERCust_ID.Text = 0
            Me.lblNERCustomer.Text = ""
            Me._dtNERUnits.Rows.Clear()
            Me.lstNER_SNs.Items.Clear()
            Me.lstNER_SNs.Refresh()


            UpdateNERCount()
            SelectNER_SNText()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating NER Manifest")
        Finally
            objRpt = Nothing
            objExcelRpt = Nothing
            R1 = Nothing
            Generic.DisposeDT(dt)
            Generic.DisposeDT(dtHasNERPallet)
            Generic.DisposeDT(dtShipPalletRpt)
            Me.Enabled = True
            Me.txtNER_SN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    '*************************************************************************
    Private Sub btnRecreateNERManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecreateNERManifest.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim strRptTitle As String = ""
        Dim strRptDir As String = ""
        Dim strDevice_IDsIN As String = ""
        Dim dt, dt1 As DataTable
        Dim R1 As DataRow
        Dim objExcelRpt As Data.ExcelReports
        Dim strNERPallett_name As String = ""
        Dim objRpt As ReportDocument
        Dim booPrintRpt As Boolean = True
        Dim iNERCust_ID As Integer = 0
        Dim iNERLoc_ID As Integer = 0
        Dim strNERCustomer As String = ""

        Try
            strNERPallett_name = InputBox("Please enter Pallet Name:", "Information").Trim
            If strNERPallett_name.Length = 0 Then Exit Sub

            If InStr(strNERPallett_name.ToUpper, "NER") = 0 Then
                MessageBox.Show("Invalid NER pallet name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            dt = Me._objDBRManifest.GetDBRNERSNDataByPalletName(strNERPallett_name)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Can't find data for this pallet. Please check Pallet Name again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                iNERCust_ID = dt.Rows(0).Item("Cust_ID")
                iNERLoc_ID = dt.Rows(0).Item("Loc_ID")
                strNERCustomer = dt.Rows(0).Item("Customer")
                dt.Columns.Remove("Customer")
                dt.Columns.Remove("Loc_ID")
                dt.Columns.Remove("Cust_ID")

                getRptDirectoryInfo(iNERCust_ID, strNERCustomer, "NER", strRptTitle, strRptDir)

                If strRptDir.Trim.Length = 0 Then
                    MessageBox.Show("Invalid manifest report directory or file info.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf System.IO.File.Exists(strRptDir & strNERPallett_name & ".xls") = True Then
                    MessageBox.Show("The manifest report file is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Cursor.Current = Cursors.WaitCursor : Me.Enabled = False

                    If MessageBox.Show("Do you want to print the report?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then booPrintRpt = False

                    objExcelRpt = New Data.ExcelReports()

                    objExcelRpt.RunAMManifestReport(dt, strNERPallett_name, strRptDir, strRptTitle, True, booPrintRpt)

                    '************************************
                    'Reset controls and global variables
                    '************************************

                    SelectNER_SNText()

                    MsgBox("Completed.", MsgBoxStyle.Information, "Information")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating DBR Manifest")
        Finally
            objRpt = Nothing
            objExcelRpt = Nothing
            R1 = Nothing
            Generic.DisposeDT(dt)
            Generic.DisposeDT(dt1)
            Me.Enabled = True
            Me.txtNER_SN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnNER_ReprintLotLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNER_ReprintLotLabel.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim dt, dtShipPalletRpt As DataTable
        Dim strNERPallett_name As String
        Dim objRpt As ReportDocument
        Dim objMisc As Data.Buisness.Misc
        Dim iPallettQty As Integer = 0

        Try
            strNERPallett_name = ""

            strNERPallett_name = InputBox("Enter NER Pallet Name:", "Pallet", "").Trim.ToUpper

            If strNERPallett_name.Trim.Length = 0 Then Exit Sub

            If InStr(strNERPallett_name.ToUpper, "NER") = 0 Then
                MessageBox.Show("Invalid NER pallet name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            '************************************
            'Get Pallett information
            '************************************
            objMisc = New Data.Buisness.Misc()
            dt = objMisc.GetPalletInfo_ByPallettName(strNERPallett_name)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Pallet name does not exist.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSN.Focus()
                Exit Sub
            End If

            If Not IsDBNull(dt.Rows(0)("Pallett_QTY")) Then
                iPallettQty = dt.Rows(0)("Pallett_QTY")
            Else
                iPallettQty = Me._objDBRManifest.GetDevCountByPalletID(dt.Rows(0)("Pallett_ID"))
            End If

            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strNERPallett_name, iPallettQty, "NER", "Fail", New String() {"NER Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If

            SelectSNText()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Reprint Manifest Label")
        Finally
            objMisc = Nothing
            Me.Enabled = True
            Me.txtNER_SN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************
    Private Sub SelectNER_SNText()
        If Me.txtNER_SN.Text.Trim.Length > 0 Then Me.txtNER_SN.SelectAll()
        Me.txtNER_SN.Focus()
    End Sub

    '***************************************************************************************************************
    Private Sub OpenSelectNERReason()
        Dim ctrl As Control
        Dim i As Integer = 0
        Try
            ReDim Me._objNameNER(Me.tpNER.Controls.Count - 1)
            ReDim Me._objNameEnabledNER(Me.tpNER.Controls.Count - 1)

            For Each ctrl In Me.tpNER.Controls
                If Not ctrl.Name.ToUpper = "pnlReasonsNER".ToUpper Then
                    Me._objNameNER(i) = ctrl.Name
                    Me._objNameEnabledNER(i) = ctrl.Enabled

                    ctrl.Enabled = False
                    i += 1
                End If
            Next

            Me.pnlReasonsNER.Left = Me.tpNER.Width / 2 - Me.pnlReasonsNER.Width / 2
            Me.pnlReasonsNER.Top = Me.tpNER.Height / 2 - Me.pnlReasonsNER.Height / 2
            Me.pnlReasonsNER.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "OpenSelectNERReason", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************
    Private Sub AddNERUnitToList(ByVal strSN As String, ByVal iDevice_ID As Integer)
        Dim R1 As DataRow
        '*******************
        'Add Record
        '*******************
        Try
            R1 = Nothing
            R1 = Me._dtNERUnits.NewRow
            R1("Device_SN") = strSN
            R1("Device_ID") = iDevice_ID
            Me._dtNERUnits.Rows.Add(R1)
            Me._dtNERUnits.AcceptChanges()

            Me.lstNER_SNs.Items.Add(strSN)
            Me.lstNER_SNs.Refresh()

            If Me._dtNERUnits.Rows.Count > 0 Then Me.btnCreateNERLot.Enabled = True

            UpdateNERCount()

            Me.txtNER_SN.Text = ""
            SelectNER_SNText()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "AddNERUnitToList", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************
    Private Sub UpdateNERCount()
        Dim iStart As Integer

        Try
            Me.rtfNERSNCount.Text = "SN Count: " & Me.lstNER_SNs.Items.Count.ToString

            Me.rtfNERSNCount.SelectionStart = 0
            Me.rtfNERSNCount.SelectionLength = Me.rtfNERSNCount.Text.Length
            Me.rtfNERSNCount.SelectionAlignment = HorizontalAlignment.Center

            iStart = Me.rtfNERSNCount.Text.IndexOf(":")

            If iStart > -1 Then
                iStart += 2

                Me.rtfNERSNCount.SelectionStart = iStart
                Me.rtfNERSNCount.SelectionLength = Me.rtfNERSNCount.Text.Length - iStart
                Me.rtfNERSNCount.SelectionFont = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
                Me.rtfNERSNCount.SelectionColor = Color.Green
            End If

            If Me.lstNER_SNs.Items.Count > 0 Then
                Me.btnNERDeleteOne.Enabled = True
                Me.btnNERDeleteAll.Enabled = True
                Me.btnCreateNERLot.Enabled = True

            Else
                Me.btnNERDeleteOne.Enabled = False
                Me.btnNERDeleteAll.Enabled = False
                Me.btnCreateNERLot.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '***************************************************************************************************************
    Private Sub btnNER_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNER_OK.Click
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            'Save DBR reason
            objMisc.UPD(Me.lblNER_DeviceID.Text, Me.cboNERReasons.SelectedValue)
            CloseSelectNERReason()

            AddNERUnitToList(Me.lblNER_SN.Text, Me.lblNER_DeviceID.Text)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnNER_OK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
        End Try
    End Sub

    '***************************************************************************************************************
    Private Sub btnNER_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNER_Cancel.Click
        If MessageBox.Show("Do you want cancel?", "NER Reason", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Me.txtNER_SN.SelectAll()
            CloseSelectNERReason()
        End If
    End Sub


#End Region

#Region "Tab ControlDrawItem and Tests"
    '***************************************************************************************************************
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Try
            Dim g As Graphics = e.Graphics
            Dim tp As TabPage = TabControl1.TabPages(e.Index)
            Dim br As Brush
            Dim sf As New StringFormat()
            Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)

            Dim xFont As Font


            sf.Alignment = StringAlignment.Center



            Dim strTitle As String = tp.Text

            'If the current index is the Selected Index, change the color
            If TabControl1.SelectedIndex = e.Index Then
                'this is the background color of the tabpage
                'you could make this a stndard color for the selected page
                br = New SolidBrush(tp.BackColor)
                'this is the background color of the tab page
                g.FillRectangle(br, e.Bounds)
                'this is the background color of the tab page
                'you could make this a stndard color for the selected page
                br = New SolidBrush(tp.ForeColor)
                'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                xFont = New Font(TabControl1.Font, FontStyle.Bold)
                g.DrawString(strTitle, xFont, br, r, sf)
            Else
                'these are the standard colors for the unselected tab pages
                br = New SolidBrush(Color.WhiteSmoke)
                g.FillRectangle(br, e.Bounds)
                br = New SolidBrush(Color.Black)
                'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                xFont = New Font(TabControl1.Font, FontStyle.Regular)
                g.DrawString(strTitle, xFont, br, r, sf)
            End If
        Catch ex As Exception
        End Try
    End Sub

    '***************************************************************************************************************
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpenSelectDBRReason()
        OpenSelectNERReason()
    End Sub

    '***************************************************************************************************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        CloseSelectDBRReason()
        CloseSelectNERReason()
    End Sub

    '***************************************************************************************************************
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer

        For i = 1 To 200
            Me.lstSN.Items.Add("SN" & i.ToString)
        Next

    End Sub


#End Region


End Class
