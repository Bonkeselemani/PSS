Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Public Class frmLabel
    Inherits System.Windows.Forms.Form

    Private _strScreenName As String = ""
    Private _objHTC As HTC
    Private _iDeviceID As Integer = 0
    Private _iModelID As Integer = 0
    Private _strDeviceWrkStation As String = ""
    Private _booValidIMEI As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strScreenName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._strScreenName = strScreenName
        Me.lblTitle.Text = Me._strScreenName
        Me._objHTC = New HTC()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            Me._objHTC = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblSymptom As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblNextStation As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents lblSku As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lblRMA As System.Windows.Forms.Label
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudQty As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblIMEI As System.Windows.Forms.Label
    Friend WithEvents txtLastDigitOfPN As System.Windows.Forms.TextBox
    Friend WithEvents lblLastDigitOfPN As System.Windows.Forms.Label
    Friend WithEvents pnlRelabel As System.Windows.Forms.Panel
    Friend WithEvents lblTobeLabelIMEI As System.Windows.Forms.Label
    Friend WithEvents txtTobeLabelIMEI As System.Windows.Forms.TextBox
    Friend WithEvents lblTobeLabelPNDisplay As System.Windows.Forms.Label
    Friend WithEvents lblTobeLabelPN As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlRelabel = New System.Windows.Forms.Panel()
        Me.lblTobeLabelPN = New System.Windows.Forms.Label()
        Me.lblTobeLabelPNDisplay = New System.Windows.Forms.Label()
        Me.txtTobeLabelIMEI = New System.Windows.Forms.TextBox()
        Me.lblTobeLabelIMEI = New System.Windows.Forms.Label()
        Me.txtLastDigitOfPN = New System.Windows.Forms.TextBox()
        Me.lblLastDigitOfPN = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudQty = New System.Windows.Forms.NumericUpDown()
        Me.lblNextStation = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblSku = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblRMA = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblSymptom = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pnlRelabel.SuspendLayout()
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(1, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(215, 57)
        Me.lblTitle.TabIndex = 121
        Me.lblTitle.Text = "MB LABEL"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSN
        '
        Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.Location = New System.Drawing.Point(216, 64)
        Me.txtSN.MaxLength = 15
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(184, 22)
        Me.txtSN.TabIndex = 1
        Me.txtSN.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(176, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "S/N:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlRelabel
        '
        Me.pnlRelabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlRelabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlRelabel.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTobeLabelPN, Me.lblTobeLabelPNDisplay, Me.txtTobeLabelIMEI, Me.lblTobeLabelIMEI, Me.txtLastDigitOfPN, Me.lblLastDigitOfPN, Me.Label1, Me.nudQty, Me.lblNextStation, Me.btnPrint, Me.txtSN, Me.Label2})
        Me.pnlRelabel.Location = New System.Drawing.Point(0, 59)
        Me.pnlRelabel.Name = "pnlRelabel"
        Me.pnlRelabel.Size = New System.Drawing.Size(880, 304)
        Me.pnlRelabel.TabIndex = 126
        '
        'lblTobeLabelPN
        '
        Me.lblTobeLabelPN.BackColor = System.Drawing.Color.White
        Me.lblTobeLabelPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTobeLabelPN.ForeColor = System.Drawing.Color.Red
        Me.lblTobeLabelPN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTobeLabelPN.Location = New System.Drawing.Point(216, 7)
        Me.lblTobeLabelPN.Name = "lblTobeLabelPN"
        Me.lblTobeLabelPN.Size = New System.Drawing.Size(184, 22)
        Me.lblTobeLabelPN.TabIndex = 144
        Me.lblTobeLabelPN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTobeLabelPN.Visible = False
        '
        'lblTobeLabelPNDisplay
        '
        Me.lblTobeLabelPNDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTobeLabelPNDisplay.ForeColor = System.Drawing.Color.Black
        Me.lblTobeLabelPNDisplay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTobeLabelPNDisplay.Location = New System.Drawing.Point(176, 10)
        Me.lblTobeLabelPNDisplay.Name = "lblTobeLabelPNDisplay"
        Me.lblTobeLabelPNDisplay.Size = New System.Drawing.Size(40, 16)
        Me.lblTobeLabelPNDisplay.TabIndex = 143
        Me.lblTobeLabelPNDisplay.Text = "P/N:"
        Me.lblTobeLabelPNDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTobeLabelPNDisplay.Visible = False
        '
        'txtTobeLabelIMEI
        '
        Me.txtTobeLabelIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTobeLabelIMEI.Location = New System.Drawing.Point(216, 36)
        Me.txtTobeLabelIMEI.MaxLength = 15
        Me.txtTobeLabelIMEI.Name = "txtTobeLabelIMEI"
        Me.txtTobeLabelIMEI.Size = New System.Drawing.Size(184, 22)
        Me.txtTobeLabelIMEI.TabIndex = 0
        Me.txtTobeLabelIMEI.Text = ""
        Me.txtTobeLabelIMEI.Visible = False
        '
        'lblTobeLabelIMEI
        '
        Me.lblTobeLabelIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTobeLabelIMEI.ForeColor = System.Drawing.Color.Black
        Me.lblTobeLabelIMEI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTobeLabelIMEI.Location = New System.Drawing.Point(176, 38)
        Me.lblTobeLabelIMEI.Name = "lblTobeLabelIMEI"
        Me.lblTobeLabelIMEI.Size = New System.Drawing.Size(40, 16)
        Me.lblTobeLabelIMEI.TabIndex = 142
        Me.lblTobeLabelIMEI.Text = "IMEI:"
        Me.lblTobeLabelIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTobeLabelIMEI.Visible = False
        '
        'txtLastDigitOfPN
        '
        Me.txtLastDigitOfPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastDigitOfPN.Location = New System.Drawing.Point(216, 128)
        Me.txtLastDigitOfPN.MaxLength = 1
        Me.txtLastDigitOfPN.Name = "txtLastDigitOfPN"
        Me.txtLastDigitOfPN.Size = New System.Drawing.Size(48, 22)
        Me.txtLastDigitOfPN.TabIndex = 3
        Me.txtLastDigitOfPN.Text = ""
        Me.txtLastDigitOfPN.Visible = False
        '
        'lblLastDigitOfPN
        '
        Me.lblLastDigitOfPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastDigitOfPN.ForeColor = System.Drawing.Color.Green
        Me.lblLastDigitOfPN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblLastDigitOfPN.Location = New System.Drawing.Point(24, 123)
        Me.lblLastDigitOfPN.Name = "lblLastDigitOfPN"
        Me.lblLastDigitOfPN.Size = New System.Drawing.Size(192, 30)
        Me.lblLastDigitOfPN.TabIndex = 140
        Me.lblLastDigitOfPN.Text = "Change Last Digit of Part Number : (Optional)"
        Me.lblLastDigitOfPN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblLastDigitOfPN.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(184, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Qty:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudQty
        '
        Me.nudQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudQty.Location = New System.Drawing.Point(216, 96)
        Me.nudQty.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQty.Name = "nudQty"
        Me.nudQty.Size = New System.Drawing.Size(48, 22)
        Me.nudQty.TabIndex = 2
        Me.nudQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblNextStation
        '
        Me.lblNextStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNextStation.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblNextStation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblNextStation.Location = New System.Drawing.Point(216, 160)
        Me.lblNextStation.Name = "lblNextStation"
        Me.lblNextStation.Size = New System.Drawing.Size(184, 32)
        Me.lblNextStation.TabIndex = 134
        Me.lblNextStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.SteelBlue
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(216, 200)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(184, 32)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "PRINT"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPartNo, Me.Label10, Me.lblIMEI, Me.Label12, Me.lblSku, Me.Label14, Me.lblModel, Me.Label16, Me.lblCustomer, Me.Label17, Me.lblRMA, Me.Button4, Me.Label19, Me.lblSymptom, Me.Label20})
        Me.Panel6.Location = New System.Drawing.Point(216, 1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(664, 57)
        Me.Panel6.TabIndex = 127
        '
        'lblPartNo
        '
        Me.lblPartNo.BackColor = System.Drawing.Color.White
        Me.lblPartNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.ForeColor = System.Drawing.Color.Black
        Me.lblPartNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPartNo.Location = New System.Drawing.Point(368, 29)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(120, 16)
        Me.lblPartNo.TabIndex = 133
        Me.lblPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(320, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 132
        Me.Label10.Text = "Part #:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIMEI
        '
        Me.lblIMEI.BackColor = System.Drawing.Color.White
        Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIMEI.ForeColor = System.Drawing.Color.Black
        Me.lblIMEI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIMEI.Location = New System.Drawing.Point(368, 3)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(120, 16)
        Me.lblIMEI.TabIndex = 131
        Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label12.Location = New System.Drawing.Point(320, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 16)
        Me.Label12.TabIndex = 130
        Me.Label12.Text = "IMEI:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSku
        '
        Me.lblSku.BackColor = System.Drawing.Color.White
        Me.lblSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSku.ForeColor = System.Drawing.Color.Black
        Me.lblSku.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSku.Location = New System.Drawing.Point(208, 29)
        Me.lblSku.Name = "lblSku"
        Me.lblSku.Size = New System.Drawing.Size(105, 16)
        Me.lblSku.TabIndex = 129
        Me.lblSku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label14.Location = New System.Drawing.Point(160, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 128
        Me.Label14.Text = "SKU:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModel
        '
        Me.lblModel.BackColor = System.Drawing.Color.White
        Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.ForeColor = System.Drawing.Color.Black
        Me.lblModel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblModel.Location = New System.Drawing.Point(208, 3)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(105, 16)
        Me.lblModel.TabIndex = 127
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label16.Location = New System.Drawing.Point(160, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 16)
        Me.Label16.TabIndex = 126
        Me.Label16.Text = "Model:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.White
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.Black
        Me.lblCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCustomer.Location = New System.Drawing.Point(66, 29)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(86, 16)
        Me.lblCustomer.TabIndex = 125
        Me.lblCustomer.Text = "ATT"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label17.Location = New System.Drawing.Point(-6, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 16)
        Me.Label17.TabIndex = 124
        Me.Label17.Text = "Customer:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRMA
        '
        Me.lblRMA.BackColor = System.Drawing.Color.White
        Me.lblRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRMA.ForeColor = System.Drawing.Color.Black
        Me.lblRMA.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRMA.Location = New System.Drawing.Point(66, 3)
        Me.lblRMA.Name = "lblRMA"
        Me.lblRMA.Size = New System.Drawing.Size(86, 16)
        Me.lblRMA.TabIndex = 123
        Me.lblRMA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(144, 245)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(200, 31)
        Me.Button4.TabIndex = 66
        Me.Button4.TabStop = False
        Me.Button4.Text = "Generate Report"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label19.Location = New System.Drawing.Point(10, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 16)
        Me.Label19.TabIndex = 122
        Me.Label19.Text = "RMA:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSymptom
        '
        Me.lblSymptom.BackColor = System.Drawing.Color.White
        Me.lblSymptom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSymptom.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSymptom.ForeColor = System.Drawing.Color.Red
        Me.lblSymptom.Location = New System.Drawing.Point(496, 13)
        Me.lblSymptom.Name = "lblSymptom"
        Me.lblSymptom.Size = New System.Drawing.Size(136, 32)
        Me.lblSymptom.TabIndex = 128
        Me.lblSymptom.UseMnemonic = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label20.Location = New System.Drawing.Point(496, -3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 16)
        Me.Label20.TabIndex = 127
        Me.Label20.Text = "Trouble Indicated :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'frmLabel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(904, 397)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel6, Me.pnlRelabel, Me.lblTitle})
        Me.Name = "frmLabel"
        Me.Text = "frmLabel"
        Me.pnlRelabel.ResumeLayout(False)
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            If Me._strScreenName.Trim.ToUpper = "MB LABEL" Then
                Me.lblTobeLabelPNDisplay.Visible = True
                Me.lblTobeLabelPN.Visible = True
                Me.lblTobeLabelIMEI.Visible = True
                Me.txtTobeLabelIMEI.Visible = True
                Me.txtTobeLabelIMEI.Focus()
            Else
                Me.txtSN.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtSN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSN.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub ClearGlobalVarAndCtrls()
        Me._iDeviceID = 0
        Me._iModelID = 0
        Me._strDeviceWrkStation = ""
        Me._booValidIMEI = False

        Me.lblRMA.Text = ""
        'Me.lblCustomer.Text = ""
        Me.lblModel.Text = ""
        Me.lblSku.Text = ""
        Me.lblIMEI.Text = ""
        Me.lblPartNo.Text = ""
        Me.lblSymptom.Text = ""
        Me.txtLastDigitOfPN.Text = ""
        Me.txtLastDigitOfPN.Visible = False
        Me.lblLastDigitOfPN.Visible = False

        Me.txtTobeLabelIMEI.Text = ""
        Me.lblTobeLabelIMEI.Text = ""
        Me.lblTobeLabelPN.Text = ""

        Me.txtSN.Text = ""
    End Sub

    '******************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Dim dtDevice As DataTable

        Try
            If e.KeyValue = 13 Then
                If Me.txtSN.Text.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Me._iDeviceID = 0

                    dtDevice = Me._objHTC.GetHTC_thtcdataInfo_InWIP(Me.txtSN.Text.Trim)
                    If dtDevice.Rows.Count > 0 Then
                        If Me._strScreenName.Trim.ToUpper = "MB LABEL" Then
                            If Me.ValidateIMEI(Me.txtTobeLabelIMEI.Text.Trim) = False Then
                                Exit Sub
                            End If
                        End If

                        Me._iDeviceID = dtDevice.Rows(0)("Device_ID")
                        Me._iModelID = dtDevice.Rows(0)("Model_ID")
                        Me.lblRMA.Text = dtDevice.Rows(0)("hd_RMA")
                        'Me.lblCustomer.Text = dtDevice.Rows(0)("hd_Station")
                        Me.lblModel.Text = dtDevice.Rows(0)("Model_Desc")
                        Me.lblSku.Text = dtDevice.Rows(0)("Sku_Number")
                        'Me.lblSN.Text = dtDevice.Rows(0)("hd_SN")
                        Me.lblIMEI.Text = dtDevice.Rows(0)("Label_IMEI")
                        Me.lblPartNo.Text = dtDevice.Rows(0)("hd_PartNo")
                        Me.lblSymptom.Text = dtDevice.Rows(0)("hd_Symptom")
                        Me._strDeviceWrkStation = dtDevice.Rows(0)("hd_Station")
                        'Me.lblNewIMEI.Text = Me._objHTC.GetNewIMEI(Me._iDeviceID)
                        Me.lblNextStation.Text = "Device Workstation: " & dtDevice.Rows(0)("hd_Station")

                        If Me._strScreenName.Trim.ToUpper = "RELABEL" And Me._iModelID = 1120 Or Me._iModelID = 1123 Then
                            Me.lblLastDigitOfPN.Visible = True
                            Me.txtLastDigitOfPN.Visible = True
                        Else
                            Me.lblTobeLabelPN.Text = Me.lblPartNo.Text
                        End If

                    Else
                        MessageBox.Show("S/N either does not exist, belongs to a different customer or already been ship.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dtDevice)
        End Try
    End Sub

    '******************************************************************
    Private Function ValidateIMEI(ByVal strIMEI As String) As Boolean
        Dim booReturnVal As Boolean = False
        Dim i As Integer = 0
        Dim dtIMEI As DataTable

        Try
            If strIMEI.Trim.Length <> 15 Then
                MessageBox.Show("IMEI must be 15 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                For i = 1 To strIMEI.Trim.Length
                    If Char.IsDigit(Mid(strIMEI, i)) = False Then
                        MessageBox.Show("IMEI must be 15 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ValidateIMEI = False 'set return val equal to false
                        Exit Function
                    End If
                Next i

                'Check if IMEI exist in system and never use
                dtIMEI = Me._objHTC.GetMainBoardIMEI(Me.txtTobeLabelIMEI.Text.Trim.ToUpper)
                If dtIMEI.Rows.Count = 0 Then
                    MessageBox.Show("IMEI is not listed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'ElseIf Not IsDBNull(dtIMEI.Rows(0)("ConsumeDevice_ID")) Then
                    '    MessageBox.Show("IMEI was used by another unit (" & dtIMEI.Rows(0)("ConsumeDevice_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtIMEI.Rows(0)("DOA") = 1 Then
                    MessageBox.Show("This IMEI belongs to an effective board.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    booReturnVal = True
                End If
            End If

            Return booReturnVal
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dtIMEI)
        End Try
    End Function

    '******************************************************************
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strNextWrkStation As String = ""
        Dim i As Integer = 0
        Dim iQty As Integer = 1
        Dim strPartNumber As String = ""
        Dim strIMEI As String = ""

        Try
            If Me._iDeviceID = 0 Or Me.txtSN.Text.Trim.Length = 0 Then
                MessageBox.Show("Device ID can not identify please scan IMEI number again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                'If Me._strScreenName.Trim.ToUpper <> Me._strDeviceWrkStation.Trim.ToString Then
                '    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, Me._iModelID, Me._objHTC.HTC_CUSTOMER_ID)
                '    If strNextWrkStation.Trim.Length = 0 Then
                '        MessageBox.Show("Can not find the next workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Exit Sub
                '    End If

                '    i = Me._objHTC.PushUnitToNextWorkingStation(Me._iDeviceID, strNextWrkStation)
                '    If i = 0 Then
                '        MessageBox.Show("System failed to push the device to " & strNextWrkStation & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Exit Sub
                '    End If
                'ElseIf Me.txtIMEI.Text.Trim <> Me.lblNewIMEI.Text.Trim Then
                '    i = Me._objHTC.ChangeSN(Me._iDeviceID, Me.lblNewIMEI.Text.Trim.ToUpper)
                '    If i = 0 Then
                '        MessageBox.Show("System failed to change IMEI number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Exit Sub
                '    End If
                'End If

                'Me._objHTC.ReprintIMEILabel(Me._iDeviceID, Me.lblNewIMEI.Text.Trim.ToUpper)
                'Me.lblNextStation.Text = "Device has moved to " & strNextWrkStation.ToUpper

                strPartNumber = Me.lblPartNo.Text.Trim.ToUpper

                If Me._strScreenName.Trim.ToUpper = "RELABEL" Then
                    strIMEI = Me.lblIMEI.Text.Trim
                Else
                    strIMEI = Me.txtTobeLabelIMEI.Text
                End If

                If Me.txtLastDigitOfPN.Text.Trim.Length > 0 Then
                    If Me.txtLastDigitOfPN.Text.Trim.EndsWith("0") = False And Me.txtLastDigitOfPN.Text.Trim.EndsWith("1") = False Then
                        MessageBox.Show("Invalid ending digit of part number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    strPartNumber = Mid(strPartNumber, 1, strPartNumber.Length - 1) & Me.txtLastDigitOfPN.Text.Trim
                    If Me.lblPartNo.Text.Trim.ToUpper <> strPartNumber Then
                        i = Me._objHTC.ChangeLastCharOfPartNumber(Me._strScreenName.ToUpper, Me._iDeviceID, ApplicationUser.IDuser, ApplicationUser.User, strPartNumber, Me.lblPartNo.Text.Trim.ToUpper)
                        If i = 0 Then
                            MessageBox.Show("System failed to change last digit of part number. Try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    End If
                End If

                Me.Enabled = False
                iQty = Me.nudQty.Value
                Me._objHTC.PrintIMEILabel(strPartNumber, strIMEI, Me.txtSN.Text.Trim.ToUpper, iQty)
                Me.ClearGlobalVarAndCtrls()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnPrint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            If Me._strScreenName = "RELABEL" Then Me.txtSN.Focus() Else Me.txtTobeLabelIMEI.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub txtLastDigitOfPN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastDigitOfPN.KeyPress
        Try
            If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtLastDigitOfPN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtTobeLabelIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTobeLabelIMEI.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Me.txtTobeLabelIMEI.Text.Trim.Length = 0 Then Exit Sub
                If Me.ValidateIMEI(Me.txtTobeLabelIMEI.Text.Trim) = False Then
                    Me.txtTobeLabelIMEI.SelectAll()
                Else
                    Me.txtSN.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtTobeLabelIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************

End Class
