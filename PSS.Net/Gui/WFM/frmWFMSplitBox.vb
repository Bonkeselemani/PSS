Namespace Gui.WFMTracfone
    Public Class frmWFMSplitBox
        Inherits System.Windows.Forms.Form

        Private _objAdmin As PSS.Data.Buisness.TracFone.Admin
        Private _objWFMProduce As PSS.Data.Buisness.WFMProduce
        Private _objTFBuildShipPallet As PSS.Data.Buisness.TracFone.BuildShipPallet
        Private _iOldPallettID As Integer = 0
        Private _strScreenName As String = ""
        Private _iCust_ID As Integer = 0
        Private _iOriginalBoxQty As Integer = 0
        Private _iSplitBox1Qty As Integer = 0
        Private _iSplitBox2Qty As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._strScreenName = strScreenName
            Me._iCust_ID = iCust_ID
            Me._objWFMProduce = New PSS.Data.Buisness.WFMProduce()
            Me._objAdmin = New PSS.Data.Buisness.TracFone.Admin()
            Me._objTFBuildShipPallet = New PSS.Data.Buisness.TracFone.BuildShipPallet()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
                Me._objWFMProduce = Nothing
                Me._objAdmin = Nothing
                Me._objTFBuildShipPallet = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents btnClearAllData As System.Windows.Forms.Button
        Friend WithEvents dbgDevicesInBox As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents pbxRightArrow As System.Windows.Forms.PictureBox
        Friend WithEvents pbxLeftArrow As System.Windows.Forms.PictureBox
        Friend WithEvents dbgMovedDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnSplitBox As System.Windows.Forms.Button
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents txtDeviceSNReturn As System.Windows.Forms.TextBox
        Friend WithEvents lblDeviceSNReturn As System.Windows.Forms.Label
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents lblTotalQty As System.Windows.Forms.Label
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWFMSplitBox))
            Me.btnClearAllData = New System.Windows.Forms.Button()
            Me.dbgDevicesInBox = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtBoxName = New System.Windows.Forms.TextBox()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblTotalQty = New System.Windows.Forms.Label()
            Me.txtDeviceSNReturn = New System.Windows.Forms.TextBox()
            Me.lblDeviceSNReturn = New System.Windows.Forms.Label()
            Me.pbxRightArrow = New System.Windows.Forms.PictureBox()
            Me.pbxLeftArrow = New System.Windows.Forms.PictureBox()
            Me.dbgMovedDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.btnSplitBox = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            CType(Me.dbgDevicesInBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.dbgMovedDevices, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnClearAllData
            '
            Me.btnClearAllData.BackColor = System.Drawing.Color.Green
            Me.btnClearAllData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearAllData.ForeColor = System.Drawing.Color.White
            Me.btnClearAllData.Location = New System.Drawing.Point(104, 424)
            Me.btnClearAllData.Name = "btnClearAllData"
            Me.btnClearAllData.Size = New System.Drawing.Size(160, 40)
            Me.btnClearAllData.TabIndex = 130
            Me.btnClearAllData.Text = "Clear All Data"
            '
            'dbgDevicesInBox
            '
            Me.dbgDevicesInBox.AllowUpdate = False
            Me.dbgDevicesInBox.AlternatingRows = True
            Me.dbgDevicesInBox.CaptionHeight = 17
            Me.dbgDevicesInBox.FilterBar = True
            Me.dbgDevicesInBox.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDevicesInBox.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgDevicesInBox.Location = New System.Drawing.Point(40, 80)
            Me.dbgDevicesInBox.Name = "dbgDevicesInBox"
            Me.dbgDevicesInBox.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDevicesInBox.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDevicesInBox.PreviewInfo.ZoomFactor = 75
            Me.dbgDevicesInBox.Size = New System.Drawing.Size(280, 336)
            Me.dbgDevicesInBox.TabIndex = 122
            Me.dbgDevicesInBox.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Con" & _
            "trol;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:" & _
            "None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>332</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 276, 332</ClientRect><B" & _
            "orderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.M" & _
            "ergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Nor" & _
            "mal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading" & _
            """ me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" " & _
            "me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""" & _
            "HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=" & _
            """OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" " & _
            "me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>" & _
            "1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth" & _
            ">17</DefaultRecSelWidth><ClientArea>0, 0, 276, 332</ClientArea><PrintPageHeaderS" & _
            "tyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></B" & _
            "lob>"
            '
            'txtBoxName
            '
            Me.txtBoxName.BackColor = System.Drawing.Color.FloralWhite
            Me.txtBoxName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxName.ForeColor = System.Drawing.Color.Blue
            Me.txtBoxName.Location = New System.Drawing.Point(120, 48)
            Me.txtBoxName.Name = "txtBoxName"
            Me.txtBoxName.Size = New System.Drawing.Size(200, 21)
            Me.txtBoxName.TabIndex = 120
            Me.txtBoxName.Text = ""
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.White
            Me.lblBoxName.Location = New System.Drawing.Point(40, 48)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(80, 19)
            Me.lblBoxName.TabIndex = 119
            Me.lblBoxName.Text = "Box Name:"
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Transparent
            Me.lblScreenName.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.White
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(328, 32)
            Me.lblScreenName.TabIndex = 131
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTotalQty, Me.txtDeviceSNReturn, Me.lblDeviceSNReturn, Me.pbxRightArrow, Me.pbxLeftArrow, Me.dbgMovedDevices, Me.txtDeviceSN, Me.lblDeviceSN, Me.btnSplitBox})
            Me.Panel1.Location = New System.Drawing.Point(328, 32)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(592, 456)
            Me.Panel1.TabIndex = 132
            '
            'lblTotalQty
            '
            Me.lblTotalQty.BackColor = System.Drawing.Color.Transparent
            Me.lblTotalQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalQty.ForeColor = System.Drawing.Color.Black
            Me.lblTotalQty.Location = New System.Drawing.Point(16, 360)
            Me.lblTotalQty.Name = "lblTotalQty"
            Me.lblTotalQty.Size = New System.Drawing.Size(272, 19)
            Me.lblTotalQty.TabIndex = 138
            Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtDeviceSNReturn
            '
            Me.txtDeviceSNReturn.BackColor = System.Drawing.Color.FloralWhite
            Me.txtDeviceSNReturn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceSNReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceSNReturn.ForeColor = System.Drawing.Color.Blue
            Me.txtDeviceSNReturn.Location = New System.Drawing.Point(68, 152)
            Me.txtDeviceSNReturn.Name = "txtDeviceSNReturn"
            Me.txtDeviceSNReturn.Size = New System.Drawing.Size(160, 21)
            Me.txtDeviceSNReturn.TabIndex = 137
            Me.txtDeviceSNReturn.Text = ""
            '
            'lblDeviceSNReturn
            '
            Me.lblDeviceSNReturn.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceSNReturn.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceSNReturn.ForeColor = System.Drawing.Color.White
            Me.lblDeviceSNReturn.Location = New System.Drawing.Point(64, 128)
            Me.lblDeviceSNReturn.Name = "lblDeviceSNReturn"
            Me.lblDeviceSNReturn.Size = New System.Drawing.Size(168, 19)
            Me.lblDeviceSNReturn.TabIndex = 136
            Me.lblDeviceSNReturn.Text = "Device SN to Return"
            Me.lblDeviceSNReturn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pbxRightArrow
            '
            Me.pbxRightArrow.Image = CType(resources.GetObject("pbxRightArrow.Image"), System.Drawing.Bitmap)
            Me.pbxRightArrow.Location = New System.Drawing.Point(232, 52)
            Me.pbxRightArrow.Name = "pbxRightArrow"
            Me.pbxRightArrow.Size = New System.Drawing.Size(32, 32)
            Me.pbxRightArrow.TabIndex = 135
            Me.pbxRightArrow.TabStop = False
            '
            'pbxLeftArrow
            '
            Me.pbxLeftArrow.Image = CType(resources.GetObject("pbxLeftArrow.Image"), System.Drawing.Bitmap)
            Me.pbxLeftArrow.Location = New System.Drawing.Point(32, 148)
            Me.pbxLeftArrow.Name = "pbxLeftArrow"
            Me.pbxLeftArrow.Size = New System.Drawing.Size(32, 40)
            Me.pbxLeftArrow.TabIndex = 134
            Me.pbxLeftArrow.TabStop = False
            '
            'dbgMovedDevices
            '
            Me.dbgMovedDevices.AllowFilter = False
            Me.dbgMovedDevices.AllowUpdate = False
            Me.dbgMovedDevices.AlternatingRows = True
            Me.dbgMovedDevices.CaptionHeight = 17
            Me.dbgMovedDevices.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgMovedDevices.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgMovedDevices.Location = New System.Drawing.Point(292, 56)
            Me.dbgMovedDevices.Name = "dbgMovedDevices"
            Me.dbgMovedDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgMovedDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgMovedDevices.PreviewInfo.ZoomFactor = 75
            Me.dbgMovedDevices.Size = New System.Drawing.Size(280, 336)
            Me.dbgMovedDevices.TabIndex = 133
            Me.dbgMovedDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Con" & _
            "trol;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:" & _
            "None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" Marquee" & _
            "Style=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalSc" & _
            "rollGroup=""1"" HorizontalScrollGroup=""1""><Height>332</Height><CaptionStyle parent" & _
            "=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyl" & _
            "e parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13""" & _
            " /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Sty" & _
            "le12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""" & _
            "HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddR" & _
            "owStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelecto" & _
            "r"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""" & _
            "Normal"" me=""Style1"" /><ClientRect>0, 0, 276, 332</ClientRect><BorderSide>0</Bord" & _
            "erSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits" & _
            "><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading""" & _
            " /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" />" & _
            "<Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><" & _
            "Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><" & _
            "Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style" & _
            " parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" />" & _
            "<Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><ho" & _
            "rzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSe" & _
            "lWidth><ClientArea>0, 0, 276, 332</ClientArea><PrintPageHeaderStyle parent="""" me" & _
            "=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.BackColor = System.Drawing.Color.FloralWhite
            Me.txtDeviceSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceSN.ForeColor = System.Drawing.Color.Blue
            Me.txtDeviceSN.Location = New System.Drawing.Point(68, 56)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(160, 21)
            Me.txtDeviceSN.TabIndex = 132
            Me.txtDeviceSN.Text = ""
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.White
            Me.lblDeviceSN.Location = New System.Drawing.Point(60, 32)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(168, 19)
            Me.lblDeviceSN.TabIndex = 131
            Me.lblDeviceSN.Text = "Device SN to Move"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSplitBox
            '
            Me.btnSplitBox.BackColor = System.Drawing.Color.Crimson
            Me.btnSplitBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSplitBox.ForeColor = System.Drawing.Color.White
            Me.btnSplitBox.Location = New System.Drawing.Point(356, 400)
            Me.btnSplitBox.Name = "btnSplitBox"
            Me.btnSplitBox.Size = New System.Drawing.Size(160, 40)
            Me.btnSplitBox.TabIndex = 130
            Me.btnSplitBox.Text = "Split Box"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.MediumTurquoise
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(328, 0)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(176, 32)
            Me.btnReprintBoxLabel.TabIndex = 133
            Me.btnReprintBoxLabel.Text = "Reprint Box Label"
            '
            'frmWFMSplitBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(936, 542)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.lblScreenName, Me.btnClearAllData, Me.dbgDevicesInBox, Me.txtBoxName, Me.lblBoxName, Me.btnReprintBoxLabel})
            Me.Name = "frmWFMSplitBox"
            Me.Text = "frmWFMSplitBox"
            CType(Me.dbgDevicesInBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.dbgMovedDevices, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWFMSplitBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.lblScreenName.Text = Me._strScreenName
            Me.Panel1.Visible = False
            Me.dbgMovedDevices.DataSource = Nothing
            Me.dbgDevicesInBox.DataSource = Nothing
        End Sub

        Private Sub txtBoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    Dim dt As DataTable
                    Dim row As DataRow
                    Dim iPallettID As Integer = 0
                    Dim strBoxName As String = Me.txtBoxName.Text.Trim

                    Me.Panel1.Visible = False
                    Me.lblTotalQty.Text = ""
                    Me.txtBoxName.Enabled = True

                    If Not strBoxName.Length > 0 Then
                        MessageBox.Show("Please enter a box name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus() : Exit Sub
                    End If

                    dt = Me._objWFMProduce.getNTFPallettDevices(strBoxName, Me._iCust_ID, Me._iOldPallettID)

                    If Not dt.Rows.Count > 0 Then
                        MessageBox.Show(String.Format("Box {0} does not exist (it may be not produced yet or empty box. See IT.", strBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus() : Exit Sub
                    End If

                    If Not Me._iOldPallettID > 0 Then
                        MessageBox.Show(String.Format("Invalid pallet ID. See IT.", strBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus() : Exit Sub
                    End If
                    If Me._objAdmin.BoxHasPackingSlip(Me._iOldPallettID) Then
                        MessageBox.Show(String.Format("Box {0} has been issued a packing slip and cannot be split.", strBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus() : Exit Sub
                    ElseIf Me._objAdmin.BoxHasWorkOrder(Me._iOldPallettID) Then
                        MessageBox.Show(String.Format("Box {0} has been issued a work order and cannot be split.", strBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus() : Exit Sub
                    End If


                    UpdateDevicesInBox(Me.dbgDevicesInBox, dt)

                    Me.Panel1.Visible = True
                    Me.txtBoxName.Enabled = False
                    Me.lblTotalQty.Text = "Original Box Device Qty: " & dt.Rows.Count
                    Me._iOriginalBoxQty = dt.Rows.Count
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub UpdateDevicesInBox(ByVal dbgGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal dt As DataTable, Optional ByVal strGridCaption As String = "")
            Try
                Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
                Dim dv As DataView = dt.DefaultView

                If dt.Rows.Count > 0 Then
                    With dbgGrid
                        If strGridCaption.Trim.Length = 0 Then
                            If dbgGrid.Name.ToUpper = "dbgMovedDevices".ToUpper Then
                                .Caption = "Devices to Transfer to New Box"
                            Else
                                .Caption = String.Format("Devices in Box {0}", Me.txtBoxName.Text.Trim)
                            End If
                        Else
                            .Caption = strGridCaption
                        End If
                        .CaptionStyle.BackColor = Color.LightGoldenrodYellow
                        .CaptionStyle.ForeColor = Color.Green
                        dv.Sort = "Device_SN ASC"
                        .DataSource = dv
                        For Each dbgc In .Splits(0).DisplayColumns : dbgc.Visible = False : Next dbgc
                        .Splits(0).DisplayColumns("Device_SN").Visible = True
                        .Splits(0).DisplayColumns("Device_SN").Width = 120
                        .Splits(0).DisplayColumns("Device_SN").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Extended
                        .ColumnFooters = True
                        .Columns("Device_SN").FooterText = String.Format("Total Devices: {0:#,##0}", .RowCount)
                        .Splits(0).DisplayColumns("Device_SN").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        .FooterStyle.BackColor = Color.LightGoldenrodYellow
                        .FooterStyle.ForeColor = Color.Green
                        For Each dbgc In .Splits(0).DisplayColumns : dbgc.Locked = True : Next dbgc
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub txtDeviceSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    Dim txt As TextBox = DirectCast(sender, TextBox)
                    Dim strSN As String = txt.Text.Trim

                    MoveDevicesTo(strSN)

                    txt.Text = String.Empty
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEI_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub MoveDevicesTo(Optional ByVal strSN As String = "")
            Dim dt As DataTable = Nothing

            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgDevicesInBox
                Dim drv As System.Data.DataRowView
                Dim i As Integer

                With dbg
                    dt = DirectCast(.DataSource, System.Data.DataView).Table()

                    Dim iDevicesRemaining As Integer = dt.Rows.Count

                    If iDevicesRemaining = 1 And .SelectedRows.Count = 1 Then
                        MessageBox.Show("You must leave at least one device in the original box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Exit Sub
                    End If

                    If strSN.Length = 0 Then
                        Dim iSelectedRows(.SelectedRows.Count - 1) As Integer
                        Dim iRow As Integer = -1

                        For i = .SelectedRows.Count - 1 To 0 Step -1
                            iRow += 1
                            iSelectedRows(iRow) = dbg.SelectedRows(i)
                            drv = .Item(dbg.SelectedRows(i))
                            MoveDeviceToNewBox(drv("Device_SN"))
                        Next i

                        For i = 0 To iSelectedRows.GetUpperBound(0) : dt.Rows.RemoveAt(iSelectedRows(i)) : Next i
                    Else
                        If IsSNInGrid(strSN, dbg) Then
                            MoveDeviceToNewBox(strSN)

                            Dim dr As DataRow

                            For Each dr In dt.Rows
                                If dr("Device_SN").ToString().Equals(strSN) Then
                                    dt.Rows.Remove(dr)

                                    Exit For
                                End If
                            Next dr
                        End If
                    End If
                End With

                UpdateDevicesInBox(dbg, dt)
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub MoveDeviceToNewBox(ByVal strSN As String)
            Try
                If strSN.Length = 0 Then
                    MessageBox.Show("Device SN must be a non-empty string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim dbgOldBox As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgDevicesInBox
                    Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgMovedDevices
                    Dim drv As System.Data.DataRowView
                    Dim i As Integer

                    If strSN.Length > 0 Then
                        If dbg.RowCount > 0 Then
                            For i = 0 To dbg.RowCount - 1
                                drv = dbg.Item(i)

                                If drv("device_SN").ToString().Equals(strSN) Then
                                    MessageBox.Show(String.Format("The device SN '{0}' has already been selected for transfer.", strSN), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                End If
                            Next i
                        End If

                        For i = 0 To dbgOldBox.RowCount - 1
                            drv = dbgOldBox.Item(i)

                            If drv("device_SN").ToString().Equals(strSN) Then
                                AddRowToTransfer(drv)
                                Exit Sub
                            End If

                        Next i
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub AddRowToTransfer(ByVal drv As System.Data.DataRowView)
            Dim dt As New DataTable()

            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgMovedDevices
                Dim drNew As DataRow
                Dim i As Integer, iDeviceID As Integer = drv("device_id")
                Dim iRecNum As Integer = 0

                Try
                    iRecNum = dbg.RowCount
                Catch ex As Exception
                End Try

                'If IsNothing(dbg.DataSource) = True OrElse dbg.DataSource = Nothing Then
                If iRecNum = 0 Then
                    dt.Columns.Add(New DataColumn("device_id", System.Type.GetType("System.Int32")))
                    dt.Columns.Add(New DataColumn("Device_SN", System.Type.GetType("System.String")))

                    drNew = dt.NewRow

                    drNew("device_id") = iDeviceID
                    drNew("Device_SN") = drv("Device_SN")

                    dt.Rows.Add(drNew)

                    'With dbg
                    '    .Caption = "Devices to Transfer to New Box"
                    'End With

                    UpdateDevicesInBox(dbg, dt)

                    'Misc.SetGridStyles(Me.dbgMovedDevices, True)
                    'EnableShowMoveToControls(True)
                Else
                    With dbg
                        dt = DirectCast(.DataSource(), System.Data.DataView).Table()

                        drNew = dt.NewRow

                        drNew("device_id") = iDeviceID
                        drNew("Device_SN") = drv("Device_SN")

                        dt.Rows.Add(drNew)
                    End With

                    UpdateDevicesInBox(dbg, dt)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub


        Private Function IsSNInGrid(ByVal strSN As String, ByVal dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As Boolean
            Try
                Dim i As Integer
                Dim bFound As Boolean = False

                For i = 0 To dbg.RowCount - 1
                    Dim drv As System.Data.DataRowView = dbg.Item(i)

                    If drv("Device_SN").ToString.Equals(strSN) Then
                        bFound = True
                        Exit For
                    End If
                Next i

                If Not bFound Then MessageBox.Show(String.Format("Device SN {0} is not in the data.", strSN), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Return bFound
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Sub MoveDevicesFrom(Optional ByVal strSN As String = "")
            Dim dt As DataTable = Nothing

            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgMovedDevices
                Dim drv As System.Data.DataRowView = Nothing
                Dim i As Integer

                With dbg
                    dt = DirectCast(.DataSource(), System.Data.DataView).Table()

                    If strSN.Length = 0 Then
                        Dim iSelectedRows(.SelectedRows.Count - 1) As Integer
                        Dim iRow As Integer = -1

                        For i = .SelectedRows.Count - 1 To 0 Step -1
                            iRow += 1
                            iSelectedRows(iRow) = .SelectedRows(i)
                            drv = .Item(.SelectedRows(i))
                            ReturnDeviceToOriginalBox(drv)
                        Next i

                        For i = 0 To iSelectedRows.GetUpperBound(0) : dt.Rows.RemoveAt(iSelectedRows(i)) : Next i
                    Else
                        If IsSNInGrid(strSN, dbg) Then
                            For i = 0 To .RowCount - 1
                                drv = .Item(i)

                                If drv("device_SN").ToString().Equals(strSN) Then
                                    ReturnDeviceToOriginalBox(drv)
                                    dt.Rows.RemoveAt(i)

                                    Exit For
                                End If
                            Next i
                        End If
                    End If
                End With

                If dt.Rows.Count > 0 Then
                    UpdateDevicesInBox(dbg, dt)
                Else
                    dbg.DataSource = Nothing
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuMoveDevicesToNewBoxClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub ReturnDeviceToOriginalBox(ByVal drv As System.Data.DataRowView)
            Dim dt As DataTable

            Try
                Dim dbgOldBox As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgDevicesInBox
                Dim drNew As DataRow

                With dbgOldBox
                    dt = DirectCast(.DataSource(), System.Data.DataView).Table()

                    drNew = dt.NewRow

                    drNew("device_id") = drv("device_id")
                    drNew("device_SN") = drv("device_SN")

                    dt.Rows.Add(drNew)
                End With

                UpdateDevicesInBox(dbgOldBox, dt)
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub txtDeviceSNReturn_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSNReturn.KeyUp
            Try
                Dim iRecNum As Integer = 0
                Try
                    iRecNum = Me.dbgMovedDevices.RowCount
                Catch ex As Exception
                End Try
                If e.KeyCode = Keys.Enter AndAlso iRecNum > 0 Then
                    Dim txt As TextBox = DirectCast(sender, TextBox)
                    Dim strSN As String = txt.Text.Trim

                    MoveDevicesFrom(strSN)

                    txt.Text = String.Empty
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDeviceIMEI_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSplitBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSplitBox.Click
            Try
                SplitBox()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSplitBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub SplitBox()
            Try
                Dim strOldBoxName As String = Me.txtBoxName.Text.Trim()
                Dim strNewBoxName As String = ""
                Dim strBoxPart As String = ""
                Dim strBoxPart2 As String = ""
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgMovedDevices
                Dim drv As System.Data.DataRowView
                Dim i As Integer
                Dim dt1, dt2 As DataTable

                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                If strOldBoxName.Length = 0 Then
                    MessageBox.Show("Box name must be a non-empty string.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                ElseIf Not Me._objAdmin.BoxExists(Me._iOldPallettID) Then
                    MessageBox.Show(String.Format("A box named '{0}' could not be located in production.tpallett.", strOldBoxName), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Not dbg.RowCount > 0 Then
                    MessageBox.Show("No devices in new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                strBoxPart = Me._objWFMProduce.getPalletNamePart(strOldBoxName, strBoxPart2)

                If strBoxPart.Trim.Length = 0 Then
                    MessageBox.Show("Invalid box name format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                ElseIf strBoxPart2.Trim.Length = 0 OrElse Not IsNumeric(strBoxPart2) Then
                    MessageBox.Show("Invalid box name format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                strNewBoxName = Me._objWFMProduce.getNewPalletName(strBoxPart, strBoxPart2)

                If strNewBoxName.Trim.Length = 0 Then
                    MessageBox.Show("Invalid box name. Exceptional things occured when to create new pallet name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim strDeviceIDsIn As String = String.Empty
                Dim iPallettID As Integer = 0, iMovedQty As Integer = dbg.RowCount

                With dbg
                    Dim iNewPalletID As Integer = Me._objWFMProduce.CreateNewPallet(Me._iOldPallettID, strNewBoxName, .RowCount)

                    If iNewPalletID = 0 Then Throw New Exception("An error occurred when attempting to create a new box.  Please contact IT.")

                    iPallettID = Me._objAdmin.GetBoxID(strNewBoxName, Me._iCust_ID)

                    If iPallettID <= 0 Then Throw New Exception("An error occurred when attempting to retrieve the pallett ID for the new box.  Please contact IT.")
                    If iPallettID <> iNewPalletID Then Throw New Exception("An error occurred when attempting to retrieve the pallett ID for the new box.  Please contact IT.")

                    For i = 0 To .RowCount - 1
                        drv = .Item(i)

                        Dim iDeviceID As Integer = drv("device_id")

                        strDeviceIDsIn &= IIf(strDeviceIDsIn.Length > 0, ", ", String.Empty) & iDeviceID.ToString()
                    Next i
                End With

                If strDeviceIDsIn.Length > 0 Then
                    Me._objAdmin.UpdateDeviceToNewBox(strDeviceIDsIn, iPallettID)
                    Me._objAdmin.UpdateOldBoxQuantity(Me._iOldPallettID, iMovedQty)
                End If

                'qty
                Me._iSplitBox1Qty = Me.dbgDevicesInBox.RowCount
                Me._iSplitBox2Qty = dbg.RowCount

                'validate after changes
                dt1 = Me._objWFMProduce.getPalletDevicesByPalletID(Me._iOldPallettID)
                dt2 = Me._objWFMProduce.getPalletDevicesByPalletID(iPallettID)
                If dt1.Rows.Count > 0 AndAlso dt2.Rows.Count > 0 Then
                    If dt1.Rows.Count = dt1.Rows(0).Item("pallett_qty") AndAlso dt2.Rows.Count = dt2.Rows(0).Item("pallett_qty") _
                       AndAlso dt1.Rows.Count = Me._iSplitBox1Qty AndAlso dt2.Rows.Count = Me._iSplitBox2Qty _
                       AndAlso (dt1.Rows.Count + dt2.Rows.Count) = Me._iOriginalBoxQty _
                       AndAlso Trim(dt1.Rows(0).Item("Pallett_name")).ToUpper = strOldBoxName.Trim.ToUpper _
                       AndAlso Trim(dt2.Rows(0).Item("Pallett_name")).ToUpper = strNewBoxName.Trim.ToUpper Then

                        Me.UpdateDevicesInBox(Me.dbgDevicesInBox, dt1, "First Box: " & strOldBoxName)
                        Me.UpdateDevicesInBox(Me.dbgMovedDevices, dt2, "Second Box : " & strNewBoxName)

                        Me.btnSplitBox.Enabled = False : Me.txtDeviceSN.Enabled = False : Me.txtDeviceSNReturn.Enabled = False
                        MessageBox.Show("Successfully split.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'print labels
                        Me._objTFBuildShipPallet.PrintWFMBoxLabel(dt1)
                        Me._objTFBuildShipPallet.PrintWFMBoxLabel(dt2)
                    Else
                        MessageBox.Show("Failled to split (Qtys are not matched).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Failled to split.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub btnClearAllData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAllData.Click
            Try
                Me._iOldPallettID = 0
                Me._iOriginalBoxQty = 0
                Me._iSplitBox1Qty = 0
                Me._iSplitBox2Qty = 0
                Me.lblTotalQty.Text = ""
                Me.txtBoxName.Text = ""
                Me.txtBoxName.Enabled = True
                Me.dbgDevicesInBox.DataSource = Nothing
                Me.dbgMovedDevices.DataSource = Nothing
                Me.txtDeviceSN.Enabled = True
                Me.txtDeviceSNReturn.Enabled = True
                Me.btnSplitBox.Enabled = True
                Me.dbgDevicesInBox.Caption = ""
                Me.dbgMovedDevices.Caption = ""
                Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearAllData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReprintBoxLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click

            Dim strPalletName As String = ""
            Dim strSN As String = ""
            Dim dt As DataTable

            Try
                Dim result As Integer = MessageBox.Show("By Box name (pallet name) - ""YES"" or By a SN in the box - ""NO""?", "Select", MessageBoxButtons.YesNoCancel)
                'If result = DialogResult.Cancel Then
                '    'No nothing
                'ElseIf result = DialogResult.No Then
                '    MessageBox.Show("No pressed")
                'ElseIf result = DialogResult.Yes Then
                '    strPalletName = InputBox("Enter Box Name.", "Reprint Box Label")
                'End If
                If result = DialogResult.No Then
                    strSN = InputBox("Enter a SN.", "Reprint Box Label")
                    If strSN.Trim.Length > 0 Then
                        dt = Me._objWFMProduce.getPalletDevicesBySN(strSN, Me._iCust_ID)
                        If dt.Rows.Count > 0 Then
                            Me._objTFBuildShipPallet.PrintWFMBoxLabel(dt)
                            If dt.Rows(0).Item("pallett_qty") <> dt.Rows.Count Then
                                MessageBox.Show("WARNING: Device qty is different from qty in the pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            MessageBox.Show("Can't find a box for this SN in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                ElseIf result = DialogResult.Yes Then
                    strPalletName = InputBox("Enter Box Name.", "Reprint Box Label")
                    If strPalletName.Trim.Length > 0 Then
                        dt = Me._objWFMProduce.getPalletDevicesByPalletName(strPalletName, Me._iCust_ID)
                        If dt.Rows.Count > 0 Then
                            Me._objTFBuildShipPallet.PrintWFMBoxLabel(dt)
                            If dt.Rows(0).Item("pallett_qty") <> dt.Rows.Count Then
                                MessageBox.Show("WARNING: Device qty is different from qty in the pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            MessageBox.Show("Can't find this box " & strPalletName & " in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearAllData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub
    End Class
End Namespace
