Public Class frmAvailForProdRpt
    Inherits System.Windows.Forms.Form
    Private objMisc As PSS.Data.Buisness.Misc
    Private objAvailForProd As PSS.Data.Buisness.clsAvailForProd
    Private objQC As PSS.Data.Buisness.QC

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMisc = New PSS.Data.Buisness.Misc()
        objAvailForProd = New PSS.Data.Buisness.clsAvailForProd()
        objQC = New PSS.Data.Buisness.QC()
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
    Friend WithEvents cmdCreateRpt As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdProdType As PSS.Gui.Controls.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdCreateRpt = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdProdType = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCreateRpt
        '
        Me.cmdCreateRpt.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdCreateRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateRpt.Location = New System.Drawing.Point(392, 96)
        Me.cmdCreateRpt.Name = "cmdCreateRpt"
        Me.cmdCreateRpt.Size = New System.Drawing.Size(128, 48)
        Me.cmdCreateRpt.TabIndex = 0
        Me.cmdCreateRpt.Text = "Create Report"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(31, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Start Work Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(148, 30)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(114, 21)
        Me.dtpStartDate.TabIndex = 97
        Me.dtpStartDate.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(30, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "End Work Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(148, 62)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(114, 21)
        Me.dtpEndDate.TabIndex = 99
        Me.dtpEndDate.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.Location = New System.Drawing.Point(147, 93)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(188, 21)
        Me.cmbCustomer.TabIndex = 101
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(61, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Customer:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdProdType
        '
        Me.cmdProdType.AutoComplete = True
        Me.cmdProdType.BackColor = System.Drawing.SystemColors.Window
        Me.cmdProdType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProdType.ForeColor = System.Drawing.Color.Black
        Me.cmdProdType.Location = New System.Drawing.Point(147, 124)
        Me.cmdProdType.Name = "cmdProdType"
        Me.cmdProdType.Size = New System.Drawing.Size(188, 21)
        Me.cmdProdType.TabIndex = 103
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(44, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Product Type:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmAvailForProdRpt
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(560, 190)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdProdType, Me.Label3, Me.cmbCustomer, Me.Label2, Me.Label1, Me.dtpEndDate, Me.Label4, Me.dtpStartDate, Me.cmdCreateRpt})
        Me.Name = "frmAvailForProdRpt"
        Me.Text = "Available for Production Report"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdCreateRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateRpt.Click
        Dim i As Integer
        Try
            i = objAvailForProd.CreateReport(Format(Me.dtpStartDate.Value, "yyyy-MM-dd"), _
                                            Format(Me.dtpEndDate.Value, "yyyy-MM-dd"), _
                                            me.cmbCustomer.SelectedValue, _
                                            me.cmdProdType.SelectedValue)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        Finally

        End Try
    End Sub

    Private Sub LoadCustomers()
        Dim dtCustomers As New DataTable()
        Try
            dtCustomers = objMisc.GetCustomers
            With Me.cmbCustomer
                .DataSource = dtCustomers.DefaultView
                .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            MsgBox("Error in frmCellShipPallet_Generic.LoadCustomers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtCustomers) Then
                dtCustomers.Dispose()
                dtCustomers = Nothing
            End If
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        objMisc = Nothing
        objAvailForProd = Nothing
        objQC = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub frmAvailForProdRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpStartDate.Value = Now
        Me.dtpEndDate.Value = Now
        LoadCustomers()
        LoadProductTypes()
    End Sub
    Private Sub LoadProductTypes()
        Dim dtProd As New DataTable()
        Try
            dtProd = objQC.LoadProductTypes
            With Me.cmdProdType
                .DataSource = dtProd.DefaultView
                .DisplayMember = dtProd.Columns("prod_desc").ToString
                .ValueMember = dtProd.Columns("prod_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmAvailForProdRpt.LoadProductTypes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtProd)
        End Try
    End Sub
End Class
