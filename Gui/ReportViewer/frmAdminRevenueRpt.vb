Option Explicit On 

Imports PSS.Data.Buisness
Imports C1.Win.C1TrueDBGrid

Public Class frmAdminRevenueRpt
    Inherits System.Windows.Forms.Form

    Private _strRptName As String = ""
    Private _objAdminRevenueRpt As AdminRevenueRpt

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strRptName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _strRptName = strRptName
        _objAdminRevenueRpt = New AdminRevenueRpt()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then

            _objAdminRevenueRpt = Nothing

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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCreateRpt As System.Windows.Forms.Button
    Friend WithEvents btnPrintRpt As System.Windows.Forms.Button
    Friend WithEvents btnCopyToExcel As System.Windows.Forms.Button
    Friend WithEvents cmbProd As PSS.Gui.Controls.ComboBox
    Friend WithEvents gridRptData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAdminRevenueRpt))
        Me.cmbProd = New PSS.Gui.Controls.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gridRptData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnCreateRpt = New System.Windows.Forms.Button()
        Me.btnPrintRpt = New System.Windows.Forms.Button()
        Me.btnCopyToExcel = New System.Windows.Forms.Button()
        CType(Me.gridRptData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbProd
        '
        Me.cmbProd.AutoComplete = True
        Me.cmbProd.BackColor = System.Drawing.SystemColors.Window
        Me.cmbProd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProd.ForeColor = System.Drawing.Color.Black
        Me.cmbProd.Location = New System.Drawing.Point(168, 40)
        Me.cmbProd.Name = "cmbProd"
        Me.cmbProd.Size = New System.Drawing.Size(256, 21)
        Me.cmbProd.TabIndex = 66
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(64, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "Product Type:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(712, 33)
        Me.lblTitle.TabIndex = 68
        Me.lblTitle.Text = "Admin Revenue Summary"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(48, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "To Work Date:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(168, 104)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(144, 21)
        Me.dtpToDate.TabIndex = 71
        Me.dtpToDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(168, 72)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(144, 21)
        Me.dtpFromDate.TabIndex = 69
        Me.dtpFromDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(48, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "From Work Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gridRptData
        '
        Me.gridRptData.AllowColMove = False
        Me.gridRptData.AllowColSelect = False
        Me.gridRptData.AllowFilter = False
        Me.gridRptData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.gridRptData.AllowSort = False
        Me.gridRptData.AllowUpdate = False
        Me.gridRptData.AllowUpdateOnBlur = False
        Me.gridRptData.AlternatingRows = True
        Me.gridRptData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.gridRptData.BackColor = System.Drawing.Color.SteelBlue
        Me.gridRptData.ColumnFooters = True
        Me.gridRptData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridRptData.GroupByCaption = "Drag a column header here to group by that column"
        Me.gridRptData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.gridRptData.Location = New System.Drawing.Point(8, 136)
        Me.gridRptData.MaintainRowCurrency = True
        Me.gridRptData.Name = "gridRptData"
        Me.gridRptData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.gridRptData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.gridRptData.PreviewInfo.ZoomFactor = 75
        Me.gridRptData.RowHeight = 20
        Me.gridRptData.Size = New System.Drawing.Size(696, 368)
        Me.gridRptData.TabIndex = 136
        Me.gridRptData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:Olive;Border:None,,0, 0, 0, 0;AlignVert:Center;}Editor{" & _
        "}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Selected" & _
        "{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:InactiveCapt" & _
        "ionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Transparent" & _
        ";}Footer{Font:Microsoft Sans Serif, 9pt, style=Bold;}Caption{AlignHorz:Center;Fo" & _
        "reColor:White;BackColor:Transparent;}Style1{}Normal{Font:Microsoft Sans Serif, 8" & _
        ".25pt;AlignVert:Center;BackColor:Control;}HighlightRow{ForeColor:HighlightText;B" & _
        "ackColor:Highlight;}Style14{}OddRow{BackColor:Transparent;}RecordSelector{AlignI" & _
        "mage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style" & _
        "=Bold;AlignHorz:Center;BackColor:LightSteelBlue;Border:Raised,,1, 1, 1, 1;ForeCo" & _
        "lor:Black;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}St" & _
        "yle13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight" & _
        "=""10"" AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" " & _
        "AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFoo" & _
        "terHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSe" & _
        "lWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>364</Heigh" & _
        "t><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""" & _
        "Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""F" & _
        "ilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle " & _
        "parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><High" & _
        "LightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactiv" & _
        "e"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle" & _
        " parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Sty" & _
        "le6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 692, 364</ClientRe" & _
        "ct><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBG" & _
        "rid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent" & _
        "=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""He" & _
        "ading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Nor" & _
        "mal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal""" & _
        " me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal" & _
        """ me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Nor" & _
        "mal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSp" & _
        "lits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSel" & _
        "Width>17</DefaultRecSelWidth><ClientArea>0, 0, 692, 364</ClientArea><PrintPageHe" & _
        "aderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" " & _
        "/></Blob>"
        '
        'btnCreateRpt
        '
        Me.btnCreateRpt.BackColor = System.Drawing.Color.Green
        Me.btnCreateRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateRpt.ForeColor = System.Drawing.Color.White
        Me.btnCreateRpt.Location = New System.Drawing.Point(504, 40)
        Me.btnCreateRpt.Name = "btnCreateRpt"
        Me.btnCreateRpt.Size = New System.Drawing.Size(168, 24)
        Me.btnCreateRpt.TabIndex = 137
        Me.btnCreateRpt.Text = "CREATE REPORT"
        '
        'btnPrintRpt
        '
        Me.btnPrintRpt.BackColor = System.Drawing.Color.SteelBlue
        Me.btnPrintRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintRpt.ForeColor = System.Drawing.Color.White
        Me.btnPrintRpt.Location = New System.Drawing.Point(504, 72)
        Me.btnPrintRpt.Name = "btnPrintRpt"
        Me.btnPrintRpt.Size = New System.Drawing.Size(168, 24)
        Me.btnPrintRpt.TabIndex = 138
        Me.btnPrintRpt.Text = "PRINT REPORT"
        '
        'btnCopyToExcel
        '
        Me.btnCopyToExcel.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnCopyToExcel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyToExcel.ForeColor = System.Drawing.Color.White
        Me.btnCopyToExcel.Location = New System.Drawing.Point(504, 104)
        Me.btnCopyToExcel.Name = "btnCopyToExcel"
        Me.btnCopyToExcel.Size = New System.Drawing.Size(168, 24)
        Me.btnCopyToExcel.TabIndex = 139
        Me.btnCopyToExcel.Text = "COPY TO EXCEL"
        '
        'frmAdminRevenueRpt
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(712, 510)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopyToExcel, Me.btnPrintRpt, Me.btnCreateRpt, Me.gridRptData, Me.Label5, Me.dtpToDate, Me.dtpFromDate, Me.Label4, Me.lblTitle, Me.cmbProd, Me.Label7})
        Me.Name = "frmAdminRevenueRpt"
        Me.Text = "Admin Revenue"
        CType(Me.gridRptData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '****************************************************************
    Private Sub frmAdminRevenueRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSql As String = ""

        Try
            strSql = "SELECT Prod_ID as ID, Prod_Desc as 'Desc' FROM lproduct WHERE Prod_Inactive = 0;"
            Generic.LoadComboBox(Me.cmbProd, strSql, 1)

            Me.dtpFromDate.Value = DateAdd(DateInterval.Day, (-1 * (Weekday(Now, FirstDayOfWeek.Monday) - 1)), Now)
            Me.dtpToDate.Value = DateAdd(DateInterval.Day, (7 - Weekday(Now, FirstDayOfWeek.Monday)), Now)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************
    Private Sub btnCreateRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateRpt.Click
        Dim dtData As DataTable

        Try
            If Me.cmbProd.SelectedValue = 0 Then
                MessageBox.Show("Please select Production.", "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Else
                dtData = Me.gridRptData.DataSource
                Me.gridRptData.DataSource = Nothing
                Me.gridRptData.ClearFields()

                Me._objAdminRevenueRpt.DisposeDT(dtData)

                'Get Report data
                Select Case _strRptName
                    Case "Admin Revenue Summary"
                        dtData = Me._objAdminRevenueRpt.GetAdminRevenueSummaryRptData(Me.dtpFromDate.Text, Me.dtpToDate.Text, Me.cmbProd.SelectedValue)
                    Case "Admin Revenue Detail"
                        dtData = Me._objAdminRevenueRpt.GetAdminRevenueDetailRptData(Me.dtpFromDate.Text, Me.dtpToDate.Text, Me.cmbProd.SelectedValue)
                End Select

                'Populate Data
                If Not IsNothing(dtData) Then
                    If dtData.Rows.Count > 0 Then
                        Me.SetDataGrid(Me.gridRptData, dtData)
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCreateRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************
    Private Sub SetDataGrid(ByRef grdCtrl As C1TrueDBGrid, ByRef dtData As DataTable)
        Dim objGroupInfo As GroupInfo

        Try
            If Not IsNothing(dtData) Then

                With grdCtrl
                    .DataSource = dtData
                    .Caption = Me._strRptName
                    .GroupByCaption = ""
                    '.GroupedColumns.Add(.Columns("ProdCompProdGrp"))
                    .GroupedColumns.Add(.Columns("Product"))
                    .GroupedColumns.Add(.Columns("ProdGroup"))
                    .GroupedColumns.Add(.Columns("Company"))
                    .GroupStyle.BackColor = Color.Olive
                    .GroupStyle.ForeColor = Color.White
                    .DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy

                    .AlternatingRows = True

                    .EvenRowStyle.BackColor = Color.Salmon
                    .EvenRowStyle.ForeColor = Color.Black

                    .OddRowStyle.BackColor = Color.Salmon
                    .OddRowStyle.ForeColor = Color.Black

                    '.HighLightRowStyle.BackColor = Me._dgfModel.HighlightStyleBackColor
                    '.HighLightRowStyle.ForeColor = Me._dgfModel.HighlightStyleForeColor

                    .CaptionStyle.BackColor = Color.Black
                    .CaptionStyle.ForeColor = Color.Lime

                    '.HeadingStyle.BackColor = Me._dgfModel.HeadingStyleBackColor
                    '.HeadingStyle.ForeColor = Me._dgfModel.HeadingStyleForeColor
                    '.HeadingStyle.HorizontalAlignment = Me._dgfModel.HeadingStyleHorizontalAlignment

                    ''.Splits(0).DisplayColumns(me._strModelDescription).Locked = True
                    '.Splits(0).DisplayColumns("Status").Locked = True
                    .Splits(0).DisplayColumns("Shift").Width = 30
                    .Columns("Shift").NumberFormat = "###,##0"

                    .Splits(0).DisplayColumns("DeviceCount").Width = 80
                    .Columns("DeviceCount").NumberFormat = "###,##0"
                    '.Columns("DeviceCount").GroupInfo.Position = C1.Win.C1TrueDBGrid.GroupPositionEnum.HeaderAndFooter
                    '' .Columns("DeviceCount").Aggregate = C1.Win.C1TrueDBGrid.AggregateEnum.Sum
                    '.Columns("DeviceCount").GroupInfo.FooterText = .Columns("DeviceCount").Aggregate.Sum

                    .Splits(0).DisplayColumns("Cost").Width = 80
                    .Columns("Cost").NumberFormat = "###,##0.00"
                    .Splits(0).DisplayColumns("PartSvc").Width = 80
                    .Columns("PartSvc").NumberFormat = "###,##0.00"
                    .Splits(0).DisplayColumns("Labor").Width = 80
                    .Columns("Labor").NumberFormat = "###,##0.00"
                    .Splits(0).DisplayColumns("TotalSales").Width = 80
                    .Columns("TotalSales").NumberFormat = "###,##0.00"
                    .Splits(0).DisplayColumns("BilledAUP").Width = 70
                    .Columns("BilledAUP").NumberFormat = "###,##0.00"
                    .Splits(0).DisplayColumns("LaborAUP").Width = 70
                    .Columns("LaborAUP").NumberFormat = "###,##0.00"
                    .Splits(0).DisplayColumns("RUR-DBR").Width = 60
                    .Columns("RUR-DBR").NumberFormat = "###,##0"
                    .Splits(0).DisplayColumns("RTM").Width = 50
                    .Columns("RTM").NumberFormat = "###,##0"
                    .Splits(0).DisplayColumns("NER").Width = 50
                    .Columns("NER").NumberFormat = "###,##0"
                    .Splits(0).DisplayColumns("Scrap").Width = 50
                    .Columns("Scrap").NumberFormat = "###,##0"
                    .Splits(0).DisplayColumns("RepeatRep").Width = 50
                    .Columns("RepeatRep").NumberFormat = "###,##0"
                    .Splits(0).DisplayColumns("PSSWrty").Width = 50
                    .Columns("PSSWrty").NumberFormat = "###,##0"
                    .Splits(0).DisplayColumns("ManWrty").Width = 50
                    .Columns("ManWrty").NumberFormat = "###,##0"
                    .Splits(0).DisplayColumns("ManChrg").Width = 50
                    .Columns("ManChrg").NumberFormat = "###,##0"

                    '.Splits(0).DisplayColumns(Me._strModelDescription).DataColumn.DataWidth = Me._iMaxModelDescLength

                    '.Splits(0).DisplayColumns("Status").Button = True

                    .CollapseColor = Color.SteelBlue

                End With

                ExpandGrid(grdCtrl)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExpandGrid(ByRef dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim i As Integer

        Try
            With dbg
                For i = 0 To .RowCount - 1
                    .ExpandGroupRow(i)
                Next i
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '****************************************************************
    Private Sub btnPrintRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintRpt.Click
        Try


        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnPrintRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************
    Private Sub btnCopyToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyToExcel.Click
        Try


        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCopyToExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '****************************************************************

    'Public Sub GroupColEventHandler(ByVal sender As Object, _
    '                                         ByVal e As GroupColEventArgs)
    '    MsgBox("GroupColEventHandler " & Me.gridRptData.Row, Me.gridRptData.Item(Me.gridRptData.Row, 0))
    'End Sub



    'Private Sub gridRptData_GroupHeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.GroupColEventArgs) Handles gridRptData.GroupHeadClick
    '    Dim strGroupByText As String = ""
    '    Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
    '    Dim dt As DataTable

    '    MsgBox("GroupHead, colindex = " & e.ColIndex & "datacolumn.CellText = " & e.DataColumn.CellText(4) & "datacolumn.CellValue = " & e.DataColumn.CellValue(4) & e.DataColumn.Caption)


    '    Select Case e.ColIndex
    '        Case 0

    '        Case 1

    '        Case 2

    '    End Select

    '    'dt = Me.gridRptData.DataSource

    '    'If Not IsNothing(dt) Then
    '    '    If dt.Rows.Count > 0 Then
    '    '        'loop through each column
    '    '        For Each col In sender.Columns
    '    '            If col.Caption <> "Model" Then
    '    '                If col.Caption = "% of Goal" Then
    '    '                    If dtGrandtotal.Compute("Sum(Goal)", "") = 0 Then
    '    '                        .Columns(col.Caption).FooterText = "0%"
    '    '                    Else
    '    '                        .Columns(col.Caption).FooterText = Format(((dtGrandtotal.Compute("Sum(Shipped)", "") / dtGrandtotal.Compute("Sum(Goal)", "")) * 100), "000.000").ToString & "%"
    '    '                    End If
    '    '                ElseIf col.Caption = "Monthly % of Goal" Then
    '    '                    If dtGrandtotal.Compute("Sum(Goal)", "") = 0 Then
    '    '                        .Columns(col.Caption).FooterText = "0%"
    '    '                    Else
    '    '                        .Columns(col.Caption).FooterText = Format(((dtGrandtotal.Compute("Sum(MonthlyShip)", "") / dtGrandtotal.Compute("Sum(Goal)", "")) * 100), "000.000").ToString & "%"
    '    '                    End If
    '    '                Else
    '    '                    .Columns(col.Caption).FooterText = dtGrandtotal.Compute("Sum([" & col.Caption & "])", "").ToString
    '    '                End If
    '    '            End If
    '    '        Next col
    '    '    End If
    '    'End If



    '    'With Me.gridRptData
    '    '    .Splits(0).DisplayColumns("Shift").Width = 30
    '    '    .Columns("Shift").NumberFormat = "###,##0"
    '    '    .Splits(0).DisplayColumns("DeviceCount").Width = 80
    '    '    .Columns("DeviceCount").NumberFormat = "###,##0"
    '    '    .Splits(0).DisplayColumns("Cost").Width = 80
    '    '    .Columns("Cost").NumberFormat = "###,##0.00"
    '    '    .Splits(0).DisplayColumns("PartSvc").Width = 80
    '    '    .Columns("PartSvc").NumberFormat = "###,##0.00"
    '    '    .Splits(0).DisplayColumns("Labor").Width = 80
    '    '    .Columns("Labor").NumberFormat = "###,##0.00"
    '    '    .Splits(0).DisplayColumns("TotalSales").Width = 80
    '    '    .Columns("TotalSales").NumberFormat = "###,##0.00"
    '    '    .Splits(0).DisplayColumns("BilledAUP").Width = 70
    '    '    .Columns("BilledAUP").NumberFormat = "###,##0.00"
    '    '    .Splits(0).DisplayColumns("LaborAUP").Width = 70
    '    '    .Columns("LaborAUP").NumberFormat = "###,##0.00"
    '    '    .Splits(0).DisplayColumns("RUR-DBR").Width = 60
    '    '    .Columns("RUR-DBR").NumberFormat = "###,##0"
    '    '    .Splits(0).DisplayColumns("RTM").Width = 50
    '    '    .Columns("RTM").NumberFormat = "###,##0"
    '    '    .Splits(0).DisplayColumns("NER").Width = 50
    '    '    .Columns("NER").NumberFormat = "###,##0"
    '    '    .Splits(0).DisplayColumns("Scrap").Width = 50
    '    '    .Columns("Scrap").NumberFormat = "###,##0"
    '    '    .Splits(0).DisplayColumns("RepeatRep").Width = 50
    '    '    .Columns("RepeatRep").NumberFormat = "###,##0"
    '    '    .Splits(0).DisplayColumns("PSSWrty").Width = 50
    '    '    .Columns("PSSWrty").NumberFormat = "###,##0"
    '    '    .Splits(0).DisplayColumns("ManWrty").Width = 50
    '    '    .Columns("ManWrty").NumberFormat = "###,##0"
    '    '    .Splits(0).DisplayColumns("ManChrg").Width = 50
    '    '    .Columns("ManChrg").NumberFormat = "###,##0"
    '    'End With
    'End Sub

    'Private Sub gridRptData_GroupAggregate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.GroupTextEventArgs) Handles gridRptData.GroupAggregate
    '    '.Columns("First").GroupInfo.Position = C1.Win.C1TrueDBGrid.GroupPositionEnum.HeaderAndFooter
    '    '.Columns("First").GroupInfo.FooterText = "First Name: {0}"
    '    MsgBox("GroupAggregate")
    'End Sub


End Class
