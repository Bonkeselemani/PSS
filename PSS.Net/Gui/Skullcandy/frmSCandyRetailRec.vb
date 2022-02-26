
Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmSCandyRetailRec
        Inherits System.Windows.Forms.Form

        Private Const strPalletManifestPath As String = "\\phq-file\public\Dept\SkullCandy\Retail\Pallet Packing List\"
        Private _iMenuCustID As Integer
        Private _iMenuLocID As Integer
        Private _objSkullCandy As Data.Buisness.Skullcandy
        Private _strReportName As String = ""
        Private _booLoadData As Boolean = False
        Private _dsShip As New DataSet()

#Region " Windows Form Designer generated code "

            Public Sub New(ByVal iCustID As Integer, ByVal iLocID As Integer)
                MyBase.New()

                'This call is required by the Windows Form Designer.
                InitializeComponent()

                'Add any initialization after the InitializeComponent() call
                _iMenuCustID = iCustID
                _iMenuLocID = iLocID

                _objSkullCandy = New Data.Buisness.Skullcandy()
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
            Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
            Friend WithEvents tpRec As System.Windows.Forms.TabPage
            Friend WithEvents tpDockShip As System.Windows.Forms.TabPage
            Friend WithEvents tpReports As System.Windows.Forms.TabPage
            Friend WithEvents Label3 As System.Windows.Forms.Label
            Friend WithEvents Label1 As System.Windows.Forms.Label
            Friend WithEvents Label2 As System.Windows.Forms.Label
            Friend WithEvents txtRec_RMA As System.Windows.Forms.TextBox
            Friend WithEvents txtRec_UPC As System.Windows.Forms.TextBox
            Friend WithEvents cboRec_Dispostion As C1.Win.C1List.C1Combo
            Friend WithEvents Panel4 As System.Windows.Forms.Panel
            Friend WithEvents Label26 As System.Windows.Forms.Label
            Friend WithEvents lblRec_RMACount As System.Windows.Forms.Label
            Friend WithEvents Label31 As System.Windows.Forms.Label
            Friend WithEvents lblRec_UserCount As System.Windows.Forms.Label
            Friend WithEvents Label35 As System.Windows.Forms.Label
            Friend WithEvents lblRec_DailyCount As System.Windows.Forms.Label
            Friend WithEvents btnRec_RefreshCount As System.Windows.Forms.Button
            Friend WithEvents dbgRec_ReceivedCnt As C1.Win.C1TrueDBGrid.C1TrueDBGrid
            Friend WithEvents Label4 As System.Windows.Forms.Label
            Friend WithEvents lblEndDate As System.Windows.Forms.Label
            Friend WithEvents lblStartDate As System.Windows.Forms.Label
            Friend WithEvents gbRpt_Date As System.Windows.Forms.GroupBox
            Friend WithEvents dtpRpt_StartDate As System.Windows.Forms.DateTimePicker
            Friend WithEvents btnRpt_RunRpt As System.Windows.Forms.Button
            Friend WithEvents dtpRpt_EndDate As System.Windows.Forms.DateTimePicker
            Friend WithEvents cboRpt_ReportName As System.Windows.Forms.ComboBox
            Friend WithEvents gbRec_ClosePallet As System.Windows.Forms.GroupBox
            Friend WithEvents Label5 As System.Windows.Forms.Label
            Friend WithEvents cboRec_ClosePalletDisposition As C1.Win.C1List.C1Combo
            Friend WithEvents btnRec_ClosePallet As System.Windows.Forms.Button
            Friend WithEvents lblRec_OpenPalletQty As System.Windows.Forms.Label
            Friend WithEvents Label6 As System.Windows.Forms.Label
            Friend WithEvents btnRec_ReprintPalletLabel As System.Windows.Forms.Button
            Friend WithEvents txtRec_CopyQty As System.Windows.Forms.TextBox
            Friend WithEvents lblPalletName As System.Windows.Forms.Label
            Friend WithEvents lblQty As System.Windows.Forms.Label
            Friend WithEvents Label7 As System.Windows.Forms.Label
            Friend WithEvents pnlBox As System.Windows.Forms.Panel
            Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
            Friend WithEvents rbtnByRMA As System.Windows.Forms.RadioButton
            Friend WithEvents rbtnByRMAUPC As System.Windows.Forms.RadioButton
            Friend WithEvents rbtnDetails As System.Windows.Forms.RadioButton
            Friend WithEvents btnCreateShip As System.Windows.Forms.Button
            Friend WithEvents lblDisposition As System.Windows.Forms.Label
            Friend WithEvents pnlQty As System.Windows.Forms.Panel
            Friend WithEvents lblPalletNameSelected As System.Windows.Forms.Label
            Friend WithEvents tpBuildShipPallet As System.Windows.Forms.TabPage
            Friend WithEvents Label8 As System.Windows.Forms.Label
            Friend WithEvents pnlShipType As System.Windows.Forms.Panel
            Friend WithEvents Button5 As System.Windows.Forms.Button
            Friend WithEvents Label11 As System.Windows.Forms.Label
            Friend WithEvents lblBSP_PalletName As System.Windows.Forms.Label
            Friend WithEvents pnlBSP_PalletList As System.Windows.Forms.Panel
            Friend WithEvents btnBSP_Reopen As System.Windows.Forms.Button
            Friend WithEvents btnBSP_CreatePalletID As System.Windows.Forms.Button
            Friend WithEvents lblBSP_PalletQty As System.Windows.Forms.Label
            Friend WithEvents txtBSP_MasterPack As System.Windows.Forms.TextBox
            Friend WithEvents lstBSP_MasterPacks As System.Windows.Forms.ListBox
            Friend WithEvents lblBSP_MasterpackQty As System.Windows.Forms.Label
            Friend WithEvents pnlBSP_Pallet As System.Windows.Forms.Panel
            Friend WithEvents cboBSP_Dispostion As C1.Win.C1List.C1Combo
            Friend WithEvents dgLocQty As C1.Win.C1TrueDBGrid.C1TrueDBGrid
            Friend WithEvents dbgRec_Location As C1.Win.C1TrueDBGrid.C1TrueDBGrid
            Friend WithEvents btnBSP_RemoveAllMPIDs As System.Windows.Forms.Button
            Friend WithEvents btnBSP_RemoveMPID As System.Windows.Forms.Button
            Friend WithEvents lblBSP_MPDesc As System.Windows.Forms.Label
            Friend WithEvents lblBSP_MPQtyDesc As System.Windows.Forms.Label
            Friend WithEvents btnRec_CloseLoc As System.Windows.Forms.Button
            Friend WithEvents dbgBSP_Pallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
            Friend WithEvents btnBSP_ClosePallet As System.Windows.Forms.Button
        Friend WithEvents btnBSP_DeletePallet As System.Windows.Forms.Button
        Friend WithEvents btnBSP_RefreshPalletList As System.Windows.Forms.Button
            Friend WithEvents Label9 As System.Windows.Forms.Label
            Friend WithEvents txtBSP_WHLocation As System.Windows.Forms.TextBox
            Friend WithEvents tpLocation As System.Windows.Forms.TabPage
            Friend WithEvents dbgLoc_Data As C1.Win.C1TrueDBGrid.C1TrueDBGrid
            Friend WithEvents btnLocRefreshData As System.Windows.Forms.Button
            Friend WithEvents txtPalletName As System.Windows.Forms.TextBox
            Friend WithEvents Label10 As System.Windows.Forms.Label
            Friend WithEvents txtRec_IPMPPrinterName As System.Windows.Forms.TextBox
            Friend WithEvents Label12 As System.Windows.Forms.Label
            Friend WithEvents gbRec_Reprint As System.Windows.Forms.GroupBox
            Friend WithEvents btnRec_ReprintLabel As System.Windows.Forms.Button
            Friend WithEvents txtRec_LabelTypeVal As System.Windows.Forms.TextBox
            Friend WithEvents lblRec_LabelType As System.Windows.Forms.Label
            Friend WithEvents cboRec_LabelTypes As System.Windows.Forms.ComboBox
            Friend WithEvents Label14 As System.Windows.Forms.Label
            Friend WithEvents txtRec_DevicePrinterName As System.Windows.Forms.TextBox
            Friend WithEvents Label13 As System.Windows.Forms.Label
            Friend WithEvents txtRec_ReprintQty As System.Windows.Forms.TextBox
        Friend WithEvents btnPrintNextQCAuditRpt As System.Windows.Forms.Button
        Friend WithEvents btnPrintAllQCAuditRpt As System.Windows.Forms.Button
        Friend WithEvents btnBSP_Reprint As System.Windows.Forms.Button
        Friend WithEvents gbBSP_Reprint As System.Windows.Forms.GroupBox
        Friend WithEvents cboBSP_ReprintType As System.Windows.Forms.ComboBox
        Friend WithEvents btnRecreatPalletDetail As System.Windows.Forms.Button
        Friend WithEvents lblLoc_Count As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSCandyRetailRec))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpRec = New System.Windows.Forms.TabPage()
            Me.btnPrintAllQCAuditRpt = New System.Windows.Forms.Button()
            Me.btnPrintNextQCAuditRpt = New System.Windows.Forms.Button()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtRec_DevicePrinterName = New System.Windows.Forms.TextBox()
            Me.gbRec_Reprint = New System.Windows.Forms.GroupBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.txtRec_ReprintQty = New System.Windows.Forms.TextBox()
            Me.lblRec_LabelType = New System.Windows.Forms.Label()
            Me.txtRec_LabelTypeVal = New System.Windows.Forms.TextBox()
            Me.cboRec_LabelTypes = New System.Windows.Forms.ComboBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.btnRec_ReprintLabel = New System.Windows.Forms.Button()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtRec_IPMPPrinterName = New System.Windows.Forms.TextBox()
            Me.btnRec_CloseLoc = New System.Windows.Forms.Button()
            Me.dbgRec_Location = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.gbRec_ClosePallet = New System.Windows.Forms.GroupBox()
            Me.btnRec_ReprintPalletLabel = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtRec_CopyQty = New System.Windows.Forms.TextBox()
            Me.lblRec_OpenPalletQty = New System.Windows.Forms.Label()
            Me.btnRec_ClosePallet = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cboRec_ClosePalletDisposition = New C1.Win.C1List.C1Combo()
            Me.dbgRec_ReceivedCnt = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.lblRec_DailyCount = New System.Windows.Forms.Label()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.lblRec_RMACount = New System.Windows.Forms.Label()
            Me.Label31 = New System.Windows.Forms.Label()
            Me.lblRec_UserCount = New System.Windows.Forms.Label()
            Me.Label35 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboRec_Dispostion = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtRec_UPC = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtRec_RMA = New System.Windows.Forms.TextBox()
            Me.btnRec_RefreshCount = New System.Windows.Forms.Button()
            Me.tpBuildShipPallet = New System.Windows.Forms.TabPage()
            Me.pnlBSP_PalletList = New System.Windows.Forms.Panel()
            Me.gbBSP_Reprint = New System.Windows.Forms.GroupBox()
            Me.cboBSP_ReprintType = New System.Windows.Forms.ComboBox()
            Me.btnBSP_Reprint = New System.Windows.Forms.Button()
            Me.btnRecreatPalletDetail = New System.Windows.Forms.Button()
            Me.btnBSP_RefreshPalletList = New System.Windows.Forms.Button()
            Me.btnBSP_DeletePallet = New System.Windows.Forms.Button()
            Me.btnBSP_Reopen = New System.Windows.Forms.Button()
            Me.dbgBSP_Pallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.pnlShipType = New System.Windows.Forms.Panel()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.btnBSP_CreatePalletID = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cboBSP_Dispostion = New C1.Win.C1List.C1Combo()
            Me.pnlBSP_Pallet = New System.Windows.Forms.Panel()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtBSP_WHLocation = New System.Windows.Forms.TextBox()
            Me.lblBSP_PalletQty = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtBSP_MasterPack = New System.Windows.Forms.TextBox()
            Me.lblBSP_MPDesc = New System.Windows.Forms.Label()
            Me.btnBSP_RemoveAllMPIDs = New System.Windows.Forms.Button()
            Me.btnBSP_RemoveMPID = New System.Windows.Forms.Button()
            Me.lstBSP_MasterPacks = New System.Windows.Forms.ListBox()
            Me.lblBSP_MasterpackQty = New System.Windows.Forms.Label()
            Me.lblBSP_MPQtyDesc = New System.Windows.Forms.Label()
            Me.lblBSP_PalletName = New System.Windows.Forms.Label()
            Me.btnBSP_ClosePallet = New System.Windows.Forms.Button()
            Me.tpLocation = New System.Windows.Forms.TabPage()
            Me.dbgLoc_Data = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblLoc_Count = New System.Windows.Forms.Label()
            Me.btnLocRefreshData = New System.Windows.Forms.Button()
            Me.tpDockShip = New System.Windows.Forms.TabPage()
            Me.pnlQty = New System.Windows.Forms.Panel()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblDisposition = New System.Windows.Forms.Label()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.pnlBox = New System.Windows.Forms.Panel()
            Me.lblPalletNameSelected = New System.Windows.Forms.Label()
            Me.rbtnDetails = New System.Windows.Forms.RadioButton()
            Me.rbtnByRMAUPC = New System.Windows.Forms.RadioButton()
            Me.rbtnByRMA = New System.Windows.Forms.RadioButton()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnCreateShip = New System.Windows.Forms.Button()
            Me.lblPalletName = New System.Windows.Forms.Label()
            Me.txtPalletName = New System.Windows.Forms.TextBox()
            Me.tpReports = New System.Windows.Forms.TabPage()
            Me.cboRpt_ReportName = New System.Windows.Forms.ComboBox()
            Me.btnRpt_RunRpt = New System.Windows.Forms.Button()
            Me.gbRpt_Date = New System.Windows.Forms.GroupBox()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpRpt_EndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpRpt_StartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dgLocQty = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabControl1.SuspendLayout()
            Me.tpRec.SuspendLayout()
            Me.gbRec_Reprint.SuspendLayout()
            CType(Me.dbgRec_Location, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbRec_ClosePallet.SuspendLayout()
            CType(Me.cboRec_ClosePalletDisposition, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgRec_ReceivedCnt, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            CType(Me.cboRec_Dispostion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpBuildShipPallet.SuspendLayout()
            Me.pnlBSP_PalletList.SuspendLayout()
            Me.gbBSP_Reprint.SuspendLayout()
            CType(Me.dbgBSP_Pallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlShipType.SuspendLayout()
            CType(Me.cboBSP_Dispostion, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlBSP_Pallet.SuspendLayout()
            Me.tpLocation.SuspendLayout()
            CType(Me.dbgLoc_Data, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpDockShip.SuspendLayout()
            Me.pnlQty.SuspendLayout()
            Me.pnlBox.SuspendLayout()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpReports.SuspendLayout()
            Me.gbRpt_Date.SuspendLayout()
            CType(Me.dgLocQty, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpRec, Me.tpBuildShipPallet, Me.tpLocation, Me.tpDockShip, Me.tpReports})
            Me.TabControl1.Location = New System.Drawing.Point(24, 16)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(992, 560)
            Me.TabControl1.TabIndex = 1
            '
            'tpRec
            '
            Me.tpRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintAllQCAuditRpt, Me.btnPrintNextQCAuditRpt, Me.Label14, Me.txtRec_DevicePrinterName, Me.gbRec_Reprint, Me.Label10, Me.txtRec_IPMPPrinterName, Me.btnRec_CloseLoc, Me.dbgRec_Location, Me.gbRec_ClosePallet, Me.dbgRec_ReceivedCnt, Me.Panel4, Me.Label2, Me.cboRec_Dispostion, Me.Label1, Me.txtRec_UPC, Me.Label3, Me.txtRec_RMA, Me.btnRec_RefreshCount})
            Me.tpRec.Location = New System.Drawing.Point(4, 22)
            Me.tpRec.Name = "tpRec"
            Me.tpRec.Size = New System.Drawing.Size(984, 534)
            Me.tpRec.TabIndex = 0
            Me.tpRec.Text = "Receiving"
            '
            'btnPrintAllQCAuditRpt
            '
            Me.btnPrintAllQCAuditRpt.BackColor = System.Drawing.Color.Red
            Me.btnPrintAllQCAuditRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintAllQCAuditRpt.ForeColor = System.Drawing.Color.White
            Me.btnPrintAllQCAuditRpt.Location = New System.Drawing.Point(216, 464)
            Me.btnPrintAllQCAuditRpt.Name = "btnPrintAllQCAuditRpt"
            Me.btnPrintAllQCAuditRpt.Size = New System.Drawing.Size(184, 40)
            Me.btnPrintAllQCAuditRpt.TabIndex = 26
            Me.btnPrintAllQCAuditRpt.TabStop = False
            Me.btnPrintAllQCAuditRpt.Text = "Print All QC Audit Report For Selected Loc"
            '
            'btnPrintNextQCAuditRpt
            '
            Me.btnPrintNextQCAuditRpt.BackColor = System.Drawing.Color.Red
            Me.btnPrintNextQCAuditRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintNextQCAuditRpt.ForeColor = System.Drawing.Color.White
            Me.btnPrintNextQCAuditRpt.Location = New System.Drawing.Point(8, 464)
            Me.btnPrintNextQCAuditRpt.Name = "btnPrintNextQCAuditRpt"
            Me.btnPrintNextQCAuditRpt.Size = New System.Drawing.Size(184, 40)
            Me.btnPrintNextQCAuditRpt.TabIndex = 25
            Me.btnPrintNextQCAuditRpt.TabStop = False
            Me.btnPrintNextQCAuditRpt.Text = "Print Next QC Audit Report For Selected Loc"
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.Location = New System.Drawing.Point(15, 80)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(225, 24)
            Me.Label14.TabIndex = 24
            Me.Label14.Text = "Printer Name to print Device/RMA:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtRec_DevicePrinterName
            '
            Me.txtRec_DevicePrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRec_DevicePrinterName.Location = New System.Drawing.Point(16, 104)
            Me.txtRec_DevicePrinterName.Name = "txtRec_DevicePrinterName"
            Me.txtRec_DevicePrinterName.Size = New System.Drawing.Size(232, 21)
            Me.txtRec_DevicePrinterName.TabIndex = 1
            Me.txtRec_DevicePrinterName.Text = ""
            '
            'gbRec_Reprint
            '
            Me.gbRec_Reprint.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label13, Me.txtRec_ReprintQty, Me.lblRec_LabelType, Me.txtRec_LabelTypeVal, Me.cboRec_LabelTypes, Me.Label12, Me.btnRec_ReprintLabel})
            Me.gbRec_Reprint.Location = New System.Drawing.Point(704, 139)
            Me.gbRec_Reprint.Name = "gbRec_Reprint"
            Me.gbRec_Reprint.Size = New System.Drawing.Size(264, 277)
            Me.gbRec_Reprint.TabIndex = 5
            Me.gbRec_Reprint.TabStop = False
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.Transparent
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.Location = New System.Drawing.Point(16, 126)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(56, 24)
            Me.Label13.TabIndex = 24
            Me.Label13.Text = "Quantity"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtRec_ReprintQty
            '
            Me.txtRec_ReprintQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRec_ReprintQty.Location = New System.Drawing.Point(16, 152)
            Me.txtRec_ReprintQty.Name = "txtRec_ReprintQty"
            Me.txtRec_ReprintQty.Size = New System.Drawing.Size(56, 21)
            Me.txtRec_ReprintQty.TabIndex = 2
            Me.txtRec_ReprintQty.Text = ""
            '
            'lblRec_LabelType
            '
            Me.lblRec_LabelType.BackColor = System.Drawing.Color.Transparent
            Me.lblRec_LabelType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRec_LabelType.Location = New System.Drawing.Point(16, 72)
            Me.lblRec_LabelType.Name = "lblRec_LabelType"
            Me.lblRec_LabelType.Size = New System.Drawing.Size(232, 24)
            Me.lblRec_LabelType.TabIndex = 23
            Me.lblRec_LabelType.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtRec_LabelTypeVal
            '
            Me.txtRec_LabelTypeVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRec_LabelTypeVal.Location = New System.Drawing.Point(16, 96)
            Me.txtRec_LabelTypeVal.Name = "txtRec_LabelTypeVal"
            Me.txtRec_LabelTypeVal.Size = New System.Drawing.Size(232, 21)
            Me.txtRec_LabelTypeVal.TabIndex = 1
            Me.txtRec_LabelTypeVal.Text = ""
            '
            'cboRec_LabelTypes
            '
            Me.cboRec_LabelTypes.Items.AddRange(New Object() {"Device", "Inner Pack", "Master Pack", "RMA"})
            Me.cboRec_LabelTypes.Location = New System.Drawing.Point(16, 40)
            Me.cboRec_LabelTypes.Name = "cboRec_LabelTypes"
            Me.cboRec_LabelTypes.Size = New System.Drawing.Size(232, 21)
            Me.cboRec_LabelTypes.TabIndex = 0
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.Location = New System.Drawing.Point(16, 16)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(88, 24)
            Me.Label12.TabIndex = 19
            Me.Label12.Text = "Label Type:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnRec_ReprintLabel
            '
            Me.btnRec_ReprintLabel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRec_ReprintLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRec_ReprintLabel.ForeColor = System.Drawing.Color.White
            Me.btnRec_ReprintLabel.Location = New System.Drawing.Point(136, 152)
            Me.btnRec_ReprintLabel.Name = "btnRec_ReprintLabel"
            Me.btnRec_ReprintLabel.Size = New System.Drawing.Size(112, 24)
            Me.btnRec_ReprintLabel.TabIndex = 3
            Me.btnRec_ReprintLabel.TabStop = False
            Me.btnRec_ReprintLabel.Text = "Print"
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.Location = New System.Drawing.Point(16, 8)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(160, 24)
            Me.Label10.TabIndex = 17
            Me.Label10.Text = "Printer Name to print MP/IP:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtRec_IPMPPrinterName
            '
            Me.txtRec_IPMPPrinterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRec_IPMPPrinterName.Location = New System.Drawing.Point(16, 32)
            Me.txtRec_IPMPPrinterName.Name = "txtRec_IPMPPrinterName"
            Me.txtRec_IPMPPrinterName.Size = New System.Drawing.Size(232, 21)
            Me.txtRec_IPMPPrinterName.TabIndex = 0
            Me.txtRec_IPMPPrinterName.Text = ""
            '
            'btnRec_CloseLoc
            '
            Me.btnRec_CloseLoc.BackColor = System.Drawing.Color.Green
            Me.btnRec_CloseLoc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRec_CloseLoc.ForeColor = System.Drawing.Color.White
            Me.btnRec_CloseLoc.Location = New System.Drawing.Point(8, 432)
            Me.btnRec_CloseLoc.Name = "btnRec_CloseLoc"
            Me.btnRec_CloseLoc.Size = New System.Drawing.Size(184, 24)
            Me.btnRec_CloseLoc.TabIndex = 6
            Me.btnRec_CloseLoc.TabStop = False
            Me.btnRec_CloseLoc.Text = "Close Selected Location"
            '
            'dbgRec_Location
            '
            Me.dbgRec_Location.AllowUpdate = False
            Me.dbgRec_Location.AlternatingRows = True
            Me.dbgRec_Location.FilterBar = True
            Me.dbgRec_Location.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRec_Location.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgRec_Location.Location = New System.Drawing.Point(8, 144)
            Me.dbgRec_Location.Name = "dbgRec_Location"
            Me.dbgRec_Location.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRec_Location.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRec_Location.PreviewInfo.ZoomFactor = 75
            Me.dbgRec_Location.Size = New System.Drawing.Size(688, 272)
            Me.dbgRec_Location.TabIndex = 5
            Me.dbgRec_Location.TabStop = False
            Me.dbgRec_Location.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>2" & _
            "68</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 684, 268<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 684, 268</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'gbRec_ClosePallet
            '
            Me.gbRec_ClosePallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRec_ReprintPalletLabel, Me.Label6, Me.txtRec_CopyQty, Me.lblRec_OpenPalletQty, Me.btnRec_ClosePallet, Me.Label5, Me.cboRec_ClosePalletDisposition})
            Me.gbRec_ClosePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbRec_ClosePallet.Location = New System.Drawing.Point(840, 464)
            Me.gbRec_ClosePallet.Name = "gbRec_ClosePallet"
            Me.gbRec_ClosePallet.Size = New System.Drawing.Size(72, 16)
            Me.gbRec_ClosePallet.TabIndex = 13
            Me.gbRec_ClosePallet.TabStop = False
            Me.gbRec_ClosePallet.Text = "Close Pallet"
            Me.gbRec_ClosePallet.Visible = False
            '
            'btnRec_ReprintPalletLabel
            '
            Me.btnRec_ReprintPalletLabel.BackColor = System.Drawing.SystemColors.Control
            Me.btnRec_ReprintPalletLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRec_ReprintPalletLabel.ForeColor = System.Drawing.Color.Black
            Me.btnRec_ReprintPalletLabel.Location = New System.Drawing.Point(16, 152)
            Me.btnRec_ReprintPalletLabel.Name = "btnRec_ReprintPalletLabel"
            Me.btnRec_ReprintPalletLabel.Size = New System.Drawing.Size(272, 24)
            Me.btnRec_ReprintPalletLabel.TabIndex = 11
            Me.btnRec_ReprintPalletLabel.Text = "Reprint Pallet Label"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(176, 72)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(60, 24)
            Me.Label6.TabIndex = 10
            Me.Label6.Text = "Copy Qty"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRec_CopyQty
            '
            Me.txtRec_CopyQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRec_CopyQty.Location = New System.Drawing.Point(248, 72)
            Me.txtRec_CopyQty.Name = "txtRec_CopyQty"
            Me.txtRec_CopyQty.Size = New System.Drawing.Size(44, 21)
            Me.txtRec_CopyQty.TabIndex = 2
            Me.txtRec_CopyQty.Text = "1"
            '
            'lblRec_OpenPalletQty
            '
            Me.lblRec_OpenPalletQty.BackColor = System.Drawing.Color.Transparent
            Me.lblRec_OpenPalletQty.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRec_OpenPalletQty.Location = New System.Drawing.Point(8, 72)
            Me.lblRec_OpenPalletQty.Name = "lblRec_OpenPalletQty"
            Me.lblRec_OpenPalletQty.Size = New System.Drawing.Size(128, 24)
            Me.lblRec_OpenPalletQty.TabIndex = 8
            Me.lblRec_OpenPalletQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnRec_ClosePallet
            '
            Me.btnRec_ClosePallet.BackColor = System.Drawing.Color.Gray
            Me.btnRec_ClosePallet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRec_ClosePallet.ForeColor = System.Drawing.Color.White
            Me.btnRec_ClosePallet.Location = New System.Drawing.Point(16, 112)
            Me.btnRec_ClosePallet.Name = "btnRec_ClosePallet"
            Me.btnRec_ClosePallet.Size = New System.Drawing.Size(272, 24)
            Me.btnRec_ClosePallet.TabIndex = 3
            Me.btnRec_ClosePallet.Text = "Close Pallet"
            Me.btnRec_ClosePallet.Visible = False
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(16, 24)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(80, 16)
            Me.Label5.TabIndex = 6
            Me.Label5.Text = "Disposition"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboRec_ClosePalletDisposition
            '
            Me.cboRec_ClosePalletDisposition.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_ClosePalletDisposition.AutoCompletion = True
            Me.cboRec_ClosePalletDisposition.AutoDropDown = True
            Me.cboRec_ClosePalletDisposition.AutoSelect = True
            Me.cboRec_ClosePalletDisposition.Caption = ""
            Me.cboRec_ClosePalletDisposition.CaptionHeight = 17
            Me.cboRec_ClosePalletDisposition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_ClosePalletDisposition.ColumnCaptionHeight = 17
            Me.cboRec_ClosePalletDisposition.ColumnFooterHeight = 17
            Me.cboRec_ClosePalletDisposition.ColumnHeaders = False
            Me.cboRec_ClosePalletDisposition.ContentHeight = 15
            Me.cboRec_ClosePalletDisposition.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_ClosePalletDisposition.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_ClosePalletDisposition.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_ClosePalletDisposition.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_ClosePalletDisposition.EditorHeight = 15
            Me.cboRec_ClosePalletDisposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_ClosePalletDisposition.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboRec_ClosePalletDisposition.ItemHeight = 15
            Me.cboRec_ClosePalletDisposition.Location = New System.Drawing.Point(16, 40)
            Me.cboRec_ClosePalletDisposition.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_ClosePalletDisposition.MaxDropDownItems = CType(10, Short)
            Me.cboRec_ClosePalletDisposition.MaxLength = 32767
            Me.cboRec_ClosePalletDisposition.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_ClosePalletDisposition.Name = "cboRec_ClosePalletDisposition"
            Me.cboRec_ClosePalletDisposition.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_ClosePalletDisposition.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_ClosePalletDisposition.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_ClosePalletDisposition.Size = New System.Drawing.Size(272, 21)
            Me.cboRec_ClosePalletDisposition.TabIndex = 1
            Me.cboRec_ClosePalletDisposition.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'dbgRec_ReceivedCnt
            '
            Me.dbgRec_ReceivedCnt.AllowUpdate = False
            Me.dbgRec_ReceivedCnt.AlternatingRows = True
            Me.dbgRec_ReceivedCnt.FilterBar = True
            Me.dbgRec_ReceivedCnt.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRec_ReceivedCnt.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgRec_ReceivedCnt.Location = New System.Drawing.Point(920, 464)
            Me.dbgRec_ReceivedCnt.Name = "dbgRec_ReceivedCnt"
            Me.dbgRec_ReceivedCnt.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRec_ReceivedCnt.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRec_ReceivedCnt.PreviewInfo.ZoomFactor = 75
            Me.dbgRec_ReceivedCnt.Size = New System.Drawing.Size(48, 16)
            Me.dbgRec_ReceivedCnt.TabIndex = 12
            Me.dbgRec_ReceivedCnt.TabStop = False
            Me.dbgRec_ReceivedCnt.Visible = False
            Me.dbgRec_ReceivedCnt.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>1" & _
            "2</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edit" & _
            "or"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle p" & _
            "arent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gro" & _
            "upStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2""" & _
            " /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=" & _
            """Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelec" & _
            "torStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected""" & _
            " me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 44, 12</Cl" & _
            "ientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1T" & _
            "rueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style " & _
            "parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style pare" & _
            "nt=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style paren" & _
            "t=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""N" & _
            "ormal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""" & _
            "Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style paren" & _
            "t=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Default" & _
            "RecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 44, 12</ClientArea><PrintPa" & _
            "geHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style" & _
            "21"" /></Blob>"
            '
            'Panel4
            '
            Me.Panel4.BackColor = System.Drawing.Color.Black
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRec_DailyCount, Me.Label26, Me.lblRec_RMACount, Me.Label31, Me.lblRec_UserCount, Me.Label35})
            Me.Panel4.Location = New System.Drawing.Point(664, 8)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(310, 120)
            Me.Panel4.TabIndex = 11
            '
            'lblRec_DailyCount
            '
            Me.lblRec_DailyCount.BackColor = System.Drawing.Color.Transparent
            Me.lblRec_DailyCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRec_DailyCount.ForeColor = System.Drawing.Color.Lime
            Me.lblRec_DailyCount.Location = New System.Drawing.Point(224, 80)
            Me.lblRec_DailyCount.Name = "lblRec_DailyCount"
            Me.lblRec_DailyCount.Size = New System.Drawing.Size(80, 31)
            Me.lblRec_DailyCount.TabIndex = 90
            Me.lblRec_DailyCount.Text = "0"
            Me.lblRec_DailyCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label26
            '
            Me.Label26.BackColor = System.Drawing.Color.Transparent
            Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label26.ForeColor = System.Drawing.Color.Lime
            Me.Label26.Location = New System.Drawing.Point(0, 80)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(224, 31)
            Me.Label26.TabIndex = 89
            Me.Label26.Text = "Daily Count :"
            Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRec_RMACount
            '
            Me.lblRec_RMACount.BackColor = System.Drawing.Color.Transparent
            Me.lblRec_RMACount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRec_RMACount.ForeColor = System.Drawing.Color.Lime
            Me.lblRec_RMACount.Location = New System.Drawing.Point(224, 40)
            Me.lblRec_RMACount.Name = "lblRec_RMACount"
            Me.lblRec_RMACount.Size = New System.Drawing.Size(80, 31)
            Me.lblRec_RMACount.TabIndex = 88
            Me.lblRec_RMACount.Text = "0"
            Me.lblRec_RMACount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label31
            '
            Me.Label31.BackColor = System.Drawing.Color.Transparent
            Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label31.ForeColor = System.Drawing.Color.Lime
            Me.Label31.Location = New System.Drawing.Point(16, 40)
            Me.Label31.Name = "Label31"
            Me.Label31.Size = New System.Drawing.Size(208, 31)
            Me.Label31.TabIndex = 87
            Me.Label31.Text = "RMA Count :"
            Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRec_UserCount
            '
            Me.lblRec_UserCount.BackColor = System.Drawing.Color.Transparent
            Me.lblRec_UserCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRec_UserCount.ForeColor = System.Drawing.Color.Lime
            Me.lblRec_UserCount.Location = New System.Drawing.Point(224, 8)
            Me.lblRec_UserCount.Name = "lblRec_UserCount"
            Me.lblRec_UserCount.Size = New System.Drawing.Size(80, 24)
            Me.lblRec_UserCount.TabIndex = 84
            Me.lblRec_UserCount.Text = "0"
            Me.lblRec_UserCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label35
            '
            Me.Label35.BackColor = System.Drawing.Color.Transparent
            Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label35.ForeColor = System.Drawing.Color.Lime
            Me.Label35.Location = New System.Drawing.Point(16, 8)
            Me.Label35.Name = "Label35"
            Me.Label35.Size = New System.Drawing.Size(208, 24)
            Me.Label35.TabIndex = 83
            Me.Label35.Text = "User Count :"
            Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(296, 104)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 24)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Disposition"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboRec_Dispostion
            '
            Me.cboRec_Dispostion.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboRec_Dispostion.AutoCompletion = True
            Me.cboRec_Dispostion.AutoDropDown = True
            Me.cboRec_Dispostion.AutoSelect = True
            Me.cboRec_Dispostion.Caption = ""
            Me.cboRec_Dispostion.CaptionHeight = 17
            Me.cboRec_Dispostion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboRec_Dispostion.ColumnCaptionHeight = 17
            Me.cboRec_Dispostion.ColumnFooterHeight = 17
            Me.cboRec_Dispostion.ColumnHeaders = False
            Me.cboRec_Dispostion.ContentHeight = 15
            Me.cboRec_Dispostion.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboRec_Dispostion.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboRec_Dispostion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_Dispostion.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboRec_Dispostion.EditorHeight = 15
            Me.cboRec_Dispostion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRec_Dispostion.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboRec_Dispostion.ItemHeight = 15
            Me.cboRec_Dispostion.Location = New System.Drawing.Point(368, 104)
            Me.cboRec_Dispostion.MatchEntryTimeout = CType(2000, Long)
            Me.cboRec_Dispostion.MaxDropDownItems = CType(10, Short)
            Me.cboRec_Dispostion.MaxLength = 32767
            Me.cboRec_Dispostion.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboRec_Dispostion.Name = "cboRec_Dispostion"
            Me.cboRec_Dispostion.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboRec_Dispostion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboRec_Dispostion.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboRec_Dispostion.Size = New System.Drawing.Size(232, 21)
            Me.cboRec_Dispostion.TabIndex = 4
            Me.cboRec_Dispostion.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(320, 64)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(40, 24)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "UPC"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRec_UPC
            '
            Me.txtRec_UPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRec_UPC.Location = New System.Drawing.Point(368, 64)
            Me.txtRec_UPC.Name = "txtRec_UPC"
            Me.txtRec_UPC.Size = New System.Drawing.Size(232, 21)
            Me.txtRec_UPC.TabIndex = 3
            Me.txtRec_UPC.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(320, 24)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 24)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "RMA"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRec_RMA
            '
            Me.txtRec_RMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRec_RMA.Location = New System.Drawing.Point(368, 24)
            Me.txtRec_RMA.Name = "txtRec_RMA"
            Me.txtRec_RMA.Size = New System.Drawing.Size(232, 21)
            Me.txtRec_RMA.TabIndex = 2
            Me.txtRec_RMA.Text = ""
            '
            'btnRec_RefreshCount
            '
            Me.btnRec_RefreshCount.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRec_RefreshCount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRec_RefreshCount.ForeColor = System.Drawing.Color.White
            Me.btnRec_RefreshCount.Location = New System.Drawing.Point(512, 432)
            Me.btnRec_RefreshCount.Name = "btnRec_RefreshCount"
            Me.btnRec_RefreshCount.Size = New System.Drawing.Size(184, 24)
            Me.btnRec_RefreshCount.TabIndex = 7
            Me.btnRec_RefreshCount.TabStop = False
            Me.btnRec_RefreshCount.Text = "Refresh Data"
            '
            'tpBuildShipPallet
            '
            Me.tpBuildShipPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlBSP_PalletList, Me.pnlShipType, Me.pnlBSP_Pallet})
            Me.tpBuildShipPallet.Location = New System.Drawing.Point(4, 22)
            Me.tpBuildShipPallet.Name = "tpBuildShipPallet"
            Me.tpBuildShipPallet.Size = New System.Drawing.Size(984, 534)
            Me.tpBuildShipPallet.TabIndex = 3
            Me.tpBuildShipPallet.Text = "Build Ship Pallet"
            '
            'pnlBSP_PalletList
            '
            Me.pnlBSP_PalletList.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlBSP_PalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlBSP_PalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbBSP_Reprint, Me.btnRecreatPalletDetail, Me.btnBSP_RefreshPalletList, Me.btnBSP_DeletePallet, Me.btnBSP_Reopen, Me.dbgBSP_Pallets})
            Me.pnlBSP_PalletList.Location = New System.Drawing.Point(16, 104)
            Me.pnlBSP_PalletList.Name = "pnlBSP_PalletList"
            Me.pnlBSP_PalletList.Size = New System.Drawing.Size(472, 392)
            Me.pnlBSP_PalletList.TabIndex = 121
            '
            'gbBSP_Reprint
            '
            Me.gbBSP_Reprint.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboBSP_ReprintType, Me.btnBSP_Reprint})
            Me.gbBSP_Reprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbBSP_Reprint.ForeColor = System.Drawing.Color.White
            Me.gbBSP_Reprint.Location = New System.Drawing.Point(224, 216)
            Me.gbBSP_Reprint.Name = "gbBSP_Reprint"
            Me.gbBSP_Reprint.Size = New System.Drawing.Size(224, 128)
            Me.gbBSP_Reprint.TabIndex = 6
            Me.gbBSP_Reprint.TabStop = False
            Me.gbBSP_Reprint.Text = "Reprint"
            '
            'cboBSP_ReprintType
            '
            Me.cboBSP_ReprintType.Items.AddRange(New Object() {"Pallet Label", "Pallet Manifest"})
            Me.cboBSP_ReprintType.Location = New System.Drawing.Point(16, 24)
            Me.cboBSP_ReprintType.Name = "cboBSP_ReprintType"
            Me.cboBSP_ReprintType.Size = New System.Drawing.Size(184, 21)
            Me.cboBSP_ReprintType.TabIndex = 6
            '
            'btnBSP_Reprint
            '
            Me.btnBSP_Reprint.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnBSP_Reprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBSP_Reprint.ForeColor = System.Drawing.Color.Black
            Me.btnBSP_Reprint.Location = New System.Drawing.Point(16, 64)
            Me.btnBSP_Reprint.Name = "btnBSP_Reprint"
            Me.btnBSP_Reprint.Size = New System.Drawing.Size(184, 24)
            Me.btnBSP_Reprint.TabIndex = 3
            Me.btnBSP_Reprint.Text = "REPRINT"
            '
            'btnRecreatPalletDetail
            '
            Me.btnRecreatPalletDetail.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnRecreatPalletDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRecreatPalletDetail.ForeColor = System.Drawing.Color.Black
            Me.btnRecreatPalletDetail.Location = New System.Drawing.Point(8, 320)
            Me.btnRecreatPalletDetail.Name = "btnRecreatPalletDetail"
            Me.btnRecreatPalletDetail.Size = New System.Drawing.Size(184, 24)
            Me.btnRecreatPalletDetail.TabIndex = 5
            Me.btnRecreatPalletDetail.Text = "RECREATE MANIFEST LIST"
            '
            'btnBSP_RefreshPalletList
            '
            Me.btnBSP_RefreshPalletList.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnBSP_RefreshPalletList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBSP_RefreshPalletList.ForeColor = System.Drawing.Color.Black
            Me.btnBSP_RefreshPalletList.Location = New System.Drawing.Point(8, 224)
            Me.btnBSP_RefreshPalletList.Name = "btnBSP_RefreshPalletList"
            Me.btnBSP_RefreshPalletList.Size = New System.Drawing.Size(184, 24)
            Me.btnBSP_RefreshPalletList.TabIndex = 4
            Me.btnBSP_RefreshPalletList.Text = "REFRESH PALLET LIST"
            '
            'btnBSP_DeletePallet
            '
            Me.btnBSP_DeletePallet.BackColor = System.Drawing.Color.Red
            Me.btnBSP_DeletePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBSP_DeletePallet.ForeColor = System.Drawing.Color.White
            Me.btnBSP_DeletePallet.Location = New System.Drawing.Point(8, 288)
            Me.btnBSP_DeletePallet.Name = "btnBSP_DeletePallet"
            Me.btnBSP_DeletePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnBSP_DeletePallet.Size = New System.Drawing.Size(184, 24)
            Me.btnBSP_DeletePallet.TabIndex = 2
            Me.btnBSP_DeletePallet.Text = "DELETE EMPTY PALLET"
            '
            'btnBSP_Reopen
            '
            Me.btnBSP_Reopen.BackColor = System.Drawing.Color.Green
            Me.btnBSP_Reopen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBSP_Reopen.ForeColor = System.Drawing.Color.White
            Me.btnBSP_Reopen.Location = New System.Drawing.Point(8, 256)
            Me.btnBSP_Reopen.Name = "btnBSP_Reopen"
            Me.btnBSP_Reopen.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnBSP_Reopen.Size = New System.Drawing.Size(184, 24)
            Me.btnBSP_Reopen.TabIndex = 1
            Me.btnBSP_Reopen.Text = "REOPEN  BOX"
            '
            'dbgBSP_Pallets
            '
            Me.dbgBSP_Pallets.AllowColMove = False
            Me.dbgBSP_Pallets.AllowColSelect = False
            Me.dbgBSP_Pallets.AllowFilter = False
            Me.dbgBSP_Pallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgBSP_Pallets.AllowSort = False
            Me.dbgBSP_Pallets.AllowUpdate = False
            Me.dbgBSP_Pallets.AllowUpdateOnBlur = False
            Me.dbgBSP_Pallets.CaptionHeight = 19
            Me.dbgBSP_Pallets.CollapseColor = System.Drawing.Color.White
            Me.dbgBSP_Pallets.ExpandColor = System.Drawing.Color.White
            Me.dbgBSP_Pallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgBSP_Pallets.ForeColor = System.Drawing.Color.White
            Me.dbgBSP_Pallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBSP_Pallets.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dbgBSP_Pallets.Location = New System.Drawing.Point(8, 8)
            Me.dbgBSP_Pallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgBSP_Pallets.Name = "dbgBSP_Pallets"
            Me.dbgBSP_Pallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBSP_Pallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBSP_Pallets.PreviewInfo.ZoomFactor = 75
            Me.dbgBSP_Pallets.RowHeight = 20
            Me.dbgBSP_Pallets.Size = New System.Drawing.Size(440, 200)
            Me.dbgBSP_Pallets.TabIndex = 0
            Me.dbgBSP_Pallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
            "lor:White;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColo" & _
            "r:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}Style12{}OddRow{BackColor:Teal;}RecordSelector{Alig" & _
            "nImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
            "rif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1" & _
            ", 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1Tru" & _
            "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
            "zing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" " & _
            "MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Ver" & _
            "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>196</Height><CaptionStyle" & _
            " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
            "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
            "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
            "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
            "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
            "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
            "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
            "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 436, 196</ClientRect><BorderSide>" & _
            "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 436, 196</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'pnlShipType
            '
            Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button5, Me.btnBSP_CreatePalletID, Me.Label8, Me.cboBSP_Dispostion})
            Me.pnlShipType.Enabled = False
            Me.pnlShipType.Location = New System.Drawing.Point(16, 8)
            Me.pnlShipType.Name = "pnlShipType"
            Me.pnlShipType.Size = New System.Drawing.Size(472, 96)
            Me.pnlShipType.TabIndex = 120
            '
            'Button5
            '
            Me.Button5.BackColor = System.Drawing.Color.Black
            Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button5.Location = New System.Drawing.Point(985, 274)
            Me.Button5.Name = "Button5"
            Me.Button5.Size = New System.Drawing.Size(410, 409)
            Me.Button5.TabIndex = 66
            Me.Button5.TabStop = False
            Me.Button5.Text = "Generate Report"
            '
            'btnBSP_CreatePalletID
            '
            Me.btnBSP_CreatePalletID.BackColor = System.Drawing.Color.Green
            Me.btnBSP_CreatePalletID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBSP_CreatePalletID.ForeColor = System.Drawing.Color.White
            Me.btnBSP_CreatePalletID.Location = New System.Drawing.Point(88, 56)
            Me.btnBSP_CreatePalletID.Name = "btnBSP_CreatePalletID"
            Me.btnBSP_CreatePalletID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnBSP_CreatePalletID.Size = New System.Drawing.Size(232, 24)
            Me.btnBSP_CreatePalletID.TabIndex = 3
            Me.btnBSP_CreatePalletID.Text = "CREATE PALLET ID"
            Me.btnBSP_CreatePalletID.Visible = False
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(16, 16)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(64, 24)
            Me.Label8.TabIndex = 6
            Me.Label8.Text = "Disposition"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboBSP_Dispostion
            '
            Me.cboBSP_Dispostion.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBSP_Dispostion.AutoCompletion = True
            Me.cboBSP_Dispostion.AutoDropDown = True
            Me.cboBSP_Dispostion.AutoSelect = True
            Me.cboBSP_Dispostion.Caption = ""
            Me.cboBSP_Dispostion.CaptionHeight = 17
            Me.cboBSP_Dispostion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBSP_Dispostion.ColumnCaptionHeight = 17
            Me.cboBSP_Dispostion.ColumnFooterHeight = 17
            Me.cboBSP_Dispostion.ColumnHeaders = False
            Me.cboBSP_Dispostion.ContentHeight = 15
            Me.cboBSP_Dispostion.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBSP_Dispostion.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBSP_Dispostion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBSP_Dispostion.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBSP_Dispostion.EditorHeight = 15
            Me.cboBSP_Dispostion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBSP_Dispostion.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboBSP_Dispostion.ItemHeight = 15
            Me.cboBSP_Dispostion.Location = New System.Drawing.Point(88, 16)
            Me.cboBSP_Dispostion.MatchEntryTimeout = CType(2000, Long)
            Me.cboBSP_Dispostion.MaxDropDownItems = CType(10, Short)
            Me.cboBSP_Dispostion.MaxLength = 32767
            Me.cboBSP_Dispostion.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBSP_Dispostion.Name = "cboBSP_Dispostion"
            Me.cboBSP_Dispostion.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBSP_Dispostion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBSP_Dispostion.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBSP_Dispostion.Size = New System.Drawing.Size(232, 21)
            Me.cboBSP_Dispostion.TabIndex = 5
            Me.cboBSP_Dispostion.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'pnlBSP_Pallet
            '
            Me.pnlBSP_Pallet.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlBSP_Pallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlBSP_Pallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.txtBSP_WHLocation, Me.lblBSP_PalletQty, Me.Label11, Me.txtBSP_MasterPack, Me.lblBSP_MPDesc, Me.btnBSP_RemoveAllMPIDs, Me.btnBSP_RemoveMPID, Me.lstBSP_MasterPacks, Me.lblBSP_MasterpackQty, Me.lblBSP_MPQtyDesc, Me.lblBSP_PalletName, Me.btnBSP_ClosePallet})
            Me.pnlBSP_Pallet.Location = New System.Drawing.Point(504, 8)
            Me.pnlBSP_Pallet.Name = "pnlBSP_Pallet"
            Me.pnlBSP_Pallet.Size = New System.Drawing.Size(400, 488)
            Me.pnlBSP_Pallet.TabIndex = 122
            Me.pnlBSP_Pallet.Visible = False
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(232, 336)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(152, 16)
            Me.Label9.TabIndex = 103
            Me.Label9.Text = "Warehouse Location"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtBSP_WHLocation
            '
            Me.txtBSP_WHLocation.Location = New System.Drawing.Point(232, 352)
            Me.txtBSP_WHLocation.Name = "txtBSP_WHLocation"
            Me.txtBSP_WHLocation.Size = New System.Drawing.Size(144, 20)
            Me.txtBSP_WHLocation.TabIndex = 2
            Me.txtBSP_WHLocation.Text = ""
            '
            'lblBSP_PalletQty
            '
            Me.lblBSP_PalletQty.BackColor = System.Drawing.Color.Black
            Me.lblBSP_PalletQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBSP_PalletQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBSP_PalletQty.ForeColor = System.Drawing.Color.Lime
            Me.lblBSP_PalletQty.Location = New System.Drawing.Point(232, 152)
            Me.lblBSP_PalletQty.Name = "lblBSP_PalletQty"
            Me.lblBSP_PalletQty.Size = New System.Drawing.Size(96, 43)
            Me.lblBSP_PalletQty.TabIndex = 101
            Me.lblBSP_PalletQty.Text = "0"
            Me.lblBSP_PalletQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(232, 136)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(96, 16)
            Me.Label11.TabIndex = 100
            Me.Label11.Text = "Pallet Qty"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtBSP_MasterPack
            '
            Me.txtBSP_MasterPack.Enabled = False
            Me.txtBSP_MasterPack.Location = New System.Drawing.Point(16, 72)
            Me.txtBSP_MasterPack.Name = "txtBSP_MasterPack"
            Me.txtBSP_MasterPack.Size = New System.Drawing.Size(176, 20)
            Me.txtBSP_MasterPack.TabIndex = 0
            Me.txtBSP_MasterPack.Text = ""
            '
            'lblBSP_MPDesc
            '
            Me.lblBSP_MPDesc.BackColor = System.Drawing.Color.Transparent
            Me.lblBSP_MPDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBSP_MPDesc.ForeColor = System.Drawing.Color.White
            Me.lblBSP_MPDesc.Location = New System.Drawing.Point(16, 56)
            Me.lblBSP_MPDesc.Name = "lblBSP_MPDesc"
            Me.lblBSP_MPDesc.Size = New System.Drawing.Size(176, 16)
            Me.lblBSP_MPDesc.TabIndex = 99
            Me.lblBSP_MPDesc.Text = "Master Pack ID"
            Me.lblBSP_MPDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnBSP_RemoveAllMPIDs
            '
            Me.btnBSP_RemoveAllMPIDs.BackColor = System.Drawing.Color.Red
            Me.btnBSP_RemoveAllMPIDs.Enabled = False
            Me.btnBSP_RemoveAllMPIDs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBSP_RemoveAllMPIDs.ForeColor = System.Drawing.Color.White
            Me.btnBSP_RemoveAllMPIDs.Location = New System.Drawing.Point(232, 280)
            Me.btnBSP_RemoveAllMPIDs.Name = "btnBSP_RemoveAllMPIDs"
            Me.btnBSP_RemoveAllMPIDs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnBSP_RemoveAllMPIDs.Size = New System.Drawing.Size(144, 40)
            Me.btnBSP_RemoveAllMPIDs.TabIndex = 4
            Me.btnBSP_RemoveAllMPIDs.Text = "REMOVE ALL MASTERPACKs"
            '
            'btnBSP_RemoveMPID
            '
            Me.btnBSP_RemoveMPID.BackColor = System.Drawing.Color.Red
            Me.btnBSP_RemoveMPID.Enabled = False
            Me.btnBSP_RemoveMPID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBSP_RemoveMPID.ForeColor = System.Drawing.Color.White
            Me.btnBSP_RemoveMPID.Location = New System.Drawing.Point(232, 224)
            Me.btnBSP_RemoveMPID.Name = "btnBSP_RemoveMPID"
            Me.btnBSP_RemoveMPID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnBSP_RemoveMPID.Size = New System.Drawing.Size(144, 40)
            Me.btnBSP_RemoveMPID.TabIndex = 3
            Me.btnBSP_RemoveMPID.Text = "REMOVE MASTERPACK"
            '
            'lstBSP_MasterPacks
            '
            Me.lstBSP_MasterPacks.Location = New System.Drawing.Point(16, 96)
            Me.lstBSP_MasterPacks.Name = "lstBSP_MasterPacks"
            Me.lstBSP_MasterPacks.Size = New System.Drawing.Size(176, 329)
            Me.lstBSP_MasterPacks.TabIndex = 1
            '
            'lblBSP_MasterpackQty
            '
            Me.lblBSP_MasterpackQty.BackColor = System.Drawing.Color.Black
            Me.lblBSP_MasterpackQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBSP_MasterpackQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBSP_MasterpackQty.ForeColor = System.Drawing.Color.Lime
            Me.lblBSP_MasterpackQty.Location = New System.Drawing.Point(232, 72)
            Me.lblBSP_MasterpackQty.Name = "lblBSP_MasterpackQty"
            Me.lblBSP_MasterpackQty.Size = New System.Drawing.Size(96, 43)
            Me.lblBSP_MasterpackQty.TabIndex = 97
            Me.lblBSP_MasterpackQty.Text = "0"
            Me.lblBSP_MasterpackQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBSP_MPQtyDesc
            '
            Me.lblBSP_MPQtyDesc.BackColor = System.Drawing.Color.Transparent
            Me.lblBSP_MPQtyDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBSP_MPQtyDesc.ForeColor = System.Drawing.Color.White
            Me.lblBSP_MPQtyDesc.Location = New System.Drawing.Point(224, 56)
            Me.lblBSP_MPQtyDesc.Name = "lblBSP_MPQtyDesc"
            Me.lblBSP_MPQtyDesc.Size = New System.Drawing.Size(104, 16)
            Me.lblBSP_MPQtyDesc.TabIndex = 96
            Me.lblBSP_MPQtyDesc.Text = "Masterpack Qty"
            Me.lblBSP_MPQtyDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBSP_PalletName
            '
            Me.lblBSP_PalletName.BackColor = System.Drawing.Color.Black
            Me.lblBSP_PalletName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBSP_PalletName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBSP_PalletName.ForeColor = System.Drawing.Color.Lime
            Me.lblBSP_PalletName.Location = New System.Drawing.Point(8, 7)
            Me.lblBSP_PalletName.Name = "lblBSP_PalletName"
            Me.lblBSP_PalletName.Size = New System.Drawing.Size(384, 33)
            Me.lblBSP_PalletName.TabIndex = 98
            Me.lblBSP_PalletName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnBSP_ClosePallet
            '
            Me.btnBSP_ClosePallet.BackColor = System.Drawing.Color.Green
            Me.btnBSP_ClosePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBSP_ClosePallet.ForeColor = System.Drawing.Color.White
            Me.btnBSP_ClosePallet.Location = New System.Drawing.Point(232, 392)
            Me.btnBSP_ClosePallet.Name = "btnBSP_ClosePallet"
            Me.btnBSP_ClosePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnBSP_ClosePallet.Size = New System.Drawing.Size(144, 30)
            Me.btnBSP_ClosePallet.TabIndex = 3
            Me.btnBSP_ClosePallet.Text = "CLOSE PALLET"
            '
            'tpLocation
            '
            Me.tpLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgLoc_Data, Me.lblLoc_Count, Me.btnLocRefreshData})
            Me.tpLocation.Location = New System.Drawing.Point(4, 22)
            Me.tpLocation.Name = "tpLocation"
            Me.tpLocation.Size = New System.Drawing.Size(984, 534)
            Me.tpLocation.TabIndex = 4
            Me.tpLocation.Text = "Location"
            '
            'dbgLoc_Data
            '
            Me.dbgLoc_Data.AllowUpdate = False
            Me.dbgLoc_Data.AlternatingRows = True
            Me.dbgLoc_Data.FilterBar = True
            Me.dbgLoc_Data.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgLoc_Data.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.dbgLoc_Data.Location = New System.Drawing.Point(24, 48)
            Me.dbgLoc_Data.Name = "dbgLoc_Data"
            Me.dbgLoc_Data.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgLoc_Data.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgLoc_Data.PreviewInfo.ZoomFactor = 75
            Me.dbgLoc_Data.Size = New System.Drawing.Size(896, 400)
            Me.dbgLoc_Data.TabIndex = 15
            Me.dbgLoc_Data.TabStop = False
            Me.dbgLoc_Data.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "96</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 892, 396<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 892, 396</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'lblLoc_Count
            '
            Me.lblLoc_Count.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLoc_Count.ForeColor = System.Drawing.Color.DimGray
            Me.lblLoc_Count.Location = New System.Drawing.Point(24, 32)
            Me.lblLoc_Count.Name = "lblLoc_Count"
            Me.lblLoc_Count.Size = New System.Drawing.Size(704, 18)
            Me.lblLoc_Count.TabIndex = 17
            '
            'btnLocRefreshData
            '
            Me.btnLocRefreshData.BackColor = System.Drawing.Color.SteelBlue
            Me.btnLocRefreshData.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocRefreshData.ForeColor = System.Drawing.Color.White
            Me.btnLocRefreshData.Location = New System.Drawing.Point(736, 8)
            Me.btnLocRefreshData.Name = "btnLocRefreshData"
            Me.btnLocRefreshData.Size = New System.Drawing.Size(184, 32)
            Me.btnLocRefreshData.TabIndex = 16
            Me.btnLocRefreshData.Text = "Refresh Data"
            '
            'tpDockShip
            '
            Me.tpDockShip.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlQty, Me.pnlBox, Me.lblPalletName, Me.txtPalletName})
            Me.tpDockShip.Location = New System.Drawing.Point(4, 22)
            Me.tpDockShip.Name = "tpDockShip"
            Me.tpDockShip.Size = New System.Drawing.Size(984, 534)
            Me.tpDockShip.TabIndex = 1
            Me.tpDockShip.Text = "Dock Ship"
            '
            'pnlQty
            '
            Me.pnlQty.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.lblDisposition, Me.lblQty})
            Me.pnlQty.Location = New System.Drawing.Point(432, 8)
            Me.pnlQty.Name = "pnlQty"
            Me.pnlQty.Size = New System.Drawing.Size(272, 64)
            Me.pnlQty.TabIndex = 27
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(136, 0)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(120, 16)
            Me.Label7.TabIndex = 25
            Me.Label7.Text = "Total Quantity"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblDisposition
            '
            Me.lblDisposition.BackColor = System.Drawing.Color.Linen
            Me.lblDisposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDisposition.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblDisposition.Location = New System.Drawing.Point(8, 16)
            Me.lblDisposition.Name = "lblDisposition"
            Me.lblDisposition.Size = New System.Drawing.Size(120, 32)
            Me.lblDisposition.TabIndex = 22
            Me.lblDisposition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblQty
            '
            Me.lblQty.BackColor = System.Drawing.Color.Black
            Me.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty.ForeColor = System.Drawing.Color.Lime
            Me.lblQty.Location = New System.Drawing.Point(136, 16)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(128, 40)
            Me.lblQty.TabIndex = 23
            Me.lblQty.Text = "0"
            Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pnlBox
            '
            Me.pnlBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPalletNameSelected, Me.rbtnDetails, Me.rbtnByRMAUPC, Me.rbtnByRMA, Me.tdgData1, Me.btnCreateShip})
            Me.pnlBox.Location = New System.Drawing.Point(48, 64)
            Me.pnlBox.Name = "pnlBox"
            Me.pnlBox.Size = New System.Drawing.Size(648, 400)
            Me.pnlBox.TabIndex = 26
            '
            'lblPalletNameSelected
            '
            Me.lblPalletNameSelected.ForeColor = System.Drawing.SystemColors.InactiveBorder
            Me.lblPalletNameSelected.Location = New System.Drawing.Point(400, 8)
            Me.lblPalletNameSelected.Name = "lblPalletNameSelected"
            Me.lblPalletNameSelected.Size = New System.Drawing.Size(232, 24)
            Me.lblPalletNameSelected.TabIndex = 71
            Me.lblPalletNameSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rbtnDetails
            '
            Me.rbtnDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnDetails.Location = New System.Drawing.Point(8, 8)
            Me.rbtnDetails.Name = "rbtnDetails"
            Me.rbtnDetails.Size = New System.Drawing.Size(72, 24)
            Me.rbtnDetails.TabIndex = 70
            Me.rbtnDetails.Text = "Details"
            '
            'rbtnByRMAUPC
            '
            Me.rbtnByRMAUPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnByRMAUPC.Location = New System.Drawing.Point(176, 8)
            Me.rbtnByRMAUPC.Name = "rbtnByRMAUPC"
            Me.rbtnByRMAUPC.Size = New System.Drawing.Size(120, 24)
            Me.rbtnByRMAUPC.TabIndex = 69
            Me.rbtnByRMAUPC.Text = "By RMA, UPC"
            '
            'rbtnByRMA
            '
            Me.rbtnByRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnByRMA.Location = New System.Drawing.Point(88, 8)
            Me.rbtnByRMA.Name = "rbtnByRMA"
            Me.rbtnByRMA.Size = New System.Drawing.Size(80, 24)
            Me.rbtnByRMA.TabIndex = 68
            Me.rbtnByRMA.Text = "By RMA"
            '
            'tdgData1
            '
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(8, 32)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.Size = New System.Drawing.Size(624, 248)
            Me.tdgData1.TabIndex = 67
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised," & _
            ",1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
            "Grid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Mar" & _
            "queeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertic" & _
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>246</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 622, 246</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 622, 246</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnCreateShip
            '
            Me.btnCreateShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateShip.Location = New System.Drawing.Point(192, 288)
            Me.btnCreateShip.Name = "btnCreateShip"
            Me.btnCreateShip.Size = New System.Drawing.Size(272, 40)
            Me.btnCreateShip.TabIndex = 2
            Me.btnCreateShip.Text = "Create Shipment"
            '
            'lblPalletName
            '
            Me.lblPalletName.BackColor = System.Drawing.Color.Transparent
            Me.lblPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletName.Location = New System.Drawing.Point(8, 29)
            Me.lblPalletName.Name = "lblPalletName"
            Me.lblPalletName.Size = New System.Drawing.Size(160, 24)
            Me.lblPalletName.TabIndex = 2
            Me.lblPalletName.Text = "PalletName/BoxID:"
            Me.lblPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPalletName
            '
            Me.txtPalletName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPalletName.Location = New System.Drawing.Point(168, 32)
            Me.txtPalletName.Name = "txtPalletName"
            Me.txtPalletName.Size = New System.Drawing.Size(256, 22)
            Me.txtPalletName.TabIndex = 0
            Me.txtPalletName.Text = ""
            '
            'tpReports
            '
            Me.tpReports.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboRpt_ReportName, Me.btnRpt_RunRpt, Me.gbRpt_Date, Me.Label4})
            Me.tpReports.Location = New System.Drawing.Point(4, 22)
            Me.tpReports.Name = "tpReports"
            Me.tpReports.Size = New System.Drawing.Size(984, 534)
            Me.tpReports.TabIndex = 2
            Me.tpReports.Text = "Reports"
            '
            'cboRpt_ReportName
            '
            Me.cboRpt_ReportName.Location = New System.Drawing.Point(112, 24)
            Me.cboRpt_ReportName.Name = "cboRpt_ReportName"
            Me.cboRpt_ReportName.Size = New System.Drawing.Size(304, 21)
            Me.cboRpt_ReportName.TabIndex = 1
            '
            'btnRpt_RunRpt
            '
            Me.btnRpt_RunRpt.BackColor = System.Drawing.Color.DarkGray
            Me.btnRpt_RunRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRpt_RunRpt.ForeColor = System.Drawing.Color.White
            Me.btnRpt_RunRpt.Location = New System.Drawing.Point(16, 176)
            Me.btnRpt_RunRpt.Name = "btnRpt_RunRpt"
            Me.btnRpt_RunRpt.Size = New System.Drawing.Size(400, 32)
            Me.btnRpt_RunRpt.TabIndex = 3
            '
            'gbRpt_Date
            '
            Me.gbRpt_Date.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpRpt_EndDate, Me.dtpRpt_StartDate, Me.lblStartDate})
            Me.gbRpt_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbRpt_Date.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbRpt_Date.Location = New System.Drawing.Point(16, 64)
            Me.gbRpt_Date.Name = "gbRpt_Date"
            Me.gbRpt_Date.Size = New System.Drawing.Size(400, 85)
            Me.gbRpt_Date.TabIndex = 2
            Me.gbRpt_Date.TabStop = False
            Me.gbRpt_Date.Text = "DATE"
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndDate.ForeColor = System.Drawing.Color.Green
            Me.lblEndDate.Location = New System.Drawing.Point(24, 48)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(80, 16)
            Me.lblEndDate.TabIndex = 105
            Me.lblEndDate.Text = "End:"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpRpt_EndDate
            '
            Me.dtpRpt_EndDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpRpt_EndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpRpt_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpRpt_EndDate.Location = New System.Drawing.Point(112, 48)
            Me.dtpRpt_EndDate.Name = "dtpRpt_EndDate"
            Me.dtpRpt_EndDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpRpt_EndDate.TabIndex = 1
            Me.dtpRpt_EndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'dtpRpt_StartDate
            '
            Me.dtpRpt_StartDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpRpt_StartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpRpt_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpRpt_StartDate.Location = New System.Drawing.Point(112, 16)
            Me.dtpRpt_StartDate.Name = "dtpRpt_StartDate"
            Me.dtpRpt_StartDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpRpt_StartDate.TabIndex = 0
            Me.dtpRpt_StartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStartDate.ForeColor = System.Drawing.Color.Green
            Me.lblStartDate.Location = New System.Drawing.Point(24, 16)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
            Me.lblStartDate.TabIndex = 103
            Me.lblStartDate.Text = "Start:"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(40, 24)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(64, 16)
            Me.Label4.TabIndex = 6
            Me.Label4.Text = "Disposition"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dgLocQty
            '
            Me.dgLocQty.AllowUpdate = False
            Me.dgLocQty.AlternatingRows = True
            Me.dgLocQty.FilterBar = True
            Me.dgLocQty.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgLocQty.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
            Me.dgLocQty.Location = New System.Drawing.Point(0, 200)
            Me.dgLocQty.Name = "dgLocQty"
            Me.dgLocQty.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgLocQty.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgLocQty.PreviewInfo.ZoomFactor = 75
            Me.dgLocQty.Size = New System.Drawing.Size(640, 224)
            Me.dgLocQty.TabIndex = 14
            Me.dgLocQty.TabStop = False
            Me.dgLocQty.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>2" & _
            "20</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 636, 220<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 636, 220</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'frmSCandyRetailRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1056, 606)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmSCandyRetailRec"
            Me.Text = "frmSCandyRetailRec"
            Me.TabControl1.ResumeLayout(False)
            Me.tpRec.ResumeLayout(False)
            Me.gbRec_Reprint.ResumeLayout(False)
            CType(Me.dbgRec_Location, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbRec_ClosePallet.ResumeLayout(False)
            CType(Me.cboRec_ClosePalletDisposition, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgRec_ReceivedCnt, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            CType(Me.cboRec_Dispostion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpBuildShipPallet.ResumeLayout(False)
            Me.pnlBSP_PalletList.ResumeLayout(False)
            Me.gbBSP_Reprint.ResumeLayout(False)
            CType(Me.dbgBSP_Pallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlShipType.ResumeLayout(False)
            CType(Me.cboBSP_Dispostion, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlBSP_Pallet.ResumeLayout(False)
            Me.tpLocation.ResumeLayout(False)
            CType(Me.dbgLoc_Data, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpDockShip.ResumeLayout(False)
            Me.pnlQty.ResumeLayout(False)
            Me.pnlBox.ResumeLayout(False)
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpReports.ResumeLayout(False)
            Me.gbRpt_Date.ResumeLayout(False)
            CType(Me.dgLocQty, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

            '****************************************************************************************************************
            Private Sub frmSCandyRetailRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
                Dim dt, dt2 As DataTable
                Dim R1 As DataRow

                Try
                    _booLoadData = True
                    Me.pnlBox.Visible = False : Me.pnlQty.Visible = False

                    Me.TabControl1.Controls.Remove(tpReports) 'no need this. Report screen will have these reports

                    dt = Data.Buisness.Generic.GetCodesDetailByMasterCode(True, 62)
                    Misc.PopulateC1DropDownList(Me.cboRec_Dispostion, dt, "DCode_SDesc", "DCode_ID")
                    Me.cboRec_Dispostion.SelectedValue = 0

                    dt2 = New DataTable() : dt2 = dt.Copy
                    Misc.PopulateC1DropDownList(Me.cboRec_ClosePalletDisposition, dt2, "DCode_LDesc", "DCode_ID")
                    Me.cboRec_ClosePalletDisposition.SelectedValue = 0

                    dt2 = New DataTable() : dt2 = dt.Copy
                    '**************************************************
                    'REMOVE Scrap & C-Stock
                    '**************************************************
                    If dt2.Select("Dcode_ID = 3998").Length > 0 Then
                        R1 = dt2.Select("Dcode_ID = 3998")(0) : dt2.Rows.Remove(R1)
                    End If
                    If dt2.Select("Dcode_ID = 4002").Length > 0 Then
                        R1 = dt2.Select("Dcode_ID = 4002")(0) : dt2.Rows.Remove(R1)
                    End If
                    '**************************************************
                    Misc.PopulateC1DropDownList(Me.cboBSP_Dispostion, dt2, "DCode_LDesc", "DCode_ID")
                    Me.cboBSP_Dispostion.SelectedValue = 0
                    Me.tpDockShip.Enabled = False
                    Me.tpReports.Enabled = False

                    btnRec_RefreshCount_Click(Nothing, Nothing)
                    PopulateOpenPallets()
                    LoadLocationData()

                    ' Me.TabControl1.SelectedTab = Me.TabControl1.TabPages(0)
                    'TabControl1.TabPages(0).Focus()
                    'TabControl1.TabPages(0).Select()
                    Me.TabControl1.SelectedIndex = 0

                    If Core.ApplicationUser.GetPermission("SkullCandy-Retail-CloseLocation") > 0 Then Me.btnRec_CloseLoc.Visible = True

                    Me.txtRec_RMA.Focus()

                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "frmSCandyRetailRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
                    _booLoadData = False
                End Try
            End Sub

            '****************************************************************************************************************

#Region "Receiving"

        ''****************************************************************************************************************
        'Private Sub LoadOpenPalletCount()
        '    Dim dt As DataTable

        '    Try
        '        dt = Me._objSkullCandy.GetOpenPalletRetailReceiving(Me._iMenuCustID)
        '        With Me.dbgRec_ReceivedCnt
        '            .Caption = "Open Pallet"
        '            .DataSource = dt.DefaultView
        '            .Splits(0).DisplayColumns("Disposition").Width = 180
        '            .Splits(0).DisplayColumns("Qty").Width = 50
        '        End With
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "LoadOpenPallets", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Sub

        ''****************************************************************************************************************
        'Private Sub btnRec_ClosePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec_ClosePallet.Click
        '    Dim i, iCopyQty As Integer
        '    Dim strErrMsg As String = "", strDispositionSDesc As String = ""

        '    Try
        '        If Me.cboRec_ClosePalletDisposition.SelectedValue = 0 Then
        '            MessageBox.Show("Please select disposition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboRec_ClosePalletDisposition.SelectAll() : Me.cboRec_ClosePalletDisposition.Focus()
        '        ElseIf Me._iMenuCustID = 0 Then
        '            MessageBox.Show("System can't define customer ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            Me.cboRec_ClosePalletDisposition.SelectAll() : Me.cboRec_ClosePalletDisposition.Focus()
        '        ElseIf MessageBox.Show("Are you sure you want to close " & Me.cboRec_ClosePalletDisposition.Text & " pallet?", _
        '                               "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
        '            Exit Sub
        '        Else
        '            If Me.txtRec_CopyQty.Text.Trim.Length > 0 Then iCopyQty = CInt(Me.txtRec_CopyQty.Text) Else iCopyQty = 1

        '            strDispositionSDesc = Me.cboRec_ClosePalletDisposition.DataSource.Table.Select("Dcode_ID = " & Me.cboRec_ClosePalletDisposition.SelectedValue)(0)("DCode_SDesc")
        '            If strDispositionSDesc.Trim.Length = 0 Then
        '                MessageBox.Show("System can't define disposition short description.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                Exit Sub
        '            End If

        '            i = Me._objSkullCandy.CloseSCRetailBulkRecPallet(Me._iMenuCustID, Me.cboRec_ClosePalletDisposition.SelectedValue, strDispositionSDesc, Core.ApplicationUser.IDuser, iCopyQty, strErrMsg)
        '            If strErrMsg.Trim.Length > 0 Then
        '                MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '            ElseIf i > 0 Then
        '                Me.cboRec_ClosePalletDisposition.SelectedValue = 0
        '            Else
        '                MessageBox.Show("System has failed to close pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                Me.cboRec_ClosePalletDisposition.SelectAll() : Me.cboRec_ClosePalletDisposition.Focus()
        '            End If

        '            Me.LoadOpenPalletCount()
        '        End If 'Check pallet qty

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "btnRec_ClosePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub

        ''****************************************************************************************************************
        'Private Sub btnRec_ReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec_ReprintPalletLabel.Click
        '    Dim iCopyQty As Integer
        '    Dim strPalletName As String = ""

        '    Try
        '        strPalletName = InputBox("Enter pallet Name:").Trim
        '        If strPalletName.Trim.Length = 0 Then Exit Sub

        '        If Me.txtRec_CopyQty.Text.Trim.Length > 0 Then iCopyQty = CInt(Me.txtRec_CopyQty.Text) Else iCopyQty = 1

        '        If Me._iMenuCustID = 0 Then
        '            MessageBox.Show("System can't define customer ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        Else
        '            Me._objSkullCandy.PrintBulkRecPalletLabel(Me._iMenuCustID, strPalletName, iCopyQty)
        '        End If

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "btnRec_ReprintPalletLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub

        ''****************************************************************************************************************
        'Private Sub cboRec_ClosePalletDisposition_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRec_ClosePalletDisposition.SelectedValueChanged
        '    Try
        '        If Me._booLoadData = False AndAlso Me.cboRec_ClosePalletDisposition.SelectedValue > 0 Then
        '            Me.btnRec_ClosePallet.Visible = True
        '            Me.lblRec_OpenPalletQty.Text = "Qty: " & Me._objSkullCandy.GetOpenRecPalletCountByDisposition(Me._iMenuCustID, Me.cboRec_ClosePalletDisposition.SelectedValue)
        '        Else
        '            Me.btnRec_ClosePallet.Visible = False
        '            Me.lblRec_OpenPalletQty.Text = ""
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "btnRec_RefreshCount_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub

        '****************************************************************************************************************
        Private Sub LoadLocationCount()
            Dim dt As DataTable
            Dim i As Integer

            Try
                dt = Me._objSkullCandy.GetLocationQty(Me._iMenuCustID)
                With Me.dbgRec_Location
                    .Caption = "Location"
                    'Location, UPC, Sku, Dcode_Ldesc as 'Disposition', Count(*) as 'Qty' 
                    .DataSource = dt.DefaultView
                    For i = 0 To dt.Columns.Count - 1
                        If dt.Columns(i).Caption = "Qty" OrElse dt.Columns(i).Caption = "Location" Then
                            .Splits(0).DisplayColumns(i).Width = 50
                        Else
                            .Splits(0).DisplayColumns(i).Width = 130
                        End If
                    Next

                    .Splits(0).DisplayColumns("Dcode_Sdesc").Visible = False
                    .Splits(0).DisplayColumns("Dcode_ID").Visible = False

                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "LoadOpenPallets", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub txts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRec_RMA.KeyPress, txtRec_UPC.KeyPress
            Try
                If Not (Char.IsLetterOrDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) AndAlso e.KeyChar.ToString <> "-" Then
                    e.Handled = True ' Allow only alphanumberic and dash
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub txts_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRec_IPMPPrinterName.KeyUp, txtRec_DevicePrinterName.KeyUp, txtRec_RMA.KeyUp, cboRec_Dispostion.KeyUp, txtRec_UPC.KeyUp, txtPalletName.KeyUp

            Try
                If sender.name = "txtRec_IPMPPrinterName" AndAlso e.KeyValue = Keys.Enter AndAlso txtRec_IPMPPrinterName.Text.Trim.Length > 0 Then
                    txtRec_DevicePrinterName.SelectAll() : txtRec_DevicePrinterName.Focus()
                ElseIf sender.name = "txtRec_DevicePrinterName" AndAlso e.KeyValue = Keys.Enter AndAlso txtRec_DevicePrinterName.Text.Trim.Length > 0 Then
                    txtRec_RMA.SelectAll() : txtRec_RMA.Focus()
                ElseIf sender.name = "txtRec_RMA" Then
                    If e.KeyValue = Keys.Enter AndAlso Me.txtRec_RMA.Text.Trim.Length > 0 Then
                        Me.txtRec_UPC.SelectAll() : Me.txtRec_UPC.Focus()
                    End If
                ElseIf sender.name = "txtRec_UPC" Then
                    If e.KeyValue = Keys.Enter AndAlso Me.txtRec_UPC.Text.Trim.Length > 0 Then
                        If ValidateUPCLength(Me.txtRec_UPC.Text.Trim.Length) = False Then
                            MessageBox.Show("Invalid UPC length.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            Me.cboRec_Dispostion.SelectAll() : Me.cboRec_Dispostion.Focus()
                        End If
                    End If
                ElseIf sender.name = "cboRec_Dispostion" Then
                    If e.KeyValue = Keys.Enter AndAlso Me.cboRec_Dispostion.SelectedValue > 0 Then
                        Me.ProcessReceiving()
                    End If
                ElseIf sender.name = "txtPalletName" Then
                    If e.KeyValue = Keys.Enter AndAlso Me.txtPalletName.Text.Trim.Length > 0 Then
                        Me.ProcessDockShip()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub ProcessReceiving()
            Dim strToday As String = "", strLoc As String = "", strDispositionLDesc As String = ""
            Dim i As Integer = 0, iMimAvailLoc As Integer = 5

            Try
                If Me.txtRec_IPMPPrinterName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter printer name of master pack and inner pack label.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRec_IPMPPrinterName.SelectAll() : Me.txtBSP_MasterPack.Focus()
                ElseIf Me.txtRec_RMA.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter RMA", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRec_RMA.SelectAll() : Me.txtRec_RMA.Focus()
                ElseIf Me.cboRec_Dispostion.SelectedValue = 0 Then
                    MessageBox.Show("Please select disposition", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboRec_Dispostion.SelectAll() : Me.cboRec_Dispostion.Focus()
                ElseIf Me.txtRec_UPC.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter UPC", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRec_UPC.SelectAll() : Me.txtRec_UPC.Focus()
                ElseIf ValidateUPCLength(Me.txtRec_UPC.Text.Trim.Length) = False Then
                    MessageBox.Show("Invalid UPC length.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strDispositionLDesc = Me.cboRec_Dispostion.DataSource.Table.Select("Dcode_ID = " & Me.cboRec_Dispostion.SelectedValue)(0)("DCode_LDesc")
                    strToday = Generic.MySQLServerDateTime(1)
                    If strToday.Trim.Length = 0 Then
                        MessageBox.Show("System has failed to define work date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtRec_UPC.SelectAll() : Me.txtRec_UPC.Focus()
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = Me._objSkullCandy.ReceiveRetailDevice(Me._iMenuCustID, _iMenuLocID, Me.txtRec_RMA.Text.Trim.ToUpper, _
                                                                  Me.cboRec_Dispostion.SelectedValue, Me.cboRec_Dispostion.Text, strDispositionLDesc, _
                                                                  Me.txtRec_UPC.Text.Trim.ToUpper, strToday, Core.ApplicationUser.IDuser, _
                                                                  Me.txtRec_IPMPPrinterName.Text.Trim, Me.txtRec_DevicePrinterName.Text.Trim, _
                                                                  iMimAvailLoc)
                        ' i = Me._objSkullCandy.ReceiveRetailDevice(Me._iMenuCustID, Me.txtRec_RMA.Text.Trim.ToUpper, Me.cboRec_Dispostion.SelectedValue, Me.txtRec_UPC.Text.Trim.ToUpper, CDate(strToday).ToString("yyyy-MM-dd"), Core.ApplicationUser.IDuser)
                        If i > 0 Then
                            Me.Enabled = True : btnRec_RefreshCount_Click(Nothing, Nothing)
                            Me.cboRec_Dispostion.SelectedValue = 0
                            Me.txtRec_UPC.Text = "" : Me.txtRec_UPC.SelectAll() : Me.txtRec_UPC.Focus()
                        Else
                            MessageBox.Show("System has failed receive. Please scan unit again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtRec_UPC.SelectAll() : Me.txtRec_UPC.Focus()
                        End If
                    End If
                End If

            Catch ex As Exception
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                btnRec_RefreshCount_Click(Nothing, Nothing)
                MessageBox.Show(ex.Message, "ProcessReceiving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.cboRec_Dispostion.SelectedValue = 0 : Me.cboRec_Dispostion.SelectAll() : Me.cboBSP_Dispostion.Focus()
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnRec_RefreshCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec_RefreshCount.Click
            Dim strToday As String = ""

            Try
                strToday = Convert.ToDateTime(Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd")

                If Me.txtRec_RMA.Text.Trim.Length > 0 Then Me.lblRec_RMACount.Text = Me._objSkullCandy.GetRetailReceivingCount(Me._iMenuCustID, Me.txtRec_RMA.Text.Trim, , ) Else Me.lblRec_RMACount.Text = "0"
                Me.lblRec_DailyCount.Text = Me._objSkullCandy.GetRetailReceivingCount(Me._iMenuCustID, , , strToday)
                Me.lblRec_UserCount.Text = Me._objSkullCandy.GetRetailReceivingCount(Me._iMenuCustID, , Core.ApplicationUser.IDuser, strToday)

                Me.LoadLocationCount()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRec_RefreshCount_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnRec_CloseLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec_CloseLoc.Click
            Dim dt As DataTable, dtDisp As DataTable
            Dim strLoc As String = "", strToday As String, strDispSDesc As String = "", strUPC As String = "", strSku As String = ""
            Dim iDispositionID As Integer, i As Integer, iPalletShipType As Integer

            Try
                If Me.dbgRec_Location.Columns.Count = 0 OrElse Me.dbgRec_Location.RowCount = 0 Then
                    Exit Sub
                ElseIf Me.dbgRec_Location.Columns("Location").Value.ToString.Trim = "" Then
                    Exit Sub
                ElseIf CInt(Me.dbgRec_Location.Columns("Qty").Value) = 0 Then
                    Exit Sub
                ElseIf Me.txtRec_IPMPPrinterName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter printer name to print master pack and inner pack label.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRec_IPMPPrinterName.SelectAll() : Me.txtBSP_MasterPack.Focus()
                ElseIf Me.txtRec_DevicePrinterName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter printer name to print device label.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRec_DevicePrinterName.SelectAll() : Me.txtRec_DevicePrinterName.Focus()
                Else
                    strLoc = Me.dbgRec_Location.Columns("Location").Value
                    If MessageBox.Show("Are you sure you want to close location '" & strLoc & "'?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                    dt = Me._objSkullCandy.GetLocationQty(Me._iMenuCustID, strLoc)

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("System could not define location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        LoadLocationCount()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        LoadLocationCount()
                    ElseIf IsDBNull(dt.Rows(0)("DCode_ID")) Then
                        MessageBox.Show("Location is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        LoadLocationCount()
                    ElseIf Not IsDBNull(dt.Rows(0)("DCode_ID")) AndAlso CInt(dt.Rows(0)("DCode_ID")) = 0 Then
                        MessageBox.Show("Location is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        LoadLocationCount()
                    ElseIf CInt(dt.Rows(0)("Qty")) = 0 Then
                        MessageBox.Show("Location is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        LoadLocationCount()
                    Else
                        iDispositionID = Me.dbgRec_Location.Columns("DCode_ID").Value
                        dtDisp = Me._objSkullCandy.GetCodeDetailByCodeID(iDispositionID)

                        If dtDisp.Rows.Count = 0 Then
                            MessageBox.Show("Dispostion is not define.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf dtDisp.Rows.Count > 1 Then
                            MessageBox.Show("Dulplicate record.", "Disposition", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            strToday = Generic.MySQLServerDateTime(1)
                            strDispSDesc = dtDisp.Rows(0)("DCode_SDesc")

                            If iDispositionID = 3998 OrElse iDispositionID = 4002 Then  'Scrap & C-Stock
                                iPalletShipType = 1
                                i = Me._objSkullCandy.CloseMasterPack(Me._iMenuCustID, _iMenuLocID, strUPC, strSku, strLoc, iDispositionID, Core.ApplicationUser.IDuser, strToday, strDispSDesc, iPalletShipType, Me.txtRec_IPMPPrinterName.Text.Trim)
                            Else
                                iPalletShipType = 0
                                strUPC = dt.Rows(0)("UPC") : strSku = dt.Rows(0)("Sku")
                                i = Me._objSkullCandy.CloseMasterPack(Me._iMenuCustID, _iMenuLocID, strUPC, strSku, strLoc, iDispositionID, Core.ApplicationUser.IDuser, strToday, strDispSDesc, iPalletShipType, Me.txtRec_IPMPPrinterName.Text.Trim)
                            End If
                            LoadLocationCount()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ProcessReceiving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtDisp)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnRec_ReprintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec_ReprintLabel.Click
            Dim objSkullcandyPrint As PSS.Data.Buisness.SkullcandyPrint
            Try
                If Me.cboRec_LabelTypes.SelectedIndex < 0 Then
                    Exit Sub
                ElseIf Me.txtRec_LabelTypeVal.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter " & Me.cboRec_LabelTypes.Text & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRec_LabelTypeVal.SelectAll() : Me.txtRec_LabelTypeVal.Focus()
                ElseIf (Me.cboRec_LabelTypes.Text = "Inner Pack" OrElse Me.cboRec_LabelTypes.Text = "Master Pack") AndAlso Me.txtRec_IPMPPrinterName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter printer name to print " & Me.cboRec_LabelTypes.Text & " label.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRec_IPMPPrinterName.SelectAll() : Me.txtBSP_MasterPack.Focus()
                ElseIf (Me.cboRec_LabelTypes.Text = "Device" OrElse Me.cboRec_LabelTypes.Text = "RMA") AndAlso Me.txtRec_DevicePrinterName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter printer name to print " & Me.cboRec_LabelTypes.Text & " label.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRec_DevicePrinterName.SelectAll() : Me.txtRec_DevicePrinterName.Focus()
                ElseIf Me.txtRec_ReprintQty.Text.Trim.Length = 0 OrElse (Me.txtRec_ReprintQty.Text) = 0 Then
                    MessageBox.Show("Please enter copy quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRec_ReprintQty.SelectAll() : Me.txtRec_ReprintQty.Focus()
                Else
                    If Me.cboRec_LabelTypes.Text = "Device" Then
                        Me._objSkullCandy.PrintDeviceLabel(CInt(Me.txtRec_LabelTypeVal.Text.Trim), txtRec_DevicePrinterName.Text.Trim)
                    ElseIf Me.cboRec_LabelTypes.Text = "Inner Pack" Then
                        If Me.txtRec_ReprintQty.Text.Trim.Length = 0 OrElse CInt(Me.txtRec_CopyQty.Text) = 0 Then Throw New Exception("Please enter quantity of label.")
                        'Me._objSkullCandy.PrintInnerPackLabel(CInt(Me.txtRec_LabelTypeVal.Text.Trim), Me.txtRec_IPMPPrinterName.Text.Trim, CInt(Me.txtRec_ReprintQty.Text))
                        objSkullcandyPrint = New PSS.Data.Buisness.SkullcandyPrint()
                        objSkullcandyPrint.Print_RetailInnerPackLabel(CInt(Me.txtRec_LabelTypeVal.Text.Trim), 1, Me.txtRec_IPMPPrinterName.Text.Trim)
                    ElseIf Me.cboRec_LabelTypes.Text = "Master Pack" Then
                        Me._objSkullCandy.PrintMasterPackLabel(CInt(Me.txtRec_LabelTypeVal.Text.Trim), Me.txtRec_IPMPPrinterName.Text.Trim)
                    ElseIf Me.cboRec_LabelTypes.Text = "RMA" Then
                        Me._objSkullCandy.PrintRMALabel(Me.txtRec_LabelTypeVal.Text.Trim, Me.txtRec_DevicePrinterName.Text.Trim, CInt(Me.txtRec_ReprintQty.Text))
                    End If
                    txtRec_LabelTypeVal.Text = "" : Me.txtRec_ReprintQty.Text = "1"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboRec_LabelTypes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objSkullcandyPrint = Nothing
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub cboRec_LabelTypes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRec_LabelTypes.SelectedIndexChanged
            Try
                txtRec_LabelTypeVal.Text = ""
                If Me.cboRec_LabelTypes.SelectedIndex < 0 Then
                    Me.lblRec_LabelType.Text = "" : Me.txtRec_ReprintQty.Enabled = False : Me.txtRec_ReprintQty.Text = 1
                ElseIf Me.cboRec_LabelTypes.Text = "Inner Pack" AndAlso Me.cboRec_LabelTypes.Text = "Master Pack" Then
                    Me.lblRec_LabelType.Text = "Master Pack ID:"
                ElseIf Me.cboRec_LabelTypes.Text = "RMA" Then
                    Me.lblRec_LabelType.Text = "RMA:"
                Else
                    Me.lblRec_LabelType.Text = Me.cboRec_LabelTypes.Text & " ID:"
                    txtRec_LabelTypeVal.Focus()
                End If

                If Me.cboRec_LabelTypes.Text = "Inner Pack" OrElse Me.cboRec_LabelTypes.Text = "RMA" Then
                    Me.txtRec_ReprintQty.Enabled = True : Me.txtRec_ReprintQty.Text = 1
                Else
                    Me.txtRec_ReprintQty.Enabled = False : Me.txtRec_ReprintQty.Text = 1
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboRec_LabelTypes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnPrintQCAuditRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintNextQCAuditRpt.Click
            Dim strLoc As String = ""

            Try
                If Me.dbgRec_Location.Columns.Count = 0 OrElse Me.dbgRec_Location.RowCount = 0 Then
                    Exit Sub
                ElseIf Me.dbgRec_Location.Columns("Location").Value.ToString.Trim = "" Then
                    Exit Sub
                ElseIf CInt(Me.dbgRec_Location.Columns("Qty").Value) = 0 Then
                    Exit Sub
                ElseIf Me.dbgRec_Location.Columns("Location").Value.ToString.ToLower = "scrap" Then
                    MessageBox.Show("No QC audit needed for scrap.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strLoc = Me.dbgRec_Location.Columns("Location").Value
                    If MessageBox.Show("Are you sure you want to print the next qc audit report for location '" & strLoc & "'?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                    Me._objSkullCandy.PrintNextQCAuditRpt(Me._iMenuCustID, strLoc)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnPrintQCAuditRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnPrintAllQCAuditRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAllQCAuditRpt.Click
            Dim strLoc As String = ""

            Try
                If Me.dbgRec_Location.Columns.Count = 0 OrElse Me.dbgRec_Location.RowCount = 0 Then
                    Exit Sub
                ElseIf Me.dbgRec_Location.Columns("Location").Value.ToString.Trim = "" Then
                    Exit Sub
                ElseIf CInt(Me.dbgRec_Location.Columns("Qty").Value) = 0 Then
                    Exit Sub
                ElseIf Me.dbgRec_Location.Columns("Location").Value.ToString.ToLower = "scrap" Then
                    MessageBox.Show("No QC audit needed for scrap.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strLoc = Me.dbgRec_Location.Columns("Location").Value
                    If MessageBox.Show("Are you sure you want to print qc audit report for location '" & strLoc & "'?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                    Me._objSkullCandy.PrintAllQCAuditRpt(Me._iMenuCustID, strLoc)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnPrintQCAuditRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Public Function ValidateUPCLength(ByVal iUPCLen As Integer) As Boolean
            Dim dt As DataTable
            Dim booRetVal As Boolean = False
            Dim strLen() As String
            Dim i As Integer

            Try
                If iUPCLen > 0 Then
                    dt = ModManuf.GetExceptionCriteria("SKURET_UPC_LENGTH")
                    If dt.Rows.Count > 1 Then Throw New Exception("Duplicate criteria in database.")

                    If dt.Rows.Count = 0 OrElse IsDBNull(dt.Rows(0)("Generic")) OrElse dt.Rows(0)("Generic").ToString.Length = 0 Then
                        booRetVal = True 'nothing define in database
                    Else
                        strLen = dt.Rows(0)("Generic").ToString.Split(",")
                        For i = 0 To strLen.Length - 1
                            If CInt(strLen(i)) = iUPCLen Then
                                booRetVal = True : Exit For
                            End If
                        Next i
                    End If
                End If

                Return booRetVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************************

#End Region

#Region "Dock Ship"
        '****************************************************************************************************************
        Private Sub ProcessDockShip()
            'Now only ship scrap
            Dim dt As New DataTable(), row As DataRow
            Dim iScrapCount As Integer = 0

            Me.pnlBox.Visible = False : Me.pnlQty.Visible = False
            If Not Me.txtPalletName.Text.Trim.Length > 0 Then
                MessageBox.Show("Please enter a palletname or BoxID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPalletName.SelectAll() : Me.txtPalletName.Focus() : Exit Sub
            End If

            Me._dsShip = Me._objSkullCandy.getRetailPalletData(Me._iMenuCustID, Me.txtPalletName.Text.Trim)
            If Not Me._dsShip.Tables.Count = 3 Then
                MessageBox.Show("Can't find pallet name '" & Me.txtPalletName.Text.Trim & "'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPalletName.SelectAll() : Me.txtPalletName.Focus() : Exit Sub
            Else
                For Each dt In Me._dsShip.Tables
                    If Not dt.Rows.Count > 0 Then
                        MessageBox.Show("No enough data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtPalletName.SelectAll() : Me.txtPalletName.Focus() : Exit Sub
                    End If
                Next
            End If

            'Detail data
            dt = Me._dsShip.Tables("Details")
            For Each row In dt.Rows
                If row("DCode_ID") = 3998 Then
                    iScrapCount += 1
                End If
            Next
            If iScrapCount = 0 Then
                MessageBox.Show("This pallet '" & Me.txtPalletName.Text.Trim & "' is not Scrap. Can't process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPalletName.SelectAll() : Me.txtPalletName.Focus()
            ElseIf iScrapCount = dt.Rows.Count Then
                'Scrap: ship the whole box
                Me.lblDisposition.Text = dt.Rows(0).Item("DCode_LDesc")
                Me.lblPalletNameSelected.Text = Me.txtPalletName.Text
                Me.rbtnDetails.Checked = True : BindData()

            Else
                MessageBox.Show("Found mixed dispositions in this pallet '" & Me.txtPalletName.Text.Trim & "'. Can't process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtPalletName.SelectAll() : Me.txtPalletName.Focus()
            End If
        End Sub

        '****************************************************************************************************************
        Private Sub rbtnDetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnDetails.CheckedChanged
            BindData()
        End Sub

        '****************************************************************************************************************
        Private Sub rbtnByRMA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnByRMA.CheckedChanged
            BindData()
        End Sub

        '****************************************************************************************************************
        Private Sub rbtnByRMAUPC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnByRMAUPC.CheckedChanged
            BindData()
        End Sub

        '****************************************************************************************************************
        Private Sub BindData()

            Dim dt As New DataTable(), row As DataRow
            Dim objV0, ObjV1, ObjV2 As Object

            If Me._dsShip.Tables.Count > 0 AndAlso Me._dsShip.Tables("Details").Rows.Count > 0 Then
                If Me.rbtnDetails.Checked Then
                    dt = Me._dsShip.Tables("Details")
                ElseIf Me.rbtnByRMA.Checked Then
                    dt = Me._dsShip.Tables("ByRMA")
                ElseIf Me.rbtnByRMAUPC.Checked Then
                    dt = Me._dsShip.Tables("ByRMAUPC")
                End If
                Me.tdgData1.DataSource = dt

                objV0 = Me._dsShip.Tables("Details").Compute("Count([Pallett_ID])", "[Pallett_ID]>0")
                ObjV1 = Me._dsShip.Tables("Details").Compute("Sum([Quantity])", "")
                ObjV2 = Me._dsShip.Tables("Details").Compute("Avg([PalletQTY])", "")
                'MessageBox.Show("objV0=" & objV0 & "   Objv1=" & ObjV1 & "  ObjV2=" & ObjV2)
                If objV0 > 0 Then
                    MessageBox.Show("Some or all units in this box are shipped. Can't process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.pnlBox.Visible = False : Me.pnlQty.Visible = False
                    Me.txtPalletName.SelectAll() : Me.txtPalletName.Focus()
                ElseIf ObjV1 = ObjV2 Then
                    Me.lblQty.Text = ObjV1
                    Me.pnlBox.Visible = True : Me.pnlQty.Visible = True
                Else
                    MessageBox.Show("Inconsistent quantity. Can't process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.pnlBox.Visible = False : Me.pnlQty.Visible = False
                    Me.txtPalletName.SelectAll() : Me.txtPalletName.Focus()
                End If
            Else
                Me.pnlBox.Visible = False : Me.pnlQty.Visible = False
                Me.txtPalletName.SelectAll() : Me.txtPalletName.Focus()
            End If

        End Sub

        '****************************************************************************************************************
        Private Sub btnCreateShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateShip.Click
            Dim strShipPalletName As String = Me.lblPalletNameSelected.Text.Trim
            Dim strDate As String = Generic.GetMySqlDateTime("%Y-%m-%d")
            Dim i As Integer = 0

            If Me._dsShip.Tables.Count > 0 AndAlso Me._dsShip.Tables("Details").Rows.Count > 0 Then
                i = Me._objSkullCandy.CreateRetailShipPallet(Me._iMenuCustID, _iMenuLocID, strShipPalletName, _
                                                           strDate, Me.lblQty.Text, Me._dsShip.Tables("Details").Rows(0).Item("BRP_ID"))
                If i > 0 Then
                    MessageBox.Show("Successfully completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me._dsShip.Tables.Clear()
                    Me.pnlBox.Visible = False : Me.pnlQty.Visible = False
                    Me.txtPalletName.Text = "" : Me.txtPalletName.Focus()
                Else
                    MessageBox.Show("Failed to create shipment!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                MessageBox.Show("Nothing to ship!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End Sub

        '****************************************************************************************************************
        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
            Dim indexOfSelectedTab As Integer = TabControl1.SelectedIndex
            Dim selectedTab As System.Windows.Forms.TabPage = TabControl1.SelectedTab

            If indexOfSelectedTab = 1 Then
                Me._dsShip.Tables.Clear()
                Me.pnlBox.Visible = False : Me.pnlQty.Visible = False
                Me.txtPalletName.SelectAll() : Me.txtPalletName.Focus()
            End If
        End Sub

        '****************************************************************************************************************

#End Region

#Region "Reports"
        '****************************************************************************************************************
        Private Sub tpReports_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpReports.VisibleChanged
            Try
                ' *************Load Report Name ***************************
                Me.cboRpt_ReportName.Items.Clear()
                Me.cboRpt_ReportName.Items.Add("Select Report Name")
                Me.cboRpt_ReportName.Items.Add("Daily Receipt Report")
                Me.cboRpt_ReportName.Items.Add("Invoice Report")

                Me.cboRpt_ReportName.Text = "Select Report Name"

                Me.gbRpt_Date.Visible = False
                Me.btnRpt_RunRpt.Text = "" : Me.btnRpt_RunRpt.Visible = False
                _strReportName = ""
                '***********************************************************

                Me.dtpRpt_StartDate.Value = Format(Now.Date, "yyyy-MM-dd")
                Me.dtpRpt_EndDate.Value = Format(Now.Date, "yyyy-MM-dd")

                Me.cboRpt_ReportName.SelectAll()
                Me.cboRpt_ReportName.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpReports_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub cboRpt_ReportName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRpt_ReportName.TextChanged
            Dim dt As DataTable
            Dim dDate As Date = Me.dtpRpt_StartDate.Value
            Dim dBegDate As Date
            Dim dEndDate As Date

            Try
                Me.gbRpt_Date.Visible = False
                Me.btnRpt_RunRpt.Text = ""
                Me.btnRpt_RunRpt.Visible = False

                If Me.cboRpt_ReportName.Text <> "Select Report Name" Then
                    _strReportName = Me.cboRpt_ReportName.Text

                    If _strReportName = "Daily Receipt Report" Then
                        Me.gbRpt_Date.Visible = True
                        Me.dtpRpt_StartDate.Value = Format(Now.Date, "yyyy-MM-dd")
                        Me.dtpRpt_EndDate.Value = Format(Now.Date, "yyyy-MM-dd")
                    ElseIf _strReportName = "Invoice Report" Then
                        Me.gbRpt_Date.Visible = True

                        'Get begin and end dates
                        If WeekdayName(Weekday(dDate)) = "Sunday" Then
                            dBegDate = Generic.DateOfPreviousWeek(dDate, DayOfWeek.Monday, 1)
                        Else
                            dBegDate = Generic.DateOfPreviousWeek(dDate, DayOfWeek.Monday, 0)
                        End If
                        dEndDate = dBegDate.AddDays(6)
                        Me.dtpRpt_StartDate.Value = Format(dBegDate, "yyyy-MM-dd") : Me.dtpRpt_EndDate.Value = Format(dEndDate, "yyyy-MM-dd")
                    End If


                    Me.btnRpt_RunRpt.Text = "Get """ & _strReportName & """"
                    Me.btnRpt_RunRpt.Visible = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboCustomers_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnRpt_RunRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRpt_RunRpt.Click
            Dim strDateStart As String = "", strDateEnd As String = ""

            Try

                If Me.gbRpt_Date.Visible = True AndAlso DateDiff(DateInterval.Day, Me.dtpRpt_StartDate.Value, Me.dtpRpt_EndDate.Value) < 0 Then
                    MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me._iMenuCustID = 0 Then
                    MessageBox.Show("Can't define customer ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    '*************************************
                    'Define user input
                    '*************************************
                    strDateStart = "" : strDateEnd = ""

                    If Me.gbRpt_Date.Visible = True Then
                        strDateStart = Me.dtpRpt_StartDate.Value.ToString("yyyy-MM-dd")
                        strDateEnd = Me.dtpRpt_EndDate.Value.ToString("yyyy-MM-dd")
                    End If

                    '*************************************
                    'Generate Report
                    '*************************************
                    If _strReportName = "Daily Receipt Report" Then
                        Me._objSkullCandy.CreateReceiptReport(Me._strReportName, strDateStart, strDateEnd, Me._iMenuCustID)
                    ElseIf _strReportName = "Invoice Report" Then
                        Me._objSkullCandy.CreateSkullcandyRetailInvoiceRpt(_strReportName, Me._iMenuCustID, strDateStart, strDateEnd)
                    End If
                    '*************************************
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '****************************************************************************************************************

#End Region

#Region "Build Ship Pallet"

        Private Sub cboBSP_Dispostion_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBSP_Dispostion.SelectedValueChanged
            Dim dt As DataTable

            Try
                If Me.cboBSP_Dispostion.SelectedValue > 0 Then
                    dt = Me._objSkullCandy.GetSkullcandyUnshipPallets(Me._iMenuCustID, Me.cboBSP_Dispostion.SelectedValue, )
                    If dt.Rows.Count > 0 Then Me.btnBSP_CreatePalletID.Visible = False Else Me.btnBSP_CreatePalletID.Visible = True
                Else
                    Me.btnBSP_CreatePalletID.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboBSP_Dispostion_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnBSP_CreatePalletID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSP_CreatePalletID.Click
            Dim dt As DataTable
            Dim strDispSDesc As String = "", strToday As String = ""
            Dim iPalletID As Integer

            Try
                If Me.cboBSP_Dispostion.SelectedValue = 0 Then
                    MessageBox.Show("Please select disposition", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBSP_Dispostion.SelectAll() : Me.cboBSP_Dispostion.Focus()
                Else
                    strToday = Generic.MySQLServerDateTime(1)
                    dt = Me._objSkullCandy.GetSkullcandyUnshipPallets(Me._iMenuCustID, Me.cboBSP_Dispostion.SelectedValue)
                    If dt.Rows.Count > 1 Then
                        MessageBox.Show("More than one open pallet for selected disposition. Please notify IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        strDispSDesc = Me.cboBSP_Dispostion.DataSource.Table.Select("Dcode_ID = " & Me.cboBSP_Dispostion.SelectedValue)(0)("DCode_SDesc")
                        iPalletID = Me._objSkullCandy.CreatePalletID(Me._iMenuCustID, _iMenuLocID, Me.cboBSP_Dispostion.SelectedValue, strDispSDesc, strToday, 0)
                        If iPalletID = 0 Then Throw New Exception("System has failed to create pallet.")
                        PopulateOpenPallets(iPalletID)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnBSP_CreatePalletID_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnBSP_ClosePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSP_ClosePallet.Click
            Dim i, iPalletID, iDeviceCnt As Integer
            Dim strPalletName As String = ""
            Dim dtPallet As DataTable, dtLabelData As DataTable
            Dim objGamestopOpt As PSS.Data.Buisness.GameStopOpt

            Try

                '************************
                'Validations
                If CInt(Me.dbgBSP_Pallets.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Pallet name is not selected.")
                ElseIf Me.dbgBSP_Pallets.Columns("Pallet Name").Value.ToString.Trim = "" Then
                    Throw New Exception("Pallet name is not selected.")
                ElseIf MessageBox.Show("Are you sure you want to close this box?", "Close Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                strPalletName = Me.dbgBSP_Pallets.Columns("Pallet Name").Value.ToString.Trim
                iPalletID = Me.dbgBSP_Pallets.Columns("Pallett_id").Value.ToString.Trim

                dtPallet = Me._objSkullCandy.GetSkullcandyUnshipPallets(Me._iMenuCustID, , iPalletID)
                If dtPallet.Rows.Count = 0 Then
                    MessageBox.Show("Pallet does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dtPallet.Rows.Count > 1 Then
                    MessageBox.Show("Pallet name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not IsDBNull(dtPallet.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Pallet has been closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf CInt(dtPallet.Rows(0)("Pallet_Invalid")) = 1 Then
                    MessageBox.Show("Pallet has been removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf CInt(dtPallet.Rows(0)("Pallet_SkuLen")) <> 3998 AndAlso Me.txtBSP_WHLocation.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter warehouse location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtBSP_WHLocation.SelectAll() : Me.txtBSP_WHLocation.Focus() : Exit Sub
                Else

                    iDeviceCnt = Me._objSkullCandy.GetDeviceCntInPallet(iPalletID)
                    If iDeviceCnt = 0 Then Throw New Exception("Pallet is empty.")

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = Me._objSkullCandy.CloseAllInvalidMasterPack(iPalletID)

                    i = Me._objSkullCandy.CloseSkullcandyPallet(iPalletID, Me.txtBSP_WHLocation.Text.Trim.ToUpper, iDeviceCnt)
                    If i = 0 Then Throw New Exception("System has failed to close the pallet.")

                    Me.cboBSP_Dispostion.SelectedValue = CInt(Me.dbgBSP_Pallets.Columns("Pallet_ShipType").Value)

                    'Refresh Pallet 
                    Me.PopulateOpenPallets()

                    objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
                    dtLabelData = objGamestopOpt.GetShipPalletData(strPalletName, iDeviceCnt, "WH Loc: " & Me.txtBSP_WHLocation.Text.Trim.ToUpper, dtPallet.Rows(0)("Disposition"), New String() {"Shipper:", "", "Approval:"})
                    objGamestopOpt.PrintPalletLabel(dtLabelData, 1)

                    'Print Template
                    'Me._objSkullCandy.PrintRetailPalletReport(iPalletID)
                    CreatePalletDetail(strPalletName, 1, 1)

                    '******************************
                    'Reset Screen control properties.
                    Me.lblBSP_PalletName.Text = "" : Me.txtBSP_WHLocation.Text = ""
                    Me.lblBSP_MasterpackQty.Text = 0 : Me.lblBSP_PalletQty.Text = 0
                    Me.lstBSP_MasterPacks.DataSource = Nothing
                    Me.pnlBSP_Pallet.Visible = False

                End If
                '******************************
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnBSP_ClosePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dtPallet) : Generic.DisposeDT(dtLabelData) : objGamestopOpt = Nothing
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnBSP_ReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSP_Reprint.Click
            Dim iCopyQty As Integer = 1
            Dim strPalletName As String = ""
            Dim dt, dt2, dtDisposition As DataTable
            Dim objGamestopOpt As PSS.Data.Buisness.GameStopOpt

            Try
                strPalletName = InputBox("Enter pallet Name:").Trim
                If strPalletName.Trim.Length = 0 Then Exit Sub

                If Me._iMenuCustID = 0 Then
                    MessageBox.Show("System can't define customer ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboBSP_ReprintType.SelectedIndex < 0 Then
                    MessageBox.Show("Please select what to reprint.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else

                    dt = Data.Production.Shipping.GetPalletInfoByName(strPalletName, Me._iMenuCustID) 'New process

                    'Old process---------------------------------------------------------------------------------
                    If dt.Rows.Count = 0 AndAlso Me.cboBSP_ReprintType.Text = "Pallet Label" Then
                        dt2 = Me._objSkullCandy.getPalletData_OldProcess(strPalletName) 'Old Process
                        If dt2.Rows.Count = 0 Then
                            MessageBox.Show("Pallet does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ElseIf dt2.Rows.Count > 1 Then
                            MessageBox.Show("Pallet name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ElseIf CInt(dt2.Rows(0)("DeviceCount")) = 0 Then
                            MessageBox.Show("Pallet is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
                            objGamestopOpt.PrintPalletLabel(dt2, 1)
                            Exit Sub
                        End If
                    End If
                    If dt.Rows.Count = 0 AndAlso Me.cboBSP_ReprintType.Text = "Pallet Manifest" Then
                        CreatePalletDetail(strPalletName, 1, 1) : Exit Sub 'Old Process
                    End If

                    'New Process----------------------------------------------------------------------------------
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Pallet does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Pallet name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                        MessageBox.Show("Pallet is still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf CInt(dt.Rows(0)("Pallett_QTY")) = 0 Then
                        MessageBox.Show("Pallet is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        Select Case Me.cboBSP_ReprintType.Text
                            Case "Pallet Label"
                                dtDisposition = Me._objSkullCandy.GetCodeDetailByCodeID(dt.Rows(0)("Pallet_SkuLen"))
                                If dtDisposition.Rows.Count = 0 Then Throw New Exception("Disposition is missing.")
                                objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
                                dt2 = objGamestopOpt.GetShipPalletData(strPalletName, CInt(dt.Rows(0)("Pallett_QTY")), "WH Loc: " & dt.Rows(0)("WHLocation"), dtDisposition.Rows(0)("DCode_LDesc"), New String() {"Shipper:", "", "Approval:"})
                                objGamestopOpt.PrintPalletLabel(dt2, 1)
                            Case "Pallet Manifest"
                                CreatePalletDetail(strPalletName, 1, 1)
                            Case Else
                                MessageBox.Show("This reprint function '" & Me.cboBSP_ReprintType.Text & "' is not available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End Select
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnBSP_ReprintPalletLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt) : Generic.DisposeDT(dt2) : Generic.DisposeDT(dtDisposition)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub PopulateOpenPallets(Optional ByVal iPallettID As Integer = 0)
            Dim dt As DataTable
            Dim i As Integer

            Try
                Me.dbgBSP_Pallets.DataSource = Nothing
                Me.txtBSP_MasterPack.Text = ""
                Me.lstBSP_MasterPacks.DataSource = Nothing
                Me.lblBSP_PalletName.Text = ""
                Me.lblBSP_MasterpackQty.Text = "0" : Me.lblBSP_PalletQty.Text = "0"
                Me.pnlBSP_Pallet.Visible = False
                Me.btnBSP_CreatePalletID.Visible = False

                dt = Me._objSkullCandy.GetSkullcandyUnshipPallets(Me._iMenuCustID, )
                With Me.dbgBSP_Pallets
                    .DataSource = dt.DefaultView
                    'Heading style (Horizontal Alignment to Center)
                    For i = 0 To (dt.Columns.Count - 1)
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).Visible = False
                    Next
                    'header forecolor
                    .Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(3).HeadingStyle.ForeColor = .ForeColor.Black

                    'Set individual column data horizontal alignment
                    .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                    .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                    'Body Forecolor
                    .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
                    .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black

                    'Set Column Widths
                    .Splits(0).DisplayColumns("Pallet Name").Width = 160
                    .Splits(0).DisplayColumns("Disposition").Width = 200

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("Pallet Name").Visible = True
                    .Splits(0).DisplayColumns("Disposition").Visible = True

                    .AlternatingRows = True

                    For i = 0 To .RowCount - 1
                        If .Columns("Pallett_ID").CellValue(i) = iPallettID Then
                            Exit Sub
                        End If
                        .MoveNext()
                    Next i
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub dbgBSP_Pallets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgBSP_Pallets.Click
            Try
                Me.ProcessPalletSelection()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "dbgBSP_Pallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub dbgBSP_Pallets_RowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgBSP_Pallets.RowColChange
            Try
                Me.ProcessPalletSelection()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "dbgBSP_Pallets_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub ProcessPalletSelection()
            Dim strShipType As String = ""
            Dim i As Integer = 0

            Try
                Me.lblBSP_PalletName.Text = ""
                Me.lblBSP_MasterpackQty.Text = "0" : Me.lblBSP_PalletQty.Text = "0"
                Me.txtBSP_MasterPack.Text = "" : Me.txtBSP_WHLocation.Text = ""
                Me.lstBSP_MasterPacks.DataSource = Nothing
                Me.pnlBSP_Pallet.Visible = True
                Me.btnBSP_CreatePalletID.Visible = False

                If Me.dbgBSP_Pallets.Columns.Count = 0 OrElse Me.dbgBSP_Pallets.RowCount = 0 Then
                    Me.pnlBSP_Pallet.Visible = False : Exit Sub
                End If

                If Me.dbgBSP_Pallets.Columns("Pallet Name").Value.ToString.Trim = "" Then Exit Sub

                Me.lblBSP_PalletName.Text = Me.dbgBSP_Pallets.Columns("Pallet Name").Value.ToString

                Me.txtBSP_MasterPack.Visible = False
                Me.btnBSP_RemoveAllMPIDs.Visible = False : Me.btnBSP_RemoveMPID.Visible = False
                Me.btnBSP_Reopen.Enabled = False

                Me.RefreshMPList()

                Me.txtBSP_WHLocation.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub RefreshMPList()
            Dim dt1 As DataTable
            Dim iPallet_ID As Integer = 0
            Dim strPalletName As String = ""

            Try
                '************************
                'Validations
                iPallet_ID = CInt(Me.dbgBSP_Pallets.Columns("Pallett_ID").Value.ToString)
                strPalletName = Me.dbgBSP_Pallets.Columns("Pallet Name").Value.ToString.Trim

                If iPallet_ID = 0 Then
                    Throw New Exception("Pallet is not selected.")
                ElseIf strPalletName.Trim = "" Then
                    Throw New Exception("Pallet is not selected.")
                End If

                '*******************************************
                'Get all devices add put them in them in list box for a pallet
                dt1 = Me._objSkullCandy.GetPalletContent(iPallet_ID)
                Me.lstBSP_MasterPacks.DataSource = dt1.DefaultView
                Me.lstBSP_MasterPacks.ValueMember = dt1.Columns("MP_ID").ToString
                Me.lstBSP_MasterPacks.DisplayMember = dt1.Columns("MP_ID").ToString
                Me.lblBSP_PalletName.Text = strPalletName

                '*******************************************
                Me.lblBSP_MasterpackQty.Text = dt1.Rows.Count
                If Not IsDBNull(dt1.Compute("Sum(Qty)", "")) Then Me.lblBSP_PalletQty.Text = dt1.Compute("Sum(Qty)", "") Else Me.lblBSP_PalletQty.Text = "0"

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
                Me.txtBSP_MasterPack.Focus()
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnBSP_Reopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSP_Reopen.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable

            Try
                '************************
                strPallet = InputBox("Enter Box ID.", "Reopen Box")
                If strPallet = "" Then Throw New Exception("Please enter a Box ID if you want to re-open it.")

                'Refresh open box list
                Me.PopulateOpenPallets()

                dt = Data.Production.Shipping.GetPalletInfoByName(strPallet, Me._iMenuCustID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Pallet does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Pallet name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Box has been shipped. Not allow to reopen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Box is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not IsNothing(Me.dbgBSP_Pallets.DataSource) AndAlso Me.dbgBSP_Pallets.RowCount > 0 AndAlso Me.dbgBSP_Pallets.DataSource.Table.Select("Pallet_SkuLen = '" & dt.Rows(0)("Pallet_SkuLen") & "'").Length > 0 Then
                    MessageBox.Show("There is an open pallet in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    i = Me._objSkullCandy.ReopenSkullcandyPallet(dt.Rows(0)("Pallett_ID"))
                    If i = 0 Then Throw New Exception("Box was not reopened.")

                    Me.cboBSP_Dispostion.SelectedValue = dt.Rows(0)("Pallet_SkuLen")

                    'Refresh Pallet( Box )
                    Me.PopulateOpenPallets(dt.Rows(0)("Pallett_ID"))

                    '************************
                    Me.lstBSP_MasterPacks.DataSource = Nothing
                    Me.lblBSP_MasterpackQty.Text = "0" : Me.lblBSP_PalletQty.Text = "0"
                    Me.lblBSP_PalletName.Text = ""
                    Me.pnlBSP_Pallet.Visible = False
                    '************************
                    Me.txtBSP_MasterPack.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnBSP_Reopen_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnDeletePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSP_DeletePallet.Click
            Dim i As Integer = 0
            Dim dt As DataTable

            Try
                If CInt(Me.dbgBSP_Pallets.Columns("Pallett_ID").Value) = 0 Then Exit Sub

                If MessageBox.Show("Are you sure you want to delete selected Box?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    dt = Data.Production.Shipping.GetPalletInfoByName(Me.dbgBSP_Pallets.Columns("Pallet Name").Value, Me._iMenuCustID)

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    If Me._objSkullCandy.GetDeviceCntInPallet(Me.dbgBSP_Pallets.Columns("Pallett_ID").Value) > 0 Then
                        MessageBox.Show("Pallet is not empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        i = PSS.Data.Production.Shipping.DeleteEmptyPallet(CInt(Me.dbgBSP_Pallets.Columns("Pallett_ID").Value), PSS.Core.ApplicationUser.IDuser)
                        MessageBox.Show("Pallet has been deleted.")

                        Me.PopulateOpenPallets()
                        Me.lstBSP_MasterPacks.DataSource = Nothing
                        Me.lblBSP_PalletName.Text = ""
                        Me.lblBSP_PalletQty.Text = "0" : Me.lblBSP_MasterpackQty.Text = "0"
                        Me.pnlBSP_Pallet.Visible = False
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDeletePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnBSP_RefreshPalletList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSP_RefreshPalletList.Click
            Try
                Me.PopulateOpenPallets()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDeletePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnRecreatPalletDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecreatPalletDetail.Click
            Dim strPalletName As String = "", strMsg As String = ""
            Dim iPrint As Integer = 0

            Try
                strPalletName = InputBox("Enter pallet Name:").Trim
                If strPalletName.Trim.Length = 0 Then Exit Sub

                If MessageBox.Show("Do you want to print the report?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then iPrint = 1

                CreatePalletDetail(strPalletName, iPrint, 0)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRecreatDetail_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub CreatePalletDetail(ByVal strPalletName As String, ByVal iPrintReport As Integer, ByVal iNoConfirmMsg As Integer)
            Dim strPathFileName As String = "", strMsg As String = ""
            Dim dt As DataTable
            Dim iArrText(0) As Integer, iTotal As Integer

            Try
                dt = Me._objSkullCandy.getRetailPalletManifestData(Me._objSkullCandy.Retail_CUSTOMERID, strPalletName)

                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Compute("Sum(Quantity)", "")) Then iTotal = dt.Compute("Sum(Quantity)", "")
                    iArrText(0) = 1
                    strPathFileName = strPalletManifestPath & strPalletName & ".xls"
                    Generic.CreateExelReport(dt, 1, strPathFileName, 0, 1, iPrintReport, iNoConfirmMsg, "F", iArrText, iTotal)
                Else
                    strMsg = "No data for this pallet: " & strPalletName & ". " & Environment.NewLine
                    strMsg &= "Or this pallet does not exist in the system."
                    MessageBox.Show(strMsg, "btnRecreatDetail_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub txtBSP_MasterPack_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBSP_MasterPack.KeyUp

        End Sub

        '****************************************************************************************************************
        Private Sub btnBSP_RemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSP_RemoveMPID.Click

        End Sub

        '****************************************************************************************************************
        Private Sub btnBSP_RemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSP_RemoveAllMPIDs.Click

        End Sub

        '****************************************************************************************************************

#End Region

#Region "Location"

        '****************************************************************************************************************
        Public Function LoadLocationData()
            Dim dt As DataTable
            Dim i, iCt1, iCt2 As Integer
            Dim strColName As String = ""

            Try
                dt = Me._objSkullCandy.GetLocation(False)

                Me.lblLoc_Count.Text = ""
                If dt.Rows.Count > 0 Then
                    iCt1 = dt.Rows.Count
                    iCt2 = dt.Compute("Count(UPC)", "UPC=''")
                    Me.lblLoc_Count.Text = "Available Location Count: " & iCt2.ToString & ",    Being Used Location Count: " & (iCt1 - iCt2).ToString
                End If

                With Me.dbgLoc_Data
                    .DataSource = dt.DefaultView
                    For i = 0 To dt.Columns.Count - 1
                        strColName = dt.Columns(i).Caption
                        If strColName = "Location" OrElse strColName = "UPC" OrElse strColName = "Sku" OrElse strColName = "Disposition" Then
                            .Splits(0).DisplayColumns(i).Width = 130
                        ElseIf strColName = "Qty" OrElse strColName = "MaxQty" OrElse strColName = "ActiveDesc" Then
                            .Splits(0).DisplayColumns(i).Width = 60
                        Else
                            .Splits(0).DisplayColumns(i).Visible = False
                        End If
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************************
        Private Sub btnLocRefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocRefreshData.Click
            Try
                LoadLocationData()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnLocRefreshData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************

#End Region


       
    End Class
End Namespace