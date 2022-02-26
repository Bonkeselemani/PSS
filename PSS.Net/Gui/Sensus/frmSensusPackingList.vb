Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Public Class frmSensusPackingList
    Inherits System.Windows.Forms.Form

    Private _objSensus As Sensus
    Private _dtPallet As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objSensus = New Sensus()
        _dtPallet = New DataTable()
        Generic.AddNewColumnToDataTable(Me._dtPallet, "pkslip_ID", "System.Int32", "0")
        Generic.AddNewColumnToDataTable(Me._dtPallet, "Pallett_ID", "System.Int32", "0")
        Generic.AddNewColumnToDataTable(Me._dtPallet, "Pallett_Name", "System.String", "")
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objSensus = Nothing

            If Not IsNothing(Me._dtPallet) Then
                Me._dtPallet.Dispose()
                Me._dtPallet = Nothing
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpPackingList As System.Windows.Forms.TabPage
    Friend WithEvents tpWaitingShipment As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPalletName As System.Windows.Forms.TextBox
    Friend WithEvents lstPalletNames As System.Windows.Forms.ListBox
    Friend WithEvents btnReprintPackingList As System.Windows.Forms.Button
    Friend WithEvents btnDeleteOne As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents btnCreatePacking As System.Windows.Forms.Button
    Friend WithEvents cboShipToLoc As PSS.Gui.Controls.ComboBox
    Friend WithEvents btnCopySelected As System.Windows.Forms.Button
    Friend WithEvents btnCopyAll As System.Windows.Forms.Button
    Friend WithEvents dbgWaitingShipment As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblListQty As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPalletQty As System.Windows.Forms.Label
    Friend WithEvents tpReadyForMoveToCEM As System.Windows.Forms.TabPage
    Friend WithEvents btnMTCEM_CopySelect As System.Windows.Forms.Button
    Friend WithEvents btnMTCEM_CopyAll As System.Windows.Forms.Button
    Friend WithEvents dbgReadyToMoveToCEM As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSensusPackingList))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpPackingList = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblListQty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPalletQty = New System.Windows.Forms.Label()
        Me.btnReprintPackingList = New System.Windows.Forms.Button()
        Me.btnDeleteOne = New System.Windows.Forms.Button()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.btnCreatePacking = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstPalletNames = New System.Windows.Forms.ListBox()
        Me.txtPalletName = New System.Windows.Forms.TextBox()
        Me.cboShipToLoc = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tpWaitingShipment = New System.Windows.Forms.TabPage()
        Me.btnCopySelected = New System.Windows.Forms.Button()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.dbgWaitingShipment = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tpReadyForMoveToCEM = New System.Windows.Forms.TabPage()
        Me.btnMTCEM_CopySelect = New System.Windows.Forms.Button()
        Me.btnMTCEM_CopyAll = New System.Windows.Forms.Button()
        Me.dbgReadyToMoveToCEM = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabControl1.SuspendLayout()
        Me.tpPackingList.SuspendLayout()
        Me.tpWaitingShipment.SuspendLayout()
        CType(Me.dbgWaitingShipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpReadyForMoveToCEM.SuspendLayout()
        CType(Me.dbgReadyToMoveToCEM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpPackingList, Me.tpWaitingShipment, Me.tpReadyForMoveToCEM})
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(200, 21)
        Me.TabControl1.Location = New System.Drawing.Point(8, 16)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(568, 352)
        Me.TabControl1.TabIndex = 0
        '
        'tpPackingList
        '
        Me.tpPackingList.BackColor = System.Drawing.Color.SteelBlue
        Me.tpPackingList.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.lblListQty, Me.Label2, Me.lblPalletQty, Me.btnReprintPackingList, Me.btnDeleteOne, Me.btnDeleteAll, Me.btnCreatePacking, Me.Label1, Me.lstPalletNames, Me.txtPalletName, Me.cboShipToLoc, Me.Label5})
        Me.tpPackingList.Location = New System.Drawing.Point(4, 25)
        Me.tpPackingList.Name = "tpPackingList"
        Me.tpPackingList.Size = New System.Drawing.Size(560, 323)
        Me.tpPackingList.TabIndex = 0
        Me.tpPackingList.Text = "Packing List"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(464, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "List Qty"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblListQty
        '
        Me.lblListQty.BackColor = System.Drawing.Color.Black
        Me.lblListQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblListQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListQty.ForeColor = System.Drawing.Color.Lime
        Me.lblListQty.Location = New System.Drawing.Point(464, 24)
        Me.lblListQty.Name = "lblListQty"
        Me.lblListQty.Size = New System.Drawing.Size(88, 40)
        Me.lblListQty.TabIndex = 97
        Me.lblListQty.Text = "0"
        Me.lblListQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(352, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Pallet Qty"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalletQty
        '
        Me.lblPalletQty.BackColor = System.Drawing.Color.Black
        Me.lblPalletQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPalletQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalletQty.ForeColor = System.Drawing.Color.Lime
        Me.lblPalletQty.Location = New System.Drawing.Point(352, 24)
        Me.lblPalletQty.Name = "lblPalletQty"
        Me.lblPalletQty.Size = New System.Drawing.Size(88, 40)
        Me.lblPalletQty.TabIndex = 95
        Me.lblPalletQty.Text = "0"
        Me.lblPalletQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReprintPackingList
        '
        Me.btnReprintPackingList.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnReprintPackingList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintPackingList.ForeColor = System.Drawing.Color.White
        Me.btnReprintPackingList.Location = New System.Drawing.Point(352, 176)
        Me.btnReprintPackingList.Name = "btnReprintPackingList"
        Me.btnReprintPackingList.Size = New System.Drawing.Size(168, 32)
        Me.btnReprintPackingList.TabIndex = 6
        Me.btnReprintPackingList.Text = "Reprint Packing List"
        '
        'btnDeleteOne
        '
        Me.btnDeleteOne.BackColor = System.Drawing.Color.Red
        Me.btnDeleteOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteOne.ForeColor = System.Drawing.Color.White
        Me.btnDeleteOne.Location = New System.Drawing.Point(352, 80)
        Me.btnDeleteOne.Name = "btnDeleteOne"
        Me.btnDeleteOne.Size = New System.Drawing.Size(88, 24)
        Me.btnDeleteOne.TabIndex = 4
        Me.btnDeleteOne.Text = "Delete One"
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackColor = System.Drawing.Color.Red
        Me.btnDeleteAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteAll.ForeColor = System.Drawing.Color.White
        Me.btnDeleteAll.Location = New System.Drawing.Point(352, 112)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(88, 24)
        Me.btnDeleteAll.TabIndex = 5
        Me.btnDeleteAll.Text = "Delete All"
        '
        'btnCreatePacking
        '
        Me.btnCreatePacking.BackColor = System.Drawing.Color.Green
        Me.btnCreatePacking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreatePacking.ForeColor = System.Drawing.Color.White
        Me.btnCreatePacking.Location = New System.Drawing.Point(352, 240)
        Me.btnCreatePacking.Name = "btnCreatePacking"
        Me.btnCreatePacking.Size = New System.Drawing.Size(168, 32)
        Me.btnCreatePacking.TabIndex = 7
        Me.btnCreatePacking.Text = "Create Packing List"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Pallet Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstPalletNames
        '
        Me.lstPalletNames.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.lstPalletNames.Location = New System.Drawing.Point(120, 64)
        Me.lstPalletNames.Name = "lstPalletNames"
        Me.lstPalletNames.Size = New System.Drawing.Size(216, 160)
        Me.lstPalletNames.TabIndex = 3
        '
        'txtPalletName
        '
        Me.txtPalletName.Location = New System.Drawing.Point(120, 40)
        Me.txtPalletName.Name = "txtPalletName"
        Me.txtPalletName.Size = New System.Drawing.Size(216, 20)
        Me.txtPalletName.TabIndex = 2
        Me.txtPalletName.Text = ""
        '
        'cboShipToLoc
        '
        Me.cboShipToLoc.AutoComplete = True
        Me.cboShipToLoc.BackColor = System.Drawing.SystemColors.Window
        Me.cboShipToLoc.DropDownWidth = 300
        Me.cboShipToLoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboShipToLoc.ForeColor = System.Drawing.Color.Black
        Me.cboShipToLoc.Location = New System.Drawing.Point(120, 8)
        Me.cboShipToLoc.MaxDropDownItems = 30
        Me.cboShipToLoc.Name = "cboShipToLoc"
        Me.cboShipToLoc.Size = New System.Drawing.Size(216, 21)
        Me.cboShipToLoc.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Ship To Location:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpWaitingShipment
        '
        Me.tpWaitingShipment.BackColor = System.Drawing.Color.SteelBlue
        Me.tpWaitingShipment.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelected, Me.btnCopyAll, Me.dbgWaitingShipment})
        Me.tpWaitingShipment.Location = New System.Drawing.Point(4, 25)
        Me.tpWaitingShipment.Name = "tpWaitingShipment"
        Me.tpWaitingShipment.Size = New System.Drawing.Size(560, 323)
        Me.tpWaitingShipment.TabIndex = 1
        Me.tpWaitingShipment.Text = "Waiting Shipment"
        '
        'btnCopySelected
        '
        Me.btnCopySelected.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnCopySelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopySelected.ForeColor = System.Drawing.Color.White
        Me.btnCopySelected.Location = New System.Drawing.Point(352, 8)
        Me.btnCopySelected.Name = "btnCopySelected"
        Me.btnCopySelected.Size = New System.Drawing.Size(160, 24)
        Me.btnCopySelected.TabIndex = 142
        Me.btnCopySelected.Text = "Copy Selected Items"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAll.ForeColor = System.Drawing.Color.White
        Me.btnCopyAll.Location = New System.Drawing.Point(208, 8)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(104, 24)
        Me.btnCopyAll.TabIndex = 141
        Me.btnCopyAll.Text = "Copy All"
        '
        'dbgWaitingShipment
        '
        Me.dbgWaitingShipment.AllowColMove = False
        Me.dbgWaitingShipment.AllowColSelect = False
        Me.dbgWaitingShipment.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgWaitingShipment.AllowUpdate = False
        Me.dbgWaitingShipment.AllowUpdateOnBlur = False
        Me.dbgWaitingShipment.AlternatingRows = True
        Me.dbgWaitingShipment.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.dbgWaitingShipment.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgWaitingShipment.FilterBar = True
        Me.dbgWaitingShipment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgWaitingShipment.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgWaitingShipment.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgWaitingShipment.Location = New System.Drawing.Point(8, 40)
        Me.dbgWaitingShipment.MaintainRowCurrency = True
        Me.dbgWaitingShipment.Name = "dbgWaitingShipment"
        Me.dbgWaitingShipment.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgWaitingShipment.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgWaitingShipment.PreviewInfo.ZoomFactor = 75
        Me.dbgWaitingShipment.RowHeight = 20
        Me.dbgWaitingShipment.Size = New System.Drawing.Size(504, 272)
        Me.dbgWaitingShipment.TabIndex = 140
        Me.dbgWaitingShipment.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
        "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>268</Height><CaptionStyle pare" & _
        "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
        "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
        "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
        "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
        "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
        "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
        "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
        "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 500, 268</ClientRect><BorderSide>0</Bo" & _
        "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
        "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
        "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
        "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
        "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
        "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
        "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
        "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
        "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
        "SelWidth><ClientArea>0, 0, 500, 268</ClientArea><PrintPageHeaderStyle parent="""" " & _
        "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'tpReadyForMoveToCEM
        '
        Me.tpReadyForMoveToCEM.BackColor = System.Drawing.Color.SteelBlue
        Me.tpReadyForMoveToCEM.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnMTCEM_CopySelect, Me.btnMTCEM_CopyAll, Me.dbgReadyToMoveToCEM})
        Me.tpReadyForMoveToCEM.Location = New System.Drawing.Point(4, 25)
        Me.tpReadyForMoveToCEM.Name = "tpReadyForMoveToCEM"
        Me.tpReadyForMoveToCEM.Size = New System.Drawing.Size(560, 323)
        Me.tpReadyForMoveToCEM.TabIndex = 2
        Me.tpReadyForMoveToCEM.Text = "Ready To CEM"
        '
        'btnMTCEM_CopySelect
        '
        Me.btnMTCEM_CopySelect.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnMTCEM_CopySelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMTCEM_CopySelect.ForeColor = System.Drawing.Color.Black
        Me.btnMTCEM_CopySelect.Location = New System.Drawing.Point(288, 8)
        Me.btnMTCEM_CopySelect.Name = "btnMTCEM_CopySelect"
        Me.btnMTCEM_CopySelect.Size = New System.Drawing.Size(160, 24)
        Me.btnMTCEM_CopySelect.TabIndex = 144
        Me.btnMTCEM_CopySelect.Text = "Copy Selected Items"
        '
        'btnMTCEM_CopyAll
        '
        Me.btnMTCEM_CopyAll.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnMTCEM_CopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMTCEM_CopyAll.ForeColor = System.Drawing.Color.Black
        Me.btnMTCEM_CopyAll.Location = New System.Drawing.Point(136, 8)
        Me.btnMTCEM_CopyAll.Name = "btnMTCEM_CopyAll"
        Me.btnMTCEM_CopyAll.Size = New System.Drawing.Size(104, 24)
        Me.btnMTCEM_CopyAll.TabIndex = 143
        Me.btnMTCEM_CopyAll.Text = "Copy All"
        '
        'dbgReadyToMoveToCEM
        '
        Me.dbgReadyToMoveToCEM.AllowColMove = False
        Me.dbgReadyToMoveToCEM.AllowColSelect = False
        Me.dbgReadyToMoveToCEM.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgReadyToMoveToCEM.AllowUpdate = False
        Me.dbgReadyToMoveToCEM.AllowUpdateOnBlur = False
        Me.dbgReadyToMoveToCEM.AlternatingRows = True
        Me.dbgReadyToMoveToCEM.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.dbgReadyToMoveToCEM.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgReadyToMoveToCEM.FilterBar = True
        Me.dbgReadyToMoveToCEM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgReadyToMoveToCEM.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgReadyToMoveToCEM.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.dbgReadyToMoveToCEM.Location = New System.Drawing.Point(8, 40)
        Me.dbgReadyToMoveToCEM.MaintainRowCurrency = True
        Me.dbgReadyToMoveToCEM.Name = "dbgReadyToMoveToCEM"
        Me.dbgReadyToMoveToCEM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgReadyToMoveToCEM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgReadyToMoveToCEM.PreviewInfo.ZoomFactor = 75
        Me.dbgReadyToMoveToCEM.RowHeight = 20
        Me.dbgReadyToMoveToCEM.Size = New System.Drawing.Size(440, 272)
        Me.dbgReadyToMoveToCEM.TabIndex = 141
        Me.dbgReadyToMoveToCEM.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
        "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>268</Height><CaptionStyle pare" & _
        "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
        "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
        "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
        "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
        "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
        "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
        "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
        "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 436, 268</ClientRect><BorderSide>0</Bo" & _
        "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
        "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
        "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
        "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
        "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
        "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
        "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
        "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
        "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
        "SelWidth><ClientArea>0, 0, 436, 268</ClientArea><PrintPageHeaderStyle parent="""" " & _
        "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'frmSensusPackingList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(616, 405)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Name = "frmSensusPackingList"
        Me.Text = "frmPackingList"
        Me.TabControl1.ResumeLayout(False)
        Me.tpPackingList.ResumeLayout(False)
        Me.tpWaitingShipment.ResumeLayout(False)
        CType(Me.dbgWaitingShipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpReadyForMoveToCEM.ResumeLayout(False)
        CType(Me.dbgReadyToMoveToCEM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*******************************************************************
    Private Sub tabModelMaster_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Try
            DrawTab(sender, e, Color.LightSteelBlue, Color.Blue, Color.AntiqueWhite, Color.Black)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "Error in tabModelMaster_DrawItem")
        End Try
    End Sub

    '*******************************************************************
    Private Sub DrawTab(ByVal sender As Object, _
                        ByVal e As System.Windows.Forms.DrawItemEventArgs, _
                        ByVal FocusedBackColor As Color, _
                        ByVal FocusedForeColor As Color, _
                        ByVal NonFocusedBackColor As Color, _
                        ByVal NonFocusedForeColor As Color)
        Dim f As Font
        Dim backBrush, foreBrush As Brush
        Dim sf As StringFormat
        Dim strTabName As String
        Dim rect As Rectangle
        Dim r As RectangleF
        Dim iAddX(), iAddY(), iAddHeight(), iAddWidth() As Integer

        Try
            sf = New StringFormat()
            f = New Font(e.Font, FontStyle.Regular)

            ReDim iAddX(1)
            ReDim iAddY(1)
            ReDim iAddHeight(1)
            ReDim iAddWidth(1)

            iAddX(0) = 1
            iAddY(0) = 0
            iAddWidth(0) = -1
            iAddHeight(0) = 1
            iAddX(1) = 0
            iAddY(1) = 4

            If e.Index = Me.TabControl1.SelectedIndex Then
                backBrush = New System.Drawing.SolidBrush(FocusedBackColor)
                foreBrush = New System.Drawing.SolidBrush(FocusedForeColor)

                'Me.TabControl1.TabPages(e.Index).BackColor = FocusedBackColor
            Else
                backBrush = New System.Drawing.SolidBrush(NonFocusedBackColor)
                foreBrush = New System.Drawing.SolidBrush(NonFocusedForeColor)

                'Me.TabControl1.TabPages(e.Index).BackColor = FocusedBackColor
            End If

            rect = New Rectangle(e.Bounds.X + iAddX(0), e.Bounds.Y + iAddY(0), e.Bounds.Width + iAddWidth(0), e.Bounds.Height + iAddHeight(0))

            sf.Alignment = StringAlignment.Center
            e.Graphics.FillRectangle(backBrush, rect)

            iAddWidth(1) = 0
            iAddHeight(1) = -4

            r = New RectangleF(e.Bounds.X + iAddX(1), e.Bounds.Y + iAddY(1), e.Bounds.Width + iAddWidth(1), e.Bounds.Height + iAddHeight(1))

            strTabName = Me.TabControl1.TabPages(e.Index).Text
            e.Graphics.DrawString(strTabName, f, foreBrush, r, sf)
        Catch ex As Exception
            Throw ex
        Finally
            sf.Dispose()
            f.Dispose()
            backBrush.Dispose()
            foreBrush.Dispose()
        End Try
    End Sub

    '*******************************************************************
    Private Sub frmPackingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)
            Me.LoadSensusShipToAddress()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmPackingList_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub LoadSensusShipToAddress()
        Dim dt As DataTable
        Try
            dt = Me._objSensus.GetSensusShipToAddress(True)
            With Me.cboShipToLoc
                .DataSource = dt.DefaultView
                .DisplayMember = "CS_Desc"
                .ValueMember = "ShipTo_ID"
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*******************************************************************
    Private Sub tpPackingList_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpPackingList.VisibleChanged
        If sender.name <> "" AndAlso sender.Visible = True Then Me.cboShipToLoc.Focus()
    End Sub

    '*******************************************************************
    Private Sub tpWaitingShipment_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpWaitingShipment.VisibleChanged
        If sender.name <> "" AndAlso sender.Visible = True Then Me.dbgWaitingShipment.Focus()
    End Sub

    '*******************************************************************
    Private Sub tpWaitingShipment_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpWaitingShipment.Enter
        Try
            Me.PopulateWaitingShipment()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "tpWaitingShipment_Enter", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '*******************************************************************
    Private Sub tpReadyForMoveToCEM_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpReadyForMoveToCEM.VisibleChanged
        If sender.name <> "" AndAlso sender.Visible = True Then Me.dbgReadyToMoveToCEM.Focus()
    End Sub

    '**************************************************************************************************
    Private Sub tpReadyForMoveToCEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpReadyForMoveToCEM.Enter
        Try
            Me.PopulateReadyToMoveToCEM()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "tpReadyForMoveToCEM_Enter", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateWaitingShipment()
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            dt = Me._objSensus.GetSensusWaitingToShipPallet()

            With Me.dbgWaitingShipment
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Black
                Next i

                .Splits(0).DisplayColumns("Pallet Name").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Prod Completed Date").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("QTY").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns("Ship to Location").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                .Splits(0).DisplayColumns("Pallet Name").Width = 140
                .Splits(0).DisplayColumns("Prod Completed Date").Width = 145
                .Splits(0).DisplayColumns("QTY").Width = 70
                .Splits(0).DisplayColumns("Ship to Location").Width = 100
            End With

            'Me.lblTotal.Text = "Total = " & dt.Rows.Count
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
        Try
            Me.CopyAll(Me.dbgWaitingShipment)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCopySelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySelected.Click
        Try
            Me.CopySelectedItems(Me.dbgWaitingShipment)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCopySelected_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateReadyToMoveToCEM()
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            dt = Me._objSensus.GetSensusReadyToMoveToCEM()

            With Me.dbgReadyToMoveToCEM
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Black
                Next i

                .Splits(0).DisplayColumns("RMA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("RR#").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Qty").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                .Splits(0).DisplayColumns("RMA").Width = 150
                .Splits(0).DisplayColumns("RR#").Width = 150
                .Splits(0).DisplayColumns("Qty").Width = 80

                .Splits(0).DisplayColumns("RMA_Barcode").Visible = False
                .Splits(0).DisplayColumns("RR_Barcode").Visible = False

            End With

            'Me.lblTotal.Text = "Total = " & dt.Rows.Count
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub CopyAll(ByRef dbgCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim strHeader As String = ""
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Try
            If dbgCtrl.RowCount > 0 And dbgCtrl.Columns.Count > 0 Then
                Me.Enabled = False

                'loop through each row
                For iRow = 0 To dbgCtrl.RowCount - 1
                    'loop through each column
                    For Each col In dbgCtrl.Columns
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

                Me.Enabled = True
            Else
                MessageBox.Show("No data to copy.", "Copy All", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Me.Enabled = True
            col = Nothing
        End Try
    End Sub

    '******************************************************************
    Private Sub CopySelectedItems(ByRef dbgCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim strHeader As String = ""

        Try
            If dbgCtrl.SelectedRows.Count > 0 And dbgCtrl.SelectedCols.Count Then
                Me.Enabled = False

                'loop through each selected row
                For Each iRow In dbgCtrl.SelectedRows

                    'loop through each selected column
                    For Each col In dbgCtrl.SelectedCols
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

                Me.Enabled = True
            Else
                MessageBox.Show("Please select a range of cells to copy.", "Copy Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Me.Enabled = True
            col = Nothing
        End Try
    End Sub

    '******************************************************************

    Private Sub btnMTCEM_CopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMTCEM_CopyAll.Click
        Try
            Me.CopyAll(Me.dbgReadyToMoveToCEM)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnMTCMD_CopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnMTCEM_CopySelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMTCEM_CopySelect.Click
        Try
            Me.CopySelectedItems(Me.dbgReadyToMoveToCEM)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnMTCMD_CopySelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub cboShipToLoc_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboShipToLoc.SelectedValueChanged
        Me._dtPallet.Rows.Clear()
        Me.lstPalletNames.Items.Clear()
        Me.txtPalletName.Text = ""
        Me.lblPalletQty.Text = "0"
        Me.lblListQty.Text = "0"
        If Me.cboShipToLoc.SelectedValue.GetType.IsValueType = True AndAlso Me.cboShipToLoc.SelectedValue > 0 Then Me.txtPalletName.Focus()
    End Sub

    '******************************************************************
    Private Sub btnDeleteOne_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteOne.Click
        Dim strDeletePalletName As String
        Dim iIndex As Integer = 0
        Dim R1 As DataRow

        Try
            '*****************
            'empty list
            '*****************
            If Me.lstPalletNames.Items.Count = 0 Then Exit Sub

            '************************
            'Get box name to be delete
            '************************
            strDeletePalletName = InputBox("Enter Pallet Name:", "Get Pallet Name").Trim
            If strDeletePalletName.Trim = "" Then
                Exit Sub
            End If

            '**********************************
            'Check if box name exist in list
            '**********************************
            iIndex = Me.lstPalletNames.Items.IndexOf(strDeletePalletName)
            If iIndex = -1 Then
                MessageBox.Show("Item does not exist in list", "Remove item From List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtPalletName.Focus()
                Exit Sub
            End If

            '**********************************
            'Delete from datatable
            '**********************************
            For Each R1 In Me._dtPallet.Rows
                If R1("Pallett_Name").ToString.Trim.ToUpper = strDeletePalletName.Trim.ToUpper Then
                    R1.Delete()
                    Exit For
                End If
            Next R1
            Me._dtPallet.AcceptChanges()

            '**************************
            'Delete from list
            '**************************
            Me.lstPalletNames.Items.RemoveAt(iIndex)
            Me.lstPalletNames.Refresh()

            '**************************
            'Reset counter
            '**************************
            Me.lblListQty.Text = Me._dtPallet.Rows.Count
            Me.txtPalletName.Text = ""
            Me.txtPalletName.Focus()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnDeleteOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

        Finally
            R1 = Nothing
            Me.txtPalletName.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnDeleteAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim R1 As DataRow
        Dim strPallettIDs As String = ""

        Try
            If Me._dtPallet.Rows.Count > 0 Then
                If MessageBox.Show("Are you sure you want to remove all items in list?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    Exit Sub
                End If

                '*********************************
                'Reset controls and global variables
                '*********************************
                Me._dtPallet.Rows.Clear()
                Me.lstPalletNames.Items.Clear()
                Me.lstPalletNames.Refresh()
                Me.lblPalletQty.Text = "0"
                Me.lblListQty.Text = Me._dtPallet.Rows.Count
                Me.txtPalletName.Text = ""
                Me.txtPalletName.Focus()
                '*********************************
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnDeleteAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
        End Try
    End Sub

    '******************************************************************
    Private Sub txtPalletName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPalletName.KeyUp
        Dim dt As DataTable
        Dim drNewRow As DataRow

        Try
            If e.KeyValue = 13 Then
                If Me.txtPalletName.Text.Trim.Length = 0 Then Exit Sub

                If Me.cboShipToLoc.SelectedValue = 0 Then
                    MessageBox.Show("Please select ship to location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletName.SelectAll()
                    Exit Sub
                End If

                '********************************
                'check for duplicate
                '********************************
                If Me._dtPallet.Rows.Count > 0 Then
                    If Me._dtPallet.Select("Pallett_Name = '" & Me.txtPalletName.Text.Trim.ToUpper & "'").Length > 0 Then
                        MessageBox.Show("This pallet is already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPalletName.SelectAll()
                        Exit Sub
                    End If
                End If

                '********************************
                dt = Me._objSensus.GetSensusPalletInfo(Me.txtPalletName.Text.Trim)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet does not exist or belongs to a different customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletName.SelectAll()
                ElseIf dt.Rows(0)("Pallet_Invalid") = 1 Then
                    MessageBox.Show("Pallet has been deleted by user " & dt.Rows(0)("Deleted By User").ToString.ToUpper & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletName.SelectAll()
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Pallet is still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletName.SelectAll()
                ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Pallet have not production completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletName.SelectAll()
                ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) Then
                    MessageBox.Show("Pallet is already assigned to a packing list number " & dt.Rows(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletName.SelectAll()
                ElseIf Not IsDBNull(dt.Rows(0)("ShipTo_ID")) AndAlso dt.Rows(0)("ShipTo_ID") <> Me.cboShipToLoc.SelectedValue Then
                    MessageBox.Show("Pallet does not belong to the selected location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletName.SelectAll()
                ElseIf IsDBNull(dt.Rows(0)("Pallett_QTY")) Then
                    MessageBox.Show("Pallet is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletName.SelectAll()
                ElseIf dt.Rows(0)("Pallett_QTY") = 0 Then
                    MessageBox.Show("Pallet is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPalletName.SelectAll()
                Else
                    drNewRow = Me._dtPallet.NewRow
                    drNewRow("Pallett_ID") = dt.Rows(0)("Pallett_ID")
                    drNewRow("Pallett_Name") = dt.Rows(0)("Pallett_Name")
                    Me._dtPallet.Rows.Add(drNewRow)
                    Me._dtPallet.AcceptChanges()
                    Me.lstPalletNames.Items.Add(Me.txtPalletName.Text.Trim.ToUpper)
                    Me.lblPalletQty.Text = dt.Rows(0)("Pallett_QTY")
                    Me.lblListQty.Text = Me._dtPallet.Rows.Count
                    Me.txtPalletName.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "txtPalletName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            drNewRow = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCreatePacking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreatePacking.Click
        Dim iPkslip_ID As Integer = 0
        Dim objSPPLF As SendPalletPackingListFiles
        Dim i As Integer = 0

        Try
            '************************
            'Validate user input
            '************************
            If Me.cboShipToLoc.SelectedValue = 0 Then
                MessageBox.Show("Please select ship location.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboShipToLoc.Focus()
                Exit Sub
            ElseIf Me.lstPalletNames.Items.Count = 0 Or Me._dtPallet.Rows.Count = 0 Then
                MessageBox.Show("Please enter at least one pallet to create packing list.", "Create Packing List", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtPalletName.Focus()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to create packing list for all pallets in the list?", "Create Box", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Me.txtPalletName.Focus()
                Exit Sub
            End If

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            '****************************
            'Create packing splip report
            '****************************
            objSPPLF = New SendPalletPackingListFiles()
            iPkslip_ID = objSPPLF.CreatePackingSlip(Sensus.SENSUS_CUSTOMER_ID, ApplicationUser.IDuser, Me.cboShipToLoc.SelectedValue)
            If iPkslip_ID = 0 Then
                MessageBox.Show("System have failed to create packing ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            '****************************
            'Assign packing # to pallet
            '****************************
            i = objSPPLF.AssignManifestNumToPallets(Me._dtPallet, iPkslip_ID, ApplicationUser.IDuser, Sensus.SENSUS_CUSTOMER_ID)
            If i = 0 Then
                MessageBox.Show("System have failed to assign packing ID to box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            '****************************
            'Print packing slip
            '****************************
            Me._objSensus.PrintPackingList(iPkslip_ID, 3)

            '************************************
            'Reset controls and global variables
            '************************************
            Me._dtPallet.Rows.Clear()

            Me.lstPalletNames.Items.Clear()
            Me.lstPalletNames.Refresh()
            Me.lblPalletQty.Text = "0"
            Me.lblListQty.Text = Me._dtPallet.Rows.Count
            Me.txtPalletName.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Packing List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.lstPalletNames.Items.Clear()
            Me.lstPalletNames.Refresh()
            Me.lblPalletQty.Text = "0"
            Me.lblListQty.Text = Me._dtPallet.Rows.Count
            Me.txtPalletName.Text = ""
        Finally
            objSPPLF = Nothing
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtPalletName.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnReprintPackingList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintPackingList.Click
        Dim strPkslip_ID As String = ""
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            '************************
            'Get packing list number
            '************************
            strPkslip_ID = InputBox("Enter Packing List#:", "Reprint Packing List").Trim
            If strPkslip_ID.Trim.Length = 0 Then
                Exit Sub
            End If

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            '****************************
            'Print packing slip
            '****************************
            Me._objSensus.PrintPackingList(strPkslip_ID, 1)

            Me.txtPalletName.SelectAll()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Packing List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Me.txtPalletName.Focus()
        End Try
    End Sub

    '******************************************************************

End Class
