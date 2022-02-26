Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Public Class frmHTCPackingList
    Inherits System.Windows.Forms.Form

    Private _objHTC As PSS.Data.Buisness.HTC
    Private _dtPLBoxs As DataTable = Nothing

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New PSS.Data.Buisness.HTC()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objHTC = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmbShipToLoc As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpgWaitingShipment As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnReprintPackingList As System.Windows.Forms.Button
    Friend WithEvents btnDeleteOne As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents btnCreatePacking As System.Windows.Forms.Button
    Friend WithEvents dbgWaitingShipment As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnCopySelected As System.Windows.Forms.Button
    Friend WithEvents btnCopyAll As System.Windows.Forms.Button
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstBoxItems As System.Windows.Forms.ListBox
    Friend WithEvents tpgPackingList As System.Windows.Forms.TabPage
    Friend WithEvents lblBoxQty As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblListQty As System.Windows.Forms.Label
    Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTCPackingList))
        Me.cmbShipToLoc = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lstBoxItems = New System.Windows.Forms.ListBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpgPackingList = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBoxQty = New System.Windows.Forms.Label()
        Me.btnReprintPackingList = New System.Windows.Forms.Button()
        Me.btnDeleteOne = New System.Windows.Forms.Button()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.btnCreatePacking = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBoxName = New System.Windows.Forms.TextBox()
        Me.tpgWaitingShipment = New System.Windows.Forms.TabPage()
        Me.btnCopySelected = New System.Windows.Forms.Button()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dbgWaitingShipment = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblListQty = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tpgPackingList.SuspendLayout()
        Me.tpgWaitingShipment.SuspendLayout()
        CType(Me.dbgWaitingShipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbShipToLoc
        '
        Me.cmbShipToLoc.AutoComplete = True
        Me.cmbShipToLoc.BackColor = System.Drawing.SystemColors.Window
        Me.cmbShipToLoc.DropDownWidth = 300
        Me.cmbShipToLoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbShipToLoc.ForeColor = System.Drawing.Color.Black
        Me.cmbShipToLoc.Location = New System.Drawing.Point(16, 32)
        Me.cmbShipToLoc.MaxDropDownItems = 30
        Me.cmbShipToLoc.Name = "cmbShipToLoc"
        Me.cmbShipToLoc.Size = New System.Drawing.Size(256, 21)
        Me.cmbShipToLoc.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 16)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Ship To Location:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstBoxItems
        '
        Me.lstBoxItems.Location = New System.Drawing.Point(16, 56)
        Me.lstBoxItems.Name = "lstBoxItems"
        Me.lstBoxItems.Size = New System.Drawing.Size(216, 368)
        Me.lstBoxItems.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgPackingList, Me.tpgWaitingShipment})
        Me.TabControl1.Location = New System.Drawing.Point(16, 64)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(648, 480)
        Me.TabControl1.TabIndex = 1
        '
        'tpgPackingList
        '
        Me.tpgPackingList.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgPackingList.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.lblListQty, Me.Label2, Me.lblBoxQty, Me.btnReprintPackingList, Me.btnDeleteOne, Me.btnDeleteAll, Me.btnCreatePacking, Me.Label1, Me.txtBoxName, Me.lstBoxItems})
        Me.tpgPackingList.Location = New System.Drawing.Point(4, 22)
        Me.tpgPackingList.Name = "tpgPackingList"
        Me.tpgPackingList.Size = New System.Drawing.Size(640, 454)
        Me.tpgPackingList.TabIndex = 0
        Me.tpgPackingList.Text = "Packing List"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(256, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "Box Qty"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBoxQty
        '
        Me.lblBoxQty.BackColor = System.Drawing.Color.Black
        Me.lblBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxQty.ForeColor = System.Drawing.Color.Lime
        Me.lblBoxQty.Location = New System.Drawing.Point(256, 32)
        Me.lblBoxQty.Name = "lblBoxQty"
        Me.lblBoxQty.Size = New System.Drawing.Size(88, 40)
        Me.lblBoxQty.TabIndex = 91
        Me.lblBoxQty.Text = "0"
        Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReprintPackingList
        '
        Me.btnReprintPackingList.BackColor = System.Drawing.Color.SteelBlue
        Me.btnReprintPackingList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintPackingList.ForeColor = System.Drawing.Color.White
        Me.btnReprintPackingList.Location = New System.Drawing.Point(256, 328)
        Me.btnReprintPackingList.Name = "btnReprintPackingList"
        Me.btnReprintPackingList.Size = New System.Drawing.Size(168, 32)
        Me.btnReprintPackingList.TabIndex = 90
        Me.btnReprintPackingList.Text = "Reprint Packing List"
        '
        'btnDeleteOne
        '
        Me.btnDeleteOne.BackColor = System.Drawing.Color.Red
        Me.btnDeleteOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteOne.ForeColor = System.Drawing.Color.White
        Me.btnDeleteOne.Location = New System.Drawing.Point(256, 112)
        Me.btnDeleteOne.Name = "btnDeleteOne"
        Me.btnDeleteOne.Size = New System.Drawing.Size(88, 24)
        Me.btnDeleteOne.TabIndex = 87
        Me.btnDeleteOne.Text = "Delete One"
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackColor = System.Drawing.Color.Red
        Me.btnDeleteAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteAll.ForeColor = System.Drawing.Color.White
        Me.btnDeleteAll.Location = New System.Drawing.Point(256, 160)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(88, 24)
        Me.btnDeleteAll.TabIndex = 88
        Me.btnDeleteAll.Text = "Delete All"
        '
        'btnCreatePacking
        '
        Me.btnCreatePacking.BackColor = System.Drawing.Color.Green
        Me.btnCreatePacking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreatePacking.ForeColor = System.Drawing.Color.White
        Me.btnCreatePacking.Location = New System.Drawing.Point(256, 392)
        Me.btnCreatePacking.Name = "btnCreatePacking"
        Me.btnCreatePacking.Size = New System.Drawing.Size(168, 32)
        Me.btnCreatePacking.TabIndex = 89
        Me.btnCreatePacking.Text = "Create Packing List"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Box Number:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxName
        '
        Me.txtBoxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxName.Location = New System.Drawing.Point(16, 32)
        Me.txtBoxName.Name = "txtBoxName"
        Me.txtBoxName.Size = New System.Drawing.Size(216, 22)
        Me.txtBoxName.TabIndex = 0
        Me.txtBoxName.Text = ""
        '
        'tpgWaitingShipment
        '
        Me.tpgWaitingShipment.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgWaitingShipment.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelected, Me.btnCopyAll, Me.lblTotal, Me.dbgWaitingShipment})
        Me.tpgWaitingShipment.Location = New System.Drawing.Point(4, 22)
        Me.tpgWaitingShipment.Name = "tpgWaitingShipment"
        Me.tpgWaitingShipment.Size = New System.Drawing.Size(640, 454)
        Me.tpgWaitingShipment.TabIndex = 1
        Me.tpgWaitingShipment.Text = "Waiting Shipment"
        '
        'btnCopySelected
        '
        Me.btnCopySelected.BackColor = System.Drawing.Color.Teal
        Me.btnCopySelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopySelected.ForeColor = System.Drawing.Color.White
        Me.btnCopySelected.Location = New System.Drawing.Point(144, 4)
        Me.btnCopySelected.Name = "btnCopySelected"
        Me.btnCopySelected.Size = New System.Drawing.Size(160, 24)
        Me.btnCopySelected.TabIndex = 139
        Me.btnCopySelected.Text = "Copy Selected Items"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.BackColor = System.Drawing.Color.Teal
        Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAll.ForeColor = System.Drawing.Color.White
        Me.btnCopyAll.Location = New System.Drawing.Point(8, 4)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(104, 24)
        Me.btnCopyAll.TabIndex = 138
        Me.btnCopyAll.Text = "Copy All"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Black
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Lime
        Me.lblTotal.Location = New System.Drawing.Point(535, 5)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(96, 24)
        Me.lblTotal.TabIndex = 136
        Me.lblTotal.Text = "Total = 0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dbgWaitingShipment
        '
        Me.dbgWaitingShipment.AllowColMove = False
        Me.dbgWaitingShipment.AllowColSelect = False
        Me.dbgWaitingShipment.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgWaitingShipment.AllowUpdate = False
        Me.dbgWaitingShipment.AllowUpdateOnBlur = False
        Me.dbgWaitingShipment.AlternatingRows = True
        Me.dbgWaitingShipment.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgWaitingShipment.FilterBar = True
        Me.dbgWaitingShipment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgWaitingShipment.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgWaitingShipment.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgWaitingShipment.Location = New System.Drawing.Point(8, 31)
        Me.dbgWaitingShipment.MaintainRowCurrency = True
        Me.dbgWaitingShipment.Name = "dbgWaitingShipment"
        Me.dbgWaitingShipment.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgWaitingShipment.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgWaitingShipment.PreviewInfo.ZoomFactor = 75
        Me.dbgWaitingShipment.RowHeight = 20
        Me.dbgWaitingShipment.Size = New System.Drawing.Size(624, 409)
        Me.dbgWaitingShipment.TabIndex = 135
        Me.dbgWaitingShipment.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
        "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>405</Height><CaptionStyle pare" & _
        "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
        "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
        "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
        "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
        "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
        "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
        "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
        "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 620, 405</ClientRect><BorderSide>0</Bo" & _
        "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
        "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
        "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
        "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
        "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
        "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
        "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
        "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
        "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRec" & _
        "SelWidth><ClientArea>0, 0, 620, 405</ClientArea><PrintPageHeaderStyle parent="""" " & _
        "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(384, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "List Qty"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblListQty
        '
        Me.lblListQty.BackColor = System.Drawing.Color.Black
        Me.lblListQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblListQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListQty.ForeColor = System.Drawing.Color.Lime
        Me.lblListQty.Location = New System.Drawing.Point(384, 32)
        Me.lblListQty.Name = "lblListQty"
        Me.lblListQty.Size = New System.Drawing.Size(88, 40)
        Me.lblListQty.TabIndex = 93
        Me.lblListQty.Text = "0"
        Me.lblListQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmHTCPackingList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(896, 557)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.cmbShipToLoc, Me.Label5})
        Me.Name = "frmHTCPackingList"
        Me.Text = "frmHTCPackingList"
        Me.TabControl1.ResumeLayout(False)
        Me.tpgPackingList.ResumeLayout(False)
        Me.tpgWaitingShipment.ResumeLayout(False)
        CType(Me.dbgWaitingShipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmHTCPackingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Create datatable for Packing Slip
            Me._dtPLBoxs = New DataTable()
            Generic.AddNewColumnToDataTable(Me._dtPLBoxs, "pkslip_ID", "System.Int32", "0")
            Generic.AddNewColumnToDataTable(Me._dtPLBoxs, "Pallett_ID", "System.Int32", "0")
            Generic.AddNewColumnToDataTable(Me._dtPLBoxs, "Pallett_Name", "System.String", "")

            Me.PopulateShipToLocation()

            PSS.Core.Highlight.SetHighLight(Me)

            Me.txtBoxName.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateShipToLocation()
        Dim dt As DataTable
        Try
            dt = Me._objHTC.GetShipToLocation()
            With Me.cmbShipToLoc
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .DisplayMember = "ShipTo_Name"
                .ValueMember = "ShipTo_ID"
                If dt.Rows.Count > 1 Then
                    .SelectedValue = dt.Rows(0)("ShipTo_ID")
                Else
                    .SelectedValue = 0
                End If
            End With
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateWaitingShipment(ByVal iShipTo_ID As Integer)
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            If Me.cmbShipToLoc.SelectedValue = 0 Then Exit Sub

            dt = Me._objHTC.GetWaitingToShipBox(iShipTo_ID)

            With Me.dbgWaitingShipment
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To Me.dbgWaitingShipment.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Black
                Next i

                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                .Splits(0).DisplayColumns("Model").Width = 150
                .Splits(0).DisplayColumns("BoxName").Width = 150
                .Splits(0).DisplayColumns("CompletionDate").Width = 100
                .Splits(0).DisplayColumns("QTY").Width = 80
                .Splits(0).DisplayColumns("PalletShipType").Width = 100
            End With

            Me.lblTotal.Text = "Total = " & dt.Rows.Count
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
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
            If Me.dbgWaitingShipment.RowCount > 0 And Me.dbgWaitingShipment.Columns.Count > 0 Then
                'loop through each row
                For iRow = 0 To Me.dbgWaitingShipment.RowCount - 1
                    'loop through each column
                    For Each col In Me.dbgWaitingShipment.Columns
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
                MessageBox.Show("No data to copy.", "Copy All", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            col = Nothing
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCopySelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySelected.Click
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim strHeader As String = ""

        Try
            If Me.dbgWaitingShipment.SelectedRows.Count > 0 And Me.dbgWaitingShipment.SelectedCols.Count Then
                'loop through each selected row
                For Each iRow In Me.dbgWaitingShipment.SelectedRows

                    'loop through each selected column
                    For Each col In Me.dbgWaitingShipment.SelectedCols
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
                MessageBox.Show("Please select a range of cells to copy.", "Copy Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCopySelected_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            col = Nothing
        End Try
    End Sub

    '******************************************************************
    Private Sub tpgWaitingShipment_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgWaitingShipment.VisibleChanged
        Try
            If sender.visible = True Then
                If Me.cmbShipToLoc.SelectedValue > 0 Then
                    Me.PopulateWaitingShipment(Me.cmbShipToLoc.SelectedValue)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "tpgWaitingShipment_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub cmbShipToLoc_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShipToLoc.SelectionChangeCommitted
        Try
            If Me.tpgWaitingShipment.Visible = True AndAlso Me.cmbShipToLoc.SelectedValue > 0 Then
                Me.PopulateWaitingShipment(Me.cmbShipToLoc.SelectedValue)
            ElseIf Me.tpgPackingList.Visible = True Then
                Me.txtBoxName.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "cmbShipToLoc_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtBoxName_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyUp
        Dim dt As DataTable
        Dim drNewRow As DataRow

        Try
            If e.KeyValue = 13 Then
                If Me.cmbShipToLoc.SelectedValue = 0 Then
                    MessageBox.Show("Please select ship to location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.SelectAll()
                    Exit Sub
                End If

                '********************************
                'check for duplicate
                '********************************
                If Me._dtPLBoxs.Rows.Count > 0 Then
                    If Me._dtPLBoxs.Select("Pallett_Name = '" & Me.txtBoxName.Text.Trim.ToUpper & "'").Length > 0 Then
                        MessageBox.Show("This box is already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.SelectAll()
                        Exit Sub
                    End If
                End If

                '********************************
                dt = Me._objHTC.GetPalletShipToLocByName(Me.txtBoxName.Text.Trim)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Box does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.SelectAll()
                ElseIf Not IsDBNull(dt.Rows(0)("Cust_ID")) AndAlso dt.Rows(0)("Cust_ID") <> Me._objHTC.HTC_CUSTOMER_ID Then
                    MessageBox.Show("Box does not belong to HTC customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.SelectAll()
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.SelectAll()
                ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Box have not production completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.SelectAll()
                ElseIf Not IsDBNull(dt.Rows(0)("pkslip_ID")) Then
                    MessageBox.Show("Box is already assigned to a packing list number " & dt.Rows(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.SelectAll()
                ElseIf Not IsDBNull(dt.Rows(0)("ShipTo_ID")) And dt.Rows(0)("ShipTo_ID") <> Me.cmbShipToLoc.SelectedValue Then
                    MessageBox.Show("Box does not belong to the selected location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.SelectAll()
                ElseIf IsDBNull(dt.Rows(0)("Pallett_QTY")) Then
                    MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.SelectAll()
                ElseIf dt.Rows(0)("Pallett_QTY") = 0 Then
                    MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxName.SelectAll()
                Else
                    ''confirm location on first box
                    'If Me.lstBoxItems.Items.Count = 0 Then
                    '    If MessageBox.Show("This packing list will ship to location " & Me.cmbShipToLoc.Text.ToUpper & ". Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub
                    'End If

                    drNewRow = Me._dtPLBoxs.NewRow
                    drNewRow("Pallett_ID") = dt.Rows(0)("Pallett_ID")
                    drNewRow("Pallett_Name") = dt.Rows(0)("Pallett_Name")
                    Me._dtPLBoxs.Rows.Add(drNewRow)
                    Me._dtPLBoxs.AcceptChanges()
                    Me.lstBoxItems.Items.Add(Me.txtBoxName.Text.Trim.ToUpper)
                    Me.lblBoxQty.Text = dt.Rows(0)("Pallett_QTY")
                    Me.lblListQty.Text = Me._dtPLBoxs.Rows.Count
                    Me.txtBoxName.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "txtFileName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            drNewRow = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnDeleteOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteOne.Click
        Dim strDeletePalletName As String
        Dim iIndex As Integer = 0
        Dim R1 As DataRow

        Try
            '*****************
            'empty list
            '*****************
            If Me.lstBoxItems.Items.Count = 0 Then
                Exit Sub
            End If

            '************************
            'Get box name to be delete
            '************************
            strDeletePalletName = Trim(InputBox("Box Name:", "Remove item"))

            If strDeletePalletName = "" Then
                Exit Sub
            End If

            '**********************************
            'Check if box name exist in list
            '**********************************
            iIndex = Me.lstBoxItems.Items.IndexOf(strDeletePalletName)
            If iIndex = -1 Then
                MessageBox.Show("Item does not exist in list", "Remove item From List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtBoxName.Focus()
                Exit Sub
            End If

            '**********************************
            'Delete from datatable
            '**********************************
            For Each R1 In Me._dtPLBoxs.Rows
                If R1("Pallett_Name").ToString.Trim.ToUpper = strDeletePalletName.Trim.ToUpper Then
                    'If Me._iManifestNum > 0 Then
                    '    If Not IsDBNull(R1("pkslip_ID")) AndAlso R1("pkslip_ID") > 0 Then
                    '        Me._objSPPLF.RemoveManifestNumFrPallets(Me.cmbCustomer.SelectedValue, R1("Pallett_ID").ToString, Me._iUserID, Me._iManifestNum)
                    '    End If
                    'End If
                    R1.Delete()
                    Exit For
                End If
            Next R1
            Me._dtPLBoxs.AcceptChanges()

            '**************************
            'Delete from list
            '**************************
            Me.lstBoxItems.Items.RemoveAt(iIndex)
            Me.lstBoxItems.Refresh()

            '**************************
            'Reset counter
            '**************************
            Me.lblListQty.Text = Me._dtPLBoxs.Rows.Count
            Me.txtBoxName.Text = ""
            Me.txtBoxName.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Remove Item From List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            Me.txtBoxName.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim R1 As DataRow
        Dim strPallettIDs As String = ""

        Try
            If Me._dtPLBoxs.Rows.Count > 0 Then
                'If Me._iManifestNum > 0 Then
                '    '*********************************
                '    'Get all pallet ID
                '    '*********************************
                '    For Each R1 In Me._dtPSPallet.Rows
                '        If strPallettIDs = "" Then
                '            strPallettIDs = R1("Pallett_ID")
                '        Else
                '            strPallettIDs &= ", " & R1("Pallett_ID")
                '        End If
                '    Next R1
                '    '*********************************
                '    'Remove manifest number from pallet
                '    '*********************************
                '    Me._objSPPLF.RemoveManifestNumFrPallets(Me.cmbCustomer.SelectedValue, strPallettIDs, Me._iUserID, Me._iManifestNum)
                'End If

                If MessageBox.Show("Are you sure you want to remove all items in list?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    Exit Sub
                End If

                '*********************************
                'Reset controls and global variables
                '*********************************
                Me._dtPLBoxs.Rows.Clear()
                Me.lstBoxItems.Items.Clear()
                Me.lstBoxItems.Refresh()
                Me.lblBoxQty.Text = "0"
                Me.lblListQty.Text = Me._dtPLBoxs.Rows.Count
                Me.txtBoxName.Text = ""
                Me.txtBoxName.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Clear All Items", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            Me.txtBoxName.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnReprintPackingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintPackingList.Click
        Dim strPkslip_ID As String = ""

        Try
            '************************
            'Get packing list number
            '************************
            strPkslip_ID = InputBox("Enter Packing List#:", "Reprint Packing List").Trim
            If strPkslip_ID.Trim.Length = 0 Then Exit Sub

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            '****************************
            'Print packing slip
            '****************************
            Me._objHTC.PrintPackingList(strPkslip_ID, 1)

            Me.txtBoxName.SelectAll()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Packing List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            Me.txtBoxName.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCreatePacking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePacking.Click
        Dim iPkslip_ID As Integer = 0
        Dim objSPPLF As SendPalletPackingListFiles
        Dim i As Integer = 0

        Try
            '************************
            'Validate user input
            '************************
            If Me.cmbShipToLoc.SelectedValue = 0 Then
                MessageBox.Show("Please select ship location.", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbShipToLoc.Focus()
                Exit Sub
            ElseIf Me.lstBoxItems.Items.Count = 0 Or Me._dtPLBoxs.Rows.Count = 0 Then
                MessageBox.Show("Please enter at least one box to create packing list.", "Create Packing List", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtBoxName.Focus()
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to create packing list for all box in the list?", "Create Box", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Me.txtBoxName.Focus()
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            '****************************
            'Create packing splip report
            '****************************
            objSPPLF = New SendPalletPackingListFiles()
            iPkslip_ID = objSPPLF.CreatePackingSlip(HTC.HTC_CUSTOMER_ID, ApplicationUser.IDuser, Me.cmbShipToLoc.SelectedValue)
            If iPkslip_ID = 0 Then
                MessageBox.Show("System have failed to create packing ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            '****************************
            'Assign packing # to pallet
            '****************************
            i = objSPPLF.AssignManifestNumToPallets(Me._dtPLBoxs, iPkslip_ID, ApplicationUser.IDuser, HTC.HTC_CUSTOMER_ID)
            If i = 0 Then
                MessageBox.Show("System have failed to assign packing ID to box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            '****************************
            'Print packing slip
            '****************************
            Me._objHTC.PrintPackingList(iPkslip_ID, 3)

            '************************************
            'Reset controls and global variables
            '************************************
            Me._dtPLBoxs.Rows.Clear()

            Me.lstBoxItems.Items.Clear()
            Me.lstBoxItems.Refresh()
            Me.lblListQty.Text = Me._dtPLBoxs.Rows.Count
            Me.txtBoxName.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Packing List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objSPPLF = Nothing
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtBoxName.Focus()
        End Try
    End Sub

    '******************************************************************

End Class
