Option Explicit On 

Public Class frmHTCDockRec
    Inherits System.Windows.Forms.Form

    Private _objHTC As PSS.Data.Buisness.HTC

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New PSS.Data.Buisness.HTC()
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
    Friend WithEvents txtRMA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents dbgOpenRMA As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTCDockRec))
        Me.txtRMA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dbgOpenRMA = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dbgOpenRMA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRMA
        '
        Me.txtRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRMA.Location = New System.Drawing.Point(8, 25)
        Me.txtRMA.MaxLength = 10
        Me.txtRMA.Name = "txtRMA"
        Me.txtRMA.Size = New System.Drawing.Size(200, 22)
        Me.txtRMA.TabIndex = 1
        Me.txtRMA.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(8, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "RMA Number:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dbgOpenRMA
        '
        Me.dbgOpenRMA.AllowArrows = False
        Me.dbgOpenRMA.AllowColMove = False
        Me.dbgOpenRMA.AllowFilter = False
        Me.dbgOpenRMA.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgOpenRMA.Caption = "Open RMA"
        Me.dbgOpenRMA.CaptionHeight = 17
        Me.dbgOpenRMA.FetchRowStyles = True
        Me.dbgOpenRMA.FilterBar = True
        Me.dbgOpenRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgOpenRMA.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgOpenRMA.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgOpenRMA.Location = New System.Drawing.Point(1, 88)
        Me.dbgOpenRMA.Name = "dbgOpenRMA"
        Me.dbgOpenRMA.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgOpenRMA.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgOpenRMA.PreviewInfo.ZoomFactor = 75
        Me.dbgOpenRMA.RowHeight = 15
        Me.dbgOpenRMA.RowSubDividerColor = System.Drawing.Color.DimGray
        Me.dbgOpenRMA.Size = New System.Drawing.Size(503, 424)
        Me.dbgOpenRMA.TabIndex = 126
        Me.dbgOpenRMA.Text = "C1TrueDBGrid1"
        Me.dbgOpenRMA.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:DarkGray;}Selec" & _
        "ted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inac" & _
        "tiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Whi" & _
        "te;}Footer{}Caption{Font:Microsoft Sans Serif, 9.75pt, style=Bold;AlignHorz:Cent" & _
        "er;ForeColor:White;BackColor:DarkSlateGray;}Style1{}Normal{Font:Microsoft Sans S" & _
        "erif, 9.75pt, style=Bold;BackColor:LightSteelBlue;}HighlightRow{ForeColor:Highli" & _
        "ghtText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}" & _
        "Style15{}Heading{Wrap:True;BackColor:SteelBlue;Border:Raised,,1, 1, 1, 1;ForeCol" & _
        "or:White;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Sty" & _
        "le13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=" & _
        """15"" AllowColMove=""False"" Name="""" AllowRowSizing=""None"" CaptionHeight=""17"" Colum" & _
        "nCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""Tru" & _
        "e"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" " & _
        "VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>403</Height><CaptionSt" & _
        "yle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><E" & _
        "venRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me" & _
        "=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Grou" & _
        "p"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyl" & _
        "e parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style" & _
        "4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Rec" & _
        "ordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Styl" & _
        "e parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 499, 403</ClientRect><BorderS" & _
        "ide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeVi" & _
        "ew></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" m" & _
        "e=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""" & _
        "Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Se" & _
        "lected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highli" & _
        "ghtRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRo" & _
        "w"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Fi" & _
        "lterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</ver" & _
        "tSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</D" & _
        "efaultRecSelWidth><ClientArea>0, 0, 499, 420</ClientArea><PrintPageHeaderStyle p" & _
        "arent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'btnGo
        '
        Me.btnGo.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.ForeColor = System.Drawing.Color.White
        Me.btnGo.Location = New System.Drawing.Point(216, 24)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(56, 24)
        Me.btnGo.TabIndex = 2
        Me.btnGo.Text = "Go"
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Location = New System.Drawing.Point(1, 1)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(215, 87)
        Me.lblHeader.TabIndex = 130
        Me.lblHeader.Text = "HTC DOCK RECEIVING"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtRMA, Me.Label2, Me.btnGo})
        Me.Panel1.Location = New System.Drawing.Point(217, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(287, 87)
        Me.Panel1.TabIndex = 1
        '
        'frmHTCDockRec
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(832, 557)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.lblHeader, Me.dbgOpenRMA})
        Me.Name = "frmHTCDockRec"
        Me.Text = "HTC Dock Receive"
        CType(Me.dbgOpenRMA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*******************************************************************
    Private Sub frmHTCDockRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)
            Me.PopulateHTCOpenRMA()

            Me.txtRMA.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmHTCDockRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateHTCOpenRMA()
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            dt = Me._objHTC.GetDockReceiveOpenRMA()

            With Me.dbgOpenRMA
                .DataSource = Nothing
                .DataSource = dt.DefaultView

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                    .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                Next i

                .Splits(0).DisplayColumns("WO_ID").Visible = False
                .Splits(0).DisplayColumns("RMA").Width = 160
                .Splits(0).DisplayColumns("Sku").Width = 80
                .Splits(0).DisplayColumns("RMA Date").Width = 140
                .Splits(0).DisplayColumns("RMA Qty").Width = 80
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                .MoveFirst()
            End With

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtRMA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRMA.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtRMA_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtRMA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRMA.KeyUp
        Try
            If e.KeyValue = 13 Then
                Me.ProcessDockReceive()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "DockRec", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Try
            Me.ProcessDockReceive()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "DockRec", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************
    Private Sub ProcessDockReceive()
        Dim i As Integer
        Dim booFound As Boolean = False
        Dim iFileQty As Integer = 0

        Try
            For i = 0 To Me.dbgOpenRMA.RowCount - 1
                If Me.dbgOpenRMA.Columns("RMA").CellText(i).ToString.Trim.ToUpper = Me.txtRMA.Text.Trim.ToUpper Then
                    booFound = True
                    iFileQty = Me.dbgOpenRMA.Columns("RMA Qty").CellText(i)
                End If
            Next i

            If booFound = False Then
                MessageBox.Show("This RMA does not have ASN file associate with it. Would you like to Receive it?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtRMA.SelectAll()
                Exit Sub
            Else
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = Me._objHTC.HTCDockRec(Me.txtRMA.Text.Trim.ToUpper, iFileQty, PSS.Core.Global.ApplicationUser.IDuser, PSS.Core.Global.ApplicationUser.User)

                Me.PopulateHTCOpenRMA()
                Me.txtRMA.Text = ""
                Me.txtRMA.Focus()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*******************************************************************


End Class
