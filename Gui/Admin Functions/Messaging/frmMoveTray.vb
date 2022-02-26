Namespace Gui.Edit
    Public Class frmMoveTray
        Inherits System.Windows.Forms.Form
        Private objMisc As PSS.Data.Buisness.Misc
        Private R1 As DataRow
        Private dt1 As DataTable
        Private iPrevWCLocationID As Integer = 0
        Private iTray_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMisc = New PSS.Data.Buisness.Misc()
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
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboLocation As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtTray As System.Windows.Forms.TextBox
        Friend WithEvents btnMove As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.btnMove = New System.Windows.Forms.Button()
            Me.txtTray = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboLocation = New PSS.Gui.Controls.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel6.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel6
            '
            Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnMove, Me.txtTray, Me.Label1, Me.cboLocation, Me.Label5, Me.Button4, Me.lblLocation, Me.Label7})
            Me.Panel6.Location = New System.Drawing.Point(8, 30)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(456, 131)
            Me.Panel6.TabIndex = 80
            '
            'btnMove
            '
            Me.btnMove.BackColor = System.Drawing.Color.SteelBlue
            Me.btnMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMove.ForeColor = System.Drawing.Color.White
            Me.btnMove.Location = New System.Drawing.Point(320, 80)
            Me.btnMove.Name = "btnMove"
            Me.btnMove.Size = New System.Drawing.Size(96, 24)
            Me.btnMove.TabIndex = 86
            Me.btnMove.Text = "Move Tray"
            '
            'txtTray
            '
            Me.txtTray.Location = New System.Drawing.Point(105, 24)
            Me.txtTray.Name = "txtTray"
            Me.txtTray.Size = New System.Drawing.Size(88, 20)
            Me.txtTray.TabIndex = 85
            Me.txtTray.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(22, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(74, 16)
            Me.Label1.TabIndex = 84
            Me.Label1.Text = "Tray ID :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocation
            '
            Me.cboLocation.AutoComplete = True
            Me.cboLocation.BackColor = System.Drawing.SystemColors.Window
            Me.cboLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation.ForeColor = System.Drawing.Color.Black
            Me.cboLocation.Location = New System.Drawing.Point(105, 82)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(199, 21)
            Me.cboLocation.TabIndex = 1
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(33, 84)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(69, 16)
            Me.Label5.TabIndex = 81
            Me.Label5.Text = "Move to :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Button4
            '
            Me.Button4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button4.Location = New System.Drawing.Point(144, 245)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(200, 31)
            Me.Button4.TabIndex = 66
            Me.Button4.TabStop = False
            Me.Button4.Text = "Generate Report"
            '
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.Blue
            Me.lblLocation.Location = New System.Drawing.Point(105, 55)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(199, 16)
            Me.lblLocation.TabIndex = 83
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(8, 55)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(89, 16)
            Me.Label7.TabIndex = 82
            Me.Label7.Text = "Assigned to :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Yellow
            Me.Label2.Location = New System.Drawing.Point(8, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(272, 16)
            Me.Label2.TabIndex = 85
            Me.Label2.Text = "Move Tray to another Line"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmMoveTray
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(608, 268)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Panel6})
            Me.Name = "frmMoveTray"
            Me.Text = "Move tray from one line to another."
            Me.Panel6.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Sub txtTray_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTray.KeyUp
            If e.KeyValue = 13 Then
                If Me.txtTray.Text = "" Then
                    MessageBox.Show("Please enter a Tray ID.", "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If Not IsNumeric(Me.txtTray.Text) Then
                    MessageBox.Show("Please enter a numeric value for Tray ID.", "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                GetLineTrayAssignedTo()



            End If
        End Sub

        Private Sub GetLineTrayAssignedTo()
            Try
                iTray_ID = 0
                iPrevWCLocationID = 0
                Me.lblLocation.Text = ""

                iTray_ID = CInt(Trim(Me.txtTray.Text))

                dt1 = New DataTable()
                dt1 = objMisc.GetLineTrayAssignedTo(iTray_ID)
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    iPrevWCLocationID = R1("WCLocation_ID")
                    Me.lblLocation.Text = R1("WC_Location")
                Else
                    Throw New Exception("This tray is not assigned to any line yet.")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                objMisc.DisposeDT(dt1)
            End Try
        End Sub

        Private Sub frmMoveTray_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            LoadLocations()
        End Sub

        Private Sub LoadLocations()
            Dim dtWCLoc As New DataTable()
            Try
                dtWCLoc = objMisc.GetWCLocations
                With Me.cboLocation
                    .DataSource = dtWCLoc.DefaultView
                    .DisplayMember = dtWCLoc.Columns("WC_Location").ToString
                    .ValueMember = dtWCLoc.Columns("WCLocation_ID").ToString
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                MessageBox.Show("Error in frmMoveTray.LoadLocations:: " & ex.Message.ToString, "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc.DisposeDT(dtWCLoc)
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
            Dim i As Integer = 0
            Try
                '************************
                'Required field validations
                If iTray_ID = 0 Then
                    MessageBox.Show("Please scan in a tray to be reassigned.", "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If iPrevWCLocationID = 0 Then
                    MessageBox.Show("This tray has not been assigned to any line before. First time assignments need to be done using 'End of Line Tray Scan' screen.", "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If Me.cboLocation.SelectedValue = 0 Then
                    MessageBox.Show("Please select a line to reassign the tray.", "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If iPrevWCLocationID = Me.cboLocation.SelectedValue Then
                    MessageBox.Show("Please select a different line to reassign the tray.", "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                '************************
                i = objMisc.MoveTrayToNewLine(iTray_ID, iPrevWCLocationID, Me.cboLocation.SelectedValue)
                If i > 0 Then
                    MessageBox.Show("Tray is reassigned to the new line.", "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    GetLineTrayAssignedTo()
                    Me.cboLocation.SelectedValue = 0
                End If
            Catch ex As Exception
                MessageBox.Show("Error in frmMoveTray.LoadLocations:: " & ex.Message.ToString, "Move Tray", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
    End Class
End Namespace