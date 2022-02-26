Public Class ucRMASpecific
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents lblShipTo As System.Windows.Forms.Label
    Friend WithEvents txtRAQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents txtPRL As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrder As System.Windows.Forms.TextBox
    Friend WithEvents lblWorkOrder As System.Windows.Forms.Label
    Friend WithEvents lblAirtimeCarrierCode As System.Windows.Forms.Label
    Friend WithEvents lblSKU As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lblManufacturer As System.Windows.Forms.Label
    Friend WithEvents txtSKU As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkOrderMemo As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    Friend WithEvents lblRMAMemo As System.Windows.Forms.Label
    Friend WithEvents lblSUG As System.Windows.Forms.Label
    Friend WithEvents txtSUG As System.Windows.Forms.TextBox
    Friend WithEvents lblWrty As System.Windows.Forms.Label
    Friend WithEvents cboAirCarrCode As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboShipTo As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManufID As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboModID As PSS.Gui.Controls.ComboBox
    Friend WithEvents txtWrty As System.Windows.Forms.TextBox
    Friend WithEvents txtReturn As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadRMA As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ucRMASpecific))
        Me.lblShipTo = New System.Windows.Forms.Label()
        Me.txtRAQty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.txtPRL = New System.Windows.Forms.TextBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWorkOrder = New System.Windows.Forms.TextBox()
        Me.lblWorkOrder = New System.Windows.Forms.Label()
        Me.lblAirtimeCarrierCode = New System.Windows.Forms.Label()
        Me.lblSKU = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.txtSKU = New System.Windows.Forms.TextBox()
        Me.txtWorkOrderMemo = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblRMAMemo = New System.Windows.Forms.Label()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.lblSUG = New System.Windows.Forms.Label()
        Me.txtSUG = New System.Windows.Forms.TextBox()
        Me.lblWrty = New System.Windows.Forms.Label()
        Me.cboAirCarrCode = New PSS.Gui.Controls.ComboBox()
        Me.cboShipTo = New PSS.Gui.Controls.ComboBox()
        Me.cboManufID = New PSS.Gui.Controls.ComboBox()
        Me.cboModID = New PSS.Gui.Controls.ComboBox()
        Me.txtWrty = New System.Windows.Forms.TextBox()
        Me.txtReturn = New System.Windows.Forms.TextBox()
        Me.btnLoadRMA = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblShipTo
        '
        Me.lblShipTo.Location = New System.Drawing.Point(32, 72)
        Me.lblShipTo.Name = "lblShipTo"
        Me.lblShipTo.Size = New System.Drawing.Size(64, 18)
        Me.lblShipTo.TabIndex = 0
        Me.lblShipTo.Text = "Ship To:"
        Me.lblShipTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRAQty
        '
        Me.txtRAQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRAQty.Location = New System.Drawing.Point(104, 208)
        Me.txtRAQty.Name = "txtRAQty"
        Me.txtRAQty.Size = New System.Drawing.Size(128, 20)
        Me.txtRAQty.TabIndex = 7
        Me.txtRAQty.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(32, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "RA QTY:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIP
        '
        Me.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIP.Location = New System.Drawing.Point(104, 184)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(128, 20)
        Me.txtIP.TabIndex = 6
        Me.txtIP.Text = ""
        '
        'txtPRL
        '
        Me.txtPRL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPRL.Location = New System.Drawing.Point(104, 160)
        Me.txtPRL.Name = "txtPRL"
        Me.txtPRL.Size = New System.Drawing.Size(128, 20)
        Me.txtPRL.TabIndex = 5
        Me.txtPRL.Text = ""
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.Location = New System.Drawing.Point(104, 136)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(128, 20)
        Me.txtQuantity.TabIndex = 4
        Me.txtQuantity.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(32, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "IP:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(32, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "PRL:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(32, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "QTY:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrder
        '
        Me.txtWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkOrder.Location = New System.Drawing.Point(104, 112)
        Me.txtWorkOrder.Name = "txtWorkOrder"
        Me.txtWorkOrder.Size = New System.Drawing.Size(128, 20)
        Me.txtWorkOrder.TabIndex = 3
        Me.txtWorkOrder.Text = ""
        '
        'lblWorkOrder
        '
        Me.lblWorkOrder.Location = New System.Drawing.Point(32, 112)
        Me.lblWorkOrder.Name = "lblWorkOrder"
        Me.lblWorkOrder.Size = New System.Drawing.Size(64, 16)
        Me.lblWorkOrder.TabIndex = 0
        Me.lblWorkOrder.Text = "Cust Ref #:"
        Me.lblWorkOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAirtimeCarrierCode
        '
        Me.lblAirtimeCarrierCode.Location = New System.Drawing.Point(32, 48)
        Me.lblAirtimeCarrierCode.Name = "lblAirtimeCarrierCode"
        Me.lblAirtimeCarrierCode.Size = New System.Drawing.Size(64, 18)
        Me.lblAirtimeCarrierCode.TabIndex = 0
        Me.lblAirtimeCarrierCode.Text = "Carrier:"
        Me.lblAirtimeCarrierCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSKU
        '
        Me.lblSKU.Location = New System.Drawing.Point(32, 232)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(64, 16)
        Me.lblSKU.TabIndex = 0
        Me.lblSKU.Text = "SKU:"
        Me.lblSKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(16, 368)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(80, 16)
        Me.lblModel.TabIndex = 0
        Me.lblModel.Text = "Model:"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblManufacturer
        '
        Me.lblManufacturer.Location = New System.Drawing.Point(16, 344)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(80, 16)
        Me.lblManufacturer.TabIndex = 0
        Me.lblManufacturer.Text = "Manufacturer:"
        Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSKU
        '
        Me.txtSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSKU.Location = New System.Drawing.Point(104, 232)
        Me.txtSKU.Name = "txtSKU"
        Me.txtSKU.Size = New System.Drawing.Size(128, 20)
        Me.txtSKU.TabIndex = 8
        Me.txtSKU.Text = ""
        '
        'txtWorkOrderMemo
        '
        Me.txtWorkOrderMemo.BackColor = System.Drawing.SystemColors.Window
        Me.txtWorkOrderMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkOrderMemo.Location = New System.Drawing.Point(144, 400)
        Me.txtWorkOrderMemo.Name = "txtWorkOrderMemo"
        Me.txtWorkOrderMemo.Size = New System.Drawing.Size(360, 20)
        Me.txtWorkOrderMemo.TabIndex = 13
        Me.txtWorkOrderMemo.Text = "Repair"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(120, 400)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 59
        Me.PictureBox1.TabStop = False
        '
        'lblRMAMemo
        '
        Me.lblRMAMemo.Location = New System.Drawing.Point(8, 400)
        Me.lblRMAMemo.Name = "lblRMAMemo"
        Me.lblRMAMemo.Size = New System.Drawing.Size(104, 16)
        Me.lblRMAMemo.TabIndex = 0
        Me.lblRMAMemo.Text = "RMA Memo:"
        Me.lblRMAMemo.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'lblHeading
        '
        Me.lblHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading.Location = New System.Drawing.Point(8, 8)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(312, 23)
        Me.lblHeading.TabIndex = 14
        Me.lblHeading.Text = "RMA INFORMATION"
        '
        'lblSUG
        '
        Me.lblSUG.Location = New System.Drawing.Point(32, 296)
        Me.lblSUG.Name = "lblSUG"
        Me.lblSUG.Size = New System.Drawing.Size(64, 16)
        Me.lblSUG.TabIndex = 0
        Me.lblSUG.Text = "SUG:"
        Me.lblSUG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSUG
        '
        Me.txtSUG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSUG.Location = New System.Drawing.Point(104, 296)
        Me.txtSUG.Name = "txtSUG"
        Me.txtSUG.Size = New System.Drawing.Size(128, 20)
        Me.txtSUG.TabIndex = 10
        Me.txtSUG.Text = ""
        '
        'lblWrty
        '
        Me.lblWrty.Location = New System.Drawing.Point(32, 256)
        Me.lblWrty.Name = "lblWrty"
        Me.lblWrty.Size = New System.Drawing.Size(64, 16)
        Me.lblWrty.TabIndex = 60
        Me.lblWrty.Text = "WRTY:"
        Me.lblWrty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboAirCarrCode
        '
        Me.cboAirCarrCode.AutoComplete = True
        Me.cboAirCarrCode.Location = New System.Drawing.Point(104, 48)
        Me.cboAirCarrCode.Name = "cboAirCarrCode"
        Me.cboAirCarrCode.Size = New System.Drawing.Size(128, 21)
        Me.cboAirCarrCode.TabIndex = 1
        '
        'cboShipTo
        '
        Me.cboShipTo.AutoComplete = True
        Me.cboShipTo.Location = New System.Drawing.Point(104, 72)
        Me.cboShipTo.Name = "cboShipTo"
        Me.cboShipTo.Size = New System.Drawing.Size(128, 21)
        Me.cboShipTo.TabIndex = 2
        '
        'cboManufID
        '
        Me.cboManufID.AutoComplete = True
        Me.cboManufID.Location = New System.Drawing.Point(104, 336)
        Me.cboManufID.Name = "cboManufID"
        Me.cboManufID.Size = New System.Drawing.Size(200, 21)
        Me.cboManufID.TabIndex = 11
        '
        'cboModID
        '
        Me.cboModID.AutoComplete = True
        Me.cboModID.Location = New System.Drawing.Point(104, 360)
        Me.cboModID.Name = "cboModID"
        Me.cboModID.Size = New System.Drawing.Size(200, 21)
        Me.cboModID.TabIndex = 12
        '
        'txtWrty
        '
        Me.txtWrty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWrty.Location = New System.Drawing.Point(104, 256)
        Me.txtWrty.Name = "txtWrty"
        Me.txtWrty.Size = New System.Drawing.Size(128, 20)
        Me.txtWrty.TabIndex = 9
        Me.txtWrty.Text = ""
        '
        'txtReturn
        '
        Me.txtReturn.BackColor = System.Drawing.SystemColors.Control
        Me.txtReturn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReturn.Location = New System.Drawing.Point(464, 432)
        Me.txtReturn.Name = "txtReturn"
        Me.txtReturn.Size = New System.Drawing.Size(32, 13)
        Me.txtReturn.TabIndex = 14
        Me.txtReturn.Text = ""
        '
        'btnLoadRMA
        '
        Me.btnLoadRMA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadRMA.Location = New System.Drawing.Point(360, 8)
        Me.btnLoadRMA.Name = "btnLoadRMA"
        Me.btnLoadRMA.Size = New System.Drawing.Size(144, 23)
        Me.btnLoadRMA.TabIndex = 0
        Me.btnLoadRMA.TabStop = False
        Me.btnLoadRMA.Text = "Load RMA"
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(360, 40)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(144, 23)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "&Close"
        '
        'ucRMASpecific
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.btnLoadRMA, Me.txtReturn, Me.txtWrty, Me.cboModID, Me.cboManufID, Me.cboShipTo, Me.cboAirCarrCode, Me.lblWrty, Me.lblSUG, Me.txtSUG, Me.lblHeading, Me.txtWorkOrderMemo, Me.PictureBox1, Me.lblRMAMemo, Me.lblSKU, Me.lblModel, Me.lblManufacturer, Me.txtSKU, Me.lblShipTo, Me.txtRAQty, Me.Label7, Me.txtIP, Me.txtPRL, Me.txtQuantity, Me.Label5, Me.Label4, Me.Label2, Me.txtWorkOrder, Me.lblWorkOrder, Me.lblAirtimeCarrierCode})
        Me.Name = "ucRMASpecific"
        Me.Size = New System.Drawing.Size(512, 480)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Dim dtManuf As DataTable
    Dim dtModels As DataTable

    Private Sub ucRMASpecific_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateAirCarrCode()
        PopulateManufacturers()
        cboAirCarrCode.Focus()
    End Sub

    Private Sub PopulateManufacturers()

        Dim tblJoins As New PSS.Data.Production.Joins()
        dtManuf = tblJoins.ManufListByDeviceType(2)

        cboManufID.DataSource = dtManuf
        cboManufID.DisplayMember = dtManuf.Columns("Manuf_Desc").ToString
        cboManufID.ValueMember = dtManuf.Columns("Manuf_Desc").ToString
        cboManufID.SelectedIndex = -1

    End Sub

    Private Sub PopulateModels()

        Dim tblJoins As New PSS.Data.Production.Joins()
        dtModels = tblJoins.ModelListCELLByManufName(cboManufID.Text)

        cboModID.DataSource = dtModels
        cboModID.DisplayMember = dtModels.Columns("Model_Desc").ToString
        cboModID.ValueMember = dtModels.Columns("Model_Desc").ToString

    End Sub

    Private Sub PopulateAirCarrCode()

        Dim tblJoins As New PSS.Data.Production.Joins()
        Dim dtCarrier As DataTable = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='carrier' and lcodesdetail.manuf_id=1 and lcodesdetail.prod_id=2")

        cboAirCarrCode.DataSource = dtCarrier
        cboAirCarrCode.DisplayMember = dtCarrier.Columns("Dcode_LDesc").ToString
        cboAirCarrCode.ValueMember = dtCarrier.Columns("Dcode_ID").ToString

    End Sub

    Private Sub cboManufID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufID.SelectedValueChanged
        PopulateModels()
    End Sub

    Private Sub txtReturn_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReturn.Enter
        Me.Visible = False
    End Sub

    Private Sub cboAirCarrCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAirCarrCode.Leave

        Dim valShipTo As Int32 = 0

        Try
            If Len(Trim(cboAirCarrCode.Text)) > 0 Then
                '/Populate ShipTo list
                Dim dsAir As New PSS.Data.Production.Joins()
                Dim dtAir As DataTable = dsAir.OrderEntrySelect("SELECT * FROM lcodesdetail WHERE dcode_ldesc = '" & cboAirCarrCode.Text & "' AND mcode_id=1")
                If dtAir.Rows.Count > 0 Then
                    Dim drAir As DataRow = dtAir.Rows(0)
                    valShipTo = drAir("dcode_l2desc")
                    If valShipTo > 0 Then
                        cboShipTo.Items.Clear()
                        cboShipTo.Items.Add(Trim(cboAirCarrCode.Text))
                        cboShipTo.Items.Add("Motorola")
                        System.Windows.Forms.Application.DoEvents()
                        cboShipTo.SelectedValue = Trim(cboAirCarrCode.Text)
                        cboShipTo.SelectedIndex = 0
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

        If Len(cboAirCarrCode.Text) < 1 Then
            cboAirCarrCode.Focus()
            Exit Sub
        End If
        'txtWorkOrder.Focus()
        cboShipTo.Focus()

    End Sub

    Private Function validateInt(ByVal mValue As String) As Boolean
        validateInt = False
        Dim tstValue As Integer
        Try
            tstValue = CInt(mValue)
            validateInt = True
        Catch ex As Exception
        End Try
    End Function

    Private Sub txtQuantity_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.Leave
        '//Validate value
        If validateInt(txtQuantity.Text) = False Then
            MsgBox("Quantity must be an integer value. Please corrent and continue.", MsgBoxStyle.OKOnly, "ERROR")
            txtQuantity.Text = ""
            txtQuantity.Focus()
            Exit Sub
        End If
    End Sub


    Private Sub vKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAirCarrCode.KeyDown, cboShipTo.KeyDown, txtWorkOrder.KeyDown, txtQuantity.KeyDown, txtPRL.KeyDown, txtIP.KeyDown, txtRAQty.KeyDown, txtSKU.KeyDown, txtWrty.KeyDown, txtSUG.KeyDown, cboManufID.KeyDown, cboModID.KeyDown, txtWorkOrderMemo.KeyDown
        If e.KeyCode = 13 Then
            gotoNextControl()
        End If
    End Sub

    Private Sub gotoNextControl()

        Dim mControlName As String = ActiveControl.Name.ToString

        If mControlName = "cboAirCarrCode" Then cboShipTo.Focus()
        If mControlName = "cboShipTo" Then txtWorkOrder.Focus()
        If mControlName = "txtWorkorder" Then txtQuantity.Focus()
        If mControlName = "txtQuantity" Then txtPRL.Focus()
        If mControlName = "txtPRL" Then txtIP.Focus()
        If mControlName = "txtIP" Then txtRAQty.Focus()
        If mControlName = "txtRAQty" Then txtSKU.Focus()
        If mControlName = "txtSKU" Then txtWrty.Focus()
        If mControlName = "txtWrty" Then txtSUG.Focus()
        If mControlName = "txtSUG" Then cboManufID.Focus()
        If mControlName = "cboManufID" Then cboModID.Focus()
        If mControlName = "cboModID" Then txtWorkOrderMemo.Focus()
        If mControlName = "txtWorkorderMemo" Then txtReturn.Focus()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        txtReturn.Focus()
    End Sub


End Class
