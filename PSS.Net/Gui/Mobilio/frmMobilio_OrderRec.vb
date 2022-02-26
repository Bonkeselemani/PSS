Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmMobilio_OrderRec
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _objMRec As MobilioRec

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
        Friend WithEvents dgOpenRecWO As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnClearSelection As System.Windows.Forms.Button
        Friend WithEvents btnRefreshWO As System.Windows.Forms.Button
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents gbCustInfo As System.Windows.Forms.GroupBox
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtActualQty As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblPONo As System.Windows.Forms.Label
        Friend WithEvents btnSelectOrder As System.Windows.Forms.Button
        Friend WithEvents chkDamagedPackage As System.Windows.Forms.CheckBox
        Friend WithEvents lblShipmentID As System.Windows.Forms.Label
        Friend WithEvents lblTrackNo As System.Windows.Forms.Label
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents btnReceiveOrder As System.Windows.Forms.Button
        Friend WithEvents btnReprintDeviceLabel As System.Windows.Forms.Button
        Friend WithEvents dbgOrderDetails As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMobilio_OrderRec))
            Me.dgOpenRecWO = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnClearSelection = New System.Windows.Forms.Button()
            Me.btnRefreshWO = New System.Windows.Forms.Button()
            Me.btnReceiveOrder = New System.Windows.Forms.Button()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtActualQty = New System.Windows.Forms.TextBox()
            Me.gbCustInfo = New System.Windows.Forms.GroupBox()
            Me.lblPONo = New System.Windows.Forms.Label()
            Me.lblShipmentID = New System.Windows.Forms.Label()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.lblTrackNo = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnSelectOrder = New System.Windows.Forms.Button()
            Me.chkDamagedPackage = New System.Windows.Forms.CheckBox()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnReprintDeviceLabel = New System.Windows.Forms.Button()
            Me.dbgOrderDetails = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.dgOpenRecWO, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbCustInfo.SuspendLayout()
            CType(Me.dbgOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dgOpenRecWO
            '
            Me.dgOpenRecWO.AllowUpdate = False
            Me.dgOpenRecWO.AlternatingRows = True
            Me.dgOpenRecWO.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgOpenRecWO.FilterBar = True
            Me.dgOpenRecWO.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgOpenRecWO.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgOpenRecWO.Location = New System.Drawing.Point(8, 40)
            Me.dgOpenRecWO.Name = "dgOpenRecWO"
            Me.dgOpenRecWO.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgOpenRecWO.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgOpenRecWO.PreviewInfo.ZoomFactor = 75
            Me.dgOpenRecWO.Size = New System.Drawing.Size(872, 256)
            Me.dgOpenRecWO.TabIndex = 4
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
            "52</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 868, 252<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 868, 252</ClientArea><Pr" & _
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
            Me.btnClearSelection.TabIndex = 1
            Me.btnClearSelection.Text = "Clear"
            '
            'btnRefreshWO
            '
            Me.btnRefreshWO.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshWO.ForeColor = System.Drawing.Color.White
            Me.btnRefreshWO.Location = New System.Drawing.Point(96, 8)
            Me.btnRefreshWO.Name = "btnRefreshWO"
            Me.btnRefreshWO.Size = New System.Drawing.Size(120, 23)
            Me.btnRefreshWO.TabIndex = 2
            Me.btnRefreshWO.Text = "Refresh List"
            '
            'btnReceiveOrder
            '
            Me.btnReceiveOrder.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnReceiveOrder.BackColor = System.Drawing.Color.Green
            Me.btnReceiveOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceiveOrder.ForeColor = System.Drawing.Color.White
            Me.btnReceiveOrder.Location = New System.Drawing.Point(448, 408)
            Me.btnReceiveOrder.Name = "btnReceiveOrder"
            Me.btnReceiveOrder.Size = New System.Drawing.Size(208, 23)
            Me.btnReceiveOrder.TabIndex = 7
            Me.btnReceiveOrder.Text = "Receive Order"
            '
            'Label15
            '
            Me.Label15.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.White
            Me.Label15.Location = New System.Drawing.Point(576, 312)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(80, 16)
            Me.Label15.TabIndex = 231
            Me.Label15.Text = "Actual Qty :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtActualQty
            '
            Me.txtActualQty.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.txtActualQty.Location = New System.Drawing.Point(576, 328)
            Me.txtActualQty.MaxLength = 30
            Me.txtActualQty.Name = "txtActualQty"
            Me.txtActualQty.Size = New System.Drawing.Size(80, 20)
            Me.txtActualQty.TabIndex = 216
            Me.txtActualQty.Tag = "5"
            Me.txtActualQty.Text = ""
            '
            'gbCustInfo
            '
            Me.gbCustInfo.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.gbCustInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPONo, Me.lblShipmentID, Me.lblAddress, Me.lblTrackNo, Me.Label5, Me.Label4, Me.Label2, Me.Label1})
            Me.gbCustInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCustInfo.ForeColor = System.Drawing.Color.White
            Me.gbCustInfo.Location = New System.Drawing.Point(8, 312)
            Me.gbCustInfo.Name = "gbCustInfo"
            Me.gbCustInfo.Size = New System.Drawing.Size(384, 152)
            Me.gbCustInfo.TabIndex = 219
            Me.gbCustInfo.TabStop = False
            Me.gbCustInfo.Text = "Customer Info"
            '
            'lblPONo
            '
            Me.lblPONo.BackColor = System.Drawing.Color.White
            Me.lblPONo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPONo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPONo.ForeColor = System.Drawing.Color.Black
            Me.lblPONo.Location = New System.Drawing.Point(88, 128)
            Me.lblPONo.Name = "lblPONo"
            Me.lblPONo.Size = New System.Drawing.Size(280, 16)
            Me.lblPONo.TabIndex = 182
            Me.lblPONo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShipmentID
            '
            Me.lblShipmentID.BackColor = System.Drawing.Color.White
            Me.lblShipmentID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblShipmentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipmentID.ForeColor = System.Drawing.Color.Black
            Me.lblShipmentID.Location = New System.Drawing.Point(88, 104)
            Me.lblShipmentID.Name = "lblShipmentID"
            Me.lblShipmentID.Size = New System.Drawing.Size(280, 16)
            Me.lblShipmentID.TabIndex = 181
            Me.lblShipmentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAddress
            '
            Me.lblAddress.BackColor = System.Drawing.Color.White
            Me.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAddress.ForeColor = System.Drawing.Color.Black
            Me.lblAddress.Location = New System.Drawing.Point(88, 48)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(280, 48)
            Me.lblAddress.TabIndex = 180
            '
            'lblTrackNo
            '
            Me.lblTrackNo.BackColor = System.Drawing.Color.White
            Me.lblTrackNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblTrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTrackNo.ForeColor = System.Drawing.Color.Black
            Me.lblTrackNo.Location = New System.Drawing.Point(88, 24)
            Me.lblTrackNo.Name = "lblTrackNo"
            Me.lblTrackNo.Size = New System.Drawing.Size(280, 16)
            Me.lblTrackNo.TabIndex = 179
            Me.lblTrackNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(32, 128)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(56, 16)
            Me.Label5.TabIndex = 178
            Me.Label5.Text = "PO # :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 104)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 16)
            Me.Label4.TabIndex = 177
            Me.Label4.Text = "Shipment ID :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(32, 48)
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
            Me.Label1.Location = New System.Drawing.Point(16, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 175
            Me.Label1.Text = "Tracking # :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSelectOrder
            '
            Me.btnSelectOrder.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Me.btnSelectOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectOrder.Location = New System.Drawing.Point(240, 8)
            Me.btnSelectOrder.Name = "btnSelectOrder"
            Me.btnSelectOrder.Size = New System.Drawing.Size(152, 23)
            Me.btnSelectOrder.TabIndex = 3
            Me.btnSelectOrder.Text = "Select Order To Receive"
            '
            'chkDamagedPackage
            '
            Me.chkDamagedPackage.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.chkDamagedPackage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDamagedPackage.ForeColor = System.Drawing.Color.White
            Me.chkDamagedPackage.Location = New System.Drawing.Point(448, 368)
            Me.chkDamagedPackage.Name = "chkDamagedPackage"
            Me.chkDamagedPackage.Size = New System.Drawing.Size(168, 24)
            Me.chkDamagedPackage.TabIndex = 6
            Me.chkDamagedPackage.Text = "Package is Damaged"
            '
            'lblOrderQty
            '
            Me.lblOrderQty.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.lblOrderQty.BackColor = System.Drawing.Color.White
            Me.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.Black
            Me.lblOrderQty.Location = New System.Drawing.Point(448, 328)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(80, 20)
            Me.lblOrderQty.TabIndex = 244
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label6
            '
            Me.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(448, 312)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(104, 16)
            Me.Label6.TabIndex = 243
            Me.Label6.Text = "Shipment Qty :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnReprintDeviceLabel
            '
            Me.btnReprintDeviceLabel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnReprintDeviceLabel.BackColor = System.Drawing.Color.CadetBlue
            Me.btnReprintDeviceLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintDeviceLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintDeviceLabel.Location = New System.Drawing.Point(448, 448)
            Me.btnReprintDeviceLabel.Name = "btnReprintDeviceLabel"
            Me.btnReprintDeviceLabel.Size = New System.Drawing.Size(208, 23)
            Me.btnReprintDeviceLabel.TabIndex = 8
            Me.btnReprintDeviceLabel.Text = "Reprint Label"
            '
            'dbgOrderDetails
            '
            Me.dbgOrderDetails.AllowUpdate = False
            Me.dbgOrderDetails.AlternatingRows = True
            Me.dbgOrderDetails.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgOrderDetails.FilterBar = True
            Me.dbgOrderDetails.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgOrderDetails.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgOrderDetails.Location = New System.Drawing.Point(680, 360)
            Me.dbgOrderDetails.Name = "dbgOrderDetails"
            Me.dbgOrderDetails.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgOrderDetails.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgOrderDetails.PreviewInfo.ZoomFactor = 75
            Me.dbgOrderDetails.Size = New System.Drawing.Size(200, 112)
            Me.dbgOrderDetails.TabIndex = 245
            Me.dbgOrderDetails.Visible = False
            Me.dbgOrderDetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>1" & _
            "08</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 196, 108<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 196, 108</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'frmMobilio_OrderRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(896, 494)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgOrderDetails, Me.btnReprintDeviceLabel, Me.lblOrderQty, Me.Label6, Me.chkDamagedPackage, Me.btnSelectOrder, Me.btnReceiveOrder, Me.gbCustInfo, Me.dgOpenRecWO, Me.btnClearSelection, Me.btnRefreshWO, Me.txtActualQty, Me.Label15})
            Me.Name = "frmMobilio_OrderRec"
            Me.Text = "frmMobilio_OrderRec"
            CType(Me.dgOpenRecWO, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbCustInfo.ResumeLayout(False)
            CType(Me.dbgOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***********************************************************************************************************************************
        Private Sub frmMobilio_OrderRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                LoadOpenOrder()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub LoadOpenOrder()
            Dim dt As DataTable
            Dim i As Integer

            Try
                dt = Me._objMRec.GetOpenOrderInbound(Me._iMenuCustID, )
                With Me.dgOpenRecWO
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    For i = 0 To .Columns.Count - 1
                        If .Columns(i).Caption = "PO" Then
                            .Splits(0).DisplayColumns(i).Width = 100
                        ElseIf .Columns(i).Caption = "Qty" Then
                            .Splits(0).DisplayColumns(i).Width = 40
                        ElseIf .Columns(i).Caption = "Shipment Trans ID" Then
                            .Splits(0).DisplayColumns(i).Width = 120
                        ElseIf .Columns(i).Caption = "Tracking No" OrElse .Columns(i).Caption = "Ship Carrier" Then
                            .Splits(0).DisplayColumns(i).Width = 100
                        ElseIf .Columns(i).Caption = "Name" Then
                            .Splits(0).DisplayColumns(i).Width = 120
                        ElseIf .Columns(i).Caption = "Address" Then
                            .Splits(0).DisplayColumns(i).Width = 150
                        ElseIf .Columns(i).Caption = "City" Then
                            .Splits(0).DisplayColumns(i).Width = 70
                        ElseIf .Columns(i).Caption = "State" Then
                            .Splits(0).DisplayColumns(i).Width = 60
                        ElseIf .Columns(i).Caption = "Zip" Then
                            .Splits(0).DisplayColumns(i).Width = 50
                        Else
                            .Splits(0).DisplayColumns(i).Visible = False
                        End If
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnRefreshWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshWO.Click
            Try
                btnClearSelection_Click(Nothing, Nothing)
                LoadOpenOrder()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnClearSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSelection.Click
            Try
                Me.dgOpenRecWO.Enabled = True
                Me.lblShipmentID.Text = ""
                Me.lblAddress.Text = ""
                Me.lblPONo.Text = ""
                Me.lblTrackNo.Text = ""
                Me.lblOrderQty.Text = ""
                Me.txtActualQty.Text = ""
                Me.chkDamagedPackage.Checked = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnSelectOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectOrder.Click
            Try
                ProcessPO()
                Me.txtActualQty.SelectAll() : Me.txtActualQty.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnSelectOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''***********************************************************************************************************************************
        'Private Sub dgOpenRecWO_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOpenRecWO.DoubleClick
        '    Try
        '        ProcessPO()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "dgOpenRecWO_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub

        '***********************************************************************************************************************************
        Private Sub ProcessPO()
            Try
                If Me.dgOpenRecWO.RowCount > 0 AndAlso Me.dgOpenRecWO.Columns.Count > 0 Then
                    If Me.dgOpenRecWO.Columns("mb_OrderID").CellValue(Me.dgOpenRecWO.Row) > 0 Then
                        Dim strAddress As String = ""

                        If Not IsDBNull(Me.dgOpenRecWO.Columns("PO").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblPONo.Text = Me.dgOpenRecWO.Columns("PO").CellValue(Me.dgOpenRecWO.Row)

                        strAddress = Me.dgOpenRecWO.Columns("Name").CellValue(Me.dgOpenRecWO.Row) & Environment.NewLine
                        strAddress &= Me.dgOpenRecWO.Columns("Address").CellValue(Me.dgOpenRecWO.Row) & Environment.NewLine
                        strAddress &= Me.dgOpenRecWO.Columns("City").CellValue(Me.dgOpenRecWO.Row) & ", " & Me.dgOpenRecWO.Columns("State").CellValue(Me.dgOpenRecWO.Row) & " " & Me.dgOpenRecWO.Columns("Zip").CellValue(Me.dgOpenRecWO.Row)
                        Me.lblAddress.Text = strAddress
                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Shipment Trans ID").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblShipmentID.Text = Me.dgOpenRecWO.Columns("Shipment Trans ID").CellValue(Me.dgOpenRecWO.Row)
                        If Not IsDBNull(Me.dgOpenRecWO.Columns("Tracking No").CellValue(Me.dgOpenRecWO.Row)) Then Me.lblTrackNo.Text = Me.dgOpenRecWO.Columns("Tracking No").CellValue(Me.dgOpenRecWO.Row)
                        Me.lblOrderQty.Text = Me.dgOpenRecWO.Columns("Qty").CellValue(Me.dgOpenRecWO.Row)
                        Me.txtActualQty.Text = Me.dgOpenRecWO.Columns("Qty").CellValue(Me.dgOpenRecWO.Row)
                        Me.dgOpenRecWO.Enabled = False
                    End If
                    '**********************************************
                    Me.chkDamagedPackage.Focus()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub txtActualQty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtActualQty.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then Me.chkDamagedPackage.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtActualQty_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiveOrder.Click
            Dim iOrderID As Integer, iActualQty As Integer, i As Integer, iPackageDamage As Integer = 0
            Dim dt As DataTable

            Try
                If Me.dgOpenRecWO.RowCount > 0 AndAlso Me.dgOpenRecWO.Columns.Count > 0 Then
                    If CInt(Me.dgOpenRecWO.Columns("mb_OrderID").CellValue(Me.dgOpenRecWO.Row)) = 0 Then
                        MessageBox.Show("System can't define order id. Please re-select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf (Me.txtActualQty.Text.Trim.Length = 0 OrElse CInt(Me.txtActualQty.Text) <= 0) AndAlso MessageBox.Show("Are you sure the box is empty?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        '  MessageBox.Show("Please enter actual quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtActualQty.Select() : Me.txtActualQty.Focus() : Exit Sub
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        iOrderID = Me.dgOpenRecWO.Columns("mb_OrderID").CellValue(Me.dgOpenRecWO.Row)
                        If Me.txtActualQty.Text.Trim.Length > 0 Then iActualQty = CInt(Me.txtActualQty.Text.Trim)
                        If Me.chkDamagedPackage.Checked Then iPackageDamage = 1

                        'Verify order is open
                        dt = Me._objMRec.GetOpenOrderInbound(Me._iMenuCustID, CInt(Me.dgOpenRecWO.Columns("mb_OrderID").CellValue(Me.dgOpenRecWO.Row)))
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Order is no longer available. Please re-fresh your order list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            i = Me._objMRec.ReceiveOrder(iOrderID, CInt(Me.lblOrderQty.Text), iActualQty, iPackageDamage, Core.ApplicationUser.IDuser, _
                                                         Me.dgOpenRecWO.Columns("PO").CellValue(Me.dgOpenRecWO.Row))
                            If i > 0 Then
                                Me.btnClearSelection_Click(Nothing, Nothing)
                                Me.LoadOpenOrder()
                            Else
                                MessageBox.Show("System has failed to close order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub btnReprintDeviceLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintDeviceLabel.Click
            Dim iDeviceID, iOrderID, i As Integer
            Dim strDeviceID As String
            Dim dt As DataTable
            Dim objMobilioRpt As Mobilio_Reports
            Dim strRA As String = ""

            'Print one device, in order to get correct sequence no, need to find all devices in that order which including this device
            Try
                strDeviceID = InputBox("Enter Unit ID (device ID):", "Reprint Receiving Label").Trim
                If strDeviceID.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Not IsNumeric(strDeviceID) Then
                    MessageBox.Show("Invalid Unit ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iDeviceID = CInt(strDeviceID)
                    If iDeviceID > 0 Then
                        objMobilioRpt = New Mobilio_Reports()
                        iOrderID = Me._objMRec.GetWIPDeviceOrderRecID_RANum(iDeviceID, strRA)
                        If iOrderID = 0 Then
                            MessageBox.Show("Device does not exist in WIP", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            dt = Me._objMRec.GetDevicesByInboundOrder(iOrderID)
                            If dt.Rows.Count > 0 Then
                                For i = 0 To dt.Rows.Count - 1
                                    If dt.Rows(i)("mb_DeviceID") = iDeviceID Then
                                        Me._objMRec.PrintOrderRecDeviceLabel(dt.Rows(i)("mb_DeviceID"), i + 1, dt.Rows.Count, strRA)
                                    End If
                                Next i
                            Else
                                MessageBox.Show("Can't find data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        End If
                    Else
                            MessageBox.Show("Invalid Unit ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

                'Me._objMRec.PrintOrderRecDeviceLabel(iDeviceID)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnReprintDeviceLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************


    End Class
End Namespace