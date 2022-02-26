Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text
Imports System.Data


Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_WH_Transfer
        Inherits System.Windows.Forms.Form

        Private _objTFFKRec As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Receiving
        Private _objTFFKPickPackShip As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip
        Private _dtBox As DataTable
        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _dbQuarantine As New DataTable()
        Private _dbQuarantineDetails As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFKRec = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Receiving()
            Me._objTFFKPickPackShip = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTFFKRec = Nothing
                    Me._objTFFKPickPackShip = Nothing
                Catch ex As Exception
                End Try

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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtModel As System.Windows.Forms.TextBox
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnTransfer As System.Windows.Forms.Button
        Friend WithEvents chkBoxOverstock As System.Windows.Forms.CheckBox
        Friend WithEvents chkBoxRelabel As System.Windows.Forms.CheckBox
        Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
        Friend WithEvents pnlQtyModel As System.Windows.Forms.Panel
        Friend WithEvents chkBoxPickLoc As System.Windows.Forms.CheckBox
        Friend WithEvents pnlChkBoxes As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents btnDoSplit As System.Windows.Forms.Button
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents pnlSplitBox As System.Windows.Forms.Panel
        Friend WithEvents txtOriginalQty As System.Windows.Forms.TextBox
        Friend WithEvents lblOldBox As System.Windows.Forms.Label
        Friend WithEvents lblOriginalWBID As System.Windows.Forms.Label
        Friend WithEvents lblModelID As System.Windows.Forms.Label
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblItemCountVal As System.Windows.Forms.Label
        Friend WithEvents lblTotalItemQtyVal As System.Windows.Forms.Label
        Friend WithEvents lblItemCount As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents pnlItemNeed As System.Windows.Forms.Panel
        Friend WithEvents chkBoxQuarantine As System.Windows.Forms.CheckBox
        Friend WithEvents pnlQuarantine As System.Windows.Forms.Panel
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lbNewBox As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents tdgBoxSNs As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblnewBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents txtWHAndPickBox As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents btnSetNextBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveOne As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnCompleteQuarantine As System.Windows.Forms.Button
        Friend WithEvents lblNewBoxID As System.Windows.Forms.Label
        Friend WithEvents lblSelectedBoxQty As System.Windows.Forms.Label
        Friend WithEvents lblSelectedBoxModelID As System.Windows.Forms.Label
        Friend WithEvents lblSelectedBoxModel As System.Windows.Forms.Label
        Friend WithEvents pnlBox As System.Windows.Forms.Panel
        Friend WithEvents pnlButtons As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_WH_Transfer))
            Me.txtBoxName = New System.Windows.Forms.TextBox()
            Me.txtModel = New System.Windows.Forms.TextBox()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnTransfer = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.chkBoxOverstock = New System.Windows.Forms.CheckBox()
            Me.chkBoxRelabel = New System.Windows.Forms.CheckBox()
            Me.pnlQtyModel = New System.Windows.Forms.Panel()
            Me.lblModelID = New System.Windows.Forms.Label()
            Me.chkBoxPickLoc = New System.Windows.Forms.CheckBox()
            Me.pnlChkBoxes = New System.Windows.Forms.Panel()
            Me.chkBoxQuarantine = New System.Windows.Forms.CheckBox()
            Me.pnlSplitBox = New System.Windows.Forms.Panel()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.btnDoSplit = New System.Windows.Forms.Button()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtOriginalQty = New System.Windows.Forms.TextBox()
            Me.lblOldBox = New System.Windows.Forms.Label()
            Me.lblOriginalWBID = New System.Windows.Forms.Label()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblItemCountVal = New System.Windows.Forms.Label()
            Me.lblTotalItemQtyVal = New System.Windows.Forms.Label()
            Me.lblItemCount = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.pnlItemNeed = New System.Windows.Forms.Panel()
            Me.pnlQuarantine = New System.Windows.Forms.Panel()
            Me.lblSelectedBoxModel = New System.Windows.Forms.Label()
            Me.lblSelectedBoxModelID = New System.Windows.Forms.Label()
            Me.lblSelectedBoxQty = New System.Windows.Forms.Label()
            Me.lblNewBoxID = New System.Windows.Forms.Label()
            Me.btnCompleteQuarantine = New System.Windows.Forms.Button()
            Me.btnRemoveAll = New System.Windows.Forms.Button()
            Me.btnRemoveOne = New System.Windows.Forms.Button()
            Me.btnSetNextBox = New System.Windows.Forms.Button()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtWHAndPickBox = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.lblnewBoxQty = New System.Windows.Forms.Label()
            Me.lbNewBox = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.tdgBoxSNs = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.pnlBox = New System.Windows.Forms.Panel()
            Me.pnlButtons = New System.Windows.Forms.Panel()
            Me.pnlQtyModel.SuspendLayout()
            Me.pnlChkBoxes.SuspendLayout()
            Me.pnlSplitBox.SuspendLayout()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlItemNeed.SuspendLayout()
            Me.pnlQuarantine.SuspendLayout()
            CType(Me.tdgBoxSNs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBox.SuspendLayout()
            Me.pnlButtons.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtBoxName
            '
            Me.txtBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxName.Location = New System.Drawing.Point(128, 8)
            Me.txtBoxName.Name = "txtBoxName"
            Me.txtBoxName.Size = New System.Drawing.Size(320, 26)
            Me.txtBoxName.TabIndex = 0
            Me.txtBoxName.Text = ""
            '
            'txtModel
            '
            Me.txtModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtModel.Location = New System.Drawing.Point(128, 8)
            Me.txtModel.Name = "txtModel"
            Me.txtModel.Size = New System.Drawing.Size(320, 26)
            Me.txtModel.TabIndex = 2
            Me.txtModel.Text = ""
            '
            'txtQty
            '
            Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtQty.Location = New System.Drawing.Point(128, 64)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(320, 26)
            Me.txtQty.TabIndex = 1
            Me.txtQty.Text = ""
            '
            'btnClear
            '
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(352, 16)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(75, 64)
            Me.btnClear.TabIndex = 6
            Me.btnClear.Text = "Clear"
            '
            'btnTransfer
            '
            Me.btnTransfer.BackColor = System.Drawing.Color.ForestGreen
            Me.btnTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnTransfer.ForeColor = System.Drawing.Color.White
            Me.btnTransfer.Location = New System.Drawing.Point(32, 16)
            Me.btnTransfer.Name = "btnTransfer"
            Me.btnTransfer.Size = New System.Drawing.Size(264, 64)
            Me.btnTransfer.TabIndex = 5
            Me.btnTransfer.Text = "Transfer"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Aquamarine
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(208, 23)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Transfer Pallet to WH"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(48, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 23)
            Me.Label2.TabIndex = 7
            Me.Label2.Text = "Pallet ID"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(48, 64)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 23)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "Quantity"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(16, 8)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(104, 23)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Model (Item)"
            '
            'chkBoxOverstock
            '
            Me.chkBoxOverstock.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxOverstock.ForeColor = System.Drawing.Color.White
            Me.chkBoxOverstock.Location = New System.Drawing.Point(16, 16)
            Me.chkBoxOverstock.Name = "chkBoxOverstock"
            Me.chkBoxOverstock.Size = New System.Drawing.Size(128, 24)
            Me.chkBoxOverstock.TabIndex = 3
            Me.chkBoxOverstock.Text = "To Overstock"
            '
            'chkBoxRelabel
            '
            Me.chkBoxRelabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxRelabel.ForeColor = System.Drawing.Color.White
            Me.chkBoxRelabel.Location = New System.Drawing.Point(440, 16)
            Me.chkBoxRelabel.Name = "chkBoxRelabel"
            Me.chkBoxRelabel.Size = New System.Drawing.Size(112, 24)
            Me.chkBoxRelabel.TabIndex = 4
            Me.chkBoxRelabel.Text = "To Relabel"
            '
            'pnlQtyModel
            '
            Me.pnlQtyModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.txtModel, Me.Label3, Me.txtQty, Me.lblModelID})
            Me.pnlQtyModel.Location = New System.Drawing.Point(16, 152)
            Me.pnlQtyModel.Name = "pnlQtyModel"
            Me.pnlQtyModel.Size = New System.Drawing.Size(536, 112)
            Me.pnlQtyModel.TabIndex = 10
            '
            'lblModelID
            '
            Me.lblModelID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelID.ForeColor = System.Drawing.Color.White
            Me.lblModelID.Location = New System.Drawing.Point(448, 14)
            Me.lblModelID.Name = "lblModelID"
            Me.lblModelID.Size = New System.Drawing.Size(52, 23)
            Me.lblModelID.TabIndex = 16
            Me.lblModelID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblModelID.Visible = False
            '
            'chkBoxPickLoc
            '
            Me.chkBoxPickLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxPickLoc.ForeColor = System.Drawing.Color.White
            Me.chkBoxPickLoc.Location = New System.Drawing.Point(152, 16)
            Me.chkBoxPickLoc.Name = "chkBoxPickLoc"
            Me.chkBoxPickLoc.Size = New System.Drawing.Size(144, 24)
            Me.chkBoxPickLoc.TabIndex = 10
            Me.chkBoxPickLoc.Text = "To Pick Location"
            '
            'pnlChkBoxes
            '
            Me.pnlChkBoxes.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkBoxQuarantine, Me.chkBoxOverstock, Me.chkBoxRelabel, Me.chkBoxPickLoc})
            Me.pnlChkBoxes.Location = New System.Drawing.Point(16, 40)
            Me.pnlChkBoxes.Name = "pnlChkBoxes"
            Me.pnlChkBoxes.Size = New System.Drawing.Size(560, 48)
            Me.pnlChkBoxes.TabIndex = 11
            '
            'chkBoxQuarantine
            '
            Me.chkBoxQuarantine.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxQuarantine.ForeColor = System.Drawing.Color.White
            Me.chkBoxQuarantine.Location = New System.Drawing.Point(304, 16)
            Me.chkBoxQuarantine.Name = "chkBoxQuarantine"
            Me.chkBoxQuarantine.Size = New System.Drawing.Size(128, 24)
            Me.chkBoxQuarantine.TabIndex = 11
            Me.chkBoxQuarantine.Text = "To Quarantine"
            '
            'pnlSplitBox
            '
            Me.pnlSplitBox.BackColor = System.Drawing.Color.SlateGray
            Me.pnlSplitBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.btnDoSplit, Me.Label9, Me.Label8, Me.Label7, Me.Label6})
            Me.pnlSplitBox.Location = New System.Drawing.Point(488, 312)
            Me.pnlSplitBox.Name = "pnlSplitBox"
            Me.pnlSplitBox.Size = New System.Drawing.Size(80, 40)
            Me.pnlSplitBox.TabIndex = 13
            '
            'Button1
            '
            Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button1.ForeColor = System.Drawing.Color.White
            Me.Button1.Location = New System.Drawing.Point(248, 176)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(88, 32)
            Me.Button1.TabIndex = 19
            Me.Button1.Text = "Cancel"
            '
            'btnDoSplit
            '
            Me.btnDoSplit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDoSplit.ForeColor = System.Drawing.Color.White
            Me.btnDoSplit.Location = New System.Drawing.Point(248, 120)
            Me.btnDoSplit.Name = "btnDoSplit"
            Me.btnDoSplit.Size = New System.Drawing.Size(88, 48)
            Me.btnDoSplit.TabIndex = 18
            Me.btnDoSplit.Text = "OK"
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(16, 168)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(88, 23)
            Me.Label9.TabIndex = 17
            Me.Label9.Text = "Total Qty:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(24, 48)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(72, 23)
            Me.Label8.TabIndex = 15
            Me.Label8.Text = "Qty:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(24, 120)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(72, 23)
            Me.Label7.TabIndex = 13
            Me.Label7.Text = "Qty:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(24, 88)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(72, 23)
            Me.Label6.TabIndex = 11
            Me.Label6.Text = "New:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(496, 272)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 40)
            Me.Label5.TabIndex = 9
            Me.Label5.Text = "Original:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label5.Visible = False
            '
            'txtOriginalQty
            '
            Me.txtOriginalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtOriginalQty.Location = New System.Drawing.Point(480, 8)
            Me.txtOriginalQty.Name = "txtOriginalQty"
            Me.txtOriginalQty.Size = New System.Drawing.Size(64, 26)
            Me.txtOriginalQty.TabIndex = 10
            Me.txtOriginalQty.Text = ""
            Me.txtOriginalQty.Visible = False
            '
            'lblOldBox
            '
            Me.lblOldBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOldBox.ForeColor = System.Drawing.Color.White
            Me.lblOldBox.Location = New System.Drawing.Point(360, 16)
            Me.lblOldBox.Name = "lblOldBox"
            Me.lblOldBox.Size = New System.Drawing.Size(112, 23)
            Me.lblOldBox.TabIndex = 14
            Me.lblOldBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblOldBox.Visible = False
            '
            'lblOriginalWBID
            '
            Me.lblOriginalWBID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOriginalWBID.ForeColor = System.Drawing.Color.White
            Me.lblOriginalWBID.Location = New System.Drawing.Point(496, 40)
            Me.lblOriginalWBID.Name = "lblOriginalWBID"
            Me.lblOriginalWBID.Size = New System.Drawing.Size(52, 23)
            Me.lblOriginalWBID.TabIndex = 15
            Me.lblOriginalWBID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblOriginalWBID.Visible = False
            '
            'tdgData1
            '
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.SteelBlue
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.CaptionHeight = 17
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(16, 16)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(352, 408)
            Me.tdgData1.TabIndex = 164
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 9pt;}HighlightR" & _
            "ow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{" & _
            "AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1," & _
            " 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near" & _
            ";}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGri" & _
            "d.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionH" & _
            "eight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Marque" & _
            "eStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalS" & _
            "crollGroup=""1"" HorizontalScrollGroup=""1""><Height>406</Height><CaptionStyle paren" & _
            "t=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSty" & _
            "le parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13" & _
            """ /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""St" & _
            "yle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=" & _
            """HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Odd" & _
            "RowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelect" & _
            "or"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=" & _
            """Normal"" me=""Style1"" /><ClientRect>0, 0, 350, 406</ClientRect><BorderSide>0</Bor" & _
            "derSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecS" & _
            "elWidth><ClientArea>0, 0, 350, 406</ClientArea><PrintPageHeaderStyle parent="""" m" & _
            "e=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblItemCountVal
            '
            Me.lblItemCountVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblItemCountVal.ForeColor = System.Drawing.Color.AliceBlue
            Me.lblItemCountVal.Location = New System.Drawing.Point(104, 424)
            Me.lblItemCountVal.Name = "lblItemCountVal"
            Me.lblItemCountVal.Size = New System.Drawing.Size(72, 16)
            Me.lblItemCountVal.TabIndex = 171
            Me.lblItemCountVal.Text = "0"
            '
            'lblTotalItemQtyVal
            '
            Me.lblTotalItemQtyVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalItemQtyVal.ForeColor = System.Drawing.Color.AliceBlue
            Me.lblTotalItemQtyVal.Location = New System.Drawing.Point(288, 424)
            Me.lblTotalItemQtyVal.Name = "lblTotalItemQtyVal"
            Me.lblTotalItemQtyVal.Size = New System.Drawing.Size(96, 16)
            Me.lblTotalItemQtyVal.TabIndex = 170
            Me.lblTotalItemQtyVal.Text = "0"
            '
            'lblItemCount
            '
            Me.lblItemCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblItemCount.ForeColor = System.Drawing.Color.AliceBlue
            Me.lblItemCount.Location = New System.Drawing.Point(16, 424)
            Me.lblItemCount.Name = "lblItemCount"
            Me.lblItemCount.Size = New System.Drawing.Size(96, 16)
            Me.lblItemCount.TabIndex = 169
            Me.lblItemCount.Text = "Item Count:"
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.AliceBlue
            Me.Label10.Location = New System.Drawing.Point(216, 424)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(72, 16)
            Me.Label10.TabIndex = 168
            Me.Label10.Text = "Total Qty:"
            '
            'pnlItemNeed
            '
            Me.pnlItemNeed.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgData1, Me.lblItemCountVal, Me.lblTotalItemQtyVal, Me.lblItemCount, Me.Label10})
            Me.pnlItemNeed.Location = New System.Drawing.Point(584, 8)
            Me.pnlItemNeed.Name = "pnlItemNeed"
            Me.pnlItemNeed.Size = New System.Drawing.Size(392, 464)
            Me.pnlItemNeed.TabIndex = 172
            '
            'pnlQuarantine
            '
            Me.pnlQuarantine.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSelectedBoxModel, Me.lblSelectedBoxModelID, Me.lblSelectedBoxQty, Me.lblNewBoxID, Me.btnCompleteQuarantine, Me.btnRemoveAll, Me.btnRemoveOne, Me.btnSetNextBox, Me.Label12, Me.txtWHAndPickBox, Me.Label14, Me.lblnewBoxQty, Me.lbNewBox, Me.txtSN, Me.tdgBoxSNs, Me.Label11, Me.Label13})
            Me.pnlQuarantine.Location = New System.Drawing.Point(16, 384)
            Me.pnlQuarantine.Name = "pnlQuarantine"
            Me.pnlQuarantine.Size = New System.Drawing.Size(744, 312)
            Me.pnlQuarantine.TabIndex = 173
            '
            'lblSelectedBoxModel
            '
            Me.lblSelectedBoxModel.BackColor = System.Drawing.Color.SteelBlue
            Me.lblSelectedBoxModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelectedBoxModel.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblSelectedBoxModel.Location = New System.Drawing.Point(64, 32)
            Me.lblSelectedBoxModel.Name = "lblSelectedBoxModel"
            Me.lblSelectedBoxModel.Size = New System.Drawing.Size(288, 24)
            Me.lblSelectedBoxModel.TabIndex = 211
            Me.lblSelectedBoxModel.Text = "model item"
            Me.lblSelectedBoxModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSelectedBoxModelID
            '
            Me.lblSelectedBoxModelID.BackColor = System.Drawing.Color.SteelBlue
            Me.lblSelectedBoxModelID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelectedBoxModelID.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblSelectedBoxModelID.Location = New System.Drawing.Point(656, 32)
            Me.lblSelectedBoxModelID.Name = "lblSelectedBoxModelID"
            Me.lblSelectedBoxModelID.Size = New System.Drawing.Size(64, 24)
            Me.lblSelectedBoxModelID.TabIndex = 210
            Me.lblSelectedBoxModelID.Text = "0"
            Me.lblSelectedBoxModelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSelectedBoxModelID.Visible = False
            '
            'lblSelectedBoxQty
            '
            Me.lblSelectedBoxQty.BackColor = System.Drawing.Color.SteelBlue
            Me.lblSelectedBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelectedBoxQty.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblSelectedBoxQty.Location = New System.Drawing.Point(656, 8)
            Me.lblSelectedBoxQty.Name = "lblSelectedBoxQty"
            Me.lblSelectedBoxQty.Size = New System.Drawing.Size(64, 24)
            Me.lblSelectedBoxQty.TabIndex = 209
            Me.lblSelectedBoxQty.Text = "0"
            Me.lblSelectedBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSelectedBoxQty.Visible = False
            '
            'lblNewBoxID
            '
            Me.lblNewBoxID.BackColor = System.Drawing.Color.SteelBlue
            Me.lblNewBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNewBoxID.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblNewBoxID.Location = New System.Drawing.Point(672, 144)
            Me.lblNewBoxID.Name = "lblNewBoxID"
            Me.lblNewBoxID.Size = New System.Drawing.Size(64, 24)
            Me.lblNewBoxID.TabIndex = 208
            Me.lblNewBoxID.Text = "0"
            Me.lblNewBoxID.Visible = False
            '
            'btnCompleteQuarantine
            '
            Me.btnCompleteQuarantine.BackColor = System.Drawing.Color.ForestGreen
            Me.btnCompleteQuarantine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCompleteQuarantine.ForeColor = System.Drawing.Color.White
            Me.btnCompleteQuarantine.Location = New System.Drawing.Point(456, 240)
            Me.btnCompleteQuarantine.Name = "btnCompleteQuarantine"
            Me.btnCompleteQuarantine.Size = New System.Drawing.Size(184, 56)
            Me.btnCompleteQuarantine.TabIndex = 207
            Me.btnCompleteQuarantine.Text = "Complete Quarantine"
            '
            'btnRemoveAll
            '
            Me.btnRemoveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAll.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAll.Location = New System.Drawing.Point(456, 184)
            Me.btnRemoveAll.Name = "btnRemoveAll"
            Me.btnRemoveAll.Size = New System.Drawing.Size(184, 40)
            Me.btnRemoveAll.TabIndex = 206
            Me.btnRemoveAll.Text = "Remove All"
            '
            'btnRemoveOne
            '
            Me.btnRemoveOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveOne.ForeColor = System.Drawing.Color.White
            Me.btnRemoveOne.Location = New System.Drawing.Point(456, 136)
            Me.btnRemoveOne.Name = "btnRemoveOne"
            Me.btnRemoveOne.Size = New System.Drawing.Size(184, 40)
            Me.btnRemoveOne.TabIndex = 205
            Me.btnRemoveOne.Text = "Remove One"
            '
            'btnSetNextBox
            '
            Me.btnSetNextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSetNextBox.ForeColor = System.Drawing.Color.White
            Me.btnSetNextBox.Location = New System.Drawing.Point(448, 5)
            Me.btnSetNextBox.Name = "btnSetNextBox"
            Me.btnSetNextBox.Size = New System.Drawing.Size(192, 27)
            Me.btnSetNextBox.TabIndex = 204
            Me.btnSetNextBox.Text = "Set New Source Pallet"
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.SteelBlue
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label12.Location = New System.Drawing.Point(8, 8)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(56, 16)
            Me.Label12.TabIndex = 203
            Me.Label12.Text = "Pallet:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtWHAndPickBox
            '
            Me.txtWHAndPickBox.BackColor = System.Drawing.Color.White
            Me.txtWHAndPickBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWHAndPickBox.Location = New System.Drawing.Point(64, 5)
            Me.txtWHAndPickBox.Name = "txtWHAndPickBox"
            Me.txtWHAndPickBox.Size = New System.Drawing.Size(376, 26)
            Me.txtWHAndPickBox.TabIndex = 202
            Me.txtWHAndPickBox.Text = ""
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.SteelBlue
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label14.Location = New System.Drawing.Point(576, 80)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(56, 24)
            Me.Label14.TabIndex = 201
            Me.Label14.Text = "Qty:"
            '
            'lblnewBoxQty
            '
            Me.lblnewBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblnewBoxQty.ForeColor = System.Drawing.Color.PaleGreen
            Me.lblnewBoxQty.Location = New System.Drawing.Point(464, 104)
            Me.lblnewBoxQty.Name = "lblnewBoxQty"
            Me.lblnewBoxQty.Size = New System.Drawing.Size(136, 24)
            Me.lblnewBoxQty.TabIndex = 200
            Me.lblnewBoxQty.Text = "0"
            Me.lblnewBoxQty.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lbNewBox
            '
            Me.lbNewBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbNewBox.ForeColor = System.Drawing.Color.Lime
            Me.lbNewBox.Location = New System.Drawing.Point(688, 104)
            Me.lbNewBox.Name = "lbNewBox"
            Me.lbNewBox.Size = New System.Drawing.Size(8, 16)
            Me.lbNewBox.TabIndex = 198
            Me.lbNewBox.Text = "TR20180709-0010"
            Me.lbNewBox.Visible = False
            '
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.White
            Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.Location = New System.Drawing.Point(64, 56)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(376, 26)
            Me.txtSN.TabIndex = 193
            Me.txtSN.Text = ""
            '
            'tdgBoxSNs
            '
            Me.tdgBoxSNs.AllowColSelect = False
            Me.tdgBoxSNs.AllowFilter = False
            Me.tdgBoxSNs.AllowSort = False
            Me.tdgBoxSNs.AllowUpdate = False
            Me.tdgBoxSNs.AllowUpdateOnBlur = False
            Me.tdgBoxSNs.AlternatingRows = True
            Me.tdgBoxSNs.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tdgBoxSNs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgBoxSNs.CaptionHeight = 17
            Me.tdgBoxSNs.FetchRowStyles = True
            Me.tdgBoxSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgBoxSNs.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgBoxSNs.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgBoxSNs.Location = New System.Drawing.Point(16, 80)
            Me.tdgBoxSNs.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgBoxSNs.Name = "tdgBoxSNs"
            Me.tdgBoxSNs.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgBoxSNs.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgBoxSNs.PreviewInfo.ZoomFactor = 75
            Me.tdgBoxSNs.RowHeight = 20
            Me.tdgBoxSNs.Size = New System.Drawing.Size(424, 216)
            Me.tdgBoxSNs.TabIndex = 196
            Me.tdgBoxSNs.Text = "C1TrueDBGrid1"
            Me.tdgBoxSNs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 9.75pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised," & _
            ",1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
            "Grid.MergeView AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" Caption" & _
            "Height=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""Tru" & _
            "e"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" " & _
            "VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>214</Height><CaptionSt" & _
            "yle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><E" & _
            "venRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me" & _
            "=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Grou" & _
            "p"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyl" & _
            "e parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style" & _
            "4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Rec" & _
            "ordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Styl" & _
            "e parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 422, 214</ClientRect><BorderSi" & _
            "de>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeVie" & _
            "w></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me" & _
            "=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""C" & _
            "aption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Sel" & _
            "ected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlig" & _
            "htRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow" & _
            """ /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Fil" & _
            "terBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vert" & _
            "Splits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</De" & _
            "faultRecSelWidth><ClientArea>0, 0, 422, 214</ClientArea><PrintPageHeaderStyle pa" & _
            "rent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.SteelBlue
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label11.Location = New System.Drawing.Point(24, 56)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(40, 16)
            Me.Label11.TabIndex = 194
            Me.Label11.Text = "SN:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.SteelBlue
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label13.Location = New System.Drawing.Point(456, 80)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(136, 24)
            Me.Label13.TabIndex = 199
            Me.Label13.Text = "Quarantine Pallet:"
            '
            'pnlBox
            '
            Me.pnlBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBoxName, Me.Label2})
            Me.pnlBox.Location = New System.Drawing.Point(16, 104)
            Me.pnlBox.Name = "pnlBox"
            Me.pnlBox.Size = New System.Drawing.Size(536, 40)
            Me.pnlBox.TabIndex = 174
            '
            'pnlButtons
            '
            Me.pnlButtons.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.btnTransfer})
            Me.pnlButtons.Location = New System.Drawing.Point(16, 272)
            Me.pnlButtons.Name = "pnlButtons"
            Me.pnlButtons.Size = New System.Drawing.Size(464, 96)
            Me.pnlButtons.TabIndex = 175
            '
            'frmTFFK_WH_Transfer
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1216, 702)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlButtons, Me.pnlBox, Me.pnlQuarantine, Me.pnlItemNeed, Me.lblOldBox, Me.pnlSplitBox, Me.pnlChkBoxes, Me.pnlQtyModel, Me.Label1, Me.txtOriginalQty, Me.Label5, Me.lblOriginalWBID})
            Me.Name = "frmTFFK_WH_Transfer"
            Me.Text = "WH Transfer"
            Me.pnlQtyModel.ResumeLayout(False)
            Me.pnlChkBoxes.ResumeLayout(False)
            Me.pnlSplitBox.ResumeLayout(False)
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlItemNeed.ResumeLayout(False)
            Me.pnlQuarantine.ResumeLayout(False)
            CType(Me.tdgBoxSNs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBox.ResumeLayout(False)
            Me.pnlButtons.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_WH_Transfer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me.txtModel.ReadOnly = True
                Me.pnlQtyModel.Enabled = False
                Me.btnTransfer.Enabled = False
                Me.btnClear.Enabled = False
                Me.pnlSplitBox.Visible = False
                Me.chkBoxPickLoc.Checked = False
                Me.pnlItemNeed.Visible = False


                Me.chkBoxOverstock.Checked = True : Me.chkBoxRelabel.Checked = False
                Me.chkBoxPickLoc.Checked = False : Me.chkBoxQuarantine.Checked = False

                Me.pnlQuarantine.Visible = False

                Me.chkBoxRelabel.Visible = False 'no need relabel here

                Me.txtBoxName.Text = "" : Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()

                Me.LoadItemNeed()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTFFK_WH_Transfer_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub txtBoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtBoxName.Text.Trim.Length > 0 Then
                    If Not Me.chkBoxQuarantine.Checked Then
                        Me.ProcessBox()
                    Else
                        MessageBox.Show("Not for Quarantine method. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtPONumber_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ProcessBox()
            Dim strBoxName As String = ""

            Try
                strBoxName = Me.txtBoxName.Text.Trim
                If Not strBoxName.Length > 0 Then
                    MessageBox.Show("Enater a pallet ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    Exit Sub
                End If

                If Not OneCheckBoxSelected() Then
                    MessageBox.Show("Please select a checkbox.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Cursor.Current = Cursors.WaitCursor

                Me._dtBox = Me._objTFFKRec.getReceivedWHWIPBox(strBoxName)
                If Not Me._dtBox.Rows.Count > 0 Then
                    MessageBox.Show("Can't find this pallet '" & strBoxName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                ElseIf Me._dtBox.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                Else '=1
                    If Trim(Me._dtBox.Rows(0).Item("HasModel")).ToString.Trim.ToUpper = "No".ToUpper Then
                        MessageBox.Show("No model for this pallet '" & strBoxName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    ElseIf Me.chkBoxOverstock.Checked AndAlso Trim(Me._dtBox.Rows(0).Item("HasWHLocation")).ToString.Trim.ToUpper = "Yes".ToUpper Then
                        MessageBox.Show("This pallet '" & strBoxName & "' already has a WH location assigned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    ElseIf Not Me.chkBoxOverstock.Checked AndAlso Trim(Me._dtBox.Rows(0).Item("HasWHLocation")).ToString.Trim.ToUpper = "No".ToUpper Then
                        MessageBox.Show("This pallet '" & strBoxName & "' has no WH location assigned. Can't omve to pick-location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                    Else
                        Me.txtModel.Text = Trim(Me._dtBox.Rows(0).Item("Model_Desc")).ToString
                        Me.txtQty.Text = Convert.ToInt32(Me._dtBox.Rows(0).Item("Qty")).ToString
                        Me.lblModelID.Text = Convert.ToInt32(Me._dtBox.Rows(0).Item("Model_ID")).ToString
                        If Me.chkBoxPickLoc.Checked Then
                            Me.txtOriginalQty.Text = Me.txtQty.Text
                            Me.lblOriginalWBID.Text = Convert.ToInt32(Me._dtBox.Rows(0).Item("wb_ID")).ToString
                            Me.txtQty.Enabled = True
                        Else
                            Me.txtOriginalQty.Text = ""
                            Me.txtQty.Enabled = False
                        End If

                        Me.lblOldBox.Text = ""
                        Me.txtModel.Enabled = False
                        Me.btnTransfer.Enabled = True
                        Me.btnClear.Enabled = True
                        Me.txtBoxName.ReadOnly = True
                        Me.pnlQtyModel.Enabled = True
                        Me.btnTransfer.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
            End Try

        End Sub

        Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
            Try
                If Me.chkBoxOverstock.Checked Then
                    Me.TransferToWH()
                ElseIf Me.chkBoxPickLoc.Checked Then
                    Me.TransferToPickLocation()
                ElseIf Me.chkBoxRelabel.Checked Then
                    Dim frmRelabel As New frmTFFK_RelabelModel()
                    frmRelabel.ShowDialog()
                    frmRelabel.Dispose()
                ElseIf Me.chkBoxQuarantine.Checked Then
                    'do nothing
                    MessageBox.Show("Not for Quarantine method. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("No checkbox has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub TransferToWH()
            Dim iMaxWhLocation As Integer = 25
            Dim strWhLocation As String = ""
            Dim iWB_ID As Integer = 0
            Dim i As Integer = 0
        
            Try

                strWhLocation = InputBox("Enter a warehouse location:", "Enter number", "")
                If strWhLocation.Trim.Length = 0 Then
                    MessageBox.Show("Please enter a warehouse location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf strWhLocation.Trim.Length > iMaxWhLocation Then
                    MessageBox.Show("Max length of warehouse location is " & iMaxWhLocation.ToString & ". Can't set.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me.chkBoxOverstock.Checked = False AndAlso Me.chkBoxPickLoc.Checked = False AndAlso Me.chkBoxPickLoc.Checked = False Then
                    MessageBox.Show("Please select a checkbox.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf strWhLocation.Trim.Length > 0 AndAlso strWhLocation.Trim.Length <= iMaxWhLocation Then
                    iWB_ID = Convert.ToInt32(Me._dtBox.Rows(0).Item("wb_id"))
                    i = Me._objTFFKRec.UpdateWarehouseBoxLocation(iWB_ID, strWhLocation)
                    If i > 0 Then
                        MessageBox.Show("The pallet has been transferred to warehouse location: " & strWhLocation & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.ClearControls()
                    Else
                        MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf strWhLocation = String.Empty Then
                    MessageBox.Show("You've canceled/empty/failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Exception occurred.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " TransferToWH", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.ClearControls()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub TransferToPickLocation()
            Dim iQty As Integer = 0
            Dim iOriginalQty As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim strNewBox As String = ""
            Dim strPickLocation As String = ""
            Dim strWorkstation As String = PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._strPickWorkstation
            Dim iwb_ID_Old As Integer = 0
            Dim iwb_ID_New As Integer = 0
            Dim i As Integer = 0
            Dim strReceiptDate As String = ""
            Dim strReceiptNo As String = ""
            Dim strTFPoNo As String = ""

            Try
                If Me.txtQty.Text.Trim.Length = 0 OrElse Not IsNumeric(Me.txtQty.Text.Trim) Then
                    MessageBox.Show("Enter a valid quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                iQty = Convert.ToInt32(Me.txtQty.Text) : Me.txtQty.Text = iQty
                iOriginalQty = Convert.ToInt32(Me.txtOriginalQty.Text)
                If iQty = iOriginalQty Then 'whole box move to pick loction
                    iModel_ID = Convert.ToInt32(Me.lblModelID.Text)
                    strPickLocation = Me._objTFFKPickPackShip.getPickLocation(iModel_ID)
                    iwb_ID_Old = Convert.ToInt32(Me.lblOriginalWBID.Text)
                    If Not strPickLocation.Trim.Length > 0 Then
                        MessageBox.Show("Failed to move. No Pick Location found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        i = Me._objTFFKPickPackShip.UpdatePickLocationBoxForFullBox(iwb_ID_Old, strWorkstation, strPickLocation)
                        If i > 0 Then
                            Me._objTFFKRec.PrintPickLocation(Me.txtModel.Text, iOriginalQty, strPickLocation, _
                                                                                               PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iWHRecvBoxLabelCopiesNumber)
                            MessageBox.Show(iQty.ToString & " are moved to the pick-location:" & strPickLocation, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.ClearControls()
                        Else
                            MessageBox.Show("Failed to move. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                Else 'split original box, new box move to pick location 
                    If Not Convert.ToInt32(Me.txtQty.Text) >= 1 Then
                        MessageBox.Show("Qty must be >= 1.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf Convert.ToInt32(Me.txtQty.Text) >= Convert.ToInt32(Me.txtOriginalQty.Text) Then
                        MessageBox.Show("The pallet has " & Me.txtOriginalQty.Text & " You can't enter a number >= " & Me.txtOriginalQty.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        strNewBox = Me._objTFFKPickPackShip.getNewBoxName(Me.txtBoxName.Text)
                        If strNewBox.Trim.Length = 0 Then
                            MessageBox.Show("Can't define box name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            iwb_ID_Old = Convert.ToInt32(Me.lblOriginalWBID.Text)
                            iModel_ID = Convert.ToInt32(Me.lblModelID.Text)
                            Me.lblOldBox.Text = Me.txtBoxName.Text
                            Me.txtBoxName.Text = strNewBox
                            strPickLocation = Me._objTFFKPickPackShip.getPickLocation(iModel_ID)
                            If Not strPickLocation.Trim.Length > 0 Then
                                MessageBox.Show("Failed to move. No Pick Location found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Me.txtBoxName.Text = Me.lblOldBox.Text
                            Else
                                iwb_ID_New = Me._objTFFKPickPackShip.CreateNewSplitBox(iwb_ID_Old, strNewBox)
                                If iwb_ID_New > 0 Then
                                    i = Me._objTFFKPickPackShip.UpdatePickLocationBoxForSplitBoxes(iwb_ID_Old, iOriginalQty, iwb_ID_New, iQty, strWorkstation, strPickLocation)
                                    If i > 0 Then 'successed
                                        'Print label for old box
                                        strTFPoNo = Trim(Me._dtBox.Rows(0).Item("PO Number")).ToString
                                        strReceiptDate = Trim(Me._dtBox.Rows(0).Item("Receipt_Date")).ToString
                                        strReceiptNo = Trim(Me._dtBox.Rows(0).Item("WR_ID")).ToString
                                        Me._objTFFKRec.PrintWarehouseFKRecBoxID(Me.lblOldBox.Text, Me.txtModel.Text, iOriginalQty - iQty, _
                                                       strTFPoNo, "", strReceiptDate, strReceiptNo, _
                                                       PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iWHRecvBoxLabelCopiesNumber)
                                        Me._objTFFKPickPackShip.InsertSplitBoxLogData(iwb_ID_Old, Me.lblOldBox.Text, iOriginalQty, iwb_ID_New, strNewBox, iQty, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))

                                        Me._objTFFKRec.PrintPickLocation(Me.txtModel.Text, iQty, strPickLocation, _
                                                                                               PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iWHRecvBoxLabelCopiesNumber)
                                        MessageBox.Show(iQty.ToString & " are moved to the pick-location:" & strPickLocation, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Me.ClearControls()
                                    Else
                                        MessageBox.Show("Failed to move. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Me.txtBoxName.Text = Me.lblOldBox.Text
                                    End If
                                Else
                                    MessageBox.Show("Failed to move. No box ID found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Me.txtBoxName.Text = Me.lblOldBox.Text
                                End If
                            End If
                        End If
                    End If
            End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "TransferToPickLocation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Cursor.Current = Cursors.Default
            End Try
        End Sub


        Private Sub ClearControls()
            Try
                With Me
                    .txtModel.Text = "" : .txtQty.Text = "" : .txtOriginalQty.Text = ""
                    .pnlQtyModel.Enabled = False
                    .btnTransfer.Enabled = False
                    .txtBoxName.ReadOnly = False
                    .lblModelID.Text = ""
                    .lblOldBox.Text = ""
                    .lblOriginalWBID.Text = ""
                    .pnlBox.Visible = True
                    .pnlButtons.Visible = True
                    .pnlQtyModel.Visible = True
                    .Label2.Visible = True : .txtBoxName.Visible = True
                    .btnClear.Visible = True : .btnTransfer.Visible = True
                    .pnlQuarantine.Visible = False

                    .txtBoxName.Text = "" : .txtBoxName.SelectAll() : .txtBoxName.Focus()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "  ClearControls", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub RefreshQuarantineBoxQty()
            Try
                If IsNothing(Me._dbQuarantine) OrElse Not Me._dbQuarantine.Rows.Count > 0 Then
                    Me.lblnewBoxQty.Text = 0
                Else
                    Me.lblnewBoxQty.Text = Me._dbQuarantine.Rows.Count
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.ToString, "RefreshQuarantineBoxQty", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub chkBoxOverstock_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoxOverstock.CheckedChanged
            Try
                Me.pnlItemNeed.Visible = False
                If Me.chkBoxOverstock.Checked Then
                    Me.chkBoxOverstock.ForeColor = Color.LawnGreen
                    Me.chkBoxOverstock.Font = New Font(Me.chkBoxOverstock.Font, FontStyle.Bold)
                    Me.chkBoxPickLoc.Checked = False : Me.chkBoxQuarantine.Checked = False : Me.chkBoxRelabel.Checked = False
                    Me.ClearControls()
                    Me.btnTransfer.Text = "Transfer " & Me.chkBoxOverstock.Text
                Else
                    Me.chkBoxOverstock.ForeColor = Color.White
                    Me.chkBoxOverstock.Font = New Font(Me.chkBoxOverstock.Font, FontStyle.Regular)
                    If Me.chkBoxPickLoc.Checked = False AndAlso Me.chkBoxQuarantine.Checked = False AndAlso Me.chkBoxRelabel.Checked = False Then
                        Me.chkBoxOverstock.Checked = True
                        Me.ClearControls()
                        Me.btnTransfer.Text = "Transfer " & Me.chkBoxOverstock.Text
                    Else
                        Me.chkBoxOverstock.Checked = False
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkBoxOverstock_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub chkBoxPickLoc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoxPickLoc.CheckedChanged
            Try
                'Me.pnlItemNeed.Visible = False
                Me.pnlQuarantine.Visible = False
                If Me.chkBoxPickLoc.Checked Then
                    'Me.pnlItemNeed.Visible = True
                    Me.chkBoxPickLoc.ForeColor = Color.LawnGreen
                    Me.chkBoxPickLoc.Font = New Font(Me.chkBoxPickLoc.Font, FontStyle.Bold)
                    Me.chkBoxOverstock.Checked = False : Me.chkBoxQuarantine.Checked = False : Me.chkBoxRelabel.Checked = False
                    ' Me.LoadItemNeed()

                    Me.ClearControls()
                    Me.btnTransfer.Text = "Transfer " & Me.chkBoxPickLoc.Text
                Else
                    Me.chkBoxPickLoc.ForeColor = Color.White
                    Me.chkBoxPickLoc.Font = New Font(Me.chkBoxPickLoc.Font, FontStyle.Regular)
                    If Me.chkBoxOverstock.Checked = False AndAlso Me.chkBoxQuarantine.Checked = False AndAlso Me.chkBoxRelabel.Checked = False Then
                        Me.chkBoxPickLoc.Checked = True

                        Me.ClearControls()
                        Me.btnTransfer.Text = "Transfer " & Me.chkBoxPickLoc.Text
                    Else
                        Me.chkBoxPickLoc.Checked = False
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkBoxPickLoc_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub chkBoxRelabel_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoxRelabel.CheckedChanged
            Try
                Me.pnlItemNeed.Visible = False
                If Me.chkBoxRelabel.Checked Then
                    Me.chkBoxRelabel.ForeColor = Color.LawnGreen
                    Me.chkBoxRelabel.Font = New Font(Me.chkBoxRelabel.Font, FontStyle.Bold)
                    Me.chkBoxOverstock.Checked = False : Me.chkBoxQuarantine.Checked = False : Me.chkBoxPickLoc.Checked = False
                    Me.ClearControls()
                    Me.btnTransfer.Text = "Transfer " & Me.chkBoxRelabel.Text
                Else
                    Me.chkBoxRelabel.ForeColor = Color.White
                    Me.chkBoxRelabel.Font = New Font(Me.chkBoxRelabel.Font, FontStyle.Regular)
                    If Me.chkBoxPickLoc.Checked = False AndAlso Me.chkBoxQuarantine.Checked = False AndAlso Me.chkBoxOverstock.Checked = False Then
                        Me.chkBoxRelabel.Checked = True
                        Me.ClearControls()
                        Me.btnTransfer.Text = "Transfer " & Me.chkBoxRelabel.Text
                    Else
                        Me.chkBoxRelabel.Checked = False
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkBoxRelabel_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub chkBoxQuarantine_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoxQuarantine.CheckedChanged
            Try
                If Me.chkBoxQuarantine.Checked Then
                    Me.chkBoxQuarantine.ForeColor = Color.LawnGreen
                    Me.chkBoxQuarantine.Font = New Font(Me.chkBoxQuarantine.Font, FontStyle.Bold)
                    Me.chkBoxOverstock.Checked = False : Me.chkBoxRelabel.Checked = False : Me.chkBoxPickLoc.Checked = False
                    Me.ClearQuarantineControls()
                    Me.txtSN.Enabled = False : Me.txtWHAndPickBox.Enabled = True
                    Me.txtWHAndPickBox.SelectAll() : Me.txtWHAndPickBox.Focus()
                Else
                    Me.chkBoxQuarantine.ForeColor = Color.White
                    Me.chkBoxQuarantine.Font = New Font(Me.chkBoxQuarantine.Font, FontStyle.Regular)
                    If Me.chkBoxPickLoc.Checked = False AndAlso Me.chkBoxRelabel.Checked = False AndAlso Me.chkBoxOverstock.Checked = False Then
                        Me.chkBoxQuarantine.Checked = True
                        Me.txtSN.Enabled = False : Me.txtWHAndPickBox.Enabled = True
                        Me.ClearQuarantineControls()
                    Else
                        Me.chkBoxQuarantine.Checked = False
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkBoxRelabel_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ClearQuarantineControls()
            Try
                With Me
                    .txtWHAndPickBox.Text = ""
                    .txtSN.Text = ""
                    .lbNewBox.Text = ""
                    .lblnewBoxQty.Text = 0
                    .lblNewBoxID.Text = 0
                    .lblSelectedBoxModel.Text = ""
                    .lblSelectedBoxModelID.Text = 0
                    .lblSelectedBoxQty.Text = 0
                    .tdgBoxSNs.DataSource = Nothing
                    ._dbQuarantine = Nothing

                    .pnlQuarantine.Top = .pnlBox.Top
                    .pnlQuarantine.Left = .pnlBox.Left

                    .pnlBox.Visible = False 'not work well
                    .Label2.Visible = False : .txtBoxName.Visible = False
                    .pnlButtons.Visible = False 'not work well
                    .btnClear.Visible = False : .btnTransfer.Visible = False
                    .pnlItemNeed.Visible = False
                    .pnlQtyModel.Visible = False

                    .pnlQuarantine.Visible = True
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearQuarantineControls", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Function OneCheckBoxSelected() As Boolean
            Try
                If Me.chkBoxOverstock.Checked = False _
                   AndAlso Me.chkBoxPickLoc.Checked = False _
                   AndAlso Me.chkBoxQuarantine.Checked = False _
                   AndAlso Me.chkBoxRelabel.Checked = False Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "OneCheckBoxSelected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Sub btnCheckItemNeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim dt As DataTable
            Try

                dt = Me._objTFFKPickPackShip.getItemsNeedForOpenOrders

                If dt.Rows.Count > 0 Then
                    Dim fm As New frmTFFK_OrderNeed(dt)
                    fm.ShowDialog()
                    fm.Dispose()
                Else
                    MessageBox.Show("No open orders..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnCheckItemNeed_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadItemNeed()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim dt As DataTable

            Try
                dt = Me._objTFFKPickPackShip.getItemsNeedForOpenOrders
                If dt.Rows.Count > 0 Then
                    With Me.tdgData1
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc

                        .Splits(0).DisplayColumns("Model_ID").Visible = False
                    End With
                    Me.lblTotalItemQtyVal.Text = dt.Compute("Sum([Item Qty])", "")
                    Me.lblItemCountVal.Text = dt.Rows.Count
                Else
                    MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadItemNeed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub chkBoxPickLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoxPickLoc.Click
            Me.pnlItemNeed.Visible = True
            Me.LoadItemNeed()
        End Sub

        Private Sub txtWHAndPickBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWHAndPickBox.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtWHAndPickBox.Text.Trim.Length > 0 Then
                    If Me.chkBoxQuarantine.Checked Then
                        Me.ProcessQuarantineBox()
                    Else
                        MessageBox.Show("Quarantine is not checked. Can't process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtWHAndPickBox_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ProcessQuarantineBox()
            Dim strSelectedBoxName As String = ""

            Try
                strSelectedBoxName = Me.txtWHAndPickBox.Text.Trim

                'get data
                Me._dbQuarantineDetails = Me._objTFFKRec.getWhWIP_InPickBoxData(strSelectedBoxName)
                If Not Me._dbQuarantineDetails.Rows.Count > 0 Then
                    MessageBox.Show("Can't find this box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtWHAndPickBox.SelectAll() : Me.txtWHAndPickBox.Focus()
                    Exit Sub
                End If

                If Not IsNothing(Me._dbQuarantine) AndAlso Me._dbQuarantine.Rows.Count > 0 AndAlso _
                   Not (Convert.ToInt32(Me._dbQuarantineDetails.Rows(0).Item("Model_ID")) = Convert.ToInt32(Me._dbQuarantine.Rows(0).Item("Model_ID"))) Then
                    Dim strS As String = "This pallet item '" & Convert.ToString(Me._dbQuarantineDetails.Rows(0).Item("Pallet_Item")) & "'"
                    strS &= " doesn't match the quarantine pallet item '" & Convert.ToString(Me._dbQuarantine.Rows(0).Item("Pallet_Item")) & "'. Can't put into the same quarantine pallet with different items!"
                    MessageBox.Show(strS, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtWHAndPickBox.SelectAll() : Me.txtWHAndPickBox.Focus()
                    Exit Sub
                End If

                'Fill data
                Me.lblSelectedBoxModel.Text = Convert.ToString(Me._dbQuarantineDetails.Rows(0).Item("Pallet_Item"))
                Me.lblSelectedBoxModelID.Text = Convert.ToString(Me._dbQuarantineDetails.Rows(0).Item("Model_ID"))
                Me.lblSelectedBoxQty.Text = Convert.ToString(Me._dbQuarantineDetails.Rows(0).Item("Qty"))
                Me.txtWHAndPickBox.Enabled = False : Me.txtSN.Enabled = True
                Me.txtSN.SelectAll() : Me.txtSN.Focus()


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessQuarantineBox", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                    Me.ProcessQuarantineSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtWHAndPickBox_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ProcessQuarantineSN()
            Dim strQuarantineSN As String = ""
            Dim filteredRows() As DataRow
            Dim filteredRows2() As DataRow
            Dim row As DataRow
            'Dim i, j As Integer
            'Dim strPallet As String = ""

            Try
                strQuarantineSN = Me.txtSN.Text.Trim.Replace("'", "''")

                filteredRows = Me._dbQuarantineDetails.Select("SN='" & strQuarantineSN & "'", "")

                If Not filteredRows.Length > 0 Then
                    MessageBox.Show("Can't find this SN '" & strQuarantineSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Exit Sub
                ElseIf filteredRows.Length > 1 Then
                    MessageBox.Show("Found dup SN '" & strQuarantineSN & "'. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Exit Sub
                ElseIf Convert.ToInt32(filteredRows(0).Item("SoDetailsID")) > 0 Then
                    MessageBox.Show("This item '" & strQuarantineSN & "' has been shipped. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Exit Sub
                ElseIf Not Convert.ToString(filteredRows(0).Item("SN_Item")).Trim.ToUpper = Me.lblSelectedBoxModel.Text.Trim.ToUpper Then
                    MessageBox.Show("The item '" & Convert.ToString(filteredRows("SN_Item")).Trim & "' doesn't match the pallet item '& Me.lblSelectedBoxModel.Text.Trim &'. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Exit Sub
                End If

                If IsNothing(Me._dbQuarantine) Then Me._dbQuarantine = Me._dbQuarantineDetails.Clone

                filteredRows2 = Me._dbQuarantine.Select("SN='" & strQuarantineSN & "'", "")
                If filteredRows2.Length > 0 Then
                    MessageBox.Show("You have already scanned this '" & strQuarantineSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Exit Sub
                End If

                'Get selected SN
                For Each row In filteredRows 'must be 1 row
                    Me._dbQuarantine.ImportRow(row)
                    Exit For
                Next

                'Add row ids
                AddQuarantineRowIDs(Me._dbQuarantine)
                'i = 1 : j = 1
                'For Each row In Me._dbQuarantine.Rows
                '    row.BeginEdit() : row("R2") = i
                '    If i = 1 Then strPallet = Convert.ToString(row("Pallet_Name"))
                '    If Not strPallet = Convert.ToString(row("Pallet_Name")) Then j = 1 : strPallet = Convert.ToString(row("Pallet_Name"))
                '    row("R1") = j : row.AcceptChanges()
                '    i += 1 : j += 1
                'Next

                Me.RefreshQuarantineBoxQty()
                ' Me.tdgBoxSNs.DataSource = Me._dbQuarantine.DefaultView
                Me.BindQuarantineData(Me._dbQuarantine)
                Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessQuarantineSN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindQuarantineData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0

            Try
                If dt.Rows.Count > 0 Then
                    With Me.tdgBoxSNs
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc

                        For i = 5 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).Visible = False
                        Next
                        'Me.tdgData1.Columns.RemoveAt(Me.tdgData1.Columns.IndexOf(Me.tdgData1.Columns("PickRunNo")))
                        '.Splits(0).DisplayColumns("SOHeaderID").Visible = False
                        'If dt.Rows(0)("CustomerNo") <> PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK.Meijer_CUSTOMER_ID Then
                        '    .Splits(0).DisplayColumns("BoxLabel").Visible = False
                        'End If
                        '.Splits(0).DisplayColumns("Part Number").Width = 0

                    End With

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindPackData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub AddQuarantineRowIDs(ByRef dbQuarantine As DataTable)
            Dim row As DataRow
            Dim i, j As Integer
            Dim strPallet As String = ""

            Try
                'Add row ids
                i = 1 : j = 1
                For Each row In Me._dbQuarantine.Rows
                    row.BeginEdit() : row("R2") = i
                    If i = 1 Then strPallet = Convert.ToString(row("Pallet_Name"))
                    If Not strPallet = Convert.ToString(row("Pallet_Name")) Then j = 1 : strPallet = Convert.ToString(row("Pallet_Name"))
                    row("R1") = j : row.AcceptChanges()
                    i += 1 : j += 1
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "AddQuarantineRowIDs", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSetNextBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetNextBox.Click
            Try
                If IsNothing(Me._dbQuarantine) OrElse Not Me._dbQuarantine.Rows.Count > 0 Then
                    Me.txtSN.Text = "" : Me.txtSN.Enabled = False
                    Me.lblSelectedBoxModel.Text = "" : Me.lblSelectedBoxModelID.Text = 0 : Me.lblSelectedBoxQty.Text = 0
                    Me.txtWHAndPickBox.Text = "" : Me.txtWHAndPickBox.Enabled = True
                    Me.txtWHAndPickBox.SelectAll() : Me.txtWHAndPickBox.Focus()
                Else
                    Me.txtSN.Text = "" : Me.txtSN.Enabled = False
                    Me.txtWHAndPickBox.Text = "" : Me.txtWHAndPickBox.Enabled = True
                    Me.txtWHAndPickBox.SelectAll() : Me.txtWHAndPickBox.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSetNextBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOne.Click
            Dim strRemoveSN As String = ""
            Dim row As DataRow
            Dim bRemoved As Boolean = False

            Try
                If Not IsNothing(Me._dbQuarantine) AndAlso Me._dbQuarantine.Rows.Count > 0 Then
                    strRemoveSN = InputBox("Enter a SN to remove:", "Enter SN", "")
                    If strRemoveSN.Trim.Length > 0 Then
                        strRemoveSN = strRemoveSN.Replace("'", "''")
                        For Each row In Me._dbQuarantine.Rows
                            If Convert.ToString(row("SN")).Trim.ToUpper = strRemoveSN.Trim.ToUpper Then
                                Me._dbQuarantine.Rows.Remove(row) : bRemoved = True : Exit For
                            End If
                        Next
                        If bRemoved Then
                            AddQuarantineRowIDs(Me._dbQuarantine) 'redo IDs
                            Me.tdgBoxSNs.DataSource = Me._dbQuarantine.DefaultView
                            If IsNothing(Me._dbQuarantine) OrElse Not Me._dbQuarantine.Rows.Count > 0 Then
                                Me.txtSN.Text = "" : Me.txtSN.Enabled = False
                                Me.lblSelectedBoxModel.Text = "" : Me.lblSelectedBoxModelID.Text = 0 : Me.lblSelectedBoxQty.Text = 0
                                Me.txtWHAndPickBox.Text = "" : Me.txtWHAndPickBox.Enabled = True
                                Me.txtWHAndPickBox.SelectAll() : Me.txtWHAndPickBox.Focus()
                            End If
                        Else
                            MessageBox.Show("Can't find this'" & strRemoveSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If

                Me.RefreshQuarantineBoxQty()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
            Try
                If Not IsNothing(Me._dbQuarantine) AndAlso Me._dbQuarantine.Rows.Count > 0 Then
                    Dim result As Integer = MessageBox.Show("Do you want to remove all SNs?", "Confirm Action", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        Me._dbQuarantine = Nothing
                        Me.tdgBoxSNs.DataSource = Nothing
                        If IsNothing(Me._dbQuarantine) OrElse Not Me._dbQuarantine.Rows.Count > 0 Then
                            Me.txtSN.Text = "" : Me.txtSN.Enabled = False
                            Me.lblSelectedBoxModel.Text = "" : Me.lblSelectedBoxModelID.Text = 0 : Me.lblSelectedBoxQty.Text = 0
                            Me.txtWHAndPickBox.Text = "" : Me.txtWHAndPickBox.Enabled = True
                            Me.txtWHAndPickBox.SelectAll() : Me.txtWHAndPickBox.Focus()
                        End If
                    End If
                End If

                Me.RefreshQuarantineBoxQty()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Private Sub btnCompleteQuarantine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleteQuarantine.Click
            Dim ArrLstPallet_WbIDs As New ArrayList()
            Dim filteredRows() As DataRow
            Dim row As DataRow
            Dim i As Integer = 0
            Dim iWB_ID As Integer = 0
            Dim strWI_IDs As String = ""
            Dim strReceiptDate As String = ""

            Dim strPrefixBoxName As String = "TR"
            Dim strBoxStage As String = "FK Received"
            Dim strWorkStation As String = "In-Quarantine"
            Dim iFuncrep As Integer = 10
            Dim dtBox As DataTable
            Dim iModel_ID As Integer = 0
            Dim iOrder_ID As Integer = 0
            Dim iQty As Integer = 0, iQty_Source As Integer = 0, iQty_Quarantine As Integer = 0
            Dim strPallet_Source As String = ""
            Dim strDate As String = Format(Now, "MM/dd/yyyy")
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iSoDetailsID As Integer = 999999999 'set this for quarantine SNs in TFFK process
            Dim strWhLocation As String = ""

            Try
                If IsNothing(Me._dbQuarantine) OrElse Not Me._dbQuarantine.Rows.Count > 0 Then Exit Sub

                'Get WH location
                strWhLocation = InputBox("Enter a warehouse location:", "Enter Location", "")
                If strWhLocation.Trim.Length = 0 Then
                    MessageBox.Show("Please enter a warehouse location for the quarantine pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnCompleteQuarantine.Focus() : Exit Sub
                End If

                Cursor.Current = Cursors.WaitCursor

                'Get unique pallet IDs get all WI_IDs 
                For Each row In Me._dbQuarantine.Rows
                    If Not ArrLstPallet_WbIDs.Contains(row("WB_ID")) Then ArrLstPallet_WbIDs.Add(row("WB_ID"))

                    If strWI_IDs.Trim.Length = 0 Then
                        strWI_IDs = Convert.ToString(row("Wi_ID"))
                    Else
                        strWI_IDs &= "," & Convert.ToString(row("Wi_ID"))
                    End If
                Next

                'Create quarantine pallet
                iModel_ID = Convert.ToInt32(Me._dbQuarantine.Rows(0).Item("Model_ID"))
                iOrder_ID = 0 'could come from multiple source pallets Convert.ToInt32(Me._dbQuarantine.Rows(0).Item("Order_ID"))
                iQty = Convert.ToInt32(Me._dbQuarantine.Rows.Count)
                dtBox = Me._objTFFKRec.CreateWHRecvBoxID(iModel_ID, iOrder_ID, iFuncrep, iQty, strPrefixBoxName, strBoxStage, strWorkStation, strWhLocation)
                If Not dtBox.Rows.Count = 1 Then
                    MessageBox.Show("No quarantine pallet created. Try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                'Update quarantine SNs
                i = Me._objTFFKPickPackShip.UpdateQuarantineSNs(iSoDetailsID, strWI_IDs)

                'Print Quarantine box label
                Try
                    Me._objTFFKRec.PrintQuarantineBoxLabel(Convert.ToString(dtBox.Rows(0).Item("BoxID")), Convert.ToString(Me._dbQuarantine.Rows(0).Item("Pallet_Item")), _
                                                           iQty, strDate, PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iWHRecvBoxLabelCopiesNumber)
                Catch ex As Exception
                End Try

                'Update qty for each source pallet, print new label for source pallet(s), and  keep box changes log
                For i = 0 To ArrLstPallet_WbIDs.Count - 1
                    iWB_ID = Convert.ToInt32(ArrLstPallet_WbIDs(i))
                    filteredRows = Me._dbQuarantine.Select("WB_ID=" & iWB_ID, "")
                    iQty_Source = Convert.ToInt32(filteredRows(0).Item("Qty"))
                    strPallet_Source = Convert.ToString(filteredRows(0).Item("Pallet_Name"))
                    iQty_Quarantine = filteredRows.Length
                    Try
                        strReceiptDate = Format(CDate(Convert.ToString(filteredRows(0).Item("Receipt_Date"))), "MM/dd/yyyy")
                    Catch ex As Exception
                    End Try

                    'Update source box qty
                    Me._objTFFKPickPackShip.UpdateSourceBoxAfterQuarantine(iWB_ID, iQty_Quarantine)
                    'Print source box 
                    Me._objTFFKRec.PrintWarehouseFKRecBoxID(strPallet_Source, Convert.ToString(filteredRows(0).Item("Pallet_Item")), iQty_Source - iQty_Quarantine, _
                                                            Convert.ToString(filteredRows(0).Item("OrderNo")), "", _
                                                            strReceiptDate, _
                                                            Convert.ToString(filteredRows(0).Item("WI_ID")), _
                                                            PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK._iWHRecvBoxLabelCopiesNumber)
                    'Keep box changes log
                    Me._objTFFKPickPackShip.InsertSplitBoxLogData(iWB_ID, strPallet_Source, iQty_Source, Convert.ToString(dtBox.Rows(0).Item("WB_ID")), _
                                                                  Convert.ToString(dtBox.Rows(0).Item("BoxID")), iQty_Quarantine, Me._UserID, strDateTime, "")
                Next

                'Close Quarantine pallet
                Me._objTFFKPickPackShip.CloseWarehouseBox(Convert.ToInt32(dtBox.Rows(0).Item("WB_ID")))

                'Reset/clear controls
                Me.ClearQuarantineControls()
                Me.txtWHAndPickBox.SelectAll() : Me.txtWHAndPickBox.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace