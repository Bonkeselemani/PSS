Public Class frmMsgPreTest
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
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents Panel2 As System.Windows.Forms.Panel
	Friend WithEvents Panel3 As System.Windows.Forms.Panel
	Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents Label10 As System.Windows.Forms.Label
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents Label12 As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents Label14 As System.Windows.Forms.Label
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents Label16 As System.Windows.Forms.Label
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents Label18 As System.Windows.Forms.Label
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents Label20 As System.Windows.Forms.Label
	Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
	Friend WithEvents Button2 As System.Windows.Forms.Button
	Friend WithEvents Button3 As System.Windows.Forms.Button
	Friend WithEvents Button4 As System.Windows.Forms.Button
	Friend WithEvents Label21 As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Button4 = New System.Windows.Forms.Button()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Button3 = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.DataGrid1 = New System.Windows.Forms.DataGrid()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.Panel3.SuspendLayout()
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
		Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.Label19, Me.Label20, Me.Label7, Me.Label8, Me.Label13, Me.Label14, Me.Label11, Me.Label12, Me.Label1, Me.Label10, Me.Label9, Me.Button4})
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(832, 160)
		Me.Panel1.TabIndex = 0
		'
		'Label15
		'
		Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label15.Location = New System.Drawing.Point(624, 88)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(88, 23)
		Me.Label15.TabIndex = 18
		Me.Label15.Text = "Total:"
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label16
		'
		Me.Label16.BackColor = System.Drawing.Color.LightSteelBlue
		Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label16.Location = New System.Drawing.Point(720, 88)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(88, 23)
		Me.Label16.TabIndex = 19
		Me.Label16.Text = "0"
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label17
		'
		Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label17.Location = New System.Drawing.Point(632, 56)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(80, 23)
		Me.Label17.TabIndex = 16
		Me.Label17.Text = "Failed:"
		Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label18
		'
		Me.Label18.BackColor = System.Drawing.Color.LightCoral
		Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label18.Location = New System.Drawing.Point(720, 56)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(88, 23)
		Me.Label18.TabIndex = 17
		Me.Label18.Text = "0"
		Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label19
		'
		Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label19.Location = New System.Drawing.Point(632, 24)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(80, 23)
		Me.Label19.TabIndex = 14
		Me.Label19.Text = "Passed:"
		Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label20
		'
		Me.Label20.BackColor = System.Drawing.Color.MediumAquamarine
		Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label20.Location = New System.Drawing.Point(720, 24)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(88, 23)
		Me.Label20.TabIndex = 15
		Me.Label20.Text = "0"
		Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label7
		'
		Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(312, 88)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(88, 23)
		Me.Label7.TabIndex = 12
		Me.Label7.Text = "Line:"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label8
		'
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.Location = New System.Drawing.Point(408, 88)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(144, 23)
		Me.Label8.TabIndex = 13
		'
		'Label13
		'
		Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label13.Location = New System.Drawing.Point(320, 56)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(80, 23)
		Me.Label13.TabIndex = 10
		Me.Label13.Text = "Group:"
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label14
		'
		Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label14.Location = New System.Drawing.Point(408, 56)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(144, 23)
		Me.Label14.TabIndex = 11
		'
		'Label11
		'
		Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.Location = New System.Drawing.Point(288, 120)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(112, 23)
		Me.Label11.TabIndex = 8
		Me.Label11.Text = "Computer name:"
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label12
		'
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.Location = New System.Drawing.Point(408, 120)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(144, 23)
		Me.Label12.TabIndex = 9
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(16, 16)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(200, 32)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Messaging Pre-Test"
		'
		'Label10
		'
		Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label10.Location = New System.Drawing.Point(320, 24)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(80, 23)
		Me.Label10.TabIndex = 6
		Me.Label10.Text = "Username:"
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label9
		'
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label9.Location = New System.Drawing.Point(408, 24)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(144, 23)
		Me.Label9.TabIndex = 7
		'
		'Button4
		'
		Me.Button4.BackColor = System.Drawing.SystemColors.Control
		Me.Button4.Location = New System.Drawing.Point(624, 120)
		Me.Button4.Name = "Button4"
		Me.Button4.Size = New System.Drawing.Size(184, 32)
		Me.Button4.TabIndex = 4
		Me.Button4.Text = "Pre-Test Device List"
		'
		'Panel2
		'
		Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.Label6, Me.Label4, Me.Label3, Me.TextBox1, Me.Label2, Me.Button1, Me.Button3, Me.Button2})
		Me.Panel2.Location = New System.Drawing.Point(0, 160)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(840, 160)
		Me.Panel2.TabIndex = 1
		'
		'Label5
		'
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.Location = New System.Drawing.Point(584, 56)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(224, 23)
		Me.Label5.TabIndex = 3
		'
		'Label6
		'
		Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.Location = New System.Drawing.Point(472, 56)
		Me.Label6.Name = "Label6"
		Me.Label6.TabIndex = 2
		Me.Label6.Text = "Customer:"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label4
		'
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(584, 24)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(224, 23)
		Me.Label4.TabIndex = 1
		'
		'Label3
		'
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(472, 24)
		Me.Label3.Name = "Label3"
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Product Type:"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'TextBox1
		'
		Me.TextBox1.BackColor = System.Drawing.Color.Yellow
		Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TextBox1.Location = New System.Drawing.Point(96, 24)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(224, 23)
		Me.TextBox1.TabIndex = 1
		Me.TextBox1.Text = ""
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(8, 24)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(72, 23)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Serial #:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(656, 112)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(160, 32)
		Me.Button1.TabIndex = 3
		Me.Button1.Text = "Clear"
		'
		'Button3
		'
		Me.Button3.BackColor = System.Drawing.Color.LightCoral
		Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button3.Location = New System.Drawing.Point(432, 112)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(160, 32)
		Me.Button3.TabIndex = 1
		Me.Button3.Text = "Fail"
		'
		'Button2
		'
		Me.Button2.BackColor = System.Drawing.Color.MediumAquamarine
		Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Button2.Location = New System.Drawing.Point(208, 112)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(160, 32)
		Me.Button2.TabIndex = 0
		Me.Button2.Text = "Pass"
		'
		'Panel3
		'
		Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
		Me.Panel3.Location = New System.Drawing.Point(-8, 320)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(840, 144)
		Me.Panel3.TabIndex = 2
		'
		'DataGrid1
		'
		Me.DataGrid1.CaptionText = "Pre-Test History"
		Me.DataGrid1.DataMember = ""
		Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGrid1.Location = New System.Drawing.Point(16, 8)
		Me.DataGrid1.Name = "DataGrid1"
		Me.DataGrid1.Size = New System.Drawing.Size(816, 128)
		Me.DataGrid1.TabIndex = 4
		'
		'Label21
		'
		Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label21.Location = New System.Drawing.Point(0, 488)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(816, 16)
		Me.Label21.TabIndex = 8
		Me.Label21.Text = "   This screen is used for Pre-Testing devices to route them the correct location" & _
		"."
		'
		'frmMsgPreTest
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(832, 518)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label21, Me.Panel3, Me.Panel2, Me.Panel1})
		Me.Name = "frmMsgPreTest"
		Me.Text = "Messaging Pre-Test"
		Me.Panel1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

	End Sub
	Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

	End Sub

	Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

	End Sub
End Class
