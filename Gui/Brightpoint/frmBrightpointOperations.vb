Option Explicit On 

Imports PSS.Core.[Global]

Public Class frmBrightpointOperations
    Inherits System.Windows.Forms.Form

    Private GobjBrightpoint As PSS.Data.Buisness.Brightpoint

    Private GstrMachine As String = System.Net.Dns.GetHostName
    Private GstrUserName As String = ApplicationUser.User
    Private GiUserID As Integer = ApplicationUser.IDuser
    Private GiEmpNo As Integer = ApplicationUser.NumberEmp
    Private GiShiftID As Integer = ApplicationUser.IDShift
    Private GstrWorkDate As String = ApplicationUser.Workdate
    Private GiMachineGroupID As String = ApplicationUser.GroupID
    Private GstrMachineGroupDesc As String = ApplicationUser.Group_Desc
    Private GiWCLocationID As Integer = 0
    Private GiLineID As Integer = ApplicationUser.LineID

    Private GbooBPRecSecure As Boolean = False
    Private GbooBPSlvgSecure As Boolean = False
    Private GbooBPReportSecure As Boolean = False
    Private GbooBPAdminSecure As Boolean = False
    Private GbooBPBillSecure As Boolean = False
    Private GbooBPReRecShipLess30DaysDev As Boolean = False

    Private Const GiPanelRecIndex As Integer = 1
    Private Const GiPanelShipIndex As Integer = 2
    Private Const GiPanelReportIndex As Integer = 3
    Private Const GiPanelAdminIndex As Integer = 4
    Private Const GiPanelBillIndex As Integer = 5

    Private Const GiCust_ID As Integer = 2113
    Private Const GiLoc_ID As Integer = 2636
    Private Const GstrEnterpriseCode As String = "DOB"
    Private Const GiRURSalvageBillcode_ID As Integer = 1234
    Private Const GiCell2SlvgGroup_ID As Integer = 74

    Private GSendMClaimFlg As Integer = 0
    Private GSendNKClaimFlg As Integer = 0

    '***********
    'Receiving
    '***********
    Private GdtRecItems As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        GobjBrightpoint = New PSS.Data.Buisness.Brightpoint()

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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdAdmin As System.Windows.Forms.Button
    Friend WithEvents cmdReceive As System.Windows.Forms.Button
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cmdReports As System.Windows.Forms.Button
    Friend WithEvents panelRec As System.Windows.Forms.Panel
    Friend WithEvents PanelRpt As System.Windows.Forms.Panel
    Friend WithEvents PanelAdmin As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblRecMsg As System.Windows.Forms.Label
    Friend WithEvents grdRecDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblRecScanCnt As System.Windows.Forms.Label
    Friend WithEvents btnRecRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnRecRemoveOne As System.Windows.Forms.Button
    Friend WithEvents cmdRecLoadDev As System.Windows.Forms.Button
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents btnAdminLoadASNFrmDOB As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRecDevSN As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnRptWIPRptToDOB As System.Windows.Forms.Button
    Friend WithEvents txtRecPartNum As System.Windows.Forms.TextBox
    Friend WithEvents grdSlvgSlvgInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtSlvgDevSN As System.Windows.Forms.TextBox
    Friend WithEvents btnSlvgTransfer As System.Windows.Forms.Button
    Friend WithEvents lstSlvgSNs As System.Windows.Forms.ListBox
    Friend WithEvents btnSlvgRemoveOne As System.Windows.Forms.Button
    Friend WithEvents btnSlvgRemoveAll As System.Windows.Forms.Button
    Friend WithEvents lblSlvgScanCnt As System.Windows.Forms.Label
    Friend WithEvents GroupBoxSlvgTransDev As System.Windows.Forms.GroupBox
    Friend WithEvents PanelSlvg As System.Windows.Forms.Panel
    Friend WithEvents cmdSlvg As System.Windows.Forms.Button
    Friend WithEvents rdbtnSlvgTransToSlvg As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtnSlvgTransToIntransit As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpRptShipFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRptShipToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRptGenASNRpt As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grpboxRptASNRpt As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSlvgMemo As System.Windows.Forms.TextBox
    Friend WithEvents chkRecShipLess30Days As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdminCloseTodaysPreBill As System.Windows.Forms.Button
    Friend WithEvents grpboxPreBill As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdminReprintPreBillLot As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAdminLotName As System.Windows.Forms.Label
    Friend WithEvents txtAdminPreBillSN As System.Windows.Forms.TextBox
    Friend WithEvents chkRec_DevsFrBP As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBrightpointOperations))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.cmdReports = New System.Windows.Forms.Button()
        Me.cmdSlvg = New System.Windows.Forms.Button()
        Me.cmdAdmin = New System.Windows.Forms.Button()
        Me.cmdReceive = New System.Windows.Forms.Button()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.panelRec = New System.Windows.Forms.Panel()
        Me.chkRec_DevsFrBP = New System.Windows.Forms.CheckBox()
        Me.chkRecShipLess30Days = New System.Windows.Forms.CheckBox()
        Me.txtRecPartNum = New System.Windows.Forms.TextBox()
        Me.cmdRecLoadDev = New System.Windows.Forms.Button()
        Me.btnRecRemoveAll = New System.Windows.Forms.Button()
        Me.btnRecRemoveOne = New System.Windows.Forms.Button()
        Me.lblRecScanCnt = New System.Windows.Forms.Label()
        Me.grdRecDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRecDevSN = New System.Windows.Forms.TextBox()
        Me.lblRecMsg = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PanelSlvg = New System.Windows.Forms.Panel()
        Me.GroupBoxSlvgTransDev = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSlvgMemo = New System.Windows.Forms.TextBox()
        Me.rdbtnSlvgTransToIntransit = New System.Windows.Forms.RadioButton()
        Me.lblSlvgScanCnt = New System.Windows.Forms.Label()
        Me.btnSlvgRemoveAll = New System.Windows.Forms.Button()
        Me.btnSlvgRemoveOne = New System.Windows.Forms.Button()
        Me.rdbtnSlvgTransToSlvg = New System.Windows.Forms.RadioButton()
        Me.lstSlvgSNs = New System.Windows.Forms.ListBox()
        Me.btnSlvgTransfer = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSlvgDevSN = New System.Windows.Forms.TextBox()
        Me.grdSlvgSlvgInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.PanelRpt = New System.Windows.Forms.Panel()
        Me.grpboxRptASNRpt = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnRptGenASNRpt = New System.Windows.Forms.Button()
        Me.dtpRptShipToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpRptShipFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnRptWIPRptToDOB = New System.Windows.Forms.Button()
        Me.PanelAdmin = New System.Windows.Forms.Panel()
        Me.grpboxPreBill = New System.Windows.Forms.GroupBox()
        Me.lblAdminLotName = New System.Windows.Forms.Label()
        Me.txtAdminPreBillSN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAdminReprintPreBillLot = New System.Windows.Forms.Button()
        Me.btnAdminCloseTodaysPreBill = New System.Windows.Forms.Button()
        Me.btnAdminLoadASNFrmDOB = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.panelRec.SuspendLayout()
        CType(Me.grdRecDevices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSlvg.SuspendLayout()
        Me.GroupBoxSlvgTransDev.SuspendLayout()
        CType(Me.grdSlvgSlvgInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelRpt.SuspendLayout()
        Me.grpboxRptASNRpt.SuspendLayout()
        Me.PanelAdmin.SuspendLayout()
        Me.grpboxPreBill.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblGroup, Me.cmdReports, Me.cmdSlvg, Me.cmdAdmin, Me.cmdReceive, Me.lblMachine, Me.lblShift, Me.lblWorkDate, Me.lblUserName, Me.lblTitle})
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(160, 624)
        Me.Panel2.TabIndex = 1
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(8, 84)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(136, 16)
        Me.lblGroup.TabIndex = 94
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdReports
        '
        Me.cmdReports.BackColor = System.Drawing.Color.Black
        Me.cmdReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReports.ForeColor = System.Drawing.Color.Lime
        Me.cmdReports.Location = New System.Drawing.Point(8, 304)
        Me.cmdReports.Name = "cmdReports"
        Me.cmdReports.Size = New System.Drawing.Size(135, 23)
        Me.cmdReports.TabIndex = 3
        Me.cmdReports.Text = "REPORT"
        '
        'cmdSlvg
        '
        Me.cmdSlvg.BackColor = System.Drawing.Color.Black
        Me.cmdSlvg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSlvg.ForeColor = System.Drawing.Color.Lime
        Me.cmdSlvg.Location = New System.Drawing.Point(9, 240)
        Me.cmdSlvg.Name = "cmdSlvg"
        Me.cmdSlvg.Size = New System.Drawing.Size(135, 23)
        Me.cmdSlvg.TabIndex = 2
        Me.cmdSlvg.Text = "SALVAGE"
        '
        'cmdAdmin
        '
        Me.cmdAdmin.BackColor = System.Drawing.Color.Black
        Me.cmdAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdmin.ForeColor = System.Drawing.Color.Lime
        Me.cmdAdmin.Location = New System.Drawing.Point(8, 272)
        Me.cmdAdmin.Name = "cmdAdmin"
        Me.cmdAdmin.Size = New System.Drawing.Size(135, 23)
        Me.cmdAdmin.TabIndex = 4
        Me.cmdAdmin.Text = "ADMIN"
        '
        'cmdReceive
        '
        Me.cmdReceive.BackColor = System.Drawing.Color.Black
        Me.cmdReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReceive.ForeColor = System.Drawing.Color.Lime
        Me.cmdReceive.Location = New System.Drawing.Point(9, 208)
        Me.cmdReceive.Name = "cmdReceive"
        Me.cmdReceive.Size = New System.Drawing.Size(135, 23)
        Me.cmdReceive.TabIndex = 1
        Me.cmdReceive.Text = "RECEIVE"
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(8, 66)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(136, 16)
        Me.lblMachine.TabIndex = 92
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(8, 120)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(136, 16)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(8, 138)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(136, 16)
        Me.lblWorkDate.TabIndex = 84
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(8, 102)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(136, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(2, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(152, 40)
        Me.lblTitle.TabIndex = 93
        Me.lblTitle.Text = "BRIGHTPOINT OPERATIONS"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panelRec
        '
        Me.panelRec.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.panelRec.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkRec_DevsFrBP, Me.chkRecShipLess30Days, Me.txtRecPartNum, Me.cmdRecLoadDev, Me.btnRecRemoveAll, Me.btnRecRemoveOne, Me.lblRecScanCnt, Me.grdRecDevices, Me.Label8, Me.txtRecDevSN, Me.lblRecMsg, Me.Label10})
        Me.panelRec.Location = New System.Drawing.Point(160, 0)
        Me.panelRec.Name = "panelRec"
        Me.panelRec.Size = New System.Drawing.Size(736, 552)
        Me.panelRec.TabIndex = 2
        Me.panelRec.Visible = False
        '
        'chkRec_DevsFrBP
        '
        Me.chkRec_DevsFrBP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRec_DevsFrBP.ForeColor = System.Drawing.Color.Red
        Me.chkRec_DevsFrBP.Location = New System.Drawing.Point(64, 88)
        Me.chkRec_DevsFrBP.Name = "chkRec_DevsFrBP"
        Me.chkRec_DevsFrBP.Size = New System.Drawing.Size(192, 16)
        Me.chkRec_DevsFrBP.TabIndex = 142
        Me.chkRec_DevsFrBP.Text = "Devices From Brightpoint"
        Me.chkRec_DevsFrBP.Visible = False
        '
        'chkRecShipLess30Days
        '
        Me.chkRecShipLess30Days.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecShipLess30Days.ForeColor = System.Drawing.Color.Red
        Me.chkRecShipLess30Days.Location = New System.Drawing.Point(64, 12)
        Me.chkRecShipLess30Days.Name = "chkRecShipLess30Days"
        Me.chkRecShipLess30Days.Size = New System.Drawing.Size(272, 16)
        Me.chkRecShipLess30Days.TabIndex = 141
        Me.chkRecShipLess30Days.Text = "Allow Devices to come back less than 30 days"
        Me.chkRecShipLess30Days.Visible = False
        '
        'txtRecPartNum
        '
        Me.txtRecPartNum.BackColor = System.Drawing.Color.White
        Me.txtRecPartNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecPartNum.ForeColor = System.Drawing.Color.Blue
        Me.txtRecPartNum.Location = New System.Drawing.Point(65, 60)
        Me.txtRecPartNum.MaxLength = 15
        Me.txtRecPartNum.Name = "txtRecPartNum"
        Me.txtRecPartNum.Size = New System.Drawing.Size(184, 20)
        Me.txtRecPartNum.TabIndex = 140
        Me.txtRecPartNum.Text = ""
        '
        'cmdRecLoadDev
        '
        Me.cmdRecLoadDev.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.cmdRecLoadDev.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdRecLoadDev.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecLoadDev.ForeColor = System.Drawing.Color.White
        Me.cmdRecLoadDev.Location = New System.Drawing.Point(616, 488)
        Me.cmdRecLoadDev.Name = "cmdRecLoadDev"
        Me.cmdRecLoadDev.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRecLoadDev.Size = New System.Drawing.Size(112, 52)
        Me.cmdRecLoadDev.TabIndex = 6
        Me.cmdRecLoadDev.Text = "LOAD DEVICE(S)"
        '
        'btnRecRemoveAll
        '
        Me.btnRecRemoveAll.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnRecRemoveAll.BackColor = System.Drawing.Color.Red
        Me.btnRecRemoveAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecRemoveAll.ForeColor = System.Drawing.Color.White
        Me.btnRecRemoveAll.Location = New System.Drawing.Point(120, 488)
        Me.btnRecRemoveAll.Name = "btnRecRemoveAll"
        Me.btnRecRemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRecRemoveAll.Size = New System.Drawing.Size(96, 52)
        Me.btnRecRemoveAll.TabIndex = 5
        Me.btnRecRemoveAll.Text = "REMOVE ALL SNs TO BE RECEIVED"
        '
        'btnRecRemoveOne
        '
        Me.btnRecRemoveOne.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnRecRemoveOne.BackColor = System.Drawing.Color.Red
        Me.btnRecRemoveOne.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecRemoveOne.ForeColor = System.Drawing.Color.White
        Me.btnRecRemoveOne.Location = New System.Drawing.Point(8, 488)
        Me.btnRecRemoveOne.Name = "btnRecRemoveOne"
        Me.btnRecRemoveOne.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRecRemoveOne.Size = New System.Drawing.Size(96, 53)
        Me.btnRecRemoveOne.TabIndex = 4
        Me.btnRecRemoveOne.Text = "REMOVE ONE SN TO BE RECEIVED"
        '
        'lblRecScanCnt
        '
        Me.lblRecScanCnt.BackColor = System.Drawing.Color.Black
        Me.lblRecScanCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRecScanCnt.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecScanCnt.ForeColor = System.Drawing.Color.Lime
        Me.lblRecScanCnt.Location = New System.Drawing.Point(264, 45)
        Me.lblRecScanCnt.Name = "lblRecScanCnt"
        Me.lblRecScanCnt.Size = New System.Drawing.Size(80, 36)
        Me.lblRecScanCnt.TabIndex = 139
        Me.lblRecScanCnt.Text = "0"
        Me.lblRecScanCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdRecDevices
        '
        Me.grdRecDevices.AllowColMove = False
        Me.grdRecDevices.AllowColSelect = False
        Me.grdRecDevices.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdRecDevices.AllowSort = False
        Me.grdRecDevices.AllowUpdate = False
        Me.grdRecDevices.AllowUpdateOnBlur = False
        Me.grdRecDevices.AlternatingRows = True
        Me.grdRecDevices.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdRecDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRecDevices.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdRecDevices.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdRecDevices.Location = New System.Drawing.Point(8, 112)
        Me.grdRecDevices.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdRecDevices.Name = "grdRecDevices"
        Me.grdRecDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdRecDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdRecDevices.PreviewInfo.ZoomFactor = 75
        Me.grdRecDevices.RowHeight = 20
        Me.grdRecDevices.Size = New System.Drawing.Size(720, 360)
        Me.grdRecDevices.TabIndex = 3
        Me.grdRecDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt;ForeColor:White;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;B" & _
        "ackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:Ina" & _
        "ctiveCaption;}FilterBar{BackColor:White;}Footer{}Caption{AlignHorz:Center;}Style" & _
        "9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Center;}" & _
        "HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{ForeCo" & _
        "lor:Black;BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13{}H" & _
        "eading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;" & _
        "BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cent" & _
        "er;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></" & _
        "Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelec" & _
        "t=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight" & _
        "=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellB" & _
        "order"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><Height>356</Height><CaptionStyle parent=""Style2"" me=""Styl" & _
        "e10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow""" & _
        " me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pa" & _
        "rent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingSt" & _
        "yle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""" & _
        "Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""Od" & _
        "dRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" />" & _
        "<SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1" & _
        """ /><ClientRect>0, 0, 716, 356</ClientRect><BorderSide>0</BorderSide><BorderStyl" & _
        "e>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Sty" & _
        "le parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""" & _
        "Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Hea" & _
        "ding"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Norm" & _
        "al"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Norm" & _
        "al"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" " & _
        "me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Cap" & _
        "tion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSp" & _
        "lits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea" & _
        ">0, 0, 716, 356</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Prin" & _
        "tPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(16, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "SN:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecDevSN
        '
        Me.txtRecDevSN.BackColor = System.Drawing.Color.Yellow
        Me.txtRecDevSN.Location = New System.Drawing.Point(64, 36)
        Me.txtRecDevSN.MaxLength = 16
        Me.txtRecDevSN.Name = "txtRecDevSN"
        Me.txtRecDevSN.Size = New System.Drawing.Size(184, 20)
        Me.txtRecDevSN.TabIndex = 1
        Me.txtRecDevSN.Text = ""
        '
        'lblRecMsg
        '
        Me.lblRecMsg.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblRecMsg.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblRecMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecMsg.ForeColor = System.Drawing.Color.Yellow
        Me.lblRecMsg.Location = New System.Drawing.Point(368, 1)
        Me.lblRecMsg.Name = "lblRecMsg"
        Me.lblRecMsg.Size = New System.Drawing.Size(360, 79)
        Me.lblRecMsg.TabIndex = 94
        Me.lblRecMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(23, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Part#:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelSlvg
        '
        Me.PanelSlvg.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelSlvg.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBoxSlvgTransDev, Me.grdSlvgSlvgInfo})
        Me.PanelSlvg.Location = New System.Drawing.Point(184, 24)
        Me.PanelSlvg.Name = "PanelSlvg"
        Me.PanelSlvg.Size = New System.Drawing.Size(704, 504)
        Me.PanelSlvg.TabIndex = 3
        Me.PanelSlvg.Visible = False
        '
        'GroupBoxSlvgTransDev
        '
        Me.GroupBoxSlvgTransDev.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.txtSlvgMemo, Me.rdbtnSlvgTransToIntransit, Me.lblSlvgScanCnt, Me.btnSlvgRemoveAll, Me.btnSlvgRemoveOne, Me.rdbtnSlvgTransToSlvg, Me.lstSlvgSNs, Me.btnSlvgTransfer, Me.Label1, Me.txtSlvgDevSN})
        Me.GroupBoxSlvgTransDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxSlvgTransDev.Location = New System.Drawing.Point(272, 5)
        Me.GroupBoxSlvgTransDev.Name = "GroupBoxSlvgTransDev"
        Me.GroupBoxSlvgTransDev.Size = New System.Drawing.Size(384, 443)
        Me.GroupBoxSlvgTransDev.TabIndex = 2
        Me.GroupBoxSlvgTransDev.TabStop = False
        Me.GroupBoxSlvgTransDev.Text = "Devices Transfer "
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "Memo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtSlvgMemo
        '
        Me.txtSlvgMemo.BackColor = System.Drawing.Color.White
        Me.txtSlvgMemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSlvgMemo.Location = New System.Drawing.Point(16, 80)
        Me.txtSlvgMemo.MaxLength = 60
        Me.txtSlvgMemo.Name = "txtSlvgMemo"
        Me.txtSlvgMemo.Size = New System.Drawing.Size(352, 20)
        Me.txtSlvgMemo.TabIndex = 3
        Me.txtSlvgMemo.Text = ""
        '
        'rdbtnSlvgTransToIntransit
        '
        Me.rdbtnSlvgTransToIntransit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnSlvgTransToIntransit.ForeColor = System.Drawing.Color.Blue
        Me.rdbtnSlvgTransToIntransit.Location = New System.Drawing.Point(16, 40)
        Me.rdbtnSlvgTransToIntransit.Name = "rdbtnSlvgTransToIntransit"
        Me.rdbtnSlvgTransToIntransit.Size = New System.Drawing.Size(120, 16)
        Me.rdbtnSlvgTransToIntransit.TabIndex = 2
        Me.rdbtnSlvgTransToIntransit.Text = "To Intransit"
        '
        'lblSlvgScanCnt
        '
        Me.lblSlvgScanCnt.BackColor = System.Drawing.Color.Black
        Me.lblSlvgScanCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSlvgScanCnt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlvgScanCnt.ForeColor = System.Drawing.Color.Lime
        Me.lblSlvgScanCnt.Location = New System.Drawing.Point(288, 128)
        Me.lblSlvgScanCnt.Name = "lblSlvgScanCnt"
        Me.lblSlvgScanCnt.Size = New System.Drawing.Size(56, 32)
        Me.lblSlvgScanCnt.TabIndex = 140
        Me.lblSlvgScanCnt.Text = "0"
        Me.lblSlvgScanCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSlvgRemoveAll
        '
        Me.btnSlvgRemoveAll.BackColor = System.Drawing.Color.Red
        Me.btnSlvgRemoveAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlvgRemoveAll.ForeColor = System.Drawing.Color.White
        Me.btnSlvgRemoveAll.Location = New System.Drawing.Point(272, 224)
        Me.btnSlvgRemoveAll.Name = "btnSlvgRemoveAll"
        Me.btnSlvgRemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSlvgRemoveAll.Size = New System.Drawing.Size(96, 32)
        Me.btnSlvgRemoveAll.TabIndex = 7
        Me.btnSlvgRemoveAll.Text = "REMOVE ALL SN FROM LIST"
        '
        'btnSlvgRemoveOne
        '
        Me.btnSlvgRemoveOne.BackColor = System.Drawing.Color.Red
        Me.btnSlvgRemoveOne.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlvgRemoveOne.ForeColor = System.Drawing.Color.White
        Me.btnSlvgRemoveOne.Location = New System.Drawing.Point(272, 176)
        Me.btnSlvgRemoveOne.Name = "btnSlvgRemoveOne"
        Me.btnSlvgRemoveOne.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSlvgRemoveOne.Size = New System.Drawing.Size(96, 32)
        Me.btnSlvgRemoveOne.TabIndex = 6
        Me.btnSlvgRemoveOne.Text = "REMOVE ONE SN FROM LIST"
        '
        'rdbtnSlvgTransToSlvg
        '
        Me.rdbtnSlvgTransToSlvg.Checked = True
        Me.rdbtnSlvgTransToSlvg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtnSlvgTransToSlvg.ForeColor = System.Drawing.Color.Blue
        Me.rdbtnSlvgTransToSlvg.Location = New System.Drawing.Point(16, 19)
        Me.rdbtnSlvgTransToSlvg.Name = "rdbtnSlvgTransToSlvg"
        Me.rdbtnSlvgTransToSlvg.Size = New System.Drawing.Size(120, 16)
        Me.rdbtnSlvgTransToSlvg.TabIndex = 1
        Me.rdbtnSlvgTransToSlvg.TabStop = True
        Me.rdbtnSlvgTransToSlvg.Text = "To Cell 2 Salvage"
        '
        'lstSlvgSNs
        '
        Me.lstSlvgSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSlvgSNs.Location = New System.Drawing.Point(16, 152)
        Me.lstSlvgSNs.Name = "lstSlvgSNs"
        Me.lstSlvgSNs.Size = New System.Drawing.Size(184, 264)
        Me.lstSlvgSNs.TabIndex = 5
        '
        'btnSlvgTransfer
        '
        Me.btnSlvgTransfer.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSlvgTransfer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlvgTransfer.ForeColor = System.Drawing.Color.White
        Me.btnSlvgTransfer.Location = New System.Drawing.Point(272, 320)
        Me.btnSlvgTransfer.Name = "btnSlvgTransfer"
        Me.btnSlvgTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSlvgTransfer.Size = New System.Drawing.Size(96, 32)
        Me.btnSlvgTransfer.TabIndex = 8
        Me.btnSlvgTransfer.Text = "TRANSFER"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(16, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "SN:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSlvgDevSN
        '
        Me.txtSlvgDevSN.BackColor = System.Drawing.Color.Yellow
        Me.txtSlvgDevSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSlvgDevSN.Location = New System.Drawing.Point(16, 128)
        Me.txtSlvgDevSN.MaxLength = 15
        Me.txtSlvgDevSN.Name = "txtSlvgDevSN"
        Me.txtSlvgDevSN.Size = New System.Drawing.Size(184, 20)
        Me.txtSlvgDevSN.TabIndex = 4
        Me.txtSlvgDevSN.Text = ""
        '
        'grdSlvgSlvgInfo
        '
        Me.grdSlvgSlvgInfo.AllowColMove = False
        Me.grdSlvgSlvgInfo.AllowColSelect = False
        Me.grdSlvgSlvgInfo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdSlvgSlvgInfo.AllowSort = False
        Me.grdSlvgSlvgInfo.AllowUpdate = False
        Me.grdSlvgSlvgInfo.AllowUpdateOnBlur = False
        Me.grdSlvgSlvgInfo.AlternatingRows = True
        Me.grdSlvgSlvgInfo.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.grdSlvgSlvgInfo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSlvgSlvgInfo.FilterBar = True
        Me.grdSlvgSlvgInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdSlvgSlvgInfo.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdSlvgSlvgInfo.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdSlvgSlvgInfo.Location = New System.Drawing.Point(8, 8)
        Me.grdSlvgSlvgInfo.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdSlvgSlvgInfo.Name = "grdSlvgSlvgInfo"
        Me.grdSlvgSlvgInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSlvgSlvgInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSlvgSlvgInfo.PreviewInfo.ZoomFactor = 75
        Me.grdSlvgSlvgInfo.RowHeight = 20
        Me.grdSlvgSlvgInfo.Size = New System.Drawing.Size(240, 480)
        Me.grdSlvgSlvgInfo.TabIndex = 1
        Me.grdSlvgSlvgInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt;ForeColor:White;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;B" & _
        "ackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:Ina" & _
        "ctiveCaption;}FilterBar{BackColor:White;}Footer{}Caption{AlignHorz:Center;}Style" & _
        "9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Center;}" & _
        "HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{ForeCo" & _
        "lor:Black;BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13{}H" & _
        "eading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;" & _
        "BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cent" & _
        "er;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></" & _
        "Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelec" & _
        "t=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight" & _
        "=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeS" & _
        "tyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScr" & _
        "ollGroup=""1"" HorizontalScrollGroup=""1""><Height>476</Height><CaptionStyle parent=" & _
        """Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle" & _
        " parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" " & _
        "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
        "e12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
        "ighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
        "wStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector" & _
        """ me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""N" & _
        "ormal"" me=""Style1"" /><ClientRect>0, 0, 236, 476</ClientRect><BorderSide>0</Borde" & _
        "rSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits>" & _
        "<NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" " & _
        "/><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><" & _
        "Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><S" & _
        "tyle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><S" & _
        "tyle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style " & _
        "parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><" & _
        "Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><hor" & _
        "zSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSel" & _
        "Width><ClientArea>0, 0, 236, 476</ClientArea><PrintPageHeaderStyle parent="""" me=" & _
        """Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'PanelRpt
        '
        Me.PanelRpt.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelRpt.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpboxRptASNRpt, Me.btnRptWIPRptToDOB})
        Me.PanelRpt.Location = New System.Drawing.Point(264, 408)
        Me.PanelRpt.Name = "PanelRpt"
        Me.PanelRpt.Size = New System.Drawing.Size(464, 240)
        Me.PanelRpt.TabIndex = 4
        Me.PanelRpt.Visible = False
        '
        'grpboxRptASNRpt
        '
        Me.grpboxRptASNRpt.BackColor = System.Drawing.Color.Transparent
        Me.grpboxRptASNRpt.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label11, Me.btnRptGenASNRpt, Me.dtpRptShipToDate, Me.dtpRptShipFromDate, Me.Label12})
        Me.grpboxRptASNRpt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpboxRptASNRpt.ForeColor = System.Drawing.Color.Blue
        Me.grpboxRptASNRpt.Location = New System.Drawing.Point(8, 64)
        Me.grpboxRptASNRpt.Name = "grpboxRptASNRpt"
        Me.grpboxRptASNRpt.Size = New System.Drawing.Size(256, 136)
        Me.grpboxRptASNRpt.TabIndex = 70
        Me.grpboxRptASNRpt.TabStop = False
        Me.grpboxRptASNRpt.Text = "ASN ReportS"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(24, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 16)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Ship Date to:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRptGenASNRpt
        '
        Me.btnRptGenASNRpt.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRptGenASNRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRptGenASNRpt.ForeColor = System.Drawing.Color.White
        Me.btnRptGenASNRpt.Location = New System.Drawing.Point(64, 96)
        Me.btnRptGenASNRpt.Name = "btnRptGenASNRpt"
        Me.btnRptGenASNRpt.Size = New System.Drawing.Size(136, 31)
        Me.btnRptGenASNRpt.TabIndex = 66
        Me.btnRptGenASNRpt.Text = "Generate Report"
        '
        'dtpRptShipToDate
        '
        Me.dtpRptShipToDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpRptShipToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRptShipToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRptShipToDate.Location = New System.Drawing.Point(144, 64)
        Me.dtpRptShipToDate.Name = "dtpRptShipToDate"
        Me.dtpRptShipToDate.Size = New System.Drawing.Size(104, 21)
        Me.dtpRptShipToDate.TabIndex = 64
        Me.dtpRptShipToDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'dtpRptShipFromDate
        '
        Me.dtpRptShipFromDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpRptShipFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRptShipFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRptShipFromDate.Location = New System.Drawing.Point(144, 32)
        Me.dtpRptShipFromDate.Name = "dtpRptShipFromDate"
        Me.dtpRptShipFromDate.Size = New System.Drawing.Size(104, 21)
        Me.dtpRptShipFromDate.TabIndex = 62
        Me.dtpRptShipFromDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 16)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Ship Date From:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRptWIPRptToDOB
        '
        Me.btnRptWIPRptToDOB.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRptWIPRptToDOB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRptWIPRptToDOB.ForeColor = System.Drawing.Color.White
        Me.btnRptWIPRptToDOB.Location = New System.Drawing.Point(8, 8)
        Me.btnRptWIPRptToDOB.Name = "btnRptWIPRptToDOB"
        Me.btnRptWIPRptToDOB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRptWIPRptToDOB.Size = New System.Drawing.Size(184, 40)
        Me.btnRptWIPRptToDOB.TabIndex = 1
        Me.btnRptWIPRptToDOB.Text = "CREATE PSS WIP REPORT TO DOBSON"
        '
        'PanelAdmin
        '
        Me.PanelAdmin.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelAdmin.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpboxPreBill, Me.btnAdminLoadASNFrmDOB})
        Me.PanelAdmin.Location = New System.Drawing.Point(296, 464)
        Me.PanelAdmin.Name = "PanelAdmin"
        Me.PanelAdmin.Size = New System.Drawing.Size(496, 336)
        Me.PanelAdmin.TabIndex = 5
        Me.PanelAdmin.Visible = False
        '
        'grpboxPreBill
        '
        Me.grpboxPreBill.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAdminLotName, Me.txtAdminPreBillSN, Me.Label4, Me.btnAdminReprintPreBillLot, Me.btnAdminCloseTodaysPreBill})
        Me.grpboxPreBill.ForeColor = System.Drawing.Color.Red
        Me.grpboxPreBill.Location = New System.Drawing.Point(8, 64)
        Me.grpboxPreBill.Name = "grpboxPreBill"
        Me.grpboxPreBill.Size = New System.Drawing.Size(248, 192)
        Me.grpboxPreBill.TabIndex = 3
        Me.grpboxPreBill.TabStop = False
        Me.grpboxPreBill.Text = "Pre-Bill"
        '
        'lblAdminLotName
        '
        Me.lblAdminLotName.BackColor = System.Drawing.Color.Transparent
        Me.lblAdminLotName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdminLotName.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblAdminLotName.Location = New System.Drawing.Point(16, 122)
        Me.lblAdminLotName.Name = "lblAdminLotName"
        Me.lblAdminLotName.Size = New System.Drawing.Size(232, 16)
        Me.lblAdminLotName.TabIndex = 77
        Me.lblAdminLotName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdminPreBillSN
        '
        Me.txtAdminPreBillSN.Location = New System.Drawing.Point(16, 96)
        Me.txtAdminPreBillSN.Name = "txtAdminPreBillSN"
        Me.txtAdminPreBillSN.Size = New System.Drawing.Size(216, 20)
        Me.txtAdminPreBillSN.TabIndex = 76
        Me.txtAdminPreBillSN.Text = ""
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(232, 16)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Scan SN to Get Pre-Bill Lot Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnAdminReprintPreBillLot
        '
        Me.btnAdminReprintPreBillLot.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAdminReprintPreBillLot.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdminReprintPreBillLot.ForeColor = System.Drawing.Color.White
        Me.btnAdminReprintPreBillLot.Location = New System.Drawing.Point(16, 138)
        Me.btnAdminReprintPreBillLot.Name = "btnAdminReprintPreBillLot"
        Me.btnAdminReprintPreBillLot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAdminReprintPreBillLot.Size = New System.Drawing.Size(216, 24)
        Me.btnAdminReprintPreBillLot.TabIndex = 6
        Me.btnAdminReprintPreBillLot.Text = "Reprint Lot"
        '
        'btnAdminCloseTodaysPreBill
        '
        Me.btnAdminCloseTodaysPreBill.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAdminCloseTodaysPreBill.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdminCloseTodaysPreBill.ForeColor = System.Drawing.Color.White
        Me.btnAdminCloseTodaysPreBill.Location = New System.Drawing.Point(16, 16)
        Me.btnAdminCloseTodaysPreBill.Name = "btnAdminCloseTodaysPreBill"
        Me.btnAdminCloseTodaysPreBill.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAdminCloseTodaysPreBill.Size = New System.Drawing.Size(192, 40)
        Me.btnAdminCloseTodaysPreBill.TabIndex = 2
        Me.btnAdminCloseTodaysPreBill.Text = "CLOSE TODAY'S PREBILL"
        '
        'btnAdminLoadASNFrmDOB
        '
        Me.btnAdminLoadASNFrmDOB.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAdminLoadASNFrmDOB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdminLoadASNFrmDOB.ForeColor = System.Drawing.Color.White
        Me.btnAdminLoadASNFrmDOB.Location = New System.Drawing.Point(8, 8)
        Me.btnAdminLoadASNFrmDOB.Name = "btnAdminLoadASNFrmDOB"
        Me.btnAdminLoadASNFrmDOB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAdminLoadASNFrmDOB.Size = New System.Drawing.Size(216, 40)
        Me.btnAdminLoadASNFrmDOB.TabIndex = 1
        Me.btnAdminLoadASNFrmDOB.Text = "LOAD DATA FILE(S) FROM DOBSON"
        '
        'frmBrightpointOperations
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(904, 622)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelAdmin, Me.PanelRpt, Me.PanelSlvg, Me.panelRec, Me.Panel2})
        Me.Name = "frmBrightpointOperations"
        Me.Text = "Brightpoint Operations"
        Me.Panel2.ResumeLayout(False)
        Me.panelRec.ResumeLayout(False)
        CType(Me.grdRecDevices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSlvg.ResumeLayout(False)
        Me.GroupBoxSlvgTransDev.ResumeLayout(False)
        CType(Me.grdSlvgSlvgInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelRpt.ResumeLayout(False)
        Me.grpboxRptASNRpt.ResumeLayout(False)
        Me.PanelAdmin.ResumeLayout(False)
        Me.grpboxPreBill.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*******************************************************************************
    Protected Overrides Sub Finalize()
        If Not IsNothing(GobjBrightpoint) Then
            GobjBrightpoint = Nothing
        End If
        MyBase.Finalize()
    End Sub

    '*******************************************************************************
    Private Sub frmBrightpointOperations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Dim objMClaim As New PSS.Data.Buisness.WarrantyClaim.MClaim()
        Dim dt1 As DataTable
        Dim R1 As DataRow

        Try

            '********************************************
            Me.lblMachine.Text = GstrMachine
            Me.lblGroup.Text = Me.GstrMachineGroupDesc
            Me.lblUserName.Text = GstrUserName
            Me.lblShift.Text = "Shift " & GiShiftID
            Me.lblWorkDate.Text = Format(CDate(Me.GstrWorkDate), "MM/dd/yyyy")
            '********************************************
            'Get User Acess
            '********************************************
            If ApplicationUser.GetPermission("BrightpointRec") > 0 Then
                GbooBPRecSecure = True
            End If
            If ApplicationUser.GetPermission("BrightpointSlvg") > 0 Then
                GbooBPSlvgSecure = True
            End If
            If ApplicationUser.GetPermission("BrightpointRpts") > 0 Then
                GbooBPReportSecure = True
            End If
            If ApplicationUser.GetPermission("BrightpointAdmin") > 0 Then
                GbooBPAdminSecure = True
            End If
            If ApplicationUser.GetPermission("BrightpointBill") > 0 Then
                GbooBPBillSecure = True
            End If
            If ApplicationUser.GetPermission("BrightpointShipLess30DaysDev") > 0 Then
                Me.GbooBPReRecShipLess30DaysDev = True
            End If
            '********************************************
            'Get Wrok location ID 
            '********************************************
            dt1 = objMisc.CheckIfMachineTiedToLine(Me.GstrMachine)

            For Each R1 In dt1.Rows
                GiWCLocationID = R1("WCLocation_ID")
            Next R1

            Me.GSendMClaimFlg = objMClaim.GetSendMotorolaClaimFlg
            Me.GSendNKClaimFlg = objMClaim.GetSendNokiaClaimFlg

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            objMClaim = Nothing
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

#Region "General"
    '*******************************************************************************
    Private Sub SetControlAttributes(ByVal ctrl As Control, _
                                    Optional ByVal iTop As Integer = 0, _
                                    Optional ByVal iLeft As Integer = 0, _
                                    Optional ByVal iWidth As Integer = 0, _
                                    Optional ByVal iHeight As Integer = 0)
        If iTop > 0 Then
            ctrl.Top = iTop
        End If
        If iLeft > 0 Then
            ctrl.Left = iLeft
        End If
        If iWidth > 0 Then
            ctrl.Width = iWidth
        End If
        If iHeight > 0 Then
            ctrl.Height = iHeight
        End If
    End Sub

    '*******************************************************************************
    Private Sub SetButtonProps(ByVal ctrl As Control, _
                                ByVal strBC As Color, _
                                ByVal strFC As Color)
        With ctrl
            .BackColor = strBC
            .ForeColor = strFC
        End With
    End Sub

    '*******************************************************************************
    Private Sub ShowHidePanels(ByVal iPanelIndex As Integer)
        Dim x As Decimal = Me.Panel2.Width

        Try
            MakeAllPanelsInvisible()
            Select Case iPanelIndex
                Case 1  'Rec
                    If Me.GbooBPRecSecure Then
                        Me.panelRec.Visible = True

                        SetControlAttributes(panelRec, 1, x, , )

                        'Set Button Colors
                        SetButtonProps(Me.cmdReceive, Color.Orange, Color.Black)
                    End If
                Case 2  'Ship
                    If Me.GbooBPSlvgSecure Then
                        Me.PanelSlvg.Visible = True

                        SetControlAttributes(Me.PanelSlvg, 1, x, , )

                        'Set Button Colors
                        SetButtonProps(Me.cmdSlvg, Color.Orange, Color.Black)
                    End If
                Case 3  'Report
                    If Me.GbooBPReportSecure Then
                        Me.PanelRpt.Visible = True

                        SetControlAttributes(PanelRpt, 1, x, , )

                        'Set Button Colors
                        SetButtonProps(Me.cmdReports, Color.Orange, Color.Black)
                    End If
                Case 4  'Admin
                    If Me.GbooBPAdminSecure Then
                        Me.PanelAdmin.Visible = True

                        SetControlAttributes(PanelAdmin, 1, x, , )

                        'Set Button Colors
                        SetButtonProps(Me.cmdAdmin, Color.Orange, Color.Black)
                    End If
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*******************************************************************************
    Private Sub ResetAllMenuButtons()
        Dim strBC As Color = Color.Black
        Dim strFC As Color = Color.Lime

        SetButtonProps(Me.cmdReceive, strBC, strFC)
        SetButtonProps(Me.cmdSlvg, strBC, strFC)
        SetButtonProps(Me.cmdAdmin, strBC, strFC)
        SetButtonProps(Me.cmdReports, strBC, strFC)

    End Sub

    '*******************************************************************************
    Private Sub MakeAllPanelsInvisible()

        Me.panelRec.Visible = False
        Me.PanelSlvg.Visible = False
        Me.PanelAdmin.Visible = False
        Me.PanelRpt.Visible = False
    End Sub

    '*******************************************************************************
    Private Sub ClearAllPanels()
        ClearPanel_Receive()
        ClearPanel_Slvg()
        ClearPanel_Admin()
        ClearPanel_Rpt()
        ResetAllMenuButtons()
    End Sub

#End Region


    '*******************************************************************************
    Private Sub ClearPanel_Receive()
        Me.chkRecShipLess30Days.Checked = False
        Me.chkRecShipLess30Days.Visible = False
        Me.txtRecPartNum.Text = ""
        Me.txtRecDevSN.Text = ""
        Me.lblRecScanCnt.Text = "0"

        Me.lblRecMsg.Text = ""
        Me.lblRecMsg.BackColor = Color.LightSteelBlue

        If Not IsNothing(Me.GdtRecItems) Then
            Me.GdtRecItems.Clear()
        End If

        Me.grdRecDevices.DataSource = Nothing
    End Sub

    '*******************************************************************************
    Private Sub ClearPanel_Slvg()
        Me.rdbtnSlvgTransToSlvg.Checked = True  'by default
        Me.rdbtnSlvgTransToIntransit.Checked = False

        Me.txtSlvgDevSN.Text = ""
        Me.lstSlvgSNs.Items.Clear()
        Me.lstSlvgSNs.Refresh()

        Me.grdSlvgSlvgInfo.DataSource = Nothing
    End Sub

    '*******************************************************************************
    Private Sub ClearPanel_Admin()

    End Sub

    '*******************************************************************************
    Private Sub ClearPanel_Rpt()

    End Sub

    '*******************************************************************************


#Region "Main Menu Button Click Event"
    '*******************************************************************************
    Private Sub cmdReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceive.Click

        Try
            '****************************************
            'Clear All controls in all panels
            ClearAllPanels()
            '****************************************
            'Check for mapped group of computer
            If Me.GiMachineGroupID <> 11 And Me.GiMachineGroupID <> 3 Then   'Cell 2  or Cell 2 Staging 1 group
                MessageBox.Show("This computer maps to the wrong group (" & Me.GstrMachineGroupDesc & "). Must be Cellular 2 or Cellular 2 Staging 1.", "Check Computer Group", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '******************************************************
            'check for user permition
            ShowHidePanels(Me.GiPanelRecIndex)
            '******************************************************
            If Me.GbooBPRecSecure Then
                If Me.GbooBPReRecShipLess30DaysDev = True Then
                    Me.chkRecShipLess30Days.Visible = True
                Else
                    Me.chkRecShipLess30Days.Visible = False
                End If

                If ApplicationUser.GetPermission("Rec_DevFrBrightpoint") > 0 Then
                    Me.chkRec_DevsFrBP.Visible = True
                Else
                    Me.chkRec_DevsFrBP.Visible = False
                End If

                'Create Receive datatable
                Me.CreateRecItemsTable_Receive()
                Me.grdRecDevices.DataSource = Nothing
                Me.grdRecDevices.DataSource = Me.GdtRecItems
                Me.SetGridProperties_Receive()

                Me.txtRecDevSN.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Receive Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            'Invoke Garbage Collector
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '*******************************************************************************
    Private Sub cmdSlvg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSlvg.Click
        Dim objGen As PSS.Data.Buisness.Generic

        Try
            '*************************************
            'Clear All controls in all panels
            ClearAllPanels()
            '*************************************
            'Check for mapped group of computer
            If Me.GiMachineGroupID <> 3 Then   'Cell 2 group
                MessageBox.Show("This computer maps to the wrong group (" & Me.GstrMachineGroupDesc & "). Must be Cellular 2.", "Check Computer Group", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '*************************************
            'check for user permition
            ShowHidePanels(Me.GiPanelShipIndex)
            '*************************************

            If Me.GbooBPSlvgSecure Then
                'Populate Salvage information
                Me.PopulateSalvageQty_Ship()

                Me.txtSlvgDevSN.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Ship Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            'Invoke Garbage Collector
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '*******************************************************************************
    Private Sub cmdAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdmin.Click
        Try
            '**********************************
            'Clear All controls in all panels
            ClearAllPanels()

            '**********************************
            'check for user permition
            ShowHidePanels(Me.GiPanelAdminIndex)
            '**********************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Admin Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            'Invoke Garbage Collector
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '*******************************************************************************
    Private Sub cmdReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReports.Click
        Try
            '**********************************
            'Clear All controls in all panels
            ClearAllPanels()

            '**********************************
            'check for user permition
            ShowHidePanels(Me.GiPanelReportIndex)
            '**********************************
            Me.dtpRptShipFromDate.Value = Now
            Me.dtpRptShipToDate.Value = Now

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Report Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            'Invoke Garbage Collector
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '*******************************************************************************

#End Region

#Region "Receive"

    '*******************************************************************************
    Private Sub CreateRecItemsTable_Receive()
        Dim objGen As PSS.Data.Buisness.Generic

        Try
            objGen = New PSS.Data.Buisness.Generic()

            If Not IsNothing(Me.GdtRecItems) Then
                Me.GdtRecItems.Dispose()
                Me.GdtRecItems = Nothing
            End If

            Me.GdtRecItems = New DataTable()
            'SN
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "Serial Number", "System.String", "")
            'IsSalvage
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "IsSalvage", "System.Int32", "0")
            'Model
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "Model", "System.String", "")
            'UPCPartNumber
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "UPCPartNumber", "System.String", "")
            'Model_GSM
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "GSM", "System.Int32", "0")
            'ManufWrty
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "ManufWrty", "System.Int32", "0")
            'APC
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "APC", "System.String", "")
            'MSN
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "MSN", "System.String", "")
            'CSN
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "CSN", "System.String", "")
            'SugIn
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "SugIn", "System.String", "")
            'SoftVerIN
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "SoftVerIN", "System.String", "")
            ''RepairOrderNum
            'objGen.AddNewColumnToDataTable(Me.GdtRecItems, "RepairOrderNum", "System.String", "")
            'Csin_ID
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "Csin_ID", "System.Int32", "0")
            'Model_ID
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "Model_ID", "System.Int32", "0")
            'Sku_ID
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "Sku_ID", "System.Int32", 0)
            'Prod_ID
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "Prod_ID", "System.Int32", 0)
            'CamWithFile
            objGen.AddNewColumnToDataTable(Me.GdtRecItems, "CamWithFile", "System.Int32", 0)

        Catch ex As Exception
            Throw ex
        Finally
            objGen = Nothing
        End Try
    End Sub

    '*******************************************************************************
    Private Sub SetGridProperties_Receive()
        Dim iNumOfColumns As Integer = Me.grdRecDevices.Columns.Count
        Dim i As Integer

        Try
            With Me.grdRecDevices
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns("GSM").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("ManufWrty").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("IsSalvage").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("APC").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns("Serial Number").Width = 130
                .Splits(0).DisplayColumns("IsSalvage").Width = 70
                .Splits(0).DisplayColumns("Model").Width = 140
                .Splits(0).DisplayColumns("GSM").Width = 40
                .Splits(0).DisplayColumns("ManufWrty").Width = 70
                .Splits(0).DisplayColumns("APC").Width = 40
                .Splits(0).DisplayColumns("MSN").Width = 130
                .Splits(0).DisplayColumns("CSN").Width = 130
                .Splits(0).DisplayColumns("SugIn").Width = 120
                .Splits(0).DisplayColumns("SoftVerIN").Width = 120
                '.Splits(0).DisplayColumns("RepairOrderNum").Width = 140
                .Splits(0).DisplayColumns("UPCPartNumber").Width = 140
                '.Splits(0).DisplayColumns("Csin_ID").Width = 120
                '.Splits(0).DisplayColumns("Model_ID").Width = 120
                '.Splits(0).DisplayColumns("Sku_ID").Width = 120

                'Make some columns invisible
                .Splits(0).DisplayColumns("Csin_ID").Visible = False
                .Splits(0).DisplayColumns("Model_ID").Visible = False
                .Splits(0).DisplayColumns("Sku_ID").Visible = False
                .Splits(0).DisplayColumns("Prod_ID").Visible = False
                .Splits(0).DisplayColumns("CamWithFile").Visible = False

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*******************************************************************************
    Private Sub btnRecRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecRemoveOne.Click

        Dim R1 As DataRow
        Dim strSelectedSN As String = ""

        Try
            If IsNothing(Me.GdtRecItems) Then
                Exit Sub
            End If

            If Me.GdtRecItems.Rows.Count = 0 Then
                Exit Sub
            Else

                '*****************************
                'Ask user for confirm message
                '*****************************
                If MessageBox.Show("Are you sure you want to Clear the selected device?", "Remove ONE Serial Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    '*****************
                    'Get selected SN
                    '*****************
                    strSelectedSN = Trim(Me.grdRecDevices.Columns("Serial Number").Value)

                    '*******************************
                    'Remove selected SN in datatable
                    '*******************************
                    For Each R1 In Me.GdtRecItems.Rows
                        If R1("Serial Number") = strSelectedSN Then
                            Me.GdtRecItems.Rows.Remove(R1)
                            Me.GdtRecItems.AcceptChanges()

                            Exit For
                        End If
                    Next R1

                    '*******************************
                    'Reset datagrid, counter and msg label
                    '*******************************
                    If Me.GdtRecItems.Rows.Count > 0 Then
                        Me.grdRecDevices.MoveLast()
                    End If

                    Me.SetMsgLabel_Receive(Color.LightSteelBlue, Color.White, "")
                    Me.lblRecScanCnt.Text = GdtRecItems.Rows.Count
                    Me.txtRecPartNum.Text = ""
                    Me.txtRecDevSN.Focus()
                    '*******************************
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Remove ONE Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ''***************************************************
            ''Set datasource for datagrid if it is nothing.
            '' Datasorce set to nothing bydefault when exception is generated
            ''***************************************************
            'SetGridDatasource_Receive()
            ''****************************
        Finally
            R1 = Nothing
            Me.txtRecDevSN.Focus()
        End Try
    End Sub

    '*******************************************************************************
    Private Sub btnRecRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecRemoveAll.Click
        Dim R1 As DataRow

        Try
            If IsNothing(Me.GdtRecItems) Then
                Exit Sub
            End If

            If Me.GdtRecItems.Rows.Count = 0 Then
                Exit Sub
            Else
                '*****************************
                'Ask user for confirm message
                '*****************************
                If MessageBox.Show("Are you sure you want to Clear all devices?", "Remove ALL Serial Numbers", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    '************************
                    'Remove scanned devices
                    '************************
                    Me.GdtRecItems.Clear()

                    '****************************
                    'Reset counter and Msg label
                    '****************************
                    Me.SetMsgLabel_Receive(Color.LightSteelBlue, Color.White, "")
                    Me.lblRecScanCnt.Text = GdtRecItems.Rows.Count
                    Me.txtRecPartNum.Text = ""
                    Me.txtRecDevSN.Focus()
                    '****************************
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Remove ALL Serial Numbers", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ''***************************************************
            ''Set datasource for datagrid if it is nothing.
            '' Datasorce set to nothing bydefault when exception is generated
            ''***************************************************
            'SetGridDatasource_Receive()
            ''***************************************************
        Finally
            R1 = Nothing
            Me.txtRecDevSN.Focus()
        End Try
    End Sub

    '*******************************************************************************
    Private Sub cmdRecLoadDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecLoadDev.Click
        Dim i As Integer = 0
        Dim R1 As DataRow
        Dim booSNExisted As Boolean = False
        Dim objGen As New PSS.Data.Buisness.Generic()
        Dim iWO_GrpID As Integer = 3
        Dim iDevsFrBP As Integer = 0

        Try
            If Me.chkRec_DevsFrBP.Checked = True Then
                iDevsFrBP = 1
            End If

            If MessageBox.Show("Are you sure you want to load all device(s) into PSS system?", "Load Device(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Me.Enabled = False

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                If Me.GdtRecItems.Rows.Count > 0 Then
                    '****************************
                    'Check SN exist in WIP again
                    '****************************
                    For Each R1 In Me.GdtRecItems.Rows
                        booSNExisted = objGen.IsSNInWIP(Me.GiCust_ID, UCase(Trim(R1("Serial Number"))))
                        If booSNExisted = True Then
                            MessageBox.Show("This ""Serial Number: " & UCase(Trim(R1("Serial Number"))) & """ already exists in WIP. Please remove it before you load again.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtRecDevSN.SelectAll()
                            Exit Sub
                        End If
                        booSNExisted = False
                    Next R1

                    i = Me.GobjBrightpoint.RecBPDevicesIntoPSSWIP(iDevsFrBP, Me.GiCust_ID, _
                                              Me.GiLoc_ID, _
                                              Me.GstrEnterpriseCode, _
                                              Me.GstrUserName, _
                                              Me.GiUserID, _
                                              Me.GiEmpNo, _
                                              Me.GiShiftID, _
                                              Me.GstrWorkDate, _
                                              Me.GiMachineGroupID, _
                                              iWO_GrpID, _
                                              Me.GstrMachineGroupDesc, _
                                              Me.GiCell2SlvgGroup_ID, _
                                              Me.GiRURSalvageBillcode_ID, _
                                              Me.GdtRecItems)
                    If i > 0 Then
                        MessageBox.Show("Load completed.", "Load Device(s) into PSS WIP", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        GdtRecItems.Clear()
                        SetGridDatasource_Receive()
                        Me.SetMsgLabel_Receive(Color.LightSteelBlue, Color.White, "")
                        Me.lblRecScanCnt.Text = GdtRecItems.Rows.Count
                        Me.txtRecPartNum.Text = ""
                        Me.chkRecShipLess30Days.Checked = False
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, """Load Device(s)"" Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '***************************************************
            'Set datasource for datagrid if it is nothing.
            ' Datasorce set to nothing bydefault when exception is generated
            '***************************************************
            GdtRecItems.Clear()
            SetGridDatasource_Receive()
            '***************************************************
        Finally
            R1 = Nothing
            objGen = Nothing
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.Enabled = True
            Me.txtRecDevSN.Focus()
        End Try
    End Sub

    '*******************************************************************************
    Private Sub SetGridDatasource_Receive()
        Try
            If Not IsNothing(Me.GdtRecItems) Then
                If Me.grdRecDevices.DataSource = Nothing Then
                    Me.grdRecDevices.DataSource = Me.GdtRecItems
                    Me.SetGridProperties_Receive()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Set Datasource Properity", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*******************************************************************************
    Private Sub txtRecDevSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecDevSN.KeyUp
        Dim i As Integer = 0

        Try
            If e.KeyValue = 13 Then

                ''***************************
                ' Reset UPC Part Number
                ''***************************
                Me.txtRecPartNum.Text = ""

                If Trim(Me.txtRecDevSN.Text) = "" Then
                    Exit Sub
                End If
                If Len(Trim(Me.txtRecDevSN.Text)) <> 15 Then
                    MessageBox.Show("IMEI length must be 15 digits.", "Validate IMEI", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtRecDevSN.SelectAll()
                    Exit Sub
                End If
                If IsNumeric(Trim(Me.txtRecDevSN.Text)) = False Then
                    MessageBox.Show("IMEI must be 15 digits.", "Validate IMEI", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtRecDevSN.SelectAll()
                    Exit Sub
                End If

                ''***************************************
                'Limit the user to scan only 10 devices
                ''***************************************
                If Me.GdtRecItems.Rows.Count >= 15 Then
                    MessageBox.Show("You have reached the limit of ""15 devices"". Please click ""Load Device(s)"" button and continue.", "Scan Limit", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtRecDevSN.Text = ""
                    Me.txtRecDevSN.Focus()
                    Exit Sub
                End If

                i = Me.ProcessBPSerialNum_Receive
                ''***************************
                If i > 0 Then
                    Me.txtRecDevSN.Text = ""
                    Me.txtRecPartNum.Text = ""
                    Me.txtRecDevSN.Focus()
                End If
                ''***************************
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Scanned SN Keyup", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ''***************************************************
            ''Set datasource for datagrid if it is nothing.
            '' Datasorce set to nothing bydefault when exception is generated
            ''***************************************************
            'SetGridDatasource_Receive()
            ''**************************
        End Try
    End Sub

    '*******************************************************************************
    Private Sub txtRecDevSN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecDevSN.KeyPress
        If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    '*******************************************************************************
    Private Function IsSNDuplicateInList_Receive(ByVal strSN As String) As Boolean
        Dim booResult As Boolean = False
        Dim R1 As DataRow

        Try
            If Not IsNothing(Me.GdtRecItems) Then
                For Each R1 In Me.GdtRecItems.Rows
                    If strSN = R1("Serial Number") Then
                        booResult = True
                    End If
                Next R1
            End If

            Return booResult
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
        End Try
    End Function

    '*******************************************************************************
    Public Function ProcessBPSerialNum_Receive() As Integer
        Dim booDuplicate As Boolean = False
        Dim booSNExisted As Boolean = False
        Dim iIsSalvageSN As Integer = 0
        Dim booSNBeenHereAndShippedLessThan30Days As Boolean = False
        Dim objGen As PSS.Data.Buisness.Generic
        Dim i As Integer = 0

        Try
            objGen = New PSS.Data.Buisness.Generic()

            '*********************
            '1:: Check Duplicate
            '*********************
            booDuplicate = IsSNDuplicateInList_Receive(UCase(Trim(Me.txtRecDevSN.Text)))
            If booDuplicate = True Then
                MessageBox.Show("This device is already scanned in. Try another one.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtRecDevSN.SelectAll()
                Exit Function
            End If
            '*********************************
            '2:: Check if device exist in WIP
            '*********************************
            booSNExisted = objGen.IsSNInWIP(Me.GiCust_ID, UCase(Trim(Me.txtRecDevSN.Text)))
            If booSNExisted = True Then
                MessageBox.Show("This ""Serial Number"" already exists in WIP.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtRecDevSN.SelectAll()
                Exit Function
            End If
            '**************************************
            '3:: Check if device exist in Salvage 
            '**************************************
            iIsSalvageSN = Me.GobjBrightpoint.IsSalvageSN(Me.GiLoc_ID, UCase(Trim(Me.txtRecDevSN.Text)))
            If iIsSalvageSN > 0 Then
                MessageBox.Show("This is salvage device. Can not receive.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtRecDevSN.SelectAll()
                Exit Function
            End If
            '*********************************
            '4:: Check if device exist in WIP
            '*********************************
            If Me.chkRecShipLess30Days.Checked = False Then
                booSNBeenHereAndShippedLessThan30Days = Me.GobjBrightpoint.IsSNBeenHereAndShippedInLessThan30Days(Me.GiCust_ID, UCase(Trim(Me.txtRecDevSN.Text)))
                If booSNBeenHereAndShippedLessThan30Days = True Then
                    MessageBox.Show("This ""Serial Number"" been here and shipped out less than 30 days. Can not receive again.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtRecDevSN.SelectAll()
                    Exit Function
                End If
            End If
            '*************************************************
            '5::Create a new insert record for scanned device
            '*************************************************
            i = CreateNewRecord_DOB_Receive()
            '**********************************

            Return i
        Catch ex As Exception
            Throw ex
        Finally
            objGen = Nothing
        End Try
    End Function

    '*******************************************************************************
    Private Function CreateNewRecord_DOB_Receive() As Integer
        Dim drNewRow As DataRow
        Dim dt1, dt2 As DataTable
        Dim R1, R2 As DataRow
        Dim iProd_ID As Integer = 0
        Dim iManuf_ID As Integer = 0
        Dim iModel_ID As Integer = 0
        Dim iGSMFlg As Integer = 0
        Dim iSalvage As Integer = 0
        Dim DlgRsltSalvage As DialogResult
        Dim booValidMotoWrtyData As Boolean = False
        Dim frmMWrtyData As Object
        Dim booValidBillcode As Boolean = False
        'Dim objGenBilling As New PSS.Data.Buisness.GenerateBilling()

        Try
            drNewRow = Me.GdtRecItems.NewRow()
            drNewRow("Serial Number") = UCase(Trim(Me.txtRecDevSN.Text))

            '***************************
            '1::User first scan device
            '***************************

            dt1 = Me.GobjBrightpoint.GetRecDeviceInfo(UCase(Trim(Me.txtRecDevSN.Text)))

            If dt1.Rows.Count > 0 Then
                '*********************************************
                'Device come from Dobson store with data file
                '*********************************************
                R1 = dt1.Rows(0)

                Me.txtRecPartNum.Text = R1("csin_ItemNum")

                '*********************
                'Validate data
                '*********************
                'If IsDBNull(R1("csin_RepairOrderNum")) Then 'Never happen b/c it get validate when we load ASN
                '    Me.txtRecDevSN.Text = ""
                '    Throw New Exception("Repair Order is missing.")
                'End If

                If IsDBNull(R1("part_id")) Then 'Happen when UPC Part number is not mapped in our database
                    Me.txtRecDevSN.Text = ""
                    MessageBox.Show("'Part Number' of this device must be mapped before receive.", "Device has no Data File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.SetMsgLabel_Receive(Color.Red, Color.White, "REJECT")
                    Exit Function
                End If

                If IsDBNull(R1("part_number")) Then 'Never happen
                    Me.txtRecDevSN.Text = ""
                    MessageBox.Show("Part Number is missing.", "Part Description", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If

                If IsDBNull(R1("Model_Desc")) Then  'Never happen
                    Me.txtRecDevSN.Text = ""
                    MessageBox.Show("Part Number of this device have mapped to an invalid model.", "Model Description", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If

                '****************************
                'store receiving data
                '****************************
                iGSMFlg = R1("Model_GSM")
                iModel_ID = R1("model_id")
                iManuf_ID = R1("Manuf_ID")
                iProd_ID = R1("Prod_ID")
                iSalvage = R1("inactive")

                drNewRow("Csin_ID") = R1("csin_ID")
                'drNewRow("RepairOrderNum") = UCase(Trim(R1("csin_RepairOrderNum")))
                drNewRow("Sku_ID") = R1("part_id")
                drNewRow("UPCPartNumber") = UCase(Trim(R1("part_number")))
                drNewRow("Model_ID") = R1("model_id")
                drNewRow("Model") = Trim(R1("Model_Desc"))
                drNewRow("GSM") = R1("Model_GSM")
                drNewRow("Prod_ID") = R1("Prod_ID")
                drNewRow("CamWithFile") = R1("CameWithFileFlg")
                drNewRow("IsSalvage") = iSalvage

            Else
                If Trim(Me.txtRecPartNum.Text) = "" Then
                    MessageBox.Show("Please scan in UPC part number.", "UPC Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtRecPartNum.Focus()
                    Exit Function
                End If
                'If Len(Trim(Me.txtRecPartNum.Text)) <> 12 Then
                '    MessageBox.Show("Invalid UPC number. UPC part number must be 12-digits number.", "Validate UPC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    Me.txtRecPartNum.SelectAll()
                '    Exit Function
                'End If
                If IsNumeric(Trim(Me.txtRecDevSN.Text)) = False Then
                    MessageBox.Show("UPC number must be numeric.", "Validate UPC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtRecPartNum.SelectAll()
                    Exit Function
                End If
                '*****************************************************
                'Device come from customer. User has selected model.
                '*****************************************************
                '' Get UPC Part Number Information
                '**********************************
                dt2 = Me.GobjBrightpoint.GetBPRecUPCNumInfo(UCase(Trim(Me.txtRecPartNum.Text)))
                If dt2.Rows.Count > 0 Then
                    '*************************************
                    'Identify device status(repair or salvage)
                    '*************************************
                    R2 = dt2.Rows(0)
                    If IsDBNull(R2("part_number")) Then 'Never happen
                        Me.txtRecDevSN.Text = ""
                        MessageBox.Show("Part Number is missing.", "Part Description", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Function
                    End If

                    If IsDBNull(R2("Model_Desc")) Then  'Never happen
                        Me.txtRecDevSN.Text = ""
                        MessageBox.Show("Part Number of this device have mapped to an invalid model.", "Model Description", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Function
                    End If

                    '****************************
                    'store receiving data
                    '****************************
                    iGSMFlg = R2("Model_GSM")
                    iModel_ID = R2("Model_ID")
                    iManuf_ID = R2("Manuf_ID")
                    iProd_ID = R2("Prod_ID")
                    iSalvage = R2("inactive")

                    drNewRow("Sku_ID") = R2("part_id")
                    drNewRow("UPCPartNumber") = UCase(Trim(Me.txtRecPartNum.Text))
                    drNewRow("Model_ID") = R2("Model_ID")
                    drNewRow("Model") = Trim(R2("Model_Desc"))
                    drNewRow("GSM") = R2("Model_GSM")
                    drNewRow("Prod_ID") = R2("Prod_ID")
                    drNewRow("CamWithFile") = 0
                    drNewRow("IsSalvage") = iSalvage

                Else
                    Me.txtRecDevSN.Text = ""
                    Me.txtRecDevSN.Focus()
                    MessageBox.Show("'Part Number' of this device must be mapped before receive.", "Device has no Data File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.SetMsgLabel_Receive(Color.Red, Color.White, "REJECT")
                    Exit Function
                End If
            End If  'Check if device has data file


            '***************************************************
            '2::Get Warranty info for Motorola and Nokia device
            '***************************************************
            If iModel_ID > 0 Then
                If iSalvage = 0 And iProd_ID = 2 Then   'cell phone product
                    If iManuf_ID = 1 And Me.GSendMClaimFlg = 1 Then     'Motorola 
                        'THIS SECTION COMMENTED B/C WE DON'T SUBMIT MCLAIM
                        '*************************************
                        'Call Warranty Collection Data window
                        '*************************************
                        frmMWrtyData = New Gui.Motorola.frmCollectMotoWrtyData(iModel_ID, iGSMFlg)
                        frmMWrtyData.ShowDialog()
                        booValidMotoWrtyData = frmMWrtyData.ReturnFlg
                        If booValidMotoWrtyData = False Then
                            Me.SetMsgLabel_Receive(Color.Red, Color.White, "REJECT")
                            MessageBox.Show("This device did not complete 'Motorola Warranty Data Collection'. Device canceled.", "Motoral Warranty Data Collection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtRecDevSN.Focus()
                            Exit Function
                        Else
                            drNewRow("ManufWrty") = frmMWrtyData.ManufWrty
                            drNewRow("APC") = frmMWrtyData.APC
                            drNewRow("MSN") = frmMWrtyData.MSN
                            drNewRow("CSN") = frmMWrtyData.CSN
                            drNewRow("SugIn") = frmMWrtyData.SugIn
                            drNewRow("SoftVerIN") = frmMWrtyData.SoftVerIN
                        End If
                    ElseIf (iManuf_ID = 24 OrElse iManuf_ID = 48) AndAlso Me.GSendNKClaimFlg = 1 Then  'Nokia
                        '*************************************
                        'Call Warranty Collection Data window
                        '*************************************
                        frmMWrtyData = New Gui.ManufWarrantyInfo.frmCollectWrtyDateCode(iManuf_ID)
                        frmMWrtyData.ShowDialog()
                        booValidMotoWrtyData = frmMWrtyData.ReturnFlg
                        If booValidMotoWrtyData = False Then
                            Me.SetMsgLabel_Receive(Color.Red, Color.White, "REJECT")
                            MessageBox.Show("This device did not complete 'Motorola Warranty Data Collection'. Device canceled.", "Motoral Warranty Data Collection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtRecDevSN.Focus()
                            Exit Function
                        Else
                            drNewRow("ManufWrty") = frmMWrtyData.ManufWrty
                            'drNewRow("APC") = frmMWrtyData.APC
                            'drNewRow("MSN") = frmMWrtyData.MSN
                            'drNewRow("CSN") = frmMWrtyData.CSN
                            'drNewRow("SugIn") = frmMWrtyData.SugIn
                            'drNewRow("SoftVerIN") = frmMWrtyData.SoftVerIN
                        End If
                    End If  'Check Manufacturer
                End If  'No need to check Wrty if device is salvage or not phone product
            Else
                MessageBox.Show("Can not define model.", "Model ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Function
            End If

            '''***************************************
            '''Validate Salvage billcode for this model
            '''***************************************
            ''If iSalvage = 0 Then
            ''    booValidBillcode = objGenBilling.ValidateBillcode(Me.GiRURSalvageBillcode_ID, CStr(iModel_ID))
            ''    If booValidBillcode = False Then
            ''        MessageBox.Show("‘RUR Salvage’ bill code is missing. Cannot continue.", "Validate RUR-Salvage BillCode", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ''        Me.txtRecDevSN.SelectAll()
            ''        Exit Function
            ''    End If
            ''End If

            '***************************
            '3::adding new row to datatable
            '***************************
            Me.GdtRecItems.Rows.Add(drNewRow)
            Me.GdtRecItems.AcceptChanges()

            '*******************************************************
            '4::Display Message and update counter
            '*******************************************************
            If iSalvage = 0 Then
                Me.SetMsgLabel_Receive(Color.SteelBlue, Color.White, "REPAIR")
            Else
                Me.SetMsgLabel_Receive(Color.Black, Color.Yellow, "SALVAGE")
            End If

            Me.lblRecScanCnt.Text = Me.GdtRecItems.Rows.Count

            If Me.GdtRecItems.Rows.Count > 0 Then
                Me.grdRecDevices.MoveLast()
            End If
            '*******************************************************

            Return 1
        Catch ex As Exception
            Throw ex
        Finally
            ''objGenBilling = Nothing
            drNewRow = Nothing
            R1 = Nothing
            R2 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            If Not IsNothing(dt2) Then
                dt2.Dispose()
                dt2 = Nothing
            End If
            If Not IsNothing(frmMWrtyData) Then
                frmMWrtyData.Dispose()
                frmMWrtyData = Nothing
            End If
        End Try
    End Function

    '*******************************************************************************
    Private Sub SetMsgLabel_Receive(ByVal BGColor As Color, ByVal FColor As Color, ByVal strText As String)
        Me.lblRecMsg.Text = strText
        Me.lblRecMsg.BackColor = BGColor
        Me.lblRecMsg.ForeColor = FColor
    End Sub

    '*******************************************************************************
    Private Sub txtRecPartNum_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecPartNum.KeyUp
        Dim i As Integer = 0

        Try
            If e.KeyValue = 13 Then

                If Trim(Me.txtRecPartNum.Text) = "" Then
                    Exit Sub
                End If
                'If Len(Trim(Me.txtRecPartNum.Text)) <> 12 Then
                '    MessageBox.Show("Invalid UPC number. UPC part number must be 12-digits number.", "Validate UPC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'End If
                If Len(Trim(Me.txtRecDevSN.Text)) <> 15 Then
                    MessageBox.Show("IMEI length must be 15 digits.", "Validate IMEI", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtRecDevSN.SelectAll()
                    Exit Sub
                End If
                If IsNumeric(Trim(Me.txtRecDevSN.Text)) = False Then
                    MessageBox.Show("UPC number must be digits.", "Validate UPC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtRecPartNum.SelectAll()
                    Exit Sub
                End If

                ''***************************************
                'Limit the user to scan only 10 devices
                ''***************************************
                If Me.GdtRecItems.Rows.Count >= 15 Then
                    MessageBox.Show("You have reached the limit of ""15 devices"". Please click ""Load Device(s)"" button and continue.", "Scan Limit", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtRecDevSN.Text = ""
                    Me.txtRecDevSN.Focus()
                    Exit Sub
                End If

                i = Me.ProcessBPSerialNum_Receive
                ''***************************
                If i > 0 Then
                    Me.txtRecDevSN.Text = ""
                    Me.txtRecPartNum.Text = ""
                    Me.txtRecDevSN.Focus()
                End If
                ''***************************
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Scanned SN Keyup", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ''***************************************************
            ''Set datasource for datagrid if it is nothing.
            '' Datasorce set to nothing bydefault when exception is generated
            ''***************************************************
            'SetGridDatasource_Receive()
            ''**************************
        End Try
    End Sub

    '*******************************************************************************

#End Region


#Region "Salvage"

    '*******************************************************************************
    Private Sub PopulateSalvageQty_Ship()
        Dim dt1 As DataTable
        Dim iNumOfColumns As Integer = 0
        Dim i As Integer

        Try
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If

            dt1 = Me.GobjBrightpoint.GetSlvgQtyByModel(Me.GiCust_ID, Me.GiLoc_ID)
            Me.grdSlvgSlvgInfo.DataSource = Nothing
            Me.grdSlvgSlvgInfo.DataSource = dt1

            iNumOfColumns = Me.grdSlvgSlvgInfo.Columns.Count

            With Me.grdSlvgSlvgInfo
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                If iNumOfColumns > 0 Then
                    .Splits(0).DisplayColumns("QTY").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    'Set Column Widths
                    .Splits(0).DisplayColumns("Model").Width = 145
                    .Splits(0).DisplayColumns("QTY").Width = 50
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Populate Data Salvage Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************************
    Private Sub DisableEnableRadioButton(ByVal iDisableFlg As Integer)

        If iDisableFlg = 1 Then
            Me.rdbtnSlvgTransToSlvg.Enabled = False
            Me.rdbtnSlvgTransToIntransit.Enabled = False
        Else
            Me.rdbtnSlvgTransToSlvg.Enabled = True
            Me.rdbtnSlvgTransToIntransit.Enabled = True
        End If
    End Sub

    '*******************************************************************************
    Private Function ProcessSalvage_Salvage() As Integer
        Dim objGen As New PSS.Data.Buisness.Generic()
        Dim iDevice_ID As Integer = 0
        Dim strEnterprise As String = ""
        Dim booIsRURDev As Boolean = False

        Try
            '***************************
            'Check for existing of device
            '***************************
            iDevice_ID = objGen.GetDevIDInWIPBySNCustID(UCase(Trim(Me.txtSlvgDevSN.Text)), Me.GiCust_ID)
            If iDevice_ID = 0 Then
                MessageBox.Show("Device SN does not exist in WIP.", "ProcessSalvage", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSlvgDevSN.SelectAll()
                Exit Function
            End If

            '**********************************
            'Check if device belongs to Dobson
            '**********************************
            strEnterprise = Me.GobjBrightpoint.GetDeviceEnterpriseInWIP(UCase(Trim(Me.txtSlvgDevSN.Text)), Me.GiCust_ID)
            If UCase(Trim(strEnterprise)) <> "DOB" And UCase(Trim(strEnterprise)) <> "DBR" Then
                MessageBox.Show("Device SN does not belongs to Dobson.", "ProcessSalvage", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSlvgDevSN.SelectAll()
                Exit Function
            End If

            '*************************************************
            'Check if device contains any parts or services
            '*************************************************
            booIsRURDev = objGen.IsRURDev(iDevice_ID)
            If booIsRURDev = False Then
                MessageBox.Show("Device SN is not an RUR device. Please bill RUR before transferring it to salvage.", "ProcessSalvage", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSlvgDevSN.SelectAll()
                Exit Function
            End If

            Return 1
        Catch ex As Exception
            Throw ex
        Finally
            objGen = Nothing
        End Try
    End Function

    '*******************************************************************************
    Private Function ProcessSalvageSold_Salvage() As Integer
        Dim iIsSlvgDev As Integer = 0

        Try
            '*************************************************
            'Check if device contains any parts or services
            '*************************************************
            iIsSlvgDev = Me.GobjBrightpoint.IsSalvageSN(Me.GiLoc_ID, UCase(Trim(Me.txtSlvgDevSN.Text)))
            If iIsSlvgDev = 0 Then
                MessageBox.Show("SN was not a ""Salvage Device"".", "ProcessSalvage", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSlvgDevSN.SelectAll()
                Exit Function
            End If

            Return 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '*******************************************************************************
    Private Sub txtSlvgDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSlvgDevSN.KeyUp
        Dim i As Integer = 0

        Try
            If e.KeyValue = 13 Then

                If Me.txtSlvgDevSN.Text = "" Then
                    Exit Sub
                End If

                ''***************************************
                'Limit the user to scan only upto 100 devices
                ''***************************************
                If Me.lstSlvgSNs.Items.Count >= 500 Then
                    MessageBox.Show("You have reached the limit of ""100 devices"". Please click ""TRANSFER"" button and continue.", "Scan Limit", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtSlvgDevSN.Text = ""
                    Me.txtSlvgDevSN.Focus()
                    Exit Sub
                End If


                If Me.rdbtnSlvgTransToSlvg.Checked = True Then
                    i = Me.ProcessSalvage_Salvage()
                    If i = 0 Then
                        Exit Sub
                    End If
                ElseIf Me.rdbtnSlvgTransToIntransit.Checked = True Then
                    i = Me.ProcessSalvageSold_Salvage
                    If i = 0 Then
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Please select the location that you want to transfer to.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtSlvgDevSN.SelectAll()
                    Exit Sub
                End If

                '**********************
                'Check for duplicate
                '**********************
                If Me.lstSlvgSNs.Items.Count > 0 Then
                    For i = 0 To Me.lstSlvgSNs.Items.Count - 1
                        If UCase(Trim(Me.txtSlvgDevSN.Text)) = Me.lstSlvgSNs.Items.Item(i) Then
                            MessageBox.Show("This device is already scanned in. Try another one.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtSlvgDevSN.Text = ""
                            Exit Sub
                        End If
                    Next i
                End If

                '********************
                'Add SN into list
                '********************
                Me.lstSlvgSNs.Items.Add(UCase(Trim(Me.txtSlvgDevSN.Text)))
                Me.lstSlvgSNs.Refresh()
                Me.lblSlvgScanCnt.Text = Me.lstSlvgSNs.Items.Count
                Me.txtSlvgDevSN.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Salvage SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************************
    Private Sub btnSlvgRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlvgRemoveOne.Click
        Dim strSelectedSN As String = ""
        Dim i As Integer = 0

        If Me.lstSlvgSNs.Items.Count = 0 Then
            Me.txtRecDevSN.Focus()
            Exit Sub
        Else

            '*****************************
            'Ask user for confirm message
            '*****************************
            If MessageBox.Show("Are you sure you want to clear one device?", "Remove ONE Serial Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                '*****************
                'Get selected SN
                '*****************
                strSelectedSN = UCase(Trim(InputBox("Please scan SN", "SN")))
                If strSelectedSN = "" Then
                    Me.txtRecDevSN.Focus()
                    Exit Sub
                End If

                '*******************************
                'Remove selected SN in datatable
                '*******************************
                For i = 0 To Me.lstSlvgSNs.Items.Count - 1
                    If Me.lstSlvgSNs.Items.Item(i) = strSelectedSN Then
                        Me.lstSlvgSNs.Items.RemoveAt(i)
                        Exit For
                    End If
                Next i

                Me.lblSlvgScanCnt.Text = Me.lstSlvgSNs.Items.Count
            End If
        End If

        Me.txtRecDevSN.Focus()
    End Sub

    '*******************************************************************************
    Private Sub btnSlvgRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlvgRemoveAll.Click
        If Me.lstSlvgSNs.Items.Count = 0 Then
            Me.txtSlvgDevSN.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to Clear the selected device?", "Remove ONE Serial Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Me.lstSlvgSNs.Items.Clear()
            Me.lstSlvgSNs.Refresh()
            Me.lblSlvgScanCnt.Text = Me.lstSlvgSNs.Items.Count
        End If

        Me.txtSlvgDevSN.Focus()
    End Sub

    '*******************************************************************************
    Private Sub rdbtnSlvg_ClickEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtnSlvgTransToIntransit.Click, rdbtnSlvgTransToSlvg.Click
        Me.lstSlvgSNs.Items.Clear()
        Me.lstSlvgSNs.Refresh()
        Me.txtSlvgMemo.Focus()
    End Sub

    '*******************************************************************************
    Private Sub txtSlvgMemo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSlvgMemo.KeyUp
        If e.KeyValue = 13 Then
            Me.txtSlvgDevSN.Focus()
        End If
    End Sub

    '*******************************************************************************
    Private Sub btnSlvgTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlvgTransfer.Click
        Dim i As Integer = 0
        Dim iSlvgDev_ID As Integer = 0
        Dim strDevice_IDs As String = ""

        Try
            If Me.lstSlvgSNs.Items.Count = 0 Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want transfer all devices into salvage?", "Transfer Device to Salvage", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                If Me.rdbtnSlvgTransToSlvg.Checked = True Then
                    '***************************************
                    'Transfer RUR devices to Salvage
                    '***************************************
                    i = Me.GobjBrightpoint.Transf_RepDev_To_Slvg(Me.GiMachineGroupID, _
                                                        Me.GiUserID, _
                                                        Me.GstrUserName, _
                                                        Me.GiEmpNo, _
                                                        Me.GiShiftID, _
                                                        Me.GstrWorkDate, _
                                                        Me.GiWCLocationID, _
                                                        Me.GiLineID, _
                                                        Me.GiCust_ID, _
                                                        Me.GiLoc_ID, _
                                                        Me.lstSlvgSNs)
                ElseIf Me.rdbtnSlvgTransToIntransit.Checked = True Then
                    For i = 0 To Me.lstSlvgSNs.Items.Count - 1
                        '***********************
                        'Get Salvage Device_ID
                        '***********************
                        iSlvgDev_ID = Me.GobjBrightpoint.IsSalvageSN(Me.GiLoc_ID, UCase(Trim(Me.lstSlvgSNs.Items.Item(i))))
                        If iSlvgDev_ID = 0 Then
                            MessageBox.Show("Device SN """ & UCase(Trim(Me.lstSlvgSNs.Items.Item(i))) & """ does not exist in salvage bucket. Please remove it from the list.", "Validate Salvage Device", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        '***********************
                        'Build Device ID string
                        '***********************
                        If strDevice_IDs = "" Then
                            strDevice_IDs &= iSlvgDev_ID
                        Else
                            strDevice_IDs &= "," & iSlvgDev_ID
                        End If
                        iSlvgDev_ID = 0
                    Next i

                    '***************************************
                    'Transfer salvage devices to intransit
                    '***************************************
                    i = Me.GobjBrightpoint.Transf_SlvgDev_To_Intransit(Me.GiMachineGroupID, _
                                                        Me.GiCust_ID, _
                                                        Me.GiLoc_ID, _
                                                        Me.GiUserID & "-" & UCase(Trim(Me.txtSlvgMemo.Text)), _
                                                        Me.lstSlvgSNs.Items.Count, _
                                                        strDevice_IDs)
                End If

                If i > 0 Then
                    MessageBox.Show("Transfer completed.", "Device(s) Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.lstSlvgSNs.Items.Clear()
                    Me.lstSlvgSNs.Refresh()
                    Me.lblSlvgScanCnt.Text = Me.lstSlvgSNs.Items.Count
                    Me.PopulateSalvageQty_Ship()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Device(s) Transfer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtSlvgDevSN.Focus()
        End Try
    End Sub

    '*******************************************************************************
#End Region


#Region "Admin"

    '*******************************************************************************
    Private Sub btnAdminLoadASNFrmDOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminLoadASNFrmDOB.Click
        Dim i As Integer = 0

        Try
            Me.Enabled = False
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            i = Me.GobjBrightpoint.LoadASNFrDobson()

            MessageBox.Show(i & " device(s) have been loaded.", "Load ASN From DOB", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Load ASN From DOB", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try

    End Sub

    '*******************************************************************************
    Private Sub btnAdminCloseTodaysPreBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminCloseTodaysPreBill.Click
        Dim i As Integer = 0
        Dim objPartRelated As New PSS.Data.Buisness.PartRelated()

        Try
            i = objPartRelated.CloseTodaysPreBill(Me.GiLoc_ID, Me.GiUserID, Me.GiShiftID)

            If i > 0 Then
                MessageBox.Show("Close completed.", "Close Today's PreBill", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("There is no pre-bill data to close.", "Close Today's PreBill", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Close Today's PreBill", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************************
    Private Sub txtAdminPreBillSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdminPreBillSN.KeyUp
        Dim dt1 As DataTable
        Dim objPartRelated As PSS.Data.Buisness.PartRelated

        Try
            If e.KeyValue = 13 Then

                'Clear Pre-Bill Lot Name
                Me.lblAdminLotName.Text = ""

                If Trim(Me.txtAdminPreBillSN.Text) = "" Then
                    Exit Sub
                End If

                'Get Lot Name by SN
                objPartRelated = New PSS.Data.Buisness.PartRelated()
                dt1 = objPartRelated.GetPreBillLotBySN(Me.txtAdminPreBillSN.Text.Trim, Me.GiLoc_ID)

                If dt1.Rows.Count = 0 Then
                    MessageBox.Show("Device SN either does not exist in the system or does not belong to any of 'Pre-Bill Lot'.", "Get Pre-Bill Lot", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    Me.lblAdminLotName.Text = dt1.Rows(0)("PreBillLot_Name")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Pre-Bill Lot From SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objPartRelated = Nothing
            pss.Data.Buisness.Generic.DisposeDT(dt1)
        End Try
    End Sub

    '*******************************************************************************
    Private Sub btnAdminReprintPreBillLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminReprintPreBillLot.Click
        Dim objPartRelated As PSS.Data.Buisness.PartRelated
        Try
            If Trim(Me.lblAdminLotName.Text) <> "" Then

                If MessageBox.Show("Are you sure you want print a report for this Pre-Bill Lot?", "Print Pre-Bill Lot", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor : Me.Enabled = False
                    objPartRelated = New PSS.Data.Buisness.PartRelated()
                    objPartRelated.PrintPreBillLotDetailsRpt(Trim(Me.lblAdminLotName.Text))
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Print Pre-Bill Lot Rpt", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = System.Windows.Forms.Cursors.Default
            objPartRelated = Nothing
        End Try
    End Sub

    '*******************************************************************************

#End Region


#Region "Report"

    '*******************************************************************************
    Private Sub btnRptWIPRptToDOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRptWIPRptToDOB.Click
        Dim i As Integer = 0
        Dim iSalvagePallett_ID As Integer = 0
        Dim iProd_ID As Integer = 2

        Try
            Me.Enabled = False
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            iSalvagePallett_ID = Me.GobjBrightpoint.GetBPSalvagePallet_ID(Me.GiCust_ID, Me.GiLoc_ID, )

            If iSalvagePallett_ID = 0 Then
                MessageBox.Show("Salvage pallet is missing.", "Get Salvage Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            i = Me.GobjBrightpoint.PSSIReceiptToDobson(Me.GiLoc_ID, iSalvagePallett_ID, iProd_ID)

            If i > 0 Then
                MessageBox.Show("Reports have been created.", "Generate WIP Rpt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "WIP Rp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*******************************************************************************
    Private Sub btnRptGenASNRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRptGenASNRpt.Click
        Dim i As Integer = 0

        Try
            If Me.dtpRptShipFromDate.Text = "" Or Me.dtpRptShipToDate.Text = "" Then
                MsgBox("Please select 'Ship Date From' and 'Ship Date to'.", MsgBoxStyle.Information, "ASN Report")
                Exit Sub
            End If

            If Me.dtpRptShipToDate.Value < Me.dtpRptShipFromDate.Value Then
                MsgBox("'Ship Date to' can't be before 'Ship Date From'.", MsgBoxStyle.Information, "ASN Report")
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            i = Me.GobjBrightpoint.ASNToBrightPoint(Me.GiLoc_ID, Me.dtpRptShipFromDate.Text, Me.dtpRptShipToDate.Text)

            If i > 0 Then
                MessageBox.Show("Reports have been created.", "ASN Rpt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ASN Rpt", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*******************************************************************************
#End Region

    '*******************************************************************************






    

    
End Class
