Option Explicit On 
Imports PSS.Data.Buisness
Namespace Gui.WFMTracfone
	Public Class frmWFMOOBA
		Inherits System.Windows.Forms.Form
#Region "DECLARATIONS"
		Private Const strdelimiter As String = "~"
		Private _strScreenName As String = ""
		Private _iMenuCustID As Integer = 0
		Private _iMenuQCTypeID As Integer = 0
		Private _iPalletID As Integer = 0
		Private _qc As PSS.Data.Buisness.QC
		Private iDevice_ID As Integer = 0
		Private arrSplitLine(0)
		Private iQCResult As Integer = 0
		Private iGroup_ID As Integer = 0
		Private strGroup As String = ""
		Private iLine_ID As Integer = 0
		Private strLineNumber As String = ""
		Private strLineSide As String = ""
		Private _cust_id = 2597
		Private _loc_id = 3402
		Private _cpl_id = 13
		Private _qtyReqToTest As Integer = 0
		Private _boxStartQty As Integer = 0
		Private _boxHadFailures = False
		Private _disp_id = 5
#End Region
#Region " Windows Form Designer generated code "

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
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents btnPass As System.Windows.Forms.Button
		Friend WithEvents Panel2 As System.Windows.Forms.Panel
		Friend WithEvents lblCostCenter As System.Windows.Forms.Label
		Friend WithEvents lblUserName As System.Windows.Forms.Label
		Friend WithEvents lblWorkDate As System.Windows.Forms.Label
		Friend WithEvents lblShift As System.Windows.Forms.Label
		Friend WithEvents lblMachine As System.Windows.Forms.Label
		Friend WithEvents lblLineSide As System.Windows.Forms.Label
		Friend WithEvents lblGroup As System.Windows.Forms.Label
		Friend WithEvents lblLine As System.Windows.Forms.Label
		Friend WithEvents Button2 As System.Windows.Forms.Button
		Friend WithEvents lblPassed As System.Windows.Forms.Label
		Friend WithEvents Panel6 As System.Windows.Forms.Panel
		Friend WithEvents lblDeviceLoc As System.Windows.Forms.Label
		Friend WithEvents Button4 As System.Windows.Forms.Button
		Friend WithEvents txtSN As System.Windows.Forms.TextBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents btnSave As System.Windows.Forms.Button
		Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
		Friend WithEvents cmdRemove As System.Windows.Forms.Button
		Friend WithEvents lstFailCodes As System.Windows.Forms.ListBox
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents cboCodes As C1.Win.C1List.C1Combo
		Friend WithEvents Panel3 As System.Windows.Forms.Panel
		Friend WithEvents cmdDelete As System.Windows.Forms.Button
		Friend WithEvents grdHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents lblSN As System.Windows.Forms.Label
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents cboUsers As C1.Win.C1List.C1Combo
		Friend WithEvents lblTitle As System.Windows.Forms.Label
		Friend WithEvents btnFail As System.Windows.Forms.Button
		Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
		Friend WithEvents lblBoxName As System.Windows.Forms.Label
		Friend WithEvents lblCustName As System.Windows.Forms.Label
		Friend WithEvents lblBoxQty As System.Windows.Forms.Label
		Friend WithEvents chk100perCheck As System.Windows.Forms.CheckBox
		Friend WithEvents Panel1 As System.Windows.Forms.Panel
		Friend WithEvents Button1 As System.Windows.Forms.Button
		Friend WithEvents lblBoxPassQty As System.Windows.Forms.Label
		Friend WithEvents btnComplete As System.Windows.Forms.Button
		Friend WithEvents lblDateCode As System.Windows.Forms.Label
		Friend WithEvents lblWrtyStatus As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents lblBoxFailQty As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWFMOOBA))
			Me.btnClear = New System.Windows.Forms.Button()
			Me.btnPass = New System.Windows.Forms.Button()
			Me.Panel2 = New System.Windows.Forms.Panel()
			Me.lblCostCenter = New System.Windows.Forms.Label()
			Me.lblUserName = New System.Windows.Forms.Label()
			Me.lblWorkDate = New System.Windows.Forms.Label()
			Me.lblShift = New System.Windows.Forms.Label()
			Me.lblMachine = New System.Windows.Forms.Label()
			Me.lblLineSide = New System.Windows.Forms.Label()
			Me.lblGroup = New System.Windows.Forms.Label()
			Me.lblLine = New System.Windows.Forms.Label()
			Me.Button2 = New System.Windows.Forms.Button()
			Me.lblPassed = New System.Windows.Forms.Label()
			Me.Panel6 = New System.Windows.Forms.Panel()
			Me.lblDeviceLoc = New System.Windows.Forms.Label()
			Me.Button4 = New System.Windows.Forms.Button()
			Me.txtSN = New System.Windows.Forms.TextBox()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.lblDateCode = New System.Windows.Forms.Label()
			Me.lblWrtyStatus = New System.Windows.Forms.Label()
			Me.lblBoxQty = New System.Windows.Forms.Label()
			Me.lblCustName = New System.Windows.Forms.Label()
			Me.chk100perCheck = New System.Windows.Forms.CheckBox()
			Me.txtBoxName = New System.Windows.Forms.TextBox()
			Me.lblBoxName = New System.Windows.Forms.Label()
			Me.btnSave = New System.Windows.Forms.Button()
			Me.pnlFailCodes = New System.Windows.Forms.Panel()
			Me.cmdRemove = New System.Windows.Forms.Button()
			Me.lstFailCodes = New System.Windows.Forms.ListBox()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.cboCodes = New C1.Win.C1List.C1Combo()
			Me.Panel3 = New System.Windows.Forms.Panel()
			Me.cmdDelete = New System.Windows.Forms.Button()
			Me.grdHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.lblSN = New System.Windows.Forms.Label()
			Me.Label6 = New System.Windows.Forms.Label()
			Me.cboUsers = New C1.Win.C1List.C1Combo()
			Me.lblTitle = New System.Windows.Forms.Label()
			Me.btnFail = New System.Windows.Forms.Button()
			Me.Panel1 = New System.Windows.Forms.Panel()
			Me.Label7 = New System.Windows.Forms.Label()
			Me.lblBoxFailQty = New System.Windows.Forms.Label()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.btnComplete = New System.Windows.Forms.Button()
			Me.lblBoxPassQty = New System.Windows.Forms.Label()
			Me.Button1 = New System.Windows.Forms.Button()
			Me.Panel2.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.pnlFailCodes.SuspendLayout()
			CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel3.SuspendLayout()
			CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			Me.SuspendLayout()
			'
			'btnClear
			'
			Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
			Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnClear.ForeColor = System.Drawing.Color.White
			Me.btnClear.Location = New System.Drawing.Point(824, 152)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(120, 80)
			Me.btnClear.TabIndex = 5
			Me.btnClear.Text = "CLEAR"
			'
			'btnPass
			'
			Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
			Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnPass.ForeColor = System.Drawing.Color.White
			Me.btnPass.Location = New System.Drawing.Point(520, 152)
			Me.btnPass.Name = "btnPass"
			Me.btnPass.Size = New System.Drawing.Size(120, 80)
			Me.btnPass.TabIndex = 2
			Me.btnPass.Text = "PASS    (F9)"
			'
			'Panel2
			'
			Me.Panel2.BackColor = System.Drawing.Color.Black
			Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCostCenter, Me.lblUserName, Me.lblWorkDate, Me.lblShift, Me.lblMachine, Me.lblLineSide, Me.lblGroup, Me.lblLine, Me.Button2, Me.lblPassed})
			Me.Panel2.Location = New System.Drawing.Point(264, 1)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New System.Drawing.Size(680, 76)
			Me.Panel2.TabIndex = 97
			'
			'lblCostCenter
			'
			Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
			Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblCostCenter.ForeColor = System.Drawing.Color.Lime
			Me.lblCostCenter.Location = New System.Drawing.Point(468, 5)
			Me.lblCostCenter.Name = "lblCostCenter"
			Me.lblCostCenter.Size = New System.Drawing.Size(172, 19)
			Me.lblCostCenter.TabIndex = 101
			Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblUserName
			'
			Me.lblUserName.BackColor = System.Drawing.Color.Transparent
			Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblUserName.ForeColor = System.Drawing.Color.Lime
			Me.lblUserName.Location = New System.Drawing.Point(270, 6)
			Me.lblUserName.Name = "lblUserName"
			Me.lblUserName.Size = New System.Drawing.Size(198, 19)
			Me.lblUserName.TabIndex = 100
			Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblWorkDate
			'
			Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
			Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
			Me.lblWorkDate.Location = New System.Drawing.Point(270, 24)
			Me.lblWorkDate.Name = "lblWorkDate"
			Me.lblWorkDate.Size = New System.Drawing.Size(198, 18)
			Me.lblWorkDate.TabIndex = 99
			Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblShift
			'
			Me.lblShift.BackColor = System.Drawing.Color.Transparent
			Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblShift.ForeColor = System.Drawing.Color.Lime
			Me.lblShift.Location = New System.Drawing.Point(270, 41)
			Me.lblShift.Name = "lblShift"
			Me.lblShift.Size = New System.Drawing.Size(198, 19)
			Me.lblShift.TabIndex = 98
			Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblMachine
			'
			Me.lblMachine.BackColor = System.Drawing.Color.Transparent
			Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMachine.ForeColor = System.Drawing.Color.Lime
			Me.lblMachine.Location = New System.Drawing.Point(9, 41)
			Me.lblMachine.Name = "lblMachine"
			Me.lblMachine.Size = New System.Drawing.Size(254, 19)
			Me.lblMachine.TabIndex = 97
			Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblLineSide
			'
			Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
			Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
			Me.lblLineSide.Location = New System.Drawing.Point(77, 24)
			Me.lblLineSide.Name = "lblLineSide"
			Me.lblLineSide.Size = New System.Drawing.Size(128, 18)
			Me.lblLineSide.TabIndex = 96
			Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblGroup
			'
			Me.lblGroup.BackColor = System.Drawing.Color.Transparent
			Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblGroup.ForeColor = System.Drawing.Color.Lime
			Me.lblGroup.Location = New System.Drawing.Point(9, 6)
			Me.lblGroup.Name = "lblGroup"
			Me.lblGroup.Size = New System.Drawing.Size(254, 19)
			Me.lblGroup.TabIndex = 95
			Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblLine
			'
			Me.lblLine.BackColor = System.Drawing.Color.Transparent
			Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblLine.ForeColor = System.Drawing.Color.Lime
			Me.lblLine.Location = New System.Drawing.Point(9, 24)
			Me.lblLine.Name = "lblLine"
			Me.lblLine.Size = New System.Drawing.Size(66, 18)
			Me.lblLine.TabIndex = 94
			Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'Button2
			'
			Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Button2.Location = New System.Drawing.Point(168, 286)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New System.Drawing.Size(234, 37)
			Me.Button2.TabIndex = 66
			Me.Button2.TabStop = False
			Me.Button2.Text = "Generate Report"
			'
			'lblPassed
			'
			Me.lblPassed.BackColor = System.Drawing.Color.Black
			Me.lblPassed.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblPassed.ForeColor = System.Drawing.Color.Lime
			Me.lblPassed.Location = New System.Drawing.Point(468, 32)
			Me.lblPassed.Name = "lblPassed"
			Me.lblPassed.Size = New System.Drawing.Size(172, 27)
			Me.lblPassed.TabIndex = 84
			Me.lblPassed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'Panel6
			'
			Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
			Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDeviceLoc, Me.Button4, Me.txtSN, Me.Label1, Me.lblDateCode, Me.lblWrtyStatus})
			Me.Panel6.Location = New System.Drawing.Point(1, 144)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New System.Drawing.Size(495, 100)
			Me.Panel6.TabIndex = 1
			'
			'lblDeviceLoc
			'
			Me.lblDeviceLoc.BackColor = System.Drawing.Color.Transparent
			Me.lblDeviceLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblDeviceLoc.ForeColor = System.Drawing.Color.Blue
			Me.lblDeviceLoc.Location = New System.Drawing.Point(8, 32)
			Me.lblDeviceLoc.Name = "lblDeviceLoc"
			Me.lblDeviceLoc.Size = New System.Drawing.Size(320, 19)
			Me.lblDeviceLoc.TabIndex = 84
			'
			'Button4
			'
			Me.Button4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Button4.Location = New System.Drawing.Point(168, 286)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New System.Drawing.Size(234, 37)
			Me.Button4.TabIndex = 66
			Me.Button4.TabStop = False
			Me.Button4.Text = "Generate Report"
			'
			'txtSN
			'
			Me.txtSN.BackColor = System.Drawing.Color.Yellow
			Me.txtSN.Location = New System.Drawing.Point(86, 8)
			Me.txtSN.Name = "txtSN"
			Me.txtSN.Size = New System.Drawing.Size(240, 20)
			Me.txtSN.TabIndex = 3
			Me.txtSN.Text = ""
			'
			'Label1
			'
			Me.Label1.BackColor = System.Drawing.Color.Transparent
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.ForeColor = System.Drawing.Color.Blue
			Me.Label1.Location = New System.Drawing.Point(0, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(80, 19)
			Me.Label1.TabIndex = 55
			Me.Label1.Text = "IMEI/MEID:"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'lblDateCode
			'
			Me.lblDateCode.BackColor = System.Drawing.Color.Black
			Me.lblDateCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblDateCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblDateCode.ForeColor = System.Drawing.Color.Lime
			Me.lblDateCode.Location = New System.Drawing.Point(376, 59)
			Me.lblDateCode.Name = "lblDateCode"
			Me.lblDateCode.Size = New System.Drawing.Size(104, 32)
			Me.lblDateCode.TabIndex = 135
			Me.lblDateCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.lblDateCode.Visible = False
			'
			'lblWrtyStatus
			'
			Me.lblWrtyStatus.BackColor = System.Drawing.Color.Black
			Me.lblWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblWrtyStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblWrtyStatus.ForeColor = System.Drawing.Color.Lime
			Me.lblWrtyStatus.Location = New System.Drawing.Point(168, 59)
			Me.lblWrtyStatus.Name = "lblWrtyStatus"
			Me.lblWrtyStatus.Size = New System.Drawing.Size(192, 32)
			Me.lblWrtyStatus.TabIndex = 134
			Me.lblWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.lblWrtyStatus.Visible = False
			'
			'lblBoxQty
			'
			Me.lblBoxQty.BackColor = System.Drawing.Color.Transparent
			Me.lblBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBoxQty.ForeColor = System.Drawing.Color.Black
			Me.lblBoxQty.Location = New System.Drawing.Point(832, 32)
			Me.lblBoxQty.Name = "lblBoxQty"
			Me.lblBoxQty.Size = New System.Drawing.Size(104, 23)
			Me.lblBoxQty.TabIndex = 135
			Me.lblBoxQty.Text = "0"
			Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblCustName
			'
			Me.lblCustName.BackColor = System.Drawing.Color.Transparent
			Me.lblCustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblCustName.ForeColor = System.Drawing.Color.DarkGreen
			Me.lblCustName.Location = New System.Drawing.Point(16, 8)
			Me.lblCustName.Name = "lblCustName"
			Me.lblCustName.Size = New System.Drawing.Size(416, 19)
			Me.lblCustName.TabIndex = 134
			'
			'chk100perCheck
			'
			Me.chk100perCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.chk100perCheck.Location = New System.Drawing.Point(344, 41)
			Me.chk100perCheck.Name = "chk100perCheck"
			Me.chk100perCheck.Size = New System.Drawing.Size(96, 16)
			Me.chk100perCheck.TabIndex = 2
			Me.chk100perCheck.Text = "100% Test "
			'
			'txtBoxName
			'
			Me.txtBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtBoxName.Location = New System.Drawing.Point(87, 35)
			Me.txtBoxName.MaxLength = 30
			Me.txtBoxName.Name = "txtBoxName"
			Me.txtBoxName.Size = New System.Drawing.Size(240, 22)
			Me.txtBoxName.TabIndex = 1
			Me.txtBoxName.Text = ""
			'
			'lblBoxName
			'
			Me.lblBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBoxName.ForeColor = System.Drawing.Color.Black
			Me.lblBoxName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
			Me.lblBoxName.Location = New System.Drawing.Point(6, 35)
			Me.lblBoxName.Name = "lblBoxName"
			Me.lblBoxName.Size = New System.Drawing.Size(81, 16)
			Me.lblBoxName.TabIndex = 133
			Me.lblBoxName.Text = "Box Name:"
			Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'btnSave
			'
			Me.btnSave.BackColor = System.Drawing.Color.Green
			Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnSave.ForeColor = System.Drawing.Color.White
			Me.btnSave.Location = New System.Drawing.Point(704, 424)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New System.Drawing.Size(184, 72)
			Me.btnSave.TabIndex = 4
			Me.btnSave.Text = "SAVE (F5)"
			Me.btnSave.Visible = False
			'
			'pnlFailCodes
			'
			Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
			Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRemove, Me.lstFailCodes, Me.Label3, Me.cboCodes})
			Me.pnlFailCodes.Location = New System.Drawing.Point(1, 408)
			Me.pnlFailCodes.Name = "pnlFailCodes"
			Me.pnlFailCodes.Size = New System.Drawing.Size(655, 132)
			Me.pnlFailCodes.TabIndex = 7
			Me.pnlFailCodes.Visible = False
			'
			'cmdRemove
			'
			Me.cmdRemove.BackColor = System.Drawing.Color.SteelBlue
			Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cmdRemove.ForeColor = System.Drawing.Color.White
			Me.cmdRemove.Location = New System.Drawing.Point(560, 34)
			Me.cmdRemove.Name = "cmdRemove"
			Me.cmdRemove.Size = New System.Drawing.Size(84, 37)
			Me.cmdRemove.TabIndex = 3
			Me.cmdRemove.Text = "REMOVE"
			'
			'lstFailCodes
			'
			Me.lstFailCodes.Location = New System.Drawing.Point(97, 34)
			Me.lstFailCodes.Name = "lstFailCodes"
			Me.lstFailCodes.Size = New System.Drawing.Size(449, 82)
			Me.lstFailCodes.TabIndex = 2
			'
			'Label3
			'
			Me.Label3.BackColor = System.Drawing.Color.Transparent
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.ForeColor = System.Drawing.Color.Black
			Me.Label3.Location = New System.Drawing.Point(8, 9)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(80, 19)
			Me.Label3.TabIndex = 71
			Me.Label3.Text = "Fail Code:"
			Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboCodes
			'
			Me.cboCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboCodes.AutoCompletion = True
			Me.cboCodes.AutoDropDown = True
			Me.cboCodes.AutoSelect = True
			Me.cboCodes.Caption = ""
			Me.cboCodes.CaptionHeight = 17
			Me.cboCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboCodes.ColumnCaptionHeight = 17
			Me.cboCodes.ColumnFooterHeight = 17
			Me.cboCodes.ColumnHeaders = False
			Me.cboCodes.ContentHeight = 15
			Me.cboCodes.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboCodes.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboCodes.EditorHeight = 15
			Me.cboCodes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.cboCodes.ItemHeight = 15
			Me.cboCodes.Location = New System.Drawing.Point(99, 5)
			Me.cboCodes.MatchEntryTimeout = CType(2000, Long)
			Me.cboCodes.MaxDropDownItems = CType(10, Short)
			Me.cboCodes.MaxLength = 32767
			Me.cboCodes.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboCodes.Name = "cboCodes"
			Me.cboCodes.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboCodes.Size = New System.Drawing.Size(448, 21)
			Me.cboCodes.TabIndex = 1
			Me.cboCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Panel3
			'
			Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
			Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDelete, Me.grdHistory, Me.Label4, Me.lblSN, Me.Label6, Me.cboUsers})
			Me.Panel3.Location = New System.Drawing.Point(1, 245)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New System.Drawing.Size(943, 163)
			Me.Panel3.TabIndex = 6
			'
			'cmdDelete
			'
			Me.cmdDelete.BackColor = System.Drawing.Color.Red
			Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cmdDelete.ForeColor = System.Drawing.Color.White
			Me.cmdDelete.Location = New System.Drawing.Point(453, 4)
			Me.cmdDelete.Name = "cmdDelete"
			Me.cmdDelete.Size = New System.Drawing.Size(144, 20)
			Me.cmdDelete.TabIndex = 2
			Me.cmdDelete.Text = "Delete (Are you sure?)"
			Me.cmdDelete.Visible = False
			'
			'grdHistory
			'
			Me.grdHistory.GroupByCaption = "Drag a column header here to group by that column"
			Me.grdHistory.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
			Me.grdHistory.Location = New System.Drawing.Point(7, 32)
			Me.grdHistory.Name = "grdHistory"
			Me.grdHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.grdHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.grdHistory.PreviewInfo.ZoomFactor = 75
			Me.grdHistory.Size = New System.Drawing.Size(929, 120)
			Me.grdHistory.TabIndex = 6
			Me.grdHistory.Text = "C1TrueDBGrid1"
			Me.grdHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
			"ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
			"ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
			"CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
			"er;}Style1{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
			"t;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
			"5{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Contr" & _
			"olText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style" & _
			"13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""1" & _
			"2"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" M" & _
			"arqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vert" & _
			"icalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>116</Height><CaptionStyle " & _
			"parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenR" & _
			"owStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""St" & _
			"yle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" m" & _
			"e=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pa" & _
			"rent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /" & _
			"><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordS" & _
			"elector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pa" & _
			"rent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 925, 116</ClientRect><BorderSide>0" & _
			"</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
			"Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
			"ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
			"on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
			"d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
			"w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
			"<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
			"ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
			"ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
			"tRecSelWidth><ClientArea>0, 0, 925, 116</ClientArea><PrintPageHeaderStyle parent" & _
			"="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
			'
			'Label4
			'
			Me.Label4.BackColor = System.Drawing.Color.Transparent
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label4.ForeColor = System.Drawing.Color.Black
			Me.Label4.Location = New System.Drawing.Point(4, 7)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(117, 16)
			Me.Label4.TabIndex = 74
			Me.Label4.Text = "QC History for "
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lblSN
			'
			Me.lblSN.BackColor = System.Drawing.Color.Transparent
			Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblSN.ForeColor = System.Drawing.Color.Red
			Me.lblSN.Location = New System.Drawing.Point(131, 7)
			Me.lblSN.Name = "lblSN"
			Me.lblSN.Size = New System.Drawing.Size(219, 16)
			Me.lblSN.TabIndex = 76
			Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'Label6
			'
			Me.Label6.BackColor = System.Drawing.Color.Transparent
			Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label6.ForeColor = System.Drawing.Color.Black
			Me.Label6.Location = New System.Drawing.Point(616, 6)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(48, 17)
			Me.Label6.TabIndex = 82
			Me.Label6.Text = "Tech:"
			Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboUsers
			'
			Me.cboUsers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboUsers.AutoCompletion = True
			Me.cboUsers.AutoDropDown = True
			Me.cboUsers.AutoSelect = True
			Me.cboUsers.Caption = ""
			Me.cboUsers.CaptionHeight = 17
			Me.cboUsers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboUsers.ColumnCaptionHeight = 17
			Me.cboUsers.ColumnFooterHeight = 17
			Me.cboUsers.ColumnHeaders = False
			Me.cboUsers.ContentHeight = 15
			Me.cboUsers.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboUsers.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboUsers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboUsers.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboUsers.EditorHeight = 15
			Me.cboUsers.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
			Me.cboUsers.ItemHeight = 15
			Me.cboUsers.Location = New System.Drawing.Point(664, 4)
			Me.cboUsers.MatchEntryTimeout = CType(2000, Long)
			Me.cboUsers.MaxDropDownItems = CType(10, Short)
			Me.cboUsers.MaxLength = 32767
			Me.cboUsers.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboUsers.Name = "cboUsers"
			Me.cboUsers.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboUsers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboUsers.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboUsers.Size = New System.Drawing.Size(272, 21)
			Me.cboUsers.TabIndex = 1
			Me.cboUsers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'lblTitle
			'
			Me.lblTitle.BackColor = System.Drawing.Color.Black
			Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
			Me.lblTitle.Location = New System.Drawing.Point(1, 0)
			Me.lblTitle.Name = "lblTitle"
			Me.lblTitle.Size = New System.Drawing.Size(263, 77)
			Me.lblTitle.TabIndex = 96
			Me.lblTitle.Text = "OBA-AQL Test"
			Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnFail
			'
			Me.btnFail.BackColor = System.Drawing.Color.SteelBlue
			Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnFail.ForeColor = System.Drawing.Color.White
			Me.btnFail.Location = New System.Drawing.Point(672, 152)
			Me.btnFail.Name = "btnFail"
			Me.btnFail.Size = New System.Drawing.Size(120, 80)
			Me.btnFail.TabIndex = 3
			Me.btnFail.Text = "FAIL    (F12)"
			'
			'Panel1
			'
			Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
			Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.lblBoxFailQty, Me.Label5, Me.Label2, Me.btnComplete, Me.lblBoxPassQty, Me.Button1, Me.lblCustName, Me.lblBoxName, Me.txtBoxName, Me.chk100perCheck, Me.lblBoxQty})
			Me.Panel1.Location = New System.Drawing.Point(0, 78)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New System.Drawing.Size(944, 66)
			Me.Panel1.TabIndex = 2
			'
			'Label7
			'
			Me.Label7.BackColor = System.Drawing.Color.Transparent
			Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label7.ForeColor = System.Drawing.Color.Black
			Me.Label7.Location = New System.Drawing.Point(608, 0)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New System.Drawing.Size(104, 25)
			Me.Label7.TabIndex = 141
			Me.Label7.Text = "Passed"
			Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblBoxFailQty
			'
			Me.lblBoxFailQty.BackColor = System.Drawing.Color.Transparent
			Me.lblBoxFailQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblBoxFailQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBoxFailQty.ForeColor = System.Drawing.Color.Black
			Me.lblBoxFailQty.Location = New System.Drawing.Point(720, 32)
			Me.lblBoxFailQty.Name = "lblBoxFailQty"
			Me.lblBoxFailQty.Size = New System.Drawing.Size(104, 23)
			Me.lblBoxFailQty.TabIndex = 140
			Me.lblBoxFailQty.Text = "0"
			Me.lblBoxFailQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'Label5
			'
			Me.Label5.BackColor = System.Drawing.Color.Transparent
			Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label5.ForeColor = System.Drawing.Color.Black
			Me.Label5.Location = New System.Drawing.Point(720, 0)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(104, 25)
			Me.Label5.TabIndex = 139
			Me.Label5.Text = "Failed"
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'Label2
			'
			Me.Label2.BackColor = System.Drawing.Color.Transparent
			Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.ForeColor = System.Drawing.Color.Black
			Me.Label2.Location = New System.Drawing.Point(832, 0)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(104, 24)
			Me.Label2.TabIndex = 138
			Me.Label2.Text = "Box Qty."
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnComplete
			'
			Me.btnComplete.BackColor = System.Drawing.Color.SteelBlue
			Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnComplete.ForeColor = System.Drawing.Color.White
			Me.btnComplete.Location = New System.Drawing.Point(452, 24)
			Me.btnComplete.Name = "btnComplete"
			Me.btnComplete.Size = New System.Drawing.Size(144, 32)
			Me.btnComplete.TabIndex = 137
			Me.btnComplete.Text = "Complete box"
			'
			'lblBoxPassQty
			'
			Me.lblBoxPassQty.BackColor = System.Drawing.Color.Transparent
			Me.lblBoxPassQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblBoxPassQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBoxPassQty.ForeColor = System.Drawing.Color.Black
			Me.lblBoxPassQty.Location = New System.Drawing.Point(608, 32)
			Me.lblBoxPassQty.Name = "lblBoxPassQty"
			Me.lblBoxPassQty.Size = New System.Drawing.Size(104, 23)
			Me.lblBoxPassQty.TabIndex = 136
			Me.lblBoxPassQty.Text = "0"
			Me.lblBoxPassQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'Button1
			'
			Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Button1.Location = New System.Drawing.Point(168, 286)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New System.Drawing.Size(234, 37)
			Me.Button1.TabIndex = 66
			Me.Button1.TabStop = False
			Me.Button1.Text = "Generate Report"
			'
			'frmWFMOOBA
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.SteelBlue
			Me.ClientSize = New System.Drawing.Size(952, 549)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.btnClear, Me.btnPass, Me.Panel2, Me.Panel6, Me.btnSave, Me.pnlFailCodes, Me.Panel3, Me.lblTitle, Me.btnFail})
			Me.Name = "frmWFMOOBA"
			Me.Text = "frmWFMOOBA"
			Me.Panel2.ResumeLayout(False)
			Me.Panel6.ResumeLayout(False)
			Me.pnlFailCodes.ResumeLayout(False)
			CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel3.ResumeLayout(False)
			CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "CONSTRUCTORS AND SUCH"
		Public Sub New(Optional ByVal strScreenName As String = "", _
		  Optional ByVal iCustID As Integer = 0, _
		  Optional ByVal iQCTypeID As Integer = 0)
			MyBase.New()
			'This call is required by the Windows Form Designer.
			InitializeComponent()
			'Add any initialization after the InitializeComponent() call
			_strScreenName = strScreenName
			If strScreenName.Trim.Length > 0 Then
				lblTitle.Text = (strScreenName & " Test")
			End If
			_iMenuCustID = iCustID
			_iMenuQCTypeID = iQCTypeID
			_qc = New PSS.Data.Buisness.QC()
		End Sub
		Protected Overrides Sub Finalize()
			_qc = Nothing
			MyBase.Finalize()
		End Sub
#End Region
#Region "FORM EVENTS"
		Private Sub frmWFMOOBA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim i As Integer = 0
			Try
				If Not CheckIfMachineTiedToLine() Then
					Throw New Exception("Machine is not associated with a 'Line'. Please correct the issue and try again.")
				End If
				LoadUsers()
				LoadFailureCodes()
				_qc.SetShiftInfo(PSS.Core.ApplicationUser.IDShift)
				lblShift.Text = _qc.Shift
				lblUserName.Text = "Inspector: " & PSS.Core.ApplicationUser.User
				lblCustName.Text = Generic.GetCustomerName(Me._iMenuCustID)
				txtBoxName.Focus()
			Catch ex As Exception
				MessageBox.Show("Error in PSS.Core.ApplicationUser: " & ex.Message.ToString, _
				 Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub
#End Region
#Region "CONTROL EVENTS"
		Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
			RemoveItemFromList()
		End Sub
		Private Sub txtBoxName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBoxName.Enter
			Me.lblBoxQty.Text = "0"
			Me.lblBoxPassQty.Text = "0"
			Me.lblBoxFailQty.Text = "0"
			Me.txtSN.Text = ""
			Me.txtBoxName.Text = ""
			Me._iPalletID = 0
			Me.ResetControls()
		End Sub
		Private Sub txtBoxName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyDown
			Try
				If e.KeyCode = Keys.Enter AndAlso Me.txtBoxName.Text.Trim.Length > 0 Then
					If OpenTheBox(Me.txtBoxName.Text.Trim.ToUpper) Then
						Me.txtSN.Focus()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			End Try
		End Sub
		Private Sub txtSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyDown
			Dim dt1, dtLastQCRecord As DataTable
			Dim iDevice_CC As Integer = 0
			Dim strCompletedTech As String
			Dim _sn As String = Me.txtSN.Text.Trim
			Try
				If e.KeyValue = 13 Then
					If Me.txtSN.Text.Trim.Length = 0 Then
						Exit Sub
					ElseIf Me._iMenuCustID = 0 Then
						MessageBox.Show("Customer is not defined.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Me.txtSN.Text = "" : Exit Sub
					ElseIf Me._iMenuQCTypeID = 0 Then
						MessageBox.Show("QC Type is not defined.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Me.txtSN.Text = "" : Exit Sub
					ElseIf iGroup_ID = 0 Then
						MessageBox.Show("Group ID missing. This machine is not mapped to any Group.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Me.txtSN.Text = "" : Exit Sub
					ElseIf iLine_ID = 0 Then
						MessageBox.Show("Line ID missing. This machine is not mapped to any Line.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Me.txtSN.Text = "" : Exit Sub
					ElseIf Me._iPalletID = 0 Then
						MessageBox.Show("Please enter Box ID.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Me.txtSN.Text = "" : Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus() : Exit Sub
					End If

					strCompletedTech = ""
					ResetControls()

					'GET DEVICE INFO AND MODEL TYPE(WIP DOWN/NON-WIPEDOWN)
					dt1 = Generic.GetDeviceInfoInWIP(Trim(Me.txtSN.Text), Me._iMenuCustID)

					If dt1.Rows.Count > 0 Then
						If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso (dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> "BOX" And dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> "AQL-OBA") Then
							If dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> Me._strScreenName.Trim.ToUpper Then
								MessageBox.Show("The device belongs to " & dt1.Rows(0)("WorkStation").ToString & ".", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
								Me.txtSN.Text = "" : Exit Sub
							End If
						End If

						If Me._iPalletID > 0 AndAlso IsDBNull(dt1.Rows(0)("Pallett_ID")) Then
							MessageBox.Show("Device does not belong to any box.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
							Me.txtSN.Text = "" : Exit Sub
						ElseIf Me._iPalletID > 0 AndAlso Not IsDBNull(dt1.Rows(0)("Pallett_ID")) AndAlso dt1.Rows(0)("Pallett_ID") <> Me._iPalletID Then
							MessageBox.Show("Device does not belong to this box.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
							Me.txtSN.Text = "" : Exit Sub
						End If

						' MAKE SURE IF IT HAS FAILED AQL BEFORE IT HAS BEEN RETRIAGED.
						If Not ValidDeviceQCForAQL(dt1.Rows(0)("Device_id")) Then
							MessageBox.Show("This device is not valid to be included in an NTF box.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Exit Sub
						End If

						'dtLastQCRecord = Me._qc.GetLastQCRecord(dt1.Rows(0)("Device_id"))
						'If dtLastQCRecord.Rows.Count > 0 AndAlso dtLastQCRecord.Rows(0)("QCType_ID") = 4 Then
						'	MessageBox.Show("This unit has already AQL " & dtLastQCRecord.Rows(0)("QCResult") & "ed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						'	Me.txtSN.SelectAll()
						'	Exit Sub
						'End If

						Me.lblDeviceLoc.Text = PSS.Data.Buisness.Generic.GetCostCenterDescOfDevice(dt1.Rows(0)("Device_id"))

						iDevice_ID = dt1.Rows(0)("Device_id")
						If Not IsDBNull(dt1.Rows(0)("Pallett_ID")) AndAlso dt1.Rows(0)("Pallett_ID") > 0 Then
							PopulateQuanties()
						End If
						'
						'Display Warranty status and Manufacture Date code 
						'
						If dt1.Rows(0)("ManufDate").ToString.Trim.Length > 0 Then
							Me.lblWrtyStatus.Visible = True
							Me.lblDateCode.Visible = True
							Me.lblDateCode.Text = dt1.Rows(0)("ManufDate")
							If dt1.Rows(0)("Device_ManufWrty") Then Me.lblWrtyStatus.Text = "In Warranty" Else Me.lblWrtyStatus.Text = "Out of Warranty"
						End If

						'GET COMPLETED TECHNICIAN
						Dim _devTrg As New Data.BOL.tdevice_triage(_sn)
						cboUsers.SelectedValue = _devTrg.crt_user_id
						_devTrg = Nothing




						strCompletedTech = Generic.GetCelloptLastCompletedTech(iDevice_ID)
						If strCompletedTech.Trim.Length > 0 AndAlso strCompletedTech.Trim.Split("-").Length > 0 Then Me.cboUsers.SelectedValue = CInt(strCompletedTech.Trim.Split("-")(0))


						'GET DEVICE QC HISTORY
						LoadQCHistory()
						Me.lblSN.Text = Trim(Me.txtSN.Text)
						Me.txtSN.Text = "" : Me.txtSN.Focus()

					Else
						MessageBox.Show("The device scanned in does not exist.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Me.txtSN.Text = "" : Exit Sub
					End If
				ElseIf e.KeyValue = Keys.F9 Then
					PassQC()
				ElseIf e.KeyValue = Keys.F12 Then
					FailQC()
				ElseIf e.KeyValue = Keys.F5 Then
					SaveQCInfo()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message.ToString, Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
			End Try
		End Sub
		Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
			SaveQCInfo()
		End Sub
		Private Sub btnPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPass.Click
			PassQC()
		End Sub
		Private Sub btnFail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFail.Click
			FailQC()
		End Sub
		Private Sub cboCodes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCodes.KeyUp
			If e.KeyValue = 13 Then			  'Enter key presssed
				AddCodeToList()
			End If
		End Sub
		Private Sub lstFailCodes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstFailCodes.KeyUp
			If e.KeyValue = 13 Then			  'Enter Key Pressed
				RemoveItemFromList()
			End If
		End Sub
		Private Sub btnPass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnPass.KeyUp
			If e.KeyValue = Keys.Return Or e.KeyValue = Keys.F9 Then
				PassQC()
			ElseIf e.KeyValue = Keys.F12 Then
				FailQC()
			ElseIf e.KeyValue = Keys.F5 Then
				SaveQCInfo()
			End If
		End Sub
		Private Sub btnFail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnFail.KeyUp
			If e.KeyValue = Keys.Return Or e.KeyValue = Keys.F12 Then
				FailQC()
			ElseIf e.KeyValue = Keys.F9 Then
				PassQC()
			ElseIf e.KeyValue = Keys.F5 Then
				SaveQCInfo()
			End If
		End Sub
		Private Sub AllControlsKeyupEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUsers.KeyUp, cboCodes.KeyUp, lstFailCodes.KeyUp, grdHistory.KeyUp
			If e.KeyValue = Keys.F9 Then
				PassQC()
			ElseIf e.KeyValue = Keys.F12 Then
				FailQC()
			ElseIf e.KeyValue = Keys.F5 Then
				SaveQCInfo()
			ElseIf e.KeyValue = 13 AndAlso sender.name = "cboUsers" AndAlso Me.iQCResult = 2 Then
				Me.cboCodes.Focus()
			End If
		End Sub
		Private Sub btnSave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnSave.KeyUp
			If e.KeyValue = Keys.Return Or e.KeyValue = Keys.F5 Then
				SaveQCInfo()
			ElseIf e.KeyValue = Keys.F9 Then
				PassQC()
			ElseIf e.KeyValue = Keys.F12 Then
				FailQC()
			End If
		End Sub
		Private Sub cmdRemove_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdRemove.KeyUp
			If e.KeyValue = Keys.Return Then
				RemoveItemFromList()
			End If
			If e.KeyValue = Keys.F5 Then
				SaveQCInfo()
			ElseIf e.KeyValue = Keys.F9 Then
				PassQC()
			ElseIf e.KeyValue = Keys.F12 Then
				FailQC()
			End If
		End Sub
		Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
			Dim i As Integer = 0

			Try
				If Me.grdHistory.Columns.Count > 0 Then
					If Len(Me.grdHistory.Columns("QC_ID").Value) = 0 Then Exit Sub
				Else
					Exit Sub
				End If

				If MessageBox.Show("Are you sure you want to delete this QC result?", "Delete QC History", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
					i = _qc.DeleteQCHistory(CInt(Me.grdHistory.Columns("QC_ID").Value), PSS.Core.ApplicationUser.IDuser, System.Net.Dns.GetHostName)
					If i > 0 Then
						'MessageBox.Show("Deleted successfully", "Delete QC History", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
						LoadQCHistory()
					Else
						MessageBox.Show("Unable to delete QC history. Contact administrators.", "Delete QC History", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cmdDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			Try
				Me.ResetControls()
				Me.txtSN.Focus()
			Catch ex As Exception
				MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in btnClear_Click")
			End Try
		End Sub
		Private Sub chk100perCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk100perCheck.CheckedChanged
			Try
				EnableControls()
				Me.txtSN.Focus()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "chk100perCheck_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			End Try
		End Sub
		Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
			Try
				Me.Cursor = Cursors.WaitCursor
				CompleteTheBox()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Finally
				Me.Cursor = Cursors.Default
			End Try

		End Sub
#End Region
#Region "METHODS"
		Private Sub EnableControls()
			Dim _passQty As Integer = PSS.Data.Buisness.Generic.GetPalletAQLPassQty(_iPalletID)
			Dim _failQty As Integer = PSS.Data.Buisness.Generic.GetWFMPalletAQLFailQty(_iPalletID)
			btnComplete.Visible = (Me.chk100perCheck.Checked = False OrElse (_passQty + _failQty) >= _qtyReqToTest)
		End Sub
		Private Function CheckIfMachineTiedToLine() As Boolean
			Dim dt1 As DataTable
			Dim R1 As DataRow
			Dim objMisc As New PSS.Data.Buisness.Misc()

			Try
				dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
				If dt1.Rows.Count = 0 Then
					Return False
				End If
				R1 = dt1.Rows(0)
				iGroup_ID = R1("Group_ID")
				strGroup = Trim(R1("Group_Desc"))
				iLine_ID = R1("Line_ID")
				strLineNumber = Trim(R1("Line_Number"))
				strLineSide = Trim(R1("LineSide_Desc"))
				Me.lblGroup.Text = "Group: " & dt1.Rows(0)("CC_Group_Desc")
				Me.lblGroup.Tag = dt1.Rows(0)("CC_Group_ID")
				Me.lblLine.Text = dt1.Rows(0)("Line_Number")
				Me.lblLine.Tag = dt1.Rows(0)("Line_ID")
				Me.lblLineSide.Text = dt1.Rows(0)("LineSide_Desc")
				Me.lblMachine.Text = "Machine: " & System.Net.Dns.GetHostName
				Me.lblUserName.Text = "User: " & PSS.Core.Global.ApplicationUser.User
				Me.lblUserName.Tag = PSS.Core.Global.ApplicationUser.IDuser
				Me.lblShift.Text = "Shift: " & PSS.Core.Global.ApplicationUser.IDShift
				Me.lblWorkDate.Tag = PSS.Core.Global.ApplicationUser.Workdate
				Me.lblWorkDate.Text = "Work Date: " & Format(CDate(Me.lblWorkDate.Tag), "MM/dd/yyyy")
				If dt1.Rows(0)("Group_ID") = 0 Then
					MessageBox.Show("Machine does not map to any group, line and side.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.Enabled = False
				ElseIf dt1.Rows(0)("CC_Group_ID") = 0 Then
					MessageBox.Show("Machine does not map to any cost center.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.Enabled = False
				ElseIf dt1.Rows(0)("Group_ID") <> dt1.Rows(0)("CC_Group_ID") Then
					MessageBox.Show("Group of line and group of cost center are not the same. Please correct the mapping.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.Enabled = False
				ElseIf Me._iMenuCustID > 0 AndAlso Not IsDBNull(dt1.Rows(0)("CCG_CustID")) Then
					If Me._iMenuCustID <> dt1.Rows(0)("CCG_CustID") Then
						MessageBox.Show("This screen is not designed to work for the current mapped group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Me.Enabled = False
					End If
				ElseIf Me._iMenuCustID = 0 Then
					MessageBox.Show("Customer ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.Enabled = False
				End If
				Return True
			Catch ex As Exception
				Throw ex
				Return False
			Finally
				R1 = Nothing
				If Not IsNothing(dt1) Then
					dt1.Dispose()
					dt1 = Nothing
				End If
				objMisc = Nothing
			End Try
		End Function
		Private Sub LoadUsers()
			Dim dtUsers As New DataTable()
			Try
				dtUsers = _qc.LoadUsers()
				With Me.cboUsers
					.DataSource = dtUsers.DefaultView
					.DisplayMember = dtUsers.Columns("user_fullname").ToString
					.ValueMember = dtUsers.Columns("user_id").ToString
					.Splits(0).DisplayColumns("user_id").Visible = False
					.Splits(0).DisplayColumns("user_fullname").Width = .Width - (.VScrollBar.Width + 4)
					.SelectedValue = 0
				End With
			Catch ex As Exception
				MsgBox("Error in frmQC.LoadUsers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
			Finally
				_qc.DisposeDT(dtUsers)
			End Try
		End Sub
		Private Sub LoadFailureCodes()
			Dim dtCodes As New DataTable()
			Dim dtProdID As DataTable
			Dim i As Integer
			Try
				dtProdID = PSS.Data.Buisness.Generic.GetProductByCustID(False, Me._iMenuCustID)
				If dtProdID.Rows.Count = 0 Then
					MessageBox.Show("System can't define Product ID for customer " & Me.lblCustName.Text & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.Enabled = False
				ElseIf dtProdID.Rows.Count > 1 Then
					MessageBox.Show("This customer has more than one product. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.Enabled = False
				Else
					dtCodes = _qc.LoadFailureCodes(dtProdID.Rows(0)("Prod_ID"))
					With Me.cboCodes
						.DataSource = dtCodes.DefaultView
						.DisplayMember = dtCodes.Columns("DCode_SLDesc").ToString
						.ValueMember = dtCodes.Columns("DCode_ID").ToString
						For i = 0 To .Columns.Count - 1
							.Splits(0).DisplayColumns(i).Visible = False
						Next i
						.Splits(0).DisplayColumns("DCode_SLDesc").Visible = True
						.Splits(0).DisplayColumns("DCode_SLDesc").Width = .Width - (.VScrollBar.Width + 4)
						.SelectedValue = 0
					End With
				End If
			Catch ex As Exception
				Throw ex
			Finally
				_qc.DisposeDT(dtCodes)
				_qc.DisposeDT(dtProdID)
			End Try
		End Sub
		Private Sub LoadQCPASSNumber()
			Dim dt1 As New DataTable()
			Dim R1 As DataRow
			Try
				dt1 = _qc.GetQCPASSNumber(PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.IDShift, Me._iMenuQCTypeID, CInt(Me.lblGroup.Tag))
				If dt1.Rows.Count > 0 Then
					R1 = dt1.Rows(0)
					Me.lblPassed.Text = "Total Passed: " & R1("PassCount")
				Else
					Me.lblPassed.Text = "Total Passed: 0"
				End If

			Catch ex As Exception
				MsgBox("Error in frmQC.LoadQCNumbers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
			Finally
				R1 = Nothing
				_qc.DisposeDT(dt1)
			End Try
		End Sub
		Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			AddCodeToList()
		End Sub
		Private Sub AddCodeToList()
			Dim i As Integer = 0
			Dim strItem As String = ""
			Try
				If Me.cboCodes.SelectedValue = 0 Then
					MessageBox.Show("Please select the code again.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
					Exit Sub
				End If
				strItem = Trim(Me.cboCodes.Text) & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & strdelimiter & Me.cboCodes.SelectedValue
				For i = 0 To Me.lstFailCodes.Items.Count - 1
					If Me.lstFailCodes.Items(i) = strItem Then
						MsgBox("This code is already added to the list.", MsgBoxStyle.Information, "QC")
						Exit Sub
					End If
				Next
				Me.lstFailCodes.Items.Add(strItem)
				Me.cboCodes.SelectedValue = 0
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "AddCodeToList", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Sub RemoveItemFromList()
			If Me.lstFailCodes.SelectedIndex <> -1 Then			 'If nothing is selected
				Me.lstFailCodes.Items.RemoveAt(Me.lstFailCodes.SelectedIndex)
				Me.lstFailCodes.Refresh()
			End If
		End Sub
		Private Sub LoadQCHistory()
			Dim dt1 As DataTable
			Try
				dt1 = _qc.GetQCHistoryWithPalletInfo(iDevice_ID)
				Me.grdHistory.ClearFields()
				Me.grdHistory.DataSource = dt1.DefaultView
				SetGridProperties()

			Catch ex As Exception
				Throw New Exception("LoadQCHistory(): " & Environment.NewLine & ex.Message.ToString)
			Finally
				_qc.DisposeDT(dt1)
			End Try
		End Sub
		Private Sub SetGridProperties()
			Dim iNumOfColumns As Integer = Me.grdHistory.Columns.Count
			Dim i As Integer

			'Heading style (Horizontal Alignment to Center)
			For i = 0 To (iNumOfColumns - 1)
				Me.grdHistory.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
				If Me.grdHistory.Columns(i).Caption = "Failure Code" Then Me.grdHistory.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
				If Me.grdHistory.Columns(i).Caption = "Result" Then Me.grdHistory.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
			Next i

			'Set individual column data horizontal alignment
			Me.grdHistory.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

			'Set individual column data horizontal alignment
			With Me.grdHistory
				.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
				.Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				.Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				.Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
				.Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				.Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				.Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
				.Splits(0).DisplayColumns(7).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
			End With

			'Set Column Widths
			With Me.grdHistory
				.Splits(0).DisplayColumns("Iteration").Width = 50
				.Splits(0).DisplayColumns("Date").Width = 60
				.Splits(0).DisplayColumns("Type").Width = 50
				.Splits(0).DisplayColumns("Result").Width = 50
				.Splits(0).DisplayColumns("Failure Code").Width = 70
				.Splits(0).DisplayColumns("Failure Reason").Width = 170
				.Splits(0).DisplayColumns("Inspector").Width = 170
				.Splits(0).DisplayColumns("Tech").Width = 170
				.Splits(0).DisplayColumns("Box").Width = 145
			End With

			'Make some columns invisible
			Me.grdHistory.Splits(0).DisplayColumns("dcode_id").Visible = False
			Me.grdHistory.Splits(0).DisplayColumns("Inspector_id").Visible = False
			Me.grdHistory.Splits(0).DisplayColumns("tech_id").Visible = False
			Me.grdHistory.Splits(0).DisplayColumns("QC_ID").Visible = False
		End Sub
		Private Sub ClearCodeList()
			Me.lstFailCodes.Items.Clear()
		End Sub
		Private Function ConcatenateCodes() As String
			Dim i As Integer = 0
			Dim strCodes As String = ""
			Try
				For i = 0 To Me.lstFailCodes.Items.Count - 1
					arrSplitLine = Split(Trim(lstFailCodes.Items(i)), strdelimiter)
					strCodes += Trim(arrSplitLine(1))
					If i <> Me.lstFailCodes.Items.Count - 1 Then
						strCodes += ","
					End If
					ReDim arrSplitLine(0)
					arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)
				Next i
				ReDim arrSplitLine(0)
				arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)
				Return strCodes
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "ConcatenateCodes", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Function
		Private Sub ResetControls()
			iQCResult = 0
			iDevice_ID = 0
			Me.lblSN.Text = ""
			btnPass.BackColor = System.Drawing.Color.SteelBlue
			btnFail.BackColor = System.Drawing.Color.SteelBlue
			Me.cboCodes.SelectedValue = 0
			Me.lstFailCodes.Items.Clear()
			Me.pnlFailCodes.Visible = False
			Me.grdHistory.DataSource = Nothing
			Me.lblWrtyStatus.Text = ""
			Me.lblDateCode.Text = ""
			Me.lblDeviceLoc.Text = ""
			Me.lblWrtyStatus.Visible = False
			Me.lblDateCode.Visible = False
			Me.btnSave.Visible = False
			_boxHadFailures = False
		End Sub
		Private Function ValidatePallet(ByVal iPalletID As Integer) As Boolean
			Dim dt As DataTable
			Dim R1 As DataRow
			Dim booResult As Boolean = False
			Try
				If iPalletID = 0 Then
					Exit Function
				End If
				dt = Me._qc.GetPalletInfo(iPalletID)
				If dt.Rows.Count = 0 Then
					MessageBox.Show("Box name does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf dt.Rows.Count <> 1 AndAlso dt.Select("Pallet_Invalid = 0").Length > 1 Then
					MessageBox.Show("Box name exist more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf dt.Select("Pallet_Invalid = 0").Length = 1 Then
					R1 = dt.Select("Pallet_Invalid = 0")(0)
					If Not IsDBNull(R1("Pallett_ShipDate")) Then
						MessageBox.Show("Box has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf R1("Cust_ID") <> Me._iMenuCustID Then
						MessageBox.Show("Box does not belong to " & Me.lblCustName.Text & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf R1("Pallet_ShipType") <> 0 Then
						MessageBox.Show("This is not a refurbished box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Else
						booResult = True
					End If
				Else
					MessageBox.Show("Can't define box ID (" & iPalletID & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				End If
				Return booResult
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function
		Private Function DoesBoxExists(ByVal box_na As String)
			Dim _retVal As Boolean = False
			Dim _pallet As New Data.BOL.tpallet(box_na)
			_retVal = (_pallet.Pallett_ID > 0)
			_pallet = Nothing
			Return _retVal
		End Function
		Private Function OpenTheBox(ByVal strBoxName As String) As Boolean
			Dim dt As DataTable
			Dim iPalletQty As Integer
			Dim iPassQty As Integer
			Dim iFailQty As Integer
			Try
				If strBoxName.Trim.Length = 0 Then
					Exit Function
				End If
				Dim _pallet As New Data.BOL.tpallet(strBoxName)
				If _pallet.Pallett_ID < 1 Then
					Throw New Exception("Box name ( " & strBoxName & ") is not valid.")
				End If
				If _pallet.Pallet_Invalid Then
					Throw New Exception("Box name ( " & strBoxName & ") is marked as invalid.")
				End If
				If _pallet.Pallett_ReadyToShipFlg = 0 Then
					Throw New Exception("Box has not yet closed.")
				End If
				If _pallet.Pallett_ShipDate <> "" Then
					Throw New Exception("Box has been shipped.")
				End If
				If _pallet.Cust_ID <> Me._iMenuCustID Then
					Throw New Exception("Box does not belong to " & Me.lblCustName.Text & ".")
				End If
				If _pallet.Pallet_ShipType <> 0 Then
					Throw New Exception("This is not a refurbished box.")
				End If
				If _pallet.pallet_qc_passed = 1 Then
					txtBoxName.Text = ""
					Throw New Exception("This box has already passed AQL.")
				End If
				_iPalletID = _pallet.Pallett_ID
				PopulateQuanties()
				_qtyReqToTest = 1
				_boxStartQty = _pallet.Pallett_QTY
				EnableControls()
				Return True
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Function
		Private Function ValidDeviceQCForAQL(ByVal device_id As Integer) As Boolean
			' DAVID BRADLEY  03-30-2017
			' THIS VALIDATES THE QC HISTORY FOR A DEVICE TO ENSURE IT IS OKAY 
			' TO BE INCLUDED IN A BOX THAT IS QC PASSED.
			Dim _retVal As Boolean = False
			Dim _tqc As New Data.BOL.tqcDeviceQcCollection(device_id, 4)
			If _tqc.tqcDataTable.Rows.Count = 0 Then
				Return True
			Else
				' COMPARE THE LAST QC DATE WITH THE TRIAGE DATE.
				Dim _qcDate As New DateTime()
				Dim _trgDate As New DateTime()
				Dim _qcresult_id As Integer = 0
				_qcDate = _tqc.tqcDataTable.Rows(0)("QC_Date")
				_qcresult_id = _tqc.tqcDataTable.Rows(0)("QCResult_ID")
				Dim _trg As New Data.BOL.tdevice_triage(device_id)
				If _trg.dt_id > 1 Then
					_trgDate = _trg.crt_ts
					If _trgDate > _qcDate Then					  ' RETRIAGED
						_retVal = True
					Else
						If _qcresult_id = 1 Then						 ' PASSED
							_retVal = True
						Else
							_retVal = False							' FAILED OR OTHER
						End If
					End If
				Else
					Throw New Exception("No Triage record was found for this device.")
				End If
			End If
			Return _retVal
		End Function
		Private Sub PassQC()
			If iDevice_ID = 0 Then
				MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				Me.txtSN.Focus()
				Exit Sub
			End If
			btnPass.BackColor = System.Drawing.Color.Red
			btnFail.BackColor = System.Drawing.Color.SteelBlue
			iQCResult = 1
			pnlFailCodes.Visible = False
			Me.cboCodes.SelectedValue = 0
			ClearCodeList()
			If Me.cboUsers.SelectedValue > 0 Then
				Me.SaveQCInfo()
			Else
				Me.btnSave.Visible = True
			End If
		End Sub
		Private Sub FailQC()
			If iDevice_ID = 0 Then
				MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				Me.txtSN.Focus()
				Exit Sub
			Else
				FailTheBox()
				btnPass.BackColor = System.Drawing.Color.SteelBlue
				btnFail.BackColor = System.Drawing.Color.Red
				iQCResult = 2
				Me.btnSave.Visible = True
				pnlFailCodes.Visible = True
				If Me.cboUsers.SelectedValue > 0 Then
					Me.cboCodes.Focus()
				Else
					Me.cboUsers.Focus()
				End If
			End If
		End Sub
		Private Sub SaveQCInfo()
			' THIS PROCEDURE IS USED TO SAVE RESULTS OF EACH DEVICE ONE AT A TIME.
			Dim i As Integer = 0
			Dim strFailCodes As String = ""
			Dim strNextWrkStation As String = ""
			Dim iStationFailed As Integer = 0
			Dim iPalletQty As Integer = 0
			Dim iPassQty As Integer = 0
			Dim iFailQty As Integer = 0
			Try
				If iDevice_ID = 0 Then				  'Adding a new Device_ID
					MessageBox.Show("Please scan in a device to do " & Me._strScreenName & ".", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
				ElseIf iQCResult = 0 Then
					MessageBox.Show("Please choose if this device passed or failed QC.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
				ElseIf Me.cboUsers.SelectedValue = 0 Then
					MessageBox.Show("Please select the Tech who worked on this device.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.txtSN.SelectAll() : Me.cboUsers.Focus() : Exit Sub
				ElseIf iGroup_ID = 0 Then
					MessageBox.Show("Group ID missing.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
				ElseIf iLine_ID = 0 Then
					MessageBox.Show("Line ID missing.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
				ElseIf Me.chk100perCheck.Checked = False AndAlso (Me.txtBoxName.Text.Trim.Length = 0 Or Me._iPalletID = 0) Then
					MessageBox.Show("Please scan in the box ID.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.txtSN.Text = "" : Me.txtBoxName.Focus() : Exit Sub
				ElseIf Me._iPalletID = 0 Then
					MessageBox.Show("Please scan in the box ID.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.txtSN.SelectAll() : Exit Sub
				End If


				' THEY CHOSE FAIL THEN MAKE SURE THEY ENTERED A FAIL CODE.
				If iQCResult = 2 Then
					iStationFailed = 1
					If Me.lstFailCodes.Items.Count = 0 Then
						MessageBox.Show("This device failed " & Me._strScreenName & ", please select the QC reasons.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Me.cboCodes.Focus()
						Exit Sub
					End If
				End If
				strFailCodes = ConcatenateCodes()



				'Save QC result
				i = _qc.SaveQCResults( _
				 iDevice_ID, _
				 Me._iMenuQCTypeID, _
				 iQCResult, _
				 strFailCodes, _
				 Me.cboUsers.SelectedValue, _
				 PSS.Core.Global.ApplicationUser.IDuser, _
				 PSS.Core.Global.ApplicationUser.Workdate, _
				 iGroup_ID, _
				 iLine_ID, _
				 2, 0, , Me._iPalletID, , , , )




				If i > 0 Then
					' REMOVE UNIT FROM PALLETT, UPDATE BOX QTY
					If Me._iPalletID > 0 AndAlso iQCResult = 2 Then					 'failed
						If Me.ValidatePallet(Me._iPalletID) = False Then
							Exit Sub
						End If



						' NOTIFY USER OF ACTION TAKEN.

						Dim _dev As New Data.BOL.tDevice(iDevice_ID)



						' GET NEXT WORKSTATION.
						Dim _wf As New Data.BOL.tcustomer_prod_workflow("AQL")
						Dim _cpl_id_to As Integer = _wf.cpl_id_to
					Else
						MessageBox.Show("QC Results have been saved.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
					End If

					PopulateQuanties()
					LoadQCHistory()
					LoadQCPASSNumber()
					iQCResult = 0
					btnPass.BackColor = System.Drawing.Color.SteelBlue
					btnFail.BackColor = System.Drawing.Color.SteelBlue
					Me.cboUsers.SelectedValue = 0
					Me.cboCodes.SelectedValue = 0
					Me.lstFailCodes.Items.Clear()
					Me.pnlFailCodes.Visible = False
					Me.iDevice_ID = 0
					EnableControls()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message.ToString, "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				Me.txtSN.Focus()
			End Try
		End Sub
		Private Sub CompleteTheBox()
			' THIS PROCEDURE IS USED TO CLOSE THE BOX AFTER THE REQUIRED NUMBER OF DEVICES HAVE BEEN TESTING.

			Dim dt As DataTable
			Dim iPalletQty, iAQLPassQty, iAQLFailQty, i As Integer
			Dim strNextStation, strCurrentStation As String
			Try
				iPalletQty = 0
				iAQLPassQty = 0
				iAQLFailQty = 0
				i = 0
				strNextStation = ""
				strCurrentStation = ""

				' EXIT IF THERE IS NO PALLET.
				If Me._iPalletID = 0 Then
					MessageBox.Show("Box ID is not defined enter again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Exit Sub
				End If
				Dim _pwsCol As New Data.BOL.tpallettWrkStnCollection(_loc_id, Me.txtBoxName.Text.Trim)
				dt = _pwsCol.tPalletDevWrkstns.Copy
				If dt.Rows.Count = 0 Then
					MessageBox.Show("Box does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				ElseIf dt.Rows.Count > 1 Then
					MessageBox.Show("Some units in this box have the wrong workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				ElseIf dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
					MessageBox.Show("Box does not belong to any workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
					'ElseIf Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dt.Rows(0)("WorkStation").ToString.Trim, _cust_id, 0) = False Then
					'	Exit Sub





				ElseIf Generic.GetAQLFailBoxStatus(Me._iPalletID) = 2 Then
					MessageBox.Show("This box has unit(s) failed at OBA-AQL station. Please verify box quantity and reprint box label.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)





				Else
					iPalletQty = Generic.GetPalletQty(Me._iPalletID)
					iAQLPassQty = PSS.Data.Buisness.Generic.GetPalletAQLPassQty(_iPalletID)
					iAQLFailQty = PSS.Data.Buisness.Generic.GetWFMPalletAQLFailQty(_iPalletID)
					If iAQLPassQty = 0 Then
						MessageBox.Show("Box has no AQL Pass unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf iPalletQty = 0 Then
						MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf Me.chk100perCheck.Checked = True AndAlso (iAQLPassQty + iAQLFailQty) < iPalletQty Then
						MessageBox.Show("Box is not 100 percent AQL Pass.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						If Me.chk100perCheck.Checked = True Then
							Generic.DisposeDT(dt)
							dt = Generic.GetPalletNotAQLPassDevices(Me._iPalletID)
							If dt.Rows.Count > 0 Then
								Dim _msg As String = "This IMEI/MEID (" & dt.Rows(0)("Device_SN") & ") has no AQL Pass. Do you want to continue to fail this box?"
								If Not MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
									Exit Sub
								End If
							End If
						End If
					End If

					' IF WE MADE IT THIS FAR PUSH THE BOX TO ITS NEXT PERSPECTIVE LOCATION.
					Dim _wipowner As Integer = IIf(iAQLFailQty = 0, 4, 0)
					MoveDevicesToNextWrkstn(_iPalletID, _cpl_id, _wipowner)
					Dim _plt As New Data.BOL.tpallet(_iPalletID)
					_plt.pallet_qc_passed = IIf(iAQLFailQty = 0, 1, 0)
					_plt.ApplyChanges()
					MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
					'Me.lblBoxQty.Visible = False
					'Me.lblBoxQty.Text = "0"
					'Me.lblBoxPassQty.Visible = False
					'Me.lblBoxPassQty.Text = "0"
					Me.txtSN.Text = ""
					Me.txtBoxName.Text = ""
					Me._iPalletID = 0
					Me.ResetControls()
					Me.txtBoxName.Focus()
					PopulateQuanties()
					'iAQLPassQty = PSS.Data.Buisness.Generic.GetPalletAQLPassQty(Me._iPalletID)
					EnableControls()
				End If
				_pwsCol = Nothing
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub
		Private Sub FailTheBox()
			_boxHadFailures = True
			_qtyReqToTest = _boxStartQty
		End Sub
		Private Function MoveDevicesToNextWrkstn(ByVal pallet_id As Integer, ByVal cpl_id As Integer, ByVal wipowner As Integer) As Boolean
			Dim _dm As New Data.BLL.DeviceMovement(PSS.Core.ApplicationUser.IDuser)
			Dim _new_loc_id As Integer
			Dim _wipowner As Integer = 0
			If _boxHadFailures Then
				_new_loc_id = _dm.GetNextLocID(_cpl_id, _disp_id, True)
				_wipowner = 0
			Else
				_new_loc_id = _dm.GetNextLocIDWithDisp(_cpl_id, _disp_id)
				_wipowner = 4
			End If

			Dim _devs As New Data.BOL.tDeviceCollectionByPallett(pallet_id)
			Dim _dr As DataRow
			For Each _dr In _devs.deviceDataTable.Rows
				_dm.MoveDeviceToLoc(_dr("device_id"), _new_loc_id, _wipowner)
			Next
			_devs = Nothing
			_dm = Nothing
			Return True
		End Function
		Private Sub PopulateQuanties()
			Dim _qty As Integer = Generic.GetPalletQty(Me._iPalletID)
			Dim _passQty As Integer = PSS.Data.Buisness.Generic.GetPalletAQLPassQty(_iPalletID)
			Dim _failQty = PSS.Data.Buisness.Generic.GetWFMPalletAQLFailQty(_iPalletID)
			If _failQty > 0 Then
				FailTheBox()
			End If
			lblBoxQty.Text = _qty.ToString()
			lblBoxPassQty.Text = _passQty.ToString()
			lblBoxFailQty.Text = _failQty.ToString()
		End Sub
#End Region
	End Class
End Namespace
