Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_RAC_GIN_FillOrder
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblOrderRevDT As System.Windows.Forms.Label
        Friend WithEvents txtOrderRevDT As System.Windows.Forms.TextBox
        Friend WithEvents lblOrderNo As System.Windows.Forms.Label
        Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
        Friend WithEvents txtOrderQty As System.Windows.Forms.TextBox
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents txtShipQty As System.Windows.Forms.TextBox
        Friend WithEvents lblShipQty As System.Windows.Forms.Label
        Friend WithEvents grbShipmentInfo As System.Windows.Forms.GroupBox
        Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
        Friend WithEvents txtCoutry As System.Windows.Forms.TextBox
        Friend WithEvents txtState As System.Windows.Forms.TextBox
        Friend WithEvents txtCity As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtSIMCardSN As System.Windows.Forms.TextBox
        Friend WithEvents tdgSIM As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label3 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_RAC_GIN_FillOrder))
            Me.Button1 = New System.Windows.Forms.Button()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblOrderRevDT = New System.Windows.Forms.Label()
            Me.txtOrderRevDT = New System.Windows.Forms.TextBox()
            Me.lblOrderNo = New System.Windows.Forms.Label()
            Me.txtOrderNo = New System.Windows.Forms.TextBox()
            Me.txtOrderQty = New System.Windows.Forms.TextBox()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.txtShipQty = New System.Windows.Forms.TextBox()
            Me.lblShipQty = New System.Windows.Forms.Label()
            Me.grbShipmentInfo = New System.Windows.Forms.GroupBox()
            Me.txtZipCode = New System.Windows.Forms.TextBox()
            Me.txtCoutry = New System.Windows.Forms.TextBox()
            Me.txtState = New System.Windows.Forms.TextBox()
            Me.txtCity = New System.Windows.Forms.TextBox()
            Me.txtAddress2 = New System.Windows.Forms.TextBox()
            Me.txtAddress1 = New System.Windows.Forms.TextBox()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtSIMCardSN = New System.Windows.Forms.TextBox()
            Me.tdgSIM = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label3 = New System.Windows.Forms.Label()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbShipmentInfo.SuspendLayout()
            CType(Me.tdgSIM, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(64, 16)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(112, 32)
            Me.Button1.TabIndex = 0
            Me.Button1.Text = "Button1"
            '
            'tdgData1
            '
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.CaptionHeight = 17
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(32, 64)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(800, 184)
            Me.tdgData1.TabIndex = 142
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;F" & _
            "oreColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
            "ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>182</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 798, 182</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 798, 182</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14""" & _
            " /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblOrderRevDT
            '
            Me.lblOrderRevDT.BackColor = System.Drawing.Color.Transparent
            Me.lblOrderRevDT.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderRevDT.ForeColor = System.Drawing.Color.White
            Me.lblOrderRevDT.Location = New System.Drawing.Point(24, 280)
            Me.lblOrderRevDT.Name = "lblOrderRevDT"
            Me.lblOrderRevDT.Size = New System.Drawing.Size(80, 21)
            Me.lblOrderRevDT.TabIndex = 169
            Me.lblOrderRevDT.Text = "Order Date:"
            Me.lblOrderRevDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtOrderRevDT
            '
            Me.txtOrderRevDT.BackColor = System.Drawing.SystemColors.Info
            Me.txtOrderRevDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOrderRevDT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtOrderRevDT.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtOrderRevDT.Location = New System.Drawing.Point(104, 280)
            Me.txtOrderRevDT.Name = "txtOrderRevDT"
            Me.txtOrderRevDT.ReadOnly = True
            Me.txtOrderRevDT.Size = New System.Drawing.Size(192, 21)
            Me.txtOrderRevDT.TabIndex = 168
            Me.txtOrderRevDT.Text = ""
            '
            'lblOrderNo
            '
            Me.lblOrderNo.BackColor = System.Drawing.Color.Transparent
            Me.lblOrderNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderNo.ForeColor = System.Drawing.Color.White
            Me.lblOrderNo.Location = New System.Drawing.Point(32, 256)
            Me.lblOrderNo.Name = "lblOrderNo"
            Me.lblOrderNo.Size = New System.Drawing.Size(72, 21)
            Me.lblOrderNo.TabIndex = 165
            Me.lblOrderNo.Text = "Order No:"
            Me.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtOrderNo
            '
            Me.txtOrderNo.BackColor = System.Drawing.SystemColors.Info
            Me.txtOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOrderNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtOrderNo.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtOrderNo.Location = New System.Drawing.Point(104, 256)
            Me.txtOrderNo.Name = "txtOrderNo"
            Me.txtOrderNo.ReadOnly = True
            Me.txtOrderNo.Size = New System.Drawing.Size(168, 21)
            Me.txtOrderNo.TabIndex = 164
            Me.txtOrderNo.Text = ""
            '
            'txtOrderQty
            '
            Me.txtOrderQty.BackColor = System.Drawing.Color.Black
            Me.txtOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOrderQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtOrderQty.ForeColor = System.Drawing.Color.Aqua
            Me.txtOrderQty.Location = New System.Drawing.Point(104, 312)
            Me.txtOrderQty.Name = "txtOrderQty"
            Me.txtOrderQty.ReadOnly = True
            Me.txtOrderQty.Size = New System.Drawing.Size(48, 23)
            Me.txtOrderQty.TabIndex = 166
            Me.txtOrderQty.Text = "0"
            Me.txtOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblOrderQty
            '
            Me.lblOrderQty.BackColor = System.Drawing.Color.Transparent
            Me.lblOrderQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.White
            Me.lblOrderQty.Location = New System.Drawing.Point(24, 312)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(80, 21)
            Me.lblOrderQty.TabIndex = 167
            Me.lblOrderQty.Text = "Order Qty:"
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShipQty
            '
            Me.txtShipQty.BackColor = System.Drawing.Color.Black
            Me.txtShipQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtShipQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipQty.ForeColor = System.Drawing.Color.Aqua
            Me.txtShipQty.Location = New System.Drawing.Point(240, 312)
            Me.txtShipQty.Name = "txtShipQty"
            Me.txtShipQty.ReadOnly = True
            Me.txtShipQty.Size = New System.Drawing.Size(48, 23)
            Me.txtShipQty.TabIndex = 170
            Me.txtShipQty.Text = "0"
            Me.txtShipQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblShipQty
            '
            Me.lblShipQty.BackColor = System.Drawing.Color.Transparent
            Me.lblShipQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipQty.ForeColor = System.Drawing.Color.White
            Me.lblShipQty.Location = New System.Drawing.Point(168, 312)
            Me.lblShipQty.Name = "lblShipQty"
            Me.lblShipQty.Size = New System.Drawing.Size(72, 21)
            Me.lblShipQty.TabIndex = 171
            Me.lblShipQty.Text = "Ship Qty:"
            Me.lblShipQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbShipmentInfo
            '
            Me.grbShipmentInfo.BackColor = System.Drawing.Color.SteelBlue
            Me.grbShipmentInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtZipCode, Me.txtCoutry, Me.txtState, Me.txtCity, Me.txtAddress2, Me.txtAddress1, Me.txtName, Me.Label12})
            Me.grbShipmentInfo.Location = New System.Drawing.Point(40, 352)
            Me.grbShipmentInfo.Name = "grbShipmentInfo"
            Me.grbShipmentInfo.Size = New System.Drawing.Size(264, 152)
            Me.grbShipmentInfo.TabIndex = 172
            Me.grbShipmentInfo.TabStop = False
            '
            'txtZipCode
            '
            Me.txtZipCode.BackColor = System.Drawing.SystemColors.Info
            Me.txtZipCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtZipCode.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtZipCode.Location = New System.Drawing.Point(8, 120)
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.ReadOnly = True
            Me.txtZipCode.Size = New System.Drawing.Size(136, 23)
            Me.txtZipCode.TabIndex = 142
            Me.txtZipCode.Text = ""
            '
            'txtCoutry
            '
            Me.txtCoutry.BackColor = System.Drawing.SystemColors.Info
            Me.txtCoutry.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCoutry.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtCoutry.Location = New System.Drawing.Point(144, 120)
            Me.txtCoutry.Name = "txtCoutry"
            Me.txtCoutry.ReadOnly = True
            Me.txtCoutry.Size = New System.Drawing.Size(112, 23)
            Me.txtCoutry.TabIndex = 143
            Me.txtCoutry.Text = ""
            '
            'txtState
            '
            Me.txtState.BackColor = System.Drawing.SystemColors.Info
            Me.txtState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtState.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtState.Location = New System.Drawing.Point(144, 96)
            Me.txtState.Name = "txtState"
            Me.txtState.ReadOnly = True
            Me.txtState.Size = New System.Drawing.Size(112, 23)
            Me.txtState.TabIndex = 141
            Me.txtState.Text = ""
            '
            'txtCity
            '
            Me.txtCity.BackColor = System.Drawing.SystemColors.Info
            Me.txtCity.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCity.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtCity.Location = New System.Drawing.Point(8, 96)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.ReadOnly = True
            Me.txtCity.Size = New System.Drawing.Size(136, 23)
            Me.txtCity.TabIndex = 140
            Me.txtCity.Text = ""
            '
            'txtAddress2
            '
            Me.txtAddress2.BackColor = System.Drawing.SystemColors.Info
            Me.txtAddress2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress2.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtAddress2.Location = New System.Drawing.Point(8, 72)
            Me.txtAddress2.Name = "txtAddress2"
            Me.txtAddress2.ReadOnly = True
            Me.txtAddress2.Size = New System.Drawing.Size(248, 23)
            Me.txtAddress2.TabIndex = 139
            Me.txtAddress2.Text = ""
            '
            'txtAddress1
            '
            Me.txtAddress1.BackColor = System.Drawing.SystemColors.Info
            Me.txtAddress1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress1.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtAddress1.Location = New System.Drawing.Point(8, 48)
            Me.txtAddress1.Name = "txtAddress1"
            Me.txtAddress1.ReadOnly = True
            Me.txtAddress1.Size = New System.Drawing.Size(248, 23)
            Me.txtAddress1.TabIndex = 138
            Me.txtAddress1.Text = ""
            '
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.SystemColors.Info
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtName.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtName.Location = New System.Drawing.Point(8, 24)
            Me.txtName.Name = "txtName"
            Me.txtName.ReadOnly = True
            Me.txtName.Size = New System.Drawing.Size(248, 21)
            Me.txtName.TabIndex = 137
            Me.txtName.Text = ""
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(1, 8)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(72, 16)
            Me.Label12.TabIndex = 136
            Me.Label12.Text = "Address:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtSIMCardSN
            '
            Me.txtSIMCardSN.BackColor = System.Drawing.Color.White
            Me.txtSIMCardSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSIMCardSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSIMCardSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSIMCardSN.Location = New System.Drawing.Point(328, 280)
            Me.txtSIMCardSN.Name = "txtSIMCardSN"
            Me.txtSIMCardSN.Size = New System.Drawing.Size(376, 23)
            Me.txtSIMCardSN.TabIndex = 188
            Me.txtSIMCardSN.Text = ""
            '
            'tdgSIM
            '
            Me.tdgSIM.AllowColMove = False
            Me.tdgSIM.AllowColSelect = False
            Me.tdgSIM.AllowFilter = False
            Me.tdgSIM.AllowSort = False
            Me.tdgSIM.AllowUpdate = False
            Me.tdgSIM.BackColor = System.Drawing.Color.White
            Me.tdgSIM.CaptionHeight = 17
            Me.tdgSIM.ColumnHeaders = False
            Me.tdgSIM.FetchRowStyles = True
            Me.tdgSIM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgSIM.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgSIM.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgSIM.Location = New System.Drawing.Point(328, 304)
            Me.tdgSIM.Name = "tdgSIM"
            Me.tdgSIM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSIM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSIM.PreviewInfo.ZoomFactor = 75
            Me.tdgSIM.RecordSelectors = False
            Me.tdgSIM.RowHeight = 15
            Me.tdgSIM.Size = New System.Drawing.Size(376, 200)
            Me.tdgSIM.TabIndex = 190
            Me.tdgSIM.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" RecordSelectors=""Fal" & _
            "se"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>196</Height><Capti" & _
            "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
            "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
            """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
            "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
            "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
            "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
            """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
            "Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 372, 196</ClientRect><Bord" & _
            "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
            "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
            """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
            "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
            """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
            "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
            "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
            """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
            "vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17" & _
            "</DefaultRecSelWidth><ClientArea>0, 0, 372, 196</ClientArea><PrintPageHeaderStyl" & _
            "e parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob" & _
            ">"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Navy
            Me.Label3.Location = New System.Drawing.Point(328, 256)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 21)
            Me.Label3.TabIndex = 189
            Me.Label3.Text = "SIM Card SN:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmTFFK_RAC_GIN_FillOrder
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(872, 574)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSIMCardSN, Me.tdgSIM, Me.Label3, Me.grbShipmentInfo, Me.lblOrderRevDT, Me.txtOrderRevDT, Me.lblOrderNo, Me.txtOrderNo, Me.txtOrderQty, Me.lblOrderQty, Me.txtShipQty, Me.lblShipQty, Me.tdgData1, Me.Button1})
            Me.Name = "frmTFFK_RAC_GIN_FillOrder"
            Me.Text = "frmTFFK_RAC_GIN_FillOrder"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbShipmentInfo.ResumeLayout(False)
            CType(Me.tdgSIM, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

    End Class
End Namespace
