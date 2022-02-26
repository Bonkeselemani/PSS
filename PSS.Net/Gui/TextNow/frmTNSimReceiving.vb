Imports System.Text

Namespace Gui.TextNow

	Public Class frmTNSimReceiving
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
		Friend WithEvents txtNotes As System.Windows.Forms.TextBox
		Friend WithEvents txtEndSN As System.Windows.Forms.TextBox
		Friend WithEvents txtStartSN As System.Windows.Forms.TextBox
		Friend WithEvents txtDateRec As System.Windows.Forms.TextBox
		Friend WithEvents txtCust As System.Windows.Forms.TextBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents Label9 As System.Windows.Forms.Label
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents Label11 As System.Windows.Forms.Label
		Friend WithEvents Label12 As System.Windows.Forms.Label
		Friend WithEvents Label13 As System.Windows.Forms.Label
		Friend WithEvents txtSku As System.Windows.Forms.TextBox
		Friend WithEvents txtQty As System.Windows.Forms.TextBox
		Friend WithEvents btnRec As System.Windows.Forms.Button
		Friend WithEvents Panel1 As System.Windows.Forms.Panel
		Friend WithEvents Panel2 As System.Windows.Forms.Panel
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents txtPartNr As System.Windows.Forms.TextBox
		Friend WithEvents txtSkuEntry As System.Windows.Forms.TextBox
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents pnlGSM As System.Windows.Forms.Panel
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents Label15 As System.Windows.Forms.Label
		Friend WithEvents Label17 As System.Windows.Forms.Label
		Friend WithEvents Label14 As System.Windows.Forms.Label
		Friend WithEvents Label16 As System.Windows.Forms.Label
		Friend WithEvents Label18 As System.Windows.Forms.Label
		Friend WithEvents Label19 As System.Windows.Forms.Label
		Friend WithEvents txtGsmStartSuffix As System.Windows.Forms.TextBox
		Friend WithEvents txtGsmStartPrefix As System.Windows.Forms.TextBox
		Friend WithEvents txtGsmStartCs As System.Windows.Forms.TextBox
		Friend WithEvents txtGsmStartIncr As System.Windows.Forms.TextBox
		Friend WithEvents txtGsmEndIncr As System.Windows.Forms.TextBox
		Friend WithEvents txtGsmEndCs As System.Windows.Forms.TextBox
		Friend WithEvents txtGsmEndSuffix As System.Windows.Forms.TextBox
		Friend WithEvents txtGsmEndPrefix As System.Windows.Forms.TextBox
		Friend WithEvents pnlCDMA As System.Windows.Forms.Panel
		Friend WithEvents txtCdmaEndIncr As System.Windows.Forms.TextBox
		Friend WithEvents txtCdmaEndCs As System.Windows.Forms.TextBox
		Friend WithEvents txtCdmaEndPrefix As System.Windows.Forms.TextBox
		Friend WithEvents txtCdmaStartIncr As System.Windows.Forms.TextBox
		Friend WithEvents txtCdmaStartCs As System.Windows.Forms.TextBox
		Friend WithEvents txtCdmaStartPrefix As System.Windows.Forms.TextBox
		Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents btnGenerate As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtSkuEntry = New System.Windows.Forms.TextBox()
            Me.txtNotes = New System.Windows.Forms.TextBox()
            Me.txtEndSN = New System.Windows.Forms.TextBox()
            Me.txtStartSN = New System.Windows.Forms.TextBox()
            Me.txtDateRec = New System.Windows.Forms.TextBox()
            Me.txtCust = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.txtSku = New System.Windows.Forms.TextBox()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.btnRec = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtPartNr = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnGenerate = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.lblMsg = New System.Windows.Forms.Label()
            Me.pnlGSM = New System.Windows.Forms.Panel()
            Me.txtGsmEndIncr = New System.Windows.Forms.TextBox()
            Me.txtGsmEndCs = New System.Windows.Forms.TextBox()
            Me.txtGsmEndSuffix = New System.Windows.Forms.TextBox()
            Me.txtGsmEndPrefix = New System.Windows.Forms.TextBox()
            Me.txtGsmStartIncr = New System.Windows.Forms.TextBox()
            Me.txtGsmStartCs = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtGsmStartSuffix = New System.Windows.Forms.TextBox()
            Me.txtGsmStartPrefix = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.pnlCDMA = New System.Windows.Forms.Panel()
            Me.txtCdmaEndIncr = New System.Windows.Forms.TextBox()
            Me.txtCdmaEndCs = New System.Windows.Forms.TextBox()
            Me.txtCdmaEndPrefix = New System.Windows.Forms.TextBox()
            Me.txtCdmaStartIncr = New System.Windows.Forms.TextBox()
            Me.txtCdmaStartCs = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtCdmaStartPrefix = New System.Windows.Forms.TextBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.pnlGSM.SuspendLayout()
            Me.pnlCDMA.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtSkuEntry
            '
            Me.txtSkuEntry.BackColor = System.Drawing.Color.Yellow
            Me.txtSkuEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSkuEntry.Location = New System.Drawing.Point(112, 16)
            Me.txtSkuEntry.Name = "txtSkuEntry"
            Me.txtSkuEntry.Size = New System.Drawing.Size(216, 22)
            Me.txtSkuEntry.TabIndex = 0
            Me.txtSkuEntry.Text = ""
            '
            'txtNotes
            '
            Me.txtNotes.Location = New System.Drawing.Point(112, 136)
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.Size = New System.Drawing.Size(216, 72)
            Me.txtNotes.TabIndex = 3
            Me.txtNotes.Text = ""
            '
            'txtEndSN
            '
            Me.txtEndSN.BackColor = System.Drawing.Color.Yellow
            Me.txtEndSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtEndSN.Location = New System.Drawing.Point(112, 96)
            Me.txtEndSN.Name = "txtEndSN"
            Me.txtEndSN.Size = New System.Drawing.Size(216, 22)
            Me.txtEndSN.TabIndex = 2
            Me.txtEndSN.Text = ""
            '
            'txtStartSN
            '
            Me.txtStartSN.BackColor = System.Drawing.Color.Yellow
            Me.txtStartSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtStartSN.Location = New System.Drawing.Point(112, 56)
            Me.txtStartSN.Name = "txtStartSN"
            Me.txtStartSN.Size = New System.Drawing.Size(216, 22)
            Me.txtStartSN.TabIndex = 1
            Me.txtStartSN.Text = ""
            '
            'txtDateRec
            '
            Me.txtDateRec.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtDateRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDateRec.Location = New System.Drawing.Point(552, 72)
            Me.txtDateRec.Name = "txtDateRec"
            Me.txtDateRec.ReadOnly = True
            Me.txtDateRec.Size = New System.Drawing.Size(160, 22)
            Me.txtDateRec.TabIndex = 0
            Me.txtDateRec.TabStop = False
            Me.txtDateRec.Text = ""
            Me.txtDateRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtCust
            '
            Me.txtCust.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCust.Location = New System.Drawing.Point(112, 32)
            Me.txtCust.Name = "txtCust"
            Me.txtCust.ReadOnly = True
            Me.txtCust.Size = New System.Drawing.Size(160, 22)
            Me.txtCust.TabIndex = 6
            Me.txtCust.TabStop = False
            Me.txtCust.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(16, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 23)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "UPC:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(56, 136)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(40, 23)
            Me.Label7.TabIndex = 7
            Me.Label7.Text = "Notes:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(24, 96)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(72, 23)
            Me.Label8.TabIndex = 2
            Me.Label8.Text = "Ending SN:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(24, 56)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(72, 23)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Starting SN:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.Location = New System.Drawing.Point(560, 40)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(144, 23)
            Me.Label10.TabIndex = 9
            Me.Label10.Text = "Date Received"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.Location = New System.Drawing.Point(16, 32)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(80, 23)
            Me.Label11.TabIndex = 5
            Me.Label11.Text = "Customer:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.Location = New System.Drawing.Point(32, 72)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(64, 23)
            Me.Label12.TabIndex = 7
            Me.Label12.Text = "UPC:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label13
            '
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.Location = New System.Drawing.Point(288, 32)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(64, 23)
            Me.Label13.TabIndex = 3
            Me.Label13.Text = "Quantity:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtSku
            '
            Me.txtSku.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSku.Location = New System.Drawing.Point(112, 72)
            Me.txtSku.Name = "txtSku"
            Me.txtSku.ReadOnly = True
            Me.txtSku.Size = New System.Drawing.Size(160, 22)
            Me.txtSku.TabIndex = 8
            Me.txtSku.TabStop = False
            Me.txtSku.Text = ""
            '
            'txtQty
            '
            Me.txtQty.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtQty.Location = New System.Drawing.Point(368, 32)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.ReadOnly = True
            Me.txtQty.Size = New System.Drawing.Size(160, 22)
            Me.txtQty.TabIndex = 4
            Me.txtQty.TabStop = False
            Me.txtQty.Text = ""
            Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnRec
            '
            Me.btnRec.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
            Me.btnRec.Location = New System.Drawing.Point(544, 176)
            Me.btnRec.Name = "btnRec"
            Me.btnRec.Size = New System.Drawing.Size(168, 40)
            Me.btnRec.TabIndex = 4
            Me.btnRec.TabStop = False
            Me.btnRec.Text = "Receive The Serial Range"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.Silver
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.txtPartNr, Me.Label3, Me.txtSku, Me.txtCust, Me.txtDateRec, Me.Label11, Me.Label12, Me.Label10, Me.Label13, Me.txtQty})
            Me.Panel1.Location = New System.Drawing.Point(8, 8)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(728, 112)
            Me.Panel1.TabIndex = 0
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Blue
            Me.Label2.Location = New System.Drawing.Point(8, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(304, 16)
            Me.Label2.TabIndex = 12
            Me.Label2.Text = "Target UPC Information"
            '
            'txtPartNr
            '
            Me.txtPartNr.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtPartNr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPartNr.Location = New System.Drawing.Point(368, 72)
            Me.txtPartNr.Name = "txtPartNr"
            Me.txtPartNr.ReadOnly = True
            Me.txtPartNr.Size = New System.Drawing.Size(160, 22)
            Me.txtPartNr.TabIndex = 11
            Me.txtPartNr.TabStop = False
            Me.txtPartNr.Text = ""
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(288, 72)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(64, 23)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Part #:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.LightGray
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGenerate, Me.btnClear, Me.Label8, Me.Label9, Me.txtStartSN, Me.txtEndSN, Me.btnRec, Me.txtSkuEntry, Me.Label1, Me.lblMsg, Me.Label7, Me.txtNotes, Me.pnlGSM, Me.pnlCDMA})
            Me.Panel2.Location = New System.Drawing.Point(8, 128)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(728, 264)
            Me.Panel2.TabIndex = 1
            '
            'btnGenerate
            '
            Me.btnGenerate.ForeColor = System.Drawing.Color.Green
            Me.btnGenerate.Location = New System.Drawing.Point(424, 176)
            Me.btnGenerate.Name = "btnGenerate"
            Me.btnGenerate.Size = New System.Drawing.Size(112, 40)
            Me.btnGenerate.TabIndex = 29
            Me.btnGenerate.TabStop = False
            Me.btnGenerate.Text = "Generate SNs"
            '
            'btnClear
            '
            Me.btnClear.Location = New System.Drawing.Point(336, 16)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(80, 24)
            Me.btnClear.TabIndex = 8
            Me.btnClear.TabStop = False
            Me.btnClear.Text = "Clear"
            '
            'lblMsg
            '
            Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMsg.ForeColor = System.Drawing.Color.Red
            Me.lblMsg.Location = New System.Drawing.Point(40, 224)
            Me.lblMsg.Name = "lblMsg"
            Me.lblMsg.Size = New System.Drawing.Size(528, 32)
            Me.lblMsg.TabIndex = 7
            Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlGSM
            '
            Me.pnlGSM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlGSM.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtGsmEndIncr, Me.txtGsmEndCs, Me.txtGsmEndSuffix, Me.txtGsmEndPrefix, Me.txtGsmStartIncr, Me.txtGsmStartCs, Me.Label4, Me.txtGsmStartSuffix, Me.txtGsmStartPrefix, Me.Label6, Me.Label5, Me.Label17, Me.Label15})
            Me.pnlGSM.Location = New System.Drawing.Point(448, 16)
            Me.pnlGSM.Name = "pnlGSM"
            Me.pnlGSM.Size = New System.Drawing.Size(264, 136)
            Me.pnlGSM.TabIndex = 2
            '
            'txtGsmEndIncr
            '
            Me.txtGsmEndIncr.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtGsmEndIncr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGsmEndIncr.ForeColor = System.Drawing.Color.Black
            Me.txtGsmEndIncr.Location = New System.Drawing.Point(128, 79)
            Me.txtGsmEndIncr.Name = "txtGsmEndIncr"
            Me.txtGsmEndIncr.ReadOnly = True
            Me.txtGsmEndIncr.Size = New System.Drawing.Size(72, 22)
            Me.txtGsmEndIncr.TabIndex = 27
            Me.txtGsmEndIncr.TabStop = False
            Me.txtGsmEndIncr.Text = ""
            '
            'txtGsmEndCs
            '
            Me.txtGsmEndCs.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtGsmEndCs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGsmEndCs.ForeColor = System.Drawing.Color.Black
            Me.txtGsmEndCs.Location = New System.Drawing.Point(208, 79)
            Me.txtGsmEndCs.Name = "txtGsmEndCs"
            Me.txtGsmEndCs.ReadOnly = True
            Me.txtGsmEndCs.Size = New System.Drawing.Size(16, 22)
            Me.txtGsmEndCs.TabIndex = 26
            Me.txtGsmEndCs.TabStop = False
            Me.txtGsmEndCs.Text = ""
            '
            'txtGsmEndSuffix
            '
            Me.txtGsmEndSuffix.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtGsmEndSuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGsmEndSuffix.ForeColor = System.Drawing.Color.Black
            Me.txtGsmEndSuffix.Location = New System.Drawing.Point(232, 79)
            Me.txtGsmEndSuffix.Name = "txtGsmEndSuffix"
            Me.txtGsmEndSuffix.ReadOnly = True
            Me.txtGsmEndSuffix.Size = New System.Drawing.Size(16, 22)
            Me.txtGsmEndSuffix.TabIndex = 25
            Me.txtGsmEndSuffix.TabStop = False
            Me.txtGsmEndSuffix.Text = ""
            Me.txtGsmEndSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtGsmEndPrefix
            '
            Me.txtGsmEndPrefix.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtGsmEndPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGsmEndPrefix.ForeColor = System.Drawing.Color.Black
            Me.txtGsmEndPrefix.Location = New System.Drawing.Point(8, 79)
            Me.txtGsmEndPrefix.Name = "txtGsmEndPrefix"
            Me.txtGsmEndPrefix.ReadOnly = True
            Me.txtGsmEndPrefix.Size = New System.Drawing.Size(112, 22)
            Me.txtGsmEndPrefix.TabIndex = 24
            Me.txtGsmEndPrefix.TabStop = False
            Me.txtGsmEndPrefix.Text = ""
            '
            'txtGsmStartIncr
            '
            Me.txtGsmStartIncr.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtGsmStartIncr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGsmStartIncr.ForeColor = System.Drawing.Color.Black
            Me.txtGsmStartIncr.Location = New System.Drawing.Point(128, 39)
            Me.txtGsmStartIncr.Name = "txtGsmStartIncr"
            Me.txtGsmStartIncr.ReadOnly = True
            Me.txtGsmStartIncr.Size = New System.Drawing.Size(72, 22)
            Me.txtGsmStartIncr.TabIndex = 23
            Me.txtGsmStartIncr.TabStop = False
            Me.txtGsmStartIncr.Text = ""
            '
            'txtGsmStartCs
            '
            Me.txtGsmStartCs.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtGsmStartCs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGsmStartCs.ForeColor = System.Drawing.Color.Black
            Me.txtGsmStartCs.Location = New System.Drawing.Point(208, 39)
            Me.txtGsmStartCs.Name = "txtGsmStartCs"
            Me.txtGsmStartCs.ReadOnly = True
            Me.txtGsmStartCs.Size = New System.Drawing.Size(16, 22)
            Me.txtGsmStartCs.TabIndex = 22
            Me.txtGsmStartCs.TabStop = False
            Me.txtGsmStartCs.Text = ""
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Blue
            Me.Label4.Location = New System.Drawing.Point(8, 0)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(104, 24)
            Me.Label4.TabIndex = 21
            Me.Label4.Text = "G.S.M Sims"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtGsmStartSuffix
            '
            Me.txtGsmStartSuffix.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtGsmStartSuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGsmStartSuffix.ForeColor = System.Drawing.Color.Black
            Me.txtGsmStartSuffix.Location = New System.Drawing.Point(232, 39)
            Me.txtGsmStartSuffix.Name = "txtGsmStartSuffix"
            Me.txtGsmStartSuffix.ReadOnly = True
            Me.txtGsmStartSuffix.Size = New System.Drawing.Size(16, 22)
            Me.txtGsmStartSuffix.TabIndex = 18
            Me.txtGsmStartSuffix.TabStop = False
            Me.txtGsmStartSuffix.Text = ""
            Me.txtGsmStartSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtGsmStartPrefix
            '
            Me.txtGsmStartPrefix.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtGsmStartPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGsmStartPrefix.ForeColor = System.Drawing.Color.Black
            Me.txtGsmStartPrefix.Location = New System.Drawing.Point(8, 39)
            Me.txtGsmStartPrefix.Name = "txtGsmStartPrefix"
            Me.txtGsmStartPrefix.ReadOnly = True
            Me.txtGsmStartPrefix.Size = New System.Drawing.Size(112, 22)
            Me.txtGsmStartPrefix.TabIndex = 17
            Me.txtGsmStartPrefix.TabStop = False
            Me.txtGsmStartPrefix.Text = ""
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(8, 111)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(104, 16)
            Me.Label6.TabIndex = 17
            Me.Label6.Text = "Prefix"
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(128, 111)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(56, 16)
            Me.Label5.TabIndex = 13
            Me.Label5.Text = "Incremental"
            '
            'Label17
            '
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.Location = New System.Drawing.Point(200, 111)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(24, 16)
            Me.Label17.TabIndex = 21
            Me.Label17.Text = "CS"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label15
            '
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.Location = New System.Drawing.Point(232, 111)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(32, 16)
            Me.Label15.TabIndex = 19
            Me.Label15.Text = "Suffix"
            '
            'pnlCDMA
            '
            Me.pnlCDMA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlCDMA.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCdmaEndIncr, Me.txtCdmaEndCs, Me.txtCdmaEndPrefix, Me.txtCdmaStartIncr, Me.txtCdmaStartCs, Me.Label14, Me.txtCdmaStartPrefix, Me.Label16, Me.Label18, Me.Label19})
            Me.pnlCDMA.Location = New System.Drawing.Point(448, 16)
            Me.pnlCDMA.Name = "pnlCDMA"
            Me.pnlCDMA.Size = New System.Drawing.Size(266, 136)
            Me.pnlCDMA.TabIndex = 28
            '
            'txtCdmaEndIncr
            '
            Me.txtCdmaEndIncr.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtCdmaEndIncr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCdmaEndIncr.ForeColor = System.Drawing.Color.Black
            Me.txtCdmaEndIncr.Location = New System.Drawing.Point(152, 79)
            Me.txtCdmaEndIncr.Name = "txtCdmaEndIncr"
            Me.txtCdmaEndIncr.ReadOnly = True
            Me.txtCdmaEndIncr.Size = New System.Drawing.Size(72, 22)
            Me.txtCdmaEndIncr.TabIndex = 27
            Me.txtCdmaEndIncr.TabStop = False
            Me.txtCdmaEndIncr.Text = ""
            '
            'txtCdmaEndCs
            '
            Me.txtCdmaEndCs.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtCdmaEndCs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCdmaEndCs.ForeColor = System.Drawing.Color.Black
            Me.txtCdmaEndCs.Location = New System.Drawing.Point(232, 79)
            Me.txtCdmaEndCs.Name = "txtCdmaEndCs"
            Me.txtCdmaEndCs.ReadOnly = True
            Me.txtCdmaEndCs.Size = New System.Drawing.Size(16, 22)
            Me.txtCdmaEndCs.TabIndex = 26
            Me.txtCdmaEndCs.TabStop = False
            Me.txtCdmaEndCs.Text = ""
            '
            'txtCdmaEndPrefix
            '
            Me.txtCdmaEndPrefix.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtCdmaEndPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCdmaEndPrefix.ForeColor = System.Drawing.Color.Black
            Me.txtCdmaEndPrefix.Location = New System.Drawing.Point(8, 79)
            Me.txtCdmaEndPrefix.Name = "txtCdmaEndPrefix"
            Me.txtCdmaEndPrefix.ReadOnly = True
            Me.txtCdmaEndPrefix.Size = New System.Drawing.Size(136, 22)
            Me.txtCdmaEndPrefix.TabIndex = 24
            Me.txtCdmaEndPrefix.TabStop = False
            Me.txtCdmaEndPrefix.Text = ""
            '
            'txtCdmaStartIncr
            '
            Me.txtCdmaStartIncr.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtCdmaStartIncr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCdmaStartIncr.ForeColor = System.Drawing.Color.Black
            Me.txtCdmaStartIncr.Location = New System.Drawing.Point(152, 39)
            Me.txtCdmaStartIncr.Name = "txtCdmaStartIncr"
            Me.txtCdmaStartIncr.ReadOnly = True
            Me.txtCdmaStartIncr.Size = New System.Drawing.Size(72, 22)
            Me.txtCdmaStartIncr.TabIndex = 23
            Me.txtCdmaStartIncr.TabStop = False
            Me.txtCdmaStartIncr.Text = ""
            '
            'txtCdmaStartCs
            '
            Me.txtCdmaStartCs.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtCdmaStartCs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCdmaStartCs.ForeColor = System.Drawing.Color.Black
            Me.txtCdmaStartCs.Location = New System.Drawing.Point(232, 39)
            Me.txtCdmaStartCs.Name = "txtCdmaStartCs"
            Me.txtCdmaStartCs.ReadOnly = True
            Me.txtCdmaStartCs.Size = New System.Drawing.Size(16, 22)
            Me.txtCdmaStartCs.TabIndex = 22
            Me.txtCdmaStartCs.TabStop = False
            Me.txtCdmaStartCs.Text = ""
            '
            'Label14
            '
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Blue
            Me.Label14.Location = New System.Drawing.Point(8, 0)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(248, 24)
            Me.Label14.TabIndex = 21
            Me.Label14.Text = "C.D.M.A. Sims"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtCdmaStartPrefix
            '
            Me.txtCdmaStartPrefix.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.txtCdmaStartPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCdmaStartPrefix.ForeColor = System.Drawing.Color.Black
            Me.txtCdmaStartPrefix.Location = New System.Drawing.Point(8, 39)
            Me.txtCdmaStartPrefix.Name = "txtCdmaStartPrefix"
            Me.txtCdmaStartPrefix.ReadOnly = True
            Me.txtCdmaStartPrefix.Size = New System.Drawing.Size(136, 22)
            Me.txtCdmaStartPrefix.TabIndex = 17
            Me.txtCdmaStartPrefix.TabStop = False
            Me.txtCdmaStartPrefix.Text = ""
            '
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.Location = New System.Drawing.Point(8, 111)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(128, 16)
            Me.Label16.TabIndex = 17
            Me.Label16.Text = "Prefix"
            '
            'Label18
            '
            Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.Location = New System.Drawing.Point(152, 111)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(56, 16)
            Me.Label18.TabIndex = 13
            Me.Label18.Text = "Incremental"
            '
            'Label19
            '
            Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label19.Location = New System.Drawing.Point(224, 111)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(24, 16)
            Me.Label19.TabIndex = 21
            Me.Label19.Text = "CS"
            Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label20
            '
            Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.Black
            Me.Label20.Location = New System.Drawing.Point(8, 400)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(736, 24)
            Me.Label20.TabIndex = 29
            Me.Label20.Text = "This screen is used to receive a sequence of SIM cards based on the SKU and start" & _
            "ing and ending serial numbers."
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmTNSimReceiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightGray
            Me.ClientSize = New System.Drawing.Size(744, 398)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2, Me.Panel1, Me.Label20})
            Me.Name = "frmTNSimReceiving"
            Me.Text = "TextNow SIMS Reveiving"
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.pnlGSM.ResumeLayout(False)
            Me.pnlCDMA.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "DECLARATIONS"

		Dim _invalidSkuMsg As String = "Invalid UPC was entered.  Please enter valid UPC."
		Dim _invalidStartSNMsg As String = "Invalid Starting Serial Number was entered for this UPC."
		Dim _invalidEndSNMsg As String = "Invalid Ending Serial Number was entered for this UPC or was not greater than the entered Starting Serial Number."
		Dim _invalidSNRangeMsg As String = "The entered range is not valid due to already received or incorrect format."
		Dim _receivedMsg As String = "The following shipment has been received."
		Dim _simTypeCdma As Integer = 4162
		Dim _simTypeGsm As Integer = 4163
		Dim _simTypeEntered As Integer = 0
        Dim _NewSku
#End Region

#Region "FORM EVENTS"
		Private Sub frmTNSimReceiving_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			ClearAll()
			EnableControls()
			txtSkuEntry.Focus()
            txtDateRec.Text = Date.Now().ToShortDateString

            Me.btnGenerate.Visible = False

		End Sub
#End Region

#Region "CONTROL EVENTS"

        Private Sub txtSkuEntry_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSkuEntry.KeyUp

            ClearMsg()
                ClearMatches()
                ClearSNs()
                If txtSkuEntry.Text = "" Then Exit Sub
            If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
                If SkuIsValid() Then
                    PopulateOrderInfo()
                    txtStartSN.Focus()
                Else
                    _simTypeEntered = 0
                    PostMsg(_invalidSkuMsg)
                    txtSkuEntry.Text = ""
                    txtSkuEntry.Focus()
                End If
            End If
                EnableControls()
        End Sub

        Private Sub txtStartSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStartSN.KeyUp
            Dim objTN As New PSS.Data.Buisness.TN()
            Dim iSku_ID As Integer = 0

            ClearMsg()
            If txtStartSN.Text = "" Then Exit Sub

            Try

                If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
                    iSku_ID = objTN.getNewSKU_ID(Me.txtSku.Text.Trim)
                    If iSku_ID = objTN.iNewSku_ID Then
                        PopulateNewSkuStartData(txtStartSN.Text)
                    Else
                        If SNStartIsValid() Then
                            Select Case _simTypeEntered
                                Case _simTypeCdma : PopulateCDMAStart()
                                Case _simTypeGsm : PopulateGSMStart()
                                Case Else : Exit Sub
                            End Select
                            txtEndSN.Text = ""
                            txtEndSN.Focus()
                        Else
                            PostMsg(_invalidStartSNMsg)
                            txtStartSN.Text = ""
                            ClearCDMAStart()
                            ClearGSMStart()
                            txtStartSN.Focus()
                        End If
                        txtQty.Text = GetSNCount(txtStartSN.Text, txtEndSN.Text)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                objTN = Nothing
            End Try
            EnableControls()
        End Sub

        Private Sub PopulateNewSkuStartData(ByVal strSN As String)
            Dim objTN As New PSS.Data.Buisness.TN()
            Dim strSN1 As String = ""
            Dim strSN2 As String = ""
            Dim strChkSum As String = ""
            Dim strErrMsg As String = ""

            objTN.getCorrectSN(strSN, strSN1, strSN2, strChkSum, strErrMsg)

            Me.btnGenerate.Visible = False : Me.btnRec.Visible = True
            If strErrMsg.Trim.Length > 0 Then
                MessageBox.Show(strErrMsg)
            Else
                Me.txtGsmStartPrefix.Text = strSN1
                Me.txtGsmStartIncr.Text = strSN2
                Me.txtGsmStartCs.Text = strChkSum

                Me.btnGenerate.Visible = True : Me.btnRec.Visible = False
            End If

        End Sub

        Private Sub txtEndSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEndSN.KeyUp
            Dim objTN As New PSS.Data.Buisness.TN()
            Dim iSku_ID As Integer = 0

            Try
                ClearMsg()
                If txtEndSN.Text = "" Then Exit Sub
                If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
                    iSku_ID = objTN.getNewSKU_ID(Me.txtSku.Text.Trim)
                    If iSku_ID = objTN.iNewSku_ID Then
                        PopulateNewSkuEndData(txtEndSN.Text)
                    Else
                        If SNEndIsValid() Then
                            Select Case _simTypeEntered
                                Case _simTypeCdma : PopulateCDMAEnd()
                                Case _simTypeGsm : PopulateGSMEnd()
                                Case Else : Exit Sub
                            End Select
                            If PreRecValidation() Then
                                PostMsg("Ready to Receive")
                            End If
                            btnRec.Focus()
                        Else
                            PostMsg(_invalidEndSNMsg)
                            txtEndSN.Text = ""
                            ClearCDMAEnd()
                            ClearGSMEnd()
                            txtEndSN.Focus()
                        End If
                        txtQty.Text = GetSNCount(txtStartSN.Text, txtEndSN.Text)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                objTN = Nothing
            End Try
            EnableControls()
        End Sub

        Private Sub PopulateNewSkuEndData(ByVal strSN As String)
            Dim objTN As New PSS.Data.Buisness.TN()
            Dim strSN1 As String = ""
            Dim strSN2 As String = ""
            Dim strChkSum As String = ""
            Dim strErrMsg As String = ""

            Try
                Me.btnGenerate.Visible = False : Me.btnRec.Visible = True

                objTN.getCorrectSN(strSN, strSN1, strSN2, strChkSum, strErrMsg)
                If strErrMsg.Trim.Length > 0 Then
                    MessageBox.Show(strErrMsg)
                Else
                    Me.txtGsmEndPrefix.Text = strSN1
                    Me.txtGsmEndIncr.Text = strSN2
                    Me.txtGsmEndCs.Text = strChkSum

                    Me.btnGenerate.Visible = True : Me.btnRec.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                objTN = Nothing
            End Try
        End Sub

        Private Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
            Dim objTN As New PSS.Data.Buisness.TN()
            Dim dt As DataTable
            Dim strErrMsg As String = ""


            Try
                If Me.txtGsmStartPrefix.Text.Trim.Length > 0 AndAlso Me.txtGsmStartIncr.Text.Trim.Length > 0 _
                             AndAlso Me.txtGsmStartCs.Text.Trim.Length > 0 _
                             AndAlso Me.txtGsmEndPrefix.Text.Trim.Length > 0 AndAlso Me.txtGsmEndIncr.Text.Trim.Length > 0 _
                             AndAlso Me.txtGsmEndCs.Text.Trim.Length > 0 Then
                    dt = objTN.ValidateAndGenerate(Me.txtGsmStartPrefix.Text.Trim, Me.txtGsmEndPrefix.Text.Trim, Me.txtGsmStartIncr.Text.Trim, Me.txtGsmEndIncr.Text.Trim, strErrMsg)

                    If dt.Rows.Count > 0 Then
                        Dim fm As New frmTNRecv(dt)
                        fm.ShowDialog()
                        If fm.HasReceived Then
                            MessageBox.Show("Received!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ClearAll()
                            Me.btnGenerate.Visible = False
                        Else
                            MessageBox.Show("Failed to receive.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                Else
                    MessageBox.Show("Invalid starting SN or ending SN. Can't do it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                objTN = Nothing
            End Try
        End Sub

        Private Sub btnRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec.Click
            Try
                Me.Cursor = Cursors.WaitCursor
                PostMsg("Please wait....validating order.")
                ' VALIDATE.
                If Not PreRecValidation() Then
                    Exit Sub
                End If
                ' RECEIVE.
                PostMsg("Please wait....receiving order.")
                Receive()
                EnableControls()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            If MessageBox.Show("Clear all entries now?", Me.Text, _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ClearAll()
                EnableControls()
            End If
        End Sub

#End Region

#Region "PROPERTIES"

		Private Function SNStartIsValid()
			Dim _retVal As Boolean
			Dim _snNoChecksum As String
			If txtStartSN.Text.Length <> 20 Then
				_retVal = False
			Else
				Select Case _simTypeEntered
					Case _simTypeCdma : _snNoChecksum = GetGdmaStartNoChkSum()
					Case _simTypeGsm : _snNoChecksum = GetGsmStartNoChkSum()
					Case Else : Exit Function
				End Select
				If Not IsNumeric(_snNoChecksum) Then
					_retVal = False
				Else
					_retVal = True
				End If
			End If
			Return _retVal
		End Function

		Private Function SNEndIsValid() As Boolean
			Dim _retVal As Boolean
			Dim _ssn As Decimal
			Dim _esn As Decimal
			Dim _snStartNoChecksum As String
			Dim _snEndNoChecksum As String
			If txtEndSN.Text.Length <> 20 Then
				_retVal = False
			Else
				Select Case _simTypeEntered
					Case _simTypeCdma
						_snStartNoChecksum = GetGdmaStartNoChkSum()
						_snEndNoChecksum = GetGdmaStartNoChkSum()
					Case _simTypeGsm
						_snStartNoChecksum = GetGsmStartNoChkSum()
						_snEndNoChecksum = GetGsmEndNoChkSum()
					Case Else : Exit Function
				End Select
				If Not IsNumeric(_snEndNoChecksum) Then
					_retVal = False
				Else
					If _snEndNoChecksum >= _snStartNoChecksum Then
						_retVal = True
					End If
				End If
			End If
			Return _retVal
		End Function

		Private Function PreRecValidation() As Boolean
			Dim _retVal As Boolean = True
			Try
				If Not SkuIsValid() Then
					If txtSku.Text <> "" Then PostMsg(_invalidSkuMsg)
					_retVal = False
				End If
				If Not SNStartIsValid() Then
					If txtStartSN.Text <> "" Then PostMsg(_invalidStartSNMsg)
					_retVal = False
				End If
				If Not SNEndIsValid() Then
					If txtStartSN.Text <> "" Then PostMsg(_invalidEndSNMsg)
					_retVal = False
				End If
				Dim _simRec As New Data.BLL.TNSIMReceiving(PSS.Core.Global.ApplicationUser.IDuser)
				Dim _snStartNoChecksum As String
				Dim _snEndNoChecksum As String
				Select Case _simTypeEntered
					Case _simTypeCdma
						_snStartNoChecksum = GetGdmaStartNoChkSum()
						_snEndNoChecksum = GetGdmaStartNoChkSum()
					Case _simTypeGsm
						_snStartNoChecksum = GetGsmStartNoChkSum()
						_snEndNoChecksum = GetGsmEndNoChkSum()
					Case Else : Exit Function
				End Select
				If Not _simRec.IsSNRangeValid(_snStartNoChecksum, _snEndNoChecksum, _simTypeEntered) Then
					PostMsg(_invalidSNRangeMsg)
					_retVal = False
				End If
			Catch ex As Exception
				_retVal = False
			End Try
			Return _retVal
		End Function

		Private Function SkuIsValid() As Boolean
			Dim _isValid As Boolean
			Dim _sku As New Data.BOL.tcust_sku(txtSkuEntry.Text)
			_isValid = _sku.sku_id > 0
			_sku = Nothing
			Return _isValid
		End Function

#End Region

#Region "METHODS"

		Private Sub EnableControls()
			btnRec.Enabled = (lblMsg.Text = "Ready to Receive")
			pnlCDMA.Visible = (_simTypeEntered = _simTypeCdma)
			pnlGSM.Visible = (_simTypeEntered = _simTypeGsm)
		End Sub

		Private Function GetSNCount(ByVal start_sn As String, ByVal end_sn As String) As Integer
			Dim _retVal As Integer
			Dim _snPrefix As String
			Dim _snStart As Integer
			Dim _snEnd As Integer
			Dim _count As Integer
			Dim _snSuffix As String
			Dim _wr_id As Integer
			Dim _device_id As Integer
			Dim _wh_item_id As Integer
			Dim _wo_id As Integer
			If start_sn.Length <> 20 Or end_sn.Length <> 20 Then
				_retVal = 0
			Else
				Select Case _simTypeEntered
					Case _simTypeCdma
						_count = GetCdmaCount()
					Case _simTypeGsm
						_count = GetGsmCount()
					Case Else : _count = 0
				End Select
			End If
			Return _count.ToString()
		End Function

		Private Function GetRecMsg() As String
			Dim _msg As New StringBuilder()
			_msg.Append(_receivedMsg)
			_msg.Append(vbCrLf)
			_msg.Append(vbCrLf)
			_msg.Append("UPC - ")
			_msg.Append(txtSkuEntry.Text)
			_msg.Append(" Quantity of " & txtQty.Text)
			_msg.Append(vbCrLf)
			_msg.Append(vbCrLf)
			_msg.Append("Serial Number Range ")
			_msg.Append(vbCrLf)
			_msg.Append(vbCrLf)
			_msg.Append(txtStartSN.Text)
			_msg.Append(" to ")
			_msg.Append(txtEndSN.Text)
			_msg.Append(vbCrLf)
			_msg.Append(vbCrLf)
			_msg.Append("Received and assigned to the Cage.")
			_msg.Append(vbCrLf)
			Return _msg.ToString()
		End Function

		Private Sub PostMsg(ByVal text As String)
			lblMsg.Text = text
			Me.Refresh()
		End Sub

		Private Sub ClearMsg()
			lblMsg.Text = ""
		End Sub

		Private Sub PopulateOrderInfo()
			Dim _sku As New Data.BOL.tcust_sku(txtSkuEntry.Text)
			Dim _cust_id As Integer = 0
			If _sku.sku_id > 0 Then
				_cust_id = _sku.cust_id
				txtQty.Text = GetSNCount(txtStartSN.Text, txtEndSN.Text)
				txtSku.Text = _sku.sku
				txtPartNr.Text = _sku.sku_part_nr
				Select Case _sku.sku_type_decode_id
					Case _simTypeCdma : _simTypeEntered = _simTypeCdma
					Case _simTypeGsm : _simTypeEntered = _simTypeGsm
					Case Else : _simTypeEntered = 0
				End Select
				txtCust.Text = GetCustomerName(_cust_id)
			End If
			_sku = Nothing
		End Sub

		Private Sub Receive()
			Dim _user_id As Integer
			Dim _sku As String

			' Remove the checksum it will be rebuilt in generation.
			Dim _start As String = txtStartSN.Text		  '.Substring(0, txtStartSN.Text.Length - 1)
			Dim _end As String = txtEndSN.Text		  '.Substring(0, txtStartSN.Text.Length - 1)
			_user_id = PSS.Core.Global.ApplicationUser.IDuser
			_sku = txtSkuEntry.Text
			' RECEIVE THE SHIPMENT.
			Dim _tnsr As New Data.BLL.TNSIMReceiving(_user_id)
			_tnsr.GenerateSNs(_sku, _start, _end, txtNotes.Text)
			MessageBox.Show(GetRecMsg(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			ClearAll()
			ClearMsg()
		End Sub

		Private Sub ClearMatches()
			txtCust.Text = ""
			txtQty.Text = "0"
			txtSku.Text = ""
			txtPartNr.Text = ""
			_simTypeEntered = 0
		End Sub

		Private Sub ClearSku()
			txtSkuEntry.Text = ""
			_simTypeEntered = 0
		End Sub

		Private Sub ClearSNs()
			txtStartSN.Text = ""
			txtEndSN.Text = ""
			ClearCDMAStart()
			ClearCDMAEnd()
			ClearGSMStart()
			ClearGSMEnd()
			txtNotes.Text = ""
			txtCdmaStartPrefix.Text = ""
			txtCdmaStartIncr.Text = ""
			txtCdmaStartCs.Text = ""
			txtGsmEndPrefix.Text = ""
			txtGsmEndIncr.Text = ""
			txtGsmEndCs.Text = ""
			txtGsmEndSuffix.Text = ""
		End Sub

		Private Sub ClearAll()
			ClearSku()
			ClearMatches()
			ClearSNs()
			ClearMsg()
			EnableControls()
		End Sub

		Private Sub ClearCDMAStart()
			txtCdmaStartPrefix.Text = ""
			txtCdmaStartIncr.Text = ""
			txtCdmaStartCs.Text = ""
		End Sub

		Private Sub ClearCDMAEnd()
			txtCdmaEndPrefix.Text = ""
			txtCdmaEndIncr.Text = ""
			txtCdmaEndCs.Text = ""
		End Sub

		Private Sub ClearGSMStart()
			txtGsmStartPrefix.Text = ""
			txtGsmStartIncr.Text = ""
			txtGsmStartCs.Text = ""
			txtGsmStartSuffix.Text = ""
		End Sub

		Private Sub ClearGSMEnd()
			txtGsmEndPrefix.Text = ""
			txtGsmEndIncr.Text = ""
			txtGsmEndCs.Text = ""
			txtGsmEndSuffix.Text = ""
		End Sub

		Private Sub PopulateCDMAStart()
			Dim _sn As New Data.BOL.CDMASim(txtStartSN.Text)
			txtCdmaStartPrefix.Text = _sn.Prefix
			txtCdmaStartIncr.Text = _sn.Incremental
			txtCdmaStartCs.Text = _sn.Checksum
			_sn = Nothing
		End Sub

		Private Sub PopulateCDMAEnd()
			Dim _sn As New Data.BOL.CDMASim(txtEndSN.Text)
			txtCdmaEndPrefix.Text = _sn.Prefix
			txtCdmaEndIncr.Text = _sn.Incremental
			txtCdmaEndCs.Text = _sn.Checksum
			_sn = Nothing
		End Sub

		Private Sub PopulateGSMStart()
			Dim _sn As New Data.BOL.GSMSim(txtStartSN.Text)
			txtGsmStartPrefix.Text = _sn.Prefix
			txtGsmStartIncr.Text = _sn.Incremental
			txtGsmStartCs.Text = _sn.Checksum
			txtGsmStartSuffix.Text = _sn.Suffix
			_sn = Nothing
		End Sub

		Private Sub PopulateGSMEnd()
			Dim _sn As New Data.BOL.GSMSim(txtEndSN.Text)
			txtGsmEndPrefix.Text = _sn.Prefix
			txtGsmEndIncr.Text = _sn.Incremental
			txtGsmEndCs.Text = _sn.Checksum
			txtGsmEndSuffix.Text = _sn.Suffix
			_sn = Nothing
		End Sub

		Private Function GetGdmaStartNoChkSum() As String
			Dim _retVal As String
			Dim _sn As New Data.BOL.CDMASim(txtStartSN.Text)
			_retVal = _sn.SerialNumberNoChkSum()
			_sn = Nothing
			Return _retVal
		End Function

		Private Function GetGdmaEndNoChkSum() As String
			Dim _retVal As String
			Dim _sn As New Data.BOL.CDMASim(txtEndSN.Text)
			_retVal = _sn.SerialNumberNoChkSum()
			_sn = Nothing
			Return _retVal
		End Function

		Private Function GetGsmStartNoChkSum() As String
			Dim _retVal As String
			Dim _sn As New Data.BOL.GSMSim(txtStartSN.Text)
			_retVal = _sn.SerialNumberNoChkSum()
			_sn = Nothing
			Return _retVal
		End Function

		Private Function GetGsmEndNoChkSum() As String
			Dim _retVal As String
			Dim _sn As New Data.BOL.GSMSim(txtEndSN.Text)
			_retVal = _sn.SerialNumberNoChkSum()
			_sn = Nothing
			Return _retVal
		End Function

		Private Function GetCDMACount() As Integer
			Dim _retVal As Integer = 0
			Dim _snStart As New Data.BOL.CDMASim(txtStartSN.Text)
			Dim _snEnd As New Data.BOL.CDMASim(txtEndSN.Text)
			_retVal = _snEnd.Incremental - _snStart.Incremental + 1
			_snStart = Nothing
			_snEnd = Nothing
			Return _retVal
		End Function

		Private Function GetGSMCount() As Integer
			Dim _retVal As Integer = 0
			Dim _snStart As New Data.BOL.GSMSim(txtStartSN.Text)
			Dim _snEnd As New Data.BOL.GSMSim(txtEndSN.Text)
			_retVal = _snEnd.Incremental - _snStart.Incremental + 1
			_snStart = Nothing
			_snEnd = Nothing
			Return _retVal
		End Function

		Private Function GetCustomerName(ByVal cust_id As Integer) As String
			Dim _retVal As String = ""
			Dim _cust As New Data.BOL.tcustomer(cust_id)
			_retVal = _cust.Cust_Name1
			_cust = Nothing
			Return _retVal
		End Function

#End Region

 
        Private Sub frmTNSimReceiving_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click

        End Sub
    End Class

End Namespace
