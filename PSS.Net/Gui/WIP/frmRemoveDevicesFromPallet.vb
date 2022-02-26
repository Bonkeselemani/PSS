Public Class frmRemoveDevicesFromPallet
    Inherits System.Windows.Forms.Form

    Private objMisc As PSS.Data.Buisness.Misc
    Private iPallet_ID As Integer = 0
    Private iPalletCount As Integer = 0
    'Private iScanCount As Integer = 0

    Private Shared ctl As Control
    Private Shared HighLightColor As Color = Color.Yellow
    Private Shared WindowColor As Color = Color.White
    Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
    Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMisc = New PSS.Data.Buisness.Misc()

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
    Friend WithEvents txtPalletName As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
    Friend WithEvents lblIMEI As System.Windows.Forms.Label
    Friend WithEvents lblPalletName As System.Windows.Forms.Label
    Friend WithEvents pnlFailDevice As System.Windows.Forms.Panel
    Friend WithEvents cmdGo As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveSelectedItem As System.Windows.Forms.Button
    Friend WithEvents lstFailItems As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblScannedQty As System.Windows.Forms.Label
    Friend WithEvents lblPalletCount As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdLicensePlate As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLPPalletName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtPalletName = New System.Windows.Forms.TextBox()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.pnlFailDevice = New System.Windows.Forms.Panel()
        Me.lblScannedQty = New System.Windows.Forms.Label()
        Me.lstFailItems = New System.Windows.Forms.ListBox()
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.txtIMEI = New System.Windows.Forms.TextBox()
        Me.cmdRemoveSelectedItem = New System.Windows.Forms.Button()
        Me.lblPalletName = New System.Windows.Forms.Label()
        Me.cmdGo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPalletCount = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdLicensePlate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLPPalletName = New System.Windows.Forms.TextBox()
        Me.pnlFailDevice.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPalletName
        '
        Me.txtPalletName.BackColor = System.Drawing.Color.White
        Me.txtPalletName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPalletName.Location = New System.Drawing.Point(16, 24)
        Me.txtPalletName.Name = "txtPalletName"
        Me.txtPalletName.Size = New System.Drawing.Size(192, 22)
        Me.txtPalletName.TabIndex = 1
        Me.txtPalletName.Text = ""
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.Color.Black
        Me.cmdUpdate.Location = New System.Drawing.Point(225, 424)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(376, 32)
        Me.cmdUpdate.TabIndex = 8
        Me.cmdUpdate.Text = "UPDATE"
        '
        'pnlFailDevice
        '
        Me.pnlFailDevice.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFailDevice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblScannedQty, Me.lstFailItems, Me.lblIMEI, Me.txtIMEI, Me.cmdRemoveSelectedItem})
        Me.pnlFailDevice.Location = New System.Drawing.Point(225, 72)
        Me.pnlFailDevice.Name = "pnlFailDevice"
        Me.pnlFailDevice.Size = New System.Drawing.Size(376, 344)
        Me.pnlFailDevice.TabIndex = 1
        '
        'lblScannedQty
        '
        Me.lblScannedQty.BackColor = System.Drawing.Color.Black
        Me.lblScannedQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScannedQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScannedQty.ForeColor = System.Drawing.Color.Lime
        Me.lblScannedQty.Location = New System.Drawing.Point(272, 32)
        Me.lblScannedQty.Name = "lblScannedQty"
        Me.lblScannedQty.Size = New System.Drawing.Size(64, 48)
        Me.lblScannedQty.TabIndex = 21
        Me.lblScannedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstFailItems
        '
        Me.lstFailItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFailItems.ItemHeight = 16
        Me.lstFailItems.Location = New System.Drawing.Point(16, 56)
        Me.lstFailItems.Name = "lstFailItems"
        Me.lstFailItems.Size = New System.Drawing.Size(224, 276)
        Me.lstFailItems.TabIndex = 2
        '
        'lblIMEI
        '
        Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIMEI.Location = New System.Drawing.Point(16, 8)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(160, 24)
        Me.lblIMEI.TabIndex = 1
        Me.lblIMEI.Text = "IMEI Number : "
        '
        'txtIMEI
        '
        Me.txtIMEI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(16, 32)
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.Size = New System.Drawing.Size(224, 22)
        Me.txtIMEI.TabIndex = 1
        Me.txtIMEI.Text = ""
        '
        'cmdRemoveSelectedItem
        '
        Me.cmdRemoveSelectedItem.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdRemoveSelectedItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveSelectedItem.ForeColor = System.Drawing.Color.White
        Me.cmdRemoveSelectedItem.Location = New System.Drawing.Point(264, 120)
        Me.cmdRemoveSelectedItem.Name = "cmdRemoveSelectedItem"
        Me.cmdRemoveSelectedItem.Size = New System.Drawing.Size(88, 32)
        Me.cmdRemoveSelectedItem.TabIndex = 3
        Me.cmdRemoveSelectedItem.Text = "CLEAR"
        '
        'lblPalletName
        '
        Me.lblPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalletName.ForeColor = System.Drawing.Color.Black
        Me.lblPalletName.Location = New System.Drawing.Point(16, 8)
        Me.lblPalletName.Name = "lblPalletName"
        Me.lblPalletName.Size = New System.Drawing.Size(88, 16)
        Me.lblPalletName.TabIndex = 7
        Me.lblPalletName.Text = "Pallet Name : "
        '
        'cmdGo
        '
        Me.cmdGo.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGo.ForeColor = System.Drawing.Color.White
        Me.cmdGo.Location = New System.Drawing.Point(216, 24)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.Size = New System.Drawing.Size(48, 24)
        Me.cmdGo.TabIndex = 2
        Me.cmdGo.Text = "GO"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(2, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 136)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "REMOVE DEVICE(S) FROM PALLET"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdGo, Me.lblPalletName, Me.txtPalletName, Me.lblPalletCount})
        Me.Panel1.Location = New System.Drawing.Point(225, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 56)
        Me.Panel1.TabIndex = 1
        '
        'lblPalletCount
        '
        Me.lblPalletCount.BackColor = System.Drawing.Color.Black
        Me.lblPalletCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPalletCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalletCount.ForeColor = System.Drawing.Color.Lime
        Me.lblPalletCount.Location = New System.Drawing.Point(296, 7)
        Me.lblPalletCount.Name = "lblPalletCount"
        Me.lblPalletCount.Size = New System.Drawing.Size(56, 40)
        Me.lblPalletCount.TabIndex = 22
        Me.lblPalletCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdLicensePlate, Me.Label2, Me.txtLPPalletName})
        Me.Panel2.Location = New System.Drawing.Point(2, 146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(222, 102)
        Me.Panel2.TabIndex = 111
        '
        'cmdLicensePlate
        '
        Me.cmdLicensePlate.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdLicensePlate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLicensePlate.ForeColor = System.Drawing.Color.Black
        Me.cmdLicensePlate.Location = New System.Drawing.Point(16, 56)
        Me.cmdLicensePlate.Name = "cmdLicensePlate"
        Me.cmdLicensePlate.Size = New System.Drawing.Size(192, 32)
        Me.cmdLicensePlate.TabIndex = 2
        Me.cmdLicensePlate.Text = "REPRINT PALLET LABEL"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Pallet Name : "
        '
        'txtLPPalletName
        '
        Me.txtLPPalletName.BackColor = System.Drawing.Color.White
        Me.txtLPPalletName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLPPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLPPalletName.Location = New System.Drawing.Point(16, 24)
        Me.txtLPPalletName.Name = "txtLPPalletName"
        Me.txtLPPalletName.Size = New System.Drawing.Size(192, 22)
        Me.txtLPPalletName.TabIndex = 1
        Me.txtLPPalletName.Text = ""
        '
        'frmRemoveDevicesFromPallet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(14, 31)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(696, 525)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2, Me.Panel1, Me.Label1, Me.pnlFailDevice, Me.cmdUpdate})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmRemoveDevicesFromPallet"
        Me.Text = "Remove Devices from Pallet"
        Me.pnlFailDevice.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    '******************************** LAN *************************************
    Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
        Dim strIMEI As String = ""
        Dim dt1 As DataTable

        
        Try
            If e.KeyValue = 13 Then

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                If Me.txtIMEI.Text = "" Then
                    Exit Sub
                End If

                If iPallet_ID = 0 Then
                    MessageBox.Show("frmRemoveDevicesFromPallet.txtIMEI_KeyUp: Pallet Name does not exist.", "Get Device IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtIMEI.Text = ""
                    Me.txtPalletName.Focus()
                    Exit Sub
                Else
                    dt1 = objMisc.GetAllSNsForPallet(iPallet_ID, Trim(Me.txtIMEI.Text))
                    If dt1.Rows.Count = 0 Then
                        MessageBox.Show("Device does not belong to Pallet.", "Get Device IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else

                        'check for duplicate in list box
                        '--------------------------
                        Dim i As Integer = 0
                        Dim flag As Boolean = False
                        For i = 0 To Me.lstFailItems.Items.Count - 1
                            If Trim(Me.txtIMEI.Text) = Me.lstFailItems.Items.Item(i) Then
                                flag = True
                                Exit For
                            End If
                        Next i
                        '--------------------------

                        If flag Then
                            'MessageBox.Show("This Device have been scan already.", "IMEI", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtIMEI.Text = ""
                            Me.txtIMEI.Focus()
                        Else
                            Me.lstFailItems.Items.Add(Trim(Me.txtIMEI.Text))
                            Me.lblScannedQty.Text = Me.lstFailItems.Items.Count
                            Me.txtIMEI.Text = ""
                            Me.txtIMEI.Focus()
                        End If
                    End If 'check device belong to pallet
                End If   'check pallet id

            End If
        Catch ex As Exception
            MessageBox.Show("txtIMEI_KeyUp: " & ex.ToString, "Input IMEI", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    '****************************** LAN ***************************************
    Private Sub txtPalletName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPalletName.KeyUp
        If e.KeyValue = 13 Then
            GetPalletID()
        End If
    End Sub


    '******************************** LAN ************************************
    Private Sub GetPalletID()
        Dim strPalletName As String = ""

        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        If Trim(Me.txtPalletName.Text) = "" Then
            MessageBox.Show("Please enter pallet name.", "Get Pallet ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            strPalletName = Trim(Me.txtPalletName.Text)
            Try
                iPallet_ID = objMisc.GetPalletID(strPalletName)
                If iPallet_ID = 0 Then
                    MessageBox.Show("Pallet Name does not exist.", "Get Pallet ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtPalletName.SelectAll()
                    Me.txtPalletName.Focus()
                Else
                    iPalletCount = objMisc.GetPalletCount(iPallet_ID)
                    Me.lblPalletCount.Text = iPalletCount
                    Me.txtIMEI.Focus()
                End If

            Catch ex As Exception
                ClearAll()
                Me.txtPalletName.Focus()
                MessageBox.Show("frmRemoveDevicesFromPallet.GetPalletID: " & ex.Message.ToString, "Remove Device from Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End If
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    '*************************  LAN  ****************************************
    'take Pallet Name and get Pallet ID from tpallet table
    Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        GetPalletID()
    End Sub


    '********************************* LAN **********************************
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim i As Integer = 0
        Dim strSN As String = ""
        Dim iCurrentWIPOwner As Integer = 0
        Dim iNewPalletCount As Integer = 0

        iNewPalletCount = iPalletCount - Me.lstFailItems.Items.Count

        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        If MessageBox.Show("Are you sure you want to Update?", "Close Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            ClearAll()
            Exit Sub
        End If

        'only AQL can remove device(s) from pallet
        '-------------------------------
        strSN = GetIMEIs()
        iCurrentWIPOwner = objMisc.GetWIPOwner(iPallet_ID, "", 1, 2, strSN)

        If iCurrentWIPOwner = -1 Then
            MessageBox.Show("Device(s) contain multiple WIP Owner. Can not remove.", "Take WIP Ownership", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ClearAll()
            Me.txtPalletName.Focus()
            Exit Sub
        ElseIf iCurrentWIPOwner = 0 Then
            MessageBox.Show("Can not find current WIP Ownership.", "Take WIP Ownership", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ClearAll()
            Me.txtPalletName.Focus()
            Exit Sub
        ElseIf iCurrentWIPOwner <> 6 And iCurrentWIPOwner <> 2 And iCurrentWIPOwner <> 3 And iCurrentWIPOwner <> 9 And iCurrentWIPOwner <> 10 Then
            MessageBox.Show("Only AQL, CELLULAR 1, CELLULAR 1 (AQL HOLD), CELLULAR 2, CELLULAR 2 (AQL HOLD) have authority to remove device(s) from pallet.", "Take WIP Ownership", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ClearAll()
            Me.txtPalletName.Focus()
            Exit Sub
        End If
        '-------------------------------


        'exit if empty pallet name
        If iPallet_ID = 0 Then
            MessageBox.Show("Pallet Name does not exist.", "Remove Device from Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txtPalletName.Focus()
            Exit Sub
        End If

        'exit if empty listbox
        If (Me.lstFailItems.Items.Count = 0) Then
            MessageBox.Show("There is no item in the list to remove.", "Remove Device from Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txtIMEI.Focus()
            Exit Sub
        End If

        Try
            i = objMisc.UpdatePallet(iPallet_ID, Trim(Me.txtPalletName.Text), Me.lstFailItems)

            If i > 0 Then
                MessageBox.Show("Device(s) have been removed sucessfully.", "Update Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                'Print report
                '-------------
                objMisc.PrintPalletDeviceCountRpt(iPallet_ID)
                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "WIP_Transfer_Count.rpt")

                'rpt.ParameterFields.GetItemByName("Pallet_Name").AddCurrentValue(Trim(Me.txtPalletName.Text))
                'rpt.ParameterFields.GetItemByName("Quantity").AddCurrentValue(iNewPalletCount)
                'rpt.ParameterFields.GetItemByName("Owner").AddCurrentValue(objMisc.GetGroupDesc(iCurrentWIPOwner))
                'rpt.PrintOut(False, 2)
                'rpt = Nothing
                '--------------

            End If

        Catch ex As Exception
            MsgBox("frmRemoveDevicesFromPallet.cmdUpdate_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Remove Devices from Pallet")
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default

        'reset control and variable
        ClearAll()
        Me.txtPalletName.Focus()

    End Sub

    '******************************* LAN **************************************
    Private Sub ClearAll()
        'iScanCount = 0
        iPalletCount = 0
        iPallet_ID = 0
        Me.lblPalletCount.Text = "0"
        Me.txtPalletName.Text = ""
        Me.txtIMEI.Text = ""
        Me.lblScannedQty.Text = "0"
        Me.lstFailItems.Items.Clear()
        Me.lstFailItems.Refresh()
        Me.txtPalletName.Focus()
    End Sub

    '******************************* LAN **************************************
    Private Sub cmdRemoveSelectedItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveSelectedItem.Click

        If Me.lstFailItems.Items.Count = 0 Then
            Me.txtIMEI.Focus()
            Exit Sub
        ElseIf Me.lstFailItems.SelectedIndex > -1 Then
            Me.lstFailItems.Items.RemoveAt(Me.lstFailItems.SelectedIndex)
            Me.lblScannedQty.Text = Me.lstFailItems.Items.Count
            Me.lstFailItems.Refresh()
            Me.txtIMEI.Focus()
        Else
            'MessageBox.Show("Select item in list box.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    '********************************* LAN ***********************************
    Private Function GetIMEIs()
        Dim strIMEIs As String = ""
        Dim i As Integer = 0

        If Me.lstFailItems.Items.Count > 0 Then
            strIMEIs &= "('"
            For i = 0 To Me.lstFailItems.Items.Count - 1
                If i <> Me.lstFailItems.Items.Count - 1 Then
                    strIMEIs &= Me.lstFailItems.Items.Item(i) & "', '"
                Else
                    strIMEIs &= Me.lstFailItems.Items.Item(i)
                End If
            Next i

            strIMEIs &= "')"
        End If

        Return strIMEIs

    End Function

    '********************************* LAN ***********************************
    Private Sub frmRemoveDevicesFromPallet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Handlers to highlight in custom colors
        SetHandler(Me.txtIMEI)
        SetHandler(Me.txtPalletName)
        SetHandler(Me.txtLPPalletName)

        Me.txtPalletName.SelectAll()
        Me.txtPalletName.Focus()

    End Sub

    '******************************************************************************
    Private Shared Sub SetHandler(ByVal ctl As Control)
        AddHandler ctl.Enter, EnterHandler
        AddHandler ctl.Leave, LeaveHandler
        AddHandler ctl.Click, EnterHandler
    End Sub
    '******************************************************************************
    Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, HighLightColor)
    End Sub
    '******************************************************************************
    Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, WindowColor)
    End Sub

    '******************************************************************************
    Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
        Dim Type As String = sender.GetType.Name.ToString
        Select Case Type
            Case "ComboBox"
                CType(sender, ComboBox).BackColor = color
            Case "TextBox"
                CType(sender, TextBox).BackColor = color
            Case Else
                'no other types should be hightlighted.

        End Select
    End Sub

    '********************************* LAN *************************************
    Protected Overrides Sub Finalize()
        objMisc = Nothing
        MyBase.Finalize()
    End Sub

    '******************************* END LAN  **********************************

    Private Sub cmdLicensePlate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLicensePlate.Click
        Dim iPalletID As Integer = 0
        Try
            iPalletID = objMisc.GetPalletID(Trim(Me.txtLPPalletName.Text), 1)
            If iPalletID > 0 Then
                objMisc.PrintPalletDeviceCountRpt(iPalletID)
            Else
                Throw New Exception("Pallet Name was not defined in the system.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Recreate License Plate", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtLPPalletName.Text = ""
            Me.txtLPPalletName.Focus()
        End Try
    End Sub
End Class
