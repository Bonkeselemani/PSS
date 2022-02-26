Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.DriveCam
    Public Class frmDCDockshipping
        Inherits System.Windows.Forms.Form

        Private _objDC As PSS.Data.Buisness.DriveCam

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

                _objDC = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpgDockShip As System.Windows.Forms.TabPage
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents dtpDockShipDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtTrackingNo As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboCarrierType As C1.Win.C1List.C1Combo
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnCopySelectedItem As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents tpgWaitingShipment As System.Windows.Forms.TabPage
        Friend WithEvents dbgWS As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnDockShip As System.Windows.Forms.Button
        Friend WithEvents dbgDockShipmentEntryToday As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnPrintShipDetailManifest As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDCDockshipping))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpgDockShip = New System.Windows.Forms.TabPage()
            Me.dbgDockShipmentEntryToday = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnDockShip = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboCarrierType = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dtpDockShipDate = New System.Windows.Forms.DateTimePicker()
            Me.txtTrackingNo = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtBoxName = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.tpgWaitingShipment = New System.Windows.Forms.TabPage()
            Me.btnCopySelectedItem = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.dbgWS = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnPrintShipDetailManifest = New System.Windows.Forms.Button()
            Me.TabControl1.SuspendLayout()
            Me.tpgDockShip.SuspendLayout()
            CType(Me.dbgDockShipmentEntryToday, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCarrierType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgWaitingShipment.SuspendLayout()
            CType(Me.dbgWS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgDockShip, Me.tpgWaitingShipment})
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(672, 472)
            Me.TabControl1.TabIndex = 106
            '
            'tpgDockShip
            '
            Me.tpgDockShip.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgDockShip.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgDockShipmentEntryToday, Me.btnDockShip, Me.Label4, Me.cboCarrierType, Me.Label3, Me.dtpDockShipDate, Me.txtTrackingNo, Me.Label2, Me.txtBoxName, Me.Label1})
            Me.tpgDockShip.Location = New System.Drawing.Point(4, 22)
            Me.tpgDockShip.Name = "tpgDockShip"
            Me.tpgDockShip.Size = New System.Drawing.Size(664, 446)
            Me.tpgDockShip.TabIndex = 0
            Me.tpgDockShip.Text = "Dock Shipping"
            '
            'dbgDockShipmentEntryToday
            '
            Me.dbgDockShipmentEntryToday.AllowColMove = False
            Me.dbgDockShipmentEntryToday.AllowColSelect = False
            Me.dbgDockShipmentEntryToday.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgDockShipmentEntryToday.AllowUpdate = False
            Me.dbgDockShipmentEntryToday.AllowUpdateOnBlur = False
            Me.dbgDockShipmentEntryToday.AlternatingRows = True
            Me.dbgDockShipmentEntryToday.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgDockShipmentEntryToday.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgDockShipmentEntryToday.FilterBar = True
            Me.dbgDockShipmentEntryToday.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgDockShipmentEntryToday.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDockShipmentEntryToday.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgDockShipmentEntryToday.Location = New System.Drawing.Point(16, 200)
            Me.dbgDockShipmentEntryToday.MaintainRowCurrency = True
            Me.dbgDockShipmentEntryToday.Name = "dbgDockShipmentEntryToday"
            Me.dbgDockShipmentEntryToday.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDockShipmentEntryToday.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDockShipmentEntryToday.PreviewInfo.ZoomFactor = 75
            Me.dbgDockShipmentEntryToday.RowHeight = 20
            Me.dbgDockShipmentEntryToday.Size = New System.Drawing.Size(632, 216)
            Me.dbgDockShipmentEntryToday.TabIndex = 139
            Me.dbgDockShipmentEntryToday.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cen" & _
            "ter;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{B" & _
            "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:Black;BackColor:LightSteelBlue;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>212</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 628, 212</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 628, 212</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnDockShip
            '
            Me.btnDockShip.BackColor = System.Drawing.Color.Green
            Me.btnDockShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDockShip.ForeColor = System.Drawing.Color.White
            Me.btnDockShip.Location = New System.Drawing.Point(296, 168)
            Me.btnDockShip.Name = "btnDockShip"
            Me.btnDockShip.Size = New System.Drawing.Size(64, 20)
            Me.btnDockShip.TabIndex = 5
            Me.btnDockShip.Text = "SHIP"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(16, 56)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(157, 16)
            Me.Label4.TabIndex = 113
            Me.Label4.Text = "Carrier Type:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboCarrierType
            '
            Me.cboCarrierType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCarrierType.AllowDrop = True
            Me.cboCarrierType.AutoCompletion = True
            Me.cboCarrierType.AutoDropDown = True
            Me.cboCarrierType.AutoSelect = True
            Me.cboCarrierType.Caption = ""
            Me.cboCarrierType.CaptionHeight = 17
            Me.cboCarrierType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCarrierType.ColumnCaptionHeight = 17
            Me.cboCarrierType.ColumnFooterHeight = 17
            Me.cboCarrierType.ContentHeight = 15
            Me.cboCarrierType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCarrierType.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCarrierType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrierType.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCarrierType.EditorHeight = 15
            Me.cboCarrierType.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCarrierType.ItemHeight = 15
            Me.cboCarrierType.Location = New System.Drawing.Point(16, 72)
            Me.cboCarrierType.MatchEntryTimeout = CType(2000, Long)
            Me.cboCarrierType.MaxDropDownItems = CType(5, Short)
            Me.cboCarrierType.MaxLength = 32767
            Me.cboCarrierType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCarrierType.Name = "cboCarrierType"
            Me.cboCarrierType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCarrierType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCarrierType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCarrierType.Size = New System.Drawing.Size(272, 21)
            Me.cboCarrierType.TabIndex = 2
            Me.cboCarrierType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Yellow;}Selected{ForeColor:Hi" & _
            "ghlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;" & _
            "BackColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRo" & _
            "w{ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{Bac" & _
            "kColor:Yellow;}RecordSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Cen" & _
            "ter;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}S" & _
            "tyle10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView Allo" & _
            "wColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17""" & _
            " ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Clie" & _
            "ntRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><Width>16</Wid" & _
            "th></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><CaptionStyle parent" & _
            "=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyl" & _
            "e parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><Headi" & _
            "ngStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" " & _
            "me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent" & _
            "=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10" & _
            """ /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""St" & _
            "yle1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""N" & _
            "ormal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foote" & _
            "r"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive" & _
            """ /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group" & _
            """ /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Mo" & _
            "dified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(16, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(157, 16)
            Me.Label3.TabIndex = 111
            Me.Label3.Text = "Dock Ship Date:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dtpDockShipDate
            '
            Me.dtpDockShipDate.CustomFormat = ""
            Me.dtpDockShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
            Me.dtpDockShipDate.Location = New System.Drawing.Point(16, 24)
            Me.dtpDockShipDate.Name = "dtpDockShipDate"
            Me.dtpDockShipDate.Size = New System.Drawing.Size(272, 22)
            Me.dtpDockShipDate.TabIndex = 1
            '
            'txtTrackingNo
            '
            Me.txtTrackingNo.Location = New System.Drawing.Point(16, 120)
            Me.txtTrackingNo.Name = "txtTrackingNo"
            Me.txtTrackingNo.Size = New System.Drawing.Size(272, 20)
            Me.txtTrackingNo.TabIndex = 3
            Me.txtTrackingNo.Text = ""
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(16, 104)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(157, 16)
            Me.Label2.TabIndex = 109
            Me.Label2.Text = "Tracking Number:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtBoxName
            '
            Me.txtBoxName.Location = New System.Drawing.Point(16, 168)
            Me.txtBoxName.Name = "txtBoxName"
            Me.txtBoxName.Size = New System.Drawing.Size(272, 20)
            Me.txtBoxName.TabIndex = 4
            Me.txtBoxName.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(16, 152)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(157, 16)
            Me.Label1.TabIndex = 107
            Me.Label1.Text = "Box Name:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tpgWaitingShipment
            '
            Me.tpgWaitingShipment.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgWaitingShipment.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintShipDetailManifest, Me.btnCopySelectedItem, Me.btnCopyAll, Me.dbgWS})
            Me.tpgWaitingShipment.Location = New System.Drawing.Point(4, 22)
            Me.tpgWaitingShipment.Name = "tpgWaitingShipment"
            Me.tpgWaitingShipment.Size = New System.Drawing.Size(664, 446)
            Me.tpgWaitingShipment.TabIndex = 1
            Me.tpgWaitingShipment.Text = "Waiting to Ship"
            '
            'btnCopySelectedItem
            '
            Me.btnCopySelectedItem.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCopySelectedItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedItem.ForeColor = System.Drawing.Color.Black
            Me.btnCopySelectedItem.Location = New System.Drawing.Point(176, 8)
            Me.btnCopySelectedItem.Name = "btnCopySelectedItem"
            Me.btnCopySelectedItem.Size = New System.Drawing.Size(160, 24)
            Me.btnCopySelectedItem.TabIndex = 141
            Me.btnCopySelectedItem.Text = "Copy Selected Item(s)"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.Black
            Me.btnCopyAll.Location = New System.Drawing.Point(8, 8)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(160, 24)
            Me.btnCopyAll.TabIndex = 140
            Me.btnCopyAll.Text = "Copy All"
            '
            'dbgWS
            '
            Me.dbgWS.AllowColMove = False
            Me.dbgWS.AllowColSelect = False
            Me.dbgWS.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgWS.AllowUpdate = False
            Me.dbgWS.AllowUpdateOnBlur = False
            Me.dbgWS.AlternatingRows = True
            Me.dbgWS.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgWS.FilterBar = True
            Me.dbgWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgWS.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgWS.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgWS.Location = New System.Drawing.Point(8, 40)
            Me.dbgWS.MaintainRowCurrency = True
            Me.dbgWS.Name = "dbgWS"
            Me.dbgWS.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgWS.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgWS.PreviewInfo.ZoomFactor = 75
            Me.dbgWS.RowHeight = 20
            Me.dbgWS.Size = New System.Drawing.Size(624, 392)
            Me.dbgWS.TabIndex = 138
            Me.dbgWS.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:Cont" & _
            "rol;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{B" & _
            "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Ligh" & _
            "tSteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:Black;AlignVert:Center;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>388</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 620, 388</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 620, 388</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnPrintShipDetailManifest
            '
            Me.btnPrintShipDetailManifest.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnPrintShipDetailManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintShipDetailManifest.ForeColor = System.Drawing.Color.Black
            Me.btnPrintShipDetailManifest.Location = New System.Drawing.Point(440, 8)
            Me.btnPrintShipDetailManifest.Name = "btnPrintShipDetailManifest"
            Me.btnPrintShipDetailManifest.Size = New System.Drawing.Size(192, 24)
            Me.btnPrintShipDetailManifest.TabIndex = 142
            Me.btnPrintShipDetailManifest.Text = "Print Detail Manifest Report"
            '
            'frmDCDockshipping
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(696, 501)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmDCDockshipping"
            Me.Text = "frmDCDockshipping"
            Me.TabControl1.ResumeLayout(False)
            Me.tpgDockShip.ResumeLayout(False)
            CType(Me.dbgDockShipmentEntryToday, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCarrierType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgWaitingShipment.ResumeLayout(False)
            CType(Me.dbgWS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************  
        Private Sub frmDCPackingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim objDockShip As DockShipping
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                objDockShip = New DockShipping()
                dt = objDockShip.GetShipCarriers(True)
                Misc.PopulateC1DropDownList(Me.cboCarrierType, dt, "SC_Desc", "SC_ID")

                dtpDockShipDate.Value = Now()

                Me.tpgDockShip.Visible = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "FormLoad Event", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objDockShip = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************
        Private Sub tpgWaitingShipment_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgWaitingShipment.VisibleChanged
            Try
                If sender.visible = True Then
                    PopulateWaitingShipmentGrid()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpgWaitingShipment_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*******************************************************************
        Private Sub PopulateWaitingShipmentGrid()
            Dim dt As DataTable
            Dim i As Integer

            Try
                'Reset controls
                Me.dbgWS.DataSource = Nothing
                Me.btnCopyAll.Visible = False
                Me.btnCopySelectedItem.Visible = False

                dt = Me._objDC.GetPalletWaitingShipment()
                With Me.dbgWS
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


                        If dt.Columns(i).Caption.EndsWith("Date") = True Then
                            .Splits(0).DisplayColumns(i).Width = 170
                        ElseIf dt.Columns(i).Caption.EndsWith("Name") = True Or dt.Columns(i).Caption.EndsWith("Customer") = True Then
                            .Splits(0).DisplayColumns(i).Width = 150
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        Else
                            .Splits(0).DisplayColumns(i).Width = 60
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        End If
                    Next i

                    .ColumnFooters = True
                    .FooterStyle.BackColor = Color.Black
                    .FooterStyle.ForeColor = Color.Lime
                    .Columns("Customer").FooterText = "TOTAL"
                    .Columns("Box Name").FooterText = dt.Rows.Count
                End With

                Me.btnCopySelectedItem.Visible = True
                Me.btnCopyAll.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "PopulateWaitingShipmentGrid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.btnCopySelectedItem.Visible = False
                Me.btnCopyAll.Visible = False
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCopySelectedItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySelectedItem.Click
            Dim strData As String
            Dim iRow As Integer
            Dim booCompleteHeader As Boolean = False
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
            Dim strHeader As String = ""

            Try
                If Me.dbgWS.SelectedRows.Count > 0 And Me.dbgWS.SelectedCols.Count Then
                    'loop through each selected row
                    For Each iRow In Me.dbgWS.SelectedRows

                        'loop through each selected column
                        For Each col In Me.dbgWS.SelectedCols
                            'header
                            If booCompleteHeader = False Then
                                strHeader = strHeader & col.Caption & vbTab
                            End If
                            'data
                            strData = strData & col.CellText(iRow) & vbTab
                        Next col

                        'add new line to data
                        strData = strData & vbCrLf

                        'Stop collect header
                        booCompleteHeader = True
                    Next iRow

                    'combine header and data
                    strData = strHeader & vbCrLf & strData

                    'Copy Data to Clipboard
                    System.Windows.Forms.Clipboard.SetDataObject(strData, False)

                Else
                    MessageBox.Show("Please select a range of cells to copy.", "Copy Selected Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCopySelectedItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
            Dim strData As String
            Dim iRow As Integer
            Dim booCompleteHeader As Boolean = False
            Dim strHeader As String = ""
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

            Try
                If Me.dbgWS.RowCount > 0 And Me.dbgWS.Columns.Count > 0 Then
                    'loop through each row
                    For iRow = 0 To Me.dbgWS.RowCount - 1
                        'loop through each column
                        For Each col In Me.dbgWS.Columns
                            'header
                            If booCompleteHeader = False Then
                                strHeader = strHeader & col.Caption & vbTab
                            End If

                            'Data
                            strData = strData & col.CellText(iRow) & vbTab
                        Next col

                        'add new line to data
                        strData = strData & vbCrLf

                        'Stop collect header
                        booCompleteHeader = True
                    Next iRow

                    'combine header and data
                    strData = strHeader & vbCrLf & strData

                    'Copy Data to Clipboard
                    System.Windows.Forms.Clipboard.SetDataObject(strData, False)
                Else
                    MessageBox.Show("No data to copy.", "Copy All Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                col = Nothing
            End Try
        End Sub

        '*******************************************************************
        Private Sub tpgDockShip_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgDockShip.VisibleChanged
            Try
                If sender.visible = True Then
                    Me.PopulateDriveCamDockShipmentUpdatedToday()
                    Me.cboCarrierType.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpgDockShip_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub ctrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDockShipDate.KeyUp, cboCarrierType.KeyUp, txtTrackingNo.KeyUp, txtBoxName.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.Name = "dtpDockShipDate" Then
                        Me.cboCarrierType.Focus()
                    ElseIf sender.Name = "cboCarrierType" Then
                        If Me.cboCarrierType.SelectedValue > 0 Then Me.txtTrackingNo.Focus()
                    ElseIf sender.Name = "txtTrackingNo" Then
                        If Me.txtTrackingNo.Text.Trim.Length > 0 Then Me.txtBoxName.Focus()
                    ElseIf sender.Name = "txtBoxName" Then
                        If Me.txtBoxName.Text.Trim.Length > 0 AndAlso Me.DockShip() = True Then Me.txtTrackingNo.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpgDockShip_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Function DockShip() As Boolean
            Dim dt As DataTable
            Dim iManifestID As Integer = 0
            Dim i As Integer = 0
            Dim objSPPLF As SendPalletPackingListFiles

            Try
                If Me.cboCarrierType.SelectedValue = 0 Then
                    MessageBox.Show("Please select carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCarrierType.Focus()
                ElseIf Me.txtTrackingNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtTrackingNo.Focus()
                ElseIf CheckTrackNoFormat() = False Then
                    MessageBox.Show("Invalid format of tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtTrackingNo.SelectAll()
                    Me.txtTrackingNo.Focus()
                ElseIf CheckTrackNoFormat() = False Then
                    MessageBox.Show("Invalid format of tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtTrackingNo.SelectAll()
                    Me.txtTrackingNo.Focus()
                ElseIf Me.txtBoxName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter Box Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.Focus()
                Else
                    dt = Me._objDC.GetDriveCamePallet(Me.txtBoxName.Text.Trim)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Box Name does not exist in the system or does not belong to Drivecam Product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.SelectAll()
                        Me.txtBoxName.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Box Name exist more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.SelectAll()
                        Me.txtBoxName.Focus()
                    ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) Then
                        MessageBox.Show("Box is already assigned packing slip #" & dt.Rows(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.SelectAll()
                        Me.txtBoxName.Focus()
                    ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) AndAlso dt.Rows(0)("pkslip_ID") <> 0 Then
                        MessageBox.Show("Box is already assigned packing slip #" & dt.Rows(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.SelectAll()
                        Me.txtBoxName.Focus()
                    ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                        MessageBox.Show("Box is not shipped in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.SelectAll()
                        Me.txtBoxName.Focus()
                    ElseIf (dt.Rows(0)("AWPFlag")) = 1 Then
                        MessageBox.Show("Box is currently waiting for part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.SelectAll()
                        Me.txtBoxName.Focus()
                    ElseIf dt.Rows(0)("Pay_ID") = 2 AndAlso Me._objDC.GetNoInvoiceFlagCount(dt.Rows(0)("Pallett_ID")) > 0 Then
                        MessageBox.Show("There are unit(s) have not been invoiced. Please contact customer service.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.SelectAll()
                        Me.txtBoxName.Focus()
                    Else
                        objSPPLF = New SendPalletPackingListFiles()
                        iManifestID = objSPPLF.CreatePackingSlip(dt.Rows(0)("Cust_ID"), PSS.Core.ApplicationUser.IDuser, , Me.txtTrackingNo.Text.Trim.ToUpper, Format(Me.dtpDockShipDate.Value, "yyyy-MM-dd HH:mm:ss"))
                        If iManifestID = 0 Then
                            MessageBox.Show("System has failed to create Manifest ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            Me.Enabled = False
                            Cursor.Current = Cursors.WaitCursor

                            i = objSPPLF.AssignManifestNumToPallet(dt.Rows(0)("Pallett_ID"), iManifestID, PSS.Core.ApplicationUser.IDuser, dt.Rows(0)("Cust_ID"))

                            Me.PopulateDriveCamDockShipmentUpdatedToday()
                            Me.Enabled = True
                            Cursor.Current = Cursors.Default
                            Me.txtTrackingNo.Text = ""
                            Me.txtBoxName.Text = ""
                            Me.txtTrackingNo.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
                objSPPLF = Nothing
            End Try
        End Function

        '******************************************************************
        Private Sub btnDockShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDockShip.Click
            Try
                If Me.DockShip() = True Then Me.txtTrackingNo.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnDockShip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Function CheckTrackNoFormat() As Boolean
            Dim i As Integer
            Dim cStringChar As Char
            Try
                For i = 1 To Me.txtTrackingNo.Text.Trim.Length
                    cStringChar = CChar(Mid(Me.txtTrackingNo.Text.Trim, i, 1))
                    If Char.IsLetterOrDigit(cStringChar) = False Then
                        Return False
                    End If
                Next i

                Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        Private Sub PopulateDriveCamDockShipmentUpdatedToday()
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                dt = Me._objDC.GetDriveCamDockShipmentUpdatedToday()
                With Me.dbgDockShipmentEntryToday
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                        If dt.Columns(i).Caption.EndsWith("Date") = True Then
                            .Splits(0).DisplayColumns(i).Width = 120
                        ElseIf dt.Columns(i).Caption.EndsWith("Name") = True Or dt.Columns(i).Caption.EndsWith("Customer") = True Then
                            .Splits(0).DisplayColumns(i).Width = 160
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption.EndsWith("Packing ID") = True Then
                            .Splits(0).DisplayColumns(i).Width = 75
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption.EndsWith("Qty") = True Then
                            .Splits(0).DisplayColumns(i).Width = 50
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        Else
                            .Splits(0).DisplayColumns(i).Width = 130
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        End If
                    Next i
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "PopulateDriveCamDockShipmentUpdateToday", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnPrintShipDetailManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintShipDetailManifest.Click
            Dim i As Integer

            Try
                If Not IsNothing(Me.dbgWS.DataSource) AndAlso Me.dbgWS.DataSource.Table.Rows.Count > 0 Then
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor
                    i = Me._objDC.CreateDetailManifestReport()
                    If i > 0 Then Me.PopulateWaitingShipmentGrid()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnPrintShipDetailManifest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub dbgWS_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dbgWS.AfterFilter
            Me.dbgWS.Columns("Box Name").FooterText = Me.dbgWS.RowCount
        End Sub

        '******************************************************************

    End Class
end Namespace