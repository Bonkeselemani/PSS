Public Class frmTakeWIPOwnership
    Inherits System.Windows.Forms.Form

    Private objMisc As PSS.Data.Buisness.Misc
    Private objInventory As PSS.Data.Buisness.Inventory
    Private iPallet_ID As Integer = 0
    Private iWO_ID As Integer = 0
    Private iFlag As Integer = 0       '1: Triage->Prod, 2: Prod->Prod, 3: Prod->AQL or AQL->AQL-Hold

    Private iNewGroup_ID As Integer = 0         'new group owner
    Private strNewOwner As String = ""
    Private strPalletName As String = ""        'user input Pallet Name

    Private iAssignedGroup_ID As Integer = 0    'originally assigned in tworkorder table
    Private strOriginalOwner As String = ""     'origanal group
    Private iCurrentOwner As Integer = 0        'tcellopt.cellopt_WIPOwner
    Private strCurrentOwner As String = ""

    Private itransferNum As Integer = 0
    Private iHoldCount As Integer = 0

    Private dtWHR As DataTable                  'WHR_ID, WHR_DEV_SN
    Private iRcvdPalletCount As Integer = 0

    'Partial Pallet
    Private iScanCount As Integer = 0
    Private iWHPalletID As Integer = 0
    Private strRevPalletName As String = ""
    Private iRevPalletCount As Integer = 0
    Private iOwnershipOf As Integer = 1         'selected by default(full); 2:partial
    '--------------

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
        objInventory = New PSS.Data.Buisness.Inventory()

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
    Friend WithEvents cmdTakeOwnership As System.Windows.Forms.Button
    Friend WithEvents cmbNewOwner As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblIMEI As System.Windows.Forms.Label
    Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlOwnershipOf As System.Windows.Forms.Panel
    Friend WithEvents pnlPallet As System.Windows.Forms.Panel
    Friend WithEvents lblPallet As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lstIMEIs As System.Windows.Forms.ListBox
    Friend WithEvents cmdReadyToTransfer As System.Windows.Forms.Button
    Friend WithEvents lblScannedQty As System.Windows.Forms.Label
    Friend WithEvents rbtnSomeDev As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFull As System.Windows.Forms.RadioButton
    Friend WithEvents pnelSomeDev As System.Windows.Forms.Panel
    Friend WithEvents lblCurrentOwner As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblHoldQty As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.txtIMEI = New System.Windows.Forms.TextBox()
        Me.cmdTakeOwnership = New System.Windows.Forms.Button()
        Me.cmbNewOwner = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlOwnershipOf = New System.Windows.Forms.Panel()
        Me.rbtnSomeDev = New System.Windows.Forms.RadioButton()
        Me.rbtnFull = New System.Windows.Forms.RadioButton()
        Me.pnlPallet = New System.Windows.Forms.Panel()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.lblHoldQty = New System.Windows.Forms.Label()
        Me.lblCurrentOwner = New System.Windows.Forms.Label()
        Me.pnelSomeDev = New System.Windows.Forms.Panel()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.lstIMEIs = New System.Windows.Forms.ListBox()
        Me.cmdReadyToTransfer = New System.Windows.Forms.Button()
        Me.lblScannedQty = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.pnlOwnershipOf.SuspendLayout()
        Me.pnlPallet.SuspendLayout()
        Me.pnelSomeDev.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblIMEI
        '
        Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIMEI.Location = New System.Drawing.Point(40, 49)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(56, 16)
        Me.lblIMEI.TabIndex = 0
        Me.lblIMEI.Text = "IMEI :  "
        Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtIMEI
        '
        Me.txtIMEI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(104, 49)
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.Size = New System.Drawing.Size(200, 22)
        Me.txtIMEI.TabIndex = 2
        Me.txtIMEI.Text = ""
        '
        'cmdTakeOwnership
        '
        Me.cmdTakeOwnership.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdTakeOwnership.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTakeOwnership.ForeColor = System.Drawing.Color.Blue
        Me.cmdTakeOwnership.Location = New System.Drawing.Point(424, 168)
        Me.cmdTakeOwnership.Name = "cmdTakeOwnership"
        Me.cmdTakeOwnership.Size = New System.Drawing.Size(152, 56)
        Me.cmdTakeOwnership.TabIndex = 6
        Me.cmdTakeOwnership.Text = "ASSIGN OWNERSHIP"
        Me.cmdTakeOwnership.Visible = False
        '
        'cmbNewOwner
        '
        Me.cmbNewOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNewOwner.Location = New System.Drawing.Point(104, 8)
        Me.cmbNewOwner.Name = "cmbNewOwner"
        Me.cmbNewOwner.Size = New System.Drawing.Size(200, 24)
        Me.cmbNewOwner.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(5, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(349, 70)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "WIP OWNERSHIP"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblIMEI, Me.txtIMEI, Me.cmbNewOwner, Me.Label3})
        Me.Panel2.Location = New System.Drawing.Point(2, 148)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(352, 84)
        Me.Panel2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "New Owner :"
        '
        'pnlOwnershipOf
        '
        Me.pnlOwnershipOf.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlOwnershipOf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlOwnershipOf.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnSomeDev, Me.rbtnFull})
        Me.pnlOwnershipOf.Location = New System.Drawing.Point(4, 74)
        Me.pnlOwnershipOf.Name = "pnlOwnershipOf"
        Me.pnlOwnershipOf.Size = New System.Drawing.Size(350, 72)
        Me.pnlOwnershipOf.TabIndex = 1
        '
        'rbtnSomeDev
        '
        Me.rbtnSomeDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSomeDev.Location = New System.Drawing.Point(12, 36)
        Me.rbtnSomeDev.Name = "rbtnSomeDev"
        Me.rbtnSomeDev.Size = New System.Drawing.Size(148, 24)
        Me.rbtnSomeDev.TabIndex = 1
        Me.rbtnSomeDev.Text = "Some Device(s)"
        '
        'rbtnFull
        '
        Me.rbtnFull.Checked = True
        Me.rbtnFull.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFull.Location = New System.Drawing.Point(12, 4)
        Me.rbtnFull.Name = "rbtnFull"
        Me.rbtnFull.Size = New System.Drawing.Size(148, 24)
        Me.rbtnFull.TabIndex = 0
        Me.rbtnFull.TabStop = True
        Me.rbtnFull.Text = "Full Pallet"
        '
        'pnlPallet
        '
        Me.pnlPallet.BackColor = System.Drawing.Color.Black
        Me.pnlPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label5, Me.Label6, Me.Label7, Me.lblPallet, Me.lblQty, Me.lblHoldQty, Me.lblCurrentOwner})
        Me.pnlPallet.Location = New System.Drawing.Point(356, 3)
        Me.pnlPallet.Name = "pnlPallet"
        Me.pnlPallet.Size = New System.Drawing.Size(400, 144)
        Me.pnlPallet.TabIndex = 19
        Me.pnlPallet.Visible = False
        '
        'lblPallet
        '
        Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPallet.ForeColor = System.Drawing.Color.Lime
        Me.lblPallet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPallet.Location = New System.Drawing.Point(144, 6)
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.Size = New System.Drawing.Size(240, 35)
        Me.lblPallet.TabIndex = 16
        '
        'lblQty
        '
        Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.ForeColor = System.Drawing.Color.Lime
        Me.lblQty.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblQty.Location = New System.Drawing.Point(144, 74)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(240, 35)
        Me.lblQty.TabIndex = 17
        '
        'lblHoldQty
        '
        Me.lblHoldQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoldQty.ForeColor = System.Drawing.Color.Lime
        Me.lblHoldQty.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblHoldQty.Location = New System.Drawing.Point(144, 109)
        Me.lblHoldQty.Name = "lblHoldQty"
        Me.lblHoldQty.Size = New System.Drawing.Size(240, 32)
        Me.lblHoldQty.TabIndex = 22
        '
        'lblCurrentOwner
        '
        Me.lblCurrentOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentOwner.ForeColor = System.Drawing.Color.Lime
        Me.lblCurrentOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCurrentOwner.Location = New System.Drawing.Point(144, 40)
        Me.lblCurrentOwner.Name = "lblCurrentOwner"
        Me.lblCurrentOwner.Size = New System.Drawing.Size(240, 35)
        Me.lblCurrentOwner.TabIndex = 19
        '
        'pnelSomeDev
        '
        Me.pnelSomeDev.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnelSomeDev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnelSomeDev.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdReset, Me.cmdClear, Me.lstIMEIs, Me.cmdReadyToTransfer, Me.lblScannedQty})
        Me.pnelSomeDev.Location = New System.Drawing.Point(2, 235)
        Me.pnelSomeDev.Name = "pnelSomeDev"
        Me.pnelSomeDev.Size = New System.Drawing.Size(352, 277)
        Me.pnelSomeDev.TabIndex = 3
        Me.pnelSomeDev.Visible = False
        '
        'cmdReset
        '
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReset.Location = New System.Drawing.Point(240, 168)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(72, 24)
        Me.cmdReset.TabIndex = 21
        Me.cmdReset.Text = "RESET"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(240, 112)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(72, 24)
        Me.cmdClear.TabIndex = 3
        Me.cmdClear.Text = "CLEAR"
        '
        'lstIMEIs
        '
        Me.lstIMEIs.Location = New System.Drawing.Point(40, 16)
        Me.lstIMEIs.Name = "lstIMEIs"
        Me.lstIMEIs.Size = New System.Drawing.Size(174, 238)
        Me.lstIMEIs.TabIndex = 2
        '
        'cmdReadyToTransfer
        '
        Me.cmdReadyToTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReadyToTransfer.ForeColor = System.Drawing.Color.Blue
        Me.cmdReadyToTransfer.Location = New System.Drawing.Point(248, 216)
        Me.cmdReadyToTransfer.Name = "cmdReadyToTransfer"
        Me.cmdReadyToTransfer.Size = New System.Drawing.Size(44, 24)
        Me.cmdReadyToTransfer.TabIndex = 4
        Me.cmdReadyToTransfer.Text = "Ready to Transfer"
        Me.cmdReadyToTransfer.Visible = False
        '
        'lblScannedQty
        '
        Me.lblScannedQty.BackColor = System.Drawing.Color.Black
        Me.lblScannedQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScannedQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScannedQty.ForeColor = System.Drawing.Color.Lime
        Me.lblScannedQty.Location = New System.Drawing.Point(248, 16)
        Me.lblScannedQty.Name = "lblScannedQty"
        Me.lblScannedQty.Size = New System.Drawing.Size(64, 48)
        Me.lblScannedQty.TabIndex = 20
        Me.lblScannedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(424, 248)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 72)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "This screen assigns ownership to WIP devices. This is for Triage and AQL groups o" & _
        "nly."
        Me.Label4.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(8, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 35)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Pallet :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Lime
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(8, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 35)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Transfer :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(8, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 35)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "On-Hold :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(8, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 35)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Current Owner :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmTakeWIPOwnership
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 573)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.pnelSomeDev, Me.pnlPallet, Me.pnlOwnershipOf, Me.Panel2, Me.Label1, Me.cmdTakeOwnership})
        Me.Name = "frmTakeWIPOwnership"
        Me.Text = "WIP OWNERSHIP"
        Me.Panel2.ResumeLayout(False)
        Me.pnlOwnershipOf.ResumeLayout(False)
        Me.pnlPallet.ResumeLayout(False)
        Me.pnelSomeDev.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*********************************** LAN *******************************
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
                CType(sender, ComboBox).BackColor = Color
            Case "TextBox"
                CType(sender, TextBox).BackColor = Color
                'Case "ListBox"
                '    CType(sender, ComboBox).BackColor = color
                'Case "Button"
                '    CType(sender, Button).BackColor = color
            Case Else
                'no other types should be hightlighted.

        End Select
    End Sub

    '******************************** lan *************************************
    Private Sub frmTakeWIPOwnership_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt1 As DataTable
        Dim i As Integer = 0


        'Handlers to highlight in custom colors
        SetHandler(Me.cmbNewOwner)
        SetHandler(Me.txtIMEI)


        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Try
            dt1 = objInventory.GetGroups(1)

            Me.cmbNewOwner.DataSource = dt1.DefaultView
            Me.cmbNewOwner.ValueMember = dt1.Columns("Group_ID").ToString
            Me.cmbNewOwner.DisplayMember = dt1.Columns("Group").ToString
            Me.cmbNewOwner.SelectedValue = 0

        Catch ex As Exception
            MessageBox.Show("frmTakeWIPOwnership_load." & ex.Message.ToString, "Display New Owner", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If

        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub


    '**************************** lan *********************************
    Private Sub txtIMEI_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp

        'Dim strReturnValue As String = ""
        Dim blResult As Boolean = False

        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        If e.KeyValue = 13 Then

            If Trim(Me.txtIMEI.Text) = "" Then
                Me.txtIMEI.Focus()
                Exit Sub
            ElseIf iNewGroup_ID > 0 Then
                Try
                    '-------------------
                    If Me.lstIMEIs.Items.Count = 0 Then
                        blResult = objMisc.GetPalletIDandWOIDinfo(Trim(Me.txtIMEI.Text), _
                                            iOwnershipOf, _
                                            iNewGroup_ID, _
                                            iPallet_ID, _
                                            iWO_ID, _
                                            iFlag, _
                                            iCurrentOwner, _
                                            strCurrentOwner, _
                                            strPalletName, _
                                            dtWHR, _
                                            iAssignedGroup_ID, _
                                            strOriginalOwner, _
                                            iHoldCount)
                        If blResult Then
                            iRcvdPalletCount = objMisc.GetRcvdPalletCount(strPalletName)

                            Me.lblCurrentOwner.Text = strCurrentOwner

                            If iOwnershipOf = 1 Then
                                Me.pnlPallet.Visible = True
                                Me.lblQty.Text = dtWHR.Rows.Count & "/" & iRcvdPalletCount
                                Me.lblPallet.Text = strPalletName
                                Me.lblHoldQty.Text = iHoldCount & "/" & iRcvdPalletCount
                            End If

                            Me.cmdTakeOwnership.Visible = True
                            Me.cmdTakeOwnership.Focus()
                        Else
                            Me.ClearControls()
                            Me.cmbNewOwner.Focus()
                            Exit Sub
                        End If
                    End If
                    '--------------------

                    '----Assign some device(s)
                    If (Me.rbtnSomeDev.Checked = True) Then

                        If iAssignedGroup_ID <> iNewGroup_ID Then
                            MessageBox.Show("This device belongs to the pallet have been assigned to " & strOriginalOwner & ". Cannot give to " & strNewOwner & ".", "New Owner Relation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            ClearControls()
                            Exit Sub
                        End If

                        AddDeviceToList(Trim(Me.txtIMEI.Text))
                    End If

                    '-------------------------

                Catch ex As Exception
                    Me.ClearControls()
                    Me.cmbNewOwner.Focus()
                    MessageBox.Show("frmTakeWIPOwnership.txtIMEI_KeyUp." & ex.Message.ToString, "New Owner Relation", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End Try
            Else
                Me.ClearControls()
                Me.cmbNewOwner.Focus()
                MessageBox.Show("Select New Owner in list box.", "New Owner Relation", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

        End If

        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub


    '*********************************** lan ***************************
    Private Sub AddDeviceToList(ByVal strIMEI As String)
        Dim i As Integer = 0

        Try
            If iScanCount = 0 Then
                objMisc.GetWHPalletIDNameCount(strIMEI, _
                                                iWHPalletID, _
                                                strRevPalletName, _
                                                iRevPalletCount, _
                                                iHoldCount)
                If iWHPalletID > 0 Then
                    Me.lstIMEIs.Items.Add(strIMEI)
                    iScanCount += 1

                    Me.lblScannedQty.Text = iScanCount
                    Me.pnlPallet.Visible = True
                    Me.lblQty.Text = iRevPalletCount & "/" & iRcvdPalletCount
                    Me.lblPallet.Text = strRevPalletName
                    Me.lblHoldQty.Text = iHoldCount & "/" & iRcvdPalletCount
                    Me.txtIMEI.Text = ""
                    Me.txtIMEI.Focus()
                Else
                    MessageBox.Show("Device does not exist in the system.", "IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If
            Else
                'check for duplicate in list box
                '--------------------------
                Dim j As Integer = 0
                Dim flag As Boolean = False
                For j = 0 To Me.lstIMEIs.Items.Count - 1
                    If Trim(Me.txtIMEI.Text) = Me.lstIMEIs.Items.Item(j) Then
                        flag = True
                        Exit For
                    End If
                Next
                '--------------------------

                If flag Then
                    'MessageBox.Show("This Device have been scan already.", "IMEI", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtIMEI.Text = ""
                    Me.txtIMEI.Focus()
                Else
                    i = objMisc.CheckIMEIBelongsToPallet(iWHPalletID, strIMEI)
                    Me.lstIMEIs.Items.Add(strIMEI)
                    iScanCount += 1
                    Me.lblScannedQty.Text = iScanCount
                    Me.txtIMEI.Text = ""
                    Me.txtIMEI.Focus()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "IMEI to Pallet Relationship", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    '*********************************** lan ***************************
    Private Sub cmdTakeOwnership_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTakeOwnership.Click
        Dim iUpdateResult As Integer = 0
        Dim iQty As Integer = 0

        'assign total devices transfer
        '-----------------------------
        If Me.rbtnFull.Checked = True Then
            itransferNum = dtWHR.Rows.Count
        Else
            itransferNum = Me.lstIMEIs.Items.Count
        End If
        '------------------------------

        If MessageBox.Show("There is " & itransferNum & " device(s) ready to transfer, would you like to continue the transfer?", "WIP Ownership", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            ClearControls()
            Me.cmbNewOwner.Focus()
            Exit Sub
        End If

        If iCurrentOwner = iNewGroup_ID Then
            MessageBox.Show("The current owner is new owner. No need to assign ownership.", "Take Ownership", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ClearControls()
            Me.cmbNewOwner.Focus()
            Exit Sub
        End If

        '--------------validation : Current Owner -> New Owner
        If Not Validation() Then
            ClearControls()
            Me.cmbNewOwner.Focus()
            Exit Sub
        End If
        '--------------------

        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        Try
            If Me.rbtnFull.Checked = True Then
                iUpdateResult = objMisc.TakeNewWIPOwnership(dtWHR, _
                                                            iFlag, _
                                                            iNewGroup_ID, _
                                                            strPalletName)
                iQty = dtWHR.Rows.Count
            Else
                iUpdateResult = objMisc.TakeWIPOwnership_SomeDev(Me.lstIMEIs, _
                                                                 iNewGroup_ID, _
                                                                 strRevPalletName, _
                                                                 iWHPalletID)
                iQty = Me.lstIMEIs.Items.Count
            End If

            'If (iUpdateResult = dtWHR.Rows.Count) Then
            If iUpdateResult > 0 Then
                MessageBox.Show(iUpdateResult & " device(s) have been transfered to " & strNewOwner & ".", "WIP Ownership", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                Dim rptApp As New CRAXDRT.Application()
                Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "WIP_Transfer_Count_New.rpt")

                rpt.ParameterFields.GetItemByName("Pallet_Name").AddCurrentValue(strPalletName)

                Dim strQty As String = iQty & " of " & iRcvdPalletCount
                rpt.ParameterFields.GetItemByName("Quantity").AddCurrentValue(strQty)

                rpt.ParameterFields.GetItemByName("Owner").AddCurrentValue(strNewOwner)
                rpt.PrintOut(False, 2)
                rpt = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("frmTakeOwnership.cmdTakeOwnership_click." & ex.Message.ToString, "Take Ownership", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

        ClearControls()
        Me.cmbNewOwner.Focus()

        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub


    '*************************** lan ***********************************
    Private Function Validation() As Boolean

        Try

            If iCurrentOwner = 0 Then
                MessageBox.Show("Cannot find current WIPOwner.", "WIP Ownership", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return False
            ElseIf iCurrentOwner > 0 Then
                Select Case iCurrentOwner
                    Case 2                      'cell 1 -> AQL, CELL 1 AQL-HOLD, CELL 2
                        If iNewGroup_ID = 6 Or iNewGroup_ID = 9 Or (iNewGroup_ID = 3 And iPallet_ID = 0) Then
                            Return True
                        ElseIf iNewGroup_ID = 3 And iPallet_ID > 0 Then
                            MessageBox.Show("A shipping pallet already created by CELL 1. Cannot give ownership to CELL 2. Pallet must go to AQL.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        Else
                            MessageBox.Show("The Current Owner is CELL 1 and New Owner must be CELL 2, AQL or CELLULAR 1 (AQL HOLD).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If

                    Case 3                      'cell 2 -> AQL, CELL 2 AQL-HOLD, CELL 1
                        If iNewGroup_ID = 6 Or iNewGroup_ID = 10 Or iNewGroup_ID = 2 Then
                            Return True
                        ElseIf iNewGroup_ID = 2 And iPallet_ID > 0 Then
                            MessageBox.Show("A shipping pallet already created by CELL 2. Cannot give ownership to CELL 1. Pallet must go to AQL.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        Else
                            MessageBox.Show("The Current Owner is CELL 2 and New Owner must be CELL 1, AQL or CELLULAR 2 (AQL HOLD).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If

                    Case 4                      'cell 3
                        'If iGroup_ID = 6 Or iGroup_ID = 9 Then
                        '    Return True
                        'Else
                        MessageBox.Show("Can not give ownership to CELL 3.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        '    Return False
                        'End If
                        Return False

                    Case 5                      'triage -> CELL 1 OR CELL 2
                        If iNewGroup_ID = 2 Or iNewGroup_ID = 3 Then 'Or iNewGroup_ID = 4 Then
                            Return True
                        Else
                            MessageBox.Show("The Current Owner is TRIAGE and New Owner must be CELL 1 or CELL 2.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If
                    Case 6                      'AQL -> CELLULAR 1 (AQL HOLD), CELLULAR 2 (AQL HOLD), Intransit
                        If (iNewGroup_ID = 9 And iAssignedGroup_ID = 2) Or _
                           (iNewGroup_ID = 10 And iAssignedGroup_ID = 3) Or iNewGroup_ID = 7 Then
                            Return True
                        ElseIf (iNewGroup_ID = 9 And iAssignedGroup_ID = 3) Then
                            MessageBox.Show("This Pallet originally belongs to CELL 2. Cannot give ownership to CELLULAR 1 (AQL HOLD).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        ElseIf (iNewGroup_ID = 10 And iAssignedGroup_ID = 2) Then
                            MessageBox.Show("This Pallet originally belongs to CELL 1. Cannot give ownership to CELLULAR 2 (AQL HOLD).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        Else
                            MessageBox.Show("Current Owner is AQL and New Owner must be CELL 1 (AQL HOLD), CELL 2 (AQL HOLD) or Intransit.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If
                    Case 7                      'Instransit
                        MessageBox.Show("Current Owner is Intransit and can not give ownership to any group.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return False
                    Case 8                      'Warehouse
                        MessageBox.Show("Current Owner is Warehouse and can not give ownership to any group.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return False
                    Case 9                      'CELLULAR 1 (AQL HOLD) -> AQL, CELL 1
                        If iNewGroup_ID = 6 Or iNewGroup_ID = 2 Then
                            Return True
                        Else
                            MessageBox.Show("The Current Owner is CELLULAR 1 (AQL HOLD) and New Owner must be AQL or CELL 1.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If
                    Case 10                     'CELLULAR 2 (AQL HOLD)-> AQL, CELL 2
                        If iNewGroup_ID = 6 Or iNewGroup_ID = 3 Then
                            Return True
                        Else
                            MessageBox.Show("The Current Owner is CELLULAR 2 (AQL HOLD) and New Owner must be AQL or CELL 2.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Return False
                        End If
                    Case Else
                        'Return True

                End Select
            End If
        Catch ex As Exception
            MessageBox.Show("frmTakeOwnership.Validation()." & ex.Message.ToString, "Take Ownership", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Function


    '*************************** lan ***********************************
    Private Sub cmbNewOwner_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNewOwner.SelectionChangeCommitted

        If Me.cmbNewOwner.SelectedValue > 0 Then

            Me.pnlPallet.Visible = False
            Me.lblPallet.Text = ""
            Me.lblQty.Text = ""
            Me.txtIMEI.Text = ""

            iPallet_ID = 0
            iFlag = 0
            iCurrentOwner = 0
            iWO_ID = 0
            'iNewGroup_ID = 0
            'strNewOwner = ""
            strPalletName = ""
            iAssignedGroup_ID = 0
            strOriginalOwner = ""

            iScanCount = 0
            iWHPalletID = 0
            strRevPalletName = ""
            iRevPalletCount = 0
            'iOwnershipOf = 0
            Me.lstIMEIs.Items.Clear()

            iNewGroup_ID = Me.cmbNewOwner.SelectedValue
            strNewOwner = objMisc.GetGroupDesc(iNewGroup_ID)

            itransferNum = 0
            iHoldCount = 0
            iRcvdPalletCount = 0

        Else
            Me.cmbNewOwner.Focus()
        End If

    End Sub

    '************************** lan ***********************************
    Private Sub ClearControls()

        Me.lblPallet.Text = ""
        Me.lblQty.Text = ""
        Me.txtIMEI.Text = ""
        Me.lblScannedQty.Text = "0"
        Me.cmbNewOwner.SelectedValue = 0
        Me.cmdTakeOwnership.Visible = False
        Me.pnlPallet.Visible = False
        iPallet_ID = 0
        iFlag = 0
        iCurrentOwner = 0
        strCurrentOwner = ""
        iWO_ID = 0
        iNewGroup_ID = 0
        strNewOwner = ""
        strPalletName = ""
        iAssignedGroup_ID = 0
        strOriginalOwner = ""

        iRcvdPalletCount = 0
        itransferNum = 0
        iHoldCount = 0

        iScanCount = 0
        iWHPalletID = 0
        strRevPalletName = ""
        iRevPalletCount = 0
        iOwnershipOf = 0
        Me.pnelSomeDev.Visible = False
        Me.lstIMEIs.Items.Clear()

    End Sub

    '******************************** lan ******************************
    Protected Overrides Sub Finalize()
        dtWHR = Nothing
        objMisc = Nothing
        objInventory = Nothing
        MyBase.Finalize()
    End Sub


    '******************************* END LAN *******************************
    Private Sub rbtnFull_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnFull.CheckedChanged

        If Me.rbtnFull.Checked = True Then
            ClearControls()
            Me.cmbNewOwner.Focus()
            Me.pnelSomeDev.Visible = False
            iOwnershipOf = 1
        End If

    End Sub


    '******************************* END LAN *******************************
    Private Sub rbtnSomeDev_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSomeDev.CheckedChanged

        If Me.rbtnSomeDev.Checked = True Then
            ClearControls()
            Me.cmbNewOwner.Focus()
            Me.pnelSomeDev.Visible = True
            iOwnershipOf = 2
        End If

    End Sub

    '******************************* END LAN *******************************
    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        ClearControls()
        Me.rbtnFull.Checked = True
        Me.cmbNewOwner.Focus()
    End Sub


End Class
