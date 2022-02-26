Imports PSS.Rules

Namespace Gui

    Public Class PricingWin
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
        Friend WithEvents dbgMain As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtPartNum As System.Windows.Forms.TextBox
        Friend WithEvents txtPartDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtStdCost As System.Windows.Forms.TextBox
        Friend WithEvents txtAvgCost As System.Windows.Forms.TextBox
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnDel As System.Windows.Forms.Button
        Friend WithEvents chkInventory As System.Windows.Forms.CheckBox
        Friend WithEvents chkConsigned As System.Windows.Forms.CheckBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtMaxQty As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtMaterialGroup As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PricingWin))
            Me.dbgMain = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnDel = New System.Windows.Forms.Button()
            Me.txtPartNum = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtPartDesc = New System.Windows.Forms.TextBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.txtStdCost = New System.Windows.Forms.TextBox()
            Me.txtAvgCost = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.chkInventory = New System.Windows.Forms.CheckBox()
            Me.chkConsigned = New System.Windows.Forms.CheckBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtMaxQty = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtMaterialGroup = New System.Windows.Forms.TextBox()
            CType(Me.dbgMain, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'dbgMain
            '
            Me.dbgMain.AllowUpdate = False
            Me.dbgMain.AlternatingRows = True
            Me.dbgMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgMain.CaptionHeight = 17
            Me.dbgMain.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.dbgMain.FilterBar = True
            Me.dbgMain.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgMain.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgMain.Location = New System.Drawing.Point(216, 8)
            Me.dbgMain.Name = "dbgMain"
            Me.dbgMain.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgMain.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgMain.PreviewInfo.ZoomFactor = 75
            Me.dbgMain.RowHeight = 15
            Me.dbgMain.Size = New System.Drawing.Size(440, 432)
            Me.dbgMain.TabIndex = 0
            Me.dbgMain.TabStop = False
            Me.dbgMain.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "ScrollGroup=""1""><Height>430</Height><CaptionStyle parent=""Heading"" me=""Style23"" " & _
            "/><EditorStyle parent=""Editor"" me=""Style15"" /><EvenRowStyle parent=""EvenRow"" me=" & _
            """Style21"" /><FilterBarStyle parent=""FilterBar"" me=""Style26"" /><FooterStyle paren" & _
            "t=""Footer"" me=""Style17"" /><GroupStyle parent=""Group"" me=""Style25"" /><HeadingStyl" & _
            "e parent=""Heading"" me=""Style16"" /><HighLightRowStyle parent=""HighlightRow"" me=""S" & _
            "tyle20"" /><InactiveStyle parent=""Inactive"" me=""Style19"" /><OddRowStyle parent=""O" & _
            "ddRow"" me=""Style22"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style24"" " & _
            "/><SelectedStyle parent=""Selected"" me=""Style18"" /><Style parent=""Normal"" me=""Sty" & _
            "le14"" /><ClientRect>0, 29, 438, 430</ClientRect><BorderSide>0</BorderSide><Borde" & _
            "rStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.GroupByView></Splits><NamedStyl" & _
            "es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
            "arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
            "nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
            "t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
            "t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
            "ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
            "nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
            "/horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Cli" & _
            "entArea>0, 0, 438, 430</ClientArea><PrintPageHeaderStyle parent="""" me=""Style1"" /" & _
            "><PrintPageFooterStyle parent="""" me=""Style2"" /></Blob>"
            '
            'btnAdd
            '
            Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnAdd.Location = New System.Drawing.Point(16, 400)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(56, 32)
            Me.btnAdd.TabIndex = 9
            Me.btnAdd.Text = "Add"
            '
            'btnUpdate
            '
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnUpdate.Location = New System.Drawing.Point(80, 400)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(56, 32)
            Me.btnUpdate.TabIndex = 10
            Me.btnUpdate.Text = "Update"
            '
            'btnDel
            '
            Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnDel.Location = New System.Drawing.Point(144, 400)
            Me.btnDel.Name = "btnDel"
            Me.btnDel.Size = New System.Drawing.Size(56, 32)
            Me.btnDel.TabIndex = 11
            Me.btnDel.Text = "Delete"
            '
            'txtPartNum
            '
            Me.txtPartNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPartNum.Location = New System.Drawing.Point(16, 32)
            Me.txtPartNum.Name = "txtPartNum"
            Me.txtPartNum.Size = New System.Drawing.Size(184, 21)
            Me.txtPartNum.TabIndex = 1
            Me.txtPartNum.Text = ""
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(16, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(152, 16)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Part Number"
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(16, 64)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(152, 16)
            Me.Label3.TabIndex = 9
            Me.Label3.Text = "Part Description"
            '
            'txtPartDesc
            '
            Me.txtPartDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPartDesc.Location = New System.Drawing.Point(16, 80)
            Me.txtPartDesc.Name = "txtPartDesc"
            Me.txtPartDesc.Size = New System.Drawing.Size(184, 21)
            Me.txtPartDesc.TabIndex = 2
            Me.txtPartDesc.Text = ""
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtStdCost, Me.txtAvgCost, Me.Label4, Me.Label2})
            Me.GroupBox1.Location = New System.Drawing.Point(16, 112)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(184, 72)
            Me.GroupBox1.TabIndex = 3
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Pricing"
            '
            'txtStdCost
            '
            Me.txtStdCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStdCost.Location = New System.Drawing.Point(96, 40)
            Me.txtStdCost.Name = "txtStdCost"
            Me.txtStdCost.Size = New System.Drawing.Size(80, 21)
            Me.txtStdCost.TabIndex = 4
            Me.txtStdCost.Text = ""
            '
            'txtAvgCost
            '
            Me.txtAvgCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAvgCost.Location = New System.Drawing.Point(8, 40)
            Me.txtAvgCost.Name = "txtAvgCost"
            Me.txtAvgCost.Size = New System.Drawing.Size(80, 21)
            Me.txtAvgCost.TabIndex = 3
            Me.txtAvgCost.Text = ""
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(96, 24)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(64, 16)
            Me.Label4.TabIndex = 1
            Me.Label4.Text = "Std. Cost"
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(8, 24)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 16)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Avg. Cost"
            '
            'btnClear
            '
            Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnClear.Location = New System.Drawing.Point(16, 360)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(184, 32)
            Me.btnClear.TabIndex = 8
            Me.btnClear.TabStop = False
            Me.btnClear.Text = "Clear Inputs"
            '
            'chkInventory
            '
            Me.chkInventory.Location = New System.Drawing.Point(48, 247)
            Me.chkInventory.Name = "chkInventory"
            Me.chkInventory.Size = New System.Drawing.Size(120, 24)
            Me.chkInventory.TabIndex = 5
            Me.chkInventory.Text = "Inventory Part"
            '
            'chkConsigned
            '
            Me.chkConsigned.Location = New System.Drawing.Point(48, 271)
            Me.chkConsigned.Name = "chkConsigned"
            Me.chkConsigned.Size = New System.Drawing.Size(120, 24)
            Me.chkConsigned.TabIndex = 6
            Me.chkConsigned.Text = "Consigned Part"
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(65, 192)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(88, 16)
            Me.Label5.TabIndex = 14
            Me.Label5.Text = "Max Quantity:"
            '
            'txtMaxQty
            '
            Me.txtMaxQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxQty.Location = New System.Drawing.Point(65, 208)
            Me.txtMaxQty.MaxLength = 3
            Me.txtMaxQty.Name = "txtMaxQty"
            Me.txtMaxQty.Size = New System.Drawing.Size(80, 21)
            Me.txtMaxQty.TabIndex = 4
            Me.txtMaxQty.Text = ""
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(16, 304)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(152, 16)
            Me.Label6.TabIndex = 16
            Me.Label6.Text = "Material Group"
            '
            'txtMaterialGroup
            '
            Me.txtMaterialGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaterialGroup.Location = New System.Drawing.Point(16, 320)
            Me.txtMaterialGroup.Name = "txtMaterialGroup"
            Me.txtMaterialGroup.Size = New System.Drawing.Size(184, 21)
            Me.txtMaterialGroup.TabIndex = 7
            Me.txtMaterialGroup.Text = ""
            Me.txtMaterialGroup.WordWrap = False
            '
            'PricingWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(664, 445)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.txtMaterialGroup, Me.Label5, Me.txtMaxQty, Me.chkConsigned, Me.btnClear, Me.GroupBox1, Me.Label3, Me.txtPartDesc, Me.Label1, Me.txtPartNum, Me.btnDel, Me.btnUpdate, Me.btnAdd, Me.dbgMain, Me.chkInventory})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "PricingWin"
            Me.Text = "Pricing"
            CType(Me.dbgMain, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************************************************************
        Private Sub PricingWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                UpdateWin()
                If PSS.Core.ApplicationUser.GetPermission(Me.GetType.Name) < 2 Then
                    Me.btnAdd.Enabled = False
                    Me.btnUpdate.Enabled = False
                    Me.btnDel.Enabled = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PricingWin_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************************************************
        Private Sub UpdateWin()
            Dim dt As DataTable

            Try
                If Not IsNothing(Me.dbgMain.DataSource) Then dt = Me.dbgMain.DataSource.Table
                Me.dbgMain.DataSource = Rules.Pricing.GetData()
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************************
        Private Sub dbgMain_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgMain.RowColChange
            Try
                btnClear_Click(Me, EventArgs.Empty)
                Me.txtPartNum.Text = Me.dbgMain.Columns(1).Text
                Me.txtPartDesc.Text = Me.dbgMain.Columns(2).Text
                Me.txtAvgCost.Text = Me.dbgMain.Columns(3).Text
                Me.txtStdCost.Text = Me.dbgMain.Columns(4).Text
                If Me.dbgMain.Columns(5).Text = "YES" Then
                    Me.chkInventory.Checked = True
                Else
                    Me.chkInventory.Checked = False
                End If

                If Me.dbgMain.Columns(6).Text = "YES" Then
                    Me.chkConsigned.Checked = True
                Else
                    Me.chkConsigned.Checked = False
                End If

                Me.txtMaxQty.Text = Me.dbgMain.Columns(7).Text
                Me.txtMaterialGroup.Text = Me.dbgMain.Columns("Material Group").Text
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgMain_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.txtPartNum.Text = ""
                Me.txtPartDesc.Text = ""
                Me.txtAvgCost.Text = ""
                Me.txtStdCost.Text = ""
                Me.chkInventory.Checked = False
                Me.txtPartNum.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************************************************
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim iFlg, iMax, iCPFlg As Integer

            Try
                iFlg = 0 : iMax = 0 : iCPFlg = 0

                If Me.chkInventory.Checked = True Then iFlg = 1 Else iFlg = 0
                If Me.chkConsigned.Checked = True Then iCPFlg = 1 Else iCPFlg = 0
                If Len(Trim(Me.txtMaxQty.Text)) > 0 Then iMax = Convert.ToInt32(Me.txtMaxQty.Text)

                If CheckFields() = False Then Exit Sub

                If PSS.Data.Buisness.Pricing.GetPartCount(Me.txtPartNum.Text.Trim) > 0 Then
                    MessageBox.Show("Part number " & Me.txtPartNum.Text.Trim & " is existed in the system.", "CheckFields", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If Pricing.Insert(Me.txtPartNum.Text, Me.txtPartDesc.Text, Me.txtAvgCost.Text, Me.txtStdCost.Text, iFlg, iCPFlg, iMax, Me.txtMaterialGroup.Text.Trim) = True Then
                        UpdateWin()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAdd_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************************************************
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim iFlg, iMax, iCPFlg, iPSPriceID As Integer

            Try
                iFlg = 0 : iMax = 0 : iCPFlg = 0 : iPSPriceID = 0

                If Me.chkInventory.Checked = True Then iFlg = 1 Else iFlg = 0
                If Me.chkConsigned.Checked = True Then iCPFlg = 1 Else iCPFlg = 0

                If Len(Trim(Me.txtMaxQty.Text)) > 0 Then iMax = Me.txtMaxQty.Text
                If CheckFields() = False Then Exit Sub
                iPSPriceID = PSS.Data.Buisness.Pricing.GetPSPriceID(Me.txtPartNum.Text.Trim)

                If iPSPriceID = 0 Then
                    MessageBox.Show("Part number " & Me.txtPartNum.Text.Trim & " does not exist in the system for update.", "CheckFields", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Pricing.Update(iPSPriceID, Me.txtPartNum.Text, Me.txtPartDesc.Text, Me.txtAvgCost.Text, Me.txtStdCost.Text, iFlg, iCPFlg, iMax, Me.txtMaterialGroup.Text.Trim) = True Then
                    UpdateWin()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************************************************
        Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
            Try
                If CheckFields() = False Then Exit Sub
                If Pricing.Delete(Me.dbgMain.Columns(0).Text) = True Then
                    UpdateWin()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDel_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************************************************
        Private Function CheckFields() As Boolean
            Dim booReturnVal As Boolean = False

            Try
                If Me.txtAvgCost.Text = "" OrElse Me.txtAvgCost.Text = Nothing Then
                    MessageBox.Show("Average cost is missing.", "CheckFields", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtPartDesc.Text = "" Or Me.txtPartDesc.Text = Nothing Then
                    MessageBox.Show("Part description is missing.", "CheckFields", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtPartNum.Text = "" Or Me.txtPartNum.Text = Nothing Then
                    MessageBox.Show("Part number is missing.", "CheckFields", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtStdCost.Text = "" Or Me.txtStdCost.Text = Nothing Then
                    MessageBox.Show("Standard cost is missing.", "CheckFields", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    booReturnVal = True
                End If
                Return booReturnVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************************************************************

    End Class

End Namespace