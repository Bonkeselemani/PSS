
Namespace Gui

    Public Class frmAddSUG
        Inherits System.Windows.Forms.Form

        Private objMClaim As PSS.Data.Buisness.WarrantyClaim.MClaim

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMClaim = New PSS.Data.Buisness.WarrantyClaim.MClaim()

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
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtSJUG As System.Windows.Forms.TextBox
        Friend WithEvents cmdAddSUG As System.Windows.Forms.Button
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents cmbModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents grdSugNum As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmdUpdateSUG As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAddSUG))
            Me.txtSJUG = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cmdAddSUG = New System.Windows.Forms.Button()
            Me.cmdUpdateSUG = New System.Windows.Forms.Button()
            Me.cmbModel = New PSS.Gui.Controls.ComboBox()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.grdSugNum = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.grdSugNum, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtSJUG
            '
            Me.txtSJUG.Location = New System.Drawing.Point(80, 48)
            Me.txtSJUG.Name = "txtSJUG"
            Me.txtSJUG.Size = New System.Drawing.Size(208, 22)
            Me.txtSJUG.TabIndex = 102
            Me.txtSJUG.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 56)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(64, 16)
            Me.Label10.TabIndex = 104
            Me.Label10.Text = "SJUG #:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdAddSUG
            '
            Me.cmdAddSUG.BackColor = System.Drawing.Color.Green
            Me.cmdAddSUG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdAddSUG.ForeColor = System.Drawing.Color.White
            Me.cmdAddSUG.Location = New System.Drawing.Point(80, 96)
            Me.cmdAddSUG.Name = "cmdAddSUG"
            Me.cmdAddSUG.Size = New System.Drawing.Size(200, 32)
            Me.cmdAddSUG.TabIndex = 105
            Me.cmdAddSUG.Text = "Add New SJUG"
            '
            'cmdUpdateSUG
            '
            Me.cmdUpdateSUG.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdUpdateSUG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdUpdateSUG.ForeColor = System.Drawing.Color.Black
            Me.cmdUpdateSUG.Location = New System.Drawing.Point(80, 160)
            Me.cmdUpdateSUG.Name = "cmdUpdateSUG"
            Me.cmdUpdateSUG.Size = New System.Drawing.Size(200, 32)
            Me.cmdUpdateSUG.TabIndex = 107
            Me.cmdUpdateSUG.Text = "Update SJUG Number"
            '
            'cmbModel
            '
            Me.cmbModel.AutoComplete = True
            Me.cmbModel.Location = New System.Drawing.Point(80, 16)
            Me.cmbModel.Name = "cmbModel"
            Me.cmbModel.Size = New System.Drawing.Size(208, 24)
            Me.cmbModel.TabIndex = 111
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.SteelBlue
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.White
            Me.lblModel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblModel.Location = New System.Drawing.Point(8, 16)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(64, 16)
            Me.lblModel.TabIndex = 109
            Me.lblModel.Text = "Model : "
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grdSugNum
            '
            Me.grdSugNum.AllowColMove = False
            Me.grdSugNum.AllowColSelect = False
            Me.grdSugNum.AlternatingRows = True
            Me.grdSugNum.FilterBar = True
            Me.grdSugNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdSugNum.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdSugNum.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdSugNum.Location = New System.Drawing.Point(304, 16)
            Me.grdSugNum.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdSugNum.Name = "grdSugNum"
            Me.grdSugNum.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdSugNum.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdSugNum.PreviewInfo.ZoomFactor = 75
            Me.grdSugNum.RowHeight = 20
            Me.grdSugNum.Size = New System.Drawing.Size(192, 288)
            Me.grdSugNum.TabIndex = 112
            Me.grdSugNum.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "1""><Height>284</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 188, 284</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 188, 284</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'frmAddSUG
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(536, 357)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdSugNum, Me.cmbModel, Me.lblModel, Me.cmdUpdateSUG, Me.cmdAddSUG, Me.txtSJUG, Me.Label10})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmAddSUG"
            Me.Text = "Add Motorola SUG Numbers"
            CType(Me.grdSugNum, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


        Protected Overrides Sub Finalize()
            objMClaim = Nothing
            MyBase.Finalize()
        End Sub

        '*************************************************************************
        Private Sub frmAddSJUG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.LoadModels()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub LoadSUGNumbers()
            Dim dt1 As DataTable
            Try
                dt1 = Me.objMClaim.GetMotoSUGNumbers(Me.cmbModel.SelectedValue, 0)
                Me.grdSugNum.ClearFields()
                Me.grdSugNum.DataSource = dt1.DefaultView
                SetSugNumGridProperties()
            Catch ex As Exception
                Throw New Exception("LoadAllSides:: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '*************************************************************************
        Private Sub LoadModels()
            Dim dtModels As New DataTable()
            Dim objMisc As New PSS.Data.Buisness.Misc()
            Try
                dtModels = objMisc.GetModels(2, 1, 1)
                With Me.cmbModel
                    .DataSource = dtModels.DefaultView
                    .DisplayMember = dtModels.Columns("Model_Desc").ToString
                    .ValueMember = dtModels.Columns("Model_ID").ToString
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                MsgBox("Error in frmBulkShipping.LoadModels:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(dtModels) Then
                    dtModels.Dispose()
                    dtModels = Nothing
                End If
                objMisc = Nothing
            End Try
        End Sub

        '************************************************************************
        Private Sub cmbModel_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModel.SelectionChangeCommitted
            If Me.cmbModel.SelectedValue > 0 Then
                LoadSUGNumbers()
                Me.txtSJUG.Focus()
            End If
        End Sub
        '*************************************************************************
        Private Sub txtSJUG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSJUG.KeyUp
            If e.KeyValue = 13 Then
                If Trim(Me.txtSJUG.Text) = "" Then
                    Exit Sub
                Else
                    AddSUG()
                End If
            End If
        End Sub
        '***********************************************************************
        Private Sub cmdAddSJUG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSUG.Click
            AddSUG()
        End Sub
        '***********************************************************************
        Private Sub AddSUG()
            Dim i As Integer = 0

            Try
                If Me.cmbModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Select Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.cmbModel.Focus()
                    Exit Sub
                End If

                If Trim(Me.txtSJUG.Text) = "" Then
                    MessageBox.Show("Please enter SJUG number.", "Input SJUG", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.txtSJUG.Focus()
                    Exit Sub
                End If

                'If UCase(Microsoft.VisualBasic.Left(Trim(Me.txtSJUG.Text), 4)) <> "SJUG" Then
                '    MessageBox.Show("Incorrect SJUG number. SJUG must start with SJUG.", "Input SJUG", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                '    Me.txtSJUG.Focus()
                '    Exit Sub
                'End If

                Me.cmdAddSUG.Enabled = False

                i = objMClaim.AddSUG(Me.cmbModel.SelectedValue, UCase(Trim(Me.txtSJUG.Text)))

                If i > 0 Then
                    MessageBox.Show("SJUG number has sucessfully added into the system.", "Add SJUG", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ElseIf i = 0 Then
                    MessageBox.Show("Failed to add SJUG number.", "Add SJUG", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
                LoadSUGNumbers()
            Catch ex As Exception
                MsgBox("frmAddSJUG.AddSUG:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                Me.cmdAddSUG.Enabled = True
                Me.cmbModel.SelectedValue = 0
                Me.txtSJUG.Text = ""
                Me.cmbModel.Focus()
            End Try

        End Sub

        Private Sub SetSugNumGridProperties()
            Dim iNumOfColumns As Integer = Me.grdSugNum.Columns.Count
            Dim i As Integer


            With Me.grdSugNum
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 125

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False
                .Splits(0).DisplayColumns(2).Visible = False

            End With
        End Sub

        Private Sub cmdUpdateSUG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSUG.Click
            Dim i As Integer = 0

            Try

                If Len(Trim(Me.grdSugNum.Columns("LensSUG_ID").Value)) = 0 Then
                    Exit Sub
                End If

                i = Me.objMClaim.AddSUG(Me.cmbModel.SelectedValue, Trim(Me.grdSugNum.Columns("LensSUG_text").Value), CInt(Trim(Me.grdSugNum.Columns("LensSUG_ID").Value)))

                If i > 0 Then
                    MessageBox.Show("Data is saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
                Me.LoadSUGNumbers()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "cmdUpdateSUG_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

    End Class

End Namespace