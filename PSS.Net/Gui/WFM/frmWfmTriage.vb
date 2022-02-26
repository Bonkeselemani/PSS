Imports PSS.Data
Namespace Gui.WFMTracfone
	Public Class frmWfmTriage
		Inherits System.Windows.Forms.Form
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
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents Label9 As System.Windows.Forms.Label
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents Label12 As System.Windows.Forms.Label
		Friend WithEvents Label11 As System.Windows.Forms.Label
		Friend WithEvents btnAddVisual As System.Windows.Forms.Button
		Friend WithEvents btnAddSW As System.Windows.Forms.Button
		Friend WithEvents btnAddFun As System.Windows.Forms.Button
		Friend WithEvents btnAddCos As System.Windows.Forms.Button
		Friend WithEvents txtSn As System.Windows.Forms.TextBox
		Friend WithEvents txtModel As System.Windows.Forms.TextBox
		Friend WithEvents txtBox As System.Windows.Forms.TextBox
		Friend WithEvents btnIMEIHold As System.Windows.Forms.Button
		Friend WithEvents btnReset As System.Windows.Forms.Button
		Friend WithEvents Panel5 As System.Windows.Forms.Panel
		Friend WithEvents pnlVis As System.Windows.Forms.Panel
		Friend WithEvents pnlSof As System.Windows.Forms.Panel
		Friend WithEvents pnlFun As System.Windows.Forms.Panel
		Friend WithEvents pnlCos As System.Windows.Forms.Panel
		Friend WithEvents lbVis As System.Windows.Forms.ListBox
		Friend WithEvents lbSof As System.Windows.Forms.ListBox
		Friend WithEvents lbFun As System.Windows.Forms.ListBox
		Friend WithEvents lbCos As System.Windows.Forms.ListBox
		Friend WithEvents cbPassVis As System.Windows.Forms.CheckBox
		Friend WithEvents cbPassSof As System.Windows.Forms.CheckBox
		Friend WithEvents cbPassFun As System.Windows.Forms.CheckBox
		Friend WithEvents cbPassCos As System.Windows.Forms.CheckBox
		Friend WithEvents lblFcVis As System.Windows.Forms.Label
		Friend WithEvents lblFcSof As System.Windows.Forms.Label
		Friend WithEvents lblFcFun As System.Windows.Forms.Label
		Friend WithEvents lblFcCos As System.Windows.Forms.Label
		Friend WithEvents btnSave As System.Windows.Forms.Button
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents lblLastMove As System.Windows.Forms.Label
		Friend WithEvents btnResetDevice As System.Windows.Forms.Button
		Friend WithEvents Label15 As System.Windows.Forms.Label
		Friend WithEvents Label16 As System.Windows.Forms.Label
		Friend WithEvents lblTodayCnt As System.Windows.Forms.Label
		Friend WithEvents lblWeekCnt As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.pnlVis = New System.Windows.Forms.Panel()
			Me.lblFcVis = New System.Windows.Forms.Label()
			Me.cbPassVis = New System.Windows.Forms.CheckBox()
			Me.lbVis = New System.Windows.Forms.ListBox()
			Me.Label9 = New System.Windows.Forms.Label()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.btnAddVisual = New System.Windows.Forms.Button()
			Me.pnlSof = New System.Windows.Forms.Panel()
			Me.lblFcSof = New System.Windows.Forms.Label()
			Me.cbPassSof = New System.Windows.Forms.CheckBox()
			Me.lbSof = New System.Windows.Forms.ListBox()
			Me.Label10 = New System.Windows.Forms.Label()
			Me.Label6 = New System.Windows.Forms.Label()
			Me.btnAddSW = New System.Windows.Forms.Button()
			Me.pnlFun = New System.Windows.Forms.Panel()
			Me.lblFcFun = New System.Windows.Forms.Label()
			Me.cbPassFun = New System.Windows.Forms.CheckBox()
			Me.lbFun = New System.Windows.Forms.ListBox()
			Me.Label11 = New System.Windows.Forms.Label()
			Me.Label7 = New System.Windows.Forms.Label()
			Me.btnAddFun = New System.Windows.Forms.Button()
			Me.pnlCos = New System.Windows.Forms.Panel()
			Me.lblFcCos = New System.Windows.Forms.Label()
			Me.lbCos = New System.Windows.Forms.ListBox()
			Me.Label12 = New System.Windows.Forms.Label()
			Me.Label8 = New System.Windows.Forms.Label()
			Me.cbPassCos = New System.Windows.Forms.CheckBox()
			Me.btnAddCos = New System.Windows.Forms.Button()
			Me.txtSn = New System.Windows.Forms.TextBox()
			Me.txtModel = New System.Windows.Forms.TextBox()
			Me.txtBox = New System.Windows.Forms.TextBox()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.btnIMEIHold = New System.Windows.Forms.Button()
			Me.btnReset = New System.Windows.Forms.Button()
			Me.Panel5 = New System.Windows.Forms.Panel()
			Me.btnSave = New System.Windows.Forms.Button()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.lblLastMove = New System.Windows.Forms.Label()
			Me.btnResetDevice = New System.Windows.Forms.Button()
			Me.lblTodayCnt = New System.Windows.Forms.Label()
			Me.lblWeekCnt = New System.Windows.Forms.Label()
			Me.Label15 = New System.Windows.Forms.Label()
			Me.Label16 = New System.Windows.Forms.Label()
			Me.pnlVis.SuspendLayout()
			Me.pnlSof.SuspendLayout()
			Me.pnlFun.SuspendLayout()
			Me.pnlCos.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.SuspendLayout()
			'
			'Label3
			'
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.Location = New System.Drawing.Point(24, 512)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(672, 24)
			Me.Label3.TabIndex = 13
			Me.Label3.Text = "This screen is used to triage individual devices into a status of FUN, SOF, COS, " & _
			"NTF or IMEI Hold."
			'
			'pnlVis
			'
			Me.pnlVis.BackColor = System.Drawing.Color.Silver
			Me.pnlVis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlVis.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFcVis, Me.cbPassVis, Me.lbVis, Me.Label9, Me.Label5})
			Me.pnlVis.Location = New System.Drawing.Point(16, 8)
			Me.pnlVis.Name = "pnlVis"
			Me.pnlVis.Size = New System.Drawing.Size(224, 360)
			Me.pnlVis.TabIndex = 0
			'
			'lblFcVis
			'
			Me.lblFcVis.BackColor = System.Drawing.Color.Yellow
			Me.lblFcVis.Location = New System.Drawing.Point(128, 24)
			Me.lblFcVis.Name = "lblFcVis"
			Me.lblFcVis.Size = New System.Drawing.Size(40, 23)
			Me.lblFcVis.TabIndex = 2
			Me.lblFcVis.Visible = False
			'
			'cbPassVis
			'
			Me.cbPassVis.Appearance = System.Windows.Forms.Appearance.Button
			Me.cbPassVis.BackColor = System.Drawing.SystemColors.Control
			Me.cbPassVis.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
			Me.cbPassVis.Location = New System.Drawing.Point(56, 24)
			Me.cbPassVis.Name = "cbPassVis"
			Me.cbPassVis.Size = New System.Drawing.Size(64, 24)
			Me.cbPassVis.TabIndex = 1
			Me.cbPassVis.Text = "PASS"
			Me.cbPassVis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lbVis
			'
			Me.lbVis.Location = New System.Drawing.Point(0, 72)
			Me.lbVis.Name = "lbVis"
			Me.lbVis.Size = New System.Drawing.Size(224, 277)
			Me.lbVis.TabIndex = 4
			'
			'Label9
			'
			Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label9.ForeColor = System.Drawing.Color.Red
			Me.Label9.Location = New System.Drawing.Point(6, 56)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New System.Drawing.Size(162, 16)
			Me.Label9.TabIndex = 3
			Me.Label9.Text = "FAIL - FUN"
			'
			'Label5
			'
			Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label5.Location = New System.Drawing.Point(8, 0)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(216, 23)
			Me.Label5.TabIndex = 0
			Me.Label5.Text = "Visual Inspection"
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnAddVisual
			'
			Me.btnAddVisual.BackColor = System.Drawing.SystemColors.Control
			Me.btnAddVisual.Location = New System.Drawing.Point(200, 104)
			Me.btnAddVisual.Name = "btnAddVisual"
			Me.btnAddVisual.Size = New System.Drawing.Size(32, 24)
			Me.btnAddVisual.TabIndex = 8
			Me.btnAddVisual.Text = "..."
			Me.btnAddVisual.Visible = False
			'
			'pnlSof
			'
			Me.pnlSof.BackColor = System.Drawing.Color.Silver
			Me.pnlSof.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlSof.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFcSof, Me.cbPassSof, Me.lbSof, Me.Label10, Me.Label6})
			Me.pnlSof.Location = New System.Drawing.Point(248, 8)
			Me.pnlSof.Name = "pnlSof"
			Me.pnlSof.Size = New System.Drawing.Size(224, 360)
			Me.pnlSof.TabIndex = 1
			'
			'lblFcSof
			'
			Me.lblFcSof.BackColor = System.Drawing.Color.Yellow
			Me.lblFcSof.Location = New System.Drawing.Point(128, 24)
			Me.lblFcSof.Name = "lblFcSof"
			Me.lblFcSof.Size = New System.Drawing.Size(40, 23)
			Me.lblFcSof.TabIndex = 2
			Me.lblFcSof.Visible = False
			'
			'cbPassSof
			'
			Me.cbPassSof.Appearance = System.Windows.Forms.Appearance.Button
			Me.cbPassSof.BackColor = System.Drawing.SystemColors.Control
			Me.cbPassSof.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
			Me.cbPassSof.Location = New System.Drawing.Point(56, 24)
			Me.cbPassSof.Name = "cbPassSof"
			Me.cbPassSof.Size = New System.Drawing.Size(64, 24)
			Me.cbPassSof.TabIndex = 1
			Me.cbPassSof.Text = "PASS"
			Me.cbPassSof.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lbSof
			'
			Me.lbSof.Location = New System.Drawing.Point(-1, 72)
			Me.lbSof.Name = "lbSof"
			Me.lbSof.Size = New System.Drawing.Size(225, 277)
			Me.lbSof.TabIndex = 4
			'
			'Label10
			'
			Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label10.ForeColor = System.Drawing.Color.Red
			Me.Label10.Location = New System.Drawing.Point(6, 56)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New System.Drawing.Size(162, 16)
			Me.Label10.TabIndex = 3
			Me.Label10.Text = "FAIL - SOF"
			'
			'Label6
			'
			Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label6.Location = New System.Drawing.Point(8, 0)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(216, 23)
			Me.Label6.TabIndex = 0
			Me.Label6.Text = "Software Inspection"
			Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnAddSW
			'
			Me.btnAddSW.BackColor = System.Drawing.SystemColors.Control
			Me.btnAddSW.Location = New System.Drawing.Point(432, 104)
			Me.btnAddSW.Name = "btnAddSW"
			Me.btnAddSW.Size = New System.Drawing.Size(32, 24)
			Me.btnAddSW.TabIndex = 9
			Me.btnAddSW.Text = "..."
			Me.btnAddSW.Visible = False
			'
			'pnlFun
			'
			Me.pnlFun.BackColor = System.Drawing.Color.Silver
			Me.pnlFun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlFun.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFcFun, Me.cbPassFun, Me.lbFun, Me.Label11, Me.Label7})
			Me.pnlFun.Location = New System.Drawing.Point(480, 8)
			Me.pnlFun.Name = "pnlFun"
			Me.pnlFun.Size = New System.Drawing.Size(224, 360)
			Me.pnlFun.TabIndex = 2
			'
			'lblFcFun
			'
			Me.lblFcFun.BackColor = System.Drawing.Color.Yellow
			Me.lblFcFun.Location = New System.Drawing.Point(128, 24)
			Me.lblFcFun.Name = "lblFcFun"
			Me.lblFcFun.Size = New System.Drawing.Size(40, 23)
			Me.lblFcFun.TabIndex = 2
			Me.lblFcFun.Visible = False
			'
			'cbPassFun
			'
			Me.cbPassFun.Appearance = System.Windows.Forms.Appearance.Button
			Me.cbPassFun.BackColor = System.Drawing.SystemColors.Control
			Me.cbPassFun.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
			Me.cbPassFun.Location = New System.Drawing.Point(56, 24)
			Me.cbPassFun.Name = "cbPassFun"
			Me.cbPassFun.Size = New System.Drawing.Size(64, 24)
			Me.cbPassFun.TabIndex = 1
			Me.cbPassFun.Text = "PASS"
			Me.cbPassFun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lbFun
			'
			Me.lbFun.Location = New System.Drawing.Point(-1, 72)
			Me.lbFun.Name = "lbFun"
			Me.lbFun.Size = New System.Drawing.Size(225, 277)
			Me.lbFun.TabIndex = 4
			'
			'Label11
			'
			Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label11.ForeColor = System.Drawing.Color.Red
			Me.Label11.Location = New System.Drawing.Point(6, 56)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New System.Drawing.Size(162, 16)
			Me.Label11.TabIndex = 3
			Me.Label11.Text = "FAIL - FUN"
			'
			'Label7
			'
			Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label7.Location = New System.Drawing.Point(6, 0)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New System.Drawing.Size(218, 23)
			Me.Label7.TabIndex = 0
			Me.Label7.Text = "Functional Inspection"
			Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnAddFun
			'
			Me.btnAddFun.BackColor = System.Drawing.SystemColors.Control
			Me.btnAddFun.Location = New System.Drawing.Point(664, 104)
			Me.btnAddFun.Name = "btnAddFun"
			Me.btnAddFun.Size = New System.Drawing.Size(32, 24)
			Me.btnAddFun.TabIndex = 10
			Me.btnAddFun.Text = "..."
			Me.btnAddFun.Visible = False
			'
			'pnlCos
			'
			Me.pnlCos.BackColor = System.Drawing.Color.Silver
			Me.pnlCos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlCos.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFcCos, Me.lbCos, Me.Label12, Me.Label8, Me.cbPassCos})
			Me.pnlCos.Location = New System.Drawing.Point(712, 8)
			Me.pnlCos.Name = "pnlCos"
			Me.pnlCos.Size = New System.Drawing.Size(224, 360)
			Me.pnlCos.TabIndex = 3
			'
			'lblFcCos
			'
			Me.lblFcCos.BackColor = System.Drawing.Color.Yellow
			Me.lblFcCos.Location = New System.Drawing.Point(128, 24)
			Me.lblFcCos.Name = "lblFcCos"
			Me.lblFcCos.Size = New System.Drawing.Size(40, 23)
			Me.lblFcCos.TabIndex = 2
			Me.lblFcCos.Visible = False
			'
			'lbCos
			'
			Me.lbCos.Location = New System.Drawing.Point(-1, 72)
			Me.lbCos.Name = "lbCos"
			Me.lbCos.Size = New System.Drawing.Size(225, 277)
			Me.lbCos.TabIndex = 4
			'
			'Label12
			'
			Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label12.ForeColor = System.Drawing.Color.Red
			Me.Label12.Location = New System.Drawing.Point(6, 56)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New System.Drawing.Size(162, 16)
			Me.Label12.TabIndex = 3
			Me.Label12.Text = "FAIL COS"
			'
			'Label8
			'
			Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label8.Location = New System.Drawing.Point(6, 0)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New System.Drawing.Size(218, 23)
			Me.Label8.TabIndex = 0
			Me.Label8.Text = "Cosmetic Inspection"
			Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'cbPassCos
			'
			Me.cbPassCos.Appearance = System.Windows.Forms.Appearance.Button
			Me.cbPassCos.BackColor = System.Drawing.SystemColors.Control
			Me.cbPassCos.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
			Me.cbPassCos.Location = New System.Drawing.Point(56, 24)
			Me.cbPassCos.Name = "cbPassCos"
			Me.cbPassCos.Size = New System.Drawing.Size(64, 24)
			Me.cbPassCos.TabIndex = 1
			Me.cbPassCos.Text = "PASS"
			Me.cbPassCos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnAddCos
			'
			Me.btnAddCos.BackColor = System.Drawing.SystemColors.Control
			Me.btnAddCos.Location = New System.Drawing.Point(896, 104)
			Me.btnAddCos.Name = "btnAddCos"
			Me.btnAddCos.Size = New System.Drawing.Size(32, 24)
			Me.btnAddCos.TabIndex = 11
			Me.btnAddCos.Text = "..."
			Me.btnAddCos.Visible = False
			'
			'txtSn
			'
			Me.txtSn.Location = New System.Drawing.Point(16, 40)
			Me.txtSn.Name = "txtSn"
			Me.txtSn.Size = New System.Drawing.Size(224, 20)
			Me.txtSn.TabIndex = 2
			Me.txtSn.Text = ""
			'
			'txtModel
			'
			Me.txtModel.BackColor = System.Drawing.Color.Gainsboro
			Me.txtModel.Location = New System.Drawing.Point(264, 40)
			Me.txtModel.Name = "txtModel"
			Me.txtModel.ReadOnly = True
			Me.txtModel.Size = New System.Drawing.Size(224, 20)
			Me.txtModel.TabIndex = 4
			Me.txtModel.Text = ""
			'
			'txtBox
			'
			Me.txtBox.BackColor = System.Drawing.Color.Gainsboro
			Me.txtBox.Location = New System.Drawing.Point(512, 40)
			Me.txtBox.Name = "txtBox"
			Me.txtBox.ReadOnly = True
			Me.txtBox.Size = New System.Drawing.Size(224, 20)
			Me.txtBox.TabIndex = 6
			Me.txtBox.Text = ""
			'
			'Label1
			'
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.Location = New System.Drawing.Point(16, 16)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(160, 23)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "IMEI"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'Label2
			'
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.Location = New System.Drawing.Point(264, 16)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(224, 23)
			Me.Label2.TabIndex = 3
			Me.Label2.Text = "Model"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'Label4
			'
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label4.Location = New System.Drawing.Point(512, 16)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(224, 23)
			Me.Label4.TabIndex = 5
			Me.Label4.Text = "Box ID"
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'btnIMEIHold
			'
			Me.btnIMEIHold.Enabled = False
			Me.btnIMEIHold.Location = New System.Drawing.Point(16, 456)
			Me.btnIMEIHold.Name = "btnIMEIHold"
			Me.btnIMEIHold.Size = New System.Drawing.Size(88, 32)
			Me.btnIMEIHold.TabIndex = 12
			Me.btnIMEIHold.Text = "IMEI Hold"
			'
			'btnReset
			'
			Me.btnReset.Enabled = False
			Me.btnReset.Location = New System.Drawing.Point(736, 456)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New System.Drawing.Size(88, 32)
			Me.btnReset.TabIndex = 14
			Me.btnReset.Text = "RESET"
			'
			'Panel5
			'
			Me.Panel5.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlCos, Me.pnlFun, Me.pnlSof, Me.pnlVis})
			Me.Panel5.Location = New System.Drawing.Point(0, 72)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New System.Drawing.Size(944, 376)
			Me.Panel5.TabIndex = 7
			'
			'btnSave
			'
			Me.btnSave.Location = New System.Drawing.Point(848, 456)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New System.Drawing.Size(88, 32)
			Me.btnSave.TabIndex = 15
			Me.btnSave.Text = "SAVE (F5)"
			'
			'btnClear
			'
			Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnClear.Location = New System.Drawing.Point(192, 16)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(48, 21)
			Me.btnClear.TabIndex = 1
			Me.btnClear.Text = "Clear"
			'
			'lblLastMove
			'
			Me.lblLastMove.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
			Me.lblLastMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblLastMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblLastMove.ForeColor = System.Drawing.Color.Black
			Me.lblLastMove.Location = New System.Drawing.Point(432, 456)
			Me.lblLastMove.Name = "lblLastMove"
			Me.lblLastMove.Size = New System.Drawing.Size(88, 32)
			Me.lblLastMove.TabIndex = 16
			Me.lblLastMove.Text = "NTF"
			Me.lblLastMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnResetDevice
			'
			Me.btnResetDevice.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
			Me.btnResetDevice.Location = New System.Drawing.Point(136, 456)
			Me.btnResetDevice.Name = "btnResetDevice"
			Me.btnResetDevice.Size = New System.Drawing.Size(208, 32)
			Me.btnResetDevice.TabIndex = 17
			Me.btnResetDevice.Text = "Reset a device back to Triage"
			Me.btnResetDevice.Visible = False
			'
			'lblTodayCnt
			'
			Me.lblTodayCnt.BackColor = System.Drawing.Color.Black
			Me.lblTodayCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblTodayCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblTodayCnt.ForeColor = System.Drawing.Color.Yellow
			Me.lblTodayCnt.Location = New System.Drawing.Point(752, 32)
			Me.lblTodayCnt.Name = "lblTodayCnt"
			Me.lblTodayCnt.Size = New System.Drawing.Size(88, 32)
			Me.lblTodayCnt.TabIndex = 18
			Me.lblTodayCnt.Text = "0"
			Me.lblTodayCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblWeekCnt
			'
			Me.lblWeekCnt.BackColor = System.Drawing.Color.Black
			Me.lblWeekCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblWeekCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblWeekCnt.ForeColor = System.Drawing.Color.Yellow
			Me.lblWeekCnt.Location = New System.Drawing.Point(848, 32)
			Me.lblWeekCnt.Name = "lblWeekCnt"
			Me.lblWeekCnt.Size = New System.Drawing.Size(88, 32)
			Me.lblWeekCnt.TabIndex = 19
			Me.lblWeekCnt.Text = "0"
			Me.lblWeekCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'Label15
			'
			Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label15.Location = New System.Drawing.Point(752, 8)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New System.Drawing.Size(88, 23)
			Me.Label15.TabIndex = 20
			Me.Label15.Text = "Today"
			Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'Label16
			'
			Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label16.Location = New System.Drawing.Point(848, 8)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New System.Drawing.Size(88, 23)
			Me.Label16.TabIndex = 21
			Me.Label16.Text = "This Week"
			Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'frmWfmTriage
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(944, 534)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label16, Me.Label15, Me.lblWeekCnt, Me.lblTodayCnt, Me.btnAddVisual, Me.btnAddSW, Me.btnAddFun, Me.btnAddCos, Me.btnResetDevice, Me.lblLastMove, Me.btnClear, Me.btnSave, Me.Panel5, Me.btnReset, Me.btnIMEIHold, Me.Label4, Me.Label2, Me.Label1, Me.txtBox, Me.txtModel, Me.txtSn, Me.Label3})
			Me.Name = "frmWfmTriage"
			Me.Text = "WFM Triage"
			Me.pnlVis.ResumeLayout(False)
			Me.pnlSof.ResumeLayout(False)
			Me.pnlFun.ResumeLayout(False)
			Me.pnlCos.ResumeLayout(False)
			Me.Panel5.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"
		' Customer Name is "WFM (TF)"
		Private _cust_id = 2597		  ' CUSTOMER ID
		Private _loc_id = 3402		  ' LOCATION ID
		Private _user_id As Integer		 ' CURRENT USER ID
		Private _prod_id = 2		  ' PRODUCT ID
		Private _cpl_id = 10		  ' CUSTOMER PRODUCT LOCATION.
		Private _cc_id As Integer = 0	   ' COMPUTER COST CENTER.
		Private _tdevice_ro As BOL.tDevice_ByWS_Readonly
		Private _tdevice As BOL.tDevice
		Private _failCode As Integer = 0
		Private Enum FailCodeTypes
			Visual = 1
			Software = 2
			Functional = 3
			Cosmetic = 4
		End Enum
#End Region
#Region "CONSTRUCTORS"
		Public Sub New()
			MyBase.New()
			InitializeComponent()
		End Sub
#End Region
#Region "FORM EVENTS"
		Private Sub frmWfmTriage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			_cust_id = 2597
			_user_id = PSS.Core.ApplicationUser.IDuser
			Dim _hold_cust_id As Integer = _cust_id
			Try
				_cc_id = get_cc_id()
				PostLastMove("")
				LoadAdminButtons()
				LoadVISGrid()
				LoadSOFGrid()
				LoadFUNGrid()
				LoadCOSGrid()
				GetStats()
				EnableControls()
				txtSn.Focus()
			Catch ex As Exception
				Me.Close()
				Throw New Exception("Unable to load the " & Me.Name & " form." & _
				 vbCrLf & vbCrLf & ex.Message)
			End Try
		End Sub
		Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
			Select Case keyData
				Case Keys.F5
					If btnSave.Enabled Then
						btnSave_Click(Nothing, Nothing)
					End If
				Case Else
					Return MyBase.ProcessCmdKey(msg, keyData)
			End Select
			Return True
		End Function
#End Region
#Region "CONTROL EVENTS"
		Private Sub btnAddVisual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddVisual.Click
			Try
				If AddNewListValue(FailCodeTypes.Visual) Then
					LoadVISGrid()
					MessageBox.Show("The new value has been added.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub
		Private Sub btnAddSW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSW.Click
			Try
				If AddNewListValue(FailCodeTypes.Software) Then
					LoadSOFGrid()
					MessageBox.Show("The new value has been added.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub
		Private Sub btnAddFun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFun.Click
			Try
				If AddNewListValue(FailCodeTypes.Functional) Then
					LoadFUNGrid()
					MessageBox.Show("The new value has been added.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub
		Private Sub btnAddCos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCos.Click
			Try
				If AddNewListValue(FailCodeTypes.Cosmetic) Then
					LoadCOSGrid()
					MessageBox.Show("The new value has been added.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub
		Private Sub btnIMEIHold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIMEIHold.Click
			Dim _msg As String = "Would you like to move this device to IMEI Hold?"
			If MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
				MoveToIMEIHold()
				GetStats()
			End If
		End Sub
		Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
			ResetResults()
		End Sub
		Private Sub txtSn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSn.KeyDown
			If e.KeyCode = Keys.Enter Then
				PostLastMove("")
				Dim _sn As String = txtSn.Text
				If _sn = "" Then Exit Sub
				Dim _device_id As Integer = 0
				Me.Cursor = Cursors.WaitCursor
				_device_id = SearchForSN()
				If _device_id > 0 Then
					' MAKE SURE THE DEVICE HAS NOT BEEN TRIAGED ALREADY.
					If IsDeviceTriaged(_device_id) Then
						ResetAll()
						MessageBox.Show("This device has already been triaged.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						_tdevice = New BOL.tDevice(_device_id)
					End If
				Else
					MessageBox.Show("The Serial Number " & _sn & " has not been allocated to Triage.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					ResetAll()
				End If
				EnableControls()
				Me.Cursor = Cursors.Default
			End If
		End Sub
		Private Sub cbPassVis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPassVis.CheckedChanged
			If cbPassVis.Checked Then
				lblFcVis.Text = "0"
			End If
			EnableControls()
		End Sub
		Private Sub cbPassSof_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPassSof.CheckedChanged
			If cbPassSof.Checked Then
				lblFcSof.Text = "0"
			End If
			EnableControls()
		End Sub
		Private Sub cbPassFun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPassFun.CheckedChanged
			If cbPassFun.Checked Then
				lblFcFun.Text = "0"
			End If
			EnableControls()
		End Sub
		Private Sub cbPassCos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPassCos.CheckedChanged
			If cbPassCos.Checked Then
				lblFcCos.Text = "0"
			End If
			EnableControls()
		End Sub
		Private Sub lbVis_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVis.SelectedValueChanged
			If lbVis.SelectedValue Is Nothing Then
				Exit Sub
			ElseIf lbVis.SelectedValue > 0 Then
				_failCode = lbVis.SelectedValue
				lblFcVis.Text = lbVis.SelectedValue.ToString()
			End If
			EnableControls()
		End Sub
		Private Sub lbSof_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSof.SelectedValueChanged
			If lbSof.SelectedValue Is Nothing Then
				Exit Sub
			ElseIf lbSof.SelectedValue > 0 Then
				_failCode = lbSof.SelectedValue
				lblFcSof.Text = lbSof.SelectedValue.ToString()
			End If
			EnableControls()
		End Sub
		Private Sub lbFun_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFun.SelectedValueChanged
			If lbFun.SelectedValue Is Nothing Then
				Exit Sub
			ElseIf lbFun.SelectedValue > 0 Then
				_failCode = lbFun.SelectedValue
				lblFcFun.Text = lbFun.SelectedValue.ToString()
			End If
			EnableControls()
		End Sub
		Private Sub lbCos_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbCos.SelectedValueChanged
			If lbCos.SelectedValue Is Nothing Then
				Exit Sub
			ElseIf lbCos.SelectedValue > 0 Then
				_failCode = lbCos.SelectedValue
				lblFcCos.Text = lbCos.SelectedValue.ToString()
			End If
			EnableControls()
		End Sub
		Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
			Try
				SaveTheRecord()
				GetStats()
				ResetAll()
			Catch ex As Exception
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			ResetAll()
		End Sub
		Private Sub btnResetDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetDevice.Click
			Dim _frm As New frmWFMSetDeviceBackToTriage()
			_frm.ShowDialog()
			GetStats()
		End Sub
#End Region
#Region "PROPERTIES"
		Private ReadOnly Property TodayStart() As DateTime
			Get
				Return Date.Now.Date()
			End Get
		End Property
		Private ReadOnly Property TodayEnd() As DateTime
			Get
				Return Date.Now.Date().AddDays(1).AddSeconds(-1)
			End Get
		End Property
		Private ReadOnly Property WeekStart() As DateTime
			Get
				Dim _now As DateTime = Date.Now
				Dim _wkStart As DateTime
				Dim _negDays As Integer = _now.DayOfWeek - 1
				If _now.DayOfWeek = DayOfWeek.Sunday Then
					_wkStart = _now.Date.AddDays(-6)
				Else
					_wkStart = _now.Date.AddDays(-_negDays)
				End If
				Return _wkStart
			End Get
		End Property
		Private ReadOnly Property WeekEnd()
			Get
				Dim _wkEnd As DateTime = WeekStart.Date.AddDays(7).AddSeconds(-1)
				Return _wkEnd
			End Get
		End Property
#End Region
#Region "METHODS"
		Private Sub LoadAdminButtons()
			Dim _sec As New Data.Buisness.Security()
			If _sec.DoesUserHaveSpecialPerm(_user_id, "WFM Admin") Then
				Me.btnAddVisual.Visible = True
				Me.btnAddSW.Visible = True
				Me.btnAddFun.Visible = True
				Me.btnAddCos.Visible = True
				''' PENDING TODD'S TESTING. 
				btnResetDevice.Visible = True
			End If
			_sec = Nothing
		End Sub
		Private Sub EnableControls()
			pnlVis.Enabled = (txtSn.Text <> "" AndAlso lblFcVis.Text = "")
			pnlSof.Enabled = (txtSn.Text <> "" AndAlso lblFcSof.Text = "" AndAlso lblFcVis.Text = "0")
			pnlFun.Enabled = (txtSn.Text <> "" AndAlso lblFcFun.Text = "" AndAlso lblFcSof.Text = "0")
			pnlCos.Enabled = (txtSn.Text <> "" AndAlso lblFcCos.Text = "" AndAlso lblFcFun.Text = "0")
			btnReset.Enabled = txtSn.Text <> ""
			Select Case lblFcVis.Text
				Case "" : pnlVis.BackColor = IIf(pnlVis.Enabled, SystemColors.Control, SystemColors.ControlDark)
				Case "0" : pnlVis.BackColor = Color.Honeydew
				Case Else : pnlVis.BackColor = Color.Lavender
			End Select
			Select Case lblFcSof.Text
				Case "" : pnlSof.BackColor = IIf(pnlSof.Enabled, SystemColors.Control, SystemColors.ControlDark)
				Case "0" : pnlSof.BackColor = Color.Honeydew
				Case Else : pnlSof.BackColor = Color.Lavender
			End Select
			Select Case lblFcFun.Text
				Case "" : pnlFun.BackColor = IIf(pnlFun.Enabled, SystemColors.Control, SystemColors.ControlDark)
				Case "0" : pnlFun.BackColor = Color.Honeydew
				Case Else : pnlFun.BackColor = Color.Lavender
			End Select
			Select Case lblFcCos.Text
				Case "" : pnlCos.BackColor = IIf(pnlCos.Enabled, SystemColors.Control, SystemColors.ControlDark)
				Case "0" : pnlCos.BackColor = Color.Honeydew
				Case Else : pnlCos.BackColor = Color.Lavender
			End Select
			btnSave.Enabled = (_failCode > 0 OrElse cbPassCos.Checked = True)
			lblLastMove.Visible = lblLastMove.Text <> ""
		End Sub
		Private Sub LoadVISGrid()
			Dim _dt As New DataTable()
			Dim _lb As ListBox = lbVis
			Dim _col As New BOL.tcustproductfailcodesCollection(_cust_id, _prod_id, FailCodeTypes.Visual)
			_dt = _col.tcustproductfailcodesDataTable.Copy
			_col = Nothing
			AddSelectOneRowToDt(_dt)
			_lb.DisplayMember = "fc_desc"
			_lb.ValueMember = "fc_id"
			_lb.DataSource = _dt
		End Sub
		Private Sub LoadSOFGrid()
			Dim _dt As New DataTable()
			Dim _lb As ListBox = lbSof
			Dim _col As New BOL.tcustproductfailcodesCollection(_cust_id, _prod_id, FailCodeTypes.Software)
			_dt = _col.tcustproductfailcodesDataTable.Copy
			_col = Nothing
			AddSelectOneRowToDt(_dt)
			_lb.DisplayMember = "fc_desc"
			_lb.ValueMember = "fc_id"
			_lb.DataSource = _dt
		End Sub
		Private Sub LoadFUNGrid()
			Dim _dt As New DataTable()
			Dim _lb As ListBox = lbFun
			Dim _col As New BOL.tcustproductfailcodesCollection(_cust_id, _prod_id, FailCodeTypes.Functional)
			_dt = _col.tcustproductfailcodesDataTable.Copy
			_col = Nothing
			AddSelectOneRowToDt(_dt)
			_lb.DisplayMember = "fc_desc"
			_lb.ValueMember = "fc_id"
			_lb.DataSource = _dt
		End Sub
		Private Sub LoadCOSGrid()
			Dim _dt As New DataTable()
			Dim _lb As ListBox = lbCos
			Dim _col As New BOL.tcustproductfailcodesCollection(_cust_id, _prod_id, FailCodeTypes.Cosmetic)
			_dt = _col.tcustproductfailcodesDataTable.Copy
			_col = Nothing
			AddSelectOneRowToDt(_dt)
			_lb.DisplayMember = "fc_desc"
			_lb.ValueMember = "fc_id"
			_lb.DataSource = _dt
		End Sub
		Private Function AddNewListValue(ByVal FailCodeTypes As FailCodeTypes) As Boolean
			Dim _prompt As String = "Please enter the new value to be added."
			Dim _newValue As String = ""
			Dim _retVal As String = False
			Try
				_newValue = InputBox(_prompt, Me.Text)
				If _newValue <> "" Then
					Dim _fc As New BLL.RefTables.FailCodes(PSS.Core.ApplicationUser.IDuser)
					_retVal = _fc.AddNewFailCode(_cust_id, _prod_id, _
					FailCodeTypes, _newValue)
				End If
				Return _retVal
			Catch ex As Exception
				Throw ex
			End Try
		End Function
		Private Function AddSelectOneRowToDt(ByRef dt As DataTable) As DataTable
			Dim _dr As DataRow
			_dr = dt.NewRow()
			_dr("fc_id") = 0
			_dr("fc_desc") = "(Select One)"
			dt.Rows.InsertAt(_dr, 0)
			dt.AcceptChanges()
			Return dt
		End Function
		Private Sub ClearAllFailCodes()
			lblFcVis.Text = ""
			lblFcSof.Text = ""
			lblFcFun.Text = ""
			lblFcCos.Text = ""
			EnableControls()
		End Sub
		Private Function SearchForSN() As Integer
			Dim _device_id As Integer = 0
			_tdevice_ro = New BOL.tDevice_ByWS_Readonly(_cust_id, txtSn.Text, "Triage")
			If _tdevice_ro.Device_ID > 0 Then
				_device_id = _tdevice_ro.Device_ID
				txtModel.Text = _tdevice_ro.Model_Desc
				txtBox.Text = _tdevice_ro.Box_na
			Else
				_tdevice_ro = Nothing
			End If
			Return _device_id
		End Function
		Private Function IsDeviceTriaged(ByVal device_id As Integer) As Boolean
			Dim _retVal As Boolean = False
			Dim _dt_id As Integer = 0
			Dim _dvt As New BOL.tdevice_triage(device_id)
			If _dvt.dt_id > 0 Then
				_retVal = True
			End If
			_dvt = Nothing
			Return _retVal
		End Function
		Private Sub MoveToIMEIHold()
			' TODO: FINISH THIS.
			ResetAll()
		End Sub
		Private Sub ResetResults()
			cbPassVis.Checked = False
			cbPassSof.Checked = False
			cbPassFun.Checked = False
			cbPassCos.Checked = False
			lblFcVis.Text = ""
			lblFcSof.Text = ""
			lblFcFun.Text = ""
			lblFcCos.Text = ""
			_failCode = 0
			lbVis.SelectedIndex = 0
			lbSof.SelectedIndex = 0
			lbFun.SelectedIndex = 0
			lbCos.SelectedIndex = 0
			EnableControls()
		End Sub
		Private Sub ResetAll()
			_tdevice = Nothing
			_tdevice_ro = Nothing
			txtSn.Text = ""
			txtModel.Text = ""
			txtBox.Text = ""
			ResetResults()
			txtSn.Focus()
		End Sub
		Private Function GetDispID(ByVal failcode_id As Integer) As Integer
			Dim _disp_id As Integer = 0
			If failcode_id = 0 Then
				_disp_id = 5
			Else
				Dim _fc As New BOL.tFailCodes(failcode_id)
				Dim _fct_id As Integer
				_fct_id = _fc.fct_id
				_fc = Nothing
				Dim _fct As New BOL.tFailCodeType(_fct_id)
				_disp_id = _fct.disp_id
				_fct = Nothing
			End If
			Return _disp_id
		End Function
		Private Function GetTargetLoc(ByVal cpl_id As Integer, ByVal disp_id As Integer) As String
			Dim _retVal As String = ""
			Dim _disp As New Data.BOL.tdispositions(disp_id)
			_retVal = _disp.disp_cd
			Return _retVal
		End Function
		Private Sub SaveTheRecord()
			Dim _dm As New BLL.DeviceMovement(_user_id)
			Dim _disp_id As Integer = 0
			Dim _targetLoc As String = ""
			Dim _cpl_id_to As Integer = _dm.GetNextLocID(_cpl_id)
			_disp_id = GetDispID(_failCode)
			_targetLoc = GetTargetLoc(_cpl_id, _disp_id)
			' CREATE THE TRIAGE RECORD.
			Dim _dvt As New BOL.tdevice_triage()
			_dvt.device_id = _tdevice.Device_ID
			_dvt.fc_id = _failCode
			_dvt.disp_id = _disp_id
			_dvt.whb_id_incoming = _tdevice_ro.WHB_ID
			_dvt.crt_user_id = _user_id
			If _dvt.IsValid Then
				_dvt.ApplyChanges()
				' REMOVE DEVICES FROM THE BOX.
				Dim _wfmd As New BLL.WFMDevice()
				_wfmd.RemoveDeviceFromBox(_dvt.device_id, _dvt.whb_id_incoming)
				_wfmd = Nothing
				' ASSIGN THE COST CENTER TO THE DEVICE.
				Dim _acc As New PSS.Data.Production.AssignCostCenter()
				_acc.AssignCostCenterToUnit(_tdevice.Device_ID, _cc_id, _prod_id)
				' MOVE DEVICE TO NEW LOCATION.
				_dm.MoveDeviceToLoc(_tdevice.Device_ID, _cpl_id_to)
				PostLastMove(_targetLoc)
				EnableControls()
			Else
				Throw New Exception("Incomplete information to save the record.")
			End If
		End Sub
		Private Sub PostLastMove(ByVal msg As String)
			lblLastMove.Text = msg
		End Sub
		Private Sub GetStats()
			Dim _TodayCnt As Integer = 0
			Dim _WeekCnt As Integer = 0
			Dim _wfmRep As New Data.BLL.WFMReporting()
			_TodayCnt = _wfmRep.GetTriageCountByUser(TodayStart, TodayEnd, PSS.Core.ApplicationUser.IDuser)
			_WeekCnt = _wfmRep.GetTriageCountByUser(WeekStart, WeekEnd, PSS.Core.ApplicationUser.IDuser)
			lblTodayCnt.Text = _TodayCnt.ToString
			lblWeekCnt.Text = _WeekCnt.ToString()
		End Sub
		Private Function get_cc_id() As Integer
			Dim _retVal As Integer = 0
			Dim _dt As New DataTable()
			Dim _misc As New Data.Buisness.Misc()
			_dt = _misc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
			If _dt.Rows.Count = 0 Then
				_retVal = 0
			Else
				_retVal = _dt.Rows(0)("cc_id")
			End If
			_misc = Nothing
			_dt = Nothing
			Return _retVal
		End Function
#End Region
	End Class
End Namespace
