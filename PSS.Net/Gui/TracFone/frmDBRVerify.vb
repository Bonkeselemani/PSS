Option Explicit On 
Imports PSS.Data.Buisness

Namespace Gui.TracFone

    Public Class frmDBRVerify
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
        Private iDevice_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal strScreenName As String = "", _
                       Optional ByVal iCustID As Integer = 0)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

            _strScreenName = strScreenName
            _iMenuCustID = iCustID
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
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnYes As System.Windows.Forms.Button
        Friend WithEvents btnNo As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnYes = New System.Windows.Forms.Button()
            Me.btnNo = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(44, 38)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(248, 20)
            Me.txtDevSN.TabIndex = 1
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(44, 23)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(183, 19)
            Me.Label10.TabIndex = 101
            Me.Label10.Text = "Serial Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnYes
            '
            Me.btnYes.BackColor = System.Drawing.Color.Green
            Me.btnYes.Location = New System.Drawing.Point(24, 23)
            Me.btnYes.Name = "btnYes"
            Me.btnYes.Size = New System.Drawing.Size(88, 30)
            Me.btnYes.TabIndex = 1
            Me.btnYes.Text = "Yes"
            '
            'btnNo
            '
            Me.btnNo.BackColor = System.Drawing.Color.Green
            Me.btnNo.Location = New System.Drawing.Point(144, 23)
            Me.btnNo.Name = "btnNo"
            Me.btnNo.Size = New System.Drawing.Size(88, 30)
            Me.btnNo.TabIndex = 2
            Me.btnNo.Text = "No"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnNo, Me.btnYes})
            Me.GroupBox1.Enabled = False
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(44, 76)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(252, 68)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Is BER?"
            '
            'frmDBRVerify
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(352, 213)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.txtDevSN, Me.Label10})
            Me.Name = "frmDBRVerify"
            Me.Text = "frmDBRVerify"
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*******************************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Dim dt1 As DataTable

            Try
                If e.KeyValue = 13 Then
                    If Me.txtDevSN.Text.Trim.Length = 0 Then Exit Sub

                    dt1 = Generic.GetDeviceInfoInWIP(Trim(Me.txtDevSN.Text), Me._iMenuCustID)

                    If dt1.Rows.Count > 0 Then
                        If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                            If dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> Me._strScreenName.Trim.ToUpper Then
                                MessageBox.Show("The device belongs to " & dt1.Rows(0)("WorkStation").ToString & ".", "BER Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.Text = ""
                                Exit Sub
                            End If
                        End If
                        iDevice_ID = dt1.Rows(0)("Device_id")
                        Me.GroupBox1.Enabled = True
                    Else
                        MessageBox.Show("This device does not exist or missing information.", "BER", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "BER", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
            Dim strNextWrkStation As String = ""
            Dim iStationFailed As Integer = 0

            Try
                strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, iStationFailed)
                If strNextWrkStation.Trim.Length > 0 Then
                    Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, iDevice_ID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )
                    MessageBox.Show("Device has been pushed to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtDevSN.Text = ""
                    Me.iDevice_ID = 0
                    Me.txtDevSN.Focus()
                Else
                    MessageBox.Show("Can't define next workstation for this screen.", "btnYes_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "btnYes_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
            Dim strNextWrkStation As String = ""
            Dim iStationFailed As Integer = 1
            Try
                strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, iStationFailed)
                If strNextWrkStation.Trim.Length > 0 Then
                    Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, iDevice_ID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )
                    MessageBox.Show("Device has been pushed to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtDevSN.Text = ""
                    Me.iDevice_ID = 0
                    Me.txtDevSN.Focus()
                Else
                    MessageBox.Show("Can't define next workstation for this screen.", "btnNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "btnYes_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*******************************************************************************


    End Class
End Namespace