'******************************************************************************
'Modify:
'1) 01/06/2010 By Lan Nguyen : Separate function and cosmetic parts to collect 
'    Failcode and Repair code for Samsung, LG, Motorola Warranty Claim
'******************************************************************************

Option Explicit On 

Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports System.IO

Namespace Gui.techscreen

    Public Class frmNewTech
        Inherits System.Windows.Forms.Form

		Private _objModelManuf As New PSS.Data.Buisness.ModManuf()

        Private Const strdelimiter As String = "~"

        Private _strScreenName As String = "REPAIR"
        Private _iScreenID As Integer = 0
        Private Const vBuffer As Integer = 5
        Private Const hBuffer As Integer = 5
        Private Const btnWidth = 120
        Private Const btnHeight = 50

        Private btnLeft As Int32 = 5
        Private btnTop As Int32 = 5

        Private pnlLeft As Integer
        Private pnlWidth As Integer
        Private origFrmWidth As Integer
        Private formDiffWidth As Integer
        Private colCount As Integer

        Private _objNewTech As PSS.Data.Buisness.NewTech

        Private _device As Device = Nothing
        Private tmpBinLoc As String
        Private tmpDeviceID, tmpModelID, tmpManufID, tmpProdID, tmpTrayID, tmpLoc, tmpCustID, tmpWO, tmpDeviceType, tmpConsignedParts, tmpCustCRbill As Integer
        Private vManufWrty, _iPSSWrty, _iMachineGrpID, _iDeviceWipOwner, _iBillType As Integer
        Private dtCustomerSet, _dtAWAP As DataTable
        Private rPresent, _drPreBillData, _drCelloptData, _drDevice As DataRow
        Private _dbBERTarget As Double = 0.0
        Private _iTFFlatRate As Integer = -1

        'WARRANTY CLAIM
        Private _booPopulatingReflowCheckListFlg As Boolean = False, _booStationCheck As Boolean = True

        'This customer ID send from the menu selection
		Private _iSCustID As Integer = 0

		Private _IsMgsDbrOrNer As Boolean = False
        Private _IsSNReady As Boolean = False
        Private _bAllowSoftwareProcess As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal iBillType As Integer = 2, _
                       Optional ByVal iCustID As Integer = 0, _
                       Optional ByVal strScreenName As String = "", _
                       Optional ByVal iCheckDeviceStation As Integer = -1, _
                       Optional ByVal iScreenID As Integer = 0, _
                       Optional ByVal bAllowSoftwareProcess As Boolean = False)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iBillType = iBillType   'Magic number 1: Pre-Bill, 2:Tech  3:Pre-Bill Lot

            If iCustID > 0 Then
                Me._iSCustID = iCustID
                Me.lblCustName.Text = PSS.Data.Buisness.Generic.GetCustomerName(iCustID)
            End If

            If strScreenName.Trim.Length > 0 Then Me._strScreenName = strScreenName
            If iCheckDeviceStation >= 0 Then
                If iCheckDeviceStation = 0 Then Me._booStationCheck = False Else Me._booStationCheck = True
            End If
            Me._iScreenID = iScreenID
            Me._bAllowSoftwareProcess = bAllowSoftwareProcess
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
        Friend WithEvents lblTray As System.Windows.Forms.Label
        Friend WithEvents tabMain As System.Windows.Forms.TabControl
        Friend WithEvents btnExpand As System.Windows.Forms.Button
        Friend WithEvents btnResize As System.Windows.Forms.Button
        Friend WithEvents tbParts As System.Windows.Forms.TabPage
        Friend WithEvents tbServices As System.Windows.Forms.TabPage
        Friend WithEvents pnlBill As System.Windows.Forms.Panel
        Friend WithEvents pnlService As System.Windows.Forms.Panel
        Friend WithEvents gridBilling As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblSelected As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents tbScrap As System.Windows.Forms.TabPage
        Friend WithEvents pnlScrap As System.Windows.Forms.Panel
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents lblLotNum As System.Windows.Forms.Label
        Friend WithEvents txtLotNum As System.Windows.Forms.TextBox
        Friend WithEvents lblATT As System.Windows.Forms.Label
        Friend WithEvents lblRejectReason As System.Windows.Forms.Label
        Friend WithEvents lblUnitPartsCost As System.Windows.Forms.Label
        Friend WithEvents lblAPCGoal As System.Windows.Forms.Label
        Friend WithEvents lblDailyAPC As System.Windows.Forms.Label
        Friend WithEvents lblCustName As System.Windows.Forms.Label
        Friend WithEvents tbReflow As System.Windows.Forms.TabPage
        Friend WithEvents chklstReflowBillcodes As System.Windows.Forms.CheckedListBox
        Friend WithEvents tpFParts As System.Windows.Forms.TabPage
        Friend WithEvents pnlFuncParts As System.Windows.Forms.Panel
        Friend WithEvents lblQCResult As System.Windows.Forms.Label
        Friend WithEvents lblRFResult As System.Windows.Forms.Label
        Friend WithEvents lblReflowFailDesc As System.Windows.Forms.Label
        Friend WithEvents lblReflowRepDesc As System.Windows.Forms.Label
        Friend WithEvents btnCompleteRepair As System.Windows.Forms.Button
        Friend WithEvents tbRVParts As System.Windows.Forms.TabPage
        Friend WithEvents tbRVFParts As System.Windows.Forms.TabPage
        Friend WithEvents pnlRVParts As System.Windows.Forms.Panel
        Friend WithEvents pnlRVFParts As System.Windows.Forms.Panel
        Friend WithEvents lblWarrantyStatus As System.Windows.Forms.Label
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents tbTestResults As System.Windows.Forms.TabPage
        Friend WithEvents pnlTestResults As System.Windows.Forms.Panel
        Friend WithEvents lblTestResult_QC As System.Windows.Forms.Label
        Friend WithEvents lblTestResult_RF2 As System.Windows.Forms.Label
        Friend WithEvents lblTestResult_RF1 As System.Windows.Forms.Label
        Friend WithEvents lblTestResult_Triage As System.Windows.Forms.Label
        Friend WithEvents _LabelTestResult_QC As System.Windows.Forms.Label
        Friend WithEvents _LabelTestResult_RF2 As System.Windows.Forms.Label
        Friend WithEvents _LabelTestResult_RF1 As System.Windows.Forms.Label
        Friend WithEvents _LabelTestResult_Triage As System.Windows.Forms.Label
        Friend WithEvents tpAccessories As System.Windows.Forms.TabPage
        Friend WithEvents pnlAccessories As System.Windows.Forms.Panel
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents txtTray As System.Windows.Forms.TextBox
        Friend WithEvents txtTechNotes As System.Windows.Forms.TextBox
        Friend WithEvents btnSaveTechNotes As System.Windows.Forms.Button
        Friend WithEvents lblTechNotesUpdDate As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents tbNeedPart As System.Windows.Forms.TabPage
        Friend WithEvents pnlNeededParts As System.Windows.Forms.Panel
        Friend WithEvents tbNeedAccessories As System.Windows.Forms.TabPage
        Friend WithEvents pnlNeededAccessories As System.Windows.Forms.Panel
        Friend WithEvents lstFailCodes As System.Windows.Forms.ListBox
        Friend WithEvents cboCodes As C1.Win.C1List.C1Combo
        Friend WithEvents gbTechFailureCodes As System.Windows.Forms.GroupBox
        Friend WithEvents btnRemoveCode As System.Windows.Forms.Button
        Friend WithEvents tbSW As System.Windows.Forms.TabPage
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNewTech))
            Me.lblTray = New System.Windows.Forms.Label()
            Me.tabMain = New System.Windows.Forms.TabControl()
            Me.tbParts = New System.Windows.Forms.TabPage()
            Me.pnlBill = New System.Windows.Forms.Panel()
            Me.tbServices = New System.Windows.Forms.TabPage()
            Me.pnlService = New System.Windows.Forms.Panel()
            Me.tbRVParts = New System.Windows.Forms.TabPage()
            Me.pnlRVParts = New System.Windows.Forms.Panel()
            Me.tbRVFParts = New System.Windows.Forms.TabPage()
            Me.pnlRVFParts = New System.Windows.Forms.Panel()
            Me.tpFParts = New System.Windows.Forms.TabPage()
            Me.lblQCResult = New System.Windows.Forms.Label()
            Me.lblRFResult = New System.Windows.Forms.Label()
            Me.pnlFuncParts = New System.Windows.Forms.Panel()
            Me.tbReflow = New System.Windows.Forms.TabPage()
            Me.lblReflowRepDesc = New System.Windows.Forms.Label()
            Me.lblReflowFailDesc = New System.Windows.Forms.Label()
            Me.chklstReflowBillcodes = New System.Windows.Forms.CheckedListBox()
            Me.tbTestResults = New System.Windows.Forms.TabPage()
            Me.gbTechFailureCodes = New System.Windows.Forms.GroupBox()
            Me.btnRemoveCode = New System.Windows.Forms.Button()
            Me.lstFailCodes = New System.Windows.Forms.ListBox()
            Me.cboCodes = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblTechNotesUpdDate = New System.Windows.Forms.Label()
            Me.btnSaveTechNotes = New System.Windows.Forms.Button()
            Me.txtTechNotes = New System.Windows.Forms.TextBox()
            Me.pnlTestResults = New System.Windows.Forms.Panel()
            Me._LabelTestResult_QC = New System.Windows.Forms.Label()
            Me.lblTestResult_QC = New System.Windows.Forms.Label()
            Me._LabelTestResult_RF2 = New System.Windows.Forms.Label()
            Me.lblTestResult_RF2 = New System.Windows.Forms.Label()
            Me._LabelTestResult_RF1 = New System.Windows.Forms.Label()
            Me.lblTestResult_RF1 = New System.Windows.Forms.Label()
            Me._LabelTestResult_Triage = New System.Windows.Forms.Label()
            Me.lblTestResult_Triage = New System.Windows.Forms.Label()
            Me.tpAccessories = New System.Windows.Forms.TabPage()
            Me.pnlAccessories = New System.Windows.Forms.Panel()
            Me.tbScrap = New System.Windows.Forms.TabPage()
            Me.pnlScrap = New System.Windows.Forms.Panel()
            Me.tbNeedPart = New System.Windows.Forms.TabPage()
            Me.pnlNeededParts = New System.Windows.Forms.Panel()
            Me.tbNeedAccessories = New System.Windows.Forms.TabPage()
            Me.pnlNeededAccessories = New System.Windows.Forms.Panel()
            Me.btnExpand = New System.Windows.Forms.Button()
            Me.btnResize = New System.Windows.Forms.Button()
            Me.gridBilling = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblSelected = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.lblLotNum = New System.Windows.Forms.Label()
            Me.txtLotNum = New System.Windows.Forms.TextBox()
            Me.lblATT = New System.Windows.Forms.Label()
            Me.lblRejectReason = New System.Windows.Forms.Label()
            Me.lblAPCGoal = New System.Windows.Forms.Label()
            Me.lblUnitPartsCost = New System.Windows.Forms.Label()
            Me.lblDailyAPC = New System.Windows.Forms.Label()
            Me.lblCustName = New System.Windows.Forms.Label()
            Me.btnCompleteRepair = New System.Windows.Forms.Button()
            Me.lblWarrantyStatus = New System.Windows.Forms.Label()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.txtTray = New System.Windows.Forms.TextBox()
            Me.tbSW = New System.Windows.Forms.TabPage()
            Me.tabMain.SuspendLayout()
            Me.tbParts.SuspendLayout()
            Me.tbServices.SuspendLayout()
            Me.tbRVParts.SuspendLayout()
            Me.tbRVFParts.SuspendLayout()
            Me.tpFParts.SuspendLayout()
            Me.tbReflow.SuspendLayout()
            Me.tbTestResults.SuspendLayout()
            Me.gbTechFailureCodes.SuspendLayout()
            CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlTestResults.SuspendLayout()
            Me.tpAccessories.SuspendLayout()
            Me.tbScrap.SuspendLayout()
            Me.tbNeedPart.SuspendLayout()
            Me.tbNeedAccessories.SuspendLayout()
            CType(Me.gridBilling, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTray
            '
            Me.lblTray.Location = New System.Drawing.Point(225, 40)
            Me.lblTray.Name = "lblTray"
            Me.lblTray.Size = New System.Drawing.Size(32, 16)
            Me.lblTray.TabIndex = 141
            '
            'tabMain
            '
            Me.tabMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tabMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbParts, Me.tbServices, Me.tbRVParts, Me.tbRVFParts, Me.tpFParts, Me.tbReflow, Me.tbTestResults, Me.tpAccessories, Me.tbScrap, Me.tbNeedPart, Me.tbNeedAccessories, Me.tbSW})
            Me.tabMain.Location = New System.Drawing.Point(8, 72)
            Me.tabMain.Name = "tabMain"
            Me.tabMain.SelectedIndex = 0
            Me.tabMain.Size = New System.Drawing.Size(992, 481)
            Me.tabMain.TabIndex = 108
            '
            'tbParts
            '
            Me.tbParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlBill})
            Me.tbParts.Location = New System.Drawing.Point(4, 22)
            Me.tbParts.Name = "tbParts"
            Me.tbParts.Size = New System.Drawing.Size(984, 455)
            Me.tbParts.TabIndex = 0
            Me.tbParts.Text = "PARTS"
            '
            'pnlBill
            '
            Me.pnlBill.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlBill.AutoScroll = True
            Me.pnlBill.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlBill.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlBill.Location = New System.Drawing.Point(8, 8)
            Me.pnlBill.Name = "pnlBill"
            Me.pnlBill.Size = New System.Drawing.Size(968, 433)
            Me.pnlBill.TabIndex = 108
            '
            'tbServices
            '
            Me.tbServices.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlService})
            Me.tbServices.Location = New System.Drawing.Point(4, 22)
            Me.tbServices.Name = "tbServices"
            Me.tbServices.Size = New System.Drawing.Size(984, 455)
            Me.tbServices.TabIndex = 1
            Me.tbServices.Text = "SERVICES"
            '
            'pnlService
            '
            Me.pnlService.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlService.AutoScroll = True
            Me.pnlService.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlService.Location = New System.Drawing.Point(8, 8)
            Me.pnlService.Name = "pnlService"
            Me.pnlService.Size = New System.Drawing.Size(968, 433)
            Me.pnlService.TabIndex = 109
            '
            'tbRVParts
            '
            Me.tbRVParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlRVParts})
            Me.tbRVParts.Location = New System.Drawing.Point(4, 22)
            Me.tbRVParts.Name = "tbRVParts"
            Me.tbRVParts.Size = New System.Drawing.Size(984, 455)
            Me.tbRVParts.TabIndex = 5
            Me.tbRVParts.Text = "RV PARTS"
            '
            'pnlRVParts
            '
            Me.pnlRVParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlRVParts.AutoScroll = True
            Me.pnlRVParts.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlRVParts.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlRVParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlRVParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlRVParts.Location = New System.Drawing.Point(8, 11)
            Me.pnlRVParts.Name = "pnlRVParts"
            Me.pnlRVParts.Size = New System.Drawing.Size(968, 433)
            Me.pnlRVParts.TabIndex = 109
            '
            'tbRVFParts
            '
            Me.tbRVFParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlRVFParts})
            Me.tbRVFParts.Location = New System.Drawing.Point(4, 22)
            Me.tbRVFParts.Name = "tbRVFParts"
            Me.tbRVFParts.Size = New System.Drawing.Size(984, 455)
            Me.tbRVFParts.TabIndex = 6
            Me.tbRVFParts.Text = "RV FUNCTIONAL PARTS"
            '
            'pnlRVFParts
            '
            Me.pnlRVFParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlRVFParts.AutoScroll = True
            Me.pnlRVFParts.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlRVFParts.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlRVFParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlRVFParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlRVFParts.Location = New System.Drawing.Point(8, 11)
            Me.pnlRVFParts.Name = "pnlRVFParts"
            Me.pnlRVFParts.Size = New System.Drawing.Size(968, 433)
            Me.pnlRVFParts.TabIndex = 109
            '
            'tpFParts
            '
            Me.tpFParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblQCResult, Me.lblRFResult, Me.pnlFuncParts})
            Me.tpFParts.Location = New System.Drawing.Point(4, 22)
            Me.tpFParts.Name = "tpFParts"
            Me.tpFParts.Size = New System.Drawing.Size(984, 455)
            Me.tpFParts.TabIndex = 4
            Me.tpFParts.Text = "FUNCTIONAL PARTS"
            '
            'lblQCResult
            '
            Me.lblQCResult.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblQCResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQCResult.ForeColor = System.Drawing.Color.Blue
            Me.lblQCResult.ImageAlign = System.Drawing.ContentAlignment.BottomRight
            Me.lblQCResult.Location = New System.Drawing.Point(656, 3)
            Me.lblQCResult.Name = "lblQCResult"
            Me.lblQCResult.Size = New System.Drawing.Size(320, 16)
            Me.lblQCResult.TabIndex = 111
            Me.lblQCResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRFResult
            '
            Me.lblRFResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRFResult.ForeColor = System.Drawing.Color.Blue
            Me.lblRFResult.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.lblRFResult.Location = New System.Drawing.Point(8, 3)
            Me.lblRFResult.Name = "lblRFResult"
            Me.lblRFResult.Size = New System.Drawing.Size(384, 16)
            Me.lblRFResult.TabIndex = 110
            Me.lblRFResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlFuncParts
            '
            Me.pnlFuncParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlFuncParts.AutoScroll = True
            Me.pnlFuncParts.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlFuncParts.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlFuncParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFuncParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlFuncParts.Location = New System.Drawing.Point(8, 24)
            Me.pnlFuncParts.Name = "pnlFuncParts"
            Me.pnlFuncParts.Size = New System.Drawing.Size(968, 417)
            Me.pnlFuncParts.TabIndex = 109
            '
            'tbReflow
            '
            Me.tbReflow.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblReflowRepDesc, Me.lblReflowFailDesc, Me.chklstReflowBillcodes})
            Me.tbReflow.Location = New System.Drawing.Point(4, 22)
            Me.tbReflow.Name = "tbReflow"
            Me.tbReflow.Size = New System.Drawing.Size(984, 455)
            Me.tbReflow.TabIndex = 3
            Me.tbReflow.Text = "REFLOW"
            '
            'lblReflowRepDesc
            '
            Me.lblReflowRepDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReflowRepDesc.ForeColor = System.Drawing.Color.Blue
            Me.lblReflowRepDesc.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.lblReflowRepDesc.Location = New System.Drawing.Point(352, 48)
            Me.lblReflowRepDesc.Name = "lblReflowRepDesc"
            Me.lblReflowRepDesc.Size = New System.Drawing.Size(408, 16)
            Me.lblReflowRepDesc.TabIndex = 112
            Me.lblReflowRepDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblReflowFailDesc
            '
            Me.lblReflowFailDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReflowFailDesc.ForeColor = System.Drawing.Color.Blue
            Me.lblReflowFailDesc.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.lblReflowFailDesc.Location = New System.Drawing.Point(352, 24)
            Me.lblReflowFailDesc.Name = "lblReflowFailDesc"
            Me.lblReflowFailDesc.Size = New System.Drawing.Size(408, 16)
            Me.lblReflowFailDesc.TabIndex = 111
            Me.lblReflowFailDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'chklstReflowBillcodes
            '
            Me.chklstReflowBillcodes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.chklstReflowBillcodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chklstReflowBillcodes.Location = New System.Drawing.Point(8, 16)
            Me.chklstReflowBillcodes.Name = "chklstReflowBillcodes"
            Me.chklstReflowBillcodes.Size = New System.Drawing.Size(328, 382)
            Me.chklstReflowBillcodes.TabIndex = 0
            Me.chklstReflowBillcodes.Visible = False
            '
            'tbTestResults
            '
            Me.tbTestResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbTechFailureCodes, Me.Label1, Me.lblTechNotesUpdDate, Me.btnSaveTechNotes, Me.txtTechNotes, Me.pnlTestResults})
            Me.tbTestResults.Location = New System.Drawing.Point(4, 22)
            Me.tbTestResults.Name = "tbTestResults"
            Me.tbTestResults.Size = New System.Drawing.Size(984, 455)
            Me.tbTestResults.TabIndex = 8
            Me.tbTestResults.Text = "TEST RESULTS"
            '
            'gbTechFailureCodes
            '
            Me.gbTechFailureCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRemoveCode, Me.lstFailCodes, Me.cboCodes})
            Me.gbTechFailureCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbTechFailureCodes.Location = New System.Drawing.Point(120, 312)
            Me.gbTechFailureCodes.Name = "gbTechFailureCodes"
            Me.gbTechFailureCodes.Size = New System.Drawing.Size(816, 112)
            Me.gbTechFailureCodes.TabIndex = 2
            Me.gbTechFailureCodes.TabStop = False
            Me.gbTechFailureCodes.Text = "Tech Fail Code"
            '
            'btnRemoveCode
            '
            Me.btnRemoveCode.BackColor = System.Drawing.Color.Red
            Me.btnRemoveCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveCode.ForeColor = System.Drawing.Color.White
            Me.btnRemoveCode.Location = New System.Drawing.Point(728, 24)
            Me.btnRemoveCode.Name = "btnRemoveCode"
            Me.btnRemoveCode.Size = New System.Drawing.Size(80, 64)
            Me.btnRemoveCode.TabIndex = 4
            Me.btnRemoveCode.Text = "Remove Fail Code  (F12)"
            '
            'lstFailCodes
            '
            Me.lstFailCodes.ItemHeight = 16
            Me.lstFailCodes.Location = New System.Drawing.Point(368, 16)
            Me.lstFailCodes.Name = "lstFailCodes"
            Me.lstFailCodes.Size = New System.Drawing.Size(352, 84)
            Me.lstFailCodes.TabIndex = 2
            '
            'cboCodes
            '
            Me.cboCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCodes.AutoCompletion = True
            Me.cboCodes.AutoDropDown = True
            Me.cboCodes.AutoSelect = True
            Me.cboCodes.Caption = ""
            Me.cboCodes.CaptionHeight = 17
            Me.cboCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCodes.ColumnCaptionHeight = 17
            Me.cboCodes.ColumnFooterHeight = 17
            Me.cboCodes.ColumnHeaders = False
            Me.cboCodes.ContentHeight = 15
            Me.cboCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCodes.EditorHeight = 15
            Me.cboCodes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCodes.ItemHeight = 15
            Me.cboCodes.Location = New System.Drawing.Point(0, 24)
            Me.cboCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboCodes.MaxDropDownItems = CType(10, Short)
            Me.cboCodes.MaxLength = 32767
            Me.cboCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCodes.Name = "cboCodes"
            Me.cboCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCodes.Size = New System.Drawing.Size(352, 21)
            Me.cboCodes.TabIndex = 1
            Me.cboCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(16, 248)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 23)
            Me.Label1.TabIndex = 16
            Me.Label1.Text = "Tech Notes:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTechNotesUpdDate
            '
            Me.lblTechNotesUpdDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTechNotesUpdDate.ForeColor = System.Drawing.Color.Blue
            Me.lblTechNotesUpdDate.Location = New System.Drawing.Point(120, 232)
            Me.lblTechNotesUpdDate.Name = "lblTechNotesUpdDate"
            Me.lblTechNotesUpdDate.Size = New System.Drawing.Size(720, 16)
            Me.lblTechNotesUpdDate.TabIndex = 10
            Me.lblTechNotesUpdDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'btnSaveTechNotes
            '
            Me.btnSaveTechNotes.BackColor = System.Drawing.Color.SteelBlue
            Me.btnSaveTechNotes.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveTechNotes.ForeColor = System.Drawing.Color.White
            Me.btnSaveTechNotes.Location = New System.Drawing.Point(24, 280)
            Me.btnSaveTechNotes.Name = "btnSaveTechNotes"
            Me.btnSaveTechNotes.Size = New System.Drawing.Size(88, 64)
            Me.btnSaveTechNotes.TabIndex = 3
            Me.btnSaveTechNotes.Text = "Save Notes / Fail Codes"
            '
            'txtTechNotes
            '
            Me.txtTechNotes.Location = New System.Drawing.Point(120, 248)
            Me.txtTechNotes.Multiline = True
            Me.txtTechNotes.Name = "txtTechNotes"
            Me.txtTechNotes.Size = New System.Drawing.Size(720, 56)
            Me.txtTechNotes.TabIndex = 1
            Me.txtTechNotes.Text = ""
            '
            'pnlTestResults
            '
            Me.pnlTestResults.Controls.AddRange(New System.Windows.Forms.Control() {Me._LabelTestResult_QC, Me.lblTestResult_QC, Me._LabelTestResult_RF2, Me.lblTestResult_RF2, Me._LabelTestResult_RF1, Me.lblTestResult_RF1, Me._LabelTestResult_Triage, Me.lblTestResult_Triage})
            Me.pnlTestResults.Location = New System.Drawing.Point(8, 8)
            Me.pnlTestResults.Name = "pnlTestResults"
            Me.pnlTestResults.Size = New System.Drawing.Size(832, 216)
            Me.pnlTestResults.TabIndex = 0
            '
            '_LabelTestResult_QC
            '
            Me._LabelTestResult_QC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_QC.Location = New System.Drawing.Point(48, 160)
            Me._LabelTestResult_QC.Name = "_LabelTestResult_QC"
            Me._LabelTestResult_QC.Size = New System.Drawing.Size(64, 23)
            Me._LabelTestResult_QC.TabIndex = 15
            Me._LabelTestResult_QC.Text = "QC:"
            Me._LabelTestResult_QC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTestResult_QC
            '
            Me.lblTestResult_QC.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblTestResult_QC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestResult_QC.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
            Me.lblTestResult_QC.Location = New System.Drawing.Point(120, 152)
            Me.lblTestResult_QC.Name = "lblTestResult_QC"
            Me.lblTestResult_QC.Size = New System.Drawing.Size(696, 40)
            Me.lblTestResult_QC.TabIndex = 14
            '
            '_LabelTestResult_RF2
            '
            Me._LabelTestResult_RF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_RF2.Location = New System.Drawing.Point(40, 112)
            Me._LabelTestResult_RF2.Name = "_LabelTestResult_RF2"
            Me._LabelTestResult_RF2.Size = New System.Drawing.Size(72, 23)
            Me._LabelTestResult_RF2.TabIndex = 13
            Me._LabelTestResult_RF2.Text = "RF2:"
            Me._LabelTestResult_RF2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTestResult_RF2
            '
            Me.lblTestResult_RF2.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblTestResult_RF2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestResult_RF2.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
            Me.lblTestResult_RF2.Location = New System.Drawing.Point(120, 104)
            Me.lblTestResult_RF2.Name = "lblTestResult_RF2"
            Me.lblTestResult_RF2.Size = New System.Drawing.Size(696, 40)
            Me.lblTestResult_RF2.TabIndex = 12
            '
            '_LabelTestResult_RF1
            '
            Me._LabelTestResult_RF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_RF1.Location = New System.Drawing.Point(40, 64)
            Me._LabelTestResult_RF1.Name = "_LabelTestResult_RF1"
            Me._LabelTestResult_RF1.Size = New System.Drawing.Size(72, 23)
            Me._LabelTestResult_RF1.TabIndex = 11
            Me._LabelTestResult_RF1.Text = "RF1:"
            Me._LabelTestResult_RF1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTestResult_RF1
            '
            Me.lblTestResult_RF1.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblTestResult_RF1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestResult_RF1.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
            Me.lblTestResult_RF1.Location = New System.Drawing.Point(120, 56)
            Me.lblTestResult_RF1.Name = "lblTestResult_RF1"
            Me.lblTestResult_RF1.Size = New System.Drawing.Size(696, 40)
            Me.lblTestResult_RF1.TabIndex = 10
            '
            '_LabelTestResult_Triage
            '
            Me._LabelTestResult_Triage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_Triage.Location = New System.Drawing.Point(40, 24)
            Me._LabelTestResult_Triage.Name = "_LabelTestResult_Triage"
            Me._LabelTestResult_Triage.Size = New System.Drawing.Size(72, 23)
            Me._LabelTestResult_Triage.TabIndex = 9
            Me._LabelTestResult_Triage.Text = "TRIAGE:"
            Me._LabelTestResult_Triage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTestResult_Triage
            '
            Me.lblTestResult_Triage.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblTestResult_Triage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestResult_Triage.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(64, Byte), CType(0, Byte))
            Me.lblTestResult_Triage.Location = New System.Drawing.Point(120, 8)
            Me.lblTestResult_Triage.Name = "lblTestResult_Triage"
            Me.lblTestResult_Triage.Size = New System.Drawing.Size(696, 40)
            Me.lblTestResult_Triage.TabIndex = 8
            '
            'tpAccessories
            '
            Me.tpAccessories.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlAccessories})
            Me.tpAccessories.Location = New System.Drawing.Point(4, 22)
            Me.tpAccessories.Name = "tpAccessories"
            Me.tpAccessories.Size = New System.Drawing.Size(984, 455)
            Me.tpAccessories.TabIndex = 9
            Me.tpAccessories.Text = "ACCESSORIES"
            '
            'pnlAccessories
            '
            Me.pnlAccessories.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlAccessories.AutoScroll = True
            Me.pnlAccessories.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlAccessories.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlAccessories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlAccessories.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlAccessories.Location = New System.Drawing.Point(8, 11)
            Me.pnlAccessories.Name = "pnlAccessories"
            Me.pnlAccessories.Size = New System.Drawing.Size(968, 433)
            Me.pnlAccessories.TabIndex = 109
            '
            'tbScrap
            '
            Me.tbScrap.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlScrap})
            Me.tbScrap.Location = New System.Drawing.Point(4, 22)
            Me.tbScrap.Name = "tbScrap"
            Me.tbScrap.Size = New System.Drawing.Size(984, 455)
            Me.tbScrap.TabIndex = 2
            Me.tbScrap.Text = "SCRAP"
            '
            'pnlScrap
            '
            Me.pnlScrap.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlScrap.AutoScroll = True
            Me.pnlScrap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlScrap.Location = New System.Drawing.Point(8, 8)
            Me.pnlScrap.Name = "pnlScrap"
            Me.pnlScrap.Size = New System.Drawing.Size(968, 433)
            Me.pnlScrap.TabIndex = 0
            '
            'tbNeedPart
            '
            Me.tbNeedPart.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlNeededParts})
            Me.tbNeedPart.Location = New System.Drawing.Point(4, 22)
            Me.tbNeedPart.Name = "tbNeedPart"
            Me.tbNeedPart.Size = New System.Drawing.Size(984, 455)
            Me.tbNeedPart.TabIndex = 10
            Me.tbNeedPart.Text = "Need Part(s)"
            '
            'pnlNeededParts
            '
            Me.pnlNeededParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlNeededParts.AutoScroll = True
            Me.pnlNeededParts.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlNeededParts.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlNeededParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlNeededParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlNeededParts.Location = New System.Drawing.Point(8, 11)
            Me.pnlNeededParts.Name = "pnlNeededParts"
            Me.pnlNeededParts.Size = New System.Drawing.Size(968, 433)
            Me.pnlNeededParts.TabIndex = 109
            '
            'tbNeedAccessories
            '
            Me.tbNeedAccessories.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlNeededAccessories})
            Me.tbNeedAccessories.Location = New System.Drawing.Point(4, 22)
            Me.tbNeedAccessories.Name = "tbNeedAccessories"
            Me.tbNeedAccessories.Size = New System.Drawing.Size(984, 455)
            Me.tbNeedAccessories.TabIndex = 11
            Me.tbNeedAccessories.Text = "Need Accessories"
            '
            'pnlNeededAccessories
            '
            Me.pnlNeededAccessories.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlNeededAccessories.AutoScroll = True
            Me.pnlNeededAccessories.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlNeededAccessories.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlNeededAccessories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlNeededAccessories.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlNeededAccessories.Location = New System.Drawing.Point(8, 11)
            Me.pnlNeededAccessories.Name = "pnlNeededAccessories"
            Me.pnlNeededAccessories.Size = New System.Drawing.Size(968, 433)
            Me.pnlNeededAccessories.TabIndex = 110
            '
            'btnExpand
            '
            Me.btnExpand.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnExpand.Location = New System.Drawing.Point(1008, 120)
            Me.btnExpand.Name = "btnExpand"
            Me.btnExpand.Size = New System.Drawing.Size(16, 23)
            Me.btnExpand.TabIndex = 109
            Me.btnExpand.Text = "Expand"
            Me.btnExpand.Visible = False
            '
            'btnResize
            '
            Me.btnResize.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnResize.Location = New System.Drawing.Point(1008, 88)
            Me.btnResize.Name = "btnResize"
            Me.btnResize.Size = New System.Drawing.Size(16, 23)
            Me.btnResize.TabIndex = 110
            Me.btnResize.Text = "Resize"
            Me.btnResize.Visible = False
            '
            'gridBilling
            '
            Me.gridBilling.AlternatingRows = True
            Me.gridBilling.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gridBilling.BackColor = System.Drawing.SystemColors.Control
            Me.gridBilling.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
            Me.gridBilling.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridBilling.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.gridBilling.Location = New System.Drawing.Point(8, 104)
            Me.gridBilling.Name = "gridBilling"
            Me.gridBilling.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gridBilling.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gridBilling.PreviewInfo.ZoomFactor = 75
            Me.gridBilling.Size = New System.Drawing.Size(992, 441)
            Me.gridBilling.TabIndex = 118
            Me.gridBilling.TabStop = False
            Me.gridBilling.Text = "C1TrueDBGrid1"
            Me.gridBilling.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Caption=""Bill Code"" DataField=" & _
            """""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""Description""" & _
            " DataField=""""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""R" & _
            "ef Des"" DataField=""""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Cap" & _
            "tion=""Number"" DataField=""""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColu" & _
            "mn Caption=""Failure"" DataField=""""><ValueItems /><GroupInfo /></C1DataColumn><C1D" & _
            "ataColumn Caption=""Transaction"" DataField=""""><ValueItems /><GroupInfo /></C1Data" & _
            "Column></DataCols><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrapper""><Data" & _
            ">Style12{}Style50{}Style51{}Caption{AlignHorz:Center;}Normal{}Style25{}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{AlignHorz:Near;}Sty" & _
            "le19{AlignHorz:Near;}Style14{AlignHorz:Near;}Style15{AlignHorz:Near;}Style16{}St" & _
            "yle17{}Style10{AlignHorz:Near;}Style11{}OddRow{}Style13{}Style45{}Style44{}Style" & _
            "38{}Style39{}Style34{AlignHorz:Near;}Style35{AlignHorz:Near;}Style2{}Style29{}St" & _
            "yle28{}Style27{AlignHorz:Near;}Style26{AlignHorz:Near;}RecordSelector{AlignImage" & _
            ":Center;}Footer{}Style23{AlignHorz:Near;}Style22{AlignHorz:Near;}Style21{}Style2" & _
            "0{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Inactiv" & _
            "e{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:Aqu" & _
            "a;}Heading{Wrap:True;BackColor:Control;Border:Flat,ControlDark,0, 1, 0, 1;ForeCo" & _
            "lor:ControlText;AlignVert:Center;}Style49{}Style48{}Style24{}Style6{}Style1{}Sty" & _
            "le3{}Style41{}Style40{}Style43{}FilterBar{}Style42{}Style5{}Style47{}Style9{}Sty" & _
            "le8{}Style46{}Style36{}Style37{}Style4{}Style7{}Style32{}Style33{}Style30{AlignH" & _
            "orz:Near;}Style31{AlignHorz:Near;}HighlightRow{ForeColor:HighlightText;BackColor" & _
            ":Highlight;}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alter" & _
            "natingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHe" & _
            "ight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>437</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><internalCols><C1DisplayColumn><HeadingSt" & _
            "yle parent=""Style2"" me=""Style34"" /><Style parent=""Style1"" me=""Style35"" /><Footer" & _
            "Style parent=""Style3"" me=""Style36"" /><EditorStyle parent=""Style5"" me=""Style37"" /" & _
            "><GroupHeaderStyle parent=""Style1"" me=""Style41"" /><GroupFooterStyle parent=""Styl" & _
            "e1"" me=""Style40"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single</Column" & _
            "Divider><Height>15</Height><DCIdx>0</DCIdx></C1DisplayColumn><C1DisplayColumn><H" & _
            "eadingStyle parent=""Style2"" me=""Style14"" /><Style parent=""Style1"" me=""Style15"" /" & _
            "><FooterStyle parent=""Style3"" me=""Style16"" /><EditorStyle parent=""Style5"" me=""St" & _
            "yle17"" /><GroupHeaderStyle parent=""Style1"" me=""Style43"" /><GroupFooterStyle pare" & _
            "nt=""Style1"" me=""Style42"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single" & _
            "</ColumnDivider><Height>15</Height><DCIdx>2</DCIdx></C1DisplayColumn><C1DisplayC" & _
            "olumn><HeadingStyle parent=""Style2"" me=""Style18"" /><Style parent=""Style1"" me=""St" & _
            "yle19"" /><FooterStyle parent=""Style3"" me=""Style20"" /><EditorStyle parent=""Style5" & _
            """ me=""Style21"" /><GroupHeaderStyle parent=""Style1"" me=""Style45"" /><GroupFooterSt" & _
            "yle parent=""Style1"" me=""Style44"" /><Visible>True</Visible><ColumnDivider>DarkGra" & _
            "y,Single</ColumnDivider><Height>15</Height><DCIdx>3</DCIdx></C1DisplayColumn><C1" & _
            "DisplayColumn><HeadingStyle parent=""Style2"" me=""Style26"" /><Style parent=""Style1" & _
            """ me=""Style27"" /><FooterStyle parent=""Style3"" me=""Style28"" /><EditorStyle parent" & _
            "=""Style5"" me=""Style29"" /><GroupHeaderStyle parent=""Style1"" me=""Style47"" /><Group" & _
            "FooterStyle parent=""Style1"" me=""Style46"" /><Visible>True</Visible><ColumnDivider" & _
            ">DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>4</DCIdx></C1DisplayCo" & _
            "lumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style22"" /><Style parent" & _
            "=""Style1"" me=""Style23"" /><FooterStyle parent=""Style3"" me=""Style24"" /><EditorStyl" & _
            "e parent=""Style5"" me=""Style25"" /><GroupHeaderStyle parent=""Style1"" me=""Style49"" " & _
            "/><GroupFooterStyle parent=""Style1"" me=""Style48"" /><Visible>True</Visible><Colum" & _
            "nDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>1</DCIdx></C1D" & _
            "isplayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style30"" /><Styl" & _
            "e parent=""Style1"" me=""Style31"" /><FooterStyle parent=""Style3"" me=""Style32"" /><Ed" & _
            "itorStyle parent=""Style5"" me=""Style33"" /><GroupHeaderStyle parent=""Style1"" me=""S" & _
            "tyle51"" /><GroupFooterStyle parent=""Style1"" me=""Style50"" /><Visible>True</Visibl" & _
            "e><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>5</DCI" & _
            "dx></C1DisplayColumn></internalCols><ClientRect>0, 0, 988, 437</ClientRect><Bord" & _
            "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
            "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
            """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
            "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
            """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
            "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
            "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
            """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
            "vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidt" & _
            "h>17</DefaultRecSelWidth><ClientArea>0, 0, 988, 437</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style38"" /><PrintPageFooterStyle parent="""" me=""Style39"" /></" & _
            "Blob>"
            '
            'lblSelected
            '
            Me.lblSelected.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelected.ForeColor = System.Drawing.Color.Blue
            Me.lblSelected.Location = New System.Drawing.Point(576, 5)
            Me.lblSelected.Name = "lblSelected"
            Me.lblSelected.Size = New System.Drawing.Size(128, 16)
            Me.lblSelected.TabIndex = 119
            Me.lblSelected.Text = "SHOW SELECTED"
            Me.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClear.Location = New System.Drawing.Point(952, 1)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 22)
            Me.btnClear.TabIndex = 120
            Me.btnClear.Text = "&Clear"
            '
            'btnComplete
            '
            Me.btnComplete.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnComplete.Location = New System.Drawing.Point(824, 1)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(124, 22)
            Me.btnComplete.TabIndex = 123
            Me.btnComplete.Text = "Complete This Device"
            '
            'lblLotNum
            '
            Me.lblLotNum.Location = New System.Drawing.Point(312, 48)
            Me.lblLotNum.Name = "lblLotNum"
            Me.lblLotNum.Size = New System.Drawing.Size(72, 16)
            Me.lblLotNum.TabIndex = 124
            Me.lblLotNum.Text = "Lot Number:"
            Me.lblLotNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblLotNum.Visible = False
            '
            'txtLotNum
            '
            Me.txtLotNum.BackColor = System.Drawing.SystemColors.Control
            Me.txtLotNum.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtLotNum.Location = New System.Drawing.Point(392, 48)
            Me.txtLotNum.Name = "txtLotNum"
            Me.txtLotNum.Size = New System.Drawing.Size(40, 13)
            Me.txtLotNum.TabIndex = 125
            Me.txtLotNum.Text = ""
            Me.txtLotNum.Visible = False
            '
            'lblATT
            '
            Me.lblATT.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblATT.Font = New System.Drawing.Font("Verdana", 9.75!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblATT.ForeColor = System.Drawing.Color.Red
            Me.lblATT.Location = New System.Drawing.Point(416, 8)
            Me.lblATT.Name = "lblATT"
            Me.lblATT.Size = New System.Drawing.Size(144, 16)
            Me.lblATT.TabIndex = 129
            Me.lblATT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRejectReason
            '
            Me.lblRejectReason.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblRejectReason.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRejectReason.ForeColor = System.Drawing.Color.Blue
            Me.lblRejectReason.Location = New System.Drawing.Point(560, 58)
            Me.lblRejectReason.Name = "lblRejectReason"
            Me.lblRejectReason.Size = New System.Drawing.Size(448, 12)
            Me.lblRejectReason.TabIndex = 131
            Me.lblRejectReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRejectReason.Visible = False
            '
            'lblAPCGoal
            '
            Me.lblAPCGoal.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblAPCGoal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblAPCGoal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAPCGoal.ForeColor = System.Drawing.Color.Green
            Me.lblAPCGoal.Location = New System.Drawing.Point(648, 26)
            Me.lblAPCGoal.Name = "lblAPCGoal"
            Me.lblAPCGoal.Size = New System.Drawing.Size(120, 26)
            Me.lblAPCGoal.TabIndex = 132
            Me.lblAPCGoal.Text = "Avg Parts Cost Goal $1.25"
            Me.lblAPCGoal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblAPCGoal.Visible = False
            '
            'lblUnitPartsCost
            '
            Me.lblUnitPartsCost.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblUnitPartsCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblUnitPartsCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUnitPartsCost.ForeColor = System.Drawing.Color.Green
            Me.lblUnitPartsCost.Location = New System.Drawing.Point(776, 26)
            Me.lblUnitPartsCost.Name = "lblUnitPartsCost"
            Me.lblUnitPartsCost.Size = New System.Drawing.Size(112, 26)
            Me.lblUnitPartsCost.TabIndex = 133
            Me.lblUnitPartsCost.Text = "Unit Parts Cost $1.25"
            Me.lblUnitPartsCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblUnitPartsCost.Visible = False
            '
            'lblDailyAPC
            '
            Me.lblDailyAPC.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblDailyAPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDailyAPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDailyAPC.ForeColor = System.Drawing.Color.Green
            Me.lblDailyAPC.Location = New System.Drawing.Point(896, 26)
            Me.lblDailyAPC.Name = "lblDailyAPC"
            Me.lblDailyAPC.Size = New System.Drawing.Size(120, 26)
            Me.lblDailyAPC.TabIndex = 134
            Me.lblDailyAPC.Text = "Daily Avg Parts Cost $1.25"
            Me.lblDailyAPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblDailyAPC.Visible = False
            '
            'lblCustName
            '
            Me.lblCustName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustName.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblCustName.Location = New System.Drawing.Point(8, 8)
            Me.lblCustName.Name = "lblCustName"
            Me.lblCustName.Size = New System.Drawing.Size(184, 16)
            Me.lblCustName.TabIndex = 135
            Me.lblCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCompleteRepair
            '
            Me.btnCompleteRepair.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCompleteRepair.Location = New System.Drawing.Point(712, 1)
            Me.btnCompleteRepair.Name = "btnCompleteRepair"
            Me.btnCompleteRepair.Size = New System.Drawing.Size(104, 22)
            Me.btnCompleteRepair.TabIndex = 136
            Me.btnCompleteRepair.Text = "Complete Repair"
            Me.btnCompleteRepair.Visible = False
            '
            'lblWarrantyStatus
            '
            Me.lblWarrantyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWarrantyStatus.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWarrantyStatus.ForeColor = System.Drawing.Color.Red
            Me.lblWarrantyStatus.Location = New System.Drawing.Point(456, 32)
            Me.lblWarrantyStatus.Name = "lblWarrantyStatus"
            Me.lblWarrantyStatus.Size = New System.Drawing.Size(48, 26)
            Me.lblWarrantyStatus.TabIndex = 137
            Me.lblWarrantyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblScreenName
            '
            Me.lblScreenName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblScreenName.Location = New System.Drawing.Point(216, 8)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(136, 16)
            Me.lblScreenName.TabIndex = 138
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblDeviceSN.Location = New System.Drawing.Point(0, 40)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(80, 16)
            Me.lblDeviceSN.TabIndex = 142
            Me.lblDeviceSN.Text = "Serial Number:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerial.Location = New System.Drawing.Point(80, 40)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(136, 20)
            Me.txtSerial.TabIndex = 143
            Me.txtSerial.Text = ""
            '
            'txtTray
            '
            Me.txtTray.BackColor = System.Drawing.SystemColors.Control
            Me.txtTray.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtTray.Location = New System.Drawing.Point(256, 48)
            Me.txtTray.Name = "txtTray"
            Me.txtTray.Size = New System.Drawing.Size(56, 13)
            Me.txtTray.TabIndex = 144
            Me.txtTray.Text = ""
            Me.txtTray.Visible = False
            '
            'tbSW
            '
            Me.tbSW.Location = New System.Drawing.Point(4, 22)
            Me.tbSW.Name = "tbSW"
            Me.tbSW.Size = New System.Drawing.Size(984, 455)
            Me.tbSW.TabIndex = 12
            Me.tbSW.Text = "SOFTWARE"
            '
            'frmNewTech
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1024, 558)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTray, Me.txtSerial, Me.lblDeviceSN, Me.lblScreenName, Me.lblWarrantyStatus, Me.btnCompleteRepair, Me.lblCustName, Me.lblDailyAPC, Me.lblUnitPartsCost, Me.lblAPCGoal, Me.lblRejectReason, Me.lblATT, Me.txtLotNum, Me.lblLotNum, Me.btnComplete, Me.btnClear, Me.lblSelected, Me.btnResize, Me.btnExpand, Me.tabMain, Me.lblTray, Me.gridBilling})
            Me.Name = "frmNewTech"
            Me.Text = "frmNewTech"
            Me.tabMain.ResumeLayout(False)
            Me.tbParts.ResumeLayout(False)
            Me.tbServices.ResumeLayout(False)
            Me.tbRVParts.ResumeLayout(False)
            Me.tbRVFParts.ResumeLayout(False)
            Me.tpFParts.ResumeLayout(False)
            Me.tbReflow.ResumeLayout(False)
            Me.tbTestResults.ResumeLayout(False)
            Me.gbTechFailureCodes.ResumeLayout(False)
            CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlTestResults.ResumeLayout(False)
            Me.tpAccessories.ResumeLayout(False)
            Me.tbScrap.ResumeLayout(False)
            Me.tbNeedPart.ResumeLayout(False)
            Me.tbNeedAccessories.ResumeLayout(False)
            CType(Me.gridBilling, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Generate Dynamic Buttons"

        '*****************************************************************
        Private Sub createScrapButtons(ByVal dt As DataTable)
            Dim btnWidthScrap As Integer = 225
            Dim btnHeightScrap As Integer = 30
            Dim NSCbtnWidthScrap As Integer = 220
            Dim NSCbtnHeightScrap As Integer = 5

            Dim r As DataRow
            'Dim dtScrap As DataTable
            Dim cBill() As Button
            Dim heightPanelSCRAP As Integer
            Dim widthPanelSCRAP As Integer
            Dim colLengthScrap As Integer = 16
            Dim x As Integer = 0
            Dim iCount As Integer = 0
            Dim objScrap As PSS.Data.Buisness.ScrapParts

            Try
                'dtScrap = Me._objNewTech.GetScrapParts(Me.tmpDeviceID)
                objScrap = New PSS.Data.Buisness.ScrapParts()

                colCount = 0
                pnlScrap.BackColor = Color.LightYellow
                pnlLeft = pnlScrap.Left
                pnlWidth = tabMain.Width - 48
                'gridLeft = gridBilling.Left
                'gridWidth = gridBilling.Width

                ReDim cBill(dt.Rows.Count)

                heightPanelSCRAP = pnlScrap.Height - 20
                widthPanelSCRAP = pnlScrap.Width

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    cBill(x) = New System.Windows.Forms.Button()

                    With cBill(x)
                        iCount = 0
                        '********************************************
                        If Not IsDBNull(r("BillCode_ID")) Then
                            iCount = objScrap.GetScrapCount(tmpDeviceID, tmpModelID, r("BillCode_ID"))
                        End If

                        If iCount > 0 Then
                            .BackColor = Color.LightGreen
                            .ForeColor = Color.Black
                        Else
                            .BackColor = Color.LightCoral
                            .ForeColor = Color.Black
                        End If
                        '********************************************

                        .Text = r("BillCode_DESC") & " " & Trim("(" & Trim(iCount) & ")")
                        .Size = New Size(btnWidthScrap, btnHeightScrap)
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True
                        colCount += 1
                        '.BackColor = Color.LightCoral
                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.ScrapClick
                    End With

                    colLengthScrap = 16

                    If colCount > colLengthScrap Then
                        If tmpCustID = 1403 Then
                            btnLeft = btnLeft + NSCbtnWidthScrap
                        Else
                            btnLeft = btnLeft + btnWidthScrap + 5
                        End If
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        If tmpCustID = 1403 Then
                            btnTop = btnTop + NSCbtnHeightScrap
                        Else
                            btnTop = btnTop + btnHeightScrap + 2
                        End If
                    End If
                Next
                Me.pnlScrap.Controls.AddRange(cBill)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateScrapButtons", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                r = Nothing
                cBill = Nothing
                'PSS.Data.Buisness.Generic.DisposeDT(dtScrap)
            End Try
        End Sub

        '*****************************************************************
        Private Sub createBillingButtons(ByVal dt As DataTable)
            Dim r As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0

            Try
                colCount = 0
                pnlLeft = pnlBill.Left
                pnlWidth = tabMain.Width - 48
                'gridLeft = gridBilling.Left
                'gridWidth = gridBilling.Width

                gridBilling.Visible = False
                btnExpand.Text = "Show"

                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    cBill(x) = New System.Windows.Forms.Button()
                    With cBill(x)
                        .Text = r("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True

                        .BackColor = Color.LightGray
                        '*********************************************
                        'High light Consigned parts
                        '*********************************************
                        If r("PSPrice_ConsignedPart").ToString() = "1" Then
                            .BackColor = Color.Orange
                        Else
                            .BackColor = Color.LightGray
                        End If
                        '*********************************************

                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.billingClick
                    End With

                    If tmpCustID = 1403 Then colLength = 12

                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next

                Me.pnlBill.Controls.AddRange(cBill)

                '*************************************
                'Create need parts buttons
                '*************************************
                If Me._device.PredeterminePartNeed = True Then
                    colCount = 0
                    pnlLeft = Me.pnlNeededParts.Left
                    pnlWidth = tabMain.Width - 48

                    ReDim cBill(dt.Rows.Count)

                    btnLeft = hBuffer
                    btnTop = vBuffer

                    For x = 0 To dt.Rows.Count - 1
                        r = dt.Rows(x)
                        cBill(x) = New System.Windows.Forms.Button()
                        With cBill(x)
                            .Text = r("BillCode_DESC")
                            .Size = New Size(btnWidth, btnHeight)
                            colCount += 1
                            .Location = New Point(btnLeft, btnTop)
                            .Visible = True

                            '*********************************************
                            'High light Consigned parts
                            '*********************************************
                            If r("PSPrice_ConsignedPart").ToString() = "1" Then
                                .BackColor = Color.Orange
                            Else
                                .BackColor = Color.LightSteelBlue
                            End If
                            '*********************************************

                            .Tag = r("BillCode_ID")
                            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            AddHandler .Click, AddressOf Me.billingClick_AWAP
                        End With

                        If colCount > colLength Then
                            btnLeft = btnLeft + btnWidth + 5
                            btnTop = vBuffer
                            colCount = 0
                        Else
                            btnTop = btnTop + btnHeight + 5
                        End If
                    Next

                    Me.pnlNeededParts.Controls.AddRange(cBill)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                r = Nothing
                cBill = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Sub createServiceButtons(ByVal dt As DataTable)
            Dim cService() As Button
            Dim heightPanelSERVICE As Integer
            Dim widthPanelSERVICE As Integer
            Dim x As Integer = 0
            Dim r As DataRow

            Try
                colCount = 0
                pnlLeft = pnlService.Left
                pnlWidth = tabMain.Width - 48
                'gridLeft = grid.Left
                'gridWidth = gridBilling.Width

                'gridBilling.Visible = False
                pnlService.Width = pnlService.Width
                btnExpand.Text = "Show"

                ReDim cService(dt.Rows.Count)

                heightPanelSERVICE = pnlService.Height
                widthPanelSERVICE = pnlService.Width

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)

                    '//This is new May 16, 2005
                    If r("billcode_id") = 442 Or r("billcode_id") = 446 Or r("billcode_id") = 447 Or r("billcode_id") = 448 Then
                        If tmpCustID <> 2019 And tmpCustID <> 2058 And tmpCustID <> 2069 Then
                            GoTo procNextVal
                        End If
                    End If
                    '//This is new May 16, 2005

                    '//This is new May 19, 2006
                    If r("billcode_id") = 446 Then
                        If tmpCustID = 2019 Then
                            GoTo procNextVal
                        End If
                    End If
                    '//This is new May 19, 2006

                    cService(x) = New System.Windows.Forms.Button()
                    With cService(x)
                        .Text = r("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        .Location = New Point(btnLeft, btnTop)
                        .BackColor = Color.LightGray
                        'If tmpCustID = 2113 And (r("BillCode_ID") = 255 Or r("BillCode_ID") = 466) Then Modified July 25, 2007
                        If tmpCustID = 2113 And r("BillCode_ID") = 466 Then
                            .Visible = False
                        Else
                            .Visible = True
                            colCount += 1
                        End If

                        '.Visible = True
                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.billingClick
                    End With


                    'colCount += 1
                    If colCount > 6 Then
                        'If btnTop + btnHeight + 150 > pnlService.Height Then
                        'If tmpCustID = 2113 And (r("BillCode_ID") = 255 Or r("BillCode_ID") = 466) Then Modified July 25, 2007
                        If tmpCustID = 2113 And r("BillCode_ID") = 466 Then
                        Else
                            btnLeft = btnLeft + btnWidth + 5
                            btnTop = vBuffer
                            colCount = 0

                        End If
                    Else

                        'If tmpCustID = 2113 And (r("BillCode_ID") = 255 Or r("BillCode_ID") = 466) Then Modified July 25, 2007
                        If tmpCustID = 2113 And r("BillCode_ID") = 466 Then
                        Else
                            btnTop = btnTop + btnHeight + 5
                        End If
                    End If
procnextval:
                Next
                Me.pnlService.Controls.AddRange(cService)

            Catch ex As Exception
                Throw ex
            Finally
                cService = Nothing
                r = Nothing
            End Try
        End Sub

        'Private Sub createRepairActionButtons(ByVal dt As DataTable)

        'Dim cRepair() As Button

        'ReDim cRepair(dt.Rows.Count)

        'Dim heightPanelProblemFound As Integer = pnlProblemFound.Height
        'Dim widthPanelProblemFound As Integer = pnlProblemFound.Width

        'Dim btnLeft As Int32 = hBuffer
        'Dim btnTop As Int32 = vBuffer
        'Dim x As Integer = 0
        'Dim r As DataRow

        'For x = 0 To dt.Rows.Count - 1
        'r = dt.Rows(x)
        'cRepair(x) = New System.Windows.Forms.Button()
        'With cRepair(x)
        ''.Text = "button " & x
        '.Text = r("Dcode_LDesc")
        '.Size = New Size(btnWidth, btnHeight)
        '.Location = New Point(btnLeft, btnTop)
        '.Visible = True
        '.Tag = x
        'AddHandler .Click, AddressOf Me.repairactionclick
        'End With

        'If btnTop + btnHeight + 50 > pnlProblemFound.Height Then
        'btnLeft = btnLeft + btnWidth + 20
        'btnTop = vBuffer
        'Else
        '    btnTop = btnTop + btnHeight + 20
        'End If
        'Next
        'Me.pnlRepairAction.Controls.AddRange(cRepair)

        'End Sub

        '*****************************************************************
        Private Function CreateFuncBillingButtons() As Boolean
            Dim booResult As Boolean = True
            Dim r, drNewRow As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0
            Dim myBillColumn As DataColumn
            Dim dt, dtReflow As DataTable
            Dim objBD As New Buisness.DeviceBilling()

            Try
                dt = objBD.GetPartBillcodes(Me.tmpCustID, Me.tmpModelID, , 1, 0)

                colCount = 0
                pnlLeft = pnlFuncParts.Left
                pnlWidth = tabMain.Width - 48
                'gridLeft = gridBilling.Left
                'gridWidth = gridBilling.Width

                gridBilling.Visible = False
                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("ReflowTypeID") <> 4 Then
                        cBill(x) = New System.Windows.Forms.Button()
                        With cBill(x)
                            .Text = r("BillCode_DESC")
                            .Size = New Size(btnWidth, btnHeight)

                            colCount += 1
                            .Location = New Point(btnLeft, btnTop)
                            .Visible = True

                            .BackColor = Color.LightGray
                            '*********************************************
                            'High light Consigned parts
                            '*********************************************
                            If r("PSPrice_ConsignedPart").ToString() = "1" Then
                                .BackColor = Color.Orange
                            Else
                                .BackColor = Color.LightGray
                            End If
                            '*********************************************

                            .Tag = r("BillCode_ID")
                            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            AddHandler .Click, AddressOf Me.billingClick
                        End With

                        If colCount > colLength Then
                            btnLeft = btnLeft + btnWidth + 5
                            btnTop = vBuffer
                            colCount = 0
                        Else
                            btnTop = btnTop + btnHeight + 5
                        End If
                    End If
                Next x

                Me.pnlFuncParts.Controls.AddRange(cBill)

                '***************************************
                'Relow parts Only apply to Samsung NOW
                '***************************************
                If Me.tmpProdID = 2 AndAlso (Me.tmpManufID = 21 Or Me.tmpManufID = 16 Or Me.tmpManufID = 1 Or Me.tmpManufID = 24) Then
                    dtReflow = New DataTable()
                    dtReflow = dt.Clone

                    For Each r In dt.Rows
                        If CInt(r("ReflowTypeID")) <> 3 Then
                            drNewRow = Nothing : drNewRow = dtReflow.NewRow
                            For x = 0 To dt.Columns.Count - 1 : drNewRow(x) = r(x) : Next x
                            dtReflow.Rows.Add(drNewRow) : dtReflow.AcceptChanges()
                        End If
                    Next r

                    With Me.chklstReflowBillcodes
                        .DataSource = dtReflow.DefaultView
                        .DisplayMember = "BillCode_Desc"
                        .ValueMember = "BillCode_ID"
                        .Visible = True
                        Me.SetCheckedStateForReflowParts()
                    End With
                End If
                '***************************************

                Return booResult
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateFuncBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                r = Nothing : drNewRow = Nothing
                cBill = Nothing
                If Not IsNothing(myBillColumn) Then
                    myBillColumn.Dispose() : myBillColumn = Nothing
                End If
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dtReflow)
            End Try
        End Function

        '*****************************************************************
        Private Function CreateRVBillCodesButtons() As Boolean
            Dim booResult As Boolean = True
            Dim r, drNewRow As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0
            Dim myBillColumn As DataColumn
            Dim dt, dtReflow As DataTable
            Dim objBD As New Buisness.DeviceBilling()

            Try
                '***************************************
                'RV Parts
                '***************************************
                dt = objBD.GetPartBillcodes(Me.tmpCustID, Me.tmpModelID, 2, , 1)

                colCount = 0
                pnlLeft = Me.pnlRVParts.Left
                pnlWidth = tabMain.Width - 48

                gridBilling.Visible = False
                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("ReflowTypeID") <> 4 Then
                        cBill(x) = New System.Windows.Forms.Button()
                        With cBill(x)
                            .Text = r("BillCode_DESC")
                            .Size = New Size(btnWidth, btnHeight)

                            colCount += 1
                            .Location = New Point(btnLeft, btnTop)
                            .Visible = True

                            .Tag = r("BillCode_ID")
                            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            AddHandler .Click, AddressOf Me.billingClick
                        End With

                        If colCount > colLength Then
                            btnLeft = btnLeft + btnWidth + 5
                            btnTop = vBuffer
                            colCount = 0
                        Else
                            btnTop = btnTop + btnHeight + 5
                        End If
                    End If
                Next x

                Me.pnlRVParts.Controls.AddRange(cBill)

                '***************************************
                'RV Functional Parts
                '***************************************
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                dt = objBD.GetPartBillcodes(Me.tmpCustID, Me.tmpModelID, , 1, 1)

                colCount = 0
                pnlLeft = Me.pnlRVFParts.Left
                pnlWidth = tabMain.Width - 48

                gridBilling.Visible = False
                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("ReflowTypeID") <> 4 Then
                        cBill(x) = New System.Windows.Forms.Button()
                        With cBill(x)
                            .Text = r("BillCode_DESC")
                            .Size = New Size(btnWidth, btnHeight)

                            colCount += 1
                            .Location = New Point(btnLeft, btnTop)
                            .Visible = True

                            .Tag = r("BillCode_ID")
                            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            AddHandler .Click, AddressOf Me.billingClick
                        End With

                        If colCount > colLength Then
                            btnLeft = btnLeft + btnWidth + 5
                            btnTop = vBuffer
                            colCount = 0
                        Else
                            btnTop = btnTop + btnHeight + 5
                        End If
                    End If
                Next x

                Me.pnlRVFParts.Controls.AddRange(cBill)
                '***************************************

                Return booResult
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateRVBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                r = Nothing : drNewRow = Nothing
                cBill = Nothing
                If Not IsNothing(myBillColumn) Then
                    myBillColumn.Dispose() : myBillColumn = Nothing
                End If
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dtReflow)
            End Try
        End Function

        '*****************************************************************
        Private Function CreateAccessoryButtons() As Boolean
            Dim booResult As Boolean = True
            Dim R1, drAccessories() As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim i As Integer = 0

            Try
                drAccessories = Me._device.BillableBillcodes.Select("BillType_ID = 3")

                colCount = 0
                pnlLeft = Me.pnlAccessories.Left
                pnlWidth = tabMain.Width - 48

                ReDim cBill(drAccessories.Length)

                btnLeft = hBuffer
                btnTop = vBuffer

                For i = 0 To drAccessories.Length - 1
                    R1 = drAccessories(i)
                    cBill(i) = New System.Windows.Forms.Button()
                    With cBill(i)
                        .Text = R1("BillCode_Desc")
                        .Name = R1("PSPrice_Number")
                        .Size = New Size(btnWidth, btnHeight)

                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True

                        .Tag = R1("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        'AddHandler .Click, AddressOf Me.AccessoryClick
                        AddHandler .Click, AddressOf Me.billingClick
                    End With

                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next i

                Me.pnlAccessories.Controls.AddRange(cBill)

                '****************************************
                'Create AWAP button
                '****************************************
                If Me._device.PredeterminePartNeed = True Then
                    colCount = 0
                    pnlLeft = Me.pnlNeededAccessories.Left
                    pnlWidth = tabMain.Width - 48

                    ReDim cBill(drAccessories.Length)

                    btnLeft = hBuffer
                    btnTop = vBuffer

                    For i = 0 To drAccessories.Length - 1
                        R1 = drAccessories(i)
                        cBill(i) = New System.Windows.Forms.Button()
                        With cBill(i)
                            .Text = R1("BillCode_Desc")
                            .Name = R1("PSPrice_Number")
                            .Size = New Size(btnWidth, btnHeight)

                            colCount += 1
                            .Location = New Point(btnLeft, btnTop)
                            .Visible = True
                            .BackColor = Color.LightSteelBlue

                            .Tag = R1("BillCode_ID")
                            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            AddHandler .Click, AddressOf Me.billingClick_AWAP
                        End With

                        If colCount > colLength Then
                            btnLeft = btnLeft + btnWidth + 5
                            btnTop = vBuffer
                            colCount = 0
                        Else
                            btnTop = btnTop + btnHeight + 5
                        End If
                    Next i

                    Me.pnlNeededAccessories.Controls.AddRange(cBill)
                End If
                '****************************************

                ' Me.HighlightSelectedAccessories()
                Return booResult
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateAccessoryButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                cBill = Nothing
            End Try
        End Function

        ''******************************************************************
        'Private Sub HighlightSelectedAccessories()
        '    'Highlight Accessories button that are create in receiving screen

        '    Dim objPJoins As New PSS.Data.Production.Joins()
        '    Dim dtAsy As DataTable = objPJoins.GenericSelect("Select * From tDeviceAccessories WHERE Device_ID=" & Me.tmpDeviceID & " And Status_ID=3411 ORDER BY DA_ID")
        '    Dim iSavedCnt, iAllCnt As Integer
        '    Dim drAsy As DataRow
        '    Dim btnAsy As Button

        '    Try
        '        iSavedCnt = 0 : iAllCnt = 0

        '        'Reset Backcolor
        '        For iAllCnt = 0 To Me.pnlAccessories.Controls.Count - 1
        '            Me.pnlAccessories.Controls(iAllCnt).BackColor = Color.LightGray
        '        Next iAllCnt

        '        'Highlight the Accessoriess
        '        For iSavedCnt = 0 To dtAsy.Rows.Count - 1
        '            drAsy = dtAsy.Rows(iSavedCnt)

        '            'Accessories button panel
        '            For iAllCnt = 0 To pnlAccessories.Controls.Count - 1
        '                btnAsy = CType(pnlAccessories.Controls(iAllCnt), System.Windows.Forms.Button)
        '                With btnAsy
        '                    If drAsy("billcode_ID") = .Tag Then
        '                        btnAsy.BackColor = Color.Orange
        '                        Exit For
        '                    End If

        '                End With
        '            Next iAllCnt

        '        Next iSavedCnt


        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "HighlightSelectedAccessoriess", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Finally
        '        Buisness.Generic.DisposeDT(dtAsy)
        '        objPJoins = Nothing
        '        drAsy = Nothing

        '    End Try
        'End Sub

        '*****************************************************************


#End Region

        '*******************************************************************
        Private Sub txtSerial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown
            If e.KeyValue = 13 AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
            End If
        End Sub

        '*******************************************************************
        Private Sub ProcessSN()
            Dim objCSMisc As New Data.Buisness.CellstarMisc()
            Dim objGameStopOpt As New PSS.Data.Buisness.GameStopOpt()
            Dim ProdGrpCheck As New PSS.Data.Buisness.ProdGrpCheck()
            Dim objCellularBilling As New PSS.Data.Buisness.CellularBilling()
            Dim objPretest As PSS.Data.Buisness.PreTest
            Dim val As Long = 0
            Dim bIsGSdevice, booCorrectStation As Boolean
            Dim strGSLotNum As String
            Dim strOriginalDeviceSN As String
            Dim dtPretestData As DataTable
            Dim strDevCurrWrkStation As String = ""
            Dim iDeviceCCID, iMachineCCID As Integer

            Try
                booCorrectStation = False : Me._IsSNReady = False
                '******************************
                'Clear controls and variables
                '******************************
                strOriginalDeviceSN = Me.txtSerial.Text.Trim.ToUpper
                ButtonClear_ClickEvent()
                Me.txtSerial.Text = strOriginalDeviceSN
                '******************************

                If Me._iSCustID > 0 Then
                    Dim objVivint As New PSS.Data.Buisness.VV.Vivint()
                    Me.txtSerial.Text = objVivint.RemovePrefixSN(strOriginalDeviceSN, Me._iSCustID)
                    strOriginalDeviceSN = Me.txtSerial.Text.Trim
                    objVivint = Nothing
                End If


                Me.lblATT.Visible = False
                Me.pnlBill.BackColor = Me.BackColor

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                txtSerial.Text = txtSerial.Text.Trim.ToUpper  '//Format serial as all uppercase
                val = Me.verifySerialNumber(txtSerial.Text)

                If val = 0 Then
                    MessageBox.Show("SN/IMEI does not exist in the system or already has a pallet assigned to it.", "information", MessageBoxButtons.OK)
                    Me.lblTray.Visible = False : Me.txtTray.Visible = False
                    Me.txtSerial.Text = "" : Me.txtSerial.Focus() : Exit Sub
                ElseIf val = -1 Then
                    MessageBox.Show("No data in tMessData.", "information", MessageBoxButtons.OK)
                    Me.lblTray.Visible = False : Me.txtTray.Visible = False
                    Me.txtSerial.Text = "" : Me.txtSerial.Focus() : Exit Sub
                ElseIf val = -2 Then
                    MessageBox.Show("More than one rows in tMessData.", "information", MessageBoxButtons.OK)
                    Me.lblTray.Visible = False : Me.txtTray.Visible = False
                    Me.txtSerial.Text = "" : Me.txtSerial.Focus() : Exit Sub
                ElseIf val = -3 Then
                    MessageBox.Show("The device is in Pre-Eval. Can't process it now.", "information", MessageBoxButtons.OK)
                    Me.lblTray.Visible = False : Me.txtTray.Visible = False
                    Me.txtSerial.Text = "" : Me.txtSerial.Focus()
                ElseIf val = -4 Then
                    MessageBox.Show("The device is in WH. Please do Eval Process.", "information", MessageBoxButtons.OK)
                    Me.lblTray.Visible = False : Me.txtTray.Visible = False
                    Me.txtSerial.Text = "" : Me.txtSerial.Focus() : Exit Sub
                ElseIf val = -11 Then
                    MessageBox.Show("The device workstation is not in " & PSS.Data.Buisness.WIKO.WIKO.WIKO_PreBill_WorkStation.Trim.ToUpper & ".", "information", MessageBoxButtons.OK)
                    Me.lblTray.Visible = False : Me.txtTray.Visible = False
                    Me.txtSerial.Text = "" : Me.txtSerial.Focus() : Exit Sub
                ElseIf val = 2 Then
                    MessageBox.Show("SN/IMEI existed more than one in the system. Please contact your lead or supervisor.", "information", MessageBoxButtons.OK)
                    'Me.txtTray.Text = ""
                    'Me.lblTray.Visible = True
                    'Me.txtTray.Visible = True
                    'Me.txtTray.Focus()
                    Me.txtSerial.Text = ""
                    Me.txtSerial.Focus()
                ElseIf Misc.NTF_Device(val) = False Then
                    MessageBox.Show("This screen does not accept any unit from NTF.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerial.Text = "" : Me.txtSerial.Focus() : Exit Sub
                Else
                    Me.tmpDeviceID = val
                    bIsGSdevice = objGameStopOpt.IsGameStopDevice(strOriginalDeviceSN)

                    '******************************************************************
                    ' Added by Yuri on 20-Jun-2007.
                    ' Alter display depending on whether the item is a gamestop device.
                    If bIsGSdevice Then ' Display lot number data
                        Me.lblTray.Visible = False ' Tray controls are invisible
                        Me.txtTray.Visible = False
                        'Me.txtTray.Text = getTrayID(tmpDeviceID)
                        strGSLotNum = objGameStopOpt.GameStopDeviceLotNum(strOriginalDeviceSN)
                        Me.lblLotNum.Left = Me.lblTray.Left ' Set positions for lot number controls
                        Me.lblLotNum.Top = Me.lblTray.Top
                        Me.txtLotNum.Left = Me.lblLotNum.Left + Me.lblLotNum.Width + 1
                        Me.txtLotNum.Top = Me.txtTray.Top + 1
                        Me.txtLotNum.Text = strGSLotNum
                        Me.lblLotNum.Visible = True ' Lot number controls are visible
                        Me.txtLotNum.Visible = True
                    Else ' Display tray data
                        Me.lblLotNum.Visible = False ' Lot number controls are invisible
                        Me.txtLotNum.Visible = False
                        Me.txtLotNum.Text = ""
                        'Me.txtTray.Text = getTrayID(tmpDeviceID)
                        Me.lblTray.Visible = True ' Tray controls are visible
                        Me.txtTray.Visible = True
                    End If

                    '******************************************************************
                    ' Added by Yuri on 21-Jun-2007.
                    ' Check ProdGrp_ID for NULL value.
                    If Not ProdGrpCheck.CheckProdGrpID(strOriginalDeviceSN) Then Exit Sub
                    '******************************************************************

                    If retreiveData() = False Then Exit Sub

                    '**********************************************
                    'Collect warranty data  for TF customer
                    '**********************************************
                    Dim iCurrManufWrty As Integer = Me.vManufWrty
                    If Me.tmpCustID = 2258 Then
                        Dim booRefreshData As Boolean = False
                        If Me.CollectWarrantyDateCode_Tracfone(Me.tmpDeviceID, Me.tmpManufID, Me.tmpModelID, Me.txtSerial.Text, Me.vManufWrty, booRefreshData) = False Then
                            Me.btnClear_Click(Nothing, Nothing)
                            Exit Sub
                        ElseIf booRefreshData Then
                            Dim dtDevice As DataTable = Me._objNewTech.GetDeviceInfo(Me.tmpDeviceID)
                            If dtDevice.Rows.Count > 0 Then Me._drDevice = dtDevice.Rows(0) Else Throw New Exception("Can't find data for device id : " & Me.tmpDeviceID)
                        End If
                    End If
                    If iCurrManufWrty <> Me.vManufWrty Then Me._device = New Device(Me.tmpDeviceID)
                    If vManufWrty = 1 Then Me.lblWarrantyStatus.Text = "IW" Else Me.lblWarrantyStatus.Text = "OW"

                    '*************************************
                    ' Added by Lan on 10/19/2007.
                    ' Get Prebill data.
                    '*************************************
                    If Trim(Me.txtSerial.Text) <> "" AndAlso Me._iBillType = 3 Then Me.GetPrebillData()

                    '*************************************
                    'Added by Lan on 11/14/2007
                    'Device must be pretest before refurbish. ATCLE and SYX Customer only
                    '*************************************
                    If Trim(Me.txtSerial.Text) <> "" AndAlso (Me.tmpCustID = 2019 OrElse Me.tmpCustID = 2485 OrElse Me.tmpCustID = 2629 OrElse Me.tmpCustID = 2631) Then
                        objPretest = New PSS.Data.Buisness.PreTest()
                        dtPretestData = objPretest.GetPretestStatus_ByDeviceID(Me.tmpDeviceID)
                        If dtPretestData.Rows.Count = 0 Then
                            MessageBox.Show("Please pretest device.", "PreTest Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.ButtonClear_ClickEvent()
                            Me.txtSerial.SelectAll()
                            Me.txtSerial.Focus()
                            Exit Sub
                        End If
                    ElseIf Me.tmpProdID = 9 And Me._iDeviceWipOwner = 6 Then
                        'Can't process hold unit. Only get reset by customer service
                        MessageBox.Show("This Unit is currently on hold. Can't process at this point.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.ButtonClear_ClickEvent()
                        Me.txtSerial.SelectAll()
                        Me.txtSerial.Focus()
                        Exit Sub
                    ElseIf Me.tmpCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        '****************************************************
                        'Validate screen name and device workstation
                        '****************************************************
                        If Me._booStationCheck = True Then
                            strDevCurrWrkStation = PSS.Data.Buisness.Generic.GetDeviceCurrentWorkStation(Me.tmpDeviceID).Trim.ToUpper
                            If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, strDevCurrWrkStation, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0) = False Then
                                Me.ButtonClear_ClickEvent() : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                                Exit Sub
                            ElseIf Me._iBillType = 1 AndAlso strDevCurrWrkStation = "BER SCREEN" AndAlso lblATT.Text.EndsWith("_FUN") = False Then
                                MessageBox.Show("Not accept cosmetic unit from BER Screen workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.ButtonClear_ClickEvent() : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                                Exit Sub
                            End If
                        End If
                        '****************************************************
                        'Validate cost center
                        '****************************************************
                        If Me._iBillType = 2 Then
                            iDeviceCCID = PSS.Data.Buisness.Generic.GetCostCenterIDOfDevice(Me.tmpDeviceID)
                            iMachineCCID = PSS.Data.Buisness.Generic.GetMachineCostCenterID()
                            If iDeviceCCID = 0 Then
                                MessageBox.Show("This Device has not received into cell.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.ButtonClear_ClickEvent()
                                Me.txtSerial.SelectAll()
                                Me.txtSerial.Focus()
                                Exit Sub
                            ElseIf PSS.Data.Buisness.Generic.GetNextSeqNoInTtestdata(tmpDeviceID, 13) > 1 Then
                                '//This is rework unit. Don't validate cost center
                            ElseIf IsNothing(Me._drCelloptData) = True AndAlso PSS.Data.Buisness.Generic.GetNextSeqNoInTtestdata(tmpDeviceID, 13) = 1 AndAlso iDeviceCCID <> iMachineCCID Then
                                MessageBox.Show("This Device belongs to cell " & PSS.Data.Buisness.Generic.GetCostCenterDescOfDevice(Me.tmpDeviceID) & "." & Environment.NewLine & "Please send it to the right workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.ButtonClear_ClickEvent()
                                Me.txtSerial.SelectAll()
                                Me.txtSerial.Focus()
                                Exit Sub
                            ElseIf Not IsNothing(Me._drCelloptData) AndAlso CInt(Me._drCelloptData("CellOpt_QCReject")) = 0 AndAlso iDeviceCCID <> iMachineCCID Then
                                MessageBox.Show("This Device belongs to cell " & PSS.Data.Buisness.Generic.GetCostCenterDescOfDevice(Me.tmpDeviceID) & "." & Environment.NewLine & "Please send it to the right workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.ButtonClear_ClickEvent()
                                Me.txtSerial.SelectAll()
                                Me.txtSerial.Focus()
                                Exit Sub
                            ElseIf Not IsNothing(Me._drCelloptData) AndAlso CInt(Me._drCelloptData("CellOpt_QCReject")) = 0 AndAlso Not IsDBNull(Me._drCelloptData("User_Fullname")) AndAlso CInt(Me._drCelloptData("CellOpt_TechAssigned")) <> PSS.Core.ApplicationUser.IDuser Then
                                MessageBox.Show("This Device belongs to technician " & Me._drCelloptData("User_Fullname") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.ButtonClear_ClickEvent()
                                Me.txtSerial.SelectAll()
                                Me.txtSerial.Focus()
                                Exit Sub
                            End If
                        End If

                        ' TODO ON NEXT PROJECT.
                        ' Do software screen if needed.
                        'If _objModelManuf.IsKillSwitchModel(tmpModelID) Then
                        '	Dim _objDevice As New Data.Buisness.tDevice(txtSerial.Text)
                        '	Dim _objDeviceQuestions As New Data.Buisness.tdevice_questionCollection(_objDevice.Device_ID)
                        '	If (_objDeviceQuestions.NeedQuestionsAnswered()) Then
                        '		If Not DoSWScreen() Then
                        '			' Clear SN with message to the user.
                        '			MessageBox.Show("Software Screening is required for this device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '			Me.ButtonClear_ClickEvent()
                        '			Me.txtSerial.SelectAll()
                        '			Me.txtSerial.Focus()
                        '			Exit Sub
                        '		End If
                        '	End If
                        'End If

                        '**************************************************
                        'Hide and show refubished/repair completed button
                        '**************************************************
                        If Me._booStationCheck = False Then
                            Me.btnComplete.Visible = False
                            Me.btnCompleteRepair.Visible = False
                        Else
                            'Check if unit is already completed repair.
                            If Me._iBillType = 2 Then
                                Me.btnCompleteRepair.Visible = True
                                If Me._objNewTech.IsUnitCompletedRepair(Me.tmpDeviceID) = True Then Me.btnCompleteRepair.Enabled = False Else Me.btnCompleteRepair.Enabled = True
                            Else
                                Me.btnCompleteRepair.Visible = False
                                Me.btnCompleteRepair.Enabled = True
                            End If

                        End If
                        '**************************************************
                        HighLightSelectedButtons()
                    ElseIf Me.tmpCustID = PSS.Data.Buisness.Syx.CUSTOMERID Then
                        Me.btnCompleteRepair.Enabled = True
                        Me.btnCompleteRepair.Visible = True
                    ElseIf Me.tmpCustID = Buisness.AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID Then
                        Me.btnComplete.Visible = True
                    End If
                    '*************************************

                    Me.txtSerial.Enabled = False
                    loadTestResults()

                    If Me.tmpCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                        Dim objSkyTel As New PSS.Data.Buisness.SkyTel()
                        Me.lblCustName.Text &= " - " & objSkyTel.GetCustomerLocName(tmpLoc)
                        objSkyTel = Nothing
                    End If
                End If

                Me._IsSNReady = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SN KeyDownEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.ButtonClear_ClickEvent()
            Finally
                Cursor.Current = Cursors.Default : Me.Enabled = True
                objCSMisc = Nothing : objGameStopOpt = Nothing : ProdGrpCheck = Nothing
                objCellularBilling = Nothing : objPretest = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dtPretestData)
            End Try
        End Sub

        '*******************************************************************
        Private Sub GetPrebillData()
            Try
                Me.pnlBill.BackColor = Color.LightSteelBlue

                If Me._objNewTech.IsPreBillOpenForToday(PSS.Core.ApplicationUser.Workdate) = False Then
                    Me.txtSerial.Text = ""
                    Me.ButtonClear_ClickEvent()
                    Throw New Exception("Today's Pre-bill has been closed. You can not do any pre-bill for today.")
                End If

                Me._drPreBillData = _objNewTech.GetPreBillData(Me.tmpDeviceID)
                If Not IsNothing(Me._drPreBillData) Then
                    If Me._iBillType = 3 Then
                        Me.txtSerial.Text = ""
                        Me.ButtonClear_ClickEvent()
                        Throw New Exception("This device has pre-bill lot assigned to it. Can not pre-bill.")
                    ElseIf Me._iMachineGrpID = 3 Then
                        If Me._drPreBillData("PreBillLot_Inactive") = 0 Or Me._iDeviceWipOwner = 8 Then
                            Me.ButtonClear_ClickEvent()
                            Throw New Exception("Pre-bill lot of this device has not released from the part cage. Please contact Material Dept.")
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************
        Private Function verifySerialNumber(ByVal mDeviceSN As String) As Long
            Dim dt, dtMess As DataTable
            Dim objMess As New PSS.Data.Buisness.Messaging()

            Try
                dt = Me._objNewTech.GetDeviceInWip(mDeviceSN, Me._iSCustID)

                If dt.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf dt.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                ElseIf Me._iSCustID = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID OrElse _
                       Me._iSCustID = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                    dtMess = objMess.GetMessDataByDeviceID(dt.Rows(0)("Device_ID"))

                    If dtMess.Rows.Count < 1 Then
                        Return -1 'no data in tmessdata
                    ElseIf dtMess.Rows.Count > 1 Then
                        Return -2 'mutiple rows for device_ID
                    Else '=1
                        If dtMess.Rows(0)("EvalFlag") = 1 AndAlso dtMess.Rows(0)("wipowner_id") = 202 Then 'Pre-Eval
                            Return -3
                        ElseIf dtMess.Rows(0)("EvalFlag") = 1 AndAlso dtMess.Rows(0)("wipowner_id") = 201 Then 'WH             'Pre-Eval
                            Return -4
                        Else 'ok
                            Me.txtTray.Text = dt.Rows(0)("Tray_ID")
                            Return dt.Rows(0)("Device_ID")       'Send back device ID
                        End If
                    End If
                ElseIf Me._iSCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                    Dim objWiKoRecv As New PSS.Data.Buisness.WIKO.WIKO_Receiving()
                    Dim strWorkstation As String = objWiKoRecv.getTCellOptWorkstation(dt.Rows(0)("Device_ID"))
                    If Not strWorkstation.Trim.ToUpper = PSS.Data.Buisness.WIKO.WIKO.WIKO_PreBill_WorkStation.Trim.ToUpper Then
                        Return -11
                    Else
                        Me.txtTray.Text = dt.Rows(0)("Tray_ID")
                        Return dt.Rows(0)("Device_ID")       'Send back device ID
                    End If
                    'Added by Amazech-Thanga 07.08.2021
                ElseIf Me._iSCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                    Dim objWingTechATTRecv As New PSS.Data.Buisness.WingTechATT.WingTechATT_Receiving()
                    Dim strWorkstation As String = objWingTechATTRecv.getTCellOptWorkstation(dt.Rows(0)("Device_ID"))
                    If Not strWorkstation.Trim.ToUpper = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_PreBill_WorkStation.Trim.ToUpper Then
                        Return -11
                    Else
                        Me.txtTray.Text = dt.Rows(0)("Tray_ID")
                        Return dt.Rows(0)("Device_ID")       'Send back device ID
                    End If
                    ''Added By Amazech-Thanga 07.09.2021
                ElseIf Me._iSCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                    Dim objVinsmartRecv As New PSS.Data.Buisness.Vinsmart.Vinsmart_Receiving()
                    Dim strWorkstation As String = objVinsmartRecv.getTCellOptWorkstation(dt.Rows(0)("Device_ID"))
                    If Not strWorkstation.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_PreBill_WorkStation.Trim.ToUpper Then
                        Return -11
                    Else
                        Me.txtTray.Text = dt.Rows(0)("Tray_ID")
                        Return dt.Rows(0)("Device_ID")       'Send back device ID
                    End If
                Else 'ok
                    Me.txtTray.Text = dt.Rows(0)("Tray_ID")
                    Return dt.Rows(0)("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            Finally
                Buisness.Generic.DisposeDT(dt) : Buisness.Generic.DisposeDT(dtMess)
                objMess = Nothing
            End Try
        End Function

        '*******************************************************************
        Private Function retreiveData() As Boolean
            Dim xr As DataRow
            Dim blnNER As Boolean = False
            Dim iWC_ActiveConsume As Integer = 0
            Dim booReturnVal As Boolean = False

            Try
                If Not IsNothing(Me._device) Then Me._device = Nothing

                If getData() = False Then Return False

                If Me.tmpCustID = Buisness.NI.CUSTOMERID Then
                    MessageBox.Show("Not allow to process Natvie Instrument unit. You should use repair/tech screen under Native Instrument menu.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If

                If Me.tmpDeviceID > 0 And Me.tmpCustID > 0 Then
                    Me.PopulateBillingSelectionGrid(Me.tmpDeviceID, Me.tmpCustID)
                End If

                'get machine group
                Me._iMachineGrpID = Me._objNewTech.GetGroupID(System.Net.Dns.GetHostName)

                If Len(Trim(txtTray.Text)) > 0 And Len(Trim(txtSerial.Text)) > 0 Then
                    If Me.tmpProdID <> 1 Then
                        _drCelloptData = Me._objNewTech.GetCellOptAndTechData(Me.tmpDeviceID)
                        '//Identify status of device
                        If Not IsNothing(_drCelloptData) Then
                            Me._iDeviceWipOwner = _drCelloptData("cellopt_WipOwner")
                        End If
                    Else
                        xr = Me._objNewTech.GetMessData(Me.tmpDeviceID)
                        If Not IsNothing(xr) Then
                            Me._iDeviceWipOwner = xr("wipowner_id")
                        End If
                    End If
                End If

                '*************************************
                ' Added by Lan on 10/19/2007.
                ' Get Prebill data.
                '*************************************
                If Me._iDeviceWipOwner = 8 Then
                    MessageBox.Show("This device is currently waiting for parts. Please contact your supervisor for more information.", "Prebill Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.ButtonClear_ClickEvent()
                    Exit Function
                ElseIf Me.tmpCustID = 2453 AndAlso vManufWrty = 0 AndAlso _drCelloptData("Cellopt_WIPOwner").ToString = "6" Then
                    '**************************************************************************************
                    ' Added by Lan on 05/16/2011. PANTCH OW, can't Add more part after billing is completed.
                    ' Reason: Customer services might already contact customer with the total charge. 
                    '**************************************************************************************
                    MessageBox.Show("Device is currently on hold.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.ButtonClear_ClickEvent()
                    Exit Function
                End If
                '*************************************

                '//****************************************************************
                'If Me.tmpCustID = 2258 And Me._iBillType = 2 Then CreateFuncBillingButtons() 'Tracfone customer
                Me.LoadDevice()
                If Me.tmpCustID = 2258 Then CreateFuncBillingButtons() 'Tracfone customer
                loadBillCodes()
                loadServiceCodes()
                CreateRVBillCodesButtons()
                Me.CreateAccessoryButtons()
                populateParts()

                'added by Amazech-Thanga 07.07.2021 and 07.08.2021 and 07.09.2021
                If Not Me.tmpCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID AndAlso Not Me.tmpCustID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID AndAlso Me._device.CustRepNonWrty = 0 AndAlso Not Me.tmpCustID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID AndAlso Me.tmpCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID AndAlso Me.tmpCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID And Me.vManufWrty = 0 Then
                    MsgBox("This customer does not approve non warranty repairs. Please do not try to bill.", MsgBoxStyle.OKOnly)
                    Me.ButtonClear_ClickEvent()
                    Exit Function
                End If

                Return True
            Catch ex As Exception
                Throw ex
            Finally
                xr = Nothing
            End Try
        End Function

        Private Function getData() As Boolean
            Dim booResult As Boolean = True
            Dim dt As DataTable
            Dim objBillGrpAdmin As New Buisness.BillGroupsAdmin()
            Dim dtModelTarget As DataTable

            Try
                objBillGrpAdmin = New Buisness.BillGroupsAdmin()
                tmpModelID = 0
                tmpManufID = 0
                tmpProdID = 0
                tmpTrayID = 0
                tmpWO = 0
                tmpCustID = 0

                tmpCustCRbill = 0
                tmpDeviceType = 0
                vManufWrty = 0
                _iPSSWrty = 0
                tmpConsignedParts = 0
                _dtAWAP = New DataTable()
                _drDevice = Nothing

                tmpTrayID = Me.txtTray.Text
                If Me.tmpDeviceID = 0 Then Throw New Exception("Device ID is missing.")

                dt = Me._objNewTech.GetDeviceInfo(Me.tmpDeviceID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Can't define device's model.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Device ID existed more than one in the system.")
                Else
                    _drDevice = dt.Rows(0)
                    tmpModelID = dt.Rows(0)("Model_ID")
                    tmpManufID = dt.Rows(0)("Manuf_ID")
                    tmpProdID = dt.Rows(0)("Prod_ID")
                    tmpTrayID = dt.Rows(0)("Tray_ID")
                    tmpWO = dt.Rows(0)("WO_ID")
                    tmpLoc = dt.Rows(0)("Loc_ID")
                    tmpCustID = dt.Rows(0)("Cust_ID")
                    tmpCustCRbill = dt.Rows(0)("Cust_CRBilling")
					vManufWrty = Data.Buisness.Generic.ConvertToSomething(dt.Rows(0)("Device_ManufWrty"), 0)
					tmpConsignedParts = Data.Buisness.Generic.ConvertToSomething(dt.Rows(0)("cust_consignedparts"), 0)
					_iPSSWrty = Data.Buisness.Generic.ConvertToSomething(dt.Rows(0)("Device_PSSWrty"), 0)
                    Me.lblATT.Text = dt.Rows(0)("Model_Desc") : Me.lblATT.Visible = True

                    If tmpProdID = 2 Then btnComplete.Visible = True Else btnComplete.Visible = False
                    If Me._iBillType = 1 AndAlso Me.tmpCustID = 2258 Then Me.btnCompleteRepair.Visible = False
                    If tmpProdID = 75 AndAlso Me.tmpCustID = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID Then Me.btnComplete.Visible = True

                    If tmpDeviceID = 0 Or tmpModelID = 0 Or tmpManufID = 0 Then
                        Throw New Exception("Can not define Device ID/ Model ID/ Manufacturer ID of this device.")
                    ElseIf Me.tmpCustID = 2427 Then 'Genesis
                        Throw New Exception("This screen is not availble for this customer.")
                    End If

                    If dt.Rows(0)("TechFailureCode").ToString.Trim = "1" Then
                        Me.gbTechFailureCodes.Visible = True
                        Me.LoadTechFailureCodes(tmpDeviceID)
                        LoadTechFailureResult(tmpDeviceID)
                    Else
                        Me.gbTechFailureCodes.Visible = False
                    End If

                    If vManufWrty = 1 Then Me.lblWarrantyStatus.Text = "IW" Else Me.lblWarrantyStatus.Text = "OW"

                    If tmpCustID = Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                        Me.lblWarrantyStatus.Visible = False
                        'Added by Amazech-Thanga 07.08.2021
                    ElseIf tmpCustID = Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                        Me.lblWarrantyStatus.Visible = False
                        'Added By Amazech-Thanga 07.09.2021
                    ElseIf tmpCustID = Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        Me.lblWarrantyStatus.Visible = False
                    Else
                        Me.lblWarrantyStatus.Visible = True
                    End If

                    If tmpCustID = Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then 'reset wrnty desc
                        If vManufWrty = 0 Then
                            Me.lblWarrantyStatus.Text = "OW"
                        ElseIf vManufWrty = 1 Then
                            Me.lblWarrantyStatus.Text = "IW"
                        ElseIf vManufWrty = 2 Then
                            Me.lblWarrantyStatus.Text = "DOA"
                        Else
                            Throw New Exception("No warranty defined of this device.")
                        End If
                    End If
                    'added by Amazech-Thanga 07.07.2021
                    If tmpCustID = Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID Then 'reset wrnty desc
                        If vManufWrty = 0 Then
                            Me.lblWarrantyStatus.Text = "OW"
                        ElseIf vManufWrty = 1 Then
                            Me.lblWarrantyStatus.Text = "IW"
                        ElseIf vManufWrty = 2 Then
                            Me.lblWarrantyStatus.Text = "DOA"
                        Else
                            Throw New Exception("No warranty defined of this device.")
                        End If
                    End If
                    If tmpCustID = Buisness.VV.Vivint.Vivint_CUSTOMER_ID Then  'reset wrnty desc
                        Me.lblWarrantyStatus.Visible = True
                        If vManufWrty = 0 Then
                            Me.lblWarrantyStatus.Text = "OW"
                        ElseIf vManufWrty = 1 Then
                            Me.lblWarrantyStatus.Text = "IW"
                        ElseIf vManufWrty = 2 Then
                            Me.lblWarrantyStatus.Text = "NW" 'No Warranty
                            Me.lblWarrantyStatus.Visible = False
                        Else
                            Throw New Exception("No warranty defined of this device.")
                        End If
                    End If

                    createCustDataTable(tmpCustID, tmpModelID)
                    _dtAWAP = Me._objNewTech.GetSelectedAWAP(tmpDeviceID)
                    dtModelTarget = objBillGrpAdmin.GetModelTarget(Me.tmpCustID, Me.tmpModelID, "")
                    If dtModelTarget.Rows.Count > 0 Then
                        Me._dbBERTarget = dtModelTarget.Rows(0)("MT_BERCap")
                        If Not IsDBNull(dtModelTarget.Rows(0)("FlatRate")) AndAlso CInt(dtModelTarget.Rows(0)("FlatRate")) = 1 Then _iTFFlatRate = 1 Else _iTFFlatRate = 0
                    End If

                    'getPartData(tmpModelID)

                    '****************************
                    'Added by Lan on 10/03/2007
                    'Show ATT lalel if model desc
                    ' has ATT phase
                    '****************************
                    If tmpCustID = 2019 Then
                        Dim objATCLESpecialBilling As New PSS.Data.Buisness.ATCLESpecialBilling()
                        If objATCLESpecialBilling.IsModelHasATT(tmpModelID) = True Then
                            Me.lblATT.Visible = True
                            Me.pnlBill.BackColor = Color.SteelBlue
                        Else
                            Me.lblATT.Visible = False
                            Me.pnlBill.BackColor = Me.BackColor
                        End If
                        objATCLESpecialBilling = Nothing

                    ElseIf tmpCustID = 14 Or tmpCustID = PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID OrElse _
                                            tmpCustID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse _
                                            tmpCustID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse _
                                            tmpCustID = Buisness.SkyTel.CookPager_CUSTOMER_ID OrElse _
                                            tmpCustID = Buisness.SkyTel.CriticalAlert_CUSTOMER_ID OrElse _
                                            tmpCustID = Buisness.SkyTel.Anna_CUSTOMER_ID OrElse _
                                            tmpCustID = Buisness.SkyTel.Lahey_CUSTOMER_ID OrElse _
                                            tmpCustID = Buisness.SkyTel.Masco_CUSTOMER_ID OrElse _
                                            tmpCustID = Buisness.SkyTel.Franciscan_CUSTOMER_ID OrElse _
                                            tmpCustID = Buisness.SkyTel.Maine_CUSTOMER_ID OrElse _
                                            tmpCustID = Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                        'tmpCustID = 1545 or tmpCustID = 2507 Or tmpCustID = 2508 Then 'modified for new cust_ID, Z Fang
                        '***************************************************
                        'Populate Average parts cost information 03/17/2009
                        '***************************************************
                        DisplayAvgPartsCostInfo(tmpCustID, tmpLoc, tmpModelID, tmpDeviceID, True)
                        DisplayPretestResult(tmpDeviceID)   'pretest result
                        '***************************************************
                    ElseIf Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        Me.lblRFResult.Text = Me._objNewTech.GetLatestRFTestResult(Me.tmpDeviceID)
                        Me.lblQCResult.Text = Me._objNewTech.GetLatestQCTestResult(Me.tmpDeviceID)
                        DisplayPretestResult(tmpDeviceID)   'pretest result
                    ElseIf Me.tmpCustID = Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                        Dim bIsDevicePretested As Boolean = False
                        DisplayPretestResult(tmpDeviceID, bIsDevicePretested)   'pretest result
                        If Not bIsDevicePretested Then Throw New Exception("This device is not pretested. Can't process in Tech/Bill screen.")
                        'Added by Amazech-Thanga 07.08.2021
                    ElseIf Me.tmpCustID = Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                        Dim bIsDevicePretested As Boolean = False
                        DisplayPretestResult(tmpDeviceID, bIsDevicePretested)   'pretest result
                        If Not bIsDevicePretested Then Throw New Exception("This device is not pretested. Can't process in Tech/Bill screen.")
                        'Added By Amazech-Thanga 07.09.2021
                    ElseIf Me.tmpCustID = Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        Dim bIsDevicePretested As Boolean = False
                        DisplayPretestResult(tmpDeviceID, bIsDevicePretested)   'pretest result
                        If Not bIsDevicePretested Then Throw New Exception("This device is not pretested. Can't process in Tech/Bill screen.")
                    End If

                    '****************************
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                'KEEP THIS SO DON'T HAVE DECLARE TOO MANY GLOBAL VARIABLE
                'Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************
        'Populate Average parts cost information 03/17/2009
        '*******************************************************************
        Private Sub DisplayAvgPartsCostInfo(ByVal iCustID As Integer, _
                                            ByVal iLocID As Integer, _
                                            ByVal iModelID As Integer, _
                                            ByVal iDeviceID As Integer, _
                                            ByVal booRefreshAPCG As Boolean)
            Dim objAPC As PSS.Data.Buisness.AvgPartsCost
            Dim decPartsCostGoal As Decimal = 0.0
            Dim decUnitPartsCost As Decimal = 0.0
            Dim decDailyAvgPartsCost As Decimal = 0.0
            Dim strAPCG As String = ""

            Try
                If booRefreshAPCG = False Then
                    strAPCG = Me.lblAPCGoal.Text.Trim
                    If (strAPCG.Length = 0 Or strAPCG.Substring(strAPCG.IndexOf("$") + 1).Trim.Length = 0) Then
                        booRefreshAPCG = True
                    Else
                        decPartsCostGoal = CDec(strAPCG.Substring(strAPCG.IndexOf("$") + 1).Trim)
                    End If
                End If

                Me.lblAPCGoal.Visible = False
                Me.lblUnitPartsCost.Visible = False
                Me.lblDailyAPC.Visible = False
                Me.lblUnitPartsCost.ForeColor = Color.Green
                Me.lblDailyAPC.ForeColor = Color.Green
                Me.lblAPCGoal.Text = ""
                Me.lblUnitPartsCost.Text = ""
                Me.lblDailyAPC.Text = ""

                objAPC = New PSS.Data.Buisness.AvgPartsCost()
                If booRefreshAPCG = True Or decPartsCostGoal = 0 Then decPartsCostGoal = objAPC.GetAPCGAmt(iCustID, iModelID)

                If decPartsCostGoal > 0 Then
                    objAPC.GetUnitsPartsCostAndTodayAPC(iCustID, iLocID, iModelID, iDeviceID, decUnitPartsCost, decDailyAvgPartsCost)
                    Me.lblAPCGoal.Visible = True
                    Me.lblUnitPartsCost.Visible = True
                    Me.lblDailyAPC.Visible = True

                    Me.lblAPCGoal.Text = "Avg Parts Cost Goal $" & Format(decPartsCostGoal, "##0.00")
                    Me.lblUnitPartsCost.Text = "Unit Parts Cost $" & Format(decUnitPartsCost, "##0.00")
                    Me.lblDailyAPC.Text = "Daily Avg Parts Cost $" & Format(decDailyAvgPartsCost, "##0.00")

                    'color code goal
                    If Format(decUnitPartsCost, "##0.00") > decPartsCostGoal Then Me.lblUnitPartsCost.ForeColor = Color.Red
                    If Format(decDailyAvgPartsCost, "##0.00") > decPartsCostGoal Then Me.lblDailyAPC.ForeColor = Color.Red
                End If

            Catch ex As Exception
                Throw ex
            Finally
                objAPC = Nothing
                strAPCG = Nothing
            End Try
        End Sub

        '*******************************************************************
        'Display pretest result 03/17/2009
        '*******************************************************************
        Private Sub DisplayPretestResult(ByVal iDeviceID As Integer, Optional ByRef bIsDevicePretested As Boolean = False)
            Dim objPT As PSS.Data.Buisness.PreTest
            Dim strPretestResult As String = ""

            Try
                Me.lblRejectReason.Visible = False
                Me.lblRejectReason.Text = ""

                objPT = New PSS.Data.Buisness.PreTest()
                strPretestResult = objPT.GetPretestResult(iDeviceID)
                If strPretestResult.Trim.Length > 0 Then
                    Me.lblRejectReason.Text = "Pretest Result: " & strPretestResult
                    bIsDevicePretested = True
                    Me.lblRejectReason.Visible = True
                Else
                    Me.lblRejectReason.Text = "No pretest history" & strPretestResult
                    bIsDevicePretested = False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objPT = Nothing
            End Try
        End Sub

        '*******************************************************************


        '*******************************************************************
        'Private Function getTrayID(ByVal mDeviceID As Long) As Long
        '    Dim dTray As PSS.Data.Production.tdevice
        '    Dim tTray As DataRow

        '    Try
        '        getTrayID = 0
        '        dTray = New PSS.Data.Production.tdevice()
        '        tTray = dTray.GetRowByPK(mDeviceID)
        '        getTrayID = tTray("Tray_ID")
        '    Catch ex As Exception
        '        '//will return value of 0 so no coding necessary here
        '    Finally
        '        dTray = Nothing
        '        tTray = Nothing
        '    End Try
        'End Function

        ''*******************************************************************
        'Private Sub getPartData(ByVal ModelID As Int32)

        '    Dim dtPdata As New PSS.Data.Buisness.DeviceBilling()
        '    Dim dtPartData As DataTable = dtPdata.GetPartData(ModelID)

        '    Try
        '        dtPartData.Dispose()
        '        dtPartData = Nothing
        '    Catch ex As Exception
        '    End Try
        'End Sub

        '*********************************************************************************************
        Private Sub LoadDevice()
            Try
                _device = Nothing
                _device = New Device(Me.tmpDeviceID)
                _device.ScreenID = Me._iScreenID

                If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    Dim booFlatRateModel As Boolean = False
                    Dim dtFlatRate As DataTable
                    Dim dteToday As DateTime = CDate(Data.Buisness.Generic.MySQLServerDateTime(1))

                    'Validate Flat Rate
                    booFlatRateModel = Buisness.DeviceBilling.IsFlatRateModel(Me.tmpCustID, Me.tmpModelID, True, )
                    If booFlatRateModel = False Then Throw New Exception("Flat rate is not set up for this model.")
                    _device.FlatRatePart = booFlatRateModel
                    dtFlatRate = Data.Buisness.DeviceBilling.GetTFFlatRateLaborPartCharge(Me.tmpCustID, Me._device.DeviceData("Model_Desc"), CInt(dteToday.Year & dteToday.Month.ToString("00")))
                    If dtFlatRate.Rows.Count = 0 Then Throw New Exception("No flat rate set up for this model.")
                    Buisness.Generic.DisposeDT(dtFlatRate)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub loadBillCodes()
            Dim mthd As New PSS.Data.Production.Joins()
            Dim mthdGrp As DataTable
            Dim mthdScrap As DataTable
            Dim objBD As Buisness.DeviceBilling
            Dim dtFuncParts As DataTable
            Dim strSQL As String = ""

            Try
                'If tmpConsignedParts = 0 Then

                '    mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=0 AND tpsmap.Inactive = 0 ORDER BY BillCode_Desc")
                '    'End If

                '    '//New for Debra Maxwell July 22 2005
                '    If tmpCustID = 1 Then
                '        mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=0 AND tpsmap.laborlvl_id < 3 AND tpsmap.Inactive = 0 ORDER BY BillCode_Desc")
                '        '//New for Debra Maxwell July 22 2005
                '    ElseIf tmpCustID <> 1403 Then '//Motorola - NSC
                '        'Added by Asif on 02/19/2007
                '        'If tmpCustID = 2019 Then    'ATCLE-AWS Customer
                '        'mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=0 AND tpsmap.Inactive = 0 AND tpsmap.custflg = 0 and lbillcodes.billcode_id <> 707 ORDER BY BillCode_Desc") 'Don't display 'LCD main' billcode
                '        'Else
                '        mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=0 AND tpsmap.Inactive = 0 AND tpsmap.custflg = 0 ORDER BY BillCode_Desc")
                '    End If

                '    '//New for Debra Maxwell July 22 2005
                'End If

                If tmpConsignedParts = 1 Then
                    'mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=1 ORDER BY BillCode_Desc")
                    'mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=1 AND tpsmap.Inactive = 0 ORDER BY BillCode_Desc")
                    strSQL = "SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=1 AND tpsmap.Inactive = 0 ORDER BY BillCode_Desc"
                    mthdGrp = mthd.GenericSelect(strSQL)
                Else
                    '//April 23, 2007
                    '//This is allowed only for Brightpoint
                    '//This will display both regular and consigned billcodes
                    If tmpCustID = 2113 Then
                        'mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM " & _
                        '"lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & _
                        '"INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                        '"LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & _
                        '"AND tbilldisplayexceptions.cust_id = " & tmpCustID & " " & _
                        '"WHERE tpsmap.model_id = " & tmpModelID & " " & _
                        '" AND billtype_id = 2 " & _
                        '"AND tpsmap.Inactive = 0 " & _
                        '"AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & tmpCustID & ") " & _
                        '"AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & _
                        '"ORDER BY BillCode_Desc")
                        strSQL = "SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM " & _
                        "lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & _
                        "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                        "LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & _
                        "AND tbilldisplayexceptions.cust_id = " & tmpCustID & " " & _
                        "WHERE tpsmap.model_id = " & tmpModelID & " " & _
                        " AND billtype_id = 2 " & _
                        "AND tpsmap.Inactive = 0 " & _
                        "AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & tmpCustID & ") " & _
                        "AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & _
                        "ORDER BY BillCode_Desc"
                        mthdGrp = mthd.GenericSelect(strSQL)
                    ElseIf tmpCustID = 2258 Or tmpCustID = 2485 Then
                        objBD = New Buisness.DeviceBilling()
                        mthdGrp = objBD.GetPartBillcodes(tmpCustID, tmpModelID, 2, , 0)
                    Else
                        'February 26, 2007
                        '//This new code allows for the inclusion of a table which will allow for the 
                        '//hiding of specific billcodes on models for specific customers.
                        'mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM " & _
                        '"lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & _
                        '"INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                        '"LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & _
                        '"AND tbilldisplayexceptions.cust_id = " & tmpCustID & " " & _
                        '"WHERE tpsmap.model_id = " & tmpModelID & " " & _
                        '" AND billtype_id = 2 AND tpsmap.ReflowTypeID <> 4 " & _
                        '"AND lpsprice.psprice_consignedpart = 0 " & _
                        '"AND tpsmap.Inactive = 0 AND lpsprice.RVFlag = 0 " & _
                        '"AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & tmpCustID & ") " & _
                        '"AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & _
                        '"ORDER BY BillCode_Desc")
                        strSQL = "SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM " & _
                        "lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & _
                        "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                        "LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & _
                        "AND tbilldisplayexceptions.cust_id = " & tmpCustID & " " & _
                        "WHERE tpsmap.model_id = " & tmpModelID & " " & _
                        " AND billtype_id = 2 AND tpsmap.ReflowTypeID <> 4 " & _
                        "AND lpsprice.psprice_consignedpart = 0 " & _
                        "AND tpsmap.Inactive = 0 AND lpsprice.RVFlag = 0 " & _
                        "AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & tmpCustID & ") " & _
                        "AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & _
                        "ORDER BY BillCode_Desc"
                        mthdGrp = mthd.GenericSelect(strSQL)
                        '//End of new code segment
                        'February 26, 2007
                    End If
                    '//April 23, 2007
                    '//This is allowed only for Brightpoint
                    '//This will display both regular and consigned billcodes

                End If

                '//New code to get scrap button datatable
                ' mthdScrap = mthd.OrderEntrySelect("SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_flgCountScrap = 1 AND tpsmap.Inactive = 0 ORDER BY lpsprice.psprice_ordergroup desc, BillCode_Desc asc")
                strSQL = "SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_flgCountScrap = 1 AND tpsmap.Inactive = 0 ORDER BY lpsprice.psprice_ordergroup desc, BillCode_Desc asc"
                mthdScrap = mthd.OrderEntrySelect(strSQL)

                '//New code to get scrap button datatable

                createBillingButtons(mthdGrp)
                System.Windows.Forms.Application.DoEvents()
                createScrapButtons(mthdScrap)
                System.Windows.Forms.Application.DoEvents()

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                Buisness.Generic.DisposeDT(mthdGrp)
                Buisness.Generic.DisposeDT(mthdScrap)
            End Try
        End Sub

        '******************************************************************
        Private Sub loadServiceCodes()
            Dim mthd As New PSS.Data.Production.Joins()
            'Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 1 AND lbillcodes.billcode_id <> 278 ORDER BY BillCode_Desc")
            Dim mthdGrp As DataTable
            Dim strSQL As String = ""

            Try
                'February 26, 2007
                '//This new code allows for the inclusion of a table which will allow for the 
                '//hiding of specific billcodes on models for specific customers.
                'mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM " & _
                '"lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & _
                '"INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                '"LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & _
                '"AND tbilldisplayexceptions.cust_id = " & tmpCustID & " " & _
                '"WHERE tpsmap.model_id = " & tmpModelID & " " & _
                '" AND billtype_id = 1 " & _
                '"AND lpsprice.psprice_consignedpart = 0 " & _
                '"AND tpsmap.Inactive = 0 " & _
                '"AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & tmpCustID & ") " & _
                '"AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & _
                '"ORDER BY BillCode_Desc")
                strSQL = "SELECT lbillcodes.*, lpsprice.psprice_number FROM " & _
                "lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & _
                "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                "LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & _
                "AND tbilldisplayexceptions.cust_id = " & tmpCustID & " " & _
                "WHERE tpsmap.model_id = " & tmpModelID & " " & _
                " AND billtype_id = 1 " & _
                "AND lpsprice.psprice_consignedpart = 0 " & _
                "AND tpsmap.Inactive = 0 " & _
                "AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & tmpCustID & ") " & _
                "AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & _
                "ORDER BY BillCode_Desc"
                mthdGrp = mthd.GenericSelect(strSQL)
                '//End of new code segment
                'February 26, 2007

                createServiceButtons(mthdGrp)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "loadServiceCodes", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                mthd = Nothing
                If Not IsNothing(mthdGrp) Then
                    mthdGrp.Dispose()
                    mthdGrp = Nothing
                End If
            End Try
        End Sub

        '******************************************************************
        Private Sub populateParts()
            Dim x As Integer = 0
            Dim R1 As DataRow
            Dim tmpBtn As Button

            Try
                'Highlight button that are selected
                For Each R1 In Me._device.Parts.Rows
                    'Bill panel
                    For x = 0 To pnlBill.Controls.Count - 1
                        tmpBtn = CType(pnlBill.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    'Service panel
                    For x = 0 To pnlService.Controls.Count - 1
                        tmpBtn = CType(pnlService.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    'Functional part panel
                    For x = 0 To Me.pnlFuncParts.Controls.Count - 1
                        tmpBtn = CType(pnlFuncParts.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    'RV part panel
                    For x = 0 To Me.pnlRVParts.Controls.Count - 1
                        tmpBtn = CType(pnlRVParts.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    'RV Functional part panel
                    For x = 0 To Me.pnlRVFParts.Controls.Count - 1
                        tmpBtn = CType(pnlRVFParts.Controls(x), System.Windows.Forms.Button)
                        With tmpBtn
                            If R1("BillCode_ID") = .Tag Then
                                tmpBtn.ForeColor = Color.Blue
                                Exit For
                            End If
                        End With
                    Next x
                Next R1

                'Highlight needed parts
                For Each R1 In Me._dtAWAP.Rows
                    For x = 0 To Me.pnlNeededParts.Controls.Count - 1
                        tmpBtn = CType(pnlNeededParts.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    For x = 0 To Me.pnlNeededAccessories.Controls.Count - 1
                        tmpBtn = CType(pnlNeededAccessories.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x
                Next R1

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Sub

        '*******************************************************************
        Private Sub PopulateBillingSelectionGrid(ByVal iDeviceID As Integer, ByVal iCustID As Integer)
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                If iDeviceID = 0 Or iCustID = 0 Then
                    Me.gridBilling.DataSource = Nothing
                    Me.gridBilling.Visible = False
                Else
                    If iCustID = 2258 Then dt = Me._objNewTech.GetBillingSelectionInformation(iDeviceID, iCustID, True) Else dt = Me._objNewTech.GetBillingSelectionInformation(iDeviceID, iCustID, )

                    With Me.gridBilling
                        .DataSource = Nothing
                        .DataSource = dt.DefaultView
                        .Visible = True

                        .Splits(0).Style.WrapText = True
                        .FilterBar = True
                        .RowHeight = 28
                        .AlternatingRows = True

                        For i = 0 To .Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        Next i

                        .Splits(0).DisplayColumns("Complain Description").Width = 120
                        .Splits(0).DisplayColumns("Main Category").Width = 100
                        .Splits(0).DisplayColumns("Fail Code").Width = 120

                        .Splits(0).DisplayColumns("Fail At").Width = 80
                        .Splits(0).DisplayColumns("Failed Inspector").Width = 80
                        .Splits(0).DisplayColumns("Repair Code").Width = 120
                        .Splits(0).DisplayColumns("Part Desc").Width = 65
                        .Splits(0).DisplayColumns("Part Number").Width = 70
                        .Splits(0).DisplayColumns("Part SN").Width = 65
                        .Splits(0).DisplayColumns("Part IMEI").Width = 65
                        .Splits(0).DisplayColumns("Tech").Width = 100
                        .Splits(0).DisplayColumns("Completed").Width = 62
                        .Splits(0).DisplayColumns("Completed Tech").Width = 80
                        .Splits(0).DisplayColumns("Completed Date").Width = 100
                        .Splits(0).DisplayColumns("Seq").Width = 40

                        .Columns("Completed Date").NumberFormat = "MM/dd/yyyy hh:mm tt"

                        .Splits(0).DisplayColumns("BillCode_ID").Visible = False
                        .Splits(0).DisplayColumns("Fail_ID").Visible = False
                        .Splits(0).DisplayColumns("Repair_ID").Visible = False
                        .Splits(0).DisplayColumns("MC_ID").Visible = False
                        .Splits(0).DisplayColumns("RI_ID").Visible = False
                        .Splits(0).DisplayColumns("Device_ID").Visible = False
                        .Splits(0).DisplayColumns("FailDetails").Visible = False
                        .Splits(0).DisplayColumns("PSPrice_ID").Visible = False
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************
        Private Sub ScrapClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim i As Integer = 0
            Dim objScrap As New PSS.Data.Buisness.ScrapParts()
            Dim iEmpNo As Integer = PSS.Core.Global.ApplicationUser.NumberEmp
            Dim strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
            Dim iBillcode_ID As Integer = 0
            Dim DlgRslt As DialogResult
            Dim iCount As Integer = 0
            Dim stroldText As String = Trim(sender.text.ToString)
            Dim strnewText As String = ""

            If Trim(sender.tag.ToString) <> "" Then
                iBillcode_ID = CInt(Trim(sender.tag.ToString))
            Else
                Throw New Exception("BillcodeID could not be determined.")
            End If

            Try
                '*********************
                DlgRslt = MessageBox.Show("To Scrap: Click 'YES'." & Environment.NewLine & "To Unscrap: Click 'NO'." & Environment.NewLine & "To Cancel without changing anything: Click 'CANCEL'.", "Add to Scrap or Remove from Scrap", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

                Select Case DlgRslt
                    Case DialogResult.Yes
                        iCount = 1
                    Case DialogResult.No
                        iCount = -1
                    Case DialogResult.Cancel
                        iCount = 0
                        Exit Sub
                    Case Else
                        Throw New Exception("Unable to determine if the part is being scrapped or removed from the scrap.")
                End Select
                '*********************
                i = objScrap.ScrapParts(tmpDeviceID, tmpModelID, iBillcode_ID, tmpProdID, iEmpNo, strWorkDate, iCount, PSS.Core.ApplicationUser.IDuser)
                '*********************
                If i > 0 Then
                    iCount = objScrap.GetScrapCount(tmpDeviceID, tmpModelID, iBillcode_ID)
                    strnewText = Mid(stroldText, 1, InStr(stroldText, "(") - 1) & "(" & iCount & ")"
                    sender.text = strnewText
                    If iCount > 0 Then
                        sender.backcolor = Color.LightGreen
                        sender.forecolor = Color.Black
                    Else
                        sender.backcolor = Color.LightCoral
                        sender.forecolor = Color.Black
                    End If
                End If
                '*********************

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Scrap Part Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objScrap = Nothing
            End Try
        End Sub

        Private Sub billingClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim iFailID, iRepairID, iComplainID, iRVPart, iConsignedPart As Integer
            Dim dr1, drSelectedBillcode As DataRow
            Dim x As Integer
            Dim action As String
            Dim strNextBucket, strAddPartNo, strReplPartSN As String
            Dim dtContingent As DataTable
            Dim booIsRVPart As Boolean = False

            Try
                If Not IsNothing(Me._device) Then
                    Me._device.FailID = 0 : Me._device.RepairID = 0 : Me._device.ComplainID = 0
                End If
                strNextBucket = "" : strAddPartNo = "" : strReplPartSN = "" : iFailID = 0 : iRepairID = 0 : iComplainID = 0 : iRVPart = 0 : iConsignedPart = 0

                '//May 25, 2006
                '//Validate group value before continuing
                '//This section validates that all groups are defined
                '//and that they machine group is equal to the workorder group
                '//the device is tied to.
                Dim blnValidate As Boolean = validateDeviceMachineGroup(tmpDeviceID)
                If blnValidate = False Then
                    Exit Sub
                ElseIf Me.tmpDeviceID = 0 Then
                    Exit Sub
                End If
                '//May 25, 2006

                '//Determine action to be performed
                action = "add"
                If Me._device.Parts.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then action = "remove"

                '*********************************
                'Define Adding Part #
                '*********************************
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length = 0 Then
                    MessageBox.Show("Billcode ID is missing in billable list. Please refresh the screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    drSelectedBillcode = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)
                    strAddPartNo = drSelectedBillcode("PSPrice_Number").ToString.ToLower
                    iRVPart = drSelectedBillcode("RVFlag")
                    iConsignedPart = drSelectedBillcode("PSPrice_ConsignedPart")
                    If iRVPart = 1 Then booIsRVPart = True
                End If

                If Me.tmpCustID = 2258 AndAlso action = "add" AndAlso drSelectedBillcode("BillCode_Rule") = 1 AndAlso (Me._drCelloptData("Workstation").ToString.Trim.ToUpper = "WH-WIP" OrElse Me._drCelloptData("Workstation").ToString.Trim.ToUpper = "PRODUCTION STAGING") Then
                    MessageBox.Show("Can't bill RUR on unit at 'WH-WIP'/'PRODUCTION STAGING' location. Please transfer to 'Pre-Bill'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Confirm message - AMS Infrastructure
                If action = "add" AndAlso drSelectedBillcode("BillCode_Rule") = 1 AndAlso Me.tmpCustID = PSS.Data.Buisness.AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID AndAlso MessageBox.Show("Are you sure you want to complete this device?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                If Me.tmpCustID = PSS.Data.Buisness.Syx.CUSTOMERID AndAlso action = "add" AndAlso strAddPartNo.Trim.ToLower <> "syxtemp" AndAlso drSelectedBillcode("BillType_ID") = 2 Then
                    'Technician has to confirm corret part # in BOM
                    If MessageBox.Show("Please confirm the following part number is correct by click on OK otherwise click Cancel and contact your suppervisor. " & Environment.NewLine & strAddPartNo, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then Exit Sub
                End If

                '*********************************

                If Me.BillingClickValidate(tmpCustID, action.Trim.ToUpper, CInt(Trim(sender.tag.ToString))) = False Then
                    '*********************************
                    'Customer specific validation 10/20/08
                    '*********************************
                    Exit Sub
                ElseIf action = "add" AndAlso Me.ValidateRVOEMAndConsighnedPartSelection(strAddPartNo, CInt(Trim(sender.tag.ToString)), iRVPart, iConsignedPart) = False Then
                    '***************************************************
                    'RV, EOM and Consigned Parts validation 05/05/2011
                    '***************************************************
                    Exit Sub
                End If

                '**************************************************************
                'COMMENT THIS ON 6/12/2014 BECUASE TF NEED TO KEEP NEED PART.
                ' THIS CHECK ONLY APPLY TO TMI BUT WE DONT HAVE TMI ANY MORE....
                '**************************************************************
                ''Must remove all needed part before scrap 
                'If tmpCustID <> Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso action = "add" AndAlso drSelectedBillcode("BillCode_Rule") <> 0 AndAlso Me._dtAWAP.Rows.Count > 0 Then
                '    MessageBox.Show("Please remove all need part(s) before select this bill code " & sender.text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Exit Sub
                'End If

                '***************************************************
                ' Collect real part and repalce with temporay part
                '***************************************************
                If action = "add" AndAlso (strAddPartNo.Trim.ToLower.Equals("temppart") = True OrElse strAddPartNo.Trim.ToLower.Equals("temppart_rv") = True) AndAlso CollectPartAndReplaceTempPartInBOM(sender.tag.ToString.Trim, booIsRVPart, Me.tmpProdID, Me.tmpModelID, Me._device) = False Then
                    Exit Sub
                End If

                '*************************************************
                'Get Failcode and Repair code for warranty device
                '*************************************************
                If action = "add" AndAlso Me.tmpProdID = 2 AndAlso Me.vManufWrty = 1 AndAlso Me._device.ManufWarantyClaimable = 1 AndAlso (Me._iPSSWrty = 0 Or (Me._iPSSWrty = 1 AndAlso Me._device.PSSWarrantyID <> 2)) Then
                    Dim iPartRepLevel As Integer = Me._device.GetPartRepairLevel(CInt(sender.tag.ToString))
                    If (Me.tmpManufID <> 64 AndAlso iPartRepLevel > 1) OrElse (Me.tmpManufID = 64 AndAlso iPartRepLevel > 2) Then
                        'Get Fail and Repair code if existing in map table
                        If Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then
                            If Not IsDBNull(Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Fail_ID")) Then iFailID = Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Fail_ID")
                            If Not IsDBNull(Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Repair_ID")) Then iRepairID = Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Repair_ID")
                        End If

                        If iFailID = 0 AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then iFailID = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Fail_ID")

                        'For Tracfone, Authorize to claim and part level > 1 then Set RV part to Abuse
                        If Me.tmpCustID = 2258 AndAlso Me._device.ManufWarantyClaimable = 1 And Me._device.GetPartRepairLevel(CInt(sender.tag.ToString)) > 1 AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_Number").ToString.Trim.ToLower.EndsWith("_rv") Then iFailID = 311

                        'collect Fail and Repair code
                        If iFailID = 0 Or (iRepairID = 0 AndAlso iFailID <> 311) Then If Me.CollectFailRepairCode(iFailID, iRepairID, iComplainID, sender.parent.name.ToString, CInt(sender.tag.ToString), iConsignedPart, strAddPartNo) = False Then Exit Sub

                        Me._device.FailID = iFailID
                        Me._device.RepairID = iRepairID
                        Me._device.ComplainID = iComplainID
                    ElseIf Me.tmpManufID = 64 Then 'PANTECH
                        If CInt(sender.tag.ToString) = 267 Then 'RUR - Liquid Damage
                            Me._device.FailID = 550 : Me._device.RepairID = 146 : Me._device.ComplainID = 205
                        ElseIf CInt(sender.tag.ToString) = 276 Then 'RUR - Physical Damage
                            Me._device.FailID = 549 : Me._device.RepairID = 145 : Me._device.ComplainID = 188
                        ElseIf CInt(sender.tag.ToString) = 255 Then 'No Parts
                            Me._device.FailID = 551 : Me._device.RepairID = 150 : Me._device.ComplainID = 198
                        ElseIf iPartRepLevel < 3 AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillType_ID") = 2 Then 'Cosmetic parts 
                            Me._device.FailID = 526 : Me._device.RepairID = 138 : Me._device.ComplainID = 11
                        End If
                    End If
                    '*******************************************
                End If

                'Tracfone and Touchpanel/RV_Touchpnel billcode
                If action = "add" AndAlso Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso drSelectedBillcode("BillType_ID") = 2 AndAlso (sender.tag.ToString = "1882" OrElse sender.tag.ToString = "2180") Then
                    If MessageBox.Show("Is Abuse/Cosmetic?", "Replacement Reason", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        Me._device.ComplainID = 212 'Touch Screen (COS)
                    Else
                        Me._device.ComplainID = 213 'Touch Screen Func
                    End If
                ElseIf action = "add" AndAlso Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso (Buisness.TracFone.clsMisc.IsLCDDisplayBillcodeID(Convert.ToInt32(sender.tag)) = True) Then
                    If iFailID = 311 Then
                        Me._device.ComplainID = 214 'Cosmetic LCDX
                    ElseIf iFailID > 0 AndAlso iFailID <> 311 Then
                        Me._device.ComplainID = 215 'Level 2 LCD
                    ElseIf MessageBox.Show("Is this physical/liquid damaged?", "Replacement Reason", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        Me._device.ComplainID = 214 'Cosmetic LCDX
                    Else
                        Me._device.ComplainID = 215 'Level 2 LCD
                    End If
                End If

                '**********************************************
                'Max cap:
                '1) TRACFONE don't want charge more than $80
                '2) Jabil don't want part cost more than $85
                '**********************************************
                If action = "add" Then
                    If Me.tmpCustID = 2258 Then
                        If Me._dbBERTarget = 0 Then
                            MessageBox.Show("This model does not have max cap set up.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        ElseIf Me._iTFFlatRate < 0 Then
                            MessageBox.Show("Flat rate is missing for this model. Please contact Material Department.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        ElseIf Me._objNewTech.GetTFTotalCharge(Me.tmpCustID, Me.tmpModelID, Me.tmpManufID, tmpDeviceID, Me._device.ManufWarranty, CInt(sender.tag.ToString), drSelectedBillcode("LaborLevel"), iFailID, drSelectedBillcode("PSPrice_StndCost"), Me._device.CustMarkUp, drSelectedBillcode("BillType_ID")) > Me._dbBERTarget Then
                            MessageBox.Show("Repair cost has exceed the maximum limit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        ElseIf IsDBNull(Me._drDevice("LastDateInWrty")) Then
                            MessageBox.Show("Warranty coverage date is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    ElseIf Me.tmpCustID = 2462 Then
                        If Me.vManufWrty = 0 Then
                            Dim dbTotalPartsCharge As Double = 0
                            If Not IsDBNull(Me._device.Parts.Compute("Sum(DBill_InvoiceAmt)", "")) Then dbTotalPartsCharge = Me._device.Parts.Compute("Sum(DBill_InvoiceAmt)", "")
                            dbTotalPartsCharge = dbTotalPartsCharge + (Convert.ToDouble(drSelectedBillcode("PSPrice_StndCost")) * (Convert.ToDouble(Me._device.CustMarkUp) + 1))
                            If Me._dbBERTarget = 0 Then
                                MessageBox.Show("This model does not have max cap set up.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            ElseIf dbTotalPartsCharge > _dbBERTarget Then
                                MessageBox.Show("Parts cost has exceed the maximum limit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        End If
                    End If 'customer
                End If 'add

                '********************************************************
                'COLLECT REPLACEMENT PART SERIAL NUMBER 
                'This new feature requested on 1/29/2013 By Michael Tebrinke
                '********************************************************
                If action = "add" AndAlso Me._objNewTech.IsPartSNNeeded(Me.tmpCustID, Convert.ToInt32(Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_ID"))) = True Then
                    strReplPartSN = InputBox("Please enter part's serial #:").Trim
                    If strReplPartSN.Trim.Length = 0 Then
                        MessageBox.Show("You must enter part's serial #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If
                '********************************************************

                '//March 24, 2006
                Me.Enabled = False

                dtContingent = Me._objNewTech.GetContingentBillcodes(Trim(sender.tag.ToString), tmpModelID, tmpLoc)
                If action = "remove" Then   '//turn off
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, dr1("cbill_contBillcode")) Then Me._device.DeletePart(dr1("cbill_contBillcode"))
                    Next dr1

                    If Trim(sender.tag.ToString) = 173 Then
                        If Me._device.Parts.Select("Billcode_ID = " & 756).Length > 0 Then Me._device.DeletePart(756)
                    End If
                    deleteComponent(Trim(sender.tag.ToString))
                Else    '//turn on
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeMapped(tmpModelID, dr1("cbill_contBillcode")) > 0 AndAlso PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, dr1("cbill_contBillcode")) = False Then Me._device.AddPart(dr1("cbill_contBillcode"))
                    Next dr1
                    addComponent(Trim(sender.tag.ToString), strReplPartSN)
                    ' CHECK TO SEE IF THIS IS A MESSSAGING DBR OR NER TO SET THE FLAG TO BE USED ON CLEAR_CLICK.
                    If sender.tag = 25 Or sender.tag = 89 Then
                        _IsMgsDbrOrNer = True
                    End If
                End If

                '*******************************
                Me.HighLightSelectedButtons()

                '*******************************
                'Liquidity Services Customer and Good Unit
                '*******************************
                If Me.tmpCustID = 2245 And action = "add" And sender.tag.ToString.Trim = 1309 And Me._objNewTech.GetModelUnlockCode(tmpModelID) = 1 Then
                    Me._objNewTech.UpdateLockCode(tmpDeviceID)
                End If

                '*******************************
                If Me.tmpProdID = 9 Then
                    If sender.tag.ToString.Trim = 1590 AndAlso action = "add" Then  'compact Flash
                        If Me._objNewTech.IsCFApproved(Me.tmpDeviceID) = False Then
                            Me._objNewTech.SendUnitToHold(Me.tmpDeviceID, Me.tmpProdID)
                        End If
                    Else
                        Me._objNewTech.UpdateWipOwnerID(tmpDeviceID, Me.tmpProdID, PSS.Core.ApplicationUser.IDuser, 0, , , "New Tech Billing")      'Last argument is zero because don't want system to change cc_id
                    End If
                End If

                '***************************************************
                'Populate Average parts cost information 03/17/2009
                '***************************************************
                'If Me.tmpCustID = 14 Or Me.tmpCustID = 1545 Then DisplayAvgPartsCostInfo(tmpCustID, tmpLoc, tmpModelID, tmpDeviceID, False)
                'If Me.tmpCustID = 14 Or Me.tmpCustID = 2507 Then DisplayAvgPartsCostInfo(tmpCustID, tmpLoc, tmpModelID, tmpDeviceID, False)
                'If Me.tmpCustID = 14 Or Me.tmpCustID = 2508 Then DisplayAvgPartsCostInfo(tmpCustID, tmpLoc, tmpModelID, tmpDeviceID, False)
                If Me._iSCustID = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID OrElse _
                   Me._iSCustID = PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID Then
                    DisplayAvgPartsCostInfo(tmpCustID, tmpLoc, tmpModelID, tmpDeviceID, False)
                End If

                '***************************************************

                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillCode_Rule") = 1 AndAlso Me.tmpCustID = PSS.Data.Buisness.AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID Then
                    Dim strErrMsg As String = "" : Dim objAMSInf As New Buisness.AMSInfraStructure()
                    strErrMsg = objAMSInf.AutoShip_AMS_Infrastructure(Me.tmpDeviceID, PSS.Core.ApplicationUser.IDShift)
                    If strErrMsg.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        Me.ButtonClear_ClickEvent()
                    End If
                End If

                '***************************************************
                'Tracfone: If RUR then clear all and push to Quantine
                '***************************************************
                If Me.tmpCustID = 2258 AndAlso Me._device.RUR_DBR = True AndAlso action = "add" Then
                    strNextBucket = Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, 2258, 1, )
                    If strNextBucket.Trim.Length = 0 Then strNextBucket = "BER HOLD"
                    Buisness.Generic.SetTcelloptWorkStationForDevice(strNextBucket, Me.tmpDeviceID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )
                    Me.ButtonClear_ClickEvent()
                    Me.txtSerial.Focus()
                End If
                '***************************************************

            Catch ex As Exception
                Dim strMsg As String = ex.Message
                If strMsg = "Cacceled." OrElse strMsg = "Failed to update DBR reason." _
                   OrElse strMsg = "Failed to update NER reason." Then
                    MessageBox.Show(ex.Message, "BillingButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show(ex.ToString, "BillingButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                'MessageBox.Show(ex.ToString, "BillingButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                dr1 = Nothing : Buisness.Generic.DisposeDT(dtContingent)
                '********************************
                'Reset fail and repair code ID
                '********************************
                If Not IsNothing(Me._device) Then
                    Me._device.FailID = 0 : Me._device.RepairID = 0 : Me._device.ComplainID = 0
                End If
                '********************************
            End Try
        End Sub

        '********************************************************************************
        Private Sub billingClick_AWAP(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim iFailID, iRepairID, iComplainID, iRVPart, iConsignedPart As Integer
            Dim dr1, drAddingBillcode As DataRow
            Dim x As Integer
            Dim action As String
            Dim strAddPartNo, strBilledPartNo As String
            Dim dtContingent As DataTable
            Dim booIsRVPart As Boolean = False

            Try
                strAddPartNo = "" : strBilledPartNo = "" : iFailID = 0 : iRepairID = 0 : iComplainID = 0 : iRVPart = 0 : iConsignedPart = 0

                '//Determine action to be performed
                action = "add"
                If Me._dtAWAP.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then action = "remove"

                '*********************************
                'Define Adding Part #
                '*********************************
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length = 0 Then
                    MessageBox.Show("Billcode ID is missing in billable list. Please refresh the screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    strAddPartNo = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_Number").ToString.ToLower
                    iRVPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("RVFlag")
                    If iRVPart = 1 Then booIsRVPart = True
                    iConsignedPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_ConsignedPart")
                End If

                If iRVPart > 0 Then
                    MessageBox.Show("RV part should not listed in this tab. Please contact your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf iConsignedPart > 0 Then
                    MessageBox.Show("Consigned part should not listed in this tab. Please contact your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Must remove all needed part before scrap 
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillCode_Rule") <> 0 AndAlso Me._dtAWAP.Rows.Count > 0 Then
                    MessageBox.Show("Please remove all need part(s) before select this bill code " & sender.text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                '*********************************
                If action = "add" AndAlso Me.ValidateRVOEMAndConsighnedPartSelection(strAddPartNo, CInt(Trim(sender.tag.ToString)), iRVPart, iConsignedPart) = False Then
                    '***************************************************
                    'RV, EOM and Consigned Parts validation 05/05/2011
                    '***************************************************
                    Exit Sub
                End If

                '***************************************************
                ' Collect real part and repalce with temporay part
                '***************************************************
                If action = "add" AndAlso (strAddPartNo.Trim.ToLower.Equals("temppart") = True OrElse strAddPartNo.Trim.ToLower.Equals("temppart_rv") = True) AndAlso techscreen.frmNewTech.CollectPartAndReplaceTempPartInBOM(sender.tag.ToString.Trim, booIsRVPart, Me.tmpProdID, Me.tmpModelID, Me._device) = False Then
                    Exit Sub
                End If

                '//March 24, 2006
                Me.Enabled = False

                dtContingent = Me._objNewTech.GetContingentBillcodes(Trim(sender.tag.ToString), tmpModelID, tmpLoc)
                If action = "remove" Then   '//turn off
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeExistedInAWAP(Me.tmpDeviceID, dr1("cbill_contBillcode")) Then
                            Me._objNewTech.DeleteDeviceBillAWAP(Me.tmpDeviceID, dr1("cbill_contBillcode"), Core.ApplicationUser.IDuser)
                        End If
                    Next dr1

                    Me._objNewTech.DeleteDeviceBillAWAP(Me.tmpDeviceID, Trim(sender.tag.ToString), Core.ApplicationUser.IDuser)
                Else    '//turn on
                    Dim R1 As DataRow
                    '**************************************
                    'Contigent
                    '**************************************
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeMapped(tmpModelID, dr1("cbill_contBillcode")) > 0 AndAlso PSS.Data.Buisness.Generic.IsBillcodeExistedInAWAP(Me.tmpDeviceID, dr1("cbill_contBillcode")) = False Then
                            If Me._device.BillableBillcodes.Select("Billcode_ID = " & dr1("cbill_contBillcode")).Length > 0 Then
                                R1 = Me._device.BillableBillcodes.Select(dr1("cbill_contBillcode"))(0)

                                Me._objNewTech.InsertIntoDeviceBillAWAP(Me.tmpDeviceID, R1("PSPrice_StndCost"), R1("PSPrice_AvgCost"), _
                                R1("PSPrice_StndCost"), (R1("PSPrice_StndCost") * 1.15), R1("Billcode_ID"), R1("PSPrice_Number"), _
                                1, Core.ApplicationUser.IDuser, iFailID, iRepairID, 0)
                            End If
                        End If
                    Next dr1
                    '**************************************
                    R1 = Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)
                    Me._objNewTech.InsertIntoDeviceBillAWAP(Me.tmpDeviceID, R1("PSPrice_StndCost"), R1("PSPrice_AvgCost"), _
                    R1("PSPrice_StndCost"), (R1("PSPrice_StndCost") * 1.15), R1("Billcode_ID"), R1("PSPrice_Number"), _
                    1, Core.ApplicationUser.IDuser, iFailID, iRepairID, 0)
                End If

                '*******************************
                Me._dtAWAP = Me._objNewTech.GetSelectedAWAP(tmpDeviceID)
                Me.HighLightSelectedButtons()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "billingClick_AWAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                dr1 = Nothing : Buisness.Generic.DisposeDT(dtContingent)
                '********************************
                'Reset fail and repair code ID
                '********************************
                If Not IsNothing(Me._device) Then
                    Me._device.FailID = 0 : Me._device.RepairID = 0 : Me._device.ComplainID = 0
                End If
                '********************************
            End Try
        End Sub

        '**************************************************************
        Private Function ValidateRVOEMAndConsighnedPartSelection(ByVal strAddingPartNo As String, _
                                                                 ByVal iBillcodeID As Integer, _
                                                                 ByVal iRVPart As Integer, _
                                                                 ByVal iConsignedPart As Integer) As Boolean
            Dim booReturnVal As Boolean = True
            Dim R1 As DataRow

            Try
                'No need to check if part list is empty or adding part is a services
                If Me._device.Parts.Rows.Count = 0 OrElse Me._device.GetPartTypeID(iBillcodeID) = 1 Then Return True

                ValidateRVOEMAndConsighnedPartSelection = True

                For Each R1 In Me._device.Parts.Rows
                    If iRVPart = 1 AndAlso (R1("Part_Number").ToString.Trim & "_RV").ToUpper.Equals(strAddingPartNo.Trim.ToUpper) Then
                        MessageBox.Show("An OEM part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf iConsignedPart = 1 AndAlso (R1("Part_Number").ToString.Trim & "_TT").ToUpper.Equals(strAddingPartNo.Trim.ToUpper) Then
                        MessageBox.Show("An OEM part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf (strAddingPartNo.Trim & "_RV").ToUpper.Equals(R1("Part_Number").ToString.Trim.ToUpper) Then
                        MessageBox.Show("RV part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf (strAddingPartNo.Trim & "_TT").ToUpper.Equals(R1("Part_Number").ToString.Trim.ToUpper) Then
                        MessageBox.Show("Consigned part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    End If
                Next R1
                Return booReturnVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Private Sub HighLightSelectedButtons()
            Dim i As Integer = 0

            Try
                'Panel Bill
                For i = 0 To Me.pnlBill.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlBill.Controls(i).Tag).Length > 0 Then
                        Me.pnlBill.Controls(i).ForeColor = Color.Blue
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlBill.Controls(i).Tag).Length > 0 Then Me.pnlBill.Controls(i).BackColor = Color.Lime Else Me.pnlBill.Controls(i).BackColor = Color.LightGray
                    Else
                        Me.pnlBill.Controls(i).ForeColor = Color.Black
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlBill.Controls(i).Tag).Length > 0 Then Me.pnlBill.Controls(i).BackColor = Color.Yellow Else Me.pnlBill.Controls(i).BackColor = Color.LightGray
                    End If
                Next i

                'Panel Services
                For i = 0 To Me.pnlService.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlService.Controls(i).Tag).Length > 0 Then
                        Me.pnlService.Controls(i).ForeColor = Color.Blue
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlService.Controls(i).Tag).Length > 0 Then Me.pnlService.Controls(i).BackColor = Color.Lime Else Me.pnlService.Controls(i).BackColor = Color.LightGray
                    Else
                        Me.pnlService.Controls(i).ForeColor = Color.Black
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlService.Controls(i).Tag).Length > 0 Then Me.pnlService.Controls(i).BackColor = Color.Yellow Else Me.pnlService.Controls(i).BackColor = Color.LightGray
                    End If
                Next i

                'pnlFuncParts
                For i = 0 To Me.pnlFuncParts.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlFuncParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlFuncParts.Controls(i).ForeColor = Color.Blue
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlFuncParts.Controls(i).Tag).Length > 0 Then Me.pnlFuncParts.Controls(i).BackColor = Color.Lime Else Me.pnlFuncParts.Controls(i).BackColor = Color.LightGray
                    Else
                        Me.pnlFuncParts.Controls(i).ForeColor = Color.Black
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlFuncParts.Controls(i).Tag).Length > 0 Then Me.pnlFuncParts.Controls(i).BackColor = Color.Yellow Else Me.pnlFuncParts.Controls(i).BackColor = Color.LightGray
                    End If
                Next i

                'pnlRVParts
                For i = 0 To Me.pnlRVParts.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlRVParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlRVParts.Controls(i).ForeColor = Color.Blue
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlRVParts.Controls(i).Tag).Length > 0 Then Me.pnlRVParts.Controls(i).BackColor = Color.Lime Else Me.pnlRVParts.Controls(i).BackColor = Color.LightGray
                    Else
                        Me.pnlRVParts.Controls(i).ForeColor = Color.Black
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlRVParts.Controls(i).Tag).Length > 0 Then Me.pnlRVParts.Controls(i).BackColor = Color.Yellow Else Me.pnlRVParts.Controls(i).BackColor = Color.LightGray
                    End If
                Next i

                'pnlRVFParts
                For i = 0 To Me.pnlRVFParts.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlRVFParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlRVFParts.Controls(i).ForeColor = Color.Blue
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlRVFParts.Controls(i).Tag).Length > 0 Then Me.pnlRVFParts.Controls(i).BackColor = Color.Lime Else Me.pnlRVFParts.Controls(i).BackColor = Color.LightGray
                    Else
                        Me.pnlRVFParts.Controls(i).ForeColor = Color.Black
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlRVFParts.Controls(i).Tag).Length > 0 Then Me.pnlRVFParts.Controls(i).BackColor = Color.Yellow Else Me.pnlRVFParts.Controls(i).BackColor = Color.LightGray
                    End If
                Next i

                'pnlAccessories
                For i = 0 To Me.pnlAccessories.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlAccessories.Controls(i).Tag).Length > 0 Then
                        Me.pnlAccessories.Controls(i).ForeColor = Color.Blue
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlAccessories.Controls(i).Tag).Length > 0 Then Me.pnlAccessories.Controls(i).BackColor = Color.Lime Else Me.pnlAccessories.Controls(i).BackColor = Color.LightGray
                    Else
                        Me.pnlAccessories.Controls(i).ForeColor = Color.Black
                        If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._dtAWAP.Select("Billcode_ID = " & Me.pnlAccessories.Controls(i).Tag).Length > 0 Then Me.pnlAccessories.Controls(i).BackColor = Color.Yellow Else Me.pnlAccessories.Controls(i).BackColor = Color.LightGray
                    End If
                Next i

                'pnlNeededAccessories
                For i = 0 To Me.pnlNeededAccessories.Controls.Count - 1
                    If Me._dtAWAP.Select("Billcode_ID = " & Me.pnlNeededAccessories.Controls(i).Tag).Length > 0 Then
                        Me.pnlNeededAccessories.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlNeededAccessories.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                'pnlNeededParts
                For i = 0 To Me.pnlNeededParts.Controls.Count - 1
                    If Me._dtAWAP.Select("Billcode_ID = " & Me.pnlNeededParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlNeededParts.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlNeededParts.Controls(i).ForeColor = Color.Black
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**************************************************************
        Private Sub frmNewTech_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me._objNewTech = New PSS.Data.Buisness.NewTech()
                origFrmWidth = Me.Width
                txtSerial.Focus()
                tmpBinLoc = getBinLoc()
                btnComplete.Visible = False
                '2258 is TracFone customer ID
                If Me._iSCustID = 2258 AndAlso Me._iBillType = 2 Then Me.btnComplete.Text = "Complete Refurbished"
                If Me._iSCustID = 2258 AndAlso Me._bAllowSoftwareProcess Then
                    'Do nothing, Keep Software process available
                Else
                    Me.tabMain.TabPages.Remove(tbSW)
                End If

                Me.lblScreenName.Text = Me._strScreenName

                'Me.lblATT.Size = New System.Drawing.Size(208, 16)
                'Me.lblCustName.Size = New System.Drawing.Size(336, 16)
                'Me.lblScreenName.Size = New System.Drawing.Size(208, 16)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmNewTech_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub frmNewTech_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

            colCount = 0

            btnLeft = hBuffer
            btnTop = vBuffer

            formDiffWidth += Me.Width - origFrmWidth

            Dim x As Integer
            Dim tmpBtn As System.Windows.Forms.Button
            For x = 0 To pnlBill.Controls.Count - 1
                tmpBtn = CType(pnlBill.Controls(x), System.Windows.Forms.Button)
                With tmpBtn
                    .Location = New Point(btnLeft, btnTop)
                End With

                colCount += 1
                If colCount > 6 Then
                    'If btnTop + btnHeight + 120 > pnlBill.Height Then
                    btnLeft = btnLeft + btnWidth + 5
                    btnTop = vBuffer
                    colCount = 0
                Else
                    btnTop = btnTop + btnHeight + 5
                End If

            Next

            btnLeft = hBuffer
            btnTop = vBuffer

            For x = 0 To pnlService.Controls.Count - 1
                tmpBtn = CType(pnlService.Controls(x), System.Windows.Forms.Button)
                With tmpBtn
                    .Location = New Point(btnLeft, btnTop)
                End With

                colCount += 1
                If colCount > 6 Then
                    'If btnTop + btnHeight + 120 > pnlService.Height Then
                    btnLeft = btnLeft + btnWidth + 5
                    btnTop = vBuffer
                    colCount = 0
                Else
                    btnTop = btnTop + btnHeight + 5
                End If
            Next
        End Sub

        '**************************************************************
        Private Sub lblSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSelected.Click
            If lblSelected.Text = "SHOW SELECTED" Then
                tabMain.Visible = False
                gridBilling.Visible = True
                lblSelected.Text = "RETURN"
                If Me.tmpCustID = Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    PopulateBillingSelectionGrid(Me.tmpDeviceID, Me.tmpCustID)
                End If
            Else
                tabMain.Visible = True
                gridBilling.Visible = False
                lblSelected.Text = "SHOW SELECTED"
                Me.txtSerial.Focus()
            End If
        End Sub

        '*********************************************************************************************
        Private Sub addComponent(ByVal valBillCode As Integer, ByVal strPartSerialNo As String)
            Dim iUpdateDBRCode, iInvoiceYrMonth As Integer
            Dim dteToday As DateTime = Nothing

            Try
                iUpdateDBRCode = 0 : iInvoiceYrMonth = 0
                '*************************************************
                '//Added by Asif
                'If (tmpCustID = 1 OrElse tmpCustID = 14 OrElse tmpCustID = PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID OrElse tmpCustID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse tmpCustID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse tmpCustID = 444 OrElse tmpCustID = Buisness.SkyTel.CookPager_CUSTOMER_ID) AndAlso CInt(Trim(valBillCode)) = 25 Then
                If (tmpCustID = 1 OrElse tmpCustID = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID OrElse _
                    tmpCustID = PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID OrElse _
                    tmpCustID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse _
                    tmpCustID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse _
                    tmpCustID = PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.CookPager_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.CriticalAlert_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Anna_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Lahey_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Masco_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Franciscan_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Maine_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.SMHC_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.ATS_CUSTOMER_ID) AndAlso CInt(Trim(valBillCode)) = 25 Then
                    iUpdateDBRCode = ShowDBRReasonScreen(True, True)       'DBR
                    If iUpdateDBRCode = 0 Then
                        Throw New Exception("Failed to update DBR reason.")
                    ElseIf iUpdateDBRCode = -999999 Then
                        Throw New Exception("Cacceled.")
                    End If
                    'ElseIf (tmpCustID = 1 OrElse tmpCustID = 14 OrElse tmpCustID = PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID OrElse tmpCustID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse tmpCustID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse tmpCustID = 444 OrElse tmpCustID = Buisness.SkyTel.CookPager_CUSTOMER_ID) AndAlso CInt(Trim(valBillCode)) = 89 Then
                ElseIf (tmpCustID = 1 OrElse tmpCustID = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID OrElse _
                        tmpCustID = PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID OrElse _
                        tmpCustID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse _
                        tmpCustID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse _
                        tmpCustID = PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.CookPager_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.CriticalAlert_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.Anna_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.Lahey_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.Masco_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.Franciscan_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.Maine_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.SMHC_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID OrElse _
                        tmpCustID = Buisness.SkyTel.ATS_CUSTOMER_ID) AndAlso CInt(Trim(valBillCode)) = 89 Then
                    iUpdateDBRCode = ShowDBRReasonScreen(False, True)       'NER
                    If iUpdateDBRCode = 0 Then
                        Throw New Exception("Failed to update NER reason.")
                    ElseIf iUpdateDBRCode = -999999 Then
                        Throw New Exception("Cacceled.")
                    End If
                End If

                '*************************************************
                'Get Part Data Information
                If valBillCode > 0 Then
                    If Me.tmpCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        dteToday = CDate(Buisness.Generic.MySQLServerDateTime(1))
                        iInvoiceYrMonth = CInt(dteToday.Year & dteToday.Month.ToString("00"))
                    End If
                    _device.AddPart(valBillCode, , strPartSerialNo)
                    _device.Update(iInvoiceYrMonth)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub deleteComponent(ByVal valBillCode As Integer)
            Dim iInvoiceYrMonth As Integer = 0
            Dim dteToday As DateTime = Nothing

            Try
                '*************************************************
                '//Added by Asif
                'If (tmpCustID = 1 OrElse tmpCustID = 14 OrElse tmpCustID = PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID OrElse tmpCustID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse tmpCustID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse tmpCustID = 444 OrElse tmpCustID = Buisness.SkyTel.CookPager_CUSTOMER_ID) AndAlso CInt(Trim(valBillCode)) = 25 Then
                If (tmpCustID = 1 OrElse tmpCustID = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID OrElse _
                    tmpCustID = PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID OrElse _
                    tmpCustID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse _
                    tmpCustID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse _
                    tmpCustID = PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.CookPager_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.CriticalAlert_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Anna_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Lahey_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Masco_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Franciscan_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.Maine_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.SMHC_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID OrElse _
                    tmpCustID = Buisness.SkyTel.ATS_CUSTOMER_ID) AndAlso CInt(Trim(valBillCode)) = 25 Then
                    Dim objDeviceBilling As New PSS.Data.Buisness.DeviceBilling()
                    objDeviceBilling.UnShipMessDBR(tmpDeviceID)
                    objDeviceBilling.DeleteDBRCode(tmpDeviceID)
                    objDeviceBilling = Nothing
                End If

                If valBillCode > 0 Then
                    If Me.tmpCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        dteToday = CDate(Buisness.Generic.MySQLServerDateTime(1))
                        iInvoiceYrMonth = CInt(dteToday.Year & dteToday.Month.ToString("00"))
                    End If

                    _device.DeletePart(valBillCode)
                    _device.Update(iInvoiceYrMonth)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub createCustDataTable(ByVal vCustomer As Integer, ByVal vModel As Integer)
            Try
                If Not IsNothing(Me.dtCustomerSet) Then Me.dtCustomerSet.Clear()
                dtCustomerSet = PSS.Data.Production.tbillmap.GetCustomerSet(vCustomer, vModel)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            '*************************************
            ' Added by Lan on 10/19/2007.
            ' Get Prebill data.
            '*************************************
            Dim iIsDevHaspart As Integer = 0
            Dim booUpdateTechInfo As Boolean = True

            If Trim(Me.txtSerial.Text) <> "" And Me.tmpDeviceID > 0 Then
                Try
                    If Me.tmpCustID <> 2253 AndAlso Not (Me.tmpProdID = 9 AndAlso Me._device.Parts.Select("[Billcode_ID] = 1590").Length > 0) Then
                        If Me.tmpCustID = 2258 Then booUpdateTechInfo = False 'don't update tech data for Tracfone Customer
                        If tmpProdID = 1 Then
                            ' FOR MESSAGING SEND THE MSG DBR OR NER FLAG.
                            Me._objNewTech.UpdateWipOwnerID(tmpDeviceID, Me.tmpProdID, PSS.Core.ApplicationUser.IDuser, Me._iDeviceWipOwner, booUpdateTechInfo, _IsMgsDbrOrNer, "New Tech Billing")
                        Else
                            Me._objNewTech.UpdateWipOwnerID(tmpDeviceID, Me.tmpProdID, PSS.Core.ApplicationUser.IDuser, Me._iDeviceWipOwner, booUpdateTechInfo, , "New Tech Billing")
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "Send Device to WaitingPart", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End Try
            End If
            '*************************************
            Me._IsSNReady = False

            Me.ButtonClear_ClickEvent()
            Me.txtSerial.Focus()
        End Sub

        '*********************************************************************************************
        Private Sub ButtonClear_ClickEvent()
            Me.txtSerial.Enabled = True
            Me.lblATT.Text = ""
            Me.pnlBill.BackColor = Me.BackColor
            Me.pnlService.Controls.Clear()
            Me.pnlBill.Controls.Clear()
            Me.pnlScrap.Controls.Clear()
            Me.pnlFuncParts.Controls.Clear()
            Me.pnlRVParts.Controls.Clear()
            Me.pnlRVFParts.Controls.Clear()
            Me.pnlAccessories.Controls.Clear()
            Me.chklstReflowBillcodes.DataSource = Nothing
            Me.chklstReflowBillcodes.Visible = False
            txtTray.Text = ""
            txtSerial.Text = ""

            Me.gridBilling.DataSource = Nothing
            Me.gridBilling.Visible = False

            Me.tmpDeviceID = 0
            Me.tmpModelID = 0
            Me.tmpManufID = 0
            Me.tmpProdID = 0
            Me.tmpTrayID = 0
            Me.tmpWO = 0
            Me._iDeviceWipOwner = 0

            btnComplete.Visible = False
            btnCompleteRepair.Visible = False
            '//reset the bill tray feature

            tabMain.Visible = True
            lblSelected.Text = "SHOW SELECTED"
            Me.lblAPCGoal.Text = ""
            Me.lblUnitPartsCost.Text = ""
            Me.lblDailyAPC.Text = ""
            Me.lblAPCGoal.Visible = False
            Me.lblUnitPartsCost.Visible = False
            Me.lblDailyAPC.Visible = False
            Me.lblRFResult.Text = ""
            Me.lblQCResult.Text = ""
            Me.lblRejectReason.Text = ""
            Me.lblReflowFailDesc.Text = ""
            Me.lblReflowRepDesc.Text = ""

            'Clear global variable
            'class
            If Not IsNothing(Me._device) Then
                Me._device.Dispose()
                Me._device = Nothing
            End If

            'data table
            PSS.Data.Buisness.Generic.DisposeDT(Me.dtCustomerSet)
            PSS.Data.Buisness.Generic.DisposeDT(Me._dtAWAP)

            rPresent = Nothing
            _drPreBillData = Nothing
            _drCelloptData = Nothing
            _drDevice = Nothing
            Me.btnCompleteRepair.Enabled = True

            Me.lblWarrantyStatus.Text = "" : Me.lblWarrantyStatus.Visible = False

            Me.lblTestResult_Triage.Text = ""
            Me.lblTestResult_RF1.Text = ""
            Me.lblTestResult_RF2.Text = ""
            Me.lblTestResult_QC.Text = ""
            Me.lblTechNotesUpdDate.Text = ""
            Me.txtTechNotes.Text = ""

            Me.gbTechFailureCodes.Visible = False
            Me.cboCodes.DataSource = Nothing
            Me.lstFailCodes.DataSource = Nothing

            _IsMgsDbrOrNer = False

            txtSerial.Focus()
        End Sub

        Private Function verifySerialNumberTray(ByVal mDeviceSN As String, ByVal mTray As String) As Long
            Try
                Dim dRec As New PSS.Data.Production.tdevice()
                Dim tRec As DataTable = dRec.GetDataTableBySNTray(mDeviceSN, mTray)
                Dim r As DataRow

                If tRec.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0           'send trigger to display error message
                ElseIf tRec.Rows.Count > 1 Then    'If more than 1 record is returned then 
                    Return 2           'send trigger to display tray textbox
                Else
                    r = tRec.Rows(0)
                    Return r("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Private Function getBinLoc() As String
            Dim filename As String = "C:\Documents and Settings\All Users\BinLoc.txt"
            If File.Exists(filename) Then
                Dim stream As StreamReader
                stream = New StreamReader(filename)
                getBinLoc = stream.ReadToEnd
            Else
                getBinLoc = "NO BIN"
            End If

            Return getBinLoc
        End Function

        '**************************************************************
        Private Function ShowDBRReasonScreen(ByVal bIsDBR As Boolean, ByVal bIsAMS As Boolean) As Integer
            Dim objDBR As New Billing.frmDBRReason()
            Dim i As Integer = 0
            Try
                With objDBR
                    .CustID = tmpCustID
                    .DeviceID = tmpDeviceID
                    .IsAMS = bIsAMS
                    If Not bIsDBR Then    'NER
                        .IsDBR = False
                        .HeaderLabel = "NER Reason"
                    Else
                        .IsDBR = True
                        .HeaderLabel = "DBR Reason"
                    End If
                    .ShowDialog()

                    'Update the DB with the selected DBR reason
                    If objDBR.DBRCode > 0 Then
                        i = .UPD
                    Else
                        i = objDBR.DBRCode       '0 = not selected, or  -999999 = Canceled
                    End If
                End With

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDBR) Then
                    objDBR.Dispose() : objDBR = Nothing
                End If
            End Try
        End Function

        Private Function validateDeviceMachineGroup(ByVal mDeviceID) As Boolean
            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable
            Dim r As DataRow
            Dim strSQL As String
            Dim strMachineShort As String
            Dim errMsg As String = ""
            Dim tmpMachineName As String
            Dim lMachineGroup, lDeviceGroup, lWIPGroup As Long

            Try
                '//This is new August 29, 2006
                If tmpDeviceType = 1 Then Return True

                '//Get machine name
                tmpMachineName = System.Net.Dns.GetHostName

                If IsNothing(tmpMachineName) = True Then
                    tmpMachineName = ""
                    errMsg += "Machine name not assigned in environmental variables." & vbCrLf
                    MsgBox(errMsg, MsgBoxStyle.OKOnly, "ERROR")
                    Return False
                ElseIf Me._objNewTech.GetMachineCount(tmpMachineName) = 0 Then
                    Return False
                Else
                    lMachineGroup = Me._objNewTech.GetMachineGroupID(tmpMachineName)
                    lDeviceGroup = Me._objNewTech.GetDeviceGroupID(mDeviceID)

                    If lMachineGroup = 0 Then
                        errMsg = ""
                        errMsg += "The machine name is not defined in lwclocation."
                        MsgBox(errMsg, MsgBoxStyle.OKOnly, "ERROR")
                        Return False
                    ElseIf lDeviceGroup = 0 Then
                        errMsg = ""
                        errMsg += "The group number for this device is invalid."
                        MsgBox(errMsg, MsgBoxStyle.OKOnly, "ERROR")
                        Return False
                    End If
                End If

                Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Private Sub RemoveAllBillCodes(ByVal vDeviceID As Long)
        '    Dim strSQL As String
        '    Dim dt As PSS.Data.Production.Joins
        '    Dim dtSelect As DataTable
        '    Dim xCount As Integer = 0
        '    Dim rSelect As DataRow
        '    Dim blnPartsDelete As Boolean
        '    Dim blnPartTrans As Boolean

        '    Dim x As Integer = 0
        '    Dim dr1 As DataRow

        '    If vDeviceID > 0 Then
        '        For x = 0 To dtBill.Rows.Count - 1
        '            dr1 = dtBill.Rows(x)
        '            If dr1("Bill ID") > 0 Then
        '                deleteComponent(Trim(dr1("Bill ID")))
        '            End If
        '        Next

        '        For x = dtBill.Rows.Count - 1 To 0 Step -1
        '            dr1 = dtBill.Rows(x)
        '            If dr1("Bill ID") > 0 Then
        '                dtBill.Rows(x).Delete()
        '            End If
        '        Next

        '        Dim zCount As Integer = 0
        '        For zCount = 0 To Me.pnlService.Controls.Count - 1
        '            Me.pnlService.Controls(zCount).ForeColor = Color.Black
        '        Next
        '        For zCount = 0 To Me.pnlBill.Controls.Count - 1
        '            Me.pnlBill.Controls(zCount).ForeColor = Color.Black
        '        Next
        '    End If

        '    Exit Sub

        '    If vDeviceID > 0 Then
        '        strSQL = "SELECT DBill_ID FROM tdevicebill where device_id = " & vDeviceID
        '        dtSelect = dt.OrderEntrySelect(strSQL)

        '        For xCount = 0 To dtSelect.Rows.Count - 1
        '            rSelect = dtSelect.Rows(xCount)
        '            If rSelect("Dbill_ID") > 0 Then
        '                Try
        '                    '//Commented OUT August 15, 2007 - this is called from AddPart in Device Class
        '                    'blnPartTrans = setPartTransaction(vDeviceID, rSelect("DBill_ID"), tmpDeviceType, tmpID, tmpBinLoc, -1, 0, tmpEmployee, tmpShift)
        '                    System.Windows.Forms.Application.DoEvents()
        '                    strSQL = "DELETE FROM tpartscodes WHERE DBill_ID = " & rSelect("DBill_ID")
        '                    blnPartsDelete = dt.OrderEntryUpdateDelete(strSQL)
        '                Catch ex As Exception
        '                    MsgBox(ex.ToString)
        '                End Try
        '            End If
        '        Next

        '        Try
        '            strSQL = "DELETE FROM tdevicebill where device_id = " & vDeviceID
        '            Dim blnAction As Boolean = dt.OrderEntryUpdateDelete(strSQL)
        '        Catch ex As Exception
        '            MsgBox(ex.ToString)
        '        End Try

        '        _device = Nothing
        '        Me.LoadDevice()
        '    End If
        'End Sub

        '*********************************************************************************************
        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim iTestTypeID As Integer = 7
            Dim blnComplete As Boolean
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Dim strNextStation As String = ""
            Dim iRework As Integer = 1
            Dim i, iMaxBillcodeRule As Integer
            Dim strNextWrkStation As String = ""
            Dim dialogMsg As Windows.Forms.DialogResult

            Try
                Me.Enabled = False : i = 0 : iMaxBillcodeRule = 0

                If Me.txtSerial.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf tmpDeviceID = 0 Then
                    MsgBox("This device can not be identified. Can NOT complete.", MsgBoxStyle.Exclamation, "ERROR")
                    Me.txtSerial.SelectAll()
                    Me.txtSerial.Focus()
                    Exit Sub
                ElseIf Me.tmpCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso Me._device.Parts.Rows.Count = 0 Then
                    MessageBox.Show("Can not complete this unit without billing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerial.Focus()
                    Exit Sub
                ElseIf Me.tmpCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID AndAlso Me._device.Parts.Rows.Count = 0 Then
                    MessageBox.Show("Can not complete this unit without billing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerial.Focus()
                    Exit Sub
                    'Added By Amazech-Thanga 07.08.2021
                ElseIf Me.tmpCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID AndAlso Me._device.Parts.Rows.Count = 0 Then
                    MessageBox.Show("Can not complete this unit without billing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerial.Focus()
                    Exit Sub
                    'Added By Amazech-Thanga 07.09.2021
                ElseIf Me.tmpCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID AndAlso Me._device.Parts.Rows.Count = 0 Then
                    MessageBox.Show("Can not complete this unit without billing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerial.Focus()
                    Exit Sub
                Else
                    Me.lblATT.Visible = False : Me.pnlBill.BackColor = Me.BackColor

                    'Hung 11/23/2011 update Syxdata status 
                    If Me.tmpCustID = PSS.Data.Buisness.Syx.CUSTOMERID Then

                        Dim objSyx As New PSS.Data.Buisness.Syx()
                        iMaxBillcodeRule = PSS.Data.Buisness.Generic.GetMaxBillRule(tmpDeviceID)
                        If iMaxBillcodeRule = 1 Then
                            objSyx.UpdateSyxStatus(Me.tmpDeviceID, "Scrap")
                        Else
                            Dim frmSyxDataStatus As New Gui.SyxDataStatus(2, False)
                            frmSyxDataStatus.ShowDialog()
                            objSyx.UpdateSyxStatus(Me.tmpDeviceID, frmSyxDataStatus._strStatus)
                        End If
                    ElseIf Me.tmpCustID = PSS.Data.Buisness.AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID Then
                        If MessageBox.Show("Are you sure you want to complete this device?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                        Dim strErrMsg As String = "" : Dim objAMSInf As New Buisness.AMSInfraStructure()
                        strErrMsg = objAMSInf.AutoShip_AMS_Infrastructure(Me.tmpDeviceID, PSS.Core.ApplicationUser.IDShift)
                        If strErrMsg.Trim.Length > 0 Then
                            MessageBox.Show(strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        Else
                            Me.ButtonClear_ClickEvent() : Exit Sub
                        End If
                    End If

                    'tmpProdID = 2 and not WIKO=========================================================================================================================
                    'added by Amazech-Thanga 07.08.2021
                    If tmpProdID = 2 AndAlso Not Me.tmpCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID AndAlso Not Me.tmpCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID AndAlso Not Me.tmpCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        'COLLECT MOTOROLA WARRANTY CLAIM DATA
                        If tmpManufID = 1 Then CollectMotorolaClaimInfo()

                        ''//GetMachineGroup
                        'If Me._iDeviceGrpID <> 2 And _iDeviceGrpID <> 3 And _iDeviceGrpID <> 4 And _iDeviceGrpID <> 79 Then
                        '    MsgBox("You are trying to complete a device from outside the cellular line or the machine may not be mapped. This can not be done.", MsgBoxStyle.Information, "Outside Tech Line")
                        '    Exit Sub
                        'End If

                        If MsgBox("This device can not be modified after this is selected. Continue?", MsgBoxStyle.YesNo, "Device Completion") = MsgBoxResult.Yes Then
                            If Me.tmpCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                                '***********************************************
                                'Get and assign unit to workstation for TracFone
                                '***********************************************
                                If Me._objNewTech.GetTFTotalCharge(Me.tmpCustID, Me.tmpModelID, Me.tmpManufID, Me.tmpDeviceID, Me._device.ManufWarranty, 0, 0, 0, 0, 0, 0) > Me._dbBERTarget Then
                                    MessageBox.Show("Total fee for this device to repair has exceed the maximum limit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If
                                iMaxBillcodeRule = PSS.Data.Buisness.Generic.GetMaxBillRule(tmpDeviceID)
                                If iMaxBillcodeRule < 0 Then
                                    MessageBox.Show("Bill rule is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Me.txtSerial.Focus()
                                    Exit Sub
                                ElseIf iMaxBillcodeRule = 0 Then
                                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 0)
                                Else
                                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 1)
                                End If
                                If strNextWrkStation.Trim.Length > 0 Then
                                    If Me._iBillType = 1 AndAlso Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, 1624) = True Then strNextWrkStation = "LABEL"
                                    PSS.Data.Buisness.Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, tmpDeviceID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )
                                    MessageBox.Show("This unit now belongs to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                                '***********************************************
                                'Write Refurbished completed record
                                '***********************************************
                                If Me._iBillType = 1 Then iTestTypeID = 12 Else iTestTypeID = 13
                                If iTestTypeID > 0 Then
                                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                                    i = objTFMisc.WriteTestResult(Me.tmpDeviceID, iTestTypeID, PSS.Core.Global.ApplicationUser.IDuser, 0, iRework, , , , , , , PSS.Data.Buisness.Generic.GetMachineCostCenterID())
                                End If
                            ElseIf Me.tmpCustID = 2453 AndAlso Me.vManufWrty = 0 AndAlso Me._device.Parts.Rows.Count = 0 Then       'PANTECH
                                MsgBox("Can't complete without any part/service.", MsgBoxStyle.Information, "Cancelled")
                                Exit Sub
                            End If

                            '***********************************************
                            '//Complete the process only on CELLULAR PRODUCT
                            '***********************************************
                            If Me.tmpProdID = 2 AndAlso Me._iBillType = 2 Then blnComplete = completeDevice()
                            '***********************************************
                            '//Set Waiting for part WIP OWNER 
                            '***********************************************
                            If Me._iBillType = 3 AndAlso Buisness.Generic.IsDeviceHadParts(Me.tmpDeviceID) = True Then
                                Dim objMis As New Buisness.Misc()
                                If Me.tmpCustID = 2453 AndAlso Me.vManufWrty = 0 Then
                                    'put OW unit on hold, customer service will contact customer to get approve
                                    objMis.UpdtWipOwner(Me.tmpDeviceID, 6)
                                Else
                                    objMis.UpdtWipOwner(Me.tmpDeviceID, 8)
                                End If
                            End If
                            '***********************************************
                            Me.ButtonClear_ClickEvent()
                            txtSerial.Focus()
                        Else
                            '//Cancel the process
                            MsgBox("The completion process has been cancelled.", MsgBoxStyle.Information, "Cancelled") : Exit Sub
                        End If
                    End If    'tmpProdID = 2 and not WIKO========================================================================================================================

                    'WIKO,Vivint,WingTechATT,Vinsmart
                    If Me.tmpCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID OrElse Me.tmpCustID = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID OrElse Me.tmpCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID OrElse Me.tmpCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        If MsgBox("This device can not be modified after this is selected. Continue?", MsgBoxStyle.YesNo, "Device Completion") = MsgBoxResult.Yes Then

                            If Me.tmpCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.WIKO.WIKO.WIKO_Label_WorkStation.Trim.ToUpper
                            If Me.tmpCustID = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.VV.Vivint.Vivint_Label_WorkStation.Trim.ToUpper
                            If Me.tmpCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Label_WorkStation.Trim.ToUpper
                            If Me.tmpCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then strNextWrkStation = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Label_WorkStation.Trim.ToUpper
                            If strNextWrkStation.Trim.Length > 0 Then
                                PSS.Data.Buisness.Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, tmpDeviceID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )
                                MessageBox.Show("This unit now belongs to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                            blnComplete = completeDevice()

                            Me.ButtonClear_ClickEvent()
                            txtSerial.Focus()
                        Else
                            '//Cancel the process
                            MsgBox("The completion process has been cancelled.", MsgBoxStyle.Information, "Cancelled") : Exit Sub
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Me._IsSNReady = False

                objTFMisc = Nothing
                Me.txtSerial.Focus()
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub CollectMotorolaClaimInfo()
            '*******************************************************************
            'Check if the Motorola MCliam data needs to be collected.
            'Added by LAN on 1/1/2007 11:28 AM
            '*******************************************************************
            Dim objMClaims As New PSS.Data.Buisness.WarrantyClaim.MClaim()
            Dim iSendMClaimFlg As Integer = 0
            Dim iBillcodeFlag As Integer = 0
            Dim booVar As Boolean = False

            Try
                iSendMClaimFlg = objMClaims.GetSendMotorolaClaimFlg
                If iSendMClaimFlg = 1 Then
                    booVar = objMClaims.CheckIfMotorolaMClaimDataNeeded(tmpDeviceID, Trim(Me.txtSerial.Text))

                    If booVar = True Then
                        iBillcodeFlag = objMClaims.BillcodeFlag
                        Dim frmMClaimData As New frmCollectMClaimData(tmpDeviceID, iBillcodeFlag)
                        frmMClaimData.ShowDialog()
                        booVar = frmMClaimData.ReturnFlag
                        If booVar = False Then
                            MessageBox.Show("This device is not COMPLETED because Motorola MClaim Data was not input.", "MClaim Data Collection", MessageBoxButtons.OK)
                            frmMClaimData.Dispose()
                            frmMClaimData = Nothing
                            Exit Sub
                        End If
                        If Not IsNothing(frmMClaimData) Then
                            frmMClaimData.Dispose()
                            frmMClaimData = Nothing
                        End If
                    End If
                End If
                '*******************************************************************
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                Exit Sub
            Finally
                objMClaims = Nothing
            End Try
        End Sub

        '*********************************************************************************************
        Private Function completeDevice() As Boolean
            Dim iCompleteLine, iQCReject As Integer
            Dim blnUpdate, blnJournal, booUpdateTechInfo As Boolean

            Try
                completeDevice = False

                If tmpDeviceID > 0 Then
                    iCompleteLine = 0 : iQCReject = 0 : booUpdateTechInfo = False

                    If Not IsDBNull(Me._drCelloptData("CellOpt_QCReject")) Then
                        iQCReject = Me._drCelloptData("CellOpt_QCReject")
                    End If

                    If IsDBNull(Me._drCelloptData("CellOpt_TechAssigned")) Then
                        booUpdateTechInfo = True
                    ElseIf CInt(Me._drCelloptData("CellOpt_TechAssigned")) = 0 Then
                        booUpdateTechInfo = True
                    End If

                    iCompleteLine = Me._objNewTech.GetMachineMapLineID()

                    Me._objNewTech.UpdateRefurbCompletedData(Me.tmpDeviceID, iQCReject, PSS.Core.ApplicationUser.IDuser, iCompleteLine, booUpdateTechInfo)

                    If iQCReject = 2 Then
                        '//Write a Journal Entry
                        blnJournal = makeCelloptJournalEntry(PSS.Core.Global.ApplicationUser.NumberEmp, iCompleteLine, "REJECTED DEVICE HAS BEEN COMPLETED", iQCReject, tmpDeviceID)
                        Return blnJournal
                    End If

                    Return True
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************
        Private Function makeCelloptJournalEntry(ByVal mEmpNum As String, ByVal mLine As String, ByVal strEntryText As String, ByVal mQCReject As Integer, ByVal mDeviceID As Long) As Boolean
            Dim ds As PSS.Data.Production.Joins
            Dim blnInsert As Boolean = False
            Dim strSQL As String = ""

            If Len(Trim(mEmpNum)) > 0 And Len(Trim(strEntryText)) > 0 And mDeviceID > 0 Then
                Try
                    strSQL = "INSERT INTO tcellopt_techjournal " & _
                    "(EntryDate, " & _
                    "EmpNum, " & _
                    "Line_ID, " & _
                    "Entry, " & _
                    "QCReject, " & _
                    "Device_ID) " & _
                    "VALUES " & _
                    "(now(), " & _
                    mEmpNum & ", " & _
                    mLine & ", " & _
                    "'" & strEntryText & "', " & _
                    mQCReject & ", " & _
                    mDeviceID & ")"

                    blnInsert = ds.OrderEntryUpdateDelete(strSQL)

                    Return blnInsert
                Catch ex As Exception
                    Return blnInsert
                Finally
                    ds = Nothing
                End Try
            End If
        End Function

        '*********************************************************************************************
        Private Sub txtLotNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLotNum.KeyPress
            ' Since the lot number text box is enabled, make sure no one can edit the lot number value.
            e.Handled = True
        End Sub

        '*********************************************************************************************
        Private Function BillingClickValidate(ByVal iCust_ID As Integer, _
                   ByVal strAction As String, _
                   ByVal iBillcode_ID As Integer) As Boolean
            Dim booResult As Boolean = True

            Try
                If iCust_ID = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID OrElse _
                   iCust_ID = PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID Then
                    booResult = Me.BillingClickValidate_AMS(strAction, iBillcode_ID)
                ElseIf iCust_ID = 2242 Then
                    booResult = Me.BillingClickValidate_Sonitrol()
                ElseIf iCust_ID = 2219 Then    'Gamestop
                    If strAction = "ADD" AndAlso Me._device.Parts.Rows.Count >= 1 Then
                        MessageBox.Show("You are not allow to bill more than one part/service.", "BillingClickValidate", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        booResult = False
                    End If
                ElseIf Me.tmpProdID = PSS.Data.Buisness.DriveCam.PRODID Then
                    booResult = Me.BillingClickValidate_DriveCam(strAction, iBillcode_ID)
                ElseIf Me.tmpManufID = 64 Then
                    booResult = Me.BillingClickValidate_PantechManuf(strAction, iBillcode_ID)

                End If
                Return booResult
            Catch ex As Exception
                BillingClickValidate = False
                MessageBox.Show(ex.Message, "BillingClickValidate_AMS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '*********************************************************************************************
        Private Function BillingClickValidate_PantechManuf(ByVal strAction As String, _
                    ByVal iBillCode_ID As Integer) As Boolean
            Dim booResult As Boolean = False

            Try
                'If strAction.ToLower = "add" AndAlso Me.tmpManufID = 64 AndAlso Me._iBillType <> 3 AndAlso _drCelloptData("HasPreBillLot").ToString = "0" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillCode_ID.ToString & " AND BillType_ID = 2").Length > 0 Then
                '    '**********************************************************************
                '    'Added on 2011-06-23 All Pantech Unit have to go through Pre-bill Lot
                '    '**********************************************************************
                '    MessageBox.Show("All Pantech devices must go through pre-bill lot.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Me.ButtonClear_ClickEvent()
                'Else
                If strAction.ToLower = "add" AndAlso Me.tmpManufID = 64 AndAlso Me.vManufWrty = 1 AndAlso iBillCode_ID.ToString = 2008 Then
                    '**********************************************************************
                    'this service only allow to on OW unit
                    '**********************************************************************
                    MessageBox.Show("This service is not valid for IW device.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf strAction.ToLower = "add" AndAlso Me.tmpManufID = 64 AndAlso iBillCode_ID.ToString = 2008 AndAlso Buisness.Generic.IsDeviceHadParts(Me.tmpDeviceID) = True Then
                    '**********************************************************************
                    'this service only allow to on OW unit
                    '**********************************************************************
                    MessageBox.Show("Please remove all parts before bill this service.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me.tmpCustID = 2453 AndAlso Me.vManufWrty = 0 AndAlso strAction.ToLower = "add" AndAlso Me._device.GetPartRule(iBillCode_ID) = 1 Then
                    MessageBox.Show("Not allowed to bill RUR on OW units.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    booResult = True
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************
        Private Function BillingClickValidate_AMS(ByVal strAction As String, _
                    ByVal iBillCode_ID As Integer) As Boolean
            Dim booResult As Boolean = True
            Try
                If PSS.Data.Buisness.Generic.GetMachineCostCenterID() = 0 Then
                    MessageBox.Show("This computer does not map to any cost center. Please contact your supervisor for advises.", "Computer Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    booResult = False
                ElseIf iBillCode_ID = 25 Then     'DBR Billcode
                    If strAction = "ADD" And Me._device.Parts.Rows.Count > 0 Then
                        MessageBox.Show("Please Remove all parts and service before bill DBR", "DBR Device", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booResult = False
                    End If
                ElseIf iBillCode_ID = 58 And strAction = "ADD" Then
                    '**********************************************************
                    'don't allow user to bill Refreq billcodes for AMS customer
                    '**********************************************************
                    MessageBox.Show("You are not allow to bill Refreq/Recap.", "Refreq/Recap", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    booResult = False
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************
        Private Function BillingClickValidate_Sonitrol() As Boolean
            Dim booResult As Boolean = True

            Try
                If PSS.Data.Buisness.Generic.GetMachineCostCenterID() = 0 Then
                    MessageBox.Show("This computer does not map to any cost center. Please contact your supervisor for advises.", "Computer Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    booResult = False
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************
        Private Function BillingClickValidate_DriveCam(ByVal strAction As String, ByVal iBillcodeID As Integer) As Boolean
            Dim booResult As Boolean = True
            Dim dt As DataTable
            Dim strRURCatSql As String = ""
            Dim iDcodeID As Integer = 0
            Dim objFrmRURSelection As frmSelectedValue
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim booRURReturnToCust As Boolean = False
            Dim booRepopulateParts As Boolean = False

            Try
                If strAction = "ADD" And iBillcodeID = 1590 Then
                    dt = Me._objNewTech.GetDrivecamCFAppStatus(Me.tmpDeviceID)
                    If dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0)("ReleaseFrHoldDate")) AndAlso dt.Rows(0)("CompactFlashApproved") = 0 Then
                            MessageBox.Show("This unit is not approved to bill Compact Flash. Please verify with customer service.", "Information", MessageBoxButtons.OK)
                            Return False
                        End If
                    End If
                End If

                booRURReturnToCust = PSS.Data.Buisness.Generic.GetRURReturnToCust(Me.tmpDeviceID)

                If strAction = "ADD" And iBillcodeID = 1592 And Me._device.Parts.Select("[BillCode_ID] <> 1591 and [BillCode_ID] <> 1588").Length >= 1 Then    '1592: RUR
                    MessageBox.Show("If you wish to RUR/NER or NO PART this device first clear all part(s)/service.", "BillingClickValidate", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    booResult = False
                ElseIf strAction = "ADD" And Me._device.RUR_DBR Then
                    MessageBox.Show("This Device is a RUR/NER you CANNOT add part/service to a RUR/NER.", "BillingClickValidate", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    booResult = False
                ElseIf strAction = "ADD" And iBillcodeID = 1592 And booRURReturnToCust = False Then
                    booResult = False
                    If MessageBox.Show("You are about to scrap this unit. Do you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        'do nothing
                    Else
                        strRURCatSql = PSS.Data.Buisness.DriveCam.GetRURCodesQuery(38)
                        objFrmRURSelection = New frmSelectedValue(strRURCatSql, "RUR Reason:", "Dcode_ID", "Dcode_Desc")
                        objFrmRURSelection.ShowDialog()
                        iDcodeID = objFrmRURSelection._iSelectedVal
                        If iDcodeID = 0 Then
                            MessageBox.Show("You have to select RUR reason.", "Information", MessageBoxButtons.OK)
                        Else
                            objMisc = New PSS.Data.Buisness.Misc()
                            objMisc.DeleteDBRCode(Me.tmpDeviceID, iDcodeID)
                            objMisc.UPD(Me.tmpDeviceID, iDcodeID)

                            'Unbill Shipping & Handling And Diagnostic
                            If PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, 1591) = True Then Me._device.DeletePart(1591)
                            If PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, 1588) = True Then Me._device.DeletePart(1588)
                            Me._device.AddPart(iBillcodeID)

                            'Scrap and close the unit in the system
                            Me._objNewTech.ScrapDriveCamUnit(Me.tmpDeviceID, PSS.Core.ApplicationUser.IDShift)
                            Me.ButtonClear_ClickEvent()
                            Me.txtSerial.Focus()
                        End If
                    End If
                ElseIf strAction = "ADD" And ((iBillcodeID = 1592 And booRURReturnToCust = True) Or iBillcodeID = 1589 Or iBillcodeID = 1590) Then
                    If iBillcodeID = 1592 Then
                        strRURCatSql = PSS.Data.Buisness.DriveCam.GetRURCodesQuery(38)
                        objFrmRURSelection = New frmSelectedValue(strRURCatSql, "RUR Reason:", "Dcode_ID", "Dcode_Desc")
                        objFrmRURSelection.ShowDialog()
                        iDcodeID = objFrmRURSelection._iSelectedVal
                        If iDcodeID = 0 Then
                            MessageBox.Show("You have to select RUR reason.", "Information", MessageBoxButtons.OK)
                            Return False
                        Else
                            objMisc = New PSS.Data.Buisness.Misc()
                            objMisc.DeleteDBRCode(Me.tmpDeviceID, iDcodeID)
                            objMisc.UPD(Me.tmpDeviceID, iDcodeID)
                        End If
                    End If
                    ''Bill Shipping & Handling And Diagnostic
                    'If Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, 1591) = False Then
                    '    Me._device.AddPart(1591)
                    '    booRepopulateParts = True
                    'End If
                    If Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, 1588) = False Then
                        Me._device.AddPart(1588)
                        booRepopulateParts = True
                    End If
                    If iBillcodeID = 1590 And Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, 1589) = False Then
                        Me._device.AddPart(1589)
                        booRepopulateParts = True
                    End If

                    'Repopulate parts
                    If booRepopulateParts = True Then Me.populateParts()
                End If
                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                objMisc = Nothing
            End Try
        End Function

        '*********************************************************************************************
        Public Function TFAddPartBillCode(ByVal iAddBillcode As Integer) As Integer
            Dim i As Integer
            Try
                If PSS.Data.Buisness.Generic.IsBillcodeMapped(Me.tmpModelID, iAddBillcode) > 0 Then
                    If PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, iAddBillcode) = False Then
                        Me._device.AddPart(iAddBillcode)
                        Me._device.Update()
                        For i = 0 To Me.pnlBill.Controls.Count - 1
                            If Me.pnlBill.Controls(i).Tag = iAddBillcode Then
                                Me.pnlBill.Controls(i).ForeColor = Color.Blue
                                Exit For
                            End If
                        Next i
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************
        Private Function BillingClickValidate_Tracfone(ByVal strAction As String, ByVal iBillcodeID As Integer) As Boolean
            Dim booResult As Boolean = True

            Try
                If strAction = "ADD" AndAlso iBillcodeID = 1702 AndAlso PSS.Data.Buisness.Generic.IsDeviceHadParts(Me.tmpDeviceID) Then
                    'Tracfone functional failure return
                    MessageBox.Show("There is part(s) billed to this unit. Plese remove all part(s) before continue.", "BillingClickValidate", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    booResult = False
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************************************
        Public Function CollectFailRepairCode(ByRef iFailID As Integer, _
                   ByRef iRepID As Integer, _
                   ByRef iSymCodeID As Integer, _
                   ByVal strPanel As String, _
                   ByVal iBillcodeID As Integer, _
                   ByVal iConsignedPart As Integer, _
                   Optional ByVal strPartNumber As String = "") As Boolean
            Const iUserAbuseFailCode As Integer = 311
            Dim booResult As Boolean = False
            Dim objfrmCSSFailRepCode As Gui.Technician.frmCollectRepairFailCodes
            Dim booReplacePart, booReflow As Boolean
            Dim objMsgboxResult As DialogResult = DialogResult.No     'set defaul value to no ( no user abuse )
            Dim iRepairLevel As Integer = 0

            Try
                iSymCodeID = 0

                '*****************************************
                'NO USER ABUSE FOR PANTECH MANUFACTURER
                ' If unit in warranty: Pantech pay.....
                '*****************************************
                If Me.tmpManufID <> 64 Then objMsgboxResult = MessageBox.Show("Is this physical/liquid damaged?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If objMsgboxResult = DialogResult.Cancel Then
                    booResult = False
                ElseIf objMsgboxResult = DialogResult.Yes Then
                    If Me.tmpManufID = 16 Then      'LG
                        iRepID = 88
                    ElseIf Me.tmpManufID = 21 Then      'SamSung
                        If iConsignedPart = 1 Then
                            MessageBox.Show("Can not use this part for physical/liquid damaged.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        Else
                            iRepID = 83
                        End If
                    ElseIf Me.tmpManufID = 1 Then      'Motorola
                        iRepID = 90
                    ElseIf Me.tmpManufID = 24 Then      'Nokia
                        iRepID = 96
                    End If

                    '******************************************************
                    'This failcode use to identify who will pay for part 
                    ' and service (Manufacturer/Customer)
                    '******************************************************
                    iFailID = iUserAbuseFailCode
                    booResult = True
                Else
                    '********************************
                    'Motorola : find repair level
                    '********************************
                    If Me.tmpManufID = 1 Then
                        iRepairLevel = Me._device.GetPartRepairLevel(iBillcodeID)
                        If iRepairLevel < 0 Then
                            MessageBox.Show("System can't define repair level for part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            booResult = True
                            Exit Function
                        End If
                    End If
                    '********************************
                    booReplacePart = True : booReflow = False
                    objfrmCSSFailRepCode = New Gui.Technician.frmCollectRepairFailCodes(Me.tmpManufID, Me.tmpModelID, Me.tmpProdID, iBillcodeID, booReplacePart, booReflow, Me.tmpDeviceID, Me.txtSerial.Text.Trim, iRepairLevel, strPartNumber)
                    objfrmCSSFailRepCode._iFailcodeID = iFailID
                    objfrmCSSFailRepCode._iRepCodeID = iRepID
                    objfrmCSSFailRepCode.ShowDialog()

                    If objfrmCSSFailRepCode._booCancel = False Then
                        iFailID = objfrmCSSFailRepCode._iFailcodeID
                        iRepID = objfrmCSSFailRepCode._iRepCodeID
                        iSymCodeID = objfrmCSSFailRepCode._iSymCodeID
                        booResult = True
                    End If
                End If


                Return booResult
            Catch ex As Exception
                Throw ex
                CollectFailRepairCode = False
            Finally
                If Not IsNothing(objfrmCSSFailRepCode) Then
                    objfrmCSSFailRepCode.Dispose()
                    objfrmCSSFailRepCode = Nothing
                End If
            End Try
        End Function

        '*********************************************************************************************
        Private Sub chklstReflowBillcodes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstReflowBillcodes.ItemCheck
            Const iUserAbuseFailCode As Integer = 311
            Const iReflowBillcode As Integer = 531
            Dim objfrmCSSFailRepCode As Gui.Technician.frmCollectRepairFailCodes
            Dim iFailID, iRepID, iReflowPartCnt, iReflowTypeID As Integer
            Dim booReplacePart, booReflow, booRefreshData As Boolean
            Dim objMsgboxResult As DialogResult
            Dim iCurrManufWrty As Integer = Me.vManufWrty

            Try
                If _booPopulatingReflowCheckListFlg = True Then Exit Sub

                booRefreshData = False

                If Me.tmpDeviceID = 0 Then
                    MessageBox.Show("Device ID is missing. Please re-enter the SN/IMEI.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.NewValue = CheckState.Unchecked
                ElseIf Me.tmpModelID = 0 Then
                    MessageBox.Show("Model ID is missing. Please re-enter the SN/IMEI.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.NewValue = CheckState.Unchecked
                ElseIf Buisness.Generic.IsBillcodeMapped(Me.tmpModelID, iReflowBillcode) = 0 Then
                    MessageBox.Show("Reflow service is not map for this model. Please contact Material Department.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.NewValue = CheckState.Unchecked
                ElseIf Me.tmpCustID = 2258 AndAlso e.NewValue = CheckState.Checked AndAlso Me.CollectWarrantyDateCode_Tracfone(Me.tmpDeviceID, Me.tmpManufID, Me.tmpModelID, Me.txtSerial.Text, Me.vManufWrty, booRefreshData) = False Then
                    e.NewValue = CheckState.Unchecked
                    Exit Sub
                    'Collect warranty data  for TF customer
                Else
                    '*******************************************
                    'Refresh data after collect warranty code
                    '*******************************************
                    If booRefreshData Then
                        Dim dtDevice As DataTable = Me._objNewTech.GetDeviceInfo(Me.tmpDeviceID)
                        If dtDevice.Rows.Count > 0 Then
                            Me._drDevice = dtDevice.Rows(0)
                        Else
                            e.NewValue = CheckState.Unchecked : Throw New Exception("Can't find data for device id : " & Me.tmpDeviceID)
                        End If
                    End If
                    '*******************************************
                    If iCurrManufWrty <> Me.vManufWrty Then Me._device = New Device(Me.tmpDeviceID)
                    If vManufWrty = 1 Then Me.lblWarrantyStatus.Text = "IW" Else Me.lblWarrantyStatus.Text = "OW"

                    booReplacePart = False : booReflow = True
                    iFailID = 0 : iRepID = 0

                    If e.NewValue = CheckState.Checked Then
                        '**********************************************************
                        'Reflow type 1:Eligeble for Reflow and warrany claim 
                        '            2: Eligeble for Reflow but not warranty claim
                        '**********************************************************
                        iReflowTypeID = Me.chklstReflowBillcodes.DataSource.Table.Select("Billcode_ID = " & Me.chklstReflowBillcodes.SelectedValue())(0)("ReflowTypeID")

                        If iReflowTypeID = 1 Then objMsgboxResult = MessageBox.Show("Is this physical/liquid damaged?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) Else objMsgboxResult = DialogResult.Yes

                        If objMsgboxResult = DialogResult.Cancel Then
                            e.NewValue = CheckState.Unchecked
                        ElseIf objMsgboxResult = DialogResult.Yes Then
                            If Me.tmpManufID = 16 Then      'LG
                                iRepID = 89       'Resoldering
                            ElseIf Me.tmpManufID = 21 Then      'SamSung
                                iRepID = 84       'RESOLDER
                            ElseIf Me.tmpManufID = 1 Then      'Motorola
                                iRepID = 93
                            ElseIf Me.tmpManufID = 24 Then      'Nokia
                                iRepID = 94
                            End If

                            '******************************************************
                            'This failcode use to identify who will pay for part 
                            ' and service (Manufacturer/Customer)
                            '******************************************************
                            iFailID = iUserAbuseFailCode
                        Else
                            If Me.tmpManufID = 24 Then iRepID = 94
                            objfrmCSSFailRepCode = New Gui.Technician.frmCollectRepairFailCodes(Me.tmpManufID, Me.tmpModelID, Me.tmpProdID, Me.chklstReflowBillcodes.SelectedValue(), booReplacePart, booReflow, Me.tmpDeviceID, Me.txtSerial.Text.Trim)
                            objfrmCSSFailRepCode._iFailcodeID = iFailID
                            objfrmCSSFailRepCode._iRepCodeID = iRepID
                            objfrmCSSFailRepCode.ShowDialog()

                            If objfrmCSSFailRepCode._booCancel = False Then
                                iFailID = objfrmCSSFailRepCode._iFailcodeID
                                iRepID = objfrmCSSFailRepCode._iRepCodeID
                            Else
                                e.NewValue = CheckState.Unchecked
                            End If
                        End If

                        If e.NewValue = CheckState.Checked Then
                            '************************************
                            'Bill Reflow service if not existed
                            '************************************
                            If Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, iReflowBillcode) = False Then
                                If IsNothing(Me._device) Then Me._device = New PSS.Rules.Device(Me.tmpDeviceID)
                                Me._device.AddPart(iReflowBillcode)
                                Me._device.Update()
                            End If
                            '********************************************
                            'Record Reflow part, Failcode and Repair code 
                            '********************************************
                            Buisness.WarrantyClaim.FailCodesRepairCodes.SaveReflowPart(Me.tmpDeviceID, Me.chklstReflowBillcodes.SelectedValue(), iFailID, iRepID, PSS.Core.ApplicationUser.IDuser)
                        End If
                    ElseIf e.NewValue = CheckState.Unchecked Then
                        iReflowPartCnt = 0
                        Buisness.WarrantyClaim.FailCodesRepairCodes.DeleteReflowPart(Me.tmpDeviceID, Me.chklstReflowBillcodes.SelectedValue())
                        iReflowPartCnt = Buisness.WarrantyClaim.FailCodesRepairCodes.GetReflowPartCount(Me.tmpDeviceID)
                        If iReflowPartCnt = 0 Then
                            If IsNothing(Me._device) Then Me._device = New PSS.Rules.Device(Me.tmpDeviceID)
                            Me._device.DeletePart(iReflowBillcode)
                            Me._device.Update()
                        End If
                    ElseIf e.NewValue = CheckState.Indeterminate Then
                        MessageBox.Show("Indeterminate check state of selected item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Not IsNothing(objfrmCSSFailRepCode) Then
                    objfrmCSSFailRepCode.Dispose()
                    objfrmCSSFailRepCode = Nothing
                End If
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub SetCheckedStateForReflowParts()
            Dim dt As DataTable
            Dim i As Integer

            Try
                _booPopulatingReflowCheckListFlg = True

                If Me.chklstReflowBillcodes.Items.Count > 0 Then
                    dt = Buisness.WarrantyClaim.FailCodesRepairCodes.GetExistingReflowParts(Me.tmpDeviceID)
                    For i = 0 To Me.chklstReflowBillcodes.Items.Count - 1
                        If dt.Select("Billcode_ID = " & Me.chklstReflowBillcodes.Items.Item(i)("Billcode_ID")).Length > 0 Then Me.chklstReflowBillcodes.SetItemChecked(i, True)
                    Next i
                End If

                _booPopulatingReflowCheckListFlg = False
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulatingReflowCheckListFlg = False
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub tbReflow_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbReflow.VisibleChanged
            Try
                If Me.tbReflow.Visible = True AndAlso Me.tmpDeviceID > 0 AndAlso Me.chklstReflowBillcodes.Items.Count > 0 Then
                    SetCheckedStateForReflowParts()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tbReflow_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub chklstReflowBillcodes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chklstReflowBillcodes.SelectedIndexChanged
            Dim strFailDesc, strRepDesc As String

            Try
                strFailDesc = "" : strRepDesc = ""
                'MessageBox.Show("Me.chklstReflowBillcodes.SelectedIndex=" & Me.chklstReflowBillcodes.SelectedIndex)
                If Me.chklstReflowBillcodes.SelectedIndex >= 0 AndAlso Me.chklstReflowBillcodes.GetItemCheckState(Me.chklstReflowBillcodes.SelectedIndex) = CheckState.Checked Then
                    Buisness.WarrantyClaim.FailCodesRepairCodes.GetReflowFailRepDesc(strFailDesc, strRepDesc, Me.chklstReflowBillcodes.Items.Item(Me.chklstReflowBillcodes.SelectedIndex)("Billcode_ID"), Me.tmpDeviceID)
                End If
                Me.lblReflowFailDesc.Text = strFailDesc
                Me.lblReflowRepDesc.Text = strRepDesc
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chklstReflowBillcodes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub btnCompleteRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleteRepair.Click
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Dim objTFBillingData As Buisness.TracFone.TFBillingData
            Dim i, iTestTypeID, iRework As Integer

            Try
                If Me.tmpDeviceID > 0 Then
                    i = 0 : iTestTypeID = 7 : iRework = 1

                    If Me.tmpCustID = 2258 Then    'Tracfone
                        If Me._objNewTech.GetTFTotalCharge(Me.tmpCustID, Me.tmpModelID, Me.tmpManufID, Me.tmpDeviceID, Me._device.ManufWarranty, 0, 0, 0, 0, 0, 0) > Me._dbBERTarget Then
                            MessageBox.Show("Total fee for this device to repair has exceed the maximum limit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        objTFBillingData = New Buisness.TracFone.TFBillingData()
                        If objTFBillingData.GetMaxPartsAndServicesRepLevel(Me.tmpDeviceID) <= 1 Then
                            MessageBox.Show("This device does not have functional repair. Please complete the unit with refurbished.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    ElseIf Me.tmpCustID = PSS.Data.Buisness.Syx.CUSTOMERID Then
                        If MsgBox("Are you sure you want to complete this device?", MsgBoxStyle.YesNo, "Device Completion") = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If

                    objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                    i = objTFMisc.WriteTestResult(Me.tmpDeviceID, iTestTypeID, PSS.Core.Global.ApplicationUser.IDuser, 0, iRework, , , , , , )
                    If i > 0 Then
                        If Me.tmpCustID = 2258 Then
                            Me.btnCompleteRepair.Enabled = False
                        Else
                            Me.ButtonClear_ClickEvent()
                            txtSerial.Focus()
                        End If
                    End If    'Successufully update
                End If    'DeviceID > 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCompleteRepair_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._IsSNReady = False

                objTFMisc = Nothing
            End Try
        End Sub

        '******************************************************************

#Region "Test Results"

        '******************************************************************
        Private Sub loadTestResults()
            Dim dtTechNotes As DataTable

            Try
                Me.lblTestResult_Triage.Text = ""
                Me.lblTestResult_RF1.Text = ""
                Me.lblTestResult_RF2.Text = ""
                Me.lblTestResult_QC.Text = ""
                Me.lblTechNotesUpdDate.Text = ""
                Me.txtTechNotes.Text = ""

                Me.lblTestResult_Triage.Text = Me._objNewTech.GetTestResult_Triage(Me.tmpDeviceID)
                Me.lblTestResult_RF1.Text = Me._objNewTech.GetTestResult_RF1(Me.tmpDeviceID)
                Me.lblTestResult_RF2.Text = Me._objNewTech.GetTestResult_RF2(Me.tmpDeviceID)
                Me.lblTestResult_QC.Text = Me._objNewTech.GetTestResult_QC(Me.tmpDeviceID)

                dtTechNotes = Me._objNewTech.GetTechNotesInfo(Me.tmpDeviceID)
                If dtTechNotes.Rows.Count > 0 Then
                    Me.lblTechNotesUpdDate.Text = "Saved on " & dtTechNotes.Rows(0)("UpdatedDT") & " by " & dtTechNotes.Rows(0)("User_FullName")
                    Me.txtTechNotes.Text = dtTechNotes.Rows(0)("Notes").ToString
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "loadTestResults", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Buisness.Generic.DisposeDT(dtTechNotes)
            End Try
        End Sub

        '******************************************************************
#End Region

        '******************************************************************
        Private Sub AccessoryClick(ByVal sender As Object, ByVal e As System.EventArgs)
            'Accessory Status '3411=Pass ;3412=Fail ;3413=Missing
            Dim btName, BillCode_ID, Part_Number As String
            Dim user_ID As Integer = PSS.Core.ApplicationUser.IDuser
            Dim objAccessoryStatusWind As Gui.AccessoryStatus
            Dim strAction, strFailReason As String
            Dim iStatusID As Integer
            Dim objSyx As New PSS.Data.Buisness.Syx()

            Try
                Me.Enabled = False
                Part_Number = Trim(sender.name.ToString)
                btName = Trim(sender.text.ToString)
                BillCode_ID = Trim(sender.tag.ToString)

                If CType(sender, Button).BackColor.ToString() = "Color [Orange]" Then
                    'Failed or Remove Accessories
                    objAccessoryStatusWind = New Gui.AccessoryStatus()
                    objAccessoryStatusWind.ShowDialog()
                    If objAccessoryStatusWind._booCancel = True Then
                        Exit Sub
                    Else
                        iStatusID = objAccessoryStatusWind._iStatusDCodeID
                        strFailReason = objAccessoryStatusWind._strFailReason
                        objSyx.InsertRemoveAccessories(Me.tmpDeviceID, BillCode_ID, Part_Number, objSyx.ScreenID_Billing, user_ID, iStatusID, strFailReason)
                        CType(sender, Button).BackColor = Color.LightGray
                    End If
                Else
                    'Add New Accessory 
                    'If MessageBox.Show("The " & btName.ToUpper & " accessory is not available or missing during receiving. Are you sure you want to add the " & btName.ToUpper & " accessory ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                    iStatusID = 3411
                    objSyx.InsertRemoveAccessories(Me.tmpDeviceID, BillCode_ID, Part_Number, objSyx.ScreenID_Billing, user_ID, iStatusID)
                    CType(sender, Button).BackColor = Color.Orange
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAccessories_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                If Not IsNothing(objAccessoryStatusWind) Then
                    objAccessoryStatusWind.Dispose() : objAccessoryStatusWind = Nothing
                    objSyx = Nothing
                End If
            End Try
        End Sub

        '******************************************************************
        Private Sub txtTechNotes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTechNotes.KeyPress
            Try
                If e.KeyChar = Chr(Keys.Enter) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtTechNotes_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Public Shared Function CollectPartAndReplaceTempPartInBOM(ByVal iBillcodeID As Integer, ByVal booIsRVPart As Boolean, ByVal iProdID As Integer, _
                        ByVal iModelID As Integer, ByRef objdevice As PSS.Rules.Device) As Boolean
            Dim objColPartAndMapBOM As Gui.frmCollectPartAndRemapBOM
            Dim booResult As Boolean = False
            Dim iPspriceID As Integer = 0

            Try
                iPspriceID = objdevice.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID)(0)("PSPrice_ID")
                objColPartAndMapBOM = New Gui.frmCollectPartAndRemapBOM(iModelID, iBillcodeID, iPspriceID, booIsRVPart, iProdID)
                objColPartAndMapBOM.ShowDialog()

                If objColPartAndMapBOM._booCancel = False Then
                    booResult = True
                    If objColPartAndMapBOM._booRefreshBOM = True Then objdevice.ReFreshPartMapBOM()
                End If
                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objColPartAndMapBOM) Then
                    objColPartAndMapBOM.Dispose() : objColPartAndMapBOM = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Private Sub btnSaveTechNotes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveTechNotes.Click
            Dim i As Integer = 0
            Dim strErrMsg As String = ""

            Try
                If Me.txtSerial.Text.Trim.Length = 0 OrElse Me.tmpDeviceID = 0 Then
                    MessageBox.Show("Please enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                ElseIf Me.txtTechNotes.Text.Trim.Length = 0 AndAlso Me.lstFailCodes.Items.Count = 0 Then
                    MessageBox.Show("Please enter tech notes or select tech failure code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtTechNotes.SelectAll() : Me.txtTechNotes.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = Me._objNewTech.SaveTechNotes(Me.tmpDeviceID, Me.txtTechNotes.Text.Trim, ApplicationUser.IDuser)
                    If i = 0 Then
                        MessageBox.Show("System has failed to save Tech Notes.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf Me.lstFailCodes.Items.Count > 0 Then
                        'Save failure result
                        Me._objNewTech.SaveTechFailureResult(Me.tmpDeviceID, Me.GetCorrectCodes, ApplicationUser.IDuser, strErrMsg)
                        If strErrMsg.Trim.Length > 0 Then
                            MessageBox.Show("Note did not save." & strErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSaveTechNotes_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub LoadTechFailureCodes(ByVal iDeviceID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objNewTech.GetTechFailureCodes(True, iDeviceID)
                Misc.PopulateC1DropDownList(Me.cboCodes, dt, "DCode_SLDesc", "DCode_ID")
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub ctrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCodes.KeyUp, btnSaveTechNotes.KeyUp, btnRemoveCode.KeyUp, lstFailCodes.KeyUp, txtTechNotes.KeyUp
            Dim R1 As DataRow

            Try
                If sender.name = "cboCodes" Then
                    If e.KeyCode = Keys.Enter Then
                        If Me.cboCodes.SelectedValue = 0 Then Exit Sub

                        If Me.lstFailCodes.DataSource.Table.Select("DCode_ID = " & Me.cboCodes.SelectedValue).Length > 0 Then
                            MessageBox.Show("This code is already added to the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            R1 = Me.lstFailCodes.DataSource.Table.NewRow
                            R1("DCode_ID") = Me.cboCodes.SelectedValue
                            R1("DCode_SLDesc") = Me.cboCodes.Text
                            Me.lstFailCodes.DataSource.Table.Rows.Add(R1)
                            Me.lstFailCodes.DataSource.Table.AcceptChanges()
                        End If

                        Me.cboCodes.SelectedValue = 0
                    ElseIf e.KeyCode = Keys.F12 Then
                        btnRemoveCode_Click(Nothing, Nothing)
                    End If
                ElseIf sender.name = "cboCodes_KeyUp" OrElse sender.name = "btnRemoveCode" OrElse sender.name = "btnRemoveCode" OrElse sender.name = "lstFailCodes" OrElse sender.name = "txtTechNotes" Then
                    If e.KeyCode = Keys.F12 Then btnRemoveCode_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSaveTechNotes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************************
        Private Function GetCorrectCodes() As ArrayList
            Dim i As Integer = 0
            Dim strCodes As New ArrayList()

            Try
                For i = 0 To Me.lstFailCodes.DataSource.Table.Rows.Count - 1
                    strCodes.Add(Me.lstFailCodes.DataSource.Table.Rows(i)("DCode_ID"))
                Next i

                Return strCodes
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************************************
        Private Sub LoadTechFailureResult(ByVal iDevice_ID As Integer)
            Dim dtTechFailResult As DataTable

            Try
                dtTechFailResult = Me._objNewTech.GetTechFailureResult(iDevice_ID)
                With Me.lstFailCodes
                    .DataSource = Nothing
                    .Items.Clear()
                    .DataSource = dtTechFailResult.DefaultView
                    .DisplayMember = "DCode_SLDesc"
                    .ValueMember = "DCode_ID"
                End With
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtTechFailResult)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnRemoveCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveCode.Click
            Dim R1 As DataRow

            Try
                If Me.lstFailCodes.Items.Count > 0 Then
                    R1 = Me.lstFailCodes.DataSource.Table.Select("DCode_ID = " & Me.lstFailCodes.SelectedValue)(0)
                    Me.lstFailCodes.DataSource.Table.Rows.Remove(R1)
                    Me.lstFailCodes.DataSource.Table.AcceptChanges()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '****************************************************************************************************************
        Public Shared Function CollectWarrantyDateCode_Tracfone(ByVal iDeviceID As Integer, ByVal iManufID As Integer, ByVal iModelID As Integer, ByVal strSN As String, _
                      ByRef iRefManufWrty As Integer, ByRef booRefresh As Boolean) As Boolean
            Dim iManufWrty, iWrtyExpInLess31Days, iManufacturingCountryID, iBoxType, i As Integer
            Dim strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, strToday As String
            Dim objAdmin As Data.Buisness.TracFone.Admin
            Dim objTFRec As Data.Buisness.TracFone.Receive
            Dim booResult As Boolean = False
            Dim drWarrantyData As DataRow

            Try
                objAdmin = New Data.Buisness.TracFone.Admin()
                objTFRec = New Data.Buisness.TracFone.Receive()
                drWarrantyData = objAdmin.GetCurrentWarrantyData(iDeviceID)

                If objTFRec.IsManufWarrantyClaimable(iManufID) = False Then      'Apple and RIM: temporary not collect datecode
                    booResult = True
                ElseIf Not IsDBNull(drWarrantyData("LastDateInWrty")) AndAlso drWarrantyData("LastDateInWrty").ToString.Trim.Length > 0 Then
                    booResult = True    'already has warranty data
                Else
                    strLastDateInWrty = "" : strWrtyDateCode = "" : strMSN = "" : strAPC = "" : strToday = ""
                    strToday = Data.Buisness.Generic.MySQLServerDateTime(1)
                    iBoxType = objAdmin.GetBoxTypeFromDeviceID(iDeviceID)
                    '***************************
                    'collect warranty data
                    '***************************
                    If Gui.TracFone.frmRec.CollectWarrantyData(iManufID, iModelID, strSN, iBoxType, iManufWrty, iWrtyExpInLess31Days, strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, iManufacturingCountryID) = False Then
                        'fail to collect warranty data
                    ElseIf iManufWrty < 0 Then
                        MessageBox.Show("System has failed to define manufacture warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf iManufWrty = 1 AndAlso CDate(strLastDateInWrty).Year > CDate(strToday).Year AndAlso (CDate(strLastDateInWrty).Year - CDate(strToday).Year) > 2 Then
                        MessageBox.Show("Invalid warranty expiration date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        i = objTFRec.UpdateWarrantyData(iDeviceID, iManufWrty, strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, "", strToday)
                        If i = 0 Then
                            MessageBox.Show("Invalid warranty expiration date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            booResult = True : iRefManufWrty = iManufWrty : booRefresh = True
                        End If
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                objAdmin = Nothing : objTFRec = Nothing
            End Try
        End Function

        '****************************************************************************************************************

        Private Function DoSWScreen() As Boolean 'Do not use this. Bad one!!!
            Dim _dialogResult As New DialogResult()
            Dim _frm As New TFSWScreenForDevice(txtSerial.Text)
            _dialogResult = _frm.ShowDialog()
            Return (_dialogResult = DialogResult.Yes)
        End Function

        '********************************************************************************************************************
        'Do Software Screen
        Private Sub TabMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.Click
            Try

                If Me._iSCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID _
                   AndAlso Me._bAllowSoftwareProcess = True _
                   AndAlso tabMain.SelectedTab.Name = "tbSW" AndAlso Me._IsSNReady = True _
                   AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                    If PSS.Data.Buisness.ModManuf.IsKillSwitchModel(tmpModelID) Then
                        Dim fm As New TFSWScreenForDevice(Me.txtSerial.Text, True)
                        fm.ShowDialog()
                    Else
                        MessageBox.Show("This model is not Software Process enabled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class

End Namespace


