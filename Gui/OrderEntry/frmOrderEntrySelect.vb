Imports CrystalDecisions.CrystalReports.Engine
Imports PSS.Core
Imports PSS.Data
Imports C1.Win.C1TrueDBGrid


Namespace Gui.OrderEntry

    Public Class frmOrderEntrySelect
        Inherits System.Windows.Forms.Form

        Private xCount As Integer
        Private CustomerID(2000) As Integer
        Private LocationID(2000) As Integer

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
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents tdbGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblPurchaseOrder As System.Windows.Forms.Label
        Friend WithEvents cboPurchaseOrder As System.Windows.Forms.ComboBox
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents btnExit As System.Windows.Forms.Button
        Friend WithEvents btnPrintPO As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOrderEntrySelect))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.tdbGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.cboLocation = New System.Windows.Forms.ComboBox()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.btnNew = New System.Windows.Forms.Button()
            Me.lblPurchaseOrder = New System.Windows.Forms.Label()
            Me.cboPurchaseOrder = New System.Windows.Forms.ComboBox()
            Me.btnExit = New System.Windows.Forms.Button()
            Me.btnPrintPO = New System.Windows.Forms.Button()
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tdbGrid
            '
            Me.tdbGrid.AllowFilter = True
            Me.tdbGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.tdbGrid.AllowSort = True
            Me.tdbGrid.AllowUpdate = False
            Me.tdbGrid.AlternatingRows = True
            Me.tdbGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tdbGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdbGrid.CaptionHeight = 17
            Me.tdbGrid.CollapseColor = System.Drawing.Color.Black
            Me.tdbGrid.DataChanged = False
            Me.tdbGrid.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.tdbGrid.BackColor = System.Drawing.Color.Empty
            Me.tdbGrid.ExpandColor = System.Drawing.Color.Black
            Me.tdbGrid.FilterBar = True
            Me.tdbGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdbGrid.Location = New System.Drawing.Point(368, 0)
            Me.tdbGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.tdbGrid.Name = "tdbGrid"
            Me.tdbGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbGrid.PreviewInfo.ZoomFactor = 75
            Me.tdbGrid.PrintInfo.ShowOptionsDialog = False
            Me.tdbGrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.tdbGrid.RowDivider = GridLines1
            Me.tdbGrid.RowHeight = 15
            Me.tdbGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.tdbGrid.ScrollTips = False
            Me.tdbGrid.Size = New System.Drawing.Size(400, 466)
            Me.tdbGrid.TabIndex = 0
            Me.tdbGrid.Text = "C1TrueDBGrid1"
            Me.tdbGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:Aqua;}Selected{ForeColor:HighlightText;BackCol" & _
            "or:Highlight;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Inactive{ForeColor:InactiveCaptionText;BackC" & _
            "olor:InactiveCaption;}FilterBar{}OddRow{}Footer{}Caption{AlignHorz:Center;}Style" & _
            "25{}Normal{Font:Verdana, 8.25pt;}Style26{}HighlightRow{ForeColor:HighlightText;B" & _
            "ackColor:Highlight;}Style24{}Style23{AlignHorz:Near;}Style22{}Style21{}Style20{}" & _
            "RecordSelector{AlignImage:Center;}Style18{}Style19{}Style14{}Style15{}Style16{}S" & _
            "tyle17{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.GroupByView Name="""" Alterna" & _
            "tingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeig" & _
            "ht=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16" & _
            """ VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 398, 464</" & _
            "ClientRect><DefRecSelWidth>16</DefRecSelWidth><CaptionStyle parent=""Heading"" me=" & _
            """Style23"" /><EditorStyle parent=""Editor"" me=""Style15"" /><EvenRowStyle parent=""Ev" & _
            "enRow"" me=""Style21"" /><FilterBarStyle parent=""FilterBar"" me=""Style26"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style17"" /><GroupStyle parent=""Group"" me=""Style25"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style16"" /><HighLightRowStyle parent=""Highlight" & _
            "Row"" me=""Style20"" /><InactiveStyle parent=""Inactive"" me=""Style19"" /><OddRowStyle" & _
            " parent=""OddRow"" me=""Style22"" /><RecordSelectorStyle parent=""RecordSelector"" me=" & _
            """Style24"" /><SelectedStyle parent=""Selected"" me=""Style18"" /><Style parent=""Norma" & _
            "l"" me=""Style14"" /></C1.Win.C1TrueDBGrid.GroupByView></Splits><NamedStyles><Style" & _
            " parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""He" & _
            "ading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headi" & _
            "ng"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal" & _
            """ me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal" & _
            """ me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me" & _
            "=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0" & _
            ", 0, 398, 464</ClientArea></Blob>"
            '
            'lblLocation
            '
            Me.lblLocation.Location = New System.Drawing.Point(24, 80)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(64, 16)
            Me.lblLocation.TabIndex = 4
            Me.lblLocation.Text = "Location"
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(24, 24)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(64, 16)
            Me.lblCustomer.TabIndex = 3
            Me.lblCustomer.Text = "Customer"
            '
            'cboCustomer
            '
            Me.cboCustomer.Location = New System.Drawing.Point(24, 48)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(288, 21)
            Me.cboCustomer.TabIndex = 5
            '
            'cboLocation
            '
            Me.cboLocation.Location = New System.Drawing.Point(24, 104)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(288, 21)
            Me.cboLocation.TabIndex = 6
            '
            'btnUpdate
            '
            Me.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdate.Location = New System.Drawing.Point(232, 352)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(96, 48)
            Me.btnUpdate.TabIndex = 54
            Me.btnUpdate.Text = "Update Order Entry"
            '
            'btnDelete
            '
            Me.btnDelete.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDelete.Location = New System.Drawing.Point(128, 352)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(96, 48)
            Me.btnDelete.TabIndex = 53
            Me.btnDelete.Text = "Delete Order Entry"
            '
            'btnNew
            '
            Me.btnNew.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNew.Location = New System.Drawing.Point(24, 352)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(96, 48)
            Me.btnNew.TabIndex = 52
            Me.btnNew.Text = "New Order Entry"
            '
            'lblPurchaseOrder
            '
            Me.lblPurchaseOrder.Location = New System.Drawing.Point(24, 144)
            Me.lblPurchaseOrder.Name = "lblPurchaseOrder"
            Me.lblPurchaseOrder.Size = New System.Drawing.Size(104, 16)
            Me.lblPurchaseOrder.TabIndex = 55
            Me.lblPurchaseOrder.Text = "Purchase Order"
            '
            'cboPurchaseOrder
            '
            Me.cboPurchaseOrder.Location = New System.Drawing.Point(24, 168)
            Me.cboPurchaseOrder.Name = "cboPurchaseOrder"
            Me.cboPurchaseOrder.Size = New System.Drawing.Size(288, 21)
            Me.cboPurchaseOrder.TabIndex = 56
            '
            'btnExit
            '
            Me.btnExit.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnExit.Location = New System.Drawing.Point(24, 408)
            Me.btnExit.Name = "btnExit"
            Me.btnExit.Size = New System.Drawing.Size(304, 48)
            Me.btnExit.TabIndex = 57
            Me.btnExit.Text = "E&xit"
            '
            'btnPrintPO
            '
            Me.btnPrintPO.Location = New System.Drawing.Point(232, 200)
            Me.btnPrintPO.Name = "btnPrintPO"
            Me.btnPrintPO.TabIndex = 58
            Me.btnPrintPO.Text = "Print"
            '
            'frmOrderEntrySelect
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(774, 466)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintPO, Me.btnExit, Me.cboPurchaseOrder, Me.lblPurchaseOrder, Me.btnUpdate, Me.btnDelete, Me.btnNew, Me.cboLocation, Me.cboCustomer, Me.lblLocation, Me.lblCustomer, Me.tdbGrid})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "frmOrderEntrySelect"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Order Entry Selection"
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmOrderEntrySelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            PopulatetdbGrid()   '//Loads data into true dbgrid

        End Sub

        Private Sub PopulatePurchaseOrderList()

            If Len(Trim(cboLocation.Text)) < 1 Then
                cboLocation.SelectedIndex = 0
            End If

            Dim xCount As Integer = 0
            Dim aCount As Integer = 0

            ClearCboPurchaseOrder()     '//Start by clearing out the control to be populated

            Try
                Dim dtCustomer As DataTable
                dtCustomer = PSS.Data.Production.Joins.OrderEntrySelect("Select distinct tcustomer.cust_name1, tlocation.loc_name, tpurchaseorder.po_id from tworkorder, tlocation, tpurchaseorder, tcustomer where tworkorder.loc_id=tlocation.loc_id and tworkorder.po_id = tpurchaseorder.po_id and tlocation.cust_id = tcustomer.cust_id")
                Dim rCustomer As DataRow

                For xCount = 0 To dtCustomer.Rows.Count - 1     '//Iterate through datatable and assign records
                    rCustomer = dtCustomer.Rows(xCount)
                    If Trim(rCustomer("cust_name1")) = cboCustomer.Text Then
                        If Trim(rCustomer("loc_name")) = cboLocation.Text Then
                            cboPurchaseOrder.Items.Insert(aCount, Trim(rCustomer("po_id")))
                        End If
                    End If
                Next

                '//Dispose and close elements
                rCustomer = Nothing
                dtCustomer.Dispose()
                dtCustomer = Nothing

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub ClearCboCustomer()

            '//Clear out cboCustomer control
            cboCustomer.Items.Clear()
            cboCustomer.Text = ""

        End Sub

        Private Sub ClearCboLocation()

            '//Clear out cboLocation control
            cboLocation.Items.Clear()
            cboLocation.Text = ""

        End Sub

        Private Sub ClearCboPurchaseOrder()

            '//Clear out cboPurchaseOrder control
            cboPurchaseOrder.Items.Clear()
            cboPurchaseOrder.Text = ""

        End Sub

        Public Sub ResetCombo()

            '//This method will clear out all combo boxes for the form
            '//and repopulate
            ClearCboCustomer()
            PopulateCustomerList()
            ClearCboLocation()
            PopulateLocationList()
            ClearCboPurchaseOrder()
            PopulatePurchaseOrderList()

        End Sub

        Private Sub PopulatetdbGrid()

            '//This method creates a datatbale and assigns it to the tru dbgrid
            Try
                Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("Select Distinct tcustomer.cust_name1, tlocation.loc_name, tpurchaseorder.po_id, tpurchaseorder.po_desc from tworkorder, tlocation, tpurchaseorder, tcustomer where tworkorder.loc_id=tlocation.loc_id and tworkorder.po_id = tpurchaseorder.po_id and tlocation.cust_id = tcustomer.cust_id Order By tcustomer.cust_name1;")
                tdbGrid.DataSource = dt.DefaultView

                tdbGrid.Columns(0).Caption = "Customer Name"
                tdbGrid.Columns(0).DataWidth = 250
                tdbGrid.Columns(1).Caption = "Location"
                tdbGrid.Columns(1).DataWidth = 250
                tdbGrid.Columns(2).Caption = "Purchase Order"
                tdbGrid.Columns(2).DataWidth = 250
                tdbGrid.Columns(3).Caption = "Description"
                tdbGrid.Columns(2).DataWidth = 750


            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
            End Try

        End Sub

        Private Sub PopulateCustomerList()

            Dim xCount As Integer = 0

            '//This method perform the population of the cboCustomer control.

            Try
                Dim tblCustomer As New PSS.Data.Production.tcustomer()
                Dim dsCustomer As DataSet = tblCustomer.GetDataOrdered
                Dim rCustomer As DataRow

                ClearCboCustomer()

                For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                    rCustomer = dsCustomer.Tables("tcustomer").Rows(xCount)
                    cboCustomer.Items.Insert(xCount, rCustomer("cust_name1"))
                    CustomerID(xCount) = Trim(rCustomer("cust_ID"))
                Next

                cboCustomer.SelectedIndex = 0

                dsCustomer = Nothing
                tblCustomer = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub PopulateLocationList()

            Dim xCount As Integer = 0

            '//This method perform the population of the cboLocation control.

            Try
                Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("Select distinct Loc_Name, Loc_ID, cust_ID from tlocation where Cust_id =" & CustomerID(cboCustomer.SelectedIndex))
                Dim dr As DataRow

                'Populate the location list
                ClearCboLocation()

                For xCount = 0 To dt.Rows.Count - 1
                    dr = dt.Rows(xCount)
                    cboLocation.Items.Insert(xCount, Trim(dr("Loc_Name")))
                    LocationID(xCount) = Trim(dr("loc_ID"))
                Next

                dt.Dispose()
                dr = Nothing
                dt = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

            '//This code causes the location list to be repopulated
            '//once the customer value has changed
            Try
                PopulateLocationList()
                ClearCboPurchaseOrder()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub tdbGrid_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbGrid.RowColChange

            '//This code clears the combo boxes and reloads them with the data from the tru dbgrid.
            '//The combo boxes are reloaded with data that is specific to the customer, location, and purchase order
            ClearCboCustomer()
            ClearCboLocation()
            ClearCboPurchaseOrder()

            Try
                PopulateCustomerList()
                cboCustomer.Text = tdbGrid.Columns(0).Text
                PopulateLocationList()
                cboLocation.Text = tdbGrid.Columns(1).Text
                PopulatePurchaseOrderList()
                cboPurchaseOrder.Text = tdbGrid.Columns(2).Text
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub cboLocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged

            '//This code causes the purchase order combo box to be 
            '//reloaded once the location has changed
            PopulatePurchaseOrderList()

        End Sub

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

            Dim frm As New frmOrderEntry()

            If Len(cboCustomer.SelectedItem) > 0 And Len(cboLocation.SelectedItem) > 0 Then
                frm.LoadNew(CustomerID(cboCustomer.SelectedIndex), LocationID(cboLocation.SelectedIndex))
                frm.ShowDialog()
                PopulatetdbGrid()
                ResetCombo()
            Else
                MsgBox("Please select both a customer and location before performing this function.", MsgBoxStyle.OKOnly, "More data required")
            End If

        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

            Dim frm As New frmOrderEntry()

            If Len(cboPurchaseOrder.SelectedItem) > 0 Then
                frm.LoadDelete(cboPurchaseOrder.SelectedItem)
                frm.ShowDialog()
                PopulatetdbGrid()
                ResetCombo()
            Else
                MsgBox("Please select a purchase order number before performing this function.", MsgBoxStyle.OKOnly, "More data required")
            End If

        End Sub

        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            Dim frm As New frmOrderEntry()

            If Len(cboPurchaseOrder.SelectedItem) > 0 Then

                If cboLocation.SelectedIndex < 0 Then
                    MsgBox("reselect location")
                    Exit Sub
                End If

                frm.LoadUpdate(CustomerID(cboCustomer.SelectedIndex), LocationID(cboLocation.SelectedIndex), cboPurchaseOrder.SelectedItem)
                frm.ShowDialog()
                'PopulatetdbGrid()   'for good measure - elements should not change
                ResetCombo()        'for good measure
            Else
                MsgBox("Please select a purchase order number before performing this function.", MsgBoxStyle.OKOnly, "More data required")
            End If

        End Sub

        Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

            Close()

        End Sub

        Private Sub btnPrintPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPO.Click

            If Len(cboPurchaseOrder.Text) > 0 Then

                Dim strReportLoc As String = PSS.Core.ReportPath

                Try

                    'Dim report As New ReportDocument()
                    'report.Load(strReportLoc & "CustSrvs_PO.rpt", OpenReportMethod.OpenReportByTempCopy)
                    'report.Refresh()
                    'report.RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & Trim(cboPurchaseOrder.Text)
                    'report.PrintToPrinter(1, False, 0, 0)
                    'report = Nothing

                    'Dim rptApp As New CRAXDRT.Application()
                    'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "CustSrvs_PO.rpt")
                    Dim objRpt As ReportDocument

                    objRpt = New ReportDocument()

                    With objRpt
                        .RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & cboPurchaseOrder.Text.Trim
                        .PrintToPrinter(2, True, 0, 0)
                    End With

                    'rpt.RecordSelectionFormula = "{tpurchaseorder.PO_ID} = " & Trim(cboPurchaseOrder.Text)
                    'rpt.PrintOut(False, 2)
                    'rpt = Nothing

                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try

            End If

        End Sub

        Private Sub tdbGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbGrid.Click

        End Sub
    End Class

End Namespace
