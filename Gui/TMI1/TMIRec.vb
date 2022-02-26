Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class TMIRec
        Inherits System.Windows.Forms.Form

        Public _strScreenName As String = ""
        Private _objTMIRec As TMIRecShip
        Private _objProdRec As PSS.Data.Production.Receiving
        Private _iTrayID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName

            _objTMIRec = New TMIRecShip()
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
        Friend WithEvents gbCustInfo As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents lblEmail As System.Windows.Forms.Label
        Friend WithEvents lblManuf As System.Windows.Forms.Label
        Friend WithEvents lblProdDesc As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnClearSelection As System.Windows.Forms.Button
        Friend WithEvents txtManufSN As System.Windows.Forms.TextBox
        Friend WithEvents btnSelectClaim As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dgOpenRecWO As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCloseWO As System.Windows.Forms.Button
        Friend WithEvents btnReOpenWO As System.Windows.Forms.Button
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents btnRefreshWO As System.Windows.Forms.Button
        Friend WithEvents lblRecdQty As System.Windows.Forms.Label
        Friend WithEvents lblClaimQty As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents btnReprintSNLabel As System.Windows.Forms.Button
        Friend WithEvents gbChangeManufSN As System.Windows.Forms.GroupBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtNewManufSN As System.Windows.Forms.TextBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents btnUpdateManufSN As System.Windows.Forms.Button
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents btnReceive As System.Windows.Forms.Button
        Friend WithEvents lblPrevRepClaimNo As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents txtWeight As System.Windows.Forms.TextBox
        Friend WithEvents txtFreightage As System.Windows.Forms.TextBox
        Friend WithEvents txtEditEditManufSNPssSN As System.Windows.Forms.TextBox
        Friend WithEvents txtRecPssSn As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TMIRec))
            Me.btnRefreshWO = New System.Windows.Forms.Button()
            Me.gbCustInfo = New System.Windows.Forms.GroupBox()
            Me.lblEmail = New System.Windows.Forms.Label()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.lblName = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.lblProdDesc = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtManufSN = New System.Windows.Forms.TextBox()
            Me.btnClearSelection = New System.Windows.Forms.Button()
            Me.dgOpenRecWO = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnSelectClaim = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnCloseWO = New System.Windows.Forms.Button()
            Me.btnReOpenWO = New System.Windows.Forms.Button()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblRecdQty = New System.Windows.Forms.Label()
            Me.lblClaimQty = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.btnReprintSNLabel = New System.Windows.Forms.Button()
            Me.gbChangeManufSN = New System.Windows.Forms.GroupBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtNewManufSN = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtEditEditManufSNPssSN = New System.Windows.Forms.TextBox()
            Me.btnUpdateManufSN = New System.Windows.Forms.Button()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtRecPssSn = New System.Windows.Forms.TextBox()
            Me.btnReceive = New System.Windows.Forms.Button()
            Me.lblPrevRepClaimNo = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.txtWeight = New System.Windows.Forms.TextBox()
            Me.txtFreightage = New System.Windows.Forms.TextBox()
            Me.gbCustInfo.SuspendLayout()
            CType(Me.dgOpenRecWO, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbChangeManufSN.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnRefreshWO
            '
            Me.btnRefreshWO.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshWO.ForeColor = System.Drawing.Color.White
            Me.btnRefreshWO.Location = New System.Drawing.Point(104, 16)
            Me.btnRefreshWO.Name = "btnRefreshWO"
            Me.btnRefreshWO.Size = New System.Drawing.Size(120, 23)
            Me.btnRefreshWO.TabIndex = 1
            Me.btnRefreshWO.Text = "Refresh List"
            '
            'gbCustInfo
            '
            Me.gbCustInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEmail, Me.lblPhone, Me.lblAddress, Me.lblName, Me.Label5, Me.Label4, Me.Label2, Me.Label1})
            Me.gbCustInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCustInfo.ForeColor = System.Drawing.Color.White
            Me.gbCustInfo.Location = New System.Drawing.Point(448, 296)
            Me.gbCustInfo.Name = "gbCustInfo"
            Me.gbCustInfo.Size = New System.Drawing.Size(288, 192)
            Me.gbCustInfo.TabIndex = 182
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
            'lblManuf
            '
            Me.lblManuf.BackColor = System.Drawing.Color.White
            Me.lblManuf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblManuf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManuf.ForeColor = System.Drawing.Color.Black
            Me.lblManuf.Location = New System.Drawing.Point(104, 384)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(200, 20)
            Me.lblManuf.TabIndex = 186
            Me.lblManuf.Tag = "0"
            Me.lblManuf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblProdDesc
            '
            Me.lblProdDesc.BackColor = System.Drawing.Color.White
            Me.lblProdDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblProdDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProdDesc.ForeColor = System.Drawing.Color.Black
            Me.lblProdDesc.Location = New System.Drawing.Point(104, 360)
            Me.lblProdDesc.Name = "lblProdDesc"
            Me.lblProdDesc.Size = New System.Drawing.Size(200, 20)
            Me.lblProdDesc.TabIndex = 185
            Me.lblProdDesc.Tag = "0"
            Me.lblProdDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(16, 384)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(88, 16)
            Me.Label9.TabIndex = 184
            Me.Label9.Text = "Manufacture :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(16, 360)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(88, 16)
            Me.Label10.TabIndex = 183
            Me.Label10.Text = "Product Type :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(24, 472)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(80, 16)
            Me.Label6.TabIndex = 190
            Me.Label6.Text = "Manuf S/N :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtManufSN
            '
            Me.txtManufSN.Location = New System.Drawing.Point(104, 472)
            Me.txtManufSN.MaxLength = 30
            Me.txtManufSN.Name = "txtManufSN"
            Me.txtManufSN.Size = New System.Drawing.Size(200, 20)
            Me.txtManufSN.TabIndex = 7
            Me.txtManufSN.Text = ""
            '
            'btnClearSelection
            '
            Me.btnClearSelection.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClearSelection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearSelection.ForeColor = System.Drawing.Color.White
            Me.btnClearSelection.Location = New System.Drawing.Point(16, 16)
            Me.btnClearSelection.Name = "btnClearSelection"
            Me.btnClearSelection.Size = New System.Drawing.Size(56, 23)
            Me.btnClearSelection.TabIndex = 0
            Me.btnClearSelection.Text = "Clear"
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
            Me.dgOpenRecWO.Size = New System.Drawing.Size(952, 240)
            Me.dgOpenRecWO.TabIndex = 4
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
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 948, 236<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 948, 236</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
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
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(32, 336)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 195
            Me.Label3.Text = "Model :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCloseWO
            '
            Me.btnCloseWO.BackColor = System.Drawing.Color.Navy
            Me.btnCloseWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWO.ForeColor = System.Drawing.Color.White
            Me.btnCloseWO.Location = New System.Drawing.Point(416, 16)
            Me.btnCloseWO.Name = "btnCloseWO"
            Me.btnCloseWO.Size = New System.Drawing.Size(128, 23)
            Me.btnCloseWO.TabIndex = 196
            Me.btnCloseWO.Text = "Close Claim"
            '
            'btnReOpenWO
            '
            Me.btnReOpenWO.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReOpenWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReOpenWO.ForeColor = System.Drawing.Color.White
            Me.btnReOpenWO.Location = New System.Drawing.Point(560, 16)
            Me.btnReOpenWO.Name = "btnReOpenWO"
            Me.btnReOpenWO.Size = New System.Drawing.Size(136, 23)
            Me.btnReOpenWO.TabIndex = 197
            Me.btnReOpenWO.Text = "Re-Open Claim"
            Me.btnReOpenWO.Visible = False
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(104, 336)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(200, 20)
            Me.lblModel.TabIndex = 198
            Me.lblModel.Tag = "0"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecdQty
            '
            Me.lblRecdQty.BackColor = System.Drawing.Color.Black
            Me.lblRecdQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblRecdQty.Font = New System.Drawing.Font("Tahoma", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecdQty.ForeColor = System.Drawing.Color.Green
            Me.lblRecdQty.Location = New System.Drawing.Point(320, 392)
            Me.lblRecdQty.Name = "lblRecdQty"
            Me.lblRecdQty.Size = New System.Drawing.Size(88, 48)
            Me.lblRecdQty.TabIndex = 199
            Me.lblRecdQty.Tag = "0"
            Me.lblRecdQty.Text = "0"
            Me.lblRecdQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblClaimQty
            '
            Me.lblClaimQty.BackColor = System.Drawing.Color.Black
            Me.lblClaimQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblClaimQty.Font = New System.Drawing.Font("Tahoma", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblClaimQty.ForeColor = System.Drawing.Color.Green
            Me.lblClaimQty.Location = New System.Drawing.Point(320, 312)
            Me.lblClaimQty.Name = "lblClaimQty"
            Me.lblClaimQty.Size = New System.Drawing.Size(88, 48)
            Me.lblClaimQty.TabIndex = 200
            Me.lblClaimQty.Tag = "0"
            Me.lblClaimQty.Text = "0"
            Me.lblClaimQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(320, 296)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 201
            Me.Label7.Text = "Claim Qty :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(312, 376)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(104, 16)
            Me.Label8.TabIndex = 202
            Me.Label8.Text = "Received Qty :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'btnReprintSNLabel
            '
            Me.btnReprintSNLabel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReprintSNLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintSNLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintSNLabel.Location = New System.Drawing.Point(320, 464)
            Me.btnReprintSNLabel.Name = "btnReprintSNLabel"
            Me.btnReprintSNLabel.Size = New System.Drawing.Size(120, 23)
            Me.btnReprintSNLabel.TabIndex = 8
            Me.btnReprintSNLabel.Text = "Reprint S/N Label"
            '
            'gbChangeManufSN
            '
            Me.gbChangeManufSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label13, Me.Label14, Me.Label12, Me.txtNewManufSN, Me.Label11, Me.txtEditEditManufSNPssSN, Me.btnUpdateManufSN})
            Me.gbChangeManufSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbChangeManufSN.ForeColor = System.Drawing.Color.White
            Me.gbChangeManufSN.Location = New System.Drawing.Point(744, 296)
            Me.gbChangeManufSN.Name = "gbChangeManufSN"
            Me.gbChangeManufSN.Size = New System.Drawing.Size(224, 192)
            Me.gbChangeManufSN.TabIndex = 204
            Me.gbChangeManufSN.TabStop = False
            Me.gbChangeManufSN.Text = "Change Manufacture S/N"
            Me.gbChangeManufSN.Visible = False
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.White
            Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.Black
            Me.Label13.Location = New System.Drawing.Point(8, 86)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(200, 16)
            Me.Label13.TabIndex = 196
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label14
            '
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.White
            Me.Label14.Location = New System.Drawing.Point(8, 70)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(96, 16)
            Me.Label14.TabIndex = 195
            Me.Label14.Text = "Manuf S/N :"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(8, 112)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(160, 16)
            Me.Label12.TabIndex = 194
            Me.Label12.Text = "New Manuf S/N :"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtNewManufSN
            '
            Me.txtNewManufSN.Location = New System.Drawing.Point(8, 128)
            Me.txtNewManufSN.MaxLength = 30
            Me.txtNewManufSN.Name = "txtNewManufSN"
            Me.txtNewManufSN.Size = New System.Drawing.Size(200, 21)
            Me.txtNewManufSN.TabIndex = 193
            Me.txtNewManufSN.Text = ""
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(8, 24)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(80, 16)
            Me.Label11.TabIndex = 192
            Me.Label11.Text = "PSS S/N :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtEditEditManufSNPssSN
            '
            Me.txtEditEditManufSNPssSN.Location = New System.Drawing.Point(8, 40)
            Me.txtEditEditManufSNPssSN.MaxLength = 30
            Me.txtEditEditManufSNPssSN.Name = "txtEditEditManufSNPssSN"
            Me.txtEditEditManufSNPssSN.Size = New System.Drawing.Size(200, 21)
            Me.txtEditEditManufSNPssSN.TabIndex = 191
            Me.txtEditEditManufSNPssSN.Text = ""
            '
            'btnUpdateManufSN
            '
            Me.btnUpdateManufSN.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnUpdateManufSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateManufSN.ForeColor = System.Drawing.Color.Black
            Me.btnUpdateManufSN.Location = New System.Drawing.Point(64, 160)
            Me.btnUpdateManufSN.Name = "btnUpdateManufSN"
            Me.btnUpdateManufSN.Size = New System.Drawing.Size(96, 23)
            Me.btnUpdateManufSN.TabIndex = 205
            Me.btnUpdateManufSN.Text = "Save Change"
            '
            'Label15
            '
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.White
            Me.Label15.Location = New System.Drawing.Point(16, 448)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(80, 16)
            Me.Label15.TabIndex = 206
            Me.Label15.Text = "PSS S/N :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRecPssSn
            '
            Me.txtRecPssSn.Enabled = False
            Me.txtRecPssSn.Location = New System.Drawing.Point(104, 448)
            Me.txtRecPssSn.MaxLength = 30
            Me.txtRecPssSn.Name = "txtRecPssSn"
            Me.txtRecPssSn.Size = New System.Drawing.Size(200, 20)
            Me.txtRecPssSn.TabIndex = 6
            Me.txtRecPssSn.Tag = "0"
            Me.txtRecPssSn.Text = ""
            '
            'btnReceive
            '
            Me.btnReceive.BackColor = System.Drawing.Color.Green
            Me.btnReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceive.ForeColor = System.Drawing.Color.White
            Me.btnReceive.Location = New System.Drawing.Point(104, 504)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.Size = New System.Drawing.Size(200, 23)
            Me.btnReceive.TabIndex = 207
            Me.btnReceive.Text = "Receive"
            '
            'lblPrevRepClaimNo
            '
            Me.lblPrevRepClaimNo.BackColor = System.Drawing.Color.Black
            Me.lblPrevRepClaimNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPrevRepClaimNo.Font = New System.Drawing.Font("Tahoma", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPrevRepClaimNo.ForeColor = System.Drawing.Color.Green
            Me.lblPrevRepClaimNo.Location = New System.Drawing.Point(104, 296)
            Me.lblPrevRepClaimNo.Name = "lblPrevRepClaimNo"
            Me.lblPrevRepClaimNo.Size = New System.Drawing.Size(200, 32)
            Me.lblPrevRepClaimNo.TabIndex = 208
            Me.lblPrevRepClaimNo.Tag = "0"
            Me.lblPrevRepClaimNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label17
            '
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(0, 304)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(104, 16)
            Me.Label17.TabIndex = 209
            Me.Label17.Text = "Previous Claim # :"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label18
            '
            Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.White
            Me.Label18.Location = New System.Drawing.Point(8, 416)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(96, 16)
            Me.Label18.TabIndex = 210
            Me.Label18.Text = "Box Weight (lb) :"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label18.Visible = False
            '
            'Label20
            '
            Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.White
            Me.Label20.Location = New System.Drawing.Point(144, 416)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(112, 16)
            Me.Label20.TabIndex = 212
            Me.Label20.Text = "Cal. Freightage($):"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label20.Visible = False
            '
            'txtWeight
            '
            Me.txtWeight.Location = New System.Drawing.Point(104, 416)
            Me.txtWeight.Name = "txtWeight"
            Me.txtWeight.Size = New System.Drawing.Size(40, 20)
            Me.txtWeight.TabIndex = 214
            Me.txtWeight.Text = ""
            Me.txtWeight.Visible = False
            '
            'txtFreightage
            '
            Me.txtFreightage.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.txtFreightage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFreightage.Enabled = False
            Me.txtFreightage.Location = New System.Drawing.Point(256, 416)
            Me.txtFreightage.Name = "txtFreightage"
            Me.txtFreightage.Size = New System.Drawing.Size(50, 20)
            Me.txtFreightage.TabIndex = 215
            Me.txtFreightage.Text = "0"
            Me.txtFreightage.Visible = False
            '
            'TMIRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(992, 574)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFreightage, Me.txtWeight, Me.Label20, Me.Label18, Me.Label17, Me.lblPrevRepClaimNo, Me.btnReceive, Me.Label15, Me.txtRecPssSn, Me.gbChangeManufSN, Me.btnReprintSNLabel, Me.Label8, Me.Label7, Me.lblClaimQty, Me.lblRecdQty, Me.lblModel, Me.btnReOpenWO, Me.btnCloseWO, Me.Label3, Me.btnSelectClaim, Me.dgOpenRecWO, Me.btnClearSelection, Me.Label6, Me.txtManufSN, Me.lblManuf, Me.lblProdDesc, Me.Label9, Me.Label10, Me.gbCustInfo, Me.btnRefreshWO})
            Me.Name = "TMIRec"
            Me.Text = "TMIRec"
            Me.gbCustInfo.ResumeLayout(False)
            CType(Me.dgOpenRecWO, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbChangeManufSN.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************************************      
        Private Sub TMIRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)
                LoadOpenRecWorkorder()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub LoadOpenRecWorkorder()
            Dim dt As DataTable

            Try
                dt = Me._objTMIRec.GetOpenRecWorkOrder(TMI.LOCID)
                With Me.dgOpenRecWO
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("Model_ID").Visible = False
                    .Splits(0).DisplayColumns("Manuf_ID").Visible = False
                    .Splits(0).DisplayColumns("Prod_ID").Visible = False
                    '.Splits(0).DisplayColumns("LastClaimNo").Visible = False

                    .Splits(0).DisplayColumns("PrevRepDeviceID").Visible = False
                    .Splits(0).DisplayColumns("PrevRepModelID").Visible = False
                    .Splits(0).DisplayColumns("PrevRepManufID").Visible = False
                    .Splits(0).DisplayColumns("PrevRepProdID").Visible = False
                End With

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**************************************************************************************************
        Private Sub ClearAllSelection()
            Try
                Me.lblPrevRepClaimNo.Text = ""
                Me.lblModel.Text = "" : Me.lblModel.Tag = 0
                Me.lblProdDesc.Text = "" : Me.lblProdDesc.Tag = 0
                Me.lblManuf.Text = "" : Me.lblManuf.Tag = 0
                Me.txtManufSN.Text = ""

                'Customer info
                Me.lblName.Text = ""
                Me.lblAddress.Text = ""
                Me.lblPhone.Text = ""
                Me.lblEmail.Text = ""

                Me.dgOpenRecWO.Enabled = True
                Me.lblRecdQty.Text = "0"
                Me.lblClaimQty.Text = "0"

                Me.btnReceive.Visible = False
                Me.txtRecPssSn.Text = ""

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
                ElseIf sender.name = "btnReOpenWO" Then
                    ReOpenWO()
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

                        If Me.dgOpenRecWO.Columns("LastClaimNo").CellValue(Me.dgOpenRecWO.Row).ToString.Length > 0 Then
                            '**********************************************
                            'PSS WARRANTY
                            '**********************************************
                            If Me.dgOpenRecWO.Columns("Prev Rep S/N").CellValue(Me.dgOpenRecWO.Row).ToString.Length = 0 Then
                                MessageBox.Show("Systen can't define previous repair serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            ElseIf Convert.ToInt32(Me.dgOpenRecWO.Columns("PrevRepModelID").CellValue(Me.dgOpenRecWO.Row)) = 0 Then
                                MessageBox.Show("Systen can't define previous repair model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            ElseIf IsDBNull(Me.dgOpenRecWO.Columns("Prev Rep Ship Date").CellValue(Me.dgOpenRecWO.Row)) = True Then
                                MessageBox.Show("Previous claim still have open unit. Please contact your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            Else
                                Me.lblPrevRepClaimNo.Text = Me.dgOpenRecWO.Columns("LastClaimNo").CellValue(Me.dgOpenRecWO.Row)
                                Me.lblProdDesc.Text = Me.dgOpenRecWO.Columns("Prev Rep Product Type").CellValue(Me.dgOpenRecWO.Row)
                                Me.lblProdDesc.Tag = Me.dgOpenRecWO.Columns("PrevRepProdID").CellValue(Me.dgOpenRecWO.Row)
                                Me.lblModel.Text = Me.dgOpenRecWO.Columns("Prev Rep Model").CellValue(Me.dgOpenRecWO.Row)
                                Me.lblModel.Tag = Me.dgOpenRecWO.Columns("PrevRepModelID").CellValue(Me.dgOpenRecWO.Row)
                                Me.lblManuf.Text = Me.dgOpenRecWO.Columns("Prev Rep Manufacture").CellValue(Me.dgOpenRecWO.Row)
                                Me.lblManuf.Tag = Me.dgOpenRecWO.Columns("PrevRepManufID").CellValue(Me.dgOpenRecWO.Row)
                                Me.txtManufSN.Text = Me.dgOpenRecWO.Columns("Prev Rep Manuf S/N").CellValue(Me.dgOpenRecWO.Row)
                                Me.txtRecPssSn.Text = Me.dgOpenRecWO.Columns("Prev Rep S/N").CellValue(Me.dgOpenRecWO.Row)
                                Me.btnReceive.Visible = True : Me.txtManufSN.Enabled = False
                            End If
                            '**********************************************
                        Else
                            If Not IsDBNull(Me.dgOpenRecWO.Columns("Type").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblProdDesc.Text = Me.dgOpenRecWO.Columns("Type").CellValue(Me.dgOpenRecWO.Row)
                            If Not IsDBNull(Me.dgOpenRecWO.Columns("Prod_ID").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblProdDesc.Tag = Me.dgOpenRecWO.Columns("Prod_ID").CellValue(Me.dgOpenRecWO.Row)
                            If Not IsDBNull(Me.dgOpenRecWO.Columns("Model").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblModel.Text = Me.dgOpenRecWO.Columns("Model").CellValue(Me.dgOpenRecWO.Row)
                            If Not IsDBNull(Me.dgOpenRecWO.Columns("Model_ID").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblModel.Tag = Me.dgOpenRecWO.Columns("Model_ID").CellValue(Me.dgOpenRecWO.Row)
                            If Not IsDBNull(Me.dgOpenRecWO.Columns("Manufacture").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblManuf.Text = Me.dgOpenRecWO.Columns("Manufacture").CellValue(Me.dgOpenRecWO.Row)
                            If Not IsDBNull(Me.dgOpenRecWO.Columns("Manuf_ID").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblManuf.Tag = Me.dgOpenRecWO.Columns("Manuf_ID").CellValue(Me.dgOpenRecWO.Row)
                            Me.btnReceive.Visible = False
                        End If

                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Name").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblName.Text = Me.dgOpenRecWO.Columns("Name").CellValue(Me.dgOpenRecWO.Row)

                        strAddress = Me.dgOpenRecWO.Columns("Address1").CellValue(Me.dgOpenRecWO.Row) & Environment.NewLine
                        strAddress &= Me.dgOpenRecWO.Columns("City").CellValue(Me.dgOpenRecWO.Row) & ", " & Me.dgOpenRecWO.Columns("State").CellValue(Me.dgOpenRecWO.Row) & " " & Me.dgOpenRecWO.Columns("ZipCode").CellValue(Me.dgOpenRecWO.Row)
                        Me.lblAddress.Text = strAddress
                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Tel").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblPhone.Text = Me.dgOpenRecWO.Columns("Tel").CellValue(Me.dgOpenRecWO.Row)
                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Email").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblEmail.Text = Me.dgOpenRecWO.Columns("Email").CellValue(Me.dgOpenRecWO.Row)
                        Me.dgOpenRecWO.Enabled = False

                        Me._iTrayID = Generic.GetTrayID(Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row))
                        If Me._iTrayID = 0 Then Me._iTrayID = Me._objProdRec.InsertIntoTtray(PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row), Me.dgOpenRecWO.Columns("Claim #").CellValue(Me.dgOpenRecWO.Row))
                        Me.lblRecdQty.Text = Generic.GetRecQty(Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row))
                        Me.lblClaimQty.Text = Me.dgOpenRecWO.Columns("Qty").CellValue(Me.dgOpenRecWO.Row)

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
                        R1 = Me._objProdRec.GetWorkorderInfo(Me.dgOpenRecWO.Columns("Claim #").CellValue(Me.dgOpenRecWO.Row), , PSS.Data.Buisness.TMI.LOCID)
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
                                    strStatusDesc = Me._objTMIRec.GetTMIStatusDesc(iStatusID)
                                    If strStatusDesc.Trim.Length = 0 Then strStatusDesc = "Unit Received"
                                    Me._objTMIRec.UpdateTMIOrderCurrentStatus(R1("WO_ID"), strStatusDesc, False, iStatusID, "", 0)
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

                    R1 = Me._objProdRec.GetWorkorderInfo(strWorkOrder, , PSS.Data.Buisness.TMI.LOCID)

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
            Dim iCCID, iWOID, iDeviceID, iPSSWrty As Integer
            Dim strWorkStation As String = ""
            Dim dtManufSN As DataTable
            Dim iWeight As Integer, iFreightRate As Double ' iMaxWeight As Integer
            'Dim iCarrierID As Integer, iZone As Integer, iFreightRate As Double
            'Dim strEffectiveDate As String, strZipCode As String
            'Dim errMsg As String = ""
            Dim iR As Integer

            Try
                If Me.lblProdDesc.Tag = 0 Then
                    MessageBox.Show("Product type is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtManufSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter Manufacture S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                ElseIf Generic.IsSNInWIP(TMI.CUSTOMERID, Me.txtManufSN.Text.Trim) = True Then
                    MessageBox.Show("S/N is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                ElseIf Me._iTrayID = 0 Then
                    MessageBox.Show("Can't define Tray ID. Please re-select RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Convert.ToInt32(Me.lblRecdQty.Text) >= Convert.ToInt32(Me.dgOpenRecWO.Columns("Qty").CellValue(Me.dgOpenRecWO.Row)) Then
                    MessageBox.Show("Can't receive more than claim's quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'ElseIf Not IsNumeric(Me.txtFreightage.Text) Then
                    '    MessageBox.Show("Cal. Freightage must be a number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'ElseIf IsNumeric(Me.txtFreightage.Text) AndAlso Not Convert.ToDouble(Me.txtFreightage.Text) > 0 Then
                    '    MessageBox.Show("Cal. Freightage should be > 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'ElseIf Not IsNumeric(Me.txtWeight.Text) Then
                    '    MessageBox.Show("Box Weight must be a number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'ElseIf IsNumeric(Me.txtWeight.Text) AndAlso Not Convert.ToInt32(Me.txtWeight.Text) >= 0.5 Then
                    'MessageBox.Show("Box Weight should be >= 0.5", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If Me.lblModel.Tag = 0 Then Me.CreateModel()

                    If Me.lblModel.Tag = 0 Then Throw New Exception("System has failed to create model.")
                    MapServicesPartsAndAccessories(Me.lblProdDesc.Tag, Me.lblModel.Tag)

                    If Me.txtRecPssSn.Text.Trim.Length > 0 Then Me.txtRecPssSn.Tag = Me._objProdRec.IsDeviceUnderPSSWrty(Me.txtRecPssSn.Text.Trim, PSS.Data.Buisness.TMI.LOCID)

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    '*****************************************
                    'Get next workstation
                    '*****************************************
                    strWorkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, PSS.Data.Buisness.TMI.CUSTOMERID, , )
                    If strWorkStation.Trim.Length = 0 Then Throw New Exception("Wip bucket is missing.")
                    '*****************************************

                    If Me.txtManufSN.Text.Trim.ToLower <> "noserialnumber" Then
                        dtManufSN = Generic.GetManufSNDeviceInfoInWIP(Me.txtManufSN.Text.Trim, PSS.Data.Buisness.TMI.CUSTOMERID, PSS.Data.Buisness.TMI.LOCID)
                        If dtManufSN.Rows.Count > 0 Then
                            MessageBox.Show("This serial# " & Me.txtManufSN.Text & " already entered in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                        ElseIf dtManufSN.Rows.Count > 0 AndAlso Not IsDBNull(dtManufSN.Rows(0)("Pallett_ID")) AndAlso dtManufSN.Rows(0)("Pallett_ID") > 0 Then
                            MessageBox.Show("This serial# " & Me.txtManufSN.Text & " already entered in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                        End If
                    End If

                    iCCID = 0 : iWOID = Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row)
                    ' iWeight = Me.txtWeight.Text
                    ' iFreightRate = (1 + Me._objTMIRec._PSSI_ShippingMargin) * Convert.ToDouble(Me.txtFreightage.Text)
                    ' iFreightRate = Math.Round(iFreightRate, 2)

                    iPSSWrty = Convert.ToInt16(Me.txtRecPssSn.Tag)
                    iDeviceID = Me._objTMIRec.ReceiveDeviceIntoWIP(iWOID, Me._iTrayID, Me.lblModel.Tag, Me.txtManufSN.Text.Trim.ToUpper, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, iCCID, strWorkStation, Me.txtRecPssSn.Text.Trim, iPSSWrty)

                    ''iR = Me._objTMIRec.UpdateTMIReceivedWeightFreightage(iWOID, iWeight, iFreightRate) 'Do it in Receive button click event
                    'If iR = 0 Then 'if not successfully updated, just popup a message to alert
                    '    MessageBox.Show("Failed to update Freightage data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'End If

                    If iDeviceID > 0 Then
                        Me.lblRecdQty.Text = Generic.GetRecQty(iWOID)

                        'Close workorder
                        If Convert.ToInt32(Me.lblClaimQty.Text) >= Convert.ToInt32(Me.lblRecdQty.Text) Then
                            'If MessageBox.Show("You have reached the claim quantity. Would you like to close the RMA?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then 
                            CloseWO(False)
                            MessageBox.Show("RMA closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        Me.txtFreightage.Text = 0 : Me.txtWeight.Text = "" : Me.lblPrevRepClaimNo.Text = ""
                        Me.txtRecPssSn.Text = "" : Me.txtRecPssSn.Tag = 0
                        Me.Enabled = True : Me.txtManufSN.Enabled = True : Me.txtManufSN.Text = "" : Me.txtManufSN.Focus()
                    End If 'Sucessully received
                End If 'validation
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtManufSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Enabled = True : Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
            Finally
                Generic.DisposeDT(dtManufSN)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub ComputeFreightage()
            'Dim iWeight As Integer, iMaxWeight As Integer
            'Dim iCarrierID As Integer, iZone As Integer, iFreightRate As Double
            'Dim strEffectiveDate As String, strZipCode As String
            'Dim errMsg As String = "", iR As Integer
            'Dim iWOID As Integer = 0

            ''*****************************************
            ''Handle freightage data before close
            ''*****************************************
            'Try

            '    If IsNumeric(Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row)) Then
            '        iWOID = Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row)
            '    Else
            '        MessageBox.Show("Invalid Work Order ID!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Exit Sub
            '    End If

            '    If Not IsNumeric(Me.txtWeight.Text) Then
            '        MessageBox.Show("Box weight must be a postive number!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.txtWeight.SelectAll() : Me.txtWeight.Focus() : Exit Sub
            '    ElseIf Not Me.txtWeight.Text >= 0.5 Then
            '        MessageBox.Show("Box weight should be a postive integer number (>=0.5 which will be round to 1)!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.txtWeight.SelectAll() : Me.txtWeight.Focus() : Exit Sub
            '    Else
            '        iWeight = Me.txtWeight.Text
            '        iMaxWeight = _objTMIRec.GetMaxAvailableFreightBoxWeight()
            '        If iWeight > iMaxWeight Then
            '            MessageBox.Show("Box weight is over weight!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            Me.txtWeight.SelectAll() : Me.txtWeight.Focus() : Exit Sub
            '        End If
            '        strZipCode = _objTMIRec.GetTMIZipCode(iWOID)
            '        'strEffectiveDate = Format(Now.Date, "yyyy-MM-dd")
            '        iCarrierID = _objTMIRec.GetTMICarrierID(iWOID)
            '        If Not iCarrierID > 0 Then
            '            MessageBox.Show("Either no carrier ID or no data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            Exit Sub
            '        End If
            '        iZone = _objTMIRec.GetTMIGroundZoneNumber(strZipCode)
            '        If iZone < 0 Then
            '            MessageBox.Show(_objTMIRec.EnumValue2NameString(iZone), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '            Exit Sub
            '        Else
            '            iFreightRate = _objTMIRec.getTMIGroundRate(iWeight, iZone, iCarrierID)
            '            If iFreightRate < 0 Then
            '                MessageBox.Show(_objTMIRec.EnumValue2NameString(iFreightRate), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '                Exit Sub
            '            End If
            '            'Update weight and freightage
            '            'iR = _objTMIRec.UpdateTMIReceivedWeightFreightage(iWOID, iWeight, iFreightRate) 'Do it in Receive button click event
            '            Me.txtFreightage.Text = iFreightRate
            '        End If

            '    End If

            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, "Sub ComputeFreightage ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try

        End Sub

        '**************************************************************************************************
        Private Function CreateModel()
            Dim dt As DataTable
            Dim objSyxRec As PSS.Data.Buisness.SyxReceivingShipping
            Dim iModelID As Integer = 0

            Try
                objSyxRec = New PSS.Data.Buisness.SyxReceivingShipping()
                dt = objSyxRec.GetModelInfo(Me.lblModel.Text)
                If dt.Rows.Count > 0 Then
                    Me.lblModel.Tag = dt.Rows(0)("Model_ID")
                Else
                    If Me.lblManuf.Tag = 0 Then
                        If PSS.Data.Buisness.ModManuf.IsManufExisted(Me.lblManuf.Text) = False Then PSS.Data.Buisness.ModManuf.InsertManuf(Me.lblManuf.Text)
                        Me.lblManuf.Tag = PSS.Data.Buisness.Generic.GetManufactureID(Me.lblManuf.Text)
                        If Me.lblManuf.Tag = 0 Then Throw New Exception("System has failed to create manufacture.")
                    End If

                    Dim ASCPrice_ID, Model_Tier, Model_Flat, ProdGrp_ID, RptGrp_ID As Integer
                    ASCPrice_ID = objSyxRec.GetASCPrice_ID(Me.lblManuf.Tag, Me.lblProdDesc.Tag, True)
                    ProdGrp_ID = objSyxRec.GetProdGrp_ID(Me.lblProdDesc.Tag, Me.lblProdDesc.Text, Me.lblProdDesc.Text, True)
                    RptGrp_ID = objSyxRec.GetRptGrp_ID(Me.lblProdDesc.Tag)
                    If RptGrp_ID < 1 Then
                        MessageBox.Show("Unable to define Report Group for product#" & Me.lblProdDesc.Text & ". Please contact IT immediately.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    End If
                    Model_Tier = ProdGrp_ID : Model_Flat = ProdGrp_ID
                    iModelID = objSyxRec.InsertModel(Me.lblModel.Text, Model_Tier, Model_Flat, ProdGrp_ID, ASCPrice_ID, RptGrp_ID, Me.lblManuf.Tag, Me.lblProdDesc.Tag)
                    Me.lblModel.Tag = iModelID
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objSyxRec = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************************************
        Private Function MapServicesPartsAndAccessories(ByVal iProdID As Integer, ByVal iModelID As Integer)
            Const iPSPrice_Temppart As Integer = 16410
            Dim dtBillcodeByType As DataTable
            Dim R1 As DataRow

            Try
                Dim iBillcodeID As Integer = 0 : Const iLOB_ID As Integer = 20

                '1785-S106-NER Repair CHG
                iBillcodeID = Generic.GetBillCodeID("Exception Repairs", Me.lblProdDesc.Tag)
                If iBillcodeID > 0 AndAlso Generic.IsBillcodeMapped(iModelID, iBillcodeID) = 0 Then
                    PSS.Data.Buisness.PartsMap.InsertMap(1785, iBillcodeID, iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 0, 0, 3, PSS.Core.ApplicationUser.IDuser)
                End If
                iBillcodeID = 0

                'S107-Repair & Reprofile
                iBillcodeID = Generic.GetBillCodeID("Depot Repaired", Me.lblProdDesc.Tag)
                If iBillcodeID > 0 AndAlso Generic.IsBillcodeMapped(iModelID, iBillcodeID) = 0 Then
                    PSS.Data.Buisness.PartsMap.InsertMap(1786, iBillcodeID, iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 0, 0, 3, PSS.Core.ApplicationUser.IDuser)
                End If
                iBillcodeID = 0

                '6603-S108-No Trouble Found
                iBillcodeID = Generic.GetBillCodeID("PSS Warranty No Fault Found", Me.lblProdDesc.Tag)
                If iBillcodeID > 0 AndAlso Generic.IsBillcodeMapped(iModelID, iBillcodeID) = 0 Then
                    PSS.Data.Buisness.PartsMap.InsertMap(6603, iBillcodeID, iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 0, 0, 3, PSS.Core.ApplicationUser.IDuser)
                End If
                iBillcodeID = 0

                'S107-Repair & Reprofile
                iBillcodeID = Generic.GetBillCodeID("Repaired PSS Warranty", Me.lblProdDesc.Tag)
                If iBillcodeID > 0 AndAlso Generic.IsBillcodeMapped(iModelID, iBillcodeID) = 0 Then
                    PSS.Data.Buisness.PartsMap.InsertMap(1786, iBillcodeID, iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 0, 0, 3, PSS.Core.ApplicationUser.IDuser)
                End If
                iBillcodeID = 0

                '5923-S26-RUR
                iBillcodeID = Generic.GetBillCodeID("Exception Repairs Quote Rejected", Me.lblProdDesc.Tag)
                If iBillcodeID > 0 AndAlso Generic.IsBillcodeMapped(iModelID, iBillcodeID) = 0 Then
                    PSS.Data.Buisness.PartsMap.InsertMap(5923, iBillcodeID, iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 0, 0, 3, PSS.Core.ApplicationUser.IDuser)
                End If
                iBillcodeID = 0

                '5923-S26-RUR
                iBillcodeID = Generic.GetBillCodeID("Scrap", Me.lblProdDesc.Tag)
                If iBillcodeID > 0 AndAlso Generic.IsBillcodeMapped(iModelID, iBillcodeID) = 0 Then
                    PSS.Data.Buisness.PartsMap.InsertMap(5923, iBillcodeID, iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 1, 0, 3, PSS.Core.ApplicationUser.IDuser)
                End If
                iBillcodeID = 0

                '17156-S13-Infestation Unit
                iBillcodeID = Generic.GetBillCodeID("Infestation Unit", Me.lblProdDesc.Tag)
                If iBillcodeID > 0 AndAlso Generic.IsBillcodeMapped(iModelID, iBillcodeID) = 0 Then
                    PSS.Data.Buisness.PartsMap.InsertMap(17156, iBillcodeID, iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 0, 0, 3, PSS.Core.ApplicationUser.IDuser)
                End If
                iBillcodeID = 0

                '17156-S13-Ship Back Hard Drive
                iBillcodeID = Generic.GetBillCodeID("Ship Back Hard Drive", Me.lblProdDesc.Tag)
                If iBillcodeID > 0 AndAlso Generic.IsBillcodeMapped(iModelID, iBillcodeID) = 0 Then
                    PSS.Data.Buisness.PartsMap.InsertMap(17156, iBillcodeID, iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 0, 0, 3, PSS.Core.ApplicationUser.IDuser)
                End If
                iBillcodeID = 0

                '17156-S13-Ship Back Hard Drive With Unit
                iBillcodeID = Generic.GetBillCodeID("Ship Back Hard Drive With Unit", Me.lblProdDesc.Tag)
                If iBillcodeID > 0 AndAlso Generic.IsBillcodeMapped(iModelID, iBillcodeID) = 0 Then
                    PSS.Data.Buisness.PartsMap.InsertMap(17156, iBillcodeID, iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 0, 0, 3, PSS.Core.ApplicationUser.IDuser)
                End If
                iBillcodeID = 0


                'Parts and Accessories ( no rv billcode )
                dtBillcodeByType = Me._objTMIRec.GetPartAccessoryBillcode(Me.lblProdDesc.Tag)
                For Each R1 In dtBillcodeByType.Rows
                    If R1("Billcode_ID").ToString.ToLower.StartsWith("rv_") = False AndAlso R1("Billcode_ID") > 0 AndAlso Generic.IsBillcodeMapped(iModelID, R1("Billcode_ID")) = 0 Then
                        PSS.Data.Buisness.PartsMap.InsertMap(iPSPrice_Temppart, R1("Billcode_ID"), iModelID, Me.lblProdDesc.Tag, 13, iLOB_ID, 0, 0, 3, PSS.Core.ApplicationUser.IDuser)
                    End If
                Next R1

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtBillcodeByType) : R1 = Nothing
            End Try
        End Function

        '**************************************************************************************************
        Private Sub btnReprintSNLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintSNLabel.Click
            Dim strSN As String = ""
            Dim dt As DataTable

            Try
                strSN = InputBox("Enter S/N:", "Reprint S/N Label").Trim
                If strSN.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dt = Generic.GetDeviceInfoInWIP(strSN, PSS.Data.Buisness.TMI.CUSTOMERID, PSS.Data.Buisness.TMI.LOCID, True)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Device does not exist in WIP", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me._objTMIRec.Label_ReceiveBoxLabel(dt.Rows(0)("Device_ID"), 1)
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
        Private Sub txtRecPssSn_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecPssSn.KeyUp
            Dim dt As DataTable

            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtRecPssSn.Text.Trim.Length > 0 Then
                    Me.txtRecPssSn.Tag = Me._objProdRec.IsDeviceUnderPSSWrty(Me.txtRecPssSn.Text.Trim, PSS.Data.Buisness.TMI.LOCID)
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
        Private Sub txtWeight_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWeight.KeyUp
            'Try
            '    If e.KeyCode = Keys.Enter AndAlso Me.txtWeight.Text.Trim.Length > 0 Then
            '        ComputeFreightage()
            '    End If 'Key up and input length > 0
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, "txtWeight_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Me.Enabled = True : Me.txtWeight.SelectAll() : Me.txtWeight.Focus()
            'Finally
            '    Me.Enabled = True : Cursor.Current = Cursors.Default
            'End Try
        End Sub

    End Class
End Namespace