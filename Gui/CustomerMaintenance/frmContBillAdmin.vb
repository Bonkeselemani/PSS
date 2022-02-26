Option Explicit On 

Namespace Gui.ContBillAdmin
    Public Class frmContBillAdmin
        Inherits System.Windows.Forms.Form

        Private cCellModelFactor As New PSS.Data.Buisness.CellModelFactor()
        Private ds As PSS.Data.Production.Joins
        Private strSQL As String
        Private intModified As Integer = 0

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
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblHeading As System.Windows.Forms.Label
        Friend WithEvents tvMain As System.Windows.Forms.TreeView
        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents chkContingencies As System.Windows.Forms.CheckedListBox
        Friend WithEvents lblContingencies As System.Windows.Forms.Label
        Friend WithEvents lblSource As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents pnlWork As System.Windows.Forms.Panel
        Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents lboxData As System.Windows.Forms.ListBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lblLboxHeading As System.Windows.Forms.Label
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmContBillAdmin))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.tvMain = New System.Windows.Forms.TreeView()
            Me.lblManufacturer = New System.Windows.Forms.Label()
            Me.cboManufacturer = New System.Windows.Forms.ComboBox()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblHeading = New System.Windows.Forms.Label()
            Me.chkContingencies = New System.Windows.Forms.CheckedListBox()
            Me.lblContingencies = New System.Windows.Forms.Label()
            Me.lblSource = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.pnlWork = New System.Windows.Forms.Panel()
            Me.lblLboxHeading = New System.Windows.Forms.Label()
            Me.lboxData = New System.Windows.Forms.ListBox()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.pnlWork.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Bitmap)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnUpdate, Me.tvMain, Me.lblManufacturer, Me.cboManufacturer, Me.cboCustomer, Me.lblCustomer})
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(288, 416)
            Me.Panel1.TabIndex = 0
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.Location = New System.Drawing.Point(0, 384)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(288, 32)
            Me.btnCancel.TabIndex = 9
            Me.btnCancel.Text = "CANCEL"
            '
            'btnUpdate
            '
            Me.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.Location = New System.Drawing.Point(0, 352)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(288, 32)
            Me.btnUpdate.TabIndex = 8
            Me.btnUpdate.Text = "UPDATE"
            '
            'tvMain
            '
            Me.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.tvMain.ImageIndex = -1
            Me.tvMain.Location = New System.Drawing.Point(8, 104)
            Me.tvMain.Name = "tvMain"
            Me.tvMain.SelectedImageIndex = -1
            Me.tvMain.Size = New System.Drawing.Size(272, 240)
            Me.tvMain.TabIndex = 2
            '
            'lblManufacturer
            '
            Me.lblManufacturer.BackColor = System.Drawing.Color.Transparent
            Me.lblManufacturer.Location = New System.Drawing.Point(8, 56)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(100, 16)
            Me.lblManufacturer.TabIndex = 2
            Me.lblManufacturer.Text = "MANUFACTURER"
            '
            'cboManufacturer
            '
            Me.cboManufacturer.Location = New System.Drawing.Point(8, 72)
            Me.cboManufacturer.Name = "cboManufacturer"
            Me.cboManufacturer.Size = New System.Drawing.Size(184, 21)
            Me.cboManufacturer.TabIndex = 4
            '
            'cboCustomer
            '
            Me.cboCustomer.Location = New System.Drawing.Point(8, 24)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(184, 21)
            Me.cboCustomer.TabIndex = 5
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer.Location = New System.Drawing.Point(8, 8)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(88, 16)
            Me.lblCustomer.TabIndex = 3
            Me.lblCustomer.Text = "CUSTOMER"
            '
            'Panel2
            '
            Me.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Bitmap)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblHeading})
            Me.Panel2.Location = New System.Drawing.Point(288, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(432, 40)
            Me.Panel2.TabIndex = 1
            '
            'lblHeading
            '
            Me.lblHeading.BackColor = System.Drawing.Color.Transparent
            Me.lblHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeading.Location = New System.Drawing.Point(8, 8)
            Me.lblHeading.Name = "lblHeading"
            Me.lblHeading.Size = New System.Drawing.Size(312, 23)
            Me.lblHeading.TabIndex = 0
            Me.lblHeading.Text = "Contingent Billing Administration"
            '
            'chkContingencies
            '
            Me.chkContingencies.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.chkContingencies.Location = New System.Drawing.Point(8, 64)
            Me.chkContingencies.Name = "chkContingencies"
            Me.chkContingencies.Size = New System.Drawing.Size(224, 304)
            Me.chkContingencies.TabIndex = 2
            '
            'lblContingencies
            '
            Me.lblContingencies.BackColor = System.Drawing.Color.Transparent
            Me.lblContingencies.Location = New System.Drawing.Point(8, 8)
            Me.lblContingencies.Name = "lblContingencies"
            Me.lblContingencies.Size = New System.Drawing.Size(104, 16)
            Me.lblContingencies.TabIndex = 6
            Me.lblContingencies.Text = "CONTINGENCIES"
            '
            'lblSource
            '
            Me.lblSource.BackColor = System.Drawing.Color.Transparent
            Me.lblSource.Location = New System.Drawing.Point(8, 40)
            Me.lblSource.Name = "lblSource"
            Me.lblSource.Size = New System.Drawing.Size(440, 16)
            Me.lblSource.TabIndex = 9
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.Transparent
            Me.lblModel.Location = New System.Drawing.Point(8, 24)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(440, 16)
            Me.lblModel.TabIndex = 10
            '
            'pnlWork
            '
            Me.pnlWork.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlWork.BackColor = System.Drawing.Color.Ivory
            Me.pnlWork.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlWork.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLboxHeading, Me.lboxData, Me.lblSource, Me.chkContingencies, Me.lblModel, Me.lblContingencies})
            Me.pnlWork.Location = New System.Drawing.Point(288, 40)
            Me.pnlWork.Name = "pnlWork"
            Me.pnlWork.Size = New System.Drawing.Size(432, 376)
            Me.pnlWork.TabIndex = 11
            '
            'lblLboxHeading
            '
            Me.lblLboxHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLboxHeading.Location = New System.Drawing.Point(240, 64)
            Me.lblLboxHeading.Name = "lblLboxHeading"
            Me.lblLboxHeading.Size = New System.Drawing.Size(176, 16)
            Me.lblLboxHeading.TabIndex = 12
            Me.lblLboxHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lboxData
            '
            Me.lboxData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lboxData.BackColor = System.Drawing.Color.Ivory
            Me.lboxData.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lboxData.Location = New System.Drawing.Point(240, 88)
            Me.lboxData.Name = "lboxData"
            Me.lboxData.Size = New System.Drawing.Size(176, 273)
            Me.lboxData.TabIndex = 11
            '
            'frmContBillAdmin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(720, 421)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlWork, Me.Panel2, Me.Panel1})
            Me.Name = "frmContBillAdmin"
            Me.Text = "frmContBillAdmin"
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.pnlWork.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Data acquisition for controls "

        Private Sub getCustomer()
            Dim dtCustomer As DataTable = cCellModelFactor.getDataTable("SELECT tlocation.loc_id, cust_name1 FROM tcustomer inner join tlocation on tcustomer.cust_id = tlocation.cust_id AND loc_id in ( 442, 2766, 2946, 2062 ) ORDER BY cust_name1")
            cboCustomer.DataSource = dtCustomer
            cboCustomer.DisplayMember = dtCustomer.Columns("Cust_Name1").ToString
            cboCustomer.ValueMember = dtCustomer.Columns("Loc_ID").ToString
        End Sub

        Private Sub getManufacturer()
            Dim dtManuf As DataTable
            Try
                strSQL = "SELECT DISTINCT lmanuf.Manuf_ID, lmanuf.Manuf_Desc " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSQL &= "INNER JOIN lmanuf ON tmodel.Manuf_ID = lmanuf.Manuf_ID " & Environment.NewLine
                strSQL &= "WHERE tdevice.Loc_ID = " & Me.cboCustomer.SelectedValue & " " & Environment.NewLine
                'dtManuf = cCellModelFactor.getDataTable("SELECT DISTINCT lmanuf.manuf_id, manuf_desc FROM lmanuf INNER JOIN tmodel on lmanuf.manuf_id = tmodel.manuf_id WHERE tmodel.prod_id = 2 ORDER BY manuf_desc")
                dtManuf = cCellModelFactor.getDataTable(strSQL)
                cboManufacturer.DataSource = dtManuf
                cboManufacturer.DisplayMember = dtManuf.Columns("Manuf_Desc").ToString
                cboManufacturer.ValueMember = dtManuf.Columns("Manuf_ID").ToString
                strSQL = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Informaiton", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub populateTreeControl()
            tvMain.Nodes.Clear()
            Try
                strSQL = "SELECT lbillcodes.billcode_id, lbillcodes.billcode_desc, tmodel.model_desc, tmodel.model_id, lpsprice.psprice_number, lpsprice.psprice_desc FROM tpsmap " & Environment.NewLine
                strSQL &= "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                strSQL &= "inner join tmodel on tpsmap.model_id = tmodel.model_id " & Environment.NewLine
                strSQL &= "inner join lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSQL &= "WHERE tmodel.manuf_id = " & cboManufacturer.SelectedValue & " " & Environment.NewLine
                'strSQL &= "AND tmodel.Prod_ID = 2 " & Environment.NewLine
                strSQL &= "ORDER BY tmodel.model_desc, lbillcodes.billcode_desc" & Environment.NewLine
            Catch ex As Exception
                strSQL = "SELECT lbillcodes.billcode_id, lbillcodes.billcode_desc, tmodel.model_desc, tmodel.model_id, lpsprice.psprice_number, lpsprice.psprice_desc FROM tpsmap " & Environment.NewLine
                strSQL &= "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                strSQL &= "inner join tmodel on tpsmap.model_id = tmodel.model_id " & Environment.NewLine
                strSQL &= "inner join lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSQL &= "WHERE tmodel.manuf_id = 0 " & Environment.NewLine
                'strSQL &= "AND tmodel.Prod_ID = 2 " & Environment.NewLine
                strSQL &= "ORDER BY tmodel.model_desc, lbillcodes.billcode_desc" & Environment.NewLine
            End Try

            Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
            Dim r As DataRow
            Dim xCount As Integer = 0
            Dim cNode As Integer = 0
            Dim ccNode As Integer = 0
            Dim mModel As Integer = 0

            cNode = 0
            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                If mModel <> r("Model_ID") Then
                    '//Add Model
                    tvMain.Nodes.Add("Model: " & UCase(r("Model_Desc")))
                    tvMain.Nodes.Item(cNode).Tag = r("Model_ID")
                    tvMain.SelectedNode = tvMain.Nodes(cNode)
                    mModel = r("Model_ID")
                    cNode += 1
                    ccNode = 0
                End If
                '//Insert Billcodes
                tvMain.SelectedNode.Nodes.Add(Mid(r("Billcode_Desc"), 1, 40))
                tvMain.SelectedNode.Nodes.Item(ccNode).Tag = r("BillCode_ID")
                ccNode += 1
            Next
            chkContingencies.Items.Clear()
            lboxData.Items.Clear()
            chkContingencies.Visible = False
            lblLboxHeading.Visible = False
            lblModel.Text = ""
            lblModel.BackColor = Color.Transparent
            lblSource.Text = ""
            lblSource.BackColor = Color.Transparent
        End Sub

        Private Sub loadDetailData()
            lboxData.Items.Clear()
            If Mid(Trim(tvMain.SelectedNode.Text), 1, 5) <> "Model" Then
                chkContingencies.Items.Clear()
                strSQL = "SELECT distinct lbillcodes.billcode_desc, tpsmap.billcode_id, lpsprice.psprice_desc FROM tpsmap INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id INNER JOIN lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id WHERE tpsmap.model_id = " & tvMain.SelectedNode.Parent.Tag & " AND tpsmap.billcode_id <> " & tvMain.SelectedNode.Tag & " ORDER BY billcode_desc"

                Dim dtCont As DataTable = ds.OrderEntrySelect(strSQL)
                Dim r As DataRow
                Dim xCount As Integer = 0

                For xCount = 0 To dtCont.Rows.Count - 1
                    r = dtCont.Rows(xCount)
                    chkContingencies.Items.Add(r("Billcode_Desc"))
                Next
                lblSource.Text = "SOURCE: " & tvMain.SelectedNode.Text
                lblSource.BackColor = Color.AliceBlue
                lblSource.Visible = True
                lblModel.Text = tvMain.SelectedNode.Parent.Text
                lblModel.BackColor = Color.AliceBlue
                lblModel.Visible = True
                chkContingencies.Visible = True
                '//Load selections into chkListbox
                strSQL = "SELECT billcode_desc FROM tcontigentbilling INNER JOIN lbillcodes on tcontigentbilling.cbill_contBillCode = lbillcodes.billcode_id INNER JOIN tpsmap on (tcontigentbilling.cbill_model_id = tpsmap.model_id and tcontigentbilling.cbill_contbillcode = tpsmap.billcode_id) INNER JOIN lpsprice on tpsmap.psprice_id = lpsprice.psprice_id WHERE Cbill_Loc_ID = " & cboCustomer.SelectedValue & " AND cbill_model_id = " & tvMain.SelectedNode.Parent.Tag & " AND cbill_billcode_id =  " & tvMain.SelectedNode.Tag
                Dim dtSelected As DataTable = ds.OrderEntrySelect(strSQL)
                Dim zCount As Integer = 0

                lboxData.Items.Clear()
                lblLboxHeading.Text = "CURRENT BILLCODES"
                lblLboxHeading.Visible = True
                For xCount = 0 To chkContingencies.Items.Count - 1
                    For zCount = 0 To dtSelected.Rows.Count - 1
                        r = dtSelected.Rows(zCount)
                        If r("Billcode_Desc") = chkContingencies.Items(xCount) Then
                            chkContingencies.SetItemChecked(xCount, True)
                            lboxData.Items.Add(chkContingencies.Items(xCount))
                            Exit For
                        End If
                    Next
                Next
            Else
                lboxData.Items.Clear()
                chkContingencies.Items.Clear()
                chkContingencies.Visible = False
                lblSource.Visible = False
                lblModel.Visible = False
                lblContingencies.Visible = False
                lblLboxHeading.Visible = False
            End If
        End Sub

#End Region

#Region "Database Functions"

        Private Sub UpdateData()

            Dim xCount As Integer = 0
            Dim dtUpdate As DataTable
            Dim dtStatus As DataTable
            Dim dtBillcode As DataTable
            Dim rBillcode As DataRow
            Dim blnInsert As Boolean

            '//Read all entries for said model
            For xCount = 0 To chkContingencies.Items.Count - 1
                If chkContingencies.CheckedItems.Contains(chkContingencies.Items(xCount)) = True Then
                    '//Make certain item is in table
                    '//Get Contingent Billcode ID
                    strSQL = "SELECT tpsmap.billcode_id FROM tpsmap INNER JOIN lbillcodes ON tpsmap.billcode_id = lbillcodes.billcode_id WHERE tpsmap.model_ID = " & tvMain.SelectedNode.Parent.Tag & " AND lbillcodes.billcode_desc = '" & chkContingencies.Items(xCount) & "'"
                    dtBillcode = ds.OrderEntrySelect(strSQL)
                    rBillcode = dtBillcode.Rows(0)
                    System.Windows.Forms.Application.DoEvents()
                    '//See if value is in table
                    strSQL = "SELECT * FROM tcontigentbilling WHERE cbill_loc_id = " & cboCustomer.SelectedValue & " AND cbill_model_id = " & tvMain.SelectedNode.Parent.Tag & " AND cbill_Billcode_id = " & tvMain.SelectedNode.Tag & " AND cbill_contBillCode = " & rBillcode("BillCode_ID")
                    dtStatus = ds.OrderEntrySelect(strSQL)
                    If dtStatus.Rows.Count = 1 Then
                        '//Device is listed
                    Else
                        'add record
                        strSQL = "INSERT INTO tcontigentbilling (cbill_loc_ID, cbill_Model_ID, cbill_BillCode_ID, cbill_contBillCode) VALUES (" & cboCustomer.SelectedValue & ", " & tvMain.SelectedNode.Parent.Tag & ", " & tvMain.SelectedNode.Tag & ", " & rBillcode("BillCode_ID") & ")"
                        blnInsert = ds.OrderEntryUpdateDelete(strSQL)
                    End If
                Else
                    '//Make certain item is removed from table
                    '//Get Contingent Billcode ID
                    strSQL = "SELECT tpsmap.billcode_id FROM tpsmap INNER JOIN lbillcodes ON tpsmap.billcode_id = lbillcodes.billcode_id WHERE tpsmap.model_ID = " & tvMain.SelectedNode.Parent.Tag & " AND lbillcodes.billcode_desc = '" & chkContingencies.Items(xCount) & "'"
                    dtBillcode = ds.OrderEntrySelect(strSQL)
                    rBillcode = dtBillcode.Rows(0)
                    System.Windows.Forms.Application.DoEvents()
                    '//See if value is in table
                    strSQL = "SELECT * FROM tcontigentbilling WHERE cbill_loc_id = " & cboCustomer.SelectedValue & " AND cbill_model_id = " & tvMain.SelectedNode.Parent.Tag & " AND cbill_Billcode_id = " & tvMain.SelectedNode.Tag & " AND cbill_contBillCode = " & rBillcode("BillCode_ID")
                    dtStatus = ds.OrderEntrySelect(strSQL)
                    If dtStatus.Rows.Count = 1 Then
                        '//Remove Device
                        strSQL = "DELETE FROM tcontigentbilling WHERE cbill_loc_ID = " & cboCustomer.SelectedValue & " AND cbill_Model_ID = " & tvMain.SelectedNode.Parent.Tag & " AND cbill_BillCode_ID = " & tvMain.SelectedNode.Tag & " AND cbill_contBillCode = " & rBillcode("BillCode_ID")
                        blnInsert = ds.OrderEntryUpdateDelete(strSQL)
                    Else
                        'Device is not in table
                    End If
                End If
            Next
            '//Clear data from variables
            chkContingencies.Items.Clear()
            lboxData.Items.Clear()
            '//Hide components not in use
            chkContingencies.Visible = False
            lblLboxHeading.Visible = False
            lblModel.Text = ""
            lblModel.BackColor = Color.Transparent
            lblSource.Text = ""
            lblSource.BackColor = Color.Transparent
            tvMain.SelectedNode.Collapse()
            tvMain.Select()
        End Sub

        Private Sub CancelData()
            '//Clear data from variables
            chkContingencies.Items.Clear()
            lboxData.Items.Clear()
            '//Hide components not in use
            chkContingencies.Visible = False
            lblLboxHeading.Visible = False
            lblModel.Text = ""
            lblModel.BackColor = Color.Transparent
            lblSource.Text = ""
            lblSource.BackColor = Color.Transparent
            loadDetailData()
            tvMain.Select()
            cboCustomer.Enabled = True
            cboManufacturer.Enabled = True
        End Sub

#End Region

#Region "Reset and Reload Form Controls"

        Private Sub resetFormControls()
            chkContingencies.Visible = False
            lblSource.Visible = False
            lblModel.Visible = False
            lblContingencies.Visible = False
            System.Windows.Forms.Application.DoEvents()
            populateTreeControl()
        End Sub

#End Region

#Region "Form Events"

        Private Sub frmContBillAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            tvMain.ForeColor = Color.White
            getCustomer()
            cboCustomer.Text = ""
            tvMain.ForeColor = Color.Black

            chkContingencies.Visible = False
            lblSource.Visible = False
            lblModel.Visible = False
            lblContingencies.Visible = False
            System.Windows.Forms.Application.DoEvents()
        End Sub

#End Region

#Region "Control Events"
        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted
            Me.getManufacturer()
        End Sub

        Private Sub cboManufacturer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectedValueChanged
            lblLboxHeading.Visible = False
            Me.populateTreeControl()
        End Sub

        Private Sub chkContingencies_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkContingencies.ItemCheck
            Dim lbxCount As Integer = 0
            Try
                If chkContingencies.CheckedItems.Contains(chkContingencies.SelectedItem) = False Then
                    '//ADD ELEMENT
                    lboxData.Items.Add(chkContingencies.SelectedItem)
                    lboxData.Sorted = True
                    intModified = 1
                Else
                    '//REMOVE ELEMENT
                    For lbxCount = 0 To lboxData.Items.Count - 1
                        If lboxData.Items(lbxCount) = chkContingencies.SelectedItem Then
                            lboxData.Items.RemoveAt(lbxCount)
                            intModified = 1
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub tvMain_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvMain.BeforeSelect
            If intModified = 1 Then
                Dim strResponse As String = MsgBox("Do you want to save the data for this part?", MsgBoxStyle.YesNo, "Save Data")
                Select Case strResponse
                    Case vbYes
                        UpdateData()
                        intModified = 0
                    Case vbNo
                        CancelData()
                        intModified = 0
                End Select
            End If
        End Sub

        Private Sub tvMain_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMain.AfterSelect
            loadDetailData()
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            UpdateData()
            intModified = 0
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            CancelData()
            intModified = 0
        End Sub

        Private Sub cboCustomer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.Enter
            If intModified = 1 Then
                MsgBox("Please do not change customers until you have saved or cancelled your current changes.", MsgBoxStyle.Information)
                chkContingencies.Focus()
            End If
        End Sub

        Private Sub cboManufacturer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.Enter
            If intModified = 1 Then
                MsgBox("Please do not change manufacturers until you have saved or cancelled your current changes.", MsgBoxStyle.Information)
                chkContingencies.Focus()
            End If
        End Sub

#End Region


    End Class
End Namespace
