
Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmTF_AdminStationTrans_CreateWHBox
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _objTFMisc As Data.Buisness.TracFone.clsMisc
        Private _booPopulateData As Boolean = False
        Private _drInputData As DataRow = Nothing

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
            Me._strScreenName = strScreenName
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
        Friend WithEvents tpgAdminStationTransf As System.Windows.Forms.TabPage
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnTransfer As System.Windows.Forms.Button
        Friend WithEvents pnlST_InputVal As System.Windows.Forms.Panel
        Friend WithEvents txtST_InputVal As System.Windows.Forms.TextBox
        Friend WithEvents cboST_TranfTypes As C1.Win.C1List.C1Combo
        Friend WithEvents pnlST_ModelQty As System.Windows.Forms.Panel
        Friend WithEvents lblST_InputQty As System.Windows.Forms.Label
        Friend WithEvents lblST_Model As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lblST_InputLabel As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboST_NextStation As C1.Win.C1List.C1Combo
        Friend WithEvents pnlST_SNs As System.Windows.Forms.Panel
        Friend WithEvents lstST_SNs As System.Windows.Forms.ListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTF_AdminStationTrans_CreateWHBox))
			Me.TabControl1 = New System.Windows.Forms.TabControl()
			Me.tpgAdminStationTransf = New System.Windows.Forms.TabPage()
			Me.pnlST_SNs = New System.Windows.Forms.Panel()
			Me.lstST_SNs = New System.Windows.Forms.ListBox()
			Me.cboST_NextStation = New C1.Win.C1List.C1Combo()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnTransfer = New System.Windows.Forms.Button()
			Me.pnlST_ModelQty = New System.Windows.Forms.Panel()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.lblST_InputQty = New System.Windows.Forms.Label()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.lblST_Model = New System.Windows.Forms.Label()
			Me.pnlST_InputVal = New System.Windows.Forms.Panel()
			Me.lblST_InputLabel = New System.Windows.Forms.Label()
			Me.txtST_InputVal = New System.Windows.Forms.TextBox()
			Me.cboST_TranfTypes = New C1.Win.C1List.C1Combo()
			Me.Label9 = New System.Windows.Forms.Label()
			Me.TabControl1.SuspendLayout()
			Me.tpgAdminStationTransf.SuspendLayout()
			Me.pnlST_SNs.SuspendLayout()
			CType(Me.cboST_NextStation, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlST_ModelQty.SuspendLayout()
			Me.pnlST_InputVal.SuspendLayout()
			CType(Me.cboST_TranfTypes, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'TabControl1
			'
			Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgAdminStationTransf})
			Me.TabControl1.Location = New System.Drawing.Point(16, 16)
			Me.TabControl1.Name = "TabControl1"
			Me.TabControl1.SelectedIndex = 0
			Me.TabControl1.Size = New System.Drawing.Size(816, 456)
			Me.TabControl1.TabIndex = 0
			'
			'tpgAdminStationTransf
			'
			Me.tpgAdminStationTransf.BackColor = System.Drawing.Color.SteelBlue
			Me.tpgAdminStationTransf.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlST_SNs, Me.cboST_NextStation, Me.Label3, Me.btnCancel, Me.btnTransfer, Me.pnlST_ModelQty, Me.pnlST_InputVal, Me.cboST_TranfTypes, Me.Label9})
			Me.tpgAdminStationTransf.Location = New System.Drawing.Point(4, 22)
			Me.tpgAdminStationTransf.Name = "tpgAdminStationTransf"
			Me.tpgAdminStationTransf.Size = New System.Drawing.Size(808, 430)
			Me.tpgAdminStationTransf.TabIndex = 0
			Me.tpgAdminStationTransf.Text = "Admin Station Transfer"
			'
			'pnlST_SNs
			'
			Me.pnlST_SNs.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstST_SNs})
			Me.pnlST_SNs.Location = New System.Drawing.Point(8, 184)
			Me.pnlST_SNs.Name = "pnlST_SNs"
			Me.pnlST_SNs.Size = New System.Drawing.Size(376, 216)
			Me.pnlST_SNs.TabIndex = 127
			Me.pnlST_SNs.Visible = False
			'
			'lstST_SNs
			'
			Me.lstST_SNs.Location = New System.Drawing.Point(120, 8)
			Me.lstST_SNs.Name = "lstST_SNs"
			Me.lstST_SNs.Size = New System.Drawing.Size(248, 199)
			Me.lstST_SNs.TabIndex = 0
			'
			'cboST_NextStation
			'
			Me.cboST_NextStation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboST_NextStation.AutoCompletion = True
			Me.cboST_NextStation.AutoDropDown = True
			Me.cboST_NextStation.AutoSelect = True
			Me.cboST_NextStation.Caption = ""
			Me.cboST_NextStation.CaptionHeight = 17
			Me.cboST_NextStation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboST_NextStation.ColumnCaptionHeight = 17
			Me.cboST_NextStation.ColumnFooterHeight = 17
			Me.cboST_NextStation.ColumnHeaders = False
			Me.cboST_NextStation.ContentHeight = 15
			Me.cboST_NextStation.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboST_NextStation.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboST_NextStation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboST_NextStation.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboST_NextStation.EditorHeight = 15
			Me.cboST_NextStation.Enabled = False
			Me.cboST_NextStation.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.cboST_NextStation.ItemHeight = 15
			Me.cboST_NextStation.Location = New System.Drawing.Point(504, 16)
			Me.cboST_NextStation.MatchEntryTimeout = CType(2000, Long)
			Me.cboST_NextStation.MaxDropDownItems = CType(10, Short)
			Me.cboST_NextStation.MaxLength = 32767
			Me.cboST_NextStation.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboST_NextStation.Name = "cboST_NextStation"
			Me.cboST_NextStation.ReadOnly = True
			Me.cboST_NextStation.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboST_NextStation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboST_NextStation.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboST_NextStation.Size = New System.Drawing.Size(248, 21)
			Me.cboST_NextStation.TabIndex = 125
			Me.cboST_NextStation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label3
			'
			Me.Label3.BackColor = System.Drawing.Color.Transparent
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.ForeColor = System.Drawing.Color.White
			Me.Label3.Location = New System.Drawing.Point(408, 18)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(88, 16)
			Me.Label3.TabIndex = 126
			Me.Label3.Text = "To  :"
			Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'btnCancel
			'
			Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCancel.ForeColor = System.Drawing.Color.White
			Me.btnCancel.Location = New System.Drawing.Point(640, 64)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(112, 24)
			Me.btnCancel.TabIndex = 124
			Me.btnCancel.Text = "Clear"
			'
			'btnTransfer
			'
			Me.btnTransfer.BackColor = System.Drawing.Color.Green
			Me.btnTransfer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnTransfer.ForeColor = System.Drawing.Color.White
			Me.btnTransfer.Location = New System.Drawing.Point(440, 64)
			Me.btnTransfer.Name = "btnTransfer"
			Me.btnTransfer.Size = New System.Drawing.Size(120, 24)
			Me.btnTransfer.TabIndex = 123
			Me.btnTransfer.Text = "Transfer"
			'
			'pnlST_ModelQty
			'
			Me.pnlST_ModelQty.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.lblST_InputQty, Me.Label1, Me.lblST_Model})
			Me.pnlST_ModelQty.Location = New System.Drawing.Point(8, 104)
			Me.pnlST_ModelQty.Name = "pnlST_ModelQty"
			Me.pnlST_ModelQty.Size = New System.Drawing.Size(376, 72)
			Me.pnlST_ModelQty.TabIndex = 122
			'
			'Label2
			'
			Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.ForeColor = System.Drawing.Color.White
			Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.Label2.Location = New System.Drawing.Point(64, 8)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(48, 16)
			Me.Label2.TabIndex = 141
			Me.Label2.Text = "Model:"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'lblST_InputQty
			'
			Me.lblST_InputQty.BackColor = System.Drawing.Color.White
			Me.lblST_InputQty.ForeColor = System.Drawing.Color.Black
			Me.lblST_InputQty.Location = New System.Drawing.Point(120, 40)
			Me.lblST_InputQty.Name = "lblST_InputQty"
			Me.lblST_InputQty.Size = New System.Drawing.Size(48, 22)
			Me.lblST_InputQty.TabIndex = 136
			Me.lblST_InputQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'Label1
			'
			Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.ForeColor = System.Drawing.Color.White
			Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.Label1.Location = New System.Drawing.Point(64, 40)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(48, 16)
			Me.Label1.TabIndex = 137
			Me.Label1.Text = "Qty:"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'lblST_Model
			'
			Me.lblST_Model.BackColor = System.Drawing.Color.White
			Me.lblST_Model.ForeColor = System.Drawing.Color.Black
			Me.lblST_Model.Location = New System.Drawing.Point(120, 8)
			Me.lblST_Model.Name = "lblST_Model"
			Me.lblST_Model.Size = New System.Drawing.Size(248, 22)
			Me.lblST_Model.TabIndex = 140
			Me.lblST_Model.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'pnlST_InputVal
			'
			Me.pnlST_InputVal.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblST_InputLabel, Me.txtST_InputVal})
			Me.pnlST_InputVal.Location = New System.Drawing.Point(8, 48)
			Me.pnlST_InputVal.Name = "pnlST_InputVal"
			Me.pnlST_InputVal.Size = New System.Drawing.Size(376, 48)
			Me.pnlST_InputVal.TabIndex = 2
			'
			'lblST_InputLabel
			'
			Me.lblST_InputLabel.BackColor = System.Drawing.Color.Transparent
			Me.lblST_InputLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblST_InputLabel.ForeColor = System.Drawing.Color.White
			Me.lblST_InputLabel.Location = New System.Drawing.Point(8, 18)
			Me.lblST_InputLabel.Name = "lblST_InputLabel"
			Me.lblST_InputLabel.Size = New System.Drawing.Size(104, 16)
			Me.lblST_InputLabel.TabIndex = 122
			Me.lblST_InputLabel.Text = "Transfer  :"
			Me.lblST_InputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtST_InputVal
			'
			Me.txtST_InputVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtST_InputVal.Location = New System.Drawing.Point(120, 16)
			Me.txtST_InputVal.MaxLength = 20
			Me.txtST_InputVal.Name = "txtST_InputVal"
			Me.txtST_InputVal.Size = New System.Drawing.Size(248, 22)
			Me.txtST_InputVal.TabIndex = 0
			Me.txtST_InputVal.Text = ""
			'
			'cboST_TranfTypes
			'
			Me.cboST_TranfTypes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboST_TranfTypes.AutoCompletion = True
			Me.cboST_TranfTypes.AutoDropDown = True
			Me.cboST_TranfTypes.AutoSelect = True
			Me.cboST_TranfTypes.Caption = ""
			Me.cboST_TranfTypes.CaptionHeight = 17
			Me.cboST_TranfTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboST_TranfTypes.ColumnCaptionHeight = 17
			Me.cboST_TranfTypes.ColumnFooterHeight = 17
			Me.cboST_TranfTypes.ColumnHeaders = False
			Me.cboST_TranfTypes.ContentHeight = 15
			Me.cboST_TranfTypes.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboST_TranfTypes.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboST_TranfTypes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboST_TranfTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboST_TranfTypes.EditorHeight = 15
			Me.cboST_TranfTypes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
			Me.cboST_TranfTypes.ItemHeight = 15
			Me.cboST_TranfTypes.Location = New System.Drawing.Point(128, 16)
			Me.cboST_TranfTypes.MatchEntryTimeout = CType(2000, Long)
			Me.cboST_TranfTypes.MaxDropDownItems = CType(10, Short)
			Me.cboST_TranfTypes.MaxLength = 32767
			Me.cboST_TranfTypes.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboST_TranfTypes.Name = "cboST_TranfTypes"
			Me.cboST_TranfTypes.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboST_TranfTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboST_TranfTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboST_TranfTypes.Size = New System.Drawing.Size(248, 21)
			Me.cboST_TranfTypes.TabIndex = 0
			Me.cboST_TranfTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label9
			'
			Me.Label9.BackColor = System.Drawing.Color.Transparent
			Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label9.ForeColor = System.Drawing.Color.White
			Me.Label9.Location = New System.Drawing.Point(32, 18)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New System.Drawing.Size(88, 16)
			Me.Label9.TabIndex = 121
			Me.Label9.Text = "Transfer  :"
			Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'frmTF_AdminStationTrans_CreateWHBox
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.SteelBlue
			Me.ClientSize = New System.Drawing.Size(872, 510)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
			Me.Name = "frmTF_AdminStationTrans_CreateWHBox"
			Me.Text = "frmTF_AdminStationTrans_CreateWHBox"
			Me.TabControl1.ResumeLayout(False)
			Me.tpgAdminStationTransf.ResumeLayout(False)
			Me.pnlST_SNs.ResumeLayout(False)
			CType(Me.cboST_NextStation, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlST_ModelQty.ResumeLayout(False)
			Me.pnlST_InputVal.ResumeLayout(False)
			CType(Me.cboST_TranfTypes, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region

        '****************************************************************************************************************
        Private Sub frmTF_AdminStationTrans_CreateWHBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                dt = Me._objTFMisc.GetAdminStationTranfer(True)
                _booPopulateData = True
                Misc.PopulateC1DropDownList(Me.cboST_TranfTypes, dt, "Desc", "ID")
                Me.cboST_TranfTypes.SelectedValue = 0

                CreateDeviceTable()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt) : _booPopulateData = False
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub CreateDeviceTable()
            Dim dt As DataTable

            Try
                dt = New DataTable()
                dt.Columns.Add(New DataColumn("Device_ID", System.Type.GetType("System.Int32", False, True)))
                dt.Columns.Add(New DataColumn("Device_SN", System.Type.GetType("System.String", False, True)))
                dt.Columns.Add(New DataColumn("Model_ID", System.Type.GetType("System.Int32", False, True)))
                Me.lstST_SNs.DataSource = Nothing
                Me.lstST_SNs.DataSource = dt
                Me.lstST_SNs.DisplayMember = "Device_SN"
                Me.lstST_SNs.ValueMember = "Device_ID"

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                If Me.cboST_TranfTypes.SelectedValue = 0 Then
                    Me.lblST_InputLabel.Text = ""
                    Me.pnlST_SNs.Visible = False
                End If

                Me.txtST_InputVal.Text = ""
                Me.lblST_Model.Text = ""
                Me.lblST_InputQty.Text = ""

                Me._drInputData = Nothing

                '***********************************
                CreateDeviceTable()
                '***********************************
                Me.txtST_InputVal.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub cboST_TranfTypes_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboST_TranfTypes.SelectedValueChanged
            Dim R1, R2 As DataRow
            Dim strNextStation() As String
            Dim i As Integer
            Dim dt As DataTable

            Try
                btnCancel_Click(Nothing, Nothing)
                Me.cboST_NextStation.DataSource = Nothing
                Me.cboST_NextStation.Text = ""
                Me.pnlST_SNs.Visible = False

                If _booPopulateData = True OrElse Me.cboST_TranfTypes.SelectedValue = 0 Then Exit Sub

                R1 = Me.cboST_TranfTypes.DataSource.Table.select("ID = " & Me.cboST_TranfTypes.SelectedValue)(0)

                If R1("TFSF_BySN").ToString = "1" Then
                    Me.lblST_InputLabel.Text = "SN :"
                    If R1("TFSF_CreateBox").ToString = "1" Then Me.pnlST_SNs.Visible = True
                ElseIf R1("TFSF_ByWHBox").ToString = "1" Then
                    Me.lblST_InputLabel.Text = "Warehouse Box :"
                ElseIf R1("TFSF_ShipBox").ToString = "1" Then
                    Me.lblST_InputLabel.Text = "Ship Box :"
                End If

                dt = New DataTable()
                dt.Columns.Add(New DataColumn("ID", System.Type.GetType("system.Int16", False, True)))
                dt.Columns.Add(New DataColumn("Desc", System.Type.GetType("system.String", False, True)))

                strNextStation = R1("wfp_ToStation").ToString.Split("|")
                For i = 0 To strNextStation.Length - 1
                    If strNextStation(i).Trim.Length > 0 Then
                        R2 = dt.NewRow : R2("ID") = i + 1 : R2("Desc") = strNextStation(i).Trim
                        dt.Rows.Add(R2)
                    End If
                Next i

                dt.AcceptChanges()
                If dt.Rows.Count > 1 Then dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Misc.PopulateC1DropDownList(Me.cboST_NextStation, dt, "Desc", "ID")

                If dt.Rows.Count = 1 Then
                    Me.cboST_NextStation.SelectedIndex = 0
                    Me.cboST_NextStation.Enabled = False
                Else
                    Me.cboST_NextStation.SelectedValue = 0
                    Me.cboST_NextStation.Enabled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboST_TranfTypes_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub txtST_InputVal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtST_InputVal.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtST_InputVal.Text.Trim.Length > 0 Then
                    If Me.ProcessInput(Me.txtST_InputVal.Text.Trim, True) = False Then
                        Exit Sub
                    End If
                End If 'enter key
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtST_InputVal_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txtST_InputVal.SelectAll() : Me.txtST_InputVal.Focus()
            End Try
        End Sub

        '****************************************************************************************************************
        Private Function ProcessInput(ByVal strInput As String, ByVal booCheckDuplicate As Boolean) As Boolean
            Dim booRetVal As Boolean = False
            Dim R1 As DataRow
            Dim dt As DataTable

            Try
                If Me.cboST_TranfTypes.SelectedValue = 0 Then
                    MessageBox.Show("Please select transfer type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboST_TranfTypes.Text.Trim.StartsWith("Create") = False AndAlso strInput.Trim.Length = 0 Then
                    MessageBox.Show(Me.lblST_InputLabel.Text & " is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    R1 = Me.cboST_TranfTypes.DataSource.Table.select("ID = " & Me.cboST_TranfTypes.SelectedValue)(0)
                    If R1("TFSF_BySN").ToString = "1" Then
                        dt = Data.Buisness.Generic.GetDeviceInfoInWIP(strInput, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID)
                        If dt.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf dt.Rows.Count = 0 Then
                            MessageBox.Show("SN does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso CInt(dt.Rows(0)("Pallett_ID")) > 0 Then
                            MessageBox.Show("SN belongs to a ship pallet. Can't continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf Not IsDBNull(dt.Rows(0)("Device_DateShip")) Then
                            MessageBox.Show("SN is shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf IsValidStation(dt.Rows(0)("WorkStation"), R1("wfp_FrStation")) = False Then
                            MessageBox.Show("Can't accept unit from workstation '" & dt.Rows(0)("WorkStation") & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If R1("TFSF_CreateBox").ToString = "1" Then
                                Dim drNewRow As DataRow, dt2 As DataTable
                                dt2 = Me.lstST_SNs.DataSource

                                'Do validation
                                If dt2.Rows.Count > 0 AndAlso dt2.Rows(0)("Model_ID").ToString.Trim <> dt.Rows(0)("Model_ID").ToString.Trim Then Throw New Exception("Can't mix model.")
                                If dt2.Select("Device_SN = '" & strInput.Trim & "'").Length = 0 Then
                                    drNewRow = dt2.NewRow
                                    drNewRow("Model_ID") = dt.Rows(0)("Model_ID")
                                    drNewRow("Device_ID") = dt.Rows(0)("Device_ID")
                                    drNewRow("Device_SN") = dt.Rows(0)("Device_SN")
                                    dt2.Rows.Add(drNewRow) : dt2.AcceptChanges()
                                    Me.lblST_Model.Text = dt.Rows(0)("Model_Desc")
                                    Me.lblST_InputQty.Text = dt2.Rows.Count
                                ElseIf booCheckDuplicate = True Then
                                    Throw New Exception("SN is listed.")
                                End If

                                booRetVal = True
                                Me.Enabled = True : Me.txtST_InputVal.Text = "" : Me.txtST_InputVal.SelectAll() : Me.txtST_InputVal.Focus()
                            Else
                                _drInputData = dt.Rows(0)
                                booRetVal = True
                                Me.lblST_Model.Text = dt.Rows(0)("Model_Desc")
                                Me.lblST_InputQty.Text = "1"
                                booRetVal = True
                            End If
                        End If
                    Else
                        If R1("TFSF_ByWHBox").ToString = "1" Then
                            dt = Me._objTFMisc.GetBoxStationCount(strInput)
                        ElseIf R1("TFSF_ShipBox").ToString = "1" Then
                            dt = Me._objTFMisc.GetShipBoxStationCount(strInput.Trim)
                        End If

                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("This Box does not exist.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Box has multiple workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        ElseIf dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                            MessageBox.Show("This Box does not belong to any workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        ElseIf IsValidStation(dt.Rows(0)("WorkStation").ToString.Trim, R1("wfp_FrStation")) = False Then
                            MessageBox.Show("Can't accept units from workstation '" & dt.Rows(0)("WorkStation") & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf R1("TFSF_ShipBox").ToString = "1" AndAlso Not IsDBNull(dt.Rows(0)("WO_ID")) AndAlso CInt(dt.Rows(0)("WO_ID")) > 0 Then
                            MessageBox.Show("This box has assigned to an outbound shipment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If R1("TFSF_ByWHBox").ToString = "1" Then
                                If Not IsDBNull(dt.Compute("SUM(cnt)", "")) Then Me.lblST_InputQty.Text = dt.Compute("SUM(cnt)", "") Else Me.lblST_InputQty.Text = "0"
                                Me.lblST_Model.Text = dt.Rows(0)("VN_ItemNo")
                            ElseIf R1("TFSF_ShipBox").ToString = "1" Then
                                Me.lblST_InputQty.Text = dt.Rows(0)("Pallett_QTY")
                                Me.lblST_Model.Text = dt.Rows(0)("cust_OutgoingSku")
                            End If
                            _drInputData = dt.Rows(0)
                            booRetVal = True
                        End If

                    End If 'box type
                End If 'has selected tranfer type

                Return booRetVal
            Catch ex As Exception
                Throw ex
            Finally
                Data.Buisness.Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Function

        '****************************************************************************************************************
        Private Function IsValidStation(ByVal strFromStation As String, ByVal strAcceptedStation As String) As Boolean
            Dim booRetVal As Boolean = False
            Dim strAcptedStation() As String
            Dim i As Integer

            Try
                If strAcceptedStation.Trim.Length = 0 Then
                    booRetVal = True
                Else
                    strAcptedStation = strAcceptedStation.Split("|")
                    If strAcptedStation.Length = 0 Then
                        booRetVal = True
                    Else
                        For i = 0 To strAcptedStation.Length - 1
                            If strAcptedStation(i).Trim.ToLower = strFromStation.Trim.ToLower Then
                                booRetVal = True : Exit For
                            End If
                        Next i
                    End If
                End If
                Return booRetVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************************
        Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
            Dim dt As DataTable
            Dim R1, R2 As DataRow
            Dim i As Integer

            Try
                If Me.cboST_TranfTypes.SelectedValue = 0 Then
                    MessageBox.Show("Please select transfer type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                R1 = Me.cboST_TranfTypes.DataSource.Table.select("ID = " & Me.cboST_TranfTypes.SelectedValue)(0)

                If R1("TFSF_BySN").ToString <> "1" AndAlso ProcessInput(Me.txtST_InputVal.Text.Trim, False) = False Then
                    Exit Sub
                Else
                    For i = 0 To Me.lstST_SNs.Items.Count - 1
						If ProcessInput(Me.lstST_SNs.Items.Item(i)("Device_SN"), False) = False Then
							Exit Sub
						End If
						If Me.cboST_NextStation.Text = "SW HOLD" Then
							' REMOVE FROM tboxdevicesinprocess TABLE.
							_objTFMisc.RemoveDvcFromSWFail(Me.lstST_SNs.Items.Item(i)("Device_id"))
						End If
					Next i
				End If

				If Me.cboST_TranfTypes.Text.Trim.StartsWith("Create") AndAlso Me.lstST_SNs.Items.Count = 0 Then
					MessageBox.Show("List is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf Me.cboST_NextStation.SelectedValue = 0 Then
					MessageBox.Show("Please select next workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Else
					Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

					'*********************************************
					'Save data
					'*********************************************
					If R1("TFSF_CreateBox").ToString = "0" AndAlso Me.txtST_InputVal.Text.Trim.Length = 0 Then Throw New Exception("Please enter " & Me.lblST_InputLabel.Text)

					If R1("TFSF_ByWHBox").ToString = "1" Then
						i = Me._objTFMisc.PushWBBoxToWorkArea(Me.txtST_InputVal.Text.Trim, Me.cboST_NextStation.Text, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name)
					ElseIf R1("TFSF_ShipBox").ToString = "1" Then
						If IsNothing(_drInputData) Then Throw New Exception("Can't define input data.")
						i = Me._objTFMisc.PushShipBoxToNextStation(CInt(_drInputData("Pallett_ID")), Me.cboST_NextStation.Text, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name)
					Else
						If R1("TFSF_BySN").ToString = "1" AndAlso R1("TFSF_CreateBox").ToString = "1" Then
							If Me.lstST_SNs.Items.Count = 0 Then Exit Sub

							dt = Me.lstST_SNs.DataSource
							i = Me._objTFMisc.CreateWHBoxAndTransferToNewStation(dt, Me.cboST_NextStation.Text, R1("wfp_FrStation"), Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name)
						ElseIf R1("TFSF_BySN").ToString = "1" Then
							i = Generic.SetTcelloptWorkStationForDevice(Me.cboST_NextStation.Text, CInt(_drInputData("Device_ID")), Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )
							If i > 0 Then Me._objTFMisc.RemoveWarehouseBox(CInt(_drInputData("Device_ID")))
						Else
							Throw New Exception("System can't define transfer function.")
						End If
					End If

					'*********************************************
					'Clean up control and global variable
					'*********************************************
					If i = 0 Then
						MessageBox.Show("System has failed to move units to the next work station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Else
						Me.btnCancel_Click(Nothing, Nothing)
					End If
					'*********************************************
				End If
			Catch ex As Exception
                MessageBox.Show(ex.Message, "btnTransfer_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************


    End Class
End Namespace