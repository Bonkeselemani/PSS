Imports PSS.Core
Imports PSS.Data
Imports PSS.Rules
Imports PSS.Core.[Global]

Namespace Gui.Billing


    Public Class mapCustBill
        Inherits System.Windows.Forms.Form

        Private dtCustomer, dtManufacturer, dtModel, dtTemplate As DataTable
        Private vCustomer, vManufacturer, vModel As Long


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
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents cboModel As System.Windows.Forms.ComboBox
        Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
        Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnGet As System.Windows.Forms.Button
        Friend WithEvents gridAmount As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents lblBillCodeDesc As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(mapCustBill))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Dim GridLines2 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.lblManufacturer = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.cboModel = New System.Windows.Forms.ComboBox()
            Me.cboManufacturer = New System.Windows.Forms.ComboBox()
            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnGet = New System.Windows.Forms.Button()
            Me.gridAmount = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblBillCodeDesc = New System.Windows.Forms.Label()
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridAmount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(8, 24)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(100, 16)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "CUSTOMER"
            '
            'lblManufacturer
            '
            Me.lblManufacturer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManufacturer.Location = New System.Drawing.Point(8, 72)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(100, 16)
            Me.lblManufacturer.TabIndex = 1
            Me.lblManufacturer.Text = "MANUFACTURER"
            '
            'lblModel
            '
            Me.lblModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.Location = New System.Drawing.Point(8, 120)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(100, 16)
            Me.lblModel.TabIndex = 2
            Me.lblModel.Text = "MODEL"
            '
            'cboCustomer
            '
            Me.cboCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.Location = New System.Drawing.Point(8, 40)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(184, 21)
            Me.cboCustomer.TabIndex = 3
            '
            'cboModel
            '
            Me.cboModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.Location = New System.Drawing.Point(8, 136)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(184, 21)
            Me.cboModel.TabIndex = 5
            '
            'cboManufacturer
            '
            Me.cboManufacturer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboManufacturer.ItemHeight = 13
            Me.cboManufacturer.Location = New System.Drawing.Point(8, 88)
            Me.cboManufacturer.Name = "cboManufacturer"
            Me.cboManufacturer.Size = New System.Drawing.Size(184, 21)
            Me.cboManufacturer.TabIndex = 4
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
            'Commented out by Asif on 10/16/2006
            'Me.MainGrid.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.MainGrid.BackColor = System.Drawing.Color.Empty
            Me.MainGrid.ExpandColor = System.Drawing.Color.Black
            Me.MainGrid.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.MainGrid.Location = New System.Drawing.Point(208, 24)
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
            Me.MainGrid.Size = New System.Drawing.Size(544, 440)
            Me.MainGrid.TabIndex = 37
            Me.MainGrid.Text = "C1TrueDBGrid1"
            Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{Back" & _
            "Color:Aqua;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:T" & _
            "rue;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:C" & _
            "ontrol;}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}Filter" & _
            "Bar{}OddRow{}Footer{}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}Styl" & _
            "e10{AlignHorz:Near;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Ed" & _
            "itor{}RecordSelector{AlignImage:Center;}Style9{}Style8{}Style3{}Style2{}Group{Ba" & _
            "ckColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style1{}</Data></S" & _
            "tyles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect" & _
            "=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
            "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
            "dth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
            "ClientRect>0, 0, 542, 438</ClientRect><BorderSide>0</BorderSide><CaptionStyle pa" & _
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
            "ientArea>0, 0, 542, 438</ClientArea></Blob>"
            '
            'btnGet
            '
            Me.btnGet.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGet.Location = New System.Drawing.Point(8, 176)
            Me.btnGet.Name = "btnGet"
            Me.btnGet.Size = New System.Drawing.Size(184, 23)
            Me.btnGet.TabIndex = 38
            Me.btnGet.Text = "Get Record"
            '
            'gridAmount
            '
            Me.gridAmount.AllowColMove = False
            Me.gridAmount.AllowColSelect = False
            Me.gridAmount.AllowDelete = True
            Me.gridAmount.AllowFilter = False
            Me.gridAmount.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.gridAmount.AllowSort = False
            Me.gridAmount.AllowUpdate = False
            Me.gridAmount.AlternatingRows = True
            Me.gridAmount.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gridAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.gridAmount.CaptionHeight = 17
            Me.gridAmount.CollapseColor = System.Drawing.Color.Black
            Me.gridAmount.DataChanged = False
            'Me.gridAmount.DeadAreaBackColor = System.Drawing.Color.Empty
            'Commented out by Asif on 10/16/2006
            Me.gridAmount.BackColor = System.Drawing.Color.Empty

            Me.gridAmount.ExpandColor = System.Drawing.Color.Black
            Me.gridAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gridAmount.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridAmount.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.gridAmount.Location = New System.Drawing.Point(24, 48)
            Me.gridAmount.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.gridAmount.Name = "gridAmount"
            Me.gridAmount.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gridAmount.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gridAmount.PreviewInfo.ZoomFactor = 75
            Me.gridAmount.PrintInfo.ShowOptionsDialog = False
            Me.gridAmount.RecordSelectorWidth = 16
            GridLines2.Color = System.Drawing.Color.DarkGray
            GridLines2.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.gridAmount.RowDivider = GridLines2
            Me.gridAmount.RowHeight = 15
            Me.gridAmount.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.gridAmount.ScrollTips = False
            Me.gridAmount.Size = New System.Drawing.Size(112, 104)
            Me.gridAmount.TabIndex = 39
            Me.gridAmount.Text = "C1TrueDBGrid1"
            Me.gridAmount.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Level=""0"" Caption=""Amount"" Dat" & _
            "aField=""""><ValueItems /></C1DataColumn></DataCols><Styles type=""C1.Win.C1TrueDBG" & _
            "rid.Design.ContextWrapper""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Styl" & _
            "e7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:HighlightText;BackColor:H" & _
            "ighlight;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColo" & _
            "r:ControlText;AlignVert:Center;}Inactive{ForeColor:InactiveCaptionText;BackColor" & _
            ":InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;}Editor{}Normal{Fo" & _
            "nt:Verdana, 8.25pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle1{}OddRow{}RecordSelector{AlignImage:Center;}Group{AlignVert:Center;Border:No" & _
            "ne,,0, 0, 0, 0;BackColor:ControlDark;}Style9{}Style8{}Style3{}Style2{}Style14{Al" & _
            "ignHorz:Near;}Style15{AlignHorz:Near;}Style16{}Style17{}Style10{AlignHorz:Near;}" & _
            "</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" Allo" & _
            "wColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnC" & _
            "aptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" Record" & _
            "SelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollG" & _
            "roup=""1""><ClientRect>0, 0, 110, 102</ClientRect><BorderSide>0</BorderSide><Capti" & _
            "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
            "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
            """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
            "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
            "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
            "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
            """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
            "Style parent=""Normal"" me=""Style1"" /><internalCols><C1DisplayColumn><HeadingStyle" & _
            " parent=""Style2"" me=""Style14"" /><Style parent=""Style1"" me=""Style15"" /><FooterSty" & _
            "le parent=""Style3"" me=""Style16"" /><EditorStyle parent=""Style5"" me=""Style17"" /><V" & _
            "isible>True</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</H" & _
            "eight><DCIdx>0</DCIdx></C1DisplayColumn></internalCols></C1.Win.C1TrueDBGrid.Mer" & _
            "geView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norma" & _
            "l"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" " & _
            "me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me" & _
            "=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hi" & _
            "ghlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""O" & _
            "ddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me" & _
            "=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1<" & _
            "/vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWid" & _
            "th>16</DefaultRecSelWidth><ClientArea>0, 0, 110, 102</ClientArea></Blob>"
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBillCodeDesc, Me.gridAmount})
            Me.Panel1.Location = New System.Drawing.Point(8, 224)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(160, 160)
            Me.Panel1.TabIndex = 40
            '
            'lblBillCodeDesc
            '
            Me.lblBillCodeDesc.Location = New System.Drawing.Point(24, 16)
            Me.lblBillCodeDesc.Name = "lblBillCodeDesc"
            Me.lblBillCodeDesc.Size = New System.Drawing.Size(120, 23)
            Me.lblBillCodeDesc.TabIndex = 40
            Me.lblBillCodeDesc.Text = "Label1"
            Me.lblBillCodeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mapCustBill
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(776, 485)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.btnGet, Me.MainGrid, Me.cboModel, Me.cboManufacturer, Me.cboCustomer, Me.lblModel, Me.lblManufacturer, Me.lblCustomer})
            Me.Name = "mapCustBill"
            Me.Text = "Mapping - Model to Bill Code to Customer"
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridAmount, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub mapCustBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            populateCustomer()
            cboCustomer.Focus()

        End Sub

        Private Sub populateCustomer()

            Dim objConn As PSS.Data.Production.Joins
            Dim strSQL As String = "SELECT cust_id, cust_name1 FROM tcustomer WHERE Cust_Name2 is null ORDER BY cust_name1"

            Try
                dtCustomer.Clear()
            Catch ex As Exception
                '//Do not display an error - will error if current datatable is null
            End Try

            dtCustomer = objConn.OrderEntrySelect(strSQL)

            cboCustomer.DataSource = dtCustomer
            cboCustomer.DisplayMember = dtCustomer.Columns("cust_name1").ToString
            cboCustomer.ValueMember = dtCustomer.Columns("cust_id").ToString

        End Sub
        Private Sub populateManufacturer()

            Dim objConn As PSS.Data.Production.Joins
            Dim strSQL As String = "SELECT * FROM lmanuf ORDER BY manuf_desc"

            Try
                dtManufacturer.Clear()
            Catch ex As Exception
                '//Do not display an error - will error if current datatable is null
            End Try

            dtManufacturer = objConn.OrderEntrySelect(strSQL)

            cboManufacturer.DataSource = dtManufacturer
            cboManufacturer.DisplayMember = dtManufacturer.Columns("manuf_desc").ToString
            cboManufacturer.ValueMember = dtManufacturer.Columns("manuf_id").ToString

        End Sub
        Private Sub populateModel(ByVal vManuf As Long)

            Dim objConn As PSS.Data.Production.Joins
            Dim strSQL As String = "SELECT model_id, model_desc FROM tmodel WHERE manuf_id = " & vManuf & " ORDER BY model_desc"

            Try
                dtModel.Clear()
            Catch ex As Exception
                '//Do not display an error - will error if current datatable is null
            End Try

            dtModel = objConn.OrderEntrySelect(strSQL)

            cboModel.DataSource = dtModel
            cboModel.DisplayMember = dtModel.Columns("model_desc").ToString
            cboModel.ValueMember = dtModel.Columns("model_id").ToString

        End Sub

        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted

            vCustomer = cboCustomer.SelectedValue
            populateManufacturer()
            cboManufacturer.Focus()

        End Sub
        Private Sub cboManufacturer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectionChangeCommitted

            vManufacturer = cboManufacturer.SelectedValue
            populateModel(vManufacturer)
            cboModel.Focus()

        End Sub
        Private Sub cboModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectionChangeCommitted

            vModel = cboModel.SelectedValue

        End Sub



        Private Sub getModelTemplate(ByVal vModelID As Long)


            If vModelID > 0 Then
                Dim objConn As PSS.Data.Production.Joins
                Dim strSQL As String = "SELECT lbillcodes.billcode_desc, tpsmap.* FROM " & _
                                        "tpsmap INNER JOIN lbillcodes ON tpsmap.billcode_id = lbillcodes.billcode_id " & _
                                        "WHERE Model_ID = " & vModelID & " ORDER BY lbillcodes.billcode_desc"
                Try
                    dtTemplate.Clear()
                Catch ex As Exception
                    '//Do not display an error - will error if current datatable is null
                End Try

                dtTemplate = objConn.OrderEntrySelect(strSQL)

                MainGrid.DataSource = dtTemplate
                System.Windows.Forms.Application.DoEvents()


            End If


        End Sub


        Private Sub btnGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGet.Click

            getModelTemplate(cboModel.SelectedValue)

        End Sub

        Private Sub MainGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseUp

            MainGrid.Enabled = False
            gridAmount.Visible = True
            gridAmount.Enabled = True


        End Sub

    End Class

End Namespace
