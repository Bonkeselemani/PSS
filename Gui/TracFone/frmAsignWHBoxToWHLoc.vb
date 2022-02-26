Option Explicit On 

Namespace Gui.TracFone
    Public Class frmAsignWHBoxToWHLoc
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _objWH As PSS.Data.Buisness.TracFone.Warehouse

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objWH = New PSS.Data.Buisness.TracFone.Warehouse()
            _strScreenName = strScreenName
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
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtWHLoc As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
        Friend WithEvents btnRefreshData As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents dbgWHBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAsignWHBoxToWHLoc))
            Me.dbgWHBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtWHLoc = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtBoxName = New System.Windows.Forms.TextBox()
            Me.btnRefreshData = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            CType(Me.dbgWHBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dbgWHBoxes
            '
            Me.dbgWHBoxes.AllowUpdate = False
            Me.dbgWHBoxes.AlternatingRows = True
            Me.dbgWHBoxes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgWHBoxes.FilterBar = True
            Me.dbgWHBoxes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgWHBoxes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgWHBoxes.Location = New System.Drawing.Point(264, 16)
            Me.dbgWHBoxes.Name = "dbgWHBoxes"
            Me.dbgWHBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgWHBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgWHBoxes.PreviewInfo.ZoomFactor = 75
            Me.dbgWHBoxes.Size = New System.Drawing.Size(664, 400)
            Me.dbgWHBoxes.TabIndex = 6
            Me.dbgWHBoxes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "96</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 660, 396<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 660, 396</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(16, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(200, 16)
            Me.Label3.TabIndex = 87
            Me.Label3.Text = "Warehouse Location :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtWHLoc
            '
            Me.txtWHLoc.BackColor = System.Drawing.Color.White
            Me.txtWHLoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWHLoc.Location = New System.Drawing.Point(16, 32)
            Me.txtWHLoc.MaxLength = 25
            Me.txtWHLoc.Name = "txtWHLoc"
            Me.txtWHLoc.Size = New System.Drawing.Size(221, 21)
            Me.txtWHLoc.TabIndex = 1
            Me.txtWHLoc.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(16, 64)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 16)
            Me.Label1.TabIndex = 89
            Me.Label1.Text = "Box :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtBoxName
            '
            Me.txtBoxName.BackColor = System.Drawing.Color.White
            Me.txtBoxName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxName.Location = New System.Drawing.Point(16, 80)
            Me.txtBoxName.MaxLength = 25
            Me.txtBoxName.Name = "txtBoxName"
            Me.txtBoxName.Size = New System.Drawing.Size(221, 21)
            Me.txtBoxName.TabIndex = 2
            Me.txtBoxName.Text = ""
            '
            'btnRefreshData
            '
            Me.btnRefreshData.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshData.ForeColor = System.Drawing.Color.White
            Me.btnRefreshData.Location = New System.Drawing.Point(16, 136)
            Me.btnRefreshData.Name = "btnRefreshData"
            Me.btnRefreshData.Size = New System.Drawing.Size(224, 23)
            Me.btnRefreshData.TabIndex = 3
            Me.btnRefreshData.Text = "Refresh Data"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.White
            Me.btnCopyAll.Location = New System.Drawing.Point(16, 184)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(224, 23)
            Me.btnCopyAll.TabIndex = 4
            Me.btnCopyAll.Text = "Copy All Rows"
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.White
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(16, 232)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(224, 23)
            Me.btnCopySelectedRows.TabIndex = 5
            Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'frmAsignWHBoxToWHLoc
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(944, 446)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelectedRows, Me.btnCopyAll, Me.btnRefreshData, Me.Label1, Me.txtBoxName, Me.Label3, Me.txtWHLoc, Me.dbgWHBoxes})
            Me.Name = "frmAsignWHBoxToWHLoc"
            Me.Text = "frmAsignWHBoxToWHLoc"
            CType(Me.dbgWHBoxes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************************************************************************
        Private Sub frmAsignWHBoxToWHLoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PopulateWHBoxes()
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "frmAsignWHBoxToWHLoc_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub PopulateWHBoxes()
            Dim dt As DataTable

            Try
                dt = Me._objWH.GetWHBoxes()
                With Me.dbgWHBoxes
                    .DataSource = dt.DefaultView
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub txtWHLoc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWHLoc.KeyUp
            Try
                If e.KeyCode = Keys.Enter And Me.txtWHLoc.Text.Trim.Length > 0 Then
                    Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "txtWHLoc_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub txtBoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyUp
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                If e.KeyCode = Keys.Enter And Me.txtBoxName.Text.Trim.Length > 0 Then
                    If Me.txtWHLoc.Text.Trim.Length = 0 Then
                        MessageBox.Show("Please enter warehouse location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        dt = Me._objWH.GetWHBoxDetails(Me.txtBoxName.Text.Trim)
                        If dt.Select("Workstation <> 'WH-WIP'").Length > 0 Then
                            MessageBox.Show("There is " & dt.Select("Workstation <> 'WH-WIP'").Length & " units in this box does not belong to 'WH-WIP'. Please verify box's workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtBoxName.SelectAll()
                        Else
                            i = Me._objWH.AssignWHLocation(Me.txtBoxName.Text.Trim, Me.txtWHLoc.Text.Trim.ToUpper)
                            If i > 0 Then Me.txtBoxName.Text = ""
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "txtWHLoc_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub btnRefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshData.Click
            Try
                Me.PopulateWHBoxes()
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "btnRefreshData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub btnCopyAll_btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click, btnCopySelectedRows.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If sender.name = "btnCopyAll" Then
                    Misc.CopyAllData(Me.dbgWHBoxes)
                ElseIf sender.name = "btnCopySelectedRows" Then
                    Misc.CopySelectedRowsData(Me.dbgWHBoxes)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*********************************************************************************************************************

    End Class
End Namespace