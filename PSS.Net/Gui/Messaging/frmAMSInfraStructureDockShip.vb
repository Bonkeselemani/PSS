Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmAMSInfraStructureDockShip
    Inherits System.Windows.Forms.Form

    Private _objAMSInfraStructure As AMSInfraStructure
    Private _iMachineCC_GrpID As Integer = 0

    Private _iWOID As Integer = 0
    Private _iTrayID As Integer = 0
    Private _iCameWithFile As Integer = 0
    Private _booDiscrepancy As Boolean
    Private _iMenuCustID As Integer = 0
    Private _strTabPageTitle As String
    Private _iDefaultDataDays As Integer = 30

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strTabPageTitle As String, ByVal iCustID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _strTabPageTitle = strTabPageTitle
        _iMenuCustID = iCustID
        _objAMSInfraStructure = New AMSInfraStructure()

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
    Friend WithEvents lblBin As System.Windows.Forms.Label
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblScreenName As System.Windows.Forms.Label
    Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
    Friend WithEvents btnRecreateManifest As System.Windows.Forms.Button
    Friend WithEvents btnDeleteBox As System.Windows.Forms.Button
    Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnReopenBox As System.Windows.Forms.Button
    Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
    Friend WithEvents panelPallet As System.Windows.Forms.Panel
    Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCloseBox As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblBoxName As System.Windows.Forms.Label
    Friend WithEvents pnlShipType As System.Windows.Forms.Panel
    Friend WithEvents cboBoxTypes As C1.Win.C1List.C1Combo
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btnCreateBoxID As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAMSInfraStructureDockShip))
        Me.lblBin = New System.Windows.Forms.Label()
        Me.lblLineSide = New System.Windows.Forms.Label()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.PanelPalletList = New System.Windows.Forms.Panel()
        Me.btnRecreateManifest = New System.Windows.Forms.Button()
        Me.btnDeleteBox = New System.Windows.Forms.Button()
        Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnReopenBox = New System.Windows.Forms.Button()
        Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
        Me.panelPallet = New System.Windows.Forms.Panel()
        Me.txtDevSN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCloseBox = New System.Windows.Forms.Button()
        Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
        Me.btnRemoveSN = New System.Windows.Forms.Button()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBoxName = New System.Windows.Forms.Label()
        Me.pnlShipType = New System.Windows.Forms.Panel()
        Me.cboBoxTypes = New C1.Win.C1List.C1Combo()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnCreateBoxID = New System.Windows.Forms.Button()
        Me.PanelPalletList.SuspendLayout()
        CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPallet.SuspendLayout()
        Me.pnlShipType.SuspendLayout()
        CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBin
        '
        Me.lblBin.Name = "lblBin"
        Me.lblBin.TabIndex = 0
        '
        'lblLineSide
        '
        Me.lblLineSide.Name = "lblLineSide"
        Me.lblLineSide.TabIndex = 0
        '
        'lblMachine
        '
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.TabIndex = 0
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(8, 4)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(146, 16)
        Me.lblGroup.TabIndex = 91
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine
        '
        Me.lblLine.BackColor = System.Drawing.Color.Transparent
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.ForeColor = System.Drawing.Color.Lime
        Me.lblLine.Location = New System.Drawing.Point(8, 25)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(146, 16)
        Me.lblLine.TabIndex = 90
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(376, 25)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(178, 16)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(376, 46)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(178, 16)
        Me.lblWorkDate.TabIndex = 84
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(376, 4)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(178, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScreenName
        '
        Me.lblScreenName.BackColor = System.Drawing.Color.Black
        Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(728, 40)
        Me.lblScreenName.TabIndex = 118
        Me.lblScreenName.Text = "AMS InfraStructure Dock Ship Box"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelPalletList
        '
        Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRecreateManifest, Me.btnDeleteBox, Me.dbgPallets, Me.btnReopenBox, Me.btnReprintBoxLabel})
        Me.PanelPalletList.Location = New System.Drawing.Point(0, 144)
        Me.PanelPalletList.Name = "PanelPalletList"
        Me.PanelPalletList.Size = New System.Drawing.Size(319, 328)
        Me.PanelPalletList.TabIndex = 119
        '
        'btnRecreateManifest
        '
        Me.btnRecreateManifest.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnRecreateManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecreateManifest.ForeColor = System.Drawing.Color.Black
        Me.btnRecreateManifest.Location = New System.Drawing.Point(16, 224)
        Me.btnRecreateManifest.Name = "btnRecreateManifest"
        Me.btnRecreateManifest.Size = New System.Drawing.Size(272, 32)
        Me.btnRecreateManifest.TabIndex = 4
        Me.btnRecreateManifest.Text = "Re-Create Excel Manifest"
        '
        'btnDeleteBox
        '
        Me.btnDeleteBox.BackColor = System.Drawing.Color.Red
        Me.btnDeleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteBox.ForeColor = System.Drawing.Color.White
        Me.btnDeleteBox.Location = New System.Drawing.Point(144, 144)
        Me.btnDeleteBox.Name = "btnDeleteBox"
        Me.btnDeleteBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeleteBox.Size = New System.Drawing.Size(144, 32)
        Me.btnDeleteBox.TabIndex = 2
        Me.btnDeleteBox.Text = "DELETE EMPTY BOX"
        '
        'dbgPallets
        '
        Me.dbgPallets.AllowColMove = False
        Me.dbgPallets.AllowColSelect = False
        Me.dbgPallets.AllowFilter = False
        Me.dbgPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgPallets.AllowSort = False
        Me.dbgPallets.AllowUpdate = False
        Me.dbgPallets.AllowUpdateOnBlur = False
        Me.dbgPallets.CollapseColor = System.Drawing.Color.White
        Me.dbgPallets.ExpandColor = System.Drawing.Color.White
        Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgPallets.ForeColor = System.Drawing.Color.White
        Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgPallets.Location = New System.Drawing.Point(8, 9)
        Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgPallets.Name = "dbgPallets"
        Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgPallets.PreviewInfo.ZoomFactor = 75
        Me.dbgPallets.RowHeight = 20
        Me.dbgPallets.Size = New System.Drawing.Size(296, 119)
        Me.dbgPallets.TabIndex = 0
        Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
        "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
        "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
        "lor:White;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColo" & _
        "r:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRow{ForeColor:Highli" & _
        "ghtText;BackColor:Highlight;}Style12{}OddRow{BackColor:Teal;}RecordSelector{Alig" & _
        "nImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
        "rif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1" & _
        ", 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
        "tyle14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1Tru" & _
        "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
        "zing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" " & _
        "MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Ver" & _
        "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>115</Height><CaptionStyle" & _
        " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
        "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
        "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
        "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
        "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
        "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
        "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
        "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 292, 115</ClientRect><BorderSide>" & _
        "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
        "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
        "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
        "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
        "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
        "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
        "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
        "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
        "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
        "ltRecSelWidth><ClientArea>0, 0, 292, 115</ClientArea><PrintPageHeaderStyle paren" & _
        "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'btnReopenBox
        '
        Me.btnReopenBox.BackColor = System.Drawing.Color.Red
        Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReopenBox.ForeColor = System.Drawing.Color.White
        Me.btnReopenBox.Location = New System.Drawing.Point(16, 144)
        Me.btnReopenBox.Name = "btnReopenBox"
        Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReopenBox.Size = New System.Drawing.Size(112, 32)
        Me.btnReopenBox.TabIndex = 1
        Me.btnReopenBox.Text = "REOPEN  BOX"
        '
        'btnReprintBoxLabel
        '
        Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
        Me.btnReprintBoxLabel.Location = New System.Drawing.Point(16, 184)
        Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
        Me.btnReprintBoxLabel.Size = New System.Drawing.Size(272, 32)
        Me.btnReprintBoxLabel.TabIndex = 3
        Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
        '
        'panelPallet
        '
        Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
        Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDevSN, Me.Label10, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblCount, Me.Label3, Me.lblBoxName})
        Me.panelPallet.Location = New System.Drawing.Point(320, 48)
        Me.panelPallet.Name = "panelPallet"
        Me.panelPallet.Size = New System.Drawing.Size(408, 424)
        Me.panelPallet.TabIndex = 120
        Me.panelPallet.Visible = False
        '
        'txtDevSN
        '
        Me.txtDevSN.Location = New System.Drawing.Point(11, 56)
        Me.txtDevSN.Name = "txtDevSN"
        Me.txtDevSN.Size = New System.Drawing.Size(221, 20)
        Me.txtDevSN.TabIndex = 0
        Me.txtDevSN.Text = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(11, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(157, 16)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Serial Number:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCloseBox
        '
        Me.btnCloseBox.BackColor = System.Drawing.Color.Green
        Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseBox.ForeColor = System.Drawing.Color.White
        Me.btnCloseBox.Location = New System.Drawing.Point(232, 264)
        Me.btnCloseBox.Name = "btnCloseBox"
        Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCloseBox.Size = New System.Drawing.Size(152, 56)
        Me.btnCloseBox.TabIndex = 2
        Me.btnCloseBox.Text = "CLOSE && SHIP BOX"
        '
        'btnRemoveAllSNs
        '
        Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
        Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
        Me.btnRemoveAllSNs.Location = New System.Drawing.Point(232, 192)
        Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
        Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRemoveAllSNs.Size = New System.Drawing.Size(148, 33)
        Me.btnRemoveAllSNs.TabIndex = 4
        Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
        '
        'btnRemoveSN
        '
        Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
        Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
        Me.btnRemoveSN.Location = New System.Drawing.Point(232, 152)
        Me.btnRemoveSN.Name = "btnRemoveSN"
        Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRemoveSN.Size = New System.Drawing.Size(148, 32)
        Me.btnRemoveSN.TabIndex = 3
        Me.btnRemoveSN.Text = "REMOVE SN"
        '
        'lstDevices
        '
        Me.lstDevices.Location = New System.Drawing.Point(11, 80)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(221, 277)
        Me.lstDevices.TabIndex = 1
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(256, 80)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(98, 32)
        Me.lblCount.TabIndex = 97
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(256, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Box Count"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBoxName
        '
        Me.lblBoxName.BackColor = System.Drawing.Color.Black
        Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
        Me.lblBoxName.Location = New System.Drawing.Point(10, 5)
        Me.lblBoxName.Name = "lblBoxName"
        Me.lblBoxName.Size = New System.Drawing.Size(342, 32)
        Me.lblBoxName.TabIndex = 98
        Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlShipType
        '
        Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboBoxTypes, Me.Button5, Me.btnCreateBoxID})
        Me.pnlShipType.Location = New System.Drawing.Point(0, 48)
        Me.pnlShipType.Name = "pnlShipType"
        Me.pnlShipType.Size = New System.Drawing.Size(319, 88)
        Me.pnlShipType.TabIndex = 121
        '
        'cboBoxTypes
        '
        Me.cboBoxTypes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboBoxTypes.Caption = ""
        Me.cboBoxTypes.CaptionHeight = 17
        Me.cboBoxTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBoxTypes.ColumnCaptionHeight = 17
        Me.cboBoxTypes.ColumnFooterHeight = 17
        Me.cboBoxTypes.ContentHeight = 15
        Me.cboBoxTypes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBoxTypes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBoxTypes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBoxTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBoxTypes.EditorHeight = 15
        Me.cboBoxTypes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboBoxTypes.ItemHeight = 15
        Me.cboBoxTypes.Location = New System.Drawing.Point(64, 0)
        Me.cboBoxTypes.MatchEntryTimeout = CType(2000, Long)
        Me.cboBoxTypes.MaxDropDownItems = CType(5, Short)
        Me.cboBoxTypes.MaxLength = 32767
        Me.cboBoxTypes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBoxTypes.Name = "cboBoxTypes"
        Me.cboBoxTypes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBoxTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBoxTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBoxTypes.Size = New System.Drawing.Size(216, 21)
        Me.cboBoxTypes.TabIndex = 1
        Me.cboBoxTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
        "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
        "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
        "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Black
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(720, 200)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(300, 300)
        Me.Button5.TabIndex = 66
        Me.Button5.TabStop = False
        Me.Button5.Text = "Generate Report"
        '
        'btnCreateBoxID
        '
        Me.btnCreateBoxID.BackColor = System.Drawing.Color.Green
        Me.btnCreateBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateBoxID.ForeColor = System.Drawing.Color.White
        Me.btnCreateBoxID.Location = New System.Drawing.Point(64, 40)
        Me.btnCreateBoxID.Name = "btnCreateBoxID"
        Me.btnCreateBoxID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCreateBoxID.Size = New System.Drawing.Size(216, 32)
        Me.btnCreateBoxID.TabIndex = 3
        Me.btnCreateBoxID.Text = "CREATE BOX ID"
        Me.btnCreateBoxID.Visible = False
        '
        'frmAMSInfraStructureDockShip
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(744, 486)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlShipType, Me.PanelPalletList, Me.panelPallet, Me.lblScreenName})
        Me.Name = "frmAMSInfraStructureDockShip"
        Me.Text = "frmAMSInfraStructureDockShip"
        Me.PanelPalletList.ResumeLayout(False)
        CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPallet.ResumeLayout(False)
        Me.pnlShipType.ResumeLayout(False)
        CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAMSInfraStructureDockShip_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Const ProdID As Integer = 1
        Dim dt As DataTable
        Dim isComputerNameMapped As Boolean = False
        Dim tmpStr As String = String.Empty

        Try
            Me.btnReopenBox.Visible = False : Me.btnDeleteBox.Visible = False 'Not need these

            '**********************************************************************************************************************************************
            'Set ScreenName
            '**********************************************************************************************************************************************
            Me.lblScreenName.Text = Me._strTabPageTitle

            '***********************************************************************************************************************************************
            'check computer mapping
            '***********************************************************************************************************************************************
            Me._iMachineCC_GrpID = Generic.GetMachineCostCenterGrpID()
            Select Case Me._iMenuCustID
                Case Me._objAMSInfraStructure.AMSInfraStructure_CUSTOMER_ID
                    tmpStr = "AMS InfraStructure"
                    If Me._iMachineCC_GrpID = Me._objAMSInfraStructure.AMSInfraStructure_GROUPID Then
                        isComputerNameMapped = True
                    End If
                Case Else 'it is ok as long as has a valid customer
                    tmpStr = ""
                    If Me._iMenuCustID > 0 Then isComputerNameMapped = True Else isComputerNameMapped = False
            End Select

            If Not isComputerNameMapped Then
                MessageBox.Show("Machine is not mapped to " & tmpStr & " group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
                If PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                    PSS.Gui.MainWin.MainWin.wrkArea.TabPages.RemoveAt(PSS.Gui.MainWin.MainWin.wrkArea.SelectedIndex)
                Else
                    PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Clear()
                End If
            Else
                'populate data to dropdown list controls
                dt = Me._objAMSInfraStructure.GetShipBoxTypes()
                Misc.PopulateC1DropDownList(Me.cboBoxTypes, dt, "ShipTypeDesc", "ShipTypeID")
                Me.cboBoxTypes.SelectedValue = 0
                Me.cboBoxTypes.Enabled = False 'AMS Infrastructure always 'REFURBISHED' 

                LoadOpenPallet()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '********************************************************************
    Private Sub LoadOpenPallet()
        Dim strPrefixPalletName As String, strType As String
        Dim dt As DataTable

        Try
            If IsNothing(Me.cboBoxTypes.SelectedValue) Then
                MessageBox.Show("No Box Type.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Not Me.cboBoxTypes.SelectedValue = 0 Then
                MessageBox.Show("Type of AMS InfraStructure must be 'REFURBISHED'.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                strType = Me.cboBoxTypes.DataSource.Table.select("ShipTypeID = " & Me.cboBoxTypes.SelectedValue)(0)("ShipTypeDesc")
                strType = strType.Substring(0, 3)
                strPrefixPalletName = Me._objAMSInfraStructure.GetPalletNamePrefixStr(Me._iMenuCustID) & strType
                dt = Me._objAMSInfraStructure.GetOpenPallets(strPrefixPalletName, Me._iMenuCustID)
                PopulateOpenPallets(dt)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadOpenPallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub PopulateOpenPallets(ByVal dt As DataTable)

        Try
            Me.dbgPallets.DataSource = Nothing
            If dt.Rows.Count > 0 Then
                With Me.dbgPallets
                    .DataSource = dt.DefaultView
                    SetGridOpenBoxProperties()
                    Me.btnCreateBoxID.Visible = False
                End With
            Else
                Me.btnCreateBoxID.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "PopulateOpenPallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub SetGridOpenBoxProperties(Optional ByVal iPallet_ID As Integer = 0)
        Dim iNumOfColumns As Integer = Me.dbgPallets.Columns.Count
        Dim i As Integer

        With Me.dbgPallets
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(i).Visible = False
            Next
            'header forecolor
            .Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(3).HeadingStyle.ForeColor = .ForeColor.Black

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Body Forecolor
            .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black

            'Set Column Widths
            .Splits(0).DisplayColumns("Box Name").Width = 200

            'Make some columns invisible
            .Splits(0).DisplayColumns("Box Name").Visible = True

            .AlternatingRows = True

            For i = 0 To .RowCount - 1
                If .Columns("Pallett_ID").CellValue(i) = iPallet_ID Then
                    Exit Sub
                End If
                .MoveNext()
            Next i
        End With
    End Sub

    '********************************************************************
    Private Sub PopulateSelectedPallet(ByVal iPallet_ID As Integer)
        Dim strPrefixPalletName As String
        Dim dt As DataTable
        Try
            dt = Me._objAMSInfraStructure.GetOpenPalletsByPalletID(iPallet_ID)
            PopulateOpenPallets(dt)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadOpenPallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub btnCreateBoxID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBoxID.Click

        Dim iBoxType As Integer = 0
        Dim iPalletID As Integer = 0
        Dim strPrefixPalletName As String, strType As String
        Dim dt As DataTable

        Try
            If IsNothing(Me.cboBoxTypes.SelectedValue) Then
                MessageBox.Show("No Box Type.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Not Me.cboBoxTypes.SelectedValue = 0 Then
                MessageBox.Show("Type of AMS InfraStructure must be 'REFURBISHED'.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                'Check valid selection of box type
                If Me.IsValidBoxTypeSelection() = False Then
                    MessageBox.Show("Not a valid Box Type.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboBoxTypes.Focus()
                    Exit Sub
                End If
                iBoxType = Me.cboBoxTypes.SelectedValue
                strType = Me.cboBoxTypes.DataSource.Table.select("ShipTypeID = " & Me.cboBoxTypes.SelectedValue)(0)("ShipTypeDesc")
                strType = strType.Substring(0, 3)

                'check for open pallet
                strPrefixPalletName = Me._objAMSInfraStructure.GetPalletNamePrefixStr(Me._iMenuCustID) & strType
                dt = Me._objAMSInfraStructure.GetOpenPallets(strPrefixPalletName, Me._iMenuCustID)
                If dt.Rows.Count = 0 Then
                    iPalletID = Me._objAMSInfraStructure.CreateBoxID(iBoxType, strPrefixPalletName, Me._iMenuCustID, Me._objAMSInfraStructure.AMSInfraStructure_LOC_ID)
                    PopulateSelectedPallet(iPalletID)
                Else
                    MessageBox.Show("At least one open box is currently availalbe to fill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    PopulateOpenPallets(dt)
                    Me.txtDevSN.Focus()
                End If  'check if there is an box available to fill

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCreateBoxID_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    '********************************************************************
    Private Sub dbgPallets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgPallets.Click
        Try
            Me.ProcessPalletSelection()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgPallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub dbgPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgPallets.RowColChange
        Try
            Me.ProcessPalletSelection()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgPallets_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessPalletSelection()
        Dim strShipType As String = ""
        Dim i As Integer = 0
        Dim booFound As Boolean = False

        Try
            Me.lblBoxName.Text = ""
            Me.lblCount.Text = "0"
            Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.panelPallet.Visible = True

            If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
                Me.panelPallet.Visible = False
                Exit Sub
            End If
            If Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Exit Sub
            End If

            Me.lblBoxName.Text = Me.dbgPallets.Columns("Box Name").Value.ToString
            'Select Case Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString
            '    Case "0"    'REFURBISHED
            '        Me.cboBoxTypes.SelectedValue = 0
            '        .Me.Enabled = True
            '        'Case Else
            '        '    Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString)
            '        '    Me.cboFreqs.SelectedValue = 0
            '        '    Me.cboFreqs.Enabled = False
            'End Select
            Me.RefreshSNList()
            Me.txtDevSN.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RefreshSNList()
        Dim dt1 As DataTable
        Dim iPallet_ID As Integer = 0
        Dim strPalletName As String = ""
        Dim strFreqNo As String = ""
        Dim objMisc As PSS.Data.Buisness.Misc

        Try
            '************************
            'Validations
            iPallet_ID = CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString)
            strPalletName = Me.dbgPallets.Columns("Box Name").Value.ToString.Trim

            If iPallet_ID = 0 Then
                Throw New Exception("Box is not selected.")
            ElseIf strPalletName.Trim = "" Then
                Throw New Exception("Box is not selected.")
            End If

            '*******************************************
            'Get all devices add put them in them in list box for a pallet
            objMisc = New PSS.Data.Buisness.Misc()
            dt1 = objMisc.GetAllSNsForPallet(iPallet_ID)
            Me.lstDevices.DataSource = dt1.DefaultView
            Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
            Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString
            Me.lblBoxName.Text = strPalletName

            '*******************************************
            Me.lblCount.Text = dt1.Rows.Count
        Catch ex As Exception
            Throw ex
        Finally
            objMisc = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
            Me.txtDevSN.Focus()
        End Try
    End Sub


    '********************************************************************
    Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtDevSN.Text.Trim.Length > 0 Then Me.ProcessSN()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessSN()
        Dim i As Integer = 0
        Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
        Dim dtDevice As DataTable

        Try
            'Validations
            If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Not Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString.Trim = "0" Then
                Throw New Exception("Ship type must be 'REFURBISHED'.")
            ElseIf Me.txtDevSN.Text.Trim = "" Then
                Exit Sub
            End If

            'Check if the Device is already scanned in
            For i = 0 To Me.lstDevices.Items.Count - 1
                If UCase(Trim(Me.lstDevices.Items(i).ToString)) = strSN Then
                    MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                    Exit Sub
                End If
            Next

            'More Validations
            If Generic.IsPalletClosed(CInt(Me.dbgPallets.Columns("Pallett_ID").Value)) = True Then
                MsgBox("Box had been closed by another machine. Please refresh your screen.", MsgBoxStyle.Information, "Device Scan")
                Exit Sub
            End If
            i = 0
            dtDevice = Me._objAMSInfraStructure.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, CInt(Me.dbgPallets.Columns("Loc_ID").Value))

            If dtDevice.Rows.Count > 1 Then
                MsgBox("This device existed twice in the system. Please contact IT.", MsgBoxStyle.Information, "Information")
                Me.txtDevSN.SelectAll()
                Exit Sub
            ElseIf dtDevice.Rows.Count = 0 Then
                MsgBox("This device does not exist in the system, already ship or belong to a different customer.", MsgBoxStyle.Information, "Information")
                Me.txtDevSN.SelectAll()
                Exit Sub
            Else
                'For AMS INE, production-shipped-device (WIP) already assigned a Pallet_ID(which is the pallet when doing billing)
                'Now need to differ them, check if it has been assinged DockShipped pallet
                If Me._objAMSInfraStructure.IsDockShippedPalletID(Me._objAMSInfraStructure.GetPalletNamePrefixStr(Me._iMenuCustID), CInt(dtDevice.Rows(0)("Pallett_ID"))) Then
                    MsgBox("This device already has assigned into a box ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                    MsgBox("This device has not been billed.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor
                    'Add it to the list and update the tdevice.pallett_ID 
                    i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgPallets.Columns("Pallett_ID").Value))
                    Me.RefreshSNList()
                    'Me.LoadCellProductionNumbers()
                    'Me.LoadWeeklyCellProductionNumbers()
                    Me.Enabled = True : Cursor.Current = Cursors.Default
                    Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("ProcessSN: " & ex.Message, "Process SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtDevSN.Text = ""
            Me.txtDevSN.Focus()
        Finally
            Generic.DisposeDT(dtDevice)
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
        Dim strSN As String = ""
        Dim i As Integer = 0
        Dim iDeviceID As Integer = 0

        Try
            'Validations
            If Me.dbgPallets.RowCount = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.lstDevices.Items.Count = 0 Then
                Exit Sub
            End If

            'Ask for input
            strSN = InputBox("Enter S/N:", "S/N").Trim
            If strSN = "" Then
                Throw New Exception("Please enter a S/N if you want to remove it from the selected box.")
            End If

            'Get device_ID
            For i = 0 To Me.lstDevices.Items.Count - 1
                If Me.lstDevices.Items.Item(i)("Device_SN").ToString.Trim = strSN Then
                    iDeviceID = CInt(Me.lstDevices.Items.Item(i)("Device_ID").ToString)
                    Exit For
                End If
            Next i

            'Ready to remove
            If iDeviceID > 0 Then
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = Me._objAMSInfraStructure.RemoveSNfromPallet(Me._objAMSInfraStructure.Repair_Pallet_ID, iDeviceID)
                If i = 0 Then
                    Throw New Exception("S/N entered was not removed from Box.")
                End If

                Me.RefreshSNList()
            Else
                Throw New Exception("S/N was not listed.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear S/N", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtDevSN.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
        Dim str_sn As String = ""
        Dim i As Integer = 0, j As Integer = 0
        Dim iDeviceID As Integer = 0

        If MessageBox.Show("Are you sure you want to remove all devices from this Box?", "Clear All S/Ns", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        Try
            'Validations
            If Me.dbgPallets.RowCount = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.lstDevices.Items.Count = 0 Then
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor
            For i = 0 To Me.lstDevices.Items.Count - 1
                iDeviceID = CInt(Me.lstDevices.Items.Item(i)("Device_ID").ToString)
                j = Me._objAMSInfraStructure.RemoveSNfromPallet(Me._objAMSInfraStructure.Repair_Pallet_ID, iDeviceID)
            Next i

            RefreshSNList()

            If Not Me.lstDevices.Items.Count = 0 Then
                MessageBox.Show("Didn't clear all or added from other PC workstation.", "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtDevSN.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
        Dim i As Integer = 0, iPackingSlipID As Integer = 0
        Dim objMisc As PSS.Data.Buisness.Misc
        Dim strRptTitle As String = ""

        Try
            'Validations
            If CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box name is not selected.")
            ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Throw New Exception("Box name is not selected.")
            End If

            If Me.lstDevices.Items.Count = 0 Then
                Throw New Exception("There is no devices in this box.")
            End If

            'Close it? Y/N
            If MessageBox.Show("Are you sure you want to close this box?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            ' strRptTitle = Generic.GetCustomerName(_iMenuCustID) & " " & Me.cboBoxTypes.Text & " Manifest"
            strRptTitle = "AMS INE " & Me.cboBoxTypes.Text & " Manifest"

            'Ready to close pallet
            objMisc = New PSS.Data.Buisness.Misc()
            i = objMisc.ClosePallet(Me._iMenuCustID, CInt(Me.dbgPallets.Columns("Pallett_ID").Value), _
                              Me.dbgPallets.Columns("Box Name").Value, _
                              Me.lstDevices.Items.Count, Me.dbgPallets.Columns("Pallet_ShipType").Value, 0, strRptTitle)
            If i = 0 Then
                MessageBox.Show("Box has not closed yet due to an error. Please contact IT.", "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value)
            PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.dbgPallets.Columns("Box Name").Value, _
                                                                 Me.dbgPallets.Columns("Model_ID").Value, _
                                                                 Me.cboBoxTypes.Text, Me.lstDevices.Items.Count, 1)

            'Ready to ship
            iPackingSlipID = Me._objAMSInfraStructure.InsertPackingSlip(Me._iMenuCustID, PSS.Core.Global.ApplicationUser.IDuser)
            If iPackingSlipID > 0 Then
                i = Me._objAMSInfraStructure.UpdateAfterShipped(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), iPackingSlipID, Core.ApplicationUser.IDuser, "AMS InfraStructure Dock Ship", Me.Name)
                ' MessageBox.Show("Final=" & i)
                If Not i > 0 Then
                    MessageBox.Show("Failed to update tCellOpt or tPallett. Please contact IT.", "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                MessageBox.Show("Failed to create packingslip. Please contact IT.", "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Refresh Pallet (Box) 
            LoadOpenPallet()

            'Reset Screen control properties.
            Me.lblBoxName.Text = ""
            Me.lblCount.Text = 0
            Me.lstDevices.DataSource = Nothing
            Me.panelPallet.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
        Dim str_pallett As String = ""
        Dim dtPallettInfo As DataTable
        Dim strPalletType As String = ""
        Dim iPalletQty As Integer = 0
        Dim R1 As DataRow
        Dim objMisc As PSS.Data.Buisness.Misc

        Try
            str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
            If str_pallett = "" Then
                Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            objMisc = New PSS.Data.Buisness.Misc()
            dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)
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

                If R1("Pallet_ShipType") = 0 Then
                    strPalletType = "REFURBISHED"
                    'ElseIf R1("Pallet_ShipType") = 1 Then
                    '    strPalletType = "DBR"
                    'ElseIf R1("Pallet_ShipType") = 2 Then
                    '    strPalletType = "NER"
                Else
                    MessageBox.Show("System can't define Box Type.", "Information", MessageBoxButtons.OK)
                    Exit Sub
                End If

                If Not IsDBNull(R1("Pallett_QTY")) Then iPalletQty = R1("Pallett_QTY")

                If Not IsDBNull(R1("Cust_ID")) Then
                    PSS.Data.Production.Shipping.PrintPalletLicensePlate(str_pallett, R1("Model_ID"), strPalletType, iPalletQty, 1)
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

    '********************************************************************
    Private Sub btnRecreateManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecreateManifest.Click
        Dim str_pallett, strPalletType, strRptTitle, strFilePath As String
        Dim dtPallettInfo As DataTable
        Dim iPalletQty As Integer = 0
        Dim R1 As DataRow
        Dim objMisc As PSS.Data.Buisness.Misc
        Dim booPrintRpt As Boolean = False
        Dim objSkytel As SkyTel

        Try
            str_pallett = "" : strPalletType = "" : strRptTitle = "" : strFilePath = ""
            str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            objMisc = New PSS.Data.Buisness.Misc()
            dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)
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

                If MessageBox.Show("Do you want to print report?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then booPrintRpt = True

                strRptTitle = "AMS INE " & Me.cboBoxTypes.DataSource.Table.Select("ShipTypeID = " & R1("Pallet_ShipType"))(0)("ShipTypeDesc") & " Manifest"

                strFilePath = Me._objAMSInfraStructure.AMSInfraStructure_MANIFEST_DIR
                objSkytel = New SkyTel()
                objSkytel.CreateShipManifestReport(R1("Pallett_ID"), R1("Pallett_Name"), strFilePath, strRptTitle, booPrintRpt, R1("Pallet_ShipType"))
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

    '********************************************************************
    Private Function IsValidBoxTypeSelection() As Boolean
        Dim dtBoxType As DataTable
        Try
            dtBoxType = Me.cboBoxTypes.DataSource.Table
            If dtBoxType.Select("ShipTypeDesc = '" & Me.cboBoxTypes.Text & "'").Length = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dtBoxType = Nothing
        End Try
    End Function

End Class
