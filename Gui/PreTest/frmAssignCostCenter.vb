Public Class frmAssignCostCenter
    Inherits System.Windows.Forms.Form

    Private _objACC As PSS.Data.Production.AssignCostCenter

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objACC = New PSS.Data.Production.AssignCostCenter()
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
    Friend WithEvents lblTrayID As System.Windows.Forms.Label
    Friend WithEvents txtTrayID As System.Windows.Forms.TextBox
    Friend WithEvents btnAssignCostCenter As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblTrayID = New System.Windows.Forms.Label()
        Me.txtTrayID = New System.Windows.Forms.TextBox()
        Me.btnAssignCostCenter = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTrayID
        '
        Me.lblTrayID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrayID.ForeColor = System.Drawing.Color.Black
        Me.lblTrayID.Location = New System.Drawing.Point(16, 16)
        Me.lblTrayID.Name = "lblTrayID"
        Me.lblTrayID.Size = New System.Drawing.Size(56, 24)
        Me.lblTrayID.TabIndex = 0
        Me.lblTrayID.Text = "Tray ID:"
        Me.lblTrayID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTrayID
        '
        Me.txtTrayID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrayID.Location = New System.Drawing.Point(72, 16)
        Me.txtTrayID.Name = "txtTrayID"
        Me.txtTrayID.Size = New System.Drawing.Size(160, 22)
        Me.txtTrayID.TabIndex = 1
        Me.txtTrayID.Text = ""
        '
        'btnAssignCostCenter
        '
        Me.btnAssignCostCenter.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAssignCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssignCostCenter.ForeColor = System.Drawing.Color.White
        Me.btnAssignCostCenter.Location = New System.Drawing.Point(24, 64)
        Me.btnAssignCostCenter.Name = "btnAssignCostCenter"
        Me.btnAssignCostCenter.Size = New System.Drawing.Size(96, 40)
        Me.btnAssignCostCenter.TabIndex = 122
        Me.btnAssignCostCenter.Text = "Assign"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(168, 64)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 40)
        Me.btnCancel.TabIndex = 123
        Me.btnCancel.Text = "Cancel"
        '
        'frmAssignCostCenter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(288, 117)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnAssignCostCenter, Me.txtTrayID, Me.lblTrayID})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssignCostCenter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assign Cost Center to Tray Devices"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAssignCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignCostCenter.Click
        Dim i As Integer = 0
        Try
            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            If Me.txtTrayID.Text.Trim.Length > 0 Then
                If Not IsValidTrayID() Then
                    MessageBox.Show("A tray ID must be numeric.", "Invalid Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    i = AssignCostCenterToDevices()
                    If i > 0 Then MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in btnAssignCostCenter_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
            Me.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmAssignCostCenter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtTrayID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrayID.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then btnAssignCostCenter_Click(Me, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in txtTrayID_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtTrayID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTrayID.KeyPress
        Try
            If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in txtTrayID_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function IsValidTrayID() As Boolean
        Dim bIsValidTrayID As Boolean = True
        Dim strTrayID As String
        Dim chTray As Char

        Try
            strTrayID = Me.txtTrayID.Text.Trim

            For Each chTray In strTrayID
                If Not Char.IsDigit(chTray) Then
                    bIsValidTrayID = False

                    Exit For
                End If
            Next chTray

            Return bIsValidTrayID
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function AssignCostCenterToDevices() As Integer
        Dim iCCID As Integer = 0
        Dim strTrayID, strAssignedCC As String
        Dim i As Integer = 0

        Try
            iCCID = Me._objACC.GetCostCenterID()

            If iCCID > 0 Then
                strTrayID = Me.txtTrayID.Text.Trim

                If Me._objACC.IsValidTray(strTrayID) Then
                    strAssignedCC = Me._objACC.IsTrayAssigned(strTrayID)

                    If strAssignedCC.Length = 0 Then
                        If Me._objACC.ValidateMachGrpAndDevGrp(CInt(strTrayID)) = False Then
                            MessageBox.Show("Devices in this tray received under a different group than machine group. Please contact your supervisor for advice.", "Tray Assigned", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            i = Me._objACC.AssignCostCenterToTray(Me.txtTrayID.Text.Trim, iCCID)
                        End If
                    Else
                        MessageBox.Show("This tray has already been assigned to " & strAssignedCC & ".", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    MessageBox.Show("Either the tray ID is not valid or devices have been shipped from this tray.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                MessageBox.Show("No cost center has been assigned to this machine.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
