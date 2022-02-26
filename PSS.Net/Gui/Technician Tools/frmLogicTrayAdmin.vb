Namespace LogicalTray


    Public Class frmLogicTrayAdmin
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
        Friend WithEvents lblMain As System.Windows.Forms.Label
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents lblDetail As System.Windows.Forms.Label
        Friend WithEvents btnReleaseOwnership As System.Windows.Forms.Button
        Friend WithEvents txtOwner As System.Windows.Forms.TextBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnCompleteTray As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLogicTrayAdmin))
            Me.lblMain = New System.Windows.Forms.Label()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.lblDetail = New System.Windows.Forms.Label()
            Me.btnReleaseOwnership = New System.Windows.Forms.Button()
            Me.txtOwner = New System.Windows.Forms.TextBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnCompleteTray = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblMain
            '
            Me.lblMain.BackColor = System.Drawing.Color.Transparent
            Me.lblMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMain.Location = New System.Drawing.Point(8, 8)
            Me.lblMain.Name = "lblMain"
            Me.lblMain.Size = New System.Drawing.Size(392, 23)
            Me.lblMain.TabIndex = 0
            Me.lblMain.Text = "CELLULAR LOGIC TRAY ADMINISTRATION"
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.BackColor = System.Drawing.Color.Transparent
            Me.lblDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceSN.Location = New System.Drawing.Point(64, 56)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(152, 16)
            Me.lblDeviceSN.TabIndex = 1
            Me.lblDeviceSN.Text = "Device Serial Number:"
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceSN.Location = New System.Drawing.Point(216, 50)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(200, 22)
            Me.txtDeviceSN.TabIndex = 2
            Me.txtDeviceSN.Text = ""
            '
            'lblDetail
            '
            Me.lblDetail.BackColor = System.Drawing.Color.Transparent
            Me.lblDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDetail.Location = New System.Drawing.Point(72, 80)
            Me.lblDetail.Name = "lblDetail"
            Me.lblDetail.Size = New System.Drawing.Size(144, 16)
            Me.lblDetail.TabIndex = 3
            Me.lblDetail.Text = "Current Ownership:"
            '
            'btnReleaseOwnership
            '
            Me.btnReleaseOwnership.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReleaseOwnership.Location = New System.Drawing.Point(216, 104)
            Me.btnReleaseOwnership.Name = "btnReleaseOwnership"
            Me.btnReleaseOwnership.Size = New System.Drawing.Size(200, 48)
            Me.btnReleaseOwnership.TabIndex = 4
            Me.btnReleaseOwnership.Text = "RELEASE OWNERSHIP 1 DEVICE"
            '
            'txtOwner
            '
            Me.txtOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtOwner.Location = New System.Drawing.Point(216, 74)
            Me.txtOwner.Name = "txtOwner"
            Me.txtOwner.Size = New System.Drawing.Size(200, 22)
            Me.txtOwner.TabIndex = 5
            Me.txtOwner.Text = ""
            '
            'btnCancel
            '
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.Location = New System.Drawing.Point(216, 232)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(200, 48)
            Me.btnCancel.TabIndex = 6
            Me.btnCancel.Text = "CANCEL"
            '
            'btnCompleteTray
            '
            Me.btnCompleteTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCompleteTray.Location = New System.Drawing.Point(216, 160)
            Me.btnCompleteTray.Name = "btnCompleteTray"
            Me.btnCompleteTray.Size = New System.Drawing.Size(200, 48)
            Me.btnCompleteTray.TabIndex = 7
            Me.btnCompleteTray.Text = "RELEASE OWNERSHIP COMPLETE TRAY"
            Me.btnCompleteTray.Visible = False
            '
            'frmLogicTrayAdmin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Bitmap)
            Me.ClientSize = New System.Drawing.Size(600, 389)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCompleteTray, Me.btnCancel, Me.txtOwner, Me.btnReleaseOwnership, Me.lblDetail, Me.txtDeviceSN, Me.lblDeviceSN, Me.lblMain})
            Me.Name = "frmLogicTrayAdmin"
            Me.Text = "frmLogicTrayAdmin"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Dim vConn As PSS.Data.Production.Joins
        Private intDeviceID As Long = 0
        Private intUserID As Long = 0
        Private intLogicTray As Long = 0

        Private Sub frmLogicTrayAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtOwner.Enabled = False
            txtDeviceSN.Focus()
        End Sub

        Private Sub clearControls()
            intDeviceID = 0
            intUserID = 0
            intLogicTray = 0
            txtDeviceSN.Text = ""
            txtOwner.Text = ""
            txtDeviceSN.Focus()
        End Sub

        Private Function getDeviceID(ByVal mIMEI As String) As Long
            Dim dt As DataTable = vConn.OrderEntrySelect("SELECT Device_ID FROM tdevice WHERE Device_SN = '" & mIMEI & "' AND device_dateship IS NULL")
            If dt.Rows.Count > 0 Then
                Dim r As DataRow
                r = dt.Rows(0)
                Return r("Device_ID")
            Else
                Return 0
            End If
        End Function

        Private Function getLogicalTrayAssignment(ByVal mDeviceID As Long) As String
            intLogicTray = 0
            If mDeviceID > 0 Then
                Dim strSQL As String = "SELECT cellopt_TechAssigned, cellopt_LogicTray FROM tcellopt WHERE device_id = " & mDeviceID
                Dim dt As DataTable = vConn.OrderEntrySelect(strSQL)
                Dim r As DataRow
                If dt.Rows.Count > 0 Then
                    r = dt.Rows(0)
                    If IsDBNull(r("cellopt_TechAssigned")) = True Then
                        Return -1
                    Else
                        Try
                            intLogicTray = r("cellopt_LogicTray")
                        Catch ex As Exception
                            intLogicTray = -1
                        End Try

                        Return r("cellopt_TechAssigned")
                    End If
                End If
            End If

        End Function

        Private Function getTechName(ByVal mUserID As Long) As String
            If intUserID > 0 Then
                Dim strSQL As String = "SELECT user_fullname FROM security.tusers WHERE user_id = " & mUserID
                Dim dt As DataTable = vConn.OrderEntrySelect(strSQL)
                Dim r As DataRow
                If dt.Rows.Count > 0 Then
                    r = dt.Rows(0)
                    If IsDBNull(r("user_fullname")) = True Then
                        Return 0
                    Else
                        Return r("user_fullname")
                    End If
                End If
            End If

        End Function

        Private Sub txtDeviceSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown
            If e.KeyCode = 13 Then
                txtOwner.Text = ""
                '//Get DeviceID
                intDeviceID = getDeviceID(Trim(txtDeviceSN.Text))
                If intDeviceID = 0 Then
                    MsgBox("The IMEI is not valid.", MsgBoxStyle.Critical, "ERROR")
                    clearControls()
                    Exit Sub
                Else
                    '//Get Tech Name
                    intUserID = Me.getLogicalTrayAssignment(intDeviceID)
                    If intUserID > 0 Then
                        Me.txtOwner.Text = Trim(Me.getTechName(intUserID))
                    Else
                        MsgBox("The tray has not been assigned to a technician. CAN NOT CONTINUE.", MsgBoxStyle.Critical, "ERROR")
                        clearControls()
                        Exit Sub
                    End If
                End If
            End If

        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            clearControls()
        End Sub

        Private Sub btnReleaseOwnership_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReleaseOwnership.Click
            If intLogicTray > 0 Then
                Dim blnRelease As Boolean
                'blnRelease = vConn.OrderEntryUpdateDelete("UPDATE tcellopt SET cellopt_TechAssigned = NULL WHERE cellopt_LogicTray = " & intLogicTray)
                '//This is new it will only release a single item
                '//September 29, 2006
                blnRelease = vConn.OrderEntryUpdateDelete("UPDATE tcellopt SET cellopt_TechAssigned = NULL, cellopt_LogicTray = NULL WHERE cellopt_LogicTray = " & intLogicTray & " AND device_id = " & intDeviceID)
                '//This is new it will only release a single item
                '//September 29, 2006
                If blnRelease = True Then
                    MsgBox("Ownership of device " & intDeviceID & " in tray " & intLogicTray & " has been released.", MsgBoxStyle.OKOnly, "COMPLETE")
                    clearControls()
                Else
                    MsgBox("Ownership can was not released, error occurred in module. Contact IT.", MsgBoxStyle.Critical, "ERROR")
                    clearControls()
                End If
            ElseIf intDeviceID > 0 Then
                Dim blnReleaseDevice As Boolean
                blnReleaseDevice = vConn.OrderEntryUpdateDelete("UPDATE tcellopt, tdevice SET cellopt_TechAssigned = NULL, cc_id = null WHERE tdevice.Device_ID = tcellopt.Device_ID AND tdevice.Device_ID = " & intDeviceID)
                If blnReleaseDevice = True Then
                    MsgBox("Ownership of device " & intDeviceID & " has been released.", MsgBoxStyle.OKOnly, "COMPLETE")
                    clearControls()
                Else
                    MsgBox("Ownership can was not released, error occurred in module. Contact IT.", MsgBoxStyle.Critical, "ERROR")
                    clearControls()
                End If
            Else
                MsgBox("Ownership can not be released, the tray number can not be determined. Contact IT.", MsgBoxStyle.Critical, "ERROR")
                clearControls()
                Exit Sub
            End If
        End Sub

        Private Sub btnCompleteTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleteTray.Click
            If intLogicTray > 0 Then
                Dim blnRelease As Boolean
                blnRelease = vConn.OrderEntryUpdateDelete("UPDATE tcellopt SET cellopt_TechAssigned = NULL, cellopt_LogicTray = NULL WHERE cellopt_LogicTray = " & intLogicTray & ";")
                If blnRelease = True Then
                    MsgBox("Ownership of tray " & intLogicTray & " has been released.", MsgBoxStyle.OKOnly, "COMPLETE")
                    clearControls()
                Else
                    MsgBox("Ownership can was not released, error occurred in module. Contact IT.", MsgBoxStyle.Critical, "ERROR")
                    clearControls()
                End If
            ElseIf intDeviceID > 0 Then
                Dim blnReleaseDevice As Boolean
                blnReleaseDevice = vConn.OrderEntryUpdateDelete("UPDATE tcellopt SET cellopt_TechAssigned = NULL WHERE Device_ID = " & intDeviceID)
                If blnReleaseDevice = True Then
                    MsgBox("Ownership of device " & intDeviceID & " has been released.", MsgBoxStyle.OKOnly, "COMPLETE")
                    clearControls()
                Else
                    MsgBox("Ownership can was not released, error occurred in module. Contact IT.", MsgBoxStyle.Critical, "ERROR")
                    clearControls()
                End If
            Else
                MsgBox("Ownership can not be released, the tray number can not be determined. Contact IT.", MsgBoxStyle.Critical, "ERROR")
                clearControls()
                Exit Sub
            End If
        End Sub

    End Class

End Namespace
