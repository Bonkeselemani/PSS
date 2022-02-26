Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone

    Public Class frmWHFillingOrder
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _objWH As PSS.Data.Buisness.TracFone.Warehouse
        Private _dtBoxes As DataTable
        Private _Cust_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal strScreenName As String = "", Optional ByVal iCustID As Integer = 0)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            If iCustID > 0 Then Me._Cust_ID = iCustID
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
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents cboOpenOrders As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents lblPODate As System.Windows.Forms.Label
        Friend WithEvents btnPrintAvailableBoxRpt As System.Windows.Forms.Button
        Friend WithEvents dbgAvailableBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnRemoveAllBoxes As System.Windows.Forms.Button
        Friend WithEvents btnRemoveOneBox As System.Windows.Forms.Button
        Friend WithEvents lblTotalQty As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtBoxWeight As System.Windows.Forms.TextBox
        Friend WithEvents cboOpenOrderTobeFilled As C1.Win.C1List.C1Combo
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnFillOrder As System.Windows.Forms.Button
        Friend WithEvents lstBoxes As System.Windows.Forms.ListBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents btnReprintPackingList As System.Windows.Forms.Button
        Friend WithEvents btnReprintBoxLabelTal As System.Windows.Forms.Button
        Friend WithEvents lblShipToAddr As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents btnRefreshList As System.Windows.Forms.Button
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents chkWHNTFBoxes As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWHFillingOrder))
            Me.dbgAvailableBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.chkWHNTFBoxes = New System.Windows.Forms.CheckBox()
            Me.btnRefreshList = New System.Windows.Forms.Button()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.btnPrintAvailableBoxRpt = New System.Windows.Forms.Button()
            Me.lblPODate = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cboOpenOrders = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnRemoveAllBoxes = New System.Windows.Forms.Button()
            Me.btnRemoveOneBox = New System.Windows.Forms.Button()
            Me.lblTotalQty = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblBoxQty = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtBoxWeight = New System.Windows.Forms.TextBox()
            Me.cboOpenOrderTobeFilled = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnFillOrder = New System.Windows.Forms.Button()
            Me.lstBoxes = New System.Windows.Forms.ListBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtBoxName = New System.Windows.Forms.TextBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblShipToAddr = New System.Windows.Forms.Label()
            Me.btnReprintBoxLabelTal = New System.Windows.Forms.Button()
            Me.btnReprintPackingList = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            CType(Me.dbgAvailableBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboOpenOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboOpenOrderTobeFilled, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'dbgAvailableBoxes
            '
            Me.dbgAvailableBoxes.AllowUpdate = False
            Me.dbgAvailableBoxes.AlternatingRows = True
            Me.dbgAvailableBoxes.FilterBar = True
            Me.dbgAvailableBoxes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgAvailableBoxes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgAvailableBoxes.Location = New System.Drawing.Point(9, 169)
            Me.dbgAvailableBoxes.Name = "dbgAvailableBoxes"
            Me.dbgAvailableBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgAvailableBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgAvailableBoxes.PreviewInfo.ZoomFactor = 75
            Me.dbgAvailableBoxes.Size = New System.Drawing.Size(519, 375)
            Me.dbgAvailableBoxes.TabIndex = 3
            Me.dbgAvailableBoxes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColor:Control;" & _
            "Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}FilterBar{Font" & _
            ":Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{" & _
            "}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColo" & _
            "r:ControlDark;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><" & _
            "C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" Name="""" AlternatingRowStyle=""True""" & _
            " CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""" & _
            "True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""1" & _
            "7"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>371</Height><Captio" & _
            "nStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /" & _
            "><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar""" & _
            " me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 515, 371</ClientRect><Borde" & _
            "rSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merge" & _
            "View></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal""" & _
            " me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me" & _
            "=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""" & _
            "Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""High" & _
            "lightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Odd" & _
            "Row"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""" & _
            "FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</v" & _
            "ertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17<" & _
            "/DefaultRecSelWidth><ClientArea>0, 0, 515, 371</ClientArea><PrintPageHeaderStyle" & _
            " parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>" & _
            ""
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkWHNTFBoxes, Me.btnRefreshList, Me.btnCopySelectedRows, Me.btnCopyAll, Me.btnPrintAvailableBoxRpt, Me.lblPODate, Me.Label4, Me.lblQty, Me.Label2, Me.lblModel, Me.Label8, Me.cboOpenOrders, Me.Label5})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(9, 0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(519, 169)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Open Orders"
            '
            'chkWHNTFBoxes
            '
            Me.chkWHNTFBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkWHNTFBoxes.Location = New System.Drawing.Point(16, 136)
            Me.chkWHNTFBoxes.Name = "chkWHNTFBoxes"
            Me.chkWHNTFBoxes.Size = New System.Drawing.Size(136, 24)
            Me.chkWHNTFBoxes.TabIndex = 118
            Me.chkWHNTFBoxes.Text = "All WH NTF Boxes"
            Me.ToolTip1.SetToolTip(Me.chkWHNTFBoxes, "All WH NTF Boxes if checked, otherwise, all produced NTF boxes")
            '
            'btnRefreshList
            '
            Me.btnRefreshList.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnRefreshList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshList.ForeColor = System.Drawing.Color.Black
            Me.btnRefreshList.Location = New System.Drawing.Point(168, 136)
            Me.btnRefreshList.Name = "btnRefreshList"
            Me.btnRefreshList.Size = New System.Drawing.Size(104, 24)
            Me.btnRefreshList.TabIndex = 117
            Me.btnRefreshList.Text = "Refresh List"
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.Black
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(360, 137)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(152, 24)
            Me.btnCopySelectedRows.TabIndex = 116
            Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.Black
            Me.btnCopyAll.Location = New System.Drawing.Point(280, 136)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(72, 24)
            Me.btnCopyAll.TabIndex = 115
            Me.btnCopyAll.Text = "Copy All"
            '
            'btnPrintAvailableBoxRpt
            '
            Me.btnPrintAvailableBoxRpt.BackColor = System.Drawing.Color.Green
            Me.btnPrintAvailableBoxRpt.Location = New System.Drawing.Point(464, 88)
            Me.btnPrintAvailableBoxRpt.Name = "btnPrintAvailableBoxRpt"
            Me.btnPrintAvailableBoxRpt.Size = New System.Drawing.Size(51, 16)
            Me.btnPrintAvailableBoxRpt.TabIndex = 2
            Me.btnPrintAvailableBoxRpt.Text = "Print Available Boxes"
            Me.btnPrintAvailableBoxRpt.Visible = False
            '
            'lblPODate
            '
            Me.lblPODate.BackColor = System.Drawing.Color.White
            Me.lblPODate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPODate.ForeColor = System.Drawing.Color.Blue
            Me.lblPODate.Location = New System.Drawing.Point(355, 94)
            Me.lblPODate.Name = "lblPODate"
            Me.lblPODate.Size = New System.Drawing.Size(94, 21)
            Me.lblPODate.TabIndex = 98
            Me.lblPODate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(243, 94)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 18)
            Me.Label4.TabIndex = 99
            Me.Label4.Text = "PO Date :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblQty
            '
            Me.lblQty.BackColor = System.Drawing.Color.White
            Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty.ForeColor = System.Drawing.Color.Blue
            Me.lblQty.Location = New System.Drawing.Point(141, 89)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(93, 22)
            Me.lblQty.TabIndex = 96
            Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(18, 89)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(123, 19)
            Me.Label2.TabIndex = 97
            Me.Label2.Text = "Quantity :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Blue
            Me.lblModel.Location = New System.Drawing.Point(141, 59)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(308, 21)
            Me.lblModel.TabIndex = 94
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(75, 57)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(66, 19)
            Me.Label8.TabIndex = 95
            Me.Label8.Text = "Model :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboOpenOrders
            '
            Me.cboOpenOrders.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenOrders.AutoCompletion = True
            Me.cboOpenOrders.AutoDropDown = True
            Me.cboOpenOrders.AutoSelect = True
            Me.cboOpenOrders.Caption = ""
            Me.cboOpenOrders.CaptionHeight = 17
            Me.cboOpenOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenOrders.ColumnCaptionHeight = 17
            Me.cboOpenOrders.ColumnFooterHeight = 17
            Me.cboOpenOrders.ColumnHeaders = False
            Me.cboOpenOrders.ContentHeight = 15
            Me.cboOpenOrders.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenOrders.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenOrders.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrders.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenOrders.EditorHeight = 15
            Me.cboOpenOrders.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboOpenOrders.ItemHeight = 15
            Me.cboOpenOrders.Location = New System.Drawing.Point(141, 28)
            Me.cboOpenOrders.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenOrders.MaxDropDownItems = CType(10, Short)
            Me.cboOpenOrders.MaxLength = 32767
            Me.cboOpenOrders.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenOrders.Name = "cboOpenOrders"
            Me.cboOpenOrders.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenOrders.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenOrders.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenOrders.Size = New System.Drawing.Size(308, 21)
            Me.cboOpenOrders.TabIndex = 1
            Me.cboOpenOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(9, 28)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(132, 18)
            Me.Label5.TabIndex = 92
            Me.Label5.Text = "Order Number :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRemoveAllBoxes
            '
            Me.btnRemoveAllBoxes.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllBoxes.Enabled = False
            Me.btnRemoveAllBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllBoxes.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllBoxes.Location = New System.Drawing.Point(8, 368)
            Me.btnRemoveAllBoxes.Name = "btnRemoveAllBoxes"
            Me.btnRemoveAllBoxes.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllBoxes.Size = New System.Drawing.Size(152, 32)
            Me.btnRemoveAllBoxes.TabIndex = 9
            Me.btnRemoveAllBoxes.Text = "REMOVE ALL BOXES"
            '
            'btnRemoveOneBox
            '
            Me.btnRemoveOneBox.BackColor = System.Drawing.Color.Red
            Me.btnRemoveOneBox.Enabled = False
            Me.btnRemoveOneBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveOneBox.ForeColor = System.Drawing.Color.White
            Me.btnRemoveOneBox.Location = New System.Drawing.Point(8, 320)
            Me.btnRemoveOneBox.Name = "btnRemoveOneBox"
            Me.btnRemoveOneBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveOneBox.Size = New System.Drawing.Size(152, 32)
            Me.btnRemoveOneBox.TabIndex = 8
            Me.btnRemoveOneBox.Text = "REMOVE ONE BOX"
            '
            'lblTotalQty
            '
            Me.lblTotalQty.BackColor = System.Drawing.Color.Black
            Me.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalQty.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalQty.Location = New System.Drawing.Point(32, 264)
            Me.lblTotalQty.Name = "lblTotalQty"
            Me.lblTotalQty.Size = New System.Drawing.Size(106, 41)
            Me.lblTotalQty.TabIndex = 111
            Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Lime
            Me.Label10.Location = New System.Drawing.Point(40, 241)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(89, 16)
            Me.Label10.TabIndex = 112
            Me.Label10.Text = "TOTAL"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblBoxQty
            '
            Me.lblBoxQty.BackColor = System.Drawing.Color.Black
            Me.lblBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxQty.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxQty.Location = New System.Drawing.Point(32, 192)
            Me.lblBoxQty.Name = "lblBoxQty"
            Me.lblBoxQty.Size = New System.Drawing.Size(106, 41)
            Me.lblBoxQty.TabIndex = 109
            Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Lime
            Me.Label7.Location = New System.Drawing.Point(40, 169)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(89, 16)
            Me.Label7.TabIndex = 110
            Me.Label7.Text = "BOX QTY"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(72, 114)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 19)
            Me.Label6.TabIndex = 108
            Me.Label6.Text = "Weight (LBs):"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBoxWeight
            '
            Me.txtBoxWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxWeight.Location = New System.Drawing.Point(168, 114)
            Me.txtBoxWeight.Name = "txtBoxWeight"
            Me.txtBoxWeight.Size = New System.Drawing.Size(224, 22)
            Me.txtBoxWeight.TabIndex = 4
            Me.txtBoxWeight.Text = ""
            '
            'cboOpenOrderTobeFilled
            '
            Me.cboOpenOrderTobeFilled.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenOrderTobeFilled.AutoCompletion = True
            Me.cboOpenOrderTobeFilled.AutoDropDown = True
            Me.cboOpenOrderTobeFilled.AutoSelect = True
            Me.cboOpenOrderTobeFilled.Caption = ""
            Me.cboOpenOrderTobeFilled.CaptionHeight = 17
            Me.cboOpenOrderTobeFilled.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenOrderTobeFilled.ColumnCaptionHeight = 17
            Me.cboOpenOrderTobeFilled.ColumnFooterHeight = 17
            Me.cboOpenOrderTobeFilled.ColumnHeaders = False
            Me.cboOpenOrderTobeFilled.ContentHeight = 15
            Me.cboOpenOrderTobeFilled.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenOrderTobeFilled.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenOrderTobeFilled.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrderTobeFilled.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenOrderTobeFilled.EditorHeight = 15
            Me.cboOpenOrderTobeFilled.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrderTobeFilled.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboOpenOrderTobeFilled.ItemHeight = 15
            Me.cboOpenOrderTobeFilled.Location = New System.Drawing.Point(168, 28)
            Me.cboOpenOrderTobeFilled.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenOrderTobeFilled.MaxDropDownItems = CType(10, Short)
            Me.cboOpenOrderTobeFilled.MaxLength = 32767
            Me.cboOpenOrderTobeFilled.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenOrderTobeFilled.Name = "cboOpenOrderTobeFilled"
            Me.cboOpenOrderTobeFilled.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenOrderTobeFilled.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenOrderTobeFilled.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenOrderTobeFilled.Size = New System.Drawing.Size(224, 21)
            Me.cboOpenOrderTobeFilled.TabIndex = 1
            Me.cboOpenOrderTobeFilled.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(8, 30)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(158, 19)
            Me.Label3.TabIndex = 105
            Me.Label3.Text = "Order Number :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnFillOrder
            '
            Me.btnFillOrder.BackColor = System.Drawing.Color.Green
            Me.btnFillOrder.Enabled = False
            Me.btnFillOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFillOrder.ForeColor = System.Drawing.Color.White
            Me.btnFillOrder.Location = New System.Drawing.Point(168, 500)
            Me.btnFillOrder.Name = "btnFillOrder"
            Me.btnFillOrder.Size = New System.Drawing.Size(224, 39)
            Me.btnFillOrder.TabIndex = 7
            Me.btnFillOrder.Text = "Fill Order with Selected Box"
            '
            'lstBoxes
            '
            Me.lstBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstBoxes.ItemHeight = 16
            Me.lstBoxes.Location = New System.Drawing.Point(168, 168)
            Me.lstBoxes.Name = "lstBoxes"
            Me.lstBoxes.Size = New System.Drawing.Size(224, 324)
            Me.lstBoxes.TabIndex = 6
            Me.lstBoxes.TabStop = False
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(112, 144)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(56, 18)
            Me.Label1.TabIndex = 101
            Me.Label1.Text = "Box ID:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBoxName
            '
            Me.txtBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxName.Location = New System.Drawing.Point(168, 144)
            Me.txtBoxName.Name = "txtBoxName"
            Me.txtBoxName.Size = New System.Drawing.Size(224, 22)
            Me.txtBoxName.TabIndex = 5
            Me.txtBoxName.Text = ""
            '
            'GroupBox2
            '
            Me.GroupBox2.BackColor = System.Drawing.Color.SteelBlue
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.lblShipToAddr, Me.btnReprintBoxLabelTal, Me.btnReprintPackingList, Me.btnReprintBoxLabel, Me.btnRemoveAllBoxes, Me.btnRemoveOneBox, Me.lblTotalQty, Me.Label10, Me.lblBoxQty, Me.Label7, Me.Label6, Me.txtBoxWeight, Me.cboOpenOrderTobeFilled, Me.Label3, Me.btnFillOrder, Me.lstBoxes, Me.Label1, Me.txtBoxName})
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(528, 0)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(400, 544)
            Me.GroupBox2.TabIndex = 2
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Fill Orders"
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(8, 56)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(152, 19)
            Me.Label9.TabIndex = 117
            Me.Label9.Text = "Ship To Address:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblShipToAddr
            '
            Me.lblShipToAddr.BackColor = System.Drawing.Color.Black
            Me.lblShipToAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipToAddr.ForeColor = System.Drawing.Color.Lime
            Me.lblShipToAddr.Location = New System.Drawing.Point(168, 56)
            Me.lblShipToAddr.Name = "lblShipToAddr"
            Me.lblShipToAddr.Size = New System.Drawing.Size(224, 56)
            Me.lblShipToAddr.TabIndex = 116
            '
            'btnReprintBoxLabelTal
            '
            Me.btnReprintBoxLabelTal.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabelTal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabelTal.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabelTal.Location = New System.Drawing.Point(8, 496)
            Me.btnReprintBoxLabelTal.Name = "btnReprintBoxLabelTal"
            Me.btnReprintBoxLabelTal.Size = New System.Drawing.Size(152, 32)
            Me.btnReprintBoxLabelTal.TabIndex = 115
            Me.btnReprintBoxLabelTal.Text = "REPRINT BOX LABEL (TAL)"
            Me.btnReprintBoxLabelTal.Visible = False
            '
            'btnReprintPackingList
            '
            Me.btnReprintPackingList.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintPackingList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintPackingList.ForeColor = System.Drawing.Color.Black
            Me.btnReprintPackingList.Location = New System.Drawing.Point(8, 456)
            Me.btnReprintPackingList.Name = "btnReprintPackingList"
            Me.btnReprintPackingList.Size = New System.Drawing.Size(152, 32)
            Me.btnReprintPackingList.TabIndex = 114
            Me.btnReprintPackingList.Text = "REPRINT PACKING LIST"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(8, 416)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(152, 32)
            Me.btnReprintBoxLabel.TabIndex = 113
            Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
            '
            'frmWHFillingOrder
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(936, 549)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.GroupBox1, Me.dbgAvailableBoxes})
            Me.Name = "frmWHFillingOrder"
            Me.Text = "Warehouse - Fill Open Orders"
            CType(Me.dbgAvailableBoxes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboOpenOrders, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboOpenOrderTobeFilled, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWHFillingOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)

                If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    Me.GroupBox1.Text = "WFM (TracFone): " & Me.GroupBox1.Text
                    Me.GroupBox2.Text = "WFM (TracFone): " & Me.GroupBox2.Text
                    Me.chkWHNTFBoxes.Checked = True : Me.chkWHNTFBoxes.Visible = True
                Else
                    Me.GroupBox1.Text = "TracFone: " & Me.GroupBox1.Text
                    Me.GroupBox2.Text = "TracFone: " & Me.GroupBox2.Text
                    Me.chkWHNTFBoxes.Checked = False : Me.chkWHNTFBoxes.Visible = False
                End If

                Me._dtBoxes = Me._objWH.GetBoxTemplate()

                With Me.lstBoxes
                    Me.lstBoxes.DataSource = Me._dtBoxes.DefaultView
                    Me.lstBoxes.ValueMember = Me._dtBoxes.Columns("Pallett_ID").ToString
                    Me.lstBoxes.DisplayMember = Me._dtBoxes.Columns("Pallett_Name").ToString
                End With

                Me.PopulateOpenOrder()
                Me.PopulateAvailableBox()
                Me.cboOpenOrders.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmWHFillingOrder_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PopulateOpenOrder()
            Dim dt As DataTable

            Try
                If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    dt = Me._objWH.GetTFOpenOrder(Me._Cust_ID)
                Else
                    dt = Me._objWH.GetTFOpenOrder()
                End If
                'dt = Me._objWH.GetTFOpenOrder()
                Misc.PopulateC1DropDownList(Me.cboOpenOrders, dt, "WO_CustWO", "WO_ID")
                Me.cboOpenOrders.SelectedValue = 0

                Misc.PopulateC1DropDownList(Me.cboOpenOrderTobeFilled, dt, "WO_CustWO", "WO_ID")
                Me.cboOpenOrderTobeFilled.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub PopulateAvailableBox()
            Dim dt As DataTable
            Dim i As Integer

            Try
                If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    dt = Me._objWH.GetWFMAvailableBox(, Me.chkWHNTFBoxes.Checked)
                Else
                    dt = Me._objWH.GetTFAvailableBox()
                End If
                'dt = Me._objWH.GetTFAvailableBox()
                With Me.dbgAvailableBoxes
                    'dt.DefaultView.Sort = "Box"
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

                        If dt.Columns(i).Caption = "Box" Then
                            .Splits(0).DisplayColumns(i).Width = 150
                            .Splits(0).DisplayColumns(i).Frozen = True
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption = "Model" Then
                            .Splits(0).DisplayColumns(i).Width = 100
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption = "Qty" Then
                            .Splits(0).DisplayColumns(i).Width = 40
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        ElseIf dt.Columns(i).Caption = "Box Type" Then
                            .Splits(0).DisplayColumns(i).Width = 105
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                            'ElseIf dt.Columns(i).Caption = "Wrty Claim Cnt" Then
                            '    .Splits(0).DisplayColumns(i).Width = 90
                            '    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        Else
                            .Splits(0).DisplayColumns(i).Visible = False
                        End If
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub cboOpenOrders_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenOrders.SelectedValueChanged
            Try
                If Me.cboOpenOrders.SelectedValue > 0 Then
                    Me.lblModel.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("VN_ItemNo")
                    Me.lblQty.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("OrderQty")
                    Me.lblPODate.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("PODate")

                    Me.btnPrintAvailableBoxRpt.Enabled = True
                    Me.cboOpenOrderTobeFilled.SelectedValue = Me.cboOpenOrders.SelectedValue

                    If Not IsNothing(Me.cboOpenOrderTobeFilled.SelectedValue) Then
                        Me.lblShipToAddr.Text = Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("Name").ToString & Environment.NewLine & Environment.NewLine
                        Me.lblShipToAddr.Text &= Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("Address1").ToString & Environment.NewLine & Environment.NewLine
                        Me.lblShipToAddr.Text &= Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("City").ToString & ", " & Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("State").ToString & " " & Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("Zip").ToString
                    End If
                Else
                    Me.lblShipToAddr.Text = ""
                    Me.lblQty.Text = ""
                    Me.lblModel.Text = ""
                    Me.lblPODate.Text = ""
                    Me.btnPrintAvailableBoxRpt.Enabled = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenOrders_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub cboOpenOrderTobeFilled_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOpenOrderTobeFilled.SelectedValueChanged
            Try
                Me.txtBoxWeight.Text = ""
                Me.txtBoxName.Text = ""
                Me.lblBoxQty.Text = "0"
                Me._dtBoxes.Clear()
                Me.lblTotalQty.Text = Me._dtBoxes.Rows.Count

                If Me.cboOpenOrderTobeFilled.SelectedValue > 0 Then
                    If Me._objWH.GetOrderFilledBoxCnt(Me.cboOpenOrderTobeFilled.SelectedValue) > 0 Then
                        MessageBox.Show("This order has some box assigned to it. Please contact IT immediately.", "Verify Partial Order", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If Not IsNothing(Me.cboOpenOrderTobeFilled.SelectedValue) Then
                            Me.cboOpenOrders.SelectedValue = Me.cboOpenOrderTobeFilled.SelectedValue
                            Me.lblModel.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("VN_ItemNo")
                            Me.lblQty.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("OrderQty")
                            Me.lblPODate.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("PODate")
                            Me.btnPrintAvailableBoxRpt.Enabled = True

                            If Not IsNothing(Me.cboOpenOrderTobeFilled.SelectedValue) Then
                                Me.lblShipToAddr.Text = Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("Name").ToString & Environment.NewLine & Environment.NewLine
                                Me.lblShipToAddr.Text &= Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("Address1").ToString & Environment.NewLine & Environment.NewLine
                                Me.lblShipToAddr.Text &= Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("City").ToString & ", " & Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("State").ToString & " " & Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("Zip").ToString
                            End If
                        Else
                            Me.cboOpenOrders.SelectedValue = 0
                            Me.lblModel.Text = ""
                            Me.lblQty.Text = ""
                            Me.lblPODate.Text = ""
                            Me.lblShipToAddr.Text = ""
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenOrderTobeFilled_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtBoxWeight_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBoxWeight.KeyPress
            If e.KeyChar.IsDigit(e.KeyChar) = False AndAlso e.KeyChar.IsControl(e.KeyChar) = False Then e.Handled = True
        End Sub

        Private Sub txtBoxWeight_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxWeight.KeyUp
            If e.KeyCode = Keys.Enter AndAlso Me.txtBoxWeight.Text.Trim.Length > 0 Then Me.txtBoxName.Focus()
        End Sub

        Private Sub btnRemoveOneBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOneBox.Click
            Dim strBoxName As String = ""
            Dim R1 As DataRow

            Try
                If Me.lstBoxes.Items.Count = 0 Then
                    MessageBox.Show("The list is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strBoxName = InputBox("Please enter Box ID:", "Get Box").Trim

                    If strBoxName.Length = 0 Then
                        Exit Sub : Me.txtBoxName.Focus()
                    Else
                        If Me._dtBoxes.Select("Pallett_Name = '" & strBoxName & "' ").Length = 0 Then
                            MessageBox.Show("Box is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            R1 = Me._dtBoxes.Select("Pallett_Name = '" & strBoxName & "'")(0)
                            Me._dtBoxes.Rows.Remove(R1)
                            Me._dtBoxes.AcceptChanges()
                            Me.lstBoxes.Refresh()
                            If Me._dtBoxes.Rows.Count > 0 Then
                                Me.btnFillOrder.Enabled = True
                                Me.btnRemoveAllBoxes.Enabled = True
                                Me.btnRemoveOneBox.Enabled = True
                            Else
                                Me.btnFillOrder.Enabled = False
                                Me.btnRemoveAllBoxes.Enabled = False
                                Me.btnRemoveOneBox.Enabled = False
                            End If
                            Me.txtBoxName.Text = ""
                            Me.txtBoxWeight.Text = ""
                            Me.txtBoxWeight.Focus()

                            If Me._dtBoxes.Rows.Count > 0 Then
                                Me.lblBoxQty.Text = Me._dtBoxes.Rows(Me._dtBoxes.Rows.Count - 1)("Pallett_Qty")
                                Me.lblTotalQty.Text = Me._dtBoxes.Compute("Sum(Pallett_Qty)", "")
                            Else
                                Me.lblBoxQty.Text = 0
                                Me.lblTotalQty.Text = 0
                            End If

                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveOneBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                R1 = Nothing
            End Try
        End Sub

        Private Sub btnRemoveAllBoxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllBoxes.Click
            Try
                If MessageBox.Show("Are you sure you want to remove all boxes in the list.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Me.txtBoxName.Focus()
                    Exit Sub
                Else
                    Me.btnFillOrder.Enabled = False
                    Me.btnRemoveAllBoxes.Enabled = False
                    Me.btnRemoveOneBox.Enabled = False
                    Me._dtBoxes.Clear()
                    Me._dtBoxes.AcceptChanges()
                    Me.lstBoxes.Refresh()
                    Me.txtBoxName.Text = ""
                    Me.txtBoxWeight.Text = ""
                    Me.txtBoxWeight.Focus()

                    Me.lblBoxQty.Text = 0
                    Me.lblTotalQty.Text = 0
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAllBoxes_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtBoxName_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyUp
            Dim objPallet As PSS.Data.Buisness.TracFone.BuildShipPallet
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim _HasBc As Boolean = True
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtBoxName.Text.Trim.Length = 0 Then
                        Exit Sub
                    ElseIf Me.txtBoxWeight.Text.Trim.Length = 0 Then
                        MessageBox.Show("Please enter box weight.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.Text = ""
                        Me.txtBoxWeight.SelectAll()
                        Me.txtBoxWeight.Focus()
                    ElseIf Me._dtBoxes.Select("Pallett_Name = '" & Me.txtBoxName.Text.Trim & "'").Length > 0 Then
                        MessageBox.Show("Box is already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.SelectAll()
                        Me.txtBoxName.Focus()
                    Else
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor
                        objPallet = New PSS.Data.Buisness.TracFone.BuildShipPallet()
                        If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                            dt = objPallet.GetWFMPallet(Me.txtBoxName.Text.Trim)
                        Else
                            dt = objPallet.GetTracFonePallet(Me.txtBoxName.Text.Trim)
                            ' GET HAS BATTERY COVER FLAG.
                            _HasBc = IsBCRequired(dt.Rows(0)("model_id"))
                        End If
                        'dt = objPallet.GetTracFonePallet(Me.txtBoxName.Text.Trim)

                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Box ID does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Box ID exists more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                            MessageBox.Show("Box has not yet closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                            MessageBox.Show("Box has not yet completed in production.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf dt.Rows(0)("Model_ID") <> Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Model_ID") Then
                            MessageBox.Show("Model of Box and Order does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf (CInt(Me.lblTotalQty.Text) + dt.Rows(0)("Pallett_QTY")) > Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("OrderQty") Then
                            MessageBox.Show("Total devices of all the boxes have exceeded the quantity of order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) AndAlso dt.Rows(0)("pkslip_ID") > 0 Then
                            MessageBox.Show("This Box has already Manifest  with ID " & dt.Rows(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf Not IsDBNull(dt.Rows(0)("WO_ID")) AndAlso dt.Rows(0)("WO_ID") > 0 Then
                            MessageBox.Show("This Box has already assigned to order (" & dt.Rows(0)("WO_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf dt.Rows(0)("Manuf_ID") <> 53 AndAlso dt.Rows(0)("Manuf_ID") <> 220 AndAlso dt.Rows(0)("Pallett_QTY") <> Generic.GetPalletQty(dt.Rows(0)("Pallett_ID")) Then
                            MessageBox.Show("This Box quantity is different with device count. Please contact IT immediately.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf Me._Cust_ID <> PSS.Data.Buisness.WFM.CUSTOMER_ID AndAlso dt.Rows(0)("Cust_ID") <> PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                            MessageBox.Show("This Box does not belong to TracFone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID AndAlso dt.Rows(0)("Cust_ID") <> PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                            MessageBox.Show("This Box does not belong to WFM (TracFone).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf Me._Cust_ID <> PSS.Data.Buisness.WFM.CUSTOMER_ID AndAlso Me._objWH.GetNoneCageRBWSCount(dt.Rows(0)("Pallett_ID")) > 0 Then
                            MessageBox.Show("Box has not yet move from Production to WH-RB.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID AndAlso Me._objWH.GetNoneWHFloorCount(dt.Rows(0)("Pallett_ID")) > 0 Then
                            MessageBox.Show("Box has not yet move from Production to WH-FLOOR.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf dt.Rows(0)("Pallet_ShipType") = 10 AndAlso Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("IDCode").ToString <> "8396771500019" Then
                            MessageBox.Show("This box is functional failure return to BRIGHTSTAR but ship to address does not belong BRIGHTSTAR.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf dt.Rows(0)("Pallet_ShipType") = 11 AndAlso Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("IDCode").ToString <> "1100001003792" Then
                            MessageBox.Show("This box is functional failure return to COOPER GENERAL but ship to address does not belong COOPER GENERAL.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf dt.Rows(0)("Pallet_ShipType") > 0 AndAlso Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("VN_ItemNo").ToString.EndsWith("RB") Then
                            MessageBox.Show("This box is not a finished good product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf dt.Rows(0)("Pallet_ShipType") > 0 AndAlso (dt.Rows(0)("Model_Desc") & "X").ToString.ToLower <> Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("VN_ItemNo").ToString.ToLower Then
                            MessageBox.Show("Model of Box and Order does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        ElseIf Me._Cust_ID <> PSS.Data.Buisness.WFM.CUSTOMER_ID AndAlso _HasBc AndAlso dt.Rows(0)("Pallet_ShipType") = 0 AndAlso Me.HasBatteryCoverAssigned(dt.Rows(0)("Pallett_ID")) = False Then
                            Me.txtBoxName.SelectAll()
                        ElseIf Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID AndAlso Me.chkWHNTFBoxes.Checked AndAlso (dt.Rows(0).IsNull("WHLocation") OrElse Trim(dt.Rows(0).IsNull("WHLocation")).Length = 0) Then
                            MessageBox.Show("This produced box has not assigned a WH location. Not allowed to ship with current selection.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.SelectAll()
                        Else
                            Me.btnFillOrder.Enabled = True
                            Me.btnRemoveAllBoxes.Enabled = True
                            Me.btnRemoveOneBox.Enabled = True
                            R1 = Me._dtBoxes.NewRow
                            R1.BeginEdit()
                            R1("Pallett_ID") = dt.Rows(0)("Pallett_ID")
                            R1("Pallett_Name") = dt.Rows(0)("Pallett_Name")
                            R1("Pallett_Qty") = dt.Rows(0)("Pallett_Qty")
                            R1("Pallet_Weight") = CInt(Me.txtBoxWeight.Text)
                            R1("Manuf_ID") = dt.Rows(0)("Manuf_ID")
                            R1.EndEdit()
                            Me._dtBoxes.Rows.Add(R1)
                            Me._dtBoxes.AcceptChanges()
                            Me.lstBoxes.Refresh()
                            Me.lblBoxQty.Text = dt.Rows(0)("Pallett_Qty")
                            If Not IsDBNull(_dtBoxes.Compute("Sum(Pallett_Qty)", "")) Then Me.lblTotalQty.Text = _dtBoxes.Compute("Sum(Pallett_Qty)", "") Else Me.lblTotalQty.Text = "0"
                            Me.Enabled = True
                            Me.txtBoxName.Text = ""
                            Me.txtBoxName.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                R1 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub ProcessTracFoneBox()
            '    Dim objPallet As PSS.Data.Buisness.TracFone.BuildShipPallet
            '    Dim dt As DataTable
            '    Dim R1 As DataRow
            '    Dim _HasBc As Boolean = True
            '    Try
            '        If e.KeyCode = Keys.Enter Then
            '            If Me.txtBoxName.Text.Trim.Length = 0 Then
            '                Exit Sub
            '            ElseIf Me.txtBoxWeight.Text.Trim.Length = 0 Then
            '                MessageBox.Show("Please enter box weight.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                Me.txtBoxName.Text = ""
            '                Me.txtBoxWeight.SelectAll()
            '                Me.txtBoxWeight.Focus()
            '            ElseIf Me._dtBoxes.Select("Pallett_Name = '" & Me.txtBoxName.Text.Trim & "'").Length > 0 Then
            '                MessageBox.Show("Box is already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                Me.txtBoxName.SelectAll()
            '                Me.txtBoxName.Focus()
            '            Else
            '                Me.Enabled = False
            '                Cursor.Current = Cursors.WaitCursor
            '                objPallet = New PSS.Data.Buisness.TracFone.BuildShipPallet()
            '                dt = objPallet.GetTracFonePallet(Me.txtBoxName.Text.Trim)

            '                ' GET HAS BATTERY COVER FLAG.
            '                _HasBc = IsBCRequired(dt.Rows(0)("model_id"))

            '                If dt.Rows.Count = 0 Then
            '                    MessageBox.Show("Box ID does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows.Count > 1 Then
            '                    MessageBox.Show("Box ID exists more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
            '                    MessageBox.Show("Box has not yet closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
            '                    MessageBox.Show("Box has not yet completed in production.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Model_ID") <> Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Model_ID") Then
            '                    MessageBox.Show("Model of Box and Order does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf (CInt(Me.lblTotalQty.Text) + dt.Rows(0)("Pallett_QTY")) > Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("OrderQty") Then
            '                    MessageBox.Show("Total devices of all the boxes have exceeded the quantity of order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) AndAlso dt.Rows(0)("pkslip_ID") > 0 Then
            '                    MessageBox.Show("This Box has already Manifest  with ID " & dt.Rows(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf Not IsDBNull(dt.Rows(0)("WO_ID")) AndAlso dt.Rows(0)("WO_ID") > 0 Then
            '                    MessageBox.Show("This Box has already assigned to order (" & dt.Rows(0)("WO_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Manuf_ID") <> 53 AndAlso dt.Rows(0)("Pallett_QTY") <> Generic.GetPalletQty(dt.Rows(0)("Pallett_ID")) Then
            '                    MessageBox.Show("This Box quantity is different with device count. Please contact ID immediately.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Cust_ID") <> PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
            '                    MessageBox.Show("This Box does not belong to TracFone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf Me._objWH.GetNoneCageRBWSCount(dt.Rows(0)("Pallett_ID")) > 0 Then
            '                    MessageBox.Show("Box has not yet move from Production to WH-RB.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallet_ShipType") = 10 AndAlso Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("IDCode").ToString <> "8396771500019" Then
            '                    MessageBox.Show("This box is functional failure return to BRIGHTSTAR but ship to address does not belong BRIGHTSTAR.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallet_ShipType") = 11 AndAlso Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("IDCode").ToString <> "1100001003792" Then
            '                    MessageBox.Show("This box is functional failure return to COOPER GENERAL but ship to address does not belong COOPER GENERAL.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallet_ShipType") > 0 AndAlso Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("VN_ItemNo").ToString.EndsWith("RB") Then
            '                    MessageBox.Show("This box is not a finished good product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallet_ShipType") > 0 AndAlso (dt.Rows(0)("Model_Desc") & "X").ToString.ToLower <> Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("VN_ItemNo").ToString.ToLower Then
            '                    MessageBox.Show("Model of Box and Order does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf _HasBc AndAlso dt.Rows(0)("Pallet_ShipType") = 0 AndAlso Me.HasBatteryCoverAssigned(dt.Rows(0)("Pallett_ID")) = False Then
            '                    Me.txtBoxName.SelectAll()
            '                Else
            '                    Me.btnFillOrder.Enabled = True
            '                    Me.btnRemoveAllBoxes.Enabled = True
            '                    Me.btnRemoveOneBox.Enabled = True
            '                    R1 = Me._dtBoxes.NewRow
            '                    R1.BeginEdit()
            '                    R1("Pallett_ID") = dt.Rows(0)("Pallett_ID")
            '                    R1("Pallett_Name") = dt.Rows(0)("Pallett_Name")
            '                    R1("Pallett_Qty") = dt.Rows(0)("Pallett_Qty")
            '                    R1("Pallet_Weight") = CInt(Me.txtBoxWeight.Text)
            '                    R1("Manuf_ID") = dt.Rows(0)("Manuf_ID")
            '                    R1.EndEdit()
            '                    Me._dtBoxes.Rows.Add(R1)
            '                    Me._dtBoxes.AcceptChanges()
            '                    Me.lstBoxes.Refresh()
            '                    Me.lblBoxQty.Text = dt.Rows(0)("Pallett_Qty")
            '                    If Not IsDBNull(_dtBoxes.Compute("Sum(Pallett_Qty)", "")) Then Me.lblTotalQty.Text = _dtBoxes.Compute("Sum(Pallett_Qty)", "") Else Me.lblTotalQty.Text = "0"
            '                    Me.Enabled = True
            '                    Me.txtBoxName.Text = ""
            '                    Me.txtBoxName.Focus()
            '                End If
            '            End If
            '        End If
            '    Catch ex As Exception
            '        MessageBox.Show(ex.ToString, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Finally
            '        R1 = Nothing
            '        PSS.Data.Buisness.Generic.DisposeDT(dt)
            '        Me.Enabled = True
            '        Cursor.Current = Cursors.Default
            '    End Try
        End Sub

        Private Sub ProcessWFMBox()
            '    Dim objPallet As PSS.Data.Buisness.TracFone.BuildShipPallet
            '    Dim dt As DataTable
            '    Dim R1 As DataRow
            '    Dim _HasBc As Boolean = True
            '    Try
            '        If e.KeyCode = Keys.Enter Then
            '            If Me.txtBoxName.Text.Trim.Length = 0 Then
            '                Exit Sub
            '            ElseIf Me.txtBoxWeight.Text.Trim.Length = 0 Then
            '                MessageBox.Show("Please enter box weight.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                Me.txtBoxName.Text = ""
            '                Me.txtBoxWeight.SelectAll()
            '                Me.txtBoxWeight.Focus()
            '            ElseIf Me._dtBoxes.Select("Pallett_Name = '" & Me.txtBoxName.Text.Trim & "'").Length > 0 Then
            '                MessageBox.Show("Box is already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                Me.txtBoxName.SelectAll()
            '                Me.txtBoxName.Focus()
            '            Else
            '                Me.Enabled = False
            '                Cursor.Current = Cursors.WaitCursor
            '                objPallet = New PSS.Data.Buisness.TracFone.BuildShipPallet()
            '                dt = objPallet.GetWFMPallet(Me.txtBoxName.Text.Trim)

            '                ' GET HAS BATTERY COVER FLAG.
            '                '_HasBc = IsBCRequired(dt.Rows(0)("model_id"))

            '                If dt.Rows.Count = 0 Then
            '                    MessageBox.Show("Box ID does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows.Count > 1 Then
            '                    MessageBox.Show("Box ID exists more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
            '                    MessageBox.Show("Box has not yet closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
            '                    MessageBox.Show("Box has not yet completed in production.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Model_ID") <> Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Model_ID") Then
            '                    MessageBox.Show("Model of Box and Order does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf (CInt(Me.lblTotalQty.Text) + dt.Rows(0)("Pallett_QTY")) > Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("OrderQty") Then
            '                    MessageBox.Show("Total devices of all the boxes have exceeded the quantity of order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) AndAlso dt.Rows(0)("pkslip_ID") > 0 Then
            '                    MessageBox.Show("This Box has already Manifest  with ID " & dt.Rows(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf Not IsDBNull(dt.Rows(0)("WO_ID")) AndAlso dt.Rows(0)("WO_ID") > 0 Then
            '                    MessageBox.Show("This Box has already assigned to order (" & dt.Rows(0)("WO_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Manuf_ID") <> 53 AndAlso dt.Rows(0)("Pallett_QTY") <> Generic.GetPalletQty(dt.Rows(0)("Pallett_ID")) Then
            '                    MessageBox.Show("This Box quantity is different with device count. Please contact ID immediately.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Cust_ID") <> PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
            '                    MessageBox.Show("This Box does not belong to TracFone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf Me._objWH.GetNoneCageRBWSCount(dt.Rows(0)("Pallett_ID")) > 0 Then
            '                    MessageBox.Show("Box has not yet move from Production to WH-RB.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallet_ShipType") = 10 AndAlso Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("IDCode").ToString <> "8396771500019" Then
            '                    MessageBox.Show("This box is functional failure return to BRIGHTSTAR but ship to address does not belong BRIGHTSTAR.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallet_ShipType") = 11 AndAlso Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("IDCode").ToString <> "1100001003792" Then
            '                    MessageBox.Show("This box is functional failure return to COOPER GENERAL but ship to address does not belong COOPER GENERAL.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallet_ShipType") > 0 AndAlso Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("VN_ItemNo").ToString.EndsWith("RB") Then
            '                    MessageBox.Show("This box is not a finished good product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf dt.Rows(0)("Pallet_ShipType") > 0 AndAlso (dt.Rows(0)("Model_Desc") & "X").ToString.ToLower <> Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("VN_ItemNo").ToString.ToLower Then
            '                    MessageBox.Show("Model of Box and Order does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                    Me.txtBoxName.SelectAll()
            '                ElseIf _HasBc AndAlso dt.Rows(0)("Pallet_ShipType") = 0 AndAlso Me.HasBatteryCoverAssigned(dt.Rows(0)("Pallett_ID")) = False Then
            '                    Me.txtBoxName.SelectAll()
            '                Else
            '                    Me.btnFillOrder.Enabled = True
            '                    Me.btnRemoveAllBoxes.Enabled = True
            '                    Me.btnRemoveOneBox.Enabled = True
            '                    R1 = Me._dtBoxes.NewRow
            '                    R1.BeginEdit()
            '                    R1("Pallett_ID") = dt.Rows(0)("Pallett_ID")
            '                    R1("Pallett_Name") = dt.Rows(0)("Pallett_Name")
            '                    R1("Pallett_Qty") = dt.Rows(0)("Pallett_Qty")
            '                    R1("Pallet_Weight") = CInt(Me.txtBoxWeight.Text)
            '                    R1("Manuf_ID") = dt.Rows(0)("Manuf_ID")
            '                    R1.EndEdit()
            '                    Me._dtBoxes.Rows.Add(R1)
            '                    Me._dtBoxes.AcceptChanges()
            '                    Me.lstBoxes.Refresh()
            '                    Me.lblBoxQty.Text = dt.Rows(0)("Pallett_Qty")
            '                    If Not IsDBNull(_dtBoxes.Compute("Sum(Pallett_Qty)", "")) Then Me.lblTotalQty.Text = _dtBoxes.Compute("Sum(Pallett_Qty)", "") Else Me.lblTotalQty.Text = "0"
            '                    Me.Enabled = True
            '                    Me.txtBoxName.Text = ""
            '                    Me.txtBoxName.Focus()
            '                End If
            '            End If
            '        End If
            '    Catch ex As Exception
            '        MessageBox.Show(ex.ToString, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Finally
            '        R1 = Nothing
            '        PSS.Data.Buisness.Generic.DisposeDT(dt)
            '        Me.Enabled = True
            '        Cursor.Current = Cursors.Default
            '    End Try
        End Sub

        Private Function HasBatteryCoverAssigned(ByVal iPalletID As Integer) As Boolean
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim strNoBattSN As String = ""

            Try
                dt = Me._objWH.GetDeviceWithoutBatteryCover(iPalletID)
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        strNoBattSN &= dt.Rows(i)("Device_SN") & Environment.NewLine

                        If i > 2 Then
                            strNoBattSN &= "...." & Environment.NewLine
                            Exit For
                        End If
                    Next i

                    MessageBox.Show("No battery cover assigned to the following IMEI(s)" & Environment.NewLine & strNoBattSN, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        Private Sub btnFillOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFillOrder.Click
            Dim strBoxIDs As String = ""
            Dim R1 As DataRow
            Dim dt As DataTable
            Dim i As Integer = 0

            ' PROMPT THE USER TO MAKE SURE THEY WANT TO PROCEED.
            If MessageBox.Show("Fill the selected order now?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
                Exit Sub
            End If

            Try
                Me.Enabled = False

                If Me._dtBoxes.Rows.Count = 0 Then
                    MessageBox.Show("Please scan Box ID to fill open workorder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.Focus()
                ElseIf Me.cboOpenOrderTobeFilled.SelectedValue = 0 Then
                    MessageBox.Show("Please select workorder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenOrderTobeFilled.Focus()
                ElseIf IsNothing(Me._dtBoxes.Compute("Sum(Pallett_Qty)", "")) Then
                    MessageBox.Show("Quantity of boxes is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.Focus()
                ElseIf Me._dtBoxes.Compute("Sum(Pallett_Qty)", "") <> Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("OrderQty") Then
                    MessageBox.Show("Can not fill partial order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.Focus()
                Else
                    For Each R1 In Me._dtBoxes.Rows
                        If strBoxIDs.Trim.Length > 0 Then strBoxIDs &= ", "
                        strBoxIDs &= R1("Pallett_ID")
                    Next R1

                    dt = Me._objWH.GetPalletsInfo(strBoxIDs)

                    If dt.Select("Pallett_ShipDate is null").Length > 0 Then
                        MessageBox.Show("This Box (" & dt.Select("Pallett_ShipDate is null")(0)("Pallett_Name") & ") has not yet completed at production line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.Focus()
                    ElseIf dt.Select("Pallett_ReadyToShipFlg = 0").Length > 0 Then
                        MessageBox.Show("This Box (" & dt.Select("Pallett_ReadyToShipFlg = 0")(0)("Pallett_Name") & ") has not yet closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.Focus()
                    ElseIf dt.Select("pkslip_ID is not null AND pkslip_ID > 0").Length > 0 Then
                        MessageBox.Show("This Box (" & dt.Select("pkslip_ID > 0")(0)("Pallett_Name") & ") has already manifested.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.Focus()
                    ElseIf Me._Cust_ID <> PSS.Data.Buisness.WFM.CUSTOMER_ID AndAlso dt.Select("Cust_ID <> 2258").Length > 0 Then
                        MessageBox.Show("This Box (" & dt.Select("Cust_ID <> 2258")(0)("Pallett_Name") & ") does not belong to TracFone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.Focus()
                    ElseIf Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID AndAlso dt.Select("Cust_ID <> 2597").Length > 0 Then
                        MessageBox.Show("This Box (" & dt.Select("Cust_ID <> 2597")(0)("Pallett_Name") & ") does not belong to WFM(TracFone).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.Focus()
                    ElseIf dt.Select("WO_ID > 0").Length > 0 Then
                        MessageBox.Show("This Box (" & dt.Select("WO_ID > 0")(0)("Pallett_Name") & ") is not available for filling the selected order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.Focus()
                    Else
                        Cursor.Current = Cursors.WaitCursor
                        Try
                            If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                                i = Me._objWH.FillSaleOrder(Me._dtBoxes, Me.cboOpenOrders.SelectedValue, PSS.Core.ApplicationUser.IDuser, Me._Cust_ID)
                            Else
                                i = Me._objWH.FillSaleOrder(Me._dtBoxes, Me.cboOpenOrders.SelectedValue, PSS.Core.ApplicationUser.IDuser, 2258)
                            End If
                            'i = Me._objWH.FillSaleOrder(Me._dtBoxes, Me.cboOpenOrders.SelectedValue, PSS.Core.ApplicationUser.IDuser)
                        Catch ex As Exception
                            If ex.Message = "No data found while system try to print box label." Then
                                MessageBox.Show("Unable to print box label.  The order has still been filled.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                Throw ex
                            End If
                        End Try
                        Me._dtBoxes.Clear()
                        Me._dtBoxes.AcceptChanges()
                        Me.lstBoxes.Refresh()
                        Me.txtBoxWeight.Text = ""
                        Me.txtBoxName.Text = ""
                        Me.lblShipToAddr.Text = ""
                        Me.PopulateOpenOrder()
                        Me.PopulateAvailableBox()
                        Me.Enabled = True
                        Me.txtBoxWeight.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnFillOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub cboOpenOrderTobeFilled_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOpenOrderTobeFilled.KeyUp
            If e.KeyCode = Keys.Enter Then
                Me.lblShipToAddr.Text = ""
                If Me.cboOpenOrderTobeFilled.SelectedValue > 0 Then
                    Me.lblShipToAddr.Text = Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("Name").ToString & Environment.NewLine & Environment.NewLine
                    Me.lblShipToAddr.Text &= Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("Address1").ToString & Environment.NewLine & Environment.NewLine
                    Me.lblShipToAddr.Text &= Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("City").ToString & ", " & Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("State").ToString & " " & Me.cboOpenOrderTobeFilled.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("Zip").ToString
                    Me.txtBoxWeight.Focus()
                End If
            End If
        End Sub

        Private Sub btnReprintPackingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintPackingList.Click
            Dim str_pallett As String = ""
            Dim dtPallettInfo As DataTable
            Dim strPalletType As String = ""
            Dim iPalletQty As Integer = 0
            Dim R1 As DataRow
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim iTotalBoxInOrder As Integer = 0
            Try
                str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                objMisc = New PSS.Data.Buisness.Misc()
                If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett, Me._Cust_ID)
                Else
                    dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett, 2258)
                End If
                'dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)
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

                    If R1("WO_ID") = 0 Then
                        MessageBox.Show("Work order ID is missing.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    End If

                    If Not IsDBNull(R1("Cust_ID")) Then
                        iTotalBoxInOrder = Me._objWH.GetMaxBoxNoInOrder(R1("WO_ID"))
                        Me._objWH.PrintPackingListReport(R1("WO_ID"), iTotalBoxInOrder, R1("Cust_ID"))
                        'Me._objWH.PrintPackingListReport(R1("WO_ID"), iTotalBoxInOrder)
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
            End Try
        End Sub

        Private Sub btnReprintBoxLabelTal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click, btnReprintBoxLabelTal.Click
            Try
                If sender.name = "btnReprintBoxLabel" Then
                    Me.ReprintBoxLabel(False)
                Else
                    Me.ReprintBoxLabel(True)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Public Sub ReprintBoxLabel(ByVal booTalBarcode As Boolean)
            Dim str_pallett As String = ""
            Dim dtPallettInfo As DataTable
            Dim R1 As DataRow
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim iTotalBoxInOrder As Integer = 0
            Try
                str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                objMisc = New PSS.Data.Buisness.Misc()

                If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett, Me._Cust_ID)
                Else
                    dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett, 2258)
                End If
                'dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)

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

                    If R1("WO_ID") = 0 Then
                        MessageBox.Show("Work order ID is missing.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    End If
                    If Not IsDBNull(R1("Cust_ID")) Then
                        iTotalBoxInOrder = Me._objWH.GetMaxBoxNoInOrder(R1("WO_ID"))

                        Me._objWH.Print2DBarcodeBoxLabel(R1("Pallett_ID"), iTotalBoxInOrder, booTalBarcode, R1("Cust_ID"))
                        'Me._objWH.Print2DBarcodeBoxLabel(R1("Pallett_ID"), iTotalBoxInOrder, booTalBarcode)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc = Nothing : R1 = Nothing
                Generic.DisposeDT(dtPallettInfo)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnCopyAll_btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click, btnCopySelectedRows.Click
            Try
                If sender.name = "btnCopyAll" Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Misc.CopyAllData(Me.dbgAvailableBoxes)
                ElseIf sender.name = "btnCopySelectedRows" Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Misc.CopySelectedRowsData(Me.dbgAvailableBoxes)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCopyAll_btnCopySelectedRows_Click.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnRefreshList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshList.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.PopulateAvailableBox()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Protected Function IsBCRequired(ByVal model_id As Integer)
            ' SEE IF THE MODEL REQUIRES A BC.
            Dim _mdl As New Data.Model(model_id)
            Return _mdl.Has_BC
        End Function

        Private Sub chkWHNTFBoxes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWHNTFBoxes.CheckedChanged
            If Me.chkWHNTFBoxes.Checked Then
                Me.chkWHNTFBoxes.ForeColor = Color.MediumBlue
            Else
                Me.chkWHNTFBoxes.ForeColor = Color.White
            End If
        End Sub

        Private Sub lstBoxes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstBoxes.DoubleClick
            Try
                If Me._dtBoxes.Rows.Count > 0 Then
                    Me.lblBoxQty.Text = Me._dtBoxes.Rows(Me.lstBoxes.SelectedIndex)("Pallett_Qty")
                    Me.lblTotalQty.Text = Me._dtBoxes.Compute("Sum(Pallett_Qty)", "")
                Else
                    Me.lblBoxQty.Text = 0
                    Me.lblTotalQty.Text = 0
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace