Option Explicit On 

Namespace Gui.TracFone
    Public Class frmProdLineRec
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
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
        Friend WithEvents pnlFileInfo As System.Windows.Forms.Panel
        Friend WithEvents lblRcvd As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblRejected As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblAccepted As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lblFileQty As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents pnlPN As System.Windows.Forms.Panel
        Friend WithEvents Button5 As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
        Friend WithEvents pnlDiscrepOption As System.Windows.Forms.Panel
        Friend WithEvents chkLessThan30Days As System.Windows.Forms.CheckBox
        Friend WithEvents chkExtraItem As System.Windows.Forms.CheckBox
        Friend WithEvents chkWrongSku As System.Windows.Forms.CheckBox
        Friend WithEvents pnlSku As System.Windows.Forms.Panel
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtSku As System.Windows.Forms.TextBox
        Friend WithEvents PanelSN As System.Windows.Forms.Panel
        Friend WithEvents Button8 As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents PanelOptions As System.Windows.Forms.Panel
        Friend WithEvents lblSkuPartNumber As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents PanelIMEI As System.Windows.Forms.Panel
        Friend WithEvents Button6 As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents cmbOpenRMA As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents btnCloseRMA As System.Windows.Forms.Button
        Friend WithEvents dbgRecUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblMsg As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProdLineRec))
            Me.pnlFileInfo = New System.Windows.Forms.Panel()
            Me.lblRcvd = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblRejected = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblAccepted = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblFileQty = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.pnlPN = New System.Windows.Forms.Panel()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtPartNumber = New System.Windows.Forms.TextBox()
            Me.pnlDiscrepOption = New System.Windows.Forms.Panel()
            Me.chkLessThan30Days = New System.Windows.Forms.CheckBox()
            Me.chkExtraItem = New System.Windows.Forms.CheckBox()
            Me.chkWrongSku = New System.Windows.Forms.CheckBox()
            Me.pnlSku = New System.Windows.Forms.Panel()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtSku = New System.Windows.Forms.TextBox()
            Me.PanelSN = New System.Windows.Forms.Panel()
            Me.Button8 = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.PanelOptions = New System.Windows.Forms.Panel()
            Me.lblSkuPartNumber = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.PanelIMEI = New System.Windows.Forms.Panel()
            Me.Button6 = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.lblHeader = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.cmbOpenRMA = New PSS.Gui.Controls.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.btnCloseRMA = New System.Windows.Forms.Button()
            Me.dbgRecUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblMsg = New System.Windows.Forms.Label()
            Me.pnlFileInfo.SuspendLayout()
            Me.Panel6.SuspendLayout()
            Me.pnlPN.SuspendLayout()
            Me.pnlDiscrepOption.SuspendLayout()
            Me.pnlSku.SuspendLayout()
            Me.PanelSN.SuspendLayout()
            Me.PanelOptions.SuspendLayout()
            Me.PanelIMEI.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlFileInfo
            '
            Me.pnlFileInfo.BackColor = System.Drawing.Color.Black
            Me.pnlFileInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFileInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRcvd, Me.Label11, Me.lblRejected, Me.Label9, Me.lblAccepted, Me.Label7, Me.lblFileQty, Me.Label6})
            Me.pnlFileInfo.Location = New System.Drawing.Point(592, 105)
            Me.pnlFileInfo.Name = "pnlFileInfo"
            Me.pnlFileInfo.Size = New System.Drawing.Size(328, 160)
            Me.pnlFileInfo.TabIndex = 112
            '
            'lblRcvd
            '
            Me.lblRcvd.BackColor = System.Drawing.Color.Transparent
            Me.lblRcvd.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRcvd.ForeColor = System.Drawing.Color.Lime
            Me.lblRcvd.Location = New System.Drawing.Point(224, 123)
            Me.lblRcvd.Name = "lblRcvd"
            Me.lblRcvd.Size = New System.Drawing.Size(96, 31)
            Me.lblRcvd.TabIndex = 90
            Me.lblRcvd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Lime
            Me.Label11.Location = New System.Drawing.Point(0, 123)
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
            Me.lblRejected.Location = New System.Drawing.Point(224, 83)
            Me.lblRejected.Name = "lblRejected"
            Me.lblRejected.Size = New System.Drawing.Size(96, 31)
            Me.lblRejected.TabIndex = 88
            Me.lblRejected.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Lime
            Me.Label9.Location = New System.Drawing.Point(16, 83)
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
            Me.lblAccepted.Location = New System.Drawing.Point(224, 43)
            Me.lblAccepted.Name = "lblAccepted"
            Me.lblAccepted.Size = New System.Drawing.Size(96, 31)
            Me.lblAccepted.TabIndex = 86
            Me.lblAccepted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Lime
            Me.Label7.Location = New System.Drawing.Point(16, 43)
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
            Me.lblFileQty.Location = New System.Drawing.Point(224, 3)
            Me.lblFileQty.Name = "lblFileQty"
            Me.lblFileQty.Size = New System.Drawing.Size(96, 31)
            Me.lblFileQty.TabIndex = 84
            Me.lblFileQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Lime
            Me.Label6.Location = New System.Drawing.Point(16, 3)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(208, 31)
            Me.Label6.TabIndex = 83
            Me.Label6.Text = "Devices in file :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel6
            '
            Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlPN, Me.pnlDiscrepOption, Me.pnlSku, Me.PanelSN, Me.Button4, Me.PanelOptions, Me.PanelIMEI})
            Me.Panel6.Location = New System.Drawing.Point(1, 145)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(591, 120)
            Me.Panel6.TabIndex = 110
            '
            'pnlPN
            '
            Me.pnlPN.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlPN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlPN.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button5, Me.Label4, Me.txtPartNumber})
            Me.pnlPN.Location = New System.Drawing.Point(8, 79)
            Me.pnlPN.Name = "pnlPN"
            Me.pnlPN.Size = New System.Drawing.Size(217, 32)
            Me.pnlPN.TabIndex = 2
            '
            'Button5
            '
            Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button5.Location = New System.Drawing.Point(144, 245)
            Me.Button5.Name = "Button5"
            Me.Button5.Size = New System.Drawing.Size(200, 31)
            Me.Button5.TabIndex = 66
            Me.Button5.TabStop = False
            Me.Button5.Text = "Generate Report"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(-1, 6)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(40, 16)
            Me.Label4.TabIndex = 83
            Me.Label4.Text = "P/N :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPartNumber
            '
            Me.txtPartNumber.BackColor = System.Drawing.Color.White
            Me.txtPartNumber.Location = New System.Drawing.Point(40, 4)
            Me.txtPartNumber.MaxLength = 15
            Me.txtPartNumber.Name = "txtPartNumber"
            Me.txtPartNumber.Size = New System.Drawing.Size(159, 20)
            Me.txtPartNumber.TabIndex = 3
            Me.txtPartNumber.Text = ""
            '
            'pnlDiscrepOption
            '
            Me.pnlDiscrepOption.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlDiscrepOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlDiscrepOption.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkLessThan30Days, Me.chkExtraItem, Me.chkWrongSku})
            Me.pnlDiscrepOption.Location = New System.Drawing.Point(455, 6)
            Me.pnlDiscrepOption.Name = "pnlDiscrepOption"
            Me.pnlDiscrepOption.Size = New System.Drawing.Size(129, 106)
            Me.pnlDiscrepOption.TabIndex = 6
            '
            'chkLessThan30Days
            '
            Me.chkLessThan30Days.Enabled = False
            Me.chkLessThan30Days.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLessThan30Days.ForeColor = System.Drawing.Color.White
            Me.chkLessThan30Days.Location = New System.Drawing.Point(9, 64)
            Me.chkLessThan30Days.Name = "chkLessThan30Days"
            Me.chkLessThan30Days.Size = New System.Drawing.Size(103, 18)
            Me.chkLessThan30Days.TabIndex = 2
            Me.chkLessThan30Days.Text = "< 30 days"
            Me.chkLessThan30Days.Visible = False
            '
            'chkExtraItem
            '
            Me.chkExtraItem.Enabled = False
            Me.chkExtraItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkExtraItem.ForeColor = System.Drawing.Color.White
            Me.chkExtraItem.Location = New System.Drawing.Point(8, 37)
            Me.chkExtraItem.Name = "chkExtraItem"
            Me.chkExtraItem.Size = New System.Drawing.Size(104, 16)
            Me.chkExtraItem.TabIndex = 1
            Me.chkExtraItem.Text = "Extra Unit"
            '
            'chkWrongSku
            '
            Me.chkWrongSku.Enabled = False
            Me.chkWrongSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkWrongSku.ForeColor = System.Drawing.Color.White
            Me.chkWrongSku.Location = New System.Drawing.Point(8, 8)
            Me.chkWrongSku.Name = "chkWrongSku"
            Me.chkWrongSku.Size = New System.Drawing.Size(104, 19)
            Me.chkWrongSku.TabIndex = 0
            Me.chkWrongSku.Text = "Wrong Sku"
            '
            'pnlSku
            '
            Me.pnlSku.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlSku.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlSku.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.Label2, Me.txtSku})
            Me.pnlSku.Location = New System.Drawing.Point(8, 46)
            Me.pnlSku.Name = "pnlSku"
            Me.pnlSku.Size = New System.Drawing.Size(216, 32)
            Me.pnlSku.TabIndex = 1
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(144, 245)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(200, 31)
            Me.Button2.TabIndex = 66
            Me.Button2.TabStop = False
            Me.Button2.Text = "Generate Report"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(0, 4)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 16)
            Me.Label2.TabIndex = 85
            Me.Label2.Text = "Sku:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSku
            '
            Me.txtSku.BackColor = System.Drawing.Color.White
            Me.txtSku.Location = New System.Drawing.Point(40, 3)
            Me.txtSku.MaxLength = 5
            Me.txtSku.Name = "txtSku"
            Me.txtSku.Size = New System.Drawing.Size(159, 20)
            Me.txtSku.TabIndex = 0
            Me.txtSku.Text = ""
            '
            'PanelSN
            '
            Me.PanelSN.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelSN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button8, Me.Label1, Me.txtSN})
            Me.PanelSN.Location = New System.Drawing.Point(231, 79)
            Me.PanelSN.Name = "PanelSN"
            Me.PanelSN.Size = New System.Drawing.Size(217, 32)
            Me.PanelSN.TabIndex = 4
            '
            'Button8
            '
            Me.Button8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button8.Location = New System.Drawing.Point(144, 245)
            Me.Button8.Name = "Button8"
            Me.Button8.Size = New System.Drawing.Size(200, 31)
            Me.Button8.TabIndex = 66
            Me.Button8.TabStop = False
            Me.Button8.Text = "Generate Report"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(0, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 16)
            Me.Label1.TabIndex = 83
            Me.Label1.Text = "SN :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.White
            Me.txtSN.Location = New System.Drawing.Point(40, 4)
            Me.txtSN.MaxLength = 15
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(159, 20)
            Me.txtSN.TabIndex = 2
            Me.txtSN.Text = ""
            '
            'Button4
            '
            Me.Button4.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Button4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button4.Location = New System.Drawing.Point(144, 245)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(200, 31)
            Me.Button4.TabIndex = 66
            Me.Button4.TabStop = False
            Me.Button4.Text = "Generate Report"
            '
            'PanelOptions
            '
            Me.PanelOptions.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSkuPartNumber, Me.Label8, Me.lblModel, Me.Button3})
            Me.PanelOptions.Location = New System.Drawing.Point(8, 6)
            Me.PanelOptions.Name = "PanelOptions"
            Me.PanelOptions.Size = New System.Drawing.Size(440, 35)
            Me.PanelOptions.TabIndex = 5
            '
            'lblSkuPartNumber
            '
            Me.lblSkuPartNumber.BackColor = System.Drawing.Color.Transparent
            Me.lblSkuPartNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSkuPartNumber.ForeColor = System.Drawing.Color.Black
            Me.lblSkuPartNumber.Location = New System.Drawing.Point(272, 8)
            Me.lblSkuPartNumber.Name = "lblSkuPartNumber"
            Me.lblSkuPartNumber.Size = New System.Drawing.Size(152, 16)
            Me.lblSkuPartNumber.TabIndex = 94
            Me.lblSkuPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSkuPartNumber.Visible = False
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(-56, 6)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(56, 16)
            Me.Label8.TabIndex = 88
            Me.Label8.Text = "Model :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(2, 7)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(232, 16)
            Me.lblModel.TabIndex = 86
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Button3
            '
            Me.Button3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button3.Location = New System.Drawing.Point(16, 245)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(200, 31)
            Me.Button3.TabIndex = 66
            Me.Button3.TabStop = False
            Me.Button3.Text = "Generate Report"
            '
            'PanelIMEI
            '
            Me.PanelIMEI.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelIMEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelIMEI.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button6, Me.Label3, Me.txtIMEI})
            Me.PanelIMEI.Location = New System.Drawing.Point(232, 46)
            Me.PanelIMEI.Name = "PanelIMEI"
            Me.PanelIMEI.Size = New System.Drawing.Size(216, 32)
            Me.PanelIMEI.TabIndex = 3
            '
            'Button6
            '
            Me.Button6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button6.Location = New System.Drawing.Point(144, 245)
            Me.Button6.Name = "Button6"
            Me.Button6.Size = New System.Drawing.Size(200, 31)
            Me.Button6.TabIndex = 66
            Me.Button6.TabStop = False
            Me.Button6.Text = "Generate Report"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(0, 5)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(39, 16)
            Me.Label3.TabIndex = 85
            Me.Label3.Text = "IMEI:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtIMEI
            '
            Me.txtIMEI.BackColor = System.Drawing.Color.White
            Me.txtIMEI.Location = New System.Drawing.Point(40, 4)
            Me.txtIMEI.MaxLength = 15
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(159, 20)
            Me.txtIMEI.TabIndex = 1
            Me.txtIMEI.Text = ""
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.Black
            Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
            Me.lblHeader.Location = New System.Drawing.Point(1, 1)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(271, 103)
            Me.lblHeader.TabIndex = 111
            Me.lblHeader.Text = "TRACFONE PRODUCTION RECEIVING"
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbOpenRMA, Me.Label5, Me.Button1, Me.btnCloseRMA})
            Me.Panel1.Location = New System.Drawing.Point(1, 105)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(591, 40)
            Me.Panel1.TabIndex = 109
            '
            'cmbOpenRMA
            '
            Me.cmbOpenRMA.AutoComplete = True
            Me.cmbOpenRMA.BackColor = System.Drawing.SystemColors.Window
            Me.cmbOpenRMA.DropDownWidth = 300
            Me.cmbOpenRMA.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbOpenRMA.ForeColor = System.Drawing.Color.Black
            Me.cmbOpenRMA.Location = New System.Drawing.Point(104, 9)
            Me.cmbOpenRMA.MaxDropDownItems = 30
            Me.cmbOpenRMA.Name = "cmbOpenRMA"
            Me.cmbOpenRMA.Size = New System.Drawing.Size(360, 21)
            Me.cmbOpenRMA.TabIndex = 84
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label5.Location = New System.Drawing.Point(0, 10)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 16)
            Me.Label5.TabIndex = 83
            Me.Label5.Text = "RMA Number :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Button1
            '
            Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button1.Location = New System.Drawing.Point(144, 245)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(200, 31)
            Me.Button1.TabIndex = 66
            Me.Button1.TabStop = False
            Me.Button1.Text = "Generate Report"
            '
            'btnCloseRMA
            '
            Me.btnCloseRMA.BackColor = System.Drawing.Color.Navy
            Me.btnCloseRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseRMA.ForeColor = System.Drawing.Color.White
            Me.btnCloseRMA.Location = New System.Drawing.Point(478, 7)
            Me.btnCloseRMA.Name = "btnCloseRMA"
            Me.btnCloseRMA.Size = New System.Drawing.Size(104, 24)
            Me.btnCloseRMA.TabIndex = 3
            Me.btnCloseRMA.Text = "CLOSE RMA"
            '
            'dbgRecUnits
            '
            Me.dbgRecUnits.AllowUpdate = False
            Me.dbgRecUnits.AlternatingRows = True
            Me.dbgRecUnits.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgRecUnits.FilterBar = True
            Me.dbgRecUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRecUnits.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgRecUnits.Location = New System.Drawing.Point(1, 265)
            Me.dbgRecUnits.Name = "dbgRecUnits"
            Me.dbgRecUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRecUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRecUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgRecUnits.Size = New System.Drawing.Size(919, 215)
            Me.dbgRecUnits.TabIndex = 114
            Me.dbgRecUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16""" & _
            " DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>2" & _
            "11</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 915, 211<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 915, 211</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'lblMsg
            '
            Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
            Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMsg.ForeColor = System.Drawing.Color.White
            Me.lblMsg.Location = New System.Drawing.Point(273, 1)
            Me.lblMsg.Name = "lblMsg"
            Me.lblMsg.Size = New System.Drawing.Size(647, 102)
            Me.lblMsg.TabIndex = 113
            Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmProdLineRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(936, 501)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlFileInfo, Me.Panel6, Me.lblHeader, Me.Panel1, Me.dbgRecUnits, Me.lblMsg})
            Me.Name = "frmProdLineRec"
            Me.Text = "frmProdLineRec"
            Me.pnlFileInfo.ResumeLayout(False)
            Me.Panel6.ResumeLayout(False)
            Me.pnlPN.ResumeLayout(False)
            Me.pnlDiscrepOption.ResumeLayout(False)
            Me.pnlSku.ResumeLayout(False)
            Me.PanelSN.ResumeLayout(False)
            Me.PanelOptions.ResumeLayout(False)
            Me.PanelIMEI.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

    End Class
End Namespace