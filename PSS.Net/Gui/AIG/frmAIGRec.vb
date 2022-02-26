Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmAIGRec
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer
        Private _iMenuLocID As Integer
        Private _objProdRec As PSS.Data.Production.Receiving
        Private _iTrayID As Integer = 0
        Private _dtAccessories As DataTable
        Private _objAIG As PSS.Data.Buisness.AIG
        Private Const _iModelID = 3602 'Generic

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer, ByVal iLocID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _iMenuCustID = iCustID
            _iMenuLocID = iLocID

            _objAIG = New PSS.Data.Buisness.AIG()
            _objProdRec = New PSS.Data.Production.Receiving()
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
        Friend WithEvents btnLanUseOnlyBOM As System.Windows.Forms.Button
        Friend WithEvents btnReceive As System.Windows.Forms.Button
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblClaimQty As System.Windows.Forms.Label
        Friend WithEvents lblRecdQty As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents btnReOpenWO As System.Windows.Forms.Button
        Friend WithEvents btnCloseWO As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnSelectClaim As System.Windows.Forms.Button
        Friend WithEvents dgOpenRecWO As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnClearSelection As System.Windows.Forms.Button
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtManufSN As System.Windows.Forms.TextBox
        Friend WithEvents lblManuf As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents gbCustInfo As System.Windows.Forms.GroupBox
        Friend WithEvents lblEmail As System.Windows.Forms.Label
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnRefreshWO As System.Windows.Forms.Button
        Friend WithEvents chklstAccessories As System.Windows.Forms.CheckedListBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents btnReprintLabels As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents txtNotes As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAIGRec))
            Me.btnLanUseOnlyBOM = New System.Windows.Forms.Button()
            Me.btnReceive = New System.Windows.Forms.Button()
            Me.btnReprintLabels = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblClaimQty = New System.Windows.Forms.Label()
            Me.lblRecdQty = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.btnReOpenWO = New System.Windows.Forms.Button()
            Me.btnCloseWO = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnSelectClaim = New System.Windows.Forms.Button()
            Me.dgOpenRecWO = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnClearSelection = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtManufSN = New System.Windows.Forms.TextBox()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.gbCustInfo = New System.Windows.Forms.GroupBox()
            Me.lblEmail = New System.Windows.Forms.Label()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.lblName = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnRefreshWO = New System.Windows.Forms.Button()
            Me.chklstAccessories = New System.Windows.Forms.CheckedListBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.txtNotes = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            CType(Me.dgOpenRecWO, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbCustInfo.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnLanUseOnlyBOM
            '
            Me.btnLanUseOnlyBOM.BackColor = System.Drawing.Color.Red
            Me.btnLanUseOnlyBOM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLanUseOnlyBOM.ForeColor = System.Drawing.Color.White
            Me.btnLanUseOnlyBOM.Location = New System.Drawing.Point(920, 16)
            Me.btnLanUseOnlyBOM.Name = "btnLanUseOnlyBOM"
            Me.btnLanUseOnlyBOM.Size = New System.Drawing.Size(32, 23)
            Me.btnLanUseOnlyBOM.TabIndex = 247
            Me.btnLanUseOnlyBOM.Text = "LanUseOnly-BOM"
            Me.btnLanUseOnlyBOM.Visible = False
            '
            'btnReceive
            '
            Me.btnReceive.BackColor = System.Drawing.Color.Green
            Me.btnReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceive.ForeColor = System.Drawing.Color.White
            Me.btnReceive.Location = New System.Drawing.Point(104, 112)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.Size = New System.Drawing.Size(200, 23)
            Me.btnReceive.TabIndex = 240
            Me.btnReceive.Text = "Receive"
            '
            'btnReprintLabels
            '
            Me.btnReprintLabels.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnReprintLabels.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintLabels.ForeColor = System.Drawing.Color.White
            Me.btnReprintLabels.Location = New System.Drawing.Point(680, 512)
            Me.btnReprintLabels.Name = "btnReprintLabels"
            Me.btnReprintLabels.Size = New System.Drawing.Size(128, 48)
            Me.btnReprintLabels.TabIndex = 11
            Me.btnReprintLabels.Text = "Reprint Labels"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(312, 72)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(104, 16)
            Me.Label8.TabIndex = 237
            Me.Label8.Text = "Received Qty :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(320, 16)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 236
            Me.Label7.Text = "Claim Qty :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblClaimQty
            '
            Me.lblClaimQty.BackColor = System.Drawing.Color.Black
            Me.lblClaimQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblClaimQty.Font = New System.Drawing.Font("Tahoma", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblClaimQty.ForeColor = System.Drawing.Color.Green
            Me.lblClaimQty.Location = New System.Drawing.Point(320, 32)
            Me.lblClaimQty.Name = "lblClaimQty"
            Me.lblClaimQty.Size = New System.Drawing.Size(88, 32)
            Me.lblClaimQty.TabIndex = 235
            Me.lblClaimQty.Tag = "0"
            Me.lblClaimQty.Text = "0"
            Me.lblClaimQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblRecdQty
            '
            Me.lblRecdQty.BackColor = System.Drawing.Color.Black
            Me.lblRecdQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblRecdQty.Font = New System.Drawing.Font("Tahoma", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecdQty.ForeColor = System.Drawing.Color.Green
            Me.lblRecdQty.Location = New System.Drawing.Point(320, 88)
            Me.lblRecdQty.Name = "lblRecdQty"
            Me.lblRecdQty.Size = New System.Drawing.Size(88, 32)
            Me.lblRecdQty.TabIndex = 234
            Me.lblRecdQty.Tag = "0"
            Me.lblRecdQty.Text = "0"
            Me.lblRecdQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(104, 48)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(200, 20)
            Me.lblModel.TabIndex = 233
            Me.lblModel.Tag = "0"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnReOpenWO
            '
            Me.btnReOpenWO.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReOpenWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReOpenWO.ForeColor = System.Drawing.Color.White
            Me.btnReOpenWO.Location = New System.Drawing.Point(560, 16)
            Me.btnReOpenWO.Name = "btnReOpenWO"
            Me.btnReOpenWO.Size = New System.Drawing.Size(136, 23)
            Me.btnReOpenWO.TabIndex = 5
            Me.btnReOpenWO.Text = "Re-Open Claim"
            Me.btnReOpenWO.Visible = False
            '
            'btnCloseWO
            '
            Me.btnCloseWO.BackColor = System.Drawing.Color.Navy
            Me.btnCloseWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWO.ForeColor = System.Drawing.Color.White
            Me.btnCloseWO.Location = New System.Drawing.Point(416, 16)
            Me.btnCloseWO.Name = "btnCloseWO"
            Me.btnCloseWO.Size = New System.Drawing.Size(128, 23)
            Me.btnCloseWO.TabIndex = 2314
            Me.btnCloseWO.Text = "Close Claim"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(32, 48)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 230
            Me.Label3.Text = "Model :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSelectClaim
            '
            Me.btnSelectClaim.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnSelectClaim.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectClaim.Location = New System.Drawing.Point(248, 16)
            Me.btnSelectClaim.Name = "btnSelectClaim"
            Me.btnSelectClaim.Size = New System.Drawing.Size(152, 23)
            Me.btnSelectClaim.TabIndex = 3
            Me.btnSelectClaim.Text = "Select Claim To Receive"
            '
            'dgOpenRecWO
            '
            Me.dgOpenRecWO.AllowUpdate = False
            Me.dgOpenRecWO.AlternatingRows = True
            Me.dgOpenRecWO.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgOpenRecWO.FilterBar = True
            Me.dgOpenRecWO.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgOpenRecWO.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgOpenRecWO.Location = New System.Drawing.Point(16, 48)
            Me.dgOpenRecWO.Name = "dgOpenRecWO"
            Me.dgOpenRecWO.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgOpenRecWO.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgOpenRecWO.PreviewInfo.ZoomFactor = 75
            Me.dgOpenRecWO.Size = New System.Drawing.Size(928, 240)
            Me.dgOpenRecWO.TabIndex = 6
            Me.dgOpenRecWO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "36</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 924, 236<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 924, 236</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnClearSelection
            '
            Me.btnClearSelection.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClearSelection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearSelection.ForeColor = System.Drawing.Color.White
            Me.btnClearSelection.Location = New System.Drawing.Point(16, 16)
            Me.btnClearSelection.Name = "btnClearSelection"
            Me.btnClearSelection.Size = New System.Drawing.Size(56, 23)
            Me.btnClearSelection.TabIndex = 1
            Me.btnClearSelection.Text = "Clear"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(24, 80)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(80, 16)
            Me.Label6.TabIndex = 229
            Me.Label6.Text = "Manuf S/N :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtManufSN
            '
            Me.txtManufSN.Location = New System.Drawing.Point(104, 80)
            Me.txtManufSN.MaxLength = 30
            Me.txtManufSN.Name = "txtManufSN"
            Me.txtManufSN.Size = New System.Drawing.Size(200, 20)
            Me.txtManufSN.TabIndex = 0
            Me.txtManufSN.Text = ""
            '
            'lblManuf
            '
            Me.lblManuf.BackColor = System.Drawing.Color.White
            Me.lblManuf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblManuf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManuf.ForeColor = System.Drawing.Color.Black
            Me.lblManuf.Location = New System.Drawing.Point(104, 24)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(200, 20)
            Me.lblManuf.TabIndex = 228
            Me.lblManuf.Tag = "0"
            Me.lblManuf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(16, 24)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(88, 16)
            Me.Label9.TabIndex = 226
            Me.Label9.Text = "Manufacture :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'gbCustInfo
            '
            Me.gbCustInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEmail, Me.lblPhone, Me.lblAddress, Me.lblName, Me.Label5, Me.Label4, Me.Label2, Me.Label1})
            Me.gbCustInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCustInfo.ForeColor = System.Drawing.Color.White
            Me.gbCustInfo.Location = New System.Drawing.Point(248, 304)
            Me.gbCustInfo.Name = "gbCustInfo"
            Me.gbCustInfo.Size = New System.Drawing.Size(424, 152)
            Me.gbCustInfo.TabIndex = 8
            Me.gbCustInfo.TabStop = False
            Me.gbCustInfo.Text = "Customer Info"
            '
            'lblEmail
            '
            Me.lblEmail.BackColor = System.Drawing.Color.White
            Me.lblEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmail.ForeColor = System.Drawing.Color.Black
            Me.lblEmail.Location = New System.Drawing.Point(72, 128)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(208, 16)
            Me.lblEmail.TabIndex = 182
            Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPhone
            '
            Me.lblPhone.BackColor = System.Drawing.Color.White
            Me.lblPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPhone.ForeColor = System.Drawing.Color.Black
            Me.lblPhone.Location = New System.Drawing.Point(72, 104)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(208, 16)
            Me.lblPhone.TabIndex = 181
            Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAddress
            '
            Me.lblAddress.BackColor = System.Drawing.Color.White
            Me.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAddress.ForeColor = System.Drawing.Color.Black
            Me.lblAddress.Location = New System.Drawing.Point(72, 48)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(208, 48)
            Me.lblAddress.TabIndex = 180
            '
            'lblName
            '
            Me.lblName.BackColor = System.Drawing.Color.White
            Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(72, 24)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(208, 16)
            Me.lblName.TabIndex = 179
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(8, 128)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(56, 16)
            Me.Label5.TabIndex = 178
            Me.Label5.Text = "Email :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 104)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(56, 16)
            Me.Label4.TabIndex = 177
            Me.Label4.Text = "Phone # :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(56, 16)
            Me.Label2.TabIndex = 176
            Me.Label2.Text = "Address :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(56, 16)
            Me.Label1.TabIndex = 175
            Me.Label1.Text = "Name :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRefreshWO
            '
            Me.btnRefreshWO.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshWO.ForeColor = System.Drawing.Color.White
            Me.btnRefreshWO.Location = New System.Drawing.Point(104, 16)
            Me.btnRefreshWO.Name = "btnRefreshWO"
            Me.btnRefreshWO.Size = New System.Drawing.Size(120, 23)
            Me.btnRefreshWO.TabIndex = 2
            Me.btnRefreshWO.Text = "Refresh List"
            '
            'chklstAccessories
            '
            Me.chklstAccessories.Location = New System.Drawing.Point(16, 312)
            Me.chklstAccessories.Name = "chklstAccessories"
            Me.chklstAccessories.Size = New System.Drawing.Size(216, 304)
            Me.chklstAccessories.TabIndex = 7
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(16, 296)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(72, 16)
            Me.Label11.TabIndex = 249
            Me.Label11.Text = "Accessories"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.Label7, Me.lblClaimQty, Me.lblRecdQty, Me.lblModel, Me.Label3, Me.Label9, Me.lblManuf, Me.Label6, Me.btnReceive, Me.txtManufSN})
            Me.GroupBox1.Location = New System.Drawing.Point(248, 464)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(424, 152)
            Me.GroupBox1.TabIndex = 9
            Me.GroupBox1.TabStop = False
            '
            'txtNotes
            '
            Me.txtNotes.Location = New System.Drawing.Point(680, 312)
            Me.txtNotes.MaxLength = 255
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.Size = New System.Drawing.Size(264, 168)
            Me.txtNotes.TabIndex = 2315
            Me.txtNotes.Text = ""
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(680, 296)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(56, 16)
            Me.Label10.TabIndex = 183
            Me.Label10.Text = "Notes:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'frmAIGRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(960, 654)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNotes, Me.GroupBox1, Me.Label11, Me.chklstAccessories, Me.btnLanUseOnlyBOM, Me.btnReOpenWO, Me.btnCloseWO, Me.btnSelectClaim, Me.dgOpenRecWO, Me.btnClearSelection, Me.gbCustInfo, Me.btnRefreshWO, Me.btnReprintLabels, Me.Label10})
            Me.Name = "frmAIGRec"
            Me.Text = "frmAIGRec"
            CType(Me.dgOpenRecWO, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbCustInfo.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '************************************************************************************************** 
        Private Sub frmAIGRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)
                LoadOpenRecWorkorder()

                _dtAccessories = Me._objAIG.GetAIGAccessories(PSS.Data.Buisness.AIG.PRODID)
                Me.chklstAccessories.DataSource = Me._dtAccessories.DefaultView
                Me.chklstAccessories.DisplayMember = "AccessoryDesc"
                Me.chklstAccessories.ValueMember = "A_ID"

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub LoadOpenRecWorkorder()
            Dim dt As DataTable

            Try
                dt = _objAIG.GetOpenRecWorkOrder(PSS.Data.Buisness.AIG.LOCID)
                With Me.dgOpenRecWO
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("State_ID").Visible = False
                    .Splits(0).DisplayColumns("Cntry_ID").Visible = False
                End With

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub ClearAllSelection()
            Try
                Me.lblModel.Text = "" : Me.lblModel.Tag = 0
                Me.lblManuf.Text = "" : Me.lblManuf.Tag = 0
                Me.txtManufSN.Text = ""

                'Customer info
                Me.lblName.Text = ""
                Me.lblAddress.Text = ""
                Me.lblPhone.Text = ""
                Me.lblEmail.Text = ""
                Me.txtNotes.Text = ""

                Me.dgOpenRecWO.Enabled = True
                Me.lblRecdQty.Text = "0"
                Me.lblClaimQty.Text = "0"
                Me.chklstAccessories.DataSource = Nothing
                Me.chklstAccessories.Items.Clear()

                Me.btnReceive.Visible = False

                _iTrayID = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearAllSelection", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSelection.Click, btnSelectClaim.Click, btnCloseWO.Click, btnReOpenWO.Click, btnRefreshWO.Click
            Try
                If sender.name = "btnClearSelection" Then
                    ClearAllSelection()
                ElseIf sender.name = "btnRefreshWO" Then
                    ClearAllSelection()
                    LoadOpenRecWorkorder()
                ElseIf sender.name = "btnSelectClaim" Then
                    ProcessSelectedClaim()
                ElseIf sender.name = "btnCloseWO" Then
                    CloseWO()
                    'ElseIf sender.name = "btnReOpenWO" Then
                    '    ReOpenWO()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name & " Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub ProcessSelectedClaim()
            Try
                If Me.dgOpenRecWO.RowCount > 0 AndAlso Me.dgOpenRecWO.Columns.Count > 0 Then
                    If Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row) > 0 Then
                        Dim strAddress As String = ""

                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Model").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblModel.Text = Me.dgOpenRecWO.Columns("Model").CellValue(Me.dgOpenRecWO.Row)
                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Manufacture").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblManuf.Text = Me.dgOpenRecWO.Columns("Manufacture").CellValue(Me.dgOpenRecWO.Row)
                        Me.btnReceive.Visible = False

                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Name").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblName.Text = Me.dgOpenRecWO.Columns("Name").CellValue(Me.dgOpenRecWO.Row)

                        strAddress = Me.dgOpenRecWO.Columns("Address1").CellValue(Me.dgOpenRecWO.Row) & Environment.NewLine
                        strAddress &= Me.dgOpenRecWO.Columns("City").CellValue(Me.dgOpenRecWO.Row) & ", " & Me.dgOpenRecWO.Columns("State").CellValue(Me.dgOpenRecWO.Row) & " " & Me.dgOpenRecWO.Columns("ZipCode").CellValue(Me.dgOpenRecWO.Row)
                        Me.lblAddress.Text = strAddress
                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Tel").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblPhone.Text = Me.dgOpenRecWO.Columns("Tel").CellValue(Me.dgOpenRecWO.Row)
                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Email").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblEmail.Text = Me.dgOpenRecWO.Columns("Email").CellValue(Me.dgOpenRecWO.Row)
                        Me.dgOpenRecWO.Enabled = False

                        'Create tray
                        Me._iTrayID = Generic.GetTrayID(Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row))
                        If Me._iTrayID = 0 Then Me._iTrayID = Me._objProdRec.InsertIntoTtray(PSS.Core.ApplicationUser.IDuser, _
                                                                                             PSS.Core.ApplicationUser.User, _
                                                                                             Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row)) 'Me.dgOpenRecWO.Columns("Claim #").CellValue(Me.dgOpenRecWO.Row))
                        Me.lblRecdQty.Text = Generic.GetRecQty(Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row))
                        Me.lblClaimQty.Text = Me.dgOpenRecWO.Columns("Qty").CellValue(Me.dgOpenRecWO.Row)
                        Me.chklstAccessories.DataSource = Me._dtAccessories
                        Me.chklstAccessories.DisplayMember = "AccessoryDesc"
                        Me.chklstAccessories.ValueMember = "A_ID"
                    End If
                    '**********************************************
                    Me.txtManufSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSelectedClaim", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub CloseWO(Optional ByVal booDisplayCompletedMsg As Boolean = True)
            Const iStatusID As Integer = 3
            Dim R1 As DataRow
            Dim i, iRecUnitCnt As Integer
            Dim strStatusDesc As String = ""

            Try
                If Me.dgOpenRecWO.RowCount > 0 AndAlso Me.dgOpenRecWO.Columns.Count > 0 Then
                    If Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row) > 0 Then
                        R1 = Me._objProdRec.GetWorkorderInfo(Me.dgOpenRecWO.Columns("Claim #").CellValue(Me.dgOpenRecWO.Row), , PSS.Data.Buisness.AIG.LOCID)
                        i = 0 : iRecUnitCnt = 0

                        If IsNothing(R1) Then
                            MessageBox.Show("This claim # '" & Me.dgOpenRecWO.Columns("Claim #").CellValue(Me.dgOpenRecWO.Row) & "' does not exist in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf R1("WO_Closed") = 1 Then
                            MessageBox.Show("This claim # '" & Me.dgOpenRecWO.Columns("Claim #").CellValue(Me.dgOpenRecWO.Row) & "' is already closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf R1("WO_Shipped") = 1 Then
                            MessageBox.Show("This claim # '" & Me.dgOpenRecWO.Columns("Claim #").CellValue(Me.dgOpenRecWO.Row) & "' has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iRecUnitCnt = PSS.Data.Buisness.Generic.GetRecQty(R1("WO_ID"))
                            If iRecUnitCnt = 0 Then
                                MessageBox.Show("This claim # '" & Me.dgOpenRecWO.Columns("Claim #").CellValue(Me.dgOpenRecWO.Row) & "' is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Else
                                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                                i = PSS.Data.Buisness.Generic.CloseWO(R1("WO_ID"))
                                If i > 0 Then
                                    'strStatusDesc = Me._objTMIRec.GetTMIStatusDesc(iStatusID)
                                    If strStatusDesc.Trim.Length = 0 Then strStatusDesc = "Unit Received"
                                    'Me._objTMIRec.UpdateTMIOrderCurrentStatus(R1("WO_ID"), strStatusDesc, False, iStatusID, "", 0, 0)
                                    ClearAllSelection() : LoadOpenRecWorkorder()
                                    Me.Enabled = True : Cursor.Current = Cursors.Default
                                    If booDisplayCompletedMsg Then MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CloseWO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub ReOpenWO()
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strWorkOrder As String = ""

            Try
                strWorkOrder = InputBox("Enter Claim #:").Trim.ToUpper
                If strWorkOrder.Trim.Length > 0 Then
                    Me.ClearAllSelection()

                    R1 = Me._objProdRec.GetWorkorderInfo(strWorkOrder, , PSS.Data.Buisness.AIG.LOCID)

                    If IsNothing(R1) Then
                        MessageBox.Show("This claim # " & strWorkOrder & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf R1("WO_Closed") = 0 Then
                        MessageBox.Show("This claim # " & strWorkOrder & " is open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf (Not IsDBNull(R1("WO_DateShip")) AndAlso R1("WO_DateShip").ToString.Trim.Length > 0) OrElse R1("WO_Shipped") = 1 Then
                        MessageBox.Show("This claim # " & strWorkOrder & " has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.ReOpenWO(R1("WO_ID"))
                        If i > 0 Then
                            Me.ClearAllSelection() : Me.LoadOpenRecWorkorder() : Me.Enabled = True
                            MessageBox.Show("Claim # is now open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub txtManufSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtManufSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtManufSN.Text.Trim.Length > 0 Then
                    Me.ProcessSN()
                End If 'Key up and input length > 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtManufSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True : Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub ProcessSN()
            Dim iCCID, iWOID, iDeviceID, iPSSWrty, iPssiStatusID, iWipOwnerID, iPssWrtyOnDeviceID, iSNDiscpFlag As Integer
            Dim strWorkStation, strExpectedShipDate, strEDISerialNo, strPssiStatus As String
            Dim dtManufSN, dtPartNeed As DataTable
            Dim arlstAccessories As ArrayList
            Dim objProdRec As Data.Production.Receiving

            Try
                strWorkStation = "" : strExpectedShipDate = ""
                strEDISerialNo = Me.dgOpenRecWO.Columns("EDI S/N").CellValue(Me.dgOpenRecWO.Row).ToString.Trim

                If Convert.ToInt32(Me.dgOpenRecWO.Columns("Qty").CellValue(Me.dgOpenRecWO.Row)) = 0 Then
                    MessageBox.Show("RMA is empty. Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                ElseIf Me.txtManufSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter Manufacture S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                ElseIf Generic.IsSNInWIP(Me._iMenuCustID, Me.txtManufSN.Text.Trim) = True Then
                    MessageBox.Show("S/N is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                ElseIf Me._iTrayID = 0 Then
                    MessageBox.Show("Can't define Tray ID. Please re-select RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Convert.ToInt32(Me.lblRecdQty.Text) >= Convert.ToInt32(Me.dgOpenRecWO.Columns("Qty").CellValue(Me.dgOpenRecWO.Row)) Then
                    MessageBox.Show("Can't receive more than claim's quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf strEDISerialNo.Trim.Length = 0 Then
                    MessageBox.Show("S/N in EDI is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'ElseIf strEDISerialNo.ToLower <> Me.txtManufSN.Text.Trim.ToLower Then
                    '    MessageBox.Show("Serial number does not match (" & strEDISerialNo.ToLower & " vs " & Me.txtManufSN.Text.Trim.ToLower & " ). Please verify claim #. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                ElseIf Generic.IsSNInWIP(Me._iMenuCustID, Me.txtManufSN.Text.Trim) = True Then
                    MessageBox.Show("S/N is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                ElseIf Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row).ToString.Trim.Length = 0 OrElse Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row) = 0 Then
                    MessageBox.Show("Workorder is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                Else
                    objProdRec = New Data.Production.Receiving()

                    iCCID = 0 : iWOID = Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row)

                    arlstAccessories = Me.GetAccessoryCheckList
                    iPSSWrty = 0 : iSNDiscpFlag = 0
                    iPSSWrty = Me._objProdRec.IsDeviceUnderPSSWrty_BaseOnProdShipDate(Me.txtManufSN.Text.Trim, PSS.Data.Buisness.AIG.LOCID, iPssWrtyOnDeviceID)

                    '*****************************************
                    'Get next workstation
                    '*****************************************
                    strWorkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, , iPSSWrty)
                    If strWorkStation.Trim.Length = 0 Then Throw New Exception("Wip bucket is missing.")
                    '*****************************************
                    dtPartNeed = Me._objAIG.GetPartNeed(iWOID)
                    If strEDISerialNo.ToLower <> Me.txtManufSN.Text.Trim.ToLower Then 'SN discrenpancy
                        If Not Me._objAIG.SN_ExistsInEDI(Me._iMenuCustID, Me.txtManufSN.Text.Trim) Then 'strEDISerialNo is do belong to any other claims
                            iWipOwnerID = 6 : iPssiStatusID = 10
                            strWorkStation = Me._objAIG.strAwaitApproval_SN_Discrepancy '"AWAIT APPROVAL (SN Discp)"
                            iSNDiscpFlag = 1
                        Else
                            MessageBox.Show("Other open claims already has this SN '" & Me.txtManufSN.Text.Trim & "'. Can't received it.", "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.Enabled = True : Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                        End If
                    ElseIf dtPartNeed.Rows.Count > 0 AndAlso dtPartNeed.Select("[Part Arrived] = 'No'").Length > 0 Then
                        iPssiStatusID = 6 'Waiting Parts
                        iWipOwnerID = 8 : strWorkStation = "AWAP"
                    ElseIf iPSSWrty = 1 Then
                        iWipOwnerID = 6 : iPssiStatusID = 10
                    Else
                        iPssiStatusID = 3 : iWipOwnerID = 1
                    End If

                    strPssiStatus = Data.Buisness.TMIRecShip.GetTMIStatusDesc(iPssiStatusID)
                    If strPssiStatus.Trim.Length = 0 Then Throw New Exception("Pssi status is missing.")
                    '*****************************************

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    '*****************************************
                    'Cal strExpectedShipDate
                    strExpectedShipDate = Me._objAIG.CalExpectedShipDate(Me._iMenuCustID, CInt(Me.dgOpenRecWO.Columns("State_ID").CellValue(Me.dgOpenRecWO.Row)))
                    If strExpectedShipDate.Trim.Length = 0 Then Throw New Exception("System can't define expected ship date.")

                    iDeviceID = Me._objAIG.ReceiveDeviceIntoWIP(iWOID, Me._iTrayID, _iModelID, Me.txtManufSN.Text.Trim.ToUpper, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, iCCID, strWorkStation, iPSSWrty, arlstAccessories, strExpectedShipDate, iPssiStatusID, strPssiStatus, iWipOwnerID, iPssWrtyOnDeviceID, iSNDiscpFlag)

                    If iDeviceID > 0 Then
                        Me.lblRecdQty.Text = Generic.GetRecQty(iWOID)

                        'Add notes if any
                        If Me.txtNotes.Text.Trim.Length > 0 Then
                            Me._objAIG.AddReceivingNotes(Me._iTrayID, Me.txtNotes.Text)
                        End If

                        'Close workorder
                        If Convert.ToInt32(Me.lblClaimQty.Text) >= Convert.ToInt32(Me.lblRecdQty.Text) Then
                            CloseWO(False)
                            MessageBox.Show("RMA received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        Me.txtNotes.Text = ""
                        Me.Enabled = True : Me.txtManufSN.Enabled = True : Me.txtManufSN.Text = "" : Me.txtManufSN.Focus()
                    End If 'Sucessully received
                    End If 'validation
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtManufSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True : Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
            Finally
                objProdRec = Nothing
                Generic.DisposeDT(dtManufSN) : Generic.DisposeDT(dtPartNeed)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub btnReprintLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintLabels.Click
            Dim strSN As String = ""
            Dim dt As DataTable
            Dim arlstAccessories As ArrayList

            Try
                strSN = InputBox("Enter S/N:", "Reprint S/N Label").Trim
                If strSN.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dt = Generic.GetDeviceInfoInWIP(strSN, Me._iMenuCustID, Me._iMenuLocID, True)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Device does not exist in WIP", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me._objAIG.PrintReceivingLabel(dt.Rows(0)("Device_ID"))
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintSNLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
            Try
                Me.ProcessSN()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '************************************************************************************************** 
        Private Function GetAccessoryCheckList() As System.Collections.ArrayList
            Dim arlstAccessories As New ArrayList()
            Dim i As Integer = 0

            Try
                For i = 0 To Me.chklstAccessories.Items.Count - 1
                    If Me.chklstAccessories.GetItemCheckState(i) = CheckState.Checked Then
                        arlstAccessories.Add(Me.chklstAccessories.Items.Item(i)("A_ID"))
                    End If
                Next i
                Return arlstAccessories
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '************************************************************************************************** 

    End Class
End Namespace