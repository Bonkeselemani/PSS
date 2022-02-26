Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Reflection

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
        End Sub

#Region "Windows Form Designer generated code"
        Friend WithEvents dgReferencedAssemblies As System.Windows.Forms.DataGrid

        Private Sub InitializeComponent()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.dgReferencedAssemblies = New System.Windows.Forms.DataGrid()
            Me.tbxVersion = New System.Windows.Forms.TextBox()
            Me.label5 = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.groupBox1.SuspendLayout()
            CType(Me.dgReferencedAssemblies, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'groupBox1
            '
            Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgReferencedAssemblies, Me.tbxVersion, Me.label5})
            Me.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.groupBox1.Location = New System.Drawing.Point(8, 8)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(369, 296)
            Me.groupBox1.TabIndex = 0
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Info"
            '
            'dgReferencedAssemblies
            '
            Me.dgReferencedAssemblies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dgReferencedAssemblies.CaptionBackColor = System.Drawing.Color.SteelBlue
            Me.dgReferencedAssemblies.CaptionText = "Referenced Assemblies"
            Me.dgReferencedAssemblies.DataMember = ""
            Me.dgReferencedAssemblies.FlatMode = True
            Me.dgReferencedAssemblies.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dgReferencedAssemblies.Location = New System.Drawing.Point(8, 64)
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
            Me.tbxVersion.Location = New System.Drawing.Point(72, 32)
            Me.tbxVersion.Name = "tbxVersion"
            Me.tbxVersion.Size = New System.Drawing.Size(184, 21)
            Me.tbxVersion.TabIndex = 5
            Me.tbxVersion.Text = ""
            '
            'label5
            '
            Me.label5.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.label5.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.label5.Location = New System.Drawing.Point(16, 33)
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
            Me.label2.Location = New System.Drawing.Point(24, 360)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(344, 72)
            Me.label2.TabIndex = 1
            Me.label2.Text = "This software is Copyright © Product Support Services, Inc. 2003. Reproduction, t" & _
            "ransfer, distribution or storage of part or all of the contents in any form with" & _
            "out the prior written permission of Product Support Services, Inc. is prohibited" & _
            "."
            '
            'btnOK
            '
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnOK.Location = New System.Drawing.Point(296, 314)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(72, 27)
            Me.btnOK.TabIndex = 1
            Me.btnOK.Text = "OK"
            '
            'AboutWin
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.CancelButton = Me.btnOK
            Me.ClientSize = New System.Drawing.Size(381, 447)
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
    End Class

End Namespace

