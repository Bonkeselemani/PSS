
Namespace Gui.WFadmin


Public Class frmWFadmin
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cboProduct As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManufacturer As PSS.Gui.Controls.ComboBox
    Friend WithEvents pnlEdit As System.Windows.Forms.Panel
    Friend WithEvents lblEdit As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lblWeightFactor As System.Windows.Forms.Label
    Friend WithEvents txtWeightFactor As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWFadmin))
        Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cboProduct = New PSS.Gui.Controls.ComboBox()
        Me.cboManufacturer = New PSS.Gui.Controls.ComboBox()
        Me.pnlEdit = New System.Windows.Forms.Panel()
        Me.lblEdit = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lblWeightFactor = New System.Windows.Forms.Label()
        Me.txtWeightFactor = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Manufacturer"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MainGrid
        '
        Me.MainGrid.AllowColMove = False
        Me.MainGrid.AllowColSelect = False
        Me.MainGrid.AllowDelete = True
        Me.MainGrid.AllowFilter = False
        Me.MainGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.MainGrid.AllowSort = False
        Me.MainGrid.AllowUpdate = False
        Me.MainGrid.AlternatingRows = True
        Me.MainGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainGrid.CaptionHeight = 17
        Me.MainGrid.CollapseColor = System.Drawing.Color.Black
        Me.MainGrid.DataChanged = False
        Me.MainGrid.BackColor = System.Drawing.Color.Empty
        Me.MainGrid.ExpandColor = System.Drawing.Color.Black
        Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
        Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.MainGrid.Location = New System.Drawing.Point(264, 16)
        Me.MainGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.MainGrid.PreviewInfo.ZoomFactor = 75
        Me.MainGrid.PrintInfo.ShowOptionsDialog = False
        Me.MainGrid.RecordSelectorWidth = 16
        GridLines1.Color = System.Drawing.Color.DarkGray
        GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
        Me.MainGrid.RowDivider = GridLines1
        Me.MainGrid.RowHeight = 15
        Me.MainGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.MainGrid.ScrollTips = False
        Me.MainGrid.Size = New System.Drawing.Size(272, 280)
        Me.MainGrid.TabIndex = 37
        Me.MainGrid.Text = "C1TrueDBGrid1"
        Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
        "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;BackColor:Co" & _
        "ntrol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}OddRow{}Foo" & _
        "ter{}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}HighlightRow{ForeCol" & _
        "or:HighlightText;BackColor:Highlight;}EvenRow{BackColor:Aqua;}Editor{}RecordSele" & _
        "ctor{AlignImage:Center;}Style9{}Style8{}Style3{}Style2{}Group{AlignVert:Center;B" & _
        "order:None,,0, 0, 0, 0;BackColor:ControlDark;}Style10{AlignHorz:Near;}</Data></S" & _
        "tyles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect" & _
        "=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
        "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
        "dth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
        "ClientRect>0, 0, 270, 278</ClientRect><BorderSide>0</BorderSide><CaptionStyle pa" & _
        "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
        "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
        "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
        """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
        "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
        "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
        "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
        "nt=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles>" & _
        "<Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pare" & _
        "nt=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=" & _
        """Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""" & _
        "Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""" & _
        "Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headi" & _
        "ng"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=" & _
        """Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</ho" & _
        "rzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Cl" & _
        "ientArea>0, 0, 270, 278</ClientArea></Blob>"
        '
        'cboProduct
        '
        Me.cboProduct.AutoComplete = True
        Me.cboProduct.Location = New System.Drawing.Point(128, 16)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(128, 21)
        Me.cboProduct.TabIndex = 38
        '
        'cboManufacturer
        '
        Me.cboManufacturer.AutoComplete = True
        Me.cboManufacturer.Location = New System.Drawing.Point(128, 40)
        Me.cboManufacturer.Name = "cboManufacturer"
        Me.cboManufacturer.Size = New System.Drawing.Size(128, 21)
        Me.cboManufacturer.TabIndex = 39
        '
        'pnlEdit
        '
        Me.pnlEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEdit.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUpdate, Me.txtWeightFactor, Me.lblEdit, Me.lblModel, Me.lblWeightFactor})
        Me.pnlEdit.Location = New System.Drawing.Point(16, 72)
        Me.pnlEdit.Name = "pnlEdit"
        Me.pnlEdit.Size = New System.Drawing.Size(240, 224)
        Me.pnlEdit.TabIndex = 40
        '
        'lblEdit
        '
        Me.lblEdit.BackColor = System.Drawing.Color.SteelBlue
        Me.lblEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdit.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblEdit.Name = "lblEdit"
        Me.lblEdit.Size = New System.Drawing.Size(240, 32)
        Me.lblEdit.TabIndex = 0
        Me.lblEdit.Text = "EDIT"
        Me.lblEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(16, 48)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(208, 16)
        Me.lblModel.TabIndex = 41
        Me.lblModel.Text = "Model:"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWeightFactor
        '
        Me.lblWeightFactor.Location = New System.Drawing.Point(16, 72)
        Me.lblWeightFactor.Name = "lblWeightFactor"
        Me.lblWeightFactor.Size = New System.Drawing.Size(96, 16)
        Me.lblWeightFactor.TabIndex = 41
        Me.lblWeightFactor.Text = "Weight Factor:"
        Me.lblWeightFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWeightFactor
        '
        Me.txtWeightFactor.Location = New System.Drawing.Point(120, 72)
        Me.txtWeightFactor.Name = "txtWeightFactor"
        Me.txtWeightFactor.TabIndex = 42
        Me.txtWeightFactor.Text = ""
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(16, 152)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(208, 56)
        Me.btnUpdate.TabIndex = 43
        Me.btnUpdate.Text = "UPDATE"
        '
        'frmWFadmin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(552, 317)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlEdit, Me.cboManufacturer, Me.cboProduct, Me.MainGrid, Me.Label2, Me.Label1})
        Me.Name = "frmWFadmin"
        Me.Text = "Weight Factor Administration"
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEdit.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmWFadmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        populateProdID()
        populateManufacturer()


    End Sub


    Private Sub populateProdID()

        Dim dt As DataTable
        Dim strSQL As String
        strSQL = "SELECT DISTINCT Prod_ID, Prod_Desc FROM lproduct ORDER BY Prod_Desc"
        dt = getDataTable(strSQL)

        cboProduct.DataSource = dt
        cboProduct.DisplayMember = dt.Columns("Prod_Desc").ToString
        cboProduct.ValueMember = dt.Columns("Prod_ID").ToString

    End Sub

    Private Sub populateManufacturer()

        Dim dt As DataTable
        Dim strSQL As String
        strSQL = "SELECT DISTINCT manuf_ID, manuf_Desc FROM lmanuf ORDER BY manuf_Desc"
        dt = getDataTable(strSQL)

        cboManufacturer.DataSource = dt
        cboManufacturer.DisplayMember = dt.Columns("Manuf_Desc").ToString
        cboManufacturer.ValueMember = dt.Columns("Manuf_ID").ToString

    End Sub


    Private Function getDataTable(ByVal strSQL As String) As DataTable

        Dim ds As New PSS.Data.Production.Joins()
        Dim dt As DataTable
        Try

            dt = ds.OrderEntrySelect(strSQL)
            ds = Nothing
            Return dt

        Catch ex As Exception
            ds = Nothing
            Return Nothing
        End Try

    End Function



End Class

End Namespace
