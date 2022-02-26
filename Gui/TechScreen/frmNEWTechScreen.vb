Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]

Namespace Gui.techscreen


Public Class frmNEWTechScreen
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
    Friend WithEvents grpMotorola As System.Windows.Forms.GroupBox
    Friend WithEvents cboRepairStatus As PSS.Gui.Controls.ComboBox
    Friend WithEvents txtAirtime As System.Windows.Forms.TextBox
    Friend WithEvents txtSoftwareVerOUT As System.Windows.Forms.TextBox
    Friend WithEvents txtSoftwareVerIN As System.Windows.Forms.TextBox
    Friend WithEvents cboRepairDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRepairCycleTime As System.Windows.Forms.TextBox
    Friend WithEvents txtRepairTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMINnumber As System.Windows.Forms.TextBox
    Friend WithEvents txtOutgoingESNCSN As System.Windows.Forms.TextBox
    Friend WithEvents txtOutgoingIMEI As System.Windows.Forms.TextBox
    Friend WithEvents txtOutgoingMSN As System.Windows.Forms.TextBox
    Friend WithEvents lblAirtime As System.Windows.Forms.Label
    Friend WithEvents lblSoftwareVerOUT As System.Windows.Forms.Label
    Friend WithEvents lblRepairStatus As System.Windows.Forms.Label
    Friend WithEvents lblOutgoingMSN As System.Windows.Forms.Label
    Friend WithEvents lblSoftwareVerIN As System.Windows.Forms.Label
    Friend WithEvents lblOutgoingESNCSN As System.Windows.Forms.Label
    Friend WithEvents lblOutgoingIMEI As System.Windows.Forms.Label
    Friend WithEvents lblTechID As System.Windows.Forms.Label
    Friend WithEvents lblRepairTime As System.Windows.Forms.Label
    Friend WithEvents lblMINnumber As System.Windows.Forms.Label
    Friend WithEvents lblRepairCycleTime As System.Windows.Forms.Label
    Friend WithEvents lblRepairDate As System.Windows.Forms.Label
    Friend WithEvents txtTray As System.Windows.Forms.TextBox
    Friend WithEvents lblTray As System.Windows.Forms.Label
    Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents cboTechID As PSS.Gui.Controls.ComboBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lstChecked As System.Windows.Forms.ListBox
        Friend WithEvents lblTechName As System.Windows.Forms.Label
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tbProblem As System.Windows.Forms.TabPage
        Friend WithEvents btnPFdefault As System.Windows.Forms.Button
        Friend WithEvents clboxProblem As System.Windows.Forms.CheckedListBox
        Friend WithEvents btnPFcomplete As System.Windows.Forms.Button
        Friend WithEvents tbRepair As System.Windows.Forms.TabPage
        Friend WithEvents btnRdefault As System.Windows.Forms.Button
        Friend WithEvents btnRcomplete As System.Windows.Forms.Button
        Friend WithEvents clboxRepair As System.Windows.Forms.CheckedListBox
        Friend WithEvents tbPartsNotAvailable As System.Windows.Forms.TabPage
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboServiceCode As PSS.Gui.Controls.ComboBox
        Friend WithEvents gridComponents As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboPartNum As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboFailCode As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboRefDes As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboBillCode As PSS.Gui.Controls.ComboBox
        Friend WithEvents btnDeleteComponent As System.Windows.Forms.Button
        Friend WithEvents btnAddComponent As System.Windows.Forms.Button
        Friend WithEvents txtRefDesNum As System.Windows.Forms.TextBox
        Friend WithEvents lblFailCode As System.Windows.Forms.Label
        Friend WithEvents lblRefDesNum As System.Windows.Forms.Label
        Friend WithEvents lblRefDes As System.Windows.Forms.Label
        Friend WithEvents lblAir As System.Windows.Forms.Label
        Friend WithEvents cbVoidManufWrty As System.Windows.Forms.CheckBox
        Friend WithEvents lblTroubleFound As System.Windows.Forms.Label
        Friend WithEvents cboTroubleFound As PSS.Gui.Controls.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNEWTechScreen))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.grpMotorola = New System.Windows.Forms.GroupBox()
            Me.cboTroubleFound = New PSS.Gui.Controls.ComboBox()
            Me.lblTroubleFound = New System.Windows.Forms.Label()
            Me.lblAir = New System.Windows.Forms.Label()
            Me.lblTechName = New System.Windows.Forms.Label()
            Me.lstChecked = New System.Windows.Forms.ListBox()
            Me.cboTechID = New PSS.Gui.Controls.ComboBox()
            Me.cboRepairStatus = New PSS.Gui.Controls.ComboBox()
            Me.txtAirtime = New System.Windows.Forms.TextBox()
            Me.txtSoftwareVerOUT = New System.Windows.Forms.TextBox()
            Me.txtSoftwareVerIN = New System.Windows.Forms.TextBox()
            Me.cboRepairDate = New System.Windows.Forms.DateTimePicker()
            Me.txtMINnumber = New System.Windows.Forms.TextBox()
            Me.txtOutgoingESNCSN = New System.Windows.Forms.TextBox()
            Me.txtOutgoingIMEI = New System.Windows.Forms.TextBox()
            Me.txtOutgoingMSN = New System.Windows.Forms.TextBox()
            Me.lblAirtime = New System.Windows.Forms.Label()
            Me.lblSoftwareVerOUT = New System.Windows.Forms.Label()
            Me.lblRepairStatus = New System.Windows.Forms.Label()
            Me.lblOutgoingMSN = New System.Windows.Forms.Label()
            Me.lblSoftwareVerIN = New System.Windows.Forms.Label()
            Me.lblOutgoingESNCSN = New System.Windows.Forms.Label()
            Me.lblOutgoingIMEI = New System.Windows.Forms.Label()
            Me.lblTechID = New System.Windows.Forms.Label()
            Me.lblMINnumber = New System.Windows.Forms.Label()
            Me.lblRepairDate = New System.Windows.Forms.Label()
            Me.txtRepairCycleTime = New System.Windows.Forms.TextBox()
            Me.txtRepairTime = New System.Windows.Forms.TextBox()
            Me.lblRepairTime = New System.Windows.Forms.Label()
            Me.lblRepairCycleTime = New System.Windows.Forms.Label()
            Me.txtTray = New System.Windows.Forms.TextBox()
            Me.lblTray = New System.Windows.Forms.Label()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tbProblem = New System.Windows.Forms.TabPage()
            Me.btnPFcomplete = New System.Windows.Forms.Button()
            Me.btnPFdefault = New System.Windows.Forms.Button()
            Me.clboxProblem = New System.Windows.Forms.CheckedListBox()
            Me.tbRepair = New System.Windows.Forms.TabPage()
            Me.btnRdefault = New System.Windows.Forms.Button()
            Me.btnRcomplete = New System.Windows.Forms.Button()
            Me.clboxRepair = New System.Windows.Forms.CheckedListBox()
            Me.tbPartsNotAvailable = New System.Windows.Forms.TabPage()
            Me.cbVoidManufWrty = New System.Windows.Forms.CheckBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboServiceCode = New PSS.Gui.Controls.ComboBox()
            Me.gridComponents = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
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
            Me.grpMotorola.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.tbProblem.SuspendLayout()
            Me.tbRepair.SuspendLayout()
            Me.tbPartsNotAvailable.SuspendLayout()
            CType(Me.gridComponents, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnUpdate
            '
            Me.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdate.Location = New System.Drawing.Point(16, 408)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(184, 24)
            Me.btnUpdate.TabIndex = 15
            Me.btnUpdate.Text = "UPDATE"
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClear.Location = New System.Drawing.Point(208, 408)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(56, 24)
            Me.btnClear.TabIndex = 16
            Me.btnClear.Text = "CLEAR"
            '
            'grpMotorola
            '
            Me.grpMotorola.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.grpMotorola.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTroubleFound, Me.lblTroubleFound, Me.lblAir, Me.lblTechName, Me.lstChecked, Me.cboTechID, Me.cboRepairStatus, Me.txtAirtime, Me.txtSoftwareVerOUT, Me.txtSoftwareVerIN, Me.cboRepairDate, Me.txtMINnumber, Me.txtOutgoingESNCSN, Me.txtOutgoingIMEI, Me.txtOutgoingMSN, Me.lblAirtime, Me.lblSoftwareVerOUT, Me.lblRepairStatus, Me.lblOutgoingMSN, Me.lblSoftwareVerIN, Me.lblOutgoingESNCSN, Me.lblOutgoingIMEI, Me.lblTechID, Me.lblMINnumber, Me.lblRepairDate})
            Me.grpMotorola.Location = New System.Drawing.Point(16, 56)
            Me.grpMotorola.Name = "grpMotorola"
            Me.grpMotorola.Size = New System.Drawing.Size(248, 344)
            Me.grpMotorola.TabIndex = 3
            Me.grpMotorola.TabStop = False
            '
            'cboTroubleFound
            '
            Me.cboTroubleFound.AutoComplete = True
            Me.cboTroubleFound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTroubleFound.Location = New System.Drawing.Point(112, 208)
            Me.cboTroubleFound.Name = "cboTroubleFound"
            Me.cboTroubleFound.Size = New System.Drawing.Size(128, 21)
            Me.cboTroubleFound.TabIndex = 11
            '
            'lblTroubleFound
            '
            Me.lblTroubleFound.Location = New System.Drawing.Point(8, 208)
            Me.lblTroubleFound.Name = "lblTroubleFound"
            Me.lblTroubleFound.Size = New System.Drawing.Size(104, 16)
            Me.lblTroubleFound.TabIndex = 118
            Me.lblTroubleFound.Text = "Trouble Found:"
            Me.lblTroubleFound.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAir
            '
            Me.lblAir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAir.Location = New System.Drawing.Point(176, 184)
            Me.lblAir.Name = "lblAir"
            Me.lblAir.Size = New System.Drawing.Size(64, 16)
            Me.lblAir.TabIndex = 117
            Me.lblAir.Text = "(HH-MM-SS)"
            Me.lblAir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblTechName
            '
            Me.lblTechName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTechName.Location = New System.Drawing.Point(168, 162)
            Me.lblTechName.Name = "lblTechName"
            Me.lblTechName.Size = New System.Drawing.Size(72, 16)
            Me.lblTechName.TabIndex = 116
            '
            'lstChecked
            '
            Me.lstChecked.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.lstChecked.BackColor = System.Drawing.SystemColors.Menu
            Me.lstChecked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstChecked.Location = New System.Drawing.Point(16, 280)
            Me.lstChecked.Name = "lstChecked"
            Me.lstChecked.Size = New System.Drawing.Size(224, 54)
            Me.lstChecked.TabIndex = 115
            '
            'cboTechID
            '
            Me.cboTechID.AutoComplete = True
            Me.cboTechID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboTechID.Location = New System.Drawing.Point(112, 160)
            Me.cboTechID.Name = "cboTechID"
            Me.cboTechID.Size = New System.Drawing.Size(48, 21)
            Me.cboTechID.TabIndex = 9
            '
            'cboRepairStatus
            '
            Me.cboRepairStatus.Location = New System.Drawing.Point(56, 232)
            Me.cboRepairStatus.MaxDropDownItems = 15
            Me.cboRepairStatus.Name = "cboRepairStatus"
            Me.cboRepairStatus.Size = New System.Drawing.Size(184, 21)
            Me.cboRepairStatus.TabIndex = 12
            '
            'txtAirtime
            '
            Me.txtAirtime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAirtime.Location = New System.Drawing.Point(112, 184)
            Me.txtAirtime.Name = "txtAirtime"
            Me.txtAirtime.Size = New System.Drawing.Size(64, 20)
            Me.txtAirtime.TabIndex = 10
            Me.txtAirtime.Text = ""
            '
            'txtSoftwareVerOUT
            '
            Me.txtSoftwareVerOUT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSoftwareVerOUT.Location = New System.Drawing.Point(112, 136)
            Me.txtSoftwareVerOUT.Name = "txtSoftwareVerOUT"
            Me.txtSoftwareVerOUT.Size = New System.Drawing.Size(128, 20)
            Me.txtSoftwareVerOUT.TabIndex = 8
            Me.txtSoftwareVerOUT.Text = ""
            '
            'txtSoftwareVerIN
            '
            Me.txtSoftwareVerIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSoftwareVerIN.Location = New System.Drawing.Point(112, 112)
            Me.txtSoftwareVerIN.Name = "txtSoftwareVerIN"
            Me.txtSoftwareVerIN.Size = New System.Drawing.Size(128, 20)
            Me.txtSoftwareVerIN.TabIndex = 7
            Me.txtSoftwareVerIN.Text = ""
            '
            'cboRepairDate
            '
            Me.cboRepairDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.cboRepairDate.Location = New System.Drawing.Point(56, 256)
            Me.cboRepairDate.Name = "cboRepairDate"
            Me.cboRepairDate.Size = New System.Drawing.Size(184, 20)
            Me.cboRepairDate.TabIndex = 13
            '
            'txtMINnumber
            '
            Me.txtMINnumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMINnumber.Location = New System.Drawing.Point(112, 88)
            Me.txtMINnumber.Name = "txtMINnumber"
            Me.txtMINnumber.Size = New System.Drawing.Size(128, 20)
            Me.txtMINnumber.TabIndex = 6
            Me.txtMINnumber.Text = ""
            '
            'txtOutgoingESNCSN
            '
            Me.txtOutgoingESNCSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOutgoingESNCSN.Location = New System.Drawing.Point(112, 64)
            Me.txtOutgoingESNCSN.Name = "txtOutgoingESNCSN"
            Me.txtOutgoingESNCSN.Size = New System.Drawing.Size(128, 20)
            Me.txtOutgoingESNCSN.TabIndex = 5
            Me.txtOutgoingESNCSN.Text = ""
            '
            'txtOutgoingIMEI
            '
            Me.txtOutgoingIMEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOutgoingIMEI.Location = New System.Drawing.Point(112, 40)
            Me.txtOutgoingIMEI.Name = "txtOutgoingIMEI"
            Me.txtOutgoingIMEI.Size = New System.Drawing.Size(128, 20)
            Me.txtOutgoingIMEI.TabIndex = 4
            Me.txtOutgoingIMEI.Text = ""
            '
            'txtOutgoingMSN
            '
            Me.txtOutgoingMSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOutgoingMSN.Location = New System.Drawing.Point(112, 16)
            Me.txtOutgoingMSN.Name = "txtOutgoingMSN"
            Me.txtOutgoingMSN.Size = New System.Drawing.Size(128, 20)
            Me.txtOutgoingMSN.TabIndex = 3
            Me.txtOutgoingMSN.Text = ""
            '
            'lblAirtime
            '
            Me.lblAirtime.Location = New System.Drawing.Point(8, 184)
            Me.lblAirtime.Name = "lblAirtime"
            Me.lblAirtime.Size = New System.Drawing.Size(104, 16)
            Me.lblAirtime.TabIndex = 110
            Me.lblAirtime.Text = "Airtime:"
            Me.lblAirtime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSoftwareVerOUT
            '
            Me.lblSoftwareVerOUT.Location = New System.Drawing.Point(8, 136)
            Me.lblSoftwareVerOUT.Name = "lblSoftwareVerOUT"
            Me.lblSoftwareVerOUT.Size = New System.Drawing.Size(104, 16)
            Me.lblSoftwareVerOUT.TabIndex = 108
            Me.lblSoftwareVerOUT.Text = "Software Ver OUT:"
            Me.lblSoftwareVerOUT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRepairStatus
            '
            Me.lblRepairStatus.Location = New System.Drawing.Point(16, 232)
            Me.lblRepairStatus.Name = "lblRepairStatus"
            Me.lblRepairStatus.Size = New System.Drawing.Size(40, 16)
            Me.lblRepairStatus.TabIndex = 111
            Me.lblRepairStatus.Text = "Status:"
            Me.lblRepairStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblOutgoingMSN
            '
            Me.lblOutgoingMSN.Location = New System.Drawing.Point(8, 16)
            Me.lblOutgoingMSN.Name = "lblOutgoingMSN"
            Me.lblOutgoingMSN.Size = New System.Drawing.Size(104, 16)
            Me.lblOutgoingMSN.TabIndex = 103
            Me.lblOutgoingMSN.Text = "Outgoing MSN;"
            Me.lblOutgoingMSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSoftwareVerIN
            '
            Me.lblSoftwareVerIN.Location = New System.Drawing.Point(8, 112)
            Me.lblSoftwareVerIN.Name = "lblSoftwareVerIN"
            Me.lblSoftwareVerIN.Size = New System.Drawing.Size(104, 16)
            Me.lblSoftwareVerIN.TabIndex = 107
            Me.lblSoftwareVerIN.Text = "Software Ver IN:"
            Me.lblSoftwareVerIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOutgoingESNCSN
            '
            Me.lblOutgoingESNCSN.Location = New System.Drawing.Point(8, 64)
            Me.lblOutgoingESNCSN.Name = "lblOutgoingESNCSN"
            Me.lblOutgoingESNCSN.Size = New System.Drawing.Size(104, 16)
            Me.lblOutgoingESNCSN.TabIndex = 105
            Me.lblOutgoingESNCSN.Text = "Outgoing E/CSN:"
            Me.lblOutgoingESNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOutgoingIMEI
            '
            Me.lblOutgoingIMEI.Location = New System.Drawing.Point(8, 40)
            Me.lblOutgoingIMEI.Name = "lblOutgoingIMEI"
            Me.lblOutgoingIMEI.Size = New System.Drawing.Size(104, 16)
            Me.lblOutgoingIMEI.TabIndex = 104
            Me.lblOutgoingIMEI.Text = "Outgoing IMEI:"
            Me.lblOutgoingIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTechID
            '
            Me.lblTechID.Location = New System.Drawing.Point(8, 160)
            Me.lblTechID.Name = "lblTechID"
            Me.lblTechID.Size = New System.Drawing.Size(104, 16)
            Me.lblTechID.TabIndex = 109
            Me.lblTechID.Text = "Technician ID:"
            Me.lblTechID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMINnumber
            '
            Me.lblMINnumber.Location = New System.Drawing.Point(8, 88)
            Me.lblMINnumber.Name = "lblMINnumber"
            Me.lblMINnumber.Size = New System.Drawing.Size(104, 16)
            Me.lblMINnumber.TabIndex = 106
            Me.lblMINnumber.Text = "MIN Number:"
            Me.lblMINnumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRepairDate
            '
            Me.lblRepairDate.Location = New System.Drawing.Point(16, 256)
            Me.lblRepairDate.Name = "lblRepairDate"
            Me.lblRepairDate.Size = New System.Drawing.Size(32, 16)
            Me.lblRepairDate.TabIndex = 112
            Me.lblRepairDate.Text = "Date:"
            Me.lblRepairDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtRepairCycleTime
            '
            Me.txtRepairCycleTime.Location = New System.Drawing.Point(48, 32)
            Me.txtRepairCycleTime.Name = "txtRepairCycleTime"
            Me.txtRepairCycleTime.Size = New System.Drawing.Size(8, 20)
            Me.txtRepairCycleTime.TabIndex = 14
            Me.txtRepairCycleTime.Text = ""
            Me.txtRepairCycleTime.Visible = False
            '
            'txtRepairTime
            '
            Me.txtRepairTime.Location = New System.Drawing.Point(40, 32)
            Me.txtRepairTime.Name = "txtRepairTime"
            Me.txtRepairTime.Size = New System.Drawing.Size(8, 20)
            Me.txtRepairTime.TabIndex = 13
            Me.txtRepairTime.Text = ""
            Me.txtRepairTime.Visible = False
            '
            'lblRepairTime
            '
            Me.lblRepairTime.Location = New System.Drawing.Point(0, 24)
            Me.lblRepairTime.Name = "lblRepairTime"
            Me.lblRepairTime.Size = New System.Drawing.Size(8, 16)
            Me.lblRepairTime.TabIndex = 113
            Me.lblRepairTime.Text = "Repair Time:"
            Me.lblRepairTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblRepairTime.Visible = False
            '
            'lblRepairCycleTime
            '
            Me.lblRepairCycleTime.Location = New System.Drawing.Point(24, 24)
            Me.lblRepairCycleTime.Name = "lblRepairCycleTime"
            Me.lblRepairCycleTime.Size = New System.Drawing.Size(8, 16)
            Me.lblRepairCycleTime.TabIndex = 114
            Me.lblRepairCycleTime.Text = "Repair Cycle Time:"
            Me.lblRepairCycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblRepairCycleTime.Visible = False
            '
            'txtTray
            '
            Me.txtTray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTray.Location = New System.Drawing.Point(120, 32)
            Me.txtTray.Name = "txtTray"
            Me.txtTray.Size = New System.Drawing.Size(136, 20)
            Me.txtTray.TabIndex = 2
            Me.txtTray.Text = ""
            Me.txtTray.Visible = False
            '
            'lblTray
            '
            Me.lblTray.Location = New System.Drawing.Point(56, 32)
            Me.lblTray.Name = "lblTray"
            Me.lblTray.Size = New System.Drawing.Size(64, 16)
            Me.lblTray.TabIndex = 101
            Me.lblTray.Text = "Tray:"
            Me.lblTray.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblTray.Visible = False
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblDeviceSN.Location = New System.Drawing.Point(24, 8)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(96, 16)
            Me.lblDeviceSN.TabIndex = 100
            Me.lblDeviceSN.Text = "Serial Number:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Button1
            '
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(16, 23)
            Me.Button1.TabIndex = 34
            Me.Button1.Text = "Get Data"
            Me.Button1.Visible = False
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerial.Location = New System.Drawing.Point(120, 8)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(136, 20)
            Me.txtSerial.TabIndex = 1
            Me.txtSerial.Text = ""
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbProblem, Me.tbRepair, Me.tbPartsNotAvailable})
            Me.TabControl1.ItemSize = New System.Drawing.Size(83, 18)
            Me.TabControl1.Location = New System.Drawing.Point(280, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(496, 424)
            Me.TabControl1.TabIndex = 118
            '
            'tbProblem
            '
            Me.tbProblem.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPFcomplete, Me.btnPFdefault, Me.clboxProblem})
            Me.tbProblem.Location = New System.Drawing.Point(4, 22)
            Me.tbProblem.Name = "tbProblem"
            Me.tbProblem.Size = New System.Drawing.Size(488, 398)
            Me.tbProblem.TabIndex = 0
            Me.tbProblem.Text = "Problem Found"
            '
            'btnPFcomplete
            '
            Me.btnPFcomplete.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnPFcomplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPFcomplete.Location = New System.Drawing.Point(408, 8)
            Me.btnPFcomplete.Name = "btnPFcomplete"
            Me.btnPFcomplete.Size = New System.Drawing.Size(75, 24)
            Me.btnPFcomplete.TabIndex = 119
            Me.btnPFcomplete.Text = "Complete"
            '
            'btnPFdefault
            '
            Me.btnPFdefault.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnPFdefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPFdefault.Location = New System.Drawing.Point(328, 8)
            Me.btnPFdefault.Name = "btnPFdefault"
            Me.btnPFdefault.Size = New System.Drawing.Size(75, 24)
            Me.btnPFdefault.TabIndex = 122
            Me.btnPFdefault.TabStop = False
            Me.btnPFdefault.Text = "Default"
            '
            'clboxProblem
            '
            Me.clboxProblem.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.clboxProblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.clboxProblem.Location = New System.Drawing.Point(8, 40)
            Me.clboxProblem.Name = "clboxProblem"
            Me.clboxProblem.Size = New System.Drawing.Size(472, 347)
            Me.clboxProblem.TabIndex = 16
            '
            'tbRepair
            '
            Me.tbRepair.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRdefault, Me.btnRcomplete, Me.clboxRepair})
            Me.tbRepair.Location = New System.Drawing.Point(4, 22)
            Me.tbRepair.Name = "tbRepair"
            Me.tbRepair.Size = New System.Drawing.Size(488, 398)
            Me.tbRepair.TabIndex = 1
            Me.tbRepair.Text = "Repair Action"
            Me.tbRepair.Visible = False
            '
            'btnRdefault
            '
            Me.btnRdefault.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRdefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRdefault.Location = New System.Drawing.Point(328, 8)
            Me.btnRdefault.Name = "btnRdefault"
            Me.btnRdefault.Size = New System.Drawing.Size(75, 24)
            Me.btnRdefault.TabIndex = 120
            Me.btnRdefault.TabStop = False
            Me.btnRdefault.Text = "Default"
            '
            'btnRcomplete
            '
            Me.btnRcomplete.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRcomplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRcomplete.Location = New System.Drawing.Point(408, 8)
            Me.btnRcomplete.Name = "btnRcomplete"
            Me.btnRcomplete.Size = New System.Drawing.Size(75, 24)
            Me.btnRcomplete.TabIndex = 121
            Me.btnRcomplete.Text = "Complete"
            '
            'clboxRepair
            '
            Me.clboxRepair.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.clboxRepair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.clboxRepair.Location = New System.Drawing.Point(8, 40)
            Me.clboxRepair.Name = "clboxRepair"
            Me.clboxRepair.Size = New System.Drawing.Size(472, 347)
            Me.clboxRepair.TabIndex = 17
            '
            'tbPartsNotAvailable
            '
            Me.tbPartsNotAvailable.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbVoidManufWrty, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.cboServiceCode, Me.gridComponents, Me.cboPartNum, Me.Label1, Me.cboFailCode, Me.cboRefDes, Me.cboBillCode, Me.btnDeleteComponent, Me.btnAddComponent, Me.txtRefDesNum, Me.lblFailCode, Me.lblRefDesNum, Me.lblRefDes})
            Me.tbPartsNotAvailable.Location = New System.Drawing.Point(4, 22)
            Me.tbPartsNotAvailable.Name = "tbPartsNotAvailable"
            Me.tbPartsNotAvailable.Size = New System.Drawing.Size(488, 398)
            Me.tbPartsNotAvailable.TabIndex = 2
            Me.tbPartsNotAvailable.Text = "Parts"
            Me.tbPartsNotAvailable.Visible = False
            '
            'cbVoidManufWrty
            '
            Me.cbVoidManufWrty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbVoidManufWrty.Location = New System.Drawing.Point(80, 152)
            Me.cbVoidManufWrty.Name = "cbVoidManufWrty"
            Me.cbVoidManufWrty.Size = New System.Drawing.Size(176, 24)
            Me.cbVoidManufWrty.TabIndex = 7
            Me.cbVoidManufWrty.Text = "Void Manufacturer Warranty"
            '
            'Label5
            '
            Me.Label5.ForeColor = System.Drawing.Color.Blue
            Me.Label5.Location = New System.Drawing.Point(304, 56)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(56, 16)
            Me.Label5.TabIndex = 43
            Me.Label5.Text = "(bill code)"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.ForeColor = System.Drawing.Color.Blue
            Me.Label4.Location = New System.Drawing.Point(304, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(56, 16)
            Me.Label4.TabIndex = 42
            Me.Label4.Text = "(bill code)"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.ForeColor = System.Drawing.Color.Blue
            Me.Label3.Location = New System.Drawing.Point(32, 32)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 16)
            Me.Label3.TabIndex = 41
            Me.Label3.Text = "PART:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.ForeColor = System.Drawing.Color.Blue
            Me.Label2.Location = New System.Drawing.Point(8, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 16)
            Me.Label2.TabIndex = 40
            Me.Label2.Text = "SERVICE:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboServiceCode
            '
            Me.cboServiceCode.AutoComplete = True
            Me.cboServiceCode.ItemHeight = 13
            Me.cboServiceCode.Location = New System.Drawing.Point(80, 56)
            Me.cboServiceCode.MaxDropDownItems = 30
            Me.cboServiceCode.Name = "cboServiceCode"
            Me.cboServiceCode.Size = New System.Drawing.Size(224, 21)
            Me.cboServiceCode.TabIndex = 3
            '
            'gridComponents
            '
            Me.gridComponents.AllowAddNew = True
            Me.gridComponents.AllowFilter = True
            Me.gridComponents.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.gridComponents.AllowSort = True
            Me.gridComponents.AlternatingRows = True
            Me.gridComponents.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gridComponents.CaptionHeight = 17
            Me.gridComponents.CollapseColor = System.Drawing.Color.Black
            Me.gridComponents.DataChanged = False
            Me.gridComponents.BackColor = System.Drawing.Color.Empty
            Me.gridComponents.ExpandColor = System.Drawing.Color.Black
            Me.gridComponents.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
            Me.gridComponents.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridComponents.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.gridComponents.Location = New System.Drawing.Point(8, 184)
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
            Me.gridComponents.Size = New System.Drawing.Size(472, 192)
            Me.gridComponents.TabIndex = 9
            Me.gridComponents.TabStop = False
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
            "ert:Center;Border:Flat,ControlDark,0, 1, 0, 1;ForeColor:ControlText;BackColor:Co" & _
            "ntrol;}FilterBar{}Style4{}Style9{}Style8{}Style36{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style30" & _
            "{AlignHorz:Near;}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Me" & _
            "rgeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeigh" & _
            "t=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWid" & _
            "th=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><C" & _
            "lientRect>0, 0, 468, 188</ClientRect><BorderSide>0</BorderSide><CaptionStyle par" & _
            "ent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowS" & _
            "tyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style" & _
            "13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""" & _
            "Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle paren" & _
            "t=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><O" & _
            "ddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSele" & _
            "ctor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style paren" & _
            "t=""Normal"" me=""Style1"" /><internalCols><C1DisplayColumn><HeadingStyle parent=""St" & _
            "yle2"" me=""Style14"" /><Style parent=""Style1"" me=""Style15"" /><FooterStyle parent=""" & _
            "Style3"" me=""Style16"" /><EditorStyle parent=""Style5"" me=""Style17"" /><Visible>True" & _
            "</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCId" & _
            "x>0</DCIdx></C1DisplayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""" & _
            "Style22"" /><Style parent=""Style1"" me=""Style23"" /><FooterStyle parent=""Style3"" me" & _
            "=""Style24"" /><EditorStyle parent=""Style5"" me=""Style25"" /><Visible>True</Visible>" & _
            "<ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>1</DCIdx" & _
            "></C1DisplayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style26"" /" & _
            "><Style parent=""Style1"" me=""Style27"" /><FooterStyle parent=""Style3"" me=""Style28""" & _
            " /><EditorStyle parent=""Style5"" me=""Style29"" /><Visible>True</Visible><ColumnDiv" & _
            "ider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>2</DCIdx></C1Displ" & _
            "ayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style30"" /><Style pa" & _
            "rent=""Style1"" me=""Style31"" /><FooterStyle parent=""Style3"" me=""Style32"" /><Editor" & _
            "Style parent=""Style5"" me=""Style33"" /><Visible>True</Visible><ColumnDivider>DarkG" & _
            "ray,Single</ColumnDivider><Height>15</Height><DCIdx>3</DCIdx></C1DisplayColumn><" & _
            "C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style34"" /><Style parent=""Styl" & _
            "e1"" me=""Style35"" /><FooterStyle parent=""Style3"" me=""Style36"" /><EditorStyle pare" & _
            "nt=""Style5"" me=""Style37"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single" & _
            "</ColumnDivider><Height>15</Height><DCIdx>4</DCIdx></C1DisplayColumn></internalC" & _
            "ols></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""N" & _
            "ormal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foote" & _
            "r"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive" & _
            """ /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" />" & _
            "<Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /" & _
            "><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector" & _
            """ /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /" & _
            "></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modif" & _
            "ied</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 468, 18" & _
            "8</ClientArea></Blob>"
            '
            'cboPartNum
            '
            Me.cboPartNum.AutoComplete = True
            Me.cboPartNum.ItemHeight = 13
            Me.cboPartNum.Location = New System.Drawing.Point(80, 8)
            Me.cboPartNum.Name = "cboPartNum"
            Me.cboPartNum.Size = New System.Drawing.Size(168, 21)
            Me.cboPartNum.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(16, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(56, 16)
            Me.Label1.TabIndex = 16
            Me.Label1.Text = "Part#:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboFailCode
            '
            Me.cboFailCode.AutoComplete = True
            Me.cboFailCode.ItemHeight = 13
            Me.cboFailCode.Location = New System.Drawing.Point(80, 128)
            Me.cboFailCode.Name = "cboFailCode"
            Me.cboFailCode.Size = New System.Drawing.Size(232, 21)
            Me.cboFailCode.TabIndex = 6
            '
            'cboRefDes
            '
            Me.cboRefDes.AutoComplete = True
            Me.cboRefDes.ItemHeight = 13
            Me.cboRefDes.Location = New System.Drawing.Point(80, 80)
            Me.cboRefDes.MaxDropDownItems = 20
            Me.cboRefDes.Name = "cboRefDes"
            Me.cboRefDes.Size = New System.Drawing.Size(168, 21)
            Me.cboRefDes.TabIndex = 4
            '
            'cboBillCode
            '
            Me.cboBillCode.AutoComplete = True
            Me.cboBillCode.ItemHeight = 13
            Me.cboBillCode.Location = New System.Drawing.Point(80, 32)
            Me.cboBillCode.MaxDropDownItems = 30
            Me.cboBillCode.Name = "cboBillCode"
            Me.cboBillCode.Size = New System.Drawing.Size(224, 21)
            Me.cboBillCode.TabIndex = 2
            '
            'btnDeleteComponent
            '
            Me.btnDeleteComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDeleteComponent.Location = New System.Drawing.Point(416, 128)
            Me.btnDeleteComponent.Name = "btnDeleteComponent"
            Me.btnDeleteComponent.Size = New System.Drawing.Size(48, 24)
            Me.btnDeleteComponent.TabIndex = 9
            Me.btnDeleteComponent.Text = "Delete"
            '
            'btnAddComponent
            '
            Me.btnAddComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddComponent.Location = New System.Drawing.Point(360, 128)
            Me.btnAddComponent.Name = "btnAddComponent"
            Me.btnAddComponent.Size = New System.Drawing.Size(48, 24)
            Me.btnAddComponent.TabIndex = 8
            Me.btnAddComponent.Text = "Add"
            '
            'txtRefDesNum
            '
            Me.txtRefDesNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRefDesNum.Location = New System.Drawing.Point(80, 104)
            Me.txtRefDesNum.Name = "txtRefDesNum"
            Me.txtRefDesNum.Size = New System.Drawing.Size(72, 20)
            Me.txtRefDesNum.TabIndex = 5
            Me.txtRefDesNum.Text = ""
            '
            'lblFailCode
            '
            Me.lblFailCode.Location = New System.Drawing.Point(8, 128)
            Me.lblFailCode.Name = "lblFailCode"
            Me.lblFailCode.Size = New System.Drawing.Size(72, 16)
            Me.lblFailCode.TabIndex = 13
            Me.lblFailCode.Text = "Failure Code:"
            Me.lblFailCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRefDesNum
            '
            Me.lblRefDesNum.Location = New System.Drawing.Point(8, 104)
            Me.lblRefDesNum.Name = "lblRefDesNum"
            Me.lblRefDesNum.Size = New System.Drawing.Size(72, 16)
            Me.lblRefDesNum.TabIndex = 12
            Me.lblRefDesNum.Text = "Ref. Des. #:"
            Me.lblRefDesNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRefDes
            '
            Me.lblRefDes.Location = New System.Drawing.Point(8, 80)
            Me.lblRefDes.Name = "lblRefDes"
            Me.lblRefDes.Size = New System.Drawing.Size(72, 16)
            Me.lblRefDes.TabIndex = 14
            Me.lblRefDes.Text = "Ref Des:"
            Me.lblRefDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmNEWTechScreen
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(790, 445)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.txtSerial, Me.grpMotorola, Me.txtTray, Me.lblTray, Me.lblDeviceSN, Me.Button1, Me.btnUpdate, Me.btnClear, Me.txtRepairCycleTime, Me.lblRepairCycleTime, Me.txtRepairTime, Me.lblRepairTime})
            Me.Name = "frmNEWTechScreen"
            Me.Text = "frmNEWTechScreen"
            Me.grpMotorola.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.tbProblem.ResumeLayout(False)
            Me.tbRepair.ResumeLayout(False)
            Me.tbPartsNotAvailable.ResumeLayout(False)
            CType(Me.gridComponents, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

    Private valOldRepStat As String

    Private tstPriority, chgBillCode As Boolean

    Private mSerialNumber As Long
    Private valBillCode As Integer
        Private tmpDeviceID, tmpModelID, tmpManufID, tmpTrayID, tmpCustID, tmpWO As Int32
        Private vManufWrty As Integer = 0

        Private arrTechs(11, 1) As String
        Private dtTech As DataTable

        Public datagrid As DataTable
        Public valFailureCode As Integer
        Private dtBillCode, dtServiceCode, dtRefDes, dtFailureCode, dtRepairCode As DataTable

    Private _device As Device = Nothing
    Private _tray As DataTable = Nothing

        Private dtCustomerSet, dtRefDesDesc, dtFailureDesc, dtWarrantySet As DataTable


        Private Sub frmNEWTechScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            lblTroubleFound.Visible = False '//Hide the elements for the ATC project
            cboTroubleFound.Visible = False '//only make them visible if needed

            '//END

            txtSerial.Focus()

        End Sub

        Private Function getTrayID(ByVal mDeviceID As Long) As Long

            getTrayID = 0

            Try

                Dim dTray As New PSS.Data.Production.tdevice()
                Dim tTray As DataRow = dTray.GetRowByPK(mDeviceID)

                getTrayID = tTray("Tray_ID")

            Catch ex As Exception
                '//will return value of 0 so no coding necessary here
            End Try

        End Function

        Private Function verifySerialNumber(ByVal mDeviceSN As String) As Long

            Try

                If Len(Trim(mDeviceSN)) > 12 Then
                    Dim rIMEI As DataRow
                    Dim dtIMEI As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("select tdevice.device_id, tdevice.device_sn from tdevice inner join tcellopt on tdevice.device_id = tcellopt.device_id where tcellopt.cellopt_imei = '" & mDeviceSN & "'")
                    If dtIMEI.Rows.Count > 0 Then
                        rIMEI = dtIMEI.Rows(0)
                        txtSerial.Text = rIMEI("Device_SN")
                        Return rIMEI("Device_ID")
                    End If
                End If

                Dim dRec As New PSS.Data.Production.tdevice()
                Dim tRec As DataTable = dRec.GetDataTableBySN(mDeviceSN)
                Dim r As DataRow

                If tRec.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf tRec.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                Else
                    r = tRec.Rows(0)
                    Return r("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            End Try

        End Function

        Private Function verifySerialNumberTray(ByVal mDeviceSN As String, ByVal mTray As String) As Long

            Try
                Dim dRec As New PSS.Data.Production.tdevice()
                Dim tRec As DataTable = dRec.GetDataTableBySNTray(mDeviceSN, mTray)
                Dim r As DataRow

                If tRec.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf tRec.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                Else
                    r = tRec.Rows(0)
                    Return r("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            End Try

        End Function

        Private Sub txtSerial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown

            Dim blnGetData As Boolean

            mSerialNumber = 0

            If e.KeyValue = 13 Then
                txtSerial.Text = UCase(txtSerial.Text)  '//Format serial as all uppercase
                Dim val As Long = Me.verifySerialNumber(txtSerial.Text)
                If val = 0 Then
                    lblTray.Visible = False
                    txtTray.Visible = False
                    txtSerial.Text = ""
                    txtSerial.Focus()
                    Exit Sub
                ElseIf val = 2 Then
                    txtTray.Text = ""
                    lblTray.Visible = True
                    txtTray.Visible = True
                    txtTray.Focus()
                Else
                    mSerialNumber = val
                    txtTray.Text = getTrayID(mSerialNumber)
                    lblTray.Visible = True
                    txtTray.Visible = True

                    getDeviceType(mSerialNumber)

                    retreiveData()
                    'blnGetData = getDeviceData_tcellopt(mSerialNumber) '//Get tcellopt data for form
                    txtOutgoingMSN.Focus()
                    'If blnGetData = False Then
                    'MsgBox("The cellular phone data could not be acquired. Please verify the device serial number and tray.", MsgBoxStyle.OKOnly, "Device Not Found")
                    'lblTray.Visible = False
                    'txtTray.Visible = False
                    'txtSerial.Text = ""
                    'txtSerial.Focus()
                    'Exit Sub
                    'End If
                End If
            End If

        End Sub

        Private Function getDeviceData_tcellopt(ByVal vDeviceID As Long) As Boolean

            getDeviceData_tcellopt = False

            Try

                Dim dDev As New PSS.Data.Production.tcellopt()
                Dim tDev As DataRow = dDev.GetRowByDeviceID(vDeviceID)

                If IsDBNull(tDev("CellOpt_OutMSN")) = False Then                '//MSN
                    Me.txtOutgoingMSN.Text = tDev("CellOpt_OutMSN")
                ElseIf IsDBNull(tDev("CellOpt_MSN")) = False Then
                    Me.txtOutgoingMSN.Text = tDev("CellOpt_MSN")
                End If

                If IsDBNull(tDev("CellOpt_OutIMEI")) = False Then               '//IMEI
                    Me.txtOutgoingIMEI.Text = tDev("CellOpt_OutIMEI")
                ElseIf IsDBNull(tDev("CellOpt_IMEI")) = False Then
                    Me.txtOutgoingIMEI.Text = tDev("CellOpt_IMEI")
                End If

                If IsDBNull(tDev("CellOpt_OutCSN")) = False Then                '//CSN
                    Me.txtOutgoingESNCSN.Text = tDev("CellOpt_OutCSN")
                ElseIf IsDBNull(tDev("CellOpt_CSN")) = False Then
                    Me.txtOutgoingESNCSN.Text = tDev("CellOpt_CSN")
                End If

                If IsDBNull(tDev("CellOpt_SoftVerIN")) = False Then             '//SoftwareVersionIN
                    Me.txtSoftwareVerIN.Text = tDev("CellOpt_SoftVerIN")
                End If

                If IsDBNull(tDev("CellOpt_SoftVerOUT")) = False Then            '//SoftwareVersionOUT
                    Me.txtSoftwareVerOUT.Text = tDev("CellOpt_SoftVerOUT")
                End If

                If IsDBNull(tDev("CellOpt_TechID")) = False Then                '//TechID
                    Me.cboTechID.Text = tDev("CellOpt_TechID")
                End If

                If IsDBNull(tDev("CellOpt_MIN")) = False Then                   '//MIN
                    Me.txtMINnumber.Text = tDev("CellOpt_MIN")
                End If

                If IsDBNull(tDev("CellOpt_AirTime")) = False Then               '//AirTime
                    Me.txtAirtime.Text = tDev("CellOpt_AirTime")
                End If

                If IsDBNull(tDev("CellOpt_RepairStatus")) = False Then          '//RepairStatus
                    Me.cboRepairStatus.Text = tDev("CellOpt_RepairStatus")
                End If

                If IsDBNull(tDev("CellOpt_RepairDate")) = False Then            '//RepairDate
                    Me.cboRepairDate.Text = tDev("CellOpt_RepairDate")
                End If

                getDeviceData_tcellopt = True

            Catch ex As Exception
                '//will return value of false so no coding necessary here
            End Try

        End Function


        Private Sub getData(ByVal TrayNum As Int32, ByVal deviceSN As String)

            tmpDeviceID = 0
            tmpModelID = 0
            tmpTrayID = 0
            tmpManufID = 0
            tmpCustID = 0
            tmpWO = 0
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
                    tmpWO = r("WO_ID")


                    '//Craig Haney March 16, 2004
                    If r("Device_ManufWrty") = 1 Then
                        Me.cbVoidManufWrty.Visible = True
                        Me.cbVoidManufWrty.Enabled = True
                    Else
                        Me.cbVoidManufWrty.Visible = True
                        Me.cbVoidManufWrty.Enabled = False
                    End If
                    'If r("Device_ChgManufWrty") = 1 Then
                    'Me.cbVoidManufWrty.Checked = True
                    'Else
                    'Me.cbVoidManufWrty.Checked = False
                    'End If
                    '//Craig Haney March 16, 2004 - END

                    Exit For
                End If
            Next

            'Craig Haney
            Dim tmpCds As PSS.Data.Production.Joins
            Dim tmpCdr As DataRow = tmpCds.GetCustomerFromDeviceID(tmpDeviceID)
            tmpCustID = tmpCdr("Cust_ID")

            Dim tmpDS2 As PSS.Data.Production.Joins
            Dim vCV As Integer = 0
            Dim tmpCount As Integer = 0

            If tmpCdr("Cust_SpecialCodes") > 0 Then
                vCV = tmpCdr("Cust_SpecialCodes")
                lblTroubleFound.Visible = True
                cboTroubleFound.Visible = True
                Try
                    cboTroubleFound.Items.Clear()
                Catch ex As Exception
                End Try
                Dim tmpDT As DataTable = tmpDS2.GetSpecialCodeTF(vCV)
                Dim tmpR As DataRow

                cboTroubleFound.DataSource = tmpDT
                cboTroubleFound.DisplayMember = tmpDT.Columns("DCode_LDesc").ToString
                cboTroubleFound.ValueMember = tmpDT.Columns("Dcode_ID").ToString
                cboTroubleFound.SelectedIndex = -1
            Else
                lblTroubleFound.Visible = False
                cboTroubleFound.Visible = False
            End If

            'Craig Haney - END


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

            '//new code cdh 5-12-04 start
            If tmpCustID = 1403 Then
                Dim rWO As DataRow = PSS.Data.Production.tworkorder.GetRowByPK(tmpWO)
                If Trim(rWO("WO_CustWO")) = "RLCPSS050604AFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS050604BFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS050604CFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "2200.01.35"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "2200.01.35"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS050604DFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "2200.01.35"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "2200.01.35"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS051004AFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS051004BFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS051304AFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf UCase(Trim(rWO("WO_CustWO"))) = "120EVZWPSSI5.14.04" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf UCase(Trim(rWO("WO_CustWO"))) = "120EQWESTPSSI5.14.04" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "0"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "0"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf UCase(Trim(rWO("WO_CustWO"))) = "V60PNSCVZWPSSI5.14.04" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8600.02.0E.03"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8600.02.0E.03"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS051704AFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS051704BFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS051704CFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "2200.01.35"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "2200.01.35"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS051704DFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "2200.01.35"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "2200.01.35"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS051704EFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "2200.01.35"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "2200.01.35"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS051704FFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "2200.01.35"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "2200.01.35"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS052404AFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS052404BFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS060104AFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS060104BFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS060104CFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "C343NSCVZWPSSI5.14.04" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "C343_R2.7_X_1.2.05R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "C343_R2.7_X_1.2.05R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "120TNSCCINGPSSI5.14.04" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "4001.2E.06.00"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "4001.2E.06.00"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "C250NSCTMOPSSI5.14.04" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "R312LTS..G.09.10.82R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "R312LTS..G.09.10.82R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                ElseIf Trim(rWO("WO_CustWO")) = "RLCPSS060704BFRU" Then
                    If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8300.01.54.0R"
                    If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8300.01.54.0R"
                    If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
                End If
            End If
            '//new code cdh 5-12-04 END

            If tmpCustID = 1844 Then
                If Len(Trim(txtSoftwareVerIN.Text)) < 1 Then txtSoftwareVerIN.Text = "8600.02.0E.03"
                If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then txtSoftwareVerOUT.Text = "8600.02.0E.03"
                If Len(Trim(txtAirtime.Text)) < 1 Then txtAirtime.Text = "0"
            End If

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

            If IsDBNull(mtData("CellOpt_TechID")) = False Then
                cboTechID.Text = mtData("CellOpt_TechID")
            Else
                cboTechID.Text = "102"
            End If

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
                valOldRepStat = mtData("CellOpt_RepairStatus")
            Else
                valOldRepStat = ""
            End If

            'cboRepairDate
            If IsDBNull(mtData("CellOpt_RepairDate")) = False Then cboRepairDate.Text = mtData("CellOpt_RepairDate")

            'Craig Haney
            Dim tTF As New PSS.Data.Production.tdevicecodes()
            Dim dTF As DataTable = tTF.GetTroubleFound(tmpDeviceID)
            Dim rTF As DataRow
            Dim rCount As Integer = 0

            For rCount = 0 To dTF.Rows.Count - 1
                rTF = dTF.Rows(rCount)
                cboTroubleFound.SelectedValue = rTF("Dcode_ID")
            Next
            'Craig Haney - END

            'Craig D Haney September 24 2004 - START
            '//Clear old datatables
            Try
                dtCustomerSet.Clear()
            Catch ex As Exception
            End Try
            Try
                dtRefDesDesc.Clear()
            Catch ex As Exception
            End Try
            Try
                dtFailureDesc.Clear()
            Catch ex As Exception
            End Try
            Try
                dtWarrantySet.Clear()
            Catch ex As Exception
            End Try
            '//Load datatables
            dtCustomerSet = PSS.Data.Production.tbillmap.GetCustomerSet(tmpCustID, tmpModelID)
            dtRefDesDesc = PSS.Data.Production.lcodesdetail.GetCodesCELL(11, tmpManufID)
            dtFailureDesc = PSS.Data.Production.lcodesdetail.GetCodesCELL(4, tmpManufID)
            dtWarrantySet = PSS.Data.Production.twrtymap.GetWarrantySet(tmpModelID)
            'Craig D Haney September 24 2004 - END

            txtOutgoingMSN.Focus()

        End Sub

        Private Sub retreiveData()

            Try
                '_device.Dispose()
                '_tray.Dispose()

                _device = Nothing
                _tray = Nothing
            Catch ex As Exception
            End Try

            tstPriority = True

            defineGridComponents()

            getData(Me.txtTray.Text, Me.txtSerial.Text)

            Try
                clboxProblem.Items.Clear()
                clboxRepair.Items.Clear()
            Catch
            End Try

            populateCodePRIORITY(9, clboxProblem)
            If tstPriority = False Then populateCodeSMALL(9, clboxProblem)
            tstPriority = True
            populateCodePRIORITY(3, clboxRepair)
            If tstPriority = False Then populateCodeSMALL(3, clboxRepair)




            loadActions()
            loadTechs()

            txtOutgoingMSN.Focus()

            'NEW CDH
            loadGroup("Reference Designator", "DCode_LDesc", cboRefDes)
            loadGroup("Failure", "DCode_LDesc", cboFailCode)
            '            loadGroup("Repair Status", "DCode_LDesc", cboRepairStatus)

            loadBillCodes()
            loadServiceCodes()
            Me.LoadTray()
            Me.LoadDevice()
            populateParts()

            '/Determine if valid for billing
            Dim mthd As New PSS.Data.Production.Joins()
            Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT tcustomer.cust_repairnonwrty, tcustomer.cust_ReplaceLCD, tdevice.device_manufwrty FROM ((tcustomer INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID) INNER JOIN tdevice ON tdevice.loc_ID = tlocation.Loc_ID) WHERE tray_id = " & txtTray.Text & " AND device_SN = '" & txtSerial.Text & "'")
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
            "WHERE MCode_DESC = '" & valType & "' AND lcodesdetail.manuf_ID= " & tmpManufID & " AND lcodesdetail.prod_id= 2 AND lcodesdetail.Dcode_Inactive = 0 ORDER BY " & valField)

            If valType = "Reference Designator" Then
                dtRefDes = mthdGrp
            ElseIf valType = "Failure" Then
                dtFailureCode = mthdGrp
            ElseIf valType = "Repair Status" Then
                dtRepairCode = mthdGrp
            End If

            If valCtrl.GetType.ToString = "PSS.Gui.Controls.ComboBox" Then
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

            Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 ORDER BY BillCode_Desc")
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

        Private Sub loadServiceCodes()

            Dim mthd As New PSS.Data.Production.Joins()

            Try
                cboServiceCode.Items.Clear()
            Catch ex As Exception
            End Try
            '//Craig Haney - March 25, 2004
            'Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND BillCOde_Rule > 0 ORDER BY BillCode_Desc")
            Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 1 ORDER BY BillCode_Desc")
            dtServiceCode = mthdGrp
            Dim xCount As Integer = 0
            Dim r As DataRow
            For xCount = 0 To mthdGrp.Rows.Count - 1
                r = mthdGrp.Rows(xCount)
                cboServiceCode.Items.Add(r("BillCode_DESC"))
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
                End If
                Source = Nothing
            Else
                MsgBox("A tray number is all numeric. please enter a valid tray.", MsgBoxStyle.Information, "Error")
            End If

        End Sub

        Private Sub LoadDevice()
            Try
                Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(txtSerial.Text) & "'")
                _device = New Device(__device(0)("Device_ID"))
                Dim i As Integer = 0
                For i = 0 To _tray.Rows.Count - 1
                    If _tray.Rows(i)("Device_SN") = UCase(txtSerial.Text) Then
                        Exit For
                    End If
                Next

            Catch ex As Exception
                MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                _device = Nothing
            End Try
        End Sub

        Private Sub populateParts()

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

        Private Sub getPartData(ByVal ModelID As Int32)

            Dim dtPdata As New PSS.Data.Buisness.DeviceBilling()
            Dim dtPartData As DataTable = dtPdata.GetPartData(ModelID)

            Try
                dtPartData.Dispose()
                dtPartData = Nothing
            Catch ex As Exception
            End Try

        End Sub

        Private Sub HotKeysF12()

            If Len(Trim(tmpTrayID)) > 0 Then
                If Len(Trim(tmpDeviceID)) > 0 Then
                    UpdateBilling()
                End If
            End If

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



#Region "Bill Code Grid"

        Private Sub defineGridComponents()

            datagrid = CreateGridDT()
            gridComponents.DataSource = datagrid

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

#End Region

#Region "PF RA"

        Private Sub populate_PF_RA_Boxes()

            Try
                clboxProblem.Items.Clear()
                clboxRepair.Items.Clear()
            Catch
            End Try

            '//Use these once the priority level has been set in the table
            populateCodePRIORITY(9, clboxProblem)
            If tstPriority = False Then populateCodeSMALL(9, clboxProblem)
            tstPriority = True
            populateCodePRIORITY(3, clboxRepair)
            If tstPriority = False Then populateCodeSMALL(3, clboxRepair)
            '//Use these once the priority level has been set in the table
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
                    If tmpCustID = 1844 And tmpWO = 999999 Then
                        If r("Dcode_ID") = 524 Or r("Dcode_ID") = 1194 Then
                            ctl.Items.Add(r("Dcode_Ldesc"), True)
                        End If
                    ElseIf tmpWO = 65480 Then
                        If r("Dcode_ID") = 1134 Then
                            ctl.Items.Add(r("Dcode_Ldesc"), True)
                        End If
                    Else
                        ctl.Items.Add(r("Dcode_Ldesc"), False)
                    End If
                    'ctl.Items.Add(r("Dcode_Ldesc"), False)
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
                    If tmpCustID = 1844 And tmpWO = 999999 Then
                        If r("Dcode_ID") = 524 Or r("Dcode_ID") = 1194 Then
                            ctl.Items.Add(r("Dcode_Ldesc"), True)
                        End If
                    ElseIf tmpWO = 65480 Then
                        If r("Dcode_ID") = 1134 Then
                            ctl.Items.Add(r("Dcode_Ldesc"), True)
                        End If
                    Else
                        ctl.Items.Add(r("Dcode_Ldesc"), False)
                    End If
                    'ctl.Items.Add(r("Dcode_Ldesc"), False)
                End If
            Next

            Try
                dtDC.Dispose()
                dtDC = Nothing
            Catch ex As Exception
            End Try

        End Sub

#End Region

#Region "KeyDown Movement"

        Private Sub NextElement()

            If ActiveControl.Name = "cboRepairDate" Then btnUpdate.Focus()
            If ActiveControl.Name = "cboRepairStatus" Then cboRepairDate.Focus()
            If cboTroubleFound.Visible = True Then If ActiveControl.Name = "cboTroubleFound" Then cboRepairStatus.Focus()
            If ActiveControl.Name = "txtAirtime" Then cboTroubleFound.Focus()
            If ActiveControl.Name = "cboTechID" Then txtAirtime.Focus()
            If ActiveControl.Name = "txtSoftwareVerOUT" Then cboTechID.Focus()
            If ActiveControl.Name = "txtSoftwareVerIN" Then txtSoftwareVerOUT.Focus()
            If ActiveControl.Name = "txtMINnumber" Then txtSoftwareVerIN.Focus()
            If ActiveControl.Name = "txtOutgoingESNCSN" Then txtMINnumber.Focus()
            If ActiveControl.Name = "txtOutgoingIMEI" Then txtOutgoingESNCSN.Focus()
            If ActiveControl.Name = "txtOutgoingMSN" Then txtOutgoingIMEI.Focus()

        End Sub

        Private Sub txtOutgoingMSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoingMSN.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub txtOutgoingIMEI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoingIMEI.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub txtOutgoingESNCSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutgoingESNCSN.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub txtMINnumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMINnumber.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub txtSoftwareVerIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoftwareVerIN.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub txtSoftwareVerOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoftwareVerOUT.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub cboTechID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTechID.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub txtAirtime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAirtime.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub cboRepairStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRepairStatus.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub cboRepairDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRepairDate.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

#End Region



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
                    If tmpCustID = 1844 And tmpWO = 99999999 Then
                        If r("Dcode_ID") = 524 Or r("Dcode_ID") = 1194 Then
                            ctl.Items.Add(r("Dcode_Ldesc"), True)
                        End If
                    ElseIf tmpWO = 65480 Then
                        If r("Dcode_ID") = 1134 Then
                            ctl.Items.Add(r("Dcode_Ldesc"), True)
                        End If
                    Else
                        ctl.Items.Add(r("Dcode_Ldesc"), False)
                    End If
                    End If
            Next

            Try
                dtDC.Dispose()
                dtDC = Nothing
            Catch ex As Exception
            End Try

        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

            clearData()

            txtOutgoingESNCSN.Enabled = True
            txtOutgoingMSN.Enabled = True
            txtOutgoingIMEI.Enabled = True

            Try
                datagrid.Clear()
            Catch ex As Exception
            End Try
            txtTray.Text = ""
            txtSerial.Text = ""
            txtTray.Focus()

        End Sub

        Private Sub clearData()

            lblTroubleFound.Visible = False
            cboTroubleFound.SelectedIndex = -1
            cboTroubleFound.Visible = False

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
            cboBillCode.SelectedIndex = -1
            cboServiceCode.SelectedIndex = -1
            cboFailCode.Text = ""
            cboRefDes.Text = ""
            txtRefDesNum.Text = ""
            cbVoidManufWrty.Enabled = False  '//Craig Haney

            lblTray.Visible = False
            txtTray.Visible = False

            Try
                clboxProblem.Items.Clear()
                clboxRepair.Items.Clear()
            Catch
            End Try

            Try
                cboPartNum.Text = ""
                cboBillCode.Text = ""
                cboServiceCode.Text = ""
                cboBillCode.SelectedIndex = -1
                cboServiceCode.SelectedIndex = -1
                cboRefDes.Text = ""
                txtRefDesNum.Text = ""
                cboFailCode.Text = ""
            Catch ex As Exception
            End Try

            txtSerial.Focus()

        End Sub

        Private Function getDecimalValue(ByVal vHex As String) As String

            If Len(Trim(vHex)) > 7 Then
                'Make hex code conversion here
                Dim valHex As String = Mid$(Trim(vHex), 1, 8)
                Dim vals1 As String = Mid$(Trim(vHex), 1, 2)
                Dim vals2 As String = Mid$(Trim(vHex), 3, 6)
                Dim valDec1 As System.UInt32
                valDec1 = System.UInt32.Parse(vals1, Globalization.NumberStyles.HexNumber)
                Dim valDec2 As System.UInt32
                valDec2 = System.UInt32.Parse(vals2, Globalization.NumberStyles.HexNumber)

                Dim v1 As String = valDec1.ToString.PadLeft(3, "0")
                Dim v2 As String = valDec2.ToString.PadLeft(8, "0")
                getDecimalValue = v1 & v2
            End If

        End Function


        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click


            If Len(Trim(txtOutgoingESNCSN.Text)) > 1 Then
                If Trim(txtSerial.Text) <> Trim(txtOutgoingESNCSN.Text) Then
                    MsgBox("The Outgoing ESN has been changed. The system will update the current ESN Value.", MsgBoxStyle.OKOnly)
                    Try
                        ChangeSerial()
                    Catch ex As Exception
                        MsgBox("Error updating value.", MsgBoxStyle.OKOnly)
                    End Try
                    '//New Craig D. Haney June 23, 2005 START
                    Try
                        Dim newDecimal As String = getDecimalValue(txtOutgoingESNCSN.Text)
                        Dim ds As PSS.Data.Production.Joins
                        Dim blnDS As Boolean = ds.OrderEntryUpdateDelete("UPDATE tcellopt SET cellopt_Csn_Dec = '" & newDecimal & "' WHERE Device_ID = " & mSerialNumber)
                    Catch ex As Exception
                    End Try
                    '//New Craig D. Haney June 23, 2005 END
                End If
            End If

            If Len(Trim(txtOutgoingMSN.Text)) > 1 Then
                If Trim(txtSerial.Text) <> Trim(txtOutgoingMSN.Text) Then
                    MsgBox("The Outgoing MSN has been changed. The system will update the current Serial/MSN Value.", MsgBoxStyle.OKOnly)
                    Try
                        ChangeMSN()
                    Catch ex As Exception
                        MsgBox("Error updating value.", MsgBoxStyle.OKOnly)
                    End Try
                    '//New Craig D. Haney June 23, 2005 START
                    Try
                        Dim newDecimal As String = getDecimalValue(txtOutgoingMSN.Text)
                        Dim ds As PSS.Data.Production.Joins
                        Dim blnDS As Boolean = ds.OrderEntryUpdateDelete("UPDATE tcellopt SET cellopt_Csn_Dec = '" & newDecimal & "' WHERE Device_ID = " & mSerialNumber)
                    Catch ex As Exception
                    End Try
                    '//New Craig D. Haney June 23, 2005 END
                End If
            End If

            Dim blnUpd As Boolean = updateData()
            If blnUpd = False Then
                MsgBox("Did not update correctly")
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End If
            saveClboxInfo(tmpDeviceID)

            If tmpManufID = 1 Then
                Dim strCheckComplete As String
                strCheckComplete = PSS.Gui.Receiving.General.verEntry_SLI(tmpDeviceID)

                If Len(Trim(strCheckComplete)) > 0 Then MsgBox(strCheckComplete, MsgBoxStyle.OKOnly, "Additional DataRequired")
            End If


            Cursor.Current = System.Windows.Forms.Cursors.Default

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

            Try
                If Len(Trim(cboTroubleFound.SelectedValue)) > 0 Then
                    strSQL = "INSERT into tdevicecodes(Device_ID,Dcode_ID) VALUES(" & intDevice & ", " & cboTroubleFound.SelectedValue & ")"
                    blnInsert = insCode.UpdateCodes(strSQL)
                End If
            Catch ex As Exception
            End Try


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

            If Trim(valNewRepStat) = "ARP" Then valNewRepStat = "INR"

            If Trim(valNewRepStat) <> Trim(valOldRepStat) Then
                '//Update the send claim value to 0
                Dim mthdFlag As New PSS.Data.Production.Joins()
                Dim blnUpdateFlag As Boolean = mthdFlag.OrderEntryUpdateDelete("UPDATE tdevice SET Device_SendClaim = 0 WHERE Device_ID = " & tmpDeviceID)
                mthdFlag = Nothing
            End If

            Try
                If Trim(valNewRepStat) <> Trim(valOldRepStat) Then
                    '//Update the repair status value
                    '//Get old Dcode_ID for repair status
                    Dim RSNEWdr As DataRow = PSS.Data.Production.lcodesdetail.GetRepairStatusID(valNewRepStat, 10)
                    Dim RSOLDdr As DataRow = PSS.Data.Production.lcodesdetail.GetRepairStatusID(valOldRepStat, 10)
                    Dim mthdJoins As New PSS.Data.Production.Joins()
                    Dim blnUpdateRS As Boolean = mthdJoins.OrderEntryUpdateDelete("UPDATE tdevicecodes SET Dcode_ID = " & RSNEWdr("Dcode_ID") & " WHERE Device_ID = " & tmpDeviceID & " AND dcode_id =  " & RSOLDdr("Dcode_ID"))
                    '//Update the repair status value
                End If
            Catch EX As Exception
            End Try

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
                strUpdateList += "CellOpt_RepairDate = '" & PSS.Gui.Receiving.General.FormatDate(Trim(cboRepairDate.Text)) & "',"
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





        Private Sub cboPartNum_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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


        Private Sub txtSoftwareVerIN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSoftwareVerIN.Leave

            If Len(Trim(txtSoftwareVerOUT.Text)) < 1 Then
                If Len(Trim(txtSoftwareVerIN.Text)) > 0 Then
                    txtSoftwareVerOUT.Text = txtSoftwareVerIN.Text
                End If
            End If

        End Sub

        Private Sub loadActions()

            Try
                lstChecked.Items.Clear()
            Catch ex As Exception
            End Try
            Dim xCount As Integer
            For xCount = 0 To clboxProblem.CheckedItems.Count - 1
                lstChecked.Items.Add("PF: " & clboxProblem.CheckedItems(xCount))
            Next
            For xCount = 0 To clboxRepair.CheckedItems.Count - 1
                lstChecked.Items.Add("RA: " & clboxRepair.CheckedItems(xCount))
            Next

        End Sub



        Private Sub loadTechs()


            Try
                Me.cboTechID.Items.Clear()
            Catch ex As Exception

            End Try

            Dim lstTech As New PSS.Data.Production.tusers()
            dtTech = lstTech.GetCellTechList

            Dim xCount As Integer
            Dim r As DataRow

            'cboTechID.DataSource = dtTech.DefaultView
            'cboTechID.DisplayMember = dtTech.Columns("tech_id").ToString

            For xCount = 0 To dtTech.Rows.Count - 1
                r = dtTech.Rows(xCount)
                If IsDBNull(r("tech_id")) = False Then
                    cboTechID.Items.Add(r("tech_id"))
                End If
            Next

            'For xCount = 1 To UBound(arrTechs)
            'If IsDBNull(arrTechs(xCount, 1)) = False Then
            '    cboTechID.Items.Add(arrTechs(xCount, 1))
            'End If
            'Next

            Dim tmpUser As String = PSS.Core.[Global].ApplicationUser.User
            Dim tmpID As Integer = 0

            For xCount = 0 To dtTech.Rows.Count - 1
                r = dtTech.Rows(xCount)
                If tmpUser = r("user_fullname") Then
                    tmpID = r("tech_id")
                    lblTechName.Text = r("user_fullname")
                    Exit For
                End If
            Next

            'For xCount = 1 To UBound(arrTechs)
            'If tmpUser = arrTechs(xCount, 0) Then
            '    tmpID = arrTechs(xCount, 1)
            '    lblTechName.Text = arrTechs(xCount, 0)
            '    Exit For
            'End If
            'Next

            If tmpID = 0 Then cboTechID.SelectedIndex = -1

            cboTechID.Text = tmpID

        End Sub

        Private Sub getTechName()
            Dim xCount As Integer
            Dim r As DataRow
            Dim intTech As Integer = 0

            Try
                intTech = CInt(cboTechID.Text)
            Catch ex As Exception
                intTech = 0
            End Try

            For xCount = 0 To dtTech.Rows.Count - 1
                r = dtTech.Rows(xCount)

                If intTech = r("tech_id") Then
                    lblTechName.Text = r("user_fullname")
                    Exit For
                End If
            Next
            'For xCount = 1 To UBound(arrTechs)
            'If cboTechID.Text = arrTechs(xCount, 1) Then
            '    lblTechName.Text = arrTechs(xCount, 0)
            '    Exit For
            'End If
            'Next
        End Sub

        Private Sub cboTechID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTechID.SelectedValueChanged
            getTechName()
        End Sub

        Private Sub txtAirtime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAirtime.Leave
            If IsNumeric(txtAirtime.Text) = False Then
                txtAirtime.Text = PSS.Gui.Receiving.General.convertAirTime(txtAirtime.Text)
            End If
        End Sub

        Private Sub txtSerial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerial.TextChanged

        End Sub

        Private Sub txtTray_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTray.KeyDown

            If e.KeyValue = 13 Then

                Dim blnGetData As Boolean

                mSerialNumber = 0

                txtSerial.Text = UCase(txtSerial.Text)  '//Format serial as all uppercase
                Dim val As Long = Me.verifySerialNumberTray(txtSerial.Text, txtTray.Text)
                If val = 0 Then
                    lblTray.Visible = False
                    txtTray.Visible = False
                    txtSerial.Text = ""
                    txtSerial.Focus()
                    Exit Sub
                Else
                    mSerialNumber = val
                    txtTray.Text = getTrayID(mSerialNumber)
                    lblTray.Visible = True
                    txtTray.Visible = True
                    retreiveData()
                    'blnGetData = getDeviceData_tcellopt(mSerialNumber) '//Get tcellopt data for form
                    txtOutgoingMSN.Focus()
                    'If blnGetData = False Then
                    'MsgBox("The cellular phone data could not be acquired. Please verify the device serial number and tray.", MsgBoxStyle.OKOnly, "Device Not Found")
                    'lblTray.Visible = False
                    'txtTray.Visible = False
                    'txtSerial.Text = ""
                    'txtSerial.Focus()
                    'Exit Sub
                    'End If
                End If
            End If

        End Sub

        Private Sub clboxProblem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clboxProblem.SelectedIndexChanged

        End Sub

        Private Sub btnAddComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddComponent.Click

            Dim valRefDes As Integer
            Dim devBillID As Int32
            '//Get intial values

            valBillCode = 0
            valRefDes = 0
            valFailureCode = 0




            Dim blnReplace As Boolean = False


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
            If valBillCode = 0 Then
                For xCount = 0 To dtServiceCode.Rows.Count - 1
                    r = dtServiceCode.Rows(xCount)
                    If r("BillCode_Desc") = Me.cboServiceCode.Text Then
                        valBillCode = r("BillCode_ID")
                        Exit For
                    End If
                Next
            End If
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

            If dtRefDes.Rows.Count > 0 And dtFailureCode.Rows.Count > 0 Then
                '//NEW Craig D. Haney - requested by Asif
                If Len(Trim(cboBillCode.Text)) > 0 Then
                    If valRefDes = 0 Or valFailureCode = 0 Then
                        MsgBox("You must have defined a Reference Designator and Failure Code for any part billed. (These are not needed for services)", MsgBoxStyle.OKOnly, "ERROR")
                        cboRefDes.Focus()
                        Exit Sub
                    End If
                End If
            End If
            '//NEW Craig D. Haney - requested by Asif

            '//Check to see if this is a replacement phone
            If valBillCode = 394 Then


                Dim dtReplace As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM md_replacedevice WHERE OldModel_ID = " & tmpModelID)

                If dtReplace.Rows.Count > 0 Then
                    If PSS.Core.[Global].ApplicationUser.User = "Danny Oznick" Then

                        '//Verify billing before continuing
                        Dim strBillCheck As String = "SELECT * FROM tdevicebill where Device_ID = " & tmpDeviceID
                        Dim dtBillCheck As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strBillCheck)
                        If dtBillCheck.Rows.Count > 0 Then
                            MsgBox("Please remove all billed items before billing replacement phone", MsgBoxStyle.OKOnly, )
                            Exit Sub
                        End If
                        '//Verify billing before continuing



                        Dim tR As DataRow
                        tR = dtReplace.Rows(0)
                        Dim newModel As DataRow = PSS.Data.Production.tmodel.GetRowByModel(tR("NewModel_ID"))

                        Dim tResponse As String = MsgBox("Are you replaceing this model with a " & newModel("Model_Desc") & " model?", MsgBoxStyle.YesNo, "Model Change?")
                        Select Case tResponse
                            Case vbYes
                                If tR("NewModel_ID") > 0 And tR("NewSku_ID") > 0 And tmpDeviceID > 0 Then
                                    Dim strUpdate As String = "UPDATE tdevice SET model_id = " & tR("NewModel_ID") & ", sku_id = " & tR("NewSku_ID") & " WHERE device_id = " & tmpDeviceID
                                    Dim blnReplaceUpdate As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strUpdate)
                                    blnReplace = True
                                    '//Change Serial Number

                                    Dim strNewSerial As String = InputBox("Enter New Serial number:", "Serial Number")
                                    If Len(Trim(strNewSerial)) < 1 Then
                                        strNewSerial = InputBox("Entry Invalid. Please re-try, Enter New Serial number:", "Serial Number")
                                        If Len(Trim(strNewSerial)) < 1 Then
                                            MsgBox("You have not entered a valid value. Add of bill code - Exiting.", MsgBoxStyle.OKOnly)
                                            Exit Sub
                                        End If
                                    End If
                                    '//Execute change of serial number
                                    Try
                                        Dim blnUpdateCellOpt As Boolean
                                        If Len(Trim(txtOutgoingESNCSN.Text)) > 0 Then
                                            If tmpDeviceID > 0 Then
                                                Me.txtOutgoingESNCSN.Text = strNewSerial
                                                ChangeSerial()
                                                blnUpdateCellOpt = PSS.Data.Production.Joins.OrderEntryUpdateDelete("UPDATE tcellopt set cellopt_outcsn = '" & txtOutgoingESNCSN.Text & "' WHERE Device_ID = " & tmpDeviceID)
                                            End If
                                        ElseIf Len(Trim(txtOutgoingMSN.Text)) > 0 Then
                                            If tmpDeviceID > 0 Then
                                                Me.txtOutgoingMSN.Text = strNewSerial
                                                ChangeMSN()
                                                blnUpdateCellOpt = PSS.Data.Production.Joins.OrderEntryUpdateDelete("UPDATE tcellopt set cellopt_outmsn = '" & txtOutgoingMSN.Text & "' WHERE Device_ID = " & tmpDeviceID)
                                            End If
                                        Else
                                            MsgBox("Can NOT change serial number because phone technology not determined. Please change it manually", MsgBoxStyle.OKOnly)
                                        End If
                                    Catch ex As Exception
                                        MsgBox("Error updating value.", MsgBoxStyle.OKOnly)
                                    End Try
                                End If
                            Case vbNo
                                '//Continue as normal
                        End Select


                    Else
                        MsgBox("You do not have permissions to perform this action for this model.", MsgBoxStyle.OKOnly)
                        Exit Sub
                    End If
                End If

                '//This is to update the transaction value to correctly identify the action being performed
                If tmpDeviceID > 0 Then
                    Dim strUpdTransaction As String = "UPDATE tcellopt SET cellopt_transaction = 1345 WHERE device_id = " & tmpDeviceID
                    Dim blnUpdTransaction As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strUpdTransaction)

                    strUpdTransaction = "UPDATE tdevicecodes, lcodesdetail SET tdevicecodes.dcode_id = 1345 WHERE tdevicecodes.dcode_id = lcodesdetail.dcode_id AND tdevicecodes.device_id = " & tmpDeviceID & " AND lcodesdetail.mcode_id = 8"
                    blnUpdTransaction = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strUpdTransaction)
                End If

            End If
            '//Check to see if this is a replacement phone






            Try
                'Get Part Data Information
                _device.AddPart(valBillCode)
                System.Windows.Forms.Application.DoEvents()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

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

            Try
                'Delete RefDesNum
                genSQL = "DELETE FROM tbillcell WHERE DBill_ID = " & devBillID
                blnGeneric = tGeneric.OrderEntryUpdateDelete(genSQL)
                If blnGeneric = False Then
                    MsgBox("Ref Des Num could not be deleted", MsgBoxStyle.OKOnly)
                End If
            Catch ex As Exception
            End Try

            Try
                'Insert RefDesNum
                genSQL = "INSERT INTO tbillcell(BCell_RefDSNum, DBill_ID) VALUES( '" & txtRefDesNum.Text & "', " & devBillID & ")"
                blnGeneric = tGeneric.OrderEntryUpdateDelete(genSQL)
                If blnGeneric = False Then
                    MsgBox("Ref Des Num could not be inserted", MsgBoxStyle.OKOnly)
                End If
            Catch ex As Exception
                MsgBox("There was an error updating reference designator number.", MsgBoxStyle.OKOnly)
            End Try


            '//IF RUR then set transaction to RUR - number 1344 - BEGIN
            '//This is to update the transaction value to correctly identify the action being performed
            If tmpDeviceID > 0 Then
                Dim strRURcheck As String = "select tdevicebill.dbill_id from tdevicebill inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id where tdevicebill.device_id = " & tmpDeviceID & " and lbillcodes.billcode_rule = 1"
                Dim dtRURcheck As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strRURcheck)
                If dtRURcheck.Rows.Count > 0 Then
                    Dim strRURUpdTransaction As String = "UPDATE tcellopt SET cellopt_transaction = 1344 WHERE device_id = " & tmpDeviceID
                    Dim blnRURUpdTransaction As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strRURUpdTransaction)

                    strRURUpdTransaction = "UPDATE tdevicecodes, lcodesdetail SET tdevicecodes.dcode_id = 1344 WHERE tdevicecodes.dcode_id = lcodesdetail.dcode_id AND tdevicecodes.device_id = " & tmpDeviceID & " AND lcodesdetail.mcode_id = 8"
                    blnRURUpdTransaction = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strRURUpdTransaction)
                End If
            End If
            '//IF RUR then set transaction to RUR - number 1344 - END


            HotKeysF12()
            cboPartNum.Text = ""
            cboBillCode.Text = ""
            cboServiceCode.Text = ""
            cboBillCode.SelectedIndex = -1
            cboServiceCode.SelectedIndex = -1
            Me.cboRefDes.Text = ""
            txtRefDesNum.Text = ""
            Me.cboFailCode.Text = ""
            Me.txtRefDesNum.Text = ""
            populateParts()
            'Update tdevice date bill
            'Dim dtUpDev As New PSS.Data.Production.tdevice()
            'Dim blnUpd As Boolean = dtUpDev.UpdateBillDateByDevice(vDeviceID, PSS.Gui.Receiving.General.FormatDate(Now))


            If blnReplace = True Then
                If valBillCode = 394 Then
                    'Update data
                    Dim blnUpd As Boolean = updateData()
                    If blnUpd = False Then
                        MsgBox("Did not update correctly")
                        Cursor.Current = System.Windows.Forms.Cursors.Default
                    End If
                    saveClboxInfo(tmpDeviceID)

                    If tmpManufID = 1 Then
                        Dim strCheckComplete As String
                        strCheckComplete = PSS.Gui.Receiving.General.verEntry_SLI(tmpDeviceID)

                        If Len(Trim(strCheckComplete)) > 0 Then MsgBox(strCheckComplete, MsgBoxStyle.OKOnly, "Additional DataRequired")
                    End If
                    'Clear data
                    clearData()

                    Try
                        datagrid.Clear()
                    Catch ex As Exception
                    End Try
                    txtTray.Text = ""
                    txtSerial.Text = ""
                    txtTray.Focus()
                End If
            End If

        End Sub

        Private Sub clboxRepair_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clboxRepair.SelectedIndexChanged

        End Sub

        Private Sub btnRdefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRdefault.Click

            Try
                clboxRepair.Items.Clear()
            Catch ex As Exception
            End Try

            populateCodeSMALL(3, clboxRepair)

        End Sub

        Private Sub btnRcomplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRcomplete.Click

            Try
                clboxRepair.Items.Clear()
            Catch ex As Exception
            End Try

            populateCode(3, clboxRepair)

        End Sub

        Private Sub btnPFdefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPFdefault.Click

            Try
                clboxProblem.Items.Clear()
            Catch ex As Exception
            End Try

            populateCodeSMALL(9, clboxProblem)


        End Sub

        Private Sub btnPFcomplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPFcomplete.Click

            Try
                clboxProblem.Items.Clear()
            Catch ex As Exception
            End Try

            populateCode(9, clboxProblem)

        End Sub


        Private Sub gridComponents_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridComponents.MouseUp

            Try
                cboPartNum.Text = ""
                cboBillCode.Text = ""
                cboServiceCode.Text = ""
                cboBillCode.SelectedIndex = -1
                cboServiceCode.SelectedIndex = -1
                cboRefDes.Text = ""
                txtRefDesNum.Text = ""
                cboFailCode.Text = ""
            Catch ex As Exception
            End Try

            Try
                valBillCode = gridComponents.Columns(0).Value
            Catch ex As Exception
                Exit Sub
            End Try

            Me.btnDeleteComponent.Visible = True
            'Me.btnAddComponent.Visible = False
            Me.TabControl1.SelectedIndex = 2

            Try
                cboBillCode.Text = gridComponents.Columns(1).Value
                If Trim(cboBillCode.Text) = "" Then cboServiceCode.Text = gridComponents.Columns(1).Value
            Catch ex As Exception
                cboServiceCode.Text = gridComponents.Columns(1).Value
            End Try

            Try
                cboRefDes.Text = gridComponents.Columns(3).Value
            Catch ex As Exception
            End Try
            Try
                txtRefDesNum.Text = gridComponents.Columns(4).Value
            Catch ex As Exception
            End Try
            Try
                cboFailCode.Text = gridComponents.Columns(5).Value
            Catch ex As Exception
            End Try

        End Sub

        Private Sub btnDeleteComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteComponent.Click

            'Get Part Data Information

            Dim tDBillID As New PSS.Data.Production.tdevicebill()

            If tmpDeviceID > 0 Then
                Dim dtID As DataTable = tDBillID.GetDataTableByDevice(tmpDeviceID)
                Dim vBillID As String

                If dtID.Rows.Count = 1 Then
                    vBillID = dtID.Rows(0)("DBill_ID")
                    If vBillID > 0 Then
                        Dim blnExe As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete("DELETE FROM tpartscodes WHERE DBill_ID = " & vBillID)

                        Try
                            'Delete RefDesNum
                            Dim tGeneric As New PSS.Data.Production.Joins()
                            Dim genSQL As String
                            genSQL = "DELETE FROM tbillcell WHERE DBill_ID = " & vBillID
                            Dim blnGeneric As Boolean
                            blnGeneric = tGeneric.OrderEntryUpdateDelete(genSQL)
                            If blnGeneric = False Then
                                MsgBox("Ref Des Num could not be deleted", MsgBoxStyle.OKOnly)
                            End If
                        Catch ex As Exception
                        End Try


                    End If
                End If
            End If


            Dim dtBillID As DataTable = tDBillID.GetDataTableByDeviceBillCode(tmpDeviceID, valBillCode)

            If valBillCode > 0 Then
                Try
                    _device.DeletePart(valBillCode)
                    cboBillCode.Text = ""
                    cboBillCode.SelectedIndex = -1
                    cboServiceCode.SelectedIndex = -1
                    'HotKeysF12()
                    populateParts()
                Catch ex As Exception
                End Try
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

            'New Craig Haney August 9, 2004
            '//This is to update the transaction value to correctly identify the action being performed
            If tmpDeviceID > 0 Then
                Dim strRURcheck As String = "select tdevicebill.dbill_id from tdevicebill inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id where tdevicebill.device_id = " & tmpDeviceID & " and lbillcodes.billcode_rule = 1"
                Dim dtRURcheck As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strRURcheck)
                If dtRURcheck.Rows.Count = 0 Then
                    Dim strRURUpdTransaction As String = "UPDATE tcellopt SET cellopt_transaction = 307 WHERE device_id = " & tmpDeviceID
                    Dim blnRURUpdTransaction As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strRURUpdTransaction)

                    strRURUpdTransaction = "UPDATE tdevicecodes, lcodesdetail SET tdevicecodes.dcode_id = 307 WHERE tdevicecodes.dcode_id = lcodesdetail.dcode_id AND tdevicecodes.device_id = " & tmpDeviceID & " AND lcodesdetail.mcode_id = 8"
                    blnRURUpdTransaction = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strRURUpdTransaction)

                End If
            End If

            If valBillCode = 394 Then
                Dim strRURUpdTransaction As String = "UPDATE tcellopt SET cellopt_transaction = 307 WHERE device_id = " & tmpDeviceID
                Dim blnRURUpdTransaction As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strRURUpdTransaction)

                strRURUpdTransaction = "UPDATE tdevicecodes, lcodesdetail SET tdevicecodes.dcode_id = 307 WHERE tdevicecodes.dcode_id = lcodesdetail.dcode_id AND tdevicecodes.device_id = " & tmpDeviceID & " AND lcodesdetail.mcode_id = 8"
                blnRURUpdTransaction = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strRURUpdTransaction)

            End If
            '//IF RUR then set transaction to RUR - number 1344 - END
            'New Craig Haney August 9, 2004

            HotKeysF12()

            Try
                cboPartNum.Text = ""
                cboBillCode.Text = ""
                cboBillCode.SelectedIndex = -1
                cboServiceCode.SelectedIndex = -1
                cboRefDes.Text = ""
                txtRefDesNum.Text = ""
                cboFailCode.Text = ""
            Catch ex As Exception
            End Try

        End Sub

        Private Sub clboxProblem_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clboxProblem.MouseUp
            loadActions()
        End Sub

        Private Sub clboxRepair_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clboxRepair.MouseUp
            loadActions()
        End Sub

        Private Sub txtTray_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTray.TextChanged

        End Sub

        Private Sub cboBillCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillCode.SelectedIndexChanged

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

            '//Craig D Haney September 24 2004 - BEGIN

            If dtCustomerSet.Rows.Count > 0 Then

                Dim z, zCount As Integer
                Dim w, wCount As Integer
                Dim rHS As DataRow
                Dim rHScount As DataRow

                If vManufWrty = 0 Then

                    For z = 0 To dtCustomerSet.Rows.Count - 1
                        rHS = dtCustomerSet.Rows(z)
                        If rHS("BillCode_ID") = tmpBillCode Then

                            If IsDBNull(rHS("BMap_RefDes")) = False Then
                                For zCount = 0 To dtRefDesDesc.Rows.Count - 1
                                    rHScount = dtRefDesDesc.Rows(zCount)
                                    If rHScount("Dcode_ID") = rHS("BMap_RefDes") Then
                                        Me.cboRefDes.Text = rHScount("Dcode_LDesc")
                                        Exit For
                                    End If
                                Next
                            End If
                            If IsDBNull(rHS("BMap_RefDesNumb`")) = False Then
                                Try
                                    Me.txtRefDesNum.Text = rHS("BMap_RefDesNumb")
                                Catch ex As Exception
                                End Try
                            End If
                            If IsDBNull(rHS("BMap_Failure")) = False Then
                                For zCount = 0 To dtFailureDesc.Rows.Count - 1
                                    rHScount = dtFailureDesc.Rows(zCount)
                                    If rHScount("Dcode_ID") = rHS("BMap_Failure") Then
                                        Me.cboFailCode.Text = rHScount("Dcode_LDesc")
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Next


                ElseIf vManufWrty = 1 Then

                    For z = 0 To dtWarrantySet.Rows.Count - 1
                        rHS = dtWarrantySet.Rows(z)
                        If rHS("BillCode_ID") = tmpBillCode Then

                            If IsDBNull(rHS("WMap_RefDes")) = False Then
                                For zCount = 0 To dtRefDesDesc.Rows.Count - 1
                                    rHScount = dtRefDesDesc.Rows(zCount)
                                    If rHScount("Dcode_ID") = rHS("WMap_RefDes") Then
                                        Me.cboRefDes.Text = rHScount("Dcode_LDesc")
                                        Exit For
                                    End If
                                Next
                            End If
                            If IsDBNull(rHS("WMap_RefDesNumb`")) = False Then
                                Try
                                    Me.txtRefDesNum.Text = rHS("WMap_RefDesNumb")
                                Catch ex As Exception
                                End Try
                            End If
                            If IsDBNull(rHS("WMap_Failure")) = False Then
                                For zCount = 0 To dtFailureDesc.Rows.Count - 1
                                    rHScount = dtFailureDesc.Rows(zCount)
                                    If rHScount("Dcode_ID") = rHS("WMap_Failure") Then
                                        Me.cboFailCode.Text = rHScount("Dcode_LDesc")
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Next


                End If


            End If
            '//Craig D Haney September 24 2004 - END

            If tmpBillCode = 256 Then
            ElseIf tmpBillCode = 331 Then
                cboRefDes.Text = "Housing_Rear"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 201 Then
                'cboRefDes.Text = "Keypad Main"
                cboRefDes.Text = "Keypad_Main"      'Commented by Asif 04/21/2004
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
                cboRefDes.Text = "Housing_Front"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 314 Then
                cboRefDes.Text = "Antenna"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 251 Then
                cboRefDes.Text = "Vibrator"
                cboFailCode.Text = "Failure"
            ElseIf tmpBillCode = 311 Then
                cboRefDes.Text = "Keypad_Mylar"
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
                cboRefDes.Text = "Lens_Main"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 147 Then
                If tmpModelID = 733 Or tmpModelID = 565 Or tmpModelID = 738 Or tmpModelID = 735 Or tmpModelID = 718 Or tmpModelID = 739 Or tmpModelID = 626 Or tmpModelID = 564 Or tmpModelID = 563 Then
                    cboRefDes.Text = "Housing_Rear"
                    cboFailCode.Text = "Failure"
                End If
            ElseIf tmpBillCode = 178 Then
                cboRefDes.Text = "Housing_Front"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 319 Then
                cboRefDes.Text = "Shield"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 115 Then
                If tmpModelID = 563 Or tmpModelID = 564 Or tmpModelID = 626 Or tmpModelID = 739 Or tmpModelID = 733 Or tmpModelID = 718 Or tmpModelID = 565 Or tmpModelID = 735 Or tmpModelID = 738 Then
                    cboRefDes.Text = "Antenna"
                    cboFailCode.Text = "Failure"
                End If
            ElseIf tmpBillCode = 147 Then
                If tmpModelID = 626 Or tmpModelID = 739 Or tmpModelID = 733 Then
                    cboRefDes.Text = "Housing_Rear"
                    cboFailCode.Text = "Failure"
                End If
            ElseIf tmpBillCode = 408 Then
                If tmpModelID = 626 Then
                    cboRefDes.Text = "Housing Flip"
                    cboFailCode.Text = "Refurbishment"
                End If
            ElseIf tmpBillCode = 296 Then
                cboRefDes.Text = "Housing_Rear"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 185 Then
                cboRefDes.Text = "Housing_Front"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 334 Then
                cboRefDes.Text = "Label"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 318 Then
                cboRefDes.Text = "Lens_Main"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 413 Then
                cboRefDes.Text = "Pad"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 402 Then
                cboRefDes.Text = "Label"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 391 Then
                cboRefDes.Text = "Lens_Main"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 165 Then
                cboRefDes.Text = "Lens CLI"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 209 Then
                cboRefDes.Text = "Lens_Main"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 119 Then
                cboRefDes.Text = "Housing Flip"
                cboFailCode.Text = "Refurbishment"
            ElseIf tmpBillCode = 189 Then
                cboRefDes.Text = "Housing_Front"
                cboFailCode.Text = "Refurbishment"
            End If

            '//New Section Craig Haney for v60ic, v60it, v60p devices only
            If tmpModelID = 626 Or tmpModelID = 733 Or tmpModelID = 718 Then
                If tmpBillCode = 384 Then
                    cboRefDes.Text = "Switch"
                    cboFailCode.Text = "Failure"
                    txtRefDesNum.Text = "6001"
                ElseIf tmpBillCode = 385 Then
                    cboRefDes.Text = "Switch"
                    cboFailCode.Text = "Failure"
                    txtRefDesNum.Text = "6002"
                ElseIf tmpBillCode = 426 Then
                    cboRefDes.Text = "Switch"
                    cboFailCode.Text = "Failure"
                    txtRefDesNum.Text = "6004"
                ElseIf tmpBillCode = 383 Then
                    cboRefDes.Text = "Switch"
                    cboFailCode.Text = "Failure"
                    txtRefDesNum.Text = "6003"
                End If
            End If

            '//New Section Craig Haney for v60ic devices only
            If tmpModelID = 626 Then
                If tmpBillCode = 397 Then
                    cboRefDes.Text = "Keypad Sidekeys"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 185 Then
                    cboRefDes.Text = "Housing_Front"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 253 Then
                    cboRefDes.Text = "Keypad Sidekeys"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 115 Then
                    cboRefDes.Text = "Antenna"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 201 Then
                    cboRefDes.Text = "Keypad_Main"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 205 Then
                    cboRefDes.Text = "Keyboard"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 147 Then
                    cboRefDes.Text = "Endoskeleton / Chassis"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 322 Then
                    cboRefDes.Text = "Endoskeleton / Chassis"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 401 Then
                    cboRefDes.Text = "Endoskeleton / Chassis"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 235 Then
                    cboRefDes.Text = ""
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 219 Then
                    cboRefDes.Text = "Microphone"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 324 Then
                    cboRefDes.Text = ""
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 165 Then
                    cboRefDes.Text = "Lens CLI"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 403 Then
                    cboRefDes.Text = "Endoskeleton / Chassis"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 207 Then
                    cboRefDes.Text = "Display"
                    cboFailCode.Text = "Failure"
                    'cboRefDes.Text = "Endoskeleton / Chassis"
                    'cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 119 Then
                    cboRefDes.Text = "Endoskeleton / Chassis"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 209 Then
                    cboRefDes.Text = "Lens_Main"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 404 Then
                    cboRefDes.Text = ""
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 402 Then
                    cboRefDes.Text = "Label"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 409 Then
                    cboRefDes.Text = "Label"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 118 Then
                    cboRefDes.Text = "Housing Flip"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 300 Then
                    cboRefDes.Text = "Housing Flip"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 406 Then
                    cboRefDes.Text = "Housing Flip"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 120 Then
                    cboRefDes.Text = "Speaker"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 388 Then
                    cboRefDes.Text = "Antenna"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 400 Then
                    cboRefDes.Text = "Antenna"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 137 Then
                    cboRefDes.Text = "Switch"
                    txtRefDesNum.Text = "51"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 116 Then
                    cboRefDes.Text = "Connector"
                    txtRefDesNum.Text = "600"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 254 Then
                    cboRefDes.Text = "Switch"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 171 Then
                    cboRefDes.Text = "Connector"
                    txtRefDesNum.Text = "1000"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 321 Then
                    cboRefDes.Text = "Endoskeleton / Chassis"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 399 Then
                    cboRefDes.Text = "Connector"
                    txtRefDesNum.Text = "50"
                    cboFailCode.Text = "Failure"
                End If
            End If

            If tmpModelID = 623 Then
                If tmpBillCode = 353 Then
                    cboFailCode.Text = "Refurbished (cosmetic renewal)"
                ElseIf tmpBillCode = 143 Then
                    cboFailCode.Text = "Refurbished (cosmetic renewal)"
                ElseIf tmpBillCode = 164 Then
                    cboFailCode.Text = "Refurbished (cosmetic renewal)"
                ElseIf tmpBillCode = 167 Then
                    cboFailCode.Text = "Refurbished (cosmetic renewal)"
                ElseIf tmpBillCode = 207 Then
                    cboFailCode.Text = "Refurbished (cosmetic renewal)"
                ElseIf tmpBillCode = 114 Then
                    cboFailCode.Text = "Refurbished (cosmetic renewal)"
                End If
            End If



            If tmpModelID = 770 Then
                If tmpBillCode = 425 Then
                    cboRefDes.Text = "Alert"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 136 Then
                    cboRefDes.Text = "Alert"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 115 Then
                    cboRefDes.Text = "Antenna"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 415 Then
                    cboRefDes.Text = "Camera"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 139 Then
                    cboRefDes.Text = "Connector"
                    cboFailCode.Text = "Failure"
                    txtRefDesNum.Text = "3"
                ElseIf tmpBillCode = 399 Then
                    cboRefDes.Text = "Connector"
                    cboFailCode.Text = "Failure"
                    txtRefDesNum.Text = "1"
                ElseIf tmpBillCode = 236 Then
                    cboRefDes.Text = "Connector"
                    cboFailCode.Text = "Failure"
                    txtRefDesNum.Text = "1350"
                ElseIf tmpBillCode = 114 Then
                    cboRefDes.Text = "Connector"
                    cboFailCode.Text = "Failure"
                    txtRefDesNum.Text = "1400"
                ElseIf tmpBillCode = 412 Then
                    cboRefDes.Text = "Display"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 207 Then
                    cboRefDes.Text = "Display"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 424 Then
                    cboRefDes.Text = "Endoskeleton / Chassis"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 423 Then
                    cboRefDes.Text = "Endoskeleton / Chassis"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 408 Then
                    cboRefDes.Text = "Housing Flip"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 301 Then
                    cboRefDes.Text = "Housing Flip"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 321 Then
                    cboRefDes.Text = "Housing Flip"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 118 Then
                    cboRefDes.Text = "Housing Flip"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 178 Then
                    cboRefDes.Text = "Housing_Front"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 147 Then
                    cboRefDes.Text = "Housing_Rear"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 422 Then
                    cboRefDes.Text = "Housing_Rear"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 166 Then
                    cboRefDes.Text = "IC"
                    cboFailCode.Text = "Failure"
                    txtRefDesNum.Text = "1400"
                ElseIf tmpBillCode = 201 Then
                    cboRefDes.Text = "Keypad_Main"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 311 Then
                    cboRefDes.Text = "Keypad_Mylar"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 419 Then
                    cboRefDes.Text = "Label"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 165 Then
                    cboRefDes.Text = "Lens CLI"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 209 Then
                    cboRefDes.Text = "Lens_Main"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 219 Then
                    cboRefDes.Text = "Microphone"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 319 Then
                    cboRefDes.Text = "Shield"
                    cboFailCode.Text = "Refurbishment"
                ElseIf tmpBillCode = 120 Then
                    cboRefDes.Text = "Speaker"
                    cboFailCode.Text = "Failure"
                ElseIf tmpBillCode = 251 Then
                    cboRefDes.Text = "Vibrator"
                    cboFailCode.Text = "Failure"
                End If
            End If



        End Sub

        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        End Sub

        Private Sub TabControl1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Resize
            clboxProblem.Height = TabControl1.Height - 80
        End Sub

        Private Sub tbProblem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbProblem.Click

        End Sub

        Private Sub cbVoidManufWrty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVoidManufWrty.CheckedChanged

            If cbVoidManufWrty.Checked = True Then
                '//Cancel out Manufacturer Warranty
                If tmpDeviceID > 0 Then
                    Dim blnChange As Boolean = PSS.Data.Production.tdevice.UpdateManufWrtyOUT(tmpDeviceID)
                    vManufWrty = 1
                    Dim blnAudit As Boolean = PSS.Data.Production.Generic.GenericInsert("INSERT INTO tauditprocdetail (auditproc_new, audit_oldIDValue, audit_oldIDName) VALUES ('VOID MANUF WRTY'," & tmpDeviceID & ",'" & PSS.Core.[Global].ApplicationUser.User & "')")
                    cbVoidManufWrty.Enabled = False
                End If
            End If

        End Sub

        Private Function voidManufWrtry(ByVal vDeviceID As Int32) As Boolean

            '//First toggle setting of both variables
            Dim aToggle As New PSS.Data.Production.tdevice()

        End Function


        Private Sub cboTroubleFound_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTroubleFound.KeyDown
            If e.KeyValue = 13 Then NextElement()
        End Sub

        Private Sub tbPartsNotAvailable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPartsNotAvailable.Click

        End Sub

        Private Sub ChangeSerial()
            Dim __device As DataRow()
            If Len(Me.txtOutgoingESNCSN.Text) <> 0 Then
                __device = _tray.Select("Device_SN = '" & Trim(UCase(Me.txtOutgoingESNCSN.Text)) & "'")
            Else
                MsgBox("You must first scan a device in order to change the serial.", MsgBoxStyle.Information, "Error")
                Exit Sub
            End If

            If __device.Length > 0 Then
                MsgBox("This serial is ALREADY in use by another device in this tray.", MsgBoxStyle.Information, "Error")
                Me.txtOutgoingESNCSN.Text = ""
                Me.txtOutgoingESNCSN.Focus()
            Else
                __device = _tray.Select("Device_SN = '" & Me.txtSerial.Text & "'")
                If IsDBNull(__device(0)("Device_OldSN")) Then
                    __device(0)("Device_OldSN") = Me.txtSerial.Text
                End If
                __device(0)("Device_SN") = Trim(UCase(Me.txtOutgoingESNCSN.Text))
                Buisness.DeviceBilling.ChangeSerial(__device(0)("Device_ID"), Trim(UCase(Me.txtOutgoingESNCSN.Text)), _
                                                                                        Me.txtSerial.Text)
                __device = Nothing
                '                Me.txtSerial.Text = Trim(UCase(Me.txtOutgoingESNCSN.Text))
                '                Me.txtOutgoingESNCSN.Text = ""
                '                LoadDevice(Me, New KeyEventArgs(Keys.KeyCode.Enter))
            End If
        End Sub

        Private Sub ChangeMSN()
            Dim __device As DataRow()
            If Len(Me.txtOutgoingMSN.Text) <> 0 Then
                __device = _tray.Select("Device_SN = '" & Trim(UCase(Me.txtOutgoingMSN.Text)) & "'")
            Else
                MsgBox("You must first scan a device in order to change the MSN.", MsgBoxStyle.Information, "Error")
                Exit Sub
            End If

            If __device.Length > 0 Then
                MsgBox("This serial is ALREADY in use by another device in this tray.", MsgBoxStyle.Information, "Error")
                Me.txtOutgoingMSN.Text = ""
                Me.txtOutgoingMSN.Focus()
            Else
                __device = _tray.Select("Device_SN = '" & Me.txtSerial.Text & "'")
                If IsDBNull(__device(0)("Device_OldSN")) Then
                    __device(0)("Device_OldSN") = Me.txtSerial.Text
                End If
                __device(0)("Device_SN") = Trim(UCase(Me.txtOutgoingESNCSN.Text))
                Buisness.DeviceBilling.ChangeSerial(__device(0)("Device_ID"), Trim(UCase(Me.txtOutgoingMSN.Text)), _
                                                                                        Me.txtSerial.Text)
                __device = Nothing
                '                Me.txtSerial.Text = Trim(UCase(Me.txtOutgoingESNCSN.Text))
                '                Me.txtOutgoingESNCSN.Text = ""
                '                LoadDevice(Me, New KeyEventArgs(Keys.KeyCode.Enter))
            End If
        End Sub


        Private Sub txtRefDesNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefDesNum.TextChanged

        End Sub

        Private Sub txtRefDesNum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefDesNum.Leave

            If Len(Trim(txtRefDesNum.Text)) > 0 Then
                Try
                    If Trim(CInt(txtRefDesNum.Text)) = Trim(txtRefDesNum.Text) Then
                    Else
                        MsgBox("Reference Designator Numbers must be integer values only. Please try again.", MsgBoxStyle.OKOnly)
                        txtRefDesNum.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Reference Designator Numbers must be integer values only. Please try again.", MsgBoxStyle.OKOnly)
                    txtRefDesNum.Focus()
                    Exit Sub
                End Try
            End If

        End Sub

        Private Sub getDeviceType(ByVal mDeviceID As Long)

            txtOutgoingESNCSN.Enabled = True
            txtOutgoingMSN.Enabled = True
            txtOutgoingIMEI.Enabled = True
            Try
                Dim strSQL As String = "SELECT Dcode_L2Desc FROM ((tdevice INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id) INNER JOIN lcodesdetail ON tmodel.dcode_id = lcodesdetail.dcode_id) WHERE tdevice.device_id = " & mDeviceID
                Dim dtType As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
                Dim r As DataRow
                Dim xCount As Integer = 0
                For xCount = 0 To dtType.Rows.Count - 1
                    r = dtType.Rows(xCount)
                    If Trim(r("Dcode_L2Desc")) = "CDMA" Then
                        txtOutgoingESNCSN.Enabled = True
                        txtOutgoingMSN.Enabled = False
                        txtOutgoingIMEI.Enabled = False
                    ElseIf Trim(r("Dcode_L2Desc")) = "TDMA" Then
                        txtOutgoingESNCSN.Enabled = True
                        txtOutgoingMSN.Enabled = False
                        txtOutgoingIMEI.Enabled = False
                    ElseIf Trim(r("Dcode_L2Desc")) = "Analog" Then
                        txtOutgoingESNCSN.Enabled = True
                        txtOutgoingMSN.Enabled = False
                        txtOutgoingIMEI.Enabled = False
                    ElseIf Trim(r("Dcode_L2Desc")) = "GSM/PCS" Then
                        txtOutgoingESNCSN.Enabled = False
                        txtOutgoingMSN.Enabled = True
                        txtOutgoingIMEI.Enabled = True
                    Else
                        txtOutgoingESNCSN.Enabled = True
                        txtOutgoingMSN.Enabled = True
                        txtOutgoingIMEI.Enabled = True
                    End If
                Next
            Catch ex As Exception
            End Try

        End Sub



        Private Sub cboServiceCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServiceCode.SelectedIndexChanged

        End Sub

        Private Sub txtOutgoingESNCSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOutgoingESNCSN.TextChanged

        End Sub
    End Class

End Namespace
