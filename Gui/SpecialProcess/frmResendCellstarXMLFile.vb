Public Class frmResendCellstarXMLFile
    Inherits System.Windows.Forms.Form

    Private objCellstarMisc As PSS.Data.Buisness.CellstarMisc

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objCellstarMisc = New PSS.Data.Buisness.CellstarMisc()
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
    Friend WithEvents panelPallet As System.Windows.Forms.Panel
    Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdCreateXML As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.panelPallet = New System.Windows.Forms.Panel()
        Me.txtDevSN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdCreateXML = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panelPallet.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelPallet
        '
        Me.panelPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDevSN, Me.Label10, Me.cmdCreateXML, Me.btnClearAll, Me.btnClear, Me.lstDevices, Me.lblCount, Me.Label3})
        Me.panelPallet.Location = New System.Drawing.Point(8, 10)
        Me.panelPallet.Name = "panelPallet"
        Me.panelPallet.Size = New System.Drawing.Size(340, 313)
        Me.panelPallet.TabIndex = 95
        '
        'txtDevSN
        '
        Me.txtDevSN.Location = New System.Drawing.Point(11, 26)
        Me.txtDevSN.Name = "txtDevSN"
        Me.txtDevSN.Size = New System.Drawing.Size(156, 20)
        Me.txtDevSN.TabIndex = 100
        Me.txtDevSN.Text = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(11, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 16)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Device SN:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCreateXML
        '
        Me.cmdCreateXML.BackColor = System.Drawing.Color.Green
        Me.cmdCreateXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateXML.ForeColor = System.Drawing.Color.White
        Me.cmdCreateXML.Location = New System.Drawing.Point(11, 262)
        Me.cmdCreateXML.Name = "cmdCreateXML"
        Me.cmdCreateXML.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCreateXML.Size = New System.Drawing.Size(157, 42)
        Me.cmdCreateXML.TabIndex = 92
        Me.cmdCreateXML.Text = "Create and Send XML File"
        '
        'btnClearAll
        '
        Me.btnClearAll.BackColor = System.Drawing.Color.Red
        Me.btnClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAll.ForeColor = System.Drawing.Color.White
        Me.btnClearAll.Location = New System.Drawing.Point(180, 142)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClearAll.Size = New System.Drawing.Size(148, 33)
        Me.btnClearAll.TabIndex = 91
        Me.btnClearAll.Text = "REMOVE ALL SNs"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Red
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(180, 103)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(148, 32)
        Me.btnClear.TabIndex = 90
        Me.btnClear.Text = "REMOVE SN"
        '
        'lstDevices
        '
        Me.lstDevices.Location = New System.Drawing.Point(11, 53)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(156, 199)
        Me.lstDevices.TabIndex = 89
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(205, 26)
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
        Me.Label3.Location = New System.Drawing.Point(225, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Count"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmResendCellstarXMLFile
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(360, 334)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panelPallet})
        Me.Name = "frmResendCellstarXMLFile"
        Me.Text = "Resend Brightpoint XMLFiles"
        Me.panelPallet.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If Me.lstDevices.SelectedIndex <> -1 Then    'If nothing is selected
            Me.lstDevices.Items.RemoveAt(Me.lstDevices.SelectedIndex)
            Me.lstDevices.Refresh()
        End If
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        If Me.lstDevices.Items.Count > 0 Then
            Me.lstDevices.Items.Clear()
            Me.lblCount.Text = lstDevices.Items.Count
        End If
    End Sub

    Private Sub cmdCreateXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateXML.Click
        Dim objCellstarMisc As New PSS.Data.Buisness.CellstarMisc()
        Dim i As Integer = 0

        Try
            If Me.lstDevices.Items.Count = 0 Then
                Exit Sub
            End If
            i = objCellstarMisc.CreateAndSendXML(Me.lstDevices)
            MessageBox.Show("File has been created and FTP'd to Brightpoint.")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
        Dim i As Integer = 0

        If e.KeyValue = 13 Then
            Try
                'check for duplicates in list, if exists exit sub
                For i = 0 To Me.lstDevices.Items.Count - 1
                    If Me.lstDevices.Items(i) = Trim(Me.txtDevSN.Text) Then  'UCase(txtDevice.Text) Then
                        MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Customer Specific Shipping")
                        Me.txtDevSN.Text = ""
                        Me.txtDevSN.Text = ""
                        Me.txtDevSN.Focus()
                        Exit Sub
                    End If
                Next

                'Check if device is shipped
                i = objCellstarMisc.CheckIfDevShipped(Trim(Me.txtDevSN.Text))
                If i = 0 Then
                    Throw New Exception(Me.txtDevSN.Text & " was not shipped in the system.")
                End If

                Me.lstDevices.Items.Add(UCase(Trim(Me.txtDevSN.Text)))
                Me.lblCount.Text = lstDevices.Items.Count
                Me.txtDevSN.Text = ""
                Me.txtDevSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                Me.txtDevSN.SelectAll()
            End Try
        End If

    End Sub

    Protected Overrides Sub Finalize()
        objCellstarMisc = Nothing
        MyBase.Finalize()
    End Sub
End Class
