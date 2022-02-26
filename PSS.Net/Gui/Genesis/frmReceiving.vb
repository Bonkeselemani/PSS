Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Genesis
    Public Class frmReceiving
        Inherits System.Windows.Forms.Form

        Private _objGenesisRec As PSS.Data.Buisness.Genesis.Receiving
        Private _booPopDataToCombo As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objGenesisRec = New PSS.Data.Buisness.Genesis.Receiving()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                _objGenesisRec = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblModelDesc As System.Windows.Forms.Label
        Friend WithEvents cboOpenSO As C1.Win.C1List.C1Combo
        Friend WithEvents cboSOLines As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents btnReceive As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveOneSN As System.Windows.Forms.Button
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents lstSNs As System.Windows.Forms.ListBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents btnViewSODetails As System.Windows.Forms.Button
        Friend WithEvents dbgSODetails As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblLineTotalQty As System.Windows.Forms.Label
        Friend WithEvents lblLineReceivedQty As System.Windows.Forms.Label
        Friend WithEvents lblLineOpenQty As System.Windows.Forms.Label
        Friend WithEvents lblLineProducedQty As System.Windows.Forms.Label
        Friend WithEvents lblListCount As System.Windows.Forms.Label
        Friend WithEvents btnRefreshQty As System.Windows.Forms.Button
        Friend WithEvents lblSOProducedQty As System.Windows.Forms.Label
        Friend WithEvents lblSOOepnQty As System.Windows.Forms.Label
        Friend WithEvents lblSOTotalQty As System.Windows.Forms.Label
        Friend WithEvents lblSOReceivedQty As System.Windows.Forms.Label
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReceiving))
            Me.cboOpenSO = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblModelDesc = New System.Windows.Forms.Label()
            Me.cboSOLines = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblLineTotalQty = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblLineReceivedQty = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblLineOpenQty = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblLineProducedQty = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.lstSNs = New System.Windows.Forms.ListBox()
            Me.btnReceive = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveOneSN = New System.Windows.Forms.Button()
            Me.lblListCount = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.btnRefreshQty = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.lblSOProducedQty = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.lblSOOepnQty = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.lblSOTotalQty = New System.Windows.Forms.Label()
            Me.lblSOReceivedQty = New System.Windows.Forms.Label()
            Me.dbgSODetails = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnViewSODetails = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            CType(Me.cboOpenSO, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboSOLines, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.dbgSODetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
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
            Me.cboOpenSO.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboOpenSO.ItemHeight = 15
            Me.cboOpenSO.Location = New System.Drawing.Point(144, 16)
            Me.cboOpenSO.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenSO.MaxDropDownItems = CType(10, Short)
            Me.cboOpenSO.MaxLength = 32767
            Me.cboOpenSO.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenSO.Name = "cboOpenSO"
            Me.cboOpenSO.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenSO.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenSO.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenSO.Size = New System.Drawing.Size(272, 21)
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
            Me.Label5.Location = New System.Drawing.Point(8, 14)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(130, 21)
            Me.Label5.TabIndex = 85
            Me.Label5.Text = "Order :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(7, 79)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(130, 21)
            Me.Label1.TabIndex = 86
            Me.Label1.Text = "Model:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModelDesc
            '
            Me.lblModelDesc.BackColor = System.Drawing.Color.White
            Me.lblModelDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblModelDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModelDesc.ForeColor = System.Drawing.Color.Black
            Me.lblModelDesc.Location = New System.Drawing.Point(144, 80)
            Me.lblModelDesc.Name = "lblModelDesc"
            Me.lblModelDesc.Size = New System.Drawing.Size(272, 21)
            Me.lblModelDesc.TabIndex = 87
            Me.lblModelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cboSOLines.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboSOLines.ItemHeight = 15
            Me.cboSOLines.Location = New System.Drawing.Point(144, 48)
            Me.cboSOLines.MatchEntryTimeout = CType(2000, Long)
            Me.cboSOLines.MaxDropDownItems = CType(10, Short)
            Me.cboSOLines.MaxLength = 32767
            Me.cboSOLines.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSOLines.Name = "cboSOLines"
            Me.cboSOLines.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSOLines.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSOLines.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSOLines.Size = New System.Drawing.Size(272, 21)
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
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 46)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(130, 21)
            Me.Label2.TabIndex = 89
            Me.Label2.Text = "Order Line # :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLineTotalQty
            '
            Me.lblLineTotalQty.BackColor = System.Drawing.Color.White
            Me.lblLineTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblLineTotalQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineTotalQty.ForeColor = System.Drawing.Color.Black
            Me.lblLineTotalQty.Location = New System.Drawing.Point(83, 32)
            Me.lblLineTotalQty.Name = "lblLineTotalQty"
            Me.lblLineTotalQty.Size = New System.Drawing.Size(48, 21)
            Me.lblLineTotalQty.TabIndex = 91
            Me.lblLineTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(6, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 21)
            Me.Label4.TabIndex = 90
            Me.Label4.Text = "Total:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLineReceivedQty
            '
            Me.lblLineReceivedQty.BackColor = System.Drawing.Color.White
            Me.lblLineReceivedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblLineReceivedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineReceivedQty.ForeColor = System.Drawing.Color.Black
            Me.lblLineReceivedQty.Location = New System.Drawing.Point(82, 64)
            Me.lblLineReceivedQty.Name = "lblLineReceivedQty"
            Me.lblLineReceivedQty.Size = New System.Drawing.Size(48, 21)
            Me.lblLineReceivedQty.TabIndex = 93
            Me.lblLineReceivedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(6, 64)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(72, 21)
            Me.Label6.TabIndex = 92
            Me.Label6.Text = "Received:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLineOpenQty
            '
            Me.lblLineOpenQty.BackColor = System.Drawing.Color.White
            Me.lblLineOpenQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblLineOpenQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineOpenQty.ForeColor = System.Drawing.Color.Black
            Me.lblLineOpenQty.Location = New System.Drawing.Point(218, 32)
            Me.lblLineOpenQty.Name = "lblLineOpenQty"
            Me.lblLineOpenQty.Size = New System.Drawing.Size(48, 21)
            Me.lblLineOpenQty.TabIndex = 95
            Me.lblLineOpenQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(166, 32)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(48, 21)
            Me.Label8.TabIndex = 94
            Me.Label8.Text = "Open:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLineProducedQty
            '
            Me.lblLineProducedQty.BackColor = System.Drawing.Color.White
            Me.lblLineProducedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblLineProducedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineProducedQty.ForeColor = System.Drawing.Color.Black
            Me.lblLineProducedQty.Location = New System.Drawing.Point(218, 64)
            Me.lblLineProducedQty.Name = "lblLineProducedQty"
            Me.lblLineProducedQty.Size = New System.Drawing.Size(48, 21)
            Me.lblLineProducedQty.TabIndex = 97
            Me.lblLineProducedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(134, 64)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(80, 21)
            Me.Label10.TabIndex = 96
            Me.Label10.Text = "Produced:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(8, 111)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(130, 21)
            Me.Label11.TabIndex = 98
            Me.Label11.Text = "Serial Number:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN
            '
            Me.txtSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.Location = New System.Drawing.Point(144, 112)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(272, 21)
            Me.txtSN.TabIndex = 3
            Me.txtSN.Text = ""
            '
            'lstSNs
            '
            Me.lstSNs.Location = New System.Drawing.Point(144, 144)
            Me.lstSNs.Name = "lstSNs"
            Me.lstSNs.Size = New System.Drawing.Size(272, 420)
            Me.lstSNs.TabIndex = 4
            '
            'btnReceive
            '
            Me.btnReceive.BackColor = System.Drawing.Color.Green
            Me.btnReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReceive.ForeColor = System.Drawing.Color.White
            Me.btnReceive.Location = New System.Drawing.Point(24, 520)
            Me.btnReceive.Name = "btnReceive"
            Me.btnReceive.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReceive.Size = New System.Drawing.Size(104, 30)
            Me.btnReceive.TabIndex = 5
            Me.btnReceive.Text = "RECEIVE"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(24, 376)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(104, 30)
            Me.btnRemoveAllSNs.TabIndex = 7
            Me.btnRemoveAllSNs.Text = "REMOVE ALL"
            '
            'btnRemoveOneSN
            '
            Me.btnRemoveOneSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveOneSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveOneSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveOneSN.Location = New System.Drawing.Point(24, 320)
            Me.btnRemoveOneSN.Name = "btnRemoveOneSN"
            Me.btnRemoveOneSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveOneSN.Size = New System.Drawing.Size(104, 30)
            Me.btnRemoveOneSN.TabIndex = 6
            Me.btnRemoveOneSN.Text = "REMOVE ONE"
            '
            'lblListCount
            '
            Me.lblListCount.BackColor = System.Drawing.Color.Black
            Me.lblListCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblListCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblListCount.ForeColor = System.Drawing.Color.Lime
            Me.lblListCount.Location = New System.Drawing.Point(24, 192)
            Me.lblListCount.Name = "lblListCount"
            Me.lblListCount.Size = New System.Drawing.Size(104, 43)
            Me.lblListCount.TabIndex = 105
            Me.lblListCount.Text = "0"
            Me.lblListCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(24, 176)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(104, 16)
            Me.Label12.TabIndex = 104
            Me.Label12.Text = "List Count"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnRefreshQty
            '
            Me.btnRefreshQty.BackColor = System.Drawing.Color.Green
            Me.btnRefreshQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshQty.ForeColor = System.Drawing.Color.White
            Me.btnRefreshQty.Location = New System.Drawing.Point(440, 112)
            Me.btnRefreshQty.Name = "btnRefreshQty"
            Me.btnRefreshQty.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRefreshQty.Size = New System.Drawing.Size(272, 24)
            Me.btnRefreshQty.TabIndex = 106
            Me.btnRefreshQty.Text = "Refresh Quantity"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLineProducedQty, Me.Label6, Me.lblLineOpenQty, Me.Label4, Me.Label8, Me.Label10, Me.lblLineTotalQty, Me.lblLineReceivedQty})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(728, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(272, 96)
            Me.GroupBox1.TabIndex = 107
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Line Quantity"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSOProducedQty, Me.Label14, Me.lblSOOepnQty, Me.Label16, Me.Label17, Me.Label18, Me.lblSOTotalQty, Me.lblSOReceivedQty})
            Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(440, 8)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(272, 96)
            Me.GroupBox2.TabIndex = 108
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Order Quantity"
            '
            'lblSOProducedQty
            '
            Me.lblSOProducedQty.BackColor = System.Drawing.Color.White
            Me.lblSOProducedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblSOProducedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSOProducedQty.ForeColor = System.Drawing.Color.Black
            Me.lblSOProducedQty.Location = New System.Drawing.Point(218, 64)
            Me.lblSOProducedQty.Name = "lblSOProducedQty"
            Me.lblSOProducedQty.Size = New System.Drawing.Size(48, 21)
            Me.lblSOProducedQty.TabIndex = 97
            Me.lblSOProducedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.White
            Me.Label14.Location = New System.Drawing.Point(6, 64)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(72, 21)
            Me.Label14.TabIndex = 92
            Me.Label14.Text = "Received:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSOOepnQty
            '
            Me.lblSOOepnQty.BackColor = System.Drawing.Color.White
            Me.lblSOOepnQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblSOOepnQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSOOepnQty.ForeColor = System.Drawing.Color.Black
            Me.lblSOOepnQty.Location = New System.Drawing.Point(218, 32)
            Me.lblSOOepnQty.Name = "lblSOOepnQty"
            Me.lblSOOepnQty.Size = New System.Drawing.Size(48, 21)
            Me.lblSOOepnQty.TabIndex = 95
            Me.lblSOOepnQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label16
            '
            Me.Label16.BackColor = System.Drawing.Color.Transparent
            Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.White
            Me.Label16.Location = New System.Drawing.Point(6, 32)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(72, 21)
            Me.Label16.TabIndex = 90
            Me.Label16.Text = "Total:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label17
            '
            Me.Label17.BackColor = System.Drawing.Color.Transparent
            Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(166, 32)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(48, 21)
            Me.Label17.TabIndex = 94
            Me.Label17.Text = "Open:"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label18
            '
            Me.Label18.BackColor = System.Drawing.Color.Transparent
            Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.White
            Me.Label18.Location = New System.Drawing.Point(134, 64)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(80, 21)
            Me.Label18.TabIndex = 96
            Me.Label18.Text = "Produced:"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSOTotalQty
            '
            Me.lblSOTotalQty.BackColor = System.Drawing.Color.White
            Me.lblSOTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblSOTotalQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSOTotalQty.ForeColor = System.Drawing.Color.Black
            Me.lblSOTotalQty.Location = New System.Drawing.Point(83, 32)
            Me.lblSOTotalQty.Name = "lblSOTotalQty"
            Me.lblSOTotalQty.Size = New System.Drawing.Size(48, 21)
            Me.lblSOTotalQty.TabIndex = 91
            Me.lblSOTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSOReceivedQty
            '
            Me.lblSOReceivedQty.BackColor = System.Drawing.Color.White
            Me.lblSOReceivedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblSOReceivedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSOReceivedQty.ForeColor = System.Drawing.Color.Black
            Me.lblSOReceivedQty.Location = New System.Drawing.Point(82, 64)
            Me.lblSOReceivedQty.Name = "lblSOReceivedQty"
            Me.lblSOReceivedQty.Size = New System.Drawing.Size(48, 21)
            Me.lblSOReceivedQty.TabIndex = 93
            Me.lblSOReceivedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dbgSODetails
            '
            Me.dbgSODetails.AllowUpdate = False
            Me.dbgSODetails.AlternatingRows = True
            Me.dbgSODetails.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgSODetails.FilterBar = True
            Me.dbgSODetails.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgSODetails.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgSODetails.Location = New System.Drawing.Point(440, 144)
            Me.dbgSODetails.Name = "dbgSODetails"
            Me.dbgSODetails.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgSODetails.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgSODetails.PreviewInfo.ZoomFactor = 75
            Me.dbgSODetails.Size = New System.Drawing.Size(560, 424)
            Me.dbgSODetails.TabIndex = 109
            Me.dbgSODetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;" & _
            "ForeColor:Lime;BackColor:Black;}Normal{BackColor:SteelBlue;}Selected{ForeColor:H" & _
            "ighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}St" & _
            "yle16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue" & _
            ";}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Re" & _
            "cordSelector{AlignImage:Center;}Footer{ForeColor:Lime;BackColor:Black;}Style21{}" & _
            "Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenR" & _
            "ow{BackColor:NavajoWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1" & _
            ", 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft Sans Se" & _
            "rif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}S" & _
            "tyle5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Sty" & _
            "le7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGri" & _
            "d.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionH" & _
            "eight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBord" & _
            "er"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizon" & _
            "talScrollGroup=""1""><Height>420</Height><CaptionStyle parent=""Style2"" me=""Style10" & _
            """ /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me" & _
            "=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle paren" & _
            "t=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle" & _
            " parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Sty" & _
            "le7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRo" & _
            "w"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Se" & _
            "lectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /" & _
            "><ClientRect>0, 0, 556, 420</ClientRect><BorderSide>0</BorderSide><BorderStyle>S" & _
            "unken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style " & _
            "parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Hea" & _
            "ding"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headin" & _
            "g"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal""" & _
            " me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal""" & _
            " me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=" & _
            """RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Captio" & _
            "n"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplit" & _
            "s><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0," & _
            " 0, 556, 420</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPa" & _
            "geFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'btnViewSODetails
            '
            Me.btnViewSODetails.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnViewSODetails.BackColor = System.Drawing.Color.Green
            Me.btnViewSODetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnViewSODetails.ForeColor = System.Drawing.Color.White
            Me.btnViewSODetails.Location = New System.Drawing.Point(864, 112)
            Me.btnViewSODetails.Name = "btnViewSODetails"
            Me.btnViewSODetails.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnViewSODetails.Size = New System.Drawing.Size(136, 24)
            Me.btnViewSODetails.TabIndex = 110
            Me.btnViewSODetails.Text = "View Order Details"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCopyAll.BackColor = System.Drawing.Color.DimGray
            Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.White
            Me.btnCopyAll.Location = New System.Drawing.Point(864, 584)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCopyAll.Size = New System.Drawing.Size(136, 24)
            Me.btnCopyAll.TabIndex = 111
            Me.btnCopyAll.Text = "Copy All Rows"
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCopySelectedRows.BackColor = System.Drawing.Color.DimGray
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.White
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(704, 584)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(136, 24)
            Me.btnCopySelectedRows.TabIndex = 112
            Me.btnCopySelectedRows.Text = "Copy Selected Rows"
            '
            'frmReceiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1016, 621)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelectedRows, Me.btnCopyAll, Me.btnViewSODetails, Me.dbgSODetails, Me.GroupBox2, Me.GroupBox1, Me.lblListCount, Me.Label12, Me.btnReceive, Me.btnRemoveAllSNs, Me.btnRemoveOneSN, Me.lstSNs, Me.txtSN, Me.Label11, Me.cboSOLines, Me.Label2, Me.lblModelDesc, Me.Label1, Me.cboOpenSO, Me.Label5, Me.btnRefreshQty})
            Me.Name = "frmReceiving"
            Me.Text = "frmReceiving"
            CType(Me.cboOpenSO, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboSOLines, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.dbgSODetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************************************************
        Private Sub frmReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)

                '*********************************
                'Load Open Order & Box Type
                '*********************************
                Me.LoadOpenSO()

                Me.cboOpenSO.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmReceiving_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub LoadOpenSO()
            Dim dt As DataTable
            Try

                Me._booPopDataToCombo = True
                Me.cboSOLines.DataSource = Nothing : Me.cboSOLines.Text = ""
                ResetSOQuantity() : ResetScanCtrl()
                Me.lblModelDesc.Text = ""

                dt = Me._objGenesisRec.GetOpenToRecSO(SharedFunctions.intGenesisLocID, True)
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
        Private Sub ResetSOQuantity()
            Try
                Me.lblSOOepnQty.Text = ""
                Me.lblSOProducedQty.Text = ""
                Me.lblSOReceivedQty.Text = ""
                Me.lblSOTotalQty.Text = ""

                Me.lblLineOpenQty.Text = ""
                Me.lblLineProducedQty.Text = ""
                Me.lblLineReceivedQty.Text = ""
                Me.lblLineTotalQty.Text = ""
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub ResetScanCtrl()
            Try
                Me.lblLineOpenQty.Text = "0"
                Me.txtSN.Text = ""
                Me.lstSNs.Items.Clear() : Me.lstSNs.Refresh()

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub cboOpenSO_SOLine_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenSO.SelectedValueChanged, cboSOLines.SelectedValueChanged
            Try
                If Me._booPopDataToCombo = True Then Exit Sub

                If sender.name = "cboOpenSO" Then
                    If Me.cboOpenSO.SelectedValue > 0 Then
                        Me.LoadSOLines()
                        Me.cboSOLines.Focus() : Me.cboSOLines.SelectAll()
                    End If
                ElseIf sender.name = "cboSOLines" Then
                    If Me.cboSOLines.SelectedValue > 0 Then
                        RefreshLineData()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenSO_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub LoadSOLines()
            Dim dt As DataTable
            Try

                Me._booPopDataToCombo = True
                Me.cboSOLines.DataSource = Nothing : Me.cboSOLines.Text = ""
                ResetSOQuantity() : ResetScanCtrl()
                Me.lblModelDesc.Text = ""

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                dt = Me._objGenesisRec.GetOpenToRecSOLines(Me.cboOpenSO.SelectedValue, False, PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User)
                Misc.PopulateC1DropDownList(Me.cboSOLines, dt, "LineNo", "Tray_ID")
                _booPopDataToCombo = False

                If dt.Rows.Count > 0 AndAlso Me.cboSOLines.SelectedValue > 0 Then RefreshLineData()

                Me._booPopDataToCombo = False
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub RefreshLineData()
            Dim dt As DataTable
            Dim iSOQty, iSOLineQty, iTrayID As Integer

            Try
                Me.lblModelDesc.Text = ""
                ResetSOQuantity() : ResetScanCtrl()
                If _booPopDataToCombo = True Then Exit Sub

                If Me.cboOpenSO.SelectedValue = 0 Then Exit Sub
                If Me.cboSOLines.SelectedValue = 0 Then
                    MessageBox.Show("Tray ID is missing for this line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                iSOQty = 0 : iSOLineQty = 0 : iTrayID = 0

                iTrayID = Me.cboSOLines.SelectedValue

                Me.lblModelDesc.Text = Me.cboSOLines.Columns("ItemNo").CellValue(Me.cboSOLines.SelectedIndex)

                If Me.cboSOLines.DataSource.Table.Rows.Count > 0 AndAlso Not IsDBNull(Me.cboSOLines.DataSource.Table.Compute("Sum(Quantity)", "")) Then iSOQty = Me.cboSOLines.DataSource.Table.Compute("Sum(Quantity)", "")
                If Me.cboSOLines.DataSource.Table.Rows.Count > 0 AndAlso Not IsDBNull(Me.cboSOLines.DataSource.Table.Compute("Sum(Quantity)", "Tray_ID = " & iTrayID)) Then iSOLineQty = Me.cboSOLines.DataSource.Table.Compute("Sum(Quantity)", "Tray_ID = " & iTrayID)
                dt = Me._objGenesisRec.GetWODeviceData(Me.cboOpenSO.SelectedValue)

                'SO Quantity
                Me.lblSOTotalQty.Text = iSOQty
                Me.lblSOReceivedQty.Text = dt.Rows.Count
                Me.lblSOProducedQty.Text = dt.Select("Device_DateShip <> ''").Length
                Me.lblSOOepnQty.Text = iSOQty - dt.Rows.Count

                'Line Quantity
                Me.lblLineTotalQty.Text = iSOLineQty
                Me.lblLineReceivedQty.Text = dt.Select("Tray_ID = " & iTrayID).Length
                Me.lblLineProducedQty.Text = dt.Select("Tray_ID = " & iTrayID & " AND Device_DateShip <> ''").Length
                Me.lblLineOpenQty.Text = iSOLineQty - Convert.ToInt32(Me.lblLineReceivedQty.Text)

            Catch ex As Exception
                Throw ex
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnRefreshQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshQty.Click
            Try
                RefreshLineData() : Me.txtSN.SelectAll() : Me.txtSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshQty_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Dim iRecvdCnt As Integer = 0
            Dim dtOpenDevInfo As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtSN.Text.Trim.Length > 0 Then
                        If Me.cboOpenSO.SelectedValue = 0 Then
                            MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf Me.cboSOLines.SelectedValue = 0 Then
                            MessageBox.Show("Tray ID is missing for this line item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf Me.lstSNs.Items.IndexOf(Me.txtSN.Text.Trim.ToUpper) >= 0 Then
                            MessageBox.Show("Serial number has already scanned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        ElseIf Convert.ToInt32(Me.cboSOLines.Columns("Model_ID").CellValue(Me.cboSOLines.SelectedIndex)) = 0 Then
                            MessageBox.Show("Model ID is missing for this line item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Else
                            iRecvdCnt = Me._objGenesisRec.GetTrayCount(Me.cboSOLines.SelectedValue)

                            If iRecvdCnt >= Convert.ToInt32(Me.cboSOLines.Columns("Quantity").CellValue(Me.cboSOLines.SelectedIndex)) Then
                                MessageBox.Show("You have reached the quantity of this line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            ElseIf (iRecvdCnt + Me.lstSNs.Items.Count) >= Convert.ToInt32(Me.cboSOLines.Columns("Quantity").CellValue(Me.cboSOLines.SelectedIndex)) Then
                                MessageBox.Show("You have reached the quantity of this line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            Else
                                dtOpenDevInfo = Me._objGenesisRec.GetOpenDeviceInfoByLocation(SharedFunctions.intGenesisLocID, Me.txtSN.Text.Trim.ToUpper)
                                If dtOpenDevInfo.Rows.Count > 0 Then
                                    MessageBox.Show("Serial number '" & Me.txtSN.Text.Trim.ToUpper & "' is open under order # " & dtOpenDevInfo.Rows(0)("WO_CustWO") & " .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                                Else
                                    Me.lstSNs.Items.Add(Me.txtSN.Text.Trim.ToUpper) : Me.lblListCount.Text = Me.lstSNs.Items.Count
                                    Me.txtSN.Text = "" : Me.txtSN.Focus()
                                End If 'check device in WIP
                            End If 'check quantity
                        End If
                    End If  'has data
                End If 'enter key
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshQty_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dtOpenDevInfo)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnRemoveOneSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOneSN.Click
            Dim strSN As String = ""
            Try
                If Me.lstSNs.Items.Count = 0 Then Exit Sub

                strSN = InputBox("Scan serial number:").Trim.ToUpper
                If strSN.Trim.Length = 0 Then Exit Sub

                If Me.lstSNs.Items.IndexOf(strSN) < 0 Then
                    MessageBox.Show("Serial number is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Else
                    Me.lstSNs.Items.Remove(strSN) : Me.lstSNs.Refresh() : Me.lblListCount.Text = Me.lstSNs.Items.Count
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveOneSN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Try
                If Me.lstSNs.Items.Count = 0 Then Exit Sub
                If MessageBox.Show("Are you sure you want to empty the list?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                Me.lstSNs.Items.Clear() : Me.lstSNs.Refresh() : Me.lblListCount.Text = Me.lstSNs.Items.Count
                Me.txtSN.SelectAll() : Me.txtSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAllSNs_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
            Dim i As Integer = 0
            Dim strExcptSNsList, strExcpSNsArr() As String
            Dim dblLabor As Double = 0.0

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If Me.lstSNs.Items.Count = 0 Then Exit Sub
                strExcptSNsList = ""

                dblLabor = Me._objGenesisRec.GetUnitPrice(Me.cboSOLines.Columns("WOL_ID").CellValue(Me.cboSOLines.SelectedIndex))

                For i = 0 To Me.lstSNs.Items.Count - 1
                    If Me.ProcessSN(Me.lstSNs.Items.Item(i), dblLabor) = False Then
                        If strExcptSNsList.Length > 0 Then strExcptSNsList &= ", "
                        strExcptSNsList &= Me.lstSNs.Items.Item(i)
                    End If
                Next i

                Me.RefreshLineData()

                If Me.lblLineOpenQty.Text = 0 Then
                    Me._objGenesisRec.SetReceivingClosedFlag(Me.lblModelDesc.Text = Me.cboSOLines.Columns("WOL_ID").CellValue(Me.cboSOLines.SelectedIndex), 1)
                Else
                    strExcpSNsArr = strExcptSNsList.Split(",".Chars(0))
                    i = 0
                    While (i < strExcpSNsArr.Length AndAlso strExcpSNsArr(i).Trim.Length > 0)
                        Me.lstSNs.Items.Add(strExcpSNsArr(i)) : i += 1
                    End While
                    Me.lstSNs.Refresh() : Me.lblListCount.Text = Me.lstSNs.Items.Count
                    Me.Enabled = True : Me.txtSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReceive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                strExcpSNsArr = Nothing
            End Try
        End Sub

        '********************************************************************************************************
        Private Function ProcessSN(ByVal strSN As String, ByVal dblUnitPrice As Double) As Boolean
            Const iGenesisCCID As Integer = 66
            Dim booResult As Boolean = False
            Dim iModelID, iTrayID, iWOID, iShiftID, iDeviceID As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim dtOpenDevInfo As DataTable
            Dim objClsGenericProcess As PSS.Data.Buisness.GenericProcess.clsGenericProcess

            Try
                ProcessSN = False
                If Me.cboOpenSO.SelectedValue = 0 Then
                    MessageBox.Show("Please select Order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me.cboSOLines.SelectedValue = 0 Then
                    MessageBox.Show("Tray ID is missing for this line item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Convert.ToInt32(Me.cboSOLines.Columns("Model_ID").CellValue(Me.cboSOLines.SelectedIndex)) = 0 Then
                    MessageBox.Show("Model ID is missing for this line item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me._objGenesisRec.GetTrayCount(Me.cboSOLines.SelectedValue) >= Convert.ToInt32(Me.cboSOLines.Columns("Quantity").CellValue(Me.cboSOLines.SelectedIndex)) Then
                    MessageBox.Show("You have reached the quantity of this line. Can't add this serial number '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Else
                    iModelID = 0 : iTrayID = 0 : iWOID = 0 : iShiftID = 0
                    iWOID = Me.cboOpenSO.SelectedValue : iTrayID = Me.cboSOLines.SelectedValue
                    iModelID = Convert.ToInt32(Me.cboSOLines.Columns("Model_ID").CellValue(Me.cboSOLines.SelectedIndex))
                    iShiftID = PSS.Core.ApplicationUser.IDShift
                    dtOpenDevInfo = Me._objGenesisRec.GetOpenDeviceInfoByLocation(SharedFunctions.intGenesisLocID, strSN)

                    If dtOpenDevInfo.Rows.Count > 0 Then
                        MessageBox.Show("Serial number '" & strSN & "' is open under order # " & dtOpenDevInfo.Rows(0)("WO_CustWO") & " .", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    Else
                        objRec = New PSS.Data.Production.Receiving()
                        iDeviceID = objRec.InsertIntoTdevice(strSN, Generic.GetWorkDate(iShiftID), objRec.GetNextDeviceCountInTray(iTrayID) + 1, iTrayID, SharedFunctions.intGenesisLocID, iWOID, iModelID, iShiftID, , , , iGenesisCCID, dblUnitPrice)

                        If iDeviceID = 0 Then
                            MessageBox.Show("System has failed to insert SN to tdevice.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            objClsGenericProcess = New PSS.Data.Buisness.GenericProcess.clsGenericProcess()
                            objClsGenericProcess.InsertUpdateAsnData(iWOID, SharedFunctions.intGenesisLocID, iModelID, iDeviceID, "", "", "", strSN, "", "", "", "", 0, 0, PSS.Core.ApplicationUser.IDuser, )
                            booResult = True
                        End If
                    End If
                End If

                Return booResult
            Catch ex As Exception
                ProcessSN = False
                Throw ex
            Finally
                Generic.DisposeDT(dtOpenDevInfo)
                objRec = Nothing
            End Try
        End Function

        '********************************************************************************************************
        Private Sub btnViewSODetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewSODetails.Click
            Dim dt As DataTable
            Dim strSO As String = ""

            Try
                strSO = InputBox("Enter order #:").Trim.ToUpper
                If strSO.Trim.Length = 0 Then Exit Sub

                With Me.dbgSODetails
                    .DataSource = Nothing
                    .Caption = ""
                    dt = Me._objGenesisRec.GetOrderInfo(SharedFunctions.intGenesisLocID, strSO)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Order '" & strSO & "' does not exist for Genesis customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    Else
                        .DataSource = dt.DefaultView
                        .Caption = strSO
                        .Splits(0).DisplayColumns("LineNo").Width = 50
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnViewSODetails_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySelectedRows.Click
            Try
                If Me.dbgSODetails.RowCount = 0 Then Exit Sub
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Misc.CopySelectedRowsData(Me.dbgSODetails)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCopySelectedRows_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            End Try
        End Sub

        '********************************************************************************************************
        Private Sub btnCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
            Try
                If Me.dbgSODetails.RowCount = 0 Then Exit Sub
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Misc.CopyAllData(Me.dbgSODetails)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            End Try
        End Sub

        '********************************************************************************************************
    End Class
End Namespace