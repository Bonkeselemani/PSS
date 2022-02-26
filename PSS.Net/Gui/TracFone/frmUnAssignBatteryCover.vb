Option Explicit On 
Imports PSS.Data.Buisness
Namespace Gui.TracFone
    Public Class frmUnAssignBatteryCover
        Inherits System.Windows.Forms.Form
#Region "DECLARATIONS"
        Private _strScreenName As String = ""
        Private _objTFMisc As Data.Buisness.TracFone.clsMisc
        Private _iPalletID As Integer = 0
        Private _iCust_ID As Integer = 2258
        Private strNextStation As String = "PRODUCTION COMPLETED"
        Private _user_id As Integer
#End Region
#Region "Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _objTFMisc = New Data.Buisness.TracFone.clsMisc()
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
        Friend WithEvents tcMain As System.Windows.Forms.TabControl
        Friend WithEvents tpAssignBatteries As System.Windows.Forms.TabPage
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents lblBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblBilledRV As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblBilledNew As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblBilledUse As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtShipBoxName As System.Windows.Forms.TextBox
        Friend WithEvents btnUnassignBatteryMoveBox As System.Windows.Forms.Button
        Friend WithEvents lblBoxList As System.Windows.Forms.Label
        Friend WithEvents tdgBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grpBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents lblSelectedPalletID As System.Windows.Forms.Label
        Friend WithEvents lblSelectedPalletName As System.Windows.Forms.Label
        Friend WithEvents lblUsePart As System.Windows.Forms.Label
        Friend WithEvents lblNewPart As System.Windows.Forms.Label
        Friend WithEvents lblRVPart As System.Windows.Forms.Label
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUnAssignBatteryCover))
            Me.tcMain = New System.Windows.Forms.TabControl()
            Me.tpAssignBatteries = New System.Windows.Forms.TabPage()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.grpBox1 = New System.Windows.Forms.GroupBox()
            Me.btnUnassignBatteryMoveBox = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.lblBoxQty = New System.Windows.Forms.Label()
            Me.lblUsePart = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblNewPart = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblRVPart = New System.Windows.Forms.Label()
            Me.lblBilledRV = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblBilledNew = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblBilledUse = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblSelectedPalletName = New System.Windows.Forms.Label()
            Me.lblSelectedPalletID = New System.Windows.Forms.Label()
            Me.txtShipBoxName = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblBoxList = New System.Windows.Forms.Label()
            Me.tdgBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.tcMain.SuspendLayout()
            Me.tpAssignBatteries.SuspendLayout()
            Me.grpBox1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.tdgBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tcMain
            '
            Me.tcMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpAssignBatteries})
            Me.tcMain.Location = New System.Drawing.Point(8, 8)
            Me.tcMain.Name = "tcMain"
            Me.tcMain.SelectedIndex = 0
            Me.tcMain.Size = New System.Drawing.Size(868, 528)
            Me.tcMain.TabIndex = 1
            '
            'tpAssignBatteries
            '
            Me.tpAssignBatteries.BackColor = System.Drawing.Color.SteelBlue
            Me.tpAssignBatteries.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.btnCopySelectedRows, Me.btnCopyAll, Me.grpBox1, Me.lblBoxList, Me.tdgBoxes})
            Me.tpAssignBatteries.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tpAssignBatteries.ForeColor = System.Drawing.Color.White
            Me.tpAssignBatteries.Location = New System.Drawing.Point(4, 22)
            Me.tpAssignBatteries.Name = "tpAssignBatteries"
            Me.tpAssignBatteries.Size = New System.Drawing.Size(860, 502)
            Me.tpAssignBatteries.TabIndex = 0
            Me.tpAssignBatteries.Text = "Unassign/Move"
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(400, 0)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(160, 23)
            Me.btnCopySelectedRows.TabIndex = 30
            Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopyAll.Location = New System.Drawing.Point(288, 0)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(104, 23)
            Me.btnCopyAll.TabIndex = 29
            Me.btnCopyAll.Text = "Copy All Rows"
            '
            'grpBox1
            '
            Me.grpBox1.BackColor = System.Drawing.Color.SteelBlue
            Me.grpBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUnassignBatteryMoveBox, Me.Panel1, Me.txtShipBoxName, Me.Label1})
            Me.grpBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpBox1.ForeColor = System.Drawing.Color.Blue
            Me.grpBox1.Location = New System.Drawing.Point(8, 288)
            Me.grpBox1.Name = "grpBox1"
            Me.grpBox1.Size = New System.Drawing.Size(768, 200)
            Me.grpBox1.TabIndex = 28
            Me.grpBox1.TabStop = False
            Me.grpBox1.Text = "Box to Process"
            '
            'btnUnassignBatteryMoveBox
            '
            Me.btnUnassignBatteryMoveBox.BackColor = System.Drawing.Color.Green
            Me.btnUnassignBatteryMoveBox.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUnassignBatteryMoveBox.ForeColor = System.Drawing.Color.White
            Me.btnUnassignBatteryMoveBox.Location = New System.Drawing.Point(336, 72)
            Me.btnUnassignBatteryMoveBox.Name = "btnUnassignBatteryMoveBox"
            Me.btnUnassignBatteryMoveBox.Size = New System.Drawing.Size(432, 80)
            Me.btnUnassignBatteryMoveBox.TabIndex = 2
            Me.btnUnassignBatteryMoveBox.Text = "UNASSIGN BATTERY COVER and MOVE FROM WH-RB TO PRODUCTION COMPLETED"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label13, Me.lblBoxQty, Me.lblUsePart, Me.Label11, Me.lblNewPart, Me.Label10, Me.lblRVPart, Me.lblBilledRV, Me.Label4, Me.lblBilledNew, Me.Label9, Me.lblBilledUse, Me.Label12, Me.Label2, Me.lblSelectedPalletName, Me.lblSelectedPalletID})
            Me.Panel1.Location = New System.Drawing.Point(8, 56)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(317, 136)
            Me.Panel1.TabIndex = 25
            '
            'Label13
            '
            Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.Black
            Me.Label13.Location = New System.Drawing.Point(0, 104)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(56, 16)
            Me.Label13.TabIndex = 25
            Me.Label13.Text = "Box Qty:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBoxQty
            '
            Me.lblBoxQty.BackColor = System.Drawing.SystemColors.Control
            Me.lblBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxQty.ForeColor = System.Drawing.Color.Black
            Me.lblBoxQty.Location = New System.Drawing.Point(72, 104)
            Me.lblBoxQty.Name = "lblBoxQty"
            Me.lblBoxQty.Size = New System.Drawing.Size(40, 18)
            Me.lblBoxQty.TabIndex = 26
            Me.lblBoxQty.Text = "0"
            Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblUsePart
            '
            Me.lblUsePart.BackColor = System.Drawing.SystemColors.Control
            Me.lblUsePart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblUsePart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUsePart.ForeColor = System.Drawing.Color.Black
            Me.lblUsePart.Location = New System.Drawing.Point(72, 56)
            Me.lblUsePart.Name = "lblUsePart"
            Me.lblUsePart.Size = New System.Drawing.Size(128, 20)
            Me.lblUsePart.TabIndex = 20
            Me.lblUsePart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(-5, 56)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(71, 16)
            Me.Label11.TabIndex = 19
            Me.Label11.Text = "Use Part #:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNewPart
            '
            Me.lblNewPart.BackColor = System.Drawing.SystemColors.Control
            Me.lblNewPart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblNewPart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNewPart.ForeColor = System.Drawing.Color.Black
            Me.lblNewPart.Location = New System.Drawing.Point(72, 32)
            Me.lblNewPart.Name = "lblNewPart"
            Me.lblNewPart.Size = New System.Drawing.Size(128, 20)
            Me.lblNewPart.TabIndex = 16
            Me.lblNewPart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(-12, 32)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(80, 16)
            Me.Label10.TabIndex = 15
            Me.Label10.Text = "New Part #:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRVPart
            '
            Me.lblRVPart.BackColor = System.Drawing.SystemColors.Control
            Me.lblRVPart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblRVPart.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRVPart.ForeColor = System.Drawing.Color.Black
            Me.lblRVPart.Location = New System.Drawing.Point(72, 80)
            Me.lblRVPart.Name = "lblRVPart"
            Me.lblRVPart.Size = New System.Drawing.Size(128, 18)
            Me.lblRVPart.TabIndex = 4
            Me.lblRVPart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBilledRV
            '
            Me.lblBilledRV.BackColor = System.Drawing.SystemColors.Control
            Me.lblBilledRV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBilledRV.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBilledRV.ForeColor = System.Drawing.Color.Black
            Me.lblBilledRV.Location = New System.Drawing.Point(264, 80)
            Me.lblBilledRV.Name = "lblBilledRV"
            Me.lblBilledRV.Size = New System.Drawing.Size(40, 20)
            Me.lblBilledRV.TabIndex = 6
            Me.lblBilledRV.Text = "0"
            Me.lblBilledRV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(200, 80)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(64, 18)
            Me.Label4.TabIndex = 5
            Me.Label4.Text = "R.V. Qty:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBilledNew
            '
            Me.lblBilledNew.BackColor = System.Drawing.SystemColors.Control
            Me.lblBilledNew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBilledNew.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBilledNew.ForeColor = System.Drawing.Color.Black
            Me.lblBilledNew.Location = New System.Drawing.Point(264, 32)
            Me.lblBilledNew.Name = "lblBilledNew"
            Me.lblBilledNew.Size = New System.Drawing.Size(40, 20)
            Me.lblBilledNew.TabIndex = 21
            Me.lblBilledNew.Text = "0"
            Me.lblBilledNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Black
            Me.Label9.Location = New System.Drawing.Point(200, 32)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(64, 16)
            Me.Label9.TabIndex = 23
            Me.Label9.Text = "New Qty:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBilledUse
            '
            Me.lblBilledUse.BackColor = System.Drawing.SystemColors.Control
            Me.lblBilledUse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBilledUse.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBilledUse.ForeColor = System.Drawing.Color.Black
            Me.lblBilledUse.Location = New System.Drawing.Point(264, 56)
            Me.lblBilledUse.Name = "lblBilledUse"
            Me.lblBilledUse.Size = New System.Drawing.Size(40, 20)
            Me.lblBilledUse.TabIndex = 22
            Me.lblBilledUse.Text = "0"
            Me.lblBilledUse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.Location = New System.Drawing.Point(200, 56)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(64, 16)
            Me.Label12.TabIndex = 24
            Me.Label12.Text = "Use Qty:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(-1, 80)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(81, 16)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "R.V. Part #:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSelectedPalletName
            '
            Me.lblSelectedPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelectedPalletName.ForeColor = System.Drawing.Color.Navy
            Me.lblSelectedPalletName.Name = "lblSelectedPalletName"
            Me.lblSelectedPalletName.Size = New System.Drawing.Size(248, 24)
            Me.lblSelectedPalletName.TabIndex = 27
            '
            'lblSelectedPalletID
            '
            Me.lblSelectedPalletID.Font = New System.Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelectedPalletID.ForeColor = System.Drawing.Color.Lavender
            Me.lblSelectedPalletID.Location = New System.Drawing.Point(264, -2)
            Me.lblSelectedPalletID.Name = "lblSelectedPalletID"
            Me.lblSelectedPalletID.Size = New System.Drawing.Size(48, 16)
            Me.lblSelectedPalletID.TabIndex = 26
            Me.lblSelectedPalletID.Text = "0"
            Me.lblSelectedPalletID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShipBoxName
            '
            Me.txtShipBoxName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipBoxName.Location = New System.Drawing.Point(80, 24)
            Me.txtShipBoxName.Name = "txtShipBoxName"
            Me.txtShipBoxName.Size = New System.Drawing.Size(248, 21)
            Me.txtShipBoxName.TabIndex = 0
            Me.txtShipBoxName.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label1.Location = New System.Drawing.Point(8, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Box Name:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxList
            '
            Me.lblBoxList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxList.ForeColor = System.Drawing.Color.White
            Me.lblBoxList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblBoxList.Location = New System.Drawing.Point(8, 8)
            Me.lblBoxList.Name = "lblBoxList"
            Me.lblBoxList.Size = New System.Drawing.Size(192, 16)
            Me.lblBoxList.TabIndex = 27
            Me.lblBoxList.Text = "Box List"
            Me.lblBoxList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tdgBoxes
            '
            Me.tdgBoxes.AllowColMove = False
            Me.tdgBoxes.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.tdgBoxes.AllowUpdate = False
            Me.tdgBoxes.AllowUpdateOnBlur = False
            Me.tdgBoxes.AlternatingRows = True
            Me.tdgBoxes.CaptionHeight = 19
            Me.tdgBoxes.CollapseColor = System.Drawing.Color.White
            Me.tdgBoxes.ExpandColor = System.Drawing.Color.White
            Me.tdgBoxes.FilterBar = True
            Me.tdgBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgBoxes.ForeColor = System.Drawing.Color.White
            Me.tdgBoxes.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgBoxes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgBoxes.Location = New System.Drawing.Point(8, 24)
            Me.tdgBoxes.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgBoxes.Name = "tdgBoxes"
            Me.tdgBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgBoxes.PreviewInfo.ZoomFactor = 75
            Me.tdgBoxes.RowHeight = 20
            Me.tdgBoxes.Size = New System.Drawing.Size(768, 248)
            Me.tdgBoxes.TabIndex = 26
            Me.tdgBoxes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Tahoma, 8.25pt;ForeC" & _
            "olor:Black;BackColor:AliceBlue;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
            "ight;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption;}FilterBar{Font" & _
            ":Microsoft Sans Serif, 8.25pt;ForeColor:Black;BackColor:White;}Footer{Font:Tahom" & _
            "a, 8.25pt, style=Bold, Italic;AlignHorz:Far;}Caption{AlignHorz:Center;ForeColor:" & _
            "MidnightBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;Align" & _
            "Vert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style14{}OddRow{Font:Tahoma, 8.25pt;ForeColor:Bl" & _
            "ack;BackColor:LightBlue;}RecordSelector{ForeColor:White;AlignImage:Center;}Style" & _
            "15{}Heading{Wrap:True;Font:Tahoma, 8.25pt, style=Bold;AlignHorz:Center;BackColor" & _
            ":LightSteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:DarkBlue;AlignVert:Center;}S" & _
            "tyle8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}Styl" & _
            "e9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" " & _
            "Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" Colu" & _
            "mnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""Dott" & _
            "edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
            "1"" HorizontalScrollGroup=""1""><Height>244</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 764, 244</ClientRect><BorderSide>0</BorderSide><Bor" & _
            "derStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyl" & _
            "es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
            "arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
            "nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
            "t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
            "t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
            "ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
            "nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
            "/horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cli" & _
            "entArea>0, 0, 764, 244</ClientArea><PrintPageHeaderStyle parent="""" me=""Style16"" " & _
            "/><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnRefresh
            '
            Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.Color.LawnGreen
            Me.btnRefresh.Location = New System.Drawing.Point(184, 0)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(64, 24)
            Me.btnRefresh.TabIndex = 31
            Me.btnRefresh.Text = "Refresh"
            '
            'frmUnAssignBatteryCover
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(792, 566)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcMain})
            Me.Name = "frmUnAssignBatteryCover"
            Me.Text = "frmUnAssignBatteryCover"
            Me.tcMain.ResumeLayout(False)
            Me.tpAssignBatteries.ResumeLayout(False)
            Me.grpBox1.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            CType(Me.tdgBoxes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
#Region "FORM EVENTS"
        Private Sub frmUnAssignBatteryCover_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)
                Me.Show()
                Application.DoEvents()
                _user_id = Core.ApplicationUser.IDuser
                ' Me.tcMain.Visible = False
                Me.tcMain.Width = Screen.PrimaryScreen.Bounds.Width
                Me.tdgBoxes.Width = Me.tcMain.Width - 50
                Me.btnUnassignBatteryMoveBox.Text = "UNASSIGN BATTERY COVER" & Environment.NewLine & " and " & Environment.NewLine & "MOVE FROM WH-RB TO PRODUCTION COMPLETED"
                Me.grpBox1.Width = Me.tdgBoxes.Width
                PopulateWHRBBoxes()
            Catch ex As Exception
                MessageBox.Show(ex.Message, " frmUnAssignBatteryCover_Loadd", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

#End Region
#Region "CONTROL EVENTS"
        Private Sub btnUnassignBatteryMoveBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnassignBatteryMoveBox.Click
            If Not ValidateEntries() Then
                Exit Sub
            End If
            ProcessBox()
        End Sub
        Private Sub txtShipBoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipBoxName.KeyUp
            Dim dt As DataTable
            Dim row As DataRow
            Dim strPallet As String = ""
            Dim bFound As Boolean = False
            Try
                If e.KeyCode = Keys.Enter Then
                    If Not Me.txtShipBoxName.Text.Trim.Length > 0 Then
                        Exit Sub
                    End If
                    strPallet = Me.txtShipBoxName.Text.Trim
                    'Refresh WH-RB data
                    PopulateWHRBBoxes()
                    If Me.tdgBoxes.RowCount > 0 Then
                        dt = Me.tdgBoxes.DataSource.table
                        ClearTextBoxes()
                        For Each row In dt.Rows
                            If Trim(row("Pallet Name")).ToUpper = strPallet.ToUpper Then
                                Me.lblSelectedPalletName.Text = strPallet : Me.lblSelectedPalletID.Text = row("Pallett_ID")
                                Me.lblNewPart.Text = row("Bat. New Part") : Me.lblBilledNew.Text = row("Bat. New Qty")
                                Me.lblUsePart.Text = row("Bat. Use Part") : Me.lblBilledUse.Text = row("Bat. Use Qty")
                                Me.lblRVPart.Text = row("Bat. RV Part") : Me.lblBilledRV.Text = row("Bat. RV Qty")
                                Me.lblBoxQty.Text = row("Box Qty") : Me.txtShipBoxName.Text = ""
                                bFound = True : Exit For
                            End If
                        Next
                        If Not bFound Then
                            MessageBox.Show("Pallet '" & strPallet & "' does not exit!", "txtShipBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ClearTextBoxes() : PopulateWHRBBoxes()
                            Me.txtShipBoxName.SelectAll() : Me.txtShipBoxName.Focus()
                        End If
                    Else
                        MessageBox.Show("Pallet '" & strPallet & "' does not exit!", "txtShipBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ClearTextBoxes()
                        Me.txtShipBoxName.SelectAll() : Me.txtShipBoxName.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "  txtShipBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub btnCopyAll_btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click, btnCopySelectedRows.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If sender.name = "btnCopyAll" Then
                    Misc.CopyAllData(Me.tdgBoxes)
                ElseIf sender.name = "btnCopySelectedRows" Then
                    Misc.CopySelectedRowsData(Me.tdgBoxes)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub
        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            PopulateWHRBBoxes()
        End Sub
        Private Sub tdgBoxes_BindingContextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdgBoxes.BindingContextChanged
            Me.ActiveControl = Me.txtShipBoxName
            txtShipBoxName.SelectAll()
            txtShipBoxName.Focus()
        End Sub
#End Region
#Region "METHODS"
        Private Sub PopulateWHRBBoxes()
            Dim dt As DataTable
            Dim i As Integer
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.tdgBoxes.DataSource = Nothing
                dt = Me._objTFMisc.Get_WHRB_Boxes(Me._iCust_ID, 0)
                If dt.Rows.Count > 0 Then
                    With Me.tdgBoxes
                        .DataSource = dt.DefaultView
                        For i = 0 To .Columns.Count - 1
                            Me.tdgBoxes.Splits(0).DisplayColumns(i).AutoSize()
                        Next
                        .Splits(0).DisplayColumns("Pallett_ID").Visible = False

                        Me.lblBoxList.Text = "WH-RB Box List: (" & .RowCount & ")"
                    End With
                Else
                    Me.lblBoxList.Text = "WH-RB Box List: (0)"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, " PopulateWHRBBoxes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Sub ProcessBox()
            Dim _pallet_id = CInt(Me.lblSelectedPalletID.Text)
            Dim dt_P As New DataTable()
            Dim dt_DB As New DataTable()
            Dim _billedIDString As String = ""
            dt_P = GetPalletData(_pallet_id)
            dt_DB = GetDeviceBillData(_pallet_id)
            Dim _has_bc As Boolean
            _has_bc = dt_P.Rows(0)("HAS_BC") = 1
            Dim _parts_removed As Boolean = False
            If _has_bc Then
                _billedIDString = GetBilledIDString(dt_DB)
                _parts_removed = RemovePartData(_pallet_id, _billedIDString)
            End If
            Dim _moved As Boolean
            If (Not _has_bc) Or _parts_removed Then
                _moved = MoveBox_To_Prod_Comp(_pallet_id)
            End If
            ' NOTIFIY USER OS STATUS.
            If (_has_bc = False Or _parts_removed) And _moved Then
                MessageBox.Show("The battery covers have been unassigned.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearTextBoxes()
                Me.txtShipBoxName.Text = ""
                Me.txtShipBoxName.Focus()
                PopulateWHRBBoxes()
            End If
        End Sub
        Private Function ValidateEntries() As Boolean
            ' VALIDATE A VALID PALLET NAME HAS BEEN ENTERED.
            Dim _retVal As Boolean = False
            If Me.lblSelectedPalletName.Text <> "" And Me.lblSelectedPalletID.Text <> "" Then
                _retVal = True
            End If
            Return _retVal
        End Function
        Private Function GetPalletData(ByVal pallet_id As Integer) As DataTable
            Dim dt As New DataTable()
            dt = Me._objTFMisc.Get_WHRB_Boxes(Me._iCust_ID, pallet_id)
            Return dt
        End Function
        Private Function GetDeviceBillData(ByVal pallet_id As Integer) As DataTable
            Dim dt As New DataTable()
            dt = Me._objTFMisc.GetAssignedBatteryDataDetails(pallet_id)
            Return dt
        End Function
        Private Function RemovePartData(ByVal _pallet_id As Integer, ByVal strDBilled_IDs As String) As Boolean
            Dim _removedBCs As Integer
            _removedBCs = Me._objTFMisc.UnassignBilledBatteryParts(strDBilled_IDs)
            Return (_removedBCs > 0)
        End Function
        Private Function MoveBox_To_Prod_Comp(ByVal pallet_id As Integer) As Boolean
            Dim _cnt As Integer
            _cnt = Me._objTFMisc.PushShipBoxToNextStation(pallet_id, strNextStation, _user_id, _strScreenName, Me.Name)
            Return (_cnt > 0)
        End Function
        Private Function GetBilledIDString(ByVal dt As DataTable) As String
            Dim row As DataRow
            Dim strDBilled_IDs As String = ""
            For Each row In dt.Rows
                If strDBilled_IDs.Trim.Length = 0 Then
                    strDBilled_IDs = row("DBill_ID")
                Else
                    strDBilled_IDs &= "," & row("DBill_ID")
                End If
            Next
            Return strDBilled_IDs
        End Function
        Private Sub ClearTextBoxes()
            Try
                Me.lblSelectedPalletName.Text = "" : Me.lblSelectedPalletID.Text = 0
                Me.lblNewPart.Text = "" : Me.lblBilledNew.Text = 0
                Me.lblUsePart.Text = "" : Me.lblBilledUse.Text = 0
                Me.lblRVPart.Text = "" : Me.lblBilledRV.Text = 0
                Me.lblBoxQty.Text = 0
            Catch ex As Exception
                MessageBox.Show(ex.Message, "  ClearTextBoxes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
#End Region
    End Class
End Namespace
