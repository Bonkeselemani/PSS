Imports PSS.Core
Imports PSS.Data
Imports System.Windows.Forms


Namespace Gui.ExceptionBillItems

    Public Class frmExceptionBillItems
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
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblWorkorder As System.Windows.Forms.Label
        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents txtWorkorder As System.Windows.Forms.TextBox
        Friend WithEvents lblBillCodes As System.Windows.Forms.Label
        Friend WithEvents cboManuf As PSS.Gui.Controls.ComboBox
        Friend WithEvents btnSaveData As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmExceptionBillItems))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.lblWorkorder = New System.Windows.Forms.Label()
            Me.lblManufacturer = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.cboManuf = New PSS.Gui.Controls.ComboBox()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.txtWorkorder = New System.Windows.Forms.TextBox()
            Me.lblBillCodes = New System.Windows.Forms.Label()
            Me.btnSaveData = New System.Windows.Forms.Button()
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(24, 21)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(128, 16)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "CUSTOMER:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblWorkorder
            '
            Me.lblWorkorder.Location = New System.Drawing.Point(24, 44)
            Me.lblWorkorder.Name = "lblWorkorder"
            Me.lblWorkorder.Size = New System.Drawing.Size(128, 16)
            Me.lblWorkorder.TabIndex = 1
            Me.lblWorkorder.Text = "WORKORDER:"
            Me.lblWorkorder.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblManufacturer
            '
            Me.lblManufacturer.Location = New System.Drawing.Point(24, 77)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(128, 16)
            Me.lblManufacturer.TabIndex = 2
            Me.lblManufacturer.Text = "MANUFACTURER:"
            Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblModel
            '
            Me.lblModel.Location = New System.Drawing.Point(24, 101)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(128, 16)
            Me.lblModel.TabIndex = 3
            Me.lblModel.Text = "MODEL:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'MainGrid
            '
            Me.MainGrid.AllowColMove = False
            Me.MainGrid.AllowColSelect = False
            Me.MainGrid.AllowDelete = True
            Me.MainGrid.AllowFilter = False
            Me.MainGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.MainGrid.AllowSort = False
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
            Me.MainGrid.Location = New System.Drawing.Point(32, 160)
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
            Me.MainGrid.Size = New System.Drawing.Size(424, 112)
            Me.MainGrid.TabIndex = 37
            Me.MainGrid.Text = "C1TrueDBGrid1"
            Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;AlignVert:Ce" & _
            "nter;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Editor{}Normal{Font:Verdana, 8.25pt;}Style10{AlignHorz:Ne" & _
            "ar;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}EvenRow{BackColor:" & _
            "Aqua;}OddRow{}RecordSelector{AlignImage:Center;}Group{BackColor:ControlDark;Bord" & _
            "er:None,,0, 0, 0, 0;AlignVert:Center;}Style8{}Style3{}Style2{}Style9{}</Data></S" & _
            "tyles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect" & _
            "=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
            "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
            "dth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
            "ClientRect>0, 0, 422, 110</ClientRect><BorderSide>0</BorderSide><CaptionStyle pa" & _
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
            "ientArea>0, 0, 422, 110</ClientArea></Blob>"
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.Location = New System.Drawing.Point(160, 16)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(168, 21)
            Me.cboCustomer.TabIndex = 38
            '
            'cboManuf
            '
            Me.cboManuf.AutoComplete = True
            Me.cboManuf.Location = New System.Drawing.Point(160, 72)
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.Size = New System.Drawing.Size(168, 21)
            Me.cboManuf.TabIndex = 39
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.Location = New System.Drawing.Point(160, 96)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(168, 21)
            Me.cboModel.TabIndex = 40
            '
            'txtWorkorder
            '
            Me.txtWorkorder.Location = New System.Drawing.Point(160, 40)
            Me.txtWorkorder.Name = "txtWorkorder"
            Me.txtWorkorder.Size = New System.Drawing.Size(168, 20)
            Me.txtWorkorder.TabIndex = 41
            Me.txtWorkorder.Text = ""
            '
            'lblBillCodes
            '
            Me.lblBillCodes.Location = New System.Drawing.Point(40, 144)
            Me.lblBillCodes.Name = "lblBillCodes"
            Me.lblBillCodes.Size = New System.Drawing.Size(128, 16)
            Me.lblBillCodes.TabIndex = 43
            Me.lblBillCodes.Text = "BILLCODES:"
            '
            'btnSaveData
            '
            Me.btnSaveData.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnSaveData.Location = New System.Drawing.Point(32, 280)
            Me.btnSaveData.Name = "btnSaveData"
            Me.btnSaveData.Size = New System.Drawing.Size(424, 32)
            Me.btnSaveData.TabIndex = 44
            Me.btnSaveData.Text = "Save Data"
            '
            'frmExceptionBillItems
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(496, 325)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSaveData, Me.lblBillCodes, Me.txtWorkorder, Me.cboModel, Me.cboManuf, Me.cboCustomer, Me.MainGrid, Me.lblModel, Me.lblManufacturer, Me.lblWorkorder, Me.lblCustomer})
            Me.Name = "frmExceptionBillItems"
            Me.Text = "frmExceptionBillItems"
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private dtCust, dtManuf, dtModel, dtBillCodes As DataTable
        Private strSQL As String
        Private ds As Data.Production.Joins

        Private Sub frmExceptionBillItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            System.Windows.Forms.Application.DoEvents()
            cboCustomer.Focus()
            loadCustomer()
            System.Windows.Forms.Application.DoEvents()
            loadManuf()
            System.Windows.Forms.Application.DoEvents()
            cboCustomer.Focus()
        End Sub


#Region "Load Functions"

        Private Sub loadCustomer()
            dtCust = getCust()
            cboCustomer.DataSource = dtCust
            cboCustomer.DisplayMember = dtCust.Columns("Cust_Name1").ToString
            cboCustomer.ValueMember = dtCust.Columns("Cust_ID").ToString
        End Sub
        Private Sub loadManuf()
            dtManuf = getManuf()
            cboManuf.DataSource = dtManuf
            cboManuf.DisplayMember = dtManuf.Columns("Manuf_Desc").ToString
            cboManuf.ValueMember = dtManuf.Columns("Manuf_ID").ToString
        End Sub
        Private Sub loadModel(ByVal mManuf As Long)
            dtModel = getModel(mManuf)
            cboModel.DataSource = dtModel
            cboModel.DisplayMember = dtModel.Columns("Model_Desc").ToString
            cboModel.ValueMember = dtModel.Columns("Model_ID").ToString
        End Sub
        Private Sub loadBillCodes(ByVal mModel As Long)
            dtBillCodes = getBillCodes(mModel)
        End Sub

#End Region

#Region "On Change Events for Combo Boxes"




#End Region


#Region "Create Data Tables"

        Private Function getCust() As DataTable
            strSQL = "SELECT * FROM tcustomer WHERE cust_name2 is null ORDER BY cust_name1"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getManuf() As DataTable
            strSQL = "SELECT * FROM lmanuf ORDER BY Manuf_Desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getModel(ByVal vmanuf As Long) As DataTable
            strSQL = "SELECT * FROM tmodel WHERE manuf_ID = " & vmanuf & " ORDER BY Model_Desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getBillCodes(ByVal vmodel As Long) As DataTable
            strSQL = "SELECT lbillcodes.billcode_id, lbillcodes.billcode_desc, tpsmap.inactive, texceptionbillitems.Price_amount FROM tpsmap left outer join texceptionbillitems ON tpsmap.billcode_id = texceptionbillitems.billcode_id and tpsmap.model_id = texceptionbillitems.model_id inner join lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id WHERE tpsmap.model_id = " & vmodel & " ORDER BY lbillcodes.billcode_desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function

#End Region




        Private Sub cboManuf_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManuf.SelectedValueChanged
            Try
                loadModel(cboManuf.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
            Try
                loadBillCodes(cboModel.SelectedValue)

                Me.MainGrid.DataSource = dtBillCodes


                Me.MainGrid.Splits(0).DisplayColumns(0).Width = 100
                Me.MainGrid.Splits(0).DisplayColumns(1).Width = 250
                Me.MainGrid.Splits(0).DisplayColumns(2).Width = 0
                Me.MainGrid.Splits(0).DisplayColumns(3).Width = 100

            Catch ex As Exception
            End Try

        End Sub

        Private Sub MainGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseUp

            If MainGrid.Col.ToString < 3 Then
                MainGrid.Col = 3
            End If
            'MsgBox("Selected Columns: " & MainGrid.Col.ToString)


        End Sub
    End Class

End Namespace
