Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_Shipment
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
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnPost As System.Windows.Forms.Button
        Friend WithEvents lblPO As System.Windows.Forms.Label
        Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnPost = New System.Windows.Forms.Button()
            Me.lblPO = New System.Windows.Forms.Label()
            Me.txtPONumber = New System.Windows.Forms.TextBox()
            Me.SuspendLayout()
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(288, 32)
            Me.Label2.TabIndex = 159
            Me.Label2.Text = "Shipping"
            '
            'btnPost
            '
            Me.btnPost.BackColor = System.Drawing.Color.Green
            Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPost.Location = New System.Drawing.Point(200, 264)
            Me.btnPost.Name = "btnPost"
            Me.btnPost.Size = New System.Drawing.Size(168, 64)
            Me.btnPost.TabIndex = 158
            Me.btnPost.Text = "Ship"
            '
            'lblPO
            '
            Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPO.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.lblPO.Location = New System.Drawing.Point(32, 72)
            Me.lblPO.Name = "lblPO"
            Me.lblPO.Size = New System.Drawing.Size(128, 23)
            Me.lblPO.TabIndex = 163
            Me.lblPO.Text = "Order #"
            '
            'txtPONumber
            '
            Me.txtPONumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPONumber.Location = New System.Drawing.Point(176, 72)
            Me.txtPONumber.Name = "txtPONumber"
            Me.txtPONumber.Size = New System.Drawing.Size(184, 26)
            Me.txtPONumber.TabIndex = 162
            Me.txtPONumber.Text = ""
            '
            'frmTFFK_Shipment
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(400, 350)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPO, Me.txtPONumber, Me.Label2, Me.btnPost})
            Me.Name = "frmTFFK_Shipment"
            Me.Text = "frmTFFK_Shipment"
            Me.ResumeLayout(False)

        End Sub

#End Region

    End Class
End Namespace