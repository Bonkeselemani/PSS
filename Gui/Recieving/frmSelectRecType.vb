


Namespace Gui.Receiving


    Public Class frmSelectRecType
        Inherits System.Windows.Forms.Form

        Public txtWebUserID As Int32


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
        Friend WithEvents grpPager As System.Windows.Forms.GroupBox
        Friend WithEvents grpCellular As System.Windows.Forms.GroupBox
        Friend WithEvents btnPagerEndUser As System.Windows.Forms.Button
        Friend WithEvents btnPagerCOAM As System.Windows.Forms.Button
        Friend WithEvents btnPagerFirm As System.Windows.Forms.Button
        Friend WithEvents btnCellWebUser As System.Windows.Forms.Button
        Friend WithEvents btnCellEndUser As System.Windows.Forms.Button
        Friend WithEvents btnCellCOAM As System.Windows.Forms.Button
        Friend WithEvents btnCellFirm As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnPagerPO As System.Windows.Forms.Button
        Friend WithEvents btnCellPO As System.Windows.Forms.Button
        Friend WithEvents btnRMASpecial As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grpPager = New System.Windows.Forms.GroupBox()
            Me.btnRMASpecial = New System.Windows.Forms.Button()
            Me.btnPagerPO = New System.Windows.Forms.Button()
            Me.btnPagerEndUser = New System.Windows.Forms.Button()
            Me.btnPagerCOAM = New System.Windows.Forms.Button()
            Me.btnPagerFirm = New System.Windows.Forms.Button()
            Me.grpCellular = New System.Windows.Forms.GroupBox()
            Me.btnCellPO = New System.Windows.Forms.Button()
            Me.btnCellWebUser = New System.Windows.Forms.Button()
            Me.btnCellEndUser = New System.Windows.Forms.Button()
            Me.btnCellCOAM = New System.Windows.Forms.Button()
            Me.btnCellFirm = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.grpPager.SuspendLayout()
            Me.grpCellular.SuspendLayout()
            Me.SuspendLayout()
            '
            'grpPager
            '
            Me.grpPager.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRMASpecial, Me.btnPagerPO, Me.btnPagerEndUser, Me.btnPagerCOAM, Me.btnPagerFirm})
            Me.grpPager.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.grpPager.Location = New System.Drawing.Point(8, 8)
            Me.grpPager.Name = "grpPager"
            Me.grpPager.Size = New System.Drawing.Size(160, 184)
            Me.grpPager.TabIndex = 0
            Me.grpPager.TabStop = False
            Me.grpPager.Text = "Pager"
            '
            'btnRMASpecial
            '
            Me.btnRMASpecial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRMASpecial.Location = New System.Drawing.Point(8, 152)
            Me.btnRMASpecial.Name = "btnRMASpecial"
            Me.btnRMASpecial.Size = New System.Drawing.Size(144, 23)
            Me.btnRMASpecial.TabIndex = 9
            Me.btnRMASpecial.Text = "Stage Receiving"
            Me.btnRMASpecial.Visible = False
            '
            'btnPagerPO
            '
            Me.btnPagerPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPagerPO.Location = New System.Drawing.Point(8, 120)
            Me.btnPagerPO.Name = "btnPagerPO"
            Me.btnPagerPO.Size = New System.Drawing.Size(144, 23)
            Me.btnPagerPO.TabIndex = 8
            Me.btnPagerPO.Text = "Purchase Order"
            Me.btnPagerPO.Visible = False
            '
            'btnPagerEndUser
            '
            Me.btnPagerEndUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPagerEndUser.Location = New System.Drawing.Point(8, 88)
            Me.btnPagerEndUser.Name = "btnPagerEndUser"
            Me.btnPagerEndUser.Size = New System.Drawing.Size(144, 23)
            Me.btnPagerEndUser.TabIndex = 7
            Me.btnPagerEndUser.Text = "End User"
            '
            'btnPagerCOAM
            '
            Me.btnPagerCOAM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPagerCOAM.Location = New System.Drawing.Point(8, 56)
            Me.btnPagerCOAM.Name = "btnPagerCOAM"
            Me.btnPagerCOAM.Size = New System.Drawing.Size(144, 23)
            Me.btnPagerCOAM.TabIndex = 6
            Me.btnPagerCOAM.Text = "COAM"
            '
            'btnPagerFirm
            '
            Me.btnPagerFirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPagerFirm.Location = New System.Drawing.Point(8, 24)
            Me.btnPagerFirm.Name = "btnPagerFirm"
            Me.btnPagerFirm.Size = New System.Drawing.Size(144, 23)
            Me.btnPagerFirm.TabIndex = 5
            Me.btnPagerFirm.Text = "Firm"
            Me.btnPagerFirm.Visible = False
            '
            'grpCellular
            '
            Me.grpCellular.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCellPO, Me.btnCellWebUser, Me.btnCellEndUser, Me.btnCellCOAM, Me.btnCellFirm})
            Me.grpCellular.Location = New System.Drawing.Point(176, 8)
            Me.grpCellular.Name = "grpCellular"
            Me.grpCellular.Size = New System.Drawing.Size(160, 184)
            Me.grpCellular.TabIndex = 1
            Me.grpCellular.TabStop = False
            Me.grpCellular.Text = "Cellular"
            Me.grpCellular.Visible = False
            '
            'btnCellPO
            '
            Me.btnCellPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCellPO.Location = New System.Drawing.Point(8, 152)
            Me.btnCellPO.Name = "btnCellPO"
            Me.btnCellPO.Size = New System.Drawing.Size(144, 23)
            Me.btnCellPO.TabIndex = 13
            Me.btnCellPO.Text = "Purchase Order"
            '
            'btnCellWebUser
            '
            Me.btnCellWebUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCellWebUser.Location = New System.Drawing.Point(8, 120)
            Me.btnCellWebUser.Name = "btnCellWebUser"
            Me.btnCellWebUser.Size = New System.Drawing.Size(144, 23)
            Me.btnCellWebUser.TabIndex = 12
            Me.btnCellWebUser.Text = "WEB User"
            '
            'btnCellEndUser
            '
            Me.btnCellEndUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCellEndUser.Location = New System.Drawing.Point(8, 88)
            Me.btnCellEndUser.Name = "btnCellEndUser"
            Me.btnCellEndUser.Size = New System.Drawing.Size(144, 23)
            Me.btnCellEndUser.TabIndex = 11
            Me.btnCellEndUser.Text = "End User"
            '
            'btnCellCOAM
            '
            Me.btnCellCOAM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCellCOAM.Location = New System.Drawing.Point(8, 56)
            Me.btnCellCOAM.Name = "btnCellCOAM"
            Me.btnCellCOAM.Size = New System.Drawing.Size(144, 23)
            Me.btnCellCOAM.TabIndex = 10
            Me.btnCellCOAM.Text = "COAM"
            '
            'btnCellFirm
            '
            Me.btnCellFirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCellFirm.Location = New System.Drawing.Point(8, 24)
            Me.btnCellFirm.Name = "btnCellFirm"
            Me.btnCellFirm.Size = New System.Drawing.Size(144, 23)
            Me.btnCellFirm.TabIndex = 9
            Me.btnCellFirm.Text = "Firm"
            '
            'btnCancel
            '
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Location = New System.Drawing.Point(8, 200)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(328, 23)
            Me.btnCancel.TabIndex = 3
            Me.btnCancel.Text = "Cancel"
            '
            'frmSelectRecType
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(344, 231)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.grpCellular, Me.grpPager})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "frmSelectRecType"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Select Receiving Type"
            Me.grpPager.ResumeLayout(False)
            Me.grpCellular.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public srcDevice As String
        Public srcRecType As String
        Public srcWebInput As String


        Private Sub btnPagerEndUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagerEndUser.Click

            srcDevice = "1"
            srcRecType = "3"
            Close()

        End Sub
        Private Sub btnPagerFirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagerFirm.Click

            srcDevice = "1"
            srcRecType = "1"
            Close()

        End Sub
        Private Sub btnPagerCOAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagerCOAM.Click

            srcDevice = "1"
            srcRecType = "2"
            Close()

        End Sub

        Private Sub frmSelectRecType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


            'Determine display based on security
            'Dim secType As Integer = 0

            'secType = 1

            'If secType = 1 Then 'Pager only
            ''configure properties of form
            'frmSelectRecType.ActiveForm.Width = 176
            'frmSelectRecType.ActiveForm.Height = 112
            'grpPager.Visible = True
            'grpPager.Left = 8
            'grpPager.Top = 8
            'grpCellular.Visible = False
            'btnCancel.Width = 160
            'btnCancel.Height = 23
            'btnCancel.Left = 16
            'btnCancel.Top = 168
            'End If


        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

            Me.Close()

        End Sub

        Private Sub btnCellFirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCellFirm.Click

            srcDevice = "2"
            srcRecType = "1"
            Close()

        End Sub

        Private Sub btnCellCOAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCellCOAM.Click

            srcDevice = "2"
            srcRecType = "2"
            Close()

        End Sub

        Private Sub btnCellEndUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCellEndUser.Click

            srcDevice = "2"
            srcRecType = "3"
            Close()

        End Sub

        Private Sub btnCellWebUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCellWebUser.Click

            'txtWebUserID = 0
            srcDevice = "2"
            srcRecType = "4"
            'Dim frmWebInput As New frmWebUserInput()
            'frmWebInput.ShowDialog()
            'srcWebInput = frmWebInput.WebUserID.ToString
            'If txtWebUserID < 1 Then
            'Exit Sub
            'End If
            Close()

        End Sub

        Private Sub grpPager_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpPager.Enter

        End Sub

        Private Sub btnPagerPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagerPO.Click

            srcDevice = "1"
            srcRecType = "4"
            Close()

        End Sub

        Private Sub btnRMASpecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRMASpecial.Click

            srcDevice = "1"
            srcRecType = "5"
            Close()

        End Sub

        Private Sub btnBulkRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            srcDevice = "1"
            srcRecType = "6"
            Close()

        End Sub

        Private Sub btnCellPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCellPO.Click

        End Sub
    End Class

End Namespace
