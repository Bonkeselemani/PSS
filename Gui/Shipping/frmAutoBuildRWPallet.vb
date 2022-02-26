Public Class frmAutoBuildRWPallet
    Inherits System.Windows.Forms.Form

    Private objRWPallets As PSS.Data.Buisness.ReworkPallets
    Private strMachine As String = System.Net.Dns.GetHostName
    Private strUserName As String = PSS.Core.[Global].ApplicationUser.User
    Private iUserID As Integer = PSS.Core.[Global].ApplicationUser.IDuser
    Private iShiftID As Integer = PSS.Core.[Global].ApplicationUser.IDShift
    Private strWorkDate As String = PSS.Core.[Global].ApplicationUser.Workdate

    Private iGroup_ID As Integer = 0
    Private iLine_ID As Integer = 0
    Private iWCLocation_ID As Integer = 0
    Private strGroup As String = ""

    Private iCust_id As Integer = 0
    Private strFilePath As String = ""
    Private dtWO_IDs As DataTable


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objRWPallets = New PSS.Data.Buisness.ReworkPallets()
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
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRcvdPalletName As System.Windows.Forms.TextBox
    Friend WithEvents cmdShip As System.Windows.Forms.Button
    Friend WithEvents cmdPallet As System.Windows.Forms.Button
    Friend WithEvents lblRef As System.Windows.Forms.Label
    Friend WithEvents lblRUR As System.Windows.Forms.Label
    Friend WithEvents lblRefQty As System.Windows.Forms.Label
    Friend WithEvents lblRURQty As System.Windows.Forms.Label
    Friend WithEvents lblRTMQty As System.Windows.Forms.Label
    Friend WithEvents lblIncQty As System.Windows.Forms.Label
    Friend WithEvents lblInc As System.Windows.Forms.Label
    Friend WithEvents lblRTM As System.Windows.Forms.Label
    Friend WithEvents cmdRmDev As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClearOne As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lstSN As System.Windows.Forms.ListBox
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClearOne = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lstSN = New System.Windows.Forms.ListBox()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIncQty = New System.Windows.Forms.Label()
        Me.lblInc = New System.Windows.Forms.Label()
        Me.lblRTMQty = New System.Windows.Forms.Label()
        Me.lblRURQty = New System.Windows.Forms.Label()
        Me.lblRefQty = New System.Windows.Forms.Label()
        Me.lblRTM = New System.Windows.Forms.Label()
        Me.lblRUR = New System.Windows.Forms.Label()
        Me.lblRef = New System.Windows.Forms.Label()
        Me.cmdPallet = New System.Windows.Forms.Button()
        Me.txtRcvdPalletName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdShip = New System.Windows.Forms.Button()
        Me.cmdRmDev = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(24, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "SN:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClearOne
        '
        Me.btnClearOne.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClearOne.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearOne.ForeColor = System.Drawing.Color.White
        Me.btnClearOne.Location = New System.Drawing.Point(232, 148)
        Me.btnClearOne.Name = "btnClearOne"
        Me.btnClearOne.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClearOne.Size = New System.Drawing.Size(80, 24)
        Me.btnClearOne.TabIndex = 118
        Me.btnClearOne.Text = "Clear One"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(232, 180)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(80, 24)
        Me.btnClear.TabIndex = 117
        Me.btnClear.Text = "Clear All"
        '
        'lstSN
        '
        Me.lstSN.BackColor = System.Drawing.Color.White
        Me.lstSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSN.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSN.ForeColor = System.Drawing.Color.Black
        Me.lstSN.Location = New System.Drawing.Point(64, 116)
        Me.lstSN.Name = "lstSN"
        Me.lstSN.Size = New System.Drawing.Size(157, 158)
        Me.lstSN.TabIndex = 116
        '
        'txtSN
        '
        Me.txtSN.BackColor = System.Drawing.Color.White
        Me.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSN.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.ForeColor = System.Drawing.Color.Black
        Me.txtSN.Location = New System.Drawing.Point(64, 92)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(157, 21)
        Me.txtSN.TabIndex = 115
        Me.txtSN.Text = ""
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCount.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCount.Location = New System.Drawing.Point(240, 100)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(64, 32)
        Me.lblCount.TabIndex = 113
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(64, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 53)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Scan in the device(s) you want to exclude from this shipment. Excluded devices ca" & _
        "n not be shipped using this process later."
        '
        'lblIncQty
        '
        Me.lblIncQty.BackColor = System.Drawing.Color.Transparent
        Me.lblIncQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncQty.ForeColor = System.Drawing.Color.Black
        Me.lblIncQty.Location = New System.Drawing.Point(152, 187)
        Me.lblIncQty.Name = "lblIncQty"
        Me.lblIncQty.Size = New System.Drawing.Size(48, 16)
        Me.lblIncQty.TabIndex = 111
        Me.lblIncQty.Text = "0"
        Me.lblIncQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIncQty.Visible = False
        '
        'lblInc
        '
        Me.lblInc.BackColor = System.Drawing.Color.Transparent
        Me.lblInc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInc.ForeColor = System.Drawing.Color.Black
        Me.lblInc.Location = New System.Drawing.Point(56, 187)
        Me.lblInc.Name = "lblInc"
        Me.lblInc.Size = New System.Drawing.Size(88, 16)
        Me.lblInc.TabIndex = 110
        Me.lblInc.Text = "Incomplete: "
        Me.lblInc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblInc.Visible = False
        '
        'lblRTMQty
        '
        Me.lblRTMQty.BackColor = System.Drawing.Color.Transparent
        Me.lblRTMQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRTMQty.ForeColor = System.Drawing.Color.Black
        Me.lblRTMQty.Location = New System.Drawing.Point(152, 163)
        Me.lblRTMQty.Name = "lblRTMQty"
        Me.lblRTMQty.Size = New System.Drawing.Size(48, 16)
        Me.lblRTMQty.TabIndex = 109
        Me.lblRTMQty.Text = "0"
        Me.lblRTMQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRTMQty.Visible = False
        '
        'lblRURQty
        '
        Me.lblRURQty.BackColor = System.Drawing.Color.Transparent
        Me.lblRURQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRURQty.ForeColor = System.Drawing.Color.Black
        Me.lblRURQty.Location = New System.Drawing.Point(152, 139)
        Me.lblRURQty.Name = "lblRURQty"
        Me.lblRURQty.Size = New System.Drawing.Size(48, 16)
        Me.lblRURQty.TabIndex = 108
        Me.lblRURQty.Text = "0"
        Me.lblRURQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRURQty.Visible = False
        '
        'lblRefQty
        '
        Me.lblRefQty.BackColor = System.Drawing.Color.Transparent
        Me.lblRefQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefQty.ForeColor = System.Drawing.Color.Black
        Me.lblRefQty.Location = New System.Drawing.Point(152, 115)
        Me.lblRefQty.Name = "lblRefQty"
        Me.lblRefQty.Size = New System.Drawing.Size(48, 16)
        Me.lblRefQty.TabIndex = 107
        Me.lblRefQty.Text = "1000"
        Me.lblRefQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRefQty.Visible = False
        '
        'lblRTM
        '
        Me.lblRTM.BackColor = System.Drawing.Color.Transparent
        Me.lblRTM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRTM.ForeColor = System.Drawing.Color.Black
        Me.lblRTM.Location = New System.Drawing.Point(56, 163)
        Me.lblRTM.Name = "lblRTM"
        Me.lblRTM.Size = New System.Drawing.Size(88, 16)
        Me.lblRTM.TabIndex = 106
        Me.lblRTM.Text = "RTM: "
        Me.lblRTM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRTM.Visible = False
        '
        'lblRUR
        '
        Me.lblRUR.BackColor = System.Drawing.Color.Transparent
        Me.lblRUR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUR.ForeColor = System.Drawing.Color.Black
        Me.lblRUR.Location = New System.Drawing.Point(56, 139)
        Me.lblRUR.Name = "lblRUR"
        Me.lblRUR.Size = New System.Drawing.Size(88, 16)
        Me.lblRUR.TabIndex = 105
        Me.lblRUR.Text = "RUR: "
        Me.lblRUR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRUR.Visible = False
        '
        'lblRef
        '
        Me.lblRef.BackColor = System.Drawing.Color.Transparent
        Me.lblRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRef.ForeColor = System.Drawing.Color.Black
        Me.lblRef.Location = New System.Drawing.Point(56, 115)
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Size = New System.Drawing.Size(88, 16)
        Me.lblRef.TabIndex = 104
        Me.lblRef.Text = "Refurbished: "
        Me.lblRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRef.Visible = False
        '
        'cmdPallet
        '
        Me.cmdPallet.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPallet.ForeColor = System.Drawing.Color.White
        Me.cmdPallet.Location = New System.Drawing.Point(264, 91)
        Me.cmdPallet.Name = "cmdPallet"
        Me.cmdPallet.Size = New System.Drawing.Size(40, 22)
        Me.cmdPallet.TabIndex = 2
        Me.cmdPallet.Text = "GO"
        '
        'txtRcvdPalletName
        '
        Me.txtRcvdPalletName.Location = New System.Drawing.Point(56, 91)
        Me.txtRcvdPalletName.Name = "txtRcvdPalletName"
        Me.txtRcvdPalletName.Size = New System.Drawing.Size(200, 20)
        Me.txtRcvdPalletName.TabIndex = 1
        Me.txtRcvdPalletName.Text = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(56, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(160, 16)
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "Received Pallet Name:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdShip
        '
        Me.cmdShip.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShip.ForeColor = System.Drawing.Color.White
        Me.cmdShip.Location = New System.Drawing.Point(72, 235)
        Me.cmdShip.Name = "cmdShip"
        Me.cmdShip.Size = New System.Drawing.Size(176, 34)
        Me.cmdShip.TabIndex = 1
        Me.cmdShip.Text = "SHIP PALLET"
        '
        'cmdRmDev
        '
        Me.cmdRmDev.BackColor = System.Drawing.Color.Red
        Me.cmdRmDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRmDev.ForeColor = System.Drawing.Color.White
        Me.cmdRmDev.Location = New System.Drawing.Point(712, 496)
        Me.cmdRmDev.Name = "cmdRmDev"
        Me.cmdRmDev.Size = New System.Drawing.Size(40, 24)
        Me.cmdRmDev.TabIndex = 91
        Me.cmdRmDev.Text = "Remove Device from Rework Ship Pallet"
        Me.cmdRmDev.Visible = False
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Black
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Yellow
        Me.lbl.Location = New System.Drawing.Point(2, 2)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(698, 45)
        Me.lbl.TabIndex = 90
        Me.lbl.Text = "AUTO-SHIP REWORK PALLETS"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.btnClearOne, Me.Label2, Me.lstSN, Me.btnClear, Me.txtSN, Me.Label1, Me.lblCount})
        Me.Panel1.Location = New System.Drawing.Point(2, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(336, 315)
        Me.Panel1.TabIndex = 120
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.Label4, Me.lblRUR, Me.cmdPallet, Me.lblRefQty, Me.cmdShip, Me.lblRTMQty, Me.lblRef, Me.txtRcvdPalletName, Me.lblIncQty, Me.lblRTM, Me.Label10, Me.lblInc, Me.lblRURQty})
        Me.Panel2.Location = New System.Drawing.Point(340, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(360, 315)
        Me.Panel2.TabIndex = 121
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "STEP 1: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(6, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "STEP 2: "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(71, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(281, 61)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Once you entered the Pallet Name and clicked the GO button you can not go back to" & _
        " STEP 1. So make sure you have scanned in all the devices before coming to STEP " & _
        "2."
        '
        'frmAutoBuildRWPallet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 525)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lbl, Me.Panel2, Me.Panel1, Me.cmdRmDev})
        Me.Name = "frmAutoBuildRWPallet"
        Me.Text = "Auto Build and Ship Rework Pallet"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        objRWPallets = Nothing
        MyBase.Finalize()
    End Sub

    '*********************************************************
    Private Function CheckIfMachineTiedToLine() As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            dt1 = objMisc.CheckIfMachineTiedToLine(strMachine)
            If dt1.Rows.Count = 0 Then
                Return 0
            End If

            For Each R1 In dt1.Rows
                iGroup_ID = R1("Group_ID")
                strGroup = Trim(R1("Group_Desc"))
                iLine_ID = R1("Line_ID")
                'strLineNumber = Trim(R1("Line_Number"))
                'iLineSide_ID = R1("LineSide_ID")
                'strLineSide = Trim(R1("LineSide_Desc"))
                'strBin = Trim(R1("WC_Location"))
                iWCLocation_ID = R1("WCLocation_ID")
            Next R1

            'Me.lblGroup.Text = "Group: " & strGroup
            'Me.lblLine.Text = strLineNumber
            'Me.lblLineSide.Text = strLineSide
            'Me.lblMachine.Text = "Machine: " & strMachine
            'Me.lblUserName.Text = "User: " & strUserName
            'Me.lblShift.Text = "Shift: " & iShiftID
            'Me.lblWorkDate.Text = "Work Date: " & Format(CDate(strWorkDate), "MM/dd/yyyy")
            'Me.lblBin.Text = "BIN: " & strBin

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

    '*********************************************************
    Private Sub frmAutoBuildRWPallet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0

        Try
            i = CheckIfMachineTiedToLine()
            If i = 0 Then
                Throw New Exception("Machine is not associated with any 'Line'. Can't continue.")
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("frmAutoBuildRWPallet.frmAutoBuildRWPallet_Load: " & Environment.NewLine & ex.Message.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub txtRcvdPalletName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRcvdPalletName.KeyUp
        If e.KeyValue = 13 Then
            Try
                If Trim(Me.txtRcvdPalletName.Text) = "" Then
                    Exit Sub
                End If
                Me.ProcessPallet()
                Me.Panel1.Visible = False
                Me.cmdShip.Visible = True
            Catch ex As Exception
                MessageBox.Show("txtRcvdPalletName_KeyUp: " & Environment.NewLine & ex.Message.ToString, "Get Received Pallet Name", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End If
    End Sub

    '*********************************************************
    Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click
        Dim i As Integer = 0
        Dim objMainWin As New Gui.MainWin.WorkArea()

        Try
            If MessageBox.Show("Are you sure you want to auto-ship this pallet?", "Unship Devices", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            'auto ship rework pallet
            i = Me.objRWPallets.ShipReworkPallet(Me.strFilePath, strWorkDate, strUserName, iUserID, iWCLocation_ID, iLine_ID, iGroup_ID, iShiftID, Me.iCust_id, Me.dtWO_IDs)

            'confirm message
            If i > 0 Then
                MessageBox.Show("Rework pallet has been shipped. This screen will now close!!!", "Auto Build and Ship Rewor Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Me.Close()
            PSS.Gui.MainWin.MainWin.wrkArea.TabPages.RemoveAt(PSS.Gui.MainWin.MainWin.wrkArea.SelectedIndex)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            ClearGlobal()
        Finally
            objMainWin = Nothing
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            ClearGlobal()
            Me.txtRcvdPalletName.Focus()
            Me.Panel1.Visible = True
            Me.cmdShip.Visible = False
        End Try
    End Sub

    Private Sub ClearGlobal()
        Try
            Me.objRWPallets.iRefPallet_id = 0
            Me.objRWPallets.iRURPallet_id = 0
            Me.objRWPallets.iRTMPallet_id = 0
            Me.objRWPallets.DisposeDT(Me.objRWPallets.dtRef)
            Me.objRWPallets.DisposeDT(Me.objRWPallets.dtRUR)
            Me.objRWPallets.DisposeDT(Me.objRWPallets.dtRTM)
            Me.objRWPallets.strRefPalletName = ""
            Me.objRWPallets.strRURPalletName = ""
            Me.objRWPallets.strRTMPalletName = ""
            Me.iCust_id = 0
            Me.objRWPallets.DisposeDT(Me.dtWO_IDs)

            Me.txtRcvdPalletName.Text = ""
            Me.lblRef.Visible = False
            Me.lblRefQty.Visible = False
            Me.lblRUR.Visible = False
            Me.lblRURQty.Visible = False
            Me.lblRTM.Visible = False
            Me.lblRTMQty.Visible = False
            Me.cmdShip.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdPallet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPallet.Click
        Try
            If Trim(Me.txtRcvdPalletName.Text) = "" Then
                Exit Sub
            End If
            Me.ProcessPallet()
        Catch ex As Exception
            MessageBox.Show("cmdPallet_Click: " & Environment.NewLine & ex.Message.ToString, "Get Received Pallet Name", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ClearGlobal()
    End Sub

    '*********************************************************
    Private Sub ProcessPallet()
        Dim iRefPallett_id As Integer = 0
        Dim iRURPallett_id As Integer = 0
        Dim iRtmPallett_id As Integer = 0
        Dim iIncPallett_id As Integer = 0
        Dim iWO_Qty As Integer = 0
        Dim iWO_GroupID As Integer = 0
        Dim i As Integer = 0
        Dim strWO_id As String = ""

        Try
            Me.lblRef.Visible = False
            Me.lblRefQty.Visible = False
            Me.lblRefQty.Text = "0"
            Me.lblRUR.Visible = False
            Me.lblRURQty.Visible = False
            Me.lblRURQty.Text = "0"
            Me.lblRTM.Visible = False
            Me.lblRTMQty.Visible = False
            Me.lblRTMQty.Text = "0"
            Me.lblInc.Visible = False
            Me.lblIncQty.Visible = False
            Me.lblIncQty.Text = "0"

            'If UCase(Microsoft.VisualBasic.Right(Trim(Me.txtRcvdPalletName.Text), 2)) <> "RW" Then
            '    Throw New Exception("This pallet is not rework pallet. Can not auto ship.")
            'End If

            '*************************
            'Step 1: Get WO_ID
            '*************************
            If Not IsNothing(dtWO_IDs) Then
                dtWO_IDs.Dispose()
                dtWO_IDs = Nothing
            End If

            dtWO_IDs = objRWPallets.GetWOInfo(Trim(Me.txtRcvdPalletName.Text))

            If dtWO_IDs.Rows.Count = 0 Then
                Throw New Exception("Pallet name either does not exist or have not line received.")
            End If

            iCust_id = dtWO_IDs.Rows(0)("Cust_id")
            iWO_GroupID = dtWO_IDs.Rows(0)("group_id")

            For i = 0 To dtWO_IDs.Rows.Count - 1
                If i = 0 Then
                    strWO_id = dtWO_IDs.Rows(i)("wo_id")
                Else
                    strWO_id &= "," & dtWO_IDs.Rows(i)("wo_id")
                End If
            Next i

            '*************************
            'Assign report directory
            '*************************
            Select Case Me.iCust_id
                Case 2019
                    strFilePath = "p:\dept\ATCLE\Palet packing list\"
                    'Case 2113
                    '    strFilePath = "p:\dept\Cellstar\Pallet packing list\"
                Case 2219
                    strFilePath = "p:\dept\Game Stop\Pallet packing list\"
                Case Else
                    Throw New Exception("This sreen was designed to work for ATCLE rework pallet only. If you need to use this screen for different customer, contact IT.")
            End Select

            '*******************************************************
            'Step 2:Check if machine group is the same with wo group
            '*******************************************************
            If iWO_GroupID <> Me.iGroup_ID Then
                Throw New Exception("The workorder does not belong to " & strGroup & ".")
            End If

            '********************************************
            'Step 3: Get all device in WO and Validate WO
            '********************************************
            iWO_Qty = Me.objRWPallets.CreateShipDatatable(Trim(Me.txtRcvdPalletName.Text), strWO_id, Me.lstSN)

            '*************************************
            'Step 4: Create ship pallet name
            '*************************************
            If Me.objRWPallets.dtRef.Rows.Count > 0 Then
                Me.lblRef.Visible = True
                Me.lblRefQty.Visible = True
                Me.lblRefQty.Text = Me.objRWPallets.dtRef.Rows.Count
            End If
            If Me.objRWPallets.dtRUR.Rows.Count > 0 Then
                Me.lblRUR.Visible = True
                Me.lblRURQty.Visible = True
                Me.lblRURQty.Text = Me.objRWPallets.dtRUR.Rows.Count
            End If
            If Me.objRWPallets.dtRTM.Rows.Count > 0 Then
                Me.lblRTM.Visible = True
                Me.lblRTMQty.Visible = True
                Me.lblRTMQty.Text = Me.objRWPallets.dtRTM.Rows.Count
            End If
            '*************************************

            Me.cmdShip.Visible = True
        Catch ex As Exception
            Me.objRWPallets.DisposeDT(Me.dtWO_IDs)
            Me.objRWPallets.DisposeDT(Me.objRWPallets.dtRef)
            Me.objRWPallets.DisposeDT(Me.objRWPallets.dtRUR)
            Me.objRWPallets.DisposeDT(Me.objRWPallets.dtRTM)
            Me.txtRcvdPalletName.SelectAll()
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdRmDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRmDev.Click
        Dim i As Integer = 0
        Dim strPallett_name As String = ""
        Dim strIMEI As String = ""
        Dim strSN As String = ""
        Dim dt1 As DataTable


        Try
            If MessageBox.Show("Are you sure you want to 'unship' a device from rework pallet?", "Unship Devices", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            '*******************************
            'Get pallett Name
            '*******************************
            strPallett_name = Trim(InputBox("Enter Shipping Pallet Name:"))
            If strPallett_name = "" Then
                Exit Sub
            End If

            '*******************************
            'Validate pallett
            '*******************************
            If UCase(Mid(Trim(strPallett_name), 4, 2)) <> "RW" Then
                MessageBox.Show(strPallett_name & " is not a rework pallet.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            dt1 = Me.objRWPallets.GetPallett_ID(strPallett_name)

            If dt1.Rows.Count = 0 Then
                MessageBox.Show(strPallett_name & " does not exist in the system.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If dt1.Rows(0)("Pallett_BulkShipped") <> 2 Then
                MessageBox.Show(strPallett_name & " is not a rework pallet.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '*******************************
            'Get Device serial number
            '*******************************
            strSN = Trim(InputBox("Enter Serial Number:"))
            '*******************************
            'unship device
            '*******************************
            i = Me.objRWPallets.RemoveADeviceFromRWPallett(iGroup_ID, strSN, dt1.Rows(0))

            '*******************************
            'confirm message
            '*******************************
            If i > 0 Then
                MessageBox.Show("Device has been upshipped.", "Remove Device from Ship Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show("cmdRmDev_Click:: " & Environment.NewLine & ex.Message.ToString, "Remove Device from Auto-ship Rework Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.objRWPallets.DisposeDT(dt1)
            Me.txtRcvdPalletName.Focus()
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If Me.lstSN.Items.Count > 0 Then
            Me.lstSN.Items.Clear()
            Me.lblCount.Text = lstSN.Items.Count
        End If
    End Sub

    Private Sub btnClearOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearOne.Click
        If Me.lstSN.SelectedIndex <> -1 Then    'If nothing is selected
            Me.lstSN.Items.RemoveAt(Me.lstSN.SelectedIndex)
            Me.lstSN.Refresh()
        End If
    End Sub

    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Dim i As Integer = 0

        If e.KeyValue = 13 Then
            'check for duplicates in list, if exists exit sub
            For i = 0 To Me.lstSN.Items.Count - 1
                If Trim(UCase(Me.lstSN.Items(i))) = Trim(UCase(txtSN.Text)) Then
                    MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Customer Specific Shipping")
                    Me.txtSN.Text = ""
                    txtSN.Text = ""
                    Me.txtSN.Focus()
                    Exit Sub
                End If
            Next i

            Me.lstSN.Items.Add(Trim(UCase(Me.txtSN.Text)))
            Me.lblCount.Text = Me.lstSN.Items.Count
            Me.txtSN.Text = ""
            Me.txtSN.Focus()
        End If
    End Sub


End Class
