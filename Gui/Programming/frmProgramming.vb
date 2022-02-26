Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]


Namespace Programming

    Public Class frmProgramming
        Inherits System.Windows.Forms.Form

        Private tmpUser As String
        Private tmpID As Integer
        Private mSerialNumber As Long
        Private tmpDeviceID, tmpModelID, tmpManufID, tmpTrayID, tmpCustID, tmpWO As Int32
        Private vManufWrty As Integer = 0
        Private _device As Device = Nothing
        Private _tray As DataTable = Nothing



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
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents txtTray As System.Windows.Forms.TextBox
        Friend WithEvents lblTray As System.Windows.Forms.Label
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents chkNew As System.Windows.Forms.CheckBox
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents chkFLASH As System.Windows.Forms.CheckBox
        Friend WithEvents lblNew As System.Windows.Forms.Label
        Friend WithEvents lblFlash As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.txtTray = New System.Windows.Forms.TextBox()
            Me.lblTray = New System.Windows.Forms.Label()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.chkNew = New System.Windows.Forms.CheckBox()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.chkFLASH = New System.Windows.Forms.CheckBox()
            Me.lblNew = New System.Windows.Forms.Label()
            Me.lblFlash = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerial.Location = New System.Drawing.Point(112, 16)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(136, 20)
            Me.txtSerial.TabIndex = 1
            Me.txtSerial.Text = ""
            '
            'txtTray
            '
            Me.txtTray.BackColor = System.Drawing.SystemColors.Control
            Me.txtTray.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtTray.Location = New System.Drawing.Point(296, 16)
            Me.txtTray.Name = "txtTray"
            Me.txtTray.Size = New System.Drawing.Size(88, 13)
            Me.txtTray.TabIndex = 107
            Me.txtTray.Text = ""
            Me.txtTray.Visible = False
            '
            'lblTray
            '
            Me.lblTray.Location = New System.Drawing.Point(256, 16)
            Me.lblTray.Name = "lblTray"
            Me.lblTray.Size = New System.Drawing.Size(40, 16)
            Me.lblTray.TabIndex = 109
            Me.lblTray.Text = "Tray:"
            Me.lblTray.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblTray.Visible = False
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblDeviceSN.Location = New System.Drawing.Point(16, 16)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(96, 16)
            Me.lblDeviceSN.TabIndex = 108
            Me.lblDeviceSN.Text = "Serial Number:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkNew
            '
            Me.chkNew.Location = New System.Drawing.Point(24, 64)
            Me.chkNew.Name = "chkNew"
            Me.chkNew.Size = New System.Drawing.Size(64, 32)
            Me.chkNew.TabIndex = 2
            Me.chkNew.Text = "NEW"
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClear.Location = New System.Drawing.Point(576, 304)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.TabIndex = 4
            Me.btnClear.Text = "Clear"
            '
            'chkFLASH
            '
            Me.chkFLASH.Location = New System.Drawing.Point(24, 104)
            Me.chkFLASH.Name = "chkFLASH"
            Me.chkFLASH.Size = New System.Drawing.Size(64, 40)
            Me.chkFLASH.TabIndex = 3
            Me.chkFLASH.Text = "FLASH"
            '
            'lblNew
            '
            Me.lblNew.Location = New System.Drawing.Point(96, 64)
            Me.lblNew.Name = "lblNew"
            Me.lblNew.Size = New System.Drawing.Size(200, 32)
            Me.lblNew.TabIndex = 110
            Me.lblNew.Text = "(A checkmark signifies that the device is considered NEW. No check - used)"
            '
            'lblFlash
            '
            Me.lblFlash.Location = New System.Drawing.Point(96, 104)
            Me.lblFlash.Name = "lblFlash"
            Me.lblFlash.Size = New System.Drawing.Size(200, 40)
            Me.lblFlash.TabIndex = 111
            Me.lblFlash.Text = "(A checkmark signifies that the device has been FLASHED. No check - Can NOT be Fl" & _
            "ashed)"
            '
            'frmProgramming
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(664, 341)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFlash, Me.lblNew, Me.chkFLASH, Me.btnClear, Me.chkNew, Me.txtSerial, Me.txtTray, Me.lblTray, Me.lblDeviceSN})
            Me.Name = "frmProgramming"
            Me.Text = "frmProgramming"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmProgramming_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtSerial.Focus()
        End Sub

        Private Sub txtSerial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown


            Dim blnGetData As Boolean

            mSerialNumber = 0

            If e.KeyValue = 13 Then
                txtSerial.Text = UCase(txtSerial.Text)  '//Format serial as all uppercase
                Dim val As Long = Me.verifySerialNumber(txtSerial.Text)
                If val = 0 Then
                    lblTray.Visible = False
                    txtTray.Visible = False
                    txtSerial.Text = ""
                    txtSerial.Focus()
                    Exit Sub
                ElseIf val = 2 Then
                    txtTray.Text = ""
                    lblTray.Visible = True
                    txtTray.Visible = True
                    txtTray.Focus()
                Else
                    mSerialNumber = val
                    txtTray.Text = getTrayID(mSerialNumber)
                    lblTray.Visible = True
                    txtTray.Visible = True

                    '//Get data value
                    If mSerialNumber > 0 Then
                        Dim strSQL As String
                        strSQL = "SELECT * FROM tcellopt WHERE Device_ID = " & mSerialNumber
                        Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
                        Dim r As DataRow
                        Dim xCount As Integer
                        For xCount = 0 To dt.Rows.Count - 1
                            r = dt.Rows(xCount)
                            If r("Cellopt_New") = 1 Then
                                Me.chkNew.Checked = True
                            ElseIf r("Cellopt_New") = 0 Then
                                Me.chkNew.Checked = False
                            End If

                            If r("Cellopt_PTFlash") = 1 Then
                                Me.chkFLASH.Checked = True
                            ElseIf r("Cellopt_PTFlash") = 0 Then
                                Me.chkFLASH.Checked = False
                            End If


                        Next
                    End If
                End If
            End If

        End Sub


        Private Function verifySerialNumber(ByVal mDeviceSN As String) As Long

            Try

                If Len(Trim(mDeviceSN)) > 12 Then
                    Dim rIMEI As DataRow
                    Dim dtIMEI As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("select tdevice.device_id, tdevice.device_sn from tdevice inner join tcellopt on tdevice.device_id = tcellopt.device_id where tcellopt.cellopt_imei = '" & mDeviceSN & "'")
                    If dtIMEI.Rows.Count > 0 Then
                        rIMEI = dtIMEI.Rows(0)
                        txtSerial.Text = rIMEI("Device_SN")
                        Return rIMEI("Device_ID")
                    End If
                End If

                Dim dRec As New PSS.Data.Production.tdevice()
                Dim tRec As DataTable = dRec.GetDataTableBySN(mDeviceSN)
                Dim r As DataRow

                If tRec.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf tRec.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                Else
                    r = tRec.Rows(0)
                    Return r("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            End Try

        End Function

        Private Function getTrayID(ByVal mDeviceID As Long) As Long

            getTrayID = 0

            Try
                Dim dTray As New PSS.Data.Production.tdevice()
                Dim tTray As DataRow = dTray.GetRowByPK(mDeviceID)
                getTrayID = tTray("Tray_ID")
            Catch ex As Exception
                '//will return value of 0 so no coding necessary here
            End Try

        End Function

        Private Sub chkNew_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNew.CheckedChanged

            '//Get data value
            If mSerialNumber > 0 Then
                Dim strSQL As String
                If Me.chkNew.Checked = True Then
                    strSQL = "UPDATE tcellopt SET cellopt_New = 1 WHERE Device_ID = " & mSerialNumber
                Else
                    strSQL = "UPDATE tcellopt SET cellopt_New = 0 WHERE Device_ID = " & mSerialNumber
                End If
                Dim blnDT As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
            Else
                'MsgBox("can not update database no device ID has been defined", MsgBoxStyle.OKOnly)
            End If

        End Sub


        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click


            mSerialNumber = 0
            Me.chkNew.Checked = False
            Me.chkFLASH.Checked = False
            Me.txtSerial.Text = ""
            Me.txtTray.Text = ""
            txtSerial.Focus()

        End Sub

        Private Sub chkFLASH_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFLASH.CheckedChanged

            '//Get data value
            If mSerialNumber > 0 Then
                Dim strSQL As String
                If Me.chkFLASH.Checked = True Then
                    strSQL = "UPDATE tcellopt SET cellopt_PTFlash = 1 WHERE Device_ID = " & mSerialNumber
                Else
                    strSQL = "UPDATE tcellopt SET cellopt_PTFlash = 0 WHERE Device_ID = " & mSerialNumber
                End If
                Dim blnDT As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
            Else
                'MsgBox("can not update database no device ID has been defined", MsgBoxStyle.OKOnly)
            End If

        End Sub

    End Class

End Namespace
