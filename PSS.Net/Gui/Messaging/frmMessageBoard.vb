Public Class frmMessageBoard
    Inherits System.Windows.Forms.Form
    Private _dtData As DataTable
    Private _strWeekDates As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal dt As DataTable, ByVal strWeekDates As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _dtData = dt
        _strWeekDates = strWeekDates
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
    Friend WithEvents bnClose As System.Windows.Forms.Button
    Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
    Friend WithEvents btnCopyAll As System.Windows.Forms.Button
    Friend WithEvents lblBtnShowAllCols As System.Windows.Forms.Label
    Friend WithEvents grdData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblBtnShowKeyCols As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessageBoard))
        Me.bnClose = New System.Windows.Forms.Button()
        Me.btnCopySelectedRows = New System.Windows.Forms.Button()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.lblBtnShowAllCols = New System.Windows.Forms.Label()
        Me.grdData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblBtnShowKeyCols = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.grdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bnClose
        '
        Me.bnClose.BackColor = System.Drawing.Color.SlateGray
        Me.bnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bnClose.ForeColor = System.Drawing.Color.Blue
        Me.bnClose.Location = New System.Drawing.Point(704, 6)
        Me.bnClose.Name = "bnClose"
        Me.bnClose.Size = New System.Drawing.Size(88, 40)
        Me.bnClose.TabIndex = 135
        Me.bnClose.Text = "Close"
        '
        'btnCopySelectedRows
        '
        Me.btnCopySelectedRows.BackColor = System.Drawing.Color.SlateGray
        Me.btnCopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.Cyan
        Me.btnCopySelectedRows.Location = New System.Drawing.Point(560, 8)
        Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
        Me.btnCopySelectedRows.Size = New System.Drawing.Size(136, 40)
        Me.btnCopySelectedRows.TabIndex = 138
        Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.BackColor = System.Drawing.Color.SlateGray
        Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAll.ForeColor = System.Drawing.Color.Cyan
        Me.btnCopyAll.Location = New System.Drawing.Point(464, 8)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(88, 40)
        Me.btnCopyAll.TabIndex = 137
        Me.btnCopyAll.Text = "Copy All Rows"
        '
        'lblBtnShowAllCols
        '
        Me.lblBtnShowAllCols.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnShowAllCols.ForeColor = System.Drawing.Color.Black
        Me.lblBtnShowAllCols.Name = "lblBtnShowAllCols"
        Me.lblBtnShowAllCols.Size = New System.Drawing.Size(32, 24)
        Me.lblBtnShowAllCols.TabIndex = 139
        Me.lblBtnShowAllCols.Text = "-"
        '
        'grdData
        '
        Me.grdData.AllowUpdate = False
        Me.grdData.AlternatingRows = True
        Me.grdData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.grdData.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdData.FilterBar = True
        Me.grdData.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdData.Location = New System.Drawing.Point(24, 48)
        Me.grdData.Name = "grdData"
        Me.grdData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdData.PreviewInfo.ZoomFactor = 75
        Me.grdData.Size = New System.Drawing.Size(768, 464)
        Me.grdData.TabIndex = 140
        Me.grdData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
        "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
        "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:Linen;}Styl" & _
        "e13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSe" & _
        "lector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveC" & _
        "aptionText;BackColor:InactiveCaption;}EvenRow{BackColor:WhiteSmoke;}Heading{Wrap" & _
        ":True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor" & _
        ":Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;" & _
        "BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Bor" & _
        "der:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}<" & _
        "/Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyl" & _
        "e=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" Fil" & _
        "terBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSel" & _
        "Width=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>460</Height" & _
        "><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""S" & _
        "tyle5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Fi" & _
        "lterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle p" & _
        "arent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighL" & _
        "ightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive" & _
        """ me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle " & _
        "parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Styl" & _
        "e6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 764, 460</ClientRec" & _
        "t><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGr" & _
        "id.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=" & _
        """Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Hea" & _
        "ding"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Norm" & _
        "al"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" " & _
        "me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal""" & _
        " me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Norm" & _
        "al"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSpl" & _
        "its>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelW" & _
        "idth>17</DefaultRecSelWidth><ClientArea>0, 0, 764, 460</ClientArea><PrintPageHea" & _
        "derStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /" & _
        "></Blob>"
        '
        'lblBtnShowKeyCols
        '
        Me.lblBtnShowKeyCols.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBtnShowKeyCols.ForeColor = System.Drawing.Color.Black
        Me.lblBtnShowKeyCols.Location = New System.Drawing.Point(32, 0)
        Me.lblBtnShowKeyCols.Name = "lblBtnShowKeyCols"
        Me.lblBtnShowKeyCols.Size = New System.Drawing.Size(32, 24)
        Me.lblBtnShowKeyCols.TabIndex = 141
        Me.lblBtnShowKeyCols.Text = "-"
        '
        'lblTitle
        '
        Me.lblTitle.ForeColor = System.Drawing.Color.Navy
        Me.lblTitle.Location = New System.Drawing.Point(24, 32)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(440, 24)
        Me.lblTitle.TabIndex = 142
        Me.lblTitle.Text = " "
        '
        'frmMessageBoard
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(816, 536)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBtnShowKeyCols, Me.grdData, Me.lblBtnShowAllCols, Me.btnCopySelectedRows, Me.btnCopyAll, Me.bnClose, Me.lblTitle})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessageBoard"
        CType(Me.grdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*********************************************************************************************************************
    Private Sub frmMessageBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.CenterToScreen()
            Me.lblTitle.Text = "Forecated vs Shipped for Week (" & Me._strWeekDates & ")"
            ShowKeyColumns()
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "frmMessageBoard_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************************************************************************
    Private Sub ShowKeyColumns()
        Try
            Dim i As Integer
            Dim myDT As DataTable = Me._dtData.Copy

            'remove soem cols
            For i = myDT.Columns.Count - 1 To 0 Step -1
                If i <= 6 Then Exit For
                myDT.Columns.RemoveAt(i)
            Next

            'dataview, sort, idx 
            Dim dv As New DataView(myDT)
            dv.Sort = "Alert Desc"
            For i = 0 To dv.Count - 1
                dv(i)("Idx") = i + 1
            Next

            'Bind data
            With Me.grdData
                .DataSource = dv
                .Splits(0).DisplayColumns("Idx").Width = 20
                .Splits(0).DisplayColumns("Model_Desc").Width = 180
                .Splits(0).DisplayColumns("Alert").Width = 110
                '.Columns("Alert").SortDirection = C1.Win.C1TrueDBGrid.SortDirEnum.Descending'not action to sort but just status
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "ShowKeyColumns", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '*********************************************************************************************************************
    Private Sub bnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnClose.Click
        Me.Close()
    End Sub

    '*********************************************************************************************************************
    Private Sub lblBtnShowAllCols_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblBtnShowAllCols.DoubleClick
        Try
            Dim i As Integer
            'dataview, sort,idx
            Dim dv As New DataView(Me._dtData)
            dv.Sort = "Alert Desc"
            For i = 0 To dv.Count - 1
                dv(i)("Idx") = i + 1
            Next

            'Bind data
            With Me.grdData
                .DataSource = dv
                .Splits(0).DisplayColumns("Idx").Width = 20
                .Splits(0).DisplayColumns("Model_Desc").Width = 180
                .Splits(0).DisplayColumns("Alert").Width = 130
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "lblBtnShowAllCols_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************************************************************************
    Private Sub btnCopyAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
        Try
            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            If sender.name = "btnCopyAll" Then
                Misc.CopyAllData(Me.grdData)
            ElseIf sender.name = "btnCopySelectedRows" Then
                Misc.CopySelectedRowsData(Me.grdData)
            ElseIf sender.name = "btnCopyAll2" Then
                Misc.CopyAllData(Me.grdData)
            ElseIf sender.name = "btnCopySelectedRows2" Then
                Misc.CopySelectedRowsData(Me.grdData)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*********************************************************************************************************************
    Private Sub btnCopySelectedRows_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopySelectedRows.Click
        Try
            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            If sender.name = "btnCopyAll" Then
                Misc.CopyAllData(Me.grdData)
            ElseIf sender.name = "btnCopySelectedRows" Then
                Misc.CopySelectedRowsData(Me.grdData)
            ElseIf sender.name = "btnCopyAll2" Then
                Misc.CopyAllData(Me.grdData)
            ElseIf sender.name = "btnCopySelectedRows2" Then
                Misc.CopySelectedRowsData(Me.grdData)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
        End Try
    End Sub


    '*********************************************************************************************************************
    Private Sub lblBtnShowKeyCols_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblBtnShowKeyCols.DoubleClick
        Try
            ShowKeyColumns()
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "lblBtnShowKeyCols_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************************************************************************
End Class
