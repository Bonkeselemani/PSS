Imports CrystalDecisions.CrystalReports.Engine
Imports eInfoDesigns.dbProvider.MySqlClient
Imports Microsoft.Data.Odbc

Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]
Imports System
Imports System.Data
Imports System.GC
Imports System.IO
Imports System.Data.OleDb

Imports System.Net
Imports System.Net.Dns



Namespace Gui.Receiving

    Public Class frmRecEdit
        Inherits System.Windows.Forms.Form

        Private dsCustomer As DataSet
        Private dtManufacturer, dtModel, dtLocation, dtWorkOrder, dtTray, dtDevice, dtUnship As DataTable
        Private chkDTworkorder, chkDTtray As DataSet
        Private r As DataRow
        Private xCount, valProduct As Integer
        Private valueCustomer, valueLocation, valueManufacturer, valueModel, intWorkOrder, intTray, intDevice As Int32
        Private oldWOmessage, oldCustomer, oldLocation, oldRefNum, oldPOnum, oldManuf, oldModel, oldManufWrty, oldDevice, oldLocText, oldModelText As String

        Private tmpTrayID As Long
        Private tmpDeviceID As Long
        Private txtSerial As String
        Private _device As Device = Nothing
        Private _tray As DataTable = Nothing

        Private highPF As Long
        Private highRA As Long
        Private mTray As Long


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
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rbWorkOrder As System.Windows.Forms.RadioButton
        Friend WithEvents rbTray As System.Windows.Forms.RadioButton
        Friend WithEvents txtSelect As System.Windows.Forms.TextBox
        Friend WithEvents tbWorkOrder As System.Windows.Forms.TabPage
        Friend WithEvents tbTray As System.Windows.Forms.TabPage
        Friend WithEvents tbDevice As System.Windows.Forms.TabPage
        Friend WithEvents tbCtrl As System.Windows.Forms.TabControl
        Friend WithEvents grpWOLocation As System.Windows.Forms.GroupBox
        Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents btnLocation As System.Windows.Forms.Button
        Friend WithEvents grpWOMemo As System.Windows.Forms.GroupBox
        Friend WithEvents txtWOmessage As System.Windows.Forms.TextBox
        Friend WithEvents lblWOmsg As System.Windows.Forms.Label
        Friend WithEvents btnMemo As System.Windows.Forms.Button
        Friend WithEvents grpWORefNum As System.Windows.Forms.GroupBox
        Friend WithEvents lblRefNum As System.Windows.Forms.Label
        Friend WithEvents txtRefNum As System.Windows.Forms.TextBox
        Friend WithEvents btnRefNum As System.Windows.Forms.Button
        Friend WithEvents lblPOnum As System.Windows.Forms.Label
        Friend WithEvents txtPOnum As System.Windows.Forms.TextBox
        Friend WithEvents btnPOnum As System.Windows.Forms.Button
        Friend WithEvents lblManuf As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents cboManuf As System.Windows.Forms.ComboBox
        Friend WithEvents cboModel As System.Windows.Forms.ComboBox
        Friend WithEvents btnModel As System.Windows.Forms.Button
        Friend WithEvents lblManufWrty As System.Windows.Forms.Label
        Friend WithEvents txtManufWrty As System.Windows.Forms.TextBox
        Friend WithEvents btnManufWrty As System.Windows.Forms.Button
        Friend WithEvents lblDelDevice As System.Windows.Forms.Label
        Friend WithEvents btnDelDevice As System.Windows.Forms.Button
        Friend WithEvents grpWOPOnum As System.Windows.Forms.GroupBox
        Friend WithEvents grpTrayModel As System.Windows.Forms.GroupBox
        Friend WithEvents grpDeviceManufWrty As System.Windows.Forms.GroupBox
        Friend WithEvents grpDeviceDeleteDevice As System.Windows.Forms.GroupBox
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lstTray As System.Windows.Forms.ListBox
        Friend WithEvents lstDevice As System.Windows.Forms.ListBox
        Friend WithEvents txtDelDevice As System.Windows.Forms.TextBox
        Friend WithEvents lblNarrative As System.Windows.Forms.Label
        Friend WithEvents tbShipping As System.Windows.Forms.TabPage
        Friend WithEvents rbShipping As System.Windows.Forms.RadioButton
        Friend WithEvents lstDeviceShip As System.Windows.Forms.ListBox
        Friend WithEvents btnUnShip As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents grpDeviceShip As System.Windows.Forms.GroupBox
        Friend WithEvents txtUnshipDevice As System.Windows.Forms.TextBox
        Friend WithEvents grpTrayLocation As System.Windows.Forms.GroupBox
        Friend WithEvents cboTrayLocation As System.Windows.Forms.ComboBox
        Friend WithEvents lblTLocation As System.Windows.Forms.Label
        Friend WithEvents btnTLoc As System.Windows.Forms.Button
        Friend WithEvents grpDeviceInsertDevice As System.Windows.Forms.GroupBox
        Friend WithEvents btnInsDevice As System.Windows.Forms.Button
        Friend WithEvents txtInsDevice As System.Windows.Forms.TextBox
        Friend WithEvents lblInsDevice As System.Windows.Forms.Label
        Friend WithEvents cboRecType As System.Windows.Forms.ComboBox
        Friend WithEvents lblRecType As System.Windows.Forms.Label
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents btnReprintReceiving As System.Windows.Forms.Button
        Friend WithEvents btnReprintShipping As System.Windows.Forms.Button
        Friend WithEvents tbDeviceDelete As System.Windows.Forms.TabPage
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents tdbGrid2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnDeleteNoTray As System.Windows.Forms.Button
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents btnPrintManDetail As System.Windows.Forms.Button
        Friend WithEvents txtLocation As System.Windows.Forms.TextBox
        Friend WithEvents txtDelete As System.Windows.Forms.TextBox
        Friend WithEvents txtUnshiplbl As System.Windows.Forms.TextBox
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents txtDelDevLoc As System.Windows.Forms.TextBox
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents Button5 As System.Windows.Forms.Button
        Friend WithEvents Button6 As System.Windows.Forms.Button
        Friend WithEvents Button7 As System.Windows.Forms.Button
        Friend WithEvents Button8 As System.Windows.Forms.Button
        Friend WithEvents Button9 As System.Windows.Forms.Button
        Friend WithEvents Button10 As System.Windows.Forms.Button
        Friend WithEvents btnHighPFRA As System.Windows.Forms.Button
        Friend WithEvents Button11 As System.Windows.Forms.Button
        Friend WithEvents Button12 As System.Windows.Forms.Button
        Friend WithEvents Button13 As System.Windows.Forms.Button
        Friend WithEvents btnCellUpdate As System.Windows.Forms.Button
        Friend WithEvents Button14 As System.Windows.Forms.Button
        Friend WithEvents btnInvoiceModification As System.Windows.Forms.Button
        Friend WithEvents Button15 As System.Windows.Forms.Button
        Friend WithEvents Button16 As System.Windows.Forms.Button
        Friend WithEvents Button17 As System.Windows.Forms.Button
        Friend WithEvents Button18 As System.Windows.Forms.Button
        Friend WithEvents Button19 As System.Windows.Forms.Button
        Friend WithEvents btnCreateNavisionFile As System.Windows.Forms.Button
        Friend WithEvents Button20 As System.Windows.Forms.Button
        Friend WithEvents Button21 As System.Windows.Forms.Button
        Friend WithEvents Button22 As System.Windows.Forms.Button
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents Button24 As System.Windows.Forms.Button
        Friend WithEvents Button25 As System.Windows.Forms.Button
        Friend WithEvents Button26 As System.Windows.Forms.Button
        Friend WithEvents Button27 As System.Windows.Forms.Button
        Friend WithEvents btnUpdatePricing As System.Windows.Forms.Button
        Friend WithEvents Button28 As System.Windows.Forms.Button
        Friend WithEvents Button29 As System.Windows.Forms.Button
        Friend WithEvents Button30 As System.Windows.Forms.Button
        Friend WithEvents Button31 As System.Windows.Forms.Button
        Friend WithEvents Button32 As System.Windows.Forms.Button
        Friend WithEvents btnUpload As System.Windows.Forms.Button
        Friend WithEvents Button33 As System.Windows.Forms.Button
        Friend WithEvents Button34 As System.Windows.Forms.Button
        Friend WithEvents AdminFunc As System.Windows.Forms.TabPage
        Friend WithEvents Button23 As System.Windows.Forms.Button
        Friend WithEvents btnLoadUSAMobilityData As System.Windows.Forms.Button
        Friend WithEvents Button35 As System.Windows.Forms.Button
        Friend WithEvents txtWo As System.Windows.Forms.TextBox
        Friend WithEvents lstCap As System.Windows.Forms.ListBox
        Friend WithEvents Button36 As System.Windows.Forms.Button
        Friend WithEvents btnUpdateAveragePriceOnly As System.Windows.Forms.Button
        Friend WithEvents Button38 As System.Windows.Forms.Button
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnLoadTechPSSI As System.Windows.Forms.Button
        Friend WithEvents btnLoadTemp As System.Windows.Forms.Button
        Friend WithEvents tbEndUser As System.Windows.Forms.TabPage
        Friend WithEvents Button41 As System.Windows.Forms.Button
        Friend WithEvents Button37 As System.Windows.Forms.Button
        Friend WithEvents btnVerizon As System.Windows.Forms.Button
        Friend WithEvents cmdDelTrayDev As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRecEdit))
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rbShipping = New System.Windows.Forms.RadioButton()
            Me.txtSelect = New System.Windows.Forms.TextBox()
            Me.rbTray = New System.Windows.Forms.RadioButton()
            Me.rbWorkOrder = New System.Windows.Forms.RadioButton()
            Me.tbCtrl = New System.Windows.Forms.TabControl()
            Me.tbWorkOrder = New System.Windows.Forms.TabPage()
            Me.grpWOPOnum = New System.Windows.Forms.GroupBox()
            Me.btnPOnum = New System.Windows.Forms.Button()
            Me.txtPOnum = New System.Windows.Forms.TextBox()
            Me.lblPOnum = New System.Windows.Forms.Label()
            Me.grpWORefNum = New System.Windows.Forms.GroupBox()
            Me.btnRefNum = New System.Windows.Forms.Button()
            Me.txtRefNum = New System.Windows.Forms.TextBox()
            Me.lblRefNum = New System.Windows.Forms.Label()
            Me.grpWOMemo = New System.Windows.Forms.GroupBox()
            Me.btnMemo = New System.Windows.Forms.Button()
            Me.txtWOmessage = New System.Windows.Forms.TextBox()
            Me.lblWOmsg = New System.Windows.Forms.Label()
            Me.grpWOLocation = New System.Windows.Forms.GroupBox()
            Me.txtLocation = New System.Windows.Forms.TextBox()
            Me.btnLocation = New System.Windows.Forms.Button()
            Me.cboLocation = New System.Windows.Forms.ComboBox()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.AdminFunc = New System.Windows.Forms.TabPage()
            Me.btnVerizon = New System.Windows.Forms.Button()
            Me.Button37 = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnLoadTemp = New System.Windows.Forms.Button()
            Me.btnLoadTechPSSI = New System.Windows.Forms.Button()
            Me.btnUpdateAveragePriceOnly = New System.Windows.Forms.Button()
            Me.Button36 = New System.Windows.Forms.Button()
            Me.lstCap = New System.Windows.Forms.ListBox()
            Me.txtWo = New System.Windows.Forms.TextBox()
            Me.Button35 = New System.Windows.Forms.Button()
            Me.btnLoadUSAMobilityData = New System.Windows.Forms.Button()
            Me.tbDeviceDelete = New System.Windows.Forms.TabPage()
            Me.btnDeleteNoTray = New System.Windows.Forms.Button()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.tdbGrid2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tbTray = New System.Windows.Forms.TabPage()
            Me.Button41 = New System.Windows.Forms.Button()
            Me.btnReprintReceiving = New System.Windows.Forms.Button()
            Me.grpTrayLocation = New System.Windows.Forms.GroupBox()
            Me.cboTrayLocation = New System.Windows.Forms.ComboBox()
            Me.lblTLocation = New System.Windows.Forms.Label()
            Me.btnTLoc = New System.Windows.Forms.Button()
            Me.lstTray = New System.Windows.Forms.ListBox()
            Me.grpTrayModel = New System.Windows.Forms.GroupBox()
            Me.btnModel = New System.Windows.Forms.Button()
            Me.cboModel = New System.Windows.Forms.ComboBox()
            Me.cboManuf = New System.Windows.Forms.ComboBox()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.tbShipping = New System.Windows.Forms.TabPage()
            Me.btnPrintManDetail = New System.Windows.Forms.Button()
            Me.btnReprintShipping = New System.Windows.Forms.Button()
            Me.grpDeviceShip = New System.Windows.Forms.GroupBox()
            Me.txtUnshiplbl = New System.Windows.Forms.TextBox()
            Me.txtUnshipDevice = New System.Windows.Forms.TextBox()
            Me.btnUnShip = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lstDeviceShip = New System.Windows.Forms.ListBox()
            Me.tbDevice = New System.Windows.Forms.TabPage()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.grpDeviceInsertDevice = New System.Windows.Forms.GroupBox()
            Me.lblRecType = New System.Windows.Forms.Label()
            Me.cboRecType = New System.Windows.Forms.ComboBox()
            Me.txtInsDevice = New System.Windows.Forms.TextBox()
            Me.btnInsDevice = New System.Windows.Forms.Button()
            Me.lblInsDevice = New System.Windows.Forms.Label()
            Me.lstDevice = New System.Windows.Forms.ListBox()
            Me.grpDeviceDeleteDevice = New System.Windows.Forms.GroupBox()
            Me.txtDelDevLoc = New System.Windows.Forms.TextBox()
            Me.txtDelete = New System.Windows.Forms.TextBox()
            Me.txtDelDevice = New System.Windows.Forms.TextBox()
            Me.btnDelDevice = New System.Windows.Forms.Button()
            Me.lblDelDevice = New System.Windows.Forms.Label()
            Me.grpDeviceManufWrty = New System.Windows.Forms.GroupBox()
            Me.btnManufWrty = New System.Windows.Forms.Button()
            Me.txtManufWrty = New System.Windows.Forms.TextBox()
            Me.lblManufWrty = New System.Windows.Forms.Label()
            Me.tbEndUser = New System.Windows.Forms.TabPage()
            Me.Button38 = New System.Windows.Forms.Button()
            Me.Button34 = New System.Windows.Forms.Button()
            Me.Button33 = New System.Windows.Forms.Button()
            Me.btnUpload = New System.Windows.Forms.Button()
            Me.Button32 = New System.Windows.Forms.Button()
            Me.Button31 = New System.Windows.Forms.Button()
            Me.Button30 = New System.Windows.Forms.Button()
            Me.Button29 = New System.Windows.Forms.Button()
            Me.Button28 = New System.Windows.Forms.Button()
            Me.btnUpdatePricing = New System.Windows.Forms.Button()
            Me.Button27 = New System.Windows.Forms.Button()
            Me.Button26 = New System.Windows.Forms.Button()
            Me.Button25 = New System.Windows.Forms.Button()
            Me.Button24 = New System.Windows.Forms.Button()
            Me.Button23 = New System.Windows.Forms.Button()
            Me.Button22 = New System.Windows.Forms.Button()
            Me.Button21 = New System.Windows.Forms.Button()
            Me.Button20 = New System.Windows.Forms.Button()
            Me.btnCreateNavisionFile = New System.Windows.Forms.Button()
            Me.Button19 = New System.Windows.Forms.Button()
            Me.Button18 = New System.Windows.Forms.Button()
            Me.Button17 = New System.Windows.Forms.Button()
            Me.Button16 = New System.Windows.Forms.Button()
            Me.Button15 = New System.Windows.Forms.Button()
            Me.btnInvoiceModification = New System.Windows.Forms.Button()
            Me.Button14 = New System.Windows.Forms.Button()
            Me.btnCellUpdate = New System.Windows.Forms.Button()
            Me.Button13 = New System.Windows.Forms.Button()
            Me.Button12 = New System.Windows.Forms.Button()
            Me.Button11 = New System.Windows.Forms.Button()
            Me.btnHighPFRA = New System.Windows.Forms.Button()
            Me.Button10 = New System.Windows.Forms.Button()
            Me.Button9 = New System.Windows.Forms.Button()
            Me.Button8 = New System.Windows.Forms.Button()
            Me.Button7 = New System.Windows.Forms.Button()
            Me.Button6 = New System.Windows.Forms.Button()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.lblNarrative = New System.Windows.Forms.Label()
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.cmdDelTrayDev = New System.Windows.Forms.Button()
            Me.GroupBox1.SuspendLayout()
            Me.tbCtrl.SuspendLayout()
            Me.tbWorkOrder.SuspendLayout()
            Me.grpWOPOnum.SuspendLayout()
            Me.grpWORefNum.SuspendLayout()
            Me.grpWOMemo.SuspendLayout()
            Me.grpWOLocation.SuspendLayout()
            Me.AdminFunc.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.tbDeviceDelete.SuspendLayout()
            CType(Me.tdbGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbTray.SuspendLayout()
            Me.grpTrayLocation.SuspendLayout()
            Me.grpTrayModel.SuspendLayout()
            Me.tbShipping.SuspendLayout()
            Me.grpDeviceShip.SuspendLayout()
            Me.tbDevice.SuspendLayout()
            Me.grpDeviceInsertDevice.SuspendLayout()
            Me.grpDeviceDeleteDevice.SuspendLayout()
            Me.grpDeviceManufWrty.SuspendLayout()
            Me.tbEndUser.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbShipping, Me.txtSelect, Me.rbTray, Me.rbWorkOrder})
            Me.GroupBox1.Location = New System.Drawing.Point(32, 32)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(168, 112)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Select Device"
            '
            'rbShipping
            '
            Me.rbShipping.Location = New System.Drawing.Point(16, 56)
            Me.rbShipping.Name = "rbShipping"
            Me.rbShipping.Size = New System.Drawing.Size(104, 16)
            Me.rbShipping.TabIndex = 4
            Me.rbShipping.Text = "Shipping"
            '
            'txtSelect
            '
            Me.txtSelect.Location = New System.Drawing.Point(16, 80)
            Me.txtSelect.Name = "txtSelect"
            Me.txtSelect.Size = New System.Drawing.Size(136, 20)
            Me.txtSelect.TabIndex = 3
            Me.txtSelect.Text = ""
            '
            'rbTray
            '
            Me.rbTray.Location = New System.Drawing.Point(16, 40)
            Me.rbTray.Name = "rbTray"
            Me.rbTray.Size = New System.Drawing.Size(104, 16)
            Me.rbTray.TabIndex = 1
            Me.rbTray.Text = "Tray"
            '
            'rbWorkOrder
            '
            Me.rbWorkOrder.Location = New System.Drawing.Point(16, 24)
            Me.rbWorkOrder.Name = "rbWorkOrder"
            Me.rbWorkOrder.Size = New System.Drawing.Size(104, 16)
            Me.rbWorkOrder.TabIndex = 0
            Me.rbWorkOrder.Text = "Work Order"
            '
            'tbCtrl
            '
            Me.tbCtrl.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbWorkOrder, Me.AdminFunc, Me.tbDeviceDelete, Me.tbTray, Me.tbShipping, Me.tbDevice, Me.tbEndUser})
            Me.tbCtrl.Location = New System.Drawing.Point(208, 8)
            Me.tbCtrl.Name = "tbCtrl"
            Me.tbCtrl.SelectedIndex = 0
            Me.tbCtrl.Size = New System.Drawing.Size(520, 384)
            Me.tbCtrl.TabIndex = 1
            '
            'tbWorkOrder
            '
            Me.tbWorkOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpWOPOnum, Me.grpWORefNum, Me.grpWOMemo, Me.grpWOLocation})
            Me.tbWorkOrder.Location = New System.Drawing.Point(4, 22)
            Me.tbWorkOrder.Name = "tbWorkOrder"
            Me.tbWorkOrder.Size = New System.Drawing.Size(512, 358)
            Me.tbWorkOrder.TabIndex = 0
            Me.tbWorkOrder.Text = "WorkOrder"
            '
            'grpWOPOnum
            '
            Me.grpWOPOnum.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPOnum, Me.txtPOnum, Me.lblPOnum})
            Me.grpWOPOnum.Location = New System.Drawing.Point(16, 272)
            Me.grpWOPOnum.Name = "grpWOPOnum"
            Me.grpWOPOnum.Size = New System.Drawing.Size(432, 72)
            Me.grpWOPOnum.TabIndex = 9
            Me.grpWOPOnum.TabStop = False
            Me.grpWOPOnum.Text = "Purchase Number"
            '
            'btnPOnum
            '
            Me.btnPOnum.Location = New System.Drawing.Point(344, 40)
            Me.btnPOnum.Name = "btnPOnum"
            Me.btnPOnum.TabIndex = 2
            Me.btnPOnum.Text = "Update"
            '
            'txtPOnum
            '
            Me.txtPOnum.Location = New System.Drawing.Point(128, 24)
            Me.txtPOnum.Name = "txtPOnum"
            Me.txtPOnum.TabIndex = 1
            Me.txtPOnum.Text = ""
            '
            'lblPOnum
            '
            Me.lblPOnum.Location = New System.Drawing.Point(56, 24)
            Me.lblPOnum.Name = "lblPOnum"
            Me.lblPOnum.Size = New System.Drawing.Size(72, 16)
            Me.lblPOnum.TabIndex = 0
            Me.lblPOnum.Text = "PO Number:"
            Me.lblPOnum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grpWORefNum
            '
            Me.grpWORefNum.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefNum, Me.txtRefNum, Me.lblRefNum})
            Me.grpWORefNum.Location = New System.Drawing.Point(16, 192)
            Me.grpWORefNum.Name = "grpWORefNum"
            Me.grpWORefNum.Size = New System.Drawing.Size(432, 72)
            Me.grpWORefNum.TabIndex = 8
            Me.grpWORefNum.TabStop = False
            Me.grpWORefNum.Text = "Customer Reference Number"
            '
            'btnRefNum
            '
            Me.btnRefNum.Location = New System.Drawing.Point(344, 40)
            Me.btnRefNum.Name = "btnRefNum"
            Me.btnRefNum.TabIndex = 2
            Me.btnRefNum.Text = "Update"
            '
            'txtRefNum
            '
            Me.txtRefNum.Location = New System.Drawing.Point(128, 24)
            Me.txtRefNum.Name = "txtRefNum"
            Me.txtRefNum.Size = New System.Drawing.Size(208, 20)
            Me.txtRefNum.TabIndex = 1
            Me.txtRefNum.Text = ""
            '
            'lblRefNum
            '
            Me.lblRefNum.Location = New System.Drawing.Point(24, 30)
            Me.lblRefNum.Name = "lblRefNum"
            Me.lblRefNum.Size = New System.Drawing.Size(104, 9)
            Me.lblRefNum.TabIndex = 0
            Me.lblRefNum.Text = "Reference Number:"
            Me.lblRefNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grpWOMemo
            '
            Me.grpWOMemo.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnMemo, Me.txtWOmessage, Me.lblWOmsg})
            Me.grpWOMemo.Location = New System.Drawing.Point(16, 16)
            Me.grpWOMemo.Name = "grpWOMemo"
            Me.grpWOMemo.Size = New System.Drawing.Size(432, 80)
            Me.grpWOMemo.TabIndex = 7
            Me.grpWOMemo.TabStop = False
            Me.grpWOMemo.Text = "Memo"
            '
            'btnMemo
            '
            Me.btnMemo.Location = New System.Drawing.Point(344, 48)
            Me.btnMemo.Name = "btnMemo"
            Me.btnMemo.TabIndex = 4
            Me.btnMemo.Text = "Update"
            '
            'txtWOmessage
            '
            Me.txtWOmessage.Location = New System.Drawing.Point(128, 24)
            Me.txtWOmessage.Name = "txtWOmessage"
            Me.txtWOmessage.Size = New System.Drawing.Size(288, 20)
            Me.txtWOmessage.TabIndex = 3
            Me.txtWOmessage.Text = ""
            '
            'lblWOmsg
            '
            Me.lblWOmsg.Location = New System.Drawing.Point(16, 24)
            Me.lblWOmsg.Name = "lblWOmsg"
            Me.lblWOmsg.Size = New System.Drawing.Size(112, 16)
            Me.lblWOmsg.TabIndex = 2
            Me.lblWOmsg.Text = "WorkOrder Message:"
            Me.lblWOmsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grpWOLocation
            '
            Me.grpWOLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtLocation, Me.btnLocation, Me.cboLocation, Me.cboCustomer, Me.lblLocation, Me.lblCustomer})
            Me.grpWOLocation.Location = New System.Drawing.Point(16, 104)
            Me.grpWOLocation.Name = "grpWOLocation"
            Me.grpWOLocation.Size = New System.Drawing.Size(432, 80)
            Me.grpWOLocation.TabIndex = 6
            Me.grpWOLocation.TabStop = False
            Me.grpWOLocation.Text = "Parent/ Location"
            '
            'txtLocation
            '
            Me.txtLocation.Location = New System.Drawing.Point(344, 24)
            Me.txtLocation.Name = "txtLocation"
            Me.txtLocation.Size = New System.Drawing.Size(72, 20)
            Me.txtLocation.TabIndex = 11
            Me.txtLocation.Text = ""
            Me.txtLocation.Visible = False
            '
            'btnLocation
            '
            Me.btnLocation.Location = New System.Drawing.Point(344, 48)
            Me.btnLocation.Name = "btnLocation"
            Me.btnLocation.TabIndex = 10
            Me.btnLocation.Text = "Update"
            '
            'cboLocation
            '
            Me.cboLocation.Location = New System.Drawing.Point(128, 48)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(208, 21)
            Me.cboLocation.TabIndex = 9
            '
            'cboCustomer
            '
            Me.cboCustomer.Location = New System.Drawing.Point(128, 24)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(208, 21)
            Me.cboCustomer.TabIndex = 8
            '
            'lblLocation
            '
            Me.lblLocation.Location = New System.Drawing.Point(72, 48)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(56, 16)
            Me.lblLocation.TabIndex = 7
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(72, 24)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
            Me.lblCustomer.TabIndex = 6
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'AdminFunc
            '
            Me.AdminFunc.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnVerizon, Me.Button37, Me.Panel1, Me.btnUpdateAveragePriceOnly, Me.Button36, Me.lstCap, Me.txtWo, Me.Button35, Me.btnLoadUSAMobilityData})
            Me.AdminFunc.Location = New System.Drawing.Point(4, 22)
            Me.AdminFunc.Name = "AdminFunc"
            Me.AdminFunc.Size = New System.Drawing.Size(512, 358)
            Me.AdminFunc.TabIndex = 6
            Me.AdminFunc.Text = "Administrative Functions"
            '
            'btnVerizon
            '
            Me.btnVerizon.Location = New System.Drawing.Point(296, 8)
            Me.btnVerizon.Name = "btnVerizon"
            Me.btnVerizon.Size = New System.Drawing.Size(208, 23)
            Me.btnVerizon.TabIndex = 12
            Me.btnVerizon.Text = "Ameritech Verizon Load"
            '
            'Button37
            '
            Me.Button37.Location = New System.Drawing.Point(296, 328)
            Me.Button37.Name = "Button37"
            Me.Button37.Size = New System.Drawing.Size(208, 23)
            Me.Button37.TabIndex = 11
            Me.Button37.Text = "Load AMERITECH Data"
            Me.Button37.Visible = False
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLoadTemp, Me.btnLoadTechPSSI})
            Me.Panel1.Location = New System.Drawing.Point(16, 72)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(176, 80)
            Me.Panel1.TabIndex = 10
            '
            'btnLoadTemp
            '
            Me.btnLoadTemp.Location = New System.Drawing.Point(6, 47)
            Me.btnLoadTemp.Name = "btnLoadTemp"
            Me.btnLoadTemp.Size = New System.Drawing.Size(162, 23)
            Me.btnLoadTemp.TabIndex = 1
            Me.btnLoadTemp.Text = "Load from Temporary Files"
            '
            'btnLoadTechPSSI
            '
            Me.btnLoadTechPSSI.Location = New System.Drawing.Point(8, 8)
            Me.btnLoadTechPSSI.Name = "btnLoadTechPSSI"
            Me.btnLoadTechPSSI.Size = New System.Drawing.Size(160, 23)
            Me.btnLoadTechPSSI.TabIndex = 0
            Me.btnLoadTechPSSI.Text = "Load from Labor Distribution"
            '
            'btnUpdateAveragePriceOnly
            '
            Me.btnUpdateAveragePriceOnly.Location = New System.Drawing.Point(16, 40)
            Me.btnUpdateAveragePriceOnly.Name = "btnUpdateAveragePriceOnly"
            Me.btnUpdateAveragePriceOnly.Size = New System.Drawing.Size(176, 23)
            Me.btnUpdateAveragePriceOnly.TabIndex = 8
            Me.btnUpdateAveragePriceOnly.Text = "Update Average Cost Only"
            '
            'Button36
            '
            Me.Button36.Location = New System.Drawing.Point(16, 320)
            Me.Button36.Name = "Button36"
            Me.Button36.Size = New System.Drawing.Size(176, 23)
            Me.Button36.TabIndex = 6
            Me.Button36.Text = "Clear"
            '
            'lstCap
            '
            Me.lstCap.Location = New System.Drawing.Point(16, 216)
            Me.lstCap.Name = "lstCap"
            Me.lstCap.Size = New System.Drawing.Size(176, 95)
            Me.lstCap.TabIndex = 5
            '
            'txtWo
            '
            Me.txtWo.Location = New System.Drawing.Point(16, 160)
            Me.txtWo.Name = "txtWo"
            Me.txtWo.Size = New System.Drawing.Size(176, 20)
            Me.txtWo.TabIndex = 4
            Me.txtWo.Text = ""
            '
            'Button35
            '
            Me.Button35.Location = New System.Drawing.Point(16, 184)
            Me.Button35.Name = "Button35"
            Me.Button35.Size = New System.Drawing.Size(176, 23)
            Me.Button35.TabIndex = 3
            Me.Button35.Text = "DBR CapCode Values"
            '
            'btnLoadUSAMobilityData
            '
            Me.btnLoadUSAMobilityData.Location = New System.Drawing.Point(16, 8)
            Me.btnLoadUSAMobilityData.Name = "btnLoadUSAMobilityData"
            Me.btnLoadUSAMobilityData.Size = New System.Drawing.Size(176, 23)
            Me.btnLoadUSAMobilityData.TabIndex = 0
            Me.btnLoadUSAMobilityData.Text = "Load USA Mobility Data"
            '
            'tbDeviceDelete
            '
            Me.tbDeviceDelete.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteNoTray, Me.txtDeviceSN, Me.Label2, Me.tdbGrid2})
            Me.tbDeviceDelete.Location = New System.Drawing.Point(4, 22)
            Me.tbDeviceDelete.Name = "tbDeviceDelete"
            Me.tbDeviceDelete.Size = New System.Drawing.Size(512, 358)
            Me.tbDeviceDelete.TabIndex = 4
            Me.tbDeviceDelete.Text = "Device Delete (No Tray)"
            '
            'btnDeleteNoTray
            '
            Me.btnDeleteNoTray.Location = New System.Drawing.Point(384, 304)
            Me.btnDeleteNoTray.Name = "btnDeleteNoTray"
            Me.btnDeleteNoTray.TabIndex = 3
            Me.btnDeleteNoTray.Text = "Delete"
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.Location = New System.Drawing.Point(248, 16)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(120, 20)
            Me.txtDeviceSN.TabIndex = 2
            Me.txtDeviceSN.Text = ""
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(16, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(232, 16)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Enter the Device Serial Number for Deletion:"
            '
            'tdbGrid2
            '
            Me.tdbGrid2.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbGrid2.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdbGrid2.Location = New System.Drawing.Point(16, 48)
            Me.tdbGrid2.Name = "tdbGrid2"
            Me.tdbGrid2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbGrid2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbGrid2.PreviewInfo.ZoomFactor = 75
            Me.tdbGrid2.Size = New System.Drawing.Size(448, 240)
            Me.tdbGrid2.TabIndex = 0
            Me.tdbGrid2.Text = "C1TrueDBGrid1"
            Me.tdbGrid2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Alig" & _
            "nVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
            "ctorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
            "=""1""><Height>236</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSty" & _
            "le parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><F" & _
            "ilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=" & _
            """Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headi" & _
            "ng"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inacti" & _
            "veStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9""" & _
            " /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pa" & _
            "rent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0" & _
            ", 0, 444, 236</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderS" & _
            "tyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
            "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
            "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
            "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
            "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
            "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
            "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
            "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
            "</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 444, 236</" & _
            "ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle " & _
            "parent="""" me=""Style15"" /></Blob>"
            '
            'tbTray
            '
            Me.tbTray.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button41, Me.btnReprintReceiving, Me.grpTrayLocation, Me.lstTray, Me.grpTrayModel})
            Me.tbTray.Location = New System.Drawing.Point(4, 22)
            Me.tbTray.Name = "tbTray"
            Me.tbTray.Size = New System.Drawing.Size(512, 358)
            Me.tbTray.TabIndex = 1
            Me.tbTray.Text = "Tray"
            '
            'Button41
            '
            Me.Button41.Location = New System.Drawing.Point(256, 48)
            Me.Button41.Name = "Button41"
            Me.Button41.Size = New System.Drawing.Size(232, 24)
            Me.Button41.TabIndex = 14
            Me.Button41.Text = "REPRINT USA MOBILITY WORKSHEET"
            '
            'btnReprintReceiving
            '
            Me.btnReprintReceiving.Location = New System.Drawing.Point(256, 16)
            Me.btnReprintReceiving.Name = "btnReprintReceiving"
            Me.btnReprintReceiving.Size = New System.Drawing.Size(232, 24)
            Me.btnReprintReceiving.TabIndex = 13
            Me.btnReprintReceiving.Text = "REPRINT RECEIVING WORKSHEET"
            '
            'grpTrayLocation
            '
            Me.grpTrayLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTrayLocation, Me.lblTLocation, Me.btnTLoc})
            Me.grpTrayLocation.Location = New System.Drawing.Point(16, 248)
            Me.grpTrayLocation.Name = "grpTrayLocation"
            Me.grpTrayLocation.Size = New System.Drawing.Size(432, 64)
            Me.grpTrayLocation.TabIndex = 12
            Me.grpTrayLocation.TabStop = False
            Me.grpTrayLocation.Text = "Tray Location"
            Me.grpTrayLocation.Visible = False
            '
            'cboTrayLocation
            '
            Me.cboTrayLocation.Location = New System.Drawing.Point(120, 24)
            Me.cboTrayLocation.Name = "cboTrayLocation"
            Me.cboTrayLocation.Size = New System.Drawing.Size(208, 21)
            Me.cboTrayLocation.TabIndex = 13
            '
            'lblTLocation
            '
            Me.lblTLocation.Location = New System.Drawing.Point(64, 24)
            Me.lblTLocation.Name = "lblTLocation"
            Me.lblTLocation.Size = New System.Drawing.Size(56, 16)
            Me.lblTLocation.TabIndex = 12
            Me.lblTLocation.Text = "Location:"
            Me.lblTLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnTLoc
            '
            Me.btnTLoc.Location = New System.Drawing.Point(344, 32)
            Me.btnTLoc.Name = "btnTLoc"
            Me.btnTLoc.TabIndex = 14
            Me.btnTLoc.Text = "Update"
            '
            'lstTray
            '
            Me.lstTray.Location = New System.Drawing.Point(16, 16)
            Me.lstTray.Name = "lstTray"
            Me.lstTray.Size = New System.Drawing.Size(88, 95)
            Me.lstTray.TabIndex = 1
            '
            'grpTrayModel
            '
            Me.grpTrayModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnModel, Me.cboModel, Me.cboManuf, Me.lblModel, Me.lblManuf})
            Me.grpTrayModel.Location = New System.Drawing.Point(16, 136)
            Me.grpTrayModel.Name = "grpTrayModel"
            Me.grpTrayModel.Size = New System.Drawing.Size(432, 104)
            Me.grpTrayModel.TabIndex = 0
            Me.grpTrayModel.TabStop = False
            Me.grpTrayModel.Text = "Manufacturer/ Model"
            '
            'btnModel
            '
            Me.btnModel.Location = New System.Drawing.Point(344, 72)
            Me.btnModel.Name = "btnModel"
            Me.btnModel.TabIndex = 4
            Me.btnModel.Text = "Update"
            '
            'cboModel
            '
            Me.cboModel.Location = New System.Drawing.Point(120, 48)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(208, 21)
            Me.cboModel.TabIndex = 3
            '
            'cboManuf
            '
            Me.cboManuf.Location = New System.Drawing.Point(120, 24)
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.Size = New System.Drawing.Size(208, 21)
            Me.cboManuf.TabIndex = 2
            '
            'lblModel
            '
            Me.lblModel.Location = New System.Drawing.Point(16, 50)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(100, 16)
            Me.lblModel.TabIndex = 1
            Me.lblModel.Text = "Model:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblManuf
            '
            Me.lblManuf.Location = New System.Drawing.Point(16, 26)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(100, 16)
            Me.lblManuf.TabIndex = 0
            Me.lblManuf.Text = "Manufacturer:"
            Me.lblManuf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tbShipping
            '
            Me.tbShipping.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintManDetail, Me.btnReprintShipping, Me.grpDeviceShip, Me.lstDeviceShip})
            Me.tbShipping.Location = New System.Drawing.Point(4, 22)
            Me.tbShipping.Name = "tbShipping"
            Me.tbShipping.Size = New System.Drawing.Size(512, 358)
            Me.tbShipping.TabIndex = 3
            Me.tbShipping.Text = "Shipping"
            '
            'btnPrintManDetail
            '
            Me.btnPrintManDetail.Location = New System.Drawing.Point(256, 48)
            Me.btnPrintManDetail.Name = "btnPrintManDetail"
            Me.btnPrintManDetail.Size = New System.Drawing.Size(208, 23)
            Me.btnPrintManDetail.TabIndex = 6
            Me.btnPrintManDetail.Text = "PRINT MANIFEST DETAIL"
            '
            'btnReprintShipping
            '
            Me.btnReprintShipping.Location = New System.Drawing.Point(256, 16)
            Me.btnReprintShipping.Name = "btnReprintShipping"
            Me.btnReprintShipping.Size = New System.Drawing.Size(208, 24)
            Me.btnReprintShipping.TabIndex = 5
            Me.btnReprintShipping.Text = "REPRINT SHIPPING REPORTS"
            '
            'grpDeviceShip
            '
            Me.grpDeviceShip.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtUnshiplbl, Me.txtUnshipDevice, Me.btnUnShip, Me.Label1})
            Me.grpDeviceShip.Location = New System.Drawing.Point(16, 120)
            Me.grpDeviceShip.Name = "grpDeviceShip"
            Me.grpDeviceShip.Size = New System.Drawing.Size(432, 88)
            Me.grpDeviceShip.TabIndex = 4
            Me.grpDeviceShip.TabStop = False
            Me.grpDeviceShip.Text = "UnShip Device"
            '
            'txtUnshiplbl
            '
            Me.txtUnshiplbl.Location = New System.Drawing.Point(272, 24)
            Me.txtUnshiplbl.Name = "txtUnshiplbl"
            Me.txtUnshiplbl.Size = New System.Drawing.Size(56, 20)
            Me.txtUnshiplbl.TabIndex = 6
            Me.txtUnshiplbl.Text = "/* UNSHIP */"
            Me.txtUnshiplbl.Visible = False
            '
            'txtUnshipDevice
            '
            Me.txtUnshipDevice.Enabled = False
            Me.txtUnshipDevice.Location = New System.Drawing.Point(168, 24)
            Me.txtUnshipDevice.Name = "txtUnshipDevice"
            Me.txtUnshipDevice.TabIndex = 3
            Me.txtUnshipDevice.Text = ""
            '
            'btnUnShip
            '
            Me.btnUnShip.Location = New System.Drawing.Point(344, 56)
            Me.btnUnShip.Name = "btnUnShip"
            Me.btnUnShip.TabIndex = 2
            Me.btnUnShip.Text = "UnShip"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(16, 26)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(152, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "UnShip this Device:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lstDeviceShip
            '
            Me.lstDeviceShip.Location = New System.Drawing.Point(16, 8)
            Me.lstDeviceShip.Name = "lstDeviceShip"
            Me.lstDeviceShip.Size = New System.Drawing.Size(120, 95)
            Me.lstDeviceShip.TabIndex = 3
            '
            'tbDevice
            '
            Me.tbDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDelTrayDev, Me.btnReprint, Me.grpDeviceInsertDevice, Me.lstDevice, Me.grpDeviceDeleteDevice, Me.grpDeviceManufWrty})
            Me.tbDevice.Location = New System.Drawing.Point(4, 22)
            Me.tbDevice.Name = "tbDevice"
            Me.tbDevice.Size = New System.Drawing.Size(512, 358)
            Me.tbDevice.TabIndex = 2
            Me.tbDevice.Text = "Device"
            '
            'btnReprint
            '
            Me.btnReprint.Location = New System.Drawing.Point(256, 16)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(208, 24)
            Me.btnReprint.TabIndex = 6
            Me.btnReprint.Text = "REPRINT RECEIVING WORKSHEET"
            '
            'grpDeviceInsertDevice
            '
            Me.grpDeviceInsertDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRecType, Me.cboRecType, Me.txtInsDevice, Me.btnInsDevice, Me.lblInsDevice})
            Me.grpDeviceInsertDevice.Location = New System.Drawing.Point(16, 280)
            Me.grpDeviceInsertDevice.Name = "grpDeviceInsertDevice"
            Me.grpDeviceInsertDevice.Size = New System.Drawing.Size(432, 72)
            Me.grpDeviceInsertDevice.TabIndex = 5
            Me.grpDeviceInsertDevice.TabStop = False
            Me.grpDeviceInsertDevice.Text = "Insert Device"
            '
            'lblRecType
            '
            Me.lblRecType.Location = New System.Drawing.Point(64, 24)
            Me.lblRecType.Name = "lblRecType"
            Me.lblRecType.Size = New System.Drawing.Size(100, 16)
            Me.lblRecType.TabIndex = 5
            Me.lblRecType.Text = "Rec Type:"
            Me.lblRecType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboRecType
            '
            Me.cboRecType.Items.AddRange(New Object() {"FIRM", "COAM", "END USER", "PO"})
            Me.cboRecType.Location = New System.Drawing.Point(168, 24)
            Me.cboRecType.Name = "cboRecType"
            Me.cboRecType.Size = New System.Drawing.Size(100, 21)
            Me.cboRecType.TabIndex = 5
            '
            'txtInsDevice
            '
            Me.txtInsDevice.Location = New System.Drawing.Point(168, 48)
            Me.txtInsDevice.Name = "txtInsDevice"
            Me.txtInsDevice.TabIndex = 6
            Me.txtInsDevice.Text = ""
            '
            'btnInsDevice
            '
            Me.btnInsDevice.Location = New System.Drawing.Point(344, 40)
            Me.btnInsDevice.Name = "btnInsDevice"
            Me.btnInsDevice.TabIndex = 7
            Me.btnInsDevice.Text = "Insert"
            '
            'lblInsDevice
            '
            Me.lblInsDevice.Location = New System.Drawing.Point(16, 48)
            Me.lblInsDevice.Name = "lblInsDevice"
            Me.lblInsDevice.Size = New System.Drawing.Size(152, 16)
            Me.lblInsDevice.TabIndex = 0
            Me.lblInsDevice.Text = "Insert new Device:"
            Me.lblInsDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lstDevice
            '
            Me.lstDevice.Location = New System.Drawing.Point(16, 8)
            Me.lstDevice.Name = "lstDevice"
            Me.lstDevice.Size = New System.Drawing.Size(120, 95)
            Me.lstDevice.TabIndex = 2
            '
            'grpDeviceDeleteDevice
            '
            Me.grpDeviceDeleteDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDelDevLoc, Me.txtDelete, Me.txtDelDevice, Me.btnDelDevice, Me.lblDelDevice})
            Me.grpDeviceDeleteDevice.Location = New System.Drawing.Point(16, 200)
            Me.grpDeviceDeleteDevice.Name = "grpDeviceDeleteDevice"
            Me.grpDeviceDeleteDevice.Size = New System.Drawing.Size(432, 72)
            Me.grpDeviceDeleteDevice.TabIndex = 1
            Me.grpDeviceDeleteDevice.TabStop = False
            Me.grpDeviceDeleteDevice.Text = "Delete Device"
            '
            'txtDelDevLoc
            '
            Me.txtDelDevLoc.Location = New System.Drawing.Point(336, 24)
            Me.txtDelDevLoc.Name = "txtDelDevLoc"
            Me.txtDelDevLoc.Size = New System.Drawing.Size(56, 20)
            Me.txtDelDevLoc.TabIndex = 6
            Me.txtDelDevLoc.Text = ""
            Me.txtDelDevLoc.Visible = False
            '
            'txtDelete
            '
            Me.txtDelete.Location = New System.Drawing.Point(272, 24)
            Me.txtDelete.Name = "txtDelete"
            Me.txtDelete.Size = New System.Drawing.Size(56, 20)
            Me.txtDelete.TabIndex = 5
            Me.txtDelete.Text = "/* DELETE */"
            Me.txtDelete.Visible = False
            '
            'txtDelDevice
            '
            Me.txtDelDevice.Enabled = False
            Me.txtDelDevice.Location = New System.Drawing.Point(168, 24)
            Me.txtDelDevice.Name = "txtDelDevice"
            Me.txtDelDevice.TabIndex = 3
            Me.txtDelDevice.Text = ""
            '
            'btnDelDevice
            '
            Me.btnDelDevice.Location = New System.Drawing.Point(344, 40)
            Me.btnDelDevice.Name = "btnDelDevice"
            Me.btnDelDevice.TabIndex = 4
            Me.btnDelDevice.Text = "Delete"
            '
            'lblDelDevice
            '
            Me.lblDelDevice.Location = New System.Drawing.Point(16, 26)
            Me.lblDelDevice.Name = "lblDelDevice"
            Me.lblDelDevice.Size = New System.Drawing.Size(152, 16)
            Me.lblDelDevice.TabIndex = 0
            Me.lblDelDevice.Text = "Delete this Device:"
            Me.lblDelDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grpDeviceManufWrty
            '
            Me.grpDeviceManufWrty.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnManufWrty, Me.txtManufWrty, Me.lblManufWrty})
            Me.grpDeviceManufWrty.Location = New System.Drawing.Point(16, 112)
            Me.grpDeviceManufWrty.Name = "grpDeviceManufWrty"
            Me.grpDeviceManufWrty.Size = New System.Drawing.Size(432, 80)
            Me.grpDeviceManufWrty.TabIndex = 0
            Me.grpDeviceManufWrty.TabStop = False
            Me.grpDeviceManufWrty.Text = "Manufacturer Warranty"
            '
            'btnManufWrty
            '
            Me.btnManufWrty.Location = New System.Drawing.Point(344, 48)
            Me.btnManufWrty.Name = "btnManufWrty"
            Me.btnManufWrty.TabIndex = 2
            Me.btnManufWrty.Text = "Update"
            '
            'txtManufWrty
            '
            Me.txtManufWrty.Location = New System.Drawing.Point(168, 22)
            Me.txtManufWrty.Name = "txtManufWrty"
            Me.txtManufWrty.Size = New System.Drawing.Size(40, 20)
            Me.txtManufWrty.TabIndex = 1
            Me.txtManufWrty.Text = ""
            '
            'lblManufWrty
            '
            Me.lblManufWrty.Location = New System.Drawing.Point(40, 24)
            Me.lblManufWrty.Name = "lblManufWrty"
            Me.lblManufWrty.Size = New System.Drawing.Size(128, 16)
            Me.lblManufWrty.TabIndex = 0
            Me.lblManufWrty.Text = "Manufacturer Warranty:"
            Me.lblManufWrty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tbEndUser
            '
            Me.tbEndUser.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button38, Me.Button34, Me.Button33, Me.btnUpload, Me.Button32, Me.Button31, Me.Button30, Me.Button29, Me.Button28, Me.btnUpdatePricing, Me.Button27, Me.Button26, Me.Button25, Me.Button24, Me.Button23, Me.Button22, Me.Button21, Me.Button20, Me.btnCreateNavisionFile, Me.Button19, Me.Button18, Me.Button17, Me.Button16, Me.Button15, Me.btnInvoiceModification, Me.Button14, Me.btnCellUpdate, Me.Button13, Me.Button12, Me.Button11, Me.btnHighPFRA, Me.Button10, Me.Button9, Me.Button8, Me.Button7, Me.Button6, Me.Button5, Me.Button4, Me.Button3, Me.Button2, Me.Button1})
            Me.tbEndUser.Location = New System.Drawing.Point(4, 22)
            Me.tbEndUser.Name = "tbEndUser"
            Me.tbEndUser.Size = New System.Drawing.Size(512, 358)
            Me.tbEndUser.TabIndex = 5
            Me.tbEndUser.Text = "End User"
            '
            'Button38
            '
            Me.Button38.Location = New System.Drawing.Point(304, 88)
            Me.Button38.Name = "Button38"
            Me.Button38.Size = New System.Drawing.Size(200, 23)
            Me.Button38.TabIndex = 44
            Me.Button38.Text = "CellUpdate-ATCLE/AWS"
            Me.Button38.Visible = False
            '
            'Button34
            '
            Me.Button34.Location = New System.Drawing.Point(200, 184)
            Me.Button34.Name = "Button34"
            Me.Button34.Size = New System.Drawing.Size(112, 23)
            Me.Button34.TabIndex = 43
            Me.Button34.Text = "SKU Update 1 time"
            Me.Button34.Visible = False
            '
            'Button33
            '
            Me.Button33.Location = New System.Drawing.Point(304, 208)
            Me.Button33.Name = "Button33"
            Me.Button33.Size = New System.Drawing.Size(80, 23)
            Me.Button33.TabIndex = 42
            Me.Button33.Text = "UploadData"
            Me.Button33.Visible = False
            '
            'btnUpload
            '
            Me.btnUpload.Location = New System.Drawing.Point(200, 232)
            Me.btnUpload.Name = "btnUpload"
            Me.btnUpload.Size = New System.Drawing.Size(72, 23)
            Me.btnUpload.TabIndex = 41
            Me.btnUpload.Text = "UploadData"
            Me.btnUpload.Visible = False
            '
            'Button32
            '
            Me.Button32.Location = New System.Drawing.Point(304, 136)
            Me.Button32.Name = "Button32"
            Me.Button32.Size = New System.Drawing.Size(200, 24)
            Me.Button32.TabIndex = 40
            Me.Button32.Text = "Populate lchannel2frequency (1time)"
            Me.Button32.Visible = False
            '
            'Button31
            '
            Me.Button31.Location = New System.Drawing.Point(304, 112)
            Me.Button31.Name = "Button31"
            Me.Button31.Size = New System.Drawing.Size(200, 24)
            Me.Button31.TabIndex = 39
            Me.Button31.Text = "Insert Pricing - Navision to PSSI"
            Me.Button31.Visible = False
            '
            'Button30
            '
            Me.Button30.Location = New System.Drawing.Point(384, 208)
            Me.Button30.Name = "Button30"
            Me.Button30.Size = New System.Drawing.Size(120, 23)
            Me.Button30.TabIndex = 38
            Me.Button30.Text = "Edit tparttransaction"
            Me.Button30.Visible = False
            '
            'Button29
            '
            Me.Button29.Location = New System.Drawing.Point(208, 208)
            Me.Button29.Name = "Button29"
            Me.Button29.Size = New System.Drawing.Size(96, 23)
            Me.Button29.TabIndex = 37
            Me.Button29.Text = "AutoDisposition"
            Me.Button29.Visible = False
            '
            'Button28
            '
            Me.Button28.Location = New System.Drawing.Point(72, 136)
            Me.Button28.Name = "Button28"
            Me.Button28.Size = New System.Drawing.Size(232, 24)
            Me.Button28.TabIndex = 36
            Me.Button28.Text = "Update Pricing - Navision to PSSI Part 2"
            Me.Button28.Visible = False
            '
            'btnUpdatePricing
            '
            Me.btnUpdatePricing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdatePricing.Location = New System.Drawing.Point(72, 112)
            Me.btnUpdatePricing.Name = "btnUpdatePricing"
            Me.btnUpdatePricing.Size = New System.Drawing.Size(232, 24)
            Me.btnUpdatePricing.TabIndex = 35
            Me.btnUpdatePricing.Text = "Update Pricing - Navision to PSSI"
            Me.btnUpdatePricing.Visible = False
            '
            'Button27
            '
            Me.Button27.Location = New System.Drawing.Point(72, 256)
            Me.Button27.Name = "Button27"
            Me.Button27.Size = New System.Drawing.Size(128, 24)
            Me.Button27.TabIndex = 34
            Me.Button27.Text = "Pad for B Perry"
            Me.Button27.Visible = False
            '
            'Button26
            '
            Me.Button26.Location = New System.Drawing.Point(72, 232)
            Me.Button26.Name = "Button26"
            Me.Button26.Size = New System.Drawing.Size(128, 24)
            Me.Button26.TabIndex = 33
            Me.Button26.Text = "Update Decimals"
            Me.Button26.Visible = False
            '
            'Button25
            '
            Me.Button25.Location = New System.Drawing.Point(72, 280)
            Me.Button25.Name = "Button25"
            Me.Button25.Size = New System.Drawing.Size(128, 24)
            Me.Button25.TabIndex = 32
            Me.Button25.Text = "Jocelyn File"
            Me.Button25.Visible = False
            '
            'Button24
            '
            Me.Button24.Location = New System.Drawing.Point(72, 304)
            Me.Button24.Name = "Button24"
            Me.Button24.Size = New System.Drawing.Size(128, 24)
            Me.Button24.TabIndex = 31
            Me.Button24.Text = "Cretae Navision SKUs"
            Me.Button24.Visible = False
            '
            'Button23
            '
            Me.Button23.Location = New System.Drawing.Point(72, 328)
            Me.Button23.Name = "Button23"
            Me.Button23.Size = New System.Drawing.Size(128, 24)
            Me.Button23.TabIndex = 30
            Me.Button23.Text = "Load USA Mobility File"
            Me.Button23.Visible = False
            '
            'Button22
            '
            Me.Button22.Location = New System.Drawing.Point(184, 160)
            Me.Button22.Name = "Button22"
            Me.Button22.Size = New System.Drawing.Size(152, 24)
            Me.Button22.TabIndex = 29
            Me.Button22.Text = "Nicad Battery Labor Charge"
            Me.Button22.Visible = False
            '
            'Button21
            '
            Me.Button21.Location = New System.Drawing.Point(416, 328)
            Me.Button21.Name = "Button21"
            Me.Button21.Size = New System.Drawing.Size(88, 23)
            Me.Button21.TabIndex = 28
            Me.Button21.Text = "Crystal Project"
            Me.Button21.Visible = False
            '
            'Button20
            '
            Me.Button20.Location = New System.Drawing.Point(344, 328)
            Me.Button20.Name = "Button20"
            Me.Button20.Size = New System.Drawing.Size(72, 23)
            Me.Button20.TabIndex = 27
            Me.Button20.Text = "Admin Search"
            Me.Button20.Visible = False
            '
            'btnCreateNavisionFile
            '
            Me.btnCreateNavisionFile.Location = New System.Drawing.Point(72, 88)
            Me.btnCreateNavisionFile.Name = "btnCreateNavisionFile"
            Me.btnCreateNavisionFile.Size = New System.Drawing.Size(232, 24)
            Me.btnCreateNavisionFile.TabIndex = 26
            Me.btnCreateNavisionFile.Text = "Create Navision File"
            Me.btnCreateNavisionFile.Visible = False
            '
            'Button19
            '
            Me.Button19.Location = New System.Drawing.Point(72, 208)
            Me.Button19.Name = "Button19"
            Me.Button19.Size = New System.Drawing.Size(136, 23)
            Me.Button19.TabIndex = 25
            Me.Button19.Text = "Search Verizon"
            Me.Button19.Visible = False
            '
            'Button18
            '
            Me.Button18.Location = New System.Drawing.Point(272, 232)
            Me.Button18.Name = "Button18"
            Me.Button18.Size = New System.Drawing.Size(72, 23)
            Me.Button18.TabIndex = 24
            Me.Button18.Text = "CellUpdate"
            Me.Button18.Visible = False
            '
            'Button17
            '
            Me.Button17.Location = New System.Drawing.Point(336, 160)
            Me.Button17.Name = "Button17"
            Me.Button17.Size = New System.Drawing.Size(168, 24)
            Me.Button17.TabIndex = 23
            Me.Button17.Text = "Reclaimed LCD Service Move"
            Me.Button17.Visible = False
            '
            'Button16
            '
            Me.Button16.Location = New System.Drawing.Point(416, 304)
            Me.Button16.Name = "Button16"
            Me.Button16.Size = New System.Drawing.Size(88, 24)
            Me.Button16.TabIndex = 22
            Me.Button16.Text = "Create sum part numbers"
            Me.Button16.Visible = False
            '
            'Button15
            '
            Me.Button15.Location = New System.Drawing.Point(344, 304)
            Me.Button15.Name = "Button15"
            Me.Button15.Size = New System.Drawing.Size(72, 23)
            Me.Button15.TabIndex = 21
            Me.Button15.Text = "create dpart ytd table"
            Me.Button15.Visible = False
            '
            'btnInvoiceModification
            '
            Me.btnInvoiceModification.Location = New System.Drawing.Point(312, 184)
            Me.btnInvoiceModification.Name = "btnInvoiceModification"
            Me.btnInvoiceModification.Size = New System.Drawing.Size(192, 24)
            Me.btnInvoiceModification.TabIndex = 20
            Me.btnInvoiceModification.Text = "Modify Metrocall Invoice - Paging"
            Me.btnInvoiceModification.Visible = False
            '
            'Button14
            '
            Me.Button14.Location = New System.Drawing.Point(200, 256)
            Me.Button14.Name = "Button14"
            Me.Button14.Size = New System.Drawing.Size(72, 23)
            Me.Button14.TabIndex = 19
            Me.Button14.Text = "Update mcode"
            Me.Button14.Visible = False
            '
            'btnCellUpdate
            '
            Me.btnCellUpdate.Location = New System.Drawing.Point(72, 184)
            Me.btnCellUpdate.Name = "btnCellUpdate"
            Me.btnCellUpdate.Size = New System.Drawing.Size(128, 23)
            Me.btnCellUpdate.TabIndex = 18
            Me.btnCellUpdate.Text = "CellUpdate"
            Me.btnCellUpdate.Visible = False
            '
            'Button13
            '
            Me.Button13.Location = New System.Drawing.Point(256, 256)
            Me.Button13.Name = "Button13"
            Me.Button13.Size = New System.Drawing.Size(88, 23)
            Me.Button13.TabIndex = 17
            Me.Button13.Text = "mapCustBill"
            Me.Button13.Visible = False
            '
            'Button12
            '
            Me.Button12.Location = New System.Drawing.Point(16, 16)
            Me.Button12.Name = "Button12"
            Me.Button12.Size = New System.Drawing.Size(128, 23)
            Me.Button12.TabIndex = 16
            Me.Button12.Text = "Auto Bill"
            '
            'Button11
            '
            Me.Button11.Location = New System.Drawing.Point(416, 232)
            Me.Button11.Name = "Button11"
            Me.Button11.Size = New System.Drawing.Size(88, 23)
            Me.Button11.TabIndex = 15
            Me.Button11.Text = "Programming"
            Me.Button11.Visible = False
            '
            'btnHighPFRA
            '
            Me.btnHighPFRA.Location = New System.Drawing.Point(272, 328)
            Me.btnHighPFRA.Name = "btnHighPFRA"
            Me.btnHighPFRA.Size = New System.Drawing.Size(72, 23)
            Me.btnHighPFRA.TabIndex = 14
            Me.btnHighPFRA.Text = "Determine High PF and RA"
            Me.btnHighPFRA.Visible = False
            '
            'Button10
            '
            Me.Button10.Location = New System.Drawing.Point(200, 304)
            Me.Button10.Name = "Button10"
            Me.Button10.Size = New System.Drawing.Size(72, 23)
            Me.Button10.TabIndex = 13
            Me.Button10.Text = "update Prefix"
            Me.Button10.Visible = False
            '
            'Button9
            '
            Me.Button9.Location = New System.Drawing.Point(200, 280)
            Me.Button9.Name = "Button9"
            Me.Button9.Size = New System.Drawing.Size(72, 23)
            Me.Button9.TabIndex = 12
            Me.Button9.Text = "remove J"
            Me.Button9.Visible = False
            '
            'Button8
            '
            Me.Button8.Location = New System.Drawing.Point(200, 328)
            Me.Button8.Name = "Button8"
            Me.Button8.Size = New System.Drawing.Size(72, 23)
            Me.Button8.TabIndex = 11
            Me.Button8.Text = "Correct Date Codes"
            Me.Button8.Visible = False
            '
            'Button7
            '
            Me.Button7.Location = New System.Drawing.Point(344, 280)
            Me.Button7.Name = "Button7"
            Me.Button7.Size = New System.Drawing.Size(72, 23)
            Me.Button7.TabIndex = 10
            Me.Button7.Text = "Shipping Stage"
            Me.Button7.Visible = False
            '
            'Button6
            '
            Me.Button6.Location = New System.Drawing.Point(344, 256)
            Me.Button6.Name = "Button6"
            Me.Button6.Size = New System.Drawing.Size(72, 23)
            Me.Button6.TabIndex = 9
            Me.Button6.Text = "PreLoad"
            Me.Button6.Visible = False
            '
            'Button5
            '
            Me.Button5.Location = New System.Drawing.Point(344, 232)
            Me.Button5.Name = "Button5"
            Me.Button5.Size = New System.Drawing.Size(72, 23)
            Me.Button5.TabIndex = 7
            Me.Button5.Text = "Update Parts Codes"
            Me.Button5.Visible = False
            '
            'Button4
            '
            Me.Button4.Location = New System.Drawing.Point(256, 280)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(88, 23)
            Me.Button4.TabIndex = 6
            Me.Button4.Text = "New Tech Data Input"
            Me.Button4.Visible = False
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(416, 256)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(88, 23)
            Me.Button3.TabIndex = 5
            Me.Button3.Text = "HEX test"
            Me.Button3.Visible = False
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(416, 280)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(88, 23)
            Me.Button2.TabIndex = 4
            Me.Button2.Text = "RMA Definition"
            Me.Button2.Visible = False
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(72, 160)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(112, 23)
            Me.Button1.TabIndex = 3
            Me.Button1.Text = "End User Editing"
            Me.Button1.Visible = False
            '
            'lblNarrative
            '
            Me.lblNarrative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblNarrative.Location = New System.Drawing.Point(32, 152)
            Me.lblNarrative.Name = "lblNarrative"
            Me.lblNarrative.Size = New System.Drawing.Size(168, 240)
            Me.lblNarrative.TabIndex = 2
            '
            'cmdDelTrayDev
            '
            Me.cmdDelTrayDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDelTrayDev.ForeColor = System.Drawing.Color.Red
            Me.cmdDelTrayDev.Location = New System.Drawing.Point(240, 64)
            Me.cmdDelTrayDev.Name = "cmdDelTrayDev"
            Me.cmdDelTrayDev.Size = New System.Drawing.Size(232, 32)
            Me.cmdDelTrayDev.TabIndex = 17
            Me.cmdDelTrayDev.Text = "Delete All Devices in a Tray"
            '
            'frmRecEdit
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(790, 501)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNarrative, Me.tbCtrl, Me.GroupBox1})
            Me.Name = "frmRecEdit"
            Me.Text = "Receiving Edit/ Control"
            Me.GroupBox1.ResumeLayout(False)
            Me.tbCtrl.ResumeLayout(False)
            Me.tbWorkOrder.ResumeLayout(False)
            Me.grpWOPOnum.ResumeLayout(False)
            Me.grpWORefNum.ResumeLayout(False)
            Me.grpWOMemo.ResumeLayout(False)
            Me.grpWOLocation.ResumeLayout(False)
            Me.AdminFunc.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.tbDeviceDelete.ResumeLayout(False)
            CType(Me.tdbGrid2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbTray.ResumeLayout(False)
            Me.grpTrayLocation.ResumeLayout(False)
            Me.grpTrayModel.ResumeLayout(False)
            Me.tbShipping.ResumeLayout(False)
            Me.grpDeviceShip.ResumeLayout(False)
            Me.tbDevice.ResumeLayout(False)
            Me.grpDeviceInsertDevice.ResumeLayout(False)
            Me.grpDeviceDeleteDevice.ResumeLayout(False)
            Me.grpDeviceManufWrty.ResumeLayout(False)
            Me.tbEndUser.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmReceivingEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            '//Get Product_ID
            valProduct = 0  '//Initialize Value
reEnterProduct:
            '            valProduct = InputBox("Enter product type", "Choose Product", "1")
            valProduct = 1
            If valProduct < 1 Then
                GoTo reEnterProduct
            ElseIf IsNumeric(valProduct) = False Then
                GoTo reEnterProduct
            ElseIf CInt(valProduct) > 2 Then
                GoTo reEnterProduct
            End If

            HideAllGroups() '//Default setting - do not show elements until selection is made
            populateComboBoxes()

        End Sub

#Region " Complete "

        Private Sub txtSelect_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSelect.KeyDown

            If e.KeyCode = 13 Then
                HideAllGroups()

                '//Clear out listBoxes
                lstTray.Items.Clear()
                lstDevice.Items.Clear()
                lstDeviceShip.Items.Clear()

                populateComboBoxes()

                If Me.rbWorkOrder.Checked = True Then
                    ShowWOgroup()
                    tbCtrl.TabIndex = 1
                    tbCtrl.SelectedTab = tbWorkOrder
                ElseIf Me.rbTray.Checked = True Then
                    ShowWOgroup()
                    ShowTRAYgroup()
                    ShowDEVICEgroup()
                    tbCtrl.SelectedTab = tbTray
                ElseIf Me.rbShipping.Checked = True Then
                    ShowSHIPgroup()
                    tbCtrl.SelectedTab = tbShipping
                End If
                getOriginalValues()
            End If

        End Sub

        Private Sub HideAllGroups()

            '//Workorder Elements
            grpWOMemo.Visible = False
            grpWOLocation.Visible = False
            grpWORefNum.Visible = False
            grpWOPOnum.Visible = False
            '//Tray Elements
            grpTrayModel.Visible = False
            grpTrayLocation.Visible = False
            lstTray.Visible = False
            btnReprintReceiving.Visible = False
            '//Device Elements
            grpDeviceManufWrty.Visible = False
            grpDeviceDeleteDevice.Visible = False
            grpDeviceInsertDevice.Visible = False
            lstDevice.Visible = False
            btnReprint.Visible = False
            '//UnShip Elements
            Me.grpDeviceShip.Visible = False
            lstDeviceShip.Visible = False
            btnReprintShipping.Visible = False
            btnPrintManDetail.Visible = False
        End Sub

        Private Sub ShowWOgroup()
            grpWOMemo.Visible = True
            grpWOLocation.Visible = True
            grpWORefNum.Visible = True
            grpWOPOnum.Visible = True
        End Sub

        Private Sub ShowTRAYgroup()
            grpTrayModel.Visible = True
            grpTrayLocation.Visible = True
            lstTray.Visible = True
            btnReprintReceiving.Visible = True
        End Sub

        Private Sub ShowDEVICEgroup()
            grpDeviceManufWrty.Visible = True
            grpDeviceDeleteDevice.Visible = True
            grpDeviceInsertDevice.Visible = True
            lstDevice.Visible = True
            btnReprint.Visible = True
        End Sub

        Private Sub ShowSHIPgroup()
            grpDeviceShip.Visible = True
            lstDeviceShip.Visible = True
            btnReprintShipping.Visible = True
            btnPrintManDetail.Visible = True
        End Sub

        Private Sub rbWorkOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWorkOrder.CheckedChanged
            txtSelect.Text = ""
            txtSelect.Focus()
        End Sub

        Private Sub rbTray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTray.CheckedChanged
            txtSelect.Text = ""
            txtSelect.Focus()
        End Sub

        Private Sub rbDevice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            txtSelect.Focus()
        End Sub

#End Region

#Region " Create Datasets and Datatables "

        Private Sub createCustomerDataSet()
            Try
                Dim tmpCustomer As New PSS.Data.Production.tcustomer()
                dsCustomer = tmpCustomer.GetFirmOnlyList
                tmpCustomer = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createManufacturerDataTable()
            Try
                Dim tmpManufacturer As New PSS.Data.Production.Joins()
                dtManufacturer = tmpManufacturer.ManufListByDeviceType(valProduct)
                tmpManufacturer = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createModelDataTable()
            Try
                Dim tmpModel As New PSS.Data.Production.Joins()
                dtModel = tmpModel.ModelListByManufAndDeviceType(valProduct, valueManufacturer)
                tmpModel = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createLocationDataTable()
            Try
                Dim tmpLocation As New PSS.Data.Production.tlocation()
                dtLocation = tmpLocation.GetRowsByCustomerID(valueCustomer)
                tmpLocation = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

#End Region

#Region " Combo Box Related "

        Private Sub clearComboBoxes()

            cboCustomer.Text = ""
            cboCustomer.Items.Clear()
            cboLocation.Text = ""
            cboLocation.Items.Clear()
            cboManuf.Text = ""
            cboManuf.Items.Clear()
            cboModel.Text = ""
            cboModel.Items.Clear()

        End Sub

#Region " Populate Combo Boxes"

        Private Sub populateComboBoxes()

            Try
                dsCustomer.Clear()
                dtManufacturer.Clear()
                cboCustomer.Items.Clear()
                cboCustomer.Text = ""
                cboManuf.Items.Clear()
                cboManuf.Text = ""
            Catch exp As Exception
            End Try

            Try
                createCustomerDataSet()
                createManufacturerDataTable()

                assignDataSet2cbControl(Me.cboCustomer, dsCustomer, "tcustomer", "CUST_Name1")
                assignDataSet2cbControlTABLE(Me.cboManuf, dtManufacturer, "lmanuf", "Manuf_Desc")
            Catch exp As Exception
            End Try

        End Sub

        Private Sub assignDataSet2cbControl(ByVal ctrl As Control, ByVal ds As DataSet, ByVal tblName As String, ByVal fieldName As String)

            For xCount = 0 To ds.Tables(tblName).Rows.Count - 1
                r = ds.Tables(tblName).Rows(xCount)
                CType(ctrl, ComboBox).Items.Add(Trim(r(fieldName)))
            Next

        End Sub

        Private Sub assignDataSet2cbControlTABLE(ByVal ctrl As Control, ByVal dt As DataTable, ByVal tblName As String, ByVal fieldName As String)

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                CType(ctrl, ComboBox).Items.Add(Trim(r(fieldName)))
            Next

        End Sub

#End Region

#Region " Index Changed "

        Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

            valueCustomer = 0
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If Trim(r("CUST_Name1")) = Trim(cboCustomer.Text) Then
                    valueCustomer = r("CUST_ID")
                    'MsgBox("Customer value = " & valueCustomer)
                    Exit For
                End If
            Next
            If valueCustomer = 0 Then
                MsgBox("Customer value was not successfully set. Contact IT.", MsgBoxStyle.OKOnly)
                Exit Sub
            End If

            createLocationDataTable()
            cboLocation.Text = ""
            cboLocation.Items.Clear()
            assignDataSet2cbControlTABLE(Me.cboLocation, dtLocation, "tlocation", "Loc_Name")

            cboTrayLocation.Text = ""
            cboTrayLocation.Items.Clear()
            assignDataSet2cbControlTABLE(Me.cboTrayLocation, dtLocation, "tlocation", "Loc_Name")

        End Sub

        Private Sub cboManuf_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboManuf.SelectedIndexChanged

            valueManufacturer = 0
            For xCount = 0 To dtManufacturer.Rows.Count - 1
                r = dtManufacturer.Rows(xCount)
                If Trim(r("Manuf_Desc")) = Trim(cboManuf.Text) Then
                    valueManufacturer = r("Manuf_ID")
                    'MsgBox("Manufacturer value = " & valueManufacturer)
                    Exit For
                End If
            Next
            If valueManufacturer = 0 Then
                MsgBox("Manufacturer value was not successfully set. Contact IT.", MsgBoxStyle.OKOnly)
                Exit Sub
            End If

            cboModel.Text = ""
            cboModel.Items.Clear()
            createModelDataTable()
            assignDataSet2cbControlTABLE(Me.cboModel, dtModel, "tmodel", "Model_Desc")

        End Sub

        Private Sub cboModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModel.SelectedIndexChanged

            valueModel = 0
            For xCount = 0 To dtModel.Rows.Count - 1
                r = dtModel.Rows(xCount)
                If Trim(r("Model_Desc")) = Trim(cboModel.Text) Then
                    valueModel = r("Model_ID")
                    'MsgBox("Model value = " & valueModel)
                    Exit For
                End If
            Next
            If valueModel = 0 Then
                MsgBox("Model value was not successfully set. Contact IT.", MsgBoxStyle.OKOnly)
                Exit Sub
            End If

        End Sub

        Private Sub cboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged

            valueLocation = 0
            For xCount = 0 To dtLocation.Rows.Count - 1
                r = dtLocation.Rows(xCount)
                If Trim(r("Loc_Name")) = Trim(cboLocation.Text) Then
                    valueLocation = r("Loc_ID")
                    'MsgBox("Location value = " & valueLocation)
                    Exit For
                End If
            Next
            If valueLocation = 0 Then
                MsgBox("Location value was not successfully set. Contact IT.", MsgBoxStyle.OKOnly)
                Exit Sub
            End If

        End Sub

#End Region

#End Region

#Region " Clear Page Data"

        Private Sub clearTrayPageData()
            Me.cboManuf.Text = ""
            Me.cboModel.Text = ""
        End Sub

        Private Sub clearWorkOrderPageData()
            Me.txtWOmessage.Text = ""
            Me.cboCustomer.Text = ""
            Me.cboLocation.Text = ""
            Me.txtRefNum.Text = ""
            Me.txtPOnum.Text = ""
        End Sub

        Private Sub clearDevicePageData()
            Me.txtManufWrty.Text = ""
            Me.txtDelDevice.Text = ""
        End Sub

        Private Sub clearDeviceShipPageData()
            Me.txtUnshipDevice.Text = ""
        End Sub



#End Region

#Region " General "

        Private Sub getOriginalValues()

            Dim strSQL As String = ""
            Dim strParameterName As String = ""
            Dim strParameterValue As String = ""
            Dim tmpWO As Int32
            Dim tmpRS As New PSS.Data.Production.Joins()
            Dim dtRS As DataTable
            Dim drRS As DataRow

            Try
                dtTray.Clear()
                dtDevice.Clear()
            Catch exp As Exception
            End Try

            If Me.rbTray.Checked = True Then

                strSQL = "SELECT ttray.* FROM ttray WHERE "
                strParameterName = "ttray.Tray_ID = "
                strParameterValue = Trim(txtSelect.Text)

                If Len(Trim(strParameterName)) < 1 Then Exit Sub
                If Len(Trim(strParameterValue)) < 1 Then Exit Sub
                strSQL = strSQL & strParameterName & strParameterValue

                dtRS = tmpRS.OrderEntrySelect(strSQL)

                Try
                    tmpWO = 0
                    If dtRS.Rows.Count < 1 Then
                        MsgBox("No workorder/tray for this selection", MsgBoxStyle.OKOnly)
                        HideAllGroups()
                        txtSelect.Focus()
                        Exit Sub
                    End If
                    For xCount = 0 To dtRS.Rows.Count - 1
                        drRS = dtRS.Rows(xCount)
                        '//populate workorder
                        tmpWO = drRS("WO_ID")
                    Next
                Catch exp As Exception
                End Try

            ElseIf Me.rbWorkOrder.Checked = True Then
                tmpWO = Trim(txtSelect.Text)
            ElseIf Me.rbShipping.Checked = True Then
                populateShippingDevices()
                Exit Sub
            End If

            strSQL = "SELECT tworkorder.* FROM tworkorder WHERE "
            strParameterName = "tworkorder.WO_ID = "
            strParameterValue = Trim(tmpWO)

            If Len(Trim(strParameterName)) < 1 Then Exit Sub
            If Len(Trim(strParameterValue)) < 1 Then Exit Sub
            strSQL = strSQL & strParameterName & strParameterValue

            dtRS = tmpRS.OrderEntrySelect(strSQL)

            For xCount = 0 To dtRS.Rows.Count - 1
                drRS = dtRS.Rows(xCount)
                '//populate workorder
                intWorkOrder = drRS("WO_ID")
                oldWOmessage = ""
                If IsDBNull(drRS("WO_Memo")) = False Then oldWOmessage = drRS("WO_Memo")
                oldLocation = drRS("LOC_ID")
                oldRefNum = drRS("WO_CustWO")
                oldPOnum = ""
                If IsDBNull(drRS("PO_ID")) = False Then oldPOnum = drRS("PO_ID")
            Next

            '//This is new
            If Me.rbWorkOrder.Checked = True Then
                If Trim(intWorkOrder) <> Trim(txtSelect.Text) Then
                    MsgBox("No workorder/tray for this selection", MsgBoxStyle.OKOnly)
                    HideAllGroups()
                    txtSelect.Focus()
                    Exit Sub
                End If
            End If
            '//End of new

            '//Get Customer
            strSQL = "SELECT * FROM tlocation WHERE "
            strParameterName = "tlocation.Loc_ID = "
            strParameterValue = oldLocation
            strSQL = strSQL & strParameterName & strParameterValue

            Dim dttmpLoc As DataTable
            dttmpLoc = tmpRS.OrderEntrySelect(strSQL)
            For xCount = 0 To dttmpLoc.Rows.Count - 1
                r = dttmpLoc.Rows(xCount)
                If r("Loc_ID") = oldLocation Then
                    oldCustomer = r("Cust_ID")
                    Exit For
                End If
            Next

            Dim tCust As String

            '//Populate text boxes WorkOrder Level
            txtWOmessage.Text = ""
            cboCustomer.Text = ""
            cboLocation.Text = ""
            txtRefNum.Text = ""
            txtPOnum.Text = ""

            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If Trim(r("Cust_ID")) = oldCustomer Then
                    tCust = Trim(r("Cust_Name1"))
                    Exit For
                End If
            Next
            For xCount = 0 To cboCustomer.Items.Count - 1
                If cboCustomer.Items(xCount) = tCust Then
                    cboCustomer.SelectedIndex = xCount
                    Exit For
                End If
            Next

            Dim tLoc As String

            For xCount = 0 To dtLocation.Rows.Count - 1
                r = dtLocation.Rows(xCount)
                If Trim(r("Loc_ID")) = oldLocation Then
                    tLoc = Trim(r("loc_Name"))
                    oldLocText = Trim(r("LOC_Name"))
                    Exit For
                End If
            Next
            For xCount = 0 To cboLocation.Items.Count - 1
                If cboLocation.Items(xCount) = tLoc Then
                    cboLocation.SelectedIndex = xCount
                    Exit For
                End If
            Next

            Try
                txtWOmessage.Text = oldWOmessage
                txtRefNum.Text = oldRefNum
                txtPOnum.Text = oldPOnum
            Catch exp As Exception
            End Try

            '//Get Tray Numbers
            strSQL = "SELECT ttray.tray_ID, ttray.WO_ID FROM (tworkorder INNER JOIN ttray ON tworkorder.WO_ID = ttray.WO_ID) WHERE "
            strParameterName = "tworkorder.WO_ID = "
            strParameterValue = intWorkOrder
            strSQL = strSQL & strParameterName & strParameterValue

            dtTray = tmpRS.OrderEntrySelect(strSQL)
            For xCount = 0 To dtTray.Rows.Count - 1
                r = dtTray.Rows(xCount)
                lstTray.Items.Add(r("tray_ID"))
            Next
            ShowTRAYgroup()

            '            verifyInvoiceWorkorder(intWorkOrder)

        End Sub

        Private Sub populateDevices()

            Dim tmpRS As New PSS.Data.Production.Joins()
            Dim strSQL, strParameterName, strParameterValue As String
            Dim aTray As Int32 = Trim(lstTray.SelectedItem)

            lstDevice.Items.Clear()

            '//Get Device Numbers
            strSQL = "SELECT tdevice.Device_ID, tdevice.Device_SN, tdevice.Model_ID, tdevice.Tray_ID, tdevice.Device_ManufWrty, tdevice.Loc_ID FROM ((tworkorder INNER JOIN ttray ON tworkorder.WO_ID = ttray.WO_ID) INNER JOIN tdevice ON ttray.Tray_ID = tdevice.Tray_ID) WHERE "
            strParameterName = "ttray.Tray_ID = "
            strParameterValue = aTray
            strSQL = strSQL & strParameterName & strParameterValue

            dtDevice = tmpRS.OrderEntrySelect(strSQL)
            For xCount = 0 To dtDevice.Rows.Count - 1
                r = dtDevice.Rows(xCount)
                lstDevice.Items.Add(r("device_SN"))
            Next
            ShowDEVICEgroup()

        End Sub

        Private Sub populateShippingDevices()

            Dim tmpRS As New PSS.Data.Production.Joins()
            Dim strSQL, strParameterName, strParameterValue As String

            Me.lstDeviceShip.Items.Clear()

            '//Get Device Numbers
            strSQL = "SELECT tdevice.* FROM tdevice WHERE "
            strParameterName = "tdevice.Ship_ID = "
            strParameterValue = Trim(txtSelect.Text)

            strSQL = strSQL & strParameterName & strParameterValue & " AND not isnull(tdevice.Device_DateShip) ORDER BY tdevice.Device_SN"

            dtUnship = tmpRS.OrderEntrySelect(strSQL)
            For xCount = 0 To dtUnship.Rows.Count - 1
                r = dtUnship.Rows(xCount)
                Me.lstDeviceShip.Items.Add(r("device_SN"))
            Next
            ShowSHIPgroup()

        End Sub

        Private Sub lstTray_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstTray.SelectedIndexChanged

            clearDevicePageData()
            populateDevices()

            '//Get Tray Data
            Dim strSQl, strParameterName, strParameterValue As String
            Dim tmpRS As New PSS.Data.Production.Joins()
            Dim dtRS As DataTable
            Dim drRS As DataRow

            strSQl = "SELECT tdevice.* FROM tdevice WHERE "
            strParameterName = "tdevice.Tray_ID = "
            strParameterValue = Trim(lstTray.SelectedItem)

            If Len(Trim(strParameterName)) < 1 Then Exit Sub
            If Len(Trim(strParameterValue)) < 1 Then Exit Sub
            strSQl = strSQl & strParameterName & strParameterValue

            dtRS = tmpRS.OrderEntrySelect(strSQl)

            For xCount = 0 To dtRS.Rows.Count - 1
                drRS = dtRS.Rows(xCount)
                '//select model
                oldModel = drRS("Model_ID")
                Exit For
            Next

            '//Get Manufacturer
            strSQl = "SELECT * FROM tmodel WHERE "
            strParameterName = "tmodel.Model_ID = "
            strParameterValue = oldModel
            strSQl = strSQl & strParameterName & strParameterValue
            dtRS = tmpRS.OrderEntrySelect(strSQl)
            For xCount = 0 To dtRS.Rows.Count - 1
                drRS = dtRS.Rows(xCount)
                '//select Manufacturer ID
                oldManuf = drRS("Manuf_ID")
                oldModelText = drRS("Model_Desc")
                Exit For
            Next

            '//select Manufacturer on Page
            Dim tmpManufacturer As String
            For xCount = 0 To dtManufacturer.Rows.Count - 1
                r = dtManufacturer.Rows(xCount)
                If Trim(r("Manuf_ID")) = Trim(oldManuf) Then
                    tmpManufacturer = Trim(r("Manuf_Desc"))
                    Exit For
                End If
            Next
            For xCount = 0 To cboManuf.Items.Count - 1
                If Trim(cboManuf.Items(xCount)) = tmpManufacturer Then
                    cboManuf.SelectedIndex = xCount
                    Exit For
                End If
            Next

            '//select Model on Page
            Dim tmpModel As String
            For xCount = 0 To dtModel.Rows.Count - 1
                r = dtModel.Rows(xCount)
                If Trim(r("Model_ID")) = Trim(oldModel) Then
                    tmpModel = Trim(r("Model_Desc"))
                    Exit For
                End If
            Next
            For xCount = 0 To cboModel.Items.Count - 1
                If Trim(cboModel.Items(xCount)) = tmpModel Then
                    cboModel.SelectedIndex = xCount
                    Exit For
                End If
            Next

        End Sub

        Private Sub lstDevice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDevice.SelectedIndexChanged

            clearDevicePageData()

            '//Get Device Data
            Dim strSQl, strParameterName, strParameterValue As String
            Dim tmpRS As New PSS.Data.Production.Joins()
            Dim dtRS As DataTable
            Dim drRS As DataRow

            Dim tmpDevice As String

            For xCount = 0 To dtDevice.Rows.Count - 1
                drRS = dtDevice.Rows(xCount)
                '//select device
                If drRS("Device_SN") = lstDevice.SelectedItem Then
                    tmpDevice = drRS("Device_ID")
                    txtDelDevice.Text = lstDevice.SelectedItem
                    If IsDBNull(drRS("Device_ManufWrty")) = False Then
                        If drRS("Device_ManufWrty") = 1 Then
                            Me.txtManufWrty.Text = "S"
                            oldManufWrty = 1
                        ElseIf drRS("Device_ManufWrty") = 2 Then
                            Me.txtManufWrty.Text = "E"
                            oldManufWrty = 2
                        End If
                        Exit For
                    End If
                End If
            Next

        End Sub

        Private Sub txtSelect_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelect.TextChanged

            clearWorkOrderPageData()
            clearTrayPageData()
            clearDevicePageData()
            lstTray.Items.Clear()
            lstDevice.Items.Clear()

        End Sub

        Private Sub disableButtons()
            Me.btnDelDevice.Enabled = False
            Me.btnLocation.Enabled = False
            Me.btnManufWrty.Enabled = False
            Me.btnMemo.Enabled = False
            Me.btnModel.Enabled = False
            Me.btnPOnum.Enabled = False
            Me.btnRefNum.Enabled = False
        End Sub

        Private Sub enableButtons()
            Me.btnDelDevice.Enabled = True
            Me.btnLocation.Enabled = True
            Me.btnManufWrty.Enabled = True
            Me.btnMemo.Enabled = True
            Me.btnModel.Enabled = True
            Me.btnPOnum.Enabled = True
            Me.btnRefNum.Enabled = True
        End Sub

#End Region

#Region " Button Clicks - UPDATES "

        Private Sub btnMemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMemo.Click

            If IsDBNull(oldWOmessage) = True Then
                oldWOmessage = ""
            End If

            If Trim(oldWOmessage) = Trim(Me.txtWOmessage.Text) Then
                MsgBox("You can not update this value because it is not different from the original.", MsgBoxStyle.OKOnly, "CAN NOT UPDATE")
                Me.txtWOmessage.Focus()
                Exit Sub
            End If

            '//disable button until over
            btnMemo.Enabled = False

            Dim lblString As String

            lblString = "You are about to change the following element:" & vbCrLf & vbCrLf & _
            "WorkOrder Message from : " & vbCrLf & vbCrLf & _
            oldWOmessage & vbCrLf & vbCrLf & _
            "TO:" & vbCrLf & vbCrLf & _
            Me.txtWOmessage.Text & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Change WorkOrder Message")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update
                    If intWorkOrder > 0 Then
                        AuditCall("RecEdit_WO_message", intWorkOrder, Controls)
                        Try
                            Dim valWOmessage As String
                            Dim strSQL As String
                            If Len(Trim(Me.txtWOmessage.Text)) < 1 Then
                                valWOmessage = "Null"
                                strSQL = "UPDATE tworkorder SET tworkorder.WO_Memo = " & valWOmessage & " WHERE tworkorder.WO_ID = " & intWorkOrder
                            Else
                                valWOmessage = txtWOmessage.Text
                                strSQL = "UPDATE tworkorder SET tworkorder.WO_Memo = '" & valWOmessage & "' WHERE tworkorder.WO_ID = " & intWorkOrder
                            End If
                            Dim tmpUpdate As New PSS.Data.Production.tworkorder()
                            Dim valUpdate As Int32 = tmpUpdate.idTransaction(strSQL)
                            'set new value as oldwomessage
                            oldWOmessage = valWOmessage
                            lblNarrative.Text = ""
                            btnMemo.Enabled = True
                            Me.txtWOmessage.Focus()
                        Catch exp As Exception
                            MsgBox("Problem with the update of message has occurred with workorder number: " & intWorkOrder & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnMemo.Enabled = True
                            Me.txtWOmessage.Focus()
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnMemo.Enabled = True
                    Me.txtWOmessage.Text = oldWOmessage
                    Me.txtWOmessage.Focus()
                    Exit Sub
            End Select

        End Sub

        Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click

            Dim newLocText As String

            If IsDBNull(oldLocation) = True Then
                oldLocation = ""
                oldLocText = ""
            End If


            '//Get Location value
            Dim nvLocation As Int32
            txtLocation.Text = ""

            For xCount = 0 To dtLocation.Rows.Count - 1
                r = dtLocation.Rows(xCount)
                If Trim(cboLocation.Text) = Trim(r("Loc_Name")) Then
                    newLocText = r("Loc_Name")
                    nvLocation = r("Loc_ID")
                    txtLocation.Text = nvLocation
                    Exit For
                End If
            Next
            If nvLocation < 1 Then
                MsgBox("New location can not be assigned.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            If Trim(oldLocation) = Trim(nvLocation) Then
                MsgBox("You can not update this value because it is not different from the original.", MsgBoxStyle.OKOnly, "CAN NOT UPDATE")
                Me.cboLocation.Focus()
                Exit Sub
            End If

            '//disable button until over
            btnLocation.Enabled = False

            Dim lblString As String

            lblString = "You are about to change the following element:" & vbCrLf & vbCrLf & _
            "WorkOrder Location from : " & vbCrLf & vbCrLf & _
            oldLocText & vbCrLf & vbCrLf & _
            "TO:" & vbCrLf & vbCrLf & _
            newLocText & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Change WorkOrder Message")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update
                    If intWorkOrder > 0 Then
                        Try
                            Dim valLocation As String
                            Dim strSQL As String
                            AuditCall("RecEdit_WO_Location", intWorkOrder, Controls)
                            strSQL = "UPDATE tworkorder SET tworkorder.LOC_ID = " & nvLocation & " WHERE tworkorder.WO_ID = " & intWorkOrder
                            Dim tmpUpdate As New PSS.Data.Production.tworkorder()
                            Dim valUpdate As Int32 = tmpUpdate.idTransaction(strSQL)
                            'set new value as oldwomessage
                            oldLocation = nvLocation

                            '//Update devices
                            AuditCall("RecEdit_WO_Location_Devices", intWorkOrder, Controls)
                            strSQL = "UPDATE tdevice SET tdevice.LOC_ID = " & nvLocation & " WHERE tdevice.WO_ID = " & intWorkOrder
                            valUpdate = tmpUpdate.idTransaction(strSQL)

                            lblNarrative.Text = ""
                            btnLocation.Enabled = True
                            Me.cboLocation.Focus()
                        Catch exp As Exception
                            MsgBox("Problem with the update of location has occurred with workorder number: " & intWorkOrder & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnLocation.Enabled = True
                            Me.cboLocation.Focus()
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnLocation.Enabled = True
                    Me.cboLocation.Focus()
                    Exit Sub
            End Select

        End Sub

        Private Sub btnRefNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefNum.Click

            If IsDBNull(oldRefNum) = True Then
                oldRefNum = ""
            Else
                txtRefNum.Text = Trim(UCase(txtRefNum.Text))
            End If

            If Trim(oldRefNum) = Trim(Me.txtRefNum.Text) Then
                MsgBox("You can not update this value because it is not different from the original.", MsgBoxStyle.OKOnly, "CAN NOT UPDATE")
                Me.txtRefNum.Focus()
                Exit Sub
            End If

            If Len(Me.txtRefNum.Text) < 1 Then
                MsgBox("New Reference Number can not be assigned.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//disable button until over
            btnRefNum.Enabled = False

            Dim lblString As String

            lblString = "You are about to change the following element:" & vbCrLf & vbCrLf & _
            "Reference Number from : " & vbCrLf & vbCrLf & _
            oldRefNum & vbCrLf & vbCrLf & _
            "TO:" & vbCrLf & vbCrLf & _
            Me.txtRefNum.Text & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Change WorkOrder Message")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update
                    If intWorkOrder > 0 Then
                        Try
                            Dim valWOmessage As String
                            Dim strSQL As String
                            AuditCall("RecEdit_WO_refnum", intWorkOrder, Controls)
                            strSQL = "UPDATE tworkorder SET tworkorder.WO_CustWO = '" & Trim(txtRefNum.Text) & "' WHERE tworkorder.WO_ID = " & intWorkOrder
                            Dim tmpUpdate As New PSS.Data.Production.tworkorder()
                            Dim valUpdate As Int32 = tmpUpdate.idTransaction(strSQL)
                            'set new value as oldwomessage
                            oldRefNum = Me.txtRefNum.Text
                            lblNarrative.Text = ""
                            btnRefNum.Enabled = True
                            Me.txtRefNum.Focus()
                        Catch exp As Exception
                            MsgBox("Problem with the update of the customer reference number has occurred with workorder number: " & intWorkOrder & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnRefNum.Enabled = True
                            Me.txtRefNum.Focus()
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnRefNum.Enabled = True
                    Me.txtRefNum.Text = oldRefNum
                    Me.txtRefNum.Focus()
                    Exit Sub
            End Select

        End Sub

        Private Sub btnPOnum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPOnum.Click

            If IsDBNull(oldPOnum) = True Then
                oldPOnum = ""
            End If

            If Len(Trim(txtPOnum.Text)) < 1 Then
            Else
                If IsNumeric(Trim(txtPOnum.Text)) = False Then
                    MsgBox("PO Numbers must be numeric", MsgBoxStyle.OKOnly, "ERROR")
                    Me.txtPOnum.Text = oldPOnum
                    Me.txtPOnum.Focus()
                    Exit Sub
                Else
                    If Trim(txtPOnum.Text) = Trim(CInt(txtPOnum.Text)) Then
                    Else
                        MsgBox("PO Numbers must be integers", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If
                End If
            End If


            If Trim(oldPOnum) = Trim(Me.txtPOnum.Text) Then
                MsgBox("You can not update this value because it is not different from the original.", MsgBoxStyle.OKOnly, "CAN NOT UPDATE")
                Me.txtPOnum.Focus()
                Exit Sub
            End If

            '//disable button until over
            btnPOnum.Enabled = False

            Dim lblString As String

            lblString = "You are about to change the following element:" & vbCrLf & vbCrLf & _
            "PO Number from : " & vbCrLf & vbCrLf & _
            oldPOnum & vbCrLf & vbCrLf & _
            "TO:" & vbCrLf & vbCrLf & _
            Me.txtPOnum.Text & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Change WorkOrder Message")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update
                    If intWorkOrder > 0 Then
                        Try
                            Dim valPOnum As String
                            Dim strSQL As String
                            AuditCall("RecEdit_WO_PO", intWorkOrder, Controls)
                            If Len(Trim(Me.txtPOnum.Text)) < 1 Then
                                valPOnum = "Null"
                                strSQL = "UPDATE tworkorder SET tworkorder.PO_ID = " & valPOnum & " WHERE tworkorder.WO_ID = " & intWorkOrder
                            Else
                                valPOnum = txtPOnum.Text
                                strSQL = "UPDATE tworkorder SET tworkorder.PO_ID = '" & valPOnum & "' WHERE tworkorder.WO_ID = " & intWorkOrder
                            End If
                            Dim tmpUpdate As New PSS.Data.Production.tworkorder()
                            Dim valUpdate As Int32 = tmpUpdate.idTransaction(strSQL)
                            'set new value as oldwomessage
                            oldPOnum = Me.txtPOnum.Text
                            lblNarrative.Text = ""
                            btnPOnum.Enabled = True
                            Me.txtPOnum.Focus()
                        Catch exp As Exception
                            MsgBox("Problem with the update of the purchase order number has occurred with workorder number: " & intWorkOrder & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnPOnum.Enabled = True
                            Me.txtPOnum.Focus()
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnPOnum.Enabled = True
                    Me.txtPOnum.Text = oldPOnum
                    Me.txtPOnum.Focus()
                    Exit Sub
            End Select

        End Sub

        Private Sub btnModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModel.Click

            Dim newModelText As String

            If IsDBNull(oldModel) = True Then
                oldModel = ""
            End If


            '//Get Model value
            Dim nvModel As Int32

            For xCount = 0 To dtModel.Rows.Count - 1
                r = dtModel.Rows(xCount)
                If Trim(cboModel.Text) = Trim(r("Model_Desc")) Then
                    newModelText = r("Model_Desc")
                    nvModel = r("Model_ID")
                    Exit For
                End If
            Next
            If nvModel < 1 Then
                MsgBox("New model can not be assigned.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            If Trim(oldModel) = Trim(nvModel) Then
                MsgBox("You can not update this value because it is not different from the original.", MsgBoxStyle.OKOnly, "CAN NOT UPDATE")
                Me.cboModel.Focus()
                Exit Sub
            End If

            '//disable button until over
            btnModel.Enabled = False

            Dim lblString As String

            lblString = "You are about to change the following element:" & vbCrLf & vbCrLf & _
            "Model from : " & vbCrLf & vbCrLf & _
            oldModelText & vbCrLf & vbCrLf & _
            "TO:" & vbCrLf & vbCrLf & _
            newModelText & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Change WorkOrder Message")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update
                    Dim intTray As Int32 = Trim(lstTray.SelectedItem)
                    If intWorkOrder > 0 And intTray > 0 Then
                        Try
                            Dim valModel As String
                            Dim strSQL As String
                            strSQL = "UPDATE tdevice SET tdevice.Model_ID = " & nvModel & " WHERE tdevice.WO_ID = " & intWorkOrder & " AND tdevice.Tray_ID = " & intTray
                            Dim tmpUpdate As New PSS.Data.Production.tworkorder()
                            Dim valUpdate As Int32 = tmpUpdate.idTransaction(strSQL)
                            'set new value as oldwomessage
                            oldModel = nvModel
                            lblNarrative.Text = ""
                            btnModel.Enabled = True
                            Me.cboModel.Focus()
                        Catch exp As Exception
                            MsgBox("Problem with the update of model has occurred with workorder number: " & intWorkOrder & ", tray number: " & intTray & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnModel.Enabled = True
                            Me.cboModel.Focus()
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnModel.Enabled = True
                    Me.cboModel.Focus()
                    Exit Sub
            End Select

        End Sub

        Private Sub btnManufWrty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManufWrty.Click

            If IsDBNull(oldManufWrty) = True Then
                oldManufWrty = ""
            Else
                If oldManufWrty = "1" Then
                    oldManufWrty = "S"
                ElseIf oldManufWrty = "2" Then
                    oldManufWrty = "E"
                End If
            End If

            If Trim(oldManufWrty) = Trim(Me.txtManufWrty.Text) Then
                MsgBox("You can not update this value because it is not different from the original.", MsgBoxStyle.OKOnly, "CAN NOT UPDATE")
                Me.txtManufWrty.Focus()
                Exit Sub
            End If

            If Len(Trim(txtManufWrty.Text)) > 0 Then
                txtManufWrty.Text = UCase(Trim(txtManufWrty.Text))
                If Trim(txtManufWrty.Text) <> "S" And Trim(txtManufWrty.Text) <> "E" Then
                    txtManufWrty.Text = ""
                End If

            End If

            '//disable button until over
            btnManufWrty.Enabled = False

            Dim lblString As String

            lblString = "You are about to change the following element:" & vbCrLf & vbCrLf & _
            "Manufacture Warranty from : " & vbCrLf & vbCrLf & _
            oldManufWrty & vbCrLf & vbCrLf & _
            "TO:" & vbCrLf & vbCrLf & _
            Me.txtManufWrty.Text & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Change WorkOrder Message")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update
                    Dim intTray As Int32 = lstTray.SelectedItem
                    Dim strDevice As String = lstDevice.SelectedItem
                    If intWorkOrder > 0 And intTray > 0 And Len(Trim(strDevice)) > 0 Then
                        Try
                            Dim valManufWrty As String
                            Dim strSQL As String
                            If Len(Trim(Me.txtManufWrty.Text)) < 1 Then
                                valManufWrty = "Null"
                                strSQL = "UPDATE tdevice SET tdevice.Device_ManufWrty = " & valManufWrty & " WHERE tdevice.WO_ID = " & intWorkOrder & " AND tdevice.Tray_ID = " & intTray & " AND tdevice.Device_SN = '" & strDevice & "'"
                                valManufWrty = ""
                            Else
                                If Trim(txtManufWrty.Text) = "S" Then
                                    valManufWrty = "1"
                                ElseIf Trim(txtManufWrty.Text) = "E" Then
                                    valManufWrty = "2"
                                End If
                                strSQL = "UPDATE tdevice SET tdevice.Device_ManufWrty = " & valManufWrty & " WHERE tdevice.WO_ID = " & intWorkOrder & " AND tdevice.Tray_ID = " & intTray & " AND tdevice.Device_SN = '" & strDevice & "'"
                            End If
                            Dim tmpUpdate As New PSS.Data.Production.tworkorder()
                            Dim valUpdate As Int32 = tmpUpdate.idTransaction(strSQL)
                            'set new value as oldwomessage
                            oldManufWrty = valManufWrty
                            lblNarrative.Text = ""
                            btnManufWrty.Enabled = True
                            Me.txtManufWrty.Focus()

                            clearDevicePageData()
                            populateDevices()

                        Catch exp As Exception
                            MsgBox("Problem with the update of manufacture warranty has occurred with workorder number: " & intWorkOrder & ", tray number: " & intTray & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnManufWrty.Enabled = True
                            Me.txtManufWrty.Focus()
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnManufWrty.Enabled = True
                    Me.txtManufWrty.Text = oldManufWrty
                    Me.txtManufWrty.Focus()
                    Exit Sub
            End Select

        End Sub

        Private Sub btnDelDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelDevice.Click

            '//Check for value
            If Len(Trim(txtDelDevice.Text)) < 1 Then
                MsgBox("Please select a device to continue.", MsgBoxStyle.OKOnly, "Choose a Device to Delete")
                Exit Sub
            End If

            '//disable button until over
            btnDelDevice.Enabled = False

            Dim lblString As String

            lblString = "You are about to delete the following element:" & vbCrLf & vbCrLf & _
            "Device : " & txtDelDevice.Text & vbCrLf & vbCrLf & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Change WorkOrder Message")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update
                    Dim intTray As Int32 = lstTray.SelectedItem
                    Dim strDevice As String = Trim(txtDelDevice.Text)

                    If intWorkOrder > 0 And intTray > 0 And Len(strDevice) > 0 Then
                        Try
                            Dim tmpDeviceID As String
                            Dim tmpLocID As String


                            '//get Device Serial Number
                            For xCount = 0 To dtDevice.Rows.Count - 1
                                r = dtDevice.Rows(xCount)
                                If Trim(r("Device_SN")) = Trim(txtDelDevice.Text) Then
                                    tmpDeviceID = r("Device_ID")
                                    tmpLocID = r("Loc_ID")
                                    txtDelDevLoc.Text = tmpLocID
                                    Exit For
                                End If
                            Next

                            Dim strSQL As String
                            'strSQL = "DELETE FROM tdevice where tdevice.WO_ID = " & intWorkOrder & " AND tdevice.Tray_ID = " & intTray & " AND tdevice.Device_ID = " & Trim(tmpDeviceID)
                            strSQL = "DELETE FROM tdevice WHERE tdevice.Device_ID = " & Trim(tmpDeviceID)

                            'Dim tmpUpdate As New PSS.Data.Production.tdevice()
                            'Dim valUpdate As Int32 = tmpUpdate.idTransaction(strSQL)
                            If tmpDeviceID > 0 Then

                                AuditCall("RecEdit_Device_Delete", tmpDeviceID, Controls)
                                'Exit Sub
                                Dim valDelete As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
                            Else
                                MsgBox("Device ID could not be assigned. Can not delete.", MsgBoxStyle.OKOnly)
                            End If
                            lblNarrative.Text = ""
                            btnDelDevice.Enabled = True
                            Me.lstDevice.Focus()
                            Me.txtDelDevice.Text = ""
                            clearDevicePageData()
                            populateDevices()

                        Catch exp As Exception
                            MsgBox("Problem with the update of message has occurred with workorder number: " & intWorkOrder & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnDelDevice.Enabled = True
                            Me.lstDevice.Focus()
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnDelDevice.Enabled = True
                    Me.lstDevice.Focus()
                    Exit Sub
            End Select

        End Sub

#End Region

#Region " Printing "

        Private Sub rePrintShippingForms(ByVal valTray As Int32)
            Dim strReportLoc As String = PSS.Core.ReportPath
            Dim objRpt As ReportDocument
            Dim vResponse As MsgBoxResult

            Try

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Ship_Manifest.rpt")
                    .RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(valTray)
                    .PrintToPrinter(2, True, 0, 0)
                    .Close()
                End With

                'rpt.RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(valTray)
                'rpt.PrintOut(False, 2)
                'rpt = Nothing
                vResponse = MsgBox("Print Manifest Detail?", MsgBoxStyle.YesNo, "Manifest Detail")

                If vResponse = MsgBoxResult.Yes Then
                    '                    Dim report1 As New ReportDocument()
                    '                    report1.Load(strReportLoc & "Ship_ManifestDetail.rpt", OpenReportMethod.OpenReportByTempCopy)
                        '                    report1.Refresh()
                        '                    report1.RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(valTray)
                        '                    report1.PrintToPrinter(2, False, 0, 0)


                        'Dim rptApp As New CRAXDRT.Application()
                        'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Ship_ManifestDetail.rpt")

                    objRpt = Nothing
                        objRpt = New ReportDocument()

                        With objRpt
                            .Load(PSS.Core.[Global].ReportPath & "Ship_ManifestDetail.rpt")
                            .RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(valTray)
                            .PrintToPrinter(2, True, 0, 0)
                            .Close()
                        End With
                    '    rpt.RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(valTray)
                    '    rpt.PrintOut(False, 2)
                    'rpt = Nothing
                End If

            Catch exp As Exception
                        MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub rePrintShippingFormMD(ByVal valTray As Int32)
            Dim strReportLoc As String = PSS.Core.ReportPath
            Dim vResponse As MsgBoxResult
            Dim objRpt As ReportDocument

            Try
                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Ship_ManifestDetail.rpt")

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Ship_ManifestDetail.rpt")
                    .RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(valTray)
                    .PrintToPrinter(1, True, 0, 0)
                End With

                'rpt.RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(valTray)
                'rpt.PrintOut(False, 1)
                'rpt = Nothing

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub rePrintReceivingForm(ByVal valWO As Int32)
            Dim strReportLoc As String = PSS.Core.ReportPath
            Dim objRpt As ReportDocument

            Try
                '                Dim report1 As New ReportDocument()
                '                report1.Load(strReportLoc & "Rec_Worksheet.rpt", OpenReportMethod.OpenReportByTempCopy)
                '                report1.Refresh()
                '                report1.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(valWO)
                '                report1.PrintToPrinter(2, False, 0, 0)

                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Rec_Worksheet.rpt")
                    .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(valWO)
                    .PrintToPrinter(2, True, 0, 0)
                End With

                'rpt.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(valWO)
                'rpt.PrintOut(False, 2)
                'rpt = Nothing

            Catch exp As Exception
                MsgBox(exp.ToString)
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub


        Private Sub rePrintUSAReceivingForm(ByVal valWO As Int32)
            Dim strReportLoc As String = PSS.Core.ReportPath
            Dim objRpt As ReportDocument

            Try
                '                Dim report1 As New ReportDocument()
                '                report1.Load(strReportLoc & "Rec_Worksheet.rpt", OpenReportMethod.OpenReportByTempCopy)
                '                report1.Refresh()
                '                report1.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(valWO)
                '                report1.PrintToPrinter(2, False, 0, 0)

                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_WorksheetUSAMobility.rpt")

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Rec_WorksheetUSAMobility.rpt")
                    .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(valWO)
                    .PrintToPrinter(2, True, 0, 0)
                End With

                'rpt.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(valWO)
                'rpt.PrintOut(False, 2)
                'rpt = Nothing

            Catch exp As Exception
                MsgBox(exp.ToString)
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            If Me.rbTray.Checked = True Then
                intTray = Trim(txtSelect.Text)
            ElseIf Len(Trim(Me.lstTray.SelectedItem)) > 0 Then
                intTray = Trim(Me.lstTray.SelectedItem)
            End If

            If intTray > 0 Then
                rePrintReceivingForm(intTray)
            Else
                MsgBox("Error printing report - NO TRAY SELECTED", MsgBoxStyle.OKOnly, "ERROR")
            End If
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Sub

#End Region

        Private Sub disableALLelements()

            txtWOmessage.Enabled = False
            btnMemo.Enabled = False
            cboCustomer.Enabled = False
            cboLocation.Enabled = False
            btnLocation.Enabled = False
            txtRefNum.Enabled = False
            btnRefNum.Enabled = False
            txtPOnum.Enabled = False
            btnPOnum.Enabled = False
            lstTray.Enabled = False
            cboManuf.Enabled = False
            cboModel.Enabled = False
            btnModel.Enabled = False
            lstDevice.Enabled = False
            txtManufWrty.Enabled = False
            btnManufWrty.Enabled = False
            txtDelDevice.Enabled = False
            btnDelDevice.Enabled = False
            btnReprint.Enabled = False

        End Sub

        Private Sub enableALLelements()

            txtWOmessage.Enabled = True
            btnMemo.Enabled = True
            cboCustomer.Enabled = True
            cboLocation.Enabled = True
            btnLocation.Enabled = True
            txtRefNum.Enabled = True
            btnRefNum.Enabled = True
            txtPOnum.Enabled = True
            btnPOnum.Enabled = True
            lstTray.Enabled = True
            cboManuf.Enabled = True
            cboModel.Enabled = True
            btnModel.Enabled = True
            lstDevice.Enabled = True
            txtManufWrty.Enabled = True
            btnManufWrty.Enabled = True
            txtDelDevice.Enabled = True
            btnDelDevice.Enabled = True
            btnReprint.Enabled = True

        End Sub

        Private Sub verifyInvoiceWorkorder(ByVal intworkorder)

            Dim dtInvoiced As DataTable = PSS.Data.Production.Joins.verifyInvoice(intworkorder)
            Dim r As DataRow
            If dtInvoiced.Rows(0)("Invoiced") <> False Then
                disableALLelements()
            Else
                enableALLelements()
            End If

        End Sub


        Private Sub rbShipping_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbShipping.CheckedChanged
            txtSelect.Text = ""
            txtSelect.Focus()
        End Sub

        Private Sub btnUnShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnShip.Click

            '//Check for value
            If Len(Trim(Me.txtUnshipDevice.Text)) < 1 Then
                MsgBox("Please select a device to continue.", MsgBoxStyle.OKOnly, "Choose a Device to UnShip")
                Exit Sub
            End If

            '//disable button until over
            btnUnShip.Enabled = False

            Dim lblString As String

            lblString = "You are about to UnShip the following element:" & vbCrLf & vbCrLf & _
            "Device : " & txtUnshipDevice.Text & vbCrLf & vbCrLf & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Unship Device")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update
                    '                    Dim intTray As Int32 = lstTray.SelectedItem
                    Dim strDevice As String = Trim(txtUnshipDevice.Text)

                    If Len(strDevice) > 0 Then
                        Try
                            Dim tmpDeviceID As String
                            '//get Device Serial Number

                            For xCount = 0 To dtUnship.Rows.Count - 1
                                r = dtUnship.Rows(xCount)
                                If Trim(r("Device_SN")) = Trim(txtUnshipDevice.Text) Then
                                    tmpDeviceID = r("Device_ID")
                                    Exit For
                                End If
                            Next

                            Dim dtInvCheck As New PSS.Data.Production.tdevice()
                            r = dtInvCheck.GetRowByPK(tmpDeviceID)
                            If r("Device_Invoice") = 1 Then
                                MsgBox("This device can not be unshipped. It has already been invoiced.", MsgBoxStyle.OKOnly, "ERROR")
                                Exit Sub
                            End If

                            Dim strSQL As String
                            AuditCall("RecEdit_Device_UnShip", Trim(tmpDeviceID), Controls)
                            strSQL = "UPDATE tdevice SET tdevice.Device_DateShip = Null, tdevice.Device_ShipWorkDate = null, tdevice.Ship_ID = 0 WHERE tdevice.Device_ID = " & Trim(tmpDeviceID)

                            'Dim tmpUpdate As New PSS.Data.Production.tdevice()
                            'Dim valUpdate As Int32 = tmpUpdate.idTransaction(strSQL)

                            Dim valDelete As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)

                            lblNarrative.Text = ""
                            btnUnShip.Enabled = True
                            Me.lstDeviceShip.Focus()
                            Me.txtUnshipDevice.Text = ""
                            clearDeviceShipPageData()
                            populateShippingDevices()

                        Catch exp As Exception
                            MsgBox("Problem with the update of message has occurred with Shipping number: " & "" & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnUnShip.Enabled = True
                            Me.lstDeviceShip.Focus()
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnUnShip.Enabled = True
                    Me.lstDeviceShip.Focus()
                    Exit Sub
            End Select

        End Sub

        Private Sub lstDeviceShip_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDeviceShip.SelectedIndexChanged
            txtUnshipDevice.Text = Trim(lstDeviceShip.SelectedItem)
        End Sub

        Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
        Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
        Private Sub lblLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLocation.Click

        End Sub

        Private Sub tbCtrl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbCtrl.SelectedIndexChanged
            Select Case tbCtrl.SelectedTab.Name
                Case "tbEndUser"

                    If ApplicationUser.GetPermission("EditMessagingEndUserTab") > 0 Then
                    Else
                        tbCtrl.SelectedTab = tbWorkOrder
                    End If
                Case Else
                    '''
            End Select
        End Sub

        Private Sub btnTLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTLoc.Click

            Exit Sub


            '            If Len(Trim(cboTrayLocation.Text)) < 1 Then
            '                MsgBox("Please select a location.", MsgBoxStyle.OKOnly, "No Location Selected")
            '                cboTrayLocation.Focus()
            '                Exit Sub
            '            End If

            '            If Len(Trim(intTray)) < 1 Then
            '                MsgBox("Please select a tray.", MsgBoxStyle.OKOnly, "No Tray Selected")
            '                cboTrayLocation.Focus()
            '                Exit Sub
            '            End If

            '            '//Get Location value
            '            Dim nvLocation As Int32
            '            Dim newLocText As String

            '            For xCount = 0 To dtLocation.Rows.Count - 1
            '            r = dtLocation.Rows(xCount)
            '            If Trim(cboTrayLocation.Text) = Trim(r("Loc_Name")) Then
            '                newLocText = r("Loc_Name")
            '                nvLocation = r("Loc_ID")
            '                Exit For
            '            End If
            '            Next
            '            If nvLocation < 1 Then
            '               MsgBox("New location can not be assigned.", MsgBoxStyle.OKOnly, "ERROR")
            '                Exit Sub
            '           End If

            '            '//disable button until over
            '            btnTLoc.Enabled = False

            '            Dim lblString As String

            '            lblString = "You are about to change the following element:" & vbCrLf & vbCrLf & _
            '            "All Devices in Tray: " & lstTray.SelectedItem & ", Location " & _
            '            "TO:" & vbCrLf & vbCrLf & _
            '            newLocText & vbCrLf & vbCrLf

            '            Me.lblNarrative.Text = lblString

            '            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Change Tray Location")
            '            Select Case confirmRequest
            '                Case vbYes
            '                    '//Proceed with update
            '                    If intWorkOrder > 0 Then
            '                        Try
            '                            Dim valLocation As String
            '                           Dim strSQL As String
            '                            Dim tmpUpdate As New PSS.Data.Production.tworkorder()
            '                            Dim valUpdate As Int32

            '                            '//Update devices
            '                            strSQL = "UPDATE tdevice SET tdevice.LOC_ID = " & nvLocation & " WHERE tdevice.Tray_ID = " & intTray
            '                            valUpdate = tmpUpdate.idTransaction(strSQL)

            '                            lblNarrative.Text = ""
            '                            btnLocation.Enabled = True
            '                            Me.cboLocation.Focus()
            '                        Catch exp As Exception
            '                            MsgBox("Problem with the update of location has occurred with workorder number: " & intWorkOrder & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
            '                            lblNarrative.Text = ""
            '                            btnLocation.Enabled = True
            '                            Me.cboLocation.Focus()
            '                        End Try
            '                    End If
            '                Case vbNo
            '                    '//Cancel
            '                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
            '                    lblNarrative.Text = ""
            '                    btnTLoc.Enabled = True
            '                    Me.cboTrayLocation.Focus()
            '                    Exit Sub
            '            End Select


        End Sub

        Private Sub btnInsDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsDevice.Click

            Dim recType As Integer

            If Len(Trim(cboRecType.Text)) < 1 Then
                MsgBox("Please select a receiving type to continue.", MsgBoxStyle.OKOnly, "Enter receiving type for Device to Insert")
                cboRecType.Focus()
                Exit Sub
            Else '//Get rectype value
                If Trim(cboRecType.Text) = "FIRM" Then recType = 1
                If Trim(cboRecType.Text) = "COAM" Then recType = 2
                If Trim(cboRecType.Text) = "END USER" Then recType = 3
                If Trim(cboRecType.Text) = "PO" Then recType = 4
            End If

            If recType < 1 Then Exit Sub

            '//Check for value
            If Len(Trim(txtInsDevice.Text)) < 1 Then
                MsgBox("Please enter a new device serial number to continue.", MsgBoxStyle.OKOnly, "Enter a Device to Insert")
                txtInsDevice.Focus()
                Exit Sub
            End If

            txtInsDevice.Text = UCase(txtInsDevice.Text)

            '//Verify that the number is not being used by any other in the tray
            For xCount = 0 To lstDevice.Items.Count - 1
                If Trim(lstDevice.Items(xCount)) = Trim(txtInsDevice.Text) Then
                    MsgBox("The device serial number is already being used by another device in the tray.", MsgBoxStyle.OKOnly, "Can Not Insert")
                    txtInsDevice.Text = ""
                    txtInsDevice.Focus()
                    Exit Sub
                End If
            Next

            '//disable button until over
            btnInsDevice.Enabled = False

            Dim lblString As String

            lblString = "You are about to insert the following element:" & vbCrLf & vbCrLf & _
            "Device : " & txtInsDevice.Text & vbCrLf & vbCrLf & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Enter New Device")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update
                    Dim intTray As Int32 = lstTray.SelectedItem
                    Dim strDevice As String = Trim(txtInsDevice.Text)

                    If intWorkOrder > 0 And intTray > 0 And Len(strDevice) > 0 Then
                        Try
                            Dim tmpDeviceID As String
                            '//get Device Serial Number
                            tmpDeviceID = Trim(txtInsDevice.Text)

                            '//place PSS wrty check here



                            Dim CustPSSwrtyParts As Integer
                            Dim CustPSSwrtyLabor As Integer
                            Dim CustPSSwrtyDaysInWrty As Integer
                            Dim POwrty, VALwrty As String
                            Dim PSSwarranty As Boolean

                            Try
                                Dim tblCustWrty As New PSS.Data.Production.tcustwrty()
                                Dim drCustWrty As DataRow = tblCustWrty.GetRowByCustID(valueCustomer)

                                CustPSSwrtyParts = drCustWrty("PSSwrtyParts_ID")
                                CustPSSwrtyLabor = drCustWrty("PSSwrtyLabor_ID")
                                CustPSSwrtyDaysInWrty = drCustWrty("CustWrty_DaysInWrty")

                                drCustWrty = Nothing
                                tblCustWrty = Nothing

                            Catch exp As Exception
                            End Try


                            If recType = "4" Then
                                POwrty = MsgBox("Is this PO Type for FIRM?", MsgBoxStyle.YesNo, "Select Warranty Check Type")
                                If POwrty = vbYes Then
                                    POwrty = "FIRM"
                                Else
                                    POwrty = "COAMPLUS"
                                End If
                                If POwrty = "FIRM" Then GoTo PSSwrtyFIRM
                                If POwrty = "COAMPLUS" Then GoTo PSSwrtyCOAMPLUS
                            End If

                            If recType = "1" Then
PSSwrtyFIRM:


                                If valueManufacturer = 1 Then
                                    MainWin.StatusBar.SetStatusText("Checking for Manufacturer Warranty")
                                    '//Check for motorola warranty
                                    Dim motoWrty As String
                                    motoWrty = checkMotorolaWrty()
                                    If motoWrty = "S" Then
                                        VALwrty = "S"
                                    Else
                                        VALwrty = ""
                                    End If
                                End If
                            Else
                                '//Diana puts in the value manually if COAM
PSSwrtyCOAMPLUS:
                                VALwrty = InputBox("Please enter the OEM Warranty Status for this device: ", "OEM Warranty", )
                                VALwrty = UCase(VALwrty)
                                If VALwrty <> "S" And VALwrty <> "E" Or Len(VALwrty) < 1 Then
                                    VALwrty = ""
                                End If
                            End If

                            '//PSS Warranty secition here
                            Dim valDBR As Boolean = False
                            Dim BillDeviceID As Int32
                            Dim xCount As Integer = 0
                            Dim pssDate As Date

                            Dim wrtyDays As Integer = -1 * CustPSSwrtyDaysInWrty
                            pssDate = DateAdd(DateInterval.Day, wrtyDays, Now)

                            Dim pssDateMonth As String
                            Dim pssDateDay As String
                            Dim pssDateYear As String
                            Dim pssNewDate As String

                            pssNewDate = DatePart(DateInterval.Year, pssDate) & "-" & DatePart(DateInterval.Month, pssDate) & "-" & DatePart(DateInterval.Day, pssDate)

                            PSSwarranty = False

                            MainWin.StatusBar.SetStatusText("Determining PSS Warranty")
                            Try
                                If CustPSSwrtyParts = 1 And CustPSSwrtyLabor = 1 Then
                                    'Do not check for PSS Warranty - it does not apply
                                Else

                                    If valueLocation = 0 Then
                                        'valLoc = lblAddressID.Text
                                        System.Windows.Forms.Application.DoEvents()
                                    End If


                                    '//This is new code June 4th 2003
                                    '//In this segment change the valLoc value to that of the parent company if rec type is end user


                                    '//End of new code June 4th 2003


                                    Dim dtPSSwrty As DataTable = PSS.Data.Production.Joins.chkPSSwrty(txtInsDevice.Text, valueLocation, pssNewDate)
                                    Dim r As DataRow
                                    If dtPSSwrty.Rows(0)("repeat") <> False Then
                                        PSSwarranty = True

                                        For xCount = 0 To dtPSSwrty.Rows.Count - 1
                                            BillDeviceID = dtPSSwrty.Rows(0)("repeat")
                                            'Dim tblPSSwrtyBILL As New PSS.Data.Production.Joins()
                                            Dim dtPSSbill As DataTable = PSS.Data.Production.Joins.chkPSSwrtyBILL(BillDeviceID)

                                            If dtPSSbill.Rows.Count > 0 Then
                                                PSSwarranty = False
                                                valDBR = True
                                                If recType <> "2" Then
                                                    valDBR = True
                                                Else
                                                    valDBR = True
                                                    PSSwarranty = False
                                                End If
                                                GoTo EndPSSwrty
                                            Else
                                                PSSwarranty = True
                                                valDBR = False
                                            End If

                                        Next

                                    Else
                                        'No previous record of device here
                                        'continue as normal
                                    End If

                                End If
                            Catch
                                PSSwarranty = False 'Can not be true there is no days in warranty range
                            End Try

                            '//Set if under PSS Warranty then do not display OEM warranty
                            If PSSwarranty = True Then
                                VALwrty = ""
                            End If

EndPSSwrty:

                            '//end of PSS wrty check

                            Dim pssNowDate As String = DatePart(DateInterval.Year, Now) & "-" & DatePart(DateInterval.Month, Now) & "-" & DatePart(DateInterval.Day, Now)
                            Dim ManufWarranty As Integer
                            If VALwrty = "S" Then
                                ManufWarranty = 1
                            ElseIf VALwrty = "E" Then
                                ManufWarranty = 2
                            Else
                                ManufWarranty = 0
                            End If
                            Dim valFieldMW As String = ", Device_ManufWrty"
                            Dim valValueMW As String = ", " & ManufWarranty
                            If ManufWarranty = 0 Then
                                valFieldMW = ""
                                valValueMW = ""
                            End If

                            Dim PSSwrty As Integer
                            If PSSwarranty = True Then
                                PSSwrty = 1
                            Else
                                PSSwrty = 0
                            End If

                            '//Get Device Count
                            Dim valDeviceCount As Integer = 0
                            Dim dcdt As DataTable = PSS.Data.Production.tdevice.GetDataTableByTray(intTray)
                            Dim r2 As DataRow
                            For xCount = 0 To dcdt.Rows.Count - 1
                                r2 = dcdt.Rows(xCount)
                                If r2("Device_Cnt") > valDeviceCount Then
                                    valDeviceCount = r2("Device_Cnt")
                                End If
                            Next
                            valDeviceCount += 1

                            Dim strSQL As String
                            strSQL = "INSERT into tdevice (Device_SN, Device_DateRec" & valFieldMW & ", Device_PSSwrty, Device_Reject, Device_LaborCharge, Device_Cnt, Tray_ID, Loc_ID, WO_ID, WO_ID_OUT, Model_ID) VALUES " & _
                            "('" & Trim(tmpDeviceID) & "', '" & pssNowDate & "'" & valValueMW & ", " & PSSwrty & ", 0,0," & valDeviceCount & ", " & intTray & ", " & valueLocation & ", " & intWorkOrder & ", " & intWorkOrder & ", " & valueModel & ")"
                            'Dim tmpUpdate As New PSS.Data.Production.tdevice()
                            'Dim valUpdate As Int32 = tmpUpdate.idTransaction(strSQL)
                            If Len(Trim(tmpDeviceID)) > 0 Then
                                Dim valInsert As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
                            Else
                                MsgBox("Device ID could not be assigned. Can not insert.", MsgBoxStyle.OKOnly)
                            End If
                            lblNarrative.Text = ""
                            btnInsDevice.Enabled = True
                            Me.lstDevice.Focus()
                            Me.txtInsDevice.Text = ""
                            clearDevicePageData()
                            populateDevices()

                        Catch exp As Exception
                            MsgBox("Problem with the insert of a new device has occurred with workorder number: " & intWorkOrder & ". Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnInsDevice.Enabled = True
                            Me.lstDevice.Focus()
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnInsDevice.Enabled = True
                    Me.lstDevice.Focus()
                    Exit Sub
            End Select

        End Sub

        Private Sub cboRecType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRecType.SelectedIndexChanged

        End Sub


        Private Function checkMotorolaWrty() As String

            checkMotorolaWrty = "0"

            Dim xCount As Integer = 0
            Dim chkValue As String = Mid(Trim(txtInsDevice.Text), 5, 2)
            Dim tblManufWrty As New PSS.Data.Production.lmanufwrty()
            Dim dtManufWrty As DataTable = tblManufWrty.GetManufWrtyData(chkValue, valueManufacturer)
            Dim valDateCode As String
            Dim valExpDate As Date

            Dim dr As DataRow

            For xCount = 0 To dtManufWrty.Rows.Count - 1
                dr = dtManufWrty.Rows(xCount)
                valDateCode = dr("ManufWrty_Code")
                valExpDate = dr("ManufWrty_Exp")
            Next

            If valExpDate > Now Then
                checkMotorolaWrty = "S"
            Else
                checkMotorolaWrty = "0"
            End If

        End Function


        Private Sub btnReprint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Try
                If Me.rbTray.Checked = True Then
                    intTray = Trim(txtSelect.Text)
                ElseIf Len(Trim(Me.lstTray.SelectedItem)) > 0 Then
                    intTray = Trim(Me.lstTray.SelectedItem)
                End If

                If intTray > 0 Then
                    rePrintReceivingForm(intTray)
                Else
                    MsgBox("Error printing report - NO TRAY SELECTED", MsgBoxStyle.OKOnly, "ERROR")
                End If
            Catch exp As Exception

            End Try
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub btnReprintReceiving_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintReceiving.Click

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Try
                If Me.rbTray.Checked = True Then
                    intTray = Trim(txtSelect.Text)
                ElseIf Len(Trim(Me.lstTray.SelectedItem)) > 0 Then
                    intTray = Trim(Me.lstTray.SelectedItem)
                End If

                If intTray > 0 Then
                    rePrintReceivingForm(intTray)
                Else
                    MsgBox("Error printing report - NO TRAY SELECTED", MsgBoxStyle.OKOnly, "ERROR")
                End If
            Catch exp As Exception

            End Try
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub btnReprintShipping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintShipping.Click

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim TmpshipVal As Int32
            Try
                TmpshipVal = InputBox("Enter Shipping ID for reprint", "Reprint")

                If TmpshipVal > 0 Then
                    rePrintShippingForms(TmpshipVal)
                Else
                    MsgBox("Error printing report - NO TRAY SELECTED", MsgBoxStyle.OKOnly, "ERROR")
                End If
            Catch exp As Exception

            End Try
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub


        Private Sub txtDeviceSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.TextChanged

            tdbGrid2.Visible = False
            btnDeleteNoTray.Visible = False
            intWorkOrder = 0
            intTray = 0
            intDevice = 0

        End Sub

        Private Sub txtDeviceSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown

            If e.KeyValue = 13 Then

                intDevice = 0

                Dim dtDupDataGrid As New DataTable()
                Dim dtDuplicateInd As DataTable()

                dtDupDataGrid = create_dtDupGrid()

                Dim valWorkorderID As Int32

                txtDeviceSN.Text = UCase(txtDeviceSN.Text)
                Dim findDevice As String = Trim(txtDeviceSN.Text)

                Dim tblDuplicate As New PSS.Data.Production.Joins()
                Dim dtDuplicate As DataTable = tblDuplicate.CheckDupDeviceBeforeDelete(findDevice)


                '                If dtDuplicate.Rows.Count > 1 Then '//Duplicate Exists
                Dim rDuplicate As DataRow

                tdbGrid2.Visible = True
                Dim rNew1 As DataRow

                For xCount = 0 To dtDuplicate.Rows.Count - 1
                    rDuplicate = dtDuplicate.Rows(xCount)
                    '//Add elements to grid
                    rNew1 = dtDupDataGrid.NewRow
                    rNew1("ID") = rDuplicate("Device_ID")
                    rNew1("Manufacturer") = rDuplicate("Manuf_Desc")
                    rNew1("Model") = rDuplicate("Model_Desc")
                    rNew1("Date Rec") = rDuplicate("Device_DateRec")
                    rNew1("Date Billed") = rDuplicate("Device_DateBill")
                    rNew1("Date Shipped") = rDuplicate("Device_DateShip")
                    rNew1("Serial Num") = rDuplicate("Device_SN")
                    rNew1("OLD Serial Num") = rDuplicate("Device_OldSN")
                    rNew1("Tray") = rDuplicate("Tray_ID")
                    rNew1("WorkOrder") = rDuplicate("WO_ID")
                    rNew1("Location") = rDuplicate("Loc_ID")
                    dtDupDataGrid.Rows.Add(rNew1)

                    tdbGrid2.DataSource = dtDupDataGrid.DefaultView
                Next
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
                '            ElseIf dtDuplicate.Rows.Count < 2 Then

                '                '//Get Information for deleting
                '                Dim dtSN As DataTable
                '                dtSN = PSS.Data.Production.tdevice.GetDataTableBySN(findDevice)
                '                For xCount = 0 To dtSN.Rows.Count - 1
                '                    r = dtSN.Rows(xCount)
                '                    intWorkOrder = r("WO_ID")
                '                    intTray = r("Tray_ID")
                '                    intDevice = r("Device_ID")
                '                    valueLocation = r("Loc_ID")
                '                    If intDevice > 0 Then
                '                        btnDeleteNoTray.Visible = True
                '                    End If
                '               Next

                '            Else
                '                Dim rGetVal As DataRow
                '                rGetVal = dtDuplicate.Rows(0)
                '                valWorkorderID = Trim(rGetVal("WO_ID"))
                '                'valCustomerID = rGetVal("Cust_ID")
                '            End If
                '//Not a duplicate

            End If
        End Sub


        Private Function create_dtDupGrid() As DataTable

            '//This will create a datatable that will hold information that will be used to populate TDBGrid1
            '//Detail information for devices with duplicate serial numbers
            Dim dtDupList As New DataTable("dtDuplicateInd")

            dtDupList.MinimumCapacity = 500
            dtDupList.CaseSensitive = False

            Dim dcID As New DataColumn("ID")
            dtDupList.Columns.Add(dcID)
            Dim dcManuf As New DataColumn("Manufacturer")
            dtDupList.Columns.Add(dcManuf)
            Dim dcModel As New DataColumn("Model")
            dtDupList.Columns.Add(dcModel)
            Dim dcReceived As New DataColumn("Date Rec")
            dtDupList.Columns.Add(dcReceived)
            Dim dcDateBill As New DataColumn("Date Billed")
            dtDupList.Columns.Add(dcDateBill)
            Dim dcDateShip As New DataColumn("Date Shipped")
            dtDupList.Columns.Add(dcDateShip)
            Dim dcSN As New DataColumn("Serial Num")
            dtDupList.Columns.Add(dcSN)
            Dim dcOldSN As New DataColumn("OLD Serial Num")
            dtDupList.Columns.Add(dcOldSN)
            Dim dcTray As New DataColumn("Tray")
            dtDupList.Columns.Add(dcTray)
            Dim dcWO As New DataColumn("WorkOrder")
            dtDupList.Columns.Add(dcWO)
            Dim dcLoc As New DataColumn("Location")
            dtDupList.Columns.Add(dcLoc)

            create_dtDupGrid = dtDupList

        End Function

        Private Sub tdbGrid2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdbGrid2.MouseUp

            btnDeleteNoTray.Visible = False

            Dim deviceID As Int32 = 0
            deviceID = tdbGrid2.Columns(0).Text
            Dim dateCheck As String

            If deviceID > 0 Then
                intWorkOrder = tdbGrid2.Columns("WorkOrder").Text
                intTray = tdbGrid2.Columns("Tray").Text
                intDevice = tdbGrid2.Columns("ID").Text
                dateCheck = tdbGrid2.Columns("Date Shipped").Text
                If Len(Trim(dateCheck)) > 0 Then
                    MsgBox("This device has already been shipped. It cannot be deleted!", MsgBoxStyle.OKOnly, "DO NOT DELETE")
                    intDevice = 0
                    Exit Sub
                End If

                btnDeleteNoTray.Visible = True
                txtDeviceSN.Text = tdbGrid2.Columns("Serial Num").Text
            End If

        End Sub

        Private Sub btnDeleteNoTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteNoTray.Click

            '//Check for value
            If Len(Trim(intDevice)) < 1 Then
                MsgBox("No device selected.", MsgBoxStyle.OKOnly, "Can not delete")
                Exit Sub
            End If

            '//disable button until over
            btnDeleteNoTray.Enabled = False

            Dim lblString As String

            lblString = "You are about to delete the following element:" & vbCrLf & vbCrLf & _
            "Device : " & txtDeviceSN.Text & vbCrLf & _
            "ID of : " & intDevice & vbCrLf & vbCrLf & vbCrLf

            Me.lblNarrative.Text = lblString

            Dim confirmRequest As String = MsgBox(lblString & "DO YOU WANT TO CONTINUE?", MsgBoxStyle.YesNo, "Change WorkOrder Message")
            Select Case confirmRequest
                Case vbYes
                    '//Proceed with update

                    If intWorkOrder > 0 And intTray > 0 And Len(intDevice) > 0 And intDevice > 0 Then
                        Try
                            Dim tmpDeviceID As String
                            '//get Device Serial Number
                            tmpDeviceID = intDevice
                            Dim strSQL As String
                            AuditCall("RecEdit_Device_Delete", tmpDeviceID, Controls)
                            'Exit Sub
                            strSQL = "DELETE FROM tdevice WHERE tdevice.Device_ID = " & Trim(tmpDeviceID)

                            If Len(Trim(tmpDeviceID)) > 0 Then
                                Dim valDelete As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
                            Else
                                MsgBox("Device ID could not be assigned. Can not delete.", MsgBoxStyle.OKOnly)
                            End If
                            btnDeleteNoTray.Enabled = True
                            lblNarrative.Text = ""
                            Me.txtDeviceSN.Text = ""

                        Catch exp As Exception
                            MsgBox("Problem with the delete od device has occurred. Please contact IT", MsgBoxStyle.OKOnly, "ERROR")
                            lblNarrative.Text = ""
                            btnDeleteNoTray.Enabled = True
                        End Try
                    End If
                Case vbNo
                    '//Cancel
                    MsgBox("Your request has been cancelled by the user.", MsgBoxStyle.OKOnly, "Cancelled")
                    lblNarrative.Text = ""
                    btnDeleteNoTray.Enabled = True
                    Exit Sub
            End Select

        End Sub

        Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            Dim EUupdate As New frmEndUserUpdate()
            EUupdate.ShowDialog()

        End Sub

        Private Sub tdbGrid2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbGrid2.Click

        End Sub

        Private Sub btnPrintManDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintManDetail.Click

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim TmpshipVal As Int32
            Try
                TmpshipVal = InputBox("Enter Shipping ID for reprint", "Reprint")

                If TmpshipVal > 0 Then
                    rePrintShippingFormMD(TmpshipVal)
                Else
                    MsgBox("Error printing report - NO TRAY SELECTED", MsgBoxStyle.OKOnly, "ERROR")
                End If
            Catch exp As Exception

            End Try
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim cAdmin As New CompanyAdmin.CompAddress()
            cAdmin.ShowDialog()

        End Sub

        Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim cSecurity As New Security.SecurityAdmin()
            cSecurity.ShowDialog()

        End Sub

        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim cFailCodes As New Gui.codes.FailCodes()
            cFailCodes.ShowDialog()

        End Sub

        Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

            Dim frmRecM As New frmPREdefineRMArec()
            frmRecM.ShowDialog()

        End Sub

        Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

            'Make hex code conversion here
            'Dim vHEX As String = InputBox("Enter HEX Value")
            'Dim valHex As String = Mid$(vHEX, 1, 8)
            'Dim vals1 As String = Mid$(vHEX, 1, 2)
            'Dim vals2 As String = Mid$(vHEX, 3, 6)

            'Dim valDec1 As System.UInt32
            'valDec1 = System.UInt32.Parse(vals1, Globalization.NumberStyles.HexNumber)
            'Dim valDec2 As System.UInt32
            'valDec2 = System.UInt32.Parse(vals2, Globalization.NumberStyles.HexNumber)

            'Dim v1 As String = valDec1.ToString.PadLeft(3, "0")
            'Dim v2 As String = valDec2.ToString.PadLeft(8, "0")
            'MsgBox(v1 & v2)

            Dim vHEX As String = InputBox("Enter Decimal Value")
            Dim vals1 As String = Mid$(vHEX, 1, 3)
            Dim vals2 As String = Mid$(vHEX, 4, 8)

            Dim valDec1, valDec2 As String
            'valDec1 = System.Math.Log(16).Parse(vals1)
            valDec1 = System.Math.Log(16).ToString(vals1)
            valDec2 = System.Math.Log(16).ToString(vals2)

            MsgBox(valDec1 & " " & valDec2)


            '            MsgBox(valhex.ToString)




            'Dim valHex As String = Mid$(vHEX, 1, 30)
            'Dim vals1 As String = Mid$(vHEX, 1, 2)
            'Dim vals2 As String = Mid$(vHEX, 3, 6)

            'Dim valDec1 As System.UInt32
            'valDec1 = System.Decim.Parse(valHex, Globalization.NumberStyles.Number)
            'Dim valDec2 As System.UInt32
            'valDec2 = System.UInt32.Parse(vals2, Globalization.NumberStyles.HexNumber)

            'Dim v1 As String = valDec1.ToString.PadLeft(3, "0")
            'Dim v2 As String = valDec2.ToString.PadLeft(8, "0")
            'MsgBox(v1 & v2)
            'MsgBox(valDec1)


        End Sub

        Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

            Dim tmpForm As New techscreen.frmNewTechData()
            tmpForm.ShowDialog()
            'Dim tmpForm As New frmFileRec()
            'tmpForm.ShowDialog()

        End Sub

        Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

            Dim intDevice As Int32
            intDevice = InputBox("Enter Device ID", 0)

            'Dim xList As PSS.Data.Production.Joins
            'Dim dtList As DataTable = xList.OrderEntrySelect("SELECT tdevice.device_id FROM tdevice WHERE loc_id=1468")

            'Dim xr As DataRow
            'Dim xrCount As Integer = 0

            'For xrCount = 0 To dtList.Rows.Count - 1
            'xr = dtList.Rows(xrCount)
            'intDevice = xr("device_id")

            If intDevice > 0 Then

                '/Get list of bill codes for device
                Dim tRef As New PSS.Data.Production.Joins()
                Dim dtRef As DataTable = tRef.OrderEntrySelect("select tdevicebill.device_id, tdevicebill.dbill_id, tdevicebill.billcode_id, tpartscodes.dcode_id from (tdevicebill LEFT OUTER JOIN tpartscodes on tdevicebill.dbill_id = tpartscodes.dbill_id) where tdevicebill.device_id=" & intDevice)
                Dim r As DataRow
                Dim xCount As Integer = 0

                For xCount = 0 To dtRef.Rows.Count - 1
                    r = dtRef.Rows(xCount)
                    If IsDBNull(r("dcode_id")) = True Then
                        Dim dtref2 As Boolean

                        If r("billcode_id") = 331 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 597 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 314 & ")")
                        ElseIf r("billcode_id") = 201 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 599 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 314 & ")")
                        ElseIf r("billcode_id") = 137 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 622 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 171 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 622 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 116 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 622 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 219 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 605 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 120 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 609 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 207 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 590 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 188 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 596 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 314 & ")")
                        ElseIf r("billcode_id") = 314 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 588 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 314 & ")")
                        ElseIf r("billcode_id") = 251 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 611 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 311 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 600 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 233 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 610 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 224 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 608 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 292 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 606 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 314 & ")")
                        ElseIf r("billcode_id") = 325 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 602 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 314 & ")")
                        ElseIf r("billcode_id") = 327 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 613 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 311 & ")")
                        ElseIf r("billcode_id") = 329 Then
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 603 & ")")
                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 314 & ")")
                            '                        ElseIf r("dbill_id") = 147 Then
                            '                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 597 & ")")
                            '                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 597 & ")")
                            '                        ElseIf r("dbill_id") = 115 Then
                            '                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 597 & ")")
                            '                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 597 & ")")
                            '                        ElseIf r("dbill_id") = 147 Then
                            '                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 597 & ")")
                            '                            dtref2 = tRef.OrderEntryUpdateDelete("INSERT INTO tpartscodes(DBill_ID, Dcode_ID) VALUES (" & r("DBill_ID") & ", " & 597 & ")")
                        End If
                    End If
                Next
            End If

            'Next

            MsgBox("complete")
            Button5.Focus()

        End Sub


        Private Sub btncellrec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim frmX As New NEW_CellReceiving()
            frmX.ShowDialog()
        End Sub

        Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
            Dim frmY As New frmPreload_Select_Cust()
            frmY.ShowDialog()
        End Sub

        Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
            Dim frmZ As New Gui.Shipping.frmShippingStage()
            frmZ.ShowDialog()
            'Dim frmZ As New Gui.CustomerMaint.frmPreload_Workorder()
            'frmZ.ShowDialog()
        End Sub

        Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

            Dim dData As New PSS.Data.Production.Joins()
            Dim dtData As DataTable = dData.OrderEntrySelect("SELECT tdevice.device_SN, tdevice.device_ID, tcellopt.cellopt_datecode FROM tdevice inner join tcellopt on tdevice.device_id = tcellopt.device_id WHERE tcellopt.cellopt_datecode = 'ZAE'")
            Dim r As DataRow
            Dim x As Integer
            Dim blnUpd As Boolean

            For x = 0 To dtData.Rows.Count - 1
                r = dtData.Rows(x)
                If Len(Trim(r("Device_SN"))) = 11 Then
                    blnUpd = dData.OrderEntryUpdateDelete("UPDATE tcellopt set cellopt_datecode = '" & Mid$(r("Device_SN"), 9, 3) & "' WHERE tcellopt.device_id = " & r("Device_ID"))
                ElseIf Len(Trim(r("Device_SN"))) = 10 Then
                    blnUpd = dData.OrderEntryUpdateDelete("UPDATE tcellopt set cellopt_datecode = '" & Mid$(r("Device_SN"), 5, 2) & "J' WHERE tcellopt.device_id = " & r("Device_ID"))
                End If
            Next

        End Sub



        Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click


            Dim strSQL As String = "SELECT * FROM tdevice WHERE wo_id=68046"
            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
            Dim dtUpdate As PSS.Data.Production.Joins

            Dim x As Integer
            Dim r As DataRow
            Dim vBln As Boolean

            For x = 0 To dt.Rows.Count - 1
                r = dt.Rows(x)
                If Len(Trim(r("Device_SN"))) = 11 Then
                    If Mid(r("Device_SN"), 11, 1) = "J" Then
                        vBln = dtUpdate.OrderEntryUpdateDelete("UPDATE tdevice SET device_SN = '" & Mid(r("Device_SN"), 1, 10) & "' WHERE Device_SN = '" & r("Device_SN") & "'")
                    End If
                End If

            Next

        End Sub

        Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click


            Dim strSQL As String = "select device_sn from tdevice where wo_id=67779 and device_sn not in('C33GDE5U77', 'C33GCVPV83', 'C333CWZ373', 'C333CVC102', 'C33GDF6853', 'C33GCVQB34', 'C33GCZ2B39', 'C333CUGT01', 'C33GDB6A75')"
            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
            Dim dtUpdate As PSS.Data.Production.Joins

            Dim x As Integer
            Dim r As DataRow
            Dim vBln As Boolean

            For x = 0 To dt.Rows.Count - 1
                r = dt.Rows(x)
                vBln = dtUpdate.OrderEntryUpdateDelete("UPDATE tdevice SET device_SN = 'C68" & Mid(r("Device_SN"), 4, 7) & "' WHERE Device_SN = '" & r("Device_SN") & "'")
            Next


        End Sub



        Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

            Dim tmpForm As New Programming.frmProgramming()
            tmpForm.ShowDialog()

            'Dim strSQL As String = "SELECT * FROM tdevice WHERE device_ID IN (4266403,4266303,4266298,4266299,4266300,4266301,4266302,4266304,4266305,4266306,4266307,4266308,4266309,4266310,4266311,4266312,4266313,4266314,4266315,4266316,4266317,4266318,4266319,4266320,4266321,4266322,4266323,4266324,4266325,4266326,4266327, 4266328,4266329,4266330,4266331,4266332,4266333,4266334, 4266335,4266336,4266337,4266338,4266339,4266340,4266341,4266342,4266343,4266344,4266345,4266346,4266347,4266348,4266349,4266350,4266351,4266352,4266353,4266354,4266355,4266356,4266357,4266358,4266359,4266360,4266361,4266362,4266363,4266364,4266365,4266366,4266367,4266368,4266369,4266370,4266371,4266372,4266373,4266374,4266375,4266376,4266377,4266378,4266379,4266380,4266381,4266382,4266383,4266384,4266385,4266386,4266387,4266388,4266389,4266390,4266391,4266392,4266393,4266394,4266395,4266396,4266397,4266398,4266399,4266400,4266401,4266402,4266404,4266405,4266406,4266407,4266408,4266409,4266410,4266411,4266412)"
            'Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
            'Dim r As DataRow
            'Dim xCount As Integer
            'Dim blnDT As Boolean
            'For xCount = 0 To dt.Rows.Count - 1
            'r = dt.Rows(xCount)
            'txtSerial = r("Device_SN")
            'tmpDeviceID = r("Device_ID")
            'tmpTrayID = r("Tray_ID")
            'LoadTray()
            'LoadDevice()
            'Try
            'Get Part Data Information
            '_device.AddPartCELL(260, 0, 0)
            'System.Windows.Forms.Application.DoEvents()
            'HotKeysF12()
            'Catch ex As Exception
            '    MsgBox(ex.ToString)
            '    End Try
            'strSQL = "INSERT INTO tdevicecodes (device_id, dcode_id) values(" & r("Device_ID") & ", 1344)"
            'blnDT = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
            'strSQL = "INSERT INTO tdevicecodes (device_id, dcode_id) values(" & r("Device_ID") & ", 378)"
            'blnDT = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strSQL)
            'Next

        End Sub




        Private Sub LoadTray()

            If IsNumeric(tmpTrayID) Then
                Dim Source As DataTable = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(tmpTrayID)
                If Source.Rows.Count = 0 Then
                    MsgBox("This is not a valid tray.", MsgBoxStyle.Information, "Error")
                    _tray = Nothing
                Else
                    _tray = Source
                End If
                Source = Nothing
            Else
                MsgBox("A tray number is all numeric. please enter a valid tray.", MsgBoxStyle.Information, "Error")
            End If

        End Sub
        Private Sub LoadDevice()
            Try
                Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(txtSerial.ToString) & "'")
                _device = New Device(__device(0)("Device_ID"))
                Dim i As Integer = 0
                For i = 0 To _tray.Rows.Count - 1
                    If _tray.Rows(i)("Device_SN") = UCase(txtSerial) Then
                        Exit For
                    End If
                Next

            Catch ex As Exception
                MsgBox(ex)
                MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                _device = Nothing
            End Try
        End Sub


        Private Sub HotKeysF12()

            If Len(Trim(tmpTrayID)) > 0 Then
                If Len(Trim(tmpDeviceID)) > 0 Then
                    UpdateBilling()
                End If
            End If

        End Sub

        Private Sub UpdateBilling()
            Try 'here in case there is not refrence to _device
                _device.Update()
                Dim d As DataRow() = _tray.Select("Device_ID = " & _device.ID)
                If _device.Parts.Rows.Count = 0 Then
                    d(0)("Device_DateBill") = DBNull.Value
                Else
                    d(0)("Device_DateBill") = Now
                End If
                d = Nothing
                '_device.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Information, "Error")
            Finally
            End Try
        End Sub















        Private Sub btnHighPFRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHighPFRA.Click

            Dim tmpDeviceID As Long = InputBox("Enter Device ID")

            If tmpDeviceID > 0 Then
                GetHighPFRA(tmpDeviceID)
            End If

        End Sub

        Private Sub GetHighPFRA(ByVal mDeviceID As Long)

            Dim vPF, vRA As Long

            Dim dtBillCodes As DataTable = getDTpfra(mDeviceID)
            vPF = assignPF(dtBillCodes)
            vRA = assignRA(dtBillCodes)

            MsgBox("PF: " & vPF & " RA: " & vRA)
            dtBillCodes.Dispose()

        End Sub

        Private Function getDTpfra(ByVal mDeviceID As Long) As DataTable

            Dim strBillCodes As String = "select tpsmap.billcode_id, tpsmap.laborlvl_id, twrtymap.wmap_problemfound, twrtymap.wmap_repairaction from " & _
                            "(((tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
                            "inner join tpsmap on tdevicebill.billcode_id = tpsmap.billcode_id and tdevice.model_id = tpsmap.model_id) " & _
                            "left outer join twrtymap on tdevice.model_id = twrtymap.model_id and tpsmap.billcode_id = twrtymap.billcode_id) " & _
                            "where(tdevice.device_id = " & mDeviceID & ") order by laborlvl_id desc"

            Return PSS.Data.Production.Joins.OrderEntrySelect(strBillCodes)

        End Function

        Private Function assignPF(ByVal dt As DataTable) As Long

            Dim r As DataRow
            Try
                r = dt.Rows(0)
                assignPF = r("wmap_ProblemFound")
            Catch ex As Exception
                assignPF = 0
            End Try

        End Function

        Private Function assignRA(ByVal dt As DataTable) As Long

            Dim r As DataRow
            Try
                r = dt.Rows(0)
                assignRA = r("wmap_RepairAction")
            Catch ex As Exception
                assignRA = 0
            End Try

        End Function










        Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click


            Dim inpString As String = InputBox("Enter WO ID to autobill", , )
            Dim inpStringBC As String = InputBox("Enter BillCode")

            Dim dt1 As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT DISTINCT tray_id FROM tdevice WHERE WO_ID = " & inpString)
            Dim dr As DataRow
            Dim xCount As Integer = 0

            For xCount = 0 To dt1.Rows.Count - 1
                dr = dt1.Rows(xCount)
                mTray = dr("Tray_ID")
                System.Windows.Forms.Application.DoEvents()
                Try
                    AutoBill(inpStringBC)
                Catch ex As Exception
                End Try
                System.Windows.Forms.Application.DoEvents()
            Next

            MsgBox("Done")

        End Sub


        Private Sub LoadTray(ByVal tmpTrayID As Long)

            If IsNumeric(tmpTrayID) Then
                Dim Source As DataTable = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(tmpTrayID)
                If Source.Rows.Count = 0 Then
                    MsgBox("This is not a valid tray.", MsgBoxStyle.Information, "Error")
                    _tray = Nothing
                Else
                    _tray = Source
                End If
                Source = Nothing
            Else
                MsgBox("A tray number is all numeric. please enter a valid tray.", MsgBoxStyle.Information, "Error")
            End If

        End Sub
        Private Sub LoadDevice(ByVal tmpSerial As String)
            Try
                Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(tmpSerial) & "'")
                _device = New Device(__device(0)("Device_ID"))
                Dim i As Integer = 0
                For i = 0 To _tray.Rows.Count - 1
                    If _tray.Rows(i)("Device_SN") = UCase(tmpSerial) Then
                        Exit For
                    End If
                Next

            Catch ex As Exception
                MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                _device = Nothing
            End Try
        End Sub

        Private Sub AutoBill(ByVal intBillCode As Integer)

            Try
                _device = Nothing
                _tray = Nothing
            Catch ex As Exception
            End Try

            Me.LoadTray(mTray)

            Dim xCount As Integer = 0
            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tdevice WHERE tray_id = " & mTray)
            Dim r As DataRow

            For xCount = 0 To dt.Rows.Count - 1

                r = dt.Rows(xCount)
                Me.LoadDevice(r("Device_SN"))
                System.Windows.Forms.Application.DoEvents()

                Try
                    'Bill Part
                    _device.AddPart(intBillCode)
                    System.Windows.Forms.Application.DoEvents()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    If Len(Trim(mTray)) > 0 Then
                        If Len(Trim(r("Device_SN"))) > 0 Then
                            UpdateBilling()
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    _device = Nothing
                    System.Windows.Forms.Application.DoEvents()
                Catch ex As Exception
                End Try

            Next

        End Sub



        Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click

            Dim tmpForm As New billing.mapCustBill()
            tmpForm.ShowDialog()

        End Sub

        Private Sub btnCellUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCellUpdate.Click


            Dim strDate As String = InputBox("Enter Date for Processing", "DATE")

            If Len(Trim(strDate)) < 1 Then
                Exit Sub
            End If

            'Dim strSQL As String = "SELECT tdevice.* FROM tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where tlocation.cust_id=2058 and tdevice.device_dateship is not null and tdevice.device_dateship > '2004-12-15'"
            'Dim strSQL As String = "SELECT tdevice.* FROM tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where tlocation.cust_id=2069 and tdevice.device_dateship is not null and tdevice.device_dateship > '2005-07-12'"

            '//This one is being replaced on December 29, 2005
            'Dim strSQL As String = "SELECT tdevice.* FROM tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where (tlocation.cust_id=2019 or tlocation.cust_id=2058) and tdevice.device_dateship is not null and tdevice.device_dateship > '" & strDate & "' and tdevice.loc_id <> 2590"
            Dim strSQL As String = "SELECT tdevice.* FROM tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where (tlocation.cust_id=2019 or tlocation.cust_id=2058) and tdevice.device_dateship is not null and tdevice.device_dateship > '" & strDate & "'"

            Dim drData As PSS.Data.Production.Joins
            Dim drSpec As PSS.Data.Production.Joins
            Dim drSpecUpd As PSS.Data.Production.Joins
            Dim blnSpec As Boolean

            Dim vTotal As Double

            Dim dtData As DataTable
            dtData = drData.OrderEntrySelect(strSQL)

            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim dtSpec As DataTable
            Dim rdt As DataRow

            If dtData.Rows.Count > 0 Then
                For xCount = 0 To dtData.Rows.Count - 1
                    r = dtData.Rows(xCount)

                    vTotal = 0
                    'vTotal = r("Device_Laborcharge")

                    dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 442")
                    If dtSpec.Rows.Count > 0 Then
                        rdt = dtSpec.Rows(0)
                        If rdt("Dbill_InvoiceAmt") > 0 Then
                            'vTotal += rdt("Dbill_InvoiceAmt")
                            vTotal += 2.0
                            'vTotal += 2.04
                        End If
                        blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevicebill set dbill_avgcost=0, dbill_stdcost=0, dbill_invoiceAmt = 0 where device_id = " & r("Device_ID") & " AND billcode_id = 442")
                    End If

                    dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 446")
                    If dtSpec.Rows.Count > 0 Then
                        rdt = dtSpec.Rows(0)
                        If rdt("Dbill_InvoiceAmt") > 0 Then
                            'vTotal += rdt("Dbill_InvoiceAmt")
                            vTotal += 4.3
                        End If
                        blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevicebill set dbill_avgcost=0, dbill_stdcost=0,  dbill_invoiceAmt = 0 where device_id = " & r("Device_ID") & " AND billcode_id = 446")
                    End If

                    dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 447")
                    If dtSpec.Rows.Count > 0 Then
                        rdt = dtSpec.Rows(0)
                        If rdt("Dbill_InvoiceAmt") > 0 Then
                            'vTotal += rdt("Dbill_InvoiceAmt")
                            vTotal += 3.0
                            blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevicebill set dbill_avgcost=0, dbill_stdcost=0,  dbill_invoiceAmt = 0 where device_id = " & r("Device_ID") & " AND billcode_id = 447")
                        End If
                        dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 448")
                    End If
                    dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 448")
                    If dtSpec.Rows.Count > 0 Then
                        rdt = dtSpec.Rows(0)
                        If rdt("Dbill_InvoiceAmt") > 0 Then
                            'vTotal += rdt("Dbill_InvoiceAmt")
                            vTotal += 1.85
                            blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevicebill set dbill_avgcost=0, dbill_stdcost=0,  dbill_invoiceAmt = 0 where device_id = " & r("Device_ID") & " AND billcode_id = 448")
                        End If
                    End If
                    If vTotal > 0 And vTotal > r("Device_Laborcharge") Then
                        'vTotal += r("Device_Laborcharge")
                        blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevice set device_laborcharge = " & vTotal & " where device_id = " & r("Device_ID"))
                    End If

                Next
            End If

            MsgBox("Complete", MsgBoxStyle.OKOnly)

        End Sub

        Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click


            Dim newString As String
            Dim dt As PSS.Data.Production.Joins
            Dim dtOld As DataTable = dt.OrderEntrySelect("SELECT * FROM lcodesdetail where mcode_id=20")
            Dim r As DataRow
            Dim blnRun As Boolean

            Dim xCount As Integer = 0

            For xCount = 0 To dtOld.Rows.Count - 1
                r = dtOld.Rows(xCount)
                newString = r("Dcode_ldesc") & " (" & r("dcode_sdesc") & ")"
                blnRun = dt.OrderEntryUpdateDelete("UPDATE lcodesdetail set dcode_ldesc = '" & newString & "' WHERE dcode_id = " & r("Dcode_ID"))
            Next



        End Sub

        Private Sub btnInvoiceModification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoiceModification.Click

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim vResponse As String
            Dim arrData(100, 1) As String
            Dim arrCount As Integer = 0
            Dim strFile As String

            strFile = Dir("C:\Invoice Message Files\")

            Do Until Len(strFile) < 1

                If Mid$(strFile, 1, 9).ToString = "Metrocall" Then

                    'sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=R:\Invoice Message Files\" & strFile & ";Extended Properties=Excel 8.0;"
                    sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Invoice Message Files\" & strFile & ";Extended Properties=Excel 8.0;"
                    objConn.ConnectionString = sConnectionstring
                    objConn.Open()

                    objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]") '
                    objCmdSelect.Connection = objConn
                    objAdapter1.SelectCommand = objCmdSelect

                    objAdapter1.Fill(dt)
                    objAdapter1.Fill(objDataset1, "XLData")

                    Dim sConn As PSS.Data.Production.Joins

                    Dim msg As String

                    For xCount = 0 To dt.Rows.Count - 1
                        r = dt.Rows(xCount)
                        'If IsDBNull(r("PSS Wrty")) = False Then
                        'If r("PSS Wrty") = "Yes" Then

                        If IsDBNull(r("Serial #")) = False Then
                            If Len(r("Serial #")) > 0 Then
                                Dim dtDetail As DataTable = sConn.OrderEntrySelect("SELECT * FROM tdevice WHERE device_sn = '" & r("Serial #") & "' ORDER BY device_daterec DESC")
                                Dim xDetail As Integer = 0
                                Dim rDetail As DataRow

                                Try
                                    'rDetail = dtDetail.Rows(1)
                                    rDetail = dtDetail.Rows(0)

                                    'MsgBox("Last entry for serial number : " & r("Serial No") & " was " & rDetail("Device_daterec"))


                                    'objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET LastHere = '" & rDetail("Device_DateRec") & "' WHERE SerialNo = '" & r("SerialNo") & "'")
                                    objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET LastRec = '" & rDetail("Device_DateRec") & "' WHERE SerialNo = '" & r("SerialNo") & "'")
                                    objCmdSelect1.Connection = objConn
                                    objCmdSelect1.ExecuteNonQuery()


                                    'arrData(arrCount, 0) = r("Serial No")
                                    'arrData(arrCount, 1) = rDetail("Device_DateRec")
                                    arrCount += 1

                                    'msg += arrData(arrCount, 0) & ", " & arrData(arrCount, 1) & vbCrLf
                                    'msg += r("Serial No") & ", " & rDetail("Device_DateRec") & vbCrLf

                                Catch ex As Exception
                                    'MsgBox(ex.ToString)
                                    objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET LastRec = ' ' WHERE SerialNo = '" & r("SerialNo") & "'")
                                    objCmdSelect1.Connection = objConn
                                    objCmdSelect1.ExecuteNonQuery()
                                End Try

                                dtDetail.Clear()
                                dtDetail = Nothing

                            End If
                        End If
                        'End If
                    Next

                    MsgBox(msg)

                    objConn.Close()

                    '//Open Excel sheet and enter records from arrData

                    'Dim oExcel As Excel.Application
                    'Dim oBook As Excel.Workbook
                    'Dim oSheet As Excel.Worksheet
                    'oExcel = CreateObject("R:\Invoice Message Files\" & strFile, "Excel.Application")
                    'oBook = oExcel.workbooks(1)
                    'oSheet = oBook.worksheets(1)

                    'Dim xlCount As Integer = 0

                    '                    For xlCount = 0 To 10
                    '                   MsgBox(oSheet.range("F" & xlCount).value)
                    '                  Next


                    'oSheet.range("A1").value() = "TECHNICIAN REPORT = " & Me.txtDate.Text
                    'oSheet.range("A2").value() = "Tech ID"
                    'oSheet.range("A2").columnwidth = 10

                    'oSheet.range(CStr("A" & xCount + 3)).value = r(0)
                    'oSheet.range(CStr("D" & xCount + 3)).value = r("qty").ToString





                End If



                strFile = Dir()

            Loop




        End Sub


        Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub Button15_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFile As String
            Dim r As DataRow

            strFile = "c:\WeekCount.xls"


            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFile & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()

            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect

            objAdapter1.Fill(dt)
            objAdapter1.Fill(objDataset1, "XLData")

            MsgBox(dt.Rows.Count)

            Dim xCount As Integer = 0
            Dim ds2 As PSS.Data.Production.Joins
            Dim dt2 As DataTable
            Dim blnIns As Boolean
            Dim strSQL2, strSQL3 As String
            Dim r2 As DataRow
            Dim zCount As Integer = 0

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                strSQL2 = "select count(billcode_id) as itemcount, billcode_id, model_id from " & _
                    "(tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id) " & _
                    "where tdevice.device_datebill > '" & Gui.Receiving.General.FormatDateShort(r("WeekStart")) & " 00:00:00' " & _
                    "and tdevice.device_datebill < '" & Gui.Receiving.General.FormatDateShort(r("WeekEnd")) & " 00:00:00' " & _
                    "group by billcode_id"

                dt2 = ds2.OrderEntrySelect(strSQL2)

                For zCount = 0 To dt2.Rows.Count - 1
                    r2 = dt2.Rows(zCount)

                    '//Perform Insert of Data Here
                    strSQL3 = "INSERT INTO sumdpartsytd (spYTD_WeekNum, spYTD_FiscWeekNum, spYTD_WeekStart, spYTD_WeekEnd, spYTD_ItemCount, Billcode_ID, Model_ID) VALUES (" & r("WeekNum") & ", " & r("FiscWeekNum") & ", '" & Gui.Receiving.General.FormatDateShort(r("WeekStart")) & "', '" & Gui.Receiving.General.FormatDateShort(r("WeekEnd")) & "', " & r2("ItemCount") & ", " & r2("Billcode_ID") & ", " & r2("Model_ID") & ")"

                    blnIns = ds2.OrderEntryUpdateDelete(strSQL3)

                    If blnIns = False Then
                        MsgBox("Error loading record")
                    End If

                Next
            Next

        End Sub

        Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click

            Dim strSQL As String = "select tpsmap.billcode_id, tpsmap.model_id, lpsprice.psprice_number, lpsprice.psprice_desc from tpsmap inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id where billcode_id > 0"
            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
            Dim r As DataRow
            Dim blnInsert As Boolean
            Dim strSQL2 As String
            Dim xCount As Integer = 0
            Dim strDesc As String
            Dim intDesc As Integer

            For xCount = 0 To dt.Rows.Count - 1
                Try
                    r = dt.Rows(xCount)
                    intDesc = 0
                    If IsDBNull(r("psprice_desc")) = False Then
                        strDesc = Replace(r("psprice_desc"), "'", "''")
                    Else
                        strDesc = ""
                    End If

                    strSQL2 = "INSERT INTO sumpartsnumbers (parts_number, parts_desc, billcode_id, model_id) VALUES ('" & r("psprice_number") & "','" & strDesc & "', " & r("billcode_id") & ", " & r("model_id") & ")"
                    blnInsert = ds.OrderEntryUpdateDelete(strSQL2)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Next

            MsgBox("Records: " & xCount)

        End Sub

        Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click

            Dim xCount As Integer = 0
            Dim strSQL As String = "select tdevicebill.device_id, dbill_invoiceamt, Device_LaborCharge, Device_ManufWrty, Device_PSSWrty from tdevicebill INNER JOIN tdevice on tdevicebill.device_id = tdevice.device_id where billcode_id=84 and tdevice.device_dateship is not null and device_dateship > '2005-06-26 00:00:00'"

            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
            Dim r As DataRow
            Dim tDeviceID As Long
            Dim tInvoiceAmt As Double
            Dim tLaborCharge As Double
            Dim tNewLC As Double
            Dim blnUpdate As Boolean
            Dim strSQLupdate As String

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                tDeviceID = r("Device_ID")
                tInvoiceAmt = r("Dbill_InvoiceAmt")
                tLaborCharge = r("Device_LaborCharge")

                If tInvoiceAmt > 0 And tLaborCharge > 0 Then
                    tNewLC = tInvoiceAmt + tLaborCharge

                    If tDeviceID > 0 Then
                        '//Perform update of data
                        strSQLupdate = "UPDATE tdevice, tdevicebill SET dbill_invoiceAmt = 0, Device_Laborcharge = " & tNewLC & " WHERE tdevicebill.device_id = tdevice.device_id AND billcode_id=84 and tdevicebill.device_id = " & tDeviceID
                        blnUpdate = ds.OrderEntryUpdateDelete(strSQLupdate)
                    End If

                ElseIf tLaborCharge = 0 And tInvoiceAmt > 0 Then
                    If r("Device_ManufWrty") = 1 Or r("Device_PSSWrty") = 1 Then
                        If tDeviceID > 0 Then
                            '//Perform update of data
                            strSQLupdate = "UPDATE tdevice, tdevicebill SET dbill_invoiceAmt = 0, Device_Laborcharge = 0 WHERE tdevicebill.device_id = tdevice.device_id AND billcode_id=84 and tdevicebill.device_id = " & tDeviceID
                            blnUpdate = ds.OrderEntryUpdateDelete(strSQLupdate)
                        End If
                    End If
                End If

            Next

            MsgBox("Done")

        End Sub

        Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click


            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFile As String
            Dim r, rDS As DataRow

            strFile = "D:\Wip April.xls"


            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFile & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()

            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect

            objAdapter1.Fill(dt)
            objAdapter1.Fill(objDataset1, "XLData")

            MsgBox(dt.Rows.Count)

            Dim sFile As PSS.Data.Production.Joins
            'Dim dtSource As DataTable = sFile.OrderEntrySelect("select device_sn, device_daterec, device_dateship, Ship_id, Tray_id, Cust_Name1 from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id inner join tcustomer on tlocation.cust_id = tcustomer.cust_id where tdevice.loc_id in (78,15,19) order by device_sn, device_daterec desc")
            Dim dtSource As DataTable = sFile.OrderEntrySelect("select device_sn, device_daterec, device_dateship, Ship_id, Tray_id, Cust_Name1 from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id inner join tcustomer on tlocation.cust_id = tcustomer.cust_id where tdevice.loc_id in (78,15,19) order by device_sn, device_daterec desc")

            Dim xCount As Integer = 0
            Dim zCount As Integer = 0
            Dim strDevice As String

            Dim vDateRec As String
            Dim vDateShip As String
            Dim vShipID As String
            Dim vTrayID As String
            Dim vStatus As String
            Dim vCust As String
            Dim mIsAvailable As Boolean = False

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                strDevice = r("Serial #")

                For zCount = 0 To dtSource.Rows.Count - 1
                    '//Get the value from the database table
                    rDS = dtSource.Rows(zCount)
                    If Trim(rDS("Device_SN")) = Trim(strDevice) Then

                        mIsAvailable = True

                        If IsDBNull(rDS("Device_DateRec")) = False Then vDateRec = rDS("Device_DateRec")
                        If IsDBNull(rDS("Device_DateShip")) = False Then vDateShip = rDS("Device_DateShip")
                        If IsDBNull(rDS("Ship_ID")) = False Then vShipID = rDS("Ship_ID")
                        If IsDBNull(rDS("Tray_ID")) = False Then vTrayID = rDS("Tray_ID")
                        If IsDBNull(rDS("Cust_Name1")) = False Then vCust = rDS("Cust_Name1")

                        If IsDBNull(rDS("Device_DateShip")) = True Then vStatus = "Work In Progress"
                        If IsDBNull(rDS("Device_DateShip")) = False Then vStatus = "Closed"

                        Exit For

                    End If

                    If mIsAvailable = False Then vStatus = "Not Found"
                Next

                mIsAvailable = False

                '/Write data to table

                If Len(vDateRec) > 0 Then
                    If vStatus = "Work In Progress" Then
                        objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET DateReceived  = '" & vDateRec & "' WHERE [Serial #] = '" & strDevice & "'")
                        objCmdSelect1.Connection = objConn
                        objCmdSelect1.ExecuteNonQuery()
                    End If
                End If
                If Len(vDateShip) > 0 Then
                    If vStatus = "Closed" Then
                        objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET DateShipped  = '" & vDateShip & "' WHERE [Serial #] = '" & strDevice & "'")
                        objCmdSelect1.Connection = objConn
                        objCmdSelect1.ExecuteNonQuery()
                    End If
                End If

                If Len(vShipID) > 0 Then
                    If vStatus = "Closed" Then
                        objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET [Manifest #]  = '" & vShipID & "' WHERE [Serial #] = '" & strDevice & "'")
                        objCmdSelect1.Connection = objConn
                        objCmdSelect1.ExecuteNonQuery()
                    End If
                End If

                If Len(vTrayID) > 0 Then
                    objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET TrayID  = '" & vTrayID & "' WHERE [Serial #] = '" & strDevice & "'")
                    objCmdSelect1.Connection = objConn
                    objCmdSelect1.ExecuteNonQuery()
                End If

                If Len(vStatus) > 0 Then
                    objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET Status  = '" & vStatus & "' WHERE [Serial #] = '" & strDevice & "'")
                    objCmdSelect1.Connection = objConn
                    objCmdSelect1.ExecuteNonQuery()
                End If

                If Len(vCust) > 0 Then
                    objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET CustomerID  = '" & vCust & "' WHERE [Serial #] = '" & strDevice & "'")
                    objCmdSelect1.Connection = objConn
                    objCmdSelect1.ExecuteNonQuery()
                End If

                vDateRec = ""
                vDateShip = ""
                vShipID = ""
                vTrayID = ""
                vStatus = ""
                vCust = ""

            Next


            objConn.Close()

            MsgBox("Complete Vendor Inquiry")

        End Sub

        Private Sub btnCreateNavisionFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNavisionFile.Click


            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtBin As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
            Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"""

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()

            Try
                nda.Fill(dtBin)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            nda.Dispose()
            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - END

            '//THIS SECTION TO BE REPLACED - START
            '//***********************************************************************
            '//***********************************************************************
            '//***********************************************************************
            '//***********************************************************************
            '//***********************************************************************
            'strFileBin = "D:\June20.xls"
            'sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFileBin & ";Extended Properties=Excel 8.0;"
            'objConn.ConnectionString = sConnectionstring
            'objConn.Open()
            'objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
            'objCmdSelect.Connection = objConn
            'objAdapter1.SelectCommand = objCmdSelect
            'objAdapter1.Fill(dtBin)
            'objAdapter1.Fill(objDataset1, "XLData")
            'MsgBox(dtBin.Rows.Count)
            '//***********************************************************************
            '//***********************************************************************
            '//***********************************************************************
            '//***********************************************************************
            '//***********************************************************************
            '//THIS SECTION TO BE REPLACED - END

            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow
            Dim xCount, validCount As Integer
            Dim strDate, strFileDate, vDateEnd As String
            Dim strFile, strFileAdj As String
            Dim vDate As String

            Dim vDate1 As Date
            Dim blnValid As Boolean

            Dim strInvalidReason As String
            Dim step1, step2 As Boolean
            step1 = False
            step2 = False

            Try
                vDate1 = InputBox("Enter date to process", "Enter Date", Format(Now, "M/d/yy"))
            Catch ex As Exception
                MsgBox("The date you entered is invalid. The process will now end. Please try again.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End Try

            vDate = Format(vDate1, "M/d/yy")

            strFileDate = vDate
            strDate = Gui.Receiving.FormatDateShort(vDate)
            vDate = Gui.Receiving.FormatDateShort(vDate) & " 00:00:00"
            vDateEnd = Gui.Receiving.FormatDateShort(vDate) & " 23:59:59"
            strFile = strDate & "DATA.txt"
            strFileAdj = strDate & "ADJ.txt"

            Dim xFileCheck As Integer = checkFile(strFile)
            If xFileCheck = 1 Then
                MsgBox("Please remove file before running.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim fs As New FileStream("R:\InventoryData\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsAdj As New FileStream("R:\InventoryData\" & strFileAdj, FileMode.Create, FileAccess.Write)
            Dim sAdj As New StreamWriter(fsAdj)
            sAdj.BaseStream.Seek(0, SeekOrigin.End)

            Dim strData As String

            '//Section 1 reclaimed
            'Dim strSQL As String = "select lwclocation.wc_location as location, lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
            '                        "tparttransaction left outer join lwclocation on tparttransaction.binloc = lwclocation.wclocation_id " & _
            '                        "inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '                        "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 and tparttransaction.trans_amount = -1 " & _
            '                        "and lpsprice.psprice_inventorypart = 1 " & _
            '                        "group by lwclocation.wc_location, lpsprice.psprice_number"

            Dim strSQL As String = "select lwclocation.wc_location as location, lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
                                    "tparttransaction left outer join lwclocation on tparttransaction.binloc = lwclocation.wclocation_id " & _
                                    "inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                                    "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 and tparttransaction.trans_amount = -1 " & _
                                    "and lpsprice.psprice_inventorypart = 1 " & _
                                    "and tcustomer.biztype_id = 0 " & _
                                    "group by lwclocation.wc_location, lpsprice.psprice_number"


            Dim dtCellReclaim As DataTable = ds.OrderEntrySelect(strSQL)

            For xCount = 0 To dtCellReclaim.Rows.Count - 1
                r = dtCellReclaim.Rows(xCount)

                blnValid = False
                For validCount = 0 To dtBin.Rows.Count - 1
                    rBin = dtBin.Rows(validCount)

                    If Trim(rBin("BinLocation").ToString) = Trim(r("location").ToString) Then
                        'MsgBox(UCase(rBin("Part").ToString) & "   " & UCase(r("number").ToString))
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            blnValid = True
                            step1 = True
                            Exit For
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = ""
                    End If
                Next

                If blnValid = True Then
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Positive" & vbTab & strFileDate & vbTab & r("department")
                    s.WriteLine(strData)
                Else
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Positive" & vbTab & strFileDate & vbTab & r("department") & vbTab & strInvalidReason
                    sAdj.WriteLine(strData)
                End If
                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

            'strSQL = "select lwclocation.wc_location as location, lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
            '         "tparttransaction left outer join lwclocation on tparttransaction.binloc = lwclocation.wclocation_id " & _
            '         "inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '         "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '         "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '         "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 and tparttransaction.trans_amount = 1 " & _
            '         "and lpsprice.psprice_inventorypart = 1 " & _
            '         "group by lwclocation.wc_location, lpsprice.psprice_number"
            strSQL = "select lwclocation.wc_location as location, lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
                     "tparttransaction left outer join lwclocation on tparttransaction.binloc = lwclocation.wclocation_id " & _
                     "inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                     "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                     "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                     "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                     "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 and tparttransaction.trans_amount = 1 " & _
                     "and lpsprice.psprice_inventorypart = 1 " & _
                     "and tcustomer.biztype_id = 0 " & _
                     "group by lwclocation.wc_location, lpsprice.psprice_number"

            Dim dtCellConsume As DataTable = ds.OrderEntrySelect(strSQL)

            For xCount = 0 To dtCellConsume.Rows.Count - 1
                r = dtCellConsume.Rows(xCount)

                blnValid = False
                For validCount = 0 To dtBin.Rows.Count - 1
                    rBin = dtBin.Rows(validCount)
                    If Trim(rBin("BinLocation").ToString) = Trim(r("location").ToString) Then
                        'MsgBox(UCase(rBin("Part").ToString) & "   " & UCase(r("number").ToString))
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            step1 = True
                            If CInt(r("count")) <= CInt(rBin("qty")) Then
                                blnValid = True
                                Exit For
                            End If
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = "Part Count Exceeds Quantity Available"""
                    End If
                Next

                If blnValid = True Then
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Negative" & vbTab & strFileDate & vbTab & r("department")
                    s.WriteLine(strData)
                Else
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Negative" & vbTab & strFileDate & vbTab & r("department") & vbTab & strInvalidReason
                    sAdj.WriteLine(strData)
                End If
                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

            'strSQL = "select lwclocation.wc_altloc as location, lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
            '         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '         "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '         "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '         "inner join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
            '         "inner join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
            '         "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
            '         "and lpsprice.psprice_inventorypart = 1 " & _
            '         "group by lwclocation.wc_location, lpsprice.psprice_number"
            strSQL = "select lwclocation.wc_altloc as location, lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                     "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                     "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                     "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                     "inner join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                     "inner join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                     "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                     "and lpsprice.psprice_inventorypart = 1 " & _
                     "and tcustomer.biztype_id = 0 " & _
                     "group by lwclocation.wc_location, lpsprice.psprice_number"

            Dim dtPageConsume As DataTable = ds.OrderEntrySelect(strSQL)

            For xCount = 0 To dtPageConsume.Rows.Count - 1
                r = dtPageConsume.Rows(xCount)

                blnValid = False
                For validCount = 0 To dtBin.Rows.Count - 1
                    rBin = dtBin.Rows(validCount)
                    If Trim(rBin("BinLocation").ToString) = Trim(r("location").ToString) Then
                        'MsgBox(UCase(rBin("Part").ToString) & "   " & UCase(r("number").ToString))
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            step1 = True
                            If CInt(r("count")) <= CInt(rBin("qty")) Then
                                blnValid = True
                                Exit For
                            End If
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = "Part Count Exceeds Quantity Available"""
                    End If
                Next

                If blnValid = True Then
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Negative" & vbTab & strFileDate & vbTab & r("department")
                    s.WriteLine(strData)
                Else
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Negative" & vbTab & strFileDate & vbTab & r("department") & vbTab & strInvalidReason
                    sAdj.WriteLine(strData)
                End If

                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

            s.Close()
            sAdj.Close()
            MsgBox("File Creation Is Complete!", MsgBoxStyle.OKOnly, "COMPLETE")

        End Sub

        Private Shared Function checkFile(ByVal mFileName As String) As Integer




        End Function


        Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click

            Dim frmAdmin As New frmAdminSearch()
            frmAdmin.Show()

        End Sub

        Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click

            Dim vWO As Long
            Dim xCount As Integer
            Dim r, rSUB As DataRow

            Dim v1count, v2count, ttlcount, v90count, vlt90count As Long
            v1count = 0
            v2count = 0
            v90count = 0
            vlt90count = 0
            ttlcount = 0
            Dim vDate As Date = "4/25/2005"

            vWO = InputBox("Enter wo id")

            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable = ds.OrderEntrySelect("SELECT Device_SN from tdevice where wo_id = " & vWO)

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)

                Dim dtSUB As DataTable = ds.OrderEntrySelect("SELECT Count(Device_SN) as recCount, max(device_dateship) as mDate from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where tdevice.device_SN = '" & r("Device_SN") & "' and wo_id <> " & vWO & " and tlocation.cust_id = 1 GROUP BY Device_SN")
                Try
                    rSUB = dtSUB.Rows(0)
                    If rSUB("recCount") > 0 Then
                        v2count += 1
                        ttlcount += 1

                        Dim vDate2 As Date = Gui.Receiving.FormatDateShort(rSUB("mDate"))
                        Dim vDateDiff As Integer = DateDiff(DateInterval.Day, vDate2, vDate)

                        If vDateDiff > 90 Then
                            v90count += 1
                        ElseIf vDateDiff < 91 Then
                            'MsgBox(r("Device_SN") & "   " & vDateDiff)
                            vlt90count += 1
                        End If
                    Else
                        v1count += 1
                        ttlcount += 1
                    End If
                Catch ex As Exception
                    'MsgBox(ex)
                    v1count += 1
                    ttlcount += 1
                End Try
            Next

            MsgBox("one time = " & v1count & vbCrLf & "two time = " & v2count & vbCrLf & "total count = " & ttlcount & vbCrLf & "Greater than 90 days " & v90count & vbCrLf & "Less Than 90 days " & vlt90count, MsgBoxStyle.OKOnly)

        End Sub

        Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click

            Dim xCount As Integer = 0
            Dim strSQL As String = "select tdevicebill.device_id, dbill_invoiceamt, Device_LaborCharge, Device_ManufWrty, Device_PSSWrty from tdevicebill INNER JOIN tdevice on tdevicebill.device_id = tdevice.device_id where billcode_id=532 and tdevice.device_dateship > '2005-06-26 00:00:00'"

            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
            Dim r As DataRow
            Dim tDeviceID As Long
            Dim tInvoiceAmt As Double
            Dim tLaborCharge As Double
            Dim tNewLC As Double
            Dim blnUpdate As Boolean
            Dim strSQLupdate As String

            MsgBox(dt.Rows.Count)

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                tDeviceID = r("Device_ID")
                tInvoiceAmt = 2.0
                tLaborCharge = r("Device_LaborCharge")

                If tInvoiceAmt > 0 And tLaborCharge > 0 Then
                    tNewLC = tInvoiceAmt + tLaborCharge

                    If tDeviceID > 0 Then
                        '//Perform update of data
                        strSQLupdate = "UPDATE tdevice, tdevicebill SET dbill_invoiceAmt = 0, Device_Laborcharge = " & tNewLC & " WHERE tdevicebill.device_id = tdevice.device_id AND billcode_id=532 and tdevicebill.device_id = " & tDeviceID
                        blnUpdate = ds.OrderEntryUpdateDelete(strSQLupdate)
                    End If

                ElseIf tLaborCharge = 0 And tInvoiceAmt > 0 Then
                    If r("Device_ManufWrty") = 1 Or r("Device_PSSWrty") = 1 Then
                        If tDeviceID > 0 Then
                            '//Perform update of data
                            strSQLupdate = "UPDATE tdevice, tdevicebill SET dbill_invoiceAmt = 0, Device_Laborcharge = 0 WHERE tdevicebill.device_id = tdevice.device_id AND billcode_id=84 and tdevicebill.device_id = " & tDeviceID
                            blnUpdate = ds.OrderEntryUpdateDelete(strSQLupdate)
                        End If
                    End If
                End If

            Next

            MsgBox("Done")

        End Sub




        Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click

            Dim objXL As Excel.Application
            Dim oSheet As Excel.Worksheet

            objXL = New Excel.Application()
            Me.OpenFileDialog1.ShowDialog()
            objXL.Workbooks.Open(OpenFileDialog1.FileName)
            oSheet = objXL.Worksheets(1)

            Dim mVendor As String = oSheet.Range("B13").Value
            Dim mReturnOfficeCode As String = oSheet.Range("B14").Value
            Dim mWorkorderNumber As String = oSheet.Range("B15").Value
            Dim mWorkorderQty As String = oSheet.Range("B16").Value
            Dim mCreationDate As String = oSheet.Range("B17").Value
            Dim mStartDate As String = oSheet.Range("B18").Value
            Dim mDueDate As String = oSheet.Range("B19").Value
            Dim mWorkorderSKU As String = oSheet.Range("B20").Value
            Dim mChannelCode As String = oSheet.Range("B21").Value
            Dim mFromLocation As String = oSheet.Range("B22").Value
            Dim mProcessedBy As String = oSheet.Range("B23").Value
            Dim mShipToOfficeCode As String = oSheet.Range("B27").Value
            Dim mFinishedGoodsSKU As String = oSheet.Range("B28").Value
            Dim mInstructions As String = oSheet.Range("B37").Value
            Dim mCapCodeRange As String = oSheet.Range("E38").Value
            Dim mFreq As String = oSheet.Range("E39").Value

            Dim intCapCodeMarker As Integer
            Dim mStartCap As String
            Dim mEndCap As String
            Dim mPad As String


            Try
                intCapCodeMarker = InStr(mCapCodeRange, "-")
                mStartCap = Trim(Mid$(mCapCodeRange, 1, intCapCodeMarker - 1))
                mEndCap = Trim(Mid$(mCapCodeRange, intCapCodeMarker + 1, 10))
            Catch EX As Exception
                intCapCodeMarker = 0
            End Try

            If intCapCodeMarker = 0 Then
                mStartCap = "WARRANTY"
                mEndCap = "WARRANTY"
            End If

            mPad = oSheet.Range("F38").Value

            Dim mString As String
            'mString += mVendor & vbCrLf
            'mString += mReturnOfficeCode & vbCrLf
            'mString += mWorkorderNumber & vbCrLf
            'mString += mWorkorderQty & vbCrLf
            'mString += mCreationDate & vbCrLf
            'mString += mStartDate & vbCrLf
            'mString += mDueDate & vbCrLf
            'mString += mWorkorderSKU & vbCrLf
            'mString += mChannelCode & vbCrLf
            'mString += mFromLocation & vbCrLf
            'mString += mProcessedBy & vbCrLf
            'mString += mShipToOfficeCode & vbCrLf
            'mString += mFinishedGoodsSKU & vbCrLf
            'mString += mInstructions & vbCrLf
            'mString += mCapCodeRange & vbCrLf
            'mString += intCapCodeMarker & vbCrLf
            'mString += mStartCap & vbCrLf
            'mString += mEndCap & vbCrLf
            'MsgBox(mString)

            '//Insert data into tusatest
            Dim StrFieldList As String
            StrFieldList = "(USA_WO, USA_Vendor, USA_ReturnOfficeCode, USA_Qty, USA_CreationDate, "
            StrFieldList += "USA_StartDate, USA_DueDate, USA_Channel, USA_SKU, USA_FromLocation, USA_ProcessedBy, "
            StrFieldList += "USA_ShipTo, USA_FinishedGoodsSKU, USA_Instructions, USA_CapLow, USA_CapHigh, USA_Freq, USA_Pad)"

            Dim strFieldData As String
            strFieldData = "('" & mWorkorderNumber & " ', '" & mVendor & "', '" & mReturnOfficeCode & "', " & mWorkorderQty & ", '" & mCreationDate & "', "
            strFieldData += "' " & mStartDate & "', '" & mDueDate & "', '" & mChannelCode & "', '" & mWorkorderSKU & "', '" & mFromLocation & "', '" & mProcessedBy & "', "
            strFieldData += "' " & mShipToOfficeCode & "', '" & mFinishedGoodsSKU & "', '" & mInstructions & "', '" & mStartCap & "', '" & mEndCap & "', '" & mFreq & "', " & mPad & ")"

            Dim strInsert As String = "INSERT INTO tusatest " & StrFieldList & " VALUES " & strFieldData

            Dim blnInsert As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strInsert)
            If blnInsert = False Then MsgBox("The data could not be inserted.", MsgBoxStyle.Critical, "ERROR")

        End Sub

        Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click


            Dim frmMain As New frmDisposition()
            frmMain.ShowDialog()
            Exit Sub


            Dim vSKUblank As String = InputBox("Enter Base SKU to create", "Create Navision Skus")
            If Len(Trim(vSKUblank)) > 0 Then vSKUblank = UCase(vSKUblank)

            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable = ds.OrderEntrySelect("Select Sku_Number from tsku")

            Dim odbcStr As String = "SELECT No_ FROM Item WHERE No_ Like 'C10MIL%' "

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()

            Try
                nda.Fill(ndt)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            nda.Dispose()
            MsgBox(ndt.Rows.Count)

            Dim x As Integer
            Dim rdt As DataRow
            For x = 0 To ndt.Rows.Count - 1
                rdt = ndt.Rows(x)
                MsgBox(rdt("No_"))
            Next
            oODBConnection.Close()
            Exit Sub



        End Sub

        Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click


            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFile As String
            Dim r, rDS As DataRow

            strFile = "D:\Ranger060805.xls"


            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFile & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()

            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect

            objAdapter1.Fill(dt)
            objAdapter1.Fill(objDataset1, "XLData")

            MsgBox(dt.Rows.Count)

            Dim sFile As PSS.Data.Production.Joins
            Dim dtSource As DataTable = sFile.OrderEntrySelect("select device_sn, device_daterec, device_dateship, Ship_id, Tray_id from tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where tlocation.cust_id = 1 and device_daterec > '2005-06-07 00:00:00'  order by device_sn, device_daterec desc")

            Dim xCount As Integer = 0
            Dim zCount As Integer = 0
            Dim strDevice As String

            Dim vDateRec As String
            Dim vDateShip As String
            Dim vShipID As String
            Dim vTrayID As String
            Dim vStatus As String
            Dim mIsAvailable As Boolean = False

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                strDevice = r("Serial No")

                For zCount = 0 To dtSource.Rows.Count - 1
                    '//Get the value from the database table
                    rDS = dtSource.Rows(zCount)
                    If Trim(rDS("Device_SN")) = Trim(strDevice) Then

                        mIsAvailable = True

                        If IsDBNull(rDS("Device_DateRec")) = False Then vDateRec = rDS("Device_DateRec")
                        If IsDBNull(rDS("Device_DateShip")) = False Then vDateShip = rDS("Device_DateShip")
                        If IsDBNull(rDS("Ship_ID")) = False Then vShipID = rDS("Ship_ID")
                        If IsDBNull(rDS("Tray_ID")) = False Then vTrayID = rDS("Tray_ID")

                        If IsDBNull(rDS("Device_DateShip")) = True Then vStatus = "Work In Progress"
                        If IsDBNull(rDS("Device_DateShip")) = False Then vStatus = "Closed"

                        Exit For

                    End If

                    If mIsAvailable = False Then vStatus = "Not Found"
                Next

                mIsAvailable = False

                '/Write data to table

                If Len(vDateRec) > 0 Then
                    If vStatus = "Work In Progress" Then
                        objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET DateRec  = '" & vDateRec & "' WHERE [Serial No] = '" & strDevice & "'")
                        objCmdSelect1.Connection = objConn
                        objCmdSelect1.ExecuteNonQuery()
                    End If
                End If
                If Len(vDateShip) > 0 Then
                    If vStatus = "Closed" Then
                        objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET DateShip  = '" & vDateShip & "' WHERE [Serial No] = '" & strDevice & "'")
                        objCmdSelect1.Connection = objConn
                        objCmdSelect1.ExecuteNonQuery()
                    End If
                End If

                'If Len(vShipID) > 0 Then
                'If vStatus = "Closed" Then
                '    objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET [Manifest #]  = '" & vShipID & "' WHERE [Serial #] = '" & strDevice & "'")
                '    objCmdSelect1.Connection = objConn
                '    objCmdSelect1.ExecuteNonQuery()
                'End If
                'End If

                'If Len(vTrayID) > 0 Then
                'objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET TrayID  = '" & vTrayID & "' WHERE [Serial #] = '" & strDevice & "'")
                'objCmdSelect1.Connection = objConn
                'objCmdSelect1.ExecuteNonQuery()
                'End If

                'If Len(vStatus) > 0 Then
                'objCmdSelect1.CommandText = ("UPDATE [Sheet1$] SET Status  = '" & vStatus & "' WHERE [Serial #] = '" & strDevice & "'")
                'objCmdSelect1.Connection = objConn
                'objCmdSelect1.ExecuteNonQuery()
                'End If

                vDateRec = ""
                vDateShip = ""
                vShipID = ""
                vTrayID = ""
                vStatus = ""

            Next


            objConn.Close()

        End Sub


        Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click

            Dim valWO As Long = InputBox("Enter WO ID value:", "WO ID")
            If Len(Trim(valWO)) > 0 Then
                Dim dtSource As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT tdevice.Device_ID, Device_SN, cellopt_CSN_Dec FROM tdevice INNER JOIN tcellopt on tdevice.device_id = tcellopt.device_id where WO_ID = " & valWO & " AND cellopt_CSN_Dec =''")

                Dim vHex, vDec As String
                Dim blnInsert As Boolean
                Dim dtInsert As PSS.Data.Production.Joins
                Dim xCount As Integer = 0
                Dim r As DataRow
                For xCount = 0 To dtSource.Rows.Count - 1
                    r = dtSource.Rows(xCount)
                    vHex = r("Device_SN")

                    Dim valHex As String = Mid$(Trim(vHex), 1, 8)
                    Dim vals1 As String = Mid$(Trim(vHex), 1, 2)
                    Dim vals2 As String = Mid$(Trim(vHex), 3, 6)
                    Dim valDec1 As System.UInt32
                    valDec1 = System.UInt32.Parse(vals1, Globalization.NumberStyles.HexNumber)
                    Dim valDec2 As System.UInt32
                    valDec2 = System.UInt32.Parse(vals2, Globalization.NumberStyles.HexNumber)
                    Dim v1 As String = valDec1.ToString.PadLeft(3, "0")
                    Dim v2 As String = valDec2.ToString.PadLeft(8, "0")
                    vDec = v1 & v2

                    blnInsert = dtInsert.OrderEntryUpdateDelete("UPDATE tcellopt SET cellopt_CSN_Dec = '" & vDec & "' WHERE Device_ID = " & r("Device_ID"))
                Next

            End If



        End Sub

        Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click


            Dim vStart As Long = 0

            Dim valWO As Long = InputBox("Enter WO ID value:", "WO ID")
            If Len(Trim(valWO)) > 0 Then
                Dim dtSource As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT tdevice.Device_ID, tdevice.Device_SN, devicemetro_capcode, USA_Pad FROM tdevice INNER JOIN tdevicemetro on tdevice.device_sn = tdevicemetro.devicemetro_sn INNER JOIN tworkorder on tdevice.wo_id = tworkorder.wo_id INNER JOIN tusatest ON tworkorder.wo_custwo = tusatest.USA_WO where tdevice.WO_ID = " & valWO)

                Dim vPad As Integer
                Dim vCap, newCap As String
                Dim blnInsert As Boolean
                Dim dtInsert As PSS.Data.Production.Joins
                Dim xCount As Integer = 0
                Dim r As DataRow
                For xCount = 0 To dtSource.Rows.Count - 1
                    r = dtSource.Rows(xCount)
                    vCap = Trim(r("DeviceMetro_capcode"))
                    vCap = (r("DeviceMetro_capcode"))

                    vPad = r("USA_Pad")
                    'If Len(Trim(vStart)) <> vPad Then
                    '                        newCap = vCap.ToString.PadLeft(vPad, "0")
                    newCap = vStart.ToString.PadLeft(vPad, "0")
                    vStart += 1
                    blnInsert = dtInsert.OrderEntryUpdateDelete("UPDATE tdevicemetro SET devicemetro_capcode = '" & newCap & "' WHERE DeviceMetro_SN = '" & r("Device_SN") & "'")
                    'End If

                    'If Mid$(r("DeviceMetro_capcode"), 1, 2) = "00" Then
                    '     blnInsert = dtInsert.OrderEntryUpdateDelete("UPDATE tdevicemetro SET devicemetro_capcode = '" & Trim(Mid$(r("DeviceMetro_capcode"), 3, 10)) & "' WHERE DeviceMetro_SN = '" & r("Device_SN") & "'")
                    'End If

                Next
            End If

        End Sub

        Private Sub btnUpdatePricing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdatePricing.Click

            '//Create datatable form Navision which holds data values for Part numbers and pricing
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtNavision As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            Dim blnDelete As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete("DELETE FROM tnavpriceload")
            If blnDelete = False Then
                MsgBox("The table tnavpriceload could not be cleared. The process can not continue.")
                Exit Sub
            End If

            '//NEW NAVISION DATATABLE FOR SOURCE DATA - START
            Dim odbcStr As String = "SELECT No_ as Part, ""Unit Cost"" as UnitCost, ""Unit Price"" as StandardCost FROM Item"

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()
            Try
                nda.Fill(dtNavision)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            nda.Dispose()
            '//NEW NAVISION DATATABLE FOR SOURCE DATA - END

            '//NEW PSSI DATATABLE FOR SOURCE DATA - START
            Dim dtPSSI As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT PSPrice_Number, PSPrice_Desc, PSPrice_AvgCost, PSPrice_StndCost, PSPrice_InventoryPart FROM lpsprice")
            '//NEW PSSI DATATABLE FOR SOURCE DATA - END

            '//Make array for new data use PSSI source as the source for the array add three additional dimensions
            Dim arrNewData(dtPSSI.Rows.Count, 8) As String
            '//Make array for new data use PSSI source as the source for the array add three additional dimensions

            '//Load elements to array
            Dim xCount As Integer
            Dim yCount As Integer

            Dim rPSSI As DataRow
            Dim rNavision As DataRow

            For xCount = 0 To dtPSSI.Rows.Count - 1
                rPSSI = dtPSSI.Rows(xCount)
                '//Add data from PSSI source
                If IsDBNull(rPSSI("PSPrice_Number")) = False Then arrNewData(xCount, 1) = rPSSI("PSPrice_Number")
                If IsDBNull(rPSSI("PSPrice_Desc")) = False Then arrNewData(xCount, 2) = rPSSI("PSPrice_Desc")
                If IsDBNull(rPSSI("PSPrice_AvgCost")) = False Then arrNewData(xCount, 3) = rPSSI("PSPrice_AvgCost")
                If IsDBNull(rPSSI("PSPrice_StndCost")) = False Then arrNewData(xCount, 4) = rPSSI("PSPrice_StndCost")
                If IsDBNull(rPSSI("PSPrice_InventoryPart")) = False Then arrNewData(xCount, 5) = rPSSI("PSPrice_InventoryPart")

                For yCount = 0 To dtNavision.Rows.Count - 1
                    rNavision = dtNavision.Rows(yCount)
                    '//Add data fron Navision source is Part ID's match

                    If Trim(UCase(rNavision("Part"))) = Trim(UCase(rPSSI("PSPrice_Number"))) Then
                        arrNewData(xCount, 6) = rNavision("Part")
                        arrNewData(xCount, 7) = rNavision("UnitCost")
                        arrNewData(xCount, 8) = rNavision("StandardCost")
                        Exit For
                    End If
                Next
            Next

            '//The complete data array should be completed.
            '//Now write data to table for storage
            Dim vDate As String = Gui.Receiving.FormatDateShort(Now)
            Dim vInsert As PSS.Data.Production.Joins
            Dim v1, v2, v6 As String
            Dim v3, v4, v7, v8 As Double
            Dim v5 As Integer

            For xCount = 0 To dtPSSI.Rows.Count - 1

                Try
                    v1 = arrNewData(xCount, 1)
                Catch ex As Exception
                End Try
                Try
                    v2 = arrNewData(xCount, 2)
                Catch ex As Exception
                    v2 = ""
                End Try
                Try
                    v3 = arrNewData(xCount, 3)
                Catch ex As Exception
                    v3 = 0
                End Try
                Try
                    v4 = arrNewData(xCount, 4)
                Catch ex As Exception
                    v4 = 0
                End Try
                Try
                    v5 = arrNewData(xCount, 5)
                Catch ex As Exception
                End Try
                Try
                    v6 = arrNewData(xCount, 6)
                Catch ex As Exception
                End Try
                Try
                    v7 = arrNewData(xCount, 7)
                Catch ex As Exception
                End Try
                Try
                    v8 = arrNewData(xCount, 8)
                Catch ex As Exception
                End Try

                Dim vWriteData As Boolean = False
                '//Run business rules to determine whether to write fdata values or not
                '//If amounts are not even then data needs to be written
                If v3 <> v7 And Len(Trim(v6)) > 0 Then vWriteData = True
                If v4 <> v8 And Len(Trim(v6)) > 0 Then vWriteData = True


                Dim strDesc As String = v2
                Dim strDescCh As String
                Dim i As Integer

                i = StrComp(v2, "'", vbTextCompare)
                If i > 0 Then
                    strDescCh = Replace(v2, "'", "\'", 1, -1, vbTextCompare)
                    v2 = strDescCh
                End If

                Dim blnWrite As Boolean
                Dim strSQL As String
                If vWriteData = True Then
                    strSQL = "INSERT INTO tnavpriceload (PSSI_Date, PSSI_Number, PSSI_Desc, PSSI_AvgCost, PSSI_StndCost, PSSI_InvPart, NAV_Number, NAV_UnitCost, NAV_StndCost) VALUES ('" & vDate & "','" & v1 & "','" & v2 & "'," & v3 & "," & v4 & ", " & v5 & ", '" & v6 & "'," & v7 & "," & v8 & ")"
                    blnWrite = vInsert.OrderEntryUpdateDelete(strSQL)
                End If

            Next



            '//Make report in excel
            Dim oExcel As Excel.Application
            Dim oBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet
            oExcel = New Excel.Application()
            oBook = oExcel.workbooks.add
            oSheet = oBook.worksheets(1)



            oSheet.range("A1").value() = "PRICING DATA LOAD"
            oSheet.range("A1").columnwidth = 50
            oSheet.range("A2").value() = "NAVISION TO PSSI"
            oSheet.range("A3").value() = UCase(vDate)

            oSheet.range("B5").value() = "PART NUMBER"
            oSheet.range("B1").columnwidth = 20
            oSheet.range("C5").value() = "DESCRIPTION"
            oSheet.range("C1").columnwidth = 20
            oSheet.range("D5").value() = "OLD COST(avg)"
            oSheet.range("D1").columnwidth = 20
            oSheet.columns("D").numberformat = "0.00"
            oSheet.range("E5").value() = "NEW COST(avg)"
            oSheet.range("E1").columnwidth = 20
            oSheet.columns("E").numberformat = "0.00"
            oSheet.range("F5").value() = "OLD PRICE(stnd)"
            oSheet.range("F1").columnwidth = 20
            oSheet.columns("F").numberformat = "0.00"
            oSheet.range("G5").value() = "NEW PRICE(stnd)"
            oSheet.range("G1").columnwidth = 20
            oSheet.columns("G").numberformat = "0.00"


            oSheet.range("G2").columnwidth = 8
            oSheet.range("H2").value() = "Diff."
            oSheet.range("H2").columnwidth = 8
            oSheet.range("I2").value() = "Avg Cost"
            oSheet.range("I2").columnwidth = 8
            oSheet.columns("I").numberformat = "0.00"

            MsgBox("DONE")

        End Sub

        Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click

            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tnavpriceload")
            Dim r As DataRow
            Dim xCount As Integer = 0
            Dim blnValue As Boolean
            Dim ds As PSS.Data.Production.Joins

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                If Len(Trim(r("PSSI_Number"))) > 0 Then
                    '//This is the normal SQL
                    blnValue = ds.OrderEntryUpdateDelete("UPDATE lpsprice SET psprice_AvgCost = " & r("NAV_UnitCost") & ", psprice_StndCost = " & r("Nav_StndCost") & " WHERE PSPrice_Number = '" & r("PSSI_Number") & "'")
                    '//This SQL is to only update average price
                    'blnValue = ds.OrderEntryUpdateDelete("UPDATE lpsprice SET psprice_AvgCost = " & r("NAV_UnitCost") & " WHERE PSPrice_Number = '" & r("PSSI_Number") & "'")
                End If
            Next

            MsgBox("DONE")

        End Sub

        Private Function verifyDisposition(ByVal vDeviceID As Long, ByVal vType As Integer) As String

            Dim ds As PSS.Data.Production.Joins
            Dim vWO, vSKU, vOrigSKU As Long
            Dim mSKU As String

            '//See if record exists in tdisposition
            Dim dtCount As DataTable = ds.OrderEntrySelect("SELECT * FROM tdisposition WHERE Device_ID = " & vDeviceID)
            Dim rCount As DataRow
            If dtCount.Rows.Count > 0 Then
                rCount = dtCount.Rows(0)
                '//Get SKU Number
                Dim dtNumber As DataTable = ds.OrderEntrySelect("SELECT * FROM tsku WHERE Sku_ID = " & rCount("Disp_New"))
                Dim rNumber As DataRow = dtNumber.Rows(0)
                Return rNumber("Sku_Number")
                dtNumber = Nothing
            End If
            dtCount = Nothing

            If vType = 1 Then '//This is for DBD/RUR Devices
                Return ""
            End If

            '//Get WO_ID
            Dim dtWO As DataTable = ds.OrderEntrySelect("SELECT * FROM tdevice WHERE Device_ID = " & vDeviceID)
            Dim rWO As DataRow = dtWO.Rows(0)
            vOrigSKU = rWO("Sku_ID")
            vWO = rWO("WO_ID")
            dtWO = Nothing
            System.Windows.Forms.Application.DoEvents()

            '//Get default SKU value from tpreloadwodata
            Try
                Dim dtSKU As DataTable = ds.OrderEntrySelect("SELECT * FROM tpreloadwodata WHERE WO_ID = " & vWO)
                Dim rSKU As DataRow = dtSKU.Rows(0)
                mSKU = rSKU("plwodata_DefaultSKU")
                dtSKU = Nothing
            Catch ex As Exception
                MsgBox("No SKU has been defined for this device and no default can be determined. Please use the disposition screen to assign the correct sku to this device.", MsgBoxStyle.Critical, "ERROR")
                Return ""
            End Try
            System.Windows.Forms.Application.DoEvents()

            '//Determine the correct SKU_ID for this default SKU
            Try
                Dim dtSKUID As DataTable = ds.OrderEntrySelect("SELECT * FROM tsku WHERE Sku_Number = '" & mSKU & "'")
                Dim rSKUID As DataRow = dtSKUID.Rows(0)
                vSKU = rSKUID("Sku_ID")
                dtSKUID = Nothing
            Catch ex As Exception
                MsgBox("No SKU ID can be determined. Please use the disposition screen to assign the correct sku to this device.", MsgBoxStyle.Critical, "ERROR")
                Return ""
            End Try
            System.Windows.Forms.Application.DoEvents()

            If vSKU > 0 And vDeviceID > 0 Then
                '//Update record in tdevice and insert record into tdisposition
                Dim blninsert As Boolean = ds.OrderEntryUpdateDelete("INSERT INTO tdisposition (Disp_Date, Disp_Old, Disp_New, Device_ID) VALUES ('" & Gui.Receiving.FormatDate(Now) & "', " & vOrigSKU & ", " & vSKU & ", " & vDeviceID & ")")
                System.Windows.Forms.Application.DoEvents()
                Dim blnUpdate As Boolean = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Sku_ID = " & vSKU & " WHERE Device_ID = " & vDeviceID)
                System.Windows.Forms.Application.DoEvents()

                Return mSKU
            End If

        End Function

        Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click

            Dim vDeviceID As Long = InputBox("Enter Device_ID", "Input", 0)

            If vDeviceID = 0 Then
                Exit Sub
            End If

            Dim cMisc As New PSS.Data.Buisness.Misc()

            'Dim strValue As String = verifyDisposition(vDeviceID, 0)
            Dim strValue As String = cMisc.renderDisposition(vDeviceID, 0)

            MsgBox("_Disposition: " & cMisc._Disposition & ", PassBackValue: " & strValue)

        End Sub

        Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click

            '//Get records to be update tparttransaction
            Dim strSQL1 As String = ("select max(trans_id) as trans, device_id, billcode_id, trans_amount from tparttransaction where date_rec > '2005-08-30 00:00:00' and date_rec < '2005-09-20 00:00:00' and date_rec < '2005-09-18 00:00:00' and trans_amount = 1 and dbill_id = 0 group by device_id, billcode_id")
            '            Dim strSQL1 As String = ("select max(trans_id) as trans, device_id, billcode_id, trans_amount from tparttransaction where date_rec > '2005-08-26 00:00:00' and date_rec > '2005-08-29 00:00:00' and date_rec < '2005-09-18 00:00:00' and trans_amount = 1 group by device_id, billcode_id")
            Dim dtsource As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQL1)

            MsgBox(dtsource.Rows.Count)

            Dim dtTempSource As PSS.Data.Production.Joins
            Dim dtTemp As DataTable

            Dim dtUpdate As PSS.Data.Production.Joins
            Dim blnUpdate As Boolean

            Dim rSource As DataRow
            Dim rTemp As DataRow
            Dim xCount As Long
            For xCount = 0 To dtsource.Rows.Count - 1
                rSource = dtsource.Rows(xCount)
                '//Get dbill_id value
                If rSource("Device_ID") > 0 And rSource("Billcode_ID") > 0 And rSource("Trans") > 0 Then
                    dtTemp = dtTempSource.OrderEntrySelect("select * from tdevicebill where device_id = " & rSource("Device_ID") & " and billcode_id = " & rSource("Billcode_ID"))

                    If dtTemp.Rows.Count < 1 Then GoTo ForceNextRecord


                    rTemp = dtTemp.Rows(0)

                    If rTemp("DBill_ID") > 0 Then
                        '//Update the record in tparttransaction
                        Try
                            blnUpdate = dtUpdate.OrderEntryUpdateDelete("UPDATE tparttransaction SET DBill_ID = " & rTemp("DBill_ID") & " WHERE trans_id = " & rSource("Trans") & " and device_id = " & rSource("Device_ID") & " AND billcode_id = " & rSource("Billcode_ID"))
                        Catch ex As Exception
                            MsgBox("Could not update device_id = " & rSource("Device_ID") & " billcode " & rSource("Billcode_ID"), MsgBoxStyle.Critical)
                        End Try
                    Else
                        MsgBox("Could not update device_id = " & rSource("Device_ID") & " billcode " & rSource("Billcode_ID"), MsgBoxStyle.Critical)
                    End If
                End If
ForceNextRecord:
            Next

        End Sub


        Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click

            '//Create datatable form Navision which holds data values for Part numbers and pricing
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtNavision As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            Dim blnDelete As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete("DELETE FROM tnavpriceinsert")
            If blnDelete = False Then
                MsgBox("The table tnavpriceinsert could not be cleared. The process can not continue.")
                Exit Sub
            End If

            '//NEW NAVISION DATATABLE FOR SOURCE DATA - START
            Dim odbcStr As String = "SELECT No_ as Part, ""Unit Cost"" as UnitCost, ""Unit Price"" as StandardCost, Description FROM Item where Description not like 'Tools-%' and Description not like 'Equip%' and Description not like 'Label-%' and Description not like 'Toner-%' and Description not like 'Crystals-%' and Description not like 'Holster-%' and Description not like 'Mktg-%'"

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()
            Try
                nda.Fill(dtNavision)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            nda.Dispose()
            '//NEW NAVISION DATATABLE FOR SOURCE DATA - END

            '//NEW PSSI DATATABLE FOR SOURCE DATA - START
            Dim dtPSSI As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT PSPrice_Number, PSPrice_Desc, PSPrice_AvgCost, PSPrice_StndCost, PSPrice_InventoryPart FROM lpsprice where PSPrice_desc not like 'Tools-%' and PSPrice_desc not like 'Equip%' and PSPrice_desc not like 'Label-%' and PSPrice_desc not like 'Toner-%' and PSPrice_desc not like 'Crystals-%' and PSPrice_desc not like 'Holster-%'")

            '//NEW PSSI DATATABLE FOR SOURCE DATA - END

            Dim rPSSI As DataRow
            Dim rNavision As DataRow
            Dim strSQL As String

            Dim NavCount, PssiCount As Integer
            Dim blnExists As Boolean = False
            Dim blnInsert As Boolean
            Dim dsInsert As PSS.Data.Production.Joins
            '//Iterate through Navision
            For NavCount = 0 To dtNavision.Rows.Count - 1
                rNavision = dtNavision.Rows(NavCount)

                blnExists = False

                For PssiCount = 0 To dtPSSI.Rows.Count - 1
                    rPSSI = dtPSSI.Rows(PssiCount)
                    If Trim(UCase(rPSSI("PSPrice_Number"))) = Trim(UCase(rNavision("Part"))) Then
                        blnExists = True
                        Exit For
                    End If
                Next
                If blnExists = False Then
                    '//Insert data into tnavpriceinsert


                    Dim strDesc As String = rNavision("Description")
                    Dim strDescCh As String
                    Dim i As Integer

                    i = StrComp(strDesc, "'", vbTextCompare)
                    If i > 0 Then
                        strDescCh = Replace(strDesc, "'", "\'", 1, -1, vbTextCompare)
                        strDesc = strDescCh
                    End If



                    If Mid$(strDesc, 1, 4) <> "99Z_" Then

                        strSQL = "INSERT INTO tnavpriceinsert (PSSI_Date, PSSI_Number, PSSI_Desc, PSSI_AvgCost, PSSI_StndCost) VALUES ('" & Gui.Receiving.FormatDateShort(Now) & "', '" & rNavision("Part") & "', '" & strDesc & "', " & rNavision("UnitCost") & ", " & rNavision("StandardCost") & ")"
                        blnInsert = dsInsert.OrderEntryUpdateDelete(strSQL)
                        System.Windows.Forms.Application.DoEvents()
                        '//Insert data into lpsprice
                        strSQL = "INSERT INTO lpsprice (PSPrice_Number, PSPrice_Desc, PSPrice_AvgCost, PSPrice_StndCost) VALUES ('" & rNavision("Part") & "', '" & strDesc & "', " & rNavision("UnitCost") & ", " & rNavision("StandardCost") & ")"
                        blnInsert = dsInsert.OrderEntryUpdateDelete(strSQL)
                        System.Windows.Forms.Application.DoEvents()

                    End If


                End If
                blnExists = False
            Next

            MsgBox("DONE")

        End Sub

        Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click

        End Sub

        Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFile As String
            Dim r, rDS As DataRow

            strFile = "D:\TBL_ChannelFrequency.xls"


            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFile & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()

            objCmdSelect.CommandText = ("SELECT * FROM [MainSheet$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect

            Try
                objAdapter1.Fill(dt)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            objAdapter1.Fill(objDataset1, "XLData")

            MsgBox(dt.Rows.Count)

            Dim dsIns As PSS.Data.Production.Joins
            Dim blnInsert As Boolean
            Dim xCount As Integer = 0
            Dim rIns As DataRow
            Dim strSQL As String

            For xCount = 0 To dt.Rows.Count - 1
                rIns = dt.Rows(xCount)
                '//Insert record into table
                strSQL = "INSERT INTO lchannel2frequency (C2F_Frequency, C2F_Channel) VALUES ('" & rIns("Frequency") & "', '" & rIns("Channel") & "')"
                blnInsert = dsIns.OrderEntryUpdateDelete(strSQL)
            Next

        End Sub

        Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFile As String
            Dim r, rDS As DataRow

            strFile = "D:\TBL_ModelCodes.xls"


            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFile & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()

            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect

            Try
                objAdapter1.Fill(dt)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            objAdapter1.Fill(objDataset1, "XLData")

            MsgBox(dt.Rows.Count)

            Dim dsIns As PSS.Data.Production.Joins
            Dim blnInsert As Boolean
            Dim xCount As Integer = 0
            Dim rIns As DataRow
            Dim strSQL As String

            For xCount = 0 To dt.Rows.Count - 1
                rIns = dt.Rows(xCount)
                '//Insert record into table
                strSQL = "INSERT INTO lmodelcodes4skus (ModelCode, Description, Category, Timing, Model_ID) VALUES ('" & rIns("ModelCode") & "', '" & rIns("Description") & "', '" & rIns("Category") & "', " & rIns("Timing") & ", '" & rIns("modelid") & "')"
                blnInsert = dsIns.OrderEntryUpdateDelete(strSQL)
            Next

        End Sub

        Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click



            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFile As String
            Dim r1, rDS As DataRow

            strFile = "D:\XL_NewSkus.xls"


            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFile & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()

            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect

            Try
                objAdapter1.Fill(dt)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            objAdapter1.Fill(objDataset1, "XLData")

            MsgBox(dt.Rows.Count)

            Dim dsMain As PSS.Data.Production.Joins
            Dim xCount As Integer = 0
            Dim blnUpdate As Boolean
            Dim newSku As String
            Dim zCount As Integer = 0
            Dim r As DataRow



            Dim dtMain As DataTable = dsMain.OrderEntrySelect("SELECT devicemetro_sku, devicemetro_sn FROM tdevicemetro")
            Dim rMain As DataRow

            For xCount = 0 To dtMain.Rows.Count - 1
                rMain = dtMain.Rows(xCount)
                If Len(Trim(rMain("devicemetro_SKU"))) < 13 Then
                    For zCount = 0 To dt.Rows.Count - 1
                        r = dt.Rows(zCount)
                        If UCase(Trim(r("OLDSKU"))) = UCase(Trim(rMain("devicemetro_Sku"))) Then
                            blnUpdate = dsMain.OrderEntryUpdateDelete("UPDATE tdevicemetro SET devicemetro_SKU = '" & r("NEWSKU") & "' WHERE devicemetro_sn = '" & rMain("devicemetro_sn") & "'")
                            Exit For
                        End If
                    Next
                End If
            Next



        End Sub

        Private Sub btnLoadUSAMobilityData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadUSAMobilityData.Click

            Dim objXL As Excel.Application
            Dim oSheet As Excel.Worksheet
            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow

            objXL = New Excel.Application()

            Me.OpenFileDialog1.ShowDialog()
            objXL.Workbooks.Open(OpenFileDialog1.FileName)
            oSheet = objXL.Worksheets(1)
            Dim strValidate As String
            Dim mVendor As String
            Dim mReturnOfficeCode As String
            Dim mWorkorderNumber As String
            Dim mWorkorderQty As String
            Dim mCreationDate As String
            Dim mStartDate As String
            Dim mDueDate As String
            Dim mWorkorderSKU As String
            Dim mChannelCode As String
            Dim mFromLocation As String
            Dim mProcessedBy As String
            Dim mShipToOfficeCode As String
            Dim mFinishedGoodsSKU As String
            Dim mInstructions As String
            Dim mCapCodeRange As String
            Dim mFreq As String
            Dim mPad As String
            Dim mStartCap As String
            Dim mEndCap As String
            Dim dt As DataTable

            Dim x As Integer
            For x = 4 To 200

                If Len(Trim(oSheet.Range("A" & x).Value)) > 0 Then
                    '//Get record to insert
                    mVendor = "PSS"
                    mReturnOfficeCode = "DDC"
                    mWorkorderNumber = oSheet.Range("B" & x).Value
                    mWorkorderQty = oSheet.Range("E" & x).Value
                    mCreationDate = Now
                    mStartDate = DateAdd(DateInterval.Day, 2, Now)
                    mDueDate = DateAdd(DateInterval.Day, 14, Now)
                    mWorkorderSKU = oSheet.Range("C" & x).Value
                    mChannelCode = Mid(oSheet.Range("C" & x).Value, 1, 10)
                    mFromLocation = "ZDI"
                    mProcessedBy = "MAXWELL"
                    mShipToOfficeCode = oSheet.Range("A" & x).Value
                    mFinishedGoodsSKU = oSheet.Range("D" & x).Value
                    mInstructions = oSheet.Range("F" & x).Value


                    mStartCap = oSheet.Range("H" & x).Value
                    mEndCap = oSheet.Range("J" & x).Value
                    mPad = Len(Trim(oSheet.Range("G" & x).Value))

                    If mPad = 8 Then
                        mPad = 9
                    ElseIf mPad = 6 Then
                        mPad = 7
                    Else
                        mPad = 9
                    End If

                    If Len(Trim(mStartCap)) = 0 Then
                        mStartCap = "0000"
                    End If
                    If Len(Trim(mEndCap)) = 0 Then
                        mEndCap = "5000"
                    End If

                    dt = ds.OrderEntrySelect("SELECT * FROM lchannel2frequency WHERE C2F_Channel = '" & Mid(oSheet.Range("D" & x).Value, 9, 3) & "'")
                    r = dt.Rows(0)
                    mFreq = r("C2F_Frequency")


                    strValidate = ""
                    '//Validate data before inserting into tusatest

                    '//Validate caps are OK

                    '//The length of capcodes must be equal
                    Try
                        If Len(Trim(mStartCap)) <> Len(Trim(mEndCap)) Then
                            strValidate += "The Upper Cap Limit does not have the same number of characters as the Lower Cap Limit." & vbCrLf
                        End If
                    Catch ex As Exception
                        strValidate += "The Upper Cap Limit does not have the same number of characters as the Lower Cap Limit." & vbCrLf
                    End Try

                    '//validate that the end capcode is higher than the start capcode
                    Try
                        If mEndCap - mStartCap > 0 Then
                            '//Validation true append nothing
                        Else
                            strValidate += "The Upper Cap Limit is Less Than the Lower Cap Limit." & vbCrLf
                        End If
                    Catch ex As Exception
                        strValidate += "Either the Upper or Lower Cap Limit is not valid." & vbCrLf
                    End Try

                    '//check to see if strValidate is populated
                    If Len(Trim(strValidate)) > 0 Then
                        '//An error has occured. do not insert
                        MsgBox("Error:" & vbCrLf & strValidate & vbCrLf & "The record will not be inserted.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If

                    '//Insert data into tusatest
                    Dim StrFieldList As String
                    StrFieldList = "(USA_WO, USA_Vendor, USA_ReturnOfficeCode, USA_Qty, USA_CreationDate, "
                    StrFieldList += "USA_StartDate, USA_DueDate, USA_Channel, USA_SKU, USA_FromLocation, USA_ProcessedBy, "
                    StrFieldList += "USA_ShipTo, USA_FinishedGoodsSKU, USA_Instructions, USA_CapLow, USA_CapHigh, USA_Freq, USA_Pad)"

                    Dim strFieldData As String
                    strFieldData = "('" & mWorkorderNumber & " ', '" & mVendor & "', '" & mReturnOfficeCode & "', " & mWorkorderQty & ", '" & mCreationDate & "', "
                    strFieldData += "' " & mStartDate & "', '" & mDueDate & "', '" & mChannelCode & "', '" & mWorkorderSKU & "', '" & mFromLocation & "', '" & mProcessedBy & "', "
                    strFieldData += "' " & mShipToOfficeCode & "', '" & mFinishedGoodsSKU & "', '" & mInstructions & "', '" & mStartCap & "', '" & mEndCap & "', '" & mFreq & "', " & mPad & ")"

                    Dim strInsert As String
                    Dim blnInsert As Boolean

                    Try
                        strInsert = "INSERT INTO tusatest " & StrFieldList & " VALUES " & strFieldData
                        blnInsert = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strInsert)
                        If blnInsert = True Then
                            'MsgBox("Entry Complete", MsgBoxStyle.OKOnly, "DONE")
                        ElseIf blnInsert = False Then
                            MsgBox("The data could not be inserted.", MsgBoxStyle.Critical, "ERROR")
                        End If
                    Catch ex As Exception
                        MsgBox("The data could not be inserted.", MsgBoxStyle.Critical, "ERROR")
                    End Try

                End If


            Next

            dt.Dispose()
            dt = Nothing

            MsgBox("Complete")

            Exit Sub
            '//OLD CODE

            'Dim objXL As Excel.Application
            'Dim oSheet As Excel.Worksheet

            'objXL = New Excel.Application()

            'Me.OpenFileDialog1.ShowDialog()
            'objXL.Workbooks.Open(OpenFileDialog1.FileName)
            'oSheet = objXL.Worksheets(1)

            'Dim mVendor As String = oSheet.Range("B13").Value
            'Dim mReturnOfficeCode As String = oSheet.Range("B14").Value
            'Dim mWorkorderNumber As String = oSheet.Range("B15").Value
            'Dim mWorkorderQty As String = oSheet.Range("B16").Value
            'Dim mCreationDate As String = oSheet.Range("B17").Value
            'Dim mStartDate As String = oSheet.Range("B18").Value
            'Dim mDueDate As String = oSheet.Range("B19").Value
            'Dim mWorkorderSKU As String = oSheet.Range("B20").Value
            'Dim mChannelCode As String = oSheet.Range("B21").Value
            'Dim mFromLocation As String = oSheet.Range("B22").Value
            'Dim mProcessedBy As String = oSheet.Range("B23").Value
            'Dim mShipToOfficeCode As String = oSheet.Range("B27").Value
            'Dim mFinishedGoodsSKU As String = oSheet.Range("B28").Value
            'Dim mInstructions As String = oSheet.Range("B37").Value
            'Dim mCapCodeRange As String = oSheet.Range("E38").Value
            'Dim mFreq As String = oSheet.Range("E39").Value

            'Dim intCapCodeMarker As Integer
            'Dim mStartCap As String
            'Dim mEndCap As String
            'Dim mPad As String


            'Try
            'intCapCodeMarker = InStr(mCapCodeRange, "-")
            'mStartCap = Trim(Mid$(mCapCodeRange, 1, intCapCodeMarker - 1))
            'mEndCap = Trim(Mid$(mCapCodeRange, intCapCodeMarker + 1, 10))
            'Catch EX As Exception
            'intCapCodeMarker = 0
            'End Try

            'If intCapCodeMarker = 0 Then
            'mStartCap = "WARRANTY"
            'mEndCap = "WARRANTY"
            'End If

            'mPad = oSheet.Range("F38").Value

            ''Dim strValidate As String = ""
            'Dim dsV As PSS.Data.Production.Joins
            ''//Validate data before inserting into tusatest

            ''//Validate caps are OK

            ''//The length of capcodes must be equal
            'Try
            'If Len(Trim(mStartCap)) <> Len(Trim(mEndCap)) Then
            '    strValidate += "The Upper Cap Limit does not have the same number of characters as the Lower Cap Limit." & vbCrLf
            'End If
            'Catch ex As Exception
            'strValidate += "The Upper Cap Limit does not have the same number of characters as the Lower Cap Limit." & vbCrLf
            'End Try

            ''//validate that the end capcode is higher than the start capcode
            'Try
            'If mEndCap - mStartCap > 0 Then
            '    '//Validation true append nothing
            'Else
            '    strValidate += "The Upper Cap Limit is Less Than the Lower Cap Limit." & vbCrLf
            'End If
            'Catch ex As Exception
            'strValidate += "Either the Upper or Lower Cap Limit is not valid." & vbCrLf
            'End Try

            ''//Validate Frequency
            ''Dim ds As PSS.Data.Production.Joins
            'Dim dtFreq As DataTable = ds.OrderEntrySelect("select * from lchannel2frequency where c2f_frequency = '" & Trim(mFreq) & "'")
            ''Dim r As DataRow
            'r = dtFreq.Rows(0)
            'Try
            'If Trim(r("C2F_Channel")) <> Trim(Mid$(mFinishedGoodsSKU, 9, 3)) Then
            '    strValidate += "The Channel does not relate to the frequency value." & vbCrLf
            'End If
            'Catch ex As Exception
            'strValidate += "The Channel does not relate to the frequency value." & vbCrLf
            'End Try

            ''//check to see if strValidate is populated
            'If Len(Trim(strValidate)) > 0 Then
            ''//An error has occured. do not insert
            'MsgBox("Error:" & vbCrLf & strValidate & vbCrLf & "The record will not be inserted.", MsgBoxStyle.OKOnly, "ERROR")
            'Exit Sub
            'End If

            ''//Insert data into tusatest
            'Dim StrFieldList As String
            'StrFieldList = "(USA_WO, USA_Vendor, USA_ReturnOfficeCode, USA_Qty, USA_CreationDate, "
            'StrFieldList += "USA_StartDate, USA_DueDate, USA_Channel, USA_SKU, USA_FromLocation, USA_ProcessedBy, "
            'StrFieldList += "USA_ShipTo, USA_FinishedGoodsSKU, USA_Instructions, USA_CapLow, USA_CapHigh, USA_Freq, USA_Pad)"

            'Dim strFieldData As String
            'strFieldData = "('" & mWorkorderNumber & " ', '" & mVendor & "', '" & mReturnOfficeCode & "', " & mWorkorderQty & ", '" & mCreationDate & "', "
            'strFieldData += "' " & mStartDate & "', '" & mDueDate & "', '" & mChannelCode & "', '" & mWorkorderSKU & "', '" & mFromLocation & "', '" & mProcessedBy & "', "
            'strFieldData += "' " & mShipToOfficeCode & "', '" & mFinishedGoodsSKU & "', '" & mInstructions & "', '" & mStartCap & "', '" & mEndCap & "', '" & mFreq & "', " & mPad & ")"

            'Dim strInsert As String
            'Dim blnInsert As Boolean

            'Try
            'strInsert = "INSERT INTO tusatest " & StrFieldList & " VALUES " & strFieldData
            'blnInsert = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strInsert)
            'If blnInsert = True Then
            'MsgBox("Entry Complete", MsgBoxStyle.OKOnly, "DONE")
            'ElseIf blnInsert = False Then
            '    MsgBox("The data could not be inserted.", MsgBoxStyle.Critical, "ERROR")
            'End If
            'Catch ex As Exception
            'MsgBox("The data could not be inserted.", MsgBoxStyle.Critical, "ERROR")
            'End Try

        End Sub

        Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim strWeekday As String
            '//Determine day of week for NOW

            Dim strTime As String = Format(Now, "hh:mm:ss")
            Dim intWeekday As Integer

            If strTime < "06:00:00" Then
                intWeekday = Weekday(DateAdd(DateInterval.Day, -1, Now))
            Else
                intWeekday = Weekday(Now)
            End If

            MsgBox(strTime)

            Select Case intWeekday
                Case 1
                    strWeekday = "Sunday"
                Case 2
                    strWeekday = "Monday"
                Case 3
                    strWeekday = "Tuesday"
                Case 4
                    strWeekday = "Wednesday"
                Case 5
                    strWeekday = "Thursday"
                Case 6
                    strWeekday = "Friday"
                Case 7
                    strWeekday = "Saturday"
                Case Else
                    strWeekday = "NONE"
            End Select

            MsgBox(strWeekday)

            'Get records from
            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable
            Dim strSQL As String
            strSQL = "select * from tshiftdetail where SD_Day = '" & strWeekday & "'"
            dt = ds.OrderEntrySelect(strSQL)

            Dim DateDiff As Integer
            Dim DateMark As String
            Dim DATEstart As String
            Dim DATEend As String
            Dim DATEnow As Date = Now

            Dim r As DataRow

            Dim xCount As Integer = 0
            For xCount = 0 To dt.Rows.Count - 1
                '//Determine which time interval works
                'Get date dynamics
                r = dt.Rows(xCount)
                If IsDBNull(r("SD_DayDiff")) = True Then
                    DateDiff = 0
                Else
                    DateDiff = r("SD_DayDiff")
                End If
                DateMark = r("SD_DD_Point")

                If DateDiff > 0 Then
                    If DateMark = "S" Then
                        DATEstart = Format(DateAdd(DateInterval.Day, DateDiff, Now), "yyyy-MM-dd")
                        DATEend = Format(Now, "yyyy-MM-dd")
                    ElseIf DateMark = "E" Then
                        DATEstart = Format(Now, "yyyy-MM-dd")
                        DATEend = Format(DateAdd(DateInterval.Day, DateDiff, Now), "yyyy-MM-dd")
                    End If
                Else
                    '//Use today
                    DATEstart = Format(Now, "yyyy-MM-dd")
                    DATEend = Format(Now, "yyyy-MM-dd")
                End If

                DATEstart += DATEstart & " " & r("SD_Start")
                DATEend += DATEend & " " & r("SD_End")

                '//Perform the comparison

                If DATEnow > DATEstart And DATEnow < DATEend Then
                    '//Assign value and exit sub
                    MsgBox(r("Shift_ID"))
                    Exit Sub
                End If
            Next

        End Sub


        Private Sub btnLoadCapCdoe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFile As String
            Dim r, rDS As DataRow

            strFile = "C:\CapCodeData_101105.xls"

            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFile & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()

            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect

            objAdapter1.Fill(dt)
            objAdapter1.Fill(objDataset1, "XLData")

            MsgBox(dt.Rows.Count)

            Dim strUpdate As String
            Dim pssUpd As PSS.Data.Production.Joins
            Dim blnUpdate As Boolean
            Dim rUpdate As DataRow

            Dim xCount As Integer

            For xCount = 0 To dt.Rows.Count - 1
                rUpdate = dt.Rows(xCount)
                If Len(Trim(rUpdate("SerialNumber"))) > 0 Then
                    strUpdate = "UPDATE tdevicemetro SET devicemetro_capcode = '" & rUpdate("CapCode") & "' WHERE devicemetro_sn = '" & Trim(rUpdate("SerialNumber")) & "'"
                    Try
                        blnUpdate = pssUpd.OrderEntryUpdateDelete(strUpdate)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If
            Next

        End Sub

        Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click

            If Len(Trim(txtWo.Text)) > 0 Then
                Dim ds As PSS.Data.Production.Joins
                Dim dt As DataTable = ds.OrderEntrySelect("SELECT tdevicemetro.devicemetro_capcode, count(tdevicemetro.devicemetro_capcode) as rcdCount FROM tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id inner join tdevicemetro on tdevice.device_sn = tdevicemetro.devicemetro_sn where tdevice.wo_id = " & txtWo.Text & " and tdevicebill.billcode_id = 25 group by tdevicemetro.devicemetro_capcode order by tdevicemetro.devicemetro_capcode")

                lstCap.Items.Clear()

                Dim x As Integer = 0
                Dim r As DataRow
                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("rcdCount") < 2 Then
                        lstCap.Items.Add(r("Devicemetro_capcode"))
                    End If
                Next

                'Me.lstCap.DataSource = dt.Columns("devicemetro_capcode").ToString

                ds = Nothing


            End If


        End Sub


        Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
            lstCap.Items.Clear()
            txtWo.Focus()
        End Sub

        Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable
            Dim strSQL As String = "Select * from tdevice where tdevice.wo_id = 78247 and tray_id not in (475293,475296,475298,475351,475358,475363,475372,475394,475398,475404) order by tray_id, Device_Cnt"


            dt = ds.OrderEntrySelect(strSQL)
            Dim r As DataRow
            Dim xCount As Integer
            Dim blnUpdate As Boolean
            Dim vSerial As String
            Dim strsql2 As String
            Dim intCapcode As Long

            intCapcode = 11102228

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                vSerial = r("device_sn")
                If Len(Trim(vSerial)) > 0 Then
                    strsql2 = "UPDATE tdevicemetro set devicemetro_capcode = '0" & intCapcode & "' WHERE devicemetro_sn = '" & vSerial & "'"
                    blnUpdate = ds.OrderEntryUpdateDelete(strsql2)
                    intCapcode += 1
                End If
            Next









        End Sub



        Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAveragePriceOnly.Click

            '//Create datatable form Navision which holds data values for Part numbers and pricing
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtNavision As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            Dim blnDelete As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete("DELETE FROM tnavprice_average_cost")
            If blnDelete = False Then
                MsgBox("The table tnavprice_average_cost could not be cleared. The process can not continue.")
                Exit Sub
            End If

            '//NEW NAVISION DATATABLE FOR SOURCE DATA - START
            Dim odbcStr As String = "SELECT No_ as Part, ""Unit Cost"" as UnitCost, ""Unit Price"" as StandardCost FROM Item"

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()
            Try
                nda.Fill(dtNavision)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            nda.Dispose()
            '//NEW NAVISION DATATABLE FOR SOURCE DATA - END

            '//NEW PSSI DATATABLE FOR SOURCE DATA - START
            Dim dtPSSI As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT PSPrice_Number, PSPrice_Desc, PSPrice_AvgCost, PSPrice_StndCost, PSPrice_InventoryPart FROM lpsprice")
            '//NEW PSSI DATATABLE FOR SOURCE DATA - END

            '//Make array for new data use PSSI source as the source for the array add three additional dimensions
            Dim arrNewData(dtPSSI.Rows.Count, 8) As String
            '//Make array for new data use PSSI source as the source for the array add three additional dimensions

            '//Load elements to array
            Dim xCount As Integer
            Dim yCount As Integer

            Dim rPSSI As DataRow
            Dim rNavision As DataRow

            For xCount = 0 To dtPSSI.Rows.Count - 1
                rPSSI = dtPSSI.Rows(xCount)
                '//Add data from PSSI source
                If IsDBNull(rPSSI("PSPrice_Number")) = False Then arrNewData(xCount, 1) = rPSSI("PSPrice_Number")
                If IsDBNull(rPSSI("PSPrice_Desc")) = False Then arrNewData(xCount, 2) = rPSSI("PSPrice_Desc")
                If IsDBNull(rPSSI("PSPrice_AvgCost")) = False Then arrNewData(xCount, 3) = rPSSI("PSPrice_AvgCost")
                If IsDBNull(rPSSI("PSPrice_StndCost")) = False Then arrNewData(xCount, 4) = rPSSI("PSPrice_StndCost")
                If IsDBNull(rPSSI("PSPrice_InventoryPart")) = False Then arrNewData(xCount, 5) = rPSSI("PSPrice_InventoryPart")

                For yCount = 0 To dtNavision.Rows.Count - 1
                    rNavision = dtNavision.Rows(yCount)
                    '//Add data fron Navision source is Part ID's match

                    If Trim(UCase(rNavision("Part"))) = Trim(UCase(rPSSI("PSPrice_Number"))) Then
                        arrNewData(xCount, 6) = rNavision("Part")
                        arrNewData(xCount, 7) = rNavision("UnitCost")
                        arrNewData(xCount, 8) = rNavision("StandardCost")
                        Exit For
                    End If
                Next
            Next

            '//The complete data array should be completed.
            '//Now write data to table for storage
            Dim vDate As String = Gui.Receiving.FormatDateShort(Now)
            Dim vInsert As PSS.Data.Production.Joins
            Dim v1, v2, v6 As String
            Dim v3, v4, v7, v8 As Double
            Dim v5 As Integer

            For xCount = 0 To dtPSSI.Rows.Count - 1

                Try
                    v1 = arrNewData(xCount, 1)
                Catch ex As Exception
                End Try
                Try
                    v2 = arrNewData(xCount, 2)
                Catch ex As Exception
                    v2 = ""
                End Try
                Try
                    v3 = arrNewData(xCount, 3)
                Catch ex As Exception
                    v3 = 0
                End Try
                Try
                    v4 = arrNewData(xCount, 4)
                Catch ex As Exception
                    v4 = 0
                End Try
                Try
                    v5 = arrNewData(xCount, 5)
                Catch ex As Exception
                End Try
                Try
                    v6 = arrNewData(xCount, 6)
                Catch ex As Exception
                End Try
                Try
                    v7 = arrNewData(xCount, 7)
                Catch ex As Exception
                End Try
                Try
                    v8 = arrNewData(xCount, 8)
                Catch ex As Exception
                End Try

                Dim vWriteData As Boolean = False
                '//Run business rules to determine whether to write fdata values or not
                '//If amounts are not even then data needs to be written
                If v3 <> v7 And Len(Trim(v6)) > 0 Then vWriteData = True
                If v4 <> v8 And Len(Trim(v6)) > 0 Then vWriteData = True

                Dim strDesc As String = v2
                Dim strDescCh As String
                Dim i As Integer

                i = StrComp(v2, "'", vbTextCompare)
                If i > 0 Then
                    strDescCh = Replace(v2, "'", "\'", 1, -1, vbTextCompare)
                    v2 = strDescCh
                End If

                Dim blnWrite As Boolean
                Dim strSQL As String
                If vWriteData = True Then
                    strSQL = "INSERT INTO tnavprice_average_cost (PSSI_Date, PSSI_Number, PSSI_Desc, PSSI_AvgCost, PSSI_InvPart, NAV_Number, NAV_UnitCost, NAV_StndCost) VALUES ('" & vDate & "','" & v1 & "','" & v2 & "'," & v3 & ", " & v5 & ", '" & v6 & "'," & v7 & "," & v8 & ")"
                    blnWrite = vInsert.OrderEntryUpdateDelete(strSQL)
                End If

            Next
            System.Windows.Forms.Application.DoEvents()

            MsgBox("END OF PART 1")
            'Exit Sub

            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tnavprice_average_cost")
            Dim r As DataRow
            Dim blnValue As Boolean
            Dim ds As PSS.Data.Production.Joins

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                If Len(Trim(r("PSSI_Number"))) > 0 Then
                    '//This is the normal SQL
                    'blnValue = ds.OrderEntryUpdateDelete("UPDATE lpsprice SET psprice_AvgCost = " & r("NAV_UnitCost") & ", psprice_StndCost = " & r("Nav_StndCost") & " WHERE PSPrice_Number = '" & r("PSSI_Number") & "'")
                    '//This SQL is to only update average price
                    blnValue = ds.OrderEntryUpdateDelete("UPDATE lpsprice SET psprice_AvgCost = " & r("NAV_UnitCost") & " WHERE PSPrice_Number = '" & r("PSSI_Number") & "'")
                End If
            Next

            MsgBox("COMPLETE")

        End Sub




        Private Sub Button38_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click


            Dim strDate As String = InputBox("Enter Date for Processing", "DATE")

            If Len(Trim(strDate)) < 1 Then
                Exit Sub
            End If

            'Dim strSQL As String = "SELECT tdevice.* FROM tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where tlocation.cust_id=2058 and tdevice.device_dateship is not null and tdevice.device_dateship > '2004-12-15'"
            'Dim strSQL As String = "SELECT tdevice.* FROM tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where tlocation.cust_id=2069 and tdevice.device_dateship is not null and tdevice.device_dateship > '2005-07-12'"

            '//This one is being replaced on December 29, 2005
            'Dim strSQL As String = "SELECT tdevice.* FROM tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id where (tlocation.cust_id=2019 or tlocation.cust_id=2058) and tdevice.device_dateship is not null and tdevice.device_dateship > '" & strDate & "' and tdevice.loc_id <> 2590"
            Dim strSQL As String = "SELECT tdevice.* FROM tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id inner join tworkorder on tdevice.wo_id = tworkorder.wo_id where tdevice.loc_id = 2540 and tdevice.device_dateship is not null and tworkorder.po_id is null and tdevice.device_dateship > '2006-02-01 00:00:00' AND tdevice.device_dateship < '2006-02-05 00:00:00'"


            Dim drData As PSS.Data.Production.Joins
            Dim drSpec As PSS.Data.Production.Joins
            Dim drSpecUpd As PSS.Data.Production.Joins
            Dim blnSpec As Boolean

            Dim vTotal As Double

            Dim dtData As DataTable
            dtData = drData.OrderEntrySelect(strSQL)

            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim dtSpec As DataTable
            Dim rdt As DataRow

            If dtData.Rows.Count > 0 Then
                For xCount = 0 To dtData.Rows.Count - 1
                    r = dtData.Rows(xCount)

                    vTotal = 0
                    'vTotal = r("Device_Laborcharge")

                    dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 442")
                    If dtSpec.Rows.Count > 0 Then
                        rdt = dtSpec.Rows(0)
                        If rdt("Dbill_InvoiceAmt") > 0 Then
                            'vTotal += rdt("Dbill_InvoiceAmt")
                            vTotal += 2.0
                            'vTotal += 2.04
                        End If
                        blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevicebill set dbill_avgcost=0, dbill_stdcost=0, dbill_invoiceAmt = 0 where device_id = " & r("Device_ID") & " AND billcode_id = 442")
                    End If

                    dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 446")
                    If dtSpec.Rows.Count > 0 Then
                        rdt = dtSpec.Rows(0)
                        If rdt("Dbill_InvoiceAmt") > 0 Then
                            'vTotal += rdt("Dbill_InvoiceAmt")
                            vTotal += 4.3
                        End If
                        blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevicebill set dbill_avgcost=0, dbill_stdcost=0,  dbill_invoiceAmt = 0 where device_id = " & r("Device_ID") & " AND billcode_id = 446")
                    End If

                    dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 447")
                    If dtSpec.Rows.Count > 0 Then
                        rdt = dtSpec.Rows(0)
                        If rdt("Dbill_InvoiceAmt") > 0 Then
                            'vTotal += rdt("Dbill_InvoiceAmt")
                            vTotal += 3.0
                            blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevicebill set dbill_avgcost=0, dbill_stdcost=0,  dbill_invoiceAmt = 0 where device_id = " & r("Device_ID") & " AND billcode_id = 447")
                        End If
                        dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 448")
                    End If
                    dtSpec = drSpec.OrderEntrySelect("SELECT * FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 448")
                    If dtSpec.Rows.Count > 0 Then
                        rdt = dtSpec.Rows(0)
                        If rdt("Dbill_InvoiceAmt") > 0 Then
                            'vTotal += rdt("Dbill_InvoiceAmt")
                            vTotal += 1.85
                            blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevicebill set dbill_avgcost=0, dbill_stdcost=0,  dbill_invoiceAmt = 0 where device_id = " & r("Device_ID") & " AND billcode_id = 448")
                        End If
                    End If
                    If vTotal > 0 And vTotal > r("Device_Laborcharge") Then
                        'vTotal += r("Device_Laborcharge")
                        blnSpec = drSpecUpd.OrderEntryUpdateDelete("Update tdevice set device_laborcharge = " & vTotal & " where device_id = " & r("Device_ID"))
                    End If

                Next
            End If

            MsgBox("Complete", MsgBoxStyle.OKOnly)




        End Sub

        Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim ds As PSS.Data.Production.Joins
            Dim blnRecord As Boolean
            Dim dt As DataTable = ds.OrderEntrySelect("SELECT Device_ID FROM tdevice where wo_id = 79937")
            Dim r As DataRow
            Dim x As Integer = 0
            For x = 0 To dt.Rows.Count - 1
                r = dt.Rows(x)
                If r("Device_ID") > 0 Then
                    blnRecord = ds.OrderEntryUpdateDelete("INSERT INTO tdisposition (Disp_Date, Disp_old, Disp_New, Device_ID) VALUES ('" & Gui.Receiving.FormatDate(Now()) & "', 437, 436, " & r("Device_ID") & ")")
                End If
            Next

        End Sub

        Private Sub Button39_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable
            dt = ds.OrderEntrySelect("SELECT * FROM tdevicemetro WHERE wo_id = 80035 Order By Tray_id ")

            Dim blnUpdate As Boolean
            Dim newString As String
            Dim intNew As Integer = 34
            Dim x As Integer = 0
            Dim r As DataRow

            For x = 0 To dt.Rows.Count - 1
                r = dt.Rows(x)


                newString = Mid$(r("Devicemetro_capcode"), 1, 5) & "3" & intNew.ToString.PadLeft(3, "0")
                If Len(Trim(r("devicemetro_sn"))) > 0 Then
                    blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevicemetro SET devicemetro_capcode = '" & newString & "' WHERE WO_ID = 80035 and devicemetro_sn = '" & r("devicemetro_sn") & "'")
                End If
                intNew += 1

            Next
        End Sub

        Private Sub Button39_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable = ds.OrderEntrySelect("SELECT tdevice.Device_ID FROM tdevice INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id WHERE loc_id = 2540 and device_dateship is null and tdevicebill.billcode_id = 446 and tdevice.model_id = 841")
            Dim dtUpd As DataTable
            Dim r As DataRow
            Dim blnUpdate As Boolean

            Dim xCount As Integer = 0

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)

                If r("Device_ID") > 0 Then
                    dtUpd = ds.OrderEntrySelect("SELECT tdevicebill.billcode_id FROM tdevice INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id WHERE tdevice.device_id = " & r("Device_ID") & " AND tdevicebill.billcode_id in (637,704,731,722,358,296,316,711,729,165,416,730,173,701,298,620,190,718,721,655,654,630,301,632,719,201,710,707,209,638,519,723,708,709,702,703,705,706,300,232,399,413,452,453,454,455,714,715,716,717,625,626,621,622,649,647,648,634,725,636,724,635,253)")
                    System.Windows.Forms.Application.DoEvents()
                    If dtUpd.Rows.Count < 1 Then
                        MsgBox(r("Device_ID"))
                        'If r("Device_ID") > 0 Then
                        'blnUpdate = ds.OrderEntryUpdateDelete("DELETE FROM tdevicebill where device_id = " & r("Device_ID") & " AND billcode_id = 446")
                        'End If
                    End If
                End If
            Next

        End Sub


        Private Sub btnLoadTechPSSI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadTechPSSI.Click

            Dim objXL As Excel.Application
            Dim oSheet As Excel.Worksheet
            Dim OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim objDataset1 As New DataSet()
            Dim xCount As Integer = 0
            Dim r As DataRow

            Dim ds As PSS.Data.Production.Joins
            Dim blnInsert As Boolean
            Dim mDate As String
            Dim strSQL As String

            '//Get the filename to load from
            OpenFileDialog1.ShowDialog()
            'MsgBox(OpenFileDialog1.FileName)
            If Len(Trim(OpenFileDialog1.filename)) < 1 Then
                MsgBox("Data can not be loaded. No file has been selected.", MsgBoxStyle.OKOnly)
                Exit Sub
            End If
            'objXL.Workbooks.Open(OpenFileDialog1.FileName)
            'oSheet = objXL.Worksheets(1)

            '//Create a datatable of all values from the assigned file
            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & OpenFileDialog1.filename & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()
            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]") '
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect
            objAdapter1.Fill(dt)
            objAdapter1.Fill(objDataset1, "XLData")


            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)

                '//Format the information correctly
                Dim errData As String = ""
                If Len(Trim(r("EmployeeNo"))) < 1 Then errData += "No Employee Number." & vbCrLf
                If Len(Trim(r("Employee Name"))) < 1 Then errData += "No Employee Name." & vbCrLf
                If Len(Trim(r("Item Date"))) < 1 Then errData += "No Item Date." & vbCrLf
                If Len(Trim(r("Hours"))) < 1 Then errData += "No Hours." & vbCrLf

                If Len(Trim(errData)) > 0 Then
                    MsgBox("Data is not correct. can not continue", MsgBoxStyle.OKOnly)
                    Exit Sub
                End If

                '//Insert data
                mDate = Gui.Receiving.FormatDateShort(r("Item Date"))

                strSQL = "INSERT INTO ttechhours " & _
                         "(employee_no, techhours_username, techhours_date, techhours_hours, techhours_filename) " & _
                         "VALUES " & _
                         "(" & r("EmployeeNo") & ", '" & r("Employee Name") & "', '" & mDate & "', " & r("Hours") & ", '" & OpenFileDialog1.filename & "')"

                blnInsert = ds.OrderEntryUpdateDelete(strSQL)
            Next

            MsgBox("Load is complete.", MsgBoxStyle.OKOnly)

        End Sub

        Private Sub btnLoadTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadTemp.Click

            Dim objXL As Excel.Application
            Dim oSheet As Excel.Worksheet
            Dim OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim objDataset1 As New DataSet()
            Dim xCount As Integer = 0
            Dim r As DataRow

            Dim ds As PSS.Data.Production.Joins
            Dim blnInsert As Boolean
            Dim mDate As String
            Dim strSQL As String

            '//Get the filename to load from
            OpenFileDialog1.ShowDialog()
            'MsgBox(OpenFileDialog1.FileName)
            If Len(Trim(OpenFileDialog1.filename)) < 1 Then
                MsgBox("Data can not be loaded. No file has been selected.", MsgBoxStyle.OKOnly)
                Exit Sub
            End If
            'objXL.Workbooks.Open(OpenFileDialog1.FileName)
            'oSheet = objXL.Worksheets(1)

            '//Create a datatable of all values from the assigned file
            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & OpenFileDialog1.filename & ";Extended Properties=Excel 8.0;"
            objConn.ConnectionString = sConnectionstring
            objConn.Open()
            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]") '
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect
            objAdapter1.Fill(dt)
            objAdapter1.Fill(objDataset1, "XLData")


            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                Try
                    '//Format the information correctly
                    Dim errData As String = ""
                    If Len(Trim(r("EmployeeNo"))) < 1 Then errData += "No Employee Number." & vbCrLf
                    If Len(Trim(r("Employee Name"))) < 1 Then errData += "No Employee Name." & vbCrLf
                    If Len(Trim(r("Item Date"))) < 1 Then errData += "No Item Date." & vbCrLf
                    If Len(Trim(r("Hours"))) < 1 Then errData += "No Hours." & vbCrLf

                    If Len(Trim(errData)) > 0 Then
                        MsgBox("Data is not correct. can not continue", MsgBoxStyle.OKOnly)
                        Exit Sub
                    End If

                    '//Insert data
                    mDate = Gui.Receiving.FormatDateShort(r("Item Date"))

                    strSQL = "INSERT INTO ttechhours " & _
                             "(employee_no, techhours_username, techhours_date, techhours_hours, techhours_filename) " & _
                             "VALUES " & _
                             "(" & r("EmployeeNo") & ", '" & r("Employee Name") & "', '" & mDate & "', " & r("Hours") & ", '" & OpenFileDialog1.filename & "')"

                    blnInsert = ds.OrderEntryUpdateDelete(strSQL)
                Catch ex As Exception
                End Try
            Next

            MsgBox("Load is complete.", MsgBoxStyle.OKOnly)

        End Sub






        Private Sub btnXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim ds As PSS.Data.Production.Joins
            Dim strSQL As String
            Dim x, xParts, xWork, xPF, xRS As Integer
            Dim r, rParts, rWork, rPF, rRS As DataRow
            Dim dtParts As DataTable
            Dim dtWork As DataTable
            Dim dtPF As DataTable
            Dim dtRepairStatus As DataTable
            Dim mRepairStatus As String

            Dim myWriter As System.Xml.XmlTextWriter
            myWriter = New System.Xml.XmlTextWriter("c:\CellStarClosed.xml", Nothing)

            mywriter.Indentation = 4
            mywriter.IndentChar = " "
            mywriter.Formatting = mywriter.Indentation

            '//Get a list of all closed devices where ship date > '2006-08-24 00:00:00'
            'strSQL = "SELECT * FROM tdevice INNER JOIN cstincomingdata ON tdevice.device_SN = cstincomingdata.csin_ESN WHERE Loc_ID = 2636 AND device_DateShip > '2006-08-24 00:00:00'"
            strSQL = "SELECT * FROM tdevice INNER JOIN cstincomingdata ON tdevice.device_SN = cstincomingdata.csin_ESN WHERE Loc_ID = 2636 AND device_SN = '02120221202'"

            Dim dtDevices As DataTable = ds.OrderEntrySelect(strSQL)

            If dtDevices.Rows.Count > 0 Then
                '//There are devices to record

                myWriter.WriteStartDocument()
                myWriter.WriteStartElement("RepairUpdateStatus")

                For x = 0 To dtDevices.Rows.Count - 1
                    '//Device Header Data
                    r = dtDevices.Rows(x)

                    '//writer header values
                    myWriter.WriteStartElement("RepairItem")
                    myWriter.WriteElementString("InvoiceNumber", r("csin_RepairOrderNum"))
                    myWriter.WriteElementString("ESN", r("csin_ESN"))
                    myWriter.WriteElementString("RepairStatus", "Out")
                    myWriter.WriteElementString("RepairStatusTimestamp", FormatDate(Now))
                    'myWriter.WriteElementString("RepairStatusTimestamp", r("Device_DateShip"))

                    myWriter.WriteElementString("ServiceCenterID", "0001")


                    '//Verify proper service code to use
                    mRepairStatus = ""
                    '//RUR Status
                    strSQL = "SELECT lbillcodes.billcode_id, lbillcodes.billcode_rule FROM tdevice " & _
                    "INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & _
                    "WHERE tdevice.device_id = " & r("Device_ID")
                    dtRepairStatus = ds.OrderEntrySelect(strSQL)

                    For xRS = 0 To dtRepairStatus.Rows.Count - 1
                        rRS = dtRepairStatus.Rows(xRS)
                        'RUR
                        If rRS("billcode_rule") = 1 Or rRS("billcode_rule") = 2 Then
                            mRepairStatus = "0"
                            Exit For
                        End If
                        'No Trouble Found
                        If rRS("billcode_id") = 541 Or rRS("billcode_id") = 533 Then
                            mRepairStatus = "5"
                            Exit For
                        End If
                        'Flashing
                        If rRS("billcode_id") = 442 Then
                            mRepairStatus = "6"
                            Exit For
                        End If
                        'Cancelled
                        If rRS("billcode_id") = 466 Then
                            mRepairStatus = "7"
                            Exit For
                        End If
                    Next

                    If Len(Trim(mRepairStatus)) > 0 Then
                        myWriter.WriteElementString("RepairServiceLevel", mRepairStatus)
                    Else
                        myWriter.WriteElementString("RepairServiceLevel", r("Device_LaborLevel"))
                    End If
                    mRepairStatus = ""
                    '//Verify proper service code to use


                    '//Get Parts Data (Multiple entries)
                    strSQL = "SELECT PSPrice_Number, PSPrice_Desc, Dbill_InvoiceAmt, Device_ManufWrty, Device_LaborCharge, Device_PSSWrty FROM tdevice INNER JOIN tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "INNER JOIN tpsmap ON tdevicebill.billcode_id = tpsmap.billcode_id AND tdevice.model_id = tpsmap.model_id " & _
                    "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id " & _
                    "WHERE lbillcodes.billtype_id = 2 " & _
                    "AND tdevice.device_id = " & r("Device_ID")

                    dtParts = ds.OrderEntrySelect(strSQL)
                    If dtParts.Rows.Count > 0 Then
                        myWriter.WriteStartElement("PartsConsumed")
                        For xParts = 0 To dtParts.Rows.Count - 1
                            rParts = dtParts.Rows(xParts)
                            myWriter.WriteStartElement("Parts")
                            myWriter.WriteElementString("PartNumber", rParts("PSPrice_Number"))
                            myWriter.WriteElementString("PartDescription", rParts("PSPrice_Desc"))
                            myWriter.WriteElementString("PartCost", rParts("DBill_InvoiceAmt"))
                            myWriter.WriteElementString("PartWarranty", rParts("Device_ManufWrty"))
                            myWriter.WriteElementString("PartQty", "1")
                            myWriter.WriteEndElement() '//from parts
                        Next
                        myWriter.WriteEndElement()
                    End If

                    '//Assign Labor Amount
                    Try
                        rParts = dtParts.Rows(0)
                        myWriter.WriteElementString("LaborCost", rParts("Device_LaborCharge"))
                    Catch ex As Exception
                    End Try
                    '//Work Performed Section

                    strSQL = "select distinct dcode_sdesc, dcode_ldesc from " & _
                    "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "left outer join tbillmap on tlocation.cust_id = tbillmap.cust_id AND " & _
                    "tdevice.model_id = tbillmap.model_id AND " & _
                    "tdevicebill.billcode_id = tbillmap.billcode_id " & _
                    "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & _
                    "where tdevice.device_id = " & r("Device_ID")

                    dtWork = ds.OrderEntrySelect(strSQL)

                    If dtWork.Rows.Count > 0 Then
                        For xWork = 0 To dtWork.Rows.Count - 1
                            rWork = dtWork.Rows(xWork)
                            myWriter.WriteStartElement("WorkPerformed")
                            myWriter.WriteStartElement("Work")
                            myWriter.WriteElementString("WorkCode", rWork("Dcode_Sdesc"))
                            myWriter.WriteElementString("WorkDescription", rWork("Dcode_Ldesc"))
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                        Next
                    End If


                    '//Problem Found Section

                    strSQL = "select distinct dcode_sdesc, dcode_ldesc from " & _
                    "tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "left outer join tbillmap on tlocation.cust_id = tbillmap.cust_id AND " & _
                    "tdevice.model_id = tbillmap.model_id AND " & _
                    "tdevicebill.billcode_id = tbillmap.billcode_id " & _
                    "inner join lcodesdetail on tbillmap.bmap_problemfound = lcodesdetail.dcode_id " & _
                    "where tdevice.device_id = " & r("Device_ID")

                    dtPF = ds.OrderEntrySelect(strSQL)

                    If dtPF.Rows.Count > 0 Then
                        For xPF = 0 To dtPF.Rows.Count - 1
                            rPF = dtPF.Rows(xPF)
                            myWriter.WriteStartElement("ProblemFound")
                            myWriter.WriteStartElement("Problem")
                            myWriter.WriteElementString("ProblemCode", rPF("Dcode_Sdesc"))
                            myWriter.WriteElementString("ProblemDescription", rPF("Dcode_Ldesc"))
                            myWriter.WriteEndElement()
                            myWriter.WriteEndElement()
                        Next
                    End If

                    '//Warranty Item - Device
                    Try
                        myWriter.WriteElementString("Warranty", rParts("Device_PSSWrty"))
                    Catch ex As Exception
                    End Try

                    myWriter.WriteEndElement()
                Next

                myWriter.WriteEndElement()

                myWriter.WriteEndDocument()
                myWriter.Flush()

            End If

            MsgBox("Complete")

            Exit Sub

            'Dim i As Integer
            'Dim myWriter As System.Xml.XmlTextWriter
            'myWriter = New System.Xml.XmlTextWriter("c:\CellStarClosed.xml", Nothing)
            'With myWriter
            '.Indentation = 4
            '.IndentChar = " "
            '.Formatting = .Indentation
            '.WriteStartDocument()
            '.WriteStartElement("RepairUpdateStatus")
            'For i = 2 To 6
            'If Len(Trim(objXL.Range("B" & i).Value)) > 0 Then
            '.WriteStartElement("RepairItem")
            '.WriteElementString("InvoiceNumber", objXL.Range("A" & i).Value)
            '.WriteElementString("ESN", objXL.Range("B" & i).Value)
            '.WriteElementString("RepairStatus", objXL.Range("C" & i).Value)
            '.WriteElementString("RepairStatusTimestamp", objXL.Range("D" & i).Value)
            '.WriteElementString("ServiceCenterID", objXL.Range("E" & i).Value)
            'If Len(Trim(objXL.Range("G" & i).Value)) > 0 Then .WriteElementString("RepairServiceLevel", objXL.Range("G" & i).Value)
            'If Len(Trim(objXL.Range("I" & i).Value)) > 0 Then .WriteStartElement("PartsConsumed")
            'End If
            '//If Parts
            'If Len(Trim(objXL.Range("I" & i).Value)) > 0 Then
            '.WriteStartElement("Parts")
            '.WriteElementString("PartNumber", objXL.Range("I" & i).Value)
            '.WriteElementString("PartDescription", objXL.Range("J" & i).Value)
            '.WriteElementString("PartCost", objXL.Range("K" & i).Value)
            '.WriteElementString("PartWarranty", objXL.Range("L" & i).Value)
            '.WriteElementString("PartQty", objXL.Range("M" & i).Value)
            '.WriteEndElement() '//from parts
            'End If
            '//End Parts
            '//Labor
            'If Len(Trim(objXL.Range("O" & i).Value)) > 0 Then
            '.WriteEndElement()
            '.WriteElementString("LaborCost", objXL.Range("O" & i).Value)
            '//Work
            '.WriteStartElement("WorkPerformed")
            '.WriteStartElement("Work")
            '.WriteElementString("WorkCode", objXL.Range("R" & i).Value)
            '.WriteElementString("WorkDescription", objXL.Range("S" & i).Value)
            '.WriteEndElement()
            '.WriteEndElement()
            '//Problem Found
            '.WriteStartElement("ProblemFound")
            '.WriteStartElement("Problem")
            '.WriteElementString("ProblemCode", objXL.Range("W" & i).Value)
            '.WriteElementString("ProblemDescription", objXL.Range("X" & i).Value)
            '.WriteEndElement()
            '.WriteEndElement()
            '//Warranty
            '.WriteElementString("Warranty", "1")
            'End If
            'If Len(Trim(objXL.Range("B" & i).Value)) > 0 And Len(Trim(objXL.Range("O" & i).Value)) > 0 Then '//
            '.WriteEndElement()
            'ElseIf Len(Trim(objXL.Range("I" & i).Value)) < 1 And Len(Trim(objXL.Range("O" & i).Value)) < 1 Then  '//
            '    .WriteEndElement()
            'ElseIf Len(Trim(objXL.Range("I" & i).Value)) > 0 And Len(Trim(objXL.Range("O" & i).Value)) > 0 Then  '//
            '    .WriteEndElement()
            'End If
            'Next
            '.WriteEndElement()
            '.WriteEndDocument()
            'End With
            'myWriter.Flush()

        End Sub


        Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Try
                If Me.rbTray.Checked = True Then
                    intTray = Trim(txtSelect.Text)
                ElseIf Len(Trim(Me.lstTray.SelectedItem)) > 0 Then
                    intTray = Trim(Me.lstTray.SelectedItem)
                End If

                If intTray > 0 Then
                    rePrintUSAReceivingForm(intTray)
                Else
                    MsgBox("Error printing report - NO TRAY SELECTED", MsgBoxStyle.OKOnly, "ERROR")
                End If
            Catch exp As Exception

            End Try
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub Button37_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click

            Dim intCount As Integer = 0
            Dim intOldModel As Long

            Dim insWO As New PSS.Data.Production.tworkorder()
            Dim insTray As New PSS.Data.Production.ttray()
            Dim insDevice As New PSS.Data.Production.tdevice()

            Dim objXL As Excel.Application
            Dim oSheet As Excel.Worksheet
            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow

            objXL = New Excel.Application()

            Me.OpenFileDialog1.ShowDialog()
            objXL.Workbooks.Open(OpenFileDialog1.FileName)
            oSheet = objXL.Worksheets(1)

            Dim xCount As Integer
            Dim vWO As Long
            Dim vWOLong As String
            Dim vTray As Long

            vWO = 0
            vWOLong = ""
            vTray = 0

            Dim strSQL As String
            Dim dtWO As DataTable
            Dim rWO As DataRow

            Dim wo_id As Long
            Dim tray_id As Long
            Dim device_id As Long

            Dim dtModel As DataTable
            Dim rModel As DataRow
            Dim mModel As Long
            Dim mManuf As Long

            Dim dtFreq As DataTable
            Dim rFreq As DataRow
            Dim mFreq As Long
            Dim motoFreq As Long

            Dim mWrtyDate As String
            Dim iLoc As Integer
            Dim mDeviceSN As String
            Dim dtPSSWrty As DataTable
            Dim blnPSSWrty As Boolean
            Dim intPSSWrty As Integer
            Dim blnManufWrty As Boolean
            Dim intManufWrty As Integer
            Dim blnDevice As Boolean
            Dim blnUpdate As Boolean

            Dim chkValue As String
            Dim tblManufWrty As New PSS.Data.Production.lmanufwrty()
            Dim dtManufWrty As DataTable
            Dim valDateCode As String
            Dim valExpDate As Date
            Dim xMW As Integer = 0
            Dim dr As DataRow

            Dim rtray As DataRow
            Dim dtTray As DataTable

            'mWorkorderQty = oSheet.Range("E" & x).Value

            intCount = 1
            intOldModel = 0

            For xCount = 1 To 400
                If Trim(oSheet.range("A" & xCount).value) = "RMA-NO:" Or Mid$(oSheet.range("B" & xCount).value, 1, 4) = "2006" Then

                    '//*********************************************************************************
                    '//Determine if Workorder Exists
                    '//*********************************************************************************
                    strSQL = "SELECT * FROM tworkorder WHERE WO_CustWO = '" & Mid$(oSheet.range("B" & xCount).value, 4, 20) & "' AND Loc_ID =19"
                    dtWO = ds.OrderEntrySelect(strSQL)
                    System.Windows.Forms.Application.DoEvents()

                    If dtWO.Rows.Count > 0 Then
                        '//*********************************************************************************
                        '//workorder exists - get ID number
                        '//*********************************************************************************
                        rWO = dtWO.Rows(0)
                        wo_id = rWO("WO_ID")

                        '//get tray number
                        strSQL = "SELECT * FROM ttray WHERE wo_id = " & wo_id & " Order BY tray_id desc"
                        dtTray = ds.OrderEntrySelect(strSQL)
                        rtray = dtTray.Rows(0)
                        tray_id = rtray("tray_id")

                    Else
                        '//*********************************************************************************
                        '//new workorder - Insert record
                        '//*********************************************************************************
                        strSQL = "INSERT INTO TWORKORDER " & _
                        "(WO_CustWO, " & _
                        "Loc_ID, " & _
                        "Group_ID, " & _
                        "WO_SkuLength, " & _
                        "Prod_ID)" & _
                        "VALUES " & _
                        "('" & Mid$(oSheet.range("B" & xCount).value, 4, 20) & "', " & _
                        "19 " & ", " & _
                        "1 " & ", " & _
                        "0 " & ", " & _
                        "1)"
                        wo_id = insWO.idTransaction(strSQL)
                        '//*********************************************************************************
                        '//insert new tray
                        '//Each device will be in its own tray for Brightpoint
                        '//*********************************************************************************
                        If wo_id > 0 Then
                            '//new tray
                            strSQL = "INSERT INTO TTRAY " & _
                            "(Tray_RecUser, " & _
                            "WO_ID) " & _
                            "VALUES " & _
                            "('" & PSS.Core.[Global].ApplicationUser.User & "', " & _
                            wo_id & ")"
                            tray_id = insWO.idTransaction(strSQL)
                        End If
                        System.Windows.Forms.Application.DoEvents()
                    End If
                    System.Windows.Forms.Application.DoEvents()
                End If






                If Len(Trim(oSheet.range("C" & xCount).value)) > 0 Then
                    'If wo_id > 0 And tray_id > 0 Then
                    '//Translate Model
                    Try
                        strSQL = "SELECT * FROM tmodel WHERE Model_Desc = '" & oSheet.range("D" & xCount).value & "'"
                        dtModel = ds.OrderEntrySelect(strSQL)
                        rModel = dtModel.Rows(0)
                        mModel = rModel("Model_ID")
                        mManuf = rModel("Manuf_ID")
                    Catch ex As Exception
                        mModel = 0
                    End Try

                    '//If count > 25 or model change - make new tray
                    If intCount > 25 Or intOldModel <> mModel Then
                        '//make new tray
                        If wo_id > 0 Then
                            '//new tray
                            strSQL = "INSERT INTO TTRAY " & _
                            "(Tray_RecUser, " & _
                            "WO_ID) " & _
                            "VALUES " & _
                            "('" & PSS.Core.[Global].ApplicationUser.User & "', " & _
                            wo_id & ")"
                            tray_id = insWO.idTransaction(strSQL)
                            intCount = 1
                        End If
                        System.Windows.Forms.Application.DoEvents()
                    End If

                    '//Translate Frequency
                    Try
                        strSQL = "SELECT * FROM lfrequency WHERE Freq_Number = '" & oSheet.range("E" & xCount).value & "'"
                        dtFreq = ds.OrderEntrySelect(strSQL)
                        rFreq = dtFreq.Rows(0)
                        mFreq = rFreq("Freq_ID")
                        motoFreq = rFreq("Freq_MotoCode")
                    Catch ex As Exception
                        mModel = 0
                        motoFreq = 0
                    End Try
                    '//PSS Warranty
                    '//Get PSSWrty Status
                    '//90 days
                    mWrtyDate = FormatDate(DateAdd(DateInterval.Day, -90, Now))
                    iLoc = 19
                    mDeviceSN = oSheet.range("B" & xCount).value
                    dtPSSWrty = ds.chkPSSwrty(mDeviceSN, iLoc, mWrtyDate)

                    If dtPSSWrty.Rows(0)("repeat") <> False Then
                        blnPSSWrty = True
                        intPSSWrty = 1
                    Else
                        blnPSSWrty = False
                        intPSSWrty = 0
                    End If
                    System.Windows.Forms.Application.DoEvents()
                    'dtPSSWrty = Nothing
                    '//Get PSSWrty Status - END
                    '//Manufacturer Warranty
                    Try
                        xMW = 0
                        chkValue = Mid(Trim(mDeviceSN), 5, 2)
                        dtManufWrty = tblManufWrty.GetManufWrtyData(chkValue, mManuf)
                        For xMW = 0 To dtManufWrty.Rows.Count - 1
                            dr = dtManufWrty.Rows(xCount)
                            valDateCode = dr("ManufWrty_Code")
                            valExpDate = dr("ManufWrty_Exp")
                        Next
                        If valExpDate > Now Then
                            blnManufWrty = True
                            intManufWrty = 1
                        Else
                            blnManufWrty = False
                            intManufWrty = 0
                        End If
                    Catch ex As Exception
                        blnManufWrty = False
                        intManufWrty = 0
                    End Try

                    '//Validate the data to insert
                    If mModel < 1 Then
                        MsgBox("the record for wo: " & wo_id & " at tray: " & tray_id & " for serial number : " & mDeviceSN & " is invalid. the system will now stop processing this file.", MsgBoxStyle.Critical, "error")
                        Exit Sub
                    End If
                    If mFreq < 1 Then
                        MsgBox("the record for wo: " & wo_id & " at tray: " & tray_id & " for serial number : " & mDeviceSN & " is invalid. the system will now stop processing this file.", MsgBoxStyle.Critical, "error")
                        Exit Sub
                    End If
                    If wo_id < 1 Then
                        MsgBox("the record for wo: " & wo_id & " at tray: " & tray_id & " for serial number : " & mDeviceSN & " is invalid. the system will now stop processing this file.", MsgBoxStyle.Critical, "error")
                        Exit Sub
                    End If
                    If tray_id < 1 Then
                        MsgBox("the record for wo: " & wo_id & " at tray: " & tray_id & " for serial number : " & mDeviceSN & " is invalid. the system will now stop processing this file.", MsgBoxStyle.Critical, "error")
                        Exit Sub
                    End If
                    If Len(Trim(mDeviceSN)) < 1 Then
                        MsgBox("the record for wo: " & wo_id & " at tray: " & tray_id & " for serial number : " & mDeviceSN & " is invalid. the system will now stop processing this file.", MsgBoxStyle.Critical, "error")
                        Exit Sub
                    End If

                    '//*********************************************************************************
                    '//insert device
                    '//The qualifier to insert the device will be that the wo_id and tray_id <> 0
                    '//*********************************************************************************
                    If wo_id > 0 And tray_id > 0 Then
                        '//insert device
                        strSQL = "INSERT INTO TDEVICE " & _
                        "(Device_SN, " & _
                        "Device_DateRec, " & _
                        "Device_ManufWrty, " & _
                        "Device_PSSWrty, " & _
                        "Device_Cnt, " & _
                        "Device_RecWorkDate, " & _
                        "Tray_ID, " & _
                        "Loc_ID, " & _
                        "WO_ID, " & _
                        "WO_ID_Out, " & _
                        "Model_ID, " & _
                        "Shift_ID_Rec) " & _
                        "VALUES " & _
                        "('" & mDeviceSN & "', " & _
                        "'" & Gui.Receiving.FormatDate(Now) & "', " & _
                        intManufWrty & ", " & _
                        intPSSWrty & ", " & _
                        intCount & ", " & _
                        "'" & PSS.Core.[Global].ApplicationUser.Workdate & "', " & _
                        tray_id & ", " & _
                        iLoc & ", " & _
                        wo_id & ", " & _
                        wo_id & ", " & _
                        mModel & ", " & _
                        PSS.Core.[Global].ApplicationUser.IDShift & ")"

                        blnDevice = ds.OrderEntryUpdateDelete(strSQL)
                        System.Windows.Forms.Application.DoEvents()

                        '//*********************************************************************************
                        '//Get the device ID in order to create the tdevicemetro record
                        '//You can not use the idTransaction function because it runs too slow to function
                        '//It locks up the system
                        '//*********************************************************************************
                        dtDevice = ds.OrderEntrySelect("SELECT device_id FROM tdevice WHERE Device_SN = '" & mDeviceSN & "' AND WO_ID = " & wo_id)
                        r = dtDevice.Rows(0)
                        System.Windows.Forms.Application.DoEvents()
                        device_id = r("Device_ID")
                        'replace update record in tdevicemetro
                        If Len(mDeviceSN) > 0 Then
                            strSQL = "REPLACE into tdevicemetro " & _
                            "(devicemetro_SN, " & _
                            "devicemetro_CapCode, " & _
                            "devicemetro_FreqCode, " & _
                            "freq_id, " & _
                            "model_id, " & _
                            "tray_id, " & _
                            "wo_id) " & _
                            "values ('" & mDeviceSN & "', '" & oSheet.range("A" & xCount).value & "', " & motoFreq & ", " & mFreq & ", " & mModel & ", " & tray_id & ", " & wo_id & ")"
                            blnUpdate = ds.OrderEntryUpdateDelete(strSQL)
                        End If
                    End If
                End If

                intCount += 1
                intOldModel = mModel

            Next


            dtManufWrty.Dispose()
            dtManufWrty = Nothing
            tblManufWrty = Nothing





        End Sub

        Private Sub btnVerizon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerizon.Click

            Dim objXL As Excel.Application
            Dim oSheet As Excel.Worksheet
            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow

            Dim mWorkorder As String
            Dim mSerial As String
            Dim mCapCode As String
            Dim mModel As String
            Dim mFreq As String
            Dim xCount As Integer
            Dim mModelNumber As String
            Dim mSKUNumber As String
            Dim iSKU As String

            objXL = New Excel.Application()

            Me.OpenFileDialog1.ShowDialog()
            objXL.Workbooks.Open(OpenFileDialog1.FileName)
            oSheet = objXL.Worksheets(1)

            Dim dtWO As DataTable

            Dim strSQL As String

            For xCount = 1 To 1000
                If Trim(oSheet.range("A" & xCount).value) = "RMA-NO:" Or Mid$(oSheet.range("B" & xCount).value, 1, 4) = "2006" Then

                    '//*********************************************************************************
                    '//Determine if Workorder Exists
                    '//*********************************************************************************
                    strSQL = "SELECT * FROM tverdata WHERE WO_Name = '" & Mid$(oSheet.range("B" & xCount).value, 4, 20) & "'"
                    dtWO = ds.OrderEntrySelect(strSQL)
                    System.Windows.Forms.Application.DoEvents()

                    If dtWO.Rows.Count > 0 Then
                        '//*********************************************************************************
                        '//workorder exists - get ID number
                        '//*********************************************************************************
                        MsgBox("This file has already been loaded. Exiting...", MsgBoxStyle.Information, "ERROR")
                        Exit Sub
                    Else
                        '//*********************************************************************************
                        '//new workorder - Insert record
                        '//*********************************************************************************
                        '//Get WO Name
                        mWorkorder = Mid$(oSheet.range("B" & xCount).value, 4, 20)
                    End If
                End If

                If Len(Trim(oSheet.range("C" & xCount).value)) > 0 Then
                    '//Get data and insert record
                    mSerial = oSheet.range("B" & xCount).value
                    mCapCode = oSheet.range("A" & xCount).value
                    mModel = oSheet.range("D" & xCount).value
                    mFreq = oSheet.range("E" & xCount).value
                    mModelNumber = oSheet.range("C" & xCount).value

                    Try
                        '//Get SKU Number
                        iSKU = Mid$(mModelNumber, 8, 1)

                        Select Case iSKU
                            Case 8
                                mSKUNumber = "XXXXXXFLXX"
                            Case 9
                                mSKUNumber = "XXFXXXXXXX"
                            Case 3
                                mSKUNumber = "XXTXXXXXXX"
                            Case 1
                                mSKUNumber = "XX4XXXXXXX"
                        End Select
                    Catch ex As Exception
                        mSKUNumber = " "
                    End Try

                    strSQL = "INSERT INTO tverdata (WO_Name, Device_SN, Device_CapCode, Device_Model, Device_Freq, Model_Number, SKU_Number) " & _
                             "VALUES " & _
                             "('" & mWorkorder & "', '" & mSerial & "', '" & mCapCode & "', '" & mModel & "', '" & mFreq & "', '" & mModelNumber & "', '" & mSKUNumber & "')"
                    Dim blnUpdate As Boolean = ds.OrderEntryUpdateDelete(strSQL)
                End If

            Next

            MsgBox("Complete")

        End Sub



        '**********************************************************************
        'added by Lan on 02/22/07
        Private Sub cmdDelTrayDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelTrayDev.Click
            Dim objMessMisc As New PSS.Data.Buisness.MessMisc()
            Dim i As Integer = 0
            Dim strTray_id As String = Trim(InputBox("Enter tray_id:"))

            Try
                If MessageBox.Show("Are you sure you want to delete this tray and all its devices?", "Delete Tray", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                'Validations
                If Trim(strTray_id) = "" Then
                    Exit Sub
                End If
                If Not IsNumeric(Trim(strTray_id)) Then
                    Throw (New Exception("Incorrect tray_id format."))
                End If

                'Me.cmdDelTrayDev.Enabled = False

                'Delete Tray
                i = objMessMisc.DeleteTray(CInt(Trim(strTray_id)))

                'Confirmation Message
                If i > 0 Then
                    MsgBox("Tray has been deleted. Please discard the old paper work promptly.")
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Delete Tray", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMessMisc = Nothing
                'Me.cmdDelTrayDev.Enabled = True
            End Try
        End Sub
    End Class

End Namespace
