Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core

Namespace Gui.Warehouse
    Public Class frmStorage
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _objWHC As WHCharge

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _objWHC = New WHCharge()
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
        Friend WithEvents tcWHCharge As System.Windows.Forms.TabControl
        Friend WithEvents tpAddWHCharge As System.Windows.Forms.TabPage
        Friend WithEvents tpAddWHChargeDef As System.Windows.Forms.TabPage
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtWHCD_Desc As System.Windows.Forms.TextBox
        Friend WithEvents pnlWHCD_AddDef As System.Windows.Forms.Panel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtWHCD_UnitOfMeasure As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtWHCD_Charge As System.Windows.Forms.TextBox
        Friend WithEvents dgWHCD_ChargeDef As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblWHC_TotalCharge As System.Windows.Forms.Label
        Friend WithEvents txtWHC_Qty As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cboWHC_Types As C1.Win.C1List.C1Combo
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblWHC_UnitOfMeasure As System.Windows.Forms.Label
        Friend WithEvents pnlWHC_Add As System.Windows.Forms.Panel
        Friend WithEvents dtpWHC_End As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpWHC_Start As System.Windows.Forms.DateTimePicker
        Friend WithEvents dgWHC_SearchData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents dtpWHC_InvoiceDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents lblWHC_ChargePerUnit As System.Windows.Forms.Label
        Friend WithEvents btnWHCD_RefreshList As System.Windows.Forms.Button
        Friend WithEvents btnWHCD_Add As System.Windows.Forms.Button
        Friend WithEvents btnActivateSelRows As System.Windows.Forms.Button
        Friend WithEvents btnDeActivateSelRows As System.Windows.Forms.Button
        Friend WithEvents btnWHC_AddUpd As System.Windows.Forms.Button
        Friend WithEvents btnWHC_Clear As System.Windows.Forms.Button
        Friend WithEvents btnWHC_GetExistingData As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStorage))
            Me.tcWHCharge = New System.Windows.Forms.TabControl()
            Me.tpAddWHCharge = New System.Windows.Forms.TabPage()
            Me.btnWHC_GetExistingData = New System.Windows.Forms.Button()
            Me.pnlWHC_Add = New System.Windows.Forms.Panel()
            Me.lblWHC_ChargePerUnit = New System.Windows.Forms.Label()
            Me.dtpWHC_InvoiceDate = New System.Windows.Forms.DateTimePicker()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblWHC_UnitOfMeasure = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboWHC_Types = New C1.Win.C1List.C1Combo()
            Me.btnWHC_AddUpd = New System.Windows.Forms.Button()
            Me.lblWHC_TotalCharge = New System.Windows.Forms.Label()
            Me.txtWHC_Qty = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dtpWHC_End = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dtpWHC_Start = New System.Windows.Forms.DateTimePicker()
            Me.dgWHC_SearchData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpAddWHChargeDef = New System.Windows.Forms.TabPage()
            Me.btnDeActivateSelRows = New System.Windows.Forms.Button()
            Me.btnActivateSelRows = New System.Windows.Forms.Button()
            Me.btnWHCD_RefreshList = New System.Windows.Forms.Button()
            Me.pnlWHCD_AddDef = New System.Windows.Forms.Panel()
            Me.btnWHCD_Add = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtWHCD_Charge = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtWHCD_UnitOfMeasure = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtWHCD_Desc = New System.Windows.Forms.TextBox()
            Me.dgWHCD_ChargeDef = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnWHC_Clear = New System.Windows.Forms.Button()
            Me.tcWHCharge.SuspendLayout()
            Me.tpAddWHCharge.SuspendLayout()
            Me.pnlWHC_Add.SuspendLayout()
            CType(Me.cboWHC_Types, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgWHC_SearchData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpAddWHChargeDef.SuspendLayout()
            Me.pnlWHCD_AddDef.SuspendLayout()
            CType(Me.dgWHCD_ChargeDef, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tcWHCharge
            '
            Me.tcWHCharge.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tcWHCharge.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpAddWHCharge, Me.tpAddWHChargeDef})
            Me.tcWHCharge.Location = New System.Drawing.Point(16, 48)
            Me.tcWHCharge.Name = "tcWHCharge"
            Me.tcWHCharge.SelectedIndex = 0
            Me.tcWHCharge.Size = New System.Drawing.Size(760, 440)
            Me.tcWHCharge.TabIndex = 0
            '
            'tpAddWHCharge
            '
            Me.tpAddWHCharge.BackColor = System.Drawing.Color.SteelBlue
            Me.tpAddWHCharge.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnWHC_GetExistingData, Me.pnlWHC_Add, Me.Label5, Me.dtpWHC_End, Me.Label4, Me.dtpWHC_Start, Me.dgWHC_SearchData})
            Me.tpAddWHCharge.Location = New System.Drawing.Point(4, 22)
            Me.tpAddWHCharge.Name = "tpAddWHCharge"
            Me.tpAddWHCharge.Size = New System.Drawing.Size(752, 414)
            Me.tpAddWHCharge.TabIndex = 0
            Me.tpAddWHCharge.Text = "Add WH Charge"
            '
            'btnWHC_GetExistingData
            '
            Me.btnWHC_GetExistingData.BackColor = System.Drawing.Color.SteelBlue
            Me.btnWHC_GetExistingData.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWHC_GetExistingData.ForeColor = System.Drawing.Color.White
            Me.btnWHC_GetExistingData.Location = New System.Drawing.Point(528, 16)
            Me.btnWHC_GetExistingData.Name = "btnWHC_GetExistingData"
            Me.btnWHC_GetExistingData.Size = New System.Drawing.Size(96, 23)
            Me.btnWHC_GetExistingData.TabIndex = 3
            Me.btnWHC_GetExistingData.Text = "Get Data"
            '
            'pnlWHC_Add
            '
            Me.pnlWHC_Add.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlWHC_Add.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlWHC_Add.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnWHC_Clear, Me.lblWHC_ChargePerUnit, Me.dtpWHC_InvoiceDate, Me.Label8, Me.lblWHC_UnitOfMeasure, Me.Label7, Me.cboWHC_Types, Me.btnWHC_AddUpd, Me.lblWHC_TotalCharge, Me.txtWHC_Qty, Me.Label9})
            Me.pnlWHC_Add.Location = New System.Drawing.Point(528, 56)
            Me.pnlWHC_Add.Name = "pnlWHC_Add"
            Me.pnlWHC_Add.Size = New System.Drawing.Size(220, 336)
            Me.pnlWHC_Add.TabIndex = 4
            Me.pnlWHC_Add.Visible = False
            '
            'lblWHC_ChargePerUnit
            '
            Me.lblWHC_ChargePerUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWHC_ChargePerUnit.ForeColor = System.Drawing.Color.White
            Me.lblWHC_ChargePerUnit.Location = New System.Drawing.Point(8, 64)
            Me.lblWHC_ChargePerUnit.Name = "lblWHC_ChargePerUnit"
            Me.lblWHC_ChargePerUnit.Size = New System.Drawing.Size(200, 16)
            Me.lblWHC_ChargePerUnit.TabIndex = 241
            Me.lblWHC_ChargePerUnit.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'dtpWHC_InvoiceDate
            '
            Me.dtpWHC_InvoiceDate.Location = New System.Drawing.Point(8, 120)
            Me.dtpWHC_InvoiceDate.Name = "dtpWHC_InvoiceDate"
            Me.dtpWHC_InvoiceDate.TabIndex = 2
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(8, 96)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(104, 16)
            Me.Label8.TabIndex = 240
            Me.Label8.Text = "Invoice Date :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblWHC_UnitOfMeasure
            '
            Me.lblWHC_UnitOfMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWHC_UnitOfMeasure.ForeColor = System.Drawing.Color.Blue
            Me.lblWHC_UnitOfMeasure.Location = New System.Drawing.Point(80, 177)
            Me.lblWHC_UnitOfMeasure.Name = "lblWHC_UnitOfMeasure"
            Me.lblWHC_UnitOfMeasure.Size = New System.Drawing.Size(128, 16)
            Me.lblWHC_UnitOfMeasure.TabIndex = 239
            Me.lblWHC_UnitOfMeasure.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(8, 160)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(96, 16)
            Me.Label7.TabIndex = 238
            Me.Label7.Text = "Quantity :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboWHC_Types
            '
            Me.cboWHC_Types.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboWHC_Types.AutoCompletion = True
            Me.cboWHC_Types.AutoDropDown = True
            Me.cboWHC_Types.AutoSelect = True
            Me.cboWHC_Types.Caption = ""
            Me.cboWHC_Types.CaptionHeight = 17
            Me.cboWHC_Types.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboWHC_Types.ColumnCaptionHeight = 17
            Me.cboWHC_Types.ColumnFooterHeight = 17
            Me.cboWHC_Types.ColumnHeaders = False
            Me.cboWHC_Types.ContentHeight = 15
            Me.cboWHC_Types.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboWHC_Types.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboWHC_Types.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWHC_Types.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboWHC_Types.EditorHeight = 15
            Me.cboWHC_Types.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboWHC_Types.ItemHeight = 15
            Me.cboWHC_Types.Location = New System.Drawing.Point(8, 24)
            Me.cboWHC_Types.MatchEntryTimeout = CType(2000, Long)
            Me.cboWHC_Types.MaxDropDownItems = CType(10, Short)
            Me.cboWHC_Types.MaxLength = 32767
            Me.cboWHC_Types.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboWHC_Types.Name = "cboWHC_Types"
            Me.cboWHC_Types.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboWHC_Types.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboWHC_Types.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboWHC_Types.Size = New System.Drawing.Size(200, 21)
            Me.cboWHC_Types.TabIndex = 1
            Me.cboWHC_Types.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnWHC_AddUpd
            '
            Me.btnWHC_AddUpd.BackColor = System.Drawing.Color.Green
            Me.btnWHC_AddUpd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWHC_AddUpd.ForeColor = System.Drawing.Color.White
            Me.btnWHC_AddUpd.Location = New System.Drawing.Point(8, 256)
            Me.btnWHC_AddUpd.Name = "btnWHC_AddUpd"
            Me.btnWHC_AddUpd.Size = New System.Drawing.Size(200, 23)
            Me.btnWHC_AddUpd.TabIndex = 4
            Me.btnWHC_AddUpd.Text = "Add/Update Warehouse Charge"
            '
            'lblWHC_TotalCharge
            '
            Me.lblWHC_TotalCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWHC_TotalCharge.ForeColor = System.Drawing.Color.White
            Me.lblWHC_TotalCharge.Location = New System.Drawing.Point(8, 216)
            Me.lblWHC_TotalCharge.Name = "lblWHC_TotalCharge"
            Me.lblWHC_TotalCharge.Size = New System.Drawing.Size(200, 16)
            Me.lblWHC_TotalCharge.TabIndex = 236
            Me.lblWHC_TotalCharge.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtWHC_Qty
            '
            Me.txtWHC_Qty.Location = New System.Drawing.Point(8, 176)
            Me.txtWHC_Qty.MaxLength = 30
            Me.txtWHC_Qty.Name = "txtWHC_Qty"
            Me.txtWHC_Qty.Size = New System.Drawing.Size(64, 20)
            Me.txtWHC_Qty.TabIndex = 3
            Me.txtWHC_Qty.Text = ""
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(8, 8)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(104, 16)
            Me.Label9.TabIndex = 232
            Me.Label9.Text = "Type :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(280, 16)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(40, 21)
            Me.Label5.TabIndex = 140
            Me.Label5.Text = "End :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpWHC_End
            '
            Me.dtpWHC_End.Location = New System.Drawing.Point(320, 16)
            Me.dtpWHC_End.Name = "dtpWHC_End"
            Me.dtpWHC_End.Size = New System.Drawing.Size(192, 20)
            Me.dtpWHC_End.TabIndex = 2
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(-20, 16)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 21)
            Me.Label4.TabIndex = 138
            Me.Label4.Text = "Start :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpWHC_Start
            '
            Me.dtpWHC_Start.Location = New System.Drawing.Point(56, 16)
            Me.dtpWHC_Start.Name = "dtpWHC_Start"
            Me.dtpWHC_Start.Size = New System.Drawing.Size(192, 20)
            Me.dtpWHC_Start.TabIndex = 1
            '
            'dgWHC_SearchData
            '
            Me.dgWHC_SearchData.AllowUpdate = False
            Me.dgWHC_SearchData.AlternatingRows = True
            Me.dgWHC_SearchData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgWHC_SearchData.FilterBar = True
            Me.dgWHC_SearchData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgWHC_SearchData.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dgWHC_SearchData.Location = New System.Drawing.Point(8, 56)
            Me.dgWHC_SearchData.Name = "dgWHC_SearchData"
            Me.dgWHC_SearchData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgWHC_SearchData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgWHC_SearchData.PreviewInfo.ZoomFactor = 75
            Me.dgWHC_SearchData.Size = New System.Drawing.Size(504, 336)
            Me.dgWHC_SearchData.TabIndex = 5
            Me.dgWHC_SearchData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "32</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 500, 332<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 500, 332</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'tpAddWHChargeDef
            '
            Me.tpAddWHChargeDef.BackColor = System.Drawing.Color.SteelBlue
            Me.tpAddWHChargeDef.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeActivateSelRows, Me.btnActivateSelRows, Me.btnWHCD_RefreshList, Me.pnlWHCD_AddDef, Me.dgWHCD_ChargeDef})
            Me.tpAddWHChargeDef.Location = New System.Drawing.Point(4, 22)
            Me.tpAddWHChargeDef.Name = "tpAddWHChargeDef"
            Me.tpAddWHChargeDef.Size = New System.Drawing.Size(752, 414)
            Me.tpAddWHChargeDef.TabIndex = 1
            Me.tpAddWHChargeDef.Text = "Add WH Charge Defition"
            '
            'btnDeActivateSelRows
            '
            Me.btnDeActivateSelRows.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnDeActivateSelRows.BackColor = System.Drawing.Color.Red
            Me.btnDeActivateSelRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeActivateSelRows.ForeColor = System.Drawing.Color.White
            Me.btnDeActivateSelRows.Location = New System.Drawing.Point(528, 320)
            Me.btnDeActivateSelRows.Name = "btnDeActivateSelRows"
            Me.btnDeActivateSelRows.Size = New System.Drawing.Size(216, 23)
            Me.btnDeActivateSelRows.TabIndex = 6
            Me.btnDeActivateSelRows.Text = "De-activate Selected Row(s)"
            '
            'btnActivateSelRows
            '
            Me.btnActivateSelRows.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnActivateSelRows.BackColor = System.Drawing.Color.Green
            Me.btnActivateSelRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnActivateSelRows.ForeColor = System.Drawing.Color.White
            Me.btnActivateSelRows.Location = New System.Drawing.Point(528, 272)
            Me.btnActivateSelRows.Name = "btnActivateSelRows"
            Me.btnActivateSelRows.Size = New System.Drawing.Size(216, 23)
            Me.btnActivateSelRows.TabIndex = 5
            Me.btnActivateSelRows.Text = "Activate Selected Row(s)"
            '
            'btnWHCD_RefreshList
            '
            Me.btnWHCD_RefreshList.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnWHCD_RefreshList.BackColor = System.Drawing.Color.SteelBlue
            Me.btnWHCD_RefreshList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWHCD_RefreshList.ForeColor = System.Drawing.Color.White
            Me.btnWHCD_RefreshList.Location = New System.Drawing.Point(528, 8)
            Me.btnWHCD_RefreshList.Name = "btnWHCD_RefreshList"
            Me.btnWHCD_RefreshList.Size = New System.Drawing.Size(152, 23)
            Me.btnWHCD_RefreshList.TabIndex = 2
            Me.btnWHCD_RefreshList.Text = "Refresh List"
            '
            'pnlWHCD_AddDef
            '
            Me.pnlWHCD_AddDef.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlWHCD_AddDef.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlWHCD_AddDef.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnWHCD_Add, Me.Label3, Me.txtWHCD_Charge, Me.Label2, Me.txtWHCD_UnitOfMeasure, Me.Label1, Me.txtWHCD_Desc})
            Me.pnlWHCD_AddDef.Location = New System.Drawing.Point(528, 48)
            Me.pnlWHCD_AddDef.Name = "pnlWHCD_AddDef"
            Me.pnlWHCD_AddDef.Size = New System.Drawing.Size(216, 200)
            Me.pnlWHCD_AddDef.TabIndex = 3
            Me.pnlWHCD_AddDef.Visible = False
            '
            'btnWHCD_Add
            '
            Me.btnWHCD_Add.BackColor = System.Drawing.Color.Green
            Me.btnWHCD_Add.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWHCD_Add.ForeColor = System.Drawing.Color.White
            Me.btnWHCD_Add.Location = New System.Drawing.Point(8, 160)
            Me.btnWHCD_Add.Name = "btnWHCD_Add"
            Me.btnWHCD_Add.Size = New System.Drawing.Size(192, 23)
            Me.btnWHCD_Add.TabIndex = 4
            Me.btnWHCD_Add.Text = "Add"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(4, 104)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(104, 16)
            Me.Label3.TabIndex = 236
            Me.Label3.Text = "Charge/Unit $ :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtWHCD_Charge
            '
            Me.txtWHCD_Charge.Location = New System.Drawing.Point(8, 120)
            Me.txtWHCD_Charge.MaxLength = 30
            Me.txtWHCD_Charge.Name = "txtWHCD_Charge"
            Me.txtWHCD_Charge.Size = New System.Drawing.Size(192, 20)
            Me.txtWHCD_Charge.TabIndex = 3
            Me.txtWHCD_Charge.Text = ""
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(6, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 16)
            Me.Label2.TabIndex = 234
            Me.Label2.Text = "Unit of Measure :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtWHCD_UnitOfMeasure
            '
            Me.txtWHCD_UnitOfMeasure.Location = New System.Drawing.Point(8, 72)
            Me.txtWHCD_UnitOfMeasure.MaxLength = 30
            Me.txtWHCD_UnitOfMeasure.Name = "txtWHCD_UnitOfMeasure"
            Me.txtWHCD_UnitOfMeasure.Size = New System.Drawing.Size(192, 20)
            Me.txtWHCD_UnitOfMeasure.TabIndex = 2
            Me.txtWHCD_UnitOfMeasure.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 16)
            Me.Label1.TabIndex = 232
            Me.Label1.Text = "Description :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtWHCD_Desc
            '
            Me.txtWHCD_Desc.Location = New System.Drawing.Point(8, 24)
            Me.txtWHCD_Desc.MaxLength = 30
            Me.txtWHCD_Desc.Name = "txtWHCD_Desc"
            Me.txtWHCD_Desc.Size = New System.Drawing.Size(192, 20)
            Me.txtWHCD_Desc.TabIndex = 1
            Me.txtWHCD_Desc.Text = ""
            '
            'dgWHCD_ChargeDef
            '
            Me.dgWHCD_ChargeDef.AllowUpdate = False
            Me.dgWHCD_ChargeDef.AlternatingRows = True
            Me.dgWHCD_ChargeDef.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgWHCD_ChargeDef.FilterBar = True
            Me.dgWHCD_ChargeDef.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgWHCD_ChargeDef.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dgWHCD_ChargeDef.Location = New System.Drawing.Point(12, 8)
            Me.dgWHCD_ChargeDef.Name = "dgWHCD_ChargeDef"
            Me.dgWHCD_ChargeDef.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgWHCD_ChargeDef.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgWHCD_ChargeDef.PreviewInfo.ZoomFactor = 75
            Me.dgWHCD_ChargeDef.Size = New System.Drawing.Size(500, 376)
            Me.dgWHCD_ChargeDef.TabIndex = 1
            Me.dgWHCD_ChargeDef.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "72</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 496, 372<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 496, 372</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'cboCustomers
            '
            Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomers.AutoCompletion = True
            Me.cboCustomers.AutoDropDown = True
            Me.cboCustomers.AutoSelect = True
            Me.cboCustomers.Caption = ""
            Me.cboCustomers.CaptionHeight = 17
            Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomers.ColumnCaptionHeight = 17
            Me.cboCustomers.ColumnFooterHeight = 17
            Me.cboCustomers.ColumnHeaders = False
            Me.cboCustomers.ContentHeight = 15
            Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomers.EditorHeight = 15
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(88, 8)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(10, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(216, 21)
            Me.cboCustomers.TabIndex = 1
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(-8, 8)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 21)
            Me.Label6.TabIndex = 137
            Me.Label6.Text = "Customer :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnWHC_Clear
            '
            Me.btnWHC_Clear.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnWHC_Clear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWHC_Clear.ForeColor = System.Drawing.Color.Black
            Me.btnWHC_Clear.Location = New System.Drawing.Point(8, 296)
            Me.btnWHC_Clear.Name = "btnWHC_Clear"
            Me.btnWHC_Clear.Size = New System.Drawing.Size(200, 23)
            Me.btnWHC_Clear.TabIndex = 242
            Me.btnWHC_Clear.Text = "Clear"
            '
            'frmStorage
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(784, 502)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcWHCharge, Me.Label6, Me.cboCustomers})
            Me.Name = "frmStorage"
            Me.Text = "frmStorage"
            Me.tcWHCharge.ResumeLayout(False)
            Me.tpAddWHCharge.ResumeLayout(False)
            Me.pnlWHC_Add.ResumeLayout(False)
            CType(Me.cboWHC_Types, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgWHC_SearchData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpAddWHChargeDef.ResumeLayout(False)
            Me.pnlWHCD_AddDef.ResumeLayout(False)
            CType(Me.dgWHCD_ChargeDef, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************************
        Private Sub frmStorage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                'Load customers
                dt = _objWHC.GetTermCustomers(True)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = _iMenuCustID
                If _iMenuCustID > 0 Then Me.cboCustomers.Enabled = False

                'Load warehouse charge type
                dt = _objWHC.GetWHChargeDefitionList(Me._iMenuCustID, True, True)
                Misc.PopulateC1DropDownList(Me.cboWHC_Types, dt, "WHCType_Desc", "WHCType_ID")
                Me.cboWHC_Types.SelectedValue = 0
                '  'WHCType_UnitMeasurement, WHCType_Charge, Cust_ID

                Me.dtpWHC_Start.Value = Now
                Me.dtpWHC_End.Value = Now
                Me.dtpWHC_InvoiceDate.Value = Now

                If ApplicationUser.GetPermission("WHC_AddCharge") > 0 Then Me.pnlWHC_Add.Visible = True Else Me.pnlWHC_Add.Visible = False
                If ApplicationUser.GetPermission("WHC_AddTypeDef") > 0 Then Me.pnlWHCD_AddDef.Visible = True Else Me.pnlWHCD_AddDef.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************

#Region "Add Warehouse Charge"

        '********************************************************************************
        Private Sub btnWHC_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHC_GetExistingData.Click
            Dim dt As DataTable
            Dim strDateStart, strDateEnd As String

            Try
                strDateStart = Me.dtpWHC_Start.Value.ToString("yyyy-MM-dd")
                strDateEnd = Me.dtpWHC_End.Value.ToString("yyyy-MM-dd")

                If DateDiff(DateInterval.Day, Convert.ToDateTime(strDateStart), Convert.ToDateTime(strDateEnd)) < 0 Then
                    MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    dt = Me._objWHC.GetWHCharge(Me._iMenuCustID, strDateStart, strDateEnd)
                    With Me.dgWHC_SearchData
                        .DataSource = dt.DefaultView

                        .Splits(0).DisplayColumns("Type").Width = 300
                        .Splits(0).DisplayColumns("WHCType_ID").Visible = False
                        .Splits(0).DisplayColumns("WHC_ID").Visible = False
                        .Splits(0).DisplayColumns("WHC_Qty").Visible = False

                        .Columns("Total Charge").NumberFormat = "C2"
                    End With
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnWHC_Search_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cboWHC_Types_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboWHC_Types.SelectedValueChanged
            Dim decCharge As Decimal = 0

            Try
                Me.lblWHC_ChargePerUnit.Text = ""
                Me.lblWHC_TotalCharge.Text = ""
                Me.lblWHC_UnitOfMeasure.Text = ""

                If Me.cboWHC_Types.SelectedValue > 0 Then
                    Me.lblWHC_UnitOfMeasure.Text = Me.cboWHC_Types.DataSource.Table.Select("WHCType_ID = " & Me.cboWHC_Types.SelectedValue)(0)("WHCType_UnitMeasurement")
                    decCharge = Convert.ToDecimal(Me.cboWHC_Types.DataSource.Table.Select("WHCType_ID = " & Me.cboWHC_Types.SelectedValue)(0)("WHCType_Charge"))
                    Me.lblWHC_ChargePerUnit.Text = decCharge & "/" & Me.lblWHC_UnitOfMeasure.Text
                    If Me.txtWHC_Qty.Text.Trim.Length > 0 Then Me.lblWHC_TotalCharge.Text = (Convert.ToDecimal(Me.txtWHC_Qty.Text) * decCharge).ToString
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboWHC_Types_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub txtWHC_Qty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWHC_Qty.KeyPress
            Try
                If e.KeyChar.IsDigit(e.KeyChar) = False AndAlso e.KeyChar.IsControl(e.KeyChar) = False AndAlso e.KeyChar.Equals(".") = False Then
                    e.Handled = True
                ElseIf e.KeyChar.Equals(".") = True AndAlso Me.txtWHC_Qty.Text.Trim.IndexOf(".") >= 0 Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtWHC_Qty_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub txtWHC_Qty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWHC_Qty.KeyUp
            Try
                If e.KeyValue = Keys.Enter AndAlso Me.txtWHC_Qty.Text.Trim.Length > 0 AndAlso Me.cboWHC_Types.SelectedValue > 0 Then
                    Try
                        Dim decCharge As Decimal = Convert.ToDecimal(Me.cboWHC_Types.DataSource.Table.Select("WHCType_ID = " & Me.cboWHC_Types.SelectedValue)(0)("WHCType_Charge"))
                        Me.lblWHC_TotalCharge.Text = "Total Charge $ : " & (Convert.ToDecimal(Me.txtWHC_Qty.Text) * decCharge)
                    Catch ex As Exception
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtWHC_Qty_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnWHC_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHC_AddUpd.Click
            Dim strToday, strInvDate As String
            Dim decQty, decChargePerUnit, decTotalCharge As Decimal
            Dim dt As DataTable
            Dim i As Integer

            Try
                If Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboWHC_Types.SelectedValue = 0 Then
                    MessageBox.Show("Please select type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtWHC_Qty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lblWHC_UnitOfMeasure.Text.Trim.Length = 0 Then
                    MessageBox.Show("Unit of measurement is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Cursor.Current = Cursors.WaitCursor
                    decQty = Convert.ToDecimal(Me.txtWHC_Qty.Text)
                    decChargePerUnit = Convert.ToDecimal(Me.cboWHC_Types.DataSource.Table.Select("WHCType_ID = " & Me.cboWHC_Types.SelectedValue)(0)("WHCType_Charge"))
                    decTotalCharge = decQty * decChargePerUnit
                    strToday = Generic.MySQLServerDateTime(1)
                    strInvDate = Me.dtpWHC_InvoiceDate.Value.ToString("yyyy-MM-dd")

                    If DateDiff(DateInterval.Day, Convert.ToDateTime(strToday), Convert.ToDateTime(strInvDate)) < 0 Then
                        MessageBox.Show("Invalid invoice date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf decQty <= 0 Then
                        MessageBox.Show("Invalid quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf decChargePerUnit = 0 Then
                        MessageBox.Show("Charge per unit is zero. Please verify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        dt = Me._objWHC.GetWHCharge(Me._iMenuCustID, strInvDate, strInvDate, Me.cboWHC_Types.SelectedValue)
                        If dt.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate charge. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf dt.Rows.Count = 1 AndAlso Convert.ToDecimal(Me.txtWHC_Qty.Text) = Convert.ToDecimal(dt.Rows(0)("WHC_Qty")) Then
                            MessageBox.Show(dt.Rows(0)("Type") & " has already added by " & dt.Rows(0)("Added by") & " on " & Convert.ToDateTime(dt.Rows(0)("Added Date")).ToString("MM/dd/yyyy") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If dt.Rows.Count = 1 Then
                                If Me.cboWHC_Types.Enabled = True Then
                                    If MessageBox.Show("Are you sure you want to update quantity from " & dt.Rows(0)("WHC_Qty").ToString & " to " & Me.txtWHC_Qty.Text & "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                                End If
                                i = Me._objWHC.UpdateWarehouseCharge(Convert.ToInt32(dt.Rows(0)("WHC_ID")), decQty, decTotalCharge, ApplicationUser.IDuser)
                            Else
                                i = Me._objWHC.AddWarehouseCharge(Me._iMenuCustID, Me.cboWHC_Types.SelectedValue, Me.cboWHC_Types.Text, Me.lblWHC_UnitOfMeasure.Text, decQty, decTotalCharge, strInvDate, ApplicationUser.IDuser)
                            End If

                            If i > 0 Then
                                btnWHC_Search_Click(Nothing, Nothing)
                                Me.cboWHC_Types.SelectedValue = 0 : Me.cboWHC_Types.Enabled = True
                                Me.dtpWHC_InvoiceDate.Enabled = True
                                Me.txtWHC_Qty.Text = ""
                                Me.lblWHC_ChargePerUnit.Text = ""
                                Me.lblWHC_TotalCharge.Text = ""
                                Me.lblWHC_UnitOfMeasure.Text = ""
                                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("System has failed to add charge.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        End If 'Existing of record
                    End If 'Validate date range and qty
                End If 'validate user input
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnWHC_Add_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************
        Private Sub dgWHC_SearchData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgWHC_SearchData.DoubleClick
            Try
                If Me.dgWHC_SearchData.RowCount > 0 AndAlso Me.dgWHC_SearchData.Columns.Count > 0 Then
                    If Me.cboWHC_Types.DataSource.Table.Select("WHCType_ID = " & Convert.ToInt32(Me.dgWHC_SearchData.Columns("WHCType_ID").CellValue(Me.dgWHC_SearchData.Row))).length > 0 Then
                        Me.cboWHC_Types.SelectedValue = Convert.ToInt32(Me.dgWHC_SearchData.Columns("WHCType_ID").CellValue(Me.dgWHC_SearchData.Row))
                        Me.cboWHC_Types.Enabled = False
                        Me.dtpWHC_InvoiceDate.Value = Convert.ToDateTime(Me.dgWHC_SearchData.Columns("Invoice Date").CellValue(Me.dgWHC_SearchData.Row))
                        Me.dtpWHC_InvoiceDate.Enabled = False
                        Me.txtWHC_Qty.Text = Me.dgWHC_SearchData.Columns("WHC_Qty").CellValue(Me.dgWHC_SearchData.Row)
                    Else
                        MessageBox.Show("Charge type is no longer availalbe.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "dgWHC_SearchData_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnWHC_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHC_Clear.Click
            Try
                Me.cboWHC_Types.SelectedValue = 0
                Me.txtWHC_Qty.Text = ""
                Me.lblWHC_ChargePerUnit.Text = ""
                Me.lblWHC_TotalCharge.Text = ""
                Me.lblWHC_UnitOfMeasure.Text = ""

                Me.cboWHC_Types.Enabled = True
                Me.dtpWHC_InvoiceDate.Enabled = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnWHC_Clear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************

#End Region

#Region "Add Warehouse Charge Type Defition"

        '********************************************************************************
        Private Sub btnWHCD_RefreshList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHCD_RefreshList.Click
            Try
                LoadWarehouseChargeDef()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnWHCD_RefreshList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub LoadWarehouseChargeDef()
            Dim dt As DataTable

            Try
                dt = Me._objWHC.GetWHChargeDefitionList(Me._iMenuCustID, False, False)
                dt.Columns("WHCType_Desc").ColumnName = "Type"
                dt.Columns("WHCType_UnitMeasurement").ColumnName = "Unit of Measure"
                dt.Columns("WHCType_Charge").ColumnName = "Charge/Unit"
                dt.AcceptChanges()
                With Me.dgWHCD_ChargeDef
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("WHCType_ID").Visible = False
                    .Splits(0).DisplayColumns("Cust_ID").Visible = False
                    .Splits(0).DisplayColumns("Active").Visible = False

                    .Splits(0).DisplayColumns("Type").Width = 300
                    .Splits(0).DisplayColumns("Active?").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Columns("Charge/Unit").NumberFormat = "C2"
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub txtCtrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWHCD_Desc.KeyUp, txtWHCD_UnitOfMeasure.KeyUp, txtWHCD_Charge.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "txtWHCD_Desc" AndAlso Me.txtWHCD_Desc.Text.Trim.Length > 0 Then
                        Me.txtWHCD_UnitOfMeasure.SelectAll() : Me.txtWHCD_UnitOfMeasure.Focus()
                    ElseIf sender.name = "txtWHCD_UnitOfMeasure" AndAlso Me.txtWHCD_UnitOfMeasure.Text.Trim.Length > 0 Then
                        Me.txtWHCD_UnitOfMeasure.SelectAll() : Me.txtWHCD_UnitOfMeasure.Focus()
                    ElseIf sender.name = "txtWHCD_Charge" AndAlso txtWHCD_Charge.Text.Trim.Length > 0 Then
                        Me.txtWHCD_Charge.SelectAll() : Me.txtWHCD_Charge.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub txtCtrls_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWHCD_Desc.KeyPress, txtWHCD_UnitOfMeasure.KeyPress, txtWHCD_Charge.KeyPress
            Try
                If (sender.name = "txtWHCD_Desc" OrElse sender.name = "txtWHCD_UnitOfMeasure") AndAlso (e.KeyChar.ToString = "'" = True OrElse e.KeyChar.ToString = """" = True) Then
                    e.Handled = True
                ElseIf sender.name = "txtWHCD_Charge" Then
                    If e.KeyChar.IsDigit(e.KeyChar) = False AndAlso e.KeyChar.IsControl(e.KeyChar) = False AndAlso e.KeyChar.ToString <> "." Then
                        e.Handled = True
                    ElseIf e.KeyChar.ToString = "." AndAlso Me.txtWHCD_Charge.Text.Trim.IndexOf(".") >= 0 Then
                        e.Handled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnWHCD_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHCD_Add.Click
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                If Me.txtWHCD_Desc.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter description.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtWHCD_UnitOfMeasure.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter unit of measure.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtWHCD_Charge.Text.Trim.Length = 0 OrElse Convert.ToDecimal(Me.txtWHCD_Charge.Text) <= 0 Then
                    MessageBox.Show("Charge must be greater than zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    dt = Me._objWHC.GetWHChargeDefition(Me._iMenuCustID, Me.txtWHCD_Desc.Text.Trim.ToUpper)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show(Me.txtWHCD_Desc.Text.Trim.ToUpper & " is existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If MessageBox.Show("Are you sure you want to add " & Me.txtWHCD_Desc.Text.Trim.ToUpper & "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                        i = _objWHC.AddWHChargeDefition(Me._iMenuCustID, Me.txtWHCD_Desc.Text.Trim.ToUpper, Me.txtWHCD_UnitOfMeasure.Text.Trim.ToUpper, Convert.ToDecimal(Me.txtWHCD_Charge.Text))
                        If i > 0 Then
                            MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            '*************************************************
                            LoadWarehouseChargeDef()

                            Me.Enabled = True : Me.btnWHC_Clear_Click(Nothing, Nothing)

                            'Load warehouse charge type
                            dt = _objWHC.GetWHChargeDefitionList(Me._iMenuCustID, True, True)
                            Misc.PopulateC1DropDownList(Me.cboWHC_Types, dt, "WHCType_Desc", "WHCType_ID")
                            '*************************************************

                            Me.cboWHC_Types.SelectedValue = 0
                            Me.txtWHCD_Desc.Text = ""
                            Me.txtWHCD_UnitOfMeasure.Text = ""
                            Me.txtWHCD_Charge.Text = ""
                            Me.Enabled = True : Me.txtWHCD_Desc.Focus()
                        Else
                            MessageBox.Show("System has failed to add warehouse charge definition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnActivateSelRows_btnDeActivateSelRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivateSelRows.Click, btnDeActivateSelRows.Click
            Dim dt As DataTable
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
            Dim iRow, iActive As Integer
            Dim strWHCTypeIDs, strUpdValDes As String

            Try
                strWHCTypeIDs = "" : strUpdValDes = ""

                If Me.dgWHCD_ChargeDef.RowCount > 0 And dgWHCD_ChargeDef.Columns.Count > 0 Then

                    If dgWHCD_ChargeDef.SelectedRows.Count = 0 Then
                        MessageBox.Show("Please select row(s).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    For Each iRow In dgWHCD_ChargeDef.SelectedRows
                        If strWHCTypeIDs.Trim.Length > 0 Then strWHCTypeIDs &= ", "
                        strWHCTypeIDs &= dgWHCD_ChargeDef.Columns("WHCType_ID").CellText(iRow).ToString
                    Next iRow

                    If sender.name = "btnDeActivateSelRows" Then
                        iActive = 0
                        strUpdValDes = "Inactive"
                    Else
                        iActive = 1
                        strUpdValDes = "Active"
                    End If

                    If strWHCTypeIDs.Trim.Length > 0 Then
                        If MessageBox.Show("Are you sure you want to set selected row(s) to " & strUpdValDes & "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                    End If

                    Me._objWHC.SetWHDefActiveFlag(strWHCTypeIDs, iActive)

                    LoadWarehouseChargeDef()

                    Me.Enabled = True : Me.btnWHC_Clear_Click(Nothing, Nothing)

                    'Load warehouse charge type
                    dt = _objWHC.GetWHChargeDefitionList(Me._iMenuCustID, True, True)
                    Misc.PopulateC1DropDownList(Me.cboWHC_Types, dt, "WHCType_Desc", "WHCType_ID")
                    Me.cboWHC_Types.SelectedValue = 0

                    MessageBox.Show("Completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "btnActivateSelRows_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************

#End Region

       

        
     
    End Class
End Namespace