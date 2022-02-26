Option Explicit On 

Imports PSS.Core.[Global]

Public Class frmMessEditDevices
    Inherits System.Windows.Forms.Form

    Private Const _ICUSTID As Integer = 14

    Private GstrUserName As String = PSS.Core.[Global].ApplicationUser.User
    Private GiUserID As Integer = PSS.Core.[Global].ApplicationUser.IDuser
    Private GstrMachine As String = System.Net.Dns.GetHostName
    Private GiEmpNo As Integer = ApplicationUser.NumberEmp
    Private GiShiftID As Integer = ApplicationUser.IDShift
    Private GstrWorkDate As String = ApplicationUser.Workdate

    Private GdtItems As DataTable
    Private GiWO_ID As Integer

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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents radioWO As System.Windows.Forms.RadioButton
    Friend WithEvents radioSN As System.Windows.Forms.RadioButton
    Friend WithEvents lstItems As System.Windows.Forms.ListBox
    Friend WithEvents radioTray As System.Windows.Forms.RadioButton
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEditType As System.Windows.Forms.ComboBox
    Friend WithEvents radioShipID As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDoIt As System.Windows.Forms.Button
    Friend WithEvents cmbChangeToItem As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtChangeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblChangeTo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.radioWO = New System.Windows.Forms.RadioButton()
        Me.radioSN = New System.Windows.Forms.RadioButton()
        Me.lstItems = New System.Windows.Forms.ListBox()
        Me.radioTray = New System.Windows.Forms.RadioButton()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEditType = New System.Windows.Forms.ComboBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmbChangeToItem = New System.Windows.Forms.ComboBox()
        Me.lblChangeTo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radioShipID = New System.Windows.Forms.RadioButton()
        Me.cmdDoIt = New System.Windows.Forms.Button()
        Me.txtChangeTo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(-1, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(441, 56)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "MESSAGING DATA MANIPULATION"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(26, 286)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(144, 20)
        Me.txtItem.TabIndex = 3
        Me.txtItem.Text = ""
        '
        'radioWO
        '
        Me.radioWO.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioWO.ForeColor = System.Drawing.Color.White
        Me.radioWO.Location = New System.Drawing.Point(57, 74)
        Me.radioWO.Name = "radioWO"
        Me.radioWO.Size = New System.Drawing.Size(144, 28)
        Me.radioWO.TabIndex = 3
        Me.radioWO.Text = "Work Order ID"
        '
        'radioSN
        '
        Me.radioSN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioSN.ForeColor = System.Drawing.Color.White
        Me.radioSN.Location = New System.Drawing.Point(57, 26)
        Me.radioSN.Name = "radioSN"
        Me.radioSN.Size = New System.Drawing.Size(144, 28)
        Me.radioSN.TabIndex = 1
        Me.radioSN.Text = "Serial Number"
        '
        'lstItems
        '
        Me.lstItems.Location = New System.Drawing.Point(26, 309)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(144, 173)
        Me.lstItems.TabIndex = 4
        '
        'radioTray
        '
        Me.radioTray.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioTray.ForeColor = System.Drawing.Color.White
        Me.radioTray.Location = New System.Drawing.Point(57, 50)
        Me.radioTray.Name = "radioTray"
        Me.radioTray.Size = New System.Drawing.Size(144, 28)
        Me.radioTray.TabIndex = 2
        Me.radioTray.Text = "Tray ID"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Red
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(10, 488)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(80, 21)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "CLEAR ONE"
        '
        'btnClearAll
        '
        Me.btnClearAll.BackColor = System.Drawing.Color.Red
        Me.btnClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAll.ForeColor = System.Drawing.Color.White
        Me.btnClearAll.Location = New System.Drawing.Point(114, 488)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClearAll.Size = New System.Drawing.Size(80, 21)
        Me.btnClearAll.TabIndex = 6
        Me.btnClearAll.Text = "CLEAR ALL"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(18, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 24)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "What do you want to do?"
        '
        'cmbEditType
        '
        Me.cmbEditType.Items.AddRange(New Object() {"Change Model", "Change Frequency", "Change Baud Rate", "Change Cap Code", "Change Serial Number", "Change Tray Memo", "Change Work Order Name", "Change PO", "Un-Receive", "Reprint Receive Manifest", "Delete", "DBR Device(s)", "Un-Bill DBRs"})
        Me.cmbEditType.Location = New System.Drawing.Point(18, 89)
        Me.cmbEditType.Name = "cmbEditType"
        Me.cmbEditType.Size = New System.Drawing.Size(296, 21)
        Me.cmbEditType.TabIndex = 1
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Location = New System.Drawing.Point(384, 485)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(48, 24)
        Me.cmdExit.TabIndex = 10
        Me.cmdExit.Text = "Exit"
        '
        'cmbChangeToItem
        '
        Me.cmbChangeToItem.Items.AddRange(New Object() {"Change Model", "Change SKU", "Change Frequency", "Change Baud Rate", "Change Serial Number", "Change Tray Memo", "Change Work Order Name", "Delete", ""})
        Me.cmbChangeToItem.Location = New System.Drawing.Point(203, 286)
        Me.cmbChangeToItem.Name = "cmbChangeToItem"
        Me.cmbChangeToItem.Size = New System.Drawing.Size(216, 21)
        Me.cmbChangeToItem.TabIndex = 8
        Me.cmbChangeToItem.Visible = False
        '
        'lblChangeTo
        '
        Me.lblChangeTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangeTo.ForeColor = System.Drawing.Color.White
        Me.lblChangeTo.Location = New System.Drawing.Point(203, 270)
        Me.lblChangeTo.Name = "lblChangeTo"
        Me.lblChangeTo.Size = New System.Drawing.Size(100, 16)
        Me.lblChangeTo.TabIndex = 101
        Me.lblChangeTo.Text = "Change to:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioSN, Me.radioTray, Me.radioShipID, Me.radioWO})
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(18, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 136)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "What are you going to scan in the box below?"
        '
        'radioShipID
        '
        Me.radioShipID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioShipID.ForeColor = System.Drawing.Color.White
        Me.radioShipID.Location = New System.Drawing.Point(57, 98)
        Me.radioShipID.Name = "radioShipID"
        Me.radioShipID.Size = New System.Drawing.Size(144, 28)
        Me.radioShipID.TabIndex = 4
        Me.radioShipID.Text = "Ship ID"
        '
        'cmdDoIt
        '
        Me.cmdDoIt.BackColor = System.Drawing.Color.Red
        Me.cmdDoIt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDoIt.ForeColor = System.Drawing.Color.White
        Me.cmdDoIt.Location = New System.Drawing.Point(240, 424)
        Me.cmdDoIt.Name = "cmdDoIt"
        Me.cmdDoIt.Size = New System.Drawing.Size(112, 48)
        Me.cmdDoIt.TabIndex = 9
        Me.cmdDoIt.Text = "JUST DO IT"
        '
        'txtChangeTo
        '
        Me.txtChangeTo.Location = New System.Drawing.Point(203, 286)
        Me.txtChangeTo.MaxLength = 327
        Me.txtChangeTo.Name = "txtChangeTo"
        Me.txtChangeTo.Size = New System.Drawing.Size(216, 20)
        Me.txtChangeTo.TabIndex = 102
        Me.txtChangeTo.Text = ""
        Me.txtChangeTo.Visible = False
        Me.txtChangeTo.WordWrap = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(26, 269)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Scan in Items:"
        '
        'frmMessEditDevices
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(438, 516)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.txtChangeTo, Me.Label6, Me.txtItem, Me.lblChangeTo, Me.cmbChangeToItem, Me.btnClear, Me.GroupBox1, Me.cmdDoIt, Me.lstItems, Me.cmdExit, Me.btnClearAll, Me.cmbEditType, Me.Label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessEditDevices"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Messaging Data Manipulation"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    '*********************************************************************
    Private Sub CreateItemsTable()
        Dim objGen As New PSS.Data.Buisness.Generic()

        Try
            Me.lstItems.DataSource = Nothing

            If Not IsNothing(Me.GdtItems) Then
                Me.GdtItems.Dispose()
                Me.GdtItems = Nothing
            End If

            Me.GdtItems = New DataTable()
            objGen.AddNewColumnToDataTable(Me.GdtItems, "ID", "System.Int32")
            objGen.AddNewColumnToDataTable(Me.GdtItems, "WO_ID", "System.Int32")
            objGen.AddNewColumnToDataTable(Me.GdtItems, "Item", "System.String")
            With Me.lstItems
                .DataSource = Nothing
                .DataSource = Me.GdtItems.DefaultView
                .DisplayMember = Me.GdtItems.Columns("Item").ToString
                .ValueMember = Me.GdtItems.Columns("ID").ToString
                .Refresh()
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Item Datatable", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objGen = Nothing
        End Try
    End Sub

    '*********************************************************************
    Private Sub EnableDisableAllRadioButton(ByVal iEnable As Integer)
        If iEnable = 1 Then
            Me.radioSN.Enabled = True
            Me.radioTray.Enabled = True
            Me.radioShipID.Enabled = True
            Me.radioWO.Enabled = True
        Else
            Me.radioSN.Enabled = False
            Me.radioTray.Enabled = False
            Me.radioShipID.Enabled = False
            Me.radioWO.Enabled = False
        End If
    End Sub

    '*********************************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim strItem As String = ""
        Dim i As Integer = 0
        Dim R1 As DataRow

        Try
            If Me.lstItems.Items.Count = 0 Then
                Exit Sub
            End If

            '************************
            strItem = InputBox("Enter item:", "Clear One Item in List")
            If strItem = "" Then
                MessageBox.Show("Please enter a remove item if you want to remove it from the list.", "Remove an Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            For Each R1 In Me.GdtItems.Rows
                If strItem = R1("Item") Then
                    R1.Delete()
                    Me.GdtItems.AcceptChanges()
                    Exit For
                End If
            Next R1

            '*****************************************
            'disable item types when list contain item
            '*****************************************
            Me.lstItems.Refresh()
            If Me.GdtItems.Rows.Count = 0 Then
                Me.EnableDisableAllRadioButton(1)
                Me.GiWO_ID = 0
            Else
                Me.EnableDisableAllRadioButton(0)
            End If
            '*****************************************
            Me.txtItem.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear One Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
        End Try
    End Sub

    '*********************************************************************
    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click

        Try
            Me.EnableDisableAllRadioButton(1)
            Me.GiWO_ID = 0

            If Me.GdtItems.Rows.Count = 0 Then
                Exit Sub
            End If

            Me.CreateItemsTable()
            Me.lstItems.Refresh()
            Me.txtItem.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear All Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************************
    Private Sub cmbEditType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEditType.SelectedIndexChanged

        Try
            Me.ClearControls()
            Me.lblChangeTo.Visible = True

            Select Case Me.cmbEditType.SelectedIndex
                Case 0    'Change Model
                    Me.LoadModels()
                    Me.lblChangeTo.Text = "Change To:"
                    Me.cmbChangeToItem.Visible = True
                    Me.txtChangeTo.Visible = False
                Case 1    'Change Frequency
                    Me.LoadFrequencies()
                    Me.lblChangeTo.Text = "Change To:"
                    Me.cmbChangeToItem.Visible = True
                    Me.txtChangeTo.Visible = False
                Case 2    'Change Baud Rate
                    Me.LoadBaudRates()
                    Me.lblChangeTo.Text = "Change To:"
                    Me.cmbChangeToItem.Visible = True
                    Me.txtChangeTo.Visible = False
                Case 3    'Change Cap Code
                    Me.lblChangeTo.Text = "Change To:"
                    Me.txtChangeTo.Visible = True
                    Me.cmbChangeToItem.Visible = False
                Case 4    'Change Serial Number
                    Me.lblChangeTo.Text = "Change To:"
                    Me.txtChangeTo.Visible = True
                    Me.cmbChangeToItem.Visible = False
                Case 5    'Change Tray Memo
                    Me.lblChangeTo.Text = "Change To:"
                    Me.txtChangeTo.Visible = True
                    Me.cmbChangeToItem.Visible = False
                Case 6    'Change Work Order Name
                    MessageBox.Show("Change Work Order Name is not implemented yet.", "Select 'What To Do' Type", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    Me.lblChangeTo.Text = "Change To:"
                    Me.txtChangeTo.Visible = True
                    Me.cmbChangeToItem.Visible = False
                Case 7    'Change PO
                    MessageBox.Show("Change PO is not implemented yet.", "Select 'What To Do' Type", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    Me.lblChangeTo.Text = "Change To:"
                    Me.cmbChangeToItem.Visible = True
                    Me.txtChangeTo.Visible = False
                Case 8    'Un-Receive
                    Me.lblChangeTo.Visible = False
                    Me.cmbChangeToItem.Visible = False
                    Me.txtChangeTo.Visible = False
                Case 9    'Reprint Receive Manifest
                    Me.lblChangeTo.Visible = False
                    Me.cmbChangeToItem.Visible = False
                    Me.txtChangeTo.Visible = False
                Case 10     'Delete
                    If ApplicationUser.GetPermission("MessDelete") > 0 Then
                        Me.lblChangeTo.Visible = False
                        Me.cmbChangeToItem.Visible = False
                        Me.txtChangeTo.Visible = False
                    Else
                        MessageBox.Show("You don't have permission to perform this edit.", "Validate Delete Access", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Me.cmbEditType.SelectedIndex = -1
                        Exit Sub
                    End If
                Case 11     'DBR Device(s)
                    If ApplicationUser.GetPermission("MessDBRDevices") > 0 Then
                        Me.lblChangeTo.Text = "DBR Reasons"
                        Me.cmbChangeToItem.Visible = True
                        Me.txtChangeTo.Visible = False
                        Me.LoadDBRCodes()
                    Else
                        MessageBox.Show("You don't have permission to perform this edit.", "Validate Delete Access", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Me.cmbEditType.SelectedIndex = -1
                        Exit Sub
                    End If
                Case 12     'Un-Bill DBRs
                    If ApplicationUser.GetPermission("MessDBRDevices") > 0 Then
                        Me.lblChangeTo.Visible = False
                        Me.cmbChangeToItem.Visible = False
                        Me.txtChangeTo.Visible = False
                    Else
                        MessageBox.Show("You don't have permission to perform this edit.", "Validate Delete Access", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Me.cmbEditType.SelectedIndex = -1
                        Exit Sub
                    End If
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select 'What To Do' Type", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub

    '*********************************************************************
    Private Sub LoadModels()
        Dim dtModels As New DataTable()
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            dtModels = objMisc.GetModels(1, 0)
            With Me.cmbChangeToItem
                .DataSource = Nothing
                .DataSource = dtModels.DefaultView
                .DisplayMember = dtModels.Columns("Model_Desc").ToString
                .ValueMember = dtModels.Columns("Model_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtModels) Then
                dtModels.Dispose()
                dtModels = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    '********************************************************************
    Private Sub LoadFrequencies()
        Dim dtFreq As New DataTable()
        Dim objMessMisc As New PSS.Data.Buisness.MessMisc()

        Try
            dtFreq = objMessMisc.GetFrequencies
            dtFreq.LoadDataRow(New Object() {"0", "--Select--"}, False)

            With Me.cmbChangeToItem
                .DataSource = Nothing
                .DataSource = dtFreq.DefaultView
                .DisplayMember = dtFreq.Columns("freq_Number").ToString
                .ValueMember = dtFreq.Columns("freq_id").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtFreq) Then
                dtFreq.Dispose()
                dtFreq = Nothing
            End If
            objMessMisc = Nothing
        End Try
    End Sub

    '********************************************************************
    Private Sub LoadBaudRates()
        Dim dtBaudRates As New DataTable()
        Dim objML As New PSS.Data.Buisness.MessLabel()

        Try
            dtBaudRates = objML.GetBaudRates()
            With Me.cmbChangeToItem
                .DataSource = Nothing
                .DataSource = dtBaudRates.DefaultView
                .DisplayMember = dtBaudRates.Columns("baud_Number").ToString
                .ValueMember = dtBaudRates.Columns("Baud_ID").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtBaudRates) Then
                dtBaudRates.Dispose()
                dtBaudRates = Nothing
            End If
            objML = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadPOs(ByVal iLoc_id As Integer)
        Dim dtPO As DataTable
        Dim objMessRec As New PSS.Data.Buisness.MessReceive()

        Try
            If iLoc_id = 0 Then
                Exit Sub
            End If

            dtPO = objMessRec.GetPurchaseOrders(iLoc_id)
            '**************************************************
            'Fill the Customer combo box
            '**************************************************
            With Me.cmbChangeToItem
                .DataSource = Nothing
                .DataSource = dtPO.DefaultView
                .ValueMember = dtPO.Columns("PO_id").ToString
                .DisplayMember = dtPO.Columns("DisplayDesc").ToString
                .SelectedValue = 0
            End With
            '**************************************************
        Catch ex As Exception
            Throw ex
        Finally
            objMessRec = Nothing
            If Not IsNothing(dtPO) Then
                dtPO.Dispose()
                dtPO = Nothing
            End If
        End Try
    End Sub

    '*********************************************************************
    Private Sub LoadDBRCodes()
        Dim dtDBR As DataTable
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Try
            dtDBR = objMisc.GetDBRCodes
            Me.cmbChangeToItem.DataSource = dtDBR.DefaultView
            Me.cmbChangeToItem.DisplayMember = dtDBR.Columns("DispalyDesc").ToString
            Me.cmbChangeToItem.ValueMember = dtDBR.Columns("Dcode_ID").ToString
            Me.cmbChangeToItem.SelectedValue = 0   'Empty Row      0 is a Magoc number :)
        Catch ex As Exception
            objMisc.DisposeDT(dtDBR)
            MessageBox.Show("Error in frmDBRReason.LoadDBRCodes:: " & ex.Message.ToString, "Load DBR Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            objMisc = Nothing
            If Not IsNothing(dtDBR) Then
                dtDBR.Dispose()
                dtDBR = Nothing
            End If
        End Try
    End Sub

    '*********************************************************************
    Private Sub ClearControls()
        Me.EnableDisableAllRadioButton(1)
        Me.UnSelectScanType()
        Me.txtItem.Text = ""
        Me.txtChangeTo.Text = ""
        If Me.cmbChangeToItem.Items.Count > 0 Then
            Me.cmbChangeToItem.SelectedValue = 0
        End If
        Me.CreateItemsTable()
    End Sub

    Private Sub UnSelectScanType()
        Me.radioSN.Checked = False
        Me.radioTray.Checked = False
        Me.radioWO.Checked = False
        Me.radioShipID.Checked = False
    End Sub

    '*********************************************************************
    Private Sub OptionChaged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioWO.CheckedChanged, radioTray.CheckedChanged, radioShipID.CheckedChanged, radioSN.CheckedChanged
        If sender.checked = True Then
            Me.CreateItemsTable()
            Me.EnableDisableAllRadioButton(1)
            Me.ValidateUserSelection()
            '******************************
            'set focust to next control
            '******************************
            Me.txtItem.Focus()
        End If
    End Sub

    '********************************************************************
    Public Function ValidateUserSelection() As Boolean

        If Me.cmbEditType.SelectedIndex < 0 Then
            MessageBox.Show("Please Select 'What you want to do'.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.UnSelectScanType()
        Else
            Select Case Me.cmbEditType.SelectedIndex
                Case 0    'Change Model
                    If Me.radioSN.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Change Model' by Tray ID and Work Order ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 1    'Change Frequency
                    If Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Change Frequency' by Serial Number, Tray ID and Work Order ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 2    'Change Baud Rate
                    If Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Change Baud Rate' by Serial Number, Tray ID and Work Order ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 3    'Change Cap Code
                    If Me.radioTray.Checked = True Or Me.radioWO.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Change Cap Code' by Serial Number.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 4    'Change Serial Number
                    If Me.radioTray.Checked = True Or Me.radioWO.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Change Serial Number' by Serial Number.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 5    'Change Tray Memo
                    If Me.radioSN.Checked = True Or Me.radioWO.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Change Tray Memo' by Tray ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 6    'Change Work Order Name
                    If Me.radioSN.Checked = True Or Me.radioTray.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Change Work Order Name' by Work Order ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 7    'Change PO
                    If Me.radioSN.Checked = True Or Me.radioTray.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Change PO' by Work Order ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 8    'Un-Receive
                    If Me.radioWO.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Un-receive' by SNs or tray ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 9    'Reprint Receive Manifest
                    If Me.radioSN.Checked = True Or Me.radioWO.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Reprint Receive Manifest' by Tray ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 10     'Delete
                    If Me.radioWO.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Delete' by SNs or Tray ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 11     'DBR Device(s)
                    If Me.radioWO.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'DBR Device(s)' by SN and Tray ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
                Case 12     'Un-Bill DBRs
                    If Me.radioWO.Checked = True Or Me.radioShipID.Checked = True Then
                        MessageBox.Show("You can only 'Un-Bill DBRs' by SN and Tray ID.", "Validate Scan Type", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.UnSelectScanType()
                    End If
            End Select
        End If
    End Function

    '*********************************************************************
    Private Sub txtItem_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItem.KeyUp

        Dim i As Integer = 0
        Dim iItemExisted As Integer = 0
        Dim booCheckBillingShippingInvoicing As Boolean = False
        Dim R1 As DataRow
        Dim strEditType As String = ""

        Try
            If e.KeyValue = 13 Then

                If Trim(Me.txtItem.Text) = "" Then
                    Exit Sub
                End If

                strEditType = Trim(Me.GetEditType)

                If Me.radioSN.Checked = False And Me.radioTray.Checked = False And Me.radioShipID.Checked = False And Me.radioWO.Checked = False Then
                    MessageBox.Show("Please select 'Item Type' before scan item.", "Get Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If Me.cmbEditType.SelectedIndex < 0 Then
                    MessageBox.Show("Please select 'What To Do' before scan item.", "Get Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    Me.cmbEditType.SelectedIndex = Me.cmbEditType.SelectedIndex
                End If

                If Me.radioSN.Checked = True Then
                    If strEditType = "Change Serial Number" Or strEditType = "Change Cap Code" Then
                        If Me.lstItems.Items.Count >= 1 Then
                            MessageBox.Show("You only can '" & strEditType & "' of one device.", "Scan Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If
                ElseIf Me.radioTray.Checked = True Then
                    If Not IsNumeric(Trim(Me.txtItem.Text)) Then
                        MessageBox.Show("Invalid Tray ID.", "Scan in Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                ElseIf Me.radioShipID.Checked = True Then
                    If Not IsNumeric(Trim(Me.txtItem.Text)) Then
                        MessageBox.Show("Invalid Ship ID.", "Scan in Ship ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                ElseIf Me.radioWO.Checked = True Then
                    If Not IsNumeric(Trim(Me.txtItem.Text)) Then
                        MessageBox.Show("Invalid Work Order ID.", "Scan in WO ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    If strEditType = "Change Work Order Name" Then
                        If Me.lstItems.Items.Count >= 1 Then
                            MessageBox.Show("You can only change Work Order Name of one Work Order.", "Scan Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If
                End If

                '****************
                'Check duplicate
                '****************
                If IsNothing(Me.GdtItems) Then
                    Me.CreateItemsTable()
                Else
                    For Each R1 In Me.GdtItems.Rows
                        If R1("Item") = UCase(Trim(Me.txtItem.Text)) Then
                            MessageBox.Show("This item is already scanned in. Try another one.", "Scan in Items", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtItem.SelectAll()
                            Exit Sub
                        End If
                    Next R1
                End If

                '*********************************
                'Check if item existed in database
                '*********************************
                iItemExisted = Me.CheckItemExisted(Me.txtItem.Text.Trim.ToUpper, _ICUSTID)
                If iItemExisted = 0 Then
                    If Me.radioSN.Checked = True Then
                        MessageBox.Show("Serial Number does not exist in WIP.", "Validate Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ElseIf Me.radioTray.Checked = True Then
                        MessageBox.Show("Either Tray ID does not exist or there is no device for this Tray ID.", "Validate Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ElseIf Me.radioWO.Checked = True Then
                        MessageBox.Show("Either Work Order ID does not exist or there is no device for this WO ID.", "Validate Workorder ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ElseIf Me.radioShipID.Checked = True Then
                        MessageBox.Show("There is no devices for this Ship ID.", "Validate Ship ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                    Me.txtItem.SelectAll()
                    Exit Sub
                End If

                '*********************************
                'Check if wo_id exist for item
                '*********************************
                If iItemExisted > 0 AndAlso Me.GiWO_ID = 0 AndAlso (strEditType = "Un-Receive" Or strEditType = "Delete") Then
                    MessageBox.Show("Work Order ID is missing for scanned item.", "Validate WO ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                '******************************************************************
                'Check if item contains billed devices, shipped devices or invoiced devices
                '******************************************************************
                If iItemExisted > 0 Then
                    booCheckBillingShippingInvoicing = Me.CheckBillingAndShipping(iItemExisted)
                    If booCheckBillingShippingInvoicing = False Then
                        Me.txtItem.SelectAll()
                        Exit Sub
                    End If
                End If

                '********************
                'add item to listbox
                '********************
                R1 = Nothing
                If iItemExisted > 0 AndAlso booCheckBillingShippingInvoicing = True Then
                    '************************************************************
                    'Check if scanned item have the same wo with item in the list
                    '************************************************************
                    If strEditType = "Un-Receive" Or strEditType = "Delete" Then
                        If Me.GdtItems.Rows.Count > 0 Then
                            If Me.GdtItems.Rows(0)("WO_ID") <> Me.GiWO_ID Then
                                MessageBox.Show("'Scanned Item' does not belong to the same 'Work Order' with item(s) on the list.", "Validate WO ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If
                        End If
                    End If
                    '************************************************************

                    R1 = Nothing
                    R1 = Me.GdtItems.NewRow()
                    R1("Item") = UCase(Trim(Me.txtItem.Text))
                    R1("ID") = iItemExisted
                    R1("WO_ID") = Me.GiWO_ID
                    Me.GdtItems.Rows.Add(R1)
                    Me.GdtItems.AcceptChanges()
                    Me.lstItems.Refresh()
                    Me.txtItem.Text = ""
                ElseIf iItemExisted = -1 Then
                    '1) //do nothing. This happen when there are more than 1 devices for a SN.
                    '   System ask user to scan in the tray id. But tray ID either in the incorrect format or blank
                    '2) 
                End If

                '*****************************************
                'disable item types when list contain item
                '*****************************************
                If Me.lstItems.Items.Count = 0 Then
                    Me.EnableDisableAllRadioButton(1)
                Else
                    Me.EnableDisableAllRadioButton(0)
                End If
                '*****************************************
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Scan Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************************
    Private Function CheckItemExisted(ByVal strItem As String, _
                                      ByVal iCustID As Integer) As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim iResult As Integer = 0
        Dim strTray_id As String = ""
        Dim objMessAdmin As New PSS.Data.Buisness.MessAdmin()

        Try
            Me.GiWO_ID = 0

            If Me.radioSN.Checked = True Then
                If Me.GetEditType = "Un-Bill DBRs" Then
                    dt1 = objMessAdmin.GetMessDevice(strItem, iCustID)
                Else
                    dt1 = objMessAdmin.GetMessDeviceInWIP(strItem, iCustID)
                End If

                If dt1.Rows.Count > 1 Then
                    strTray_id = Trim(InputBox("Please scan Tray ID:", "Scan Tray ID"))
                    If Not IsNumeric(strTray_id) Then
                        MessageBox.Show("Tray ID has incorrect format.", "Validate Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        iResult = -1
                    ElseIf strTray_id = "" Then
                        iResult = -1
                    Else
                        For Each R1 In dt1.Rows
                            If R1("Tray_ID") = CInt(strTray_id) Then
                                iResult = R1("Device_ID")
                                Me.GiWO_ID = R1("WO_ID")
                                Exit For
                            End If
                        Next R1
                    End If
                ElseIf dt1.Rows.Count = 1 Then
                    iResult = dt1.Rows(0)("Device_ID")
                    Me.GiWO_ID = dt1.Rows(0)("WO_ID")
                Else
                    iResult = dt1.Rows.Count
                End If
            ElseIf Me.radioTray.Checked = True Then
                dt1 = objMessAdmin.GetMessDevCntInTray(CInt(Trim(strItem)))
                If dt1.Rows.Count > 0 Then
                    iResult = CInt(Trim(strItem))
                    Me.GiWO_ID = dt1.Rows(0)("WO_ID")
                End If
            ElseIf Me.radioShipID.Checked = True Then
                dt1 = objMessAdmin.GetMessDevCntInShipManifest(CInt(Me.txtItem.Text))
                If dt1.Rows.Count > 0 Then
                    iResult = CInt(Trim(strItem))
                    Me.GiWO_ID = dt1.Rows(0)("WO_ID")
                End If
            ElseIf Me.radioWO.Checked = True Then
                dt1 = objMessAdmin.GetMessDevCntWO(CInt(Trim(strItem)))
                If dt1.Rows.Count > 0 Then
                    iResult = CInt(Trim(strItem))
                    Me.GiWO_ID = dt1.Rows(0)("WO_ID")
                End If
            End If

            Return iResult

        Catch ex As Exception
            Throw ex
        Finally
            objMessAdmin = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Function

    '*********************************************************************
    Private Function CheckBillingAndShipping(ByVal iItemExisted) As Boolean
        Dim objMessAdmin As New PSS.Data.Buisness.MessAdmin()
        Dim strErrMsg As String = ""
        Dim strInputType As String = ""
        Dim iNoBilledDev As Integer = 0
        Dim iNoShippedDev As Integer = 0
        Dim iNoInvoicedDev As Integer = 0
        Dim booResult As Boolean = False
        Dim booBilledFlag As Boolean = True
        Dim booShippedFlag As Boolean = True
        Dim booInvoicedFlag As Boolean = True
        Dim booDBRDeviceFlg As Boolean = True
        Dim iDBRPallett As Integer = 0

        Try
            strInputType = Me.GetInputType

            Select Case Me.cmbEditType.SelectedIndex
                Case 0    'Change Model
                    iNoBilledDev = objMessAdmin.IsBilledDeviceExisted(strInputType, iItemExisted)
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 1    'Change Frequency
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 2    'Change Baud Rate
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 3    'Change Cap Code
                    'This might not need because we already excluded when we check existed item.
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 4    'Change Serial Number
                    'This might not need because we already excluded when we check existed item.
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 5    'Change Tray Memo
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 6    'Change Work Order Name
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 7    'Change PO
                    iNoBilledDev = objMessAdmin.IsBilledDeviceExisted(strInputType, iItemExisted)
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 8    'Un-Receive
                    iNoBilledDev = objMessAdmin.IsBilledDeviceExisted(strInputType, iItemExisted)
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 9    'Reprint Receive Manifest
                    'We don't need to validate billed and shipped devices
                Case 10     'Delete
                    iNoBilledDev = objMessAdmin.IsBilledDeviceExisted(strInputType, iItemExisted)
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 11     'DBR Device(s)
                    iNoBilledDev = objMessAdmin.IsBilledDeviceExisted(strInputType, iItemExisted)
                    iNoShippedDev = objMessAdmin.IsShippedDeviceExisted(strInputType, iItemExisted)
                Case 12     'Un-Bill DBRs
                    booDBRDeviceFlg = objMessAdmin.IsMessDBRDevices(strInputType, iItemExisted, iNoInvoicedDev)
                    'Check if item has DBR-Pallet
                    iDBRPallett = objMessAdmin.GetDBRPallett(strInputType, iItemExisted)
                    If iDBRPallett > 0 Then
                        MessageBox.Show(strInputType & " had DBR-Pallet.", "Validate Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
            End Select

            '*************************
            'Bill
            '*************************
            If iNoBilledDev > 0 Then
                booBilledFlag = False
                strErrMsg &= "Been billed" & Environment.NewLine
                'MessageBox.Show("This " & strInputType & " have billed device(s) can not " & Me.GetEditType & ".", "Validate Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End If

            '*************************
            'Ship
            '*************************
            If iNoShippedDev > 0 Then
                booShippedFlag = False
                strErrMsg &= "Been shipped" & Environment.NewLine
                'MessageBox.Show("This " & strInputType & " have shipped device(s) can not " & Me.GetEditType & ".", "Validate Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End If

            '*************************
            'Invoice
            '*************************
            If iNoInvoicedDev > 0 Then
                booInvoicedFlag = False
                strErrMsg &= "Been invoiced" & Environment.NewLine
                'MessageBox.Show("This " & strInputType & " have invoiced device(s) can not " & Me.GetEditType & ".", "Validate Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End If

            '*************************
            'DBR
            '*************************
            If booDBRDeviceFlg = False Then
                strErrMsg = "Not an DBR"
            End If

            '*************************
            'set error message
            '*************************
            If booBilledFlag = True And booShippedFlag = True And booInvoicedFlag = True And booDBRDeviceFlg = True And iDBRPallett = 0 Then
                booResult = True
            ElseIf strErrMsg <> "" Then
                If strInputType = "SN" Then
                    MessageBox.Show("Can not " & Me.GetEditType & " for the following reasons:" & Environment.NewLine & strErrMsg, "Validate Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If
            End If
            '*************************

            Return booResult
        Catch ex As Exception
            Throw ex
        Finally
            objMessAdmin = Nothing
        End Try
    End Function

    '*********************************************************************
    Private Sub cmdDoIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDoIt.Click
        Dim i As Integer = 0
        Dim strInputType As String = ""
        Dim strInputItems_id As String = ""
        Dim R1 As DataRow
        Dim objMessAdmin As PSS.Data.Buisness.MessAdmin
        Dim objDBRReasonCode As Object
        Dim iDBRCode_ID As Integer = 0

        Try
            Me.Enabled = False

            '********************************
            'validate required information
            '********************************
            If Me.lstItems.Items.Count = 0 Then
                MessageBox.Show("Please scan in item(s)", "Validate Input Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtItem.Focus()
                Exit Sub
            End If

            If Me.cmbEditType.SelectedIndex = 0 Or Me.cmbEditType.SelectedIndex = 1 Or Me.cmbEditType.SelectedIndex = 2 Or Me.cmbEditType.SelectedIndex = 7 Then
                If Me.cmbChangeToItem.SelectedValue = 0 Then
                    MessageBox.Show("Please select what you want to change in 'Change To' drop down box.", "Validate Input Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If Me.cmbEditType.SelectedIndex = 1 Then
                    If Me.cmbChangeToItem.SelectedItem(Me.cmbChangeToItem.DisplayMember) = "000.0000" Then
                        MessageBox.Show("'000.0000' is a default frequency. Please select a different Frequency.", "Validate Input Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            ElseIf Me.cmbEditType.SelectedIndex = 3 Or Me.cmbEditType.SelectedIndex = 4 Or Me.cmbEditType.SelectedIndex = 5 Or Me.cmbEditType.SelectedIndex = 6 Then
                If Trim(Me.txtChangeTo.Text) = "" Then
                    MessageBox.Show("Please enter what you want to change in 'Change To' box.", "Validate Input Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            '*********************
            'Confirm user action
            '*********************
            If MessageBox.Show("Are you sure you want to " & Me.GetEditType & " the scanned item(s)?", Me.GetEditType, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            '********************************
            'Get Input Type
            '********************************
            strInputType = Me.GetInputType()

            '********************************
            'build input string
            '********************************
            For i = 0 To Me.GdtItems.Rows.Count - 1
                R1 = Me.GdtItems.Rows(i)

                If i = 0 Then
                    strInputItems_id &= R1("ID")
                Else
                    strInputItems_id &= "," & R1("ID")
                End If
            Next i

            i = 0
            System.Windows.Forms.Application.DoEvents()

            '********************************
            'Update in the system
            '********************************
            objMessAdmin = New PSS.Data.Buisness.MessAdmin()

            Select Case Me.cmbEditType.SelectedIndex
                Case 0    'Change Model
                    i = objMessAdmin.EditMessModel(strInputType, strInputItems_id, Me.cmbChangeToItem.SelectedValue)
                Case 1    'Change Frequency
                    i = objMessAdmin.EditMessFreq(strInputType, strInputItems_id, Me.cmbChangeToItem.SelectedValue, Me.GiUserID)
                Case 2    'Change Baud Rate
                    i = objMessAdmin.EditMessBaud(strInputType, strInputItems_id, Me.cmbChangeToItem.SelectedValue, Me.GiUserID)
                Case 3    'Change Cap Code
                    i = objMessAdmin.EditCapCode(strInputType, strInputItems_id, Trim(UCase(Me.txtChangeTo.Text)), Me.GiUserID)
                Case 4    'Change Serial Number
                    i = objMessAdmin.EditMessSN(strInputType, CInt(strInputItems_id), Trim(UCase(Me.txtChangeTo.Text)), Me.GiUserID, Me._ICUSTID)
                Case 5    'Change Tray Memo
                    i = objMessAdmin.EditMessTrayMemo(strInputItems_id, UCase(Trim(Me.txtChangeTo.Text)))
                Case 6    'Change Work Order Name
                    '//not implemented yet
                Case 7    'Change PO
                    '//not implemented yet 
                Case 8    'Un-Receive
                    Try
                        i = objMessAdmin.UnReceiveDeleteDevices(strInputType, strInputItems_id, 1, Me.GstrUserName, Me.GdtItems)    '1:Un-Receive
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString, "Un-Receive", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End Try
                Case 9    'Reprint Receive Manifest
                    i = ReprintRecManifestByTrayID()
                Case 10    'Delete
                    Try
                        i = objMessAdmin.UnReceiveDeleteDevices(strInputType, strInputItems_id, 2, Me.GstrUserName, Me.GdtItems)    '2:Delete
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString, "Un-Receive", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End Try
                Case 11    'DBR Device(s)
                    Try
                        If Me.cmbChangeToItem.SelectedValue = 0 Then
                            MessageBox.Show("Please select DBR Reason.", "DBR Reasons", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                        i = Messaging.Functions.DBRMessDevices(strInputType, strInputItems_id, Me.cmbChangeToItem.SelectedValue)
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString, "DBR Device(s)", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End Try
                Case 12     'Un-Bill DBRs
                    Try
                        i = Messaging.Functions.UnBillMessDBRDevices(strInputType, strInputItems_id)
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString, "Un-Bill DBRs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End Try
            End Select

            System.Windows.Forms.Application.DoEvents()

            '*************************
            'confirm completed message
            '*************************
            If i > 0 Then
                MessageBox.Show("Done.", Me.GetEditType, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            '********************************
            'Reset controls and variable
            '********************************
            Me.GiWO_ID = 0
            Me.ClearControls()
            Me.txtItem.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, Me.GetEditType, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            If Me.txtChangeTo.Visible = True Then
                Me.txtChangeTo.SelectAll()
            Else
                Me.cmbChangeToItem.Focus()
            End If
        Finally
            R1 = Nothing
            objMessAdmin = Nothing
            Me.Enabled = True
        End Try
    End Sub

    '*********************************************************************
    Private Function ReprintRecManifestByTrayID() As Integer
        Dim R1 As DataRow
        Dim objMessRec As PSS.Data.Buisness.MessReceive

        Try
            '**********************************************
            'reprint receive manifest
            '**********************************************
            objMessRec = New PSS.Data.Buisness.MessReceive()

            For Each R1 In Me.GdtItems.Rows
                '***********************
                'Print Report
                '***********************
                objMessRec.PrintRecReport(CInt(R1("ID")), 1)
                System.Windows.Forms.Application.DoEvents()
            Next R1

            System.Windows.Forms.Application.DoEvents()

            Return 1
        Catch ex As Exception
            MessageBox.Show(ex.ToString, Me.GetEditType, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            objMessRec = Nothing
        End Try
    End Function

    '*********************************************************************
    Private Function GetInputType() As String
        Dim strInputType As String = ""

        '********************************
        'Get Input Type
        '********************************
        If Me.radioSN.Checked = True Then
            strInputType = "SN"
        ElseIf Me.radioTray.Checked = True Then
            strInputType = "TRAY ID"
        ElseIf Me.radioWO.Checked = True Then
            strInputType = "WO"
        ElseIf Me.radioShipID.Checked = True Then
            strInputType = "SHIP ID"
        End If
        '********************************

        Return strInputType
    End Function

    '*********************************************************************
    Private Function GetEditType() As String
        Dim strEditType As String = ""

        '********************************
        'Get Edit Type
        '********************************
        Select Case Me.cmbEditType.SelectedIndex
            Case 0    'Change Model
                strEditType = "Change Model"
            Case 1    'Change Frequency
                strEditType = "Change Frequency"
            Case 2    'Change Baud Rate
                strEditType = "Change Baud Rate"
            Case 3    'Change Cap Code
                strEditType = "Change Cap Code"
            Case 4    'Change Serial Number
                strEditType = "Change Serial Number"
            Case 5    'Change Tray Memo
                strEditType = "Change Tray Memo"
            Case 6    'Change Work Order Name
                strEditType = "Change Work Order Name"
            Case 7    'Change PO
                strEditType = "Change PO"
            Case 8    'Un-Receive
                strEditType = "Un-Receive"
            Case 9    'Reprint Receive Manifest
                strEditType = "Reprint Receive Manifest"
            Case 10    'Delete
                strEditType = "Delete"
            Case 11    'DBR Device(s)
                strEditType = "DBR Device(s)"
            Case 12     'Un-Bill DBRs
                strEditType = "Un-Bill DBRs"
        End Select

        Return strEditType
    End Function

    '*********************************************************************



End Class
