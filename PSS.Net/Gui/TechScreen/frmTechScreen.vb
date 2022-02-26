Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global

Namespace Gui.techscreen

    Public Class frmTechScreen
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
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents chkBxRepairCodes As System.Windows.Forms.CheckedListBox
        Friend WithEvents lblRepairCodes As System.Windows.Forms.Label
        Friend WithEvents lblReasonCodes As System.Windows.Forms.Label
        Friend WithEvents lblBillingCodes As System.Windows.Forms.Label
        Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
        Friend WithEvents CheckedListBox2 As System.Windows.Forms.CheckedListBox
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnAddComponentMoto As System.Windows.Forms.Button
        Friend WithEvents grpDetail As System.Windows.Forms.GroupBox
        Friend WithEvents grpMotorola As System.Windows.Forms.GroupBox
        Friend WithEvents gridComponents As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grpMotoAction As System.Windows.Forms.GroupBox
        Friend WithEvents cboDeviceSN As System.Windows.Forms.ComboBox
        Friend WithEvents lblOutgoingMSN As System.Windows.Forms.Label
        Friend WithEvents lblOutgoingIMEI As System.Windows.Forms.Label
        Friend WithEvents lblOutgoingESNCSN As System.Windows.Forms.Label
        Friend WithEvents lblRepairStatus As System.Windows.Forms.Label
        Friend WithEvents lblRepairDate As System.Windows.Forms.Label
        Friend WithEvents lblRepairTime As System.Windows.Forms.Label
        Friend WithEvents lblRepairCycleTime As System.Windows.Forms.Label
        Friend WithEvents lblSoftwareVerIN As System.Windows.Forms.Label
        Friend WithEvents lblSoftwareVerOUT As System.Windows.Forms.Label
        Friend WithEvents lblTechID As System.Windows.Forms.Label
        Friend WithEvents lblAirtime As System.Windows.Forms.Label
        Friend WithEvents lblMINnumber As System.Windows.Forms.Label
        Friend WithEvents txtAirtime As System.Windows.Forms.TextBox
        Friend WithEvents cboTechID As System.Windows.Forms.ComboBox
        Friend WithEvents txtSoftwareVerOUT As System.Windows.Forms.TextBox
        Friend WithEvents txtSoftwareVerIN As System.Windows.Forms.TextBox
        Friend WithEvents cboRepairDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtRepairCycleTime As System.Windows.Forms.TextBox
        Friend WithEvents txtRepairTime As System.Windows.Forms.TextBox
        Friend WithEvents txtMINnumber As System.Windows.Forms.TextBox
        Friend WithEvents txtOutgoingESNCSN As System.Windows.Forms.TextBox
        Friend WithEvents txtOutgoingIMEI As System.Windows.Forms.TextBox
        Friend WithEvents txtOutgoingMSN As System.Windows.Forms.TextBox
        Friend WithEvents lblTray As System.Windows.Forms.Label
        Friend WithEvents txtTray As System.Windows.Forms.TextBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tbProblem As System.Windows.Forms.TabPage
        Friend WithEvents tbRepair As System.Windows.Forms.TabPage
        Friend WithEvents tbPartsNotAvailable As System.Windows.Forms.TabPage
        Friend WithEvents clboxProblem As System.Windows.Forms.CheckedListBox
        Friend WithEvents clboxRepair As System.Windows.Forms.CheckedListBox
        Friend WithEvents txtRefDesNum As System.Windows.Forms.TextBox
        Friend WithEvents lblFailCode As System.Windows.Forms.Label
        Friend WithEvents lblRefDesNum As System.Windows.Forms.Label
        Friend WithEvents lblRefDes As System.Windows.Forms.Label
        Friend WithEvents lblBillCode As System.Windows.Forms.Label
        Friend WithEvents btnAddComponent As System.Windows.Forms.Button
        Friend WithEvents btnDeleteComponent As System.Windows.Forms.Button
        Friend WithEvents cboBillCode As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboRefDes As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboFailCode As PSS.Gui.Controls.ComboBox
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents cboRepairStatus As PSS.Gui.Controls.ComboBox
        Friend WithEvents btnPFcomplete As System.Windows.Forms.Button
        Friend WithEvents btnRcomplete As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboPartNum As PSS.Gui.Controls.ComboBox
        Friend WithEvents btnPFdefault As System.Windows.Forms.Button
        Friend WithEvents btnRdefault As System.Windows.Forms.Button
        Friend WithEvents Button4 As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTechScreen))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.chkBxRepairCodes = New System.Windows.Forms.CheckedListBox()
            Me.lblTray = New System.Windows.Forms.Label()
            Me.txtTray = New System.Windows.Forms.TextBox()
            Me.lblRepairCodes = New System.Windows.Forms.Label()
            Me.lblReasonCodes = New System.Windows.Forms.Label()
            Me.lblBillingCodes = New System.Windows.Forms.Label()
            Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
            Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnAddComponentMoto = New System.Windows.Forms.Button()
            Me.grpDetail = New System.Windows.Forms.GroupBox()
            Me.lblOutgoingMSN = New System.Windows.Forms.Label()
            Me.lblOutgoingIMEI = New System.Windows.Forms.Label()
            Me.lblOutgoingESNCSN = New System.Windows.Forms.Label()
            Me.lblRepairStatus = New System.Windows.Forms.Label()
            Me.lblRepairDate = New System.Windows.Forms.Label()
            Me.lblRepairTime = New System.Windows.Forms.Label()
            Me.lblRepairCycleTime = New System.Windows.Forms.Label()
            Me.lblSoftwareVerIN = New System.Windows.Forms.Label()
            Me.lblSoftwareVerOUT = New System.Windows.Forms.Label()
            Me.lblTechID = New System.Windows.Forms.Label()
            Me.lblAirtime = New System.Windows.Forms.Label()
            Me.lblMINnumber = New System.Windows.Forms.Label()
            Me.grpMotorola = New System.Windows.Forms.GroupBox()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.cboRepairStatus = New PSS.Gui.Controls.ComboBox()
            Me.txtAirtime = New System.Windows.Forms.TextBox()
            Me.cboTechID = New System.Windows.Forms.ComboBox()
            Me.txtSoftwareVerOUT = New System.Windows.Forms.TextBox()
            Me.txtSoftwareVerIN = New System.Windows.Forms.TextBox()
            Me.cboRepairDate = New System.Windows.Forms.DateTimePicker()
            Me.txtRepairCycleTime = New System.Windows.Forms.TextBox()
            Me.txtRepairTime = New System.Windows.Forms.TextBox()
            Me.txtMINnumber = New System.Windows.Forms.TextBox()
            Me.txtOutgoingESNCSN = New System.Windows.Forms.TextBox()
            Me.txtOutgoingIMEI = New System.Windows.Forms.TextBox()
            Me.txtOutgoingMSN = New System.Windows.Forms.TextBox()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.gridComponents = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grpMotoAction = New System.Windows.Forms.GroupBox()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tbProblem = New System.Windows.Forms.TabPage()
            Me.btnPFdefault = New System.Windows.Forms.Button()
            Me.btnPFcomplete = New System.Windows.Forms.Button()
            Me.clboxProblem = New System.Windows.Forms.CheckedListBox()
            Me.tbRepair = New System.Windows.Forms.TabPage()
            Me.btnRdefault = New System.Windows.Forms.Button()
            Me.btnRcomplete = New System.Windows.Forms.Button()
            Me.clboxRepair = New System.Windows.Forms.CheckedListBox()
            Me.tbPartsNotAvailable = New System.Windows.Forms.TabPage()
            Me.cboPartNum = New PSS.Gui.Controls.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboFailCode = New PSS.Gui.Controls.ComboBox()
            Me.cboRefDes = New PSS.Gui.Controls.ComboBox()
            Me.cboBillCode = New PSS.Gui.Controls.ComboBox()
            Me.btnDeleteComponent = New System.Windows.Forms.Button()
            Me.btnAddComponent = New System.Windows.Forms.Button()
            Me.txtRefDesNum = New System.Windows.Forms.TextBox()
            Me.lblFailCode = New System.Windows.Forms.Label()
            Me.lblRefDesNum = New System.Windows.Forms.Label()
            Me.lblRefDes = New System.Windows.Forms.Label()
            Me.lblBillCode = New System.Windows.Forms.Label()
            Me.cboDeviceSN = New System.Windows.Forms.ComboBox()
            Me.grpDetail.SuspendLayout()
            Me.grpMotorola.SuspendLayout()
            CType(Me.gridComponents, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpMotoAction.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.tbProblem.SuspendLayout()
            Me.tbRepair.SuspendLayout()
            Me.tbPartsNotAvailable.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.Location = New System.Drawing.Point(248, 8)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(120, 16)
            Me.lblDeviceSN.TabIndex = 0
            Me.lblDeviceSN.Text = "Device Serial Number:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkBxRepairCodes
            '
            Me.chkBxRepairCodes.Location = New System.Drawing.Point(24, 56)
            Me.chkBxRepairCodes.Name = "chkBxRepairCodes"
            Me.chkBxRepairCodes.Size = New System.Drawing.Size(120, 289)
            Me.chkBxRepairCodes.TabIndex = 3
            '
            'lblTray
            '
            Me.lblTray.Location = New System.Drawing.Point(24, 8)
            Me.lblTray.Name = "lblTray"
            Me.lblTray.Size = New System.Drawing.Size(64, 16)
            Me.lblTray.TabIndex = 4
            Me.lblTray.Text = "Tray:"
            Me.lblTray.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTray
            '
            Me.txtTray.Location = New System.Drawing.Point(88, 8)
            Me.txtTray.Name = "txtTray"
            Me.txtTray.Size = New System.Drawing.Size(152, 20)
            Me.txtTray.TabIndex = 0
            Me.txtTray.Text = ""
            '
            'lblRepairCodes
            '
            Me.lblRepairCodes.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblRepairCodes.Location = New System.Drawing.Point(24, 24)
            Me.lblRepairCodes.Name = "lblRepairCodes"
            Me.lblRepairCodes.Size = New System.Drawing.Size(112, 16)
            Me.lblRepairCodes.TabIndex = 6
            Me.lblRepairCodes.Text = "Repair Codes"
            Me.lblRepairCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblReasonCodes
            '
            Me.lblReasonCodes.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblReasonCodes.Location = New System.Drawing.Point(144, 24)
            Me.lblReasonCodes.Name = "lblReasonCodes"
            Me.lblReasonCodes.Size = New System.Drawing.Size(112, 16)
            Me.lblReasonCodes.TabIndex = 7
            Me.lblReasonCodes.Text = "Reason Codes"
            Me.lblReasonCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBillingCodes
            '
            Me.lblBillingCodes.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblBillingCodes.Location = New System.Drawing.Point(272, 24)
            Me.lblBillingCodes.Name = "lblBillingCodes"
            Me.lblBillingCodes.Size = New System.Drawing.Size(112, 16)
            Me.lblBillingCodes.TabIndex = 8
            Me.lblBillingCodes.Text = "Billing Codes"
            Me.lblBillingCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'CheckedListBox1
            '
            Me.CheckedListBox1.Location = New System.Drawing.Point(144, 56)
            Me.CheckedListBox1.Name = "CheckedListBox1"
            Me.CheckedListBox1.Size = New System.Drawing.Size(120, 289)
            Me.CheckedListBox1.TabIndex = 9
            '
            'CheckedListBox2
            '
            Me.CheckedListBox2.Location = New System.Drawing.Point(264, 56)
            Me.CheckedListBox2.Name = "CheckedListBox2"
            Me.CheckedListBox2.Size = New System.Drawing.Size(120, 289)
            Me.CheckedListBox2.TabIndex = 10
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(192, 352)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(192, 23)
            Me.btnSave.TabIndex = 11
            Me.btnSave.Text = "Save"
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(24, 352)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(152, 23)
            Me.btnCancel.TabIndex = 12
            Me.btnCancel.Text = "Cancel"
            '
            'btnAddComponentMoto
            '
            Me.btnAddComponentMoto.Location = New System.Drawing.Point(392, 392)
            Me.btnAddComponentMoto.Name = "btnAddComponentMoto"
            Me.btnAddComponentMoto.Size = New System.Drawing.Size(368, 24)
            Me.btnAddComponentMoto.TabIndex = 18
            Me.btnAddComponentMoto.Text = "Add Component"
            '
            'grpDetail
            '
            Me.grpDetail.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRepairCodes, Me.CheckedListBox2, Me.chkBxRepairCodes, Me.lblBillingCodes, Me.CheckedListBox1, Me.lblReasonCodes, Me.btnSave, Me.btnCancel})
            Me.grpDetail.Location = New System.Drawing.Point(848, 448)
            Me.grpDetail.Name = "grpDetail"
            Me.grpDetail.Size = New System.Drawing.Size(32, 32)
            Me.grpDetail.TabIndex = 14
            Me.grpDetail.TabStop = False
            Me.grpDetail.Visible = False
            '
            'lblOutgoingMSN
            '
            Me.lblOutgoingMSN.Location = New System.Drawing.Point(8, 16)
            Me.lblOutgoingMSN.Name = "lblOutgoingMSN"
            Me.lblOutgoingMSN.Size = New System.Drawing.Size(112, 16)
            Me.lblOutgoingMSN.TabIndex = 16
            Me.lblOutgoingMSN.Text = "Outgoing MSN;"
            Me.lblOutgoingMSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOutgoingIMEI
            '
            Me.lblOutgoingIMEI.Location = New System.Drawing.Point(8, 40)
            Me.lblOutgoingIMEI.Name = "lblOutgoingIMEI"
            Me.lblOutgoingIMEI.Size = New System.Drawing.Size(112, 16)
            Me.lblOutgoingIMEI.TabIndex = 17
            Me.lblOutgoingIMEI.Text = "Outgoing IMEI:"
            Me.lblOutgoingIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOutgoingESNCSN
            '
            Me.lblOutgoingESNCSN.Location = New System.Drawing.Point(8, 64)
            Me.lblOutgoingESNCSN.Name = "lblOutgoingESNCSN"
            Me.lblOutgoingESNCSN.Size = New System.Drawing.Size(112, 16)
            Me.lblOutgoingESNCSN.TabIndex = 18
            Me.lblOutgoingESNCSN.Text = "Outgoing ESN/CSN:"
            Me.lblOutgoingESNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRepairStatus
            '
            Me.lblRepairStatus.Location = New System.Drawing.Point(432, 24)
            Me.lblRepairStatus.Name = "lblRepairStatus"
            Me.lblRepairStatus.Size = New System.Drawing.Size(100, 16)
            Me.lblRepairStatus.TabIndex = 19
            Me.lblRepairStatus.Text = "Repair Status:"
            Me.lblRepairStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRepairDate
            '
            Me.lblRepairDate.Location = New System.Drawing.Point(432, 48)
            Me.lblRepairDate.Name = "lblRepairDate"
            Me.lblRepairDate.Size = New System.Drawing.Size(100, 16)
            Me.lblRepairDate.TabIndex = 20
            Me.lblRepairDate.Text = "Repair Date:"
            Me.lblRepairDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRepairTime
            '
            Me.lblRepairTime.Location = New System.Drawing.Point(432, 72)
            Me.lblRepairTime.Name = "lblRepairTime"
            Me.lblRepairTime.Size = New System.Drawing.Size(100, 16)
            Me.lblRepairTime.TabIndex = 21
            Me.lblRepairTime.Text = "Repair Time:"
            Me.lblRepairTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblRepairTime.Visible = False
            '
            'lblRepairCycleTime
            '
            Me.lblRepairCycleTime.Location = New System.Drawing.Point(432, 96)
            Me.lblRepairCycleTime.Name = "lblRepairCycleTime"
            Me.lblRepairCycleTime.Size = New System.Drawing.Size(100, 16)
            Me.lblRepairCycleTime.TabIndex = 22
            Me.lblRepairCycleTime.Text = "Repair Cycle Time:"
            Me.lblRepairCycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblRepairCycleTime.Visible = False
            '
            'lblSoftwareVerIN
            '
            Me.lblSoftwareVerIN.Location = New System.Drawing.Point(224, 24)
            Me.lblSoftwareVerIN.Name = "lblSoftwareVerIN"
            Me.lblSoftwareVerIN.Size = New System.Drawing.Size(120, 16)
            Me.lblSoftwareVerIN.TabIndex = 23
            Me.lblSoftwareVerIN.Text = "Software Version IN:"
            Me.lblSoftwareVerIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSoftwareVerOUT
            '
            Me.lblSoftwareVerOUT.Location = New System.Drawing.Point(224, 48)
            Me.lblSoftwareVerOUT.Name = "lblSoftwareVerOUT"
            Me.lblSoftwareVerOUT.Size = New System.Drawing.Size(120, 16)
            Me.lblSoftwareVerOUT.TabIndex = 24
            Me.lblSoftwareVerOUT.Text = "Software Version OUT:"
            Me.lblSoftwareVerOUT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTechID
            '
            Me.lblTechID.Location = New System.Drawing.Point(240, 72)
            Me.lblTechID.Name = "lblTechID"
            Me.lblTechID.Size = New System.Drawing.Size(100, 16)
            Me.lblTechID.TabIndex = 25
            Me.lblTechID.Text = "Technician ID:"
            Me.lblTechID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAirtime
            '
            Me.lblAirtime.Location = New System.Drawing.Point(240, 96)
            Me.lblAirtime.Name = "lblAirtime"
            Me.lblAirtime.Size = New System.Drawing.Size(100, 16)
            Me.lblAirtime.TabIndex = 26
            Me.lblAirtime.Text = "Airtime:"
            Me.lblAirtime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMINnumber
            '
            Me.lblMINnumber.Location = New System.Drawing.Point(8, 88)
            Me.lblMINnumber.Name = "lblMINnumber"
            Me.lblMINnumber.Size = New System.Drawing.Size(112, 16)
            Me.lblMINnumber.TabIndex = 27
            Me.lblMINnumber.Text = "MIN Number:"
            Me.lblMINnumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grpMotorola
            '
            Me.grpMotorola.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button4, Me.cboRepairStatus, Me.txtAirtime, Me.cboTechID, Me.txtSoftwareVerOUT, Me.txtSoftwareVerIN, Me.cboRepairDate, Me.txtRepairCycleTime, Me.txtRepairTime, Me.txtMINnumber, Me.txtOutgoingESNCSN, Me.txtOutgoingIMEI, Me.txtOutgoingMSN, Me.lblAirtime, Me.lblSoftwareVerOUT, Me.lblRepairStatus, Me.lblOutgoingMSN, Me.lblSoftwareVerIN, Me.lblOutgoingESNCSN, Me.lblOutgoingIMEI, Me.lblTechID, Me.lblRepairTime, Me.lblMINnumber, Me.lblRepairCycleTime, Me.lblRepairDate})
            Me.grpMotorola.Location = New System.Drawing.Point(24, 32)
            Me.grpMotorola.Name = "grpMotorola"
            Me.grpMotorola.Size = New System.Drawing.Size(736, 120)
            Me.grpMotorola.TabIndex = 28
            Me.grpMotorola.TabStop = False
            '
            'Button4
            '
            Me.Button4.Location = New System.Drawing.Point(648, 80)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(56, 23)
            Me.Button4.TabIndex = 28
            Me.Button4.Text = "Button4"
            Me.Button4.Visible = False
            '
            'cboRepairStatus
            '
            Me.cboRepairStatus.Location = New System.Drawing.Point(536, 16)
            Me.cboRepairStatus.Name = "cboRepairStatus"
            Me.cboRepairStatus.Size = New System.Drawing.Size(192, 21)
            Me.cboRepairStatus.TabIndex = 11
            '
            'txtAirtime
            '
            Me.txtAirtime.Location = New System.Drawing.Point(344, 88)
            Me.txtAirtime.Name = "txtAirtime"
            Me.txtAirtime.Size = New System.Drawing.Size(72, 20)
            Me.txtAirtime.TabIndex = 10
            Me.txtAirtime.Text = ""
            '
            'cboTechID
            '
            Me.cboTechID.Location = New System.Drawing.Point(344, 64)
            Me.cboTechID.Name = "cboTechID"
            Me.cboTechID.Size = New System.Drawing.Size(72, 21)
            Me.cboTechID.TabIndex = 9
            '
            'txtSoftwareVerOUT
            '
            Me.txtSoftwareVerOUT.Location = New System.Drawing.Point(344, 40)
            Me.txtSoftwareVerOUT.Name = "txtSoftwareVerOUT"
            Me.txtSoftwareVerOUT.Size = New System.Drawing.Size(72, 20)
            Me.txtSoftwareVerOUT.TabIndex = 8
            Me.txtSoftwareVerOUT.Text = ""
            '
            'txtSoftwareVerIN
            '
            Me.txtSoftwareVerIN.Location = New System.Drawing.Point(344, 16)
            Me.txtSoftwareVerIN.Name = "txtSoftwareVerIN"
            Me.txtSoftwareVerIN.Size = New System.Drawing.Size(72, 20)
            Me.txtSoftwareVerIN.TabIndex = 7
            Me.txtSoftwareVerIN.Text = ""
            '
            'cboRepairDate
            '
            Me.cboRepairDate.Location = New System.Drawing.Point(536, 40)
            Me.cboRepairDate.Name = "cboRepairDate"
            Me.cboRepairDate.Size = New System.Drawing.Size(192, 20)
            Me.cboRepairDate.TabIndex = 12
            '
            'txtRepairCycleTime
            '
            Me.txtRepairCycleTime.Location = New System.Drawing.Point(536, 88)
            Me.txtRepairCycleTime.Name = "txtRepairCycleTime"
            Me.txtRepairCycleTime.TabIndex = 14
            Me.txtRepairCycleTime.Text = ""
            Me.txtRepairCycleTime.Visible = False
            '
            'txtRepairTime
            '
            Me.txtRepairTime.Location = New System.Drawing.Point(536, 64)
            Me.txtRepairTime.Name = "txtRepairTime"
            Me.txtRepairTime.TabIndex = 13
            Me.txtRepairTime.Text = ""
            Me.txtRepairTime.Visible = False
            '
            'txtMINnumber
            '
            Me.txtMINnumber.Location = New System.Drawing.Point(128, 88)
            Me.txtMINnumber.Name = "txtMINnumber"
            Me.txtMINnumber.Size = New System.Drawing.Size(88, 20)
            Me.txtMINnumber.TabIndex = 6
            Me.txtMINnumber.Text = ""
            '
            'txtOutgoingESNCSN
            '
            Me.txtOutgoingESNCSN.Location = New System.Drawing.Point(128, 64)
            Me.txtOutgoingESNCSN.Name = "txtOutgoingESNCSN"
            Me.txtOutgoingESNCSN.Size = New System.Drawing.Size(88, 20)
            Me.txtOutgoingESNCSN.TabIndex = 5
            Me.txtOutgoingESNCSN.Text = ""
            '
            'txtOutgoingIMEI
            '
            Me.txtOutgoingIMEI.Location = New System.Drawing.Point(128, 40)
            Me.txtOutgoingIMEI.Name = "txtOutgoingIMEI"
            Me.txtOutgoingIMEI.Size = New System.Drawing.Size(88, 20)
            Me.txtOutgoingIMEI.TabIndex = 4
            Me.txtOutgoingIMEI.Text = ""
            '
            'txtOutgoingMSN
            '
            Me.txtOutgoingMSN.Location = New System.Drawing.Point(128, 16)
            Me.txtOutgoingMSN.Name = "txtOutgoingMSN"
            Me.txtOutgoingMSN.Size = New System.Drawing.Size(88, 20)
            Me.txtOutgoingMSN.TabIndex = 3
            Me.txtOutgoingMSN.Text = ""
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(8, 232)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(96, 23)
            Me.Button3.TabIndex = 16
            Me.Button3.Text = "CLEAR"
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(184, 232)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(168, 23)
            Me.Button2.TabIndex = 15
            Me.Button2.Text = "UPDATE"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(528, 8)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(224, 23)
            Me.Button1.TabIndex = 2
            Me.Button1.Text = "Get Data"
            '
            'gridComponents
            '
            Me.gridComponents.AllowAddNew = True
            Me.gridComponents.AllowFilter = True
            Me.gridComponents.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.gridComponents.AllowSort = True
            Me.gridComponents.AlternatingRows = True
            Me.gridComponents.CaptionHeight = 17
            Me.gridComponents.CollapseColor = System.Drawing.Color.Black
            Me.gridComponents.DataChanged = False
            Me.gridComponents.BackColor = System.Drawing.Color.Empty
            Me.gridComponents.ExpandColor = System.Drawing.Color.Black
            Me.gridComponents.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridComponents.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.gridComponents.Location = New System.Drawing.Point(392, 160)
            Me.gridComponents.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.gridComponents.Name = "gridComponents"
            Me.gridComponents.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gridComponents.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gridComponents.PreviewInfo.ZoomFactor = 75
            Me.gridComponents.PrintInfo.ShowOptionsDialog = False
            Me.gridComponents.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.gridComponents.RowDivider = GridLines1
            Me.gridComponents.RowHeight = 15
            Me.gridComponents.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.gridComponents.ScrollTips = False
            Me.gridComponents.Size = New System.Drawing.Size(368, 224)
            Me.gridComponents.TabIndex = 29
            Me.gridComponents.Text = "C1TrueDBGrid1"
            Me.gridComponents.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Level=""0"" Caption=""Bill Code"" " & _
            "DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Caption=""Ref D" & _
            "es"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Caption=""R" & _
            "ef Des Num"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0"" Ca" & _
            "ption=""Failure"" DataField=""""><ValueItems /></C1DataColumn><C1DataColumn Level=""0" & _
            """ Caption=""Price"" DataField=""""><ValueItems /></C1DataColumn></DataCols><Styles t" & _
            "ype=""C1.Win.C1TrueDBGrid.Design.ContextWrapper""><Data>Caption{AlignHorz:Center;}" & _
            "Style27{AlignHorz:Near;}Normal{}Style25{}Selected{ForeColor:HighlightText;BackCo" & _
            "lor:Highlight;}Editor{}Style14{AlignHorz:Near;}Style15{AlignHorz:Near;}Style16{}" & _
            "Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{}Style13{}Style12{}Style37{}Sty" & _
            "le34{AlignHorz:Near;}Style35{AlignHorz:Near;}Style32{}Style33{}Style31{AlignHorz" & _
            ":Near;}Footer{}Style29{}Style28{}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style26{AlignHorz:Near;}RecordSelector{AlignImage:Center;}Style24{}St" & _
            "yle23{AlignHorz:Near;}Style22{AlignHorz:Near;}Inactive{ForeColor:InactiveCaption" & _
            "Text;BackColor:InactiveCaption;}EvenRow{BackColor:Aqua;}Heading{Wrap:True;AlignV" & _
            "ert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Fi" & _
            "lterBar{}Style4{}Style9{}Style8{}Style36{}Style5{}Group{BackColor:ControlDark;Bo" & _
            "rder:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style30{AlignHor" & _
            "z:Near;}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView N" & _
            "ame="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Co" & _
            "lumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" D" & _
            "efRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect" & _
            ">0, 0, 364, 220</ClientRect><BorderSide>0</BorderSide><CaptionStyle parent=""Styl" & _
            "e2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle pare" & _
            "nt=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Fo" & _
            "oterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" " & _
            "/><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highli" & _
            "ghtRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyl" & _
            "e parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=" & _
            """Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal" & _
            """ me=""Style1"" /><internalCols><C1DisplayColumn><HeadingStyle parent=""Style2"" me=" & _
            """Style14"" /><Style parent=""Style1"" me=""Style15"" /><FooterStyle parent=""Style3"" m" & _
            "e=""Style16"" /><EditorStyle parent=""Style5"" me=""Style17"" /><Visible>True</Visible" & _
            "><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>0</DCId" & _
            "x></C1DisplayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style22"" " & _
            "/><Style parent=""Style1"" me=""Style23"" /><FooterStyle parent=""Style3"" me=""Style24" & _
            """ /><EditorStyle parent=""Style5"" me=""Style25"" /><Visible>True</Visible><ColumnDi" & _
            "vider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>1</DCIdx></C1Disp" & _
            "layColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style26"" /><Style p" & _
            "arent=""Style1"" me=""Style27"" /><FooterStyle parent=""Style3"" me=""Style28"" /><Edito" & _
            "rStyle parent=""Style5"" me=""Style29"" /><Visible>True</Visible><ColumnDivider>Dark" & _
            "Gray,Single</ColumnDivider><Height>15</Height><DCIdx>2</DCIdx></C1DisplayColumn>" & _
            "<C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style30"" /><Style parent=""Sty" & _
            "le1"" me=""Style31"" /><FooterStyle parent=""Style3"" me=""Style32"" /><EditorStyle par" & _
            "ent=""Style5"" me=""Style33"" /><Visible>True</Visible><ColumnDivider>DarkGray,Singl" & _
            "e</ColumnDivider><Height>15</Height><DCIdx>3</DCIdx></C1DisplayColumn><C1Display" & _
            "Column><HeadingStyle parent=""Style2"" me=""Style34"" /><Style parent=""Style1"" me=""S" & _
            "tyle35"" /><FooterStyle parent=""Style3"" me=""Style36"" /><EditorStyle parent=""Style" & _
            "5"" me=""Style37"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single</ColumnD" & _
            "ivider><Height>15</Height><DCIdx>4</DCIdx></C1DisplayColumn></internalCols></C1." & _
            "Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" />" & _
            "<Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Sty" & _
            "le parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Styl" & _
            "e parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style pa" & _
            "rent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style p" & _
            "arent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Styl" & _
            "e parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedS" & _
            "tyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layo" & _
            "ut><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 364, 220</Client" & _
            "Area></Blob>"
            '
            'grpMotoAction
            '
            Me.grpMotoAction.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.Button2, Me.Button3})
            Me.grpMotoAction.Location = New System.Drawing.Point(24, 160)
            Me.grpMotoAction.Name = "grpMotoAction"
            Me.grpMotoAction.Size = New System.Drawing.Size(360, 264)
            Me.grpMotoAction.TabIndex = 30
            Me.grpMotoAction.TabStop = False
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbProblem, Me.tbRepair, Me.tbPartsNotAvailable})
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(344, 216)
            Me.TabControl1.TabIndex = 15
            '
            'tbProblem
            '
            Me.tbProblem.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPFdefault, Me.btnPFcomplete, Me.clboxProblem})
            Me.tbProblem.Location = New System.Drawing.Point(4, 22)
            Me.tbProblem.Name = "tbProblem"
            Me.tbProblem.Size = New System.Drawing.Size(336, 190)
            Me.tbProblem.TabIndex = 0
            Me.tbProblem.Text = "Problem Found"
            '
            'btnPFdefault
            '
            Me.btnPFdefault.Location = New System.Drawing.Point(176, 160)
            Me.btnPFdefault.Name = "btnPFdefault"
            Me.btnPFdefault.Size = New System.Drawing.Size(75, 24)
            Me.btnPFdefault.TabIndex = 18
            Me.btnPFdefault.TabStop = False
            Me.btnPFdefault.Text = "Default"
            '
            'btnPFcomplete
            '
            Me.btnPFcomplete.Location = New System.Drawing.Point(256, 160)
            Me.btnPFcomplete.Name = "btnPFcomplete"
            Me.btnPFcomplete.Size = New System.Drawing.Size(75, 24)
            Me.btnPFcomplete.TabIndex = 17
            Me.btnPFcomplete.Text = "Complete"
            '
            'clboxProblem
            '
            Me.clboxProblem.Location = New System.Drawing.Point(8, 8)
            Me.clboxProblem.Name = "clboxProblem"
            Me.clboxProblem.Size = New System.Drawing.Size(320, 154)
            Me.clboxProblem.TabIndex = 16
            '
            'tbRepair
            '
            Me.tbRepair.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRdefault, Me.btnRcomplete, Me.clboxRepair})
            Me.tbRepair.Location = New System.Drawing.Point(4, 22)
            Me.tbRepair.Name = "tbRepair"
            Me.tbRepair.Size = New System.Drawing.Size(336, 190)
            Me.tbRepair.TabIndex = 1
            Me.tbRepair.Text = "Repair Action"
            '
            'btnRdefault
            '
            Me.btnRdefault.Location = New System.Drawing.Point(176, 160)
            Me.btnRdefault.Name = "btnRdefault"
            Me.btnRdefault.Size = New System.Drawing.Size(75, 24)
            Me.btnRdefault.TabIndex = 19
            Me.btnRdefault.TabStop = False
            Me.btnRdefault.Text = "Default"
            '
            'btnRcomplete
            '
            Me.btnRcomplete.Location = New System.Drawing.Point(256, 160)
            Me.btnRcomplete.Name = "btnRcomplete"
            Me.btnRcomplete.Size = New System.Drawing.Size(75, 24)
            Me.btnRcomplete.TabIndex = 18
            Me.btnRcomplete.Text = "Complete"
            '
            'clboxRepair
            '
            Me.clboxRepair.Location = New System.Drawing.Point(8, 6)
            Me.clboxRepair.Name = "clboxRepair"
            Me.clboxRepair.Size = New System.Drawing.Size(320, 154)
            Me.clboxRepair.TabIndex = 17
            '
            'tbPartsNotAvailable
            '
            Me.tbPartsNotAvailable.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboPartNum, Me.Label1, Me.cboFailCode, Me.cboRefDes, Me.cboBillCode, Me.btnDeleteComponent, Me.btnAddComponent, Me.txtRefDesNum, Me.lblFailCode, Me.lblRefDesNum, Me.lblRefDes, Me.lblBillCode})
            Me.tbPartsNotAvailable.Location = New System.Drawing.Point(4, 22)
            Me.tbPartsNotAvailable.Name = "tbPartsNotAvailable"
            Me.tbPartsNotAvailable.Size = New System.Drawing.Size(336, 190)
            Me.tbPartsNotAvailable.TabIndex = 2
            Me.tbPartsNotAvailable.Text = "Parts"
            '
            'cboPartNum
            '
            Me.cboPartNum.AutoComplete = True
            Me.cboPartNum.Location = New System.Drawing.Point(128, 16)
            Me.cboPartNum.Name = "cboPartNum"
            Me.cboPartNum.Size = New System.Drawing.Size(200, 21)
            Me.cboPartNum.TabIndex = 18
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(8, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(120, 16)
            Me.Label1.TabIndex = 16
            Me.Label1.Text = "Part#:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboFailCode
            '
            Me.cboFailCode.AutoComplete = True
            Me.cboFailCode.Location = New System.Drawing.Point(128, 112)
            Me.cboFailCode.Name = "cboFailCode"
            Me.cboFailCode.Size = New System.Drawing.Size(200, 21)
            Me.cboFailCode.TabIndex = 22
            '
            'cboRefDes
            '
            Me.cboRefDes.AutoComplete = True
            Me.cboRefDes.Location = New System.Drawing.Point(128, 64)
            Me.cboRefDes.Name = "cboRefDes"
            Me.cboRefDes.Size = New System.Drawing.Size(200, 21)
            Me.cboRefDes.TabIndex = 20
            '
            'cboBillCode
            '
            Me.cboBillCode.AutoComplete = True
            Me.cboBillCode.Location = New System.Drawing.Point(128, 40)
            Me.cboBillCode.Name = "cboBillCode"
            Me.cboBillCode.Size = New System.Drawing.Size(200, 21)
            Me.cboBillCode.TabIndex = 19
            '
            'btnDeleteComponent
            '
            Me.btnDeleteComponent.Location = New System.Drawing.Point(176, 144)
            Me.btnDeleteComponent.Name = "btnDeleteComponent"
            Me.btnDeleteComponent.Size = New System.Drawing.Size(72, 40)
            Me.btnDeleteComponent.TabIndex = 4
            Me.btnDeleteComponent.TabStop = False
            Me.btnDeleteComponent.Text = "Delete Component"
            '
            'btnAddComponent
            '
            Me.btnAddComponent.Location = New System.Drawing.Point(256, 144)
            Me.btnAddComponent.Name = "btnAddComponent"
            Me.btnAddComponent.Size = New System.Drawing.Size(72, 40)
            Me.btnAddComponent.TabIndex = 23
            Me.btnAddComponent.Text = "Add Component"
            '
            'txtRefDesNum
            '
            Me.txtRefDesNum.Location = New System.Drawing.Point(128, 88)
            Me.txtRefDesNum.Name = "txtRefDesNum"
            Me.txtRefDesNum.Size = New System.Drawing.Size(56, 20)
            Me.txtRefDesNum.TabIndex = 21
            Me.txtRefDesNum.Text = ""
            '
            'lblFailCode
            '
            Me.lblFailCode.Location = New System.Drawing.Point(8, 112)
            Me.lblFailCode.Name = "lblFailCode"
            Me.lblFailCode.Size = New System.Drawing.Size(120, 16)
            Me.lblFailCode.TabIndex = 13
            Me.lblFailCode.Text = "Failure Code:"
            Me.lblFailCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRefDesNum
            '
            Me.lblRefDesNum.Location = New System.Drawing.Point(8, 88)
            Me.lblRefDesNum.Name = "lblRefDesNum"
            Me.lblRefDesNum.Size = New System.Drawing.Size(120, 16)
            Me.lblRefDesNum.TabIndex = 12
            Me.lblRefDesNum.Text = "Ref. Des. Number:"
            Me.lblRefDesNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRefDes
            '
            Me.lblRefDes.Location = New System.Drawing.Point(8, 64)
            Me.lblRefDes.Name = "lblRefDes"
            Me.lblRefDes.Size = New System.Drawing.Size(120, 16)
            Me.lblRefDes.TabIndex = 14
            Me.lblRefDes.Text = "Reference Designator:"
            Me.lblRefDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBillCode
            '
            Me.lblBillCode.Location = New System.Drawing.Point(8, 40)
            Me.lblBillCode.Name = "lblBillCode"
            Me.lblBillCode.Size = New System.Drawing.Size(120, 16)
            Me.lblBillCode.TabIndex = 15
            Me.lblBillCode.Text = "Bill Code:"
            Me.lblBillCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboDeviceSN
            '
            Me.cboDeviceSN.Location = New System.Drawing.Point(368, 8)
            Me.cboDeviceSN.Name = "cboDeviceSN"
            Me.cboDeviceSN.Size = New System.Drawing.Size(152, 21)
            Me.cboDeviceSN.TabIndex = 1
            '
            'frmTechScreen
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(784, 429)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboDeviceSN, Me.grpMotoAction, Me.gridComponents, Me.grpMotorola, Me.grpDetail, Me.btnAddComponentMoto, Me.txtTray, Me.lblTray, Me.lblDeviceSN, Me.Button1})
            Me.Name = "frmTechScreen"
            Me.Text = "frmTechScreen"
            Me.grpDetail.ResumeLayout(False)
            Me.grpMotorola.ResumeLayout(False)
            CType(Me.gridComponents, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpMotoAction.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.tbProblem.ResumeLayout(False)
            Me.tbRepair.ResumeLayout(False)
            Me.tbPartsNotAvailable.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private dtBillCode As DataTable
        Private dtRefDes As DataTable
        Private dtFailureCode As DataTable
        Private dtRepairCode As DataTable

        Private dtSerialNum As DataTable
        Private dtPartData As DataTable
        Private tmpDeviceID As Int32
        Private tmpModelID As Int32
        Private tmpManufID As Int32
        Private tmpTrayID As Int32
        Public datagrid As DataTable

        Private _device As Device = Nothing
        Private _tray As DataTable = Nothing
        Private valBillCode As Integer
        Private valOldRepStat As String
        Private chgBillCode As Boolean
        Private tstPriority As Boolean


        Private Sub frmTechScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Me.txtTray.Focus()
            Try
                cboTechID.Items.Clear()
            Catch ex As Exception
            End Try
            cboTechID.Items.Add("102")
            cboTechID.Text = "102"

        End Sub


        Private Sub loadParts()

            Try
                datagrid.Clear()
            Catch ex As Exception
            End Try
            Dim dtP As New PSS.Data.Production.Joins()
            Dim dtParts As DataTable = dtP.GenericSelect("select lbillcodes.billcode_desc, tdevicebill.* from (tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id) WHERE tdevicebill.device_id=" & tmpModelID & " ORDER BY BillCode_Desc")

            Dim xcount As Integer = 0
            Dim r As DataRow
            Dim dr1 As DataRow

            For xcount = 0 To dtParts.Rows.Count - 1
                r = dtParts.Rows(xcount)
                dr1 = datagrid.NewRow()
                dr1("PartNum") = r("billcode_desc")
                datagrid.Rows.Add(dr1)
            Next

            Try
                dtParts.Dispose()
                dtParts = Nothing
            Catch ex As Exception
            End Try

        End Sub




        Private Function CreateGridDT() As DataTable

            Dim dtGrid As New DataTable("dtGridMain")

            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim dcPNID As New DataColumn("Bill Code ID")
            dtGrid.Columns.Add(dcPNID)
            Dim dcPartNum As New DataColumn("Bill Code")
            dtGrid.Columns.Add(dcPartNum)
            Dim dcQty As New DataColumn("Quantity")
            dtGrid.Columns.Add(dcQty)
            Dim dcRefDes As New DataColumn("Ref Des")
            dtGrid.Columns.Add(dcRefDes)
            Dim dcRefDesNum As New DataColumn("Ref Des Num")
            dtGrid.Columns.Add(dcRefDesNum)
            Dim dcFail As New DataColumn("Fail Code")
            dtGrid.Columns.Add(dcFail)

            CreateGridDT = dtGrid

        End Function



        Private Sub getPartData(ByVal ModelID As Int32)

            Dim dtPdata As New PSS.Data.Buisness.DeviceBilling()
            Dim dtPartData As DataTable = dtPdata.GetPartData(ModelID)

            Try
                dtPartData.Dispose()
                dtPartData = Nothing
            Catch ex As Exception
            End Try

            'MsgBox("Part Data count is : " & dtPartData.Rows.Count)

        End Sub


        Private Sub getData(ByVal TrayNum As Int32, ByVal deviceSN As String)

            tmpDeviceID = 0
            tmpModelID = 0
            tmpTrayID = 0
            tmpManufID = 0
            valOldRepStat = ""

            tmpTrayID = Me.txtTray.Text

            Dim mthd As New PSS.Data.Production.tdevice()
            Dim mtDeviceID As DataTable = mthd.GetDataTableBySN(deviceSN)
            Dim r As DataRow
            Dim xCount As Integer = 0

            For xCount = 0 To mtDeviceID.Rows.Count - 1
                r = mtDeviceID.Rows(xCount)
                If r("Tray_ID") = TrayNum Then
                    tmpDeviceID = r("Device_ID")
                    tmpModelID = r("Model_ID")
                    Exit For
                End If
            Next

            Try
                mtDeviceID.Dispose()
                mtDeviceID = Nothing
            Catch ex As Exception
            End Try

            Dim mtManuf As New PSS.Data.Production.tmodel()
            Dim mtManufID As DataRow = mtManuf.GetRowByModel(tmpModelID)
            tmpManufID = mtManufID("Manuf_ID")
            If tmpDeviceID = 0 Or tmpModelID = 0 Or tmpManufID = 0 Then
                Exit Sub
            End If


            '//Get values from tcellopt
            Dim mthdCO As New PSS.Data.Production.tcellopt()
            Dim mtData As DataRow = mthdCO.GetRowByDeviceID(tmpDeviceID)
            '//FIll form with data
            If IsDBNull(mtData("CellOpt_OutMSN")) = False Then Me.txtOutgoingMSN.Text = mtData("CellOpt_OutMSN")
            If IsDBNull(mtData("CellOpt_OutIMEI")) = False Then txtOutgoingIMEI.Text = mtData("CellOpt_OutIMEI")
            If IsDBNull(mtData("CellOpt_OutCSN")) = False Then txtOutgoingESNCSN.Text = mtData("CellOpt_OutCSN")
            If IsDBNull(mtData("CellOpt_MIN")) = False Then txtMINnumber.Text = mtData("CellOpt_MIN")
            If IsDBNull(mtData("CellOpt_SoftVerIN")) = False Then txtSoftwareVerIN.Text = mtData("CellOpt_SoftVerIN")
            If IsDBNull(mtData("CellOpt_SoftVerOUT")) = False Then txtSoftwareVerOUT.Text = mtData("CellOpt_SoftVerOUT")
            If IsDBNull(mtData("CellOpt_Airtime")) = False Then txtAirtime.Text = mtData("CellOpt_Airtime")
            If IsDBNull(mtData("CellOpt_RepairTime")) = False Then txtRepairTime.Text = mtData("CellOpt_RepairTime")
            If IsDBNull(mtData("CellOpt_CycleTime")) = False Then txtRepairCycleTime.Text = mtData("CellOpt_CycleTime")

            '//Get IN values for specific elements
            Dim INmsn As String = ""
            Dim INcsn As String = ""
            Dim INimei As String = ""
            If IsDBNull(mtData("CellOpt_MSN")) = False Then INmsn = mtData("CellOpt_MSN")
            If IsDBNull(mtData("CellOpt_CSN")) = False Then INcsn = mtData("CellOpt_CSN")
            If IsDBNull(mtData("CellOpt_IMEI")) = False Then INimei = mtData("CellOpt_IMEI")
            '//Replace with OUT values if OUT values are not defined
            If Len(Trim(txtOutgoingMSN.Text)) < 1 Then txtOutgoingMSN.Text = INmsn
            If Len(Trim(txtOutgoingESNCSN.Text)) < 1 Then txtOutgoingESNCSN.Text = INcsn
            If Len(Trim(txtOutgoingIMEI.Text)) < 1 Then txtOutgoingIMEI.Text = INimei

            'cboTech
            '            If IsDBNull(mtData("CellOpt_TechID")) = False Then
            '            For xCount = 0 To Me.cboTechID.Items.Count - 1
            '                If Me.cboTechID.Items(xCount) = mtData("CellOpt_TechID") Then
            '                    cboTechID.Text = cboTechID.Items(xCount)
            '                    Exit For
            '                End If
            '            Next
            '            End If
            If IsDBNull(mtData("CellOpt_TechID")) = False Then
                cboTechID.Text = mtData("CellOpt_TechID")
            Else
                cboTechID.Text = "102"
            End If

            'cboRepairStatus
            '            If IsDBNull(mtData("CellOpt_RepairStatus")) = False Then
            '            For xCount = 0 To Me.cboRepairStatus.Items.Count - 1
            '                If Me.cboRepairStatus.Items(xCount) = mtData("CellOpt_RepairStatus") Then
            '                    cboRepairStatus.Text = cboRepairStatus.Items(xCount)
            '                    Exit For
            '                End If
            '            Next
            '            End If



            getPartData(tmpModelID)


            loadGroup("Repair Status", "DCode_LDesc", cboRepairStatus)

            If IsDBNull(mtData("CellOpt_RepairStatus")) = False Then

                '//Convert value over to ldesc
                Dim rRC As DataRow
                For xCount = 0 To dtRepairCode.Rows.Count - 1
                    rRC = dtRepairCode.Rows(xCount)
                    If Trim(rRC("Dcode_SDesc")) = Trim(mtData("CellOpt_RepairStatus")) Then
                        cboRepairStatus.Text = rRC("Dcode_LDesc")
                        Exit For
                    End If
                Next
                'cboRepairStatus.Text = mtData("CellOpt_RepairStatus")
                'valOldRepStat = mtData("CellOpt_RepairStatus")
                valOldRepStat = mtData("CellOpt_RepairStatus")
            Else
                valOldRepStat = ""
            End If

            'cboRepairDate
            If IsDBNull(mtData("CellOpt_RepairDate")) = False Then cboRepairDate.Text = mtData("CellOpt_RepairDate")

            txtOutgoingMSN.Focus()

        End Sub

        Private Function updateData() As Boolean

            updateData = False

            Dim xCount As Integer = 0
            Dim rRC As DataRow
            Dim valNewRepStat As String = ""

            For xCount = 0 To dtRepairCode.Rows.Count - 1
                rRC = dtRepairCode.Rows(xCount)
                If Trim(rRC("Dcode_LDesc")) = Trim(cboRepairStatus.Text) Then
                    valNewRepStat = rRC("Dcode_SDesc")
                    Exit For
                End If
            Next

            If Trim(valNewRepStat) <> Trim(valOldRepStat) Then
                '//Update the send claim value to 0
                Dim mthdFlag As New PSS.Data.Production.Joins()
                Dim blnUpdateFlag As Boolean = mthdFlag.OrderEntryUpdateDelete("UPDATE tdevice SET Device_SendClaim = 0 WHERE Device_ID = " & tmpDeviceID)
                mthdFlag = Nothing
            End If

            Dim strUpdateList As String = ""

            If Len(Trim(txtOutgoingMSN.Text)) > 0 Then
                strUpdateList += "CellOpt_OutMSN = '" & Trim(txtOutgoingMSN.Text) & "',"
            Else
                strUpdateList += "CellOpt_OutMSN = NULL ,"
            End If

            If Len(Trim(txtOutgoingIMEI.Text)) > 0 Then
                strUpdateList += "CellOpt_OutIMEI = '" & Trim(txtOutgoingIMEI.Text) & "',"
            Else
                strUpdateList += "CellOpt_OutIMEI = NULL ,"
            End If

            If Len(Trim(txtOutgoingESNCSN.Text)) > 0 Then
                strUpdateList += "CellOpt_OutCSN = '" & Trim(txtOutgoingESNCSN.Text) & "',"
            Else
                strUpdateList += "CellOpt_OutCSN = NULL ,"
            End If

            If Len(Trim(txtMINnumber.Text)) > 0 Then
                strUpdateList += "CellOpt_MIN = '" & Trim(txtMINnumber.Text) & "',"
            Else
                strUpdateList += "CellOpt_MIN = NULL ,"
            End If

            If Len(Trim(txtSoftwareVerIN.Text)) > 0 Then
                strUpdateList += "CellOpt_SoftVerIN = '" & Trim(txtSoftwareVerIN.Text) & "',"
            Else
                strUpdateList += "CellOpt_SoftVerIN = NULL ,"
            End If

            If Len(Trim(txtSoftwareVerOUT.Text)) > 0 Then
                strUpdateList += "CellOpt_SoftVerOUT = '" & Trim(txtSoftwareVerOUT.Text) & "',"
            Else
                strUpdateList += "CellOpt_SoftVerOUT = NULL ,"
            End If

            If Len(Trim(cboTechID.Text)) > 0 Then
                strUpdateList += "CellOpt_TechID = '" & Trim(cboTechID.Text) & "',"
            Else
                strUpdateList += "CellOpt_TechID = '102' ,"
            End If

            If Len(Trim(txtAirtime.Text)) > 0 Then

                'Dim x As Integer = 0
                'Dim vCheck As String
                'Dim blnAirtime As Boolean = False
                'For x = 1 To Len(Trim(txtAirtime.Text))
                'Try
                'If CInt(Mid(txtAirtime.Text, x, 1)) = False Then blnAirtime = True
                'If Mid(txtAirtime.Text, x, 1) = "-" Then
                'blnAirtime = False
                'Else
                '    blnAirtime = True
                '    Exit For
                'End If
                'Catch
                'End Try
                'Next
                'If blnAirtime = True Then
                'MsgBox("Invalid Airtime")
                'Exit Function
                'Else
                'End If

            '/Convert over time to minutes
            'Dim vHour As Integer
            'Dim vMinute As Integer
            'Dim tmpStr As String
            'Dim intH, intM, ttlM As Integer
            'intH = InStr(txtAirtime.Text, "-")
            'vHour = Mid$(txtAirtime.Text, 1, intH - 1)
            'intM = InStr(Mid$(txtAirtime.Text, vHour + 1), "-")
            'vMinute = Mid$(Mid$(txtAirtime.Text, vHour + 1), 1, intH - 1)
            'ttlM = (vHour * 60) + vMinute
            'strUpdateList += "CellOpt_Airtime = '" & Trim(txtAirtime.Text) & "',"
            strUpdateList += "CellOpt_Airtime = '" & Trim(txtAirtime.Text) & "',"
            Else
            strUpdateList += "CellOpt_Airtime = NULL ,"
            End If

            If Len(Trim(valNewRepStat)) > 0 Then
                strUpdateList += "CellOpt_RepairStatus = '" & valNewRepStat & "',"
            Else
                strUpdateList += "CellOpt_RepairStatus = NULL ,"
            End If


            '            If Len(Trim(cboRepairStatus.Text)) > 0 Then
            '            strUpdateList += "CellOpt_RepairStatus = '" & Trim(cboRepairStatus.Text) & "',"
            '            Else
            '                strUpdateList += "CellOpt_RepairStatus = NULL ,"
            '            End If

            If Len(Trim(cboRepairDate.Text)) > 0 Then
                strUpdateList += "CellOpt_RepairDate = '" & Receiving.General.FormatDate(Trim(cboRepairDate.Text)) & "',"
            Else
                strUpdateList += "CellOpt_RepairDate = NULL ,"
            End If

            If Len(Trim(txtRepairTime.Text)) > 0 Then
                strUpdateList += "CellOpt_RepairTime = '" & Trim(txtRepairTime.Text) & "',"
            Else
                strUpdateList += "CellOpt_RepairTime = NULL ,"
            End If

            If Len(Trim(txtRepairCycleTime.Text)) > 0 Then
                strUpdateList += "CellOpt_CycleTime = '" & Trim(txtRepairCycleTime.Text) & "'"
            Else
                strUpdateList += "CellOpt_CycleTime = NULL "
            End If

            Dim strSQL As String = "UPDATE tcellopt SET " & strUpdateList & " WHERE Device_ID = " & tmpDeviceID

            '//Perform the update of data to the tcellopt table
            Dim mthd As New PSS.Data.Production.tcellopt()
            Dim blnUpdate As Boolean = mthd.UpdateCellOptData(strSQL)

            updateData = blnUpdate

        End Function

        Private Sub btnAddComponentMoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddComponentMoto.Click

            Me.btnDeleteComponent.Visible = False
            Me.btnAddComponent.Visible = True

            Me.TabControl1.SelectedIndex = 2
            Me.TabControl1.TabPages(2).Controls(1).Focus()

        End Sub

        Private Sub defineGridComponents()

            datagrid = CreateGridDT()
            gridComponents.DataSource = datagrid

        End Sub

        Private Sub MAE_SetColor(ByVal sender As System.Object, ByVal e As System.EventArgs)
            MAE_RemoveColor()
            sender.BackColor = System.Drawing.Color.DodgerBlue
            sender.ForeColor = System.Drawing.Color.Yellow
        End Sub

        Private Sub MAE_RemoveColor()
            Dim x As Integer
            For x = 0 To Me.grpMotoAction.Controls.Count - 1
                If Mid$(Me.grpMotoAction.Controls(x).Name, 1, 3) = "MAE" Then
                    Me.grpMotoAction.Controls(x).BackColor = System.Drawing.SystemColors.Control
                    Me.grpMotoAction.Controls(x).ForeColor = System.Drawing.SystemColors.ControlText
                End If
            Next
        End Sub

        Private Sub txtTray_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTray.TextChanged

        End Sub

        Private Sub txtTray_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTray.Leave

            'Verify data is valid for tray_id
            If IsNumeric(txtTray.Text) = False Then
                MsgBox("Please enter a valid tray number.", MsgBoxStyle.OKOnly, "ERROR")
                txtTray.Text = ""
                txtTray.Focus()
                Exit Sub
            End If


            'Populate the dtSerialNum
            Try
                dtSerialNum.Clear()
            Catch exp As Exception
                '//Do not display anything...Will come here if dtSerialNum is empty
            End Try

            Dim dataSN As New PSS.Data.Production.tdevice()
            dtSerialNum = dataSN.GetDataTableByTray(txtTray.Text)


        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            tstPriority = True

            defineGridComponents()

            getData(Me.txtTray.Text, Me.cboDeviceSN.Text)

            Try
                clboxProblem.Items.Clear()
                clboxRepair.Items.Clear()
            Catch
            End Try

            '//START
            '//Use these once the priority level has been set in the table
            populateCodePRIORITY(9, clboxProblem)
            If tstPriority = False Then populateCodeSMALL(9, clboxProblem)
            tstPriority = True
            populateCodePRIORITY(3, clboxRepair)
            If tstPriority = False Then populateCodeSMALL(3, clboxRepair)
            '//Use these once the priority level has been set in the table
            '//END

            txtOutgoingMSN.Focus()

            'NEW CDH
            loadGroup("Reference Designator", "DCode_LDesc", cboRefDes)
            loadGroup("Failure", "DCode_LDesc", cboFailCode)
            '            loadGroup("Repair Status", "DCode_LDesc", cboRepairStatus)

            loadBillCodes()
            Me.LoadTray()
            Me.LoadDevice()
            populateParts()

            'NEW CDH December 7, 2003
            '/Determine if valid for billing
            Dim mthd As New PSS.Data.Production.Joins()
            Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT tcustomer.cust_repairnonwrty, tcustomer.cust_ReplaceLCD, tdevice.device_manufwrty FROM ((tcustomer INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID) INNER JOIN tdevice ON tdevice.loc_ID = tlocation.Loc_ID) WHERE tray_id = " & txtTray.Text & " AND device_SN = '" & cboDeviceSN.Text & "'")
            Dim vNER As DataTable = mthd.GenericSelect("SELECT * FROM tdevicebill where device_id = " & tmpDeviceID)
            Dim blnNER As Boolean = False
            Dim blnUpdDate As Boolean

            Dim r As DataRow
            Dim xCount As Integer = 0

            For xCount = 0 To vNER.Rows.Count - 1
                r = vNER.Rows(xCount)
                If r("BillCode_ID") = 270 Then
                    blnNER = True
                    Exit For
                End If
            Next


            For xCount = 0 To mthdGrp.Rows.Count - 1
                r = mthdGrp.Rows(xCount)
                If r("Cust_RepairNonWrty") = 0 And r("Device_ManufWrty") = 0 And r("Cust_ReplaceLCD") = 0 Then
                    MsgBox("This customer does not approve non warranty repairs. Please do not try to bill.", MsgBoxStyle.OKOnly)
                    If blnNER = False Then
                        Try
                            _device.AddPart(270)
                            If tmpDeviceID > 0 Then
                                blnUpdDate = mthd.OrderEntryUpdateDelete("UPDATE tdevice set Device_DateBill = now() WHERE Device_ID = " & tmpDeviceID)
                            End If
                        Catch ex As Exception
                        End Try
                        HotKeysF12()
                        populateParts()
                        Exit For
                    End If
                End If
            Next

            Try
                mthdGrp.Dispose()
                mthdGrp = Nothing
            Catch ex As Exception
            End Try

            'NEW CDH December 7, 2003

        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


            '/Add New TEST
            Dim strCheck As String

            strCheck = ""
            'If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then strCheck = strCheck & " No Software Version IN Defined." & vbCrLf
            'If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then strCheck = strCheck & " No Software Version OUT Defined." & vbCrLf
            'If clboxProblem.CheckedItems.Count < 1 Then strCheck = strCheck & " No Problem Found Defined." & vbCrLf
            'If clboxRepair.CheckedItems.Count < 1 Then strCheck = strCheck & " No Repair Action Defined." & vbCrLf

            If Len(strCheck) > 0 Then
                strCheck = strCheck & vbCrLf & "Please supply the requested data. The system will NOT save the data until all required fields have been entered."
                MsgBox(strCheck, MsgBoxStyle.OKOnly)
                Exit Sub
            End If

            Dim blnUpd As Boolean = updateData()
            If blnUpd = False Then
                MsgBox("Did not update correctly")
            End If
            saveClboxInfo(tmpDeviceID)

            'clearData()
            'tmpDeviceID = 0

            'NEW Craig Haney January 12, 2004
            Try
                _device.Dispose()
                _tray.Dispose()

                _device = Nothing
                _tray = Nothing
            Catch ex As Exception
            End Try

            'NEW Craig Haney January 12, 2004

        End Sub

        Private Sub clearData()

            tmpDeviceID = 0
            txtOutgoingMSN.Text = ""
            txtOutgoingIMEI.Text = ""
            txtOutgoingESNCSN.Text = ""
            txtMINnumber.Text = ""
            txtSoftwareVerIN.Text = ""
            txtSoftwareVerOUT.Text = ""
            cboTechID.Text = "102"
            txtAirtime.Text = ""
            cboRepairStatus.Text = ""
            cboRepairDate.Text = Now
            txtRepairTime.Text = ""
            txtRepairCycleTime.Text = ""

            cboPartNum.Text = ""
            cboBillCode.Text = ""
            cboFailCode.Text = ""
            cboRefDes.Text = ""
            txtRefDesNum.Text = ""

            Try
                clboxProblem.Items.Clear()
                clboxRepair.Items.Clear()
            Catch
            End Try

            cboDeviceSN.Focus()

        End Sub

        Private Sub populateCode(ByVal txtType As Int32, ByVal ctl As CheckedListBox)

            Dim dDeviceCodes As New PSS.Data.Production.tdevicecodes()
            Dim dtDC As DataTable = dDeviceCodes.GetSelectedValues(tmpDeviceID, tmpManufID)
            Dim yCount As Integer = 0
            Dim blnVal As Boolean
            Dim rDC As DataRow

            Dim xCount As Integer
            Dim r As DataRow

            Dim dcode As New PSS.Data.Production.lcodesdetail()
            Dim dtCode = dcode.GetCodes(txtType, tmpManufID)

            For xCount = 0 To dtCode.rows.count - 1
                r = dtCode.rows(xCount)
                blnVal = False
                For yCount = 0 To dtDC.Rows.Count - 1
                    rDC = dtDC.Rows(yCount)
                    If r("Dcode_ID") = rDC("Dcode_ID") Then
                        blnVal = True
                        Exit For
                    End If
                Next
                If blnVal = True Then
                    ctl.Items.Add(r("Dcode_Ldesc"), True)
                Else
                    ctl.Items.Add(r("Dcode_Ldesc"), False)
                End If
            Next

            Try
                dtDC.Dispose()
                dtDC = Nothing
            Catch ex As Exception
            End Try



        End Sub



        Private Sub populateCodeSMALL(ByVal txtType As Int32, ByVal ctl As CheckedListBox)

            Dim dDeviceCodes As New PSS.Data.Production.tdevicecodes()
            Dim dtDC As DataTable = dDeviceCodes.GetSelectedValues(tmpDeviceID, tmpManufID)
            Dim yCount As Integer = 0
            Dim blnVal As Boolean
            Dim rDC As DataRow

            Dim xCount As Integer
            Dim r As DataRow

            Dim dcode As New PSS.Data.Production.lcodesdetail()
            Dim dtCode = dcode.GetCodesSMALL(txtType, tmpManufID)

            For xCount = 0 To dtCode.rows.count - 1
                r = dtCode.rows(xCount)
                blnVal = False
                For yCount = 0 To dtDC.Rows.Count - 1
                    rDC = dtDC.Rows(yCount)
                    If r("Dcode_ID") = rDC("Dcode_ID") Then
                        blnVal = True
                        Exit For
                    End If
                Next
                If blnVal = True Then
                    ctl.Items.Add(r("Dcode_Ldesc"), True)
                Else
                    ctl.Items.Add(r("Dcode_Ldesc"), False)
                End If
            Next

            Try
                dtDC.Dispose()
                dtDC = Nothing
            Catch ex As Exception
            End Try



        End Sub


        Private Sub populateCodePRIORITY(ByVal txtType As Int32, ByVal ctl As CheckedListBox)

            Dim dDeviceCodes As New PSS.Data.Production.tdevicecodes()
            Dim dtDC As DataTable = dDeviceCodes.GetSelectedValues(tmpDeviceID, tmpManufID)
            Dim yCount As Integer = 0
            Dim blnVal As Boolean
            Dim rDC As DataRow

            Dim xCount As Integer
            Dim r As DataRow

            Dim dcode As New PSS.Data.Production.lcodesdetail()
            Dim dtCode = dcode.GetCodesPRIORITY(txtType, tmpManufID)

            If dtCode.rows.count = 0 Then
                tstPriority = False
                Exit Sub
            End If

            For xCount = 0 To dtCode.rows.count - 1
                r = dtCode.rows(xCount)
                blnVal = False
                For yCount = 0 To dtDC.Rows.Count - 1
                    rDC = dtDC.Rows(yCount)
                    If r("Dcode_ID") = rDC("Dcode_ID") Then
                        blnVal = True
                        Exit For
                    End If
                Next
                If blnVal = True Then
                    ctl.Items.Add(r("Dcode_Ldesc"), True)
                Else
                    ctl.Items.Add(r("Dcode_Ldesc"), False)
                End If
            Next

            Try
                dtDC.Dispose()
                dtDC = Nothing
            Catch ex As Exception
            End Try



        End Sub




        Private Sub saveClboxInfo(ByVal intDevice As Int32)

            Dim xCount As Integer = 0
            Dim yCount As Integer = 0
            Dim r As DataRow
            Dim strDesc As String
            Dim strSQL As String
            Dim blnInsert As Boolean
            Dim dcode As New PSS.Data.Production.lcodesdetail()
            Dim dtCode = dcode.GetCodes(9, tmpManufID)

            Dim insCode As New PSS.Data.Production.tdevicecodes()

            'Delete codes before inserting
            Dim blnDelete As Boolean
            blnDelete = insCode.DeleteCodes(intDevice)

            If blnDelete = False Then MsgBox("Delete Failed contact IT", MsgBoxStyle.OKOnly)

            For xCount = 0 To Me.clboxProblem.CheckedItems.Count - 1
                strDesc = clboxProblem.CheckedItems(xCount)
                For yCount = 0 To dtCode.rows.count - 1
                    r = dtCode.rows(yCount)
                    If r("Dcode_Ldesc") = strDesc Then
                        strSQL = "INSERT into tdevicecodes(Device_ID,Dcode_ID) VALUES(" & intDevice & ", " & r("Dcode_ID") & ")"
                        blnInsert = insCode.UpdateCodes(strSQL)
                        Exit For
                    End If
                Next
            Next

            dtCode = dcode.GetCodes(3, tmpManufID)
            For xCount = 0 To Me.clboxRepair.CheckedItems.Count - 1
                strDesc = clboxRepair.CheckedItems(xCount)
                For yCount = 0 To dtCode.rows.count - 1
                    r = dtCode.rows(yCount)
                    If r("Dcode_Ldesc") = strDesc Then
                        strSQL = "INSERT into tdevicecodes(Device_ID,Dcode_ID) VALUES(" & intDevice & ", " & r("Dcode_ID") & ")"
                        blnInsert = insCode.UpdateCodes(strSQL)
                        Exit For
                    End If
                Next
            Next

        End Sub


        Private Sub loadGroup(ByVal valType As String, ByVal valField As String, ByVal valCtrl As Control)

            Try
                If valType = "Reference Designator" Then cboRefDes.Items.Clear()
                If valType = "Failure" Then cboFailCode.Items.Clear()
                If valType = "Repair Status" Then cboRepairStatus.Items.Clear()
            Catch ex As Exception
            End Try

            Dim mthd As New PSS.Data.Production.Joins()
            Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT * FROM " & _
            "(lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) " & _
            "WHERE MCode_DESC = '" & valType & "' AND lcodesdetail.manuf_ID= " & tmpManufID & " AND lcodesdetail.prod_id= 2 ORDER BY " & valField)

            If valType = "Reference Designator" Then
                dtRefDes = mthdGrp
            ElseIf valType = "Failure" Then
                dtFailureCode = mthdGrp
            ElseIf valType = "Repair Status" Then
                dtRepairCode = mthdGrp
            End If

            If valCtrl.GetType.ToString = "PSS.Gui.Controls.ComboBox" Then
                'If valCtrl.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                Dim xCount As Integer = 0
                Dim r As DataRow
                For xCount = 0 To mthdGrp.Rows.Count - 1
                    r = mthdGrp.Rows(xCount)
                    CType(valCtrl, ComboBox).Items.Add(r(valField))
                Next
            End If

            Try
                mthdGrp.Dispose()
                mthdGrp = Nothing
            Catch ex As Exception
            End Try

            'mthdGrp.Dispose()
            'mthdGrp = Nothing

        End Sub

        Private Sub loadBillCodes()

            Dim mthd As New PSS.Data.Production.Joins()

            Try
                cboBillCode.Items.Clear()
            Catch ex As Exception
            End Try

            Try
                cboPartNum.Items.Clear()
            Catch ex As Exception
            End Try

            'Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT lbillcodes.* FROM (lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id) WHERE tpsmap.model_id = " & tmpModelID & " ORDER BY BillCode_Desc")
            Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " ORDER BY BillCode_Desc")
            dtBillCode = mthdGrp
            Dim xCount As Integer = 0
            Dim r As DataRow
            For xCount = 0 To mthdGrp.Rows.Count - 1
                r = mthdGrp.Rows(xCount)
                cboPartNum.Items.Add(r("PSPrice_Number"))
                cboBillCode.Items.Add(r("BillCode_DESC"))
            Next

            mthdGrp.Dispose()
            mthdGrp = Nothing

        End Sub

        Private Sub LoadTray()

            If IsNumeric(tmpTrayID) Then
                Dim Source As DataTable = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(tmpTrayID)
                If Source.Rows.Count = 0 Then
                    MsgBox("This is not a valid tray.", MsgBoxStyle.Information, "Error")
                    _tray = Nothing
                Else
                    _tray = Source
                    'DoDeviceFields()
                End If
                Source = Nothing
            Else
                MsgBox("A tray number is all numeric. please enter a valid tray.", MsgBoxStyle.Information, "Error")
            End If

        End Sub

        Private Sub LoadDevice()
            Try
                Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(cboDeviceSN.Text) & "'")
                _device = New Device(__device(0)("Device_ID"))
                'Me.dbgParts.DataSource = _device.DefaultView
                'DoPartsFields()
                Dim i As Integer = 0
                For i = 0 To _tray.Rows.Count - 1
                    If _tray.Rows(i)("Device_SN") = UCase(cboDeviceSN.Text) Then
                        Exit For
                    End If
                Next
                'Me.dbgDevices.MoveRelative(0, i)
                'Me.dbgDevices.Row = i
                'Me.lblCust.Text = _device.Customer
                'If _device.EndUser = True Then LockPrint(True)

                'txtDevice.Text = UCase(txtDevice.Text)
                'txtPart.Focus()
            Catch ex As Exception
                MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                _device = Nothing
                ' Me.dbgParts.DataSource = Nothing
                'LockPrint(False)
                'Me.lblCust.Text = ""
                'txtDevice.Text = ""
            End Try
        End Sub

        Private Sub HotKeysF12()
            'If e.KeyCode = Keys.F12 Then
            If Len(Trim(tmpTrayID)) > 0 Then
                If Len(Trim(tmpDeviceID)) > 0 Then
                    'If Len(Trim(txtPart.Text)) > 0 Then
                    'txtPart.Text = ""
                    'End If
                    UpdateBilling()
                    'Me.dbgParts.DataSource = Nothing
                    '_device.Dispose()
                    '_device = Nothing
                    'Me.lblCust.Text = ""
                    'If Me._printOnF9 = True Then
                    '    Me.btnPrintDevice.Enabled = False
                    'End If
                    'txtDevice.Text = ""
                    'txtDevice.Focus()
                End If
            End If
            'End If
        End Sub

        Private Sub UpdateBilling()
            Try 'here in case there is not refrence to _device
                _device.Update()
                Dim d As DataRow() = _tray.Select("Device_ID = " & _device.ID)
                If _device.Parts.Rows.Count = 0 Then
                    d(0)("Device_DateBill") = DBNull.Value
                Else
                    d(0)("Device_DateBill") = Now
                End If
                d = Nothing
                '_device.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Information, "Error")
            Finally
            End Try
        End Sub


        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub btnAddComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddComponent.Click

            '//Get intial values
            Dim valRefDes As Integer
            Dim valFailureCode As Integer
            Dim devBillID As Int32

            valBillCode = 0
            valRefDes = 0
            valFailureCode = 0

            Dim xCount As Integer = 0
            Dim r As DataRow
            'BillCode
            For xCount = 0 To dtBillCode.Rows.Count - 1
                r = dtBillCode.Rows(xCount)
                If r("BillCode_Desc") = Me.cboBillCode.Text Then
                    valBillCode = r("BillCode_ID")
                    Exit For
                End If
            Next
            'RefDes
            For xCount = 0 To dtRefDes.Rows.Count - 1
                r = dtRefDes.Rows(xCount)
                If r("Dcode_LDesc") = Me.cboRefDes.Text Then
                    valRefDes = r("Dcode_ID")
                    Exit For
                End If
            Next
            'FailureCode
            For xCount = 0 To dtFailureCode.Rows.Count - 1
                r = dtFailureCode.Rows(xCount)
                If r("Dcode_LDesc") = Me.cboFailCode.Text Then
                    valFailureCode = r("Dcode_ID")
                    Exit For
                End If
            Next

            'Get Part Data Information
            _device.AddPart(valBillCode)
            System.Windows.Forms.Application.DoEvents()

            'Get tdevicebillID value and add records to tpartcodes
            Dim tDBillID As New PSS.Data.Production.tdevicebill()
            Dim dtBillID As DataTable = tDBillID.GetDataTableByDeviceBillCode(tmpDeviceID, valBillCode)
            For xCount = 0 To dtBillID.Rows.Count - 1
                r = dtBillID.Rows(xCount)
                devBillID = r("DBill_ID")
                Exit For
            Next

            Try
                dtBillID.Dispose()
                dtBillID = Nothing
            Catch ex As Exception
            End Try


            'Insert records into tpartscodes
            Dim tGeneric As New PSS.Data.Production.Joins()
            Dim genSQL As String = "INSERT INTO tpartscodes(DBill_ID, DCode_ID) VALUES( " & devBillID & ", " & valRefDes & ")"
            Dim blnGeneric As Boolean = tGeneric.OrderEntryUpdateDelete(genSQL)
            If blnGeneric = False Then
                MsgBox("Ref Des could not be inserted", MsgBoxStyle.OKOnly)
            End If


            genSQL = "INSERT INTO tpartscodes(DBill_ID, DCode_ID) VALUES( " & devBillID & ", " & valFailureCode & ")"
            blnGeneric = tGeneric.OrderEntryUpdateDelete(genSQL)
            If blnGeneric = False Then
                MsgBox("Failure Code could not be inserted", MsgBoxStyle.OKOnly)
            End If

            'Insert RefDesNum
            genSQL = "INSERT INTO tbillcell(BCell_RefDSNum, DBill_ID) VALUES( '" & txtRefDesNum.Text & "', " & devBillID & ")"
            blnGeneric = tGeneric.OrderEntryUpdateDelete(genSQL)
            If blnGeneric = False Then
                MsgBox("Ref Des Num could not be inserted", MsgBoxStyle.OKOnly)
            End If

            HotKeysF12()
            cboPartNum.Text = ""
            cboBillCode.Text = ""
            Me.cboRefDes.Text = ""
            txtRefDesNum.Text = ""
            Me.cboFailCode.Text = ""
            Me.txtRefDesNum.Text = ""
            populateParts()
            'Update tdevice date bill
            'Dim dtUpDev As New PSS.Data.Production.tdevice()
            'Dim blnUpd As Boolean = dtUpDev.UpdateBillDateByDevice(vDeviceID, PSS.Gui.Receiving.General.FormatDate(Now))

        End Sub

        Private Sub populateParts()

            'TEST CDH
            Try
                datagrid.Clear()
            Catch ex As Exception
            End Try
            Dim dtP As New PSS.Data.Production.Joins()
            Dim dtParts As DataTable = dtP.GenericSelect("select lbillcodes.billcode_desc, tdevicebill.* from (tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id) WHERE tdevicebill.device_id=" & tmpDeviceID & " ORDER BY BillCode_Desc")
            Dim dtParts2 As DataTable = dtP.GenericSelect("SELECT tpartscodes.*,lbillcodes.billcode_desc, lbillcodes.billcode_id, lcodesmaster.Mcode_Desc, lcodesdetail.DCode_Ldesc FROM ((((tdevicebill INNER JOIN tpartscodes ON tdevicebill.DBill_ID = tpartscodes.DBill_ID) INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id) LEFT OUTER JOIN lcodesdetail ON tpartscodes.DCode_ID = lcodesdetail.DCode_ID) LEFT OUTER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID) WHERE tdevicebill.device_id= " & tmpDeviceID & " ORDER BY BillCode_Desc")
            Dim dtParts3 As DataTable = dtP.GenericSelect("SELECT tbillcell.* FROM (tdevicebill INNER JOIN tbillcell ON tdevicebill.DBill_ID = tbillcell.DBill_ID) WHERE tdevicebill.device_id= " & tmpDeviceID)

            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim dr1 As DataRow

            Dim OPTxCount As Integer = 0
            Dim OPTr As DataRow

            Dim OPT2xCount As Integer = 0
            Dim OPT2r As DataRow

            Dim txtRefDes As String = ""
            Dim txtFailure As String = ""
            Dim txtRefDesNum As String = ""

            'For xCount = 0 To dtParts.Rows.Count - 1
            'r = dtParts.Rows(xCount)
            'Next

            For xCount = 0 To dtParts.Rows.Count - 1
                r = dtParts.Rows(xCount)

                For OPTxCount = 0 To dtParts2.Rows.Count - 1
                    OPTr = dtParts2.Rows(OPTxCount)
                    If OPTr("billcode_desc") = r("billcode_desc") And IsDBNull(OPTr("Mcode_Desc")) = False And r("DBill_ID") = OPTr("DBill_ID") Then
                        If OPTr("Mcode_Desc") = "Reference Designator" Then txtRefDes = OPTr("Dcode_Ldesc")
                        If OPTr("Mcode_Desc") = "Failure" Then txtFailure = OPTr("Dcode_Ldesc")
                    End If
                Next

                For OPT2xCount = 0 To dtParts3.Rows.Count - 1
                    OPT2r = dtParts3.Rows(OPT2xCount)
                    If OPT2r("DBill_ID") = r("DBill_ID") Then
                        txtRefDesNum = OPT2r("BCell_RefDSNUM")
                    End If
                Next

                dr1 = datagrid.NewRow()
                dr1("Bill Code ID") = r("billcode_ID")
                dr1("Bill Code") = r("billcode_desc")
                dr1("Ref Des") = txtRefDes
                dr1("Ref Des Num") = txtRefDesNum
                dr1("Fail Code") = txtFailure
                datagrid.Rows.Add(dr1)
                'Exit For
                txtRefDes = ""
                txtFailure = ""
                txtRefDesNum = ""
            Next

        End Sub


        Private Sub btnDeleteComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteComponent.Click

            'Get Part Data Information

            Dim tDBillID As New PSS.Data.Production.tdevicebill()
            Dim dtBillID As DataTable = tDBillID.GetDataTableByDeviceBillCode(tmpDeviceID, valBillCode)

            If valBillCode > 0 Then
                _device.DeletePart(valBillCode)
                cboBillCode.Text = ""
                'HotKeysF12()
                populateParts()
            Else
                MsgBox("can not delete device")
                Exit Sub
            End If

            Try
                'dtBillID.Dispose()
                'dtBillID = Nothing
            Catch ex As Exception
            End Try

            'Get tdevicebillID value and add records to tpartcodes
            'MsgBox("tmpdeviceID=" & tmpDeviceID)
            'MsgBox("valBillCode=" & valBillCode)


            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim devBillID As Int32 = 0

            For xCount = 0 To dtBillID.Rows.Count - 1
                r = dtBillID.Rows(xCount)
                devBillID = r("DBill_ID")
                Exit For
            Next

            'Remove records from tpartscodes
            If devBillID > 0 Then
                Dim tGeneric As New PSS.Data.Production.Joins()
                Dim genSQL As String = "DELETE FROM tpartscodes WHERE DBill_ID= " & devBillID
                Dim blnGeneric As Boolean = tGeneric.OrderEntryUpdateDelete(genSQL)
                If blnGeneric = False Then
                    MsgBox("Ref Des and Fail Code could not be removed.", MsgBoxStyle.OKOnly)
                Else
                    'MsgBox("tpartscodes:good")
                End If
            Else
                'MsgBox("No BillID")
            End If

            'Remove records from tbillcell
            If devBillID > 0 Then
                Dim tGeneric As New PSS.Data.Production.Joins()
                Dim genSQL As String = "DELETE FROM tbillcell WHERE DBill_ID= " & devBillID
                Dim blnGeneric As Boolean = tGeneric.OrderEntryUpdateDelete(genSQL)
                If blnGeneric = False Then
                    MsgBox("Ref Des Num could not be removed.", MsgBoxStyle.OKOnly)
                Else
                    'MsgBox("tpartscodes:good")
                End If
            Else
                'MsgBox("No BillID")
            End If

            Try
                cboPartNum.Text = ""
                cboBillCode.Text = ""
                cboRefDes.Text = ""
                txtRefDesNum.Text = ""
                cboFailCode.Text = ""
            Catch ex As Exception
            End Try


        End Sub

        Private Sub gridComponents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridComponents.Click

        End Sub

        Private Sub gridComponents_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridComponents.MouseUp

            valBillCode = gridComponents.Columns(0).Value
            Me.btnDeleteComponent.Visible = True
            Me.btnAddComponent.Visible = False
            Me.TabControl1.SelectedIndex = 2

            cboBillCode.Text = gridComponents.Columns(1).Value
            If Trim(cboBillCode.Text) = "" Then cboRefDes.Text = gridComponents.Columns(3).Value

            Try
                txtRefDesNum.Text = gridComponents.Columns(4).Value
            Catch ex As Exception
            End Try
            Try
                cboFailCode.Text = gridComponents.Columns(5).Value
            Catch ex As Exception
            End Try

        End Sub

        Private Sub clboxProblem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clboxProblem.SelectedIndexChanged

        End Sub

        Private Sub cboRefDes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub cboFailCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

            clearData()

            Try
                datagrid.Clear()
            Catch ex As Exception
            End Try

            txtTray.Text = ""
            cboDeviceSN.Text = ""
            txtTray.Focus()

        End Sub


        Private Sub txtTray_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTray.KeyDown

            If e.KeyValue = 13 Then
                '//Populate Serial Numbers
                Try
                    cboDeviceSN.Items.Clear()
                Catch
                End Try

                Dim tmpSN As New PSS.Data.Production.tdevice()
                Dim dtSN As DataTable = tmpSN.GetDataTableByTray(txtTray.Text)
                Dim xCount As Integer = 0
                Dim r As DataRow
                For xCount = 0 To dtSN.Rows.Count - 1
                    r = dtSN.Rows(xCount)
                    Me.cboDeviceSN.Items.Add(r("Device_SN"))
                Next
                Me.cboDeviceSN.Focus()
            End If

        End Sub

        Private Sub cboDeviceSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDeviceSN.KeyDown

            If e.KeyValue = 13 Then
                Me.Button1.Focus()
            End If

        End Sub

        Private Sub cboRepairStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub txtSoftwareVerIN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoftwareVerIN.TextChanged


        End Sub

        Private Sub txtSoftwareVerIN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoftwareVerIN.Leave

            If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then
                If Len(Trim(txtSoftwareVerIN.Text)) > 0 Then
                    txtSoftwareVerOUT.Text = txtSoftwareVerIN.Text
                End If
            End If

        End Sub

        Private Sub btnRcomplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRcomplete.Click

            Try
                clboxRepair.Items.Clear()
            Catch ex As Exception
            End Try

            'populateCode(9, clboxProblem)
            populateCode(3, clboxRepair)

        End Sub

        Private Sub btnPFcomplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPFcomplete.Click

            Try
                clboxProblem.Items.Clear()
            Catch ex As Exception
            End Try

            populateCode(9, clboxProblem)
            'populateCode(3, clboxRepair)

        End Sub


        Private Sub cboBillCode_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillCode.SelectedValueChanged

            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim tmpBillCode As Int32

            cboRefDes.Text = ""
            cboFailCode.Text = ""

            chgBillCode = True

            'Part Number
            For xCount = 0 To dtBillCode.Rows.Count - 1
                r = dtBillCode.Rows(xCount)
                If Trim(r("BillCode_Desc")) = Trim(cboBillCode.Text) Then
                    cboPartNum.Text = Trim(r("PSPrice_Number"))
                    Exit For
                End If
            Next

            'BillCode
            For xCount = 0 To dtBillCode.Rows.Count - 1
                r = dtBillCode.Rows(xCount)
                If r("BillCode_Desc") = Me.cboBillCode.Text Then
                    tmpBillCode = r("BillCode_ID")
                    Exit For
                End If
            Next

            If tmpBillCode = 256 Then
            ElseIf tmpBillCode = 331 Then
                cboRefDes.Text = "Housing Rear"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 201 Then
                'cboRefDes.Text = "Keypad Main"         'Commented by Asif on 04/21/2004
                cboRefDes.Text = "Keypad_Main"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 137 Then
                cboRefDes.Text = "Connector"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 171 Then
                cboRefDes.Text = "Connector"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 116 Then
                cboRefDes.Text = "Connector"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 219 Then
                cboRefDes.Text = "Microphone"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 120 Then
                cboRefDes.Text = "Speaker"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 207 Then
                cboRefDes.Text = "Display"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 278 Then
                cboRefDes.Text = ""
                cboFailCode.Text = ""
            ElseIf tmpBillCode = 259 Then
                cboRefDes.Text = ""
                cboFailCode.Text = ""
            ElseIf tmpBillCode = 188 Then
                cboRefDes.Text = "Housing Front"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 314 Then
                cboRefDes.Text = "Antenna"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 251 Then
                cboRefDes.Text = "Vibrator"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 311 Then
                cboRefDes.Text = "Keypad Mylar"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 233 Then
                cboRefDes.Text = "Alert"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 224 Then
                cboRefDes.Text = "Switch"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 292 Then
                cboRefDes.Text = "Pad"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 325 Then
                cboRefDes.Text = "Label"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 327 Then
                cboRefDes.Text = "Component Capacitor"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 329 Then
                'cboRefDes.Text = "Lens Main"       'Commented by Asif on 04/21/2004
                cboRefDes.Text = "Lens_Main"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 147 Then
                If tmpModelID = 733 Or tmpModelID = 565 Then
                    cboRefDes.Text = "Housing Rear"
                    cboFailCode.Text = "Failure"
                End If
            End If

        End Sub

        Private Sub cboPartNum_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPartNum.SelectedValueChanged

            Dim xCount As Integer
            Dim r As DataRow

            For xCount = 0 To dtBillCode.Rows.Count - 1
                r = dtBillCode.Rows(xCount)
                If Trim(r("PSPrice_Number")) = Trim(cboPartNum.Text) Then
                    If chgBillCode = False Then
                        cboBillCode.Text = Trim(r("BillCode_Desc"))
                        Exit For
                    End If
                End If
            Next

            chgBillCode = False

        End Sub

#Region "KeyPress Enter Movements"

        Private Sub txtOutgoingMSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoingMSN.KeyDown
            If e.KeyValue = 13 Then
                Me.txtOutgoingIMEI.Focus()
            End If
        End Sub

        Private Sub txtOutgoingIMEI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoingIMEI.KeyDown
            If e.KeyValue = 13 Then
                Me.txtOutgoingESNCSN.Focus()
            End If
        End Sub

        Private Sub txtOutgoingESNCSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoingESNCSN.KeyDown
            If e.KeyValue = 13 Then
                Me.txtMINnumber.Focus()
            End If
        End Sub

        Private Sub txtMINnumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMINnumber.KeyDown
            If e.KeyValue = 13 Then
                Me.txtSoftwareVerIN.Focus()
            End If
        End Sub

        Private Sub txtSoftwareVerIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoftwareVerIN.KeyDown
            If e.KeyValue = 13 Then
                Me.txtSoftwareVerOUT.Focus()
            End If
        End Sub

        Private Sub txtSoftwareVerOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoftwareVerOUT.KeyDown
            If e.KeyValue = 13 Then
                Me.cboTechID.Focus()
            End If
        End Sub

        Private Sub cboTechID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTechID.KeyDown
            If e.KeyValue = 13 Then
                Me.txtAirtime.Focus()
            End If
        End Sub

        Private Sub txtAirtime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAirtime.KeyDown
            If e.KeyValue = 13 Then
                Me.cboRepairStatus.Focus()
            End If
        End Sub

        Private Sub cboRepairStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRepairStatus.KeyDown
            If e.KeyValue = 13 Then
                Me.cboRepairDate.Focus()
            End If
        End Sub

        Private Sub cboRepairDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRepairDate.KeyDown
            If e.KeyValue = 13 Then
                Me.txtRepairTime.Focus()
            End If
        End Sub

        Private Sub txtRepairTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRepairTime.KeyDown
            If e.KeyValue = 13 Then
                Me.txtRepairCycleTime.Focus()
            End If
        End Sub



#End Region

        Private Sub txtRepairCycleTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRepairCycleTime.KeyDown
            If e.KeyValue = 13 Then
                clboxProblem.Focus()
            End If
        End Sub

        Private Sub clboxProblem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles clboxProblem.KeyDown
            If e.KeyValue = 13 Then
                Me.clboxRepair.Focus()
            End If
        End Sub

        Private Sub clboxRepair_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles clboxRepair.KeyDown
            If e.KeyValue = 13 Then
                Me.cboPartNum.Focus()
            End If
        End Sub

        Private Sub cboPartNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPartNum.KeyDown
            If e.KeyValue = 13 Then

            End If
        End Sub

        Private Sub cboBillCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillCode.SelectedIndexChanged

        End Sub

        Private Sub btnPFdefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPFdefault.Click

            Try
                clboxProblem.Items.Clear()
            Catch ex As Exception
            End Try

            populateCodeSMALL(9, clboxProblem)
            'populateCode(3, clboxRepair)

        End Sub

        Private Sub btnRdefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRdefault.Click

            Try
                clboxRepair.Items.Clear()
            Catch ex As Exception
            End Try

            populateCodeSMALL(3, clboxRepair)

        End Sub




        Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

            Dim strMessage As String
            strMessage = PSS.Gui.Receiving.verEntry_SLI(tmpDeviceID)
            MsgBox(strMessage)

        End Sub

        Private Sub cboPartNum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNum.SelectedIndexChanged

        End Sub
    End Class

End Namespace
