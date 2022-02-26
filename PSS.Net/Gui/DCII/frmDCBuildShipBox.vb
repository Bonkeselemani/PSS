Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.DriveCam

    Public Class frmDCBuildShipBox
        Inherits System.Windows.Forms.Form

        Private Const _IPRODID As Integer = 9

        Private _objDC As PSS.Data.Buisness.DriveCam
        Private _iMachineCC_GrpID As Integer = 0
        Private _booPopulateData As Boolean = False

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
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents pnlShipType As System.Windows.Forms.Panel
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Button5 As System.Windows.Forms.Button
        Friend WithEvents btnCreateBoxID As System.Windows.Forms.Button
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblBin As System.Windows.Forms.Label
        Friend WithEvents lblLineSide As System.Windows.Forms.Label
        Friend WithEvents lblMachine As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents lblWorkDate As System.Windows.Forms.Label
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents panelPallet As System.Windows.Forms.Panel
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCloseBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
        Friend WithEvents btnDeleteBox As System.Windows.Forms.Button
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnReopenBox As System.Windows.Forms.Button
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents cboDriveCamCust As C1.Win.C1List.C1Combo
        Friend WithEvents btnGetCustByWo As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
        Friend WithEvents btnRecreateManifest As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDCBuildShipBox))
            Me.pnlShipType = New System.Windows.Forms.Panel()
            Me.cboLocations = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnGetCustByWo = New System.Windows.Forms.Button()
            Me.cboDriveCamCust = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.btnCreateBoxID = New System.Windows.Forms.Button()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblBin = New System.Windows.Forms.Label()
            Me.lblLineSide = New System.Windows.Forms.Label()
            Me.lblMachine = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.lblWorkDate = New System.Windows.Forms.Label()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCloseBox = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.PanelPalletList = New System.Windows.Forms.Panel()
            Me.btnDeleteBox = New System.Windows.Forms.Button()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReopenBox = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.btnRecreateManifest = New System.Windows.Forms.Button()
            Me.pnlShipType.SuspendLayout()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboDriveCamCust, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.panelPallet.SuspendLayout()
            Me.PanelPalletList.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlShipType
            '
            Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLocations, Me.Label1, Me.btnGetCustByWo, Me.cboDriveCamCust, Me.Label4, Me.Button5, Me.btnCreateBoxID})
            Me.pnlShipType.Location = New System.Drawing.Point(3, 74)
            Me.pnlShipType.Name = "pnlShipType"
            Me.pnlShipType.Size = New System.Drawing.Size(357, 150)
            Me.pnlShipType.TabIndex = 117
            '
            'cboLocations
            '
            Me.cboLocations.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocations.Caption = ""
            Me.cboLocations.CaptionHeight = 17
            Me.cboLocations.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocations.ColumnCaptionHeight = 17
            Me.cboLocations.ColumnFooterHeight = 17
            Me.cboLocations.ContentHeight = 15
            Me.cboLocations.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocations.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocations.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocations.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocations.EditorHeight = 15
            Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboLocations.ItemHeight = 15
            Me.cboLocations.Location = New System.Drawing.Point(88, 72)
            Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocations.MaxDropDownItems = CType(5, Short)
            Me.cboLocations.MaxLength = 32767
            Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocations.Name = "cboLocations"
            Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocations.Size = New System.Drawing.Size(216, 21)
            Me.cboLocations.TabIndex = 91
            Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 72)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(73, 16)
            Me.Label1.TabIndex = 92
            Me.Label1.Text = "Location :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnGetCustByWo
            '
            Me.btnGetCustByWo.BackColor = System.Drawing.Color.SlateGray
            Me.btnGetCustByWo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGetCustByWo.ForeColor = System.Drawing.Color.White
            Me.btnGetCustByWo.Location = New System.Drawing.Point(88, 3)
            Me.btnGetCustByWo.Name = "btnGetCustByWo"
            Me.btnGetCustByWo.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnGetCustByWo.Size = New System.Drawing.Size(216, 21)
            Me.btnGetCustByWo.TabIndex = 90
            Me.btnGetCustByWo.Text = "Get Customer By Workorder"
            '
            'cboDriveCamCust
            '
            Me.cboDriveCamCust.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDriveCamCust.Caption = ""
            Me.cboDriveCamCust.CaptionHeight = 17
            Me.cboDriveCamCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDriveCamCust.ColumnCaptionHeight = 17
            Me.cboDriveCamCust.ColumnFooterHeight = 17
            Me.cboDriveCamCust.ContentHeight = 15
            Me.cboDriveCamCust.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDriveCamCust.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDriveCamCust.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDriveCamCust.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDriveCamCust.EditorHeight = 15
            Me.cboDriveCamCust.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboDriveCamCust.ItemHeight = 15
            Me.cboDriveCamCust.Location = New System.Drawing.Point(88, 40)
            Me.cboDriveCamCust.MatchEntryTimeout = CType(2000, Long)
            Me.cboDriveCamCust.MaxDropDownItems = CType(5, Short)
            Me.cboDriveCamCust.MaxLength = 32767
            Me.cboDriveCamCust.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDriveCamCust.Name = "cboDriveCamCust"
            Me.cboDriveCamCust.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDriveCamCust.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDriveCamCust.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDriveCamCust.Size = New System.Drawing.Size(216, 21)
            Me.cboDriveCamCust.TabIndex = 1
            Me.cboDriveCamCust.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 40)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(73, 16)
            Me.Label4.TabIndex = 89
            Me.Label4.Text = "Customer :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Button5
            '
            Me.Button5.BackColor = System.Drawing.Color.Black
            Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button5.Location = New System.Drawing.Point(720, 200)
            Me.Button5.Name = "Button5"
            Me.Button5.Size = New System.Drawing.Size(300, 300)
            Me.Button5.TabIndex = 66
            Me.Button5.TabStop = False
            Me.Button5.Text = "Generate Report"
            '
            'btnCreateBoxID
            '
            Me.btnCreateBoxID.BackColor = System.Drawing.Color.Green
            Me.btnCreateBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateBoxID.ForeColor = System.Drawing.Color.White
            Me.btnCreateBoxID.Location = New System.Drawing.Point(88, 112)
            Me.btnCreateBoxID.Name = "btnCreateBoxID"
            Me.btnCreateBoxID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreateBoxID.Size = New System.Drawing.Size(216, 24)
            Me.btnCreateBoxID.TabIndex = 4
            Me.btnCreateBoxID.Text = "CREATE BOX ID"
            Me.btnCreateBoxID.Visible = False
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Black
            Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
            Me.lblScreenName.Location = New System.Drawing.Point(3, 2)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(229, 70)
            Me.lblScreenName.TabIndex = 120
            Me.lblScreenName.Text = "DriveCam Build Ship Box"
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBin, Me.lblLineSide, Me.lblMachine, Me.lblGroup, Me.lblLine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
            Me.Panel2.Location = New System.Drawing.Point(227, 2)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(576, 71)
            Me.Panel2.TabIndex = 121
            '
            'lblBin
            '
            Me.lblBin.BackColor = System.Drawing.Color.Transparent
            Me.lblBin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBin.ForeColor = System.Drawing.Color.Lime
            Me.lblBin.Location = New System.Drawing.Point(176, 25)
            Me.lblBin.Name = "lblBin"
            Me.lblBin.Size = New System.Drawing.Size(178, 16)
            Me.lblBin.TabIndex = 94
            Me.lblBin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLineSide
            '
            Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
            Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
            Me.lblLineSide.Location = New System.Drawing.Point(8, 46)
            Me.lblLineSide.Name = "lblLineSide"
            Me.lblLineSide.Size = New System.Drawing.Size(146, 16)
            Me.lblLineSide.TabIndex = 93
            Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMachine
            '
            Me.lblMachine.BackColor = System.Drawing.Color.Transparent
            Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMachine.ForeColor = System.Drawing.Color.Lime
            Me.lblMachine.Location = New System.Drawing.Point(176, 4)
            Me.lblMachine.Name = "lblMachine"
            Me.lblMachine.Size = New System.Drawing.Size(178, 16)
            Me.lblMachine.TabIndex = 92
            Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Transparent
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Lime
            Me.lblGroup.Location = New System.Drawing.Point(8, 4)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(146, 16)
            Me.lblGroup.TabIndex = 91
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLine
            '
            Me.lblLine.BackColor = System.Drawing.Color.Transparent
            Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLine.ForeColor = System.Drawing.Color.Lime
            Me.lblLine.Location = New System.Drawing.Point(8, 25)
            Me.lblLine.Name = "lblLine"
            Me.lblLine.Size = New System.Drawing.Size(146, 16)
            Me.lblLine.TabIndex = 90
            Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShift
            '
            Me.lblShift.BackColor = System.Drawing.Color.Transparent
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.ForeColor = System.Drawing.Color.Lime
            Me.lblShift.Location = New System.Drawing.Point(376, 25)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(178, 16)
            Me.lblShift.TabIndex = 88
            Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWorkDate
            '
            Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
            Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
            Me.lblWorkDate.Location = New System.Drawing.Point(376, 46)
            Me.lblWorkDate.Name = "lblWorkDate"
            Me.lblWorkDate.Size = New System.Drawing.Size(178, 16)
            Me.lblWorkDate.TabIndex = 84
            Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblUserName
            '
            Me.lblUserName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserName.ForeColor = System.Drawing.Color.Lime
            Me.lblUserName.Location = New System.Drawing.Point(376, 4)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(178, 16)
            Me.lblUserName.TabIndex = 83
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDevSN, Me.Label10, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblCount, Me.Label3, Me.lblBoxName})
            Me.panelPallet.Location = New System.Drawing.Point(360, 72)
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(352, 480)
            Me.panelPallet.TabIndex = 119
            Me.panelPallet.Visible = False
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(11, 56)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(156, 20)
            Me.txtDevSN.TabIndex = 1
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(11, 40)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(157, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Serial Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCloseBox
            '
            Me.btnCloseBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseBox.Location = New System.Drawing.Point(192, 424)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseBox.Size = New System.Drawing.Size(136, 24)
            Me.btnCloseBox.TabIndex = 3
            Me.btnCloseBox.Text = "Close Box"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(180, 184)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(148, 24)
            Me.btnRemoveAllSNs.TabIndex = 5
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(180, 144)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(148, 24)
            Me.btnRemoveSN.TabIndex = 4
            Me.btnRemoveSN.Text = "REMOVE SN"
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(11, 80)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(156, 368)
            Me.lstDevices.TabIndex = 2
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Black
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.Lime
            Me.lblCount.Location = New System.Drawing.Point(205, 64)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(98, 32)
            Me.lblCount.TabIndex = 97
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(208, 48)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 16)
            Me.Label3.TabIndex = 96
            Me.Label3.Text = "Box Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Black
            Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxName.Location = New System.Drawing.Point(10, 5)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(318, 32)
            Me.lblBoxName.TabIndex = 98
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PanelPalletList
            '
            Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRecreateManifest, Me.btnDeleteBox, Me.dbgPallets, Me.btnReopenBox, Me.btnReprintBoxLabel})
            Me.PanelPalletList.Location = New System.Drawing.Point(3, 224)
            Me.PanelPalletList.Name = "PanelPalletList"
            Me.PanelPalletList.Size = New System.Drawing.Size(357, 328)
            Me.PanelPalletList.TabIndex = 118
            '
            'btnDeleteBox
            '
            Me.btnDeleteBox.BackColor = System.Drawing.Color.Red
            Me.btnDeleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeleteBox.ForeColor = System.Drawing.Color.White
            Me.btnDeleteBox.Location = New System.Drawing.Point(192, 256)
            Me.btnDeleteBox.Name = "btnDeleteBox"
            Me.btnDeleteBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeleteBox.Size = New System.Drawing.Size(152, 24)
            Me.btnDeleteBox.TabIndex = 2
            Me.btnDeleteBox.Text = "DELETE EMPTY BOX"
            '
            'dbgPallets
            '
            Me.dbgPallets.AllowColMove = False
            Me.dbgPallets.AllowColSelect = False
            Me.dbgPallets.AllowFilter = False
            Me.dbgPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgPallets.AllowSort = False
            Me.dbgPallets.AllowUpdate = False
            Me.dbgPallets.AllowUpdateOnBlur = False
            Me.dbgPallets.CollapseColor = System.Drawing.Color.White
            Me.dbgPallets.ExpandColor = System.Drawing.Color.White
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.ForeColor = System.Drawing.Color.White
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(8, 8)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(336, 232)
            Me.dbgPallets.TabIndex = 0
            Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
            "lor:White;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColo" & _
            "r:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}Style12{}OddRow{BackColor:Teal;}RecordSelector{Alig" & _
            "nImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
            "rif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1" & _
            ", 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1Tru" & _
            "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
            "zing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" " & _
            "MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Ver" & _
            "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>228</Height><CaptionStyle" & _
            " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
            "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
            "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
            "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
            "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
            "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
            "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
            "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 332, 228</ClientRect><BorderSide>" & _
            "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 332, 228</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnReopenBox
            '
            Me.btnReopenBox.BackColor = System.Drawing.Color.Red
            Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenBox.ForeColor = System.Drawing.Color.White
            Me.btnReopenBox.Location = New System.Drawing.Point(8, 256)
            Me.btnReopenBox.Name = "btnReopenBox"
            Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReopenBox.Size = New System.Drawing.Size(152, 24)
            Me.btnReopenBox.TabIndex = 1
            Me.btnReopenBox.Text = "REOPEN  BOX"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(8, 288)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(152, 24)
            Me.btnReprintBoxLabel.TabIndex = 3
            Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
            '
            'btnRecreateManifest
            '
            Me.btnRecreateManifest.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnRecreateManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRecreateManifest.ForeColor = System.Drawing.Color.Black
            Me.btnRecreateManifest.Location = New System.Drawing.Point(192, 288)
            Me.btnRecreateManifest.Name = "btnRecreateManifest"
            Me.btnRecreateManifest.Size = New System.Drawing.Size(152, 24)
            Me.btnRecreateManifest.TabIndex = 4
            Me.btnRecreateManifest.Text = "Re-Create Manifest"
            '
            'frmDCBuildShipBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(808, 589)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlShipType, Me.lblScreenName, Me.Panel2, Me.panelPallet, Me.PanelPalletList})
            Me.Name = "frmDCBuildShipBox"
            Me.Text = "frmDCBuildShipBox"
            Me.pnlShipType.ResumeLayout(False)
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboDriveCamCust, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.panelPallet.ResumeLayout(False)
            Me.PanelPalletList.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************
        Private Sub txtDevSN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDevSN.KeyPress
            Try
                If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub frmDCBuildShipBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Try
                '*****************************
                'check computer mapping
                '*****************************
                Me._iMachineCC_GrpID = Generic.GetMachineCostCenterGrpID()
                If Me._iMachineCC_GrpID = 0 Or Me._iMachineCC_GrpID <> 84 Then
                    MessageBox.Show("Machine is not map to DriveCam group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Close()
                    If PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        PSS.Gui.MainWin.MainWin.wrkArea.TabPages.RemoveAt(PSS.Gui.MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                End If

                'special permission
                If PSS.Core.ApplicationUser.GetPermission("DC_RecreateManifest") > 0 Then
                    Me.btnRecreateManifest.Visible = True
                End If

                '******************************************
                'populate data to dropdown list controls
                '******************************************
                _booPopulateData = True
                Generic.DisposeDT(dt)
                dt = Me._objDC.GetCustomersByProdID(_IPRODID)
                Misc.PopulateC1DropDownList(Me.cboDriveCamCust, dt, "Name", "ID")
                dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Me.cboDriveCamCust.SelectedValue = 0

                Me.cboDriveCamCust.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                _booPopulateData = False
            End Try
        End Sub

        '********************************************************************
        Private Sub cboDriveCamCust_cbolocations_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDriveCamCust.RowChange, cboLocations.RowChange
            Dim booResult As Boolean = False

            Try
                Me.dbgPallets.DataSource = Nothing
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = "0"
                Me.txtDevSN.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.panelPallet.Visible = False
                Me.btnCreateBoxID.Visible = False

                If _booPopulateData = False Then
                    If sender.name = "cboDriveCamCust" Then
                        Me.cboLocations.DataSource = Nothing : Me.cboLocations.Text = ""
                        If Me.cboDriveCamCust.SelectedValue > 0 Then Me.PopulateLocationList()
                    ElseIf sender.name = "cboLocations" Then
                        If Me.cboLocations.SelectedValue > 0 Then
                            booResult = Me.PopulateOpenBoxs()
                            If booResult = False Then Me.btnCreateBoxID.Visible = True Else Me.btnCreateBoxID.Visible = False
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbolocations_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateLocationList()
            Dim dt As DataTable
            Dim booResult As Boolean = False

            Try
                _booPopulateData = True
                dt = Generic.GetLocations(True, Me.cboDriveCamCust.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                    booResult = Me.PopulateOpenBoxs()
                    If booResult = False Then Me.btnCreateBoxID.Visible = True Else Me.btnCreateBoxID.Visible = False
                Else
                    Me.cboLocations.SelectedValue = 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************
        Private Function PopulateOpenBoxs(Optional ByVal iPallettID As Integer = 0) As Boolean
            Dim dt As DataTable

            Try
                Me.dbgPallets.DataSource = Nothing
                Me.txtDevSN.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = "0"
                Me.panelPallet.Visible = False
                Me.btnCreateBoxID.Visible = False

                dt = Me._objDC.GetDDOpenPallets(Me.cboDriveCamCust.SelectedValue, Me.cboLocations.SelectedValue, Me._iMachineCC_GrpID)
                If dt.Rows.Count > 0 Then
                    Me.dbgPallets.DataSource = dt.DefaultView
                    SetGridOpenBoxProperties(iPallettID)
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************
        Private Sub SetGridOpenBoxProperties(Optional ByVal iPallet_ID As Integer = 0)
            Dim i As Integer

            Try
                With Me.dbgPallets
                    'Heading style (Horizontal Alignment to Center)
                    For i = 0 To Me.dbgPallets.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Visible = False
                    Next i

                    'header forecolor
                    .Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(3).HeadingStyle.ForeColor = .ForeColor.Black

                    'Set individual column data horizontal alignment
                    .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                    'Body Forecolor
                    .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black

                    'Set Column Widths
                    .Splits(0).DisplayColumns("Box Name").Width = 150

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("Box Name").Visible = True
                    .Splits(0).DisplayColumns("Loc Name").Visible = True

                    .AlternatingRows = True

                    For i = 0 To .RowCount - 1
                        If .Columns("Pallett_ID").CellValue(i) = iPallet_ID Then
                            Exit Sub
                        End If
                        .MoveNext()
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************
        Private Sub btnCreateBoxID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBoxID.Click
            Dim iPallettID As Integer = 0
            Dim iLocID As Integer = 0

            Try
                If IsNothing(Me.cboDriveCamCust.SelectedValue) OrElse Me.cboDriveCamCust.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDriveCamCust.Focus()
                ElseIf IsNothing(Me.cboLocations.SelectedValue) OrElse Me.cboLocations.SelectedValue = 0 Then
                    MessageBox.Show("Please select Location.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDriveCamCust.Focus()
                ElseIf Not IsNothing(Me.dbgPallets.DataSource) AndAlso Me.dbgPallets.DataSource.Table.Select("Cust_ID = " & Me.cboDriveCamCust.SelectedValue & " AND Loc_ID = " & Me.cboLocations.SelectedValue).length > 0 Then
                    MessageBox.Show("An open box for selected customer is existing in the list.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.btnCreateBoxID.Visible = False
                Else
                    iLocID = Me.cboLocations.SelectedValue
                    If iLocID = 0 Then Throw New Exception("Location ID is missing.")

                    '**********************************
                    'check for open pallet
                    '**********************************
                    If Me._objDC.IsOpenBoxExisted(Me.cboDriveCamCust.SelectedValue, iLocID, Me._iMachineCC_GrpID) = False Then
                        iPallettID = Me._objDC.CreateBoxID(Me.cboDriveCamCust.SelectedValue, iLocID, Me._iMachineCC_GrpID)
                        Me.PopulateOpenBoxs(iPallettID)
                    Else
                        MessageBox.Show("An open box is currently availalbe to fill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.PopulateOpenBoxs()
                        Me.txtDevSN.Focus()
                    End If  'check if there is an box available to fill
                    '**********************************
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreateBoxID_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub dbgPallets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgPallets.Click
            Try
                Me.ProcessPalletSelection()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgPallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************
        Private Sub dbgPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgPallets.RowColChange
            Try
                Me.ProcessPalletSelection()
                Me.txtDevSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgPallets_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************
        Private Sub ProcessPalletSelection()
            Dim strShipType As String = ""
            Dim i As Integer = 0
            Dim booFound As Boolean = False

            Try
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = "0"
                Me.txtDevSN.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.panelPallet.Visible = True

                If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
                    Me.panelPallet.Visible = False
                    Exit Sub
                End If
                If Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                    Exit Sub
                End If

                Me.Enabled = False

                Me.lblBoxName.Text = Me.dbgPallets.Columns("Box Name").Value.ToString
                Me.RefreshSNList()

                '*******************************************
                Me.txtDevSN.Focus()

            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
            End Try
        End Sub

        '********************************************************************
        Private Sub RefreshSNList()
            Dim dt1 As DataTable
            Dim iPallet_ID As Integer = 0
            Dim strPalletName As String = ""
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                '************************
                'Validations
                iPallet_ID = CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString)
                strPalletName = Me.dbgPallets.Columns("Box Name").Value.ToString.Trim

                If iPallet_ID = 0 Then
                    Throw New Exception("Box is not selected.")
                ElseIf strPalletName.Trim = "" Then
                    Throw New Exception("Box is not selected.")
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString) = 0 Then
                    Throw New Exception("Location ID is missing for box" & strPalletName & ".")
                End If

                '*******************************************
                'Get all devices add put them in them in list box for a pallet
                objMisc = New PSS.Data.Buisness.Misc()
                dt1 = objMisc.GetAllSNsForPallet(iPallet_ID)

                '***************************************************************
                'Make sure all units in pallett belong to the receiving location
                '***************************************************************
                If dt1.Select("Loc_ID <> " & Me.cboLocations.SelectedValue).Length > 0 Then Throw New Exception("S/N ( " & dt1.Select("Loc_ID <> " & Me.cboLocations.SelectedValue)(0)("Device_SN") & " ) does not belongs to selected location.")
                '***************************************************************
                Me.lstDevices.DataSource = dt1.DefaultView
                Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
                Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString
                Me.lblBoxName.Text = strPalletName

                '*******************************************
                Me.lblCount.Text = dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objMisc = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '********************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDevSN.Text.Trim.Length > 0 Then Me.ProcessDCSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub ProcessDCSN()
            Dim i As Integer = 0
            Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
            Dim dtDevice, dtBilling As DataTable

            Try
                '************************
                'Validations
                If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf CInt(Me.dbgPallets.Columns("Cust_ID").Value) = 0 Then
                    Throw New Exception("Customer ID is missing in the pallet.")
                ElseIf CInt(Me.dbgPallets.Columns("Loc_ID").Value) = 0 Then
                    Throw New Exception("Loc ID is missing in the pallet.")
                ElseIf Me.txtDevSN.Text.Trim = "" Then
                    Exit Sub
                ElseIf Me.lstDevices.DataSource.Table.Select("device_sn = '" & strSN & "'").Length > 0 Then
                    '***************************************************
                    'Step 1: Check if the Device is already scanned in
                    '***************************************************
                    MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                    Exit Sub
                End If

                '***************************************************
                'Added by Lan on 09/16/2007
                'Prevent the user from adding more devices to closed pallet.
                'This happen when a pallet open at the 2 computer, computer 1 
                '  close the pallet and refesh the screen while the other computer screen 
                '  did not get refresh. This check will force the user to refresh the screen.
                '***************************************************
                If Generic.IsPalletClosed(CInt(Me.dbgPallets.Columns("Pallett_ID").Value)) = True Then
                    MsgBox("Box had been closed by another machine. Please refresh your screen.", MsgBoxStyle.Information, "Device Scan")
                    Exit Sub
                End If

                dtDevice = Me._objDC.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, CInt(Me.dbgPallets.Columns("Loc_ID").Value))

                If dtDevice.Rows.Count > 1 Then
                    MsgBox("This device existed twice in the system. Please contact IT.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.SelectAll()
                    Exit Sub
                ElseIf dtDevice.Rows.Count = 0 Then
                    MsgBox("This device either does not exist in the system, have been shipped or belongs to a different customer.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.SelectAll()
                    Exit Sub
                Else
                    If Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                        MsgBox("This device has been assigned onto a box ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", MsgBoxStyle.Information, "Information")
                        Me.txtDevSN.Text = ""
                    ElseIf IsDBNull(dtDevice.Rows(0)("wipowner_id")) Then
                        MsgBox("Can't define device's Wipowner.", MsgBoxStyle.Information, "Information")
                        Me.txtDevSN.Text = ""
                    ElseIf dtDevice.Rows(0)("wipowner_id") = 6 Then
                        MsgBox("Device is currently on hold.", MsgBoxStyle.Information, "Information")
                        Me.txtDevSN.Text = ""
                    ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                        MsgBox("This device has not been billed.", MsgBoxStyle.Information, "Information")
                        Me.txtDevSN.Text = ""
                        'ElseIf Generic.IsValidQCResults(dtDevice.Rows(0)("Device_DateBill"), 1, "Functional", True) = False Then
                        '    Me.txtDevSN.Text = ""
                    Else
                        dtBilling = Me._objDC.GetDeviceBillingInfo(dtDevice.Rows(0)("Device_ID"))
                        If Me.ValidateBilling(dtBilling, dtDevice.Rows(0)("RUR_ReturnToCust"), dtDevice.Rows(0)("Model_ID"), dtDevice.Rows(0)("Model_Type")) = False Then
                            Me.txtDevSN.Text = ""
                        Else
                            Me.Enabled = False
                            Cursor.Current = Cursors.WaitCursor

                            '***************************************************
                            'if above all is fine then add it to the list and update the database
                            i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgPallets.Columns("Pallett_ID").Value))

                            '***************************************************
                            Me.RefreshSNList()
                            'Me.LoadCellProductionNumbers()
                            'Me.LoadWeeklyCellProductionNumbers()
                            Me.Enabled = True
                            Cursor.Current = Cursors.Default
                            Me.txtDevSN.Text = ""
                            Me.txtDevSN.Focus()
                        End If  'Billing
                    End If
                End If  'Device count

            Catch ex As Exception
                MessageBox.Show("ProcessSN: " & ex.Message, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtDevSN.Text = ""
                Me.txtDevSN.Focus()
            Finally
                Generic.DisposeDT(dtDevice)
                Generic.DisposeDT(dtBilling)
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************
        Private Function ValidateBilling(ByVal dt As DataTable, _
                                         ByVal iRUR_ReturnToCust As Integer, _
                                         ByVal iModelID As Integer, _
                                         ByVal iModelTypeID As Integer) As Boolean
            Try
                ValidateBilling = False

                If dt.Rows.Count = 0 Then
                    Throw New Exception("System could not define Billcode rule. Please verify device's billing.")
                Else
                    If CInt(dt.Compute("Max(BillCode_Rule)", "")) = 1 Then  'RUR
                        If iRUR_ReturnToCust = 0 Then
                            Throw New Exception("This is a crap unit.")
                        ElseIf dt.Select("BillType_ID = 2").Length > 0 Then
                            Throw New Exception("This is an RUR with part(s). Please verify billing.")
                        ElseIf dt.Select("BillCode_Rule = 0 and BillCode_ID <> 1591 and BillCode_ID <> 1588").Length > 0 Then    '1591: Shipping handling and Diagnostic
                            Throw New Exception("This is an RUR with service code. Please verify billing.")
                        ElseIf iRUR_ReturnToCust = 1 And dt.Select("BillCode_ID = 1588").Length = 0 Then
                            Throw New Exception("Diagnostic code is missing. Please verify billing.")
                        End If
                    Else
                        If dt.Select("BillCode_ID = 1589").Length = 0 Then  'Repair
                            Throw New Exception("Repair service code is missing. Please verify billing.")
                        ElseIf dt.Select("BillCode_ID = 1588").Length = 0 Then    'Diagnostic
                            Throw New Exception("Diagnostic code is missing. Please verify billing.")
                        End If
                    End If
                End If

                Return True
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************
        Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            Dim i As Integer = 0
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim strManifestDir As String = ""

            Try
                '************************
                'Validations
                If CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Box name is not selected.")
                ElseIf CInt(Me.dbgPallets.Columns("Loc_ID").Value) = 0 Then
                    Throw New Exception("Location ID is missing for this box.")
                ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                    Throw New Exception("Box name is not selected.")
                End If

                If Me.lstDevices.Items.Count = 0 Then
                    Throw New Exception("There is no devices in this box.")
                ElseIf Me.lstDevices.DataSource.Table.Select("Loc_ID <> " & Me.cboLocations.SelectedValue).length > 0 Then
                    Throw New Exception("Some devices in box does not belong to selected location.")
                End If

                '************************
                If MessageBox.Show("Are you sure you want to close this box?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                ''************************
                'i = Me._objDC.CloseAndShipPallet(CInt(Me.dbgPallets.Columns("Cust_ID").Value), CInt(Me.dbgPallets.Columns("Pallett_ID").Value), Me.lstDevices.Items.Count, PSS.Core.ApplicationUser.IDShift)
                'If i = 0 Then
                '    Throw New Exception("Box has not closed yet due to an error. Please contact IT.")
                'End If

                '************************
                If Me.cboDriveCamCust.SelectedValue = 2266 Then
                    strManifestDir = Me._objDC.VeoliaTrans_MANIFEST_DIR
                ElseIf Me.cboDriveCamCust.SelectedValue = 2279 Then
                    strManifestDir = "P:\Dept\Greater Houston Transportation\Pallet Packing List\"
                Else
                    strManifestDir = Me._objDC.MANIFEST_DIR
                End If

                objMisc = New PSS.Data.Buisness.Misc()
                objMisc.CreateDriveCamExcelFile(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), Me.dbgPallets.Columns("Box Name").Value, strManifestDir)
                i = objMisc.ClosePallet(CInt(Me.dbgPallets.Columns("Cust_ID").Value), CInt(Me.dbgPallets.Columns("Pallett_ID").Value), Me.dbgPallets.Columns("Box Name").Value, Me.lstDevices.Items.Count, Me.dbgPallets.Columns("Pallet_ShipType").Value, 0, )
                If i = 0 Then
                    Throw New Exception("Box has not closed yet due to an error. Please contact IT.")
                End If
                'PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.dbgPallets.Columns("Box Name").Value, 0, "", Me.lstDevices.Items.Count, 1)
                PSS.Data.Production.Shipping.PrintBoxLabel(Me.dbgPallets.Columns("Box Name").Value)
                '************************

                'Refresh Pallet (Box) 
                Me.PopulateOpenBoxs()

                '******************************
                'Reset Screen control properties.
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = 0
                Me.lstDevices.DataSource = Nothing
                Me.panelPallet.Visible = False
                '******************************
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc = Nothing
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.cboDriveCamCust.Focus()
            End Try
        End Sub

        '********************************************************************
        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim strSN As String = ""
            Dim i As Integer = 0
            Dim iDeviceID As Integer = 0

            Try
                '************************
                'Validations
                If Me.dbgPallets.RowCount = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    'Throw New Exception("No IMEI in the list to remove.")
                    Exit Sub
                End If

                '************************
                strSN = InputBox("Enter S/N:", "S/N").Trim
                If strSN = "" Then
                    Throw New Exception("Please enter a S/N if you want to remove it from the selected box.")
                End If

                If Me.lstDevices.DataSource.Table.Select("Device_SN = '" & strSN & "'").Length > 0 Then
                    iDeviceID = Me.lstDevices.DataSource.Table.Select("Device_SN = '" & strSN & "'")(0)("Device_ID")

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), iDeviceID)
                    If i = 0 Then
                        Throw New Exception("S/N entered was not removed from Box.")
                    End If

                    Me.RefreshSNList()
                Else
                    Throw New Exception("S/N was not listed.")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Clear S/N", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '********************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Dim str_sn As String = ""
            Dim i As Integer = 0

            If MessageBox.Show("Are you sure you want to remove all devices from this Box?", "Clear All S/Ns", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Try
                '************************
                'Validations
                If Me.dbgPallets.RowCount = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    'Throw New Exception("No IMEI in the list to remove.")
                    Exit Sub
                End If

                '************************
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), )
                If i = 0 Then
                    Throw New Exception("No SNs were removed from box.")
                End If

                RefreshSNList()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '********************************************************************
        Private Sub btnDeleteBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBox.Click
            Dim i As Integer = 0

            Try
                If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to delete selected Box?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.DeleteEmptyPallet(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), PSS.Core.ApplicationUser.IDuser)
                    MessageBox.Show("Box has been deleted.")

                    Me.PopulateOpenBoxs()
                    Me.lstDevices.DataSource = Nothing
                    Me.lblBoxName.Text = ""
                    Me.lblCount.Text = ""
                    Me.panelPallet.Visible = False
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.cboDriveCamCust.Focus()
            End Try
        End Sub

        '********************************************************************
        Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Dim str_pallett As String = ""
            Dim dtPallettInfo As DataTable
            Dim strPalletType As String = ""
            Dim iPalletQty As Integer = 0
            Dim R1 As DataRow
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                objMisc = New PSS.Data.Buisness.Misc()
                dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)
                If dtPallettInfo.Rows.Count = 0 Then
                    MessageBox.Show("Box Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf dtPallettInfo.Rows.Count > 1 Then
                    MessageBox.Show("Box Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    R1 = dtPallettInfo.Rows(0)

                    If R1("Pallett_ReadyToShipFlg") = 0 Then
                        MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    End If

                    If Not IsDBNull(R1("Pallett_QTY")) Then iPalletQty = R1("Pallett_QTY")

                    If Not IsDBNull(R1("Cust_ID")) Then
                        '_objMisc.PrintPalletDeviceCountRpt(R1("Pallett_ID"), R1("Cust_ID"), 1)
                        'PSS.Data.Production.Shipping.PrintPalletLicensePlate(str_pallett, 0, strPalletType, iPalletQty, 1)
                        PSS.Data.Production.Shipping.PrintBoxLabel(R1("Pallett_Name"))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc = Nothing
                R1 = Nothing
                If Not IsNothing(dtPallettInfo) Then
                    dtPallettInfo.Dispose()
                    dtPallettInfo = Nothing
                End If
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.cboDriveCamCust.Focus()
            End Try
        End Sub

        '********************************************************************
        Private Sub btnGetCustByWo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCustByWo.Click
            Dim strWoID As String = ""
            Dim iCustID As Integer = 0

            Try
                strWoID = InputBox("Enter Workorder ID.", "Reprint Box Label")
                If strWoID = "" Then
                    Throw New Exception("Please enter a Workorder ID.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                iCustID = Me._objDC.GetCustIDByWOID(CInt(strWoID))
                If iCustID = 0 Then
                    MessageBox.Show("Can't find customer ID for this Workorder ID.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    If Me.cboDriveCamCust.DataSource.Table.Select("Cust_ID = " & iCustID).Length = 0 Then
                        MessageBox.Show("Customer of this workorder does not belong to DriveCam parent company.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.cboDriveCamCust.SelectedValue = 0
                        Me.dbgPallets.DataSource = Nothing
                        Me.lstDevices.DataSource = Nothing
                        Me.txtDevSN.Text = ""
                        Me.lblBoxName.Text = ""
                        Me.lblCount.Text = "0"
                        Me.panelPallet.Visible = False
                        Me.btnCreateBoxID.Visible = False
                    Else
                        Me.cboDriveCamCust.SelectedValue = iCustID
                        Me.cboLocations.DataSource = Nothing : Me.cboLocations.Text = ""
                        If Me.cboDriveCamCust.SelectedValue > 0 Then Me.PopulateLocationList()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.cboDriveCamCust.Focus()
            End Try
        End Sub

        '********************************************************************
        Private Sub btnReopenBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenBox.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            Dim strGroupChar As String = Me._iMachineCC_GrpID.ToString
            Dim dt As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                If Me.cboDriveCamCust.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDriveCamCust.SelectAll()
                    Me.cboDriveCamCust.Focus()
                    Exit Sub
                End If
                '************************
                strPallet = InputBox("Enter Box ID.", "Reopen Box")
                If strPallet = "" Then
                    Throw New Exception("Please enter a Box ID to re-open.")
                End If

                dt = Me._objDC.GetDCPallet(strPallet, Me.cboDriveCamCust.SelectedValue)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Box does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Box name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Box has been shipped. Not allow to reopen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Box is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    objMisc = New PSS.Data.Buisness.Misc()
                    i = objMisc.ReopenPallet(dt.Rows(0)("Pallett_ID"))
                    If i = 0 Then
                        Throw New Exception("Box was not reopened.")
                    End If

                    Me.cboDriveCamCust.SelectedValue = dt.Rows(0)("Cust_ID")

                    'Refresh Pallet( Box )
                    Me.PopulateOpenBoxs(dt.Rows(0)("Pallett_ID"))

                    '************************
                    Me.lstDevices.DataSource = Nothing
                    Me.lblCount.Text = "0"
                    Me.lblBoxName.Text = ""
                    Me.panelPallet.Visible = False
                    '************************
                    'Delete Excel Report
                    '************************
                    If Len(Dir(PSS.Data.Buisness.DriveCam.MANIFEST_DIR & strPallet & ".xls", FileAttribute.ReadOnly)) > 0 Then
                        Kill(PSS.Data.Buisness.DriveCam.MANIFEST_DIR & strPallet & ".xls")
                    End If
                    '************************
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reopen Box.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************
        Private Sub btnRecreateManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecreateManifest.Click
            Dim str_pallett As String = ""
            Dim dtPallettInfo As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim strManifestDir As String = ""

            Try
                str_pallett = InputBox("Enter Box Name.", "Re-Create Manifest")

                Me.Enabled = False

                objMisc = New PSS.Data.Buisness.Misc()
                dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)

                If dtPallettInfo.Rows.Count = 0 Then
                    MessageBox.Show("Box Name was not defined in system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dtPallettInfo.Rows.Count > 1 Then
                    MessageBox.Show("Box Name existed twice in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf CInt(dtPallettInfo.Rows(0)("Pallett_ReadyToShipFlg").ToString) = 0 Then
                    MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    If Me.cboDriveCamCust.SelectedValue = 2266 Then
                        strManifestDir = Me._objDC.VeoliaTrans_MANIFEST_DIR
                    ElseIf Me.cboDriveCamCust.SelectedValue = 2279 Then
                        strManifestDir = "P:\Dept\Greater Houston Transportation\Pallet Packing List\"
                    Else
                        strManifestDir = Me._objDC.MANIFEST_DIR
                    End If
                    Cursor.Current = Cursors.Default
                    objMisc.CreateDriveCamExcelFile(CInt(dtPallettInfo.Rows(0)("Pallett_ID").ToString), dtPallettInfo.Rows(0)("Pallett_Name").ToString, strManifestDir)
                    Me.Enabled = True
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRecreateManifest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc = Nothing
                If Not IsNothing(dtPallettInfo) Then
                    dtPallettInfo.Dispose()
                    dtPallettInfo = Nothing
                End If
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.cboDriveCamCust.Focus()
            End Try
        End Sub

        '********************************************************************

    End Class
End Namespace