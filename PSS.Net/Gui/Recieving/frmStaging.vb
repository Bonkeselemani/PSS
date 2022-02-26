Imports PSS.Core
Imports PSS.Data

Namespace Gui.Receiving

    Public Class frmMCstaging
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
        Friend WithEvents txtTrackNum As System.Windows.Forms.TextBox
        Friend WithEvents lblTrackNum As System.Windows.Forms.Label
        Friend WithEvents lblSerialNum As System.Windows.Forms.Label
        Friend WithEvents txtSerialNum As System.Windows.Forms.TextBox
        Friend WithEvents lblCapCode As System.Windows.Forms.Label
        Friend WithEvents txtCapCode As System.Windows.Forms.TextBox
        Friend WithEvents lstProcess As System.Windows.Forms.ListBox
        Friend WithEvents lblNewDeviceNum As System.Windows.Forms.Label
        Friend WithEvents txtNewDeviceNum As System.Windows.Forms.TextBox
        Friend WithEvents Line1 As System.Windows.Forms.Label
        Friend WithEvents Line2 As System.Windows.Forms.Label
        Friend WithEvents btnContinue As System.Windows.Forms.Button
        Friend WithEvents lblMessage As System.Windows.Forms.Label
        Friend WithEvents tabData As System.Windows.Forms.TabPage
        Friend WithEvents tabSearch As System.Windows.Forms.TabPage
        Friend WithEvents tabRemove As System.Windows.Forms.TabPage
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        Friend WithEvents lblBagAndTag As System.Windows.Forms.Label
        Friend WithEvents txtRemoveSerial As System.Windows.Forms.TextBox
        Friend WithEvents tabCtrl As System.Windows.Forms.TabControl
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents lblWO As System.Windows.Forms.Label
        Friend WithEvents txtWO As System.Windows.Forms.TextBox
        Friend WithEvents deviceGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents deviceGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents valCount As System.Windows.Forms.Label
        Friend WithEvents btnInsert As System.Windows.Forms.Button
        Friend WithEvents cboCustomer1 As System.Windows.Forms.ComboBox
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboLocation As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboLocation1 As System.Windows.Forms.ComboBox
        Friend WithEvents lblRCount As System.Windows.Forms.Label
        Friend WithEvents valRCount As System.Windows.Forms.Label
        Friend WithEvents capGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMCstaging))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Dim GridLines2 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Dim GridLines3 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblTrackNum = New System.Windows.Forms.Label()
            Me.txtTrackNum = New System.Windows.Forms.TextBox()
            Me.lblSerialNum = New System.Windows.Forms.Label()
            Me.txtSerialNum = New System.Windows.Forms.TextBox()
            Me.lblCapCode = New System.Windows.Forms.Label()
            Me.txtCapCode = New System.Windows.Forms.TextBox()
            Me.lstProcess = New System.Windows.Forms.ListBox()
            Me.lblNewDeviceNum = New System.Windows.Forms.Label()
            Me.txtNewDeviceNum = New System.Windows.Forms.TextBox()
            Me.Line1 = New System.Windows.Forms.Label()
            Me.Line2 = New System.Windows.Forms.Label()
            Me.lblMessage = New System.Windows.Forms.Label()
            Me.btnContinue = New System.Windows.Forms.Button()
            Me.tabCtrl = New System.Windows.Forms.TabControl()
            Me.tabData = New System.Windows.Forms.TabPage()
            Me.capGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.valRCount = New System.Windows.Forms.Label()
            Me.lblRCount = New System.Windows.Forms.Label()
            Me.cboLocation = New PSS.Gui.Controls.ComboBox()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.btnInsert = New System.Windows.Forms.Button()
            Me.valCount = New System.Windows.Forms.Label()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.deviceGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtWO = New System.Windows.Forms.TextBox()
            Me.cboLocation1 = New System.Windows.Forms.ComboBox()
            Me.cboCustomer1 = New System.Windows.Forms.ComboBox()
            Me.lblWO = New System.Windows.Forms.Label()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.lblBagAndTag = New System.Windows.Forms.Label()
            Me.tabRemove = New System.Windows.Forms.TabPage()
            Me.btnRemove = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtRemoveSerial = New System.Windows.Forms.TextBox()
            Me.tabSearch = New System.Windows.Forms.TabPage()
            Me.deviceGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tabCtrl.SuspendLayout()
            Me.tabData.SuspendLayout()
            CType(Me.capGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.deviceGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabRemove.SuspendLayout()
            Me.tabSearch.SuspendLayout()
            CType(Me.deviceGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTrackNum
            '
            Me.lblTrackNum.Location = New System.Drawing.Point(136, 88)
            Me.lblTrackNum.Name = "lblTrackNum"
            Me.lblTrackNum.Size = New System.Drawing.Size(100, 16)
            Me.lblTrackNum.TabIndex = 0
            Me.lblTrackNum.Text = "Tracking Number:"
            Me.lblTrackNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTrackNum
            '
            Me.txtTrackNum.Location = New System.Drawing.Point(248, 88)
            Me.txtTrackNum.Name = "txtTrackNum"
            Me.txtTrackNum.Size = New System.Drawing.Size(144, 20)
            Me.txtTrackNum.TabIndex = 3
            Me.txtTrackNum.Text = ""
            '
            'lblSerialNum
            '
            Me.lblSerialNum.Location = New System.Drawing.Point(248, 136)
            Me.lblSerialNum.Name = "lblSerialNum"
            Me.lblSerialNum.Size = New System.Drawing.Size(100, 16)
            Me.lblSerialNum.TabIndex = 2
            Me.lblSerialNum.Text = "Serial Number:"
            Me.lblSerialNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSerialNum
            '
            Me.txtSerialNum.Location = New System.Drawing.Point(360, 136)
            Me.txtSerialNum.Name = "txtSerialNum"
            Me.txtSerialNum.TabIndex = 4
            Me.txtSerialNum.Text = ""
            '
            'lblCapCode
            '
            Me.lblCapCode.Location = New System.Drawing.Point(248, 160)
            Me.lblCapCode.Name = "lblCapCode"
            Me.lblCapCode.Size = New System.Drawing.Size(100, 16)
            Me.lblCapCode.TabIndex = 4
            Me.lblCapCode.Text = "CAP Code:"
            Me.lblCapCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCapCode
            '
            Me.txtCapCode.Location = New System.Drawing.Point(360, 160)
            Me.txtCapCode.Name = "txtCapCode"
            Me.txtCapCode.TabIndex = 5
            Me.txtCapCode.Text = ""
            '
            'lstProcess
            '
            Me.lstProcess.BackColor = System.Drawing.SystemColors.Control
            Me.lstProcess.Location = New System.Drawing.Point(400, 88)
            Me.lstProcess.Name = "lstProcess"
            Me.lstProcess.Size = New System.Drawing.Size(64, 17)
            Me.lstProcess.TabIndex = 6
            Me.lstProcess.Visible = False
            '
            'lblNewDeviceNum
            '
            Me.lblNewDeviceNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNewDeviceNum.Location = New System.Drawing.Point(16, 240)
            Me.lblNewDeviceNum.Name = "lblNewDeviceNum"
            Me.lblNewDeviceNum.Size = New System.Drawing.Size(200, 23)
            Me.lblNewDeviceNum.TabIndex = 7
            Me.lblNewDeviceNum.Text = "DEVICE SERIAL NUMBER:"
            '
            'txtNewDeviceNum
            '
            Me.txtNewDeviceNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtNewDeviceNum.Location = New System.Drawing.Point(224, 240)
            Me.txtNewDeviceNum.Name = "txtNewDeviceNum"
            Me.txtNewDeviceNum.Size = New System.Drawing.Size(240, 24)
            Me.txtNewDeviceNum.TabIndex = 8
            Me.txtNewDeviceNum.Text = ""
            '
            'Line1
            '
            Me.Line1.BackColor = System.Drawing.Color.Blue
            Me.Line1.Location = New System.Drawing.Point(16, 224)
            Me.Line1.Name = "Line1"
            Me.Line1.Size = New System.Drawing.Size(448, 8)
            Me.Line1.TabIndex = 9
            '
            'Line2
            '
            Me.Line2.BackColor = System.Drawing.Color.Blue
            Me.Line2.Location = New System.Drawing.Point(16, 272)
            Me.Line2.Name = "Line2"
            Me.Line2.Size = New System.Drawing.Size(448, 8)
            Me.Line2.TabIndex = 10
            '
            'lblMessage
            '
            Me.lblMessage.BackColor = System.Drawing.Color.Red
            Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMessage.ForeColor = System.Drawing.Color.White
            Me.lblMessage.Location = New System.Drawing.Point(16, 288)
            Me.lblMessage.Name = "lblMessage"
            Me.lblMessage.Size = New System.Drawing.Size(368, 23)
            Me.lblMessage.TabIndex = 11
            Me.lblMessage.Visible = False
            '
            'btnContinue
            '
            Me.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnContinue.Location = New System.Drawing.Point(392, 288)
            Me.btnContinue.Name = "btnContinue"
            Me.btnContinue.TabIndex = 6
            Me.btnContinue.Text = "Continue"
            '
            'tabCtrl
            '
            Me.tabCtrl.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabData, Me.tabRemove, Me.tabSearch})
            Me.tabCtrl.Location = New System.Drawing.Point(8, 16)
            Me.tabCtrl.Name = "tabCtrl"
            Me.tabCtrl.SelectedIndex = 0
            Me.tabCtrl.Size = New System.Drawing.Size(752, 344)
            Me.tabCtrl.TabIndex = 13
            Me.tabCtrl.TabStop = False
            '
            'tabData
            '
            Me.tabData.Controls.AddRange(New System.Windows.Forms.Control() {Me.capGrid, Me.valRCount, Me.lblRCount, Me.cboLocation, Me.cboCustomer, Me.btnInsert, Me.valCount, Me.lblCount, Me.deviceGrid, Me.txtWO, Me.cboLocation1, Me.cboCustomer1, Me.lblWO, Me.lblLocation, Me.lblCustomer, Me.lblBagAndTag, Me.lblSerialNum, Me.txtSerialNum, Me.lstProcess, Me.btnContinue, Me.lblTrackNum, Me.txtTrackNum, Me.lblNewDeviceNum, Me.txtCapCode, Me.lblMessage, Me.txtNewDeviceNum, Me.Line2, Me.lblCapCode, Me.Line1})
            Me.tabData.Location = New System.Drawing.Point(4, 22)
            Me.tabData.Name = "tabData"
            Me.tabData.Size = New System.Drawing.Size(744, 318)
            Me.tabData.TabIndex = 0
            Me.tabData.Text = "Data Submission"
            '
            'capGrid
            '
            Me.capGrid.AllowDelete = True
            Me.capGrid.AllowFilter = True
            Me.capGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.capGrid.AllowSort = True
            Me.capGrid.AlternatingRows = True
            Me.capGrid.CaptionHeight = 17
            Me.capGrid.CollapseColor = System.Drawing.Color.Black
            Me.capGrid.DataChanged = False
            Me.capGrid.BackColor = System.Drawing.Color.Empty
            Me.capGrid.ExpandColor = System.Drawing.Color.Black
            Me.capGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.capGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.capGrid.Location = New System.Drawing.Point(16, 184)
            Me.capGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.capGrid.Name = "capGrid"
            Me.capGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.capGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.capGrid.PreviewInfo.ZoomFactor = 75
            Me.capGrid.PrintInfo.ShowOptionsDialog = False
            Me.capGrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.capGrid.RowDivider = GridLines1
            Me.capGrid.RowHeight = 15
            Me.capGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.capGrid.ScrollTips = False
            Me.capGrid.Size = New System.Drawing.Size(448, 96)
            Me.capGrid.TabIndex = 26
            Me.capGrid.Text = "C1TrueDBGrid1"
            Me.capGrid.Visible = False
            Me.capGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style9{}Od" & _
            "dRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Borde" & _
            "r:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{Al" & _
            "ignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win" & _
            ".C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Co" & _
            "lumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" R" & _
            "ecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalSc" & _
            "rollGroup=""1""><ClientRect>0, 0, 444, 92</ClientRect><BorderSide>0</BorderSide><C" & _
            "aptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Styl" & _
            "e5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filte" & _
            "rBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle pare" & _
            "nt=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLigh" & _
            "tRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" m" & _
            "e=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle par" & _
            "ent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6""" & _
            " /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits" & _
            "><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading""" & _
            " /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" />" & _
            "<Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><" & _
            "Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><" & _
            "Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style" & _
            " parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" />" & _
            "<Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><ho" & _
            "rzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSe" & _
            "lWidth><ClientArea>0, 0, 444, 92</ClientArea></Blob>"
            '
            'valRCount
            '
            Me.valRCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.valRCount.Location = New System.Drawing.Point(184, 128)
            Me.valRCount.Name = "valRCount"
            Me.valRCount.Size = New System.Drawing.Size(80, 48)
            Me.valRCount.TabIndex = 25
            Me.valRCount.Text = "0"
            Me.valRCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblRCount
            '
            Me.lblRCount.Location = New System.Drawing.Point(176, 112)
            Me.lblRCount.Name = "lblRCount"
            Me.lblRCount.Size = New System.Drawing.Size(88, 16)
            Me.lblRCount.TabIndex = 24
            Me.lblRCount.Text = "REJECT"
            Me.lblRCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboLocation
            '
            Me.cboLocation.AutoComplete = True
            Me.cboLocation.Location = New System.Drawing.Point(120, 32)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(272, 21)
            Me.cboLocation.TabIndex = 1
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.Location = New System.Drawing.Point(120, 8)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(272, 21)
            Me.cboCustomer.TabIndex = 0
            '
            'btnInsert
            '
            Me.btnInsert.Location = New System.Drawing.Point(472, 288)
            Me.btnInsert.Name = "btnInsert"
            Me.btnInsert.Size = New System.Drawing.Size(264, 23)
            Me.btnInsert.TabIndex = 6
            Me.btnInsert.Text = "INSERT"
            '
            'valCount
            '
            Me.valCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.valCount.Location = New System.Drawing.Point(88, 128)
            Me.valCount.Name = "valCount"
            Me.valCount.Size = New System.Drawing.Size(80, 48)
            Me.valCount.TabIndex = 22
            Me.valCount.Text = "0"
            Me.valCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCount
            '
            Me.lblCount.Location = New System.Drawing.Point(80, 112)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(88, 16)
            Me.lblCount.TabIndex = 21
            Me.lblCount.Text = "COUNT"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'deviceGrid
            '
            Me.deviceGrid.AllowDelete = True
            Me.deviceGrid.AllowFilter = True
            Me.deviceGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.deviceGrid.AllowSort = True
            Me.deviceGrid.AlternatingRows = True
            Me.deviceGrid.CaptionHeight = 17
            Me.deviceGrid.CollapseColor = System.Drawing.Color.Black
            Me.deviceGrid.DataChanged = False
            Me.deviceGrid.BackColor = System.Drawing.Color.Empty
            Me.deviceGrid.ExpandColor = System.Drawing.Color.Black
            Me.deviceGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.deviceGrid.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.deviceGrid.Location = New System.Drawing.Point(472, 8)
            Me.deviceGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.deviceGrid.Name = "deviceGrid"
            Me.deviceGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.deviceGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.deviceGrid.PreviewInfo.ZoomFactor = 75
            Me.deviceGrid.PrintInfo.ShowOptionsDialog = False
            Me.deviceGrid.RecordSelectorWidth = 16
            GridLines2.Color = System.Drawing.Color.DarkGray
            GridLines2.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.deviceGrid.RowDivider = GridLines2
            Me.deviceGrid.RowHeight = 15
            Me.deviceGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.deviceGrid.ScrollTips = False
            Me.deviceGrid.Size = New System.Drawing.Size(264, 272)
            Me.deviceGrid.TabIndex = 20
            Me.deviceGrid.Text = "C1TrueDBGrid1"
            Me.deviceGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}Od" & _
            "dRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Control;Bord" & _
            "er:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{Al" & _
            "ignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win" & _
            ".C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Co" & _
            "lumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" R" & _
            "ecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalSc" & _
            "rollGroup=""1""><ClientRect>0, 0, 260, 268</ClientRect><BorderSide>0</BorderSide><" & _
            "CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Sty" & _
            "le5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filt" & _
            "erBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle par" & _
            "ent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLig" & _
            "htRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" " & _
            "me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pa" & _
            "rent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6" & _
            """ /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecS" & _
            "elWidth><ClientArea>0, 0, 260, 268</ClientArea></Blob>"
            '
            'txtWO
            '
            Me.txtWO.Location = New System.Drawing.Point(120, 56)
            Me.txtWO.Name = "txtWO"
            Me.txtWO.Size = New System.Drawing.Size(144, 20)
            Me.txtWO.TabIndex = 2
            Me.txtWO.Text = ""
            '
            'cboLocation1
            '
            Me.cboLocation1.Location = New System.Drawing.Point(16, 144)
            Me.cboLocation1.Name = "cboLocation1"
            Me.cboLocation1.Size = New System.Drawing.Size(48, 21)
            Me.cboLocation1.TabIndex = 18
            Me.cboLocation1.Visible = False
            '
            'cboCustomer1
            '
            Me.cboCustomer1.Location = New System.Drawing.Point(16, 120)
            Me.cboCustomer1.Name = "cboCustomer1"
            Me.cboCustomer1.Size = New System.Drawing.Size(48, 21)
            Me.cboCustomer1.TabIndex = 17
            Me.cboCustomer1.Visible = False
            '
            'lblWO
            '
            Me.lblWO.Location = New System.Drawing.Point(8, 56)
            Me.lblWO.Name = "lblWO"
            Me.lblWO.Size = New System.Drawing.Size(104, 16)
            Me.lblWO.TabIndex = 16
            Me.lblWO.Text = "WorkOrder:"
            Me.lblWO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLocation
            '
            Me.lblLocation.Location = New System.Drawing.Point(8, 32)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(104, 16)
            Me.lblLocation.TabIndex = 15
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(8, 8)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(104, 16)
            Me.lblCustomer.TabIndex = 14
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBagAndTag
            '
            Me.lblBagAndTag.BackColor = System.Drawing.Color.LightYellow
            Me.lblBagAndTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBagAndTag.Location = New System.Drawing.Point(16, 184)
            Me.lblBagAndTag.Name = "lblBagAndTag"
            Me.lblBagAndTag.Size = New System.Drawing.Size(448, 32)
            Me.lblBagAndTag.TabIndex = 13
            Me.lblBagAndTag.Text = "This item needs to be bagged and tagged. Please use the new device serial number " & _
            "listed below."
            Me.lblBagAndTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'tabRemove
            '
            Me.tabRemove.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRemove, Me.Label1, Me.txtRemoveSerial})
            Me.tabRemove.Location = New System.Drawing.Point(4, 22)
            Me.tabRemove.Name = "tabRemove"
            Me.tabRemove.Size = New System.Drawing.Size(744, 318)
            Me.tabRemove.TabIndex = 2
            Me.tabRemove.Text = "Remove"
            '
            'btnRemove
            '
            Me.btnRemove.Location = New System.Drawing.Point(232, 80)
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.Size = New System.Drawing.Size(224, 23)
            Me.btnRemove.TabIndex = 6
            Me.btnRemove.Text = "Remove This Itrem From Staging"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(32, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(144, 16)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "Serial Number (REMOVE):"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRemoveSerial
            '
            Me.txtRemoveSerial.Location = New System.Drawing.Point(184, 32)
            Me.txtRemoveSerial.Name = "txtRemoveSerial"
            Me.txtRemoveSerial.TabIndex = 5
            Me.txtRemoveSerial.Text = ""
            '
            'tabSearch
            '
            Me.tabSearch.Controls.AddRange(New System.Windows.Forms.Control() {Me.deviceGrid1})
            Me.tabSearch.Location = New System.Drawing.Point(4, 22)
            Me.tabSearch.Name = "tabSearch"
            Me.tabSearch.Size = New System.Drawing.Size(744, 318)
            Me.tabSearch.TabIndex = 1
            Me.tabSearch.Text = "Search"
            '
            'deviceGrid1
            '
            Me.deviceGrid1.AllowAddNew = True
            Me.deviceGrid1.AllowFilter = True
            Me.deviceGrid1.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.deviceGrid1.AllowSort = True
            Me.deviceGrid1.AlternatingRows = True
            Me.deviceGrid1.CaptionHeight = 17
            Me.deviceGrid1.CollapseColor = System.Drawing.Color.Black
            Me.deviceGrid1.DataChanged = False
            Me.deviceGrid1.BackColor = System.Drawing.Color.Empty
            Me.deviceGrid1.ExpandColor = System.Drawing.Color.Black
            Me.deviceGrid1.GroupByCaption = "Drag a column header here to group by that column"
            Me.deviceGrid1.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.deviceGrid1.Location = New System.Drawing.Point(16, 24)
            Me.deviceGrid1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.deviceGrid1.Name = "deviceGrid1"
            Me.deviceGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.deviceGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.deviceGrid1.PreviewInfo.ZoomFactor = 75
            Me.deviceGrid1.PrintInfo.ShowOptionsDialog = False
            Me.deviceGrid1.RecordSelectorWidth = 16
            GridLines3.Color = System.Drawing.Color.DarkGray
            GridLines3.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.deviceGrid1.RowDivider = GridLines3
            Me.deviceGrid1.RowHeight = 15
            Me.deviceGrid1.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.deviceGrid1.ScrollTips = False
            Me.deviceGrid1.Size = New System.Drawing.Size(448, 136)
            Me.deviceGrid1.TabIndex = 0
            Me.deviceGrid1.Text = "C1TrueDBGrid1"
            Me.deviceGrid1.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Level=""0"" Caption=""Serial Numb" & _
            "er"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Caption=""C" & _
            "AP Code"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Capti" & _
            "on=""DateStaged"" DataField=""""><ValueItems /></C1DataColumn></DataCols><Styles typ" & _
            "e=""C1.Win.C1TrueDBGrid.Design.ContextWrapper""><Data>Caption{AlignHorz:Center;}No" & _
            "rmal{}Style25{}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Sty" & _
            "le18{AlignHorz:Near;}Style19{AlignHorz:Near;}Style14{AlignHorz:Near;}Style15{Ali" & _
            "gnHorz:Near;}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{}Style13{" & _
            "}Style12{}Footer{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Reco" & _
            "rdSelector{AlignImage:Center;}Style24{}Style23{AlignHorz:Near;}Style22{AlignHorz" & _
            ":Near;}Style21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:Inacti" & _
            "veCaption;}EvenRow{BackColor:Aqua;}Heading{Wrap:True;AlignVert:Center;Border:Rai" & _
            "sed,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{}Style4{}Styl" & _
            "e9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVer" & _
            "t:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Wi" & _
            "n.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" C" & _
            "olumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" " & _
            "RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalS" & _
            "crollGroup=""1""><ClientRect>0, 0, 444, 132</ClientRect><BorderSide>0</BorderSide>" & _
            "<CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""St" & _
            "yle5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Fil" & _
            "terBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle pa" & _
            "rent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLi" & _
            "ghtRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive""" & _
            " me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle p" & _
            "arent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style" & _
            "6"" /><Style parent=""Normal"" me=""Style1"" /><internalCols><C1DisplayColumn><Headin" & _
            "gStyle parent=""Style2"" me=""Style14"" /><Style parent=""Style1"" me=""Style15"" /><Foo" & _
            "terStyle parent=""Style3"" me=""Style16"" /><EditorStyle parent=""Style5"" me=""Style17" & _
            """ /><Visible>True</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Height" & _
            ">15</Height><DCIdx>0</DCIdx></C1DisplayColumn><C1DisplayColumn><HeadingStyle par" & _
            "ent=""Style2"" me=""Style18"" /><Style parent=""Style1"" me=""Style19"" /><FooterStyle p" & _
            "arent=""Style3"" me=""Style20"" /><EditorStyle parent=""Style5"" me=""Style21"" /><Visib" & _
            "le>True</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Heigh" & _
            "t><DCIdx>1</DCIdx></C1DisplayColumn><C1DisplayColumn><HeadingStyle parent=""Style" & _
            "2"" me=""Style22"" /><Style parent=""Style1"" me=""Style23"" /><FooterStyle parent=""Sty" & _
            "le3"" me=""Style24"" /><EditorStyle parent=""Style5"" me=""Style25"" /><Visible>True</V" & _
            "isible><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>2" & _
            "</DCIdx></C1DisplayColumn></internalCols></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</Default" & _
            "RecSelWidth><ClientArea>0, 0, 444, 132</ClientArea></Blob>"
            '
            'frmMCstaging
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(800, 589)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabCtrl})
            Me.Name = "frmMCstaging"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Receiving Staging"
            Me.tabCtrl.ResumeLayout(False)
            Me.tabData.ResumeLayout(False)
            CType(Me.capGrid, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.deviceGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabRemove.ResumeLayout(False)
            Me.tabSearch.ResumeLayout(False)
            CType(Me.deviceGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private vStatus As String
        Private vStatusNum As Integer
        Private dataGrid As DataTable
        Private dataCAPgrid As DataTable
        Private vDateStaged As String
        Private dtCustomer As DataTable
        Private dtLocation As DataTable
        Private intLocation, intCustomer, intWO, vCount, rCount As Int32
        Private VALdeviceGrid As String
        Public intStageType As Integer
        Private dtGridMain As DataTable
        Private capMulti As Boolean

        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim mnuFileMenu As New MainMenu()
            Me.Menu = mnuFileMenu
            mnuFileMenu.MenuItems.Add("File")
            valCount.Text = 0
            valRCount.Text = 0
            vCount = 0
            rCount = 0
            resetPage() '//Initialize all objects for initial input
            txtSerialNum.Visible = False
            createDataGrid()
            populateCustomers()
            System.Windows.Forms.Application.DoEvents()
            capGrid.Visible = False

            Dim xCount As Integer
            Dim r As DataRow

            intCustomer = 0

            For xCount = 0 To dtCustomer.Rows.Count - 1
                r = dtCustomer.Rows(xCount)
                If Trim(r("Cust_Name1")) = Trim("Metrocall") Then
                    intCustomer = r("Cust_ID")
                    cboCustomer.Text = r("Cust_Name1")
                    Exit For
                End If
            Next

            populateLocations()
            System.Windows.Forms.Application.DoEvents()

            intLocation = 0

            For xCount = 0 To dtLocation.Rows.Count - 1
                r = dtLocation.Rows(xCount)
                If Trim(r("Loc_Name")) = Trim("MCEU01") Then
                    intLocation = r("Loc_ID")
                    cboLocation.Text = r("Loc_Name")
                    Exit For
                End If
            Next

            'txtWO.Focus()
            intWO = 0
            'lblSerialNum.Visible = True
            'txtSerialNum.Visible = True
            'txtSerialNum.Focus()
            txtWO.Text = "MCEU-" & PSS.Gui.Receiving.General.FormatDateShort(Now)
            '//get Workorder if exists
            Try
                determineWOID(intLocation, txtWO.Text)
            Catch
            End Try
            txtTrackNum.Focus()

        End Sub


        



        Private Sub determineWOID(ByVal intLoc, ByVal txtWO)

            Dim dWO As New PSS.Data.Production.tworkorder()
            Dim dtWO As DataRow = dWO.GetRowByCustDesc(intLoc, txtWO)
            Try
                If IsDBNull(dtWO("WO_ID")) = False Then
                    intWO = dtWO("WO_ID")
                End If
            Catch
            End Try

        End Sub


        Private Sub populateCustomers()

            Try
                cboCustomer.Items.Clear()
            Catch ex As Exception
            End Try

            Dim tblCust As New PSS.Data.Production.Joins()
            Dim dtCust As DataTable = tblCust.GenericSelect("SELECT DISTINCT tcustomer.cust_ID, tcustomer.cust_name1 from (tcustomer INNER JOIN tlocation On tcustomer.cust_id = tlocation.cust_id) WHERE tcustomer.cust_stage =1")

            Dim xcount As Integer = 0
            Dim r As DataRow
            For xcount = 0 To dtCust.Rows.Count - 1
                r = dtCust.Rows(xcount)
                cboCustomer.Items.Add(r("Cust_Name1"))
            Next

            dtCustomer = dtCust
            dtCust.Dispose()
            dtCust = Nothing

        End Sub

        Private Sub populateLocations()

            Try
                cboLocation.Items.Clear()
            Catch ex As Exception
            End Try

            Dim tblLoc As New PSS.Data.Production.Joins()
            Dim dtLoc As DataTable = tblLoc.GenericSelect("SELECT loc_name, loc_id FROM tlocation WHERE tlocation.cust_id =" & intCustomer)

            Dim xcount As Integer = 0
            Dim r As DataRow
            For xcount = 0 To dtLoc.Rows.Count - 1
                r = dtLoc.Rows(xcount)
                cboLocation.Items.Add(r("Loc_Name"))
            Next

            dtLocation = dtLoc
            dtLoc.Dispose()
            dtLoc = Nothing

        End Sub



#Region " Page/Form Actions "

        Private Sub resetPage()
            txtTrackNum.Text = ""
            lblSerialNum.Visible = False
            txtSerialNum.Text = ""
            lblCapCode.Visible = False
            txtCapCode.Visible = False
            txtCapCode.Text = ""
            lblMessage.Visible = False
            lblNewDeviceNum.Visible = False
            txtNewDeviceNum.Visible = False
            lblBagAndTag.Visible = False
            Line1.Visible = False
            Line2.Visible = False
            btnContinue.Visible = False
            lstProcess.Items.Clear()
            vStatus = ""
            vStatusNum = 0
            vDateStaged = ""
            'intCustomer = 0
            'intLocation = 0
            txtTrackNum.Focus()
        End Sub

        Private Sub visSerialNum()
            lblSerialNum.Visible = True
            txtSerialNum.Visible = True
        End Sub

        Private Sub visCapCode()
            lblCapCode.Visible = True
            txtCapCode.Visible = True
        End Sub

        Private Sub writeTransaction()

            If vStatusNum = 2 Then txtSerialNum.Text = txtNewDeviceNum.Text

            '//COMMENTED OUT 2-24-2004 By Craig Haney causing duplicate records for status 2 and 3 items
            '//Insert Data Into table tmetrodetail
            'Dim insertRec As New PSS.Data.Production.tmetrocalldetail()
            'Dim dtStage As String = Now
            'Dim blnInsert As Boolean = insertRec.InsertDataRow(txtSerialNum.Text, txtTrackNum.Text, vStatusNum, Gui.Receiving.General.FormatDate(dtStage))

            'If blnInsert = False Then
            'MsgBox("The record could not be inserted.", MsgBoxStyle.OKOnly, "ERROR Inserting")
            'txtTrackNum.Focus()
            'Exit Sub
            'Else
                '//Write record to grid
                addRowDataGrid()
            'End If
            '//COMMENTED OUT 2-24-2004 By Craig Haney causing duplicate records for status 2 and 3 items

            'resetPage()

            txtSerialNum.Text = ""
            lblCapCode.Visible = False
            txtCapCode.Visible = False
            txtCapCode.Text = ""
            lblMessage.Visible = False
            lblNewDeviceNum.Visible = False
            txtNewDeviceNum.Visible = False
            lblBagAndTag.Visible = False
            Line1.Visible = False
            Line2.Visible = False
            btnContinue.Visible = False
            vStatus = ""
            vStatusNum = 0
            vDateStaged = ""
            'intCustomer = 0
            'intLocation = 0
            txtSerialNum.Focus()

        End Sub

        Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

            If vStatusNum < 3 Then
                writeTransaction()
                vCount += 1
                valCount.Text = vCount
            Else
                writeTransaction()
                rCount += 1
                valRCount.Text = rCount
                txtSerialNum.Text = ""
                lblCapCode.Visible = False
                txtCapCode.Visible = False
                txtCapCode.Text = ""
                lblMessage.Visible = False
                lblNewDeviceNum.Visible = False
                txtNewDeviceNum.Visible = False
                lblBagAndTag.Visible = False
                Line1.Visible = False
                Line2.Visible = False
                btnContinue.Visible = False
                vStatus = ""
                vStatusNum = 0
                vDateStaged = ""
                txtSerialNum.Focus()
            End If

        End Sub

#End Region

#Region " Verify Data "

        Private Sub verifyTrackingNumber(ByVal valTrackNum As String)

            lstProcess.Items.Add("Verifying Valid Tracking Number.....")

            txtTrackNum.Text = Trim(txtTrackNum.Text)

            If Len(Trim(valTrackNum)) < 1 Then
                txtTrackNum.Text = "USPS"
            Else
                '//Place any business logic to validate the tracking number here
                '//if failure of validation - process here and then exit sub
            End If

            lstProcess.Items.Add("Tracking Number Valid")
            '//Proceed to Serial Number
            'visSerialNum()
            'txtSerialNum.Focus()

        End Sub

        Private Sub verifySerialNumber(ByVal valSerialNum As String)

            Dim validateSerial As Boolean

            lstProcess.Items.Add("Verifying Valid Serial Number.....")

            If Len(Trim(valSerialNum)) < 1 Then
                visCapCode()
                txtCapCode.Focus()
                Exit Sub
            Else
                '//Place any business logic to validate the serial number here
                '//if failure of validation - process here and then exit sub
                validateSerial = validateSerialNumber2DB(valSerialNum)
                If validateSerial = False Then
                    '//Reorder to cap code if serial number is not in data file from Metrocall
                    visCapCode()
                    txtCapCode.Focus()
                    Exit Sub
                Else

                    Dim blnCheck As Boolean = checkDuplicate(txtSerialNum.Text, intWO)
                    If blnCheck = True Then
                        txtSerialNum.Text = ""
                        txtSerialNum.Focus()
                        Exit Sub
                    End If

                    'new code validate that this serial has not been received today
                    If Len(Trim(txtSerialNum.Text)) > 0 Then
                        Dim valSameDay As Boolean
                        valSameDay = validateSN_SameDay(txtSerialNum.Text)

                        If valSameDay = True Then

                            MsgBox("This device has already been received today, you can not receive it again.", MsgBoxStyle.OKOnly, "ERROR")
                            txtSerialNum.Text = ""
                            txtSerialNum.Focus()
                            Exit Sub
                        End If
                    End If
                    'new code validate that this serial has not been received today

                    lblMessage.Visible = True
                    btnContinue.Visible = True
                    lblMessage.BackColor = Color.Blue
                    lblMessage.ForeColor = Color.White
                    lblMessage.Text = "ACCEPTED"
                    'btnContinue.Focus()
                    vStatus = "ACCEPT"
                    vStatusNum = 1
                    'writeTransaction()
                    Dim dr1 As DataRow = dataGrid.NewRow
                    dr1("Serial") = UCase(txtSerialNum.Text)
                    dr1("Status") = vStatusNum
                    dataGrid.Rows.Add(dr1)
                    vCount += 1
                    valCount.Text = vCount
                    txtSerialNum.Text = ""
                    txtSerialNum.Focus()
                End If

            End If

            'lstProcess.Items.Add("Serial Number Valid")

        End Sub

        Private Sub verifyCapCode(ByVal valCapCode As String)

            Dim validateCap As Boolean

            lstProcess.Items.Add("Verifying Valid CapCode.....")
            lblNewDeviceNum.Visible = False
            txtNewDeviceNum.Visible = False
            btnContinue.Visible = False


            If Len(Trim(valCapCode)) < 1 Then
                txtCapCode.Focus()
                Exit Sub
            Else
                '//Place any business logic to validate the serial number here
                '//if failure of validation - process here and then exit sub
                validateCap = validateCapCode2DB(valCapCode)

                If capMulti = True Then Exit Sub

                If validateCap = False Then
                    lblMessage.Visible = True
                    btnContinue.Visible = True
                    lblMessage.BackColor = Color.Red
                    lblMessage.ForeColor = Color.Yellow
                    lblMessage.Text = "REJECTED"
                    vStatusNum = 3
                    btnContinue.Focus()
                    vStatus = "REJECT"
                    Exit Sub
                Else
                    lblNewDeviceNum.Visible = True
                    txtNewDeviceNum.Visible = True
                    lblBagAndTag.Visible = True
                    btnContinue.Visible = True
                    btnContinue.Focus()
                    vStatus = "NEW DEVICE"
                    vStatusNum = 2
                    'lstProcess.Items.Add("Cap Code Valid")

                    'new code validate that this serial has not been received today
                    Dim valSameDay As Boolean
                    valSameDay = validateSN_SameDay(txtNewDeviceNum.Text)

                    If valSameDay = True Then
                        MsgBox("This device has already been received today, you can not receive it again.", MsgBoxStyle.OKOnly, "ERROR")
                        txtSerialNum.Text = ""
                        txtSerialNum.Focus()
                        Exit Sub
                    End If
                    'new code validate that this serial has not been received today


                End If

            End If


        End Sub

#End Region

#Region " Validate Data "

        Private Function validateSerialNumber2DB(ByVal valSerialNum As String) As Boolean

            validateSerialNumber2DB = False

            Dim xCount As Integer = 0
            Dim r As DataRow

            Dim mMetrocall As New PSS.Data.Production.lmetrocall()
            Dim dtSerial As DataTable = mMetrocall.GetDeviceListBySerialNum(valSerialNum)

            If dtSerial.Rows.Count = 0 Then
                validateSerialNumber2DB = False
            ElseIf dtSerial.Rows.Count > 1 Then
                validateSerialNumber2DB = False
            Else
                validateSerialNumber2DB = True
            End If

            dtSerial.Dispose()
            dtSerial = Nothing

        End Function

        Private Function validateCapCode2DB(ByVal valCapCode As String) As Boolean

            capMulti = False

            validateCapCode2DB = True

            Dim xCount As Integer = 0
            Dim r As DataRow

            Dim mMetrocall As New PSS.Data.Production.lmetrocall()
            Dim dtCap As DataTable = mMetrocall.GetDeviceListByCapCode(valCapCode)

            If dtCap.Rows.Count = 0 Then
                validateCapCode2DB = False
            ElseIf dtCap.Rows.Count > 1 Then
                '//Instance a grid for the user to determine the correct value. Please data in here
                dataCAPgrid = CreateCAPGrid()
                For xCount = 0 To dtCap.Rows.Count - 1
                    r = dtCap.Rows(xCount)
                    capGrid.MoveLast()
                    Dim drCAP As DataRow = dataCAPgrid.NewRow
                    drCAP("DeviceSN") = r("Metro_SN")
                    drCAP("DeviceSKU") = r("Metro_SKU")
                    drCAP("DeviceCAP") = r("Metro_Cap")
                    dataCAPgrid.Rows.Add(drCAP)
                    capGrid.MoveLast()
                    capMulti = True
                Next
                capGrid.Visible = True
                Exit Function


                '//END Instance a grid for the user to determine the correct value. Please data in here
                validateCapCode2DB = False
            Else
                validateCapCode2DB = True


                txtNewDeviceNum.Text = dtCap.Rows(0)("metro_SN")

            End If

            '//Verify not duplicate
            For xCount = 0 To dataGrid.Rows.Count - 1
                r = dataGrid.Rows(xCount)
                If UCase(Trim(txtNewDeviceNum.Text)) = r("Serial") Then
                    MsgBox("This device is already in this workorder. Please bag and tag this item.", MsgBoxStyle.OKOnly, "BAG and TAG")
                    'txtCapCode.Text = ""
                    'txtSerialNum.Text = ""
                    'txtSerialNum.Focus()
                    validateCapCode2DB = False
                    Exit Function
                End If
            Next

            dtCap.Dispose()
            dtCap = Nothing

        End Function


        Private Function validateSN_SameDay(ByVal txtSn As String) As Boolean

            validateSN_SameDay = False

            Dim vSame As New PSS.Data.Production.tstagedetail()
            Dim SameSn As DataTable = vSame.GetDeviceBySerialDate(txtSn, Gui.Receiving.FormatDateShort(Now))

            If SameSn.Rows.Count > 0 Then
                validateSN_SameDay = True
            Else
                validateSN_SameDay = False
            End If

        End Function

#End Region

#Region " Leave Methods - ACTION "

        Private Sub txtTrackNum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTrackNum.Leave
            verifyTrackingNumber(txtTrackNum.Text)
        End Sub

        Private Sub txtSerialNum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerialNum.Leave
            'verifySerialNumber(txtSerialNum.Text)
        End Sub

        Private Sub txtCapCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapCode.Leave
        End Sub

#End Region

#Region " Key Down Methods - ACTION "

        Private Sub txtTrackNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrackNum.KeyDown
            If e.KeyValue = 13 Then
                txtTrackNum.Text = Trim(txtTrackNum.Text)
                visSerialNum()
                txtSerialNum.Focus()
            End If
        End Sub

        Private Sub txtSerialNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerialNum.KeyDown

            If e.KeyValue = 13 Then
                Dim xCount As Integer
                Dim r As DataRow
                '//Verify not duplicate


                For xCount = 0 To dataGrid.Rows.Count - 1
                    r = dataGrid.Rows(xCount)
                    If UCase(Trim(txtSerialNum.Text)) = r("Serial") Then
                        MsgBox("This device is already in this workorder. Please bag and tag this item.", MsgBoxStyle.OKOnly, "BAG and TAG")
                        txtSerialNum.Text = ""
                        txtSerialNum.Focus()
                        Exit Sub
                    End If
                Next
                If Len(Trim(txtSerialNum.Text)) < 1 Then
                    txtCapCode.Visible = True
                    lblCapCode.Visible = True
                    txtCapCode.Focus()
                    Exit Sub
                End If
                Dim blnChkDup As Boolean = checkDuplicate(txtSerialNum.Text, intWO)
                If blnChkDup = True Then
                    txtSerialNum.Text = ""
                    txtSerialNum.Focus()
                    Exit Sub
                End If
                verifySerialNumber(txtSerialNum.Text)

            End If
        End Sub

        Private Sub txtCapCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCapCode.KeyDown
            If e.KeyValue = 13 Then
                verifyCapCode(txtCapCode.Text)
                '                lstProcess.Focus()
            End If
        End Sub

#End Region

#Region " Delete Device "

        Private Function DeleteRecord(ByVal vSerial As String) As Boolean

            DeleteRecord = False
            If Len(Trim(vSerial)) < 1 Then Exit Function

            '//Get recordset for serial number
            Dim daRec As New PSS.Data.Production.tmetrocalldetail()
            Dim dtRec As DataTable = daRec.GetDeviceBySerial(vSerial)

            '//If recordset is single entry then OK to delete
            If dtRec.Rows.Count = 1 Then
                Dim blnDelete As Boolean = daRec.DeleteDeviceBySerial(vSerial)
                If blnDelete = False Then
                    MsgBox("Record could not be deleted,", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Function
                Else
                    DeleteRecord = True
                End If
            End If

        End Function

        Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

            If Len(Trim(txtRemoveSerial.Text)) < 1 Then
                MsgBox("Please input a serial number before continuing.", MsgBoxStyle.OKOnly, "NO SERIAL DEFINED")
                txtRemoveSerial.Focus()
                Exit Sub
            End If

            Dim blnDel As Boolean = DeleteRecord(Trim(txtRemoveSerial.Text))
            If blnDel = False Then
                MsgBox("ERROR DELETING", MsgBoxStyle.OKOnly, "ERROR")
                txtRemoveSerial.Focus()
            Else
                MsgBox("Record: " & Trim(txtRemoveSerial.Text) & " completed successfully.", MsgBoxStyle.OKOnly, "DELETED")
                txtRemoveSerial.Text = ""
                txtRemoveSerial.Focus()
            End If

        End Sub

#End Region

        Private Sub txtCapCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCapCode.TextChanged

        End Sub

        Private Sub txtCapCode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapCode.Enter
            lblMessage.Visible = False
            btnContinue.Visible = False
        End Sub

        Private Sub txtSerialNum_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerialNum.Enter
            lblMessage.Visible = False
            btnContinue.Visible = False
        End Sub

        Private Sub tabData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabData.Click
            txtTrackNum.Focus()
        End Sub

        Private Sub tabCtrl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabCtrl.SelectedIndexChanged

            'resetPage()
            If tabCtrl.SelectedIndex = 0 Then
                txtTrackNum.Focus()
            ElseIf tabCtrl.SelectedIndex = 1 Then
                txtRemoveSerial.Focus()
            End If

        End Sub

        Private Sub addRowDataGrid()

            deviceGrid.MoveLast()
            Dim dr1 As DataRow = dataGrid.NewRow
            dr1("Serial") = txtSerialNum.Text
            dr1("CapCode") = txtCapCode.Text
            dr1("DateStaged") = Gui.Receiving.General.FormatDateShort(Now)
            dr1("Status") = vStatusNum
            dataGrid.Rows.Add(dr1)

            deviceGrid.MoveLast()

        End Sub

        Private Sub createDataGrid()

            dataGrid = New DataTable()

            Dim dgSerial As New DataColumn("Serial")
            dataGrid.Columns.Add(dgSerial)
            Dim dgCAP As New DataColumn("CapCode")
            dataGrid.Columns.Add(dgCAP)
            Dim dgDateStaged As New DataColumn("DateStaged")
            dataGrid.Columns.Add(dgDateStaged)
            Dim dgStatus As New DataColumn("Status")
            dataGrid.Columns.Add(dgStatus)

            Me.deviceGrid.DataSource = dataGrid

        End Sub

        Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer1.SelectedIndexChanged

            Dim xCount As Integer
            Dim r As DataRow

            intCustomer = 0

            For xCount = 0 To dtCustomer.Rows.Count - 1
                r = dtCustomer.Rows(xCount)
                If Trim(r("Cust_Name1")) = Trim(cboCustomer.Text) Then
                    intCustomer = r("Cust_ID")
                    Exit For
                End If
            Next

            populateLocations()
            cboLocation.Focus()

        End Sub

        Private Sub cboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation1.SelectedIndexChanged

            Dim xCount As Integer
            Dim r As DataRow

            intLocation = 0

            For xCount = 0 To dtLocation.Rows.Count - 1
                r = dtLocation.Rows(xCount)
                If Trim(r("Loc_Name")) = Trim(cboLocation.Text) Then
                    intLocation = r("Loc_ID")
                    Exit For
                End If
            Next

            'txtWO.Focus()
            intWO = 0
            lblSerialNum.Visible = True
            txtSerialNum.Visible = True
            txtSerialNum.Focus()

        End Sub

        Private Sub txtWO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWO.TextChanged

        End Sub

        Private Sub txtWO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWO.KeyDown
            If e.KeyValue = 13 Then
                If Len(Trim(txtWO.Text)) > 0 Then

                    '//Verify workorder for customer
                    Dim dtVer As New PSS.Data.Production.tworkorder()
                    Dim drVer As DataRow = dtVer.GetRowByCustDesc(intLocation, Trim(txtWO.Text))
                    If IsDBNull(drVer("WO_ID")) = False Then
                        intWO = drVer("WO_ID")
                    End If
                    lblSerialNum.Visible = True
                    txtSerialNum.Visible = True
                    txtSerialNum.Focus()
                End If
            End If
        End Sub

        Private Sub txtSerialNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerialNum.TextChanged

        End Sub

        Private Sub deviceGrid_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles deviceGrid.AfterDelete

            If VALdeviceGrid = "3" Then
                rCount -= 1
                valRCount.Text = rCount
                txtSerialNum.Text = ""
                txtSerialNum.Focus()
            Else
                vCount -= 1
                valCount.Text = vCount
                txtSerialNum.Text = ""
                txtSerialNum.Focus()
            End If

        End Sub

        Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click

            If Len(Trim(txtTrackNum.Text)) < 1 Then
                MsgBox("Define Tracking Number")
                Exit Sub
            End If

            If intWO = 0 Then
                intWO = InsertWorkOrder()
            End If

            Dim xCount As Integer
            Dim r As DataRow

            Dim tInsert As New PSS.Data.Production.tstagedetail()
            Dim blnInsert As Boolean

            For xCount = 0 To dataGrid.Rows.Count - 1
                r = dataGrid.Rows(xCount)
                blnInsert = tInsert.InsertDataRow(r("Serial"), Trim(Me.txtTrackNum.Text), r("Status"), Gui.Receiving.FormatDate(Now), intCustomer, intLocation, intWO)
            Next

            Try
                dataGrid.Clear()
            Catch ex As Exception
            End Try

            'cboCustomer.Text = ""
            'cboLocation.Text = ""
            'txtWO.Text = ""
            'intCustomer = 0
            'intLocation = 0
            'intWO = 0
            cboCustomer.Focus()
            vCount = 0
            valCount.Text = vCount
            rCount = 0
            valRCount.Text = vCount

            resetPage()

        End Sub

        Private Function InsertWorkOrder() As Int32

            InsertWorkOrder = 0

            Dim newDate As String = Gui.Receiving.FormatDate(Now)

            Dim strSQL As String = "Insert into tworkorder (" & _
            " WO_CustWO, WO_Date" & ", Loc_ID, Prod_ID) VALUES ('" & _
            txtWO.Text & "', '" & _
            newDate & "', " & _
            intLocation & ", " & _
            "1)"

            Dim tblWO As New PSS.Data.Production.tworkorder()
            Dim woID As Int32 = tblWO.idTransaction(strSQL)

            InsertWorkOrder = woID
            tblWO = Nothing

        End Function



        Private Sub cboCustomer_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

            Dim xCount As Integer
            Dim r As DataRow

            intCustomer = 0

            For xCount = 0 To dtCustomer.Rows.Count - 1
                r = dtCustomer.Rows(xCount)
                If Trim(r("Cust_Name1")) = Trim(cboCustomer.Text) Then
                    intCustomer = r("Cust_ID")
                    Exit For
                End If
            Next

            populateLocations()
            'cboLocation.Focus()

        End Sub

        Private Sub cboLocation_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged

            Dim xCount As Integer
            Dim r As DataRow

            intLocation = 0

            For xCount = 0 To dtLocation.Rows.Count - 1
                r = dtLocation.Rows(xCount)
                If Trim(r("Loc_Name")) = Trim(cboLocation.Text) Then
                    intLocation = r("Loc_ID")
                    Exit For
                End If
            Next

            'txtWO.Focus()
            intWO = 0
            lblSerialNum.Visible = True
            txtSerialNum.Visible = True
            'txtSerialNum.Focus()

        End Sub

        Private Sub deviceGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deviceGrid.Click

        End Sub

        Private Sub deviceGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles deviceGrid.MouseUp

            VALdeviceGrid = deviceGrid.Columns(3).Value

        End Sub

        Private Sub txtTrackNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTrackNum.TextChanged

        End Sub

        Private Sub HotKeysF12(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSerialNum.KeyDown, txtCapCode.KeyDown

            If e.KeyCode = Keys.F12 Then
                If Len(Trim(txtTrackNum.Text)) < 1 Then
                    MsgBox("Define Tracking Number")
                    Exit Sub
                End If

                If intWO = 0 Then
                    intWO = InsertWorkOrder()
                End If

                Dim xCount As Integer
                Dim r As DataRow

                Dim tInsert As New PSS.Data.Production.tstagedetail()
                Dim blnInsert As Boolean

                For xCount = 0 To dataGrid.Rows.Count - 1
                    r = dataGrid.Rows(xCount)
                    blnInsert = tInsert.InsertDataRow(r("Serial"), Me.txtTrackNum.Text, r("Status"), Gui.Receiving.FormatDate(Now), intCustomer, intLocation, intWO)
                Next

                Try
                    dataGrid.Clear()
                Catch ex As Exception
                End Try

                'cboCustomer.Text = ""
                'cboLocation.Text = ""
                'txtWO.Text = ""
                'intCustomer = 0
                'intLocation = 0
                'intWO = 0
                cboCustomer.Focus()
                vCount = 0
                valCount.Text = vCount
                rCount = 0
                valRCount.Text = vCount

                resetPage()
            End If
        End Sub

        Private Function checkDuplicate(ByVal serialNum As String, ByVal intWorkorder As Int32) As Boolean

            checkDuplicate = False

            Try
                Dim dDevice As New PSS.Data.Production.tstagedetail()

                Dim dtDevice As DataTable = dDevice.GetDuplicateDeviceDataSTAGE(serialNum, intWorkorder)

                Dim r As DataRow

                If dtDevice.Rows.Count > 0 Then
                    MsgBox("This device is duplicated in the current workorder.", MsgBoxStyle.OKOnly, "DUPLICATE")
                    txtCapCode.Text = ""
                    txtSerialNum.Text = ""
                    txtSerialNum.Focus()
                    checkDuplicate = True
                End If
            Catch
                checkDuplicate = False
            End Try

        End Function


        Private Function CreateCAPGrid() As DataTable

            Dim dtGrid As New DataTable("dtGridMain")

            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim dcDeviceSN As New DataColumn("DeviceSN")
            dtGrid.Columns.Add(dcDeviceSN)
            Dim dcDeviceSKU As New DataColumn("DeviceSKU")
            dtGrid.Columns.Add(dcDeviceSKU)
            Dim dcDeviceCap As New DataColumn("DeviceCap")
            dtGrid.Columns.Add(dcDeviceCap)

            dataCAPgrid = dtGrid

            Dim dr1 As DataRow = dtGrid.NewRow
            dr1("DeviceSN") = "NONE"
            dtGrid.Rows.Add(dr1)

            Me.capGrid.DataSource = dtGrid

            CreateCAPGrid = dtGrid

        End Function

        Private Sub capGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles capGrid.MouseUp

            'Craig Haney NEW 3-4-04
            If capGrid.Columns(0).Value = "NONE" Then
                txtCapCode.Text = "NONE - REJECTED"
                capGrid.Visible = False
                lblMessage.Visible = True
                btnContinue.Visible = True
                lblMessage.BackColor = Color.Red
                lblMessage.ForeColor = Color.Yellow
                lblMessage.Text = "REJECTED"
                vStatusNum = 3
                btnContinue.Focus()
                vStatus = "REJECT"
                Exit Sub
            End If
            'Craig Haney NEW 3-4-04

            Me.txtSerialNum.Text = capGrid.Columns(0).Value
            Me.lblCapCode.Visible = False
            Me.txtCapCode.Text = ""
            Me.txtCapCode.Visible = False
            Me.txtSerialNum.Focus()
            capGrid.Visible = False
            capMulti = False

            Dim xCount As Integer
            Dim r As DataRow
            '//Verify not duplicate

            For xCount = 0 To dataGrid.Rows.Count - 1
                r = dataGrid.Rows(xCount)
                If UCase(Trim(txtSerialNum.Text)) = r("Serial") Then
                    MsgBox("This device is already in this workorder. Please bag and tag this item.", MsgBoxStyle.OKOnly, "BAG and TAG")
                    txtSerialNum.Text = ""
                    txtSerialNum.Focus()
                    Exit Sub
                End If
            Next
            If Len(Trim(txtSerialNum.Text)) < 1 Then
                txtCapCode.Visible = True
                lblCapCode.Visible = True
                txtCapCode.Focus()
                Exit Sub
            End If
            Dim blnChkDup As Boolean = checkDuplicate(txtSerialNum.Text, intWO)
            If blnChkDup = True Then
                txtSerialNum.Text = ""
                txtSerialNum.Focus()
                Exit Sub
            End If
            verifySerialNumber(txtSerialNum.Text)

        End Sub

    End Class

End Namespace
