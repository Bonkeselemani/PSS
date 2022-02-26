Option Explicit On 

Namespace Gui.TracFone

	Public Class TFSWScreening
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
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents Label15 As System.Windows.Forms.Label
		Friend WithEvents Label16 As System.Windows.Forms.Label
		Friend WithEvents Label17 As System.Windows.Forms.Label
		Friend WithEvents pnlBox As System.Windows.Forms.Panel
		Friend WithEvents txtBoxNr As System.Windows.Forms.TextBox
		Friend WithEvents pnlDevice As System.Windows.Forms.Panel
		Friend WithEvents lbBoxWorkers As System.Windows.Forms.ListBox
		Friend WithEvents nudBoxQty As System.Windows.Forms.NumericUpDown
		Friend WithEvents nudUPQty As System.Windows.Forms.NumericUpDown
		Friend WithEvents nudRecQty As System.Windows.Forms.NumericUpDown
		Friend WithEvents nudSWQty As System.Windows.Forms.NumericUpDown
		Friend WithEvents txtSN As System.Windows.Forms.TextBox
		Friend WithEvents btnSwitchBox As System.Windows.Forms.Button
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents lblListType As System.Windows.Forms.Label
		Friend WithEvents pbCheck As System.Windows.Forms.PictureBox
		Friend WithEvents pbX As System.Windows.Forms.PictureBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents pnlBoxList As System.Windows.Forms.Panel
		Friend WithEvents pnlRecList As System.Windows.Forms.Panel
		Friend WithEvents pnlSWFailList As System.Windows.Forms.Panel
		Friend WithEvents pnlUnPrcList As System.Windows.Forms.Panel
		Friend WithEvents lbBoxDevices As System.Windows.Forms.ListBox
		Friend WithEvents lbRecDevices As System.Windows.Forms.ListBox
		Friend WithEvents lbSWFDevices As System.Windows.Forms.ListBox
		Friend WithEvents lbUnPDevices As System.Windows.Forms.ListBox
		Friend WithEvents btnPrintALabel As System.Windows.Forms.Button
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TFSWScreening))
			Me.pnlBox = New System.Windows.Forms.Panel()
			Me.Label17 = New System.Windows.Forms.Label()
			Me.Label16 = New System.Windows.Forms.Label()
			Me.Label15 = New System.Windows.Forms.Label()
			Me.txtBoxNr = New System.Windows.Forms.TextBox()
			Me.lbBoxWorkers = New System.Windows.Forms.ListBox()
			Me.nudBoxQty = New System.Windows.Forms.NumericUpDown()
			Me.pnlDevice = New System.Windows.Forms.Panel()
			Me.pbX = New System.Windows.Forms.PictureBox()
			Me.pbCheck = New System.Windows.Forms.PictureBox()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.Label7 = New System.Windows.Forms.Label()
			Me.txtSN = New System.Windows.Forms.TextBox()
			Me.nudUPQty = New System.Windows.Forms.NumericUpDown()
			Me.nudRecQty = New System.Windows.Forms.NumericUpDown()
			Me.nudSWQty = New System.Windows.Forms.NumericUpDown()
			Me.pnlBoxList = New System.Windows.Forms.Panel()
			Me.lblListType = New System.Windows.Forms.Label()
			Me.lbBoxDevices = New System.Windows.Forms.ListBox()
			Me.btnSwitchBox = New System.Windows.Forms.Button()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.pnlRecList = New System.Windows.Forms.Panel()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.lbRecDevices = New System.Windows.Forms.ListBox()
			Me.pnlSWFailList = New System.Windows.Forms.Panel()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.lbSWFDevices = New System.Windows.Forms.ListBox()
			Me.pnlUnPrcList = New System.Windows.Forms.Panel()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.lbUnPDevices = New System.Windows.Forms.ListBox()
			Me.btnPrintALabel = New System.Windows.Forms.Button()
			Me.pnlBox.SuspendLayout()
			CType(Me.nudBoxQty, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlDevice.SuspendLayout()
			CType(Me.nudUPQty, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nudRecQty, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nudSWQty, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlBoxList.SuspendLayout()
			Me.pnlRecList.SuspendLayout()
			Me.pnlSWFailList.SuspendLayout()
			Me.pnlUnPrcList.SuspendLayout()
			Me.SuspendLayout()
			'
			'pnlBox
			'
			Me.pnlBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label17, Me.Label16, Me.Label15, Me.txtBoxNr, Me.lbBoxWorkers})
			Me.pnlBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.pnlBox.Location = New System.Drawing.Point(8, 8)
			Me.pnlBox.Name = "pnlBox"
			Me.pnlBox.Size = New System.Drawing.Size(824, 88)
			Me.pnlBox.TabIndex = 0
			'
			'Label17
			'
			Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label17.Location = New System.Drawing.Point(568, 8)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New System.Drawing.Size(88, 56)
			Me.Label17.TabIndex = 3
			Me.Label17.Text = "Current Box Workers:"
			Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
			Me.Label17.Visible = False
			'
			'Label16
			'
			Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label16.ForeColor = System.Drawing.Color.White
			Me.Label16.Location = New System.Drawing.Point(152, 40)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New System.Drawing.Size(256, 32)
			Me.Label16.TabIndex = 2
			Me.Label16.Text = "Please enter the box # you would like to work."
			'
			'Label15
			'
			Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label15.Location = New System.Drawing.Point(32, 8)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New System.Drawing.Size(112, 23)
			Me.Label15.TabIndex = 0
			Me.Label15.Text = "Box No.:"
			Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'txtBoxNr
			'
			Me.txtBoxNr.BackColor = System.Drawing.Color.Yellow
			Me.txtBoxNr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtBoxNr.Location = New System.Drawing.Point(152, 8)
			Me.txtBoxNr.Name = "txtBoxNr"
			Me.txtBoxNr.Size = New System.Drawing.Size(256, 23)
			Me.txtBoxNr.TabIndex = 1
			Me.txtBoxNr.Text = ""
			'
			'lbBoxWorkers
			'
			Me.lbBoxWorkers.BackColor = System.Drawing.SystemColors.Control
			Me.lbBoxWorkers.Location = New System.Drawing.Point(664, 8)
			Me.lbBoxWorkers.Name = "lbBoxWorkers"
			Me.lbBoxWorkers.Size = New System.Drawing.Size(152, 69)
			Me.lbBoxWorkers.TabIndex = 4
			Me.lbBoxWorkers.Visible = False
			'
			'nudBoxQty
			'
			Me.nudBoxQty.BackColor = System.Drawing.SystemColors.Control
			Me.nudBoxQty.Enabled = False
			Me.nudBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.nudBoxQty.Location = New System.Drawing.Point(8, 202)
			Me.nudBoxQty.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
			Me.nudBoxQty.Name = "nudBoxQty"
			Me.nudBoxQty.Size = New System.Drawing.Size(184, 20)
			Me.nudBoxQty.TabIndex = 6
			Me.nudBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'pnlDevice
			'
			Me.pnlDevice.BackColor = System.Drawing.SystemColors.Control
			Me.pnlDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.pbX, Me.pbCheck, Me.lblMsg, Me.Label7, Me.txtSN})
			Me.pnlDevice.Location = New System.Drawing.Point(8, 104)
			Me.pnlDevice.Name = "pnlDevice"
			Me.pnlDevice.Size = New System.Drawing.Size(824, 72)
			Me.pnlDevice.TabIndex = 1
			'
			'pbX
			'
			Me.pbX.Image = CType(resources.GetObject("pbX.Image"), System.Drawing.Bitmap)
			Me.pbX.Location = New System.Drawing.Point(423, 20)
			Me.pbX.Name = "pbX"
			Me.pbX.Size = New System.Drawing.Size(17, 12)
			Me.pbX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbX.TabIndex = 21
			Me.pbX.TabStop = False
			Me.pbX.Visible = False
			'
			'pbCheck
			'
			Me.pbCheck.Image = CType(resources.GetObject("pbCheck.Image"), System.Drawing.Bitmap)
			Me.pbCheck.Location = New System.Drawing.Point(408, 16)
			Me.pbCheck.Name = "pbCheck"
			Me.pbCheck.Size = New System.Drawing.Size(12, 16)
			Me.pbCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbCheck.TabIndex = 20
			Me.pbCheck.TabStop = False
			Me.pbCheck.Visible = False
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(456, 16)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(360, 48)
			Me.lblMsg.TabIndex = 19
			Me.lblMsg.Text = "Any message to the user goes here."
			'
			'Label7
			'
			Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label7.Location = New System.Drawing.Point(16, 16)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New System.Drawing.Size(128, 23)
			Me.Label7.TabIndex = 0
			Me.Label7.Text = "Device Serial No.:"
			Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'txtSN
			'
			Me.txtSN.BackColor = System.Drawing.Color.White
			Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtSN.Location = New System.Drawing.Point(152, 16)
			Me.txtSN.Name = "txtSN"
			Me.txtSN.Size = New System.Drawing.Size(240, 23)
			Me.txtSN.TabIndex = 1
			Me.txtSN.Text = ""
			'
			'nudUPQty
			'
			Me.nudUPQty.BackColor = System.Drawing.SystemColors.Control
			Me.nudUPQty.Enabled = False
			Me.nudUPQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.nudUPQty.InterceptArrowKeys = False
			Me.nudUPQty.Location = New System.Drawing.Point(8, 202)
			Me.nudUPQty.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
			Me.nudUPQty.Name = "nudUPQty"
			Me.nudUPQty.Size = New System.Drawing.Size(184, 20)
			Me.nudUPQty.TabIndex = 17
			Me.nudUPQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'nudRecQty
			'
			Me.nudRecQty.BackColor = System.Drawing.SystemColors.Control
			Me.nudRecQty.Enabled = False
			Me.nudRecQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.nudRecQty.Location = New System.Drawing.Point(8, 202)
			Me.nudRecQty.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
			Me.nudRecQty.Name = "nudRecQty"
			Me.nudRecQty.Size = New System.Drawing.Size(184, 20)
			Me.nudRecQty.TabIndex = 11
			Me.nudRecQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'nudSWQty
			'
			Me.nudSWQty.BackColor = System.Drawing.SystemColors.Control
			Me.nudSWQty.Enabled = False
			Me.nudSWQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.nudSWQty.Location = New System.Drawing.Point(8, 202)
			Me.nudSWQty.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
			Me.nudSWQty.Name = "nudSWQty"
			Me.nudSWQty.Size = New System.Drawing.Size(184, 20)
			Me.nudSWQty.TabIndex = 14
			Me.nudSWQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'pnlBoxList
			'
			Me.pnlBoxList.BackColor = System.Drawing.Color.SkyBlue
			Me.pnlBoxList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlBoxList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblListType, Me.lbBoxDevices, Me.nudBoxQty})
			Me.pnlBoxList.Location = New System.Drawing.Point(8, 184)
			Me.pnlBoxList.Name = "pnlBoxList"
			Me.pnlBoxList.Size = New System.Drawing.Size(200, 232)
			Me.pnlBoxList.TabIndex = 5
			'
			'lblListType
			'
			Me.lblListType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblListType.ForeColor = System.Drawing.Color.Blue
			Me.lblListType.Location = New System.Drawing.Point(8, 8)
			Me.lblListType.Name = "lblListType"
			Me.lblListType.Size = New System.Drawing.Size(184, 24)
			Me.lblListType.TabIndex = 0
			Me.lblListType.Text = "Incoming Box Devices"
			Me.lblListType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lbBoxDevices
			'
			Me.lbBoxDevices.BackColor = System.Drawing.SystemColors.Control
			Me.lbBoxDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lbBoxDevices.Location = New System.Drawing.Point(8, 40)
			Me.lbBoxDevices.Name = "lbBoxDevices"
			Me.lbBoxDevices.Size = New System.Drawing.Size(184, 160)
			Me.lbBoxDevices.TabIndex = 1
			'
			'btnSwitchBox
			'
			Me.btnSwitchBox.BackColor = System.Drawing.SystemColors.Control
			Me.btnSwitchBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnSwitchBox.Location = New System.Drawing.Point(672, 429)
			Me.btnSwitchBox.Name = "btnSwitchBox"
			Me.btnSwitchBox.Size = New System.Drawing.Size(160, 27)
			Me.btnSwitchBox.TabIndex = 8
			Me.btnSwitchBox.Text = "Switch to Different Box"
			'
			'Label2
			'
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.ForeColor = System.Drawing.Color.White
			Me.Label2.Location = New System.Drawing.Point(8, 424)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(440, 40)
			Me.Label2.TabIndex = 20
			Me.Label2.Text = "This screen is used for the Tracfone Software Screening process.  You will first " & _
			"select a box to work and then work the individual devices."
			'
			'pnlRecList
			'
			Me.pnlRecList.BackColor = System.Drawing.Color.SkyBlue
			Me.pnlRecList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlRecList.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.lbRecDevices, Me.nudRecQty})
			Me.pnlRecList.Location = New System.Drawing.Point(216, 184)
			Me.pnlRecList.Name = "pnlRecList"
			Me.pnlRecList.Size = New System.Drawing.Size(200, 232)
			Me.pnlRecList.TabIndex = 23
			'
			'Label1
			'
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.ForeColor = System.Drawing.Color.Blue
			Me.Label1.Location = New System.Drawing.Point(8, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(184, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Receiving Box Devices"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lbRecDevices
			'
			Me.lbRecDevices.BackColor = System.Drawing.SystemColors.Control
			Me.lbRecDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lbRecDevices.Location = New System.Drawing.Point(8, 40)
			Me.lbRecDevices.Name = "lbRecDevices"
			Me.lbRecDevices.Size = New System.Drawing.Size(184, 160)
			Me.lbRecDevices.TabIndex = 1
			'
			'pnlSWFailList
			'
			Me.pnlSWFailList.BackColor = System.Drawing.Color.SkyBlue
			Me.pnlSWFailList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlSWFailList.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.lbSWFDevices, Me.nudSWQty})
			Me.pnlSWFailList.Location = New System.Drawing.Point(424, 184)
			Me.pnlSWFailList.Name = "pnlSWFailList"
			Me.pnlSWFailList.Size = New System.Drawing.Size(200, 232)
			Me.pnlSWFailList.TabIndex = 24
			'
			'Label3
			'
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.ForeColor = System.Drawing.Color.Blue
			Me.Label3.Location = New System.Drawing.Point(8, 8)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(184, 24)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Software Fail Devices"
			Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lbSWFDevices
			'
			Me.lbSWFDevices.BackColor = System.Drawing.SystemColors.Control
			Me.lbSWFDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lbSWFDevices.Location = New System.Drawing.Point(8, 40)
			Me.lbSWFDevices.Name = "lbSWFDevices"
			Me.lbSWFDevices.Size = New System.Drawing.Size(184, 160)
			Me.lbSWFDevices.TabIndex = 1
			'
			'pnlUnPrcList
			'
			Me.pnlUnPrcList.BackColor = System.Drawing.Color.SkyBlue
			Me.pnlUnPrcList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlUnPrcList.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.lbUnPDevices, Me.nudUPQty})
			Me.pnlUnPrcList.Location = New System.Drawing.Point(632, 184)
			Me.pnlUnPrcList.Name = "pnlUnPrcList"
			Me.pnlUnPrcList.Size = New System.Drawing.Size(200, 232)
			Me.pnlUnPrcList.TabIndex = 25
			'
			'Label4
			'
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label4.ForeColor = System.Drawing.Color.Blue
			Me.Label4.Location = New System.Drawing.Point(8, 8)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(184, 24)
			Me.Label4.TabIndex = 0
			Me.Label4.Text = "Un-Processed Devices"
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lbUnPDevices
			'
			Me.lbUnPDevices.BackColor = System.Drawing.SystemColors.Control
			Me.lbUnPDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lbUnPDevices.Location = New System.Drawing.Point(8, 40)
			Me.lbUnPDevices.Name = "lbUnPDevices"
			Me.lbUnPDevices.Size = New System.Drawing.Size(184, 160)
			Me.lbUnPDevices.TabIndex = 1
			'
			'btnPrintALabel
			'
			Me.btnPrintALabel.BackColor = System.Drawing.SystemColors.Control
			Me.btnPrintALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnPrintALabel.Location = New System.Drawing.Point(464, 429)
			Me.btnPrintALabel.Name = "btnPrintALabel"
			Me.btnPrintALabel.Size = New System.Drawing.Size(192, 27)
			Me.btnPrintALabel.TabIndex = 26
			Me.btnPrintALabel.Text = "Reprint A Box Label From SN"
			'
			'TFSWScreening
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.SteelBlue
			Me.ClientSize = New System.Drawing.Size(840, 470)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintALabel, Me.pnlUnPrcList, Me.pnlSWFailList, Me.pnlRecList, Me.pnlBoxList, Me.btnSwitchBox, Me.pnlBox, Me.Label2, Me.pnlDevice})
			Me.Name = "TFSWScreening"
			Me.Text = "Tracfone Software Screening"
			Me.pnlBox.ResumeLayout(False)
			CType(Me.nudBoxQty, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlDevice.ResumeLayout(False)
			CType(Me.nudUPQty, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nudRecQty, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nudSWQty, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlBoxList.ResumeLayout(False)
			Me.pnlRecList.ResumeLayout(False)
			Me.pnlSWFailList.ResumeLayout(False)
			Me.pnlUnPrcList.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region "DECLARATIONS"

		Private Enum ListTypes
			Box
			Receiving
			SoftwareFail
			UnProcessed
		End Enum
		Private _defaultColor As Color
		Private _focusColor As Color = Color.SkyBlue
		Private _currentWS As String = "SW SCREEN"
		Private _newWS As String = ""
		Private _newWSText As String = ""
		Private _box_qty As Integer = 0
		Private _rec_qty As Integer = 0
		Private _swf_qty As Integer = 0
		Private _unp_qty As Integer = 0
		Private _box_ready_to_close As Boolean = False
        Private _dtPassedDevices As DataTable = Nothing
#End Region
#Region "FORM EVENTS"

		Private Sub TFSWScreening_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			ClearBox()
		End Sub

#End Region
#Region "CONTROL EVENTS"

		Private Sub txtBoxNr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxNr.KeyDown
            Try
                If e.KeyCode = Keys.Enter Then
                    If Misc.Triaged_Device(Me.txtBoxNr.Text) = False Then
                        MessageBox.Show("This screen does not accept any unit from NTF.", "txtBoxNr_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxNr.Text = "" : Me.txtBoxNr.Focus()
                    ElseIf IsBoxNrValid(txtBoxNr.Text) Then
                        OpenBox(txtBoxNr.Text)
                    Else
                        MessageBox.Show("The entered box number is not valid for this screen.", "txtBoxNr_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtBoxNr.Text = ""
                        txtBoxNr.Focus()
                    End If
                Else
                    ClearDevice()
                    ClearDeviceLists()
                    pnlDevice.Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtBoxNr_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Private Sub txtSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyDown
            Dim _snInBox As Boolean
            lblMsg.Text = ""
            pbCheck.Visible = False
            pbX.Visible = False
            If e.KeyCode = Keys.Enter Then
                Try
                    _snInBox = IsSNValidForBox()
                    If _snInBox Then
                        pbCheck.Visible = True
                        ShowDataPopup()
                        ClearDevice()
                        PopulateDeviceListAndCounts()
                        If IsBoxReadyToClose() Then
                            PromptToCloseBox()
                        Else
                            pnlDevice.Visible = True
                            txtSN.Focus()
                        End If
                    Else
                        pbX.Visible = True
                        lblMsg.Text = "Serial Number cannot be processed for this Box at this time."
                    End If
                Catch ex As Exception
                    pbX.Visible = True
                    lblMsg.Text = "Serial Number cannot be processed for this Box at this time."
                    MessageBox.Show("Device SN: " & txtSN.Text & " - " & ex.Message, "txtSN_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ClearDevice()
                End Try
            End If
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim _dlgr As New DialogResult()
            Dim _msg As String = "Cancel the processing of this device?"
            _dlgr = MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If _dlgr = DialogResult.Yes Then
                ClearDevice()
            End If
        End Sub

        Private Sub btnSwitchBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSwitchBox.Click
            ClearBox()
        End Sub
        Private Sub lbBox_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
         Handles lbBoxDevices.DataSourceChanged, _
         lbRecDevices.DataSourceChanged, _
         lbSWFDevices.DataSourceChanged, _
         lbUnPDevices.DataSourceChanged
            Dim ctlLIST As ListBox
            ctlLIST = sender
            If (ctlLIST.DataSource = Nothing) Then
                ctlLIST.Items.Clear()
            End If
        End Sub

        Private Sub btnPrintALabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintALabel.Click
            Dim _objTFRec As New PSS.Data.Buisness.TracFone.Receive()
            Dim _objTFMisc As New PSS.Data.Buisness.TracFone.clsMisc()
            Dim _dt As New DataTable()
            Dim _device_sn As String
            Dim _box_nr As String
            Dim _box_sw_process_flag As Boolean = False
            Try
                _device_sn = InputBox("Please scan a SERIAL NUMBER to print the associated Box Label.", Me.Text, "")
                If _device_sn <> "" Then
                    _dt = _objTFMisc.GetWIPOpenDeviceBoxID(_device_sn)
                    _box_nr = _dt.Rows(0)("box id").ToString()
                    If _box_nr <> "" Then
                        Me.Cursor = Cursors.WaitCursor
                        _objTFRec.ReprintWHBox(_box_nr)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Unable to obtain box information for this device.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                _dt.Dispose()
                Me.Cursor = Cursors.Default
            End Try
        End Sub

#End Region
#Region "PROPERTIES"

		Private ReadOnly Property IsBoxReadyToClose() As Boolean
			Get
				If _box_qty = 0 Then
					Return False
				Else
					If _rec_qty + _swf_qty = _box_qty Then
						Return True
					End If
				End If
			End Get
		End Property

		'Private ReadOnly Property RedDotEnabled() As Boolean
		'	Get
		'		Return pnlData.Visible
		'	End Get
		'End Property

		'Private ReadOnly Property ScreenableEnabled() As Boolean
		'	Get
		'		Return pnlData.Visible
		'	End Get
		'End Property

		'Private ReadOnly Property FPIssueEnabled() As Boolean
		'	Get
		'		Return pnlData.Visible AndAlso cbScreenable.Checked
		'	End Get
		'End Property

		'Private ReadOnly Property PINLockedEnabled() As Boolean
		'	Get
		'		Return pnlData.Visible AndAlso cbScreenable.Checked AndAlso cbFPIssue.Checked = False
		'	End Get
		'End Property

		'Private ReadOnly Property KSEnabledEnabled() As Boolean
		'	Get
		'		Return pnlData.Visible AndAlso cbScreenable.Checked AndAlso cbFPIssue.Checked = False
		'	End Get
		'End Property

		'Private ReadOnly Property RemovedEnabled() As Boolean
		'	Get
		'		Return pnlData.Visible AndAlso cbScreenable.Checked AndAlso cbFPIssue.Checked = False AndAlso cbKSEnabled.Checked
		'	End Get
		'End Property

#End Region
#Region "METHODS"

		Private Sub ClearBox()
			txtBoxNr.Text = ""
			lbBoxWorkers.Items.Clear()
			_box_qty = 0
			_rec_qty = 0
			_swf_qty = 0
			_unp_qty = 0
			nudBoxQty.Value = 0
			nudRecQty.Value = 0
			nudSWQty.Value = 0
			nudUPQty.Value = 0
			ClearDevice()
			ClearDeviceLists()
			pnlDevice.Visible = False
			txtBoxNr.Focus()
		End Sub
		Private Sub ClearDevice()
			' TODO: ADD FUNCTIONALITY HERE.
			txtSN.Text = ""
			pbCheck.Visible = False
			pbX.Visible = False
			lblMsg.Text = ""
			txtSN.Enabled = True
			_newWS = ""
			_newWSText = ""
		End Sub
		Private Sub ClearDeviceLists()
			lbBoxDevices.DataSource = Nothing
			lbRecDevices.DataSource = Nothing
			lbSWFDevices.DataSource = Nothing
			lbUnPDevices.DataSource = Nothing
			lbBoxDevices.DataBindings.Clear()
			lbRecDevices.DataBindings.Clear()
			lbSWFDevices.DataBindings.Clear()
			lbUnPDevices.DataBindings.Clear()
		End Sub
		Private Sub ShowDataPopup()
			Dim _frm As New TFSWScreenForDevice(txtBoxNr.Text, txtSN.Text)
			Try
				_frm.ShowDialog()
				ClearDevice()
				If IsBoxReadyToClose() Then
					PromptToCloseBox()
				Else
					txtSN.Focus()
				End If
			Catch ex As Exception
				Throw ex
			Finally
				_frm.Dispose()
				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Sub

		Private Sub OpenBox(ByVal BoxNr As String)
			PopulateBoxWorkers()
			PopulateDeviceListAndCounts()
			If IsBoxReadyToClose() Then
				PromptToCloseBox()
			Else
				pnlDevice.Visible = True
				txtSN.Focus()
			End If
		End Sub
		Private Sub PopulateBoxWorkers()
			' TODO: FINISH THIS
		End Sub
		Private Sub PopulateDeviceListAndCounts()
			Dim _box_nr As String = txtBoxNr.Text
			Dim _dt As New DataTable()
			_dt = PSS.Data.Buisness.TracFone.clsMisc.GetWBDevices(_box_nr)
			_box_qty = _dt.Rows.Count()
			lbBoxDevices.DataSource = _dt.Copy()
			lbBoxDevices.DisplayMember = "device_sn"
			lbBoxDevices.ValueMember = "device_sn"

			_dt = PSS.Data.Buisness.TracFone.clsMisc.GetWBDevicesPendingWS(_box_nr, "PRE-BUFF")
            _rec_qty = _dt.Rows.Count()
            _dtPassedDevices = _dt.Copy()
			lbRecDevices.DataSource = _dt.Copy()
			lbRecDevices.DisplayMember = "device_sn"
			lbRecDevices.ValueMember = "device_sn"

			_dt = PSS.Data.Buisness.TracFone.clsMisc.GetWBDevicesPendingWS(_box_nr, "SW FAIL")
			_swf_qty = _dt.Rows.Count()
			lbSWFDevices.DataSource = _dt.Copy()
			lbSWFDevices.DisplayMember = "device_sn"
			lbSWFDevices.ValueMember = "device_sn"

			_dt = PSS.Data.Buisness.TracFone.clsMisc.GetWBDevicesUnProcessed(_box_nr)
			_unp_qty = _dt.Rows.Count()
			lbUnPDevices.DataSource = _dt.Copy()
			lbUnPDevices.DisplayMember = "device_sn"
			lbUnPDevices.ValueMember = "device_sn"

			nudBoxQty.Value = _box_qty
			nudRecQty.Value = _rec_qty
			nudSWQty.Value = _swf_qty
			nudUPQty.Value = _unp_qty
			_dt.Dispose()
		End Sub

        Private Function IsBoxNrValid(ByVal BoxNr As String) As Boolean
            ' Validates a box is in the correct workstation.
            Dim _valid As Boolean = PSS.Data.Buisness.TracFone.clsMisc.VerifyWBHasDevicesInWS(BoxNr, 2258, "SW SCREEN")
            Return _valid

        End Function
        Private Function IsSNValidForBox() As Boolean
            ' VALIDATES SN TO PROCESS IN BOX.
            Dim _box_nr As String = txtBoxNr.Text
            Dim _sn As String = txtSN.Text
            Dim _valid As Boolean = False
            Try
                _valid = PSS.Data.Buisness.TracFone.clsMisc.IsDvcRdyToProcessForBx(_box_nr, _sn, "SW SCREEN")
                Return _valid
            Catch ex As Exception
                Throw New Exception(ex.Message)
                Return False
            End Try
        End Function
        Private Sub PromptToCloseBox()
            Dim _dr As New DialogResult()
            Dim _msg As String
            Try
                _msg = "This box is ready to close.  Would you like to close it now?"
                _dr = MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If _dr = DialogResult.Yes Then
                    CloseBox()
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        Private Sub CloseBox()
            Dim _box_nr As String = txtBoxNr.Text
            Dim _results As Boolean = False
            Dim _clsMisc As New PSS.Data.Buisness.TracFone.clsMisc()
            Dim iModel_ID As Integer = 0
            Dim row As DataRow
            Dim objTFMisc As New Data.Buisness.TracFone.clsMisc()

            _results = _clsMisc.SWScreenCloseBox(txtBoxNr.Text, _
             PSS.Core.Global.ApplicationUser.IDuser, _
             lbRecDevices.Items.Count, _
             lbSWFDevices.Items.Count)
            If _results Then
                If lbRecDevices.Items.Count > 0 Then
                    For Each row In Me._dtPassedDevices.Rows
                        iModel_ID = objTFMisc.getDeviceModelID(row("Device_ID"))
                        If Not objTFMisc.IsBuffable(iModel_ID) Then
                            objTFMisc.ResetWorkstationForNonBuffableDevice(row("Device_ID"), "WH-WIP")
                        End If
                    Next
                End If
                MessageBox.Show("This box has been closed and all the devices transfered.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearBox()
            End If
        End Sub

#End Region

	End Class

End Namespace
