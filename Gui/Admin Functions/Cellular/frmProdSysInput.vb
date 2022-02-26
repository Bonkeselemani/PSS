Namespace Gui.Cellular



Public Class frmProdSysInput
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
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblPointsPerHour As System.Windows.Forms.Label
    Friend WithEvents lblBonusPerPointOverGoal As System.Windows.Forms.Label
    Friend WithEvents txtPointsPerHour As System.Windows.Forms.TextBox
    Friend WithEvents txtBonusPerPointOverGoal As System.Windows.Forms.TextBox
    Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProdSysInput))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.lblPointsPerHour = New System.Windows.Forms.Label()
            Me.lblBonusPerPointOverGoal = New System.Windows.Forms.Label()
            Me.txtPointsPerHour = New System.Windows.Forms.TextBox()
            Me.txtBonusPerPointOverGoal = New System.Windows.Forms.TextBox()
            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.Location = New System.Drawing.Point(8, 8)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(544, 23)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Productivity System Input Screen"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPointsPerHour
            '
            Me.lblPointsPerHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPointsPerHour.Location = New System.Drawing.Point(96, 64)
            Me.lblPointsPerHour.Name = "lblPointsPerHour"
            Me.lblPointsPerHour.Size = New System.Drawing.Size(80, 32)
            Me.lblPointsPerHour.TabIndex = 1
            Me.lblPointsPerHour.Text = "Points Per Hour"
            Me.lblPointsPerHour.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblBonusPerPointOverGoal
            '
            Me.lblBonusPerPointOverGoal.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblBonusPerPointOverGoal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBonusPerPointOverGoal.Location = New System.Drawing.Point(368, 48)
            Me.lblBonusPerPointOverGoal.Name = "lblBonusPerPointOverGoal"
            Me.lblBonusPerPointOverGoal.Size = New System.Drawing.Size(100, 54)
            Me.lblBonusPerPointOverGoal.TabIndex = 2
            Me.lblBonusPerPointOverGoal.Text = "Bonus Per Point Over Goal"
            Me.lblBonusPerPointOverGoal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'txtPointsPerHour
            '
            Me.txtPointsPerHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPointsPerHour.Location = New System.Drawing.Point(88, 104)
            Me.txtPointsPerHour.Name = "txtPointsPerHour"
            Me.txtPointsPerHour.Size = New System.Drawing.Size(88, 22)
            Me.txtPointsPerHour.TabIndex = 3
            Me.txtPointsPerHour.Text = ""
            Me.txtPointsPerHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtBonusPerPointOverGoal
            '
            Me.txtBonusPerPointOverGoal.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.txtBonusPerPointOverGoal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBonusPerPointOverGoal.Location = New System.Drawing.Point(376, 104)
            Me.txtBonusPerPointOverGoal.Name = "txtBonusPerPointOverGoal"
            Me.txtBonusPerPointOverGoal.Size = New System.Drawing.Size(88, 22)
            Me.txtBonusPerPointOverGoal.TabIndex = 4
            Me.txtBonusPerPointOverGoal.Text = ""
            Me.txtBonusPerPointOverGoal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'MainGrid
            '
            Me.MainGrid.AllowColMove = False
            Me.MainGrid.AllowColSelect = False
            Me.MainGrid.AllowDelete = True
            Me.MainGrid.AllowFilter = False
            Me.MainGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.MainGrid.AllowSort = False
            Me.MainGrid.AlternatingRows = True
            Me.MainGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.MainGrid.CaptionHeight = 17
            Me.MainGrid.CollapseColor = System.Drawing.Color.Black
            Me.MainGrid.DataChanged = False
            Me.MainGrid.BackColor = System.Drawing.Color.Empty
            Me.MainGrid.ExpandColor = System.Drawing.Color.Black
            Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.MainGrid.Location = New System.Drawing.Point(88, 144)
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
            Me.MainGrid.Size = New System.Drawing.Size(376, 224)
            Me.MainGrid.TabIndex = 37
            Me.MainGrid.Text = "C1TrueDBGrid1"
            Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;AlignVert:Ce" & _
            "nter;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Editor{}Normal{Font:Verdana, 8.25pt;}Style10{AlignHorz:Ne" & _
            "ar;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}EvenRow{BackColor:" & _
            "Aqua;}OddRow{}RecordSelector{AlignImage:Center;}Style8{}Style3{}Style2{}Group{Ba" & _
            "ckColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style9{}</Data></S" & _
            "tyles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect" & _
            "=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
            "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
            "dth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
            "ClientRect>0, 0, 374, 222</ClientRect><BorderSide>0</BorderSide><CaptionStyle pa" & _
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
            "ientArea>0, 0, 374, 222</ClientArea></Blob>"
            '
            'frmProdSysInput
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(560, 389)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.MainGrid, Me.txtBonusPerPointOverGoal, Me.txtPointsPerHour, Me.lblBonusPerPointOverGoal, Me.lblPointsPerHour, Me.lblTitle})
            Me.Name = "frmProdSysInput"
            Me.Text = "frmProdSysInput"
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


        Dim strSQL As String
        Dim ds As PSS.Data.Production.Joins
        Dim MGdt As DataTable

    Private Sub MainGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainGrid.Click

    End Sub

    Private Sub frmProdSysInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            getGridData()
        End Sub


        Private Sub getGridData()
            strSQL = "select lmanuf.manuf_desc as MANUFACTURER, tmodel.model_desc AS MODEL, " & _
                     "tmodel.goalhour AS 'UNIT GOAL PER HOUR', tmodel.piecepoint AS 'POINTS PER PIECE', tmodel.pointgoal AS 'POINT GOAL PER HOUR' from " & _
                     "tmodel inner join lmanuf on tmodel.manuf_id = lmanuf.manuf_id " & _
                     "where prod_id = 2 order by lmanuf.manuf_desc, tmodel.model_desc"
            MGdt = ds.OrderEntrySelect(strSQL)
            MainGrid.DataSource = MGdt

        End Sub



End Class

End Namespace
