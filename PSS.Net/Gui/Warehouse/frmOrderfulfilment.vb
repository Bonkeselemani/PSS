Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Namespace Gui.Warehouse
    Public Class frmOrderfulfilment
        Inherits System.Windows.Forms.Form

        Private _objOFFM As OrderFulfilment
        Private _objSOData As SaleOrderData
        Private _booPopulateData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objOFFM = New OrderFulfilment()
            _objSOData = New SaleOrderData()
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
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents btnCloseBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboOpenOrderNo As C1.Win.C1List.C1Combo
        Friend WithEvents dbgOderInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dbgBoxInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grbShipmentInfo As System.Windows.Forms.GroupBox
        Friend WithEvents cboShipCarrier As C1.Win.C1List.C1Combo
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtTrackingNo As System.Windows.Forms.TextBox
        Friend WithEvents btnReopenBox As System.Windows.Forms.Button
        Friend WithEvents pnlBoxFunction As System.Windows.Forms.Panel
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents pnlCreateBox As System.Windows.Forms.Panel
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblFilledQty As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents txtMaxBoxQty As System.Windows.Forms.TextBox
        Friend WithEvents btnCloseOrder As System.Windows.Forms.Button
        Friend WithEvents btnDeleteEmptyBox As System.Windows.Forms.Button
        Friend WithEvents btnCreateBox As System.Windows.Forms.Button
        Friend WithEvents pnlSNsList As System.Windows.Forms.Panel
        Friend WithEvents btnReprintPackingSlip As System.Windows.Forms.Button
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Private WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtShipPhone As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents grbAccessories As System.Windows.Forms.GroupBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents btnAddAccessories As System.Windows.Forms.Button
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblAccQty As System.Windows.Forms.Label
        Friend WithEvents txtRetFedExTrackingNo As System.Windows.Forms.TextBox
        Friend WithEvents lblFedexRetTracNo As System.Windows.Forms.Label
        Friend WithEvents lblAccItemNo As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
        Friend WithEvents txtCity As System.Windows.Forms.TextBox
        Friend WithEvents txtState As System.Windows.Forms.TextBox
        Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
        Friend WithEvents txtShippingCost As System.Windows.Forms.TextBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblCustPONo As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrderfulfilment))
            Me.lblHeader = New System.Windows.Forms.Label()
            Me.cboOpenOrderNo = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dbgOderInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.pnlSNsList = New System.Windows.Forms.Panel()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.grbAccessories = New System.Windows.Forms.GroupBox()
            Me.lblFedexRetTracNo = New System.Windows.Forms.Label()
            Me.lblAccQty = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.btnAddAccessories = New System.Windows.Forms.Button()
            Me.txtRetFedExTrackingNo = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.lblAccItemNo = New System.Windows.Forms.Label()
            Me.btnCloseBox = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.txtMaxBoxQty = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dbgBoxInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnCloseOrder = New System.Windows.Forms.Button()
            Me.grbShipmentInfo = New System.Windows.Forms.GroupBox()
            Me.txtShippingCost = New System.Windows.Forms.TextBox()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtZipCode = New System.Windows.Forms.TextBox()
            Me.txtState = New System.Windows.Forms.TextBox()
            Me.txtAddress2 = New System.Windows.Forms.TextBox()
            Me.txtShipPhone = New System.Windows.Forms.TextBox()
            Me.txtCity = New System.Windows.Forms.TextBox()
            Me.txtAddress1 = New System.Windows.Forms.TextBox()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblFilledQty = New System.Windows.Forms.Label()
            Me.txtTrackingNo = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboShipCarrier = New C1.Win.C1List.C1Combo()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.btnReopenBox = New System.Windows.Forms.Button()
            Me.pnlBoxFunction = New System.Windows.Forms.Panel()
            Me.btnReprintPackingSlip = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.btnDeleteEmptyBox = New System.Windows.Forms.Button()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.btnCreateBox = New System.Windows.Forms.Button()
            Me.pnlCreateBox = New System.Windows.Forms.Panel()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblCustPONo = New System.Windows.Forms.Label()
            CType(Me.cboOpenOrderNo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgOderInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlSNsList.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.grbAccessories.SuspendLayout()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgBoxInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbShipmentInfo.SuspendLayout()
            CType(Me.cboShipCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBoxFunction.SuspendLayout()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlCreateBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.Black
            Me.lblHeader.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
            Me.lblHeader.Location = New System.Drawing.Point(8, 8)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(272, 32)
            Me.lblHeader.TabIndex = 131
            Me.lblHeader.Text = "Order Fulfilment"
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboOpenOrderNo
            '
            Me.cboOpenOrderNo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenOrderNo.AutoCompletion = True
            Me.cboOpenOrderNo.AutoDropDown = True
            Me.cboOpenOrderNo.AutoSelect = True
            Me.cboOpenOrderNo.Caption = ""
            Me.cboOpenOrderNo.CaptionHeight = 17
            Me.cboOpenOrderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenOrderNo.ColumnCaptionHeight = 17
            Me.cboOpenOrderNo.ColumnFooterHeight = 17
            Me.cboOpenOrderNo.ColumnHeaders = False
            Me.cboOpenOrderNo.ContentHeight = 15
            Me.cboOpenOrderNo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenOrderNo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenOrderNo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrderNo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenOrderNo.EditorHeight = 15
            Me.cboOpenOrderNo.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboOpenOrderNo.ItemHeight = 15
            Me.cboOpenOrderNo.Location = New System.Drawing.Point(80, 135)
            Me.cboOpenOrderNo.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenOrderNo.MaxDropDownItems = CType(10, Short)
            Me.cboOpenOrderNo.MaxLength = 32767
            Me.cboOpenOrderNo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenOrderNo.Name = "cboOpenOrderNo"
            Me.cboOpenOrderNo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenOrderNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenOrderNo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenOrderNo.Size = New System.Drawing.Size(200, 21)
            Me.cboOpenOrderNo.TabIndex = 7
            Me.cboOpenOrderNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(8, 135)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 21)
            Me.Label5.TabIndex = 114
            Me.Label5.Text = "Order # :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgOderInfo
            '
            Me.dbgOderInfo.AllowUpdate = False
            Me.dbgOderInfo.AlternatingRows = True
            Me.dbgOderInfo.FilterBar = True
            Me.dbgOderInfo.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgOderInfo.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgOderInfo.Location = New System.Drawing.Point(1, 208)
            Me.dbgOderInfo.Name = "dbgOderInfo"
            Me.dbgOderInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgOderInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgOderInfo.PreviewInfo.ZoomFactor = 75
            Me.dbgOderInfo.Size = New System.Drawing.Size(465, 152)
            Me.dbgOderInfo.TabIndex = 3
            Me.dbgOderInfo.Visible = False
            Me.dbgOderInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:LightSteelBlue;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bo" & _
            "ld;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColo" & _
            "r:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}" & _
            "Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" A" & _
            "lternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFoot" & _
            "erHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWid" & _
            "th=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><H" & _
            "eight>148</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle pare" & _
            "nt=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBa" & _
            "rStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3" & _
            """ /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=" & _
            """Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle" & _
            " parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Rec" & _
            "ordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""S" & _
            "elected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 46" & _
            "1, 148</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></" & _
            "C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal""" & _
            " /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><" & _
            "Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><S" & _
            "tyle parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style" & _
            " parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Styl" & _
            "e parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><S" & _
            "tyle parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Nam" & _
            "edStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layou" & _
            "t><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 461, 148</ClientA" & _
            "rea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent=" & _
            """"" me=""Style21"" /></Blob>"
            '
            'pnlSNsList
            '
            Me.pnlSNsList.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlSNsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlSNsList.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.Label3, Me.grbAccessories, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lblCount, Me.lblBoxName})
            Me.pnlSNsList.Location = New System.Drawing.Point(466, 208)
            Me.pnlSNsList.Name = "pnlSNsList"
            Me.pnlSNsList.Size = New System.Drawing.Size(422, 344)
            Me.pnlSNsList.TabIndex = 1
            Me.pnlSNsList.Visible = False
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstDevices, Me.txtDevSN, Me.Label10})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(152, 280)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Devices"
            '
            'lstDevices
            '
            Me.lstDevices.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstDevices.Location = New System.Drawing.Point(8, 72)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(136, 199)
            Me.lstDevices.TabIndex = 2
            '
            'txtDevSN
            '
            Me.txtDevSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDevSN.Location = New System.Drawing.Point(8, 48)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(136, 21)
            Me.txtDevSN.TabIndex = 1
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 32)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(136, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "S/N :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Black
            Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Lime
            Me.Label3.Location = New System.Drawing.Point(296, 4)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(48, 33)
            Me.Label3.TabIndex = 102
            Me.Label3.Text = "Qty:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbAccessories
            '
            Me.grbAccessories.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFedexRetTracNo, Me.lblAccQty, Me.Label14, Me.btnAddAccessories, Me.txtRetFedExTrackingNo, Me.Label13, Me.lblAccItemNo})
            Me.grbAccessories.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbAccessories.ForeColor = System.Drawing.Color.White
            Me.grbAccessories.Location = New System.Drawing.Point(160, 48)
            Me.grbAccessories.Name = "grbAccessories"
            Me.grbAccessories.Size = New System.Drawing.Size(248, 160)
            Me.grbAccessories.TabIndex = 2
            Me.grbAccessories.TabStop = False
            Me.grbAccessories.Text = "Accessories"
            Me.grbAccessories.Visible = False
            '
            'lblFedexRetTracNo
            '
            Me.lblFedexRetTracNo.BackColor = System.Drawing.Color.Transparent
            Me.lblFedexRetTracNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFedexRetTracNo.ForeColor = System.Drawing.Color.White
            Me.lblFedexRetTracNo.Location = New System.Drawing.Point(7, 80)
            Me.lblFedexRetTracNo.Name = "lblFedexRetTracNo"
            Me.lblFedexRetTracNo.Size = New System.Drawing.Size(184, 16)
            Me.lblFedexRetTracNo.TabIndex = 131
            Me.lblFedexRetTracNo.Text = " Fedex Returns Tracking #"
            Me.lblFedexRetTracNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAccQty
            '
            Me.lblAccQty.BackColor = System.Drawing.Color.White
            Me.lblAccQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblAccQty.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccQty.ForeColor = System.Drawing.Color.Black
            Me.lblAccQty.Location = New System.Drawing.Point(176, 44)
            Me.lblAccQty.Name = "lblAccQty"
            Me.lblAccQty.Size = New System.Drawing.Size(64, 23)
            Me.lblAccQty.TabIndex = 130
            Me.lblAccQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.White
            Me.Label14.Location = New System.Drawing.Point(5, 24)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(64, 21)
            Me.Label14.TabIndex = 129
            Me.Label14.Text = "Item # "
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnAddAccessories
            '
            Me.btnAddAccessories.BackColor = System.Drawing.Color.Green
            Me.btnAddAccessories.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddAccessories.ForeColor = System.Drawing.Color.White
            Me.btnAddAccessories.Location = New System.Drawing.Point(176, 128)
            Me.btnAddAccessories.Name = "btnAddAccessories"
            Me.btnAddAccessories.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnAddAccessories.Size = New System.Drawing.Size(64, 27)
            Me.btnAddAccessories.TabIndex = 2
            Me.btnAddAccessories.Text = "ADD"
            '
            'txtRetFedExTrackingNo
            '
            Me.txtRetFedExTrackingNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRetFedExTrackingNo.Location = New System.Drawing.Point(8, 96)
            Me.txtRetFedExTrackingNo.Name = "txtRetFedExTrackingNo"
            Me.txtRetFedExTrackingNo.Size = New System.Drawing.Size(232, 23)
            Me.txtRetFedExTrackingNo.TabIndex = 1
            Me.txtRetFedExTrackingNo.Text = ""
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.Transparent
            Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.White
            Me.Label13.Location = New System.Drawing.Point(176, 24)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(40, 21)
            Me.Label13.TabIndex = 127
            Me.Label13.Text = "Qty "
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAccItemNo
            '
            Me.lblAccItemNo.BackColor = System.Drawing.Color.White
            Me.lblAccItemNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblAccItemNo.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccItemNo.ForeColor = System.Drawing.Color.Black
            Me.lblAccItemNo.Location = New System.Drawing.Point(8, 44)
            Me.lblAccItemNo.Name = "lblAccItemNo"
            Me.lblAccItemNo.Size = New System.Drawing.Size(152, 23)
            Me.lblAccItemNo.TabIndex = 100
            Me.lblAccItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCloseBox
            '
            Me.btnCloseBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseBox.Location = New System.Drawing.Point(168, 296)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseBox.Size = New System.Drawing.Size(136, 30)
            Me.btnCloseBox.TabIndex = 3
            Me.btnCloseBox.Text = "CLOSE BOX"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(280, 248)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(136, 30)
            Me.btnRemoveAllSNs.TabIndex = 5
            Me.btnRemoveAllSNs.Text = "REMOVE ALL ITEMS"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(168, 248)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(104, 30)
            Me.btnRemoveSN.TabIndex = 4
            Me.btnRemoveSN.Text = "REMOVE ITEM"
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Black
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.Lime
            Me.lblCount.Location = New System.Drawing.Point(344, 4)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(64, 33)
            Me.lblCount.TabIndex = 97
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Black
            Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxName.Location = New System.Drawing.Point(8, 4)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(288, 33)
            Me.lblBoxName.TabIndex = 98
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtMaxBoxQty
            '
            Me.txtMaxBoxQty.Location = New System.Drawing.Point(113, 7)
            Me.txtMaxBoxQty.MaxLength = 4
            Me.txtMaxBoxQty.Name = "txtMaxBoxQty"
            Me.txtMaxBoxQty.Size = New System.Drawing.Size(39, 20)
            Me.txtMaxBoxQty.TabIndex = 1
            Me.txtMaxBoxQty.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(2, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 16)
            Me.Label1.TabIndex = 101
            Me.Label1.Text = "Max Qty In Box:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboProduct
            '
            Me.cboProduct.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProduct.AutoCompletion = True
            Me.cboProduct.AutoDropDown = True
            Me.cboProduct.AutoSelect = True
            Me.cboProduct.Caption = ""
            Me.cboProduct.CaptionHeight = 17
            Me.cboProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProduct.ColumnCaptionHeight = 17
            Me.cboProduct.ColumnFooterHeight = 17
            Me.cboProduct.ColumnHeaders = False
            Me.cboProduct.ContentHeight = 15
            Me.cboProduct.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProduct.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProduct.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProduct.EditorHeight = 15
            Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(80, 48)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(10, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(200, 21)
            Me.cboProduct.TabIndex = 4
            Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 21)
            Me.Label2.TabIndex = 122
            Me.Label2.Text = "Product :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.AutoCompletion = True
            Me.cboCustomer.AutoDropDown = True
            Me.cboCustomer.AutoSelect = True
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ColumnHeaders = False
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(80, 77)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(200, 21)
            Me.cboCustomer.TabIndex = 5
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(0, 77)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 21)
            Me.Label4.TabIndex = 124
            Me.Label4.Text = "Customer :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgBoxInfo
            '
            Me.dbgBoxInfo.AllowUpdate = False
            Me.dbgBoxInfo.AlternatingRows = True
            Me.dbgBoxInfo.FilterBar = True
            Me.dbgBoxInfo.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBoxInfo.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dbgBoxInfo.Location = New System.Drawing.Point(1, 400)
            Me.dbgBoxInfo.Name = "dbgBoxInfo"
            Me.dbgBoxInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBoxInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBoxInfo.PreviewInfo.ZoomFactor = 75
            Me.dbgBoxInfo.Size = New System.Drawing.Size(465, 152)
            Me.dbgBoxInfo.TabIndex = 2
            Me.dbgBoxInfo.Visible = False
            Me.dbgBoxInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;BackColor:LightSteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:Con" & _
            "trolText;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bo" & _
            "ld;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVer" & _
            "t:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}" & _
            "Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" A" & _
            "lternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFoot" & _
            "erHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWid" & _
            "th=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><H" & _
            "eight>148</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle pare" & _
            "nt=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBa" & _
            "rStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3" & _
            """ /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=" & _
            """Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle" & _
            " parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Rec" & _
            "ordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""S" & _
            "elected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 46" & _
            "1, 148</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></" & _
            "C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal""" & _
            " /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><" & _
            "Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><S" & _
            "tyle parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style" & _
            " parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Styl" & _
            "e parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><S" & _
            "tyle parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Nam" & _
            "edStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layou" & _
            "t><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 461, 148</ClientA" & _
            "rea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent=" & _
            """"" me=""Style21"" /></Blob>"
            '
            'btnCloseOrder
            '
            Me.btnCloseOrder.BackColor = System.Drawing.Color.Green
            Me.btnCloseOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseOrder.ForeColor = System.Drawing.Color.White
            Me.btnCloseOrder.Location = New System.Drawing.Point(336, 152)
            Me.btnCloseOrder.Name = "btnCloseOrder"
            Me.btnCloseOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseOrder.Size = New System.Drawing.Size(168, 21)
            Me.btnCloseOrder.TabIndex = 11
            Me.btnCloseOrder.Text = "CLOSE && SHIP ORDER"
            '
            'grbShipmentInfo
            '
            Me.grbShipmentInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCustPONo, Me.txtShippingCost, Me.Label15, Me.txtZipCode, Me.txtState, Me.txtAddress2, Me.txtShipPhone, Me.txtCity, Me.txtAddress1, Me.txtName, Me.Label12, Me.Label11, Me.lblFilledQty, Me.txtTrackingNo, Me.Label7, Me.cboShipCarrier, Me.Label6, Me.btnCloseOrder, Me.Label9, Me.lblOrderQty})
            Me.grbShipmentInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbShipmentInfo.ForeColor = System.Drawing.Color.White
            Me.grbShipmentInfo.Location = New System.Drawing.Point(288, 0)
            Me.grbShipmentInfo.Name = "grbShipmentInfo"
            Me.grbShipmentInfo.Size = New System.Drawing.Size(600, 208)
            Me.grbShipmentInfo.TabIndex = 126
            Me.grbShipmentInfo.TabStop = False
            Me.grbShipmentInfo.Text = "Shipment Information"
            Me.grbShipmentInfo.Visible = False
            '
            'txtShippingCost
            '
            Me.txtShippingCost.Location = New System.Drawing.Point(336, 120)
            Me.txtShippingCost.Name = "txtShippingCost"
            Me.txtShippingCost.Size = New System.Drawing.Size(168, 21)
            Me.txtShippingCost.TabIndex = 10
            Me.txtShippingCost.Text = ""
            '
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.White
            Me.Label15.Location = New System.Drawing.Point(336, 104)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(136, 21)
            Me.Label15.TabIndex = 137
            Me.Label15.Text = "Shipping Cost :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtZipCode
            '
            Me.txtZipCode.BackColor = System.Drawing.SystemColors.Info
            Me.txtZipCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtZipCode.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtZipCode.Location = New System.Drawing.Point(8, 152)
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.Size = New System.Drawing.Size(176, 23)
            Me.txtZipCode.TabIndex = 6
            Me.txtZipCode.Text = ""
            '
            'txtState
            '
            Me.txtState.BackColor = System.Drawing.SystemColors.Info
            Me.txtState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtState.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtState.Location = New System.Drawing.Point(184, 128)
            Me.txtState.Name = "txtState"
            Me.txtState.Size = New System.Drawing.Size(144, 23)
            Me.txtState.TabIndex = 5
            Me.txtState.Text = ""
            '
            'txtAddress2
            '
            Me.txtAddress2.BackColor = System.Drawing.SystemColors.Info
            Me.txtAddress2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress2.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtAddress2.Location = New System.Drawing.Point(8, 104)
            Me.txtAddress2.Name = "txtAddress2"
            Me.txtAddress2.Size = New System.Drawing.Size(320, 23)
            Me.txtAddress2.TabIndex = 3
            Me.txtAddress2.Text = ""
            '
            'txtShipPhone
            '
            Me.txtShipPhone.BackColor = System.Drawing.SystemColors.Info
            Me.txtShipPhone.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipPhone.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtShipPhone.Location = New System.Drawing.Point(184, 152)
            Me.txtShipPhone.Name = "txtShipPhone"
            Me.txtShipPhone.Size = New System.Drawing.Size(144, 23)
            Me.txtShipPhone.TabIndex = 7
            Me.txtShipPhone.Text = ""
            Me.txtShipPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtCity
            '
            Me.txtCity.BackColor = System.Drawing.SystemColors.Info
            Me.txtCity.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCity.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtCity.Location = New System.Drawing.Point(8, 128)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.Size = New System.Drawing.Size(176, 23)
            Me.txtCity.TabIndex = 4
            Me.txtCity.Text = ""
            '
            'txtAddress1
            '
            Me.txtAddress1.BackColor = System.Drawing.SystemColors.Info
            Me.txtAddress1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress1.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtAddress1.Location = New System.Drawing.Point(8, 80)
            Me.txtAddress1.Name = "txtAddress1"
            Me.txtAddress1.Size = New System.Drawing.Size(320, 23)
            Me.txtAddress1.TabIndex = 2
            Me.txtAddress1.Text = ""
            '
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.SystemColors.Info
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtName.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtName.Location = New System.Drawing.Point(8, 32)
            Me.txtName.Multiline = True
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(320, 42)
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(1, 16)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(72, 16)
            Me.Label12.TabIndex = 135
            Me.Label12.Text = "Address :"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(512, 96)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(80, 16)
            Me.Label11.TabIndex = 133
            Me.Label11.Text = "Filled Qty"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblFilledQty
            '
            Me.lblFilledQty.BackColor = System.Drawing.Color.Black
            Me.lblFilledQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblFilledQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFilledQty.ForeColor = System.Drawing.Color.Lime
            Me.lblFilledQty.Location = New System.Drawing.Point(520, 112)
            Me.lblFilledQty.Name = "lblFilledQty"
            Me.lblFilledQty.Size = New System.Drawing.Size(72, 43)
            Me.lblFilledQty.TabIndex = 134
            Me.lblFilledQty.Text = "0"
            Me.lblFilledQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtTrackingNo
            '
            Me.txtTrackingNo.Location = New System.Drawing.Point(336, 80)
            Me.txtTrackingNo.Name = "txtTrackingNo"
            Me.txtTrackingNo.Size = New System.Drawing.Size(168, 21)
            Me.txtTrackingNo.TabIndex = 9
            Me.txtTrackingNo.Text = ""
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(336, 64)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 125
            Me.Label7.Text = "Tracking # :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboShipCarrier
            '
            Me.cboShipCarrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboShipCarrier.AutoCompletion = True
            Me.cboShipCarrier.AutoDropDown = True
            Me.cboShipCarrier.AutoSelect = True
            Me.cboShipCarrier.Caption = ""
            Me.cboShipCarrier.CaptionHeight = 17
            Me.cboShipCarrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboShipCarrier.ColumnCaptionHeight = 17
            Me.cboShipCarrier.ColumnFooterHeight = 17
            Me.cboShipCarrier.ColumnHeaders = False
            Me.cboShipCarrier.ContentHeight = 15
            Me.cboShipCarrier.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboShipCarrier.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboShipCarrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboShipCarrier.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboShipCarrier.EditorHeight = 15
            Me.cboShipCarrier.Enabled = False
            Me.cboShipCarrier.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboShipCarrier.ItemHeight = 15
            Me.cboShipCarrier.Location = New System.Drawing.Point(336, 32)
            Me.cboShipCarrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboShipCarrier.MaxDropDownItems = CType(10, Short)
            Me.cboShipCarrier.MaxLength = 32767
            Me.cboShipCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboShipCarrier.Name = "cboShipCarrier"
            Me.cboShipCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboShipCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboShipCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboShipCarrier.Size = New System.Drawing.Size(168, 21)
            Me.cboShipCarrier.TabIndex = 8
            Me.cboShipCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(336, 16)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(104, 21)
            Me.Label6.TabIndex = 124
            Me.Label6.Text = "Ship Carrier :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(512, 16)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(80, 16)
            Me.Label9.TabIndex = 131
            Me.Label9.Text = "Order Qty"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblOrderQty
            '
            Me.lblOrderQty.BackColor = System.Drawing.Color.Black
            Me.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.Lime
            Me.lblOrderQty.Location = New System.Drawing.Point(520, 32)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(72, 43)
            Me.lblOrderQty.TabIndex = 132
            Me.lblOrderQty.Text = "0"
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReopenBox
            '
            Me.btnReopenBox.BackColor = System.Drawing.Color.SeaGreen
            Me.btnReopenBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenBox.ForeColor = System.Drawing.Color.White
            Me.btnReopenBox.Location = New System.Drawing.Point(272, 7)
            Me.btnReopenBox.Name = "btnReopenBox"
            Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReopenBox.Size = New System.Drawing.Size(88, 20)
            Me.btnReopenBox.TabIndex = 127
            Me.btnReopenBox.Text = "Re-Open Box"
            '
            'pnlBoxFunction
            '
            Me.pnlBoxFunction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlBoxFunction.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReprintPackingSlip, Me.btnReprintBoxLabel})
            Me.pnlBoxFunction.Location = New System.Drawing.Point(1, 160)
            Me.pnlBoxFunction.Name = "pnlBoxFunction"
            Me.pnlBoxFunction.Size = New System.Drawing.Size(287, 48)
            Me.pnlBoxFunction.TabIndex = 128
            '
            'btnReprintPackingSlip
            '
            Me.btnReprintPackingSlip.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnReprintPackingSlip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintPackingSlip.ForeColor = System.Drawing.Color.White
            Me.btnReprintPackingSlip.Location = New System.Drawing.Point(144, 8)
            Me.btnReprintPackingSlip.Name = "btnReprintPackingSlip"
            Me.btnReprintPackingSlip.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReprintPackingSlip.Size = New System.Drawing.Size(136, 30)
            Me.btnReprintPackingSlip.TabIndex = 130
            Me.btnReprintPackingSlip.Text = "Reprint Packing Slip"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(8, 8)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(120, 30)
            Me.btnReprintBoxLabel.TabIndex = 128
            Me.btnReprintBoxLabel.Text = "Reprint Box Label"
            '
            'btnDeleteEmptyBox
            '
            Me.btnDeleteEmptyBox.BackColor = System.Drawing.Color.Red
            Me.btnDeleteEmptyBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeleteEmptyBox.ForeColor = System.Drawing.Color.White
            Me.btnDeleteEmptyBox.Location = New System.Drawing.Point(376, 7)
            Me.btnDeleteEmptyBox.Name = "btnDeleteEmptyBox"
            Me.btnDeleteEmptyBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeleteEmptyBox.Size = New System.Drawing.Size(80, 20)
            Me.btnDeleteEmptyBox.TabIndex = 129
            Me.btnDeleteEmptyBox.Text = "Delete Box"
            '
            'cboLocation
            '
            Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocation.AutoCompletion = True
            Me.cboLocation.AutoDropDown = True
            Me.cboLocation.AutoSelect = True
            Me.cboLocation.Caption = ""
            Me.cboLocation.CaptionHeight = 17
            Me.cboLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocation.ColumnCaptionHeight = 17
            Me.cboLocation.ColumnFooterHeight = 17
            Me.cboLocation.ColumnHeaders = False
            Me.cboLocation.ContentHeight = 15
            Me.cboLocation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocation.EditorHeight = 15
            Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboLocation.ItemHeight = 15
            Me.cboLocation.Location = New System.Drawing.Point(80, 106)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(10, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(200, 21)
            Me.cboLocation.TabIndex = 6
            Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'btnCreateBox
            '
            Me.btnCreateBox.BackColor = System.Drawing.Color.Green
            Me.btnCreateBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateBox.ForeColor = System.Drawing.Color.White
            Me.btnCreateBox.Location = New System.Drawing.Point(170, 7)
            Me.btnCreateBox.Name = "btnCreateBox"
            Me.btnCreateBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreateBox.Size = New System.Drawing.Size(86, 20)
            Me.btnCreateBox.TabIndex = 102
            Me.btnCreateBox.Text = "Create Box"
            '
            'pnlCreateBox
            '
            Me.pnlCreateBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlCreateBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMaxBoxQty, Me.Label1, Me.btnCreateBox, Me.btnReopenBox, Me.btnDeleteEmptyBox})
            Me.pnlCreateBox.Location = New System.Drawing.Point(1, 360)
            Me.pnlCreateBox.Name = "pnlCreateBox"
            Me.pnlCreateBox.Size = New System.Drawing.Size(465, 40)
            Me.pnlCreateBox.TabIndex = 8
            Me.pnlCreateBox.Visible = False
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(0, 106)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(80, 21)
            Me.Label8.TabIndex = 130
            Me.Label8.Text = "Location :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCustPONo
            '
            Me.lblCustPONo.BackColor = System.Drawing.Color.Transparent
            Me.lblCustPONo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustPONo.ForeColor = System.Drawing.Color.Yellow
            Me.lblCustPONo.Location = New System.Drawing.Point(8, 184)
            Me.lblCustPONo.Name = "lblCustPONo"
            Me.lblCustPONo.Size = New System.Drawing.Size(320, 16)
            Me.lblCustPONo.TabIndex = 139
            Me.lblCustPONo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmOrderfulfilment
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(896, 565)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlCreateBox, Me.cboLocation, Me.Label8, Me.pnlBoxFunction, Me.grbShipmentInfo, Me.dbgBoxInfo, Me.cboCustomer, Me.Label4, Me.cboProduct, Me.Label2, Me.pnlSNsList, Me.dbgOderInfo, Me.cboOpenOrderNo, Me.Label5, Me.lblHeader})
            Me.Name = "frmOrderfulfilment"
            Me.Text = "frmOrderfulfilment"
            CType(Me.cboOpenOrderNo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgOderInfo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlSNsList.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.grbAccessories.ResumeLayout(False)
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgBoxInfo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbShipmentInfo.ResumeLayout(False)
            CType(Me.cboShipCarrier, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBoxFunction.ResumeLayout(False)
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlCreateBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************
        Private Sub frmSaleOrderfulfilment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim objDockShip As DockShipping

            Try
                'Populate Products
                PopulateProductsList()

                'populate ship carrier
                dt = Nothing
                objDockShip = New DockShipping()
                dt = objDockShip.GetShipCarriers(True)
                Misc.PopulateC1DropDownList(Me.cboShipCarrier, dt, "SC_Desc", "SC_ID")

                PSS.Core.Highlight.SetHighLight(Me)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDockShipping_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _booPopulateData = False
                objDockShip = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub cbo_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProduct.RowChange, cboCustomer.RowChange, cboLocation.RowChange, cboOpenOrderNo.RowChange
            Dim dt As DataTable

            Try
                If _booPopulateData = False Then
                    Me.dbgOderInfo.DataSource = Nothing
                    Me.dbgBoxInfo.DataSource = Nothing
                    Me.pnlSNsList.Visible = False
                    Me.lstDevices.DataSource = Nothing
                    Me.txtDevSN.Text = ""
                    Me.lblOrderQty.Text = "0" : Me.lblFilledQty.Text = "0"
                    Me.txtTrackingNo.Text = "" : Me.cboShipCarrier.SelectedValue = 0
                    Me.txtName.Text = "" : Me.txtAddress1.Text = "" : Me.txtAddress2.Text = "" : Me.txtCity.Text = "" : Me.txtState.Text = "" : Me.txtZipCode.Text = "" : Me.txtShipPhone.Text = ""
                    Me.grbShipmentInfo.Visible = False
                    Me.pnlCreateBox.Visible = False

                    If sender.name = "cboProduct" Then
                        Me.cboCustomer.DataSource = Nothing : Me.cboCustomer.Text = ""
                        Me.cboLocation.DataSource = Nothing : Me.cboLocation.Text = ""
                        Me.cboOpenOrderNo.DataSource = Nothing : Me.cboOpenOrderNo.Text = ""

                        If Me.cboProduct.SelectedValue > 0 Then
                            'Populate Customer
                            Me.PopulateCustomerList()
                        End If
                    ElseIf sender.name = "cboCustomer" Then
                        Me.cboLocation.DataSource = Nothing : Me.cboLocation.Text = ""
                        Me.cboOpenOrderNo.DataSource = Nothing : Me.cboOpenOrderNo.Text = ""
                        If Me.cboCustomer.SelectedValue > 0 Then
                            Me.PopulateLocationList()
                        End If
                    ElseIf sender.name = "cboLocation" Then
                        Me.cboOpenOrderNo.DataSource = Nothing : Me.cboOpenOrderNo.Text = ""
                        If Me.cboLocation.SelectedValue > 0 Then
                            'Populate Open Orders
                            Me.PopulateOpenOrdersList()
                        End If
                    ElseIf sender.name = "cboOpenOrderNo" Then
                        Me.lblFilledQty.Text = "0" : Me.lblOrderQty.Text = "0"
                        Me.txtShippingCost.Text = "" : Me.txtTrackingNo.Text = "" : Me.cboShipCarrier.SelectedValue = 0
                        Me.txtName.Text = "" : Me.txtAddress1.Text = "" : Me.txtAddress2.Text = "" : Me.txtCity.Text = "" : Me.txtState.Text = "" : Me.txtZipCode.Text = "" : Me.txtShipPhone.Text = "" : Me.lblCustPONo.Text = ""
                        Me.dbgBoxInfo.DataSource = Nothing : Me.dbgBoxInfo.Visible = False
                        Me.txtMaxBoxQty.Text = ""
                        Me.dbgOderInfo.DataSource = Nothing : Me.dbgOderInfo.Visible = False
                        Me.pnlCreateBox.Visible = False
                        Me.txtDevSN.Text = ""
                        Me.lblCount.Text = "0"
                        Me.lblBoxName.Text = ""
                        Me.pnlSNsList.Visible = False

                        If Me.cboOpenOrderNo.SelectedValue > 0 Then
                            Me.PopulateOrderInfo()
                            Me.PopulateBoxesInfo()
                            Me.grbShipmentInfo.Visible = True
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RowChange_Event", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateProductsList()
            Dim dt As DataTable

            Try
                'Populate product type
                _booPopulateData = True
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                Me.cboProduct.SelectedValue = 0

            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateCustomerList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboCustomer.SelectedValue = dt.Rows(0)("Cust_ID")
                    Me.PopulateLocationList()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateLocationList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Generic.GetLocations(True, Me.cboCustomer.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboLocation, dt, "Loc_Name", "Loc_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboLocation.SelectedValue = dt.Rows(0)("Loc_ID")

                    'Populate Open Orders
                    Me.PopulateOpenOrdersList()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateOpenOrdersList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                If Me.cboLocation.SelectedValue > 0 Then
                    Me.cboOpenOrderNo.DataSource = Nothing : Me.cboOpenOrderNo.Text = ""
                    dt = Me._objOFFM.GetOpenOrders(True, Me.cboLocation.SelectedValue)
                    Misc.PopulateC1DropDownList(Me.cboOpenOrderNo, dt, "WO_CustWO", "WO_ID")
                    Me.cboOpenOrderNo.SelectedValue = 0
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub cboOpenOrderNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOpenOrderNo.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.cboOpenOrderNo.SelectedValue > 0 Then
                    Me.dbgOderInfo.DataSource = Nothing
                    Me.dbgBoxInfo.DataSource = Nothing
                    Me.pnlSNsList.Visible = False
                    Me.lstDevices.DataSource = Nothing
                    Me.txtDevSN.Text = ""
                    Me.lblOrderQty.Text = "0" : Me.lblFilledQty.Text = "0"
                    Me.txtTrackingNo.Text = "" : Me.cboShipCarrier.SelectedValue = 0
                    Me.txtName.Text = "" : Me.txtAddress1.Text = "" : Me.txtAddress2.Text = "" : Me.txtCity.Text = "" : Me.txtState.Text = "" : Me.txtZipCode.Text = "" : Me.txtShipPhone.Text = "" : Me.lblCustPONo.Text = ""
                    Me.grbShipmentInfo.Visible = False
                    Me.pnlCreateBox.Visible = False

                    Me.dbgOderInfo.DataSource = Nothing
                    Me.PopulateOrderInfo()
                    Me.PopulateBoxesInfo()
                    Me.grbShipmentInfo.Visible = True

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenOrderNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateOrderInfo()
            Dim dt, dtCarrierCode As DataTable
            Dim i As Integer = 0

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                Me._booPopulateData = True

                'Populate Order information
                dt = Me._objSOData.GetOrderDetail(Me.cboOpenOrderNo.DataSource.Table.select("WO_ID = " & Me.cboOpenOrderNo.SelectedValue)(0)("WO_CustWO"))
                With Me.dbgOderInfo
                    .DataSource = dt.DefaultView
                    .Visible = True

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Next i

                    .Splits(0).DisplayColumns("SOHeaderID").Visible = False
                    .Splits(0).DisplayColumns("Model_ID").Visible = False
                    .Splits(0).DisplayColumns("Accessory?").Visible = False
                    .Splits(0).DisplayColumns("Name").Visible = False
                    .Splits(0).DisplayColumns("Address1").Visible = False
                    .Splits(0).DisplayColumns("Address2").Visible = False
                    .Splits(0).DisplayColumns("City").Visible = False
                    .Splits(0).DisplayColumns("State").Visible = False
                    .Splits(0).DisplayColumns("ZipCode").Visible = False
                    .Splits(0).DisplayColumns("ShipPhone").Visible = False
                    .Splits(0).DisplayColumns("Qty").Width = 50
                    .Splits(0).DisplayColumns("Filled Qty").Width = 60
                    .Splits(0).DisplayColumns("Item#").Width = 100
                    .Splits(0).DisplayColumns("Item Desc").Width = 150
                    .Splits(0).DisplayColumns("ShipVia").Width = 55

                    If dt.Rows.Count > 0 Then
                        Me.pnlCreateBox.Visible = True
                        Me.lblOrderQty.Text = dt.Compute("SUM(Qty)", "")

                        'Select ship via
                        If Not IsDBNull(Me.cboShipCarrier.DataSource) Then
                            dtCarrierCode = Me.cboShipCarrier.DataSource.Table
                            If dtCarrierCode.Select("SC_ID > 0 AND CustUsedCodes like '%" & dt.Rows(0)("ShipVia") & "%'").Length > 0 Then
                                Me.cboShipCarrier.SelectedValue = dtCarrierCode.Select("SC_ID > 0 AND CustUsedCodes like '%" & dt.Rows(0)("ShipVia") & "%'")(0)("SC_ID")
                            Else
                                Me.cboShipCarrier.SelectedValue = 0
                            End If
                        End If

                        'Populate Ship To Address
                        Me.txtName.Text = dt.Rows(0)("Name")
                        Me.txtAddress1.Text = dt.Rows(0)("Address1")
                        If Not IsDBNull(dt.Rows(0)("Address2")) Then Me.txtAddress2.Text = dt.Rows(0)("Address2")
                        Me.txtCity.Text = dt.Rows(0)("City")
                        Me.txtState.Text = dt.Rows(0)("State")
                        Me.txtZipCode.Text = dt.Rows(0)("ZipCode")
                        Me.txtShipPhone.Text = dt.Rows(0)("ShipPhone")
                        Me.lblCustPONo.Text = "Customer PO#: " & Me.cboOpenOrderNo.DataSource.Table.select("WO_ID = " & Me.cboOpenOrderNo.SelectedValue)(0)("WO_Memo").ToString
                    Else
                        Me.pnlCreateBox.Visible = False
                        Me.lblOrderQty.Text = dt.Rows.Count
                        If IsDBNull(dt.Compute("sum([Filled Qty])", "")) Then Me.lblFilledQty.Text = "0" Else Me.lblFilledQty.Text = dt.Compute("sum([Filled Qty])", "")
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._booPopulateData = False
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub dbgOderInfo_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgOderInfo.RowColChange
            Try
                If Me._booPopulateData = True Then
                    Exit Sub
                ElseIf IsDBNull(Me.dbgOderInfo.Columns("Accessory?").Value) Or IsDBNull(Me.dbgOderInfo.Columns("Model_ID").Value) Then
                    MessageBox.Show("Model ID is missing for this item # ( " & Me.dbgOderInfo.Columns("Item#").Value & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                ElseIf Me.dbgOderInfo.Columns("Accessory?").Value > 0 Then
                    Me.txtRetFedExTrackingNo.Text = ""
                    Me.lblAccItemNo.Text = ""
                    Me.lblAccQty.Text = ""
                    If Me.dbgOderInfo.Columns("Model_ID").Value = 0 Then
                        MessageBox.Show("Model ID is missing for this item # ( " & Me.dbgOderInfo.Columns("Item#").Value & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    ElseIf Me.dbgOderInfo.Columns("Model_ID").Value = 1344 Then
                        Me.lblFedexRetTracNo.Visible = True
                        Me.txtRetFedExTrackingNo.Visible = True
                    Else
                        Me.lblFedexRetTracNo.Visible = False
                        Me.txtRetFedExTrackingNo.Visible = False
                    End If

                    Me.grbAccessories.Visible = True
                    Me.lblAccItemNo.Text = Me.dbgOderInfo.Columns("Item#").Value
                    Me.lblAccQty.Text = Me.dbgOderInfo.Columns("Qty").Value
                    If Me.dbgOderInfo.Columns("Qty").Value <> Me.dbgOderInfo.Columns("Filled Qty").Value Then Me.btnAddAccessories.Visible = True Else Me.btnAddAccessories.Visible = False
                Else
                    Me.grbAccessories.Visible = False
                    Me.lblAccItemNo.Text = ""
                    Me.lblAccQty.Text = ""
                    Me.txtRetFedExTrackingNo.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgOderInfo_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateBoxesInfo(Optional ByVal iPalletID As Integer = 0)
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                Me._booPopulateData = True

                'Populate Boxes
                dt = Me._objOFFM.GetBoxesDispDataInOrder(Me.cboLocation.SelectedValue, Me.cboOpenOrderNo.SelectedValue)
                With Me.dbgBoxInfo
                    .DataSource = dt.DefaultView
                    ' If dt.Rows.Count > 0 Then 
                    .Visible = True
                    .Splits(0).DisplayColumns("Pallett_ID").Visible = False
                    .Splits(0).DisplayColumns("Cust_ID").Visible = False
                    .Splits(0).DisplayColumns("Loc_ID").Visible = False
                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("Pallet_ShipType").Visible = False

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Next i

                    .Splits(0).DisplayColumns("Box").Width = 140
                    .Splits(0).DisplayColumns("Open?").Width = 50
                    .Splits(0).DisplayColumns("Qty").Width = 50
                    .Splits(0).DisplayColumns("Max Qty").Width = 60

                    ' If dt.Rows.Count > 0 Then Me.lblFilledQty.Text = dt.Compute("SUM(Qty)", "") Else Me.lblFilledQty.Text = "0"

                    If iPalletID > 0 Then
                        .MoveFirst()
                        For i = 0 To .RowCount - 1
                            If .Columns("Pallett_ID").Value <> iPalletID Then .MoveNext() Else Exit For
                        Next i

                        Me.RefreshSNList()
                    End If

                    '*******************************************
                    'Update filled quantity
                    '*******************************************
                    dt = Nothing : R1 = Nothing
                    dt = Me._objOFFM.GetDevicesInOrder(Me.cboLocation.SelectedValue, Me.cboOpenOrderNo.SelectedValue)
                    If dt.Rows.Count > 0 Then
                        For Each R1 In Me.dbgOderInfo.DataSource.Table.Rows
                            If Not IsDBNull(dt.Compute("Sum(Qty)", "Model_ID = " & R1("Model_ID"))) Then
                                R1.BeginEdit() : R1("Filled Qty") = dt.Compute("Sum(Qty)", "Model_ID = " & R1("Model_ID")) : R1.EndEdit()
                            End If
                        Next R1
                        Me.dbgOderInfo.DataSource.Table.AcceptChanges()

                        If IsDBNull(Me.dbgOderInfo.DataSource.Table.compute("Sum([Filled Qty])", "")) Then Me.lblFilledQty.Text = "0" Else Me.lblFilledQty.Text = Me.dbgOderInfo.DataSource.Table.compute("Sum([Filled Qty])", "")
                    End If
                    '*******************************************
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._booPopulateData = False
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Sub

        '**************************************************************************
        Private Sub RefreshSNList()
            Dim dt1 As DataTable
            Dim iPallet_ID As Integer = 0
            Dim strPalletName As String = ""
            Dim R1 As DataRow

            Try
                If _booPopulateData = True Then Exit Sub

                '************************
                'Validations
                iPallet_ID = CInt(Me.dbgBoxInfo.Columns("Pallett_ID").Value.ToString)
                strPalletName = Me.dbgBoxInfo.Columns("Box").Value.ToString.Trim

                If iPallet_ID = 0 Then
                    Throw New Exception("Box is not selected.")
                ElseIf strPalletName.Trim = "" Then
                    Throw New Exception("Box is not selected.")
                End If

                '*******************************************
                'Get all devices add put them in them in list box
                '*******************************************
                dt1 = Me._objOFFM.GetAllSNsForPallet(iPallet_ID)
                Me.lstDevices.DataSource = dt1.DefaultView
                Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
                Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString
                Me.lblBoxName.Text = strPalletName

                Me.pnlSNsList.Visible = True
                Me.lblCount.Text = dt1.Rows.Count

                '*******************************************
                'Update filled quantity
                '*******************************************
                dt1 = Nothing : R1 = Nothing
                dt1 = Me._objOFFM.GetDevicesInOrder(Me.cboLocation.SelectedValue, Me.cboOpenOrderNo.SelectedValue)
                If dt1.Rows.Count > 0 Then
                    For Each R1 In Me.dbgOderInfo.DataSource.Table.Rows
                        If Not IsDBNull(dt1.Compute("Sum(Qty)", "Model_ID = " & R1("Model_ID"))) Then
                            R1.BeginEdit() : R1("Filled Qty") = dt1.Compute("Sum(Qty)", "Model_ID = " & R1("Model_ID")) : R1.EndEdit()
                        End If
                    Next R1
                    Me.dbgOderInfo.DataSource.Table.AcceptChanges()

                    '*******************************************
                    'Update box quantity
                    '*******************************************
                    R1 = Me.dbgBoxInfo.DataSource.Table.Select("Pallett_ID = " & iPallet_ID)(0)
                    If Not IsDBNull(dt1.Compute("Sum(Qty)", "Pallett_ID = " & iPallet_ID)) And Not IsNothing(dt1.Compute("Sum(Qty)", "Pallett_ID = " & iPallet_ID)) Then
                        R1.BeginEdit() : R1("Qty") = dt1.Compute("Sum(Qty)", "Pallett_ID = " & iPallet_ID) : R1.EndEdit()
                        Me.dbgBoxInfo.DataSource.Table.AcceptChanges()
                    End If
                End If
                '*******************************************

                If Not IsDBNull(Me.dbgOderInfo.DataSource.Table.Compute("Sum([Filled Qty])", "")) Then Me.lblFilledQty.Text = Me.dbgOderInfo.DataSource.Table.Compute("Sum([Filled Qty])", "") Else Me.lblFilledQty.Text = "0"

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt1)
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '**************************************************************************
        Private Sub dbgBoxInfo_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgBoxInfo.RowColChange
            Try
                If Me._booPopulateData = True Then Exit Sub

                Me.lblBoxName.Text = ""
                Me.lblCount.Text = "0"
                Me.txtDevSN.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.pnlSNsList.Visible = False

                If Me.dbgBoxInfo.RowCount > 0 AndAlso Me.dbgBoxInfo.Columns("Open?").Value.ToString.ToLower = "yes" Then
                    RefreshSNList()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "dbgBoxInfo_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Sub txtMaxBoxQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaxBoxQty.KeyPress
            Try
                If e.KeyChar.IsDigit(e.KeyChar) = False And e.KeyChar.IsControl(e.KeyChar) = False Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtMaxBoxQty_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnCreateBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBox.Click
            Dim iModelID, iMaxQty, iPalletID As Integer

            Try
                If Me.txtMaxBoxQty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please maximum box quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMaxBoxQty.SelectAll()
                    Me.txtMaxBoxQty.Focus()
                ElseIf Me.cboOpenOrderNo.SelectedValue = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenOrderNo.SelectAll()
                    Me.cboOpenOrderNo.Focus()
                ElseIf Me.cboLocation.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenOrderNo.SelectAll()
                    Me.cboOpenOrderNo.Focus()
                ElseIf Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                ElseIf Me.dbgOderInfo.RowCount = 0 Then
                    MessageBox.Show("Order is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dbgOderInfo.DataSource.Table.select("Model_ID = null").length > 0 Then
                    MessageBox.Show("Model ID is missing for selected item #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dbgOderInfo.DataSource.Table.Compute("Sum(Qty)", "") = Me.dbgOderInfo.DataSource.Table.Compute("Sum([Filled Qty])", "") Then
                    MessageBox.Show("Order is full.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dbgBoxInfo.RowCount > 0 AndAlso Me.dbgBoxInfo.DataSource.Table.select("[Open?] = 'Yes'").length > 0 Then
                    MessageBox.Show("There are open boxes available to fill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dbgOderInfo.Columns("Model_ID").Value = 0 Then
                    MessageBox.Show("Can't define model ID. Please select line item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    iModelID = Me.dbgOderInfo.Columns("Model_ID").Value
                    iMaxQty = CInt(Me.txtMaxBoxQty.Text)

                    'check for open pallet
                    iPalletID = Me._objOFFM.GetOpenBoxIDInOrder(Me.cboLocation.SelectedValue, Me.cboOpenOrderNo.SelectedValue)
                    If iPalletID = 0 Then
                        iPalletID = Me._objOFFM.CreateBox(Me.cboCustomer.SelectedValue, Me.cboLocation.SelectedValue, iMaxQty, Me.cboOpenOrderNo.SelectedValue)
                        Me.PopulateBoxesInfo(iPalletID)
                    Else
                        MessageBox.Show("An open box is currently availalbe to fill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.PopulateBoxesInfo(iPalletID)
                        Me.txtDevSN.Focus()
                    End If  'check if there is an box available to fill
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreateBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDevSN.Text.Trim.Length > 0 Then Me.ProcessDevice()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************
        Private Sub ProcessDevice()
            Dim i As Integer = 0
            Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
            Dim dtDevice As DataTable

            Try
                '************************
                'Validations
                If CInt(Me.dbgBoxInfo.Columns("Pallett_ID").Value) = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.dbgBoxInfo.Columns("Box").Value.ToString.Trim = "" Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.txtDevSN.Text.Trim = "" Then
                    Exit Sub
                End If

                '***************************************************
                'Step 1: Check if the Device is already scanned in
                '***************************************************
                If Me.lstDevices.DataSource.Table.Select("Device_SN = '" & strSN & "'").length > 0 Then
                    MessageBox.Show("This device is already scanned in. Try another one.", "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                    Exit Sub
                End If

                '***************************************************
                'Step 2: Check quantity of box
                '***************************************************
                If Me.dbgBoxInfo.Columns("Max Qty").Value > 0 AndAlso Me.lstDevices.Items.Count >= Me.dbgBoxInfo.Columns("Max Qty").Value Then
                    Throw New Exception("Box can't contain more than " & Me.dbgBoxInfo.Columns("Max Qty").Value & " units.")
                End If
                '***************************************************
                'Prevent the user from adding more devices to closed pallet.
                'This happen when a pallet open at the 2 computer, computer 1 
                '  close the pallet and refesh the screen while the other computer screen 
                '  did not get refresh. This check will force the user to refresh the screen.
                '***************************************************
                If Generic.IsPalletClosed(CInt(Me.dbgBoxInfo.Columns("Pallett_ID").Value)) = True Then
                    MessageBox.Show("Box had been closed by another machine. Please refresh your screen.", "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                i = 0

                dtDevice = Generic.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, CInt(Me.dbgBoxInfo.Columns("Cust_ID").Value))

                If dtDevice.Rows.Count > 1 Then
                    MessageBox.Show("This device existed twice in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll()
                    Exit Sub
                ElseIf dtDevice.Rows.Count = 0 Then
                    MessageBox.Show("This device does not exist in the system, already ship or belong to a different customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll()
                    Exit Sub
                Else
                    If Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                        MessageBox.Show("This device has assigned into a box ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.Text = ""
                    ElseIf Not IsDBNull(dtDevice.Rows(0)("Device_DateShip")) Then
                        MessageBox.Show("This device has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.Text = ""
                        'ElseIf dtDevice.Rows(0)("Model_ID") <> Me.dbgBoxInfo.Columns("Model_ID").Value Then
                        '    MessageBox.Show("Wrong Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.txtDevSN.Text = ""
                    ElseIf dtDevice.Rows(0)("Device_FinishedGoods") <> 1 Then
                        MessageBox.Show("Device is not a fished good device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.Text = ""
                    ElseIf Me.dbgOderInfo.DataSource.Table.Select("Model_ID = " & dtDevice.Rows(0)("Model_ID")).length = 0 Then
                        MessageBox.Show("Wrong model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.Text = ""
                    ElseIf Me.dbgOderInfo.DataSource.Table.Compute("Sum([Filled Qty])", "Model_ID = " & dtDevice.Rows(0)("Model_ID")) >= Me.dbgOderInfo.DataSource.Table.Compute("Sum([Qty])", "Model_ID = " & dtDevice.Rows(0)("Model_ID")) Then
                        Throw New Exception("All units for this item # " & Me.dbgOderInfo.Columns("Item#").Value & " has been filled.")
                    Else
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        '***************************************************
                        'if above all is fine then add it to the list and update the database
                        i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgBoxInfo.Columns("Pallett_ID").Value))

                        '***************************************************
                        Me.RefreshSNList()
                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        Me.txtDevSN.Text = ""
                        Me.txtDevSN.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("ProcessSN: " & ex.Message, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtDevSN.Text = ""
                Me.txtDevSN.Focus()
            Finally
                Generic.DisposeDT(dtDevice)
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnAddAccessories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAccessories.Click
            Dim iDeviceID, iPOHeader As Integer

            Try
                iDeviceID = 0 : iPOHeader = 0
                If Me.dbgOderInfo.RowCount = 0 Then
                    Exit Sub
                ElseIf Me.cboLocation.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Me.cboOpenOrderNo.SelectedValue = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Me.dbgOderInfo.Columns("Accessory?").Value = 0 Then
                    MessageBox.Show("This item # ( " & Me.dbgOderInfo.Columns("Item#").Value & ") is not accessory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Me.dbgOderInfo.Columns("Model_ID").Value = 0 Then
                    MessageBox.Show("Model ID of this item # ( " & Me.dbgOderInfo.Columns("Item#").Value & ") is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Me.dbgOderInfo.Columns("Qty").Value = Me.dbgOderInfo.Columns("Filled Qty").Value Then
                    MessageBox.Show("This item # ( " & Me.dbgOderInfo.Columns("Item#").Value & ") has filled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Me.dbgBoxInfo.Columns("Pallett_ID").Value.ToString.Trim = "" Then
                    MessageBox.Show("Box name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Me.dbgOderInfo.Columns("Model_ID").Value = 1344 And Me.txtRetFedExTrackingNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter Fedex returns tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    iPOHeader = CInt(Me.dbgOderInfo.Columns("SOHeaderID").Value.ToString)
                    iDeviceID = Me._objOFFM.FillAccessory(Me.cboLocation.SelectedValue, _
                                                          Me.dbgOderInfo.Columns("Model_ID").Value, _
                                                          Me.cboOpenOrderNo.SelectedValue, _
                                                          Me.dbgBoxInfo.Columns("Pallett_ID").Value, _
                                                          Me.lblAccQty.Text, _
                                                          PSS.Core.Global.ApplicationUser.IDShift, _
                                                          iPOHeader, _
                                                          Me.lblAccItemNo.Text, _
                                                          Me.txtRetFedExTrackingNo.Text.ToUpper.Trim)
                    If iDeviceID > 0 Then
                        Me.RefreshSNList()
                        Me.lblAccItemNo.Text = ""
                        Me.lblAccQty.Text = ""
                        Me.txtRetFedExTrackingNo.Text = ""
                        Me.btnAddAccessories.Visible = False
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddAccessories_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            Dim i, iQty As Integer
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim dt As DataTable

            Try
                '************************
                'Validations
                If CInt(Me.dbgBoxInfo.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Box name is not selected.")
                ElseIf Me.dbgBoxInfo.Columns("Box").Value.ToString.Trim = "" Then
                    Throw New Exception("Box name is not selected.")
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("This box is empty.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txtDevSN.Focus() : Exit Sub
                ElseIf Me.dbgBoxInfo.Columns("Max Qty").Value > 0 AndAlso Me.lstDevices.Items.Count > Me.dbgBoxInfo.Columns("Max Qty").Value Then
                    MessageBox.Show("Box can't contain more than " & Me.dbgBoxInfo.Columns("Max Qty").Value & " units.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txtDevSN.Focus() : Exit Sub
                ElseIf MessageBox.Show("Are you sure you want to close box " & Me.dbgBoxInfo.Columns("Box").Value & "?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dt = Me._objOFFM.GetBoxLabelData(Me.dbgBoxInfo.Columns("Box").Value, Me.cboCustomer.SelectedValue)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Box does not exist or has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Box existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(dt.Rows(0)("ShipDate")) Then
                        MessageBox.Show("Box has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        'Get Qty
                        iQty = CInt(Me.dbgBoxInfo.Columns("Qty").Value)

                        objMisc = New PSS.Data.Buisness.Misc()
                        i = objMisc.ClosePallet(CInt(Me.dbgBoxInfo.Columns("Cust_ID").Value), CInt(Me.dbgBoxInfo.Columns("Pallett_ID").Value), Me.dbgBoxInfo.Columns("Box").Value, iQty, Me.dbgBoxInfo.Columns("Pallet_ShipType").Value, 0, )
                        If i = 0 Then
                            Throw New Exception("Box has not closed yet due to an error. Please contact IT.")
                        End If

                        '************************
                        'Print 4 x 4 Box Label
                        '************************
                        Me._objOFFM.PrintBoxLabel(dt)

                        'Refresh Pallet (Box) 
                        Me.PopulateBoxesInfo()

                        '******************************
                        'Reset Screen control properties.
                        Me.lblBoxName.Text = ""
                        Me.lblCount.Text = 0
                        Me.lstDevices.DataSource = Nothing
                        Me.pnlSNsList.Visible = False
                        Me.lblAccItemNo.Text = ""
                        Me.lblAccQty.Text = ""
                        Me.txtRetFedExTrackingNo.Text = ""

                        '******************************
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                objMisc = Nothing
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnCloseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseOrder.Click
            Dim dt As DataTable
            Dim iManifestID, iShipQty As Integer
            Dim objPeekBilling As Peek.PeekBilling

            Try
                '************************
                'Validate user input
                '************************
                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select a customer.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                ElseIf Me.cboLocation.SelectedValue = 0 Then
                    MessageBox.Show("Please select a location.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboLocation.SelectAll()
                    Me.cboLocation.Focus()
                ElseIf Me.cboOpenOrderNo.SelectedValue = 0 Then
                    MessageBox.Show("Please select a order.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboOpenOrderNo.SelectAll()
                    Me.cboOpenOrderNo.Focus()
                ElseIf CInt(Me.lblOrderQty.Text) <> CInt(Me.lblFilledQty.Text) Then
                    MessageBox.Show("System does not allow partial shipment.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me.txtTrackingNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tracking number.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtTrackingNo.Focus()
                ElseIf Me.txtShippingCost.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter shipping cost.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtShippingCost.SelectAll() : Me.txtShippingCost.Focus()
                ElseIf CDec(Me.txtShippingCost.Text.Trim) <= 0 Then
                    MessageBox.Show("Please enter shipping cost.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtShippingCost.SelectAll() : txtShippingCost.Focus()
                ElseIf Me.cboShipCarrier.SelectedValue = 0 Then
                    MessageBox.Show("Please select ship carrier.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf MessageBox.Show("Are you sure you want to ship selected order?", "Close Order", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    'exit sub
                Else
                    Me.Enabled = False

                    dt = Me._objOFFM.GetAllBoxesInOrder(Me.cboLocation.SelectedValue, Me.cboOpenOrderNo.SelectedValue)

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Order is empty.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Select("pkslip_ID > 0").Length > 0 Then
                        MessageBox.Show("Some boxes was assigned to another manifest.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Select("Pallett_ShipDate <> null").Length > 0 Then
                        MessageBox.Show("Some boxes have been shipped.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Select("Pallett_ReadyToShipFlg = 0").Length > 0 Then
                        MessageBox.Show("Some boxes is still open.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        Cursor.Current = Cursors.WaitCursor

                        iShipQty = dt.Compute("Sum(Pallett_QTY)", "")
                        iManifestID = Me._objOFFM.CloseOrder(Me.cboCustomer.SelectedValue, _
                                                   Me.cboOpenOrderNo.SelectedValue, Me.cboOpenOrderNo.DataSource.Table.select("WO_ID = " & Me.cboOpenOrderNo.SelectedValue)(0)("WO_CustWo"), _
                                                   ApplicationUser.IDuser, ApplicationUser.IDShift, ApplicationUser.Workdate, _
                                                   iShipQty, Me.cboShipCarrier.SelectedValue, Me.txtTrackingNo.Text, Me.dbgBoxInfo.RowCount, CDec(Me.txtShippingCost.Text))

                        If iManifestID > 0 Then
                            objPeekBilling = New Peek.PeekBilling()
                            objPeekBilling.BillPartsServices(iManifestID)
                            Me.lblFilledQty.Text = "0" : Me.lblOrderQty.Text = "0"
                            Me.txtShippingCost.Text = "" : Me.txtTrackingNo.Text = "" : Me.cboShipCarrier.SelectedValue = 0
                            Me.txtName.Text = "" : Me.txtAddress1.Text = "" : Me.txtAddress2.Text = "" : Me.txtCity.Text = "" : Me.txtState.Text = "" : Me.txtZipCode.Text = "" : Me.txtShipPhone.Text = "" : Me.lblCustPONo.Text = ""
                            Me.dbgBoxInfo.DataSource = Nothing : Me.dbgBoxInfo.Visible = False
                            Me.txtMaxBoxQty.Text = ""
                            Me.dbgOderInfo.DataSource = Nothing : Me.dbgOderInfo.Visible = False
                            Me.pnlCreateBox.Visible = False
                            Me.txtDevSN.Text = ""
                            Me.lblCount.Text = "0"
                            Me.lblBoxName.Text = ""
                            Me.pnlSNsList.Visible = False
                            Me.Enabled = True
                            Me.PopulateOpenOrdersList()
                            Me.cboOpenOrderNo.SelectAll()
                            Me.cboOpenOrderNo.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
                objPeekBilling = Nothing
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Dim strBoxName As String = ""
            Dim dt As DataTable

            Try
                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select a customer.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                Else
                    strBoxName = InputBox("Enter Box:").Trim()

                    If strBoxName.Trim.Length = 0 Then Exit Sub

                    Me.Enabled = False

                    dt = Me._objOFFM.GetBoxLabelData(strBoxName, Me.cboCustomer.SelectedValue)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Box does not exist or has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Box existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                        MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Cursor.Current = Cursors.WaitCursor
                        Me._objOFFM.PrintBoxLabel(dt)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnReprintPackingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintPackingSlip.Click
            Dim strPacingSlipID As String = ""
            Dim dt As DataTable

            Try
                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select a customer.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    strPacingSlipID = InputBox("Enter Packing Slip #:").Trim()

                    If strPacingSlipID.Trim.Length = 0 Then Exit Sub

                    Me._objOFFM.PrintPackingSlip(strPacingSlipID, 1)

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnReopenBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenBox.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim strCurrentStation As String = ""
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select a customer.", "Close Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                Else
                    '************************
                    strPallet = InputBox("Enter Box ID.", "Reopen Box")
                    If strPallet = "" Then
                        Exit Sub
                    Else
                        Me.Enabled = False

                        dt = Me._objOFFM.GetBoxData(strPallet, Me.cboCustomer.SelectedValue)
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Box does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Box name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                            MessageBox.Show("Box has been shipped. Not allow to reopen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                            MessageBox.Show("Box is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            Cursor.Current = Cursors.WaitCursor

                            objMisc = New PSS.Data.Buisness.Misc()
                            i = objMisc.ReopenPallet(dt.Rows(0)("Pallett_ID"))
                            If i = 0 Then Throw New Exception("Pallet was not reopened.")

                            'Refresh Pallet( Box )
                            Me.PopulateBoxesInfo(dt.Rows(0)("Pallett_ID"))

                            '************************
                            Me.lstDevices.DataSource = Nothing
                            Me.lblCount.Text = "0"
                            Me.lblBoxName.Text = ""
                            Me.pnlSNsList.Visible = False
                            '************************
                            Me.Enabled = True
                            Me.txtDevSN.Focus()
                        End If  'existed in database
                    End If  'Must enter box name
                End If  'must select customer
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reopen Box.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default

                Generic.DisposeDT(dt)
                objMisc = Nothing
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnDeleteEmptyBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteEmptyBox.Click
            Dim i As Integer

            Try
                If Me.dbgBoxInfo.RowCount = 0 OrElse CInt(Me.dbgBoxInfo.Columns("Pallett_ID").Value) = 0 Then
                    Exit Sub
                ElseIf Me.dbgBoxInfo.Columns("Qty").Value > 0 Then
                    MessageBox.Show("This box is not empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                ElseIf MessageBox.Show("Are you sure you want to delete box " & Me.dbgBoxInfo.Columns("Box").Value & "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.DeleteEmptyPallet(CInt(Me.dbgBoxInfo.Columns("Pallett_ID").Value), PSS.Core.ApplicationUser.IDuser)
                    MessageBox.Show("Box has been deleted.")

                    Me.PopulateBoxesInfo()
                    Me.lstDevices.DataSource = Nothing
                    Me.lblBoxName.Text = ""
                    Me.lblCount.Text = ""
                    Me.pnlSNsList.Visible = False
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim strSN As String = ""
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try
                '************************
                'Validations
                If Me.dbgBoxInfo.RowCount = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf CInt(Me.dbgBoxInfo.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.dbgBoxInfo.Columns("Open?").Value.ToString.ToLower = "no" Then
                    Throw New Exception("Box has been closed.")
                ElseIf CInt(Me.dbgBoxInfo.Columns("Qty").Value) = 0 Then
                    Throw New Exception("Box is empty.")
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    Throw New Exception("Box is empty.")
                End If

                '************************
                strSN = InputBox("Enter S/N:", "Get S/N").Trim
                If strSN = "" Then
                    Throw New Exception("Please enter a S/N: if you want to remove it from the selected box.")
                ElseIf Me.lstDevices.DataSource.Table.Select("Device_SN = '" & strSN & "'").Length = 0 Then
                    MessageBox.Show("S/N is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    R1 = Me.lstDevices.DataSource.Table.Select("Device_SN = '" & strSN & "'")(0)
                    If IsNothing(R1) = False Then

                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        If R1("Accessory") = 0 Then
                            i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgBoxInfo.Columns("Pallett_id").Value), R1("Device_ID"))
                        Else
                            i = Me._objOFFM.DeleteAccessorySN(R1("Device_ID"))
                        End If

                        If i = 0 Then
                            Throw New Exception("S/N entered was not removed from Box.")
                        End If

                        Me.RefreshSNList()
                    Else
                        Throw New Exception("S/N is not listed.")
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Clear S/N", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Dim str_sn As String = ""
            Dim i, j As Integer
            Dim dt As DataTable
            Dim drAccessories() As DataRow

            Try
                If MessageBox.Show("Are you sure you want to remove all devices in box " & Me.dbgBoxInfo.Columns("Box").Value & "?", "Clear All S/N", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                ElseIf Me.dbgBoxInfo.RowCount = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf CInt(Me.dbgBoxInfo.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.dbgBoxInfo.Columns("Open?").Value.ToString.ToLower = "no" Then
                    Throw New Exception("Box has been closed.")
                ElseIf CInt(Me.dbgBoxInfo.Columns("Qty").Value) = 0 Then
                    Throw New Exception("Box is empty.")
                End If

                '************************
                Me.Enabled = False

                dt = Me.lstDevices.DataSource.Table
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Cursor.Current = Cursors.WaitCursor

                    drAccessories = dt.Select("Accessory > 0")
                    If drAccessories.Length > 0 Then
                        'Delete Accessories
                        For j = 0 To drAccessories.Length - 1
                            i += Me._objOFFM.DeleteAccessorySN(drAccessories(j)("Device_ID"))
                        Next j
                    End If

                    'Remove device from pallet
                    i = 0
                    i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgBoxInfo.Columns("Pallett_id").Value), )

                    If i = 0 Then
                        Throw New Exception("No S/N was removed from box.")
                    End If

                    Me.PopulateBoxesInfo(CInt(Me.dbgBoxInfo.Columns("Pallett_id").Value))
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                drAccessories = Nothing
                Generic.DisposeDT(dt)
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '**************************************************************************
        Private Sub txtShippingCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShippingCost.KeyPress
            Try
                If e.KeyChar.IsDigit(e.KeyChar) = False And e.KeyChar.IsControl(e.KeyChar) = False And e.KeyChar <> "." Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtMaxBoxQty_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************

    End Class
End Namespace