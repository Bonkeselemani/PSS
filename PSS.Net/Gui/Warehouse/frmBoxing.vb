Imports System.Data
Namespace Gui.Warehouse
	Public Class frmBoxing
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
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents btnCloseBox As System.Windows.Forms.Button
		Friend WithEvents txtSN As System.Windows.Forms.TextBox
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents btnRemoveItem As System.Windows.Forms.Button
		Private WithEvents cboModel As System.Windows.Forms.ComboBox
		Friend WithEvents lbValidPrefix As System.Windows.Forms.ListBox
		Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents lbSerialNumbers As System.Windows.Forms.ListBox
		Friend WithEvents pnlReprint As System.Windows.Forms.Panel
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents btnPrintCancel As System.Windows.Forms.Button
		Friend WithEvents pnlMain As System.Windows.Forms.Panel
		Friend WithEvents btnReprint As System.Windows.Forms.Button
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents txtPrintSN As System.Windows.Forms.TextBox
		Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents Label9 As System.Windows.Forms.Label
		Friend WithEvents txtRemoveSN As System.Windows.Forms.TextBox
		Friend WithEvents pnlRemoveItem As System.Windows.Forms.Panel
		Friend WithEvents btnRemoveCancel As System.Windows.Forms.Button
		Friend WithEvents pnlModel As System.Windows.Forms.Panel
		Friend WithEvents lblRecordCount As System.Windows.Forms.Label
		Friend WithEvents nudMax As System.Windows.Forms.NumericUpDown
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents cboDisposition As System.Windows.Forms.ComboBox
		Friend WithEvents lbl_cust_desc As System.Windows.Forms.Label
		Friend WithEvents pnlDisp As System.Windows.Forms.Panel
		Friend WithEvents lblTitle As System.Windows.Forms.Label
		Friend WithEvents lblDisp As System.Windows.Forms.Label
		Friend WithEvents pnlModifyBox As System.Windows.Forms.Panel
		Friend WithEvents Label11 As System.Windows.Forms.Label
		Friend WithEvents Label12 As System.Windows.Forms.Label
		Friend WithEvents txtModifyBoxNr As System.Windows.Forms.TextBox
		Friend WithEvents btnModifyBox As System.Windows.Forms.Button
		Friend WithEvents btnModifyBoxCancel As System.Windows.Forms.Button
		Friend WithEvents lblBoxName As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.btnCloseBox = New System.Windows.Forms.Button()
			Me.txtSN = New System.Windows.Forms.TextBox()
			Me.cboModel = New System.Windows.Forms.ComboBox()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.nudMax = New System.Windows.Forms.NumericUpDown()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.btnRemoveItem = New System.Windows.Forms.Button()
			Me.lbValidPrefix = New System.Windows.Forms.ListBox()
			Me.ListBox1 = New System.Windows.Forms.ListBox()
			Me.Label6 = New System.Windows.Forms.Label()
			Me.btnReprint = New System.Windows.Forms.Button()
			Me.lbSerialNumbers = New System.Windows.Forms.ListBox()
			Me.pnlMain = New System.Windows.Forms.Panel()
			Me.lblBoxName = New System.Windows.Forms.Label()
			Me.btnModifyBox = New System.Windows.Forms.Button()
			Me.lblTitle = New System.Windows.Forms.Label()
			Me.pnlDisp = New System.Windows.Forms.Panel()
			Me.cboDisposition = New System.Windows.Forms.ComboBox()
			Me.lblDisp = New System.Windows.Forms.Label()
			Me.lbl_cust_desc = New System.Windows.Forms.Label()
			Me.Label10 = New System.Windows.Forms.Label()
			Me.lblRecordCount = New System.Windows.Forms.Label()
			Me.pnlModel = New System.Windows.Forms.Panel()
			Me.pnlReprint = New System.Windows.Forms.Panel()
			Me.Label7 = New System.Windows.Forms.Label()
			Me.btnPrintCancel = New System.Windows.Forms.Button()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.txtPrintSN = New System.Windows.Forms.TextBox()
			Me.pnlRemoveItem = New System.Windows.Forms.Panel()
			Me.Label8 = New System.Windows.Forms.Label()
			Me.btnRemoveCancel = New System.Windows.Forms.Button()
			Me.Label9 = New System.Windows.Forms.Label()
			Me.txtRemoveSN = New System.Windows.Forms.TextBox()
			Me.pnlModifyBox = New System.Windows.Forms.Panel()
			Me.Label11 = New System.Windows.Forms.Label()
			Me.btnModifyBoxCancel = New System.Windows.Forms.Button()
			Me.Label12 = New System.Windows.Forms.Label()
			Me.txtModifyBoxNr = New System.Windows.Forms.TextBox()
			CType(Me.nudMax, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlMain.SuspendLayout()
			Me.pnlDisp.SuspendLayout()
			Me.pnlModel.SuspendLayout()
			Me.pnlReprint.SuspendLayout()
			Me.pnlRemoveItem.SuspendLayout()
			Me.pnlModifyBox.SuspendLayout()
			Me.SuspendLayout()
			'
			'btnCloseBox
			'
			Me.btnCloseBox.Location = New System.Drawing.Point(560, 376)
			Me.btnCloseBox.Name = "btnCloseBox"
			Me.btnCloseBox.Size = New System.Drawing.Size(128, 24)
			Me.btnCloseBox.TabIndex = 1
			Me.btnCloseBox.Text = "Close the Box"
			'
			'txtSN
			'
			Me.txtSN.BackColor = System.Drawing.Color.LightSkyBlue
			Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtSN.Location = New System.Drawing.Point(456, 64)
			Me.txtSN.Name = "txtSN"
			Me.txtSN.Size = New System.Drawing.Size(232, 23)
			Me.txtSN.TabIndex = 2
			Me.txtSN.Text = ""
			'
			'cboModel
			'
			Me.cboModel.Location = New System.Drawing.Point(8, 32)
			Me.cboModel.MaxDropDownItems = 15
			Me.cboModel.Name = "cboModel"
			Me.cboModel.Size = New System.Drawing.Size(168, 21)
			Me.cboModel.TabIndex = 3
			'
			'Label1
			'
			Me.Label1.Location = New System.Drawing.Point(8, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(72, 23)
			Me.Label1.TabIndex = 4
			Me.Label1.Text = "Model"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'Label2
			'
			Me.Label2.Location = New System.Drawing.Point(456, 40)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(232, 23)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Serial Number"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'Label3
			'
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.Location = New System.Drawing.Point(8, 376)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(488, 32)
			Me.Label3.TabIndex = 8
			Me.Label3.Text = "This screen is used to box items for storage.  Enter the serial number into the b" & _
			"lue field and press enter to add the item to the list."
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(40, 224)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(208, 72)
			Me.lblMsg.TabIndex = 7
			Me.lblMsg.Text = "Message to the user goes here."
			'
			'nudMax
			'
			Me.nudMax.Location = New System.Drawing.Point(40, 168)
			Me.nudMax.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
			Me.nudMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
			Me.nudMax.Name = "nudMax"
			Me.nudMax.Size = New System.Drawing.Size(88, 20)
			Me.nudMax.TabIndex = 10
			Me.nudMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			Me.nudMax.Value = New Decimal(New Integer() {90, 0, 0, 0})
			'
			'Label4
			'
			Me.Label4.Location = New System.Drawing.Point(40, 144)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(88, 23)
			Me.Label4.TabIndex = 11
			Me.Label4.Text = "Max Box Count"
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'btnRemoveItem
			'
			Me.btnRemoveItem.BackColor = System.Drawing.Color.Silver
			Me.btnRemoveItem.Location = New System.Drawing.Point(304, 248)
			Me.btnRemoveItem.Name = "btnRemoveItem"
			Me.btnRemoveItem.Size = New System.Drawing.Size(112, 40)
			Me.btnRemoveItem.TabIndex = 12
			Me.btnRemoveItem.Text = "Remove a Device from the list"
			'
			'lbValidPrefix
			'
			Me.lbValidPrefix.Enabled = False
			Me.lbValidPrefix.Location = New System.Drawing.Point(680, 448)
			Me.lbValidPrefix.Name = "lbValidPrefix"
			Me.lbValidPrefix.Size = New System.Drawing.Size(40, 17)
			Me.lbValidPrefix.TabIndex = 15
			Me.lbValidPrefix.Visible = False
			'
			'ListBox1
			'
			Me.ListBox1.Location = New System.Drawing.Point(112, 112)
			Me.ListBox1.Name = "ListBox1"
			Me.ListBox1.Size = New System.Drawing.Size(120, 69)
			Me.ListBox1.TabIndex = 0
			'
			'Label6
			'
			Me.Label6.Location = New System.Drawing.Point(680, 424)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(32, 23)
			Me.Label6.TabIndex = 16
			Me.Label6.Text = "Valid SN Prefixes"
			Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.Label6.Visible = False
			'
			'btnReprint
			'
			Me.btnReprint.BackColor = System.Drawing.Color.LightSteelBlue
			Me.btnReprint.Location = New System.Drawing.Point(304, 192)
			Me.btnReprint.Name = "btnReprint"
			Me.btnReprint.Size = New System.Drawing.Size(112, 40)
			Me.btnReprint.TabIndex = 17
			Me.btnReprint.Text = "Re-print an existing Box Label"
			'
			'lbSerialNumbers
			'
			Me.lbSerialNumbers.BackColor = System.Drawing.Color.LightGray
			Me.lbSerialNumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lbSerialNumbers.ItemHeight = 16
			Me.lbSerialNumbers.Location = New System.Drawing.Point(456, 88)
			Me.lbSerialNumbers.Name = "lbSerialNumbers"
			Me.lbSerialNumbers.Size = New System.Drawing.Size(232, 260)
			Me.lbSerialNumbers.TabIndex = 18
			'
			'pnlMain
			'
			Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBoxName, Me.btnModifyBox, Me.lblTitle, Me.nudMax, Me.pnlDisp, Me.lbl_cust_desc, Me.Label10, Me.lblRecordCount, Me.pnlModel, Me.Label4, Me.Label2, Me.lbSerialNumbers, Me.txtSN, Me.btnReprint, Me.btnRemoveItem, Me.lblMsg, Me.btnCloseBox, Me.Label3})
			Me.pnlMain.Location = New System.Drawing.Point(8, 8)
			Me.pnlMain.Name = "pnlMain"
			Me.pnlMain.Size = New System.Drawing.Size(704, 416)
			Me.pnlMain.TabIndex = 19
			'
			'lblBoxName
			'
			Me.lblBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBoxName.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
			Me.lblBoxName.Location = New System.Drawing.Point(240, 104)
			Me.lblBoxName.Name = "lblBoxName"
			Me.lblBoxName.Size = New System.Drawing.Size(200, 40)
			Me.lblBoxName.TabIndex = 28
			Me.lblBoxName.Text = "Existing box name goes here"
			Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnModifyBox
			'
			Me.btnModifyBox.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
			Me.btnModifyBox.Location = New System.Drawing.Point(304, 304)
			Me.btnModifyBox.Name = "btnModifyBox"
			Me.btnModifyBox.Size = New System.Drawing.Size(112, 40)
			Me.btnModifyBox.TabIndex = 27
			Me.btnModifyBox.Text = "Modify an existing NTF Pallet"
			'
			'lblTitle
			'
			Me.lblTitle.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
			Me.lblTitle.Location = New System.Drawing.Point(16, 8)
			Me.lblTitle.Name = "lblTitle"
			Me.lblTitle.Size = New System.Drawing.Size(312, 24)
			Me.lblTitle.TabIndex = 26
			Me.lblTitle.Text = "Form Title Goes Here"
			'
			'pnlDisp
			'
			Me.pnlDisp.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboDisposition, Me.lblDisp})
			Me.pnlDisp.Location = New System.Drawing.Point(232, 32)
			Me.pnlDisp.Name = "pnlDisp"
			Me.pnlDisp.Size = New System.Drawing.Size(200, 64)
			Me.pnlDisp.TabIndex = 25
			'
			'cboDisposition
			'
			Me.cboDisposition.Location = New System.Drawing.Point(8, 32)
			Me.cboDisposition.Name = "cboDisposition"
			Me.cboDisposition.Size = New System.Drawing.Size(176, 21)
			Me.cboDisposition.TabIndex = 22
			'
			'lblDisp
			'
			Me.lblDisp.Location = New System.Drawing.Point(8, 8)
			Me.lblDisp.Name = "lblDisp"
			Me.lblDisp.Size = New System.Drawing.Size(176, 23)
			Me.lblDisp.TabIndex = 23
			Me.lblDisp.Text = "Disposition"
			Me.lblDisp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'lbl_cust_desc
			'
			Me.lbl_cust_desc.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lbl_cust_desc.ForeColor = System.Drawing.Color.SteelBlue
			Me.lbl_cust_desc.Location = New System.Drawing.Point(352, 8)
			Me.lbl_cust_desc.Name = "lbl_cust_desc"
			Me.lbl_cust_desc.Size = New System.Drawing.Size(312, 24)
			Me.lbl_cust_desc.TabIndex = 24
			Me.lbl_cust_desc.Text = "Customer Name Goes Here"
			'
			'Label10
			'
			Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label10.Location = New System.Drawing.Point(40, 104)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New System.Drawing.Size(200, 40)
			Me.Label10.TabIndex = 21
			Me.Label10.Text = "Please select a Model before entering serial numbers."
			'
			'lblRecordCount
			'
			Me.lblRecordCount.BackColor = System.Drawing.Color.MediumSeaGreen
			Me.lblRecordCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblRecordCount.Location = New System.Drawing.Point(456, 344)
			Me.lblRecordCount.Name = "lblRecordCount"
			Me.lblRecordCount.Size = New System.Drawing.Size(232, 23)
			Me.lblRecordCount.TabIndex = 20
			Me.lblRecordCount.Text = "0 Record(s)"
			Me.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'pnlModel
			'
			Me.pnlModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboModel, Me.Label1})
			Me.pnlModel.Location = New System.Drawing.Point(32, 32)
			Me.pnlModel.Name = "pnlModel"
			Me.pnlModel.Size = New System.Drawing.Size(184, 64)
			Me.pnlModel.TabIndex = 19
			'
			'pnlReprint
			'
			Me.pnlReprint.BackColor = System.Drawing.Color.LightSteelBlue
			Me.pnlReprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlReprint.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.btnPrintCancel, Me.Label5, Me.txtPrintSN})
			Me.pnlReprint.Location = New System.Drawing.Point(0, 432)
			Me.pnlReprint.Name = "pnlReprint"
			Me.pnlReprint.Size = New System.Drawing.Size(232, 176)
			Me.pnlReprint.TabIndex = 19
			Me.pnlReprint.Visible = False
			'
			'Label7
			'
			Me.Label7.Location = New System.Drawing.Point(16, 120)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New System.Drawing.Size(184, 48)
			Me.Label7.TabIndex = 9
			Me.Label7.Text = "Enter a serial number belonging to the box you you want to print a label for."
			'
			'btnPrintCancel
			'
			Me.btnPrintCancel.BackColor = System.Drawing.SystemColors.Control
			Me.btnPrintCancel.Location = New System.Drawing.Point(128, 80)
			Me.btnPrintCancel.Name = "btnPrintCancel"
			Me.btnPrintCancel.Size = New System.Drawing.Size(80, 24)
			Me.btnPrintCancel.TabIndex = 8
			Me.btnPrintCancel.Text = "Cancel"
			'
			'Label5
			'
			Me.Label5.Location = New System.Drawing.Point(16, 16)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(192, 23)
			Me.Label5.TabIndex = 7
			Me.Label5.Text = "Serial Number"
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'txtPrintSN
			'
			Me.txtPrintSN.BackColor = System.Drawing.Color.LightSkyBlue
			Me.txtPrintSN.Location = New System.Drawing.Point(16, 48)
			Me.txtPrintSN.Name = "txtPrintSN"
			Me.txtPrintSN.Size = New System.Drawing.Size(192, 20)
			Me.txtPrintSN.TabIndex = 6
			Me.txtPrintSN.Text = ""
			'
			'pnlRemoveItem
			'
			Me.pnlRemoveItem.BackColor = System.Drawing.Color.Silver
			Me.pnlRemoveItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlRemoveItem.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.btnRemoveCancel, Me.Label9, Me.txtRemoveSN})
			Me.pnlRemoveItem.Location = New System.Drawing.Point(232, 432)
			Me.pnlRemoveItem.Name = "pnlRemoveItem"
			Me.pnlRemoveItem.Size = New System.Drawing.Size(224, 176)
			Me.pnlRemoveItem.TabIndex = 20
			Me.pnlRemoveItem.Visible = False
			'
			'Label8
			'
			Me.Label8.Location = New System.Drawing.Point(16, 120)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New System.Drawing.Size(184, 40)
			Me.Label8.TabIndex = 9
			Me.Label8.Text = "Enter a serial number to be removed from the list."
			'
			'btnRemoveCancel
			'
			Me.btnRemoveCancel.BackColor = System.Drawing.SystemColors.Control
			Me.btnRemoveCancel.Location = New System.Drawing.Point(128, 80)
			Me.btnRemoveCancel.Name = "btnRemoveCancel"
			Me.btnRemoveCancel.Size = New System.Drawing.Size(80, 24)
			Me.btnRemoveCancel.TabIndex = 8
			Me.btnRemoveCancel.Text = "Cancel"
			'
			'Label9
			'
			Me.Label9.Location = New System.Drawing.Point(16, 16)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New System.Drawing.Size(192, 23)
			Me.Label9.TabIndex = 7
			Me.Label9.Text = "Serial Number"
			Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'txtRemoveSN
			'
			Me.txtRemoveSN.BackColor = System.Drawing.Color.LightSkyBlue
			Me.txtRemoveSN.Location = New System.Drawing.Point(16, 48)
			Me.txtRemoveSN.Name = "txtRemoveSN"
			Me.txtRemoveSN.Size = New System.Drawing.Size(192, 20)
			Me.txtRemoveSN.TabIndex = 6
			Me.txtRemoveSN.Text = ""
			'
			'pnlModifyBox
			'
			Me.pnlModifyBox.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
			Me.pnlModifyBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlModifyBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label11, Me.btnModifyBoxCancel, Me.Label12, Me.txtModifyBoxNr})
			Me.pnlModifyBox.Location = New System.Drawing.Point(456, 432)
			Me.pnlModifyBox.Name = "pnlModifyBox"
			Me.pnlModifyBox.Size = New System.Drawing.Size(224, 176)
			Me.pnlModifyBox.TabIndex = 21
			Me.pnlModifyBox.Visible = False
			'
			'Label11
			'
			Me.Label11.Location = New System.Drawing.Point(16, 120)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New System.Drawing.Size(184, 40)
			Me.Label11.TabIndex = 9
			Me.Label11.Text = "Enter the pallet name to be modified."
			'
			'btnModifyBoxCancel
			'
			Me.btnModifyBoxCancel.BackColor = System.Drawing.SystemColors.Control
			Me.btnModifyBoxCancel.Location = New System.Drawing.Point(128, 80)
			Me.btnModifyBoxCancel.Name = "btnModifyBoxCancel"
			Me.btnModifyBoxCancel.Size = New System.Drawing.Size(80, 24)
			Me.btnModifyBoxCancel.TabIndex = 8
			Me.btnModifyBoxCancel.Text = "Cancel"
			'
			'Label12
			'
			Me.Label12.Location = New System.Drawing.Point(16, 16)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New System.Drawing.Size(192, 23)
			Me.Label12.TabIndex = 7
			Me.Label12.Text = "Pallet Name"
			Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			'
			'txtModifyBoxNr
			'
			Me.txtModifyBoxNr.BackColor = System.Drawing.Color.LightSkyBlue
			Me.txtModifyBoxNr.Location = New System.Drawing.Point(16, 48)
			Me.txtModifyBoxNr.Name = "txtModifyBoxNr"
			Me.txtModifyBoxNr.Size = New System.Drawing.Size(192, 20)
			Me.txtModifyBoxNr.TabIndex = 6
			Me.txtModifyBoxNr.Text = ""
			'
			'frmBoxing
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(720, 438)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlModifyBox, Me.pnlReprint, Me.pnlRemoveItem, Me.pnlMain, Me.Label6, Me.lbValidPrefix})
			Me.Name = "frmBoxing"
			Me.Text = "Device Boxing"
			CType(Me.nudMax, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlMain.ResumeLayout(False)
			Me.pnlDisp.ResumeLayout(False)
			Me.pnlModel.ResumeLayout(False)
			Me.pnlReprint.ResumeLayout(False)
			Me.pnlRemoveItem.ResumeLayout(False)
			Me.pnlModifyBox.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"
		Private _cpl_id As Integer	   ' THE LOCATION THE WHERE THE DEVICES ARE COMING FROM.
		Private _cust_id As Integer = 0		 ' CUSTOMER ID
		Private _loc_id As Integer = 0		 ' LOCATION ID
		Private _use_disp As Boolean = False		' USE DISPOSITION FILTERING.
		Private _use_prefix As Boolean = False		' USE PREFIX VALIDATION.
		Private _user_id As Integer = 0		' CURRENT USER ID
		Private _form_title As String = ""
		Private _createDevicesWithBox = False		  ' CREATE THE DEVICES WITH THE BOX IF THEY DO NOT EXISTS.
		Private _applyBilling As Boolean = False
		Private _using_existing_box As Boolean = False
		Private _existingPalletID As Integer = 0
		Private _existingPalletName As String = ""
		Public Enum BOXING_PROCESS
			INITIAL_BOXING = 1
			TRIAGE_BOXING = 2
		End Enum
		Private SelectedBoxingProcess As BOXING_PROCESS
#End Region
#Region "CONSTRUCTORS"
		Public Sub New(ByVal boxing_process As BOXING_PROCESS, ByVal cust_id As Integer, ByVal loc_id As Integer, ByVal cpl_id As Integer, ByVal CreateDevicesWithBox As Boolean, ByVal form_title As String)
			MyBase.New()
			InitializeComponent()
			SelectedBoxingProcess = boxing_process
			_applyBilling = (SelectedBoxingProcess = boxing_process.TRIAGE_BOXING)
			_cust_id = cust_id
			_loc_id = loc_id
			_cpl_id = cpl_id
			_use_disp = False
			_use_prefix = False
			_form_title = form_title
			_createDevicesWithBox = CreateDevicesWithBox
		End Sub
		Public Sub New(ByVal boxing_process As BOXING_PROCESS, ByVal cust_id As Integer, ByVal loc_id As Integer, ByVal cpl_id As Integer, ByVal use_disp As Boolean, ByVal use_prefix As Boolean, ByVal CreateDevicesWithBox As Boolean, ByVal form_title As String)
			MyBase.New()
			InitializeComponent()
			SelectedBoxingProcess = boxing_process
			_applyBilling = (SelectedBoxingProcess = boxing_process.TRIAGE_BOXING)
			_cust_id = cust_id
			_loc_id = loc_id
			_cpl_id = cpl_id
			_use_disp = use_disp
			_use_prefix = use_prefix
			_form_title = form_title
			_createDevicesWithBox = CreateDevicesWithBox
		End Sub
#End Region
#Region "FORM EVENTS"
		Private Sub frmTmoBoxing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' PROCESSES TO DO UPON LOADING THE FORM.
			Try
				lblTitle.Text = _form_title
				ClearMsg()
				_user_id = PSS.Core.ApplicationUser.IDuser
				pnlDisp.Visible = _use_disp
				GetCustomerInformation()
				PopulateModelCombo()
				PopulateDispositionCombo()
				EnableControls()
			Catch ex As Exception
				pnlMain.Enabled = False
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub
#End Region
#Region "CONTROL EVENTS"
		Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
			' POPULATES THE PREFIX LIST WHEN THE MODEL CHANGES.
			If cboModel.SelectedValue > 0 AndAlso _use_prefix Then
				PopulatePrefixList()
			End If
			EnableControls()
		End Sub
		Private Sub cboDisposition_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDisposition.SelectedValueChanged
			EnableControls()
		End Sub
		Private Sub txtSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyDown
			' PROCESS TO DO UPON ENTRY OF SERIAL NUMBER.
			If e.KeyCode = Keys.Enter AndAlso txtSN.Text <> "" Then
				' CHECK THE MODEL PREFIX.
				If _use_prefix AndAlso Not ValidatePrefix(txtSN.Text) Then
					MessageBox.Show("This is not a valid entry for this model based on the serial number prefix.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
					txtSN.Text = ""
					txtSN.Focus()
					Exit Sub
				End If
				' CHECK FOR DUPLICATE ENTRY IN THE LIST.
				If IsDeviceDuplicate(txtSN.Text) Then
					MessageBox.Show("This device has already been entered.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					txtSN.Text = ""
					txtSN.Focus()
					Exit Sub
				End If
				' CHECK TO MAKE SURE THE ITEM IS NOT ALREADY BOXED.
				If IsDeviceAlreadyBoxed(txtSN.Text) Then
					MessageBox.Show("This Serial Number has already been boxed.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					txtSN.Text = ""
					txtSN.Focus()
					Exit Sub
				End If
				' CHECK TO MAKE SURE THE ITEM IS NOT IN A PALLET.
				If IsDeviceInPallet(txtSN.Text) Then
					MessageBox.Show("This Serial Number has already been placed in a pallet.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					txtSN.Text = ""
					txtSN.Focus()
					Exit Sub
				End If
				' MAKE SURE THE DEVICE HAS BEEN RECEIVED.
				If Not IsDeviceAlreadyReceived(txtSN.Text) Then
					MessageBox.Show("This Serial Number has not been received.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					txtSN.Text = ""
					txtSN.Focus()
					Exit Sub
				End If
				' CHECK THE DISPOSITION IF NEEDED.
				If _use_disp Then
					If cboDisposition.SelectedIndex <> 0 Then
						If Not IsDispositionCorrect(txtSN.Text) Then
							MessageBox.Show("This Serial Number does not have the correct disposition.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							txtSN.Text = ""
							txtSN.Focus()
							Exit Sub
						End If
					End If
				End If

				If Not _createDevicesWithBox Then
					' CHECK FOR WORKSTATION FOR CORRECT LOCATION.
					Dim _sn As String = txtSN.Text
					Dim _dev As New Data.BOL.tDevice(txtSN.Text, False)
					Dim _device_id As Integer = _dev.Device_ID
					Dim _co As New Data.BOL.tcellopt(_device_id)
					If _device_id = 0 Then
						MessageBox.Show("This device was not found in the system.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						txtSN.Text = ""
						txtSN.Focus()
						Exit Sub
						_dev = Nothing
						_co = Nothing
					ElseIf _co.WorkStation <> "TRIAGE-BOXING" Then
						MessageBox.Show("This Serial Number is not in the correct workstation to be boxed.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						txtSN.Text = ""
						txtSN.Focus()
						Exit Sub
						_dev = Nothing
						_co = Nothing
					End If
				End If

				' ADD THE ITEM TO THE LIST.
				lbSerialNumbers.Items.Add(txtSN.Text)
				txtSN.Text = ""
				EnableControls()
				UpdateCounter()
				txtSN.SelectAll()
				txtSN.Focus()
				CheckCounter()
			End If
		End Sub
		Private Sub btnRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveItem.Click
			RemoveItem()
			EnableControls()
		End Sub
		Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
			btnCloseBox.Enabled = False
			Dim _disp As String = cboDisposition.Text
			Dim _msg As String = "Proceed to close the box?"
			If MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, _
			 MessageBoxIcon.Question, _
			 MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
				Try
					' IF USING AN EXISTING PALLET AND THERE ARE NO DEVICES INCLUDED 
					' THEN DELETE THE PALLET.
					If _using_existing_box AndAlso lbSerialNumbers.Items.Count = 0 Then
						_msg = "The box will be delete since no devices are assigned to the box.  Whould you like to continue?"
						If MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
							Me.Cursor = Cursors.WaitCursor
							btnCloseBox.Enabled = False
							DeleteExistingPallet(_existingPalletID)
							ClearAll()
							EnableControls()
							MessageBox.Show("Pallet has been deleted.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
						Else
							' USER CANCELED PROCESS.
							Exit Sub
						End If
					Else
						' CLOSE THE BOX.
						''' MAKE SURE THE BOX DOES NOT HAVE ANY ALREADY FAILED DEVICES.
						'If PalletHasFailedDevices() Then
						'	MessageBox.Show("This box contains failed devices.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						'Else
						If lbSerialNumbers.Items.Count > 0 Then
							Me.Cursor = Cursors.WaitCursor
							btnCloseBox.Enabled = False
							If _disp = "NTF" Then
								ClosePallet()
								ClearAll()
							Else
								CloseWHBox()
								ClearAll()
							End If
							ClearAll()
							EnableControls()
						Else
							MessageBox.Show("You cannot close a box with no devices assigned to it.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Finally
					btnCloseBox.Enabled = True
					Me.Cursor = Cursors.Default
				End Try
			End If
			EnableControls()
		End Sub
		Private Sub btnPrintCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintCancel.Click
			pnlMain.Visible = True
			pnlMain.Enabled = True
			pnlReprint.Visible = False
			pnlReprint.Enabled = False
		End Sub
		Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
			pnlMain.Visible = False
			pnlMain.Enabled = False
			pnlReprint.Top = 0
			pnlReprint.Visible = True
			pnlReprint.Enabled = True
			txtPrintSN.Focus()
		End Sub
		Private Sub btnRemoveCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveCancel.Click
			txtRemoveSN.Text = ""
			pnlMain.Visible = True
			pnlMain.Enabled = True
			pnlRemoveItem.Visible = False
			pnlRemoveItem.Enabled = False
		End Sub
		Private Sub txtRemoveSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemoveSN.KeyDown
			Dim _item As Object
			Dim _found As Boolean = False
			Dim _pallet_id As Integer = 0
			If e.KeyCode = Keys.Enter Then
				For Each _item In lbSerialNumbers.Items
					If txtRemoveSN.Text = _item.ToString() Then
						lbSerialNumbers.Items.Remove(_item)
						If _using_existing_box Then
							Dim _sn As String = txtRemoveSN.Text
							Dim _dev As New Data.BOL.tDevice(_sn, False)
							_pallet_id = _dev.Pallett_ID
							_dev.Pallett_ID = 0
							_dev.ApplyChanges()
							_dev = Nothing
						End If
						If _pallet_id > 0 Then
							UpdatePalletCount(_pallet_id)
						End If
						_found = True
						MessageBox.Show("Item removed.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
						txtRemoveSN.Text = ""
						pnlMain.Visible = True
						pnlMain.Enabled = True
						pnlRemoveItem.Visible = False
						pnlRemoveItem.Enabled = False
						ClearMsg()
						UpdateCounter()
						EnableControls()
						Exit For
					End If
				Next
				If Not _found Then
					MessageBox.Show("Item not found in the list.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					txtRemoveSN.Text = ""
					txtRemoveSN.Focus()
				End If
			End If
		End Sub
		Private Sub nudMax_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nudMax.MouseDown
			ValidateMaxControl()
		End Sub
		Private Sub nudMax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudMax.Leave
			ValidateMaxControl()
		End Sub
		Private Sub txtPrintSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrintSN.KeyUp
			If e.KeyCode = Keys.Enter Then
				Dim _sn As String = txtPrintSN.Text
				Dim _d As New Data.BOL.tDevice(_sn, _loc_id)
				Dim _device_id As Integer = 0
				Dim _pallet_id As Integer = 0
				Dim _model_id As Integer = 0
				_device_id = _d.Device_ID
				_pallet_id = _d.Pallett_ID
				_model_id = _d.Model_ID
				_d = Nothing
				If _device_id > 0 Then
					Dim _dtrg As New Data.BOL.tdevice_triage(_device_id)
					If _dtrg.disp_id = 5 Then
						PrintPalletLabel(_pallet_id, _model_id, "NTF")
					Else
						PrintWBoxLabel(_sn)
					End If
					_dtrg = Nothing
				Else
					MessageBox.Show("Device not found.")
				End If
			End If
		End Sub
		Private Sub btnModifyBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifyBox.Click
			pnlMain.Visible = False
			pnlMain.Enabled = False
			pnlModifyBox.Top = 0
			pnlModifyBox.Left = 0
			pnlModifyBox.Visible = True
			pnlModifyBox.Enabled = True
			txtModifyBoxNr.Focus()
		End Sub
		Private Sub btnModifyBoxCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifyBoxCancel.Click
			txtModifyBoxNr.Text = ""
			pnlMain.Visible = True
			pnlMain.Enabled = True
			pnlModifyBox.Visible = False
			pnlModifyBox.Enabled = False
		End Sub
		Private Sub txtModifyBoxNr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtModifyBoxNr.KeyDown
			Dim _item As Object
			Dim _found As Boolean = False
			If e.KeyCode = Keys.Enter Then
				lbSerialNumbers.Items.Clear()
				ClearMsg()
				UpdateCounter()
				EnableControls()
				btnCloseBox.Enabled = True
				' LOAD UP THE PALLET IF IT EXISTS.
				Dim _plt As New Data.BOL.tpallet(txtModifyBoxNr.Text)
				If _plt.Pallett_ID > 0 Then
					If _plt.pallet_qc_passed = 1 Then
						MessageBox.Show("This pallet has already passed AQL and cannot be modfied.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
						ClearAll()
						Exit Sub
					End If
					_existingPalletID = _plt.Pallett_ID
					_existingPalletName = _plt.Pallett_Name
					LoadExistingPallet(_plt.Pallett_ID)
					_using_existing_box = True
					ClearMsg()
					lblBoxName.Text = _existingPalletName
					UpdateCounter()
					EnableControls()
					txtModifyBoxNr.Text = ""
					pnlMain.Visible = True
					pnlMain.Enabled = True
					pnlModifyBox.Visible = False
				Else
					MessageBox.Show("Pallet not found in the system or is not currently available for boxing.", _
					 Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
					txtModifyBoxNr.Text = ""
				End If
			End If
		End Sub
#End Region
#Region "PROPERTIES"

#End Region
#Region "METHODS"
		Private Sub EnableControls()
			' ENABLES AND DISABLES CONTROLS.
			btnModifyBox.Visible = SelectedBoxingProcess = BOXING_PROCESS.TRIAGE_BOXING
			If _use_disp Then
				txtSN.Enabled = ((cboModel.SelectedValue > 0) AndAlso _
				(lbSerialNumbers.Items.Count < nudMax.Value) AndAlso _
				(cboDisposition.SelectedValue > 0))
			Else
				txtSN.Enabled = ((cboModel.SelectedValue > 0) AndAlso _
				(lbSerialNumbers.Items.Count < nudMax.Value))
			End If
			btnModifyBox.Enabled = lbSerialNumbers.Items.Count = 0
			btnCloseBox.Enabled = ((cboModel.SelectedValue > 0) AndAlso (lbSerialNumbers.Items.Count > 0)) OrElse (_using_existing_box)
			btnRemoveItem.Enabled = ((cboModel.SelectedValue > 0) AndAlso (lbSerialNumbers.Items.Count > 0))
			pnlModel.Enabled = lbSerialNumbers.Items.Count < 1
			pnlDisp.Enabled = lbSerialNumbers.Items.Count < 1
		End Sub
		Private Sub PostMsg(ByVal text As String)
			' POST A MESSAGE TO THE USER.
			lblMsg.Text = text
			Me.Refresh()
		End Sub
		Private Sub ClearMsg()
			' CLEARS MESSAGES POSTED TO THE USER.
			lblMsg.Text = ""
			lblBoxName.Text = ""
		End Sub
		Private Sub GetCustomerInformation()
			Dim _cust As New Data.BOL.tcustomer(_cust_id)
			If _cust.Cust_ID > 0 Then
				lbl_cust_desc.Text = _cust.Cust_Name1
			Else
				Throw New Exception("Could not load customer information.")
			End If
			_cust = Nothing
		End Sub
		Private Sub PopulateModelCombo()
			' POPULATES THE MODEL COMBO BOX.
			Dim _dt As New DataTable()
			Dim _nr As DataRow
			Dim _mdl As New Data.BOL.tmodelCollection(_cust_id)
			cboModel.ValueMember = "model_id"
			cboModel.DisplayMember = "model_desc"
			_dt = _mdl.tmodelDataTable.Copy
			_nr = _dt.NewRow()
			_nr(0) = 0
			_nr(1) = "-- Select --"
			_dt.Rows.InsertAt(_nr, 0)
			_dt.AcceptChanges()
			cboModel.DataSource = _dt
			cboModel.Refresh()
			_mdl = Nothing
		End Sub
		Private Sub PopulatePrefixList()
			' POPULATES THE HIDDEN PREFIX LISTBOX.
			lbValidPrefix.DataSource = Nothing
			Dim _msnp As New Data.BOL.tmodel_sn_prefixesCollection(cboModel.SelectedValue)
			lbValidPrefix.ValueMember = "msnp_id"
			lbValidPrefix.DisplayMember = "prefix"
			lbValidPrefix.DataSource = _msnp.tmodel_sn_prefixesDataTable.Copy
			_msnp = Nothing
		End Sub
		Private Sub PopulateDispositionCombo()
			' POPULATES THE CUSTOMER COMBO BOX.
			Dim _dt As New DataTable()
			Dim _nr As DataRow
			Dim _col As New Data.BOL.tcustomer_dispositionsCollection(_cust_id, False)
			_dt = _col.tcustomer_dispositionsDataTable.Copy
			_nr = _dt.NewRow()
			_nr("disp_id") = 0
			If _use_disp Then
				_nr("disp_cd") = "-- Select One --"
			Else
				_nr("disp_cd") = "-- All --"
			End If
			_dt.Rows.InsertAt(_nr, 0)
			_dt.AcceptChanges()
			cboDisposition.DataSource = _dt
			cboDisposition.ValueMember = "disp_id"
			cboDisposition.DisplayMember = "disp_cd"
			cboDisposition.Refresh()
			_col = Nothing
			'cboDisposition.SelectedValue = 0
		End Sub
		Private Sub RemoveItem()
			' REMOVES AN ITEM FROM THE LIST.
			pnlMain.Visible = True
			pnlMain.Enabled = False
			pnlRemoveItem.Top = 0
			pnlRemoveItem.Left = 0
			pnlRemoveItem.Visible = True
			pnlRemoveItem.Enabled = True
			txtRemoveSN.Text = ""
			txtRemoveSN.Focus()
		End Sub
		Private Sub LoadExistingPallet(ByVal pallet_id As Integer)
			Dim _dr As System.Data.DataRow
			' GET THE PALLET RECORD.
			Dim _plt As New Data.BOL.tpallet(pallet_id)
			If _plt.Pallett_ID > 0 Then
				' SET THE MODEL
				cboModel.SelectedValue = _plt.Model_ID
				' SET THE DISPOSITION
				cboDisposition.SelectedValue = _plt.disp_id
				_plt = Nothing
				' GET THE DEVICES
				Dim _dt As New DataTable()
				Dim _devs As New Data.BOL.tDeviceCollectionByPallett(pallet_id)
				_dt = _devs.deviceDataTable.Copy
				_devs = Nothing
				For Each _dr In _dt.Rows()
					lbSerialNumbers.Items.Add(_dr("device_sn"))
				Next
			Else
				MessageBox.Show("Pallet not found", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
		End Sub
		Private Sub CloseWHBox()
			' CLOSES THE BOX AND WRITES DATA TO THE DATABASE.
			Dim _model_id As Integer
			Dim _dt As New DataTable()
			Dim _newBoxNr As String = ""
			Dim _whb_id As Integer
			Dim _disp_id As Integer = cboDisposition.SelectedValue
			Dim _box_type As String = ""
			Dim _wfmr As New Data.BLL.WFMReceiving(_user_id)
			Dim _dm As New Data.BLL.DeviceMovement(_user_id)
			_model_id = cboModel.SelectedValue
			Dim _cpl_id_to As Integer = _dm.GetNextLocIDWithDisp(_cpl_id, _disp_id)
			BuildDataTable(_dt)
			If _createDevicesWithBox AndAlso Not _using_existing_box Then
				_whb_id = _wfmr.CreateBoxAndDevices(_dt, _model_id, _user_id, _cpl_id_to, _disp_id, _applyBilling)
			Else
				_whb_id = _wfmr.CreateBox(_dt, _model_id, _user_id, _cpl_id_to, _disp_id, _applyBilling)
			End If

			' GET THE NEW BOX NUMBER FROM THE BOX CREATED.
			Dim _wb As New Data.BOL.wh_box(_whb_id)
			_newBoxNr = _wb.box_na
			_wb = Nothing
			' GET THE BOX TYPE.
			Dim _disp As New Data.BOL.tdispositions(_disp_id)
			If _disp.disp_id > 0 Then
				_box_type = _disp.disp_cd
			Else
				_box_type = ""
			End If
			_disp = Nothing

			' PROCESS THE CREATION OF THE BOX.
			If _whb_id > 0 Then
				Dim _ws As String = IIf(cboDisposition.SelectedValue > 0, cboDisposition.Text, "")
				PrintTheLabel(_newBoxNr, cboModel.Text, lbSerialNumbers.Items.Count, _box_type)
				Dim _msg As String = ""
				_msg = "Box number " & _newBoxNr & " has been successfully closed."
				If _disp_id > 0 Then
					_msg += vbCrLf & vbCrLf & "The box has been moved to " & _ws & "."
				End If
				MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			Else
				Throw New Exception("Unable to create box. Please try again.")
			End If
		End Sub
		Private Sub ClosePallet()
			' CLOSES THE BOX AND WRITES DATA TO THE DATABASE.
			Dim _model_id As Integer
			Dim _dt As New DataTable()
			Dim _newPalletNa As String = ""
			Dim _pallet_id As Integer
			Dim _disp_id As Integer = cboDisposition.SelectedValue
			Dim _box_type As String = ""
			Dim _wfmr As New Data.BLL.WFMReceiving(_user_id)
			Dim _dm As New Data.BLL.DeviceMovement(_user_id)
			_model_id = cboModel.SelectedValue
			Dim _cpl_id_to As Integer = _dm.GetNextLocIDWithDisp(_cpl_id, _disp_id)
			BuildDataTable(_dt)
			' CREATE THE PALLET IF THIS IS NOT A RECYCLING BOX NUMBER.
			If Not _using_existing_box Then
				Dim _palletFtry As New Data.BLL.PalletFactory()
				_pallet_id = _palletFtry.CreateWfmNtfPallet(_dt, _model_id, _disp_id, _user_id)
				If _pallet_id > 0 Then
					' GET THE NEW PALLET NAME FROM THE BOX CREATED.
					Dim _pallet As New Data.BOL.tpallet(_pallet_id)
					_newPalletNa = _pallet.Pallett_Name
					_pallet = Nothing
				Else
					Throw New Exception("Pallet creation failed.")
				End If
			Else
				_pallet_id = _existingPalletID
				_newPalletNa = _existingPalletName
				RemoveAllDevicesFromPallet(_pallet_id)
			End If
			' UPDATE THE DEVICES IN THE BOX.
			Dim _dr As DataRow
			Dim _palletQty As Integer = _dt.Rows.Count
			For Each _dr In _dt.Rows()
				Dim _device_id As Integer
				Dim _sn As String = _dr(0).ToString()
				' tdevice
				Dim _device As New Data.BOL.tDevice(_sn, False)
				_device_id = _device.Device_ID
				_device.Pallett_ID = _pallet_id
				_device.ApplyChanges()
				_device = Nothing
				' titem
				Dim _itm As New Data.BOL.titem(_device_id)
				_itm.BoxID = _newPalletNa
				_itm.ApplyChanges()
				_itm = Nothing
				' tcellopt
				Dim _co As New Data.BOL.tcellopt(_device_id)
				_co.WorkStation = "AQL"
				_co.WorkStationEntryDt = Date.Now
				_co.ApplyChanges()
				_co = Nothing
			Next
			' UPDATE THE PALLET QUANTITY.
			Dim _plt As New Data.BOL.tpallet(_pallet_id)
			_plt.Pallett_QTY = _palletQty
			_plt.AQL_QCResult_ID = 0
			_plt.ApplyChanges()
			_plt = Nothing
			' GET THE BOX TYPE.
			Dim _disp As New Data.BOL.tdispositions(_disp_id)
			If _disp.disp_id > 0 Then
				_box_type = _disp.disp_cd
			Else
				_box_type = ""
			End If
			_disp = Nothing
			' PRINT THE LABEL IF THE PALLET WAS CREATED AND WRAP THINGS UP.
			If _pallet_id > 0 Then
				Dim _ws As String = IIf(cboDisposition.SelectedValue > 0, cboDisposition.Text, "")
				PrintTheLabel(_newPalletNa, cboModel.Text, lbSerialNumbers.Items.Count, _box_type)
				Dim _msg As String = ""
				_msg = "Box number " & _newPalletNa & " has been successfully closed."
				If _disp_id > 0 Then
					_msg += vbCrLf & vbCrLf & "The box has been moved to " & _ws & "."
				End If
				MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			Else
				Throw New Exception("Unable to create box. Please try again.")
			End If
		End Sub
		Private Sub BuildDataTable(ByRef dt As DataTable)
			' PUTS ALL SERIAL NUMBERS ENTERED INTO A DATATABLE FOR PROCESSING.
			Dim item As Object
			dt.TableName = "serial_numbers"
			dt.Columns.Clear()
			dt.Columns.Add("sn", GetType(String))
			dt.AcceptChanges()
			Dim dr As DataRow
			For Each item In lbSerialNumbers.Items
				dr = dt.NewRow()
				dr(0) = item.ToString()
				dt.Rows.Add(dr)
			Next
		End Sub
		Private Function IsDeviceDuplicate(ByVal sn As String) As Boolean
			' CHECKS TO MAKE SURE THE SERIAL NUMBER IS NOT A DUPLICATE.
			Dim _retVal As Boolean = False
			Dim _item As Object
			For Each _item In lbSerialNumbers.Items
				If sn = _item.ToString Then
					_retVal = True
				End If
			Next
			Return _retVal
		End Function
		Private Function IsDeviceAlreadyReceived(ByVal sn As String) As Boolean
			' MAKE SURE THE DEVICE HAS BEEN RECEIVED.
			Dim _retVal As Boolean = False
			Dim _bpr As New Data.BOL.ttf_bx_phn_received(sn)
			_retVal = _bpr.bpr_id > 1
			_bpr = Nothing
			Return _retVal
		End Function
		Private Function IsDispositionCorrect(ByVal sn As String) As Boolean
			Dim _retVal As Boolean
			Dim _disp_id As Integer = cboDisposition.SelectedValue
			Dim _device_disp_id As Integer
			If _disp_id = 0 Then
				Return True
			End If
			Dim _dtrg As New Data.BOL.tdevice_triage(sn)
			_device_disp_id = _dtrg.disp_id
			_dtrg = Nothing
			_retVal = (_device_disp_id = _disp_id)
			Return _retVal
		End Function
		Private Sub UpdateCounter()
			' UPDATES THE RECORD COUNTER.
			lblRecordCount.Text = lbSerialNumbers.Items.Count.ToString() & " Record(s)"
		End Sub
		Private Sub CheckCounter()
			' CHECKS THE RECORD COUNTER TO SEE IF BOX IS FULL.
			If nudMax.Value = lbSerialNumbers.Items.Count Then
				PostMsg("This box is full.... Please close the box before continuing.")
				lbSerialNumbers.Focus()
			End If
		End Sub
		Private Sub ValidateMaxControl()
			' VALIDATE THE MAX COUNTER CONTROL IF RECORDS HAVE ALREADY BEEN ADDED.
			If nudMax.Value < lbSerialNumbers.Items.Count Then
				nudMax.Value = lbSerialNumbers.Items.Count
				Dim _msg As String = "You cannot change the max box count to be " & _
				 "less than the items you have already assigned to the box.  " & _
				 vbCrLf & vbCrLf & _
				 "The max count has been set to the number of items in the box."
				MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
			ClearMsg()
			CheckCounter()
			EnableControls()
		End Sub
		Private Function ValidatePrefix(ByVal sn As String) As Boolean
			' VALIDATES THE SERIAL NUMBER PREFIX.
			Dim _retVal As Boolean = False
			Dim _item As Object
			For Each _item In lbValidPrefix.Items
				If Mid(sn, 1, _item(2).ToString.Length) = _item(2).ToString() Then
					_retVal = True
					Exit For
				End If
			Next
			Return _retVal
		End Function
		Private Function IsDeviceAlreadyBoxed(ByVal sn As String) As Boolean
			' CHECK TO MAKE SURE THE ITEM IS NOT ALREADY BOXED.
			Dim _retVal As Boolean
			Dim _whb As New Data.BOL.wh_box_by_sn_readonly(sn)
			_retVal = _whb.whb_id > 1
			_whb = Nothing
			Return _retVal
		End Function
		Private Function IsDeviceInPallet(ByVal sn As String) As Boolean
			' CHECK TO MAKE SURE THE ITEM IS NOT ALREADY BOXED.
			Dim _retVal As Boolean
			Dim _dev As New Data.BOL.tDevice(sn, False)
			_retVal = _dev.Pallett_ID > 0
			_dev = Nothing
			Return _retVal
		End Function
		Private Sub PrintTheLabel(ByVal box_id As String, ByVal model_desc As String, ByVal box_qty As Integer, ByVal box_type As String)
			' PRINTS THE BOX LABEL.
			Dim _objTFRec As New PSS.Data.Buisness.TracFone.Receive()
			_objTFRec.PrintWarehouseBoxReceivedLabel(box_id, model_desc, box_qty, "0000", box_type)
		End Sub
		Private Sub DeleteExistingPallet(ByVal pallet_id As Integer)
			If pallet_id > 0 Then
				Dim _p As New Data.BLL.PalletFactory()
				_p.DeletePallet(pallet_id)
				_p = Nothing
			End If
		End Sub
		Private Sub RemoveAllDevicesFromPallet(ByVal pallet_id As Integer)
			Dim _pf As New Data.BLL.PalletFactory()
			_pf.RemoveAllDevicesFromPallet(pallet_id)
			_pf = Nothing
		End Sub
		Private Function PalletHasFailedDevices() As Boolean
			' THIS FUNCTION CHECKS ALL DEVICES IN THE PALLET TO MAKE SURE THEY
			' ALL HAVE PASS AQL.
			Dim _retVal As Boolean = False
			'Dim item As String
			Try
				Dim i As Integer = 0
				For i = 0 To lbSerialNumbers.Items.Count - 1
					Dim _sn As String = lbSerialNumbers.Items(i).ToString()
					Dim _dev As New Data.BOL.tDevice(_sn, False)
					Dim _device_id As Integer = _dev.Device_ID
					Dim _dqcCol As New Data.BOL.tqcDeviceQcCollection(_device_id, 4)
					If _dqcCol.tqcDataTable.Rows.Count = 0 Then
						_retVal = False
					Else
						If _dqcCol.tqcDataTable.Rows(0)("qcresult_id") <> 1 Then
							_retVal = True
							Exit For
						End If
					End If
					_dev = Nothing
					_dqcCol = Nothing
				Next
				Return _retVal
			Catch ex As Exception
				Throw New Exception("This pallet has devices that have not passed AQL.")
			End Try
		End Function
		Private Sub PrintPalletLabel(ByVal pallet_id As Integer, ByVal model_id As Integer, ByVal box_type As String)
			' PRINTS A WAREHOUSE BOX LABEL ASSOCIATED TO THE SERIAL NUMBER.
			Dim _p As New Data.BOL.tpallet(pallet_id)
			If _p.Pallett_ID > 0 Then
				Dim _m As New Data.BOL.tmodel(model_id)
				PrintTheLabel(_p.Pallett_Name, _m.Model_Desc, _p.Pallett_QTY, box_type)
				_m = Nothing
				txtPrintSN.Text = ""
				pnlMain.Visible = True
				pnlMain.Enabled = True
				pnlReprint.Visible = False
				pnlReprint.Enabled = False
			Else
				MessageBox.Show("The serial number could not be found within a box.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				txtPrintSN.Text = ""
				txtPrintSN.Focus()
			End If
			_p = Nothing
		End Sub
		Private Sub PrintWBoxLabel(ByVal _sn As String)
			' PRINTS A WAREHOUSE BOX LABEL ASSOCIATED TO THE SERIAL NUMBER.
			Dim _box_type As String = ""
			Dim _ro_whb As New Data.BOL.wh_box_by_sn_readonly(txtPrintSN.Text)
			If _ro_whb.whb_id > 0 Then
				' GET THE BOX TYPE.
				Dim _disp As New Data.BOL.tdispositions(_ro_whb.disp_id)
				If _disp.disp_id > 0 Then
					_box_type = _disp.disp_cd
				Else
					_box_type = ""
				End If
				_disp = Nothing
				PrintTheLabel(_ro_whb.box_na, _ro_whb.model_desc, _ro_whb.quantity, _box_type)
				txtPrintSN.Text = ""
				pnlMain.Visible = True
				pnlMain.Enabled = True
				pnlReprint.Visible = False
				pnlReprint.Enabled = False
			Else
				MessageBox.Show("The serial number could not be found within a box.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				txtPrintSN.Text = ""
				txtPrintSN.Focus()
			End If
		End Sub
		Private Sub UpdatePalletCount(ByVal pallet_id As Integer)
			Dim _retVal As Integer = 0
			Dim _p As New Data.BOL.tpallet(pallet_id)
			If _p.Pallett_ID > 0 Then
				Dim _pf As New Data.BLL.PalletFactory()
				_p.Pallett_QTY = _pf.GetPalletQty(pallet_id)
				If _p.Pallett_QTY = 0 Then
					_p.MarkForDeletion()
				End If
				_p.ApplyChanges()
				_pf = Nothing
			End If
		End Sub
		Private Sub ClearAll()
			_existingPalletID = 0
			_existingPalletName = ""
			_using_existing_box = False
			lbSerialNumbers.Items.Clear()
			ClearMsg()
			UpdateCounter()
			txtModifyBoxNr.Text = ""
			pnlMain.Visible = True
			pnlMain.Enabled = True
			pnlReprint.Visible = False
			pnlRemoveItem.Visible = False
			pnlModifyBox.Visible = False
			lblBoxName.Text = _existingPalletName
			EnableControls()
		End Sub
#End Region
	End Class
End Namespace
