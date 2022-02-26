Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmRURPriceException
    Inherits System.Windows.Forms.Form

    Private _objRPE As RURPriceException
    Private _booLoadData As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objRPE = New RURPriceException()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objRPE = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dbgRegPrice As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents dbgExpPrice As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRUR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtNER As System.Windows.Forms.TextBox
    Friend WithEvents txtNTF As System.Windows.Forms.TextBox
    Friend WithEvents grbAddUpdPrice As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRTM As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRURPriceException))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dbgRegPrice = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.dbgExpPrice = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grbAddUpdPrice = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRTM = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNTF = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNER = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRUR = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        CType(Me.dbgRegPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgExpPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbAddUpdPrice.SuspendLayout()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dbgRegPrice
        '
        Me.dbgRegPrice.AllowArrows = False
        Me.dbgRegPrice.AllowColMove = False
        Me.dbgRegPrice.AllowFilter = False
        Me.dbgRegPrice.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.IndividualRows
        Me.dbgRegPrice.AllowUpdate = False
        Me.dbgRegPrice.AlternatingRows = True
        Me.dbgRegPrice.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgRegPrice.Caption = "Regular Price"
        Me.dbgRegPrice.CaptionHeight = 17
        Me.dbgRegPrice.FetchRowStyles = True
        Me.dbgRegPrice.FilterBar = True
        Me.dbgRegPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgRegPrice.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgRegPrice.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgRegPrice.LinesPerRow = 3
        Me.dbgRegPrice.Location = New System.Drawing.Point(8, 48)
        Me.dbgRegPrice.Name = "dbgRegPrice"
        Me.dbgRegPrice.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgRegPrice.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgRegPrice.PreviewInfo.ZoomFactor = 75
        Me.dbgRegPrice.RowHeight = 25
        Me.dbgRegPrice.RowSubDividerColor = System.Drawing.Color.DimGray
        Me.dbgRegPrice.Size = New System.Drawing.Size(440, 152)
        Me.dbgRegPrice.TabIndex = 2
        Me.dbgRegPrice.Text = "C1TrueDBGrid1"
        Me.dbgRegPrice.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Wrap:True;Font:Microsoft " & _
        "Sans Serif, 8.25pt, style=Bold;AlignHorz:Near;Trimming:Character;BackColor:Wheat" & _
        ";ForegroundImagePos:LeftOfText;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
        "ight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}" & _
        "FilterBar{ForeColor:Red;BackColor:White;}Footer{Font:Microsoft Sans Serif, 8.25p" & _
        "t, style=Bold;}Caption{Font:Microsoft Sans Serif, 9pt, style=Bold;AlignHorz:Cent" & _
        "er;BackColor:SlateGray;}Style1{}Normal{Font:Microsoft Sans Serif, 9pt;BackColor:" & _
        "LightSteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1" & _
        "4{}OddRow{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Near" & _
        ";}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sa" & _
        "ns Serif, 8.25pt, style=Bold;BackColor:SteelBlue;Border:Raised,,1, 1, 1, 1;ForeC" & _
        "olor:White;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}S" & _
        "tyle13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeigh" & _
        "t=""10"" AllowColMove=""False"" Name="""" AllowRowSizing=""IndividualRows"" AlternatingR" & _
        "owStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""1" & _
        "7"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Record" & _
        "SelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollG" & _
        "roup=""1""><Height>130</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Edito" & _
        "rStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" " & _
        "/><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer""" & _
        " me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""H" & _
        "eading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><In" & _
        "activeStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Sty" & _
        "le9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyl" & _
        "e parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRe" & _
        "ct>0, 17, 436, 130</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bo" & _
        "rderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=""""" & _
        " me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=" & _
        """Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""In" & _
        "active"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edit" & _
        "or"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Even" & _
        "Row"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSe" & _
        "lector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Gr" & _
        "oup"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout" & _
        ">None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 436, " & _
        "148</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterS" & _
        "tyle parent="""" me=""Style15"" /></Blob>"
        '
        'dbgExpPrice
        '
        Me.dbgExpPrice.AllowArrows = False
        Me.dbgExpPrice.AllowColMove = False
        Me.dbgExpPrice.AllowFilter = False
        Me.dbgExpPrice.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.IndividualRows
        Me.dbgExpPrice.AllowUpdate = False
        Me.dbgExpPrice.AlternatingRows = True
        Me.dbgExpPrice.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgExpPrice.Caption = "Exception Price"
        Me.dbgExpPrice.CaptionHeight = 17
        Me.dbgExpPrice.FetchRowStyles = True
        Me.dbgExpPrice.FilterBar = True
        Me.dbgExpPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgExpPrice.ForeColor = System.Drawing.Color.White
        Me.dbgExpPrice.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgExpPrice.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.dbgExpPrice.LinesPerRow = 3
        Me.dbgExpPrice.Location = New System.Drawing.Point(8, 208)
        Me.dbgExpPrice.Name = "dbgExpPrice"
        Me.dbgExpPrice.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgExpPrice.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgExpPrice.PreviewInfo.ZoomFactor = 75
        Me.dbgExpPrice.RowHeight = 25
        Me.dbgExpPrice.RowSubDividerColor = System.Drawing.Color.DimGray
        Me.dbgExpPrice.Size = New System.Drawing.Size(440, 224)
        Me.dbgExpPrice.TabIndex = 3
        Me.dbgExpPrice.Text = "C1TrueDBGrid1"
        Me.dbgExpPrice.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Wrap:True;Font:Microsoft " & _
        "Sans Serif, 8.25pt, style=Bold;AlignHorz:Near;Trimming:Character;ForeColor:White" & _
        ";BackColor:Wheat;ForegroundImagePos:LeftOfText;}Selected{ForeColor:HighlightText" & _
        ";BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:I" & _
        "nactiveCaption;}FilterBar{ForeColor:Red;BackColor:White;}Footer{Font:Microsoft S" & _
        "ans Serif, 8.25pt, style=Bold;}Caption{Font:Microsoft Sans Serif, 9pt, style=Bol" & _
        "d;AlignHorz:Center;BackColor:Purple;}Style9{}Normal{Font:Microsoft Sans Serif, 9" & _
        "pt;BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:High" & _
        "light;}Style12{}OddRow{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;A" & _
        "lignHorz:Near;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Font" & _
        ":Microsoft Sans Serif, 8.25pt, style=Bold;AlignVert:Center;Border:Raised,,1, 1, " & _
        "1, 1;ForeColor:White;BackColor:SteelBlue;}Style8{}Style10{AlignHorz:Near;}Style1" & _
        "1{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeV" & _
        "iew HBarHeight=""10"" AllowColMove=""False"" Name="""" AllowRowSizing=""IndividualRows""" & _
        " AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFo" & _
        "oterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""DottedCellB" & _
        "order"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><Height>202</Height><CaptionStyle parent=""Style2"" me=""Styl" & _
        "e10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow""" & _
        " me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pa" & _
        "rent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingSt" & _
        "yle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""" & _
        "Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""Od" & _
        "dRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" />" & _
        "<SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1" & _
        """ /><ClientRect>0, 17, 436, 202</ClientRect><BorderSide>0</BorderSide><BorderSty" & _
        "le>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><St" & _
        "yle parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=" & _
        """Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""He" & _
        "ading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Nor" & _
        "mal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Nor" & _
        "mal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading""" & _
        " me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Ca" & _
        "ption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzS" & _
        "plits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientAre" & _
        "a>0, 0, 436, 220</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Pri" & _
        "ntPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'grbAddUpdPrice
        '
        Me.grbAddUpdPrice.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.btnSave, Me.Label6, Me.txtRTM, Me.Label5, Me.txtNTF, Me.Label4, Me.txtNER, Me.Label3, Me.txtRUR, Me.Label2, Me.cboModels})
        Me.grbAddUpdPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbAddUpdPrice.ForeColor = System.Drawing.Color.White
        Me.grbAddUpdPrice.Location = New System.Drawing.Point(472, 204)
        Me.grbAddUpdPrice.Name = "grbAddUpdPrice"
        Me.grbAddUpdPrice.Size = New System.Drawing.Size(232, 228)
        Me.grbAddUpdPrice.TabIndex = 4
        Me.grbAddUpdPrice.TabStop = False
        Me.grbAddUpdPrice.Text = "Add/Update Exception Price"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(144, 184)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 24)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Green
        Me.btnSave.Location = New System.Drawing.Point(16, 184)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(144, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "RTM:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtRTM
        '
        Me.txtRTM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRTM.Location = New System.Drawing.Point(144, 136)
        Me.txtRTM.Name = "txtRTM"
        Me.txtRTM.Size = New System.Drawing.Size(72, 22)
        Me.txtRTM.TabIndex = 5
        Me.txtRTM.Text = ""
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "NTF:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtNTF
        '
        Me.txtNTF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNTF.Location = New System.Drawing.Point(16, 136)
        Me.txtNTF.Name = "txtNTF"
        Me.txtNTF.Size = New System.Drawing.Size(72, 22)
        Me.txtNTF.TabIndex = 4
        Me.txtNTF.Text = ""
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(144, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "NER:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtNER
        '
        Me.txtNER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNER.Location = New System.Drawing.Point(144, 88)
        Me.txtNER.Name = "txtNER"
        Me.txtNER.Size = New System.Drawing.Size(72, 22)
        Me.txtNER.TabIndex = 3
        Me.txtNER.Text = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "RUR:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtRUR
        '
        Me.txtRUR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRUR.Location = New System.Drawing.Point(16, 88)
        Me.txtRUR.Name = "txtRUR"
        Me.txtRUR.Size = New System.Drawing.Size(72, 22)
        Me.txtRUR.TabIndex = 2
        Me.txtRUR.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Model:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cboModels
        '
        Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboModels.Caption = ""
        Me.cboModels.CaptionHeight = 17
        Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModels.ColumnCaptionHeight = 17
        Me.cboModels.ColumnFooterHeight = 17
        Me.cboModels.ContentHeight = 15
        Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModels.EditorHeight = 15
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(16, 40)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(5, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(200, 21)
        Me.cboModels.TabIndex = 25
        Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(88, 10)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(360, 21)
        Me.cboCustomers.TabIndex = 24
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
        'frmRURPriceException
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(720, 501)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCustomers, Me.grbAddUpdPrice, Me.dbgExpPrice, Me.dbgRegPrice, Me.Label1})
        Me.Name = "frmRURPriceException"
        Me.Text = "frmRURPriceException"
        CType(Me.dbgRegPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgExpPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbAddUpdPrice.ResumeLayout(False)
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmRURPriceException_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)
            Me.LoadCustomers()
            Me.LoadModels()

            Me.cboCustomers.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmRURPriceException_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadCustomers()
        Dim dt As DataTable

        Try
            _booLoadData = True
            dt = _objRPE.GetCustomers(True)
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
            Me.cboCustomers.SelectedValue = 0

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadCustomers", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            _booLoadData = False
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadModels()
        Dim dt As DataTable
        Try
            _booLoadData = True
            dt = _objRPE.GetModels(True)
            Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
            Me.cboModels.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadModels", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
            _booLoadData = False
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadRegPrice()
        Dim dt As DataTable
        Dim i As Integer

        Try
            dt = Me._objRPE.GetRURRegPriceByCust(Me.cboCustomers.SelectedValue)

            With Me.dbgRegPrice
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To dt.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    .Splits(0).DisplayColumns(i).Width = 60
                Next i

                .Splits(0).DisplayColumns("Product").Width = 150
                .Splits(0).DisplayColumns("Product").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                .AlternatingRows = True
                .AllowFilter = False
                .FilterBar = False

            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadExceptionPrice()
        Dim dt As DataTable
        Dim i As Integer

        Try
            dt = Me._objRPE.GetRURExceptionPriceByCust(Me.cboCustomers.SelectedValue)

            With Me.dbgExpPrice
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To dt.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                    .Splits(0).DisplayColumns(i).Width = 60
                Next i

                .Splits(0).DisplayColumns("Model").Width = 150
                .Splits(0).DisplayColumns("Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                .Splits(0).DisplayColumns("RP_ID").Visible = False
                .Splits(0).DisplayColumns("Model_ID").Visible = False
                .AlternatingRows = True
                .EvenRowStyle.BackColor = Color.DarkBlue
                .OddRowStyle.BackColor = Color.Purple
                .AllowFilter = True
                .FilterBar = True

            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub cboCustomers_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomers.RowChange
        Try
            If _booLoadData = True Then Exit Sub

            Me.ClearUpdateCtrls()
            If Me.cboCustomers.SelectedValue > 0 Then
                Me.LoadRegPrice()
                Me.LoadExceptionPrice()
                Me.dbgRegPrice.Visible = True
                Me.dbgExpPrice.Visible = True
                Me.grbAddUpdPrice.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "LoadExceptionPrice", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboCustomers.SelectAll() : Me.cboCustomers.Focus()
            ElseIf Me.cboModels.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboModels.SelectAll() : Me.cboModels.Focus()
            ElseIf Me.txtNER.Text.Trim.Length = 0 OrElse Convert.ToDecimal(Me.txtNER.Text) < 0 Then
                MessageBox.Show("Please enter NER price.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtNER.SelectAll() : Me.txtNER.Focus()
            ElseIf Me.txtNTF.Text.Trim.Length = 0 OrElse Convert.ToDecimal(Me.txtNTF.Text) < 0 Then
                MessageBox.Show("Please enter NTF price.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtNTF.SelectAll() : Me.txtNTF.Focus()
            ElseIf Me.txtRTM.Text.Trim.Length = 0 OrElse Convert.ToDecimal(Me.txtRTM.Text) < 0 Then
                MessageBox.Show("Please enter RTM price.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtRTM.SelectAll() : Me.txtRTM.Focus()
            ElseIf Me.txtRUR.Text.Trim.Length = 0 OrElse Convert.ToDecimal(Me.txtRUR.Text) < 0 Then
                MessageBox.Show("Please enter RUR price.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtRUR.SelectAll() : Me.txtRUR.Focus()
            Else
                Dim i As Integer = Me._objRPE.AddUpdateExceptionRUR(Me.cboCustomers.SelectedValue, Me.cboModels.SelectedValue, Convert.ToDecimal(Me.txtRUR.Text), Convert.ToDecimal(Me.txtNER.Text), Convert.ToDecimal(Me.txtNTF.Text), Convert.ToDecimal(Me.txtRTM.Text))
                If i > 0 Then
                    Me.ClearUpdateCtrls() : Me.LoadExceptionPrice()
                    Me.cboModels.SelectAll() : Me.cboModels.Focus()
                Else
                    MessageBox.Show("No update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgExpPrice_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub dbgExpPrice_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgExpPrice.DoubleClick
        Try
            If _booLoadData = True Then Exit Sub

            Me.ClearUpdateCtrls()
            If Me.dbgExpPrice.RowCount > 0 Then
                If Convert.ToInt32(Me.dbgExpPrice.Columns("RP_ID").CellValue(Me.dbgExpPrice.Row)) > 0 Then
                    Me.txtNER.Text = Me.dbgExpPrice.Columns("NER").CellValue(Me.dbgExpPrice.Row)
                    Me.txtNTF.Text = Me.dbgExpPrice.Columns("NTF").CellValue(Me.dbgExpPrice.Row)
                    Me.txtRTM.Text = Me.dbgExpPrice.Columns("RTM").CellValue(Me.dbgExpPrice.Row)
                    Me.txtRUR.Text = Me.dbgExpPrice.Columns("RUR").CellValue(Me.dbgExpPrice.Row)
                    Me.cboModels.SelectedValue = Convert.ToInt32(Me.dbgExpPrice.Columns("Model_ID").CellValue(Me.dbgExpPrice.Row))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgExpPrice_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub ClearUpdateCtrls()
        Try
            Me.cboModels.SelectedValue = 0
            Me.txtNER.Text = ""
            Me.txtNTF.Text = ""
            Me.txtRTM.Text = ""
            Me.txtRUR.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '******************************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            ClearUpdateCtrls()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************

End Class
