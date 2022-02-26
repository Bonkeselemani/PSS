Option Explicit On 

Imports PSS.Rules
Imports PSS.Core.Global
Imports C1.Win.C1TrueDBGrid
Imports CrystalDecisions.CrystalReports.Engine
Imports PSS.Data.Buisness

Public Class frmMessConsole
    Inherits System.Windows.Forms.Form

    Private GobjMessAdmin As PSS.Data.Buisness.MessAdmin
    Private GobjMessReceive As PSS.Data.Buisness.MessReceive
    Private GobjMessLabel As PSS.Data.Buisness.MessLabel
    Private GobjMessAbacus As PSS.Data.Buisness.MessAbacusData
    Private GobjMessTrayMan As PSS.Data.Buisness.MessTrayManipulate
    Private _objMsgGoalsDB As PSS.Data.Buisness.MessProdTracking
    Private _objMessReports As PSS.Data.Buisness.MessReports

    Private GstrMachine As String = System.Net.Dns.GetHostName
    Private GstrUserName As String = PSS.Core.Global.ApplicationUser.User
    Private GiUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private GiShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    Private GstrWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate

    '*******************************
    'Receving section
    '*******************************
    'Panel Specific Global Variables
    Private GdtRecDBGrid As DataTable
    Private GstrRecWO As String = ""
    Private GiRecWOID As Integer = 0
    Private GiRecLocID As Integer = 0
    Private GiRecCustID As Integer = 0
    Private GiRecFreq_id As Integer = 0
    Private GstrRecFreqNumber As String = ""
    Private GiRecFreq_code As Integer = 0
    Private GiRecBaud_id As Integer = 0
    Private GstrRecBaudRate As String = ""
    Private GstrRecSKU As String = ""
    Private GstrRecParentWO As String = ""
	Private GiRecParentWO_ID As Integer = 0
	Private _user_id As Integer = 0
    '*******************************
    'Slit Tray section
    '*******************************
    Private _dtDevices As DataTable
    '*******************************
    'Product tracker
    '*******************************
    Private _dtEditMsgWeeklyGoal As DataTable
    '*******************************

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
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents cmdLabeling As System.Windows.Forms.Button
    Friend WithEvents cmdAdmin As System.Windows.Forms.Button
    Friend WithEvents cmdReceive As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnRecClear As System.Windows.Forms.Button
    Friend WithEvents btnRecClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdRecTray As System.Windows.Forms.Button
    Friend WithEvents txtRecDevSN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRecWO As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmdRecReprintManifest As System.Windows.Forms.Button
    Friend WithEvents lblRecPO As System.Windows.Forms.Label
    Friend WithEvents lblRecAddress As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblRecLoc As System.Windows.Forms.Label
    Friend WithEvents lblRecDevRcvdCnt As System.Windows.Forms.Label
    Friend WithEvents cmbRecCust As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdRecDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lbllblModel As System.Windows.Forms.Label
    Friend WithEvents lbllblCust As System.Windows.Forms.Label
    Friend WithEvents chklblND As System.Windows.Forms.CheckBox
    Friend WithEvents cmdlblPrint As System.Windows.Forms.Button
    Friend WithEvents txtlblCap As System.Windows.Forms.TextBox
    Friend WithEvents txtlblSN As System.Windows.Forms.TextBox
    Friend WithEvents cmblblBaud As System.Windows.Forms.ComboBox
    Friend WithEvents msklblFreq As AxMSMask.AxMaskEdBox
    Friend WithEvents chklblPlus As System.Windows.Forms.CheckBox
    Friend WithEvents chkClearData As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRecTray_ID As System.Windows.Forms.TextBox
    Friend WithEvents lblRecScanCnt As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents txtRecTrayMemo As System.Windows.Forms.TextBox
    Friend WithEvents lblRecWOHasFile As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lbllblDaily As System.Windows.Forms.Label
    Friend WithEvents lbllblweekly As System.Windows.Forms.Label
    Friend WithEvents lblRecModelDesc As System.Windows.Forms.Label
    Friend WithEvents cmdAbacusData As System.Windows.Forms.Button
    Friend WithEvents grdAbacusData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtAbacusSearchCriteria As System.Windows.Forms.TextBox
    Friend WithEvents cmbAbacusSearchType As PSS.Gui.Controls.ComboBox
    Friend WithEvents grdAbacusRecData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnRecDBRTray As System.Windows.Forms.Button
    Friend WithEvents chkRecCheckWarranty As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintModelLetter As System.Windows.Forms.CheckBox
    Friend WithEvents lstModelType As System.Windows.Forms.ListBox
    Friend WithEvents lblModelType As System.Windows.Forms.Label
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpgAdmin As System.Windows.Forms.TabPage
    Friend WithEvents tpgRec As System.Windows.Forms.TabPage
    Friend WithEvents tpgLabel As System.Windows.Forms.TabPage
    Friend WithEvents tpgAbacusData As System.Windows.Forms.TabPage
    Friend WithEvents btnAdminAMValidateData As System.Windows.Forms.Button
    Friend WithEvents grpWarrantyCheck As System.Windows.Forms.GroupBox
    Friend WithEvents lblWarrantiedNY As System.Windows.Forms.Label
    Friend WithEvents lblWarrantied As System.Windows.Forms.Label
    Friend WithEvents lblSN As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtAdminStartNum As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtAdminCapcodeLen As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtAdminCapcodeRange As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtAdminCapcodePrefix As System.Windows.Forms.TextBox
    Friend WithEvents cmdAdminCreateCapcodeSheet As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAdminRefreshData As System.Windows.Forms.CheckBox
    Friend WithEvents dtpAdminLocChgDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdAdminLoadAMData As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAdminLoadFile As System.Windows.Forms.Button
    Friend WithEvents cmbAdminCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdAdminMapCustMod As System.Windows.Forms.Button
    Friend WithEvents cmdAdminEditDevice As System.Windows.Forms.Button
    Friend WithEvents cmdAdminCreateWO As System.Windows.Forms.Button
    Friend WithEvents lblBanner As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents tpgDivideTray As System.Windows.Forms.TabPage
    Friend WithEvents btnDT_DivideTray As System.Windows.Forms.Button
    Friend WithEvents btnDT_RemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnDT_RemoveOne As System.Windows.Forms.Button
    Friend WithEvents lblDT_NewTrayQty As System.Windows.Forms.Label
    Friend WithEvents lblDT_OriginalTrayQty As System.Windows.Forms.Label
    Friend WithEvents txtDT_MovedSN As System.Windows.Forms.TextBox
    Friend WithEvents lstDT_NewTraySNs As System.Windows.Forms.ListBox
    Friend WithEvents lstDT_OriginalTraySNs As System.Windows.Forms.ListBox
    Friend WithEvents txtDT_TrayID As System.Windows.Forms.TextBox
    Friend WithEvents btnDivideTray As System.Windows.Forms.Button
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnProdTracking As System.Windows.Forms.Button
    Friend WithEvents tpgProdTracking As System.Windows.Forms.TabPage
    Friend WithEvents btnDT_ClearAll As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btnShipmentSummary As System.Windows.Forms.Button
    Friend WithEvents btnSSummary_printSelected As System.Windows.Forms.Button
    Friend WithEvents btnSSummary_PrintAll As System.Windows.Forms.Button
    Friend WithEvents grdShipmentSummary As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tpgShipmentSummary As System.Windows.Forms.TabPage
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents dtpSSummary_pkslipCreationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSSummary_Go As System.Windows.Forms.Button
    Friend WithEvents btnSSummary_Clear As System.Windows.Forms.Button
    Friend WithEvents txtSSummary_PkSlipID As System.Windows.Forms.TextBox
    Friend WithEvents tabMsgProdTracker As System.Windows.Forms.TabControl
    Friend WithEvents tbpgMsgProdTracker As System.Windows.Forms.TabPage
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblMonthlyRange As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyRange As System.Windows.Forms.Label
    Friend WithEvents btnCopyNormalProdTracker As System.Windows.Forms.Button
    Friend WithEvents gridSpecialProdTracker As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents gridNormalProdTracker As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbpgSetWeeklyGoal As System.Windows.Forms.TabPage
    Friend WithEvents btnAddProdWlyGoal As System.Windows.Forms.Button
    Friend WithEvents txtWeek05 As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtWeek04 As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtWeek03 As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtWeek02 As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtWeek01 As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cboModel As System.Windows.Forms.ComboBox
    Friend WithEvents btnClearProdWlyGoal As System.Windows.Forms.Button
    Friend WithEvents gridEditProdWeeklyGoal As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cboFreq As System.Windows.Forms.ComboBox
    Friend WithEvents txtAWAP As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents chkSpecialProj As System.Windows.Forms.CheckBox
    Friend WithEvents btnSSummary_CopyToExcel As System.Windows.Forms.Button
    Friend WithEvents chkPrintSkyTellLetter As System.Windows.Forms.CheckBox
    Friend WithEvents dbgDailyWeeklyProd As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents chkRefreq As System.Windows.Forms.CheckBox
    Friend WithEvents cmbRecModel As C1.Win.C1List.C1Combo
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents chkRecPrintWorkSheet As System.Windows.Forms.CheckBox
    Friend WithEvents tpBuilShipPallet As System.Windows.Forms.TabPage
    Friend WithEvents btnBuildShipPallet As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents lblBSP_ScanQty As System.Windows.Forms.Label
    Friend WithEvents txtBSP_ShipID As System.Windows.Forms.TextBox
    Friend WithEvents lstBSP_ShipIDs As System.Windows.Forms.ListBox
    Friend WithEvents btnBSP_Clear As System.Windows.Forms.Button
    Friend WithEvents btnBSP_ClearAll As System.Windows.Forms.Button
    Friend WithEvents lblBSP_DevQty As System.Windows.Forms.Label
    Friend WithEvents btnBSP_CreatePallet As System.Windows.Forms.Button
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents btnBSP_RepintPalletLabel As System.Windows.Forms.Button
    Friend WithEvents btnMessageBoard As System.Windows.Forms.Button
    Friend WithEvents pnlRecFreqBaud As System.Windows.Forms.Panel
    Friend WithEvents cboRecFreq As C1.Win.C1List.C1Combo
    Friend WithEvents lblFreq As System.Windows.Forms.Label
    Friend WithEvents cboRecBaud As C1.Win.C1List.C1Combo
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtRecCapCode As System.Windows.Forms.TextBox
    Friend WithEvents lblModelActive As System.Windows.Forms.Label
	Friend WithEvents lblEquipTypeMismatch As System.Windows.Forms.Label
	Friend WithEvents btnDbrNerRemoval As System.Windows.Forms.Button


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessConsole))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnBuildShipPallet = New System.Windows.Forms.Button()
        Me.btnShipmentSummary = New System.Windows.Forms.Button()
        Me.btnProdTracking = New System.Windows.Forms.Button()
        Me.btnDivideTray = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.cmdAbacusData = New System.Windows.Forms.Button()
        Me.cmdLabeling = New System.Windows.Forms.Button()
        Me.cmdAdmin = New System.Windows.Forms.Button()
        Me.cmdReceive = New System.Windows.Forms.Button()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.chkRecCheckWarranty = New System.Windows.Forms.CheckBox()
        Me.btnRecDBRTray = New System.Windows.Forms.Button()
        Me.lblRecModelDesc = New System.Windows.Forms.Label()
        Me.lblRecWOHasFile = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtRecTrayMemo = New System.Windows.Forms.TextBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtRecTray_ID = New System.Windows.Forms.TextBox()
        Me.grdRecDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cmbRecCust = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblRecLoc = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblRecPO = New System.Windows.Forms.Label()
        Me.cmdRecReprintManifest = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnRecClearAll = New System.Windows.Forms.Button()
        Me.btnRecClear = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblRecScanCnt = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdRecTray = New System.Windows.Forms.Button()
        Me.txtRecDevSN = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblRecAddress = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRecWO = New System.Windows.Forms.TextBox()
        Me.lblRecDevRcvdCnt = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblModelType = New System.Windows.Forms.Label()
        Me.lstModelType = New System.Windows.Forms.ListBox()
        Me.chkPrintModelLetter = New System.Windows.Forms.CheckBox()
        Me.lbllblweekly = New System.Windows.Forms.Label()
        Me.lbllblDaily = New System.Windows.Forms.Label()
        Me.chkClearData = New System.Windows.Forms.CheckBox()
        Me.lbllblModel = New System.Windows.Forms.Label()
        Me.lbllblCust = New System.Windows.Forms.Label()
        Me.chklblND = New System.Windows.Forms.CheckBox()
        Me.cmdlblPrint = New System.Windows.Forms.Button()
        Me.txtlblCap = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtlblSN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmblblBaud = New System.Windows.Forms.ComboBox()
        Me.msklblFreq = New AxMSMask.AxMaskEdBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.chklblPlus = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.grdAbacusRecData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAbacusSearchCriteria = New System.Windows.Forms.TextBox()
        Me.cmbAbacusSearchType = New PSS.Gui.Controls.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grdAbacusData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpgAdmin = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdAdminLoadFile = New System.Windows.Forms.Button()
        Me.cmbAdminCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtAdminStartNum = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtAdminCapcodeLen = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtAdminCapcodeRange = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtAdminCapcodePrefix = New System.Windows.Forms.TextBox()
        Me.cmdAdminCreateCapcodeSheet = New System.Windows.Forms.Button()
        Me.btnAdminAMValidateData = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkAdminRefreshData = New System.Windows.Forms.CheckBox()
        Me.dtpAdminLocChgDate = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdAdminLoadAMData = New System.Windows.Forms.Button()
        Me.cmdAdminCreateWO = New System.Windows.Forms.Button()
        Me.grpWarrantyCheck = New System.Windows.Forms.GroupBox()
        Me.lblWarrantiedNY = New System.Windows.Forms.Label()
        Me.lblWarrantied = New System.Windows.Forms.Label()
        Me.lblSN = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.cmdAdminEditDevice = New System.Windows.Forms.Button()
        Me.cmdAdminMapCustMod = New System.Windows.Forms.Button()
        Me.tpgAbacusData = New System.Windows.Forms.TabPage()
        Me.tpgLabel = New System.Windows.Forms.TabPage()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.chkRefreq = New System.Windows.Forms.CheckBox()
        Me.dbgDailyWeeklyProd = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.chkPrintSkyTellLetter = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tpgProdTracking = New System.Windows.Forms.TabPage()
        Me.tabMsgProdTracker = New System.Windows.Forms.TabControl()
        Me.tbpgMsgProdTracker = New System.Windows.Forms.TabPage()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblMonthlyRange = New System.Windows.Forms.Label()
        Me.lblWeeklyRange = New System.Windows.Forms.Label()
        Me.btnCopyNormalProdTracker = New System.Windows.Forms.Button()
        Me.gridSpecialProdTracker = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.gridNormalProdTracker = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbpgSetWeeklyGoal = New System.Windows.Forms.TabPage()
        Me.chkSpecialProj = New System.Windows.Forms.CheckBox()
        Me.txtAWAP = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.cboFreq = New System.Windows.Forms.ComboBox()
        Me.btnAddProdWlyGoal = New System.Windows.Forms.Button()
        Me.txtWeek05 = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtWeek04 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtWeek03 = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtWeek02 = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtWeek01 = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cboModel = New System.Windows.Forms.ComboBox()
        Me.btnClearProdWlyGoal = New System.Windows.Forms.Button()
        Me.gridEditProdWeeklyGoal = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tpgDivideTray = New System.Windows.Forms.TabPage()
        Me.btnDT_ClearAll = New System.Windows.Forms.Button()
        Me.btnDT_DivideTray = New System.Windows.Forms.Button()
        Me.btnDT_RemoveAll = New System.Windows.Forms.Button()
        Me.btnDT_RemoveOne = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblDT_NewTrayQty = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblDT_OriginalTrayQty = New System.Windows.Forms.Label()
        Me.txtDT_MovedSN = New System.Windows.Forms.TextBox()
        Me.lstDT_NewTraySNs = New System.Windows.Forms.ListBox()
        Me.lstDT_OriginalTraySNs = New System.Windows.Forms.ListBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtDT_TrayID = New System.Windows.Forms.TextBox()
        Me.tpgRec = New System.Windows.Forms.TabPage()
        Me.btnDbrNerRemoval = New System.Windows.Forms.Button()
        Me.lblEquipTypeMismatch = New System.Windows.Forms.Label()
        Me.lblModelActive = New System.Windows.Forms.Label()
        Me.pnlRecFreqBaud = New System.Windows.Forms.Panel()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtRecCapCode = New System.Windows.Forms.TextBox()
        Me.cboRecBaud = New C1.Win.C1List.C1Combo()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cboRecFreq = New C1.Win.C1List.C1Combo()
        Me.lblFreq = New System.Windows.Forms.Label()
        Me.btnMessageBoard = New System.Windows.Forms.Button()
        Me.chkRecPrintWorkSheet = New System.Windows.Forms.CheckBox()
        Me.cmbRecModel = New C1.Win.C1List.C1Combo()
        Me.tpgShipmentSummary = New System.Windows.Forms.TabPage()
        Me.btnSSummary_CopyToExcel = New System.Windows.Forms.Button()
        Me.btnSSummary_Clear = New System.Windows.Forms.Button()
        Me.btnSSummary_Go = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.dtpSSummary_pkslipCreationDate = New System.Windows.Forms.DateTimePicker()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtSSummary_PkSlipID = New System.Windows.Forms.TextBox()
        Me.btnSSummary_printSelected = New System.Windows.Forms.Button()
        Me.btnSSummary_PrintAll = New System.Windows.Forms.Button()
        Me.grdShipmentSummary = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tpBuilShipPallet = New System.Windows.Forms.TabPage()
        Me.btnBSP_RepintPalletLabel = New System.Windows.Forms.Button()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txtBSP_ShipID = New System.Windows.Forms.TextBox()
        Me.lstBSP_ShipIDs = New System.Windows.Forms.ListBox()
        Me.btnBSP_CreatePallet = New System.Windows.Forms.Button()
        Me.lblBSP_ScanQty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBSP_DevQty = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.btnBSP_ClearAll = New System.Windows.Forms.Button()
        Me.btnBSP_Clear = New System.Windows.Forms.Button()
        Me.lblBanner = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.grdRecDevices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.msklblFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAbacusRecData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAbacusData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpgAdmin.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grpWarrantyCheck.SuspendLayout()
        Me.tpgAbacusData.SuspendLayout()
        Me.tpgLabel.SuspendLayout()
        CType(Me.dbgDailyWeeklyProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgProdTracking.SuspendLayout()
        Me.tabMsgProdTracker.SuspendLayout()
        Me.tbpgMsgProdTracker.SuspendLayout()
        CType(Me.gridSpecialProdTracker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridNormalProdTracker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpgSetWeeklyGoal.SuspendLayout()
        CType(Me.gridEditProdWeeklyGoal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgDivideTray.SuspendLayout()
        Me.tpgRec.SuspendLayout()
        Me.pnlRecFreqBaud.SuspendLayout()
        CType(Me.cboRecBaud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRecFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRecModel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgShipmentSummary.SuspendLayout()
        CType(Me.grdShipmentSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpBuilShipPallet.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Location = New System.Drawing.Point(-1, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(169, 84)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "MESSAGING OPERATIONS CONSOLE"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBuildShipPallet, Me.btnShipmentSummary, Me.btnProdTracking, Me.btnDivideTray, Me.btnReports, Me.cmdAbacusData, Me.cmdLabeling, Me.cmdAdmin, Me.cmdReceive, Me.lblMachine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel2.Location = New System.Drawing.Point(0, 84)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(168, 467)
        Me.Panel2.TabIndex = 2
        '
        'btnBuildShipPallet
        '
        Me.btnBuildShipPallet.BackColor = System.Drawing.Color.Black
        Me.btnBuildShipPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuildShipPallet.ForeColor = System.Drawing.Color.Lime
        Me.btnBuildShipPallet.Location = New System.Drawing.Point(8, 408)
        Me.btnBuildShipPallet.Name = "btnBuildShipPallet"
        Me.btnBuildShipPallet.Size = New System.Drawing.Size(143, 26)
        Me.btnBuildShipPallet.TabIndex = 98
        Me.btnBuildShipPallet.Tag = "False"
        Me.btnBuildShipPallet.Text = "BUILD SHIP PALLET"
        '
        'btnShipmentSummary
        '
        Me.btnShipmentSummary.BackColor = System.Drawing.Color.Black
        Me.btnShipmentSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShipmentSummary.ForeColor = System.Drawing.Color.Lime
        Me.btnShipmentSummary.Location = New System.Drawing.Point(9, 336)
        Me.btnShipmentSummary.Name = "btnShipmentSummary"
        Me.btnShipmentSummary.Size = New System.Drawing.Size(143, 28)
        Me.btnShipmentSummary.TabIndex = 97
        Me.btnShipmentSummary.Tag = "False"
        Me.btnShipmentSummary.Text = "SHIPMENT SUMMARY"
        '
        'btnProdTracking
        '
        Me.btnProdTracking.BackColor = System.Drawing.Color.Black
        Me.btnProdTracking.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProdTracking.ForeColor = System.Drawing.Color.Lime
        Me.btnProdTracking.Location = New System.Drawing.Point(9, 374)
        Me.btnProdTracking.Name = "btnProdTracking"
        Me.btnProdTracking.Size = New System.Drawing.Size(143, 26)
        Me.btnProdTracking.TabIndex = 96
        Me.btnProdTracking.Tag = "False"
        Me.btnProdTracking.Text = "PRODUCT TRACKING"
        '
        'btnDivideTray
        '
        Me.btnDivideTray.BackColor = System.Drawing.Color.Black
        Me.btnDivideTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDivideTray.ForeColor = System.Drawing.Color.Lime
        Me.btnDivideTray.Location = New System.Drawing.Point(11, 299)
        Me.btnDivideTray.Name = "btnDivideTray"
        Me.btnDivideTray.Size = New System.Drawing.Size(141, 27)
        Me.btnDivideTray.TabIndex = 95
        Me.btnDivideTray.Tag = "False"
        Me.btnDivideTray.Text = "TRAY DIVISION"
        '
        'btnReports
        '
        Me.btnReports.BackColor = System.Drawing.Color.Black
        Me.btnReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.Color.Lime
        Me.btnReports.Location = New System.Drawing.Point(11, 261)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Size = New System.Drawing.Size(141, 28)
        Me.btnReports.TabIndex = 94
        Me.btnReports.Tag = "False"
        Me.btnReports.Text = "REPORTS"
        '
        'cmdAbacusData
        '
        Me.cmdAbacusData.BackColor = System.Drawing.Color.Black
        Me.cmdAbacusData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAbacusData.ForeColor = System.Drawing.Color.Lime
        Me.cmdAbacusData.Location = New System.Drawing.Point(11, 224)
        Me.cmdAbacusData.Name = "cmdAbacusData"
        Me.cmdAbacusData.Size = New System.Drawing.Size(141, 27)
        Me.cmdAbacusData.TabIndex = 93
        Me.cmdAbacusData.Tag = "False"
        Me.cmdAbacusData.Text = "ABACUS DATA"
        '
        'cmdLabeling
        '
        Me.cmdLabeling.BackColor = System.Drawing.Color.Black
        Me.cmdLabeling.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLabeling.ForeColor = System.Drawing.Color.Lime
        Me.cmdLabeling.Location = New System.Drawing.Point(9, 186)
        Me.cmdLabeling.Name = "cmdLabeling"
        Me.cmdLabeling.Size = New System.Drawing.Size(143, 28)
        Me.cmdLabeling.TabIndex = 3
        Me.cmdLabeling.Tag = "False"
        Me.cmdLabeling.Text = "LABEL"
        '
        'cmdAdmin
        '
        Me.cmdAdmin.BackColor = System.Drawing.Color.Black
        Me.cmdAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdmin.ForeColor = System.Drawing.Color.Lime
        Me.cmdAdmin.Location = New System.Drawing.Point(11, 112)
        Me.cmdAdmin.Name = "cmdAdmin"
        Me.cmdAdmin.Size = New System.Drawing.Size(141, 27)
        Me.cmdAdmin.TabIndex = 1
        Me.cmdAdmin.Tag = "False"
        Me.cmdAdmin.Text = "ADMIN"
        '
        'cmdReceive
        '
        Me.cmdReceive.BackColor = System.Drawing.Color.Black
        Me.cmdReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReceive.ForeColor = System.Drawing.Color.Lime
        Me.cmdReceive.Location = New System.Drawing.Point(11, 150)
        Me.cmdReceive.Name = "cmdReceive"
        Me.cmdReceive.Size = New System.Drawing.Size(141, 26)
        Me.cmdReceive.TabIndex = 2
        Me.cmdReceive.Tag = "False"
        Me.cmdReceive.Text = "RECEIVE"
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Black
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(7, 9)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(153, 18)
        Me.lblMachine.TabIndex = 92
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Black
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(7, 48)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(153, 18)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Black
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(7, 68)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(153, 18)
        Me.lblWorkDate.TabIndex = 84
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Black
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(7, 28)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(153, 18)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkRecCheckWarranty
        '
        Me.chkRecCheckWarranty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecCheckWarranty.ForeColor = System.Drawing.Color.Red
        Me.chkRecCheckWarranty.Location = New System.Drawing.Point(8, 160)
        Me.chkRecCheckWarranty.Name = "chkRecCheckWarranty"
        Me.chkRecCheckWarranty.Size = New System.Drawing.Size(119, 18)
        Me.chkRecCheckWarranty.TabIndex = 7
        Me.chkRecCheckWarranty.TabStop = False
        Me.chkRecCheckWarranty.Text = "Check Warranty"
        '
        'btnRecDBRTray
        '
        Me.btnRecDBRTray.BackColor = System.Drawing.Color.Gold
        Me.btnRecDBRTray.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecDBRTray.ForeColor = System.Drawing.Color.Black
        Me.btnRecDBRTray.Location = New System.Drawing.Point(384, 480)
        Me.btnRecDBRTray.Name = "btnRecDBRTray"
        Me.btnRecDBRTray.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRecDBRTray.Size = New System.Drawing.Size(176, 40)
        Me.btnRecDBRTray.TabIndex = 8
        Me.btnRecDBRTray.Text = "RECEIVE DBR TRAY"
        '
        'lblRecModelDesc
        '
        Me.lblRecModelDesc.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecModelDesc.ForeColor = System.Drawing.Color.Red
        Me.lblRecModelDesc.Location = New System.Drawing.Point(500, 152)
        Me.lblRecModelDesc.Name = "lblRecModelDesc"
        Me.lblRecModelDesc.Size = New System.Drawing.Size(304, 29)
        Me.lblRecModelDesc.TabIndex = 141
        Me.lblRecModelDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblRecWOHasFile
        '
        Me.lblRecWOHasFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecWOHasFile.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecWOHasFile.ForeColor = System.Drawing.Color.Black
        Me.lblRecWOHasFile.Location = New System.Drawing.Point(639, 84)
        Me.lblRecWOHasFile.Name = "lblRecWOHasFile"
        Me.lblRecWOHasFile.Size = New System.Drawing.Size(42, 19)
        Me.lblRecWOHasFile.TabIndex = 139
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(471, 84)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(160, 19)
        Me.Label20.TabIndex = 140
        Me.Label20.Text = "WO Came With Data File?"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecTrayMemo
        '
        Me.txtRecTrayMemo.Location = New System.Drawing.Point(120, 80)
        Me.txtRecTrayMemo.Name = "txtRecTrayMemo"
        Me.txtRecTrayMemo.Size = New System.Drawing.Size(256, 20)
        Me.txtRecTrayMemo.TabIndex = 4
        Me.txtRecTrayMemo.Text = ""
        Me.txtRecTrayMemo.WordWrap = False
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.ForeColor = System.Drawing.Color.White
        Me.cmdClear.Location = New System.Drawing.Point(688, 432)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClear.Size = New System.Drawing.Size(112, 40)
        Me.cmdClear.TabIndex = 9
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "CLEAR"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(320, 141)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 18)
        Me.Label17.TabIndex = 136
        Me.Label17.Text = "Tray ID"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtRecTray_ID
        '
        Me.txtRecTray_ID.BackColor = System.Drawing.Color.White
        Me.txtRecTray_ID.Location = New System.Drawing.Point(320, 160)
        Me.txtRecTray_ID.MaxLength = 15
        Me.txtRecTray_ID.Name = "txtRecTray_ID"
        Me.txtRecTray_ID.Size = New System.Drawing.Size(80, 20)
        Me.txtRecTray_ID.TabIndex = 5
        Me.txtRecTray_ID.TabStop = False
        Me.txtRecTray_ID.Text = ""
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
        Me.grdRecDevices.CaptionHeight = 19
        Me.grdRecDevices.FilterBar = True
        Me.grdRecDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRecDevices.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdRecDevices.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdRecDevices.Location = New System.Drawing.Point(9, 192)
        Me.grdRecDevices.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdRecDevices.Name = "grdRecDevices"
        Me.grdRecDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdRecDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdRecDevices.PreviewInfo.ZoomFactor = 75
        Me.grdRecDevices.RowHeight = 20
        Me.grdRecDevices.Size = New System.Drawing.Size(671, 280)
        Me.grdRecDevices.TabIndex = 133
        Me.grdRecDevices.TabStop = False
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
        "Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" AllowColMove=""Fals" & _
        "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
        "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar" & _
        "=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=" & _
        """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>276</Height><Capt" & _
        "ionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5""" & _
        " /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBa" & _
        "r"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=" & _
        """Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRo" & _
        "wStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""" & _
        "Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent" & _
        "=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" />" & _
        "<Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 667, 276</ClientRect><Bor" & _
        "derSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Mer" & _
        "geView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norma" & _
        "l"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" " & _
        "me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me" & _
        "=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hi" & _
        "ghlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""O" & _
        "ddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me" & _
        "=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1<" & _
        "/vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>1" & _
        "7</DefaultRecSelWidth><ClientArea>0, 0, 667, 276</ClientArea><PrintPageHeaderSty" & _
        "le parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blo" & _
        "b>"
        '
        'cmbRecCust
        '
        Me.cmbRecCust.AutoComplete = True
        Me.cmbRecCust.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRecCust.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecCust.ForeColor = System.Drawing.Color.Black
        Me.cmbRecCust.Location = New System.Drawing.Point(120, 5)
        Me.cmbRecCust.Name = "cmbRecCust"
        Me.cmbRecCust.Size = New System.Drawing.Size(256, 21)
        Me.cmbRecCust.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(24, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 19)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Customer:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(376, 28)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 18)
        Me.Label26.TabIndex = 129
        Me.Label26.Text = "Address:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecLoc
        '
        Me.lblRecLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecLoc.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecLoc.ForeColor = System.Drawing.Color.Black
        Me.lblRecLoc.Location = New System.Drawing.Point(440, 9)
        Me.lblRecLoc.Name = "lblRecLoc"
        Me.lblRecLoc.Size = New System.Drawing.Size(240, 19)
        Me.lblRecLoc.TabIndex = 128
        Me.lblRecLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(376, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 19)
        Me.Label25.TabIndex = 127
        Me.Label25.Text = "Location:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecPO
        '
        Me.lblRecPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecPO.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecPO.ForeColor = System.Drawing.Color.Black
        Me.lblRecPO.Location = New System.Drawing.Point(440, 65)
        Me.lblRecPO.Name = "lblRecPO"
        Me.lblRecPO.Size = New System.Drawing.Size(240, 19)
        Me.lblRecPO.TabIndex = 121
        Me.lblRecPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdRecReprintManifest
        '
        Me.cmdRecReprintManifest.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdRecReprintManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecReprintManifest.ForeColor = System.Drawing.Color.White
        Me.cmdRecReprintManifest.Location = New System.Drawing.Point(688, 384)
        Me.cmdRecReprintManifest.Name = "cmdRecReprintManifest"
        Me.cmdRecReprintManifest.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRecReprintManifest.Size = New System.Drawing.Size(112, 39)
        Me.cmdRecReprintManifest.TabIndex = 8
        Me.cmdRecReprintManifest.TabStop = False
        Me.cmdRecReprintManifest.Text = "REPRINT MANIFEST"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(400, 65)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(32, 19)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "PO:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRecClearAll
        '
        Me.btnRecClearAll.BackColor = System.Drawing.Color.Red
        Me.btnRecClearAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecClearAll.ForeColor = System.Drawing.Color.White
        Me.btnRecClearAll.Location = New System.Drawing.Point(688, 288)
        Me.btnRecClearAll.Name = "btnRecClearAll"
        Me.btnRecClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRecClearAll.Size = New System.Drawing.Size(112, 37)
        Me.btnRecClearAll.TabIndex = 11
        Me.btnRecClearAll.Text = "REMOVE ALL SNs"
        '
        'btnRecClear
        '
        Me.btnRecClear.BackColor = System.Drawing.Color.Red
        Me.btnRecClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecClear.ForeColor = System.Drawing.Color.White
        Me.btnRecClear.Location = New System.Drawing.Point(688, 240)
        Me.btnRecClear.Name = "btnRecClear"
        Me.btnRecClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRecClear.Size = New System.Drawing.Size(112, 40)
        Me.btnRecClear.TabIndex = 10
        Me.btnRecClear.Text = "REMOVE ONE SN"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(128, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 16)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "SN"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecScanCnt
        '
        Me.lblRecScanCnt.BackColor = System.Drawing.Color.Black
        Me.lblRecScanCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRecScanCnt.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecScanCnt.ForeColor = System.Drawing.Color.Lime
        Me.lblRecScanCnt.Location = New System.Drawing.Point(696, 112)
        Me.lblRecScanCnt.Name = "lblRecScanCnt"
        Me.lblRecScanCnt.Size = New System.Drawing.Size(104, 32)
        Me.lblRecScanCnt.TabIndex = 97
        Me.lblRecScanCnt.Text = "0"
        Me.lblRecScanCnt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(696, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 37)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "DEVICES IN TRAY"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdRecTray
        '
        Me.cmdRecTray.BackColor = System.Drawing.Color.Green
        Me.cmdRecTray.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRecTray.ForeColor = System.Drawing.Color.White
        Me.cmdRecTray.Location = New System.Drawing.Point(200, 480)
        Me.cmdRecTray.Name = "cmdRecTray"
        Me.cmdRecTray.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRecTray.Size = New System.Drawing.Size(160, 40)
        Me.cmdRecTray.TabIndex = 7
        Me.cmdRecTray.Text = "RECEIVE TRAY"
        '
        'txtRecDevSN
        '
        Me.txtRecDevSN.BackColor = System.Drawing.Color.Yellow
        Me.txtRecDevSN.Location = New System.Drawing.Point(136, 160)
        Me.txtRecDevSN.MaxLength = 15
        Me.txtRecDevSN.Name = "txtRecDevSN"
        Me.txtRecDevSN.Size = New System.Drawing.Size(167, 20)
        Me.txtRecDevSN.TabIndex = 6
        Me.txtRecDevSN.Text = ""
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(24, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Tray Memo:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(0, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 18)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Work Order (WO):"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRecAddress
        '
        Me.lblRecAddress.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblRecAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecAddress.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecAddress.Location = New System.Drawing.Point(440, 28)
        Me.lblRecAddress.Name = "lblRecAddress"
        Me.lblRecAddress.Size = New System.Drawing.Size(240, 37)
        Me.lblRecAddress.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(64, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Model:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecWO
        '
        Me.txtRecWO.Location = New System.Drawing.Point(120, 30)
        Me.txtRecWO.MaxLength = 30
        Me.txtRecWO.Name = "txtRecWO"
        Me.txtRecWO.Size = New System.Drawing.Size(256, 20)
        Me.txtRecWO.TabIndex = 2
        Me.txtRecWO.Text = ""
        '
        'lblRecDevRcvdCnt
        '
        Me.lblRecDevRcvdCnt.BackColor = System.Drawing.Color.Black
        Me.lblRecDevRcvdCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRecDevRcvdCnt.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecDevRcvdCnt.ForeColor = System.Drawing.Color.Lime
        Me.lblRecDevRcvdCnt.Location = New System.Drawing.Point(696, 46)
        Me.lblRecDevRcvdCnt.Name = "lblRecDevRcvdCnt"
        Me.lblRecDevRcvdCnt.Size = New System.Drawing.Size(106, 26)
        Me.lblRecDevRcvdCnt.TabIndex = 114
        Me.lblRecDevRcvdCnt.Text = "0"
        Me.lblRecDevRcvdCnt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Black
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Lime
        Me.Label19.Location = New System.Drawing.Point(696, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 37)
        Me.Label19.TabIndex = 113
        Me.Label19.Text = "DEVICES RCVD FOR WO"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblModelType
        '
        Me.lblModelType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelType.Location = New System.Drawing.Point(121, 295)
        Me.lblModelType.Name = "lblModelType"
        Me.lblModelType.Size = New System.Drawing.Size(84, 28)
        Me.lblModelType.TabIndex = 106
        Me.lblModelType.Text = "Model Type:"
        Me.lblModelType.Visible = False
        '
        'lstModelType
        '
        Me.lstModelType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstModelType.Items.AddRange(New Object() {"Motorola", "Unication"})
        Me.lstModelType.Location = New System.Drawing.Point(216, 295)
        Me.lstModelType.Name = "lstModelType"
        Me.lstModelType.Size = New System.Drawing.Size(93, 17)
        Me.lstModelType.TabIndex = 105
        Me.lstModelType.Visible = False
        '
        'chkPrintModelLetter
        '
        Me.chkPrintModelLetter.BackColor = System.Drawing.Color.Transparent
        Me.chkPrintModelLetter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintModelLetter.ForeColor = System.Drawing.Color.Black
        Me.chkPrintModelLetter.Location = New System.Drawing.Point(121, 327)
        Me.chkPrintModelLetter.Name = "chkPrintModelLetter"
        Me.chkPrintModelLetter.Size = New System.Drawing.Size(188, 28)
        Me.chkPrintModelLetter.TabIndex = 104
        Me.chkPrintModelLetter.Text = "Print Model Letter"
        Me.chkPrintModelLetter.Visible = False
        '
        'lbllblweekly
        '
        Me.lbllblweekly.BackColor = System.Drawing.Color.Black
        Me.lbllblweekly.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbllblweekly.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblweekly.ForeColor = System.Drawing.Color.Lime
        Me.lbllblweekly.Location = New System.Drawing.Point(449, 9)
        Me.lbllblweekly.Name = "lbllblweekly"
        Me.lbllblweekly.Size = New System.Drawing.Size(94, 56)
        Me.lbllblweekly.TabIndex = 101
        Me.lbllblweekly.Text = "0"
        Me.lbllblweekly.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lbllblDaily
        '
        Me.lbllblDaily.BackColor = System.Drawing.Color.Black
        Me.lbllblDaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbllblDaily.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblDaily.ForeColor = System.Drawing.Color.Lime
        Me.lbllblDaily.Location = New System.Drawing.Point(346, 9)
        Me.lbllblDaily.Name = "lbllblDaily"
        Me.lbllblDaily.Size = New System.Drawing.Size(93, 56)
        Me.lbllblDaily.TabIndex = 98
        Me.lbllblDaily.Text = "0"
        Me.lbllblDaily.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'chkClearData
        '
        Me.chkClearData.BackColor = System.Drawing.Color.Transparent
        Me.chkClearData.Checked = True
        Me.chkClearData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClearData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearData.ForeColor = System.Drawing.Color.Black
        Me.chkClearData.Location = New System.Drawing.Point(121, 243)
        Me.chkClearData.Name = "chkClearData"
        Me.chkClearData.Size = New System.Drawing.Size(122, 28)
        Me.chkClearData.TabIndex = 9
        Me.chkClearData.Text = "Clear Data"
        Me.chkClearData.Visible = False
        '
        'lbllblModel
        '
        Me.lbllblModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbllblModel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblModel.ForeColor = System.Drawing.Color.Black
        Me.lbllblModel.Location = New System.Drawing.Point(121, 131)
        Me.lbllblModel.Name = "lbllblModel"
        Me.lbllblModel.Size = New System.Drawing.Size(188, 23)
        Me.lbllblModel.TabIndex = 18
        Me.lbllblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbllblCust
        '
        Me.lbllblCust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbllblCust.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblCust.ForeColor = System.Drawing.Color.Black
        Me.lbllblCust.Location = New System.Drawing.Point(121, 159)
        Me.lbllblCust.Name = "lbllblCust"
        Me.lbllblCust.Size = New System.Drawing.Size(188, 23)
        Me.lbllblCust.TabIndex = 17
        Me.lbllblCust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chklblND
        '
        Me.chklblND.BackColor = System.Drawing.Color.Transparent
        Me.chklblND.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklblND.ForeColor = System.Drawing.Color.Black
        Me.chklblND.Location = New System.Drawing.Point(121, 215)
        Me.chklblND.Name = "chklblND"
        Me.chklblND.Size = New System.Drawing.Size(216, 28)
        Me.chklblND.TabIndex = 8
        Me.chklblND.Text = "ND (AE Advisor Elite only)"
        Me.chklblND.Visible = False
        '
        'cmdlblPrint
        '
        Me.cmdlblPrint.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdlblPrint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlblPrint.ForeColor = System.Drawing.Color.White
        Me.cmdlblPrint.Location = New System.Drawing.Point(121, 464)
        Me.cmdlblPrint.Name = "cmdlblPrint"
        Me.cmdlblPrint.Size = New System.Drawing.Size(188, 38)
        Me.cmdlblPrint.TabIndex = 6
        Me.cmdlblPrint.Text = "PRINT (F12)"
        '
        'txtlblCap
        '
        Me.txtlblCap.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlblCap.Location = New System.Drawing.Point(121, 37)
        Me.txtlblCap.Name = "txtlblCap"
        Me.txtlblCap.Size = New System.Drawing.Size(188, 20)
        Me.txtlblCap.TabIndex = 3
        Me.txtlblCap.Text = ""
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(47, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 18)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Model:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtlblSN
        '
        Me.txtlblSN.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.txtlblSN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlblSN.Location = New System.Drawing.Point(121, 9)
        Me.txtlblSN.Name = "txtlblSN"
        Me.txtlblSN.Size = New System.Drawing.Size(188, 20)
        Me.txtlblSN.TabIndex = 2
        Me.txtlblSN.Text = ""
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(18, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 22)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Baud Rate:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(18, 66)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(94, 23)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Frequency:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(28, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 18)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Cap Code:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmblblBaud
        '
        Me.cmblblBaud.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmblblBaud.Location = New System.Drawing.Point(121, 94)
        Me.cmblblBaud.Name = "cmblblBaud"
        Me.cmblblBaud.Size = New System.Drawing.Size(188, 22)
        Me.cmblblBaud.TabIndex = 5
        '
        'msklblFreq
        '
        Me.msklblFreq.ContainingControl = Me
        Me.msklblFreq.Location = New System.Drawing.Point(121, 65)
        Me.msklblFreq.Name = "msklblFreq"
        Me.msklblFreq.OcxState = CType(resources.GetObject("msklblFreq.OcxState"), System.Windows.Forms.AxHost.State)
        Me.msklblFreq.Size = New System.Drawing.Size(188, 24)
        Me.msklblFreq.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(28, 154)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 27)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Customer:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(0, 9)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(112, 20)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "Serial Number:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'chklblPlus
        '
        Me.chklblPlus.BackColor = System.Drawing.Color.Transparent
        Me.chklblPlus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklblPlus.ForeColor = System.Drawing.Color.Black
        Me.chklblPlus.Location = New System.Drawing.Point(121, 186)
        Me.chklblPlus.Name = "chklblPlus"
        Me.chklblPlus.Size = New System.Drawing.Size(188, 29)
        Me.chklblPlus.TabIndex = 7
        Me.chklblPlus.Text = "Plus (ST 800 only)"
        Me.chklblPlus.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.AddExtension = False
        Me.OpenFileDialog1.CheckFileExists = False
        Me.OpenFileDialog1.DefaultExt = "xls"
        Me.OpenFileDialog1.Filter = "Excel files (*.xls)|*.xls|CSV (Comma Delimited) *.CSV|*.csv"
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(9, 309)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(169, 18)
        Me.Label28.TabIndex = 140
        Me.Label28.Text = "Receive Data"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdAbacusRecData
        '
        Me.grdAbacusRecData.AllowColMove = False
        Me.grdAbacusRecData.AllowColSelect = False
        Me.grdAbacusRecData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdAbacusRecData.AllowUpdate = False
        Me.grdAbacusRecData.AllowUpdateOnBlur = False
        Me.grdAbacusRecData.AlternatingRows = True
        Me.grdAbacusRecData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdAbacusRecData.BackColor = System.Drawing.Color.SteelBlue
        Me.grdAbacusRecData.CaptionHeight = 19
        Me.grdAbacusRecData.FilterBar = True
        Me.grdAbacusRecData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAbacusRecData.ForeColor = System.Drawing.Color.White
        Me.grdAbacusRecData.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdAbacusRecData.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdAbacusRecData.Location = New System.Drawing.Point(9, 328)
        Me.grdAbacusRecData.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdAbacusRecData.Name = "grdAbacusRecData"
        Me.grdAbacusRecData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAbacusRecData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAbacusRecData.PreviewInfo.ZoomFactor = 75
        Me.grdAbacusRecData.RowHeight = 20
        Me.grdAbacusRecData.Size = New System.Drawing.Size(775, 177)
        Me.grdAbacusRecData.TabIndex = 139
        Me.grdAbacusRecData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt;ForeColor:White;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;B" & _
        "ackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:Ina" & _
        "ctiveCaption;}FilterBar{BackColor:White;}Footer{}Caption{AlignHorz:Center;}Style" & _
        "9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Center;}" & _
        "HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{ForeCo" & _
        "lor:White;BackColor:CadetBlue;}RecordSelector{AlignImage:Center;BackColor:Contro" & _
        "l;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;Alig" & _
        "nHorz:Center;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;A" & _
        "lignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Styl" & _
        "e1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" Allow" & _
        "ColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" Alternating" & _
        "RowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""" & _
        "17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" De" & _
        "fRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>173<" & _
        "/Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor" & _
        """ me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle par" & _
        "ent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Group" & _
        "Style parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /" & _
        "><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""I" & _
        "nactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelecto" & _
        "rStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" m" & _
        "e=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 771, 173</Cl" & _
        "ientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1T" & _
        "rueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style " & _
        "parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style pare" & _
        "nt=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style paren" & _
        "t=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""N" & _
        "ormal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""" & _
        "Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style paren" & _
        "t=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Default" & _
        "RecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 771, 173</ClientArea><Print" & _
        "PageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Sty" & _
        "le15"" /></Blob>"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(271, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(168, 19)
        Me.Label18.TabIndex = 138
        Me.Label18.Text = "Search Criteria:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAbacusSearchCriteria
        '
        Me.txtAbacusSearchCriteria.BackColor = System.Drawing.Color.Yellow
        Me.txtAbacusSearchCriteria.Location = New System.Drawing.Point(271, 28)
        Me.txtAbacusSearchCriteria.Name = "txtAbacusSearchCriteria"
        Me.txtAbacusSearchCriteria.Size = New System.Drawing.Size(206, 20)
        Me.txtAbacusSearchCriteria.TabIndex = 137
        Me.txtAbacusSearchCriteria.Text = ""
        '
        'cmbAbacusSearchType
        '
        Me.cmbAbacusSearchType.AutoComplete = True
        Me.cmbAbacusSearchType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAbacusSearchType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAbacusSearchType.ForeColor = System.Drawing.Color.Black
        Me.cmbAbacusSearchType.Items.AddRange(New Object() {"-- Select --", "Serial Number", "Tray ID", "Ship ID"})
        Me.cmbAbacusSearchType.Location = New System.Drawing.Point(9, 28)
        Me.cmbAbacusSearchType.Name = "cmbAbacusSearchType"
        Me.cmbAbacusSearchType.Size = New System.Drawing.Size(207, 21)
        Me.cmbAbacusSearchType.TabIndex = 136
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(9, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(169, 19)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = "Search Type:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdAbacusData
        '
        Me.grdAbacusData.AllowColMove = False
        Me.grdAbacusData.AllowColSelect = False
        Me.grdAbacusData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdAbacusData.AllowUpdate = False
        Me.grdAbacusData.AllowUpdateOnBlur = False
        Me.grdAbacusData.AlternatingRows = True
        Me.grdAbacusData.CaptionHeight = 19
        Me.grdAbacusData.FilterBar = True
        Me.grdAbacusData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAbacusData.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdAbacusData.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.grdAbacusData.Location = New System.Drawing.Point(9, 56)
        Me.grdAbacusData.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdAbacusData.Name = "grdAbacusData"
        Me.grdAbacusData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAbacusData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAbacusData.PreviewInfo.ZoomFactor = 75
        Me.grdAbacusData.RowHeight = 20
        Me.grdAbacusData.Size = New System.Drawing.Size(839, 253)
        Me.grdAbacusData.TabIndex = 134
        Me.grdAbacusData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt;ForeColor:Black;BackColor:Transparent;}Selected{ForeColor:HighlightText" & _
        ";BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:I" & _
        "nactiveCaption;}FilterBar{BackColor:White;}Footer{}Caption{AlignHorz:Center;}Sty" & _
        "le1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:Control" & _
        ";}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{Fore" & _
        "Color:Black;BackColor:Transparent;}RecordSelector{AlignImage:Center;BackColor:Co" & _
        "ntrol;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;" & _
        "AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
        "t;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}" & _
        "Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" A" & _
        "llowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" Alterna" & _
        "tingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeig" & _
        "ht=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17" & _
        """ DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>" & _
        "249</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Ed" & _
        "itor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle" & _
        " parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><G" & _
        "roupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style" & _
        "2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle paren" & _
        "t=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSel" & _
        "ectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selecte" & _
        "d"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 835, 249" & _
        "</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win" & _
        ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
        "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
        "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
        "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
        "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
        "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
        "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
        "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 835, 249</ClientArea><P" & _
        "rintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=" & _
        """Style15"" /></Blob>"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgAdmin, Me.tpgAbacusData, Me.tpgLabel, Me.tpgProdTracking, Me.tpgDivideTray, Me.tpgRec, Me.tpgShipmentSummary, Me.tpBuilShipPallet})
        Me.TabControl1.Location = New System.Drawing.Point(168, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(824, 560)
        Me.TabControl1.TabIndex = 101
        Me.TabControl1.Visible = False
        '
        'tpgAdmin
        '
        Me.tpgAdmin.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgAdmin.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.GroupBox4, Me.btnAdminAMValidateData, Me.GroupBox3, Me.cmdAdminCreateWO, Me.grpWarrantyCheck, Me.cmdAdminEditDevice, Me.cmdAdminMapCustMod})
        Me.tpgAdmin.Location = New System.Drawing.Point(4, 25)
        Me.tpgAdmin.Name = "tpgAdmin"
        Me.tpgAdmin.Size = New System.Drawing.Size(816, 531)
        Me.tpgAdmin.TabIndex = 0
        Me.tpgAdmin.Text = "ADMIN"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdAdminLoadFile, Me.cmbAdminCustomer, Me.Label1})
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Load WO File"
        '
        'cmdAdminLoadFile
        '
        Me.cmdAdminLoadFile.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAdminLoadFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdminLoadFile.ForeColor = System.Drawing.Color.White
        Me.cmdAdminLoadFile.Location = New System.Drawing.Point(9, 75)
        Me.cmdAdminLoadFile.Name = "cmdAdminLoadFile"
        Me.cmdAdminLoadFile.Size = New System.Drawing.Size(234, 28)
        Me.cmdAdminLoadFile.TabIndex = 3
        Me.cmdAdminLoadFile.Text = "Load File"
        '
        'cmbAdminCustomer
        '
        Me.cmbAdminCustomer.AutoComplete = True
        Me.cmbAdminCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAdminCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAdminCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbAdminCustomer.ItemHeight = 13
        Me.cmbAdminCustomer.Location = New System.Drawing.Point(12, 37)
        Me.cmbAdminCustomer.Name = "cmbAdminCustomer"
        Me.cmbAdminCustomer.Size = New System.Drawing.Size(229, 21)
        Me.cmbAdminCustomer.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label27, Me.txtAdminStartNum, Me.Label24, Me.txtAdminCapcodeLen, Me.Label23, Me.txtAdminCapcodeRange, Me.Label21, Me.txtAdminCapcodePrefix, Me.cmdAdminCreateCapcodeSheet})
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Red
        Me.GroupBox4.Location = New System.Drawing.Point(280, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(356, 118)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Capcode Sheet"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(243, 19)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(103, 18)
        Me.Label27.TabIndex = 11
        Me.Label27.Text = "Start Number:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdminStartNum
        '
        Me.txtAdminStartNum.Location = New System.Drawing.Point(243, 37)
        Me.txtAdminStartNum.MaxLength = 9
        Me.txtAdminStartNum.Name = "txtAdminStartNum"
        Me.txtAdminStartNum.Size = New System.Drawing.Size(94, 21)
        Me.txtAdminStartNum.TabIndex = 4
        Me.txtAdminStartNum.Text = ""
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(84, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 18)
        Me.Label24.TabIndex = 9
        Me.Label24.Text = "Length:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdminCapcodeLen
        '
        Me.txtAdminCapcodeLen.Location = New System.Drawing.Point(84, 37)
        Me.txtAdminCapcodeLen.MaxLength = 1
        Me.txtAdminCapcodeLen.Name = "txtAdminCapcodeLen"
        Me.txtAdminCapcodeLen.Size = New System.Drawing.Size(57, 21)
        Me.txtAdminCapcodeLen.TabIndex = 2
        Me.txtAdminCapcodeLen.Text = ""
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(159, 19)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 18)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "Range:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdminCapcodeRange
        '
        Me.txtAdminCapcodeRange.Location = New System.Drawing.Point(159, 37)
        Me.txtAdminCapcodeRange.MaxLength = 5
        Me.txtAdminCapcodeRange.Name = "txtAdminCapcodeRange"
        Me.txtAdminCapcodeRange.Size = New System.Drawing.Size(66, 21)
        Me.txtAdminCapcodeRange.TabIndex = 3
        Me.txtAdminCapcodeRange.Text = ""
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(18, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(57, 18)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Prefix:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdminCapcodePrefix
        '
        Me.txtAdminCapcodePrefix.Location = New System.Drawing.Point(18, 37)
        Me.txtAdminCapcodePrefix.MaxLength = 1
        Me.txtAdminCapcodePrefix.Name = "txtAdminCapcodePrefix"
        Me.txtAdminCapcodePrefix.Size = New System.Drawing.Size(48, 21)
        Me.txtAdminCapcodePrefix.TabIndex = 1
        Me.txtAdminCapcodePrefix.Text = ""
        '
        'cmdAdminCreateCapcodeSheet
        '
        Me.cmdAdminCreateCapcodeSheet.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAdminCreateCapcodeSheet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdminCreateCapcodeSheet.ForeColor = System.Drawing.Color.White
        Me.cmdAdminCreateCapcodeSheet.Location = New System.Drawing.Point(75, 75)
        Me.cmdAdminCreateCapcodeSheet.Name = "cmdAdminCreateCapcodeSheet"
        Me.cmdAdminCreateCapcodeSheet.Size = New System.Drawing.Size(196, 28)
        Me.cmdAdminCreateCapcodeSheet.TabIndex = 3
        Me.cmdAdminCreateCapcodeSheet.Text = "Create Capcode Sheet"
        '
        'btnAdminAMValidateData
        '
        Me.btnAdminAMValidateData.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAdminAMValidateData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdminAMValidateData.ForeColor = System.Drawing.Color.White
        Me.btnAdminAMValidateData.Location = New System.Drawing.Point(18, 318)
        Me.btnAdminAMValidateData.Name = "btnAdminAMValidateData"
        Me.btnAdminAMValidateData.Size = New System.Drawing.Size(234, 37)
        Me.btnAdminAMValidateData.TabIndex = 13
        Me.btnAdminAMValidateData.Text = "Data Verification"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAdminRefreshData, Me.dtpAdminLocChgDate, Me.Label12, Me.cmdAdminLoadAMData})
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Red
        Me.GroupBox3.Location = New System.Drawing.Point(280, 140)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(356, 131)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Load Abacus Data to be Receive"
        '
        'chkAdminRefreshData
        '
        Me.chkAdminRefreshData.ForeColor = System.Drawing.Color.Blue
        Me.chkAdminRefreshData.Location = New System.Drawing.Point(216, 44)
        Me.chkAdminRefreshData.Name = "chkAdminRefreshData"
        Me.chkAdminRefreshData.Size = New System.Drawing.Size(130, 28)
        Me.chkAdminRefreshData.TabIndex = 66
        Me.chkAdminRefreshData.Text = "Refresh Data"
        '
        'dtpAdminLocChgDate
        '
        Me.dtpAdminLocChgDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpAdminLocChgDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAdminLocChgDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdminLocChgDate.Location = New System.Drawing.Point(18, 41)
        Me.dtpAdminLocChgDate.Name = "dtpAdminLocChgDate"
        Me.dtpAdminLocChgDate.Size = New System.Drawing.Size(160, 21)
        Me.dtpAdminLocChgDate.TabIndex = 64
        Me.dtpAdminLocChgDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(18, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(203, 19)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Load Data by:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAdminLoadAMData
        '
        Me.cmdAdminLoadAMData.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAdminLoadAMData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdminLoadAMData.ForeColor = System.Drawing.Color.White
        Me.cmdAdminLoadAMData.Location = New System.Drawing.Point(18, 84)
        Me.cmdAdminLoadAMData.Name = "cmdAdminLoadAMData"
        Me.cmdAdminLoadAMData.Size = New System.Drawing.Size(123, 28)
        Me.cmdAdminLoadAMData.TabIndex = 3
        Me.cmdAdminLoadAMData.Text = "Load Data"
        '
        'cmdAdminCreateWO
        '
        Me.cmdAdminCreateWO.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAdminCreateWO.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdminCreateWO.ForeColor = System.Drawing.Color.White
        Me.cmdAdminCreateWO.Location = New System.Drawing.Point(18, 140)
        Me.cmdAdminCreateWO.Name = "cmdAdminCreateWO"
        Me.cmdAdminCreateWO.Size = New System.Drawing.Size(234, 38)
        Me.cmdAdminCreateWO.TabIndex = 6
        Me.cmdAdminCreateWO.Text = "Create Work Order"
        '
        'grpWarrantyCheck
        '
        Me.grpWarrantyCheck.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpWarrantyCheck.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWarrantiedNY, Me.lblWarrantied, Me.lblSN, Me.txtSN})
        Me.grpWarrantyCheck.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpWarrantyCheck.ForeColor = System.Drawing.Color.Red
        Me.grpWarrantyCheck.Location = New System.Drawing.Point(280, 284)
        Me.grpWarrantyCheck.Name = "grpWarrantyCheck"
        Me.grpWarrantyCheck.Size = New System.Drawing.Size(356, 131)
        Me.grpWarrantyCheck.TabIndex = 12
        Me.grpWarrantyCheck.TabStop = False
        Me.grpWarrantyCheck.Text = "Warranty Check"
        '
        'lblWarrantiedNY
        '
        Me.lblWarrantiedNY.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarrantiedNY.ForeColor = System.Drawing.Color.Black
        Me.lblWarrantiedNY.Location = New System.Drawing.Point(168, 65)
        Me.lblWarrantiedNY.Name = "lblWarrantiedNY"
        Me.lblWarrantiedNY.Size = New System.Drawing.Size(169, 56)
        Me.lblWarrantiedNY.TabIndex = 3
        Me.lblWarrantiedNY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWarrantied
        '
        Me.lblWarrantied.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarrantied.ForeColor = System.Drawing.Color.Black
        Me.lblWarrantied.Location = New System.Drawing.Point(28, 84)
        Me.lblWarrantied.Name = "lblWarrantied"
        Me.lblWarrantied.Size = New System.Drawing.Size(140, 19)
        Me.lblWarrantied.TabIndex = 2
        Me.lblWarrantied.Text = "Under Warranty:"
        '
        'lblSN
        '
        Me.lblSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSN.ForeColor = System.Drawing.Color.Black
        Me.lblSN.Location = New System.Drawing.Point(28, 28)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Size = New System.Drawing.Size(131, 18)
        Me.lblSN.TabIndex = 1
        Me.lblSN.Text = "Serial Number:"
        '
        'txtSN
        '
        Me.txtSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.Location = New System.Drawing.Point(159, 28)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(187, 21)
        Me.txtSN.TabIndex = 0
        Me.txtSN.Text = ""
        '
        'cmdAdminEditDevice
        '
        Me.cmdAdminEditDevice.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAdminEditDevice.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdminEditDevice.ForeColor = System.Drawing.Color.White
        Me.cmdAdminEditDevice.Location = New System.Drawing.Point(18, 196)
        Me.cmdAdminEditDevice.Name = "cmdAdminEditDevice"
        Me.cmdAdminEditDevice.Size = New System.Drawing.Size(234, 38)
        Me.cmdAdminEditDevice.TabIndex = 4
        Me.cmdAdminEditDevice.Text = "Data Manipulation"
        Me.cmdAdminEditDevice.Visible = False
        '
        'cmdAdminMapCustMod
        '
        Me.cmdAdminMapCustMod.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdAdminMapCustMod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdminMapCustMod.ForeColor = System.Drawing.Color.White
        Me.cmdAdminMapCustMod.Location = New System.Drawing.Point(18, 253)
        Me.cmdAdminMapCustMod.Name = "cmdAdminMapCustMod"
        Me.cmdAdminMapCustMod.Size = New System.Drawing.Size(234, 46)
        Me.cmdAdminMapCustMod.TabIndex = 9
        Me.cmdAdminMapCustMod.Text = "Map Customer Model to PSS Model"
        '
        'tpgAbacusData
        '
        Me.tpgAbacusData.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgAbacusData.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtAbacusSearchCriteria, Me.grdAbacusRecData, Me.Label8, Me.Label18, Me.Label28, Me.grdAbacusData, Me.cmbAbacusSearchType})
        Me.tpgAbacusData.Location = New System.Drawing.Point(4, 25)
        Me.tpgAbacusData.Name = "tpgAbacusData"
        Me.tpgAbacusData.Size = New System.Drawing.Size(816, 531)
        Me.tpgAbacusData.TabIndex = 3
        Me.tpgAbacusData.Text = "ABACUS DATA"
        '
        'tpgLabel
        '
        Me.tpgLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgLabel.Controls.AddRange(New System.Windows.Forms.Control() {Me.ComboBox1, Me.chkRefreq, Me.dbgDailyWeeklyProd, Me.chkPrintSkyTellLetter, Me.Label14, Me.Label35, Me.cmblblBaud, Me.lbllblModel, Me.chkPrintModelLetter, Me.txtlblSN, Me.Label31, Me.lbllblweekly, Me.chklblPlus, Me.Label5, Me.lbllblDaily, Me.lstModelType, Me.Label32, Me.txtlblCap, Me.chklblND, Me.chkClearData, Me.Label15, Me.Label11, Me.lbllblCust, Me.Label13, Me.lblModelType, Me.cmdlblPrint, Me.msklblFreq})
        Me.tpgLabel.Location = New System.Drawing.Point(4, 25)
        Me.tpgLabel.Name = "tpgLabel"
        Me.tpgLabel.Size = New System.Drawing.Size(816, 531)
        Me.tpgLabel.TabIndex = 2
        Me.tpgLabel.Text = "LABEL"
        '
        'ComboBox1
        '
        Me.ComboBox1.Items.AddRange(New Object() {"A06CQB5812AA", "A06GJB5806AA"})
        Me.ComboBox1.Location = New System.Drawing.Point(183, 265)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(124, 21)
        Me.ComboBox1.TabIndex = 170
        Me.ComboBox1.Text = "--Model Number--"
        Me.ComboBox1.Visible = False
        '
        'chkRefreq
        '
        Me.chkRefreq.BackColor = System.Drawing.Color.Transparent
        Me.chkRefreq.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRefreq.ForeColor = System.Drawing.Color.Blue
        Me.chkRefreq.Location = New System.Drawing.Point(121, 420)
        Me.chkRefreq.Name = "chkRefreq"
        Me.chkRefreq.Size = New System.Drawing.Size(188, 29)
        Me.chkRefreq.TabIndex = 137
        Me.chkRefreq.Text = "Refreq"
        '
        'dbgDailyWeeklyProd
        '
        Me.dbgDailyWeeklyProd.AllowColMove = False
        Me.dbgDailyWeeklyProd.AllowColSelect = False
        Me.dbgDailyWeeklyProd.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgDailyWeeklyProd.AllowUpdate = False
        Me.dbgDailyWeeklyProd.AllowUpdateOnBlur = False
        Me.dbgDailyWeeklyProd.AlternatingRows = True
        Me.dbgDailyWeeklyProd.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgDailyWeeklyProd.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dbgDailyWeeklyProd.CaptionHeight = 17
        Me.dbgDailyWeeklyProd.FilterBar = True
        Me.dbgDailyWeeklyProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgDailyWeeklyProd.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgDailyWeeklyProd.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.dbgDailyWeeklyProd.Location = New System.Drawing.Point(344, 72)
        Me.dbgDailyWeeklyProd.MaintainRowCurrency = True
        Me.dbgDailyWeeklyProd.Name = "dbgDailyWeeklyProd"
        Me.dbgDailyWeeklyProd.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgDailyWeeklyProd.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgDailyWeeklyProd.PreviewInfo.ZoomFactor = 75
        Me.dbgDailyWeeklyProd.RowHeight = 20
        Me.dbgDailyWeeklyProd.Size = New System.Drawing.Size(306, 432)
        Me.dbgDailyWeeklyProd.TabIndex = 136
        Me.dbgDailyWeeklyProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt, style=Bold;ForeColor:White;BackColor:DarkSlateGray;}Selected{ForeColor" & _
        ":ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Transparent;}Footer{F" & _
        "ont:Microsoft Sans Serif, 9pt, style=Bold;}Caption{AlignHorz:Center;ForeColor:Wh" & _
        "ite;BackColor:Transparent;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
        "Color:Control;AlignVert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:H" & _
        "ighlight;}Style12{}OddRow{Font:Microsoft Sans Serif, 8.25pt, style=Bold;ForeColo" & _
        "r:White;BackColor:Teal;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:" & _
        "True;Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Ra" & _
        "ised,,1, 1, 1, 1;ForeColor:DarkBlue;BackColor:LightSteelBlue;}Style8{}Style10{Al" & _
        "ignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win" & _
        ".C1TrueDBGrid.MergeView HBarHeight=""11"" AllowColMove=""False"" AllowColSelect=""Fal" & _
        "se"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" " & _
        "ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""" & _
        "DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGro" & _
        "up=""1"" HorizontalScrollGroup=""1""><Height>428</Height><CaptionStyle parent=""Style" & _
        "2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle paren" & _
        "t=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Foo" & _
        "terStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /" & _
        "><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highlig" & _
        "htRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle" & _
        " parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""" & _
        "Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal""" & _
        " me=""Style1"" /><ClientRect>0, 0, 302, 428</ClientRect><BorderSide>0</BorderSide>" & _
        "<BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><Named" & _
        "Styles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Sty" & _
        "le parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style " & _
        "parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style p" & _
        "arent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style p" & _
        "arent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent" & _
        "=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style " & _
        "parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplit" & _
        "s>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth>" & _
        "<ClientArea>0, 0, 302, 428</ClientArea><PrintPageHeaderStyle parent="""" me=""Style" & _
        "14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'chkPrintSkyTellLetter
        '
        Me.chkPrintSkyTellLetter.BackColor = System.Drawing.Color.Transparent
        Me.chkPrintSkyTellLetter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintSkyTellLetter.ForeColor = System.Drawing.Color.Black
        Me.chkPrintSkyTellLetter.Location = New System.Drawing.Point(121, 364)
        Me.chkPrintSkyTellLetter.Name = "chkPrintSkyTellLetter"
        Me.chkPrintSkyTellLetter.Size = New System.Drawing.Size(188, 29)
        Me.chkPrintSkyTellLetter.TabIndex = 109
        Me.chkPrintSkyTellLetter.Text = "Print SkyTell Letter"
        Me.chkPrintSkyTellLetter.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Black
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(458, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 20)
        Me.Label14.TabIndex = 108
        Me.Label14.Text = "WEEKLY"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Black
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(364, 10)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(53, 20)
        Me.Label35.TabIndex = 107
        Me.Label35.Text = "DAILY"
        '
        'tpgProdTracking
        '
        Me.tpgProdTracking.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgProdTracking.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabMsgProdTracker})
        Me.tpgProdTracking.Location = New System.Drawing.Point(4, 25)
        Me.tpgProdTracking.Name = "tpgProdTracking"
        Me.tpgProdTracking.Size = New System.Drawing.Size(816, 531)
        Me.tpgProdTracking.TabIndex = 6
        Me.tpgProdTracking.Text = "PRODUCT TRACKING"
        '
        'tabMsgProdTracker
        '
        Me.tabMsgProdTracker.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbpgMsgProdTracker, Me.tbpgSetWeeklyGoal})
        Me.tabMsgProdTracker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMsgProdTracker.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabMsgProdTracker.Name = "tabMsgProdTracker"
        Me.tabMsgProdTracker.SelectedIndex = 0
        Me.tabMsgProdTracker.Size = New System.Drawing.Size(816, 531)
        Me.tabMsgProdTracker.TabIndex = 2
        '
        'tbpgMsgProdTracker
        '
        Me.tbpgMsgProdTracker.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tbpgMsgProdTracker.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.lblMonthlyRange, Me.lblWeeklyRange, Me.btnCopyNormalProdTracker, Me.gridSpecialProdTracker, Me.Label16, Me.Label39, Me.gridNormalProdTracker})
        Me.tbpgMsgProdTracker.Location = New System.Drawing.Point(4, 22)
        Me.tbpgMsgProdTracker.Name = "tbpgMsgProdTracker"
        Me.tbpgMsgProdTracker.Size = New System.Drawing.Size(808, 496)
        Me.tbpgMsgProdTracker.TabIndex = 0
        Me.tbpgMsgProdTracker.Text = "MESSAGING PRODUCTION TRACKER"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnRefresh.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(712, 9)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 28)
        Me.btnRefresh.TabIndex = 142
        Me.btnRefresh.Text = "Refresh"
        '
        'lblMonthlyRange
        '
        Me.lblMonthlyRange.BackColor = System.Drawing.Color.Black
        Me.lblMonthlyRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthlyRange.ForeColor = System.Drawing.Color.Gold
        Me.lblMonthlyRange.Location = New System.Drawing.Point(187, 24)
        Me.lblMonthlyRange.Name = "lblMonthlyRange"
        Me.lblMonthlyRange.Size = New System.Drawing.Size(318, 18)
        Me.lblMonthlyRange.TabIndex = 141
        '
        'lblWeeklyRange
        '
        Me.lblWeeklyRange.BackColor = System.Drawing.Color.Black
        Me.lblWeeklyRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyRange.ForeColor = System.Drawing.Color.Gold
        Me.lblWeeklyRange.Location = New System.Drawing.Point(187, 5)
        Me.lblWeeklyRange.Name = "lblWeeklyRange"
        Me.lblWeeklyRange.Size = New System.Drawing.Size(318, 19)
        Me.lblWeeklyRange.TabIndex = 140
        '
        'btnCopyNormalProdTracker
        '
        Me.btnCopyNormalProdTracker.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCopyNormalProdTracker.BackColor = System.Drawing.Color.Green
        Me.btnCopyNormalProdTracker.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyNormalProdTracker.ForeColor = System.Drawing.Color.White
        Me.btnCopyNormalProdTracker.Location = New System.Drawing.Point(536, 9)
        Me.btnCopyNormalProdTracker.Name = "btnCopyNormalProdTracker"
        Me.btnCopyNormalProdTracker.Size = New System.Drawing.Size(158, 28)
        Me.btnCopyNormalProdTracker.TabIndex = 139
        Me.btnCopyNormalProdTracker.Text = "Copy Data to Excel"
        '
        'gridSpecialProdTracker
        '
        Me.gridSpecialProdTracker.AllowColMove = False
        Me.gridSpecialProdTracker.AllowColSelect = False
        Me.gridSpecialProdTracker.AllowFilter = False
        Me.gridSpecialProdTracker.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.gridSpecialProdTracker.AllowUpdate = False
        Me.gridSpecialProdTracker.AllowUpdateOnBlur = False
        Me.gridSpecialProdTracker.AlternatingRows = True
        Me.gridSpecialProdTracker.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.gridSpecialProdTracker.BackColor = System.Drawing.Color.SteelBlue
        Me.gridSpecialProdTracker.CaptionHeight = 19
        Me.gridSpecialProdTracker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridSpecialProdTracker.GroupByCaption = "Drag a column header here to group by that column"
        Me.gridSpecialProdTracker.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.gridSpecialProdTracker.Location = New System.Drawing.Point(9, 400)
        Me.gridSpecialProdTracker.MaintainRowCurrency = True
        Me.gridSpecialProdTracker.Name = "gridSpecialProdTracker"
        Me.gridSpecialProdTracker.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.gridSpecialProdTracker.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.gridSpecialProdTracker.PreviewInfo.ZoomFactor = 75
        Me.gridSpecialProdTracker.RowHeight = 20
        Me.gridSpecialProdTracker.Size = New System.Drawing.Size(781, 80)
        Me.gridSpecialProdTracker.TabIndex = 138
        Me.gridSpecialProdTracker.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{ForeColor:Red;BackColor:T" & _
        "ransparent;}Selected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{Fo" & _
        "reColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;B" & _
        "ackColor:Transparent;}Footer{Font:Microsoft Sans Serif, 9pt, style=Bold;ForeColo" & _
        "r:Black;}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}Style9{" & _
        "}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Center;}Hi" & _
        "ghlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{ForeColo" & _
        "r:Red;BackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Heading{" & _
        "Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVe" & _
        "rt:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Red;BackColor:LightSteelBlue;}Styl" & _
        "e8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><" & _
        "Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""11"" AllowColMove=""False"" Allow" & _
        "ColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" Capti" & _
        "onHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""Dot" & _
        "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
        """1"" HorizontalScrollGroup=""1""><Height>76</Height><CaptionStyle parent=""Style2"" m" & _
        "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
        "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
        "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
        "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
        "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
        "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
        "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
        """Style1"" /><ClientRect>0, 0, 777, 76</ClientRect><BorderSide>0</BorderSide><Bord" & _
        "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
        "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
        "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
        "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
        "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
        "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
        "horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clie" & _
        "ntArea>0, 0, 777, 76</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" />" & _
        "<PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(9, 384)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(207, 19)
        Me.Label16.TabIndex = 137
        Me.Label16.Text = "Special Project"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(9, 28)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(159, 18)
        Me.Label39.TabIndex = 136
        Me.Label39.Text = "Product Plan (Normal)"
        '
        'gridNormalProdTracker
        '
        Me.gridNormalProdTracker.AllowColMove = False
        Me.gridNormalProdTracker.AllowColSelect = False
        Me.gridNormalProdTracker.AllowFilter = False
        Me.gridNormalProdTracker.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.gridNormalProdTracker.AllowUpdate = False
        Me.gridNormalProdTracker.AllowUpdateOnBlur = False
        Me.gridNormalProdTracker.AlternatingRows = True
        Me.gridNormalProdTracker.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.gridNormalProdTracker.BackColor = System.Drawing.Color.SteelBlue
        Me.gridNormalProdTracker.CaptionHeight = 19
        Me.gridNormalProdTracker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridNormalProdTracker.GroupByCaption = "Drag a column header here to group by that column"
        Me.gridNormalProdTracker.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
        Me.gridNormalProdTracker.Location = New System.Drawing.Point(9, 46)
        Me.gridNormalProdTracker.MaintainRowCurrency = True
        Me.gridNormalProdTracker.Name = "gridNormalProdTracker"
        Me.gridNormalProdTracker.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.gridNormalProdTracker.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.gridNormalProdTracker.PreviewInfo.ZoomFactor = 75
        Me.gridNormalProdTracker.RowHeight = 20
        Me.gridNormalProdTracker.Size = New System.Drawing.Size(781, 338)
        Me.gridNormalProdTracker.TabIndex = 135
        Me.gridNormalProdTracker.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
        "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
        "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
        "parent;}Footer{Font:Microsoft Sans Serif, 9pt, style=Bold;}Caption{AlignHorz:Cen" & _
        "ter;ForeColor:White;BackColor:Transparent;}Style1{}Normal{Font:Microsoft Sans Se" & _
        "rif, 8.25pt;AlignVert:Center;BackColor:Control;}HighlightRow{ForeColor:Highlight" & _
        "Text;BackColor:Highlight;}Style14{}OddRow{BackColor:Transparent;}RecordSelector{" & _
        "AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt," & _
        " style=Bold;AlignHorz:Center;BackColor:LightSteelBlue;Border:Raised,,1, 1, 1, 1;" & _
        "ForeColor:Black;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style" & _
        "12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBar" & _
        "Height=""11"" AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""" & _
        "None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Col" & _
        "umnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" De" & _
        "fRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>334<" & _
        "/Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor" & _
        """ me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle par" & _
        "ent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Group" & _
        "Style parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /" & _
        "><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""I" & _
        "nactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelecto" & _
        "rStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" m" & _
        "e=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 777, 334</Cl" & _
        "ientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1T" & _
        "rueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style " & _
        "parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style pare" & _
        "nt=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style paren" & _
        "t=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""N" & _
        "ormal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""" & _
        "Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style paren" & _
        "t=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Default" & _
        "RecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 777, 334</ClientArea><Print" & _
        "PageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Sty" & _
        "le15"" /></Blob>"
        '
        'tbpgSetWeeklyGoal
        '
        Me.tbpgSetWeeklyGoal.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tbpgSetWeeklyGoal.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkSpecialProj, Me.txtAWAP, Me.Label47, Me.Label46, Me.cboFreq, Me.btnAddProdWlyGoal, Me.txtWeek05, Me.Label40, Me.txtWeek04, Me.Label41, Me.txtWeek03, Me.Label42, Me.txtWeek02, Me.Label43, Me.txtWeek01, Me.Label44, Me.Label45, Me.cboModel, Me.btnClearProdWlyGoal, Me.gridEditProdWeeklyGoal})
        Me.tbpgSetWeeklyGoal.Location = New System.Drawing.Point(4, 22)
        Me.tbpgSetWeeklyGoal.Name = "tbpgSetWeeklyGoal"
        Me.tbpgSetWeeklyGoal.Size = New System.Drawing.Size(808, 496)
        Me.tbpgSetWeeklyGoal.TabIndex = 1
        Me.tbpgSetWeeklyGoal.Text = "SET PRODUCTION WEELY GOAL"
        Me.tbpgSetWeeklyGoal.Visible = False
        '
        'chkSpecialProj
        '
        Me.chkSpecialProj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSpecialProj.ForeColor = System.Drawing.Color.Red
        Me.chkSpecialProj.Location = New System.Drawing.Point(88, 75)
        Me.chkSpecialProj.Name = "chkSpecialProj"
        Me.chkSpecialProj.Size = New System.Drawing.Size(252, 19)
        Me.chkSpecialProj.TabIndex = 155
        Me.chkSpecialProj.Text = "Special Project"
        '
        'txtAWAP
        '
        Me.txtAWAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAWAP.Location = New System.Drawing.Point(408, 9)
        Me.txtAWAP.MaxLength = 6
        Me.txtAWAP.Name = "txtAWAP"
        Me.txtAWAP.Size = New System.Drawing.Size(94, 22)
        Me.txtAWAP.TabIndex = 153
        Me.txtAWAP.Text = ""
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(344, 13)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(64, 18)
        Me.Label47.TabIndex = 154
        Me.Label47.Text = "AWAP:"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(-8, 42)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(94, 19)
        Me.Label46.TabIndex = 152
        Me.Label46.Text = "Frequency:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFreq
        '
        Me.cboFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFreq.Location = New System.Drawing.Point(88, 37)
        Me.cboFreq.Name = "cboFreq"
        Me.cboFreq.Size = New System.Drawing.Size(252, 23)
        Me.cboFreq.TabIndex = 151
        '
        'btnAddProdWlyGoal
        '
        Me.btnAddProdWlyGoal.BackColor = System.Drawing.Color.Green
        Me.btnAddProdWlyGoal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProdWlyGoal.ForeColor = System.Drawing.Color.White
        Me.btnAddProdWlyGoal.Location = New System.Drawing.Point(688, 56)
        Me.btnAddProdWlyGoal.Name = "btnAddProdWlyGoal"
        Me.btnAddProdWlyGoal.Size = New System.Drawing.Size(93, 38)
        Me.btnAddProdWlyGoal.TabIndex = 8
        Me.btnAddProdWlyGoal.Text = "Add"
        Me.btnAddProdWlyGoal.Visible = False
        '
        'txtWeek05
        '
        Me.txtWeek05.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeek05.Location = New System.Drawing.Point(576, 65)
        Me.txtWeek05.MaxLength = 6
        Me.txtWeek05.Name = "txtWeek05"
        Me.txtWeek05.Size = New System.Drawing.Size(94, 22)
        Me.txtWeek05.TabIndex = 6
        Me.txtWeek05.Text = ""
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(512, 68)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(64, 18)
        Me.Label40.TabIndex = 148
        Me.Label40.Text = "Week 05:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWeek04
        '
        Me.txtWeek04.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeek04.Location = New System.Drawing.Point(576, 37)
        Me.txtWeek04.MaxLength = 6
        Me.txtWeek04.Name = "txtWeek04"
        Me.txtWeek04.Size = New System.Drawing.Size(94, 22)
        Me.txtWeek04.TabIndex = 5
        Me.txtWeek04.Text = ""
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(512, 40)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(64, 19)
        Me.Label41.TabIndex = 146
        Me.Label41.Text = "Week 04:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWeek03
        '
        Me.txtWeek03.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeek03.Location = New System.Drawing.Point(576, 9)
        Me.txtWeek03.MaxLength = 6
        Me.txtWeek03.Name = "txtWeek03"
        Me.txtWeek03.Size = New System.Drawing.Size(94, 22)
        Me.txtWeek03.TabIndex = 4
        Me.txtWeek03.Text = ""
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(512, 11)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(64, 19)
        Me.Label42.TabIndex = 144
        Me.Label42.Text = "Week 03:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWeek02
        '
        Me.txtWeek02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeek02.Location = New System.Drawing.Point(408, 65)
        Me.txtWeek02.MaxLength = 6
        Me.txtWeek02.Name = "txtWeek02"
        Me.txtWeek02.Size = New System.Drawing.Size(94, 22)
        Me.txtWeek02.TabIndex = 3
        Me.txtWeek02.Text = ""
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(344, 68)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(64, 18)
        Me.Label43.TabIndex = 142
        Me.Label43.Text = "Week 02:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWeek01
        '
        Me.txtWeek01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeek01.Location = New System.Drawing.Point(408, 37)
        Me.txtWeek01.MaxLength = 6
        Me.txtWeek01.Name = "txtWeek01"
        Me.txtWeek01.Size = New System.Drawing.Size(94, 22)
        Me.txtWeek01.TabIndex = 2
        Me.txtWeek01.Text = ""
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(344, 40)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(64, 19)
        Me.Label44.TabIndex = 140
        Me.Label44.Text = "Week 01:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(24, 9)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(66, 19)
        Me.Label45.TabIndex = 139
        Me.Label45.Text = "Model:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboModel
        '
        Me.cboModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModel.Location = New System.Drawing.Point(88, 7)
        Me.cboModel.Name = "cboModel"
        Me.cboModel.Size = New System.Drawing.Size(252, 23)
        Me.cboModel.TabIndex = 1
        '
        'btnClearProdWlyGoal
        '
        Me.btnClearProdWlyGoal.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClearProdWlyGoal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearProdWlyGoal.ForeColor = System.Drawing.Color.White
        Me.btnClearProdWlyGoal.Location = New System.Drawing.Point(688, 9)
        Me.btnClearProdWlyGoal.Name = "btnClearProdWlyGoal"
        Me.btnClearProdWlyGoal.Size = New System.Drawing.Size(93, 37)
        Me.btnClearProdWlyGoal.TabIndex = 7
        Me.btnClearProdWlyGoal.Text = "Clear"
        '
        'gridEditProdWeeklyGoal
        '
        Me.gridEditProdWeeklyGoal.AllowColMove = False
        Me.gridEditProdWeeklyGoal.AllowColSelect = False
        Me.gridEditProdWeeklyGoal.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.gridEditProdWeeklyGoal.AllowUpdate = False
        Me.gridEditProdWeeklyGoal.AllowUpdateOnBlur = False
        Me.gridEditProdWeeklyGoal.AlternatingRows = True
        Me.gridEditProdWeeklyGoal.BackColor = System.Drawing.Color.SteelBlue
        Me.gridEditProdWeeklyGoal.CaptionHeight = 19
        Me.gridEditProdWeeklyGoal.FilterBar = True
        Me.gridEditProdWeeklyGoal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridEditProdWeeklyGoal.GroupByCaption = "Drag a column header here to group by that column"
        Me.gridEditProdWeeklyGoal.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
        Me.gridEditProdWeeklyGoal.Location = New System.Drawing.Point(9, 103)
        Me.gridEditProdWeeklyGoal.MaintainRowCurrency = True
        Me.gridEditProdWeeklyGoal.Name = "gridEditProdWeeklyGoal"
        Me.gridEditProdWeeklyGoal.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.gridEditProdWeeklyGoal.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.gridEditProdWeeklyGoal.PreviewInfo.ZoomFactor = 75
        Me.gridEditProdWeeklyGoal.RowHeight = 20
        Me.gridEditProdWeeklyGoal.Size = New System.Drawing.Size(775, 430)
        Me.gridEditProdWeeklyGoal.TabIndex = 136
        Me.gridEditProdWeeklyGoal.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
        "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
        "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
        "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
        "Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cen" & _
        "ter;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{B" & _
        "ackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
        "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Cent" & _
        "er;Border:Raised,,1, 1, 1, 1;ForeColor:Black;BackColor:LightSteelBlue;}Style8{}S" & _
        "tyle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Split" & _
        "s><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""11"" AllowColMove=""False"" AllowColSe" & _
        "lect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
        "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
        "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
        "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>426</Height><CaptionStyle pare" & _
        "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
        "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
        "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
        "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
        "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
        "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
        "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
        "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 771, 426</ClientRect><BorderSide>0</Bo" & _
        "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
        "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
        "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
        "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
        "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
        "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
        "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
        "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
        "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
        "SelWidth><ClientArea>0, 0, 771, 426</ClientArea><PrintPageHeaderStyle parent="""" " & _
        "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'tpgDivideTray
        '
        Me.tpgDivideTray.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgDivideTray.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDT_ClearAll, Me.btnDT_DivideTray, Me.btnDT_RemoveAll, Me.btnDT_RemoveOne, Me.Label33, Me.Label34, Me.lblDT_NewTrayQty, Me.Label30, Me.lblDT_OriginalTrayQty, Me.txtDT_MovedSN, Me.lstDT_NewTraySNs, Me.lstDT_OriginalTraySNs, Me.Label29, Me.txtDT_TrayID})
        Me.tpgDivideTray.Location = New System.Drawing.Point(4, 25)
        Me.tpgDivideTray.Name = "tpgDivideTray"
        Me.tpgDivideTray.Size = New System.Drawing.Size(816, 531)
        Me.tpgDivideTray.TabIndex = 5
        Me.tpgDivideTray.Text = "DIVIDE TRAY"
        '
        'btnDT_ClearAll
        '
        Me.btnDT_ClearAll.BackColor = System.Drawing.Color.Red
        Me.btnDT_ClearAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDT_ClearAll.ForeColor = System.Drawing.Color.White
        Me.btnDT_ClearAll.Location = New System.Drawing.Point(205, 443)
        Me.btnDT_ClearAll.Name = "btnDT_ClearAll"
        Me.btnDT_ClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDT_ClearAll.Size = New System.Drawing.Size(113, 37)
        Me.btnDT_ClearAll.TabIndex = 106
        Me.btnDT_ClearAll.Text = "CLEAR ALL"
        '
        'btnDT_DivideTray
        '
        Me.btnDT_DivideTray.BackColor = System.Drawing.Color.Green
        Me.btnDT_DivideTray.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDT_DivideTray.ForeColor = System.Drawing.Color.White
        Me.btnDT_DivideTray.Location = New System.Drawing.Point(533, 439)
        Me.btnDT_DivideTray.Name = "btnDT_DivideTray"
        Me.btnDT_DivideTray.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDT_DivideTray.Size = New System.Drawing.Size(122, 42)
        Me.btnDT_DivideTray.TabIndex = 105
        Me.btnDT_DivideTray.Text = "DIVIDE TRAY"
        '
        'btnDT_RemoveAll
        '
        Me.btnDT_RemoveAll.BackColor = System.Drawing.Color.Red
        Me.btnDT_RemoveAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDT_RemoveAll.ForeColor = System.Drawing.Color.White
        Me.btnDT_RemoveAll.Location = New System.Drawing.Point(533, 234)
        Me.btnDT_RemoveAll.Name = "btnDT_RemoveAll"
        Me.btnDT_RemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDT_RemoveAll.Size = New System.Drawing.Size(113, 37)
        Me.btnDT_RemoveAll.TabIndex = 104
        Me.btnDT_RemoveAll.Text = "REMOVE ALL SNs"
        '
        'btnDT_RemoveOne
        '
        Me.btnDT_RemoveOne.BackColor = System.Drawing.Color.Red
        Me.btnDT_RemoveOne.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDT_RemoveOne.ForeColor = System.Drawing.Color.White
        Me.btnDT_RemoveOne.Location = New System.Drawing.Point(533, 178)
        Me.btnDT_RemoveOne.Name = "btnDT_RemoveOne"
        Me.btnDT_RemoveOne.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDT_RemoveOne.Size = New System.Drawing.Size(113, 37)
        Me.btnDT_RemoveOne.TabIndex = 103
        Me.btnDT_RemoveOne.Text = "REMOVE ONE SN"
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(103, 54)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(122, 18)
        Me.Label33.TabIndex = 102
        Me.Label33.Text = "SN to be moved:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Black
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Lime
        Me.Label34.Location = New System.Drawing.Point(421, 9)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(93, 33)
        Me.Label34.TabIndex = 100
        Me.Label34.Text = "NEW TRAY QTY"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDT_NewTrayQty
        '
        Me.lblDT_NewTrayQty.BackColor = System.Drawing.Color.Black
        Me.lblDT_NewTrayQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDT_NewTrayQty.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDT_NewTrayQty.ForeColor = System.Drawing.Color.Lime
        Me.lblDT_NewTrayQty.Location = New System.Drawing.Point(421, 37)
        Me.lblDT_NewTrayQty.Name = "lblDT_NewTrayQty"
        Me.lblDT_NewTrayQty.Size = New System.Drawing.Size(93, 40)
        Me.lblDT_NewTrayQty.TabIndex = 101
        Me.lblDT_NewTrayQty.Text = "0"
        Me.lblDT_NewTrayQty.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Black
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Lime
        Me.Label30.Location = New System.Drawing.Point(9, 4)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(94, 32)
        Me.Label30.TabIndex = 98
        Me.Label30.Text = "ORIGINAL TRAY QTY"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDT_OriginalTrayQty
        '
        Me.lblDT_OriginalTrayQty.BackColor = System.Drawing.Color.Black
        Me.lblDT_OriginalTrayQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDT_OriginalTrayQty.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDT_OriginalTrayQty.ForeColor = System.Drawing.Color.Lime
        Me.lblDT_OriginalTrayQty.Location = New System.Drawing.Point(9, 36)
        Me.lblDT_OriginalTrayQty.Name = "lblDT_OriginalTrayQty"
        Me.lblDT_OriginalTrayQty.Size = New System.Drawing.Size(94, 40)
        Me.lblDT_OriginalTrayQty.TabIndex = 99
        Me.lblDT_OriginalTrayQty.Text = "0"
        Me.lblDT_OriginalTrayQty.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDT_MovedSN
        '
        Me.txtDT_MovedSN.BackColor = System.Drawing.Color.LightSalmon
        Me.txtDT_MovedSN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDT_MovedSN.Location = New System.Drawing.Point(225, 53)
        Me.txtDT_MovedSN.Name = "txtDT_MovedSN"
        Me.txtDT_MovedSN.Size = New System.Drawing.Size(187, 21)
        Me.txtDT_MovedSN.TabIndex = 2
        Me.txtDT_MovedSN.Text = ""
        '
        'lstDT_NewTraySNs
        '
        Me.lstDT_NewTraySNs.Location = New System.Drawing.Point(327, 84)
        Me.lstDT_NewTraySNs.Name = "lstDT_NewTraySNs"
        Me.lstDT_NewTraySNs.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstDT_NewTraySNs.Size = New System.Drawing.Size(187, 394)
        Me.lstDT_NewTraySNs.TabIndex = 4
        Me.lstDT_NewTraySNs.TabStop = False
        '
        'lstDT_OriginalTraySNs
        '
        Me.lstDT_OriginalTraySNs.Location = New System.Drawing.Point(9, 84)
        Me.lstDT_OriginalTraySNs.Name = "lstDT_OriginalTraySNs"
        Me.lstDT_OriginalTraySNs.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstDT_OriginalTraySNs.Size = New System.Drawing.Size(187, 394)
        Me.lstDT_OriginalTraySNs.TabIndex = 3
        Me.lstDT_OriginalTraySNs.TabStop = False
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(159, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 18)
        Me.Label29.TabIndex = 22
        Me.Label29.Text = "Tray ID:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDT_TrayID
        '
        Me.txtDT_TrayID.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.txtDT_TrayID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDT_TrayID.Location = New System.Drawing.Point(225, 19)
        Me.txtDT_TrayID.Name = "txtDT_TrayID"
        Me.txtDT_TrayID.Size = New System.Drawing.Size(102, 21)
        Me.txtDT_TrayID.TabIndex = 1
        Me.txtDT_TrayID.Text = ""
        '
        'tpgRec
        '
        Me.tpgRec.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDbrNerRemoval, Me.lblEquipTypeMismatch, Me.lblModelActive, Me.pnlRecFreqBaud, Me.btnMessageBoard, Me.chkRecPrintWorkSheet, Me.cmbRecModel, Me.lblRecPO, Me.Label22, Me.btnRecDBRTray, Me.Label3, Me.Label10, Me.Label7, Me.Label26, Me.cmdRecReprintManifest, Me.Label6, Me.txtRecWO, Me.grdRecDevices, Me.btnRecClearAll, Me.lblRecModelDesc, Me.cmbRecCust, Me.txtRecTrayMemo, Me.cmdClear, Me.lblRecWOHasFile, Me.btnRecClear, Me.chkRecCheckWarranty, Me.lblRecAddress, Me.lblRecLoc, Me.Label25, Me.lblRecDevRcvdCnt, Me.Label20, Me.Label9, Me.Label4, Me.Label17, Me.lblRecScanCnt, Me.txtRecDevSN, Me.Label19, Me.txtRecTray_ID, Me.cmdRecTray})
        Me.tpgRec.Location = New System.Drawing.Point(4, 25)
        Me.tpgRec.Name = "tpgRec"
        Me.tpgRec.Size = New System.Drawing.Size(816, 531)
        Me.tpgRec.TabIndex = 1
        Me.tpgRec.Text = "RECEIVE"
        '
        'btnDbrNerRemoval
        '
        Me.btnDbrNerRemoval.BackColor = System.Drawing.Color.BurlyWood
        Me.btnDbrNerRemoval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDbrNerRemoval.Location = New System.Drawing.Point(688, 336)
        Me.btnDbrNerRemoval.Name = "btnDbrNerRemoval"
        Me.btnDbrNerRemoval.Size = New System.Drawing.Size(112, 40)
        Me.btnDbrNerRemoval.TabIndex = 12
        Me.btnDbrNerRemoval.Text = "Mrg. DBR/NER Removal"
        Me.btnDbrNerRemoval.Visible = False
        '
        'lblEquipTypeMismatch
        '
        Me.lblEquipTypeMismatch.BackColor = System.Drawing.Color.Red
        Me.lblEquipTypeMismatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEquipTypeMismatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquipTypeMismatch.ForeColor = System.Drawing.Color.Yellow
        Me.lblEquipTypeMismatch.Location = New System.Drawing.Point(568, 474)
        Me.lblEquipTypeMismatch.Name = "lblEquipTypeMismatch"
        Me.lblEquipTypeMismatch.Size = New System.Drawing.Size(232, 56)
        Me.lblEquipTypeMismatch.TabIndex = 147
        Me.lblEquipTypeMismatch.Text = "Equipment Type Mismatch"
        Me.lblEquipTypeMismatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEquipTypeMismatch.Visible = False
        '
        'lblModelActive
        '
        Me.lblModelActive.AllowDrop = True
        Me.lblModelActive.Font = New System.Drawing.Font("Arial", 14.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelActive.ForeColor = System.Drawing.Color.Red
        Me.lblModelActive.Location = New System.Drawing.Point(408, 152)
        Me.lblModelActive.Name = "lblModelActive"
        Me.lblModelActive.Size = New System.Drawing.Size(80, 29)
        Me.lblModelActive.TabIndex = 146
        Me.lblModelActive.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pnlRecFreqBaud
        '
        Me.pnlRecFreqBaud.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label51, Me.txtRecCapCode, Me.cboRecBaud, Me.Label50, Me.cboRecFreq, Me.lblFreq})
        Me.pnlRecFreqBaud.Location = New System.Drawing.Point(8, 104)
        Me.pnlRecFreqBaud.Name = "pnlRecFreqBaud"
        Me.pnlRecFreqBaud.Size = New System.Drawing.Size(680, 34)
        Me.pnlRecFreqBaud.TabIndex = 5
        Me.pnlRecFreqBaud.Visible = False
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(512, 8)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(40, 18)
        Me.Label51.TabIndex = 138
        Me.Label51.Text = "Cap :"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecCapCode
        '
        Me.txtRecCapCode.BackColor = System.Drawing.Color.White
        Me.txtRecCapCode.Location = New System.Drawing.Point(552, 8)
        Me.txtRecCapCode.MaxLength = 15
        Me.txtRecCapCode.Name = "txtRecCapCode"
        Me.txtRecCapCode.Size = New System.Drawing.Size(120, 20)
        Me.txtRecCapCode.TabIndex = 3
        Me.txtRecCapCode.Text = ""
        '
        'cboRecBaud
        '
        Me.cboRecBaud.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboRecBaud.AutoCompletion = True
        Me.cboRecBaud.AutoDropDown = True
        Me.cboRecBaud.AutoSelect = True
        Me.cboRecBaud.Caption = ""
        Me.cboRecBaud.CaptionHeight = 17
        Me.cboRecBaud.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboRecBaud.ColumnCaptionHeight = 17
        Me.cboRecBaud.ColumnFooterHeight = 17
        Me.cboRecBaud.ColumnHeaders = False
        Me.cboRecBaud.ContentHeight = 15
        Me.cboRecBaud.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboRecBaud.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboRecBaud.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRecBaud.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboRecBaud.EditorHeight = 15
        Me.cboRecBaud.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRecBaud.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
        Me.cboRecBaud.ItemHeight = 15
        Me.cboRecBaud.Location = New System.Drawing.Point(368, 8)
        Me.cboRecBaud.MatchEntryTimeout = CType(2000, Long)
        Me.cboRecBaud.MaxDropDownItems = CType(10, Short)
        Me.cboRecBaud.MaxLength = 32767
        Me.cboRecBaud.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboRecBaud.Name = "cboRecBaud"
        Me.cboRecBaud.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboRecBaud.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboRecBaud.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboRecBaud.Size = New System.Drawing.Size(136, 21)
        Me.cboRecBaud.TabIndex = 2
        Me.cboRecBaud.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
        "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
        "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
        "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
        "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
        "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
        "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
        "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
        "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
        """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
        "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
        "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
        "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
        """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
        "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
        "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
        "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
        "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
        "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
        """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
        "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
        "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
        "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(320, 10)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(48, 14)
        Me.Label50.TabIndex = 110
        Me.Label50.Text = "Baud :"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboRecFreq
        '
        Me.cboRecFreq.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboRecFreq.AutoCompletion = True
        Me.cboRecFreq.AutoDropDown = True
        Me.cboRecFreq.AutoSelect = True
        Me.cboRecFreq.Caption = ""
        Me.cboRecFreq.CaptionHeight = 17
        Me.cboRecFreq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboRecFreq.ColumnCaptionHeight = 17
        Me.cboRecFreq.ColumnFooterHeight = 17
        Me.cboRecFreq.ColumnHeaders = False
        Me.cboRecFreq.ContentHeight = 15
        Me.cboRecFreq.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboRecFreq.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboRecFreq.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRecFreq.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboRecFreq.EditorHeight = 15
        Me.cboRecFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRecFreq.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
        Me.cboRecFreq.ItemHeight = 15
        Me.cboRecFreq.Location = New System.Drawing.Point(110, 8)
        Me.cboRecFreq.MatchEntryTimeout = CType(2000, Long)
        Me.cboRecFreq.MaxDropDownItems = CType(10, Short)
        Me.cboRecFreq.MaxLength = 32767
        Me.cboRecFreq.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboRecFreq.Name = "cboRecFreq"
        Me.cboRecFreq.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboRecFreq.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboRecFreq.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboRecFreq.Size = New System.Drawing.Size(136, 21)
        Me.cboRecFreq.TabIndex = 1
        Me.cboRecFreq.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
        "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
        "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
        "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
        ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
        "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
        "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
        "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
        "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
        """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
        "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
        "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
        "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
        """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
        "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
        "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
        "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
        "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
        "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
        """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
        "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
        "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
        "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'lblFreq
        '
        Me.lblFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFreq.Location = New System.Drawing.Point(62, 11)
        Me.lblFreq.Name = "lblFreq"
        Me.lblFreq.Size = New System.Drawing.Size(48, 21)
        Me.lblFreq.TabIndex = 108
        Me.lblFreq.Text = "Freq :"
        Me.lblFreq.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnMessageBoard
        '
        Me.btnMessageBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMessageBoard.ForeColor = System.Drawing.Color.SlateBlue
        Me.btnMessageBoard.Location = New System.Drawing.Point(688, 192)
        Me.btnMessageBoard.Name = "btnMessageBoard"
        Me.btnMessageBoard.Size = New System.Drawing.Size(112, 32)
        Me.btnMessageBoard.TabIndex = 9
        Me.btnMessageBoard.Text = """Hot"" Message"
        '
        'chkRecPrintWorkSheet
        '
        Me.chkRecPrintWorkSheet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecPrintWorkSheet.ForeColor = System.Drawing.Color.Blue
        Me.chkRecPrintWorkSheet.Location = New System.Drawing.Point(8, 480)
        Me.chkRecPrintWorkSheet.Name = "chkRecPrintWorkSheet"
        Me.chkRecPrintWorkSheet.Size = New System.Drawing.Size(152, 24)
        Me.chkRecPrintWorkSheet.TabIndex = 145
        Me.chkRecPrintWorkSheet.TabStop = False
        Me.chkRecPrintWorkSheet.Text = "Print Work Sheet"
        '
        'cmbRecModel
        '
        Me.cmbRecModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cmbRecModel.Caption = ""
        Me.cmbRecModel.CaptionHeight = 17
        Me.cmbRecModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbRecModel.ColumnCaptionHeight = 17
        Me.cmbRecModel.ColumnFooterHeight = 17
        Me.cmbRecModel.ContentHeight = 15
        Me.cmbRecModel.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbRecModel.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cmbRecModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecModel.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbRecModel.EditorHeight = 15
        Me.cmbRecModel.Images.Add(CType(resources.GetObject("resource.Images9"), System.Drawing.Bitmap))
        Me.cmbRecModel.ItemHeight = 15
        Me.cmbRecModel.Location = New System.Drawing.Point(120, 56)
        Me.cmbRecModel.MatchEntryTimeout = CType(2000, Long)
        Me.cmbRecModel.MaxDropDownItems = CType(5, Short)
        Me.cmbRecModel.MaxLength = 32767
        Me.cmbRecModel.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbRecModel.Name = "cmbRecModel"
        Me.cmbRecModel.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbRecModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbRecModel.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbRecModel.Size = New System.Drawing.Size(257, 21)
        Me.cmbRecModel.TabIndex = 3
        Me.cmbRecModel.Text = "C1Combo1"
        Me.cmbRecModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'tpgShipmentSummary
        '
        Me.tpgShipmentSummary.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpgShipmentSummary.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSSummary_CopyToExcel, Me.btnSSummary_Clear, Me.btnSSummary_Go, Me.Label38, Me.dtpSSummary_pkslipCreationDate, Me.Label37, Me.Label36, Me.txtSSummary_PkSlipID, Me.btnSSummary_printSelected, Me.btnSSummary_PrintAll, Me.grdShipmentSummary})
        Me.tpgShipmentSummary.Location = New System.Drawing.Point(4, 25)
        Me.tpgShipmentSummary.Name = "tpgShipmentSummary"
        Me.tpgShipmentSummary.Size = New System.Drawing.Size(816, 531)
        Me.tpgShipmentSummary.TabIndex = 7
        Me.tpgShipmentSummary.Text = "SHIPMENT SUMMARY"
        '
        'btnSSummary_CopyToExcel
        '
        Me.btnSSummary_CopyToExcel.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnSSummary_CopyToExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSSummary_CopyToExcel.ForeColor = System.Drawing.Color.White
        Me.btnSSummary_CopyToExcel.Location = New System.Drawing.Point(528, 205)
        Me.btnSSummary_CopyToExcel.Name = "btnSSummary_CopyToExcel"
        Me.btnSSummary_CopyToExcel.Size = New System.Drawing.Size(169, 29)
        Me.btnSSummary_CopyToExcel.TabIndex = 148
        Me.btnSSummary_CopyToExcel.Text = "Copy Data To Excel"
        '
        'btnSSummary_Clear
        '
        Me.btnSSummary_Clear.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSSummary_Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSSummary_Clear.ForeColor = System.Drawing.Color.White
        Me.btnSSummary_Clear.Location = New System.Drawing.Point(528, 72)
        Me.btnSSummary_Clear.Name = "btnSSummary_Clear"
        Me.btnSSummary_Clear.Size = New System.Drawing.Size(169, 28)
        Me.btnSSummary_Clear.TabIndex = 147
        Me.btnSSummary_Clear.Text = "Clear"
        '
        'btnSSummary_Go
        '
        Me.btnSSummary_Go.BackColor = System.Drawing.Color.Green
        Me.btnSSummary_Go.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSSummary_Go.ForeColor = System.Drawing.Color.White
        Me.btnSSummary_Go.Location = New System.Drawing.Point(514, 6)
        Me.btnSSummary_Go.Name = "btnSSummary_Go"
        Me.btnSSummary_Go.Size = New System.Drawing.Size(57, 24)
        Me.btnSSummary_Go.TabIndex = 146
        Me.btnSSummary_Go.Text = "Go"
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(346, 9)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(47, 19)
        Me.Label38.TabIndex = 145
        Me.Label38.Text = "Date:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpSSummary_pkslipCreationDate
        '
        Me.dtpSSummary_pkslipCreationDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpSSummary_pkslipCreationDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSSummary_pkslipCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSSummary_pkslipCreationDate.Location = New System.Drawing.Point(393, 6)
        Me.dtpSSummary_pkslipCreationDate.Name = "dtpSSummary_pkslipCreationDate"
        Me.dtpSSummary_pkslipCreationDate.Size = New System.Drawing.Size(112, 21)
        Me.dtpSSummary_pkslipCreationDate.TabIndex = 2
        Me.dtpSSummary_pkslipCreationDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Red
        Me.Label37.Location = New System.Drawing.Point(280, 9)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(38, 19)
        Me.Label37.TabIndex = 144
        Me.Label37.Text = "OR"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(9, 9)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(132, 19)
        Me.Label36.TabIndex = 142
        Me.Label36.Text = "Manifest Number:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSSummary_PkSlipID
        '
        Me.txtSSummary_PkSlipID.Location = New System.Drawing.Point(141, 6)
        Me.txtSSummary_PkSlipID.Name = "txtSSummary_PkSlipID"
        Me.txtSSummary_PkSlipID.Size = New System.Drawing.Size(84, 20)
        Me.txtSSummary_PkSlipID.TabIndex = 1
        Me.txtSSummary_PkSlipID.Text = ""
        '
        'btnSSummary_printSelected
        '
        Me.btnSSummary_printSelected.BackColor = System.Drawing.Color.DarkGray
        Me.btnSSummary_printSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSSummary_printSelected.ForeColor = System.Drawing.Color.Black
        Me.btnSSummary_printSelected.Location = New System.Drawing.Point(528, 119)
        Me.btnSSummary_printSelected.Name = "btnSSummary_printSelected"
        Me.btnSSummary_printSelected.Size = New System.Drawing.Size(169, 28)
        Me.btnSSummary_printSelected.TabIndex = 3
        Me.btnSSummary_printSelected.Text = "Print Selected Lines"
        '
        'btnSSummary_PrintAll
        '
        Me.btnSSummary_PrintAll.BackColor = System.Drawing.Color.DarkGray
        Me.btnSSummary_PrintAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSSummary_PrintAll.ForeColor = System.Drawing.Color.Black
        Me.btnSSummary_PrintAll.Location = New System.Drawing.Point(528, 166)
        Me.btnSSummary_PrintAll.Name = "btnSSummary_PrintAll"
        Me.btnSSummary_PrintAll.Size = New System.Drawing.Size(169, 28)
        Me.btnSSummary_PrintAll.TabIndex = 4
        Me.btnSSummary_PrintAll.Text = "Print All"
        '
        'grdShipmentSummary
        '
        Me.grdShipmentSummary.AllowColMove = False
        Me.grdShipmentSummary.AllowColSelect = False
        Me.grdShipmentSummary.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdShipmentSummary.AllowUpdate = False
        Me.grdShipmentSummary.AllowUpdateOnBlur = False
        Me.grdShipmentSummary.AlternatingRows = True
        Me.grdShipmentSummary.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdShipmentSummary.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdShipmentSummary.CaptionHeight = 19
        Me.grdShipmentSummary.ColumnFooters = True
        Me.grdShipmentSummary.FilterBar = True
        Me.grdShipmentSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdShipmentSummary.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdShipmentSummary.Images.Add(CType(resources.GetObject("resource.Images10"), System.Drawing.Bitmap))
        Me.grdShipmentSummary.Location = New System.Drawing.Point(9, 32)
        Me.grdShipmentSummary.MaintainRowCurrency = True
        Me.grdShipmentSummary.Name = "grdShipmentSummary"
        Me.grdShipmentSummary.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdShipmentSummary.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdShipmentSummary.PreviewInfo.ZoomFactor = 75
        Me.grdShipmentSummary.RowHeight = 20
        Me.grdShipmentSummary.Size = New System.Drawing.Size(496, 472)
        Me.grdShipmentSummary.TabIndex = 138
        Me.grdShipmentSummary.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
        "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
        "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
        "parent;}Footer{ForeColor:Lime;BackColor:Black;}Caption{AlignHorz:Center;ForeColo" & _
        "r:White;BackColor:Transparent;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;" & _
        "BackColor:Control;AlignVert:Center;}HighlightRow{ForeColor:HighlightText;BackCol" & _
        "or:Highlight;}Style12{}OddRow{BackColor:Transparent;}RecordSelector{AlignImage:C" & _
        "enter;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;" & _
        "AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Red;BackCo" & _
        "lor:LightSteelBlue;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}S" & _
        "tyle1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""11"" Al" & _
        "lowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" Alternat" & _
        "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
        "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
        " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>4" & _
        "72</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
        "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
        "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
        "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
        """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
        "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
        "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
        """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 496, 472<" & _
        "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
        "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
        "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
        "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
        "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
        "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
        "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
        "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
        "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
        "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 496, 472</ClientArea><Pr" & _
        "intPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""" & _
        "Style15"" /></Blob>"
        '
        'tpBuilShipPallet
        '
        Me.tpBuilShipPallet.BackColor = System.Drawing.Color.SteelBlue
        Me.tpBuilShipPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBSP_RepintPalletLabel, Me.Label49, Me.txtBSP_ShipID, Me.lstBSP_ShipIDs, Me.btnBSP_CreatePallet, Me.lblBSP_ScanQty, Me.Label2, Me.lblBSP_DevQty, Me.Label48, Me.btnBSP_ClearAll, Me.btnBSP_Clear})
        Me.tpBuilShipPallet.Location = New System.Drawing.Point(4, 25)
        Me.tpBuilShipPallet.Name = "tpBuilShipPallet"
        Me.tpBuilShipPallet.Size = New System.Drawing.Size(816, 531)
        Me.tpBuilShipPallet.TabIndex = 8
        Me.tpBuilShipPallet.Text = "Build Ship Pallet"
        '
        'btnBSP_RepintPalletLabel
        '
        Me.btnBSP_RepintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnBSP_RepintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBSP_RepintPalletLabel.ForeColor = System.Drawing.Color.Black
        Me.btnBSP_RepintPalletLabel.Location = New System.Drawing.Point(56, 376)
        Me.btnBSP_RepintPalletLabel.Name = "btnBSP_RepintPalletLabel"
        Me.btnBSP_RepintPalletLabel.Size = New System.Drawing.Size(176, 32)
        Me.btnBSP_RepintPalletLabel.TabIndex = 101
        Me.btnBSP_RepintPalletLabel.Text = "Re-Print Pallet Label"
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.White
        Me.Label49.Location = New System.Drawing.Point(80, 32)
        Me.Label49.Name = "Label49"
        Me.Label49.TabIndex = 100
        Me.Label49.Text = "Ship ID"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtBSP_ShipID
        '
        Me.txtBSP_ShipID.Location = New System.Drawing.Point(80, 56)
        Me.txtBSP_ShipID.Name = "txtBSP_ShipID"
        Me.txtBSP_ShipID.Size = New System.Drawing.Size(119, 20)
        Me.txtBSP_ShipID.TabIndex = 85
        Me.txtBSP_ShipID.Text = ""
        '
        'lstBSP_ShipIDs
        '
        Me.lstBSP_ShipIDs.Location = New System.Drawing.Point(80, 88)
        Me.lstBSP_ShipIDs.Name = "lstBSP_ShipIDs"
        Me.lstBSP_ShipIDs.Size = New System.Drawing.Size(119, 225)
        Me.lstBSP_ShipIDs.TabIndex = 86
        '
        'btnBSP_CreatePallet
        '
        Me.btnBSP_CreatePallet.BackColor = System.Drawing.Color.Green
        Me.btnBSP_CreatePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBSP_CreatePallet.ForeColor = System.Drawing.Color.White
        Me.btnBSP_CreatePallet.Location = New System.Drawing.Point(56, 320)
        Me.btnBSP_CreatePallet.Name = "btnBSP_CreatePallet"
        Me.btnBSP_CreatePallet.Size = New System.Drawing.Size(176, 40)
        Me.btnBSP_CreatePallet.TabIndex = 93
        Me.btnBSP_CreatePallet.Text = "Create Pallet"
        '
        'lblBSP_ScanQty
        '
        Me.lblBSP_ScanQty.BackColor = System.Drawing.Color.Black
        Me.lblBSP_ScanQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBSP_ScanQty.ForeColor = System.Drawing.Color.Lime
        Me.lblBSP_ScanQty.Location = New System.Drawing.Point(256, 160)
        Me.lblBSP_ScanQty.Name = "lblBSP_ScanQty"
        Me.lblBSP_ScanQty.Size = New System.Drawing.Size(80, 24)
        Me.lblBSP_ScanQty.TabIndex = 97
        Me.lblBSP_ScanQty.Text = "0"
        Me.lblBSP_ScanQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(256, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Device Qty"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBSP_DevQty
        '
        Me.lblBSP_DevQty.BackColor = System.Drawing.Color.Black
        Me.lblBSP_DevQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBSP_DevQty.ForeColor = System.Drawing.Color.Lime
        Me.lblBSP_DevQty.Location = New System.Drawing.Point(256, 72)
        Me.lblBSP_DevQty.Name = "lblBSP_DevQty"
        Me.lblBSP_DevQty.Size = New System.Drawing.Size(80, 24)
        Me.lblBSP_DevQty.TabIndex = 96
        Me.lblBSP_DevQty.Text = "0"
        Me.lblBSP_DevQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Black
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Lime
        Me.Label48.Location = New System.Drawing.Point(256, 144)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(80, 16)
        Me.Label48.TabIndex = 98
        Me.Label48.Text = "Scan Qty"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBSP_ClearAll
        '
        Me.btnBSP_ClearAll.BackColor = System.Drawing.Color.Red
        Me.btnBSP_ClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBSP_ClearAll.ForeColor = System.Drawing.Color.White
        Me.btnBSP_ClearAll.Location = New System.Drawing.Point(256, 216)
        Me.btnBSP_ClearAll.Name = "btnBSP_ClearAll"
        Me.btnBSP_ClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBSP_ClearAll.Size = New System.Drawing.Size(80, 25)
        Me.btnBSP_ClearAll.TabIndex = 96
        Me.btnBSP_ClearAll.Text = "CLEAR ALL"
        '
        'btnBSP_Clear
        '
        Me.btnBSP_Clear.BackColor = System.Drawing.Color.Red
        Me.btnBSP_Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBSP_Clear.ForeColor = System.Drawing.Color.White
        Me.btnBSP_Clear.Location = New System.Drawing.Point(256, 264)
        Me.btnBSP_Clear.Name = "btnBSP_Clear"
        Me.btnBSP_Clear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBSP_Clear.Size = New System.Drawing.Size(80, 25)
        Me.btnBSP_Clear.TabIndex = 95
        Me.btnBSP_Clear.Text = "CLEAR ONE"
        '
        'lblBanner
        '
        Me.lblBanner.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblBanner.Location = New System.Drawing.Point(168, -5)
        Me.lblBanner.Name = "lblBanner"
        Me.lblBanner.Size = New System.Drawing.Size(824, 32)
        Me.lblBanner.TabIndex = 102
        '
        'frmMessConsole
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1000, 557)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBanner, Me.TabControl1, Me.Panel2, Me.lblHeader})
        Me.Name = "frmMessConsole"
        Me.Text = "Messaging Operations Console"
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdRecDevices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.msklblFreq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAbacusRecData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAbacusData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpgAdmin.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.grpWarrantyCheck.ResumeLayout(False)
        Me.tpgAbacusData.ResumeLayout(False)
        Me.tpgLabel.ResumeLayout(False)
        CType(Me.dbgDailyWeeklyProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgProdTracking.ResumeLayout(False)
        Me.tabMsgProdTracker.ResumeLayout(False)
        Me.tbpgMsgProdTracker.ResumeLayout(False)
        CType(Me.gridSpecialProdTracker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridNormalProdTracker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpgSetWeeklyGoal.ResumeLayout(False)
        CType(Me.gridEditProdWeeklyGoal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgDivideTray.ResumeLayout(False)
        Me.tpgRec.ResumeLayout(False)
        Me.pnlRecFreqBaud.ResumeLayout(False)
        CType(Me.cboRecBaud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRecFreq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRecModel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgShipmentSummary.ResumeLayout(False)
        CType(Me.grdShipmentSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpBuilShipPallet.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



	Protected Overrides Sub Finalize()
		'Dispose all object
		DisposeAllGlobalObjs()

		MyBase.Finalize()
	End Sub

	'*********************************************************

#Region "Common Sub"

	'*********************************************************
	Private Sub frmMessConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim i As Integer = 0

		Try
			'********************************************
			Me.lblMachine.Text = GstrMachine
			Me.lblUserName.Text = GstrUserName
			Me.lblShift.Text = "Shift " & GiShiftID
			Me.lblWorkDate.Text = Me.GstrWorkDate
			Me.chkRecCheckWarranty.Checked = False
			_user_id = PSS.Core.ApplicationUser.IDuser

			'********************************************
			'Set user access
			'********************************************
			If ApplicationUser.GetPermission("MessAdmin") > 0 Then
				Me.cmdAdmin.Tag = True
			End If

			If ApplicationUser.GetPermission("MessReceive") > 0 Then
				Me.cmdReceive.Tag = True
			End If

			If ApplicationUser.GetPermission("AMSLabel") > 0 Then
				Me.cmdLabeling.Tag = True
			End If

			Me.cmdAbacusData.Tag = True

			If ApplicationUser.GetPermission("MessDivideTray") > 0 Then
				Me.btnDivideTray.Tag = True
			End If

			Me.btnShipmentSummary.Tag = True

			If ApplicationUser.GetPermission("MessProdTracking") > 0 Then
				Me.btnProdTracking.Tag = True
				If ApplicationUser.GetPermission("Mess_EditProdGoal") > 0 Then
					Me.gridEditProdWeeklyGoal.AllowUpdate = True
					Me.btnAddProdWlyGoal.Visible = True
				End If
			End If

			'NO SPECIAL PERMISION FOR AMS SHIPPING
			Me.btnBuildShipPallet.Tag = True

			' Load Admin buttons.
			LoadAdminButtons()


			''********************************************
			'i = Me.TabControl1.Size.Width
			'Me.lblBanner.Size = New System.Drawing.Size(900, 21)
			'Me.lblBanner.Location = New System.Drawing.Point(168, 0)

			''********************************************


		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub ShowHidePanels(ByRef ctrlTabPage As Windows.Forms.TabPage)
		Dim dt As DataTable
		Try
			MakeAllPanelsInvisible()
			Select Case ctrlTabPage.Name
				Case Me.tpgAdmin.Name
					If Me.cmdAdmin.Tag = True Then
						Me.TabControl1.Visible = True
						Me.TabControl1.SelectedTab = ctrlTabPage

						If IsNothing(Me.GobjMessAdmin) Then
							Me.GobjMessAdmin = New PSS.Data.Buisness.MessAdmin()
						End If
					End If

				Case Me.tpgRec.Name
					If Me.cmdReceive.Tag = True Then
						Me.TabControl1.Visible = True
						Me.TabControl1.SelectedTab = ctrlTabPage

						If IsNothing(Me.GobjMessReceive) Then
							Me.GobjMessReceive = New PSS.Data.Buisness.MessReceive()
						End If
					End If
				Case Me.tpgLabel.Name
					If Me.cmdLabeling.Tag = True Then
						Me.TabControl1.Visible = True
						Me.TabControl1.SelectedTab = ctrlTabPage

						If IsNothing(Me.GobjMessLabel) Then
							Me.GobjMessLabel = New PSS.Data.Buisness.MessLabel()
						End If
						Me.LoadDailyWeeklyLabelProd()
					End If
				Case Me.tpgAbacusData.Name
					If Me.cmdAbacusData.Tag = True Then
						Me.TabControl1.Visible = True
						Me.TabControl1.SelectedTab = ctrlTabPage

						If IsNothing(Me.GobjMessAbacus) Then
							Me.GobjMessAbacus = New PSS.Data.Buisness.MessAbacusData()
						End If
					End If
				Case Me.tpgDivideTray.Name
					If Me.btnDivideTray.Tag = True Then
						Me.TabControl1.Visible = True
						Me.TabControl1.SelectedTab = ctrlTabPage

						If IsNothing(Me.GobjMessTrayMan) Then
							Me.GobjMessTrayMan = New PSS.Data.Buisness.MessTrayManipulate()
						End If
					End If
				Case Me.tpgShipmentSummary.Name
					If Me.btnShipmentSummary.Tag = True Then
						Me.TabControl1.Visible = True
						Me.TabControl1.SelectedTab = ctrlTabPage
					End If
				Case Me.tpgProdTracking.Name
					If Me.btnProdTracking.Tag = True Then
						Me.TabControl1.Visible = True
						Me.TabControl1.SelectedTab = ctrlTabPage

						If IsNothing(Me.GobjMessTrayMan) Then
							Me._objMsgGoalsDB = New PSS.Data.Buisness.MessProdTracking()
						End If
						'***************************
						Me.LoadProdTrackerData()

						dt = PSS.Data.Buisness.Generic.GetModels(True, 1, )
						Misc.PopulateC1DropDownList(Me.cmbRecModel, dt, "Model_desc", "Model_id")
						Me.cmbRecModel.SelectedValue = 0
						Me.LoadFrequencies()
						Me.LoadMessagingWeeklyGoal()
						'***************************
					End If
				Case Me.tpBuilShipPallet.Name
					If Me.btnBuildShipPallet.Tag = True Then
						Me.TabControl1.Visible = True
						Me.TabControl1.SelectedTab = ctrlTabPage

						If IsNothing(_objMessReports) Then _objMessReports = New PSS.Data.Buisness.MessReports()
					End If
			End Select

		Catch ex As Exception
			Throw ex
		Finally
			PSS.Data.Buisness.Generic.DisposeDT(dt)
		End Try
	End Sub

	'*********************************************************
	Private Sub MakeAllPanelsInvisible()
		Me.TabControl1.Visible = False
	End Sub

	'*********************************************************
	Private Sub DisposeAllGlobalObjs()
		If Not IsNothing(Me.GobjMessAdmin) Then
			Me.GobjMessAdmin = Nothing
		End If
		If Not IsNothing(Me.GobjMessReceive) Then
			Me.GobjMessReceive = Nothing
		End If
		If Not IsNothing(Me.GobjMessLabel) Then
			Me.GobjMessLabel = Nothing
		End If
		If Not IsNothing(Me.GobjMessAbacus) Then
			Me.GobjMessAbacus = Nothing
		End If
		If Not IsNothing(Me.GobjMessTrayMan) Then
			Me.GobjMessTrayMan = Nothing
		End If
		If Not IsNothing(Me._objMsgGoalsDB) Then
			Me._objMsgGoalsDB = Nothing
		End If

		If Not IsNothing(Me._objMessReports) Then
			Me._objMessReports = Nothing
		End If

		GC.Collect()
		GC.WaitForPendingFinalizers()
		GC.Collect()
		GC.WaitForPendingFinalizers()
	End Sub

	'*********************************************************
	Private Sub ResetAllMenuButtons()
		Dim strBC As Color = Color.Black
		Dim strFC As Color = Color.Lime

		SetButtonProps(Me.cmdAdmin, strBC, strFC)
		SetButtonProps(Me.cmdReceive, strBC, strFC)
		SetButtonProps(Me.cmdLabeling, strBC, strFC)
		SetButtonProps(Me.cmdAbacusData, strBC, strFC)
		SetButtonProps(Me.btnReports, strBC, strFC)
		SetButtonProps(Me.btnDivideTray, strBC, strFC)
		SetButtonProps(Me.btnShipmentSummary, strBC, strFC)
		SetButtonProps(Me.btnProdTracking, strBC, strFC)
		SetButtonProps(Me.btnBuildShipPallet, strBC, strFC)
	End Sub

	'*********************************************************
	Private Sub SetButtonProps(ByVal ctrl As Control, _
								ByVal strBC As Color, _
								ByVal strFC As Color)
		With ctrl
			.BackColor = strBC
			.ForeColor = strFC
		End With
	End Sub

	'*********************************************************
	Private Sub LoadCustomers(ByRef cmbCust As ComboBox)
		Dim dtCustomers As New DataTable()
		Dim objMisc As New PSS.Data.Buisness.Misc()

		Try
			dtCustomers = objMisc.GetCustomers(1)
			With cmbCust
				.DataSource = dtCustomers.DefaultView
				.DisplayMember = dtCustomers.Columns("cust_name1").ToString
				.ValueMember = dtCustomers.Columns("Cust_ID").ToString
				.SelectedValue = 0
			End With
		Catch ex As Exception
			Throw ex
		Finally
			If Not IsNothing(dtCustomers) Then
				dtCustomers.Dispose()
				dtCustomers = Nothing
			End If
			objMisc = Nothing
		End Try
	End Sub

	'*********************************************************
	Private Sub LoadBaudRates(ByRef cmbBaud As ComboBox)
		Dim dtBaudRates As New DataTable()
		Dim objML As New PSS.Data.Buisness.MessLabel()

		Try
			dtBaudRates = objML.GetBaudRates()
			With cmbBaud
				.DataSource = dtBaudRates.DefaultView
				.DisplayMember = dtBaudRates.Columns("baud_Number").ToString
				.ValueMember = dtBaudRates.Columns("Baud_ID").ToString
				.SelectedValue = 0
			End With
		Catch ex As Exception
			Throw ex
		Finally
			If Not IsNothing(dtBaudRates) Then
				dtBaudRates.Dispose()
				dtBaudRates = Nothing
			End If
			objML = Nothing
		End Try
	End Sub

	'*********************************************************
	Private Sub ClearAllPages()
		ClearPage_Admin()
		ClearPage_Receive()
		ClearPage_Label()
		ClearPage_DivideTray()
		ClearPage_ShipmentSummary()
		ClearPage_ProdTracking()
		ClearPage_BuildShipPallet()
		ResetAllMenuButtons()
	End Sub

	'*********************************************************

#End Region

#Region "Main Menu Button"

	'*********************************************************
	Private Sub cmdAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdmin.Click
        Dim objMess As PSS.Data.Buisness.Messaging 'testing only
        'Dim custIDs As New ArrayList()
        'Dim IDs As String()

        Try
            '*******************************************************
            'Clear All controls in all panels
            'ClearAllPages()
            ''testing only
            'objMess = New PSS.Data.Buisness.Messaging()
            'If objMess.getOtherCustomers(custIDs) > 0 Then
            '    'Do Nothing
            'End If




            'Set Button Colors
            SetButtonProps(Me.cmdAdmin, Color.Orange, Color.Black)

            'Destroy all Panel Specific Business objects
            DisposeAllGlobalObjs()

            'Invoke Garbage Collector
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            '********************************************************

            'check for user permission
            ShowHidePanels(Me.tpgAdmin)
            Me.LoadCustomers(Me.cmbAdminCustomer)
            Me.dtpAdminLocChgDate.Text = Now
            If ApplicationUser.GetPermission("MessEditDevices") > 0 Then
                Me.cmdAdminEditDevice.Visible = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Admin Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
	End Sub

	'*********************************************************
	Private Sub cmdReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceive.Click
		Dim dt As DataTable
		Dim objML As New PSS.Data.Buisness.MessLabel()

		Try
			Me.lblModelActive.Text = ""

			'******************************************************
			'Clear All controls in all panels
			ClearAllPages()

			'Set Button Colors
			SetButtonProps(Me.cmdReceive, Color.Orange, Color.Black)

			'Destroy all Panel Specific Business objects
			DisposeAllGlobalObjs()

			'Invoke Garbage Collector
			GC.Collect() : GC.WaitForPendingFinalizers()
			GC.Collect() : GC.WaitForPendingFinalizers()
			'******************************************************

			'check for user permission
			ShowHidePanels(Me.tpgRec)
			If Me.cmbRecCust.Items.Count = 0 Then
				Me.LoadCustomers(cmbRecCust)
			End If

			If IsNothing(Me.cmbRecModel.DataSource) Then
				dt = PSS.Data.Buisness.Generic.GetModels(True, 1, )
				dt.DefaultView.RowFilter = "Model_desc <> 'Coaster'"			 'don't dispaly this, requested by Thomas Moralez 

				Misc.PopulateC1DropDownList(Me.cmbRecModel, dt, "Model_desc", "Model_id")
				Me.cmbRecModel.SelectedIndex = 0
				Me.cmbRecModel.SelectedValue = 0
			End If
			dt = Generic.GetFreqs(True)
			Misc.PopulateC1DropDownList(Me.cboRecFreq, dt, "freq_Number", "freq_id")
			Me.cboRecFreq.SelectedValue = 0

			dt = objML.GetBaudRates()
			Misc.PopulateC1DropDownList(Me.cboRecBaud, dt, "baud_Number", "Baud_ID")
			Me.cboRecBaud.SelectedValue = 0

			Me.cmbRecCust.SelectedValue = 14

			NoNeedReceiveDBR()

            Me.txtRecWO.Focus()
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Receive Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			PSS.Data.Buisness.Generic.DisposeDT(dt)
			objML = Nothing
		End Try
	End Sub

	'*********************************************************
	Private Sub cmdLabeling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLabeling.Click
		Try

			'Clear All controls in all panels
			ClearAllPages()

			'Set Button Colors
			SetButtonProps(Me.cmdLabeling, Color.Orange, Color.Black)

			'Destroy all Panel Specific Business objects
			DisposeAllGlobalObjs()

			'Invoke Garbage Collector
			GC.Collect()
			GC.WaitForPendingFinalizers()
			GC.Collect()
			GC.WaitForPendingFinalizers()

			'check for user permission
			ShowHidePanels(Me.tpgLabel)
			Me.LoadBaudRates(Me.cmblblBaud)

			'***********************************************
			'User need permision to change cap,freq and baud
			If ApplicationUser.GetPermission("MessChangeCapFreqBaud") > 0 Then
				Me.txtlblCap.Enabled = True
				Me.msklblFreq.Enabled = True
				Me.cmblblBaud.Enabled = True
				Me.chkRefreq.Enabled = True
			Else
				Me.txtlblCap.Enabled = False
				Me.msklblFreq.Enabled = False
				Me.cmblblBaud.Enabled = False
				Me.chkRefreq.Enabled = False
			End If
			'*********************************************
			'get Daily and weekly label production numbers
			Me.lbllblDaily.Text = Me.GobjMessLabel.GetLabelProductionNumbersByCC(GstrWorkDate, 0)
			Me.lbllblweekly.Text = Me.GobjMessLabel.GetLabelProductionNumbersByCC(GstrWorkDate, 1)
			'*********************************************
			Me.txtlblSN.Focus()
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Label Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub cmdAbacusData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbacusData.Click
		Try
			'******************************************************
			'Clear All controls in all panels
			ClearAllPages()

			'Set Button Colors
			SetButtonProps(Me.cmdAbacusData, Color.Orange, Color.Black)

			'Destroy all Panel Specific Business objects
			DisposeAllGlobalObjs()

			'Invoke Garbage Collector
			GC.Collect()
			GC.WaitForPendingFinalizers()
			GC.Collect()
			GC.WaitForPendingFinalizers()
			'******************************************************

			'check for user permission
			ShowHidePanels(Me.tpgAbacusData)
			Me.cmbAbacusSearchType.SelectedIndex = 1
			Me.txtAbacusSearchCriteria.Focus()

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Abacus Data Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub btnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReports.Click
		Dim frmReport As frmMessReports

		Try
			'******************************************************
			'Clear All controls in all panels
			ClearAllPages()

			'Set Button Colors
			SetButtonProps(Me.btnReports, Color.Orange, Color.Black)

			'Destroy all Panel Specific Business objects
			DisposeAllGlobalObjs()

			'Invoke Garbage Collector
			GC.Collect()
			GC.WaitForPendingFinalizers()
			GC.Collect()
			GC.WaitForPendingFinalizers()
			'******************************************************

			frmReport = New frmMessReports()

			frmReport.ShowDialog()
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub btnDivideTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDivideTray.Click
		Try
			'******************************************************
			'Clear All controls in all panels
			ClearAllPages()

			'Set Button Colors
			SetButtonProps(Me.btnDivideTray, Color.Orange, Color.Black)

			'Destroy all Panel Specific Business objects
			DisposeAllGlobalObjs()

			'Invoke Garbage Collector
			GC.Collect()
			GC.WaitForPendingFinalizers()
			GC.Collect()
			GC.WaitForPendingFinalizers()
			'******************************************************

			'check for user permission
			ShowHidePanels(Me.tpgDivideTray)
			Me.txtDT_TrayID.Focus()

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "TrayDivision Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub btnShipmentSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShipmentSummary.Click
		Try
			'******************************************************
			'Clear All controls in all panels
			ClearAllPages()

			'Set Button Colors
			SetButtonProps(Me.btnShipmentSummary, Color.Orange, Color.Black)

			'Destroy all Panel Specific Business objects
			DisposeAllGlobalObjs()

			'Invoke Garbage Collector
			GC.Collect()
			GC.WaitForPendingFinalizers()
			GC.Collect()
			GC.WaitForPendingFinalizers()
			'******************************************************

			'check for user permission
			ShowHidePanels(Me.tpgShipmentSummary)
			Me.dtpSSummary_pkslipCreationDate.Text = Now
			Me.txtSSummary_PkSlipID.Focus()

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "TrayDivision Button Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub btnProdTracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProdTracking.Click
		Try
			'******************************************************
			'Clear All controls in all panels
			ClearAllPages()

			'Set Button Colors
			SetButtonProps(Me.btnProdTracking, Color.Orange, Color.Black)

			'Destroy all Panel Specific Business objects
			DisposeAllGlobalObjs()

			'Invoke Garbage Collector
			GC.Collect()
			GC.WaitForPendingFinalizers()
			GC.Collect()
			GC.WaitForPendingFinalizers()
			'******************************************************

			'check for user permission
			ShowHidePanels(Me.tpgProdTracking)
			Me.cboModel.Focus()

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "ProductTracking Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub btnBuildShipPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildShipPallet.Click
		Try
			'******************************************************
			'Clear All controls in all panels
			ClearAllPages()

			'Set Button Colors
			SetButtonProps(Me.btnBuildShipPallet, Color.Orange, Color.Black)

			'Destroy all Panel Specific Business objects
			DisposeAllGlobalObjs()

			'Invoke Garbage Collector
			GC.Collect()
			GC.WaitForPendingFinalizers()
			GC.Collect()
			GC.WaitForPendingFinalizers()
			'******************************************************

			'check for user permission
			ShowHidePanels(Me.tpBuilShipPallet)
			Me.txtBSP_ShipID.SelectAll() : Me.txtBSP_ShipID.Focus()

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "btnBuildShipPallet Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub


	'*********************************************************

#End Region

#Region "Admin"
	'*********************************************************
	Private Sub ClearPage_Admin()

	End Sub

	'*********************************************************
	Private Sub cmdAdminLoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdminLoadFile.Click
		Dim strFilePath As String = ""
		Dim i As Integer = 0

		Try
            Me.Enabled = False

			'*******************************************
			'Open File Dialog box
			'*******************************************
			Select Case Me.cmbAdminCustomer.SelectedValue

				Case 1					  'USA MObility
					Me.OpenFileDialog1.DefaultExt = "xls"
					Me.OpenFileDialog1.FilterIndex = 1
					Me.OpenFileDialog1.FileName = "*.xls"
					Me.OpenFileDialog1.ShowDialog()
					If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
						If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
							MessageBox.Show("Incorrect file extension. It must be ""XLS"".", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
							Exit Sub
						End If
						strFilePath = Trim(Me.OpenFileDialog1.FileName)
						'*****************************
						'Load File
						'*****************************
						GobjMessAdmin.LoadUSAMobilityData(strFilePath, GstrUserName)
						'*****************************
					Else
						MessageBox.Show("Please select a file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
						Exit Sub
					End If
				Case 14					 'American Messaging
					Me.OpenFileDialog1.DefaultExt = "xls"
					Me.OpenFileDialog1.FilterIndex = 2
					Me.OpenFileDialog1.FileName = "*.xls"
					Me.OpenFileDialog1.ShowDialog()
					If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
						'If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "csv" Then
						'    MessageBox.Show("Incorrect file extension. It must be ""CSV"".", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
						'    Exit Sub
						'End If
						strFilePath = Trim(Me.OpenFileDialog1.FileName)
						'*****************************
						'Load File
						'*****************************
						GobjMessAdmin.LoadVerizonData(strFilePath, _
													  Me.cmbAdminCustomer.SelectedValue, _
													  Me.GiUserID)
						'*****************************


					Else
						MessageBox.Show("Please select a file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
						Exit Sub
					End If
				Case Else
					Throw New Exception("'Load file' is not designed for this customer.")
			End Select

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Load File Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			Me.Enabled = True
		End Try
	End Sub

	'*********************************************************
	Private Sub cmdAdminCreateWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdminCreateWO.Click
        Dim objMessWO As New frmMessWO()
        Dim custIDs As String() = Nothing
		'Dim i As Integer = 0
		Try
			'If iCust_ID = 1 Then
            With objMessWO

                '.CustID = tmpCustID
                '.DeviceID = tmpDeviceID
                .ShowDialog()
                'Update the DB with the selected DBR reason
                'i = .UPD
            End With
            'End If
        Catch ex As Exception
			Throw ex
		Finally
			If Not IsNothing(objMessWO) Then
				objMessWO.Dispose()
				objMessWO = Nothing
			End If

		End Try
	End Sub

	'*********************************************************
	Private Sub cmdAdminMapCustMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdminMapCustMod.Click
		Dim frmCustModPSSModMap As frmCustModPSSModMap
		Dim iDefaultCustomer As Integer = 14

		Try
			frmCustModPSSModMap = New frmCustModPSSModMap(1, iDefaultCustomer)
			frmCustModPSSModMap.ShowDialog()
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Customer Model PSS Model Mapping", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			frmCustModPSSModMap = Nothing
			GC.Collect()
			GC.WaitForPendingFinalizers()
		End Try
	End Sub

	'*********************************************************
	Private Sub cmdAdminEditDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdminEditDevice.Click
		Dim frmMessEditDevices As frmMessEditDevices

		Try
			frmMessEditDevices = New frmMessEditDevices()
			frmMessEditDevices.ShowDialog()
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Customer Model PSS Model Mapping", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			frmMessEditDevices = Nothing
			GC.Collect()
			GC.WaitForPendingFinalizers()
		End Try
	End Sub

	'*********************************************************
	Private Sub cmdAdminLoadAMData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdminLoadAMData.Click
		Dim strFilePath As String = ""
		Dim booRefreshData As Boolean = False
		Dim i As Integer = 0

		Try
			If Me.dtpAdminLocChgDate.Text = "" Then
				MessageBox.Show("Please select Date.", "Load Data", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				Exit Sub
			End If

			Me.Enabled = False
			'*******************************************
			'Open File Dialog box
			'*******************************************
			Me.OpenFileDialog1.DefaultExt = "ptr"
			Me.OpenFileDialog1.FilterIndex = 1
			Me.OpenFileDialog1.FileName = "*.ptr"
			Me.OpenFileDialog1.ShowDialog()
			If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
				If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "ptr" Then
					MessageBox.Show("Incorrect file extension. It must be ""ptr"".", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
					Exit Sub
				End If
				strFilePath = Trim(Me.OpenFileDialog1.FileName)

				booRefreshData = Me.chkAdminRefreshData.Checked

				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

				'*****************************
				'Load Full File
				'*****************************
				i = GobjMessAdmin.LoadAMAbacusFullData(strFilePath, booRefreshData, Me.dtpAdminLocChgDate.Text)
				'*****************************
				'Load Daily File
				'*****************************
				i += GobjMessAdmin.LoadAMAbacusDataByLocChangeDtToTverdata(Me.dtpAdminLocChgDate.Text)
				'*****************************

				If i > 0 Then
					MessageBox.Show("Load completed.", "Load Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				End If
			Else
				MessageBox.Show("Please select a file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				Exit Sub
			End If

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Load File Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			Me.Enabled = True
			Cursor.Current = System.Windows.Forms.Cursors.Default
		End Try
	End Sub

	'*********************************************************
	Private Sub cmdAdminCreateCapcodeSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdminCreateCapcodeSheet.Click

		Try
			If Trim(txtAdminCapcodePrefix.Text) <> "" And (UCase(Trim(txtAdminCapcodePrefix.Text)) <> "E" And UCase(Trim(txtAdminCapcodePrefix.Text)) <> "A") Then
				MessageBox.Show("Invalid prefix. It must be either ""blank"", ""A"" or ""E"".", "Validate Capcode Prefix", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				Exit Sub
			End If

			If Trim(Me.txtAdminCapcodeLen.Text) = "" Or (Trim(txtAdminCapcodeLen.Text) <> "7" And Trim(txtAdminCapcodeLen.Text) <> "9") Then
				MessageBox.Show("Invalid capcode length. It must be either ""7"" or ""9"".", "Validate Capcode Length", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				Exit Sub
			End If

			If Trim(Me.txtAdminCapcodeRange.Text) = "" Or IsNumeric(Trim(Me.txtAdminCapcodeRange.Text)) = False Then
				MessageBox.Show("Invalid capcode range. It must be numeric.", "Validate Capcode Range", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				Exit Sub
			End If

			If Trim(Me.txtAdminStartNum.Text) = "" Or IsNumeric(Trim(Me.txtAdminStartNum.Text)) = False Then
				MessageBox.Show("Capcode start number must be digit.", "Validate Capcode Start Range", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				Exit Sub
			End If

			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			Me.Enabled = False

			Me.GobjMessAdmin.CreateCapcodeSheet(UCase(Trim(Me.txtAdminCapcodePrefix.Text)), _
									Trim(Me.txtAdminCapcodeLen.Text), _
									Trim(Me.txtAdminCapcodeRange.Text), _
									Trim(Me.txtAdminStartNum.Text))

			MessageBox.Show("Completed.", "Create Capcode Sheet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Create Capcode Sheet Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			Me.Enabled = True
			Cursor.Current = System.Windows.Forms.Cursors.Default
		End Try
	End Sub

	'*********************************************************
	Private Sub txtAdminCapcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdminStartNum.KeyDown, txtAdminCapcodeLen.KeyDown, txtAdminCapcodeRange.KeyDown, txtAdminCapcodePrefix.KeyDown

		Try
			If e.KeyValue = 13 Then
				If sender.name = Me.txtAdminCapcodePrefix.Name Then
					If Trim(txtAdminCapcodePrefix.Text) <> "" And (UCase(Trim(txtAdminCapcodePrefix.Text)) <> "E" And UCase(Trim(txtAdminCapcodePrefix.Text)) <> "A") Then
						MessageBox.Show("Invalid prefix. It must be either ""blank"", ""A"" or ""E"".", "Validate Capcode Prefix", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Exit Sub
					End If
					Me.txtAdminCapcodeLen.Focus()
				ElseIf sender.name = Me.txtAdminCapcodeLen.Name Then
					If Trim(txtAdminCapcodeLen.Text) = "" Then
						Exit Sub
					End If
					If Trim(txtAdminCapcodeLen.Text) <> "7" And Trim(txtAdminCapcodeLen.Text) <> "9" Then
						MessageBox.Show("Invalid capcode length. It must be either ""7"" or ""9"".", "Validate Capcode Length", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Exit Sub
					End If
					Me.txtAdminCapcodeRange.Focus()
				ElseIf sender.name = Me.txtAdminCapcodeRange.Name Then
					If Trim(Me.txtAdminCapcodeRange.Text) = "" Then
						Exit Sub
					End If
					If IsNumeric(Trim(Me.txtAdminCapcodeRange.Text)) = False Then
						MessageBox.Show("Invalid capcode range. It must be numeric.", "Validate Capcode Range", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Exit Sub
					End If
					Me.txtAdminStartNum.Focus()
				ElseIf sender.name = Me.txtAdminStartNum.Name Then
					If Trim(Me.txtAdminStartNum.Text) = "" Then
						Exit Sub
					End If
					If IsNumeric(Trim(Me.txtAdminStartNum.Text)) = False Then
						MessageBox.Show("Capcode start number must be digit.", "Validate Capcode Start Range", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
						Exit Sub
					End If
				End If
			End If
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Create Capcode Sheet Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Public Sub txtSN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyDown
		Dim iIsPSSWarrantied As Integer = 0
		Dim strSN As String
		Dim iDeviceID As Integer = 0
		Dim iLocID As Integer

		Try
			If e.KeyCode = Keys.Enter Then
				Me.lblWarrantiedNY.Text = ""
				Me.lblWarrantiedNY.ForeColor = Color.Black
				strSN = Me.txtSN.Text.ToUpper.Trim

				If strSN.Length > 0 Then
					If IsNothing(Me.GobjMessReceive) Then Me.GobjMessReceive = New PSS.Data.Buisness.MessReceive()

					'Must find location ID in query b/c Me.GiRecLocID could be zero.
					iIsPSSWarrantied = GobjMessReceive.IsPSSWarrantied(strSN, iDeviceID)

					If iIsPSSWarrantied = 1 Then iIsPSSWarrantied = GobjMessReceive.IsRepairedDevice(iDeviceID)

					If iIsPSSWarrantied = 0 Then
						Me.lblWarrantiedNY.Text = "NO"
						Me.lblWarrantiedNY.ForeColor = Color.Red
					Else
						Me.lblWarrantiedNY.Text = "YES"
						Me.lblWarrantiedNY.ForeColor = Color.Green
					End If

					Me.txtSN.SelectAll()
				End If
			ElseIf e.KeyCode = Keys.Space Then
				Me.txtSN.Text = ""
				Me.lblWarrantiedNY.Text = ""
				Me.lblWarrantiedNY.ForeColor = Color.Black
			End If
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Warranty Check Error")
		End Try
    End Sub

    '*********************************************************
    Private Sub btnAdminAMValidateData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminAMValidateData.Click
        Dim strFilePath As String = ""
        Dim i As Integer = 0

        Try
            '*******************************************
            'Open File Dialog box
            '*******************************************
            Me.OpenFileDialog1.DefaultExt = "xls"
            Me.OpenFileDialog1.FilterIndex = 1
            Me.OpenFileDialog1.FileName = "*.xls"
            Me.OpenFileDialog1.ShowDialog()
            If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
                If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
                    MessageBox.Show("Incorrect file extension. It must be ""xls"".", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                strFilePath = Trim(Me.OpenFileDialog1.FileName)

                Me.Enabled = False
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                '*****************************
                'Load Full File
                '*****************************
                i = GobjMessAdmin.VerifyDataFrSN(strFilePath)
                '*****************************

                'If i > 0 Then
                '    MessageBox.Show("Load completed.", "Load Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                'End If
            Else
                MessageBox.Show("Please select a file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Data Verification")
        Finally
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*********************************************************

#End Region

#Region "Receive"

	'*********************************************************
	Private Sub ClearPage_Receive(Optional ByVal iKeepCtrl As Integer = 0)
		If iKeepCtrl = 0 Then
			Me.cmbRecCust.SelectedValue = 0
			Me.txtRecWO.Text = ""
		End If

		If iKeepCtrl = 1 Then			 '1:keep customer, 2:Keep customer + wo
			Me.txtRecWO.Text = ""
		End If


		Me.lblRecLoc.Text = ""
		Me.lblRecAddress.Text = ""
		Me.lblRecPO.Text = ""
		Me.lblRecDevRcvdCnt.Text = "0"
		Me.lblRecScanCnt.Text = "0"
		Me.lblRecWOHasFile.Text = ""
		Me.cmbRecModel.Text = ""
		Me.cmbRecModel.SelectedValue = 0
		Me.cmbRecModel.Enabled = True
		Me.lblRecModelDesc.Text = ""
		Me.txtRecTrayMemo.Text = ""
		Me.txtRecTray_ID.Text = ""
		Me.txtRecDevSN.Text = ""

		Me.grdRecDevices.ClearFields()
		Me.grdRecDevices.DataSource = Nothing

		If Not IsNothing(Me.GdtRecDBGrid) Then
			Me.GdtRecDBGrid.Dispose()
			Me.GdtRecDBGrid = Nothing
		End If

		Me.GiRecWOID = 0
        Me.GiRecLocID = 0
        Me.GiRecLocID = 0
		Me.GiRecBaud_id = 0
        Me.GiRecFreq_id = 0
		Me.GiRecFreq_code = 0
		Me.GstrRecWO = ""
		Me.GstrRecFreqNumber = ""
		Me.GstrRecBaudRate = ""
		Me.GstrRecSKU = ""
		Me.GstrRecParentWO = ""
		Me.GiRecParentWO_ID = 0
	End Sub

	'*********************************************************
	Private Sub cmbRecCust_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRecCust.SelectionChangeCommitted
		Dim objMess As New PSS.Data.Buisness.Messaging()

		Try
			Me.lblModelActive.Text = ""
			Me.ClearPage_Receive(1)			 'clear very thing except customer

			If Me.cmbRecCust.SelectedValue > 0 Then
				Me.txtRecWO.Focus()
				NoNeedReceiveDBR()
			End If
		Catch ex As Exception
			MessageBox.Show(ex.ToString, " cmbRecCust_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			objMess = Nothing
		End Try
    End Sub

    '*********************************************************
    Private Sub NoNeedReceiveDBR()
        Dim objMess As New PSS.Data.Buisness.Messaging()

        Try
            btnRecDBRTray.Visible = True
            If Me.cmbRecCust.SelectedValue > 0 Then
                If IsMessagingCustomer(Me.cmbRecCust.SelectedValue) _
                    OrElse Me.cmbRecCust.SelectedValue = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                    btnRecDBRTray.Visible = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "NoNeedReceiveDBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            objMess = Nothing
        End Try
    End Sub

    Private Function IsMessagingCustomer(ByVal iCust_ID As Integer) As Boolean
        Dim objMess As New PSS.Data.Buisness.Messaging()
        Dim bRet As Boolean = False
        Dim arrCustIDs As String() = objMess.strMessCust_IDs.Split(New Char() {","c})
        Dim s As String

        Try

            For Each s In arrCustIDs
                If s.ToString.Trim = iCust_ID.ToString Then
                    bRet = True : Exit For
                End If
            Next
            If iCust_ID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then bRet = True

            Return bRet
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "IsMessagingCustomer", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            objMess = Nothing
        End Try
    End Function
    '*********************************************************
    Private Sub txtRecWO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRecWO.Leave

        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '**************************************
            'Required Field Validation
            If Me.cmbRecCust.SelectedValue = 0 Then
                MessageBox.Show("Please select a customer to get WO information.")
                Me.txtRecWO.Text = ""
                Me.cmbRecCust.Focus()
                Exit Sub
            End If
            If Trim(Me.txtRecWO.Text) = "" Then
                Exit Sub
            End If
            '**************************************
            If Me.GstrRecWO <> Trim(Me.txtRecWO.Text) Then
                Me.GetWOData_Receive()
            End If
            Me.cmbRecModel.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get WO Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ClearPage_Receive(1)
            Me.txtRecWO.Focus()
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*********************************************************
    Private Sub txtRecWO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecWO.KeyUp
        Try
            If e.KeyValue = 13 Then
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                '**************************************
                'Required Field Validation


                If Me.cmbRecCust.SelectedValue = 0 Then
                    MessageBox.Show("Please select a customer to get WO information.")
                    Me.txtRecWO.Text = ""
                    Me.cmbRecCust.Focus()
                    Exit Sub
                    End If
                If Trim(Me.txtRecWO.Text) = "" Then
                    Exit Sub
                    End If
                    '**************************************
                    'Reset global (keep customer + wo)
                    '**************************************
                Me.ClearPage_Receive(2)
                    '**************************************
                    'get customer wo data
                    '**************************************
                Me.GetWOData_Receive()
                    '**************************************
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get WO Info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ClearPage_Receive(1)
            Me.txtRecWO.Focus()
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*********************************************************
    Public Sub GetWOData_Receive()
        Dim dt As DataTable
        Dim dt1 As DataTable
        Dim R1 As DataRow

        Dim strStreetAddress1 As String = ""
        Dim strStreetAddress2 As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZIP As String = ""
        Dim strCountry As String = ""
        Dim iPO_ID As Integer = 0
        Dim strPO As String = ""
        Dim dtWoInfo As DataTable

        Try
            Me.lblRecWOHasFile.Text = ""
            '****************************
            'Get PSS WO info
            '****************************
            dt = GobjMessReceive.GetWOInfoOtherMessCustomer(Trim(Me.txtRecWO.Text))
            If dt.Rows.Count = 0 Then
                Me.WorkOrderException_Receive("This Work Order was not created in the system. Can not receive. Contact your supervisor.")
                Exit Sub
            ElseIf dt.Rows.Count > 1 Then
                Me.WorkOrderException_Receive("There are two instances of this Work Order in the system. Can not receive. Contact your supervisor.")
                Exit Sub
            Else
                R1 = dt.Rows(0)
                '**********************
                ''WO_ID
                If Not IsDBNull(R1("wo_id")) Then
                    GiRecWOID = R1("wo_id")
                Else
                    Me.WorkOrderException_Receive("There are two instances of this Work Order in the system. Can not receive. Contact your supervisor.")
                    Exit Sub
                End If
                '**********************
                ''Cust_ID
                If Not IsDBNull(R1("Cust_ID")) Then
                    GiRecCustID = R1("Cust_ID")
                Else
                    Me.WorkOrderException_Receive("Customer could not be determined. There may be a problem with the WO setup. Contact your supervisor.")
                    Exit Sub
                End If
                '**********************
                ''Customer
                Select Case GiRecCustID
                    Case PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID, _
                    PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID, _
                    PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID
                        Me.cmbRecCust.SelectedValue = GiRecCustID
                        '**********************
                        ''Loc_ID
                        If Not IsDBNull(R1("Loc_ID")) Then
                            GiRecLocID = R1("Loc_ID")
                        Else
                            Me.WorkOrderException_Receive("Location ID could not be determined. There may be a problem with the WO setup. Contact your supervisor.")
                            Exit Sub
                        End If
                        '**********************
                        ''Location
                        Me.lblRecLoc.Font = New Font("Arial", 7, FontStyle.Regular)
                        Me.lblRecLoc.BorderStyle = BorderStyle.FixedSingle
                        Me.lblRecLoc.ForeColor = Color.Black
                        If Not IsDBNull(R1("Loc_Name")) Then
                            Me.lblRecLoc.Text = R1("Loc_Name")
                            If Not IsDBNull(R1("Cust_ID")) AndAlso R1("Cust_ID") = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                                Me.lblRecLoc.BorderStyle = BorderStyle.None
                                Me.lblRecLoc.Font = New Font("Arial", 12, FontStyle.Bold) 'FontStyle.Bold Or FontStyle.Underline)
                                Me.lblRecLoc.ForeColor = Color.Red
                            End If
                        Else
                            Me.WorkOrderException_Receive("Location could not be determined. There may be a problem with the WO setup. Contact your supervisor.")
                            Exit Sub
                        End If
                        '**********************
                        ''Street Address
                        If Not IsDBNull(R1("Loc_Address1")) Then
                            strStreetAddress1 = R1("Loc_Address1")
                        Else
                            strStreetAddress1 = ""
                        End If
                        If Not IsDBNull(R1("Loc_Address2")) Then
                            strStreetAddress2 = R1("Loc_Address2")
                        Else
                            strStreetAddress2 = ""
                        End If
                        '**********************
                        ''City
                        If Not IsDBNull(R1("loc_city")) Then
                            strCity = R1("loc_city")
                        Else
                            strCity = ""
                        End If
                        '**********************
                        ''State
                        If Not IsDBNull(R1("state_short")) Then
                            strState = R1("state_short")
                        Else
                            strState = ""
                        End If
                        '**********************
                        ''Zip
                        If Not IsDBNull(R1("Loc_Zip")) Then
                            strZIP = R1("Loc_Zip")
                        Else
                            strZIP = ""
                        End If
                        '**********************
                        ''Country
                        If Not IsDBNull(R1("cntry_name")) Then
                            strCountry = R1("cntry_name")
                        Else
                            strCountry = ""
                        End If
                        '**********************
                        'address
                        Me.lblRecAddress.Text = strStreetAddress1 & " " & strStreetAddress2 & Environment.NewLine & strCity & ", " & strState & " " & strZIP & " " & strCountry
                        '**********************
                        ''WO Memo
                        If Not IsDBNull(R1("WO_Memo")) Then
                            Me.txtRecTrayMemo.Text = R1("WO_Memo")
                        Else
                            Me.txtRecTrayMemo.Text = ""
                        End If
                        '**********************
                        ''PO_ID
                        If Not IsDBNull(R1("PO_ID")) Then
                            If R1("PO_ID") > 0 Then
                                iPO_ID = R1("PO_ID")
                                '**********************
                                ''PO
                                If Not IsDBNull(R1("PO_Desc")) Then
                                    strPO = R1("PO_Desc")
                                Else
                                    strPO = ""
                                End If
                                '**********************
                                Me.lblRecPO.Text = iPO_ID & " - " & strPO
                            Else
                                Me.lblRecPO.Text = ""
                            End If
                        Else
                            Me.lblRecPO.Text = ""
                        End If

                        ''*******************************
                        '''WO Came with File or not?
                        If Not IsDBNull(R1("WO_CameWithFile")) Then
                            If R1("WO_CameWithFile") = 1 Then
                                Me.lblRecWOHasFile.Text = "YES"
                                Me.pnlRecFreqBaud.Visible = False
                            Else
                                Me.pnlRecFreqBaud.Visible = True
                                Me.lblRecWOHasFile.Text = "NO"
                            End If
                        Else
                            Me.pnlRecFreqBaud.Visible = True
                            Me.lblRecWOHasFile.Text = "NO"
                        End If

                        '******************************************
                        'Number of Devices Rcvd for the Work Order.
                        '******************************************
                        Me.lblRecDevRcvdCnt.Text = GobjMessReceive.GetWORcvdQty(GiRecWOID)
                        '******************************************
                        'Get Customer Work Order Data Information
                        '******************************************
                        If Me.cmbRecCust.SelectedValue = 1 Then
                            Me.PopulateUSAMobData_Receive()
                        Else
                            Me.PopulateCustWOData_Receive()
                        End If
                        '*******************************************
                        Me.GstrRecWO = Trim(Me.txtRecWO.Text)
                        Me.cmbRecModel.Focus()
                    Case Else
                        'for original customers
                        dt1 = GobjMessReceive.GetWOInfo(Trim(Me.txtRecWO.Text), Me.cmbRecCust.SelectedValue)
                        If dt1.Rows.Count = 0 Then
                            Me.WorkOrderException_Receive("This Work Order was not created in the system. Can not receive. Contact your supervisor.")
                            Exit Sub
                        ElseIf dt1.Rows.Count > 1 Then
                            Me.WorkOrderException_Receive("There are two instances of this Work Order in the system. Can not receive. Contact your supervisor.")
                            Exit Sub
                        Else
                            R1 = dt1.Rows(0)
                            '**********************
                            ''WO_ID
                            If Not IsDBNull(R1("wo_id")) Then
                                GiRecWOID = R1("wo_id")
                            Else
                                Me.WorkOrderException_Receive("There are two instances of this Work Order in the system. Can not receive. Contact your supervisor.")
                                Exit Sub
                            End If
                            '**********************
                            ''Loc_ID
                            If Not IsDBNull(R1("Loc_ID")) Then
                                GiRecLocID = R1("Loc_ID")
                            Else
                                Me.WorkOrderException_Receive("Location ID could not be determined. There may be a problem with the WO setup. Contact your supervisor.")
                                Exit Sub
                            End If

                            '**********************
                            ''Location
                            Me.lblRecLoc.Font = New Font("Arial", 7, FontStyle.Regular)
                            Me.lblRecLoc.BorderStyle = BorderStyle.FixedSingle
                            Me.lblRecLoc.ForeColor = Color.Black
                            If Not IsDBNull(R1("Loc_Name")) Then
                                Me.lblRecLoc.Text = R1("Loc_Name")
                                If Not IsDBNull(R1("Cust_ID")) AndAlso R1("Cust_ID") = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                                    Me.lblRecLoc.BorderStyle = BorderStyle.None
                                    Me.lblRecLoc.Font = New Font("Arial", 12, FontStyle.Bold) 'FontStyle.Bold Or FontStyle.Underline)
                                    Me.lblRecLoc.ForeColor = Color.Red
                                End If
                            Else
                                Me.WorkOrderException_Receive("Location could not be determined. There may be a problem with the WO setup. Contact your supervisor.")
                                Exit Sub
                            End If

                            '**********************
                            ''Street Address
                            If Not IsDBNull(R1("Loc_Address1")) Then
                                strStreetAddress1 = R1("Loc_Address1")
                            Else
                                strStreetAddress1 = ""
                            End If
                            If Not IsDBNull(R1("Loc_Address2")) Then
                                strStreetAddress2 = R1("Loc_Address2")
                            Else
                                strStreetAddress2 = ""
                            End If
                            '**********************
                            ''City
                            If Not IsDBNull(R1("loc_city")) Then
                                strCity = R1("loc_city")
                            Else
                                strCity = ""
                            End If
                            '**********************
                            ''State
                            If Not IsDBNull(R1("state_short")) Then
                                strState = R1("state_short")
                            Else
                                strState = ""
                            End If
                            '**********************
                            ''Zip
                            If Not IsDBNull(R1("Loc_Zip")) Then
                                strZIP = R1("Loc_Zip")
                            Else
                                strZIP = ""
                            End If
                            '**********************
                            ''Country
                            If Not IsDBNull(R1("cntry_name")) Then
                                strCountry = R1("cntry_name")
                            Else
                                strCountry = ""
                            End If
                            '**********************
                            'address
                            Me.lblRecAddress.Text = strStreetAddress1 & " " & strStreetAddress2 & Environment.NewLine & strCity & ", " & strState & " " & strZIP & " " & strCountry
                            '**********************
                            ''WO Memo
                            If Not IsDBNull(R1("WO_Memo")) Then
                                Me.txtRecTrayMemo.Text = R1("WO_Memo")
                            Else
                                Me.txtRecTrayMemo.Text = ""
                            End If
                            '**********************
                            ''PO_ID
                            If Not IsDBNull(R1("PO_ID")) Then
                                If R1("PO_ID") > 0 Then
                                    iPO_ID = R1("PO_ID")
                                    '**********************
                                    ''PO
                                    If Not IsDBNull(R1("PO_Desc")) Then
                                        strPO = R1("PO_Desc")
                                    Else
                                        strPO = ""
                                    End If
                                    '**********************
                                    Me.lblRecPO.Text = iPO_ID & " - " & strPO
                                Else
                                    Me.lblRecPO.Text = ""
                                End If
                            Else
                                Me.lblRecPO.Text = ""
                            End If

                            ''*******************************
                            '''WO Came with File or not?
                            If Not IsDBNull(R1("WO_CameWithFile")) Then
                                If R1("WO_CameWithFile") = 1 Then
                                    Me.lblRecWOHasFile.Text = "YES"
                                    Me.pnlRecFreqBaud.Visible = False
                                Else
                                    Me.pnlRecFreqBaud.Visible = True
                                    Me.lblRecWOHasFile.Text = "NO"
                                End If
                            Else
                                Me.pnlRecFreqBaud.Visible = True
                                Me.lblRecWOHasFile.Text = "NO"
                            End If

                            '******************************************
                            'Number of Devices Rcvd for the Work Order.
                            '******************************************
                            Me.lblRecDevRcvdCnt.Text = GobjMessReceive.GetWORcvdQty(GiRecWOID)
                            '******************************************
                            'Get Customer Work Order Data Information
                            '******************************************
                            If Me.cmbRecCust.SelectedValue = 1 Then
                                Me.PopulateUSAMobData_Receive()
                            Else
                                Me.PopulateCustWOData_Receive()
                            End If
                            '*******************************************
                            Me.GstrRecWO = Trim(Me.txtRecWO.Text)
                            Me.cmbRecModel.Focus()
                        End If
                End Select
            End If
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If

            If Not IsNothing(dtWoInfo) Then
                dtWoInfo.Dispose()
                dtWoInfo = Nothing
            End If
        End Try
    End Sub

    Private Sub WorkOrderException_Receive(ByVal strMsg As String)
        Try
            MessageBox.Show(strMsg, "Get Work Order Data", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.ClearPage_Receive(1)
            Me.txtRecWO.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub PopulateUSAMobData_Receive()
        Dim R1, R2 As DataRow
        Dim dt1 As DataTable
        Dim objMessAd As New PSS.Data.Buisness.MessAdmin()

        Try
            dt1 = objMessAd.GetUSAMobWOInfo(Trim(Me.txtRecWO.Text))

            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)

                '******************************************
                'USA SKU,USA Freq and Baud Rate
                If Not IsDBNull(R1("USA_FinishedGoodsSKU")) Then
                    Me.GstrRecSKU = Trim(R1("USA_FinishedGoodsSKU"))

                    If Trim(R1("USA_FinishedGoodsSKU")) <> "" Then
                        'Freq
                        R2 = Me.GobjMessReceive.GetFreqFromSKU(Trim(R1("USA_FinishedGoodsSKU")))
                        If Not IsNothing(R2) Then
                            Me.GiRecFreq_id = R2("freq_id")
                            Me.GiRecFreq_code = R2("freq_MotoCode")
                            Me.GstrRecFreqNumber = R2("freq_Number")
                        Else
                            Me.GiRecFreq_id = 0
                            Me.GiRecFreq_code = 0
                            Me.GstrRecFreqNumber = ""
                        End If

                        'Baud Rate
                        Me.GstrRecBaudRate = Me.GobjMessReceive.CreateBaudRateFromSKU(Trim(R1("USA_FinishedGoodsSKU")))
                        If Trim(Me.GstrRecBaudRate) <> "" Then
                            If Me.GstrRecBaudRate <> "" Then
                                Me.GiRecBaud_id = Me.GobjMessReceive.GetBaudID(Trim(Me.GstrRecBaudRate))
                            Else
                                Me.GiRecBaud_id = 0
                            End If
                        Else
                            Me.GiRecBaud_id = 0
                        End If

                    Else
                        Me.GstrRecBaudRate = ""
                        Me.GiRecBaud_id = 0
                        Me.GiRecFreq_id = 0
                        Me.GiRecFreq_code = 0
                    End If
                Else
                    Me.GstrRecSKU = ""
                    Me.GstrRecBaudRate = ""
                    Me.GiRecBaud_id = 0
                    Me.GiRecFreq_id = 0
                    Me.GiRecFreq_code = 0
                End If

                ''*******************************
                '''WO Came with File or not?
                If Not IsDBNull(R1("Came With File?")) Then
                    If CInt(Trim(R1("Came With File?"))) = 1 Then
                        Me.lblRecWOHasFile.Text = "YES"
                    Else
                        Me.lblRecWOHasFile.Text = "NO"
                    End If
                Else
                    Me.lblRecWOHasFile.Text = "NO"
                End If
                ''*******************************
            Else
                Me.WorkOrderException_Receive("Customer Data is missing for this WO. Please contact your supervisor.")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            objMessAd = Nothing
            R1 = Nothing
            R2 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub PopulateCustWOData_Receive()
        Dim R1, drFreq As DataRow
        Dim dt1, dt2 As DataTable
        Dim objMessAd As New PSS.Data.Buisness.MessAdmin()

        Try
            dt1 = objMessAd.GetMiscCustWOInfo(Trim(Me.txtRecWO.Text), Me.cmbRecCust.SelectedValue)

            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)

                '*****************************
                'check if wo is child wo
                '*****************************
                If Not IsDBNull(R1("parent_mmw_id")) Then
                    dt2 = objMessAd.GetParentMiscWO(R1("parent_mmw_id"), Me.cmbRecCust.SelectedValue)
                    If dt2.Rows.Count > 0 Then
                        Me.GiRecParentWO_ID = dt2.Rows(0)("mmw_id")
                        Me.GstrRecParentWO = dt2.Rows(0)("mmw_wo")
                    Else
                        Me.WorkOrderException_Receive("Parent WO is missing for this WO. Please contact your supervisor.")
                        Exit Sub
                    End If
                End If

                '******************************************
                'SKU and Baud Rate
                If Not IsDBNull(R1("mmw_sku")) Then
                    Me.GstrRecSKU = Trim(R1("mmw_sku"))
                    If Trim(Trim(R1("mmw_sku"))) <> "" Then
                        Me.GstrRecBaudRate = Me.GobjMessReceive.CreateBaudRateFromSKU(Trim(R1("mmw_sku")))
                        If Me.GstrRecBaudRate <> "" Then
                            Me.GiRecBaud_id = Me.GobjMessReceive.GetBaudID(Trim(Me.GstrRecBaudRate))
                        Else
                            Me.GiRecBaud_id = 0
                        End If
                    Else
                        Me.GstrRecBaudRate = ""
                        Me.GiRecBaud_id = 0
                    End If
                Else
                    Me.GstrRecSKU = ""
                    Me.GstrRecBaudRate = ""
                    Me.GiRecBaud_id = 0
                End If

                '******************************************
                'Freq 
                If Not IsDBNull(R1("mmw_freq")) Then
                    Me.GstrRecFreqNumber = Trim(R1("mmw_freq"))
                    If Trim(R1("mmw_freq")) <> "" Then
                        drFreq = GobjMessReceive.GetFreqInfo(Trim(R1("mmw_freq")))
                        If Not IsNothing(drFreq) Then
                            Me.GiRecFreq_id = drFreq("freq_id")
                            Me.GiRecFreq_code = drFreq("freq_MotoCode")
                        Else
                            Me.GiRecFreq_id = 0
                            Me.GiRecFreq_code = 0
                        End If
                    Else
                        Me.GiRecFreq_id = 0
                        Me.GiRecFreq_code = 0
                    End If
                Else
                    Me.GstrRecFreqNumber = ""
                    Me.GiRecFreq_id = 0
                    Me.GiRecFreq_code = 0
                End If

                '******************************************
                'WO has data file from customer
                If Not IsDBNull(R1("mmw_CameWithFileFlag")) Then
                    If CInt(Trim(R1("mmw_CameWithFileFlag"))) = 1 Then
                        Me.lblRecWOHasFile.Text = "YES"
                    Else
                        Me.lblRecWOHasFile.Text = "NO"
                    End If
                Else
                    Me.lblRecWOHasFile.Text = "NO"
                End If
                '******************************************
            Else
                Me.WorkOrderException_Receive("Customer Data is missing for this WO. Please contact your supervisor.")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            objMessAd = Nothing
            R1 = Nothing
            drFreq = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            If Not IsNothing(dt2) Then
                dt2.Dispose()
                dt2 = Nothing
            End If
        End Try
    End Sub

    Private Sub ReceiveOtherMessCustomerSN()
        Dim booSNExisted As Boolean = False
        Dim _sn As String = txtRecDevSN.Text.ToUpper()
        Dim _model_id As Integer = cmbRecModel.SelectedValue()
        Dim objSkyTel As New SkyTel()
        Dim strCustomerOfDupSN As String = ""

        Try
            If Trim(Me.txtRecDevSN.Text) = "" Then
                Exit Sub
            End If
            '*********************************************
            'validate customer,Model and tray qty
            '*********************************************
            If Me.cmbRecCust.SelectedValue = 0 Then
                Me.cmbRecCust.Focus()
                MessageBox.Show("Please select Customer.")
                Exit Sub
            End If

            If Me.cmbRecModel.SelectedValue = 0 Then
                MessageBox.Show("Please select model.", "Validate Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.VerifySNPatternBasedOnModel() = False Then
                Exit Sub
            End If
            If CInt(Trim(Me.lblRecScanCnt.Text)) >= 25 Then
                MessageBox.Show("Max. number of devices in a tray is 25.", "Validate Tray Quantity", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.lblRecWOHasFile.Text = "YES" Then
                MessageBox.Show("This customer cannot have a Work Order File", "Validate Work Order", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End If

            ' IF THIS DEVICE HAS OPEN LINES ON A DIFFERENT WORK ORDER PROMPT FOR THEM TO BE REMOVED.
            Dim _dt1 As New DataTable()
            _dt1 = Me.GobjMessReceive.IsDeviceExisting(txtRecWO.Text, Trim(Me.txtRecDevSN.Text))
            Dim dr As DataRow
            For Each dr In _dt1.Rows
                If dr("wo_custwo").ToString() = txtRecWO.Text Then
                    MessageBox.Show("This item has already been received for this Work Order.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    If Not AddToOpenLineQueue(dr) Then
                        MessageBox.Show("This item cannot be received while it has open lines and has been added to the Open Line Queue.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
            Next dr

            If objSkyTel.IsAmericanMessagingSN_InWIP_AllCustomers(Me.txtRecDevSN.Text.Trim, strCustomerOfDupSN) = True Then
                MessageBox.Show("S/N '" & Me.txtSN.Text.Trim.ToUpper & "' can't be received!" & Environment.NewLine & "It exists in WIP and owned by customer(s): " & strCustomerOfDupSN, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'If Not Me.lblModelActive.Text.Trim.ToUpper = "Active".ToUpper AndAlso Not Me.lblModelActive.Text.Trim.ToUpper = "inactive".ToUpper Then
            'MessageBox.Show("Can't determine if model is active or inactive.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'Exit Sub
            'End If

            ' CHECK CAPCODE 
            If txtRecCapCode.Text = "" Then
                MessageBox.Show("A valid Capcode must be entered.", "Validate Capcode", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                txtRecCapCode.Focus()
                Exit Sub
            End If

            ' CHECK FOR DBR/NER PREVIOUS TRANSACTION ON THIS SN.
            If HasDbrNerTransaction(_sn, _model_id) Then
                MessageBox.Show("This device has previously been marked as DBR or NER.  Please turn it in to the manager for further review.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '*********************************************
            'add new device
            '*********************************************
            ProcessSN_Receive(Me.cmbRecCust.SelectedValue)
            '*********************************************
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtRecDevSN.Text = ""
        End Try
    End Sub

    Private Sub txtRecDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecDevSN.KeyUp
        Dim booSNExisted As Boolean = False
        Dim _sn As String = txtRecDevSN.Text.ToUpper()
        Dim _model_id As Integer = cmbRecModel.SelectedValue()
        If e.KeyValue = 13 Then
            Try
                If Trim(Me.txtRecDevSN.Text) = "" Then
                    Exit Sub
                End If
                '*********************************************
                'validate customer,Model and tray qty
                '*********************************************
                If Me.cmbRecCust.SelectedValue = 0 Then
                    Me.cmbRecCust.Focus()
                    MessageBox.Show("Please select Customer.")
                    Exit Sub
                End If
                'Other Mess Customers
                Select Case Me.cmbRecCust.SelectedValue
                    Case PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID, _
                    PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID, _
                    PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID
                        Me.ReceiveOtherMessCustomerSN()
                        Exit Sub
                End Select

                'Normal Mess Customers
                'Not allowed when Aquis, Moriss Comm, Propage, and Cook Pager
                Select Case Me.cmbRecCust.SelectedValue
                    Case 444, 2507, 2508, 2563
                        Me.cmbRecCust.Focus()
                        MessageBox.Show("'" & Me.cmbRecCust.SelectedText & "' is not allowed to receive here. Please use 'Receiving' screen under this customer.", "Customer Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                End Select
                If Me.cmbRecModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Validate Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If Me.VerifySNPatternBasedOnModel() = False Then
                    Exit Sub
                End If
                If CInt(Trim(Me.lblRecScanCnt.Text)) >= 25 Then
                    MessageBox.Show("Max. number of devices in a tray is 25.", "Validate Tray Quantity", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                If Me.lblRecWOHasFile.Text <> "YES" Then
                    If Me.cboRecFreq.SelectedValue = 0 Then
                        MessageBox.Show("Please select frequency.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboRecFreq.SelectAll() : Me.cboRecFreq.SelectAll() : Exit Sub
                    ElseIf Me.cboRecBaud.SelectedValue = 0 Then
                        MessageBox.Show("Please select baud rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboRecBaud.SelectAll() : Me.cboRecBaud.SelectAll() : Exit Sub
                    ElseIf Me.cmbRecCust.SelectedValue = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID _
                           AndAlso Trim(Me.txtRecCapCode.Text).Length = 0 Then
                        MessageBox.Show("Please enter capcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtRecCapCode.SelectAll() : Me.txtRecCapCode.SelectAll() : Me.txtRecCapCode.Focus() : Exit Sub
                    End If
                    Me.cboRecFreq.Enabled = True
                    Me.cboRecBaud.Enabled = True
                End If
                ' IF THIS DEVICE HAS OPEN LINES ON A DIFFERENT WORK ORDER PROMPT FOR THEM TO BE REMOVED.
                Dim _dt1 As New DataTable()
                _dt1 = Me.GobjMessReceive.IsDeviceExisting(txtRecWO.Text, Trim(Me.txtRecDevSN.Text))
                Dim dr As DataRow
                For Each dr In _dt1.Rows
                    If dr("wo_custwo").ToString() = txtRecWO.Text Then
                        MessageBox.Show("This item has already been received for this Work Order.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Else
                        If Not AddToOpenLineQueue(dr) Then
                            MessageBox.Show("This item cannot be received while it has open lines and has been added to the Open Line Queue.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                Next dr
                '*******************************************************
                '2:: Check if device exist in tdevice within same wo
                '*******************************************************
                'Check SN duplicates (Open WIP) for all American Messaging customers
                Select Case Me.cmbRecCust.SelectedValue
                    'Case 14, 444, 2507, 2508, 2563       'in fact, only AMS cust_id 14 (because only ASM is allowed here)
                Case PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID, _
                        PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID, _
                        PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID
                        Dim objSkyTel As New SkyTel()
                        Dim strCustomerOfDupSN As String = ""
                        If objSkyTel.IsAmericanMessagingSN_InWIP_AllCustomers(Me.txtRecDevSN.Text.Trim, strCustomerOfDupSN) = True Then
                            MessageBox.Show("S/N '" & Me.txtSN.Text.Trim.ToUpper & "' can't be received!" & Environment.NewLine & "It exists in WIP and owned by customer(s): " & strCustomerOfDupSN, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        If Not Me.lblModelActive.Text.Trim.ToUpper = "Active".ToUpper AndAlso Not Me.lblModelActive.Text.Trim.ToUpper = "inactive".ToUpper Then
                            MessageBox.Show("Can't determine if model is active or inactive.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                End Select
                ' CHECK EQUIPMENT TYPE OF THE DEVICES MODEL FOR DEVICE IN A FILE.
                If Not Me.cmbRecCust.SelectedValue = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                    If Me.lblRecWOHasFile.Text = "YES" Then
                        If Not IsEquipmentTypeCorrect(_sn, _model_id) Then
                            ''MessageBox.Show("This device does not have the correct equipment type for the selected model.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            lblEquipTypeMismatch.Visible = True
                            txtRecDevSN.Text = ""
                            Exit Sub
                        End If
                    End If
                End If

                'If Me.lblRecWOHasFile.Text = "YES" Then
                '    If Not IsEquipmentTypeCorrect(_sn, _model_id) Then
                '        ''MessageBox.Show("This device does not have the correct equipment type for the selected model.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        lblEquipTypeMismatch.Visible = True
                '        txtRecDevSN.Text = ""
                '        Exit Sub
                '    End If
                'End If
                ' CHECK FOR DBR/NER PREVIOUS TRANSACTION ON THIS SN.
                If HasDbrNerTransaction(_sn, _model_id) Then
                    MessageBox.Show("This device has previously been marked as DBR or NER.  Please turn it in to the manager for further review.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                '*********************************************
                'add new device
                '*********************************************
                ProcessSN_Receive(Me.cmbRecCust.SelectedValue)
                '*********************************************
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.txtRecDevSN.Text = ""
            End Try
        End If
    End Sub

    Private Function AddToOpenLineQueue(ByRef dr As DataRow) As Boolean
        'Dim _removed As Boolean = False
        Dim _msg As String
        _msg = "The following Open Line exists under a different Work Order."
        _msg &= vbCrLf
        _msg &= vbCrLf & vbTab & "Serial Number: " & dr("device_sn").ToString()
        _msg &= vbCrLf & vbTab & "Customer Work Order: " & dr("wo_custwo").ToString()
        _msg &= vbCrLf & vbTab & "Date Received: " & dr("device_daterec").ToString()
        _msg &= vbCrLf & vbTab & "WIP Owner: " & dr("wipowner_desc").ToString()
        _msg &= vbCrLf
        _msg &= vbCrLf
        _msg &= "This Serial Number is being added to the Open Line Queue to be worked by the appropriate person.  "
        _msg &= "Please add this device to a box for the person researching Open Lines."
        MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Dim _olq As New Data.Buisness.MsgOpenLinesQueue()
        _olq.device_sn = dr("device_sn").ToString()
        _olq.ApplyChanges()
        Return True
    End Function

    '*********************************************************
    Private Function VerifySNPatternBasedOnModel() As Boolean
        Dim booResult As Boolean = True

        Try
            Select Case Me.cmbRecModel.SelectedValue
                Case 2     'AG: SN start with 58
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("58") = False And Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("AG") = False Then
                        If MessageBox.Show("SN of AG must start with ""58"" or ""AG"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 3     'AE: SN must start with 56 or AE
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("56") = False And Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("AE") = False Then
                        If MessageBox.Show("SN of AE must start with ""56"" or ""AE"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 7     'BF: SN must start with PE1 or 077
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("PE") = False And Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("077") = False And Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("R1") = False Then
                        If MessageBox.Show("SN of BF must start with ""PE"", ""077"" or ""R1"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 19    'L3: SN must start with 15
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("15") = False Then
                        If MessageBox.Show("SN of L3 must start with ""15"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 276    'ST800-: SN must start with SF
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("SF") = False And Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("SP") = False Then
                        If MessageBox.Show("SN of ST800- must start with ""SF"" or ""SP"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 1113    'ST800-P: SN must start with S8P
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("S8P") = False And Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("SP") = False Then
                        If MessageBox.Show("SN of ST800-P must start with ""S8P"" or ""SP"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 1036    'Z4-Z400 Sun Telecom: SN must start with ZF
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("ZF") = False Then
                        If MessageBox.Show("SN of Z4-Z400 Sun Telecom must start with ""ZF"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 773    'T3-Titan Sun Telecom: SN must start with T3
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("T3") = False Then
                        If MessageBox.Show("SN of T3 must start with ""T3"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 786, 807    'ALPE-Alpha Elite and ALPG-Alpha Gold: SN must start with ADV
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("ADV") = False And Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("ADN") = False Then
                        If MessageBox.Show("SN of ALPE-Alpha Elite and ALPG-Alpha Gold must start with ""ADV"" or ""ADN"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 86    'B8-BR850
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("12") = False Then
                        If MessageBox.Show("SN of B8-BR850 must start with ""12"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case 87, 1110, 808    'T9-Talkabout 900 2-Way, T9Refresh-Talkabout 900 and U-P900: SN must start with 36
                    If Me.txtRecDevSN.Text.Trim.ToUpper.StartsWith("36") = False Then
                        If MessageBox.Show("SN of 2-Way must start with ""36"". Would you like to receive it anyway?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then booResult = False
                    End If
                Case Else
            End Select

            Return booResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '*********************************************************
    Private Sub ProcessSN_Receive(ByVal iCust_ID As Integer)
        Dim booDuplicate As Boolean = False

        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '**********************************
            'Create new datatable 
            '**********************************
            If IsNothing(Me.GdtRecDBGrid) Then
                Me.CreateNewTable_Receive()
            End If
            '*********************************************
            '1:: Check Duplicate
            '*********************************************
            booDuplicate = IsSNDuplicateInList_Receive(Trim(Me.txtRecDevSN.Text))
            If booDuplicate = True Then
                MessageBox.Show("This device is already scanned in. Try another one.", "Scan in Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.cmbRecCust.SelectedValue = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID _
               AndAlso IsCapCodeDuplicateInList_Receive(Trim(Me.txtRecCapCode.Text)) Then
                MessageBox.Show("This capcode is already in the list. Please check the capcode and try again", "Dup Capcode", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            '*******************************************************
            '2::Create a new insert record for scanned device
            '*******************************************************
            Select Case Me.cmbRecCust.SelectedValue
                Case PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID, _
                PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID, _
                PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID
                    CreateNewRecordOtherMessCust_Receive()
                Case PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID, _
                PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID, _
                PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID
                    CreateNewRecord_Receive()
            End Select

            If Me.lblRecWOHasFile.Text <> "YES" Then
                Me.txtRecCapCode.Text = ""
            Else
                Me.txtRecCapCode.Text = ""
                Me.cboRecFreq.SelectedValue = 0
                Me.cboRecBaud.SelectedValue = 0
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*********************************************************
    Private Sub CreateNewRecordOtherMessCust_Receive()
        Dim drNewRow As DataRow
        Dim booCreateNewEntry As Boolean = False
        Dim _sn As String = UCase(Trim(Me.txtRecDevSN.Text))

        Try
            drNewRow = Me.GdtRecDBGrid.NewRow()

            drNewRow("Serial Number") = UCase(Trim(Me.txtRecDevSN.Text))
            drNewRow("Tray_id") = 0
            drNewRow("Model_id") = Me.cmbRecModel.SelectedValue
            drNewRow("Count") = Me.GdtRecDBGrid.Rows.Count + 1

            booCreateNewEntry = Me.CreateNewRecord_WOData_Receive(drNewRow)

            '***************************
            'adding new row to datatable
            '***************************
            If booCreateNewEntry = True Then

                Me.GdtRecDBGrid.Rows.Add(drNewRow)
                Me.GdtRecDBGrid.AcceptChanges()

                ''***************************
                'display to datagrid
                ''***************************
                Me.grdRecDevices.ClearFields()
                Me.grdRecDevices.DataSource = Nothing
                If Me.GdtRecDBGrid.Rows.Count > 0 Then
                    Me.grdRecDevices.DataSource = Me.GdtRecDBGrid.DefaultView
                    SetGridProperties_Receive()
                    Me.grdRecDevices.MoveLast()
                    Me.lblRecScanCnt.Text = Me.GdtRecDBGrid.Rows.Count
                End If
            End If
            ''***************************

        Catch ex As Exception
            Throw ex
        Finally
            drNewRow = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub CreateNewRecord_Receive()
        Dim drNewRow As DataRow
        Dim booCreateNewEntry As Boolean = False
        Dim _sn As String = UCase(Trim(Me.txtRecDevSN.Text))
        Dim _model_id = Me.cmbRecModel.SelectedValue
        Try
            drNewRow = Me.GdtRecDBGrid.NewRow()

            drNewRow("Serial Number") = UCase(Trim(Me.txtRecDevSN.Text))
            drNewRow("Tray_id") = 0
            drNewRow("Count") = Me.GdtRecDBGrid.Rows.Count + 1

            '*************************************************
            'Get Device Information if wo came with data file
            '*************************************************
            If Me.lblRecWOHasFile.Text = "YES" Then

                Select Case Me.cmbRecCust.SelectedValue

                    Case 14
                        '*****************************************
                        'American messaging, American Messaging II 
                        ' and American Messaging(SBC)
                        '***************************************** 
                        booCreateNewEntry = CreateNewRecord_Tverdata_Receive(drNewRow)
                        'If booCreateNewEntry Then
                        '	ValidateEquipType(_sn, model_id)
                        'End If

                    Case Else
                        '**********************************
                        'other customer use workorder data
                        '**********************************
                        booCreateNewEntry = Me.CreateNewRecord_WOData_Receive(drNewRow)
                End Select
            Else
                '*************************************************
                'No data file come with wo then use workorder data
                '*************************************************
                booCreateNewEntry = Me.CreateNewRecord_WOData_Receive(drNewRow)
            End If


            '***************************
            'adding new row to datatable
            '***************************
            If booCreateNewEntry = True Then
                'all unit must have the same frequency
                If GdtRecDBGrid.Rows.Count > 0 AndAlso GdtRecDBGrid.Rows(0)("Frequency").ToString <> drNewRow("Frequency").ToString Then
                    Throw New Exception("The frequency (" & drNewRow("Frequency").ToString & ") of this unit does not math with unit(s) on the list.")
                End If

                Me.GdtRecDBGrid.Rows.Add(drNewRow)
                Me.GdtRecDBGrid.AcceptChanges()

                ''***************************
                'display to datagrid
                ''***************************
                Me.grdRecDevices.ClearFields()
                Me.grdRecDevices.DataSource = Nothing
                If Me.GdtRecDBGrid.Rows.Count > 0 Then
                    Me.grdRecDevices.DataSource = Me.GdtRecDBGrid.DefaultView
                    SetGridProperties_Receive()
                    Me.grdRecDevices.MoveLast()
                    Me.lblRecScanCnt.Text = Me.GdtRecDBGrid.Rows.Count
                End If
            End If
            ''***************************

        Catch ex As Exception
            Throw ex
        Finally
            drNewRow = Nothing
        End Try
    End Sub

    Private Function CreateNewRecord_WOData_Receive(ByRef drNewRow As DataRow) As Boolean
        Dim booResult As Boolean = True

        Try
            drNewRow("Cap Code") = Me.txtRecCapCode.Text.Trim.ToUpper

            If Me.GiRecFreq_id > 0 Then
                drNewRow("Freq_id") = Me.GiRecFreq_id
                drNewRow("Frequency") = Trim(Me.GstrRecFreqNumber)
                If Not IsDBNull(Me.cboRecBaud.DataSource.Table.select("Freq_ID = " & Me.cboRecFreq.SelectedValue)(0)("freq_MotoCode")) Then drNewRow("freq_MotoCode") = Me.cboRecBaud.DataSource.Table.select("Freq_ID = " & Me.cboRecFreq.SelectedValue)(0)("freq_MotoCode")
            Else
                drNewRow("Freq_id") = Me.cboRecFreq.SelectedValue
                drNewRow("Frequency") = Me.cboRecFreq.Text.Trim
                drNewRow("freq_MotoCode") = Me.GiRecFreq_code
            End If

            If Me.GiRecBaud_id = 0 Then
                drNewRow("Baud_id") = Me.cboRecBaud.SelectedValue
                drNewRow("Baud Rate") = UCase(Trim(Me.cboRecBaud.Text))
                drNewRow("SKU") = Me.cboRecBaud.DataSource.Table.select("Baud_id = " & Me.cboRecBaud.SelectedValue)(0)("am_sku")
            Else
                drNewRow("Baud_id") = Me.GiRecBaud_id
                drNewRow("Baud Rate") = UCase(Trim(Me.GstrRecBaudRate))
                drNewRow("SKU") = UCase(Trim(Me.GstrRecSKU))
            End If

            Select Case Me.cmbRecCust.SelectedValue
                Case PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID, _
                PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID, _
                PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID
                    drNewRow("Model_id") = Me.cmbRecModel.SelectedValue
                    drNewRow("Model_desc") = Me.cmbRecModel.Text.Trim
            End Select


            drNewRow("Tverdata_TransID") = 0
            drNewRow("Came With File?") = "NO"

            Return booResult
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CreateNewRecord_Tverdata_Receive(ByRef drNewRow As DataRow) As Boolean
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim drFreq As DataRow
        Dim booResult As Boolean = False

        Try
            '*****************************************
            'American messaging, American Messaging II 
            ' and American Messaging(SBC)
            '*****************************************
            If Me.GiRecParentWO_ID = 0 Then
                dt1 = Me.GobjMessReceive.GetMessDevInfo_Tverdata(UCase(Trim(Me.txtRecWO.Text)), UCase(Trim(Me.txtRecDevSN.Text)))
            Else
                dt1 = Me.GobjMessReceive.GetMessDevInfo_Tverdata(UCase(Trim(Me.GstrRecParentWO)), UCase(Trim(Me.txtRecDevSN.Text)))
            End If

            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)

                'If R1("RcvdFlag") = 1 Then
                '    MessageBox.Show("The received flag of this device showing that the device had already been received.", "Create New Entry", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Return booResult
                'End If

                '*****************
                'Came With File?
                '*****************
                drNewRow("Came With File?") = "YES"

                '*****************
                'capcode
                '*****************
                If Not IsDBNull(R1("Device_CapCode")) Then
                    drNewRow("Cap Code") = UCase(Trim(R1("Device_CapCode")))
                Else
                    drNewRow("Cap Code") = ""
                End If

                '*****************
                'Frequency
                '*****************
                If Not IsDBNull(R1("Device_Freq")) Then
                    drNewRow("Frequency") = Trim(R1("Device_Freq"))
                    drFreq = Me.GobjMessReceive.GetFreqInfo(Trim(R1("Device_Freq")))
                    If Not IsNothing(drFreq) Then
                        drNewRow("Freq_id") = Trim(drFreq("freq_id"))
                        drNewRow("freq_MotoCode") = Trim(drFreq("freq_MotoCode"))
                    Else
                        drNewRow("Freq_id") = 0
                        drNewRow("freq_MotoCode") = 0
                    End If
                Else
                    drNewRow("Frequency") = Trim(Me.GstrRecFreqNumber)
                    drNewRow("Freq_id") = Me.GiRecFreq_id
                    drNewRow("freq_MotoCode") = Me.GiRecFreq_code
                End If

                '*****************
                'SKU
                '*****************
                If Not IsDBNull(R1("SKU_Number")) Then
                    drNewRow("SKU") = UCase(Trim(R1("SKU_Number")))

                    drNewRow("Baud Rate") = UCase(Trim(Me.GobjMessReceive.CreateBaudRateFromSKU(Trim(R1("SKU_Number")))))
                    If drNewRow("Baud Rate") <> "" Then
                        drNewRow("Baud_id") = Me.GobjMessReceive.GetBaudID(drNewRow("Baud Rate"))
                    Else
                        drNewRow("Baud_id") = 0
                    End If
                Else
                    drNewRow("SKU") = UCase(Trim(Me.GstrRecSKU))
                    drNewRow("Baud Rate") = UCase(Trim(Me.GstrRecBaudRate))
                    drNewRow("Baud_id") = Me.GiRecBaud_id
                End If

                '*****************
                'Tverdata.Tran_ID
                '*****************
                If Not IsDBNull(R1("Trans_ID")) Then
                    drNewRow("Tverdata_TransID") = Trim(R1("Trans_ID"))
                Else
                    drNewRow("Tverdata_TransID") = 0
                End If
                '*****************








                booResult = True
            Else
                '***********************************************
                'SN does not exist in tverdata then use wo data
                '***********************************************
                MessageBox.Show("Device does not have data file. Can not receive.", "Validate Device's Data", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                booResult = False
                'booResult = Me.CreateNewRecord_WOData_Receive(drNewRow)
            End If

            Return booResult
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            R1 = Nothing
            drFreq = Nothing
        End Try
    End Function

    '*********************************************************
    Private Sub CreateNewTable_Receive()
        Dim ColNew As DataColumn

        Try
            If Not IsNothing(Me.GdtRecDBGrid) Then
                Me.GdtRecDBGrid.Dispose()
                Me.GdtRecDBGrid = Nothing
            End If

            Me.GdtRecDBGrid = New DataTable()

            ColNew = New DataColumn("Count")
            ColNew.DataType = System.Type.GetType("System.Int32")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            ColNew = New DataColumn("Serial Number")
            ColNew.DataType = System.Type.GetType("System.String")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            ColNew = New DataColumn("Cap Code")
            ColNew.DataType = System.Type.GetType("System.String")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            'ColNew = New DataColumn("Device_Model")
            'ColNew.DataType = System.Type.GetType("System.String")
            'GdtGGridDataSource.Columns.Add(ColNew)
            'ColNew.Dispose()
            'ColNew = Nothing

            ColNew = New DataColumn("Frequency")
            ColNew.DataType = System.Type.GetType("System.String")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            'ColNew = New DataColumn("Model_Number")
            'ColNew.DataType = System.Type.GetType("System.String")
            'GdtGGridDataSource.Columns.Add(ColNew)
            'ColNew.Dispose()
            'ColNew = Nothing

            ColNew = New DataColumn("SKU")
            ColNew.DataType = System.Type.GetType("System.String")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            ColNew = New DataColumn("Baud Rate")
            ColNew.DataType = System.Type.GetType("System.String")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            ColNew = New DataColumn("Baud_id")
            ColNew.DataType = System.Type.GetType("System.Int32")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            ColNew = New DataColumn("Freq_id")
            ColNew.DataType = System.Type.GetType("System.Int32")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            ColNew = New DataColumn("Came With File?")
            ColNew.DataType = System.Type.GetType("System.String")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            ColNew = New DataColumn("Tray_ID")
            ColNew.DataType = System.Type.GetType("System.Int32")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            ColNew = New DataColumn("freq_MotoCode")
            ColNew.DataType = System.Type.GetType("System.Int32")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            ColNew = New DataColumn("Tverdata_TransID")
            ColNew.DataType = System.Type.GetType("System.Int32")
            GdtRecDBGrid.Columns.Add(ColNew)
            ColNew.Dispose()
            ColNew = Nothing

            Select Case Me.cmbRecCust.SelectedValue
                Case PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID, _
                PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID, _
                PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID
                    ColNew = New DataColumn("Model_id")
                    ColNew.DataType = System.Type.GetType("System.Int32")
                    GdtRecDBGrid.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing

                    ColNew = New DataColumn("Model_desc")
                    ColNew.DataType = System.Type.GetType("System.String")
                    GdtRecDBGrid.Columns.Add(ColNew)
                    ColNew.Dispose()
                    ColNew = Nothing
            End Select


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
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
                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns(0).Width = 40      'Count
                .Splits(0).DisplayColumns(1).Width = 140     'Serial Number
                .Splits(0).DisplayColumns(2).Width = 110     'Cap Code
                .Splits(0).DisplayColumns(3).Width = 100     'Frequency
                .Splits(0).DisplayColumns(5).Width = 100     'Baud Rate
                .Splits(0).DisplayColumns(8).Width = 120     'Came With File?

                'Make some columns invisible
                .Splits(0).DisplayColumns(4).Visible = False      'SKU
                .Splits(0).DisplayColumns(6).Visible = False      'Baud_id
                .Splits(0).DisplayColumns(7).Visible = False      'Freq_id
                '.Splits(0).DisplayColumns(8).Visible = False  'Tray_ID
                .Splits(0).DisplayColumns(10).Visible = False      'freq_MotoCode
                .Splits(0).DisplayColumns(11).Visible = False     'Tverdata_TransID

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Function IsSNDuplicateInList_Receive(ByVal strSN As String) As Boolean
        Dim booResult As Boolean = False
        Dim R1 As DataRow

        Try
            If Not IsNothing(Me.GdtRecDBGrid) Then
                For Each R1 In Me.GdtRecDBGrid.Rows
                    If UCase(Trim(strSN)) = UCase(Trim(R1("Serial Number"))) Then
                        'Throw New Exception("This device is already scanned in. Try another one.")
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

    '*********************************************************
    Private Function IsCapCodeDuplicateInList_Receive(ByVal strCapcode As String) As Boolean
        Dim booResult As Boolean = False
        Dim R1 As DataRow

        Try
            If Not IsNothing(Me.GdtRecDBGrid) Then
                For Each R1 In Me.GdtRecDBGrid.Rows
                    If UCase(Trim(strCapcode)) = UCase(Trim(R1("Cap Code"))) Then
                        'Throw New Exception("This device is already scanned in. Try another one.")
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

    '*********************************************************
    Private Sub txtRecTray_ID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecTray_ID.KeyUp
        Dim dt1 As DataTable
        Dim iTray_ID As Integer = 0

        Try
            If e.KeyValue = 13 Then

                '******************
                '1: validate data
                '******************
                If Trim(Me.txtRecTray_ID.Text) = "" Then
                    Exit Sub
                End If

                If Not IsNumeric(Trim(Me.txtRecTray_ID.Text)) Then
                    MessageBox.Show("Tray ID must be number.", "Validate Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                iTray_ID = Trim(Me.txtRecTray_ID.Text)

                'If GiRecLocID = 0 Then
                '    MessageBox.Show("Customer's Location was not defined.", "Receive Devices", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'End If

                'If Me.cmbRecModel.SelectedValue = 0 Then
                '    MessageBox.Show("Please select Model.", "Receive Devices", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Me.cmbRecModel.Focus()
                '    Exit Sub
                'End If

                '*******************************************************
                '2: reset datatable(storing information of scanned devices)
                '*******************************************************
                If Not IsNothing(Me.GdtRecDBGrid) Then
                    Me.GdtRecDBGrid.Dispose()
                    Me.GdtRecDBGrid = Nothing
                End If

                '******************
                '3: clear dbgrid
                '******************
                Me.grdRecDevices.ClearFields()
                Me.grdRecDevices.DataSource = Nothing

                '*****************************************
                '4: get WO information and display onto form 
                '*****************************************
                dt1 = Me.GobjMessReceive.GetWOInfoByTray(CInt(Trim(Me.txtRecTray_ID.Text)))
                If dt1.Rows.Count = 0 Then
                    MessageBox.Show("Can not define 'Work Order' for scanned tray.", "Add More Devices to Tray", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    '**************************************
                    'display customer
                    '**************************************
                    If Not IsDBNull(dt1.Rows(0)("cust_id")) Then
                        Me.cmbRecCust.SelectedValue = dt1.Rows(0)("cust_id")
                    Else
                        MessageBox.Show("Can not define 'Customer' for scanned tray.", "Add More Devices to Tray", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    '**************************************
                    'Display wo data
                    '**************************************
                    If Not IsDBNull(dt1.Rows(0)("mmw_wo")) Then
                        Me.txtRecWO.Text = dt1.Rows(0)("mmw_wo")
                    Else
                        MessageBox.Show("Can not define 'Work Order' for scanned tray.", "Add More Devices to Tray", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    '**************************************
                    'Display Model
                    '**************************************
                    If IsDBNull(dt1.Rows(0)("model_id")) Then
                        MessageBox.Show("Can not define 'Model' for scanned tray.", "Add More Devices to Tray", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                    '**************************************
                    'Display tray_memo
                    '**************************************
                    If IsDBNull(dt1.Rows(0)("Tray_Memo")) Then
                        MessageBox.Show("Can not define 'Tray Memo' for scanned tray.", "Add More Devices to Tray", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    '**************************************
                    'Reset global (keep customer + wo)
                    '**************************************
                    Me.ClearPage_Receive(2)
                    '**************************************
                    'get customer wo data
                    '**************************************
                    Me.GetWOData_Receive()
                    '**************************************
                End If

                Me.txtRecTray_ID.Text = iTray_ID
                Me.cmbRecModel.SelectedValue = dt1.Rows(0)("model_id")
                Me.cmbRecModel.Enabled = False
                Me.lblRecModelDesc.Text = Me.cmbRecModel.Text
                Me.txtRecTrayMemo.Text = dt1.Rows(0)("Tray_Memo")

                '******************************
                '5: get all devices belong to tray
                '******************************
                GdtRecDBGrid = Me.GobjMessReceive.GetDevInTray(CInt(Trim(Me.txtRecTray_ID.Text)), GiRecLocID, Me.cmbRecModel.SelectedValue)

                '******************************
                '6: populate devices in dbgrid
                '******************************
                If GdtRecDBGrid.Rows.Count > 0 Then
                    Me.ResetDevCnt()
                    Me.grdRecDevices.DataSource = Me.GdtRecDBGrid.DefaultView
                    Me.SetGridProperties_Receive()
                    Me.grdRecDevices.MoveLast()
                    Me.lblRecScanCnt.Text = GdtRecDBGrid.Rows.Count
                Else
                    Me.lblRecScanCnt.Text = "0"
                End If

                Me.txtRecDevSN.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Add More Devices to Tray", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub ResetDevCnt()
        Dim R1 As DataRow
        Dim i As Integer = 0
        Try
            For Each R1 In Me.GdtRecDBGrid.Rows
                i += 1
                R1.BeginEdit()
                R1("Count") = i
                R1.EndEdit()
            Next R1
            Me.GdtRecDBGrid.AcceptChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdRecTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecTray.Click
        Me.RecTray_Receive(0)
    End Sub

    '*********************************************************
    Private Sub btnRecDBRTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecDBRTray.Click
        Me.RecTray_Receive(1)
    End Sub

    '*********************************************************
    Private Sub RecTray_Receive(ByVal iIsDBRTray As Integer)
        Const strScreenName As String = "Receiving"
        Dim i As Integer = 0
        Dim iRcvdCnt As Integer = 0, iModelID As Integer = 0
        Dim iWipOwnerID As Integer = 1, iRcvd_Tray_id As Integer = 0
        Dim iTotalRcvdDevice As Integer = 0, iDBRFailCode As Integer = 0
        Dim iEmpNo As Integer = PSS.Core.Global.ApplicationUser.NumberEmp
        Dim objFrmFailCode As frmUserSelection
        Dim strSql As String = "", strCustIDs As String
        Dim bCheckWarranty As Boolean = False

        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Me.Enabled = False

            '*****************
            'validate data
            '*****************
            If IsNothing(Me.GdtRecDBGrid) Then Exit Sub

            If Me.GdtRecDBGrid.Rows.Count = 0 Then
                Exit Sub
            End If
            If CInt(Trim(Me.lblRecScanCnt.Text)) = 0 Then
                Me.txtRecDevSN.Focus()
                MessageBox.Show("Please scan Serial Number.", "Receive Devices", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Me.GiRecWOID = 0 Then
                MessageBox.Show("Work Order ID was not defined.", "Receive Devices", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If GiRecLocID = 0 Then
                MessageBox.Show("Customer's Location was not defined.", "Receive Devices", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Me.cmbRecCust.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Receive Devices", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cmbRecCust.Focus()
                Exit Sub
            End If
            If Me.cmbRecModel.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Receive Devices", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cmbRecModel.Focus()
                Exit Sub
            End If

            If iIsDBRTray = 1 Then
                strSql = "Select Dcode_ID, Dcode_LDesc from lcodesdetail where MCode_ID = 21 order by Dcode_ID;"
                objFrmFailCode = New frmUserSelection(strSql, "DBR Fail Code")
                objFrmFailCode.colorBGColor = Color.DarkKhaki
                objFrmFailCode.ShowDialog()
                If objFrmFailCode.ReturnFlg = False Then
                    MessageBox.Show("Unable to define DBR-Code. Please try again.", "Receive Devices", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    iDBRFailCode = objFrmFailCode.ID
                End If
            End If

            If Me.chkRecCheckWarranty.Checked Then
                bCheckWarranty = True
            Else
                bCheckWarranty = False
            End If

            If IsMessagingCustomer(Me.cmbRecCust.SelectedValue) Then    'messaging
                If Me.lblModelActive.Text.Trim.ToUpper = "Active".ToUpper Then    'Receive into Pre-Eval
                    iWipOwnerID = 202
                ElseIf Me.lblModelActive.Text.Trim.ToUpper = "Inactive".ToUpper Then    'Receive into WH
                    iWipOwnerID = 201
                Else
                    MessageBox.Show("Can't determine if an active model or inactive model.", "Receive Devices", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            Else
                If IsNothing(Me._objMessReports) Then Me._objMessReports = New Data.Buisness.MessReports()
                strCustIDs = Me._objMessReports.GetAMSMessCustIDs()
                iWipOwnerID = Me.GobjMessReceive.GetNextWipOwnerIDInWFP(strCustIDs, strScreenName, 0)
                If iWipOwnerID = 0 Then Throw New Exception("System can't define wip bucket in work flow.")
            End If

            iModelID = Me.cmbRecModel.SelectedValue


            '****************************
            'insert devices into system
            '****************************

            Dim _activeModel As Boolean = IIf(lblModelActive.Text.ToUpper() = "INACTIVE", False, True)

            iRcvdCnt = Me.GobjMessReceive.ReceiveDevicesInTray(Me.GstrUserName, _
             Me.GiUserID, _
             Me.GiShiftID, _
             Trim(Me.txtRecWO.Text), _
             Me.GiRecWOID, _
             Me.GiRecLocID, _
             iModelID, _
             Me.GdtRecDBGrid, _
             iRcvd_Tray_id, _
             UCase(Trim(Me.txtRecTrayMemo.Text)), _
             Me.GiRecParentWO_ID, _
             iIsDBRTray, _
             bCheckWarranty, iWipOwnerID, _activeModel)

            '****************************
            'Bill DBR and auto-ship
            '****************************
            If iIsDBRTray > 0 AndAlso iRcvd_Tray_id > 0 Then
                i += Messaging.Functions.DBRMessDevices("TRAY ID", iRcvd_Tray_id.ToString, iDBRFailCode)
            End If

            '****************************************
            'Get total received device for workorder
            '****************************************
            iTotalRcvdDevice = GobjMessReceive.GetWORcvdQty(GiRecWOID)
            '****************************************
            'Update WO_Qty
            '****************************************
            i = GobjMessReceive.UpdatePSSWOQty(GiRecWOID, iTotalRcvdDevice)

            ''****************
            'clear data
            ''****************
            If Trim(Me.txtRecTray_ID.Text) = "" Then
                Me.lblRecDevRcvdCnt.Text = iTotalRcvdDevice
                Me.lblRecScanCnt.Text = "0"
                Me.grdRecDevices.ClearFields()
                Me.grdRecDevices.DataSource = Nothing

                Me.CreateNewTable_Receive()

                Me.txtRecDevSN.Focus()
            Else
                Me.ClearPage_Receive(1)    'clear very thing except customer
                Me.txtRecWO.Focus()
            End If
            lblEquipTypeMismatch.Visible = False

            '**********************
            'Print Rport
            '**********************
            If iRcvdCnt > 0 AndAlso Me.chkRecPrintWorkSheet.Checked = True Then
                Me.GobjMessReceive.PrintRecReport(iRcvd_Tray_id, 1)
            End If

            Me.cboRecFreq.Enabled = True : Me.cboRecFreq.SelectedValue = 0
            Me.cboRecBaud.Enabled = True : Me.cboRecBaud.SelectedValue = 0
            Me.txtRecCapCode.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Receive Tray", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objFrmFailCode = Nothing
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.Enabled = True
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdRecReprintManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecReprintManifest.Click
        Dim strTray_id As String = ""

        Try
            '*******************
            'Get Tray ID
            '*******************
            strTray_id = Trim(InputBox("Please Scan Tray ID:", "Reprint Receive Manifest"))

            '********************
            'Validate user input
            '********************
            If strTray_id = "" Then
                Exit Sub
            End If

            If Not IsNumeric(strTray_id) Then
                MessageBox.Show("Invalid Tray ID please retry.", "Validate Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '***********************
            'Print Report
            '***********************
            Me.GobjMessReceive.PrintRecReport(CInt(strTray_id), 1)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Receive Manifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub btnRecClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecClear.Click
        Dim R1 As DataRow
        Dim strSelectedSN As String = ""

        Try
            If IsNothing(Me.GdtRecDBGrid) Then Exit Sub
            If Me.GdtRecDBGrid.Rows.Count = 0 Then Exit Sub

            '*****************
            'Get selected SN
            '*****************
            strSelectedSN = InputBox("Enter SN:").Trim
            If strSelectedSN.Length = 0 Then Exit Sub

            '*******************************
            'Remove selected SN in datatable
            '*******************************
            For Each R1 In Me.GdtRecDBGrid.Rows
                If R1("Serial Number") = strSelectedSN Then
                    If R1("Tray_ID") > 0 Then
                        MessageBox.Show("This Serial Number has already been received. To remove it from this Tray go to the ""Admin"" Screen.", "Remove a Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Me.GdtRecDBGrid.Rows.Remove(R1)
                    Me.GdtRecDBGrid.AcceptChanges()

                    Exit For
                End If
            Next R1

            '********************
            'Reset datagrid
            '********************
            If Me.GdtRecDBGrid.Rows.Count > 0 Then
                Me.grdRecDevices.ClearFields()
                Me.grdRecDevices.DataSource = Nothing
                Me.grdRecDevices.DataSource = Me.GdtRecDBGrid.DefaultView
                SetGridProperties_Receive()
                Me.grdRecDevices.MoveLast()
                Me.lblRecScanCnt.Text = GdtRecDBGrid.Rows.Count
            Else
                Me.grdRecDevices.ClearFields()
                Me.grdRecDevices.DataSource = Nothing
                Me.lblRecScanCnt.Text = "0"
            End If
            '********************

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Remove ONE Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            Me.txtRecDevSN.SelectAll() : Me.txtRecDevSN.Focus()
        End Try
    End Sub

    '*********************************************************
    Private Sub btnRecClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecClearAll.Click
        Dim R1 As DataRow
        Dim i As Integer = 0

        Try
            If IsNothing(Me.GdtRecDBGrid) Then
                Exit Sub
            End If

            If Me.GdtRecDBGrid.Rows.Count = 0 Then
                Exit Sub
            Else
                '*****************************
                'Ask user for confirm message
                '*****************************
                If MessageBox.Show("Are you sure you want to Clear all devices?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    '***************************************
                    'Check if tray contain received devices
                    '***************************************
                    For Each R1 In Me.GdtRecDBGrid.Rows
                        If R1("Tray_ID") > 0 Then
                            MessageBox.Show("Only those devices will be removed from this Tray that you have just scanned in and have not yet been received. If there are devices that have already been received in this Tray they will remain unaffected.", "Remove ALL Serial Numbers", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit For
                        End If
                    Next R1

                    '************************
                    'Remove scanned devices
                    '************************
                    i = 1

                    While i = 1
                        i = 0
                        For Each R1 In Me.GdtRecDBGrid.Rows
                            If R1("Tray_ID") = 0 Then
                                Me.GdtRecDBGrid.Rows.Remove(R1)
                                Me.GdtRecDBGrid.AcceptChanges()
                                i = 1
                                Exit For
                            End If
                        Next R1
                    End While

                    '********************
                    'Reset datagrid
                    '********************
                    If Me.GdtRecDBGrid.Rows.Count > 0 Then
                        Me.grdRecDevices.ClearFields()
                        Me.grdRecDevices.DataSource = Nothing
                        Me.grdRecDevices.DataSource = Me.GdtRecDBGrid.DefaultView
                        SetGridProperties_Receive()
                        Me.grdRecDevices.MoveLast()
                        Me.lblRecScanCnt.Text = GdtRecDBGrid.Rows.Count
                    Else
                        Me.grdRecDevices.ClearFields()
                        Me.grdRecDevices.DataSource = Nothing
                        Me.lblRecScanCnt.Text = "0"
                    End If
                    '********************
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Remove ALL Serial Numbers", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            Me.txtRecDevSN.Focus()
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        Try
            ''****************
            'clear data
            ''****************
            Me.lblRecDevRcvdCnt.Text = GobjMessReceive.GetWORcvdQty(GiRecWOID)
            Me.lblRecScanCnt.Text = "0"
            Me.txtRecTray_ID.Text = ""
            Me.grdRecDevices.ClearFields()
            Me.grdRecDevices.DataSource = Nothing
            Me.CreateNewTable_Receive()
            Me.cboRecFreq.Text = ""
            Me.cboRecFreq.Enabled = True
            Me.txtRecDevSN.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear Screen", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmbRecModel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRecModel.Leave
        Dim objMess As New PSS.Data.Buisness.Messaging()
        Dim dt As DataTable

        Try
            Me.lblModelActive.Visible = False
            Me.lblRecModelDesc.Text = ""
            Me.lblRecModelDesc.ForeColor = Color.Red
            Me.lblRecModelDesc.Left = Me.lblModelActive.Left

            If cmbRecModel.SelectedValue > 0 Then
                Me.lblRecModelDesc.Text = Me.cmbRecModel.Text

                If IsMessagingCustomer(Me.cmbRecCust.SelectedValue) Then
                    dt = objMess.GetMessActiveInactiveModelData(CInt(cmbRecModel.SelectedValue))
                    If dt.Rows.Count = 1 Then
                        Me.lblModelActive.Text = dt.Rows(0).Item("ModelStatus")
                        If Trim(dt.Rows(0).Item("ModelStatus")).ToUpper = "Active".ToUpper Then
                            Me.lblModelActive.ForeColor = Color.Red
                            Me.lblRecModelDesc.ForeColor = Color.Red
                        Else
                            Me.lblModelActive.ForeColor = Color.Black
                            Me.lblRecModelDesc.ForeColor = Color.Black
                        End If
                    Else
                        Me.lblModelActive.Text = "Undefined"
                        Me.lblModelActive.ForeColor = Color.White
                        Me.lblRecModelDesc.ForeColor = Color.White
                    End If
                    Me.lblRecModelDesc.Left = Me.lblModelActive.Left + Me.lblModelActive.Width + 5
                    Me.lblModelActive.Visible = True
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cmbRecModel_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            objMess = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub btnMessageBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMessageBoard.Click
        Dim dt As DataTable
        Dim strWeekDates As String = ""

        Try
            If Me.cmbRecCust.SelectedValue <> 14 Then
                MessageBox.Show("Customer is not 'American Messaging'! No thing to show.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.GobjMessReceive = New PSS.Data.Buisness.MessReceive()
            If Me.cmbRecCust.SelectedValue = 14 Then    'only for AMS
                dt = Me.GobjMessReceive.getShippedForecatedQtyData(Me.cmbRecCust.SelectedValue, Me.GstrWorkDate, strWeekDates)
                Dim f As New frmMessageBoard(dt, strWeekDates)
                f.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString(), " btnMessageBoard_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '***************************************************************************************************************
    Private Sub Ctrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRecFreq.KeyUp, cboRecBaud.KeyUp, txtRecCapCode.KeyUp, txtRecTrayMemo.KeyUp, cmbRecModel.KeyUp, cmbRecCust.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If sender.name = "cboRecFreq" Then
                    If Me.cboRecFreq.SelectedValue > 0 Then
                        Me.cboRecBaud.SelectAll() : Me.cboRecBaud.Focus()
                    End If
                ElseIf sender.name = "cboRecBaud" Then
                    If Me.cboRecBaud.SelectedValue > 0 Then
                        Me.txtRecCapCode.SelectAll() : Me.txtRecCapCode.Focus()
                    End If
                ElseIf sender.name = "txtRecCapCode" Then
                    Me.txtRecDevSN.SelectAll() : Me.txtRecDevSN.Focus()
                ElseIf sender.name = "txtRecTrayMemo" Then
                    If Trim(txtRecTrayMemo.Text) <> "" Then
                        If Me.lblRecWOHasFile.Text = "NO" Then
                            Me.cboRecFreq.SelectAll() : Me.cboRecFreq.Focus()
                        Else
                            Me.txtRecDevSN.SelectAll() : Me.txtRecDevSN.Focus()
                        End If
                    End If
                ElseIf sender.name = "cmbRecModel" Then
                    If Me.cmbRecModel.SelectedValue > 0 Then
                        Me.lblRecModelDesc.Text = Me.cmbRecModel.Text
                        Me.txtRecTrayMemo.SelectAll() : Me.txtRecTrayMemo.Focus()
                    Else
                        Me.lblRecModelDesc.Text = ""
                    End If
                ElseIf sender.name = "cmbRecCust" Then
                    If Me.cmbRecCust.SelectedValue > 0 Then Me.txtRecWO.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, sender.name & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
    Private Function IsEquipmentTypeCorrect(ByVal sn As String, ByVal model_id As Integer) As Boolean
        ' DAVID BRADLEY - 02-14-2017
        ' THIS FUNCTION WILL COMPARE THE EQUIPMENT TYPE IN THE TVERDATA 
        ' AND TMODEL_REC_STATUS TABLES FOR A MATCH.
        Dim _retVal As Boolean = True
        Dim _tv As New Data.BOL.tverdata(sn)
        Dim _tv_et As String = _tv.Device_Model
        _tv = Nothing
        Dim _mrs As New Data.BOL.tmodel_rec_status(model_id, False)
        Dim _mrs_et = _mrs.equip_type
        _mrs = Nothing
        _retVal = (_tv_et = _mrs_et)
        If Not _retVal Then
            MessageBox.Show("The equipment type for this device is '" & _tv_et & "' and the required equipment type is '" & _mrs_et & "'.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return _retVal
    End Function


    Private Function HasDbrNerTransaction(ByVal sn As String, ByVal model_id As Integer) As Integer
        ' DAVID BRADLEY - 03-10-2017
        ' THIS FUNCTION WILL DETERMINE IF THERE ARE ANY DBR/NER RECORDS FOR THIS SERIAL NUMBER 
        ' AND RETURN THE DEVICECODEID FOR THE RECORD.
        Dim _retVal As Integer = 0
        Dim _dm As New Data.BLL.AMSReceiving()
        Try
            _retVal = _dm.GetDbrNerForSN(sn, model_id)
        Catch ex As Exception
            ' DO NOTHING HERE IF NO DBR/NER IS FOUND.
        End Try
        Return _retVal
    End Function

    Private Sub btnDbrNerRemoval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDbrNerRemoval.Click
        Dim _frm As New frmMsgDbrNerRemoval()
        _frm.ShowDialog()
    End Sub

    Private Sub LoadAdminButtons()
        Dim _sec As New Data.Buisness.Security()
        If _sec.DoesUserHaveSpecialPerm(_user_id, "Messaging Admin") Then
            btnDbrNerRemoval.Visible = True
        End If
        _sec = Nothing
    End Sub



#End Region

#Region "Label"

	'&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	'&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& LABEL &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	'*********************************************************
	Private Sub ClearPage_Label()
		Me.txtlblSN.Text = ""
		Me.txtlblCap.Text = ""
		SetFreqMaskControlText_Label()
		Me.cmblblBaud.SelectedValue = 0
		Me.lbllblModel.Text = ""
		Me.lbllblModel.Tag = 0
		Me.lbllblCust.Text = ""
		Me.chkPrintModelLetter.Checked = False
		Me.chkPrintModelLetter.Visible = False
		Me.chkPrintSkyTellLetter.Checked = False
		Me.chkPrintSkyTellLetter.Visible = False
		Me.lblModelType.Visible = False
		Me.lstModelType.SelectedIndex = -1
		Me.lstModelType.Visible = False
		Me.chkRefreq.Checked = False

		If Not IsNothing(GobjMessLabel) Then
			With Me.GobjMessLabel
				.ModelID = 0
				.DeviceID = 0
				.DeviceOldSN = ""
				.DeviceSN = ""

				.FreqID = 0
				.Frequency = ""
				.OldFreqID = 0

				.BaudID = 0
				.OldBaudID = 0

				.CapCode = ""
				.OldCapCode = ""
				.CustID = 0

				.ModelTypeLetter = ""
				.ModelType = ""
			End With
		End If
	End Sub

	'*********************************************************
	Private Sub txtlblSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlblSN.KeyUp
		If e.KeyValue = 13 Then		  'Carriage Return
			If Trim(Me.txtlblSN.Text) = "" Then
				Exit Sub
			End If
			Me.ComboBox1.Visible = False
			FillLabelInfo_Label()
			Me.txtlblCap.Focus()
		ElseIf e.KeyValue = 123 Then		   'F12
			'DoPrint()
			Me.txtlblCap.Focus()
		End If
	End Sub

	'*********************************************************
	Private Sub ShowHideOptionals_Label(ByVal imodel_id As Integer)
		chklblPlus.Visible = False
		chklblND.Visible = False

		Select Case imodel_id
			Case 276			 'ST800-
				chklblPlus.Visible = False
				Me.chklblPlus.Checked = True
			Case 3			   'AE-Advisor Elite
				chklblND.Visible = True
			Case 2			   'AG-Advisor Gold
				chklblND.Visible = True
		End Select

		ShowHideTwoWay(imodel_id)
	End Sub

	'*********************************************************
	Private Sub FillLabelInfo_Label()

		Dim dt1 As DataTable
		Dim R1 As DataRow
		'Dim strMask As String = ""

		Try
			dt1 = Me.GobjMessLabel.GetMessDeviceInfoForLabel(Trim(Me.txtlblSN.Text), 14)

			For Each R1 In dt1.Rows

				'Cap code
				If Not IsDBNull(R1("capcode")) Then
					Me.txtlblCap.Text = Trim(R1("capcode"))
					Me.GobjMessLabel.CapCode = Trim(R1("capcode"))
				Else
					Me.txtlblCap.Text = ""
					Me.GobjMessLabel.CapCode = ""
				End If

				'Frequency
				If Not IsDBNull(R1("freq_Number")) Then
					Me.SetFreqMaskControlText_Label(Trim(R1("freq_number")))
					Me.GobjMessLabel.Frequency = Trim(R1("freq_number"))
				Else
					SetFreqMaskControlText_Label()
					Me.GobjMessLabel.Frequency = ""
				End If

				'FreqID
				If Not IsDBNull(R1("Freq_id")) Then
					Me.GobjMessLabel.FreqID = R1("Freq_id")
				Else
					Me.GobjMessLabel.FreqID = 0
				End If

				'Baud_ID
				If Not IsDBNull(R1("baud_id")) Then
					Me.cmblblBaud.SelectedValue = R1("baud_id")
					Me.GobjMessLabel.BaudID = R1("baud_id")
				Else
					Me.cmblblBaud.SelectedValue = 0
					Me.GobjMessLabel.BaudID = 0
				End If

				'OldCapCode
				If Not IsDBNull(R1("capcode_old")) Then
					Me.GobjMessLabel.OldCapCode = R1("capcode_old")
				Else
					Me.GobjMessLabel.OldCapCode = ""
				End If

				'OldBaudID
				If Not IsDBNull(R1("baud_id_old")) Then
					Me.GobjMessLabel.OldBaudID = R1("baud_id_old")
				Else
					Me.GobjMessLabel.OldBaudID = 0
				End If

				'OldFreqID
				If Not IsDBNull(R1("freq_id_old")) Then
					Me.GobjMessLabel.OldFreqID = R1("freq_id_old")
				Else
					Me.GobjMessLabel.OldFreqID = 0
				End If

				'Model
				If Not IsDBNull(R1("model_desc")) Then
					Me.lbllblModel.Text = Trim(R1("model_desc"))
					Me.lbllblModel.Tag = 0
					Me.lbllblModel.Tag = R1("model_id")
				Else
					Me.lbllblModel.Text = ""
				End If

				'Model_ID
				If Not IsDBNull(R1("model_id")) Then
					ShowHideOptionals_Label(R1("model_id"))
				End If

				'Customer
				If Not IsDBNull(R1("cust_name1")) Then
					Me.lbllblCust.Text = Trim(R1("cust_name1"))
				Else
					Me.lbllblCust.Text = ""
				End If

				'CustID
				If Not IsDBNull(R1("cust_id")) Then
					Me.GobjMessLabel.CustID = R1("cust_id")
				Else
					Me.GobjMessLabel.CustID = 0
				End If

				Exit For
			Next R1

			If Me.GobjMessLabel.IsRefreqUnit = True Then
				Me.chkRefreq.Checked = True
				'Me.chkRefreq.Enabled = False
				'Me.chkRefreq.Visible = True
				'Me.txtlblCap.Enabled = True
				'Me.msklblFreq.Enabled = True
				'Me.cmblblBaud.Enabled = True
				'ElseIf Me.GobjMessLabel.ElegibleForRefreq = True Then
				'    Me.chkRefreq.Enabled = True
				'    Me.chkRefreq.Visible = True
			End If

			'*****************************************
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "SN Scan", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			If Not IsNothing(dt1) Then
				dt1.Dispose()
				dt1 = Nothing
			End If
			R1 = Nothing
		End Try
	End Sub

	'*********************************************************
	Private Sub cmdlblPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlblPrint.Click
		DoPrint()
	End Sub

	'*********************************************************
	Private Sub DoPrint()
		MessageBox.Show("Please use the generic label screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
		'    Dim i As Integer = 0
		'    Dim strND As String = ""
		'    Dim strPlus As String = ""
		'    Dim objDevice As Device = Nothing
		'    Dim strModelNumber As String = ""
		'    Try
		'        If Me.GobjMessLabel.IsRefreqUnit = False And Me.GobjMessLabel.ElegibleForRefreq = True And Me.chkRefreq.Checked = True Then
		'            objDevice = New Device(Me.GobjMessLabel.DeviceID)
		'            objDevice.AddPart(58)
		'            objDevice.Update()
		'            Exit Sub
		'        End If

		'        '*******************************************
		'        'Validate capcode added on 0813/09
		'        ''*******************************************
		'        Me.txtlblCap.Text = Me.txtlblCap.Text.Trim
		'        Select Case Me.lbllblModel.Tag
		'            Case 1121, 1110, 87, 808, 76, 130, 1142
		'                For i = 1 To Me.txtlblCap.Text.Length
		'                    If Char.IsDigit(CChar(Mid(Me.txtlblCap.Text, i, 1))) = False Then
		'                        MessageBox.Show("This model does not allow to have any letter in the capcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
		'                        Me.txtlblCap.Focus()
		'                        Exit Sub
		'                    End If
		'                Next i
		'        End Select
		'        '*******************************************

		'        If Me.chklblND.Checked Then
		'            strND = "ND"
		'        Else
		'            strND = ""
		'        End If

		'        If Me.chklblPlus.Checked Then
		'            strPlus = "PLUS"
		'        Else
		'            strPlus = ""
		'        End If

		'        If Me.ComboBox1.Visible = True Then
		'            If (Me.ComboBox1.SelectedIndex = -1) Then
		'                MessageBox.Show("Please select model number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
		'                Me.ComboBox1.Focus()
		'                Exit Sub
		'            Else
		'                strModelNumber = Me.ComboBox1.SelectedItem
		'            End If
		'        End If

		'        i = Me.GobjMessLabel.PrintLabel(UCase(Trim(Me.txtlblSN.Text)), _
		'                            UCase(Trim(Me.txtlblCap.Text)), _
		'                            Trim(Me.msklblFreq.CtlText), _
		'                            Me.cmblblBaud.SelectedValue, _
		'                            UCase(Trim(strND)), _
		'                            UCase(Trim(strPlus)), _
		'                            GiUserID, _
		'                            GstrWorkDate, _
		'                            UCase(Trim(strModelNumber)))

		'        'get Daily and weekly label production numbers
		'        Me.lbllblDaily.Text = Me.GobjMessLabel.GetLabelProductionNumbersByCC(GstrWorkDate, 0)
		'        Me.lbllblweekly.Text = Me.GobjMessLabel.GetLabelProductionNumbersByCC(GstrWorkDate, 1)
		'        Me.LoadDailyWeeklyLabelProd()

		'        'Clear Screen
		'        If Me.chkClearData.Checked Then
		'            ClearPage_Label()
		'        Else
		'            Me.txtlblSN.SelectAll()
		'        End If

		'        Me.chklblND.Checked = False
		'        Me.chklblND.Visible = False
		'        Me.chklblPlus.Checked = False
		'        Me.chklblPlus.Visible = False
		'        Me.chkClearData.Visible = False

		'        Me.chkRefreq.Checked = False
		'        'Me.chkRefreq.Enabled = False
		'        'Me.chkRefreq.Visible = False
		'        'Me.txtlblCap.Enabled = False
		'        'Me.msklblFreq.Enabled = False
		'        'Me.cmblblBaud.Enabled = False
		'        Me.txtlblSN.Focus()

		'    Catch ex As Exception
		'        MessageBox.Show(ex.ToString, "Print Label", MessageBoxButtons.OK, MessageBoxIcon.Error)
		'    Finally
		'        If Not IsNothing(objDevice) Then
		'            objDevice.Dispose()
		'            objDevice = Nothing
		'        End If
		'    End Try
	End Sub

	'*************************************************************************
	Private Sub KeyDownInControls(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlblCap.KeyUp, cmblblBaud.KeyUp, chklblPlus.KeyUp, chklblND.KeyUp, chkClearData.KeyUp, txtlblSN.KeyUp, lstModelType.KeyUp, chkPrintModelLetter.KeyUp
		If e.KeyValue = 123 Then		   'F12
			DoPrint()
		End If
	End Sub

	'*********************************************************
	Private Sub msklblFreq_KeyUpEvent(ByVal sender As Object, ByVal e As AxMSMask.MaskEdBoxEvents_KeyUpEvent) Handles msklblFreq.KeyUpEvent
		If e.keyCode = 123 Then		   'F12
			DoPrint()
		End If
	End Sub

	'*********************************************************
	Private Sub SetFreqMaskControlText_Label(Optional ByVal strText As String = "")
		Dim strMask As String = ""

		With Me.msklblFreq
			strMask = .Mask
			.Mask = ""
			.CtlText = strText
			.Mask = strMask
		End With
	End Sub

	'*********************************************************
	Private Sub PrintModelTypeLetterCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintModelLetter.CheckedChanged
		Try
			If Not Me.chkPrintModelLetter.Visible Then Exit Sub

			If Me.chkPrintModelLetter.Checked Then
				If Not IsNothing(Me.GobjMessLabel) Then Me.GobjMessLabel.ModelTypeLetter = "R"
			Else
				If Not IsNothing(Me.GobjMessLabel) Then Me.GobjMessLabel.ModelTypeLetter = ""
			End If
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Print Model Type Letter Error")
		End Try
	End Sub

	'*********************************************************
	Private Sub chkPrintSkyTellLetter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPrintSkyTellLetter.CheckedChanged
		Try
			If Not Me.chkPrintSkyTellLetter.Visible Then Exit Sub

			If Me.chkPrintSkyTellLetter.Checked Then
				If Not IsNothing(Me.GobjMessLabel) Then Me.GobjMessLabel.SkyTellLetter = "S"
			Else
				If Not IsNothing(Me.GobjMessLabel) Then Me.GobjMessLabel.SkyTellLetter = ""
			End If
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Print SkyTell Letter Error")
		End Try
	End Sub

	'*********************************************************
	Private Sub ModelTypeSelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstModelType.SelectedIndexChanged
		Try
			If Not (Me.lstModelType.Visible And Me.lstModelType.Enabled) Then Exit Sub

			If Me.lstModelType.SelectedIndex = -1 Then
				If Not IsNothing(Me.GobjMessLabel) Then
					Me.GobjMessLabel.ModelType = ""
					Me.GobjMessLabel.ModelTypeLetter = ""
				End If
			Else
				If Not IsNothing(Me.GobjMessLabel) Then Me.GobjMessLabel.ModelType = Me.lstModelType.SelectedItem

				If Me.lstModelType.SelectedItem.ToString.ToUpper = "UNICATION" Then
					If Not IsNothing(Me.GobjMessLabel) Then Me.GobjMessLabel.ModelTypeLetter = "R"
					Me.chkPrintModelLetter.Checked = True
					Me.chkPrintModelLetter.Enabled = False
				Else
					Me.chkPrintModelLetter.Enabled = True
					If Not IsNothing(Me.GobjMessLabel) Then Me.GobjMessLabel.ModelTypeLetter = IIf(Me.chkPrintModelLetter.Checked, "R", "")
				End If
			End If
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Select Model Type Error")
		End Try
	End Sub

	'*********************************************************
	Private Sub ShowHideTwoWay(ByVal iModelID As Integer)
		Try
			If iModelID = 76 Then
				Me.ComboBox1.Visible = True
				Me.lblModelType.Enabled = True
				Me.lstModelType.Enabled = True
				Me.lblModelType.Visible = True
				Me.lstModelType.Visible = True
				Me.chkPrintModelLetter.Visible = True
				Me.chkPrintSkyTellLetter.Visible = True
			ElseIf iModelID = 87 Or iModelID = 808 Or iModelID = 1110 Or iModelID = 76 Then
				Me.lblModelType.Enabled = True
				Me.lstModelType.Enabled = True
				Me.lblModelType.Visible = True
				Me.lstModelType.Visible = True
				Me.chkPrintModelLetter.Visible = True
				Me.chkPrintSkyTellLetter.Visible = True
			Else
				Me.lblModelType.Visible = False
				Me.lstModelType.Visible = False
				Me.chkPrintModelLetter.Visible = False
				Me.chkPrintSkyTellLetter.Visible = False
			End If
		Catch ex As Exception
			Throw ex
		End Try
	End Sub

	'*********************************************************
	Private Sub LoadDailyWeeklyLabelProd()
		Dim iLoc_ID As Integer = 19
		Dim dt As DataTable

		Try
			dt = Me.GobjMessLabel.GetDailyWeeklyLabelProdByModelFreq(iLoc_ID)

			If dt.Rows.Count > 0 Then
				Me.dbgDailyWeeklyProd.Visible = True
				Me.dbgDailyWeeklyProd.DataSource = dt.DefaultView

				With Me.dbgDailyWeeklyProd
					'Heading style (Horizontal Alignment to Center)
					.Splits(0).DisplayColumns("Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
					.Splits(0).DisplayColumns("Frequency").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
					.Splits(0).DisplayColumns("Frequency").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
					.Splits(0).DisplayColumns("Frequency").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

					'Set Column Widths
					.Splits(0).DisplayColumns("Model").Width = 130
					.Splits(0).DisplayColumns("Frequency").Width = 80
					.Splits(0).DisplayColumns("Daily").Width = 80
					.Splits(0).DisplayColumns("Weekly").Width = 80

					.Splits(0).DisplayColumns("Model_ID").Visible = False

					.ColumnFooters = True
					.Columns("Model").FooterText = "TOTAL"
					.Columns("Daily").FooterText = dt.Compute("SUM([Daily])", "")
					.Columns("Weekly").FooterText = dt.Compute("SUM([Weekly])", "")
				End With
			Else
				Me.dbgDailyWeeklyProd.Visible = True
			End If

		Catch ex As Exception
			Throw ex
		Finally
			If Not IsNothing(dt) Then
				dt.Dispose()
				dt = Nothing
			End If
		End Try
	End Sub

	'*********************************************************
	Private Sub dbgDailyWeeklyProd_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dbgDailyWeeklyProd.AfterFilter
		Dim iRow As Integer = 0
		Dim iDailyGrandTotal As Integer = 0
		Dim iWeeklyGrandTotal As Integer = 0

		Try
			If Me.dbgDailyWeeklyProd.RowCount > 0 And Me.dbgDailyWeeklyProd.Columns.Count > 0 Then
				'loop through each selected row
				For iRow = 0 To Me.dbgDailyWeeklyProd.RowCount - 1
					'Calculate Grand Total
					iDailyGrandTotal = iDailyGrandTotal + CInt(Me.dbgDailyWeeklyProd.Columns("Daily").CellText(iRow).ToString)
					iWeeklyGrandTotal = iWeeklyGrandTotal + CInt(Me.dbgDailyWeeklyProd.Columns("Weekly").CellText(iRow).ToString)
				Next iRow

				Me.dbgDailyWeeklyProd.Columns("Daily").FooterText = iDailyGrandTotal.ToString
				Me.dbgDailyWeeklyProd.Columns("Weekly").FooterText = iWeeklyGrandTotal.ToString
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub chkRefreq_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRefreq.CheckedChanged
		'If Me.chkRefreq.Checked = True Then
		'    Me.txtlblCap.Enabled = True
		'    Me.msklblFreq.Enabled = True
		'    Me.cmblblBaud.Enabled = True
		'Else
		'    Me.txtlblCap.Enabled = False
		'    Me.msklblFreq.Enabled = False
		'    Me.cmblblBaud.Enabled = False
		'    Me.txtlblCap.Text = Me.GobjMessLabel.CapCode
		'    Me.SetFreqMaskControlText_Label(Me.GobjMessLabel.Frequency)
		'    Me.cmblblBaud.SelectedValue = Me.GobjMessLabel.BaudID
		'End If

		If Me.chkRefreq.Checked = True And Me.GobjMessLabel.ElegibleForRefreq = False Then
			Me.chkRefreq.Checked = False
		End If
	End Sub

	'*********************************************************

#End Region

#Region "Abacus Data"

	'*********************************************************
	Private Sub ClearPage_AbacusData()
		Me.cmbAbacusSearchType.SelectedIndex = 1
		Me.txtAbacusSearchCriteria.Text = ""
		Me.grdAbacusData.DataSource = Nothing
		Me.grdAbacusData.Refresh()
	End Sub

	'*********************************************************
	Private Sub cmbAbacusSearchType_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAbacusSearchType.SelectionChangeCommitted
		If Me.cmbAbacusSearchType.SelectedIndex > 0 Then
			Me.txtAbacusSearchCriteria.SelectAll()
			Me.txtAbacusSearchCriteria.Focus()
		End If
	End Sub

	'*********************************************************
	Private Sub txtAbacusSearchCriteria_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAbacusSearchCriteria.KeyUp
		Dim dt1 As DataTable
		Dim dt2 As DataTable
		Dim strSearchType As String = ""

		Try
			If e.KeyValue = 13 Then

				If Trim(Me.txtAbacusSearchCriteria.Text) = "" Then
					Exit Sub
				End If
				If Me.cmbAbacusSearchType.SelectedIndex <= 0 Then
					MessageBox.Show("Please select ""Search Type"".", "Search Item KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					Me.cmbAbacusSearchType.Focus()
					Exit Sub
				End If

				strSearchType = Me.GetAbacusSearchType

				'*************************
				'Validate scan criteria
				'*************************
				Select Case strSearchType
					Case "Serial Number"
						'No validation
					Case "Tray ID"
						If Not IsNumeric(Trim(Me.txtAbacusSearchCriteria.Text)) Then
							MessageBox.Show("Invalid Tray ID.", "Validate Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
							Me.txtAbacusSearchCriteria.SelectAll()
							Exit Sub
						End If
					Case "Ship ID"
						If Not IsNumeric(Trim(Me.txtAbacusSearchCriteria.Text)) Then
							MessageBox.Show("Invalid Ship ID.", "Validate Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
							Me.txtAbacusSearchCriteria.SelectAll()
							Exit Sub
						End If
				End Select

				'********************************************
				'Get data base on search type and criteria
				'********************************************
				dt1 = Me.GobjMessAbacus.SearchAbacusData(strSearchType, _
				  Trim(Me.txtAbacusSearchCriteria.Text))
				dt2 = Me.GobjMessAbacus.SearchTverdataTable(strSearchType, _
				   Trim(Me.txtAbacusSearchCriteria.Text))
				'**************************
				'Set Datagrid
				'**************************
				Me.SetGridAbacusData(dt1)
				Me.SetGridAbacusRecData(dt2)
				'**************************

				Me.txtAbacusSearchCriteria.SelectAll()

			End If
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Search Item KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Function GetAbacusSearchType() As String
		Dim strSearchType As String = ""

		Select Case Me.cmbAbacusSearchType.SelectedIndex
			Case 1			  'Serial Number
				strSearchType = "Serial Number"
			Case 2			  'Tray ID
				strSearchType = "Tray ID"
			Case 3			  'Ship ID
				strSearchType = "Ship ID"
		End Select

		Return strSearchType
	End Function

	'*********************************************************
	Private Sub SetGridAbacusData(ByVal dt1 As DataTable)
		Dim i As Integer = 0
		Dim iMaxLen As Integer = 0
		Dim R1 As Object

		Try
			Me.grdAbacusData.DataSource = Nothing

			If dt1.Rows.Count > 0 Then
				Dim iNumOfColumns As Integer = grdAbacusData.Columns.Count

				Me.grdAbacusData.DataSource = dt1

				With Me.grdAbacusData
					'Heading style (Horizontal Alignment to Center)
					For i = 0 To (iNumOfColumns - 1)
						.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

						'Set individual column data horizontal alignment
						.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

						'Set Column Widths
						.Splits(0).DisplayColumns(i).Width = 100
					Next i

					'ReSet First Column Widths
					.Splits(0).DisplayColumns("Count").Width = 45

					'ReSet individual column data horizontal alignment
					.Splits(0).DisplayColumns("Count").Style.BackColor = Color.Bisque
					.Splits(0).DisplayColumns("PSS SN").Style.BackColor = Color.Bisque
					.Splits(0).DisplayColumns("PSS Old SN").Style.BackColor = Color.Bisque
					.Splits(0).DisplayColumns("Ship Date").Style.BackColor = Color.Bisque

				End With
			End If

			Me.grdAbacusData.Refresh()
		Catch ex As Exception
			Throw ex
		Finally
			R1 = Nothing
		End Try
	End Sub

	'*********************************************************
	Private Sub SetGridAbacusRecData(ByVal dt1 As DataTable)
		Dim i As Integer = 0
		Dim iMaxLen As Integer = 0
		Dim R1 As Object

		Try
			Me.grdAbacusRecData.DataSource = Nothing

			If dt1.Rows.Count > 0 Then
				Dim iNumOfColumns As Integer = Me.grdAbacusRecData.Columns.Count

				Me.grdAbacusRecData.DataSource = dt1

				With Me.grdAbacusRecData
					'Heading style (Horizontal Alignment to Center)
					For i = 0 To (iNumOfColumns - 1)
						.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

						'Set individual column data horizontal alignment
						.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

						'Set Column Widths
						.Splits(0).DisplayColumns(i).Width = 100
					Next i

					'ReSet First Column Widths
					.Splits(0).DisplayColumns(0).Width = 70

				End With
			End If

			Me.grdAbacusRecData.Refresh()
		Catch ex As Exception
			Throw ex
		Finally
			R1 = Nothing
		End Try
	End Sub

	'*********************************************************

#End Region

#Region "Tray Devision"

	'*********************************************************
	Private Sub ClearPage_DivideTray()
		Me.txtDT_TrayID.Text = ""
		Me.txtDT_MovedSN.Text = ""
		Me.lstDT_OriginalTraySNs.Items.Clear()
		Me.lstDT_OriginalTraySNs.Refresh()
		Me.lstDT_NewTraySNs.Items.Clear()
		Me.lstDT_NewTraySNs.Refresh()
		Me.lblDT_OriginalTrayQty.Text = Me.lstDT_OriginalTraySNs.Items.Count
		Me.lblDT_NewTrayQty.Text = Me.lstDT_NewTraySNs.Items.Count

		Me._dtDevices = Nothing

	End Sub

	'*********************************************************
	Private Sub txtDT_TrayID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDT_TrayID.KeyPress
		If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
			e.Handled = True
		End If
	End Sub

	'*********************************************************
	Private Sub txtDT_TrayID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDT_TrayID.KeyUp
		Dim R1 As DataRow
		Dim strTray_ID As String = ""

		Try
			If e.KeyValue = 13 Then
				strTray_ID = Me.txtDT_TrayID.Text.Trim

				'Reset all controls and global variable
				Me.ClearPage_DivideTray()
				Me.txtDT_TrayID.Text = strTray_ID

				If strTray_ID = "" Then
					Exit Sub
				End If

				Me._dtDevices = Me.GobjMessTrayMan.GetDevicesByTrayID(CInt(strTray_ID))
				If Not IsNothing(Me._dtDevices) Then
					For Each R1 In Me._dtDevices.Rows
						If IsDBNull(R1("Device_DateShip")) Then
							Me.lstDT_OriginalTraySNs.Items.Add(R1("Device_SN").ToString.ToUpper)
						End If
					Next R1
				End If

				Me.lblDT_OriginalTrayQty.Text = Me.lstDT_OriginalTraySNs.Items.Count
				Me.txtDT_MovedSN.Focus()
			End If
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "TrayID KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			R1 = Nothing
		End Try
	End Sub

	'*********************************************************
	Private Sub txtDT_MovedSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDT_MovedSN.KeyUp
		Dim R1 As DataRow

		Try
			If e.KeyValue = 13 Then
				If Me.txtDT_MovedSN.Text.Trim = "" Then
					Exit Sub
				End If

				'*****************************
				'Check for duplicate in list
				'*****************************
				If Me.lstDT_NewTraySNs.Items.IndexOf(Me.txtDT_MovedSN.Text.Trim.ToUpper) > -1 Then
					MsgBox("This serial number is already scanned.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "SN Scanning")
					Me.txtDT_MovedSN.SelectAll()
					Exit Sub
				End If

				'*****************************
				'Check for existing of SN
				'*****************************
				If Me.lstDT_OriginalTraySNs.Items.IndexOf(Me.txtDT_MovedSN.Text.Trim.ToUpper) = -1 Then
					MsgBox("This serial number does not belong to the tray or it was already shipped.", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "SN Scanning")
					Me.txtDT_MovedSN.SelectAll()
					Exit Sub
				End If

				For Each R1 In Me._dtDevices.Rows
					If R1("Device_SN").ToString.ToUpper = Me.txtDT_MovedSN.Text.Trim.ToUpper Then
						R1.BeginEdit()
						R1("NewTray") = 1
						R1.EndEdit()
						Me._dtDevices.AcceptChanges()
						Me.lstDT_NewTraySNs.Items.Add(Me.txtDT_MovedSN.Text.Trim.ToUpper)
						Me.lstDT_NewTraySNs.Refresh()
						Me.lstDT_OriginalTraySNs.Items.RemoveAt(Me.lstDT_OriginalTraySNs.Items.IndexOf(Me.txtDT_MovedSN.Text.Trim.ToUpper))
						Me.lstDT_OriginalTraySNs.Refresh()
						Exit For
					End If
				Next R1

				Me.lblDT_OriginalTrayQty.Text = Me.lstDT_OriginalTraySNs.Items.Count
				Me.lblDT_NewTrayQty.Text = Me.lstDT_NewTraySNs.Items.Count
				Me.txtDT_MovedSN.Text = ""
			End If
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Me.txtDT_MovedSN.SelectAll()
		Finally
			R1 = Nothing
		End Try
	End Sub

	'*********************************************************
	Private Sub btnDT_RemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDT_RemoveOne.Click
		Dim strSN As String = ""
		Dim R1 As DataRow

		Try
			If Me.lstDT_NewTraySNs.Items.Count = 0 Or Me.lstDT_OriginalTraySNs.Items.Count = 0 Then
				Me.txtDT_MovedSN.SelectAll()
				Me.txtDT_MovedSN.Focus()
				Exit Sub
			End If

			If IsNothing(Me._dtDevices) Then
				Me.txtDT_MovedSN.SelectAll()
				Me.txtDT_MovedSN.Focus()
				Exit Sub
			End If

			If Me._dtDevices.Select("NewTray = 1").Length = 0 Then
				Me.txtDT_MovedSN.SelectAll()
				Me.txtDT_MovedSN.Focus()
				Exit Sub
			End If

			strSN = InputBox("Scan SN to be removed from list:", "Remove One SN").Trim.ToUpper

			If strSN = "" Then
				Exit Sub
			End If

			If Me.lstDT_NewTraySNs.Items.IndexOf(strSN) = -1 Then
				MsgBox("This serial number is not listed.", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "SN Scanning")
			Else
				Me.lstDT_NewTraySNs.Items.RemoveAt(Me.lstDT_NewTraySNs.Items.IndexOf(strSN))
				Me.lstDT_NewTraySNs.Refresh()
				Me.lblDT_NewTrayQty.Text = Me.lstDT_NewTraySNs.Items.Count

				Me.lstDT_OriginalTraySNs.Items.Add(strSN)
				Me.lstDT_OriginalTraySNs.Refresh()
				Me.lblDT_OriginalTrayQty.Text = Me.lstDT_OriginalTraySNs.Items.Count

				For Each R1 In Me._dtDevices.Rows
					If R1("Device_SN").ToString.ToUpper = strSN Then
						R1.BeginEdit()
						R1("NewTray") = 0
						R1.EndEdit()
						Me._dtDevices.AcceptChanges()
						Exit For
					End If
				Next R1
			End If

			Me.txtDT_MovedSN.Focus()
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "RemoveOneSN Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub btnDT_RemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDT_RemoveAll.Click
		Dim R1 As DataRow

		Try
			If Me.lstDT_NewTraySNs.Items.Count = 0 Or Me.lstDT_OriginalTraySNs.Items.Count = 0 Then
				Me.txtDT_MovedSN.SelectAll()
				Me.txtDT_MovedSN.Focus()
				Exit Sub
			End If

			If IsNothing(Me._dtDevices) Then
				Me.txtDT_MovedSN.Text = ""
				Me.txtDT_TrayID.Focus()
				Exit Sub
			End If

			If Me._dtDevices.Select("NewTray = 1").Length = 0 Then
				Me.txtDT_MovedSN.SelectAll()
				Me.txtDT_MovedSN.Focus()
				Exit Sub
			End If

			If MessageBox.Show("Are you sure you want to REMOVE ALL the devices in the list?", "Remove ALL SN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
				Me.txtDT_MovedSN.Focus()
				Exit Sub
			End If

			Me.lstDT_NewTraySNs.Items.Clear()
			Me.lstDT_NewTraySNs.Refresh()
			Me.lstDT_OriginalTraySNs.Items.Clear()

			For Each R1 In Me._dtDevices.Rows
				If R1("NewTray") = 1 Then
					R1.BeginEdit()
					R1("NewTray") = 0
					R1.EndEdit()
					Me._dtDevices.AcceptChanges()
				End If
				Me.lstDT_OriginalTraySNs.Items.Add(R1("Device_SN").ToString.ToUpper)
			Next R1

			Me.lstDT_OriginalTraySNs.Refresh()
			Me.lblDT_OriginalTrayQty.Text = Me.lstDT_OriginalTraySNs.Items.Count.ToString
			Me.lblDT_NewTrayQty.Text = Me.lstDT_NewTraySNs.Items.Count.ToString

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "RemoveAllSNs Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			R1 = Nothing
		End Try
	End Sub

	'*********************************************************
	Private Sub btnST_SlitTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDT_DivideTray.Click
		Dim i As Integer = 0

		Try
			If IsNothing(Me._dtDevices) Then
				Me.txtDT_TrayID.Focus()
				Exit Sub
			End If

			If Me.lstDT_NewTraySNs.Items.Count = 0 Or Me._dtDevices.Select("NewTray = 1").Length = 0 Then
				Me.txtDT_MovedSN.Focus()
				Exit Sub
			End If

			If MessageBox.Show("Are you sure you want to DIVIDE tray?", "Divide Tray", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
				Me.txtDT_MovedSN.Focus()
				Exit Sub
			End If

			Me.Enabled = False
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

			i = Me.GobjMessTrayMan.DivideTray(Me._dtDevices, Me.GstrUserName, Me.GiUserID)

			Me.ClearPage_DivideTray()
			Me.txtDT_TrayID.Focus()

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "DivideTray Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			Me.Enabled = True
			Cursor.Current = System.Windows.Forms.Cursors.Default
		End Try
	End Sub

	'*********************************************************
	Private Sub btnDT_ClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDT_ClearAll.Click
		Me.ClearPage_DivideTray()
		Me.txtDT_TrayID.Focus()
	End Sub

#End Region

#Region "Shipment Summary"

	'*********************************************************
	Private Sub ClearPage_ShipmentSummary()
		Me.grdShipmentSummary.DataSource = Nothing
		Me.grdShipmentSummary.Visible = False
		Me.btnSSummary_Clear.Visible = False
		Me.btnSSummary_PrintAll.Visible = False
		Me.btnSSummary_printSelected.Visible = False
		Me.btnSSummary_CopyToExcel.Visible = False
		Me.txtSSummary_PkSlipID.Text = ""
	End Sub

	'*********************************************************
	Private Sub txtSSummary_PkSlipID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSSummary_PkSlipID.KeyPress
		If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
			e.Handled = True
		End If
	End Sub

	'*********************************************************
	Private Sub txtSSummary_PkSlipID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSSummary_PkSlipID.KeyUp

		If e.KeyValue = 13 Then
			PopulateWaitingShipmentGrid()
		End If
	End Sub

	'*********************************************************
	Private Sub dtpSSummary_pkslipCreationDate_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpSSummary_pkslipCreationDate.CloseUp
		PopulateWaitingShipmentGrid()
	End Sub

	'*********************************************************
	Private Sub btnSSummary_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSummary_Go.Click
		PopulateWaitingShipmentGrid()
	End Sub

	'*******************************************************************
	Private Sub PopulateWaitingShipmentGrid()
		Dim dt As DataTable
		Dim objSPPLF As New PSS.Data.Buisness.SendPalletPackingListFiles()
		Dim iPackingSlipID As Integer = 0
		Dim iGrandTotal As Integer = 0

		Try
			'Reset controls
			dt = Me.grdShipmentSummary.DataSource
			If Not IsNothing(dt) Then
				dt.Dispose()
				dt = Nothing
			End If
			Me.grdShipmentSummary.DataSource = Nothing
			Me.grdShipmentSummary.Visible = False
			Me.btnSSummary_PrintAll.Visible = False
			Me.btnSSummary_printSelected.Visible = False
			Me.btnSSummary_CopyToExcel.Visible = False

			'Validate Manifest ID (packing slip ID)
			If Me.txtSSummary_PkSlipID.Text.Trim <> "" AndAlso IsNumeric(Me.txtSSummary_PkSlipID.Text.Trim) = False Then
				MessageBox.Show("Manifest number is not in the correct format.", "Get Shipment Summary", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				Me.txtSSummary_PkSlipID.SelectAll()
				Me.txtSSummary_PkSlipID.Focus()
				Exit Sub
			End If

			If Me.txtSSummary_PkSlipID.Text.Trim <> "" Then
				iPackingSlipID = CInt(Me.txtSSummary_PkSlipID.Text.Trim)
			End If

			Me.Enabled = False
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

			'Get shipment summary data
			dt = objSPPLF.GetShipmentSummary(iPackingSlipID, Me.dtpSSummary_pkslipCreationDate.Text.Trim)
			If dt.Rows.Count = 0 Then
				MessageBox.Show("No data.", "Get Shipment Summary", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				Me.txtSSummary_PkSlipID.SelectAll()
				Me.txtSSummary_PkSlipID.Focus()
				Exit Sub
			End If

			'Set grid datasource and layout
			Me.grdShipmentSummary.DataSource = dt
			Me.grdShipmentSummary.Visible = True

			iGrandTotal = CInt(dt.Compute("Sum(Quantity)", "").ToString)

			Me.SetGridLayout(Me.grdShipmentSummary, _
			  Color.Blue, _
			  New Integer() {80, 152, 80, 70}, _
			  C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, _
			  New Integer() {C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Far}, _
			  iGrandTotal)

			'display buttons
			Me.grdShipmentSummary.Visible = True
			Me.btnSSummary_PrintAll.Visible = True
			Me.btnSSummary_printSelected.Visible = True
			Me.btnSSummary_Clear.Visible = True
			Me.btnSSummary_CopyToExcel.Visible = True
		Catch ex As Exception
			MessageBox.Show(ex.Message, "PopulateShipmentSummaryGrid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Me.grdShipmentSummary.DataSource = Nothing
			Me.grdShipmentSummary.Visible = False
			Me.btnSSummary_PrintAll.Visible = False
			Me.btnSSummary_printSelected.Visible = False
			Me.btnSSummary_CopyToExcel.Visible = False
		Finally
			objSPPLF = Nothing
			Me.Enabled = True
			Cursor.Current = System.Windows.Forms.Cursors.Default
			Me.txtSSummary_PkSlipID.SelectAll()
			Me.txtSSummary_PkSlipID.Focus()
		End Try
	End Sub

	'*******************************************************************
	Private Sub SetGridLayout(ByRef grdCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, _
	 ByVal clrHeaderForeColor As Color, _
	 ByVal iArrColSize() As Integer, _
	 ByVal iHeaderAlignment As Integer, _
	 ByVal iArrRowAlignment() As Integer, _
	 Optional ByVal iGrandTotal As Integer = 0)
		Dim iNumOfColumns As Integer = grdCtrl.Columns.Count
		Dim i As Integer

		With grdCtrl
			'Heading style (Horizontal Alignment to Center)
			For i = 0 To iNumOfColumns - 1
				.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = iHeaderAlignment				'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
				.Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = clrHeaderForeColor
				.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = iArrRowAlignment(i)				'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
				.Splits(0).DisplayColumns(i).Width = iArrColSize(i)
			Next i
			If iGrandTotal > 0 Then
				'.Splits(0).DisplayColumns("Frequency").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
				.ColumnFooters = True
				.Columns("Frequency").FooterText = "TOTAL"
				.Columns("Quantity").FooterText = iGrandTotal.ToString
			Else
				.ColumnFooters = False
			End If
		End With
	End Sub

	'*********************************************************
	Private Sub grdShipmentSummary_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdShipmentSummary.AfterFilter
		Dim iRow As Integer = 0
		Dim iGrandTotal As Integer = 0

		Try
			If Me.grdShipmentSummary.RowCount > 0 And Me.grdShipmentSummary.Columns.Count > 0 Then
				'loop through each selected row
				For iRow = 0 To Me.grdShipmentSummary.RowCount - 1
					'Calculate Grand Total
					iGrandTotal = iGrandTotal + CInt(Me.grdShipmentSummary.Columns("Quantity").CellText(iRow).ToString)
				Next iRow

				Me.grdShipmentSummary.ColumnFooters = True
				Me.grdShipmentSummary.Columns("Frequency").FooterText = "TOTAL"
				Me.grdShipmentSummary.Columns("Quantity").FooterText = iGrandTotal.ToString
			Else
				Me.grdShipmentSummary.ColumnFooters = False
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "Calculate Grand Total", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*********************************************************
	Private Sub btnSSummary_printSelected_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSSummary_printSelected.Click
		Dim strData As String
		Dim iRow As Integer = 0
		Dim iGrandTotal As Integer = 0
		Dim booCompleteHeader As Boolean = False
		Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
		Dim strHeader As String = ""
		Dim objSPSF As PSS.Data.Buisness.SendPalletPackingListFiles

		Try
			If Me.grdShipmentSummary.SelectedRows.Count > 0 And Me.grdShipmentSummary.SelectedCols.Count Then
				'loop through each selected row
				For Each iRow In Me.grdShipmentSummary.SelectedRows

					'loop through each selected column
					For Each col In Me.grdShipmentSummary.SelectedCols
						'header
						If booCompleteHeader = False Then
							strHeader = strHeader & col.Caption & vbTab
						End If
						'data
						strData = strData & col.CellText(iRow).ToString & vbTab

						'Calculate Grand Total
						If col.Caption = "Quantity" Then
							iGrandTotal = iGrandTotal + CInt(col.CellText(iRow).ToString)
						End If
					Next col

					'Add a new line to data
					strData = strData & vbCrLf

					'Stop collect header
					booCompleteHeader = True
				Next iRow

				'combine header, data and grand total
				strData = strHeader & vbCrLf & strData
				strData = strData & "" & vbTab & "" & vbTab & "Total" & vbTab & iGrandTotal.ToString & vbCrLf

				'Print Data
				objSPSF = New PSS.Data.Buisness.SendPalletPackingListFiles()
				objSPSF.CreateExelReportToPrint(strData, Chr(65 + Me.grdShipmentSummary.SelectedCols.Count - 1) & Me.grdShipmentSummary.SelectedRows.Count + 2)
				MessageBox.Show("Report has been printed out.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Else
				MessageBox.Show("Please select a range of cells to print.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			objSPSF = Nothing
			Me.txtSSummary_PkSlipID.SelectAll()
			Me.txtSSummary_PkSlipID.Focus()
		End Try
	End Sub

	'*********************************************************
	Private Sub btnSSummary_PrintAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSSummary_PrintAll.Click

		Try
			If Me.grdShipmentSummary.RowCount > 0 And Me.grdShipmentSummary.Columns.Count > 0 Then
				CopyShipmentSummaryDataToExcel(1)
			Else
				MessageBox.Show("No data to print.", "Print All Row", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Print All Row", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			' objSPSF = Nothing
			Me.txtSSummary_PkSlipID.SelectAll()
			Me.txtSSummary_PkSlipID.Focus()
		End Try
	End Sub

	'*********************************************************
	Private Sub btnSSummary_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSummary_Clear.Click
		Me.ClearPage_ShipmentSummary()
		Me.txtSSummary_PkSlipID.Focus()
	End Sub

	'*********************************************************
	Private Sub btnSSummary_CopyToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSSummary_CopyToExcel.Click

		Try
			If Me.grdShipmentSummary.RowCount > 0 And Me.grdShipmentSummary.Columns.Count > 0 Then
				CopyShipmentSummaryDataToExcel(2)
			Else
				MessageBox.Show("No data.", "Copy Data to Excel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Copy Data to Excel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			'objSPSF = Nothing
			Me.txtSSummary_PkSlipID.SelectAll()
			Me.txtSSummary_PkSlipID.Focus()
		End Try
	End Sub

	'*********************************************************
	Private Function CopyShipmentSummaryDataToExcel(ByVal iPrintOrDisplay As Integer)
		Dim strData As String = ""
		Dim iRow As Integer = 0
		Dim iGrandTotal As Integer = 0
		Dim booCompleteHeader As Boolean = False
		Dim strHeader As String = ""
		Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
		Dim objSPSF As PSS.Data.Buisness.SendPalletPackingListFiles

		Try
			If Me.grdShipmentSummary.RowCount > 0 And Me.grdShipmentSummary.Columns.Count > 0 Then
				'loop through each row
				For iRow = 0 To Me.grdShipmentSummary.RowCount - 1
					'loop through each column
					For Each col In Me.grdShipmentSummary.Columns
						'header
						If booCompleteHeader = False Then
							strHeader = strHeader & col.Caption & vbTab
						End If

						'Data
						strData = strData & col.CellText(iRow).ToString & vbTab

						'Calculate Grand Total
						If col.Caption = "Quantity" Then
							iGrandTotal = iGrandTotal + CInt(col.CellText(iRow).ToString)
						End If
					Next col

					'Add a new line to data
					strData = strData & vbCrLf

					'Stop collect header
					booCompleteHeader = True
				Next iRow

				'combine header, data and grand total
				strData = strHeader & vbCrLf & strData
				strData = strData & "" & vbTab & "" & vbTab & "Total" & vbTab & iGrandTotal.ToString & vbCrLf

				'Print data
				objSPSF = New PSS.Data.Buisness.SendPalletPackingListFiles()
				If iPrintOrDisplay = 1 Then
					objSPSF.CreateExelReportToPrint(strData, Chr(65 + Me.grdShipmentSummary.Columns.Count - 1) & Me.grdShipmentSummary.RowCount + 2, 1)
					MessageBox.Show("Report has been printed out.", "Copy/Print Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
				Else
					objSPSF.CreateExelReportToPrint(strData, Chr(65 + Me.grdShipmentSummary.Columns.Count - 1) & Me.grdShipmentSummary.RowCount + 2, 2)
				End If
			Else
				MessageBox.Show("No data.", "Copy/Print Data", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			End If
		Catch ex As Exception
			Throw ex
		Finally
			objSPSF = Nothing
		End Try
	End Function

	'*********************************************************

#End Region

#Region "Product Tracking"

	'*********************************************************
	Private Sub ClearPage_ProdTracking()
		Me.cboModel.SelectedValue = 0
		Me.cboFreq.SelectedValue = 0
		Me.txtAWAP.Text = ""
		Me.txtWeek01.Text = ""
		Me.txtWeek02.Text = ""
		Me.txtWeek03.Text = ""
		Me.txtWeek04.Text = ""
		Me.txtWeek05.Text = ""
		Me.chkSpecialProj.Checked = False
	End Sub

	'*******************************************************************
	Private Sub tabModelMaster_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles tabMsgProdTracker.DrawItem
		Try
			DrawTab(sender, e, Color.LightSteelBlue, Color.Blue, Color.AntiqueWhite, Color.Black)
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "Error in tabModelMaster_DrawItem")
		End Try
	End Sub

	'*******************************************************************
	Private Sub DrawTab(ByVal sender As Object, _
	  ByVal e As System.Windows.Forms.DrawItemEventArgs, _
	  ByVal FocusedBackColor As Color, _
	  ByVal FocusedForeColor As Color, _
	  ByVal NonFocusedBackColor As Color, _
	  ByVal NonFocusedForeColor As Color)
		Dim f As Font
		Dim backBrush, foreBrush As Brush
		Dim sf As StringFormat
		Dim strTabName As String
		Dim rect As Rectangle
		Dim r As RectangleF
		Dim iAddX(), iAddY(), iAddHeight(), iAddWidth() As Integer

		Try
			sf = New StringFormat()
			f = New Font(e.Font, FontStyle.Regular)

			ReDim iAddX(1)
			ReDim iAddY(1)
			ReDim iAddHeight(1)
			ReDim iAddWidth(1)

			If e.Index = Me.tabMsgProdTracker.SelectedIndex Then
				backBrush = New System.Drawing.SolidBrush(FocusedBackColor)
				foreBrush = New System.Drawing.SolidBrush(FocusedForeColor)

				Me.tabMsgProdTracker.TabPages(e.Index).BackColor = FocusedBackColor

				iAddX(0) = 4
				iAddY(0) = -6
				iAddWidth(0) = -6
				iAddHeight(0) = 3
				iAddX(1) = 1
				iAddY(1) = 4
			Else
				backBrush = New System.Drawing.SolidBrush(NonFocusedBackColor)
				foreBrush = New System.Drawing.SolidBrush(NonFocusedForeColor)

				Me.tabMsgProdTracker.TabPages(e.Index).BackColor = FocusedBackColor

				iAddX(0) = 1
				iAddY(0) = 0
				iAddWidth(0) = -1
				iAddHeight(0) = 1
				iAddX(1) = 0
				iAddY(1) = 4
			End If

			rect = New Rectangle(e.Bounds.X + iAddX(0), e.Bounds.Y + iAddY(0), e.Bounds.Width + iAddWidth(0), e.Bounds.Height + iAddHeight(0))

			sf.Alignment = StringAlignment.Center
			e.Graphics.FillRectangle(backBrush, rect)

			iAddWidth(1) = 0
			iAddHeight(1) = -4

			r = New RectangleF(e.Bounds.X + iAddX(1), e.Bounds.Y + iAddY(1), e.Bounds.Width + iAddWidth(1), e.Bounds.Height + iAddHeight(1))

			strTabName = Me.tabMsgProdTracker.TabPages(e.Index).Text
			e.Graphics.DrawString(strTabName, f, foreBrush, r, sf)
		Catch ex As Exception
			Throw ex
		Finally
			sf.Dispose()
			f.Dispose()
			backBrush.Dispose()
			foreBrush.Dispose()
		End Try
	End Sub

	'*******************************************************************
	Private Sub LoadFrequencies()
		Dim dt1 As DataTable

		Try
			dt1 = Me._objMsgGoalsDB.GetFrequencyData()
			dt1.LoadDataRow(New Object() {"-- Select --", "0"}, False)

			With Me.cboFreq
				.DisplayMember = dt1.Columns(0).ColumnName
				.ValueMember = dt1.Columns(1).ColumnName
				.DataSource = dt1
				.SelectedValue = 0
			End With
		Catch ex As Exception
			Me._objMsgGoalsDB.DisplayMessage(ex.Message)
		End Try
	End Sub

	'*******************************************************************
	Private Sub LoadMessagingWeeklyGoal()

		Try
			If Not IsNothing(Me._dtEditMsgWeeklyGoal) Then
				Me._dtEditMsgWeeklyGoal.Dispose()
				Me._dtEditMsgWeeklyGoal = Nothing
			End If

			Me.gridEditProdWeeklyGoal.ClearFields()
			Me.gridEditProdWeeklyGoal.DataSource = Nothing

			Me._dtEditMsgWeeklyGoal = Me._objMsgGoalsDB.GetExistingMsgWeeklyGoal()

			If IsNothing(Me._dtEditMsgWeeklyGoal) Then
				Exit Sub
			End If

			Me.gridEditProdWeeklyGoal.DataSource = Me._dtEditMsgWeeklyGoal

			Me.SetGridLayout_ProdTracker(Me.gridEditProdWeeklyGoal, _
			  Color.Black, _
			  New Integer() {180, 50, 65, 65, 65, 65, 65, 65, 65}, _
			  C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, _
			  New Integer() {AlignHorzEnum.Near, AlignHorzEnum.Center, AlignHorzEnum.Center, AlignHorzEnum.Center, AlignHorzEnum.Center, AlignHorzEnum.Center, AlignHorzEnum.Center, AlignHorzEnum.Center, AlignHorzEnum.Center}, _
			  New String() {"MsgWlyGoal_ID", "Model_ID", "freq_id", "IsNeedUpdate"}, , )
		Catch ex As Exception
			Me._objMsgGoalsDB.DisplayMessage(ex.Message)
		End Try
	End Sub

	'*******************************************************************
	Private Sub SetGridLayout_ProdTracker(ByRef grdCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, _
	 ByVal clrHeaderForeColor As Color, _
	 ByVal iArrColSize() As Integer, _
	 ByVal iHeaderAlignment As Integer, _
	 ByVal iArrColAlignment() As Integer, _
	 Optional ByVal strArrHideCol() As String = Nothing, _
	 Optional ByVal dtGrandtotal As DataTable = Nothing, _
	 Optional ByVal strPercentFormat() As String = Nothing, _
	 Optional ByVal iTotalWeeksOfMonth As Integer = 4)
		Dim iNumOfColumns As Integer = grdCtrl.Columns.Count
		Dim i As Integer
		Dim j As Integer
		Dim booPercentFormat As Boolean = False
		Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

		With grdCtrl
			'Heading style (Horizontal Alignment to Center)
			For i = 0 To iNumOfColumns - 1
				.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = iHeaderAlignment				'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
				.Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = clrHeaderForeColor
			Next i
			For i = 0 To iArrColSize.Length - 1
				.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = iArrColAlignment(i)				'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
				.Splits(0).DisplayColumns(i).Width = iArrColSize(i)
			Next i
			If Not IsNothing(strArrHideCol) Then
				For i = 0 To strArrHideCol.Length - 1
					.Splits(0).DisplayColumns(strArrHideCol(i)).Visible = False
				Next i
			End If

			'********************************
			'Grand Total
			'********************************
			If Not IsNothing(dtGrandtotal) Then
				'  iGrandTotal = 
				.ColumnFooters = True
				.Columns("Model").FooterText = "TOTAL"

				'loop through each column
				For Each col In grdCtrl.Columns
					If col.Caption <> "Model" Then
						If col.Caption = "% of Goal" Then
							If dtGrandtotal.Compute("Sum(Goal)", "") = 0 Then
								.Columns(col.Caption).FooterText = "0%"
							Else
								.Columns(col.Caption).FooterText = Format(((dtGrandtotal.Compute("Sum(Shipped)", "") / dtGrandtotal.Compute("Sum(Goal)", "")) * 100), "#,##0.000").ToString & "%"
							End If
						ElseIf col.Caption = "Monthly % of Goal" Then
							If dtGrandtotal.Compute("Sum(Goal)", "") = 0 Then
								.Columns(col.Caption).FooterText = "0%"
							Else
								.Columns(col.Caption).FooterText = Format((dtGrandtotal.Compute("Sum(MonthlyShip)", "") / (dtGrandtotal.Compute("Sum(Goal)", "") * iTotalWeeksOfMonth) * 100), "#,##0.000").ToString & "%"
							End If
						Else
							.Columns(col.Caption).FooterText = dtGrandtotal.Compute("Sum([" & col.Caption & "])", "").ToString
						End If
					End If
				Next col

				'********************************
				'Set percent format
				'********************************
				If Not IsNothing(strPercentFormat) Then
					For i = 0 To strPercentFormat.Length - 1
						.Columns(strPercentFormat(i)).NumberFormat = "Percent"
					Next i
				End If

				'********************************

			End If
		End With
	End Sub

	'*******************************************************************
	Private Sub WeeklyGoal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWeek01.KeyPress, txtWeek02.KeyPress, txtWeek03.KeyPress, txtWeek04.KeyPress, txtWeek05.KeyPress, txtAWAP.KeyPress
		If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
			e.Handled = True
		End If
	End Sub

	'*******************************************************************
	Private Sub gridEditProdWeeklyGoal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridEditProdWeeklyGoal.KeyPress
		If sender.Col = 0 Then
			e.Handled = True
		ElseIf e.KeyChar.IsControl(e.KeyChar) And e.KeyChar <> Microsoft.VisualBasic.ChrW(8) Then
			e.Handled = True
		ElseIf Not (e.KeyChar.IsDigit(e.KeyChar)) And e.KeyChar <> "." And e.KeyChar <> Microsoft.VisualBasic.ChrW(8) Then
			e.Handled = True
		End If
	End Sub

	'*******************************************************************
	Private Sub btnAddProdWlyGoal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProdWlyGoal.Click
		Dim i As Integer
		Dim iWeek01 As Integer = 0
		Dim iWeek02 As Integer = 0
		Dim iWeek03 As Integer = 0
		Dim iWeek04 As Integer = 0
		Dim iWeek05 As Integer = 0
		Dim iAWAP As Integer = 0
		Dim iSpecialProject As Integer = 0

		Try
			If Me.cboModel.SelectedValue = 0 Then
				MessageBox.Show("Please select model.", "AddProductWeeklyGoal_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				Me.cboModel.Focus()
			ElseIf MsgBox(String.Format("Add/Update data for {0}?", Me.cboModel.Text), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Add Data") = MsgBoxResult.Yes Then
				'*****************************************************
				' Search the grid to check if the entry already exists
				'*****************************************************
				If Me.gridEditProdWeeklyGoal.RowCount > 0 Then
					For i = 0 To Me.gridEditProdWeeklyGoal.RowCount - 1
						If Me.gridEditProdWeeklyGoal.Item(i, "Model") = Me.cboModel.Text And Me.gridEditProdWeeklyGoal.Item(i, "freq_id") = Me.cboFreq.SelectedValue Then
							Me._objMsgGoalsDB.DisplayMessage("This model and frequency already exists.")
							Exit Sub
						End If
					Next i
				End If

				'******************************
				'Get data and update in system
				'******************************
				If Me.cboFreq.SelectedValue > 0 Then
					iSpecialProject = 1
				ElseIf Me.chkSpecialProj.Checked = True Then
					iSpecialProject = 1
				End If
				If Me.txtWeek01.Text.Trim <> "" Then
					iWeek01 = CInt(Me.txtWeek01.Text.Trim)
				End If
				If Me.txtWeek02.Text.Trim <> "" Then
					iWeek02 = CInt(Me.txtWeek02.Text.Trim)
				End If
				If Me.txtWeek03.Text.Trim <> "" Then
					iWeek03 = CInt(Me.txtWeek03.Text.Trim)
				End If
				If Me.txtWeek04.Text.Trim <> "" Then
					iWeek04 = CInt(Me.txtWeek04.Text.Trim)
				End If
				If Me.txtWeek05.Text.Trim <> "" Then
					iWeek05 = CInt(Me.txtWeek05.Text.Trim)
				End If
				If Me.txtAWAP.Text.Trim <> "" Then
					iAWAP = CInt(txtAWAP.Text.Trim)
				End If

				i = Me._objMsgGoalsDB.UpdateMsgWeeklyGoalData(Me.cboModel.SelectedValue, Me.cboFreq.SelectedValue, iSpecialProject, iAWAP, iWeek01, iWeek02, iWeek03, iWeek04, iWeek05, )

				'***************************
				'Refresh data
				'***************************
				Me.LoadMessagingWeeklyGoal()
				Me.ClearPage_ProdTracking()
				'***************************
			End If
		Catch ex As Exception
			Me._objMsgGoalsDB.DisplayMessage(ex.Message)
		End Try
	End Sub

	'*******************************************************************
	Public Sub gridEditProdWeeklyGoal_DeleteRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridEditProdWeeklyGoal.KeyUp
		Try
			If Me.gridEditProdWeeklyGoal.Row > 0 And Not Me.gridEditProdWeeklyGoal.EditActive() Then
				If e.KeyValue = Keys.Delete Then
					If MsgBox(String.Format("Delete data for {0}?", Me.gridEditProdWeeklyGoal.Item(Me.gridEditProdWeeklyGoal.Row, "Model")), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Delete Data") = MsgBoxResult.Yes Then

						'***************************
						'Delete data
						'***************************
						Me._objMsgGoalsDB.DeleteMsgWeeklyGoalData(Me.gridEditProdWeeklyGoal.Item(Me.gridEditProdWeeklyGoal.Row, "MsgWlyGoal_ID"))

						'***************************
						'Refresh data
						'***************************
						Me.LoadMessagingWeeklyGoal()
						'***************************
					End If
				End If
			End If
		Catch ex As Exception
			Me._objMsgGoalsDB.DisplayMessage(ex.Message)
		End Try
	End Sub

	'*******************************************************************
	Private Sub gridEditProdWeeklyGoal_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles gridEditProdWeeklyGoal.AfterColUpdate
		Dim R1 As DataRow
		Dim i As Integer
		Dim booFound As Boolean = False

		Try
			'User select a row and column is not Model
			If sender.row >= 0 And sender.Col <> 0 Then
				If (sender.col = 1 Or sender.col = 2) And sender.Columns(sender.Col).Text.trim = "" Or sender.Columns(sender.Col).Text.trim = "0" Then
					sender.Columns("Frequency").Text = 0
					sender.Columns("freq_id").Text = 0
					sender.Columns("Special").Text = 0
					Application.DoEvents()
					booFound = True
				ElseIf sender.Col = 2 And sender.Columns(sender.Col).Text.trim <> "" And sender.Columns(sender.Col).Text.trim <> "0" Then
					For i = 0 To Me.cboFreq.Items.Count - 1
						If Me.cboFreq.Items(i)("freq_number") = sender.Columns(sender.Col).Text Then
							sender.Columns("freq_id").Text = Me.cboFreq.Items(i)("freq_id")
							sender.Columns("Special").Text = 1
							Application.DoEvents()
							booFound = True
							Exit For
						End If
					Next i
				Else
					booFound = True
				End If

				If booFound = True Then

					'******************************
					' Check for duplicate in grid
					'******************************
					If Me.gridEditProdWeeklyGoal.RowCount > 0 Then
						For i = 0 To Me.gridEditProdWeeklyGoal.RowCount - 1
							If i <> Me.gridEditProdWeeklyGoal.Row Then
								If Me.gridEditProdWeeklyGoal.Item(i, "Model") = Me.gridEditProdWeeklyGoal.Item(Me.gridEditProdWeeklyGoal.Row, "Model") And Me.gridEditProdWeeklyGoal.Item(i, "freq_id") = Me.gridEditProdWeeklyGoal.Item(Me.gridEditProdWeeklyGoal.Row, "freq_id") Then
									Me._objMsgGoalsDB.DisplayMessage("This model and frequency already exists.")
									Me.LoadMessagingWeeklyGoal()
									Exit Sub
								End If
							End If
						Next i
					End If
					'******************************

					R1 = Me._dtEditMsgWeeklyGoal.Rows(sender.row)
					R1("IsNeedUpdate") = 1

					Me._dtEditMsgWeeklyGoal.AcceptChanges()

					If sender.Columns(sender.Col).Text.trim = "" Then
						sender.Columns(sender.Col).Text = 0
					End If
				Else
					MessageBox.Show(sender.Columns(sender.Col).Text & " is not a valid frequency ", "Update Frequency", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.LoadMessagingWeeklyGoal()
				End If
			End If
		Catch ex As Exception
			Me._objMsgGoalsDB.DisplayMessage(ex.Message)
		Finally
			R1 = Nothing
		End Try
	End Sub

	'*******************************************************************
	Private Sub gridEditProdWeeklyGoal_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles gridEditProdWeeklyGoal.RowColChange
		Dim R1 As DataRow

		Try
			If IsNothing(Me._dtEditMsgWeeklyGoal) Then
				Exit Sub
			End If

			If Me._dtEditMsgWeeklyGoal.Select("IsNeedUpdate = 1").Length > 0 Then
				For Each R1 In Me._dtEditMsgWeeklyGoal.Rows
					If R1("IsNeedUpdate") = 1 Then
						Me._objMsgGoalsDB.UpdateMsgWeeklyGoalData(R1("Model_ID"), R1("freq_id"), R1("Special"), R1("AWAP"), R1("Week 01"), R1("Week 02"), R1("Week 03"), R1("Week 04"), R1("Week 05"), R1("MsgWlyGoal_ID"))
						R1("IsNeedUpdate") = 0
					End If
				Next R1

				Me._dtEditMsgWeeklyGoal.AcceptChanges()

			End If
		Catch ex As Exception
			Me._objMsgGoalsDB.DisplayMessage(ex.Message)
		Finally
			R1 = Nothing
		End Try
	End Sub

	'*******************************************************************
	Private Function LoadProdTrackerData()
		Dim dt1 As DataTable
		Dim iTotalWeeksOfMonth As Integer = 0

		Try
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			Me.Enabled = False
			'**********************************
			'Normal Production Plan
			'**********************************
			dt1 = Me.gridNormalProdTracker.DataSource

			If Not IsNothing(dt1) Then
				dt1.Dispose()
				dt1 = Nothing
			End If

			Me.gridNormalProdTracker.ClearFields()
			Me.gridNormalProdTracker.DataSource = Nothing
			dt1 = Me._objMsgGoalsDB.LoadMsgProdTracker_Data(Me.lblWeeklyRange, Me.lblMonthlyRange, iTotalWeeksOfMonth, 0)
			If dt1.Rows.Count > 0 Then
				Me.gridNormalProdTracker.DataSource = dt1
				Me.SetGridLayout_ProdTracker(Me.gridNormalProdTracker, _
				 Color.Black, _
				 New Integer() {190, 50, 60, 60, 95, 60, 80, 60, 110}, _
				 AlignHorzEnum.Center, _
				 New Integer() {AlignHorzEnum.Near, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far}, _
				 New String() {"MonthlyShip"}, dt1, _
				 New String() {"% of Goal", "Monthly % of Goal"}, iTotalWeeksOfMonth)
			End If

			'**********************************
			'Special Project
			'**********************************
			dt1 = Nothing
			dt1 = Me.gridSpecialProdTracker.DataSource

			If Not IsNothing(dt1) Then
				dt1.Dispose()
				dt1 = Nothing
			End If

			Me.gridSpecialProdTracker.ClearFields()
			Me.gridSpecialProdTracker.DataSource = Nothing
			dt1 = Me._objMsgGoalsDB.LoadMsgProdTracker_Data(Me.lblWeeklyRange, Me.lblMonthlyRange, iTotalWeeksOfMonth, 1)
			If dt1.Rows.Count > 0 Then
				Me.gridSpecialProdTracker.DataSource = dt1
				Me.SetGridLayout_ProdTracker(Me.gridSpecialProdTracker, _
				 Color.Black, _
				 New Integer() {190, 50, 60, 60, 95, 60, 80, 60, 110}, _
				 AlignHorzEnum.Center, _
				 New Integer() {AlignHorzEnum.Near, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far, AlignHorzEnum.Far}, _
				 New String() {"MonthlyShip"}, dt1, _
				 New String() {"% of Goal", "Monthly % of Goal"}, iTotalWeeksOfMonth)
			End If
			'**********************************

		Catch ex As Exception
			Me._objMsgGoalsDB.DisplayMessage(ex.Message)
		Finally
			Me.Enabled = True
			Cursor.Current = System.Windows.Forms.Cursors.Default
		End Try
	End Function

	'*******************************************************************
	Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
		Try
			LoadProdTrackerData()
		Catch ex As Exception
			Me._objMsgGoalsDB.DisplayMessage(ex.Message)
		End Try
	End Sub

	'*******************************************************************
	Private Sub btnCopyNormalProdTracker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyNormalProdTracker.Click
		Dim strData As String = ""
		Dim iRow As Integer = 0
		Dim iCol As Integer = 0
		Dim iGrandTotal As Integer = 0
		Dim booCompleteHeader As Boolean = False
		Dim strHeader As String = ""
		Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
		Dim dtProd As DataTable
		Dim dtSpecial As DataTable

		Try
			Me.Enabled = False

			dtProd = Me.gridNormalProdTracker.DataSource
			dtSpecial = Me.gridSpecialProdTracker.DataSource

			If Not IsNothing(dtProd) Or Not IsNothing(dtSpecial) Then
				'Display data
				Me._objMsgGoalsDB.CreateMsgProdTrackerExelReport(dtProd, dtSpecial, Me.lblWeeklyRange.Text.Split(" ")(3))
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "CopyDataToExcel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			Me.Enabled = True
			dtProd = Nothing
			dtSpecial = Nothing
		End Try
	End Sub

	'*******************************************************************
	Private Sub cboModel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.Leave
		Dim i As Integer = 0
		Dim booFound As Boolean = False

		Try
			If Me.cboModel.Text <> "-- Select --" Then
				For i = 0 To Me.cboModel.Items.Count - 1
					If Me.cboModel.Text = Me.cboModel.Items(i)("model_desc") Then
						Me.cboModel.SelectedValue = Me.cboModel.Items(i)("model_id")
						booFound = True
						Exit Sub
					End If
				Next i
				If booFound = False Then
					Me.cboModel.SelectedValue = 0
				End If
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, "cboModel_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'*******************************************************************
	Private Sub txtWeeklyGoal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWeek01.KeyUp, txtWeek02.KeyUp, txtWeek03.KeyUp, txtWeek04.KeyUp, txtWeek05.KeyUp
		If e.KeyValue = 13 Then
			Select Case sender.name
				Case "txtWeek01"
					Me.txtWeek02.SelectAll()
					Me.txtWeek02.Focus()
				Case "txtWeek02"
					Me.txtWeek03.SelectAll()
					Me.txtWeek03.Focus()
				Case "txtWeek03"
					Me.txtWeek04.SelectAll()
					Me.txtWeek04.Focus()
				Case "txtWeek04"
					Me.txtWeek05.SelectAll()
					Me.txtWeek05.Focus()
			End Select
		End If
	End Sub

	'*******************************************************************
	Private Sub combo_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectionChangeCommitted, cboFreq.SelectionChangeCommitted
		Select Case sender.name
			Case "cboModel"
				Me.cboFreq.Focus()
			Case "cboFreq"
				Me.txtWeek01.Focus()
		End Select
	End Sub

	'*******************************************************************
	Private Sub btnClearProdWlyGoal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearProdWlyGoal.Click
		Me.ClearPage_ProdTracking()
	End Sub

	'*******************************************************************

#End Region

#Region "Build Ship Pallet"

	'***********************************************************************************
	Private Sub ClearPage_BuildShipPallet()
		Me.txtBSP_ShipID.Text = ""
		Me.lstBSP_ShipIDs.Items.Clear()
		Me.lstBSP_ShipIDs.Refresh()
		Me.lblBSP_DevQty.Text = "0"
		Me.lblBSP_ScanQty.Text = "0"
	End Sub

	'***********************************************************************************
	Private Sub txtBSP_ShipID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBSP_ShipID.KeyUp
		Dim i As Integer = 0
		Dim iItemExisted As Integer = 0

		Try
			If e.KeyValue = 13 Then

				If Me.txtBSP_ShipID.Text.Trim.Length = 0 Then Exit Sub

				If Not IsNumeric(Me.txtBSP_ShipID.Text.Trim) Then
					MessageBox.Show("This is not a valid Ship ID.", "Scan in Ship ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
					Me.txtBSP_ShipID.SelectAll() : Me.txtBSP_ShipID.Focus() : Exit Sub
				ElseIf Me.lstBSP_ShipIDs.Items.IndexOf(Me.txtBSP_ShipID.Text.Trim) > -1 Then
					MessageBox.Show("This item is already scanned in. Try another one.", "Scan in Items", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
					Me.txtBSP_ShipID.SelectAll() : Me.txtBSP_ShipID.Focus() : Exit Sub
				End If

				'*********************************
				'Check if item existed in database
				'*********************************
				iItemExisted = Me._objMessReports.GetDeviceNoInShipManifest(CInt(Me.txtBSP_ShipID.Text))

				'********************
				'add item to listbox
				'********************
				If iItemExisted > 0 Then
					Me.lstBSP_ShipIDs.Items.Add(Me.txtBSP_ShipID.Text.Trim)
					Me.lstBSP_ShipIDs.Refresh() : Me.lstBSP_ShipIDs.Text = ""
					If Me.lstBSP_ShipIDs.Items.Count = 0 Then
						Me.lblBSP_DevQty.Text = "0"
					Else
						Me.lblBSP_DevQty.Text = Me._objMessReports.GetTotalDevInList("Ship_ID", Me.lstBSP_ShipIDs)
					End If
					Me.lblBSP_ScanQty.Text = Me.lstBSP_ShipIDs.Items.Count.ToString
					Me.txtBSP_ShipID.Text = ""
				Else
					MessageBox.Show("Ship ID is empty.", "Check Devices in Ship ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtBSP_ShipID.SelectAll() : Me.txtBSP_ShipID.Focus()
				End If
				'*****************************************
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message, "txtBSP_ShipID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Me.txtBSP_ShipID.SelectAll() : Me.txtBSP_ShipID.Focus()
		End Try
	End Sub

	'***********************************************************************************
	Private Sub btnBSP_CreatePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSP_CreatePallet.Click
		Dim iPalletID As Integer = 0
		Dim strWorkDate, strPalletName As String
		Dim dt As DataTable

		Try
			Cursor.Current = Cursors.WaitCursor : Me.Enabled = False

			strWorkDate = "" : strPalletName = ""

			If Me.lstBSP_ShipIDs.Items.Count = 0 Then Exit Sub

			strWorkDate = PSS.Data.Buisness.Generic.GetWorkDate(Core.ApplicationUser.IDShift)
			iPalletID = _objMessReports.CreateShipPallet(Me.lstBSP_ShipIDs, Core.ApplicationUser.IDuser, strWorkDate, CInt(Me.lblBSP_DevQty.Text.Trim), strPalletName)

			If iPalletID > 0 Then
				Me.ClearPage_BuildShipPallet()
				PrintPalletLabel(strPalletName)				'Print pallet lable

				MessageBox.Show("Pallet is created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End If

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Create Ship Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		Finally
			Generic.DisposeDT(dt)
			Me.Enabled = True : Cursor.Current = Cursors.Default
			GC.Collect() : GC.WaitForPendingFinalizers()
		End Try
	End Sub

	'***********************************************************************************
	Private Sub btnBSP_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBSP_Clear.Click
		Dim strItem As String = ""
		Dim i As Integer = 0

		Try
			If Me.lstBSP_ShipIDs.Items.Count = 0 Then Exit Sub

			'************************
			strItem = InputBox("Enter Item:", "Remove Item")
			If strItem = "" Then
				MessageBox.Show("Please enter an item if you want to remove it from the list.", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
				Exit Sub
			End If

			If Me.lstBSP_ShipIDs.Items.IndexOf(strItem) > -1 Then
				Me.lstBSP_ShipIDs.Items.RemoveAt(i)
				Me.lstBSP_ShipIDs.Refresh()
				If Me.lstBSP_ShipIDs.Items.Count = 0 Then
					Me.lblBSP_DevQty.Text = "0"
				Else
					Me.lblBSP_DevQty.Text = Me._objMessReports.GetTotalDevInList("Ship_ID", Me.lstBSP_ShipIDs)
				End If
				Me.lblBSP_ScanQty.Text = Me.lstBSP_ShipIDs.Items.Count.ToString
			Else
				MessageBox.Show("This item is not listed.", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
			End If

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Clear One Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'***********************************************************************************
	Private Sub btnBSP_ClearAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBSP_ClearAll.Click
		Try
			If MessageBox.Show("Are you sure you want to clear all items in the list?", "Clear List", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
				Exit Sub
			ElseIf Me.lstBSP_ShipIDs.Items.Count = 0 Then
				Exit Sub
			End If

			Me.lstBSP_ShipIDs.Items.Clear()
			Me.lstBSP_ShipIDs.Refresh()
			Me.lblBSP_DevQty.Text = "0"
			Me.lblBSP_ScanQty.Text = "0"

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "Clear All Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'***********************************************************************************
	Private Sub btnBSP_RepintPalletLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBSP_RepintPalletLabel.Click
		Dim strPalletName As String = ""

		Try
			strPalletName = InputBox("Enter Pallet Name:").Trim
			If strPalletName.Trim.Length > 0 Then PrintPalletLabel(strPalletName)

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "btnBSP_RepintPalletLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
	End Sub

	'***********************************************************************************
	Private Sub PrintPalletLabel(ByVal strPalletName As String)
		Dim dt As DataTable
		Const strReportName As String = "Ship Pallet Label Push.rpt"
		Dim dtShipPalletRpt As DataTable
		Dim objDBRManf As New PSS.Data.Buisness.DBRManifest()
		Dim objRpt As ReportDocument

		Try
			dt = PSS.Data.Production.Shipping.GetPalletInfoByName(strPalletName, 14)
			If dt.Rows.Count = 0 Then
				MessageBox.Show("Pallet does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
			Else
				dtShipPalletRpt = objDBRManf.GetShipPalletData(dt.Rows(0)("Pallett_Name").ToString, Convert.ToInt32(dt.Rows(0)("Pallett_QTY")), "", "", New String() {"NER Verification:", "Material Verification:", "Shipper Verification:"})

				If Not IsNothing(dtShipPalletRpt) Then
					objRpt = New ReportDocument()

					With objRpt
						.Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
						.SetDataSource(dtShipPalletRpt)
						.PrintToPrinter(2, True, 0, 0)
					End With
				End If
			End If
		Catch ex As Exception
			Throw ex
		Finally
			Generic.DisposeDT(dtShipPalletRpt)
			objDBRManf = Nothing : objRpt = Nothing
		End Try
	End Sub

	'***********************************************************************************
#End Region



    Private Sub tpgAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpgAdmin.Click

    End Sub

    
End Class
