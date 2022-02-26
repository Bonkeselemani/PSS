Option Explicit On 

Imports C1.Win.C1TrueDBGrid

Public Class frmDisplayData
    Inherits System.Windows.Forms.Form

    Private dt As DataTable
#Region " Windows Form Designer generated code "

    Public Sub New(ByVal dtData As DataTable)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        dt = dtData
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnCopyAll As System.Windows.Forms.Button
    Friend WithEvents btnCopySelectedItems As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDisplayData))
        Me.dbgData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.btnCopySelectedItems = New System.Windows.Forms.Button()
        CType(Me.dbgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dbgData
        '
        Me.dbgData.AllowColMove = False
        Me.dbgData.AllowColSelect = False
        Me.dbgData.AllowSort = False
        Me.dbgData.AllowUpdate = False
        Me.dbgData.AllowUpdateOnBlur = False
        Me.dbgData.AlternatingRows = True
        Me.dbgData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgData.CollapseColor = System.Drawing.Color.White
        Me.dbgData.ExpandColor = System.Drawing.Color.White
        Me.dbgData.FilterBar = True
        Me.dbgData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgData.ForeColor = System.Drawing.Color.Black
        Me.dbgData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgData.Location = New System.Drawing.Point(8, 48)
        Me.dbgData.Name = "dbgData"
        Me.dbgData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgData.PreviewInfo.ZoomFactor = 75
        Me.dbgData.RecordSelectorWidth = 18
        Me.dbgData.RowHeight = 17
        Me.dbgData.Size = New System.Drawing.Size(760, 440)
        Me.dbgData.TabIndex = 4
        Me.dbgData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt;ForeColor:Black;BackColor:CornflowerBlue;}Selected{ForeColor:HighlightT" & _
        "ext;BackColor:Orange;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption" & _
        ";}FilterBar{ForeColor:Black;BackColor:White;}Footer{ForeColor:Lime;BackColor:Bla" & _
        "ck;}Caption{Font:Microsoft Sans Serif, 12pt, style=Bold;AlignHorz:Center;ForeCol" & _
        "or:White;BackColor:MediumPurple;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25p" & _
        "t, style=Bold;AlignVert:Center;ForeColor:White;BackColor:LightSteelBlue;}Highlig" & _
        "htRow{ForeColor:HighlightText;BackColor:Yellow;}Style14{}OddRow{Font:Microsoft S" & _
        "ans Serif, 8.25pt;ForeColor:Black;BackColor:LightSteelBlue;}RecordSelector{ForeC" & _
        "olor:White;AlignImage:Center;BackColor:Control;}Style15{}Heading{AlignVert:Cente" & _
        "r;Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;Borde" & _
        "r:Raised,,1, 1, 1, 1;ForeColor:Green;BackColor:DarkGray;}Style8{}Style10{AlignHo" & _
        "rz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><S" & _
        "plits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False""" & _
        " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
        "ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordS" & _
        "electorWidth=""18"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><Height>436</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Editor" & _
        "Style parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /" & _
        "><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" " & _
        "me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""He" & _
        "ading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Ina" & _
        "ctiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Styl" & _
        "e9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle" & _
        " parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRec" & _
        "t>0, 0, 756, 436</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bord" & _
        "erStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" m" & _
        "e=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""F" & _
        "ooter"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inac" & _
        "tive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor" & _
        """ /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRo" & _
        "w"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSele" & _
        "ctor"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Grou" & _
        "p"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>N" & _
        "one</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 756, 43" & _
        "6</ClientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterSty" & _
        "le parent="""" me=""Style17"" /></Blob>"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAll.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCopyAll.Location = New System.Drawing.Point(8, 8)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(184, 32)
        Me.btnCopyAll.TabIndex = 5
        Me.btnCopyAll.Text = "Copy All"
        '
        'btnCopySelectedItems
        '
        Me.btnCopySelectedItems.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnCopySelectedItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopySelectedItems.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCopySelectedItems.Location = New System.Drawing.Point(232, 8)
        Me.btnCopySelectedItems.Name = "btnCopySelectedItems"
        Me.btnCopySelectedItems.Size = New System.Drawing.Size(184, 32)
        Me.btnCopySelectedItems.TabIndex = 6
        Me.btnCopySelectedItems.Text = "Copy Selected Items"
        '
        'frmDisplayData
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(776, 501)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelectedItems, Me.btnCopyAll, Me.dbgData})
        Me.Name = "frmDisplayData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDisplayData"
        CType(Me.dbgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmDisplayData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer

        Try
            With Me.dbgData
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = AlignVertEnum.Center

                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = AlignHorzEnum.Near
                    If .Columns(i).Caption.EndsWith("Barcode") Or .Columns(i).Caption.StartsWith("Title") Then .Splits(0).DisplayColumns(i).Visible = False
                    If .Columns(i).Caption.StartsWith("S/N") Then .Splits(0).DisplayColumns(i).Frozen = True
                Next i

                .AlternatingRows = True
                .FilterBar = True
                .AllowFilter = True
                .AllowSort = True

                If dt.Rows.Count > 0 Then
                    .Caption = Me.dt.Rows(0)("Title")

                    .ColumnFooters = True
                    .Columns("S/N").FooterText = "TOTAL"
                    .Columns("OnPallet?").FooterText = dt.Rows.Count.ToString
                End If

            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgOpenPallets_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCopyAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim strHeader As String = ""
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

        Try
            If Me.dbgData.RowCount > 0 And Me.dbgData.Columns.Count > 0 Then
                'loop through each row
                For iRow = 0 To Me.dbgData.RowCount - 1
                    'loop through each column
                    For Each col In Me.dbgData.Columns
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

                ''print data
                'Me._objSPPLF.CreateExelReportToPrint(strData, Chr(65 + Me.grdWaitingShipment.Columns.Count - 1) & Me.grdWaitingShipment.RowCount + 1)
                'MessageBox.Show("Report has been printed out.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("No data to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCopySelectedItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopySelectedItems.Click
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim strHeader As String = ""

        Try
            If Me.dbgData.SelectedRows.Count > 0 And Me.dbgData.SelectedCols.Count Then
                'loop through each selected row
                For Each iRow In Me.dbgData.SelectedRows

                    'loop through each selected column
                    For Each col In Me.dbgData.SelectedCols
                        'header
                        If booCompleteHeader = False Then
                            strHeader = strHeader & col.Caption & vbTab
                        End If
                        'data
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

                'print data
                'Me._objSPPLF.CreateExelReportToPrint(strData, Chr(65 + Me.grdWaitingShipment.SelectedCols.Count - 1) & Me.grdWaitingShipment.SelectedRows.Count + 1)
                'MessageBox.Show("Report has been printed out.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Please select a range of cells to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCopySelectedItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub dbgData_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dbgData.AfterFilter
        Try
            If Me.dbgData.RowCount > 0 Then
                dbgData.Columns("S/N").FooterText = "TOTAL"
                dbgData.Columns("OnPallet?").FooterText = Me.dbgData.RowCount.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dbgData_AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
End Class
