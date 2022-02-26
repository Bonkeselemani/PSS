Public Class frmView
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
    Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnClose As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmView))
        Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdgData2
        '
        Me.tdgData2.AllowColMove = False
        Me.tdgData2.AllowColSelect = False
        Me.tdgData2.AllowFilter = False
        Me.tdgData2.AllowSort = False
        Me.tdgData2.AllowUpdate = False
        Me.tdgData2.AlternatingRows = True
        Me.tdgData2.BackColor = System.Drawing.Color.White
        Me.tdgData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tdgData2.Caption = "Result of Assignment"
        Me.tdgData2.CaptionHeight = 15
        Me.tdgData2.FetchRowStyles = True
        Me.tdgData2.FilterBar = True
        Me.tdgData2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdgData2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.tdgData2.Name = "tdgData2"
        Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdgData2.PreviewInfo.ZoomFactor = 75
        Me.tdgData2.RowHeight = 15
        Me.tdgData2.Size = New System.Drawing.Size(712, 248)
        Me.tdgData2.TabIndex = 81
        Me.tdgData2.Text = "C1TrueDBGrid1"
        Me.tdgData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;ForeColor:OliveDrab;BackColor:Gainsboro;}Style9{}Normal{Fo" & _
        "nt:Microsoft Sans Serif, 9pt;}HighlightRow{ForeColor:HighlightText;BackColor:Hig" & _
        "hlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap" & _
        ":True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor" & _
        ":Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</D" & _
        "ata></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowCo" & _
        "lSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapt" & _
        "ionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Ma" & _
        "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Verti" & _
        "calScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>231</Height><CaptionStyle p" & _
        "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
        "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
        "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
        "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
        "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
        "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
        "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
        "ent=""Normal"" me=""Style1"" /><ClientRect>0, 15, 710, 231</ClientRect><BorderSide>0" & _
        "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
        "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
        "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
        "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
        "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
        "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
        "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
        "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
        "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
        "tRecSelWidth><ClientArea>0, 0, 710, 246</ClientArea><PrintPageHeaderStyle parent" & _
        "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnClose.Location = New System.Drawing.Point(280, 256)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(152, 32)
        Me.btnClose.TabIndex = 82
        Me.btnClose.Text = "Close"
        '
        'frmView
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 294)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.tdgData2})
        Me.Name = "frmView"
        Me.Text = "frmView"
        CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
