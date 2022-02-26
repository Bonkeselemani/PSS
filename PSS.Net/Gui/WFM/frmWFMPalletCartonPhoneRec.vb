Namespace Gui.WFMTracfone

	Public Class frmWFMPalletCartonPhoneRec
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
		Friend WithEvents Panel1 As System.Windows.Forms.Panel
		Friend WithEvents Panel2 As System.Windows.Forms.Panel
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents pbX As System.Windows.Forms.PictureBox
		Friend WithEvents pbCheck As System.Windows.Forms.PictureBox
		Friend WithEvents Label9 As System.Windows.Forms.Label
		Friend WithEvents txtAsnSku As System.Windows.Forms.TextBox
		Friend WithEvents txtAsnCarton As System.Windows.Forms.TextBox
		Friend WithEvents txtAsnPallet As System.Windows.Forms.TextBox
		Friend WithEvents txtSN As System.Windows.Forms.TextBox
		Friend WithEvents txtCarton As System.Windows.Forms.TextBox
		Friend WithEvents txtPallet As System.Windows.Forms.TextBox
		Friend WithEvents txtSku As System.Windows.Forms.TextBox
		Friend WithEvents btnRecWDescrepancy As System.Windows.Forms.Button
		Friend WithEvents cbPallet As System.Windows.Forms.CheckBox
		Friend WithEvents cbCarton As System.Windows.Forms.CheckBox
		Friend WithEvents cbSku As System.Windows.Forms.CheckBox
		Friend WithEvents cbSN As System.Windows.Forms.CheckBox
		Friend WithEvents pnlDescrepancy As System.Windows.Forms.Panel
		Friend WithEvents txtComments As System.Windows.Forms.TextBox
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents lblNoMatch As System.Windows.Forms.Label
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents txtAsnSn As System.Windows.Forms.TextBox
		Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents pbSku As System.Windows.Forms.PictureBox
		Friend WithEvents pbSN As System.Windows.Forms.PictureBox
		Friend WithEvents pbCarton As System.Windows.Forms.PictureBox
		Friend WithEvents pbPallet As System.Windows.Forms.PictureBox
		Friend WithEvents dgSNs As System.Windows.Forms.DataGrid
		Friend WithEvents txtCartonCnt As System.Windows.Forms.TextBox
		Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
		Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWFMPalletCartonPhoneRec))
			Me.Panel1 = New System.Windows.Forms.Panel()
			Me.Label8 = New System.Windows.Forms.Label()
			Me.txtAsnSn = New System.Windows.Forms.TextBox()
			Me.txtAsnSku = New System.Windows.Forms.TextBox()
			Me.txtAsnCarton = New System.Windows.Forms.TextBox()
			Me.txtAsnPallet = New System.Windows.Forms.TextBox()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.lblNoMatch = New System.Windows.Forms.Label()
			Me.Panel2 = New System.Windows.Forms.Panel()
			Me.dgSNs = New System.Windows.Forms.DataGrid()
			Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
			Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.txtComments = New System.Windows.Forms.TextBox()
			Me.Label10 = New System.Windows.Forms.Label()
			Me.pnlDescrepancy = New System.Windows.Forms.Panel()
			Me.cbPallet = New System.Windows.Forms.CheckBox()
			Me.btnRecWDescrepancy = New System.Windows.Forms.Button()
			Me.cbSN = New System.Windows.Forms.CheckBox()
			Me.cbCarton = New System.Windows.Forms.CheckBox()
			Me.cbSku = New System.Windows.Forms.CheckBox()
			Me.pbSku = New System.Windows.Forms.PictureBox()
			Me.txtSku = New System.Windows.Forms.TextBox()
			Me.Label9 = New System.Windows.Forms.Label()
			Me.pbCheck = New System.Windows.Forms.PictureBox()
			Me.pbX = New System.Windows.Forms.PictureBox()
			Me.pbSN = New System.Windows.Forms.PictureBox()
			Me.pbCarton = New System.Windows.Forms.PictureBox()
			Me.pbPallet = New System.Windows.Forms.PictureBox()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.txtSN = New System.Windows.Forms.TextBox()
			Me.txtCarton = New System.Windows.Forms.TextBox()
			Me.txtPallet = New System.Windows.Forms.TextBox()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.Label6 = New System.Windows.Forms.Label()
			Me.Label7 = New System.Windows.Forms.Label()
			Me.txtCartonCnt = New System.Windows.Forms.TextBox()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.dgSNs, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlDescrepancy.SuspendLayout()
			Me.SuspendLayout()
			'
			'Panel1
			'
			Me.Panel1.BackColor = System.Drawing.Color.LightGray
			Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.txtAsnSn, Me.txtAsnSku, Me.txtAsnCarton, Me.txtAsnPallet, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.lblNoMatch})
			Me.Panel1.Location = New System.Drawing.Point(8, 8)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New System.Drawing.Size(768, 128)
			Me.Panel1.TabIndex = 0
			'
			'Label8
			'
			Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label8.Location = New System.Drawing.Point(144, 96)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New System.Drawing.Size(112, 23)
			Me.Label8.TabIndex = 32
			Me.Label8.Text = "Serial Number:"
			Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'txtAsnSn
			'
			Me.txtAsnSn.BackColor = System.Drawing.Color.Silver
			Me.txtAsnSn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtAsnSn.ForeColor = System.Drawing.Color.Blue
			Me.txtAsnSn.Location = New System.Drawing.Point(264, 96)
			Me.txtAsnSn.Name = "txtAsnSn"
			Me.txtAsnSn.ReadOnly = True
			Me.txtAsnSn.Size = New System.Drawing.Size(232, 23)
			Me.txtAsnSn.TabIndex = 31
			Me.txtAsnSn.TabStop = False
			Me.txtAsnSn.Text = ""
			'
			'txtAsnSku
			'
			Me.txtAsnSku.BackColor = System.Drawing.Color.Silver
			Me.txtAsnSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtAsnSku.ForeColor = System.Drawing.Color.Black
			Me.txtAsnSku.Location = New System.Drawing.Point(520, 64)
			Me.txtAsnSku.Name = "txtAsnSku"
			Me.txtAsnSku.ReadOnly = True
			Me.txtAsnSku.Size = New System.Drawing.Size(232, 23)
			Me.txtAsnSku.TabIndex = 6
			Me.txtAsnSku.TabStop = False
			Me.txtAsnSku.Text = ""
			'
			'txtAsnCarton
			'
			Me.txtAsnCarton.BackColor = System.Drawing.Color.Silver
			Me.txtAsnCarton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtAsnCarton.ForeColor = System.Drawing.Color.Black
			Me.txtAsnCarton.Location = New System.Drawing.Point(264, 64)
			Me.txtAsnCarton.Name = "txtAsnCarton"
			Me.txtAsnCarton.ReadOnly = True
			Me.txtAsnCarton.Size = New System.Drawing.Size(232, 23)
			Me.txtAsnCarton.TabIndex = 5
			Me.txtAsnCarton.TabStop = False
			Me.txtAsnCarton.Text = ""
			'
			'txtAsnPallet
			'
			Me.txtAsnPallet.BackColor = System.Drawing.Color.Silver
			Me.txtAsnPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtAsnPallet.ForeColor = System.Drawing.Color.Black
			Me.txtAsnPallet.Location = New System.Drawing.Point(8, 64)
			Me.txtAsnPallet.Name = "txtAsnPallet"
			Me.txtAsnPallet.ReadOnly = True
			Me.txtAsnPallet.Size = New System.Drawing.Size(232, 23)
			Me.txtAsnPallet.TabIndex = 4
			Me.txtAsnPallet.TabStop = False
			Me.txtAsnPallet.Text = ""
			'
			'Label4
			'
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label4.Location = New System.Drawing.Point(528, 40)
			Me.Label4.Name = "Label4"
			Me.Label4.TabIndex = 3
			Me.Label4.Text = "Sku"
			'
			'Label3
			'
			Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.Location = New System.Drawing.Point(272, 40)
			Me.Label3.Name = "Label3"
			Me.Label3.TabIndex = 2
			Me.Label3.Text = "Carton"
			'
			'Label2
			'
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.Location = New System.Drawing.Point(16, 40)
			Me.Label2.Name = "Label2"
			Me.Label2.TabIndex = 1
			Me.Label2.Text = "Pallet"
			'
			'Label1
			'
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
			Me.Label1.Location = New System.Drawing.Point(16, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(320, 23)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "ASN file values for the scanned serial number"
			'
			'lblNoMatch
			'
			Me.lblNoMatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblNoMatch.ForeColor = System.Drawing.Color.Red
			Me.lblNoMatch.Location = New System.Drawing.Point(424, 8)
			Me.lblNoMatch.Name = "lblNoMatch"
			Me.lblNoMatch.Size = New System.Drawing.Size(242, 23)
			Me.lblNoMatch.TabIndex = 30
			Me.lblNoMatch.Text = "No Match Found"
			'
			'Panel2
			'
			Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgSNs, Me.btnClear, Me.txtComments, Me.Label10, Me.pnlDescrepancy, Me.pbSku, Me.txtSku, Me.Label9, Me.pbCheck, Me.pbX, Me.pbSN, Me.pbCarton, Me.pbPallet, Me.lblMsg, Me.txtSN, Me.txtCarton, Me.txtPallet, Me.Label5, Me.Label6, Me.Label7, Me.txtCartonCnt})
			Me.Panel2.Location = New System.Drawing.Point(8, 144)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New System.Drawing.Size(768, 288)
			Me.Panel2.TabIndex = 1
			'
			'dgSNs
			'
			Me.dgSNs.CaptionBackColor = System.Drawing.Color.LightSteelBlue
			Me.dgSNs.CaptionForeColor = System.Drawing.Color.Black
			Me.dgSNs.CaptionText = "Received for Carton"
			Me.dgSNs.DataMember = ""
			Me.dgSNs.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dgSNs.Location = New System.Drawing.Point(576, 16)
			Me.dgSNs.Name = "dgSNs"
			Me.dgSNs.ReadOnly = True
			Me.dgSNs.Size = New System.Drawing.Size(176, 168)
			Me.dgSNs.TabIndex = 30
			Me.dgSNs.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
			Me.dgSNs.TabStop = False
			'
			'DataGridTableStyle1
			'
			Me.DataGridTableStyle1.DataGrid = Me.dgSNs
			Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1})
			Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.DataGridTableStyle1.MappingName = ""
			'
			'DataGridTextBoxColumn1
			'
			Me.DataGridTextBoxColumn1.Format = ""
			Me.DataGridTextBoxColumn1.FormatInfo = Nothing
			Me.DataGridTextBoxColumn1.HeaderText = "Serial #"
			Me.DataGridTextBoxColumn1.MappingName = "serial_nr"
			Me.DataGridTextBoxColumn1.Width = 200
			'
			'btnClear
			'
			Me.btnClear.Location = New System.Drawing.Point(120, 200)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(88, 23)
			Me.btnClear.TabIndex = 4
			Me.btnClear.TabStop = False
			Me.btnClear.Text = "Clear All"
			'
			'txtComments
			'
			Me.txtComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtComments.Location = New System.Drawing.Point(128, 232)
			Me.txtComments.Multiline = True
			Me.txtComments.Name = "txtComments"
			Me.txtComments.Size = New System.Drawing.Size(624, 40)
			Me.txtComments.TabIndex = 29
			Me.txtComments.TabStop = False
			Me.txtComments.Text = ""
			'
			'Label10
			'
			Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label10.Location = New System.Drawing.Point(24, 232)
			Me.Label10.Name = "Label10"
			Me.Label10.TabIndex = 28
			Me.Label10.Text = "Comments:"
			Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'pnlDescrepancy
			'
			Me.pnlDescrepancy.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbPallet, Me.btnRecWDescrepancy, Me.cbSN, Me.cbCarton, Me.cbSku})
			Me.pnlDescrepancy.Location = New System.Drawing.Point(328, 16)
			Me.pnlDescrepancy.Name = "pnlDescrepancy"
			Me.pnlDescrepancy.Size = New System.Drawing.Size(241, 192)
			Me.pnlDescrepancy.TabIndex = 27
			'
			'cbPallet
			'
			Me.cbPallet.Enabled = False
			Me.cbPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cbPallet.Location = New System.Drawing.Point(16, 8)
			Me.cbPallet.Name = "cbPallet"
			Me.cbPallet.Size = New System.Drawing.Size(216, 24)
			Me.cbPallet.TabIndex = 0
			Me.cbPallet.Text = "Pallet does not match ASN file."
			'
			'btnRecWDescrepancy
			'
			Me.btnRecWDescrepancy.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
			Me.btnRecWDescrepancy.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnRecWDescrepancy.Location = New System.Drawing.Point(40, 144)
			Me.btnRecWDescrepancy.Name = "btnRecWDescrepancy"
			Me.btnRecWDescrepancy.Size = New System.Drawing.Size(192, 32)
			Me.btnRecWDescrepancy.TabIndex = 4
			Me.btnRecWDescrepancy.Text = "Receive with Discrepancies"
			'
			'cbSN
			'
			Me.cbSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cbSN.ForeColor = System.Drawing.Color.Blue
			Me.cbSN.Location = New System.Drawing.Point(16, 104)
			Me.cbSN.Name = "cbSN"
			Me.cbSN.Size = New System.Drawing.Size(224, 24)
			Me.cbSN.TabIndex = 3
			Me.cbSN.Text = "Receive as extra device."
			'
			'cbCarton
			'
			Me.cbCarton.Enabled = False
			Me.cbCarton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cbCarton.Location = New System.Drawing.Point(16, 40)
			Me.cbCarton.Name = "cbCarton"
			Me.cbCarton.Size = New System.Drawing.Size(224, 24)
			Me.cbCarton.TabIndex = 1
			Me.cbCarton.Text = "Carton does not match ASN file."
			'
			'cbSku
			'
			Me.cbSku.Enabled = False
			Me.cbSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cbSku.Location = New System.Drawing.Point(16, 72)
			Me.cbSku.Name = "cbSku"
			Me.cbSku.Size = New System.Drawing.Size(224, 24)
			Me.cbSku.TabIndex = 2
			Me.cbSku.Text = "Sku does not match ASN file."
			'
			'pbSku
			'
			Me.pbSku.Image = CType(resources.GetObject("pbSku.Image"), System.Drawing.Bitmap)
			Me.pbSku.Location = New System.Drawing.Point(304, 88)
			Me.pbSku.Name = "pbSku"
			Me.pbSku.Size = New System.Drawing.Size(16, 16)
			Me.pbSku.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbSku.TabIndex = 21
			Me.pbSku.TabStop = False
			'
			'txtSku
			'
			Me.txtSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtSku.Location = New System.Drawing.Point(120, 88)
			Me.txtSku.Name = "txtSku"
			Me.txtSku.Size = New System.Drawing.Size(176, 23)
			Me.txtSku.TabIndex = 2
			Me.txtSku.Text = ""
			'
			'Label9
			'
			Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label9.Location = New System.Drawing.Point(8, 88)
			Me.Label9.Name = "Label9"
			Me.Label9.TabIndex = 19
			Me.Label9.Text = "Sku:"
			Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'pbCheck
			'
			Me.pbCheck.Image = CType(resources.GetObject("pbCheck.Image"), System.Drawing.Bitmap)
			Me.pbCheck.Location = New System.Drawing.Point(304, 160)
			Me.pbCheck.Name = "pbCheck"
			Me.pbCheck.Size = New System.Drawing.Size(16, 16)
			Me.pbCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbCheck.TabIndex = 18
			Me.pbCheck.TabStop = False
			Me.pbCheck.Visible = False
			'
			'pbX
			'
			Me.pbX.Image = CType(resources.GetObject("pbX.Image"), System.Drawing.Bitmap)
			Me.pbX.Location = New System.Drawing.Point(304, 184)
			Me.pbX.Name = "pbX"
			Me.pbX.Size = New System.Drawing.Size(16, 16)
			Me.pbX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbX.TabIndex = 17
			Me.pbX.TabStop = False
			Me.pbX.Visible = False
			'
			'pbSN
			'
			Me.pbSN.Image = CType(resources.GetObject("pbSN.Image"), System.Drawing.Bitmap)
			Me.pbSN.Location = New System.Drawing.Point(304, 120)
			Me.pbSN.Name = "pbSN"
			Me.pbSN.Size = New System.Drawing.Size(16, 16)
			Me.pbSN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbSN.TabIndex = 16
			Me.pbSN.TabStop = False
			'
			'pbCarton
			'
			Me.pbCarton.Image = CType(resources.GetObject("pbCarton.Image"), System.Drawing.Bitmap)
			Me.pbCarton.Location = New System.Drawing.Point(304, 56)
			Me.pbCarton.Name = "pbCarton"
			Me.pbCarton.Size = New System.Drawing.Size(16, 16)
			Me.pbCarton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbCarton.TabIndex = 15
			Me.pbCarton.TabStop = False
			'
			'pbPallet
			'
			Me.pbPallet.Image = CType(resources.GetObject("pbPallet.Image"), System.Drawing.Bitmap)
			Me.pbPallet.Location = New System.Drawing.Point(304, 24)
			Me.pbPallet.Name = "pbPallet"
			Me.pbPallet.Size = New System.Drawing.Size(16, 16)
			Me.pbPallet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbPallet.TabIndex = 14
			Me.pbPallet.TabStop = False
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(8, 152)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(288, 40)
			Me.lblMsg.TabIndex = 13
			'
			'txtSN
			'
			Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtSN.Location = New System.Drawing.Point(120, 120)
			Me.txtSN.Name = "txtSN"
			Me.txtSN.Size = New System.Drawing.Size(176, 23)
			Me.txtSN.TabIndex = 3
			Me.txtSN.Text = ""
			'
			'txtCarton
			'
			Me.txtCarton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtCarton.Location = New System.Drawing.Point(120, 56)
			Me.txtCarton.Name = "txtCarton"
			Me.txtCarton.Size = New System.Drawing.Size(176, 23)
			Me.txtCarton.TabIndex = 1
			Me.txtCarton.Text = ""
			'
			'txtPallet
			'
			Me.txtPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtPallet.Location = New System.Drawing.Point(120, 24)
			Me.txtPallet.Name = "txtPallet"
			Me.txtPallet.Size = New System.Drawing.Size(176, 23)
			Me.txtPallet.TabIndex = 0
			Me.txtPallet.Text = ""
			'
			'Label5
			'
			Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label5.Location = New System.Drawing.Point(8, 120)
			Me.Label5.Name = "Label5"
			Me.Label5.TabIndex = 9
			Me.Label5.Text = "Serial Number:"
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'Label6
			'
			Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label6.Location = New System.Drawing.Point(8, 56)
			Me.Label6.Name = "Label6"
			Me.Label6.TabIndex = 8
			Me.Label6.Text = "Carton:"
			Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'Label7
			'
			Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label7.Location = New System.Drawing.Point(8, 24)
			Me.Label7.Name = "Label7"
			Me.Label7.TabIndex = 7
			Me.Label7.Text = "Pallet:"
			Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'txtCartonCnt
			'
			Me.txtCartonCnt.BackColor = System.Drawing.Color.DodgerBlue
			Me.txtCartonCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtCartonCnt.ForeColor = System.Drawing.Color.Black
			Me.txtCartonCnt.Location = New System.Drawing.Point(576, 184)
			Me.txtCartonCnt.Name = "txtCartonCnt"
			Me.txtCartonCnt.ReadOnly = True
			Me.txtCartonCnt.Size = New System.Drawing.Size(176, 23)
			Me.txtCartonCnt.TabIndex = 33
			Me.txtCartonCnt.TabStop = False
			Me.txtCartonCnt.Text = ""
			Me.txtCartonCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'frmWFMPalletCartonPhoneRec
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
			Me.ClientSize = New System.Drawing.Size(784, 438)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.Panel2})
			Me.Name = "frmWFMPalletCartonPhoneRec"
			Me.Text = "frmWFMPalletCartonPhoneRec"
			Me.Panel1.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			CType(Me.dgSNs, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlDescrepancy.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"

		Private _returnSku As String = ""

#End Region
#Region "FORM EVENTS"

		Private Sub frmWFMPalletCartonPhoneRec_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			ClearAll()
			SetCheckboxes()
			EnableControls()
		End Sub

#End Region
#Region "CONTROL EVENTS"

		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			ClearAll()
		End Sub
		Private Sub txtPallet_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPallet.KeyUp
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				SearchASNForPallet()
				SetCheckboxes()
				EnableControls()
				If e.KeyCode = Keys.Enter Then txtCarton.Focus()
			End If
		End Sub
		Private Sub txtCarton_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarton.KeyUp
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				SearchASNForCarton()
				GetCartonSNs()
				SetCheckboxes()
				EnableControls()
				txtSku.Focus()
			End If
		End Sub
		Private Sub txtSku_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSku.KeyUp
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				SearchASNForSku()
				SetCheckboxes()
				EnableControls()
				txtSN.Focus()
			End If
		End Sub
		Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
			ClearASN()
			If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
				SearchASNForSN()
				SetCheckboxes()
				EnableControls()
				If ReadyToReceive() Then
					Receive()
					SetCheckboxes()
					EnableControls()
				Else
					SearchASNForSN()
					SetCheckboxes()
					EnableControls()
				End If
			End If
		End Sub
		Private Sub btnRecWDescrepancy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecWDescrepancy.Click
			Dim _dr As New DialogResult()
			_dr = MessageBox.Show("Are you sure you want to receive this device with descrepancies?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
			If _dr = DialogResult.Yes Then
				Receive()
				If _returnSku <> "" Then
					txtSku.Text = _returnSku
					_returnSku = ""
				End If
				SetCheckboxes()
				EnableControls()
			End If
		End Sub
		Private Sub cbSN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSN.CheckedChanged
			If cbSN.Checked Then
				_returnSku = txtSku.Text
				txtSku.Text = ""
				MessageBox.Show("Please re-enter the Sku for the box.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
				SetCheckboxes()
				EnableControls()
				txtSku.Focus()
			End If
		End Sub

#End Region
#Region "PROPERTIES"

		Private ReadOnly Property PalletMatch() As Boolean
			Get
				Return txtAsnPallet.Text = txtPallet.Text
			End Get
		End Property
		Private ReadOnly Property CartonMatch() As Boolean
			Get
				Return txtAsnCarton.Text = txtCarton.Text
			End Get
		End Property
		Private ReadOnly Property SnMatch() As Boolean
			Get
				Return txtAsnSn.Text = txtSN.Text
			End Get
		End Property
		Private ReadOnly Property SkuMatch() As Boolean
			Get
				Return txtAsnSku.Text = txtSku.Text
			End Get
		End Property
		Private ReadOnly Property ReadyToReceive() As Boolean
			Get
				If _
				 txtSN.Text <> "" AndAlso _
				 txtPallet.Text <> "" AndAlso _
				 txtCarton.Text <> "" Then
					If PalletMatch AndAlso CartonMatch AndAlso SnMatch And SkuMatch Then
						Return True
					Else
						Return False
					End If
				Else
					Return False
				End If
			End Get
		End Property

#End Region
#Region "METHODS"

		Private Sub ClearAll()
			ClearASN()
			ClearPhone()
			ClearPallet()
			EnableControls()
		End Sub
		Private Sub ClearASN()
			txtAsnPallet.Text = ""
			txtAsnCarton.Text = ""
			txtAsnSku.Text = ""
			txtAsnSn.Text = ""
		End Sub
		Private Sub ClearPhone()
			txtSN.Text = ""
			txtComments.Text = ""
			cbPallet.Checked = False
			cbCarton.Checked = False
			cbSN.Checked = False
			cbSku.Checked = False
		End Sub
		Private Sub ClearPallet()
			txtPallet.Text = ""
			txtCarton.Text = ""
			txtSku.Text = ""
			_returnSku = ""
			dgSNs.DataSource = Nothing
			txtCartonCnt.Text = ""
		End Sub
		Private Sub EnableControls()
			pnlDescrepancy.Visible = _
			(cbPallet.Checked OrElse _
			cbCarton.Checked OrElse _
			cbSku.Checked OrElse _
			txtSN.Text <> txtAsnSn.Text)
			lblNoMatch.Visible = Not SnMatch
		End Sub
		Private Sub SetCheckboxes()
			pbPallet.Image = IIf(PalletMatch, pbCheck.Image, pbX.Image)
			pbCarton.Image = IIf(CartonMatch, pbCheck.Image, pbX.Image)
			pbSN.Image = IIf(SnMatch, pbCheck.Image, pbX.Image)
			pbSku.Image = IIf(SkuMatch, pbCheck.Image, pbX.Image)
			pbPallet.Visible = txtPallet.Text <> ""
			pbCarton.Visible = txtCarton.Text <> ""
			pbSku.Visible = txtSku.Text <> ""
			pbSN.Visible = txtSN.Text <> ""
			cbPallet.Checked = Not PalletMatch
			cbCarton.Checked = Not CartonMatch
			cbSku.Checked = Not SkuMatch
		End Sub
		Private Sub SearchASNForPallet()
			Dim _asn As New Data.BOL.ttf_bx_phn_asn(txtPallet.Text, "", "", "")
			If _asn.bpasn_id > 0 Then
				txtAsnPallet.Text = _asn.pallet
			End If
		End Sub
		Private Sub SearchASNForCarton()
			Dim _asn As New Data.BOL.ttf_bx_phn_asn(txtPallet.Text, txtCarton.Text, "", "")
			If _asn.bpasn_id > 0 Then
				txtAsnPallet.Text = _asn.pallet
				txtAsnCarton.Text = _asn.carton
			End If
		End Sub
		Private Sub SearchASNForSku()
			Dim _asn As New Data.BOL.ttf_bx_phn_asn(txtPallet.Text, txtCarton.Text, txtSku.Text, "")
			If _asn.bpasn_id > 0 Then
				txtAsnPallet.Text = _asn.pallet
				txtAsnCarton.Text = _asn.carton
				txtAsnSku.Text = _asn.sku
			End If
		End Sub
		Private Sub SearchASNForSN()
			Dim _asn As New Data.BOL.ttf_bx_phn_asn(txtSN.Text)
			If _asn.bpasn_id > 0 Then
				txtAsnPallet.Text = _asn.pallet
				txtAsnCarton.Text = _asn.carton
				txtAsnSku.Text = _asn.sku
				txtAsnSn.Text = _asn.serial_nr
			End If
		End Sub
		Private Sub Receive()
			Try
				Dim _tfpp As New Data.BOL.ttf_bx_phn_received()
				_tfpp.pallet = txtPallet.Text
				_tfpp.carton = txtCarton.Text
				_tfpp.serial_nr = txtSN.Text
				_tfpp.date_rec = Date.Now.Date()
				_tfpp.loc_desc = ""
				_tfpp.sku = txtSku.Text
				_tfpp.make = ""
				_tfpp.model = ""
				_tfpp.pallet_diff = cbPallet.Checked
				_tfpp.carton_diff = cbCarton.Checked
				_tfpp.sn_extra = cbSN.Checked
				_tfpp.sku_diff = cbSku.Checked
				_tfpp.comments = txtComments.Text
				_tfpp.crt_by = PSS.Core.Global.ApplicationUser.IDuser
				_tfpp.ApplyChanges()
				ClearPhone()
				ClearASN()
				SearchASNForSku()
				GetCartonSNs()
			Catch ex As Exception
				MessageBox.Show("Unable to receive this record." & vbCrLf & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Sub GetCartonSNs()
			Dim _obj As New Data.BOL.ttf_bx_phn_receivedCollection(txtPallet.Text, txtCarton.Text)
			dgSNs.DataSource = Nothing
			dgSNs.DataSource = _obj.ttf_bx_phn_receivedDataTable
			txtCartonCnt.Text = _obj.ttf_bx_phn_receivedDataTable.Rows.Count.ToString()
		End Sub

#End Region

	End Class

End Namespace
