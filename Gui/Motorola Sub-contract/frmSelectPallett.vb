Namespace Gui.MotorolaSubcontract
    Public Class frmSelectPallett
        Inherits System.Windows.Forms.Form
        Private iDt As New DataTable()
        Private iPallettId As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByRef dt As DataTable)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            iDt = dt

        End Sub



        'Public Sub New(ByRef dt As DataTable)
        '    MyBase.New()

        '    'This call is required by the Windows Form Designer.
        '    InitializeComponent()

        '    'Add any initialization after the InitializeComponent() call
        '    iDt = dt


        'End Sub




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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnSelect As System.Windows.Forms.Button
        Friend WithEvents grdPalletts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectPallett))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.grdPalletts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnSelect = New System.Windows.Forms.Button()
            CType(Me.grdPalletts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(120, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(131, 23)
            Me.Label1.TabIndex = 12
            Me.Label1.Text = "Select a Pallett"
            '
            'grdPalletts
            '
            Me.grdPalletts.AllowColMove = False
            Me.grdPalletts.AllowFilter = True
            Me.grdPalletts.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.grdPalletts.AllowSort = True
            Me.grdPalletts.AllowUpdate = False
            Me.grdPalletts.AllowUpdateOnBlur = False
            Me.grdPalletts.AlternatingRows = True
            Me.grdPalletts.BackColor = System.Drawing.Color.SkyBlue
            Me.grdPalletts.CaptionHeight = 18
            Me.grdPalletts.CollapseColor = System.Drawing.Color.Black
            Me.grdPalletts.DataChanged = False
            Me.grdPalletts.BackColor = System.Drawing.Color.Empty
            Me.grdPalletts.ExpandColor = System.Drawing.Color.Black
            Me.grdPalletts.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdPalletts.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdPalletts.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdPalletts.Location = New System.Drawing.Point(120, 80)
            Me.grdPalletts.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.grdPalletts.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdPalletts.Name = "grdPalletts"
            Me.grdPalletts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdPalletts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdPalletts.PreviewInfo.ZoomFactor = 75
            Me.grdPalletts.PrintInfo.ShowOptionsDialog = False
            Me.grdPalletts.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.grdPalletts.RowDivider = GridLines1
            Me.grdPalletts.RowHeight = 15
            Me.grdPalletts.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.grdPalletts.ScrollTips = False
            Me.grdPalletts.Size = New System.Drawing.Size(121, 128)
            Me.grdPalletts.TabIndex = 11
            Me.grdPalletts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;AlignHorz:General" & _
            ";BackColor:SkyBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor" & _
            "{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}OddRow{BackColor:Transparen" & _
            "t;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelector{Alig" & _
            "nImage:Center;}Footer{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:" & _
            "ControlDark;}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}E" & _
            "venRow{BackColor:Aqua;}Heading{Wrap:True;AlignHorz:Center;BackColor:Control;Bord" & _
            "er:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}FilterBar{}Style9{" & _
            "}Style8{}Style5{}Style4{}Style7{}Style6{}Style1{AlignHorz:General;}Style3{}Style" & _
            "2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" N" & _
            "ame="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Co" & _
            "lumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" D" & _
            "efRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect" & _
            ">0, 0, 117, 124</ClientRect><BorderSide>0</BorderSide><CaptionStyle parent=""Styl" & _
            "e2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle pare" & _
            "nt=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Fo" & _
            "oterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" " & _
            "/><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highli" & _
            "ghtRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyl" & _
            "e parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=" & _
            """Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal" & _
            """ me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style par" & _
            "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
            "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
            "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
            "=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me" & _
            "=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Re" & _
            "cordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" " & _
            "me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><" & _
            "Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0" & _
            ", 0, 117, 124</ClientArea></Blob>"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.Transparent
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(181, 232)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 32)
            Me.btnCancel.TabIndex = 10
            Me.btnCancel.Text = "Cancel"
            '
            'btnSelect
            '
            Me.btnSelect.BackColor = System.Drawing.Color.Transparent
            Me.btnSelect.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelect.ForeColor = System.Drawing.Color.Black
            Me.btnSelect.Location = New System.Drawing.Point(103, 232)
            Me.btnSelect.Name = "btnSelect"
            Me.btnSelect.Size = New System.Drawing.Size(75, 32)
            Me.btnSelect.TabIndex = 9
            Me.btnSelect.Text = "Select"
            '
            'frmSelectPallett
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Bitmap)
            Me.ClientSize = New System.Drawing.Size(364, 315)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.grdPalletts, Me.btnCancel, Me.btnSelect})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmSelectPallett"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Select a Pallett"
            CType(Me.grdPalletts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Property PallettID()
            Get
                Return Me.iPallettId
            End Get
            Set(ByVal Value)
                Me.iPallettId = Value
            End Set
        End Property

        Private Sub frmSelectPallett_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                Me.grdPalletts.DataSource = iDt.DefaultView
                Me.grdPalletts.Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.grdPalletts.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            Catch ex As Exception
                Me.PallettID = 0
                MsgBox("frmSelectPallett_Load (Me.grdPalletts.DataSource): " & ex.Message.ToString)
                Me.Close()
                Me.Dispose()
            Finally
                '**************************
                'Destroy the datatable
                '**************************
                If Not IsNothing(iDt) Then
                    If Not IsDBNull(iDt) Then
                        iDt.Dispose()
                    End If
                    iDt = Nothing
                End If
                '**************************
            End Try
        End Sub

        Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
            Me.Close()
            Me.Dispose()
        End Sub

        Private Sub grdPalletts_RowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPalletts.RowColChange
            Me.PallettID = CInt(Me.grdPalletts.Columns("Pallett_ID").Value)
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.PallettID = 0
            Me.Close()
            Me.Dispose()
        End Sub
    End Class
End Namespace