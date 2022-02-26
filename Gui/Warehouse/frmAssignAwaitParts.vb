
Namespace warehouse


    Public Class frmAssignAwaitParts
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
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents cboModel As System.Windows.Forms.ComboBox
        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
        Friend WithEvents lblCurrent As System.Windows.Forms.Label
        Friend WithEvents lblCurrentCount As System.Windows.Forms.Label
        Friend WithEvents lblNewCount As System.Windows.Forms.Label
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents lblList As System.Windows.Forms.Label
        Friend WithEvents lstInventory As System.Windows.Forms.ListBox
        Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
        Friend WithEvents txtNewCount As System.Windows.Forms.TextBox
        Friend WithEvents lblwarehouse As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.cboModel = New System.Windows.Forms.ComboBox()
            Me.cboManufacturer = New System.Windows.Forms.ComboBox()
            Me.lblManufacturer = New System.Windows.Forms.Label()
            Me.lblCurrent = New System.Windows.Forms.Label()
            Me.lblCurrentCount = New System.Windows.Forms.Label()
            Me.lblNewCount = New System.Windows.Forms.Label()
            Me.txtNewCount = New System.Windows.Forms.TextBox()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.lblList = New System.Windows.Forms.Label()
            Me.lstInventory = New System.Windows.Forms.ListBox()
            Me.lblwarehouse = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(32, 13)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.Location = New System.Drawing.Point(96, 8)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(160, 21)
            Me.cboCustomer.TabIndex = 1
            '
            'lblModel
            '
            Me.lblModel.Location = New System.Drawing.Point(32, 77)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(56, 16)
            Me.lblModel.TabIndex = 2
            Me.lblModel.Text = "Model:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModel
            '
            Me.cboModel.Location = New System.Drawing.Point(96, 72)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(160, 21)
            Me.cboModel.TabIndex = 3
            '
            'cboManufacturer
            '
            Me.cboManufacturer.Location = New System.Drawing.Point(96, 48)
            Me.cboManufacturer.Name = "cboManufacturer"
            Me.cboManufacturer.Size = New System.Drawing.Size(160, 21)
            Me.cboManufacturer.TabIndex = 5
            '
            'lblManufacturer
            '
            Me.lblManufacturer.Location = New System.Drawing.Point(8, 53)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(80, 16)
            Me.lblManufacturer.TabIndex = 4
            Me.lblManufacturer.Text = "Manufacturer:"
            Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrent
            '
            Me.lblCurrent.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.lblCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrent.Location = New System.Drawing.Point(8, 176)
            Me.lblCurrent.Name = "lblCurrent"
            Me.lblCurrent.Size = New System.Drawing.Size(168, 32)
            Me.lblCurrent.TabIndex = 6
            Me.lblCurrent.Text = "CURRENT COUNT AWAITING PARTS"
            Me.lblCurrent.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblCurrentCount
            '
            Me.lblCurrentCount.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.lblCurrentCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrentCount.Location = New System.Drawing.Point(184, 176)
            Me.lblCurrentCount.Name = "lblCurrentCount"
            Me.lblCurrentCount.Size = New System.Drawing.Size(64, 32)
            Me.lblCurrentCount.TabIndex = 7
            Me.lblCurrentCount.Text = "0"
            Me.lblCurrentCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblNewCount
            '
            Me.lblNewCount.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.lblNewCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNewCount.Location = New System.Drawing.Point(24, 224)
            Me.lblNewCount.Name = "lblNewCount"
            Me.lblNewCount.Size = New System.Drawing.Size(152, 32)
            Me.lblNewCount.TabIndex = 8
            Me.lblNewCount.Text = "NEW COUNT"
            Me.lblNewCount.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtNewCount
            '
            Me.txtNewCount.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.txtNewCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtNewCount.Location = New System.Drawing.Point(184, 216)
            Me.txtNewCount.Name = "txtNewCount"
            Me.txtNewCount.Size = New System.Drawing.Size(64, 38)
            Me.txtNewCount.TabIndex = 9
            Me.txtNewCount.Text = "0"
            Me.txtNewCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnUpdate
            '
            Me.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnUpdate.Location = New System.Drawing.Point(16, 272)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(232, 40)
            Me.btnUpdate.TabIndex = 10
            Me.btnUpdate.Text = "UPDATE VALUE"
            '
            'lblList
            '
            Me.lblList.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblList.Location = New System.Drawing.Point(296, 64)
            Me.lblList.Name = "lblList"
            Me.lblList.Size = New System.Drawing.Size(280, 24)
            Me.lblList.TabIndex = 11
            Me.lblList.Text = "Current Awaiting Parts Warehouse Inventory"
            Me.lblList.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lstInventory
            '
            Me.lstInventory.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lstInventory.Location = New System.Drawing.Point(296, 88)
            Me.lstInventory.Name = "lstInventory"
            Me.lstInventory.Size = New System.Drawing.Size(280, 225)
            Me.lstInventory.TabIndex = 12
            '
            'lblwarehouse
            '
            Me.lblwarehouse.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.lblwarehouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblwarehouse.Location = New System.Drawing.Point(32, 120)
            Me.lblwarehouse.Name = "lblwarehouse"
            Me.lblwarehouse.Size = New System.Drawing.Size(216, 23)
            Me.lblwarehouse.TabIndex = 13
            Me.lblwarehouse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmAssignAwaitParts
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(624, 341)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblwarehouse, Me.lstInventory, Me.lblList, Me.btnUpdate, Me.txtNewCount, Me.lblNewCount, Me.lblCurrentCount, Me.lblCurrent, Me.cboManufacturer, Me.lblManufacturer, Me.cboModel, Me.lblModel, Me.cboCustomer, Me.lblCustomer})
            Me.Name = "frmAssignAwaitParts"
            Me.Text = "Warehouse Assign Awaiting Parts"
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private ds As PSS.Data.Production.Joins
        Dim dt As DataTable
        Dim r As DataRow
        Dim strSQL As String
        Dim xCount As Integer = 0
        Dim iInWarehouse As Long = 0
        Dim blnUpdate As Boolean


        Private Sub frmAssignAwaitParts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            getCustomerList()
            getManufacturerList()
            getModelList()

            cboCustomer.Text = ""

            'makeList()
        End Sub

        Private Sub getCustomerList()
            strSQL = "SELECT Cust_ID, Cust_Name1 FROM tcustomer WHERE Cust_id = 2113 ORDER BY Cust_Name1"
            dt = ds.OrderEntrySelect(strSQL)
            dt.Rows.InsertAt(dt.NewRow(), 0)
            cboCustomer.DataSource = dt
            cboCustomer.DisplayMember = dt.Columns("Cust_Name1").ToString
            cboCustomer.ValueMember = dt.Columns("Cust_ID").ToString
        End Sub

        Private Sub getManufacturerList()
            strSQL = "SELECT Manuf_ID, Manuf_Desc FROM lmanuf ORDER BY Manuf_Desc"
            dt = ds.OrderEntrySelect(strSQL)
            cboManufacturer.DataSource = dt
            cboManufacturer.DisplayMember = dt.Columns("Manuf_Desc").ToString
            cboManufacturer.ValueMember = dt.Columns("Manuf_ID").ToString
        End Sub

        Private Sub getModelList()
            strSQL = "SELECT Model_ID, Model_Desc FROM tmodel WHERE Manuf_ID = " & cboManufacturer.SelectedValue & " ORDER BY Model_Desc"
            dt = ds.OrderEntrySelect(strSQL)
            cboModel.DataSource = dt
            cboModel.DisplayMember = dt.Columns("Model_Desc").ToString
            cboModel.ValueMember = dt.Columns("Model_ID").ToString
        End Sub


        Private Sub getModelDetail()
            If Len(Trim(cboModel.ValueMember.ToString)) > 0 Then
                If Len(Trim(cboCustomer.ValueMember.ToString)) > 0 Then

                    strSQL = "select model_id, whp_rcvdflag, count(whp_rcvdflag) as vCount from twarehousepallet " & _
                    "inner join twarehousepalletload on twarehousepallet.whpallet_ID = twarehousepalletload.whpallet_id " & _
                    "where(cust_id = " & cboCustomer.SelectedValue.ToString & ") " & _
                    "and twarehousepalletload.whp_rcvdflag in (8,13) " & _
                    "and model_id = " & cboModel.SelectedValue.ToString & " " & _
                    "group by model_id, whp_rcvdflag"
                    dt = ds.OrderEntrySelect(strSQL)

                    For xCount = 0 To dt.Rows.Count - 1
                        r = dt.Rows(xCount)
                        If r("whp_rcvdflag") = 8 Then
                            '//Count in warehouse
                            iInWarehouse = r("vCount")
                            lblwarehouse.Text = "WAREHOUSE: " & iInWarehouse
                        ElseIf r("whp_rcvdflag") = 13 Then
                            '//Currently awaiting parts
                            Me.lblCurrentCount.Text = r("vCount")
                        End If
                    Next
                End If
            End If
        End Sub

        Private Sub cboManufacturer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectionChangeCommitted
            getModelList()
        End Sub

        Private Sub cboModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectionChangeCommitted
            lblCurrentCount.Text = 0
            txtNewCount.Text = 0
            getModelDetail()
            makeList()
            If iInWarehouse > 0 Then
                txtNewCount.Focus()
            Else
                cboModel.Focus()
            End If
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            Dim iDifference As Integer = 0

            '//Determine is the process is to add or remove records from awaiting parts
            If CLng(txtNewCount.Text) > CLng(lblCurrentCount.Text) Then
                '//Add Records
                iDifference = CLng(txtNewCount.Text) - CLng(lblCurrentCount.Text)

                '// Verify that there is enough records to perform this action
                If iDifference > iInWarehouse Then
                    '//Not enough devices to perform action
                Else
                    '//Add the records
                    strSQL = "select whp_id, whp_rcvdflag from twarehousepallet " & _
                    "inner join twarehousepalletload on twarehousepallet.whpallet_ID = twarehousepalletload.whpallet_id " & _
                    "where(cust_id = " & cboCustomer.SelectedValue.ToString & ") " & _
                    "and twarehousepalletload.whp_rcvdflag = 8 and model_id = " & cboModel.SelectedValue.ToString & " " & _
                    "order by whp_id desc"
                    dt = ds.OrderEntrySelect(strSQL)

                    For xCount = 0 To iDifference - 1
                        r = dt.Rows(xCount)
                        If r("whp_id") > 0 Then
                            blnUpdate = ds.OrderEntryUpdateDelete("UPDATE twarehousepalletload SET whp_rcvdflag = 13 WHERE whp_id = " & r("whp_id"))
                        End If
                    Next
                End If
            ElseIf CLng(txtNewCount.Text) < CLng(lblCurrentCount.Text) Then
                '//Remove Records
                iDifference = CLng(lblCurrentCount.Text) - CLng(txtNewCount.Text)

                '// Verify that there is enough records to perform this action
                If iDifference < 0 Then
                    '//Not enough devices to perform action
                Else
                    '//Remove the records
                    strSQL = "select whp_id, whp_rcvdflag from twarehousepallet " & _
                    "inner join twarehousepalletload on twarehousepallet.whpallet_ID = twarehousepalletload.whpallet_id " & _
                    "where(cust_id = " & cboCustomer.SelectedValue.ToString & ") " & _
                    "and twarehousepalletload.whp_rcvdflag = 13 and model_id = " & cboModel.SelectedValue.ToString & " " & _
                    "order by whp_id"
                    dt = ds.OrderEntrySelect(strSQL)

                    For xCount = 0 To iDifference - 1
                        r = dt.Rows(xCount)
                        If r("whp_id") > 0 Then
                            blnUpdate = ds.OrderEntryUpdateDelete("UPDATE twarehousepalletload SET whp_rcvdflag = 8 WHERE whp_id = " & r("whp_id"))
                        End If
                    Next

                End If
            Else
                '//No Change 
            End If

            lblwarehouse.Text = ""
            lblCurrentCount.Text = 0
            txtNewCount.Text = 0
            cboModel.Focus()
            makeList()

        End Sub


        Private Sub makeList()

            If Len(Trim(cboCustomer.SelectedValue.ToString)) > 0 Then

                Try
                    lstInventory.Items.Clear()

                    strSQL = "select tmodel.model_id, lmanuf.manuf_desc, tmodel.model_desc, whp_rcvdflag, count(whp_rcvdflag) as vCount from twarehousepallet " & _
                    "inner join twarehousepalletload on twarehousepallet.whpallet_ID = twarehousepalletload.whpallet_id " & _
                    "inner join tmodel on twarehousepallet.model_id = tmodel.model_id " & _
                    "inner join lmanuf on tmodel.manuf_id = lmanuf.manuf_id " & _
                    "where(cust_id = 2113) " & _
                    "and twarehousepalletload.whp_rcvdflag in (13) " & _
                    "group by model_id, whp_rcvdflag"
                    dt = ds.OrderEntrySelect(strSQL)

                    Dim strLine As String

                    For xCount = 0 To dt.Rows.Count - 1
                        r = dt.Rows(xCount)
                        strLine = r("vCount").ToString.PadLeft(4, "0") & "    " & r("Manuf_Desc") & "  " & r("Model_Desc")
                        lstInventory.Items.Add(strLine)
                    Next
                Catch ex As Exception
                End Try
            End If
        End Sub

        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted
            makeList()
        End Sub

    End Class


End Namespace

