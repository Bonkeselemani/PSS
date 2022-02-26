Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class SyxEditModel
        Inherits System.Windows.Forms.Form

        Private _objBizSyx As Syx
        Private _booPopulateCombo As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objBizSyx = New Syx()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                _objBizSyx = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblCurrManuf As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblCurrProdDesc As System.Windows.Forms.Label
        Friend WithEvents cboNewManuf As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboNewProdType As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents dbgDevInWIP As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboComsume As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboNeed As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SyxEditModel))
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblCurrManuf = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblCurrProdDesc = New System.Windows.Forms.Label()
            Me.cboNewManuf = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboNewProdType = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.dbgDevInWIP = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboComsume = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboNeed = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboNewManuf, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboNewProdType, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgDevInWIP, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboComsume, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboNeed, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(88, 8)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(192, 21)
            Me.cboModel.TabIndex = 1
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(16, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 23)
            Me.Label2.TabIndex = 89
            Me.Label2.Text = "Model:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrManuf
            '
            Me.lblCurrManuf.BackColor = System.Drawing.Color.White
            Me.lblCurrManuf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCurrManuf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrManuf.ForeColor = System.Drawing.Color.Black
            Me.lblCurrManuf.Location = New System.Drawing.Point(88, 32)
            Me.lblCurrManuf.Name = "lblCurrManuf"
            Me.lblCurrManuf.Size = New System.Drawing.Size(192, 23)
            Me.lblCurrManuf.TabIndex = 90
            Me.lblCurrManuf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(16, 32)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(64, 23)
            Me.Label3.TabIndex = 91
            Me.Label3.Text = "Manuf:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(0, 56)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 23)
            Me.Label4.TabIndex = 93
            Me.Label4.Text = "Product Type:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrProdDesc
            '
            Me.lblCurrProdDesc.BackColor = System.Drawing.Color.White
            Me.lblCurrProdDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCurrProdDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrProdDesc.ForeColor = System.Drawing.Color.Black
            Me.lblCurrProdDesc.Location = New System.Drawing.Point(88, 56)
            Me.lblCurrProdDesc.Name = "lblCurrProdDesc"
            Me.lblCurrProdDesc.Size = New System.Drawing.Size(192, 23)
            Me.lblCurrProdDesc.TabIndex = 92
            Me.lblCurrProdDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboNewManuf
            '
            Me.cboNewManuf.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboNewManuf.Caption = ""
            Me.cboNewManuf.CaptionHeight = 17
            Me.cboNewManuf.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboNewManuf.ColumnCaptionHeight = 17
            Me.cboNewManuf.ColumnFooterHeight = 17
            Me.cboNewManuf.ContentHeight = 15
            Me.cboNewManuf.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboNewManuf.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboNewManuf.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboNewManuf.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboNewManuf.EditorHeight = 15
            Me.cboNewManuf.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboNewManuf.ItemHeight = 15
            Me.cboNewManuf.Location = New System.Drawing.Point(440, 8)
            Me.cboNewManuf.MatchEntryTimeout = CType(2000, Long)
            Me.cboNewManuf.MaxDropDownItems = CType(5, Short)
            Me.cboNewManuf.MaxLength = 32767
            Me.cboNewManuf.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboNewManuf.Name = "cboNewManuf"
            Me.cboNewManuf.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboNewManuf.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboNewManuf.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboNewManuf.Size = New System.Drawing.Size(216, 21)
            Me.cboNewManuf.TabIndex = 2
            Me.cboNewManuf.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(296, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(136, 23)
            Me.Label1.TabIndex = 95
            Me.Label1.Text = "Change Manuf To:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboNewProdType
            '
            Me.cboNewProdType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboNewProdType.Caption = ""
            Me.cboNewProdType.CaptionHeight = 17
            Me.cboNewProdType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboNewProdType.ColumnCaptionHeight = 17
            Me.cboNewProdType.ColumnFooterHeight = 17
            Me.cboNewProdType.ContentHeight = 15
            Me.cboNewProdType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboNewProdType.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboNewProdType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboNewProdType.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboNewProdType.EditorHeight = 15
            Me.cboNewProdType.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboNewProdType.ItemHeight = 15
            Me.cboNewProdType.Location = New System.Drawing.Point(440, 56)
            Me.cboNewProdType.MatchEntryTimeout = CType(2000, Long)
            Me.cboNewProdType.MaxDropDownItems = CType(5, Short)
            Me.cboNewProdType.MaxLength = 32767
            Me.cboNewProdType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboNewProdType.Name = "cboNewProdType"
            Me.cboNewProdType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboNewProdType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboNewProdType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboNewProdType.Size = New System.Drawing.Size(216, 21)
            Me.cboNewProdType.TabIndex = 3
            Me.cboNewProdType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(288, 56)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(144, 23)
            Me.Label5.TabIndex = 97
            Me.Label5.Text = "Change Product Type To:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.Green
            Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(664, 8)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(72, 72)
            Me.btnSave.TabIndex = 4
            Me.btnSave.Text = "Save Changes"
            '
            'dbgDevInWIP
            '
            Me.dbgDevInWIP.AllowColMove = False
            Me.dbgDevInWIP.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgDevInWIP.AllowUpdate = False
            Me.dbgDevInWIP.AllowUpdateOnBlur = False
            Me.dbgDevInWIP.AlternatingRows = True
            Me.dbgDevInWIP.CaptionHeight = 19
            Me.dbgDevInWIP.CollapseColor = System.Drawing.Color.White
            Me.dbgDevInWIP.ExpandColor = System.Drawing.Color.White
            Me.dbgDevInWIP.FilterBar = True
            Me.dbgDevInWIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgDevInWIP.ForeColor = System.Drawing.Color.White
            Me.dbgDevInWIP.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDevInWIP.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgDevInWIP.Location = New System.Drawing.Point(16, 96)
            Me.dbgDevInWIP.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgDevInWIP.Name = "dbgDevInWIP"
            Me.dbgDevInWIP.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDevInWIP.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDevInWIP.PreviewInfo.ZoomFactor = 75
            Me.dbgDevInWIP.RowHeight = 20
            Me.dbgDevInWIP.Size = New System.Drawing.Size(720, 432)
            Me.dbgDevInWIP.TabIndex = 99
            Me.dbgDevInWIP.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{Font:Microsoft Sans Serif, 6.75pt, style" & _
            "=Bold;ForeColor:Black;BackColor:White;}Footer{}Caption{AlignHorz:Center;ForeColo" & _
            "r:White;BackColor:SteelBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, s" & _
            "tyle=Bold;AlignVert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRo" & _
            "w{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{ForeColor:Black;B" & _
            "ackColor:LightSteelBlue;}RecordSelector{ForeColor:White;AlignImage:Center;}Style" & _
            "15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Ce" & _
            "nter;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;AlignVert:Center" & _
            ";}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}S" & _
            "tyle9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fals" & _
            "e"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" C" & _
            "olumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""D" & _
            "ottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGrou" & _
            "p=""1"" HorizontalScrollGroup=""1""><Height>428</Height><CaptionStyle parent=""Style2" & _
            """ me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent" & _
            "=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Foot" & _
            "erStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" />" & _
            "<HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highligh" & _
            "tRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle " & _
            "parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""S" & _
            "tyle11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" " & _
            "me=""Style1"" /><ClientRect>0, 0, 716, 428</ClientRect><BorderSide>0</BorderSide><" & _
            "BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedS" & _
            "tyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Styl" & _
            "e parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style p" & _
            "arent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pa" & _
            "rent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pa" & _
            "rent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=" & _
            """Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style p" & _
            "arent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits" & _
            ">1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><" & _
            "ClientArea>0, 0, 716, 428</ClientArea><PrintPageHeaderStyle parent="""" me=""Style1" & _
            "6"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'cboComsume
            '
            Me.cboComsume.AllowColMove = False
            Me.cboComsume.AllowColSelect = False
            Me.cboComsume.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.cboComsume.AllowSort = False
            Me.cboComsume.AllowUpdate = False
            Me.cboComsume.AllowUpdateOnBlur = False
            Me.cboComsume.AlternatingRows = True
            Me.cboComsume.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cboComsume.CaptionHeight = 19
            Me.cboComsume.CollapseColor = System.Drawing.Color.White
            Me.cboComsume.ExpandColor = System.Drawing.Color.White
            Me.cboComsume.FilterBar = True
            Me.cboComsume.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboComsume.ForeColor = System.Drawing.Color.White
            Me.cboComsume.GroupByCaption = "Drag a column header here to group by that column"
            Me.cboComsume.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboComsume.Location = New System.Drawing.Point(752, 8)
            Me.cboComsume.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.cboComsume.Name = "cboComsume"
            Me.cboComsume.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.cboComsume.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.cboComsume.PreviewInfo.ZoomFactor = 75
            Me.cboComsume.RowHeight = 20
            Me.cboComsume.Size = New System.Drawing.Size(288, 256)
            Me.cboComsume.TabIndex = 100
            Me.cboComsume.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{Font:Microsoft Sans Serif, 6.75pt, style" & _
            "=Bold;ForeColor:Black;BackColor:White;}Footer{}Caption{AlignHorz:Center;ForeColo" & _
            "r:White;BackColor:SteelBlue;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, s" & _
            "tyle=Bold;BackColor:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRo" & _
            "w{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{ForeColor:Black;B" & _
            "ackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;ForeColor:White;}Style" & _
            "13{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Ce" & _
            "nter;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;BackColor:Control" & _
            ";}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style16{}Style17{}S" & _
            "tyle1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fals" & _
            "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
            "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar" & _
            "=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>252</Height><Capt" & _
            "ionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5""" & _
            " /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBa" & _
            "r"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=" & _
            """Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRo" & _
            "wStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""" & _
            "Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent" & _
            "=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" />" & _
            "<Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 284, 252</ClientRect><Bor" & _
            "derSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Mer" & _
            "geView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norma" & _
            "l"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" " & _
            "me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me" & _
            "=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hi" & _
            "ghlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""O" & _
            "ddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me" & _
            "=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1<" & _
            "/vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>1" & _
            "7</DefaultRecSelWidth><ClientArea>0, 0, 284, 252</ClientArea><PrintPageHeaderSty" & _
            "le parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blo" & _
            "b>"
            '
            'cboNeed
            '
            Me.cboNeed.AllowColMove = False
            Me.cboNeed.AllowColSelect = False
            Me.cboNeed.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.cboNeed.AllowSort = False
            Me.cboNeed.AllowUpdate = False
            Me.cboNeed.AllowUpdateOnBlur = False
            Me.cboNeed.AlternatingRows = True
            Me.cboNeed.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cboNeed.CaptionHeight = 19
            Me.cboNeed.CollapseColor = System.Drawing.Color.White
            Me.cboNeed.ExpandColor = System.Drawing.Color.White
            Me.cboNeed.FilterBar = True
            Me.cboNeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboNeed.ForeColor = System.Drawing.Color.White
            Me.cboNeed.GroupByCaption = "Drag a column header here to group by that column"
            Me.cboNeed.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboNeed.Location = New System.Drawing.Point(752, 272)
            Me.cboNeed.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.cboNeed.Name = "cboNeed"
            Me.cboNeed.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.cboNeed.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.cboNeed.PreviewInfo.ZoomFactor = 75
            Me.cboNeed.RowHeight = 20
            Me.cboNeed.Size = New System.Drawing.Size(288, 256)
            Me.cboNeed.TabIndex = 101
            Me.cboNeed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{Font:Microsoft Sans Serif, 6.75pt, style" & _
            "=Bold;ForeColor:Black;BackColor:White;}Footer{}Caption{AlignHorz:Center;ForeColo" & _
            "r:White;BackColor:SteelBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, s" & _
            "tyle=Bold;AlignVert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRo" & _
            "w{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{ForeColor:Black;B" & _
            "ackColor:LightSteelBlue;}RecordSelector{ForeColor:White;AlignImage:Center;}Style" & _
            "15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Ce" & _
            "nter;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;AlignVert:Center" & _
            ";}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}S" & _
            "tyle9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fals" & _
            "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
            "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar" & _
            "=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>252</Height><Capt" & _
            "ionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5""" & _
            " /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBa" & _
            "r"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=" & _
            """Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRo" & _
            "wStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""" & _
            "Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent" & _
            "=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" />" & _
            "<Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 284, 252</ClientRect><Bor" & _
            "derSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Mer" & _
            "geView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norma" & _
            "l"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" " & _
            "me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me" & _
            "=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hi" & _
            "ghlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""O" & _
            "ddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me" & _
            "=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1<" & _
            "/vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>1" & _
            "7</DefaultRecSelWidth><ClientArea>0, 0, 284, 252</ClientArea><PrintPageHeaderSty" & _
            "le parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blo" & _
            "b>"
            '
            'SyxEditModel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1064, 542)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboNeed, Me.cboComsume, Me.dbgDevInWIP, Me.btnSave, Me.cboNewProdType, Me.Label5, Me.cboNewManuf, Me.Label1, Me.Label4, Me.lblCurrProdDesc, Me.Label3, Me.lblCurrManuf, Me.cboModel, Me.Label2})
            Me.Name = "SyxEditModel"
            Me.Text = "SyxEditModel"
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboNewManuf, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboNewProdType, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgDevInWIP, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboComsume, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboNeed, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***********************************************************************************************
        Private Sub SyxEditModel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                dt = Generic.GetManufactures(True)
                Misc.PopulateC1DropDownList(Me.cboNewManuf, dt, "Manuf_Desc", "Manuf_ID")
                Me.cboNewManuf.SelectedValue = 0

                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboNewProdType, dt, "Prod_Desc", "Prod_ID")
                Me.cboNewProdType.SelectedValue = 0

                Me.PopulateModels()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SyxEditModel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************
        Private Sub PopulateModels()
            Dim dt As DataTable

            Try
                dt = _objBizSyx.GetModelManufProd(True)
                _booPopulateCombo = True
                Misc.PopulateC1DropDownList(Me.cboModel, dt, "Model_Desc", "Model_ID")
                Me.cboModel.SelectedValue = 0
                _booPopulateCombo = False
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateCombo = False
            End Try
        End Sub

        '***********************************************************************************************
        Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
            Try
                Me.lblCurrManuf.Text = "" : Me.lblCurrProdDesc.Text = ""
                If _booPopulateCombo Then Exit Sub
                Me.lblCurrManuf.Text = Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Manuf_Desc")
                Me.lblCurrProdDesc.Text = Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Prod_Desc")
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboModel_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***********************************************************************************************
        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim iModelID, iCurrManufID, iCurrProdID As Integer
            Dim dt As DataTable

            Try
                If Me.cboModel.SelectedValue = 0 Then
                    Exit Sub
                ElseIf Me.cboNewManuf.SelectedValue = 0 AndAlso Me.cboNewProdType.SelectedValue = 0 Then
                    MessageBox.Show("Please select either new manufacture or new product type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iModelID = Me.cboModel.SelectedValue
                    iCurrManufID = Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Manuf_ID")
                    iCurrProdID = Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Prod_ID")

                    If Me.cboNewManuf.SelectedValue = iCurrManufID AndAlso Me.cboNewProdType.SelectedValue = iCurrProdID Then
                        MessageBox.Show("Nothing change.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        If iCurrProdID <> Me.cboNewProdType.SelectedValue Then
                            dt = Me._objBizSyx.GetDeviceInWipWithBillingInfo(Me.cboModel.SelectedValue)

                            With Me.dbgDevInWIP
                                .DataSource = dt.DefaultView

                            End With
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************

    End Class
End Namespace