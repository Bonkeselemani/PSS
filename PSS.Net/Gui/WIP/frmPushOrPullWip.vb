Public Class frmPushOrPullWip
    Inherits System.Windows.Forms.Form

    Private iCompMapGroup As Integer = PSS.Core.Global.ApplicationUser.GroupID


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
    Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomer1 As System.Windows.Forms.Label
    Friend WithEvents lblMesg As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdEnter As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents CheckPassed As System.Windows.Forms.CheckBox
    Friend WithEvents CheckFailed As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtIMEI = New System.Windows.Forms.TextBox()
        Me.lblCustomer1 = New System.Windows.Forms.Label()
        Me.lblMesg = New System.Windows.Forms.Label()
        Me.cmdEnter = New System.Windows.Forms.Button()
        Me.CheckPassed = New System.Windows.Forms.CheckBox()
        Me.CheckFailed = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(1, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(341, 54)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "CELLULAR 1 PRETEST FUNCTIONAL"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtIMEI
        '
        Me.txtIMEI.Enabled = False
        Me.txtIMEI.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(72, 56)
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.Size = New System.Drawing.Size(168, 23)
        Me.txtIMEI.TabIndex = 71
        Me.txtIMEI.Text = ""
        '
        'lblCustomer1
        '
        Me.lblCustomer1.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomer1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCustomer1.ForeColor = System.Drawing.Color.Black
        Me.lblCustomer1.Location = New System.Drawing.Point(24, 56)
        Me.lblCustomer1.Name = "lblCustomer1"
        Me.lblCustomer1.Size = New System.Drawing.Size(48, 16)
        Me.lblCustomer1.TabIndex = 72
        Me.lblCustomer1.Text = "IMEI"
        Me.lblCustomer1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMesg
        '
        Me.lblMesg.BackColor = System.Drawing.Color.SteelBlue
        Me.lblMesg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMesg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMesg.ForeColor = System.Drawing.Color.White
        Me.lblMesg.Location = New System.Drawing.Point(1, 162)
        Me.lblMesg.Name = "lblMesg"
        Me.lblMesg.Size = New System.Drawing.Size(341, 30)
        Me.lblMesg.TabIndex = 73
        Me.lblMesg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdEnter
        '
        Me.cmdEnter.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdEnter.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdEnter.ForeColor = System.Drawing.Color.White
        Me.cmdEnter.Location = New System.Drawing.Point(248, 55)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(67, 24)
        Me.cmdEnter.TabIndex = 74
        Me.cmdEnter.Text = "Enter"
        Me.cmdEnter.Visible = False
        '
        'CheckPassed
        '
        Me.CheckPassed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckPassed.Location = New System.Drawing.Point(13, 12)
        Me.CheckPassed.Name = "CheckPassed"
        Me.CheckPassed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckPassed.Size = New System.Drawing.Size(72, 24)
        Me.CheckPassed.TabIndex = 75
        Me.CheckPassed.Text = "Passed"
        '
        'CheckFailed
        '
        Me.CheckFailed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckFailed.Location = New System.Drawing.Point(112, 12)
        Me.CheckFailed.Name = "CheckFailed"
        Me.CheckFailed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckFailed.Size = New System.Drawing.Size(72, 24)
        Me.CheckFailed.TabIndex = 76
        Me.CheckFailed.Text = "Failed"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckPassed, Me.lblCustomer1, Me.txtIMEI, Me.CheckFailed, Me.cmdEnter})
        Me.Panel1.Location = New System.Drawing.Point(0, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(342, 104)
        Me.Panel1.TabIndex = 77
        '
        'frmPushOrPullWip
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(408, 277)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.lblMesg, Me.lblTitle})
        Me.Name = "frmPushOrPullWip"
        Me.Text = "frmPushOrPullWip"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmPushOrPullWip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objInventory As New PSS.Data.Buisness.Inventory()

        Try
            Me.lblTitle.Text = objInventory.GetGroupDesc(iCompMapGroup)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Loading", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
        End Try
    End Sub

    '****************************************************************************
    Private Sub CheckPassed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckPassed.CheckedChanged
        If Me.CheckPassed.Checked = True Then
            Me.CheckFailed.Checked = False
            Me.CheckFailed.Visible = False
        End If
    End Sub

    '****************************************************************************
    Private Sub CheckFailed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckFailed.CheckedChanged
        If Me.CheckFailed.Checked = True Then
            Me.CheckPassed.Checked = False
            Me.CheckPassed.Visible = False
        End If
    End Sub

    '****************************************************************************
    Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
        Dim objInventory As New PSS.Data.Buisness.Inventory()

        If e.KeyValue = 13 Then
            Try


            Catch ex As Exception

            Finally
                objInventory = Nothing
            End Try
        End If
    End Sub
End Class
