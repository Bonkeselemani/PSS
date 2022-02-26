Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Reflection
Imports PSS.Data

Namespace Gui.About

    Public Class AboutWin
        Inherits System.Windows.Forms.Form

        Private groupBox1 As System.Windows.Forms.GroupBox
        Private WithEvents btnOK As System.Windows.Forms.Button
        Private label2 As System.Windows.Forms.Label
        Private label5 As System.Windows.Forms.Label
        Private tbxVersion As System.Windows.Forms.TextBox
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            InitializeComponent()

            Dim asmme As [Assembly] = [Assembly].GetExecutingAssembly()
            Me.tbxVersion.Text = Application.ProductVersion

            Dim arranReferencedAssemblies As AssemblyName() = asmme.GetReferencedAssemblies()
            dgReferencedAssemblies.DataSource = arranReferencedAssemblies

            Dim objDataProc As DBQuery.DataProc
            objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Me.txtServer.Text = ConfigFile.Server

            CheckEnvironment()

        End Sub

#Region "Windows Form Designer generated code"
        Friend WithEvents dgReferencedAssemblies As System.Windows.Forms.DataGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtServer As System.Windows.Forms.TextBox
        Friend WithEvents lblProd As System.Windows.Forms.Label
        Friend WithEvents lblDevNet As System.Windows.Forms.Label
        Friend WithEvents lblTestNet As System.Windows.Forms.Label

        Private Sub InitializeComponent()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.txtServer = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.dgReferencedAssemblies = New System.Windows.Forms.DataGrid()
            Me.tbxVersion = New System.Windows.Forms.TextBox()
            Me.label5 = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.lblProd = New System.Windows.Forms.Label()
            Me.lblDevNet = New System.Windows.Forms.Label()
            Me.lblTestNet = New System.Windows.Forms.Label()
            Me.groupBox1.SuspendLayout()
            CType(Me.dgReferencedAssemblies, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'groupBox1
            '
            Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProd, Me.lblDevNet, Me.lblTestNet, Me.txtServer, Me.Label1, Me.dgReferencedAssemblies, Me.tbxVersion, Me.label5})
            Me.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.groupBox1.Location = New System.Drawing.Point(8, 8)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(369, 336)
            Me.groupBox1.TabIndex = 0
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Info"
            '
            'txtServer
            '
            Me.txtServer.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.txtServer.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtServer.Enabled = False
            Me.txtServer.ForeColor = System.Drawing.Color.Black
            Me.txtServer.Location = New System.Drawing.Point(72, 56)
            Me.txtServer.Name = "txtServer"
            Me.txtServer.Size = New System.Drawing.Size(184, 21)
            Me.txtServer.TabIndex = 8
            Me.txtServer.Text = ""
            Me.txtServer.Visible = False
            '
            'Label1
            '
            Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.Label1.Location = New System.Drawing.Point(16, 58)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(54, 16)
            Me.Label1.TabIndex = 7
            Me.Label1.Text = "Server"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label1.Visible = False
            '
            'dgReferencedAssemblies
            '
            Me.dgReferencedAssemblies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dgReferencedAssemblies.CaptionBackColor = System.Drawing.Color.SteelBlue
            Me.dgReferencedAssemblies.CaptionText = "Referenced Assemblies"
            Me.dgReferencedAssemblies.DataMember = ""
            Me.dgReferencedAssemblies.FlatMode = True
            Me.dgReferencedAssemblies.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dgReferencedAssemblies.Location = New System.Drawing.Point(8, 88)
            Me.dgReferencedAssemblies.Name = "dgReferencedAssemblies"
            Me.dgReferencedAssemblies.Size = New System.Drawing.Size(352, 224)
            Me.dgReferencedAssemblies.TabIndex = 6
            '
            'tbxVersion
            '
            Me.tbxVersion.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.tbxVersion.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.tbxVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tbxVersion.Enabled = False
            Me.tbxVersion.ForeColor = System.Drawing.Color.Black
            Me.tbxVersion.Location = New System.Drawing.Point(72, 34)
            Me.tbxVersion.Name = "tbxVersion"
            Me.tbxVersion.Size = New System.Drawing.Size(184, 21)
            Me.tbxVersion.TabIndex = 5
            Me.tbxVersion.Text = ""
            '
            'label5
            '
            Me.label5.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.label5.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.label5.Location = New System.Drawing.Point(16, 36)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(54, 16)
            Me.label5.TabIndex = 4
            Me.label5.Text = "Version"
            Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'label2
            '
            Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.label2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.label2.Location = New System.Drawing.Point(16, 408)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(344, 72)
            Me.label2.TabIndex = 1
            Me.label2.Text = "This software is Copyright � Product Support Services, Inc. 2003. Reproduction, t" & _
            "ransfer, distribution or storage of part or all of the contents in any form with" & _
            "out the prior written permission of Product Support Services, Inc. is prohibited" & _
            "."
            '
            'btnOK
            '
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnOK.Location = New System.Drawing.Point(288, 360)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(72, 27)
            Me.btnOK.TabIndex = 1
            Me.btnOK.Text = "OK"
            '
            'lblProd
            '
            Me.lblProd.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblProd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProd.ForeColor = System.Drawing.Color.White
            Me.lblProd.Location = New System.Drawing.Point(272, 16)
            Me.lblProd.Name = "lblProd"
            Me.lblProd.Size = New System.Drawing.Size(88, 24)
            Me.lblProd.TabIndex = 18
            Me.lblProd.Text = "Production"
            Me.lblProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDevNet
            '
            Me.lblDevNet.BackColor = System.Drawing.Color.ForestGreen
            Me.lblDevNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblDevNet.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevNet.ForeColor = System.Drawing.Color.White
            Me.lblDevNet.Location = New System.Drawing.Point(272, 64)
            Me.lblDevNet.Name = "lblDevNet"
            Me.lblDevNet.Size = New System.Drawing.Size(88, 24)
            Me.lblDevNet.TabIndex = 17
            Me.lblDevNet.Text = "DEVNET"
            Me.lblDevNet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblTestNet
            '
            Me.lblTestNet.BackColor = System.Drawing.Color.Red
            Me.lblTestNet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTestNet.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestNet.ForeColor = System.Drawing.Color.White
            Me.lblTestNet.Location = New System.Drawing.Point(272, 40)
            Me.lblTestNet.Name = "lblTestNet"
            Me.lblTestNet.Size = New System.Drawing.Size(88, 24)
            Me.lblTestNet.TabIndex = 16
            Me.lblTestNet.Text = "TESTNET"
            Me.lblTestNet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'AboutWin
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.CancelButton = Me.btnOK
            Me.ClientSize = New System.Drawing.Size(381, 488)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnOK, Me.groupBox1, Me.label2})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AboutWin"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "About PSS.Net"
            Me.groupBox1.ResumeLayout(False)
            CType(Me.dgReferencedAssemblies, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
#End Region

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
            Me.Close()
        End Sub

        Private Sub CheckEnvironment()
            Dim objDataProc As DBQuery.DataProc
            objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Me.lblTestNet.Visible = (ConfigFile.Server <> "172.16.25.21")
            ' DISPLAY THE LABLE REPRESENTING THE ENVIRONMENT.
            lblProd.Visible = False
            lblTestNet.Visible = False
            lblDevNet.Visible = False
            Dim _envText As String
            Select Case ConfigFile.Server.ToString()
                Case "172.16.25.21" : lblProd.Visible = True : lblProd.Top = 34
                Case "172.16.25.79" : lblTestNet.Visible = True : lblTestNet.Top = 34
                Case "172.16.25.112" : lblDevNet.Visible = True : lblDevNet.Top = 34
                Case "172.16.25.119" : lblDevNet.Visible = True : lblDevNet.Top = 34
                Case "172.16.25.95" : lblDevNet.Visible = True : lblDevNet.Top = 34
                Case "172.16.25.29" : lblDevNet.Visible = True : lblDevNet.Top = 34
                Case Else : lblTestNet.Visible = True : lblTestNet.Top = 34
            End Select
		End Sub

	End Class

End Namespace

