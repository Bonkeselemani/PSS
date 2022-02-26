Imports System.IO
Imports System.Drawing.Color
Imports PSS.Core.Global
Namespace warehouse

    Public Class frmWarehouseRec
        Inherits System.Windows.Forms.Form
        Private objWarehouse As PSS.Data.Buisness.Warehouse
        'Private strDirectory As String = "R:\ATCLE\ATCLE_DataFiles\"
        'Private strGSDirectory As String = "P:\Dept\Game Stop\Data Files\"
        Private strPallett As String = ""
        Private iNoBoxForPallet As Integer = 0
        Private iWrongSKU As Integer = 0
        Private iParentGroupID As Integer = PSS.Core.Global.ApplicationUser.GroupID
        Private iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser

        '//These are used for the Check Serial Status Process
        Private ds As PSS.Data.Production.Joins
        Private dtCheck As DataTable
        Private DateCheck As String = Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Month, -6, Now))
        Private chkVerify As Integer = 0
        '//These are used for the Check Serial Status Process

        '//lan added
        Private iCust_id As Integer = 0
        Private iDev_billcode As Integer = 0
        Private iDevNoSN As Integer = 0

        '//Lan added by 12/06/2006
        Private iGS_Limit As Integer = 100
        'Private iGS_WHP_FileQty As Integer = 0
        Private iGS_ScanQty As Integer = 0
        Private strChildPalletName As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objWarehouse = New PSS.Data.Buisness.Warehouse()

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
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtBoxSN As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents txtPallet As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblFileDevNum As System.Windows.Forms.Label
        Friend WithEvents chkBoxEmpty As System.Windows.Forms.CheckBox
        Friend WithEvents lblMsg As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblRcvd As System.Windows.Forms.Label
        Friend WithEvents lblRejected As System.Windows.Forms.Label
        Friend WithEvents lblAccepted As System.Windows.Forms.Label
        Friend WithEvents cmdDone As System.Windows.Forms.Button
        Friend WithEvents chkWrongSKU As System.Windows.Forms.CheckBox
        Friend WithEvents chkBoxEmpty_Pallet As System.Windows.Forms.CheckBox
        Friend WithEvents cmdPallet As System.Windows.Forms.Button
        Friend WithEvents tdgDescrep As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmdDeleteDescrap As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cmdDeletePallet As System.Windows.Forms.Button
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents chkVerifyHistory As System.Windows.Forms.CheckBox
        Friend WithEvents chkVerifyNew As System.Windows.Forms.CheckBox
        Friend WithEvents cmdReject As System.Windows.Forms.Button
        Friend WithEvents chkMultiPhone As System.Windows.Forms.CheckBox
        Friend WithEvents cmdDeleteAccpeted As System.Windows.Forms.Button
        Friend WithEvents cmdUndo As System.Windows.Forms.Button
        Friend WithEvents cmdDeleteProdRcvdDev As System.Windows.Forms.Button
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents Button5 As System.Windows.Forms.Button
        Friend WithEvents Button6 As System.Windows.Forms.Button
        Friend WithEvents PanelOptions As System.Windows.Forms.Panel
        Friend WithEvents PanelBOX As System.Windows.Forms.Panel
        Friend WithEvents PanelDevice As System.Windows.Forms.Panel
        Friend WithEvents PanelGSOption As System.Windows.Forms.Panel
        Friend WithEvents RadioBad As System.Windows.Forms.RadioButton
        Friend WithEvents RadioGood As System.Windows.Forms.RadioButton
        Friend WithEvents RadioScrap As System.Windows.Forms.RadioButton
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents Button7 As System.Windows.Forms.Button
        Friend WithEvents Button8 As System.Windows.Forms.Button
        Friend WithEvents PanelDevNoSN As System.Windows.Forms.Panel
        Friend WithEvents CheckNoSN As System.Windows.Forms.CheckBox
        Friend WithEvents PanelATCLE As System.Windows.Forms.Panel
        Friend WithEvents PanelGS As System.Windows.Forms.Panel
        Friend WithEvents lblGSRcvd As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblGood As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents lblGSFileDevNum As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents lblGSReject As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents lblNoSN As System.Windows.Forms.Label
        Friend WithEvents cmdGetSNNotRec As System.Windows.Forms.Button
        Friend WithEvents cmdChangeSN As System.Windows.Forms.Button
        Friend WithEvents cmdReprintDesc As System.Windows.Forms.Button
        Friend WithEvents lblGSChildPallet_Name As System.Windows.Forms.Label
        Friend WithEvents cmdGetSubPallet As System.Windows.Forms.Button
        Friend WithEvents cmdChangePalletModel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWarehouseRec))
            Me.lblHeader = New System.Windows.Forms.Label()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.PanelDevNoSN = New System.Windows.Forms.Panel()
            Me.CheckNoSN = New System.Windows.Forms.CheckBox()
            Me.Button8 = New System.Windows.Forms.Button()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.Button7 = New System.Windows.Forms.Button()
            Me.chkWrongSKU = New System.Windows.Forms.CheckBox()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.PanelOptions = New System.Windows.Forms.Panel()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.chkMultiPhone = New System.Windows.Forms.CheckBox()
            Me.chkBoxEmpty = New System.Windows.Forms.CheckBox()
            Me.PanelBOX = New System.Windows.Forms.Panel()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.txtBoxSN = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PanelDevice = New System.Windows.Forms.Panel()
            Me.Button6 = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.PanelGSOption = New System.Windows.Forms.Panel()
            Me.RadioBad = New System.Windows.Forms.RadioButton()
            Me.RadioGood = New System.Windows.Forms.RadioButton()
            Me.RadioScrap = New System.Windows.Forms.RadioButton()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblGSChildPallet_Name = New System.Windows.Forms.Label()
            Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cmdPallet = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtPallet = New System.Windows.Forms.TextBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.chkBoxEmpty_Pallet = New System.Windows.Forms.CheckBox()
            Me.PanelATCLE = New System.Windows.Forms.Panel()
            Me.lblRcvd = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblRejected = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblAccepted = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblFileDevNum = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblMsg = New System.Windows.Forms.Label()
            Me.cmdDone = New System.Windows.Forms.Button()
            Me.cmdUndo = New System.Windows.Forms.Button()
            Me.tdgDescrep = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cmdDeleteDescrap = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cmdDeletePallet = New System.Windows.Forms.Button()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.chkVerifyNew = New System.Windows.Forms.CheckBox()
            Me.chkVerifyHistory = New System.Windows.Forms.CheckBox()
            Me.cmdReject = New System.Windows.Forms.Button()
            Me.cmdDeleteAccpeted = New System.Windows.Forms.Button()
            Me.cmdDeleteProdRcvdDev = New System.Windows.Forms.Button()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.PanelGS = New System.Windows.Forms.Panel()
            Me.lblGSReject = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.lblGSRcvd = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblGood = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.lblGSFileDevNum = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.lblNoSN = New System.Windows.Forms.Label()
            Me.cmdGetSNNotRec = New System.Windows.Forms.Button()
            Me.cmdChangeSN = New System.Windows.Forms.Button()
            Me.cmdReprintDesc = New System.Windows.Forms.Button()
            Me.cmdGetSubPallet = New System.Windows.Forms.Button()
            Me.cmdChangePalletModel = New System.Windows.Forms.Button()
            Me.Panel6.SuspendLayout()
            Me.PanelDevNoSN.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.PanelOptions.SuspendLayout()
            Me.PanelBOX.SuspendLayout()
            Me.PanelDevice.SuspendLayout()
            Me.PanelGSOption.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.PanelATCLE.SuspendLayout()
            CType(Me.tdgDescrep, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            Me.PanelGS.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.Black
            Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
            Me.lblHeader.Location = New System.Drawing.Point(9, 6)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(223, 104)
            Me.lblHeader.TabIndex = 57
            Me.lblHeader.Text = "ATCLE RECEIVING"
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Panel6
            '
            Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelDevNoSN, Me.Panel4, Me.Button4, Me.PanelOptions, Me.PanelBOX, Me.PanelDevice, Me.PanelGSOption})
            Me.Panel6.Location = New System.Drawing.Point(7, 177)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(536, 117)
            Me.Panel6.TabIndex = 5
            '
            'PanelDevNoSN
            '
            Me.PanelDevNoSN.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelDevNoSN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelDevNoSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckNoSN, Me.Button8})
            Me.PanelDevNoSN.Location = New System.Drawing.Point(7, 43)
            Me.PanelDevNoSN.Name = "PanelDevNoSN"
            Me.PanelDevNoSN.Size = New System.Drawing.Size(323, 32)
            Me.PanelDevNoSN.TabIndex = 103
            '
            'CheckNoSN
            '
            Me.CheckNoSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CheckNoSN.ForeColor = System.Drawing.Color.White
            Me.CheckNoSN.Location = New System.Drawing.Point(104, 2)
            Me.CheckNoSN.Name = "CheckNoSN"
            Me.CheckNoSN.Size = New System.Drawing.Size(168, 24)
            Me.CheckNoSN.TabIndex = 67
            Me.CheckNoSN.Text = "Device has no SN"
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
            'Panel4
            '
            Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button7, Me.chkWrongSKU})
            Me.Panel4.Location = New System.Drawing.Point(336, 79)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(192, 32)
            Me.Panel4.TabIndex = 102
            '
            'Button7
            '
            Me.Button7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button7.Location = New System.Drawing.Point(144, 245)
            Me.Button7.Name = "Button7"
            Me.Button7.Size = New System.Drawing.Size(200, 31)
            Me.Button7.TabIndex = 66
            Me.Button7.TabStop = False
            Me.Button7.Text = "Generate Report"
            '
            'chkWrongSKU
            '
            Me.chkWrongSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkWrongSKU.ForeColor = System.Drawing.Color.White
            Me.chkWrongSKU.Location = New System.Drawing.Point(16, 0)
            Me.chkWrongSKU.Name = "chkWrongSKU"
            Me.chkWrongSKU.TabIndex = 9
            Me.chkWrongSKU.Text = "Wrong SKU"
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
            'PanelOptions
            '
            Me.PanelOptions.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.chkMultiPhone, Me.chkBoxEmpty})
            Me.PanelOptions.Location = New System.Drawing.Point(336, 5)
            Me.PanelOptions.Name = "PanelOptions"
            Me.PanelOptions.Size = New System.Drawing.Size(192, 72)
            Me.PanelOptions.TabIndex = 99
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
            'chkMultiPhone
            '
            Me.chkMultiPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMultiPhone.ForeColor = System.Drawing.Color.White
            Me.chkMultiPhone.Location = New System.Drawing.Point(16, 35)
            Me.chkMultiPhone.Name = "chkMultiPhone"
            Me.chkMultiPhone.Size = New System.Drawing.Size(168, 24)
            Me.chkMultiPhone.TabIndex = 86
            Me.chkMultiPhone.Text = "Multiple Phones in Box"
            '
            'chkBoxEmpty
            '
            Me.chkBoxEmpty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxEmpty.ForeColor = System.Drawing.Color.White
            Me.chkBoxEmpty.Location = New System.Drawing.Point(16, 3)
            Me.chkBoxEmpty.Name = "chkBoxEmpty"
            Me.chkBoxEmpty.Size = New System.Drawing.Size(96, 24)
            Me.chkBoxEmpty.TabIndex = 8
            Me.chkBoxEmpty.Text = "Empty Box"
            '
            'PanelBOX
            '
            Me.PanelBOX.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelBOX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelBOX.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button5, Me.txtBoxSN, Me.Label1})
            Me.PanelBOX.Location = New System.Drawing.Point(7, 5)
            Me.PanelBOX.Name = "PanelBOX"
            Me.PanelBOX.Size = New System.Drawing.Size(323, 34)
            Me.PanelBOX.TabIndex = 100
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
            'txtBoxSN
            '
            Me.txtBoxSN.BackColor = System.Drawing.Color.Khaki
            Me.txtBoxSN.Location = New System.Drawing.Point(104, 4)
            Me.txtBoxSN.MaxLength = 15
            Me.txtBoxSN.Name = "txtBoxSN"
            Me.txtBoxSN.Size = New System.Drawing.Size(159, 20)
            Me.txtBoxSN.TabIndex = 6
            Me.txtBoxSN.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(0, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 16)
            Me.Label1.TabIndex = 83
            Me.Label1.Text = "Box Serial:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'PanelDevice
            '
            Me.PanelDevice.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelDevice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button6, Me.Label3, Me.txtDevSN})
            Me.PanelDevice.Location = New System.Drawing.Point(8, 79)
            Me.PanelDevice.Name = "PanelDevice"
            Me.PanelDevice.Size = New System.Drawing.Size(323, 34)
            Me.PanelDevice.TabIndex = 101
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
            Me.Label3.Location = New System.Drawing.Point(0, 7)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 85
            Me.Label3.Text = "Device Serial:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDevSN
            '
            Me.txtDevSN.BackColor = System.Drawing.Color.Khaki
            Me.txtDevSN.Location = New System.Drawing.Point(104, 4)
            Me.txtDevSN.MaxLength = 15
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(159, 20)
            Me.txtDevSN.TabIndex = 7
            Me.txtDevSN.Text = ""
            '
            'PanelGSOption
            '
            Me.PanelGSOption.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelGSOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelGSOption.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioBad, Me.RadioGood, Me.RadioScrap})
            Me.PanelGSOption.Location = New System.Drawing.Point(336, 5)
            Me.PanelGSOption.Name = "PanelGSOption"
            Me.PanelGSOption.Size = New System.Drawing.Size(192, 72)
            Me.PanelGSOption.TabIndex = 99
            '
            'RadioBad
            '
            Me.RadioBad.BackColor = System.Drawing.Color.Transparent
            Me.RadioBad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.RadioBad.ForeColor = System.Drawing.Color.White
            Me.RadioBad.Location = New System.Drawing.Point(16, 22)
            Me.RadioBad.Name = "RadioBad"
            Me.RadioBad.Size = New System.Drawing.Size(112, 24)
            Me.RadioBad.TabIndex = 2
            Me.RadioBad.Text = "Bad/RUR"
            Me.RadioBad.Visible = False
            '
            'RadioGood
            '
            Me.RadioGood.BackColor = System.Drawing.Color.Transparent
            Me.RadioGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.RadioGood.ForeColor = System.Drawing.Color.White
            Me.RadioGood.Location = New System.Drawing.Point(16, 2)
            Me.RadioGood.Name = "RadioGood"
            Me.RadioGood.Size = New System.Drawing.Size(152, 24)
            Me.RadioGood.TabIndex = 1
            Me.RadioGood.Text = "Good/Refurbished"
            '
            'RadioScrap
            '
            Me.RadioScrap.BackColor = System.Drawing.Color.Transparent
            Me.RadioScrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.RadioScrap.ForeColor = System.Drawing.Color.White
            Me.RadioScrap.Location = New System.Drawing.Point(16, 41)
            Me.RadioScrap.Name = "RadioScrap"
            Me.RadioScrap.Size = New System.Drawing.Size(160, 24)
            Me.RadioScrap.TabIndex = 3
            Me.RadioScrap.Text = "Scrap"
            Me.RadioScrap.Visible = False
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblGSChildPallet_Name, Me.cmbCustomer, Me.lblCustomer, Me.cmdPallet, Me.Label5, Me.txtPallet, Me.Button1, Me.chkBoxEmpty_Pallet})
            Me.Panel1.Location = New System.Drawing.Point(8, 110)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(536, 64)
            Me.Panel1.TabIndex = 1
            '
            'lblGSChildPallet_Name
            '
            Me.lblGSChildPallet_Name.BackColor = System.Drawing.Color.Black
            Me.lblGSChildPallet_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGSChildPallet_Name.ForeColor = System.Drawing.Color.Lime
            Me.lblGSChildPallet_Name.Location = New System.Drawing.Point(328, 19)
            Me.lblGSChildPallet_Name.Name = "lblGSChildPallet_Name"
            Me.lblGSChildPallet_Name.Size = New System.Drawing.Size(200, 24)
            Me.lblGSChildPallet_Name.TabIndex = 90
            Me.lblGSChildPallet_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblGSChildPallet_Name.Visible = False
            '
            'cmbCustomer
            '
            Me.cmbCustomer.AutoComplete = True
            Me.cmbCustomer.BackColor = System.Drawing.Color.Khaki
            Me.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCustomer.Location = New System.Drawing.Point(112, 5)
            Me.cmbCustomer.Name = "cmbCustomer"
            Me.cmbCustomer.Size = New System.Drawing.Size(159, 21)
            Me.cmbCustomer.TabIndex = 85
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.LightSteelBlue
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.Color.Black
            Me.lblCustomer.Location = New System.Drawing.Point(32, 5)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(72, 16)
            Me.lblCustomer.TabIndex = 84
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdPallet
            '
            Me.cmdPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdPallet.ForeColor = System.Drawing.Color.White
            Me.cmdPallet.Location = New System.Drawing.Point(275, 34)
            Me.cmdPallet.Name = "cmdPallet"
            Me.cmdPallet.Size = New System.Drawing.Size(40, 22)
            Me.cmdPallet.TabIndex = 4
            Me.cmdPallet.Text = "GO"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label5.Location = New System.Drawing.Point(0, 34)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 16)
            Me.Label5.TabIndex = 83
            Me.Label5.Text = "Pallet Number:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPallet
            '
            Me.txtPallet.BackColor = System.Drawing.Color.Khaki
            Me.txtPallet.Location = New System.Drawing.Point(112, 34)
            Me.txtPallet.MaxLength = 30
            Me.txtPallet.Name = "txtPallet"
            Me.txtPallet.Size = New System.Drawing.Size(159, 20)
            Me.txtPallet.TabIndex = 2
            Me.txtPallet.Text = ""
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
            'chkBoxEmpty_Pallet
            '
            Me.chkBoxEmpty_Pallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxEmpty_Pallet.Location = New System.Drawing.Point(288, 8)
            Me.chkBoxEmpty_Pallet.Name = "chkBoxEmpty_Pallet"
            Me.chkBoxEmpty_Pallet.Size = New System.Drawing.Size(24, 16)
            Me.chkBoxEmpty_Pallet.TabIndex = 3
            Me.chkBoxEmpty_Pallet.Text = "No boxes for all devices in Pallet"
            Me.chkBoxEmpty_Pallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.chkBoxEmpty_Pallet.Visible = False
            '
            'PanelATCLE
            '
            Me.PanelATCLE.BackColor = System.Drawing.Color.Black
            Me.PanelATCLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelATCLE.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRcvd, Me.Label11, Me.lblRejected, Me.Label9, Me.lblAccepted, Me.Label7, Me.lblFileDevNum, Me.Label6})
            Me.PanelATCLE.Location = New System.Drawing.Point(544, 110)
            Me.PanelATCLE.Name = "PanelATCLE"
            Me.PanelATCLE.Size = New System.Drawing.Size(339, 184)
            Me.PanelATCLE.TabIndex = 83
            '
            'lblRcvd
            '
            Me.lblRcvd.BackColor = System.Drawing.Color.Transparent
            Me.lblRcvd.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRcvd.ForeColor = System.Drawing.Color.Lime
            Me.lblRcvd.Location = New System.Drawing.Point(225, 136)
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
            Me.Label11.Location = New System.Drawing.Point(-3, 136)
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
            Me.lblRejected.Location = New System.Drawing.Point(225, 96)
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
            Me.Label9.Location = New System.Drawing.Point(13, 96)
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
            Me.lblAccepted.Location = New System.Drawing.Point(225, 56)
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
            Me.Label7.Location = New System.Drawing.Point(13, 56)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(208, 31)
            Me.Label7.TabIndex = 85
            Me.Label7.Text = "Accepted :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFileDevNum
            '
            Me.lblFileDevNum.BackColor = System.Drawing.Color.Transparent
            Me.lblFileDevNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFileDevNum.ForeColor = System.Drawing.Color.Lime
            Me.lblFileDevNum.Location = New System.Drawing.Point(225, 16)
            Me.lblFileDevNum.Name = "lblFileDevNum"
            Me.lblFileDevNum.Size = New System.Drawing.Size(96, 31)
            Me.lblFileDevNum.TabIndex = 84
            Me.lblFileDevNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Lime
            Me.Label6.Location = New System.Drawing.Point(13, 16)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(208, 31)
            Me.Label6.TabIndex = 83
            Me.Label6.Text = "Devices in file :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMsg
            '
            Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
            Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMsg.ForeColor = System.Drawing.Color.White
            Me.lblMsg.Location = New System.Drawing.Point(233, 6)
            Me.lblMsg.Name = "lblMsg"
            Me.lblMsg.Size = New System.Drawing.Size(650, 104)
            Me.lblMsg.TabIndex = 84
            Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmdDone
            '
            Me.cmdDone.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDone.ForeColor = System.Drawing.Color.Navy
            Me.cmdDone.Location = New System.Drawing.Point(288, 496)
            Me.cmdDone.Name = "cmdDone"
            Me.cmdDone.Size = New System.Drawing.Size(280, 40)
            Me.cmdDone.TabIndex = 13
            Me.cmdDone.Text = "CLOSE PALLET"
            '
            'cmdUndo
            '
            Me.cmdUndo.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdUndo.Enabled = False
            Me.cmdUndo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdUndo.ForeColor = System.Drawing.Color.Red
            Me.cmdUndo.Location = New System.Drawing.Point(224, 416)
            Me.cmdUndo.Name = "cmdUndo"
            Me.cmdUndo.Size = New System.Drawing.Size(192, 32)
            Me.cmdUndo.TabIndex = 12
            Me.cmdUndo.Text = "UNDO (Last Reject Only)"
            '
            'tdgDescrep
            '
            Me.tdgDescrep.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgDescrep.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgDescrep.Location = New System.Drawing.Point(8, 320)
            Me.tdgDescrep.Name = "tdgDescrep"
            Me.tdgDescrep.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDescrep.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDescrep.PreviewInfo.ZoomFactor = 75
            Me.tdgDescrep.Size = New System.Drawing.Size(874, 88)
            Me.tdgDescrep.TabIndex = 10
            Me.tdgDescrep.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{}Style13{}Style12{}Hi" & _
            "ghlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelector{AlignImag" & _
            "e:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackC" & _
            "olor:InactiveCaption;}EvenRow{BackColor:Aqua;}Heading{Wrap:True;AlignVert:Center" & _
            ";Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{}S" & _
            "tyle4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0," & _
            " 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Sp" & _
            "lits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCaptionHeig" & _
            "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
            "dth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
            "Height>84</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle pare" & _
            "nt=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBa" & _
            "rStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3" & _
            """ /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=" & _
            """Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle" & _
            " parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Rec" & _
            "ordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""S" & _
            "elected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 87" & _
            "0, 84</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C" & _
            "1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" " & _
            "/><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><S" & _
            "tyle parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><St" & _
            "yle parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style " & _
            "parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style" & _
            " parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><St" & _
            "yle parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Name" & _
            "dStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout" & _
            "><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 870, 84</ClientAre" & _
            "a><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent=""""" & _
            " me=""Style21"" /></Blob>"
            '
            'cmdDeleteDescrap
            '
            Me.cmdDeleteDescrap.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDeleteDescrap.Enabled = False
            Me.cmdDeleteDescrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDeleteDescrap.ForeColor = System.Drawing.Color.Red
            Me.cmdDeleteDescrap.Location = New System.Drawing.Point(8, 416)
            Me.cmdDeleteDescrap.Name = "cmdDeleteDescrap"
            Me.cmdDeleteDescrap.Size = New System.Drawing.Size(216, 32)
            Me.cmdDeleteDescrap.TabIndex = 11
            Me.cmdDeleteDescrap.Text = "Delete Selected Discrepancy"
            Me.cmdDeleteDescrap.Visible = False
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 302)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(216, 16)
            Me.Label4.TabIndex = 89
            Me.Label4.Text = "Rejected/Discrepancies:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmdDeletePallet
            '
            Me.cmdDeletePallet.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDeletePallet.Enabled = False
            Me.cmdDeletePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDeletePallet.ForeColor = System.Drawing.Color.Red
            Me.cmdDeletePallet.Location = New System.Drawing.Point(296, 584)
            Me.cmdDeletePallet.Name = "cmdDeletePallet"
            Me.cmdDeletePallet.Size = New System.Drawing.Size(136, 24)
            Me.cmdDeletePallet.TabIndex = 90
            Me.cmdDeletePallet.Text = "Delete Pallet to Re-receive"
            Me.cmdDeletePallet.Visible = False
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkVerifyNew, Me.chkVerifyHistory})
            Me.Panel3.Location = New System.Drawing.Point(504, 584)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(80, 24)
            Me.Panel3.TabIndex = 93
            Me.Panel3.Visible = False
            '
            'chkVerifyNew
            '
            Me.chkVerifyNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkVerifyNew.Location = New System.Drawing.Point(168, 4)
            Me.chkVerifyNew.Name = "chkVerifyNew"
            Me.chkVerifyNew.Size = New System.Drawing.Size(88, 16)
            Me.chkVerifyNew.TabIndex = 93
            Me.chkVerifyNew.TabStop = False
            Me.chkVerifyNew.Text = "Verify New"
            '
            'chkVerifyHistory
            '
            Me.chkVerifyHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkVerifyHistory.Location = New System.Drawing.Point(8, 4)
            Me.chkVerifyHistory.Name = "chkVerifyHistory"
            Me.chkVerifyHistory.Size = New System.Drawing.Size(136, 16)
            Me.chkVerifyHistory.TabIndex = 92
            Me.chkVerifyHistory.TabStop = False
            Me.chkVerifyHistory.Text = "Verify Having History"
            '
            'cmdReject
            '
            Me.cmdReject.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdReject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdReject.ForeColor = System.Drawing.Color.Red
            Me.cmdReject.Location = New System.Drawing.Point(416, 416)
            Me.cmdReject.Name = "cmdReject"
            Me.cmdReject.Size = New System.Drawing.Size(195, 32)
            Me.cmdReject.TabIndex = 94
            Me.cmdReject.Text = "Reject for wrong SKU"
            '
            'cmdDeleteAccpeted
            '
            Me.cmdDeleteAccpeted.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDeleteAccpeted.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDeleteAccpeted.ForeColor = System.Drawing.Color.Red
            Me.cmdDeleteAccpeted.Location = New System.Drawing.Point(56, 584)
            Me.cmdDeleteAccpeted.Name = "cmdDeleteAccpeted"
            Me.cmdDeleteAccpeted.Size = New System.Drawing.Size(232, 24)
            Me.cmdDeleteAccpeted.TabIndex = 96
            Me.cmdDeleteAccpeted.Text = "Delete ACCEPTED Device From Warehouse Receive"
            Me.cmdDeleteAccpeted.Visible = False
            '
            'cmdDeleteProdRcvdDev
            '
            Me.cmdDeleteProdRcvdDev.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDeleteProdRcvdDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDeleteProdRcvdDev.ForeColor = System.Drawing.Color.Red
            Me.cmdDeleteProdRcvdDev.Location = New System.Drawing.Point(592, 584)
            Me.cmdDeleteProdRcvdDev.Name = "cmdDeleteProdRcvdDev"
            Me.cmdDeleteProdRcvdDev.Size = New System.Drawing.Size(192, 24)
            Me.cmdDeleteProdRcvdDev.TabIndex = 97
            Me.cmdDeleteProdRcvdDev.Text = "Delete Production Received Device"
            Me.cmdDeleteProdRcvdDev.Visible = False
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Black
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Yellow
            Me.lblGroup.Location = New System.Drawing.Point(14, 85)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(209, 23)
            Me.lblGroup.TabIndex = 98
            Me.lblGroup.Text = "CELLULAR 1 STAGE 1"
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'PanelGS
            '
            Me.PanelGS.BackColor = System.Drawing.Color.Black
            Me.PanelGS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelGS.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblGSReject, Me.Label20, Me.lblGSRcvd, Me.Label8, Me.lblGood, Me.Label14, Me.lblGSFileDevNum, Me.Label16, Me.Label18, Me.lblNoSN})
            Me.PanelGS.Location = New System.Drawing.Point(544, 110)
            Me.PanelGS.Name = "PanelGS"
            Me.PanelGS.Size = New System.Drawing.Size(339, 184)
            Me.PanelGS.TabIndex = 99
            '
            'lblGSReject
            '
            Me.lblGSReject.BackColor = System.Drawing.Color.Transparent
            Me.lblGSReject.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGSReject.ForeColor = System.Drawing.Color.Lime
            Me.lblGSReject.Location = New System.Drawing.Point(225, 112)
            Me.lblGSReject.Name = "lblGSReject"
            Me.lblGSReject.Size = New System.Drawing.Size(96, 25)
            Me.lblGSReject.TabIndex = 94
            Me.lblGSReject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label20
            '
            Me.Label20.BackColor = System.Drawing.Color.Transparent
            Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.Lime
            Me.Label20.Location = New System.Drawing.Point(13, 112)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(208, 25)
            Me.Label20.TabIndex = 93
            Me.Label20.Text = "Rejected :"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label20.Visible = False
            '
            'lblGSRcvd
            '
            Me.lblGSRcvd.BackColor = System.Drawing.Color.Transparent
            Me.lblGSRcvd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGSRcvd.ForeColor = System.Drawing.Color.Lime
            Me.lblGSRcvd.Location = New System.Drawing.Point(225, 150)
            Me.lblGSRcvd.Name = "lblGSRcvd"
            Me.lblGSRcvd.Size = New System.Drawing.Size(96, 25)
            Me.lblGSRcvd.TabIndex = 90
            Me.lblGSRcvd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Lime
            Me.Label8.Location = New System.Drawing.Point(13, 150)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(208, 25)
            Me.Label8.TabIndex = 89
            Me.Label8.Text = "Total Received :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblGood
            '
            Me.lblGood.BackColor = System.Drawing.Color.Transparent
            Me.lblGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGood.ForeColor = System.Drawing.Color.Lime
            Me.lblGood.Location = New System.Drawing.Point(225, 78)
            Me.lblGood.Name = "lblGood"
            Me.lblGood.Size = New System.Drawing.Size(96, 25)
            Me.lblGood.TabIndex = 86
            Me.lblGood.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Lime
            Me.Label14.Location = New System.Drawing.Point(13, 78)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(208, 25)
            Me.Label14.TabIndex = 85
            Me.Label14.Text = "Good/Refurbish :"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblGSFileDevNum
            '
            Me.lblGSFileDevNum.BackColor = System.Drawing.Color.Transparent
            Me.lblGSFileDevNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGSFileDevNum.ForeColor = System.Drawing.Color.Lime
            Me.lblGSFileDevNum.Location = New System.Drawing.Point(225, 3)
            Me.lblGSFileDevNum.Name = "lblGSFileDevNum"
            Me.lblGSFileDevNum.Size = New System.Drawing.Size(96, 25)
            Me.lblGSFileDevNum.TabIndex = 84
            Me.lblGSFileDevNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label16
            '
            Me.Label16.BackColor = System.Drawing.Color.Transparent
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Lime
            Me.Label16.Location = New System.Drawing.Point(13, 3)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(208, 25)
            Me.Label16.TabIndex = 83
            Me.Label16.Text = "Devices in file :"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label18
            '
            Me.Label18.BackColor = System.Drawing.Color.Transparent
            Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.Lime
            Me.Label18.Location = New System.Drawing.Point(13, 40)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(208, 25)
            Me.Label18.TabIndex = 91
            Me.Label18.Text = "Devices have no SN :"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNoSN
            '
            Me.lblNoSN.BackColor = System.Drawing.Color.Transparent
            Me.lblNoSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNoSN.ForeColor = System.Drawing.Color.Lime
            Me.lblNoSN.Location = New System.Drawing.Point(228, 40)
            Me.lblNoSN.Name = "lblNoSN"
            Me.lblNoSN.Size = New System.Drawing.Size(96, 25)
            Me.lblNoSN.TabIndex = 92
            Me.lblNoSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdGetSNNotRec
            '
            Me.cmdGetSNNotRec.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdGetSNNotRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdGetSNNotRec.ForeColor = System.Drawing.Color.Red
            Me.cmdGetSNNotRec.Location = New System.Drawing.Point(811, 416)
            Me.cmdGetSNNotRec.Name = "cmdGetSNNotRec"
            Me.cmdGetSNNotRec.Size = New System.Drawing.Size(200, 32)
            Me.cmdGetSNNotRec.TabIndex = 100
            Me.cmdGetSNNotRec.Text = "SNs not Received"
            Me.cmdGetSNNotRec.Visible = False
            '
            'cmdChangeSN
            '
            Me.cmdChangeSN.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdChangeSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdChangeSN.ForeColor = System.Drawing.Color.Red
            Me.cmdChangeSN.Location = New System.Drawing.Point(224, 456)
            Me.cmdChangeSN.Name = "cmdChangeSN"
            Me.cmdChangeSN.Size = New System.Drawing.Size(192, 32)
            Me.cmdChangeSN.TabIndex = 102
            Me.cmdChangeSN.Text = "Change Serial Number"
            Me.cmdChangeSN.Visible = False
            '
            'cmdReprintDesc
            '
            Me.cmdReprintDesc.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdReprintDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdReprintDesc.ForeColor = System.Drawing.Color.Red
            Me.cmdReprintDesc.Location = New System.Drawing.Point(611, 416)
            Me.cmdReprintDesc.Name = "cmdReprintDesc"
            Me.cmdReprintDesc.Size = New System.Drawing.Size(200, 32)
            Me.cmdReprintDesc.TabIndex = 103
            Me.cmdReprintDesc.Text = "Reprint selected Descrepancy"
            Me.cmdReprintDesc.Visible = False
            '
            'cmdGetSubPallet
            '
            Me.cmdGetSubPallet.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdGetSubPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdGetSubPallet.ForeColor = System.Drawing.Color.Red
            Me.cmdGetSubPallet.Location = New System.Drawing.Point(611, 416)
            Me.cmdGetSubPallet.Name = "cmdGetSubPallet"
            Me.cmdGetSubPallet.Size = New System.Drawing.Size(200, 32)
            Me.cmdGetSubPallet.TabIndex = 104
            Me.cmdGetSubPallet.Text = "Get Subpallet"
            Me.cmdGetSubPallet.Visible = False
            '
            'cmdChangePalletModel
            '
            Me.cmdChangePalletModel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdChangePalletModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdChangePalletModel.ForeColor = System.Drawing.Color.Red
            Me.cmdChangePalletModel.Location = New System.Drawing.Point(8, 456)
            Me.cmdChangePalletModel.Name = "cmdChangePalletModel"
            Me.cmdChangePalletModel.Size = New System.Drawing.Size(216, 32)
            Me.cmdChangePalletModel.TabIndex = 106
            Me.cmdChangePalletModel.Text = "Change Pallet Model"
            Me.cmdChangePalletModel.Visible = False
            '
            'frmWarehouseRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1028, 621)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdChangePalletModel, Me.cmdGetSubPallet, Me.cmdReprintDesc, Me.cmdChangeSN, Me.PanelGS, Me.lblGroup, Me.cmdDeleteProdRcvdDev, Me.cmdDeleteAccpeted, Me.cmdReject, Me.Panel3, Me.cmdDeletePallet, Me.Label4, Me.cmdDeleteDescrap, Me.tdgDescrep, Me.cmdUndo, Me.cmdDone, Me.lblMsg, Me.PanelATCLE, Me.Panel1, Me.Panel6, Me.lblHeader, Me.cmdGetSNNotRec})
            Me.Name = "frmWarehouseRec"
            Me.Text = "ATCLE Receiving"
            Me.Panel6.ResumeLayout(False)
            Me.PanelDevNoSN.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.PanelOptions.ResumeLayout(False)
            Me.PanelBOX.ResumeLayout(False)
            Me.PanelDevice.ResumeLayout(False)
            Me.PanelGSOption.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.PanelATCLE.ResumeLayout(False)
            CType(Me.tdgDescrep, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.PanelGS.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************
        Private Sub txtBoxSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxSN.KeyDown
            Dim iSNExistedInWHR As Integer = 0

            If e.KeyValue = 13 Then
                Try
                    If strPallett = "" Then
                        txtBoxSN.Text = ""
                        Exit Sub
                    End If

                    'If Me.chkWrongSKU.Checked = True Then
                    '    iWrongSKU = 1
                    'Else
                    '    iWrongSKU = 0
                    'End If

                    If Me.iCust_id = 2219 And Me.iDev_billcode = 0 Then
                        MessageBox.Show("Please Select the devices condition( Good/Refurbished ). ", "Input SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    '//added by Lan 12/06/2006
                    If Me.iCust_id = 2219 And Me.strChildPalletName = "" Then
                        MessageBox.Show("Sub pallet is not defined. Can not receive.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    If Me.iCust_id = 2219 And Me.iGS_Limit = Me.iGS_ScanQty Then
                        MessageBox.Show("This subPallet already meet the limit. Click 'CLOSE PALLET' button.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtBoxSN.Text = ""
                        Exit Sub
                    End If
                    '//


                    Me.lblMsg.Text = ""
                    Me.lblMsg.BackColor = SteelBlue

                    System.Windows.Forms.Application.DoEvents()

                    If Trim(Me.txtBoxSN.Text) <> "" And (Trim(Me.txtDevSN.Text) <> "" Or Me.chkBoxEmpty.Checked = True Or Me.chkMultiPhone.Checked = True) Then
                        Me.chkBoxEmpty.Checked = False
                        Me.chkMultiPhone.Checked = False
                        Dim i As Integer = 0

                        'If Me.chkBoxEmpty.Checked = True Then
                        'i = objWarehouse.ProcessSerialNumbers(iParentGroupID, iUserID, strPallett, Trim(Me.txtBoxSN.Text), "", 1, iNoBoxForPallet, iWrongSKU)
                        'Else

                        '*****************************************************
                        'Lan Add 10/30/2006
                        Dim strBoxSN = UCase(Trim(Me.txtBoxSN.Text))
                        Dim strDevSN = UCase(Trim(Me.txtDevSN.Text))

                        If Me.cmbCustomer.SelectedValue = 2219 Then
                            iSNExistedInWHR = objWarehouse.IsSNExistedInWHR(iCust_id, _
                                                                            Me.strChildPalletName, _
                                                                            strBoxSN, _
                                                                            strDevSN)
                            If iSNExistedInWHR > 0 Then
                                Me.txtBoxSN.Text = ""
                                Me.txtDevSN.Text = ""
                                MessageBox.Show("This SN already received onto the line for pallet '" & Me.strChildPalletName & "'.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If
                        End If
                        ''lan add  iDev_billcode and iCust_id
                        i = objWarehouse.ProcessSerialNumbers(iParentGroupID, iUserID, strPallett, strBoxSN, strDevSN, 0, iNoBoxForPallet, iWrongSKU, _
                                                              iCust_id, iDev_billcode, iDevNoSN, )
                        '*****************************************************

                        'End If


                        'Me.lblAccepted.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 0)
                        'Me.lblRejected.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1)
                        'Me.lblRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)

                        If objWarehouse.Result = 1 Then
                            Me.cmdUndo.Enabled = True
                        Else
                            Me.cmdUndo.Enabled = False
                        End If

                        RecalculateNumbers()
                        FormatControls(i)
                        '//
                        'added condition by Lan on 12/06/2006
                        If Me.iCust_id <> 2219 Then
                            LoadDescrepancies()
                        End If
                        '//
                        Me.txtBoxSN.Focus()
                    Else
                        If Me.txtBoxSN.Text = "" Then
                            Me.txtBoxSN.Focus()
                        ElseIf Me.txtDevSN.Text = "" Then
                            Me.txtDevSN.Focus()
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("txtBoxSN_KeyDown: " & Environment.NewLine & ex.Message, "Input Box SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.txtBoxSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.chkBoxEmpty.Checked = False
                    Me.chkMultiPhone.Checked = False
                    Me.txtBoxSN.Focus()
                End Try
            End If
        End Sub
        '*********************************************************
        Private Sub txtDevSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyDown
            Dim iSNExistedInWHR As Integer = 0

            If e.KeyValue = 13 Then
                Try

                    If strPallett = "" Then
                        txtDevSN.Text = ""
                        Exit Sub
                    End If

                    'If Me.chkWrongSKU.Checked = True Then
                    '    iWrongSKU = 1
                    'Else
                    '    iWrongSKU = 0
                    'End If


                    If Me.iCust_id = 2219 And Me.iDev_billcode = 0 Then
                        MessageBox.Show("Please Select the devices condition( Good/Refurbished ). ", "Input SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    '//added by Lan 12/06/2006
                    If Me.iCust_id = 2219 And Me.strChildPalletName = "" Then
                        MessageBox.Show("Sub pallet is not defined. Can not receive.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    If Me.iCust_id = 2219 And Me.iGS_Limit = Me.iGS_ScanQty Then
                        Me.txtBoxSN.Text = ""
                        Me.txtDevSN.Text = ""
                        MessageBox.Show("This sub pallet (" & Me.strChildPalletName & ") already meet the limit (" & Me.iGS_Limit & "). Click 'CLOSE PALLET' button.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    '//

                    Me.lblMsg.Text = ""
                    Me.lblMsg.BackColor = SteelBlue


                    '//This is new to determine if a messagebox should be thrown for verification
                    'Start
                    '//Legend 0-No Verify, 1-History, 2-New
                    If Me.chkVerifyHistory.Checked = True Then chkVerify = 1
                    If Me.chkVerifyNew.Checked = True Then chkVerify = 2
                    System.Windows.Forms.Application.DoEvents()
                    If chkVerify > 0 Then
                        checkSerialStatus(Trim(txtDevSN.Text), chkVerify)
                    End If
                    'End

                    '********************************************************
                    'lan add 10/30/2006
                    Dim strBoxSN = UCase(Trim(Me.txtBoxSN.Text))
                    Dim strDevSN = UCase(Trim(Me.txtDevSN.Text))

                    If Me.cmbCustomer.SelectedValue = 2219 Then
                        iSNExistedInWHR = objWarehouse.IsSNExistedInWHR(iCust_id, _
                                                                        Me.strChildPalletName, _
                                                                        strBoxSN, _
                                                                        strDevSN)
                        If iSNExistedInWHR > 0 Then
                            Me.txtBoxSN.Text = ""
                            Me.txtDevSN.Text = ""
                            MessageBox.Show("This SN already received onto the line under pallet '" & Me.strChildPalletName & "'.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If
                    '********************************************************
                    Dim i As Integer = 0

                    If iNoBoxForPallet = 1 Then
                        If Trim(Me.txtDevSN.Text) <> "" Then
                            'lan add iCust_id, iDev_billcode
                            i = objWarehouse.ProcessSerialNumbers(iParentGroupID, iUserID, strPallett, strBoxSN, strDevSN, 0, iNoBoxForPallet, iWrongSKU, _
                                                                  iCust_id, iDev_billcode, iDevNoSN, )

                            If objWarehouse.Result = 1 Then
                                Me.cmdUndo.Enabled = True
                            Else
                                Me.cmdUndo.Enabled = False
                            End If

                            RecalculateNumbers()
                            'Me.lblAccepted.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 0)
                            'Me.lblRejected.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1)
                            'Me.lblRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)
                            FormatControls(i)

                            If Me.iCust_id <> 2219 Then     'Lan added condition on 12/06/2006
                                LoadDescrepancies()
                            End If

                            Me.txtDevSN.Focus()
                        Else
                            Me.txtDevSN.Focus()
                        End If
                    Else
                        Me.chkBoxEmpty.Checked = False
                        Me.chkMultiPhone.Checked = False
                        System.Windows.Forms.Application.DoEvents()
                        If Trim(Me.txtBoxSN.Text) <> "" And Trim(Me.txtDevSN.Text) <> "" Then
                            'lan add iCust_id, iDev_billcode
                            i = objWarehouse.ProcessSerialNumbers(iParentGroupID, iUserID, strPallett, strBoxSN, strDevSN, 0, iNoBoxForPallet, iWrongSKU, _
                                                                  iCust_id, iDev_billcode, iDevNoSN, )

                            If objWarehouse.Result = 1 Then
                                Me.cmdUndo.Enabled = True
                            Else
                                Me.cmdUndo.Enabled = False
                            End If

                            RecalculateNumbers()
                            FormatControls(i)

                            If Me.iCust_id <> 2219 Then     'Lan added condition on 12/06/2006
                                LoadDescrepancies()
                            End If

                            Me.txtBoxSN.Focus()
                        Else
                            If Me.txtBoxSN.Text = "" Then
                                Me.txtBoxSN.Focus()
                            ElseIf Me.txtDevSN.Text = "" Then
                                Me.chkBoxEmpty.Focus()
                            End If
                        End If
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Input Device SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.txtBoxSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.chkBoxEmpty.Checked = False
                    Me.chkMultiPhone.Checked = False
                    '//
                    Me.CheckNoSN.Checked = False
                    Me.chkWrongSKU.Checked = False
                    '//
                    Me.txtBoxSN.Focus()
                End Try

            End If
        End Sub

        '*********************************************************
        Private Sub checkSerialStatus(ByVal vSerialNum As String, ByVal vCheckVerify As Integer)
            Dim strSQL As String
            strSQL = "select * from " & _
                     "tdevice where device_sn = '" & vSerialNum & "' " & _
                     "and loc_id = 2540 " & _
                     "and device_dateship > '" & DateCheck & " 00:00:00' " & _
                     "and model_id <> 849 " & _
                     "order by device_id desc"
            dtCheck = ds.OrderEntrySelect(strSQL)
            System.Windows.Forms.Application.DoEvents()
            If dtCheck.Rows.Count > 0 Then
                If vCheckVerify = 1 Then
                    MsgBox("This device has history. It has been to this facility within the past 6 months.", MsgBoxStyle.OKOnly, "HISTORY PRESENT")
                End If

            Else
                If vCheckVerify = 2 Then
                    MsgBox("This device is new.", MsgBoxStyle.OKOnly, "NEW DEVICE")
                End If
            End If
        End Sub
        '*********************************************************
        Private Sub RecalculateNumbers()
            Dim iTotal As Integer = 0

            If iCust_id = 2019 Then
                Me.lblAccepted.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 0, iCust_id)
                Me.lblRejected.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1, iCust_id)
                If Me.lblAccepted.Text <> "" Then
                    iTotal += CInt(Me.lblAccepted.Text)
                End If
                If Me.lblRejected.Text <> "" Then
                    iTotal += CInt(Me.lblRejected.Text)
                End If
                Me.lblRcvd.Text = iTotal
            ElseIf iCust_id = 2219 Then
                'Me.lblGSReject.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1, iCust_id)
                '***********************************
                '873 is a billcode of Good devices; 874 is Bad; 875 is Scrap
                Me.lblGood.Text = objWarehouse.GetGoodBadScrapDevices(Me.strChildPalletName, 873, iCust_id)
                Me.lblNoSN.Text = objWarehouse.GetDevicesNoSN(strPallett, iCust_id)
                ''Me.lblBad.Text = objWarehouse.GetGoodBadScrapDevices(strPallett, 874, iCust_id)
                ''Me.lblScrap.Text = objWarehouse.GetGoodBadScrapDevices(strPallett, 875, iCust_id)
                '************************************
                'If Me.lblGSReject.Text <> "" Then
                '    iTotal += CInt(Me.lblGSReject.Text)
                'End If
                If Me.lblGood.Text <> "" Then
                    iTotal += CInt(Me.lblGood.Text)
                End If
                ''If Me.lblBad.Text <> "" Then
                ''    iTotal += CInt(Me.lblBad.Text)
                ''End If
                ''If Me.lblScrap.Text <> "" Then
                ''    iTotal += CInt(Me.lblScrap.Text)
                ''End If
                Me.lblGSRcvd.Text = iTotal
                Me.iGS_ScanQty = iTotal
            End If
        End Sub
        '*********************************************************
        Protected Overrides Sub Finalize()
            objWarehouse = Nothing
            MyBase.Finalize()
        End Sub
        '*********************************************************
        Private Sub chkBoxEmpty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxEmpty.CheckedChanged
            Try
                If strPallett = "" Then
                    Me.chkBoxEmpty.Checked = False
                    Exit Sub
                End If

                If Me.chkBoxEmpty.Checked Then
                    If Trim(Me.txtBoxSN.Text) = "" Then
                        MessageBox.Show("Please input Box Serial Number.", "Input Box Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.chkBoxEmpty.Checked = False
                        Me.txtBoxSN.Focus()
                        Exit Sub
                    ElseIf Trim(Me.txtDevSN.Text) <> "" Then
                        MessageBox.Show("Please clear Device Serial Number.", "Input Device Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.chkBoxEmpty.Checked = False
                        Me.txtDevSN.Focus()
                        Exit Sub
                    End If
                    Dim i As Integer = 0

                    '********************************************************
                    'Lan add 10/30/2006
                    Dim strBoxSN = UCase(Trim(Me.txtBoxSN.Text))
                    Dim strDevSN = UCase(Trim(Me.txtDevSN.Text))
                    '********************************************************
                    'lan add iCust_id, iDev_billcode
                    i = objWarehouse.ProcessSerialNumbers(iParentGroupID, iUserID, strPallett, strBoxSN, strDevSN, 1, iNoBoxForPallet, iWrongSKU, _
                                                          iCust_id, iDev_billcode, iDevNoSN, )

                    If objWarehouse.Result = 1 Then
                        Me.cmdUndo.Enabled = True
                    Else
                        Me.cmdUndo.Enabled = False
                    End If

                    RecalculateNumbers()
                    FormatControls(i)
                    LoadDescrepancies()


                Me.txtBoxSN.Focus()
                Else
                If Me.txtBoxSN.Text = "" Then
                    Me.txtBoxSN.Focus()
                ElseIf Me.txtDevSN.Text = "" Then
                    Me.txtDevSN.Focus()
                End If
                End If
            Catch ex As Exception
                MessageBox.Show("chkBoxEmpty_CheckedChanged: " & Environment.NewLine & ex.Message, "Empty Box", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtBoxSN.Text = ""
                Me.txtDevSN.Text = ""
                Me.chkBoxEmpty.Checked = False
                Me.txtBoxSN.Focus()
            End Try
        End Sub
        '*********************************************************
        Private Sub FormatControls(ByVal i As Integer)
            Select Case i

                Case 0          'No descrepencies
                    'Me.BackColor = SteelBlue
                    'Me.lblMsg.BackColor = SteelBlue
                    'Me.lblMsg.ForeColor = ForestGreen
                    Me.lblMsg.BackColor = ForestGreen

                    '''If Me.cmbCustomer.SelectedValue = 2219 Then     'GAME STOP
                    '''    If Me.RadioGood.Checked = True Then
                    '''        Me.lblMsg.Text = "ACCEPTED GOOD/REFURBISHED"
                    '''    ElseIf Me.RadioBad.Checked = True Then
                    '''        Me.lblMsg.Text = "ACCEPTED BAD/RUR"
                    '''    ElseIf Me.RadioScrap.Checked = True Then
                    '''        Me.lblMsg.Text = "ACCEPTED SCRAP"
                    '''    End If
                    '''Else                                            'ATCLE 
                    '''    Me.lblMsg.Text = "ACCEPTED"
                    '''End If
                    Me.lblMsg.Text = "ACCEPTED"
                    Me.txtBoxSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.chkBoxEmpty.Checked = False
                    Me.chkMultiPhone.Checked = False
                    Me.txtBoxSN.Focus()
                    System.Windows.Forms.Application.DoEvents()

                Case 1          'Descrepencies are there
                    'Me.BackColor = Red
                    'Me.lblMsg.BackColor = White
                    'Me.lblMsg.ForeColor = Red
                    Me.lblMsg.BackColor = Red
                    Me.lblMsg.Text = "REJECTED"
                    Me.txtBoxSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.chkBoxEmpty.Checked = False
                    Me.chkMultiPhone.Checked = False
                    Me.txtBoxSN.Focus()
                    System.Windows.Forms.Application.DoEvents()

            End Select
            Me.chkWrongSKU.Checked = False
            'Me.CheckNoSN.Checked = False
        End Sub
        '*********************************************************
        Private Sub frmWarehouseRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If iParentGroupID = 0 Then
                MessageBox.Show("This Computer is not mapped to any Line/Group. Receiving can not be done.")
                Me.Close()
            End If
            '*********************11/13/2006 by Lan
            'Check for correct map of this computer
            If Not objWarehouse.CheckCompMap(iParentGroupID) Then
                MessageBox.Show("This Computer is not mapped to right Group. Receiving can not be done.")
                Me.Close()
            End If
            '****************************************

            Try
                'Determine the customer and reset screen
                If iParentGroupID = 14 Then                   'GAME STOP
                    LoadCustomers(5, 2219)                    '5:Prod_id, 2219:cust_id (lan)
                    Me.PanelOptions.Visible = False
                    Me.PanelGSOption.Visible = True
                    Me.PanelDevNoSN.Visible = True
                    Me.RadioGood.Checked = True               'by default device is good
                    Me.PanelBOX.Visible = False
                    Me.lblHeader.Text = "GAMESTOP RECEIVING"
                    iNoBoxForPallet = 1
                    Me.PanelGS.Visible = True
                    Me.PanelATCLE.Visible = False
                    iDev_billcode = 873  'bill code for good

                    '10/26/2006
                    Me.cmdGetSubPallet.Visible = True
                    'Me.lstSNNotRec.Visible = True
                    Me.cmdChangeSN.Visible = True
                    Me.cmdReprintDesc.Visible = False

                    '//added by Lan 12/06/206
                    Me.lblGSChildPallet_Name.Visible = True
                Else                                           '(ATCLE)
                    LoadCustomers(2, 2019)                      '2:Prod_id, 2019:cust_id (lan)
                    Me.PanelOptions.Visible = True
                    Me.PanelGSOption.Visible = False
                    Me.PanelDevNoSN.Visible = False
                    Me.PanelBOX.Visible = True
                    Me.lblHeader.Text = "ATCLE RECEIVING"
                    iNoBoxForPallet = 0
                    Me.PanelGS.Visible = False
                    Me.PanelATCLE.Visible = True

                    '10/26/2006
                    Me.cmdChangeSN.Visible = False
                    Me.cmdReprintDesc.Visible = True
                End If

                Me.lblGroup.Text = objWarehouse.GetGroupName(iParentGroupID)

                '**************************************
                'Set Special permissions
                '**************************************
                If ApplicationUser.GetPermission("DockReceiving_Delete") > 0 Then
                    'Me.cmdDeletePallet.Visible = True
                    Me.cmdDeleteDescrap.Visible = True
                    Me.cmdReprintDesc.Visible = True
                    Me.cmdChangePalletModel.Visible = True
                Else
                    'Me.cmdDeletePallet.Visible = False
                    Me.cmdDeleteDescrap.Visible = False
                    Me.cmdReprintDesc.Visible = False
                    Me.cmdChangePalletModel.Visible = False
                End If

                'cmdGetSNNotRec
                If ApplicationUser.GetPermission("SNNotLineRec") > 0 Then
                    Me.cmdGetSNNotRec.Visible = True
                Else
                    Me.cmdGetSNNotRec.Visible = False
                End If

                '**************************************

                Me.txtPallet.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try

        End Sub

        '*********************************************************
        'Lan add customer
        '*********************************************************
        Private Sub LoadCustomers(ByVal iProd_id As Integer, ByVal iCustID As Integer)
            Dim dtCustomers As New DataTable()
            Dim objMisc As New PSS.Data.Buisness.Misc()
            Try
                dtCustomers = objMisc.GetCustomers(iProd_id)
                With Me.cmbCustomer
                    .DataSource = dtCustomers.DefaultView
                    .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                    .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                    .SelectedValue = iCustID  '2019:ATCLE-AWS, 2219:GameStop
                End With

                Me.iCust_id = iCustID  'set iCust_id variable

            Catch ex As Exception
                MsgBox("Error in frmWarehouseRec.LoadCustomers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(dtCustomers) Then
                    dtCustomers.Dispose()
                    dtCustomers = Nothing
                End If
                If Not IsNothing(objMisc) Then
                    objMisc = Nothing
                End If
            End Try
        End Sub
        '*********************************************************
        Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click
            Dim i As Integer = 0
            Dim iFileCnt As Integer = 0
            Dim iDevCnt As Integer = 0
            Dim iCurFileQty As Integer = 0
            Dim iCloseParentFlg As Integer = 0
            Dim iPalletDiscrepancy As Integer = 0

            Try
                If strPallett = "" Then
                    Exit Sub
                End If
                'check if no device have been scanned into pallet
                If Me.iCust_id = 2219 And Me.iGS_ScanQty = 0 Then
                    MessageBox.Show("Sub pallet does not contain any device. Please check it.", "Close Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                '//
                If Me.iCust_id = 2219 And Me.strChildPalletName = "" Then
                    MessageBox.Show("Sub pallet is not defined.", "Close Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                '//

                If MessageBox.Show("Are you sure you want to close this pallet?" & Environment.NewLine & "Once the Pallet is closed it can not be reopened!", "Close Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    '********************************************************************
                    'condition and function ClosePallet_GAMESTOP added by Lan on 12/08/2006
                    If Me.iCust_id = 2219 Then
                        '*************************************
                        'get file qty and pallet qty
                        If Me.lblGSFileDevNum.Text <> "" Then
                            iFileCnt = CInt(Me.lblGSFileDevNum.Text)
                        End If
                        If Me.lblGSRcvd.Text <> "" Then
                            iDevCnt = CInt(Me.lblGSRcvd.Text)
                        End If
                        '*************************************

                        iCurFileQty = objWarehouse.GetDevCountFromLoadedFile(strPallett, iCust_id)
                        If iCurFileQty = 0 Then
                            iCloseParentFlg = 1
                        End If
                        'Close out Pallet
                        i = objWarehouse.ClosePallet_GAMESTOP(iCloseParentFlg, Me.iGS_ScanQty, strPallett, strChildPalletName, iCust_id)

                        '**************************
                        If iCloseParentFlg = 0 Then
                            OpenPallet()
                        Else
                            ClearControls()
                        End If

                        '**************************
                    Else
                        '*************************************
                        'get file qty and pallet qty
                        '*************************************
                        If Me.lblFileDevNum.Text <> "" Then
                            iFileCnt = CInt(Me.lblFileDevNum.Text)
                        End If
                        If Me.lblRcvd.Text <> "" Then
                            iDevCnt = CInt(Me.lblRcvd.Text)
                        End If

                        If iFileCnt - iDevCnt > 0 Then
                            iPalletDiscrepancy = 1   'Received number is less than file number
                        ElseIf iFileCnt - iDevCnt < 0 Then
                            iPalletDiscrepancy = 2   'Received number is greater than file number
                        End If
                        '*************************************
                        'Close out Pallet
                        i = objWarehouse.ClosePallet(strPallett, iPalletDiscrepancy, iCust_id, iParentGroupID)

                        i += objWarehouse.GetPhonesInFileNotOnPallet(iParentGroupID, strPallett, iCust_id)

                        ClearControls()
                    End If
                    '********************************************************************

                    If i = 0 Then
                        Throw New Exception("There was a problem closing out the pallet. Contact administrators.")
                    End If

                    'Generate Report
                    '//August 3, 2006 - This will not print the report automatically
                    'i = objWarehouse.CreateReport(strPallett)

                Else
                    Exit Sub
                End If

            Catch ex As Exception
                MessageBox.Show("cmdDone_Click: " & Environment.NewLine & ex.Message, "Close Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************
        Private Sub ClearControls()
            Me.lblMsg.Text = ""
            Me.lblMsg.BackColor = SteelBlue
            Me.lblFileDevNum.Text = ""
            Me.lblAccepted.Text = ""
            Me.lblRejected.Text = ""
            Me.lblRcvd.Text = ""
            Me.txtPallet.Text = ""
            Me.strPallett = ""
            Me.txtBoxSN.Text = ""
            Me.txtDevSN.Text = ""
            Me.chkBoxEmpty.Checked = False
            Me.chkMultiPhone.Checked = False
            'Me.chkBoxEmpty_Pallet.Checked = False
            Me.chkBoxEmpty.Enabled = True
            Me.txtBoxSN.Enabled = True
            Me.tdgDescrep.ClearFields()
            Me.chkVerifyHistory.Checked = False
            Me.chkVerifyNew.Checked = False

            Me.CheckNoSN.Checked = False
            ''''Me.RadioGood.Checked = False
            ''''Me.RadioBad.Checked = False
            ''''Me.RadioScrap.Checked = False
            Me.lblGSFileDevNum.Text = ""
            Me.lblNoSN.Text = ""
            Me.lblGood.Text = ""
            Me.lblGSReject.Text = ""
            Me.lblGSRcvd.Text = ""
            Me.iGS_ScanQty = 0
            Me.strChildPalletName = ""
            Me.lblGSChildPallet_Name.Text = ""

        End Sub
        '*********************************************************
        Private Sub OpenPallet()
            '*********************************************************
            'Step 1: Look for the file for the pallet
            Dim dirs As String()
            Dim i As Integer = 0
            Dim iNoBox As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Me.txtBoxSN.Text = ""
            Me.txtDevSN.Text = ""
            Me.lblFileDevNum.Text = ""
            Me.lblAccepted.Text = ""
            Me.lblRejected.Text = ""
            Me.lblRcvd.Text = ""
            Me.chkBoxEmpty.Checked = False
            Me.chkMultiPhone.Checked = False
            strPallett = ""
            '************************* Game Stop 12/06/2006
            Me.lblGSFileDevNum.Text = ""
            Me.lblGSRcvd.Text = ""
            Me.lblGSReject.Text = ""
            Me.lblGood.Text = ""
            Me.lblNoSN.Text = ""
            Me.lblGSChildPallet_Name.Text = ""
            'iGS_WHP_FileQty = 0
            iGS_ScanQty = 0
            '*************************
            Me.tdgDescrep.ClearFields()
            strPallett = Trim(Me.txtPallet.Text)

            Try

                '************************************* lan add
                'check if groups belong to a customer
                If iParentGroupID = 14 And iCust_id <> 2219 Then
                    Throw New Exception("This computer ties to GameStop group. Please select GameStop customer.")
                ElseIf iParentGroupID = 5 And iCust_id <> 2019 Then
                    Throw New Exception("This computer ties to CELL 1 STAGE 1 group. Please select ATCLE-AWS customer.")
                ElseIf iParentGroupID = 11 And iCust_id <> 2019 Then
                    Throw New Exception("This computer ties to CELL 2 STAGE 1 group. Please select ATCLE-AWS customer.")
                End If
                '**************************************
                'lan changed 10/20/2006: display device count on 2 label base on customer
                'Me.lblFileDevNum.Text = objWarehouse.GetDevCountFromLoadedFile(strPallett, iCust_id) 'lan add iCust_id
                If iCust_id = 2019 Then
                    Me.lblFileDevNum.Text = objWarehouse.GetDevCountFromLoadedFile(strPallett, iCust_id) 'lan add iCust_id
                ElseIf iCust_id = 2219 Then
                    Me.lblGSFileDevNum.Text = objWarehouse.GetDevCountFromLoadedFile(strPallett, iCust_id) 'lan add iCust_id
                End If
                '***************************************

                dt1 = objWarehouse.GetWarehousePalletInfo(strPallett)
                For Each R1 In dt1.Rows
                    If R1("WHPallet_NoBox") = 1 Then
                        Me.txtBoxSN.Enabled = False
                        Me.chkBoxEmpty.Enabled = False
                        iNoBoxForPallet = 1
                        Me.txtDevSN.Focus()
                    Else
                        Me.txtBoxSN.Enabled = True
                        Me.chkBoxEmpty.Enabled = True
                        iNoBoxForPallet = 0
                        Me.txtBoxSN.Focus()
                    End If

                    ''''''//added by Lan 12/06/2006
                    '''''If iCust_id = 2219 Then
                    '''''    iGS_WHP_FileQty = R1("WHP_FileQty")
                    '''''End If
                    ''''''//
                Next R1

                '//added by Lan 12/06/2006
                If iCust_id = 2219 Then
                    strChildPalletName = objWarehouse.GetOpenWarehouseChildPallet(strPallett)

                    'no open sub pallet
                    If strChildPalletName = "" Then
                        strChildPalletName = objWarehouse.CreateChildPallet(strPallett)
                    End If
                    Me.lblGSChildPallet_Name.Text = strChildPalletName
                End If
                '//

                RecalculateNumbers()
                If Me.iCust_id <> 2219 Then  '//added if by lan 12/06/2006
                    LoadDescrepancies()
                End If

                System.Windows.Forms.Application.DoEvents()











                ''dirs = Directory.GetFiles(strDirectory, strFileName)
                ''If dirs.Length > 0 Then
                ''    i = objWarehouse.LoadFile(strPallett, strFilePath, iNoBox)
                ''    If i = -1 Then      'Pallet was closed
                ''        Me.txtPallet.Text = ""
                ''        Throw New Exception("This Pallet has been closed. To rereceive delete it from the system first.")
                ''    Else                'Pallet was loaded but not closed yet
                ''        'Get Total Devices in the File loaded in to DB
                ''        Me.lblFileDevNum.Text = objWarehouse.GetDevCountFromLoadedFile(strPallett)

                ''        dt1 = objWarehouse.GetWarehousePalletInfo(strPallett)
                ''        For Each R1 In dt1.Rows
                ''            If R1("WHPallet_NoBox") = 1 Then
                ''                Me.chkBoxEmpty_Pallet.Checked = True
                ''                Me.txtBoxSN.Enabled = False
                ''                Me.chkBoxEmpty.Enabled = False
                ''                iNoBoxForPallet = 1
                ''                Me.txtDevSN.Focus()
                ''            Else
                ''                Me.chkBoxEmpty_Pallet.Checked = False
                ''                Me.txtBoxSN.Enabled = True
                ''                Me.chkBoxEmpty.Enabled = True
                ''                iNoBoxForPallet = 0
                ''                Me.txtBoxSN.Focus()
                ''            End If
                ''        Next R1

                ''        RecalculateNumbers()
                ''        'Me.lblAccepted.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 0)
                ''        'Me.lblRejected.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1)
                ''        'Me.lblRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)

                ''        LoadDescrepancies()

                ''        System.Windows.Forms.Application.DoEvents()
                ''    End If
                ''Else
                ''    Throw New Exception("File does not exist for the Pallet you have entered. Check the Pallet number and reinput.")
                ''End If
            Catch ex As Exception
                MessageBox.Show("txtPallet_KeyDown: " & Environment.NewLine & ex.Message, "Pallet Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtBoxSN.Text = ""
                Me.txtDevSN.Text = ""
                Me.lblFileDevNum.Text = ""
                Me.lblAccepted.Text = ""
                Me.lblRejected.Text = ""
                Me.lblRcvd.Text = ""
                Me.chkBoxEmpty.Checked = False
                Me.chkMultiPhone.Checked = False
                Me.txtPallet.Text = ""
                strPallett = ""
                Me.txtPallet.Focus()
            Finally
                dirs = Nothing
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
            '*********************************************************
        End Sub
        '*********************************************************
        Private Sub cmdPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPallet.Click
            OpenPallet()
        End Sub

        '*********************************************************
        Private Sub chkWrongSKU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWrongSKU.CheckedChanged
            If Me.strPallett = "" Then
                Me.chkWrongSKU.Checked = False
                Exit Sub
            End If
            If Me.chkWrongSKU.Checked = True Then
                iWrongSKU = 1
            Else
                iWrongSKU = 0
            End If
            If Me.txtBoxSN.Enabled = True And Me.txtBoxSN.Text = "" Then
                Me.txtBoxSN.Focus()
            Else
                Me.txtDevSN.Focus()
            End If
        End Sub
        '*********************************************************
        Private Sub txtPallet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPallet.KeyDown
            If e.KeyValue = 13 Then
                OpenPallet()
                'LoadDescrepancies()
            End If
        End Sub
        '*********************************************************
        Private Sub LoadDescrepancies()
            Dim dt1 As DataTable

            Try
                If Trim(strPallett) = "" Then
                    Exit Sub
                End If

                'select * from twarehousereceive where whpallet_id = 30 and whr_result = 1 order by whr_id desc
                dt1 = objWarehouse.LoadDockDescrepancies(strPallett, iCust_id)
                Me.tdgDescrep.ClearFields()


                If dt1.Rows.Count > 0 Then
                    Me.tdgDescrep.DataSource = dt1.DefaultView
                    SetGridProperties()
                    Me.cmdDeleteDescrap.Enabled = True
                    'Me.cmdDeletePallet.Enabled = True
                Else
                    Me.cmdDeleteDescrap.Enabled = False
                    'Me.cmdDeletePallet.Enabled = False
                    Me.cmdUndo.Enabled = False
                End If

            Catch ex As Exception
                Throw New Exception("frmQC.LoadQCHistory(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub
        '*********************************************************
        Private Sub SetGridProperties()
            Dim iNumOfColumns As Integer = Me.tdgDescrep.Columns.Count
            Dim i As Integer


            With tdgDescrep
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(7).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(8).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(9).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths

                .Splits(0).DisplayColumns(1).Width = 97
                .Splits(0).DisplayColumns(2).Width = 97
                .Splits(0).DisplayColumns(3).Width = 92
                .Splits(0).DisplayColumns(4).Width = 155
                .Splits(0).DisplayColumns(5).Width = 106
                .Splits(0).DisplayColumns(6).Width = 60
                .Splits(0).DisplayColumns(7).Width = 62
                .Splits(0).DisplayColumns(8).Width = 52
                .Splits(0).DisplayColumns(9).Width = 127

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub

        '****************************************************************
        Private Sub cmdDeleteDescrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteDescrap.Click
            Dim i As Integer = 0
            Try
                If Me.tdgDescrep.Columns.Count = 0 Then
                    Exit Sub
                End If
                If CInt(Me.tdgDescrep.Columns("whr_id").Value) = 0 Then
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure you want to delete this Descrepancy?", "Delete Descrepancy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    i = objWarehouse.DeleteDescrepancy(CInt(Me.tdgDescrep.Columns("whr_id").Value), iCust_id) 'whr_id
                    RecalculateNumbers()
                    LoadDescrepancies()

                    If Me.txtBoxSN.Enabled = True Then
                        If Trim(Me.txtBoxSN.Text) = "" Then
                            Me.txtBoxSN.Focus()
                        Else
                            Me.txtDevSN.Focus()
                        End If
                    Else
                        Me.txtDevSN.Focus()
                    End If
                Else
                    Exit Sub
                End If
                '******************************************************
            Catch ex As Exception
                MsgBox("frmWarehouseRec.cmdDeleteDescrap_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Dock Receiving")
            End Try
        End Sub

        Private Sub cmdUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUndo.Click
            Dim i As Integer = 0
            Try
                If MessageBox.Show("Are you sure you want to undo the last rejected scan?", "Undo Last Scan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    If objWarehouse.Result = 1 Then
                        If objWarehouse.WHR_ID > 0 Then
                            i = objWarehouse.DeleteDescrepancy(objWarehouse.WHR_ID, iCust_id)
                            RecalculateNumbers()
                            LoadDescrepancies()
                            objWarehouse.WHR_ID = 0
                            objWarehouse.Result = 0
                            Me.cmdUndo.Enabled = False

                            If Me.txtBoxSN.Enabled = True Then
                                If Trim(Me.txtBoxSN.Text) = "" Then
                                    Me.txtBoxSN.Focus()
                                Else
                                    Me.txtDevSN.Focus()
                                End If
                            Else
                                Me.txtDevSN.Focus()
                            End If

                        End If
                    End If
                End If

            Catch ex As Exception
                MsgBox("frmWarehouseRec.cmdDeleteDescrap_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Dock Receiving")
            End Try

        End Sub

        Private Sub cmdDeletePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeletePallet.Click
            Dim i As Integer = 0

            Try
                i = objWarehouse.DeletePalletFromDockReceiving(Trim(InputBox("Input Pallet Number.", "Delete Pallet")), iCust_id)

                If i > 0 Then
                    MessageBox.Show("Pallet successfully deleted.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ClearControls()
                Else
                    MessageBox.Show("Pallet could not be deleted.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MsgBox("frmWarehouseRec.cmdDeletePallet_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Delete Pallet")
            End Try

        End Sub

        Private Sub chkVerifyHistory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVerifyHistory.CheckedChanged
            If chkVerifyHistory.Checked = True Then chkVerifyNew.Checked = False
        End Sub

        Private Sub chkVerifyNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVerifyNew.CheckedChanged
            If chkVerifyNew.Checked = True Then chkVerifyHistory.Checked = False
        End Sub


        '******************************* LAN ****************************************
        Private Sub cmdReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReject.Click
            Dim i As Integer = 0
            Dim strDeviceSN As String = ""

            If strPallett = "" Then
                MessageBox.Show("Please input a Pallet Name.", "Reject Device for Wrong SKU", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            strDeviceSN = Trim(InputBox("Please scan in the DEVICE IMEI."))

            If Len(strDeviceSN) = 0 Then
                MessageBox.Show("Invalid input of device IMEI.", "Input IMEI", MessageBoxButtons.OK)
                Exit Sub
            End If

            Try
                i = objWarehouse.RejectDeviceForWrongSKU(strDeviceSN, iCust_id, iParentGroupID)
                If i = 0 Then
                    MessageBox.Show("Device is not updated. Device may not exist.", "Reject Device for Wrong SKU", MessageBoxButtons.OK)
                Else
                    OpenPallet()
                End If

            Catch ex As Exception
                MsgBox("frmWarehouseRec.cmdReject_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Dock Receiving")
            End Try
        End Sub


        Private Sub chkMultiPhone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMultiPhone.CheckedChanged
            Try
                If strPallett = "" Then
                    Me.chkMultiPhone.Checked = False
                    Exit Sub
                End If

                If Me.chkMultiPhone.Checked Then
                    If Trim(Me.txtBoxSN.Text) = "" Then
                        MessageBox.Show("Please input Box Serial Number.", "Input Box Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.chkMultiPhone.Checked = False
                        Me.txtBoxSN.Focus()
                        Exit Sub
                    ElseIf Trim(Me.txtDevSN.Text) <> "" Then
                        MessageBox.Show("Please clear Device Serial Number.", "Input Device Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.chkMultiPhone.Checked = False
                        Me.txtDevSN.Focus()
                        Exit Sub
                    End If
                    Dim i As Integer = 0

                    '********************************************************
                    'Lan add 10/30/2006
                    Dim strBoxSN = UCase(Trim(Me.txtBoxSN.Text))
                    Dim strDevSN = UCase(Trim(Me.txtDevSN.Text))
                    '********************************************************
                    'lan add Cust_id, iDev_billcode
                    i = objWarehouse.ProcessSerialNumbers(iParentGroupID, iUserID, strPallett, strBoxSN, strDevSN, 0, iNoBoxForPallet, iWrongSKU, _
                                                          iCust_id, iDev_billcode, iDevNoSN, 1)

                    If objWarehouse.Result = 1 Then
                        Me.cmdUndo.Enabled = True
                    Else
                        Me.cmdUndo.Enabled = False
                    End If

                    RecalculateNumbers()

                    FormatControls(i)
                    Me.CheckNoSN.Checked = False
                    LoadDescrepancies()
                    Me.txtBoxSN.Focus()
                Else
                    If Me.txtBoxSN.Text = "" Then
                        Me.txtBoxSN.Focus()
                    ElseIf Me.txtDevSN.Text = "" Then
                        Me.txtDevSN.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("chkMultiPhone_CheckedChanged: " & Environment.NewLine & ex.Message, "Empty Box", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtBoxSN.Text = ""
                Me.txtDevSN.Text = ""
                Me.chkMultiPhone.Checked = False
                Me.CheckNoSN.Checked = False
                Me.txtBoxSN.Focus()
            End Try
        End Sub



        Private Sub cmdDeleteAccpeted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteAccpeted.Click

            Dim i As Integer = 0
            Dim strSN As String = ""

            strSN = Trim(InputBox("Input IMEI", "Input IMEI"))

            Try
                If strSN = "" Then
                    MessageBox.Show("", "Input IMEI", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Else
                    'i = objWarehouse.DeleteAcceptedDeviceFromWHReceive(strPallett, strSN, iCust_id)
                End If

            Catch ex As Exception
            Finally
            End Try
        End Sub

        '****************************************************************
        'lan add
        '****************************************************************
        Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectionChangeCommitted

            If (Me.cmbCustomer.SelectedValue = 2219 And iParentGroupID <> 14) Or _
            (Me.cmbCustomer.SelectedValue = 2019 And (iParentGroupID <> 5 Or iParentGroupID <> 11)) Then
                MessageBox.Show("This Computer is not mapped to selected customer. Receiving can not be done.")
                ClearControls()
                Exit Sub
            End If

            Me.iCust_id = Me.cmbCustomer.SelectedValue
            Me.lblGroup.Text = objWarehouse.GetGroupName(iParentGroupID)

            'Determine the customer and reset screen
            If Me.cmbCustomer.SelectedValue = 2219 Then   '(GAME STOP)
                iDev_billcode = 873  'refurished billcode
                Me.RadioGood.Checked = True
                Me.PanelOptions.Visible = False
                Me.PanelGSOption.Visible = True
                Me.PanelDevNoSN.Visible = True
                Me.PanelBOX.Visible = False
                Me.lblHeader.Text = "GAMESTOP RECEIVING"
                iNoBoxForPallet = 1
                Me.PanelGS.Visible = True
                Me.PanelATCLE.Visible = False

                Me.cmdChangeSN.Visible = True
                Me.cmdGetSNNotRec.Visible = True
                Me.cmdGetSubPallet.Visible = True
            Else                                            '(ATCLE)
                iDev_billcode = 0
                Me.PanelOptions.Visible = True
                Me.PanelGSOption.Visible = False
                Me.PanelDevNoSN.Visible = False
                Me.CheckNoSN.Checked = False
                Me.PanelBOX.Visible = True
                Me.lblHeader.Text = "ATCLE RECEIVING"
                iNoBoxForPallet = 0
                Me.PanelGS.Visible = False
                Me.PanelATCLE.Visible = True

                Me.cmdChangeSN.Visible = False
                Me.cmdGetSNNotRec.Visible = False
                Me.cmdGetSubPallet.Visible = False
            End If

            Me.txtPallet.Focus()
        End Sub

        '****************************************************************
        'lan add
        '****************************************************************
        Private Sub RadioGood_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioGood.CheckedChanged
            '''''If strPallett = "" Then
            '''''    Me.RadioGood.Checked = False
            '''''    Exit Sub
            '''''End If
            '''''If Me.RadioGood.Checked = True Then
            '''''    Me.iDev_billcode = 873  'refurbished billcode
            '''''Else
            '''''    Me.iDev_billcode = 0
            '''''End If
        End Sub

        '****************************************************************
        'lan add
        '****************************************************************
        Private Sub RadioBad_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioBad.CheckedChanged
            If strPallett = "" Then
                Me.RadioBad.Checked = False
                Exit Sub
            End If
            If Me.RadioBad.Checked = True Then
                Me.iDev_billcode = 874    'RUR - Return UnRepaired
            Else
                Me.iDev_billcode = 0
            End If
        End Sub
        Private Sub RadioScrap_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioScrap.CheckedChanged
            If strPallett = "" Then
                Me.RadioScrap.Checked = False
                Exit Sub
            End If
            If Me.RadioScrap.Checked = True Then
                Me.iDev_billcode = 875      'Scrap
            Else
                Me.iDev_billcode = 0
            End If
        End Sub
        Private Sub CheckNoLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckNoSN.CheckedChanged
            If strPallett = "" Then
                Me.CheckNoSN.Checked = False
                Me.txtPallet.Focus()
                Exit Sub
            End If
            If Me.txtDevSN.Text = "" Then
                Me.txtDevSN.Focus()
            End If
            If Me.CheckNoSN.Checked = True Then
                Me.iDevNoSN = 1
            Else
                Me.iDevNoSN = 0
            End If
        End Sub

        Private Sub cmdGetSNNotRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetSNNotRec.Click
            'Dim strPalletName As String = Trim(InputBox("Please Enter the Pallet Name:"))
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strPalletName As String = Trim(Me.txtPallet.Text)
            Dim frmReport As RptViewer
            Dim strSNs As String = ""

            Try
                If Me.cmbCustomer.SelectedValue = 0 Then
                    Exit Sub
                End If

                If Me.cmbCustomer.SelectedValue = 2219 Then
                    frmReport = New RptViewer("GS_SN not Line Received.rpt")
                    frmReport.Show()
                    frmReport.Refresh()
                ElseIf Me.cmbCustomer.SelectedValue = 2019 Then
                    If strPalletName <> "" And iCust_id > 0 Then
                        dt1 = objWarehouse.GetDeviceNotWarehouseRec(strPalletName, iCust_id)
                        If dt1.Rows.Count > 0 Then
                            For Each R1 In dt1.Rows
                                strSNs &= R1("WHP_PieceIdentifier") & Environment.NewLine
                            Next R1
                            'show list of SN
                            If strSNs <> "" Then
                                MessageBox.Show(strSNs, "Get SN have not yet Receive", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        End If
                    Else
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Get SN not in System", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(frmReport) Then
                    frmReport = Nothing
                End If
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                R1 = Nothing
                Me.txtDevSN.Focus()
            End Try
        End Sub

        '**************************************************************Lan 10/31/2006
        Private Sub cmdChangeSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeSN.Click
            Dim strOldSN As String = ""
            Dim strNewSN As String = ""
            Dim i As Integer = 0

            If strPallett = "" Then
                MessageBox.Show("Please input a Pallet.", "Change SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            strOldSN = UCase(Trim(InputBox("Please enter the old SN.")))
            strNewSN = UCase(Trim(InputBox("Please enter the new SN.")))

            If Len(strOldSN) = 0 Or Len(strNewSN) = 0 Then
                MessageBox.Show("Input a valid SN.", "Input SN", MessageBoxButtons.OK)
                Exit Sub
            End If

            Try
                i = objWarehouse.ChangeSN(strOldSN, strNewSN, Trim(Me.txtPallet.Text), iCust_id)

                If i = 0 Then
                    Throw New Exception("Can not update new serial number.")
                ElseIf i = -1 Then  'New SN exist in system
                    Throw New Exception("New serial number already exist.")
                ElseIf i = -2 Then  'Old SN does not exist in the system
                    Throw New Exception("Old SN does not exist in the system or it was already line received. Can not change SN of any device that has already been line received.")
                ElseIf i = -99 Then
                    Throw New Exception("New SN (" & strNewSN & ") already existed in the system with an open ship date. Try a different SN.")
                Else
                    MessageBox.Show("Update Sucessful.", "Change SN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Change SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.txtDevSN.Focus()
            End Try
        End Sub
        '**************************************************************Lan 10/31/2006

        Private Sub cmdReprintDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintDesc.Click
            Dim i As Integer = 0
            Try
                If Me.tdgDescrep.Columns.Count = 0 Then
                    Exit Sub
                End If
                If CInt(Me.tdgDescrep.Columns("whr_id").Value) = 0 Then
                    Exit Sub
                End If

                i = objWarehouse.ReprintDiscrepancy(CInt(Me.tdgDescrep.Columns("whr_id").Value), iCust_id, iParentGroupID)
                If Me.txtBoxSN.Enabled = True Then
                    If Trim(Me.txtBoxSN.Text) = "" Then
                        Me.txtBoxSN.Focus()
                    Else
                        Me.txtDevSN.Focus()
                    End If
                Else
                    Me.txtDevSN.Focus()
                End If

            Catch ex As Exception
                MsgBox("frmWarehouseRec.cmdReprintDesc_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Line Receiving")
            End Try
        End Sub

        '**************************************************************Lan 12/13/2006
        Private Sub cmdGetSubPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetSubPallet.Click
            'Dim strPallet As String = ""
            'Dim strDisplay As String = ""
            'Dim dt1 As DataTable
            'Dim R1 As DataRow

            'Try
            '    strPallet = InputBox("Enter the Parent pallet:")
            '    If strPallet = "" Then
            '        Exit Sub
            '    Else
            '        dt1 = Me.objWarehouse.GetChildPallets(strPallet)
            '        If dt1.Rows.Count > 0 Then
            '            Me.lstChildPallet.Items.Clear()
            '            Me.lstChildPallet.Refresh()
            '            For Each R1 In dt1.Rows
            '                strDisplay = R1("WHPallet_Number") & "      " & R1("WHP_CountedQty")
            '                If R1("WHPalletClosed") = 1 Then
            '                    strDisplay &= "      CLOSED"
            '                Else
            '                    strDisplay &= "      OPEN"
            '                End If
            '                Me.lstChildPallet.Items.Add(strDisplay)
            '            Next R1
            '            Me.lstChildPallet.Visible = True
            '        Else
            '            Me.lstChildPallet.Visible = False
            '            MessageBox.Show("No subpallet for this main pallet.", "Get sub-pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            '        End If
            '    End If
            '    '******************************
            '    'set focust
            '    If Me.txtPallet.Text = "" Then
            '        Me.txtPallet.Focus()
            '    Else
            '        Me.txtDevSN.Focus()
            '    End If
            '    '******************************
            'Catch ex As Exception
            '    MsgBox("frmWarehouseRec.cmdGetSubPallet_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Line Receiving")
            'Finally
            '    R1 = Nothing
            '    If Not IsNothing(dt1) Then
            '        dt1.Dispose()
            '        dt1 = Nothing
            '    End If
            'End Try


            Dim frmReport As RptViewer
            Try
                frmReport = New RptViewer("GS_GetSubPallet.rpt")
                frmReport.Show()
                frmReport.Refresh()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                frmReport = Nothing
            End Try

        End Sub

        Private Sub cmdChangePalletModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangePalletModel.Click
            Dim i As Integer = 0
            Dim objChangeModel As Object

            Try
                If Me.cmbCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select Customer.", "Change Pallet Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.cmbCustomer.Focus()
                    Exit Sub
                End If

                objChangeModel = New frmChangePalletModel(Me.cmbCustomer.SelectedValue)
                With objChangeModel
                    .ShowDialog()
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Change Pallet Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                objChangeModel = Nothing
            End Try
        End Sub



    End Class
End Namespace