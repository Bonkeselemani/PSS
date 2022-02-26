Public Class frmPreload_Select_Cust
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox13 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox14 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox15 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox16 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox17 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox18 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox19 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox20 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox21 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox22 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox23 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.CheckBox13 = New System.Windows.Forms.CheckBox()
        Me.CheckBox14 = New System.Windows.Forms.CheckBox()
        Me.CheckBox15 = New System.Windows.Forms.CheckBox()
        Me.CheckBox16 = New System.Windows.Forms.CheckBox()
        Me.CheckBox17 = New System.Windows.Forms.CheckBox()
        Me.CheckBox18 = New System.Windows.Forms.CheckBox()
        Me.CheckBox19 = New System.Windows.Forms.CheckBox()
        Me.CheckBox20 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox21 = New System.Windows.Forms.CheckBox()
        Me.CheckBox22 = New System.Windows.Forms.CheckBox()
        Me.CheckBox23 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "SELECTED"
        '
        'CheckBox1
        '
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.Location = New System.Drawing.Point(16, 48)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox1.TabIndex = 2
        Me.CheckBox1.Text = "Carrier"
        '
        'CheckBox2
        '
        Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox2.Location = New System.Drawing.Point(16, 72)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox2.TabIndex = 3
        Me.CheckBox2.Text = "Ship To"
        '
        'CheckBox3
        '
        Me.CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox3.Location = New System.Drawing.Point(16, 96)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox3.TabIndex = 4
        Me.CheckBox3.Text = "Quantity"
        '
        'CheckBox4
        '
        Me.CheckBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox4.Location = New System.Drawing.Point(16, 120)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox4.TabIndex = 5
        Me.CheckBox4.Text = "PRL"
        '
        'CheckBox5
        '
        Me.CheckBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox5.Location = New System.Drawing.Point(16, 144)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox5.TabIndex = 6
        Me.CheckBox5.Text = "IP"
        '
        'CheckBox6
        '
        Me.CheckBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox6.Location = New System.Drawing.Point(112, 48)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox6.TabIndex = 7
        Me.CheckBox6.Text = "RA Quantity"
        '
        'CheckBox7
        '
        Me.CheckBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox7.Location = New System.Drawing.Point(112, 72)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox7.TabIndex = 8
        Me.CheckBox7.Text = "SKU"
        '
        'CheckBox8
        '
        Me.CheckBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox8.Location = New System.Drawing.Point(112, 96)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox8.TabIndex = 9
        Me.CheckBox8.Text = "Warranty"
        '
        'CheckBox9
        '
        Me.CheckBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox9.Location = New System.Drawing.Point(112, 120)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox9.TabIndex = 10
        Me.CheckBox9.Text = "SUG"
        '
        'CheckBox10
        '
        Me.CheckBox10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox10.Location = New System.Drawing.Point(112, 144)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(88, 24)
        Me.CheckBox10.TabIndex = 11
        Me.CheckBox10.Text = "Doc Date"
        '
        'CheckBox11
        '
        Me.CheckBox11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox11.Location = New System.Drawing.Point(152, 96)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox11.TabIndex = 21
        Me.CheckBox11.Text = "MIN Number"
        '
        'CheckBox12
        '
        Me.CheckBox12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox12.Location = New System.Drawing.Point(152, 72)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox12.TabIndex = 20
        Me.CheckBox12.Text = "Carrier Model Code"
        '
        'CheckBox13
        '
        Me.CheckBox13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox13.Location = New System.Drawing.Point(152, 48)
        Me.CheckBox13.Name = "CheckBox13"
        Me.CheckBox13.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox13.TabIndex = 19
        Me.CheckBox13.Text = "Transceiver Code"
        '
        'CheckBox14
        '
        Me.CheckBox14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox14.Location = New System.Drawing.Point(16, 192)
        Me.CheckBox14.Name = "CheckBox14"
        Me.CheckBox14.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox14.TabIndex = 18
        Me.CheckBox14.Text = "Transaction Code"
        '
        'CheckBox15
        '
        Me.CheckBox15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox15.Location = New System.Drawing.Point(16, 168)
        Me.CheckBox15.Name = "CheckBox15"
        Me.CheckBox15.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox15.TabIndex = 17
        Me.CheckBox15.Text = "AirTime Carrier Code"
        '
        'CheckBox16
        '
        Me.CheckBox16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox16.Location = New System.Drawing.Point(16, 144)
        Me.CheckBox16.Name = "CheckBox16"
        Me.CheckBox16.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox16.TabIndex = 16
        Me.CheckBox16.Text = "Courier Tracking IN"
        '
        'CheckBox17
        '
        Me.CheckBox17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox17.Location = New System.Drawing.Point(16, 120)
        Me.CheckBox17.Name = "CheckBox17"
        Me.CheckBox17.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox17.TabIndex = 15
        Me.CheckBox17.Text = "Incoming IMEI"
        '
        'CheckBox18
        '
        Me.CheckBox18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox18.Location = New System.Drawing.Point(16, 96)
        Me.CheckBox18.Name = "CheckBox18"
        Me.CheckBox18.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox18.TabIndex = 14
        Me.CheckBox18.Text = "APC Code"
        '
        'CheckBox19
        '
        Me.CheckBox19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox19.Location = New System.Drawing.Point(16, 72)
        Me.CheckBox19.Name = "CheckBox19"
        Me.CheckBox19.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox19.TabIndex = 13
        Me.CheckBox19.Text = "Proof of Purchase"
        '
        'CheckBox20
        '
        Me.CheckBox20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox20.Location = New System.Drawing.Point(16, 48)
        Me.CheckBox20.Name = "CheckBox20"
        Me.CheckBox20.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox20.TabIndex = 12
        Me.CheckBox20.Text = "Date Code"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "SELECTED"
        '
        'CheckBox21
        '
        Me.CheckBox21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox21.Location = New System.Drawing.Point(152, 120)
        Me.CheckBox21.Name = "CheckBox21"
        Me.CheckBox21.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox21.TabIndex = 22
        Me.CheckBox21.Text = "Product Code"
        '
        'CheckBox22
        '
        Me.CheckBox22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox22.Location = New System.Drawing.Point(152, 144)
        Me.CheckBox22.Name = "CheckBox22"
        Me.CheckBox22.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox22.TabIndex = 23
        Me.CheckBox22.Text = "Complaint Code"
        '
        'CheckBox23
        '
        Me.CheckBox23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox23.Location = New System.Drawing.Point(152, 168)
        Me.CheckBox23.Name = "CheckBox23"
        Me.CheckBox23.Size = New System.Drawing.Size(128, 24)
        Me.CheckBox23.TabIndex = 24
        Me.CheckBox23.Text = "Return Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox17, Me.CheckBox16, Me.Label3, Me.CheckBox14, Me.CheckBox20, Me.CheckBox23, Me.CheckBox18, Me.CheckBox11, Me.CheckBox22, Me.CheckBox15, Me.CheckBox12, Me.CheckBox13, Me.CheckBox21, Me.CheckBox19})
        Me.GroupBox1.Location = New System.Drawing.Point(232, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 224)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Device Specific"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox1, Me.CheckBox8, Me.CheckBox4, Me.CheckBox9, Me.CheckBox5, Me.CheckBox10, Me.CheckBox3, Me.CheckBox2, Me.Label11, Me.CheckBox7, Me.CheckBox6})
        Me.GroupBox2.Location = New System.Drawing.Point(16, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(208, 224)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Customer Specific"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer Name:"
        '
        'cboCustomer
        '
        Me.cboCustomer.Location = New System.Drawing.Point(120, 11)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(232, 21)
        Me.cboCustomer.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(16, 280)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(504, 40)
        Me.btnSave.TabIndex = 25
        Me.btnSave.Text = "SAVE"
        '
        'frmPreload_Select_Cust
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 325)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSave, Me.cboCustomer, Me.Label1, Me.GroupBox2, Me.GroupBox1})
        Me.Name = "frmPreload_Select_Cust"
        Me.Text = "Customer Defined PreLoad Elements"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmPreload_Select_Cust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PopulateCustomerPreLoad()  '//Populates the drop down with a list of all non endUser customers

    End Sub

    Private Sub PopulateCustomerPreLoad()

        Dim tblCust As New PSS.Data.Production.tcustomer()
        Dim dtCust As DataSet = tblCust.GetDataOrdered

        cboCustomer.DataSource = dtCust
        'cboCustomer.DisplayMember = dtCust.Tables("tcustomer").Columns("Cust_Name1").ToString
        'cboCustomer.ValueMember = dtCust.Tables("tcustomer").Columns("Cust_ID").ToString

    End Sub


    Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

    End Sub
End Class
