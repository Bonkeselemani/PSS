Public Class frmQC_Codes
    Inherits System.Windows.Forms.Form

    Private objQC As PSS.Data.Buisness.QC
    Private iDCode_ID As Integer = 0
    Private dtCodes As DataTable
    Private _booLoadData As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objQC = New PSS.Data.Buisness.QC()

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCodeDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
    Friend WithEvents cboCodeDesc2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCodeDesc2 As System.Windows.Forms.TextBox
    Friend WithEvents cboCodeDesc As C1.Win.C1List.C1Combo
    Friend WithEvents cboCodes As C1.Win.C1List.C1Combo
    Friend WithEvents cboMCodes As C1.Win.C1List.C1Combo
    Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmQC_Codes))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodeDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCodeDesc2 = New System.Windows.Forms.TextBox()
        Me.chkInactive = New System.Windows.Forms.CheckBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboProduct = New C1.Win.C1List.C1Combo()
        Me.cboMCodes = New C1.Win.C1List.C1Combo()
        Me.cboCodes = New C1.Win.C1List.C1Combo()
        Me.cboCodeDesc = New C1.Win.C1List.C1Combo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboCodeDesc2 = New C1.Win.C1List.C1Combo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCodeDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCodeDesc2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(120, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Code:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(64, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Product:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(168, 33)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(112, 20)
        Me.txtCode.TabIndex = 1
        Me.txtCode.Text = ""
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Yellow
        Me.btnSave.Location = New System.Drawing.Point(168, 168)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 25)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save Code"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(48, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Master Codes:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(40, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Code Description:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodeDesc
        '
        Me.txtCodeDesc.Location = New System.Drawing.Point(168, 64)
        Me.txtCodeDesc.Name = "txtCodeDesc"
        Me.txtCodeDesc.Size = New System.Drawing.Size(312, 20)
        Me.txtCodeDesc.TabIndex = 2
        Me.txtCodeDesc.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(48, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 16)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Code Description:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label10, Me.txtCodeDesc2, Me.chkInactive, Me.btnClear, Me.Label6, Me.Label5, Me.txtCodeDesc, Me.Label2, Me.txtCode, Me.btnSave})
        Me.Panel5.Location = New System.Drawing.Point(7, 208)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(609, 240)
        Me.Panel5.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(27, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 16)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Code Description 2:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodeDesc2
        '
        Me.txtCodeDesc2.Location = New System.Drawing.Point(168, 96)
        Me.txtCodeDesc2.Name = "txtCodeDesc2"
        Me.txtCodeDesc2.Size = New System.Drawing.Size(312, 20)
        Me.txtCodeDesc2.TabIndex = 3
        Me.txtCodeDesc2.Text = ""
        '
        'chkInactive
        '
        Me.chkInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInactive.ForeColor = System.Drawing.Color.Black
        Me.chkInactive.Location = New System.Drawing.Point(72, 136)
        Me.chkInactive.Name = "chkInactive"
        Me.chkInactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkInactive.TabIndex = 4
        Me.chkInactive.Text = "Inactive"
        Me.chkInactive.Visible = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(392, 8)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(208, 24)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "Clear data to Add New Code"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(3, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 17)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Add/Edit Codes"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboProduct, Me.cboMCodes, Me.cboCodes, Me.cboCodeDesc, Me.Label9, Me.cboCodeDesc2, Me.Label8, Me.Label7, Me.Label3, Me.Label4, Me.Label1})
        Me.Panel1.Location = New System.Drawing.Point(7, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(609, 202)
        Me.Panel1.TabIndex = 9
        '
        'cboProduct
        '
        Me.cboProduct.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboProduct.Caption = ""
        Me.cboProduct.CaptionHeight = 17
        Me.cboProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboProduct.ColumnCaptionHeight = 17
        Me.cboProduct.ColumnFooterHeight = 17
        Me.cboProduct.ContentHeight = 15
        Me.cboProduct.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboProduct.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboProduct.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProduct.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboProduct.EditorHeight = 15
        Me.cboProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboProduct.ItemHeight = 15
        Me.cboProduct.Location = New System.Drawing.Point(168, 40)
        Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
        Me.cboProduct.MaxDropDownItems = CType(5, Short)
        Me.cboProduct.MaxLength = 32767
        Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboProduct.Size = New System.Drawing.Size(232, 21)
        Me.cboProduct.TabIndex = 1
        Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
        "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
        "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'cboMCodes
        '
        Me.cboMCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboMCodes.Caption = ""
        Me.cboMCodes.CaptionHeight = 17
        Me.cboMCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMCodes.ColumnCaptionHeight = 17
        Me.cboMCodes.ColumnFooterHeight = 17
        Me.cboMCodes.ContentHeight = 15
        Me.cboMCodes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMCodes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMCodes.EditorHeight = 15
        Me.cboMCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMCodes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboMCodes.ItemHeight = 15
        Me.cboMCodes.Location = New System.Drawing.Point(168, 67)
        Me.cboMCodes.MatchEntryTimeout = CType(2000, Long)
        Me.cboMCodes.MaxDropDownItems = CType(5, Short)
        Me.cboMCodes.MaxLength = 32767
        Me.cboMCodes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMCodes.Name = "cboMCodes"
        Me.cboMCodes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMCodes.Size = New System.Drawing.Size(232, 21)
        Me.cboMCodes.TabIndex = 2
        Me.cboMCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
        "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
        "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'cboCodes
        '
        Me.cboCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCodes.Caption = ""
        Me.cboCodes.CaptionHeight = 17
        Me.cboCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCodes.ColumnCaptionHeight = 17
        Me.cboCodes.ColumnFooterHeight = 17
        Me.cboCodes.ContentHeight = 15
        Me.cboCodes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCodes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCodes.EditorHeight = 15
        Me.cboCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodes.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboCodes.ItemHeight = 15
        Me.cboCodes.Location = New System.Drawing.Point(168, 96)
        Me.cboCodes.MatchEntryTimeout = CType(2000, Long)
        Me.cboCodes.MaxDropDownItems = CType(5, Short)
        Me.cboCodes.MaxLength = 32767
        Me.cboCodes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCodes.Name = "cboCodes"
        Me.cboCodes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCodes.Size = New System.Drawing.Size(232, 21)
        Me.cboCodes.TabIndex = 3
        Me.cboCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
        "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
        "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'cboCodeDesc
        '
        Me.cboCodeDesc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCodeDesc.Caption = ""
        Me.cboCodeDesc.CaptionHeight = 17
        Me.cboCodeDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCodeDesc.ColumnCaptionHeight = 17
        Me.cboCodeDesc.ColumnFooterHeight = 17
        Me.cboCodeDesc.ContentHeight = 15
        Me.cboCodeDesc.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCodeDesc.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCodeDesc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodeDesc.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCodeDesc.EditorHeight = 15
        Me.cboCodeDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodeDesc.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboCodeDesc.ItemHeight = 15
        Me.cboCodeDesc.Location = New System.Drawing.Point(168, 122)
        Me.cboCodeDesc.MatchEntryTimeout = CType(2000, Long)
        Me.cboCodeDesc.MaxDropDownItems = CType(5, Short)
        Me.cboCodeDesc.MaxLength = 32767
        Me.cboCodeDesc.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCodeDesc.Name = "cboCodeDesc"
        Me.cboCodeDesc.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCodeDesc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCodeDesc.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCodeDesc.Size = New System.Drawing.Size(312, 21)
        Me.cboCodeDesc.TabIndex = 4
        Me.cboCodeDesc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
        "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
        "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 16)
        Me.Label9.TabIndex = 93
        Me.Label9.Text = "Code Description 2:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCodeDesc2
        '
        Me.cboCodeDesc2.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCodeDesc2.Caption = ""
        Me.cboCodeDesc2.CaptionHeight = 17
        Me.cboCodeDesc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCodeDesc2.ColumnCaptionHeight = 17
        Me.cboCodeDesc2.ColumnFooterHeight = 17
        Me.cboCodeDesc2.ContentHeight = 15
        Me.cboCodeDesc2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCodeDesc2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCodeDesc2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodeDesc2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCodeDesc2.EditorHeight = 15
        Me.cboCodeDesc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodeDesc2.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.cboCodeDesc2.ItemHeight = 15
        Me.cboCodeDesc2.Location = New System.Drawing.Point(168, 152)
        Me.cboCodeDesc2.MatchEntryTimeout = CType(2000, Long)
        Me.cboCodeDesc2.MaxDropDownItems = CType(5, Short)
        Me.cboCodeDesc2.MaxLength = 32767
        Me.cboCodeDesc2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCodeDesc2.Name = "cboCodeDesc2"
        Me.cboCodeDesc2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCodeDesc2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCodeDesc2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCodeDesc2.Size = New System.Drawing.Size(312, 21)
        Me.cboCodeDesc2.TabIndex = 5
        Me.cboCodeDesc2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
        "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
        "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(64, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Code:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(2, -2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 25)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Existing Codes"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmQC_Codes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(632, 486)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.Panel5})
        Me.Name = "frmQC_Codes"
        Me.Text = "frmQC_Codes"
        Me.Panel5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMCodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCodeDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCodeDesc2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*********************************************************
    Protected Overrides Sub Finalize()
        objQC = Nothing
        MyBase.Finalize()
    End Sub
    '*********************************************************
    Private Sub frmQC_Codes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadProductTypes()
            Me.chkInactive.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "frmQC_Codes_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadProductTypes()
        Dim dtProd As New DataTable()
        Try
            _booLoadData = True
            dtProd = objQC.LoadProductTypes
            Misc.PopulateC1DropDownList(cboProduct, dtProd, "prod_desc", "prod_id")
            Me.cboProduct.SelectedValue = 0
        Catch ex As Exception
            MsgBox("Error in frmQC_Codes.LoadProductTypes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            _booLoadData = False : objQC.DisposeDT(dtProd)
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadMasterCodes()
        Dim dtCodes As New DataTable()
        Try
            _booLoadData = True
            dtCodes = objQC.LoadQCMasterCodes(Me.cboProduct.SelectedValue)
            Misc.PopulateC1DropDownList(cboMCodes, dtCodes, "MCode_Desc", "MCode_ID")
            Me.cboMCodes.SelectedValue = 0
        Catch ex As Exception
            MsgBox("Error in frmQC_Codes.LoadMasterCodes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            _booLoadData = False : objQC.DisposeDT(dtCodes)
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadCodes()
        Dim dt As DataTable

        Try
            If _booLoadData = True Then Exit Sub

            If Me.cboProduct.SelectedValue = 0 Or Me.cboMCodes.SelectedValue = 0 Then Exit Sub

            _booLoadData = True
            dtCodes = objQC.LoadCodes(Me.cboProduct.SelectedValue, Me.cboMCodes.SelectedValue)
            Misc.PopulateC1DropDownList(cboCodes, dtCodes, "DCode_sDesc", "DCode_ID")
            Me.cboCodes.SelectedValue = iDCode_ID

            dt = New DataTable() : dt = dtCodes.Copy
            Misc.PopulateC1DropDownList(Me.cboCodeDesc, dt, "Dcode_Ldesc", "DCode_ID")
            Me.cboCodeDesc.SelectedValue = iDCode_ID

            dt = Nothing : dt = New DataTable() : dt = dtCodes.Copy
            Misc.PopulateC1DropDownList(Me.cboCodeDesc2, dt, "Dcode_L2desc", "DCode_ID")
            Me.cboCodeDesc2.SelectedValue = iDCode_ID

        Catch ex As Exception
            MsgBox("Error in frmQC_Codes.LoadCodes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            _booLoadData = False : PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '*********************************************************
    Private Sub cboProduct_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.RowChange
        Try
            If Me._booLoadData = True Then Exit Sub
            If Me.cboProduct.SelectedValue > 0 Then
                objQC.DisposeDT(dtCodes)
                Me.txtCode.Text = ""
                Me.txtCodeDesc.Text = ""
                Me.chkInactive.Checked = False
                Me.cboMCodes.DataSource = Nothing
                Me.cboCodes.DataSource = Nothing
                Me.cboCodeDesc.DataSource = Nothing
                Me.cboCodeDesc2.DataSource = Nothing
                iDCode_ID = 0
                LoadMasterCodes()
                LoadCodes()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboProduct_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************
    Private Sub cboMCodes_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMCodes.SelectedValueChanged
        Try
            If Me._booLoadData = True Then Exit Sub
            Me.txtCode.Text = ""
            Me.txtCodeDesc.Text = ""
            Me.chkInactive.Checked = False
            Me.cboCodes.DataSource = Nothing
            Me.cboCodeDesc.DataSource = Nothing
            Me.cboCodeDesc2.DataSource = Nothing
            If Me.cboMCodes.SelectedValue > 0 Then
                objQC.DisposeDT(dtCodes)
                Me.LoadCodes()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboMCodes_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cboCodes_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCodes.SelectedValueChanged, cboCodeDesc.SelectedValueChanged, cboCodeDesc2.SelectedValueChanged
        Dim i As Integer = 0

        Try
            If Me._booLoadData = True Then Exit Sub

            If sender.name = "cboCodes" Then
                iDCode_ID = Me.cboCodes.SelectedValue
                Me.cboCodeDesc.SelectedValue = iDCode_ID
                Me.cboCodeDesc2.SelectedValue = iDCode_ID
            ElseIf sender.name = "cboCodeDesc" Then
                iDCode_ID = Me.cboCodeDesc.SelectedValue
                Me.cboCodes.SelectedValue = iDCode_ID
                Me.cboCodeDesc2.SelectedValue = iDCode_ID
            ElseIf sender.name = "cboCodeDesc2" Then
                iDCode_ID = Me.cboCodeDesc2.SelectedValue
                Me.cboCodes.SelectedValue = iDCode_ID
                Me.cboCodeDesc.SelectedValue = iDCode_ID
            End If

            If iDCode_ID <> 0 Then
                System.Windows.Forms.Application.DoEvents()
                Me.txtCode.Text = Me.cboCodes.Text
                Me.txtCodeDesc.Text = Me.cboCodeDesc.Text
                Me.txtCodeDesc2.Text = Me.cboCodeDesc2.Text
                For i = 0 To Me.dtCodes.Rows.Count - 1
                    If iDCode_ID = CInt(Me.dtCodes.Rows(i)("Dcode_Id").ToString()) Then
                        If CInt(Me.dtCodes.Rows(i)("DCode_Inactive").ToString()) = 1 Then
                            Me.chkInactive.Checked = True
                        Else
                            Me.chkInactive.Checked = False
                        End If
                        Exit For
                    End If
                Next
            Else
                Me.txtCode.Text = ""
                Me.txtCodeDesc.Text = ""
                Me.chkInactive.Checked = False
                Me.txtCodeDesc.Text = ""
                Me.txtCodeDesc2.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboCodes_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim i As Integer = 0

        Try
            If Me.cboProduct.SelectedValue = 0 Then
                MessageBox.Show("Please select Product.", "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ElseIf Me.cboMCodes.SelectedValue = 0 Then
                MessageBox.Show("Please select Master Code.", "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ElseIf Me.txtCode.Text.Trim.Length = 0 Or Me.txtCodeDesc.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter code and code description.", "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Else
                If Me.chkInactive.Checked = True Then i = 1

                iDCode_ID = objQC.SaveCode(Me.cboProduct.SelectedValue, Trim(Me.txtCode.Text), Trim(Me.txtCodeDesc.Text), Me.cboMCodes.SelectedValue, iDCode_ID, i, Me.txtCodeDesc2.Text.Trim, Core.ApplicationUser.IDuser)
                MessageBox.Show("Code is created successfully.", "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtCode.Text = ""
                Me.txtCodeDesc.Text = ""
                Me.txtCodeDesc2.Text = ""
                Me.chkInactive.Checked = False
                iDCode_ID = 0
                LoadCodes()
                Me.cboCodes.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtCode.Text = ""
        Me.txtCodeDesc.Text = ""
        Me.txtCodeDesc2.Text = ""
        Me.cboCodes.SelectedValue = 0
        Me.cboCodeDesc.SelectedValue = 0
        Me.cboCodeDesc2.SelectedValue = 0
        iDCode_ID = 0
        Me.chkInactive.Checked = False
    End Sub

    'Private Sub cboCodes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Dim i As Integer = 0
    '    Dim J As Integer = 0
    '    J = Me.cboCodes.SelectedIndex

    '    Try
    '        Me.txtCode.Text = ""
    '        Me.txtCodeDesc.Text = ""
    '        Me.chkInactive.Checked = False
    '        If e.KeyValue = 13 Then
    '            For i = 0 To Me.cboCodes.Items.Count - 1
    '                If Me.cboCodes.Text = Me.cboCodes.Items.Item(i)("DCode_sDesc") Then
    '                    Me.cboCodes.SelectedValue = Me.cboCodes.Items.Item(i)("DCode_ID")
    '                    Me.cboCodeDesc.SelectedValue = Me.cboCodes.Items.Item(i)("DCode_ID")
    '                    Me.iDCode_ID = Me.cboCodes.Items.Item(i)("DCode_ID")
    '                    If iDCode_ID <> 0 Then
    '                        System.Windows.Forms.Application.DoEvents()
    '                        Me.txtCode.Text = Me.cboCodes.Text
    '                        Me.txtCodeDesc.Text = Me.cboCodeDesc.Text
    '                        If CInt(Me.dtCodes.Rows(J)("DCode_Inactive").ToString()) = 1 Then
    '                            Me.chkInactive.Checked = True
    '                        Else
    '                            Me.chkInactive.Checked = False
    '                        End If

    '                    Else
    '                        Me.txtCode.Text = ""
    '                        Me.txtCodeDesc.Text = ""
    '                        Me.chkInactive.Checked = False
    '                    End If
    '                    Exit Sub
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString, "cboCodes_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '    End Try
    'End Sub



End Class
