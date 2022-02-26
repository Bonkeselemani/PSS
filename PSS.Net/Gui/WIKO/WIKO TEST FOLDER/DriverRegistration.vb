Public Class DriverRegistration
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
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(496, 224)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(264, 23)
        Me.Button4.TabIndex = 31
        Me.Button4.Text = "Refresh"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(496, 184)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(264, 23)
        Me.Button3.TabIndex = 30
        Me.Button3.Text = "Delete"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(496, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(264, 23)
        Me.Button2.TabIndex = 29
        Me.Button2.Text = "Update"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(496, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(264, 23)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Save"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(200, 256)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(184, 20)
        Me.TextBox4.TabIndex = 27
        Me.TextBox4.Text = " "
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(200, 216)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(184, 20)
        Me.TextBox3.TabIndex = 26
        Me.TextBox3.Text = " "
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(200, 144)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(184, 20)
        Me.TextBox2.TabIndex = 25
        Me.TextBox2.Text = " "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(200, 104)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(184, 20)
        Me.TextBox1.TabIndex = 24
        Me.TextBox1.Text = " "
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker1.Location = New System.Drawing.Point(200, 184)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(184, 20)
        Me.DateTimePicker1.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(88, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "User ID"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(88, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Adress"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(88, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "DOB"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(88, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "First Name "
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(88, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "ID"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(200, 296)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(664, 344)
        Me.DataGrid1.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(208, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(448, 56)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "DRIVER REGISTRATION "
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(72, 296)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 329)
        Me.ListBox1.TabIndex = 32
        '
        'DriverRegistration
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.ClientSize = New System.Drawing.Size(872, 646)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1, Me.Button4, Me.Button3, Me.Button2, Me.Button1, Me.TextBox4, Me.TextBox3, Me.TextBox2, Me.TextBox1, Me.DateTimePicker1, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.DataGrid1, Me.Label1})
        Me.Name = "DriverRegistration"
        Me.Text = "DriverRegistration"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
