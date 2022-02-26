Option Explicit On 

Imports PSS.Data
Imports PSS.Core

Namespace Gui
    Public Class frmAquisProdRec
        Inherits System.Windows.Forms.Form

        Private _objProdRec As PSS.Data.Production.Receiving
        Private _objAquisProdRec As PSS.Data.Buisness.AquisProdRec
        Private _booPopulateData As Boolean = False
        Private _iTrayID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objProdRec = New PSS.Data.Production.Receiving()
            _objAquisProdRec = New PSS.Data.Buisness.AquisProdRec()
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
        Friend WithEvents cboOpenWOrders As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnCloseWO As System.Windows.Forms.Button
        Friend WithEvents rbtnByBox As System.Windows.Forms.RadioButton
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblWOReceivedQty As System.Windows.Forms.Label
        Friend WithEvents dbgRecUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpProdReceiving As System.Windows.Forms.TabPage
        Friend WithEvents tpReceivedData As System.Windows.Forms.TabPage
        Friend WithEvents btnRefreshRecData As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtBoxID As System.Windows.Forms.TextBox
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblBoxCount As System.Windows.Forms.Label
        Friend WithEvents lblScanQty As System.Windows.Forms.Label
        Friend WithEvents pnSNs As System.Windows.Forms.Panel
        Friend WithEvents rbtnBySNsInBox As System.Windows.Forms.RadioButton
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents rbtnBySNs As System.Windows.Forms.RadioButton
        Friend WithEvents pnBox As System.Windows.Forms.Panel
        Friend WithEvents btnReceive As System.Windows.Forms.Button
        Friend WithEvents lstPartialBox As System.Windows.Forms.ListBox
        Friend WithEvents lstBox As System.Windows.Forms.ListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAquisProdRec))
            Me.cboOpenWOrders = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnCloseWO = New System.Windows.Forms.Button()
            Me.rbtnByBox = New System.Windows.Forms.RadioButton()
            Me.rbtnBySNsInBox = New System.Windows.Forms.RadioButton()
            Me.txtBoxID = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lstPartialBox = New System.Windows.Forms.ListBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblWOReceivedQty = New System.Windows.Forms.Label()
            Me.btnRefreshRecData = New System.Windows.Forms.Button()
            Me.dbgRecUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReceive = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpProdReceiving = New System.Windows.Forms.TabPage()
            Me.pnBox = New System.Windows.Forms.Panel()
            Me.lstBox = New System.Windows.Forms.ListBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblBoxCount = New System.Windows.Forms.Label()
            Me.pnSNs = New System.Windows.Forms.Panel()
            Me.lblScanQty = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rbtnBySNs = New System.Windows.Forms.RadioButton()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.tpReceivedData = New System.Windows.Forms.TabPage()
            CType(Me.cboOpenWOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpProdReceiving.SuspendLayout()
            Me.pnBox.SuspendLayout()
            Me.pnSNs.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.tpReceivedData.SuspendLayout()
            Me.SuspendLayout()
            '
            'cboOpenWOrders
            '
            Me.cboOpenWOrders.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenWOrders.AutoCompletion = True
            Me.cboOpenWOrders.AutoDropDown = True
            Me.cboOpenWOrders.AutoSelect = True
            Me.cboOpenWOrders.Caption = ""
            Me.cboOpenWOrders.CaptionHeight = 17
            Me.cboOpenWOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenWOrders.ColumnCaptionHeight = 17
            Me.cboOpenWOrders.ColumnFooterHeight = 17
            Me.cboOpenWOrders.ColumnHeaders = False
            Me.cboOpenWOrders.ContentHeight = 15
            Me.cboOpenWOrders.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenWOrders.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenWOrders.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenWOrders.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenWOrders.EditorHeight = 15
            Me.cboOpenWOrders.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboOpenWOrders.ItemHeight = 15
            Me.cboOpenWOrders.Location = New System.Drawing.Point(8, 24)
            Me.cboOpenWOrders.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenWOrders.MaxDropDownItems = CType(10, Short)
            Me.cboOpenWOrders.MaxLength = 32767
            Me.cboOpenWOrders.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenWOrders.Name = "cboOpenWOrders"
            Me.cboOpenWOrders.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenWOrders.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenWOrders.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenWOrders.Size = New System.Drawing.Size(288, 21)
            Me.cboOpenWOrders.TabIndex = 1
            Me.cboOpenWOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(8, 0)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(168, 21)
            Me.Label5.TabIndex = 85
            Me.Label5.Text = "Open Work Order # "
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnCloseWO
            '
            Me.btnCloseWO.BackColor = System.Drawing.Color.Navy
            Me.btnCloseWO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWO.ForeColor = System.Drawing.Color.White
            Me.btnCloseWO.Location = New System.Drawing.Point(328, 24)
            Me.btnCloseWO.Name = "btnCloseWO"
            Me.btnCloseWO.Size = New System.Drawing.Size(128, 24)
            Me.btnCloseWO.TabIndex = 5
            Me.btnCloseWO.Text = "Close Work Order"
            '
            'rbtnByBox
            '
            Me.rbtnByBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnByBox.ForeColor = System.Drawing.Color.White
            Me.rbtnByBox.Location = New System.Drawing.Point(16, 21)
            Me.rbtnByBox.Name = "rbtnByBox"
            Me.rbtnByBox.Size = New System.Drawing.Size(72, 24)
            Me.rbtnByBox.TabIndex = 1
            Me.rbtnByBox.Text = "By Box"
            '
            'rbtnBySNsInBox
            '
            Me.rbtnBySNsInBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnBySNsInBox.ForeColor = System.Drawing.Color.White
            Me.rbtnBySNsInBox.Location = New System.Drawing.Point(152, 21)
            Me.rbtnBySNsInBox.Name = "rbtnBySNsInBox"
            Me.rbtnBySNsInBox.Size = New System.Drawing.Size(176, 24)
            Me.rbtnBySNsInBox.TabIndex = 2
            Me.rbtnBySNsInBox.Text = "By Serial Number in Box"
            '
            'txtBoxID
            '
            Me.txtBoxID.Location = New System.Drawing.Point(8, 24)
            Me.txtBoxID.Name = "txtBoxID"
            Me.txtBoxID.Size = New System.Drawing.Size(192, 20)
            Me.txtBoxID.TabIndex = 1
            Me.txtBoxID.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(208, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 98
            Me.Label3.Text = "Box Qty "
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lstPartialBox
            '
            Me.lstPartialBox.Location = New System.Drawing.Point(8, 48)
            Me.lstPartialBox.Name = "lstPartialBox"
            Me.lstPartialBox.Size = New System.Drawing.Size(192, 238)
            Me.lstPartialBox.TabIndex = 3
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(-8, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(144, 16)
            Me.Label2.TabIndex = 100
            Me.Label2.Text = "Received Quantity : "
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWOReceivedQty
            '
            Me.lblWOReceivedQty.BackColor = System.Drawing.Color.Transparent
            Me.lblWOReceivedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWOReceivedQty.ForeColor = System.Drawing.Color.White
            Me.lblWOReceivedQty.Location = New System.Drawing.Point(144, 56)
            Me.lblWOReceivedQty.Name = "lblWOReceivedQty"
            Me.lblWOReceivedQty.Size = New System.Drawing.Size(88, 16)
            Me.lblWOReceivedQty.TabIndex = 101
            Me.lblWOReceivedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnRefreshRecData
            '
            Me.btnRefreshRecData.BackColor = System.Drawing.Color.Navy
            Me.btnRefreshRecData.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshRecData.ForeColor = System.Drawing.Color.White
            Me.btnRefreshRecData.Location = New System.Drawing.Point(512, 24)
            Me.btnRefreshRecData.Name = "btnRefreshRecData"
            Me.btnRefreshRecData.Size = New System.Drawing.Size(160, 24)
            Me.btnRefreshRecData.TabIndex = 6
            Me.btnRefreshRecData.Text = "Refresh Received Data"
            '
            'dbgRecUnits
            '
            Me.dbgRecUnits.AllowUpdate = False
            Me.dbgRecUnits.AlternatingRows = True
            Me.dbgRecUnits.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgRecUnits.FilterBar = True
            Me.dbgRecUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRecUnits.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgRecUnits.Location = New System.Drawing.Point(8, 16)
            Me.dbgRecUnits.Name = "dbgRecUnits"
            Me.dbgRecUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRecUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRecUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgRecUnits.Size = New System.Drawing.Size(680, 344)
            Me.dbgRecUnits.TabIndex = 103
            Me.dbgRecUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "40</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 676, 340<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 676, 340</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnReceive
            '
            Me.btnReceive.BackColor = System.Drawing.Color.Green
            Me.btnReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceive.ForeColor = System.Drawing.Color.White
            Me.btnReceive.Location = New System.Drawing.Point(624, 312)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReceive.Size = New System.Drawing.Size(72, 40)
            Me.btnReceive.TabIndex = 4
            Me.btnReceive.Text = "Receive"
            Me.btnReceive.Visible = False
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpProdReceiving, Me.tpReceivedData})
            Me.TabControl1.Location = New System.Drawing.Point(8, 80)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(712, 408)
            Me.TabControl1.TabIndex = 104
            '
            'tpProdReceiving
            '
            Me.tpProdReceiving.BackColor = System.Drawing.Color.SteelBlue
            Me.tpProdReceiving.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnBox, Me.pnSNs, Me.GroupBox1, Me.btnReceive})
            Me.tpProdReceiving.Location = New System.Drawing.Point(4, 22)
            Me.tpProdReceiving.Name = "tpProdReceiving"
            Me.tpProdReceiving.Size = New System.Drawing.Size(704, 382)
            Me.tpProdReceiving.TabIndex = 0
            Me.tpProdReceiving.Text = "Production Receiving"
            '
            'pnBox
            '
            Me.pnBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstBox, Me.Label1, Me.txtBoxID, Me.Label3, Me.lblBoxCount})
            Me.pnBox.Location = New System.Drawing.Point(8, 64)
            Me.pnBox.Name = "pnBox"
            Me.pnBox.Size = New System.Drawing.Size(288, 304)
            Me.pnBox.TabIndex = 2
            Me.pnBox.Visible = False
            '
            'lstBox
            '
            Me.lstBox.Location = New System.Drawing.Point(8, 48)
            Me.lstBox.Name = "lstBox"
            Me.lstBox.Size = New System.Drawing.Size(192, 238)
            Me.lstBox.TabIndex = 5
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 16)
            Me.Label1.TabIndex = 101
            Me.Label1.Text = "Box ID "
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblBoxCount
            '
            Me.lblBoxCount.BackColor = System.Drawing.Color.Black
            Me.lblBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxCount.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxCount.Location = New System.Drawing.Point(208, 24)
            Me.lblBoxCount.Name = "lblBoxCount"
            Me.lblBoxCount.Size = New System.Drawing.Size(80, 32)
            Me.lblBoxCount.TabIndex = 99
            Me.lblBoxCount.Text = "0"
            Me.lblBoxCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pnSNs
            '
            Me.pnSNs.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblScanQty, Me.Label7, Me.txtSN, Me.Label4, Me.lstPartialBox})
            Me.pnSNs.Location = New System.Drawing.Point(320, 64)
            Me.pnSNs.Name = "pnSNs"
            Me.pnSNs.Size = New System.Drawing.Size(296, 304)
            Me.pnSNs.TabIndex = 3
            Me.pnSNs.Visible = False
            '
            'lblScanQty
            '
            Me.lblScanQty.BackColor = System.Drawing.Color.Black
            Me.lblScanQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScanQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanQty.ForeColor = System.Drawing.Color.Lime
            Me.lblScanQty.Location = New System.Drawing.Point(216, 24)
            Me.lblScanQty.Name = "lblScanQty"
            Me.lblScanQty.Size = New System.Drawing.Size(80, 32)
            Me.lblScanQty.TabIndex = 105
            Me.lblScanQty.Text = "0"
            Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(216, 8)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(80, 16)
            Me.Label7.TabIndex = 104
            Me.Label7.Text = "Scan Qty"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(8, 24)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(192, 20)
            Me.txtSN.TabIndex = 1
            Me.txtSN.Text = ""
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 8)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(40, 16)
            Me.Label4.TabIndex = 103
            Me.Label4.Text = "SN "
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.SteelBlue
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnBySNs, Me.rbtnBySNsInBox, Me.rbtnByBox, Me.btnCancel})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(688, 56)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Receiving Devices To Production"
            '
            'rbtnBySNs
            '
            Me.rbtnBySNs.Enabled = False
            Me.rbtnBySNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnBySNs.ForeColor = System.Drawing.Color.White
            Me.rbtnBySNs.Location = New System.Drawing.Point(376, 20)
            Me.rbtnBySNs.Name = "rbtnBySNs"
            Me.rbtnBySNs.Size = New System.Drawing.Size(176, 24)
            Me.rbtnBySNs.TabIndex = 3
            Me.rbtnBySNs.Text = "By Serial Number"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(608, 16)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCancel.Size = New System.Drawing.Size(72, 32)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "Cancel"
            '
            'tpReceivedData
            '
            Me.tpReceivedData.BackColor = System.Drawing.Color.SteelBlue
            Me.tpReceivedData.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgRecUnits})
            Me.tpReceivedData.Location = New System.Drawing.Point(4, 22)
            Me.tpReceivedData.Name = "tpReceivedData"
            Me.tpReceivedData.Size = New System.Drawing.Size(704, 382)
            Me.tpReceivedData.TabIndex = 1
            Me.tpReceivedData.Text = "Received Data"
            '
            'frmAquisProdRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(744, 502)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.lblWOReceivedQty, Me.Label2, Me.btnCloseWO, Me.cboOpenWOrders, Me.Label5, Me.btnRefreshRecData})
            Me.Name = "frmAquisProdRec"
            Me.Text = "frmAquisProdRec"
            CType(Me.cboOpenWOrders, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpProdReceiving.ResumeLayout(False)
            Me.pnBox.ResumeLayout(False)
            Me.pnSNs.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.tpReceivedData.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************************************************
        Private Sub btnRefreshRecData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshRecData.Click
            Try
                Me.dbgRecUnits.DataSource = Nothing
                If Me.cboOpenWOrders.SelectedValue > 0 Then
                    PopulateReceivedUnits(Me.cboOpenWOrders.SelectedValue)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshRecData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub PopulateReceivedUnits(ByVal iWOID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objProdRec.GetReceivedDeviceInWO(iWOID, False, True)
                dt.Columns("Device_SN").ColumnName = "SN"
                dt.AcceptChanges()

                With Me.dbgRecUnits
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Cnt").Width = 55
                    .Splits(0).DisplayColumns("SN").Width = 150
                    .Splits(0).DisplayColumns("Model").Width = 200
                    ' .Splits(0).DisplayColumns("S/N").Width = 120
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub frmAquisProdRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)

                '*********************************
                'Load Open Order & Box Type
                '*********************************
                Me.LoadOpenWorkOrder()
                Me.cboOpenWOrders.SelectAll() : Me.cboOpenWOrders.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub ClearCtrls()
            Try
                Me.lstBox.DataSource = Nothing : Me.lstBox.Items.Clear() : Me.lstBox.Refresh()
                Me.lstPartialBox.DataSource = Nothing : Me.lstPartialBox.Items.Clear() : Me.lstPartialBox.Refresh()
                Me.txtBoxID.Text = "" : Me.txtBoxID.Enabled = True : Me.txtBoxID.Tag = 0
                Me.lblBoxCount.Text = "0"
                Me.txtSN.Text = ""
                Me.lblScanQty.Text = "0"
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearCtrlVar", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub LoadOpenWorkOrder()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Me._objProdRec.GetOpenWorkordersList(Buisness.Messaging.Aquis_Loc_ID, False)
                dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Misc.PopulateC1DropDownList(Me.cboOpenWOrders, dt, "WO_CustWO", "WO_ID")
                Me.cboOpenWOrders.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub cboOpenWOrders_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenWOrders.RowChange
            Dim dt As DataTable

            Try
                Me.ClearCtrls() : Me.lblWOReceivedQty.Text = "" : _iTrayID = 0

                If Me.cboOpenWOrders.SelectedValue > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.lblWOReceivedQty.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboOpenWOrders.SelectedValue)
                    Me._iTrayID = Me._objProdRec.GetTrayID(Me.cboOpenWOrders.SelectedValue)
                    Me.Enabled = True : Me.txtBoxID.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenWOrders_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub rbtns_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnByBox.CheckedChanged, rbtnBySNsInBox.CheckedChanged, rbtnBySNs.CheckedChanged
            Try
                Me.ClearCtrls()
                If sender.name = "rbtnByBox" And Me.rbtnByBox.Checked = True Then
                    Me.pnBox.Visible = True
                    Me.pnSNs.Visible = False
                    Me.btnReceive.Visible = True
                    Me.txtBoxID.Focus()
                ElseIf sender.name = "rbtnBySNsInBox" Then
                    Me.pnBox.Visible = True
                    Me.pnSNs.Visible = True
                    Me.lstPartialBox.Visible = True
                    Me.btnReceive.Visible = True
                    Me.txtBoxID.Focus()
                ElseIf sender.name = "rbtnBySNs" Then
                    Me.pnBox.Visible = False
                    Me.pnSNs.Visible = True
                    Me.lstPartialBox.Visible = False
                    Me.btnReceive.Visible = False
                    Me.txtSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtns_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub txtBoxID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxID.KeyUp
            Dim dt As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtBoxID.Text.Trim.Length > 0 Then
                        If Me.cboOpenWOrders.SelectedValue = 0 Then
                            MessageBox.Show("Please select work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboOpenWOrders.SelectAll() : Me.cboOpenWOrders.Focus()
                        Else
                            dt = Me._objAquisProdRec.GetWarehouseItemByBoxName(Me.txtBoxID.Text.Trim)
                            If dt.Rows.Count = 0 Then
                                MessageBox.Show("Box does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                            ElseIf dt.Rows(0)("Closed").ToString = "0" Then
                                MessageBox.Show("Box is open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                            Else
                                Me.lstBox.DataSource = dt.DefaultView
                                Me.lstBox.DisplayMember = "Serial"
                                Me.lstBox.ValueMember = "WI_ID"
                                Me.txtBoxID.Tag = dt.Rows(0)("WB_ID")
                                Me.lblBoxCount.Text = Me.lstBox.Items.Count
                                Me.txtBoxID.Enabled = False
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtns_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtSN.Text.Trim.Length > 0 Then
                        If Me.rbtnByBox.Checked = True Then
                            MessageBox.Show("Receive device by box does not need SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf Me.rbtnBySNsInBox.Checked = True Then
                            Me.ProcessSNInBox(Me.txtSN.Text.Trim)
                        ElseIf Me.rbtnBySNs.Checked = True Then
                            Me.ProcessSN(Me.txtSN.Text.Trim)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************************************************
        Private Function ProcessSNInBox(ByVal strSN As String) As Boolean
            Dim dt As DataTable
            Dim drNewRow, R1 As DataRow
            Dim i As Integer = 0

            Try
                If Me.txtBoxID.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter box name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxID.Text = "" : Me.txtSN.SelectAll() : Me.txtBoxID.Focus()
                ElseIf Me.txtBoxID.Tag = 0 Then
                    MessageBox.Show("Box ID is missing. Please re-enter box name again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxID.Enabled = True : Me.txtSN.Text = "" : Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                Else
                    dt = Me._objAquisProdRec.GetWarehouseItemBySN(strSN)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Serial number  '" & strSN & "' does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate serial number '" & strSN & "'.  Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    ElseIf dt.Rows(0)("WB_ID").ToString.Trim = "0" Or dt.Rows(0)("WB_ID").ToString.Trim.Length = 0 Then
                        MessageBox.Show("This device does not belong to any box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    ElseIf dt.Rows(0)("WB_ID").ToString.Trim <> Me.txtBoxID.Tag.ToString.Trim Then
                        MessageBox.Show("Serial number does not belong to the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    ElseIf Not IsNothing(Me.lstPartialBox.DataSource) AndAlso Me.lstPartialBox.DataSource.table.select("Serial = '" & strSN.Trim & "'").length > 0 Then
                        '***************************************************
                        'Check if the Device is already scanned in
                        '***************************************************
                        MessageBox.Show("This device is already listed. Try another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    Else
                        If IsNothing(Me.lstPartialBox.DataSource) Then
                            Me.lstPartialBox.DataSource = dt.DefaultView
                            Me.lstPartialBox.DisplayMember = "Serial"
                            Me.lstPartialBox.ValueMember = "WI_ID"
                        Else
                            drNewRow = Me.lstPartialBox.DataSource.Table.NewRow
                            For i = 0 To dt.Columns.Count - 1
                                drNewRow(i) = dt.Rows(0)(i)
                            Next i
                            Me.lstPartialBox.DataSource.Table.Rows.Add(drNewRow)
                            Me.lstPartialBox.DataSource.Table.AcceptChanges()
                            Me.lstPartialBox.Refresh()
                            Me.txtSN.Text = ""
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtns_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************
        Private Function ProcessSN(ByVal strSN As String) As Boolean

            ' ZF added and need to work on it more
            Dim dt As DataTable
            Dim drNewRow, R1 As DataRow
            Dim i As Integer = 0

            Try
                If Me.txtBoxID.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter box name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxID.Text = "" : Me.txtSN.SelectAll() : Me.txtBoxID.Focus()
                ElseIf Me.txtBoxID.Tag = 0 Then
                    MessageBox.Show("Box ID is missing. Please re-enter box name again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxID.Enabled = True : Me.txtSN.Text = "" : Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                Else
                    dt = Me._objAquisProdRec.GetWarehouseItemBySN(strSN)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Serial number  '" & strSN & "' does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate serial number '" & strSN & "'.  Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    ElseIf dt.Rows(0)("WB_ID").ToString.Trim = "0" Or dt.Rows(0)("WB_ID").ToString.Trim Then
                        MessageBox.Show("This device does not belong to any box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    ElseIf dt.Rows(0)("WB_ID").ToString.Trim <> Me.txtBoxID.Tag.ToString.Trim Then
                        MessageBox.Show("Serial number does not belong to the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    ElseIf Not IsNothing(Me.lstPartialBox.DataSource) AndAlso Me.lstPartialBox.DataSource.table.select("Serial = '" & strSN.Trim & "'").length > 0 Then
                        '***************************************************
                        'Check if the Device is already scanned in
                        '***************************************************
                        MessageBox.Show("This device is already listed. Try another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = "" : Me.txtSN.Focus()
                    Else
                        If IsNothing(Me.lstPartialBox.DataSource) Then
                            Me.lstPartialBox.DataSource = dt.DefaultView
                            Me.lstPartialBox.DisplayMember = "Serial"
                            Me.lstPartialBox.ValueMember = "WI_ID"
                        Else
                            drNewRow = Me.lstPartialBox.DataSource.Table.NewRow
                            For i = 0 To dt.Columns.Count - 1
                                drNewRow(i) = dt.Rows(0)(i)
                            Next i
                            Me.lstPartialBox.DataSource.Table.Rows.Add(drNewRow)
                            Me.lstPartialBox.DataSource.Table.AcceptChanges()
                            Me.lstPartialBox.Refresh()
                            Me.txtSN.Text = ""
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtns_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************
        Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
            Try
                If Me.rbtnByBox.Checked = True Then
                    If IsNothing(Me.lstBox.DataSource) OrElse Me.lstBox.Items.Count = 0 Then
                        MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxID.Enabled = True : Me.txtSN.Text = "" : Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                    Else
                        If Me.ProcessReceiveDevicesInBox(Me.lstBox.DataSource.Table) = True Then Me.txtBoxID.Focus()
                    End If
                ElseIf Me.rbtnBySNsInBox.Checked = True Then
                    If IsNothing(Me.lstPartialBox.DataSource) OrElse Me.lstPartialBox.Items.Count = 0 Then
                        MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxID.Enabled = True : Me.txtSN.Text = "" : Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                    Else
                        Me.ProcessReceiveDevicesInBox(Me.lstPartialBox.DataSource.Table)
                        Me.txtBoxID.Focus()
                    End If
                ElseIf Me.rbtnBySNs.Checked = True Then


                Else
                    MessageBox.Show("Please select receive type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************************************************
        Private Function ProcessReceiveDevicesInBox(ByVal dt As DataTable) As Boolean
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strSku, strWorkDate, strWarehouseItemIDs, strHasDeviceIDSNsList, strSNs As String
            Dim iBaudID, iCnt, iDeviceID, i As Integer

            Try
                If Me.cboOpenWOrders.SelectedValue = 0 Then
                    MessageBox.Show("Please select work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenWOrders.SelectAll() : Me.cboOpenWOrders.Focus()
                ElseIf Me.txtBoxID.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter box name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                ElseIf Me.txtBoxID.Tag.ToString().Trim = "0" Then
                    MessageBox.Show("Box ID is missing. Please re-enter box name again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxID.Enabled = True : Me.txtSN.Text = "" : Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                ElseIf dt.Rows.Count = 0 Then
                    MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxID.Enabled = True : Me.txtSN.Text = "" : Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    strWorkDate = "" : strWarehouseItemIDs = "" : strHasDeviceIDSNsList = "" : strSNs = String.Empty
                    iCnt = 0 : iDeviceID = 0 : i = 0

                    '**************************************
                    'Validate item in box
                    '**************************************
                    For Each R1 In dt.Rows
                        If strWarehouseItemIDs.Trim.Length > 0 Then strWarehouseItemIDs &= ", "
                        strWarehouseItemIDs &= R1("WI_ID")
                        If strSNs.Trim.Length > 0 Then strSNs &= ", "
                        strSNs &= "'" & R1("Serial") & "'"
                    Next R1
                    'Check item table
                    dt1 = Me._objAquisProdRec.GetItemsHasDeviceID(strWarehouseItemIDs)
                    If dt1.Rows.Count > 0 Then
                        For Each R1 In dt1.Rows
                            strHasDeviceIDSNsList &= R1("Serial") & Environment.NewLine
                        Next R1
                    End If
                    If strHasDeviceIDSNsList.Trim.Length > 0 Then
                        MessageBox.Show("The following Serial number(s) have already moved to production:" & Environment.NewLine & strHasDeviceIDSNsList & "Please refresh the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return False
                    End If
                    'check existing of SN in WIP
                    Buisness.Generic.DisposeDT(dt1)
                    dt1 = Me._objAquisProdRec.GetDevicesInWip(Buisness.Messaging.Aquis_Loc_ID, strSNs)
                    strSNs = ""
                    If dt1.Rows.Count > 0 Then
                        For Each R1 In dt1.Rows
                            strSNs &= R1("Device_SN") & Environment.NewLine
                        Next R1
                    End If
                    If strSNs.Trim.Length > 0 Then
                        MessageBox.Show("The following Serial number(s) existed in WIP:" & Environment.NewLine & strSNs & "Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Return False
                    End If
                    '**************************************

                    strWorkDate = Buisness.Generic.GetWorkDate(ApplicationUser.IDShift)

                    For Each R1 In dt.Rows
                        ' Hung Nguyen 10/28/2011 update correct SKU which required in Pager Tester application 
                        iBaudID = R1("BaudRate_ID")
                        Select Case iBaudID
                            Case 1  'POCSAG 512
                                strSku = "XXFXXXXXXX"
                            Case 2  'POCSAG 1200
                                strSku = "XXTXXXXXXX"
                            Case 3  'POCSAG 2400
                                strSku = "XX4XXXXXXX"
                            Case 4  'FLEX
                                strSku = "XXXXXXFLXX"
                            Case Else
                                Throw New Exception("System can not define sku length for the unit serial#" & R1("Serial") & " . Please contact your supervisor or IT immediately...")
                        End Select

                        iCnt = Me._objProdRec.GetNextDeviceCountInTray(Me._iTrayID) ' _iTrayID is assiged when selecting work order

                        iDeviceID = Me._objProdRec.InsertIntoTdevice(R1("Serial"), strWorkDate, iCnt, _
                                                                     _iTrayID, _
                                                                     Buisness.Messaging.Aquis_Loc_ID, _
                                                                     Me.cboOpenWOrders.SelectedValue, _
                                                                     R1("Model_ID"), _
                                                                     ApplicationUser.IDShift, 0, 0, , , )
                        If iDeviceID = 0 Then Throw New Exception("System has failed to insert data into tdevice.")

                        i = Me._objProdRec.InsertIntoTmessdata(Me.cboOpenWOrders.SelectedValue, _
                                                               iDeviceID, R1("Cap_Code"), strSku, _
                                                               R1("BaudRate_ID"), R1("Freq_ID"), 0)
                        If i = 0 Then Throw New Exception("System has failed to write data into messaging table.")

                        i = Me._objAquisProdRec.UpdateDeviceIDOfITem(R1("WI_ID"), iDeviceID)
                        If i = 0 Then Throw New Exception("System has failed to update Device ID in warehouse item table.")
                    Next R1

                    Me.ClearCtrls()
                    Me.lblWOReceivedQty.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboOpenWOrders.SelectedValue)

                    Return True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Buisness.Generic.DisposeDT(dt)
                Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '*********************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me.lstBox.DataSource = Nothing : Me.lstBox.Items.Clear() : Me.lstBox.Refresh()
                Me.lstPartialBox.DataSource = Nothing : Me.lstPartialBox.Items.Clear() : Me.lstPartialBox.Refresh()
                Me.txtBoxID.Text = "" : Me.txtBoxID.Tag = 0 : Me.txtBoxID.Enabled = True
                Me.lblBoxCount.Text = "0"
                Me.txtSN.Text = ""
                Me.lblScanQty.Text = "0"

                If Me.rbtnByBox.Checked = True Or Me.rbtnBySNsInBox.Checked = True Then
                    Me.txtBoxID.Focus()
                ElseIf Me.rbtnBySNs.Checked = True Then
                    Me.txtSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub btnCloseWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseWO.Click
            Dim R1 As DataRow
            Dim i, iRecUnitCnt As Integer

            Try
                If Me.cboOpenWOrders.SelectedValue = 0 Then Exit Sub

                R1 = Me._objProdRec.GetWorkorderInfo(Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex).ToString.Trim, , Buisness.Messaging.Aquis_Loc_ID)
                i = 0 : iRecUnitCnt = 0

                If IsNothing(R1) Then
                    MessageBox.Show("This Work Order # '" & Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex) & "' does not exist in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("WO_Closed") = 1 Then
                    MessageBox.Show("This Work Order # '" & Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex) & "' is already closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("WO_Shipped") = 1 Then
                    MessageBox.Show("This Work Order # '" & Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex) & "' has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iRecUnitCnt = PSS.Data.Buisness.Generic.GetRecQty(R1("WO_ID"))
                    If iRecUnitCnt = 0 Then
                        MessageBox.Show("This Work Order # '" & Me.cboOpenWOrders.Columns("WO_CustWO").CellValue(Me.cboOpenWOrders.SelectedIndex) & "' is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.CloseWO(R1("WO_ID"))
                        If i > 0 Then
                            Me.ClearCtrls() : Me.LoadOpenWorkOrder()
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            Me.cboOpenWOrders.SelectAll() : Me.cboOpenWOrders.Focus()
                            MessageBox.Show("Work Order is closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseWO_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*********************************************************************************************

    End Class
End Namespace