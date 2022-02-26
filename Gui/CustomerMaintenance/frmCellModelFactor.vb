Namespace Gui.WFadmin


    Public Class frmCellModelFactor
        Inherits System.Windows.Forms.Form

        Private cCellModelFactor As New PSS.Data.Buisness.CellModelFactor()




#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            pnlEdit.Visible = False
            MainGrid.Visible = False
            getGroups()
            getManufacturer()
            getModel()

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
        Friend WithEvents pnl1 As System.Windows.Forms.Panel
        Friend WithEvents pnl2 As System.Windows.Forms.Panel
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
        Friend WithEvents btnNEW As System.Windows.Forms.Button
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnModelCheck As System.Windows.Forms.Button
        Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pnlEdit As System.Windows.Forms.Panel
        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblUnitHour As System.Windows.Forms.Label
        Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
        Friend WithEvents cboModel As System.Windows.Forms.ComboBox
        Friend WithEvents txtUnitsHour As System.Windows.Forms.TextBox
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCellModelFactor))
            Me.pnl1 = New System.Windows.Forms.Panel()
            Me.pnlEdit = New System.Windows.Forms.Panel()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.txtUnitsHour = New System.Windows.Forms.TextBox()
            Me.cboModel = New System.Windows.Forms.ComboBox()
            Me.cboManufacturer = New System.Windows.Forms.ComboBox()
            Me.lblUnitHour = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblManufacturer = New System.Windows.Forms.Label()
            Me.btnModelCheck = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.btnNEW = New System.Windows.Forms.Button()
            Me.cboGroup = New System.Windows.Forms.ComboBox()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.pnl2 = New System.Windows.Forms.Panel()
            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.pnl1.SuspendLayout()
            Me.pnlEdit.SuspendLayout()
            Me.pnl2.SuspendLayout()
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnl1
            '
            Me.pnl1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.pnl1.BackColor = System.Drawing.Color.LightBlue
            Me.pnl1.BackgroundImage = CType(resources.GetObject("pnl1.BackgroundImage"), System.Drawing.Bitmap)
            Me.pnl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlEdit, Me.btnModelCheck, Me.btnClear, Me.btnDelete, Me.btnNEW, Me.cboGroup, Me.lblGroup})
            Me.pnl1.Name = "pnl1"
            Me.pnl1.Size = New System.Drawing.Size(200, 536)
            Me.pnl1.TabIndex = 1
            '
            'pnlEdit
            '
            Me.pnlEdit.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlEdit.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnUpdate, Me.txtUnitsHour, Me.cboModel, Me.cboManufacturer, Me.lblUnitHour, Me.lblModel, Me.lblManufacturer})
            Me.pnlEdit.Location = New System.Drawing.Point(8, 56)
            Me.pnlEdit.Name = "pnlEdit"
            Me.pnlEdit.Size = New System.Drawing.Size(184, 224)
            Me.pnlEdit.TabIndex = 2
            '
            'btnCancel
            '
            Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(0, 192)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(184, 32)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "CANCEL"
            '
            'btnUpdate
            '
            Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.ForeColor = System.Drawing.Color.Black
            Me.btnUpdate.Location = New System.Drawing.Point(0, 160)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(184, 32)
            Me.btnUpdate.TabIndex = 4
            Me.btnUpdate.Text = "UPDATE/ INSERT"
            '
            'txtUnitsHour
            '
            Me.txtUnitsHour.Location = New System.Drawing.Point(8, 112)
            Me.txtUnitsHour.Name = "txtUnitsHour"
            Me.txtUnitsHour.Size = New System.Drawing.Size(56, 20)
            Me.txtUnitsHour.TabIndex = 3
            Me.txtUnitsHour.Text = ""
            '
            'cboModel
            '
            Me.cboModel.Location = New System.Drawing.Point(8, 64)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(160, 21)
            Me.cboModel.TabIndex = 2
            '
            'cboManufacturer
            '
            Me.cboManufacturer.Location = New System.Drawing.Point(8, 24)
            Me.cboManufacturer.Name = "cboManufacturer"
            Me.cboManufacturer.Size = New System.Drawing.Size(160, 21)
            Me.cboManufacturer.TabIndex = 1
            '
            'lblUnitHour
            '
            Me.lblUnitHour.BackColor = System.Drawing.Color.Transparent
            Me.lblUnitHour.Location = New System.Drawing.Point(8, 96)
            Me.lblUnitHour.Name = "lblUnitHour"
            Me.lblUnitHour.Size = New System.Drawing.Size(100, 16)
            Me.lblUnitHour.TabIndex = 0
            Me.lblUnitHour.Text = "UNITS per HOUR"
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.Transparent
            Me.lblModel.Location = New System.Drawing.Point(8, 48)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(100, 16)
            Me.lblModel.TabIndex = 0
            Me.lblModel.Text = "MODEL"
            '
            'lblManufacturer
            '
            Me.lblManufacturer.BackColor = System.Drawing.Color.Transparent
            Me.lblManufacturer.Location = New System.Drawing.Point(8, 8)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(100, 16)
            Me.lblManufacturer.TabIndex = 0
            Me.lblManufacturer.Text = "MANUFACTURER"
            '
            'btnModelCheck
            '
            Me.btnModelCheck.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnModelCheck.BackgroundImage = CType(resources.GetObject("btnModelCheck.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnModelCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnModelCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnModelCheck.Location = New System.Drawing.Point(0, 496)
            Me.btnModelCheck.Name = "btnModelCheck"
            Me.btnModelCheck.Size = New System.Drawing.Size(200, 32)
            Me.btnModelCheck.TabIndex = 9
            Me.btnModelCheck.Text = "MODEL CHECK"
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnClear.BackgroundImage = CType(resources.GetObject("btnClear.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.Location = New System.Drawing.Point(0, 464)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(200, 32)
            Me.btnClear.TabIndex = 8
            Me.btnClear.Text = "CLEAR"
            '
            'btnDelete
            '
            Me.btnDelete.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnDelete.BackgroundImage = CType(resources.GetObject("btnDelete.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelete.Location = New System.Drawing.Point(0, 432)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(200, 32)
            Me.btnDelete.TabIndex = 7
            Me.btnDelete.Text = "DELETE"
            '
            'btnNEW
            '
            Me.btnNEW.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnNEW.BackgroundImage = CType(resources.GetObject("btnNEW.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnNEW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNEW.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNEW.Location = New System.Drawing.Point(0, 400)
            Me.btnNEW.Name = "btnNEW"
            Me.btnNEW.Size = New System.Drawing.Size(200, 32)
            Me.btnNEW.TabIndex = 6
            Me.btnNEW.Text = "NEW"
            '
            'cboGroup
            '
            Me.cboGroup.Location = New System.Drawing.Point(8, 24)
            Me.cboGroup.Name = "cboGroup"
            Me.cboGroup.Size = New System.Drawing.Size(184, 21)
            Me.cboGroup.TabIndex = 1
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Transparent
            Me.lblGroup.Location = New System.Drawing.Point(8, 8)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(48, 16)
            Me.lblGroup.TabIndex = 0
            Me.lblGroup.Text = "GROUP"
            '
            'pnl2
            '
            Me.pnl2.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnl2.BackColor = System.Drawing.Color.Ivory
            Me.pnl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnl2.Controls.AddRange(New System.Windows.Forms.Control() {Me.MainGrid})
            Me.pnl2.Location = New System.Drawing.Point(200, 40)
            Me.pnl2.Name = "pnl2"
            Me.pnl2.Size = New System.Drawing.Size(552, 496)
            Me.pnl2.TabIndex = 2
            '
            'MainGrid
            '
            Me.MainGrid.AllowColMove = False
            Me.MainGrid.AllowColSelect = False
            Me.MainGrid.AllowDelete = True
            Me.MainGrid.AllowFilter = False
            Me.MainGrid.AllowSort = False
            Me.MainGrid.AllowUpdate = False
            Me.MainGrid.AlternatingRows = True
            Me.MainGrid.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.MainGrid.CaptionHeight = 17
            Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.MainGrid.Location = New System.Drawing.Point(8, 8)
            Me.MainGrid.Name = "MainGrid"
            Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.MainGrid.PreviewInfo.ZoomFactor = 75
            Me.MainGrid.RowHeight = 15
            Me.MainGrid.Size = New System.Drawing.Size(536, 480)
            Me.MainGrid.TabIndex = 10
            Me.MainGrid.Text = "C1TrueDBGrid1"
            Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;BackColor:Co" & _
            "ntrol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}OddRow{}Foo" & _
            "ter{}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}HighlightRow{ForeCol" & _
            "or:HighlightText;BackColor:Highlight;}EvenRow{BackColor:Aqua;}Editor{}RecordSele" & _
            "ctor{AlignImage:Center;}Style9{}Style8{}Style3{}Style2{}Style14{}Style15{}Group{" & _
            "AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style10{AlignHor" & _
            "z:Near;}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fal" & _
            "se"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17""" & _
            " ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder" & _
            """ RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizonta" & _
            "lScrollGroup=""1""><Height>478</Height><CaptionStyle parent=""Style2"" me=""Style10"" " & _
            "/><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""" & _
            "Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=" & _
            """Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle p" & _
            "arent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style" & _
            "7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow""" & _
            " me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Sele" & _
            "ctedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><" & _
            "ClientRect>0, 0, 534, 478</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sun" & _
            "ken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" m" & _
            "e=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""R" & _
            "ecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption""" & _
            " me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits>" & _
            "<Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>" & _
            "0, 0, 534, 478</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Print" & _
            "PageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Panel1
            '
            Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Bitmap)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1})
            Me.Panel1.Location = New System.Drawing.Point(200, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(552, 40)
            Me.Panel1.TabIndex = 0
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(320, 23)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Cell/ Model Factor Administration"
            '
            'frmCellModelFactor
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(752, 541)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.pnl2, Me.pnl1})
            Me.Name = "frmCellModelFactor"
            Me.Text = "frmCellModelFactor"
            Me.pnl1.ResumeLayout(False)
            Me.pnlEdit.ResumeLayout(False)
            Me.pnl2.ResumeLayout(False)
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Sub getGroups()
            Dim dtGroup As DataTable = cCellModelFactor.getDataTable("SELECT group_id, group_desc FROM lgroups WHERE group_id in (2,3,4) ORDER BY group_desc")
            cboGroup.DataSource = dtGroup
            cboGroup.DisplayMember = dtGroup.Columns("Group_Desc").ToString
            cboGroup.ValueMember = dtGroup.Columns("Group_ID").ToString
        End Sub
        Private Sub getManufacturer()
            Dim dtManuf As DataTable = cCellModelFactor.getDataTable("SELECT manuf_id, manuf_desc FROM lmanuf ORDER BY manuf_desc")
            cboManufacturer.DataSource = dtManuf
            cboManufacturer.DisplayMember = dtManuf.Columns("Manuf_Desc").ToString
            cboManufacturer.ValueMember = dtManuf.Columns("Manuf_ID").ToString
        End Sub
        Private Sub getModel()
            If cCellModelFactor._Manuf > 0 Then
                Dim dtModel As DataTable = cCellModelFactor.getDataTable("SELECT model_id, model_desc FROM tmodel WHERE manuf_id = " & cboManufacturer.SelectedValue & " AND Prod_ID = 2 ORDER BY model_desc")
                cboModel.DataSource = dtModel
                cboModel.DisplayMember = dtModel.Columns("Model_Desc").ToString
                cboModel.ValueMember = dtModel.Columns("Model_ID").ToString
            End If
        End Sub

        Private Sub getMainGridData()
            MainGrid.DataSource = cCellModelFactor.getMainGrid()
            FormatMainGrid()
            MainGrid.Visible = True
        End Sub


        Private Sub cboGroup_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGroup.SelectedValueChanged
            Try
                cCellModelFactor._Group = cboGroup.SelectedValue
                System.Windows.Forms.Application.DoEvents()
                getManufacturer()
                cboModel.Text = ""
                cboManufacturer.Text = ""
                txtUnitsHour.Text = ""
                getMainGridData()
                cboManufacturer.Enabled = True
                cboModel.Enabled = True
                MainGrid.Focus()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub cboManufacturer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectedValueChanged
            Try
                cCellModelFactor._Manuf = cboManufacturer.SelectedValue
                getModel()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
            Try
                cCellModelFactor._Model = cboModel.SelectedValue
                If Len(Trim(txtUnitsHour.Text)) > 0 Then
                    mthdUpdate()
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub btnNEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNEW.Click
            pnlEdit.Visible = True
            cboModel.Text = ""
            cboManufacturer.Text = ""
            txtUnitsHour.Text = ""
            cboManufacturer.Focus()
        End Sub

        Private Sub mthdUpdate()
            Dim blnUpdate As Boolean

            If IsNumeric(txtUnitsHour.Text) = False Then
                MsgBox("Please enter a numeric value for units per hour", MsgBoxStyle.Critical, "ERROR")
                txtUnitsHour.Text = ""
                txtUnitsHour.Focus()
                Exit Sub
            End If
            '//Validate value is double
            cCellModelFactor._UnitsHour = txtUnitsHour.Text
            cCellModelFactor._Manuf = cboManufacturer.SelectedValue
            cCellModelFactor._Model = cboModel.SelectedValue

            blnUpdate = cCellModelFactor.modifyTable
            System.Windows.Forms.Application.DoEvents()
            getMainGridData()
            cboManufacturer.Enabled = True
            cboModel.Enabled = True
        End Sub


        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            mthdUpdate()
        End Sub


        Private Sub FormatMainGrid()
            MainGrid.Splits(0).DisplayColumns(0).Visible = False
            MainGrid.Splits(0).DisplayColumns(1).Visible = False
            MainGrid.Splits(0).DisplayColumns(2).Width = 125
            MainGrid.Splits(0).DisplayColumns(3).Width = 125
            MainGrid.Splits(0).DisplayColumns(4).Width = 119
            MainGrid.Width = 390

        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            pnlEdit.Visible = False
            getManufacturer()
            getModel()
            cboGroup.Focus()
            txtUnitsHour.Text = ""
            cboManufacturer.Enabled = True
            cboModel.Enabled = True
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            cboModel.Text = ""
            cboManufacturer.Text = ""
            txtUnitsHour.Text = ""
            cboManufacturer.Enabled = True
            cboModel.Enabled = True
            MainGrid.Focus()
        End Sub

        Private Sub MainGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainGrid.Click
        End Sub


        Private Sub MainGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseUp

            Dim mGroup As Integer = 0
            Dim mModel As Integer = 0
            Dim mUnitsHour As Double = 0.0

            pnlEdit.Visible = True

            mGroup = cboGroup.SelectedValue
            mModel = MainGrid.Columns(1).Value

            cCellModelFactor._Group = MainGrid.Columns(0).Value
            cCellModelFactor._Model = MainGrid.Columns(1).Value
            mModel = MainGrid.Columns(1).Value
            mUnitsHour = MainGrid.Columns(4).Value

            cboManufacturer.SelectedValue = cCellModelFactor.getManufacturer(MainGrid.Columns(1).Value)
            getModel()
            cboModel.SelectedValue = mModel
            cCellModelFactor._Manuf = cboManufacturer.SelectedValue
            cCellModelFactor.getMainGrid()
            txtUnitsHour.Text = mUnitsHour
            cboManufacturer.Enabled = False
            cboModel.Enabled = False
            txtUnitsHour.Focus()
        End Sub

        Private Sub txtUnitsHour_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnitsHour.KeyDown
            If e.KeyValue = 13 Then
                mthdUpdate()
            End If
        End Sub

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim blnUpdate As Boolean
            '//Validate value is double
            cCellModelFactor._UnitsHour = txtUnitsHour.Text
            cCellModelFactor._Manuf = cboManufacturer.SelectedValue
            cCellModelFactor._Model = cboModel.SelectedValue

            blnUpdate = cCellModelFactor.deleteRecord
            System.Windows.Forms.Application.DoEvents()
            cboManufacturer.Enabled = True
            cboModel.Enabled = True
            getMainGridData()
            getManufacturer()
            cboModel.Text = ""
            cboManufacturer.Text = ""
            txtUnitsHour.Text = ""
            cboManufacturer.Enabled = True
            cboModel.Enabled = True
            MainGrid.Focus()
        End Sub

    End Class

End Namespace
