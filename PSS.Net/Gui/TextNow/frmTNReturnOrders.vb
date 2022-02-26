Imports PSS.Data

Public Class frmTNReturnOrders
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
	Friend WithEvents txtTrackingNr As System.Windows.Forms.TextBox
	Friend WithEvents txtSN As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents btnSearch As System.Windows.Forms.Button
	Friend WithEvents lblShipQty As System.Windows.Forms.Label
	Friend WithEvents txtShipQty As System.Windows.Forms.TextBox
	Friend WithEvents lblOrderRevDT As System.Windows.Forms.Label
	Friend WithEvents txtInsertPartNo As System.Windows.Forms.TextBox
	Friend WithEvents txtOrderRevDT As System.Windows.Forms.TextBox
	Friend WithEvents lblOrderQty As System.Windows.Forms.Label
	Friend WithEvents txtOrderQty As System.Windows.Forms.TextBox
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents txtSku As System.Windows.Forms.TextBox
	Friend WithEvents lblOrderNo As System.Windows.Forms.Label
	Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
	Friend WithEvents lblSku As System.Windows.Forms.Label
	Friend WithEvents lblInsertPartNo As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents pnlResults As System.Windows.Forms.Panel
	Friend WithEvents btnClear As System.Windows.Forms.Button
	Friend WithEvents txtShipCarrier As System.Windows.Forms.TextBox
	Friend WithEvents lblAddress1 As System.Windows.Forms.Label
	Friend WithEvents lblAddress2 As System.Windows.Forms.Label
	Friend WithEvents lblName As System.Windows.Forms.Label
	Friend WithEvents lblCity As System.Windows.Forms.Label
	Friend WithEvents lblState As System.Windows.Forms.Label
	Friend WithEvents lblCountry As System.Windows.Forms.Label
	Friend WithEvents lblZipcode As System.Windows.Forms.Label
	Friend WithEvents btnProcess As System.Windows.Forms.Button
	Friend WithEvents txtReason As System.Windows.Forms.TextBox
	Friend WithEvents Label8 As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.txtTrackingNr = New System.Windows.Forms.TextBox()
		Me.txtSN = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.btnSearch = New System.Windows.Forms.Button()
		Me.lblShipQty = New System.Windows.Forms.Label()
		Me.txtShipQty = New System.Windows.Forms.TextBox()
		Me.lblOrderRevDT = New System.Windows.Forms.Label()
		Me.txtInsertPartNo = New System.Windows.Forms.TextBox()
		Me.txtOrderRevDT = New System.Windows.Forms.TextBox()
		Me.lblOrderQty = New System.Windows.Forms.Label()
		Me.txtOrderQty = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.txtSku = New System.Windows.Forms.TextBox()
		Me.lblOrderNo = New System.Windows.Forms.Label()
		Me.txtOrderNo = New System.Windows.Forms.TextBox()
		Me.lblSku = New System.Windows.Forms.Label()
		Me.lblInsertPartNo = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.txtShipCarrier = New System.Windows.Forms.TextBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.lblZipcode = New System.Windows.Forms.Label()
		Me.lblCountry = New System.Windows.Forms.Label()
		Me.lblAddress1 = New System.Windows.Forms.Label()
		Me.lblCity = New System.Windows.Forms.Label()
		Me.lblName = New System.Windows.Forms.Label()
		Me.lblAddress2 = New System.Windows.Forms.Label()
		Me.lblState = New System.Windows.Forms.Label()
		Me.txtReason = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.btnProcess = New System.Windows.Forms.Button()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.btnClear = New System.Windows.Forms.Button()
		Me.pnlResults = New System.Windows.Forms.Panel()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.GroupBox1.SuspendLayout()
		Me.pnlResults.SuspendLayout()
		Me.SuspendLayout()
		'
		'txtTrackingNr
		'
		Me.txtTrackingNr.BackColor = System.Drawing.Color.LightSkyBlue
		Me.txtTrackingNr.Location = New System.Drawing.Point(144, 32)
		Me.txtTrackingNr.Name = "txtTrackingNr"
		Me.txtTrackingNr.Size = New System.Drawing.Size(208, 20)
		Me.txtTrackingNr.TabIndex = 1
		Me.txtTrackingNr.Text = ""
		'
		'txtSN
		'
		Me.txtSN.BackColor = System.Drawing.Color.LightSkyBlue
		Me.txtSN.Location = New System.Drawing.Point(144, 64)
		Me.txtSN.Name = "txtSN"
		Me.txtSN.Size = New System.Drawing.Size(208, 20)
		Me.txtSN.TabIndex = 3
		Me.txtSN.Text = ""
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(16, 32)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(112, 23)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Tracking Number:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(16, 64)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(112, 23)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "SIM Serial Number:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'btnSearch
		'
		Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(128, Byte))
		Me.btnSearch.Location = New System.Drawing.Point(384, 32)
		Me.btnSearch.Name = "btnSearch"
		Me.btnSearch.Size = New System.Drawing.Size(88, 24)
		Me.btnSearch.TabIndex = 4
		Me.btnSearch.Text = "Search"
		'
		'lblShipQty
		'
		Me.lblShipQty.BackColor = System.Drawing.Color.Transparent
		Me.lblShipQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblShipQty.ForeColor = System.Drawing.Color.Black
		Me.lblShipQty.Location = New System.Drawing.Point(616, 32)
		Me.lblShipQty.Name = "lblShipQty"
		Me.lblShipQty.Size = New System.Drawing.Size(56, 21)
		Me.lblShipQty.TabIndex = 12
		Me.lblShipQty.Text = "Ship Qty :"
		Me.lblShipQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtShipQty
		'
		Me.txtShipQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtShipQty.ForeColor = System.Drawing.Color.Black
		Me.txtShipQty.Location = New System.Drawing.Point(680, 32)
		Me.txtShipQty.Name = "txtShipQty"
		Me.txtShipQty.ReadOnly = True
		Me.txtShipQty.Size = New System.Drawing.Size(40, 20)
		Me.txtShipQty.TabIndex = 13
		Me.txtShipQty.Text = ""
		Me.txtShipQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'lblOrderRevDT
		'
		Me.lblOrderRevDT.BackColor = System.Drawing.Color.Transparent
		Me.lblOrderRevDT.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblOrderRevDT.ForeColor = System.Drawing.Color.Black
		Me.lblOrderRevDT.Location = New System.Drawing.Point(40, 64)
		Me.lblOrderRevDT.Name = "lblOrderRevDT"
		Me.lblOrderRevDT.Size = New System.Drawing.Size(88, 21)
		Me.lblOrderRevDT.TabIndex = 2
		Me.lblOrderRevDT.Text = "Order Date :"
		Me.lblOrderRevDT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtInsertPartNo
		'
		Me.txtInsertPartNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtInsertPartNo.ForeColor = System.Drawing.Color.Black
		Me.txtInsertPartNo.Location = New System.Drawing.Point(136, 128)
		Me.txtInsertPartNo.Name = "txtInsertPartNo"
		Me.txtInsertPartNo.ReadOnly = True
		Me.txtInsertPartNo.Size = New System.Drawing.Size(208, 20)
		Me.txtInsertPartNo.TabIndex = 7
		Me.txtInsertPartNo.Text = ""
		'
		'txtOrderRevDT
		'
		Me.txtOrderRevDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtOrderRevDT.ForeColor = System.Drawing.SystemColors.Desktop
		Me.txtOrderRevDT.Location = New System.Drawing.Point(136, 64)
		Me.txtOrderRevDT.Name = "txtOrderRevDT"
		Me.txtOrderRevDT.ReadOnly = True
		Me.txtOrderRevDT.Size = New System.Drawing.Size(208, 20)
		Me.txtOrderRevDT.TabIndex = 3
		Me.txtOrderRevDT.Text = ""
		'
		'lblOrderQty
		'
		Me.lblOrderQty.BackColor = System.Drawing.Color.Transparent
		Me.lblOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblOrderQty.ForeColor = System.Drawing.Color.Black
		Me.lblOrderQty.Location = New System.Drawing.Point(40, 160)
		Me.lblOrderQty.Name = "lblOrderQty"
		Me.lblOrderQty.Size = New System.Drawing.Size(88, 21)
		Me.lblOrderQty.TabIndex = 8
		Me.lblOrderQty.Text = "Order Qty :"
		Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtOrderQty
		'
		Me.txtOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtOrderQty.ForeColor = System.Drawing.Color.Black
		Me.txtOrderQty.Location = New System.Drawing.Point(136, 160)
		Me.txtOrderQty.Name = "txtOrderQty"
		Me.txtOrderQty.ReadOnly = True
		Me.txtOrderQty.Size = New System.Drawing.Size(40, 20)
		Me.txtOrderQty.TabIndex = 9
		Me.txtOrderQty.Text = ""
		Me.txtOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label6
		'
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.ForeColor = System.Drawing.Color.Black
		Me.Label6.Location = New System.Drawing.Point(368, 32)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(72, 21)
		Me.Label6.TabIndex = 10
		Me.Label6.Text = "Ship Carrier:"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtSku
		'
		Me.txtSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSku.ForeColor = System.Drawing.Color.Black
		Me.txtSku.Location = New System.Drawing.Point(136, 96)
		Me.txtSku.Name = "txtSku"
		Me.txtSku.ReadOnly = True
		Me.txtSku.Size = New System.Drawing.Size(208, 20)
		Me.txtSku.TabIndex = 5
		Me.txtSku.Text = ""
		'
		'lblOrderNo
		'
		Me.lblOrderNo.BackColor = System.Drawing.Color.Transparent
		Me.lblOrderNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblOrderNo.ForeColor = System.Drawing.Color.Black
		Me.lblOrderNo.Location = New System.Drawing.Point(40, 32)
		Me.lblOrderNo.Name = "lblOrderNo"
		Me.lblOrderNo.Size = New System.Drawing.Size(88, 21)
		Me.lblOrderNo.TabIndex = 0
		Me.lblOrderNo.Text = "Order No :"
		Me.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtOrderNo
		'
		Me.txtOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtOrderNo.ForeColor = System.Drawing.SystemColors.Desktop
		Me.txtOrderNo.Location = New System.Drawing.Point(136, 32)
		Me.txtOrderNo.Name = "txtOrderNo"
		Me.txtOrderNo.ReadOnly = True
		Me.txtOrderNo.Size = New System.Drawing.Size(208, 20)
		Me.txtOrderNo.TabIndex = 1
		Me.txtOrderNo.Text = ""
		'
		'lblSku
		'
		Me.lblSku.BackColor = System.Drawing.Color.Transparent
		Me.lblSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSku.ForeColor = System.Drawing.Color.Black
		Me.lblSku.Location = New System.Drawing.Point(40, 96)
		Me.lblSku.Name = "lblSku"
		Me.lblSku.Size = New System.Drawing.Size(88, 21)
		Me.lblSku.TabIndex = 4
		Me.lblSku.Text = "Sku :"
		Me.lblSku.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblInsertPartNo
		'
		Me.lblInsertPartNo.BackColor = System.Drawing.Color.Transparent
		Me.lblInsertPartNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblInsertPartNo.ForeColor = System.Drawing.Color.Black
		Me.lblInsertPartNo.Location = New System.Drawing.Point(40, 128)
		Me.lblInsertPartNo.Name = "lblInsertPartNo"
		Me.lblInsertPartNo.Size = New System.Drawing.Size(88, 21)
		Me.lblInsertPartNo.TabIndex = 6
		Me.lblInsertPartNo.Text = "Insert Part No"
		Me.lblInsertPartNo.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'Label3
		'
		Me.Label3.ForeColor = System.Drawing.Color.Black
		Me.Label3.Location = New System.Drawing.Point(368, 64)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(72, 23)
		Me.Label3.TabIndex = 14
		Me.Label3.Text = "Address:"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'txtShipCarrier
		'
		Me.txtShipCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtShipCarrier.ForeColor = System.Drawing.Color.Black
		Me.txtShipCarrier.Location = New System.Drawing.Point(448, 32)
		Me.txtShipCarrier.Name = "txtShipCarrier"
		Me.txtShipCarrier.ReadOnly = True
		Me.txtShipCarrier.Size = New System.Drawing.Size(152, 20)
		Me.txtShipCarrier.TabIndex = 11
		Me.txtShipCarrier.Text = ""
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSku, Me.lblOrderNo, Me.txtOrderNo, Me.lblSku, Me.lblInsertPartNo, Me.txtShipCarrier, Me.txtShipQty, Me.lblOrderRevDT, Me.txtInsertPartNo, Me.txtOrderRevDT, Me.lblShipQty, Me.lblOrderQty, Me.txtOrderQty, Me.Label6, Me.Label3, Me.lblZipcode, Me.lblCountry, Me.lblAddress1, Me.lblCity, Me.lblName, Me.lblAddress2, Me.lblState})
		Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
		Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(776, 200)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Search Results"
		'
		'lblZipcode
		'
		Me.lblZipcode.ForeColor = System.Drawing.Color.Blue
		Me.lblZipcode.Location = New System.Drawing.Point(448, 160)
		Me.lblZipcode.Name = "lblZipcode"
		Me.lblZipcode.Size = New System.Drawing.Size(136, 23)
		Me.lblZipcode.TabIndex = 27
		'
		'lblCountry
		'
		Me.lblCountry.ForeColor = System.Drawing.Color.Blue
		Me.lblCountry.Location = New System.Drawing.Point(584, 160)
		Me.lblCountry.Name = "lblCountry"
		Me.lblCountry.Size = New System.Drawing.Size(136, 23)
		Me.lblCountry.TabIndex = 28
		'
		'lblAddress1
		'
		Me.lblAddress1.ForeColor = System.Drawing.Color.Blue
		Me.lblAddress1.Location = New System.Drawing.Point(448, 88)
		Me.lblAddress1.Name = "lblAddress1"
		Me.lblAddress1.Size = New System.Drawing.Size(272, 23)
		Me.lblAddress1.TabIndex = 22
		'
		'lblCity
		'
		Me.lblCity.ForeColor = System.Drawing.Color.Blue
		Me.lblCity.Location = New System.Drawing.Point(448, 136)
		Me.lblCity.Name = "lblCity"
		Me.lblCity.Size = New System.Drawing.Size(136, 23)
		Me.lblCity.TabIndex = 25
		'
		'lblName
		'
		Me.lblName.ForeColor = System.Drawing.Color.Blue
		Me.lblName.Location = New System.Drawing.Point(448, 64)
		Me.lblName.Name = "lblName"
		Me.lblName.Size = New System.Drawing.Size(272, 23)
		Me.lblName.TabIndex = 24
		'
		'lblAddress2
		'
		Me.lblAddress2.ForeColor = System.Drawing.Color.Blue
		Me.lblAddress2.Location = New System.Drawing.Point(448, 112)
		Me.lblAddress2.Name = "lblAddress2"
		Me.lblAddress2.Size = New System.Drawing.Size(272, 23)
		Me.lblAddress2.TabIndex = 23
		'
		'lblState
		'
		Me.lblState.ForeColor = System.Drawing.Color.Blue
		Me.lblState.Location = New System.Drawing.Point(584, 136)
		Me.lblState.Name = "lblState"
		Me.lblState.Size = New System.Drawing.Size(136, 23)
		Me.lblState.TabIndex = 26
		'
		'txtReason
		'
		Me.txtReason.Location = New System.Drawing.Point(144, 224)
		Me.txtReason.Multiline = True
		Me.txtReason.Name = "txtReason"
		Me.txtReason.Size = New System.Drawing.Size(624, 40)
		Me.txtReason.TabIndex = 2
		Me.txtReason.Text = ""
		'
		'Label4
		'
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.ForeColor = System.Drawing.Color.Black
		Me.Label4.Location = New System.Drawing.Point(16, 224)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(112, 16)
		Me.Label4.TabIndex = 1
		Me.Label4.Text = "Reason for Return:"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnProcess
		'
		Me.btnProcess.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(128, Byte))
		Me.btnProcess.Location = New System.Drawing.Point(656, 280)
		Me.btnProcess.Name = "btnProcess"
		Me.btnProcess.Size = New System.Drawing.Size(112, 32)
		Me.btnProcess.TabIndex = 3
		Me.btnProcess.Text = "Process Return"
		'
		'Label5
		'
		Me.Label5.Location = New System.Drawing.Point(16, 296)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(560, 23)
		Me.Label5.TabIndex = 4
		Me.Label5.Text = "This screen is used to process SIM Card Returns.  The SIM will be returned to inv" & _
		"entory the Kitted."
		'
		'Label7
		'
		Me.Label7.ForeColor = System.Drawing.Color.Blue
		Me.Label7.Location = New System.Drawing.Point(504, 32)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(264, 64)
		Me.Label7.TabIndex = 6
		Me.Label7.Text = "Please enter or scan in the Tracking Number and the Serial Number of the SIM card" & _
		".  Click on the Search button to locate the order to be processed as a return."
		'
		'btnClear
		'
		Me.btnClear.Location = New System.Drawing.Point(384, 64)
		Me.btnClear.Name = "btnClear"
		Me.btnClear.Size = New System.Drawing.Size(88, 24)
		Me.btnClear.TabIndex = 5
		Me.btnClear.Text = "Clear"
		'
		'pnlResults
		'
		Me.pnlResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.Label5, Me.btnProcess, Me.txtReason, Me.Label4, Me.GroupBox1})
		Me.pnlResults.ForeColor = System.Drawing.Color.Black
		Me.pnlResults.Location = New System.Drawing.Point(8, 104)
		Me.pnlResults.Name = "pnlResults"
		Me.pnlResults.Size = New System.Drawing.Size(792, 320)
		Me.pnlResults.TabIndex = 7
		Me.pnlResults.Visible = False
		'
		'Label8
		'
		Me.Label8.BackColor = System.Drawing.SystemColors.Control
		Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.ForeColor = System.Drawing.Color.Red
		Me.Label8.Location = New System.Drawing.Point(16, 240)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(96, 16)
		Me.Label8.TabIndex = 5
		Me.Label8.Text = "(Required)"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'frmTNReturnOrders
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(808, 430)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlResults, Me.btnClear, Me.Label7, Me.btnSearch, Me.Label2, Me.Label1, Me.txtSN, Me.txtTrackingNr})
		Me.ForeColor = System.Drawing.Color.Black
		Me.Name = "frmTNReturnOrders"
		Me.Text = "TextNow SIM Card Returns"
		Me.GroupBox1.ResumeLayout(False)
		Me.pnlResults.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region
#Region "DECLARATIONS"

#End Region
#Region "FORM EVENTS"

	Private Sub frmTNReturnOrders_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		EnableControls()
	End Sub

#End Region
#Region "CONTROL EVENTS"

	Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
		Me.Cursor = Cursors.WaitCursor
		SearchForOrder()
		EnableControls()
		If pnlResults.Visible Then txtReason.Focus()
		Me.Cursor = Cursors.Default
	End Sub
	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		ClearAll()
		EnableControls()
	End Sub
	Private Sub txtTrackingNr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTrackingNr.TextChanged
		ClearOrder()
		EnableControls()
	End Sub
	Private Sub txtSN_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSN.TextChanged
		ClearOrder()
		EnableControls()
	End Sub
	Private Sub txtReason_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReason.TextChanged
		EnableControls()
	End Sub
	Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
		Me.Cursor = Cursors.WaitCursor
		Dim _tnOrder As New BLL.TNSIMOrders(PSS.Core.ApplicationUser.IDuser)
		If _tnOrder.ProcessReturn(txtTrackingNr.Text, txtSN.Text, txtReason.Text) Then
			MessageBox.Show("The item has been returned and added back to the Kitted inventory.")
			ClearAll()
		Else
			MessageBox.Show("An error occurred while attempting to process the return." & vbCrLf & vbCrLf, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End If
		Me.Cursor = Cursors.Default
	End Sub

#End Region
#Region "PROPERTIES"

#End Region
#Region "METHODS"

	Private Sub SearchForOrder()
		Dim _sku As String = ""
		Dim _soheaderid As Integer
		Dim _soh As New BOL.soheader(txtTrackingNr.Text)
		If _soh.SOHeaderID < 1 Then
			MessageBox.Show("Order now found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			_soh = Nothing
			Exit Sub
		End If

		Dim _device As New BOL.tDevice(txtSN.Text, True)
		If _device.Device_ID < 1 Then
			MessageBox.Show("SIM Card now found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			_device = Nothing
			Exit Sub
		End If

		' POPULATE FROM SOHEADER TABLE.
		_soheaderid = _soh.SOHeaderID
		txtOrderNo.Text = _soh.PONumber
		txtOrderRevDT.Text = _soh.ReceiptTimestamp.ToString
		txtShipCarrier.Text = _soh.ShipCarrier
		lblName.Text = _soh.CustomerFirstName
		lblAddress1.Text = _soh.CustomerAddress1
		lblAddress2.Text = _soh.CustomerAddress2
		lblCity.Text = _soh.CustomerCity
		lblState.Text = _soh.CustomerState
		lblZipcode.Text = _soh.CustomerPostalCode
		lblCountry.Text = _soh.CustomerCountry
		_soh = Nothing

		' POPULATE FROM SODETAILS TABLE
		Dim _sodCol As New BOL.sodetailsCollection(_soheaderid)
		Dim _sod As BOL.sodetails
		If _sodCol.sodetailsDataTable.Rows.Count > 0 Then
			Dim _dt As New DataTable()
			_dt = _sodCol.sodetailsDataTable.Copy
			_sod = New BOL.sodetails(_dt.Rows(0)("sodetailsid"))
			_sku = _sod.SKU
			txtOrderQty.Text = _sod.Quantity.ToString()
			txtShipQty.Text = _sod.ShipQuantity.ToString()
			_sod = Nothing
		End If

		' POPULATE FROM TCUST_SKU TABLE.
		Dim _cust_sku As New BOL.tcust_sku(_sku)
		txtSku.Text = _cust_sku.sku
		txtInsertPartNo.Text = _cust_sku.sku_part_nr
		_cust_sku = Nothing

	End Sub
	Private Sub EnableControls()
		btnSearch.Enabled = (txtTrackingNr.Text <> "" AndAlso txtSN.Text <> "")
		btnProcess.Enabled = txtReason.Text <> ""
		pnlResults.Visible = txtOrderNo.Text <> ""
	End Sub
	Private Sub ClearAll()
		ClearSearch()
		ClearOrder()
	End Sub
	Private Sub ClearSearch()
		txtTrackingNr.Text = ""
		txtSN.Text = ""
		ClearOrder()
	End Sub
	Private Sub ClearOrder()
		txtOrderNo.Text = ""
		txtOrderRevDT.Text = ""
		txtSku.Text = ""
		txtInsertPartNo.Text = ""
		txtOrderQty.Text = ""
		txtShipCarrier.Text = ""
		txtShipQty.Text = ""
		lblName.Text = ""
		lblAddress1.Text = ""
		lblAddress2.Text = ""
		lblCity.Text = ""
		lblState.Text = ""
		lblZipcode.Text = ""
		lblCountry.Text = ""
	End Sub

	Private Sub ProcessReturn()

	End Sub

#End Region

	Private Sub txtTrackingNr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrackingNr.KeyUp
		If e.KeyCode = Keys.Enter Then
			txtSN.Focus()
		End If
	End Sub

	Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
		If e.KeyCode = Keys.Enter Then
			btnSearch_Click(Nothing, Nothing)
		End If
	End Sub

End Class
