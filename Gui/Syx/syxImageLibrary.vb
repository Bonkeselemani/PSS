Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui

    Public Class syxImageLibrary
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
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents pnManageImageLibrary As System.Windows.Forms.Panel
        Friend WithEvents btnRemoveHasImageFlag As System.Windows.Forms.Button
        Friend WithEvents dgImageLib As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(syxImageLibrary))
            Me.pnManageImageLibrary = New System.Windows.Forms.Panel()
            Me.btnRemoveHasImageFlag = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.dgImageLib = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.pnManageImageLibrary.SuspendLayout()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgImageLib, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnManageImageLibrary
            '
            Me.pnManageImageLibrary.BackColor = System.Drawing.Color.SteelBlue
            Me.pnManageImageLibrary.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRemoveHasImageFlag, Me.btnAdd, Me.cboModels, Me.Label8})
            Me.pnManageImageLibrary.Location = New System.Drawing.Point(8, 376)
            Me.pnManageImageLibrary.Name = "pnManageImageLibrary"
            Me.pnManageImageLibrary.Size = New System.Drawing.Size(752, 112)
            Me.pnManageImageLibrary.TabIndex = 2
            '
            'btnRemoveHasImageFlag
            '
            Me.btnRemoveHasImageFlag.BackColor = System.Drawing.Color.Red
            Me.btnRemoveHasImageFlag.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveHasImageFlag.ForeColor = System.Drawing.Color.White
            Me.btnRemoveHasImageFlag.Location = New System.Drawing.Point(376, 16)
            Me.btnRemoveHasImageFlag.Name = "btnRemoveHasImageFlag"
            Me.btnRemoveHasImageFlag.Size = New System.Drawing.Size(352, 23)
            Me.btnRemoveHasImageFlag.TabIndex = 2
            Me.btnRemoveHasImageFlag.Text = "Remove Selected Row From Image Library"
            '
            'btnAdd
            '
            Me.btnAdd.BackColor = System.Drawing.Color.Green
            Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAdd.ForeColor = System.Drawing.Color.White
            Me.btnAdd.Location = New System.Drawing.Point(376, 72)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(352, 23)
            Me.btnAdd.TabIndex = 4
            Me.btnAdd.Text = "Add Image to Library"
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(72, 72)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(280, 21)
            Me.cboModels.TabIndex = 3
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
            "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
            "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(8, 73)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(64, 16)
            Me.Label8.TabIndex = 180
            Me.Label8.Text = "Model :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'dgImageLib
            '
            Me.dgImageLib.AllowUpdate = False
            Me.dgImageLib.AlternatingRows = True
            Me.dgImageLib.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgImageLib.FilterBar = True
            Me.dgImageLib.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgImageLib.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dgImageLib.Location = New System.Drawing.Point(8, 16)
            Me.dgImageLib.Name = "dgImageLib"
            Me.dgImageLib.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgImageLib.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgImageLib.PreviewInfo.ZoomFactor = 75
            Me.dgImageLib.Size = New System.Drawing.Size(728, 352)
            Me.dgImageLib.TabIndex = 1
            Me.dgImageLib.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "48</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 724, 348<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 724, 348</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'syxImageLibrary
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(768, 518)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnManageImageLibrary, Me.dgImageLib})
            Me.Name = "syxImageLibrary"
            Me.Text = "syxImageLibrary"
            Me.pnManageImageLibrary.ResumeLayout(False)
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgImageLib, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************************************************
        Private Sub syxImageLibrary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim objImgLib As New Syx()

            Try
                dt = objImgLib.GetModellistByProdTypes(" 33, 24, 76, 74 ")
                dt.LoadDataRow(New Object() {"0", "--Select--", ""}, True)
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")

                LoadImageLibrary()

                If PSS.Core.[Global].ApplicationUser.GetPermission("SyxManageImageLib") > 0 Then Me.pnManageImageLibrary.Visible = True Else Me.pnManageImageLibrary.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Generic.DisposeDT(dt) : objImgLib = Nothing
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub LoadImageLibrary()
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim objImgLib As New Syx()

            Try
                dt = objImgLib.GetImageLibrary()
                With Me.dgImageLib
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    .Splits(0).DisplayColumns("Model_ID").Visible = False

                    .Splits(0).DisplayColumns("Model").Width = 150
                    .Splits(0).DisplayColumns("Manuf Model").Width = 250
                    .Splits(0).DisplayColumns("Has Image?").Width = 100
                    .Splits(0).DisplayColumns("Last Updated Date").Width = 150
                    .Splits(0).DisplayColumns("Updated By").Width = 150

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                    Next i
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : objImgLib = Nothing
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim i As Integer = 0
            Dim objWIP As New SyxWip()

            Try
                If Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.SelectAll() : Me.cboModels.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = objWIP.AddRemoveModelToImageLibrary(Me.cboModels.DataSource.Table.select("Model_ID = " & Me.cboModels.SelectedValue)(0)("Model_Desc"), PSS.Core.ApplicationUser.IDuser, 1)
                    If i > 0 Then
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Enabled = True : Me.cboModels.SelectedValue = 0 : Me.cboModels.SelectAll() : Me.cboModels.Focus()
                        Me.LoadImageLibrary()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                objWIP = Nothing : Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub btnRemoveHasImageFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveHasImageFlag.Click
            Dim i As Integer = 0
            Dim objWIP As New SyxWip()

            Try
                If Me.dgImageLib.RowCount > 0 AndAlso Me.dgImageLib.Columns("Model_ID").CellValue(Me.dgImageLib.Row).ToString.Trim.Length > 0 AndAlso Me.dgImageLib.Columns("Model").CellValue(Me.dgImageLib.Row).ToString.Trim.Length > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = objWIP.AddRemoveModelToImageLibrary(Me.dgImageLib.Columns("Model").CellValue(Me.dgImageLib.Row).ToString.Trim, PSS.Core.ApplicationUser.IDuser, 0)
                    If i > 0 Then
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.LoadImageLibrary()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                objWIP = Nothing : Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub dgImageLib_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgImageLib.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()

                    objCopyAll.Text = "Copy all grid data to the clipboard."
                    objCopySelected.Text = "Copy selected rows to the clipboard."

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgMain_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dgImageLib)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dgImageLib)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '****************************************************************************************************


    End Class
End Namespace