Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_Relabel
        Inherits System.Windows.Forms.Form

        Private _objPick As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip
        Private _dtOrder As DataTable
        Private _dtOrderDetail As DataTable
        Private _dtSelectedOrderDetail As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objPick = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Me._objPick = Nothing

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
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblPO As System.Windows.Forms.Label
        Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
        Friend WithEvents lblOpenOrders As System.Windows.Forms.Label
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lstICCID As System.Windows.Forms.ListBox
        Friend WithEvents tdgProductDetails As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnDelAll As System.Windows.Forms.Button
        Friend WithEvents btnDelOne As System.Windows.Forms.Button
        Friend WithEvents txtWHBoxName As System.Windows.Forms.TextBox
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents txtOrderQty As System.Windows.Forms.TextBox
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents lblPickedQty As System.Windows.Forms.Label
        Friend WithEvents btnRelabel As System.Windows.Forms.Button
        Friend WithEvents btnToPickLocation As System.Windows.Forms.Button
        Friend WithEvents pnlDetails As System.Windows.Forms.Panel
        Friend WithEvents btnSplitBox As System.Windows.Forms.Button
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnSelectWO As System.Windows.Forms.Button
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents txtPickLocQty As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_Relabel))
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnRelabel = New System.Windows.Forms.Button()
            Me.lblPO = New System.Windows.Forms.Label()
            Me.txtPONumber = New System.Windows.Forms.TextBox()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.TextBox2 = New System.Windows.Forms.TextBox()
            Me.TextBox3 = New System.Windows.Forms.TextBox()
            Me.TextBox4 = New System.Windows.Forms.TextBox()
            Me.TextBox5 = New System.Windows.Forms.TextBox()
            Me.lblOpenOrders = New System.Windows.Forms.Label()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lstICCID = New System.Windows.Forms.ListBox()
            Me.tdgProductDetails = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnDelAll = New System.Windows.Forms.Button()
            Me.btnDelOne = New System.Windows.Forms.Button()
            Me.txtWHBoxName = New System.Windows.Forms.TextBox()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.txtOrderQty = New System.Windows.Forms.TextBox()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.txtPickLocQty = New System.Windows.Forms.TextBox()
            Me.lblPickedQty = New System.Windows.Forms.Label()
            Me.btnToPickLocation = New System.Windows.Forms.Button()
            Me.pnlDetails = New System.Windows.Forms.Panel()
            Me.btnSplitBox = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnSelectWO = New System.Windows.Forms.Button()
            Me.btnRefresh = New System.Windows.Forms.Button()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgProductDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlDetails.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(0, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(576, 32)
            Me.Label2.TabIndex = 156
            Me.Label2.Text = "WH to Pick Location, Split Box, Relabeling"
            '
            'btnRelabel
            '
            Me.btnRelabel.BackColor = System.Drawing.Color.Transparent
            Me.btnRelabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRelabel.Location = New System.Drawing.Point(256, 520)
            Me.btnRelabel.Name = "btnRelabel"
            Me.btnRelabel.Size = New System.Drawing.Size(168, 56)
            Me.btnRelabel.TabIndex = 149
            Me.btnRelabel.Text = "Relabel"
            '
            'lblPO
            '
            Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPO.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblPO.Location = New System.Drawing.Point(48, 64)
            Me.lblPO.Name = "lblPO"
            Me.lblPO.Size = New System.Drawing.Size(128, 23)
            Me.lblPO.TabIndex = 145
            Me.lblPO.Text = "Scan IMEI"
            '
            'txtPONumber
            '
            Me.txtPONumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPONumber.Location = New System.Drawing.Point(32, 88)
            Me.txtPONumber.Name = "txtPONumber"
            Me.txtPONumber.Size = New System.Drawing.Size(184, 26)
            Me.txtPONumber.TabIndex = 0
            Me.txtPONumber.Text = ""
            '
            'TextBox1
            '
            Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox1.Location = New System.Drawing.Point(120, 120)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(96, 26)
            Me.TextBox1.TabIndex = 158
            Me.TextBox1.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label1.Location = New System.Drawing.Point(32, 128)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 23)
            Me.Label1.TabIndex = 159
            Me.Label1.Text = "FROM:"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label3.Location = New System.Drawing.Point(32, 160)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 23)
            Me.Label3.TabIndex = 160
            Me.Label3.Text = "TO:"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label4.Location = New System.Drawing.Point(32, 192)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 23)
            Me.Label4.TabIndex = 161
            Me.Label4.Text = "QTY:"
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label5.Location = New System.Drawing.Point(32, 224)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(88, 23)
            Me.Label5.TabIndex = 162
            Me.Label5.Text = "SCANNED:"
            '
            'TextBox2
            '
            Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox2.Location = New System.Drawing.Point(120, 152)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(96, 26)
            Me.TextBox2.TabIndex = 163
            Me.TextBox2.Text = ""
            '
            'TextBox3
            '
            Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox3.Location = New System.Drawing.Point(120, 184)
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Size = New System.Drawing.Size(96, 26)
            Me.TextBox3.TabIndex = 164
            Me.TextBox3.Text = ""
            '
            'TextBox4
            '
            Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox4.Location = New System.Drawing.Point(120, 216)
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.Size = New System.Drawing.Size(96, 26)
            Me.TextBox4.TabIndex = 165
            Me.TextBox4.Text = ""
            '
            'TextBox5
            '
            Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox5.Location = New System.Drawing.Point(64, 8)
            Me.TextBox5.Name = "TextBox5"
            Me.TextBox5.Size = New System.Drawing.Size(152, 26)
            Me.TextBox5.TabIndex = 167
            Me.TextBox5.Text = ""
            '
            'lblOpenOrders
            '
            Me.lblOpenOrders.BackColor = System.Drawing.Color.SteelBlue
            Me.lblOpenOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOpenOrders.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lblOpenOrders.Location = New System.Drawing.Point(16, 48)
            Me.lblOpenOrders.Name = "lblOpenOrders"
            Me.lblOpenOrders.Size = New System.Drawing.Size(144, 24)
            Me.lblOpenOrders.TabIndex = 166
            Me.lblOpenOrders.Text = "Open Sale Orders"
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
            Me.tdgData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(16, 72)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(600, 144)
            Me.tdgData1.TabIndex = 157
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
            "crollGroup=""1"" HorizontalScrollGroup=""1""><Height>142</Height><CaptionStyle paren" & _
            "t=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSty" & _
            "le parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13" & _
            """ /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""St" & _
            "yle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=" & _
            """HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Odd" & _
            "RowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelect" & _
            "or"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=" & _
            """Normal"" me=""Style1"" /><ClientRect>0, 0, 598, 142</ClientRect><BorderSide>0</Bor" & _
            "derSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecS" & _
            "elWidth><ClientArea>0, 0, 598, 142</ClientArea><PrintPageHeaderStyle parent="""" m" & _
            "e=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lstICCID
            '
            Me.lstICCID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstICCID.Location = New System.Drawing.Point(32, 256)
            Me.lstICCID.Name = "lstICCID"
            Me.lstICCID.Size = New System.Drawing.Size(184, 69)
            Me.lstICCID.TabIndex = 176
            '
            'tdgProductDetails
            '
            Me.tdgProductDetails.AllowColMove = False
            Me.tdgProductDetails.AllowColSelect = False
            Me.tdgProductDetails.AllowFilter = False
            Me.tdgProductDetails.AllowSort = False
            Me.tdgProductDetails.AllowUpdate = False
            Me.tdgProductDetails.AlternatingRows = True
            Me.tdgProductDetails.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgProductDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgProductDetails.CaptionHeight = 17
            Me.tdgProductDetails.FetchRowStyles = True
            Me.tdgProductDetails.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgProductDetails.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgProductDetails.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgProductDetails.Location = New System.Drawing.Point(16, 64)
            Me.tdgProductDetails.Name = "tdgProductDetails"
            Me.tdgProductDetails.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgProductDetails.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgProductDetails.PreviewInfo.ZoomFactor = 75
            Me.tdgProductDetails.RowHeight = 15
            Me.tdgProductDetails.Size = New System.Drawing.Size(576, 128)
            Me.tdgProductDetails.TabIndex = 175
            Me.tdgProductDetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" " & _
            "CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyl" & _
            "es=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>126</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 574, 126</ClientRect><B" & _
            "orderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.M" & _
            "ergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Nor" & _
            "mal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading" & _
            """ me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" " & _
            "me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""" & _
            "HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=" & _
            """OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" " & _
            "me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>" & _
            "1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth" & _
            ">17</DefaultRecSelWidth><ClientArea>0, 0, 574, 126</ClientArea><PrintPageHeaderS" & _
            "tyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></B" & _
            "lob>"
            '
            'btnDelAll
            '
            Me.btnDelAll.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelAll.Location = New System.Drawing.Point(256, 8)
            Me.btnDelAll.Name = "btnDelAll"
            Me.btnDelAll.Size = New System.Drawing.Size(56, 24)
            Me.btnDelAll.TabIndex = 181
            Me.btnDelAll.TabStop = False
            Me.btnDelAll.Text = "Del All"
            '
            'btnDelOne
            '
            Me.btnDelOne.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelOne.Location = New System.Drawing.Point(184, 8)
            Me.btnDelOne.Name = "btnDelOne"
            Me.btnDelOne.Size = New System.Drawing.Size(64, 24)
            Me.btnDelOne.TabIndex = 180
            Me.btnDelOne.TabStop = False
            Me.btnDelOne.Text = "Del One"
            '
            'txtWHBoxName
            '
            Me.txtWHBoxName.BackColor = System.Drawing.Color.White
            Me.txtWHBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtWHBoxName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWHBoxName.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtWHBoxName.Location = New System.Drawing.Point(16, 32)
            Me.txtWHBoxName.Name = "txtWHBoxName"
            Me.txtWHBoxName.Size = New System.Drawing.Size(264, 22)
            Me.txtWHBoxName.TabIndex = 178
            Me.txtWHBoxName.Text = ""
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.White
            Me.lblBoxName.Location = New System.Drawing.Point(16, 16)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(112, 21)
            Me.lblBoxName.TabIndex = 179
            Me.lblBoxName.Text = "WH Box Name:"
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtOrderQty
            '
            Me.txtOrderQty.BackColor = System.Drawing.Color.Black
            Me.txtOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOrderQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtOrderQty.ForeColor = System.Drawing.Color.Aqua
            Me.txtOrderQty.Location = New System.Drawing.Point(392, 32)
            Me.txtOrderQty.Name = "txtOrderQty"
            Me.txtOrderQty.ReadOnly = True
            Me.txtOrderQty.Size = New System.Drawing.Size(48, 23)
            Me.txtOrderQty.TabIndex = 182
            Me.txtOrderQty.Text = "0"
            Me.txtOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblOrderQty
            '
            Me.lblOrderQty.BackColor = System.Drawing.Color.Transparent
            Me.lblOrderQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.White
            Me.lblOrderQty.Location = New System.Drawing.Point(312, 32)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(80, 21)
            Me.lblOrderQty.TabIndex = 183
            Me.lblOrderQty.Text = "Order Qty:"
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPickLocQty
            '
            Me.txtPickLocQty.BackColor = System.Drawing.Color.Black
            Me.txtPickLocQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPickLocQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPickLocQty.ForeColor = System.Drawing.Color.Aqua
            Me.txtPickLocQty.Location = New System.Drawing.Point(544, 32)
            Me.txtPickLocQty.Name = "txtPickLocQty"
            Me.txtPickLocQty.ReadOnly = True
            Me.txtPickLocQty.Size = New System.Drawing.Size(48, 23)
            Me.txtPickLocQty.TabIndex = 184
            Me.txtPickLocQty.Text = "0"
            Me.txtPickLocQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblPickedQty
            '
            Me.lblPickedQty.BackColor = System.Drawing.Color.Transparent
            Me.lblPickedQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPickedQty.ForeColor = System.Drawing.Color.White
            Me.lblPickedQty.Location = New System.Drawing.Point(448, 32)
            Me.lblPickedQty.Name = "lblPickedQty"
            Me.lblPickedQty.Size = New System.Drawing.Size(96, 21)
            Me.lblPickedQty.TabIndex = 185
            Me.lblPickedQty.Text = "Pick Loc Qty:"
            Me.lblPickedQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnToPickLocation
            '
            Me.btnToPickLocation.BackColor = System.Drawing.Color.Green
            Me.btnToPickLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnToPickLocation.Location = New System.Drawing.Point(456, 520)
            Me.btnToPickLocation.Name = "btnToPickLocation"
            Me.btnToPickLocation.Size = New System.Drawing.Size(168, 56)
            Me.btnToPickLocation.TabIndex = 186
            Me.btnToPickLocation.Text = "To Pick Location"
            '
            'pnlDetails
            '
            Me.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlDetails.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDelOne, Me.txtOrderQty, Me.btnDelAll, Me.txtWHBoxName, Me.tdgProductDetails, Me.txtPickLocQty, Me.lblPickedQty, Me.lblOrderQty, Me.lblBoxName})
            Me.pnlDetails.Location = New System.Drawing.Point(16, 240)
            Me.pnlDetails.Name = "pnlDetails"
            Me.pnlDetails.Size = New System.Drawing.Size(608, 272)
            Me.pnlDetails.TabIndex = 187
            '
            'btnSplitBox
            '
            Me.btnSplitBox.BackColor = System.Drawing.Color.Transparent
            Me.btnSplitBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSplitBox.Location = New System.Drawing.Point(64, 520)
            Me.btnSplitBox.Name = "btnSplitBox"
            Me.btnSplitBox.Size = New System.Drawing.Size(168, 56)
            Me.btnSplitBox.TabIndex = 188
            Me.btnSplitBox.Text = "Split Box"
            '
            'Panel2
            '
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox4, Me.TextBox2, Me.lblPO, Me.TextBox5, Me.Label4, Me.Label3, Me.txtPONumber, Me.TextBox3, Me.Label5, Me.TextBox1, Me.Label1, Me.lstICCID})
            Me.Panel2.Location = New System.Drawing.Point(592, 8)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(64, 48)
            Me.Panel2.TabIndex = 189
            '
            'btnSelectWO
            '
            Me.btnSelectWO.BackColor = System.Drawing.Color.Green
            Me.btnSelectWO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectWO.ForeColor = System.Drawing.Color.White
            Me.btnSelectWO.Location = New System.Drawing.Point(280, 40)
            Me.btnSelectWO.Name = "btnSelectWO"
            Me.btnSelectWO.Size = New System.Drawing.Size(112, 32)
            Me.btnSelectWO.TabIndex = 191
            Me.btnSelectWO.Text = "Select Order"
            '
            'btnRefresh
            '
            Me.btnRefresh.BackColor = System.Drawing.Color.Green
            Me.btnRefresh.ForeColor = System.Drawing.Color.White
            Me.btnRefresh.Location = New System.Drawing.Point(176, 40)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(96, 32)
            Me.btnRefresh.TabIndex = 190
            Me.btnRefresh.Text = "Refresh Order"
            '
            'frmTFFK_Relabel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(672, 646)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSelectWO, Me.btnRefresh, Me.Panel2, Me.btnSplitBox, Me.pnlDetails, Me.btnToPickLocation, Me.lblOpenOrders, Me.tdgData1, Me.Label2, Me.btnRelabel})
            Me.Name = "frmTFFK_Relabel"
            Me.Text = "frmTFFK_Relabel"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgProductDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlDetails.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_Relabel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me.GetData()


                Me.tdgData1.Focus()


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTFFK_Relabel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Finally
                '    Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub GetData()
            Dim ds As New DataSet()
            Try
                ds = Me._objPick.getOpenOrdersForPickData

                Me._dtOrder = ds.Tables("OrderHeader")
                Me._dtOrderDetail = ds.Tables("OrderDetails")

                Me.BindMasterData(Me._dtOrder)


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GetData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub BindMasterData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If dt.Rows.Count > 0 Then
                    With Me.tdgData1
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0
                        '.Splits(0).DisplayColumns("Sku_ID").Width = 0
                        '.Splits(0).DisplayColumns("LineItemNumber").Width = 0
                        '.Splits(0).DisplayColumns("sku_type_decode_id").Width = 0
                        '.Splits(0).DisplayColumns("sku_insert_decode_id").Width = 0
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindMasterData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub BindDetailData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If dt.Rows.Count > 0 Then
                    With Me.tdgProductDetails
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc

                        .Splits(0).DisplayColumns("WH Inv").Button = True
                        .Splits(0).DisplayColumns("WH Inv").ButtonAlways = True
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0
                        '.Splits(0).DisplayColumns("Sku_ID").Width = 0
                        '.Splits(0).DisplayColumns("LineItemNumber").Width = 0
                        '.Splits(0).DisplayColumns("sku_type_decode_id").Width = 0
                        '.Splits(0).DisplayColumns("sku_insert_decode_id").Width = 0
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindDetailData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Me.GetData()

        End Sub

        Private Sub ProcessSelectedWO()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim iRow As Integer = 0
            Dim iSoHeaderID As Integer = 0
            Dim row As DataRow
            Dim foundRows() As DataRow

            Try
                Me.tdgData1.Enabled = True
                'With Me.tdgData1
                '    For Each iRow In .SelectedRows 'must be one row
                '        If Trim(.Columns("Status").CellValue(iRow)).ToString.ToUpper = "Closed".ToUpper Then
                '            MessageBox.Show("Devices for this item '" & .Columns("Status").CellValue(iRow).ToString & "' has be received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '            Exit Sub
                '        End If
                '        strSelectedItem = .Columns("item").CellText(iRow)
                '        Exit For
                '    Next
                'End With


                If Not tdgData1.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row to process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    With Me.tdgData1
                        For Each iRow In .SelectedRows 'must be one row
                            'If Trim(.Columns("Status").CellValue(iRow)).ToString.ToUpper = "Closed".ToUpper Then
                            '    MessageBox.Show("Devices for this item '" & .Columns("Status").CellValue(iRow).ToString & "' has be received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            '    Exit Sub
                            'End If
                            iSoHeaderID = Convert.ToInt32(.Columns("SoHeaderID").CellText(iRow))
                            Exit For
                        Next
                    End With

                    foundRows = Me._dtOrderDetail.Select("[SoHeaderID]=" & iSoHeaderID)
                    If foundRows.Length = 0 Then
                        MessageBox.Show("Failed to get item detail data for the order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Me._dtSelectedOrderDetail = Me._dtOrderDetail.Clone
                        For Each row In foundRows
                            Me._dtSelectedOrderDetail.ImportRow(row)
                        Next

                        If Not Me._dtSelectedOrderDetail.Rows.Count > 0 Then
                            MessageBox.Show("No item detail data for the order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            Me.BindDetailData(Me._dtSelectedOrderDetail)
                            Me.txtOrderQty.Text = Convert.ToInt32(Me.tdgData1.Columns("Order Qty").CellText(iRow))
                            Me.txtPickLocQty.Text = 0
                            Me.txtWHBoxName.SelectAll() : Me.txtWHBoxName.Focus()
                        End If



                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSelectedWO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnSelectWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectWO.Click
            Me.ProcessSelectedWO()
        End Sub


        Private Sub tdgProductDetails_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdgProductDetails.ButtonClick
            Dim iModel_ID As Integer = 0
            Dim dt As DataTable

            Dim rIdx As Integer = 0
            Dim cIdx As Integer = 0
            Dim iQty As Integer = 0
            Dim strQty As String = ""
            Dim iSkid As Integer = 0
            Dim row As DataRow

            Try
                rIdx = Me.tdgData1.Row : cIdx = e.ColIndex
                iModel_ID = Me.tdgProductDetails.Columns("Model_ID").CellText(rIdx)
                dt = Me._objPick.getWHInventoryBoxesData(iModel_ID)

                If dt.Rows.Count > 0 Then
                    Dim fm As New frmTFFK_ItemBoxInvtory(dt)
                    fm.ShowDialog()
                    fm.Dispose()
                Else
                    MessageBox.Show("No available boxes for this item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgProductDetails_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtWHBoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWHBoxName.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtWHBoxName.Text.Trim.Length > 0 Then
                    Me.ProcessBox()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtWHBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessBox()
            Try

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtWHBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
    End Class
End Namespace