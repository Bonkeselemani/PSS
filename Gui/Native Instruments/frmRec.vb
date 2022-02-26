Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.NativeInstruments
    Public Class frmRec
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _objNIRec As NIRec
        Private _objProdRec As PSS.Data.Production.Receiving
        Private _iTrayID As Integer
        Private _booLoadData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            _strScreenName = strScreenName

            'Add any initialization after the InitializeComponent() call
            _objNIRec = New NIRec()
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
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents btnReceive As System.Windows.Forms.Button
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblRecdQty As System.Windows.Forms.Label
        Friend WithEvents btnReOpenWO As System.Windows.Forms.Button
        Friend WithEvents btnCloseWO As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dgOpenRecWO As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnClearSelection As System.Windows.Forms.Button
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtManufSN As System.Windows.Forms.TextBox
        Friend WithEvents lblManuf As System.Windows.Forms.Label
        Friend WithEvents lblProdDesc As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
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
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents lblOrderType As System.Windows.Forms.Label
        Friend WithEvents lblModRepStatus As System.Windows.Forms.Label
        Friend WithEvents btnSelectWO As System.Windows.Forms.Button
        Friend WithEvents btnReprintSNLabel As System.Windows.Forms.Button
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents cboDevCon As C1.Win.C1List.C1Combo
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cboWipNextLoc As C1.Win.C1List.C1Combo
        Friend WithEvents pnlRecIntoWipLoc As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRec))
            Me.Label17 = New System.Windows.Forms.Label()
            Me.lblOrderType = New System.Windows.Forms.Label()
            Me.btnReceive = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.lblRecdQty = New System.Windows.Forms.Label()
            Me.btnReOpenWO = New System.Windows.Forms.Button()
            Me.btnCloseWO = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnSelectWO = New System.Windows.Forms.Button()
            Me.dgOpenRecWO = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnClearSelection = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtManufSN = New System.Windows.Forms.TextBox()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.lblProdDesc = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
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
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblModRepStatus = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.btnReprintSNLabel = New System.Windows.Forms.Button()
            Me.cboDevCon = New C1.Win.C1List.C1Combo()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.cboWipNextLoc = New C1.Win.C1List.C1Combo()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.pnlRecIntoWipLoc = New System.Windows.Forms.Panel()
            CType(Me.dgOpenRecWO, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbCustInfo.SuspendLayout()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboDevCon, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboWipNextLoc, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlRecIntoWipLoc.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label17
            '
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(0, 296)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(104, 16)
            Me.Label17.TabIndex = 240
            Me.Label17.Text = "Order Type :"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOrderType
            '
            Me.lblOrderType.BackColor = System.Drawing.Color.Black
            Me.lblOrderType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblOrderType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderType.ForeColor = System.Drawing.Color.Green
            Me.lblOrderType.Location = New System.Drawing.Point(112, 292)
            Me.lblOrderType.Name = "lblOrderType"
            Me.lblOrderType.Size = New System.Drawing.Size(280, 24)
            Me.lblOrderType.TabIndex = 239
            Me.lblOrderType.Tag = "0"
            Me.lblOrderType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnReceive
            '
            Me.btnReceive.BackColor = System.Drawing.Color.Green
            Me.btnReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceive.ForeColor = System.Drawing.Color.White
            Me.btnReceive.Location = New System.Drawing.Point(112, 536)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.Size = New System.Drawing.Size(280, 23)
            Me.btnReceive.TabIndex = 5
            Me.btnReceive.Text = "Receive"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(448, 424)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(88, 16)
            Me.Label8.TabIndex = 236
            Me.Label8.Text = "Received Qty :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(448, 352)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 235
            Me.Label7.Text = "Order Qty :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblOrderQty
            '
            Me.lblOrderQty.BackColor = System.Drawing.Color.Black
            Me.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblOrderQty.Font = New System.Drawing.Font("Tahoma", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.Green
            Me.lblOrderQty.Location = New System.Drawing.Point(448, 368)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(88, 40)
            Me.lblOrderQty.TabIndex = 234
            Me.lblOrderQty.Tag = "0"
            Me.lblOrderQty.Text = "0"
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblRecdQty
            '
            Me.lblRecdQty.BackColor = System.Drawing.Color.Black
            Me.lblRecdQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblRecdQty.Font = New System.Drawing.Font("Tahoma", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecdQty.ForeColor = System.Drawing.Color.Green
            Me.lblRecdQty.Location = New System.Drawing.Point(448, 440)
            Me.lblRecdQty.Name = "lblRecdQty"
            Me.lblRecdQty.Size = New System.Drawing.Size(88, 40)
            Me.lblRecdQty.TabIndex = 233
            Me.lblRecdQty.Tag = "0"
            Me.lblRecdQty.Text = "0"
            Me.lblRecdQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReOpenWO
            '
            Me.btnReOpenWO.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReOpenWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReOpenWO.ForeColor = System.Drawing.Color.White
            Me.btnReOpenWO.Location = New System.Drawing.Point(552, 8)
            Me.btnReOpenWO.Name = "btnReOpenWO"
            Me.btnReOpenWO.Size = New System.Drawing.Size(136, 23)
            Me.btnReOpenWO.TabIndex = 11
            Me.btnReOpenWO.Text = "Re-Open Order"
            '
            'btnCloseWO
            '
            Me.btnCloseWO.BackColor = System.Drawing.Color.Navy
            Me.btnCloseWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWO.ForeColor = System.Drawing.Color.White
            Me.btnCloseWO.Location = New System.Drawing.Point(408, 8)
            Me.btnCloseWO.Name = "btnCloseWO"
            Me.btnCloseWO.Size = New System.Drawing.Size(128, 23)
            Me.btnCloseWO.TabIndex = 10
            Me.btnCloseWO.Text = "Close Order"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(0, 360)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(104, 16)
            Me.Label3.TabIndex = 229
            Me.Label3.Text = "Model"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSelectWO
            '
            Me.btnSelectWO.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnSelectWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectWO.Location = New System.Drawing.Point(240, 8)
            Me.btnSelectWO.Name = "btnSelectWO"
            Me.btnSelectWO.Size = New System.Drawing.Size(152, 23)
            Me.btnSelectWO.TabIndex = 9
            Me.btnSelectWO.Text = "Select Order To Receive"
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
            Me.dgOpenRecWO.Location = New System.Drawing.Point(8, 40)
            Me.dgOpenRecWO.Name = "dgOpenRecWO"
            Me.dgOpenRecWO.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgOpenRecWO.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgOpenRecWO.PreviewInfo.ZoomFactor = 75
            Me.dgOpenRecWO.Size = New System.Drawing.Size(848, 240)
            Me.dgOpenRecWO.TabIndex = 11
            Me.dgOpenRecWO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>2" & _
            "36</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 844, 236<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 844, 236</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnClearSelection
            '
            Me.btnClearSelection.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClearSelection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearSelection.ForeColor = System.Drawing.Color.White
            Me.btnClearSelection.Location = New System.Drawing.Point(8, 8)
            Me.btnClearSelection.Name = "btnClearSelection"
            Me.btnClearSelection.Size = New System.Drawing.Size(56, 23)
            Me.btnClearSelection.TabIndex = 7
            Me.btnClearSelection.Text = "Clear"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(24, 504)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(80, 16)
            Me.Label6.TabIndex = 228
            Me.Label6.Text = "Manuf S/N :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtManufSN
            '
            Me.txtManufSN.Location = New System.Drawing.Point(112, 504)
            Me.txtManufSN.MaxLength = 30
            Me.txtManufSN.Name = "txtManufSN"
            Me.txtManufSN.Size = New System.Drawing.Size(280, 20)
            Me.txtManufSN.TabIndex = 4
            Me.txtManufSN.Text = ""
            '
            'lblManuf
            '
            Me.lblManuf.BackColor = System.Drawing.Color.White
            Me.lblManuf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblManuf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManuf.ForeColor = System.Drawing.Color.Black
            Me.lblManuf.Location = New System.Drawing.Point(256, 432)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(136, 20)
            Me.lblManuf.TabIndex = 227
            Me.lblManuf.Tag = "0"
            Me.lblManuf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblProdDesc
            '
            Me.lblProdDesc.BackColor = System.Drawing.Color.White
            Me.lblProdDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblProdDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProdDesc.ForeColor = System.Drawing.Color.Black
            Me.lblProdDesc.Location = New System.Drawing.Point(112, 432)
            Me.lblProdDesc.Name = "lblProdDesc"
            Me.lblProdDesc.Size = New System.Drawing.Size(136, 20)
            Me.lblProdDesc.TabIndex = 226
            Me.lblProdDesc.Tag = "0"
            Me.lblProdDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(16, 432)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(88, 16)
            Me.Label10.TabIndex = 224
            Me.Label10.Text = "Product/Manuf :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'gbCustInfo
            '
            Me.gbCustInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEmail, Me.lblPhone, Me.lblAddress, Me.lblName, Me.Label5, Me.Label4, Me.Label2, Me.Label1})
            Me.gbCustInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCustInfo.ForeColor = System.Drawing.Color.White
            Me.gbCustInfo.Location = New System.Drawing.Point(568, 288)
            Me.gbCustInfo.Name = "gbCustInfo"
            Me.gbCustInfo.Size = New System.Drawing.Size(288, 192)
            Me.gbCustInfo.TabIndex = 223
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
            Me.btnRefreshWO.Location = New System.Drawing.Point(96, 8)
            Me.btnRefreshWO.Name = "btnRefreshWO"
            Me.btnRefreshWO.Size = New System.Drawing.Size(120, 23)
            Me.btnRefreshWO.TabIndex = 8
            Me.btnRefreshWO.Text = "Refresh List"
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.AutoCompletion = True
            Me.cboModels.AutoDropDown = True
            Me.cboModels.AutoSelect = True
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ColumnHeaders = False
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(112, 360)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(280, 21)
            Me.cboModels.TabIndex = 2
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(16, 396)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(88, 16)
            Me.Label11.TabIndex = 242
            Me.Label11.Text = "Model Status :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModRepStatus
            '
            Me.lblModRepStatus.BackColor = System.Drawing.Color.Black
            Me.lblModRepStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblModRepStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModRepStatus.ForeColor = System.Drawing.Color.Green
            Me.lblModRepStatus.Location = New System.Drawing.Point(112, 392)
            Me.lblModRepStatus.Name = "lblModRepStatus"
            Me.lblModRepStatus.Size = New System.Drawing.Size(280, 24)
            Me.lblModRepStatus.TabIndex = 241
            Me.lblModRepStatus.Tag = "0"
            Me.lblModRepStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.CadetBlue
            Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Purple
            Me.Label12.Location = New System.Drawing.Point(448, 304)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(88, 32)
            Me.Label12.TabIndex = 243
            Me.Label12.Tag = "0"
            Me.Label12.Text = "OW"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label13
            '
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.White
            Me.Label13.Location = New System.Drawing.Point(443, 288)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(96, 16)
            Me.Label13.TabIndex = 244
            Me.Label13.Text = "PSS Wrty Status"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'btnReprintSNLabel
            '
            Me.btnReprintSNLabel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReprintSNLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintSNLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintSNLabel.Location = New System.Drawing.Point(448, 496)
            Me.btnReprintSNLabel.Name = "btnReprintSNLabel"
            Me.btnReprintSNLabel.Size = New System.Drawing.Size(120, 23)
            Me.btnReprintSNLabel.TabIndex = 6
            Me.btnReprintSNLabel.Text = "Reprint S/N Label"
            '
            'cboDevCon
            '
            Me.cboDevCon.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDevCon.AutoCompletion = True
            Me.cboDevCon.AutoDropDown = True
            Me.cboDevCon.AutoSelect = True
            Me.cboDevCon.Caption = ""
            Me.cboDevCon.CaptionHeight = 17
            Me.cboDevCon.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDevCon.ColumnCaptionHeight = 17
            Me.cboDevCon.ColumnFooterHeight = 17
            Me.cboDevCon.ColumnHeaders = False
            Me.cboDevCon.ContentHeight = 15
            Me.cboDevCon.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDevCon.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDevCon.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDevCon.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDevCon.EditorHeight = 15
            Me.cboDevCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDevCon.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboDevCon.ItemHeight = 15
            Me.cboDevCon.Location = New System.Drawing.Point(112, 328)
            Me.cboDevCon.MatchEntryTimeout = CType(2000, Long)
            Me.cboDevCon.MaxDropDownItems = CType(10, Short)
            Me.cboDevCon.MaxLength = 32767
            Me.cboDevCon.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDevCon.Name = "cboDevCon"
            Me.cboDevCon.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDevCon.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDevCon.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDevCon.Size = New System.Drawing.Size(280, 21)
            Me.cboDevCon.TabIndex = 1
            Me.cboDevCon.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.White
            Me.Label16.Location = New System.Drawing.Point(0, 328)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(104, 16)
            Me.Label16.TabIndex = 249
            Me.Label16.Text = "Device Condition :"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboWipNextLoc
            '
            Me.cboWipNextLoc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboWipNextLoc.AutoCompletion = True
            Me.cboWipNextLoc.AutoDropDown = True
            Me.cboWipNextLoc.AutoSelect = True
            Me.cboWipNextLoc.Caption = ""
            Me.cboWipNextLoc.CaptionHeight = 17
            Me.cboWipNextLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboWipNextLoc.ColumnCaptionHeight = 17
            Me.cboWipNextLoc.ColumnFooterHeight = 17
            Me.cboWipNextLoc.ColumnHeaders = False
            Me.cboWipNextLoc.ContentHeight = 15
            Me.cboWipNextLoc.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboWipNextLoc.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboWipNextLoc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWipNextLoc.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboWipNextLoc.EditorHeight = 15
            Me.cboWipNextLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWipNextLoc.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboWipNextLoc.ItemHeight = 15
            Me.cboWipNextLoc.Location = New System.Drawing.Point(104, 8)
            Me.cboWipNextLoc.MatchEntryTimeout = CType(2000, Long)
            Me.cboWipNextLoc.MaxDropDownItems = CType(10, Short)
            Me.cboWipNextLoc.MaxLength = 32767
            Me.cboWipNextLoc.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboWipNextLoc.Name = "cboWipNextLoc"
            Me.cboWipNextLoc.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboWipNextLoc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboWipNextLoc.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboWipNextLoc.Size = New System.Drawing.Size(280, 21)
            Me.cboWipNextLoc.TabIndex = 1
            Me.cboWipNextLoc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(16, 8)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(80, 16)
            Me.Label9.TabIndex = 251
            Me.Label9.Text = "WIP Location:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlRecIntoWipLoc
            '
            Me.pnlRecIntoWipLoc.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.cboWipNextLoc})
            Me.pnlRecIntoWipLoc.Location = New System.Drawing.Point(8, 464)
            Me.pnlRecIntoWipLoc.Name = "pnlRecIntoWipLoc"
            Me.pnlRecIntoWipLoc.Size = New System.Drawing.Size(392, 40)
            Me.pnlRecIntoWipLoc.TabIndex = 3
            '
            'frmRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(872, 582)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlRecIntoWipLoc, Me.cboDevCon, Me.Label16, Me.btnReprintSNLabel, Me.Label13, Me.Label12, Me.Label11, Me.lblModRepStatus, Me.cboModels, Me.Label17, Me.lblOrderType, Me.btnReceive, Me.Label8, Me.Label7, Me.lblOrderQty, Me.lblRecdQty, Me.btnReOpenWO, Me.btnCloseWO, Me.Label3, Me.btnSelectWO, Me.dgOpenRecWO, Me.btnClearSelection, Me.Label6, Me.txtManufSN, Me.lblManuf, Me.lblProdDesc, Me.Label10, Me.gbCustInfo, Me.btnRefreshWO})
            Me.Name = "frmRec"
            Me.Text = "frmRec"
            CType(Me.dgOpenRecWO, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbCustInfo.ResumeLayout(False)
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboDevCon, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboWipNextLoc, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlRecIntoWipLoc.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************************
        Private Sub frmRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                LoadOpenRecWorkorder()

                _booLoadData = True
                'Load customers
                dt = Generic.GetModelsWithCustCriteria(NI.CUSTOMERID, True, NI.PRODID, NI.MANUFID)
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
                Me.cboModels.SelectedValue = 0

                'Load device condition
                dt = Generic.ConditionDefinitionForRecvDevice(True)
                Misc.PopulateC1DropDownList(Me.cboDevCon, dt, "DCode_LDesc", "DCode_ID")
                Me.cboDevCon.SelectedValue = 0

                'Load device condition
                Dim strNextStation As String = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, NI.CUSTOMERID, , )
                dt = Generic.BuildDTWithAutoIncrementID(strNextStation.Split("|"), True)
                Misc.PopulateC1DropDownList(Me.cboWipNextLoc, dt, "Desc", "ID")
                Me.cboWipNextLoc.SelectedValue = 1

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                _booLoadData = False
            End Try
        End Sub

        '***************************************************************************************
        Private Sub LoadOpenRecWorkorder()
            Dim dt As DataTable

            Try
                dt = Me._objNIRec.GetOpenRecWorkOrder(NI.LOCID)
                With Me.dgOpenRecWO
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("State").Width = 80
                    .Splits(0).DisplayColumns("WO Qty").Width = 50
                    .Splits(0).DisplayColumns("WO Type").Width = 60
                    .Splits(0).DisplayColumns("ZipCode").Width = 60
                End With

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************        
        Private Sub ClearAllSelection()
            Try
                Me.lblOrderType.Text = ""
                Me.lblModRepStatus.Text = ""
                Me.lblProdDesc.Text = ""
                Me.lblManuf.Text = ""
                Me.txtManufSN.Text = ""

                'Customer info
                Me.lblName.Text = ""
                Me.lblAddress.Text = ""
                Me.lblPhone.Text = ""
                Me.lblEmail.Text = ""

                Me.dgOpenRecWO.Enabled = True
                Me.lblRecdQty.Text = "0"
                Me.lblOrderQty.Text = "0"

                Me.btnReceive.Visible = False
                Me.txtManufSN.Text = ""

                _iTrayID = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearAllSelection", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************       
        Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSelection.Click, btnSelectWO.Click, btnCloseWO.Click, btnReOpenWO.Click, btnRefreshWO.Click
            Try
                If sender.name = "btnClearSelection" Then
                    ClearAllSelection()
                ElseIf sender.name = "btnRefreshWO" Then
                    ClearAllSelection()
                    LoadOpenRecWorkorder()
                ElseIf sender.name = "btnSelectWO" Then
                    ProcessSelectedWO()
                ElseIf sender.name = "btnCloseWO" Then
                    CloseWO()
                ElseIf sender.name = "btnReOpenWO" Then
                    ReOpenWO()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name & " Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ProcessSelectedWO()
            Try
                If Me.dgOpenRecWO.RowCount > 0 AndAlso Me.dgOpenRecWO.Columns.Count > 0 Then
                    If Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row) > 0 Then
                        Dim strAddress As String = ""

                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Name").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblName.Text = Me.dgOpenRecWO.Columns("Name").CellValue(Me.dgOpenRecWO.Row)

                        strAddress = Me.dgOpenRecWO.Columns("Address1").CellValue(Me.dgOpenRecWO.Row) & Environment.NewLine
                        strAddress &= Me.dgOpenRecWO.Columns("City").CellValue(Me.dgOpenRecWO.Row) & ", " & Me.dgOpenRecWO.Columns("State").CellValue(Me.dgOpenRecWO.Row) & " " & Me.dgOpenRecWO.Columns("ZipCode").CellValue(Me.dgOpenRecWO.Row)
                        Me.lblAddress.Text = strAddress
                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Tel").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblPhone.Text = Me.dgOpenRecWO.Columns("Tel").CellValue(Me.dgOpenRecWO.Row)
                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Email").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblEmail.Text = Me.dgOpenRecWO.Columns("Email").CellValue(Me.dgOpenRecWO.Row)
                        Me.dgOpenRecWO.Enabled = False

                        Me._iTrayID = Generic.GetTrayID(Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row))
                        If Me._iTrayID = 0 Then Me._iTrayID = Me._objProdRec.InsertIntoTtray(PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row), Me.dgOpenRecWO.Columns("Work Order").CellValue(Me.dgOpenRecWO.Row))
                        Me.lblRecdQty.Text = Generic.GetRecQty(Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row)) + Me._objNIRec.GetRecQtyWH(NI.LOCID, Me.dgOpenRecWO.Columns("Work Order").CellValue(Me.dgOpenRecWO.Row).ToString)
                        Me.lblOrderQty.Text = Me.dgOpenRecWO.Columns("WO Qty").CellValue(Me.dgOpenRecWO.Row).ToString.Trim
                        Me.lblOrderType.Text = Me.dgOpenRecWO.Columns("WO Type").CellValue(Me.dgOpenRecWO.Row).ToString.Trim

                        Me.Enabled = True : Cursor.Current = Cursors.Default

                        If Me.lblOrderType.Text = "End User" Then
                            Me.cboDevCon.SelectedValue = 3855 : Me.cboDevCon.Enabled = False
                            Me.cboModels.SelectAll() : Me.cboModels.Focus()
                        Else
                            Me.cboDevCon.Enabled = True
                            Me.cboDevCon.SelectedValue = 0
                            Me.cboDevCon.SelectAll() : Me.cboDevCon.Focus()
                        End If
                    End If
                    '**********************************************
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSelectedClaim", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub CloseWO(Optional ByVal booDisplayCompletedMsg As Boolean = True)
            Const iStatusID As Integer = 3
            Dim R1 As DataRow
            Dim i, iRecUnitCnt As Integer
            Dim strStatusDesc As String = ""
            Dim objTMIRec As New PSS.Data.Buisness.TMIRecShip()

            Try
                If Me.dgOpenRecWO.RowCount > 0 AndAlso Me.dgOpenRecWO.Columns.Count > 0 Then
                    If Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row) > 0 Then
                        R1 = Me._objProdRec.GetWorkorderInfo(Me.dgOpenRecWO.Columns("Work Order").CellValue(Me.dgOpenRecWO.Row), , NI.LOCID)
                        i = 0 : iRecUnitCnt = 0

                        If IsNothing(R1) Then
                            MessageBox.Show("This work order # '" & Me.dgOpenRecWO.Columns("Work Order").CellValue(Me.dgOpenRecWO.Row) & "' does not exist in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf R1("WO_Closed") = 1 Then
                            MessageBox.Show("This work order '" & Me.dgOpenRecWO.Columns("Work Order").CellValue(Me.dgOpenRecWO.Row) & "' is already closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf R1("WO_Shipped") = 1 Then
                            MessageBox.Show("This work order '" & Me.dgOpenRecWO.Columns("Work Order").CellValue(Me.dgOpenRecWO.Row) & "' has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iRecUnitCnt = PSS.Data.Buisness.Generic.GetRecQty(R1("WO_ID"))
                            If iRecUnitCnt = 0 Then
                                MessageBox.Show("This work order '" & Me.dgOpenRecWO.Columns("Work Order").CellValue(Me.dgOpenRecWO.Row) & "' is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf iRecUnitCnt <> Convert.ToInt32(R1("WO_Quantity")) AndAlso MessageBox.Show("Discrepancy occur in this order (WO Qty: " & R1("WO_Quantity").ToString & " vs Rec Qty: " & iRecUnitCnt & "). Do you want to continue? ", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                Exit Sub
                            Else
                                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                                i = PSS.Data.Buisness.Generic.CloseWO(R1("WO_ID"))
                                If i > 0 Then
                                    strStatusDesc = objTMIRec.GetTMIStatusDesc(iStatusID)
                                    If strStatusDesc.Trim.Length = 0 Then strStatusDesc = "Unit Received"
                                    objTMIRec.UpdateTMIOrderCurrentStatus(R1("WO_ID"), strStatusDesc, False, iStatusID, "", 0)
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

        '***************************************************************************************
        Private Sub ReOpenWO()
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strWorkOrder As String = ""

            Try
                strWorkOrder = InputBox("Enter Work Order #:").Trim.ToUpper
                If strWorkOrder.Trim.Length > 0 Then
                    Me.ClearAllSelection()

                    R1 = Me._objProdRec.GetWorkorderInfo(strWorkOrder, , NI.LOCID)

                    If IsNothing(R1) Then
                        MessageBox.Show("This Work Order # " & strWorkOrder & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf R1("WO_Closed") = 0 Then
                        MessageBox.Show("This Work Order # " & strWorkOrder & " is open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf (Not IsDBNull(R1("WO_DateShip")) AndAlso R1("WO_DateShip").ToString.Trim.Length > 0) OrElse R1("WO_Shipped") = 1 Then
                        MessageBox.Show("This Work Order # " & strWorkOrder & " has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.ReOpenWO(R1("WO_ID"))
                        If i > 0 Then
                            Me.ClearAllSelection() : Me.LoadOpenRecWorkorder() : Me.Enabled = True
                            MessageBox.Show("Work Order # is now open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
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

        '***************************************************************************************
        Private Sub ProcessSN()
            Const dbRecLaborCharge As Double = 3.5  'Only apply to new product or inactive model
            Dim iCCID, iWOID, i, iPSSWrty, iEOF As Integer
            Dim strWorkStation, strWO, strEDISerialNo As String
            Dim dtManufSN As DataTable
            Dim iR As Integer

            Try
                strWorkStation = "" : strWO = "" : strEDISerialNo = Me.dgOpenRecWO.Columns("EDI S/N").CellValue(Me.dgOpenRecWO.Row).ToString.Trim
                If Me.txtManufSN.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.SelectAll() : Me.cboModels.Focus()
                ElseIf Me.cboModels.DataSource.Table.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("ModelCriteria_ID") = "0" Then
                    MessageBox.Show("Model is not defined as active or inactive. Please contact your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.SelectAll() : Me.cboModels.Focus()
                ElseIf Me._iTrayID = 0 Then
                    MessageBox.Show("Can't define Tray ID. Please re-select RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                ElseIf Convert.ToInt32(Me.lblRecdQty.Text) >= Convert.ToInt32(Me.dgOpenRecWO.Columns("WO Qty").CellValue(Me.dgOpenRecWO.Row)) Then
                    MessageBox.Show("Can't receive more than claim's quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                ElseIf Me.cboDevCon.SelectedValue = 0 Then
                    MessageBox.Show("Please select device's condition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDevCon.SelectAll() : Me.cboDevCon.Focus()
                ElseIf Me.cboModels.DataSource.Table.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("EndOfLife").ToString = "0" AndAlso Me.cboWipNextLoc.SelectedValue = 0 Then
                    MessageBox.Show("Please wip location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboWipNextLoc.SelectAll() : Me.cboWipNextLoc.Focus()
                ElseIf strEDISerialNo.Length > 0 AndAlso strEDISerialNo.ToLower <> Me.txtManufSN.Text.Trim.ToLower AndAlso MessageBox.Show("Serial number does not match (" & strEDISerialNo.ToLower & " vs " & Me.txtManufSN.Text.Trim.ToLower & " ). Are you sure you want to receive?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                Else
                    iEOF = Me.cboModels.DataSource.Table.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("EndOfLife")
                    '**************************************
                    'Check for duplicate
                    '**************************************
                    If iEOF = 0 AndAlso Me.cboDevCon.Text <> "New Product" Then
                        If Generic.IsSNInWIP(NI.CUSTOMERID, Me.txtManufSN.Text.Trim) = True Then
                            MessageBox.Show("S/N is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                        End If
                    Else
                        If Me._objNIRec.IsDeviceOpenInWH(Me.txtManufSN.Text.Trim) = True Then
                            MessageBox.Show("S/N is already existed in warehouse.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus() : Exit Sub
                        End If
                    End If
                    '**************************************

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    iCCID = 0 : iWOID = Me.dgOpenRecWO.Columns("WO_ID").CellValue(Me.dgOpenRecWO.Row)
                    strWO = Me.dgOpenRecWO.Columns("Work Order").CellValue(Me.dgOpenRecWO.Row)

                    If iEOF = 0 AndAlso Me.cboDevCon.Text <> "New Product" Then
                        'Get next workstation
                        strWorkStation = Me.cboWipNextLoc.DataSource.Table.Select("ID = " & Me.cboWipNextLoc.SelectedValue)(0)("Desc").ToString
                        If strWorkStation.Trim.Length = 0 Then Throw New Exception("Wip bucket is missing.")

                        i = Me._objNIRec.ReceiveDeviceIntoWIP(iWOID, Me._iTrayID, Me.cboModels.SelectedValue, Me.txtManufSN.Text.Trim.ToUpper, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, iCCID, strWorkStation, iPSSWrty)
                    Else
                        i = Me._objNIRec.ReceiveDeviceIntoWH(NI.CUSTOMERID, NI.LOCID, strWO, Me.txtManufSN.Text.Trim.ToUpper, Me.cboDevCon.SelectedValue, Me.cboModels.SelectedValue, dbRecLaborCharge, PSS.Core.ApplicationUser.IDuser)
                    End If

                    If i > 0 Then
                        Me.lblRecdQty.Text = Generic.GetRecQty(iWOID) + Me._objNIRec.GetRecQtyWH(NI.LOCID, strWO)

                        'Close workorder
                        If Convert.ToInt32(Me.lblOrderQty.Text) >= Convert.ToInt32(Me.lblRecdQty.Text) AndAlso Me.lblOrderType.Text = "End User" Then
                            'If MessageBox.Show("You have reached the claim quantity. Would you like to close the RMA?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then 
                            CloseWO(False)
                            MessageBox.Show("RMA closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

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

        '***************************************************************************************
        Private Sub btnReprintSNLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintSNLabel.Click
            Dim strSN As String = ""
            Dim dt As DataTable

            Try
                'strSN = InputBox("Enter S/N:", "Reprint S/N Label").Trim
                'If strSN.Trim.Length = 0 Then
                '    Exit Sub
                'Else
                '    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                '    dt = Generic.GetDeviceInfoInWIP(strSN, NI.CUSTOMERID, NI.LOCID, True)
                '    If dt.Rows.Count = 0 Then
                '        MessageBox.Show("Device does not exist in WIP", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Else
                '        Me._objNIRec.PrintReceiveBoxLabel(dt.Rows(0)("Device_SN"), dt.Rows(0)("Model_Desc"), "", , 1)
                '    End If
                'End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintSNLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
            Try
                Me.ProcessSN()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cbos_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModels.SelectedValueChanged, cboDevCon.SelectedValueChanged, cboWipNextLoc.SelectedValueChanged
            Try
                If sender.name = "cboDevCon" AndAlso Me.cboDevCon.SelectedValue > 0 Then
                    cboModels.SelectAll() : cboModels.Focus()
                ElseIf sender.name = "cboModels" AndAlso Me.cboModels.SelectedValue > 0 Then
                    If Me.cboModels.DataSource.Table.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("EndOfLife").ToString = "0" Then
                        Me.lblModRepStatus.Text = "Active"
                        Me.pnlRecIntoWipLoc.Visible = True
                        Me.cboWipNextLoc.SelectAll() : Me.cboWipNextLoc.Focus()
                    Else
                        Me.lblModRepStatus.Text = "EOF"
                        Me.pnlRecIntoWipLoc.Visible = False
                        Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                    End If
                ElseIf sender.name = "cboWipNextLoc" AndAlso Me.cboWipNextLoc.SelectedValue > 0 Then
                    Me.txtManufSN.SelectAll() : Me.txtManufSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name & " SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************

    End Class
End Namespace