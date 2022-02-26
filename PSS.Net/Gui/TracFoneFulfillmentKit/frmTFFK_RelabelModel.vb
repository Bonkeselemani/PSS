Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_RelabelModel
        Inherits System.Windows.Forms.Form

        Private _objData As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Relabel
        Private _dtDevices As DataTable
        Private _bLoadData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objData = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_Relabel()
            _dtDevices = New DataTable()
            _dtDevices.Columns.Add(New DataColumn("Device_ID", System.Type.GetType("System.Int32")))
            _dtDevices.Columns.Add(New DataColumn("Device_SN", System.Type.GetType("System.String")))
            _dtDevices.Columns.Add(New DataColumn("WI_ID", System.Type.GetType("System.Int32")))
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            _objData = Nothing
            Generic.DisposeDT(_dtDevices)
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
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnDoRelabel As System.Windows.Forms.Button
        Friend WithEvents lblFrom As System.Windows.Forms.Label
        Friend WithEvents chkBoxLabel As System.Windows.Forms.CheckBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtFromModelSN As System.Windows.Forms.TextBox
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblScanQty As System.Windows.Forms.Label
        Friend WithEvents lblLimitQty As System.Windows.Forms.Label
        Friend WithEvents lblWIPQty As System.Windows.Forms.Label
        Friend WithEvents pnlQty As System.Windows.Forms.Panel
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lstConvetToModels As System.Windows.Forms.ListBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lblFromModel As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnDoRelabel = New System.Windows.Forms.Button()
            Me.lblFrom = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.chkBoxLabel = New System.Windows.Forms.CheckBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtFromModelSN = New System.Windows.Forms.TextBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblScanQty = New System.Windows.Forms.Label()
            Me.lblLimitQty = New System.Windows.Forms.Label()
            Me.lblWIPQty = New System.Windows.Forms.Label()
            Me.pnlQty = New System.Windows.Forms.Panel()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lstConvetToModels = New System.Windows.Forms.ListBox()
            Me.lblFromModel = New System.Windows.Forms.Label()
            Me.pnlQty.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnDoRelabel
            '
            Me.btnDoRelabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDoRelabel.ForeColor = System.Drawing.Color.Black
            Me.btnDoRelabel.Location = New System.Drawing.Point(352, 408)
            Me.btnDoRelabel.Name = "btnDoRelabel"
            Me.btnDoRelabel.Size = New System.Drawing.Size(112, 48)
            Me.btnDoRelabel.TabIndex = 0
            Me.btnDoRelabel.Text = "Finish"
            '
            'lblFrom
            '
            Me.lblFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFrom.Location = New System.Drawing.Point(32, 131)
            Me.lblFrom.Name = "lblFrom"
            Me.lblFrom.Size = New System.Drawing.Size(88, 24)
            Me.lblFrom.TabIndex = 144
            Me.lblFrom.Text = "From"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(0, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(144, 32)
            Me.Label2.TabIndex = 157
            Me.Label2.Text = "Relabeling"
            '
            'chkBoxLabel
            '
            Me.chkBoxLabel.Checked = True
            Me.chkBoxLabel.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxLabel.Location = New System.Drawing.Point(352, 368)
            Me.chkBoxLabel.Name = "chkBoxLabel"
            Me.chkBoxLabel.Size = New System.Drawing.Size(120, 40)
            Me.chkBoxLabel.TabIndex = 160
            Me.chkBoxLabel.Text = "Print Label"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(32, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.TabIndex = 161
            Me.Label1.Text = "IMEI:"
            '
            'txtFromModelSN
            '
            Me.txtFromModelSN.Location = New System.Drawing.Point(32, 72)
            Me.txtFromModelSN.Name = "txtFromModelSN"
            Me.txtFromModelSN.Size = New System.Drawing.Size(184, 20)
            Me.txtFromModelSN.TabIndex = 162
            Me.txtFromModelSN.Text = ""
            '
            'btnCancel
            '
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(512, 408)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(112, 48)
            Me.btnCancel.TabIndex = 164
            Me.btnCancel.Text = "Cancel / Close"
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(32, 256)
            Me.Label3.Name = "Label3"
            Me.Label3.TabIndex = 165
            Me.Label3.Text = "IMEIs to Convert"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(352, 64)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(32, 23)
            Me.Label4.TabIndex = 167
            Me.Label4.Text = "To:"
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(32, 216)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(184, 20)
            Me.txtSN.TabIndex = 169
            Me.txtSN.Text = ""
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(32, 200)
            Me.Label5.Name = "Label5"
            Me.Label5.TabIndex = 168
            Me.Label5.Text = "IMEI:"
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(112, 8)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(64, 23)
            Me.Label6.TabIndex = 170
            Me.Label6.Text = "WIP QTY:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(8, 8)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(64, 23)
            Me.Label9.TabIndex = 172
            Me.Label9.Text = "Limit QTY:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblScanQty
            '
            Me.lblScanQty.Location = New System.Drawing.Point(152, 256)
            Me.lblScanQty.Name = "lblScanQty"
            Me.lblScanQty.Size = New System.Drawing.Size(64, 23)
            Me.lblScanQty.TabIndex = 174
            Me.lblScanQty.Text = "999"
            Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'lblLimitQty
            '
            Me.lblLimitQty.Location = New System.Drawing.Point(80, 8)
            Me.lblLimitQty.Name = "lblLimitQty"
            Me.lblLimitQty.Size = New System.Drawing.Size(40, 23)
            Me.lblLimitQty.TabIndex = 177
            Me.lblLimitQty.Text = "999"
            Me.lblLimitQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWIPQty
            '
            Me.lblWIPQty.Location = New System.Drawing.Point(184, 8)
            Me.lblWIPQty.Name = "lblWIPQty"
            Me.lblWIPQty.Size = New System.Drawing.Size(32, 23)
            Me.lblWIPQty.TabIndex = 178
            Me.lblWIPQty.Text = "999"
            Me.lblWIPQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlQty
            '
            Me.pnlQty.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.lblWIPQty, Me.lblLimitQty, Me.Label6})
            Me.pnlQty.Location = New System.Drawing.Point(414, 61)
            Me.pnlQty.Name = "pnlQty"
            Me.pnlQty.Size = New System.Drawing.Size(216, 32)
            Me.pnlQty.TabIndex = 179
            Me.pnlQty.Visible = False
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(32, 280)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(184, 212)
            Me.lstDevices.TabIndex = 180
            '
            'lstConvetToModels
            '
            Me.lstConvetToModels.Location = New System.Drawing.Point(352, 88)
            Me.lstConvetToModels.Name = "lstConvetToModels"
            Me.lstConvetToModels.Size = New System.Drawing.Size(268, 264)
            Me.lstConvetToModels.TabIndex = 181
            '
            'lblFromModel
            '
            Me.lblFromModel.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lblFromModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblFromModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFromModel.Location = New System.Drawing.Point(32, 152)
            Me.lblFromModel.Name = "lblFromModel"
            Me.lblFromModel.Size = New System.Drawing.Size(184, 24)
            Me.lblFromModel.TabIndex = 182
            Me.lblFromModel.Text = "TFSAS327VCPAP7"
            Me.lblFromModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmTFFK_RelabelModel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightBlue
            Me.ClientSize = New System.Drawing.Size(728, 526)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFromModel, Me.lstConvetToModels, Me.lstDevices, Me.pnlQty, Me.lblScanQty, Me.txtSN, Me.Label5, Me.Label4, Me.Label3, Me.btnCancel, Me.txtFromModelSN, Me.Label1, Me.chkBoxLabel, Me.Label2, Me.lblFrom, Me.btnDoRelabel})
            Me.Name = "frmTFFK_RelabelModel"
            Me.Text = "Relabe lModel"
            Me.pnlQty.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************************************************
        Private Sub frmTFFK_RelabelModel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ClearGUI()
            Me.lstDevices.DataSource = _dtDevices.DefaultView
            Me.lstDevices.ValueMember = _dtDevices.Columns("Device_ID").ToString
            Me.lstDevices.DisplayMember = _dtDevices.Columns("Device_SN").ToString
            Me.txtFromModelSN.Focus()
        End Sub

        '******************************************************************************************************
        Private Sub ClearGUI()
            Me.txtFromModelSN.Enabled = True
            Me.txtFromModelSN.Text = String.Empty
            Me.txtFromModelSN.Enabled = True
            Me.txtSN.Text = String.Empty

            Me.lblFromModel.Text = String.Empty
            Me.lblFromModel.Tag = String.Empty
            Me.lstConvetToModels.Enabled = True
            Me.lstConvetToModels.DataSource = Nothing
            Me.lstConvetToModels.Items.Clear()
            Me.lstConvetToModels.Refresh()

            Me._dtDevices.Rows.Clear()
            Me.lstDevices.Refresh()

            Me.pnlQty.Visible = False
            Me.lblLimitQty.Text = "0"
            Me.lblWIPQty.Text = "0"
            Me.lblScanQty.Text = String.Empty

            Me.btnDoRelabel.Enabled = False
        End Sub

        '******************************************************************************************************
        Private Sub txtFromModelSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFromModelSN.KeyUp
            Dim dtSN As DataTable
            Dim iWIPQty As Integer = 0
            Dim dtAvalModels As DataTable

            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtFromModelSN.Text.Trim.Length > 0 Then
                    dtSN = Me._objData.GetDeviceSNInWIP(Me.txtFromModelSN.Text.Trim)

                    If dtSN.Rows.Count > 1 Then
                        MsgBox("This device existed twice in the system. Please contact IT.", MsgBoxStyle.Information, "Information")
                        Me.txtFromModelSN.SelectAll()
                        Exit Sub
                    ElseIf dtSN.Rows.Count = 0 Then
                        MsgBox("This device does not exist in the system.", MsgBoxStyle.Information, "Information")
                        Me.txtFromModelSN.SelectAll()
                        Exit Sub
                    Else
                        Me.lblFromModel.Text = dtSN.Rows(0)("Model_Desc")
                        Me.lblFromModel.Tag = Convert.ToUInt32(dtSN.Rows(0)("Model_ID")).ToString()

                        _bLoadData = True

                        dtAvalModels = Me._objData.GetAvailableModelsToConvert(Convert.ToUInt32(dtSN.Rows(0)("Model_ID")).ToString())
                        Me.lstConvetToModels.DataSource = dtAvalModels.DefaultView
                        Me.lstConvetToModels.ValueMember = dtAvalModels.Columns("To_Model_ID").ToString
                        Me.lstConvetToModels.DisplayMember = dtAvalModels.Columns("To Model").ToString
                        _bLoadData = False

                        LoadQty()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Generic.DisposeDT(dtSN) : Generic.DisposeDT(dtAvalModels)
                _bLoadData = False
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub lstConvetToModels_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstConvetToModels.SelectedValueChanged
            Try
                If Not _bLoadData AndAlso Not IsNothing(Me.lstConvetToModels.DataSource) AndAlso Me.lstConvetToModels.SelectedIndex >= 0 Then
                    LoadQty()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        ''******************************************************************************************************
        Private Sub LoadQty()
            Try
                Dim R1 As DataRowView = Me.lstConvetToModels.SelectedItem
                Me.pnlQty.Visible = True
                Me.lblLimitQty.Text = R1("Qty_Limit").ToString()
                Me.lblWIPQty.Text = Me._objData.GetWIPJobQty(R1("To_Model_ID").ToString())
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Dim sSN As String = Me.txtSN.Text.Trim
            Dim dtDevice As DataTable

            Try
                If e.KeyCode = Keys.Enter AndAlso sSN.Length > 0 Then
                    If IsNothing(Me.lstConvetToModels.DataSource) OrElse Me.lstConvetToModels.SelectedIndex < 0 Then
                        MessageBox.Show("Please select convert to model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSN.SelectAll()
                    ElseIf Me._dtDevices.Select("Device_SN = '" & sSN & "'").Length > 0 Then
                        MessageBox.Show("This device is already scanned in. Try another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSN.SelectAll()
                    ElseIf (Me.lblScanQty.Text.Length > 0 AndAlso (Convert.ToInt32(Me.lblScanQty.Text) + Convert.ToInt32(Me.lblWIPQty.Text)) >= Convert.ToInt32(Me.lblLimitQty.Text)) _
                            OrElse Convert.ToInt32(Me.lblWIPQty.Text) >= Convert.ToInt32(Me.lblLimitQty.Text) Then
                        MessageBox.Show("You have reached the limit qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtSN.SelectAll()
                    Else
                        Dim R1 As DataRowView = Me.lstConvetToModels.SelectedItem
                        If Not IsNothing(R1) Then
                            dtDevice = Me._objData.GetDeviceSNInWIP(sSN)
                            If dtDevice.Rows.Count > 1 Then
                                MsgBox("This device existed twice in the system. Please contact IT.", MsgBoxStyle.Information, "Information")
                                Me.txtSN.SelectAll()
                            ElseIf dtDevice.Rows.Count = 0 Then
                                MsgBox("This device does not exist in the system.", MsgBoxStyle.Information, "Information")
                                Me.txtSN.SelectAll()
                            ElseIf dtDevice.Rows(0)("Model_ID").ToString() <> Me.lblFromModel.Tag Then
                                MsgBox("This device does not have the same model as from model.", MsgBoxStyle.Information, "Information")
                                Me.txtSN.SelectAll()
                            ElseIf dtDevice.Rows(0)("Model_ID").ToString() = R1("To_Model_ID").ToString() Then
                                MsgBox("This device has the same model as convert to model.", MsgBoxStyle.Information, "Information")
                                Me.txtSN.SelectAll()
                            Else
                                Me.Enabled = False

                                Dim drNew As DataRow
                                drNew = Me._dtDevices.NewRow
                                drNew.BeginEdit()
                                drNew("Device_ID") = dtDevice.Rows(0)("Device_ID")
                                drNew("Device_SN") = dtDevice.Rows(0)("Device_SN")
                                drNew("WI_ID") = dtDevice.Rows(0)("WI_ID")
                                drNew.EndEdit()
                                Me._dtDevices.Rows.Add(drNew)

                                Me.lblScanQty.Text = Me._dtDevices.Rows.Count

                                Me.txtFromModelSN.Enabled = False
                                Me.lstConvetToModels.Enabled = False
                                Me.btnDoRelabel.Enabled = True

                                Me.txtSN.Text = String.Empty
                                Me.txtSN.Focus()
                            End If
                        Else
                            MessageBox.Show("Can't define convert to model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If 'Check if user select convert to model                        

                    End If 'Check for duplicate
                End If 'Check for enter key
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Me.Enabled = True
            End Try
        End Sub

        '******************************************************************************************************
        Private Sub btnDoRelabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoRelabel.Click

            Try

                If IsNothing(Me.lstConvetToModels.DataSource) OrElse Me.lstConvetToModels.SelectedIndex < 0 Then
                    MessageBox.Show("Please select convert to model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtFromModelSN.SelectAll()
                ElseIf (Me._dtDevices.Rows.Count + Convert.ToInt32(Me.lblWIPQty.Text)) > Convert.ToInt32(Me.lblLimitQty.Text) Then
                    MessageBox.Show("You have scanned more than the limit qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtFromModelSN.SelectAll()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    Dim R1 As DataRowView = Me.lstConvetToModels.SelectedItem
                    If Not IsNothing(R1) Then
                        Dim i As Integer = Me._objData.UpdateRelabel(Me._dtDevices, Convert.ToInt32(Me.lblFromModel.Tag), Convert.ToInt32(R1("To_Model_ID")), PSS.Core.Global.ApplicationUser.IDuser)

                        Cursor.Current = Cursors.Default
                        Me.Enabled = True

                        If i > 0 Then
                            'Tommy20180508
                            GenerateSerialLabelFile()

                            MessageBox.Show("Completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        Me.ClearGUI()
                        Me.txtFromModelSN.Focus()
                    Else
                        MessageBox.Show("Can't define convert to model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If 'Check if user select convert to model     
                End If



            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        'Tommy20180508
        Private Sub GenerateSerialLabelFile()

            Dim iIndex As Integer
            Dim strRelabel As String = String.Empty
            Dim item As String
            Dim item2 As String

            Dim rowView As DataRowView

            'First row in the label text file is headers
            strRelabel = "1-Item Number,2-Serial Number" & vbCrLf

            For Each rowView In lstConvetToModels.SelectedItems
                item2 = rowView("To Model")
            Next


            For Each rowView In lstDevices.Items
                item = rowView("Device_SN")
                strRelabel = strRelabel & item2 & "," & item & vbCrLf
            Next



            Dim fs As New System.IO.FileStream("\\PHQ-FILE\Public\Dept\BarTender\Integrations\Serial\Serial.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write)
            Dim file As New System.IO.StreamWriter(fs)

            file.Write(strRelabel)
            file.Close()

        End Sub
        '******************************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            ClearGUI()
            Me.txtFromModelSN.Focus()
        End Sub


        '******************************************************************************************************


    End Class
End Namespace