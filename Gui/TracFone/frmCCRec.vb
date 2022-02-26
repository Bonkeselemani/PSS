Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone

    Public Class frmCCRec
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _strScreenName As String = "Cell Receiving"
        Private _iMachineCCID As Integer = 0
        Private _iMachineCCGroupID As Integer = 0
        Private _strMachineCCDesc As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
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
        Friend WithEvents btnRec As System.Windows.Forms.Button
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents gbInputData As System.Windows.Forms.GroupBox
        Friend WithEvents lblMainInputName As System.Windows.Forms.Label
        Friend WithEvents lblIMEI As System.Windows.Forms.Label
        Friend WithEvents lblTotalQty As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lblScanTotal As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.gbInputData = New System.Windows.Forms.GroupBox()
            Me.lblTotalQty = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblIMEI = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnRec = New System.Windows.Forms.Button()
            Me.lblMainInputName = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.lblScanTotal = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.gbInputData.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbInputData
            '
            Me.gbInputData.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblScanTotal, Me.Label2, Me.lblTotalQty, Me.Label10, Me.lblIMEI, Me.btnClear, Me.btnRec, Me.lblMainInputName, Me.txtIMEI})
            Me.gbInputData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbInputData.ForeColor = System.Drawing.Color.White
            Me.gbInputData.Location = New System.Drawing.Point(8, 32)
            Me.gbInputData.Name = "gbInputData"
            Me.gbInputData.Size = New System.Drawing.Size(560, 176)
            Me.gbInputData.TabIndex = 1
            Me.gbInputData.TabStop = False
            Me.gbInputData.Text = "Receive Device into Cost Center "
            '
            'lblTotalQty
            '
            Me.lblTotalQty.BackColor = System.Drawing.Color.Black
            Me.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalQty.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalQty.Location = New System.Drawing.Point(424, 32)
            Me.lblTotalQty.Name = "lblTotalQty"
            Me.lblTotalQty.Size = New System.Drawing.Size(96, 48)
            Me.lblTotalQty.TabIndex = 138
            Me.lblTotalQty.Text = "0"
            Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Black
            Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Lime
            Me.Label10.Location = New System.Drawing.Point(424, 16)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(96, 18)
            Me.Label10.TabIndex = 139
            Me.Label10.Text = "DAILY TOTAL"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblIMEI
            '
            Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIMEI.ForeColor = System.Drawing.Color.Blue
            Me.lblIMEI.Location = New System.Drawing.Point(112, 24)
            Me.lblIMEI.Name = "lblIMEI"
            Me.lblIMEI.Size = New System.Drawing.Size(248, 24)
            Me.lblIMEI.TabIndex = 137
            Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnClear
            '
            Me.btnClear.Location = New System.Drawing.Point(288, 96)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(72, 24)
            Me.btnClear.TabIndex = 3
            Me.btnClear.Text = "Clear"
            '
            'btnRec
            '
            Me.btnRec.BackColor = System.Drawing.Color.Green
            Me.btnRec.Location = New System.Drawing.Point(104, 96)
            Me.btnRec.Name = "btnRec"
            Me.btnRec.Size = New System.Drawing.Size(80, 24)
            Me.btnRec.TabIndex = 2
            Me.btnRec.Text = "Receive"
            Me.btnRec.Visible = False
            '
            'lblMainInputName
            '
            Me.lblMainInputName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMainInputName.ForeColor = System.Drawing.Color.White
            Me.lblMainInputName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblMainInputName.Location = New System.Drawing.Point(16, 56)
            Me.lblMainInputName.Name = "lblMainInputName"
            Me.lblMainInputName.Size = New System.Drawing.Size(81, 16)
            Me.lblMainInputName.TabIndex = 135
            Me.lblMainInputName.Text = "IMEI/MEID:"
            Me.lblMainInputName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtIMEI
            '
            Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIMEI.Location = New System.Drawing.Point(104, 56)
            Me.txtIMEI.MaxLength = 20
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(256, 22)
            Me.txtIMEI.TabIndex = 1
            Me.txtIMEI.Text = ""
            '
            'lblScanTotal
            '
            Me.lblScanTotal.BackColor = System.Drawing.Color.Black
            Me.lblScanTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScanTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanTotal.ForeColor = System.Drawing.Color.Lime
            Me.lblScanTotal.Location = New System.Drawing.Point(424, 112)
            Me.lblScanTotal.Name = "lblScanTotal"
            Me.lblScanTotal.Size = New System.Drawing.Size(96, 48)
            Me.lblScanTotal.TabIndex = 140
            Me.lblScanTotal.Text = "0"
            Me.lblScanTotal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Black
            Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Lime
            Me.Label2.Location = New System.Drawing.Point(424, 96)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 18)
            Me.Label2.TabIndex = 141
            Me.Label2.Text = "SCAN TOTAL"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'frmCCRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(608, 285)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbInputData})
            Me.Name = "frmCCRec"
            Me.Text = "frmCCRec"
            Me.gbInputData.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmCCRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                CheckIfMachineTiedToLine()

                Me.lblTotalQty.Text = Generic.GetTodayCCEntryCount(Me._iMachineCCID)

                Me.txtIMEI.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmCCRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************
        Private Function CheckIfMachineTiedToLine() As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim objMisc As New PSS.Data.Buisness.Misc()

            Try
                dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)

                If dt1.Rows.Count = 0 Then
                    MessageBox.Show("Machine does not map to any group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf dt1.Rows(0)("Group_ID") = 0 Then
                    MessageBox.Show("Machine does not map to any group, line and side.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf dt1.Rows(0)("CC_Group_ID") = 0 Then
                    MessageBox.Show("Machine does not map to any cost center.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf dt1.Rows(0)("CC_Group_ID") <> 85 Then
                    MessageBox.Show("Machine does not map to TracFone group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Close()
                    If PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        PSS.Gui.MainWin.MainWin.wrkArea.TabPages.RemoveAt(PSS.Gui.MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf dt1.Rows(0)("Group_ID") <> dt1.Rows(0)("CC_Group_ID") Then
                    MessageBox.Show("Group of line and group of cost center are not the same. Please correct the mapping.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf Me._iMenuCustID > 0 AndAlso Not IsDBNull(dt1.Rows(0)("CCG_CustID")) AndAlso Me._iMenuCustID <> dt1.Rows(0)("CCG_CustID") Then
                    MessageBox.Show("This screen is not designed to work for the current mapped group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf Me._iMenuCustID = 0 Then
                    MessageBox.Show("Customer ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex) Else MainWin.MainWin.wrkArea.TabPages.Clear()
                ElseIf Me._iMenuCustID <> dt1.Rows(0)("CCG_CustID") Then
                    MessageBox.Show("Machine does not map to the selected customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex) Else MainWin.MainWin.wrkArea.TabPages.Clear()
                ElseIf dt1.Rows(0)("wa_id") <> 2 Then
                    MessageBox.Show("Machine does not map to production. Please correct the mapping.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                Else
                    Me._iMachineCCID = dt1.Rows(0)("cc_id")
                    Me._iMachineCCGroupID = dt1.Rows(0)("CC_Group_ID")
                    Me.gbInputData.Text = "Receive Device into Cost Center " & dt1.Rows(0)("CostCenter")
                    _strMachineCCDesc = dt1.Rows(0)("CostCenter")
                End If

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                objMisc = Nothing
            End Try
        End Function

        '******************************************************************
        Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
            Try
                If Me.txtIMEI.Text.Trim.Length > 0 Then Me.btnRec.Visible = True
                If e.KeyCode = Keys.Enter AndAlso Me.txtIMEI.Text.Trim.Length > 0 Then Me.ProcessSN()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Function ProcessSN()
            Dim objRec As PSS.Data.Buisness.TracFone.Receive
            Dim i As Integer
            Dim strNextWrkStation, strDeviceWorkStation As String
            Dim dt As DataTable

            Try
                i = 0 : Me.lblIMEI.Text = "" : strNextWrkStation = "" : strDeviceWorkStation = ""

                objRec = New PSS.Data.Buisness.TracFone.Receive()
                dt = objRec.GetDeviceCostCenterInfo(Me.txtIMEI.Text.Trim)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Device does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf dt.Rows.Count <> 1 Then
                    MessageBox.Show("Device exist more than one in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf IsDBNull(dt.Rows(0)("Group_ID")) = True Then
                    MessageBox.Show("Device does not belong to any group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf dt.Rows(0)("Group_ID") <> Me._iMachineCCGroupID Then
                    MessageBox.Show("Device group and Machine group does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Not IsDBNull(dt.Rows(0)("cc_id")) AndAlso dt.Rows(0)("cc_id") > 0 AndAlso dt.Rows(0)("cc_id") = _iMachineCCID Then
                    MessageBox.Show("Device has already scanned into current cell.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Not IsDBNull(dt.Rows(0)("cc_id")) AndAlso dt.Rows(0)("cc_id") > 0 Then
                    MessageBox.Show("Device belongs to " & dt.Rows(0)("Group_Desc").ToString.ToUpper & " cell " & dt.Rows(0)("cc_desc").ToString.ToUpper & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                Else
                    'Work-station check..
                    strDeviceWorkStation = Generic.GetDeviceCurrentWorkStation(dt.Rows(0)("Device_ID"))
                    If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, strDeviceWorkStation, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    Else
                        i = objRec.ReceiveDeviceIntoCostCenter(Me._iMachineCCID, dt.Rows(0)("Device_ID"), PSS.Core.[Global].ApplicationUser.IDuser)
                        If i > 0 Then
                            Me.lblIMEI.Text = Me.txtIMEI.Text.Trim
                            Me.lblTotalQty.Text = Generic.GetTodayCCEntryCount(Me._iMachineCCID)

                            Me.lblScanTotal.Text = CInt(Me.lblScanTotal.Text) + 1
                            Me.btnRec.Visible = False
                            Me.txtIMEI.Text = ""
                            Me.txtIMEI.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '******************************************************************
        Private Sub btnRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec.Click
            Try
                If Me.txtIMEI.Text.Trim.Length > 0 Then Me.ProcessSN()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Me.lblIMEI.Text = ""
            Me.txtIMEI.Text = ""
            Me.lblScanTotal.Text = "0"
            Me.btnRec.Visible = False
            Me.txtIMEI.Focus()
        End Sub

        '******************************************************************

    End Class
End Namespace