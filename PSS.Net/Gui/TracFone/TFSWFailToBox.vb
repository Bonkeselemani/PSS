Public Class TFSWFailToBox
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
	Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Button2 As System.Windows.Forms.Button
	Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.ListBox1 = New System.Windows.Forms.ListBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.ComboBox1 = New System.Windows.Forms.ComboBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'TextBox1
		'
		Me.TextBox1.BackColor = System.Drawing.Color.Yellow
		Me.TextBox1.Location = New System.Drawing.Point(152, 56)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(264, 20)
		Me.TextBox1.TabIndex = 0
		Me.TextBox1.Text = ""
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(152, 16)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(200, 20)
		Me.TextBox2.TabIndex = 1
		Me.TextBox2.Text = ""
		'
		'Button1
		'
		Me.Button1.BackColor = System.Drawing.SystemColors.Control
		Me.Button1.Location = New System.Drawing.Point(528, 448)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(104, 32)
		Me.Button1.TabIndex = 2
		Me.Button1.Text = "Move to SW Fail Box"
		'
		'ListBox1
		'
		Me.ListBox1.Location = New System.Drawing.Point(376, 16)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(200, 17)
		Me.ListBox1.TabIndex = 3
		'
		'Label1
		'
		Me.Label1.BackColor = System.Drawing.Color.White
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label1.Location = New System.Drawing.Point(480, 184)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(96, 23)
		Me.Label1.TabIndex = 4
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(40, 56)
		Me.Label2.Name = "Label2"
		Me.Label2.TabIndex = 5
		Me.Label2.Text = "Box Number:"
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(16, 16)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(128, 23)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "Device Serial Number:"
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(368, 184)
		Me.Label4.Name = "Label4"
		Me.Label4.TabIndex = 7
		Me.Label4.Text = "Box Count:"
		'
		'Button2
		'
		Me.Button2.BackColor = System.Drawing.SystemColors.Control
		Me.Button2.Location = New System.Drawing.Point(440, 24)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(176, 24)
		Me.Button2.TabIndex = 8
		Me.Button2.Text = "Generate New Box Number"
		'
		'ComboBox1
		'
		Me.ComboBox1.Location = New System.Drawing.Point(152, 24)
		Me.ComboBox1.Name = "ComboBox1"
		Me.ComboBox1.Size = New System.Drawing.Size(264, 21)
		Me.ComboBox1.TabIndex = 9
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(24, 24)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(112, 16)
		Me.Label5.TabIndex = 10
		Me.Label5.Text = "Model:"
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.SystemColors.Control
		Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.TextBox2, Me.ListBox1, Me.Label4, Me.Label1})
		Me.Panel1.Location = New System.Drawing.Point(8, 96)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(656, 240)
		Me.Panel1.TabIndex = 11
		'
		'TFSWFailToBox
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.Color.SteelBlue
		Me.ClientSize = New System.Drawing.Size(672, 502)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.Label5, Me.ComboBox1, Me.Button2, Me.Label2, Me.Button1, Me.TextBox1})
		Me.Name = "TFSWFailToBox"
		Me.Text = "TFSWFailToBox"
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region


End Class
