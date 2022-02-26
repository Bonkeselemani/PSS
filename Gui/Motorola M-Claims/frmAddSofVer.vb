Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Motorola

    Public Class frmAddSofVer
        Inherits System.Windows.Forms.Form

        Private _booPopulateData As Boolean = False
        Private _objMClaim As PSS.Data.Buisness.WarrantyClaim.MClaim

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objMClaim = New PSS.Data.Buisness.WarrantyClaim.MClaim()
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
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnUpdateSofVer As System.Windows.Forms.Button
        Friend WithEvents btnAddSofVer As System.Windows.Forms.Button
        Friend WithEvents txtSoftwareVersion As System.Windows.Forms.TextBox
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents dbgSofVer As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAddSofVer))
            Me.dbgSofVer = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.btnUpdateSofVer = New System.Windows.Forms.Button()
            Me.btnAddSofVer = New System.Windows.Forms.Button()
            Me.txtSoftwareVersion = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            CType(Me.dbgSofVer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dbgSofVer
            '
            Me.dbgSofVer.AllowColMove = False
            Me.dbgSofVer.AllowColSelect = False
            Me.dbgSofVer.AlternatingRows = True
            Me.dbgSofVer.FilterBar = True
            Me.dbgSofVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgSofVer.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgSofVer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgSofVer.Location = New System.Drawing.Point(360, 24)
            Me.dbgSofVer.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgSofVer.Name = "dbgSofVer"
            Me.dbgSofVer.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgSofVer.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgSofVer.PreviewInfo.ZoomFactor = 75
            Me.dbgSofVer.RowHeight = 20
            Me.dbgSofVer.Size = New System.Drawing.Size(192, 328)
            Me.dbgSofVer.TabIndex = 119
            Me.dbgSofVer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:" & _
            "Control;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddR" & _
            "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:Tr" & _
            "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
            "er;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}St" & _
            "yle10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
            "orWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
            "1""><Height>324</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 188, 324</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 188, 324</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.SteelBlue
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.White
            Me.lblModel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblModel.Location = New System.Drawing.Point(56, 24)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(64, 16)
            Me.lblModel.TabIndex = 117
            Me.lblModel.Text = "Model : "
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnUpdateSofVer
            '
            Me.btnUpdateSofVer.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnUpdateSofVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateSofVer.ForeColor = System.Drawing.Color.Black
            Me.btnUpdateSofVer.Location = New System.Drawing.Point(128, 168)
            Me.btnUpdateSofVer.Name = "btnUpdateSofVer"
            Me.btnUpdateSofVer.Size = New System.Drawing.Size(208, 32)
            Me.btnUpdateSofVer.TabIndex = 4
            Me.btnUpdateSofVer.Text = "Update Software Version"
            '
            'btnAddSofVer
            '
            Me.btnAddSofVer.BackColor = System.Drawing.Color.Green
            Me.btnAddSofVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddSofVer.ForeColor = System.Drawing.Color.White
            Me.btnAddSofVer.Location = New System.Drawing.Point(128, 104)
            Me.btnAddSofVer.Name = "btnAddSofVer"
            Me.btnAddSofVer.Size = New System.Drawing.Size(208, 32)
            Me.btnAddSofVer.TabIndex = 3
            Me.btnAddSofVer.Text = "Add New Software Version"
            '
            'txtSoftwareVersion
            '
            Me.txtSoftwareVersion.Location = New System.Drawing.Point(128, 56)
            Me.txtSoftwareVersion.MaxLength = 10
            Me.txtSoftwareVersion.Name = "txtSoftwareVersion"
            Me.txtSoftwareVersion.Size = New System.Drawing.Size(208, 20)
            Me.txtSoftwareVersion.TabIndex = 2
            Me.txtSoftwareVersion.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(0, 57)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(120, 16)
            Me.Label10.TabIndex = 114
            Me.Label10.Text = "Software Version:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.AutoCompletion = True
            Me.cboModels.AutoDropDown = True
            Me.cboModels.AutoSelect = True
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ColumnHeaders = False
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(128, 24)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(208, 21)
            Me.cboModels.TabIndex = 1
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'frmAddSofVer
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(616, 405)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboModels, Me.dbgSofVer, Me.lblModel, Me.btnUpdateSofVer, Me.btnAddSofVer, Me.txtSoftwareVersion, Me.Label10})
            Me.Name = "frmAddSofVer"
            Me.Text = "frmAddSofVer"
            CType(Me.dbgSofVer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************************************
        Private Sub frmAddSofVer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                objMisc = New PSS.Data.Buisness.Misc()
                dt = objMisc.GetModels(2, 1, 1)
                _booPopulateData = True
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "model_desc", "Model_id")
                Me.cboModels.SelectedValue = 0

                Me._booPopulateData = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                objMisc = Nothing
                Me._booPopulateData = False
            End Try
        End Sub

        '*********************************************************************************
        Private Sub cboModels_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModels.RowChange
            Try
                If Me._booPopulateData = True Then Exit Sub

                If Not IsNothing(Me.dbgSofVer.DataSource) Then Me.dbgSofVer.DataSource = Nothing

                If Me.cboModels.SelectedValue > 0 Then Me.PopulateSoftVerByModel()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboModels_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************************************
        Private Sub PopulateSoftVerByModel()
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                With Me.dbgSofVer
                    .DataSource = Nothing

                    dt = _objMClaim.GetMotoSoftwareVersion(Me.cboModels.SelectedValue, , )

                    .DataSource = dt.DefaultView

                    'Misc.PopulateC1DropDownList(Me., dt, "sv_SoftwareVersion", "sv_ID")

                    'Heading style (Horizontal Alignment to Center)
                    For i = 0 To (dt.Columns.Count - 1)
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        'Set individual column data horizontal alignment
                        .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    Next i

                    'Set Column Widths
                    .Splits(0).DisplayColumns("sv_SoftwareVersion").Width = 125

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("sv_ID").Visible = False
                    .Splits(0).DisplayColumns("sv_Model_ID").Visible = False

                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************************************
        Private Sub btnAddSofVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSofVer.Click
            Dim i As Integer = 0

            Try
                If Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboModels.SelectAll() : Me.cboModels.Focus()
                ElseIf Me.txtSoftwareVersion.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter software version.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtSoftwareVersion.SelectAll() : Me.txtSoftwareVersion.Focus()
                ElseIf ValidateSoftwareVersion(Me.txtSoftwareVersion.Text.Trim.ToUpper) = False Then
                    Me.txtSoftwareVersion.SelectAll() : Me.txtSoftwareVersion.Focus() : Exit Sub
                Else
                    i = Me._objMClaim.InsertUpdateSoftVersionList(Me.cboModels.SelectedValue, Me.txtSoftwareVersion.Text.Trim, )

                    If i > 0 Then
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtSoftwareVersion.Text = ""
                        Me.txtSoftwareVersion.Focus()
                    Else
                        Me.txtSoftwareVersion.SelectAll()
                        Me.txtSoftwareVersion.Focus()
                    End If
                    Me.PopulateSoftVerByModel()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddSofVer_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************************************
        Private Sub btnUpdateSofVer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateSofVer.Click
            Dim i As Integer = 0
            Dim strNewSofVer As String = ""
            Dim iSofVerID As Integer = 0

            Try
                If IsNothing(Me.dbgSofVer.DataSource) Then
                    Exit Sub
                ElseIf Me.dbgSofVer.RowCount = 0 OrElse Me.dbgSofVer.Columns.Count = 0 Then
                    Exit Sub
                ElseIf Me.dbgSofVer.Columns("sv_ID").Value.ToString.Trim.Length = 0 Then
                    MessageBox.Show("Please select row to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf ValidateSoftwareVersion(Me.dbgSofVer.Columns("sv_SoftwareVersion").Value.ToString.Trim.ToUpper) = False Then
                    Me.PopulateSoftVerByModel()
                    Me.txtSoftwareVersion.SelectAll() : Me.txtSoftwareVersion.Focus() : Exit Sub
                Else
                    i = Me._objMClaim.InsertUpdateSoftVersionList(Me.cboModels.SelectedValue, Me.dbgSofVer.Columns("sv_SoftwareVersion").Value.ToString.Trim.ToUpper, CInt(Me.dbgSofVer.Columns("sv_ID").Value))

                    If i > 0 Then
                        MessageBox.Show("Data have been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtSoftwareVersion.Text = ""
                        Me.txtSoftwareVersion.Focus()
                    End If
                    Me.PopulateSoftVerByModel()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "btnUpdateSofVer_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************************************
        Private Function ValidateSoftwareVersion(ByVal strSofVer As String) As Boolean
            Dim i As Integer = 0
            Dim booResult As Boolean = True

            Try
                If strSofVer.Trim.Length > 10 Then
                    MessageBox.Show("Software version can't longer than 10 characters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSoftwareVersion.SelectAll() : Me.txtSoftwareVersion.Focus() : booResult = False
                Else
                    For i = 1 To strSofVer.Trim.Length
                        If Char.IsLetterOrDigit(Mid(strSofVer.Trim, i, 1)) = False And Mid(strSofVer.Trim, i, 1) <> "." Then
                            MessageBox.Show("Software version contains invalid character.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.txtSoftwareVersion.SelectAll() : Me.txtSoftwareVersion.Focus() : booResult = False : Exit For
                        End If
                    Next i
                End If

                Return booResult
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "ValidateSoftwareVersion", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '*********************************************************************************
        Private Sub txtSoftwareVersion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoftwareVersion.KeyPress
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) And e.KeyChar <> "." Then
                e.Handled = True
            End If
        End Sub

        '*********************************************************************************

    End Class

End Namespace