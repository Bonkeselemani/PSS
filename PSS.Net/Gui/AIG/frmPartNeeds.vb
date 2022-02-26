Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmPartNeeds
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = "Part Need"
        Private _iLocID As Integer
        Private _iCustID As Integer
        Private _objAIG As PSS.Data.Buisness.AIG
        Private _booLoadData As Boolean = False
        Private _bEndUser As Boolean = True

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iLocID As Integer, ByVal iCustID As Integer, ByVal bEndUser As Boolean, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iLocID = iLocID
            _iCustID = iCustID
            _objAIG = New PSS.Data.Buisness.AIG()

            _bEndUser = bEndUser
            If _bEndUser Then
                Me.pnlPartNeed_Claim.Visible = True
                Me.pnlPartNeed_SN.Visible = False
            Else
                Me.pnlPartNeed_Claim.Visible = False
                Me.pnlPartNeed_SN.Visible = True
            End If
            _strScreenName = strScreenName
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
        Friend WithEvents tpPartNeeds As System.Windows.Forms.TabPage
        Friend WithEvents tpUpdatePO As System.Windows.Forms.TabPage
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblMake As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblDefectType2 As System.Windows.Forms.Label
        Friend WithEvents lblDefectType1 As System.Windows.Forms.Label
        Friend WithEvents lblErrDesc As System.Windows.Forms.Label
        Friend WithEvents cboNPOrders As C1.Win.C1List.C1Combo
        Friend WithEvents btnPNClear As System.Windows.Forms.Button
        Friend WithEvents btnPNRefreshPartList As System.Windows.Forms.Button
        Friend WithEvents btnPNRefreshOrdersList As System.Windows.Forms.Button
        Friend WithEvents dbgNPList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnPNCompleted As System.Windows.Forms.Button
        Friend WithEvents btnPORefresh As System.Windows.Forms.Button
        Friend WithEvents btnPOSave As System.Windows.Forms.Button
        Friend WithEvents dbgPONeedPartList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnPNDeleteRow As System.Windows.Forms.Button
        Friend WithEvents txtPO As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents grpPart As System.Windows.Forms.GroupBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtNotes As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtPartQty As System.Windows.Forms.TextBox
        Friend WithEvents txtPartDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
        Friend WithEvents pnlPartNeed_Claim As System.Windows.Forms.Panel
        Friend WithEvents pnlPartNeed_SN As System.Windows.Forms.Panel
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnPartNeed_ClearSN As System.Windows.Forms.Button
        Friend WithEvents btnPNUpdate As System.Windows.Forms.Button
        Friend WithEvents btnPNAdd As System.Windows.Forms.Button
        Friend WithEvents btnPN_ReOpen As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPartNeeds))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpPartNeeds = New System.Windows.Forms.TabPage()
            Me.btnPN_ReOpen = New System.Windows.Forms.Button()
            Me.pnlPartNeed_SN = New System.Windows.Forms.Panel()
            Me.btnPartNeed_ClearSN = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.pnlPartNeed_Claim = New System.Windows.Forms.Panel()
            Me.cboNPOrders = New C1.Win.C1List.C1Combo()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.btnPNRefreshOrdersList = New System.Windows.Forms.Button()
            Me.grpPart = New System.Windows.Forms.GroupBox()
            Me.btnPNAdd = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtNotes = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtPartQty = New System.Windows.Forms.TextBox()
            Me.txtPartDesc = New System.Windows.Forms.TextBox()
            Me.txtPartNo = New System.Windows.Forms.TextBox()
            Me.btnPNUpdate = New System.Windows.Forms.Button()
            Me.btnPNClear = New System.Windows.Forms.Button()
            Me.btnPNDeleteRow = New System.Windows.Forms.Button()
            Me.btnPNCompleted = New System.Windows.Forms.Button()
            Me.btnPNRefreshPartList = New System.Windows.Forms.Button()
            Me.dbgNPList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblErrDesc = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblMake = New System.Windows.Forms.Label()
            Me.lblDefectType2 = New System.Windows.Forms.Label()
            Me.lblDefectType1 = New System.Windows.Forms.Label()
            Me.tpUpdatePO = New System.Windows.Forms.TabPage()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtPO = New System.Windows.Forms.TextBox()
            Me.btnPOSave = New System.Windows.Forms.Button()
            Me.btnPORefresh = New System.Windows.Forms.Button()
            Me.dbgPONeedPartList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabControl1.SuspendLayout()
            Me.tpPartNeeds.SuspendLayout()
            Me.pnlPartNeed_SN.SuspendLayout()
            Me.pnlPartNeed_Claim.SuspendLayout()
            CType(Me.cboNPOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpPart.SuspendLayout()
            CType(Me.dbgNPList, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpUpdatePO.SuspendLayout()
            CType(Me.dbgPONeedPartList, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpPartNeeds, Me.tpUpdatePO})
            Me.TabControl1.Location = New System.Drawing.Point(16, 0)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(888, 640)
            Me.TabControl1.TabIndex = 0
            '
            'tpPartNeeds
            '
            Me.tpPartNeeds.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpPartNeeds.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPN_ReOpen, Me.pnlPartNeed_SN, Me.pnlPartNeed_Claim, Me.grpPart, Me.btnPNDeleteRow, Me.btnPNCompleted, Me.btnPNRefreshPartList, Me.dbgNPList, Me.lblErrDesc, Me.lblModel, Me.lblMake, Me.lblDefectType2, Me.lblDefectType1})
            Me.tpPartNeeds.Location = New System.Drawing.Point(4, 22)
            Me.tpPartNeeds.Name = "tpPartNeeds"
            Me.tpPartNeeds.Size = New System.Drawing.Size(880, 614)
            Me.tpPartNeeds.TabIndex = 0
            Me.tpPartNeeds.Text = "Part Needs"
            '
            'btnPN_ReOpen
            '
            Me.btnPN_ReOpen.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnPN_ReOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPN_ReOpen.Location = New System.Drawing.Point(232, 520)
            Me.btnPN_ReOpen.Name = "btnPN_ReOpen"
            Me.btnPN_ReOpen.Size = New System.Drawing.Size(112, 32)
            Me.btnPN_ReOpen.TabIndex = 139
            Me.btnPN_ReOpen.Text = "Re-Open Claim"
            '
            'pnlPartNeed_SN
            '
            Me.pnlPartNeed_SN.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPartNeed_ClearSN, Me.Label6, Me.TextBox1})
            Me.pnlPartNeed_SN.Location = New System.Drawing.Point(8, 64)
            Me.pnlPartNeed_SN.Name = "pnlPartNeed_SN"
            Me.pnlPartNeed_SN.Size = New System.Drawing.Size(336, 48)
            Me.pnlPartNeed_SN.TabIndex = 1
            '
            'btnPartNeed_ClearSN
            '
            Me.btnPartNeed_ClearSN.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnPartNeed_ClearSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPartNeed_ClearSN.ForeColor = System.Drawing.Color.Black
            Me.btnPartNeed_ClearSN.Location = New System.Drawing.Point(264, 24)
            Me.btnPartNeed_ClearSN.Name = "btnPartNeed_ClearSN"
            Me.btnPartNeed_ClearSN.Size = New System.Drawing.Size(64, 20)
            Me.btnPartNeed_ClearSN.TabIndex = 156
            Me.btnPartNeed_ClearSN.Text = "Clear"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Black
            Me.Label6.Location = New System.Drawing.Point(8, 8)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(136, 16)
            Me.Label6.TabIndex = 155
            Me.Label6.Text = "S/N :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(8, 24)
            Me.TextBox1.MaxLength = 45
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(240, 20)
            Me.TextBox1.TabIndex = 154
            Me.TextBox1.Text = ""
            '
            'pnlPartNeed_Claim
            '
            Me.pnlPartNeed_Claim.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboNPOrders, Me.Label7, Me.btnPNRefreshOrdersList})
            Me.pnlPartNeed_Claim.Location = New System.Drawing.Point(8, 4)
            Me.pnlPartNeed_Claim.Name = "pnlPartNeed_Claim"
            Me.pnlPartNeed_Claim.Size = New System.Drawing.Size(336, 56)
            Me.pnlPartNeed_Claim.TabIndex = 0
            '
            'cboNPOrders
            '
            Me.cboNPOrders.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboNPOrders.Caption = ""
            Me.cboNPOrders.CaptionHeight = 17
            Me.cboNPOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboNPOrders.ColumnCaptionHeight = 17
            Me.cboNPOrders.ColumnFooterHeight = 17
            Me.cboNPOrders.ContentHeight = 15
            Me.cboNPOrders.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboNPOrders.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboNPOrders.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboNPOrders.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboNPOrders.EditorHeight = 15
            Me.cboNPOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboNPOrders.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboNPOrders.ItemHeight = 15
            Me.cboNPOrders.Location = New System.Drawing.Point(8, 32)
            Me.cboNPOrders.MatchEntryTimeout = CType(2000, Long)
            Me.cboNPOrders.MaxDropDownItems = CType(5, Short)
            Me.cboNPOrders.MaxLength = 32767
            Me.cboNPOrders.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboNPOrders.Name = "cboNPOrders"
            Me.cboNPOrders.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboNPOrders.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboNPOrders.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboNPOrders.Size = New System.Drawing.Size(320, 21)
            Me.cboNPOrders.TabIndex = 126
            Me.cboNPOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(8, 16)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(136, 16)
            Me.Label7.TabIndex = 127
            Me.Label7.Text = "Open Claims :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnPNRefreshOrdersList
            '
            Me.btnPNRefreshOrdersList.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnPNRefreshOrdersList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPNRefreshOrdersList.ForeColor = System.Drawing.Color.Black
            Me.btnPNRefreshOrdersList.Location = New System.Drawing.Point(264, 6)
            Me.btnPNRefreshOrdersList.Name = "btnPNRefreshOrdersList"
            Me.btnPNRefreshOrdersList.Size = New System.Drawing.Size(64, 20)
            Me.btnPNRefreshOrdersList.TabIndex = 132
            Me.btnPNRefreshOrdersList.Text = "Refresh"
            '
            'grpPart
            '
            Me.grpPart.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPNAdd, Me.Label4, Me.txtNotes, Me.Label3, Me.Label2, Me.Label1, Me.txtPartQty, Me.txtPartDesc, Me.txtPartNo, Me.btnPNUpdate, Me.btnPNClear})
            Me.grpPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpPart.Location = New System.Drawing.Point(8, 304)
            Me.grpPart.Name = "grpPart"
            Me.grpPart.Size = New System.Drawing.Size(336, 200)
            Me.grpPart.TabIndex = 2
            Me.grpPart.TabStop = False
            Me.grpPart.Text = "Part Info"
            '
            'btnPNAdd
            '
            Me.btnPNAdd.BackColor = System.Drawing.Color.LimeGreen
            Me.btnPNAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPNAdd.Location = New System.Drawing.Point(48, 168)
            Me.btnPNAdd.Name = "btnPNAdd"
            Me.btnPNAdd.Size = New System.Drawing.Size(80, 20)
            Me.btnPNAdd.TabIndex = 157
            Me.btnPNAdd.Text = "Add"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(0, 72)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(88, 16)
            Me.Label4.TabIndex = 156
            Me.Label4.Text = "Note:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtNotes
            '
            Me.txtNotes.Location = New System.Drawing.Point(88, 72)
            Me.txtNotes.MaxLength = 100
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.Size = New System.Drawing.Size(240, 48)
            Me.txtNotes.TabIndex = 3
            Me.txtNotes.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(0, 136)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 16)
            Me.Label3.TabIndex = 155
            Me.Label3.Text = "Part Qty:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(0, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(88, 16)
            Me.Label2.TabIndex = 154
            Me.Label2.Text = "Part Description:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(24, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 16)
            Me.Label1.TabIndex = 153
            Me.Label1.Text = "Part #:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtPartQty
            '
            Me.txtPartQty.Enabled = False
            Me.txtPartQty.Location = New System.Drawing.Point(88, 136)
            Me.txtPartQty.MaxLength = 2
            Me.txtPartQty.Name = "txtPartQty"
            Me.txtPartQty.Size = New System.Drawing.Size(60, 20)
            Me.txtPartQty.TabIndex = 4
            Me.txtPartQty.TabStop = False
            Me.txtPartQty.Text = "1"
            '
            'txtPartDesc
            '
            Me.txtPartDesc.Location = New System.Drawing.Point(88, 48)
            Me.txtPartDesc.MaxLength = 100
            Me.txtPartDesc.Name = "txtPartDesc"
            Me.txtPartDesc.Size = New System.Drawing.Size(240, 20)
            Me.txtPartDesc.TabIndex = 2
            Me.txtPartDesc.Text = ""
            '
            'txtPartNo
            '
            Me.txtPartNo.Location = New System.Drawing.Point(88, 24)
            Me.txtPartNo.MaxLength = 45
            Me.txtPartNo.Name = "txtPartNo"
            Me.txtPartNo.Size = New System.Drawing.Size(240, 20)
            Me.txtPartNo.TabIndex = 1
            Me.txtPartNo.Text = ""
            '
            'btnPNUpdate
            '
            Me.btnPNUpdate.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnPNUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPNUpdate.Location = New System.Drawing.Point(152, 168)
            Me.btnPNUpdate.Name = "btnPNUpdate"
            Me.btnPNUpdate.Size = New System.Drawing.Size(80, 20)
            Me.btnPNUpdate.TabIndex = 4
            Me.btnPNUpdate.Text = "Update"
            Me.btnPNUpdate.Visible = False
            '
            'btnPNClear
            '
            Me.btnPNClear.BackColor = System.Drawing.Color.Silver
            Me.btnPNClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPNClear.Location = New System.Drawing.Point(256, 168)
            Me.btnPNClear.Name = "btnPNClear"
            Me.btnPNClear.Size = New System.Drawing.Size(64, 20)
            Me.btnPNClear.TabIndex = 5
            Me.btnPNClear.Text = "Clear"
            '
            'btnPNDeleteRow
            '
            Me.btnPNDeleteRow.BackColor = System.Drawing.Color.Red
            Me.btnPNDeleteRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPNDeleteRow.ForeColor = System.Drawing.Color.White
            Me.btnPNDeleteRow.Location = New System.Drawing.Point(352, 8)
            Me.btnPNDeleteRow.Name = "btnPNDeleteRow"
            Me.btnPNDeleteRow.Size = New System.Drawing.Size(224, 20)
            Me.btnPNDeleteRow.TabIndex = 4
            Me.btnPNDeleteRow.Text = "Delete a Part (Selected Row)"
            '
            'btnPNCompleted
            '
            Me.btnPNCompleted.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnPNCompleted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPNCompleted.Location = New System.Drawing.Point(8, 520)
            Me.btnPNCompleted.Name = "btnPNCompleted"
            Me.btnPNCompleted.Size = New System.Drawing.Size(120, 32)
            Me.btnPNCompleted.TabIndex = 3
            Me.btnPNCompleted.Text = "Completed"
            '
            'btnPNRefreshPartList
            '
            Me.btnPNRefreshPartList.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnPNRefreshPartList.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnPNRefreshPartList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPNRefreshPartList.ForeColor = System.Drawing.Color.Black
            Me.btnPNRefreshPartList.Location = New System.Drawing.Point(800, 8)
            Me.btnPNRefreshPartList.Name = "btnPNRefreshPartList"
            Me.btnPNRefreshPartList.Size = New System.Drawing.Size(64, 20)
            Me.btnPNRefreshPartList.TabIndex = 5
            Me.btnPNRefreshPartList.Text = "Refresh"
            '
            'dbgNPList
            '
            Me.dbgNPList.AllowSort = False
            Me.dbgNPList.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgNPList.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgNPList.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgNPList.Location = New System.Drawing.Point(352, 32)
            Me.dbgNPList.Name = "dbgNPList"
            Me.dbgNPList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgNPList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgNPList.PreviewInfo.ZoomFactor = 75
            Me.dbgNPList.Size = New System.Drawing.Size(512, 488)
            Me.dbgNPList.TabIndex = 6
            Me.dbgNPList.Text = "C1TrueDBGrid1"
            Me.dbgNPList.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
            "3{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Contro" & _
            "lText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style" & _
            "15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Capti" & _
            "onHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>484</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 508, 484</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 508, 484</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14""" & _
            " /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblErrDesc
            '
            Me.lblErrDesc.BackColor = System.Drawing.Color.White
            Me.lblErrDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblErrDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblErrDesc.ForeColor = System.Drawing.Color.Black
            Me.lblErrDesc.Location = New System.Drawing.Point(16, 216)
            Me.lblErrDesc.Name = "lblErrDesc"
            Me.lblErrDesc.Size = New System.Drawing.Size(320, 80)
            Me.lblErrDesc.TabIndex = 138
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(16, 152)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(320, 16)
            Me.lblModel.TabIndex = 129
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblMake
            '
            Me.lblMake.BackColor = System.Drawing.Color.White
            Me.lblMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMake.ForeColor = System.Drawing.Color.Black
            Me.lblMake.Location = New System.Drawing.Point(16, 128)
            Me.lblMake.Name = "lblMake"
            Me.lblMake.Size = New System.Drawing.Size(320, 16)
            Me.lblMake.TabIndex = 128
            Me.lblMake.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblDefectType2
            '
            Me.lblDefectType2.BackColor = System.Drawing.Color.White
            Me.lblDefectType2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDefectType2.ForeColor = System.Drawing.Color.Black
            Me.lblDefectType2.Location = New System.Drawing.Point(16, 192)
            Me.lblDefectType2.Name = "lblDefectType2"
            Me.lblDefectType2.Size = New System.Drawing.Size(320, 16)
            Me.lblDefectType2.TabIndex = 131
            Me.lblDefectType2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblDefectType1
            '
            Me.lblDefectType1.BackColor = System.Drawing.Color.White
            Me.lblDefectType1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDefectType1.ForeColor = System.Drawing.Color.Black
            Me.lblDefectType1.Location = New System.Drawing.Point(16, 168)
            Me.lblDefectType1.Name = "lblDefectType1"
            Me.lblDefectType1.Size = New System.Drawing.Size(320, 16)
            Me.lblDefectType1.TabIndex = 130
            Me.lblDefectType1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'tpUpdatePO
            '
            Me.tpUpdatePO.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpUpdatePO.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.txtPO, Me.btnPOSave, Me.btnPORefresh, Me.dbgPONeedPartList})
            Me.tpUpdatePO.Location = New System.Drawing.Point(4, 22)
            Me.tpUpdatePO.Name = "tpUpdatePO"
            Me.tpUpdatePO.Size = New System.Drawing.Size(880, 614)
            Me.tpUpdatePO.TabIndex = 1
            Me.tpUpdatePO.Text = "Update PO"
            '
            'Label5
            '
            Me.Label5.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(265, 17)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(113, 16)
            Me.Label5.TabIndex = 153
            Me.Label5.Text = "PO:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
            Me.Label5.Visible = False
            '
            'txtPO
            '
            Me.txtPO.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.txtPO.Location = New System.Drawing.Point(384, 16)
            Me.txtPO.Name = "txtPO"
            Me.txtPO.Size = New System.Drawing.Size(168, 20)
            Me.txtPO.TabIndex = 152
            Me.txtPO.Text = ""
            Me.txtPO.Visible = False
            '
            'btnPOSave
            '
            Me.btnPOSave.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnPOSave.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnPOSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPOSave.Location = New System.Drawing.Point(568, 16)
            Me.btnPOSave.Name = "btnPOSave"
            Me.btnPOSave.Size = New System.Drawing.Size(152, 18)
            Me.btnPOSave.TabIndex = 151
            Me.btnPOSave.Text = "Add PO To Selected Row"
            Me.btnPOSave.Visible = False
            '
            'btnPORefresh
            '
            Me.btnPORefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnPORefresh.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnPORefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPORefresh.Location = New System.Drawing.Point(784, 16)
            Me.btnPORefresh.Name = "btnPORefresh"
            Me.btnPORefresh.Size = New System.Drawing.Size(64, 18)
            Me.btnPORefresh.TabIndex = 150
            Me.btnPORefresh.Text = "Refresh"
            '
            'dbgPONeedPartList
            '
            Me.dbgPONeedPartList.AllowSort = False
            Me.dbgPONeedPartList.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgPONeedPartList.FilterBar = True
            Me.dbgPONeedPartList.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPONeedPartList.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgPONeedPartList.Location = New System.Drawing.Point(16, 56)
            Me.dbgPONeedPartList.Name = "dbgPONeedPartList"
            Me.dbgPONeedPartList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPONeedPartList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPONeedPartList.PreviewInfo.ZoomFactor = 75
            Me.dbgPONeedPartList.Size = New System.Drawing.Size(832, 424)
            Me.dbgPONeedPartList.TabIndex = 7
            Me.dbgPONeedPartList.Text = "C1TrueDBGrid1"
            Me.dbgPONeedPartList.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{BackColor:WhiteSmoke;}Footer{}C" & _
            "aption{AlignHorz:Center;}Style1{}Normal{BackColor:LightSteelBlue;}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1," & _
            " 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}St" & _
            "yle11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Me" & _
            "rgeView Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""" & _
            "17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" De" & _
            "fRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>420<" & _
            "/Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor" & _
            """ me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle par" & _
            "ent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Group" & _
            "Style parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /" & _
            "><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""I" & _
            "nactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelecto" & _
            "rStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" m" & _
            "e=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 828, 420</Cl" & _
            "ientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1T" & _
            "rueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style " & _
            "parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style pare" & _
            "nt=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style paren" & _
            "t=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""N" & _
            "ormal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""" & _
            "Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style paren" & _
            "t=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Default" & _
            "RecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 828, 420</ClientArea><Print" & _
            "PageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Sty" & _
            "le15"" /></Blob>"
            '
            'frmPartNeeds
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(936, 678)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmPartNeeds"
            Me.Text = "frmPartNeeds"
            Me.TabControl1.ResumeLayout(False)
            Me.tpPartNeeds.ResumeLayout(False)
            Me.pnlPartNeed_SN.ResumeLayout(False)
            Me.pnlPartNeed_Claim.ResumeLayout(False)
            CType(Me.cboNPOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpPart.ResumeLayout(False)
            CType(Me.dbgNPList, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpUpdatePO.ResumeLayout(False)
            CType(Me.dbgPONeedPartList, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Part Need"
        '******************************************************************************************************
        Private Sub frmPartNeeds_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If _bEndUser Then LoadOrders()
                LoadPONeedPartList()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub LoadOrders()
            Dim dt As DataTable

            Try
                dt = _objAIG.GetOpenNotShip(Me._iCustID, True)
                _booLoadData = True
                Misc.PopulateC1DropDownList(Me.cboNPOrders, dt, "ClaimNo", "EW_ID")
                Me.cboNPOrders.SelectedValue = 0

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                _booLoadData = False
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNRefreshOrdersList.Click
            Try
                Me.lblMake.Text = "" : Me.lblModel.Text = ""
                Me.lblDefectType1.Text = "" : Me.lblDefectType2.Text = ""
                Me.lblErrDesc.Text = "" : Me.dbgNPList.DataSource = Nothing
                btnClear_Click(Nothing, Nothing)
                LoadOrders()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnPNRefreshPartList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNRefreshPartList.Click
            Try
                Me.dbgNPList.DataSource = Nothing
                If Me.cboNPOrders.SelectedValue > 0 Then
                    LoadParNeedsList(CInt(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID")))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub cboOrders_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNPOrders.SelectedValueChanged
            Dim iWOID As Integer = 0
            Dim dt As DataTable

            Try
                If Me._booLoadData = True Then Exit Sub

                btnClear_Click(Nothing, Nothing)
                Me.lblMake.Text = "" : Me.lblModel.Text = ""
                Me.lblDefectType1.Text = "" : Me.lblDefectType2.Text = ""
                Me.lblErrDesc.Text = "" : Me.dbgNPList.Enabled = True
                If Not IsNothing(Me.dbgNPList.DataSource) Then Me.dbgNPList.DataSource = Nothing

                If Me.cboNPOrders.SelectedValue > 0 Then

                    If Not IsDBNull(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID")) _
                      AndAlso Convert.ToInt32(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID")) > 0 Then
                        iWOID = CInt(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID"))
                        If iWOID > 0 Then 'SN discrepancy validating
                            dt = Me._objAIG.Get_SN_DiscrepancyData(Me._iLocID, iWOID)
                            If dt.Rows.Count = 1 Then
                                If dt.Rows(0).Item("SN_Discp_Flag") = 1 AndAlso dt.Rows(0).Item("SN_Discp_AV_ID") <> 1 Then
                                    MessageBox.Show("SN Discrepancy hasn't approved. Can't process the part need.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If
                            ElseIf dt.Rows.Count > 1 Then
                                MessageBox.Show("Invalid data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        End If
                    End If

                    Me.lblMake.Text = "Make: " & Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("Brand")
                    Me.lblModel.Text = "Model: " & Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("Model")
                    Me.lblDefectType1.Text = "Defective 1: " & Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("DefectType1")
                    Me.lblDefectType2.Text = "Defective 2: " & Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("DefectType2")
                    Me.lblErrDesc.Text = "Error Description: " & Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("ErrDesc_ItemSKU")

                    'If Not IsDBNull(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID")) _
                    '   AndAlso Convert.ToInt32(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID")) > 0 Then
                    '    iWOID = CInt(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID"))
                    '    LoadParNeedsList(iWOID)
                    'End If
                    If iWOID > 0 Then
                        LoadParNeedsList(iWOID)
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOrders_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub LoadParNeedsList(ByVal iWOID As Integer)
            Dim dt As DataTable
            Try
                dt = Me._objAIG.GetPartNeeds(iWOID)
                With Me.dbgNPList
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("PN_ID").Width = 60
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnPNAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNAdd.Click
            Dim i As Integer
            Dim iWO_ID As Integer = 0, iPN_ID As Integer = 0
            Dim strErrMsg As String = ""

            Try
                If Me.cboNPOrders.SelectedValue = 0 Then
                    MessageBox.Show("Please select order", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboNPOrders.SelectAll() : Me.cboNPOrders.Focus()
                ElseIf Me.txtPartNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter part #", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPartNo.Focus()
                ElseIf Me.txtPartDesc.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter part description.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPartDesc.Focus()
                ElseIf Me.txtPartQty.Text.Trim.Length = 0 OrElse CInt(Me.txtPartQty.Text) = 0 Then
                    MessageBox.Show("Please enter a valid part quantitiy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPartQty.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    iWO_ID = CInt(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID"))
                    i = Me._objAIG.AddPartNeeds(iWO_ID, Me.txtPartNo.Text.Trim, Me.txtPartDesc.Text.Trim, Me.txtNotes.Text.Trim, CInt(Me.txtPartQty.Text), PSS.Core.ApplicationUser.IDuser, strErrMsg)

                    If strErrMsg.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPartNo.SelectAll() : Me.txtPartNo.Focus()
                    Else
                        If i > 0 Then
                            Me.txtPartNo.Text = "" : Me.txtPartDesc.Text = "" : Me.txtNotes.Text = ""
                            Me.txtPartQty.Text = "1" : Me.Enabled = True : Me.txtPartNo.Focus()
                            Me.LoadParNeedsList(iWO_ID)
                        Else
                            MessageBox.Show("System has failed to save data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtPartNo.SelectAll() : Me.txtPartNo.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtPartNo_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub dbgNPList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgNPList.DoubleClick
            Try
                If Not IsNothing(Me.dbgNPList.DataSource) AndAlso Me.dbgNPList.RowCount > 0 Then
                    Me.txtPartNo.Text = Me.dbgNPList.Columns("Part #").CellValue(Me.dbgNPList.Row)
                    Me.txtPartDesc.Text = Me.dbgNPList.Columns("Part Description").CellValue(Me.dbgNPList.Row)
                    Me.txtNotes.Text = Me.dbgNPList.Columns("Notes").CellValue(Me.dbgNPList.Row)
                    Me.txtPartQty.Text = Me.dbgNPList.Columns("Qty").CellValue(Me.dbgNPList.Row)
                    Me.btnPNAdd.Visible = False
                    Me.btnPNUpdate.Visible = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgNPList_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub dbgNPList_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgNPList.RowColChange
            Try
                If Not IsNothing(Me.dbgNPList.DataSource) AndAlso Me.dbgNPList.RowCount > 0 Then
                    Me.btnClear_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgNPList_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnPNUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNUpdate.Click
            Dim i As Integer
            Dim iWO_ID As Integer = 0, iPN_ID As Integer = 0
            Dim strErrMsg As String = ""

            Try
                If Me.cboNPOrders.SelectedValue = 0 Then
                    MessageBox.Show("Please select order", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboNPOrders.SelectAll() : Me.cboNPOrders.Focus()
                ElseIf Me.txtPartNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter part #", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPartNo.Focus()
                ElseIf Me.txtPartDesc.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter part description.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPartDesc.Focus()
                ElseIf Me.txtPartQty.Text.Trim.Length = 0 OrElse CInt(Me.txtPartQty.Text) = 0 Then
                    MessageBox.Show("Please enter a valid part quantitiy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPartQty.Focus()
                ElseIf Me.dbgNPList.Columns("PN_ID").CellValue(Me.dbgNPList.Row).ToString = "" Or Me.dbgNPList.Columns("PN_ID").CellValue(Me.dbgNPList.Row).ToString = "0" Then
                    MessageBox.Show("Part need ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPartQty.Focus()
                ElseIf MessageBox.Show("Are you sure you want to update PN_ID " & Me.dbgNPList.Columns("PN_ID").CellValue(Me.dbgNPList.Row) & "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    iWO_ID = CInt(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID"))
                    i = Me._objAIG.UpdatePartNeeds(Me.dbgNPList.Columns("PN_ID").CellValue(Me.dbgNPList.Row), Me.txtPartNo.Text.Trim, Me.txtPartDesc.Text.Trim, Me.txtNotes.Text.Trim, CInt(Me.txtPartQty.Text), PSS.Core.ApplicationUser.IDuser, strErrMsg)

                    If strErrMsg.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPartNo.SelectAll() : Me.txtPartNo.Focus()
                    Else
                        If i > 0 Then
                            Me.txtPartNo.Text = "" : Me.txtPartDesc.Text = "" : Me.txtNotes.Text = ""
                            Me.txtPartQty.Text = "1" : Me.Enabled = True : Me.dbgNPList.Enabled = True : Me.txtPartNo.Focus()
                            Me.LoadParNeedsList(iWO_ID)
                        Else
                            MessageBox.Show("System has failed to save data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtPartNo.SelectAll() : Me.txtPartNo.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtPartNo_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnPNCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNCompleted.Click
            Const iWipOnerID As Integer = 8 'Waiting Parts
            Dim i, iPssiStatusID As Integer
            Dim strWorkstation, strPssiStatus As String
            Dim dtDevice As DataTable

            Try
                If Me.cboNPOrders.SelectedValue = 0 Then
                    MessageBox.Show("Please select order", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboNPOrders.SelectAll() : Me.cboNPOrders.Focus()
                Else
                    strWorkstation = "" : strPssiStatus = ""
                    dtDevice = Generic.GetDevicesInWO(CInt(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID")))
                    If dtDevice.Rows.Count = 1 Then
                        iPssiStatusID = 6   'Waiting Parts
                    Else
                        iPssiStatusID = 11   'Part Ordered
                    End If
                    strPssiStatus = PSS.Data.Buisness.TMIRecShip.GetTMIStatusDesc(iPssiStatusID)
                    strWorkstation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iCustID, , )
                    If strPssiStatus.Trim.Length = 0 Then
                        MessageBox.Show("Pssi status description is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf strWorkstation.Trim.Length = 0 Then
                        MessageBox.Show("Workflow is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        i = Me._objAIG.CompletedPartEstimate(CInt(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID")), Core.ApplicationUser.IDuser)
                        Me._objAIG.SetPssiStatus(CInt(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID")), iPssiStatusID, strPssiStatus)
                        If dtDevice.Rows.Count = 1 Then Generic.SetTcelloptWorkStationForDevice(strWorkstation, dtDevice.Rows(0)("Device_ID"), Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, iWipOnerID, , , , , )
                        Me.LoadOrders()
                        LoadPONeedPartList()
                        btnRefresh_Click(sender, e)
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPNCompleted_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnPN_ReOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPN_ReOpen.Click
            Dim i, iWOID As Integer
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strClaimNo As String = ""

            Try
                strClaimNo = InputBox("Enter Claim #:").Trim

                If strClaimNo.Trim.Length = 0 Then
                    Exit Sub
                Else
                    dt = Generic.GetCustWo(strClaimNo, Data.Buisness.AIG.LOCID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Claim # does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboNPOrders.SelectAll() : Me.cboNPOrders.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Claim # existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboNPOrders.SelectAll() : Me.cboNPOrders.Focus()
                    ElseIf dt.Rows(0)("ClosePreOrderPart").ToString = "0" Then
                        MessageBox.Show("Claim is open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboNPOrders.SelectAll() : Me.cboNPOrders.Focus()
                    ElseIf Not IsDBNull(dt.Rows(0)("WO_DateShip")) Then
                        MessageBox.Show("Claim is shipped. Can't re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboNPOrders.SelectAll() : Me.cboNPOrders.Focus()
                    Else
                        iWOID = CInt(dt.Rows(0)("WO_ID"))
                        dt = Me._objAIG.GetRecDevicesInWO(iWOID)
                        For Each R1 In dt.Rows
                            If Not IsDBNull(R1("Device_Dateship")) Then
                                MessageBox.Show("S/N '" & R1("Device_SN") & "' has been shipped. Can't re-open claim.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.cboNPOrders.SelectAll() : Me.cboNPOrders.Focus() : Exit Sub
                            ElseIf Not IsDBNull(R1("Pallett_ID")) AndAlso CInt(R1("Pallett_ID")) > 0 Then
                                MessageBox.Show("S/N '" & R1("Device_SN") & "' belongs to a shipping box. Can't re-open claim.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.cboNPOrders.SelectAll() : Me.cboNPOrders.Focus() : Exit Sub
                            End If
                        Next R1

                        i = Me._objAIG.ReOpenCompletedPartEstimate(dt.Rows(0)("WO_ID"))
                        Me.LoadOrders()
                        LoadPONeedPartList()
                        btnRefresh_Click(sender, e)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPN_ReOpen_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNClear.Click
            Try
                Me.btnPNAdd.Visible = True : Me.btnPNUpdate.Visible = False
                Me.txtPartNo.Text = ""
                Me.txtPartDesc.Text = ""
                Me.txtNotes.Text = ""
                Me.txtPartQty.Text = "1"
                Me.txtPartNo.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub txts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            Try
                If sender.name = "txtPartNo" Then
                    If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                        e.Handled = True
                    End If
                ElseIf sender.name = "txtPartDesc" Then
                    If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar) Or e.KeyChar.ToString = " ") Then
                        e.Handled = True
                    End If
                ElseIf sender.name = "txtNotes" Then
                    If e.KeyChar.ToString = "'" OrElse e.KeyChar.ToString = "\" Then
                        e.Handled = True
                    End If
                ElseIf sender.name = "txtPartQty" Then
                    If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txts_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnPNDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNDeleteRow.Click
            Dim i As Integer = 0
            Try
                If Me.cboNPOrders.SelectedValue = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dbgNPList.RowCount > 0 Then
                    If Not IsDBNull(Me.dbgNPList.Columns("PO").CellValue(Me.dbgNPList.Row)) AndAlso _
                       Me.dbgNPList.Columns("PO").CellValue(Me.dbgNPList.Row).ToString.Trim.Length > 0 Then
                        MessageBox.Show("Part # has PO assigned to it. Can't remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf MessageBox.Show("Are you sure you want to remove part # '" & Me.dbgNPList.Columns("Part #").CellValue(Me.dbgNPList.Row).ToString & "'?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        Exit Sub
                    Else
                        i = Me._objAIG.DeleteNeedPart(CInt(Me.dbgNPList.Columns("PN_ID").CellValue(Me.dbgNPList.Row)))
                        If i = 0 Then
                            MessageBox.Show("System has failed to remove selected row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            LoadParNeedsList(CInt(Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("WO_ID")))
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPNDeleteRow_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub txtPartQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartQty.KeyPress
            Dim allowed As String = "0123456789"
            Dim curchar As Integer = Asc(e.KeyChar)
            If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8) Then
                e.Handled = True
            End If
        End Sub

        '******************************************************************************************************
        Private Sub txtPartQty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartQty.KeyUp
            'Avoiding paste text into to the textbox or number with 0 at starting position
            If IsNumeric(Me.txtPartQty.Text) Then
                Dim iNum As Integer = Me.txtPartQty.Text
                If iNum > 0 Then
                    Me.txtPartQty.Text = iNum
                Else
                    Me.txtPartQty.Text = ""
                End If
            Else
                Me.txtPartQty.Text = ""
            End If
        End Sub


        '******************************************************************************************************
#End Region

#Region "Update PO"

        '******************************************************************************************************
        Private Sub LoadPONeedPartList()
            Dim dt As DataTable
            Try
                dt = Me._objAIG.GetCompletedPartEstimateList(Data.Buisness.AIG.LOCID, _bEndUser)
                With Me.dbgPONeedPartList
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("PN_ID").Visible = False
                    .Splits(0).DisplayColumns("WO_Closed").Visible = False
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnPORefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPORefresh.Click
            Try
                LoadPONeedPartList()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPORefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub txtPO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPO.KeyPress
            Try
                If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtPO_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnPOSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPOSave.Click
            Dim i, iRow As Integer
            Dim strDRA_IDs As String = ""

            Try
                If Me.txtPO.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter PO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPO.SelectAll() : Me.txtPO.Focus()
                ElseIf Me.dbgPONeedPartList.SelectedRows.Count > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    '*********************************
                    'loop through each selected row
                    '*********************************
                    For Each iRow In dbgPONeedPartList.SelectedRows
                        If Not IsDBNull(dbgPONeedPartList.Columns("PO").CellValue(iRow)) AndAlso IsDBNull(dbgPONeedPartList.Columns("PO").CellValue(iRow)).ToString.Trim.Length > 0 Then
                            If MessageBox.Show("Part # " & dbgPONeedPartList.Columns("Part #").CellValue(iRow) & " has PO assigned to it. Are you sure you want to update to the new PO?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                Exit Sub
                            Else
                                If strDRA_IDs.Trim.Length > 0 Then strDRA_IDs &= ", "
                                strDRA_IDs &= dbgPONeedPartList.Columns("PN_ID").CellValue(iRow)
                            End If
                        Else
                            If strDRA_IDs.Trim.Length > 0 Then strDRA_IDs &= ", "
                            strDRA_IDs &= dbgPONeedPartList.Columns("PN_ID").CellValue(iRow)
                        End If
                    Next iRow

                    '*********************************
                    If strDRA_IDs.Trim.Length > 0 Then
                        i = Me._objAIG.UpdatePO(strDRA_IDs, Me.txtPO.Text.Trim, Core.ApplicationUser.IDuser)
                        If i = 0 Then
                            MessageBox.Show("System has failed to update PO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else

                            Me.LoadPONeedPartList()
                            Me.Enabled = True : Me.txtPO.SelectAll() : Me.txtPO.Focus()
                        End If
                    End If
                    '*********************************
                Else
                    MessageBox.Show("Please select a range of row to assign PO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPOSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub dbgPONeedPartList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgPONeedPartList.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()

                    objCopyAll.Text = "Copy all"
                    objCopySelected.Text = "Copy selected rows"

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "grdDevice_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dbgPONeedPartList)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dbgPONeedPartList)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '******************************************************************************************************

#End Region


    End Class
End Namespace