Option Explicit On 

Imports PSS.Data.Buisness
Imports C1.Win

Public Class frmSensusSearch
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
    Friend WithEvents cboSearchBy As C1.Win.C1List.C1Combo
    Friend WithEvents dbgSearchResult As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCopyData As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSensusSearch))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCriteria = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnCopyData = New System.Windows.Forms.Button()
        Me.dbgSearchResult = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cboSearchBy = New C1.Win.C1List.C1Combo()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        CType(Me.dbgSearchResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Search By:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(56, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Criteria:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCriteria
        '
        Me.txtCriteria.Location = New System.Drawing.Point(152, 40)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(176, 20)
        Me.txtCriteria.TabIndex = 2
        Me.txtCriteria.Text = ""
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.SeaGreen
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(336, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 18)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        '
        'btnCopyData
        '
        Me.btnCopyData.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCopyData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyData.ForeColor = System.Drawing.Color.White
        Me.btnCopyData.Location = New System.Drawing.Point(440, 8)
        Me.btnCopyData.Name = "btnCopyData"
        Me.btnCopyData.Size = New System.Drawing.Size(80, 56)
        Me.btnCopyData.TabIndex = 5
        Me.btnCopyData.Text = "COPY DATA"
        '
        'dbgSearchResult
        '
        Me.dbgSearchResult.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgSearchResult.BackColor = System.Drawing.SystemColors.Control
        Me.dbgSearchResult.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgSearchResult.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgSearchResult.Location = New System.Drawing.Point(8, 72)
        Me.dbgSearchResult.Name = "dbgSearchResult"
        Me.dbgSearchResult.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgSearchResult.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgSearchResult.PreviewInfo.ZoomFactor = 75
        Me.dbgSearchResult.Size = New System.Drawing.Size(512, 184)
        Me.dbgSearchResult.TabIndex = 6
        Me.dbgSearchResult.Text = "C1TrueDBGrid1"
        Me.dbgSearchResult.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 6.75pt;ForeColor:White;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;B" & _
        "ackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:Ina" & _
        "ctiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;}Style9{}Normal{}Highl" & _
        "ightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{Font:Micros" & _
        "oft Sans Serif, 6.75pt;ForeColor:White;BackColor:SteelBlue;}RecordSelector{Align" & _
        "Image:Center;}Style15{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1" & _
        ", 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Sty" & _
        "le11{}Style12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Mer" & _
        "geView Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""1" & _
        "7"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" " & _
        "VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>180</Height><CaptionSt" & _
        "yle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><E" & _
        "venRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me" & _
        "=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Grou" & _
        "p"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyl" & _
        "e parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style" & _
        "4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Rec" & _
        "ordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Styl" & _
        "e parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 508, 180</ClientRect><BorderSi" & _
        "de>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeVie" & _
        "w></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me" & _
        "=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""C" & _
        "aption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Sel" & _
        "ected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlig" & _
        "htRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow" & _
        """ /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Fil" & _
        "terBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vert" & _
        "Splits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</De" & _
        "faultRecSelWidth><ClientArea>0, 0, 508, 180</ClientArea><PrintPageHeaderStyle pa" & _
        "rent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboSearchBy.AllowDrop = True
        Me.cboSearchBy.AutoCompletion = True
        Me.cboSearchBy.AutoDropDown = True
        Me.cboSearchBy.AutoSelect = True
        Me.cboSearchBy.Caption = ""
        Me.cboSearchBy.CaptionHeight = 17
        Me.cboSearchBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSearchBy.ColumnCaptionHeight = 17
        Me.cboSearchBy.ColumnFooterHeight = 17
        Me.cboSearchBy.ColumnHeaders = False
        Me.cboSearchBy.ContentHeight = 15
        Me.cboSearchBy.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboSearchBy.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboSearchBy.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSearchBy.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSearchBy.EditorHeight = 15
        Me.cboSearchBy.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboSearchBy.ItemHeight = 15
        Me.cboSearchBy.Location = New System.Drawing.Point(152, 8)
        Me.cboSearchBy.MatchEntryTimeout = CType(2000, Long)
        Me.cboSearchBy.MaxDropDownItems = CType(10, Short)
        Me.cboSearchBy.MaxLength = 32767
        Me.cboSearchBy.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboSearchBy.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboSearchBy.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboSearchBy.Size = New System.Drawing.Size(176, 21)
        Me.cboSearchBy.TabIndex = 1
        Me.cboSearchBy.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(152, 40)
        Me.dtpDate.MinDate = New Date(2009, 1, 1, 0, 0, 0, 0)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(176, 20)
        Me.dtpDate.TabIndex = 3
        Me.dtpDate.Visible = False
        '
        'frmSensusSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpDate, Me.cboSearchBy, Me.dbgSearchResult, Me.btnCopyData, Me.btnSearch, Me.Label1, Me.txtCriteria, Me.Label5})
        Me.Name = "frmSensusSearch"
        Me.Text = "frmSensusSearch"
        CType(Me.dbgSearchResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSearchBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*******************************************************************
    Private Sub frmSensusSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)
            Me.PopulateSearchBy()
            Me.cboSearchBy.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmSensusSearch_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateSearchBy()
        Dim dt As DataTable
        Try
            dt = New DataTable()
            Generic.AddNewColumnToDataTable(dt, "SearchBy", "System.String", "")
            Generic.AddNewColumnToDataTable(dt, "SearchID", "System.Int32", "")
            AddSearchByRow(dt, "Serial Number")
            AddSearchByRow(dt, "Meter ID")
            AddSearchByRow(dt, "RR#")
            AddSearchByRow(dt, "RMA")
            AddSearchByRow(dt, "Rec Date")
            AddSearchByRow(dt, "Prod Ship Date")
            AddSearchByRow(dt, "CEM Date")
            AddSearchByRow(dt, "Pallet Name")
            AddSearchByRow(dt, "Packing List #")

            With Me.cboSearchBy
                .DataSource = dt.DefaultView
                .ValueMember = "SearchID"
                .DisplayMember = "SearchBy"
                .Text = ""
                .Splits(0).DisplayColumns("SearchID").Visible = False
                .Splits(0).DisplayColumns("SearchBy").Width = Me.cboSearchBy.Width - 5
            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*******************************************************************
    Private Sub AddSearchByRow(ByRef dt As DataTable, _
                               ByVal strSearchByVal As String)
        Dim drNewRow As DataRow

        Try
            drNewRow = dt.NewRow
            drNewRow("SearchBy") = strSearchByVal
            drNewRow("SearchID") = dt.Rows.Count + 1
            dt.Rows.Add(drNewRow)
            dt.AcceptChanges()
        Catch ex As Exception
            Throw ex
        Finally
            drNewRow = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub cboSearchBy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSearchBy.KeyDown
        If e.KeyValue = Keys.Enter Then
            Me.dbgSearchResult.DataSource = Nothing
            If Me.cboSearchBy.Text.Trim.ToUpper.EndsWith("Date".ToUpper) = True Then
                Me.txtCriteria.Visible = False
                Me.dtpDate.Visible = True
                Me.dtpDate.Value = Now
                Me.txtCriteria.Text = ""
                Me.dtpDate.Focus()
            Else
                Me.txtCriteria.Visible = True
                Me.dtpDate.Visible = False
                Me.txtCriteria.Text = ""
                Me.txtCriteria.Focus()
            End If
        End If
    End Sub

    '*******************************************************************
    Private Sub txtCriteria_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCriteria.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtCriteria.Text.Trim.Length > 0 Then ProcessSearch()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtCriteria_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            ProcessSearch()
            If Me.txtCriteria.Visible = True Then Me.txtCriteria.Focus() Else Me.dtpDate.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnSearch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub ProcessSearch()
        Dim objSensus As Sensus
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            If Me.cboSearchBy.Text.Trim = "" Then
                MessageBox.Show("Please select search type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboSearchBy.Focus()
            ElseIf Me.cboSearchBy.Text.Trim.EndsWith("Date") = False AndAlso Me.txtCriteria.Text.Trim = "" Then
                MessageBox.Show("Please select search criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboSearchBy.Focus()
            ElseIf Me.cboSearchBy.Text.Trim.EndsWith("Date") = True AndAlso Me.dtpDate.Value > Now() Then
                MessageBox.Show("Date cannot be future.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboSearchBy.Focus()
            Else
                objSensus = New Sensus()
                dt = objSensus.GetSensusSearchData(Me.cboSearchBy.Text.Trim, Me.txtCriteria.Text.Trim, Format(Me.dtpDate.Value, "yyyy-MM-dd"))

                With Me.dbgSearchResult
                    .DataSource = Nothing

                    If dt.Rows.Count > 0 Then
                        .DataSource = dt.DefaultView

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1TrueDBGrid.AlignVertEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1TrueDBGrid.AlignVertEnum.Center
                        Next i

                        .Splits(0).DisplayColumns("Line #").Width = 40

                        .AllowSort = True
                        .FilterBar = True
                        .AlternatingRows = True
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
            objSensus = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub dtpDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDate.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then Me.ProcessSearch()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dtpDate_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnCopyData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyData.Click
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim strHeader As String = ""
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Try
            If Me.dbgSearchResult.RowCount > 0 And dbgSearchResult.Columns.Count > 0 Then
                Me.Enabled = False

                'loop through each row
                For iRow = 0 To dbgSearchResult.RowCount - 1
                    'loop through each column
                    For Each col In dbgSearchResult.Columns
                        'header
                        If booCompleteHeader = False Then
                            strHeader = strHeader & col.Caption & vbTab
                        End If

                        'Data
                        strData = strData & col.CellText(iRow) & vbTab
                    Next col

                    'add new line to data
                    strData = strData & vbCrLf

                    'Stop collect header
                    booCompleteHeader = True
                Next iRow

                'combine header and data
                strData = strHeader & vbCrLf & strData

                'Copy Data to Clipboard
                System.Windows.Forms.Clipboard.SetDataObject(strData, False)

                Me.Enabled = True
            Else
                MessageBox.Show("No data to copy.", "Copy All", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Me.Enabled = True
            col = Nothing
            Me.txtCriteria.SelectAll()
            Me.dtpDate.Value = Now
            If Me.txtCriteria.Visible = True Then Me.txtCriteria.Focus() Else Me.dtpDate.Focus()
        End Try
    End Sub

    '*******************************************************************

End Class
