Imports PSS.Data

Public Class frmMessDemandData
    Inherits System.Windows.Forms.Form

    Private _objMessDemandData As Buisness.MessDemandData
    Private _dtDemandData As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objMessDemandData = New Buisness.MessDemandData()
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
    Friend WithEvents dbgDemandData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnUpdateData As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessDemandData))
        Me.dbgDemandData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnUpdateData = New System.Windows.Forms.Button()
        CType(Me.dbgDemandData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dbgDemandData
        '
        Me.dbgDemandData.AlternatingRows = True
        Me.dbgDemandData.CaptionHeight = 17
        Me.dbgDemandData.FetchRowStyles = True
        Me.dbgDemandData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgDemandData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgDemandData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgDemandData.Name = "dbgDemandData"
        Me.dbgDemandData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgDemandData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgDemandData.PreviewInfo.ZoomFactor = 75
        Me.dbgDemandData.RowHeight = 15
        Me.dbgDemandData.Size = New System.Drawing.Size(292, 273)
        Me.dbgDemandData.TabIndex = 0
        Me.dbgDemandData.Text = "C1TrueDBGrid1"
        Me.dbgDemandData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:LightBlue;}Sele" & _
        "cted{ForeColor:Yellow;BackColor:Green;}Style3{}Inactive{ForeColor:InactiveCaptio" & _
        "nText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;}St" & _
        "yle9{}Normal{Font:Microsoft Sans Serif, 9pt, style=Bold;}HighlightRow{ForeColor:" & _
        "HighlightText;BackColor:Highlight;}Style14{}OddRow{BackColor:White;}RecordSelect" & _
        "or{AlignImage:Center;}Style15{}Heading{Wrap:True;AlignVert:Center;Border:Raised," & _
        ",1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:N" & _
        "ear;}Style11{}Style12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
        "Grid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dotted" & _
        "CellBorder"" RecordSelectorWidth=""13"" DefRecSelWidth=""13"" VerticalScrollGroup=""1""" & _
        " HorizontalScrollGroup=""1""><Height>269</Height><CaptionStyle parent=""Style2"" me=" & _
        """Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""Eve" & _
        "nRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterSty" & _
        "le parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Head" & _
        "ingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow""" & _
        " me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle paren" & _
        "t=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style1" & _
        "1"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""S" & _
        "tyle1"" /><ClientRect>0, 0, 288, 269</ClientRect><BorderSide>0</BorderSide><Borde" & _
        "rStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles" & _
        "><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style par" & _
        "ent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent" & _
        "=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=" & _
        """Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
        """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
        "ing"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent" & _
        "=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</h" & _
        "orzSplits><Layout>None</Layout><DefaultRecSelWidth>13</DefaultRecSelWidth><Clien" & _
        "tArea>0, 0, 288, 269</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" />" & _
        "<PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'btnUpdateData
        '
        Me.btnUpdateData.BackColor = System.Drawing.Color.SteelBlue
        Me.btnUpdateData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateData.ForeColor = System.Drawing.Color.White
        Me.btnUpdateData.Location = New System.Drawing.Point(312, 88)
        Me.btnUpdateData.Name = "btnUpdateData"
        Me.btnUpdateData.Size = New System.Drawing.Size(112, 40)
        Me.btnUpdateData.TabIndex = 1
        Me.btnUpdateData.Text = "&Update Data"
        '
        'frmMessDemandData
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(506, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUpdateData, Me.dbgDemandData})
        Me.Name = "frmMessDemandData"
        Me.Text = "Messaging Demand Data"
        CType(Me.dbgDemandData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmMessDemandData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim bDisplayForm As Boolean = True

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            LoadGridData()
            RefreshGridData()
            FormatGrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Form Load Error")
            bDisplayForm = False
            Me.Close()
        Finally
            If bDisplayForm Then
                MyBase.WindowState = FormWindowState.Maximized
                Me.Enabled = True
            End If

            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LoadGridData()
        Dim dt As DataTable

        Try
            Me._dtDemandData = Me._objMessDemandData.GetDemandData()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Demand Data Load Error")
        Finally
        End Try
    End Sub

    Private Sub frmMessDemandData_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Dim iLeft As Integer

        Try
            Me.Left = MyBase.Left
            Me.Top = MyBase.Top
            Me.Height = MyBase.Height
            Me.Width = MyBase.Width

            With Me.dbgDemandData
                .Left = 0
                .Top = 0
                .Width = 0.75 * MyBase.Width
                .Height = MyBase.Height
            End With

            Me.btnUpdateData.Top = MyBase.Top + (MyBase.Height - Me.btnUpdateData.Height) / 2
            iLeft = Me.dbgDemandData.Left + Me.dbgDemandData.Width
            Me.btnUpdateData.Left = iLeft + (MyBase.Width - iLeft - Me.btnUpdateData.Width) / 2
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Resize Error")
        End Try
    End Sub

    Private Sub RefreshGridData()
        Try
            Me.dbgDemandData.DataSource = Nothing

            If Not IsNothing(Me._dtDemandData) Then Me.dbgDemandData.DataSource = Me._dtDemandData
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Grid Refresh Error")
        End Try
    End Sub

    Private Sub FormatGrid()
        Try
            If Not IsNothing(Me.dbgDemandData.DataSource) Then
                With Me.dbgDemandData
                    .Caption = "Demand Data"
                    .GroupByCaption = ""
                    .GroupedColumns.Clear()
                    .GroupedColumns.Add(.Columns("Model"))
                    .GroupStyle.BackColor = Color.DarkGreen
                    .GroupStyle.ForeColor = Color.White
                    .DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy

                    .Columns("Daily Demand").NumberFormat = "#0"
                    .Columns("Tier").NumberFormat = "0"

                    .Columns("Daily Demand").DefaultValue = 0
                    .Columns("Tier").DefaultValue = 0
                    .Columns("AM Model Desc").DefaultValue = ""
                    .Columns("Type").DefaultValue = ""

                    .Columns("Type").EditMask = ">a"
                    '.Splits(0).DisplayColumns("Type").

                    .Splits(0).DisplayColumns("Model").AutoSize()
                    .Splits(0).DisplayColumns("Frequency").AutoSize()
                    .Splits(0).DisplayColumns("AM Model Desc").AutoSize()
                    .Splits(0).DisplayColumns("Type").AutoSize()

                    .Splits(0).DisplayColumns("Model").Locked = True
                    .Splits(0).DisplayColumns("Frequency").Locked = True

                    .Splits(0).DisplayColumns("Daily Demand").FetchStyle = True
                    .Splits(0).DisplayColumns("Tier").FetchStyle = True
                    .Splits(0).DisplayColumns("AM Model Desc").FetchStyle = True
                    .Splits(0).DisplayColumns("Type").FetchStyle = True

                    'Hide the ID columns
                    .Splits(0).DisplayColumns("ModelID").Visible = False
                    .Splits(0).DisplayColumns("FreqID").Visible = False

                    If Me._dtDemandData.Rows.Count > 0 Then
                        .Enabled = True
                        ExpandGrid()
                    Else
                        .Enabled = False
                    End If
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Grid Format Error")
        End Try
    End Sub

    Private Sub dbgDemandData_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles dbgDemandData.FetchCellStyle
        e.CellStyle.BackColor = System.Drawing.Color.MidnightBlue
        e.CellStyle.ForeColor = System.Drawing.Color.Yellow
    End Sub

    Private Sub dbgDemandData_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dbgDemandData.KeyPress
        If Me.dbgDemandData.Row > -1 Then
            If Me.dbgDemandData.Col = Me.dbgDemandData.Columns.IndexOf(Me.dbgDemandData.Columns("Tier")) Or Me.dbgDemandData.Col = Me.dbgDemandData.Columns.IndexOf(Me.dbgDemandData.Columns("Daily Demand")) Then
                If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then e.Handled = True ' Allow only numbers 
            ElseIf Me.dbgDemandData.Col = Me.dbgDemandData.Columns.IndexOf(Me.dbgDemandData.Columns("AM Model Desc")) Then
            ElseIf Me.dbgDemandData.Col = Me.dbgDemandData.Columns.IndexOf(Me.dbgDemandData.Columns("Type")) Then
                If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then e.Handled = True ' Allow only numbers and letters
            Else
                e.Handled = True ' No editing 
            End If
        End If
    End Sub

    Private Sub ExpandGrid()
        Dim i As Integer

        Try
            With Me.dbgDemandData
                For i = 0 To .RowCount - 1 + Me._objMessDemandData.GetModelCount()  'Add model count b/c of the grouping rows
                    .ExpandGroupRow(i)
                Next
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnUpdateData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateData.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            Me._objMessDemandData.UpdateData(Me._dtDemandData)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Data Update Error")
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class
