Imports CrystalDecisions.CrystalReports.Engine

Namespace Flashing

    Public Class frmBuildCellShipPallet_LiquidationPhone
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
        Friend WithEvents panelPassDevs As System.Windows.Forms.Panel
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents cmdClosePallet As System.Windows.Forms.Button
        Friend WithEvents btnClearAll As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblPalletName As System.Windows.Forms.Label
        Friend WithEvents PanelFailDevs As System.Windows.Forms.Panel
        Friend WithEvents lstFailDevices As System.Windows.Forms.ListBox
        Friend WithEvents lstPassDevices As System.Windows.Forms.ListBox
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtPalletName As System.Windows.Forms.TextBox
        Friend WithEvents RadioPass As System.Windows.Forms.RadioButton
        Friend WithEvents RadioFail As System.Windows.Forms.RadioButton
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtModel As System.Windows.Forms.TextBox
        Friend WithEvents txtBoxSN As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.panelPassDevs = New System.Windows.Forms.Panel()
            Me.lstPassDevices = New System.Windows.Forms.ListBox()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cmdClosePallet = New System.Windows.Forms.Button()
            Me.btnClearAll = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.txtBoxSN = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblPalletName = New System.Windows.Forms.Label()
            Me.PanelFailDevs = New System.Windows.Forms.Panel()
            Me.lstFailDevices = New System.Windows.Forms.ListBox()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtModel = New System.Windows.Forms.TextBox()
            Me.RadioFail = New System.Windows.Forms.RadioButton()
            Me.RadioPass = New System.Windows.Forms.RadioButton()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtPalletName = New System.Windows.Forms.TextBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.panelPassDevs.SuspendLayout()
            Me.PanelFailDevs.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'panelPassDevs
            '
            Me.panelPassDevs.BackColor = System.Drawing.Color.LightSteelBlue
            Me.panelPassDevs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPassDevs.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstPassDevices})
            Me.panelPassDevs.Location = New System.Drawing.Point(8, 28)
            Me.panelPassDevs.Name = "panelPassDevs"
            Me.panelPassDevs.Size = New System.Drawing.Size(176, 252)
            Me.panelPassDevs.TabIndex = 95
            '
            'lstPassDevices
            '
            Me.lstPassDevices.Location = New System.Drawing.Point(7, 7)
            Me.lstPassDevices.Name = "lstPassDevices"
            Me.lstPassDevices.Size = New System.Drawing.Size(156, 238)
            Me.lstPassDevices.TabIndex = 0
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(16, 64)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(156, 20)
            Me.txtDevSN.TabIndex = 1
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(16, 47)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(93, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Device SN:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmdClosePallet
            '
            Me.cmdClosePallet.BackColor = System.Drawing.Color.Green
            Me.cmdClosePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdClosePallet.ForeColor = System.Drawing.Color.White
            Me.cmdClosePallet.Location = New System.Drawing.Point(408, 316)
            Me.cmdClosePallet.Name = "cmdClosePallet"
            Me.cmdClosePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.cmdClosePallet.Size = New System.Drawing.Size(148, 33)
            Me.cmdClosePallet.TabIndex = 5
            Me.cmdClosePallet.Text = "CLOSE PALLET"
            '
            'btnClearAll
            '
            Me.btnClearAll.BackColor = System.Drawing.Color.Red
            Me.btnClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearAll.ForeColor = System.Drawing.Color.White
            Me.btnClearAll.Location = New System.Drawing.Point(408, 268)
            Me.btnClearAll.Name = "btnClearAll"
            Me.btnClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClearAll.Size = New System.Drawing.Size(148, 33)
            Me.btnClearAll.TabIndex = 4
            Me.btnClearAll.Text = "REMOVE ALL SNs"
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.Red
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(408, 228)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClear.Size = New System.Drawing.Size(148, 32)
            Me.btnClear.TabIndex = 3
            Me.btnClear.Text = "REMOVE SN"
            '
            'txtBoxSN
            '
            Me.txtBoxSN.Location = New System.Drawing.Point(16, 18)
            Me.txtBoxSN.Name = "txtBoxSN"
            Me.txtBoxSN.Size = New System.Drawing.Size(156, 20)
            Me.txtBoxSN.TabIndex = 0
            Me.txtBoxSN.Text = ""
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(16, 2)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(85, 16)
            Me.Label2.TabIndex = 87
            Me.Label2.Text = "Box SN:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Black
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.Lime
            Me.lblCount.Location = New System.Drawing.Point(232, 32)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(98, 32)
            Me.lblCount.TabIndex = 97
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label3.Location = New System.Drawing.Point(248, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(53, 16)
            Me.Label3.TabIndex = 96
            Me.Label3.Text = "Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPalletName
            '
            Me.lblPalletName.BackColor = System.Drawing.Color.Black
            Me.lblPalletName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPalletName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletName.ForeColor = System.Drawing.Color.Lime
            Me.lblPalletName.Location = New System.Drawing.Point(397, 56)
            Me.lblPalletName.Name = "lblPalletName"
            Me.lblPalletName.Size = New System.Drawing.Size(275, 32)
            Me.lblPalletName.TabIndex = 98
            Me.lblPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PanelFailDevs
            '
            Me.PanelFailDevs.BackColor = System.Drawing.Color.LightSteelBlue
            Me.PanelFailDevs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelFailDevs.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstFailDevices})
            Me.PanelFailDevs.Location = New System.Drawing.Point(200, 28)
            Me.PanelFailDevs.Name = "PanelFailDevs"
            Me.PanelFailDevs.Size = New System.Drawing.Size(176, 252)
            Me.PanelFailDevs.TabIndex = 101
            '
            'lstFailDevices
            '
            Me.lstFailDevices.Location = New System.Drawing.Point(7, 7)
            Me.lstFailDevices.Name = "lstFailDevices"
            Me.lstFailDevices.Size = New System.Drawing.Size(156, 238)
            Me.lstFailDevices.TabIndex = 0
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.SteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelFailDevs, Me.panelPassDevs, Me.Label5, Me.Label6})
            Me.Panel3.Location = New System.Drawing.Point(3, 156)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(389, 292)
            Me.Panel3.TabIndex = 2
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(16, 11)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(99, 16)
            Me.Label5.TabIndex = 102
            Me.Label5.Text = "Passed Units:"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(208, 10)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(99, 16)
            Me.Label6.TabIndex = 104
            Me.Label6.Text = "Failed Units:"
            '
            'Panel4
            '
            Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.txtModel, Me.RadioFail, Me.RadioPass, Me.Label1, Me.txtPalletName})
            Me.Panel4.Location = New System.Drawing.Point(3, 4)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(669, 48)
            Me.Panel4.TabIndex = 0
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(216, 2)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(85, 16)
            Me.Label4.TabIndex = 91
            Me.Label4.Text = "Model:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtModel
            '
            Me.txtModel.Location = New System.Drawing.Point(216, 18)
            Me.txtModel.Name = "txtModel"
            Me.txtModel.Size = New System.Drawing.Size(156, 20)
            Me.txtModel.TabIndex = 1
            Me.txtModel.Text = ""
            '
            'RadioFail
            '
            Me.RadioFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
            Me.RadioFail.Location = New System.Drawing.Point(576, 16)
            Me.RadioFail.Name = "RadioFail"
            Me.RadioFail.Size = New System.Drawing.Size(56, 16)
            Me.RadioFail.TabIndex = 3
            Me.RadioFail.Text = "FAIL"
            '
            'RadioPass
            '
            Me.RadioPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
            Me.RadioPass.Location = New System.Drawing.Point(448, 16)
            Me.RadioPass.Name = "RadioPass"
            Me.RadioPass.Size = New System.Drawing.Size(72, 16)
            Me.RadioPass.TabIndex = 2
            Me.RadioPass.Text = "PASS"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(16, 2)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(85, 16)
            Me.Label1.TabIndex = 87
            Me.Label1.Text = "Pallet Name:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPalletName
            '
            Me.txtPalletName.Location = New System.Drawing.Point(16, 18)
            Me.txtPalletName.Name = "txtPalletName"
            Me.txtPalletName.Size = New System.Drawing.Size(156, 20)
            Me.txtPalletName.TabIndex = 0
            Me.txtPalletName.Text = ""
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBoxSN, Me.lblCount, Me.txtDevSN, Me.Label2, Me.Label3, Me.Label10})
            Me.Panel1.Location = New System.Drawing.Point(3, 56)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(389, 96)
            Me.Panel1.TabIndex = 1
            '
            'frmBuildCellShipPallet_LiquidationPhone
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(704, 685)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.Panel4, Me.Panel3, Me.lblPalletName, Me.btnClearAll, Me.btnClear, Me.cmdClosePallet})
            Me.Name = "frmBuildCellShipPallet_LiquidationPhone"
            Me.Text = "Auto Ship Devices"
            Me.panelPassDevs.ResumeLayout(False)
            Me.PanelFailDevs.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmBuildCellShipPallet_LiquidationPhone_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.txtPalletName.Focus()
        End Sub

        '*************************************************************************
        Private Sub txtPalletName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPalletName.KeyUp
            If e.KeyValue = 13 Then
                If Trim(Me.txtPalletName.Text) = "" Then
                    Exit Sub
                End If
                Me.lblPalletName.Text = UCase(Trim(Me.txtPalletName.Text))
                Me.txtModel.Focus()
            End If
        End Sub

        '*************************************************************************
        Private Sub txtModel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtModel.KeyUp
            If e.KeyValue = 13 Then
                If Trim(Me.txtModel.Text) = "" Then
                    Exit Sub
                End If
                Me.RadioPass.Focus()
            End If
        End Sub

        '*************************************************************************
        Private Sub RadioPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioPass.CheckedChanged
            If Me.RadioPass.Checked = True Then
                Me.lblPalletName.Text = UCase(Trim(Me.txtPalletName.Text))
                Me.panelPassDevs.BackColor = System.Drawing.Color.Green
                Me.PanelFailDevs.BackColor = System.Drawing.Color.LightSteelBlue
                Me.lblCount.Text = Me.lstPassDevices.Items.Count
                Me.txtBoxSN.Focus()
            End If
        End Sub

        '*************************************************************************
        Private Sub RadioFail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioFail.CheckedChanged
            If Me.RadioFail.Checked = True Then
                Me.lblPalletName.Text = UCase(Trim(Me.txtPalletName.Text))
                Me.panelPassDevs.BackColor = System.Drawing.Color.LightSteelBlue
                Me.PanelFailDevs.BackColor = System.Drawing.Color.Green
                Me.lblCount.Text = Me.lstFailDevices.Items.Count
                Me.txtBoxSN.Focus()
            End If
        End Sub

        '*************************************************************************
        Private Sub txtBoxSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxSN.KeyUp
            If e.KeyValue = 13 Then
                Me.BackColor = System.Drawing.Color.SteelBlue

                If Me.RadioPass.Checked = False And Me.RadioFail.Checked = False Then
                    MessageBox.Show("Pallet type is not defined.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If Me.txtBoxSN.Text = "" Then
                    Exit Sub
                Else
                    Me.txtDevSN.Focus()
                End If
            End If
        End Sub

        '*************************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp

            If e.KeyValue = 13 Then

                If Me.txtDevSN.Text = "" Then
                    Exit Sub
                Else
                    'box and dev match
                    If UCase(Trim(Me.txtBoxSN.Text)) = UCase(Trim(Me.txtDevSN.Text)) Then

                        '****************************************
                        'check for duplicate in  pass list box
                        '****************************************
                        If CheckDulp() Then
                            Me.BackColor = System.Drawing.Color.Red
                            MessageBox.Show("SN already scan into pallet.", "Scan Device SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Me.txtBoxSN.Text = ""
                            Me.txtDevSN.Text = ""
                            Me.txtBoxSN.Focus()
                            Exit Sub
                        End If

                        '****************************************
                        'check for duplicate in  pass list box
                        '****************************************
                        If Me.RadioPass.Checked = True Then
                            Me.lstPassDevices.Items.Add(UCase(Trim(Me.txtBoxSN.Text)))
                            Me.lblCount.Text = Me.lstPassDevices.Items.Count
                        ElseIf Me.RadioFail.Checked = True Then
                            Me.lstFailDevices.Items.Add(UCase(Trim(Me.txtBoxSN.Text)))
                            Me.lblCount.Text = Me.lstFailDevices.Items.Count
                        Else
                            MessageBox.Show("Pallet type is not defined.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        End If

                    Else
                        'box and dev does not match
                        MessageBox.Show("Box SN and Device SN doe not match.", "Scan Device SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Me.BackColor = System.Drawing.Color.Red
                    End If

                    'reset control
                    Me.txtBoxSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.txtBoxSN.Focus()
                End If
            End If
        End Sub

        '*************************************************************************
        Private Function CheckDulp() As Boolean
            Dim i As Integer = 0

            If Me.RadioPass.Checked = True Then
                If Me.lstPassDevices.Items.Count = 0 Then
                    Return False
                End If
                For i = 0 To Me.lstPassDevices.Items.Count - 1
                    If UCase(Trim(Me.txtBoxSN.Text)) = Me.lstPassDevices.Items.Item(i) Then
                        Return True
                    End If
                Next i
            ElseIf Me.RadioFail.Checked = True Then
                If Me.lstFailDevices.Items.Count = 0 Then
                    Return False
                End If
                For i = 0 To Me.lstFailDevices.Items.Count - 1
                    If UCase(Trim(Me.txtBoxSN.Text)) = Me.lstFailDevices.Items.Item(i) Then
                        Return True
                    End If
                Next i
            Else
                MessageBox.Show("Pallet type is not defined.", "Check Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

            Return False
        End Function

        '*************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Dim i As Integer
            Dim strSn As String = ""

            Me.txtBoxSN.Focus()

            If Me.RadioPass.Checked = True Then
                If Me.lstPassDevices.Items.Count = 0 Then
                    Exit Sub
                End If
                strSn = UCase(Trim(InputBox("Enter serial number:")))
                If strSn = "" Then
                    Exit Sub
                End If

                Me.lstPassDevices.Items.Remove(strSn)
                Me.lstPassDevices.Refresh()
                Me.lblCount.Text = Me.lstPassDevices.Items.Count

            ElseIf Me.RadioFail.Checked = True Then
                If Me.lstFailDevices.Items.Count = 0 Then
                    Exit Sub
                End If
                strSn = UCase(Trim(InputBox("Enter serial number:")))
                If strSn = "" Then
                    Exit Sub
                End If

                Me.lstFailDevices.Items.Remove(strSn)
                Me.lstPassDevices.Refresh()
                Me.lblCount.Text = Me.lstPassDevices.Items.Count
            Else
                MessageBox.Show("Pallet type is not defined.", "Remove SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End Sub

        '*************************************************************************
        Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
            Me.txtBoxSN.Focus()
            Me.ClearListbox()
        End Sub

        '*************************************************************************
        Private Sub cmdClosePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePallet.Click
            Me.txtBoxSN.Focus()

            'Validate input
            If Me.txtPalletName.Text = "" Then
                MessageBox.Show("Pallet name is not defined.", "Close pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtPalletName.Focus()
                Exit Sub
            End If
            If Me.txtModel.Text = "" Then
                MessageBox.Show("Model is not defined.", "Close pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtModel.Focus()
                Exit Sub
            End If
            If Me.RadioPass.Checked = False And Me.RadioFail.Checked = False Then
                MessageBox.Show("Pallet type is not defined.", "Close pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'print pallet licence
            PrintPalletDeviceCountRpt()

            Me.ClearListbox()
        End Sub
        '*************************************************************************
        Private Sub ClearListbox()
            If Me.RadioPass.Checked = True Then
                If Me.lstPassDevices.Items.Count = 0 Then
                    Exit Sub
                End If
                Me.lstPassDevices.Items.Clear()
                Me.lstPassDevices.Refresh()
                Me.lblCount.Text = Me.lstPassDevices.Items.Count
            ElseIf Me.RadioFail.Checked = True Then
                If Me.lstFailDevices.Items.Count = 0 Then
                    Exit Sub
                End If
                Me.lstFailDevices.Items.Clear()
                Me.lstPassDevices.Refresh()
                Me.lblCount.Text = Me.lstPassDevices.Items.Count
            Else
                MessageBox.Show("Pallet type is not defined.", "Clear list box", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End Sub

        Private Sub PrintPalletDeviceCountRpt()
            'Dim ps As New PrinterSettings()
            'Dim rptApp As New CRAXDRT.Application()
            'Dim rpt As CRAXDRT.Report
            Dim i As Integer = 0
            Dim strRptPath As String = "R:\PSSInet_Reports_Prod\Ship_PalletLabel_FLASHING.rpt"
            Dim objRpt As ReportDocument

            Try
                'ps.DefaultPageSettings.Landscape = True
                objRpt = New ReportDocument()

                With objRpt
                    .Load(strRptPath)
                    .SetParameterValue("pallet name", UCase(Trim(Me.txtPalletName.Text)))
                    .SetParameterValue("model", "Model:" & UCase(Trim(Me.txtModel.Text)) & " *")
                    .SetParameterValue("quantity", "QTY:" & CInt(Trim(Me.lblCount.Text)))

                    If Me.RadioPass.Checked = True Then
                        .SetParameterValue("pallet type", "PASSED")
                    Else
                        .SetParameterValue("pallet type", "FAILED")
                    End If

                    .PrintToPrinter(1, True, 0, 0)
                End With

                'rpt = rptApp.OpenReport(strRptPath)
                'rpt.ParameterFields.GetItemByName("pallet name").AddCurrentValue(UCase(Trim(Me.txtPalletName.Text)))
                'rpt.ParameterFields.GetItemByName("model").AddCurrentValue("Model:" & UCase(Trim(Me.txtModel.Text)) & " *")
                'rpt.ParameterFields.GetItemByName("quantity").AddCurrentValue("QTY:" & CInt(Trim(Me.lblCount.Text)))
                'If Me.RadioPass.Checked = True Then
                '    rpt.ParameterFields.GetItemByName("pallet type").AddCurrentValue("PASSED")
                'Else
                '    rpt.ParameterFields.GetItemByName("pallet type").AddCurrentValue("FAILED")
                'End If
                ''rpt.PrintOut(False, 2)
                'For i = 0 To 1
                '    rpt.PrintOut(False, 1)
                'Next i

            Catch ex As Exception
                MessageBox.Show("" & ex.ToString, "Print Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'Finally
                '    If Not IsNothing(rpt) Then
                '        rpt = Nothing
                '    End If
                '    If Not IsNothing(rptApp) Then
                '        rptApp = Nothing
                '    End If
            End Try
        End Sub


    End Class
End Namespace