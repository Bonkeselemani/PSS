Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.VV
    Public Class frmVivint_PoRequest
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _objVivint As PSS.Data.Buisness.VV.Vivint
        Private _objVivint_PoRequest As PSS.Data.Buisness.VV.Vivint_PoRequest
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User
        Private _Vivint_custId As Integer = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID
        Private _vivint_LocID As Integer = PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID
#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            Me._strScreenName = strScreenName
            Me._objVivint = New PSS.Data.Buisness.VV.Vivint()
            Me._objVivint_PoRequest = New PSS.Data.Buisness.VV.Vivint_PoRequest()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objVivint = Nothing
                    Me._objVivint_PoRequest = Nothing
                Catch ex As Exception
                End Try
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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents txtPKslip As System.Windows.Forms.TextBox
        Friend WithEvents lstManifest As System.Windows.Forms.ListBox
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents btnCreatePO As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtPKslip = New System.Windows.Forms.TextBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnCreatePO = New System.Windows.Forms.Button()
            Me.lstManifest = New System.Windows.Forms.ListBox()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(24, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 23)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Manifest ID"
            '
            'txtPKslip
            '
            Me.txtPKslip.Location = New System.Drawing.Point(112, 32)
            Me.txtPKslip.Name = "txtPKslip"
            Me.txtPKslip.Size = New System.Drawing.Size(144, 20)
            Me.txtPKslip.TabIndex = 2
            Me.txtPKslip.Text = ""
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCreatePO, Me.txtPKslip, Me.Label1, Me.lstManifest, Me.btnRemoveSN, Me.btnRemoveAllSNs})
            Me.GroupBox1.Location = New System.Drawing.Point(24, 40)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(440, 360)
            Me.GroupBox1.TabIndex = 3
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Manifest Data"
            '
            'btnCreatePO
            '
            Me.btnCreatePO.BackColor = System.Drawing.Color.Green
            Me.btnCreatePO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreatePO.ForeColor = System.Drawing.Color.White
            Me.btnCreatePO.Location = New System.Drawing.Point(112, 320)
            Me.btnCreatePO.Name = "btnCreatePO"
            Me.btnCreatePO.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreatePO.Size = New System.Drawing.Size(240, 32)
            Me.btnCreatePO.TabIndex = 7
            Me.btnCreatePO.Text = "CREATE THE REPORT"
            '
            'lstManifest
            '
            Me.lstManifest.Location = New System.Drawing.Point(112, 56)
            Me.lstManifest.Name = "lstManifest"
            Me.lstManifest.Size = New System.Drawing.Size(144, 251)
            Me.lstManifest.TabIndex = 5
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(264, 32)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveSN.TabIndex = 5
            Me.btnRemoveSN.Text = "REMOVE SN"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(264, 72)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveAllSNs.TabIndex = 6
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            '
            'frmVivint_PoRequest
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSkyBlue
            Me.ClientSize = New System.Drawing.Size(760, 566)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1})
            Me.Name = "frmVivint_PoRequest"
            Me.Text = "frmVivint_PoRequest"
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region
        Private Sub cleanFocus()
            txtPKslip.Text = ""
            txtPKslip.Focus()
        End Sub

        Private Sub txtPKslip_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKslip.KeyUp
            Dim strPkslip_id As String = Trim(txtPKslip.Text)
            Dim dt As New DataTable()
            Dim dt1 As New DataTable()
            If Not IsNumeric(strPkslip_id) Then
                MsgBox("Manifest Must be a Number", MsgBoxStyle.Information, "Manifest Number")
                cleanFocus()
                Exit Sub
            End If

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtPKslip.Text.Trim.Length > 0 Then
                        If Trim(txtPKslip.Text).Length = 0 Then
                            MsgBox("Please, Select Manifest ID ", MsgBoxStyle.Information, "Device Scan")
                            cleanFocus()
                        Else
                            If lstManifest.Items.Contains(strPkslip_id) Then
                                MsgBox("This Manifest Number is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                                cleanFocus()
                                Exit Sub
                            End If
                            dt = _objVivint_PoRequest.CheckPO_Request(strPkslip_id)
                            ' CHECK IF THE MANIFEST HAS BEEN CLOSED 
                            If dt.Rows.Count > 0 AndAlso dt.Rows(0)("SoHeaderID") = 0 Then
                                dt1 = _objVivint_PoRequest.CheckManifest_Scrap(strPkslip_id)
                                If dt1.Rows.Count > 0 AndAlso (dt1.Rows(0)("Model_id") <> 4630 Or dt1.Rows(0)("Model_id") <> 4702) Then
                                    If dt.Rows(0)("PO_Requested") = 0 Then
                                        lstManifest.Items.Add(strPkslip_id)
                                        cleanFocus()
                                    Else
                                        MsgBox("You already sent the Request for this Manifest Number", MsgBoxStyle.Information, "SCRAP")
                                        cleanFocus()
                                    End If
                                Else
                                    MsgBox("You can't request Po for SCRAP or RTV Devices", MsgBoxStyle.Information, "SCRAP")
                                    cleanFocus()
                                End If
                            Else
                                MsgBox(" Shipment has been manifested or doesn't Exist", MsgBoxStyle.Information, "Manifest Number")
                                cleanFocus()
                            End If
                            End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Private Sub btnCreateBoxID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePO.Click
            Dim i As Integer
            Dim strSNList As String
            If lstManifest.Items.Count = 0 Then
                MessageBox.Show("There is no Manifest in The List or The Manifest Number doesn't Exist", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            For i = 0 To lstManifest.Items.Count - 1
                Dim iTempManifest As Integer = lstManifest.Items.Item(i)
                strSNList += "" & iTempManifest & ","
            Next
            Dim strSNUpdated As String = strSNList.Remove(strSNList.Length - 1, 1)
            If _objVivint_PoRequest.PO_RequestVivint(strSNUpdated) = 1 Then
                _objVivint_PoRequest.UpdatePCklist(strSNUpdated, _iUserID)
            End If
            lstManifest.Items.Clear()
            cleanFocus()
        End Sub

        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            If MessageBox.Show("Are you sure you want to remove all Manifest?", "Clear All Manifest", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            lstManifest.Items.Clear()
        End Sub

        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim strManifestNum As String
            strManifestNum = Convert.ToDouble(InputBox("Enter Manifest Number:", "Manifest Number").Trim)
            If (strManifestNum.Trim) = "" Then
                Throw New Exception("Please enter a Manifest Number if you want to remove it from the List.")
            ElseIf lstManifest.Items.Count > 0 AndAlso lstManifest.Items.Contains(strManifestNum) Then

                lstManifest.Items.Remove(strManifestNum)
            Else
                MessageBox.Show("There is no Manifest in The List or The Manifest Number doesn't Exist", "Information ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub lstManifest_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstManifest.SelectedIndexChanged

        End Sub

        Private Sub lstManifest_ValueMemberChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstManifest.ValueMemberChanged
        End Sub

        Private Sub txtPKslip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKslip.TextChanged

        End Sub
    End Class
End Namespace