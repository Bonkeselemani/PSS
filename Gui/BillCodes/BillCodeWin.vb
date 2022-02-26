
Imports PSS.Rules

Namespace Gui

    Public Class BillCodeWin
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
        Friend WithEvents dbgBillCodes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnNewBill As System.Windows.Forms.Button
        Friend WithEvents btnUpdateBill As System.Windows.Forms.Button
        Friend WithEvents btnDeleteBill As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BillCodeWin))
            Me.dbgBillCodes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnNewBill = New System.Windows.Forms.Button()
            Me.btnUpdateBill = New System.Windows.Forms.Button()
            Me.btnDeleteBill = New System.Windows.Forms.Button()
            CType(Me.dbgBillCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dbgBillCodes
            '
            Me.dbgBillCodes.AllowUpdate = False
            Me.dbgBillCodes.AlternatingRows = True
            Me.dbgBillCodes.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgBillCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgBillCodes.CaptionHeight = 17
            Me.dbgBillCodes.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.dbgBillCodes.FilterBar = True
            Me.dbgBillCodes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBillCodes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgBillCodes.Location = New System.Drawing.Point(232, 8)
            Me.dbgBillCodes.Name = "dbgBillCodes"
            Me.dbgBillCodes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBillCodes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBillCodes.PreviewInfo.ZoomFactor = 75
            Me.dbgBillCodes.RowHeight = 15
            Me.dbgBillCodes.Size = New System.Drawing.Size(368, 376)
            Me.dbgBillCodes.TabIndex = 0
            Me.dbgBillCodes.Text = "C1TrueDBGrid1"
            Me.dbgBillCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:LightSkyBlue;}Selected{ForeColor:HighlightText" & _
            ";BackColor:Highlight;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1" & _
            ", 1;ForeColor:ControlText;AlignVert:Center;}Inactive{ForeColor:InactiveCaptionTe" & _
            "xt;BackColor:InactiveCaption;}FilterBar{}OddRow{}Footer{}Caption{AlignHorz:Cente" & _
            "r;}Style25{}Normal{Font:Verdana, 8.25pt;}Style26{}HighlightRow{ForeColor:Highlig" & _
            "htText;BackColor:Highlight;}Style24{}Style23{AlignHorz:Near;}Style22{}Style21{}S" & _
            "tyle20{}RecordSelector{AlignImage:Center;}Style18{}Style19{}Style2{}Style14{}Sty" & _
            "le15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Gro" & _
            "upByView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
            "ht=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder""" & _
            " RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizontal" & _
            "ScrollGroup=""1""><Height>374</Height><CaptionStyle parent=""Heading"" me=""Style23"" " & _
            "/><EditorStyle parent=""Editor"" me=""Style15"" /><EvenRowStyle parent=""EvenRow"" me=" & _
            """Style21"" /><FilterBarStyle parent=""FilterBar"" me=""Style26"" /><FooterStyle paren" & _
            "t=""Footer"" me=""Style17"" /><GroupStyle parent=""Group"" me=""Style25"" /><HeadingStyl" & _
            "e parent=""Heading"" me=""Style16"" /><HighLightRowStyle parent=""HighlightRow"" me=""S" & _
            "tyle20"" /><InactiveStyle parent=""Inactive"" me=""Style19"" /><OddRowStyle parent=""O" & _
            "ddRow"" me=""Style22"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style24"" " & _
            "/><SelectedStyle parent=""Selected"" me=""Style18"" /><Style parent=""Normal"" me=""Sty" & _
            "le14"" /><ClientRect>0, 29, 366, 374</ClientRect><BorderSide>0</BorderSide><Borde" & _
            "rStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.GroupByView></Splits><NamedStyl" & _
            "es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
            "arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
            "nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
            "t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
            "t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
            "ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
            "nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
            "/horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Cli" & _
            "entArea>0, 0, 366, 374</ClientArea><PrintPageHeaderStyle parent="""" me=""Style1"" /" & _
            "><PrintPageFooterStyle parent="""" me=""Style2"" /></Blob>"
            '
            'btnNewBill
            '
            Me.btnNewBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnNewBill.Location = New System.Drawing.Point(8, 16)
            Me.btnNewBill.Name = "btnNewBill"
            Me.btnNewBill.Size = New System.Drawing.Size(216, 24)
            Me.btnNewBill.TabIndex = 1
            Me.btnNewBill.Text = "New Bill Code"
            '
            'btnUpdateBill
            '
            Me.btnUpdateBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnUpdateBill.Location = New System.Drawing.Point(8, 48)
            Me.btnUpdateBill.Name = "btnUpdateBill"
            Me.btnUpdateBill.Size = New System.Drawing.Size(216, 24)
            Me.btnUpdateBill.TabIndex = 2
            Me.btnUpdateBill.Text = "Update Bill Code"
            '
            'btnDeleteBill
            '
            Me.btnDeleteBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnDeleteBill.Location = New System.Drawing.Point(8, 80)
            Me.btnDeleteBill.Name = "btnDeleteBill"
            Me.btnDeleteBill.Size = New System.Drawing.Size(216, 24)
            Me.btnDeleteBill.TabIndex = 3
            Me.btnDeleteBill.Text = "Delete Bill Code"
            '
            'BillCodeWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(608, 389)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteBill, Me.btnUpdateBill, Me.btnNewBill, Me.dbgBillCodes})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "BillCodeWin"
            Me.Text = "Bill Codes"
            CType(Me.dbgBillCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private selectedBillCode As Integer = 0
        Private selectedBillDesc As String = Nothing

        Private Sub LoadView()
            Me.dbgBillCodes.DataSource = BillCode.GetView
        End Sub

        Private Sub BillCodeWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            LoadView()
        End Sub

        Private Sub dbgBillCodes_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgBillCodes.RowColChange
            Me.selectedBillCode = Trim(dbgBillCodes.Columns(0).Text)
            Me.selectedBillDesc = Trim(dbgBillCodes.Columns(1).Text)
        End Sub

        Private Sub btnUpdateBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateBill.Click
            Me.LoadEditWin(selectedBillCode)
            Me.selectedBillCode = 0
            Me.LoadView()
        End Sub

        Private Sub LoadEditWin(ByVal billCode As Integer)
            Dim b As New BillCodeEditWin(billCode)
            b.ShowDialog()
        End Sub

        Private Sub btnDeleteBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBill.Click
            'If selectedBillCode = 0 Then Exit Sub
            'If MsgBox("Are you sure you wish to delete " & Trim(Me.selectedBillDesc), MsgBoxStyle.YesNo, "Confirm Delete") = MsgBoxResult.Yes Then
            '    BillCode.DeleteBillCode(Me.selectedBillCode)
            '    Me.selectedBillCode = 0
            '    Me.LoadView()
            'End If
            MessageBox.Show("This function is currently not available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Sub

        Private Sub btnNewBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewBill.Click
            Me.LoadEditWin(Nothing)
            Me.selectedBillCode = 0
            Me.LoadView()
        End Sub

    End Class

End Namespace

