
Namespace Gui.Shipping

    Public Class frmShippingStage
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
        Friend WithEvents lblTrackingNumber As System.Windows.Forms.Label
        Friend WithEvents lblSerialNumber As System.Windows.Forms.Label
        Friend WithEvents txtTrackingNumber As System.Windows.Forms.TextBox
        Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
        Friend WithEvents grpDeviceCount As System.Windows.Forms.GroupBox
        Friend WithEvents lblDeviceCount As System.Windows.Forms.Label
        Friend WithEvents btnShip As System.Windows.Forms.Button
        Friend WithEvents gridSerial As System.Windows.Forms.ListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblTrackingNumber = New System.Windows.Forms.Label()
            Me.lblSerialNumber = New System.Windows.Forms.Label()
            Me.txtTrackingNumber = New System.Windows.Forms.TextBox()
            Me.txtSerialNumber = New System.Windows.Forms.TextBox()
            Me.grpDeviceCount = New System.Windows.Forms.GroupBox()
            Me.lblDeviceCount = New System.Windows.Forms.Label()
            Me.btnShip = New System.Windows.Forms.Button()
            Me.gridSerial = New System.Windows.Forms.ListBox()
            Me.grpDeviceCount.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTrackingNumber
            '
            Me.lblTrackingNumber.Location = New System.Drawing.Point(32, 40)
            Me.lblTrackingNumber.Name = "lblTrackingNumber"
            Me.lblTrackingNumber.Size = New System.Drawing.Size(100, 16)
            Me.lblTrackingNumber.TabIndex = 0
            Me.lblTrackingNumber.Text = "Tracking Number:"
            Me.lblTrackingNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSerialNumber
            '
            Me.lblSerialNumber.Location = New System.Drawing.Point(32, 68)
            Me.lblSerialNumber.Name = "lblSerialNumber"
            Me.lblSerialNumber.Size = New System.Drawing.Size(100, 16)
            Me.lblSerialNumber.TabIndex = 1
            Me.lblSerialNumber.Text = "Serial Number:"
            Me.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTrackingNumber
            '
            Me.txtTrackingNumber.Location = New System.Drawing.Point(144, 36)
            Me.txtTrackingNumber.Name = "txtTrackingNumber"
            Me.txtTrackingNumber.Size = New System.Drawing.Size(184, 20)
            Me.txtTrackingNumber.TabIndex = 1
            Me.txtTrackingNumber.Text = ""
            '
            'txtSerialNumber
            '
            Me.txtSerialNumber.Location = New System.Drawing.Point(144, 64)
            Me.txtSerialNumber.Name = "txtSerialNumber"
            Me.txtSerialNumber.Size = New System.Drawing.Size(184, 20)
            Me.txtSerialNumber.TabIndex = 2
            Me.txtSerialNumber.Text = ""
            '
            'grpDeviceCount
            '
            Me.grpDeviceCount.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDeviceCount})
            Me.grpDeviceCount.Location = New System.Drawing.Point(336, 96)
            Me.grpDeviceCount.Name = "grpDeviceCount"
            Me.grpDeviceCount.Size = New System.Drawing.Size(176, 120)
            Me.grpDeviceCount.TabIndex = 0
            Me.grpDeviceCount.TabStop = False
            Me.grpDeviceCount.Text = "Device Count"
            '
            'lblDeviceCount
            '
            Me.lblDeviceCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceCount.Location = New System.Drawing.Point(16, 24)
            Me.lblDeviceCount.Name = "lblDeviceCount"
            Me.lblDeviceCount.Size = New System.Drawing.Size(148, 88)
            Me.lblDeviceCount.TabIndex = 0
            Me.lblDeviceCount.Text = "99"
            Me.lblDeviceCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnShip
            '
            Me.btnShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnShip.Location = New System.Drawing.Point(336, 320)
            Me.btnShip.Name = "btnShip"
            Me.btnShip.Size = New System.Drawing.Size(176, 56)
            Me.btnShip.TabIndex = 0
            Me.btnShip.Text = "Ship This Tracking Number"
            '
            'gridSerial
            '
            Me.gridSerial.Location = New System.Drawing.Point(144, 96)
            Me.gridSerial.Name = "gridSerial"
            Me.gridSerial.Size = New System.Drawing.Size(184, 277)
            Me.gridSerial.TabIndex = 3
            '
            'frmShippingStage
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(552, 421)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gridSerial, Me.btnShip, Me.grpDeviceCount, Me.txtSerialNumber, Me.txtTrackingNumber, Me.lblSerialNumber, Me.lblTrackingNumber})
            Me.Name = "frmShippingStage"
            Me.Text = "Stage Shipping"
            Me.grpDeviceCount.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private dtDevices As DataTable
        Private rDevices As DataRow
        Private intDeviceCount As Integer


        Private Sub frmShippingStage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            lblDeviceCount.Text = 0
            txtTrackingNumber.Focus()

        End Sub


        Private Function getSerialNumbers(ByVal mTrackNo As String) As DataTable

            If Len(Trim(mTrackNo)) > 0 Then
                Dim strSQL As String = "SELECT StageD_SN FROM tstagedetail WHERE StageD_TrackingNo = '" & mTrackNo & "' AND STageD_DateShipped = '0000-00-00'"
                Dim ds As PSS.Data.Production.Joins
                Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
                If dt.Rows.Count < 1 Then
                    Return Nothing
                    Exit Function
                End If
                intDeviceCount = dt.Rows.Count
                lblDeviceCount.Text = intDeviceCount
                Return dt
            Else
                Return Nothing
            End If

        End Function


        Private Sub txtTrackingNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTrackingNumber.Leave

            If Len(Trim(txtTrackingNumber.Text)) > 0 Then
                dtDevices = getSerialNumbers(Trim(txtTrackingNumber.Text))
                If dtDevices.Rows.Count < 1 Then txtTrackingNumber.Focus()
            Else
                txtTrackingNumber.Focus()
            End If

        End Sub


        Private Sub txtSerialNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerialNumber.KeyDown

            If e.KeyValue = 13 Then

                Dim xCount As Integer = 0
                Dim zCount As Integer = 0
                Dim blnPresent As Boolean = False

                '//Determine if text is in datatable
                For xCount = 0 To dtDevices.Rows.Count - 1
                    rDevices = dtDevices.Rows(xCount)
                    If Trim(rDevices("STageD_SN")) = Trim(txtSerialNumber.Text) Then
                        blnPresent = True

                        '//Check against listbox to see if already listed
                        For zCount = 0 To gridSerial.Items.Count - 1
                            If Trim(gridSerial.Items(zCount)) = Trim(txtSerialNumber.Text) Then
                                blnPresent = False
                            End If
                        Next

                        'dtDevices.Rows(xCount).Delete()
                        '//Add to litbox
                        If blnPresent = True Then
                            gridSerial.Items.Add(Trim(txtSerialNumber.Text))
                            txtSerialNumber.Text = ""
                            txtSerialNumber.Focus()
                            '//decrement counter by 1
                            intDeviceCount -= 1
                            lblDeviceCount.Text = intDeviceCount
                            Exit For
                        Else
                            txtSerialNumber.Text = ""
                            txtSerialNumber.Focus()
                        End If
                    End If
                Next

                If blnPresent = False Then
                    MsgBox("Not In List", MsgBoxStyle.OKOnly)
                    Exit Sub
                End If


            End If

        End Sub

        Private Sub txtTrackingNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrackingNumber.KeyDown
            If e.KeyValue = 13 Then
                txtSerialNumber.Focus()
            End If
        End Sub

        Private Sub txtSerialNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerialNumber.TextChanged

        End Sub

        Private Sub btnShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShip.Click

            Dim xCount As Integer = 0
            Dim vSerial As String = ""
            Dim dr As PSS.Data.Production.Joins
            Dim strSQL As String
            Dim blnUpdate As Boolean

            '//Update data for selecteddevices
            If Len(Trim(txtTrackingNumber.Text)) > 0 Then
                For xCount = 0 To gridSerial.Items.Count - 1
                    vSerial = gridSerial.Items(xCount)
                    strSQL = "UPDATE tstagedetail SET StageD_DateShipped = '" & Gui.Receiving.General.FormatDateShort(Now) & "' WHERE StageD_TrackingNo = '" & Trim(txtTrackingNumber.Text) & "' AND StageD_SN = '" & vSerial & "'"
                    blnUpdate = dr.OrderEntryUpdateDelete(strSQL)
                Next
            End If


        End Sub


    End Class

End Namespace
