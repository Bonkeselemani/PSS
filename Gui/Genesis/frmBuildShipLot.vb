Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Genesis
    Public Class frmBuildShipLot
        Inherits System.Windows.Forms.Form

        Private _objShip As PSS.Data.Buisness.Genesis.Shipping
        Private _booPopDataToCombo As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objShip = New PSS.Data.Buisness.Genesis.Shipping()
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
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCloseLot As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
        Friend WithEvents btnDeleteBox As System.Windows.Forms.Button
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnReopenBox As System.Windows.Forms.Button
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents Button5 As System.Windows.Forms.Button
        Friend WithEvents btnCreateBoxID As System.Windows.Forms.Button
        Friend WithEvents lblModelDesc As System.Windows.Forms.Label
        Friend WithEvents cboOpenSO As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboSOLines As C1.Win.C1List.C1Combo
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblPlannedShipmentDate As System.Windows.Forms.Label
        Friend WithEvents txtLed1 As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtLed2 As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtLed3 As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtLed4 As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtPsu As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtBaseplate As System.Windows.Forms.TextBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents panelDeviceList As System.Windows.Forms.Panel
        Friend WithEvents PanelOrder As System.Windows.Forms.Panel
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents lblWOLinePackedQty As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents lblWOLineQty As System.Windows.Forms.Label
        Friend WithEvents lblListCount As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBuildShipLot))
            Me.panelDeviceList = New System.Windows.Forms.Panel()
            Me.lblListCount = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtBaseplate = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.txtPsu = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtLed4 = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtLed3 = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtLed2 = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtLed1 = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCloseLot = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.PanelPalletList = New System.Windows.Forms.Panel()
            Me.btnDeleteBox = New System.Windows.Forms.Button()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReopenBox = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.PanelOrder = New System.Windows.Forms.Panel()
            Me.lblWOLineQty = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.lblWOLinePackedQty = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblPlannedShipmentDate = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.btnCreateBoxID = New System.Windows.Forms.Button()
            Me.lblModelDesc = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboOpenSO = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboSOLines = New C1.Win.C1List.C1Combo()
            Me.panelDeviceList.SuspendLayout()
            Me.PanelPalletList.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelOrder.SuspendLayout()
            CType(Me.cboOpenSO, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboSOLines, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'panelDeviceList
            '
            Me.panelDeviceList.BackColor = System.Drawing.Color.SteelBlue
            Me.panelDeviceList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelDeviceList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblListCount, Me.Label15, Me.txtBaseplate, Me.Label13, Me.txtPsu, Me.Label12, Me.txtLed4, Me.Label11, Me.txtLed3, Me.Label9, Me.txtLed2, Me.Label8, Me.txtLed1, Me.Label4, Me.txtDevSN, Me.Label10, Me.btnCloseLot, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblBoxName})
            Me.panelDeviceList.Location = New System.Drawing.Point(448, 0)
            Me.panelDeviceList.Name = "panelDeviceList"
            Me.panelDeviceList.Size = New System.Drawing.Size(400, 624)
            Me.panelDeviceList.TabIndex = 124
            Me.panelDeviceList.Visible = False
            '
            'lblListCount
            '
            Me.lblListCount.BackColor = System.Drawing.Color.Black
            Me.lblListCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblListCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblListCount.ForeColor = System.Drawing.Color.Lime
            Me.lblListCount.Location = New System.Drawing.Point(200, 216)
            Me.lblListCount.Name = "lblListCount"
            Me.lblListCount.Size = New System.Drawing.Size(96, 43)
            Me.lblListCount.TabIndex = 113
            Me.lblListCount.Text = "0"
            Me.lblListCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.White
            Me.Label15.Location = New System.Drawing.Point(200, 200)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(96, 16)
            Me.Label15.TabIndex = 112
            Me.Label15.Text = "List Count"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtBaseplate
            '
            Me.txtBaseplate.Location = New System.Drawing.Point(208, 144)
            Me.txtBaseplate.Name = "txtBaseplate"
            Me.txtBaseplate.Size = New System.Drawing.Size(176, 20)
            Me.txtBaseplate.TabIndex = 5
            Me.txtBaseplate.Text = ""
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.Transparent
            Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.White
            Me.Label13.Location = New System.Drawing.Point(208, 128)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(176, 16)
            Me.Label13.TabIndex = 111
            Me.Label13.Text = "Base Plate:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPsu
            '
            Me.txtPsu.Location = New System.Drawing.Point(208, 104)
            Me.txtPsu.Name = "txtPsu"
            Me.txtPsu.Size = New System.Drawing.Size(176, 20)
            Me.txtPsu.TabIndex = 4
            Me.txtPsu.Text = ""
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(208, 88)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(176, 16)
            Me.Label12.TabIndex = 109
            Me.Label12.Text = "PSU:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtLed4
            '
            Me.txtLed4.Location = New System.Drawing.Point(208, 64)
            Me.txtLed4.Name = "txtLed4"
            Me.txtLed4.Size = New System.Drawing.Size(176, 20)
            Me.txtLed4.TabIndex = 3
            Me.txtLed4.Text = ""
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(208, 48)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(176, 16)
            Me.Label11.TabIndex = 107
            Me.Label11.Text = "LED 4:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtLed3
            '
            Me.txtLed3.Location = New System.Drawing.Point(8, 144)
            Me.txtLed3.Name = "txtLed3"
            Me.txtLed3.Size = New System.Drawing.Size(176, 20)
            Me.txtLed3.TabIndex = 2
            Me.txtLed3.Text = ""
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(8, 128)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(176, 16)
            Me.Label9.TabIndex = 105
            Me.Label9.Text = "LED 3:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtLed2
            '
            Me.txtLed2.Location = New System.Drawing.Point(8, 104)
            Me.txtLed2.Name = "txtLed2"
            Me.txtLed2.Size = New System.Drawing.Size(176, 20)
            Me.txtLed2.TabIndex = 1
            Me.txtLed2.Text = ""
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(8, 88)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(176, 16)
            Me.Label8.TabIndex = 103
            Me.Label8.Text = "LED 2:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtLed1
            '
            Me.txtLed1.Location = New System.Drawing.Point(8, 64)
            Me.txtLed1.Name = "txtLed1"
            Me.txtLed1.Size = New System.Drawing.Size(176, 20)
            Me.txtLed1.TabIndex = 0
            Me.txtLed1.Text = ""
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 48)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(176, 16)
            Me.Label4.TabIndex = 101
            Me.Label4.Text = "LED 1:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(8, 200)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(176, 20)
            Me.txtDevSN.TabIndex = 6
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 184)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(176, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Serial Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCloseLot
            '
            Me.btnCloseLot.BackColor = System.Drawing.Color.Green
            Me.btnCloseLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseLot.ForeColor = System.Drawing.Color.White
            Me.btnCloseLot.Location = New System.Drawing.Point(200, 496)
            Me.btnCloseLot.Name = "btnCloseLot"
            Me.btnCloseLot.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseLot.Size = New System.Drawing.Size(128, 30)
            Me.btnCloseLot.TabIndex = 7
            Me.btnCloseLot.Text = "CLOSE LOT"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(200, 368)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(128, 30)
            Me.btnRemoveAllSNs.TabIndex = 9
            Me.btnRemoveAllSNs.Text = "REMOVE ALL"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(200, 312)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(128, 30)
            Me.btnRemoveSN.TabIndex = 8
            Me.btnRemoveSN.Text = "REMOVE ONE"
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(8, 224)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(176, 355)
            Me.lstDevices.TabIndex = 10
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Black
            Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxName.Location = New System.Drawing.Point(8, 7)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(376, 33)
            Me.lblBoxName.TabIndex = 98
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PanelPalletList
            '
            Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteBox, Me.dbgPallets, Me.btnReopenBox, Me.btnReprintBoxLabel})
            Me.PanelPalletList.Location = New System.Drawing.Point(1, 288)
            Me.PanelPalletList.Name = "PanelPalletList"
            Me.PanelPalletList.Size = New System.Drawing.Size(447, 336)
            Me.PanelPalletList.TabIndex = 123
            '
            'btnDeleteBox
            '
            Me.btnDeleteBox.BackColor = System.Drawing.Color.Red
            Me.btnDeleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeleteBox.ForeColor = System.Drawing.Color.White
            Me.btnDeleteBox.Location = New System.Drawing.Point(264, 240)
            Me.btnDeleteBox.Name = "btnDeleteBox"
            Me.btnDeleteBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeleteBox.Size = New System.Drawing.Size(160, 32)
            Me.btnDeleteBox.TabIndex = 2
            Me.btnDeleteBox.Text = "DELETE EMPTY LOT"
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
            Me.dbgPallets.CaptionHeight = 19
            Me.dbgPallets.CollapseColor = System.Drawing.Color.White
            Me.dbgPallets.ExpandColor = System.Drawing.Color.White
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.ForeColor = System.Drawing.Color.White
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(16, 9)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(408, 223)
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
            "eDBGrid.MergeView HBarHeight=""17"" AllowColMove=""False"" AllowColSelect=""False"" Na" & _
            "me="""" AllowRowSizing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFo" & _
            "oterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecS" & _
            "elWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>219</Heig" & _
            "ht><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=" & _
            """Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""" & _
            "FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle" & _
            " parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><Hig" & _
            "hLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inacti" & _
            "ve"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyl" & _
            "e parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""St" & _
            "yle6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 404, 219</ClientR" & _
            "ect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDB" & _
            "Grid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style paren" & _
            "t=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""H" & _
            "eading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""No" & _
            "rmal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal" & _
            """ me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Norma" & _
            "l"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""No" & _
            "rmal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertS" & _
            "plits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSe" & _
            "lWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 404, 219</ClientArea><PrintPageH" & _
            "eaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17""" & _
            " /></Blob>"
            '
            'btnReopenBox
            '
            Me.btnReopenBox.BackColor = System.Drawing.Color.Green
            Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenBox.ForeColor = System.Drawing.Color.White
            Me.btnReopenBox.Location = New System.Drawing.Point(16, 240)
            Me.btnReopenBox.Name = "btnReopenBox"
            Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReopenBox.Size = New System.Drawing.Size(152, 32)
            Me.btnReopenBox.TabIndex = 1
            Me.btnReopenBox.Text = "REOPEN  LOT"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(16, 288)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(152, 31)
            Me.btnReprintBoxLabel.TabIndex = 3
            Me.btnReprintBoxLabel.Text = "REPRINT LOT LABEL"
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Black
            Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
            Me.lblScreenName.Location = New System.Drawing.Point(1, 1)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(447, 79)
            Me.lblScreenName.TabIndex = 125
            Me.lblScreenName.Text = "GENESIS BUILD SHIP LOT"
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PanelOrder
            '
            Me.PanelOrder.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWOLineQty, Me.Label17, Me.lblWOLinePackedQty, Me.Label7, Me.lblPlannedShipmentDate, Me.Label6, Me.Button5, Me.btnCreateBoxID, Me.lblModelDesc, Me.Label1, Me.cboOpenSO, Me.Label5, Me.Label2, Me.cboSOLines})
            Me.PanelOrder.Location = New System.Drawing.Point(1, 81)
            Me.PanelOrder.Name = "PanelOrder"
            Me.PanelOrder.Size = New System.Drawing.Size(447, 207)
            Me.PanelOrder.TabIndex = 122
            '
            'lblWOLineQty
            '
            Me.lblWOLineQty.BackColor = System.Drawing.Color.White
            Me.lblWOLineQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWOLineQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWOLineQty.ForeColor = System.Drawing.Color.Black
            Me.lblWOLineQty.Location = New System.Drawing.Point(176, 136)
            Me.lblWOLineQty.Name = "lblWOLineQty"
            Me.lblWOLineQty.Size = New System.Drawing.Size(56, 21)
            Me.lblWOLineQty.TabIndex = 122
            Me.lblWOLineQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label17
            '
            Me.Label17.BackColor = System.Drawing.Color.Transparent
            Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(56, 136)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(120, 21)
            Me.Label17.TabIndex = 121
            Me.Label17.Text = "Line's Quantity:"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWOLinePackedQty
            '
            Me.lblWOLinePackedQty.BackColor = System.Drawing.Color.White
            Me.lblWOLinePackedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWOLinePackedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWOLinePackedQty.ForeColor = System.Drawing.Color.Black
            Me.lblWOLinePackedQty.Location = New System.Drawing.Point(368, 136)
            Me.lblWOLinePackedQty.Name = "lblWOLinePackedQty"
            Me.lblWOLinePackedQty.Size = New System.Drawing.Size(56, 21)
            Me.lblWOLinePackedQty.TabIndex = 120
            Me.lblWOLinePackedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(248, 136)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(120, 21)
            Me.Label7.TabIndex = 119
            Me.Label7.Text = "Packed Quantity:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPlannedShipmentDate
            '
            Me.lblPlannedShipmentDate.BackColor = System.Drawing.Color.White
            Me.lblPlannedShipmentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPlannedShipmentDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPlannedShipmentDate.ForeColor = System.Drawing.Color.Black
            Me.lblPlannedShipmentDate.Location = New System.Drawing.Point(176, 104)
            Me.lblPlannedShipmentDate.Name = "lblPlannedShipmentDate"
            Me.lblPlannedShipmentDate.Size = New System.Drawing.Size(248, 21)
            Me.lblPlannedShipmentDate.TabIndex = 118
            Me.lblPlannedShipmentDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(0, 104)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(168, 21)
            Me.Label6.TabIndex = 117
            Me.Label6.Text = "Planned Shipment Date:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Button5
            '
            Me.Button5.BackColor = System.Drawing.Color.Black
            Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button5.Location = New System.Drawing.Point(985, 274)
            Me.Button5.Name = "Button5"
            Me.Button5.Size = New System.Drawing.Size(410, 409)
            Me.Button5.TabIndex = 66
            Me.Button5.TabStop = False
            Me.Button5.Text = "Generate Report"
            '
            'btnCreateBoxID
            '
            Me.btnCreateBoxID.BackColor = System.Drawing.Color.Green
            Me.btnCreateBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateBoxID.ForeColor = System.Drawing.Color.White
            Me.btnCreateBoxID.Location = New System.Drawing.Point(176, 168)
            Me.btnCreateBoxID.Name = "btnCreateBoxID"
            Me.btnCreateBoxID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreateBoxID.Size = New System.Drawing.Size(248, 28)
            Me.btnCreateBoxID.TabIndex = 3
            Me.btnCreateBoxID.Text = "CREATE LOT ID"
            Me.btnCreateBoxID.Visible = False
            '
            'lblModelDesc
            '
            Me.lblModelDesc.BackColor = System.Drawing.Color.White
            Me.lblModelDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblModelDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelDesc.ForeColor = System.Drawing.Color.Black
            Me.lblModelDesc.Location = New System.Drawing.Point(176, 72)
            Me.lblModelDesc.Name = "lblModelDesc"
            Me.lblModelDesc.Size = New System.Drawing.Size(248, 21)
            Me.lblModelDesc.TabIndex = 115
            Me.lblModelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(64, 72)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 21)
            Me.Label1.TabIndex = 114
            Me.Label1.Text = "Model:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboOpenSO
            '
            Me.cboOpenSO.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenSO.AutoCompletion = True
            Me.cboOpenSO.AutoDropDown = True
            Me.cboOpenSO.AutoSelect = True
            Me.cboOpenSO.Caption = ""
            Me.cboOpenSO.CaptionHeight = 17
            Me.cboOpenSO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenSO.ColumnCaptionHeight = 17
            Me.cboOpenSO.ColumnFooterHeight = 17
            Me.cboOpenSO.ColumnHeaders = False
            Me.cboOpenSO.ContentHeight = 15
            Me.cboOpenSO.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenSO.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenSO.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenSO.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenSO.EditorHeight = 15
            Me.cboOpenSO.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboOpenSO.ItemHeight = 15
            Me.cboOpenSO.Location = New System.Drawing.Point(176, 8)
            Me.cboOpenSO.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenSO.MaxDropDownItems = CType(10, Short)
            Me.cboOpenSO.MaxLength = 32767
            Me.cboOpenSO.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenSO.Name = "cboOpenSO"
            Me.cboOpenSO.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenSO.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenSO.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenSO.Size = New System.Drawing.Size(248, 21)
            Me.cboOpenSO.TabIndex = 1
            Me.cboOpenSO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(64, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 21)
            Me.Label5.TabIndex = 113
            Me.Label5.Text = "Order :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(64, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 21)
            Me.Label2.TabIndex = 116
            Me.Label2.Text = "Order Line # :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboSOLines
            '
            Me.cboSOLines.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSOLines.AutoCompletion = True
            Me.cboSOLines.AutoDropDown = True
            Me.cboSOLines.AutoSelect = True
            Me.cboSOLines.Caption = ""
            Me.cboSOLines.CaptionHeight = 17
            Me.cboSOLines.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSOLines.ColumnCaptionHeight = 17
            Me.cboSOLines.ColumnFooterHeight = 17
            Me.cboSOLines.ColumnHeaders = False
            Me.cboSOLines.ContentHeight = 15
            Me.cboSOLines.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSOLines.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSOLines.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSOLines.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSOLines.EditorHeight = 15
            Me.cboSOLines.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboSOLines.ItemHeight = 15
            Me.cboSOLines.Location = New System.Drawing.Point(176, 40)
            Me.cboSOLines.MatchEntryTimeout = CType(2000, Long)
            Me.cboSOLines.MaxDropDownItems = CType(10, Short)
            Me.cboSOLines.MaxLength = 32767
            Me.cboSOLines.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSOLines.Name = "cboSOLines"
            Me.cboSOLines.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSOLines.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSOLines.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSOLines.Size = New System.Drawing.Size(248, 21)
            Me.cboSOLines.TabIndex = 2
            Me.cboSOLines.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'frmBuildShipLot
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(864, 645)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panelDeviceList, Me.PanelPalletList, Me.lblScreenName, Me.PanelOrder})
            Me.Name = "frmBuildShipLot"
            Me.Text = "frmBuildShipLot"
            Me.panelDeviceList.ResumeLayout(False)
            Me.PanelPalletList.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelOrder.ResumeLayout(False)
            CType(Me.cboOpenSO, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboSOLines, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************************************************
        Private Sub frmBuildShipLot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ''*****************************
                ''check computer mapping
                ''*****************************
                'i = CheckIfMachineTiedToLine()

                PSS.Core.Highlight.SetHighLight(Me)

                '*********************************
                'Load Open Order & Box Type
                '*********************************
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.LoadOpenToShipSO()

                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.cboOpenSO.SelectAll() : Me.cboOpenSO.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub LoadOpenToShipSO()
            Dim dt As DataTable

            Try
                Me._booPopDataToCombo = True : ClearOrderSelection()

                dt = Me._objShip.GetOpenToShipSO(SharedFunctions.intGenesisLocID, True)
                Misc.PopulateC1DropDownList(Me.cboOpenSO, dt, "WO_CustWO", "WO_ID")
                Me.cboOpenSO.SelectedValue = 0
                _booPopDataToCombo = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub ClearOrderSelection()
            Dim dt1, dt2 As DataTable

            Try
                If Not IsNothing(Me.cboSOLines.DataSource) Then dt1 = Me.cboSOLines.DataSource.Table
                Me.cboSOLines.DataSource = Nothing : Me.cboSOLines.Text = ""
                Me.lblModelDesc.Text = "" : Me.lblPlannedShipmentDate.Text = ""
                Me.lblWOLineQty.Text = "" : Me.lblWOLinePackedQty.Text = ""
                Me.btnCreateBoxID.Visible = False

                If Not IsNothing(Me.dbgPallets.DataSource) Then dt2 = Me.dbgPallets.DataSource.Table
                Me.dbgPallets.DataSource = Nothing : Me.ClearPalletData()
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
                Generic.DisposeDT(dt2)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub ClearPalletData()
            Dim dt As DataTable

            Try
                If Not IsNothing(Me.lstDevices.DataSource) Then dt = Me.lstDevices.DataSource.Table
                Me.lstDevices.DataSource = Nothing : Me.lstDevices.Refresh()
                Me.lblBoxName.Text = "" : Me.lblListCount.Text = ""
                Me.txtLed1.Text = "" : Me.txtLed2.Text = "" : Me.txtLed3.Text = "" : Me.txtLed4.Text = ""
                Me.txtPsu.Text = "" : Me.txtBaseplate.Text = "" : Me.txtDevSN.Text = ""
                Me.panelDeviceList.Visible = False
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub cboOpenSO_SOLine_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenSO.SelectedValueChanged, cboSOLines.SelectedValueChanged
            Try
                If Me._booPopDataToCombo = True Then Exit Sub

                If sender.name = "cboOpenSO" Then
                    Me.ClearOrderSelection()
                    If Me.cboOpenSO.SelectedValue > 0 Then
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        Me.LoadSOLines() : Me.cboSOLines.SelectAll() : Me.cboSOLines.Focus()
                    End If
                ElseIf sender.name = "cboSOLines" Then
                    Me.ClearPalletData()
                    If Me.cboSOLines.SelectedValue > 0 Then
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        Me.lblModelDesc.Text = Me.cboSOLines.Columns("ItemNo").CellValue(Me.cboSOLines.SelectedIndex)
                        Me.lblPlannedShipmentDate.Text = Me.cboSOLines.Columns("PlannedShipmentDate").CellValue(Me.cboSOLines.SelectedIndex)
                        Me.lblWOLineQty.Text = Me.cboSOLines.Columns("Quantity").CellValue(Me.cboSOLines.SelectedIndex)
                        Me.lblWOLinePackedQty.Text = Me._objShip.GetWOLinePackingCount(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue)
                        RefreshPalletList()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenSO_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub LoadSOLines()
            Dim dt As DataTable

            Try
                Me._booPopDataToCombo = True : ClearOrderSelection()

                dt = Me._objShip.GetOpenToShipSOLines(Me.cboOpenSO.SelectedValue, False)
                Misc.PopulateC1DropDownList(Me.cboSOLines, dt, "LineNo", "WOL_ID")
                _booPopDataToCombo = False

                If dt.Rows.Count > 0 AndAlso Me.cboSOLines.SelectedValue > 0 Then
                    Me.lblModelDesc.Text = Me.cboSOLines.Columns("ItemNo").CellValue(Me.cboSOLines.SelectedIndex)
                    Me.lblPlannedShipmentDate.Text = Me.cboSOLines.Columns("PlannedShipmentDate").CellValue(Me.cboSOLines.SelectedIndex)
                    Me.lblWOLineQty.Text = Me.cboSOLines.Columns("Quantity").CellValue(Me.cboSOLines.SelectedIndex)
                    Me.lblWOLinePackedQty.Text = Me._objShip.GetWOLinePackingCount(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue)
                    RefreshPalletList()
                End If

                Me._booPopDataToCombo = False
            Catch ex As Exception
                Throw ex
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub RefreshPalletList(Optional ByVal iPalletID As Integer = 0)
            Dim dt, dt1 As DataTable
            Dim i As Integer = 0

            Try
                If _booPopDataToCombo = True Then Exit Sub

                Me._booPopDataToCombo = True : ClearPalletData()
                If Not IsNothing(dbgPallets.DataSource) Then dt1 = Me.dbgPallets.DataSource.Table

                dt = Me._objShip.GetOpenPalletPerSOLines(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue)
                Me.dbgPallets.DataSource = dt.DefaultView : SetGridPalletProperties(iPalletID)
                _booPopDataToCombo = False

                If dt.Rows.Count > 0 Then
                    RefreshSNList() : Me.btnCreateBoxID.Visible = False
                Else
                    Me.btnCreateBoxID.Visible = True
                End If

                Me._booPopDataToCombo = False
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                _booPopDataToCombo = False
                Generic.DisposeDT(dt) : Generic.DisposeDT(dt1)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub SetGridPalletProperties(Optional ByVal iPallet_ID As Integer = 0)
            Dim iNumOfColumns As Integer = Me.dbgPallets.Columns.Count
            Dim i As Integer

            Try
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
                    .Splits(0).DisplayColumns("Lot Name").Width = 200
                    .Splits(0).DisplayColumns("Line #").Width = 60

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("Lot Name").Visible = True
                    .Splits(0).DisplayColumns("Line #").Visible = True

                    .AlternatingRows = True

                    For i = 0 To .RowCount - 1
                        If .Columns("Pallett_ID").CellValue(i) = iPallet_ID Then Exit Sub
                        .MoveNext()
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub RefreshSNList()
            Dim dt As DataTable
            Dim iPallet_ID As Integer = 0
            Dim strPalletName As String = ""
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                If _booPopDataToCombo = True Then Exit Sub

                Me._booPopDataToCombo = True : Me.ClearPalletData()

                '************************
                'Validations
                iPallet_ID = CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString)
                strPalletName = Me.dbgPallets.Columns("Lot Name").Value.ToString.Trim

                If iPallet_ID = 0 Then
                    Throw New Exception("Lot is not selected.")
                ElseIf strPalletName.Trim = "" Then
                    Throw New Exception("Lot is not selected.")
                End If

                '*******************************************
                'Get all devices add put them in them in list box for a pallet
                objMisc = New PSS.Data.Buisness.Misc()
                dt = objMisc.GetAllSNsForPallet(iPallet_ID)
                Me.lstDevices.DataSource = dt.DefaultView
                Me.lstDevices.ValueMember = dt.Columns("device_id").ToString
                Me.lstDevices.DisplayMember = dt.Columns("device_sn").ToString
                Me.lblBoxName.Text = strPalletName
                Me.lblListCount.Text = dt.Rows.Count
                Me.panelDeviceList.Visible = True
                '*******************************************
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnCreateBoxID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBoxID.Click
            Dim iPalletID As Integer = 0

            Try
                If Me.cboOpenSO.SelectedValue = 0 Then
                    MessageBox.Show("Please select Order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me.cboSOLines.SelectedValue = 0 Then
                    MessageBox.Show("Please select line item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Convert.ToInt32(Me.cboSOLines.Columns("Model_ID").CellValue(Me.cboSOLines.SelectedIndex)) = 0 Then
                    MessageBox.Show("Model ID is missing for this line item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me._objShip.GetWOLinePackingCount(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue) >= Convert.ToInt32(Me.cboSOLines.Columns("Quantity").CellValue(Me.cboSOLines.SelectedIndex)) Then
                    MessageBox.Show("You have reached the quantity of this line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                ElseIf Me._objShip.GetOpenPalletPerSOLines(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue).Rows.Count > 0 Then
                    MessageBox.Show("There is open lot. Please close it before open a new lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    Me.RefreshPalletList()
                Else
                    iPalletID = Me._objShip.CreatePallet(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue, Me.cboSOLines.Columns("Model_ID").CellValue(Me.cboSOLines.SelectedIndex))
                    RefreshPalletList(iPalletID)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreateBoxID_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub dbgPallets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgPallets.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.ProcessPalletSelection()
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtLed1.SelectAll() : Me.txtLed1.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgPallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub dbgPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgPallets.RowColChange
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.ProcessPalletSelection()
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtLed1.SelectAll() : Me.txtLed1.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgPallets_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub ProcessPalletSelection()
            Dim strShipType As String = ""
            Dim i As Integer = 0
            Dim booFound As Boolean = False

            Try
                Me.ClearPalletData()

                If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
                    Me.panelDeviceList.Visible = False : Exit Sub
                End If

                If Me.dbgPallets.Columns("Lot Name").Value.ToString.Trim = "" Then Exit Sub

                Me.lblBoxName.Text = Me.dbgPallets.Columns("Lot Name").Value.ToString

                Me.RefreshSNList()

                '*******************************************
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub txtOthers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLed1.KeyUp, txtLed2.KeyUp, txtLed3.KeyUp, txtLed4.KeyUp, txtPsu.KeyUp, txtBaseplate.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "txtLed1" Then
                        Me.txtLed2.SelectAll() : Me.txtLed2.Focus()
                    ElseIf sender.name = "txtLed2" Then
                        Me.txtLed3.SelectAll() : Me.txtLed3.Focus()
                    ElseIf sender.name = "txtLed3" Then
                        Me.txtLed4.SelectAll() : Me.txtLed4.Focus()
                    ElseIf sender.name = "txtLed4" Then
                        Me.txtPsu.SelectAll() : Me.txtPsu.Focus()
                    ElseIf sender.name = "txtPsu" Then
                        Me.txtBaseplate.SelectAll() : Me.txtBaseplate.Focus()
                    ElseIf sender.name = "txtBaseplate" Then
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Dim i, iWOLinePackedQty As Integer
            Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
            Dim dtDevice As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDevSN.Text.Trim.Length > 0 Then
                        '************************
                        'Validations
                        If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                            MessageBox.Show("Lot Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf Me.dbgPallets.Columns("Lot Name").Value.ToString.Trim = "" Then
                            MessageBox.Show("Lot Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf Me.lstDevices.Items.Count > 0 AndAlso Me.lstDevices.DataSource.Table.Select("device_sn = '" & strSN & "'").Length > 0 Then
                            MessageBox.Show("Device is listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf Not IsDBNull(Me.dbgPallets.Columns("Pallett_MaxQty").Value) AndAlso dbgPallets.Columns("Pallett_MaxQty").Value > 0 AndAlso Me.lstDevices.Items.Count >= dbgPallets.Columns("Pallett_MaxQty").Value Then
                            MessageBox.Show("Lot can't contain more than " & Me.dbgPallets.Columns("Pallett_MaxQty").Value & " units.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf Generic.IsPalletClosed(CInt(Me.dbgPallets.Columns("Pallett_ID").Value)) = True Then
                            '***************************************************
                            'Added by Lan on 09/16/2007
                            'Prevent the user from adding more devices to closed pallet.
                            'This happen when a pallet open at the 2 computer, computer 1 
                            '  close the pallet and refesh the screen while the other computer screen 
                            '  did not get refresh. This check will force the user to refresh the screen.
                            '***************************************************
                            MessageBox.Show("Lot had been closed by another machine. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Else
                            iWOLinePackedQty = Me._objShip.GetWOLinePackingCount(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue)
                            Me.lblWOLinePackedQty.Text = iWOLinePackedQty

                            If iWOLinePackedQty >= Convert.ToInt32(Me.cboSOLines.Columns("Quantity").CellValue(Me.cboSOLines.SelectedIndex)) Then
                                MessageBox.Show("You have reached the quantity of this line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            Else
                                dtDevice = PSS.Data.Buisness.Genesis.Receiving.GetOpenDeviceInfoByLocation(CInt(Me.dbgPallets.Columns("Loc_ID").Value), Me.txtDevSN.Text.Trim.ToUpper)

                                If dtDevice.Rows.Count > 1 Then
                                    MessageBox.Show("This device existed twice in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                ElseIf dtDevice.Rows.Count = 0 Then
                                    MessageBox.Show("This device does not exist in the system, already ship or belong to a different customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                ElseIf Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                                    MessageBox.Show("This device already has assigned into a box ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                ElseIf dtDevice.Rows(0)("Model_ID") <> Me.dbgPallets.Columns("Model_ID").Value Then
                                    MessageBox.Show("Wrong Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                ElseIf dtDevice.Rows(0)("WO_ID") <> CInt(Me.dbgPallets.Columns("WO_ID").Value) Then
                                    MessageBox.Show("Wrong order. This device belongs to order # " & dtDevice.Rows(0)("WO_CustWO") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)

                                    'THIS IS TEMPORARY !!...REMOVE THIS AFTER FINISH                                'ElseIf CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 0 AndAlso Generic.HasQCPassInLastTransaction(dtDevice.Rows(0)("Device_ID")) = False Then    'must Final passed
                                    '    MessageBox.Show("Device does not has QC Passed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Else
                                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                                    '***************************************************
                                    'if above all is fine then add it to the list and update the database
                                    i = Me._objShip.AssignDeviceToPallet(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), dtDevice.Rows(0)("Device_ID") _
                                                                        , Me.txtLed1.Text.Trim.ToUpper, Me.txtLed2.Text.Trim.ToUpper, Me.txtLed3.Text.Trim.ToUpper, Me.txtLed4.Text.Trim.ToUpper _
                                                                        , Me.txtPsu.Text.Trim.ToUpper, Me.txtBaseplate.Text.Trim.ToUpper)

                                    '***************************************************
                                    Me.lblWOLinePackedQty.Text = iWOLinePackedQty + 1
                                    Me.RefreshSNList() : Me.Enabled = True : Cursor.Current = Cursors.Default
                                    Me.txtLed1.Text = "" : Me.txtLed2.Text = "" : Me.txtLed3.Text = "" : Me.txtLed4.Text = ""
                                    Me.txtPsu.Text = "" : Me.txtBaseplate.Text = "" : Me.txtDevSN.Text = ""
                                    Me.Enabled = True : Cursor.Current = Cursors.Default : Me.txtLed1.Focus()

                                End If  'Device's validation
                            End If  'Unit packed under workorder Line quantity
                        End If  'Pallet's validation
                    End If  'SN's length > 0
                End If  'Enter key
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dtDevice)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim strSN As String = ""
            Dim iDeviceID, i As Integer

            Try
                '************************
                'Validations
                If Me.dbgPallets.RowCount = 0 Then
                    MessageBox.Show("Box Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    MessageBox.Show("Box Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    Exit Sub
                Else
                    '************************
                    strSN = InputBox("Enter serial number:", "S/N").Trim
                    If strSN = "" Then Exit Sub
                    iDeviceID = 0 : i = 0

                    If Me.lstDevices.Items.Count > 0 AndAlso Me.lstDevices.DataSource.Table.Select("device_sn = '" & strSN & "'").Length > 0 Then
                        iDeviceID = CInt(Me.lstDevices.DataSource.Table.Select("device_sn = '" & strSN & "'")(0)("Device_ID").ToString)
                    End If

                    If iDeviceID > 0 Then
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        i = Me._objShip.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), iDeviceID)
                        If i = 0 Then
                            MessageBox.Show("System has failed to remove serial number from list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Else
                            Me.lblWOLinePackedQty.Text = Me._objShip.GetWOLinePackingCount(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue)
                            Me.RefreshSNList()
                        End If
                    Else
                        MessageBox.Show("Serial number is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Remove S/N", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtLed1.SelectAll() : Me.txtLed1.Focus()
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Dim i As Integer = 0

            Try
                If Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("The list is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf MessageBox.Show("Are you sure you want to remove all devices from this Box?", "Clear All S/Ns", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                ElseIf Me.dbgPallets.RowCount = 0 Then
                    MessageBox.Show("Box Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    MessageBox.Show("Box Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    Exit Sub
                Else
                    '************************
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = Me._objShip.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), 0)

                    If i = 0 Then
                        MessageBox.Show("System has failed to remove all serial number from list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        Me.lblWOLinePackedQty.Text = Me._objShip.GetWOLinePackingCount(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue)
                        RefreshSNList()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtLed1.SelectAll() : Me.txtLed1.Focus()
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnCloseLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseLot.Click
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim i, iDeviceID, iWOLinePackedQty, iPalletID As Integer

            Try
                i = 0 : iDeviceID = 0 : iWOLinePackedQty = 0 : iPalletID = 0
                '************************
                'Validations
                If CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    MessageBox.Show("Lot name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dbgPallets.Columns("Lot Name").Value.ToString.Trim = "" Then
                    MessageBox.Show("Lot name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("This lot is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(Me.dbgPallets.Columns("Pallett_MaxQty").Value) AndAlso dbgPallets.Columns("Pallett_MaxQty").Value > 0 AndAlso Me.lstDevices.Items.Count > dbgPallets.Columns("Pallett_MaxQty").Value Then
                    MessageBox.Show("The list has exceeded the maximum quantity of " & dbgPallets.Columns("Pallett_MaxQty").Value & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Generic.IsPalletClosed(CInt(Me.dbgPallets.Columns("Pallett_ID").Value)) = True Then
                    '***************************************************
                    'Added by Lan on 09/16/2007
                    'Prevent the user from adding more devices to closed pallet.
                    'This happen when a pallet open at the 2 computer, computer 1 
                    '  close the pallet and refesh the screen while the other computer screen 
                    '  did not get refresh. This check will force the user to refresh the screen.
                    '***************************************************
                    MessageBox.Show("Lot had been closed by another machine. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf MessageBox.Show("Are you sure you want to close this lot?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    iPalletID = Convert.ToInt32(Me.dbgPallets.Columns("Pallett_id").Value)
                    iWOLinePackedQty = Me._objShip.GetWOLinePackingCount(SharedFunctions.intGenesisCustID, SharedFunctions.intGenesisLocID, Me.cboOpenSO.SelectedValue, Me.cboSOLines.SelectedValue)

                    If iWOLinePackedQty > Convert.ToInt32(Me.cboSOLines.Columns("Quantity").CellValue(Me.cboSOLines.SelectedIndex)) Then
                        MessageBox.Show("You have exceeded the quantity of this line. Please adjust the list's quantity to line's quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    Else
                        objMisc = New PSS.Data.Buisness.Misc()
                        i = objMisc.ClosePallet(SharedFunctions.intGenesisCustID, CInt(Me.dbgPallets.Columns("Pallett_ID").Value), Me.dbgPallets.Columns("Lot Name").Value, Me.lstDevices.Items.Count, Me.dbgPallets.Columns("Pallet_ShipType").Value, 0)

                        If i = 0 Then
                            MessageBox.Show("Box has not closed yet due to an error. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If iWOLinePackedQty = Convert.ToInt32(Me.cboSOLines.Columns("Quantity").CellValue(Me.cboSOLines.SelectedIndex)) Then
                                Me._objShip.SetShippingClosedFlag(Me.dbgPallets.Columns("Pallet_SkuLen").Value, 1)
                                Me.LoadSOLines()
                            Else
                                'Reset Screen control properties.
                                Me.lblWOLinePackedQty.Text = iWOLinePackedQty
                                Me.RefreshPalletList()
                            End If
                            '************************
                            'Pallet Label
                            '************************
                            Me._objShip.PrintBoxLabel(iPalletID, SharedFunctions.strPaletLabelName)
                        End If 'update
                    End If  'WOLine Qtry
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtLed1.SelectAll() : Me.txtLed1.Focus()
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnReopenBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenBox.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable

            Try
                '************************
                strPallet = InputBox("Enter Lot Name.", "Reopen Lot")
                If strPallet = "" Then
                    MessageBox.Show("You must enter enter lot name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.RefreshPalletList()

                dt = PSS.Data.Production.Shipping.GetPalletInfoByName(strPallet, SharedFunctions.intGenesisCustID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Lot does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Lot name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Lot has been shipped. Not allow to reopen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Lot is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not IsNothing(Me.dbgPallets.DataSource) AndAlso Me.dbgPallets.RowCount > 0 AndAlso Me.dbgPallets.DataSource.Table.Select("Model_ID = " & dt.Rows(0)("Model_ID") & " AND Pallet_SkuLen = '" & dt.Rows(0)("Pallet_SkuLen") & "' AND Pallet_ShipType = " & dt.Rows(0)("Pallet_ShipType")).Length > 0 Then
                    MessageBox.Show("There is an open lot in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("Pallet_Invalid") > 0 Then
                    MessageBox.Show("This is an invalid lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    i = PSS.Data.Production.Shipping.ReopenPallet(dt.Rows(0)("Pallett_ID"))
                    Me._objShip.SetShippingClosedFlag(dt.Rows(0)("Pallet_SkuLen"), 0)
                    If i = 0 Then
                        MessageBox.Show("Box was not reopened.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else 'Refresh Pallet( Box )
                        Me.LoadSOLines()

                        Me.Enabled = True : Cursor.Current = Cursors.Default
                        Me.txtLed1.SelectAll() : Me.txtLed1.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reopen Box.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnDeleteBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBox.Click
            Dim i As Integer = 0

            Try
                If Me.dbgPallets.RowCount = 0 Then Exit Sub
                If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then Exit Sub

                If MessageBox.Show("Are you sure you want to delete selected lot?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.DeleteEmptyPallet(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), PSS.Core.ApplicationUser.IDuser)
                    MessageBox.Show("Box has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.RefreshPalletList()
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Dim str_pallett As String = ""
            Dim dtPallettInfo As DataTable

            Try
                str_pallett = InputBox("Enter Lot Name.", "Reprint Lot Label")
                If str_pallett = "" Then
                    MessageBox.Show("Please enter a Box Name if you want to reprint the box label.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    dtPallettInfo = PSS.Data.Production.Shipping.GetPalletInfoByName(str_pallett, SharedFunctions.intGenesisCustID)
                    If dtPallettInfo.Rows.Count = 0 Then
                        MessageBox.Show("Lot Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dtPallettInfo.Rows.Count > 1 Then
                        MessageBox.Show("Lot Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dtPallettInfo.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                        MessageBox.Show("Lot is still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Me._objShip.PrintBoxLabel(dtPallettInfo.Rows(0)("Pallett_ID"), SharedFunctions.strPaletLabelName)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtPallettInfo)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************

    End Class
End Namespace