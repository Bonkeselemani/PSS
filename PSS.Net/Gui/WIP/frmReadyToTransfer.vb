Public Class frmReadyToTransfer
    Inherits System.Windows.Forms.Form

    Private objMisc As PSS.Data.Buisness.Misc
    Private objdtSource As PSS.Data.Production.Joins
    'Add by lan 11/27/2006 transfer wip
    Private objCSBER As PSS.Data.Buisness.CellStarBER
    Private dtWipTransfESNs As DataTable

    Private Shared ctl As Control
    Private Shared HighLightColor As Color = Color.Yellow
    Private Shared WindowColor As Color = Color.White
    Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
    Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMisc = New PSS.Data.Buisness.Misc()
        objdtSource = New PSS.Data.Production.Joins()
        objCSBER = New PSS.Data.Buisness.CellStarBER()

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPalletName As System.Windows.Forms.Label
    'Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblScannedQty As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblCustomer1 As System.Windows.Forms.Label
    Friend WithEvents lblModel1 As System.Windows.Forms.Label
    Friend WithEvents lblNoPartAvailabel As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblDevAvailable As System.Windows.Forms.Label
    Friend WithEvents lblDevWP As System.Windows.Forms.Label
    Friend WithEvents txtTotalPartsAv As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents CheckWP As System.Windows.Forms.CheckBox
    Friend WithEvents CheckReleaseWP As System.Windows.Forms.CheckBox
    Friend WithEvents PanelTotalPartsAva As System.Windows.Forms.Panel
    Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PanelDev As System.Windows.Forms.Panel
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdClearOne As System.Windows.Forms.Button
    Friend WithEvents txtESN As System.Windows.Forms.TextBox
    Friend WithEvents lstESNs As System.Windows.Forms.ListBox
    Friend WithEvents cmdTransDev As System.Windows.Forms.Button
    Friend WithEvents cboSubcontractor As PSS.Gui.Controls.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPalletName = New System.Windows.Forms.Label()
        Me.PanelDev = New System.Windows.Forms.Panel()
        Me.cmdClearAll = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdClearOne = New System.Windows.Forms.Button()
        Me.lstESNs = New System.Windows.Forms.ListBox()
        Me.cmdTransDev = New System.Windows.Forms.Button()
        Me.txtESN = New System.Windows.Forms.TextBox()
        Me.lblScannedQty = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSubcontractor = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckReleaseWP = New System.Windows.Forms.CheckBox()
        Me.CheckWP = New System.Windows.Forms.CheckBox()
        Me.PanelTotalPartsAva = New System.Windows.Forms.Panel()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.lblNoPartAvailabel = New System.Windows.Forms.Label()
        Me.txtTotalPartsAv = New System.Windows.Forms.TextBox()
        Me.lblCustomer1 = New System.Windows.Forms.Label()
        Me.lblDevAvailable = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblDevWP = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblModel1 = New System.Windows.Forms.Label()
        Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
        Me.cboModel = New PSS.Gui.Controls.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PanelDev.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PanelTotalPartsAva.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(395, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(334, 39)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "TRANSFER WIP "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Box IMEI:"
        '
        'lblPalletName
        '
        Me.lblPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalletName.ForeColor = System.Drawing.Color.Red
        Me.lblPalletName.Location = New System.Drawing.Point(8, 8)
        Me.lblPalletName.Name = "lblPalletName"
        Me.lblPalletName.Size = New System.Drawing.Size(232, 32)
        Me.lblPalletName.TabIndex = 0
        '
        'PanelDev
        '
        Me.PanelDev.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelDev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelDev.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClearAll, Me.Label6, Me.cmdClearOne, Me.lstESNs, Me.cmdTransDev, Me.txtESN, Me.lblScannedQty})
        Me.PanelDev.Location = New System.Drawing.Point(395, 82)
        Me.PanelDev.Name = "PanelDev"
        Me.PanelDev.Size = New System.Drawing.Size(334, 292)
        Me.PanelDev.TabIndex = 3
        Me.PanelDev.Visible = False
        '
        'cmdClearAll
        '
        Me.cmdClearAll.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearAll.ForeColor = System.Drawing.Color.White
        Me.cmdClearAll.Location = New System.Drawing.Point(236, 136)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(76, 40)
        Me.cmdClearAll.TabIndex = 4
        Me.cmdClearAll.Text = "Clear all ESNs"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "ESN:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdClearOne
        '
        Me.cmdClearOne.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdClearOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClearOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearOne.ForeColor = System.Drawing.Color.White
        Me.cmdClearOne.Location = New System.Drawing.Point(236, 88)
        Me.cmdClearOne.Name = "cmdClearOne"
        Me.cmdClearOne.Size = New System.Drawing.Size(76, 40)
        Me.cmdClearOne.TabIndex = 3
        Me.cmdClearOne.Text = "Clear one ESN"
        '
        'lstESNs
        '
        Me.lstESNs.Location = New System.Drawing.Point(44, 32)
        Me.lstESNs.Name = "lstESNs"
        Me.lstESNs.Size = New System.Drawing.Size(174, 199)
        Me.lstESNs.TabIndex = 2
        '
        'cmdTransDev
        '
        Me.cmdTransDev.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdTransDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTransDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTransDev.ForeColor = System.Drawing.Color.White
        Me.cmdTransDev.Location = New System.Drawing.Point(47, 241)
        Me.cmdTransDev.Name = "cmdTransDev"
        Me.cmdTransDev.Size = New System.Drawing.Size(168, 40)
        Me.cmdTransDev.TabIndex = 5
        Me.cmdTransDev.Text = "TRANSFER DEVICES TO SUBCONTRACTOR"
        '
        'txtESN
        '
        Me.txtESN.Location = New System.Drawing.Point(44, 8)
        Me.txtESN.Name = "txtESN"
        Me.txtESN.Size = New System.Drawing.Size(174, 20)
        Me.txtESN.TabIndex = 1
        Me.txtESN.Text = ""
        '
        'lblScannedQty
        '
        Me.lblScannedQty.BackColor = System.Drawing.Color.Black
        Me.lblScannedQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScannedQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScannedQty.ForeColor = System.Drawing.Color.Lime
        Me.lblScannedQty.Location = New System.Drawing.Point(244, 8)
        Me.lblScannedQty.Name = "lblScannedQty"
        Me.lblScannedQty.Size = New System.Drawing.Size(64, 40)
        Me.lblScannedQty.TabIndex = 20
        Me.lblScannedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Subcontractor :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSubcontractor
        '
        Me.cboSubcontractor.AutoComplete = True
        Me.cboSubcontractor.BackColor = System.Drawing.SystemColors.Window
        Me.cboSubcontractor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboSubcontractor.ForeColor = System.Drawing.Color.Black
        Me.cboSubcontractor.Location = New System.Drawing.Point(112, 6)
        Me.cboSubcontractor.Name = "cboSubcontractor"
        Me.cboSubcontractor.Size = New System.Drawing.Size(174, 21)
        Me.cboSubcontractor.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(56, 272)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 32)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "This screen puts the devices on hold that are not ready to be transferred to prod" & _
        "uction lines. This is for Triage group only."
        Me.Label3.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel3, Me.PanelTotalPartsAva, Me.lblCustomer1, Me.lblDevAvailable, Me.Label18, Me.lblDevWP, Me.Label14, Me.lblModel1, Me.cboCustomer, Me.cboModel})
        Me.Panel1.Location = New System.Drawing.Point(2, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 214)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckReleaseWP, Me.CheckWP})
        Me.Panel3.Location = New System.Drawing.Point(9, 119)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(367, 30)
        Me.Panel3.TabIndex = 21
        '
        'CheckReleaseWP
        '
        Me.CheckReleaseWP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckReleaseWP.ForeColor = System.Drawing.Color.White
        Me.CheckReleaseWP.Location = New System.Drawing.Point(168, 4)
        Me.CheckReleaseWP.Name = "CheckReleaseWP"
        Me.CheckReleaseWP.Size = New System.Drawing.Size(152, 16)
        Me.CheckReleaseWP.TabIndex = 4
        Me.CheckReleaseWP.Text = "Release all WP Devices"
        '
        'CheckWP
        '
        Me.CheckWP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckWP.ForeColor = System.Drawing.Color.White
        Me.CheckWP.Location = New System.Drawing.Point(13, 5)
        Me.CheckWP.Name = "CheckWP"
        Me.CheckWP.Size = New System.Drawing.Size(139, 16)
        Me.CheckWP.TabIndex = 3
        Me.CheckWP.Text = "Put all Devices on WP"
        '
        'PanelTotalPartsAva
        '
        Me.PanelTotalPartsAva.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelTotalPartsAva.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTotalPartsAva.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUpdate, Me.lblNoPartAvailabel, Me.txtTotalPartsAv})
        Me.PanelTotalPartsAva.ForeColor = System.Drawing.Color.Black
        Me.PanelTotalPartsAva.Location = New System.Drawing.Point(9, 159)
        Me.PanelTotalPartsAva.Name = "PanelTotalPartsAva"
        Me.PanelTotalPartsAva.Size = New System.Drawing.Size(367, 40)
        Me.PanelTotalPartsAva.TabIndex = 22
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.Color.Black
        Me.cmdUpdate.Location = New System.Drawing.Point(296, 5)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(56, 24)
        Me.cmdUpdate.TabIndex = 6
        Me.cmdUpdate.Text = "Update "
        Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNoPartAvailabel
        '
        Me.lblNoPartAvailabel.BackColor = System.Drawing.Color.Transparent
        Me.lblNoPartAvailabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoPartAvailabel.ForeColor = System.Drawing.Color.White
        Me.lblNoPartAvailabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblNoPartAvailabel.Location = New System.Drawing.Point(0, 2)
        Me.lblNoPartAvailabel.Name = "lblNoPartAvailabel"
        Me.lblNoPartAvailabel.Size = New System.Drawing.Size(120, 29)
        Me.lblNoPartAvailabel.TabIndex = 15
        Me.lblNoPartAvailabel.Text = "Total parts available for this model :"
        Me.lblNoPartAvailabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalPartsAv
        '
        Me.txtTotalPartsAv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTotalPartsAv.Location = New System.Drawing.Point(128, 8)
        Me.txtTotalPartsAv.Name = "txtTotalPartsAv"
        Me.txtTotalPartsAv.Size = New System.Drawing.Size(160, 20)
        Me.txtTotalPartsAv.TabIndex = 5
        Me.txtTotalPartsAv.Text = ""
        '
        'lblCustomer1
        '
        Me.lblCustomer1.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer1.ForeColor = System.Drawing.Color.Black
        Me.lblCustomer1.Location = New System.Drawing.Point(65, 10)
        Me.lblCustomer1.Name = "lblCustomer1"
        Me.lblCustomer1.Size = New System.Drawing.Size(112, 16)
        Me.lblCustomer1.TabIndex = 13
        Me.lblCustomer1.Text = "Customer : "
        Me.lblCustomer1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDevAvailable
        '
        Me.lblDevAvailable.BackColor = System.Drawing.Color.Transparent
        Me.lblDevAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDevAvailable.ForeColor = System.Drawing.Color.Black
        Me.lblDevAvailable.Location = New System.Drawing.Point(193, 91)
        Me.lblDevAvailable.Name = "lblDevAvailable"
        Me.lblDevAvailable.Size = New System.Drawing.Size(152, 16)
        Me.lblDevAvailable.TabIndex = 96
        Me.lblDevAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(24, 67)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(160, 16)
        Me.Label18.TabIndex = 97
        Me.Label18.Text = "Device(s) waiting for parts :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDevWP
        '
        Me.lblDevWP.BackColor = System.Drawing.Color.Transparent
        Me.lblDevWP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDevWP.ForeColor = System.Drawing.Color.Black
        Me.lblDevWP.Location = New System.Drawing.Point(193, 67)
        Me.lblDevWP.Name = "lblDevWP"
        Me.lblDevWP.Size = New System.Drawing.Size(152, 16)
        Me.lblDevWP.TabIndex = 98
        Me.lblDevWP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(8, 91)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(176, 16)
        Me.Label14.TabIndex = 95
        Me.Label14.Text = "Device(s) not waiting for parts :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModel1
        '
        Me.lblModel1.BackColor = System.Drawing.Color.Transparent
        Me.lblModel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel1.ForeColor = System.Drawing.Color.Black
        Me.lblModel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblModel1.Location = New System.Drawing.Point(65, 39)
        Me.lblModel1.Name = "lblModel1"
        Me.lblModel1.Size = New System.Drawing.Size(112, 16)
        Me.lblModel1.TabIndex = 11
        Me.lblModel1.Text = "Model : "
        Me.lblModel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCustomer
        '
        Me.cboCustomer.AutoComplete = True
        Me.cboCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cboCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCustomer.ForeColor = System.Drawing.Color.Black
        Me.cboCustomer.Location = New System.Drawing.Point(185, 8)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(160, 21)
        Me.cboCustomer.TabIndex = 1
        '
        'cboModel
        '
        Me.cboModel.AutoComplete = True
        Me.cboModel.BackColor = System.Drawing.SystemColors.Window
        Me.cboModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboModel.ForeColor = System.Drawing.Color.Black
        Me.cboModel.Location = New System.Drawing.Point(185, 36)
        Me.cboModel.Name = "cboModel"
        Me.cboModel.Size = New System.Drawing.Size(160, 21)
        Me.cboModel.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(2, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(390, 39)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "WAITING FOR PARTS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSubcontractor, Me.Label5})
        Me.Panel4.Location = New System.Drawing.Point(395, 42)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(334, 38)
        Me.Panel4.TabIndex = 2
        '
        'frmReadyToTransfer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 752)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Panel1, Me.PanelDev, Me.Label1, Me.Label3, Me.Panel4})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "frmReadyToTransfer"
        Me.Text = "Put Devices on Waiting Parts"
        Me.PanelDev.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.PanelTotalPartsAva.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*********************************** lan ***********************************
    Protected Overrides Sub Finalize()
        objMisc = Nothing
        objdtSource = Nothing
        objCSBER = Nothing
        MyBase.Finalize()
    End Sub
    '*********************************** LAN *******************************
    Private Shared Sub SetHandler(ByVal ctl As Control)
        AddHandler ctl.Enter, EnterHandler
        AddHandler ctl.Leave, LeaveHandler
        AddHandler ctl.Click, EnterHandler
    End Sub
    '******************************************************************************
    Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, HighLightColor)
    End Sub
    '******************************************************************************
    Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, WindowColor)
    End Sub
    '******************************************************************************
    Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
        Dim Type As String = sender.GetType.Name.ToString

        Select Case Type
            Case "ComboBox"
                CType(sender, ComboBox).BackColor = color
            Case "TextBox"
                CType(sender, TextBox).BackColor = color
                'Case "ListBox"
                '    CType(sender, ComboBox).BackColor = color
                'Case "Button"
                '    CType(sender, Button).BackColor = color
            Case Else
                'no other types should be hightlighted.

        End Select
    End Sub
    '*********************************** lan ***********************************
    Private Sub frmReadyToTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Handlers to highlight in custom colors

        '&&&&&&&&&&&&&&& 11/09/2006
        SetHandler(Me.cboCustomer)
        SetHandler(Me.cboModel)
        SetHandler(Me.txtTotalPartsAv)
        PopulateCustomers()
        PopulateModels()
        Me.cboModel.Focus()
        '&&&&&&&&&&&&&&& 11/20/2006 transfer wipowner to subcontractor
        SetHandler(Me.cboSubcontractor)
        SetHandler(Me.txtESN)
        PopulateSubcontractors()

    End Sub

    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    '11/09/2006 PUT ALL DEVICES BELONG TO SELECTED MODEL ON WAITING PARTS 
    '*************************************************************
    'lan add
    Private Sub PopulateCustomers()
        Dim strSQL As String
        Dim dt1 As DataTable

        Try
            strSQL = "SELECT Cust_ID, Cust_Name1 FROM tcustomer WHERE Cust_id  IN (2019,2219,2113)ORDER BY cust_name1;"
            dt1 = objdtSource.OrderEntrySelect(strSQL)

            Me.cboCustomer.DataSource = dt1.DefaultView
            Me.cboCustomer.DisplayMember = dt1.Columns("Cust_Name1").ToString
            Me.cboCustomer.ValueMember = dt1.Columns("Cust_ID").ToString

            Me.cboCustomer.SelectedValue = 2113
        Catch ex As Exception
            MessageBox.Show("PopulateCustomers(): " & ex.ToString, "Populate Customers", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub
    '*************************************************************
    Private Sub PopulateModels()
        Dim strSQL As String
        Dim dt1 As DataTable

        Try
            strSQL = "SELECT * FROM tmodel WHERE Prod_ID in (2) ORDER BY Model_Desc"
            dt1 = objdtSource.OrderEntrySelect(strSQL)
            dt1.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
            cboModel.DataSource = dt1.DefaultView
            cboModel.DisplayMember = dt1.Columns("Model_Desc").ToString
            cboModel.ValueMember = dt1.Columns("Model_ID").ToString
            Me.cboModel.SelectedValue = 0

        Catch ex As Exception
            MessageBox.Show("PopulateModels(): " & ex.ToString, "Populate Customers", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub
    '*************************************************************
    Private Sub cboModel_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModel.SelectionChangeCommitted
        Dim dtDevicesInf As DataTable

        Try
            If Me.cboModel.SelectedValue > 0 Then
                ''If Me.cboCustomer.SelectedValue <> 2113 Then
                ''    MessageBox.Show("This screen was desingned for Brightpoint customer only. Contact IT if you need to implement this screen with a different customer.", "Define customer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ''    Me.cboCustomer.SelectedValue = 2113
                ''    Me.cboModel.Focus()
                ''    Exit Sub
                ''End If

                '******************************************************
                'get all devices belong to selected customer and model
                dtDevicesInf = GetDevInf()
                '******************************************************
                'display total devices are waiting for parts and not waiting for parts
                Me.lblDevAvailable.Text = GetDevWipCnt(dtDevicesInf, 1)  '1:Available
                Me.lblDevWP.Text = GetDevWipCnt(dtDevicesInf, 2)         '2:Waiting for Parts
                '******************************************************
            End If
        Catch ex As Exception
            MessageBox.Show("cboModel_SelectionChangeCommitted: " & ex.ToString, "Populate Customers", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dtDevicesInf) Then
                dtDevicesInf.Dispose()
                dtDevicesInf = Nothing
            End If
        End Try
    End Sub
    '*************************************************************
    Private Function GetDevInf(Optional ByVal strOrder As String = "desc") As DataTable
        Dim strSQL As String
        Dim dt1 As DataTable

        Try
            strSQL = "select tdevice.Device_ID, tdevice.Device_SN, tdevice.Device_DateRec,  tdevice.Device_DateShip, tcellopt.Cellopt_WIPOwner " & Environment.NewLine
            strSQL &= "from tdevice " & Environment.NewLine
            strSQL &= "inner join tlocation on tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
            strSQL &= "inner join tcellopt on tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
            strSQL &= "where tdevice.model_id = " & Me.cboModel.SelectedValue & " and " & Environment.NewLine
            strSQL &= "tlocation.cust_id = " & Me.cboCustomer.SelectedValue & " And " & Environment.NewLine
            strSQL &= "(device_DateShip is null) " & Environment.NewLine
            strSQL &= "order by tdevice.device_DateRec " & strOrder & ";"
            dt1 = objdtSource.OrderEntrySelect(strSQL)
            Return dt1
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Function
    '*************************************************************
    Private Function GetDevWipCnt(ByVal dtDevicesInf As DataTable, _
                                    ByVal iWipStatus As Integer) As Integer
        Dim iCnt As Integer = 0
        Dim R1 As DataRow

        Try
            For Each R1 In dtDevicesInf.Rows
                If iWipStatus = 1 Then          '1:Available
                    If R1("Cellopt_WIPOwner") = 2 Or R1("Cellopt_WIPOwner") = 3 Or R1("Cellopt_WIPOwner") = 5 Or R1("Cellopt_WIPOwner") = 11 Then
                        If objMisc.DevNoTechAssign(R1("Device_id")) Then
                            iCnt += 1
                        End If
                    End If
                ElseIf iWipStatus = 2 Then      '2:Waiting for Parts
                    If R1("Cellopt_WIPOwner") = 13 Then
                        iCnt += 1
                    End If
                End If
            Next R1

            Return iCnt
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Device Wip Count", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Function
    '*************************************************************
    Private Sub txtTotalPartsAv_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalPartsAv.KeyUp
        If e.KeyValue = 13 Then
            If ValidateInput() = False Then
                'Me.txtTotalPartsAv.Focus()
                Exit Sub
            End If
            ProcessDev()
            Me.txtTotalPartsAv.Focus()
        End If
    End Sub
    '*************************************************************
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If ValidateInput() = False Then
            'Me.txtTotalPartsAv.Focus()
            Exit Sub
        End If
        ProcessDev()
        Me.txtTotalPartsAv.Focus()
    End Sub
    '*************************************************************
    Private Function ValidateInput() As Boolean
        'validate input
        ''If Me.cboCustomer.SelectedValue <> 2113 Then
        ''    MessageBox.Show("This screen was desingned for Brightpoint customer only. Contact IT if you need to implement this screen with a different customer.", "Define customer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        ''    Me.cboCustomer.SelectedValue = 2113
        ''    Me.cboModel.Focus()
        ''    Return False
        ''End If
        If Me.cboModel.SelectedValue = 0 Then
            MessageBox.Show("Please select model.", "Define model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.cboModel.Focus()
            Return False
        End If
        If Me.CheckReleaseWP.Checked = False And Me.CheckWP.Checked = False Then
            If (Me.txtTotalPartsAv.Text) = "" Or IsNumeric(Trim(Me.txtTotalPartsAv.Text)) = False Or CInt(Me.txtTotalPartsAv.Text) = 0 Then
                MessageBox.Show("Please enter total parts available for " & Me.cboModel.SelectedText & " model.", "Define model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtTotalPartsAv.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    '*************************************************************
    Private Sub ProcessDev()
        Dim iTotalPartsAv As Integer = 0
        Dim R1 As DataRow
        Dim iResult As Integer = 0
        Dim strDate As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim strSql As String = ""
        Dim dtDevicesInf As DataTable

        Try
            '****************************************************************
            If Me.CheckReleaseWP.Checked = True Then
                '*****************************************************
                'get all devices belong to selected customer and model
                dtDevicesInf = GetDevInf()
                '*****************************************************
                For Each R1 In dtDevicesInf.Rows
                  If R1("Cellopt_WIPOwner") = 13 Then
                        iResult = objMisc.UpdtWipOwner(R1("Device_id"), )
                    End If
                Next R1
            ElseIf Me.CheckWP.Checked = True Then
                '*****************************************************
                'get all devices belong to selected customer and model
                dtDevicesInf = GetDevInf()
                '*****************************************************
                For Each R1 In dtDevicesInf.Rows
                    If R1("Cellopt_WIPOwner") = 13 Or R1("Cellopt_WIPOwner") = 15 Then
                        ''
                    Else
                        If objMisc.DevNoTechAssign(R1("Device_id")) Then
                            iResult = objMisc.UpdtWipOwner(R1("Device_id"), 13)
                        End If
                    End If
                    'If R1("Cellopt_WIPOwner") <> 13 Or R1("Cellopt_WIPOwner") <> 15 Then
                    '    If objMisc.DevNoTechAssign(R1("Device_id")) Then
                    '        iResult = objMisc.UpdtWipOwner(R1("Device_id"), 13)
                    '    End If
                    'End If
                Next R1
            Else
                '*****************************************************
                'get all devices belong to selected customer and model
                dtDevicesInf = GetDevInf("asc")
                '*****************************************************
                iTotalPartsAv = CInt(Trim(Me.txtTotalPartsAv.Text))
                Dim icount As Integer = 0
                For Each R1 In dtDevicesInf.Rows
                   If R1("Cellopt_WIPOwner") = 13 Then
                        iResult = objMisc.UpdtWipOwner(R1("Device_id"), )
                        icount += 1
                    End If

                    '********************************
                    'hold up to available parts
                    If icount = iTotalPartsAv Then
                        Exit For
                    End If
                    '********************************
                Next R1
            End If
            '****************************************************************
            'get all the update devices belong to selected customer and model
            dtDevicesInf = GetDevInf()
            '******************************************************
            'display total devices are waiting for parts and not waiting for parts
            Me.lblDevAvailable.Text = GetDevWipCnt(dtDevicesInf, 1)  '1:Available
            Me.lblDevWP.Text = GetDevWipCnt(dtDevicesInf, 2)         '2:Waiting for Parts
            '******************************************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Update devices status", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dtDevicesInf) Then
                dtDevicesInf.Dispose()
                dtDevicesInf = Nothing
            End If
            If Me.CheckReleaseWP.Checked = True Then
                Me.CheckReleaseWP.Checked = False
            End If
            If Me.CheckWP.Checked = True Then
                Me.CheckWP.Checked = False
            End If
            Me.txtTotalPartsAv.Text = ""
        End Try
    End Sub
    '*************************************************************
    Private Sub CheckWP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckWP.CheckedChanged
        If Me.CheckWP.Checked = True Then
            If ValidateInput() = False Then
                Me.CheckWP.Checked = False
                Exit Sub
            End If
            If MessageBox.Show("Are you sure you want to put all devices of this model (" & Me.cboModel.Text & ") on waiting part?", "Set Device on WP", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                ProcessDev()
            End If
            Me.CheckWP.Checked = False
        End If
    End Sub
    '*************************************************************
    Private Sub CheckReleaseWP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckReleaseWP.CheckedChanged
        If Me.CheckReleaseWP.Checked = True Then
            If ValidateInput() = False Then
                Me.CheckReleaseWP.Checked = False
                Exit Sub
            End If
            If MessageBox.Show("Are you sure you want to release all waiting part devices for this model (" & Me.cboModel.Text & ")?", "Release WP", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                ProcessDev()
            End If
            Me.CheckReleaseWP.Checked = False
        End If
    End Sub
    '*************************************************************
    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    '11/29/2006 TRANSFER DEVICES TO SUBCONTRACTOR
    '*************************************************************
    Private Sub PopulateSubcontractors()
        Dim strSQL As String
        Dim dt1 As DataTable

        Try
            strSQL = "select * from tsubcontractor where Prod_ID = 2 order by SC_Desc;"
            dt1 = objdtSource.OrderEntrySelect(strSQL)

            dt1.LoadDataRow(New Object() {"0", "-- select --"}, False)
            Me.cboSubcontractor.DataSource = dt1.DefaultView
            Me.cboSubcontractor.DisplayMember = dt1.Columns("SC_Desc").ToString
            Me.cboSubcontractor.ValueMember = dt1.Columns("SC_ID").ToString

            Me.cboSubcontractor.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show("PopulateSubcontractors(): " & ex.ToString, "Populate Subcontractor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub RefreshListBox()
        Dim R1 As DataRow

        Try
            If Not IsNothing(Me.dtWipTransfESNs) And Me.dtWipTransfESNs.Rows.Count > 0 Then
                Me.lstESNs.Items.Clear()

                For Each R1 In dtWipTransfESNs.Rows
                    Me.lstESNs.Items.Add(Trim(R1("device_sn")))
                Next R1
                Me.lstESNs.Refresh()
                Me.lblScannedQty.Text = Me.lstESNs.Items.Count
            Else
                Me.lstESNs.Items.Clear()
                Me.lstESNs.Refresh()
                Me.lblScannedQty.Text = ""
            End If
        Catch ex As Exception
            Throw New Exception(ex.ToString)
        Finally
            R1 = Nothing
        End Try
    End Sub

    Private Sub cboSubcontractor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubcontractor.SelectionChangeCommitted
        If Me.cboSubcontractor.SelectedValue > 0 Then
            Me.PanelDev.Visible = True
            Me.txtESN.Focus()
        Else
            Me.PanelDev.Visible = False
        End If
    End Sub


    Private Sub cmdClearOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearOne.Click
        Dim i = 0
        Dim strESN As String = ""
        Dim R1 As DataRow

        If Me.lstESNs.Items.Count > 0 Then
            strESN = Trim(InputBox("Scan device ESN:"))
            If strESN = "" Then
                Me.txtESN.Focus()
                Exit Sub
            End If

            Try
                For Each R1 In Me.dtWipTransfESNs.Rows
                    If R1("device_sn") = strESN Then
                        R1.Delete()
                        Me.dtWipTransfESNs.AcceptChanges()
                        RefreshListBox()
                        Exit For
                    End If
                Next R1

                If Me.dtWipTransfESNs.Rows.Count = 0 Then
                    Me.dtWipTransfESNs = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show("cmdClearOne_Click::" & ex.ToString, "Clear one ESN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
            End Try
        End If
        Me.txtESN.Focus()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        If Not IsNothing(Me.dtWipTransfESNs) Then
            Try
                Me.dtWipTransfESNs = Nothing
                Me.lstESNs.Items.Clear()
                Me.lstESNs.Refresh()
                Me.lblScannedQty.Text = ""
            Catch ex As Exception
                MessageBox.Show("cmdClearOne_Click::" & ex.ToString, "Clear one ESN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End If
        Me.txtESN.Focus()
    End Sub


    Private Sub txtESN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtESN.KeyUp

        If e.KeyValue = 13 Then
            If Me.cboSubcontractor.SelectedValue = 0 Then
                MessageBox.Show("Please select New Owner.", "Scan device ESN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Trim(Me.txtESN.Text) = "" Then
                MessageBox.Show("Please scan in the 'Device's ESN'.", "Scan Box IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                ProcessESN()
            End If
        End If
    End Sub

    Private Sub ProcessESN()
        Dim dt As DataTable
        Dim R1 As DataRow

        Try
            '************************************************
            'Check for duplicate in listbox
            If Not IsNothing(Me.dtWipTransfESNs) Then
                If CheckDupl() Then
                    MessageBox.Show("Device already scanned.", "Scan Device", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            '************************************************
            'Check device already receive and is not a WD device 
            '  and was not shipped
            dt = Me.objCSBER.CheckDeviceNotWP(Trim(Me.txtESN.Text))

            If dt.Rows.Count = 0 Then
                Throw New Exception("No devices found for the criterion.")
            ElseIf dt.Rows.Count > 1 Then
                Throw New Exception("Device exist twice in the system.")
            End If

            '************************************************
            'Check device's wip owner: 
            Dim iCurOwner As Integer = 0
            iCurOwner = Me.objCSBER.GetDevWipOwner(dt.Rows(0)("device_id"))
            If iCurOwner = 0 Then
                Throw New Exception("Device id (" & dt.Rows(0)("device_id") & ") does not exist.")
            ElseIf iCurOwner = 15 Then
                Throw New Exception("Device belongs to outside source. Can not transfer!!")
            End If

            '************************************************
            'update global datatable:dtWipTransfESNs
            If IsNothing(dtWipTransfESNs) And Me.lstESNs.Items.Count = 0 Then
                dtWipTransfESNs = dt
            Else
                R1 = dtWipTransfESNs.NewRow
                R1("device_sn") = Trim(Me.txtESN.Text)
                R1("device_id") = dt.Rows(0)("device_id")
                dtWipTransfESNs.Rows.Add(R1)
            End If
            '************************************************
            Me.RefreshListBox()

        Catch ex As Exception
            MessageBox.Show("ProcessESN: " & ex.ToString, "Scan Device", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
            R1 = Nothing
            Me.txtESN.Text = ""
        End Try
    End Sub

    Private Function CheckDupl() As Boolean
        Dim R1 As DataRow
        Dim blnResult As Boolean = False

        Try
            For Each R1 In Me.dtWipTransfESNs.Rows
                If R1("Device_sn") = Trim(Me.txtESN.Text) Then
                    'MessageBox.Show("Device already scanned.", "Check Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    blnResult = True
                End If
            Next R1
            Return blnResult
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Check Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
        End Try
    End Function

    Private Sub cmdTransDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTransDev.Click
        Dim i As Integer = 0

        If Not IsNothing(Me.dtWipTransfESNs) Then
            Try
                'validate data
                If Me.cboSubcontractor.SelectedValue = 0 Then
                    MessageBox.Show("Please select New Owner.", "Transfer Wip", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtESN.Focus()
                    Exit Sub
                End If

                Me.cmdTransDev.Enabled = False

                'transfer scanned device(s) to subcontractor
                i = Me.objCSBER.TransWipToSubcontractor(Me.dtWipTransfESNs, Me.cboSubcontractor.SelectedValue)

                If i = 0 Then
                    MessageBox.Show("device(s) failed to update.", "Wip Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show(i & " device(s) have been sucessfully transferred.", "Wip Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show("cmdTransDev_Click::" & ex.ToString, "Transfer Wip", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.dtWipTransfESNs = Nothing
                Me.lstESNs.Items.Clear()
                Me.lstESNs.Refresh()
                Me.lblScannedQty.Text = ""
                Me.cmdTransDev.Enabled = True
            End Try
        End If
        Me.txtESN.Focus()
    End Sub
End Class
