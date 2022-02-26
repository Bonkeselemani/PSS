Imports PSS.Gui.MotorolaSubcontract.frmMotoSubContShipping
Namespace Gui.MotorolaSubcontract
    Public Class frmSelectOverpack
        Inherits System.Windows.Forms.Form

        Private iDt As New DataTable()
        Private iOP As Integer
        'Private iErr As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByRef dt As DataTable)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            iDt = dt


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
        Friend WithEvents btnSelect As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents grdOverpacks As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectOverpack))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.btnSelect = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.grdOverpacks = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.grdOverpacks, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnSelect
            '
            Me.btnSelect.BackColor = System.Drawing.Color.Transparent
            Me.btnSelect.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelect.ForeColor = System.Drawing.Color.White
            Me.btnSelect.Location = New System.Drawing.Point(104, 248)
            Me.btnSelect.Name = "btnSelect"
            Me.btnSelect.Size = New System.Drawing.Size(75, 32)
            Me.btnSelect.TabIndex = 1
            Me.btnSelect.Text = "Select"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.Transparent
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(192, 248)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 32)
            Me.btnCancel.TabIndex = 6
            Me.btnCancel.Text = "Cancel"
            '
            'grdOverpacks
            '
            Me.grdOverpacks.AllowColMove = False
            Me.grdOverpacks.AllowFilter = True
            Me.grdOverpacks.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.grdOverpacks.AllowSort = True
            Me.grdOverpacks.AllowUpdate = False
            Me.grdOverpacks.AllowUpdateOnBlur = False
            Me.grdOverpacks.AlternatingRows = True
            Me.grdOverpacks.BackColor = System.Drawing.Color.SkyBlue
            Me.grdOverpacks.CaptionHeight = 18
            Me.grdOverpacks.CollapseColor = System.Drawing.Color.Black
            Me.grdOverpacks.DataChanged = False
            Me.grdOverpacks.BackColor = System.Drawing.Color.Empty
            Me.grdOverpacks.ExpandColor = System.Drawing.Color.Black
            Me.grdOverpacks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdOverpacks.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdOverpacks.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdOverpacks.Location = New System.Drawing.Point(80, 112)
            Me.grdOverpacks.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.grdOverpacks.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdOverpacks.Name = "grdOverpacks"
            Me.grdOverpacks.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdOverpacks.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdOverpacks.PreviewInfo.ZoomFactor = 75
            Me.grdOverpacks.PrintInfo.ShowOptionsDialog = False
            Me.grdOverpacks.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.grdOverpacks.RowDivider = GridLines1
            Me.grdOverpacks.RowHeight = 15
            Me.grdOverpacks.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.grdOverpacks.ScrollTips = False
            Me.grdOverpacks.Size = New System.Drawing.Size(222, 88)
            Me.grdOverpacks.TabIndex = 7
            Me.grdOverpacks.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{Font:Verdana, 8.25pt;BackColor:SkyBlue;}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}Style9{}OddRow{BackColor:Transparent;}RecordSelecto" & _
            "r{AlignImage:Center;}Heading{Wrap:True;AlignHorz:Center;BackColor:Control;Border" & _
            ":Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{Alig" & _
            "nHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C" & _
            "1TrueDBGrid.MergeView AllowColMove=""False"" Name="""" AlternatingRowStyle=""True"" Ca" & _
            "ptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""" & _
            "DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGro" & _
            "up=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 218, 84</ClientRect><BorderSi" & _
            "de>0</BorderSide><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle paren" & _
            "t=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBar" & _
            "Style parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3""" & _
            " /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""" & _
            "Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle " & _
            "parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Reco" & _
            "rdSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Se" & _
            "lected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid" & _
            ".MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""N" & _
            "ormal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headi" & _
            "ng"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal" & _
            """ me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me" & _
            "=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" m" & _
            "e=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal" & _
            """ me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplit" & _
            "s>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWid" & _
            "th>16</DefaultRecSelWidth><ClientArea>0, 0, 218, 84</ClientArea></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(78, 88)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(160, 23)
            Me.Label1.TabIndex = 8
            Me.Label1.Text = "Select an Overpack"
            '
            'frmSelectOverpack
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Bitmap)
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(370, 359)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.grdOverpacks, Me.btnCancel, Me.btnSelect})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmSelectOverpack"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Select Overpack"
            CType(Me.grdOverpacks, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        'Public Property DT()
        '    Get
        '        Return Me.iDt
        '    End Get
        '    Set(ByVal Value)
        '        Me.iDt = Value
        '    End Set
        'End Property

        Public Property OverPackID()
            Get
                Return Me.iOP
            End Get
            Set(ByVal Value)
                Me.iOP = Value
            End Set
        End Property

        'Public Property IsError()
        '    Get
        '        Return Me.iErr
        '    End Get
        '    Set(ByVal Value)
        '        Me.iErr = Value
        '    End Set
        'End Property

        Private Sub frmSelectOverpack_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'dim OPDt as New Me.DT
            'Me.lstOverpack.DataSource = iDt.Rows.Count
            'Dim R1 As DataRow = iDt.Select("MasterPacks < 4")(0)
            'Dim row As DataRow = dt.Select("CategoryName = 'Dairy Products'")(0)

            Try
                Me.grdOverpacks.DataSource = iDt.DefaultView
                'Me.grdOverpacks.DataSource = iDt.Select("MasterPacks < 4")(0)
                Me.grdOverpacks.Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.grdOverpacks.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                Me.grdOverpacks.Splits(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.grdOverpacks.Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Catch ex As Exception
                Me.OverPackID = 0
                MsgBox("frmSelectOverpack_Load (Me.grdOverpacks.DataSource): " & ex.Message.ToString)
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


            'Me.lstOverpack.ValueMember = Me.DT("Overpack_ID")
        End Sub

        Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
            Me.Close()
            Me.Dispose()
        End Sub

        Private Sub grdOverpacks_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdOverpacks.RowColChange
            Me.OverPackID = CInt(Me.grdOverpacks.Columns("Overpack_ID").Value)
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.OverPackID = 0
            Me.Close()
            Me.Dispose()
        End Sub
    End Class
End Namespace