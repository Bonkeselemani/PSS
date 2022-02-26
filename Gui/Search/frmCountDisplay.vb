Imports PSS.Core
Imports PSS.Data

Namespace Gui.Search

    Public Class frmCountDisplay
        Inherits System.Windows.Forms.Form

        Private ds As PSS.Data.Production.Joins
        Private dt As DataTable
        Private dtGrid, grid As DataTable

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
        Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDate As System.Windows.Forms.Label
        Friend WithEvents DataGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCountDisplay))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
            Me.lblDate = New System.Windows.Forms.Label()
            Me.DataGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.btnRefresh = New System.Windows.Forms.Button()
            CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DateTimePicker1
            '
            Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.DateTimePicker1.Location = New System.Drawing.Point(64, 16)
            Me.DateTimePicker1.Name = "DateTimePicker1"
            Me.DateTimePicker1.Size = New System.Drawing.Size(104, 20)
            Me.DateTimePicker1.TabIndex = 0
            '
            'lblDate
            '
            Me.lblDate.Location = New System.Drawing.Point(16, 16)
            Me.lblDate.Name = "lblDate"
            Me.lblDate.Size = New System.Drawing.Size(40, 16)
            Me.lblDate.TabIndex = 1
            Me.lblDate.Text = "Date:"
            Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'DataGrid
            '
            Me.DataGrid.AllowColMove = False
            Me.DataGrid.AllowColSelect = False
            Me.DataGrid.AllowDelete = True
            Me.DataGrid.AllowFilter = False
            Me.DataGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.DataGrid.AllowSort = False
            Me.DataGrid.AllowUpdate = False
            Me.DataGrid.AlternatingRows = True
            Me.DataGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.DataGrid.CaptionHeight = 17
            Me.DataGrid.CollapseColor = System.Drawing.Color.Black
            Me.DataGrid.DataChanged = False
            Me.DataGrid.BackColor = System.Drawing.Color.Empty
            Me.DataGrid.ExpandColor = System.Drawing.Color.Black
            Me.DataGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.DataGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.DataGrid.Location = New System.Drawing.Point(64, 48)
            Me.DataGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.DataGrid.Name = "DataGrid"
            Me.DataGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.DataGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.DataGrid.PreviewInfo.ZoomFactor = 75
            Me.DataGrid.PrintInfo.ShowOptionsDialog = False
            Me.DataGrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.DataGrid.RowDivider = GridLines1
            Me.DataGrid.RowHeight = 15
            Me.DataGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.DataGrid.ScrollTips = False
            Me.DataGrid.Size = New System.Drawing.Size(440, 168)
            Me.DataGrid.TabIndex = 37
            Me.DataGrid.Text = "C1TrueDBGrid1"
            Me.DataGrid.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Level=""0"" Caption=""Line Name"" " & _
            "DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Caption=""Devic" & _
            "e Count"" DataField=""""><ValueItems /></C1DataColumn></DataCols><Styles type=""C1.W" & _
            "in.C1TrueDBGrid.Design.ContextWrapper""><Data>Caption{AlignHorz:Center;}Normal{Fo" & _
            "nt:Verdana, 8.25pt;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor" & _
            "{}Style18{AlignHorz:Near;}Style19{AlignHorz:Near;}Style14{AlignHorz:Near;}Style1" & _
            "5{AlignHorz:Near;}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{}Sty" & _
            "le13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordS" & _
            "elector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:Aqua;}Heading{Wrap:True" & _
            ";BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cen" & _
            "ter;}FilterBar{}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:No" & _
            "ne,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}Style2{}</" & _
            "Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowC" & _
            "olSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCap" & _
            "tionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSe" & _
            "lectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
            "up=""1""><ClientRect>0, 0, 438, 166</ClientRect><BorderSide>0</BorderSide><Caption" & _
            "Style parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" />" & _
            "<EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" " & _
            "me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Gr" & _
            "oup"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowSt" & _
            "yle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Sty" & _
            "le4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""R" & _
            "ecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><St" & _
            "yle parent=""Normal"" me=""Style1"" /><internalCols><C1DisplayColumn><HeadingStyle p" & _
            "arent=""Style2"" me=""Style14"" /><Style parent=""Style1"" me=""Style15"" /><FooterStyle" & _
            " parent=""Style3"" me=""Style16"" /><EditorStyle parent=""Style5"" me=""Style17"" /><Vis" & _
            "ible>True</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Hei" & _
            "ght><DCIdx>0</DCIdx></C1DisplayColumn><C1DisplayColumn><HeadingStyle parent=""Sty" & _
            "le2"" me=""Style18"" /><Style parent=""Style1"" me=""Style19"" /><FooterStyle parent=""S" & _
            "tyle3"" me=""Style20"" /><EditorStyle parent=""Style5"" me=""Style21"" /><Visible>True<" & _
            "/Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx" & _
            ">1</DCIdx></C1DisplayColumn></internalCols></C1.Win.C1TrueDBGrid.MergeView></Spl" & _
            "its><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headi" & _
            "ng"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption""" & _
            " /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" " & _
            "/><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" " & _
            "/><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><St" & _
            "yle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar""" & _
            " /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits>" & _
            "<horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 438, 166</ClientArea></Blob>"
            '
            'lblNote
            '
            Me.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNote.Location = New System.Drawing.Point(64, 224)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(352, 32)
            Me.lblNote.TabIndex = 38
            '
            'btnRefresh
            '
            Me.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRefresh.Location = New System.Drawing.Point(424, 224)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.TabIndex = 39
            Me.btnRefresh.Text = "Refresh"
            '
            'frmCountDisplay
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(608, 365)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.lblNote, Me.DataGrid, Me.lblDate, Me.DateTimePicker1})
            Me.Name = "frmCountDisplay"
            Me.Text = "Count Display"
            CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmCountDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            grid = createGrid()
            PopulateGrid()

        End Sub

        Private Sub DateTimePicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
            '//The date value has changed reload the grid control
            PopulateGrid()

        End Sub


        Private Sub PopulateGrid()

            lblNote.Text = ""

            grid.Clear()
            getData()
            System.Windows.Forms.Application.DoEvents()
            Dim xCount As Integer
            Dim r As DataRow

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                Dim dr As DataRow = grid.NewRow
                dr("Location") = r("vLocation")
                dr("Count") = r("vCount")
                grid.Rows.Add(dr)
            Next
            DataGrid.DataSource = grid
            resizeGridColumns()

            lblNote.ForeColor = Color.Red
            lblNote.Text = "This information was generated on " & Now

        End Sub

        Private Sub getData()


            Dim dateSTART As String = Gui.Receiving.General.FormatDateShort(DateTimePicker1.Text) & " 00:00:00"
            Dim dateEND As String = Gui.Receiving.General.FormatDateShort(DateTimePicker1.Text) & " 23:59:59"

            Dim strSQL As String = "SELECT lwclocation.wc_location as vLocation, SUM(twcdetail.wcdetail_devicecnt) as vCount " & _
                                   "from twcdetail inner join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                                   "where twcdetail.wcdetail_timein > '" & dateSTART & "' " & _
                                   "and twcdetail.wcdetail_timein < '" & dateEND & "' " & _
                                   "group by lwclocation.wclocation_id " & _
                                   "order by lwclocation.wc_location"

            dt = ds.OrderEntrySelect(strSQL)

        End Sub

        Private Function createGrid() As DataTable

            Dim dtGrid As New DataTable("dtMain")

            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim dcLocation As New DataColumn("Location")
            dtGrid.Columns.Add(dcLocation)
            Dim dcCount As New DataColumn("Count")
            dtGrid.Columns.Add(dcCount)

            Return dtGrid

        End Function

        Private Sub resizeGridColumns()
            DataGrid.Splits(0).DisplayColumns(0).Width = 200
            DataGrid.Splits(0).DisplayColumns(1).Width = 100

        End Sub

        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            PopulateGrid()
        End Sub

    End Class

End Namespace
