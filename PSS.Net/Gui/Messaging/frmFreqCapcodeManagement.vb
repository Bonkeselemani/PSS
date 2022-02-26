Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmFreqCapcodeManagement
    Inherits System.Windows.Forms.Form

    Private _iMenuCustID As Integer = 0
    Private _strScreenName As String
    Private _iSelectedFreqID As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iCust_ID As Integer, ByVal strScreenName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _iMenuCustID = iCust_ID
        _strScreenName = strScreenName

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
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents lblCusts As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnGenerateCapcode As System.Windows.Forms.Button
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSeed As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFreq As C1.Win.C1List.C1Combo
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnAddAnyCapCode As System.Windows.Forms.Button
    Friend WithEvents lblRecNum As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grpBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRefreash As System.Windows.Forms.Button
    Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblRecNum3 As System.Windows.Forms.Label
    Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
    Friend WithEvents btnCopyAll As System.Windows.Forms.Button
    Friend WithEvents lblNewCapcode As System.Windows.Forms.Label
    Friend WithEvents lblDupCapcode As System.Windows.Forms.Label
    Friend WithEvents lblRecNum2 As System.Windows.Forms.Label
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblDupCapcodesDiffFreq As System.Windows.Forms.Label
    Friend WithEvents lblRecNum4 As System.Windows.Forms.Label
    Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFreqCapcodeManagement))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.lblCusts = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.btnGenerateCapcode = New System.Windows.Forms.Button()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSeed = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFreq = New C1.Win.C1List.C1Combo()
        Me.btnAddAnyCapCode = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.lblRecNum = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnCopySelectedRows = New System.Windows.Forms.Button()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnRefreash = New System.Windows.Forms.Button()
        Me.lblRecNum3 = New System.Windows.Forms.Label()
        Me.lblNewCapcode = New System.Windows.Forms.Label()
        Me.lblDupCapcode = New System.Windows.Forms.Label()
        Me.lblRecNum2 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblDupCapcodesDiffFreq = New System.Windows.Forms.Label()
        Me.lblRecNum4 = New System.Windows.Forms.Label()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBox1.SuspendLayout()
        CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Navy
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(456, 16)
        Me.lblTitle.TabIndex = 1
        '
        'cboCustomers
        '
        Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCustomers.Caption = ""
        Me.cboCustomers.CaptionHeight = 17
        Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCustomers.ColumnCaptionHeight = 17
        Me.cboCustomers.ColumnFooterHeight = 17
        Me.cboCustomers.ContentHeight = 15
        Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCustomers.EditorHeight = 15
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(120, 24)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(256, 21)
        Me.cboCustomers.TabIndex = 2
        Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'lblCusts
        '
        Me.lblCusts.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCusts.ForeColor = System.Drawing.Color.Black
        Me.lblCusts.Location = New System.Drawing.Point(40, 24)
        Me.lblCusts.Name = "lblCusts"
        Me.lblCusts.Size = New System.Drawing.Size(80, 20)
        Me.lblCusts.TabIndex = 169
        Me.lblCusts.Text = "Customer:"
        Me.lblCusts.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(24, 56)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(93, 21)
        Me.Label32.TabIndex = 168
        Me.Label32.Text = "Frequency:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnGenerateCapcode
        '
        Me.btnGenerateCapcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateCapcode.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnGenerateCapcode.Location = New System.Drawing.Point(152, 152)
        Me.btnGenerateCapcode.Name = "btnGenerateCapcode"
        Me.btnGenerateCapcode.Size = New System.Drawing.Size(168, 32)
        Me.btnGenerateCapcode.TabIndex = 175
        Me.btnGenerateCapcode.Text = "Generate Capcodes"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(120, 120)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(136, 20)
        Me.txtQty.TabIndex = 178
        Me.txtQty.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(88, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 21)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "Qty:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSeed
        '
        Me.txtSeed.Location = New System.Drawing.Point(120, 88)
        Me.txtSeed.Name = "txtSeed"
        Me.txtSeed.Size = New System.Drawing.Size(136, 20)
        Me.txtSeed.TabIndex = 176
        Me.txtSeed.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 21)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "Capcode  Seed:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboFreq
        '
        Me.cboFreq.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboFreq.Caption = ""
        Me.cboFreq.CaptionHeight = 17
        Me.cboFreq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFreq.ColumnCaptionHeight = 17
        Me.cboFreq.ColumnFooterHeight = 17
        Me.cboFreq.ContentHeight = 15
        Me.cboFreq.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFreq.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFreq.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFreq.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFreq.EditorHeight = 15
        Me.cboFreq.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboFreq.ItemHeight = 15
        Me.cboFreq.Location = New System.Drawing.Point(120, 56)
        Me.cboFreq.MatchEntryTimeout = CType(2000, Long)
        Me.cboFreq.MaxDropDownItems = CType(5, Short)
        Me.cboFreq.MaxLength = 32767
        Me.cboFreq.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFreq.Name = "cboFreq"
        Me.cboFreq.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFreq.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFreq.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFreq.Size = New System.Drawing.Size(144, 21)
        Me.cboFreq.TabIndex = 180
        Me.cboFreq.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
        "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
        "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
        "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'btnAddAnyCapCode
        '
        Me.btnAddAnyCapCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddAnyCapCode.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnAddAnyCapCode.Location = New System.Drawing.Point(8, 152)
        Me.btnAddAnyCapCode.Name = "btnAddAnyCapCode"
        Me.btnAddAnyCapCode.Size = New System.Drawing.Size(128, 32)
        Me.btnAddAnyCapCode.TabIndex = 181
        Me.btnAddAnyCapCode.Text = "Enter Any Capcode"
        Me.ToolTip1.SetToolTip(Me.btnAddAnyCapCode, "Enter any capcode")
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.Location = New System.Drawing.Point(32, 208)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 277)
        Me.ListBox1.TabIndex = 182
        '
        'lblRecNum
        '
        Me.lblRecNum.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRecNum.Location = New System.Drawing.Point(32, 485)
        Me.lblRecNum.Name = "lblRecNum"
        Me.lblRecNum.Size = New System.Drawing.Size(120, 16)
        Me.lblRecNum.TabIndex = 183
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnSave.Location = New System.Drawing.Point(328, 152)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 32)
        Me.btnSave.TabIndex = 184
        Me.btnSave.Text = "Save"
        '
        'grpBox1
        '
        Me.grpBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDelete, Me.btnCopySelectedRows, Me.btnCopyAll, Me.tdgData1, Me.btnRefreash, Me.lblRecNum3})
        Me.grpBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBox1.Location = New System.Drawing.Point(472, 24)
        Me.grpBox1.Name = "grpBox1"
        Me.grpBox1.Size = New System.Drawing.Size(328, 480)
        Me.grpBox1.TabIndex = 185
        Me.grpBox1.TabStop = False
        Me.grpBox1.Text = "View Available Capcodes"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnDelete.ForeColor = System.Drawing.Color.Red
        Me.btnDelete.Location = New System.Drawing.Point(224, 8)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 24)
        Me.btnDelete.TabIndex = 189
        Me.btnDelete.Text = "Delete"
        Me.ToolTip1.SetToolTip(Me.btnDelete, "Select a row or rows to delete")
        '
        'btnCopySelectedRows
        '
        Me.btnCopySelectedRows.BackColor = System.Drawing.Color.LightBlue
        Me.btnCopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.Sienna
        Me.btnCopySelectedRows.Location = New System.Drawing.Point(192, 40)
        Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
        Me.btnCopySelectedRows.Size = New System.Drawing.Size(128, 24)
        Me.btnCopySelectedRows.TabIndex = 188
        Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.BackColor = System.Drawing.Color.LightBlue
        Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAll.ForeColor = System.Drawing.Color.Sienna
        Me.btnCopyAll.Location = New System.Drawing.Point(96, 40)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(88, 24)
        Me.btnCopyAll.TabIndex = 187
        Me.btnCopyAll.Text = "Copy All Rows"
        '
        'tdgData1
        '
        Me.tdgData1.AllowUpdate = False
        Me.tdgData1.AlternatingRows = True
        Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
        Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tdgData1.FetchRowStyles = True
        Me.tdgData1.FilterBar = True
        Me.tdgData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.tdgData1.Location = New System.Drawing.Point(8, 64)
        Me.tdgData1.Name = "tdgData1"
        Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData1.PreviewInfo.ZoomFactor = 75
        Me.tdgData1.Size = New System.Drawing.Size(312, 392)
        Me.tdgData1.TabIndex = 186
        Me.tdgData1.Text = "C1TrueDBGrid1"
        Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
        "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelect" & _
        "or{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised," & _
        ",1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:N" & _
        "ear;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
        "Grid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Mar" & _
        "queeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertic" & _
        "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>390</Height><CaptionStyle pa" & _
        "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
        "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
        "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
        """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
        "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
        "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
        "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
        "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 310, 390</ClientRect><BorderSide>0</" & _
        "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
        "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
        "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
        """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
        " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
        " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
        "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
        """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
        "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
        "ecSelWidth><ClientArea>0, 0, 310, 390</ClientArea><PrintPageHeaderStyle parent=""" & _
        """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'btnRefreash
        '
        Me.btnRefreash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreash.ForeColor = System.Drawing.Color.Green
        Me.btnRefreash.Location = New System.Drawing.Point(8, 32)
        Me.btnRefreash.Name = "btnRefreash"
        Me.btnRefreash.Size = New System.Drawing.Size(80, 32)
        Me.btnRefreash.TabIndex = 185
        Me.btnRefreash.Text = "Refresh"
        '
        'lblRecNum3
        '
        Me.lblRecNum3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRecNum3.Location = New System.Drawing.Point(8, 456)
        Me.lblRecNum3.Name = "lblRecNum3"
        Me.lblRecNum3.Size = New System.Drawing.Size(208, 16)
        Me.lblRecNum3.TabIndex = 186
        '
        'lblNewCapcode
        '
        Me.lblNewCapcode.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNewCapcode.Location = New System.Drawing.Point(32, 192)
        Me.lblNewCapcode.Name = "lblNewCapcode"
        Me.lblNewCapcode.Size = New System.Drawing.Size(104, 16)
        Me.lblNewCapcode.TabIndex = 186
        Me.lblNewCapcode.Text = "New Capcodes"
        '
        'lblDupCapcode
        '
        Me.lblDupCapcode.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDupCapcode.Location = New System.Drawing.Point(160, 192)
        Me.lblDupCapcode.Name = "lblDupCapcode"
        Me.lblDupCapcode.Size = New System.Drawing.Size(128, 16)
        Me.lblDupCapcode.TabIndex = 189
        Me.lblDupCapcode.Text = "Dup. Cap w/ Same Freq"
        '
        'lblRecNum2
        '
        Me.lblRecNum2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRecNum2.Location = New System.Drawing.Point(160, 485)
        Me.lblRecNum2.Name = "lblRecNum2"
        Me.lblRecNum2.Size = New System.Drawing.Size(120, 16)
        Me.lblRecNum2.TabIndex = 188
        '
        'ListBox2
        '
        Me.ListBox2.HorizontalScrollbar = True
        Me.ListBox2.Location = New System.Drawing.Point(160, 208)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(120, 277)
        Me.ListBox2.TabIndex = 187
        '
        'tdgData2
        '
        Me.tdgData2.AllowUpdate = False
        Me.tdgData2.AlternatingRows = True
        Me.tdgData2.BackColor = System.Drawing.Color.GhostWhite
        Me.tdgData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tdgData2.FetchRowStyles = True
        Me.tdgData2.FilterBar = True
        Me.tdgData2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgData2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.tdgData2.Location = New System.Drawing.Point(288, 208)
        Me.tdgData2.Name = "tdgData2"
        Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData2.PreviewInfo.ZoomFactor = 75
        Me.tdgData2.Size = New System.Drawing.Size(172, 280)
        Me.tdgData2.TabIndex = 190
        Me.tdgData2.Text = "C1TrueDBGrid1"
        Me.tdgData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
        "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelect" & _
        "or{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised" & _
        ",,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:N" & _
        "ear;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
        "Grid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Mar" & _
        "queeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertic" & _
        "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>278</Height><CaptionStyle pa" & _
        "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
        "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
        "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
        """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
        "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
        "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
        "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
        "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 170, 278</ClientRect><BorderSide>0</" & _
        "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
        "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
        "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
        """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
        " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
        " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
        "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
        """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
        "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
        "ecSelWidth><ClientArea>0, 0, 170, 278</ClientArea><PrintPageHeaderStyle parent=""" & _
        """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'lblDupCapcodesDiffFreq
        '
        Me.lblDupCapcodesDiffFreq.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDupCapcodesDiffFreq.Location = New System.Drawing.Point(288, 192)
        Me.lblDupCapcodesDiffFreq.Name = "lblDupCapcodesDiffFreq"
        Me.lblDupCapcodesDiffFreq.Size = New System.Drawing.Size(160, 16)
        Me.lblDupCapcodesDiffFreq.TabIndex = 191
        Me.lblDupCapcodesDiffFreq.Text = "Dup. Cap w/ Diff. Freq"
        '
        'lblRecNum4
        '
        Me.lblRecNum4.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRecNum4.Location = New System.Drawing.Point(288, 488)
        Me.lblRecNum4.Name = "lblRecNum4"
        Me.lblRecNum4.Size = New System.Drawing.Size(120, 16)
        Me.lblRecNum4.TabIndex = 192
        '
        'frmFreqCapcodeManagement
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(816, 509)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRecNum4, Me.lblDupCapcodesDiffFreq, Me.tdgData2, Me.lblDupCapcode, Me.lblRecNum2, Me.ListBox2, Me.lblNewCapcode, Me.grpBox1, Me.btnSave, Me.lblRecNum, Me.ListBox1, Me.btnAddAnyCapCode, Me.cboFreq, Me.txtQty, Me.Label2, Me.txtSeed, Me.Label1, Me.btnGenerateCapcode, Me.lblCusts, Me.Label32, Me.cboCustomers, Me.lblTitle})
        Me.Name = "frmFreqCapcodeManagement"
        Me.Text = "frmFreqCapcodeManagement"
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFreq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBox1.ResumeLayout(False)
        CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '***************************************************************************************
    Private Sub frmFreqCapcodeManagement_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Me.lblTitle.Text = Me._strScreenName
            'MessageBox.Show(Me._strScreenName)
            Dim objMessaging As PSS.Data.Buisness.Messaging
            Dim dt As DataTable

            Me.ListBox1.Visible = False : Me.btnSave.Enabled = False
            Me.ListBox2.Visible = False : Me.tdgData2.Visible = False
            Me.lblNewCapcode.Visible = False : Me.lblDupCapcode.Visible = False
            Me.lblDupCapcodesDiffFreq.Visible = False

            dt = Generic.GetCustomers(True, 1)
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
            Me.cboCustomers.SelectedValue = Me._iMenuCustID
            Me.cboCustomers.Enabled = False

            objMessaging = New PSS.Data.Buisness.Messaging()
            dt = objMessaging.GetFrequencies(True)
            Misc.PopulateC1DropDownList(Me.cboFreq, dt, "Freq_Number", "Freq_ID")
            Me.cboFreq.SelectedValue = 0


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub frmFreqCapcodeManagement_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '***************************************************************************************
    Private Sub btnGenerateCapcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateCapcode.Click
        Dim strSeed As String
        Dim strS As String
        Dim strNumberPart As String = ""
        Dim strStringPart As String = ""
        Dim iL As Integer = 0, i As Integer = 0
        Dim iMaxNumber As Integer = 0, iStartNumber As Integer = 0
        Dim iQty As Integer = 0
        Dim bFoundFirstString As Boolean = False
        Dim arrResult As New ArrayList()

        Me.lblRecNum.Text = "" : Me.ListBox1.Items.Clear()

        Try
            If Me.cboFreq.SelectedValue > 0 Then
                _iSelectedFreqID = Me.cboFreq.SelectedValue

                If Me.txtSeed.Text.Trim.Length > 0 _
                  AndAlso Me.txtQty.Text.Trim.Length > 0 _
                  AndAlso IsNumeric(Me.txtQty.Text.Trim) Then
                    strSeed = Me.txtSeed.Text.Trim
                    iQty = CInt(Me.txtQty.Text)

                    iL = strSeed.Length
                    For i = iL - 1 To 0 Step -1
                        ListBox1.Items.Add(strSeed.Substring(i, 1))
                        strS = strSeed.Substring(i, 1)
                        If IsCorrectSingleNumber(strS) = True AndAlso bFoundFirstString = False Then
                            strNumberPart = strS & strNumberPart
                        Else
                            bFoundFirstString = True
                            strStringPart = strS & strStringPart
                        End If
                    Next

                    If strNumberPart.Length Then
                        iMaxNumber = 10 ^ strNumberPart.Length - 1
                    End If
                    If strNumberPart.Length > 0 Then iStartNumber = CInt(strNumberPart)

                    Me.ListBox1.Items.Clear()
                    If Not strNumberPart.Length > 0 Then
                        MessageBox.Show("Invalid seed (Seed has no number(s) at its end).")
                    ElseIf iMaxNumber > iStartNumber Then
                        If Not iQty > 0 Then
                            MessageBox.Show("Qty must be greater than 0")
                        ElseIf iQty <= (iMaxNumber - iStartNumber) Then
                            arrResult = GenerateCapcode(iQty, iStartNumber, strStringPart, strNumberPart)
                            For i = 0 To arrResult.Count - 1
                                If i <= iQty - 1 Then
                                    Me.ListBox1.Items.Add(arrResult(i))
                                End If
                            Next
                            Me.lblRecNum.Text = "Count: " & ListBox1.Items.Count
                            ValidateDuplicates()
                        Else
                            MessageBox.Show("Qty is too big. Max Qty can be " & (iMaxNumber - iStartNumber).ToString)
                        End If

                        'Me.txtPart1.Text = strStringPart
                        'Me.txtPart2.Text = strNumberPart & "    " & iStartNumber & "    " & iMaxNumber
                    Else
                        MessageBox.Show("Max number is less than start number!")
                    End If
                Else
                    MessageBox.Show("Please enter valid values in Seed and Qty boxes!")
                End If
            Else
                MessageBox.Show("Please select a frequency.", "Exception Msg", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub btnGenerateCapcode_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***************************************************************************************
    Private Function GenerateCapcode(ByVal iQty As Integer, _
                                 ByVal iStartNumber As Integer, _
                                 ByVal strStringPart As String, _
                                 ByVal strNumberPart As String) As ArrayList

        Dim iStopNumber As Integer = iStartNumber + iQty
        ' Dim iZeroLen As Integer = strNumberPart.Length - iStartNumber.ToString.Length
        Dim i, j As Integer
        Dim arrResult As New ArrayList()
        Dim strS As String
        Dim decimalLength As Integer
        Try
            For i = iStartNumber To iStopNumber
                decimalLength = i.ToString("D").Length + (strNumberPart.Length - i.ToString.Length)
                strS = i.ToString("D" + decimalLength.ToString())
                arrResult.Add(strStringPart.ToUpper & strS)
            Next

            Return arrResult
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Function GenerateCapcode", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    '***************************************************************************************
    Private Function IsCorrectSingleNumber(ByVal strS As String) As Boolean
        Try
            strS = strS.Trim
            If Not IsNumeric(strS) Then
                Return False
            ElseIf strS.Length = 1 Then
                Dim i As Integer = CInt(strS)
                Select Case i
                    Case 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
                        Return True
                End Select
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Function IsCorrectSingleNumber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    '***************************************************************************************
    Private Sub ValidateDuplicates()
        'Freq_Number, CapCode, Freq_ID, Cust_ID, FCP_ID
        Dim iAvailable As Integer = 1
        Dim objMessaging As PSS.Data.Buisness.Messaging
        Dim j As Integer
        Dim dt, dtTmp, dtTmp2 As DataTable
        Dim row As DataRow
        Dim iPrimIDs As New ArrayList()

        Try
            If Not Me.ListBox1.Items.Count > 0 Then
                Exit Sub
            End If

            'validate capcodes--------------------------------------------------------------------------------------
            Me.ListBox2.Items.Clear() : Me.tdgData2.DataSource = Nothing
            objMessaging = New PSS.Data.Buisness.Messaging()

            'Same Freq 
            For j = 0 To Me.ListBox1.Items.Count - 1
                dt = objMessaging.GetMessagingDuplicatedFreqCapcodes(Me._iMenuCustID, iAvailable, Me._iSelectedFreqID, ListBox1.Items(j), True)
                For Each row In dt.Rows
                    Me.ListBox2.Items.Add(ListBox1.Items(j))
                Next
            Next
            Me.lblRecNum2.Text = "Count: " & Me.ListBox2.Items.Count
            Me.lblRecNum4.Text = "Count: 0"

            'Different Freq
            For j = 0 To Me.ListBox1.Items.Count - 1
                dt = objMessaging.GetMessagingDuplicatedFreqCapcodes(Me._iMenuCustID, iAvailable, Me._iSelectedFreqID, ListBox1.Items(j), False)
                If j = 0 Then dtTmp = dt.Clone
                For Each row In dt.Rows
                    dtTmp.ImportRow(row)
                Next
            Next
            If dtTmp.Rows.Count > 0 Then 'remove dup rows
                dtTmp2 = dtTmp.Clone
                For Each row In dtTmp.Rows
                    If Not iPrimIDs.Contains(row("FCP_ID")) Then
                        iPrimIDs.Add(row("FCP_ID"))
                        dtTmp2.ImportRow(row)
                    End If
                Next
                If dtTmp2.Rows.Count > 0 Then 'bind data
                    Me.tdgData2.DataSource = dtTmp
                    Me.tdgData2.Splits(0).DisplayColumns("Cust_ID").Width = 0
                    Me.tdgData2.Splits(0).DisplayColumns("Freq_ID").Width = 0
                    Me.tdgData2.Splits(0).DisplayColumns("FCP_ID").Width = 0
                    Me.lblRecNum4.Text = "Count: " & dtTmp.Rows.Count
                End If
            End If

            ResetValues_On()
            Me.btnSave.Enabled = True

            objMessaging = Nothing : dt = Nothing : dtTmp = Nothing : dtTmp2 = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub ValidateDuplicates", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***************************************************************************************
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '  Freq_ID,CapCode,Available,Cust_ID,UserID,UpdateDatetime'
        Dim iAvailable As Integer = 1
        Dim iUserID As Integer
        Dim strUpdateDTime, strCapCode As String
        Dim objMessaging As PSS.Data.Buisness.Messaging
        Dim i, j, iFreqID As Integer
        Dim dt As DataTable
        Dim row As DataRow

        Try
            If Not Me.ListBox1.Items.Count > 0 Then
                MessageBox.Show("Nothing to save.", "Exception Msg", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me._iSelectedFreqID > 0 Then
                iUserID = PSS.Core.ApplicationUser.IDuser
                strUpdateDTime = Format(Now(), "yyyy-MM-dd HH:mm:ss")
                objMessaging = New PSS.Data.Buisness.Messaging()

                If Me.ListBox1.Items.Count > 0 Then
                    ValidateDuplicates()
                    'Save capcodes----------------------------------------------------------------------------------------------
                    If Me.tdgData2.RowCount > 0 Or Me.ListBox2.Items.Count > 0 Then
                        MessageBox.Show("Duplicate capcode(s). Nothing to save. Please retry.", "Exception Msg", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        'Save it now
                        For j = 0 To Me.ListBox1.Items.Count - 1
                            strCapCode = ListBox1.Items(j)
                            i = objMessaging.SaveMessagingFreqCapcodes(Me._iMenuCustID, iUserID, Me._iSelectedFreqID, iAvailable, strCapCode, strUpdateDTime)
                        Next
                        MessageBox.Show("Completed!", "Have done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ResetValues(sender, e)
                        btnRefreash_Click(sender, e)
                    End If
                Else
                    MessageBox.Show("Nothing to save.", "Exception Msg", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                objMessaging = Nothing
            Else
                MessageBox.Show("Invalid frequency ID.", "Exception Msg", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***************************************************************************************
    Private Sub RefreshExistingAvailableFreqCapcodes()
        Dim objMessaging As PSS.Data.Buisness.Messaging
        Dim dt As DataTable
        '  Freq_ID,CapCode,Available,Cust_ID,UserID,UpdateDatetime'
        Try
            Me.lblRecNum3.Text = "" : Me.tdgData1.Visible = False
            objMessaging = New PSS.Data.Buisness.Messaging()
            dt = objMessaging.GetMessagingFreqCapcodes(Me._iMenuCustID, 1)
            Me.tdgData1.DataSource = dt
            Me.tdgData1.Splits(0).DisplayColumns("Available").Width = 0
            Me.tdgData1.Splits(0).DisplayColumns("Cust_ID").Width = 0
            Me.tdgData1.Splits(0).DisplayColumns("Freq_ID").Width = 0
            Me.tdgData1.Splits(0).DisplayColumns("UserID").Width = 0
            Me.tdgData1.Splits(0).DisplayColumns("FCP_ID").Width = 0

            Me.lblRecNum3.Text = "Count: " & dt.Rows.Count
            Me.tdgData1.Visible = True
            objMessaging = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub RefreshExistingAvailableFreqCapcodes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    '***************************************************************************************
    Private Sub ResetValues(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFreq.SelectedValueChanged, txtSeed.TextChanged, txtQty.TextChanged
        Dim objMessaging As PSS.Data.Buisness.Messaging
        Dim dt As DataTable

        Try
            Me.ListBox1.Items.Clear() : Me.ListBox1.Visible = False
            Me.ListBox2.Items.Clear() : Me.ListBox2.Visible = False
            Me.tdgData2.DataSource = Nothing : Me.tdgData2.Visible = False
            Me.lblDupCapcode.Visible = False : Me.lblNewCapcode.Visible = False
            Me.lblDupCapcodesDiffFreq.Visible = False
            Me.lblRecNum.Visible = False : Me.lblRecNum2.Visible = False : Me.lblRecNum4.Visible = False

            Me.btnSave.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub ResetValues", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '***************************************************************************************
    Private Sub ResetValues_On()
        Me.ListBox1.Visible = True
        Me.ListBox2.Visible = True : Me.tdgData2.Visible = True
        Me.lblNewCapcode.Visible = True : Me.lblDupCapcode.Visible = True
        Me.lblDupCapcodesDiffFreq.Visible = True
        Me.lblDupCapcode.Visible = True : Me.lblNewCapcode.Visible = True
        Me.lblDupCapcodesDiffFreq.Visible = True
        Me.lblRecNum.Visible = True : Me.lblRecNum2.Visible = True : Me.lblRecNum4.Visible = True
    End Sub

    '***************************************************************************************
    Private Sub btnRefreash_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefreash.Click
        RefreshExistingAvailableFreqCapcodes()
    End Sub

    '***************************************************************************************
    Private Sub btnAddAnyCapCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddAnyCapCode.Click
        Dim message, title, defaultValue As String
        Dim strCapCode As Object
        Dim i As Integer = 0

        Try
            message = "Enter a capcode."
            title = "InputBoxo"
            defaultValue = ""
            strCapCode = InputBox(message, title, defaultValue)

            ResetValues(sender, e)

            ' MessageBox.Show(Me.cboFreq.SelectedText)
            If Me.cboFreq.SelectedValue > 0 Then
                _iSelectedFreqID = Me.cboFreq.SelectedValue
                If strCapCode.trim.length > 0 Then
                    Me.ListBox1.Items.Add(strCapCode)
                    Me.ValidateDuplicates()

                    'message = "Do you want to save this capcode '" & strCapCode & "' and Frequency '" & Me.cboFreq.SelectedText & "'?"
                    'title = "Y/N"
                    'Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or _
                    '  MsgBoxStyle.Critical
                    'Dim response = MsgBox(message, style, title)

                    'If response = MsgBoxResult.Yes Then
                    '    Me.ListBox1.Items.Add(strCapCode)
                    '    Me.ValidateDuplicates()

                    '    'Dim objMessaging As New PSS.Data.Buisness.Messaging()
                    '    'i = objMessaging.SaveMessagingFreqCapcodes(Me._iMenuCustID, PSS.Core.ApplicationUser.IDuser, _
                    '    '                                           Me.cboFreq.SelectedValue, 1, strCapCode, Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                    '    'objMessaging = Nothing
                    'End If
                End If
            Else
                MessageBox.Show("Select a valid frequency.", "Sub  btnAddAnyCapCode_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub  btnAddAnyCapCode_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '*********************************************************************************************************************
    Private Sub btnCopyAll_btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click, btnCopySelectedRows.Click
        Try
            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            If sender.name = "btnCopyAll" Then
                Misc.CopyAllData(Me.tdgData1)
            ElseIf sender.name = "btnCopySelectedRows" Then
                Misc.CopySelectedRowsData(Me.tdgData1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
        End Try
    End Sub

    '***************************************************************************************
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim message, title As String
        Dim iRow As Integer, j As Integer = 0
        Dim strFreqCapCode As String = ""
        Dim strFCP_IDs As String = ""
        Dim objMessaging As PSS.Data.Buisness.Messaging


        With Me.tdgData1
            If .SelectedRows.Count > 0 Then
                For Each iRow In .SelectedRows
                    If j = 0 Then
                        strFCP_IDs = .Columns("FCP_ID").CellText(iRow)
                        strFreqCapCode = .Columns("Freq_Number").CellText(iRow) & "(" & .Columns("CapCode").CellText(iRow) & ")"
                    Else
                        strFCP_IDs &= "," & .Columns("FCP_ID").CellText(iRow)
                        strFreqCapCode &= ", " & .Columns("Freq_Number").CellText(iRow) & "(" & .Columns("CapCode").CellText(iRow) & ")"
                    End If
                    j = +1
                Next

                message = "Do you want to delete " & IIf(.SelectedRows.Count < 2, "this ", "these ") & .SelectedRows.Count.ToString & IIf(.SelectedRows.Count < 2, " capcode", " capcodes") & "?" & Environment.NewLine
                message &= strFreqCapCode

                Dim style = MsgBoxStyle.YesNo : title = "Your Confirmation"
                Dim response = MsgBox(message, style, title)
                If response = MsgBoxResult.Yes Then
                    objMessaging = New PSS.Data.Buisness.Messaging()
                    j = objMessaging.DeleteMessagingFreqCapcodes(strFCP_IDs)
                    If j > 0 Then
                        RefreshExistingAvailableFreqCapcodes()
                        MessageBox.Show("Deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        MessageBox.Show("Failed to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Else
                MessageBox.Show("Please select a row or a range of rows to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End With
    End Sub

    '***************************************************************************************

End Class
