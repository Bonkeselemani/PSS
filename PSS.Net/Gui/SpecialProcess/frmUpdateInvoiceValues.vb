Public Class frmUpdateInvoiceValues
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmUpdateInvoiceValues))
        Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(80, 11)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(160, 21)
        Me.ComboBox1.TabIndex = 1
        Me.ComboBox1.Text = "ComboBox1"
        '
        'MainGrid
        '
        Me.MainGrid.AllowColMove = False
        Me.MainGrid.AllowColSelect = False
        Me.MainGrid.AllowDelete = True
        Me.MainGrid.AllowFilter = False
        Me.MainGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.MainGrid.AllowSort = False
        Me.MainGrid.AllowUpdate = False
        Me.MainGrid.AlternatingRows = True
        Me.MainGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainGrid.CaptionHeight = 17
        Me.MainGrid.CollapseColor = System.Drawing.Color.Black
        Me.MainGrid.DataChanged = False
        'Me.MainGrid.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.MainGrid.ExpandColor = System.Drawing.Color.Black
        Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
        Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.MainGrid.Location = New System.Drawing.Point(24, 48)
        Me.MainGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.MainGrid.PreviewInfo.ZoomFactor = 75
        Me.MainGrid.PrintInfo.ShowOptionsDialog = False
        Me.MainGrid.RecordSelectorWidth = 16
        GridLines1.Color = System.Drawing.Color.DarkGray
        GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
        Me.MainGrid.RowDivider = GridLines1
        Me.MainGrid.RowHeight = 15
        Me.MainGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.MainGrid.ScrollTips = False
        Me.MainGrid.Size = New System.Drawing.Size(640, 296)
        Me.MainGrid.TabIndex = 37
        Me.MainGrid.Text = "C1TrueDBGrid1"
        Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
        "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;BackColor:Co" & _
        "ntrol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}OddRow{}Foo" & _
        "ter{}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}HighlightRow{ForeCol" & _
        "or:HighlightText;BackColor:Highlight;}EvenRow{BackColor:Aqua;}Editor{}RecordSele" & _
        "ctor{AlignImage:Center;}Style9{}Style8{}Style3{}Style2{}Group{AlignVert:Center;B" & _
        "order:None,,0, 0, 0, 0;BackColor:ControlDark;}Style10{AlignHorz:Near;}</Data></S" & _
        "tyles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect" & _
        "=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
        "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
        "dth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
        "ClientRect>0, 0, 638, 294</ClientRect><BorderSide>0</BorderSide><CaptionStyle pa" & _
        "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
        "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
        "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
        """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
        "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
        "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
        "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
        "nt=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles>" & _
        "<Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pare" & _
        "nt=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=" & _
        """Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""" & _
        "Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""" & _
        "Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headi" & _
        "ng"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=" & _
        """Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</ho" & _
        "rzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Cl" & _
        "ientArea>0, 0, 638, 294</ClientArea></Blob>"
        '
        'frmUpdateInvoiceValues
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(688, 445)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.MainGrid, Me.ComboBox1, Me.Label1})
        Me.Name = "frmUpdateInvoiceValues"
        Me.Text = "UPDATE INVOICE VALUES"
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmUpdateInvoiceValues_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
