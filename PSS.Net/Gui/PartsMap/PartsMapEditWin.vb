Option Explicit On 

Imports PSS.Rules.PartsMap
Imports PSS.Data.Buisness

Namespace Gui
    Public Class PartsMapEditWin
        Inherits System.Windows.Forms.Form

        Private _map_id
        Private _prod_id As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal mapid As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._map_id = mapid
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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnAddUpdate As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents cboPartNo As C1.Win.C1List.C1Combo
        Friend WithEvents cboBillCode As C1.Win.C1List.C1Combo
        Friend WithEvents cboLaborLvl As C1.Win.C1List.C1Combo
        Friend WithEvents cboLineOfBusiness As C1.Win.C1List.C1Combo
        Friend WithEvents chkInvisible As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PartsMapEditWin))
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnAddUpdate = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.cboPartNo = New C1.Win.C1List.C1Combo()
            Me.cboBillCode = New C1.Win.C1List.C1Combo()
            Me.cboLaborLvl = New C1.Win.C1List.C1Combo()
            Me.cboLineOfBusiness = New C1.Win.C1List.C1Combo()
            Me.chkInvisible = New System.Windows.Forms.CheckBox()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboPartNo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboBillCode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLaborLvl, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLineOfBusiness, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(8, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Model"
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(8, 104)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(112, 16)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Part Number"
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(8, 152)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(112, 16)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "Bill Code"
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(8, 200)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 16)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "Labor Level"
            '
            'btnAddUpdate
            '
            Me.btnAddUpdate.BackColor = System.Drawing.Color.SteelBlue
            Me.btnAddUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnAddUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddUpdate.ForeColor = System.Drawing.Color.White
            Me.btnAddUpdate.Location = New System.Drawing.Point(8, 336)
            Me.btnAddUpdate.Name = "btnAddUpdate"
            Me.btnAddUpdate.Size = New System.Drawing.Size(88, 32)
            Me.btnAddUpdate.TabIndex = 8
            Me.btnAddUpdate.Text = "Add / Update"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(112, 336)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(88, 32)
            Me.btnCancel.TabIndex = 9
            Me.btnCancel.Text = "Cancel"
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(8, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(112, 16)
            Me.Label5.TabIndex = 10
            Me.Label5.Text = "Product Type"
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(9, 248)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(112, 16)
            Me.Label6.TabIndex = 11
            Me.Label6.Text = "Line of Business"
            '
            'cboProduct
            '
            Me.cboProduct.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProduct.AutoCompletion = True
            Me.cboProduct.AutoDropDown = True
            Me.cboProduct.AutoSelect = True
            Me.cboProduct.Caption = ""
            Me.cboProduct.CaptionHeight = 17
            Me.cboProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProduct.ColumnCaptionHeight = 17
            Me.cboProduct.ColumnFooterHeight = 17
            Me.cboProduct.ContentHeight = 16
            Me.cboProduct.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProduct.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProduct.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProduct.EditorHeight = 16
            Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(8, 24)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(10, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(192, 22)
            Me.cboProduct.TabIndex = 1
            Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.AutoCompletion = True
            Me.cboModel.AutoDropDown = True
            Me.cboModel.AutoSelect = True
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ContentHeight = 16
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 16
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(8, 72)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(10, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(192, 22)
            Me.cboModel.TabIndex = 2
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboPartNo
            '
            Me.cboPartNo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPartNo.AutoCompletion = True
            Me.cboPartNo.AutoDropDown = True
            Me.cboPartNo.AutoSelect = True
            Me.cboPartNo.Caption = ""
            Me.cboPartNo.CaptionHeight = 17
            Me.cboPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPartNo.ColumnCaptionHeight = 17
            Me.cboPartNo.ColumnFooterHeight = 17
            Me.cboPartNo.ContentHeight = 16
            Me.cboPartNo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPartNo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPartNo.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPartNo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPartNo.EditorHeight = 16
            Me.cboPartNo.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboPartNo.ItemHeight = 15
            Me.cboPartNo.Location = New System.Drawing.Point(8, 120)
            Me.cboPartNo.MatchEntryTimeout = CType(2000, Long)
            Me.cboPartNo.MaxDropDownItems = CType(10, Short)
            Me.cboPartNo.MaxLength = 32767
            Me.cboPartNo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPartNo.Name = "cboPartNo"
            Me.cboPartNo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPartNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPartNo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPartNo.Size = New System.Drawing.Size(192, 22)
            Me.cboPartNo.TabIndex = 3
            Me.cboPartNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboBillCode
            '
            Me.cboBillCode.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBillCode.AutoCompletion = True
            Me.cboBillCode.AutoDropDown = True
            Me.cboBillCode.AutoSelect = True
            Me.cboBillCode.Caption = ""
            Me.cboBillCode.CaptionHeight = 17
            Me.cboBillCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBillCode.ColumnCaptionHeight = 17
            Me.cboBillCode.ColumnFooterHeight = 17
            Me.cboBillCode.ContentHeight = 16
            Me.cboBillCode.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBillCode.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBillCode.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBillCode.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBillCode.EditorHeight = 16
            Me.cboBillCode.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboBillCode.ItemHeight = 15
            Me.cboBillCode.Location = New System.Drawing.Point(8, 168)
            Me.cboBillCode.MatchEntryTimeout = CType(2000, Long)
            Me.cboBillCode.MaxDropDownItems = CType(10, Short)
            Me.cboBillCode.MaxLength = 32767
            Me.cboBillCode.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBillCode.Name = "cboBillCode"
            Me.cboBillCode.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBillCode.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBillCode.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBillCode.Size = New System.Drawing.Size(192, 22)
            Me.cboBillCode.TabIndex = 4
            Me.cboBillCode.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboLaborLvl
            '
            Me.cboLaborLvl.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLaborLvl.AutoCompletion = True
            Me.cboLaborLvl.AutoDropDown = True
            Me.cboLaborLvl.AutoSelect = True
            Me.cboLaborLvl.Caption = ""
            Me.cboLaborLvl.CaptionHeight = 17
            Me.cboLaborLvl.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLaborLvl.ColumnCaptionHeight = 17
            Me.cboLaborLvl.ColumnFooterHeight = 17
            Me.cboLaborLvl.ContentHeight = 16
            Me.cboLaborLvl.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLaborLvl.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLaborLvl.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLaborLvl.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLaborLvl.EditorHeight = 16
            Me.cboLaborLvl.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboLaborLvl.ItemHeight = 15
            Me.cboLaborLvl.Location = New System.Drawing.Point(8, 216)
            Me.cboLaborLvl.MatchEntryTimeout = CType(2000, Long)
            Me.cboLaborLvl.MaxDropDownItems = CType(10, Short)
            Me.cboLaborLvl.MaxLength = 32767
            Me.cboLaborLvl.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLaborLvl.Name = "cboLaborLvl"
            Me.cboLaborLvl.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLaborLvl.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLaborLvl.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLaborLvl.Size = New System.Drawing.Size(192, 22)
            Me.cboLaborLvl.TabIndex = 5
            Me.cboLaborLvl.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboLineOfBusiness
            '
            Me.cboLineOfBusiness.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLineOfBusiness.AutoCompletion = True
            Me.cboLineOfBusiness.AutoDropDown = True
            Me.cboLineOfBusiness.AutoSelect = True
            Me.cboLineOfBusiness.Caption = ""
            Me.cboLineOfBusiness.CaptionHeight = 17
            Me.cboLineOfBusiness.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLineOfBusiness.ColumnCaptionHeight = 17
            Me.cboLineOfBusiness.ColumnFooterHeight = 17
            Me.cboLineOfBusiness.ContentHeight = 16
            Me.cboLineOfBusiness.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLineOfBusiness.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLineOfBusiness.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLineOfBusiness.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLineOfBusiness.EditorHeight = 16
            Me.cboLineOfBusiness.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboLineOfBusiness.ItemHeight = 15
            Me.cboLineOfBusiness.Location = New System.Drawing.Point(8, 264)
            Me.cboLineOfBusiness.MatchEntryTimeout = CType(2000, Long)
            Me.cboLineOfBusiness.MaxDropDownItems = CType(10, Short)
            Me.cboLineOfBusiness.MaxLength = 32767
            Me.cboLineOfBusiness.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLineOfBusiness.Name = "cboLineOfBusiness"
            Me.cboLineOfBusiness.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLineOfBusiness.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLineOfBusiness.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLineOfBusiness.Size = New System.Drawing.Size(192, 22)
            Me.cboLineOfBusiness.TabIndex = 6
            Me.cboLineOfBusiness.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'chkInvisible
            '
            Me.chkInvisible.Location = New System.Drawing.Point(13, 304)
            Me.chkInvisible.Name = "chkInvisible"
            Me.chkInvisible.Size = New System.Drawing.Size(184, 16)
            Me.chkInvisible.TabIndex = 7
            Me.chkInvisible.Text = "Invisible"
            '
            'PartsMapEditWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(210, 378)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkInvisible, Me.cboLineOfBusiness, Me.cboLaborLvl, Me.cboBillCode, Me.cboPartNo, Me.cboModel, Me.cboProduct, Me.Label6, Me.Label5, Me.btnCancel, Me.btnAddUpdate, Me.Label4, Me.Label3, Me.Label2, Me.Label1})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "PartsMapEditWin"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Edit Mapping"
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboPartNo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboBillCode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLaborLvl, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLineOfBusiness, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************************
        Private Sub PartsMapEditWin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Me._map_id > 0 Then
                    PopulateUpdateValues()
                Else
                    Me.PopulateProducts()
                    Me.PopulateModels()
                    Me.PopulatePartNos()
                    Me.PopulateBillcodes()
                    Me.PopulateLaborLevels()
                    Me.PopulateLineOfBusiness()
                    Me.cboProduct.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PartsMapEditWin_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ''***************************************************************************************
        'Private Sub btnAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUpdate.Click
        '    Dim iInvisible As Integer = 0
        '    Try
        '        If IsNothing(Me.cboProduct.SelectedValue) OrElse Me.cboProduct.SelectedValue = 0 Then
        '            MessageBox.Show("Please select Product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboProduct.Focus()
        '        ElseIf IsNothing(Me.cboModel.SelectedValue) OrElse Me.cboModel.SelectedValue = 0 Then
        '            MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboModel.Focus()
        '        ElseIf IsNothing(Me.cboPartNo.SelectedValue) OrElse Me.cboPartNo.SelectedValue = 0 Then
        '            MessageBox.Show("Please select Product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboPartNo.Focus()
        '        ElseIf IsNothing(Me.cboBillCode.SelectedValue) OrElse Me.cboBillCode.SelectedValue = 0 Then
        '            MessageBox.Show("Please select Billcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboBillCode.Focus()
        '        ElseIf IsNothing(Me.cboLaborLvl.SelectedValue) Then
        '            MessageBox.Show("Please select Labor Level.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboLaborLvl.Focus()
        '        ElseIf IsNothing(Me.cboLineOfBusiness.SelectedValue) Then
        '            MessageBox.Show("Please select Line of Business.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboLineOfBusiness.Focus()
        '        Else
        '            If Me.chkInvisible.Checked = True Then iInvisible = 1

        '            If Me._map_id = 0 Then
        '                If Generic.IsBillcodeMapped(Me.cboModel.SelectedValue, Me.cboBillCode.SelectedValue) > 0 Then
        '                    MessageBox.Show("The combination of Model and Billcode is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                    Me.cboModel.Focus()
        '                    Exit Sub
        '                Else
        '                    InsertDataMap(Me.cboPartNo.SelectedValue, Me.cboBillCode.SelectedValue, Me.cboModel.SelectedValue, Me.cboProduct.SelectedValue, Me.cboLaborLvl.SelectedValue, Me.cboLineOfBusiness.SelectedValue, iInvisible)
        '                    If MessageBox.Show("Add completed." & Environment.NewLine & "Would you like to close the window?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
        '                        Me.Close()
        '                    End If
        '                End If
        '            Else
        '                UpdateDataMap(Me.cboPartNo.SelectedValue, Me.cboBillCode.SelectedValue, Me.cboModel.SelectedValue, Me.cboProduct.SelectedValue, Me.cboLaborLvl.SelectedValue, Me.cboLineOfBusiness.SelectedValue, Me._map_id, iInvisible)
        '                If MessageBox.Show("Update completed." & Environment.NewLine & "Would you like to close the window?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
        '                    Me.Close()
        '                End If
        '            End If

        '            Me.cboPartNo.SelectedValue = 0
        '            Me.cboBillCode.SelectedValue = 0
        '            Me.cboLaborLvl.Text = ""
        '            Me.cboLineOfBusiness.Text = ""
        '            Me.cboPartNo.Focus()
        '            'Me.Close()
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "btnAddUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub

        '***************************************************************************************
        Private Sub cboProduct_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.Leave
            Try
                If Not IsNothing(Me.cboProduct.SelectedValue) AndAlso Me.cboProduct.SelectedValue > 0 AndAlso Me._map_id = 0 Then
                    _prod_id = Me.cboProduct.SelectedValue()
                    Me.cboPartNo.SelectedValue = 0
                    Me.cboLaborLvl.SelectedValue = 0
                    Me.cboLineOfBusiness.SelectedValue = 0
                    Me.PopulateModels()
                    Me.PopulateBillcodes()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProduct_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateProducts(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Product
                Me.cboProduct.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                Me.cboProduct.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateModels(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Model
                Me.cboModel.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = Generic.GetModels(True, Me._prod_id)
                Misc.PopulateC1DropDownList(Me.cboModel, dt, "Model_desc", "Model_id")
                Me.cboModel.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulatePartNos(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Part number
                Me.cboPartNo.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = PartsMap.Pricing()
                dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Misc.PopulateC1DropDownList(Me.cboPartNo, dt, "psprice_number", "psprice_id")
                Me.cboPartNo.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateBillcodes(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Billcode
                Me.cboBillCode.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = Generic.GetBillCodes(True, Me._prod_id)
                Misc.PopulateC1DropDownList(Me.cboBillCode, dt, "Billcode_Desc", "Billcode_ID")
                Me.cboBillCode.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateLaborLevels(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Labor Level
                Me.cboLaborLvl.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = PartsMap.LaborLevels()
                Misc.PopulateC1DropDownList(Me.cboLaborLvl, dt, "laborlvl_desc", "laborlvl_id")
                Me.cboLaborLvl.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateLineOfBusiness(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Business Line
                Me.cboLineOfBusiness.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = PartsMap.LinesOfBusiness()
                Misc.PopulateC1DropDownList(Me.cboLineOfBusiness, dt, "LOB_Desc", "LOB_ID")
                Me.cboLineOfBusiness.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateUpdateValues()
            Dim R1 As DataRow = GetMappedDataItem(Me._map_id)

            Try
                If Not IsNothing(R1) Then
                    Me._prod_id = R1("Prod_ID")

                    Me.PopulateProducts(Me._prod_id)
                    Me.PopulateModels(R1("Model_ID"))
                    Me.PopulatePartNos(R1("PSPrice_ID"))
                    Me.PopulateBillcodes(R1("Billcode_ID"))
                    Me.PopulateLaborLevels(R1("LaborLvl_ID"))
                    Me.PopulateLineOfBusiness(R1("LOB_ID"))
                    Me.cboProduct.Focus()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboProduct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProduct.KeyUp, cboModel.KeyUp, cboPartNo.KeyUp, cboBillCode.KeyUp, cboLaborLvl.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = Me.cboProduct.Name Then
                        If Not IsNothing(Me.cboProduct.SelectedValue) AndAlso Me.cboProduct.SelectedValue > 0 Then Me.cboModel.Focus()
                    ElseIf sender.name = Me.cboModel.Name Then
                        If Not IsNothing(Me.cboModel.SelectedValue) AndAlso Me.cboModel.SelectedValue > 0 Then Me.cboPartNo.Focus()
                    ElseIf sender.name = Me.cboPartNo.Name Then
                        If Not IsNothing(Me.cboPartNo.SelectedValue) AndAlso Me.cboPartNo.SelectedValue > 0 Then Me.cboBillCode.Focus()
                    ElseIf sender.name = Me.cboBillCode.Name Then
                        If Not IsNothing(Me.cboBillCode.SelectedValue) AndAlso Me.cboBillCode.SelectedValue > 0 Then Me.cboLaborLvl.Focus()
                    ElseIf sender.name = Me.cboLaborLvl.Name Then
                        If Not IsNothing(Me.cboLaborLvl.SelectedValue) AndAlso Me.cboLaborLvl.SelectedValue > 0 Then Me.cboLineOfBusiness.Focus()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************

    End Class
End Namespace
