Option Explicit On 

Public Class frmHTCProdRec
    Inherits System.Windows.Forms.Form

    Private _objHTC As PSS.Data.Buisness.HTC
    Private _iWO_ID As Integer = 0
    Private _iTray_ID As Integer = 0
    Private _strCustSku As String = ""


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New PSS.Data.Buisness.HTC()

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
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lblRcvd As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblRejected As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblAccepted As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PanelOptions As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlFileInfo As System.Windows.Forms.Panel
    Friend WithEvents PanelSN As System.Windows.Forms.Panel
    Friend WithEvents PanelIMEI As System.Windows.Forms.Panel
    Friend WithEvents txtSku As System.Windows.Forms.TextBox
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFileQty As System.Windows.Forms.Label
    Friend WithEvents btnCloseRMA As System.Windows.Forms.Button
    Friend WithEvents dbgRecUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents pnlDiscrepOption As System.Windows.Forms.Panel
    Friend WithEvents chkWrongSku As System.Windows.Forms.CheckBox
    Friend WithEvents chkExtraItem As System.Windows.Forms.CheckBox
    Friend WithEvents chkLessThan30Days As System.Windows.Forms.CheckBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmbOpenRMA As PSS.Gui.Controls.ComboBox
    Friend WithEvents pnlPN As System.Windows.Forms.Panel
    Friend WithEvents pnlSku As System.Windows.Forms.Panel
    Friend WithEvents lblSkuPartNumber As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTCProdRec))
        Me.btnCloseRMA = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.pnlFileInfo = New System.Windows.Forms.Panel()
        Me.lblRcvd = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblRejected = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblAccepted = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblFileQty = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbOpenRMA = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.dbgRecUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlFileInfo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlPN.SuspendLayout()
        Me.pnlDiscrepOption.SuspendLayout()
        Me.pnlSku.SuspendLayout()
        Me.PanelSN.SuspendLayout()
        Me.PanelOptions.SuspendLayout()
        Me.PanelIMEI.SuspendLayout()
        CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCloseRMA
        '
        Me.btnCloseRMA.BackColor = System.Drawing.Color.Navy
        Me.btnCloseRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseRMA.ForeColor = System.Drawing.Color.White
        Me.btnCloseRMA.Location = New System.Drawing.Point(502, 7)
        Me.btnCloseRMA.Name = "btnCloseRMA"
        Me.btnCloseRMA.Size = New System.Drawing.Size(104, 24)
        Me.btnCloseRMA.TabIndex = 3
        Me.btnCloseRMA.Text = "CLOSE RMA"
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
        Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.White
        Me.lblMsg.Location = New System.Drawing.Point(272, 1)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(680, 102)
        Me.lblMsg.TabIndex = 106
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlFileInfo
        '
        Me.pnlFileInfo.BackColor = System.Drawing.Color.Black
        Me.pnlFileInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFileInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRcvd, Me.Label11, Me.lblRejected, Me.Label9, Me.lblAccepted, Me.Label7, Me.lblFileQty, Me.Label6})
        Me.pnlFileInfo.Location = New System.Drawing.Point(616, 104)
        Me.pnlFileInfo.Name = "pnlFileInfo"
        Me.pnlFileInfo.Size = New System.Drawing.Size(336, 160)
        Me.pnlFileInfo.TabIndex = 105
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbOpenRMA, Me.Label5, Me.Button1, Me.btnCloseRMA})
        Me.Panel1.Location = New System.Drawing.Point(0, 104)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 40)
        Me.Panel1.TabIndex = 0
        '
        'cmbOpenRMA
        '
        Me.cmbOpenRMA.AutoComplete = True
        Me.cmbOpenRMA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbOpenRMA.DropDownWidth = 300
        Me.cmbOpenRMA.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOpenRMA.ForeColor = System.Drawing.Color.Black
        Me.cmbOpenRMA.Location = New System.Drawing.Point(112, 9)
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
        Me.Label5.Location = New System.Drawing.Point(8, 10)
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
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlPN, Me.pnlDiscrepOption, Me.pnlSku, Me.PanelSN, Me.Button4, Me.PanelOptions, Me.PanelIMEI})
        Me.Panel6.Location = New System.Drawing.Point(1, 144)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(615, 120)
        Me.Panel6.TabIndex = 100
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
        Me.pnlDiscrepOption.Size = New System.Drawing.Size(152, 106)
        Me.pnlDiscrepOption.TabIndex = 6
        '
        'chkLessThan30Days
        '
        Me.chkLessThan30Days.Enabled = False
        Me.chkLessThan30Days.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLessThan30Days.ForeColor = System.Drawing.Color.White
        Me.chkLessThan30Days.Location = New System.Drawing.Point(9, 69)
        Me.chkLessThan30Days.Name = "chkLessThan30Days"
        Me.chkLessThan30Days.Size = New System.Drawing.Size(112, 18)
        Me.chkLessThan30Days.TabIndex = 2
        Me.chkLessThan30Days.Text = "< 30 days"
        '
        'chkExtraItem
        '
        Me.chkExtraItem.Enabled = False
        Me.chkExtraItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExtraItem.ForeColor = System.Drawing.Color.White
        Me.chkExtraItem.Location = New System.Drawing.Point(8, 37)
        Me.chkExtraItem.Name = "chkExtraItem"
        Me.chkExtraItem.Size = New System.Drawing.Size(112, 16)
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
        Me.chkWrongSku.Size = New System.Drawing.Size(112, 19)
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
        Me.lblSkuPartNumber.Location = New System.Drawing.Point(304, 8)
        Me.lblSkuPartNumber.Name = "lblSkuPartNumber"
        Me.lblSkuPartNumber.Size = New System.Drawing.Size(120, 16)
        Me.lblSkuPartNumber.TabIndex = 94
        Me.lblSkuPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSkuPartNumber.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(72, 6)
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
        Me.lblModel.Location = New System.Drawing.Point(128, 7)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(232, 16)
        Me.lblModel.TabIndex = 86
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(144, 245)
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
        Me.lblHeader.TabIndex = 104
        Me.lblHeader.Text = "TRACFONE PRODUCTION RECEIVING"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.dbgRecUnits.Size = New System.Drawing.Size(951, 328)
        Me.dbgRecUnits.TabIndex = 108
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
        " DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
        "24</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
        "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
        "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
        "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
        """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
        "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
        "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
        """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 947, 324<" & _
        "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
        "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
        "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
        "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
        "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
        "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
        "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
        "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
        "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
        "ultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 947, 324</ClientArea><Pr" & _
        "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
        "Style21"" /></Blob>"
        '
        'frmHTCProdRec
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(968, 621)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgRecUnits, Me.lblMsg, Me.pnlFileInfo, Me.Panel1, Me.Panel6, Me.lblHeader})
        Me.Name = "frmHTCProdRec"
        Me.Text = "frmHTCProdRec"
        Me.pnlFileInfo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.pnlPN.ResumeLayout(False)
        Me.pnlDiscrepOption.ResumeLayout(False)
        Me.pnlSku.ResumeLayout(False)
        Me.PanelSN.ResumeLayout(False)
        Me.PanelOptions.ResumeLayout(False)
        Me.PanelIMEI.ResumeLayout(False)
        CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmHTCProdRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            Me.LoadOpenRMA()

            Me.cmbOpenRMA.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadOpenRMA()
        Dim dt As DataTable

        Try
            dt = Me._objHTC.GetProdRecOpenRMA()

            With Me.cmbOpenRMA
                .DataSource = dt.DefaultView
                .ValueMember = dt.Columns("WO_ID").ToString
                .DisplayMember = dt.Columns("WO_CustWO").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub cmbOpenRMA_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOpenRMA.SelectionChangeCommitted
        Try
            Me.ClearCtrls_GlobalVarsForNewRMA()
            If Me.cmbOpenRMA.SelectedValue = 0 Then
                Exit Sub
            Else
                Me._iTray_ID = PSS.Data.Buisness.Generic.GetLastTrayIDOfWOID(Me._iWO_ID, "", )
                If Me._iTray_ID = 0 Then
                    MessageBox.Show("Can't define ""Tray ID"" for this RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.cmbOpenRMA.SelectedValue = 0
                    Exit Sub
                End If
                Me._iWO_ID = Me.cmbOpenRMA.SelectedValue
                Me.PopulateReceiveUnits()
                Me.txtSku.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cmbOpenRMA_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtIMEI_SN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIMEI.KeyPress, txtSN.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "IMEI_SN_PartNumber_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtPartNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartNumber.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) And e.KeyChar <> "-" Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "IMEI_SN_PartNumber_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtSku_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSku.KeyPress
        Try
            If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sku_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateReceiveUnits()
        Dim dt, dt1 As DataTable
        Dim i As Integer = 0

        Try
            If Me.cmbOpenRMA.SelectedValue = 0 Then
                Exit Sub
            End If

            dt = Me._objHTC.GetRecAndDiscrUnits(Me.cmbOpenRMA.SelectedItem(Me.cmbOpenRMA.DisplayMember))
            With Me.dbgRecUnits
                .DataSource = Nothing

                .DataSource = dt.DefaultView
                .Visible = True

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                    .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                Next i

                .Splits(0).DisplayColumns("RMA").Width = 80
                .Splits(0).DisplayColumns("Sku").Width = 50
                .Splits(0).DisplayColumns("SN").Width = 93
                .Splits(0).DisplayColumns("IMEI").Width = 110
                .Splits(0).DisplayColumns("P/N").Width = 100
                .Splits(0).DisplayColumns("ASN Wrty").Width = 60
                .Splits(0).DisplayColumns("Unit Wrty").Width = 60
                .Splits(0).DisplayColumns("Model").Width = 120
                .Splits(0).DisplayColumns("Repeat Rep").Width = 70
                .Splits(0).DisplayColumns("Station").Width = 80
                .Splits(0).DisplayColumns("Extra Unit").Width = 70
                .Splits(0).DisplayColumns("Missing Unit").Width = 70
                .Splits(0).DisplayColumns("Wrong Sku").Width = 70
                .Splits(0).DisplayColumns("Duplicate").Width = 70
                .Splits(0).DisplayColumns("Sku").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Repeat Rep").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Extra Unit").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Missing Unit").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Wrong Sku").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Duplicate").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                '.Splits(0).EvenRowStyle.BackColor = Color.White
                '.Splits(0).OddRowStyle.BackColor = Color.White

                .MoveLast()
            End With

            dt1 = Me._objHTC.GetRMAInfo(Me.cmbOpenRMA.SelectedItem(Me.cmbOpenRMA.DisplayMember))
            Me.lblFileQty.Text = dt1.Rows.Count
            Me.lblAccepted.Text = dt1.Select("Device_ID is not null and DiscUnit = 0").Length
            Me.lblRejected.Text = dt1.Select("Device_ID is not null and DiscUnit = 1").Length
            Me.lblRcvd.Text = dt1.Select("Device_ID is not null").Length

            Me.btnCloseRMA.Visible = True

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnNewRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me._iWO_ID > 0 And Me.lblRcvd.Text.Trim.Length > 0 Then
                Me._objHTC.UpdateWOQuantity(Me._iWO_ID, CInt(Me.lblRcvd.Text))
            End If

            Me.ClearCtrls_GlobalVarsForNewRMA()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnNewRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub ClearCtrls_GlobalVarsForNewRMA()
        Me._iWO_ID = 0
        Me._iTray_ID = 0
        Me._strCustSku = ""

        Me.txtSku.Text = ""
        Me.txtIMEI.Text = ""
        Me.txtSN.Text = ""
        Me.txtPartNumber.Text = ""
        Me.lblMsg.Text = ""
        Me.lblMsg.BackColor = Color.SteelBlue
        Me.lblFileQty.Text = ""
        Me.lblAccepted.Text = ""
        Me.lblRejected.Text = ""
        Me.lblRcvd.Text = ""
        Me.lblModel.Text = ""

        Me.dbgRecUnits.DataSource = Nothing
        Me.dbgRecUnits.Visible = False
        Me.btnCloseRMA.Visible = False

        Me.chkWrongSku.Checked = False
        Me.chkExtraItem.Checked = False
        Me.chkLessThan30Days.Checked = False

        Me.txtSku.Tag = ""
        Me.lblModel.Tag = ""

        Me.cmbOpenRMA.Focus()
    End Sub

    '******************************************************************
    Private Sub txtSku_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSku.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Me.txtSku.Text.Trim.Length = 0 Then Exit Sub

                Me.txtPartNumber.Text = ""
                Me.txtIMEI.Text = ""
                Me.txtSN.Text = ""

                Me.ProcessSku()
                Me.txtPartNumber.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSku_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtSku.SelectAll()
        End Try
    End Sub

    '******************************************************************
    Private Sub txtSku_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSku.Leave
        Try
            If Me.txtSku.Text.Trim.Length = 0 Then
                Exit Sub
            End If

            Me.ProcessSku()
            If Me.txtIMEI.Text.Trim.Length > 0 Then
                Me.ProcessIMEI()
                Me.txtSN.SelectAll()
                Me.txtSN.Focus()
            Else
                Me.txtPartNumber.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSku_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtSku.Text = ""
        End Try
    End Sub

    '******************************************************************
    Private Sub ProcessSku()
        Dim dt As DataTable

        Try
            'RESET VARIABLE
            Me._strCustSku = ""
            Me.lblSkuPartNumber.Text = ""
            Me.txtSku.Tag = 0
            Me.lblModel.Text = ""
            Me.lblModel.Tag = 0
            Me._strCustSku = ""

            If Me.chkWrongSku.Checked = False Then
                dt = Me._objHTC.GetHTCSkuInfo(Me.txtSku.Text.Trim.ToUpper)
                If dt.Rows.Count = 0 Then
                    'Throw New Exception("This Sku number has not yet set up in the system. Please contact your supervisor for advice.")
                    If MessageBox.Show("This Sku number has not set up in the system. Would you like to receive as discrepancy unit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Me.chkWrongSku.Checked = True
                    Else
                        Me.txtSku.Text = ""
                        Exit Sub
                    End If
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("This Sku number existed twice in the system. Please contact IT.")
                Else
                    Me.lblSkuPartNumber.Text = dt.Rows(0)("Sku_PartNo")
                    Me.txtSku.Tag = dt.Rows(0)("Sku_ID")
                    Me.lblModel.Text = dt.Rows(0)("Model_Desc")
                    Me.lblModel.Tag = dt.Rows(0)("Model_ID")
                    Me._strCustSku = dt.Rows(0)("Sku_Desc")
                End If
            End If

            Me.txtPartNumber.Focus()

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Me.txtIMEI.Text.Trim.Length = 0 Then Exit Sub

                If Me.txtPartNumber.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter part number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.Text = ""
                    Me.txtPartNumber.Focus()
                    Exit Sub
                End If

                Me.Enabled = False
                Me.ProcessIMEI()
                Me.Enabled = True
                Me.txtSN.Text = ""
                Me.txtSN.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtIMEI.SelectAll()
        Finally
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************
    Private Function ProcessIMEI() As DataTable
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim drArrayNonDiscrepancy As DataRow()

        Try
            '**************************
            'check for duplicate
            '**************************
            If Me.dbgRecUnits.RowCount > 0 Then
                For i = 0 To Me.dbgRecUnits.RowCount - 1
                    If Me.dbgRecUnits.Item(i, "IMEI").ToString.Trim.ToUpper = Me.txtIMEI.Text.Trim.ToUpper And Me.dbgRecUnits.Item(i, "Duplicate").ToString.Trim.Length = 0 Then
                        Throw New Exception("This IMEI is already received.")
                    End If
                Next i
            End If

            '**************************
            'check for format
            '**************************
            If Me.CheckValidIMEIFormat() = False Then
                Me.txtIMEI.SelectAll()
                Me.txtIMEI.Focus()
                Exit Function
            End If

            '**************************
            'Get IMEI Information
            '**************************
            dt = Me._objHTC.GetIMEI_InRMA(Me.txtIMEI.Text.Trim.ToUpper, Me.cmbOpenRMA.SelectedItem(Me.cmbOpenRMA.DisplayMember).Trim.ToUpper)
            If dt.Rows.Count = 0 Then
                If Me.chkExtraItem.Checked = False Then
                    If MessageBox.Show("This IMEI number is missing in RMA. Would you like to receive them as extra unit for this RMA?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        Me.txtSN.Text = ""
                        Me.txtIMEI.Focus()
                        Exit Function
                    Else
                        Me.chkExtraItem.Checked = True
                    End If
                End If
            Else
                If dt.Select("DiscUnit = 0").Length > 1 Then
                    Throw New Exception("This IMEI number existed twice in the system under the same RMA. Please contact IT.")
                ElseIf dt.Select("DiscUnit = 1").Length = dt.Rows.Count Then
                    Throw New Exception("This is a discrepant unit.")
                Else
                    drArrayNonDiscrepancy = dt.Select("DiscUnit = 0")
                    For i = 0 To drArrayNonDiscrepancy.Length - 1
                        If Not IsDBNull(dt.Rows(0)("Device_ID")) Then
                            Throw New Exception("This IMEI already received.")
                        End If
                    Next i
                End If
            End If

            Me.txtSN.Focus()

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Function

    '******************************************************************
    Private Function CheckValidIMEIFormat() As Boolean
        Dim booResult As Boolean = True
        Dim i As Integer = 0
        Try
            If Me.txtIMEI.Text.Trim.Length = 0 Then
                booResult = False
            ElseIf Me.txtIMEI.Text.Trim.Length <> 15 Then
                MessageBox.Show("IMEI must be 15 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                booResult = False
            ElseIf Me.txtIMEI.Text.Trim.StartsWith("34") = False And Me.txtIMEI.Text.Trim.StartsWith("35") = False And Me.txtIMEI.Text.Trim.StartsWith("36") = False Then
                MessageBox.Show("IMEI must start with either 34, 35 or 36.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                booResult = False
            Else
                For i = 1 To Me.txtIMEI.Text.Trim.Length
                    If Char.IsDigit(Mid(Me.txtIMEI.Text.Trim, i)) = False Then
                        MessageBox.Show("IMEI must be 15 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        booResult = False
                        Exit For
                    End If
                Next i
            End If

            Return booResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '******************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Dim i As Integer
        Dim iWrty As Integer = 0
        Dim iModelID As Integer = 0
        Dim iSkuID As Integer = 0
        Dim ihd_ID As Integer = 0
        Dim iPrevRepDeviceID As Integer = 0
        Dim dtIMEI_Data As DataTable
        Dim iWrongSku As Integer = 0
        Dim iExtraItem As Integer = 0
        Dim iLessThan30Days As Integer = 0
        Dim R1 As DataRow = Nothing
        Dim drRepeatRep As DataRow = Nothing
        Dim dteToday As Date

        Try
            If e.KeyValue = 13 Then
                If Me.txtSN.Text.Trim <> "" Then

                    '**************************
                    'check for duplicate in RMA
                    '**************************
                    If Me.dbgRecUnits.RowCount > 0 Then
                        For i = 0 To Me.dbgRecUnits.RowCount - 1
                            If Me.dbgRecUnits.Item(i, "SN").ToString.Trim.ToUpper = Me.txtSN.Text.Trim.ToUpper And Me.dbgRecUnits.Item(i, "Duplicate").ToString.Trim.Length = 0 Then
                                MsgBox("This SN is already received.", MsgBoxStyle.Critical)
                                Me.txtSN.SelectAll()
                                Exit Sub
                            End If
                        Next i
                    End If
                    '**************************
                    'check for open ship SN
                    '**************************
                    If PSS.Data.Buisness.Generic.IsSNInWIP(PSS.Data.Buisness.HTC.HTC_CUSTOMER_ID, Me.txtSN.Text.Trim.ToUpper) = True Then
                        MsgBox("S/N is already existed in WIP please contact IT.", MsgBoxStyle.Critical)
                        Me.txtSN.SelectAll()
                        Exit Sub
                    End If
                    '**************************

                    If Not IsNothing(Me.txtSku.Tag) AndAlso Me.txtSku.Tag.ToString.Trim.Length > 0 Then iSkuID = CInt(Me.txtSku.Tag)
                    If Not IsNothing(Me.lblModel.Tag) AndAlso Me.lblModel.Tag.ToString.Trim.Length > 0 Then iModelID = CInt(Me.lblModel.Tag)

                    If Me.txtSN.Text.Trim.ToUpper.StartsWith("TF") = False Then
                        MsgBox("SN must start with TF.", MsgBoxStyle.Critical)
                    ElseIf Me.txtIMEI.Text.Trim.Length = 0 Then
                        MsgBox("Please enter IMEI number.", MsgBoxStyle.Critical)
                        Me.txtIMEI.SelectAll()
                        Me.txtIMEI.Focus()
                    ElseIf Me.CheckValidIMEIFormat = False Then
                        Me.txtSN.Text = ""
                        Me.txtIMEI.SelectAll()
                        Me.txtIMEI.Focus()
                    ElseIf Me.txtPartNumber.Text.Trim.Length = 0 Then
                        MsgBox("Please enter Part number.", MsgBoxStyle.Critical)
                        Me.txtIMEI.Text = ""
                        Me.txtSN.Text = ""
                        Me.txtPartNumber.Focus()
                    ElseIf Me.txtPartNumber.Text.Trim.ToUpper.StartsWith(Mid(Me.lblSkuPartNumber.Text.Trim, 1, Me.lblSkuPartNumber.Text.Trim.Length - 2).ToUpper) = False Then
                        MsgBox("Invalid Part Number.", MsgBoxStyle.Critical)
                        Me.txtIMEI.Text = ""
                        Me.txtSN.Text = ""
                        Me.txtPartNumber.Focus()
                    ElseIf Me.txtSku.Text.Trim.Length = 0 Then
                        MsgBox("Please enter Sku number.", MsgBoxStyle.Critical)
                        Me.txtSN.Text = ""
                        Me.txtIMEI.Text = ""
                        Me.txtPartNumber.Text = ""
                        Me.txtSku.Focus()
                    ElseIf (iSkuID = 0 Or iModelID = 0) And Me.chkWrongSku.Checked = False Then
                        MsgBox("System can't define SkuID/ModelID/PartNumber relationship for this unit please re-enter Sku Number.", MsgBoxStyle.Critical)
                        Me.txtSN.Text = ""
                        Me.txtIMEI.Text = ""
                        Me.txtPartNumber.Text = ""
                        Me.txtSku.SelectAll()
                        Me.txtSku.Focus()
                    Else
                        '**************************
                        'Get previous ship date
                        '**************************
                        If Me.chkWrongSku.Checked = False And Me.chkExtraItem.Checked = False And Me.chkLessThan30Days.Checked = False Then
                            drRepeatRep = Me._objHTC.HTC_PreviousRepInfo(Me.txtSN.Text.Trim.ToUpper)
                            If Not IsNothing(drRepeatRep) Then
                                If IsDBNull(drRepeatRep("Device_DateShip")) Then
                                    Throw New Exception("This SN is already existed in WIP.")
                                End If

                                dteToday = PSS.Data.Buisness.Generic.MySQLServerDateTime()
                                If DateDiff(DateInterval.Day, CDate(dteToday), drRepeatRep("Device_ShipWorkDate")) <= 90 Then
                                    iPrevRepDeviceID = drRepeatRep("Device_ID")
                                End If
                            End If
                        End If

                        '******************************************
                        dtIMEI_Data = Me.ProcessIMEI()

                        If Not IsNothing(dtIMEI_Data) = True AndAlso dtIMEI_Data.Rows.Count > 0 Then
                            If dtIMEI_Data.Select("DiscUnit = 0 and (Device_ID is null or Device_ID = '' or Device_ID = 0)").Length = 0 Then
                                Me.txtIMEI.Text = ""
                                Me.txtSN.Text = ""
                                Exit Sub
                            Else
                                R1 = dtIMEI_Data.Select("DiscUnit = 0 and (Device_ID is null or Device_ID = '' or Device_ID = 0)")(0)

                                '*********************
                                Me.ProcessSku()
                                If Me._strCustSku.Trim.ToUpper <> Me.cmbOpenRMA.SelectedItem("Sku_Desc").ToString.Trim.ToUpper And Me.chkWrongSku.Checked = False Then
                                    'compare wo sku instead of file sku.
                                    'If Me._strCustSku.Trim.ToUpper <> R1("hd_Sku").ToString.Trim.ToUpper And Me.chkWrongSku.Checked = False Then
                                    If MessageBox.Show("The sku of this device does not match with RMA. Would you like to receive as wrong model?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                        Me._strCustSku = ""
                                        Me.txtSku.Text = ""
                                        Me.txtIMEI.Text = ""
                                        Me.txtSN.Text = ""
                                        Me.txtSku.Focus()
                                        Exit Sub
                                    Else
                                        Me.chkWrongSku.Checked = True
                                    End If
                                End If

                                '******************************************
                                If Me.chkWrongSku.Checked = True Then
                                    iWrongSku = 1
                                End If
                                If Me.chkExtraItem.Checked = True Then
                                    iExtraItem = 1
                                End If
                                If Me.chkLessThan30Days.Checked = True Then
                                    iLessThan30Days = 1
                                End If

                                '******************************************
                                'Check Warranty and discrepancy
                                '******************************************
                                iWrty = Me.CheckDeviceWrty(Me.txtSN.Text.Trim.ToUpper, Me.cmbOpenRMA.SelectedItem("WO_Date"))
                                If iWrongSku > 0 Then
                                    Me.lblMsg.Text = "WRONG SKU"
                                    Me.lblMsg.BackColor = Color.ForestGreen
                                ElseIf iExtraItem > 0 Then
                                    Me.lblMsg.Text = "EXTRA UNIT"
                                    Me.lblMsg.BackColor = Color.ForestGreen
                                ElseIf iLessThan30Days > 0 Then
                                    Me.lblMsg.Text = "< 30 DAYS"
                                    Me.lblMsg.BackColor = Color.ForestGreen
                                ElseIf iWrty > 0 Then
                                    Me.lblMsg.Text = "IN WARRANTY"
                                    Me.lblMsg.BackColor = Color.SteelBlue
                                Else
                                    Me.lblMsg.Text = "OUT WARRANTY"
                                    Me.lblMsg.BackColor = Color.ForestGreen
                                End If

                                '******************************************
                                Me.Enabled = False
                                Cursor.Current = Cursors.WaitCursor
                                ihd_ID = R1("hd_ID")

                                i = Me._objHTC.ProdReceive(Me.cmbOpenRMA.SelectedItem(Me.cmbOpenRMA.DisplayMember).Trim.ToUpper, Me._iWO_ID, _
                                                           Me._iTray_ID, _
                                                           iModelID, iSkuID, _
                                                           Me.txtPartNumber.Text.Trim.ToUpper, _
                                                           Me.txtIMEI.Text.Trim, _
                                                           Me.txtSN.Text.Trim.ToUpper, _
                                                           ihd_ID, _
                                                           iWrty, _
                                                           PSS.Core.Global.ApplicationUser.IDShift, _
                                                           iPrevRepDeviceID, _
                                                           PSS.Core.Global.ApplicationUser.IDuser, _
                                                           PSS.Core.Global.ApplicationUser.User, _
                                                           PSS.Core.Global.ApplicationUser.NumberEmp, _
                                                           iWrongSku, _
                                                           iExtraItem, _
                                                           iLessThan30Days)

                                ClearControlsAndVariableForNewDevice()
                                Me.Enabled = True
                                Me.txtSku.Focus()
                            End If
                        ElseIf Me.chkExtraItem.Checked = False Then
                            Me.txtIMEI.Text = ""
                            Me.txtSN.Text = ""
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtSN.Text = ""
        Finally
            R1 = Nothing
            drRepeatRep = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dtIMEI_Data)
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub ClearControlsAndVariableForNewDevice()
        Me.txtSku.Text = ""
        Me.txtPartNumber.Text = ""
        Me.txtIMEI.Text = ""
        Me.txtSN.Text = ""

        Me.txtSku.Tag = ""
        Me.lblModel.Tag = ""

        Me.lblSkuPartNumber.Text = ""
        Me.lblModel.Text = ""

        Me.chkWrongSku.Checked = False
        Me.chkExtraItem.Checked = False
        Me.chkLessThan30Days.Checked = False

        Me._strCustSku = ""

        Me.PopulateReceiveUnits()
        Me.txtSku.Focus()
    End Sub

    ''******************************************************************
    'Public Function CheckDeviceWrty() As Integer
    '    Dim iWty As Integer = 0
    '    Dim iDevYrs As Integer = 0
    '    Dim iDevWeek As Integer = 0
    '    Dim dteExpirationDate As Date
    '    Dim iExpirationWeek As Integer = 0

    '    Try
    '        dteExpirationDate = DateAdd(DateInterval.Month, -15, CDate(Format(Me._dteToday, "yyyy-MM-dd")))
    '        iExpirationWeek = Me._objHTC.GetWeekNum(Format(dteExpirationDate, "yyyy-MM-dd"))

    '        iDevYrs = Mid(Me.txtSN.Text.Trim.ToUpper, 3, 1)
    '        iDevYrs = CInt(Mid(Year(Me._dteToday).ToString, 1, 3) & iDevYrs)

    '        If iDevYrs > Year(Me._dteToday) Then iDevYrs -= 10

    '        iDevWeek = CInt(Mid(Me.txtSN.Text.Trim.ToUpper, 4, 2))

    '        If iDevYrs > Year(dteExpirationDate) Then
    '            iWty = 1
    '        ElseIf iDevYrs = Year(dteExpirationDate) And iDevWeek >= iExpirationWeek Then
    '            iWty = 1
    '        Else
    '            iWty = 0
    '        End If

    '        Return iWty
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    '******************************************************************
    Public Function CheckDeviceWrty(ByVal strSN As String, _
                                    ByVal dateDockRec As Date) As Integer
        Dim iWty As Integer = 0
        Dim iDevYrs As Integer = 0
        Dim iDevWeek As Integer = 0
        Dim dteExpirationDate As Date
        Dim iExpirationWeek As Integer = 0

        Try
            dteExpirationDate = DateAdd(DateInterval.Day, -448, dateDockRec)
            iExpirationWeek = Me._objHTC.GetWeekNum(Format(dteExpirationDate, "yyyy-MM-dd"))

            iDevYrs = Mid(strSN.Trim.ToUpper, 3, 1)
            iDevYrs = CInt(Mid(Year(dateDockRec).ToString, 1, 3) & iDevYrs)
            If iDevYrs > Year(dateDockRec) Then iDevYrs -= 10

            iDevWeek = CInt(Mid(strSN.Trim.ToUpper, 4, 2))

            If iDevYrs > Year(dteExpirationDate) Then
                iWty = 1
            ElseIf iDevYrs = Year(dteExpirationDate) And iDevWeek >= iExpirationWeek Then
                iWty = 1
            Else
                iWty = 0
            End If

            Return iWty
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '******************************************************************
    Private Sub btnCloseRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseRMA.Click
        Dim strDiscrepancyConfirmMsg As String = ""
        Dim i As Integer = 0
        Dim iFileQty As Integer = 0
        Dim iScanQty As Integer = 0
        Dim iReject As Integer = 0

        Try
            If Me.cmbOpenRMA.SelectedItem(Me.cmbOpenRMA.DisplayMember).Trim.Length > 0 Then
                If Me.lblRcvd.Text.Trim.Length > 0 Then iScanQty = CInt(Me.lblRcvd.Text)
                If Me.lblFileQty.Text.Trim.Length > 0 Then iFileQty = CInt(Me.lblFileQty.Text)
                If Me.lblRejected.Text.Trim > 0 Then iReject = CInt(Me.lblRejected.Text)

                If Me._iWO_ID = 0 Then
                    MessageBox.Show("WO ID is missing for this RMA. Please re-scan RMA again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Me.lblRcvd.Text.Trim.Length = 0 Or Me.lblRcvd.Text.Trim = "0" Then
                    MessageBox.Show("This RMA is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf (iFileQty - iScanQty) > 0 Then
                    MessageBox.Show("There is " & (iFileQty - iScanQty) & " unit(s) left in this RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSku.Focus()
                    Exit Sub
                ElseIf (iFileQty - iScanQty) < 0 Or iReject > 0 Then
                    MessageBox.Show("This RMA contains discrepancy unit. Please see your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSku.Focus()
                    Exit Sub
                Else
                    'If MessageBox.Show(strDiscrepancyConfirmMsg & "Are you sure you want to close this RMA?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    i = Me._objHTC.CloseWO(Me._iWO_ID, CInt(Me.lblRcvd.Text), Me.cmbOpenRMA.SelectedItem(Me.cmbOpenRMA.DisplayMember).Trim.ToUpper, PSS.Core.Global.ApplicationUser.IDuser)
                    If i > 0 Then
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.ClearCtrls_GlobalVarsForNewRMA()
                        Me.LoadOpenRMA()
                        Me.cmbOpenRMA.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCloseRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtPartNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartNumber.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Me.txtPartNumber.Text.Trim.Length > 0 Then
                    If Me.txtPartNumber.Text.Trim.Trim.ToUpper.StartsWith(Mid(Me.lblSkuPartNumber.Text.Trim, 1, Me.lblSkuPartNumber.Text.Trim.Length - 2).ToUpper) = False Then
                        MsgBox("Invalid Part Number.", MsgBoxStyle.Critical)
                        Me.txtIMEI.Text = ""
                        Me.txtSN.Text = ""
                    ElseIf Me.txtPartNumber.Text.Trim.EndsWith("0") = False And Me.txtPartNumber.Text.Trim.EndsWith("1") = False Then
                        MsgBox("Invalid Part Number.", MsgBoxStyle.Critical)
                        Me.txtIMEI.Text = ""
                        Me.txtSN.Text = ""
                    Else
                        Me.txtIMEI.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCloseRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************

    Private Sub PanelOptions_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelOptions.Paint

    End Sub
End Class
