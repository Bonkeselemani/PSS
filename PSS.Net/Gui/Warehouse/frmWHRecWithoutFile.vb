Option Explicit On 

Public Class frmWHRecWithoutFile
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objWHRec = New PSS.Data.Buisness.WarehouseReceive()

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
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblBin As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStagePalletQty As System.Windows.Forms.Label
    Friend WithEvents lblStagePalletQtyVal As System.Windows.Forms.Label
    Friend WithEvents lblSku As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tpWHRec As System.Windows.Forms.TabPage
    Friend WithEvents tpStageRec As System.Windows.Forms.TabPage
    Friend WithEvents lblStageSkid As System.Windows.Forms.Label
    Friend WithEvents lblStageLot As System.Windows.Forms.Label
    Friend WithEvents lblStageSkuVal As System.Windows.Forms.Label
    Friend WithEvents lblStageSkidVal As System.Windows.Forms.Label
    Friend WithEvents lblStageLotVal As System.Windows.Forms.Label
    Friend WithEvents txtStagePallet As System.Windows.Forms.TextBox
    Friend WithEvents lblStagePallet As System.Windows.Forms.Label
    Friend WithEvents lblStageScanQtyVal As System.Windows.Forms.Label
    Friend WithEvents lblStageDevSN As System.Windows.Forms.Label
    Friend WithEvents txtStageDevSN As System.Windows.Forms.TextBox
    Friend WithEvents lblStageScanQty As System.Windows.Forms.Label
    Friend WithEvents btnWHRecPallet As System.Windows.Forms.Button
    Friend WithEvents lblWHRLotVal As System.Windows.Forms.Label
    Friend WithEvents lblWHRLot As System.Windows.Forms.Label
    Friend WithEvents grdWHPallet As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnWHRGetPalletByLot As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWHRLotNum As System.Windows.Forms.TextBox
    Friend WithEvents txtWHRPalletQty As System.Windows.Forms.TextBox
    Friend WithEvents btnWHRPopulateData As System.Windows.Forms.Button
    Friend WithEvents btnWHRCancelUpdate As System.Windows.Forms.Button
    Friend WithEvents btnWHRUpdate As System.Windows.Forms.Button
    Friend WithEvents cmbWHModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents cmbWHRSku As PSS.Gui.Controls.ComboBox
    Friend WithEvents btnWHRDelSelectedPallet As System.Windows.Forms.Button
    Friend WithEvents btnStageClosePallet As System.Windows.Forms.Button
    Friend WithEvents grdStageDev As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnStageUnRcvdDev As System.Windows.Forms.Button
    Friend WithEvents lblStageSku As System.Windows.Forms.Label
    Friend WithEvents lblStageDateCode As System.Windows.Forms.Label
    Friend WithEvents txtStageDateCode As System.Windows.Forms.TextBox
    Friend WithEvents lblStageModelVal As System.Windows.Forms.Label
    Friend WithEvents lblStageModel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWHRecWithoutFile))
        Me.txtStagePallet = New System.Windows.Forms.TextBox()
        Me.lblStageSkid = New System.Windows.Forms.Label()
        Me.lblStageLot = New System.Windows.Forms.Label()
        Me.lblStagePallet = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.lblStageScanQtyVal = New System.Windows.Forms.Label()
        Me.lblStagePalletQty = New System.Windows.Forms.Label()
        Me.lblStageDevSN = New System.Windows.Forms.Label()
        Me.txtStageDevSN = New System.Windows.Forms.TextBox()
        Me.btnStageClosePallet = New System.Windows.Forms.Button()
        Me.grdStageDev = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.btnStageUnRcvdDev = New System.Windows.Forms.Button()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblLineSide = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblBin = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpWHRec = New System.Windows.Forms.TabPage()
        Me.cmbWHRSku = New PSS.Gui.Controls.ComboBox()
        Me.cmbWHModel = New PSS.Gui.Controls.ComboBox()
        Me.btnWHRUpdate = New System.Windows.Forms.Button()
        Me.btnWHRCancelUpdate = New System.Windows.Forms.Button()
        Me.btnWHRPopulateData = New System.Windows.Forms.Button()
        Me.txtWHRLotNum = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnWHRGetPalletByLot = New System.Windows.Forms.Button()
        Me.lblWHRLotVal = New System.Windows.Forms.Label()
        Me.lblWHRLot = New System.Windows.Forms.Label()
        Me.btnWHRDelSelectedPallet = New System.Windows.Forms.Button()
        Me.btnWHRecPallet = New System.Windows.Forms.Button()
        Me.grdWHPallet = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtWHRPalletQty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSku = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpStageRec = New System.Windows.Forms.TabPage()
        Me.lblStageModel = New System.Windows.Forms.Label()
        Me.lblStageDateCode = New System.Windows.Forms.Label()
        Me.txtStageDateCode = New System.Windows.Forms.TextBox()
        Me.lblStageSkuVal = New System.Windows.Forms.Label()
        Me.lblStageSku = New System.Windows.Forms.Label()
        Me.lblStageScanQty = New System.Windows.Forms.Label()
        Me.lblStagePalletQtyVal = New System.Windows.Forms.Label()
        Me.lblStageSkidVal = New System.Windows.Forms.Label()
        Me.lblStageLotVal = New System.Windows.Forms.Label()
        Me.lblStageModelVal = New System.Windows.Forms.Label()
        CType(Me.grdStageDev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpWHRec.SuspendLayout()
        CType(Me.grdWHPallet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStageRec.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtStagePallet
        '
        Me.txtStagePallet.BackColor = System.Drawing.Color.White
        Me.txtStagePallet.Location = New System.Drawing.Point(80, 104)
        Me.txtStagePallet.Name = "txtStagePallet"
        Me.txtStagePallet.Size = New System.Drawing.Size(224, 20)
        Me.txtStagePallet.TabIndex = 1
        Me.txtStagePallet.Text = ""
        '
        'lblStageSkid
        '
        Me.lblStageSkid.BackColor = System.Drawing.Color.Transparent
        Me.lblStageSkid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageSkid.ForeColor = System.Drawing.Color.White
        Me.lblStageSkid.Location = New System.Drawing.Point(8, 46)
        Me.lblStageSkid.Name = "lblStageSkid"
        Me.lblStageSkid.Size = New System.Drawing.Size(72, 16)
        Me.lblStageSkid.TabIndex = 87
        Me.lblStageSkid.Text = "Skid:"
        Me.lblStageSkid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStageSkid.Visible = False
        '
        'lblStageLot
        '
        Me.lblStageLot.BackColor = System.Drawing.Color.Transparent
        Me.lblStageLot.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageLot.ForeColor = System.Drawing.Color.White
        Me.lblStageLot.Location = New System.Drawing.Point(8, 30)
        Me.lblStageLot.Name = "lblStageLot"
        Me.lblStageLot.Size = New System.Drawing.Size(72, 16)
        Me.lblStageLot.TabIndex = 88
        Me.lblStageLot.Text = "Lot:"
        Me.lblStageLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStageLot.Visible = False
        '
        'lblStagePallet
        '
        Me.lblStagePallet.BackColor = System.Drawing.Color.Transparent
        Me.lblStagePallet.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStagePallet.ForeColor = System.Drawing.Color.White
        Me.lblStagePallet.Location = New System.Drawing.Point(16, 104)
        Me.lblStagePallet.Name = "lblStagePallet"
        Me.lblStagePallet.Size = New System.Drawing.Size(64, 16)
        Me.lblStagePallet.TabIndex = 89
        Me.lblStagePallet.Text = "Pallet:"
        Me.lblStagePallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
        Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.White
        Me.lblMsg.Location = New System.Drawing.Point(512, 0)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(224, 56)
        Me.lblMsg.TabIndex = 98
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStageScanQtyVal
        '
        Me.lblStageScanQtyVal.BackColor = System.Drawing.Color.Black
        Me.lblStageScanQtyVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageScanQtyVal.ForeColor = System.Drawing.Color.Lime
        Me.lblStageScanQtyVal.Location = New System.Drawing.Point(128, 240)
        Me.lblStageScanQtyVal.Name = "lblStageScanQtyVal"
        Me.lblStageScanQtyVal.Size = New System.Drawing.Size(80, 41)
        Me.lblStageScanQtyVal.TabIndex = 98
        Me.lblStageScanQtyVal.Text = "0"
        Me.lblStageScanQtyVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStagePalletQty
        '
        Me.lblStagePalletQty.BackColor = System.Drawing.Color.Transparent
        Me.lblStagePalletQty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStagePalletQty.ForeColor = System.Drawing.Color.White
        Me.lblStagePalletQty.Location = New System.Drawing.Point(8, 78)
        Me.lblStagePalletQty.Name = "lblStagePalletQty"
        Me.lblStagePalletQty.Size = New System.Drawing.Size(72, 16)
        Me.lblStagePalletQty.TabIndex = 97
        Me.lblStagePalletQty.Text = "Pallet Qty:"
        Me.lblStagePalletQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStagePalletQty.Visible = False
        '
        'lblStageDevSN
        '
        Me.lblStageDevSN.BackColor = System.Drawing.Color.Transparent
        Me.lblStageDevSN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageDevSN.ForeColor = System.Drawing.Color.White
        Me.lblStageDevSN.Location = New System.Drawing.Point(8, 128)
        Me.lblStageDevSN.Name = "lblStageDevSN"
        Me.lblStageDevSN.Size = New System.Drawing.Size(72, 14)
        Me.lblStageDevSN.TabIndex = 85
        Me.lblStageDevSN.Text = "Device SN:"
        Me.lblStageDevSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStageDevSN
        '
        Me.txtStageDevSN.BackColor = System.Drawing.Color.White
        Me.txtStageDevSN.Location = New System.Drawing.Point(80, 128)
        Me.txtStageDevSN.MaxLength = 20
        Me.txtStageDevSN.Name = "txtStageDevSN"
        Me.txtStageDevSN.Size = New System.Drawing.Size(224, 20)
        Me.txtStageDevSN.TabIndex = 2
        Me.txtStageDevSN.Text = ""
        '
        'btnStageClosePallet
        '
        Me.btnStageClosePallet.BackColor = System.Drawing.Color.Green
        Me.btnStageClosePallet.Enabled = False
        Me.btnStageClosePallet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStageClosePallet.ForeColor = System.Drawing.Color.White
        Me.btnStageClosePallet.Location = New System.Drawing.Point(48, 304)
        Me.btnStageClosePallet.Name = "btnStageClosePallet"
        Me.btnStageClosePallet.Size = New System.Drawing.Size(248, 24)
        Me.btnStageClosePallet.TabIndex = 4
        Me.btnStageClosePallet.Text = "CLOSE PALLET"
        '
        'grdStageDev
        '
        Me.grdStageDev.AllowColMove = False
        Me.grdStageDev.AllowColSelect = False
        Me.grdStageDev.AllowFilter = False
        Me.grdStageDev.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdStageDev.AllowSort = False
        Me.grdStageDev.AllowUpdate = False
        Me.grdStageDev.AllowUpdateOnBlur = False
        Me.grdStageDev.AlternatingRows = True
        Me.grdStageDev.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdStageDev.CollapseColor = System.Drawing.Color.White
        Me.grdStageDev.ExpandColor = System.Drawing.Color.White
        Me.grdStageDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdStageDev.ForeColor = System.Drawing.Color.White
        Me.grdStageDev.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdStageDev.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdStageDev.Location = New System.Drawing.Point(376, 3)
        Me.grdStageDev.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdStageDev.Name = "grdStageDev"
        Me.grdStageDev.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdStageDev.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdStageDev.PreviewInfo.ZoomFactor = 75
        Me.grdStageDev.RowHeight = 20
        Me.grdStageDev.Size = New System.Drawing.Size(300, 453)
        Me.grdStageDev.TabIndex = 2
        Me.grdStageDev.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:LightSteelBlue;" & _
        "}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColo" & _
        "r:White;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;F" & _
        "oreColor:White;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;Ali" & _
        "gnVert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:H" & _
        "ighlightText;BackColor:Highlight;}Style14{}OddRow{ForeColor:White;BackColor:Stee" & _
        "lBlue;}RecordSelector{ForeColor:White;AlignImage:Center;}Style15{}Heading{Wrap:T" & _
        "rue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Con" & _
        "trol;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{" & _
        "AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}Style9{}</Data></St" & _
        "yles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=" & _
        """False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""" & _
        "17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBor" & _
        "der"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizo" & _
        "ntalScrollGroup=""1""><Height>449</Height><CaptionStyle parent=""Style2"" me=""Style1" & _
        "0"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" m" & _
        "e=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pare" & _
        "nt=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyl" & _
        "e parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""St" & _
        "yle7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddR" & _
        "ow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><S" & _
        "electedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" " & _
        "/><ClientRect>0, 0, 296, 449</ClientRect><BorderSide>0</BorderSide><BorderStyle>" & _
        "Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style" & _
        " parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""He" & _
        "ading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headi" & _
        "ng"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal" & _
        """ me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal" & _
        """ me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me" & _
        "=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0" & _
        ", 0, 296, 449</ClientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintP" & _
        "ageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(8, 32)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(232, 16)
        Me.lblGroup.TabIndex = 90
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(6, 0)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(234, 21)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.Text = "User : lan nguyen"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnStageUnRcvdDev
        '
        Me.btnStageUnRcvdDev.BackColor = System.Drawing.Color.Red
        Me.btnStageUnRcvdDev.Enabled = False
        Me.btnStageUnRcvdDev.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStageUnRcvdDev.ForeColor = System.Drawing.Color.White
        Me.btnStageUnRcvdDev.Location = New System.Drawing.Point(48, 344)
        Me.btnStageUnRcvdDev.Name = "btnStageUnRcvdDev"
        Me.btnStageUnRcvdDev.Size = New System.Drawing.Size(248, 24)
        Me.btnStageUnRcvdDev.TabIndex = 5
        Me.btnStageUnRcvdDev.Text = "UN-RECEIVE SELECTED DEVICE"
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(408, 32)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(96, 16)
        Me.lblShift.TabIndex = 113
        '
        'lblLineSide
        '
        Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
        Me.lblLineSide.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
        Me.lblLineSide.Location = New System.Drawing.Point(240, 0)
        Me.lblLineSide.Name = "lblLineSide"
        Me.lblLineSide.Size = New System.Drawing.Size(160, 21)
        Me.lblLineSide.TabIndex = 112
        Me.lblLineSide.Text = "User : lan nguyen"
        Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBin, Me.lblWorkDate, Me.lblGroup, Me.lblLineSide, Me.lblUserName, Me.lblShift})
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(512, 56)
        Me.Panel2.TabIndex = 101
        '
        'lblBin
        '
        Me.lblBin.BackColor = System.Drawing.Color.Transparent
        Me.lblBin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBin.ForeColor = System.Drawing.Color.Lime
        Me.lblBin.Location = New System.Drawing.Point(408, 8)
        Me.lblBin.Name = "lblBin"
        Me.lblBin.Size = New System.Drawing.Size(96, 16)
        Me.lblBin.TabIndex = 115
        Me.lblBin.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(240, 32)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(160, 16)
        Me.lblWorkDate.TabIndex = 114
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpWHRec, Me.tpStageRec})
        Me.TabControl1.Location = New System.Drawing.Point(0, 64)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(736, 488)
        Me.TabControl1.TabIndex = 103
        '
        'tpWHRec
        '
        Me.tpWHRec.BackColor = System.Drawing.Color.SteelBlue
        Me.tpWHRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbWHRSku, Me.cmbWHModel, Me.btnWHRUpdate, Me.btnWHRCancelUpdate, Me.btnWHRPopulateData, Me.txtWHRLotNum, Me.Label2, Me.btnWHRGetPalletByLot, Me.lblWHRLotVal, Me.lblWHRLot, Me.btnWHRDelSelectedPallet, Me.btnWHRecPallet, Me.grdWHPallet, Me.txtWHRPalletQty, Me.Label3, Me.lblSku, Me.Label1})
        Me.tpWHRec.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tpWHRec.Location = New System.Drawing.Point(4, 22)
        Me.tpWHRec.Name = "tpWHRec"
        Me.tpWHRec.Size = New System.Drawing.Size(728, 462)
        Me.tpWHRec.TabIndex = 0
        Me.tpWHRec.Text = "Warehouse Receive"
        '
        'cmbWHRSku
        '
        Me.cmbWHRSku.AutoComplete = True
        Me.cmbWHRSku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWHRSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWHRSku.Location = New System.Drawing.Point(56, 36)
        Me.cmbWHRSku.Name = "cmbWHRSku"
        Me.cmbWHRSku.Size = New System.Drawing.Size(168, 24)
        Me.cmbWHRSku.TabIndex = 2
        '
        'cmbWHModel
        '
        Me.cmbWHModel.AutoComplete = True
        Me.cmbWHModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWHModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWHModel.Location = New System.Drawing.Point(56, 4)
        Me.cmbWHModel.Name = "cmbWHModel"
        Me.cmbWHModel.Size = New System.Drawing.Size(168, 24)
        Me.cmbWHModel.TabIndex = 1
        '
        'btnWHRUpdate
        '
        Me.btnWHRUpdate.BackColor = System.Drawing.Color.Green
        Me.btnWHRUpdate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWHRUpdate.ForeColor = System.Drawing.Color.White
        Me.btnWHRUpdate.Location = New System.Drawing.Point(416, 40)
        Me.btnWHRUpdate.Name = "btnWHRUpdate"
        Me.btnWHRUpdate.Size = New System.Drawing.Size(72, 24)
        Me.btnWHRUpdate.TabIndex = 10
        Me.btnWHRUpdate.Text = "Update"
        Me.btnWHRUpdate.Visible = False
        '
        'btnWHRCancelUpdate
        '
        Me.btnWHRCancelUpdate.BackColor = System.Drawing.Color.Green
        Me.btnWHRCancelUpdate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWHRCancelUpdate.ForeColor = System.Drawing.Color.White
        Me.btnWHRCancelUpdate.Location = New System.Drawing.Point(416, 4)
        Me.btnWHRCancelUpdate.Name = "btnWHRCancelUpdate"
        Me.btnWHRCancelUpdate.Size = New System.Drawing.Size(72, 24)
        Me.btnWHRCancelUpdate.TabIndex = 9
        Me.btnWHRCancelUpdate.Text = "Cancel"
        Me.btnWHRCancelUpdate.Visible = False
        '
        'btnWHRPopulateData
        '
        Me.btnWHRPopulateData.BackColor = System.Drawing.Color.Green
        Me.btnWHRPopulateData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWHRPopulateData.ForeColor = System.Drawing.Color.White
        Me.btnWHRPopulateData.Location = New System.Drawing.Point(272, 144)
        Me.btnWHRPopulateData.Name = "btnWHRPopulateData"
        Me.btnWHRPopulateData.Size = New System.Drawing.Size(224, 24)
        Me.btnWHRPopulateData.TabIndex = 8
        Me.btnWHRPopulateData.Text = "Populate Selected Data for update"
        '
        'txtWHRLotNum
        '
        Me.txtWHRLotNum.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtWHRLotNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtWHRLotNum.Location = New System.Drawing.Point(640, 112)
        Me.txtWHRLotNum.MaxLength = 15
        Me.txtWHRLotNum.Name = "txtWHRLotNum"
        Me.txtWHRLotNum.Size = New System.Drawing.Size(72, 20)
        Me.txtWHRLotNum.TabIndex = 6
        Me.txtWHRLotNum.Text = ""
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(568, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Lot:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnWHRGetPalletByLot
        '
        Me.btnWHRGetPalletByLot.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnWHRGetPalletByLot.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnWHRGetPalletByLot.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWHRGetPalletByLot.ForeColor = System.Drawing.Color.Black
        Me.btnWHRGetPalletByLot.Location = New System.Drawing.Point(552, 144)
        Me.btnWHRGetPalletByLot.Name = "btnWHRGetPalletByLot"
        Me.btnWHRGetPalletByLot.Size = New System.Drawing.Size(160, 24)
        Me.btnWHRGetPalletByLot.TabIndex = 7
        Me.btnWHRGetPalletByLot.Text = "GET WHPALLET BY LOT"
        '
        'lblWHRLotVal
        '
        Me.lblWHRLotVal.BackColor = System.Drawing.Color.White
        Me.lblWHRLotVal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWHRLotVal.ForeColor = System.Drawing.Color.Black
        Me.lblWHRLotVal.Location = New System.Drawing.Point(312, 4)
        Me.lblWHRLotVal.Name = "lblWHRLotVal"
        Me.lblWHRLotVal.Size = New System.Drawing.Size(72, 24)
        Me.lblWHRLotVal.TabIndex = 93
        Me.lblWHRLotVal.Text = "0100708"
        Me.lblWHRLotVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWHRLot
        '
        Me.lblWHRLot.BackColor = System.Drawing.Color.Transparent
        Me.lblWHRLot.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWHRLot.ForeColor = System.Drawing.Color.Black
        Me.lblWHRLot.Location = New System.Drawing.Point(240, 8)
        Me.lblWHRLot.Name = "lblWHRLot"
        Me.lblWHRLot.Size = New System.Drawing.Size(72, 15)
        Me.lblWHRLot.TabIndex = 92
        Me.lblWHRLot.Text = "LOT:"
        Me.lblWHRLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnWHRDelSelectedPallet
        '
        Me.btnWHRDelSelectedPallet.BackColor = System.Drawing.Color.Red
        Me.btnWHRDelSelectedPallet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWHRDelSelectedPallet.ForeColor = System.Drawing.Color.White
        Me.btnWHRDelSelectedPallet.Location = New System.Drawing.Point(24, 144)
        Me.btnWHRDelSelectedPallet.Name = "btnWHRDelSelectedPallet"
        Me.btnWHRDelSelectedPallet.Size = New System.Drawing.Size(200, 24)
        Me.btnWHRDelSelectedPallet.TabIndex = 5
        Me.btnWHRDelSelectedPallet.Text = "DELETE SELECTED PALLET"
        '
        'btnWHRecPallet
        '
        Me.btnWHRecPallet.BackColor = System.Drawing.Color.Green
        Me.btnWHRecPallet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWHRecPallet.ForeColor = System.Drawing.Color.White
        Me.btnWHRecPallet.Location = New System.Drawing.Point(24, 88)
        Me.btnWHRecPallet.Name = "btnWHRecPallet"
        Me.btnWHRecPallet.Size = New System.Drawing.Size(200, 24)
        Me.btnWHRecPallet.TabIndex = 4
        Me.btnWHRecPallet.Text = "RECEIVE PALLET"
        '
        'grdWHPallet
        '
        Me.grdWHPallet.AllowColMove = False
        Me.grdWHPallet.AllowColSelect = False
        Me.grdWHPallet.AllowFilter = False
        Me.grdWHPallet.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdWHPallet.AllowSort = False
        Me.grdWHPallet.AllowUpdate = False
        Me.grdWHPallet.AllowUpdateOnBlur = False
        Me.grdWHPallet.AlternatingRows = True
        Me.grdWHPallet.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdWHPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdWHPallet.ExpandColor = System.Drawing.Color.White
        Me.grdWHPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdWHPallet.ForeColor = System.Drawing.Color.Black
        Me.grdWHPallet.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdWHPallet.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdWHPallet.Location = New System.Drawing.Point(8, 176)
        Me.grdWHPallet.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdWHPallet.Name = "grdWHPallet"
        Me.grdWHPallet.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdWHPallet.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdWHPallet.PreviewInfo.ZoomFactor = 75
        Me.grdWHPallet.RowHeight = 20
        Me.grdWHPallet.Size = New System.Drawing.Size(712, 280)
        Me.grdWHPallet.TabIndex = 91
        Me.grdWHPallet.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt;ForeColor:Black;BackColor:LightSteelBlue;}Selected{ForeColor:HighlightT" & _
        "ext;BackColor:Highlight;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCapt" & _
        "ion;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeColor:White;}Style9{}Normal" & _
        "{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColor:LightSteelBlue;ForeColo" & _
        "r:White;AlignVert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlig" & _
        "ht;}Style12{}OddRow{Font:Microsoft Sans Serif, 8.25pt;ForeColor:Black;BackColor:" & _
        "SteelBlue;}RecordSelector{AlignImage:Center;ForeColor:White;}Style13{}Heading{Wr" & _
        "ap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert" & _
        ":Center;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;BackColor:Control;}Style8{}Styl" & _
        "e10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style16{}Style17{}Style1{}</Data>" & _
        "</Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""Fa" & _
        "lse"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""T" & _
        "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" Marquee" & _
        "Style=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalSc" & _
        "rollGroup=""1"" HorizontalScrollGroup=""1""><Height>276</Height><CaptionStyle parent" & _
        "=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyl" & _
        "e parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13""" & _
        " /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Sty" & _
        "le12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""" & _
        "HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddR" & _
        "owStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelecto" & _
        "r"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""" & _
        "Normal"" me=""Style1"" /><ClientRect>0, 0, 708, 276</ClientRect><BorderSide>0</Bord" & _
        "erSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits" & _
        "><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading""" & _
        " /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" />" & _
        "<Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><" & _
        "Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><" & _
        "Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style" & _
        " parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" />" & _
        "<Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><ho" & _
        "rzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSe" & _
        "lWidth><ClientArea>0, 0, 708, 276</ClientArea><PrintPageHeaderStyle parent="""" me" & _
        "=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'txtWHRPalletQty
        '
        Me.txtWHRPalletQty.BackColor = System.Drawing.Color.White
        Me.txtWHRPalletQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWHRPalletQty.Location = New System.Drawing.Point(312, 40)
        Me.txtWHRPalletQty.MaxLength = 15
        Me.txtWHRPalletQty.Name = "txtWHRPalletQty"
        Me.txtWHRPalletQty.Size = New System.Drawing.Size(72, 22)
        Me.txtWHRPalletQty.TabIndex = 3
        Me.txtWHRPalletQty.Text = ""
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(240, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Pallet Qty:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSku
        '
        Me.lblSku.BackColor = System.Drawing.Color.Transparent
        Me.lblSku.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSku.ForeColor = System.Drawing.Color.Black
        Me.lblSku.Location = New System.Drawing.Point(8, 40)
        Me.lblSku.Name = "lblSku"
        Me.lblSku.Size = New System.Drawing.Size(48, 15)
        Me.lblSku.TabIndex = 88
        Me.lblSku.Text = "Sku:"
        Me.lblSku.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Model:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpStageRec
        '
        Me.tpStageRec.BackColor = System.Drawing.Color.SteelBlue
        Me.tpStageRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblStageModel, Me.lblStageDateCode, Me.txtStageDateCode, Me.lblStageSkuVal, Me.lblStageSku, Me.lblStageScanQty, Me.lblStagePalletQtyVal, Me.lblStageSkidVal, Me.lblStageLotVal, Me.lblStageModelVal, Me.lblStageSkid, Me.lblStageLot, Me.txtStagePallet, Me.lblStagePallet, Me.lblStagePalletQty, Me.lblStageScanQtyVal, Me.lblStageDevSN, Me.txtStageDevSN, Me.btnStageClosePallet, Me.btnStageUnRcvdDev, Me.grdStageDev})
        Me.tpStageRec.Location = New System.Drawing.Point(4, 22)
        Me.tpStageRec.Name = "tpStageRec"
        Me.tpStageRec.Size = New System.Drawing.Size(728, 462)
        Me.tpStageRec.TabIndex = 1
        Me.tpStageRec.Text = "Stage Receive"
        '
        'lblStageModel
        '
        Me.lblStageModel.BackColor = System.Drawing.Color.Transparent
        Me.lblStageModel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageModel.ForeColor = System.Drawing.Color.White
        Me.lblStageModel.Location = New System.Drawing.Point(8, 8)
        Me.lblStageModel.Name = "lblStageModel"
        Me.lblStageModel.Size = New System.Drawing.Size(72, 16)
        Me.lblStageModel.TabIndex = 111
        Me.lblStageModel.Text = "Model:"
        Me.lblStageModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStageModel.Visible = False
        '
        'lblStageDateCode
        '
        Me.lblStageDateCode.BackColor = System.Drawing.Color.Transparent
        Me.lblStageDateCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageDateCode.ForeColor = System.Drawing.Color.White
        Me.lblStageDateCode.Location = New System.Drawing.Point(8, 152)
        Me.lblStageDateCode.Name = "lblStageDateCode"
        Me.lblStageDateCode.Size = New System.Drawing.Size(72, 16)
        Me.lblStageDateCode.TabIndex = 110
        Me.lblStageDateCode.Text = "Date Code:"
        Me.lblStageDateCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStageDateCode.Visible = False
        '
        'txtStageDateCode
        '
        Me.txtStageDateCode.Location = New System.Drawing.Point(80, 152)
        Me.txtStageDateCode.MaxLength = 4
        Me.txtStageDateCode.Name = "txtStageDateCode"
        Me.txtStageDateCode.Size = New System.Drawing.Size(104, 20)
        Me.txtStageDateCode.TabIndex = 3
        Me.txtStageDateCode.Text = ""
        Me.txtStageDateCode.Visible = False
        '
        'lblStageSkuVal
        '
        Me.lblStageSkuVal.BackColor = System.Drawing.Color.Transparent
        Me.lblStageSkuVal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageSkuVal.ForeColor = System.Drawing.Color.White
        Me.lblStageSkuVal.Location = New System.Drawing.Point(88, 62)
        Me.lblStageSkuVal.Name = "lblStageSkuVal"
        Me.lblStageSkuVal.Size = New System.Drawing.Size(64, 16)
        Me.lblStageSkuVal.TabIndex = 108
        Me.lblStageSkuVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStageSku
        '
        Me.lblStageSku.BackColor = System.Drawing.Color.Transparent
        Me.lblStageSku.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageSku.ForeColor = System.Drawing.Color.White
        Me.lblStageSku.Location = New System.Drawing.Point(8, 62)
        Me.lblStageSku.Name = "lblStageSku"
        Me.lblStageSku.Size = New System.Drawing.Size(72, 16)
        Me.lblStageSku.TabIndex = 107
        Me.lblStageSku.Text = "Sku:"
        Me.lblStageSku.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblStageSku.Visible = False
        '
        'lblStageScanQty
        '
        Me.lblStageScanQty.BackColor = System.Drawing.Color.Transparent
        Me.lblStageScanQty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageScanQty.ForeColor = System.Drawing.Color.Black
        Me.lblStageScanQty.Location = New System.Drawing.Point(128, 224)
        Me.lblStageScanQty.Name = "lblStageScanQty"
        Me.lblStageScanQty.Size = New System.Drawing.Size(80, 14)
        Me.lblStageScanQty.TabIndex = 106
        Me.lblStageScanQty.Text = "Scan Qty:"
        Me.lblStageScanQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStagePalletQtyVal
        '
        Me.lblStagePalletQtyVal.BackColor = System.Drawing.Color.Transparent
        Me.lblStagePalletQtyVal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStagePalletQtyVal.ForeColor = System.Drawing.Color.White
        Me.lblStagePalletQtyVal.Location = New System.Drawing.Point(88, 78)
        Me.lblStagePalletQtyVal.Name = "lblStagePalletQtyVal"
        Me.lblStagePalletQtyVal.Size = New System.Drawing.Size(64, 16)
        Me.lblStagePalletQtyVal.TabIndex = 105
        Me.lblStagePalletQtyVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStageSkidVal
        '
        Me.lblStageSkidVal.BackColor = System.Drawing.Color.Transparent
        Me.lblStageSkidVal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageSkidVal.ForeColor = System.Drawing.Color.White
        Me.lblStageSkidVal.Location = New System.Drawing.Point(88, 46)
        Me.lblStageSkidVal.Name = "lblStageSkidVal"
        Me.lblStageSkidVal.Size = New System.Drawing.Size(64, 16)
        Me.lblStageSkidVal.TabIndex = 104
        Me.lblStageSkidVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStageLotVal
        '
        Me.lblStageLotVal.BackColor = System.Drawing.Color.Transparent
        Me.lblStageLotVal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageLotVal.ForeColor = System.Drawing.Color.White
        Me.lblStageLotVal.Location = New System.Drawing.Point(88, 30)
        Me.lblStageLotVal.Name = "lblStageLotVal"
        Me.lblStageLotVal.Size = New System.Drawing.Size(64, 16)
        Me.lblStageLotVal.TabIndex = 103
        Me.lblStageLotVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStageModelVal
        '
        Me.lblStageModelVal.BackColor = System.Drawing.Color.Transparent
        Me.lblStageModelVal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageModelVal.ForeColor = System.Drawing.Color.White
        Me.lblStageModelVal.Location = New System.Drawing.Point(88, 8)
        Me.lblStageModelVal.Name = "lblStageModelVal"
        Me.lblStageModelVal.Size = New System.Drawing.Size(216, 16)
        Me.lblStageModelVal.TabIndex = 83
        Me.lblStageModelVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmWHRecWithoutFile
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(744, 557)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.Panel2, Me.lblMsg})
        Me.Name = "frmWHRecWithoutFile"
        Me.Text = "Gamestop Warehouse Receive"
        CType(Me.grdStageDev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpWHRec.ResumeLayout(False)
        CType(Me.grdWHPallet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStageRec.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _objWHRec As PSS.Data.Buisness.WarehouseReceive
    Private _strMachine As String = System.Net.Dns.GetHostName
    Private _iMachineGroupID As Integer = PSS.Core.Global.ApplicationUser.GroupID
    Private _strUserName As String = PSS.Core.Global.ApplicationUser.User
    Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private _iEENum As Integer = PSS.Core.Global.ApplicationUser.NumberEmp
    Private _strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
    Private _iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    Private _iWHPallet_id As Integer = 0
    Private _iProd_ID As Integer = 5
    Private Const _iGamestopRefurbBillcode As Integer = 873
    Private Const _iCust_ID As Integer = 2219
    Private Const _iLoc_ID As Integer = 2743


#Region "Set Background color for control in focus"

    'Add color to control got focus
    Private Shared ctl As Control
    Private Shared HighLightColor As Color = Color.Yellow
    Private Shared WindowColor As Color = Color.White
    Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
    Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

    '*******************************************************************
    Private Shared Sub SetHandler(ByVal ctl As Control)
        AddHandler ctl.Enter, EnterHandler
        AddHandler ctl.Leave, LeaveHandler
        AddHandler ctl.Click, EnterHandler
    End Sub

    '*******************************************************************
    Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, HighLightColor)
    End Sub

    '*******************************************************************
    Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, WindowColor)
    End Sub

    '*******************************************************************
    Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
        Dim Type As String = sender.GetType.Name.ToString

        Select Case Type
            Case "ComboBox"
                CType(sender, ComboBox).BackColor = color
            Case "TextBox"
                CType(sender, TextBox).BackColor = color
            Case Else
                'no other types should be hightlighted.
        End Select
    End Sub

    '*******************************************************************

#End Region

    '**********************************************************************
    Protected Overrides Sub Finalize()
        Me._objWHRec = Nothing
        MyBase.Finalize()
    End Sub

    '**********************************************************************
    Private Sub CheckIfMachineTiedToLine()
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            dt1 = objMisc.CheckIfMachineTiedToLine(Me._strMachine)

            For Each R1 In dt1.Rows
                Me.lblGroup.Text = "Group: " & Trim(R1("Group_Desc"))
                Me.lblLineSide.Text = Trim(R1("Line_Number")) & " " & Trim(R1("LineSide_Desc"))
                Me.lblBin.Text = "BIN: " & Trim(R1("WC_Location"))
            Next R1

            Me.lblWorkDate.Text = "Work Date: " & Format(CDate(Me._strWorkDate), "MM/dd/yyyy")
            Me.lblUserName.Text = "User: " & Me._strUserName
            Me.lblShift.Text = "Shift: " & Me._iShiftID

        Catch ex As Exception
            Throw ex
        Finally
            objMisc = Nothing
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '**********************************************************************
    Private Sub frmWHRecWithoutFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Handlers to highlight in custom colors
            SetHandler(Me.cmbWHModel)
            SetHandler(Me.cmbWHRSku)
            SetHandler(Me.txtStagePallet)
            SetHandler(Me.txtStageDateCode)
            SetHandler(Me.txtStageDevSN)
            SetHandler(Me.txtWHRLotNum)
            SetHandler(Me.txtWHRPalletQty)

            CheckIfMachineTiedToLine()

            LoadModels()
            Me.lblWHRLotVal.Text = Format(CDate(Me._strWorkDate), "MMddyy")
            Me.LoadWHPallet(0, Me.lblWHRLotVal.Text.Trim)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


#Region "Warehouse Receive Tabpage"
    '**********************************************************************
    Private Sub tpWHRec_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpWHRec.VisibleChanged
        If sender.visible = True Then
            Me.LoadWHPallet(0, Me.lblWHRLotVal.Text.Trim)

            If Me.btnWHRUpdate.Visible = True Then
                '******************
                'Reset controls
                '******************
                Me.btnWHRCancelUpdate.Visible = False
                Me.btnWHRUpdate.Visible = False
                Me.btnWHRecPallet.Visible = True
                Me.btnWHRDelSelectedPallet.Visible = True
                Me.cmbWHModel.SelectedValue = 0
                Me.cmbWHRSku.SelectedValue = 0
                Me.lblWHRLotVal.Text = Format(CDate(Me._strWorkDate), "MMddyy")
                Me.txtWHRPalletQty.Text = ""
            End If

            Me.cmbWHModel.Focus()
            Me.lblMsg.Text = ""
            Me.lblMsg.BackColor = Color.LightSteelBlue
        End If
    End Sub

    '**********************************************************************
    Private Sub LoadModels()
        Dim objGen As New PSS.Data.Buisness.Generic()

        Try
            objGen.LoadModels(Me.cmbWHModel, 5)
        Catch ex As Exception
            Throw ex
        Finally
            objGen = Nothing
        End Try
    End Sub

    '**********************************************************************
    Private Sub LoadSku()
        Dim dtSku As New DataTable()
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Dim iSKU_ID As Integer = 0

        Try
            If Me.cmbWHModel.SelectedValue = 0 Then
                Throw New Exception("Please select model.")
            End If

            dtSku = objMisc.GetSku(Me._iCust_ID, Me.cmbWHModel.SelectedValue)

            If dtSku.Rows.Count = 1 Then
                iSKU_ID = dtSku.Rows(0)("Sku_ID")
            End If

            dtSku.LoadDataRow(New Object() {"0", "-- Select --"}, False)

            With Me.cmbWHRSku
                .DataSource = dtSku.DefaultView
                .DisplayMember = dtSku.Columns("Sku_Number").ToString
                .ValueMember = dtSku.Columns("Sku_ID").ToString
                .SelectedValue = iSKU_ID
            End With

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtSku) Then
                dtSku.Dispose()
                dtSku = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    '**********************************************************************
    Private Sub cmbWHModel_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWHModel.SelectionChangeCommitted
        Try
            If Not IsNothing(Me.cmbWHModel) Then
                If Me.cmbWHModel.SelectedValue > 0 Then
                    Me.LoadSku()
                    Me.cmbWHRSku.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Model Selection", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub

    '**********************************************************************
    Private Sub cmbWHRSku_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbWHRSku.SelectionChangeCommitted
        If Me.cmbWHRSku.Items.Count > 0 Then
            If Me.cmbWHRSku.SelectedValue > 0 Then
                Me.txtWHRPalletQty.Focus()
            End If
        End If
    End Sub

    '*******************************************************************************
    Private Sub txtWHRPalletQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWHRPalletQty.KeyPress
        If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    '**********************************************************************
    Private Sub txtWHRPalletQty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWHRPalletQty.KeyUp

        Try
            If e.KeyValue = 13 Then
                RecWHPallet()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Receive Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**********************************************************************
    Private Sub btnWHRecPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHRecPallet.Click
        Try
            RecWHPallet()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Receive Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**********************************************************************
    Private Sub RecWHPallet()
        Dim i As Integer = 0

        Try

            '**********************
            'Validate user input
            '**********************
            If Me.cmbWHModel.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Receive Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbWHModel.Focus()
                Exit Sub
            End If
            If Me.cmbWHRSku.SelectedValue = 0 Then
                MessageBox.Show("Please select SKU.", "Receive Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbWHRSku.Focus()
                Exit Sub
            End If
            If Me.txtWHRPalletQty.Text.Trim = "" Then
                MessageBox.Show("Please enter pallet quantity.", "Receive Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtWHRPalletQty.Focus()
                Exit Sub
            End If

            If Me.txtWHRPalletQty.Text.Trim = "0" Then
                MessageBox.Show("Cannot receive pallet with zero quantity.", "Receive Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtWHRPalletQty.Focus()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to receive a new warehouse pallet?", "Receive Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '**********************************************************
            'Insert warehouse pallet information into twarehousepallet
            '**********************************************************
            i = Me._objWHRec.CreateWHPallet(Me._iCust_ID, _
                                        Me.cmbWHModel.SelectedValue, _
                                        Me.cmbWHModel.Text, _
                                        Me.lblWHRLotVal.Text.Trim, _
                                        UCase(Trim(Me.cmbWHRSku.SelectedItem(Me.cmbWHRSku.DisplayMember))), _
                                        Me.cmbWHRSku.SelectedValue, _
                                        CInt(Me.txtWHRPalletQty.Text.Trim), _
                                        Me._strWorkDate)

            '***********************************
            'Display updated pallet information
            '***********************************
            Me.LoadWHPallet(Me.cmbWHModel.SelectedValue, Me.lblWHRLotVal.Text.Trim)
            Me.txtWHRPalletQty.Text = ""
            Me.txtWHRPalletQty.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Receive Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '**********************************************************************
    Private Sub btnWHRDelSelectedPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHRDelSelectedPallet.Click
        Dim i As Integer = 0

        Try
            '********************************
            'Validate data
            '********************************
            If Me.grdWHPallet.Columns.Count = 0 Then
                Exit Sub
            End If
            If Me.grdWHPallet.RowCount = 0 Then
                Exit Sub
            End If
            If CInt(Me.grdWHPallet.Columns("WHPallet_ID").Value) = 0 Then
                MessageBox.Show("Warehouse pallet ID is missing.", "Delete Warehouse Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.grdWHPallet.Columns("Pallet Closed").Value.ToString.ToUpper = "YES" Then
                MessageBox.Show("Pallet was closed.", "Delete Warehouse Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.grdWHPallet.Columns("Production Rec").Value.ToString.ToUpper = "YES" Then
                MessageBox.Show("Pallet was production received.", "Delete Warehouse Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            i = Me._objWHRec.GetTotalWHLoad(Me.grdWHPallet.Columns("WHPallet_ID").Value)
            If i > 0 Then
                MessageBox.Show("Pallet already stage received. To delete the pallet you must un-receive all devices first.", "Delete Warehouse Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '******************************
            'get confirm message from user
            If MessageBox.Show("Are you sure you want to delete the selected pallet?", "Delete Warehouse Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            i = 0

            Me.Enabled = False
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '******************************
            'delete pallet
            i = Me._objWHRec.DeleteEmptyPallet(Me.grdWHPallet.Columns("WHPallet_ID").Value)

            If i > 0 Then
                MessageBox.Show("Pallet has been deleted.", "Delete Warehouse Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            '******************************
            'reset controls and variable
            Me.LoadWHPallet(Me.cmbWHModel.SelectedValue, Me.lblWHRLotVal.Text.Trim)
            Me.txtWHRPalletQty.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Delete Empty Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadWHPallet(ByVal iModel As Integer, ByVal strLot As String)
        Dim dt1 As DataTable

        Try
            dt1 = Me._objWHRec.GetGSWHPalletByLot(Me._iCust_ID, strLot, iModel)
            Me.grdWHPallet.ClearFields()

            If dt1.Rows.Count > 0 Then
                Me.grdWHPallet.DataSource = dt1.DefaultView
                SetGridWHPProperties()
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message.ToString)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub SetGridWHPProperties()
        Dim iNumOfColumns As Integer = Me.grdStageDev.Columns.Count
        Dim i As Integer

        Try
            With Me.grdWHPallet

                For i = 0 To (iNumOfColumns - 1)
                    'Heading style (Horizontal Alignment to Center)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    'Set individual column data horizontal alignment
                    .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                'Set Column Widths
                .Splits(0).DisplayColumns("WHPallet").Width = 110
                .Splits(0).DisplayColumns("QTY").Width = 40
                .Splits(0).DisplayColumns("Lot").Width = 70
                .Splits(0).DisplayColumns("Skid").Width = 30
                .Splits(0).DisplayColumns("Sku").Width = 50
                .Splits(0).DisplayColumns("Model").Width = 70
                .Splits(0).DisplayColumns("PalletType").Width = 100
                .Splits(0).DisplayColumns("Pallet Closed").Width = 100
                .Splits(0).DisplayColumns("Production Rec").Width = 100

                'Make some columns invisible
                .Splits(0).DisplayColumns("WHPallet_ID").Visible = False
                .Splits(0).DisplayColumns("SKU_ID").Visible = False
                .Splits(0).DisplayColumns("Model_ID").Visible = False
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '**********************************************************************
    Private Sub btnWHRGetPalletByLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHRGetPalletByLot.Click
        Try
            If Me.txtWHRLotNum.Text.Trim = "" Then
                Exit Sub
            End If

            Me.LoadWHPallet(0, Me.txtWHRLotNum.Text.Trim)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**********************************************************************
    Private Sub txtWHRLotNum_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWHRLotNum.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Me.txtWHRLotNum.Text.Trim = "" Then
                    Exit Sub
                End If

                Me.LoadWHPallet(0, Me.txtWHRLotNum.Text.Trim)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************************
    Private Sub txtWHRLotNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWHRLotNum.KeyPress
        If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    '**********************************************************************
    Private Sub btnWHRPopulateData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHRPopulateData.Click
        Try
            '********************************
            'Validate data
            '********************************
            If Me.grdWHPallet.Columns.Count = 0 Then
                Exit Sub
            End If
            If Me.grdWHPallet.RowCount = 0 Then
                Exit Sub
            End If
            If CInt(Me.grdWHPallet.Columns("WHPallet_ID").Value) = 0 Then
                MessageBox.Show("Please select pallet.", "Populate Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.grdWHPallet.Columns("Pallet Closed").Value.ToString = "YES" Then
                MessageBox.Show("Pallet was closed.", "Populate Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.grdWHPallet.Columns("Production Rec").Value.ToString = "YES" Then
                MessageBox.Show("Pallet was production received.", "Populate Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.cmbWHModel.SelectedValue = Me.grdWHPallet.Columns("Model_ID").Value
            Me.LoadSku()
            Me.cmbWHRSku.SelectedValue = Me.grdWHPallet.Columns("SKU_ID").Value
            Me.lblWHRLotVal.Text = Me.grdWHPallet.Columns("Lot").Value
            Me.txtWHRPalletQty.Text = Me.grdWHPallet.Columns("QTY").Value

            Me.btnWHRecPallet.Visible = False
            Me.btnWHRDelSelectedPallet.Visible = False
            Me.btnWHRCancelUpdate.Visible = True
            Me.btnWHRUpdate.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**********************************************************************
    Private Sub btnWHRCancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHRCancelUpdate.Click
        Try
            Me.btnWHRecPallet.Visible = True
            Me.btnWHRDelSelectedPallet.Visible = True
            Me.btnWHRCancelUpdate.Visible = False
            Me.btnWHRUpdate.Visible = False

            Me.cmbWHModel.SelectedValue = 0
            Me.cmbWHRSku.SelectedValue = 0
            Me.lblWHRLotVal.Text = Format(CDate(Me._strWorkDate), "MMddyy")
            Me.txtWHRPalletQty.Text = ""
            Me.cmbWHModel.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**********************************************************************
    Private Sub btnWHRUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWHRUpdate.Click
        Try
            If MessageBox.Show("Are you sure you want update selected pallet with the input information?", "Update Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            '**********************
            'Validate user input
            '**********************
            If CInt(Me.grdWHPallet.Columns("WHPallet_ID").Value) = 0 Then
                MessageBox.Show("Warehouse pallet ID is missing.", "Update Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.cmbWHModel.SelectedValue = 0 Then
                MessageBox.Show("Please select Model to update.", "Update Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbWHModel.Focus()
                Exit Sub
            End If
            If Me.cmbWHRSku.SelectedValue = 0 Then
                MessageBox.Show("Please select SKU to update.", "Update Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbWHRSku.Focus()
                Exit Sub
            End If
            If Me.txtWHRPalletQty.Text.Trim = "" Then
                MessageBox.Show("Please enter pallet quantity to update.", "Update Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtWHRPalletQty.Focus()
                Exit Sub
            End If

            If Me.txtWHRPalletQty.Text.Trim = "0" Then
                MessageBox.Show("Pallet quantity cannot be zero.", "Update Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtWHRPalletQty.Focus()
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '**********************************************************
            'Insert warehouse pallet information into twarehousepallet
            '**********************************************************
            Me._objWHRec.UpdateWHPallet(Me.grdWHPallet.Columns("WHPallet_ID").Value, _
                                        Me.grdWHPallet.Columns("WHPallet").Value, _
                                        Me.cmbWHModel.SelectedValue, _
                                        Me.cmbWHModel.Text.Trim, _
                                        Me.cmbWHRSku.SelectedValue, _
                                        Me.cmbWHRSku.Text, _
                                        CInt(Me.txtWHRPalletQty.Text.Trim))

            '******************
            'Reset controls
            '******************
            Me.btnWHRCancelUpdate.Visible = False
            Me.btnWHRUpdate.Visible = False
            Me.btnWHRecPallet.Visible = True
            Me.btnWHRDelSelectedPallet.Visible = True
            Me.cmbWHModel.SelectedValue = 0
            Me.cmbWHRSku.SelectedValue = 0
            Me.lblWHRLotVal.Text = Format(CDate(Me._strWorkDate), "MMddyy")
            Me.txtWHRPalletQty.Text = ""
            Me.cmbWHModel.Focus()

            '***********************************
            'Display updated pallet information
            '***********************************
            Me.LoadWHPallet(Me.cmbWHModel.SelectedValue, Me.lblWHRLotVal.Text.Trim)
            Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '**********************************************************************
    Private Sub grdWHPallet_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdWHPallet.RowColChange
        If Me.btnWHRUpdate.Visible = True Then
            '******************
            'Reset controls
            '******************
            Me.btnWHRCancelUpdate.Visible = False
            Me.btnWHRUpdate.Visible = False
            Me.btnWHRecPallet.Visible = True
            Me.btnWHRDelSelectedPallet.Visible = True
            Me.cmbWHModel.SelectedValue = 0
            Me.cmbWHRSku.SelectedValue = 0
            Me.lblWHRLotVal.Text = Format(CDate(Me._strWorkDate), "MMddyy")
            Me.txtWHRPalletQty.Text = ""
            Me.cmbWHModel.Focus()
        End If
    End Sub

    '**********************************************************************

#End Region

#Region "Stage Receive Tabpage"

    '**********************************************************************
    Private Sub tpStageRec_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpStageRec.VisibleChanged
        If sender.visible = True Then
            If Me._iMachineGroupID <> 14 And Me._iMachineGroupID <> 78 Then
                Me.tpStageRec.Visible = False
            Else
                Me.txtStagePallet.Focus()
            End If
        End If
    End Sub

    '**********************************************************************
    Private Sub txtPallet_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStagePallet.KeyUp
        Try
            If e.KeyValue = 13 Then
                ProcessPallet_Stage()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Get Pallet Name", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**********************************************************************
    Private Sub ProcessPallet_Stage()
        Dim dt1 As DataTable
        Dim i As Integer = 0

        Try
            '***************************
            'reset variable and controls
            '***************************
            Me.txtStageDateCode.Text = ""
            Me.txtStageDevSN.Text = ""
            Me.lblStageScanQtyVal.Text = "0"
            Me.lblMsg.Text = ""
            Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
            Me.btnStageClosePallet.Enabled = False
            Me.btnStageUnRcvdDev.Enabled = False
            Me.grdStageDev.ClearFields()
            Me._iWHPallet_id = 0

            Me.lblStageModel.Visible = False
            Me.lblStageModelVal.Text = ""
            Me.lblStageLot.Visible = False
            Me.lblStageLotVal.Text = ""
            Me.lblStageSkid.Visible = False
            Me.lblStageSkidVal.Text = ""
            Me.lblStageSku.Visible = False
            Me.lblStageSkuVal.Text = ""
            Me.lblStagePalletQty.Visible = False
            Me.lblStagePalletQtyVal.Text = ""
            Me.lblStageDateCode.Visible = False
            Me.txtStageDateCode.Visible = False

            '***************************
            'validate user input
            '***************************
            If Trim(Me.txtStagePallet.Text) = "" Then
                Exit Sub
            End If

            '***************************
            'get pallet info if existed
            '***************************
            dt1 = Me._objWHRec.GetWHPalletInfo(Trim(Me.txtStagePallet.Text), Me._iCust_ID)
            If IsNothing(dt1) Or dt1.Rows.Count = 0 Then
                MessageBox.Show("Pallet does not exist.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtStagePallet.SelectAll()
                Exit Sub
            End If

            '***************************
            'validate existed pallet
            '***************************
            If Not IsDBNull(dt1.Rows(0)("WHPalletClosed")) Then
                If dt1.Rows(0)("WHPalletClosed") = 1 Then
                    MessageBox.Show("Pallet was closed.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStagePallet.SelectAll()
                    Exit Sub
                End If
            End If
            If Not IsDBNull(dt1.Rows(0)("WHP_PalletRcvd")) Then
                If dt1.Rows(0)("WHP_PalletRcvd") = 1 Then
                    MessageBox.Show("Pallet was production received.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStagePallet.SelectAll()
                    Exit Sub
                End If
            End If

            'display pallet information into controls
            If Not IsDBNull(dt1.Rows(0)("WHPallet_id")) Then
                Me._iWHPallet_id = dt1.Rows(0)("WHPallet_id")
                Me.LoadReceivedDevices()
            End If

            If Not IsDBNull(dt1.Rows(0)("Model_Desc")) Then
                Me.lblStageModelVal.Text = dt1.Rows(0)("Model_Desc").ToString
                Me.lblStageModelVal.Tag = dt1.Rows(0)("Model_ID").ToString
                Me.lblStageModel.Visible = True
                If dt1.Rows(0)("Model_ID") = 881 Or dt1.Rows(0)("Model_ID") = 1112 Then
                    Me.txtStageDateCode.Visible = True
                    Me.lblStageDateCode.Visible = True
                    Me.lblStageDateCode.Text = "Date Code:"
                ElseIf dt1.Rows(0)("Model_ID") = 1175 Then
                    Me.txtStageDateCode.Visible = True
                    Me.lblStageDateCode.Visible = True
                    Me.lblStageDateCode.Text = "Tech Code:"
                End If
            End If

            If Not IsDBNull(dt1.Rows(0)("WHP_Lot")) Then
                Me.lblStageLotVal.Text = dt1.Rows(0)("WHP_Lot").ToString
                Me.lblStageLot.Visible = True
            End If

            If Not IsDBNull(dt1.Rows(0)("WHP_Skid")) Then
                Me.lblStageSkidVal.Text = dt1.Rows(0)("WHP_Skid").ToString
                Me.lblStageSkid.Visible = True
            End If

            If Not IsDBNull(dt1.Rows(0)("WHP_SKU")) Then
                Me.lblStageSkuVal.Text = dt1.Rows(0)("WHP_SKU").ToString
                Me.lblStageSku.Visible = True
            End If

            If Not IsDBNull(dt1.Rows(0)("WHP_FileQty")) Then
                Me.lblStagePalletQtyVal.Text = dt1.Rows(0)("WHP_FileQty").ToString
                Me.lblStagePalletQty.Visible = True
            End If

            Me.txtStageDevSN.Focus()
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '**********************************************************************
    Private Function ValidateWHPallet() As Boolean
        Dim dt1 As DataTable
        Dim bReturnVal As Boolean = False

        Try
            '***************************
            'get pallet info if existed
            '***************************
            dt1 = Me._objWHRec.GetWHPalletInfo(Trim(Me.txtStagePallet.Text), Me._iCust_ID)
            If IsNothing(dt1) Or dt1.Rows.Count = 0 Then
                MessageBox.Show("Pallet does not exist.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtStagePallet.SelectAll()
                Return bReturnVal
            End If

            '***************************
            'validate existed pallet
            '***************************
            If Not IsDBNull(dt1.Rows(0)("WHPalletClosed")) Then
                If dt1.Rows(0)("WHPalletClosed") = 1 Then
                    MessageBox.Show("Pallet was closed.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStagePallet.SelectAll()
                    Return bReturnVal
                End If
            End If
            If Not IsDBNull(dt1.Rows(0)("WHP_PalletRcvd")) Then
                If dt1.Rows(0)("WHP_PalletRcvd") = 1 Then
                    MessageBox.Show("Pallet was production received.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStagePallet.SelectAll()
                    Return bReturnVal
                End If
            End If

            bReturnVal = True

            Return bReturnVal
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Function

    '**********************************************************************
    Private Sub txtStageDevSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStageDevSN.KeyUp

        Try
            If e.KeyValue = 13 Then
                If Me.txtStagePallet.Text.Trim = "" Then
                    MessageBox.Show("Please enter pallet.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStagePallet.Focus()
                ElseIf Me.txtStageDevSN.Text.Trim = "" Then
                    'Do nothing
                ElseIf (Me.lblStageModelVal.Tag = 881 Or Me.lblStageModelVal.Tag = 1112) And Me.txtStageDevSN.Text.Trim.Length < 10 Or Me.txtStageDevSN.Text.Trim.Length > 16 Then
                    MessageBox.Show("The length of SN can't less than 10 or greater than 16 characters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStageDevSN.SelectAll()
                ElseIf Me.SNContainSpecialCharacter() = True Then
                    MessageBox.Show("SN can't contain any special characters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStageDevSN.SelectAll()
                ElseIf (Me.lblStageModelVal.Tag = 881 Or Me.lblStageModelVal.Tag = 1112) Then
                    Me.txtStageDateCode.SelectAll()
                    Me.txtStageDateCode.Focus()
                ElseIf Me.lblStageModelVal.Tag = 1175 AndAlso Me.txtStageDevSN.Text.Trim.Length <> 12 Then
                    MessageBox.Show("SN must be 12 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStageDevSN.SelectAll()
                ElseIf Me.lblStageModelVal.Tag = 1175 AndAlso Me.ValidateXB360SN() = False Then
                    MessageBox.Show("SN must be 12 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStageDevSN.SelectAll()
                ElseIf Me.lblStageModelVal.Tag = 1183 AndAlso Me.ValidateNTDSSN() = False Then
                    MessageBox.Show("SN must be 11 characters containing 2 alpha and 9 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStageDevSN.SelectAll()
                Else
                    'If CInt(Mid(Me.txtStageDevSN.Text.Trim, 8, 1)) <= 5 Then MessageBox.Show("This unit was made before year 2005.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.ProcessSN_Gamestop()
                    Me.txtStageDevSN.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Scan Device SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtStageDevSN.Text = ""
        End Try
    End Sub

    '**********************************************************************
    Private Function ValidateXB360SN() As Boolean
        Dim strSN As String = Me.txtStageDevSN.Text.Trim.ToUpper
        Dim i As Integer = 0
        Dim cSNChar As Char = Nothing
        Dim booResult As Boolean = True

        Try
            For i = 1 To strSN.Length
                cSNChar = CChar(Mid(strSN, i, 1))
                If Char.IsDigit(cSNChar) = False Then
                    booResult = False
                    Exit For
                End If
            Next i

            Return booResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '**********************************************************************
    Private Function ValidateNTDSSN() As Boolean
        Dim strSN As String = Me.txtStageDevSN.Text.Trim.ToUpper
        Dim i As Integer = 0
        Dim cSNChar As Char = Nothing
        Dim iDigits, iAlpha As Integer


        Try
            iDigits = 0 : iAlpha = 0
            For i = 1 To strSN.Length
                cSNChar = CChar(Mid(strSN, i, 1))
                If Char.IsDigit(cSNChar) = True Then
                    iDigits += 1
                ElseIf Char.IsLetter(cSNChar) = True Then
                    iAlpha += 1
                End If
            Next i

            If iDigits = 9 AndAlso iAlpha = 2 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '**********************************************************************
    Private Function SNContainSpecialCharacter() As Boolean
        Dim strSN As String = Me.txtStageDevSN.Text.Trim.ToUpper
        Dim i As Integer = 0
        Dim cSNChar As Char = Nothing

        Try
            For i = 1 To strSN.Length
                cSNChar = CChar(Mid(strSN, i, 1))
                If Char.IsLetterOrDigit(cSNChar) = False Or Char.IsPunctuation(cSNChar) = True Then
                    Return True
                End If
            Next i
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '**********************************************************************
    Private Sub txtStageDateCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStageDateCode.KeyPress
        If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    '**********************************************************************
    Private Sub txtStageDateCode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStageDateCode.KeyUp
        If e.KeyValue = 13 Then
            If Me.txtStagePallet.Text.Trim = "" Then
                MessageBox.Show("Please enter pallet.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtStagePallet.Focus()
                Exit Sub
            ElseIf Me.txtStageDevSN.Text.Trim = "" Then
                Exit Sub
            ElseIf (Me.lblStageModelVal.Tag = 881 Or Me.lblStageModelVal.Tag = 1112) And Me.txtStageDevSN.Text.Trim.Length < 10 Or Me.txtStageDevSN.Text.Trim.Length > 16 Then
                MessageBox.Show("The length of SN can't less than 10 or greater than 16 characters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtStageDevSN.SelectAll()
                Exit Sub
            ElseIf Me.SNContainSpecialCharacter() = True Then
                MessageBox.Show("SN can't contain any special characters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtStageDevSN.SelectAll()
                Me.txtStageDevSN.Focus()
                Exit Sub
            Else
                Me.ProcessSN_Gamestop()
                Me.txtStageDevSN.Focus()
            End If
        End If
    End Sub

    '**********************************************************************
    Private Sub ProcessSN_Gamestop()
        Dim i As Integer = 0
        Dim iHasNoBox As Integer = 0
        Dim dt1 As DataTable
        Dim strLot As String = ""
        Dim strPartialSN As String = ""
        Dim iModel_ID As Integer = 0

        Try
            '***************************
            '1::Validation 
            '***************************
            If Me.txtStageDevSN.Text.Trim = "" Then
                Exit Sub
            End If

            If Trim(Me.txtStagePallet.Text) = "" Then
                MessageBox.Show("Please enter Pallet Name.", "Missing Pallet Name", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtStageDevSN.Text = ""
                Me.txtStagePallet.Focus()
                Exit Sub
            End If

            If Me._iWHPallet_id = 0 Then
                MessageBox.Show("Warehouse Pallet ID is missing.", "Missing Pallet ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtStageDevSN.Text = ""
                Me.txtStagePallet.Focus()
                Exit Sub
            End If

            If CInt(Me.lblStageScanQtyVal.Text.Trim) >= (Me.lblStagePalletQtyVal.Text.Trim) Then
                MessageBox.Show("You have already reached the pallet quantity. Please contact your supervisor for advice on how to receive discrepancy devices.", "Verify Pallet Qty", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.lblMsg.Text = "REJECT"
                Me.lblMsg.BackColor = System.Drawing.Color.Red
                Me.txtStageDevSN.SelectAll()
                Exit Sub
            End If

            If Me.txtStageDevSN.Text.Trim.Length <= 4 Then
                MessageBox.Show("The length of SN is too short please verify it.", "SN Lenghth", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.lblMsg.Text = "REJECT"
                Me.lblMsg.BackColor = System.Drawing.Color.Red
                Me.txtStageDevSN.SelectAll()
                Exit Sub
            End If

            '****************************************
            'Special validation of PSP SN
            '****************************************
            If CInt(Me.lblStageModelVal.Tag) = 1039 Then
                If Me.txtStageDevSN.Text.Trim.Length <> 10 Then
                    MessageBox.Show("The length of SN must be 10 characters.", "SN Lenghth", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.lblMsg.Text = "REJECT"
                    Me.lblMsg.BackColor = System.Drawing.Color.Red
                    Me.txtStageDevSN.SelectAll()
                    Exit Sub
                End If
                If Microsoft.VisualBasic.Left(Me.txtStageDevSN.Text.Trim.ToUpper, 4) <> "PSSI" Then
                    MessageBox.Show("SN Must start with ""PSSI"" and follow by 6 diggits number.", "SN Lenghth", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.lblMsg.Text = "REJECT"
                    Me.lblMsg.BackColor = System.Drawing.Color.Red
                    Me.txtStageDevSN.SelectAll()
                    Exit Sub
                End If

                strPartialSN = Microsoft.VisualBasic.Right(Me.txtStageDevSN.Text.Trim, 6)
                For i = 0 To strPartialSN.Length - 1
                    If Char.IsDigit(strPartialSN.Chars(i)) = False Then
                        MessageBox.Show("SN Must start with ""PSSI"" and follow by 6 diggits number.", "SN Lenghth", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.lblMsg.Text = "REJECT"
                        Me.lblMsg.BackColor = System.Drawing.Color.Red
                        Me.txtStageDevSN.SelectAll()
                        Exit Sub
                    End If
                Next i
            End If

            '****************************************
            'Date Code check for Xbox and XboxGFI
            '****************************************
            If CInt(Me.lblStageModelVal.Tag) = 881 Or CInt(Me.lblStageModelVal.Tag) = 1112 Then
                lblStageDateCode.Text = "Date code"
                If Me.txtStageDateCode.Text.Trim.Length <> 4 Then
                    MessageBox.Show("Please enter 4 digits of date code.", "Date Code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.lblMsg.Text = "REJECT"
                    Me.lblMsg.BackColor = System.Drawing.Color.Red
                    Me.txtStageDevSN.SelectAll()
                    Exit Sub
                End If
                iModel_ID = Me.GetModelFromDateCode(Me.txtStageDateCode.Text.Trim)
                'ElseIf CInt(Me.lblStageModelVal.Tag) = 1175 Then
                '    lblStageDateCode.Text = "Tech code"
                '    iModel_ID = CInt(Me.lblStageModelVal.Tag)
            Else
                iModel_ID = CInt(Me.lblStageModelVal.Tag)
            End If
            '****************************************
            'Re-validate pallet again
            '****************************************
            If Me.ValidateWHPallet = False Then
                Exit Sub
            End If
            '****************************************

            i = 0

            '*************************************
            '2::Check if device in Production WIP
            '*************************************
            dt1 = Me._objWHRec.CheckDevInWIP(UCase(Trim(Me.txtStageDevSN.Text)), _
                                             iModel_ID, _
                                             Me._iCust_ID)
            If dt1.Rows.Count > 0 Then
                MessageBox.Show("This device is already in production WIP.", "Validate SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.lblMsg.Text = "REJECT"
                Me.lblMsg.BackColor = System.Drawing.Color.Red
                Me.txtStageDevSN.SelectAll()
                Exit Sub
            End If

            '****************************************************
            '3::Check if device in Production WIP
            '****************************************************
            Me._objWHRec.IsDupl_WarehouseBucket(UCase(Trim(Me.txtStageDevSN.Text)), _
                                                Me._iCust_ID, _
                                                iModel_ID, _
                                                Me.txtStagePallet.Text.Trim)
            '****************************************************
            '4::Receive Device into warehouse bucket
            '****************************************************
            i = Me._objWHRec.LoadDeviceIntoWH(Me._iWHPallet_id, _
                                             Me._iMachineGroupID, _
                                             Me._iUserID, _
                                             Me.txtStageDateCode.Text.Trim, _
                                             iModel_ID, _
                                             UCase(Trim(Me.lblStageLotVal.Text)), _
                                             UCase(Trim(Me.lblStageSkidVal.Text)), _
                                             UCase(Trim(Me.lblStageSkuVal.Text)), _
                                             UCase(Trim(Me.txtStageDevSN.Text)), _
                                             Me._iGamestopRefurbBillcode)
            '****************************************************
            'Load received device into datagrid
            '****************************************************
            Me.LoadReceivedDevices()
            '****************************************************
            Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
            Me.lblMsg.Text = "ACCEPT"
            '****************************************************
            Me.txtStageDateCode.Text = ""
            Me.txtStageDevSN.Text = ""
            Me.txtStageDevSN.Focus()
            '****************************************************
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Function GetModelFromDateCode(ByVal strDateCode As String) As Integer
        Dim iYear As Integer = 0
        Dim iMonth As Integer = 0
        Dim iModel_ID As Integer = 0

        Try
            If strDateCode = "0000" Then
                iModel_ID = 1112
            Else
                If Mid(strDateCode, 3, 1) = 9 Then
                    iYear = CInt("19" & Microsoft.VisualBasic.Right(strDateCode, 2))
                Else
                    iYear = CInt("20" & Microsoft.VisualBasic.Right(strDateCode, 2))
                End If

                If iYear < 1997 Or iYear > Year(Now()) Then
                    Throw New Exception("Invalid manufacture year.")
                End If

                iMonth = CInt(Microsoft.VisualBasic.Left(strDateCode, 2))
                If (iMonth < 12 And iYear = 2002) Or iYear < 2002 Then
                    iModel_ID = 1112
                Else
                    iModel_ID = 881
                End If
            End If

            Return iModel_ID
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '*********************************************************
    Private Sub LoadReceivedDevices()
        Dim dt1 As DataTable

        Try
            If Me._iWHPallet_id = 0 Then
                Exit Sub
            End If

            dt1 = Me._objWHRec.LoadRcvdDev(Me._iWHPallet_id)
            Me.grdStageDev.ClearFields()

            If dt1.Rows.Count > 0 Then
                Me.grdStageDev.DataSource = dt1.DefaultView
                SetGridStageDevProperties()
                Me.btnStageUnRcvdDev.Enabled = True
                Me.btnStageClosePallet.Enabled = True
                Me.lblStageScanQtyVal.Text = dt1.Rows.Count
            Else
                Me.btnStageUnRcvdDev.Enabled = False
                Me.btnStageClosePallet.Enabled = False
                Me.lblStageScanQtyVal.Text = "0"
            End If

        Catch ex As Exception
            Throw New Exception("LoadReceivedDevices(): " & Environment.NewLine & ex.Message.ToString)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub SetGridStageDevProperties()
        Dim iNumOfColumns As Integer = Me.grdStageDev.Columns.Count
        Dim i As Integer


        With grdStageDev
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns("Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Set Column Widths
            .Splits(0).DisplayColumns(2).Width = 110
            .Splits(0).DisplayColumns("Model").Width = 150

            'Make some columns invisible
            .Splits(0).DisplayColumns(0).Visible = False
            .Splits(0).DisplayColumns(1).Visible = False
            .Splits(0).DisplayColumns("Model_ID").Visible = False
        End With
    End Sub

    '**********************************************************************
    Private Sub btnStageClosePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStageClosePallet.Click
        Dim iTotalRcvd As Integer = 0
        Dim i As Integer = 0
        Dim iPallet_Discrepancy As Integer = 0

        Try
            If Me.txtStagePallet.Text = "" Then
                Me.txtStagePallet.SelectAll()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to close this pallet?", "Close pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Me.btnStageClosePallet.Enabled = False

                '********************************
                'Validate data
                '********************************
                If Me._iWHPallet_id = 0 Then
                    MessageBox.Show("WHPallet ID is not defined.", "Validate Pallet ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStagePallet.SelectAll()
                    Exit Sub
                End If

                If Me.lblStageScanQtyVal.Text = "0" Then
                    MessageBox.Show("This pallet is empty.", "Pallet QTY", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStageDevSN.SelectAll()
                    Exit Sub
                End If

                iTotalRcvd = CInt(Trim(Me.lblStageScanQtyVal.Text))

                If iTotalRcvd = 0 Then
                    MessageBox.Show("This pallet is empty.", "Pallet QTY", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtStageDevSN.SelectAll()
                    Exit Sub
                End If

                If (Me.lblStagePalletQtyVal.Text.Trim) < CInt(Me.lblStageScanQtyVal.Text.Trim) Then
                    MessageBox.Show("You have scanned more device(s) into the pallet than the count quantity. Please remove them before close the pallet. ", "Verify Pallet Qty", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    Me.txtStageDevSN.SelectAll()
                    Exit Sub
                End If

                If (Me.lblStagePalletQtyVal.Text.Trim) <> CInt(Me.lblStageScanQtyVal.Text.Trim) Then
                    If MessageBox.Show("You are about to close a pallet discrepancy quantity. Do you want to continue?", "Verify Pallet Qty", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        Me.txtStageDevSN.SelectAll()
                        Exit Sub
                    End If
                    iPallet_Discrepancy = 1
                End If

                '**************************
                'Re-validate pallet again
                '**************************
                If Me.ValidateWHPallet = False Then
                    Exit Sub
                End If
                '**************************

                Me.Enabled = False
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                '********************************
                'Close pallet
                '********************************
                i = Me._objWHRec.CloseWHPallet(UCase(Trim(Me.txtStagePallet.Text)), _
                                              Me._iWHPallet_id, _
                                              iTotalRcvd, _
                                              CInt(Me.lblStagePalletQtyVal.Text.Trim), _
                                              Me._iCust_ID, _
                                              Me._iLoc_ID, _
                                              Me._iProd_ID, _
                                              Me._iMachineGroupID, _
                                              Me._iShiftID, _
                                              Me._iEENum, _
                                              Me._iUserID, _
                                              Me._strUserName, _
                                              Me._strWorkDate, _
                                              Me.grdStageDev.DataSource, _
                                              iPallet_Discrepancy, _
                                              Me.lblStageModelVal.Text.Trim)
                '********************************
                'display confirm message
                '********************************
                If i = 0 Then
                    Throw New Exception("There was a problem closing out the pallet. Contact Administrator.")
                Else
                    MessageBox.Show("Pallet is closed.", "Close Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    '********************************
                    'clear controls and global variable
                    '********************************
                    Me.lblStageModel.Visible = False
                    Me.lblStageModelVal.Text = ""
                    Me.lblStageLot.Visible = False
                    Me.lblStageLotVal.Text = ""
                    Me.lblStageSkid.Visible = False
                    Me.lblStageSkidVal.Text = ""
                    Me.lblStageSku.Visible = False
                    Me.lblStageSkuVal.Text = ""
                    Me.lblStagePalletQty.Visible = False
                    Me.lblStagePalletQtyVal.Text = ""
                    Me.lblStageDateCode.Visible = False
                    Me.txtStageDateCode.Visible = False

                    Me.txtStagePallet.Text = ""
                    Me.txtStageDateCode.Text = ""
                    Me.txtStageDevSN.Text = ""
                    Me.lblStageScanQtyVal.Text = "0"
                    Me.lblMsg.Text = ""
                    Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
                    Me.btnStageClosePallet.Enabled = False
                    Me.btnStageUnRcvdDev.Enabled = False
                    Me.grdStageDev.ClearFields()
                    Me._iWHPallet_id = 0
                    Me.txtStagePallet.Focus()
                    '********************************
                End If

            Else
                Me.txtStageDevSN.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("cmdClosePallet_Click: " & Environment.NewLine & ex.Message.ToString, "Scan Device SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.txtStageDevSN.Focus()
        End Try
    End Sub

    '**********************************************************************
    Private Sub btnStageUnRcvdDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStageUnRcvdDev.Click
        Dim i As Integer = 0
        Dim strUnRecSN As String = ""
        Dim dv As DataView
        Dim iWHP_ID As Integer = 0
        Dim iWHR_ID As Integer = 0

        Try
            '********************************
            'restet controls
            '********************************
            Me.txtStageDateCode.Text = ""
            Me.txtStageDevSN.Text = ""

            '********************************
            'Validate data
            '********************************
            If Me.grdStageDev.Columns.Count = 0 Then
                Exit Sub
            End If
            If Me.grdStageDev.RowCount = 0 Then
                Exit Sub
            End If

            '********************************
            'Get SN
            '********************************
            strUnRecSN = InputBox("Scan device SN:", "SN").Trim.ToUpper
            If strUnRecSN = "" Then
                MessageBox.Show("You must enter device SN to perform this task.", "Delete Received Device", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            dv = Me.grdStageDev.DataSource
            If dv.Table.Select("[Device SN] = '" & strUnRecSN & "'").Length = 0 Then
                MessageBox.Show("SN was not listed.", "Delete Received Device", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                iWHP_ID = dv.Table.Select("[Device SN] = '" & strUnRecSN & "'")(0)("WHP_ID")
                iWHR_ID = dv.Table.Select("[Device SN] = '" & strUnRecSN & "'")(0)("WHR_ID")
            End If

            If iWHP_ID = 0 Or iWHR_ID = 0 Then
                MessageBox.Show("Can't define warehouse ID.", "Delete Received Device", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            ''********************************
            Me.btnStageUnRcvdDev.Enabled = False

            '********************************
            'Unreceive device
            '********************************
            If MessageBox.Show("Are you sure you want to Un-Receive the SN (" & Me.grdStageDev.Columns("Device SN").Value & ")?", "Delete Descrepancy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                i = Me._objWHRec.DeleteRcvdDev(iWHP_ID, iWHR_ID)

                If i = 0 Then
                    MessageBox.Show("Device was not Un-Received.", "Delete Received Device", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                Me.LoadReceivedDevices()
            End If

            '******************************************************
        Catch ex As Exception
            Me.btnStageUnRcvdDev.Enabled = True
            MsgBox("cmdDelRcvdDev_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Dock Receiving")
        Finally
            If Not IsNothing(dv) Then
                dv.Dispose()
                dv = Nothing
            End If
            Me.txtStageDevSN.Focus()
        End Try
    End Sub

    '**********************************************************************

#End Region


End Class
