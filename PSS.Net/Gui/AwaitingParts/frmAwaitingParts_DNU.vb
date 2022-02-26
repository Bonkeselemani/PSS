Public Class frmAwaitingParts1
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
    Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManufacturer As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblManufacturer As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lblDevice As System.Windows.Forms.Label
    Friend WithEvents cboDevice As PSS.Gui.Controls.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cboModel = New PSS.Gui.Controls.ComboBox()
        Me.cboManufacturer = New PSS.Gui.Controls.ComboBox()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblDevice = New System.Windows.Forms.Label()
        Me.cboDevice = New PSS.Gui.Controls.ComboBox()
        Me.SuspendLayout()
        '
        'cboModel
        '
        Me.cboModel.AutoComplete = True
        Me.cboModel.Location = New System.Drawing.Point(320, 32)
        Me.cboModel.Name = "cboModel"
        Me.cboModel.Size = New System.Drawing.Size(168, 21)
        Me.cboModel.TabIndex = 9
        '
        'cboManufacturer
        '
        Me.cboManufacturer.AutoComplete = True
        Me.cboManufacturer.Location = New System.Drawing.Point(320, 8)
        Me.cboManufacturer.Name = "cboManufacturer"
        Me.cboManufacturer.Size = New System.Drawing.Size(168, 21)
        Me.cboManufacturer.TabIndex = 10
        '
        'lblManufacturer
        '
        Me.lblManufacturer.Location = New System.Drawing.Point(216, 8)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(100, 16)
        Me.lblManufacturer.TabIndex = 11
        Me.lblManufacturer.Text = "Manufacturer:"
        Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(216, 32)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(100, 16)
        Me.lblModel.TabIndex = 12
        Me.lblModel.Text = "Model:"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlBill
        '
        Me.pnlBill.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBill.Location = New System.Drawing.Point(16, 64)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(560, 248)
        Me.pnlBill.TabIndex = 13
        '
        'btnClear
        '
        Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnClear.Location = New System.Drawing.Point(504, 8)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "C&lear"
        '
        'lblDevice
        '
        Me.lblDevice.Location = New System.Drawing.Point(16, 8)
        Me.lblDevice.Name = "lblDevice"
        Me.lblDevice.Size = New System.Drawing.Size(48, 16)
        Me.lblDevice.TabIndex = 16
        Me.lblDevice.Text = "Device:"
        Me.lblDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboDevice
        '
        Me.cboDevice.AutoComplete = True
        Me.cboDevice.Location = New System.Drawing.Point(72, 8)
        Me.cboDevice.Name = "cboDevice"
        Me.cboDevice.Size = New System.Drawing.Size(120, 21)
        Me.cboDevice.TabIndex = 15
        '
        'frmAwaitingParts
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(584, 317)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDevice, Me.cboDevice, Me.btnClear, Me.pnlBill, Me.lblModel, Me.lblManufacturer, Me.cboManufacturer, Me.cboModel})
        Me.Name = "frmAwaitingParts"
        Me.Text = "frmAwaitingParts"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAwaitingParts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        populateType()

    End Sub


    Private Sub populateType()
        Dim dtType As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM lproduct ORDER BY prod_desc")
        cboDevice.DataSource = dtType
        cboDevice.DisplayMember = dtType.Columns("prod_desc").ToString
        cboDevice.ValueMember = dtType.Columns("prod_id").ToString
        dtType = Nothing

    End Sub
    Private Sub populateManuf(ByVal mDevice As Integer)

        Dim dtManuf As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT distinct lmanuf.manuf_id, lmanuf.manuf_desc FROM lmanuf inner join tmodel on lmanuf.manuf_id = tmodel.manuf_id WHERE tmodel.prod_id = " & mDevice & " ORDER BY manuf_desc")
        cboManufacturer.DataSource = dtManuf
        cboManufacturer.DisplayMember = dtManuf.Columns("manuf_desc").ToString
        cboManufacturer.ValueMember = dtManuf.Columns("manuf_id").ToString
        dtManuf = Nothing

    End Sub
    Private Sub populateModel(ByVal mDevice As Integer, ByVal mManuf As Integer)

        Dim dtModel As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT Model_id, Model_Desc FROM tmodel WHERE Manuf_id = " & mManuf & " AND prod_id = " & mDevice & " ORDER BY model_desc")
        cboModel.DataSource = dtModel
        cboModel.DisplayMember = dtModel.Columns("model_desc").ToString
        cboModel.ValueMember = dtModel.Columns("model_id").ToString
        dtModel = Nothing

    End Sub

    Private Sub cboDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDevice.SelectedIndexChanged
        Try
            populateManuf(cboDevice.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboManufacturer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectedIndexChanged
        Try
            populateModel(cboDevice.SelectedValue, cboManufacturer.SelectedValue)
        Catch ex As Exception
        End Try

    End Sub

End Class
