
Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmHTC_LCD_MainBoard_Search
    Inherits System.Windows.Forms.Form

    Private _objHTC As HTC

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New HTC()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            _objHTC = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblCriteria As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cboSearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearchCriteria As System.Windows.Forms.TextBox
    Friend WithEvents dbgridSearcData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnCopySelectedData As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTC_LCD_MainBoard_Search))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblCriteria = New System.Windows.Forms.Label()
        Me.cboSearchBy = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchCriteria = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.dbgridSearcData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnCopySelectedData = New System.Windows.Forms.Button()
        CType(Me.dbgridSearcData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Location = New System.Drawing.Point(672, 37)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(63, 20)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        '
        'lblCriteria
        '
        Me.lblCriteria.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCriteria.ForeColor = System.Drawing.Color.White
        Me.lblCriteria.Location = New System.Drawing.Point(312, 37)
        Me.lblCriteria.Name = "lblCriteria"
        Me.lblCriteria.Size = New System.Drawing.Size(112, 16)
        Me.lblCriteria.TabIndex = 111
        Me.lblCriteria.Text = "Search Criteria:"
        Me.lblCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSearchBy
        '
        Me.cboSearchBy.Items.AddRange(New Object() {"Part Serial Number", "Part IMEI"})
        Me.cboSearchBy.Location = New System.Drawing.Point(432, 8)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.Size = New System.Drawing.Size(300, 21)
        Me.cboSearchBy.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(336, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Search by:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSearchCriteria
        '
        Me.txtSearchCriteria.Location = New System.Drawing.Point(432, 37)
        Me.txtSearchCriteria.Name = "txtSearchCriteria"
        Me.txtSearchCriteria.Size = New System.Drawing.Size(232, 20)
        Me.txtSearchCriteria.TabIndex = 2
        Me.txtSearchCriteria.Text = ""
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(1, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(303, 63)
        Me.lblTitle.TabIndex = 109
        Me.lblTitle.Text = "HTC LCD && Main Board Search"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dbgridSearcData
        '
        Me.dbgridSearcData.AllowColMove = False
        Me.dbgridSearcData.AllowFilter = False
        Me.dbgridSearcData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgridSearcData.AllowSort = False
        Me.dbgridSearcData.AllowUpdate = False
        Me.dbgridSearcData.AllowUpdateOnBlur = False
        Me.dbgridSearcData.AlternatingRows = True
        Me.dbgridSearcData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgridSearcData.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dbgridSearcData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgridSearcData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgridSearcData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgridSearcData.Location = New System.Drawing.Point(1, 64)
        Me.dbgridSearcData.Name = "dbgridSearcData"
        Me.dbgridSearcData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgridSearcData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgridSearcData.PreviewInfo.ZoomFactor = 75
        Me.dbgridSearcData.RowHeight = 20
        Me.dbgridSearcData.Size = New System.Drawing.Size(914, 245)
        Me.dbgridSearcData.TabIndex = 112
        Me.dbgridSearcData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Arial, 6.75pt, style" & _
        "=Bold;ForeColor:White;BackColor:CadetBlue;}Selected{ForeColor:Black;BackColor:Ye" & _
        "llow;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}" & _
        "FilterBar{Font:Arial, 8.25pt, style=Bold;BackColor:White;}Footer{}Caption{AlignH" & _
        "orz:Center;}Style1{}Normal{Font:Arial, 9pt, style=Bold;AlignVert:Center;BackColo" & _
        "r:SteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}" & _
        "OddRow{Font:Arial, 6.75pt, style=Bold;ForeColor:White;BackColor:Gray;}RecordSele" & _
        "ctor{AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8." & _
        "25pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fo" & _
        "reColor:Black;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12" & _
        "{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGri" & _
        "d.MergeView AllowColMove=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowSty" & _
        "le=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" Ma" & _
        "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Verti" & _
        "calScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>241</Height><CaptionStyle p" & _
        "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
        "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
        "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
        "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
        "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
        "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
        "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
        "ent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 910, 241</ClientRect><BorderSide>0<" & _
        "/BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></S" & _
        "plits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Hea" & _
        "ding"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Captio" & _
        "n"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected" & _
        """ /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow" & _
        """ /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><" & _
        "Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBa" & _
        "r"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplit" & _
        "s><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</Default" & _
        "RecSelWidth><ClientArea>0, 0, 910, 241</ClientArea><PrintPageHeaderStyle parent=" & _
        """"" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'btnCopySelectedData
        '
        Me.btnCopySelectedData.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCopySelectedData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopySelectedData.ForeColor = System.Drawing.Color.Black
        Me.btnCopySelectedData.Location = New System.Drawing.Point(752, 8)
        Me.btnCopySelectedData.Name = "btnCopySelectedData"
        Me.btnCopySelectedData.Size = New System.Drawing.Size(144, 20)
        Me.btnCopySelectedData.TabIndex = 4
        Me.btnCopySelectedData.Text = "Copy Selected Data"
        '
        'frmHTC_LCD_MainBoard_Search
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(920, 341)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelectedData, Me.dbgridSearcData, Me.btnSearch, Me.lblCriteria, Me.cboSearchBy, Me.Label1, Me.txtSearchCriteria, Me.lblTitle})
        Me.Name = "frmHTC_LCD_MainBoard_Search"
        Me.Text = "HTC LCD MainBoard Search"
        CType(Me.dbgridSearcData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmHTC_LCD_MainBoard_Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            Me.cboSearchBy.SelectedIndex = 0
            Me.txtSearchCriteria.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmHTC_LCD_MainBoard_Search_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Me.ProcessPartSearch()
            Me.txtSearchCriteria.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnSearch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtSearchCriteria_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchCriteria.KeyUp
        Try
            If e.KeyValue = 13 Then
                Me.ProcessPartSearch()
                Me.txtSearchCriteria.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSearchCriteria_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub ProcessPartSearch()
        Dim dt As DataTable
        Dim i As Integer

        Try
            Me.dbgridSearcData.DataSource = Nothing
            If Me.txtSearchCriteria.Text.Trim.Length = 0 Then Exit Sub
            If Me.cboSearchBy.SelectedIndex = -1 Then Exit Sub

            dt = Me._objHTC.GetPartSearchData(Me.txtSearchCriteria.Text.Trim, Me.cboSearchBy.SelectedIndex)
            With Me.dbgridSearcData
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                '.Splits(0).DisplayColumns("Device_ID").Visible = False

                .Splits(0).DisplayColumns("Part SN").Width = 100
                .Splits(0).DisplayColumns("Part IMEI").Width = 110
                .Splits(0).DisplayColumns("Device SN").Width = 100
                .Splits(0).DisplayColumns("Device IMEI In").Width = 110
                .Splits(0).DisplayColumns("Device IMEI Out").Width = 110
                .Splits(0).DisplayColumns("DOA").Width = 40

                .Splits(0).DisplayColumns("DOA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Receipt Date").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Bill Date").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("DOA Date").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            End With

        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCopySelectedData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySelectedData.Click
        Dim strData As String
        Dim iRow As Integer
        Dim booCompleteHeader As Boolean = False
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim strHeader As String = ""

        Try
            If Me.dbgridSearcData.SelectedRows.Count > 0 And Me.dbgridSearcData.SelectedCols.Count Then
                Me.Enabled = False

                'loop through each selected row
                For Each iRow In Me.dbgridSearcData.SelectedRows

                    'loop through each selected column
                    For Each col In Me.dbgridSearcData.Columns
                        If Me.dbgridSearcData.Splits(0).DisplayColumns(col.Caption).Visible = True Then
                            'header
                            If booCompleteHeader = False Then
                                strHeader = strHeader & col.Caption & vbTab
                            End If
                            'data
                            strData = strData & col.CellText(iRow) & vbTab
                        End If
                    Next col

                    'add new line to data
                    strData = strData & vbCrLf

                    'Stop collect header
                    booCompleteHeader = True
                Next iRow

                'combine header and data
                strData = strHeader & vbCrLf & strData
                System.Windows.Forms.Clipboard.SetDataObject(strData, False)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CopyDataFromDBGrid", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************

End Class
