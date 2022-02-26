Public Class frmTFFK_BulkOrder
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPalletsNo As System.Windows.Forms.TextBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtDevicesNo As System.Windows.Forms.TextBox
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPalletsNo = New System.Windows.Forms.TextBox()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.txtDevicesNo = New System.Windows.Forms.TextBox()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(192, 32)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "Bulk Order"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(40, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 23)
        Me.Label5.TabIndex = 176
        Me.Label5.Text = "Pallets Qty:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(40, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 23)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "Pckg Weight:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(40, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = "Devices Qty:"
        '
        'txtPalletsNo
        '
        Me.txtPalletsNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPalletsNo.Location = New System.Drawing.Point(184, 72)
        Me.txtPalletsNo.Name = "txtPalletsNo"
        Me.txtPalletsNo.Size = New System.Drawing.Size(104, 26)
        Me.txtPalletsNo.TabIndex = 179
        Me.txtPalletsNo.Text = ""
        '
        'txtWeight
        '
        Me.txtWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(184, 120)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(104, 26)
        Me.txtWeight.TabIndex = 180
        Me.txtWeight.Text = ""
        '
        'txtDevicesNo
        '
        Me.txtDevicesNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDevicesNo.Location = New System.Drawing.Point(184, 168)
        Me.txtDevicesNo.Name = "txtDevicesNo"
        Me.txtDevicesNo.Size = New System.Drawing.Size(104, 26)
        Me.txtDevicesNo.TabIndex = 181
        Me.txtDevicesNo.Text = ""
        '
        'btnProcess
        '
        Me.btnProcess.BackColor = System.Drawing.Color.Green
        Me.btnProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcess.ForeColor = System.Drawing.Color.White
        Me.btnProcess.Location = New System.Drawing.Point(88, 232)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(168, 48)
        Me.btnProcess.TabIndex = 182
        Me.btnProcess.Text = "Process"
        '
        'frmTFFK_BulkOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(352, 318)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnProcess, Me.txtDevicesNo, Me.txtWeight, Me.txtPalletsNo, Me.Label2, Me.Label1, Me.Label5, Me.Label4})
        Me.Name = "frmTFFK_BulkOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmTFFK_BulkOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnProcess.Enabled = False
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmTFFK_btnProcess", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub txtPalletsNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPalletsNo.TextChanged
        If txtPalletsNo.Text <> "" And txtWeight.Text <> "" And txtDevicesNo.Text <> "" Then
            btnProcess.Enabled = True
        Else
            btnProcess.Enabled = False
        End If
    End Sub

    Private Sub txtWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWeight.TextChanged
        If txtPalletsNo.Text <> "" And txtWeight.Text <> "" And txtDevicesNo.Text <> "" Then
            btnProcess.Enabled = True
        Else
            btnProcess.Enabled = False
        End If
    End Sub

    Private Sub txtDevicesNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDevicesNo.TextChanged
        If txtPalletsNo.Text <> "" And txtWeight.Text <> "" And txtDevicesNo.Text <> "" Then
            btnProcess.Enabled = True
        Else
            btnProcess.Enabled = False
        End If
    End Sub
End Class
