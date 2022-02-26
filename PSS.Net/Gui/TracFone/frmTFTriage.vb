Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFone
    Public Class frmTFTriage
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCust_ID As Integer = 0
        Private _objTFTriage As PSS.Data.Buisness.TracFone.TFTestTriage
        Private _dtTriageBox As DataTable
        Private _iLoc_ID As Integer = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID

        Private _dtTriagedDevices As New DataTable()
        Private _bHasTriaged As Boolean = False
        Private _Selected_Disp_ID As Integer = 0
        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._strScreenName = strScreenName
            Me._iMenuCust_ID = iCust_ID
            Me._objTFTriage = New PSS.Data.Buisness.TracFone.TFTestTriage()

            Me._dtTriagedDevices.Columns.Add("Device_ID", GetType(Integer))
            Me._dtTriagedDevices.Columns.Add("Device_SN", GetType(String))
            Me._dtTriagedDevices.Columns.Add("Received_Model_ID", GetType(Integer))
            Me._dtTriagedDevices.Columns.Add("Triaged_Model_ID", GetType(Integer))
            Me._dtTriagedDevices.Columns.Add("Disp_ID", GetType(Integer))
            Me._dtTriagedDevices.Columns.Add("wb_ID_Incoming", GetType(Integer))

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                Me._objTFTriage = Nothing
            End If

            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents txtBoxID As System.Windows.Forms.TextBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblBoxQty As System.Windows.Forms.Label
        Friend WithEvents lblBoxID As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents lblBoxQtyDesc As System.Windows.Forms.Label
        Friend WithEvents lblTriagedQtyDesc As System.Windows.Forms.Label
        Friend WithEvents lblTriagedQty As System.Windows.Forms.Label
        Friend WithEvents btnSOF As System.Windows.Forms.Button
        Friend WithEvents lblSelectedSN As System.Windows.Forms.Label
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents btnNTF As System.Windows.Forms.Button
        Friend WithEvents btnCOS As System.Windows.Forms.Button
        Friend WithEvents btnFUN As System.Windows.Forms.Button
        Friend WithEvents lblShowDispostion As System.Windows.Forms.Label
        Friend WithEvents btnCommitTriaging As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtBoxID = New System.Windows.Forms.TextBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnCommitTriaging = New System.Windows.Forms.Button()
            Me.lblSelectedSN = New System.Windows.Forms.Label()
            Me.btnNTF = New System.Windows.Forms.Button()
            Me.btnCOS = New System.Windows.Forms.Button()
            Me.lblShowDispostion = New System.Windows.Forms.Label()
            Me.btnFUN = New System.Windows.Forms.Button()
            Me.btnSOF = New System.Windows.Forms.Button()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.lblBoxQty = New System.Windows.Forms.Label()
            Me.lblBoxID = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.lblBoxQtyDesc = New System.Windows.Forms.Label()
            Me.lblTriagedQtyDesc = New System.Windows.Forms.Label()
            Me.lblTriagedQty = New System.Windows.Forms.Label()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtBoxID
            '
            Me.txtBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxID.Location = New System.Drawing.Point(96, 24)
            Me.txtBoxID.Name = "txtBoxID"
            Me.txtBoxID.Size = New System.Drawing.Size(416, 26)
            Me.txtBoxID.TabIndex = 0
            Me.txtBoxID.Text = ""
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCommitTriaging, Me.lblSelectedSN, Me.btnNTF, Me.btnCOS, Me.lblShowDispostion, Me.btnFUN, Me.btnSOF})
            Me.Panel1.Location = New System.Drawing.Point(32, 104)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(480, 408)
            Me.Panel1.TabIndex = 1
            '
            'btnCommitTriaging
            '
            Me.btnCommitTriaging.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnCommitTriaging.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCommitTriaging.ForeColor = System.Drawing.Color.White
            Me.btnCommitTriaging.Location = New System.Drawing.Point(232, 336)
            Me.btnCommitTriaging.Name = "btnCommitTriaging"
            Me.btnCommitTriaging.Size = New System.Drawing.Size(184, 56)
            Me.btnCommitTriaging.TabIndex = 22
            Me.btnCommitTriaging.Text = "Complete Triage"
            '
            'lblSelectedSN
            '
            Me.lblSelectedSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelectedSN.Location = New System.Drawing.Point(0, 8)
            Me.lblSelectedSN.Name = "lblSelectedSN"
            Me.lblSelectedSN.Size = New System.Drawing.Size(480, 32)
            Me.lblSelectedSN.TabIndex = 21
            Me.lblSelectedSN.Text = "Label1"
            Me.lblSelectedSN.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'btnNTF
            '
            Me.btnNTF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNTF.Location = New System.Drawing.Point(56, 264)
            Me.btnNTF.Name = "btnNTF"
            Me.btnNTF.Size = New System.Drawing.Size(360, 56)
            Me.btnNTF.TabIndex = 20
            Me.btnNTF.Text = "No Failure Found"
            '
            'btnCOS
            '
            Me.btnCOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCOS.Location = New System.Drawing.Point(56, 192)
            Me.btnCOS.Name = "btnCOS"
            Me.btnCOS.Size = New System.Drawing.Size(360, 56)
            Me.btnCOS.TabIndex = 19
            Me.btnCOS.Text = "Cosmetic Failure"
            '
            'lblShowDispostion
            '
            Me.lblShowDispostion.BackColor = System.Drawing.Color.AliceBlue
            Me.lblShowDispostion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShowDispostion.Location = New System.Drawing.Point(56, 344)
            Me.lblShowDispostion.Name = "lblShowDispostion"
            Me.lblShowDispostion.Size = New System.Drawing.Size(160, 40)
            Me.lblShowDispostion.TabIndex = 18
            Me.lblShowDispostion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnFUN
            '
            Me.btnFUN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFUN.Location = New System.Drawing.Point(56, 120)
            Me.btnFUN.Name = "btnFUN"
            Me.btnFUN.Size = New System.Drawing.Size(360, 56)
            Me.btnFUN.TabIndex = 13
            Me.btnFUN.Text = "Functional Failure"
            '
            'btnSOF
            '
            Me.btnSOF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSOF.Location = New System.Drawing.Point(56, 48)
            Me.btnSOF.Name = "btnSOF"
            Me.btnSOF.Size = New System.Drawing.Size(360, 56)
            Me.btnSOF.TabIndex = 11
            Me.btnSOF.Text = "Software Failure"
            '
            'txtSN
            '
            Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.Location = New System.Drawing.Point(96, 72)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(416, 26)
            Me.txtSN.TabIndex = 2
            Me.txtSN.Text = ""
            '
            'lblBoxQty
            '
            Me.lblBoxQty.BackColor = System.Drawing.Color.Black
            Me.lblBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxQty.ForeColor = System.Drawing.Color.White
            Me.lblBoxQty.Location = New System.Drawing.Point(680, 16)
            Me.lblBoxQty.Name = "lblBoxQty"
            Me.lblBoxQty.Size = New System.Drawing.Size(80, 32)
            Me.lblBoxQty.TabIndex = 3
            Me.lblBoxQty.Text = "0"
            Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBoxID
            '
            Me.lblBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxID.Location = New System.Drawing.Point(32, 24)
            Me.lblBoxID.Name = "lblBoxID"
            Me.lblBoxID.Size = New System.Drawing.Size(64, 24)
            Me.lblBoxID.TabIndex = 4
            Me.lblBoxID.Text = "Box ID:"
            '
            'lblSN
            '
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.Location = New System.Drawing.Point(48, 72)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(48, 24)
            Me.lblSN.TabIndex = 5
            Me.lblSN.Text = "IMEI:"
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.Green
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(536, 432)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(224, 80)
            Me.btnComplete.TabIndex = 6
            Me.btnComplete.Text = "CLOSE BOX"
            '
            'lblBoxQtyDesc
            '
            Me.lblBoxQtyDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxQtyDesc.Location = New System.Drawing.Point(608, 24)
            Me.lblBoxQtyDesc.Name = "lblBoxQtyDesc"
            Me.lblBoxQtyDesc.Size = New System.Drawing.Size(72, 24)
            Me.lblBoxQtyDesc.TabIndex = 7
            Me.lblBoxQtyDesc.Text = "Box Qty:"
            '
            'lblTriagedQtyDesc
            '
            Me.lblTriagedQtyDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTriagedQtyDesc.Location = New System.Drawing.Point(576, 72)
            Me.lblTriagedQtyDesc.Name = "lblTriagedQtyDesc"
            Me.lblTriagedQtyDesc.Size = New System.Drawing.Size(104, 24)
            Me.lblTriagedQtyDesc.TabIndex = 9
            Me.lblTriagedQtyDesc.Text = "Triaged Qty:"
            '
            'lblTriagedQty
            '
            Me.lblTriagedQty.BackColor = System.Drawing.Color.Black
            Me.lblTriagedQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTriagedQty.ForeColor = System.Drawing.Color.White
            Me.lblTriagedQty.Location = New System.Drawing.Point(680, 64)
            Me.lblTriagedQty.Name = "lblTriagedQty"
            Me.lblTriagedQty.Size = New System.Drawing.Size(80, 32)
            Me.lblTriagedQty.TabIndex = 8
            Me.lblTriagedQty.Text = "0"
            Me.lblTriagedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(552, 128)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(200, 277)
            Me.lstDevices.TabIndex = 10
            '
            'frmTFTriage
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(776, 526)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstDevices, Me.lblTriagedQtyDesc, Me.lblTriagedQty, Me.lblBoxQtyDesc, Me.btnComplete, Me.lblSN, Me.lblBoxQty, Me.txtSN, Me.Panel1, Me.txtBoxID, Me.lblBoxID})
            Me.Name = "frmTFTriage"
            Me.Text = "frmTFTriage"
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmTFTriage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                Me.lblBoxQty.Text = 0 : Me.lblTriagedQty.Text = 0
                Me.lblSelectedSN.Text = ""
                Me.Panel1.Enabled = False
                Me.txtSN.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub txtBoxID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxID.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtBoxID.Text.Trim.Length > 0 Then
                    ProcessBox()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                    ProcessSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnSOF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSOF.Click
            Try
                ProcessTriage(PSS.Data.Buisness.TracFone.TFTestTriage.Disp_ID_SOF)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnSOF_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnFUN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFUN.Click
            Try
                ProcessTriage(PSS.Data.Buisness.TracFone.TFTestTriage.Disp_ID_FUN)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnFUN_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCOS.Click
            Try
                ProcessTriage(PSS.Data.Buisness.TracFone.TFTestTriage.Disp_ID_COS)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnCOS_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnNTF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNTF.Click
            Try
                ProcessTriage(PSS.Data.Buisness.TracFone.TFTestTriage.Disp_ID_NTF)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnNTF_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCommitTriaging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommitTriaging.Click
            Dim dtModel As DataTable
            Dim strXModel As String = ""
            Dim iDevice_ID As Integer = 0
            Dim iWB_ID_Incoming As Integer = 0
            Dim iReceived_Model_ID As Integer = 0
            Dim iTriaged_Model_ID As Integer = 0
            Dim strWorkStation = "Triage Box"
            Dim bFoundCorrectModel As Boolean = False
            Dim i As Integer = 0
            Dim rowNew, row As DataRow

            Try
                If Me._bHasTriaged Then
                    If Me._Selected_Disp_ID = 2 OrElse Me._Selected_Disp_ID = 3 OrElse _
                       Me._Selected_Disp_ID = 4 OrElse Me._Selected_Disp_ID = 5 Then

                        strXModel = Me._dtTriageBox.Select("Device_SN ='" & Me.lblSelectedSN.Text.Trim & "'")(0)("Model_Desc")
                        iReceived_Model_ID = Me._dtTriageBox.Select("Device_SN ='" & Me.lblSelectedSN.Text.Trim & "'")(0)("Model_ID")
                        iDevice_ID = Me._dtTriageBox.Select("Device_SN ='" & Me.lblSelectedSN.Text.Trim & "'")(0)("Device_ID")
                        iWB_ID_Incoming = Me._dtTriageBox.Select("Device_SN ='" & Me.lblSelectedSN.Text.Trim & "'")(0)("wb_ID")

                        If Me._Selected_Disp_ID = 5 Then 'NTF
                            iTriaged_Model_ID = iReceived_Model_ID
                            bFoundCorrectModel = True
                        Else
                            dtModel = Me._objTFTriage.GetModelDataForTriage(strXModel, Me._Selected_Disp_ID)

                            If dtModel.Rows.Count = 0 Then
                                MessageBox.Show("Can't find correct model. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                bFoundCorrectModel = False
                            ElseIf dtModel.Rows.Count > 1 Then
                                MessageBox.Show("Found duplicate model. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                bFoundCorrectModel = False
                            Else '=1
                                iTriaged_Model_ID = dtModel.Rows(0).Item("Model_ID")
                                bFoundCorrectModel = True
                            End If
                        End If

                        If bFoundCorrectModel Then
                            'save data
                            i = Me._objTFTriage.InsertUpdateTriageData(iDevice_ID, Me._Selected_Disp_ID, iReceived_Model_ID, iTriaged_Model_ID, iWB_ID_Incoming, _
                                                       0, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"), strWorkStation)
                            'Update binded data
                            For Each row In Me._dtTriagedDevices.Rows
                                If row("Device_ID") = iDevice_ID Then
                                    rowNew = Me._dtTriagedDevices.NewRow
                                    row.BeginEdit()
                                    row("Received_Model_ID") = iReceived_Model_ID
                                    row("Triaged_Model_ID") = iTriaged_Model_ID
                                    row("Disp_ID") = Me._Selected_Disp_ID
                                    row("wb_ID_Incoming") = iWB_ID_Incoming
                                    row.AcceptChanges()
                                    Exit For
                                End If
                            Next
                            Me.lstDevices.DataSource = Me._dtTriagedDevices.DefaultView
                            Me.lstDevices.ValueMember = "Device_ID"
                            Me.lstDevices.DisplayMember = "Device_SN"

                            Me.lblTriagedQty.Text = Me._dtTriagedDevices.Rows.Count

                            Me.lblSelectedSN.ForeColor = Color.Black
                            Me.btnSOF.BackColor = Me.Panel1.BackColor : Me.btnFUN.BackColor = Me.Panel1.BackColor
                            Me.btnCOS.BackColor = Me.Panel1.BackColor : Me.btnNTF.BackColor = Me.Panel1.BackColor
                            Me.lblShowDispostion.Text = "" : Me._bHasTriaged = False
                            Me.Panel1.Enabled = False
                            Me.lblSelectedSN.Text = "" : Me._Selected_Disp_ID = 0


                            Me.txtSN.Enabled = True : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        End If
                    Else
                        MessageBox.Show("Invalid disposition (correct one must be SOF, FUN, COS, or NTF. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnCommitTriaging_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim strDevice_IDs As String = ""
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                If Not Me._dtTriagedDevices.Rows.Count > 0 Then Exit Sub

                If Me._dtTriagedDevices.Rows.Count = Me.lblTriagedQty.Text AndAlso Me._dtTriagedDevices.Rows.Count = Me.lblBoxQty.Text Then
                    For Each row In Me._dtTriagedDevices.Rows
                        If strDevice_IDs.Trim.Length = 0 Then
                            strDevice_IDs = row("device_ID")
                        Else
                            strDevice_IDs &= "," & row("device_ID")
                        End If
                    Next
                    i = Me._objTFTriage.UpdateCompleteTriage(strDevice_IDs)
                    Me._dtTriagedDevices.Rows.Clear() : Me.lstDevices.DataSource = Nothing
                    Me._dtTriageBox = Nothing

                    Me.txtSN.Text = "" : Me.txtSN.Enabled = False
                    Me.lblBoxQty.Text = 0 : Me.lblTriagedQty.Text = 0

                    Me.txtBoxID.Enabled = True : Me.txtBoxID.Text = "" : Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                Else
                    MessageBox.Show("You haven't triaged all devices in the box yet. Can't close it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub ProcessBox()
            Try
                Me.lblBoxQty.Text = 0 : Me.lblTriagedQty.Text = 0 : Me.txtBoxID.Enabled = True
                Me._dtTriageBox = Me._objTFTriage.GetTriageReadyBoxDeviceData(Me._iLoc_ID, Me.txtBoxID.Text.Trim)

                If Me._dtTriageBox.Rows.Count = 0 Then
                    MessageBox.Show("Can't find this box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                Else
                    Dim iModelID As Integer = Me._dtTriageBox.Rows(0).Item("Model_ID")
                    Dim R1 As DataRow
                    For Each R1 In Me._dtTriageBox.Rows
                        If Not iModelID = R1("model_ID") Then
                            MessageBox.Show("Devices don't have the same model in this box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxID.SelectAll() : Me.txtBoxID.Focus()
                            Exit Sub
                        End If
                    Next

                    Me.lblBoxQty.Text = Me._dtTriageBox.Rows.Count
                    Me.txtBoxID.Enabled = False : Me.txtSN.Enabled = True
                    Me.Panel1.Enabled = False
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub ProcessSN()
            Dim strSN As String = ""
            Dim rowNew As DataRow
            Dim iDevice_ID As Integer = 0

            Try
                strSN = Me.txtSN.Text.Trim
                Me.lblSelectedSN.Text = "" : Me.txtSN.Enabled = True
                Me.Panel1.Enabled = False
                Me.lblShowDispostion.Text = ""

                If Not Me._dtTriageBox.Rows.Count > 0 Then
                    MessageBox.Show("Box has no devices. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._dtTriagedDevices.Select("Device_SN ='" & strSN & "'").Length >= 1 Then
                    MessageBox.Show("Found duplicate device '" & strSN & "' in the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                ElseIf Me._dtTriageBox.Select("Device_SN ='" & strSN & "'").Length = 0 Then
                    MessageBox.Show("IMIE '" & strSN & "' is not in the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                Else
                    iDevice_ID = Me._dtTriageBox.Select("Device_SN ='" & strSN & "'")(0)("Device_ID")
                    rowNew = Me._dtTriagedDevices.NewRow
                    rowNew("Device_ID") = iDevice_ID
                    rowNew("Device_SN") = strSN
                    Me._dtTriagedDevices.Rows.Add(rowNew)

                    'Bind data
                    Me.lstDevices.DataSource = Nothing
                    Me.lstDevices.DataSource = Me._dtTriagedDevices.DefaultView
                    Me.lstDevices.ValueMember = "Device_ID"
                    Me.lstDevices.DisplayMember = "Device_SN"

                    Me.lblSelectedSN.Text = strSN : Me.lblSelectedSN.ForeColor = Color.Black
                    Me.txtSN.Text = "" : Me.txtSN.Enabled = False
                    Me.Panel1.Enabled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub ProcessTriage(ByVal iDisp_ID As Integer)
            Try
                Me.lblSelectedSN.ForeColor = Color.Black
                Me.btnSOF.BackColor = Me.Panel1.BackColor : Me.btnFUN.BackColor = Me.Panel1.BackColor
                Me.btnCOS.BackColor = Me.Panel1.BackColor : Me.btnNTF.BackColor = Me.Panel1.BackColor
                Me.lblShowDispostion.Text = ""
                Me._bHasTriaged = False : Me._Selected_Disp_ID = 0

                Select Case iDisp_ID
                    Case PSS.Data.Buisness.TracFone.TFTestTriage.Disp_ID_SOF
                        Me.btnSOF.BackColor = Color.Blue : Me.lblSelectedSN.ForeColor = Color.Blue
                        Me.lblShowDispostion.Text = "SOF" : Me._bHasTriaged = True
                        Me.lblShowDispostion.ForeColor = Color.Blue
                        Me._Selected_Disp_ID = iDisp_ID

                    Case PSS.Data.Buisness.TracFone.TFTestTriage.Disp_ID_FUN
                        Me.btnFUN.BackColor = Color.Blue : Me.lblSelectedSN.ForeColor = Color.Blue
                        Me.lblShowDispostion.Text = "FUN" : Me._bHasTriaged = True
                        Me.lblShowDispostion.ForeColor = Color.Blue
                        Me._Selected_Disp_ID = iDisp_ID

                    Case PSS.Data.Buisness.TracFone.TFTestTriage.Disp_ID_COS
                        Me.btnCOS.BackColor = Color.Blue : Me.lblSelectedSN.ForeColor = Color.Blue
                        Me.lblShowDispostion.Text = "COS" : Me._bHasTriaged = True
                        Me.lblShowDispostion.ForeColor = Color.Blue
                        Me._Selected_Disp_ID = iDisp_ID

                    Case PSS.Data.Buisness.TracFone.TFTestTriage.Disp_ID_NTF
                        Me.btnNTF.BackColor = Color.Blue : Me.lblSelectedSN.ForeColor = Color.Blue
                        Me.lblShowDispostion.Text = "NTF" : Me._bHasTriaged = True
                        Me.lblShowDispostion.ForeColor = Color.Blue
                        Me._Selected_Disp_ID = iDisp_ID

                End Select

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


    End Class
End Namespace