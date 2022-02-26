
Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone

    Public Class frmWHManifest
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _objWH As PSS.Data.Buisness.TracFone.Warehouse
        Private _dtOrders As DataTable
        Private _iCust_ID As Integer = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal strScreenName As String = "", Optional ByVal iCustID As Integer = 0)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            If iCustID > 0 Then
                Me._iCust_ID = iCustID
            Else
                Me._iCust_ID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID
            End If
            _objWH = New PSS.Data.Buisness.TracFone.Warehouse()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
                _objWH = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents lblTotalQty As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnCreatePackingSlip As System.Windows.Forms.Button
        Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
        Friend WithEvents dbgWaitingPackingSlip As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnRemoveAllItems As System.Windows.Forms.Button
        Friend WithEvents btnRemoveOneItem As System.Windows.Forms.Button
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtTracingNo As System.Windows.Forms.TextBox
        Friend WithEvents cboCarrier As C1.Win.C1List.C1Combo
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents nudPalletNumber As System.Windows.Forms.NumericUpDown
        Friend WithEvents chkPalletize As System.Windows.Forms.CheckBox
        Friend WithEvents lblPalletNumber As System.Windows.Forms.Label
        Friend WithEvents btnReprintBillOfLading As System.Windows.Forms.Button
        Friend WithEvents btnReprintPalletLabel As System.Windows.Forms.Button
        Friend WithEvents dgOrders As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWHManifest))
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.dgOrders = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReprintPalletLabel = New System.Windows.Forms.Button()
            Me.btnReprintBillOfLading = New System.Windows.Forms.Button()
            Me.chkPalletize = New System.Windows.Forms.CheckBox()
            Me.nudPalletNumber = New System.Windows.Forms.NumericUpDown()
            Me.lblPalletNumber = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtTracingNo = New System.Windows.Forms.TextBox()
            Me.cboCarrier = New C1.Win.C1List.C1Combo()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.btnRemoveAllItems = New System.Windows.Forms.Button()
            Me.btnRemoveOneItem = New System.Windows.Forms.Button()
            Me.lblTotalQty = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblBoxQty = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnCreatePackingSlip = New System.Windows.Forms.Button()
            Me.txtOrderNo = New System.Windows.Forms.TextBox()
            Me.dbgWaitingPackingSlip = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.GroupBox2.SuspendLayout()
            CType(Me.dgOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nudPalletNumber, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgWaitingPackingSlip, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgOrders, Me.btnReprintPalletLabel, Me.btnReprintBillOfLading, Me.chkPalletize, Me.nudPalletNumber, Me.lblPalletNumber, Me.Label11, Me.txtTracingNo, Me.cboCarrier, Me.Label9, Me.btnRemoveAllItems, Me.btnRemoveOneItem, Me.lblTotalQty, Me.Label10, Me.lblBoxQty, Me.Label7, Me.Label3, Me.btnCreatePackingSlip, Me.txtOrderNo})
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(8, 0)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(512, 544)
            Me.GroupBox2.TabIndex = 3
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Create Packing Slip"
            '
            'dgOrders
            '
            Me.dgOrders.AllowUpdate = False
            Me.dgOrders.AlternatingRows = True
            Me.dgOrders.CaptionHeight = 17
            Me.dgOrders.FilterBar = True
            Me.dgOrders.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgOrders.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgOrders.Location = New System.Drawing.Point(160, 160)
            Me.dgOrders.Name = "dgOrders"
            Me.dgOrders.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgOrders.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgOrders.PreviewInfo.ZoomFactor = 75
            Me.dgOrders.RowHeight = 15
            Me.dgOrders.Size = New System.Drawing.Size(344, 312)
            Me.dgOrders.TabIndex = 125
            Me.dgOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 9.75pt, sty" & _
            "le=Bold;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highligh" & _
            "t;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHo" & _
            "rz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}Style12{}HighlightRo" & _
            "w{ForeColor:HighlightText;BackColor:Highlight;}RecordSelector{AlignImage:Center;" & _
            "}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:Inac" & _
            "tiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:True;AlignVert:Center;B" & _
            "order:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{Font" & _
            ":Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{" & _
            "}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;Ali" & _
            "gnVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><" & _
            "C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""" & _
            "17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeSty" & _
            "le=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrol" & _
            "lGroup=""1"" HorizontalScrollGroup=""1""><Height>308</Height><CaptionStyle parent=""S" & _
            "tyle2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle p" & _
            "arent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" />" & _
            "<FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style1" & _
            "2"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hig" & _
            "hlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowS" & _
            "tyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" " & _
            "me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Nor" & _
            "mal"" me=""Style1"" /><ClientRect>0, 0, 340, 308</ClientRect><BorderSide>0</BorderS" & _
            "ide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><N" & _
            "amedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" />" & _
            "<Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><St" & _
            "yle parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Sty" & _
            "le parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Sty" & _
            "le parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style pa" & _
            "rent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><St" & _
            "yle parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzS" & _
            "plits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWi" & _
            "dth><ClientArea>0, 0, 340, 308</ClientArea><PrintPageHeaderStyle parent="""" me=""S" & _
            "tyle20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'btnReprintPalletLabel
            '
            Me.btnReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintPalletLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintPalletLabel.Location = New System.Drawing.Point(8, 452)
            Me.btnReprintPalletLabel.Name = "btnReprintPalletLabel"
            Me.btnReprintPalletLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReprintPalletLabel.Size = New System.Drawing.Size(144, 24)
            Me.btnReprintPalletLabel.TabIndex = 124
            Me.btnReprintPalletLabel.Text = "Reprint Pallet Label"
            '
            'btnReprintBillOfLading
            '
            Me.btnReprintBillOfLading.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBillOfLading.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBillOfLading.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBillOfLading.Location = New System.Drawing.Point(8, 420)
            Me.btnReprintBillOfLading.Name = "btnReprintBillOfLading"
            Me.btnReprintBillOfLading.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReprintBillOfLading.Size = New System.Drawing.Size(144, 24)
            Me.btnReprintBillOfLading.TabIndex = 123
            Me.btnReprintBillOfLading.Text = "Reprint Bill of Lading"
            '
            'chkPalletize
            '
            Me.chkPalletize.Location = New System.Drawing.Point(160, 72)
            Me.chkPalletize.Name = "chkPalletize"
            Me.chkPalletize.Size = New System.Drawing.Size(104, 16)
            Me.chkPalletize.TabIndex = 122
            Me.chkPalletize.Text = "Palletize"
            '
            'nudPalletNumber
            '
            Me.nudPalletNumber.Location = New System.Drawing.Point(160, 96)
            Me.nudPalletNumber.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
            Me.nudPalletNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.nudPalletNumber.Name = "nudPalletNumber"
            Me.nudPalletNumber.Size = New System.Drawing.Size(72, 22)
            Me.nudPalletNumber.TabIndex = 3
            Me.nudPalletNumber.Value = New Decimal(New Integer() {1, 0, 0, 0})
            Me.nudPalletNumber.Visible = False
            '
            'lblPalletNumber
            '
            Me.lblPalletNumber.BackColor = System.Drawing.Color.Transparent
            Me.lblPalletNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletNumber.ForeColor = System.Drawing.Color.White
            Me.lblPalletNumber.Location = New System.Drawing.Point(40, 99)
            Me.lblPalletNumber.Name = "lblPalletNumber"
            Me.lblPalletNumber.Size = New System.Drawing.Size(120, 16)
            Me.lblPalletNumber.TabIndex = 121
            Me.lblPalletNumber.Text = "Pallet # :"
            Me.lblPalletNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPalletNumber.Visible = False
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(72, 44)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(88, 16)
            Me.Label11.TabIndex = 120
            Me.Label11.Text = "Tracking #:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTracingNo
            '
            Me.txtTracingNo.Location = New System.Drawing.Point(160, 42)
            Me.txtTracingNo.Name = "txtTracingNo"
            Me.txtTracingNo.Size = New System.Drawing.Size(192, 22)
            Me.txtTracingNo.TabIndex = 2
            Me.txtTracingNo.Text = ""
            '
            'cboCarrier
            '
            Me.cboCarrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCarrier.AutoCompletion = True
            Me.cboCarrier.AutoDropDown = True
            Me.cboCarrier.AutoSelect = True
            Me.cboCarrier.Caption = ""
            Me.cboCarrier.CaptionHeight = 17
            Me.cboCarrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCarrier.ColumnCaptionHeight = 17
            Me.cboCarrier.ColumnFooterHeight = 17
            Me.cboCarrier.ColumnHeaders = False
            Me.cboCarrier.ContentHeight = 15
            Me.cboCarrier.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCarrier.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCarrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrier.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCarrier.EditorHeight = 15
            Me.cboCarrier.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCarrier.ItemHeight = 15
            Me.cboCarrier.Location = New System.Drawing.Point(160, 16)
            Me.cboCarrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboCarrier.MaxDropDownItems = CType(10, Short)
            Me.cboCarrier.MaxLength = 32767
            Me.cboCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCarrier.Name = "cboCarrier"
            Me.cboCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCarrier.Size = New System.Drawing.Size(192, 21)
            Me.cboCarrier.TabIndex = 1
            Me.cboCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(72, 18)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(88, 16)
            Me.Label9.TabIndex = 119
            Me.Label9.Text = "Carrier :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRemoveAllItems
            '
            Me.btnRemoveAllItems.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllItems.Enabled = False
            Me.btnRemoveAllItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllItems.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllItems.Location = New System.Drawing.Point(8, 360)
            Me.btnRemoveAllItems.Name = "btnRemoveAllItems"
            Me.btnRemoveAllItems.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllItems.Size = New System.Drawing.Size(144, 24)
            Me.btnRemoveAllItems.TabIndex = 8
            Me.btnRemoveAllItems.Text = "REMOVE ALL"
            '
            'btnRemoveOneItem
            '
            Me.btnRemoveOneItem.BackColor = System.Drawing.Color.Red
            Me.btnRemoveOneItem.Enabled = False
            Me.btnRemoveOneItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveOneItem.ForeColor = System.Drawing.Color.White
            Me.btnRemoveOneItem.Location = New System.Drawing.Point(8, 320)
            Me.btnRemoveOneItem.Name = "btnRemoveOneItem"
            Me.btnRemoveOneItem.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveOneItem.Size = New System.Drawing.Size(144, 24)
            Me.btnRemoveOneItem.TabIndex = 7
            Me.btnRemoveOneItem.Text = "REMOVE ONE ITEM"
            '
            'lblTotalQty
            '
            Me.lblTotalQty.BackColor = System.Drawing.Color.Black
            Me.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalQty.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalQty.Location = New System.Drawing.Point(24, 256)
            Me.lblTotalQty.Name = "lblTotalQty"
            Me.lblTotalQty.Size = New System.Drawing.Size(112, 35)
            Me.lblTotalQty.TabIndex = 111
            Me.lblTotalQty.Text = "0"
            Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Black
            Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Lime
            Me.Label10.Location = New System.Drawing.Point(24, 240)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(112, 18)
            Me.Label10.TabIndex = 112
            Me.Label10.Text = "DEVICE TOTAL"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblBoxQty
            '
            Me.lblBoxQty.BackColor = System.Drawing.Color.Black
            Me.lblBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxQty.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxQty.Location = New System.Drawing.Point(24, 192)
            Me.lblBoxQty.Name = "lblBoxQty"
            Me.lblBoxQty.Size = New System.Drawing.Size(112, 35)
            Me.lblBoxQty.TabIndex = 109
            Me.lblBoxQty.Text = "0"
            Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Black
            Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Lime
            Me.Label7.Location = New System.Drawing.Point(24, 176)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(112, 18)
            Me.Label7.TabIndex = 110
            Me.Label7.Text = "BOX QTY"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(24, 129)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(136, 16)
            Me.Label3.TabIndex = 105
            Me.Label3.Text = "Order# :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCreatePackingSlip
            '
            Me.btnCreatePackingSlip.BackColor = System.Drawing.Color.Green
            Me.btnCreatePackingSlip.Location = New System.Drawing.Point(168, 496)
            Me.btnCreatePackingSlip.Name = "btnCreatePackingSlip"
            Me.btnCreatePackingSlip.Size = New System.Drawing.Size(184, 24)
            Me.btnCreatePackingSlip.TabIndex = 6
            Me.btnCreatePackingSlip.Text = "Create Packing Slip"
            '
            'txtOrderNo
            '
            Me.txtOrderNo.Location = New System.Drawing.Point(160, 128)
            Me.txtOrderNo.Name = "txtOrderNo"
            Me.txtOrderNo.Size = New System.Drawing.Size(192, 22)
            Me.txtOrderNo.TabIndex = 4
            Me.txtOrderNo.Text = ""
            '
            'dbgWaitingPackingSlip
            '
            Me.dbgWaitingPackingSlip.AllowUpdate = False
            Me.dbgWaitingPackingSlip.AlternatingRows = True
            Me.dbgWaitingPackingSlip.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgWaitingPackingSlip.FilterBar = True
            Me.dbgWaitingPackingSlip.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgWaitingPackingSlip.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgWaitingPackingSlip.Location = New System.Drawing.Point(536, 6)
            Me.dbgWaitingPackingSlip.Name = "dbgWaitingPackingSlip"
            Me.dbgWaitingPackingSlip.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgWaitingPackingSlip.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgWaitingPackingSlip.PreviewInfo.ZoomFactor = 75
            Me.dbgWaitingPackingSlip.Size = New System.Drawing.Size(368, 538)
            Me.dbgWaitingPackingSlip.TabIndex = 6
            Me.dbgWaitingPackingSlip.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>5" & _
            "34</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 364, 534<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 364, 534</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'frmWHManifest
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(920, 557)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgWaitingPackingSlip, Me.GroupBox2})
            Me.Name = "frmWHManifest"
            Me.Text = "frmWHManifest"
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.dgOrders, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nudPalletNumber, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgWaitingPackingSlip, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************
        Private Sub frmWHManifest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim i As Integer

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                PopulateCarriers()

                Me.PopulateWaitingPackingOrder()
                Me._dtOrders = Me._objWH.GetTFOrderReadyForPackingSlipTemplateTable

                With Me.dgOrders
                    .DataSource = Me._dtOrders.DefaultView
                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).FilterBar = True
                    For i = 0 To Me._dtOrders.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).AllowSizing = True
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    Next i

                    .Splits(0).DisplayColumns("Box Qty").Width = 75
                    .Splits(0).DisplayColumns("Unit Qty").Width = 75
                End With

                Me.txtOrderNo.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmWHManifest_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub PopulateCarriers()
            Dim dt As DataTable

            Try
                dt = Me._objWH.GetShipCarriersWithACACCode(True)
                Misc.PopulateC1DropDownList(Me.cboCarrier, dt, "SC_Desc", "SC_ID")
                Me.cboCarrier.SelectedValue = 2
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub PopulateWaitingPackingOrder()
            Dim dt As DataTable
            Dim i As Integer

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                dt = Me._objWH.GetTFOrderReadyForPackingSlip(Me._iCust_ID)
                With Me.dbgWaitingPackingSlip
                    dt.DefaultView.Sort = "Order #"
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    .Visible = True
                    .AllowFilter = True
                    .FilterBar = True

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                        .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                        'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                        If dt.Columns(i).Caption = "Order #" Then
                            .Splits(0).DisplayColumns(i).Width = 160
                            .Splits(0).DisplayColumns(i).Frozen = True
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption = "Model" Then
                            .Splits(0).DisplayColumns(i).Width = 150
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption = "Box Qty" Then
                            .Splits(0).DisplayColumns(i).Width = 70
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        ElseIf dt.Columns(i).Caption = "Unit Qty" Then
                            .Splits(0).DisplayColumns(i).Width = 70
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        Else
                            .Splits(0).DisplayColumns(i).Visible = False
                        End If
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub ClearVarsCtrls()
            Try
                Me.txtOrderNo.Text = ""
                Me._dtOrders.Clear()
                Me._dtOrders.AcceptChanges()
                Me.dgOrders.Rebind(True)
                Me.lblBoxQty.Text = "0"
                Me.lblTotalQty.Text = "0"
                Me.btnRemoveAllItems.Enabled = False
                Me.btnRemoveOneItem.Enabled = False
                Me.btnCreatePackingSlip.Enabled = False
                Me.txtOrderNo.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearVarsCtrls", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub cboCarrier_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCarrier.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboCarrier.SelectedValue > 0 Then Me.txtTracingNo.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboCarrier_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub txtTracingNo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTracingNo.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtTracingNo.Text.Trim.Length > 0 Then Me.nudPalletNumber.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtTracingNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub txtTracingNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTracingNo.KeyPress
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) = False AndAlso e.KeyChar.IsControl(e.KeyChar) = False Then e.Handled = True
        End Sub

        '********************************************************************
        Private Sub btnRemoveOneItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOneItem.Click
            Dim strOrderNo As String = ""
            Dim R1 As DataRow

            Try
                If Me.dgOrders.RowCount = 0 Then
                    MessageBox.Show("The list is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strOrderNo = InputBox("Please enter Order Number:", "Get Order").Trim

                    If strOrderNo.Length = 0 Then
                        Exit Sub : Me.txtOrderNo.Focus()
                    Else
                        If Me._dtOrders.Select("[Order #] = '" & strOrderNo & "' ").Length = 0 Then
                            MessageBox.Show("Order number is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            R1 = Me._dtOrders.Select("[Order #] = '" & strOrderNo & "'")(0)
                            Me._dtOrders.Rows.Remove(R1)
                            Me._dtOrders.AcceptChanges()
                            Me.dgOrders.Rebind(True)

                            If Me._dtOrders.Rows.Count > 0 Then
                                Me.btnCreatePackingSlip.Enabled = True
                                Me.btnRemoveAllItems.Enabled = True
                                Me.btnRemoveOneItem.Enabled = True
                            Else
                                Me.btnCreatePackingSlip.Enabled = False
                                Me.btnRemoveAllItems.Enabled = False
                                Me.btnRemoveOneItem.Enabled = False
                            End If
                            If Not IsDBNull(Me._dtOrders.Compute("Sum([Box Qty])", "")) Then Me.lblBoxQty.Text = Me._dtOrders.Compute("Sum([Box Qty])", "") Else Me.lblBoxQty.Text = "0"
                            If Not IsDBNull(Me._dtOrders.Compute("Sum([Unit Qty])", "")) Then Me.lblTotalQty.Text = Me._dtOrders.Compute("Sum([Unit Qty])", "") Else Me.lblTotalQty.Text = "0"
                            Me.txtOrderNo.Text = ""
                            Me.txtOrderNo.Focus()
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveOneItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                R1 = Nothing
            End Try
        End Sub

        '********************************************************************
        Private Sub btnRemoveAllItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllItems.Click
            Try
                If MessageBox.Show("Are you sure you want to remove all items in the list.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Me.txtOrderNo.Focus()
                    Exit Sub
                Else
                    Me.btnCreatePackingSlip.Enabled = False
                    Me.btnRemoveAllItems.Enabled = False
                    Me.btnRemoveOneItem.Enabled = False
                    Me._dtOrders.Clear()
                    Me._dtOrders.AcceptChanges()
                    Me.dgOrders.Rebind(True)
                    Me.lblBoxQty.Text = "0"
                    Me.lblTotalQty.Text = "0"
                    Me.txtOrderNo.Text = ""
                    Me.txtOrderNo.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAllItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub txtOrderNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrderNo.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtOrderNo.Text.Trim.Length > 0 Then Me.ProcessTFOrder()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtOrderNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Function ProcessTFOrder()
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                Me.Enabled = False

                If Me.cboCarrier.SelectedValue = 0 Then
                    MessageBox.Show("Please select carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.Text = ""
                    Me.cboCarrier.Focus()
                ElseIf Me.txtTracingNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.Text = ""
                    Me.txtTracingNo.Focus()
                ElseIf Me._dtOrders.Select("[Order #] = '" & Me.txtOrderNo.Text.Trim & "'").Length > 0 Then
                    MessageBox.Show("Order is already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.SelectAll()
                    Me.txtOrderNo.Focus()
                Else
                    dt = Me._objWH.GetOrderToBeManifestByOrderNo(Me.txtOrderNo.Text.Trim, Me._iCust_ID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Order number does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Select("pkslip_ID > 0").Length > 0 Then
                        MessageBox.Show("This Order number has already assigned to manifest number " & dt.Select("pkslip_ID > 0")(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Select("WO_Closed = 0").Length > 0 Then
                        MessageBox.Show("This Order still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Cursor.Current = Cursors.WaitCursor
                        R1 = Me._dtOrders.NewRow
                        R1("Order #") = dt.Rows(0)("WO_CustWO")
                        R1("WO_ID") = dt.Rows(0)("WO_ID")
                        If Me.chkPalletize.Checked = True Then R1("Pallet_SeqNo") = Me.nudPalletNumber.Value Else R1("Pallet_SeqNo") = 0
                        If Not IsDBNull(dt.Compute("sum(Pallett_QTY)", "")) Then R1("Unit Qty") = dt.Compute("sum(Pallett_QTY)", "") Else R1("Unit Qty") = 0
                        R1("Box Qty") = dt.Rows.Count
                        Me._dtOrders.Rows.Add(R1)
                        Me._dtOrders.AcceptChanges()
                        Me.dgOrders.Rebind(True)

                        If Not IsDBNull(Me._dtOrders.Compute("Sum([Box Qty])", "")) Then Me.lblBoxQty.Text = Me._dtOrders.Compute("Sum([Box Qty])", "") Else Me.lblBoxQty.Text = "0"
                        If Not IsDBNull(Me._dtOrders.Compute("Sum([Unit Qty])", "")) Then Me.lblTotalQty.Text = Me._dtOrders.Compute("Sum([Unit Qty])", "") Else Me.lblTotalQty.Text = "0"
                        Me.txtOrderNo.Text = ""
                        Me.btnRemoveOneItem.Enabled = True
                        Me.btnRemoveAllItems.Enabled = True
                        Me.btnCreatePackingSlip.Enabled = True
                        Me.Enabled = True
                        Me.txtOrderNo.Focus()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************
        Private Sub btnCreatePackingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePackingSlip.Click
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strWOIDs As String = ""

            Try
                If Me.chkPalletize.Checked = True Then
                    If Me._dtOrders.Select("Pallet_SeqNo = 0").Length > 0 Then
                        MessageBox.Show("Pallet Number is missing for this order # """ & Me._dtOrders.Select("Pallet_SeqNo = 0")(0)("WO_CustWO") & """. Please verify it before continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                Else
                    If Me._dtOrders.Select("Pallet_SeqNo > 0").Length > 0 Then
                        MessageBox.Show("This order # """ & Me._dtOrders.Select("Pallet_SeqNo = 0")(0)("WO_CustWO") & """ has a pallet assigned to it. Please verify it before continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If

                Me.Enabled = False

                If Me._dtOrders.Rows.Count = 0 Then
                    MessageBox.Show("Please scan in order number to create manifest.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboCarrier.SelectedValue = 0 Then
                    MessageBox.Show("Please select carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.Text = ""
                    Me.cboCarrier.Focus()
                ElseIf Me.txtTracingNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.Text = ""
                    Me.txtTracingNo.Focus()
                Else
                    If MessageBox.Show("Are you sure you want to manifest all items in the list?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

                    For Each R1 In Me._dtOrders.Rows
                        If strWOIDs.Trim.Length > 0 Then strWOIDs &= ", "
                        strWOIDs &= R1("WO_ID")
                    Next R1

                    dt = Me._objWH.GetOrdersToBeManifestbyWOIDs(strWOIDs, Me._iCust_ID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Order(s) do not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Select("pkslip_ID > 0").Length > 0 Then
                        MessageBox.Show("This Order number " & dt.Select("pkslip_ID > 0")(0)("WO_CustWO") & " has already assigned to manifest number " & dt.Select("pkslip_ID > 0")(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Select("WO_Closed = 0").Length > 0 Then
                        MessageBox.Show("This Order " & dt.Select("WO_Closed = 0")(0)("WO_CustWO") & " still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Cursor.Current = Cursors.WaitCursor

                        Me._objWH.CreateManifest(Me._dtOrders, strWOIDs, PSS.Core.Global.ApplicationUser.IDuser, Me.cboCarrier.SelectedValue, Me.txtTracingNo.Text.Trim.ToUpper, Me._strScreenName, Me.Name, Me._iCust_ID)

                        Me.Enabled = True
                        Me._dtOrders.Clear()
                        Me.dgOrders.Rebind(True)
                        Me.lblBoxQty.Text = "0"
                        Me.lblTotalQty.Text = "0"
                        Me.txtOrderNo.Text = ""
                        Me.btnRemoveOneItem.Enabled = False
                        Me.btnRemoveAllItems.Enabled = False
                        Me.btnCreatePackingSlip.Enabled = False
                        Me.PopulateWaitingPackingOrder()
                        Me.Enabled = True
                        Me.txtOrderNo.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreatePackingSlip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                R1 = Nothing
                Generic.DisposeDT(dt)
                Me.txtOrderNo.Focus()
            End Try
        End Sub

        '********************************************************************
        Private Sub nudPalletNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nudPalletNumber.KeyUp
            Try
                Me.txtOrderNo.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreatePackingSlip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub chkPalletize_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPalletize.CheckedChanged
            Try
                Me._dtOrders.Clear()
                Me.dgOrders.Rebind(True)
                Me.lblBoxQty.Text = "0"
                Me.lblTotalQty.Text = "0"
                Me.txtOrderNo.Text = ""

                If Me.chkPalletize.Checked = True Then
                    Me.lblPalletNumber.Visible = True
                    Me.nudPalletNumber.Visible = True
                Else
                    Me.lblPalletNumber.Visible = False
                    Me.nudPalletNumber.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkPalletize_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************
        Private Sub btnReprintBillOfLading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBillOfLading.Click
            Dim iOrderNo As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow


            Try
                iOrderNo = InputBox("Please enter Order # .", "Reprint Box Label")
                If iOrderNo.ToString.Length = 0 Then
                    Throw New Exception("Please enter a Order # if you want to reprint the box label.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                dt = Me._objWH.GetPkSlipToReprint(iOrderNo)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Order # was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Order #'s duplicated in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    R1 = dt.Rows(0)

                    If R1("wo_closed") = 0 Then
                        MessageBox.Show("WO is still open.", "Information", MessageBoxButtons.OK)
                    ElseIf Not IsDBNull(R1("pkslip_id")) AndAlso CInt(R1("pkslip_id")) > 0 Then
                        Me._objWH.PrintBillsOfLadingReport(R1("pkslip_id"), Me._iCust_ID)
                    Else
                        MessageBox.Show("Pkslip is not available.", "Information", MessageBoxButtons.OK)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************
        Private Sub btnReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintPalletLabel.Click
            Dim iOrderNo As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                iOrderNo = InputBox("Please enter Order # .", "Reprint Box Label")
                If iOrderNo.ToString.Length = 0 Then
                    Throw New Exception("Please enter a Order # if you want to reprint the box label.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                dt = Me._objWH.GetPkSlipToReprint(iOrderNo)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Order # was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Order #'s duplicated in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    R1 = dt.Rows(0)

                    If R1("wo_closed") = 0 Then
                        MessageBox.Show("WO is still open.", "Information", MessageBoxButtons.OK)
                    ElseIf Not IsDBNull(R1("pkslip_id")) AndAlso CInt(R1("pkslip_id")) > 0 Then
                        Me._objWH.PrintShipmentLabelReport(R1("pkslip_id"), Me._iCust_ID)
                    Else
                        MessageBox.Show("Pkslip is not available.", "Information", MessageBoxButtons.OK)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                Generic.DisposeDT(dt)
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************

    End Class
End Namespace