Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmRec
        Inherits System.Windows.Forms.Form

        Private _objTFRec As PSS.Data.Buisness.TracFone.Receive
        Private _iOrderModelID As Integer = 0
        Private _iManufID As Integer = 0
        Private _iTrayID As Integer = 0
        Private _booEligibleToViewUnRecUnits As Boolean = False
        Private _booEligibleToProcessDiscrepancy As Boolean = False
        Private _booLoadDataToCtrl As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objTFRec = New PSS.Data.Buisness.TracFone.Receive()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                _objTFRec = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents pnlFileInfo As System.Windows.Forms.Panel
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblRejected As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblAccepted As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblFileQty As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblMsg As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnCloseRMA As System.Windows.Forms.Button
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents dbgRecUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnView As System.Windows.Forms.Button
        Friend WithEvents cboOpenOrders As C1.Win.C1List.C1Combo
        Friend WithEvents btnGo As System.Windows.Forms.Button
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents dtpDockRecDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnWaitingToBeRec As System.Windows.Forms.Button
        Friend WithEvents txtRcvd As System.Windows.Forms.TextBox
        Friend WithEvents btnLanUseOnly As System.Windows.Forms.Button
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents cboBoxType As C1.Win.C1List.C1Combo
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents pnlBox As System.Windows.Forms.Panel
        Friend WithEvents lblInWrtyBoxQty As System.Windows.Forms.Label
        Friend WithEvents lblInWrtyBoxID As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents lblOutWrtyBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblDisposition As System.Windows.Forms.Label
        Friend WithEvents gbOutWrty As System.Windows.Forms.GroupBox
        Friend WithEvents grbInWrty As System.Windows.Forms.GroupBox
        Friend WithEvents gbInWrtyExpLess30Days As System.Windows.Forms.GroupBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents lblWrtyExpediteQty As System.Windows.Forms.Label
        Friend WithEvents lblWrtyExpedite As System.Windows.Forms.Label
        Friend WithEvents btnRefreshRecNo As System.Windows.Forms.Button
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents txtMaxBoxQty As System.Windows.Forms.TextBox
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpReceiving As System.Windows.Forms.TabPage
        Friend WithEvents tpDicrepancyReceiving As System.Windows.Forms.TabPage
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents cboDiscrepancyOrder As C1.Win.C1List.C1Combo
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents txtDiscrepancyIMEI As System.Windows.Forms.TextBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents dbgDisRecHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label27 As System.Windows.Forms.Label
        Friend WithEvents pnlHistoryByIMEI As System.Windows.Forms.Panel
        Friend WithEvents pnlHistoryByRecptDate As System.Windows.Forms.Panel
        Friend WithEvents Label28 As System.Windows.Forms.Label
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents btnSearchHistory As System.Windows.Forms.Button
        Friend WithEvents rbtnHistoryByIMEI As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnHistoryByRecptDate As System.Windows.Forms.RadioButton
        Friend WithEvents txtHistoryByIMEI As System.Windows.Forms.TextBox
        Friend WithEvents dtpHistoryByStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpHistoryByEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboDiscModels As C1.Win.C1List.C1Combo
        Friend WithEvents btnCloseIWBox As System.Windows.Forms.Button
        Friend WithEvents btnCloseIWEBox As System.Windows.Forms.Button
        Friend WithEvents btnCloseOWBox As System.Windows.Forms.Button
        Friend WithEvents lblDiscWrtyStatus As System.Windows.Forms.Label
        Friend WithEvents lblInWrtyBoxID_Disc As System.Windows.Forms.Label
        Friend WithEvents lblWrtyExpediteQty_Disc As System.Windows.Forms.Label
        Friend WithEvents lblWrtyExpedite_Disc As System.Windows.Forms.Label
        Friend WithEvents lblOutWrtyBoxQty_Disc As System.Windows.Forms.Label
        Friend WithEvents lblInWrtyBoxQty_Disc As System.Windows.Forms.Label
        Friend WithEvents lblOutWrtyBoxID_Disc As System.Windows.Forms.Label
        Friend WithEvents lblOutWrtyBoxID As System.Windows.Forms.Label
        Friend WithEvents chkNoEDIDev944 As System.Windows.Forms.CheckBox
        Friend WithEvents pnlDisRec As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRec))
            Me.lblHeader = New System.Windows.Forms.Label()
            Me.pnlFileInfo = New System.Windows.Forms.Panel()
            Me.btnRefreshRecNo = New System.Windows.Forms.Button()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblRejected = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblAccepted = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblFileQty = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtRcvd = New System.Windows.Forms.TextBox()
            Me.lblInWrtyBoxQty = New System.Windows.Forms.Label()
            Me.lblInWrtyBoxID = New System.Windows.Forms.Label()
            Me.lblMsg = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnCloseRMA = New System.Windows.Forms.Button()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.pnlBox = New System.Windows.Forms.Panel()
            Me.gbInWrtyExpLess30Days = New System.Windows.Forms.GroupBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.lblWrtyExpediteQty = New System.Windows.Forms.Label()
            Me.lblWrtyExpedite = New System.Windows.Forms.Label()
            Me.gbOutWrty = New System.Windows.Forms.GroupBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.lblOutWrtyBoxQty = New System.Windows.Forms.Label()
            Me.lblOutWrtyBoxID = New System.Windows.Forms.Label()
            Me.grbInWrty = New System.Windows.Forms.GroupBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cboBoxType = New C1.Win.C1List.C1Combo()
            Me.btnGo = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtMaxBoxQty = New System.Windows.Forms.TextBox()
            Me.btnWaitingToBeRec = New System.Windows.Forms.Button()
            Me.btnView = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dtpDockRecDate = New System.Windows.Forms.DateTimePicker()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblDisposition = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboOpenOrders = New C1.Win.C1List.C1Combo()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.dbgRecUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnLanUseOnly = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpReceiving = New System.Windows.Forms.TabPage()
            Me.tpDicrepancyReceiving = New System.Windows.Forms.TabPage()
            Me.chkNoEDIDev944 = New System.Windows.Forms.CheckBox()
            Me.lblDiscWrtyStatus = New System.Windows.Forms.Label()
            Me.btnSearchHistory = New System.Windows.Forms.Button()
            Me.pnlHistoryByRecptDate = New System.Windows.Forms.Panel()
            Me.dtpHistoryByEndDate = New System.Windows.Forms.DateTimePicker()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.dtpHistoryByStartDate = New System.Windows.Forms.DateTimePicker()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.pnlHistoryByIMEI = New System.Windows.Forms.Panel()
            Me.txtHistoryByIMEI = New System.Windows.Forms.TextBox()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.rbtnHistoryByRecptDate = New System.Windows.Forms.RadioButton()
            Me.rbtnHistoryByIMEI = New System.Windows.Forms.RadioButton()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnCloseIWEBox = New System.Windows.Forms.Button()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.lblWrtyExpediteQty_Disc = New System.Windows.Forms.Label()
            Me.lblWrtyExpedite_Disc = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.btnCloseOWBox = New System.Windows.Forms.Button()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.lblOutWrtyBoxQty_Disc = New System.Windows.Forms.Label()
            Me.lblOutWrtyBoxID_Disc = New System.Windows.Forms.Label()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.btnCloseIWBox = New System.Windows.Forms.Button()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.lblInWrtyBoxQty_Disc = New System.Windows.Forms.Label()
            Me.lblInWrtyBoxID_Disc = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtDiscrepancyIMEI = New System.Windows.Forms.TextBox()
            Me.dbgDisRecHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboDiscModels = New C1.Win.C1List.C1Combo()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.cboDiscrepancyOrder = New C1.Win.C1List.C1Combo()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.pnlDisRec = New System.Windows.Forms.Panel()
            Me.pnlFileInfo.SuspendLayout()
            Me.Panel6.SuspendLayout()
            Me.pnlBox.SuspendLayout()
            Me.gbInWrtyExpLess30Days.SuspendLayout()
            Me.gbOutWrty.SuspendLayout()
            Me.grbInWrty.SuspendLayout()
            CType(Me.cboBoxType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.cboOpenOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpReceiving.SuspendLayout()
            Me.tpDicrepancyReceiving.SuspendLayout()
            Me.pnlHistoryByRecptDate.SuspendLayout()
            Me.pnlHistoryByIMEI.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            CType(Me.dbgDisRecHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboDiscModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboDiscrepancyOrder, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlDisRec.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.Black
            Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
            Me.lblHeader.Location = New System.Drawing.Point(1, 1)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(266, 79)
            Me.lblHeader.TabIndex = 111
            Me.lblHeader.Text = "TRACFONE RECEIVING"
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pnlFileInfo
            '
            Me.pnlFileInfo.BackColor = System.Drawing.Color.Black
            Me.pnlFileInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFileInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshRecNo, Me.Label11, Me.lblRejected, Me.Label9, Me.lblAccepted, Me.Label7, Me.lblFileQty, Me.Label6, Me.txtRcvd})
            Me.pnlFileInfo.Location = New System.Drawing.Point(637, 121)
            Me.pnlFileInfo.Name = "pnlFileInfo"
            Me.pnlFileInfo.Size = New System.Drawing.Size(310, 168)
            Me.pnlFileInfo.TabIndex = 2
            '
            'btnRefreshRecNo
            '
            Me.btnRefreshRecNo.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshRecNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshRecNo.ForeColor = System.Drawing.Color.White
            Me.btnRefreshRecNo.Location = New System.Drawing.Point(216, 136)
            Me.btnRefreshRecNo.Name = "btnRefreshRecNo"
            Me.btnRefreshRecNo.Size = New System.Drawing.Size(88, 24)
            Me.btnRefreshRecNo.TabIndex = 113
            Me.btnRefreshRecNo.Text = "Refresh"
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Lime
            Me.Label11.Location = New System.Drawing.Point(0, 96)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(224, 31)
            Me.Label11.TabIndex = 89
            Me.Label11.Text = "Total Received :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRejected
            '
            Me.lblRejected.BackColor = System.Drawing.Color.Transparent
            Me.lblRejected.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRejected.ForeColor = System.Drawing.Color.Lime
            Me.lblRejected.Location = New System.Drawing.Point(224, 63)
            Me.lblRejected.Name = "lblRejected"
            Me.lblRejected.Size = New System.Drawing.Size(80, 31)
            Me.lblRejected.TabIndex = 88
            Me.lblRejected.Text = "0"
            Me.lblRejected.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Lime
            Me.Label9.Location = New System.Drawing.Point(16, 63)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(208, 31)
            Me.Label9.TabIndex = 87
            Me.Label9.Text = "Rejected :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAccepted
            '
            Me.lblAccepted.BackColor = System.Drawing.Color.Transparent
            Me.lblAccepted.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccepted.ForeColor = System.Drawing.Color.Lime
            Me.lblAccepted.Location = New System.Drawing.Point(224, 27)
            Me.lblAccepted.Name = "lblAccepted"
            Me.lblAccepted.Size = New System.Drawing.Size(80, 31)
            Me.lblAccepted.TabIndex = 86
            Me.lblAccepted.Text = "0"
            Me.lblAccepted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Lime
            Me.Label7.Location = New System.Drawing.Point(16, 27)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(208, 31)
            Me.Label7.TabIndex = 85
            Me.Label7.Text = "Accepted :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFileQty
            '
            Me.lblFileQty.BackColor = System.Drawing.Color.Transparent
            Me.lblFileQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFileQty.ForeColor = System.Drawing.Color.Lime
            Me.lblFileQty.Location = New System.Drawing.Point(224, 0)
            Me.lblFileQty.Name = "lblFileQty"
            Me.lblFileQty.Size = New System.Drawing.Size(80, 24)
            Me.lblFileQty.TabIndex = 84
            Me.lblFileQty.Text = "0"
            Me.lblFileQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Lime
            Me.Label6.Location = New System.Drawing.Point(16, 0)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(208, 24)
            Me.Label6.TabIndex = 83
            Me.Label6.Text = "Devices in file :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRcvd
            '
            Me.txtRcvd.BackColor = System.Drawing.Color.Black
            Me.txtRcvd.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtRcvd.Enabled = False
            Me.txtRcvd.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRcvd.ForeColor = System.Drawing.Color.Lime
            Me.txtRcvd.Location = New System.Drawing.Point(221, 96)
            Me.txtRcvd.Name = "txtRcvd"
            Me.txtRcvd.Size = New System.Drawing.Size(80, 31)
            Me.txtRcvd.TabIndex = 112
            Me.txtRcvd.Text = "0"
            Me.txtRcvd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblInWrtyBoxQty
            '
            Me.lblInWrtyBoxQty.BackColor = System.Drawing.Color.Black
            Me.lblInWrtyBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInWrtyBoxQty.ForeColor = System.Drawing.Color.Lime
            Me.lblInWrtyBoxQty.Location = New System.Drawing.Point(48, 39)
            Me.lblInWrtyBoxQty.Name = "lblInWrtyBoxQty"
            Me.lblInWrtyBoxQty.Size = New System.Drawing.Size(96, 16)
            Me.lblInWrtyBoxQty.TabIndex = 84
            Me.lblInWrtyBoxQty.Text = "0"
            Me.lblInWrtyBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblInWrtyBoxID
            '
            Me.lblInWrtyBoxID.BackColor = System.Drawing.Color.Black
            Me.lblInWrtyBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInWrtyBoxID.ForeColor = System.Drawing.Color.Lime
            Me.lblInWrtyBoxID.Location = New System.Drawing.Point(7, 19)
            Me.lblInWrtyBoxID.Name = "lblInWrtyBoxID"
            Me.lblInWrtyBoxID.Size = New System.Drawing.Size(136, 16)
            Me.lblInWrtyBoxID.TabIndex = 85
            Me.lblInWrtyBoxID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblMsg
            '
            Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
            Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMsg.ForeColor = System.Drawing.Color.White
            Me.lblMsg.Location = New System.Drawing.Point(265, 1)
            Me.lblMsg.Name = "lblMsg"
            Me.lblMsg.Size = New System.Drawing.Size(680, 79)
            Me.lblMsg.TabIndex = 1
            Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(-24, 7)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(130, 21)
            Me.Label5.TabIndex = 83
            Me.Label5.Text = "Order Number :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'btnCloseRMA
            '
            Me.btnCloseRMA.BackColor = System.Drawing.Color.Navy
            Me.btnCloseRMA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseRMA.ForeColor = System.Drawing.Color.White
            Me.btnCloseRMA.Location = New System.Drawing.Point(494, 35)
            Me.btnCloseRMA.Name = "btnCloseRMA"
            Me.btnCloseRMA.Size = New System.Drawing.Size(136, 24)
            Me.btnCloseRMA.TabIndex = 2
            Me.btnCloseRMA.Text = "CLOSE ORDER"
            Me.btnCloseRMA.Visible = False
            '
            'Panel6
            '
            Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlBox, Me.btnWaitingToBeRec, Me.btnView, Me.btnCloseRMA, Me.Panel2, Me.btnReprintBoxLabel})
            Me.Panel6.Location = New System.Drawing.Point(1, 121)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(638, 168)
            Me.Panel6.TabIndex = 1
            '
            'pnlBox
            '
            Me.pnlBox.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbInWrtyExpLess30Days, Me.gbOutWrty, Me.grbInWrty, Me.Label10, Me.cboBoxType, Me.btnGo, Me.Label3, Me.txtIMEI, Me.Label14, Me.txtMaxBoxQty})
            Me.pnlBox.Location = New System.Drawing.Point(2, 33)
            Me.pnlBox.Name = "pnlBox"
            Me.pnlBox.Size = New System.Drawing.Size(486, 128)
            Me.pnlBox.TabIndex = 1
            '
            'gbInWrtyExpLess30Days
            '
            Me.gbInWrtyExpLess30Days.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label13, Me.lblWrtyExpediteQty, Me.lblWrtyExpedite})
            Me.gbInWrtyExpLess30Days.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbInWrtyExpLess30Days.ForeColor = System.Drawing.Color.White
            Me.gbInWrtyExpLess30Days.Location = New System.Drawing.Point(168, 61)
            Me.gbInWrtyExpLess30Days.Name = "gbInWrtyExpLess30Days"
            Me.gbInWrtyExpLess30Days.Size = New System.Drawing.Size(152, 64)
            Me.gbInWrtyExpLess30Days.TabIndex = 93
            Me.gbInWrtyExpLess30Days.TabStop = False
            Me.gbInWrtyExpLess30Days.Text = "Warranty Expedite"
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.Black
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.Lime
            Me.Label13.Location = New System.Drawing.Point(7, 39)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(41, 16)
            Me.Label13.TabIndex = 86
            Me.Label13.Text = "Qty:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWrtyExpediteQty
            '
            Me.lblWrtyExpediteQty.BackColor = System.Drawing.Color.Black
            Me.lblWrtyExpediteQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyExpediteQty.ForeColor = System.Drawing.Color.Lime
            Me.lblWrtyExpediteQty.Location = New System.Drawing.Point(48, 39)
            Me.lblWrtyExpediteQty.Name = "lblWrtyExpediteQty"
            Me.lblWrtyExpediteQty.Size = New System.Drawing.Size(96, 16)
            Me.lblWrtyExpediteQty.TabIndex = 84
            Me.lblWrtyExpediteQty.Text = "0"
            Me.lblWrtyExpediteQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWrtyExpedite
            '
            Me.lblWrtyExpedite.BackColor = System.Drawing.Color.Black
            Me.lblWrtyExpedite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyExpedite.ForeColor = System.Drawing.Color.Red
            Me.lblWrtyExpedite.Location = New System.Drawing.Point(7, 19)
            Me.lblWrtyExpedite.Name = "lblWrtyExpedite"
            Me.lblWrtyExpedite.Size = New System.Drawing.Size(136, 16)
            Me.lblWrtyExpedite.TabIndex = 85
            Me.lblWrtyExpedite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'gbOutWrty
            '
            Me.gbOutWrty.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label12, Me.lblOutWrtyBoxQty, Me.lblOutWrtyBoxID})
            Me.gbOutWrty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbOutWrty.ForeColor = System.Drawing.Color.White
            Me.gbOutWrty.Location = New System.Drawing.Point(328, 61)
            Me.gbOutWrty.Name = "gbOutWrty"
            Me.gbOutWrty.Size = New System.Drawing.Size(152, 64)
            Me.gbOutWrty.TabIndex = 92
            Me.gbOutWrty.TabStop = False
            Me.gbOutWrty.Text = "Out of Warranty"
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Black
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Lime
            Me.Label12.Location = New System.Drawing.Point(8, 39)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(40, 16)
            Me.Label12.TabIndex = 86
            Me.Label12.Text = "Qty:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOutWrtyBoxQty
            '
            Me.lblOutWrtyBoxQty.BackColor = System.Drawing.Color.Black
            Me.lblOutWrtyBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutWrtyBoxQty.ForeColor = System.Drawing.Color.Lime
            Me.lblOutWrtyBoxQty.Location = New System.Drawing.Point(48, 39)
            Me.lblOutWrtyBoxQty.Name = "lblOutWrtyBoxQty"
            Me.lblOutWrtyBoxQty.Size = New System.Drawing.Size(96, 16)
            Me.lblOutWrtyBoxQty.TabIndex = 84
            Me.lblOutWrtyBoxQty.Text = "0"
            Me.lblOutWrtyBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblOutWrtyBoxID
            '
            Me.lblOutWrtyBoxID.BackColor = System.Drawing.Color.Black
            Me.lblOutWrtyBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutWrtyBoxID.ForeColor = System.Drawing.Color.Lime
            Me.lblOutWrtyBoxID.Location = New System.Drawing.Point(8, 19)
            Me.lblOutWrtyBoxID.Name = "lblOutWrtyBoxID"
            Me.lblOutWrtyBoxID.Size = New System.Drawing.Size(136, 16)
            Me.lblOutWrtyBoxID.TabIndex = 85
            Me.lblOutWrtyBoxID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grbInWrty
            '
            Me.grbInWrty.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.lblInWrtyBoxQty, Me.lblInWrtyBoxID})
            Me.grbInWrty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbInWrty.ForeColor = System.Drawing.Color.White
            Me.grbInWrty.Location = New System.Drawing.Point(8, 61)
            Me.grbInWrty.Name = "grbInWrty"
            Me.grbInWrty.Size = New System.Drawing.Size(152, 64)
            Me.grbInWrty.TabIndex = 71
            Me.grbInWrty.TabStop = False
            Me.grbInWrty.Text = "In Warranty"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Black
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Lime
            Me.Label4.Location = New System.Drawing.Point(7, 39)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(41, 16)
            Me.Label4.TabIndex = 86
            Me.Label4.Text = "Qty:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(27, 5)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(80, 16)
            Me.Label10.TabIndex = 91
            Me.Label10.Text = "Box Type :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboBoxType
            '
            Me.cboBoxType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBoxType.AutoCompletion = True
            Me.cboBoxType.AutoDropDown = True
            Me.cboBoxType.AutoSelect = True
            Me.cboBoxType.Caption = ""
            Me.cboBoxType.CaptionHeight = 17
            Me.cboBoxType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBoxType.ColumnCaptionHeight = 17
            Me.cboBoxType.ColumnFooterHeight = 17
            Me.cboBoxType.ColumnHeaders = False
            Me.cboBoxType.ContentHeight = 15
            Me.cboBoxType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBoxType.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBoxType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBoxType.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBoxType.EditorHeight = 15
            Me.cboBoxType.Enabled = False
            Me.cboBoxType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBoxType.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboBoxType.ItemHeight = 15
            Me.cboBoxType.Location = New System.Drawing.Point(107, 4)
            Me.cboBoxType.MatchEntryTimeout = CType(2000, Long)
            Me.cboBoxType.MaxDropDownItems = CType(10, Short)
            Me.cboBoxType.MaxLength = 32767
            Me.cboBoxType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBoxType.Name = "cboBoxType"
            Me.cboBoxType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBoxType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBoxType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBoxType.Size = New System.Drawing.Size(221, 21)
            Me.cboBoxType.TabIndex = 3
            Me.cboBoxType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 9." & _
            "75pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Styl" & _
            "e9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;A" & _
            "lignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contro" & _
            "l;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.List" & _
            "BoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptio" & _
            "nHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
            "up=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><W" & _
            "idth>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Caption" & _
            "Style parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /" & _
            "><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style" & _
            "11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hi" & _
            "ghlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRow" & _
            "Style parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector""" & _
            " me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""No" & _
            "rmal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style par" & _
            "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
            "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
            "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
            "=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" m" & _
            "e=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Captio" & _
            "n"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplit" & _
            "s><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'btnGo
            '
            Me.btnGo.BackColor = System.Drawing.Color.Green
            Me.btnGo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGo.ForeColor = System.Drawing.Color.White
            Me.btnGo.Location = New System.Drawing.Point(336, 37)
            Me.btnGo.Name = "btnGo"
            Me.btnGo.Size = New System.Drawing.Size(31, 19)
            Me.btnGo.TabIndex = 2
            Me.btnGo.Text = "Go"
            Me.btnGo.Visible = False
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(12, 36)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 85
            Me.Label3.Text = "IMEI/MEID :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtIMEI
            '
            Me.txtIMEI.BackColor = System.Drawing.Color.Yellow
            Me.txtIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIMEI.Location = New System.Drawing.Point(107, 35)
            Me.txtIMEI.MaxLength = 25
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(221, 21)
            Me.txtIMEI.TabIndex = 1
            Me.txtIMEI.Text = ""
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Aqua
            Me.Label14.Location = New System.Drawing.Point(344, 6)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(96, 16)
            Me.Label14.TabIndex = 95
            Me.Label14.Text = "Max Box Qty:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMaxBoxQty
            '
            Me.txtMaxBoxQty.BackColor = System.Drawing.Color.AliceBlue
            Me.txtMaxBoxQty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMaxBoxQty.Location = New System.Drawing.Point(440, 4)
            Me.txtMaxBoxQty.MaxLength = 25
            Me.txtMaxBoxQty.Name = "txtMaxBoxQty"
            Me.txtMaxBoxQty.Size = New System.Drawing.Size(40, 21)
            Me.txtMaxBoxQty.TabIndex = 4
            Me.txtMaxBoxQty.Text = "90"
            Me.txtMaxBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnWaitingToBeRec
            '
            Me.btnWaitingToBeRec.BackColor = System.Drawing.Color.SteelBlue
            Me.btnWaitingToBeRec.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWaitingToBeRec.ForeColor = System.Drawing.Color.White
            Me.btnWaitingToBeRec.Location = New System.Drawing.Point(494, 99)
            Me.btnWaitingToBeRec.Name = "btnWaitingToBeRec"
            Me.btnWaitingToBeRec.Size = New System.Drawing.Size(136, 37)
            Me.btnWaitingToBeRec.TabIndex = 6
            Me.btnWaitingToBeRec.Text = "View To Be Receviced Units"
            Me.btnWaitingToBeRec.Visible = False
            '
            'btnView
            '
            Me.btnView.BackColor = System.Drawing.Color.SteelBlue
            Me.btnView.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnView.ForeColor = System.Drawing.Color.White
            Me.btnView.Location = New System.Drawing.Point(494, 67)
            Me.btnView.Name = "btnView"
            Me.btnView.Size = New System.Drawing.Size(136, 26)
            Me.btnView.TabIndex = 5
            Me.btnView.Text = "View Received Units"
            Me.btnView.Visible = False
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.dtpDockRecDate})
            Me.Panel2.Location = New System.Drawing.Point(2, 2)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(486, 30)
            Me.Panel2.TabIndex = 3
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(-7, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(114, 16)
            Me.Label2.TabIndex = 89
            Me.Label2.Text = "Dock Rec Date :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDockRecDate
            '
            Me.dtpDockRecDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpDockRecDate.Location = New System.Drawing.Point(107, 4)
            Me.dtpDockRecDate.Name = "dtpDockRecDate"
            Me.dtpDockRecDate.Size = New System.Drawing.Size(224, 20)
            Me.dtpDockRecDate.TabIndex = 1
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(494, 3)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(136, 26)
            Me.btnReprintBoxLabel.TabIndex = 4
            Me.btnReprintBoxLabel.Text = "Reprint Box Label"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDisposition, Me.Label1, Me.cboOpenOrders, Me.Label5, Me.lblModel, Me.Label8})
            Me.Panel1.Location = New System.Drawing.Point(1, 81)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(944, 39)
            Me.Panel1.TabIndex = 3
            '
            'lblDisposition
            '
            Me.lblDisposition.BackColor = System.Drawing.Color.White
            Me.lblDisposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDisposition.ForeColor = System.Drawing.Color.Blue
            Me.lblDisposition.Location = New System.Drawing.Point(824, 6)
            Me.lblDisposition.Name = "lblDisposition"
            Me.lblDisposition.Size = New System.Drawing.Size(112, 21)
            Me.lblDisposition.TabIndex = 91
            Me.lblDisposition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(708, 7)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 21)
            Me.Label1.TabIndex = 90
            Me.Label1.Text = "Box Disposition:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboOpenOrders
            '
            Me.cboOpenOrders.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenOrders.AutoCompletion = True
            Me.cboOpenOrders.AutoDropDown = True
            Me.cboOpenOrders.AutoSelect = True
            Me.cboOpenOrders.Caption = ""
            Me.cboOpenOrders.CaptionHeight = 17
            Me.cboOpenOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenOrders.ColumnCaptionHeight = 17
            Me.cboOpenOrders.ColumnFooterHeight = 17
            Me.cboOpenOrders.ColumnHeaders = False
            Me.cboOpenOrders.ContentHeight = 15
            Me.cboOpenOrders.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenOrders.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenOrders.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrders.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenOrders.EditorHeight = 15
            Me.cboOpenOrders.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboOpenOrders.ItemHeight = 15
            Me.cboOpenOrders.Location = New System.Drawing.Point(108, 6)
            Me.cboOpenOrders.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenOrders.MaxDropDownItems = CType(10, Short)
            Me.cboOpenOrders.MaxLength = 32767
            Me.cboOpenOrders.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenOrders.Name = "cboOpenOrders"
            Me.cboOpenOrders.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenOrders.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenOrders.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenOrders.Size = New System.Drawing.Size(224, 21)
            Me.cboOpenOrders.TabIndex = 1
            Me.cboOpenOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Blue
            Me.lblModel.Location = New System.Drawing.Point(464, 6)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(192, 21)
            Me.lblModel.TabIndex = 86
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(408, 7)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(56, 21)
            Me.Label8.TabIndex = 88
            Me.Label8.Text = "Model :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'dbgRecUnits
            '
            Me.dbgRecUnits.AllowUpdate = False
            Me.dbgRecUnits.AlternatingRows = True
            Me.dbgRecUnits.FilterBar = True
            Me.dbgRecUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRecUnits.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgRecUnits.Location = New System.Drawing.Point(1, 288)
            Me.dbgRecUnits.Name = "dbgRecUnits"
            Me.dbgRecUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRecUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRecUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgRecUnits.Size = New System.Drawing.Size(946, 240)
            Me.dbgRecUnits.TabIndex = 3
            Me.dbgRecUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>2" & _
            "36</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 942, 236<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 942, 236</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnLanUseOnly
            '
            Me.btnLanUseOnly.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnLanUseOnly.Location = New System.Drawing.Point(864, 584)
            Me.btnLanUseOnly.Name = "btnLanUseOnly"
            Me.btnLanUseOnly.Size = New System.Drawing.Size(104, 16)
            Me.btnLanUseOnly.TabIndex = 112
            Me.btnLanUseOnly.TabStop = False
            Me.btnLanUseOnly.Text = "Special Billing"
            Me.btnLanUseOnly.Visible = False
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpReceiving, Me.tpDicrepancyReceiving})
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(984, 576)
            Me.TabControl1.TabIndex = 113
            '
            'tpReceiving
            '
            Me.tpReceiving.BackColor = System.Drawing.Color.SteelBlue
            Me.tpReceiving.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.dbgRecUnits, Me.pnlFileInfo, Me.lblMsg, Me.lblHeader, Me.Panel6})
            Me.tpReceiving.Location = New System.Drawing.Point(4, 22)
            Me.tpReceiving.Name = "tpReceiving"
            Me.tpReceiving.Size = New System.Drawing.Size(952, 550)
            Me.tpReceiving.TabIndex = 0
            Me.tpReceiving.Text = "Receiving"
            '
            'tpDicrepancyReceiving
            '
            Me.tpDicrepancyReceiving.BackColor = System.Drawing.Color.SteelBlue
            Me.tpDicrepancyReceiving.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDisRec})
            Me.tpDicrepancyReceiving.Location = New System.Drawing.Point(4, 22)
            Me.tpDicrepancyReceiving.Name = "tpDicrepancyReceiving"
            Me.tpDicrepancyReceiving.Size = New System.Drawing.Size(976, 550)
            Me.tpDicrepancyReceiving.TabIndex = 1
            Me.tpDicrepancyReceiving.Text = "Discrepancy Receiving"
            '
            'chkNoEDIDev944
            '
            Me.chkNoEDIDev944.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoEDIDev944.ForeColor = System.Drawing.Color.Red
            Me.chkNoEDIDev944.Location = New System.Drawing.Point(38, 40)
            Me.chkNoEDIDev944.Name = "chkNoEDIDev944"
            Me.chkNoEDIDev944.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkNoEDIDev944.Size = New System.Drawing.Size(128, 24)
            Me.chkNoEDIDev944.TabIndex = 3
            Me.chkNoEDIDev944.Tag = "5654"
            Me.chkNoEDIDev944.Text = "  Exclude EDI"
            '
            'lblDiscWrtyStatus
            '
            Me.lblDiscWrtyStatus.BackColor = System.Drawing.Color.SteelBlue
            Me.lblDiscWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDiscWrtyStatus.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDiscWrtyStatus.ForeColor = System.Drawing.Color.White
            Me.lblDiscWrtyStatus.Location = New System.Drawing.Point(712, 8)
            Me.lblDiscWrtyStatus.Name = "lblDiscWrtyStatus"
            Me.lblDiscWrtyStatus.Size = New System.Drawing.Size(224, 56)
            Me.lblDiscWrtyStatus.TabIndex = 103
            Me.lblDiscWrtyStatus.Text = "Out of Warranty"
            Me.lblDiscWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSearchHistory
            '
            Me.btnSearchHistory.BackColor = System.Drawing.Color.Green
            Me.btnSearchHistory.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSearchHistory.ForeColor = System.Drawing.Color.White
            Me.btnSearchHistory.Location = New System.Drawing.Point(864, 152)
            Me.btnSearchHistory.Name = "btnSearchHistory"
            Me.btnSearchHistory.Size = New System.Drawing.Size(64, 32)
            Me.btnSearchHistory.TabIndex = 11
            Me.btnSearchHistory.Text = "Search"
            '
            'pnlHistoryByRecptDate
            '
            Me.pnlHistoryByRecptDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpHistoryByEndDate, Me.Label29, Me.dtpHistoryByStartDate, Me.Label28})
            Me.pnlHistoryByRecptDate.Location = New System.Drawing.Point(424, 144)
            Me.pnlHistoryByRecptDate.Name = "pnlHistoryByRecptDate"
            Me.pnlHistoryByRecptDate.Size = New System.Drawing.Size(432, 40)
            Me.pnlHistoryByRecptDate.TabIndex = 10
            Me.pnlHistoryByRecptDate.Visible = False
            '
            'dtpHistoryByEndDate
            '
            Me.dtpHistoryByEndDate.Location = New System.Drawing.Point(224, 17)
            Me.dtpHistoryByEndDate.Name = "dtpHistoryByEndDate"
            Me.dtpHistoryByEndDate.TabIndex = 2
            '
            'Label29
            '
            Me.Label29.BackColor = System.Drawing.Color.Transparent
            Me.Label29.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label29.ForeColor = System.Drawing.Color.White
            Me.Label29.Location = New System.Drawing.Point(224, 1)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(96, 16)
            Me.Label29.TabIndex = 109
            Me.Label29.Text = "End :"
            Me.Label29.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'dtpHistoryByStartDate
            '
            Me.dtpHistoryByStartDate.Location = New System.Drawing.Point(0, 17)
            Me.dtpHistoryByStartDate.Name = "dtpHistoryByStartDate"
            Me.dtpHistoryByStartDate.TabIndex = 1
            '
            'Label28
            '
            Me.Label28.BackColor = System.Drawing.Color.Transparent
            Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label28.ForeColor = System.Drawing.Color.White
            Me.Label28.Location = New System.Drawing.Point(0, 1)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(96, 16)
            Me.Label28.TabIndex = 107
            Me.Label28.Text = "Start :"
            Me.Label28.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'pnlHistoryByIMEI
            '
            Me.pnlHistoryByIMEI.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtHistoryByIMEI, Me.Label27})
            Me.pnlHistoryByIMEI.Location = New System.Drawing.Point(312, 144)
            Me.pnlHistoryByIMEI.Name = "pnlHistoryByIMEI"
            Me.pnlHistoryByIMEI.Size = New System.Drawing.Size(192, 40)
            Me.pnlHistoryByIMEI.TabIndex = 9
            Me.pnlHistoryByIMEI.Visible = False
            '
            'txtHistoryByIMEI
            '
            Me.txtHistoryByIMEI.BackColor = System.Drawing.Color.White
            Me.txtHistoryByIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtHistoryByIMEI.Location = New System.Drawing.Point(9, 17)
            Me.txtHistoryByIMEI.MaxLength = 25
            Me.txtHistoryByIMEI.Name = "txtHistoryByIMEI"
            Me.txtHistoryByIMEI.Size = New System.Drawing.Size(168, 21)
            Me.txtHistoryByIMEI.TabIndex = 1
            Me.txtHistoryByIMEI.Text = ""
            '
            'Label27
            '
            Me.Label27.BackColor = System.Drawing.Color.Transparent
            Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label27.ForeColor = System.Drawing.Color.White
            Me.Label27.Location = New System.Drawing.Point(9, 1)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(96, 16)
            Me.Label27.TabIndex = 106
            Me.Label27.Text = "IMEI/MEID :"
            Me.Label27.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'rbtnHistoryByRecptDate
            '
            Me.rbtnHistoryByRecptDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnHistoryByRecptDate.ForeColor = System.Drawing.Color.White
            Me.rbtnHistoryByRecptDate.Location = New System.Drawing.Point(136, 160)
            Me.rbtnHistoryByRecptDate.Name = "rbtnHistoryByRecptDate"
            Me.rbtnHistoryByRecptDate.Size = New System.Drawing.Size(168, 24)
            Me.rbtnHistoryByRecptDate.TabIndex = 8
            Me.rbtnHistoryByRecptDate.Text = "History by Received Date"
            '
            'rbtnHistoryByIMEI
            '
            Me.rbtnHistoryByIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnHistoryByIMEI.ForeColor = System.Drawing.Color.White
            Me.rbtnHistoryByIMEI.Location = New System.Drawing.Point(8, 160)
            Me.rbtnHistoryByIMEI.Name = "rbtnHistoryByIMEI"
            Me.rbtnHistoryByIMEI.Size = New System.Drawing.Size(112, 24)
            Me.rbtnHistoryByIMEI.TabIndex = 7
            Me.rbtnHistoryByIMEI.Text = "History by IMEI"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseIWEBox, Me.Label16, Me.lblWrtyExpediteQty_Disc, Me.lblWrtyExpedite_Disc})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(336, 72)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(272, 64)
            Me.GroupBox1.TabIndex = 6
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Warranty Expedite"
            '
            'btnCloseIWEBox
            '
            Me.btnCloseIWEBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseIWEBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseIWEBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseIWEBox.Location = New System.Drawing.Point(200, 24)
            Me.btnCloseIWEBox.Name = "btnCloseIWEBox"
            Me.btnCloseIWEBox.Size = New System.Drawing.Size(64, 32)
            Me.btnCloseIWEBox.TabIndex = 1
            Me.btnCloseIWEBox.Text = "Close Box"
            '
            'Label16
            '
            Me.Label16.BackColor = System.Drawing.Color.Black
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Lime
            Me.Label16.Location = New System.Drawing.Point(7, 39)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(41, 16)
            Me.Label16.TabIndex = 86
            Me.Label16.Text = "Qty:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWrtyExpediteQty_Disc
            '
            Me.lblWrtyExpediteQty_Disc.BackColor = System.Drawing.Color.Black
            Me.lblWrtyExpediteQty_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyExpediteQty_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblWrtyExpediteQty_Disc.Location = New System.Drawing.Point(48, 39)
            Me.lblWrtyExpediteQty_Disc.Name = "lblWrtyExpediteQty_Disc"
            Me.lblWrtyExpediteQty_Disc.Size = New System.Drawing.Size(144, 16)
            Me.lblWrtyExpediteQty_Disc.TabIndex = 84
            Me.lblWrtyExpediteQty_Disc.Text = "0"
            Me.lblWrtyExpediteQty_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWrtyExpedite_Disc
            '
            Me.lblWrtyExpedite_Disc.BackColor = System.Drawing.Color.Black
            Me.lblWrtyExpedite_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyExpedite_Disc.ForeColor = System.Drawing.Color.Red
            Me.lblWrtyExpedite_Disc.Location = New System.Drawing.Point(7, 19)
            Me.lblWrtyExpedite_Disc.Name = "lblWrtyExpedite_Disc"
            Me.lblWrtyExpedite_Disc.Size = New System.Drawing.Size(185, 16)
            Me.lblWrtyExpedite_Disc.TabIndex = 85
            Me.lblWrtyExpedite_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseOWBox, Me.Label21, Me.lblOutWrtyBoxQty_Disc, Me.lblOutWrtyBoxID_Disc})
            Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(664, 72)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(272, 64)
            Me.GroupBox2.TabIndex = 7
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Out of Warranty"
            '
            'btnCloseOWBox
            '
            Me.btnCloseOWBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseOWBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseOWBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseOWBox.Location = New System.Drawing.Point(200, 24)
            Me.btnCloseOWBox.Name = "btnCloseOWBox"
            Me.btnCloseOWBox.Size = New System.Drawing.Size(64, 32)
            Me.btnCloseOWBox.TabIndex = 1
            Me.btnCloseOWBox.Text = "Close Box"
            '
            'Label21
            '
            Me.Label21.BackColor = System.Drawing.Color.Black
            Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.ForeColor = System.Drawing.Color.Lime
            Me.Label21.Location = New System.Drawing.Point(8, 39)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(40, 16)
            Me.Label21.TabIndex = 86
            Me.Label21.Text = "Qty:"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOutWrtyBoxQty_Disc
            '
            Me.lblOutWrtyBoxQty_Disc.BackColor = System.Drawing.Color.Black
            Me.lblOutWrtyBoxQty_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutWrtyBoxQty_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblOutWrtyBoxQty_Disc.Location = New System.Drawing.Point(48, 39)
            Me.lblOutWrtyBoxQty_Disc.Name = "lblOutWrtyBoxQty_Disc"
            Me.lblOutWrtyBoxQty_Disc.Size = New System.Drawing.Size(144, 16)
            Me.lblOutWrtyBoxQty_Disc.TabIndex = 84
            Me.lblOutWrtyBoxQty_Disc.Text = "0"
            Me.lblOutWrtyBoxQty_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblOutWrtyBoxID_Disc
            '
            Me.lblOutWrtyBoxID_Disc.BackColor = System.Drawing.Color.Black
            Me.lblOutWrtyBoxID_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutWrtyBoxID_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblOutWrtyBoxID_Disc.Location = New System.Drawing.Point(8, 19)
            Me.lblOutWrtyBoxID_Disc.Name = "lblOutWrtyBoxID_Disc"
            Me.lblOutWrtyBoxID_Disc.Size = New System.Drawing.Size(184, 16)
            Me.lblOutWrtyBoxID_Disc.TabIndex = 85
            Me.lblOutWrtyBoxID_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseIWBox, Me.Label24, Me.lblInWrtyBoxQty_Disc, Me.lblInWrtyBoxID_Disc})
            Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox3.ForeColor = System.Drawing.Color.White
            Me.GroupBox3.Location = New System.Drawing.Point(8, 72)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(272, 64)
            Me.GroupBox3.TabIndex = 5
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "In Warranty"
            '
            'btnCloseIWBox
            '
            Me.btnCloseIWBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseIWBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseIWBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseIWBox.Location = New System.Drawing.Point(200, 22)
            Me.btnCloseIWBox.Name = "btnCloseIWBox"
            Me.btnCloseIWBox.Size = New System.Drawing.Size(64, 32)
            Me.btnCloseIWBox.TabIndex = 1
            Me.btnCloseIWBox.Text = "Close Box"
            '
            'Label24
            '
            Me.Label24.BackColor = System.Drawing.Color.Black
            Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label24.ForeColor = System.Drawing.Color.Lime
            Me.Label24.Location = New System.Drawing.Point(7, 39)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(41, 16)
            Me.Label24.TabIndex = 86
            Me.Label24.Text = "Qty:"
            Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblInWrtyBoxQty_Disc
            '
            Me.lblInWrtyBoxQty_Disc.BackColor = System.Drawing.Color.Black
            Me.lblInWrtyBoxQty_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInWrtyBoxQty_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblInWrtyBoxQty_Disc.Location = New System.Drawing.Point(48, 39)
            Me.lblInWrtyBoxQty_Disc.Name = "lblInWrtyBoxQty_Disc"
            Me.lblInWrtyBoxQty_Disc.Size = New System.Drawing.Size(144, 16)
            Me.lblInWrtyBoxQty_Disc.TabIndex = 84
            Me.lblInWrtyBoxQty_Disc.Text = "0"
            Me.lblInWrtyBoxQty_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblInWrtyBoxID_Disc
            '
            Me.lblInWrtyBoxID_Disc.BackColor = System.Drawing.Color.Black
            Me.lblInWrtyBoxID_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInWrtyBoxID_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblInWrtyBoxID_Disc.Location = New System.Drawing.Point(7, 19)
            Me.lblInWrtyBoxID_Disc.Name = "lblInWrtyBoxID_Disc"
            Me.lblInWrtyBoxID_Disc.Size = New System.Drawing.Size(185, 16)
            Me.lblInWrtyBoxID_Disc.TabIndex = 85
            Me.lblInWrtyBoxID_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.White
            Me.Label15.Location = New System.Drawing.Point(360, 40)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(96, 16)
            Me.Label15.TabIndex = 102
            Me.Label15.Text = "IMEI/MEID :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDiscrepancyIMEI
            '
            Me.txtDiscrepancyIMEI.BackColor = System.Drawing.Color.White
            Me.txtDiscrepancyIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDiscrepancyIMEI.Location = New System.Drawing.Point(464, 40)
            Me.txtDiscrepancyIMEI.MaxLength = 25
            Me.txtDiscrepancyIMEI.Name = "txtDiscrepancyIMEI"
            Me.txtDiscrepancyIMEI.Size = New System.Drawing.Size(224, 21)
            Me.txtDiscrepancyIMEI.TabIndex = 4
            Me.txtDiscrepancyIMEI.Text = ""
            '
            'dbgDisRecHistory
            '
            Me.dbgDisRecHistory.AllowUpdate = False
            Me.dbgDisRecHistory.AlternatingRows = True
            Me.dbgDisRecHistory.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgDisRecHistory.FilterBar = True
            Me.dbgDisRecHistory.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDisRecHistory.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgDisRecHistory.Location = New System.Drawing.Point(8, 200)
            Me.dbgDisRecHistory.Name = "dbgDisRecHistory"
            Me.dbgDisRecHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDisRecHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDisRecHistory.PreviewInfo.ZoomFactor = 75
            Me.dbgDisRecHistory.Size = New System.Drawing.Size(928, 320)
            Me.dbgDisRecHistory.TabIndex = 12
            Me.dbgDisRecHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
            "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "16</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 924, 316<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 924, 316</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'cboDiscModels
            '
            Me.cboDiscModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDiscModels.AutoCompletion = True
            Me.cboDiscModels.AutoDropDown = True
            Me.cboDiscModels.AutoSelect = True
            Me.cboDiscModels.Caption = ""
            Me.cboDiscModels.CaptionHeight = 17
            Me.cboDiscModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDiscModels.ColumnCaptionHeight = 17
            Me.cboDiscModels.ColumnFooterHeight = 17
            Me.cboDiscModels.ColumnHeaders = False
            Me.cboDiscModels.ContentHeight = 15
            Me.cboDiscModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDiscModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDiscModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDiscModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDiscModels.EditorHeight = 15
            Me.cboDiscModels.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboDiscModels.ItemHeight = 15
            Me.cboDiscModels.Location = New System.Drawing.Point(464, 8)
            Me.cboDiscModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboDiscModels.MaxDropDownItems = CType(10, Short)
            Me.cboDiscModels.MaxLength = 32767
            Me.cboDiscModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDiscModels.Name = "cboDiscModels"
            Me.cboDiscModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDiscModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDiscModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDiscModels.Size = New System.Drawing.Size(224, 21)
            Me.cboDiscModels.TabIndex = 2
            Me.cboDiscModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label20
            '
            Me.Label20.BackColor = System.Drawing.Color.Transparent
            Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.White
            Me.Label20.Location = New System.Drawing.Point(392, 8)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(64, 21)
            Me.Label20.TabIndex = 99
            Me.Label20.Text = "Model :"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboDiscrepancyOrder
            '
            Me.cboDiscrepancyOrder.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDiscrepancyOrder.AutoCompletion = True
            Me.cboDiscrepancyOrder.AutoDropDown = True
            Me.cboDiscrepancyOrder.AutoSelect = True
            Me.cboDiscrepancyOrder.Caption = ""
            Me.cboDiscrepancyOrder.CaptionHeight = 17
            Me.cboDiscrepancyOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDiscrepancyOrder.ColumnCaptionHeight = 17
            Me.cboDiscrepancyOrder.ColumnFooterHeight = 17
            Me.cboDiscrepancyOrder.ColumnHeaders = False
            Me.cboDiscrepancyOrder.ContentHeight = 15
            Me.cboDiscrepancyOrder.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDiscrepancyOrder.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDiscrepancyOrder.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDiscrepancyOrder.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDiscrepancyOrder.EditorHeight = 15
            Me.cboDiscrepancyOrder.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboDiscrepancyOrder.ItemHeight = 15
            Me.cboDiscrepancyOrder.Location = New System.Drawing.Point(152, 8)
            Me.cboDiscrepancyOrder.MatchEntryTimeout = CType(2000, Long)
            Me.cboDiscrepancyOrder.MaxDropDownItems = CType(10, Short)
            Me.cboDiscrepancyOrder.MaxLength = 32767
            Me.cboDiscrepancyOrder.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDiscrepancyOrder.Name = "cboDiscrepancyOrder"
            Me.cboDiscrepancyOrder.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDiscrepancyOrder.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDiscrepancyOrder.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDiscrepancyOrder.Size = New System.Drawing.Size(224, 21)
            Me.cboDiscrepancyOrder.TabIndex = 1
            Me.cboDiscrepancyOrder.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label17
            '
            Me.Label17.BackColor = System.Drawing.Color.Transparent
            Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(24, 8)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(120, 21)
            Me.Label17.TabIndex = 93
            Me.Label17.Text = "Order Number :"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'pnlDisRec
            '
            Me.pnlDisRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.btnSearchHistory, Me.chkNoEDIDev944, Me.Label17, Me.GroupBox3, Me.GroupBox1, Me.pnlHistoryByRecptDate, Me.Label20, Me.cboDiscrepancyOrder, Me.txtDiscrepancyIMEI, Me.Label15, Me.dbgDisRecHistory, Me.rbtnHistoryByRecptDate, Me.rbtnHistoryByIMEI, Me.pnlHistoryByIMEI, Me.lblDiscWrtyStatus, Me.cboDiscModels})
            Me.pnlDisRec.Location = New System.Drawing.Point(8, 0)
            Me.pnlDisRec.Name = "pnlDisRec"
            Me.pnlDisRec.Size = New System.Drawing.Size(952, 536)
            Me.pnlDisRec.TabIndex = 104
            Me.pnlDisRec.Visible = False
            '
            'frmRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1000, 606)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.btnLanUseOnly})
            Me.Name = "frmRec"
            Me.Text = "frmRec"
            Me.pnlFileInfo.ResumeLayout(False)
            Me.Panel6.ResumeLayout(False)
            Me.pnlBox.ResumeLayout(False)
            Me.gbInWrtyExpLess30Days.ResumeLayout(False)
            Me.gbOutWrty.ResumeLayout(False)
            Me.grbInWrty.ResumeLayout(False)
            CType(Me.cboBoxType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            CType(Me.cboOpenOrders, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpReceiving.ResumeLayout(False)
            Me.tpDicrepancyReceiving.ResumeLayout(False)
            Me.pnlHistoryByRecptDate.ResumeLayout(False)
            Me.pnlHistoryByIMEI.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            CType(Me.dbgDisRecHistory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboDiscModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboDiscrepancyOrder, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlDisRec.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Receiving"

        '******************************************************************
        Private Sub frmRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strSvrDateTime As String = ""
            Dim dt As DataTable

            Try
                'Me.btnLanUseOnly.Visible = True

                PSS.Core.Highlight.SetHighLight(Me)

                '*********************************
                'Load Open Order & Box Type
                '*********************************
                _booLoadDataToCtrl = True
                Me.LoadOpenWorkOrder()

                'Load box Type
                dt = Me._objTFRec.GetBoxTypeFlag()
                Misc.PopulateC1DropDownList(Me.cboBoxType, dt, "Desc", "ID")
                Me.cboBoxType.SelectedValue = 0
                '*********************************
                strSvrDateTime = Generic.GetMySqlDateTime("%Y-%m-%d")
                Me.dtpDockRecDate.Value = CDate(strSvrDateTime)
                Me.dtpDockRecDate.MaxDate = CDate(strSvrDateTime & " 23:00:00")
                '*********************************
                'Set Special permissions
                '*********************************
                If PSS.Core.ApplicationUser.GetPermission("TFViewUnRecUnits") > 0 Then _booEligibleToViewUnRecUnits = True
                If PSS.Core.ApplicationUser.GetPermission("TFRecDiscrepancyUnits") > 0 Then _booEligibleToProcessDiscrepancy = True
                If PSS.Core.ApplicationUser.GetPermission("TFRecDiscrUnitsIntoDev944") > 0 Then Me.pnlDisRec.Visible = True

                '*********************************
                'Get Tracfone Model list
                '*********************************
                Generic.DisposeDT(dt)
                dt = Me._objTFRec.GetTracfoneModels(True)
                Misc.PopulateC1DropDownList(Me.cboDiscModels, dt, "Model_Desc", "Model_ID")
                Me.cboDiscModels.SelectedValue = 0
                '**********************************************
                'Get Tracfone Blanket RMA ( forever open RMA)
                '**********************************************
                Generic.DisposeDT(dt)
                dt = Me._objTFRec.GetDiscrepancyRMA(True)
                Misc.PopulateC1DropDownList(Me.cboDiscrepancyOrder, dt, "WO_CustWO", "WO_ID")
                If dt.Rows.Count = 2 AndAlso dt.Select("WO_ID <> 0").Length > 0 Then Me.cboDiscrepancyOrder.SelectedValue = dt.Select("WO_ID <> 0")(0)("WO_ID")

                If Not IsNothing(Me.cboDiscrepancyOrder.DataSource) AndAlso Me.cboDiscrepancyOrder.SelectedValue > 0 Then PopulateOpenBoxes(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), False)
                '*********************************
                Me.dtpHistoryByStartDate.Value = CDate(strSvrDateTime)
                Me.dtpHistoryByEndDate.MaxDate = CDate(strSvrDateTime)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                _booLoadDataToCtrl = False
            End Try
        End Sub

        '******************************************************************
        Private Sub LoadOpenWorkOrder()
            Dim dt As DataTable
            Try
                '*********************************
                'Load Open Order
                '*********************************
                dt = Me._objTFRec.LoadOpenOrders()
                Misc.PopulateC1DropDownList(Me.cboOpenOrders, dt, "WO_CustWO", "WO_ID")
                Me.cboOpenOrders.SelectedValue = 0
                '*********************************
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
            Dim dt As DataTable
            Dim i As Integer

            Try
                If Me.cboOpenOrders.SelectedValue > 0 Then
                    dt = Me._objTFRec.GetReceivedDevices(Me.cboOpenOrders.SelectedValue)

                    With Me.dbgRecUnits
                        .DataSource = dt.DefaultView
                        .Visible = True
                        .AllowFilter = True
                        .FilterBar = True
                        .Caption = "Received Unit(s)"
                        .HeadingStyle.BackColor = Color.Black
                        .HeadingStyle.ForeColor = Color.Lime

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                            .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                            'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                            If dt.Columns(i).Caption = "SN" Then
                                .Splits(0).DisplayColumns(i).Frozen = True
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            ElseIf dt.Columns(i).Caption = "Receipt Date" Then
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            ElseIf dt.Columns(i).Caption = "Model" Or dt.Columns(i).Caption = "Cnt" Then
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            ElseIf dt.Columns(i).Caption = "Device_ID" Then
                                .Splits(0).DisplayColumns(i).Visible = False
                            Else
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            End If

                            If dt.Columns(i).Caption = "Model" Then
                                .Splits(0).DisplayColumns(i).Width = 170
                            ElseIf dt.Columns(i).Caption = "Cnt" Then
                                .Splits(0).DisplayColumns(i).Width = 50
                            ElseIf dt.Columns(i).Caption = "Discp Reason" Then
                                .Splits(0).DisplayColumns(i).Width = 200
                            Else
                                .Splits(0).DisplayColumns(i).Width = 120
                            End If
                        Next i
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnView_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnWaitingToBeRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitingToBeRec.Click
            Dim dt As DataTable
            Dim i As Integer

            Try
                If Me.cboOpenOrders.SelectedValue > 0 Then
                    dt = Me._objTFRec.GetToBeReceivedDevices(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))

                    With Me.dbgRecUnits
                        .DataSource = dt.DefaultView
                        .Visible = True
                        .AllowFilter = True
                        .FilterBar = True
                        .Caption = "To Be Receviced Unit(s)"
                        .HeadingStyle.BackColor = Color.Black
                        .HeadingStyle.ForeColor = Color.Lime

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                            .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                            'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                            If dt.Columns(i).Caption = "SN" Then
                                .Splits(0).DisplayColumns(i).Frozen = True
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            ElseIf dt.Columns(i).Caption = "Item#" Then
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            Else
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                                .Splits(0).DisplayColumns(i).Visible = False
                            End If

                            If dt.Columns(i).Caption = "SN" Then

                            ElseIf dt.Columns(i).Caption = "Item#" Then
                                .Splits(0).DisplayColumns(i).Width = 200
                            End If
                        Next i
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnView_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCloseRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseRMA.Click
            Dim dtMissingUnit As DataTable
            Dim iFileQty, iTotalRecQty, iReject, i As Integer
            Dim strDockDate, strSvrDateTime As String
            Dim booDiscrepancy As Boolean = False

            Try
                iFileQty = 0 : iTotalRecQty = 0 : iReject = 0 : i = 0

                If Me.cboOpenOrders.SelectedValue > 0 Then
                    If Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper = "PHONE" Then
                        '****************************
                        'Refresh Receive quantity
                        '****************************
                        Me.lblRejected.Text = Me._objTFRec.GetDiscrepancyDevices(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
                        Me.lblAccepted.Text = Me._objTFRec.GetReceivedDevicesCount(Me.cboOpenOrders.SelectedValue)
                        Me.txtRcvd.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboOpenOrders.SelectedValue)
                        '****************************
                    End If

                    If Me.txtRcvd.Text.Trim.Length > 0 Then iTotalRecQty = CInt(Me.txtRcvd.Text)
                    If Me.lblFileQty.Text.Trim.Length > 0 Then iFileQty = CInt(Me.lblFileQty.Text)
                    If Me.lblRejected.Text.Trim > 0 Then iReject = CInt(Me.lblRejected.Text)

                    If Me.cboOpenOrders.SelectedValue = 0 Then
                        MessageBox.Show("WO ID is missing for this RMA. Please re-scan RMA again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me.txtRcvd.Text.Trim.Length = 0 Or Me.txtRcvd.Text.Trim = "0" Then
                        MessageBox.Show("This Work Order is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf ((iFileQty - iTotalRecQty) <> 0 Or iReject > 0) AndAlso _booEligibleToProcessDiscrepancy = False Then
                        MessageBox.Show("This Work Order contains discrepancy unit. Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtIMEI.Focus()
                    Else
                        '****************************************
                        'Get confirmation on discrepancy units
                        '****************************************
                        If Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper = "PHONE" Then dtMissingUnit = Me._objTFRec.GetToBeReceivedDevices(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
                        If _booEligibleToProcessDiscrepancy = False Then
                            If (Not IsNothing(dtMissingUnit) AndAlso dtMissingUnit.Rows.Count > 0) Or (iFileQty - iTotalRecQty) <> 0 Or iReject > 0 Then
                                MessageBox.Show("This Work Order contains discrepancy unit. Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.txtIMEI.Focus() : Exit Sub
                            End If
                        Else
                            If Not IsNothing(dtMissingUnit) AndAlso dtMissingUnit.Rows.Count > 0 Then
                                booDiscrepancy = True
                                If MessageBox.Show(dtMissingUnit.Rows.Count & " unit(s) in this order have not yet received. Would you like to close order and mark them as MISSING UNIT?.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                            ElseIf ((iFileQty - iTotalRecQty) <> 0 Or iReject > 0) Then
                                booDiscrepancy = True
                                If MessageBox.Show("This Work Order contains discrepancy unit. Would you like to close it?.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
                            End If
                        End If
                        '****************************************

                        strSvrDateTime = Generic.GetMySqlDateTime("%Y-%m-%d")
                        If DateDiff(DateInterval.Day, CDate(strSvrDateTime), Me.dtpDockRecDate.Value) > 0 Then
                            MessageBox.Show("Invalid Dock Date! Dock Receive date can't be future.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.dtpDockRecDate.Focus()
                        ElseIf booDiscrepancy = False AndAlso MessageBox.Show("Are you sure you want to close order?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            'User canel on Confirm message
                        Else
                            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                            strDockDate = Format(Me.dtpDockRecDate.Value, "yyyy-MM-dd")
                            i = Me._objTFRec.CloseWO(Me.cboOpenOrders.SelectedValue, CInt(Me.txtRcvd.Text), PSS.Core.ApplicationUser.IDuser, strDockDate, booDiscrepancy, Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper)
                            If i > 0 Then
                                '************************************************
                                'Print Warehouse Box Label if work order is PHONE
                                '************************************************
                                If Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper = "PHONE" Then
                                    Me._objTFRec.CloseAllOpenWHBox(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
                                End If
                                '************************************************

                                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.ClearCtrls_GlobalVarsForNewRMA()
                                Me.Enabled = True : Me.cboOpenOrders.Focus()
                            End If  'Update return value
                        End If 'Validate Dock Date
                    End If  'Validate Order
                End If 'Order ID > 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub ClearCtrls_GlobalVarsForNewRMA()
            Try
                Me._booLoadDataToCtrl = True
                Me.LoadOpenWorkOrder() : _booLoadDataToCtrl = False
                Me.dbgRecUnits.DataSource = Nothing
                Me._iManufID = 0
                Me._iOrderModelID = 0
                Me._iTrayID = 0
                Me.txtIMEI.Text = ""
                Me.lblModel.Text = ""
                Me.lblFileQty.Text = ""
                Me.lblAccepted.Text = ""
                Me.lblRejected.Text = ""
                Me.txtRcvd.Text = ""
                Me.lblInWrtyBoxID.Text = ""
                Me.lblOutWrtyBoxID.Text = ""
                Me.lblInWrtyBoxQty.Text = "0"
                Me.lblOutWrtyBoxQty.Text = "0"
            Catch ex As Exception
                Throw ex
            Finally
                _booLoadDataToCtrl = False
            End Try
        End Sub

        '******************************************************************
        Private Sub cboOpenOrders_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOpenOrders.KeyUp
            Dim dt As DataTable
            Dim strBoxID As String = ""
            Dim strDockRec As String = ""

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboOpenOrders.SelectedValue > 0 Then
                        Me._iOrderModelID = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Model_ID")  ' dt.Rows(0)("Model_ID")
                        Me._iManufID = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Manuf_ID")  ' dt.Rows(0)("Model_ID")
                        Me.lblModel.Text = Generic.GetModelDesc(_iOrderModelID)  'dt.Rows(0)("Model_Desc")
                        Me.lblModel.Visible = True
                        Me.lblDisposition.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("IL_No").ToString.Trim.ToUpper
                        If Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper = "PHONE" AndAlso Me.lblDisposition.Text.StartsWith("COS") = False AndAlso Me.lblModel.Text.Trim.ToUpper.EndsWith("_FUN") = False Then MessageBox.Show("This order come in as functional failure but assigned to none functional model. Please verify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        If Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper = "PHONE" AndAlso Me.lblDisposition.Text.StartsWith("COS") = True AndAlso Me.lblModel.Text.Trim.ToUpper.EndsWith("_FUN") = True Then MessageBox.Show("This order come in as cosmetic but assigned to functional model. Please verify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        Me.lblFileQty.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("WO_Quantity") 'dt.Rows(0)("Model_Desc")
                        Me.lblRejected.Text = Me._objTFRec.GetDiscrepancyDevices(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
                        Me.lblAccepted.Text = Me._objTFRec.GetReceivedDevicesCount(Me.cboOpenOrders.SelectedValue)
                        Me.txtRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)

                        Me._iTrayID = PSS.Data.Buisness.Generic.GetTrayID(Me.cboOpenOrders.SelectedValue)
                        Me.btnCloseRMA.Visible = True
                        If Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper <> "PHONE" Then
                            Me.pnlBox.Visible = False
                            Me.btnView.Visible = False
                            Me.btnWaitingToBeRec.Visible = False
                            Me.lblAccepted.Text = Me.lblFileQty.Text
                            Me.txtRcvd.Text = Me.lblFileQty.Text
                            Me.txtRcvd.Enabled = True
                            Me.txtRcvd.SelectAll()
                            Me.txtRcvd.Focus()
                        Else 'Hanset order
                            If Me.lblDisposition.Text.StartsWith("COS") Then Me.cboBoxType.SelectedValue = 0 Else Me.cboBoxType.SelectedValue = 1
                            Me.PopulateOpenBoxes(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), True)
                            Me.pnlBox.Visible = True : Me.btnView.Visible = True
                            If _booEligibleToViewUnRecUnits = True Then Me.btnWaitingToBeRec.Visible = True Else Me.btnWaitingToBeRec.Visible = False
                            Me.txtRcvd.Enabled = False
                            Me.txtRcvd.BackColor = Color.Black : Me.txtRcvd.ForeColor = Color.Lime
                            Me.txtIMEI.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenOrders_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub cboOpenOrders_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenOrders.Enter
            Try
                Me._iManufID = 0
                Me._iOrderModelID = 0
                Me._iTrayID = 0
                Me.lblModel.Text = ""
                Me.txtIMEI.Text = ""
                Me.btnCloseRMA.Visible = False
                Me.btnView.Visible = False
                Me.btnWaitingToBeRec.Visible = False
                Me.dbgRecUnits.DataSource = Nothing
                Me.pnlBox.Visible = False
                Me.lblFileQty.Text = ""
                Me.lblAccepted.Text = ""
                Me.lblRejected.Text = ""
                Me.txtRcvd.Text = ""
                Me.lblMsg.BackColor = Color.SteelBlue
                Me.lblMsg.Text = ""
                Me.dtpDockRecDate.Enabled = True
                Me.lblInWrtyBoxID.Text = ""
                Me.lblOutWrtyBoxID.Text = ""
                Me.lblInWrtyBoxQty.Text = "0"
                Me.lblOutWrtyBoxQty.Text = "0"
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenOrders_Enter", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************************************************
        Private Sub PopulateOpenBoxes(ByVal iOrderID As Integer, ByVal booRegOrder As Boolean)
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                If booRegOrder = True Then
                    Me.lblInWrtyBoxID.Text = "" : Me.lblInWrtyBoxQty.Text = 0
                    Me.lblWrtyExpedite.Text = "" : Me.lblWrtyExpediteQty.Text = 0
                    Me.lblOutWrtyBoxID.Text = "" : Me.lblOutWrtyBoxQty.Text = 0
                Else
                    Me.lblInWrtyBoxID.Text = "" : Me.lblInWrtyBoxQty.Text = 0
                    Me.lblWrtyExpedite.Text = "" : Me.lblWrtyExpediteQty.Text = 0
                    Me.lblOutWrtyBoxID.Text = "" : Me.lblOutWrtyBoxQty.Text = 0
                End If

                dt = Me._objTFRec.GetWarehouseOpenBox(iOrderID)
                If dt.Rows.Count > 0 Then
                    If booRegOrder = True Then
                        For Each R1 In dt.Rows
                            If R1("WarrantyFlag").ToString = "0" Then
                                Me.lblOutWrtyBoxID.Text = R1("BoxID")
                                Me.lblOutWrtyBoxQty.Text = R1("Qty")
                            ElseIf R1("WrtyExpedite").ToString = "1" Then
                                Me.lblWrtyExpedite.Text = R1("BoxID")
                                Me.lblWrtyExpediteQty.Text = R1("Qty")
                            Else
                                Me.lblInWrtyBoxID.Text = R1("BoxID")
                                Me.lblInWrtyBoxQty.Text = R1("Qty")
                            End If
                        Next R1
                    Else
                        For Each R1 In dt.Rows
                            If R1("WarrantyFlag").ToString = "0" Then
                                Me.lblOutWrtyBoxID_Disc.Text = R1("BoxID")
                                Me.lblOutWrtyBoxQty_Disc.Text = R1("Qty")
                            ElseIf R1("WrtyExpedite").ToString = "1" Then
                                Me.lblWrtyExpedite_Disc.Text = R1("BoxID")
                                Me.lblWrtyExpediteQty_Disc.Text = R1("Qty")
                            Else
                                Me.lblInWrtyBoxID_Disc.Text = R1("BoxID")
                                Me.lblInWrtyBoxQty_Disc.Text = R1("Qty")
                            End If
                        Next R1

                        Me.cboDiscModels.SelectedValue = Convert.ToInt32(dt.Rows(0)("Model_ID"))
                        Me.cboDiscModels.Enabled = False
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Sub

        ''******************************************************************
        'Private Sub dbgRecUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgRecUnits.Click
        '    Try
        '        If Me.txtIMEI.Text.Trim.Length > 0 Then Me.ProcessTFSN()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "dbgRecUnits_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    End Try
        'End Sub

        '******************************************************************
        Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
            Dim booResult As Boolean = False
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtIMEI.Text.Trim.Length > 0 Then
                    booResult = ProcessTFSN()
                    If booResult = True Then Me.txtIMEI.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Function ProcessTFSN() As Boolean
            Dim dt As DataTable
            Dim iDeviceID, iManufWrty, i, iModelID, iWrtyExpInLess31Days, iManufacturingCountryID As Integer
            Dim dtBox As DataTable
            Dim strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, strWorkstation As String

            Try
                iDeviceID = 0 : iManufWrty = 0 : i = 0 : iModelID = 0 : iWrtyExpInLess31Days = 0 : iManufacturingCountryID = 0
                strLastDateInWrty = "" : strWrtyDateCode = "" : strMSN = "" : strAPC = "" : strWorkstation = ""
                Me.lblMsg.Text = ""
                Me.lblMsg.BackColor = Color.SteelBlue
                Me.lblWrtyExpedite.ForeColor = Color.Lime
                Me.lblInWrtyBoxID.ForeColor = Color.Lime
                Me.lblOutWrtyBoxID.ForeColor = Color.Lime

                If Me.cboOpenOrders.SelectedValue = 0 Then
                    MessageBox.Show("Please select Order Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.Text = "" : Me.txtIMEI.Focus()
                ElseIf Me._iManufID = 0 Then
                    MessageBox.Show("Manufacture is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.Text = "" : Me.cboOpenOrders.Focus()
                ElseIf Me._iOrderModelID = 0 Then
                    MessageBox.Show("Model is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.Text = "" : Me.cboOpenOrders.Focus()
                ElseIf Me._iTrayID = 0 Then
                    MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.Text = "" : Me.cboOpenOrders.Focus()
                ElseIf Me.cboBoxType.DataSource.Table.Select("[Desc] = '" & Me.cboBoxType.Text & "'").length = 0 Then
                    MessageBox.Show("Invalid selection of Box Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBoxType.SelectAll() : Me.cboBoxType.Focus()
                ElseIf Generic.IsSNInWIP(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, Me.txtIMEI.Text.Trim) = True Then
                    MessageBox.Show("IMEI is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.lblDisposition.Text = "FUN" AndAlso Me.lblModel.Text.Trim.ToUpper.EndsWith("_FUN") = False Then
                    MessageBox.Show("This order come in as functional failure but assigned to none functional model. Please verify with IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.txtMaxBoxQty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter maximum box quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMaxBoxQty.SelectAll() : Me.txtMaxBoxQty.Focus()
                    'ElseIf CInt(Me.lblBoxQty.Text) >= 90 Then
                    '    MessageBox.Show("Box Qty can't be greater than 90", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtIMEI.Text = "" : Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                Else
                    dt = Me._objTFRec.GetTFDeviceASNData(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), Me.txtIMEI.Text.Trim, False)
                    If dt.Rows.Count = 0 AndAlso _booEligibleToProcessDiscrepancy = False Then
                        MessageBox.Show("IMEI does not exist in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("IMEI is duplicated in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    ElseIf dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
                        MessageBox.Show("IMEI has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    Else
                        '*******************************************
                        'DISCREPANCY UNIT. IN BOX NOT IN FILE
                        '*******************************************
                        If dt.Rows.Count = 0 Then
                            If _booEligibleToProcessDiscrepancy = True Then
                                If MessageBox.Show("This IMEI does not exist in the file. Would you like to add this device into order?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                                Else
                                    Dim strCB_ItemNo As String = Me._objTFRec.GetCB_ItemNo(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
                                    dt = Me._objTFRec.AddExtraUnit(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Customer Item #"), strCB_ItemNo, Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("WO_CustWO"), Me.txtIMEI.Text.Trim.ToUpper, "Extra Unit", False, 0)
                                    If dt.Rows.Count = 0 Then
                                        MessageBox.Show("IMEI does not exist in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                                    ElseIf dt.Rows.Count > 1 Then
                                        MessageBox.Show("IMEI is duplicated in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                                    ElseIf Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
                                        MessageBox.Show("IMEI has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                                    End If
                                End If
                            Else
                                'SHOULD NEVER FALL INTO THIS SECTION
                                MessageBox.Show("IMEI does not exist in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                            End If
                        End If

                        ''***************************
                        ''Get model is GSM or CDMA?
                        ''***************************
                        'iGSM = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Model_GSM")

                        '***************************
                        'Default to incoming Model
                        '***************************
                        iModelID = Me._iOrderModelID
                        If iModelID = 0 Then Throw New Exception("Model ID is missing.")

                        '***************************
                        'collect warranty data
                        '***************************
                        If Me.CollectWarrantyData(Me._iManufID, iModelID, Me.txtIMEI.Text.Trim.ToUpper, Me.cboBoxType.SelectedValue, iManufWrty, iWrtyExpInLess31Days, strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, iManufacturingCountryID) = False Then
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                        End If

                        '*******************************
                        'Get Box
                        '*******************************
                        dtBox = Me._objTFRec.GetWHBox(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), Me.cboBoxType.SelectedValue, iManufWrty, iWrtyExpInLess31Days)

                        'Create new box
                        If dtBox.Rows.Count = 0 Then
                            dtBox = Me._objTFRec.CreateWarehouseBoxID(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), Me.cboBoxType.SelectedValue, iManufWrty, iModelID, iWrtyExpInLess31Days)
                            If dtBox.Rows.Count = 0 Then
                                MessageBox.Show("System had failed to create new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtIMEI.SelectAll() : Exit Function
                            End If
                        End If

                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        '************************************
                        'Receve device into database
                        '************************************
                        If Me.cboBoxType.SelectedValue = 1 Then strWorkstation = "BER SCREEN" Else strWorkstation = "WH-WIP"
                        iDeviceID = Me._objTFRec.ReceiveDeviceIntoWIP(dtBox, dt.Rows(0)("Item_ID"), Me.cboOpenOrders.SelectedValue, Me._iTrayID, Me.txtIMEI.Text.Trim, iModelID, iManufWrty, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, strMSN, strWrtyDateCode, strLastDateInWrty, strAPC, Me._iManufID, CInt(Me.txtMaxBoxQty.Text), iManufacturingCountryID, strWorkstation)

                        If iDeviceID > 0 Then
                            '*****************************
                            If iWrtyExpInLess31Days = 1 Then
                                If iManufWrty = 1 Then Me.lblMsg.Text = "IN WARRANTY"
                                Me.lblWrtyExpedite.Text = dtBox.Rows(0)("BoxID")
                                Me.lblWrtyExpediteQty.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblWrtyExpedite.ForeColor = Color.Red
                            ElseIf iManufWrty = 1 Then
                                Me.lblMsg.Text = "IN WARRANTY"
                                Me.lblInWrtyBoxID.Text = dtBox.Rows(0)("BoxID")
                                Me.lblInWrtyBoxQty.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblInWrtyBoxID.ForeColor = Color.Red
                            Else
                                Me.lblMsg.BackColor = Color.Purple
                                Me.lblMsg.Text = "OUT OF WARRANTY"
                                Me.lblOutWrtyBoxID.Text = dtBox.Rows(0)("BoxID")
                                Me.lblOutWrtyBoxQty.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblOutWrtyBoxID.ForeColor = Color.Red
                            End If

                            Me.txtIMEI.Text = ""
                            '******************************************************
                            'COMMENT THIS SO THE RECEIVING PROCESS COULD GO FASTER
                            '******************************************************
                            'Me.AutoBill(iDeviceID, iModelID)
                            '******************************************************
                            Me.Enabled = True : Me.txtIMEI.Focus()
                        End If
                        '************************************
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessTFSN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Function

        '******************************************************************
        Public Function CollectWarrantyData(ByVal iManufID As Integer, ByVal iModelID As Integer, ByVal strIMEI As String, ByVal iBoxType As Integer, _
                                             ByRef iManufWrty As Integer, ByRef iWrtyExpInLess31Days As Integer, ByRef strLastDateInWrty As String, _
                                             ByRef strWrtyDateCode As String, ByRef strMSN As String, ByRef strAPC As String, _
                                             ByRef iManufacturingCountryID As Integer) As Boolean
            Dim objCollectWrtyCode As System.Object
            Dim booReturnVal As Boolean = False
            Dim strToday As String = ""

            Try
                CollectWarrantyData = False
                '************************************
                'Get Date code if Manuf is Samsung
                '************************************
                If iManufID = 21 Then 'Samsung
                    objCollectWrtyCode = New Samsung.frmCollectSSWrytData()
                    objCollectWrtyCode.ShowDialog()
                    If objCollectWrtyCode._booCancel = True Then
                        MessageBox.Show("You must enter manufacture date code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If objCollectWrtyCode._strMonth.Trim.Length = 0 Then
                            MessageBox.Show("Invalid Month of Manufacture Date Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf objCollectWrtyCode._strYear.Trim.Length = 0 Then
                            MessageBox.Show("Invalid Year of Manufacture Date Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            strWrtyDateCode = objCollectWrtyCode._strYear.Trim & "." & objCollectWrtyCode._strMonth.Trim
                            iManufWrty = objCollectWrtyCode._iWrty
                            strLastDateInWrty = objCollectWrtyCode._strLastDateInWarranty
                            booReturnVal = True
                        End If
                    End If
                ElseIf iManufID = 16 Then   'LG
                    objCollectWrtyCode = New LG.frmCollectLGWrtyCode(strIMEI)
                    objCollectWrtyCode.ShowDialog()
                    If objCollectWrtyCode._booCancel = True Then
                        MessageBox.Show("You must enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If objCollectWrtyCode._strDateCode.ToString.Trim.Length = 0 Then
                            MessageBox.Show("You must enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iManufWrty = objCollectWrtyCode._iWrty
                            strWrtyDateCode = objCollectWrtyCode._strDateCode.ToString.Trim
                            If objCollectWrtyCode._strSN.ToString.Trim.Length > 3 Then strMSN = objCollectWrtyCode._strSN.ToString.Trim.ToUpper
                            strLastDateInWrty = objCollectWrtyCode._strLastDateInWarranty
                            booReturnVal = True
                        End If
                    End If
                ElseIf iManufID = 1 Then    'MOTOROLA
                    objCollectWrtyCode = New Gui.Motorola.frmCollectMotorolaWrtyCode(strIMEI, iModelID)
                    objCollectWrtyCode.ShowDialog()
                    If objCollectWrtyCode._booCancel = True Then
                        MessageBox.Show("You must enter MSN number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If objCollectWrtyCode._strMSN.Trim.Length = 0 Then
                            MessageBox.Show("You must enter MSN number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iManufWrty = objCollectWrtyCode._iWrty
                            strLastDateInWrty = objCollectWrtyCode._strLastDateInWarranty
                            strWrtyDateCode = objCollectWrtyCode._strDateCode.ToString.Trim
                            If objCollectWrtyCode._strMSN.ToString.Trim.Length > 0 Then strMSN = objCollectWrtyCode._strMSN.ToString.Trim.ToUpper
                            strAPC = objCollectWrtyCode._strAPC
                            booReturnVal = True
                        End If
                    End If
                ElseIf iManufID = 24 OrElse iManufID = 48 OrElse iManufID = 201 Then  'Nokia & Huawei & ZTE
                    objCollectWrtyCode = New Gui.ManufWarrantyInfo.frmCollectWrtyDateCode(iManufID)
                    objCollectWrtyCode.ShowDialog()
                    If objCollectWrtyCode.ReturnFlg = False Then
                        MessageBox.Show("You must enter date code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If objCollectWrtyCode.Code.Trim.Length = 0 Then
                            MessageBox.Show("You must enter date code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iManufWrty = objCollectWrtyCode.ManufWrty
                            strLastDateInWrty = objCollectWrtyCode.LastDateInWarranty
                            strWrtyDateCode = objCollectWrtyCode.DateCode.ToString.Trim
                            If objCollectWrtyCode.Code.ToString.Trim.Length > 0 Then strMSN = objCollectWrtyCode.Code.ToString.Trim.ToUpper
                            iManufacturingCountryID = objCollectWrtyCode.ManufacturingCountryID
                            booReturnVal = True
                        End If
                    End If
                Else
                    MessageBox.Show("Collect Warranty Data function is not available for this manufacture.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    booReturnVal = False
                End If

                If booReturnVal Then
                    If iManufWrty < 0 Then
                        MessageBox.Show("System has failed to calculate manufacture warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False
                    ElseIf iBoxType = 1 AndAlso iManufWrty > 0 AndAlso IsNothing(strLastDateInWrty) = False Then
                        strToday = Format(CDate(Generic.MySQLServerDateTime(1)), "yyyy-MM-dd")
                        'Separate warranty units that will expired in less than 31 days
                        If DateDiff(DateInterval.Day, CDate(strToday), CDate(strLastDateInWrty)) <= 30 Then iWrtyExpInLess31Days = 1
                    End If
                End If

                Return booReturnVal
            Catch ex As Exception
                CollectWarrantyData = False
                Throw ex
            Finally
                If Not IsNothing(objCollectWrtyCode) Then
                    objCollectWrtyCode.Dispose()
                    objCollectWrtyCode = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Private Function AutoBill(ByVal iDeviceID As Integer, ByVal iModelID As Integer) As Integer
            Const iReceiveBillcode As Integer = 1608
            Dim objDevice As Rules.Device
            Try
                If Generic.IsBillcodeMapped(iModelID, iReceiveBillcode) > 0 AndAlso Generic.IsBillcodeExisted(iDeviceID, iReceiveBillcode) = False Then
                    objDevice = New Rules.Device(iDeviceID)
                    objDevice.AddPart(iReceiveBillcode)
                    objDevice.Update()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Sub dtpDockRecDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDockRecDate.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then Me.cboBoxType.SelectAll() : Me.cboBoxType.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dtpDockRecDate_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub txtRcvd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRcvd.Leave
            Me.lblAccepted.Text = Me.txtRcvd.Text
            Me.txtRcvd.BackColor = Color.Black
        End Sub

        '******************************************************************
        Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
            Dim booResult As Boolean = False
            Try
                booResult = ProcessTFSN()
                If booResult = True Then Me.txtIMEI.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub cboBoxType_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBoxType.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboBoxType.DataSource.Table.Select("[Desc] = '" & Me.cboBoxType.Text & "'").length = 0 Then
                        MessageBox.Show("Invalid selection of Box Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboBoxType.SelectAll()
                        Me.cboBoxType.Focus()
                    Else
                        Me.txtIMEI.SelectAll()
                        Me.txtIMEI.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboBoxType_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Dim strBoxID As String = ""
            Dim dt As DataTable

            Try
                strBoxID = InputBox("Enter Box ID:").Trim

                If strBoxID.Length = 0 Then Exit Sub

                Me._objTFRec.ReprintWHBox(strBoxID)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboBoxType_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnRefreshRecNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshRecNo.Click
            Try
                If Me.cboOpenOrders.SelectedValue > 0 Then
                    Me.lblRejected.Text = Me._objTFRec.GetDiscrepancyDevices(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
                    Me.lblAccepted.Text = Me._objTFRec.GetReceivedDevicesCount(Me.cboOpenOrders.SelectedValue)
                    Me.txtRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshRecNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub txtMaxBoxQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaxBoxQty.KeyPress, txtIMEI.KeyPress, txtDiscrepancyIMEI.KeyPress
            If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        End Sub

        '******************************************************************
#End Region

#Region "Discrepancy Receiving"

        '**************************************************************************************************************
        Private Sub tpDicrepancyReceiving_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpDicrepancyReceiving.VisibleChanged
            Try
                If tpDicrepancyReceiving.Visible = True AndAlso Not IsNothing(Me.cboDiscrepancyOrder.DataSource) AndAlso Me.cboDiscrepancyOrder.SelectedValue > 0 Then PopulateOpenBoxes(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"),False)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpDicrepancyReceiving_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************************************************
        Private Sub txtDiscrepancyIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiscrepancyIMEI.KeyUp
            Dim booResult As Boolean = False

            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtDiscrepancyIMEI.Text.Trim.Length > 0 Then
                    booResult = ProcessTFSN_Discrepancy()
                    If booResult = True Then Me.txtDiscrepancyIMEI.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDiscrepancyIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Function ProcessTFSN_Discrepancy() As Boolean
            Dim dt As DataTable
            Dim iDeviceID, iManufWrty, i, iManufID, iModelID, iWrtyExpInLess31Days, iManufacturingCountryID, iBoxType, iTrayID, iWHRNO_ID As Integer
            Dim objCollectWrtyCode As System.Object
            Dim dtBox As DataTable
            Dim strLastDateInWrty, strToday, strWrtyDateCode, strMSN, strAPC, strItemNo, strWorkstation As String

            Try
                iDeviceID = 0 : iManufWrty = 0 : i = 0 : iManufID = 0 : iModelID = 0 : iWrtyExpInLess31Days = 0 : iManufacturingCountryID = 0 : iBoxType = 0 : iTrayID = 0 : iWHRNO_ID = 0
                strLastDateInWrty = "" : strWrtyDateCode = "" : strMSN = "" : strAPC = "" : strItemNo = ""
                Me.lblDiscWrtyStatus.Text = ""
                Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                Me.lblInWrtyBoxID_Disc.ForeColor = Color.Lime
                Me.lblWrtyExpedite_Disc.ForeColor = Color.Lime
                Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Lime

                If Me.cboDiscrepancyOrder.SelectedValue = 0 Then
                    MessageBox.Show("Please select Order Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                ElseIf Me.cboDiscModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscModels.SelectAll() : Me.cboDiscModels.Focus()
                ElseIf Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue).Length = 0 Then
                    MessageBox.Show("Model is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscModels.SelectAll() : Me.cboDiscModels.Focus()
                ElseIf Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Manuf_ID") = 0 Then
                    MessageBox.Show("Manufacture is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscModels.SelectAll() : Me.cboDiscModels.Focus()
                ElseIf Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue).Length = 0 Then
                    MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                ElseIf Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Tray_ID") = 0 Then
                    MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                ElseIf Generic.IsSNInWIP(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, Me.txtDiscrepancyIMEI.Text.Trim) = True Then
                    MessageBox.Show("IMEI is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus()
                Else
                    strItemNo = Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("cust_IncomingSku")
                    iManufID = Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Manuf_ID")
                    iModelID = Me.cboDiscModels.SelectedValue
                    If Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue).Length > 0 AndAlso Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Model_Desc").ToString.Trim.EndsWith("_FUN") = True Then iBoxType = 1
                    '***************************
                    'collect warranty data
                    '***************************
                    If Me.CollectWarrantyData(iManufID, iModelID, Me.txtDiscrepancyIMEI.Text.Trim.ToUpper, iBoxType, iManufWrty, iWrtyExpInLess31Days, strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, iManufacturingCountryID) = False Then
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                    End If

                    '*******************************
                    'Get Box
                    '*******************************
                    dtBox = Me._objTFRec.GetWHBox(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), iBoxType, iManufWrty, iWrtyExpInLess31Days)

                    'Create new box
                    If dtBox.Rows.Count = 0 Then
                        dtBox = Me._objTFRec.CreateWarehouseBoxID(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), iBoxType, iManufWrty, iModelID, iWrtyExpInLess31Days)
                        If dtBox.Rows.Count = 0 Then
                            MessageBox.Show("System had failed to create new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll() : Exit Function
                        End If
                    End If

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    'SET edi.titem.WHRNO_ID = 5654 ( this meen exclude the record from edi-DEV944 )
                    If Me.chkNoEDIDev944.Checked = True Then iWHRNO_ID = Convert.ToInt32(Me.chkNoEDIDev944.Tag)

                    '*******************************************
                    'DISCREPANCY UNIT. IN BOX NOT IN FILE
                    '*******************************************
                    dt = Me._objTFRec.AddExtraUnit(strItemNo, strItemNo, Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("WO_CustWO"), Me.txtDiscrepancyIMEI.Text.Trim.ToUpper, "", True, iWHRNO_ID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("System has failed to add device into item table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus() : Exit Function
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate IMEI.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus()
                    ElseIf dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
                        MessageBox.Show("IMEI has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus()
                    Else
                        '************************************
                        'Receve device into database
                        '************************************
                        If iBoxType = 1 Then strWorkstation = "BER SCREEN" Else strWorkstation = "WH-WIP"
                        iDeviceID = Me._objTFRec.ReceiveDeviceIntoWIP(dtBox, dt.Rows(0)("Item_ID"), Me.cboDiscrepancyOrder.SelectedValue, iTrayID, Me.txtDiscrepancyIMEI.Text.Trim, iModelID, iManufWrty, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, strMSN, strWrtyDateCode, strLastDateInWrty, strAPC, Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Manuf_ID"), 90, iManufacturingCountryID, strWorkstation)

                        If iDeviceID > 0 Then
                            '*****************************
                            If iWrtyExpInLess31Days = 1 Then
                                Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                                If iManufWrty = 1 Then Me.lblDiscWrtyStatus.Text = "IW"
                                Me.lblWrtyExpedite_Disc.Text = dtBox.Rows(0)("BoxID")
                                Me.lblWrtyExpediteQty_Disc.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblWrtyExpedite_Disc.ForeColor = Color.Red
                                Me.lblInWrtyBoxID_Disc.ForeColor = Color.Green
                                Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Green
                            ElseIf iManufWrty = 1 Then
                                Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                                Me.lblDiscWrtyStatus.Text = "IW"
                                Me.lblInWrtyBoxID_Disc.Text = dtBox.Rows(0)("BoxID")
                                Me.lblInWrtyBoxQty_Disc.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblInWrtyBoxID_Disc.ForeColor = Color.Red
                                Me.lblWrtyExpedite_Disc.ForeColor = Color.Green
                                Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Green
                            Else
                                Me.lblDiscWrtyStatus.BackColor = Color.Purple
                                Me.lblDiscWrtyStatus.Text = "OW"
                                Me.lblOutWrtyBoxID_Disc.Text = dtBox.Rows(0)("BoxID")
                                Me.lblOutWrtyBoxQty_Disc.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Red
                                Me.lblInWrtyBoxID_Disc.ForeColor = Color.Green
                                Me.lblWrtyExpedite_Disc.ForeColor = Color.Green
                            End If

                            '******************************************************
                            Me.Enabled = True : Me.chkNoEDIDev944.Checked = False
                            Me.txtDiscrepancyIMEI.Text = "" : Me.txtDiscrepancyIMEI.Focus()
                        End If
                        '************************************
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessTFSN_Discrepancy", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                If Not IsNothing(objCollectWrtyCode) Then
                    objCollectWrtyCode.Dispose() : objCollectWrtyCode = Nothing
                End If

                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Function

        '**************************************************************************************************************
        Private Sub cboDiscrepancyOrder_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDiscrepancyOrder.RowChange
            Try
                Me.lblDiscWrtyStatus.Text = "" : Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                Me.txtDiscrepancyIMEI.Text = "" : Me.chkNoEDIDev944.Checked = False

                If sender.name = "cboDiscrepancyOrder" AndAlso Me._booLoadDataToCtrl = False Then
                    If Not IsNothing(cboDiscrepancyOrder.DataSource) AndAlso cboDiscrepancyOrder.SelectedValue > 0 Then
                        Me.PopulateOpenBoxes(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), False)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboDiscrepancyOrder", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************************************************
        Private Sub btnCloseBoxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseIWBox.Click, btnCloseIWEBox.Click, btnCloseOWBox.Click
            Dim strBoxName As String = ""
            Dim dt As DataTable

            Try
                If Me.cboDiscrepancyOrder.SelectedValue = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                ElseIf Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue).length = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                Else
                    If sender.name = "btnCloseIWBox" Then
                        strBoxName = Me.lblInWrtyBoxID_Disc.Text.Trim.ToUpper
                    ElseIf sender.name = "btnCloseIWEBox" Then
                        strBoxName = Me.lblWrtyExpedite_Disc.Text.Trim.ToUpper
                    ElseIf sender.name = "btnCloseOWBox" Then
                        strBoxName = Me.lblOutWrtyBoxID_Disc.Text.Trim.ToUpper
                    End If

                    If strBoxName.Trim.Length = 0 Then
                        MessageBox.Show("No open box to close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf MessageBox.Show("Are you sure you want to close this box """ & strBoxName & """??.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        Exit Sub
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        dt = Me._objTFRec.GetWHBoxByBoxNameAndOrderID(strBoxName, Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"))
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Box name does not exist in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("More than one box existed in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Else
                            Me._objTFRec.CloseWareHouseBox(dt.Rows(0)("wb_id"))
                            PopulateOpenBoxes(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), False)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name.ToString, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************************************************

#End Region

#Region "LAN USE ONLY"

        '******************************************************************
        Private Sub btnLanUseOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLanUseOnly.Click
            Dim strFilePatth As String = ""
            Dim i, j As Integer
            Dim strSql, strPartNo, strStdCost As String
            Dim dt1, dt2 As DataTable
            Dim objOFD As New Windows.Forms.OpenFileDialog()
            Dim R1 As DataRow
            Dim objDevice As Rules.Device
            Dim dbInvAmt As Double = 0.0

            Try
                strSql = " select tdevice.* from tdevice " 'inner join tmessdata on tdevice.device_id = tmessdata.device_id inner join lfrequency on tmessdata.Freq_ID = lfrequency.Freq_ID " & Environment.NewLine
                'strSql &= " left outer join tdevicebill on tdevice.device_id = tdevicebill.device_id and billcode_id in ( 2144, 2145, 2146 ) " & Environment.NewLine
                strSql &= "where loc_id = 442 and Device_DateShip >= '2011-10-30 00:00:00' " & Environment.NewLine
                strSql &= "and Device_laborlevel > 0 " 'and freq_Number = '152.4800' and dbill_id is null " & Environment.NewLine
                dt1 = Me._objTFRec.GetSpecialDeviceIDs(strSql)

                For Each R1 In dt1.Rows
                    objDevice = New Rules.Device(R1("Device_ID"))

                    'If Generic.IsBillcodeExisted(R1("Device_ID"), 21) Then objDevice.DeletePart(21)
                    'If Generic.IsBillcodeExisted(R1("Device_ID"), 14) Then objDevice.DeletePart(14)
                    'objDevice.AddPart(2147)
                    'strSql = "select * from tdevicebill where device_id = " & R1("Device_ID")
                    'dt2 = Me._objTFRec.GetSpecialDeviceIDs(strSql)

                    ''If dt2.Select("Billcode_ID = 2144").Length = 0 Then
                    ''    objDevice.AddPart(2144)
                    ''End If

                    'If dt2.Select("Billcode_ID = 20").Length > 0 Then
                    '    objDevice.DeletePart(20)
                    'End If

                    'If dt2.Select("Billcode_ID = 22").Length > 0 Then
                    '    objDevice.DeletePart(22)
                    'End If

                    objDevice.Update()

                    If Not IsNothing(objDevice) Then
                        objDevice.Dispose() : objDevice = Nothing
                    End If
                    PSS.Data.Buisness.Generic.DisposeDT(dt2)
                Next R1

                MsgBox("Completed.")
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnLanUseOnly_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objOFD) Then
                    objOFD.Dispose()
                    objOFD = Nothing
                End If
                PSS.Data.Buisness.Generic.DisposeDT(dt1)

                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Sub

        Private Sub UpdateRVPrice()
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strFilePatth As String = ""
            Dim i, j As Integer
            Dim strSql, strPartNo, strBillCode_ID, strInvoiceAmt, strRegPartPrice As String
            Dim dt1 As DataTable
            Dim objOFD As New Windows.Forms.OpenFileDialog()
            Dim R1 As DataRow

            Try
                objOFD.FilterIndex = 1
                objOFD.ShowDialog()
                strFilePatth = Trim(objOFD.FileName)

                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                objSheet = objExcel.Worksheets(1)
                objExcel.Visible = True

                i = 2 : j = 0 : strPartNo = "" : strBillCode_ID = "" : strInvoiceAmt = "" : strRegPartPrice = ""
                strPartNo = objSheet.range("A" & i).value.ToString.Trim
                'strBillCode_ID = objSheet.range("B" & i).value.ToString.Trim
                strInvoiceAmt = objSheet.range("C" & i).value.ToString.Trim
                strRegPartPrice = objSheet.range("D" & i).value.ToString.Trim

                While strPartNo.Length > 0 AndAlso strInvoiceAmt.Trim.Length > 0 AndAlso strRegPartPrice.Trim.Length > 0
                    strSql = " SELECT tdevice.Device_ID, DBill_ID, DBill_StdCost, DBill_InvoiceAmt, DBill_RegPartPrice " & Environment.NewLine
                    strSql &= "FROM tdevice" & Environment.NewLine
                    strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID AND tdevice.Loc_ID = 2946 AND Pallet_ShipType = 0 and tpallett.pkslip_ID is null " & Environment.NewLine
                    'strSql &= "INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID AND pkslip_createDt > '2011-02-01 00:00:00' " & Environment.NewLine
                    strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                    strSql &= "AND DBill_RegPartPrice = 0 and Part_Number = '" & strPartNo & "' And DBill_InvoiceAmt = " & strInvoiceAmt & Environment.NewLine
                    strSql &= "UNION " & Environment.NewLine
                    strSql &= " SELECT tdevice.Device_ID, DBill_ID, DBill_StdCost, DBill_InvoiceAmt, DBill_RegPartPrice " & Environment.NewLine
                    strSql &= "FROM tdevice" & Environment.NewLine
                    'strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID AND tdevice.Loc_ID = 2946 AND Pallet_ShipType = 0 " & Environment.NewLine
                    'strSql &= "INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID AND pkslip_createDt > '2011-02-01 00:00:00' " & Environment.NewLine
                    strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID AND tdevice.Loc_ID = 2946 AND tdevice.Pallett_ID is null " & Environment.NewLine
                    strSql &= "AND DBill_RegPartPrice = 0 and Part_Number = '" & strPartNo & "'" & Environment.NewLine
                    strSql &= "AND  DBill_InvoiceAmt = " & strInvoiceAmt & Environment.NewLine

                    dt1 = _objTFRec.GetSpecialDeviceIDs(strSql)

                    For Each R1 In dt1.Rows
                        strSql = "Update tdevicebill Set DBill_RegPartPrice = " & strRegPartPrice & " WHERE DBill_ID = " & R1("DBill_ID")
                        j += Me._objTFRec.Execute(strSql)
                    Next R1

                    PSS.Data.Buisness.Generic.DisposeDT(dt1) : i += 1
                    If Not IsNothing(objSheet.range("A" & i).value) Then strPartNo = objSheet.range("A" & i).value.ToString.Trim Else strPartNo = ""
                    'If Not IsNothing(objSheet.range("B" & i).value) Then strBillCode_ID = objSheet.range("B" & i).value.ToString.Trim Else strBillCode_ID = ""
                    If Not IsNothing(objSheet.range("C" & i).value) Then strInvoiceAmt = objSheet.range("C" & i).value.ToString.Trim Else strInvoiceAmt = ""
                    If Not IsNothing(objSheet.range("D" & i).value) Then strRegPartPrice = objSheet.range("D" & i).value.ToString.Trim Else strRegPartPrice = ""
                End While


                MsgBox("Completed.")
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnLanUseOnly_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objOFD) Then
                    objOFD.Dispose()
                    objOFD = Nothing
                End If
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************
        Private Sub ProcessDeviceBilling(ByVal strDeviceIDs As String)
            Dim dt, dt2, dtMaxClaimablePartLevel As DataTable
            Dim strSql As String = ""
            Dim R1, R2 As DataRow
            Dim objDevice As Rules.Device
            Dim i As Integer = 0
            Dim objTFBilling As New PSS.Data.Buisness.TracFone.TFBillingData()
            Dim objTFBillService As New TracFone.TFBilling()

            Try
                strSql = "select WrtyClaimableFlg, Manuf_ID, Device_ManufWrty, tdevice.Device_ID, tdevice.Model_ID, FuncRep, Pallet_ShipType, Cust_ID,  CellOpt_VerificationID from tdevice " & Environment.NewLine
                strSql &= "inner join edi.titem on tdevice.Device_id = edi.titem.device_id " & Environment.NewLine
                strSql &= "inner join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "inner join tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "inner join tcellopt on tdevice.device_id = tcellopt.device_ID " & Environment.NewLine
                strSql &= "where tdevice.Loc_ID = 2946 AND tdevice.device_ID in ( " & strDeviceIDs & " )  "
                dt = Me._objTFRec.GetSpecialDeviceIDs(strSql)

                For Each R1 In dt.Rows
                    'dtMaxClaimablePartLevel = objTFBilling.GetMaxClaimablePartsAndReflowLevel(R1("Device_ID"), R1("Manuf_ID"))

                    'objTFBilling.SetWrtyClaimableFlag(R1("Device_ID"), R1("Manuf_ID"), R1("WrtyClaimableFlg"), dtMaxClaimablePartLevel)

                    objTFBillService.BillServices(R1, R1("Pallet_ShipType"), R1("Cust_ID"))
                Next R1

                'MsgBox("Completed.")
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessDeviceBilling", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
                Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
                R1 = Nothing : R2 = Nothing : objTFBilling = Nothing
            End Try
        End Sub

        '******************************************************************
        Public Function UnDoBillingGotRemoveWhenScanInFailBucket()
            Dim dt, dt2 As DataTable
            Dim strSql As String = ""
            Dim R1, R2 As DataRow
            Dim objDevice As Rules.Device
            Dim i As Integer = 0
            Dim strNotMap, strExisted As String

            Try
                strNotMap = "" : strExisted = ""

                strSql = "Select tdevice.* " & Environment.NewLine
                strSql &= "from tdevice  " & Environment.NewLine
                strSql &= "inner join tcellopt on tdevice.Device_ID = tcellopt.Device_ID  " & Environment.NewLine
                strSql &= "where loc_id = 2946 and workstation like 'FUNCTIONAL FAIL%' " & Environment.NewLine
                dt = Me._objTFRec.GetSpecialDeviceIDs(strSql)

                For Each R1 In dt.Rows
                    strSql = "SELECT tparttransaction.* FROM tparttransaction " & Environment.NewLine
                    strSql &= "INNER JOIN lbillcodes ON tparttransaction.Billcode_ID = lbillcodes.billcode_ID " & Environment.NewLine
                    strSql &= "WHERE tparttransaction.Device_ID = " & R1("Device_ID") & Environment.NewLine
                    strSql &= "AND BillType_ID = 2 AND Trans_Amount < 0 " & Environment.NewLine
                    dt2 = Me._objTFRec.GetSpecialDeviceIDs(strSql)

                    If dt2.Rows.Count > 0 Then objDevice = New Rules.Device(R1("Device_ID"))

                    For Each R2 In dt2.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeMapped(R1("Model_ID"), R2("Billcode_ID")) > 0 Then
                            If PSS.Data.Buisness.Generic.IsBillcodeExisted(R2("Device_ID"), R2("Billcode_ID")) = False Then
                                objDevice.AddPart(R2("Billcode_ID"))
                            Else
                                If strExisted.Trim.Length > 0 Then strExisted &= ","
                                strExisted &= R2("Device_ID") & "|" & R2("Billcode_ID")
                            End If
                        Else
                            If strNotMap.Trim.Length > 0 Then strNotMap &= ","
                            strNotMap &= R2("Device_ID") & "|" & R2("Billcode_ID")
                        End If
                    Next R2

                    If dt2.Rows.Count > 0 Then
                        objDevice.Update()
                        objDevice.Dispose() : objDevice = Nothing
                        R2 = Nothing : Generic.DisposeDT(dt2)
                    End If
                Next R1

                MsgBox("Completed.")
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnLanUseOnly_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
                R1 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Private Sub SWapFailcodes()
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strFilePatth As String = ""
            Dim i As Integer = 2
            Dim strSql, strManufID, strModelID, strDeviceID, strBillcodeID, strOldFailID, strNewFailID, strPartNo As String
            Dim dt1 As DataTable
            Dim objOFD As New Windows.Forms.OpenFileDialog()

            Try
                objOFD.FilterIndex = 1
                objOFD.ShowDialog()
                strFilePatth = Trim(objOFD.FileName)

                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                objSheet = objExcel.Worksheets(1)
                objExcel.Visible = True

                i = 2 : strManufID = "" : strModelID = "" : strDeviceID = ""
                strBillcodeID = "" : strOldFailID = "" : strNewFailID = "" : strPartNo = ""
                strManufID = objSheet.range("A" & i).value.ToString.Trim
                strModelID = objSheet.range("B" & i).value.ToString.Trim
                strDeviceID = objSheet.range("C" & i).value.ToString.Trim
                strPartNo = objSheet.range("E" & i).value.ToString.Trim
                strOldFailID = objSheet.range("G" & i).value.ToString.Trim
                strNewFailID = objSheet.range("K" & i).value.ToString.Trim

                While strManufID.Length > 0 AndAlso strModelID.Length > 0 _
                    AndAlso strDeviceID.Length > 0 AndAlso strPartNo.Length > 0 _
                    AndAlso strOldFailID.Length > 0 AndAlso strNewFailID.Length > 0

                    strSql = " SELECT * " & Environment.NewLine
                    strSql &= "FROM tdeviceBill " & Environment.NewLine
                    strSql &= "WHERE Device_ID = " & CInt(strDeviceID) & Environment.NewLine
                    'strSql &= "AND Billcode_ID = " & CInt(strBillcodeID) & Environment.NewLine
                    strSql &= "AND Part_Number = '" & strPartNo & "'" & Environment.NewLine
                    dt1 = Me._objTFRec.GetSpecialDeviceIDs(strSql)

                    If dt1.Rows.Count > 1 Then
                        objSheet.Range("N" & i).FormulaR1C1 = "Existed more than one"
                    ElseIf dt1.Rows.Count = 0 Then
                        objSheet.Range("N" & i).FormulaR1C1 = "Not Found"
                    Else
                        strSql = " update tdevicebill SET Fail_ID = " & CInt(strNewFailID) & Environment.NewLine
                        strSql &= "WHERE DBill_ID = " & dt1.Rows(0)("DBill_ID") & Environment.NewLine
                        _objTFRec.Execute(strSql)
                        ProcessDeviceBilling(strDeviceID)
                        objSheet.Range("N" & i).FormulaR1C1 = dt1.Rows(0)("Fail_ID") & " => " & strNewFailID
                    End If

                    'Reset variable
                    PSS.Data.Buisness.Generic.DisposeDT(dt1)
                    i += 1
                    strManufID = objSheet.range("A" & i).value.ToString.Trim
                    strModelID = objSheet.range("B" & i).value.ToString.Trim
                    strDeviceID = objSheet.range("C" & i).value.ToString.Trim
                    strPartNo = objSheet.range("E" & i).value.ToString.Trim
                    strOldFailID = objSheet.range("G" & i).value.ToString.Trim
                    strNewFailID = objSheet.range("K" & i).value.ToString.Trim
                End While

                MsgBox("Completed.")

                objBook.SaveAs(strFilePatth)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SWapFailcodes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objOFD) Then
                    objOFD.Dispose()
                    objOFD = Nothing
                End If
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************
        Private Sub AddParts()
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim strFilePatth As String = ""
            Dim i As Integer = 2
            Dim strSql, strManufID, strModelID, strDeviceID, strBillcodeID, strFailID, strRepairID As String
            Dim objOFD As New Windows.Forms.OpenFileDialog()
            Dim objDevice As Rules.Device

            Try
                objOFD.FilterIndex = 1
                objOFD.ShowDialog()
                strFilePatth = Trim(objOFD.FileName)

                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePatth)
                objSheet = objExcel.Worksheets(1)
                objExcel.Visible = True

                i = 2 : strManufID = "" : strModelID = "" : strDeviceID = ""
                strBillcodeID = "" : strFailID = "" : strRepairID = ""
                strManufID = objSheet.range("A" & i).value.ToString.Trim
                strModelID = objSheet.range("B" & i).value.ToString.Trim
                strDeviceID = objSheet.range("C" & i).value.ToString.Trim
                strBillcodeID = objSheet.range("N" & i).value.ToString.Trim
                strFailID = objSheet.range("K" & i).value.ToString.Trim
                strRepairID = objSheet.range("L" & i).value.ToString.Trim

                While strManufID.Length > 0 AndAlso strModelID.Length > 0 _
                    AndAlso strDeviceID.Length > 0 AndAlso strBillcodeID.Length > 0 _
                    AndAlso strFailID.Length > 0 AndAlso strRepairID.Length > 0

                    If PSS.Data.Buisness.Generic.IsBillcodeExisted(CInt(strDeviceID), CInt(strBillcodeID)) = False Then
                        objDevice = New Rules.Device(CInt(strDeviceID))
                        objDevice.FailID = CInt(strFailID)
                        objDevice.RepairID = CInt(strRepairID)
                        objDevice.AddPart(CInt(strBillcodeID))
                        objSheet.Range("O" & i).FormulaR1C1 = "Added"
                    Else
                        objSheet.Range("O" & i).FormulaR1C1 = "Existed"
                    End If
                    ProcessDeviceBilling(strDeviceID)

                    'Reset variable
                    If Not IsNothing(objDevice) Then
                        objDevice.Dispose()
                        objDevice = Nothing
                    End If
                    i += 1
                    strManufID = objSheet.range("A" & i).value.ToString.Trim
                    strModelID = objSheet.range("B" & i).value.ToString.Trim
                    strDeviceID = objSheet.range("C" & i).value.ToString.Trim
                    strBillcodeID = objSheet.range("N" & i).value.ToString.Trim
                    strFailID = objSheet.range("K" & i).value.ToString.Trim
                    strRepairID = objSheet.range("L" & i).value.ToString.Trim
                End While

                MsgBox("Completed.")

                objBook.SaveAs(strFilePatth)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "AddParts", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************

#End Region

       
    End Class
End Namespace