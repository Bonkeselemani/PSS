Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Messaging.AmericanMessaging
    Public Class frmAmsLevel3Map
        Inherits System.Windows.Forms.Form

        Private _objMessAdmin As New Data.Buisness.MessAdmin()
        Private _dtMappings As New DataTable()
        Private _bLoading As Boolean = True

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
        Friend WithEvents dbgLevel3Mappings As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lstMapCodes As System.Windows.Forms.ListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAmsLevel3Map))
            Me.dbgLevel3Mappings = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lstMapCodes = New System.Windows.Forms.ListBox()
            CType(Me.dbgLevel3Mappings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dbgLevel3Mappings
            '
            Me.dbgLevel3Mappings.AllowColMove = False
            Me.dbgLevel3Mappings.AllowColSelect = False
            Me.dbgLevel3Mappings.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgLevel3Mappings.AllowUpdate = False
            Me.dbgLevel3Mappings.AllowUpdateOnBlur = False
            Me.dbgLevel3Mappings.AlternatingRows = True
            Me.dbgLevel3Mappings.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgLevel3Mappings.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgLevel3Mappings.FilterBar = True
            Me.dbgLevel3Mappings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgLevel3Mappings.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgLevel3Mappings.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgLevel3Mappings.MaintainRowCurrency = True
            Me.dbgLevel3Mappings.Name = "dbgLevel3Mappings"
            Me.dbgLevel3Mappings.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgLevel3Mappings.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgLevel3Mappings.PreviewInfo.ZoomFactor = 75
            Me.dbgLevel3Mappings.RowHeight = 20
            Me.dbgLevel3Mappings.Size = New System.Drawing.Size(408, 470)
            Me.dbgLevel3Mappings.TabIndex = 153
            Me.dbgLevel3Mappings.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cen" & _
            "ter;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{B" & _
            "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:Black;BackColor:LightSteelBlue;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" AllowColSe" & _
            "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>466</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 404, 466</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 404, 466</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lstMapCodes
            '
            Me.lstMapCodes.BackColor = System.Drawing.Color.FloralWhite
            Me.lstMapCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstMapCodes.ForeColor = System.Drawing.Color.Blue
            Me.lstMapCodes.ItemHeight = 15
            Me.lstMapCodes.Location = New System.Drawing.Point(144, 312)
            Me.lstMapCodes.Name = "lstMapCodes"
            Me.lstMapCodes.Size = New System.Drawing.Size(128, 49)
            Me.lstMapCodes.TabIndex = 154
            Me.lstMapCodes.Visible = False
            '
            'frmAmsLevel3Map
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(448, 470)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstMapCodes, Me.dbgLevel3Mappings})
            Me.ForeColor = System.Drawing.Color.White
            Me.Name = "frmAmsLevel3Map"
            Me.Text = "AMS Level 3 Bill Code Mappings"
            CType(Me.dbgLevel3Mappings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmAmsLevel3Map_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PopulateGrid()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmAmsLevel3Map_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub PopulateGrid()
            Dim dt As DataTable = Nothing
            Dim dtCodes As DataTable = Nothing
            Dim i As Integer, j As Integer

            Try
                Me.dbgLevel3Mappings.DataSource = Nothing

                Me._dtMappings = Me._objMessAdmin.GetBillCodes()

                If Me._dtMappings.Rows.Count > 0 Then
                    With Me.dbgLevel3Mappings
                        Dim dc As C1.Win.C1TrueDBGrid.C1DisplayColumn
                        Dim ddc As New C1.Win.C1TrueDBGrid.C1DataColumn()

                        .DataSource = Me._dtMappings '.DefaultView

                        .Row = -1

                        .Caption = "Level 3 Map Codes"

                        For Each dc In .Splits(0).DisplayColumns : dc.AutoSize() : Next dc

                        .MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None

                        .Splits(0).DisplayColumns("billcode_id").Visible = False
                        .Splits(0).DisplayColumns("AMSLevel3MapCodesID").Visible = False

                        dtCodes = Me._objMessAdmin.GetMapCodes()
                        Me.lstMapCodes.DataSource = dtCodes.DefaultView
                        Me.lstMapCodes.ValueMember = "AMSLevel3MapCodesID"
                        Me.lstMapCodes.DisplayMember = "Description"

                        ddc.Caption = "Select a Mapping"

                        .Columns.Add(ddc)

                        .Splits(0).DisplayColumns("Select a Mapping").Button = True
                        .Splits(0).DisplayColumns("Select a Mapping").Visible = True

                        Dim styUnassigned As New C1.Win.C1TrueDBGrid.Style()
                        Dim fntStyUnassigned As New Font(styUnassigned.Font, FontStyle.Bold)

                        styUnassigned.Font = fntStyUnassigned
                        styUnassigned.ForeColor = Color.Red

                        .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styUnassigned, "Unassigned")

                        .CellTips = C1.Win.C1TrueDBGrid.CellTipEnum.Anchored
                    End With

                    Misc.SetGridStyles(Me.dbgLevel3Mappings, False)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtCodes)

                Me._bLoading = False
            End Try
        End Sub

        Private Sub dbgLevel3Mappings_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles dbgLevel3Mappings.ButtonClick
            Dim i As Integer

            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                With Me.lstMapCodes
                    .Left = sender.Left + dbg.RecordSelectorWidth

                    For i = 0 To dbg.Splits(0).DisplayColumns.Count - 2 : .Left += IIf(dbg.Splits(0).DisplayColumns(i).Visible, dbg.Splits(0).DisplayColumns(i).Width, 0) : Next i

                    .Top = dbg.Top + dbg.RowTop(dbg.Row)
                    .Width = Math.Max(Me.dbgLevel3Mappings.Splits(0).DisplayColumns("Select a Mapping").Width, 115)

                    .Visible = True
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgLevel3Mappings_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub lstMapCodes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMapCodes.SelectedIndexChanged
            Try
                If Me._bLoading Or Not Me.lstMapCodes.Visible Then Return

                If Me.dbgLevel3Mappings.Row > -1 And Me.lstMapCodes.SelectedIndex > -1 Then
                    'Dim iRow As Integer

                    'For iRow = 0 To Me.dbgLevel3Mappings.SelectedRows.Count - 1
                    Dim dr As DataRow = Me._dtMappings.Rows(Me.dbgLevel3Mappings.Row)
                    Dim iAMSLevel3MapCodesID As Long = Me.lstMapCodes.SelectedValue
                    Dim iBillCodeID As Integer = dr("BillCode_ID")

                    dr.BeginEdit()

                    dr("AMSLevel3MapCodesID") = iAMSLevel3MapCodesID
                    dr("Level 3 Assigned Code") = Me.lstMapCodes.SelectedItem("Description")

                    dr.EndEdit()
                    dr.AcceptChanges()

                    Me.dbgLevel3Mappings.Columns("Select a Mapping").Text = Me.lstMapCodes.SelectedItem("Description")

                    If iAMSLevel3MapCodesID = 0 Then
                        Me._objMessAdmin.DropBillCode(iBillCodeID)
                    Else
                        Me._objMessAdmin.UpdateBillCodeMapping(iBillCodeID, iAMSLevel3MapCodesID)
                    End If
                    'Next iRow
                End If

                Me.lstMapCodes.Visible = False
                Me.lstMapCodes.SelectedIndex = -1
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "lstMapCodes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            Generic.DisposeDT(Me._dtMappings)
            MyBase.Finalize()
        End Sub

        Private Sub dbgLevel3Mappings_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles dbgLevel3Mappings.FetchCellTips
            Try
                If Not IsNothing(e.Column) Then
                    If Not e.Column.Name.Equals("Select a Mapping") Then
                        e.CellTip = "Click in the 'Select a Mapping' column for a combo box with mapping options."
                        e.TipStyle.BackColor = Color.LightYellow
                        e.TipStyle.ForeColor = Color.Indigo
                        e.TipStyle.Font = New Font("Arial", 11, FontStyle.Bold Or FontStyle.Italic)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgLevel3Mappings_FetchCellTips", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgLevel3Mappings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dbgLevel3Mappings.KeyDown
            Try
                If e.KeyCode = Keys.Escape And Me.lstMapCodes.Visible Then Me.lstMapCodes.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgLevel3Mappings_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub dbgLevel3Mappings_ColResize(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColResizeEventArgs) Handles dbgLevel3Mappings.ColResize
            Try
                If e.Column.Name.Equals("Select a mapping") Then Me.lstMapCodes.Width = Math.Max(e.Column.Width, 115)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgLevel3Mappings_ColResize", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
    End Class
End Namespace