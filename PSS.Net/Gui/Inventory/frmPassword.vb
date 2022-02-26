Namespace Inventory
    Public Class frmPassword
        Inherits System.Windows.Forms.Form
        Private objInventory As PSS.Data.Buisness.Inventory
#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objInventory = New PSS.Data.Buisness.Inventory()
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
        Friend WithEvents lbl As System.Windows.Forms.Label
        Friend WithEvents txtPwd As System.Windows.Forms.TextBox
        Friend WithEvents cmdOK As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lbl = New System.Windows.Forms.Label()
            Me.txtPwd = New System.Windows.Forms.TextBox()
            Me.cmdOK = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lbl
            '
            Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl.Location = New System.Drawing.Point(16, 24)
            Me.lbl.Name = "lbl"
            Me.lbl.Size = New System.Drawing.Size(72, 23)
            Me.lbl.TabIndex = 0
            Me.lbl.Text = "Password:"
            '
            'txtPwd
            '
            Me.txtPwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPwd.Location = New System.Drawing.Point(93, 20)
            Me.txtPwd.MaxLength = 10
            Me.txtPwd.Name = "txtPwd"
            Me.txtPwd.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtPwd.Size = New System.Drawing.Size(123, 26)
            Me.txtPwd.TabIndex = 1
            Me.txtPwd.Text = ""
            '
            'cmdOK
            '
            Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdOK.Location = New System.Drawing.Point(229, 19)
            Me.cmdOK.Name = "cmdOK"
            Me.cmdOK.Size = New System.Drawing.Size(51, 28)
            Me.cmdOK.TabIndex = 2
            Me.cmdOK.Text = "OK"
            '
            'frmPassword
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(298, 70)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdOK, Me.txtPwd, Me.lbl})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Name = "frmPassword"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Enter Password (Part Replenishment)"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private strPwdValidated As Integer
        Public Property PasswordValidated() As Integer
            Get
                Return strPwdValidated
            End Get
            Set(ByVal Value As Integer)
                strPwdValidated = Value
            End Set
        End Property

        '**************************************************
        Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
            ValidatePassword()
        End Sub
        '**************************************************
        Private Sub ValidatePassword()
            Try
                strPwdValidated = objInventory.ValidatePassword(LCase(Trim(Me.txtPwd.Text)))
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Password Validation", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Close()
            End Try
        End Sub
        '**************************************************
        Private Sub txtPwd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPwd.KeyUp
            If e.KeyValue = 13 Then
                ValidatePassword()
            End If
        End Sub
        '**************************************************
        Protected Overrides Sub Finalize()
            objInventory = Nothing
            MyBase.Finalize()
        End Sub
        '**************************************************
    End Class
End Namespace