Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFone
	Public Class frmRec
		Inherits System.Windows.Forms.Form

		Private _objModelManuf As New PSS.Data.Buisness.ModManuf()
		Private _objTFRec As PSS.Data.Buisness.TracFone.Receive
		Private _booEligibleToViewUnRecUnits As Boolean = False
		Private _booEligibleToProcessDiscrepancy As Boolean = False
		Private _booLoadDataToCtrl As Boolean = False
        Private _bReceiving_NTF_XModel As Boolean = False
        Private _bTriageNeeded As Boolean = False

#Region " Windows Form Designer generated code "

		Public Sub New()
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call
			_objTFRec = New PSS.Data.Buisness.TracFone.Receive()
		End Sub

		'Form overrides dispose to clean up the component list.
		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not (components Is Nothing) Then
					components.Dispose()
				End If

				_objTFRec = Nothing
			End If
			MyBase.Dispose(disposing)
		End Sub

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		Friend WithEvents lblHeader As System.Windows.Forms.Label
		Friend WithEvents pnlFileInfo As System.Windows.Forms.Panel
		Friend WithEvents Label11 As System.Windows.Forms.Label
		Friend WithEvents Label9 As System.Windows.Forms.Label
		Friend WithEvents lblFileQty As System.Windows.Forms.Label
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents btnCloseRMA As System.Windows.Forms.Button
		Friend WithEvents Panel6 As System.Windows.Forms.Panel
		Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents lblModel As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
		Friend WithEvents dbgRecUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents Panel1 As System.Windows.Forms.Panel
		Friend WithEvents btnView As System.Windows.Forms.Button
		Friend WithEvents cboOpenOrders As C1.Win.C1List.C1Combo
		Friend WithEvents btnGo As System.Windows.Forms.Button
		Friend WithEvents Panel2 As System.Windows.Forms.Panel
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents dtpDockRecDate As System.Windows.Forms.DateTimePicker
		Friend WithEvents btnWaitingToBeRec As System.Windows.Forms.Button
		Friend WithEvents txtRcvd As System.Windows.Forms.TextBox
		Friend WithEvents btnLanUseOnly As System.Windows.Forms.Button
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents cboBoxType As C1.Win.C1List.C1Combo
		Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
		Friend WithEvents pnlBox As System.Windows.Forms.Panel
		Friend WithEvents lblInWrtyBoxQty As System.Windows.Forms.Label
		Friend WithEvents lblInWrtyBoxID As System.Windows.Forms.Label
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents Label12 As System.Windows.Forms.Label
		Friend WithEvents lblOutWrtyBoxQty As System.Windows.Forms.Label
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents lblDisposition As System.Windows.Forms.Label
		Friend WithEvents gbOutWrty As System.Windows.Forms.GroupBox
		Friend WithEvents grbInWrty As System.Windows.Forms.GroupBox
		Friend WithEvents gbInWrtyExpLess30Days As System.Windows.Forms.GroupBox
		Friend WithEvents Label13 As System.Windows.Forms.Label
		Friend WithEvents lblWrtyExpediteQty As System.Windows.Forms.Label
		Friend WithEvents lblWrtyExpedite As System.Windows.Forms.Label
		Friend WithEvents btnRefreshRecNo As System.Windows.Forms.Button
		Friend WithEvents Label14 As System.Windows.Forms.Label
		Friend WithEvents txtMaxBoxQty As System.Windows.Forms.TextBox
		Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
		Friend WithEvents tpReceiving As System.Windows.Forms.TabPage
		Friend WithEvents tpDicrepancyReceiving As System.Windows.Forms.TabPage
		Friend WithEvents Label17 As System.Windows.Forms.Label
		Friend WithEvents Label20 As System.Windows.Forms.Label
		Friend WithEvents cboDiscrepancyOrder As C1.Win.C1List.C1Combo
		Friend WithEvents Label15 As System.Windows.Forms.Label
		Friend WithEvents txtDiscrepancyIMEI As System.Windows.Forms.TextBox
		Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
		Friend WithEvents Label16 As System.Windows.Forms.Label
		Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
		Friend WithEvents Label21 As System.Windows.Forms.Label
		Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
		Friend WithEvents Label24 As System.Windows.Forms.Label
		Friend WithEvents dbgDisRecHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents Label27 As System.Windows.Forms.Label
		Friend WithEvents pnlHistoryByIMEI As System.Windows.Forms.Panel
		Friend WithEvents pnlHistoryByRecptDate As System.Windows.Forms.Panel
		Friend WithEvents Label28 As System.Windows.Forms.Label
		Friend WithEvents Label29 As System.Windows.Forms.Label
		Friend WithEvents btnSearchHistory As System.Windows.Forms.Button
		Friend WithEvents rbtnHistoryByIMEI As System.Windows.Forms.RadioButton
		Friend WithEvents rbtnHistoryByRecptDate As System.Windows.Forms.RadioButton
		Friend WithEvents txtHistoryByIMEI As System.Windows.Forms.TextBox
		Friend WithEvents dtpHistoryByStartDate As System.Windows.Forms.DateTimePicker
		Friend WithEvents dtpHistoryByEndDate As System.Windows.Forms.DateTimePicker
		Friend WithEvents cboDiscModels As C1.Win.C1List.C1Combo
		Friend WithEvents btnCloseIWBox As System.Windows.Forms.Button
		Friend WithEvents btnCloseIWEBox As System.Windows.Forms.Button
		Friend WithEvents btnCloseOWBox As System.Windows.Forms.Button
		Friend WithEvents lblDiscWrtyStatus As System.Windows.Forms.Label
		Friend WithEvents lblInWrtyBoxID_Disc As System.Windows.Forms.Label
		Friend WithEvents lblWrtyExpediteQty_Disc As System.Windows.Forms.Label
		Friend WithEvents lblWrtyExpedite_Disc As System.Windows.Forms.Label
		Friend WithEvents lblOutWrtyBoxQty_Disc As System.Windows.Forms.Label
		Friend WithEvents lblInWrtyBoxQty_Disc As System.Windows.Forms.Label
		Friend WithEvents lblOutWrtyBoxID_Disc As System.Windows.Forms.Label
		Friend WithEvents lblOutWrtyBoxID As System.Windows.Forms.Label
		Friend WithEvents chkNoEDIDev944 As System.Windows.Forms.CheckBox
		Friend WithEvents pnlDisRec As System.Windows.Forms.Panel
		Friend WithEvents Label19 As System.Windows.Forms.Label
		Friend WithEvents Label22 As System.Windows.Forms.Label
		Friend WithEvents Label25 As System.Windows.Forms.Label
		Friend WithEvents Panel4 As System.Windows.Forms.Panel
		Friend WithEvents Label26 As System.Windows.Forms.Label
		Friend WithEvents Label31 As System.Windows.Forms.Label
		Friend WithEvents Label35 As System.Windows.Forms.Label
		Friend WithEvents Label47 As System.Windows.Forms.Label
		Friend WithEvents Label48 As System.Windows.Forms.Label
		Friend WithEvents Label50 As System.Windows.Forms.Label
		Friend WithEvents tpReceivingBox As System.Windows.Forms.TabPage
		Friend WithEvents lblBoxRec_Disposition As System.Windows.Forms.Label
		Friend WithEvents dtpBoxRec_DockRecDate As System.Windows.Forms.DateTimePicker
		Friend WithEvents lblBoxRec_Model As System.Windows.Forms.Label
		Friend WithEvents cboBoxRec_OpenOrders As C1.Win.C1List.C1Combo
		Friend WithEvents cboBoxRec_BoxType As C1.Win.C1List.C1Combo
		Friend WithEvents dbgBoxRec_ViewUnitsOnOrder As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents txtBoxRec_IMEIs As System.Windows.Forms.TextBox
		Friend WithEvents btnBoxRec_Receive As System.Windows.Forms.Button
		Friend WithEvents btnBoxRec_RefreshRecNo As System.Windows.Forms.Button
		Friend WithEvents btnBoxRec_ViewReceivedUnits As System.Windows.Forms.Button
		Friend WithEvents btnBoxRec_ReprintBoxLabel As System.Windows.Forms.Button
		Friend WithEvents btnBoxRec_CloseRMA As System.Windows.Forms.Button
		Friend WithEvents btnBoxRec_WaitingToBeRec As System.Windows.Forms.Button
		Friend WithEvents lblBoxRec_FileQty As System.Windows.Forms.Label
		Friend WithEvents txtBoxRec_Rcvd As System.Windows.Forms.TextBox
		Friend WithEvents lblBoxRec_BoxQty As System.Windows.Forms.Label
		Friend WithEvents dbgBoxRec_MissingInEDIUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents dbgBoxRec_NotReceivedUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents dbgBoxRec_ReceivedUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents pnlBoxRec_Box As System.Windows.Forms.Panel
		Friend WithEvents btnBoxRec_Clear As System.Windows.Forms.Button
		Friend WithEvents lblBoxRec_Extra As System.Windows.Forms.Label
		Friend WithEvents lblExtra As System.Windows.Forms.Label
        Friend WithEvents chkBoxWFM As System.Windows.Forms.CheckBox
        Friend WithEvents txtWFMBox As System.Windows.Forms.TextBox
        Friend WithEvents btnViewWFMBox As System.Windows.Forms.Button
        Friend WithEvents tpReceivingWFMBox2TF As System.Windows.Forms.TabPage
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboWFM2TFOrder As C1.Win.C1List.C1Combo
        Friend WithEvents cboWFM2TFModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents chkWFM2TF_NoEDIDev944 As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents Label30 As System.Windows.Forms.Label
        Friend WithEvents lblWFM2TF_OutWrtyBoxID As System.Windows.Forms.Label
        Friend WithEvents btnCloseWFM2TFBox As System.Windows.Forms.Button
        Friend WithEvents lblWFM2TF_OutWrtyBoxQty As System.Windows.Forms.Label
        Friend WithEvents txtWFM2TF_BoxName As System.Windows.Forms.TextBox
        Friend WithEvents lstWFM2TF_SNsInBox As System.Windows.Forms.ListBox
        Friend WithEvents lblWFM2TF_SN_Count As System.Windows.Forms.Label
        Friend WithEvents lblWFMModel As System.Windows.Forms.Label
        Friend WithEvents Label32 As System.Windows.Forms.Label
        Friend WithEvents lblModel_ID As System.Windows.Forms.Label
        Friend WithEvents lblXModelDesc As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRec))
            Me.lblHeader = New System.Windows.Forms.Label()
            Me.pnlFileInfo = New System.Windows.Forms.Panel()
            Me.btnRefreshRecNo = New System.Windows.Forms.Button()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblExtra = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblFileQty = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtRcvd = New System.Windows.Forms.TextBox()
            Me.lblInWrtyBoxQty = New System.Windows.Forms.Label()
            Me.lblInWrtyBoxID = New System.Windows.Forms.Label()
            Me.lblMsg = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnCloseRMA = New System.Windows.Forms.Button()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.pnlBox = New System.Windows.Forms.Panel()
            Me.gbInWrtyExpLess30Days = New System.Windows.Forms.GroupBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.lblWrtyExpediteQty = New System.Windows.Forms.Label()
            Me.lblWrtyExpedite = New System.Windows.Forms.Label()
            Me.gbOutWrty = New System.Windows.Forms.GroupBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.lblOutWrtyBoxQty = New System.Windows.Forms.Label()
            Me.lblOutWrtyBoxID = New System.Windows.Forms.Label()
            Me.grbInWrty = New System.Windows.Forms.GroupBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cboBoxType = New C1.Win.C1List.C1Combo()
            Me.btnGo = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtMaxBoxQty = New System.Windows.Forms.TextBox()
            Me.btnWaitingToBeRec = New System.Windows.Forms.Button()
            Me.btnView = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dtpDockRecDate = New System.Windows.Forms.DateTimePicker()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblModel_ID = New System.Windows.Forms.Label()
            Me.lblXModelDesc = New System.Windows.Forms.Label()
            Me.lblDisposition = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboOpenOrders = New C1.Win.C1List.C1Combo()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.dbgRecUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnLanUseOnly = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpReceivingBox = New System.Windows.Forms.TabPage()
            Me.pnlBoxRec_Box = New System.Windows.Forms.Panel()
            Me.txtBoxRec_IMEIs = New System.Windows.Forms.TextBox()
            Me.Label48 = New System.Windows.Forms.Label()
            Me.lblBoxRec_BoxQty = New System.Windows.Forms.Label()
            Me.cboBoxRec_BoxType = New C1.Win.C1List.C1Combo()
            Me.Label47 = New System.Windows.Forms.Label()
            Me.dbgBoxRec_MissingInEDIUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnBoxRec_Receive = New System.Windows.Forms.Button()
            Me.dbgBoxRec_NotReceivedUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgBoxRec_ReceivedUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgBoxRec_ViewUnitsOnOrder = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.btnBoxRec_RefreshRecNo = New System.Windows.Forms.Button()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.lblBoxRec_Extra = New System.Windows.Forms.Label()
            Me.Label31 = New System.Windows.Forms.Label()
            Me.lblBoxRec_FileQty = New System.Windows.Forms.Label()
            Me.Label35 = New System.Windows.Forms.Label()
            Me.txtBoxRec_Rcvd = New System.Windows.Forms.TextBox()
            Me.btnBoxRec_ViewReceivedUnits = New System.Windows.Forms.Button()
            Me.btnBoxRec_ReprintBoxLabel = New System.Windows.Forms.Button()
            Me.btnBoxRec_CloseRMA = New System.Windows.Forms.Button()
            Me.btnBoxRec_WaitingToBeRec = New System.Windows.Forms.Button()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.Label50 = New System.Windows.Forms.Label()
            Me.lblBoxRec_Disposition = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.dtpBoxRec_DockRecDate = New System.Windows.Forms.DateTimePicker()
            Me.lblBoxRec_Model = New System.Windows.Forms.Label()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.cboBoxRec_OpenOrders = New C1.Win.C1List.C1Combo()
            Me.btnBoxRec_Clear = New System.Windows.Forms.Button()
            Me.tpDicrepancyReceiving = New System.Windows.Forms.TabPage()
            Me.pnlDisRec = New System.Windows.Forms.Panel()
            Me.btnViewWFMBox = New System.Windows.Forms.Button()
            Me.chkBoxWFM = New System.Windows.Forms.CheckBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.btnCloseOWBox = New System.Windows.Forms.Button()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.lblOutWrtyBoxQty_Disc = New System.Windows.Forms.Label()
            Me.lblOutWrtyBoxID_Disc = New System.Windows.Forms.Label()
            Me.btnSearchHistory = New System.Windows.Forms.Button()
            Me.chkNoEDIDev944 = New System.Windows.Forms.CheckBox()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.btnCloseIWBox = New System.Windows.Forms.Button()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.lblInWrtyBoxQty_Disc = New System.Windows.Forms.Label()
            Me.lblInWrtyBoxID_Disc = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnCloseIWEBox = New System.Windows.Forms.Button()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.lblWrtyExpediteQty_Disc = New System.Windows.Forms.Label()
            Me.lblWrtyExpedite_Disc = New System.Windows.Forms.Label()
            Me.pnlHistoryByRecptDate = New System.Windows.Forms.Panel()
            Me.dtpHistoryByEndDate = New System.Windows.Forms.DateTimePicker()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.dtpHistoryByStartDate = New System.Windows.Forms.DateTimePicker()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.cboDiscrepancyOrder = New C1.Win.C1List.C1Combo()
            Me.txtDiscrepancyIMEI = New System.Windows.Forms.TextBox()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.dbgDisRecHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.rbtnHistoryByRecptDate = New System.Windows.Forms.RadioButton()
            Me.rbtnHistoryByIMEI = New System.Windows.Forms.RadioButton()
            Me.pnlHistoryByIMEI = New System.Windows.Forms.Panel()
            Me.txtHistoryByIMEI = New System.Windows.Forms.TextBox()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.lblDiscWrtyStatus = New System.Windows.Forms.Label()
            Me.cboDiscModels = New C1.Win.C1List.C1Combo()
            Me.txtWFMBox = New System.Windows.Forms.TextBox()
            Me.tpReceiving = New System.Windows.Forms.TabPage()
            Me.tpReceivingWFMBox2TF = New System.Windows.Forms.TabPage()
            Me.Label32 = New System.Windows.Forms.Label()
            Me.lblWFMModel = New System.Windows.Forms.Label()
            Me.lstWFM2TF_SNsInBox = New System.Windows.Forms.ListBox()
            Me.lblWFM2TF_SN_Count = New System.Windows.Forms.Label()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.btnCloseWFM2TFBox = New System.Windows.Forms.Button()
            Me.Label30 = New System.Windows.Forms.Label()
            Me.lblWFM2TF_OutWrtyBoxQty = New System.Windows.Forms.Label()
            Me.lblWFM2TF_OutWrtyBoxID = New System.Windows.Forms.Label()
            Me.chkWFM2TF_NoEDIDev944 = New System.Windows.Forms.CheckBox()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.txtWFM2TF_BoxName = New System.Windows.Forms.TextBox()
            Me.cboWFM2TFModels = New C1.Win.C1List.C1Combo()
            Me.cboWFM2TFOrder = New C1.Win.C1List.C1Combo()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.pnlFileInfo.SuspendLayout()
            Me.Panel6.SuspendLayout()
            Me.pnlBox.SuspendLayout()
            Me.gbInWrtyExpLess30Days.SuspendLayout()
            Me.gbOutWrty.SuspendLayout()
            Me.grbInWrty.SuspendLayout()
            CType(Me.cboBoxType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.cboOpenOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpReceivingBox.SuspendLayout()
            Me.pnlBoxRec_Box.SuspendLayout()
            CType(Me.cboBoxRec_BoxType, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgBoxRec_MissingInEDIUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgBoxRec_NotReceivedUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgBoxRec_ReceivedUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgBoxRec_ViewUnitsOnOrder, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel4.SuspendLayout()
            CType(Me.cboBoxRec_OpenOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpDicrepancyReceiving.SuspendLayout()
            Me.pnlDisRec.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.pnlHistoryByRecptDate.SuspendLayout()
            CType(Me.cboDiscrepancyOrder, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgDisRecHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlHistoryByIMEI.SuspendLayout()
            CType(Me.cboDiscModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpReceiving.SuspendLayout()
            Me.tpReceivingWFMBox2TF.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            CType(Me.cboWFM2TFModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboWFM2TFOrder, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblHeader
            '
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.TabIndex = 4
            '
            'pnlFileInfo
            '
            Me.pnlFileInfo.BackColor = System.Drawing.Color.Black
            Me.pnlFileInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFileInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshRecNo, Me.Label11, Me.lblExtra, Me.Label9, Me.lblFileQty, Me.Label6, Me.txtRcvd})
            Me.pnlFileInfo.Location = New System.Drawing.Point(637, 144)
            Me.pnlFileInfo.Name = "pnlFileInfo"
            Me.pnlFileInfo.Size = New System.Drawing.Size(310, 168)
            Me.pnlFileInfo.TabIndex = 2
            '
            'btnRefreshRecNo
            '
            Me.btnRefreshRecNo.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshRecNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshRecNo.ForeColor = System.Drawing.Color.White
            Me.btnRefreshRecNo.Location = New System.Drawing.Point(216, 136)
            Me.btnRefreshRecNo.Name = "btnRefreshRecNo"
            Me.btnRefreshRecNo.Size = New System.Drawing.Size(88, 24)
            Me.btnRefreshRecNo.TabIndex = 113
            Me.btnRefreshRecNo.Text = "Refresh"
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Lime
            Me.Label11.Location = New System.Drawing.Point(0, 72)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(224, 31)
            Me.Label11.TabIndex = 89
            Me.Label11.Text = "Total Received :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblExtra
            '
            Me.lblExtra.BackColor = System.Drawing.Color.Transparent
            Me.lblExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblExtra.ForeColor = System.Drawing.Color.Lime
            Me.lblExtra.Location = New System.Drawing.Point(224, 32)
            Me.lblExtra.Name = "lblExtra"
            Me.lblExtra.Size = New System.Drawing.Size(80, 31)
            Me.lblExtra.TabIndex = 88
            Me.lblExtra.Text = "0"
            Me.lblExtra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Lime
            Me.Label9.Location = New System.Drawing.Point(16, 32)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(208, 31)
            Me.Label9.TabIndex = 87
            Me.Label9.Text = "Extra :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFileQty
            '
            Me.lblFileQty.BackColor = System.Drawing.Color.Transparent
            Me.lblFileQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFileQty.ForeColor = System.Drawing.Color.Lime
            Me.lblFileQty.Location = New System.Drawing.Point(224, 0)
            Me.lblFileQty.Name = "lblFileQty"
            Me.lblFileQty.Size = New System.Drawing.Size(80, 24)
            Me.lblFileQty.TabIndex = 84
            Me.lblFileQty.Text = "0"
            Me.lblFileQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Lime
            Me.Label6.Location = New System.Drawing.Point(16, 0)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(208, 24)
            Me.Label6.TabIndex = 83
            Me.Label6.Text = "Devices in file :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtRcvd
            '
            Me.txtRcvd.BackColor = System.Drawing.Color.Black
            Me.txtRcvd.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtRcvd.Enabled = False
            Me.txtRcvd.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRcvd.ForeColor = System.Drawing.Color.Lime
            Me.txtRcvd.Location = New System.Drawing.Point(221, 72)
            Me.txtRcvd.Name = "txtRcvd"
            Me.txtRcvd.Size = New System.Drawing.Size(80, 31)
            Me.txtRcvd.TabIndex = 112
            Me.txtRcvd.Text = "0"
            Me.txtRcvd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblInWrtyBoxQty
            '
            Me.lblInWrtyBoxQty.BackColor = System.Drawing.Color.Black
            Me.lblInWrtyBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInWrtyBoxQty.ForeColor = System.Drawing.Color.Lime
            Me.lblInWrtyBoxQty.Location = New System.Drawing.Point(48, 39)
            Me.lblInWrtyBoxQty.Name = "lblInWrtyBoxQty"
            Me.lblInWrtyBoxQty.Size = New System.Drawing.Size(96, 16)
            Me.lblInWrtyBoxQty.TabIndex = 84
            Me.lblInWrtyBoxQty.Text = "0"
            Me.lblInWrtyBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblInWrtyBoxID
            '
            Me.lblInWrtyBoxID.BackColor = System.Drawing.Color.Black
            Me.lblInWrtyBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInWrtyBoxID.ForeColor = System.Drawing.Color.Lime
            Me.lblInWrtyBoxID.Location = New System.Drawing.Point(7, 19)
            Me.lblInWrtyBoxID.Name = "lblInWrtyBoxID"
            Me.lblInWrtyBoxID.Size = New System.Drawing.Size(136, 16)
            Me.lblInWrtyBoxID.TabIndex = 85
            Me.lblInWrtyBoxID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblMsg
            '
            Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
            Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMsg.ForeColor = System.Drawing.Color.White
            Me.lblMsg.Location = New System.Drawing.Point(265, 1)
            Me.lblMsg.Name = "lblMsg"
            Me.lblMsg.Size = New System.Drawing.Size(680, 79)
            Me.lblMsg.TabIndex = 1
            Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(-24, 7)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(130, 21)
            Me.Label5.TabIndex = 83
            Me.Label5.Text = "Order Number :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'btnCloseRMA
            '
            Me.btnCloseRMA.BackColor = System.Drawing.Color.Navy
            Me.btnCloseRMA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseRMA.ForeColor = System.Drawing.Color.White
            Me.btnCloseRMA.Location = New System.Drawing.Point(494, 35)
            Me.btnCloseRMA.Name = "btnCloseRMA"
            Me.btnCloseRMA.Size = New System.Drawing.Size(136, 24)
            Me.btnCloseRMA.TabIndex = 2
            Me.btnCloseRMA.Text = "CLOSE ORDER"
            Me.btnCloseRMA.Visible = False
            '
            'Panel6
            '
            Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlBox, Me.btnWaitingToBeRec, Me.btnView, Me.btnCloseRMA, Me.Panel2, Me.btnReprintBoxLabel})
            Me.Panel6.Location = New System.Drawing.Point(1, 144)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(638, 168)
            Me.Panel6.TabIndex = 1
            '
            'pnlBox
            '
            Me.pnlBox.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbInWrtyExpLess30Days, Me.gbOutWrty, Me.grbInWrty, Me.Label10, Me.cboBoxType, Me.btnGo, Me.Label3, Me.txtIMEI, Me.Label14, Me.txtMaxBoxQty})
            Me.pnlBox.Location = New System.Drawing.Point(2, 33)
            Me.pnlBox.Name = "pnlBox"
            Me.pnlBox.Size = New System.Drawing.Size(486, 128)
            Me.pnlBox.TabIndex = 1
            '
            'gbInWrtyExpLess30Days
            '
            Me.gbInWrtyExpLess30Days.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label13, Me.lblWrtyExpediteQty, Me.lblWrtyExpedite})
            Me.gbInWrtyExpLess30Days.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbInWrtyExpLess30Days.ForeColor = System.Drawing.Color.White
            Me.gbInWrtyExpLess30Days.Location = New System.Drawing.Point(168, 61)
            Me.gbInWrtyExpLess30Days.Name = "gbInWrtyExpLess30Days"
            Me.gbInWrtyExpLess30Days.Size = New System.Drawing.Size(152, 64)
            Me.gbInWrtyExpLess30Days.TabIndex = 93
            Me.gbInWrtyExpLess30Days.TabStop = False
            Me.gbInWrtyExpLess30Days.Text = "Warranty Expedite"
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.Black
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.Lime
            Me.Label13.Location = New System.Drawing.Point(7, 39)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(41, 16)
            Me.Label13.TabIndex = 86
            Me.Label13.Text = "Qty:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWrtyExpediteQty
            '
            Me.lblWrtyExpediteQty.BackColor = System.Drawing.Color.Black
            Me.lblWrtyExpediteQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyExpediteQty.ForeColor = System.Drawing.Color.Lime
            Me.lblWrtyExpediteQty.Location = New System.Drawing.Point(48, 39)
            Me.lblWrtyExpediteQty.Name = "lblWrtyExpediteQty"
            Me.lblWrtyExpediteQty.Size = New System.Drawing.Size(96, 16)
            Me.lblWrtyExpediteQty.TabIndex = 84
            Me.lblWrtyExpediteQty.Text = "0"
            Me.lblWrtyExpediteQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWrtyExpedite
            '
            Me.lblWrtyExpedite.BackColor = System.Drawing.Color.Black
            Me.lblWrtyExpedite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyExpedite.ForeColor = System.Drawing.Color.Red
            Me.lblWrtyExpedite.Location = New System.Drawing.Point(7, 19)
            Me.lblWrtyExpedite.Name = "lblWrtyExpedite"
            Me.lblWrtyExpedite.Size = New System.Drawing.Size(136, 16)
            Me.lblWrtyExpedite.TabIndex = 85
            Me.lblWrtyExpedite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'gbOutWrty
            '
            Me.gbOutWrty.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label12, Me.lblOutWrtyBoxQty, Me.lblOutWrtyBoxID})
            Me.gbOutWrty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbOutWrty.ForeColor = System.Drawing.Color.White
            Me.gbOutWrty.Location = New System.Drawing.Point(328, 61)
            Me.gbOutWrty.Name = "gbOutWrty"
            Me.gbOutWrty.Size = New System.Drawing.Size(152, 64)
            Me.gbOutWrty.TabIndex = 92
            Me.gbOutWrty.TabStop = False
            Me.gbOutWrty.Text = "Out of Warranty"
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Black
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Lime
            Me.Label12.Location = New System.Drawing.Point(8, 39)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(40, 16)
            Me.Label12.TabIndex = 86
            Me.Label12.Text = "Qty:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOutWrtyBoxQty
            '
            Me.lblOutWrtyBoxQty.BackColor = System.Drawing.Color.Black
            Me.lblOutWrtyBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutWrtyBoxQty.ForeColor = System.Drawing.Color.Lime
            Me.lblOutWrtyBoxQty.Location = New System.Drawing.Point(48, 39)
            Me.lblOutWrtyBoxQty.Name = "lblOutWrtyBoxQty"
            Me.lblOutWrtyBoxQty.Size = New System.Drawing.Size(96, 16)
            Me.lblOutWrtyBoxQty.TabIndex = 84
            Me.lblOutWrtyBoxQty.Text = "0"
            Me.lblOutWrtyBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblOutWrtyBoxID
            '
            Me.lblOutWrtyBoxID.BackColor = System.Drawing.Color.Black
            Me.lblOutWrtyBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutWrtyBoxID.ForeColor = System.Drawing.Color.Lime
            Me.lblOutWrtyBoxID.Location = New System.Drawing.Point(8, 19)
            Me.lblOutWrtyBoxID.Name = "lblOutWrtyBoxID"
            Me.lblOutWrtyBoxID.Size = New System.Drawing.Size(136, 16)
            Me.lblOutWrtyBoxID.TabIndex = 85
            Me.lblOutWrtyBoxID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grbInWrty
            '
            Me.grbInWrty.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.lblInWrtyBoxQty, Me.lblInWrtyBoxID})
            Me.grbInWrty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbInWrty.ForeColor = System.Drawing.Color.White
            Me.grbInWrty.Location = New System.Drawing.Point(8, 61)
            Me.grbInWrty.Name = "grbInWrty"
            Me.grbInWrty.Size = New System.Drawing.Size(152, 64)
            Me.grbInWrty.TabIndex = 71
            Me.grbInWrty.TabStop = False
            Me.grbInWrty.Text = "In Warranty"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Black
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Lime
            Me.Label4.Location = New System.Drawing.Point(7, 39)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(41, 16)
            Me.Label4.TabIndex = 86
            Me.Label4.Text = "Qty:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(27, 5)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(80, 16)
            Me.Label10.TabIndex = 91
            Me.Label10.Text = "Box Type :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboBoxType
            '
            Me.cboBoxType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBoxType.AutoCompletion = True
            Me.cboBoxType.AutoDropDown = True
            Me.cboBoxType.AutoSelect = True
            Me.cboBoxType.Caption = ""
            Me.cboBoxType.CaptionHeight = 17
            Me.cboBoxType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBoxType.ColumnCaptionHeight = 17
            Me.cboBoxType.ColumnFooterHeight = 17
            Me.cboBoxType.ColumnHeaders = False
            Me.cboBoxType.ContentHeight = 15
            Me.cboBoxType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBoxType.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBoxType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBoxType.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBoxType.EditorHeight = 15
            Me.cboBoxType.Enabled = False
            Me.cboBoxType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBoxType.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboBoxType.ItemHeight = 15
            Me.cboBoxType.Location = New System.Drawing.Point(107, 4)
            Me.cboBoxType.MatchEntryTimeout = CType(2000, Long)
            Me.cboBoxType.MaxDropDownItems = CType(10, Short)
            Me.cboBoxType.MaxLength = 32767
            Me.cboBoxType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBoxType.Name = "cboBoxType"
            Me.cboBoxType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBoxType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBoxType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBoxType.Size = New System.Drawing.Size(221, 21)
            Me.cboBoxType.TabIndex = 3
            Me.cboBoxType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 9." & _
            "75pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Styl" & _
            "e9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;A" & _
            "lignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contro" & _
            "l;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.List" & _
            "BoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptio" & _
            "nHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
            "up=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><W" & _
            "idth>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Caption" & _
            "Style parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /" & _
            "><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style" & _
            "11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hi" & _
            "ghlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRow" & _
            "Style parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector""" & _
            " me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""No" & _
            "rmal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style par" & _
            "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
            "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
            "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
            "=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" m" & _
            "e=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Captio" & _
            "n"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplit" & _
            "s><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'btnGo
            '
            Me.btnGo.BackColor = System.Drawing.Color.Green
            Me.btnGo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGo.ForeColor = System.Drawing.Color.White
            Me.btnGo.Location = New System.Drawing.Point(336, 37)
            Me.btnGo.Name = "btnGo"
            Me.btnGo.Size = New System.Drawing.Size(31, 19)
            Me.btnGo.TabIndex = 2
            Me.btnGo.Text = "Go"
            Me.btnGo.Visible = False
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(12, 36)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 85
            Me.Label3.Text = "IMEI/MEID :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtIMEI
            '
            Me.txtIMEI.BackColor = System.Drawing.Color.Yellow
            Me.txtIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIMEI.Location = New System.Drawing.Point(107, 35)
            Me.txtIMEI.MaxLength = 25
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(221, 21)
            Me.txtIMEI.TabIndex = 1
            Me.txtIMEI.Text = ""
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Aqua
            Me.Label14.Location = New System.Drawing.Point(344, 6)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(96, 16)
            Me.Label14.TabIndex = 95
            Me.Label14.Text = "Max Box Qty:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMaxBoxQty
            '
            Me.txtMaxBoxQty.BackColor = System.Drawing.Color.AliceBlue
            Me.txtMaxBoxQty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMaxBoxQty.Location = New System.Drawing.Point(440, 4)
            Me.txtMaxBoxQty.MaxLength = 25
            Me.txtMaxBoxQty.Name = "txtMaxBoxQty"
            Me.txtMaxBoxQty.Size = New System.Drawing.Size(40, 21)
            Me.txtMaxBoxQty.TabIndex = 4
            Me.txtMaxBoxQty.Text = "90"
            Me.txtMaxBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnWaitingToBeRec
            '
            Me.btnWaitingToBeRec.BackColor = System.Drawing.Color.SteelBlue
            Me.btnWaitingToBeRec.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWaitingToBeRec.ForeColor = System.Drawing.Color.White
            Me.btnWaitingToBeRec.Location = New System.Drawing.Point(494, 99)
            Me.btnWaitingToBeRec.Name = "btnWaitingToBeRec"
            Me.btnWaitingToBeRec.Size = New System.Drawing.Size(136, 37)
            Me.btnWaitingToBeRec.TabIndex = 6
            Me.btnWaitingToBeRec.Text = "View To Be Receviced Units"
            Me.btnWaitingToBeRec.Visible = False
            '
            'btnView
            '
            Me.btnView.BackColor = System.Drawing.Color.SteelBlue
            Me.btnView.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnView.ForeColor = System.Drawing.Color.White
            Me.btnView.Location = New System.Drawing.Point(494, 67)
            Me.btnView.Name = "btnView"
            Me.btnView.Size = New System.Drawing.Size(136, 26)
            Me.btnView.TabIndex = 5
            Me.btnView.Text = "View Received Units"
            Me.btnView.Visible = False
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.dtpDockRecDate})
            Me.Panel2.Location = New System.Drawing.Point(2, 2)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(486, 30)
            Me.Panel2.TabIndex = 3
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(-7, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(114, 16)
            Me.Label2.TabIndex = 89
            Me.Label2.Text = "Dock Rec Date :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDockRecDate
            '
            Me.dtpDockRecDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpDockRecDate.Location = New System.Drawing.Point(107, 4)
            Me.dtpDockRecDate.Name = "dtpDockRecDate"
            Me.dtpDockRecDate.Size = New System.Drawing.Size(224, 20)
            Me.dtpDockRecDate.TabIndex = 1
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.White
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(494, 3)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(136, 26)
            Me.btnReprintBoxLabel.TabIndex = 4
            Me.btnReprintBoxLabel.Text = "Reprint Box Label"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblModel_ID, Me.lblXModelDesc, Me.lblDisposition, Me.Label1, Me.cboOpenOrders, Me.Label5, Me.lblModel, Me.Label8})
            Me.Panel1.Location = New System.Drawing.Point(1, 81)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(944, 55)
            Me.Panel1.TabIndex = 3
            '
            'lblModel_ID
            '
            Me.lblModel_ID.ForeColor = System.Drawing.Color.CadetBlue
            Me.lblModel_ID.Location = New System.Drawing.Point(640, 8)
            Me.lblModel_ID.Name = "lblModel_ID"
            Me.lblModel_ID.Size = New System.Drawing.Size(64, 16)
            Me.lblModel_ID.TabIndex = 93
            '
            'lblXModelDesc
            '
            Me.lblXModelDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblXModelDesc.ForeColor = System.Drawing.Color.White
            Me.lblXModelDesc.Location = New System.Drawing.Point(104, 32)
            Me.lblXModelDesc.Name = "lblXModelDesc"
            Me.lblXModelDesc.Size = New System.Drawing.Size(824, 16)
            Me.lblXModelDesc.TabIndex = 92
            Me.lblXModelDesc.Text = "Label33"
            '
            'lblDisposition
            '
            Me.lblDisposition.BackColor = System.Drawing.Color.White
            Me.lblDisposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDisposition.ForeColor = System.Drawing.Color.Blue
            Me.lblDisposition.Location = New System.Drawing.Point(824, 6)
            Me.lblDisposition.Name = "lblDisposition"
            Me.lblDisposition.Size = New System.Drawing.Size(112, 21)
            Me.lblDisposition.TabIndex = 91
            Me.lblDisposition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(708, 7)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 21)
            Me.Label1.TabIndex = 90
            Me.Label1.Text = "Box Disposition:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboOpenOrders
            '
            Me.cboOpenOrders.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenOrders.AutoCompletion = True
            Me.cboOpenOrders.AutoDropDown = True
            Me.cboOpenOrders.AutoSelect = True
            Me.cboOpenOrders.Caption = ""
            Me.cboOpenOrders.CaptionHeight = 17
            Me.cboOpenOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenOrders.ColumnCaptionHeight = 17
            Me.cboOpenOrders.ColumnFooterHeight = 17
            Me.cboOpenOrders.ColumnHeaders = False
            Me.cboOpenOrders.ContentHeight = 15
            Me.cboOpenOrders.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenOrders.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenOrders.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrders.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenOrders.EditorHeight = 15
            Me.cboOpenOrders.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboOpenOrders.ItemHeight = 15
            Me.cboOpenOrders.Location = New System.Drawing.Point(108, 6)
            Me.cboOpenOrders.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenOrders.MaxDropDownItems = CType(10, Short)
            Me.cboOpenOrders.MaxLength = 32767
            Me.cboOpenOrders.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenOrders.Name = "cboOpenOrders"
            Me.cboOpenOrders.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenOrders.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenOrders.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenOrders.Size = New System.Drawing.Size(224, 21)
            Me.cboOpenOrders.TabIndex = 1
            Me.cboOpenOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Blue
            Me.lblModel.Location = New System.Drawing.Point(440, 6)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(192, 21)
            Me.lblModel.TabIndex = 86
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(384, 7)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(56, 21)
            Me.Label8.TabIndex = 88
            Me.Label8.Text = "Model :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'dbgRecUnits
            '
            Me.dbgRecUnits.AllowUpdate = False
            Me.dbgRecUnits.AlternatingRows = True
            Me.dbgRecUnits.FilterBar = True
            Me.dbgRecUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRecUnits.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgRecUnits.Location = New System.Drawing.Point(1, 320)
            Me.dbgRecUnits.Name = "dbgRecUnits"
            Me.dbgRecUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRecUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRecUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgRecUnits.Size = New System.Drawing.Size(946, 192)
            Me.dbgRecUnits.TabIndex = 3
            Me.dbgRecUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "88</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 942, 188<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 942, 188</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnLanUseOnly
            '
            Me.btnLanUseOnly.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnLanUseOnly.Location = New System.Drawing.Point(864, 552)
            Me.btnLanUseOnly.Name = "btnLanUseOnly"
            Me.btnLanUseOnly.Size = New System.Drawing.Size(104, 16)
            Me.btnLanUseOnly.TabIndex = 112
            Me.btnLanUseOnly.TabStop = False
            Me.btnLanUseOnly.Text = "Special Billing"
            Me.btnLanUseOnly.Visible = False
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpReceivingBox, Me.tpDicrepancyReceiving, Me.tpReceiving, Me.tpReceivingWFMBox2TF})
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(984, 544)
            Me.TabControl1.TabIndex = 113
            '
            'tpReceivingBox
            '
            Me.tpReceivingBox.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlBoxRec_Box, Me.dbgBoxRec_MissingInEDIUnits, Me.btnBoxRec_Receive, Me.dbgBoxRec_NotReceivedUnits, Me.dbgBoxRec_ReceivedUnits, Me.dbgBoxRec_ViewUnitsOnOrder, Me.Panel4, Me.btnBoxRec_ViewReceivedUnits, Me.btnBoxRec_ReprintBoxLabel, Me.btnBoxRec_CloseRMA, Me.btnBoxRec_WaitingToBeRec, Me.Label19, Me.Label50, Me.lblBoxRec_Disposition, Me.Label22, Me.dtpBoxRec_DockRecDate, Me.lblBoxRec_Model, Me.Label25, Me.cboBoxRec_OpenOrders, Me.btnBoxRec_Clear})
            Me.tpReceivingBox.Location = New System.Drawing.Point(4, 22)
            Me.tpReceivingBox.Name = "tpReceivingBox"
            Me.tpReceivingBox.Size = New System.Drawing.Size(976, 518)
            Me.tpReceivingBox.TabIndex = 2
            Me.tpReceivingBox.Text = "Receiving Box"
            '
            'pnlBoxRec_Box
            '
            Me.pnlBoxRec_Box.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBoxRec_IMEIs, Me.Label48, Me.lblBoxRec_BoxQty, Me.cboBoxRec_BoxType, Me.Label47})
            Me.pnlBoxRec_Box.Location = New System.Drawing.Point(0, 112)
            Me.pnlBoxRec_Box.Name = "pnlBoxRec_Box"
            Me.pnlBoxRec_Box.Size = New System.Drawing.Size(384, 56)
            Me.pnlBoxRec_Box.TabIndex = 3
            Me.pnlBoxRec_Box.Visible = False
            '
            'txtBoxRec_IMEIs
            '
            Me.txtBoxRec_IMEIs.BackColor = System.Drawing.Color.Yellow
            Me.txtBoxRec_IMEIs.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxRec_IMEIs.Location = New System.Drawing.Point(128, 32)
            Me.txtBoxRec_IMEIs.Name = "txtBoxRec_IMEIs"
            Me.txtBoxRec_IMEIs.Size = New System.Drawing.Size(208, 21)
            Me.txtBoxRec_IMEIs.TabIndex = 1
            Me.txtBoxRec_IMEIs.Text = ""
            '
            'Label48
            '
            Me.Label48.BackColor = System.Drawing.Color.Transparent
            Me.Label48.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label48.ForeColor = System.Drawing.Color.Black
            Me.Label48.Location = New System.Drawing.Point(8, 32)
            Me.Label48.Name = "Label48"
            Me.Label48.Size = New System.Drawing.Size(112, 16)
            Me.Label48.TabIndex = 85
            Me.Label48.Text = "IMEIs/MEIDs :"
            Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxRec_BoxQty
            '
            Me.lblBoxRec_BoxQty.BackColor = System.Drawing.Color.Black
            Me.lblBoxRec_BoxQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxRec_BoxQty.ForeColor = System.Drawing.Color.LimeGreen
            Me.lblBoxRec_BoxQty.Location = New System.Drawing.Point(344, 32)
            Me.lblBoxRec_BoxQty.Name = "lblBoxRec_BoxQty"
            Me.lblBoxRec_BoxQty.Size = New System.Drawing.Size(32, 20)
            Me.lblBoxRec_BoxQty.TabIndex = 117
            Me.lblBoxRec_BoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboBoxRec_BoxType
            '
            Me.cboBoxRec_BoxType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBoxRec_BoxType.AutoCompletion = True
            Me.cboBoxRec_BoxType.AutoDropDown = True
            Me.cboBoxRec_BoxType.AutoSelect = True
            Me.cboBoxRec_BoxType.Caption = ""
            Me.cboBoxRec_BoxType.CaptionHeight = 17
            Me.cboBoxRec_BoxType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBoxRec_BoxType.ColumnCaptionHeight = 17
            Me.cboBoxRec_BoxType.ColumnFooterHeight = 17
            Me.cboBoxRec_BoxType.ColumnHeaders = False
            Me.cboBoxRec_BoxType.ContentHeight = 15
            Me.cboBoxRec_BoxType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBoxRec_BoxType.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBoxRec_BoxType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBoxRec_BoxType.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBoxRec_BoxType.EditorHeight = 15
            Me.cboBoxRec_BoxType.Enabled = False
            Me.cboBoxRec_BoxType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBoxRec_BoxType.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboBoxRec_BoxType.ItemHeight = 15
            Me.cboBoxRec_BoxType.Location = New System.Drawing.Point(128, 0)
            Me.cboBoxRec_BoxType.MatchEntryTimeout = CType(2000, Long)
            Me.cboBoxRec_BoxType.MaxDropDownItems = CType(10, Short)
            Me.cboBoxRec_BoxType.MaxLength = 32767
            Me.cboBoxRec_BoxType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBoxRec_BoxType.Name = "cboBoxRec_BoxType"
            Me.cboBoxRec_BoxType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBoxRec_BoxType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBoxRec_BoxType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBoxRec_BoxType.Size = New System.Drawing.Size(248, 21)
            Me.cboBoxRec_BoxType.TabIndex = 0
            Me.cboBoxRec_BoxType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 9." & _
            "75pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Styl" & _
            "e1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contro" & _
            "l;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Styl" & _
            "e10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.List" & _
            "BoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptio" & _
            "nHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
            "up=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><W" & _
            "idth>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Caption" & _
            "Style parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /" & _
            "><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style" & _
            "11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hi" & _
            "ghlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRow" & _
            "Style parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector""" & _
            " me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""No" & _
            "rmal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style par" & _
            "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
            "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
            "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
            "=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" m" & _
            "e=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Captio" & _
            "n"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplit" & _
            "s><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label47
            '
            Me.Label47.BackColor = System.Drawing.Color.Transparent
            Me.Label47.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label47.ForeColor = System.Drawing.Color.Black
            Me.Label47.Location = New System.Drawing.Point(40, 0)
            Me.Label47.Name = "Label47"
            Me.Label47.Size = New System.Drawing.Size(80, 16)
            Me.Label47.TabIndex = 91
            Me.Label47.Text = "Box Type :"
            Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgBoxRec_MissingInEDIUnits
            '
            Me.dbgBoxRec_MissingInEDIUnits.AllowUpdate = False
            Me.dbgBoxRec_MissingInEDIUnits.AlternatingRows = True
            Me.dbgBoxRec_MissingInEDIUnits.FilterBar = True
            Me.dbgBoxRec_MissingInEDIUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBoxRec_MissingInEDIUnits.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dbgBoxRec_MissingInEDIUnits.Location = New System.Drawing.Point(440, 176)
            Me.dbgBoxRec_MissingInEDIUnits.Name = "dbgBoxRec_MissingInEDIUnits"
            Me.dbgBoxRec_MissingInEDIUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBoxRec_MissingInEDIUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBoxRec_MissingInEDIUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgBoxRec_MissingInEDIUnits.Size = New System.Drawing.Size(200, 296)
            Me.dbgBoxRec_MissingInEDIUnits.TabIndex = 118
            Me.dbgBoxRec_MissingInEDIUnits.TabStop = False
            Me.dbgBoxRec_MissingInEDIUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "92</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 196, 292<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 196, 292</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'btnBoxRec_Receive
            '
            Me.btnBoxRec_Receive.BackColor = System.Drawing.Color.Green
            Me.btnBoxRec_Receive.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBoxRec_Receive.ForeColor = System.Drawing.Color.White
            Me.btnBoxRec_Receive.Location = New System.Drawing.Point(224, 480)
            Me.btnBoxRec_Receive.Name = "btnBoxRec_Receive"
            Me.btnBoxRec_Receive.Size = New System.Drawing.Size(200, 24)
            Me.btnBoxRec_Receive.TabIndex = 5
            Me.btnBoxRec_Receive.Text = "Receive"
            Me.btnBoxRec_Receive.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.btnBoxRec_Receive.Visible = False
            '
            'dbgBoxRec_NotReceivedUnits
            '
            Me.dbgBoxRec_NotReceivedUnits.AllowUpdate = False
            Me.dbgBoxRec_NotReceivedUnits.AlternatingRows = True
            Me.dbgBoxRec_NotReceivedUnits.FilterBar = True
            Me.dbgBoxRec_NotReceivedUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBoxRec_NotReceivedUnits.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.dbgBoxRec_NotReceivedUnits.Location = New System.Drawing.Point(224, 176)
            Me.dbgBoxRec_NotReceivedUnits.Name = "dbgBoxRec_NotReceivedUnits"
            Me.dbgBoxRec_NotReceivedUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBoxRec_NotReceivedUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBoxRec_NotReceivedUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgBoxRec_NotReceivedUnits.Size = New System.Drawing.Size(200, 296)
            Me.dbgBoxRec_NotReceivedUnits.TabIndex = 6
            Me.dbgBoxRec_NotReceivedUnits.TabStop = False
            Me.dbgBoxRec_NotReceivedUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "92</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 196, 292<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 196, 292</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'dbgBoxRec_ReceivedUnits
            '
            Me.dbgBoxRec_ReceivedUnits.AllowUpdate = False
            Me.dbgBoxRec_ReceivedUnits.AlternatingRows = True
            Me.dbgBoxRec_ReceivedUnits.FilterBar = True
            Me.dbgBoxRec_ReceivedUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBoxRec_ReceivedUnits.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.dbgBoxRec_ReceivedUnits.Location = New System.Drawing.Point(8, 176)
            Me.dbgBoxRec_ReceivedUnits.Name = "dbgBoxRec_ReceivedUnits"
            Me.dbgBoxRec_ReceivedUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBoxRec_ReceivedUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBoxRec_ReceivedUnits.PreviewInfo.ZoomFactor = 75
            Me.dbgBoxRec_ReceivedUnits.Size = New System.Drawing.Size(200, 296)
            Me.dbgBoxRec_ReceivedUnits.TabIndex = 5
            Me.dbgBoxRec_ReceivedUnits.TabStop = False
            Me.dbgBoxRec_ReceivedUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "92</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 196, 292<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 196, 292</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'dbgBoxRec_ViewUnitsOnOrder
            '
            Me.dbgBoxRec_ViewUnitsOnOrder.AllowUpdate = False
            Me.dbgBoxRec_ViewUnitsOnOrder.AlternatingRows = True
            Me.dbgBoxRec_ViewUnitsOnOrder.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgBoxRec_ViewUnitsOnOrder.FilterBar = True
            Me.dbgBoxRec_ViewUnitsOnOrder.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBoxRec_ViewUnitsOnOrder.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.dbgBoxRec_ViewUnitsOnOrder.Location = New System.Drawing.Point(656, 176)
            Me.dbgBoxRec_ViewUnitsOnOrder.Name = "dbgBoxRec_ViewUnitsOnOrder"
            Me.dbgBoxRec_ViewUnitsOnOrder.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBoxRec_ViewUnitsOnOrder.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBoxRec_ViewUnitsOnOrder.PreviewInfo.ZoomFactor = 75
            Me.dbgBoxRec_ViewUnitsOnOrder.Size = New System.Drawing.Size(312, 296)
            Me.dbgBoxRec_ViewUnitsOnOrder.TabIndex = 116
            Me.dbgBoxRec_ViewUnitsOnOrder.TabStop = False
            Me.dbgBoxRec_ViewUnitsOnOrder.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "92</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 308, 292<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 308, 292</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'Panel4
            '
            Me.Panel4.BackColor = System.Drawing.Color.Black
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBoxRec_RefreshRecNo, Me.Label26, Me.lblBoxRec_Extra, Me.Label31, Me.lblBoxRec_FileQty, Me.Label35, Me.txtBoxRec_Rcvd})
            Me.Panel4.Location = New System.Drawing.Point(384, 8)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(310, 160)
            Me.Panel4.TabIndex = 10
            '
            'btnBoxRec_RefreshRecNo
            '
            Me.btnBoxRec_RefreshRecNo.BackColor = System.Drawing.Color.SteelBlue
            Me.btnBoxRec_RefreshRecNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBoxRec_RefreshRecNo.ForeColor = System.Drawing.Color.White
            Me.btnBoxRec_RefreshRecNo.Location = New System.Drawing.Point(216, 120)
            Me.btnBoxRec_RefreshRecNo.Name = "btnBoxRec_RefreshRecNo"
            Me.btnBoxRec_RefreshRecNo.Size = New System.Drawing.Size(88, 24)
            Me.btnBoxRec_RefreshRecNo.TabIndex = 1
            Me.btnBoxRec_RefreshRecNo.Text = "Refresh"
            '
            'Label26
            '
            Me.Label26.BackColor = System.Drawing.Color.Transparent
            Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label26.ForeColor = System.Drawing.Color.Lime
            Me.Label26.Location = New System.Drawing.Point(0, 72)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(224, 31)
            Me.Label26.TabIndex = 89
            Me.Label26.Text = "Total Received :"
            Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxRec_Extra
            '
            Me.lblBoxRec_Extra.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxRec_Extra.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxRec_Extra.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxRec_Extra.Location = New System.Drawing.Point(224, 32)
            Me.lblBoxRec_Extra.Name = "lblBoxRec_Extra"
            Me.lblBoxRec_Extra.Size = New System.Drawing.Size(80, 31)
            Me.lblBoxRec_Extra.TabIndex = 88
            Me.lblBoxRec_Extra.Text = "0"
            Me.lblBoxRec_Extra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label31
            '
            Me.Label31.BackColor = System.Drawing.Color.Transparent
            Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label31.ForeColor = System.Drawing.Color.Lime
            Me.Label31.Location = New System.Drawing.Point(16, 32)
            Me.Label31.Name = "Label31"
            Me.Label31.Size = New System.Drawing.Size(208, 31)
            Me.Label31.TabIndex = 87
            Me.Label31.Text = "Extra Qty :"
            Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxRec_FileQty
            '
            Me.lblBoxRec_FileQty.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxRec_FileQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxRec_FileQty.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxRec_FileQty.Location = New System.Drawing.Point(224, 0)
            Me.lblBoxRec_FileQty.Name = "lblBoxRec_FileQty"
            Me.lblBoxRec_FileQty.Size = New System.Drawing.Size(80, 24)
            Me.lblBoxRec_FileQty.TabIndex = 84
            Me.lblBoxRec_FileQty.Text = "0"
            Me.lblBoxRec_FileQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label35
            '
            Me.Label35.BackColor = System.Drawing.Color.Transparent
            Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label35.ForeColor = System.Drawing.Color.Lime
            Me.Label35.Location = New System.Drawing.Point(16, 0)
            Me.Label35.Name = "Label35"
            Me.Label35.Size = New System.Drawing.Size(208, 24)
            Me.Label35.TabIndex = 83
            Me.Label35.Text = "File Qty :"
            Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBoxRec_Rcvd
            '
            Me.txtBoxRec_Rcvd.BackColor = System.Drawing.Color.Black
            Me.txtBoxRec_Rcvd.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtBoxRec_Rcvd.Enabled = False
            Me.txtBoxRec_Rcvd.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxRec_Rcvd.ForeColor = System.Drawing.Color.Lime
            Me.txtBoxRec_Rcvd.Location = New System.Drawing.Point(221, 72)
            Me.txtBoxRec_Rcvd.Name = "txtBoxRec_Rcvd"
            Me.txtBoxRec_Rcvd.Size = New System.Drawing.Size(80, 31)
            Me.txtBoxRec_Rcvd.TabIndex = 112
            Me.txtBoxRec_Rcvd.Text = "0"
            Me.txtBoxRec_Rcvd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'btnBoxRec_ViewReceivedUnits
            '
            Me.btnBoxRec_ViewReceivedUnits.BackColor = System.Drawing.Color.SteelBlue
            Me.btnBoxRec_ViewReceivedUnits.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBoxRec_ViewReceivedUnits.ForeColor = System.Drawing.Color.White
            Me.btnBoxRec_ViewReceivedUnits.Location = New System.Drawing.Point(704, 72)
            Me.btnBoxRec_ViewReceivedUnits.Name = "btnBoxRec_ViewReceivedUnits"
            Me.btnBoxRec_ViewReceivedUnits.Size = New System.Drawing.Size(136, 26)
            Me.btnBoxRec_ViewReceivedUnits.TabIndex = 8
            Me.btnBoxRec_ViewReceivedUnits.Text = "View Received Units"
            Me.btnBoxRec_ViewReceivedUnits.Visible = False
            '
            'btnBoxRec_ReprintBoxLabel
            '
            Me.btnBoxRec_ReprintBoxLabel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnBoxRec_ReprintBoxLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBoxRec_ReprintBoxLabel.ForeColor = System.Drawing.Color.White
            Me.btnBoxRec_ReprintBoxLabel.Location = New System.Drawing.Point(704, 8)
            Me.btnBoxRec_ReprintBoxLabel.Name = "btnBoxRec_ReprintBoxLabel"
            Me.btnBoxRec_ReprintBoxLabel.Size = New System.Drawing.Size(136, 26)
            Me.btnBoxRec_ReprintBoxLabel.TabIndex = 6
            Me.btnBoxRec_ReprintBoxLabel.Text = "Reprint Box Label"
            '
            'btnBoxRec_CloseRMA
            '
            Me.btnBoxRec_CloseRMA.BackColor = System.Drawing.Color.Navy
            Me.btnBoxRec_CloseRMA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBoxRec_CloseRMA.ForeColor = System.Drawing.Color.White
            Me.btnBoxRec_CloseRMA.Location = New System.Drawing.Point(704, 40)
            Me.btnBoxRec_CloseRMA.Name = "btnBoxRec_CloseRMA"
            Me.btnBoxRec_CloseRMA.Size = New System.Drawing.Size(136, 24)
            Me.btnBoxRec_CloseRMA.TabIndex = 7
            Me.btnBoxRec_CloseRMA.Text = "CLOSE ORDER"
            Me.btnBoxRec_CloseRMA.Visible = False
            '
            'btnBoxRec_WaitingToBeRec
            '
            Me.btnBoxRec_WaitingToBeRec.BackColor = System.Drawing.Color.SteelBlue
            Me.btnBoxRec_WaitingToBeRec.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBoxRec_WaitingToBeRec.ForeColor = System.Drawing.Color.White
            Me.btnBoxRec_WaitingToBeRec.Location = New System.Drawing.Point(704, 104)
            Me.btnBoxRec_WaitingToBeRec.Name = "btnBoxRec_WaitingToBeRec"
            Me.btnBoxRec_WaitingToBeRec.Size = New System.Drawing.Size(136, 37)
            Me.btnBoxRec_WaitingToBeRec.TabIndex = 9
            Me.btnBoxRec_WaitingToBeRec.Text = "View To Be Receviced Units"
            Me.btnBoxRec_WaitingToBeRec.Visible = False
            '
            'Label19
            '
            Me.Label19.BackColor = System.Drawing.Color.Transparent
            Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label19.ForeColor = System.Drawing.Color.Black
            Me.Label19.Location = New System.Drawing.Point(8, 60)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(112, 21)
            Me.Label19.TabIndex = 90
            Me.Label19.Text = "Box Disposition :"
            Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label50
            '
            Me.Label50.BackColor = System.Drawing.Color.Transparent
            Me.Label50.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label50.ForeColor = System.Drawing.Color.Black
            Me.Label50.Location = New System.Drawing.Point(8, 88)
            Me.Label50.Name = "Label50"
            Me.Label50.Size = New System.Drawing.Size(114, 16)
            Me.Label50.TabIndex = 89
            Me.Label50.Text = "Dock Rec Date :"
            Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxRec_Disposition
            '
            Me.lblBoxRec_Disposition.BackColor = System.Drawing.Color.White
            Me.lblBoxRec_Disposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxRec_Disposition.ForeColor = System.Drawing.Color.Blue
            Me.lblBoxRec_Disposition.Location = New System.Drawing.Point(128, 64)
            Me.lblBoxRec_Disposition.Name = "lblBoxRec_Disposition"
            Me.lblBoxRec_Disposition.Size = New System.Drawing.Size(248, 16)
            Me.lblBoxRec_Disposition.TabIndex = 91
            Me.lblBoxRec_Disposition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label22
            '
            Me.Label22.BackColor = System.Drawing.Color.Transparent
            Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.Black
            Me.Label22.Location = New System.Drawing.Point(8, 8)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(112, 16)
            Me.Label22.TabIndex = 83
            Me.Label22.Text = "Order Number :"
            Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpBoxRec_DockRecDate
            '
            Me.dtpBoxRec_DockRecDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpBoxRec_DockRecDate.Location = New System.Drawing.Point(128, 88)
            Me.dtpBoxRec_DockRecDate.Name = "dtpBoxRec_DockRecDate"
            Me.dtpBoxRec_DockRecDate.Size = New System.Drawing.Size(248, 20)
            Me.dtpBoxRec_DockRecDate.TabIndex = 2
            '
            'lblBoxRec_Model
            '
            Me.lblBoxRec_Model.BackColor = System.Drawing.Color.White
            Me.lblBoxRec_Model.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxRec_Model.ForeColor = System.Drawing.Color.Blue
            Me.lblBoxRec_Model.Location = New System.Drawing.Point(128, 40)
            Me.lblBoxRec_Model.Name = "lblBoxRec_Model"
            Me.lblBoxRec_Model.Size = New System.Drawing.Size(248, 16)
            Me.lblBoxRec_Model.TabIndex = 86
            Me.lblBoxRec_Model.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label25
            '
            Me.Label25.BackColor = System.Drawing.Color.Transparent
            Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label25.ForeColor = System.Drawing.Color.Black
            Me.Label25.Location = New System.Drawing.Point(64, 32)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(56, 21)
            Me.Label25.TabIndex = 88
            Me.Label25.Text = "Model :"
            Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboBoxRec_OpenOrders
            '
            Me.cboBoxRec_OpenOrders.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBoxRec_OpenOrders.AutoCompletion = True
            Me.cboBoxRec_OpenOrders.AutoDropDown = True
            Me.cboBoxRec_OpenOrders.AutoSelect = True
            Me.cboBoxRec_OpenOrders.Caption = ""
            Me.cboBoxRec_OpenOrders.CaptionHeight = 17
            Me.cboBoxRec_OpenOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBoxRec_OpenOrders.ColumnCaptionHeight = 17
            Me.cboBoxRec_OpenOrders.ColumnFooterHeight = 17
            Me.cboBoxRec_OpenOrders.ColumnHeaders = False
            Me.cboBoxRec_OpenOrders.ContentHeight = 15
            Me.cboBoxRec_OpenOrders.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBoxRec_OpenOrders.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBoxRec_OpenOrders.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBoxRec_OpenOrders.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBoxRec_OpenOrders.EditorHeight = 15
            Me.cboBoxRec_OpenOrders.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
            Me.cboBoxRec_OpenOrders.ItemHeight = 15
            Me.cboBoxRec_OpenOrders.Location = New System.Drawing.Point(128, 8)
            Me.cboBoxRec_OpenOrders.MatchEntryTimeout = CType(2000, Long)
            Me.cboBoxRec_OpenOrders.MaxDropDownItems = CType(10, Short)
            Me.cboBoxRec_OpenOrders.MaxLength = 32767
            Me.cboBoxRec_OpenOrders.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBoxRec_OpenOrders.Name = "cboBoxRec_OpenOrders"
            Me.cboBoxRec_OpenOrders.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBoxRec_OpenOrders.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBoxRec_OpenOrders.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBoxRec_OpenOrders.Size = New System.Drawing.Size(248, 21)
            Me.cboBoxRec_OpenOrders.TabIndex = 1
            Me.cboBoxRec_OpenOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnBoxRec_Clear
            '
            Me.btnBoxRec_Clear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnBoxRec_Clear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBoxRec_Clear.ForeColor = System.Drawing.Color.White
            Me.btnBoxRec_Clear.Location = New System.Drawing.Point(440, 480)
            Me.btnBoxRec_Clear.Name = "btnBoxRec_Clear"
            Me.btnBoxRec_Clear.Size = New System.Drawing.Size(200, 24)
            Me.btnBoxRec_Clear.TabIndex = 119
            Me.btnBoxRec_Clear.Text = "Clear IMEIs"
            '
            'tpDicrepancyReceiving
            '
            Me.tpDicrepancyReceiving.BackColor = System.Drawing.Color.SteelBlue
            Me.tpDicrepancyReceiving.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDisRec})
            Me.tpDicrepancyReceiving.Location = New System.Drawing.Point(4, 22)
            Me.tpDicrepancyReceiving.Name = "tpDicrepancyReceiving"
            Me.tpDicrepancyReceiving.Size = New System.Drawing.Size(976, 518)
            Me.tpDicrepancyReceiving.TabIndex = 1
            Me.tpDicrepancyReceiving.Text = "Discrepancy Receiving"
            '
            'pnlDisRec
            '
            Me.pnlDisRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnViewWFMBox, Me.chkBoxWFM, Me.GroupBox2, Me.btnSearchHistory, Me.chkNoEDIDev944, Me.Label17, Me.GroupBox3, Me.GroupBox1, Me.pnlHistoryByRecptDate, Me.Label20, Me.cboDiscrepancyOrder, Me.txtDiscrepancyIMEI, Me.Label15, Me.dbgDisRecHistory, Me.rbtnHistoryByRecptDate, Me.rbtnHistoryByIMEI, Me.pnlHistoryByIMEI, Me.lblDiscWrtyStatus, Me.cboDiscModels, Me.txtWFMBox})
            Me.pnlDisRec.Location = New System.Drawing.Point(8, 0)
            Me.pnlDisRec.Name = "pnlDisRec"
            Me.pnlDisRec.Size = New System.Drawing.Size(952, 536)
            Me.pnlDisRec.TabIndex = 104
            Me.pnlDisRec.Visible = False
            '
            'btnViewWFMBox
            '
            Me.btnViewWFMBox.BackColor = System.Drawing.Color.Green
            Me.btnViewWFMBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnViewWFMBox.ForeColor = System.Drawing.Color.White
            Me.btnViewWFMBox.Location = New System.Drawing.Point(690, 40)
            Me.btnViewWFMBox.Name = "btnViewWFMBox"
            Me.btnViewWFMBox.Size = New System.Drawing.Size(48, 24)
            Me.btnViewWFMBox.TabIndex = 106
            Me.btnViewWFMBox.Text = "View"
            '
            'chkBoxWFM
            '
            Me.chkBoxWFM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxWFM.ForeColor = System.Drawing.Color.White
            Me.chkBoxWFM.Location = New System.Drawing.Point(264, 38)
            Me.chkBoxWFM.Name = "chkBoxWFM"
            Me.chkBoxWFM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkBoxWFM.Size = New System.Drawing.Size(96, 23)
            Me.chkBoxWFM.TabIndex = 104
            Me.chkBoxWFM.Tag = "5654"
            Me.chkBoxWFM.Text = "  WFM by Box"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseOWBox, Me.Label21, Me.lblOutWrtyBoxQty_Disc, Me.lblOutWrtyBoxID_Disc})
            Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(664, 72)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(272, 64)
            Me.GroupBox2.TabIndex = 7
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Out of Warranty"
            '
            'btnCloseOWBox
            '
            Me.btnCloseOWBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseOWBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseOWBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseOWBox.Location = New System.Drawing.Point(200, 24)
            Me.btnCloseOWBox.Name = "btnCloseOWBox"
            Me.btnCloseOWBox.Size = New System.Drawing.Size(64, 32)
            Me.btnCloseOWBox.TabIndex = 1
            Me.btnCloseOWBox.Text = "Close Box"
            '
            'Label21
            '
            Me.Label21.BackColor = System.Drawing.Color.Black
            Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.ForeColor = System.Drawing.Color.Lime
            Me.Label21.Location = New System.Drawing.Point(8, 39)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(40, 16)
            Me.Label21.TabIndex = 86
            Me.Label21.Text = "Qty:"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblOutWrtyBoxQty_Disc
            '
            Me.lblOutWrtyBoxQty_Disc.BackColor = System.Drawing.Color.Black
            Me.lblOutWrtyBoxQty_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutWrtyBoxQty_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblOutWrtyBoxQty_Disc.Location = New System.Drawing.Point(48, 39)
            Me.lblOutWrtyBoxQty_Disc.Name = "lblOutWrtyBoxQty_Disc"
            Me.lblOutWrtyBoxQty_Disc.Size = New System.Drawing.Size(144, 16)
            Me.lblOutWrtyBoxQty_Disc.TabIndex = 84
            Me.lblOutWrtyBoxQty_Disc.Text = "0"
            Me.lblOutWrtyBoxQty_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblOutWrtyBoxID_Disc
            '
            Me.lblOutWrtyBoxID_Disc.BackColor = System.Drawing.Color.Black
            Me.lblOutWrtyBoxID_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutWrtyBoxID_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblOutWrtyBoxID_Disc.Location = New System.Drawing.Point(8, 19)
            Me.lblOutWrtyBoxID_Disc.Name = "lblOutWrtyBoxID_Disc"
            Me.lblOutWrtyBoxID_Disc.Size = New System.Drawing.Size(184, 16)
            Me.lblOutWrtyBoxID_Disc.TabIndex = 85
            Me.lblOutWrtyBoxID_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSearchHistory
            '
            Me.btnSearchHistory.BackColor = System.Drawing.Color.Green
            Me.btnSearchHistory.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSearchHistory.ForeColor = System.Drawing.Color.White
            Me.btnSearchHistory.Location = New System.Drawing.Point(864, 152)
            Me.btnSearchHistory.Name = "btnSearchHistory"
            Me.btnSearchHistory.Size = New System.Drawing.Size(64, 32)
            Me.btnSearchHistory.TabIndex = 11
            Me.btnSearchHistory.Text = "Search"
            '
            'chkNoEDIDev944
            '
            Me.chkNoEDIDev944.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoEDIDev944.ForeColor = System.Drawing.Color.Red
            Me.chkNoEDIDev944.Location = New System.Drawing.Point(38, 40)
            Me.chkNoEDIDev944.Name = "chkNoEDIDev944"
            Me.chkNoEDIDev944.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkNoEDIDev944.Size = New System.Drawing.Size(128, 24)
            Me.chkNoEDIDev944.TabIndex = 3
            Me.chkNoEDIDev944.Tag = "5654"
            Me.chkNoEDIDev944.Text = "  Exclude EDI"
            '
            'Label17
            '
            Me.Label17.BackColor = System.Drawing.Color.Transparent
            Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(24, 8)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(120, 21)
            Me.Label17.TabIndex = 93
            Me.Label17.Text = "Order Number :"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseIWBox, Me.Label24, Me.lblInWrtyBoxQty_Disc, Me.lblInWrtyBoxID_Disc})
            Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox3.ForeColor = System.Drawing.Color.White
            Me.GroupBox3.Location = New System.Drawing.Point(8, 72)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(272, 64)
            Me.GroupBox3.TabIndex = 5
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "In Warranty"
            '
            'btnCloseIWBox
            '
            Me.btnCloseIWBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseIWBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseIWBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseIWBox.Location = New System.Drawing.Point(200, 22)
            Me.btnCloseIWBox.Name = "btnCloseIWBox"
            Me.btnCloseIWBox.Size = New System.Drawing.Size(64, 32)
            Me.btnCloseIWBox.TabIndex = 1
            Me.btnCloseIWBox.Text = "Close Box"
            '
            'Label24
            '
            Me.Label24.BackColor = System.Drawing.Color.Black
            Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label24.ForeColor = System.Drawing.Color.Lime
            Me.Label24.Location = New System.Drawing.Point(7, 39)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(41, 16)
            Me.Label24.TabIndex = 86
            Me.Label24.Text = "Qty:"
            Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblInWrtyBoxQty_Disc
            '
            Me.lblInWrtyBoxQty_Disc.BackColor = System.Drawing.Color.Black
            Me.lblInWrtyBoxQty_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInWrtyBoxQty_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblInWrtyBoxQty_Disc.Location = New System.Drawing.Point(48, 39)
            Me.lblInWrtyBoxQty_Disc.Name = "lblInWrtyBoxQty_Disc"
            Me.lblInWrtyBoxQty_Disc.Size = New System.Drawing.Size(144, 16)
            Me.lblInWrtyBoxQty_Disc.TabIndex = 84
            Me.lblInWrtyBoxQty_Disc.Text = "0"
            Me.lblInWrtyBoxQty_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblInWrtyBoxID_Disc
            '
            Me.lblInWrtyBoxID_Disc.BackColor = System.Drawing.Color.Black
            Me.lblInWrtyBoxID_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInWrtyBoxID_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblInWrtyBoxID_Disc.Location = New System.Drawing.Point(7, 19)
            Me.lblInWrtyBoxID_Disc.Name = "lblInWrtyBoxID_Disc"
            Me.lblInWrtyBoxID_Disc.Size = New System.Drawing.Size(185, 16)
            Me.lblInWrtyBoxID_Disc.TabIndex = 85
            Me.lblInWrtyBoxID_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseIWEBox, Me.Label16, Me.lblWrtyExpediteQty_Disc, Me.lblWrtyExpedite_Disc})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(336, 72)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(272, 64)
            Me.GroupBox1.TabIndex = 6
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Warranty Expedite"
            '
            'btnCloseIWEBox
            '
            Me.btnCloseIWEBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseIWEBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseIWEBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseIWEBox.Location = New System.Drawing.Point(200, 24)
            Me.btnCloseIWEBox.Name = "btnCloseIWEBox"
            Me.btnCloseIWEBox.Size = New System.Drawing.Size(64, 32)
            Me.btnCloseIWEBox.TabIndex = 1
            Me.btnCloseIWEBox.Text = "Close Box"
            '
            'Label16
            '
            Me.Label16.BackColor = System.Drawing.Color.Black
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Lime
            Me.Label16.Location = New System.Drawing.Point(7, 39)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(41, 16)
            Me.Label16.TabIndex = 86
            Me.Label16.Text = "Qty:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWrtyExpediteQty_Disc
            '
            Me.lblWrtyExpediteQty_Disc.BackColor = System.Drawing.Color.Black
            Me.lblWrtyExpediteQty_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyExpediteQty_Disc.ForeColor = System.Drawing.Color.Lime
            Me.lblWrtyExpediteQty_Disc.Location = New System.Drawing.Point(48, 39)
            Me.lblWrtyExpediteQty_Disc.Name = "lblWrtyExpediteQty_Disc"
            Me.lblWrtyExpediteQty_Disc.Size = New System.Drawing.Size(144, 16)
            Me.lblWrtyExpediteQty_Disc.TabIndex = 84
            Me.lblWrtyExpediteQty_Disc.Text = "0"
            Me.lblWrtyExpediteQty_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWrtyExpedite_Disc
            '
            Me.lblWrtyExpedite_Disc.BackColor = System.Drawing.Color.Black
            Me.lblWrtyExpedite_Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyExpedite_Disc.ForeColor = System.Drawing.Color.Red
            Me.lblWrtyExpedite_Disc.Location = New System.Drawing.Point(7, 19)
            Me.lblWrtyExpedite_Disc.Name = "lblWrtyExpedite_Disc"
            Me.lblWrtyExpedite_Disc.Size = New System.Drawing.Size(185, 16)
            Me.lblWrtyExpedite_Disc.TabIndex = 85
            Me.lblWrtyExpedite_Disc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pnlHistoryByRecptDate
            '
            Me.pnlHistoryByRecptDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpHistoryByEndDate, Me.Label29, Me.dtpHistoryByStartDate, Me.Label28})
            Me.pnlHistoryByRecptDate.Location = New System.Drawing.Point(424, 144)
            Me.pnlHistoryByRecptDate.Name = "pnlHistoryByRecptDate"
            Me.pnlHistoryByRecptDate.Size = New System.Drawing.Size(432, 40)
            Me.pnlHistoryByRecptDate.TabIndex = 10
            Me.pnlHistoryByRecptDate.Visible = False
            '
            'dtpHistoryByEndDate
            '
            Me.dtpHistoryByEndDate.Location = New System.Drawing.Point(224, 17)
            Me.dtpHistoryByEndDate.Name = "dtpHistoryByEndDate"
            Me.dtpHistoryByEndDate.TabIndex = 2
            '
            'Label29
            '
            Me.Label29.BackColor = System.Drawing.Color.Transparent
            Me.Label29.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label29.ForeColor = System.Drawing.Color.White
            Me.Label29.Location = New System.Drawing.Point(224, 1)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(96, 16)
            Me.Label29.TabIndex = 109
            Me.Label29.Text = "End :"
            Me.Label29.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'dtpHistoryByStartDate
            '
            Me.dtpHistoryByStartDate.Location = New System.Drawing.Point(0, 17)
            Me.dtpHistoryByStartDate.Name = "dtpHistoryByStartDate"
            Me.dtpHistoryByStartDate.TabIndex = 1
            '
            'Label28
            '
            Me.Label28.BackColor = System.Drawing.Color.Transparent
            Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label28.ForeColor = System.Drawing.Color.White
            Me.Label28.Location = New System.Drawing.Point(0, 1)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(96, 16)
            Me.Label28.TabIndex = 107
            Me.Label28.Text = "Start :"
            Me.Label28.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label20
            '
            Me.Label20.BackColor = System.Drawing.Color.Transparent
            Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.White
            Me.Label20.Location = New System.Drawing.Point(392, 8)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(64, 21)
            Me.Label20.TabIndex = 99
            Me.Label20.Text = "Model :"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboDiscrepancyOrder
            '
            Me.cboDiscrepancyOrder.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDiscrepancyOrder.AutoCompletion = True
            Me.cboDiscrepancyOrder.AutoDropDown = True
            Me.cboDiscrepancyOrder.AutoSelect = True
            Me.cboDiscrepancyOrder.Caption = ""
            Me.cboDiscrepancyOrder.CaptionHeight = 17
            Me.cboDiscrepancyOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDiscrepancyOrder.ColumnCaptionHeight = 17
            Me.cboDiscrepancyOrder.ColumnFooterHeight = 17
            Me.cboDiscrepancyOrder.ColumnHeaders = False
            Me.cboDiscrepancyOrder.ContentHeight = 15
            Me.cboDiscrepancyOrder.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDiscrepancyOrder.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDiscrepancyOrder.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDiscrepancyOrder.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDiscrepancyOrder.EditorHeight = 15
            Me.cboDiscrepancyOrder.Images.Add(CType(resources.GetObject("resource.Images9"), System.Drawing.Bitmap))
            Me.cboDiscrepancyOrder.ItemHeight = 15
            Me.cboDiscrepancyOrder.Location = New System.Drawing.Point(152, 8)
            Me.cboDiscrepancyOrder.MatchEntryTimeout = CType(2000, Long)
            Me.cboDiscrepancyOrder.MaxDropDownItems = CType(10, Short)
            Me.cboDiscrepancyOrder.MaxLength = 32767
            Me.cboDiscrepancyOrder.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDiscrepancyOrder.Name = "cboDiscrepancyOrder"
            Me.cboDiscrepancyOrder.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDiscrepancyOrder.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDiscrepancyOrder.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDiscrepancyOrder.Size = New System.Drawing.Size(224, 21)
            Me.cboDiscrepancyOrder.TabIndex = 1
            Me.cboDiscrepancyOrder.Tag = ""
            Me.cboDiscrepancyOrder.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'txtDiscrepancyIMEI
            '
            Me.txtDiscrepancyIMEI.BackColor = System.Drawing.Color.White
            Me.txtDiscrepancyIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDiscrepancyIMEI.Location = New System.Drawing.Point(464, 40)
            Me.txtDiscrepancyIMEI.MaxLength = 25
            Me.txtDiscrepancyIMEI.Name = "txtDiscrepancyIMEI"
            Me.txtDiscrepancyIMEI.Size = New System.Drawing.Size(224, 21)
            Me.txtDiscrepancyIMEI.TabIndex = 4
            Me.txtDiscrepancyIMEI.Text = ""
            '
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.White
            Me.Label15.Location = New System.Drawing.Point(360, 42)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(96, 16)
            Me.Label15.TabIndex = 102
            Me.Label15.Text = "IMEI/MEID :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgDisRecHistory
            '
            Me.dbgDisRecHistory.AllowUpdate = False
            Me.dbgDisRecHistory.AlternatingRows = True
            Me.dbgDisRecHistory.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgDisRecHistory.FilterBar = True
            Me.dbgDisRecHistory.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDisRecHistory.Images.Add(CType(resources.GetObject("resource.Images10"), System.Drawing.Bitmap))
            Me.dbgDisRecHistory.Location = New System.Drawing.Point(8, 200)
            Me.dbgDisRecHistory.Name = "dbgDisRecHistory"
            Me.dbgDisRecHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDisRecHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDisRecHistory.PreviewInfo.ZoomFactor = 75
            Me.dbgDisRecHistory.Size = New System.Drawing.Size(928, 320)
            Me.dbgDisRecHistory.TabIndex = 12
            Me.dbgDisRecHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "16</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 924, 316<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 924, 316</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'rbtnHistoryByRecptDate
            '
            Me.rbtnHistoryByRecptDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnHistoryByRecptDate.ForeColor = System.Drawing.Color.White
            Me.rbtnHistoryByRecptDate.Location = New System.Drawing.Point(136, 160)
            Me.rbtnHistoryByRecptDate.Name = "rbtnHistoryByRecptDate"
            Me.rbtnHistoryByRecptDate.Size = New System.Drawing.Size(168, 24)
            Me.rbtnHistoryByRecptDate.TabIndex = 8
            Me.rbtnHistoryByRecptDate.Text = "History by Received Date"
            '
            'rbtnHistoryByIMEI
            '
            Me.rbtnHistoryByIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnHistoryByIMEI.ForeColor = System.Drawing.Color.White
            Me.rbtnHistoryByIMEI.Location = New System.Drawing.Point(8, 160)
            Me.rbtnHistoryByIMEI.Name = "rbtnHistoryByIMEI"
            Me.rbtnHistoryByIMEI.Size = New System.Drawing.Size(112, 24)
            Me.rbtnHistoryByIMEI.TabIndex = 7
            Me.rbtnHistoryByIMEI.Text = "History by IMEI"
            '
            'pnlHistoryByIMEI
            '
            Me.pnlHistoryByIMEI.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtHistoryByIMEI, Me.Label27})
            Me.pnlHistoryByIMEI.Location = New System.Drawing.Point(312, 144)
            Me.pnlHistoryByIMEI.Name = "pnlHistoryByIMEI"
            Me.pnlHistoryByIMEI.Size = New System.Drawing.Size(192, 40)
            Me.pnlHistoryByIMEI.TabIndex = 9
            Me.pnlHistoryByIMEI.Visible = False
            '
            'txtHistoryByIMEI
            '
            Me.txtHistoryByIMEI.BackColor = System.Drawing.Color.White
            Me.txtHistoryByIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtHistoryByIMEI.Location = New System.Drawing.Point(9, 17)
            Me.txtHistoryByIMEI.MaxLength = 25
            Me.txtHistoryByIMEI.Name = "txtHistoryByIMEI"
            Me.txtHistoryByIMEI.Size = New System.Drawing.Size(168, 21)
            Me.txtHistoryByIMEI.TabIndex = 1
            Me.txtHistoryByIMEI.Text = ""
            '
            'Label27
            '
            Me.Label27.BackColor = System.Drawing.Color.Transparent
            Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label27.ForeColor = System.Drawing.Color.White
            Me.Label27.Location = New System.Drawing.Point(9, 1)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(96, 16)
            Me.Label27.TabIndex = 106
            Me.Label27.Text = "IMEI/MEID :"
            Me.Label27.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblDiscWrtyStatus
            '
            Me.lblDiscWrtyStatus.BackColor = System.Drawing.Color.SteelBlue
            Me.lblDiscWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDiscWrtyStatus.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDiscWrtyStatus.ForeColor = System.Drawing.Color.White
            Me.lblDiscWrtyStatus.Location = New System.Drawing.Point(752, 8)
            Me.lblDiscWrtyStatus.Name = "lblDiscWrtyStatus"
            Me.lblDiscWrtyStatus.Size = New System.Drawing.Size(200, 56)
            Me.lblDiscWrtyStatus.TabIndex = 103
            Me.lblDiscWrtyStatus.Text = "Out of Warranty"
            Me.lblDiscWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboDiscModels
            '
            Me.cboDiscModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDiscModels.AutoCompletion = True
            Me.cboDiscModels.AutoDropDown = True
            Me.cboDiscModels.AutoSelect = True
            Me.cboDiscModels.Caption = ""
            Me.cboDiscModels.CaptionHeight = 17
            Me.cboDiscModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDiscModels.ColumnCaptionHeight = 17
            Me.cboDiscModels.ColumnFooterHeight = 17
            Me.cboDiscModels.ColumnHeaders = False
            Me.cboDiscModels.ContentHeight = 15
            Me.cboDiscModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDiscModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDiscModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDiscModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDiscModels.EditorHeight = 15
            Me.cboDiscModels.Images.Add(CType(resources.GetObject("resource.Images11"), System.Drawing.Bitmap))
            Me.cboDiscModels.ItemHeight = 15
            Me.cboDiscModels.Location = New System.Drawing.Point(464, 8)
            Me.cboDiscModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboDiscModels.MaxDropDownItems = CType(10, Short)
            Me.cboDiscModels.MaxLength = 32767
            Me.cboDiscModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDiscModels.Name = "cboDiscModels"
            Me.cboDiscModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDiscModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDiscModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDiscModels.Size = New System.Drawing.Size(224, 21)
            Me.cboDiscModels.TabIndex = 2
            Me.cboDiscModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'txtWFMBox
            '
            Me.txtWFMBox.BackColor = System.Drawing.Color.White
            Me.txtWFMBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWFMBox.Location = New System.Drawing.Point(616, 64)
            Me.txtWFMBox.MaxLength = 25
            Me.txtWFMBox.Name = "txtWFMBox"
            Me.txtWFMBox.Size = New System.Drawing.Size(32, 21)
            Me.txtWFMBox.TabIndex = 0
            Me.txtWFMBox.Text = ""
            '
            'tpReceiving
            '
            Me.tpReceiving.BackColor = System.Drawing.Color.SteelBlue
            Me.tpReceiving.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.dbgRecUnits, Me.pnlFileInfo, Me.lblMsg, Me.lblHeader, Me.Panel6})
            Me.tpReceiving.Location = New System.Drawing.Point(4, 22)
            Me.tpReceiving.Name = "tpReceiving"
            Me.tpReceiving.Size = New System.Drawing.Size(976, 518)
            Me.tpReceiving.TabIndex = 0
            Me.tpReceiving.Text = "Receiving"
            '
            'tpReceivingWFMBox2TF
            '
            Me.tpReceivingWFMBox2TF.BackColor = System.Drawing.Color.LightSlateGray
            Me.tpReceivingWFMBox2TF.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label32, Me.lblWFMModel, Me.lstWFM2TF_SNsInBox, Me.lblWFM2TF_SN_Count, Me.GroupBox4, Me.chkWFM2TF_NoEDIDev944, Me.Label23, Me.Label18, Me.txtWFM2TF_BoxName, Me.cboWFM2TFModels, Me.cboWFM2TFOrder, Me.Label7})
            Me.tpReceivingWFMBox2TF.Location = New System.Drawing.Point(4, 22)
            Me.tpReceivingWFMBox2TF.Name = "tpReceivingWFMBox2TF"
            Me.tpReceivingWFMBox2TF.Size = New System.Drawing.Size(976, 518)
            Me.tpReceivingWFMBox2TF.TabIndex = 3
            Me.tpReceivingWFMBox2TF.Text = "Receiving WFM Box to TF"
            '
            'Label32
            '
            Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label32.ForeColor = System.Drawing.Color.MediumBlue
            Me.Label32.Location = New System.Drawing.Point(0, 4)
            Me.Label32.Name = "Label32"
            Me.Label32.Size = New System.Drawing.Size(448, 16)
            Me.Label32.TabIndex = 111
            Me.Label32.Text = "Receiving WFM Box To TF"
            '
            'lblWFMModel
            '
            Me.lblWFMModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWFMModel.ForeColor = System.Drawing.Color.White
            Me.lblWFMModel.Location = New System.Drawing.Point(376, 56)
            Me.lblWFMModel.Name = "lblWFMModel"
            Me.lblWFMModel.Size = New System.Drawing.Size(192, 24)
            Me.lblWFMModel.TabIndex = 110
            '
            'lstWFM2TF_SNsInBox
            '
            Me.lstWFM2TF_SNsInBox.Location = New System.Drawing.Point(64, 184)
            Me.lstWFM2TF_SNsInBox.Name = "lstWFM2TF_SNsInBox"
            Me.lstWFM2TF_SNsInBox.Size = New System.Drawing.Size(352, 303)
            Me.lstWFM2TF_SNsInBox.TabIndex = 108
            '
            'lblWFM2TF_SN_Count
            '
            Me.lblWFM2TF_SN_Count.ForeColor = System.Drawing.Color.White
            Me.lblWFM2TF_SN_Count.Location = New System.Drawing.Point(64, 486)
            Me.lblWFM2TF_SN_Count.Name = "lblWFM2TF_SN_Count"
            Me.lblWFM2TF_SN_Count.Size = New System.Drawing.Size(344, 16)
            Me.lblWFM2TF_SN_Count.TabIndex = 109
            Me.lblWFM2TF_SN_Count.Text = "0"
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseWFM2TFBox, Me.Label30, Me.lblWFM2TF_OutWrtyBoxQty, Me.lblWFM2TF_OutWrtyBoxID})
            Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox4.ForeColor = System.Drawing.Color.White
            Me.GroupBox4.Location = New System.Drawing.Point(64, 112)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(352, 64)
            Me.GroupBox4.TabIndex = 107
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Out of Warranty"
            '
            'btnCloseWFM2TFBox
            '
            Me.btnCloseWFM2TFBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseWFM2TFBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWFM2TFBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseWFM2TFBox.Location = New System.Drawing.Point(200, 16)
            Me.btnCloseWFM2TFBox.Name = "btnCloseWFM2TFBox"
            Me.btnCloseWFM2TFBox.Size = New System.Drawing.Size(136, 40)
            Me.btnCloseWFM2TFBox.TabIndex = 1
            Me.btnCloseWFM2TFBox.Text = "Close Box"
            '
            'Label30
            '
            Me.Label30.BackColor = System.Drawing.Color.Black
            Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label30.ForeColor = System.Drawing.Color.Lime
            Me.Label30.Location = New System.Drawing.Point(8, 39)
            Me.Label30.Name = "Label30"
            Me.Label30.Size = New System.Drawing.Size(40, 16)
            Me.Label30.TabIndex = 86
            Me.Label30.Text = "Qty:"
            Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWFM2TF_OutWrtyBoxQty
            '
            Me.lblWFM2TF_OutWrtyBoxQty.BackColor = System.Drawing.Color.Black
            Me.lblWFM2TF_OutWrtyBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWFM2TF_OutWrtyBoxQty.ForeColor = System.Drawing.Color.Lime
            Me.lblWFM2TF_OutWrtyBoxQty.Location = New System.Drawing.Point(48, 39)
            Me.lblWFM2TF_OutWrtyBoxQty.Name = "lblWFM2TF_OutWrtyBoxQty"
            Me.lblWFM2TF_OutWrtyBoxQty.Size = New System.Drawing.Size(144, 16)
            Me.lblWFM2TF_OutWrtyBoxQty.TabIndex = 84
            Me.lblWFM2TF_OutWrtyBoxQty.Text = "0"
            Me.lblWFM2TF_OutWrtyBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWFM2TF_OutWrtyBoxID
            '
            Me.lblWFM2TF_OutWrtyBoxID.BackColor = System.Drawing.Color.Black
            Me.lblWFM2TF_OutWrtyBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWFM2TF_OutWrtyBoxID.ForeColor = System.Drawing.Color.Lime
            Me.lblWFM2TF_OutWrtyBoxID.Location = New System.Drawing.Point(8, 19)
            Me.lblWFM2TF_OutWrtyBoxID.Name = "lblWFM2TF_OutWrtyBoxID"
            Me.lblWFM2TF_OutWrtyBoxID.Size = New System.Drawing.Size(184, 16)
            Me.lblWFM2TF_OutWrtyBoxID.TabIndex = 85
            Me.lblWFM2TF_OutWrtyBoxID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkWFM2TF_NoEDIDev944
            '
            Me.chkWFM2TF_NoEDIDev944.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkWFM2TF_NoEDIDev944.ForeColor = System.Drawing.Color.Red
            Me.chkWFM2TF_NoEDIDev944.Location = New System.Drawing.Point(376, 32)
            Me.chkWFM2TF_NoEDIDev944.Name = "chkWFM2TF_NoEDIDev944"
            Me.chkWFM2TF_NoEDIDev944.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkWFM2TF_NoEDIDev944.Size = New System.Drawing.Size(128, 24)
            Me.chkWFM2TF_NoEDIDev944.TabIndex = 106
            Me.chkWFM2TF_NoEDIDev944.Tag = "5654"
            Me.chkWFM2TF_NoEDIDev944.Text = "  Exclude EDI"
            '
            'Label23
            '
            Me.Label23.BackColor = System.Drawing.Color.Transparent
            Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label23.ForeColor = System.Drawing.Color.White
            Me.Label23.Location = New System.Drawing.Point(40, 56)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(96, 16)
            Me.Label23.TabIndex = 105
            Me.Label23.Text = "TF Model :"
            Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label18
            '
            Me.Label18.BackColor = System.Drawing.Color.Transparent
            Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.White
            Me.Label18.Location = New System.Drawing.Point(40, 88)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(96, 16)
            Me.Label18.TabIndex = 104
            Me.Label18.Text = "WFM Box :"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtWFM2TF_BoxName
            '
            Me.txtWFM2TF_BoxName.BackColor = System.Drawing.Color.White
            Me.txtWFM2TF_BoxName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWFM2TF_BoxName.Location = New System.Drawing.Point(144, 88)
            Me.txtWFM2TF_BoxName.MaxLength = 25
            Me.txtWFM2TF_BoxName.Name = "txtWFM2TF_BoxName"
            Me.txtWFM2TF_BoxName.Size = New System.Drawing.Size(224, 21)
            Me.txtWFM2TF_BoxName.TabIndex = 103
            Me.txtWFM2TF_BoxName.Text = ""
            '
            'cboWFM2TFModels
            '
            Me.cboWFM2TFModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboWFM2TFModels.AutoCompletion = True
            Me.cboWFM2TFModels.AutoDropDown = True
            Me.cboWFM2TFModels.AutoSelect = True
            Me.cboWFM2TFModels.Caption = ""
            Me.cboWFM2TFModels.CaptionHeight = 17
            Me.cboWFM2TFModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboWFM2TFModels.ColumnCaptionHeight = 17
            Me.cboWFM2TFModels.ColumnFooterHeight = 17
            Me.cboWFM2TFModels.ColumnHeaders = False
            Me.cboWFM2TFModels.ContentHeight = 15
            Me.cboWFM2TFModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboWFM2TFModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboWFM2TFModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWFM2TFModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboWFM2TFModels.EditorHeight = 15
            Me.cboWFM2TFModels.Images.Add(CType(resources.GetObject("resource.Images12"), System.Drawing.Bitmap))
            Me.cboWFM2TFModels.ItemHeight = 15
            Me.cboWFM2TFModels.Location = New System.Drawing.Point(144, 56)
            Me.cboWFM2TFModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboWFM2TFModels.MaxDropDownItems = CType(10, Short)
            Me.cboWFM2TFModels.MaxLength = 32767
            Me.cboWFM2TFModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboWFM2TFModels.Name = "cboWFM2TFModels"
            Me.cboWFM2TFModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboWFM2TFModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboWFM2TFModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboWFM2TFModels.Size = New System.Drawing.Size(224, 21)
            Me.cboWFM2TFModels.TabIndex = 95
            Me.cboWFM2TFModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboWFM2TFOrder
            '
            Me.cboWFM2TFOrder.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboWFM2TFOrder.AutoCompletion = True
            Me.cboWFM2TFOrder.AutoDropDown = True
            Me.cboWFM2TFOrder.AutoSelect = True
            Me.cboWFM2TFOrder.Caption = ""
            Me.cboWFM2TFOrder.CaptionHeight = 17
            Me.cboWFM2TFOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboWFM2TFOrder.ColumnCaptionHeight = 17
            Me.cboWFM2TFOrder.ColumnFooterHeight = 17
            Me.cboWFM2TFOrder.ColumnHeaders = False
            Me.cboWFM2TFOrder.ContentHeight = 15
            Me.cboWFM2TFOrder.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboWFM2TFOrder.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboWFM2TFOrder.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWFM2TFOrder.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboWFM2TFOrder.EditorHeight = 15
            Me.cboWFM2TFOrder.Images.Add(CType(resources.GetObject("resource.Images13"), System.Drawing.Bitmap))
            Me.cboWFM2TFOrder.ItemHeight = 15
            Me.cboWFM2TFOrder.Location = New System.Drawing.Point(144, 32)
            Me.cboWFM2TFOrder.MatchEntryTimeout = CType(2000, Long)
            Me.cboWFM2TFOrder.MaxDropDownItems = CType(10, Short)
            Me.cboWFM2TFOrder.MaxLength = 32767
            Me.cboWFM2TFOrder.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboWFM2TFOrder.Name = "cboWFM2TFOrder"
            Me.cboWFM2TFOrder.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboWFM2TFOrder.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboWFM2TFOrder.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboWFM2TFOrder.Size = New System.Drawing.Size(224, 21)
            Me.cboWFM2TFOrder.TabIndex = 94
            Me.cboWFM2TFOrder.Tag = "5654"
            Me.cboWFM2TFOrder.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(16, 32)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(120, 21)
            Me.Label7.TabIndex = 93
            Me.Label7.Text = "Order Number :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'frmRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1000, 574)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.btnLanUseOnly})
            Me.Name = "frmRec"
            Me.Text = "frmRec"
            Me.pnlFileInfo.ResumeLayout(False)
            Me.Panel6.ResumeLayout(False)
            Me.pnlBox.ResumeLayout(False)
            Me.gbInWrtyExpLess30Days.ResumeLayout(False)
            Me.gbOutWrty.ResumeLayout(False)
            Me.grbInWrty.ResumeLayout(False)
            CType(Me.cboBoxType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            CType(Me.cboOpenOrders, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgRecUnits, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpReceivingBox.ResumeLayout(False)
            Me.pnlBoxRec_Box.ResumeLayout(False)
            CType(Me.cboBoxRec_BoxType, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgBoxRec_MissingInEDIUnits, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgBoxRec_NotReceivedUnits, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgBoxRec_ReceivedUnits, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgBoxRec_ViewUnitsOnOrder, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel4.ResumeLayout(False)
            CType(Me.cboBoxRec_OpenOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpDicrepancyReceiving.ResumeLayout(False)
            Me.pnlDisRec.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.pnlHistoryByRecptDate.ResumeLayout(False)
            CType(Me.cboDiscrepancyOrder, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgDisRecHistory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlHistoryByIMEI.ResumeLayout(False)
            CType(Me.cboDiscModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpReceiving.ResumeLayout(False)
            Me.tpReceivingWFMBox2TF.ResumeLayout(False)
            Me.GroupBox4.ResumeLayout(False)
            CType(Me.cboWFM2TFModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboWFM2TFOrder, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Receiving"

		'******************************************************************
		Private Sub frmRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim strSvrDateTime As String = ""
			Dim dt, dt2 As DataTable

			Try
				'Me.btnLanUseOnly.Visible = True

				PSS.Core.Highlight.SetHighLight(Me)

                Me.chkBoxWFM.Checked = False : Me.txtWFMBox.Visible = False : Me.btnViewWFMBox.Visible = False
                Me.chkNoEDIDev944.Checked = False
                Me.chkWFM2TF_NoEDIDev944.Checked = True
                Me.lstWFM2TF_SNsInBox.Visible = False
                Me.lblWFM2TF_SN_Count.Visible = False

                Me.txtWFMBox.Visible = False : Me.chkBoxWFM.Visible = False
                Me.txtWFMBox.Enabled = False : Me.chkBoxWFM.Enabled = False

				'*********************************
				'Load Open Order & Box Type
				'*********************************
				_booLoadDataToCtrl = True
				Me.LoadOpenWorkOrder()

				'Load box Type
				dt = Me._objTFRec.GetBoxTypeFlag()
				Misc.PopulateC1DropDownList(Me.cboBoxType, dt, "Desc", "ID")
				Me.cboBoxType.SelectedValue = 0

				dt2 = New DataTable()
				dt2 = dt.Copy
				Misc.PopulateC1DropDownList(Me.cboBoxRec_BoxType, dt2, "Desc", "ID")
				Me.cboBoxRec_BoxType.SelectedValue = 0
				'*********************************
				strSvrDateTime = Generic.GetMySqlDateTime("%Y-%m-%d")
				Me.dtpDockRecDate.Value = CDate(strSvrDateTime)
				Me.dtpDockRecDate.MaxDate = CDate(strSvrDateTime & " 23:00:00")

				Me.dtpBoxRec_DockRecDate.Value = CDate(strSvrDateTime)
				Me.dtpBoxRec_DockRecDate.MaxDate = CDate(strSvrDateTime & " 23:00:00")
				'*********************************
				'Set Special permissions
				'*********************************
				If PSS.Core.ApplicationUser.GetPermission("TFViewUnRecUnits") > 0 Then _booEligibleToViewUnRecUnits = True
				If PSS.Core.ApplicationUser.GetPermission("TFRecDiscrepancyUnits") > 0 Then _booEligibleToProcessDiscrepancy = True
				If PSS.Core.ApplicationUser.GetPermission("TFRecDiscrUnitsIntoDev944") > 0 Then Me.pnlDisRec.Visible = True
				If PSS.Core.ApplicationUser.GetPermission("TFRecByDevice") > 0 Then Me.tpReceiving.Enabled = True Else Me.tpReceiving.Enabled = False

				'*********************************
				'Get Tracfone Model list
				'*********************************
				Generic.DisposeDT(dt)
				dt = Me._objTFRec.GetTracfoneModels(True)
				Misc.PopulateC1DropDownList(Me.cboDiscModels, dt, "Model_Desc", "Model_ID")
                Me.cboDiscModels.SelectedValue = 0

                Dim dtWFMModels As DataTable
                dtWFMModels = Me._objTFRec.GetTracfoneModels(True)
                Misc.PopulateC1DropDownList(Me.cboWFM2TFModels, dtWFMModels, "Model_Desc", "Model_ID")
                Me.cboWFM2TFModels.SelectedValue = 0 : Me.cboWFM2TFModels.Enabled = False

				'**********************************************
				'Get Tracfone Blanket RMA ( forever open RMA)
				'**********************************************
				Generic.DisposeDT(dt)
				dt = Me._objTFRec.GetDiscrepancyRMA(True)
				Misc.PopulateC1DropDownList(Me.cboDiscrepancyOrder, dt, "WO_CustWO", "WO_ID")
				If dt.Rows.Count = 2 AndAlso dt.Select("WO_ID <> 0").Length > 0 Then Me.cboDiscrepancyOrder.SelectedValue = dt.Select("WO_ID <> 0")(0)("WO_ID")

				If Not IsNothing(Me.cboDiscrepancyOrder.DataSource) AndAlso Me.cboDiscrepancyOrder.SelectedValue > 0 Then PopulateOpenBoxes(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), False)

                Dim dtWFMOrder As DataTable
                dtWFMOrder = Me._objTFRec.GetDiscrepancyRMA(True)
                Misc.PopulateC1DropDownList(Me.cboWFM2TFOrder, dtWFMOrder, "WO_CustWO", "WO_ID")
                If dtWFMOrder.Rows.Count = 2 AndAlso dtWFMOrder.Select("WO_ID <> 0").Length > 0 Then Me.cboWFM2TFOrder.SelectedValue = dtWFMOrder.Select("WO_ID <> 0")(0)("WO_ID")

                '*********************************
                Me.dtpHistoryByStartDate.Value = CDate(strSvrDateTime)
                Me.dtpHistoryByEndDate.MaxDate = CDate(strSvrDateTime)


            Catch ex As Exception
				MessageBox.Show(ex.ToString, "frmRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
				_booLoadDataToCtrl = False
			End Try
		End Sub

		'******************************************************************
		Private Sub LoadOpenWorkOrder()
			Dim dt, dt2 As DataTable
			Try
				'*********************************
				'Load Open Order
				'*********************************
				dt = Me._objTFRec.LoadOpenOrders()
				Misc.PopulateC1DropDownList(Me.cboOpenOrders, dt, "WO_CustWO", "WO_ID")
				Me.cboOpenOrders.SelectedValue = 0
				'*********************************
				dt2 = New DataTable()
				dt2 = dt.Copy
				Misc.PopulateC1DropDownList(Me.cboBoxRec_OpenOrders, dt2, "WO_CustWO", "WO_ID")
				Me.cboBoxRec_OpenOrders.SelectedValue = 0
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'******************************************************************
		Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
			Try
				If Me.cboOpenOrders.SelectedValue > 0 Then
					LoadReceivedData(Me.cboOpenOrders.SelectedValue, Me.dbgRecUnits)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnView_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'******************************************************************
		Private Sub LoadReceivedData(ByVal iWOID As Integer, ByRef dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
			Dim dt As DataTable
			Dim i As Integer

			Try
				dt = Me._objTFRec.GetReceivedDevices(iWOID)

				With dbg
					.DataSource = dt.DefaultView
					.Visible = True
					.AllowFilter = True
					.FilterBar = True
					.Caption = "Received Unit(s)"
					.HeadingStyle.BackColor = Color.Black
					.HeadingStyle.ForeColor = Color.Lime

					For i = 0 To dt.Columns.Count - 1
						.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
						.Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
						.Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
						'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

						If dt.Columns(i).Caption = "SN" Then
							.Splits(0).DisplayColumns(i).Frozen = True
							.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
						ElseIf dt.Columns(i).Caption = "Receipt Date" Then
							.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
						ElseIf dt.Columns(i).Caption = "Model" Or dt.Columns(i).Caption = "Cnt" Then
							.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
						ElseIf dt.Columns(i).Caption = "Device_ID" Then
							.Splits(0).DisplayColumns(i).Visible = False
						Else
							.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
						End If

						If dt.Columns(i).Caption = "Model" Then
							.Splits(0).DisplayColumns(i).Width = 170
						ElseIf dt.Columns(i).Caption = "Cnt" Then
							.Splits(0).DisplayColumns(i).Width = 50
						ElseIf dt.Columns(i).Caption = "Discp Reason" Then
							.Splits(0).DisplayColumns(i).Width = 200
						Else
							.Splits(0).DisplayColumns(i).Width = 120
						End If
					Next i
				End With

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'******************************************************************
		Private Sub btnWaitingToBeRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitingToBeRec.Click
			Try
				If Me.cboOpenOrders.SelectedValue > 0 Then
					LoadWaitingToBeRecData(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), dbgRecUnits)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnView_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'******************************************************************
		Private Sub LoadWaitingToBeRecData(ByVal iOrderID As Integer, ByRef dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
			Dim dt As DataTable
			Dim i As Integer

			Try
				dt = Me._objTFRec.GetToBeReceivedDevices(iOrderID)

				With dbg
					.DataSource = dt.DefaultView
					.Visible = True
					.AllowFilter = True
					.FilterBar = True
					.Caption = "To Be Receviced Unit(s)"
					.HeadingStyle.BackColor = Color.Black
					.HeadingStyle.ForeColor = Color.Lime

					For i = 0 To dt.Columns.Count - 1
						.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
						.Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
						.Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
						'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

						If dt.Columns(i).Caption = "SN" Then
							.Splits(0).DisplayColumns(i).Frozen = True
							.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
						ElseIf dt.Columns(i).Caption = "Item#" Then
							.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
						Else
							.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
							.Splits(0).DisplayColumns(i).Visible = False
						End If

						If dt.Columns(i).Caption = "SN" Then

						ElseIf dt.Columns(i).Caption = "Item#" Then
							.Splits(0).DisplayColumns(i).Width = 200
						End If
					Next i
				End With
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'******************************************************************
		Private Sub btnCloseRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseRMA.Click
			Dim iTotalRecQty, iFileQty, iExtra, iEdiOrderID As Integer
			Dim strOrderType As String = ""
			Dim booResult As Boolean = False

			Try
				If Me.cboOpenOrders.SelectedValue > 0 Then
					strOrderType = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper
					iEdiOrderID = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID")

					iTotalRecQty = 0 : iFileQty = 0 : iExtra = 0

					If strOrderType = "PHONE" Then
						'****************************
						'Refresh Receive quantity
						'****************************
						Me.lblExtra.Text = Me._objTFRec.GetDiscrepancyDevices(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
						Me.txtRcvd.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboOpenOrders.SelectedValue)
						'****************************
					End If

					If Me.txtRcvd.Text.Trim.Length > 0 Then iTotalRecQty = CInt(Me.txtRcvd.Text)
					If Me.lblFileQty.Text.Trim.Length > 0 Then iFileQty = CInt(Me.lblFileQty.Text)
					If Me.lblExtra.Text.Trim > 0 Then iExtra = CInt(Me.lblExtra.Text)

					Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

					booResult = CloseRMA(Me.cboOpenOrders.SelectedValue, iEdiOrderID, strOrderType, iTotalRecQty, iFileQty, iExtra, Me.dtpDockRecDate.Value)
					If booResult Then
						MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						Me.ClearCtrls_GlobalVarsForNewRMA()
						Me.Enabled = True : Me.cboOpenOrders.Focus()
					End If

				End If			 'Order ID > 0
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnCloseRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
			End Try
		End Sub

		'******************************************************************
		Private Function CloseRMA(ByVal iWOID As Integer, ByVal iEdiOrderID As Integer, ByVal strOrderType As String, ByVal iTotalRecQty As Integer, _
							 ByVal iFileQty As Integer, ByVal iExtra As Integer, ByVal dteDockRecDate As Date) As Boolean
			Dim dtMissingUnit As DataTable
			Dim i As Integer = 0
			Dim strDockDate, strSvrDateTime As String
			Dim booDiscrepancy As Boolean = False, booResult As Boolean = False

			Try
				If iWOID = 0 Then
					MessageBox.Show("WO ID is missing for this RMA. Please re-scan RMA again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
				ElseIf iTotalRecQty = 0 Then
					MessageBox.Show("This Work Order is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
				ElseIf ((iFileQty - iTotalRecQty) <> 0 Or iExtra > 0) AndAlso _booEligibleToProcessDiscrepancy = False Then
					MessageBox.Show("This Work Order contains discrepancy unit. Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Else
					'****************************************
					'Get confirmation on discrepancy units
					'****************************************
					If strOrderType = "PHONE" Then
						dtMissingUnit = Me._objTFRec.GetToBeReceivedDevices(iEdiOrderID)
						If dtMissingUnit.Select("DiscrepancyReason <> '' and Device_ID = 0 ").Length > 0 Then
							MessageBox.Show("There is data discrepancy (add extra unit but not receive). Please contact IT. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
							Return False
						End If
					End If

					If _booEligibleToProcessDiscrepancy = False Then
						If (Not IsNothing(dtMissingUnit) AndAlso dtMissingUnit.Rows.Count > 0) Or (iFileQty - iTotalRecQty) <> 0 Or iExtra > 0 Then
							MessageBox.Show("This Work Order contains discrepancy unit. Please contact your supervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
							Exit Function
						End If
					Else
						If Not IsNothing(dtMissingUnit) AndAlso dtMissingUnit.Rows.Count > 0 Then
							booDiscrepancy = True
							If MessageBox.Show(dtMissingUnit.Rows.Count & " unit(s) in this order have not yet received. Would you like to close order and mark them as MISSING UNIT?.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Function
						ElseIf ((iFileQty - iTotalRecQty) <> 0 Or iExtra > 0) Then
							booDiscrepancy = True
							If MessageBox.Show("This Work Order contains discrepancy unit. Would you like to close it?.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Function
						End If
					End If
					'****************************************

					strSvrDateTime = Generic.GetMySqlDateTime("%Y-%m-%d")
					If DateDiff(DateInterval.Day, CDate(strSvrDateTime), dteDockRecDate) > 0 Then
						MessageBox.Show("Invalid Dock Date! Dock Receive date can't be future.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
					ElseIf booDiscrepancy = False AndAlso MessageBox.Show("Are you sure you want to close order?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
						'User canel on Confirm message
					Else
						strDockDate = Format(dteDockRecDate, "yyyy-MM-dd")
						i = Me._objTFRec.CloseWO(iWOID, iTotalRecQty, PSS.Core.ApplicationUser.IDuser, strDockDate, booDiscrepancy, strOrderType)
						If i > 0 Then
							'************************************************
							'Print Warehouse Box Label if work order is PHONE
							'************************************************
							If strOrderType = "PHONE" Then Me._objTFRec.CloseAllOpenWHBox(iEdiOrderID)
							'************************************************

							booResult = True
						End If					'Update return value
					End If				'Validate Dock Date
				End If			  'Validate Order

				Return booResult
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dtMissingUnit)
			End Try
		End Function

		'******************************************************************
		Private Sub ClearCtrls_GlobalVarsForNewRMA()
			Try
				Me._booLoadDataToCtrl = True
				Me.LoadOpenWorkOrder() : _booLoadDataToCtrl = False
				Me.dbgRecUnits.DataSource = Nothing
				Me.txtIMEI.Text = ""
				Me.lblModel.Text = ""
				Me.lblFileQty.Text = ""
				Me.lblExtra.Text = ""
				Me.txtRcvd.Text = ""
				Me.lblInWrtyBoxID.Text = ""
				Me.lblOutWrtyBoxID.Text = ""
				Me.lblInWrtyBoxQty.Text = "0"
				Me.lblOutWrtyBoxQty.Text = "0"
			Catch ex As Exception
				Throw ex
			Finally
				_booLoadDataToCtrl = False
			End Try
		End Sub

		'******************************************************************
		Private Sub cboOpenOrders_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOpenOrders.KeyUp
			Dim dt As DataTable
			Dim strBoxID As String = "", strDockRec As String = ""
			Dim iOrderModelID As Integer = 0
            Dim strArrLstNTF_InboundOrderCustomers As New ArrayList()
            Dim strInboundOrderCustomer As String = ""
            Dim strCustomerItem As String = ""
            Dim dtXModel As DataTable
            Dim iOrderID As Integer = 0

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboOpenOrders.SelectedValue > 0 Then
                        Me.lblXModelDesc.Visible = False : Me._bReceiving_NTF_XModel = False
                        Me._bTriageNeeded = False

                        iOrderModelID = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Model_ID")     ' dt.Rows(0)("Model_ID")

                        'Handle order from FES received as NTF as X Model only-----------------------------------------------------------------
                        strArrLstNTF_InboundOrderCustomers = Me._objTFRec.getNTF_InboundOrderCustomers()
                        strInboundOrderCustomer = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("InboundOrderCustomer")
                        strCustomerItem = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Customer Item #")
                        If strArrLstNTF_InboundOrderCustomers.Contains(strInboundOrderCustomer.Trim.ToUpper) Then
                            dtXModel = Me._objTFRec.getNTF_XModelData(strCustomerItem)
                            If Not dtXModel.Rows.Count > 0 Then
                                MessageBox.Show("No X Model defined in tModel for this " & strCustomerItem, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            ElseIf dtXModel.Rows.Count > 1 Then
                                MessageBox.Show("Duplicated X Model defined in tModel for this " & strCustomerItem, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            Else '=1 
                                iOrderID = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID")
                                If Not iOrderModelID = dtXModel.Rows(0).Item("Model_ID") Then
                                    Me._objTFRec.UpdateNTF_InboundOrderXModel(iOrderID, dtXModel.Rows(0).Item("Model_ID"))
                                    iOrderModelID = dtXModel.Rows(0).Item("Model_ID")
                                End If
                                If dtXModel.Rows(0).Item("IsTriaged") = 1 Then Me._bTriageNeeded = True
                            End If

                            'Repopulate BoxType
                            Dim dtBoxType As DataTable = Me._objTFRec.GetPredefinedBoxType
                            Me.cboBoxType.DataSource = Nothing
                            Misc.PopulateC1DropDownList(Me.cboBoxType, dtBoxType, "Desc", "ID")
                            Me.cboBoxType.SelectedValue = 2

                            Me.lblXModelDesc.Text = "Inbound Order From: " & strInboundOrderCustomer & ", Receive devices as XModel Only"
                            Me.lblXModelDesc.Visible = True

                            Me._bReceiving_NTF_XModel = True
                        End If
                        '-----------------------------------------------------------------------------------------------------------------------

                        Me.lblModel_ID.Text = iOrderModelID
                        Me.lblModel.Text = Generic.GetModelDesc(iOrderModelID)     'dt.Rows(0)("Model_Desc")

                        Me.lblModel.Visible = True
                        Me.lblDisposition.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("IL_No").ToString.Trim.ToUpper
                        If Not Me._bReceiving_NTF_XModel Then
                            Me.lblDisposition.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("IL_No").ToString.Trim.ToUpper
                            If Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper = "PHONE" _
                                AndAlso Me.lblDisposition.Text.StartsWith("COS") = False AndAlso Me.lblModel.Text.Trim.ToUpper.EndsWith("_FUN") = False _
                                Then MessageBox.Show("This order come in as functional failure but assigned to none functional model. Please verify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            If Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper = "PHONE" _
                                AndAlso Me.lblDisposition.Text.StartsWith("COS") = True AndAlso Me.lblModel.Text.Trim.ToUpper.EndsWith("_FUN") = True _
                                Then MessageBox.Show("This order come in as cosmetic but assigned to functional model. Please verify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        Me.lblFileQty.Text = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("WO_Quantity")       'dt.Rows(0)("Model_Desc")
                        Me.lblExtra.Text = Me._objTFRec.GetDiscrepancyDevices(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
                        Me.txtRcvd.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboOpenOrders.SelectedValue)

                        Me.btnCloseRMA.Visible = True
                        If Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper <> "PHONE" Then
                            Me.pnlBox.Visible = False
                            Me.btnView.Visible = False
                            Me.btnWaitingToBeRec.Visible = False
                            Me.txtRcvd.Text = Me.lblFileQty.Text
                            Me.txtRcvd.Enabled = True
                            Me.txtRcvd.SelectAll()
                            Me.txtRcvd.Focus()
                        Else       'Hanset order
                            If Not Me._bReceiving_NTF_XModel Then If Me.lblDisposition.Text.StartsWith("COS") Then Me.cboBoxType.SelectedValue = 0 Else Me.cboBoxType.SelectedValue = 1
                            Me.PopulateOpenBoxes(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), True)
                            Me.pnlBox.Visible = True : Me.btnView.Visible = True
                            If _booEligibleToViewUnRecUnits = True Then Me.btnWaitingToBeRec.Visible = True Else Me.btnWaitingToBeRec.Visible = False
                            Me.txtRcvd.Enabled = False
                            Me.txtRcvd.BackColor = Color.Black : Me.txtRcvd.ForeColor = Color.Lime
                            Me.txtIMEI.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenOrders_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
		End Sub

		'******************************************************************
		Private Sub cboOpenOrders_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenOrders.Enter
			Try
				Me.lblModel.Text = ""
				Me.txtIMEI.Text = ""
				Me.btnCloseRMA.Visible = False
				Me.btnView.Visible = False
				Me.btnWaitingToBeRec.Visible = False
				Me.dbgRecUnits.DataSource = Nothing
				Me.pnlBox.Visible = False
				Me.lblFileQty.Text = ""
				Me.lblExtra.Text = ""
				Me.txtRcvd.Text = ""
				Me.lblMsg.BackColor = Color.SteelBlue
				Me.lblMsg.Text = ""
				Me.dtpDockRecDate.Enabled = True
				Me.lblInWrtyBoxID.Text = ""
				Me.lblOutWrtyBoxID.Text = ""
				Me.lblInWrtyBoxQty.Text = "0"
                Me.lblOutWrtyBoxQty.Text = "0"
                Me.lblXModelDesc.Text = ""
                Me.lblXModelDesc.Visible = False
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cboOpenOrders_Enter", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub PopulateOpenBoxes(ByVal iOrderID As Integer, ByVal booRegOrder As Boolean)
			Dim dt As DataTable
			Dim R1 As DataRow

			Try
				If booRegOrder = True Then
					Me.lblInWrtyBoxID.Text = "" : Me.lblInWrtyBoxQty.Text = 0
					Me.lblWrtyExpedite.Text = "" : Me.lblWrtyExpediteQty.Text = 0
					Me.lblOutWrtyBoxID.Text = "" : Me.lblOutWrtyBoxQty.Text = 0
				Else
					Me.lblInWrtyBoxID.Text = "" : Me.lblInWrtyBoxQty.Text = 0
					Me.lblWrtyExpedite.Text = "" : Me.lblWrtyExpediteQty.Text = 0
					Me.lblOutWrtyBoxID.Text = "" : Me.lblOutWrtyBoxQty.Text = 0
				End If

				dt = Me._objTFRec.GetWarehouseOpenBox(iOrderID)
				If dt.Rows.Count > 0 Then
					If booRegOrder = True Then
						For Each R1 In dt.Rows
							If R1("WarrantyFlag").ToString = "0" Then
								Me.lblOutWrtyBoxID.Text = R1("BoxID")
								Me.lblOutWrtyBoxQty.Text = R1("Qty")
							ElseIf R1("WrtyExpedite").ToString = "1" Then
								Me.lblWrtyExpedite.Text = R1("BoxID")
								Me.lblWrtyExpediteQty.Text = R1("Qty")
							Else
								Me.lblInWrtyBoxID.Text = R1("BoxID")
								Me.lblInWrtyBoxQty.Text = R1("Qty")
							End If
						Next R1
					Else
						For Each R1 In dt.Rows
							If R1("WarrantyFlag").ToString = "0" Then
								Me.lblOutWrtyBoxID_Disc.Text = R1("BoxID")
								Me.lblOutWrtyBoxQty_Disc.Text = R1("Qty")
							ElseIf R1("WrtyExpedite").ToString = "1" Then
								Me.lblWrtyExpedite_Disc.Text = R1("BoxID")
								Me.lblWrtyExpediteQty_Disc.Text = R1("Qty")
							Else
								Me.lblInWrtyBoxID_Disc.Text = R1("BoxID")
								Me.lblInWrtyBoxQty_Disc.Text = R1("Qty")
							End If
						Next R1

						Me.cboDiscModels.SelectedValue = Convert.ToInt32(dt.Rows(0)("Model_ID"))
						Me.cboDiscModels.Enabled = False
					End If
				End If

			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt)
				R1 = Nothing
			End Try
		End Sub

		''******************************************************************
		'Private Sub dbgRecUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgRecUnits.Click
		'    Try
		'        If Me.txtIMEI.Text.Trim.Length > 0 Then Me.ProcessTFSN()
		'    Catch ex As Exception
		'        MessageBox.Show(ex.ToString, "dbgRecUnits_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
		'    End Try
		'End Sub

		'******************************************************************
		Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
			Dim booResult As Boolean = False
			Try
				If e.KeyCode = Keys.Enter AndAlso Me.txtIMEI.Text.Trim.Length > 0 Then
					booResult = ProcessTFSN()
					If booResult = True Then Me.txtIMEI.Text = ""
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'******************************************************************
		Private Function ProcessTFSN() As Boolean
			Dim dt As DataTable
			Dim iDeviceID, iManufWrty, i, iWrtyExpInLess31Days, iManufacturingCountryID, iManufID, iTrayID, iOrderModelID As Integer
			Dim dtBox As DataTable
			Dim strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, strWorkstation As String
			Dim objTFMisc As New Data.Buisness.TracFone.clsMisc()

			Try
				If Me.cboOpenOrders.SelectedValue = 0 Then
					MessageBox.Show("Please select Order Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.txtIMEI.Text = "" : Me.txtIMEI.Focus()
					Return False
				End If

				iDeviceID = 0 : iManufWrty = 0 : i = 0 : iOrderModelID = 0 : iWrtyExpInLess31Days = 0 : iManufacturingCountryID = 0
				strLastDateInWrty = "" : strWrtyDateCode = "" : strMSN = "" : strAPC = "" : strWorkstation = ""
				Me.lblMsg.Text = ""
				Me.lblMsg.BackColor = Color.SteelBlue
				Me.lblWrtyExpedite.ForeColor = Color.Lime
				Me.lblInWrtyBoxID.ForeColor = Color.Lime
				Me.lblOutWrtyBoxID.ForeColor = Color.Lime

				iManufID = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Manuf_ID")			  ' dt.Rows(0)("Model_ID")
                iTrayID = PSS.Data.Buisness.Generic.GetTrayID(Me.cboOpenOrders.SelectedValue)
                iOrderModelID = Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Model_ID")     ' dt.Rows(0)("Model_ID")

                If Me._bReceiving_NTF_XModel Then 'select correct xModel ID
                    iOrderModelID = Me.lblModel_ID.Text
                End If

                If iManufID = 0 Then
                    MessageBox.Show("Manufacture is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.Text = "" : Me.cboOpenOrders.Focus()
                ElseIf iOrderModelID = 0 Then
                    MessageBox.Show("Model is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.Text = "" : Me.cboOpenOrders.Focus()
                ElseIf iTrayID = 0 Then
                    MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.Text = "" : Me.cboOpenOrders.Focus()
                ElseIf Me.cboBoxType.DataSource.Table.Select("[Desc] = '" & Me.cboBoxType.Text & "'").length = 0 Then
                    MessageBox.Show("Invalid selection of Box Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBoxType.SelectAll() : Me.cboBoxType.Focus()
                ElseIf Generic.IsSNInWIP(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, Me.txtIMEI.Text.Trim) = True Then
                    MessageBox.Show("IMEI is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.lblDisposition.Text = "FUN" AndAlso Me.lblModel.Text.Trim.ToUpper.EndsWith("_FUN") = False Then
                    MessageBox.Show("This order come in as functional failure but assigned to none functional model. Please verify with IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.txtMaxBoxQty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter maximum box quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMaxBoxQty.SelectAll() : Me.txtMaxBoxQty.Focus()
                    'ElseIf CInt(Me.lblBoxQty.Text) >= 90 Then
                    '    MessageBox.Show("Box Qty can't be greater than 90", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtIMEI.Text = "" : Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                Else
                    dt = Me._objTFRec.GetTFDeviceASNData(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), False, Me.txtIMEI.Text.Trim)
                    If dt.Rows.Count = 0 AndAlso _booEligibleToProcessDiscrepancy = False Then
                        MessageBox.Show("IMEI does not exist in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("IMEI is duplicated in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    ElseIf dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
                        MessageBox.Show("IMEI has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    Else
                        '*******************************************
                        'DISCREPANCY UNIT. IN BOX NOT IN FILE
                        '*******************************************
                        If dt.Rows.Count = 0 Then
                            If _booEligibleToProcessDiscrepancy = True Then
                                If MessageBox.Show("This IMEI does not exist in the file. Would you like to add this device into order?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                                Else
                                    Dim strCB_ItemNo As String = Me._objTFRec.GetCB_ItemNo(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
                                    dt = Me._objTFRec.AddExtraUnit(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Customer Item #"), strCB_ItemNo, Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("WO_CustWO"), Me.txtIMEI.Text.Trim.ToUpper, "Extra Unit", False, 0)
                                    If dt.Rows.Count = 0 Then
                                        MessageBox.Show("IMEI does not exist in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                                    ElseIf dt.Rows.Count > 1 Then
                                        MessageBox.Show("IMEI is duplicated in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                                    ElseIf Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
                                        MessageBox.Show("IMEI has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                                    End If
                                End If
                            Else
                                'SHOULD NEVER FALL INTO THIS SECTION
                                MessageBox.Show("IMEI does not exist in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                            End If
                        End If


                        '***************************
                        'collect warranty data
                        '***************************
                        'If Me.CollectWarrantyData(iManufID, iOrderModelID, Me.txtIMEI.Text.Trim.ToUpper, Me.cboBoxType.SelectedValue, iManufWrty, iWrtyExpInLess31Days, strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, iManufacturingCountryID) = False Then
                        '    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                        'End If
                        'If iManufWrty < 0 Then
                        '    MessageBox.Show("System has failed to define manufacture warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                        'End If

                        '*******************************
                        'Get Box
                        '*******************************
                        dtBox = Me._objTFRec.GetWHBox(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), Me.cboBoxType.SelectedValue, iManufWrty, iWrtyExpInLess31Days)

                        'Create new box
                        If dtBox.Rows.Count = 0 Then
                            dtBox = Me._objTFRec.CreateWarehouseBoxID(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"), Me.cboBoxType.SelectedValue, iManufWrty, iOrderModelID, iWrtyExpInLess31Days)
                            If dtBox.Rows.Count = 0 Then
                                MessageBox.Show("System had failed to create new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtIMEI.SelectAll() : Exit Function
                            End If
                        End If

                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        '************************************
                        'Receve device into database
                        '************************************


                        ' If the box is cosmedic and tagged in the tmodel table as smartphone 
                        ' with kill switch then move to SW SCREEN.
                        If Me.cboBoxType.SelectedValue = 1 Then
                            strWorkstation = "BER SCREEN"
                        Else
                            If _objModelManuf.IsKillSwitchModel(iOrderModelID) AndAlso Me.cboBoxType.SelectedValue = 0 Then
                                strWorkstation = "SW SCREEN"
                            ElseIf objTFMisc.IsBuffable(iOrderModelID) Then
                                strWorkstation = "PRE-BUFF"
                            Else
                                strWorkstation = "WH-WIP"
                            End If
                        End If

                        'IF XModel, and allowed to triage, always goes to Triage stage, otherwise WH-WIP. So reset it.=========================================
                        If Me._bReceiving_NTF_XModel AndAlso Me._bTriageNeeded Then
                            strWorkstation = "TRIAGE"
                        Else
                            strWorkstation = "WH-WIP"
                        End If

                        '=============================================================================================

                        iDeviceID = Me._objTFRec.ReceiveDeviceIntoWIP(dtBox, dt.Rows(0)("Item_ID"), _
                                    Me.cboOpenOrders.SelectedValue, iTrayID, Me.txtIMEI.Text.Trim, iOrderModelID, _
                                    iManufWrty, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, _
                                    strMSN, strWrtyDateCode, strLastDateInWrty, strAPC, iManufID, _
                                    CInt(Me.txtMaxBoxQty.Text), iManufacturingCountryID, strWorkstation, False, _
                                    Me._bReceiving_NTF_XModel)

                        If iDeviceID > 0 Then
                            '*****************************
                            If iWrtyExpInLess31Days = 1 Then
                                If iManufWrty = 1 Then Me.lblMsg.Text = "IN WARRANTY"
                                Me.lblWrtyExpedite.Text = dtBox.Rows(0)("BoxID")
                                Me.lblWrtyExpediteQty.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblWrtyExpedite.ForeColor = Color.Red
                            ElseIf iManufWrty = 1 Then
                                Me.lblMsg.Text = "IN WARRANTY"
                                Me.lblInWrtyBoxID.Text = dtBox.Rows(0)("BoxID")
                                Me.lblInWrtyBoxQty.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblInWrtyBoxID.ForeColor = Color.Red
                            Else
                                Me.lblMsg.BackColor = Color.Purple
                                Me.lblMsg.Text = "OUT OF WARRANTY"
                                Me.lblOutWrtyBoxID.Text = dtBox.Rows(0)("BoxID")
                                Me.lblOutWrtyBoxQty.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblOutWrtyBoxID.ForeColor = Color.Red
                            End If

                            '******************************************************
                            'CONSUME PARTS @@@@@@
                            '******************************************************
                            ConsumePart(iDeviceID, iOrderModelID, iManufWrty)

                            Me.txtIMEI.Text = ""
                            '******************************************************
                            'COMMENT THIS SO THE RECEIVING PROCESS COULD GO FASTER
                            '******************************************************
                            'Me.AutoBill(iDeviceID, iModelID)
                            '******************************************************
                            Me.Enabled = True : Me.txtIMEI.Focus()
                        End If
                        '************************************
                        End If
                End If
            Catch ex As Exception
				MessageBox.Show(ex.ToString, "ProcessTFSN", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dt) : objTFMisc = Nothing
				Me.Enabled = True : Cursor.Current = Cursors.Default
			End Try
		End Function

		'******************************************************************
		Public Shared Function CollectWarrantyData(ByVal iManufID As Integer, ByVal iModelID As Integer, ByVal strIMEI As String, ByVal iBoxType As Integer, _
											 ByRef iManufWrty As Integer, ByRef iWrtyExpInLess31Days As Integer, ByRef strLastDateInWrty As String, _
											 ByRef strWrtyDateCode As String, ByRef strMSN As String, ByRef strAPC As String, _
											 ByRef iManufacturingCountryID As Integer) As Boolean
			Dim objCollectWrtyCode As System.Object
			Dim booReturnVal As Boolean = False
			Dim strToday As String = ""
			Dim objTFRec As Data.Buisness.TracFone.Receive
			Dim dteReceiptDate As Date

			Try
				dteReceiptDate = CDate(CDate(Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd"))

				iManufWrty = -1
				CollectWarrantyData = False

				objTFRec = New Data.Buisness.TracFone.Receive()

				If objTFRec.IsByPassManufDateCode(iModelID) = True Then
					iManufWrty = 0
					strLastDateInWrty = ""
					strWrtyDateCode = ""
					iManufacturingCountryID = 0
					booReturnVal = True
                ElseIf iManufID = 21 OrElse iManufID = 225 Then    '21=Samsung, 225=Franklin
                    '******************************************************
                    'Get Date code if Manuf is Samsung or Franklin
                    '******************************************************
                    objCollectWrtyCode = New Samsung.frmCollectSSWrytData()
                    objCollectWrtyCode.ShowDialog()
                    If objCollectWrtyCode._booCancel = True Then
                        MessageBox.Show("You must enter manufacture date code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If objCollectWrtyCode._strMonth.Trim.Length = 0 Then
                            MessageBox.Show("Invalid Month of Manufacture Date Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf objCollectWrtyCode._strYear.Trim.Length = 0 Then
                            MessageBox.Show("Invalid Year of Manufacture Date Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            strWrtyDateCode = objCollectWrtyCode._strYear.Trim & "." & objCollectWrtyCode._strMonth.Trim
                            iManufWrty = objCollectWrtyCode._iWrty
                            strLastDateInWrty = objCollectWrtyCode._strLastDateInWarranty
                            booReturnVal = True
                        End If
                    End If
                ElseIf iManufID = 16 Then      'LG
                    objCollectWrtyCode = New LG.frmCollectLGWrtyCode(strIMEI)
                    objCollectWrtyCode.ShowDialog()
                    If objCollectWrtyCode._booCancel = True Then
                        MessageBox.Show("You must enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If objCollectWrtyCode._strDateCode.ToString.Trim.Length = 0 Then
                            MessageBox.Show("You must enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iManufWrty = objCollectWrtyCode._iWrty
                            strWrtyDateCode = objCollectWrtyCode._strDateCode.ToString.Trim
                            If objCollectWrtyCode._strSN.ToString.Trim.Length > 3 Then strMSN = objCollectWrtyCode._strSN.ToString.Trim.ToUpper
                            strLastDateInWrty = objCollectWrtyCode._strLastDateInWarranty
                            booReturnVal = True
                        End If
                    End If
                ElseIf iManufID = 1 Then    'MOTOROLA
                    objCollectWrtyCode = New Gui.Motorola.frmCollectMotorolaWrtyCode(strIMEI, iModelID)
                    objCollectWrtyCode.ShowDialog()
                    If objCollectWrtyCode._booCancel = True Then
                        MessageBox.Show("You must enter MSN number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If objCollectWrtyCode._strMSN.Trim.Length = 0 Then
                            MessageBox.Show("You must enter MSN number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iManufWrty = objCollectWrtyCode._iWrty
                            strLastDateInWrty = objCollectWrtyCode._strLastDateInWarranty
                            strWrtyDateCode = objCollectWrtyCode._strDateCode.ToString.Trim
                            If objCollectWrtyCode._strMSN.ToString.Trim.Length > 0 Then strMSN = objCollectWrtyCode._strMSN.ToString.Trim.ToUpper
                            strAPC = objCollectWrtyCode._strAPC
                            booReturnVal = True
                        End If
                    End If
                ElseIf iManufID = 24 OrElse iManufID = 48 OrElse iManufID = 201 Then      'Nokia & Huawei & ZTE
                    objCollectWrtyCode = New Gui.ManufWarrantyInfo.frmCollectWrtyDateCode(iModelID, iManufID, dteReceiptDate)
                    objCollectWrtyCode.ShowDialog()
                    If objCollectWrtyCode.ReturnFlg = False Then
                        MessageBox.Show("You must enter date code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If objCollectWrtyCode.Code.Trim.Length = 0 Then
                            MessageBox.Show("You must enter date code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iManufWrty = objCollectWrtyCode.ManufWrty
                            strLastDateInWrty = objCollectWrtyCode.LastDateInWarranty
                            strWrtyDateCode = objCollectWrtyCode.DateCode.ToString.Trim
                            If objCollectWrtyCode.Code.ToString.Trim.Length > 0 Then strMSN = objCollectWrtyCode.Code.ToString.Trim.ToUpper
                            iManufacturingCountryID = objCollectWrtyCode.ManufacturingCountryID
                            booReturnVal = True
                        End If
                    End If
                ElseIf iManufID = 202 OrElse iManufID = 203 Then     'Alcatel, Unimax
                    objCollectWrtyCode = New Gui.ManufWarrantyInfo.frmCollectWrtyDateCode(iModelID, iManufID, dteReceiptDate)
                    objCollectWrtyCode.ShowDialog()
                    If objCollectWrtyCode.ReturnFlg = False OrElse objCollectWrtyCode.DateCode.ToString.Trim.Length = 0 Then
                        MessageBox.Show("You must enter date code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        iManufWrty = objCollectWrtyCode.ManufWrty
                        strLastDateInWrty = objCollectWrtyCode.LastDateInWarranty
                        strWrtyDateCode = objCollectWrtyCode.DateCode.ToString.Trim
                        iManufacturingCountryID = objCollectWrtyCode.ManufacturingCountryID
                        booReturnVal = True
                    End If
                ElseIf objTFRec.IsManufWarrantyClaimable(iManufID) = False Then      'Apple and RIM: temporary not collect datecode
                    iManufWrty = 0
                    strLastDateInWrty = ""
                    strWrtyDateCode = ""
                    iManufacturingCountryID = 0
                    booReturnVal = True
                Else
                    MessageBox.Show("The function of Collect Warranty Data is not available for this manufacture.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    booReturnVal = False
                End If

                If booReturnVal Then
                    If iManufWrty < 0 Then
                        MessageBox.Show("System has failed to calculate manufacture warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False
                    ElseIf iBoxType = 1 AndAlso iManufWrty > 0 AndAlso IsNothing(strLastDateInWrty) = False Then
                        strToday = Format(CDate(Generic.MySQLServerDateTime(1)), "yyyy-MM-dd")
                        'Separate warranty units that will expired in less than 31 days
                        If DateDiff(DateInterval.Day, CDate(strToday), CDate(strLastDateInWrty)) <= 30 Then iWrtyExpInLess31Days = 1
                    End If
                End If

                Return booReturnVal
            Catch ex As Exception
				CollectWarrantyData = False
				Throw ex
			Finally
				If Not IsNothing(objCollectWrtyCode) Then
					objCollectWrtyCode.Dispose()
					objCollectWrtyCode = Nothing
				End If
			End Try
		End Function

		''******************************************************************
		'Private Function AutoBill(ByVal iDeviceID As Integer, ByVal iModelID As Integer) As Integer
		'    Const iReceiveBillcode As Integer = 1608
		'    Dim objDevice As Rules.Device
		'    Try
		'        If Generic.IsBillcodeMapped(iModelID, iReceiveBillcode) > 0 AndAlso Generic.IsBillcodeExisted(iDeviceID, iReceiveBillcode) = False Then
		'            objDevice = New Rules.Device(iDeviceID)
		'            objDevice.AddPart(iReceiveBillcode)
		'            objDevice.Update()
		'        End If
		'    Catch ex As Exception
		'        Throw ex
		'    End Try
		'End Function

		'******************************************************************
		Private Sub dtpDockRecDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpDockRecDate.KeyUp
			Try
				If e.KeyCode = Keys.Enter Then Me.cboBoxType.SelectAll() : Me.cboBoxType.Focus()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "dtpDockRecDate_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'******************************************************************
		Private Sub txtRcvd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRcvd.KeyUp
			Try
				Me.lblExtra.Text = "0"

				If Me.txtRcvd.Text.Trim.Length > 0 AndAlso (CInt(Me.txtRcvd.Text) - CInt(Me.lblFileQty.Text)) > 0 Then
					Me.lblExtra.Text = CInt(Me.txtRcvd.Text) - CInt(Me.lblFileQty.Text)
				End If

				Me.txtRcvd.BackColor = Color.Black
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "txtRcvd_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		'******************************************************************
		Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
			Dim booResult As Boolean = False
			Try
				booResult = ProcessTFSN()
				If booResult = True Then Me.txtIMEI.Text = ""
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'******************************************************************
		Private Sub cboBoxType_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBoxType.KeyUp
			Try
				If e.KeyCode = Keys.Enter Then
					If Me.cboBoxType.DataSource.Table.Select("[Desc] = '" & Me.cboBoxType.Text & "'").length = 0 Then
						MessageBox.Show("Invalid selection of Box Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Me.cboBoxType.SelectAll()
						Me.cboBoxType.Focus()
					Else
						Me.txtIMEI.SelectAll()
						Me.txtIMEI.Focus()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cboBoxType_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'******************************************************************
		Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
			Dim strBoxID As String = ""
			Dim dt As DataTable

			Try
				strBoxID = InputBox("Enter Box ID:").Trim

				If strBoxID.Length = 0 Then Exit Sub

				Me._objTFRec.ReprintWHBox(strBoxID)
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cboBoxType_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'******************************************************************
		Private Sub btnRefreshRecNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshRecNo.Click
			Try
				If Me.cboOpenOrders.SelectedValue > 0 Then
					Me.lblExtra.Text = Me._objTFRec.GetDiscrepancyDevices(Me.cboOpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboOpenOrders.SelectedValue)(0)("Order_ID"))
					Me.txtRcvd.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboOpenOrders.SelectedValue)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnRefreshRecNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'******************************************************************
		Private Sub txtMaxBoxQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaxBoxQty.KeyPress
			If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
				e.Handled = True
			End If
		End Sub

		'******************************************************************
		Private Sub txtIMEI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIMEI.KeyPress, txtDiscrepancyIMEI.KeyPress
			If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
				e.Handled = True
			End If
		End Sub

		'******************************************************************

#End Region

#Region "Box Receiving"

		'**************************************************************************************************************
		Private Sub btnBoxRec_ViewReceivedUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
			Try
				If Me.cboBoxRec_OpenOrders.SelectedValue > 0 Then
					LoadReceivedData(Me.cboBoxRec_OpenOrders.SelectedValue, Me.dbgBoxRec_ViewUnitsOnOrder)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnBoxRec_ViewReceivedUnits_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub btnBoxRec_WaitingToBeRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxRec_WaitingToBeRec.Click
			Try
				If Me.cboBoxRec_OpenOrders.SelectedValue > 0 Then
					LoadWaitingToBeRecData(Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Order_ID"), dbgBoxRec_ViewUnitsOnOrder)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnBoxRec_WaitingToBeRec_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub btnBoxRec_CloseRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxRec_CloseRMA.Click
			Dim iTotalRecQty, iFileQty, iExtra, iEdiOrderID As Integer
			Dim strOrderType As String = ""
			Dim booResult As Boolean = False

			Try
				If Me.cboBoxRec_OpenOrders.SelectedValue > 0 Then
					strOrderType = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper
					iEdiOrderID = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Order_ID")

					iTotalRecQty = 0 : iFileQty = 0 : iExtra = 0

					If strOrderType = "PHONE" Then
						'****************************
						'Refresh Receive quantity
						'****************************
						Me.lblBoxRec_Extra.Text = Me._objTFRec.GetDiscrepancyDevices(Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Order_ID"))
						Me.txtBoxRec_Rcvd.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboBoxRec_OpenOrders.SelectedValue)
						'****************************
					End If

					If Me.txtBoxRec_Rcvd.Text.Trim.Length > 0 Then iTotalRecQty = CInt(Me.txtBoxRec_Rcvd.Text)
					If Me.lblBoxRec_FileQty.Text.Trim.Length > 0 Then iFileQty = CInt(Me.lblBoxRec_FileQty.Text)
					If Me.lblBoxRec_Extra.Text.Trim > 0 Then iExtra = CInt(Me.lblBoxRec_Extra.Text)

					Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

					booResult = CloseRMA(Me.cboBoxRec_OpenOrders.SelectedValue, iEdiOrderID, strOrderType, iTotalRecQty, iFileQty, iExtra, Me.dtpBoxRec_DockRecDate.Value)
					If booResult Then
						MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
						Me.ClearBoxRecCtrls_GlobalVarsForNewRMA(True)
						Me.Enabled = True : Me.cboOpenOrders.Focus()
					End If

				End If			 'Order ID > 0
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnCloseRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub ClearBoxRecCtrls_GlobalVarsForNewRMA(ByVal booRefreshOpenOrderList As Boolean)
			Try
				Me.lblBoxRec_Model.Text = ""
				Me.txtBoxRec_IMEIs.Text = "" : Me.txtBoxRec_IMEIs.Enabled = True
				Me.lblBoxRec_BoxQty.Text = ""
				Me.dbgBoxRec_ViewUnitsOnOrder.DataSource = Nothing : Me.dbgBoxRec_ViewUnitsOnOrder.Caption = ""
				Me.dbgBoxRec_ReceivedUnits.DataSource = Nothing : Me.dbgBoxRec_ReceivedUnits.Caption = ""
				Me.dbgBoxRec_NotReceivedUnits.DataSource = Nothing : Me.dbgBoxRec_NotReceivedUnits.Caption = ""
				Me.dbgBoxRec_MissingInEDIUnits.DataSource = Nothing : Me.dbgBoxRec_MissingInEDIUnits.Caption = ""
				Me.lblBoxRec_FileQty.Text = ""
				Me.lblBoxRec_Extra.Text = ""
				Me.txtBoxRec_Rcvd.Text = ""
				Me.lblBoxRec_Disposition.Text = ""
				Me.pnlBoxRec_Box.Visible = False

				If booRefreshOpenOrderList Then
					Me.btnBoxRec_CloseRMA.Visible = False
					Me.btnBoxRec_ViewReceivedUnits.Visible = False
					Me.btnBoxRec_WaitingToBeRec.Visible = False
					Me.dtpBoxRec_DockRecDate.Enabled = True

					Me._booLoadDataToCtrl = True : Me.LoadOpenWorkOrder() : _booLoadDataToCtrl = False
				End If
			Catch ex As Exception
				Throw ex
			Finally
				_booLoadDataToCtrl = False
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub cboBoxRec_OpenOrders_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBoxRec_OpenOrders.KeyUp
			Dim dt As DataTable
			Dim strBoxID As String = "", strDockRec As String = ""
			Dim iOrderModelID As Integer = 0

			Try
				If e.KeyCode = Keys.Enter Then
					If Me.cboBoxRec_OpenOrders.SelectedValue > 0 Then
						iOrderModelID = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Model_ID")

						Me.lblBoxRec_Model.Text = Generic.GetModelDesc(iOrderModelID)
						Me.lblBoxRec_Model.Visible = True
						Me.lblBoxRec_Disposition.Text = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("IL_No").ToString.Trim.ToUpper
						If Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper = "PHONE" AndAlso Me.lblBoxRec_Disposition.Text.StartsWith("COS") = False AndAlso Me.lblBoxRec_Model.Text.Trim.ToUpper.EndsWith("_FUN") = False Then MessageBox.Show("This order come in as functional failure but assigned to none functional model. Please verify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						If Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper = "PHONE" AndAlso Me.lblBoxRec_Disposition.Text.StartsWith("COS") = True AndAlso Me.lblBoxRec_Model.Text.Trim.ToUpper.EndsWith("_FUN") = True Then MessageBox.Show("This order come in as cosmetic but assigned to functional model. Please verify.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)

						Me.lblBoxRec_FileQty.Text = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("WO_Quantity")				   'dt.Rows(0)("Model_Desc")
						Me.lblBoxRec_Extra.Text = Me._objTFRec.GetDiscrepancyDevices(Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Order_ID"))
						Me.txtBoxRec_Rcvd.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboBoxRec_OpenOrders.SelectedValue)

						Me.btnBoxRec_CloseRMA.Visible = True
						If Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("cust_MaterialCategory").ToString.Trim.ToUpper <> "PHONE" Then
							Me.btnBoxRec_ViewReceivedUnits.Visible = False
							Me.btnBoxRec_WaitingToBeRec.Visible = False
							Me.txtBoxRec_Rcvd.Text = Me.lblBoxRec_FileQty.Text
							Me.txtBoxRec_Rcvd.Enabled = True : Me.pnlBoxRec_Box.Visible = False
							Me.txtBoxRec_Rcvd.SelectAll() : Me.txtBoxRec_Rcvd.Focus()
						Else				   'Hanset order
							If Me.lblBoxRec_Disposition.Text.StartsWith("COS") Then Me.cboBoxRec_BoxType.SelectedValue = 0 Else Me.cboBoxRec_BoxType.SelectedValue = 1
							Me.PopulateOpenBoxes(Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Order_ID"), True)
							Me.btnBoxRec_ViewReceivedUnits.Visible = True
							If _booEligibleToViewUnRecUnits = True Then Me.btnBoxRec_WaitingToBeRec.Visible = True Else Me.btnBoxRec_WaitingToBeRec.Visible = False
							Me.txtBoxRec_Rcvd.Enabled = False
							Me.txtBoxRec_Rcvd.BackColor = Color.Black : Me.txtBoxRec_Rcvd.ForeColor = Color.Lime
							Me.pnlBoxRec_Box.Visible = True
							Me.txtBoxRec_IMEIs.Focus()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cboBoxRec_OpenOrders_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub cboBoxRec_OpenOrders_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBoxRec_OpenOrders.Enter
			Try
				Me.btnBoxRec_CloseRMA.Visible = False
				Me.btnBoxRec_ViewReceivedUnits.Visible = False
				Me.btnBoxRec_WaitingToBeRec.Visible = False
				Me.dtpBoxRec_DockRecDate.Enabled = True

				ClearBoxRecCtrls_GlobalVarsForNewRMA(False)
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cboBoxRec_OpenOrders_Enter", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		Private Sub txtBoxRec_IMEIs_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxRec_IMEIs.KeyUp
			Dim ds As DataSet

			Try
				If e.KeyCode = Keys.Enter AndAlso Me.txtBoxRec_IMEIs.Text.Trim.Length > 0 Then
					If Me.cboBoxRec_OpenOrders.SelectedValue > 0 Then
						ds = ProcessBoxSNs(Me.txtBoxRec_IMEIs.Text.Trim, Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Order_ID"))
						BoxRec_DisplayInputData(ds)
						Me.txtBoxRec_IMEIs.Enabled = False
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "txtBoxRec_IMEIs_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDS(ds)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Function ProcessBoxSNs(ByVal strBoxSNs As String, ByVal iOrderID As Integer) As DataSet
			Dim dtEdiDataOnOrder, dtBoxSNs_Received, dtBoxSNs_ToBeRec, dtSNs_MissingInEdi, dtBoxSNs As DataTable
			Dim ds As New DataSet()
			Dim strArrBoxSNs() As String
			Dim i As Integer = 0
			Dim drNewRow, drBoxNewRow As DataRow

			Try
				dtEdiDataOnOrder = Me._objTFRec.GetTFDeviceASNData(iOrderID, False, )

				dtBoxSNs_Received = New DataTable() : dtBoxSNs_Received = dtEdiDataOnOrder.Clone : dtBoxSNs_Received.TableName = "BoxSNs_Received" : dtBoxSNs_Received.AcceptChanges()

				dtBoxSNs_ToBeRec = New DataTable() : dtBoxSNs_ToBeRec = dtEdiDataOnOrder.Clone : dtBoxSNs_ToBeRec.TableName = "BoxSNs_ToBeRec" : dtBoxSNs_ToBeRec.AcceptChanges()

				dtSNs_MissingInEdi = New DataTable() : dtSNs_MissingInEdi = dtEdiDataOnOrder.Clone : dtSNs_MissingInEdi.TableName = "BoxSNs_MissingInEDI" : dtSNs_MissingInEdi.AcceptChanges()

				dtBoxSNs = New DataTable() : dtBoxSNs = dtEdiDataOnOrder.Clone : dtBoxSNs.TableName = "BoxSNs"
				dtBoxSNs.Columns.Add(New DataColumn("ExistedInEdi", System.Type.GetType("System.Int16"))) : dtBoxSNs.AcceptChanges()

				strArrBoxSNs = Me.txtBoxRec_IMEIs.Text.Trim.Split(",")
				For i = 0 To strArrBoxSNs.Length - 1
					If strArrBoxSNs(i).Trim.Length > 0 Then
						drBoxNewRow = dtBoxSNs.NewRow : drBoxNewRow("SN") = strArrBoxSNs(i).Trim

						If dtEdiDataOnOrder.Select("SN = '" & strArrBoxSNs(i).Trim & "'").Length = 0 Then
							drNewRow = Nothing
							drNewRow = dtSNs_MissingInEdi.NewRow : drNewRow("SN") = strArrBoxSNs(i).Trim : dtSNs_MissingInEdi.Rows.Add(drNewRow)
							dtSNs_MissingInEdi.AcceptChanges()

							drBoxNewRow("ExistedInEdi") = 0
						ElseIf dtEdiDataOnOrder.Select("SN = '" & strArrBoxSNs(i).Trim & "' AND Device_ID > 0 ").Length > 0 Then
							drNewRow = Nothing
							drNewRow = dtBoxSNs_Received.NewRow : drNewRow("SN") = strArrBoxSNs(i).Trim : dtBoxSNs_Received.Rows.Add(drNewRow)
							dtBoxSNs_Received.AcceptChanges()

							drBoxNewRow("Device_ID") = dtEdiDataOnOrder.Select("SN = '" & strArrBoxSNs(i).Trim & "' AND Device_ID > 0 ")(0)("Device_ID")
							drBoxNewRow("Item_ID") = dtEdiDataOnOrder.Select("SN = '" & strArrBoxSNs(i).Trim & "' AND Device_ID > 0  ")(0)("Item_ID")
							drBoxNewRow("ExistedInEdi") = 1
						Else
							drNewRow = Nothing
							drNewRow = dtBoxSNs_ToBeRec.NewRow
							drNewRow("SN") = strArrBoxSNs(i).Trim
							drNewRow("Item_ID") = dtEdiDataOnOrder.Select("SN = '" & strArrBoxSNs(i).Trim & "' ")(0)("Item_ID")
							dtBoxSNs_ToBeRec.Rows.Add(drNewRow)
							dtBoxSNs_ToBeRec.AcceptChanges()

							drBoxNewRow("Item_ID") = dtEdiDataOnOrder.Select("SN = '" & strArrBoxSNs(i).Trim & "'")(0)("Item_ID")
							drBoxNewRow("ExistedInEdi") = 1
						End If

						dtBoxSNs.Rows.Add(drBoxNewRow) : dtBoxSNs.AcceptChanges()
						Me.btnBoxRec_Receive.Visible = True

					End If
				Next i
				ds.Tables.Add(dtBoxSNs_Received) : ds.Tables.Add(dtBoxSNs_ToBeRec) : ds.Tables.Add(dtSNs_MissingInEdi) : ds.Tables.Add(dtBoxSNs) : ds.AcceptChanges()

				Return ds
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDS(ds)
				Generic.DisposeDT(dtEdiDataOnOrder) : Generic.DisposeDT(dtBoxSNs_Received) : Generic.DisposeDT(dtBoxSNs_ToBeRec)
				Generic.DisposeDT(dtSNs_MissingInEdi) : Generic.DisposeDT(dtBoxSNs)
			End Try
		End Function

		'**************************************************************************************************************
		Private Sub BoxRec_DisplayInputData(ByVal ds As DataSet)
			Dim i As Integer

			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

				Me.lblBoxRec_BoxQty.Text = ds.Tables("BoxSNs").Rows.Count

				With Me.dbgBoxRec_ReceivedUnits
					'  If .RowCount > 0 Then .Visible = True Else .Visible = False
					.DataSource = ds.Tables("BoxSNs_Received").DefaultView
					For i = 0 To .Columns.Count - 1
						.Splits(0).DisplayColumns(i).Visible = False
					Next i

					.Splits(0).DisplayColumns("SN").Visible = True
					.Splits(0).DisplayColumns("SN").Width = 150
					.Caption = "Received - Qty: " & .RowCount
				End With
				With Me.dbgBoxRec_NotReceivedUnits
					'If .RowCount > 0 Then .Visible = True Else .Visible = False
					.DataSource = ds.Tables("BoxSNs_ToBeRec").DefaultView
					For i = 0 To .Columns.Count - 1
						.Splits(0).DisplayColumns(i).Visible = False
					Next i

					.Splits(0).DisplayColumns("SN").Visible = True
					.Splits(0).DisplayColumns("SN").Width = 150
					.Caption = "To Be Receive - Qty: " & .RowCount
				End With

				With Me.dbgBoxRec_MissingInEDIUnits
					' If .RowCount > 0 Then .Visible = True Else .Visible = False
					.DataSource = ds.Tables("BoxSNs_MissingInEDI").DefaultView
					For i = 0 To .Columns.Count - 1
						.Splits(0).DisplayColumns(i).Visible = False
					Next i

					.Splits(0).DisplayColumns("SN").Visible = True
					.Splits(0).DisplayColumns("SN").Width = 150
					.Caption = "Missing in EDI - Qty: " & .RowCount
				End With
			Catch ex As Exception
				Throw ex
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
				Generic.DisposeDS(ds)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub dtpBoxRec_DockRecDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpBoxRec_DockRecDate.KeyUp
			Try
				If e.KeyCode = Keys.Enter Then Me.cboBoxRec_BoxType.SelectAll() : Me.cboBoxRec_BoxType.Focus()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "dtpBoxRec_DockRecDate_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub txtBoxRec_Rcvd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxRec_Rcvd.KeyUp
			Try
				Me.lblBoxRec_Extra.Text = "0"

				If txtBoxRec_Rcvd.Text.Trim.Length > 0 AndAlso (CInt(Me.txtBoxRec_Rcvd.Text) - CInt(Me.lblBoxRec_FileQty.Text)) > 0 Then
					Me.lblBoxRec_Extra.Text = CInt(Me.txtBoxRec_Rcvd.Text) - CInt(Me.lblBoxRec_FileQty.Text)
				End If

				Me.txtBoxRec_Rcvd.BackColor = Color.Black
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "txtBoxRec_Rcvd_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub cboBoxRec_BoxType_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBoxRec_BoxType.KeyUp
			Try
				If e.KeyCode = Keys.Enter Then
					If Me.cboBoxRec_BoxType.DataSource.Table.Select("[Desc] = '" & Me.cboBoxRec_BoxType.Text & "'").length = 0 Then
						MessageBox.Show("Invalid selection of Box Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Me.cboBoxRec_BoxType.SelectAll()
						Me.cboBoxRec_BoxType.Focus()
					Else
						Me.txtBoxRec_IMEIs.SelectAll()
						Me.txtBoxRec_IMEIs.Focus()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "cboBoxRec_BoxType_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub btnBoxRec_ReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxRec_ReprintBoxLabel.Click
			Dim strBoxID As String = ""
			Dim dt As DataTable

			Try
				strBoxID = InputBox("Enter Box ID:").Trim

				If strBoxID.Length = 0 Then Exit Sub

				Me._objTFRec.ReprintWHBox(strBoxID)
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnBoxRec_ReprintBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Finally
				Generic.DisposeDT(dt)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub btnBoxRec_RefreshRecNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxRec_RefreshRecNo.Click
			Try
				If Me.cboBoxRec_OpenOrders.SelectedValue > 0 Then
					Me.lblBoxRec_Extra.Text = Me._objTFRec.GetDiscrepancyDevices(Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Order_ID"))
					Me.txtBoxRec_Rcvd.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboBoxRec_OpenOrders.SelectedValue)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnBoxRec_RefreshRecNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub btnBoxRec_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxRec_Clear.Click
			Try
				Me.txtBoxRec_IMEIs.Text = "" : Me.txtBoxRec_IMEIs.Enabled = True
				Me.lblBoxRec_BoxQty.Text = ""
				Me.dbgBoxRec_ViewUnitsOnOrder.DataSource = Nothing : Me.dbgBoxRec_ViewUnitsOnOrder.Caption = ""
				Me.dbgBoxRec_ReceivedUnits.DataSource = Nothing : Me.dbgBoxRec_ReceivedUnits.Caption = ""
				Me.dbgBoxRec_NotReceivedUnits.DataSource = Nothing : Me.dbgBoxRec_NotReceivedUnits.Caption = ""
				Me.dbgBoxRec_MissingInEDIUnits.DataSource = Nothing : Me.dbgBoxRec_MissingInEDIUnits.Caption = ""
				Me.txtBoxRec_IMEIs.SelectAll() : Me.txtBoxRec_IMEIs.Focus()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnBoxRec_Clear_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub btnBoxRec_Receive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoxRec_Receive.Click
			Dim booResult As Boolean = False
			Try
				booResult = ProcessTFSN_BoxRec()
				If booResult = True Then Me.txtBoxRec_IMEIs.Text = ""
				txtBoxRec_IMEIs.SelectAll() : txtBoxRec_IMEIs.Focus()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnBoxRec_Receive_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Function ProcessTFSN_BoxRec() As Boolean
			Const iWrtyExpInLess31Days As Integer = 0 : Const iManufWrty As Integer = 0 : Const iManufacturingCountryID As Integer = 0
			Const strAPC As String = "" : Const strMSN As String = "" : Const strWrtyDateCode As String = "" : Const strLastDateInWrty As String = ""
			Dim dt, dtBox As DataTable
			Dim ds As DataSet
			Dim iDeviceID, i, iManufID, iModelID, iBoxType, iTrayID, iWHRNO_ID, iOrderModelID, iOrderID As Integer
			Dim strItemNo, strWorkstation, strCustomerItemNo, strCustomerPoNo As String
			Dim drArray(), R1 As DataRow
			Dim objTFMisc As New Data.Buisness.TracFone.clsMisc()

			Try
				iDeviceID = 0 : i = 0 : iManufID = 0 : iModelID = 0
				Me.dbgBoxRec_ViewUnitsOnOrder.DataSource = Nothing : Me.dbgBoxRec_ViewUnitsOnOrder.Caption = ""
				Me.dbgBoxRec_ReceivedUnits.DataSource = Nothing : Me.dbgBoxRec_ReceivedUnits.Caption = ""
				Me.dbgBoxRec_NotReceivedUnits.DataSource = Nothing : Me.dbgBoxRec_NotReceivedUnits.Caption = ""
				Me.dbgBoxRec_MissingInEDIUnits.DataSource = Nothing : Me.dbgBoxRec_MissingInEDIUnits.Caption = ""

				If Me.cboBoxRec_OpenOrders.SelectedValue = 0 Then
					MessageBox.Show("Please select Order Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.cboBoxRec_OpenOrders.SelectAll() : Me.cboBoxRec_OpenOrders.Focus() : Return False
				ElseIf Me.txtBoxRec_IMEIs.Text.Trim.Length = 0 Then
					MessageBox.Show("Please scan in box's SNs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.txtBoxRec_IMEIs.SelectAll() : Me.txtBoxRec_IMEIs.Focus() : Return False
				End If

				iBoxType = 0 : iTrayID = 0 : iWHRNO_ID = 0

				iManufID = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Manuf_ID")
				iTrayID = PSS.Data.Buisness.Generic.GetTrayID(Me.cboBoxRec_OpenOrders.SelectedValue)
				iOrderModelID = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Model_ID")
				iOrderID = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Order_ID")
				strCustomerItemNo = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("Customer Item #")
				strCustomerPoNo = Me.cboBoxRec_OpenOrders.DataSource.Table.Select("WO_ID = " & Me.cboBoxRec_OpenOrders.SelectedValue)(0)("WO_CustWO")

				If iManufID = 0 Then
					MessageBox.Show("Manufacture is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf iOrderModelID = 0 Then
					MessageBox.Show("Model is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf iTrayID = 0 Then
					MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf iOrderID = 0 Then
					MessageBox.Show("Order ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf Me.cboBoxRec_BoxType.DataSource.Table.Select("[Desc] = '" & Me.cboBoxRec_BoxType.Text & "'").length = 0 Then
					MessageBox.Show("Invalid selection of Box Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.cboBoxRec_BoxType.SelectAll() : Me.cboBoxRec_BoxType.Focus()
				ElseIf Me.lblBoxRec_Disposition.Text = "FUN" AndAlso Me.lblBoxRec_Model.Text.Trim.ToUpper.EndsWith("_FUN") = False Then
					MessageBox.Show("This order come in as functional failure but assigned to none functional model. Please verify with IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Me.txtBoxRec_IMEIs.SelectAll() : Me.txtBoxRec_IMEIs.Focus()
				Else
					'ElseIf Generic.IsSNInWIP(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, Me.txtIMEI.Text.Trim) = True Then
					'MessageBox.Show("IMEI is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					'Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()

					ds = Me.ProcessBoxSNs(Me.txtBoxRec_IMEIs.Text.Trim, iOrderID)
					BoxRec_DisplayInputData(ds)

					If ds.Tables("BoxSNs").Select("ExistedInEdi = 0").Length > 0 AndAlso _booEligibleToProcessDiscrepancy = False Then
						MessageBox.Show("There are " & ds.Tables("BoxSNs").Select("ExistedInEdi = 0").Length & " SN(s) are missing in EDI file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					ElseIf ds.Tables("BoxSNs").Select("Device_ID > 0").Length > 0 Then
						MessageBox.Show(ds.Tables("BoxSNs").Select("Device_ID > 0").Length & " unit(s) have been received in this box. Please contact IT to reconcile this problem.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					ElseIf ds.Tables("BoxSNs").Select("ExistedInEdi = 0").Length > 0 AndAlso _booEligibleToProcessDiscrepancy = False Then
						MessageBox.Show("Your account setting does not allow to receive missing SN in EDI file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					ElseIf ds.Tables("BoxSNs").Select("ExistedInEdi = 0").Length = 0 AndAlso ds.Tables("BoxSNs").Select("ExistedInEdi = 1").Length = 0 Then
						MessageBox.Show("Can't find any SN available to receive in input SNs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
					ElseIf ds.Tables("BoxSNs").Select("ExistedInEdi = 0").Length > 0 AndAlso MessageBox.Show("Are you sure you want to recevice " & vbCrLf & ds.Tables("BoxSNs").Select("ExistedInEdi = 1").Length & " regular SN(s) " & vbCrLf & ds.Tables("BoxSNs").Select("ExistedInEdi = 0").Length & " missing SNs " & vbCrLf & " into the system?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
						Return False
					ElseIf ds.Tables("BoxSNs").Select("ExistedInEdi = 0").Length = 0 AndAlso MessageBox.Show("Are you sure you want to recevice " & vbCrLf & ds.Tables("BoxSNs").Select("ExistedInEdi = 1").Length & " SN(s) into the system?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
						Return False
					Else
						'*******************************************
						'DISCREPANCY UNIT. IN BOX NOT IN FILE
						'*******************************************
						If ds.Tables("BoxSNs").Select("ExistedInEdi = 0").Length > 0 Then
							Dim strCB_ItemNo As String = Me._objTFRec.GetCB_ItemNo(iOrderID)
							drArray = ds.Tables("BoxSNs").Select("ExistedInEdi = 0")
							If drArray.Length > 0 Then
								If Me._objTFRec.ValidateExtraSn(drArray, iOrderID, Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID) = False Then Return False

								For i = 0 To drArray.Length - 1
									dt = Me._objTFRec.AddExtraUnit(strCustomerItemNo, strCB_ItemNo, iOrderID, strCustomerPoNo, drArray(i)("SN").ToString.Trim.ToUpper, "Extra Unit", False, 0)
									If dt.Rows.Count = 0 Then
										MessageBox.Show("IMEI does not exist in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
										Me.txtBoxRec_IMEIs.SelectAll() : Me.txtBoxRec_IMEIs.Focus() : Exit Function
									ElseIf dt.Rows.Count > 1 Then
										MessageBox.Show("IMEI is duplicated in file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
										Me.txtBoxRec_IMEIs.SelectAll() : Me.txtBoxRec_IMEIs.Focus() : Exit Function
									ElseIf Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
										MessageBox.Show("IMEI has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
										Me.txtBoxRec_IMEIs.SelectAll() : Me.txtBoxRec_IMEIs.Focus() : Exit Function
									Else
										drArray(i).BeginEdit() : drArray(i)("Item_ID") = dt.Rows(0)("Item_ID") : drArray(i).EndEdit() : ds.Tables("BoxSNs").AcceptChanges()
									End If
								Next i
							End If
						End If

						If ds.Tables("BoxSNs").Select("Item_ID = 0").Length > 0 Then Throw New Exception("Missing item ID in box. Please contact IT.")
						Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

						'*******************************
						'Get Box
						'*******************************
						dtBox = Me._objTFRec.GetWHBox(iOrderID, Me.cboBoxRec_BoxType.SelectedValue, iManufWrty, iWrtyExpInLess31Days)
						'Create new box
						If dtBox.Rows.Count = 0 Then
							dtBox = Me._objTFRec.CreateWarehouseBoxID(iOrderID, Me.cboBoxRec_BoxType.SelectedValue, iManufWrty, iOrderModelID, iWrtyExpInLess31Days)
							If dtBox.Rows.Count = 0 Then
								MessageBox.Show("System had failed to create new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
								Me.txtIMEI.SelectAll() : Exit Function
							End If
						End If

						'************************************
						'Receve device into database
						'************************************

						' if box is cosmedic and tagged in the tmodel table as sw_proces 
						' then move to SW SCREEN.
						If Me.cboBoxRec_BoxType.SelectedValue = 1 Then
							strWorkstation = "BER SCREEN"
						Else
							If _objModelManuf.IsKillSwitchModel(iOrderModelID) AndAlso Me.cboBoxRec_BoxType.SelectedValue = 0 Then
								strWorkstation = "SW SCREEN"
							ElseIf objTFMisc.IsBuffable(iOrderModelID) Then
								strWorkstation = "PRE-BUFF"
							Else
								strWorkstation = "WH-WIP"
							End If
						End If

						For Each R1 In ds.Tables("BoxSNs").Rows
							iDeviceID = Me._objTFRec.ReceiveDeviceIntoWIP(dtBox, R1("Item_ID"), Me.cboBoxRec_OpenOrders.SelectedValue, iTrayID, _
							   R1("SN"), iOrderModelID, iManufWrty, PSS.Core.ApplicationUser.IDShift, _
							   PSS.Core.ApplicationUser.IDuser, strMSN, strWrtyDateCode, strLastDateInWrty, _
							   strAPC, iManufID, ds.Tables("BoxSNs").Rows.Count, iManufacturingCountryID, strWorkstation)
							If iDeviceID > 0 Then ConsumePart(iDeviceID, iOrderModelID, iManufWrty)
						Next R1

						Me.lblBoxRec_BoxQty.Text = ""
						Me.dbgBoxRec_ViewUnitsOnOrder.DataSource = Nothing : Me.dbgBoxRec_ViewUnitsOnOrder.Caption = ""
						Me.dbgBoxRec_ReceivedUnits.DataSource = Nothing : Me.dbgBoxRec_ReceivedUnits.Caption = ""
						Me.dbgBoxRec_NotReceivedUnits.DataSource = Nothing : Me.dbgBoxRec_NotReceivedUnits.Caption = ""
						Me.dbgBoxRec_MissingInEDIUnits.DataSource = Nothing : Me.dbgBoxRec_MissingInEDIUnits.Caption = ""
						Me.txtBoxRec_Rcvd.Text = PSS.Data.Buisness.Generic.GetRecQty(Me.cboBoxRec_OpenOrders.SelectedValue)
						Me.txtBoxRec_IMEIs.Text = "" : Me.Enabled = True : Me.txtBoxRec_IMEIs.Focus()

						'************************************
					End If
				End If

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "ProcessTFSN_BoxRec", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Finally
				objTFMisc = Nothing
				Generic.DisposeDT(dt) : Generic.DisposeDS(ds) : Generic.DisposeDT(dtBox) : drArray = Nothing : R1 = Nothing
				Me.Enabled = True : Cursor.Current = Cursors.Default
			End Try
		End Function

		'**************************************************************************************************************

#End Region

#Region "Discrepancy Receiving"

		'**************************************************************************************************************
		Private Sub tpDicrepancyReceiving_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpDicrepancyReceiving.VisibleChanged
			Try
				If tpDicrepancyReceiving.Visible = True AndAlso Not IsNothing(Me.cboDiscrepancyOrder.DataSource) AndAlso Me.cboDiscrepancyOrder.SelectedValue > 0 Then PopulateOpenBoxes(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), False)
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "tpDicrepancyReceiving_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		'**************************************************************************************************************
		Private Sub txtDiscrepancyIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiscrepancyIMEI.KeyUp
			Dim booResult As Boolean = False

			Try
				If e.KeyCode = Keys.Enter AndAlso Me.txtDiscrepancyIMEI.Text.Trim.Length > 0 Then
					booResult = ProcessTFSN_Discrepancy()
					If booResult = True Then Me.txtDiscrepancyIMEI.Text = ""
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "txtDiscrepancyIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			End Try
        End Sub

        '******************************************************************
        Private Sub txtWFMBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWFMBox.KeyUp
            Dim booResult As Boolean = False
            Dim dt As DataTable
            Dim row As DataRow
            Dim strSNs As String = ""
            Dim iWFM_Model_ID As Integer = 0
            Dim iTF_Model_ID As Integer = 0
            Dim bIsNTFBox As Boolean = False

            Try
                Exit Sub ' no need this
                If e.KeyCode = Keys.Enter AndAlso Me.txtWFMBox.Text.Trim.Length > 0 Then
                    'MessageBox.Show(Me.cboDiscrepancyOrder.SelectedValue.ToString)
                    If Me.cboDiscrepancyOrder.SelectedValue = 0 Then
                        MessageBox.Show("Please select Order Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                        Exit Sub
                    ElseIf Not Me.cboDiscrepancyOrder.SelectedValue = 10652538 Then
                        MessageBox.Show("Not a valid order for converting WFM box to TF box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                        Exit Sub
                        'ElseIf Me.cboDiscModels.SelectedValue = 0 Then
                        '    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Me.cboDiscModels.SelectAll() : Me.cboDiscModels.Focus()
                        '    Exit Sub
                        'ElseIf Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue).Length = 0 Then
                        '    MessageBox.Show("Model is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Me.cboDiscModels.SelectAll() : Me.cboDiscModels.Focus()
                        '    Exit Sub
                        'ElseIf Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Manuf_ID") = 0 Then
                        '    MessageBox.Show("Manufacture is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Me.cboDiscModels.SelectAll() : Me.cboDiscModels.Focus()
                        '    Exit Sub
                    ElseIf Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue).Length = 0 Then
                        MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                        Exit Sub
                    ElseIf Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Tray_ID") = 0 Then
                        MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                        Exit Sub
                    End If

                    dt = Me._objTFRec.GetWFM_WHBox(Me.txtWFMBox.Text.Trim, bIsNTFBox)
                    For Each row In dt.Rows
                        If strSNs.Trim.Length = 0 Then strSNs = "'" & row("device_SN") & "'" Else strSNs &= ",'" & row("device_SN") & "'"
                    Next
                    If Not dt.Rows.Count > 0 Then
                        MessageBox.Show("Can't find this box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFMBox.SelectAll() : Me.txtWFMBox.Focus()
                    ElseIf dt.Rows.Count > 90 Then
                        MessageBox.Show("This box has more than 90 devices.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFMBox.SelectAll() : Me.txtWFMBox.Focus()
                    ElseIf Not dt.Rows(0).Item("cust_ID") = PSS.Data.Buisness.WFM.CUSTOMER_ID OrElse _
                           Not dt.Rows(0).Item("Loc_ID") = PSS.Data.Buisness.WFM.LOC_ID Then
                        MessageBox.Show("The box doesn't belong to WFFM.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFMBox.SelectAll() : Me.txtWFMBox.Focus()
                    ElseIf Not dt.Rows.Count = dt.Rows(0).Item("quantity") Then
                        MessageBox.Show("Qty doesn't match: Device count = " & dt.Rows.Count.ToString & ", defined box qty = " & dt.Rows(0).Item("quantity"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFMBox.SelectAll() : Me.txtWFMBox.Focus()
                    ElseIf Generic.AreAnySNsInWIPInBox(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strSNs).Trim.Length > 0 Then
                        MessageBox.Show("IMEI " & Generic.AreAnySNsInWIPInBox(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strSNs) & " in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFMBox.SelectAll() : Me.txtWFMBox.Focus()
                    Else
                        'For Each row In dt.Rows
                        '    Me.ProcessWFM2TF_SN_Discrepancy(row("device_SN"))
                        'Next
                        iWFM_Model_ID = dt.Rows(0).Item("WFM_Model_ID")
                        iTF_Model_ID = Me._objTFRec.GetTF_ModelID(iWFM_Model_ID, dt.Rows(0).Item("Disp_ID"))
                        If iTF_Model_ID > 0 AndAlso Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & iTF_Model_ID).Length > 0 Then
                            Me.cboDiscModels.SelectedValue = iTF_Model_ID
                            If Me.cboDiscModels.SelectedValue = iTF_Model_ID Then
                                booResult = Me.ProcessWFM2TF_SN_Discrepancy(dt)
                            Else
                                MessageBox.Show("Invalid TF model selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("No mapped model between WFM and TF.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                    'booResult = ProcessTFSN_Discrepancy()
                    'If booResult = True Then Me.txtDiscrepancyIMEI.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtWFMBox_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        '******************************************************************
        Private Sub txtWFM2TF_BoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWFM2TF_BoxName.KeyUp
            Dim booResult As Boolean = False
            Dim dt As DataTable
            Dim row As DataRow
            Dim strSNs As String = ""
            Dim iWFM_Model_ID As Integer = 0
            Dim iTF_Model_ID As Integer = 0
            Dim bIsNTFBox As Boolean = False

            Try
                Me.lstWFM2TF_SNsInBox.Visible = False : Me.lblWFM2TF_SN_Count.Visible = False
                Me.cboWFM2TFModels.SelectedValue = 0 : Me.cboWFM2TFModels.Enabled = False
                Me.lblWFMModel.Text = ""

                If e.KeyCode = Keys.Enter AndAlso Me.txtWFM2TF_BoxName.Text.Trim.Length > 0 Then
                    'MessageBox.Show(Me.cboDiscrepancyOrder.SelectedValue.ToString)
                    If Me.cboWFM2TFOrder.SelectedValue = 0 Then
                        MessageBox.Show("Please select Order Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboWFM2TFOrder.SelectAll() : Me.cboWFM2TFOrder.Focus()
                        Exit Sub
                    ElseIf Not Me.cboWFM2TFOrder.SelectedValue = 10652538 Then
                        MessageBox.Show("Not a valid order for converting WFM box to TF box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboWFM2TFOrder.SelectAll() : Me.cboWFM2TFOrder.Focus()
                    ElseIf Me.cboWFM2TFOrder.DataSource.Table.Select("WO_ID = " & Me.cboWFM2TFOrder.SelectedValue).Length = 0 Then
                        MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cboWFM2TFOrder.SelectAll() : Me.cboWFM2TFOrder.Focus()
                        Exit Sub
                    ElseIf Me.cboWFM2TFOrder.DataSource.Table.Select("WO_ID = " & Me.cboWFM2TFOrder.SelectedValue)(0)("Tray_ID") = 0 Then
                        MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.cboWFM2TFOrder.SelectAll() : Me.cboWFM2TFOrder.Focus()
                        Exit Sub
                    End If

                    dt = Me._objTFRec.GetWFM_WHBox(Me.txtWFM2TF_BoxName.Text.Trim, bIsNTFBox)

                    For Each row In dt.Rows
                        If Me._objTFRec.IsSN_WFM2TFAlreadyReceived(row("device_SN")) Then
                            MessageBox.Show("WFM SN '" & row("device_SN") & "' has been already received into TF.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.cboWFM2TFOrder.SelectAll() : Me.cboWFM2TFOrder.Focus()
                            Exit Sub
                        End If
                        If strSNs.Trim.Length = 0 Then strSNs = "'" & row("device_SN") & "'" Else strSNs &= ",'" & row("device_SN") & "'"
                    Next
                    If Not dt.Rows.Count > 0 Then
                        MessageBox.Show("Can't find this box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFM2TF_BoxName.SelectAll() : Me.txtWFM2TF_BoxName.Focus()
                    ElseIf dt.Rows.Count > 100 Then
                        MessageBox.Show("This box has more than 100 devices.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFM2TF_BoxName.SelectAll() : Me.txtWFM2TF_BoxName.Focus()
                    ElseIf Not dt.Rows(0).Item("cust_ID") = PSS.Data.Buisness.WFM.CUSTOMER_ID OrElse _
                           Not dt.Rows(0).Item("Loc_ID") = PSS.Data.Buisness.WFM.LOC_ID Then
                        MessageBox.Show("The box doesn't belong to WFFM.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFM2TF_BoxName.SelectAll() : Me.txtWFM2TF_BoxName.Focus()
                    ElseIf Not dt.Rows.Count = dt.Rows(0).Item("quantity") Then
                        MessageBox.Show("Qty doesn't match: Device count = " & dt.Rows.Count.ToString & ", defined box qty = " & dt.Rows(0).Item("quantity"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFM2TF_BoxName.SelectAll() : Me.txtWFM2TF_BoxName.Focus()
                    ElseIf Generic.AreAnySNsInWIPInBox(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strSNs).Trim.Length > 0 Then
                        MessageBox.Show("IMEI " & Generic.AreAnySNsInWIPInBox(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strSNs) & " in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtWFM2TF_BoxName.SelectAll() : Me.txtWFM2TF_BoxName.Focus()
                    Else
                        iWFM_Model_ID = dt.Rows(0).Item("WFM_Model_ID")
                        iTF_Model_ID = Me._objTFRec.GetTF_ModelID(iWFM_Model_ID, dt.Rows(0).Item("Disp_ID"))
                        If iTF_Model_ID > 0 AndAlso Me.cboWFM2TFModels.DataSource.Table.Select("Model_ID = " & iTF_Model_ID).Length > 0 Then
                            Me.cboWFM2TFModels.SelectedValue = iTF_Model_ID
                            If Me.cboWFM2TFModels.SelectedValue = iTF_Model_ID Then
                                booResult = Me.ProcessWFM2TF_Box_SNs(dt, bIsNTFBox)
                            Else
                                MessageBox.Show("Invalid TF model selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("No mapped model between WFM and TF.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                    'booResult = ProcessTFSN_Discrepancy()
                    'If booResult = True Then Me.txtDiscrepancyIMEI.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtWFM2TF_BoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Function ProcessTFSN_Discrepancy() As Boolean
            Dim dt As DataTable
            Dim iDeviceID, iManufWrty, i, iManufID, iModelID, iWrtyExpInLess31Days, iManufacturingCountryID, iBoxType, iTrayID, iWHRNO_ID As Integer
            Dim iL_CustID As Integer = 0
            Dim objCollectWrtyCode As System.Object
            Dim dtBox As DataTable
            Dim strLastDateInWrty, strToday, strWrtyDateCode, strMSN, strAPC, strItemNo, strWorkstation As String
            Dim objTFMisc As New Data.Buisness.TracFone.clsMisc()
            Dim iWFM_DeviceID As Integer = 0
            Dim iWFM_WHB_ID As Integer = 0

            Try
                iDeviceID = 0 : iManufWrty = 0 : i = 0 : iManufID = 0 : iModelID = 0 : iWrtyExpInLess31Days = 0 : iManufacturingCountryID = 0 : iBoxType = 0 : iTrayID = 0 : iWHRNO_ID = 0
                strLastDateInWrty = "" : strWrtyDateCode = "" : strMSN = "" : strAPC = "" : strItemNo = ""
                Me.lblDiscWrtyStatus.Text = ""
                Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                Me.lblInWrtyBoxID_Disc.ForeColor = Color.Lime
                Me.lblWrtyExpedite_Disc.ForeColor = Color.Lime
                Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Lime

                If Me.cboDiscrepancyOrder.SelectedValue = 0 Then
                    MessageBox.Show("Please select Order Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                ElseIf Me.cboDiscModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscModels.SelectAll() : Me.cboDiscModels.Focus()
                ElseIf Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue).Length = 0 Then
                    MessageBox.Show("Model is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscModels.SelectAll() : Me.cboDiscModels.Focus()
                ElseIf Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Manuf_ID") = 0 Then
                    MessageBox.Show("Manufacture is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscModels.SelectAll() : Me.cboDiscModels.Focus()
                ElseIf Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue).Length = 0 Then
                    MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                ElseIf Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Tray_ID") = 0 Then
                    MessageBox.Show("Tray ID is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                ElseIf Generic.IsSNInWIP(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, Me.txtDiscrepancyIMEI.Text.Trim) = True Then
                    MessageBox.Show("IMEI is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus()
                Else
                    strItemNo = Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("cust_IncomingSku")
                    iManufID = Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Manuf_ID")
                    iModelID = Me.cboDiscModels.SelectedValue
                    If Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue).Length > 0 AndAlso Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Model_Desc").ToString.Trim.EndsWith("_FUN") = True Then iBoxType = 1

                    iL_CustID = Me._objTFRec.GetCustIDBySN(Me.txtDiscrepancyIMEI.Text.Trim)


                    'not allowed WFM SN to TF
                    If iL_CustID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                        MessageBox.Show("You must transfer WFM devices to TF, box by box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                    End If
                    '***************************
                    'collect warranty data
                    '***************************
                    If Not iL_CustID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                        If Me.CollectWarrantyData(iManufID, iModelID, Me.txtDiscrepancyIMEI.Text.Trim.ToUpper, iBoxType, iManufWrty, iWrtyExpInLess31Days, strLastDateInWrty, strWrtyDateCode, strMSN, strAPC, iManufacturingCountryID) = False Then
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function
                        End If
                        If iManufWrty < 0 Then
                            MessageBox.Show("System has failed to define manufacture warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus() : Exit Function

                        End If
                    End If
                    If iL_CustID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                        iWFM_DeviceID = Me._objTFRec.GetWFM_DeviceID(Me.txtDiscrepancyIMEI.Text.Trim)
                        iWFM_WHB_ID = Me._objTFRec.GetWFM_WHB_ID(Me.txtDiscrepancyIMEI.Text.Trim)
                    End If

                    '*******************************
                    'Get Box
                    '*******************************
                    dtBox = Me._objTFRec.GetWHBox(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), iBoxType, iManufWrty, iWrtyExpInLess31Days)

                    'Create new box
                    If dtBox.Rows.Count = 0 Then
                        dtBox = Me._objTFRec.CreateWarehouseBoxID(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), iBoxType, iManufWrty, iModelID, iWrtyExpInLess31Days)
                        If dtBox.Rows.Count = 0 Then
                            MessageBox.Show("System had failed to create new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll() : Exit Function
                        End If
                    End If

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    'SET edi.titem.WHRNO_ID = 5654 ( this meen exclude the record from edi-DEV944 )
                    If Me.chkNoEDIDev944.Checked = True Then iWHRNO_ID = Convert.ToInt32(Me.chkNoEDIDev944.Tag)

                    '*******************************************
                    'DISCREPANCY UNIT. IN BOX NOT IN FILE
                    '*******************************************
                    dt = Me._objTFRec.AddExtraUnit(strItemNo, strItemNo, Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("WO_CustWO"), Me.txtDiscrepancyIMEI.Text.Trim.ToUpper, "", True, iWHRNO_ID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("System has failed to add device into item table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus() : Exit Function
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate IMEI.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus()
                    ElseIf dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
                        MessageBox.Show("IMEI has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus()
                    Else
                        '************************************
                        'Receve device into database
                        '************************************

                        ' if box is cosmedic and tagged in the tmodel table as smartphone 
                        ' with kill switch then move to SW SCREEN.
                        If iBoxType = 1 Then
                            strWorkstation = "BER SCREEN"
                        Else
                            If _objModelManuf.IsKillSwitchModel(iModelID) AndAlso Me.cboBoxRec_BoxType.SelectedValue = 0 Then
                                strWorkstation = "SW SCREEN"
                            ElseIf objTFMisc.IsBuffable(iModelID) Then
                                strWorkstation = "PRE-BUFF"
                            Else
                                strWorkstation = "WH-WIP"
                            End If

                        End If

                        iDeviceID = Me._objTFRec.ReceiveDeviceIntoWIP(dtBox, dt.Rows(0)("Item_ID"), Me.cboDiscrepancyOrder.SelectedValue, iTrayID, Me.txtDiscrepancyIMEI.Text.Trim, iModelID, iManufWrty, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, strMSN, strWrtyDateCode, strLastDateInWrty, strAPC, Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Manuf_ID"), 90, iManufacturingCountryID, strWorkstation)

                        If iDeviceID > 0 Then
                            '*****************************
                            If iWrtyExpInLess31Days = 1 Then
                                Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                                If iManufWrty = 1 Then Me.lblDiscWrtyStatus.Text = "IW"
                                Me.lblWrtyExpedite_Disc.Text = dtBox.Rows(0)("BoxID")
                                Me.lblWrtyExpediteQty_Disc.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblWrtyExpedite_Disc.ForeColor = Color.Red
                                Me.lblInWrtyBoxID_Disc.ForeColor = Color.Green
                                Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Green
                            ElseIf iManufWrty = 1 Then
                                Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                                Me.lblDiscWrtyStatus.Text = "IW"
                                Me.lblInWrtyBoxID_Disc.Text = dtBox.Rows(0)("BoxID")
                                Me.lblInWrtyBoxQty_Disc.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblInWrtyBoxID_Disc.ForeColor = Color.Red
                                Me.lblWrtyExpedite_Disc.ForeColor = Color.Green
                                Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Green
                            Else
                                Me.lblDiscWrtyStatus.BackColor = Color.Purple
                                Me.lblDiscWrtyStatus.Text = "OW"
                                Me.lblOutWrtyBoxID_Disc.Text = dtBox.Rows(0)("BoxID")
                                Me.lblOutWrtyBoxQty_Disc.Text = CInt(dtBox.Rows(0)("Qty"))
                                Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Red
                                Me.lblInWrtyBoxID_Disc.ForeColor = Color.Green
                                Me.lblWrtyExpedite_Disc.ForeColor = Color.Green
                            End If

                            '******************************************************
                            'CONSUME PARTS @@@@@@
                            '******************************************************
                            ConsumePart(iDeviceID, iModelID, iManufWrty)

                            If iWFM_DeviceID > 0 Then Me._objTFRec.UpdateWFMCocFunProductionCompleted(iWFM_DeviceID.ToString, iWFM_WHB_ID, dtBox.Rows(0)("WB_ID"))

                            '******************************************************
                            Me.Enabled = True : Me.chkNoEDIDev944.Checked = False
                            Me.txtDiscrepancyIMEI.Text = "" : Me.txtDiscrepancyIMEI.Focus()
                        End If
                        '************************************
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessTFSN_Discrepancy", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt) : objTFMisc = Nothing
                If Not IsNothing(objCollectWrtyCode) Then
                    objCollectWrtyCode.Dispose() : objCollectWrtyCode = Nothing
                End If

                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Function

        '******************************************************************
        Private Function ProcessWFM2TF_SN_Discrepancy(ByVal dtWFMFullBox As DataTable) As Boolean
            Dim dt As DataTable
            Dim iDeviceID, iManufWrty, i, iManufID, iModelID, iWrtyExpInLess31Days, iManufacturingCountryID, iBoxType, iTrayID, iWHRNO_ID As Integer
            Dim iL_CustID As Integer = 0
            Dim objCollectWrtyCode As System.Object
            Dim dtBox As DataTable
            Dim strLastDateInWrty, strToday, strWrtyDateCode, strMSN, strAPC, strItemNo, strWorkstation As String
            Dim objTFMisc As New Data.Buisness.TracFone.clsMisc()
            Dim strTmpSN As String = ""
            Dim row As DataRow

            Try
                iDeviceID = 0 : iManufWrty = 0 : i = 0 : iManufID = 0 : iModelID = 0 : iWrtyExpInLess31Days = 0 : iManufacturingCountryID = 0 : iBoxType = 0 : iTrayID = 0 : iWHRNO_ID = 0
                strLastDateInWrty = "2016-07-29" : strWrtyDateCode = "" ' "07.29.2016"
                strMSN = "" : strAPC = "" : strItemNo = ""
                Me.lblDiscWrtyStatus.Text = ""
                Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                Me.lblInWrtyBoxID_Disc.ForeColor = Color.Lime
                Me.lblWrtyExpedite_Disc.ForeColor = Color.Lime
                Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Lime

                strItemNo = Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("cust_IncomingSku")
                iManufID = Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Manuf_ID")
                iModelID = Me.cboDiscModels.SelectedValue
                If Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue).Length > 0 AndAlso _
                   Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Model_Desc").ToString.Trim.EndsWith("_FUN") = True Then
                    iBoxType = 1
                End If
                '*******************************
                'Get Box
                '*******************************
                dtBox = Me._objTFRec.GetWHBox(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), _
                                              iBoxType, iManufWrty, iWrtyExpInLess31Days)

                'Create new box
                If dtBox.Rows.Count = 0 Then
                    dtBox = Me._objTFRec.CreateWarehouseBoxID(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), _
                    iBoxType, iManufWrty, iModelID, iWrtyExpInLess31Days)
                    If dtBox.Rows.Count = 0 Then
                        MessageBox.Show("System had failed to create new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    End If
                End If

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.SuspendLayout() : Me.tpDicrepancyReceiving.SuspendLayout()
                Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)

                'SET edi.titem.WHRNO_ID = 5654 ( this meen exclude the record from edi-DEV944 )
                If Me.chkNoEDIDev944.Checked = True Then iWHRNO_ID = Convert.ToInt32(Me.chkNoEDIDev944.Tag)

                '*******************************************
                'DISCREPANCY UNIT. IN BOX NOT IN FILE
                '*******************************************
                Dim iCount As Integer = 0
                For Each row In dtWFMFullBox.Rows 'each row
                    strTmpSN = row("Device_SN")

                    dt = Me._objTFRec.AddExtraUnit(strItemNo, strItemNo, Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), _
                         Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("WO_CustWO"), _
                         strTmpSN.Trim.ToUpper, "", True, iWHRNO_ID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("System has failed to add device into item table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Function
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate IMEI (" & strTmpSN & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Function
                    ElseIf dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
                        MessageBox.Show("IMEI (" & strTmpSN & ") has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        'Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus()
                        Exit Function
                    End If


                    'Else
                    '************************************
                    'Receve device into database
                    '************************************

                    ' if box is cosmedic and tagged in the tmodel table as smartphone 
                    ' with kill switch then move to SW SCREEN.
                    If iBoxType = 1 Then
                        strWorkstation = "BER SCREEN"
                    Else
                        If _objModelManuf.IsKillSwitchModel(iModelID) AndAlso Me.cboBoxRec_BoxType.SelectedValue = 0 Then
                            strWorkstation = "SW SCREEN"
                        ElseIf objTFMisc.IsBuffable(iModelID) Then
                            strWorkstation = "PRE-BUFF"
                        Else
                            strWorkstation = "WH-WIP"
                        End If
                    End If

                    iDeviceID = Me._objTFRec.ReceiveDeviceIntoWIP(dtBox, dt.Rows(0)("Item_ID"), Me.cboDiscrepancyOrder.SelectedValue, _
                                 iTrayID, strTmpSN.Trim, iModelID, iManufWrty, PSS.Core.ApplicationUser.IDShift, _
                                 PSS.Core.ApplicationUser.IDuser, strMSN, strWrtyDateCode, strLastDateInWrty, strAPC, _
                                 Me.cboDiscModels.DataSource.Table.Select("Model_ID = " & Me.cboDiscModels.SelectedValue)(0)("Manuf_ID"), _
                                 90, iManufacturingCountryID, strWorkstation, True)
                    If iDeviceID > 0 Then
                        iCount += 1 : ConsumePart(iDeviceID, iModelID, iManufWrty)
                    End If
                Next 'each row


                If Not iCount = dtWFMFullBox.Rows.Count Then
                    MessageBox.Show("Failed to receive all SNs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If

                Dim strDeviceIDs As String = ""
                For Each row In dtWFMFullBox.Rows
                    If strDeviceIDs.Trim.Length = 0 Then
                        strDeviceIDs = row("Device_ID")
                    Else
                        strDeviceIDs &= "," & row("Device_ID")
                    End If
                Next
                Me._objTFRec.UpdateWFMCocFunProductionCompleted(strDeviceIDs, dtWFMFullBox.Rows(0)("whb_id"), dtBox.Rows(0)("wb_id"))

                'If iDeviceID > 0 Then
                '*****************************
                If iWrtyExpInLess31Days = 1 Then
                    Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                    If iManufWrty = 1 Then Me.lblDiscWrtyStatus.Text = "IW"
                    Me.lblWrtyExpedite_Disc.Text = dtBox.Rows(0)("BoxID")
                    Me.lblWrtyExpediteQty_Disc.Text = CInt(dtBox.Rows(0)("Qty"))
                    Me.lblWrtyExpedite_Disc.ForeColor = Color.Red
                    Me.lblInWrtyBoxID_Disc.ForeColor = Color.Green
                    Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Green
                ElseIf iManufWrty = 1 Then
                    Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                    Me.lblDiscWrtyStatus.Text = "IW"
                    Me.lblInWrtyBoxID_Disc.Text = dtBox.Rows(0)("BoxID")
                    Me.lblInWrtyBoxQty_Disc.Text = CInt(dtBox.Rows(0)("Qty"))
                    Me.lblInWrtyBoxID_Disc.ForeColor = Color.Red
                    Me.lblWrtyExpedite_Disc.ForeColor = Color.Green
                    Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Green
                Else
                    Me.lblDiscWrtyStatus.BackColor = Color.Purple
                    Me.lblDiscWrtyStatus.Text = "OW"
                    Me.lblOutWrtyBoxID_Disc.Text = dtBox.Rows(0)("BoxID")
                    Me.lblOutWrtyBoxQty_Disc.Text = CInt(dtBox.Rows(0)("Qty"))
                    Me.lblOutWrtyBoxID_Disc.ForeColor = Color.Red
                    Me.lblInWrtyBoxID_Disc.ForeColor = Color.Green
                    Me.lblWrtyExpedite_Disc.ForeColor = Color.Green
                End If

                '******************************************************
                'CONSUME PARTS @@@@@@
                '******************************************************
                'ConsumePart(iDeviceID, iModelID, iManufWrty)

                '******************************************************
                Me.Enabled = True ': Me.chkNoEDIDev944.Checked = False
                'End If
                '************************************
                ' End If
                Return True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessTFSN_Discrepancy", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt) : objTFMisc = Nothing
                If Not IsNothing(objCollectWrtyCode) Then
                    objCollectWrtyCode.Dispose() : objCollectWrtyCode = Nothing
                End If

                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.ResumeLayout() : Me.tpDicrepancyReceiving.ResumeLayout()
            End Try
        End Function

        '******************************************************************
        Private Function ProcessWFM2TF_Box_SNs(ByVal dtWFMFullBox As DataTable, ByVal bIsNTFBox As Boolean) As Boolean
            Dim dt As DataTable
            Dim iDeviceID, iManufWrty, i, iManufID, iModelID, iWrtyExpInLess31Days, iManufacturingCountryID, iBoxType, iTrayID, iWHRNO_ID As Integer
            Dim iL_CustID As Integer = 0
            Dim objCollectWrtyCode As System.Object
            Dim dtBox As DataTable
            Dim strLastDateInWrty, strToday, strWrtyDateCode, strMSN, strAPC, strItemNo, strWorkstation As String
            Dim objTFMisc As New Data.Buisness.TracFone.clsMisc()
            Dim strTmpSN As String = ""
            Dim row As DataRow
            Dim iIsWFM As Integer = 1

            Try

                iDeviceID = 0 : iManufWrty = 0 : i = 0 : iManufID = 0 : iModelID = 0 : iWrtyExpInLess31Days = 0
                iManufacturingCountryID = 0 : iBoxType = 0 : iTrayID = 0 : iWHRNO_ID = 0
                strLastDateInWrty = "2016-07-29" : strWrtyDateCode = "" ' "07.29.2016"
                strMSN = "" : strAPC = "" : strItemNo = ""
                Me.lblWFM2TF_OutWrtyBoxID.ForeColor = Color.Lime
                Me.cboWFM2TFOrder.Enabled = False

                strItemNo = Me.cboWFM2TFModels.DataSource.Table.Select("Model_ID = " & Me.cboWFM2TFModels.SelectedValue)(0)("cust_IncomingSku")
                iManufID = Me.cboWFM2TFModels.DataSource.Table.Select("Model_ID = " & Me.cboWFM2TFModels.SelectedValue)(0)("Manuf_ID")
                iModelID = Me.cboWFM2TFModels.SelectedValue
                If Me.cboWFM2TFModels.DataSource.Table.Select("Model_ID = " & Me.cboWFM2TFModels.SelectedValue).Length > 0 AndAlso _
                   Me.cboWFM2TFModels.DataSource.Table.Select("Model_ID = " & Me.cboWFM2TFModels.SelectedValue)(0)("Model_Desc").ToString.Trim.EndsWith("_FUN") = True Then
                    iBoxType = 1 '_FUN , 0=COS default
                End If

                'Create new Box
                dtBox = Me._objTFRec.CreateWFM2TF_WarehouseBoxID(Me.cboWFM2TFOrder.DataSource.Table.Select("WO_ID = " & Me.cboWFM2TFOrder.SelectedValue)(0)("Order_ID"), _
                                                                 iBoxType, iManufWrty, iModelID, iWrtyExpInLess31Days)
                If dtBox.Rows.Count = 0 Then
                    MessageBox.Show("System had failed to create new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                    Exit Function
                End If

                'start to receive
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.SuspendLayout() : Me.tpReceivingWFMBox2TF.SuspendLayout()
                Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)

                'SET edi.titem.WHRNO_ID = 5654 ( this meen exclude the record from edi-DEV944 )
                If Me.chkWFM2TF_NoEDIDev944.Checked = True Then iWHRNO_ID = Convert.ToInt32(Me.chkWFM2TF_NoEDIDev944.Tag)

                'receive each SN and save
                Dim iCount As Integer = 0
                For Each row In dtWFMFullBox.Rows 'each row
                    strTmpSN = row("Device_SN")

                    dt = Me._objTFRec.AddWFM2TF_SN_To_tItem(strItemNo, strItemNo, _
                         Me.cboWFM2TFOrder.DataSource.Table.Select("WO_ID = " & Me.cboWFM2TFOrder.SelectedValue)(0)("Order_ID"), _
                         Me.cboWFM2TFOrder.DataSource.Table.Select("WO_ID = " & Me.cboWFM2TFOrder.SelectedValue)(0)("WO_CustWO"), _
                         strTmpSN.Trim.ToUpper, iWHRNO_ID, iIsWFM)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("System has failed to add device " & strTmpSN & " into item table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return False
                        Exit Function
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate IMEI (" & strTmpSN & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return False
                        Exit Function
                    ElseIf dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("Device_ID")) AndAlso dt.Rows(0)("Device_ID") > 0 Then
                        MessageBox.Show("IMEI (" & strTmpSN & ") has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return False
                        Exit Function
                    End If

                    ' if box is cosmedic and tagged in the tmodel table as smartphone 
                    ' with kill switch then move to SW SCREEN.
                    If iBoxType = 1 Then
                        strWorkstation = "BER SCREEN"
                    Else
                        If _objModelManuf.IsKillSwitchModel(iModelID) AndAlso Me.cboBoxRec_BoxType.SelectedValue = 0 Then
                            strWorkstation = "SW SCREEN"
                        ElseIf objTFMisc.IsBuffable(iModelID) Then
                            strWorkstation = "PRE-BUFF"
                        Else
                            strWorkstation = "WH-WIP"
                        End If
                    End If

                    If bIsNTFBox Then strWorkstation = "WH-WIP"

                    iDeviceID = Me._objTFRec.ReceiveWFM2TF_DeviceIntoWIP(dtBox, dt.Rows(0)("Item_ID"), Me.cboWFM2TFOrder.SelectedValue, _
                                 iTrayID, strTmpSN.Trim, iModelID, iManufWrty, PSS.Core.ApplicationUser.IDShift, _
                                 PSS.Core.ApplicationUser.IDuser, strMSN, strWrtyDateCode, strLastDateInWrty, strAPC, _
                                 Me.cboWFM2TFModels.DataSource.Table.Select("Model_ID = " & Me.cboWFM2TFModels.SelectedValue)(0)("Manuf_ID"), _
                                 90, iManufacturingCountryID, strWorkstation, True)

                    If iDeviceID > 0 Then
                        iCount += 1 : ConsumePart(iDeviceID, iModelID, iManufWrty)
                    End If
                Next 'each row

                If Not iCount = dtWFMFullBox.Rows.Count Then
                    MessageBox.Show("Failed to receive all SNs. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If

                Dim strDeviceIDs As String = ""
                For Each row In dtWFMFullBox.Rows
                    If strDeviceIDs.Trim.Length = 0 Then
                        strDeviceIDs = row("Device_ID")
                    Else
                        strDeviceIDs &= "," & row("Device_ID")
                    End If
                Next

                If Not bIsNTFBox Then
                    Me._objTFRec.UpdateWFMCocFunProductionCompleted(strDeviceIDs, dtWFMFullBox.Rows(0)("whb_id"), dtBox.Rows(0)("wb_id"))
                End If

                Me.lblWFM2TF_OutWrtyBoxID.Text = dtBox.Rows(0)("BoxID")
                Me.lblWFM2TF_OutWrtyBoxQty.Text = dtWFMFullBox.Rows(0).Item("quantity")
                Me.lblWFM2TF_OutWrtyBoxID.ForeColor = Color.Red
                Me.lblWFMModel.Text = "WFM Model: " & dtWFMFullBox.Rows(0).Item("WFM_Model")

                For Each row In dtWFMFullBox.Rows 'each row
                    Me.lstWFM2TF_SNsInBox.Items.Add(row("Device_SN"))
                Next
                Me.lblWFM2TF_SN_Count.Text = Me.lstWFM2TF_SNsInBox.Items.Count

                Me.lstWFM2TF_SNsInBox.Visible = True
                Me.lblWFM2TF_SN_Count.Visible = True
                Me.Enabled = True
                Return True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessWFM2TF_Box_SNs", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt) : objTFMisc = Nothing
                If Not IsNothing(objCollectWrtyCode) Then
                    objCollectWrtyCode.Dispose() : objCollectWrtyCode = Nothing
                End If

                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.ResumeLayout() : Me.tpDicrepancyReceiving.ResumeLayout()
            End Try
        End Function




        '**************************************************************************************************************
        Private Sub cboDiscrepancyOrder_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDiscrepancyOrder.RowChange
            Try
                Me.lblDiscWrtyStatus.Text = "" : Me.lblDiscWrtyStatus.BackColor = Color.SteelBlue
                Me.txtDiscrepancyIMEI.Text = "" ': Me.chkNoEDIDev944.Checked = False

                If sender.name = "cboDiscrepancyOrder" AndAlso Me._booLoadDataToCtrl = False Then
                    If Not IsNothing(cboDiscrepancyOrder.DataSource) AndAlso cboDiscrepancyOrder.SelectedValue > 0 Then
                        Me.PopulateOpenBoxes(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), False)
                    End If
                    If Me.chkBoxWFM.Checked And Me.txtWFMBox.Text.Trim.Length = 0 Then
                        Me.cboDiscModels.SelectedValue = 0 : Me.cboDiscModels.Enabled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboDiscrepancyOrder", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************************************************
        Private Sub btnCloseBoxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseIWBox.Click, btnCloseIWEBox.Click, btnCloseOWBox.Click
            Dim strBoxName As String = ""
            Dim dt As DataTable

            Try
                If Me.cboDiscrepancyOrder.SelectedValue = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                ElseIf Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue).length = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboDiscrepancyOrder.SelectAll() : Me.cboDiscrepancyOrder.Focus()
                Else
                    If sender.name = "btnCloseIWBox" Then
                        strBoxName = Me.lblInWrtyBoxID_Disc.Text.Trim.ToUpper
                    ElseIf sender.name = "btnCloseIWEBox" Then
                        strBoxName = Me.lblWrtyExpedite_Disc.Text.Trim.ToUpper
                    ElseIf sender.name = "btnCloseOWBox" Then
                        strBoxName = Me.lblOutWrtyBoxID_Disc.Text.Trim.ToUpper
                    End If

                    If strBoxName.Trim.Length = 0 Then
                        MessageBox.Show("No open box to close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf MessageBox.Show("Are you sure you want to close this box """ & strBoxName & """??.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        Exit Sub
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        dt = Me._objTFRec.GetWHBoxByBoxNameAndOrderID(strBoxName, Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"))
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Box name does not exist in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("More than one box existed in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Else
                            Me._objTFRec.CloseWareHouseBox(dt.Rows(0)("wb_id"))
                            If Me.chkBoxWFM.Checked Then
                                Me.lblOutWrtyBoxID_Disc.Text = ""
                                Me.lblOutWrtyBoxQty_Disc.Text = 0
                                Me.txtWFMBox.Text = ""
                                Me.cboDiscModels.Enabled = True
                                Me.txtWFMBox.SelectAll() : Me.txtWFMBox.Focus()
                            Else
                                PopulateOpenBoxes(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), False)
                            End If
                            ' PopulateOpenBoxes(Me.cboDiscrepancyOrder.DataSource.Table.Select("WO_ID = " & Me.cboDiscrepancyOrder.SelectedValue)(0)("Order_ID"), False)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name.ToString, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************************************************
        Private Sub btnCloseWFM2TFBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseWFM2TFBox.Click
            Dim strBoxName As String = ""
            Dim dt As DataTable

            Try
                strBoxName = Me.lblWFM2TF_OutWrtyBoxID.Text.Trim.ToUpper
                If strBoxName.Trim.Length = 0 Then
                    MessageBox.Show("No open box to close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf MessageBox.Show("Are you sure you want to close this box """ & strBoxName & """??.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    dt = Me._objTFRec.GetWFM2TF_WHBoxByBoxNameAndOrderID(strBoxName, Me.cboWFM2TFOrder.DataSource.Table.Select("WO_ID = " & Me.cboWFM2TFOrder.SelectedValue)(0)("Order_ID"))
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Box name does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("More than one box existed in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf Not Me.lblWFM2TF_OutWrtyBoxQty.Text = Me.lblWFM2TF_SN_Count.Text Then
                        MessageBox.Show("Qty Devices is not equal to qty of the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        Me._objTFRec.CloseWareHouseBox(dt.Rows(0)("wb_id"))
                        Me.lblWFM2TF_OutWrtyBoxID.Text = ""
                        Me.lblWFM2TF_OutWrtyBoxQty.Text = 0
                        Me.txtWFM2TF_BoxName.Text = ""
                        ' Me.cboWFM2TFModels.Enabled = True
                        Me.lstWFM2TF_SNsInBox.Items.Clear()
                        Me.lblWFM2TF_SN_Count.Text = 0
                        Me.lstWFM2TF_SNsInBox.Visible = False
                        Me.lblWFM2TF_SN_Count.Visible = False
                        Me.cboWFM2TFOrder.Enabled = True
                        Me.lblWFMModel.Text = ""
                        Me.cboWFM2TFModels.SelectedValue = 0
                        Me.lstWFM2TF_SNsInBox.Items.Clear()

                        Me.txtWFM2TF_BoxName.SelectAll() : Me.txtWFM2TF_BoxName.Focus()

                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name.ToString, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************************************************
        Private Sub ConsumePart(ByVal iDeviceID As Integer, ByVal iModelID As Integer, ByVal iManufWrty As Integer)
            Const iFailID As Integer = 311
            Dim iRepID As Integer
            Dim dt As DataTable
            Dim objDevice As Rules.Device
            Dim R1 As DataRow

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                dt = Me._objTFRec.GetBillcodeIDsForAutoConsumeParts(iModelID)

                If dt.Rows.Count > 0 Then
                    If Convert.ToInt32(dt.Rows(0)("Manuf_ID")) = 16 Then      'LG
                        iRepID = 88
                    ElseIf Convert.ToInt32(dt.Rows(0)("Manuf_ID")) = 21 Then      'SamSung
                        iRepID = 83
                    ElseIf Convert.ToInt32(dt.Rows(0)("Manuf_ID")) = 1 Then      'Motorola
                        iRepID = 90
                    ElseIf Convert.ToInt32(dt.Rows(0)("Manuf_ID")) = 24 Then      'Nokia
                        iRepID = 96
                    End If

                    objDevice = New Rules.Device(iDeviceID)

                    For Each R1 In dt.Rows
                        If iManufWrty > 0 AndAlso Convert.ToInt16(R1("LaborLevel")) > 0 Then
                            objDevice.FailID = iFailID
                            objDevice.RepairID = iRepID
                        End If

                        objDevice.AddPart(R1("Billcode_ID"))
                    Next R1
                    objDevice.Update()
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************************************************
        Private Sub chkBoxWFM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBoxWFM.Click
            Try
                If Me.chkBoxWFM.Checked Then
                    Me.chkBoxWFM.ForeColor = Color.Blue
                    Me.txtWFMBox.Top = Me.txtDiscrepancyIMEI.Top
                    Me.txtWFMBox.Left = Me.txtDiscrepancyIMEI.Left
                    Me.txtWFMBox.Width = Me.txtDiscrepancyIMEI.Width
                    Me.txtDiscrepancyIMEI.Visible = False
                    Me.txtWFMBox.Visible = True
                    Me.cboDiscModels.Enabled = False
                    Me.txtWFMBox.Text = ""
                    Me.Label15.Text = "WFM Box :"
                    Me.chkNoEDIDev944.Checked = True
                    Me.cboDiscModels.SelectedValue = 0
                    Me.txtWFMBox.SelectAll() : Me.txtWFMBox.Focus()
                Else
                    Me.chkBoxWFM.ForeColor = Color.White
                    Me.txtDiscrepancyIMEI.Visible = True
                    Me.txtWFMBox.Visible = False
                    Me.txtDiscrepancyIMEI.Text = ""
                    Me.Label15.Text = "IMEI/MEID :"
                    Me.txtDiscrepancyIMEI.SelectAll() : Me.txtDiscrepancyIMEI.Focus()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name.ToString, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub chkNoEDIDev944_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNoEDIDev944.Click
            Try
                If Me.chkBoxWFM.Checked Then
                    chkNoEDIDev944.Checked = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name.ToString, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub chkWFM2TF_NoEDIDev944_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWFM2TF_NoEDIDev944.Click
            Try
                Me.chkWFM2TF_NoEDIDev944.Checked = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name.ToString, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        '**************************************************************************************************************

#End Region

#Region "LAN USE ONLY"

		'******************************************************************
		Private Sub btnLanUseOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLanUseOnly.Click
			'Dim strSql, strDeviceIDs As String
			'Dim dt1, dt2 As DataTable
			'Dim R1, R2 As DataRow
			'Dim objTFBilling As New TracFone.TFBilling()
			'Dim i, j As Integer
			'Dim booFlatRate As Boolean = False
			'Dim objDevice As Rules.Device
			'Dim decDBill_InvoiceAmt As Decimal
			'Dim strNotFlatRateModel As String = ""

			'Try
			'    strDeviceIDs = ""

			'    strSql = "select tdevice.*, Pallet_Shiptype, Manuf_ID, FuncRep from tdevice " & Environment.NewLine
			'    strSql &= "inner join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID" & Environment.NewLine
			'    'strSql &= "inner join tpackingslip on tpallett.pkslip_ID = tpackingslip.pkslip_ID" & Environment.NewLine
			'    strSql &= "INNER JOIN tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
			'    strSql &= "inner join edi.titem on tdevice.Device_ID = edi.titem.device_ID " & Environment.NewLine
			'    strSql &= "where tdevice.loc_id = 2946  " & Environment.NewLine
			'    strSql &= "and Pallet_shiptype = 0 AND pkslip_id is null and pallet_shiptype = 0  " & Environment.NewLine
			'    ' strSql &= "AND tdevice.model_ID in ( 3464, 3465 ) "
			'    'strSql &= "and pkslip_createDt >= '2014-10-01 00:00:00' " & Environment.NewLine
			'    dt1 = Me._objTFRec.GetSpecialDeviceIDs(strSql)

			'    For Each R1 In dt1.Rows
			'        booFlatRate = PSS.Data.Buisness.DeviceBilling.IsFlatRateModel(2258, R1("Model_ID"), True, )
			'        If booFlatRate = False Then
			'            If strNotFlatRateModel.Trim.Length > 0 Then strNotFlatRateModel &= ", "
			'            strNotFlatRateModel &= R1("Model_ID") & Environment.NewLine
			'        End If

			'        strSql = "update tdevicebill inner join lbillcodes ON tdevicebill.billcode_ID = lbillcodes.billcode_ID " & Environment.NewLine
			'        strSql &= " Set DBill_InvoiceAmt = 0 "
			'        strSql &= "WHERE tdevicebill.device_ID = " & R1("Devi ce_ID") & " and billtype_ID = 2 " & Environment.NewLine
			'        i += Me._objTFRec.Execute(strSql)

			'        objTFBilling.BillServices(R1, R1("Pallet_Shiptype"), 2258, booFlatRate)
			'    Next R1

			'    MsgBox("Completed." & Environment.NewLine & strNotFlatRateModel)
			'    'System.Windows.Forms.Clipboard.SetDataObject(strNotFlatRateModel, False)

			'Catch ex As Exception
			'    MessageBox.Show(ex.ToString, "btnLanUseOnly_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			'Finally
			'    PSS.Data.Buisness.Generic.DisposeDT(dt1)

			'    GC.Collect() : GC.WaitForPendingFinalizers()
			'    GC.Collect() : GC.WaitForPendingFinalizers()
			'End Try
		End Sub

		'******************************************************************
		Private Sub UpdateRVPrice()
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objBook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet
			Dim strFilePatth As String = ""
			Dim i, j As Integer
			Dim strSql, strPartNo, strBillCode_ID, strInvoiceAmt, strRegPartPrice As String
			Dim dt1 As DataTable
			Dim objOFD As New Windows.Forms.OpenFileDialog()
			Dim R1 As DataRow

			Try
				objOFD.FilterIndex = 1
				objOFD.ShowDialog()
				strFilePatth = Trim(objOFD.FileName)

				objExcel = New Excel.Application()
				objBook = objExcel.Workbooks.Open(strFilePatth)
				objSheet = objExcel.Worksheets(1)
				objExcel.Visible = True

				i = 2 : j = 0 : strPartNo = "" : strBillCode_ID = "" : strInvoiceAmt = "" : strRegPartPrice = ""
				strPartNo = objSheet.Range("A" & i).Value.ToString.Trim
				'strBillCode_ID = objSheet.range("B" & i).value.ToString.Trim
				strInvoiceAmt = objSheet.Range("C" & i).Value.ToString.Trim
				strRegPartPrice = objSheet.Range("D" & i).Value.ToString.Trim

				While strPartNo.Length > 0 AndAlso strInvoiceAmt.Trim.Length > 0 AndAlso strRegPartPrice.Trim.Length > 0
					strSql = " SELECT tdevice.Device_ID, DBill_ID, DBill_StdCost, DBill_InvoiceAmt, DBill_RegPartPrice " & Environment.NewLine
					strSql &= "FROM tdevice" & Environment.NewLine
					strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID AND tdevice.Loc_ID = 2946 AND Pallet_ShipType = 0 and tpallett.pkslip_ID is null " & Environment.NewLine
					'strSql &= "INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID AND pkslip_createDt > '2011-02-01 00:00:00' " & Environment.NewLine
					strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
					strSql &= "AND DBill_RegPartPrice = 0 and Part_Number = '" & strPartNo & "' And DBill_InvoiceAmt = " & strInvoiceAmt & Environment.NewLine
					strSql &= "UNION " & Environment.NewLine
					strSql &= " SELECT tdevice.Device_ID, DBill_ID, DBill_StdCost, DBill_InvoiceAmt, DBill_RegPartPrice " & Environment.NewLine
					strSql &= "FROM tdevice" & Environment.NewLine
					'strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID AND tdevice.Loc_ID = 2946 AND Pallet_ShipType = 0 " & Environment.NewLine
					'strSql &= "INNER JOIN tpackingslip ON tpallett.pkslip_ID = tpackingslip.pkslip_ID AND pkslip_createDt > '2011-02-01 00:00:00' " & Environment.NewLine
					strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID AND tdevice.Loc_ID = 2946 AND tdevice.Pallett_ID is null " & Environment.NewLine
					strSql &= "AND DBill_RegPartPrice = 0 and Part_Number = '" & strPartNo & "'" & Environment.NewLine
					strSql &= "AND  DBill_InvoiceAmt = " & strInvoiceAmt & Environment.NewLine

					dt1 = _objTFRec.GetSpecialDeviceIDs(strSql)

					For Each R1 In dt1.Rows
						strSql = "Update tdevicebill Set DBill_RegPartPrice = " & strRegPartPrice & " WHERE DBill_ID = " & R1("DBill_ID")
						j += Me._objTFRec.Execute(strSql)
					Next R1

					PSS.Data.Buisness.Generic.DisposeDT(dt1) : i += 1
					If Not IsNothing(objSheet.Range("A" & i).Value) Then strPartNo = objSheet.Range("A" & i).Value.ToString.Trim Else strPartNo = ""
					'If Not IsNothing(objSheet.range("B" & i).value) Then strBillCode_ID = objSheet.range("B" & i).value.ToString.Trim Else strBillCode_ID = ""
					If Not IsNothing(objSheet.Range("C" & i).Value) Then strInvoiceAmt = objSheet.Range("C" & i).Value.ToString.Trim Else strInvoiceAmt = ""
					If Not IsNothing(objSheet.Range("D" & i).Value) Then strRegPartPrice = objSheet.Range("D" & i).Value.ToString.Trim Else strRegPartPrice = ""
				End While


				MsgBox("Completed.")
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnLanUseOnly_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Finally
				If Not IsNothing(objOFD) Then
					objOFD.Dispose()
					objOFD = Nothing
				End If
				PSS.Data.Buisness.Generic.DisposeDT(dt1)
				If Not IsNothing(objSheet) Then
					objSheet = Nothing
					System.Runtime.InteropServices.Marshal.ReleaseComObject(objSheet)
				End If
				If Not IsNothing(objBook) Then
					objBook.Close()
					objBook = Nothing
					System.Runtime.InteropServices.Marshal.ReleaseComObject(objBook)
				End If
				If Not IsNothing(objExcel) Then
					objExcel.Quit()
					objExcel = Nothing
					System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
				End If

				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Sub

		'******************************************************************
		Private Sub ProcessDeviceBilling(ByVal strDeviceIDs As String)
			Dim dt, dt2, dtMaxClaimablePartLevel As DataTable
			Dim strSql As String = ""
			Dim R1, R2 As DataRow
			Dim objDevice As Rules.Device
			Dim i, iInvYrMonth As Integer
			Dim objTFBilling As New PSS.Data.Buisness.TracFone.TFBillingData()
			Dim objTFBillService As New TracFone.TFBilling()
			Dim booFlatRate As Boolean = False

			Try
				strSql = "select WrtyClaimableFlg, Manuf_ID, Device_ManufWrty, tdevice.Device_ID, tdevice.Model_ID, FuncRep, Pallet_ShipType, Cust_ID,  CellOpt_VerificationID  " & Environment.NewLine
				strSql &= ", if(Device_dateship is not null,  Device_dateship, now()) as InvPeriod" & Environment.NewLine
				strSql &= "from tdevice " & Environment.NewLine
				strSql &= "inner join edi.titem on tdevice.Device_id = edi.titem.device_id " & Environment.NewLine
				strSql &= "inner join tpallett on tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
				strSql &= "inner join tmodel on tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
				strSql &= "inner join tcellopt on tdevice.device_id = tcellopt.device_ID " & Environment.NewLine
				strSql &= "where tdevice.Loc_ID = 2946 AND tdevice.device_ID in ( " & strDeviceIDs & " )  "
				dt = Me._objTFRec.GetSpecialDeviceIDs(strSql)

				For Each R1 In dt.Rows
					iInvYrMonth = CInt(CDate(R1("InvPeriod")).Year & CDate(R1("InvPeriod")).Month.ToString("00"))
					booFlatRate = Data.Buisness.DeviceBilling.IsFlatRateModel(R1("Cust_ID"), R1("Model_ID"), True, )
					'dtMaxClaimablePartLevel = objTFBilling.GetMaxClaimablePartsAndReflowLevel(R1("Device_ID"), R1("Manuf_ID"))

					'objTFBilling.SetWrtyClaimableFlag(R1("Device_ID"), R1("Manuf_ID"), R1("WrtyClaimableFlg"), dtMaxClaimablePartLevel)

					objTFBillService.BillServices(R1, R1("Pallet_ShipType"), R1("Cust_ID"), booFlatRate, iInvYrMonth)
				Next R1

				'MsgBox("Completed.")
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "ProcessDeviceBilling", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Finally
				If Not IsNothing(objDevice) Then
					objDevice.Dispose()
					objDevice = Nothing
				End If
				Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
				R1 = Nothing : R2 = Nothing : objTFBilling = Nothing
			End Try
		End Sub

		'******************************************************************
		Public Function UnDoBillingGotRemoveWhenScanInFailBucket()
			Dim dt, dt2 As DataTable
			Dim strSql As String = ""
			Dim R1, R2 As DataRow
			Dim objDevice As Rules.Device
			Dim i As Integer = 0
			Dim strNotMap, strExisted As String

			Try
				strNotMap = "" : strExisted = ""

				strSql = "Select tdevice.* " & Environment.NewLine
				strSql &= "from tdevice  " & Environment.NewLine
				strSql &= "inner join tcellopt on tdevice.Device_ID = tcellopt.Device_ID  " & Environment.NewLine
				strSql &= "where loc_id = 2946 and workstation like 'FUNCTIONAL FAIL%' " & Environment.NewLine
				dt = Me._objTFRec.GetSpecialDeviceIDs(strSql)

				For Each R1 In dt.Rows
					strSql = "SELECT tparttransaction.* FROM tparttransaction " & Environment.NewLine
					strSql &= "INNER JOIN lbillcodes ON tparttransaction.Billcode_ID = lbillcodes.billcode_ID " & Environment.NewLine
					strSql &= "WHERE tparttransaction.Device_ID = " & R1("Device_ID") & Environment.NewLine
					strSql &= "AND BillType_ID = 2 AND Trans_Amount < 0 " & Environment.NewLine
					dt2 = Me._objTFRec.GetSpecialDeviceIDs(strSql)

					If dt2.Rows.Count > 0 Then objDevice = New Rules.Device(R1("Device_ID"))

					For Each R2 In dt2.Rows
						If PSS.Data.Buisness.Generic.IsBillcodeMapped(R1("Model_ID"), R2("Billcode_ID")) > 0 Then
							If PSS.Data.Buisness.Generic.IsBillcodeExisted(R2("Device_ID"), R2("Billcode_ID")) = False Then
								objDevice.AddPart(R2("Billcode_ID"))
							Else
								If strExisted.Trim.Length > 0 Then strExisted &= ","
								strExisted &= R2("Device_ID") & "|" & R2("Billcode_ID")
							End If
						Else
							If strNotMap.Trim.Length > 0 Then strNotMap &= ","
							strNotMap &= R2("Device_ID") & "|" & R2("Billcode_ID")
						End If
					Next R2

					If dt2.Rows.Count > 0 Then
						objDevice.Update()
						objDevice.Dispose() : objDevice = Nothing
						R2 = Nothing : Generic.DisposeDT(dt2)
					End If
				Next R1

				MsgBox("Completed.")
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnLanUseOnly_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
			Finally
				If Not IsNothing(objDevice) Then
					objDevice.Dispose()
					objDevice = Nothing
				End If
				R1 = Nothing
				PSS.Data.Buisness.Generic.DisposeDT(dt)
			End Try
		End Function

		'******************************************************************
		Private Sub SWapFailcodes()
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objBook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet
			Dim strFilePatth As String = ""
			Dim i As Integer = 2
			Dim strSql, strManufID, strModelID, strDeviceID, strBillcodeID, strOldFailID, strNewFailID, strPartNo As String
			Dim dt1 As DataTable
			Dim objOFD As New Windows.Forms.OpenFileDialog()

			Try
				objOFD.FilterIndex = 1
				objOFD.ShowDialog()
				strFilePatth = Trim(objOFD.FileName)

				objExcel = New Excel.Application()
				objBook = objExcel.Workbooks.Open(strFilePatth)
				objSheet = objExcel.Worksheets(1)
				objExcel.Visible = True

				i = 2 : strManufID = "" : strModelID = "" : strDeviceID = ""
				strBillcodeID = "" : strOldFailID = "" : strNewFailID = "" : strPartNo = ""
				strManufID = objSheet.Range("A" & i).Value.ToString.Trim
				strModelID = objSheet.Range("B" & i).Value.ToString.Trim
				strDeviceID = objSheet.Range("C" & i).Value.ToString.Trim
				strPartNo = objSheet.Range("E" & i).Value.ToString.Trim
				strOldFailID = objSheet.Range("G" & i).Value.ToString.Trim
				strNewFailID = objSheet.Range("K" & i).Value.ToString.Trim

				While strManufID.Length > 0 AndAlso strModelID.Length > 0 _
					AndAlso strDeviceID.Length > 0 AndAlso strPartNo.Length > 0 _
					AndAlso strOldFailID.Length > 0 AndAlso strNewFailID.Length > 0

					strSql = " SELECT * " & Environment.NewLine
					strSql &= "FROM tdeviceBill " & Environment.NewLine
					strSql &= "WHERE Device_ID = " & CInt(strDeviceID) & Environment.NewLine
					'strSql &= "AND Billcode_ID = " & CInt(strBillcodeID) & Environment.NewLine
					strSql &= "AND Part_Number = '" & strPartNo & "'" & Environment.NewLine
					dt1 = Me._objTFRec.GetSpecialDeviceIDs(strSql)

					If dt1.Rows.Count > 1 Then
						objSheet.Range("N" & i).FormulaR1C1 = "Existed more than one"
					ElseIf dt1.Rows.Count = 0 Then
						objSheet.Range("N" & i).FormulaR1C1 = "Not Found"
					Else
						strSql = " update tdevicebill SET Fail_ID = " & CInt(strNewFailID) & Environment.NewLine
						strSql &= "WHERE DBill_ID = " & dt1.Rows(0)("DBill_ID") & Environment.NewLine
						_objTFRec.Execute(strSql)
						ProcessDeviceBilling(strDeviceID)
						objSheet.Range("N" & i).FormulaR1C1 = dt1.Rows(0)("Fail_ID") & " => " & strNewFailID
					End If

					'Reset variable
					PSS.Data.Buisness.Generic.DisposeDT(dt1)
					i += 1
					strManufID = objSheet.Range("A" & i).Value.ToString.Trim
					strModelID = objSheet.Range("B" & i).Value.ToString.Trim
					strDeviceID = objSheet.Range("C" & i).Value.ToString.Trim
					strPartNo = objSheet.Range("E" & i).Value.ToString.Trim
					strOldFailID = objSheet.Range("G" & i).Value.ToString.Trim
					strNewFailID = objSheet.Range("K" & i).Value.ToString.Trim
				End While

				MsgBox("Completed.")

				objBook.SaveAs(strFilePatth)
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "SWapFailcodes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				If Not IsNothing(objOFD) Then
					objOFD.Dispose()
					objOFD = Nothing
				End If
				PSS.Data.Buisness.Generic.DisposeDT(dt1)
				If Not IsNothing(objSheet) Then
					objSheet = Nothing
					System.Runtime.InteropServices.Marshal.ReleaseComObject(objSheet)
				End If
				If Not IsNothing(objBook) Then
					objBook.Close()
					objBook = Nothing
					System.Runtime.InteropServices.Marshal.ReleaseComObject(objBook)
				End If
				If Not IsNothing(objExcel) Then
					objExcel.Quit()
					objExcel = Nothing
					System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
				End If

				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Sub

		'******************************************************************
		Private Sub AddParts()
			Dim objExcel As Excel.Application			 ' Excel application
			Dim objBook As Excel.Workbook			  ' Excel workbook
			Dim objSheet As Excel.Worksheet			 ' Excel Worksheet
			Dim strFilePatth As String = ""
			Dim i As Integer = 2
			Dim strSql, strManufID, strModelID, strDeviceID, strBillcodeID, strFailID, strRepairID As String
			Dim objOFD As New Windows.Forms.OpenFileDialog()
			Dim objDevice As Rules.Device

			Try
				objOFD.FilterIndex = 1
				objOFD.ShowDialog()
				strFilePatth = Trim(objOFD.FileName)

				objExcel = New Excel.Application()
				objBook = objExcel.Workbooks.Open(strFilePatth)
				objSheet = objExcel.Worksheets(1)
				objExcel.Visible = True

				i = 2 : strManufID = "" : strModelID = "" : strDeviceID = ""
				strBillcodeID = "" : strFailID = "" : strRepairID = ""
				strManufID = objSheet.Range("A" & i).Value.ToString.Trim
				strModelID = objSheet.Range("B" & i).Value.ToString.Trim
				strDeviceID = objSheet.Range("C" & i).Value.ToString.Trim
				strBillcodeID = objSheet.Range("N" & i).Value.ToString.Trim
				strFailID = objSheet.Range("K" & i).Value.ToString.Trim
				strRepairID = objSheet.Range("L" & i).Value.ToString.Trim

				While strManufID.Length > 0 AndAlso strModelID.Length > 0 _
					AndAlso strDeviceID.Length > 0 AndAlso strBillcodeID.Length > 0 _
					AndAlso strFailID.Length > 0 AndAlso strRepairID.Length > 0

					If PSS.Data.Buisness.Generic.IsBillcodeExisted(CInt(strDeviceID), CInt(strBillcodeID)) = False Then
						objDevice = New Rules.Device(CInt(strDeviceID))
						objDevice.FailID = CInt(strFailID)
						objDevice.RepairID = CInt(strRepairID)
						objDevice.AddPart(CInt(strBillcodeID))
						objSheet.Range("O" & i).FormulaR1C1 = "Added"
					Else
						objSheet.Range("O" & i).FormulaR1C1 = "Existed"
					End If
					ProcessDeviceBilling(strDeviceID)

					'Reset variable
					If Not IsNothing(objDevice) Then
						objDevice.Dispose()
						objDevice = Nothing
					End If
					i += 1
					strManufID = objSheet.Range("A" & i).Value.ToString.Trim
					strModelID = objSheet.Range("B" & i).Value.ToString.Trim
					strDeviceID = objSheet.Range("C" & i).Value.ToString.Trim
					strBillcodeID = objSheet.Range("N" & i).Value.ToString.Trim
					strFailID = objSheet.Range("K" & i).Value.ToString.Trim
					strRepairID = objSheet.Range("L" & i).Value.ToString.Trim
				End While

				MsgBox("Completed.")

				objBook.SaveAs(strFilePatth)
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "AddParts", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				If Not IsNothing(objDevice) Then
					objDevice.Dispose()
					objDevice = Nothing
				End If
				If Not IsNothing(objSheet) Then
					objSheet = Nothing
					System.Runtime.InteropServices.Marshal.ReleaseComObject(objSheet)
				End If
				If Not IsNothing(objBook) Then
					objBook.Close()
					objBook = Nothing
					System.Runtime.InteropServices.Marshal.ReleaseComObject(objBook)
				End If
				If Not IsNothing(objExcel) Then
					objExcel.Quit()
					objExcel = Nothing
					System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
				End If

				GC.Collect()
				GC.WaitForPendingFinalizers()
				GC.Collect()
				GC.WaitForPendingFinalizers()
			End Try
		End Sub

		'******************************************************************

#End Region

   
 
        Private Sub cboBoxRec_BoxType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBoxRec_BoxType.TextChanged

        End Sub

        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        End Sub

    End Class
End Namespace
