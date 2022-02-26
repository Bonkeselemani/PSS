Option Explicit On 

Namespace Gui.TracFone
    Public Class frmPreBuff
        Inherits System.Windows.Forms.Form

        Private Const TESTTYPE_ID As Integer = 15
        Private _iMenuCustID As Integer
        Private _strScreenName As String = ""
        Private _objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
        Private _iModelID As Integer = 0
        Private _iOrderID As Integer = 0
        Private _drBuffBillcode As DataRow
     
#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _strScreenName = strScreenName
            Me.lblScreenName.Text = Me._strScreenName

            _objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
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
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents btnCompleted As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtBoxID As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblScanCount As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblBillcode As System.Windows.Forms.Label
        Friend WithEvents btnLanUseOnly As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.btnCompleted = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtBoxID = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblBoxQty = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lblScanCount = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblBillcode = New System.Windows.Forms.Label()
            Me.btnLanUseOnly = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(416, 512)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(152, 24)
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Cancel"
            '
            'lblScreenName
            '
            Me.lblScreenName.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Blue
            Me.lblScreenName.Location = New System.Drawing.Point(120, 8)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(448, 48)
            Me.lblScreenName.TabIndex = 158
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnCompleted
            '
            Me.btnCompleted.BackColor = System.Drawing.Color.Green
            Me.btnCompleted.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCompleted.ForeColor = System.Drawing.Color.White
            Me.btnCompleted.Location = New System.Drawing.Point(416, 448)
            Me.btnCompleted.Name = "btnCompleted"
            Me.btnCompleted.Size = New System.Drawing.Size(152, 24)
            Me.btnCompleted.TabIndex = 3
            Me.btnCompleted.Text = "Complete"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label3.Location = New System.Drawing.Point(120, 74)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 157
            Me.Label3.Text = "WH Box ID:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBoxID
            '
            Me.txtBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxID.Location = New System.Drawing.Point(200, 72)
            Me.txtBoxID.MaxLength = 15
            Me.txtBoxID.Name = "txtBoxID"
            Me.txtBoxID.Size = New System.Drawing.Size(368, 22)
            Me.txtBoxID.TabIndex = 0
            Me.txtBoxID.Text = ""
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label2.Location = New System.Drawing.Point(264, 136)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(48, 16)
            Me.Label2.TabIndex = 156
            Me.Label2.Text = "Model:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxQty
            '
            Me.lblBoxQty.BackColor = System.Drawing.Color.White
            Me.lblBoxQty.ForeColor = System.Drawing.Color.Black
            Me.lblBoxQty.Location = New System.Drawing.Point(200, 136)
            Me.lblBoxQty.Name = "lblBoxQty"
            Me.lblBoxQty.Size = New System.Drawing.Size(48, 22)
            Me.lblBoxQty.TabIndex = 153
            Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label1.Location = New System.Drawing.Point(32, 136)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(160, 16)
            Me.Label1.TabIndex = 154
            Me.Label1.Text = "Box Quantity:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(320, 136)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(248, 22)
            Me.lblModel.TabIndex = 155
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(200, 168)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(176, 20)
            Me.txtDevSN.TabIndex = 1
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(16, 168)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(176, 16)
            Me.Label10.TabIndex = 161
            Me.Label10.Text = "Serial Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(200, 192)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(176, 342)
            Me.lstDevices.TabIndex = 2
            '
            'lblScanCount
            '
            Me.lblScanCount.BackColor = System.Drawing.Color.Black
            Me.lblScanCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScanCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanCount.ForeColor = System.Drawing.Color.Lime
            Me.lblScanCount.Location = New System.Drawing.Point(416, 184)
            Me.lblScanCount.Name = "lblScanCount"
            Me.lblScanCount.Size = New System.Drawing.Size(88, 43)
            Me.lblScanCount.TabIndex = 163
            Me.lblScanCount.Text = "0"
            Me.lblScanCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(416, 168)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(88, 16)
            Me.Label4.TabIndex = 162
            Me.Label4.Text = "Scan Count"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(416, 300)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveAllSNs.TabIndex = 6
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(416, 244)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveSN.TabIndex = 5
            Me.btnRemoveSN.Text = "REMOVE SN"
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label5.Location = New System.Drawing.Point(120, 110)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 16)
            Me.Label5.TabIndex = 165
            Me.Label5.Text = "Bill Code:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBillcode
            '
            Me.lblBillcode.BackColor = System.Drawing.Color.White
            Me.lblBillcode.ForeColor = System.Drawing.Color.Black
            Me.lblBillcode.Location = New System.Drawing.Point(200, 104)
            Me.lblBillcode.Name = "lblBillcode"
            Me.lblBillcode.Size = New System.Drawing.Size(368, 22)
            Me.lblBillcode.TabIndex = 166
            Me.lblBillcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnLanUseOnly
            '
            Me.btnLanUseOnly.BackColor = System.Drawing.Color.Green
            Me.btnLanUseOnly.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLanUseOnly.ForeColor = System.Drawing.Color.White
            Me.btnLanUseOnly.Location = New System.Drawing.Point(696, 448)
            Me.btnLanUseOnly.Name = "btnLanUseOnly"
            Me.btnLanUseOnly.Size = New System.Drawing.Size(152, 24)
            Me.btnLanUseOnly.TabIndex = 167
            Me.btnLanUseOnly.Text = "Don't touch"
            Me.btnLanUseOnly.Visible = False
            '
            'frmPreBuff
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(952, 574)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLanUseOnly, Me.lblBillcode, Me.Label5, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lblScanCount, Me.Label4, Me.txtDevSN, Me.Label10, Me.lstDevices, Me.btnCancel, Me.lblScreenName, Me.btnCompleted, Me.Label3, Me.txtBoxID, Me.Label2, Me.lblBoxQty, Me.Label1, Me.lblModel})
            Me.Name = "frmPreBuff"
            Me.Text = "frmPreBuff"
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************************
        Private Sub frmPreBuff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'Me.btnLanUseOnly.Visible = True

                PSS.Core.Highlight.SetHighLight(Me)
                Me.txtBoxID.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmPreBuff_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me._iModelID = 0 : _iOrderID = 0 : _drBuffBillcode = Nothing
                Me.txtBoxID.Text = ""
                Me.lblBoxQty.Text = ""
                Me.lblModel.Text = ""
                Me.txtDevSN.Text = ""
                Me.lstDevices.Items.Clear()
                Me.lblScanCount.Text = "0"
                Me.txtBoxID.Enabled = True
                Me.lblBillcode.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************
        Private Sub txtBoxID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxID.KeyUp
            Dim dt As DataTable, dtBuffBillcode As DataTable

            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtBoxID.Text.Trim.Length > 0 Then
                    Dim strBoxID As String = Me.txtBoxID.Text.Trim.ToUpper
                    Me.btnCancel_Click(Nothing, Nothing)
                    Me.txtBoxID.Text = strBoxID


                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dt = Me._objTFMisc.GetBoxStationCount(Me.txtBoxID.Text)
                    Me.Enabled = True
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("This Box ID does not exist.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    ElseIf (dt.Rows.Count > 1) Then
                        MessageBox.Show("This Box ID has units of multiple workstation or multiple model.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    ElseIf dt.Rows(0)("Closed").ToString = "0" Then
                        MessageBox.Show("Box is open.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    ElseIf dt.Rows(0)("Model_ID").ToString = "0" Then
                        MessageBox.Show("Model is missing.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    ElseIf dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
                        MessageBox.Show("This Box does not belong to any workstation.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    ElseIf Misc.Triaged_Device(txtBoxID.Text) = False Then
                        MessageBox.Show("This screen does not accept any unit from NTF.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                        'ElseIf Data.Buisness.Generic.IsBillcodeMapped(dt.Rows(0)("Model_ID"), BUFF_BILLCODE_ID) = 0 Then
                        '    MessageBox.Show("'RV_TSP/LCD' billcode is not mapped for this model.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        '    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                    Else
                        dtBuffBillcode = Me._objTFMisc.GetBuffBillcode(CInt(dt.Rows(0)("Model_ID")))
                        If dtBuffBillcode.Rows.Count = 0 Then
                            MessageBox.Show("Billcode is not mapped for this model.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                        ElseIf dtBuffBillcode.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate billcode existed. Please contact material department.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                        Else
                            Me.lblModel.Text = dt.Rows(0)("Model_Desc")
                            Me._iModelID = dt.Rows(0)("Model_ID")
                            Me._iOrderID = dt.Rows(0)("Order_ID")
                            Me.lblBoxQty.Text = dt.Rows(0)("Cnt")
                            Me.txtBoxID.Enabled = False
                            Me._drBuffBillcode = dtBuffBillcode.Rows(0)
                            Me.lblBillcode.Text = dtBuffBillcode.Rows(0)("BillCode_ID") & " - " & dtBuffBillcode.Rows(0)("BillCode_Desc")
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtBoxID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                PSS.Data.Buisness.Generic.DisposeDT(dt) : PSS.Data.Buisness.Generic.DisposeDT(dtBuffBillcode)
            End Try
        End Sub

        '**************************************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Dim dt As DataTable
            Dim iManufWrty As Integer = 0

            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtBoxID.Text.Trim.Length > 0 Then
                    If Me._iModelID = 0 Then Throw New Exception("Box did not pass validation. Please re-scan the box.")
                    If IsNothing(Me._drBuffBillcode) OrElse CInt(_drBuffBillcode("Billcode_ID")) = 0 Then Throw New Exception("Billcode is not mapped.")

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dt = Me._objTFMisc.GetDevicesInWHBox(Me.txtBoxID.Text.Trim, Me._iOrderID, Me.txtDevSN.Text.Trim)
                    Me.Enabled = True : Cursor.Current = Cursors.Default
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Serial number does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                    ElseIf dt.Rows(0)("BoxID").ToString.Trim.ToLower <> Me.txtBoxID.Text.Trim.ToLower Then
                        MessageBox.Show("Serial does not belong to box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                    ElseIf dt.Rows(0)("WorkStation").ToString.Trim.ToLower <> "pre-buff" Then
                        MessageBox.Show("Serial does not belong to Pre-Buff work station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                    Else
                        ''Collect warranty data  for TF customer
                        'If _iMenuCustID = 2258 AndAlso Gui.techscreen.frmNewTech.CollectWarrantyDateCode_Tracfone(CInt(dt.Rows(0)("Device_ID")), CInt(dt.Rows(0)("Manuf_ID")), CInt(dt.Rows(0)("Model_ID")), Me.txtDevSN.Text.Trim, iManufWrty) = False Then
                        '    Exit Sub
                        'End If

                        Me.lstDevices.Items.Add(Me.txtDevSN.Text.Trim)
                        Me.lblScanCount.Text = Me.lstDevices.Items.Count
                        Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************************
        Private Sub btnCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleted.Click
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim iArrListPassBuff As ArrayList
            Dim strNextStation As String = "", strDeviceIDs As String = ""
            Dim objDevice As Rules.Device
            Dim R1 As DataRow
            Dim objNewTech As New Data.Buisness.NewTech()

            Try
                If Me.lstDevices.Items.Count = 0 Then
                    If MessageBox.Show("Are you sure none of the unit can be pre-buff?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                End If

                Me.Enabled = False : Me.Cursor.Current = Cursors.WaitCursor
                dt = Me._objTFMisc.GetDevicesInWHBox(Me.txtBoxID.Text.Trim, Me._iOrderID)
                If dt.Select("WorkStation <> 'PRE-BUFF'").Length > 0 Then
                    MessageBox.Show("Serial '" & dt.Select("WorkStation <> 'PRE-BUFF'")(0)("SN") & "' does not belong to Pre-Buff work station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf IsNothing(Me._drBuffBillcode) OrElse CInt(_drBuffBillcode("Billcode_ID")) = 0 Then
                    MessageBox.Show("Bill code is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    iArrListPassBuff = New ArrayList()
                    strNextStation = Data.Buisness.Generic.GetNextWorkStationInWFP(_strScreenName, 0, Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                    If strNextStation.Trim.Length = 0 Then Throw New Exception("System can't determine next work station.")

                    '1: Validate if serial # in box and get list of device passed pre-buff
                    For i = 0 To Me.lstDevices.Items.Count - 1
                        If dt.Select("SN = '" & Me.lstDevices.Items(i) & "'").Length = 0 Then
                            MessageBox.Show("Serial '" & Me.lstDevices.Items(i) & "' does not belong to box '" & Me.txtBoxID.Text.Trim & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        Else
                            iArrListPassBuff.Add(dt.Select("SN = '" & Me.lstDevices.Items(i) & "'")(0)("Device_ID"))
                        End If
                    Next i

                    '2: Bill pre-buff 
                    For Each R1 In dt.Rows
                        If Not IsNothing(iArrListPassBuff) AndAlso iArrListPassBuff.IndexOf(R1("Device_ID")) >= 0 Then
                            If Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), CInt(_drBuffBillcode("Billcode_ID"))) = False Then
                                objDevice = New Rules.Device(R1("Device_ID"))
                                objDevice.AddPart(CInt(_drBuffBillcode("Billcode_ID")))
                                'COMMENT THIS BECUASE WE DON'T HAVE WARRANTY DATE CODE YET ( TODD REQUEST THIS ON 11/13/2014
                                'objDevice.Update()
                                objDevice.Dispose() : objDevice = Nothing
                            End If
                            'remove from pre-eval
                            objNewTech.DeleteDeviceBillAWAP(CInt(R1("Device_ID")), CInt(_drBuffBillcode("Billcode_ID")))
                        Else
                            If Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), CInt(_drBuffBillcode("Billcode_ID"))) = True Then
                                objDevice = New Rules.Device(R1("Device_ID"))
                                objDevice.DeletePart(CInt(_drBuffBillcode("Billcode_ID")))
                                'COMMENT THIS BECUASE WE DON'T HAVE WARRANTY DATE CODE YET ( TODD REQUEST THIS ON 11/13/2014
                                'objDevice.Update()
                                objDevice.Dispose() : objDevice = Nothing
                            End If
                            'Add to pre-eval
                            If Data.Buisness.Generic.IsBillcodeExistedInAWAP(CInt(R1("Device_ID")), CInt(_drBuffBillcode("Billcode_ID"))) = False Then
                                objNewTech.InsertIntoDeviceBillAWAP(CInt(R1("Device_ID")), _drBuffBillcode("PSPrice_StndCost"), _drBuffBillcode("PSPrice_AvgCost"), _
                                    CDec(_drBuffBillcode("PSPrice_StndCost")), (CDec(_drBuffBillcode("PSPrice_StndCost")) * 1.15), CInt(_drBuffBillcode("Billcode_ID")), _
                                    _drBuffBillcode("PSPrice_Number"), 1, Core.ApplicationUser.IDuser, 0, 0, 0)
                            End If
                        End If

                        If strDeviceIDs.Trim.Length > 0 Then strDeviceIDs &= ","
                        strDeviceIDs &= R1("Device_ID")
                    Next R1

                    '3: Clean pre-buff record. this should never happen unless some one manually moved the box to pre-buff or system crash. 
                    'We need to have only one transaction per device to give the correct yield.
                    Me._objTFMisc.RemoveTestDataRecords(strDeviceIDs, Me.TESTTYPE_ID)

                    '4: write pre-buff record and push box to next work station
                    i = Me._objTFMisc.SetPreBuff(dt, iArrListPassBuff, Me.txtBoxID.Text.Trim, strNextStation, TESTTYPE_ID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name)

                    If i > 0 Then
                        Me.btnCancel_Click(Nothing, Nothing)
                        Me.Enabled = True : Me.txtBoxID.Select() : Me.txtBoxID.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCompleted_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Data.Buisness.Generic.DisposeDT(dt) : objNewTech = Nothing
            End Try
        End Sub

        '**************************************************************************************
        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim strSN As String = ""

            Try
                strSN = InputBox("Enter serial number:").Trim
                If strSN.Length = 0 Then Exit Sub

                If Me.lstDevices.Items.IndexOf(strSN) < 0 Then
                    MessageBox.Show("Serial number is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me.lstDevices.Items.Remove(Me.lstDevices.Items.IndexOf(strSN))
                    Me.lstDevices.Refresh()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRemoveSN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Try
                Me.lstDevices.Items.Clear() : Me.lstDevices.Refresh()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRemoveSN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************************
        Private Sub btnLanUseOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLanUseOnly.Click
            'Dim dtBuffBillcode, dtData As DataTable
            'Dim R1 As DataRow
            'Dim objNewTech As New Data.Buisness.NewTech()
            'Dim iResult As Integer = 0, i, j As Integer
            'Dim strMissingPreBuffBillcode As String = ""

            'Try
            '    dtData = Me._objTFMisc.GetPreBuffPassedDevice()
            '    For Each R1 In dtData.Rows

            '        iResult = CInt(R1("QCResult_ID"))
            '        dtBuffBillcode = Me._objTFMisc.GetBuffBillcode(CInt(R1("Model_ID")))

            '        If dtBuffBillcode.Rows.Count = 1 Then
            '            If iResult = 1 Then 'passed
            '                'remove from pre-eval
            '                i = objNewTech.DeleteDeviceBillAWAP(CInt(R1("Device_ID")), CInt(dtBuffBillcode.Rows(0)("Billcode_ID")))
            '            Else 'failed
            '                'Add to pre-eval
            '                If Data.Buisness.Generic.IsBillcodeExistedInAWAP(CInt(R1("Device_ID")), CInt(dtBuffBillcode.Rows(0)("Billcode_ID"))) = False Then
            '                    j = objNewTech.InsertIntoDeviceBillAWAP(CInt(R1("Device_ID")), dtBuffBillcode.Rows(0)("PSPrice_StndCost"), dtBuffBillcode.Rows(0)("PSPrice_AvgCost"), _
            '                                                  CDec(dtBuffBillcode.Rows(0)("PSPrice_StndCost")), (CDec(dtBuffBillcode.Rows(0)("PSPrice_StndCost")) * 1.15), CInt(dtBuffBillcode.Rows(0)("Billcode_ID")), _
            '                                                  dtBuffBillcode.Rows(0)("PSPrice_Number"), 1, Core.ApplicationUser.IDuser, 0, 0, 0)
            '                End If
            '            End If
            '        Else
            '            If strMissingPreBuffBillcode.Trim.Length > 0 Then strMissingPreBuffBillcode &= ", "
            '            strMissingPreBuffBillcode &= R1("Device_ID")
            '        End If
            '    Next

            'Catch ex As Exception
            '    MessageBox.Show(ex.Message, "btnLanUseOnly_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    Data.Buisness.Generic.DisposeDT(dtBuffBillcode)
            '    Data.Buisness.Generic.DisposeDT(dtData)
            '    objNewTech = Nothing
            'End Try
        End Sub

        '**************************************************************************************

    End Class
End Namespace