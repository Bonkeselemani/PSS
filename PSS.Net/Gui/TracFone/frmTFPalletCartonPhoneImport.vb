
Namespace Gui.TracFone

	Public Class frmTFPalletCartonPhoneImport
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
		Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents lblFile As System.Windows.Forms.Label
		Friend WithEvents btnGetFilename As System.Windows.Forms.Button
		Friend WithEvents btnImport As System.Windows.Forms.Button
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
			Me.lblFile = New System.Windows.Forms.Label()
			Me.btnGetFilename = New System.Windows.Forms.Button()
			Me.btnImport = New System.Windows.Forms.Button()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			'
			'lblFile
			'
			Me.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblFile.Location = New System.Drawing.Point(16, 56)
			Me.lblFile.Name = "lblFile"
			Me.lblFile.Size = New System.Drawing.Size(440, 23)
			Me.lblFile.TabIndex = 1
			'
			'btnGetFilename
			'
			Me.btnGetFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnGetFilename.Location = New System.Drawing.Point(464, 56)
			Me.btnGetFilename.Name = "btnGetFilename"
			Me.btnGetFilename.Size = New System.Drawing.Size(32, 23)
			Me.btnGetFilename.TabIndex = 2
			Me.btnGetFilename.Text = "..."
			'
			'btnImport
			'
			Me.btnImport.Location = New System.Drawing.Point(384, 112)
			Me.btnImport.Name = "btnImport"
			Me.btnImport.TabIndex = 3
			Me.btnImport.Text = "Import"
			'
			'Label2
			'
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.ForeColor = System.Drawing.Color.Blue
			Me.Label2.Location = New System.Drawing.Point(16, 24)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(248, 23)
			Me.Label2.TabIndex = 0
			Me.Label2.Text = "Select the file to be imported."
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(16, 112)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(352, 40)
			Me.lblMsg.TabIndex = 4
			Me.lblMsg.Text = "Message to User"
			'
			'Label3
			'
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.Location = New System.Drawing.Point(8, 216)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(488, 24)
			Me.Label3.TabIndex = 29
			Me.Label3.Text = "This screen is used to import data files for the TMO project."
			Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'frmTFPalletCartonPhoneImport
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(512, 254)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.lblMsg, Me.Label2, Me.btnImport, Me.btnGetFilename, Me.lblFile})
			Me.Name = "frmTFPalletCartonPhoneImport"
			Me.Text = "Tracfone Pallet/Carton/Phone Import"
			Me.ResumeLayout(False)

		End Sub

#End Region

		Private _invalidFileMsg As String = "The selected file is not a valid TMO data file."
		Private _successMsg As String = "The file has been successfully imported."
		Private _failMsg As String = "The file did not import and returned the following error."

		Private Sub btnGetFilename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetFilename.Click
			Dim _dr As New DialogResult()
			_dr = OpenFileDialog1.ShowDialog()
			If _dr = DialogResult.OK Then
				lblFile.Text = OpenFileDialog1.FileName
			End If
		End Sub

		Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
			' set variables.
			' validate the file.
			' import the file.
			' notifiy the user or success or failure.
		End Sub











	End Class

End Namespace
