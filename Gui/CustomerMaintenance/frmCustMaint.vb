Imports PSS.Core.[Global]

Namespace Gui.CustomerMaint

    Public Class frmCustMaint
        Inherits System.Windows.Forms.Form



        Private cvalCustomer As Int32
        Private cvalProduct As Int32
        Private CustomerSelect As Int32
        Private ParentCoSelect As Int32
        Private CustomerSelectText, ParentCoSelectText As String
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
        Friend WithEvents lblSelectCustomer As System.Windows.Forms.Label
        Friend WithEvents cboSelectCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents btnNEW As System.Windows.Forms.Button
        Friend WithEvents grpSection As System.Windows.Forms.GroupBox
        Friend WithEvents lblParentCo As System.Windows.Forms.Label
        Friend WithEvents lblParentCoStatus As System.Windows.Forms.Label
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblCustomerStatus As System.Windows.Forms.Label
        Friend WithEvents lblMarkup As System.Windows.Forms.Label
        Friend WithEvents lblMarkupStatus As System.Windows.Forms.Label
        Friend WithEvents lblWarranty As System.Windows.Forms.Label
        Friend WithEvents lblWarrantyStatus As System.Windows.Forms.Label
        Friend WithEvents lblCC As System.Windows.Forms.Label
        Friend WithEvents lblCCStatus As System.Windows.Forms.Label
        Friend WithEvents lblCustPrice As System.Windows.Forms.Label
        Friend WithEvents lblCustPriceStatus As System.Windows.Forms.Label
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents ctrlTab As System.Windows.Forms.TabControl
        Friend WithEvents Label55 As System.Windows.Forms.Label
        Friend WithEvents CP_cboPricingGroup As System.Windows.Forms.ComboBox
        Friend WithEvents CP_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents Label54 As System.Windows.Forms.Label
        Friend WithEvents CC_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents CC_txtExpDate As System.Windows.Forms.TextBox
        Friend WithEvents CC_txtCCNumber As System.Windows.Forms.TextBox
        Friend WithEvents CC_cboCCType As System.Windows.Forms.ComboBox
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents CC_txtName As System.Windows.Forms.TextBox
        Friend WithEvents CM_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents CM_txtName As System.Windows.Forms.TextBox
        Friend WithEvents btnCustomerMarkup_Save As System.Windows.Forms.Button
        Friend WithEvents btnCustomerMarkup_Cancel As System.Windows.Forms.Button
        Friend WithEvents btnCustomerMarkup_NEW As System.Windows.Forms.Button
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents CM_cboInvMthdID As System.Windows.Forms.ComboBox
        Friend WithEvents CM_txtCustomer As System.Windows.Forms.TextBox
        Friend WithEvents CM_txtNER As System.Windows.Forms.TextBox
        Friend WithEvents CM_txtRUR As System.Windows.Forms.TextBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents CM_cboProduct As System.Windows.Forms.ComboBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents LOC_ListBox As System.Windows.Forms.ListBox
        Friend WithEvents LOC_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents LOC_txtShippingMemo As System.Windows.Forms.TextBox
        Friend WithEvents LOC_txtMemo As System.Windows.Forms.TextBox
        Friend WithEvents LOC_cboManifestDetail As System.Windows.Forms.ComboBox
        Friend WithEvents LOC_cboAfterMarket As System.Windows.Forms.ComboBox
        Friend WithEvents LOC_cboCountry As System.Windows.Forms.ComboBox
        Friend WithEvents LOC_cboState As System.Windows.Forms.ComboBox
        Friend WithEvents LOC_txtEmail As System.Windows.Forms.TextBox
        Friend WithEvents LOC_txtFax As System.Windows.Forms.TextBox
        Friend WithEvents LOC_txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents LOC_txtContact As System.Windows.Forms.TextBox
        Friend WithEvents LOC_txtZip As System.Windows.Forms.TextBox
        Friend WithEvents LOC_txtCity As System.Windows.Forms.TextBox
        Friend WithEvents LOC_txtAddress2 As System.Windows.Forms.TextBox
        Friend WithEvents LOC_txtAddress1 As System.Windows.Forms.TextBox
        Friend WithEvents LOC_txtName As System.Windows.Forms.TextBox
        Friend WithEvents Label53 As System.Windows.Forms.Label
        Friend WithEvents Label52 As System.Windows.Forms.Label
        Friend WithEvents Label51 As System.Windows.Forms.Label
        Friend WithEvents Label50 As System.Windows.Forms.Label
        Friend WithEvents Label49 As System.Windows.Forms.Label
        Friend WithEvents Label48 As System.Windows.Forms.Label
        Friend WithEvents Label47 As System.Windows.Forms.Label
        Friend WithEvents Label46 As System.Windows.Forms.Label
        Friend WithEvents Label45 As System.Windows.Forms.Label
        Friend WithEvents Label44 As System.Windows.Forms.Label
        Friend WithEvents Label43 As System.Windows.Forms.Label
        Friend WithEvents Label42 As System.Windows.Forms.Label
        Friend WithEvents Label41 As System.Windows.Forms.Label
        Friend WithEvents Label40 As System.Windows.Forms.Label
        Friend WithEvents Label39 As System.Windows.Forms.Label
        Friend WithEvents Label38 As System.Windows.Forms.Label
        Friend WithEvents btnCustomer_NEW As System.Windows.Forms.Button
        Friend WithEvents CUST_cboName As System.Windows.Forms.ComboBox
        Friend WithEvents btnCustomer_Save As System.Windows.Forms.Button
        Friend WithEvents btnCustomer_Cancel As System.Windows.Forms.Button
        Friend WithEvents CUST_cboSalesPerson As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_cboParentCo As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_cboPayID As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_cboCollSalesTax As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_cboCrAppShip As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_cboCrAppRec As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_cboRepLCD As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_cboRepNonWrty As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_txtRejectTimes As System.Windows.Forms.TextBox
        Friend WithEvents CUST_txtRejectDays As System.Windows.Forms.TextBox
        Friend WithEvents CUST_cboPlusParts As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_txtLName As System.Windows.Forms.TextBox
        Friend WithEvents CUST_txtFName As System.Windows.Forms.TextBox
        Friend WithEvents Label37 As System.Windows.Forms.Label
        Friend WithEvents Label36 As System.Windows.Forms.Label
        Friend WithEvents Label35 As System.Windows.Forms.Label
        Friend WithEvents Label34 As System.Windows.Forms.Label
        Friend WithEvents Label33 As System.Windows.Forms.Label
        Friend WithEvents Label32 As System.Windows.Forms.Label
        Friend WithEvents Label31 As System.Windows.Forms.Label
        Friend WithEvents Label30 As System.Windows.Forms.Label
        Friend WithEvents Label29 As System.Windows.Forms.Label
        Friend WithEvents Label28 As System.Windows.Forms.Label
        Friend WithEvents Label27 As System.Windows.Forms.Label
        Friend WithEvents Label26 As System.Windows.Forms.Label
        Friend WithEvents Label25 As System.Windows.Forms.Label
        Friend WithEvents btnParentCo_UPDATE As System.Windows.Forms.Button
        Friend WithEvents btnParentCo_CANCEL As System.Windows.Forms.Button
        Friend WithEvents btnParentCo_SAVE As System.Windows.Forms.Button
        Friend WithEvents btnParentCo_NEW As System.Windows.Forms.Button
        Friend WithEvents PC_txtMotoCode As System.Windows.Forms.TextBox
        Friend WithEvents PC_cboPrcGroup As System.Windows.Forms.ComboBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents PC_cboWrtyLabor As System.Windows.Forms.ComboBox
        Friend WithEvents PC_cboWrtyParts As System.Windows.Forms.ComboBox
        Friend WithEvents PC_txtWrtyDays As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents PC_txtNER As System.Windows.Forms.TextBox
        Friend WithEvents PC_txtRUR As System.Windows.Forms.TextBox
        Friend WithEvents PC_txtMarkUp As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents PC_cboName As System.Windows.Forms.ComboBox
        Friend WithEvents lblPCname As System.Windows.Forms.Label
        Friend WithEvents PC_txtName As System.Windows.Forms.TextBox
        Friend WithEvents btnCustWrty_SAVE As System.Windows.Forms.Button
        Friend WithEvents btnCustWrty_CANCEL As System.Windows.Forms.Button
        Friend WithEvents btnCustWrty_NEW As System.Windows.Forms.Button
        Friend WithEvents CW_cboProduct As System.Windows.Forms.ComboBox
        Friend WithEvents CW_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents CW_cboWrtyLabor As System.Windows.Forms.ComboBox
        Friend WithEvents CW_cboWrtyParts As System.Windows.Forms.ComboBox
        Friend WithEvents CW_txtDaysInWrty As System.Windows.Forms.TextBox
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents btnCreditCard_NEW As System.Windows.Forms.Button
        Friend WithEvents btnCreditCard_UPDATE As System.Windows.Forms.Button
        Friend WithEvents btnCreditCard_SAVE As System.Windows.Forms.Button
        Friend WithEvents btnCreditCard_CANCEL As System.Windows.Forms.Button
        Friend WithEvents lblLocationStatus As System.Windows.Forms.Label
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents btnCustomer_UPDATE As System.Windows.Forms.Button
        Friend WithEvents btnCustomerMarkup_UPDATE As System.Windows.Forms.Button
        Friend WithEvents btnCustWrty_UPDATE As System.Windows.Forms.Button
        Friend WithEvents CP_cboProduct As System.Windows.Forms.ComboBox
        Friend WithEvents Label56 As System.Windows.Forms.Label
        Friend WithEvents btnPricingGroup As System.Windows.Forms.Button
        Friend WithEvents CM_txtMarkupInvt As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblHighlight As System.Windows.Forms.Label
        Friend WithEvents Label57 As System.Windows.Forms.Label
        Friend WithEvents Label58 As System.Windows.Forms.Label
        Friend WithEvents Label59 As System.Windows.Forms.Label
        Friend WithEvents Label60 As System.Windows.Forms.Label
        Friend WithEvents Label61 As System.Windows.Forms.Label
        Friend WithEvents btnCustPrice_UPDATE As System.Windows.Forms.Button
        Friend WithEvents btnCustPrice_SAVE As System.Windows.Forms.Button
        Friend WithEvents btnCustPrice_CANCEL As System.Windows.Forms.Button
        Friend WithEvents btnCustPrice_NEW As System.Windows.Forms.Button
        Friend WithEvents tbParent As System.Windows.Forms.TabPage
        Friend WithEvents tbCustWrty As System.Windows.Forms.TabPage
        Friend WithEvents tbCreditCard As System.Windows.Forms.TabPage
        Friend WithEvents tbLocation As System.Windows.Forms.TabPage
        Friend WithEvents tbCustMarkup As System.Windows.Forms.TabPage
        Friend WithEvents tbCustomer As System.Windows.Forms.TabPage
        Friend WithEvents tbCust2Price As System.Windows.Forms.TabPage
        Friend WithEvents Label62 As System.Windows.Forms.Label
        Friend WithEvents btnLocation_Update As System.Windows.Forms.Button
        Friend WithEvents btnLocation_Save As System.Windows.Forms.Button
        Friend WithEvents btnLocation_Cancel As System.Windows.Forms.Button
        Friend WithEvents btnLocation_New As System.Windows.Forms.Button
        Friend WithEvents LOC_txtCustomer As System.Windows.Forms.TextBox
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents tbSearch As System.Windows.Forms.TabPage
        Friend WithEvents searchGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnPrcGroup As System.Windows.Forms.Button
        Friend WithEvents tdbGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdbGridExcpt As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblException As System.Windows.Forms.Label
        Friend WithEvents chkEndUser As System.Windows.Forms.CheckBox
        Friend WithEvents btnChangeName As System.Windows.Forms.Button
        Friend WithEvents btnChangeParent As System.Windows.Forms.Button
        Friend WithEvents CUST_cboInvoiceDetail As System.Windows.Forms.ComboBox
        Friend WithEvents Label63 As System.Windows.Forms.Label
        Friend WithEvents CC_txtAuthCode As System.Windows.Forms.TextBox
        Friend WithEvents lblAuthCode As System.Windows.Forms.Label
        Friend WithEvents PC_valPrcGroup As System.Windows.Forms.TextBox
        Friend WithEvents PC_valWrtyParts As System.Windows.Forms.TextBox
        Friend WithEvents PC_valWrtyLabor As System.Windows.Forms.TextBox
        Friend WithEvents PC_valEndUser As System.Windows.Forms.TextBox
        Friend WithEvents PC_valPCOID As System.Windows.Forms.TextBox
        Friend WithEvents CUST_valCustID As System.Windows.Forms.TextBox
        Friend WithEvents lblCMplusParts As System.Windows.Forms.Label
        Friend WithEvents CM_cboplusparts As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_chkINACTIVE As System.Windows.Forms.CheckBox
        Friend WithEvents CUST_txtMemo As System.Windows.Forms.TextBox
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents Label64 As System.Windows.Forms.Label
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents Label65 As System.Windows.Forms.Label
        Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
        Friend WithEvents Label66 As System.Windows.Forms.Label
        Friend WithEvents cboCustomerPreLoad As System.Windows.Forms.ComboBox
        Friend WithEvents btnPLSave As System.Windows.Forms.Button
        Friend WithEvents chkPLCarrier As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLWarranty As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLPRL As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLIP As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLDockDate As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLquantity As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLShipTo As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLSKU As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLRAQuantity As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLIncIMEI As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLCourierTrackIN As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLTransaction As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLDateCode As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLReturn As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLAPC As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLMIN As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLComplaint As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLAirTimeCarrier As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLCarrierModel As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLTransceiver As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLProduct As System.Windows.Forms.CheckBox
        Friend WithEvents chkPLPOP As System.Windows.Forms.CheckBox
        Friend WithEvents btnOptions As System.Windows.Forms.Button
        Friend WithEvents chkUPC As System.Windows.Forms.CheckBox
        Friend WithEvents chkPO As System.Windows.Forms.CheckBox
        Friend WithEvents CM_txtNTF As System.Windows.Forms.TextBox
        Friend WithEvents Label67 As System.Windows.Forms.Label
        Friend WithEvents chkPLDefaultSku As System.Windows.Forms.CheckBox
        Friend WithEvents chkAggBill As System.Windows.Forms.CheckBox
        Friend WithEvents tbAggBilling As System.Windows.Forms.TabPage
        Friend WithEvents grpAggregates As System.Windows.Forms.GroupBox
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        Friend WithEvents btnInsert As System.Windows.Forms.Button
        Friend WithEvents txtAmount As System.Windows.Forms.TextBox
        Friend WithEvents txtBillCode As System.Windows.Forms.TextBox
        Friend WithEvents Label70 As System.Windows.Forms.Label
        Friend WithEvents Label69 As System.Windows.Forms.Label
        Friend WithEvents gridAggregate As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label68 As System.Windows.Forms.Label
        Friend WithEvents lstAggCodes As System.Windows.Forms.ListBox
        Friend WithEvents CM_txtRTM As System.Windows.Forms.TextBox
        Friend WithEvents Label71 As System.Windows.Forms.Label
        Friend WithEvents tpgUpdLabor As System.Windows.Forms.TabPage
        Friend WithEvents Label72 As System.Windows.Forms.Label
        Friend WithEvents Label73 As System.Windows.Forms.Label
        Friend WithEvents btnUpdateLabor As System.Windows.Forms.Button
        Friend WithEvents pnlUpdateLabor As System.Windows.Forms.Panel
        Friend WithEvents chkInWip As System.Windows.Forms.CheckBox
        Friend WithEvents cboULModels As C1.Win.C1List.C1Combo
        Friend WithEvents cboULCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label74 As System.Windows.Forms.Label
        Friend WithEvents Label75 As System.Windows.Forms.Label
        Friend WithEvents pnlULShipDate As System.Windows.Forms.Panel
        Friend WithEvents dtpULShipEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents chkULProdShipDate As System.Windows.Forms.CheckBox
        Friend WithEvents dtULShipStartDate As System.Windows.Forms.DateTimePicker
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCustMaint))
            Me.lblSelectCustomer = New System.Windows.Forms.Label()
            Me.cboSelectCustomer = New System.Windows.Forms.ComboBox()
            Me.btnNEW = New System.Windows.Forms.Button()
            Me.grpSection = New System.Windows.Forms.GroupBox()
            Me.lblLocationStatus = New System.Windows.Forms.Label()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.lblCustPriceStatus = New System.Windows.Forms.Label()
            Me.lblCustPrice = New System.Windows.Forms.Label()
            Me.lblCCStatus = New System.Windows.Forms.Label()
            Me.lblCC = New System.Windows.Forms.Label()
            Me.lblWarrantyStatus = New System.Windows.Forms.Label()
            Me.lblWarranty = New System.Windows.Forms.Label()
            Me.lblMarkupStatus = New System.Windows.Forms.Label()
            Me.lblMarkup = New System.Windows.Forms.Label()
            Me.lblCustomerStatus = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.lblParentCoStatus = New System.Windows.Forms.Label()
            Me.lblParentCo = New System.Windows.Forms.Label()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.ctrlTab = New System.Windows.Forms.TabControl()
            Me.tbParent = New System.Windows.Forms.TabPage()
            Me.PC_valPCOID = New System.Windows.Forms.TextBox()
            Me.PC_valEndUser = New System.Windows.Forms.TextBox()
            Me.PC_valPrcGroup = New System.Windows.Forms.TextBox()
            Me.btnChangeParent = New System.Windows.Forms.Button()
            Me.chkEndUser = New System.Windows.Forms.CheckBox()
            Me.btnParentCo_UPDATE = New System.Windows.Forms.Button()
            Me.btnParentCo_CANCEL = New System.Windows.Forms.Button()
            Me.btnParentCo_SAVE = New System.Windows.Forms.Button()
            Me.btnParentCo_NEW = New System.Windows.Forms.Button()
            Me.PC_txtMotoCode = New System.Windows.Forms.TextBox()
            Me.PC_cboPrcGroup = New System.Windows.Forms.ComboBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.PC_valWrtyLabor = New System.Windows.Forms.TextBox()
            Me.PC_cboWrtyLabor = New System.Windows.Forms.ComboBox()
            Me.PC_cboWrtyParts = New System.Windows.Forms.ComboBox()
            Me.PC_txtWrtyDays = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.PC_valWrtyParts = New System.Windows.Forms.TextBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.PC_txtNER = New System.Windows.Forms.TextBox()
            Me.PC_txtRUR = New System.Windows.Forms.TextBox()
            Me.PC_txtMarkUp = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PC_cboName = New System.Windows.Forms.ComboBox()
            Me.lblPCname = New System.Windows.Forms.Label()
            Me.PC_txtName = New System.Windows.Forms.TextBox()
            Me.lblHighlight = New System.Windows.Forms.Label()
            Me.tpgUpdLabor = New System.Windows.Forms.TabPage()
            Me.pnlUpdateLabor = New System.Windows.Forms.Panel()
            Me.pnlULShipDate = New System.Windows.Forms.Panel()
            Me.dtpULShipEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtULShipStartDate = New System.Windows.Forms.DateTimePicker()
            Me.Label75 = New System.Windows.Forms.Label()
            Me.Label74 = New System.Windows.Forms.Label()
            Me.chkULProdShipDate = New System.Windows.Forms.CheckBox()
            Me.btnUpdateLabor = New System.Windows.Forms.Button()
            Me.chkInWip = New System.Windows.Forms.CheckBox()
            Me.cboULModels = New C1.Win.C1List.C1Combo()
            Me.Label72 = New System.Windows.Forms.Label()
            Me.cboULCustomers = New C1.Win.C1List.C1Combo()
            Me.Label73 = New System.Windows.Forms.Label()
            Me.tbCustMarkup = New System.Windows.Forms.TabPage()
            Me.btnCustomerMarkup_UPDATE = New System.Windows.Forms.Button()
            Me.CM_cboCustomer = New System.Windows.Forms.ComboBox()
            Me.CM_txtName = New System.Windows.Forms.TextBox()
            Me.btnCustomerMarkup_Save = New System.Windows.Forms.Button()
            Me.btnCustomerMarkup_Cancel = New System.Windows.Forms.Button()
            Me.btnCustomerMarkup_NEW = New System.Windows.Forms.Button()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.CM_txtRTM = New System.Windows.Forms.TextBox()
            Me.Label71 = New System.Windows.Forms.Label()
            Me.CM_txtNTF = New System.Windows.Forms.TextBox()
            Me.Label67 = New System.Windows.Forms.Label()
            Me.CM_cboplusparts = New System.Windows.Forms.ComboBox()
            Me.lblCMplusParts = New System.Windows.Forms.Label()
            Me.CM_txtMarkupInvt = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.CM_cboInvMthdID = New System.Windows.Forms.ComboBox()
            Me.CM_txtCustomer = New System.Windows.Forms.TextBox()
            Me.CM_txtNER = New System.Windows.Forms.TextBox()
            Me.CM_txtRUR = New System.Windows.Forms.TextBox()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.CM_cboProduct = New System.Windows.Forms.ComboBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label58 = New System.Windows.Forms.Label()
            Me.tbCustWrty = New System.Windows.Forms.TabPage()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.btnCustWrty_UPDATE = New System.Windows.Forms.Button()
            Me.btnCustWrty_SAVE = New System.Windows.Forms.Button()
            Me.btnCustWrty_CANCEL = New System.Windows.Forms.Button()
            Me.btnCustWrty_NEW = New System.Windows.Forms.Button()
            Me.CW_cboProduct = New System.Windows.Forms.ComboBox()
            Me.CW_cboCustomer = New System.Windows.Forms.ComboBox()
            Me.CW_cboWrtyLabor = New System.Windows.Forms.ComboBox()
            Me.CW_cboWrtyParts = New System.Windows.Forms.ComboBox()
            Me.CW_txtDaysInWrty = New System.Windows.Forms.TextBox()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label60 = New System.Windows.Forms.Label()
            Me.tbAggBilling = New System.Windows.Forms.TabPage()
            Me.grpAggregates = New System.Windows.Forms.GroupBox()
            Me.btnRemove = New System.Windows.Forms.Button()
            Me.btnInsert = New System.Windows.Forms.Button()
            Me.txtAmount = New System.Windows.Forms.TextBox()
            Me.txtBillCode = New System.Windows.Forms.TextBox()
            Me.Label70 = New System.Windows.Forms.Label()
            Me.Label69 = New System.Windows.Forms.Label()
            Me.gridAggregate = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label68 = New System.Windows.Forms.Label()
            Me.lstAggCodes = New System.Windows.Forms.ListBox()
            Me.tbCreditCard = New System.Windows.Forms.TabPage()
            Me.CC_txtAuthCode = New System.Windows.Forms.TextBox()
            Me.lblAuthCode = New System.Windows.Forms.Label()
            Me.btnCreditCard_UPDATE = New System.Windows.Forms.Button()
            Me.btnCreditCard_SAVE = New System.Windows.Forms.Button()
            Me.btnCreditCard_CANCEL = New System.Windows.Forms.Button()
            Me.btnCreditCard_NEW = New System.Windows.Forms.Button()
            Me.CC_cboCustomer = New System.Windows.Forms.ComboBox()
            Me.CC_txtExpDate = New System.Windows.Forms.TextBox()
            Me.CC_txtCCNumber = New System.Windows.Forms.TextBox()
            Me.CC_cboCCType = New System.Windows.Forms.ComboBox()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.CC_txtName = New System.Windows.Forms.TextBox()
            Me.Label59 = New System.Windows.Forms.Label()
            Me.tbCustomer = New System.Windows.Forms.TabPage()
            Me.chkAggBill = New System.Windows.Forms.CheckBox()
            Me.CUST_txtMemo = New System.Windows.Forms.TextBox()
            Me.CUST_chkINACTIVE = New System.Windows.Forms.CheckBox()
            Me.CUST_valCustID = New System.Windows.Forms.TextBox()
            Me.CUST_cboInvoiceDetail = New System.Windows.Forms.ComboBox()
            Me.Label63 = New System.Windows.Forms.Label()
            Me.btnChangeName = New System.Windows.Forms.Button()
            Me.btnCustomer_UPDATE = New System.Windows.Forms.Button()
            Me.btnCustomer_NEW = New System.Windows.Forms.Button()
            Me.CUST_cboName = New System.Windows.Forms.ComboBox()
            Me.btnCustomer_Save = New System.Windows.Forms.Button()
            Me.btnCustomer_Cancel = New System.Windows.Forms.Button()
            Me.CUST_cboSalesPerson = New System.Windows.Forms.ComboBox()
            Me.CUST_cboParentCo = New System.Windows.Forms.ComboBox()
            Me.CUST_cboPayID = New System.Windows.Forms.ComboBox()
            Me.CUST_cboCollSalesTax = New System.Windows.Forms.ComboBox()
            Me.CUST_cboCrAppShip = New System.Windows.Forms.ComboBox()
            Me.CUST_cboCrAppRec = New System.Windows.Forms.ComboBox()
            Me.CUST_cboRepLCD = New System.Windows.Forms.ComboBox()
            Me.CUST_cboRepNonWrty = New System.Windows.Forms.ComboBox()
            Me.CUST_txtRejectTimes = New System.Windows.Forms.TextBox()
            Me.CUST_txtRejectDays = New System.Windows.Forms.TextBox()
            Me.CUST_cboPlusParts = New System.Windows.Forms.ComboBox()
            Me.CUST_txtLName = New System.Windows.Forms.TextBox()
            Me.CUST_txtFName = New System.Windows.Forms.TextBox()
            Me.Label37 = New System.Windows.Forms.Label()
            Me.Label36 = New System.Windows.Forms.Label()
            Me.Label35 = New System.Windows.Forms.Label()
            Me.Label34 = New System.Windows.Forms.Label()
            Me.Label33 = New System.Windows.Forms.Label()
            Me.Label32 = New System.Windows.Forms.Label()
            Me.Label31 = New System.Windows.Forms.Label()
            Me.Label30 = New System.Windows.Forms.Label()
            Me.Label29 = New System.Windows.Forms.Label()
            Me.Label28 = New System.Windows.Forms.Label()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.Label25 = New System.Windows.Forms.Label()
            Me.Label57 = New System.Windows.Forms.Label()
            Me.tbSearch = New System.Windows.Forms.TabPage()
            Me.searchGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tbLocation = New System.Windows.Forms.TabPage()
            Me.btnOptions = New System.Windows.Forms.Button()
            Me.btnLocation_Update = New System.Windows.Forms.Button()
            Me.btnLocation_Save = New System.Windows.Forms.Button()
            Me.btnLocation_Cancel = New System.Windows.Forms.Button()
            Me.btnLocation_New = New System.Windows.Forms.Button()
            Me.LOC_ListBox = New System.Windows.Forms.ListBox()
            Me.LOC_cboCustomer = New System.Windows.Forms.ComboBox()
            Me.LOC_txtShippingMemo = New System.Windows.Forms.TextBox()
            Me.LOC_txtMemo = New System.Windows.Forms.TextBox()
            Me.LOC_cboManifestDetail = New System.Windows.Forms.ComboBox()
            Me.LOC_cboAfterMarket = New System.Windows.Forms.ComboBox()
            Me.LOC_cboCountry = New System.Windows.Forms.ComboBox()
            Me.LOC_cboState = New System.Windows.Forms.ComboBox()
            Me.LOC_txtEmail = New System.Windows.Forms.TextBox()
            Me.LOC_txtFax = New System.Windows.Forms.TextBox()
            Me.LOC_txtPhone = New System.Windows.Forms.TextBox()
            Me.LOC_txtContact = New System.Windows.Forms.TextBox()
            Me.LOC_txtZip = New System.Windows.Forms.TextBox()
            Me.LOC_txtCity = New System.Windows.Forms.TextBox()
            Me.LOC_txtAddress2 = New System.Windows.Forms.TextBox()
            Me.LOC_txtAddress1 = New System.Windows.Forms.TextBox()
            Me.LOC_txtName = New System.Windows.Forms.TextBox()
            Me.Label53 = New System.Windows.Forms.Label()
            Me.Label52 = New System.Windows.Forms.Label()
            Me.Label51 = New System.Windows.Forms.Label()
            Me.Label50 = New System.Windows.Forms.Label()
            Me.Label49 = New System.Windows.Forms.Label()
            Me.Label48 = New System.Windows.Forms.Label()
            Me.Label47 = New System.Windows.Forms.Label()
            Me.Label46 = New System.Windows.Forms.Label()
            Me.Label45 = New System.Windows.Forms.Label()
            Me.Label44 = New System.Windows.Forms.Label()
            Me.Label43 = New System.Windows.Forms.Label()
            Me.Label42 = New System.Windows.Forms.Label()
            Me.Label41 = New System.Windows.Forms.Label()
            Me.Label40 = New System.Windows.Forms.Label()
            Me.Label39 = New System.Windows.Forms.Label()
            Me.Label38 = New System.Windows.Forms.Label()
            Me.LOC_txtCustomer = New System.Windows.Forms.TextBox()
            Me.Label62 = New System.Windows.Forms.Label()
            Me.tbCust2Price = New System.Windows.Forms.TabPage()
            Me.lblException = New System.Windows.Forms.Label()
            Me.tdbGridExcpt = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdbGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnPrcGroup = New System.Windows.Forms.Button()
            Me.btnPricingGroup = New System.Windows.Forms.Button()
            Me.CP_cboProduct = New System.Windows.Forms.ComboBox()
            Me.Label56 = New System.Windows.Forms.Label()
            Me.btnCustPrice_UPDATE = New System.Windows.Forms.Button()
            Me.btnCustPrice_SAVE = New System.Windows.Forms.Button()
            Me.btnCustPrice_CANCEL = New System.Windows.Forms.Button()
            Me.btnCustPrice_NEW = New System.Windows.Forms.Button()
            Me.Label55 = New System.Windows.Forms.Label()
            Me.CP_cboPricingGroup = New System.Windows.Forms.ComboBox()
            Me.CP_cboCustomer = New System.Windows.Forms.ComboBox()
            Me.Label54 = New System.Windows.Forms.Label()
            Me.Label61 = New System.Windows.Forms.Label()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.btnPLSave = New System.Windows.Forms.Button()
            Me.cboCustomerPreLoad = New System.Windows.Forms.ComboBox()
            Me.Label64 = New System.Windows.Forms.Label()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.chkPLDefaultSku = New System.Windows.Forms.CheckBox()
            Me.chkPO = New System.Windows.Forms.CheckBox()
            Me.chkUPC = New System.Windows.Forms.CheckBox()
            Me.chkPLCarrier = New System.Windows.Forms.CheckBox()
            Me.chkPLWarranty = New System.Windows.Forms.CheckBox()
            Me.chkPLPRL = New System.Windows.Forms.CheckBox()
            Me.chkPLIP = New System.Windows.Forms.CheckBox()
            Me.chkPLDockDate = New System.Windows.Forms.CheckBox()
            Me.chkPLquantity = New System.Windows.Forms.CheckBox()
            Me.chkPLShipTo = New System.Windows.Forms.CheckBox()
            Me.Label65 = New System.Windows.Forms.Label()
            Me.chkPLSKU = New System.Windows.Forms.CheckBox()
            Me.chkPLRAQuantity = New System.Windows.Forms.CheckBox()
            Me.GroupBox5 = New System.Windows.Forms.GroupBox()
            Me.chkPLIncIMEI = New System.Windows.Forms.CheckBox()
            Me.chkPLCourierTrackIN = New System.Windows.Forms.CheckBox()
            Me.Label66 = New System.Windows.Forms.Label()
            Me.chkPLTransaction = New System.Windows.Forms.CheckBox()
            Me.chkPLDateCode = New System.Windows.Forms.CheckBox()
            Me.chkPLReturn = New System.Windows.Forms.CheckBox()
            Me.chkPLAPC = New System.Windows.Forms.CheckBox()
            Me.chkPLMIN = New System.Windows.Forms.CheckBox()
            Me.chkPLComplaint = New System.Windows.Forms.CheckBox()
            Me.chkPLAirTimeCarrier = New System.Windows.Forms.CheckBox()
            Me.chkPLCarrierModel = New System.Windows.Forms.CheckBox()
            Me.chkPLTransceiver = New System.Windows.Forms.CheckBox()
            Me.chkPLProduct = New System.Windows.Forms.CheckBox()
            Me.chkPLPOP = New System.Windows.Forms.CheckBox()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.grpSection.SuspendLayout()
            Me.ctrlTab.SuspendLayout()
            Me.tbParent.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.tpgUpdLabor.SuspendLayout()
            Me.pnlUpdateLabor.SuspendLayout()
            Me.pnlULShipDate.SuspendLayout()
            CType(Me.cboULModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboULCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbCustMarkup.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.tbCustWrty.SuspendLayout()
            Me.tbAggBilling.SuspendLayout()
            Me.grpAggregates.SuspendLayout()
            CType(Me.gridAggregate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbCreditCard.SuspendLayout()
            Me.tbCustomer.SuspendLayout()
            Me.tbSearch.SuspendLayout()
            CType(Me.searchGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbLocation.SuspendLayout()
            Me.tbCust2Price.SuspendLayout()
            CType(Me.tdbGridExcpt, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage1.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox5.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblSelectCustomer
            '
            Me.lblSelectCustomer.Location = New System.Drawing.Point(16, 16)
            Me.lblSelectCustomer.Name = "lblSelectCustomer"
            Me.lblSelectCustomer.Size = New System.Drawing.Size(96, 21)
            Me.lblSelectCustomer.TabIndex = 0
            Me.lblSelectCustomer.Text = "Select Customer:"
            Me.lblSelectCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboSelectCustomer
            '
            Me.cboSelectCustomer.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.cboSelectCustomer.Location = New System.Drawing.Point(112, 16)
            Me.cboSelectCustomer.Name = "cboSelectCustomer"
            Me.cboSelectCustomer.Size = New System.Drawing.Size(480, 21)
            Me.cboSelectCustomer.TabIndex = 0
            Me.cboSelectCustomer.TabStop = False
            '
            'btnNEW
            '
            Me.btnNEW.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnNEW.Location = New System.Drawing.Point(696, 16)
            Me.btnNEW.Name = "btnNEW"
            Me.btnNEW.Size = New System.Drawing.Size(96, 24)
            Me.btnNEW.TabIndex = 2
            Me.btnNEW.TabStop = False
            Me.btnNEW.Text = "&NEW"
            '
            'grpSection
            '
            Me.grpSection.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.grpSection.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLocationStatus, Me.lblLocation, Me.lblCustPriceStatus, Me.lblCustPrice, Me.lblCCStatus, Me.lblCC, Me.lblWarrantyStatus, Me.lblWarranty, Me.lblMarkupStatus, Me.lblMarkup, Me.lblCustomerStatus, Me.lblCustomer, Me.lblParentCoStatus, Me.lblParentCo})
            Me.grpSection.Location = New System.Drawing.Point(720, 64)
            Me.grpSection.Name = "grpSection"
            Me.grpSection.Size = New System.Drawing.Size(104, 304)
            Me.grpSection.TabIndex = 11
            Me.grpSection.TabStop = False
            Me.grpSection.Text = "Section Status"
            '
            'lblLocationStatus
            '
            Me.lblLocationStatus.BackColor = System.Drawing.Color.LightYellow
            Me.lblLocationStatus.Location = New System.Drawing.Point(8, 112)
            Me.lblLocationStatus.Name = "lblLocationStatus"
            Me.lblLocationStatus.Size = New System.Drawing.Size(88, 16)
            Me.lblLocationStatus.TabIndex = 26
            Me.lblLocationStatus.Text = "Not Defined"
            Me.lblLocationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.SteelBlue
            Me.lblLocation.ForeColor = System.Drawing.Color.White
            Me.lblLocation.Location = New System.Drawing.Point(8, 96)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(88, 16)
            Me.lblLocation.TabIndex = 25
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCustPriceStatus
            '
            Me.lblCustPriceStatus.BackColor = System.Drawing.Color.LightYellow
            Me.lblCustPriceStatus.Location = New System.Drawing.Point(8, 208)
            Me.lblCustPriceStatus.Name = "lblCustPriceStatus"
            Me.lblCustPriceStatus.Size = New System.Drawing.Size(88, 16)
            Me.lblCustPriceStatus.TabIndex = 24
            Me.lblCustPriceStatus.Text = "Not Defined"
            Me.lblCustPriceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCustPrice
            '
            Me.lblCustPrice.BackColor = System.Drawing.Color.SteelBlue
            Me.lblCustPrice.ForeColor = System.Drawing.Color.White
            Me.lblCustPrice.Location = New System.Drawing.Point(8, 192)
            Me.lblCustPrice.Name = "lblCustPrice"
            Me.lblCustPrice.Size = New System.Drawing.Size(88, 16)
            Me.lblCustPrice.TabIndex = 23
            Me.lblCustPrice.Text = "Cust to Price:"
            Me.lblCustPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCCStatus
            '
            Me.lblCCStatus.BackColor = System.Drawing.Color.LightYellow
            Me.lblCCStatus.Location = New System.Drawing.Point(8, 240)
            Me.lblCCStatus.Name = "lblCCStatus"
            Me.lblCCStatus.Size = New System.Drawing.Size(88, 16)
            Me.lblCCStatus.TabIndex = 22
            Me.lblCCStatus.Text = "Not Defined"
            Me.lblCCStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCC
            '
            Me.lblCC.BackColor = System.Drawing.Color.SteelBlue
            Me.lblCC.ForeColor = System.Drawing.Color.White
            Me.lblCC.Location = New System.Drawing.Point(8, 224)
            Me.lblCC.Name = "lblCC"
            Me.lblCC.Size = New System.Drawing.Size(88, 16)
            Me.lblCC.TabIndex = 21
            Me.lblCC.Text = "Credit Card:"
            Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblWarrantyStatus
            '
            Me.lblWarrantyStatus.BackColor = System.Drawing.Color.LightYellow
            Me.lblWarrantyStatus.Location = New System.Drawing.Point(8, 144)
            Me.lblWarrantyStatus.Name = "lblWarrantyStatus"
            Me.lblWarrantyStatus.Size = New System.Drawing.Size(88, 16)
            Me.lblWarrantyStatus.TabIndex = 20
            Me.lblWarrantyStatus.Text = "Not Defined"
            Me.lblWarrantyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWarranty
            '
            Me.lblWarranty.BackColor = System.Drawing.Color.SteelBlue
            Me.lblWarranty.ForeColor = System.Drawing.Color.White
            Me.lblWarranty.Location = New System.Drawing.Point(8, 128)
            Me.lblWarranty.Name = "lblWarranty"
            Me.lblWarranty.Size = New System.Drawing.Size(88, 16)
            Me.lblWarranty.TabIndex = 19
            Me.lblWarranty.Text = "Warranty:"
            Me.lblWarranty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblMarkupStatus
            '
            Me.lblMarkupStatus.BackColor = System.Drawing.Color.LightYellow
            Me.lblMarkupStatus.Location = New System.Drawing.Point(8, 176)
            Me.lblMarkupStatus.Name = "lblMarkupStatus"
            Me.lblMarkupStatus.Size = New System.Drawing.Size(88, 16)
            Me.lblMarkupStatus.TabIndex = 18
            Me.lblMarkupStatus.Text = "Not Defined"
            Me.lblMarkupStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMarkup
            '
            Me.lblMarkup.BackColor = System.Drawing.Color.SteelBlue
            Me.lblMarkup.ForeColor = System.Drawing.Color.White
            Me.lblMarkup.Location = New System.Drawing.Point(8, 160)
            Me.lblMarkup.Name = "lblMarkup"
            Me.lblMarkup.Size = New System.Drawing.Size(88, 16)
            Me.lblMarkup.TabIndex = 17
            Me.lblMarkup.Text = "Markup:"
            Me.lblMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCustomerStatus
            '
            Me.lblCustomerStatus.BackColor = System.Drawing.Color.LightYellow
            Me.lblCustomerStatus.Location = New System.Drawing.Point(8, 80)
            Me.lblCustomerStatus.Name = "lblCustomerStatus"
            Me.lblCustomerStatus.Size = New System.Drawing.Size(88, 16)
            Me.lblCustomerStatus.TabIndex = 16
            Me.lblCustomerStatus.Text = "Not Defined"
            Me.lblCustomerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.SteelBlue
            Me.lblCustomer.ForeColor = System.Drawing.Color.White
            Me.lblCustomer.Location = New System.Drawing.Point(8, 64)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(88, 16)
            Me.lblCustomer.TabIndex = 15
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblParentCoStatus
            '
            Me.lblParentCoStatus.BackColor = System.Drawing.Color.LightYellow
            Me.lblParentCoStatus.Location = New System.Drawing.Point(8, 48)
            Me.lblParentCoStatus.Name = "lblParentCoStatus"
            Me.lblParentCoStatus.Size = New System.Drawing.Size(88, 16)
            Me.lblParentCoStatus.TabIndex = 14
            Me.lblParentCoStatus.Text = "Not Defined"
            Me.lblParentCoStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblParentCo
            '
            Me.lblParentCo.BackColor = System.Drawing.Color.SteelBlue
            Me.lblParentCo.ForeColor = System.Drawing.Color.White
            Me.lblParentCo.Location = New System.Drawing.Point(8, 32)
            Me.lblParentCo.Name = "lblParentCo"
            Me.lblParentCo.Size = New System.Drawing.Size(88, 16)
            Me.lblParentCo.TabIndex = 13
            Me.lblParentCo.Text = "Parent:"
            Me.lblParentCo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnUpdate
            '
            Me.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnUpdate.Location = New System.Drawing.Point(728, 416)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(96, 16)
            Me.btnUpdate.TabIndex = 20
            Me.btnUpdate.TabStop = False
            Me.btnUpdate.Text = "Update"
            Me.btnUpdate.Visible = False
            '
            'ctrlTab
            '
            Me.ctrlTab.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.ctrlTab.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbParent, Me.tpgUpdLabor, Me.tbCustMarkup, Me.tbCustWrty, Me.tbAggBilling, Me.tbCreditCard, Me.tbCustomer, Me.tbSearch, Me.tbLocation, Me.tbCust2Price, Me.TabPage1})
            Me.ctrlTab.Location = New System.Drawing.Point(24, 48)
            Me.ctrlTab.Name = "ctrlTab"
            Me.ctrlTab.SelectedIndex = 0
            Me.ctrlTab.Size = New System.Drawing.Size(688, 328)
            Me.ctrlTab.TabIndex = 21
            Me.ctrlTab.TabStop = False
            '
            'tbParent
            '
            Me.tbParent.Controls.AddRange(New System.Windows.Forms.Control() {Me.PC_valPCOID, Me.PC_valEndUser, Me.PC_valPrcGroup, Me.btnChangeParent, Me.chkEndUser, Me.btnParentCo_UPDATE, Me.btnParentCo_CANCEL, Me.btnParentCo_SAVE, Me.btnParentCo_NEW, Me.PC_txtMotoCode, Me.PC_cboPrcGroup, Me.Label8, Me.GroupBox2, Me.GroupBox1, Me.Label1, Me.PC_cboName, Me.lblPCname, Me.PC_txtName, Me.lblHighlight})
            Me.tbParent.Location = New System.Drawing.Point(4, 22)
            Me.tbParent.Name = "tbParent"
            Me.tbParent.Size = New System.Drawing.Size(680, 302)
            Me.tbParent.TabIndex = 0
            Me.tbParent.Text = "Parent"
            '
            'PC_valPCOID
            '
            Me.PC_valPCOID.Location = New System.Drawing.Point(568, 264)
            Me.PC_valPCOID.Name = "PC_valPCOID"
            Me.PC_valPCOID.Size = New System.Drawing.Size(24, 20)
            Me.PC_valPCOID.TabIndex = 103
            Me.PC_valPCOID.Text = ""
            Me.PC_valPCOID.Visible = False
            '
            'PC_valEndUser
            '
            Me.PC_valEndUser.Location = New System.Drawing.Point(536, 264)
            Me.PC_valEndUser.Name = "PC_valEndUser"
            Me.PC_valEndUser.Size = New System.Drawing.Size(24, 20)
            Me.PC_valEndUser.TabIndex = 102
            Me.PC_valEndUser.Text = ""
            Me.PC_valEndUser.Visible = False
            '
            'PC_valPrcGroup
            '
            Me.PC_valPrcGroup.Location = New System.Drawing.Point(112, 144)
            Me.PC_valPrcGroup.Name = "PC_valPrcGroup"
            Me.PC_valPrcGroup.Size = New System.Drawing.Size(56, 20)
            Me.PC_valPrcGroup.TabIndex = 100
            Me.PC_valPrcGroup.Text = ""
            Me.PC_valPrcGroup.Visible = False
            '
            'btnChangeParent
            '
            Me.btnChangeParent.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnChangeParent.Location = New System.Drawing.Point(528, 48)
            Me.btnChangeParent.Name = "btnChangeParent"
            Me.btnChangeParent.Size = New System.Drawing.Size(88, 16)
            Me.btnChangeParent.TabIndex = 14
            Me.btnChangeParent.Text = "Change Name"
            '
            'chkEndUser
            '
            Me.chkEndUser.Location = New System.Drawing.Point(464, 264)
            Me.chkEndUser.Name = "chkEndUser"
            Me.chkEndUser.Size = New System.Drawing.Size(72, 24)
            Me.chkEndUser.TabIndex = 10
            Me.chkEndUser.Text = "End User"
            '
            'btnParentCo_UPDATE
            '
            Me.btnParentCo_UPDATE.Location = New System.Drawing.Point(528, 8)
            Me.btnParentCo_UPDATE.Name = "btnParentCo_UPDATE"
            Me.btnParentCo_UPDATE.Size = New System.Drawing.Size(80, 24)
            Me.btnParentCo_UPDATE.TabIndex = 13
            Me.btnParentCo_UPDATE.Text = "Update"
            '
            'btnParentCo_CANCEL
            '
            Me.btnParentCo_CANCEL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnParentCo_CANCEL.Location = New System.Drawing.Point(416, 8)
            Me.btnParentCo_CANCEL.Name = "btnParentCo_CANCEL"
            Me.btnParentCo_CANCEL.Size = New System.Drawing.Size(80, 24)
            Me.btnParentCo_CANCEL.TabIndex = 11
            Me.btnParentCo_CANCEL.Text = "Cancel"
            '
            'btnParentCo_SAVE
            '
            Me.btnParentCo_SAVE.Location = New System.Drawing.Point(440, 8)
            Me.btnParentCo_SAVE.Name = "btnParentCo_SAVE"
            Me.btnParentCo_SAVE.Size = New System.Drawing.Size(80, 24)
            Me.btnParentCo_SAVE.TabIndex = 12
            Me.btnParentCo_SAVE.Text = "Save"
            '
            'btnParentCo_NEW
            '
            Me.btnParentCo_NEW.Location = New System.Drawing.Point(8, 8)
            Me.btnParentCo_NEW.Name = "btnParentCo_NEW"
            Me.btnParentCo_NEW.Size = New System.Drawing.Size(40, 24)
            Me.btnParentCo_NEW.TabIndex = 15
            Me.btnParentCo_NEW.Text = "New"
            '
            'PC_txtMotoCode
            '
            Me.PC_txtMotoCode.Location = New System.Drawing.Point(112, 96)
            Me.PC_txtMotoCode.Name = "PC_txtMotoCode"
            Me.PC_txtMotoCode.TabIndex = 2
            Me.PC_txtMotoCode.Text = ""
            '
            'PC_cboPrcGroup
            '
            Me.PC_cboPrcGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PC_cboPrcGroup.Location = New System.Drawing.Point(112, 120)
            Me.PC_cboPrcGroup.Name = "PC_cboPrcGroup"
            Me.PC_cboPrcGroup.Size = New System.Drawing.Size(184, 21)
            Me.PC_cboPrcGroup.TabIndex = 3
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(32, 120)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(80, 16)
            Me.Label8.TabIndex = 23
            Me.Label8.Text = "Pricing Group:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.PC_valWrtyLabor, Me.PC_cboWrtyLabor, Me.PC_cboWrtyParts, Me.PC_txtWrtyDays, Me.Label7, Me.Label6, Me.Label5, Me.PC_valWrtyParts})
            Me.GroupBox2.Location = New System.Drawing.Point(40, 184)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(416, 104)
            Me.GroupBox2.TabIndex = 8
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Warranty"
            '
            'PC_valWrtyLabor
            '
            Me.PC_valWrtyLabor.Location = New System.Drawing.Point(384, 72)
            Me.PC_valWrtyLabor.Name = "PC_valWrtyLabor"
            Me.PC_valWrtyLabor.Size = New System.Drawing.Size(24, 20)
            Me.PC_valWrtyLabor.TabIndex = 102
            Me.PC_valWrtyLabor.Text = ""
            Me.PC_valWrtyLabor.Visible = False
            '
            'PC_cboWrtyLabor
            '
            Me.PC_cboWrtyLabor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PC_cboWrtyLabor.Location = New System.Drawing.Point(128, 72)
            Me.PC_cboWrtyLabor.Name = "PC_cboWrtyLabor"
            Me.PC_cboWrtyLabor.Size = New System.Drawing.Size(256, 21)
            Me.PC_cboWrtyLabor.TabIndex = 9
            '
            'PC_cboWrtyParts
            '
            Me.PC_cboWrtyParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PC_cboWrtyParts.Location = New System.Drawing.Point(128, 48)
            Me.PC_cboWrtyParts.Name = "PC_cboWrtyParts"
            Me.PC_cboWrtyParts.Size = New System.Drawing.Size(256, 21)
            Me.PC_cboWrtyParts.TabIndex = 8
            '
            'PC_txtWrtyDays
            '
            Me.PC_txtWrtyDays.Location = New System.Drawing.Point(128, 24)
            Me.PC_txtWrtyDays.Name = "PC_txtWrtyDays"
            Me.PC_txtWrtyDays.Size = New System.Drawing.Size(40, 20)
            Me.PC_txtWrtyDays.TabIndex = 7
            Me.PC_txtWrtyDays.Text = ""
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(16, 72)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(112, 16)
            Me.Label7.TabIndex = 2
            Me.Label7.Text = "PSS Warranty Labor:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(16, 48)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(112, 16)
            Me.Label6.TabIndex = 1
            Me.Label6.Text = "PSS Warranty Parts:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(16, 24)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(112, 16)
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "Warranty Days:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'PC_valWrtyParts
            '
            Me.PC_valWrtyParts.Location = New System.Drawing.Point(384, 48)
            Me.PC_valWrtyParts.Name = "PC_valWrtyParts"
            Me.PC_valWrtyParts.Size = New System.Drawing.Size(24, 20)
            Me.PC_valWrtyParts.TabIndex = 101
            Me.PC_valWrtyParts.Text = ""
            Me.PC_valWrtyParts.Visible = False
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.PC_txtNER, Me.PC_txtRUR, Me.PC_txtMarkUp, Me.Label4, Me.Label3, Me.Label2})
            Me.GroupBox1.Location = New System.Drawing.Point(304, 80)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(152, 104)
            Me.GroupBox1.TabIndex = 5
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Defaults"
            '
            'PC_txtNER
            '
            Me.PC_txtNER.Location = New System.Drawing.Point(72, 72)
            Me.PC_txtNER.Name = "PC_txtNER"
            Me.PC_txtNER.Size = New System.Drawing.Size(72, 20)
            Me.PC_txtNER.TabIndex = 6
            Me.PC_txtNER.Text = ""
            '
            'PC_txtRUR
            '
            Me.PC_txtRUR.Location = New System.Drawing.Point(72, 48)
            Me.PC_txtRUR.Name = "PC_txtRUR"
            Me.PC_txtRUR.Size = New System.Drawing.Size(72, 20)
            Me.PC_txtRUR.TabIndex = 5
            Me.PC_txtRUR.Text = ""
            '
            'PC_txtMarkUp
            '
            Me.PC_txtMarkUp.Location = New System.Drawing.Point(72, 24)
            Me.PC_txtMarkUp.Name = "PC_txtMarkUp"
            Me.PC_txtMarkUp.Size = New System.Drawing.Size(72, 20)
            Me.PC_txtMarkUp.TabIndex = 4
            Me.PC_txtMarkUp.Text = ""
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(16, 72)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(56, 16)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "NER:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(16, 48)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(56, 16)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "RUR:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(16, 24)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(56, 16)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Mark Up:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(48, 96)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 16)
            Me.Label1.TabIndex = 17
            Me.Label1.Text = "Moto Code:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'PC_cboName
            '
            Me.PC_cboName.Location = New System.Drawing.Point(112, 48)
            Me.PC_cboName.Name = "PC_cboName"
            Me.PC_cboName.Size = New System.Drawing.Size(344, 21)
            Me.PC_cboName.TabIndex = 1
            '
            'lblPCname
            '
            Me.lblPCname.BackColor = System.Drawing.Color.SkyBlue
            Me.lblPCname.Location = New System.Drawing.Point(48, 48)
            Me.lblPCname.Name = "lblPCname"
            Me.lblPCname.Size = New System.Drawing.Size(64, 16)
            Me.lblPCname.TabIndex = 15
            Me.lblPCname.Text = "Name:"
            Me.lblPCname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'PC_txtName
            '
            Me.PC_txtName.Location = New System.Drawing.Point(112, 48)
            Me.PC_txtName.Name = "PC_txtName"
            Me.PC_txtName.Size = New System.Drawing.Size(344, 20)
            Me.PC_txtName.TabIndex = 99
            Me.PC_txtName.TabStop = False
            Me.PC_txtName.Text = ""
            '
            'lblHighlight
            '
            Me.lblHighlight.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblHighlight.BackColor = System.Drawing.Color.SkyBlue
            Me.lblHighlight.Location = New System.Drawing.Point(0, 40)
            Me.lblHighlight.Name = "lblHighlight"
            Me.lblHighlight.Size = New System.Drawing.Size(680, 32)
            Me.lblHighlight.TabIndex = 24
            '
            'tpgUpdLabor
            '
            Me.tpgUpdLabor.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgUpdLabor.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlUpdateLabor})
            Me.tpgUpdLabor.Location = New System.Drawing.Point(4, 22)
            Me.tpgUpdLabor.Name = "tpgUpdLabor"
            Me.tpgUpdLabor.Size = New System.Drawing.Size(680, 302)
            Me.tpgUpdLabor.TabIndex = 10
            Me.tpgUpdLabor.Text = "Update Labor"
            '
            'pnlUpdateLabor
            '
            Me.pnlUpdateLabor.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlULShipDate, Me.chkULProdShipDate, Me.btnUpdateLabor, Me.chkInWip, Me.cboULModels, Me.Label72, Me.cboULCustomers, Me.Label73})
            Me.pnlUpdateLabor.Location = New System.Drawing.Point(8, 8)
            Me.pnlUpdateLabor.Name = "pnlUpdateLabor"
            Me.pnlUpdateLabor.Size = New System.Drawing.Size(656, 272)
            Me.pnlUpdateLabor.TabIndex = 0
            '
            'pnlULShipDate
            '
            Me.pnlULShipDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpULShipEndDate, Me.dtULShipStartDate, Me.Label75, Me.Label74})
            Me.pnlULShipDate.Location = New System.Drawing.Point(24, 120)
            Me.pnlULShipDate.Name = "pnlULShipDate"
            Me.pnlULShipDate.Size = New System.Drawing.Size(288, 72)
            Me.pnlULShipDate.TabIndex = 99
            Me.pnlULShipDate.Visible = False
            '
            'dtpULShipEndDate
            '
            Me.dtpULShipEndDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpULShipEndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpULShipEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpULShipEndDate.Location = New System.Drawing.Point(144, 40)
            Me.dtpULShipEndDate.Name = "dtpULShipEndDate"
            Me.dtpULShipEndDate.Size = New System.Drawing.Size(136, 21)
            Me.dtpULShipEndDate.TabIndex = 98
            Me.dtpULShipEndDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
            '
            'dtULShipStartDate
            '
            Me.dtULShipStartDate.CustomFormat = "yyyy-MM-dd"
            Me.dtULShipStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtULShipStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtULShipStartDate.Location = New System.Drawing.Point(144, 8)
            Me.dtULShipStartDate.Name = "dtULShipStartDate"
            Me.dtULShipStartDate.Size = New System.Drawing.Size(136, 21)
            Me.dtULShipStartDate.TabIndex = 95
            Me.dtULShipStartDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
            '
            'Label75
            '
            Me.Label75.BackColor = System.Drawing.Color.Transparent
            Me.Label75.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label75.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label75.Location = New System.Drawing.Point(16, 40)
            Me.Label75.Name = "Label75"
            Me.Label75.Size = New System.Drawing.Size(120, 16)
            Me.Label75.TabIndex = 97
            Me.Label75.Text = "Ship End Date:"
            Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label74
            '
            Me.Label74.BackColor = System.Drawing.Color.Transparent
            Me.Label74.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label74.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label74.Location = New System.Drawing.Point(16, 16)
            Me.Label74.Name = "Label74"
            Me.Label74.Size = New System.Drawing.Size(126, 16)
            Me.Label74.TabIndex = 96
            Me.Label74.Text = "Ship Start Date:"
            Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkULProdShipDate
            '
            Me.chkULProdShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkULProdShipDate.ForeColor = System.Drawing.Color.White
            Me.chkULProdShipDate.Location = New System.Drawing.Point(128, 88)
            Me.chkULProdShipDate.Name = "chkULProdShipDate"
            Me.chkULProdShipDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkULProdShipDate.Size = New System.Drawing.Size(176, 24)
            Me.chkULProdShipDate.TabIndex = 94
            Me.chkULProdShipDate.Text = "Production Ship Date"
            '
            'btnUpdateLabor
            '
            Me.btnUpdateLabor.BackColor = System.Drawing.Color.Green
            Me.btnUpdateLabor.Location = New System.Drawing.Point(88, 200)
            Me.btnUpdateLabor.Name = "btnUpdateLabor"
            Me.btnUpdateLabor.Size = New System.Drawing.Size(216, 23)
            Me.btnUpdateLabor.TabIndex = 93
            Me.btnUpdateLabor.Text = "Update Labor"
            '
            'chkInWip
            '
            Me.chkInWip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkInWip.ForeColor = System.Drawing.Color.White
            Me.chkInWip.Location = New System.Drawing.Point(17, 88)
            Me.chkInWip.Name = "chkInWip"
            Me.chkInWip.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkInWip.Size = New System.Drawing.Size(84, 24)
            Me.chkInWip.TabIndex = 92
            Me.chkInWip.Text = "In WIP"
            '
            'cboULModels
            '
            Me.cboULModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboULModels.Caption = ""
            Me.cboULModels.CaptionHeight = 17
            Me.cboULModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboULModels.ColumnCaptionHeight = 17
            Me.cboULModels.ColumnFooterHeight = 17
            Me.cboULModels.ContentHeight = 15
            Me.cboULModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboULModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboULModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboULModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboULModels.EditorHeight = 15
            Me.cboULModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboULModels.ItemHeight = 15
            Me.cboULModels.Location = New System.Drawing.Point(88, 56)
            Me.cboULModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboULModels.MaxDropDownItems = CType(5, Short)
            Me.cboULModels.MaxLength = 32767
            Me.cboULModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboULModels.Name = "cboULModels"
            Me.cboULModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboULModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboULModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboULModels.Size = New System.Drawing.Size(216, 21)
            Me.cboULModels.TabIndex = 89
            Me.cboULModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label72
            '
            Me.Label72.BackColor = System.Drawing.Color.Transparent
            Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label72.ForeColor = System.Drawing.Color.White
            Me.Label72.Location = New System.Drawing.Point(16, 56)
            Me.Label72.Name = "Label72"
            Me.Label72.Size = New System.Drawing.Size(73, 16)
            Me.Label72.TabIndex = 91
            Me.Label72.Text = "Model:"
            Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboULCustomers
            '
            Me.cboULCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboULCustomers.Caption = ""
            Me.cboULCustomers.CaptionHeight = 17
            Me.cboULCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboULCustomers.ColumnCaptionHeight = 17
            Me.cboULCustomers.ColumnFooterHeight = 17
            Me.cboULCustomers.ContentHeight = 15
            Me.cboULCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboULCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboULCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboULCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboULCustomers.EditorHeight = 15
            Me.cboULCustomers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboULCustomers.ItemHeight = 15
            Me.cboULCustomers.Location = New System.Drawing.Point(88, 24)
            Me.cboULCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboULCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboULCustomers.MaxLength = 32767
            Me.cboULCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboULCustomers.Name = "cboULCustomers"
            Me.cboULCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboULCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboULCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboULCustomers.Size = New System.Drawing.Size(216, 21)
            Me.cboULCustomers.TabIndex = 88
            Me.cboULCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label73
            '
            Me.Label73.BackColor = System.Drawing.Color.Transparent
            Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label73.ForeColor = System.Drawing.Color.White
            Me.Label73.Location = New System.Drawing.Point(16, 24)
            Me.Label73.Name = "Label73"
            Me.Label73.Size = New System.Drawing.Size(73, 16)
            Me.Label73.TabIndex = 90
            Me.Label73.Text = "Customer:"
            Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tbCustMarkup
            '
            Me.tbCustMarkup.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCustomerMarkup_UPDATE, Me.CM_cboCustomer, Me.CM_txtName, Me.btnCustomerMarkup_Save, Me.btnCustomerMarkup_Cancel, Me.btnCustomerMarkup_NEW, Me.GroupBox4, Me.CM_cboProduct, Me.Label10, Me.Label9, Me.Label58})
            Me.tbCustMarkup.Location = New System.Drawing.Point(4, 22)
            Me.tbCustMarkup.Name = "tbCustMarkup"
            Me.tbCustMarkup.Size = New System.Drawing.Size(680, 302)
            Me.tbCustMarkup.TabIndex = 4
            Me.tbCustMarkup.Text = "Cust Markup"
            '
            'btnCustomerMarkup_UPDATE
            '
            Me.btnCustomerMarkup_UPDATE.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCustomerMarkup_UPDATE.Location = New System.Drawing.Point(592, 8)
            Me.btnCustomerMarkup_UPDATE.Name = "btnCustomerMarkup_UPDATE"
            Me.btnCustomerMarkup_UPDATE.Size = New System.Drawing.Size(80, 24)
            Me.btnCustomerMarkup_UPDATE.TabIndex = 13
            Me.btnCustomerMarkup_UPDATE.Text = "Update"
            '
            'CM_cboCustomer
            '
            Me.CM_cboCustomer.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.CM_cboCustomer.Location = New System.Drawing.Point(168, 56)
            Me.CM_cboCustomer.Name = "CM_cboCustomer"
            Me.CM_cboCustomer.Size = New System.Drawing.Size(352, 20)
            Me.CM_cboCustomer.TabIndex = 1
            '
            'CM_txtName
            '
            Me.CM_txtName.Location = New System.Drawing.Point(168, 56)
            Me.CM_txtName.Name = "CM_txtName"
            Me.CM_txtName.Size = New System.Drawing.Size(280, 20)
            Me.CM_txtName.TabIndex = 60
            Me.CM_txtName.Text = ""
            '
            'btnCustomerMarkup_Save
            '
            Me.btnCustomerMarkup_Save.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCustomerMarkup_Save.Location = New System.Drawing.Point(504, 8)
            Me.btnCustomerMarkup_Save.Name = "btnCustomerMarkup_Save"
            Me.btnCustomerMarkup_Save.Size = New System.Drawing.Size(80, 24)
            Me.btnCustomerMarkup_Save.TabIndex = 12
            Me.btnCustomerMarkup_Save.Text = "Save"
            '
            'btnCustomerMarkup_Cancel
            '
            Me.btnCustomerMarkup_Cancel.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCustomerMarkup_Cancel.Location = New System.Drawing.Point(416, 8)
            Me.btnCustomerMarkup_Cancel.Name = "btnCustomerMarkup_Cancel"
            Me.btnCustomerMarkup_Cancel.Size = New System.Drawing.Size(80, 24)
            Me.btnCustomerMarkup_Cancel.TabIndex = 11
            Me.btnCustomerMarkup_Cancel.Text = "Cancel"
            '
            'btnCustomerMarkup_NEW
            '
            Me.btnCustomerMarkup_NEW.Location = New System.Drawing.Point(8, 8)
            Me.btnCustomerMarkup_NEW.Name = "btnCustomerMarkup_NEW"
            Me.btnCustomerMarkup_NEW.Size = New System.Drawing.Size(40, 24)
            Me.btnCustomerMarkup_NEW.TabIndex = 13
            Me.btnCustomerMarkup_NEW.Text = "New"
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.CM_txtRTM, Me.Label71, Me.CM_txtNTF, Me.Label67, Me.CM_cboplusparts, Me.lblCMplusParts, Me.CM_txtMarkupInvt, Me.Label11, Me.CM_cboInvMthdID, Me.CM_txtCustomer, Me.CM_txtNER, Me.CM_txtRUR, Me.Label15, Me.Label14, Me.Label13, Me.Label12})
            Me.GroupBox4.Location = New System.Drawing.Point(56, 128)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(536, 152)
            Me.GroupBox4.TabIndex = 3
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Markups"
            '
            'CM_txtRTM
            '
            Me.CM_txtRTM.Location = New System.Drawing.Point(440, 24)
            Me.CM_txtRTM.Name = "CM_txtRTM"
            Me.CM_txtRTM.Size = New System.Drawing.Size(72, 20)
            Me.CM_txtRTM.TabIndex = 6
            Me.CM_txtRTM.Text = ""
            '
            'Label71
            '
            Me.Label71.Location = New System.Drawing.Point(408, 24)
            Me.Label71.Name = "Label71"
            Me.Label71.Size = New System.Drawing.Size(32, 16)
            Me.Label71.TabIndex = 62
            Me.Label71.Text = "RTM:"
            Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_txtNTF
            '
            Me.CM_txtNTF.Location = New System.Drawing.Point(224, 24)
            Me.CM_txtNTF.Name = "CM_txtNTF"
            Me.CM_txtNTF.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtNTF.TabIndex = 4
            Me.CM_txtNTF.Text = ""
            '
            'Label67
            '
            Me.Label67.Location = New System.Drawing.Point(184, 24)
            Me.Label67.Name = "Label67"
            Me.Label67.Size = New System.Drawing.Size(38, 16)
            Me.Label67.TabIndex = 61
            Me.Label67.Text = "NTF:"
            Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_cboplusparts
            '
            Me.CM_cboplusparts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CM_cboplusparts.Location = New System.Drawing.Point(352, 112)
            Me.CM_cboplusparts.Name = "CM_cboplusparts"
            Me.CM_cboplusparts.Size = New System.Drawing.Size(48, 21)
            Me.CM_cboplusparts.TabIndex = 10
            '
            'lblCMplusParts
            '
            Me.lblCMplusParts.Location = New System.Drawing.Point(288, 112)
            Me.lblCMplusParts.Name = "lblCMplusParts"
            Me.lblCMplusParts.Size = New System.Drawing.Size(64, 16)
            Me.lblCMplusParts.TabIndex = 59
            Me.lblCMplusParts.Text = "Plus Parts:"
            Me.lblCMplusParts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_txtMarkupInvt
            '
            Me.CM_txtMarkupInvt.Location = New System.Drawing.Point(336, 48)
            Me.CM_txtMarkupInvt.Name = "CM_txtMarkupInvt"
            Me.CM_txtMarkupInvt.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtMarkupInvt.TabIndex = 8
            Me.CM_txtMarkupInvt.Text = ""
            '
            'Label11
            '
            Me.Label11.Location = New System.Drawing.Point(232, 48)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(100, 16)
            Me.Label11.TabIndex = 57
            Me.Label11.Text = "Inventory Markup:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_cboInvMthdID
            '
            Me.CM_cboInvMthdID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CM_cboInvMthdID.Location = New System.Drawing.Point(112, 72)
            Me.CM_cboInvMthdID.Name = "CM_cboInvMthdID"
            Me.CM_cboInvMthdID.Size = New System.Drawing.Size(288, 21)
            Me.CM_cboInvMthdID.TabIndex = 9
            '
            'CM_txtCustomer
            '
            Me.CM_txtCustomer.Location = New System.Drawing.Point(112, 48)
            Me.CM_txtCustomer.Name = "CM_txtCustomer"
            Me.CM_txtCustomer.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtCustomer.TabIndex = 7
            Me.CM_txtCustomer.Text = ""
            '
            'CM_txtNER
            '
            Me.CM_txtNER.Location = New System.Drawing.Point(336, 24)
            Me.CM_txtNER.Name = "CM_txtNER"
            Me.CM_txtNER.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtNER.TabIndex = 5
            Me.CM_txtNER.Text = ""
            '
            'CM_txtRUR
            '
            Me.CM_txtRUR.Location = New System.Drawing.Point(112, 24)
            Me.CM_txtRUR.Name = "CM_txtRUR"
            Me.CM_txtRUR.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtRUR.TabIndex = 3
            Me.CM_txtRUR.Text = ""
            '
            'Label15
            '
            Me.Label15.Location = New System.Drawing.Point(8, 72)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(104, 16)
            Me.Label15.TabIndex = 12
            Me.Label15.Text = "Inventory Method:"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(40, 48)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(72, 16)
            Me.Label14.TabIndex = 11
            Me.Label14.Text = "Customer:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(296, 24)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(40, 16)
            Me.Label13.TabIndex = 10
            Me.Label13.Text = "NER:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label12
            '
            Me.Label12.Location = New System.Drawing.Point(72, 24)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(38, 16)
            Me.Label12.TabIndex = 9
            Me.Label12.Text = "RUR:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_cboProduct
            '
            Me.CM_cboProduct.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.CM_cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CM_cboProduct.Location = New System.Drawing.Point(168, 80)
            Me.CM_cboProduct.Name = "CM_cboProduct"
            Me.CM_cboProduct.Size = New System.Drawing.Size(352, 20)
            Me.CM_cboProduct.TabIndex = 2
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.SkyBlue
            Me.Label10.Location = New System.Drawing.Point(112, 82)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(48, 16)
            Me.Label10.TabIndex = 51
            Me.Label10.Text = "Product:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.SkyBlue
            Me.Label9.Location = New System.Drawing.Point(104, 58)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(56, 16)
            Me.Label9.TabIndex = 50
            Me.Label9.Text = "Customer:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label58
            '
            Me.Label58.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label58.BackColor = System.Drawing.Color.SkyBlue
            Me.Label58.Location = New System.Drawing.Point(0, 40)
            Me.Label58.Name = "Label58"
            Me.Label58.Size = New System.Drawing.Size(680, 72)
            Me.Label58.TabIndex = 62
            '
            'tbCustWrty
            '
            Me.tbCustWrty.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label19, Me.btnCustWrty_UPDATE, Me.btnCustWrty_SAVE, Me.btnCustWrty_CANCEL, Me.btnCustWrty_NEW, Me.CW_cboProduct, Me.CW_cboCustomer, Me.CW_cboWrtyLabor, Me.CW_cboWrtyParts, Me.CW_txtDaysInWrty, Me.Label20, Me.Label18, Me.Label17, Me.Label16, Me.Label60})
            Me.tbCustWrty.Location = New System.Drawing.Point(4, 22)
            Me.tbCustWrty.Name = "tbCustWrty"
            Me.tbCustWrty.Size = New System.Drawing.Size(680, 302)
            Me.tbCustWrty.TabIndex = 3
            Me.tbCustWrty.Text = "Cust Warranty"
            '
            'Label19
            '
            Me.Label19.BackColor = System.Drawing.Color.SkyBlue
            Me.Label19.Location = New System.Drawing.Point(112, 56)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(56, 16)
            Me.Label19.TabIndex = 59
            Me.Label19.Text = "Customer:"
            Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCustWrty_UPDATE
            '
            Me.btnCustWrty_UPDATE.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCustWrty_UPDATE.Location = New System.Drawing.Point(592, 8)
            Me.btnCustWrty_UPDATE.Name = "btnCustWrty_UPDATE"
            Me.btnCustWrty_UPDATE.Size = New System.Drawing.Size(80, 24)
            Me.btnCustWrty_UPDATE.TabIndex = 8
            Me.btnCustWrty_UPDATE.Text = "Update"
            '
            'btnCustWrty_SAVE
            '
            Me.btnCustWrty_SAVE.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCustWrty_SAVE.Location = New System.Drawing.Point(504, 8)
            Me.btnCustWrty_SAVE.Name = "btnCustWrty_SAVE"
            Me.btnCustWrty_SAVE.Size = New System.Drawing.Size(80, 24)
            Me.btnCustWrty_SAVE.TabIndex = 7
            Me.btnCustWrty_SAVE.Text = "Save"
            '
            'btnCustWrty_CANCEL
            '
            Me.btnCustWrty_CANCEL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCustWrty_CANCEL.Location = New System.Drawing.Point(416, 8)
            Me.btnCustWrty_CANCEL.Name = "btnCustWrty_CANCEL"
            Me.btnCustWrty_CANCEL.Size = New System.Drawing.Size(80, 24)
            Me.btnCustWrty_CANCEL.TabIndex = 6
            Me.btnCustWrty_CANCEL.Text = "Cancel"
            '
            'btnCustWrty_NEW
            '
            Me.btnCustWrty_NEW.Location = New System.Drawing.Point(8, 8)
            Me.btnCustWrty_NEW.Name = "btnCustWrty_NEW"
            Me.btnCustWrty_NEW.Size = New System.Drawing.Size(40, 24)
            Me.btnCustWrty_NEW.TabIndex = 9
            Me.btnCustWrty_NEW.Text = "New"
            '
            'CW_cboProduct
            '
            Me.CW_cboProduct.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.CW_cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CW_cboProduct.Location = New System.Drawing.Point(168, 80)
            Me.CW_cboProduct.Name = "CW_cboProduct"
            Me.CW_cboProduct.Size = New System.Drawing.Size(352, 20)
            Me.CW_cboProduct.TabIndex = 2
            '
            'CW_cboCustomer
            '
            Me.CW_cboCustomer.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.CW_cboCustomer.Location = New System.Drawing.Point(168, 56)
            Me.CW_cboCustomer.Name = "CW_cboCustomer"
            Me.CW_cboCustomer.Size = New System.Drawing.Size(352, 20)
            Me.CW_cboCustomer.TabIndex = 1
            '
            'CW_cboWrtyLabor
            '
            Me.CW_cboWrtyLabor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CW_cboWrtyLabor.Location = New System.Drawing.Point(232, 184)
            Me.CW_cboWrtyLabor.Name = "CW_cboWrtyLabor"
            Me.CW_cboWrtyLabor.Size = New System.Drawing.Size(224, 21)
            Me.CW_cboWrtyLabor.TabIndex = 5
            '
            'CW_cboWrtyParts
            '
            Me.CW_cboWrtyParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CW_cboWrtyParts.Location = New System.Drawing.Point(232, 160)
            Me.CW_cboWrtyParts.Name = "CW_cboWrtyParts"
            Me.CW_cboWrtyParts.Size = New System.Drawing.Size(224, 21)
            Me.CW_cboWrtyParts.TabIndex = 4
            '
            'CW_txtDaysInWrty
            '
            Me.CW_txtDaysInWrty.Location = New System.Drawing.Point(232, 136)
            Me.CW_txtDaysInWrty.Name = "CW_txtDaysInWrty"
            Me.CW_txtDaysInWrty.Size = New System.Drawing.Size(56, 20)
            Me.CW_txtDaysInWrty.TabIndex = 3
            Me.CW_txtDaysInWrty.Text = ""
            '
            'Label20
            '
            Me.Label20.BackColor = System.Drawing.Color.SkyBlue
            Me.Label20.Location = New System.Drawing.Point(104, 80)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(56, 16)
            Me.Label20.TabIndex = 60
            Me.Label20.Text = "Product:"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label18
            '
            Me.Label18.Location = New System.Drawing.Point(120, 184)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(112, 16)
            Me.Label18.TabIndex = 58
            Me.Label18.Text = "Warranty Labor:"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label17
            '
            Me.Label17.Location = New System.Drawing.Point(120, 160)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(112, 16)
            Me.Label17.TabIndex = 57
            Me.Label17.Text = "Warranty Parts:"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label16
            '
            Me.Label16.Location = New System.Drawing.Point(136, 136)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(96, 16)
            Me.Label16.TabIndex = 56
            Me.Label16.Text = "Days In Warranty:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label60
            '
            Me.Label60.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label60.BackColor = System.Drawing.Color.SkyBlue
            Me.Label60.Location = New System.Drawing.Point(0, 40)
            Me.Label60.Name = "Label60"
            Me.Label60.Size = New System.Drawing.Size(680, 72)
            Me.Label60.TabIndex = 70
            '
            'tbAggBilling
            '
            Me.tbAggBilling.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpAggregates})
            Me.tbAggBilling.Location = New System.Drawing.Point(4, 22)
            Me.tbAggBilling.Name = "tbAggBilling"
            Me.tbAggBilling.Size = New System.Drawing.Size(680, 302)
            Me.tbAggBilling.TabIndex = 9
            Me.tbAggBilling.Text = "Aggregate Billing"
            '
            'grpAggregates
            '
            Me.grpAggregates.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRemove, Me.btnInsert, Me.txtAmount, Me.txtBillCode, Me.Label70, Me.Label69, Me.gridAggregate, Me.Label68, Me.lstAggCodes})
            Me.grpAggregates.Location = New System.Drawing.Point(16, 16)
            Me.grpAggregates.Name = "grpAggregates"
            Me.grpAggregates.Size = New System.Drawing.Size(584, 280)
            Me.grpAggregates.TabIndex = 44
            Me.grpAggregates.TabStop = False
            Me.grpAggregates.Text = "Aggregate Billing"
            '
            'btnRemove
            '
            Me.btnRemove.Location = New System.Drawing.Point(472, 208)
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.Size = New System.Drawing.Size(96, 48)
            Me.btnRemove.TabIndex = 52
            Me.btnRemove.Text = "Remove"
            '
            'btnInsert
            '
            Me.btnInsert.Location = New System.Drawing.Point(360, 208)
            Me.btnInsert.Name = "btnInsert"
            Me.btnInsert.Size = New System.Drawing.Size(96, 48)
            Me.btnInsert.TabIndex = 51
            Me.btnInsert.Text = "Insert"
            '
            'txtAmount
            '
            Me.txtAmount.Location = New System.Drawing.Point(248, 232)
            Me.txtAmount.Name = "txtAmount"
            Me.txtAmount.TabIndex = 50
            Me.txtAmount.Text = ""
            '
            'txtBillCode
            '
            Me.txtBillCode.Location = New System.Drawing.Point(248, 208)
            Me.txtBillCode.Name = "txtBillCode"
            Me.txtBillCode.TabIndex = 49
            Me.txtBillCode.Text = ""
            '
            'Label70
            '
            Me.Label70.Location = New System.Drawing.Point(176, 232)
            Me.Label70.Name = "Label70"
            Me.Label70.Size = New System.Drawing.Size(64, 16)
            Me.Label70.TabIndex = 48
            Me.Label70.Text = "Amount:"
            Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label69
            '
            Me.Label69.Location = New System.Drawing.Point(176, 208)
            Me.Label69.Name = "Label69"
            Me.Label69.Size = New System.Drawing.Size(64, 16)
            Me.Label69.TabIndex = 47
            Me.Label69.Text = "BillCode:"
            Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'gridAggregate
            '
            Me.gridAggregate.AllowColMove = False
            Me.gridAggregate.AllowColSelect = False
            Me.gridAggregate.AllowDelete = True
            Me.gridAggregate.AllowFilter = False
            Me.gridAggregate.AllowSort = False
            Me.gridAggregate.AllowUpdate = False
            Me.gridAggregate.AlternatingRows = True
            Me.gridAggregate.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gridAggregate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.gridAggregate.CaptionHeight = 17
            Me.gridAggregate.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridAggregate.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.gridAggregate.Location = New System.Drawing.Point(248, 48)
            Me.gridAggregate.Name = "gridAggregate"
            Me.gridAggregate.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gridAggregate.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gridAggregate.PreviewInfo.ZoomFactor = 75
            Me.gridAggregate.RowHeight = 15
            Me.gridAggregate.Size = New System.Drawing.Size(320, 152)
            Me.gridAggregate.TabIndex = 46
            Me.gridAggregate.Text = "C1TrueDBGrid1"
            Me.gridAggregate.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Caption=""BillCode"" DataField=""" & _
            """><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""ID"" DataField" & _
            "=""""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""Amount"" Dat" & _
            "aField=""""><ValueItems /><GroupInfo /></C1DataColumn></DataCols><Styles type=""C1." & _
            "Win.C1TrueDBGrid.Design.ContextWrapper""><Data>HighlightRow{ForeColor:HighlightTe" & _
            "xt;BackColor:Highlight;}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}S" & _
            "tyle25{}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{Al" & _
            "ignHorz:Near;}Style19{AlignHorz:Near;}Style14{AlignHorz:Near;}Style15{AlignHorz:" & _
            "Near;}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{}Style13{}Style3" & _
            "2{}Style33{}Style31{}Footer{}Style29{}Style28{}Style27{}Style26{}RecordSelector{" & _
            "AlignImage:Center;}Style24{}Style23{AlignHorz:Near;}Style22{AlignHorz:Near;}Styl" & _
            "e21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}" & _
            "EvenRow{BackColor:Aqua;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1," & _
            " 1, 1;ForeColor:ControlText;AlignVert:Center;}FilterBar{}Style5{}Style4{}Style9{" & _
            "}Style8{}Style12{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:Contr" & _
            "olDark;}Style7{}Style6{}Style1{}Style30{}Style3{}Style2{}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
            "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>150</H" & _
            "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
            "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
            "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
            "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
            "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
            "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
            """Style6"" /><Style parent=""Normal"" me=""Style1"" /><internalCols><C1DisplayColumn><" & _
            "HeadingStyle parent=""Style2"" me=""Style14"" /><Style parent=""Style1"" me=""Style15"" " & _
            "/><FooterStyle parent=""Style3"" me=""Style16"" /><EditorStyle parent=""Style5"" me=""S" & _
            "tyle17"" /><GroupHeaderStyle parent=""Style1"" me=""Style29"" /><GroupFooterStyle par" & _
            "ent=""Style1"" me=""Style28"" /><Visible>True</Visible><ColumnDivider>DarkGray,Singl" & _
            "e</ColumnDivider><Height>15</Height><DCIdx>0</DCIdx></C1DisplayColumn><C1Display" & _
            "Column><HeadingStyle parent=""Style2"" me=""Style18"" /><Style parent=""Style1"" me=""S" & _
            "tyle19"" /><FooterStyle parent=""Style3"" me=""Style20"" /><EditorStyle parent=""Style" & _
            "5"" me=""Style21"" /><GroupHeaderStyle parent=""Style1"" me=""Style31"" /><GroupFooterS" & _
            "tyle parent=""Style1"" me=""Style30"" /><Visible>True</Visible><ColumnDivider>DarkGr" & _
            "ay,Single</ColumnDivider><Height>15</Height><DCIdx>1</DCIdx></C1DisplayColumn><C" & _
            "1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style22"" /><Style parent=""Style" & _
            "1"" me=""Style23"" /><FooterStyle parent=""Style3"" me=""Style24"" /><EditorStyle paren" & _
            "t=""Style5"" me=""Style25"" /><GroupHeaderStyle parent=""Style1"" me=""Style33"" /><Grou" & _
            "pFooterStyle parent=""Style1"" me=""Style32"" /><Visible>True</Visible><ColumnDivide" & _
            "r>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>2</DCIdx></C1DisplayC" & _
            "olumn></internalCols><ClientRect>0, 0, 318, 150</ClientRect><BorderSide>0</Borde" & _
            "rSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits>" & _
            "<NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" " & _
            "/><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><" & _
            "Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><S" & _
            "tyle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><S" & _
            "tyle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style " & _
            "parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><" & _
            "Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><hor" & _
            "zSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRe" & _
            "cSelWidth><ClientArea>0, 0, 318, 150</ClientArea><PrintPageHeaderStyle parent=""""" & _
            " me=""Style26"" /><PrintPageFooterStyle parent="""" me=""Style27"" /></Blob>"
            '
            'Label68
            '
            Me.Label68.Location = New System.Drawing.Point(96, 56)
            Me.Label68.Name = "Label68"
            Me.Label68.Size = New System.Drawing.Size(120, 32)
            Me.Label68.TabIndex = 45
            Me.Label68.Text = "Available Aggregate Bill Codes"
            Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lstAggCodes
            '
            Me.lstAggCodes.Location = New System.Drawing.Point(96, 88)
            Me.lstAggCodes.Name = "lstAggCodes"
            Me.lstAggCodes.Size = New System.Drawing.Size(120, 108)
            Me.lstAggCodes.TabIndex = 44
            '
            'tbCreditCard
            '
            Me.tbCreditCard.Controls.AddRange(New System.Windows.Forms.Control() {Me.CC_txtAuthCode, Me.lblAuthCode, Me.btnCreditCard_UPDATE, Me.btnCreditCard_SAVE, Me.btnCreditCard_CANCEL, Me.btnCreditCard_NEW, Me.CC_cboCustomer, Me.CC_txtExpDate, Me.CC_txtCCNumber, Me.CC_cboCCType, Me.Label24, Me.Label23, Me.Label22, Me.Label21, Me.CC_txtName, Me.Label59})
            Me.tbCreditCard.Location = New System.Drawing.Point(4, 22)
            Me.tbCreditCard.Name = "tbCreditCard"
            Me.tbCreditCard.Size = New System.Drawing.Size(680, 302)
            Me.tbCreditCard.TabIndex = 5
            Me.tbCreditCard.Text = "Credit Card"
            '
            'CC_txtAuthCode
            '
            Me.CC_txtAuthCode.Location = New System.Drawing.Point(136, 128)
            Me.CC_txtAuthCode.Name = "CC_txtAuthCode"
            Me.CC_txtAuthCode.Size = New System.Drawing.Size(64, 20)
            Me.CC_txtAuthCode.TabIndex = 4
            Me.CC_txtAuthCode.Text = ""
            '
            'lblAuthCode
            '
            Me.lblAuthCode.Location = New System.Drawing.Point(32, 128)
            Me.lblAuthCode.Name = "lblAuthCode"
            Me.lblAuthCode.Size = New System.Drawing.Size(104, 16)
            Me.lblAuthCode.TabIndex = 73
            Me.lblAuthCode.Text = "Authorization Code:"
            Me.lblAuthCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCreditCard_UPDATE
            '
            Me.btnCreditCard_UPDATE.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCreditCard_UPDATE.Location = New System.Drawing.Point(592, 8)
            Me.btnCreditCard_UPDATE.Name = "btnCreditCard_UPDATE"
            Me.btnCreditCard_UPDATE.Size = New System.Drawing.Size(80, 24)
            Me.btnCreditCard_UPDATE.TabIndex = 8
            Me.btnCreditCard_UPDATE.Text = "Update"
            '
            'btnCreditCard_SAVE
            '
            Me.btnCreditCard_SAVE.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCreditCard_SAVE.Location = New System.Drawing.Point(504, 8)
            Me.btnCreditCard_SAVE.Name = "btnCreditCard_SAVE"
            Me.btnCreditCard_SAVE.Size = New System.Drawing.Size(80, 24)
            Me.btnCreditCard_SAVE.TabIndex = 7
            Me.btnCreditCard_SAVE.Text = "Save"
            '
            'btnCreditCard_CANCEL
            '
            Me.btnCreditCard_CANCEL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCreditCard_CANCEL.Location = New System.Drawing.Point(416, 8)
            Me.btnCreditCard_CANCEL.Name = "btnCreditCard_CANCEL"
            Me.btnCreditCard_CANCEL.Size = New System.Drawing.Size(80, 24)
            Me.btnCreditCard_CANCEL.TabIndex = 6
            Me.btnCreditCard_CANCEL.Text = "Cancel"
            '
            'btnCreditCard_NEW
            '
            Me.btnCreditCard_NEW.Location = New System.Drawing.Point(8, 8)
            Me.btnCreditCard_NEW.Name = "btnCreditCard_NEW"
            Me.btnCreditCard_NEW.Size = New System.Drawing.Size(40, 24)
            Me.btnCreditCard_NEW.TabIndex = 9
            Me.btnCreditCard_NEW.Text = "New"
            '
            'CC_cboCustomer
            '
            Me.CC_cboCustomer.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.CC_cboCustomer.Location = New System.Drawing.Point(136, 48)
            Me.CC_cboCustomer.Name = "CC_cboCustomer"
            Me.CC_cboCustomer.Size = New System.Drawing.Size(336, 20)
            Me.CC_cboCustomer.TabIndex = 1
            '
            'CC_txtExpDate
            '
            Me.CC_txtExpDate.Location = New System.Drawing.Point(136, 152)
            Me.CC_txtExpDate.Name = "CC_txtExpDate"
            Me.CC_txtExpDate.Size = New System.Drawing.Size(64, 20)
            Me.CC_txtExpDate.TabIndex = 5
            Me.CC_txtExpDate.Text = ""
            '
            'CC_txtCCNumber
            '
            Me.CC_txtCCNumber.Location = New System.Drawing.Point(136, 104)
            Me.CC_txtCCNumber.Name = "CC_txtCCNumber"
            Me.CC_txtCCNumber.Size = New System.Drawing.Size(120, 20)
            Me.CC_txtCCNumber.TabIndex = 3
            Me.CC_txtCCNumber.Text = ""
            '
            'CC_cboCCType
            '
            Me.CC_cboCCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CC_cboCCType.Location = New System.Drawing.Point(136, 80)
            Me.CC_cboCCType.Name = "CC_cboCCType"
            Me.CC_cboCCType.Size = New System.Drawing.Size(128, 21)
            Me.CC_cboCCType.TabIndex = 2
            '
            'Label24
            '
            Me.Label24.BackColor = System.Drawing.Color.SkyBlue
            Me.Label24.Location = New System.Drawing.Point(80, 48)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(56, 16)
            Me.Label24.TabIndex = 61
            Me.Label24.Text = "Customer:"
            Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label23
            '
            Me.Label23.Location = New System.Drawing.Point(32, 152)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(100, 16)
            Me.Label23.TabIndex = 60
            Me.Label23.Text = "Expiration Date:"
            Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label22
            '
            Me.Label22.Location = New System.Drawing.Point(24, 104)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(112, 16)
            Me.Label22.TabIndex = 59
            Me.Label22.Text = "Credit Card Number:"
            Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label21
            '
            Me.Label21.Location = New System.Drawing.Point(32, 80)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(104, 16)
            Me.Label21.TabIndex = 58
            Me.Label21.Text = "Credit Card Type:"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CC_txtName
            '
            Me.CC_txtName.Location = New System.Drawing.Point(136, 80)
            Me.CC_txtName.Name = "CC_txtName"
            Me.CC_txtName.Size = New System.Drawing.Size(128, 20)
            Me.CC_txtName.TabIndex = 66
            Me.CC_txtName.Text = ""
            '
            'Label59
            '
            Me.Label59.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label59.BackColor = System.Drawing.Color.SkyBlue
            Me.Label59.Location = New System.Drawing.Point(0, 40)
            Me.Label59.Name = "Label59"
            Me.Label59.Size = New System.Drawing.Size(680, 32)
            Me.Label59.TabIndex = 71
            '
            'tbCustomer
            '
            Me.tbCustomer.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAggBill, Me.CUST_txtMemo, Me.CUST_chkINACTIVE, Me.CUST_valCustID, Me.CUST_cboInvoiceDetail, Me.Label63, Me.btnChangeName, Me.btnCustomer_UPDATE, Me.btnCustomer_NEW, Me.CUST_cboName, Me.btnCustomer_Save, Me.btnCustomer_Cancel, Me.CUST_cboSalesPerson, Me.CUST_cboParentCo, Me.CUST_cboPayID, Me.CUST_cboCollSalesTax, Me.CUST_cboCrAppShip, Me.CUST_cboCrAppRec, Me.CUST_cboRepLCD, Me.CUST_cboRepNonWrty, Me.CUST_txtRejectTimes, Me.CUST_txtRejectDays, Me.CUST_cboPlusParts, Me.CUST_txtLName, Me.CUST_txtFName, Me.Label37, Me.Label36, Me.Label35, Me.Label34, Me.Label33, Me.Label32, Me.Label31, Me.Label30, Me.Label29, Me.Label28, Me.Label27, Me.Label26, Me.Label25, Me.Label57})
            Me.tbCustomer.Location = New System.Drawing.Point(4, 22)
            Me.tbCustomer.Name = "tbCustomer"
            Me.tbCustomer.Size = New System.Drawing.Size(680, 302)
            Me.tbCustomer.TabIndex = 1
            Me.tbCustomer.Text = "Customer"
            '
            'chkAggBill
            '
            Me.chkAggBill.Location = New System.Drawing.Point(400, 248)
            Me.chkAggBill.Name = "chkAggBill"
            Me.chkAggBill.Size = New System.Drawing.Size(112, 24)
            Me.chkAggBill.TabIndex = 15
            Me.chkAggBill.Text = "Aggregate Billing"
            '
            'CUST_txtMemo
            '
            Me.CUST_txtMemo.Location = New System.Drawing.Point(8, 264)
            Me.CUST_txtMemo.Multiline = True
            Me.CUST_txtMemo.Name = "CUST_txtMemo"
            Me.CUST_txtMemo.Size = New System.Drawing.Size(344, 32)
            Me.CUST_txtMemo.TabIndex = 106
            Me.CUST_txtMemo.Text = ""
            '
            'CUST_chkINACTIVE
            '
            Me.CUST_chkINACTIVE.Location = New System.Drawing.Point(112, 232)
            Me.CUST_chkINACTIVE.Name = "CUST_chkINACTIVE"
            Me.CUST_chkINACTIVE.TabIndex = 105
            Me.CUST_chkINACTIVE.Text = "INACTIVATE"
            '
            'CUST_valCustID
            '
            Me.CUST_valCustID.Location = New System.Drawing.Point(568, 272)
            Me.CUST_valCustID.Name = "CUST_valCustID"
            Me.CUST_valCustID.Size = New System.Drawing.Size(24, 20)
            Me.CUST_valCustID.TabIndex = 104
            Me.CUST_valCustID.Text = ""
            Me.CUST_valCustID.Visible = False
            '
            'CUST_cboInvoiceDetail
            '
            Me.CUST_cboInvoiceDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboInvoiceDetail.Location = New System.Drawing.Point(464, 224)
            Me.CUST_cboInvoiceDetail.Name = "CUST_cboInvoiceDetail"
            Me.CUST_cboInvoiceDetail.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboInvoiceDetail.TabIndex = 14
            '
            'Label63
            '
            Me.Label63.Location = New System.Drawing.Point(360, 224)
            Me.Label63.Name = "Label63"
            Me.Label63.Size = New System.Drawing.Size(100, 16)
            Me.Label63.TabIndex = 61
            Me.Label63.Text = "Invoice Detail:"
            Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnChangeName
            '
            Me.btnChangeName.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnChangeName.Location = New System.Drawing.Point(536, 48)
            Me.btnChangeName.Name = "btnChangeName"
            Me.btnChangeName.Size = New System.Drawing.Size(88, 16)
            Me.btnChangeName.TabIndex = 19
            Me.btnChangeName.Text = "Change Name"
            '
            'btnCustomer_UPDATE
            '
            Me.btnCustomer_UPDATE.Location = New System.Drawing.Point(528, 8)
            Me.btnCustomer_UPDATE.Name = "btnCustomer_UPDATE"
            Me.btnCustomer_UPDATE.Size = New System.Drawing.Size(80, 24)
            Me.btnCustomer_UPDATE.TabIndex = 18
            Me.btnCustomer_UPDATE.Text = "Update"
            '
            'btnCustomer_NEW
            '
            Me.btnCustomer_NEW.Location = New System.Drawing.Point(8, 8)
            Me.btnCustomer_NEW.Name = "btnCustomer_NEW"
            Me.btnCustomer_NEW.Size = New System.Drawing.Size(40, 24)
            Me.btnCustomer_NEW.TabIndex = 19
            Me.btnCustomer_NEW.Text = "New"
            '
            'CUST_cboName
            '
            Me.CUST_cboName.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.CUST_cboName.Location = New System.Drawing.Point(112, 48)
            Me.CUST_cboName.Name = "CUST_cboName"
            Me.CUST_cboName.Size = New System.Drawing.Size(416, 20)
            Me.CUST_cboName.TabIndex = 1
            '
            'btnCustomer_Save
            '
            Me.btnCustomer_Save.Location = New System.Drawing.Point(440, 8)
            Me.btnCustomer_Save.Name = "btnCustomer_Save"
            Me.btnCustomer_Save.Size = New System.Drawing.Size(80, 24)
            Me.btnCustomer_Save.TabIndex = 17
            Me.btnCustomer_Save.Text = "Save"
            '
            'btnCustomer_Cancel
            '
            Me.btnCustomer_Cancel.Location = New System.Drawing.Point(352, 8)
            Me.btnCustomer_Cancel.Name = "btnCustomer_Cancel"
            Me.btnCustomer_Cancel.Size = New System.Drawing.Size(80, 24)
            Me.btnCustomer_Cancel.TabIndex = 16
            Me.btnCustomer_Cancel.Text = "Cancel"
            '
            'CUST_cboSalesPerson
            '
            Me.CUST_cboSalesPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboSalesPerson.Location = New System.Drawing.Point(112, 200)
            Me.CUST_cboSalesPerson.Name = "CUST_cboSalesPerson"
            Me.CUST_cboSalesPerson.Size = New System.Drawing.Size(176, 21)
            Me.CUST_cboSalesPerson.TabIndex = 7
            '
            'CUST_cboParentCo
            '
            Me.CUST_cboParentCo.Location = New System.Drawing.Point(112, 176)
            Me.CUST_cboParentCo.Name = "CUST_cboParentCo"
            Me.CUST_cboParentCo.Size = New System.Drawing.Size(176, 21)
            Me.CUST_cboParentCo.TabIndex = 6
            '
            'CUST_cboPayID
            '
            Me.CUST_cboPayID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboPayID.Location = New System.Drawing.Point(112, 152)
            Me.CUST_cboPayID.Name = "CUST_cboPayID"
            Me.CUST_cboPayID.Size = New System.Drawing.Size(176, 21)
            Me.CUST_cboPayID.TabIndex = 5
            '
            'CUST_cboCollSalesTax
            '
            Me.CUST_cboCollSalesTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboCollSalesTax.Location = New System.Drawing.Point(464, 200)
            Me.CUST_cboCollSalesTax.Name = "CUST_cboCollSalesTax"
            Me.CUST_cboCollSalesTax.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboCollSalesTax.TabIndex = 13
            '
            'CUST_cboCrAppShip
            '
            Me.CUST_cboCrAppShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboCrAppShip.Location = New System.Drawing.Point(464, 176)
            Me.CUST_cboCrAppShip.Name = "CUST_cboCrAppShip"
            Me.CUST_cboCrAppShip.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboCrAppShip.TabIndex = 12
            '
            'CUST_cboCrAppRec
            '
            Me.CUST_cboCrAppRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboCrAppRec.Location = New System.Drawing.Point(464, 152)
            Me.CUST_cboCrAppRec.Name = "CUST_cboCrAppRec"
            Me.CUST_cboCrAppRec.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboCrAppRec.TabIndex = 11
            '
            'CUST_cboRepLCD
            '
            Me.CUST_cboRepLCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboRepLCD.Location = New System.Drawing.Point(464, 128)
            Me.CUST_cboRepLCD.Name = "CUST_cboRepLCD"
            Me.CUST_cboRepLCD.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboRepLCD.TabIndex = 10
            '
            'CUST_cboRepNonWrty
            '
            Me.CUST_cboRepNonWrty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboRepNonWrty.Location = New System.Drawing.Point(464, 104)
            Me.CUST_cboRepNonWrty.Name = "CUST_cboRepNonWrty"
            Me.CUST_cboRepNonWrty.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboRepNonWrty.TabIndex = 9
            '
            'CUST_txtRejectTimes
            '
            Me.CUST_txtRejectTimes.Location = New System.Drawing.Point(112, 128)
            Me.CUST_txtRejectTimes.Name = "CUST_txtRejectTimes"
            Me.CUST_txtRejectTimes.TabIndex = 4
            Me.CUST_txtRejectTimes.Text = ""
            '
            'CUST_txtRejectDays
            '
            Me.CUST_txtRejectDays.Location = New System.Drawing.Point(112, 104)
            Me.CUST_txtRejectDays.Name = "CUST_txtRejectDays"
            Me.CUST_txtRejectDays.TabIndex = 3
            Me.CUST_txtRejectDays.Text = ""
            '
            'CUST_cboPlusParts
            '
            Me.CUST_cboPlusParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboPlusParts.Location = New System.Drawing.Point(464, 80)
            Me.CUST_cboPlusParts.Name = "CUST_cboPlusParts"
            Me.CUST_cboPlusParts.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboPlusParts.TabIndex = 8
            Me.CUST_cboPlusParts.Visible = False
            '
            'CUST_txtLName
            '
            Me.CUST_txtLName.Location = New System.Drawing.Point(112, 80)
            Me.CUST_txtLName.Name = "CUST_txtLName"
            Me.CUST_txtLName.Size = New System.Drawing.Size(144, 20)
            Me.CUST_txtLName.TabIndex = 2
            Me.CUST_txtLName.Text = ""
            '
            'CUST_txtFName
            '
            Me.CUST_txtFName.Location = New System.Drawing.Point(112, 48)
            Me.CUST_txtFName.Name = "CUST_txtFName"
            Me.CUST_txtFName.Size = New System.Drawing.Size(352, 20)
            Me.CUST_txtFName.TabIndex = 99
            Me.CUST_txtFName.TabStop = False
            Me.CUST_txtFName.Text = ""
            '
            'Label37
            '
            Me.Label37.Location = New System.Drawing.Point(8, 202)
            Me.Label37.Name = "Label37"
            Me.Label37.Size = New System.Drawing.Size(100, 16)
            Me.Label37.TabIndex = 41
            Me.Label37.Text = "Sales Person:"
            Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label36
            '
            Me.Label36.Location = New System.Drawing.Point(8, 178)
            Me.Label36.Name = "Label36"
            Me.Label36.Size = New System.Drawing.Size(100, 16)
            Me.Label36.TabIndex = 40
            Me.Label36.Text = "Parent Company:"
            Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label35
            '
            Me.Label35.Location = New System.Drawing.Point(32, 154)
            Me.Label35.Name = "Label35"
            Me.Label35.Size = New System.Drawing.Size(72, 16)
            Me.Label35.TabIndex = 38
            Me.Label35.Text = "Pay ID:"
            Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label34
            '
            Me.Label34.Location = New System.Drawing.Point(360, 200)
            Me.Label34.Name = "Label34"
            Me.Label34.Size = New System.Drawing.Size(100, 16)
            Me.Label34.TabIndex = 37
            Me.Label34.Text = "Collect Sales Tax:"
            Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label33
            '
            Me.Label33.Location = New System.Drawing.Point(344, 176)
            Me.Label33.Name = "Label33"
            Me.Label33.Size = New System.Drawing.Size(120, 16)
            Me.Label33.TabIndex = 36
            Me.Label33.Text = "Credit Approve Ship:"
            Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label32
            '
            Me.Label32.Location = New System.Drawing.Point(336, 152)
            Me.Label32.Name = "Label32"
            Me.Label32.Size = New System.Drawing.Size(128, 16)
            Me.Label32.TabIndex = 35
            Me.Label32.Text = "Credit Approve Receive:"
            Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label31
            '
            Me.Label31.Location = New System.Drawing.Point(360, 128)
            Me.Label31.Name = "Label31"
            Me.Label31.Size = New System.Drawing.Size(100, 16)
            Me.Label31.TabIndex = 34
            Me.Label31.Text = "Replace LCD:"
            Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label30
            '
            Me.Label30.Location = New System.Drawing.Point(344, 104)
            Me.Label30.Name = "Label30"
            Me.Label30.Size = New System.Drawing.Size(120, 16)
            Me.Label30.TabIndex = 33
            Me.Label30.Text = "Repair Non-Warranty:"
            Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label29
            '
            Me.Label29.Location = New System.Drawing.Point(24, 130)
            Me.Label29.Name = "Label29"
            Me.Label29.Size = New System.Drawing.Size(80, 16)
            Me.Label29.TabIndex = 32
            Me.Label29.Text = "Reject Times:"
            Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label28
            '
            Me.Label28.Location = New System.Drawing.Point(24, 106)
            Me.Label28.Name = "Label28"
            Me.Label28.Size = New System.Drawing.Size(80, 16)
            Me.Label28.TabIndex = 31
            Me.Label28.Text = "Reject Days:"
            Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label27
            '
            Me.Label27.Location = New System.Drawing.Point(400, 80)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(64, 16)
            Me.Label27.TabIndex = 30
            Me.Label27.Text = "Plus Parts:"
            Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label27.Visible = False
            '
            'Label26
            '
            Me.Label26.Location = New System.Drawing.Point(40, 82)
            Me.Label26.Name = "Label26"
            Me.Label26.Size = New System.Drawing.Size(64, 16)
            Me.Label26.TabIndex = 29
            Me.Label26.Text = "Last Name:"
            Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label25
            '
            Me.Label25.BackColor = System.Drawing.Color.SkyBlue
            Me.Label25.Location = New System.Drawing.Point(48, 48)
            Me.Label25.Name = "Label25"
            Me.Label25.Size = New System.Drawing.Size(64, 16)
            Me.Label25.TabIndex = 28
            Me.Label25.Text = "First Name:"
            Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label57
            '
            Me.Label57.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label57.BackColor = System.Drawing.Color.SkyBlue
            Me.Label57.Location = New System.Drawing.Point(0, 40)
            Me.Label57.Name = "Label57"
            Me.Label57.Size = New System.Drawing.Size(680, 32)
            Me.Label57.TabIndex = 59
            '
            'tbSearch
            '
            Me.tbSearch.Controls.AddRange(New System.Windows.Forms.Control() {Me.searchGrid})
            Me.tbSearch.Location = New System.Drawing.Point(4, 22)
            Me.tbSearch.Name = "tbSearch"
            Me.tbSearch.Size = New System.Drawing.Size(680, 302)
            Me.tbSearch.TabIndex = 7
            Me.tbSearch.Text = "Search"
            '
            'searchGrid
            '
            Me.searchGrid.AlternatingRows = True
            Me.searchGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.searchGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.searchGrid.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.searchGrid.FilterBar = True
            Me.searchGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.searchGrid.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.searchGrid.Location = New System.Drawing.Point(16, 8)
            Me.searchGrid.Name = "searchGrid"
            Me.searchGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.searchGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.searchGrid.PreviewInfo.ZoomFactor = 75
            Me.searchGrid.Size = New System.Drawing.Size(648, 288)
            Me.searchGrid.TabIndex = 0
            Me.searchGrid.Text = "C1TrueDBGrid1"
            Me.searchGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:Aqua;}Selected{ForeColor:HighlightText;BackCol" & _
            "or:Highlight;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeC" & _
            "olor:ControlText;BackColor:Control;}Inactive{ForeColor:InactiveCaptionText;BackC" & _
            "olor:InactiveCaption;}FilterBar{}OddRow{}Footer{}Caption{AlignHorz:Center;}Style" & _
            "25{}Normal{}Style26{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}S" & _
            "tyle24{}Style23{AlignHorz:Near;}Style22{}Style21{}Style20{}RecordSelector{AlignI" & _
            "mage:Center;}Style18{}Style19{}Style2{}Style14{}Style15{}Style16{}Style17{}Style" & _
            "1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.GroupByView Name="""" AlternatingR" & _
            "owStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""1" & _
            "7"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" Def" & _
            "RecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>257</" & _
            "Height><CaptionStyle parent=""Heading"" me=""Style23"" /><EditorStyle parent=""Editor" & _
            """ me=""Style15"" /><EvenRowStyle parent=""EvenRow"" me=""Style21"" /><FilterBarStyle p" & _
            "arent=""FilterBar"" me=""Style26"" /><FooterStyle parent=""Footer"" me=""Style17"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style25"" /><HeadingStyle parent=""Heading"" me=""Style1" & _
            "6"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style20"" /><InactiveStyle pare" & _
            "nt=""Inactive"" me=""Style19"" /><OddRowStyle parent=""OddRow"" me=""Style22"" /><Record" & _
            "SelectorStyle parent=""RecordSelector"" me=""Style24"" /><SelectedStyle parent=""Sele" & _
            "cted"" me=""Style18"" /><Style parent=""Normal"" me=""Style14"" /><ClientRect>0, 29, 64" & _
            "6, 257</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></" & _
            "C1.Win.C1TrueDBGrid.GroupByView></Splits><NamedStyles><Style parent="""" me=""Norma" & _
            "l"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /" & _
            "><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" />" & _
            "<Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Sty" & _
            "le parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><St" & _
            "yle parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" />" & _
            "<Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></N" & _
            "amedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Lay" & _
            "out><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 646, 286</Clien" & _
            "tArea><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent" & _
            "="""" me=""Style2"" /></Blob>"
            '
            'tbLocation
            '
            Me.tbLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnOptions, Me.btnLocation_Update, Me.btnLocation_Save, Me.btnLocation_Cancel, Me.btnLocation_New, Me.LOC_ListBox, Me.LOC_cboCustomer, Me.LOC_txtShippingMemo, Me.LOC_txtMemo, Me.LOC_cboManifestDetail, Me.LOC_cboAfterMarket, Me.LOC_cboCountry, Me.LOC_cboState, Me.LOC_txtEmail, Me.LOC_txtFax, Me.LOC_txtPhone, Me.LOC_txtContact, Me.LOC_txtZip, Me.LOC_txtCity, Me.LOC_txtAddress2, Me.LOC_txtAddress1, Me.LOC_txtName, Me.Label53, Me.Label52, Me.Label51, Me.Label50, Me.Label49, Me.Label48, Me.Label47, Me.Label46, Me.Label45, Me.Label44, Me.Label43, Me.Label42, Me.Label41, Me.Label40, Me.Label39, Me.Label38, Me.LOC_txtCustomer, Me.Label62})
            Me.tbLocation.Location = New System.Drawing.Point(4, 22)
            Me.tbLocation.Name = "tbLocation"
            Me.tbLocation.Size = New System.Drawing.Size(680, 302)
            Me.tbLocation.TabIndex = 2
            Me.tbLocation.Text = "Location"
            '
            'btnOptions
            '
            Me.btnOptions.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnOptions.Location = New System.Drawing.Point(536, 272)
            Me.btnOptions.Name = "btnOptions"
            Me.btnOptions.Size = New System.Drawing.Size(136, 23)
            Me.btnOptions.TabIndex = 0
            Me.btnOptions.TabStop = False
            Me.btnOptions.Text = "Options"
            '
            'btnLocation_Update
            '
            Me.btnLocation_Update.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnLocation_Update.Location = New System.Drawing.Point(592, 8)
            Me.btnLocation_Update.Name = "btnLocation_Update"
            Me.btnLocation_Update.Size = New System.Drawing.Size(80, 24)
            Me.btnLocation_Update.TabIndex = 19
            Me.btnLocation_Update.Text = "Update"
            '
            'btnLocation_Save
            '
            Me.btnLocation_Save.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnLocation_Save.Location = New System.Drawing.Point(504, 8)
            Me.btnLocation_Save.Name = "btnLocation_Save"
            Me.btnLocation_Save.Size = New System.Drawing.Size(80, 24)
            Me.btnLocation_Save.TabIndex = 18
            Me.btnLocation_Save.Text = "Save"
            '
            'btnLocation_Cancel
            '
            Me.btnLocation_Cancel.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnLocation_Cancel.Location = New System.Drawing.Point(416, 8)
            Me.btnLocation_Cancel.Name = "btnLocation_Cancel"
            Me.btnLocation_Cancel.Size = New System.Drawing.Size(80, 24)
            Me.btnLocation_Cancel.TabIndex = 17
            Me.btnLocation_Cancel.Text = "Cancel"
            '
            'btnLocation_New
            '
            Me.btnLocation_New.Location = New System.Drawing.Point(8, 8)
            Me.btnLocation_New.Name = "btnLocation_New"
            Me.btnLocation_New.Size = New System.Drawing.Size(40, 24)
            Me.btnLocation_New.TabIndex = 20
            Me.btnLocation_New.Text = "New"
            '
            'LOC_ListBox
            '
            Me.LOC_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_ListBox.Location = New System.Drawing.Point(8, 80)
            Me.LOC_ListBox.Name = "LOC_ListBox"
            Me.LOC_ListBox.Size = New System.Drawing.Size(176, 212)
            Me.LOC_ListBox.TabIndex = 73
            Me.LOC_ListBox.TabStop = False
            '
            'LOC_cboCustomer
            '
            Me.LOC_cboCustomer.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_cboCustomer.Location = New System.Drawing.Point(96, 48)
            Me.LOC_cboCustomer.Name = "LOC_cboCustomer"
            Me.LOC_cboCustomer.Size = New System.Drawing.Size(392, 20)
            Me.LOC_cboCustomer.TabIndex = 1
            '
            'LOC_txtShippingMemo
            '
            Me.LOC_txtShippingMemo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtShippingMemo.Location = New System.Drawing.Point(536, 192)
            Me.LOC_txtShippingMemo.Multiline = True
            Me.LOC_txtShippingMemo.Name = "LOC_txtShippingMemo"
            Me.LOC_txtShippingMemo.Size = New System.Drawing.Size(136, 72)
            Me.LOC_txtShippingMemo.TabIndex = 16
            Me.LOC_txtShippingMemo.Text = ""
            '
            'LOC_txtMemo
            '
            Me.LOC_txtMemo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtMemo.Location = New System.Drawing.Point(536, 96)
            Me.LOC_txtMemo.Multiline = True
            Me.LOC_txtMemo.Name = "LOC_txtMemo"
            Me.LOC_txtMemo.Size = New System.Drawing.Size(136, 72)
            Me.LOC_txtMemo.TabIndex = 15
            Me.LOC_txtMemo.Text = ""
            '
            'LOC_cboManifestDetail
            '
            Me.LOC_cboManifestDetail.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_cboManifestDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.LOC_cboManifestDetail.Location = New System.Drawing.Point(480, 248)
            Me.LOC_cboManifestDetail.Name = "LOC_cboManifestDetail"
            Me.LOC_cboManifestDetail.Size = New System.Drawing.Size(48, 20)
            Me.LOC_cboManifestDetail.TabIndex = 13
            '
            'LOC_cboAfterMarket
            '
            Me.LOC_cboAfterMarket.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_cboAfterMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.LOC_cboAfterMarket.Location = New System.Drawing.Point(480, 224)
            Me.LOC_cboAfterMarket.Name = "LOC_cboAfterMarket"
            Me.LOC_cboAfterMarket.Size = New System.Drawing.Size(48, 20)
            Me.LOC_cboAfterMarket.TabIndex = 12
            '
            'LOC_cboCountry
            '
            Me.LOC_cboCountry.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.LOC_cboCountry.Location = New System.Drawing.Point(264, 176)
            Me.LOC_cboCountry.Name = "LOC_cboCountry"
            Me.LOC_cboCountry.Size = New System.Drawing.Size(264, 20)
            Me.LOC_cboCountry.TabIndex = 8
            '
            'LOC_cboState
            '
            Me.LOC_cboState.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_cboState.Location = New System.Drawing.Point(392, 152)
            Me.LOC_cboState.Name = "LOC_cboState"
            Me.LOC_cboState.Size = New System.Drawing.Size(48, 20)
            Me.LOC_cboState.TabIndex = 6
            '
            'LOC_txtEmail
            '
            Me.LOC_txtEmail.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtEmail.Location = New System.Drawing.Point(264, 272)
            Me.LOC_txtEmail.Name = "LOC_txtEmail"
            Me.LOC_txtEmail.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtEmail.TabIndex = 14
            Me.LOC_txtEmail.Text = ""
            '
            'LOC_txtFax
            '
            Me.LOC_txtFax.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtFax.Location = New System.Drawing.Point(264, 248)
            Me.LOC_txtFax.Name = "LOC_txtFax"
            Me.LOC_txtFax.Size = New System.Drawing.Size(120, 20)
            Me.LOC_txtFax.TabIndex = 11
            Me.LOC_txtFax.Text = ""
            '
            'LOC_txtPhone
            '
            Me.LOC_txtPhone.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtPhone.Location = New System.Drawing.Point(264, 224)
            Me.LOC_txtPhone.Name = "LOC_txtPhone"
            Me.LOC_txtPhone.Size = New System.Drawing.Size(120, 20)
            Me.LOC_txtPhone.TabIndex = 10
            Me.LOC_txtPhone.Text = ""
            '
            'LOC_txtContact
            '
            Me.LOC_txtContact.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtContact.Location = New System.Drawing.Point(264, 200)
            Me.LOC_txtContact.Name = "LOC_txtContact"
            Me.LOC_txtContact.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtContact.TabIndex = 9
            Me.LOC_txtContact.Text = ""
            '
            'LOC_txtZip
            '
            Me.LOC_txtZip.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtZip.Location = New System.Drawing.Point(464, 152)
            Me.LOC_txtZip.Name = "LOC_txtZip"
            Me.LOC_txtZip.Size = New System.Drawing.Size(62, 20)
            Me.LOC_txtZip.TabIndex = 7
            Me.LOC_txtZip.Text = ""
            '
            'LOC_txtCity
            '
            Me.LOC_txtCity.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtCity.Location = New System.Drawing.Point(264, 152)
            Me.LOC_txtCity.Name = "LOC_txtCity"
            Me.LOC_txtCity.Size = New System.Drawing.Size(96, 20)
            Me.LOC_txtCity.TabIndex = 5
            Me.LOC_txtCity.Text = ""
            '
            'LOC_txtAddress2
            '
            Me.LOC_txtAddress2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtAddress2.Location = New System.Drawing.Point(264, 128)
            Me.LOC_txtAddress2.Name = "LOC_txtAddress2"
            Me.LOC_txtAddress2.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtAddress2.TabIndex = 4
            Me.LOC_txtAddress2.Text = ""
            '
            'LOC_txtAddress1
            '
            Me.LOC_txtAddress1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtAddress1.Location = New System.Drawing.Point(264, 104)
            Me.LOC_txtAddress1.Name = "LOC_txtAddress1"
            Me.LOC_txtAddress1.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtAddress1.TabIndex = 3
            Me.LOC_txtAddress1.Text = ""
            '
            'LOC_txtName
            '
            Me.LOC_txtName.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtName.Location = New System.Drawing.Point(264, 80)
            Me.LOC_txtName.Name = "LOC_txtName"
            Me.LOC_txtName.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtName.TabIndex = 2
            Me.LOC_txtName.Text = ""
            '
            'Label53
            '
            Me.Label53.BackColor = System.Drawing.Color.SkyBlue
            Me.Label53.Location = New System.Drawing.Point(24, 48)
            Me.Label53.Name = "Label53"
            Me.Label53.Size = New System.Drawing.Size(64, 16)
            Me.Label53.TabIndex = 56
            Me.Label53.Text = "Customer:"
            Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label52
            '
            Me.Label52.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label52.Location = New System.Drawing.Point(536, 168)
            Me.Label52.Name = "Label52"
            Me.Label52.Size = New System.Drawing.Size(88, 24)
            Me.Label52.TabIndex = 55
            Me.Label52.Text = "Shipping Memo:"
            Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label51
            '
            Me.Label51.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label51.Location = New System.Drawing.Point(536, 80)
            Me.Label51.Name = "Label51"
            Me.Label51.Size = New System.Drawing.Size(40, 16)
            Me.Label51.TabIndex = 54
            Me.Label51.Text = "Memo:"
            Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label50
            '
            Me.Label50.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label50.Location = New System.Drawing.Point(392, 248)
            Me.Label50.Name = "Label50"
            Me.Label50.Size = New System.Drawing.Size(88, 16)
            Me.Label50.TabIndex = 53
            Me.Label50.Text = "Manifest Detail:"
            Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label49
            '
            Me.Label49.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label49.Location = New System.Drawing.Point(408, 224)
            Me.Label49.Name = "Label49"
            Me.Label49.Size = New System.Drawing.Size(72, 16)
            Me.Label49.TabIndex = 52
            Me.Label49.Text = "After Market:"
            Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label48
            '
            Me.Label48.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label48.Location = New System.Drawing.Point(208, 272)
            Me.Label48.Name = "Label48"
            Me.Label48.Size = New System.Drawing.Size(48, 16)
            Me.Label48.TabIndex = 51
            Me.Label48.Text = "E-Mail:"
            Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label47
            '
            Me.Label47.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label47.Location = New System.Drawing.Point(208, 248)
            Me.Label47.Name = "Label47"
            Me.Label47.Size = New System.Drawing.Size(48, 16)
            Me.Label47.TabIndex = 50
            Me.Label47.Text = "Fax:"
            Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label46
            '
            Me.Label46.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label46.Location = New System.Drawing.Point(208, 224)
            Me.Label46.Name = "Label46"
            Me.Label46.Size = New System.Drawing.Size(48, 16)
            Me.Label46.TabIndex = 49
            Me.Label46.Text = "Phone:"
            Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label45
            '
            Me.Label45.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label45.Location = New System.Drawing.Point(208, 200)
            Me.Label45.Name = "Label45"
            Me.Label45.Size = New System.Drawing.Size(48, 16)
            Me.Label45.TabIndex = 48
            Me.Label45.Text = "Contact:"
            Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label44
            '
            Me.Label44.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label44.Location = New System.Drawing.Point(192, 176)
            Me.Label44.Name = "Label44"
            Me.Label44.Size = New System.Drawing.Size(64, 16)
            Me.Label44.TabIndex = 47
            Me.Label44.Text = "Country:"
            Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label43
            '
            Me.Label43.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label43.Location = New System.Drawing.Point(440, 152)
            Me.Label43.Name = "Label43"
            Me.Label43.Size = New System.Drawing.Size(24, 16)
            Me.Label43.TabIndex = 46
            Me.Label43.Text = "Zip:"
            Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label42
            '
            Me.Label42.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label42.Location = New System.Drawing.Point(360, 152)
            Me.Label42.Name = "Label42"
            Me.Label42.Size = New System.Drawing.Size(40, 16)
            Me.Label42.TabIndex = 45
            Me.Label42.Text = "State:"
            Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label41
            '
            Me.Label41.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label41.Location = New System.Drawing.Point(192, 152)
            Me.Label41.Name = "Label41"
            Me.Label41.Size = New System.Drawing.Size(64, 16)
            Me.Label41.TabIndex = 44
            Me.Label41.Text = "City:"
            Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label40
            '
            Me.Label40.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label40.Location = New System.Drawing.Point(192, 128)
            Me.Label40.Name = "Label40"
            Me.Label40.Size = New System.Drawing.Size(64, 16)
            Me.Label40.TabIndex = 43
            Me.Label40.Text = "Address(2):"
            Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label39
            '
            Me.Label39.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label39.Location = New System.Drawing.Point(192, 104)
            Me.Label39.Name = "Label39"
            Me.Label39.Size = New System.Drawing.Size(64, 16)
            Me.Label39.TabIndex = 42
            Me.Label39.Text = "Address(1):"
            Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label38
            '
            Me.Label38.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label38.Location = New System.Drawing.Point(192, 80)
            Me.Label38.Name = "Label38"
            Me.Label38.Size = New System.Drawing.Size(64, 16)
            Me.Label38.TabIndex = 41
            Me.Label38.Text = "Account #:"
            Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'LOC_txtCustomer
            '
            Me.LOC_txtCustomer.Location = New System.Drawing.Point(96, 48)
            Me.LOC_txtCustomer.Name = "LOC_txtCustomer"
            Me.LOC_txtCustomer.Size = New System.Drawing.Size(320, 20)
            Me.LOC_txtCustomer.TabIndex = 99
            Me.LOC_txtCustomer.TabStop = False
            Me.LOC_txtCustomer.Text = ""
            '
            'Label62
            '
            Me.Label62.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label62.BackColor = System.Drawing.Color.SkyBlue
            Me.Label62.Location = New System.Drawing.Point(0, 40)
            Me.Label62.Name = "Label62"
            Me.Label62.Size = New System.Drawing.Size(680, 32)
            Me.Label62.TabIndex = 78
            '
            'tbCust2Price
            '
            Me.tbCust2Price.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblException, Me.tdbGridExcpt, Me.tdbGrid, Me.btnPrcGroup, Me.btnPricingGroup, Me.CP_cboProduct, Me.Label56, Me.btnCustPrice_UPDATE, Me.btnCustPrice_SAVE, Me.btnCustPrice_CANCEL, Me.btnCustPrice_NEW, Me.Label55, Me.CP_cboPricingGroup, Me.CP_cboCustomer, Me.Label54, Me.Label61})
            Me.tbCust2Price.Location = New System.Drawing.Point(4, 22)
            Me.tbCust2Price.Name = "tbCust2Price"
            Me.tbCust2Price.Size = New System.Drawing.Size(680, 302)
            Me.tbCust2Price.TabIndex = 6
            Me.tbCust2Price.Text = "Cust to Price"
            '
            'lblException
            '
            Me.lblException.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblException.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
            Me.lblException.ForeColor = System.Drawing.Color.White
            Me.lblException.Location = New System.Drawing.Point(392, 160)
            Me.lblException.Name = "lblException"
            Me.lblException.Size = New System.Drawing.Size(280, 16)
            Me.lblException.TabIndex = 75
            Me.lblException.Text = "Exception"
            Me.lblException.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'tdbGridExcpt
            '
            Me.tdbGridExcpt.AlternatingRows = True
            Me.tdbGridExcpt.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tdbGridExcpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdbGridExcpt.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbGridExcpt.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdbGridExcpt.Location = New System.Drawing.Point(392, 176)
            Me.tdbGridExcpt.Name = "tdbGridExcpt"
            Me.tdbGridExcpt.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbGridExcpt.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbGridExcpt.PreviewInfo.ZoomFactor = 75
            Me.tdbGridExcpt.Size = New System.Drawing.Size(280, 88)
            Me.tdbGridExcpt.TabIndex = 74
            Me.tdbGridExcpt.TabStop = False
            Me.tdbGridExcpt.Text = "C1TrueDBGrid1"
            Me.tdbGridExcpt.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Alig" & _
            "nVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" Cap" & _
            "tionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""D" & _
            "ottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGrou" & _
            "p=""1"" HorizontalScrollGroup=""1""><Height>86</Height><CaptionStyle parent=""Style2""" & _
            " me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=" & _
            """EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Foote" & _
            "rStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><" & _
            "HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highlight" & _
            "Row"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle p" & _
            "arent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""St" & _
            "yle11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" m" & _
            "e=""Style1"" /><ClientRect>0, 0, 278, 86</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 278, 86</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" " & _
            "/><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tdbGrid
            '
            Me.tdbGrid.AlternatingRows = True
            Me.tdbGrid.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.tdbGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdbGrid.FilterBar = True
            Me.tdbGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdbGrid.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.tdbGrid.Location = New System.Drawing.Point(8, 160)
            Me.tdbGrid.Name = "tdbGrid"
            Me.tdbGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdbGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdbGrid.PreviewInfo.ZoomFactor = 75
            Me.tdbGrid.Size = New System.Drawing.Size(376, 104)
            Me.tdbGrid.TabIndex = 73
            Me.tdbGrid.TabStop = False
            Me.tdbGrid.Text = "C1TrueDBGrid1"
            Me.tdbGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Back" & _
            "Color:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" Cap" & _
            "tionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True" & _
            """ MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" V" & _
            "erticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>102</Height><CaptionSty" & _
            "le parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Ev" & _
            "enRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=" & _
            """Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group" & _
            """ me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle" & _
            " parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4" & _
            """ /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Reco" & _
            "rdSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style" & _
            " parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 374, 102</ClientRect><BorderSid" & _
            "e>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView" & _
            "></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=" & _
            """Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Ca" & _
            "ption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Sele" & _
            "cted"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highligh" & _
            "tRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow""" & _
            " /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filt" & _
            "erBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertS" & _
            "plits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</Def" & _
            "aultRecSelWidth><ClientArea>0, 0, 374, 102</ClientArea><PrintPageHeaderStyle par" & _
            "ent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnPrcGroup
            '
            Me.btnPrcGroup.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnPrcGroup.Location = New System.Drawing.Point(560, 272)
            Me.btnPrcGroup.Name = "btnPrcGroup"
            Me.btnPrcGroup.Size = New System.Drawing.Size(112, 23)
            Me.btnPrcGroup.TabIndex = 4
            Me.btnPrcGroup.Text = "Pricing Group"
            '
            'btnPricingGroup
            '
            Me.btnPricingGroup.Location = New System.Drawing.Point(360, 328)
            Me.btnPricingGroup.Name = "btnPricingGroup"
            Me.btnPricingGroup.Size = New System.Drawing.Size(112, 23)
            Me.btnPricingGroup.TabIndex = 58
            Me.btnPricingGroup.Text = "Add Pricing Group"
            Me.btnPricingGroup.Visible = False
            '
            'CP_cboProduct
            '
            Me.CP_cboProduct.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.CP_cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CP_cboProduct.Location = New System.Drawing.Point(168, 80)
            Me.CP_cboProduct.Name = "CP_cboProduct"
            Me.CP_cboProduct.Size = New System.Drawing.Size(352, 20)
            Me.CP_cboProduct.TabIndex = 2
            '
            'Label56
            '
            Me.Label56.BackColor = System.Drawing.Color.SkyBlue
            Me.Label56.Location = New System.Drawing.Point(104, 82)
            Me.Label56.Name = "Label56"
            Me.Label56.Size = New System.Drawing.Size(56, 16)
            Me.Label56.TabIndex = 56
            Me.Label56.Text = "Product:"
            Me.Label56.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'btnCustPrice_UPDATE
            '
            Me.btnCustPrice_UPDATE.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCustPrice_UPDATE.Location = New System.Drawing.Point(592, 8)
            Me.btnCustPrice_UPDATE.Name = "btnCustPrice_UPDATE"
            Me.btnCustPrice_UPDATE.Size = New System.Drawing.Size(80, 24)
            Me.btnCustPrice_UPDATE.TabIndex = 7
            Me.btnCustPrice_UPDATE.Text = "Update"
            '
            'btnCustPrice_SAVE
            '
            Me.btnCustPrice_SAVE.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCustPrice_SAVE.Location = New System.Drawing.Point(504, 8)
            Me.btnCustPrice_SAVE.Name = "btnCustPrice_SAVE"
            Me.btnCustPrice_SAVE.Size = New System.Drawing.Size(80, 24)
            Me.btnCustPrice_SAVE.TabIndex = 6
            Me.btnCustPrice_SAVE.Text = "Save"
            '
            'btnCustPrice_CANCEL
            '
            Me.btnCustPrice_CANCEL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCustPrice_CANCEL.Location = New System.Drawing.Point(416, 8)
            Me.btnCustPrice_CANCEL.Name = "btnCustPrice_CANCEL"
            Me.btnCustPrice_CANCEL.Size = New System.Drawing.Size(80, 24)
            Me.btnCustPrice_CANCEL.TabIndex = 5
            Me.btnCustPrice_CANCEL.Text = "Cancel"
            '
            'btnCustPrice_NEW
            '
            Me.btnCustPrice_NEW.Location = New System.Drawing.Point(8, 8)
            Me.btnCustPrice_NEW.Name = "btnCustPrice_NEW"
            Me.btnCustPrice_NEW.Size = New System.Drawing.Size(40, 24)
            Me.btnCustPrice_NEW.TabIndex = 8
            Me.btnCustPrice_NEW.Text = "New"
            '
            'Label55
            '
            Me.Label55.Location = New System.Drawing.Point(24, 128)
            Me.Label55.Name = "Label55"
            Me.Label55.Size = New System.Drawing.Size(80, 16)
            Me.Label55.TabIndex = 24
            Me.Label55.Text = "Pricing Group:"
            Me.Label55.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'CP_cboPricingGroup
            '
            Me.CP_cboPricingGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CP_cboPricingGroup.Location = New System.Drawing.Point(104, 128)
            Me.CP_cboPricingGroup.Name = "CP_cboPricingGroup"
            Me.CP_cboPricingGroup.Size = New System.Drawing.Size(352, 21)
            Me.CP_cboPricingGroup.TabIndex = 3
            '
            'CP_cboCustomer
            '
            Me.CP_cboCustomer.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.CP_cboCustomer.Location = New System.Drawing.Point(168, 56)
            Me.CP_cboCustomer.Name = "CP_cboCustomer"
            Me.CP_cboCustomer.Size = New System.Drawing.Size(352, 20)
            Me.CP_cboCustomer.TabIndex = 1
            '
            'Label54
            '
            Me.Label54.BackColor = System.Drawing.Color.SkyBlue
            Me.Label54.Location = New System.Drawing.Point(104, 58)
            Me.Label54.Name = "Label54"
            Me.Label54.Size = New System.Drawing.Size(64, 16)
            Me.Label54.TabIndex = 21
            Me.Label54.Text = "Customer:"
            Me.Label54.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label61
            '
            Me.Label61.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label61.BackColor = System.Drawing.Color.SkyBlue
            Me.Label61.Location = New System.Drawing.Point(0, 40)
            Me.Label61.Name = "Label61"
            Me.Label61.Size = New System.Drawing.Size(680, 72)
            Me.Label61.TabIndex = 71
            '
            'TabPage1
            '
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPLSave, Me.cboCustomerPreLoad, Me.Label64, Me.GroupBox3, Me.GroupBox5})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(680, 302)
            Me.TabPage1.TabIndex = 8
            Me.TabPage1.Text = "PreLoad"
            '
            'btnPLSave
            '
            Me.btnPLSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPLSave.Location = New System.Drawing.Point(8, 248)
            Me.btnPLSave.Name = "btnPLSave"
            Me.btnPLSave.Size = New System.Drawing.Size(600, 32)
            Me.btnPLSave.TabIndex = 30
            Me.btnPLSave.Text = "SAVE"
            '
            'cboCustomerPreLoad
            '
            Me.cboCustomerPreLoad.Location = New System.Drawing.Point(112, 8)
            Me.cboCustomerPreLoad.Name = "cboCustomerPreLoad"
            Me.cboCustomerPreLoad.Size = New System.Drawing.Size(232, 21)
            Me.cboCustomerPreLoad.TabIndex = 27
            '
            'Label64
            '
            Me.Label64.Location = New System.Drawing.Point(8, 8)
            Me.Label64.Name = "Label64"
            Me.Label64.Size = New System.Drawing.Size(96, 16)
            Me.Label64.TabIndex = 26
            Me.Label64.Text = "Customer Name:"
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPLDefaultSku, Me.chkPO, Me.chkUPC, Me.chkPLCarrier, Me.chkPLWarranty, Me.chkPLPRL, Me.chkPLIP, Me.chkPLDockDate, Me.chkPLquantity, Me.chkPLShipTo, Me.Label65, Me.chkPLSKU, Me.chkPLRAQuantity})
            Me.GroupBox3.Location = New System.Drawing.Point(8, 40)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(208, 200)
            Me.GroupBox3.TabIndex = 28
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Customer Specific"
            '
            'chkPLDefaultSku
            '
            Me.chkPLDefaultSku.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLDefaultSku.Location = New System.Drawing.Point(112, 160)
            Me.chkPLDefaultSku.Name = "chkPLDefaultSku"
            Me.chkPLDefaultSku.Size = New System.Drawing.Size(88, 24)
            Me.chkPLDefaultSku.TabIndex = 14
            Me.chkPLDefaultSku.Text = "Default SKU"
            '
            'chkPO
            '
            Me.chkPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPO.Location = New System.Drawing.Point(112, 136)
            Me.chkPO.Name = "chkPO"
            Me.chkPO.Size = New System.Drawing.Size(88, 24)
            Me.chkPO.TabIndex = 13
            Me.chkPO.Text = "PO Number"
            '
            'chkUPC
            '
            Me.chkUPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkUPC.Location = New System.Drawing.Point(112, 112)
            Me.chkUPC.Name = "chkUPC"
            Me.chkUPC.Size = New System.Drawing.Size(88, 24)
            Me.chkUPC.TabIndex = 12
            Me.chkUPC.Text = "UPC"
            '
            'chkPLCarrier
            '
            Me.chkPLCarrier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLCarrier.Location = New System.Drawing.Point(16, 48)
            Me.chkPLCarrier.Name = "chkPLCarrier"
            Me.chkPLCarrier.Size = New System.Drawing.Size(88, 24)
            Me.chkPLCarrier.TabIndex = 2
            Me.chkPLCarrier.Text = "Carrier"
            '
            'chkPLWarranty
            '
            Me.chkPLWarranty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLWarranty.Location = New System.Drawing.Point(112, 64)
            Me.chkPLWarranty.Name = "chkPLWarranty"
            Me.chkPLWarranty.Size = New System.Drawing.Size(88, 24)
            Me.chkPLWarranty.TabIndex = 9
            Me.chkPLWarranty.Text = "Warranty"
            '
            'chkPLPRL
            '
            Me.chkPLPRL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLPRL.Location = New System.Drawing.Point(16, 120)
            Me.chkPLPRL.Name = "chkPLPRL"
            Me.chkPLPRL.Size = New System.Drawing.Size(88, 24)
            Me.chkPLPRL.TabIndex = 5
            Me.chkPLPRL.Text = "PRL"
            '
            'chkPLIP
            '
            Me.chkPLIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLIP.Location = New System.Drawing.Point(16, 144)
            Me.chkPLIP.Name = "chkPLIP"
            Me.chkPLIP.Size = New System.Drawing.Size(88, 24)
            Me.chkPLIP.TabIndex = 6
            Me.chkPLIP.Text = "IP"
            '
            'chkPLDockDate
            '
            Me.chkPLDockDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLDockDate.Location = New System.Drawing.Point(112, 88)
            Me.chkPLDockDate.Name = "chkPLDockDate"
            Me.chkPLDockDate.Size = New System.Drawing.Size(88, 24)
            Me.chkPLDockDate.TabIndex = 11
            Me.chkPLDockDate.Text = "Dock Date"
            '
            'chkPLquantity
            '
            Me.chkPLquantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLquantity.Location = New System.Drawing.Point(16, 96)
            Me.chkPLquantity.Name = "chkPLquantity"
            Me.chkPLquantity.Size = New System.Drawing.Size(88, 24)
            Me.chkPLquantity.TabIndex = 4
            Me.chkPLquantity.Text = "Quantity"
            '
            'chkPLShipTo
            '
            Me.chkPLShipTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLShipTo.Location = New System.Drawing.Point(16, 72)
            Me.chkPLShipTo.Name = "chkPLShipTo"
            Me.chkPLShipTo.Size = New System.Drawing.Size(88, 24)
            Me.chkPLShipTo.TabIndex = 3
            Me.chkPLShipTo.Text = "Ship To"
            '
            'Label65
            '
            Me.Label65.Location = New System.Drawing.Point(16, 24)
            Me.Label65.Name = "Label65"
            Me.Label65.Size = New System.Drawing.Size(64, 16)
            Me.Label65.TabIndex = 0
            Me.Label65.Text = "SELECTED"
            '
            'chkPLSKU
            '
            Me.chkPLSKU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLSKU.Location = New System.Drawing.Point(112, 40)
            Me.chkPLSKU.Name = "chkPLSKU"
            Me.chkPLSKU.Size = New System.Drawing.Size(88, 24)
            Me.chkPLSKU.TabIndex = 8
            Me.chkPLSKU.Text = "SKU"
            '
            'chkPLRAQuantity
            '
            Me.chkPLRAQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLRAQuantity.Location = New System.Drawing.Point(16, 168)
            Me.chkPLRAQuantity.Name = "chkPLRAQuantity"
            Me.chkPLRAQuantity.Size = New System.Drawing.Size(88, 24)
            Me.chkPLRAQuantity.TabIndex = 7
            Me.chkPLRAQuantity.Text = "RA Quantity"
            '
            'GroupBox5
            '
            Me.GroupBox5.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPLIncIMEI, Me.chkPLCourierTrackIN, Me.Label66, Me.chkPLTransaction, Me.chkPLDateCode, Me.chkPLReturn, Me.chkPLAPC, Me.chkPLMIN, Me.chkPLComplaint, Me.chkPLAirTimeCarrier, Me.chkPLCarrierModel, Me.chkPLTransceiver, Me.chkPLProduct, Me.chkPLPOP})
            Me.GroupBox5.Location = New System.Drawing.Point(224, 40)
            Me.GroupBox5.Name = "GroupBox5"
            Me.GroupBox5.Size = New System.Drawing.Size(384, 200)
            Me.GroupBox5.TabIndex = 29
            Me.GroupBox5.TabStop = False
            Me.GroupBox5.Text = "Device Specific"
            '
            'chkPLIncIMEI
            '
            Me.chkPLIncIMEI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLIncIMEI.Location = New System.Drawing.Point(16, 120)
            Me.chkPLIncIMEI.Name = "chkPLIncIMEI"
            Me.chkPLIncIMEI.Size = New System.Drawing.Size(128, 24)
            Me.chkPLIncIMEI.TabIndex = 15
            Me.chkPLIncIMEI.Text = "Incoming IMEI"
            '
            'chkPLCourierTrackIN
            '
            Me.chkPLCourierTrackIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLCourierTrackIN.Location = New System.Drawing.Point(16, 144)
            Me.chkPLCourierTrackIN.Name = "chkPLCourierTrackIN"
            Me.chkPLCourierTrackIN.Size = New System.Drawing.Size(128, 24)
            Me.chkPLCourierTrackIN.TabIndex = 16
            Me.chkPLCourierTrackIN.Text = "Courier Tracking IN"
            '
            'Label66
            '
            Me.Label66.Location = New System.Drawing.Point(16, 24)
            Me.Label66.Name = "Label66"
            Me.Label66.Size = New System.Drawing.Size(64, 16)
            Me.Label66.TabIndex = 0
            Me.Label66.Text = "SELECTED"
            '
            'chkPLTransaction
            '
            Me.chkPLTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLTransaction.Location = New System.Drawing.Point(144, 72)
            Me.chkPLTransaction.Name = "chkPLTransaction"
            Me.chkPLTransaction.Size = New System.Drawing.Size(128, 24)
            Me.chkPLTransaction.TabIndex = 18
            Me.chkPLTransaction.Text = "Transaction Code"
            '
            'chkPLDateCode
            '
            Me.chkPLDateCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLDateCode.Location = New System.Drawing.Point(16, 48)
            Me.chkPLDateCode.Name = "chkPLDateCode"
            Me.chkPLDateCode.Size = New System.Drawing.Size(128, 24)
            Me.chkPLDateCode.TabIndex = 12
            Me.chkPLDateCode.Text = "Date Code"
            '
            'chkPLReturn
            '
            Me.chkPLReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLReturn.Location = New System.Drawing.Point(272, 96)
            Me.chkPLReturn.Name = "chkPLReturn"
            Me.chkPLReturn.TabIndex = 24
            Me.chkPLReturn.Text = "Return Code"
            '
            'chkPLAPC
            '
            Me.chkPLAPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLAPC.Location = New System.Drawing.Point(16, 96)
            Me.chkPLAPC.Name = "chkPLAPC"
            Me.chkPLAPC.Size = New System.Drawing.Size(128, 24)
            Me.chkPLAPC.TabIndex = 14
            Me.chkPLAPC.Text = "APC Code"
            '
            'chkPLMIN
            '
            Me.chkPLMIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLMIN.Location = New System.Drawing.Point(144, 144)
            Me.chkPLMIN.Name = "chkPLMIN"
            Me.chkPLMIN.Size = New System.Drawing.Size(128, 24)
            Me.chkPLMIN.TabIndex = 21
            Me.chkPLMIN.Text = "MIN Number"
            '
            'chkPLComplaint
            '
            Me.chkPLComplaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLComplaint.Location = New System.Drawing.Point(272, 72)
            Me.chkPLComplaint.Name = "chkPLComplaint"
            Me.chkPLComplaint.TabIndex = 23
            Me.chkPLComplaint.Text = "Complaint Code"
            '
            'chkPLAirTimeCarrier
            '
            Me.chkPLAirTimeCarrier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLAirTimeCarrier.Location = New System.Drawing.Point(144, 48)
            Me.chkPLAirTimeCarrier.Name = "chkPLAirTimeCarrier"
            Me.chkPLAirTimeCarrier.Size = New System.Drawing.Size(128, 24)
            Me.chkPLAirTimeCarrier.TabIndex = 17
            Me.chkPLAirTimeCarrier.Text = "AirTime Carrier Code"
            '
            'chkPLCarrierModel
            '
            Me.chkPLCarrierModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLCarrierModel.Location = New System.Drawing.Point(144, 120)
            Me.chkPLCarrierModel.Name = "chkPLCarrierModel"
            Me.chkPLCarrierModel.Size = New System.Drawing.Size(128, 24)
            Me.chkPLCarrierModel.TabIndex = 20
            Me.chkPLCarrierModel.Text = "Carrier Model Code"
            '
            'chkPLTransceiver
            '
            Me.chkPLTransceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLTransceiver.Location = New System.Drawing.Point(144, 96)
            Me.chkPLTransceiver.Name = "chkPLTransceiver"
            Me.chkPLTransceiver.Size = New System.Drawing.Size(128, 24)
            Me.chkPLTransceiver.TabIndex = 19
            Me.chkPLTransceiver.Text = "Transceiver Code"
            '
            'chkPLProduct
            '
            Me.chkPLProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLProduct.Location = New System.Drawing.Point(272, 48)
            Me.chkPLProduct.Name = "chkPLProduct"
            Me.chkPLProduct.TabIndex = 22
            Me.chkPLProduct.Text = "Product Code"
            '
            'chkPLPOP
            '
            Me.chkPLPOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkPLPOP.Location = New System.Drawing.Point(16, 72)
            Me.chkPLPOP.Name = "chkPLPOP"
            Me.chkPLPOP.Size = New System.Drawing.Size(128, 24)
            Me.chkPLPOP.TabIndex = 13
            Me.chkPLPOP.Text = "Proof of Purchase"
            '
            'btnRefresh
            '
            Me.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRefresh.Location = New System.Drawing.Point(600, 16)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.TabIndex = 22
            Me.btnRefresh.TabStop = False
            Me.btnRefresh.Text = "Refresh"
            '
            'frmCustMaint
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(832, 437)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.ctrlTab, Me.btnUpdate, Me.grpSection, Me.btnNEW, Me.cboSelectCustomer, Me.lblSelectCustomer})
            Me.Name = "frmCustMaint"
            Me.Text = "frmCustMaint"
            Me.grpSection.ResumeLayout(False)
            Me.ctrlTab.ResumeLayout(False)
            Me.tbParent.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.tpgUpdLabor.ResumeLayout(False)
            Me.pnlUpdateLabor.ResumeLayout(False)
            Me.pnlULShipDate.ResumeLayout(False)
            CType(Me.cboULModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboULCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbCustMarkup.ResumeLayout(False)
            Me.GroupBox4.ResumeLayout(False)
            Me.tbCustWrty.ResumeLayout(False)
            Me.tbAggBilling.ResumeLayout(False)
            Me.grpAggregates.ResumeLayout(False)
            CType(Me.gridAggregate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbCreditCard.ResumeLayout(False)
            Me.tbCustomer.ResumeLayout(False)
            Me.tbSearch.ResumeLayout(False)
            CType(Me.searchGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbLocation.ResumeLayout(False)
            Me.tbCust2Price.ResumeLayout(False)
            CType(Me.tdbGridExcpt, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdbGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage1.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox5.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private dsCustomer, dsCustomerMarkup, dsCustomerWarranty, dsParentCo, dsPrcGroup, dsPSSWrtyParts, dsPSSWrtyLabor, dsYesNo, dsPayID, dsState, dsCountry, dsProduct, dsInvMthd, dsCCType, dsSalesPerson, dsCustomer2Price As DataSet
        Private dtLocation As DataTable
        Private sectionTop As Integer = 0
        Private xCount As Integer
        Private r As DataRow
        Private dtGrid As New DataTable()
        Private dtGridExcpt As New DataTable()

        Private dtAggCodes, dtDefinedAggCodes As DataTable
        Private blnAggInsert As Boolean

        Private Sub populateSearchGrid()

            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("Select lparentco.PCo_Name, tcustomer.Cust_Name1, tcustomer.Cust_Name2, tlocation.Loc_Name, tlocation.Loc_Address1, tlocation.Loc_Address2, tlocation.Loc_City, lstate.State_Short, tlocation.Loc_Zip, tlocation.Loc_Contact, tlocation.Loc_Phone, tlocation.Loc_Fax, tlocation.Loc_Email, tcreditcard.creditcard_num from ((((lparentco INNER JOIN tcustomer ON lparentco.PCo_ID = tcustomer.PCo_ID) INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID) INNER JOIN lstate ON tlocation.State_ID = lstate.State_ID) LEFT JOIN tcreditcard ON tcustomer.cust_id = tcreditcard.cust_id) ORDER BY lparentco.PCo_Name, tcustomer.Cust_Name1, tcustomer.Cust_Name2, tlocation.Loc_Name")
            searchGrid.DataSource = dt.DefaultView

            searchGrid.Columns(0).Caption = "Parent Company"
            searchGrid.Columns(1).Caption = "Customer"
            searchGrid.Columns(2).Caption = "Last Name"
            searchGrid.Columns(3).Caption = "Location"
            searchGrid.Columns(4).Caption = "Address"
            searchGrid.Columns(5).Caption = "Address 2"
            searchGrid.Columns(6).Caption = "City"
            searchGrid.Columns(7).Caption = "State"
            searchGrid.Columns(8).Caption = "Zip"
            searchGrid.Columns(9).Caption = "Contact"
            searchGrid.Columns(10).Caption = "Phone"
            searchGrid.Columns(11).Caption = "Fax"
            searchGrid.Columns(12).Caption = "Email"
            searchGrid.Columns(13).Caption = "Credit Card"

        End Sub


        Private Sub frmCustMaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ctrlTab.Visible = False
            System.Windows.Forms.Application.DoEvents()
            '//Hide Insert Values
            PC_txtName.Visible = False
            CUST_txtFName.Visible = False

            HideSections()
            HideAllButtons()
            '//Perform load operations
            populateComboBoxesALL()
            populateCustomerSelect()

            CUST_txtLName.Enabled = False
            ctrlTab.Visible = True
            System.Windows.Forms.Application.DoEvents()

            populateSearchGrid()
            create_dtGrid()
            create_dtGridExcpt()

            '            If ApplicationUser.GetPermission("frmTrayTransfer") > 0 Then
            '            MsgBox(ApplicationUser.GetPermission("frmTrayTransfer"))
            '           End If

            PopulateCustomerPreLoad()
            System.Windows.Forms.Application.DoEvents()
            If Len(Trim(cboSelectCustomer.Text)) > 0 Then
                Dim aIndex As Integer
                With cboCustomerPreLoad
                    For aIndex = 0 To .Items.Count - 1
                        If CType(.Items(aIndex)(1), String).Trim = cboSelectCustomer.Text.Trim Then
                            .SelectedIndex = aIndex
                            Exit For
                        End If
                    Next
                    If aIndex >= .Items.Count Then .SelectedIndex = -1
                End With
            End If

            'Set Special permissions
            If ApplicationUser.GetPermission("UpdateLabor") > 0 Then Me.pnlUpdateLabor.Visible = True Else Me.pnlUpdateLabor.Visible = False
            Me.dtULShipStartDate.Value = Now()
            Me.dtpULShipEndDate.Value = Now
        End Sub


        Private Sub HideAllButtons()

            btnParentCo_NEW.Visible = False
            btnCustPrice_NEW.Visible = False
            btnCustomer_NEW.Visible = False
            btnCustomerMarkup_NEW.Visible = False
            btnCustWrty_NEW.Visible = False
            btnCreditCard_NEW.Visible = False
            'btnLocation_New.Visible = False

            btnParentCo_CANCEL.Visible = False
            btnCustPrice_CANCEL.Visible = False
            btnCustomer_Cancel.Visible = False
            btnCustomerMarkup_Cancel.Visible = False
            btnCustWrty_CANCEL.Visible = False
            btnCreditCard_CANCEL.Visible = False
            btnLocation_Cancel.Visible = False

            btnParentCo_SAVE.Visible = False
            btnCustPrice_SAVE.Visible = False
            btnCustomer_Save.Visible = False
            btnCustomerMarkup_Save.Visible = False
            btnCustWrty_SAVE.Visible = False
            btnCreditCard_SAVE.Visible = False
            btnLocation_Save.Visible = False

            btnParentCo_UPDATE.Visible = False
            btnCustPrice_UPDATE.Visible = False
            btnCustomer_UPDATE.Visible = False
            btnCustomerMarkup_UPDATE.Visible = False
            btnCustWrty_UPDATE.Visible = False
            btnCreditCard_UPDATE.Visible = False
            btnLocation_Update.Visible = False

        End Sub

#Region " Verification of Data "

        Private Function VerifyCreditCard_beforeInsert() As String

            VerifyCreditCard_beforeInsert = ""
            If Len(Trim(CC_cboCustomer.Text)) < 1 Then VerifyCreditCard_beforeInsert += "No Customer Selected." & vbCrLf
            If Len(Trim(CC_cboCCType.Text)) < 1 Then VerifyCreditCard_beforeInsert += "No Credit Card Type Selected." & vbCrLf
            If Len(Trim(CC_txtCCNumber.Text)) < 1 Then VerifyCreditCard_beforeInsert += "No Credit Card Number Defined." & vbCrLf
            If Len(Trim(CC_txtAuthCode.Text)) < 1 Then VerifyCreditCard_beforeInsert += "No Credit Card Authorization Defined." & vbCrLf
            If Len(Trim(CC_txtAuthCode.Text)) > 4 Then VerifyCreditCard_beforeInsert += "Card Authorization Invalid Defined." & vbCrLf
            If Len(Trim(CC_txtExpDate.Text)) < 1 Then VerifyCreditCard_beforeInsert += "No Expiration Date Defined." & vbCrLf
            '//Verify length of number string
            If Len(Trim(CC_txtCCNumber.Text)) > 16 Or Len(CC_txtCCNumber.Text) < 13 Then VerifyCreditCard_beforeInsert += "Length of Credit Card Number is Invalid."

        End Function
        Private Function VerifyParentCo_beforeInsert() As String

            VerifyParentCo_beforeInsert = ""

            If Len(Trim(PC_txtName.Text)) < 1 Then VerifyParentCo_beforeInsert += "No Parent Company Name Defined." & vbCrLf
            If Len(Trim(PC_txtMotoCode.Text)) < 1 Then VerifyParentCo_beforeInsert += "No Moto Code Defined." & vbCrLf
            If Len(Trim(PC_cboPrcGroup.Text)) < 1 Then VerifyParentCo_beforeInsert += "No Pricing Group Defined." & vbCrLf

            If chkEndUser.Checked = True Then
                If Len(Trim(PC_txtMarkUp.Text)) < 1 Then VerifyParentCo_beforeInsert += "No Customer Markup Defined." & vbCrLf
                If Len(Trim(PC_txtRUR.Text)) < 1 Then VerifyParentCo_beforeInsert += "No RUR Value Defined." & vbCrLf
                If Len(Trim(PC_txtNER.Text)) < 1 Then VerifyParentCo_beforeInsert += "No NER Value Defined." & vbCrLf
                If Len(Trim(PC_txtWrtyDays.Text)) < 1 Then VerifyParentCo_beforeInsert += "No Number of Warranty Days Value Defined." & vbCrLf
                If Len(Trim(PC_cboWrtyParts.Text)) < 1 Then VerifyParentCo_beforeInsert += "No Warranty Parts Value Defined." & vbCrLf
                If Len(Trim(PC_cboWrtyLabor.Text)) < 1 Then VerifyParentCo_beforeInsert += "No Warranty Labor Value Defined." & vbCrLf
            End If

        End Function
        Private Function VerifyCustomer_beforeInsert() As String

            VerifyCustomer_beforeInsert = ""

            If Len(Trim(CUST_txtFName.Text)) < 1 Then VerifyCustomer_beforeInsert += "No First Name Defined." & vbCrLf
            '            If Len(Trim(CUST_txtLName.Text)) < 1 Then VerifyCustomer_beforeInsert += "No Last Name Defined." & vbCrLf
            If Len(Trim(CUST_txtRejectDays.Text)) < 1 Then VerifyCustomer_beforeInsert += "No Reject Days Defined." & vbCrLf
            If Len(Trim(CUST_txtRejectTimes.Text)) < 1 Then VerifyCustomer_beforeInsert += "No Reject Times Defined." & vbCrLf
            If Len(Trim(CUST_cboPayID.Text)) < 1 Then VerifyCustomer_beforeInsert += "No Pay ID Defined." & vbCrLf
            If Len(Trim(CUST_cboParentCo.Text)) < 1 Then VerifyCustomer_beforeInsert += "No Parent Company Defined." & vbCrLf
            If Len(Trim(CUST_cboSalesPerson.Text)) < 1 Then VerifyCustomer_beforeInsert += "No Sales Person Defined." & vbCrLf
            'If Len(Trim(CUST_cboPlusParts.Text)) < 1 Then VerifyCustomer_beforeInsert += "Plus Parts is Not Defined." & vbCrLf
            If Len(Trim(CUST_cboRepNonWrty.Text)) < 1 Then VerifyCustomer_beforeInsert += "Repair Non Warranty is Not Defined." & vbCrLf
            If Len(Trim(CUST_cboRepLCD.Text)) < 1 Then VerifyCustomer_beforeInsert += "Replace LCD is Not Defined." & vbCrLf
            If Len(Trim(CUST_cboCrAppRec.Text)) < 1 Then VerifyCustomer_beforeInsert += "Credit Approved Received is Not Defined." & vbCrLf
            If Len(Trim(CUST_cboCrAppShip.Text)) < 1 Then VerifyCustomer_beforeInsert += "Credit Approved Shipping is Not Defined." & vbCrLf
            If Len(Trim(CUST_cboCollSalesTax.Text)) < 1 Then VerifyCustomer_beforeInsert += "Collect Sales Tax is Not Defined." & vbCrLf

        End Function

        Private Function VerifyCustomer2Price_beforeInsert() As String

            VerifyCustomer2Price_beforeInsert = ""

            If Len(Trim(CP_cboCustomer.Text)) < 1 Then VerifyCustomer2Price_beforeInsert += "No Name Defined." & vbCrLf
            If Len(Trim(CP_cboProduct.Text)) < 1 Then VerifyCustomer2Price_beforeInsert += "No Product Defined." & vbCrLf
            If Len(Trim(CP_cboPricingGroup.Text)) < 1 Then VerifyCustomer2Price_beforeInsert += "No Pricing Group Defined." & vbCrLf

        End Function


        Private Function VerifyCustomerMarkup_beforeInsert() As String

            VerifyCustomerMarkup_beforeInsert = ""

            If Len(Trim(CM_cboCustomer.Text)) < 1 Then VerifyCustomerMarkup_beforeInsert += "No Last Name Defined." & vbCrLf
            If Len(Trim(CM_cboProduct.Text)) < 1 Then VerifyCustomerMarkup_beforeInsert += "No Product Defined." & vbCrLf
            'If Len(Trim(CM_txtMarkupInvt.Text)) < 1 Then VerifyCustomerMarkup_beforeInsert += "No Markup Inventory Defined." & vbCrLf
            If Len(Trim(CM_txtRUR.Text)) < 1 Then VerifyCustomerMarkup_beforeInsert += "No RUR Defined." & vbCrLf
            If Len(Trim(CM_txtNER.Text)) < 1 Then VerifyCustomerMarkup_beforeInsert += "No NER Defined." & vbCrLf
            If Len(Trim(CM_txtNTF.Text)) < 1 Then VerifyCustomerMarkup_beforeInsert += "No NTF Defined." & vbCrLf
            If Len(Trim(CM_txtRTM.Text)) < 1 Then VerifyCustomerMarkup_beforeInsert += "No RTM Defined." & vbCrLf
            If Len(Trim(CM_txtCustomer.Text)) < 1 Then VerifyCustomerMarkup_beforeInsert += "No Sales Person Defined." & vbCrLf
            If Len(Trim(CM_cboInvMthdID.Text)) < 1 Then VerifyCustomerMarkup_beforeInsert += "Plus Parts is Not Defined." & vbCrLf

        End Function
        Private Function VerifyCustomerWarranty_beforeInsert() As String

            VerifyCustomerWarranty_beforeInsert = ""

            If Len(Trim(CW_cboCustomer.Text)) < 1 Then VerifyCustomerWarranty_beforeInsert += "No Customer Selected." & vbCrLf
            If Len(Trim(CW_cboProduct.Text)) < 1 Then VerifyCustomerWarranty_beforeInsert += "No Product Selected." & vbCrLf
            If Len(Trim(CW_txtDaysInWrty.Text)) < 1 Then VerifyCustomerWarranty_beforeInsert += "No Days in Warranty Defined." & vbCrLf
            If Len(Trim(CW_cboWrtyParts.Text)) < 1 Then VerifyCustomerWarranty_beforeInsert += "Warranty Parts Not Selected." & vbCrLf
            If Len(Trim(CW_cboWrtyLabor.Text)) < 1 Then VerifyCustomerWarranty_beforeInsert += "Warranty Labor Not Selected." & vbCrLf

        End Function
        Private Function VerifyLocation_beforeInsert() As String

            VerifyLocation_beforeInsert = ""

            If Len(Trim(LOC_txtName.Text)) < 1 Then VerifyLocation_beforeInsert += "No Location Name Defined." & vbCrLf
            If Len(Trim(LOC_txtAddress1.Text)) < 1 Then VerifyLocation_beforeInsert += "No Location Address Line 1 Defined." & vbCrLf
            '//txtAddress2 can be null - NO VERIFY
            If Len(Trim(LOC_txtCity.Text)) < 1 Then VerifyLocation_beforeInsert += "No City Defined." & vbCrLf
            If Len(Trim(LOC_cboState.Text)) < 1 Then VerifyLocation_beforeInsert += "No State Defined." & vbCrLf
            If Len(Trim(LOC_txtZip.Text)) < 1 Then VerifyLocation_beforeInsert += "No Zip Code Defined." & vbCrLf
            If Len(Trim(LOC_cboCountry.Text)) < 1 Then VerifyLocation_beforeInsert += "No Country Defined." & vbCrLf
            '//txtContact can be null - NO VERIFY
            If Len(Trim(LOC_txtPhone.Text)) < 1 Then VerifyLocation_beforeInsert += "No Telephone Number Defined." & vbCrLf
            '//txtFax can be null - NO VERIFY
            '//txtEmail can be null - NO VERIFY
            If Len(Trim(LOC_cboAfterMarket.Text)) < 1 Then VerifyLocation_beforeInsert += "No After Market Value Selected." & vbCrLf
            If Len(Trim(LOC_cboManifestDetail.Text)) < 1 Then VerifyLocation_beforeInsert += "No Manifest Detail Value Selected." & vbCrLf
            '//txtMemo can be null - NO VERIFY
            '//txtShippingMemo can be null - NO VERIFY
            If Len(Trim(LOC_cboCustomer.Text)) < 1 Then VerifyLocation_beforeInsert += "No Customer Selected." & vbCrLf

        End Function
#End Region

#Region " Insert SQL "
        Private Function GeneratePCoSQL_Insert() As String

            Dim tmpPriceGroup As String
            Dim tmpWrtyParts As String
            Dim tmpWrtyLabor As String

            GeneratePCoSQL_Insert = ""

            '//Convert over combo box values to id
            If Len(Trim(PC_cboPrcGroup.Text)) > 0 Then
                For xCount = 0 To dsPrcGroup.Tables("lpricinggroup").Rows.Count - 1
                    r = dsPrcGroup.Tables("lpricinggroup").Rows(xCount)
                    If r("PrcGroup_LDesc") = PC_cboPrcGroup.Text Then
                        tmpPriceGroup = r("PrcGroup_ID")
                        Exit For
                    End If
                Next
            Else
                tmpPriceGroup = "Null"
            End If

            If Len(Trim(PC_cboWrtyParts.Text)) > 0 Then
                For xCount = 0 To dsPSSWrtyParts.Tables("lpsswrtyparts").Rows.Count - 1
                    r = dsPSSWrtyParts.Tables("lpsswrtyparts").Rows(xCount)
                    If r("PSSWrtyParts_Desc") = PC_cboWrtyParts.Text Then
                        tmpWrtyParts = r("PSSWrtyParts_ID")
                        Exit For
                    End If
                Next
            Else
                tmpWrtyParts = "Null"
            End If

            If Len(Trim(PC_cboWrtyLabor.Text)) > 0 Then
                For xCount = 0 To dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows.Count - 1
                    r = dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows(xCount)
                    If r("PSSWrtylabor_Desc") = PC_cboWrtyLabor.Text Then
                        tmpWrtyLabor = r("PSSWrtyLabor_ID")
                        Exit For
                    End If
                Next
            Else
                tmpWrtyLabor = "Null"
            End If

            '           '//Verify all replies have values
            '            If tmpPriceGroup < 1 Or tmpWrtyParts < 1 Or tmpWrtyLabor < 1 Then
            '                '//Throw error message and exit
            '                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
            '                GeneratePCoSQL_Insert = ""
            '                Exit Function
            '            End If


            Dim valEndUser As Integer
            If chkEndUser.Checked = True Then
                valEndUser = 1
            Else
                valEndUser = 0
            End If

            '//Create SQL for return
            Dim sqlFieldList As String
            Dim sqlValueList As String

            If Len(Trim(PC_txtMotoCode.Text)) < 1 Then PC_txtMotoCode.Text = "Null"
            If Len(Trim(PC_txtMarkUp.Text)) < 1 Then PC_txtMarkUp.Text = "Null"
            If Len(Trim(PC_txtRUR.Text)) < 1 Then PC_txtRUR.Text = "Null"
            If Len(Trim(PC_txtNER.Text)) < 1 Then PC_txtNER.Text = "Null"
            If Len(Trim(PC_txtWrtyDays.Text)) < 1 Then PC_txtWrtyDays.Text = "Null"

            sqlFieldList = "(PCo_Name, PCo_MotoCode, PCo_DefMarkUp, PCo_DefRUR, PCo_DefNER, " & _
            "PCo_DefWrtyDays, PSSWrtyParts_ID, PSSWrtyLabor_ID, PrcGroup_ID, PCo_EndUser)"
            sqlValueList = "( '" & PC_txtName.Text & "', '" & _
            PC_txtMotoCode.Text & "', " & _
            PC_txtMarkUp.Text & ", " & _
            PC_txtRUR.Text & ", " & _
            PC_txtNER.Text & ", " & _
            PC_txtWrtyDays.Text & ", " & _
            tmpWrtyParts & ", " & _
            tmpWrtyLabor & ", " & _
            tmpPriceGroup & ", " & _
            valEndUser & ")"

            GeneratePCoSQL_Insert = "INSERT INTO lparentco " & sqlFieldList & " VALUES " & sqlValueList

        End Function
        Private Function GenerateCustMarkupSQL_Insert() As String

            Dim tmpInventoryMethod As String
            Dim tmpPlusParts As String

            GenerateCustMarkupSQL_Insert = ""

            '//Convert over combo box values to id
            If Len(Trim(CM_cboInvMthdID.Text)) > 0 Then
                For xCount = 0 To dsInvMthd.Tables("linvtrymethod").Rows.Count - 1
                    r = dsInvMthd.Tables("linvtrymethod").Rows(xCount)
                    If r("Invtrymdth_Desc") = CM_cboInvMthdID.Text Then
                        tmpInventoryMethod = r("Invtrymdth_ID")
                        Exit For
                    End If
                Next
            Else
                tmpInventoryMethod = "Null"
            End If


            If Len(Trim(CM_cboplusparts.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CM_cboplusparts.Text Then
                        tmpPlusParts = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpPlusParts = "Null"
            End If



            '//Create SQL for return
            Dim tmpcustomer As Int32 = GetCustomerCMID()
            Dim tmpProduct As Int32 = GetProductCMID()

            Dim sqlFieldList As String
            Dim sqlValueList As String

            If Len(Trim(CM_txtRUR.Text)) < 1 Then CM_txtRUR.Text = "Null"
            If Len(Trim(CM_txtNER.Text)) < 1 Then CM_txtNER.Text = "Null"
            If Len(Trim(CM_txtNTF.Text)) < 1 Then CM_txtNTF.Text = "Null"
            If Len(Trim(CM_txtRTM.Text)) < 1 Then CM_txtRTM.Text = "Null"
            If Len(Trim(CM_txtCustomer.Text)) < 1 Then CM_txtCustomer.Text = "Null"
            If Len(Trim(CM_txtMarkupInvt.Text)) < 1 Then CM_txtMarkupInvt.Text = "Null"
            If Len(Trim(CM_cboInvMthdID.Text)) < 1 Then CM_cboInvMthdID.Text = "Null"

            sqlFieldList = "(Markup_RUR, Markup_NER, Markup_NTF, Markup_Cust, Markup_Invt, Cust_ID, " & _
            "Prod_ID, Markup_PlusParts, Invtrymthd_ID, Markup_RTM)"
            sqlValueList = "( " & CM_txtRUR.Text & ", " & _
            CM_txtNER.Text & ", " & _
            CM_txtNTF.Text & ", " & _
            CM_txtCustomer.Text & ", " & _
            CM_txtMarkupInvt.Text & ", " & _
            tmpcustomer & ", " & _
            tmpProduct & ", " & _
            tmpPlusParts & ", " & _
            tmpInventoryMethod & ", " & _
            CM_txtRTM.Text & ")"

            GenerateCustMarkupSQL_Insert = "INSERT INTO tcustmarkup " & sqlFieldList & " VALUES " & sqlValueList

        End Function
        Private Function GenerateCustMarkupSQL_Update() As String


            Dim tmpInventoryMethod As String
            Dim tmpID As Int32
            Dim tmpPlusParts As String

            GenerateCustMarkupSQL_Update = ""

            '//Convert over combo box values to id
            If Len(Trim(CM_cboInvMthdID.Text)) > 0 Then
                For xCount = 0 To dsInvMthd.Tables("linvtrymethod").Rows.Count - 1
                    r = dsInvMthd.Tables("linvtrymethod").Rows(xCount)
                    If r("Invtrymdth_Desc") = CM_cboInvMthdID.Text Then
                        tmpInventoryMethod = r("Invtrymdth_ID")
                        Exit For
                    End If
                Next
            Else
                tmpInventoryMethod = "Null"
            End If

            If Len(Trim(CM_cboplusparts.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CM_cboplusparts.Text Then
                        tmpPlusParts = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpPlusParts = "Null"
            End If

            '//Create SQL for return
            Dim tmpcustomer As Int32 = GetCustomerCMID()
            Dim tmpProduct As Int32 = GetProductCMID()

            Dim drTmp As New PSS.Data.Production.tcustmarkup()
            Dim rTmp As DataRow = drTmp.GetRowByCustProd(tmpcustomer, tmpProduct)
            tmpID = rTmp("Markup_ID")

            Dim sqlFieldList As String
            Dim sqlValueList As String
            Dim strSQl As String

            If Len(Trim(CM_txtRUR.Text)) < 1 Then CM_txtRUR.Text = "Null"
            If Len(Trim(CM_txtNER.Text)) < 1 Then CM_txtNER.Text = "Null"
            If Len(Trim(CM_txtNTF.Text)) < 1 Then CM_txtNTF.Text = "Null"
            If Len(Trim(CM_txtRTM.Text)) < 1 Then CM_txtRTM.Text = "Null"
            If Len(Trim(CM_txtCustomer.Text)) < 1 Then CM_txtCustomer.Text = "Null"
            If Len(Trim(CM_txtMarkupInvt.Text)) < 1 Then CM_txtMarkupInvt.Text = "Null"
            If Len(Trim(CM_cboInvMthdID.Text)) < 1 Then CM_cboInvMthdID.Text = "Null"

            strSQl = "UPDATE tcustmarkup SET " & _
            "Markup_RUR = " & CM_txtRUR.Text & ", " & _
            "Markup_NER = " & CM_txtNER.Text & ", " & _
            "Markup_NTF = " & CM_txtNTF.Text & ", " & _
            "Markup_RTM = " & CM_txtRTM.Text & ", " & _
            "Markup_Cust = " & CM_txtCustomer.Text & ", " & _
            "Markup_Invt = " & CM_txtMarkupInvt.Text & ", " & _
            "Cust_ID = " & tmpcustomer & ", " & _
            "Prod_ID = " & tmpProduct & ", " & _
            "Markup_PlusParts = " & tmpPlusParts & ", " & _
            "Invtrymthd_ID = " & tmpInventoryMethod & " WHERE Markup_ID = " & tmpID

            GenerateCustMarkupSQL_Update = strSQl

        End Function

        Private Function GenerateCustomerSQL_Insert() As String

            Dim tmpPayID As String
            Dim tmpParentCo As String
            Dim tmpSalesPerson As String
            Dim tmpPlusParts As String
            Dim tmpRepNonWrty As String
            Dim tmpRepLCD As String
            Dim tmpCrAppRec As String
            Dim tmpCrAppShip As String
            Dim tmpCollSalesTax As String
            Dim tmpInvoiceDetail As String
            Dim tmpMemo As String
            Dim tmpAggBill As Integer

            GenerateCustomerSQL_Insert = ""

            '//Convert over combo box values to id
            If Len(Trim(CUST_cboPayID.Text)) > 0 Then
                For xCount = 0 To dsPayID.Tables("lpaymethod").Rows.Count - 1
                    r = dsPayID.Tables("lpaymethod").Rows(xCount)
                    If r("Pay_Desc") = CUST_cboPayID.Text Then
                        tmpPayID = r("Pay_ID")
                        Exit For
                    End If
                Next
            Else
                tmpPayID = "Null"
            End If

            If Len(Trim(CUST_cboParentCo.Text)) > 0 Then
                For xCount = 0 To dsParentCo.Tables("lparentco").Rows.Count - 1
                    r = dsParentCo.Tables("lparentco").Rows(xCount)
                    If r("PCo_Name") = CUST_cboParentCo.Text Then
                        tmpParentCo = r("PCo_ID")
                        Exit For
                    End If
                Next
            Else
                tmpParentCo = "Null"
            End If

            If Len(Trim(CUST_txtMemo.Text)) > 0 Then
                tmpMemo = "'" & Trim(CUST_txtMemo.Text) & "'"
            Else
                tmpMemo = "Null"
            End If

            If Len(Trim(CUST_cboSalesPerson.Text)) > 0 Then
                For xCount = 0 To dsSalesPerson.Tables("tslsp").Rows.Count - 1
                    r = dsSalesPerson.Tables("tslsp").Rows(xCount)
                    If r("SlsP_FirstName") = CUST_cboSalesPerson.Text Then
                        tmpSalesPerson = r("SlsP_ID")
                        Exit For
                    End If
                Next
            Else
                tmpSalesPerson = "Null"
            End If

            'If Len(Trim(CUST_cboPlusParts.Text)) > 0 Then
            '    For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
            'r = dsYesNo.Tables("Generic").Rows(xCount)
            'If r("Desc") = CUST_cboPlusParts.Text Then
            'tmpPlusParts = r("Value")
            'Exit For
            'End If
            '    Next
            'Else
            'tmpPlusParts = "Null"
            'End If

            If Len(Trim(CUST_cboRepNonWrty.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboRepNonWrty.Text Then
                        tmpRepNonWrty = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpRepNonWrty = "Null"
            End If

            If Len(Trim(CUST_cboRepLCD.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboRepLCD.Text Then
                        tmpRepLCD = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpRepLCD = "Null"
            End If

            If Len(Trim(CUST_cboInvoiceDetail.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboInvoiceDetail.Text Then
                        tmpInvoiceDetail = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpInvoiceDetail = "Null"
            End If

            If Len(Trim(CUST_cboCrAppRec.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboCrAppRec.Text Then
                        tmpCrAppRec = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpCrAppRec = "Null"
            End If

            If Len(Trim(CUST_cboCrAppShip.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboCrAppShip.Text Then
                        tmpCrAppShip = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpCrAppShip = "Null"
            End If

            If Len(Trim(CUST_cboCollSalesTax.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboCollSalesTax.Text Then
                        tmpCollSalesTax = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpCollSalesTax = "Null"
            End If

            '            '//Verify all replies have values
            '            If tmpPayID < 1 Or tmpParentCo < 1 Or tmpSalesPerson < 1 Or tmpPlusParts < 1 Or tmpRepNonWrty < 1 Or tmpRepLCD < 1 Or tmpCrAppRec < 1 Or tmpCrAppShip < 1 Or tmpCollSalesTax < 1 Then
            '                '//Throw error message and exit
            '                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
            '                GenerateCustomerSQL_Insert = ""
            '                Exit Function
            '            End If'

            Dim tmpCust_Inactive As Integer
            If CUST_chkINACTIVE.Checked = True Then
                tmpCust_Inactive = 1
            Else
                tmpCust_Inactive = 0
            End If


            If chkAggBill.Checked = True Then
                tmpAggBill = 1
                Me.grpAggregates.Visible = True
            Else
                tmpAggBill = 0
                Me.grpAggregates.Visible = False
            End If

            '//Create SQL for return
            Dim sqlFieldList As String
            Dim sqlValueList As String

            sqlFieldList = "(Cust_Name1, Cust_RejectDays, Cust_RejectTimes, Cust_Inactive, " & _
            "Cust_RepairNonWrty, Cust_ReplaceLCD, Cust_CrApproveRec, Cust_CrApproveShip, " & _
            "Cust_CollSalesTax, Pay_ID, PCo_ID, SlsP_ID, Cust_InvoiceDetail, Cust_Memo, Cust_AggBilling)"

            sqlValueList = "( '" & CUST_txtFName.Text & "', " & _
            CUST_txtRejectDays.Text & ", " & _
            CUST_txtRejectTimes.Text & ", " & _
            tmpCust_Inactive & ", " & _
            tmpRepNonWrty & ", " & _
            tmpRepLCD & ", " & _
            tmpCrAppRec & ", " & _
            tmpCrAppShip & ", " & _
            tmpCollSalesTax & ", " & _
            tmpPayID & ", " & _
            tmpParentCo & ", " & _
            tmpSalesPerson & ", " & _
            tmpInvoiceDetail & ", " & _
            tmpMemo & ", " & _
            tmpAggBill & ")"

            GenerateCustomerSQL_Insert = "INSERT INTO tcustomer " & sqlFieldList & " VALUES " & sqlValueList

        End Function



        Private Function GenerateCustomerSQL_Update() As String

            Dim tmpPayID As String
            Dim tmpParentCo As String
            Dim tmpSalesPerson As String
            Dim tmpPlusParts As String
            Dim tmpRepNonWrty As String
            Dim tmpRepLCD As String
            Dim tmpCrAppRec As String
            Dim tmpCrAppShip As String
            Dim tmpCollSalesTax As String
            Dim tmpInvoiceDetail As String
            Dim tmpMemo As String
            Dim tmpAggBill As Integer

            Dim valCustomer As Int32 = GetCustomerID()

            CUST_valCustID.Text = valCustomer
            GenerateCustomerSQL_Update = ""

            '//Convert over combo box values to id
            If Len(Trim(CUST_cboPayID.Text)) > 0 Then
                For xCount = 0 To dsPayID.Tables("lpaymethod").Rows.Count - 1
                    r = dsPayID.Tables("lpaymethod").Rows(xCount)
                    If r("Pay_Desc") = CUST_cboPayID.Text Then
                        tmpPayID = r("Pay_ID")
                        Exit For
                    End If
                Next
            Else
                tmpPayID = "Null"
            End If

            If Len(Trim(CUST_cboParentCo.Text)) > 0 Then
                For xCount = 0 To dsParentCo.Tables("lparentco").Rows.Count - 1
                    r = dsParentCo.Tables("lparentco").Rows(xCount)
                    If r("PCo_Name") = CUST_cboParentCo.Text Then
                        tmpParentCo = r("PCo_ID")
                        Exit For
                    End If
                Next
            Else
                tmpParentCo = "Null"
            End If

            If Len(Trim(CUST_txtMemo.Text)) > 0 Then
                tmpMemo = "'" & Trim(CUST_txtMemo.Text) & "'"
            Else
                tmpMemo = "Null"
            End If

            If Len(Trim(CUST_cboSalesPerson.Text)) > 0 Then
                For xCount = 0 To dsSalesPerson.Tables("tslsp").Rows.Count - 1
                    r = dsSalesPerson.Tables("tslsp").Rows(xCount)
                    If r("SlsP_FirstName") = CUST_cboSalesPerson.Text Then
                        tmpSalesPerson = r("SlsP_ID")
                        Exit For
                    End If
                Next
            Else
                tmpSalesPerson = "Null"
            End If

            'If Len(Trim(CUST_cboPlusParts.Text)) > 0 Then
            '    For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
            'r = dsYesNo.Tables("Generic").Rows(xCount)
            'If r("Desc") = CUST_cboPlusParts.Text Then
            'tmpPlusParts = r("Value")
            'Exit For
            'End If
            '    Next
            'Else
            'tmpPlusParts = "Null"
            'End If

            If Len(Trim(CUST_cboRepNonWrty.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboRepNonWrty.Text Then
                        tmpRepNonWrty = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpRepNonWrty = "Null"
            End If

            If Len(Trim(CUST_cboRepLCD.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboRepLCD.Text Then
                        tmpRepLCD = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpRepLCD = "Null"
            End If

            If Len(Trim(CUST_cboInvoiceDetail.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboInvoiceDetail.Text Then
                        tmpInvoiceDetail = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpInvoiceDetail = "Null"
            End If

            If Len(Trim(CUST_cboCrAppRec.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboCrAppRec.Text Then
                        tmpCrAppRec = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpCrAppRec = "Null"
            End If

            If Len(Trim(CUST_cboCrAppShip.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboCrAppShip.Text Then
                        tmpCrAppShip = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpCrAppShip = "Null"
            End If

            If Len(Trim(CUST_cboCollSalesTax.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = CUST_cboCollSalesTax.Text Then
                        tmpCollSalesTax = r("Value")
                        Exit For
                    End If
                Next
            Else
                tmpCollSalesTax = "Null"
            End If


            Dim tmpCust_Inactive As Integer
            If CUST_chkINACTIVE.Checked = True Then
                tmpCust_Inactive = 1
            Else
                tmpCust_Inactive = 0
            End If

            If chkAggBill.Checked = True Then
                tmpAggBill = 1
            Else
                tmpAggBill = 0
            End If


            '            '//Verify all replies have values
            '            If tmpPayID < 1 Or tmpParentCo < 1 Or tmpSalesPerson < 1 Or tmpPlusParts < 1 Or tmpRepNonWrty < 1 Or tmpRepLCD < 1 Or tmpCrAppRec < 1 Or tmpCrAppShip < 1 Or tmpCollSalesTax < 1 Then
            '                '//Throw error message and exit
            '                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
            '                GenerateCustomerSQL_Insert = ""
            '                Exit Function
            '            End If'

            '//Create SQL for return
            Dim sqlFieldList As String
            Dim sqlValueList As String
            Dim strSQL As String


            strSQL = "UPDATE tcustomer SET " & _
            "Cust_Name1 = '" & CUST_txtFName.Text & "', " & _
            "Cust_RejectDays = " & CUST_txtRejectDays.Text & ", " & _
            "Cust_RejectTimes = " & CUST_txtRejectTimes.Text & ", " & _
            "Cust_RepairNonWrty = " & tmpRepNonWrty & ", " & _
            "Cust_ReplaceLCD = " & tmpRepLCD & ", " & _
            "Cust_CrApproveRec = " & tmpCrAppRec & ", " & _
            "Cust_CrApproveShip = " & tmpCrAppShip & ", " & _
            "Cust_CollSalesTax  = " & tmpCollSalesTax & ", " & _
            "Cust_Inactive = " & tmpCust_Inactive & ", " & _
            "Pay_ID = " & tmpPayID & ", " & _
            "PCo_ID = " & tmpParentCo & ", " & _
            "SlsP_ID = " & tmpSalesPerson & ", " & _
            "Cust_Memo = " & tmpMemo & ", " & _
            "Cust_InvoiceDetail = " & tmpInvoiceDetail & ", " & _
            "Cust_AggBilling = " & tmpAggBill & " WHERE CUST_ID = " & valCustomer

            GenerateCustomerSQL_Update = strSQL

        End Function

        Private Function GenerateLocationSQL_Update() As String


            Dim tmpState As String
            Dim tmpCountry As String
            Dim tmpAfterMarket As String
            Dim tmpManifestDetail As String

            Dim valCustomer As Int32 = GetCustomerIDLoc()
            GenerateLocationSQL_Update = ""

            '//Convert over combo box values to id
            If Len(Trim(LOC_cboState.Text)) > 0 Then
                For xCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                    r = dsState.Tables("lstate").Rows(xCount)
                    If r("State_Short") = LOC_cboState.Text Then
                        tmpState = r("State_ID")
                        Exit For
                    End If
                Next
            End If
            If Len(Trim(LOC_cboCountry.Text)) > 0 Then
                For xCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                    r = dsCountry.Tables("lcountry").Rows(xCount)
                    If r("Cntry_Name") = LOC_cboCountry.Text Then
                        tmpCountry = r("Cntry_ID")
                        Exit For
                    End If
                Next
            End If

            If Len(Trim(LOC_cboAfterMarket.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = LOC_cboAfterMarket.Text Then
                        tmpAfterMarket = r("Value")
                        Exit For
                    End If
                Next
            End If
            If Len(Trim(LOC_cboManifestDetail.Text)) > 0 Then
                For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    r = dsYesNo.Tables("Generic").Rows(xCount)
                    If r("Desc") = LOC_cboManifestDetail.Text Then
                        tmpManifestDetail = r("Value")
                        Exit For
                    End If
                Next
            End If

            If Len(Trim(LOC_txtAddress2.Text)) < 1 Then LOC_txtAddress2.Text = ""
            If Len(Trim(LOC_txtFax.Text)) < 1 Then LOC_txtFax.Text = ""
            If Len(Trim(LOC_txtEmail.Text)) < 1 Then LOC_txtEmail.Text = ""
            If Len(Trim(LOC_txtMemo.Text)) < 1 Then LOC_txtMemo.Text = ""
            If Len(Trim(LOC_txtShippingMemo.Text)) < 1 Then LOC_txtShippingMemo.Text = ""

            '//Create SQL for return
            Dim sqlFieldList As String
            Dim sqlValueList As String
            Dim strSQL As String

            strSQL = "UPDATE tlocation SET " & _
            "Loc_Address1 = '" & LOC_txtAddress1.Text & "', " & _
            "Loc_Address2 = '" & LOC_txtAddress2.Text & "', " & _
            "Loc_City = '" & LOC_txtCity.Text & "', " & _
            "Loc_Zip = '" & LOC_txtZip.Text & "', " & _
            "Loc_Contact = '" & LOC_txtContact.Text & "', " & _
            "Loc_Phone = '" & LOC_txtPhone.Text & "', " & _
            "Loc_Fax = '" & LOC_txtFax.Text & "', " & _
            "Loc_Email  = '" & LOC_txtEmail.Text & "', " & _
            "Loc_Memo = '" & LOC_txtMemo.Text & "', " & _
            "Loc_ShipMemo = '" & LOC_txtShippingMemo.Text & "', " & _
            "Loc_AfterMarket = " & tmpAfterMarket & ", " & _
            "Loc_ManifestDetail = " & tmpManifestDetail & ", " & _
            "State_ID = " & tmpState & ", " & _
            "Cntry_ID = " & tmpCountry & _
            " WHERE Cust_ID = " & valCustomer & " AND Loc_Name = '" & LOC_txtName.Text & "'"

            GenerateLocationSQL_Update = strSQL

        End Function


        Private Function GenerateCustomerMarkupSQL_Insert() As String

            Dim tmpCustomer As Integer
            Dim tmpProduct As Integer
            Dim tmpInvMthdID As Integer

            GenerateCustomerMarkupSQL_Insert = ""

            '//Convert over combo box values to id
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CM_cboCustomer.Text Then
                    tmpCustomer = r("CUST_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                r = dsProduct.Tables("lproduct").Rows(xCount)
                If r("Prod_Desc") = CM_cboProduct.Text Then
                    tmpProduct = r("Prod_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsInvMthd.Tables("linvtrymethod").Rows.Count - 1
                r = dsInvMthd.Tables("linvtrymethod").Rows(xCount)
                If r("invtrymdth_Desc") = CM_cboInvMthdID.Text Then
                    tmpInvMthdID = r("invtrymdth_ID")
                    Exit For
                End If
            Next

            '//Verify all replies have values
            If tmpCustomer < 1 Or tmpProduct < 1 Or tmpInvMthdID Then
                '//Throw error message and exit
                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
                GenerateCustomerMarkupSQL_Insert = ""
                Exit Function
            End If

            '//Create SQL for return
            Dim sqlFieldList As String
            Dim sqlValueList As String

            sqlFieldList = "(Markup_RUR, Markup_NER, Markup_Cust, Markup_Invt, " & _
            "Cust_ID, Prod_ID, Invtrymthd_ID)"

            sqlValueList = "(" & CM_txtRUR.Text & ", " & CM_txtNER.Text & ", " & CM_txtCustomer.Text & ", " & _
            tmpInvMthdID & ", " & _
            tmpCustomer & ", " & _
            tmpProduct & ")"

            GenerateCustomerMarkupSQL_Insert = "INSERT INTO tcustomer " & sqlFieldList & " VALUES " & sqlValueList

        End Function

        Private Function GenerateCustPriceSQL_Insert() As String

            Dim tmpCustomer As Integer
            Dim tmpProduct As Integer
            Dim tmpPrcGroup As Integer

            GenerateCustPriceSQL_Insert = ""

            '//Convert over combo box values to id
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CP_cboCustomer.Text Then
                    tmpCustomer = r("CUST_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                r = dsProduct.Tables("lproduct").Rows(xCount)
                If r("Prod_Desc") = CP_cboProduct.Text Then
                    tmpProduct = r("Prod_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsPrcGroup.Tables("lpricinggroup").Rows.Count - 1
                r = dsPrcGroup.Tables("lpricinggroup").Rows(xCount)
                If r("PrcGroup_LDesc") = CP_cboPricingGroup.Text Then
                    tmpPrcGroup = r("PrcGroup_ID")
                    Exit For
                End If
            Next

            '//Verify all replies have values
            If tmpCustomer < 1 Or tmpProduct < 1 Or tmpPrcGroup < 1 Then
                '//Throw error message and exit
                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
                GenerateCustPriceSQL_Insert = ""
                Exit Function
            End If

            '//Create SQL for return
            Dim sqlFieldList As String
            Dim sqlValueList As String

            sqlFieldList = "(Cust_ID, PrcGroup_ID, Prod_ID)"

            sqlValueList = "(" & tmpCustomer & ", " & tmpPrcGroup & ", " & tmpProduct & ")"

            GenerateCustPriceSQL_Insert = "INSERT INTO tcusttoprice " & sqlFieldList & " VALUES " & sqlValueList

        End Function

        Private Function GenerateCustPriceSQL_Update() As String

            Dim tmpCustomer As Integer
            Dim tmpProduct As Integer
            Dim tmpPrcGroup As Integer

            GenerateCustPriceSQL_Update = ""

            '//Convert over combo box values to id
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CP_cboCustomer.Text Then
                    tmpCustomer = r("CUST_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                r = dsProduct.Tables("lproduct").Rows(xCount)
                If r("Prod_Desc") = CP_cboProduct.Text Then
                    tmpProduct = r("Prod_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsPrcGroup.Tables("lpricinggroup").Rows.Count - 1
                r = dsPrcGroup.Tables("lpricinggroup").Rows(xCount)
                If r("PrcGroup_LDesc") = CP_cboPricingGroup.Text Then
                    tmpPrcGroup = r("PrcGroup_ID")
                    Exit For
                End If
            Next

            '//Verify all replies have values
            If tmpCustomer < 1 Or tmpProduct < 1 Or tmpPrcGroup < 1 Then
                '//Throw error message and exit
                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
                GenerateCustPriceSQL_Update = ""
                Exit Function
            End If

            '//Create SQL for return
            Dim strSQL As String

            strSQL = "UPDATE tcusttoprice SET " & _
            "PrcGroup_ID = " & tmpPrcGroup & _
            " WHERE Cust_ID = " & tmpCustomer & " AND Prod_ID = " & tmpProduct

            GenerateCustPriceSQL_Update = strSQL

        End Function

        Private Function GenerateCreditCardSQL_Insert() As String

            Dim tmpCustomer As Integer
            Dim tmpCCType As Integer

            GenerateCreditCardSQL_Insert = ""

            '//Convert over combo box values to id
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CC_cboCustomer.Text Then
                    tmpCustomer = r("CUST_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsCCType.Tables("lcctype").Rows.Count - 1
                r = dsCCType.Tables("lcctype").Rows(xCount)
                If r("CCType_Desc") = CC_cboCCType.Text Then
                    tmpCCType = r("CCType_ID")
                    Exit For
                End If
            Next


            '//Verify all replies have values
            If tmpCustomer < 1 Or tmpCCType < 1 Then
                '//Throw error message and exit
                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
                GenerateCreditCardSQL_Insert = ""
                Exit Function
            End If

            '//Create SQL for return
            Dim sqlFieldList As String
            Dim sqlValueList As String

            sqlFieldList = "(creditcard_num, creditcard_authcode, creditcard_expdate, ccardtype_id, " & _
            "Cust_ID)"

            sqlValueList = "(" & CC_txtCCNumber.Text & ", '" & CC_txtAuthCode.Text & "', '" & CC_txtExpDate.Text & "', " & tmpCCType & ", " & _
            tmpCustomer & ")"

            GenerateCreditCardSQL_Insert = "INSERT INTO tcreditcard " & sqlFieldList & " VALUES " & sqlValueList

        End Function
        Private Function GenerateCreditCardSQL_Update() As String

            Dim tmpCustomer As Integer
            Dim tmpCCType As Integer

            GenerateCreditCardSQL_Update = ""

            '//Convert over combo box values to id
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CC_cboCustomer.Text Then
                    tmpCustomer = r("CUST_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsCCType.Tables("lcctype").Rows.Count - 1
                r = dsCCType.Tables("lcctype").Rows(xCount)
                If r("CCType_Desc") = CC_cboCCType.Text Then
                    tmpCCType = r("CCType_ID")
                    Exit For
                End If
            Next


            '//Verify all replies have values
            If tmpCustomer < 1 Or tmpCCType < 1 Then
                '//Throw error message and exit
                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
                GenerateCreditCardSQL_Update = ""
                Exit Function
            End If

            '//Create SQL for return
            Dim strSQL As String

            strSQL = "UPDATE tcreditcard SET " & _
            "creditcard_num = " & CC_txtCCNumber.Text & ", " & _
            "creditcard_authcode = '" & CC_txtAuthCode.Text & "', " & _
            "creditcard_expdate = '" & CC_txtExpDate.Text & "', " & _
            "ccardtype_id = " & tmpCCType & _
            " WHERE Cust_ID = " & tmpCustomer

            GenerateCreditCardSQL_Update = strSQL

            clearComboBoxesALL()
            clearDatasets()
            populateComboBoxesALL()


        End Function
        Private Function GenerateLocationSQL_Insert()

            Dim tmpCustomer As Integer
            Dim tmpState As Integer
            Dim tmpCountry As Integer
            Dim tmpAfterMarket As Integer
            Dim tmpManifestDetail As Integer

            GenerateLocationSQL_Insert = ""

            '//Convert over combo box values to id
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = LOC_cboCustomer.Text Then
                    tmpCustomer = r("CUST_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                r = dsState.Tables("lstate").Rows(xCount)
                If r("State_Short") = LOC_cboState.Text Then
                    tmpState = r("State_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                r = dsCountry.Tables("lcountry").Rows(xCount)
                If r("Cntry_Name") = LOC_cboCountry.Text Then
                    tmpCountry = r("Cntry_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                r = dsYesNo.Tables("Generic").Rows(xCount)
                If r("Desc") = LOC_cboAfterMarket.Text Then
                    tmpAfterMarket = r("Value")
                    Exit For
                End If
            Next

            For xCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                r = dsYesNo.Tables("Generic").Rows(xCount)
                If r("Desc") = LOC_cboManifestDetail.Text Then
                    tmpManifestDetail = r("Value")
                    Exit For
                End If
            Next

            '//Verify all replies have values
            If tmpCustomer < 1 Or tmpState < 1 Or tmpCountry < 1 Or Len(tmpAfterMarket) < 1 Or Len(tmpManifestDetail) < 1 Then
                '//Throw error message and exit
                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
                GenerateLocationSQL_Insert = ""
                Exit Function
            End If

            '//Create SQL for return
            Dim sqlFieldList As String
            Dim sqlValueList As String

            If Len(Trim(LOC_txtAddress2.Text)) < 1 Then LOC_txtAddress2.Text = ""
            If Len(Trim(LOC_txtFax.Text)) < 1 Then LOC_txtFax.Text = ""
            If Len(Trim(LOC_txtEmail.Text)) < 1 Then LOC_txtEmail.Text = ""
            If Len(Trim(LOC_txtMemo.Text)) < 1 Then LOC_txtMemo.Text = ""
            If Len(Trim(LOC_txtShippingMemo.Text)) < 1 Then LOC_txtShippingMemo.Text = ""

            sqlFieldList = "(Loc_Name, Loc_Address1, Loc_Address2, Loc_City, " & _
            "Loc_Zip, Loc_Contact, Loc_Phone, Loc_Fax, Loc_Email, Loc_AfterMarket, " & _
            "Loc_ManifestDetail, Loc_Memo, Loc_ShipMemo, State_ID, Cntry_ID, Cust_ID)"

            sqlValueList = "('" & LOC_txtName.Text & "', '" & LOC_txtAddress1.Text & "', '" & LOC_txtAddress2.Text & "', '" & LOC_txtCity.Text & "', '" & _
            LOC_txtZip.Text & "', '" & LOC_txtContact.Text & "', '" & LOC_txtPhone.Text & "', '" & LOC_txtFax.Text & "', '" & LOC_txtEmail.Text & "', " & tmpAfterMarket & ", " & _
            tmpManifestDetail & ", '" & LOC_txtMemo.Text & "', '" & LOC_txtShippingMemo.Text & "', " & tmpState & ", " & tmpCountry & ", " & tmpCustomer & ")"

            GenerateLocationSQL_Insert = "INSERT INTO tlocation " & sqlFieldList & " VALUES " & sqlValueList

        End Function
#End Region

#Region " Update SQL "

        Private Function GeneratePCoSQL_Update() As String

            Dim tmpPriceGroup As String
            Dim tmpWrtyParts As String
            Dim tmpWrtyLabor As String

            Dim valPCoID As Int32 = GetParentCoID()
            PC_valPCOID.Text = valPCoID
            GeneratePCoSQL_Update = ""

            '//Convert over combo box values to id
            If Len(Trim(PC_cboPrcGroup.Text)) > 0 Then
                For xCount = 0 To dsPrcGroup.Tables("lpricinggroup").Rows.Count - 1
                    r = dsPrcGroup.Tables("lpricinggroup").Rows(xCount)
                    If r("PrcGroup_LDesc") = PC_cboPrcGroup.Text Then
                        tmpPriceGroup = r("PrcGroup_ID")
                        '//This is new for Audit Trail
                        PC_valPrcGroup.Text = tmpPriceGroup
                        '//End
                        Exit For
                    End If
                Next
            Else
                tmpPriceGroup = "Null"
            End If

            If Len(Trim(PC_cboWrtyParts.Text)) > 0 Then
                For xCount = 0 To dsPSSWrtyParts.Tables("lpsswrtyparts").Rows.Count - 1
                    r = dsPSSWrtyParts.Tables("lpsswrtyparts").Rows(xCount)
                    If r("PSSWrtyParts_Desc") = PC_cboWrtyParts.Text Then
                        tmpWrtyParts = r("PSSWrtyParts_ID")
                        '//This is new for Audit Trail
                        PC_valWrtyParts.Text = tmpWrtyParts
                        '//End
                        Exit For
                    End If
                Next
            Else
                tmpWrtyParts = "Null"
            End If

            If Len(Trim(PC_cboWrtyLabor.Text)) > 0 Then
                For xCount = 0 To dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows.Count - 1
                    r = dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows(xCount)
                    If r("PSSWrtylabor_Desc") = PC_cboWrtyLabor.Text Then
                        tmpWrtyLabor = r("PSSWrtyLabor_ID")
                        '//This is new for Audit Trail
                        PC_valWrtyLabor.Text = tmpWrtyLabor
                        '//End
                        Exit For
                    End If
                Next
            Else
                tmpWrtyLabor = "Null"
            End If

            '            '//Verify all replies have values
            '            If tmpPriceGroup < 1 Or tmpWrtyParts < 1 Or tmpWrtyLabor < 1 Then
            '                '//Throw error message and exit
            '                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
            '                GeneratePCoSQL_Update = ""
            '                Exit Function
            '            End If

            If Len(Trim(PC_txtMotoCode.Text)) < 1 Then PC_txtMotoCode.Text = "Null"
            If Len(Trim(PC_txtMarkUp.Text)) < 1 Then PC_txtMarkUp.Text = "Null"
            If Len(Trim(PC_txtRUR.Text)) < 1 Then PC_txtRUR.Text = "Null"
            If Len(Trim(PC_txtNER.Text)) < 1 Then PC_txtNER.Text = "Null"
            If Len(Trim(PC_txtWrtyDays.Text)) < 1 Then PC_txtWrtyDays.Text = "Null"

            Dim valEndUser As Integer
            If chkEndUser.Checked = True Then
                valEndUser = 1
                '//This is new for Audit Trail
                PC_valEndUser.Text = valEndUser
                '//End
            Else
                valEndUser = 0
                '//This is new for Audit Trail
                PC_valEndUser.Text = valEndUser
                '//End
            End If

            '//Create SQL for return
            Dim strSQL As String

            strSQL = "UPDATE lparentco SET " & _
            "PCo_MotoCode = '" & PC_txtMotoCode.Text & "', " & _
            "PCo_DefMarkUp = " & PC_txtMarkUp.Text & ", " & _
            "PCo_DefRUR = " & PC_txtRUR.Text & ", " & _
            "PCo_DefNER = " & PC_txtNER.Text & ", " & _
            "PCo_DefWrtyDays = " & PC_txtWrtyDays.Text & ", " & _
            "PSSWrtyParts_ID = " & tmpWrtyParts & ", " & _
            "PSSWrtyLabor_ID = " & tmpWrtyLabor & ", " & _
            "PrcGroup_ID = " & tmpPriceGroup & ", " & _
            "PCo_EndUser = " & valEndUser & _
            " WHERE PCo_ID = " & valPCoID

            GeneratePCoSQL_Update = strSQL


        End Function


#End Region

#Region " Get ID Values "
        Private Function GetParentCoID() As Int32

            GetParentCoID = 0

            For xCount = 0 To dsParentCo.Tables("lparentco").Rows.Count - 1
                r = dsParentCo.Tables("lparentco").Rows(xCount)
                If r("PCo_Name") = PC_cboName.Text Then
                    GetParentCoID = r("PCo_ID")
                    Exit For
                End If
            Next

        End Function
        Private Function GetCustomerID() As Int32

            GetCustomerID = 0

            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CUST_cboName.Text Then
                    GetCustomerID = r("CUST_ID")
                    Exit For
                End If
            Next

        End Function
        Private Function GetCustomerIDLoc() As Int32

            GetCustomerIDLoc = 0

            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = LOC_cboCustomer.Text Then
                    GetCustomerIDLoc = r("CUST_ID")
                    Exit For
                End If
            Next

        End Function
        Private Function GetCustomerCMID() As Int32

            GetCustomerCMID = 0

            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CM_cboCustomer.Text Then
                    GetCustomerCMID = r("CUST_ID")
                    Exit For
                End If
            Next

        End Function


        Private Sub GetSelectCustomer()

            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = cboSelectCustomer.Text Then
                    CustomerSelect = r("CUST_ID")
                    CustomerSelectText = r("Cust_Name1")
                    ParentCoSelect = r("PCo_ID")
                    Exit For
                End If
            Next
            For xCount = 0 To dsParentCo.Tables("lparentco").Rows.Count - 1
                r = dsParentCo.Tables("lparentco").Rows(xCount)
                If r("PCo_ID") = ParentCoSelect Then
                    ParentCoSelectText = r("PCo_Name")
                    Exit For
                End If
            Next

        End Sub
        Private Function GetCustomerIDCC() As Int32

            GetCustomerIDCC = 0

            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CC_cboCustomer.Text Then
                    GetCustomerIDCC = r("CUST_ID")
                    Exit For
                End If
            Next

        End Function
        Private Function GetCustomerCWID() As Int32

            GetCustomerCWID = 0

            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CW_cboCustomer.Text Then
                    GetCustomerCWID = r("CUST_ID")
                    Exit For
                End If
            Next

        End Function
        Private Function GetCustomerCPID() As Int32

            GetCustomerCPID = 0

            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CP_cboCustomer.Text Then
                    GetCustomerCPID = r("CUST_ID")
                    Exit For
                End If
            Next

        End Function
        Private Function GetProductIDWrty() As Int32

            GetProductIDWrty = 0

            For xCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                r = dsProduct.Tables("lproduct").Rows(xCount)
                If r("PROD_Desc") = CW_cboProduct.Text Then
                    GetProductIDWrty = r("PROD_ID")
                    Exit For
                End If
            Next

        End Function
        Private Function GetProductCMID() As Int32

            GetProductCMID = 0

            For xCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                r = dsProduct.Tables("lproduct").Rows(xCount)
                If r("Prod_Desc") = CM_cboProduct.Text Then
                    GetProductCMID = r("Prod_ID")
                    Exit For
                End If
            Next

        End Function
        Private Function GetProductCWID() As Int32

            GetProductCWID = 0

            For xCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                r = dsProduct.Tables("lproduct").Rows(xCount)
                If r("Prod_Desc") = CW_cboProduct.Text Then
                    GetProductCWID = r("Prod_ID")
                    Exit For
                End If
            Next

        End Function
        Private Function GetProductCPID() As Int32

            GetProductCPID = 0

            For xCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                r = dsProduct.Tables("lproduct").Rows(xCount)
                If r("Prod_Desc") = CP_cboProduct.Text Then
                    GetProductCPID = r("Prod_ID")
                    Exit For
                End If
            Next

        End Function

#End Region

#Region " Get Data From Tables "

        Private Function GetParentCoData(ByVal valPCoID As Int32) As Boolean

            Try

                Dim tmpCount As Integer = 0
                Dim tmpCount2 As Integer = 0

                Dim r2 As DataRow

                Dim tmpData As New PSS.Data.Production.lparentco()
                Dim tmpTable As DataTable = tmpData.GetParentCoByID(valPCoID)
                For xCount = 0 To tmpTable.Rows.Count - 1
                    r = tmpTable.Rows(xCount)

                    If IsDBNull(r("PCo_Name")) = False Then
                        For tmpCount = 0 To PC_cboName.Items.Count - 1
                            If PC_cboName.Items(tmpCount) = r("PCo_Name") Then
                                PC_cboName.SelectedIndex = tmpCount
                                Exit For '//New June 18 2003
                            End If
                        Next
                    End If

                    'New June 30 2003
                    If IsDBNull(r("PCo_EndUser")) = False Then
                        If Trim(r("Pco_EndUser")) = 1 Then
                            chkEndUser.Checked = True
                        Else
                            chkEndUser.Checked = False
                        End If
                    End If

                    If IsDBNull(r("PCo_Name")) = False Then PC_txtName.Text = r("PCo_Name")
                    If IsDBNull(r("PCo_MotoCode")) = False Then PC_txtMotoCode.Text = r("PCo_MotoCode")
                    If IsDBNull(r("PCo_DefMarkUp")) = False Then PC_txtMarkUp.Text = r("PCo_DefMarkUp")
                    If IsDBNull(r("PCo_DefRUR")) = False Then PC_txtRUR.Text = r("PCo_DefRUR")
                    If IsDBNull(r("PCo_DefNER")) = False Then PC_txtNER.Text = r("PCo_DefNER")
                    If IsDBNull(r("PCo_DefWrtyDays")) = False Then PC_txtWrtyDays.Text = r("PCo_DefWrtyDays")

                    If IsDBNull(r("PrcGroup_ID")) = False Then
                        For tmpCount = 0 To dsPrcGroup.Tables("lpricinggroup").Rows.Count - 1
                            r2 = dsPrcGroup.Tables("lpricinggroup").Rows(tmpCount)
                            If r2("PrcGroup_ID") = r("PrcGroup_ID") Then
                                'run through combo box and select
                                For tmpCount2 = 0 To PC_cboPrcGroup.Items.Count - 1
                                    If r2("PrcGroup_LDesc") = PC_cboPrcGroup.Items(tmpCount2) Then
                                        PC_cboPrcGroup.SelectedIndex = tmpCount2
                                        Exit For
                                    End If
                                Next
                            End If
                        Next
                    End If

                    If IsDBNull(r("PSSWrtyParts_ID")) = False Then
                        For tmpCount = 0 To dsPSSWrtyParts.Tables("lpsswrtyparts").Rows.Count - 1
                            r2 = dsPSSWrtyParts.Tables("lpsswrtyparts").Rows(tmpCount)
                            If r2("PSSWrtyParts_ID") = r("PSSWrtyParts_ID") Then
                                'run through combo box and select
                                For tmpCount2 = 0 To PC_cboWrtyParts.Items.Count - 1
                                    If r2("PSSWrtyParts_Desc") = PC_cboWrtyParts.Items(tmpCount2) Then
                                        PC_cboWrtyParts.SelectedIndex = tmpCount2
                                        Exit For
                                    End If
                                Next
                            End If
                        Next
                    End If

                    If IsDBNull(r("PSSWrtyLabor_ID")) = False Then

                        For tmpCount = 0 To dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows.Count - 1
                            r2 = dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows(tmpCount)
                            If r2("PSSWrtylabor_ID") = r("PSSWrtyLabor_ID") Then

                                'run through combo box and select
                                For tmpCount2 = 0 To PC_cboWrtyLabor.Items.Count - 1
                                    If r2("PSSWrtyLabor_Desc") = PC_cboWrtyLabor.Items(tmpCount2) Then
                                        PC_cboWrtyLabor.SelectedIndex = tmpCount2
                                        Exit For
                                    End If
                                Next
                            End If
                        Next
                    End If

                Next
                lblParentCoStatus.Text = "LOADED"
                btnParentCo_NEW.Visible = False
                btnParentCo_CANCEL.Visible = False
                btnParentCo_SAVE.Visible = False
                btnParentCo_UPDATE.Visible = True
            Catch exp As Exception
                '//No value for entry
                lblParentCoStatus.Text = "Not Present"
                btnParentCo_NEW.Visible = True
                btnParentCo_CANCEL.Visible = True
                btnParentCo_SAVE.Visible = True
                btnParentCo_UPDATE.Visible = False
            End Try

        End Function

#End Region

#Region " Assign DataSets to Controls"

        Private Sub assignDataSet2cbControl(ByVal ctrl As Control, ByVal ds As DataSet, ByVal tblName As String, ByVal fieldName As String)

            For xCount = 0 To ds.Tables(tblName).Rows.Count - 1
                r = ds.Tables(tblName).Rows(xCount)
                CType(ctrl, ComboBox).Items.Add(r(fieldName))
            Next

        End Sub

#End Region

#Region " Create DataSets"

        Private Sub createCustomerDataSet()
            Try
                Dim tmpCustomer As New PSS.Data.Production.tcustomer()
                dsCustomer = tmpCustomer.GetFirmOnlyList
                tmpCustomer = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createCustomerMarkupDataSet()
            Try
                Dim tmpCustomerMarkup As New PSS.Data.Production.tcustmarkup()
                dsCustomerMarkup = tmpCustomerMarkup.GetData
                tmpCustomerMarkup = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createCustomer2PriceDataSet()
            Try
                Dim tmpCustomer2Price As New PSS.Data.Production.tcusttoprice()
                dsCustomer2Price = tmpCustomer2Price.GetData
                tmpCustomer2Price = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createCustomerWarrantyDataSet()
            Try
                Dim tmpCustomerWarranty As New PSS.Data.Production.tcustwrty()
                dsCustomerWarranty = tmpCustomerWarranty.GetData
                tmpCustomerWarranty = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createParentCoDataSet()
            Try
                Dim tmpParentCo As New PSS.Data.Production.lparentco()
                dsParentCo = tmpParentCo.GetParentCoOrdered
                tmpParentCo = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createPrcGroupDataSet()
            Try
                Dim tmpPrcGroup As New PSS.Data.Production.lpricinggroup()
                dsPrcGroup = tmpPrcGroup.GetPrcGroupOrder
                tmpPrcGroup = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createPSSWrtyPartsDataSet()
            Try
                Dim tmpPSSWrtyParts As New PSS.Data.Production.lpsswrtyparts()
                dsPSSWrtyParts = tmpPSSWrtyParts.GetData
                tmpPSSWrtyParts = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createPSSWrtyLaborDataSet()
            Try
                Dim tmpPSSWrtyLabor As New PSS.Data.Production.lpsswrtylabor()
                dsPSSWrtyLabor = tmpPSSWrtyLabor.GetData
                tmpPSSWrtyLabor = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createPayMethodDataSet()
            Try
                Dim tmpPayID As New PSS.Data.Production.lpaymethod()
                dsPayID = tmpPayID.GetData
                tmpPayID = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createStateDataSet()
            Try
                Dim tmpState As New PSS.Data.Production.lstate()
                dsState = tmpState.GetData
                tmpState = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createCountryDataSet()
            Try
                Dim tmpCountry As New PSS.Data.Production.lcountry()
                dsCountry = tmpCountry.GetData
                tmpCountry = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createProductDataSet()
            Try
                Dim tmpProduct As New PSS.Data.Production.lproduct()
                dsProduct = tmpProduct.GetData
                tmpProduct = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub
        Private Sub createLocationDataSet(ByVal valCustomer As Int32)
            Try
                Dim tmpLocation As New PSS.Data.Production.tlocation()
                dtLocation = tmpLocation.GetRowsByCustomerID(valCustomer)
                tmpLocation = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub
        Private Sub createInventoryMethodDataSet()
            Try
                Dim tmpInventoryMethod As New PSS.Data.Production.linvtrymethod()
                dsInvMthd = tmpInventoryMethod.GetData
                tmpInventoryMethod = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createCCTypeDataSet()
            Try
                Dim tmpCCType As New PSS.Data.Production.lcctype()
                dsCCType = tmpCCType.GetData
                tmpCCType = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createSalesPersonDataSet()
            Try
                Dim tmpSalesPerson As New PSS.Data.Production.tslsp()
                dsSalesPerson = tmpSalesPerson.GetSalesPersonOrder
                tmpSalesPerson = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub createYesNoDataSet()

            Dim tmpRow As DataRow
            Try
                dsYesNo = New DataSet()
                dsYesNo.Tables.Add("Generic")
                dsYesNo.Tables("Generic").Columns.Add("Value")
                dsYesNo.Tables("Generic").Columns.Add("Desc")

                tmpRow = dsYesNo.Tables("Generic").NewRow

                With dsYesNo.Tables("Generic")
                    tmpRow.Item(0) = 1
                    tmpRow.Item(1) = "YES"
                End With
                dsYesNo.Tables("Generic").Rows.Add(tmpRow)
                tmpRow = dsYesNo.Tables("Generic").NewRow
                With dsYesNo.Tables("Generic")
                    tmpRow.Item(0) = 0
                    tmpRow.Item(1) = "NO"
                End With
                dsYesNo.Tables("Generic").Rows.Add(tmpRow)
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

#End Region

#Region " Form Layout Rules"

        Private Function defineTopValue() As Integer

            If sectionTop = 0 Then
                sectionTop = 130 'Starting point for sections
            Else
                sectionTop = sectionTop + 15 'add margin distance
            End If

            defineTopValue = sectionTop

        End Function

        Private Sub clearDatasets()

            '//Clear all data sets
            dsCustomer.Clear()
            dsParentCo.Clear()
            dsPrcGroup.Clear()
            dsPSSWrtyParts.Clear()
            dsPSSWrtyLabor.Clear()
            dsYesNo.Clear()
            dsPayID.Clear()
            dsState.Clear()
            dsCountry.Clear()
            dsProduct.Clear()
            dsInvMthd.Clear()
            dsCCType.Clear()
            dsSalesPerson.Clear()
            dsCustomerMarkup.Clear()

        End Sub


        Private Sub clearCustomerSelect()
            cboSelectCustomer.Items.Clear()
            cboSelectCustomer.Text = ""
        End Sub

        Private Sub clearComboBoxesALL()

            PC_cboName.Items.Clear()
            PC_cboName.Text = ""
            PC_cboPrcGroup.Items.Clear()
            PC_cboPrcGroup.Text = ""
            PC_cboWrtyParts.Items.Clear()
            PC_cboWrtyParts.Text = ""
            PC_cboWrtyLabor.Items.Clear()
            PC_cboWrtyLabor.Text = ""
            CUST_cboParentCo.Items.Clear()
            CUST_cboParentCo.Text = ""
            CUST_cboName.Items.Clear()
            CUST_cboName.Text = ""
            CUST_cboPlusParts.Items.Clear()
            CUST_cboPlusParts.Text = ""
            CUST_cboRepNonWrty.Items.Clear()
            CUST_cboRepNonWrty.Text = ""
            CUST_cboRepLCD.Items.Clear()
            CUST_cboRepLCD.Text = ""
            CUST_cboCrAppRec.Items.Clear()
            CUST_cboCrAppRec.Text = ""
            CUST_cboCrAppShip.Items.Clear()
            CUST_cboCrAppShip.Text = ""
            CUST_cboCollSalesTax.Items.Clear()
            CUST_cboCollSalesTax.Text = ""
            CUST_cboPayID.Items.Clear()
            CUST_cboPayID.Text = ""
            CUST_cboSalesPerson.Items.Clear()
            CUST_cboSalesPerson.Text = ""
            CUST_cboInvoiceDetail.Items.Clear()
            CUST_cboInvoiceDetail.Text = ""
            LOC_cboState.Items.Clear()
            LOC_cboState.Text = ""
            LOC_cboCountry.Items.Clear()
            LOC_cboCountry.Text = ""
            LOC_cboAfterMarket.Items.Clear()
            LOC_cboAfterMarket.Text = ""
            LOC_cboManifestDetail.Items.Clear()
            LOC_cboManifestDetail.Text = ""
            LOC_cboCustomer.Items.Clear()
            LOC_cboCustomer.Text = ""
            CM_cboCustomer.Items.Clear()
            CM_cboCustomer.Text = ""
            CM_cboProduct.Items.Clear()
            CM_cboProduct.Text = ""
            CM_cboInvMthdID.Items.Clear()
            CM_cboInvMthdID.Text = ""
            CM_cboplusparts.Items.Clear()
            CM_cboplusparts.Text = ""
            CW_cboCustomer.Items.Clear()
            CW_cboCustomer.Text = ""
            CW_cboProduct.Items.Clear()
            CW_cboProduct.Text = ""
            CW_cboWrtyParts.Items.Clear()
            CW_cboWrtyParts.Text = ""
            CW_cboWrtyLabor.Items.Clear()
            CW_cboWrtyLabor.Text = ""
            CC_cboCustomer.Items.Clear()
            CC_cboCustomer.Text = ""
            CC_cboCCType.Items.Clear()
            CC_cboCCType.Text = ""
            CP_cboCustomer.Items.Clear()
            CP_cboCustomer.Text = ""
            CP_cboPricingGroup.Items.Clear()
            CP_cboPricingGroup.Text = ""
            CP_cboProduct.Items.Clear()
            CP_cboProduct.Text = ""

        End Sub

        Private Sub populateCustomerSelect()
            assignDataSet2cbControl(cboSelectCustomer, dsCustomer, "tcustomer", "cust_name1")
        End Sub


        Private Sub populateComboBoxesALL()

            createCustomerDataSet()
            createParentCoDataSet()
            createPrcGroupDataSet()
            createPSSWrtyPartsDataSet()
            createPSSWrtyLaborDataSet()
            createYesNoDataSet()
            createPayMethodDataSet()
            createStateDataSet()
            createCountryDataSet()
            createProductDataSet()
            createInventoryMethodDataSet()
            createCCTypeDataSet()
            createSalesPersonDataSet()
            createCustomerMarkupDataSet()
            createCustomerWarrantyDataSet()
            createCustomer2PriceDataSet()
            'createLocationDataSet()

            assignDataSet2cbControl(PC_cboName, dsParentCo, "lparentco", "PCo_Name")
            assignDataSet2cbControl(PC_cboPrcGroup, dsPrcGroup, "lpricinggroup", "PrcGroup_LDesc")
            assignDataSet2cbControl(PC_cboWrtyParts, dsPSSWrtyParts, "lpsswrtyparts", "PSSWrtyParts_Desc")
            assignDataSet2cbControl(PC_cboWrtyLabor, dsPSSWrtyLabor, "lpsswrtylabor", "PSSWrtyLabor_Desc")
            assignDataSet2cbControl(CUST_cboParentCo, dsParentCo, "lparentco", "PCo_Name")
            assignDataSet2cbControl(CUST_cboName, dsCustomer, "tcustomer", "cust_name1")
            assignDataSet2cbControl(CUST_cboPlusParts, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboRepNonWrty, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboRepLCD, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboCrAppRec, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboCrAppShip, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboCollSalesTax, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboPayID, dsPayID, "lpaymethod", "Pay_Desc")
            assignDataSet2cbControl(CUST_cboSalesPerson, dsSalesPerson, "tslsp", "SlsP_FirstName")
            assignDataSet2cbControl(CUST_cboInvoiceDetail, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(LOC_cboState, dsState, "lstate", "State_Short")
            assignDataSet2cbControl(LOC_cboCountry, dsCountry, "lcountry", "Cntry_Name")
            assignDataSet2cbControl(LOC_cboAfterMarket, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(LOC_cboManifestDetail, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(LOC_cboCustomer, dsCustomer, "tcustomer", "cust_name1")
            assignDataSet2cbControl(CM_cboCustomer, dsCustomer, "tcustomer", "cust_name1")
            assignDataSet2cbControl(CM_cboProduct, dsProduct, "lproduct", "Prod_Desc")
            assignDataSet2cbControl(CM_cboInvMthdID, dsInvMthd, "linvtrymethod", "InvtryMdth_Desc")
            assignDataSet2cbControl(CM_cboplusparts, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CW_cboCustomer, dsCustomer, "tcustomer", "cust_name1")
            assignDataSet2cbControl(CW_cboProduct, dsProduct, "lproduct", "Prod_Desc")
            assignDataSet2cbControl(CW_cboWrtyParts, dsPSSWrtyParts, "lpsswrtyparts", "PSSWrtyParts_Desc")
            assignDataSet2cbControl(CW_cboWrtyLabor, dsPSSWrtyLabor, "lpsswrtylabor", "PSSWrtyLabor_Desc")
            assignDataSet2cbControl(CC_cboCustomer, dsCustomer, "tcustomer", "cust_name1")
            assignDataSet2cbControl(CC_cboCCType, dsCCType, "lcctype", "CCType_Desc")
            assignDataSet2cbControl(CP_cboCustomer, dsCustomer, "tcustomer", "cust_name1")
            assignDataSet2cbControl(CP_cboPricingGroup, dsPrcGroup, "lpricinggroup", "PrcGroup_LDesc")
            assignDataSet2cbControl(CP_cboProduct, dsProduct, "lproduct", "Prod_Desc")

        End Sub

        Private Sub HideSections()


            sectionTop = 0

        End Sub

#End Region

#Region " Form buttons click events"

        Private Sub btnParentCo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            openParent()

        End Sub

        Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            openCustomer()

        End Sub

        Private Sub btnWarranty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            openWarranty()

        End Sub
        Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            openLocation()

        End Sub

        Private Sub btnMarkup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            openMarkup()

        End Sub

        Private Sub btnCreditCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            openCreditCard()

        End Sub

        Private Sub btnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            HideSections()

            openParent()
            openCustomer()
            openLocation()
            openMarkup()
            openWarranty()
            openCreditCard()
            openCust2Price()

        End Sub

        Private Sub btnSome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            HideSections()

            openParent()
            openCustomer()
            openLocation()

        End Sub

        Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            HideSections()

        End Sub

#End Region

#Region " Opening Section Code"

        Private Sub openParent()
        End Sub

        Private Sub openCustomer()
        End Sub

        Private Sub openWarranty()
        End Sub

        Private Sub openLocation()
        End Sub

        Private Sub openMarkup()
        End Sub

        Private Sub openCreditCard()
        End Sub

        Private Sub openCust2Price()
        End Sub

#End Region

#Region " Parent Company Section"

#Region " Form Specific "

        Private Sub ClearParentCoFields()

            PC_txtName.Text = ""
            'PC_cboName.Text = ""
            'PC_cboName.Items.Clear()
            PC_txtMotoCode.Text = ""
            '            PC_cboPrcGroup.SelectedIndex = 0
            PC_cboPrcGroup.Text = ""
            PC_txtMarkUp.Text = ""
            PC_txtRUR.Text = ""
            PC_txtNER.Text = ""
            PC_txtWrtyDays.Text = ""
            '            PC_cboWrtyParts.SelectedIndex = 0
            PC_cboWrtyParts.Text = ""
            '            PC_cboWrtyLabor.SelectedIndex = 0
            PC_cboWrtyLabor.Text = ""

            PC_cboPrcGroup.Items.Clear()
            PC_cboWrtyParts.Items.Clear()
            PC_cboWrtyLabor.Items.Clear()

            assignDataSet2cbControl(PC_cboPrcGroup, dsPrcGroup, "lpricinggroup", "PrcGroup_LDesc")
            assignDataSet2cbControl(PC_cboWrtyParts, dsPSSWrtyParts, "lpsswrtyparts", "PSSWrtyParts_Desc")
            assignDataSet2cbControl(PC_cboWrtyLabor, dsPSSWrtyLabor, "lpsswrtylabor", "PSSWrtyLabor_Desc")

        End Sub


#End Region

#Region " Form Button Specific "

        Private Sub btnParentCo_NEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub btnParentCo_SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub btnParentCo_CANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End Sub

#End Region

#Region " Data Specific "




        Private Sub refreshParentCoList()

            Dim strOldParentCo As String
            strOldParentCo = PC_cboName.Text

            'ClearParentCoFields()
            dsParentCo.Tables("lparentco").Rows.Clear()
            PC_cboName.Text = ""
            PC_cboName.Items.Clear()
            CUST_cboParentCo.Text = ""
            CUST_cboParentCo.Items.Clear()

            createParentCoDataSet()
            assignDataSet2cbControl(PC_cboName, dsParentCo, "lparentco", "PCo_Name")
            assignDataSet2cbControl(CUST_cboParentCo, dsParentCo, "lparentco", "PCo_Name")

            '//Parent Company Name
            For xCount = 0 To PC_cboName.Items.Count - 1
                If PC_cboName.Items(xCount) = Trim(strOldParentCo) Then
                    PC_cboName.SelectedIndex = xCount
                    Exit For
                End If
            Next

        End Sub

        Private Sub GetParentCo(ByVal avalID As Int32)

            Dim tmpCount As Integer = 0

            For xCount = 0 To dsParentCo.Tables("lparentco").Rows.Count - 1
                r = dsParentCo.Tables("lparentco").Rows(xCount)
                If r("PCo_ID") = avalID Then
                    '//Get values for page
                    If IsDBNull(r("PCo_MotoCode")) = False Then PC_txtMotoCode.Text = r("PCo_MotoCode")
                    If IsDBNull(r("PCo_DefMarkUp")) = False Then PC_txtMarkUp.Text = r("PCo_DefMarkUp")
                    If IsDBNull(r("PCo_DefRUR")) = False Then PC_txtRUR.Text = r("PCo_DefRUR")
                    If IsDBNull(r("PCo_DefNER")) = False Then PC_txtNER.Text = r("PCo_DefNER")
                    If IsDBNull(r("PCo_DefWrtyDays")) = False Then PC_txtWrtyDays.Text = r("PCo_DefWrtyDays")

                    '//Pricing Group
                    Dim rNew As DataRow
                    Dim zCount As Integer = 0
                    For tmpCount = 0 To dsPrcGroup.Tables("lpricinggroup").Rows.Count - 1
                        rNew = dsPrcGroup.Tables("lpricinggroup").Rows(tmpCount)
                        If rNew("prcGroup_ID") = r("PrcGroup_ID") Then
                            PC_cboPrcGroup.SelectedIndex = tmpCount
                            Exit For
                        End If
                    Next
                    '//Warranty Parts
                    For tmpCount = 0 To dsPSSWrtyParts.Tables("lpsswrtyparts").Rows.Count - 1
                        rNew = dsPSSWrtyParts.Tables("lpsswrtyparts").Rows(tmpCount)
                        If IsDBNull(r("PSSWrtyParts_ID")) = False Then
                            If rNew("PSSWrtyParts_ID") = r("PSSWrtyParts_ID") Then
                                For zCount = 0 To PC_cboWrtyParts.Items.Count - 1
                                    If PC_cboWrtyParts.Items(zCount) = rNew("PSSWrtyParts_Desc") Then
                                        PC_cboWrtyParts.SelectedIndex = zCount
                                        Exit For
                                    End If
                                Next
                                Exit For
                            End If
                        End If
                    Next
                    '//Warranty Labor
                    For tmpCount = 0 To dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows.Count - 1
                        rNew = dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows(tmpCount)
                        If IsDBNull(r("PSSWrtyLabor_ID")) = False Then
                            If rNew("PSSWrtyLabor_ID") = r("PSSWrtyLabor_ID") Then
                                PC_cboWrtyLabor.SelectedItem = tmpCount
                                For zCount = 0 To PC_cboWrtyLabor.Items.Count - 1
                                    If PC_cboWrtyLabor.Items(zCount) = rNew("PSSWrtyLabor_Desc") Then
                                        PC_cboWrtyLabor.SelectedIndex = zCount
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Next
                    Exit For
                End If
            Next

            '//Hide the new elements
            btnParentCo_SAVE.Visible = False
            btnParentCo_CANCEL.Visible = False

        End Sub

#End Region

#End Region

#Region " Customer Section "

#Region " Form Specific Customer "

        Private Sub ClearLocationFields()

            LOC_txtName.Text = ""
            LOC_txtAddress1.Text = ""
            LOC_txtAddress2.Text = ""
            LOC_txtCity.Text = ""
            LOC_cboState.Text = ""
            LOC_txtZip.Text = ""
            LOC_cboCountry.Text = ""
            LOC_txtContact.Text = ""
            LOC_txtPhone.Text = ""
            LOC_txtFax.Text = ""
            LOC_cboAfterMarket.Text = ""
            LOC_cboManifestDetail.Text = ""
            LOC_txtEmail.Text = ""
            LOC_txtMemo.Text = ""
            LOC_txtShippingMemo.Text = ""

        End Sub

        Private Sub ClearCustomerFields()

            CUST_txtFName.Text = ""
            CUST_txtLName.Text = ""
            CUST_txtRejectDays.Text = ""
            CUST_txtRejectTimes.Text = ""
            '            CUST_cboPayID.SelectedIndex = 0
            CUST_cboPayID.Text = ""
            '            CUST_cboName.SelectedIndex = 0
            '            CUST_cboName.Text = ""
            '           CUST_cboParentCo.SelectedIndex = 0
            CUST_cboParentCo.Text = ""
            '          CUST_cboSalesPerson.SelectedIndex = 0
            CUST_cboSalesPerson.Text = ""
            '         CUST_cboPlusParts.SelectedIndex = 0
            CUST_cboPlusParts.Text = ""
            '        CUST_cboRepNonWrty.SelectedIndex = 0
            CUST_cboRepNonWrty.Text = ""
            '       CUST_cboRepLCD.SelectedIndex = 0
            CUST_cboRepLCD.Text = ""
            '      CUST_cboCrAppRec.SelectedIndex = 0
            CUST_cboCrAppRec.Text = ""
            '     CUST_cboCrAppShip.SelectedIndex = 0
            CUST_cboCrAppShip.Text = ""
            '    CUST_cboCollSalesTax.SelectedIndex = 0
            CUST_cboCollSalesTax.Text = ""
            CUST_txtMemo.Text = ""

            CUST_cboParentCo.Items.Clear()
            CUST_cboPlusParts.Items.Clear()
            CUST_cboRepNonWrty.Items.Clear()
            CUST_cboRepLCD.Items.Clear()
            CUST_cboCrAppRec.Items.Clear()
            CUST_cboCrAppShip.Items.Clear()
            CUST_cboCollSalesTax.Items.Clear()
            CUST_cboPayID.Items.Clear()
            CUST_cboSalesPerson.Items.Clear()

            assignDataSet2cbControl(CUST_cboParentCo, dsParentCo, "lparentco", "PCo_Name")
            assignDataSet2cbControl(CUST_cboPlusParts, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboRepNonWrty, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboRepLCD, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboCrAppRec, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboCrAppShip, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboCollSalesTax, dsYesNo, "Generic", "Desc")
            assignDataSet2cbControl(CUST_cboPayID, dsPayID, "lpaymethod", "Pay_Desc")
            assignDataSet2cbControl(CUST_cboSalesPerson, dsSalesPerson, "tslsp", "SlsP_FirstName")

        End Sub



#End Region

#Region " Form Button Specific "

        Private Sub btnCustomer_NEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub btnCustomer_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End Sub

        Private Sub btnCustomer_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

#End Region

#Region " Data Specific Customer "



        Private Sub refreshCustomerList()

            Dim strOldCustomer As String
            strOldCustomer = CUST_cboName.Text

            'ClearCustomerFields()
            dsCustomer.Tables("tcustomer").Rows.Clear()
            CUST_cboName.Text = ""
            CUST_cboName.Items.Clear()
            'CUST_cboParentCo.Text = ""
            'CUST_cboParentCo.Items.Clear()

            createCustomerDataSet()
            assignDataSet2cbControl(CUST_cboName, dsCustomer, "tcustomer", "Cust_Name1")
            'assignDataSet2cbControl(CUST_cboParentCo, dsParentCo, "lparentco", "PCo_Name")

            '//Customer Name
            For xCount = 0 To CUST_cboName.Items.Count - 1
                If CUST_cboName.Items(xCount) = Trim(strOldCustomer) Then
                    CUST_cboName.SelectedIndex = xCount
                    Exit For
                End If
            Next

        End Sub
        Private Sub refreshLocationList()

            Dim strOldCustomer As String
            strOldCustomer = LOC_cboCustomer.Text

            'ClearCustomerFields()
            dsCustomer.Tables("tcustomer").Rows.Clear()
            LOC_cboCustomer.Text = ""
            LOC_cboCustomer.Items.Clear()
            'CUST_cboParentCo.Text = ""
            'CUST_cboParentCo.Items.Clear()

            createCustomerDataSet()
            assignDataSet2cbControl(LOC_cboCustomer, dsCustomer, "tcustomer", "Cust_Name1")
            'assignDataSet2cbControl(CUST_cboParentCo, dsParentCo, "lparentco", "PCo_Name")

            '//Customer Name
            For xCount = 0 To LOC_cboCustomer.Items.Count - 1
                If LOC_cboCustomer.Items(xCount) = Trim(strOldCustomer) Then
                    LOC_cboCustomer.SelectedIndex = xCount
                    Exit For
                End If
            Next

        End Sub

        Private Sub GetCreditCard(ByVal tmpVal As Int32)

            Try
                Dim objMessShip As PSS.Data.Buisness.MessShip
                Dim rCC As DataRow = objMessShip.GetCCbyCustID(tmpVal)
                Dim tmpCount1 As Integer

                If IsDBNull(r("CUST_Name1")) = False Then
                    For tmpCount1 = 0 To CUST_cboName.Items.Count - 1
                        If CC_cboCustomer.Items(tmpCount1) = r("CUST_Name1") Then
                            CC_cboCustomer.SelectedIndex = tmpCount1
                            Exit For
                        End If
                    Next
                End If

                If IsDBNull(Trim(rCC("CreditCard_Num"))) = False Then
                    Me.CC_txtCCNumber.Text = rCC("CreditCard_Num")
                End If

                If IsDBNull(rCC("CreditCard_AuthCode")) = False Then
                    Me.CC_txtAuthCode.Text = rCC("CreditCard_AuthCode")
                End If

                If IsDBNull(Trim(rCC("CreditCard_ExpDate"))) = False Then
                    Me.CC_txtExpDate.Text = rCC("CreditCard_ExpDate")
                End If

                Dim tmpCount, tmpcount2 As Integer
                Dim r2 As DataRow

                If IsDBNull(Trim(rCC("CCardType_ID"))) = False Then
                    CC_cboCCType.SelectedIndex = 0
                    CC_cboCCType.Text = ""
                    For tmpCount = 0 To dsCCType.Tables("lcctype").Rows.Count - 1
                        r2 = dsCCType.Tables("lcctype").Rows(tmpCount)
                        If Trim(r2("CCType_ID")) = Trim(rCC("ccardtype_ID")) Then
                            'run through combo box and select
                            For tmpcount2 = 0 To CC_cboCCType.Items.Count - 1
                                If Trim(r2("CCType_Desc")) = Trim(CC_cboCCType.Items(tmpcount2)) Then
                                    CC_cboCCType.SelectedIndex = tmpcount2
                                    If tmpcount2 = 0 Then
                                        CC_cboCCType.SelectedIndex = 1
                                        CC_cboCCType.SelectedIndex = tmpcount2
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                    Next
                End If
                lblCCStatus.Text = "LOADED"
                btnCreditCard_NEW.Visible = False
                btnCreditCard_CANCEL.Visible = False
                btnCreditCard_SAVE.Visible = False
                btnCreditCard_UPDATE.Visible = True

            Catch exp As Exception
                'CC_cboCustomer.SelectedIndex = 0
                'CC_cboCustomer.Text = ""
                CC_txtCCNumber.Text = ""
                CC_txtExpDate.Text = ""
                'CC_cboCCType.SelectedIndex = 0
                CC_cboCCType.Text = ""
                lblCCStatus.Text = "Not Present"
                btnCreditCard_NEW.Visible = True
                btnCreditCard_CANCEL.Visible = True
                btnCreditCard_SAVE.Visible = True
                btnCreditCard_UPDATE.Visible = False

            End Try

        End Sub

        Private Sub GetLocation(ByVal valCustomer As Int32, ByVal valLocation As String)

            Try
                Dim tmpCount As Integer = 0
                Dim tmpCount1 As Integer

                For xCount = 0 To dtLocation.Rows.Count - 1
                    r = dtLocation.Rows(xCount)

                    If r("LOC_Name") = valLocation Then

                        '                        If IsDBNull(r("CUST_Name1")) = False Then
                        '                            For tmpCount1 = 0 To CUST_cboName.Items.Count - 1
                        '                                If CUST_cboName.Items(tmpCount1) = r("CUST_Name1") Then
                        '                                    CUST_cboName.SelectedIndex = tmpCount1
                        '                                    Exit For
                        '                                End If
                        '                            Next
                        '                        End If

                        '//Get values for page

                        If IsDBNull(r("Loc_Name")) = False Then LOC_txtName.Text = r("Loc_Name")
                        If IsDBNull(r("Loc_Address1")) = False Then LOC_txtAddress1.Text = r("Loc_Address1")
                        If IsDBNull(r("Loc_Address2")) = False Then LOC_txtAddress2.Text = r("Loc_Address2")
                        If IsDBNull(r("Loc_City")) = False Then LOC_txtCity.Text = r("Loc_City")
                        If IsDBNull(r("Loc_Zip")) = False Then LOC_txtZip.Text = r("Loc_Zip")
                        If IsDBNull(r("Loc_Contact")) = False Then LOC_txtContact.Text = r("Loc_Contact")
                        If IsDBNull(r("Loc_Phone")) = False Then LOC_txtPhone.Text = r("Loc_Phone")
                        If IsDBNull(r("Loc_Fax")) = False Then LOC_txtFax.Text = r("Loc_Fax")
                        If IsDBNull(r("Loc_Email")) = False Then LOC_txtEmail.Text = r("Loc_Email")
                        If IsDBNull(r("Loc_Memo")) = False Then LOC_txtMemo.Text = r("Loc_Memo")
                        If IsDBNull(r("Loc_ShipMemo")) = False Then LOC_txtShippingMemo.Text = r("Loc_ShipMemo")

                        '//After Market
                        Dim rNew As DataRow
                        Dim zCount As Integer = 0
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("Loc_AfterMarket")) = False Then
                                If rNew("Value") = r("Loc_AfterMarket") Then
                                    LOC_cboAfterMarket.SelectedItem = tmpCount
                                    For zCount = 0 To LOC_cboAfterMarket.Items.Count - 1
                                        If LOC_cboAfterMarket.Items(zCount) = rNew("Desc") Then
                                            LOC_cboAfterMarket.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//Manifest Detail
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("Loc_ManifestDetail")) = False Then
                                If rNew("Value") = r("Loc_ManifestDetail") Then
                                    LOC_cboManifestDetail.SelectedItem = tmpCount
                                    For zCount = 0 To LOC_cboManifestDetail.Items.Count - 1
                                        If LOC_cboManifestDetail.Items(zCount) = rNew("Desc") Then
                                            LOC_cboManifestDetail.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//State ID
                        For tmpCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                            rNew = dsState.Tables("lstate").Rows(tmpCount)
                            If IsDBNull(r("State_ID")) = False Then
                                If rNew("State_ID") = r("State_ID") Then
                                    For zCount = 0 To LOC_cboState.Items.Count - 1
                                        If LOC_cboState.Items(zCount) = rNew("State_Short") Then
                                            LOC_cboState.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                    Exit For
                                End If
                            End If
                        Next
                        '//Country ID
                        For tmpCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                            rNew = dsCountry.Tables("lcountry").Rows(tmpCount)
                            If IsDBNull(r("Cntry_ID")) = False Then
                                If rNew("Cntry_ID") = r("Cntry_ID") Then
                                    For zCount = 0 To LOC_cboCountry.Items.Count - 1
                                        If LOC_cboCountry.Items(zCount) = rNew("Cntry_Name") Then
                                            LOC_cboCountry.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                Next

                '//Hide the new elements
                btnLocation_Save.Visible = False
                btnLocation_Cancel.Visible = False

                lblLocationStatus.Text = "LOADED"
                'btnLocation_New.Visible = False
                btnLocation_Cancel.Visible = False
                btnLocation_Save.Visible = False
                btnLocation_Update.Visible = True

            Catch exp As Exception
                MsgBox(exp.ToString)


                lblLocationStatus.Text = "Not Present"
                'btnLocation_New.Visible = True
                btnLocation_Cancel.Visible = True
                btnLocation_Save.Visible = True
                btnLocation_Update.Visible = False
            End Try

        End Sub


        Private Sub GetCustomer(ByVal avalID As Int32)

            Try
                Dim tmpCount As Integer = 0
                Dim tmpCount1 As Integer

                For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                    r = dsCustomer.Tables("tcustomer").Rows(xCount)

                    If r("CUST_ID") = avalID Then

                        If IsDBNull(r("CUST_Name1")) = False Then
                            For tmpCount1 = 0 To CUST_cboName.Items.Count - 1
                                If CUST_cboName.Items(tmpCount1) = r("CUST_Name1") Then
                                    CUST_cboName.SelectedIndex = tmpCount1
                                    Exit For
                                End If
                            Next
                        End If

                        '//Get values for page
                        If IsDBNull(r("CUST_Name1")) = False Then CUST_txtFName.Text = r("CUST_Name1")
                        If IsDBNull(r("CUST_Name2")) = False Then CUST_txtLName.Text = r("CUST_Name2")
                        If IsDBNull(r("CUST_RejectDays")) = False Then CUST_txtRejectDays.Text = r("CUST_RejectDays")
                        If IsDBNull(r("CUST_RejectTimes")) = False Then CUST_txtRejectTimes.Text = r("CUST_RejectTimes")
                        If IsDBNull(r("CUST_Memo")) = False Then Me.CUST_txtMemo.Text = r("CUST_Memo")

                        '//Inactive
                        If IsDBNull(r("CUST_Inactive")) = False Then
                            If r("CUST_Inactive") = 1 Then
                                CUST_chkINACTIVE.Checked = True
                            Else
                                CUST_chkINACTIVE.Checked = False
                            End If
                        End If

                        '//Aggregate Billing
                        If IsDBNull(r("CUST_AggBilling")) = False Then
                            If r("CUST_AggBilling") = 1 Then
                                chkAggBill.Checked = True
                                Me.grpAggregates.Visible = True
                            Else
                                chkAggBill.Checked = False
                                Me.grpAggregates.Visible = False
                            End If
                        End If

                        '//Pay ID
                        Dim rNew As DataRow
                        Dim zCount As Integer = 0
                        For tmpCount = 0 To dsPayID.Tables("lpaymethod").Rows.Count - 1
                            rNew = dsPayID.Tables("lpaymethod").Rows(tmpCount)
                            If rNew("Pay_ID") = r("Pay_ID") Then
                                CUST_cboPayID.SelectedIndex = tmpCount
                                Exit For
                            End If
                        Next
                        '//Parent Company
                        For tmpCount = 0 To dsParentCo.Tables("lparentco").Rows.Count - 1
                            rNew = dsParentCo.Tables("lparentco").Rows(tmpCount)
                            If IsDBNull(r("PCo_ID")) = False Then
                                If rNew("PCo_ID") = r("PCo_ID") Then
                                    For zCount = 0 To CUST_cboParentCo.Items.Count - 1
                                        If CUST_cboParentCo.Items(zCount) = rNew("PCo_Name") Then
                                            CUST_cboParentCo.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                    Exit For
                                End If
                            End If
                        Next
                        '//Sales Person
                        For tmpCount = 0 To dsSalesPerson.Tables("tSlsP").Rows.Count - 1
                            rNew = dsSalesPerson.Tables("tSlsP").Rows(tmpCount)
                            If IsDBNull(r("SlsP_ID")) = False Then
                                If rNew("SlsP_ID") = r("SlsP_ID") Then
                                    CUST_cboSalesPerson.SelectedItem = tmpCount
                                    For zCount = 0 To CUST_cboSalesPerson.Items.Count - 1
                                        If CUST_cboSalesPerson.Items(zCount) = rNew("SlsP_FirstName") Then
                                            CUST_cboSalesPerson.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//Plus Parts
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("PlusParts")) = False Then
                                If rNew("Value") = r("PlusParts") Then
                                    CUST_cboPlusParts.SelectedItem = tmpCount
                                    For zCount = 0 To CUST_cboPlusParts.Items.Count - 1
                                        If CUST_cboPlusParts.Items(zCount) = rNew("Desc") Then
                                            CUST_cboPlusParts.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//Repair Non Warranty
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("Cust_RepairNonWrty")) = False Then
                                If rNew("Value") = r("Cust_RepairNonWrty") Then
                                    CUST_cboRepNonWrty.SelectedItem = tmpCount
                                    For zCount = 0 To CUST_cboRepNonWrty.Items.Count - 1
                                        If CUST_cboRepNonWrty.Items(zCount) = rNew("Desc") Then
                                            CUST_cboRepNonWrty.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//Replace LCD
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("Cust_ReplaceLCD")) = False Then
                                If rNew("Value") = r("Cust_ReplaceLCD") Then
                                    CUST_cboRepLCD.SelectedItem = tmpCount
                                    For zCount = 0 To CUST_cboRepLCD.Items.Count - 1
                                        If CUST_cboRepLCD.Items(zCount) = rNew("Desc") Then
                                            CUST_cboRepLCD.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//InvoiceDetail
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("Cust_InvoiceDetail")) = False Then
                                If rNew("Value") = r("Cust_InvoiceDetail") Then
                                    CUST_cboInvoiceDetail.SelectedItem = tmpCount
                                    For zCount = 0 To CUST_cboInvoiceDetail.Items.Count - 1
                                        If CUST_cboInvoiceDetail.Items(zCount) = rNew("Desc") Then
                                            CUST_cboInvoiceDetail.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//Credit Approve Receive
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("Cust_CrApproveRec")) = False Then
                                If rNew("Value") = r("Cust_CrApproveRec") Then
                                    CUST_cboCrAppRec.SelectedItem = tmpCount
                                    For zCount = 0 To CUST_cboCrAppRec.Items.Count - 1
                                        If CUST_cboCrAppRec.Items(zCount) = rNew("Desc") Then
                                            CUST_cboCrAppRec.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//Credit Approve Ship
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("Cust_CrApproveShip")) = False Then
                                If rNew("Value") = r("Cust_CrApproveShip") Then
                                    CUST_cboCrAppShip.SelectedItem = tmpCount
                                    For zCount = 0 To CUST_cboCrAppShip.Items.Count - 1
                                        If CUST_cboCrAppShip.Items(zCount) = rNew("Desc") Then
                                            CUST_cboCrAppShip.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//Collect Sales Tax
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("Cust_CollSalesTax")) = False Then
                                If rNew("Value") = r("Cust_CollSalesTax") Then
                                    CUST_cboCollSalesTax.SelectedItem = tmpCount
                                    For zCount = 0 To CUST_cboCollSalesTax.Items.Count - 1
                                        If CUST_cboCollSalesTax.Items(zCount) = rNew("Desc") Then
                                            CUST_cboCollSalesTax.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        Exit For
                    End If
                Next

                '//Hide the new elements
                btnCustomer_Save.Visible = False
                btnCustomer_Cancel.Visible = False

                lblCustomerStatus.Text = "LOADED"
                btnCustomer_NEW.Visible = False
                btnCustomer_Cancel.Visible = False
                btnCustomer_Save.Visible = False
                btnCustomer_UPDATE.Visible = True

            Catch exp As Exception
                lblCustomerStatus.Text = "Not Present"
                btnCustomer_NEW.Visible = True
                btnCustomer_Cancel.Visible = True
                btnCustomer_Save.Visible = True
                btnCustomer_UPDATE.Visible = False

            End Try

        End Sub

        Private Sub GetCustomerLocation(ByVal avalID As Int32)

            Try
                Dim tmpCount As Integer = 0
                Dim tmpCount1 As Integer

                For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                    r = dsCustomer.Tables("tcustomer").Rows(xCount)

                    If r("CUST_ID") = avalID Then

                        If IsDBNull(r("CUST_Name1")) = False Then
                            For tmpCount1 = 0 To LOC_cboCustomer.Items.Count - 1
                                If LOC_cboCustomer.Items(tmpCount1) = r("CUST_Name1") Then
                                    LOC_cboCustomer.SelectedIndex = tmpCount1
                                    Exit For
                                End If
                            Next
                        End If

                        '//Populate listbox with location names
                        Dim rNew As DataRow
                        Dim zCount As Integer = 0
                        For tmpCount = 0 To dtLocation.Rows.Count - 1
                            rNew = dtLocation.Rows(tmpCount)
                            If rNew("Cust_ID") = avalID Then
                                LOC_ListBox.Items.Add(rNew("Loc_Name"))
                                '                                Exit For
                            End If
                        Next
                    End If
                Next


            Catch exp As Exception
                'MsgBox(exp.ToString)
                lblLocationStatus.Text = "Not Present"
                ' btnCustomer_NEW.Visible = True
                ' btnCustomer_Cancel.Visible = True
                ' btnCustomer_Save.Visible = True
                ' btnCustomer_UPDATE.Visible = False

            End Try

        End Sub
        Private Sub GetCustomerMarkup(ByVal custID As Int32, ByVal prodID As Int32)

            Try
                Dim tmpCount As Integer = 0
                Dim tmpCount1 As Integer
                Dim valType As Boolean

                valType = False


                For xCount = 0 To dsCustomerMarkup.Tables("tcustmarkup").Rows.Count - 1

                    r = dsCustomerMarkup.Tables("tcustmarkup").Rows(xCount)

                    If r("CUST_ID") = custID And r("PROD_ID") = prodID Then

                        valType = True
                        'If IsDBNull(r("CUST_ID")) = False Then
                        'For tmpCount1 = 0 To CM_cboCustomer.Items.Count - 1
                        'If CM_cboCustomer.Items(tmpCount1) = r("CUST_Name1") Then
                        '    CM_cboCustomer.SelectedIndex = tmpCount1
                        '    Exit For
                        'End If
                        'Next
                        'End If

                        '//Get values for page
                        If IsDBNull(r("MarkUp_RUR")) = False Then CM_txtRUR.Text = r("MarkUp_RUR")
                        If IsDBNull(r("MarkUp_NER")) = False Then CM_txtNER.Text = r("MarkUp_NER")
                        If IsDBNull(r("MarkUp_NTF")) = False Then CM_txtNTF.Text = r("MarkUp_NTF")
                        If IsDBNull(r("MarkUp_RTM")) = False Then CM_txtRTM.Text = r("MarkUp_RTM")
                        If IsDBNull(r("MarkUp_Cust")) = False Then CM_txtCustomer.Text = r("MarkUp_Cust")
                        If IsDBNull(r("MarkUp_Invt")) = False Then CM_txtMarkupInvt.Text = r("MarkUp_Invt")

                        '//Inventory Method
                        Dim rNew As DataRow
                        Dim zCount As Integer
                        For tmpCount = 0 To dsInvMthd.Tables("linvtrymethod").Rows.Count - 1
                            rNew = dsInvMthd.Tables("linvtrymethod").Rows(tmpCount)
                            If IsDBNull(r("InvtryMthd_ID")) = False Then
                                If rNew("Invtrymdth_ID") = r("InvtryMthd_ID") Then
                                    CM_cboInvMthdID.SelectedItem = tmpCount
                                    For zCount = 0 To CM_cboInvMthdID.Items.Count - 1
                                        If CM_cboInvMthdID.Items(zCount) = rNew("Invtrymdth_Desc") Then
                                            CM_cboInvMthdID.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next
                        '//Plus Parts
                        For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                            rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                            If IsDBNull(r("Markup_PlusParts")) = False Then
                                If rNew("Value") = r("Markup_PlusParts") Then
                                    CM_cboplusparts.SelectedItem = tmpCount
                                    For zCount = 0 To CM_cboplusparts.Items.Count - 1
                                        If CM_cboplusparts.Items(zCount) = rNew("Desc") Then
                                            CM_cboplusparts.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next

                        '//Customer
                        '                    Dim rNew As DataRow
                        '                    Dim zCount As Integer
                        '                    For tmpCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                        '                        rNew = dsCustomer.Tables("tcustomer").Rows(tmpCount)
                        '                        If IsDBNull(r("CUST_ID")) = False Then
                        '                            If rNew("CUST_ID") = r("CUST_ID") Then
                        '                                CM_cboCustomer.SelectedItem = tmpCount
                        '                                For zCount = 0 To CM_cboCustomer.Items.Count - 1
                        '                                    If CM_cboCustomer.Items(zCount) = rNew("CUST_FName") Then
                        '                                        CM_cboCustomer.SelectedIndex = zCount
                        '                                        Exit For
                        '                                    End If
                        '                                Next
                        '                            End If
                        '                        End If
                        '                    Next

                        '//Product
                        '                   For tmpCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                        '                       rNew = dsProduct.Tables("lproduct").Rows(tmpCount)
                        '                       If IsDBNull(r("PROD_ID")) = False Then
                        '                           If rNew("PROD_ID") = r("PROD_ID") Then
                        '                               CM_cboProduct.SelectedItem = tmpCount
                        '                               For zCount = 0 To CM_cboProduct.Items.Count - 1
                        '                                   If CM_cboProduct.Items(zCount) = rNew("PROD_Desc") Then
                        '                                       CM_cboProduct.SelectedIndex = zCount
                        '                                        Exit For
                        '                                    End If
                        '                                Next
                        '                            End If
                        '                        End If
                        '                    Next

                    End If

                Next

                '//Hide the new elements
                btnCustomerMarkup_Save.Visible = False
                btnCustomerMarkup_Cancel.Visible = False

                Me.lblMarkupStatus.Text = "LOADED"
                btnCustomerMarkup_NEW.Visible = False
                btnCustomerMarkup_Cancel.Visible = False
                btnCustomerMarkup_Save.Visible = False
                btnCustomerMarkup_UPDATE.Visible = True

                If valType = False Then
                    btnCustomerMarkup_Save.Visible = True
                    btnCustomerMarkup_UPDATE.Visible = False
                End If

            Catch exp As Exception
                lblMarkupStatus.Text = "Not Present"
                btnCustomerMarkup_NEW.Visible = True
                btnCustomerMarkup_Cancel.Visible = True
                btnCustomerMarkup_Save.Visible = True
                btnCustomerMarkup_UPDATE.Visible = False

            End Try

        End Sub

        Private Sub GetCustomerWarranty(ByVal custID As Int32, ByVal prodID As Int32)

            Try
                Dim tmpCount As Integer = 0
                Dim tmpCount1 As Integer
                Dim valType As Boolean

                valType = False


                For xCount = 0 To dsCustomerWarranty.Tables("tcustwrty").Rows.Count - 1

                    r = dsCustomerWarranty.Tables("tcustwrty").Rows(xCount)

                    If r("CUST_ID") = custID And r("PROD_ID") = prodID Then

                        valType = True
                        'If IsDBNull(r("CUST_ID")) = False Then
                        'For tmpCount1 = 0 To CM_cboCustomer.Items.Count - 1
                        'If CM_cboCustomer.Items(tmpCount1) = r("CUST_Name1") Then
                        '    CM_cboCustomer.SelectedIndex = tmpCount1
                        '    Exit For
                        'End If
                        'Next
                        'End If

                        '//Get values for page
                        If IsDBNull(r("CustWrty_DaysinWrty")) = False Then CW_txtDaysInWrty.Text = r("custwrty_DaysinWrty")

                        '//Warranty Parts
                        Dim rNew As DataRow
                        Dim zCount As Integer
                        For tmpCount = 0 To dsPSSWrtyParts.Tables("lpsswrtyparts").Rows.Count - 1
                            rNew = dsPSSWrtyParts.Tables("lpsswrtyparts").Rows(tmpCount)
                            If IsDBNull(r("PSSWrtyParts_ID")) = False Then
                                If rNew("PSSWrtyParts_ID") = r("PSSWrtyParts_ID") Then
                                    CW_cboWrtyParts.SelectedItem = tmpCount
                                    For zCount = 0 To CW_cboWrtyParts.Items.Count - 1
                                        If CW_cboWrtyParts.Items(zCount) = rNew("PSSWrtyParts_Desc") Then
                                            CW_cboWrtyParts.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next

                        '//Warranty labor
                        For tmpCount = 0 To dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows.Count - 1
                            rNew = dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows(tmpCount)
                            If IsDBNull(r("PSSWrtyLabor_ID")) = False Then
                                If rNew("PSSWrtyLabor_ID") = r("PSSWrtyLabor_ID") Then
                                    CW_cboWrtyLabor.SelectedItem = tmpCount
                                    For zCount = 0 To CW_cboWrtyLabor.Items.Count - 1
                                        If CW_cboWrtyLabor.Items(zCount) = rNew("PSSWrtyLabor_Desc") Then
                                            CW_cboWrtyLabor.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next

                    End If

                Next

                '//Hide the new elements
                btnCustWrty_SAVE.Visible = False
                btnCustWrty_CANCEL.Visible = False

                Me.lblWarrantyStatus.Text = "LOADED"
                btnCustWrty_NEW.Visible = False
                btnCustWrty_CANCEL.Visible = False
                btnCustWrty_SAVE.Visible = False
                btnCustWrty_UPDATE.Visible = True

                If valType = False Then
                    btnCustWrty_SAVE.Visible = True
                    btnCustWrty_UPDATE.Visible = False
                End If

            Catch exp As Exception
                lblWarrantyStatus.Text = "Not Present"
                btnCustWrty_NEW.Visible = True
                btnCustWrty_CANCEL.Visible = True
                btnCustWrty_SAVE.Visible = True
                btnCustWrty_UPDATE.Visible = False

            End Try

        End Sub

        Private Sub GetCustomerPrice(ByVal custID As Int32, ByVal prodID As Int32)

            Try
                Dim tmpCount As Integer = 0
                Dim tmpCount1 As Integer
                Dim valType As Boolean

                valType = False

                For xCount = 0 To dsCustomer2Price.Tables("tcusttoprice").Rows.Count - 1

                    r = dsCustomer2Price.Tables("tcusttoprice").Rows(xCount)

                    If r("CUST_ID") = custID And r("PROD_ID") = prodID Then

                        valType = True
                        'If IsDBNull(r("CUST_ID")) = False Then
                        'For tmpCount1 = 0 To CM_cboCustomer.Items.Count - 1
                        'If CM_cboCustomer.Items(tmpCount1) = r("CUST_Name1") Then
                        '    CM_cboCustomer.SelectedIndex = tmpCount1
                        '    Exit For
                        'End If
                        'Next
                        'End If

                        '//Get values for page
                        'If IsDBNull(r("PrcGroup_ID")) = False Then CW_txtDaysInWrty.Text = r("custwrty_DaysinWrty")

                        '//Pricing Group
                        Dim rNew As DataRow
                        Dim zCount As Integer
                        For tmpCount = 0 To dsPrcGroup.Tables("lpricinggroup").Rows.Count - 1
                            rNew = dsPrcGroup.Tables("lpricinggroup").Rows(tmpCount)
                            If IsDBNull(r("PrcGroup_ID")) = False Then
                                If rNew("PrcGroup_ID") = r("PrcGroup_ID") Then
                                    CP_cboPricingGroup.SelectedItem = tmpCount
                                    For zCount = 0 To CP_cboPricingGroup.Items.Count - 1
                                        If CP_cboPricingGroup.Items(zCount) = rNew("PrcGroup_LDesc") Then
                                            CP_cboPricingGroup.SelectedIndex = zCount
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Next

                        '//Hide the new elements
                        btnCustPrice_SAVE.Visible = False
                        btnCustPrice_CANCEL.Visible = False

                        Me.lblCustPriceStatus.Text = "LOADED"
                        btnCustPrice_NEW.Visible = False
                        btnCustPrice_CANCEL.Visible = False
                        btnCustPrice_SAVE.Visible = False
                        btnCustPrice_UPDATE.Visible = True

                        If valType = False Then
                            btnCustPrice_SAVE.Visible = True
                            btnCustPrice_UPDATE.Visible = False
                        End If
                    End If
                Next

                If valType = False Then
                    Me.lblCustPriceStatus.Text = "Not Present"
                    btnCustPrice_NEW.Visible = False
                    btnCustPrice_CANCEL.Visible = False
                    btnCustPrice_SAVE.Visible = True
                    btnCustPrice_UPDATE.Visible = False
                End If


            Catch exp As Exception


                MsgBox(exp.ToString) '/Craig Haney July 11, 2005


                lblCustPriceStatus.Text = "Not Present"
                btnCustPrice_NEW.Visible = True
                btnCustPrice_CANCEL.Visible = True
                btnCustPrice_SAVE.Visible = True
                btnCustPrice_UPDATE.Visible = False

            End Try


        End Sub

#End Region

#End Region

#Region " Customer Markup Section "

#Region " Form Specific Customer Markup "

        Private Sub ClearCustomerMarkupFields()

            CM_txtName.Text = ""
            '            CM_cboCustomer.SelectedIndex = 0
            CM_cboCustomer.Text = ""
            '            CM_cboProduct.SelectedIndex = 0
            CM_cboProduct.Text = ""
            CM_txtMarkupInvt.Text = ""
            CM_txtRUR.Text = ""
            CM_txtNER.Text = ""
            CM_txtNTF.Text = ""
            CM_txtRTM.Text = ""
            CM_txtCustomer.Text = ""
            '            CM_cboInvMthdID.SelectedIndex = 0
            CM_cboInvMthdID.Text = ""

            CM_cboInvMthdID.Items.Clear()

            assignDataSet2cbControl(CM_cboInvMthdID, dsInvMthd, "linvtrymethod", "Invtrymdth_Desc")

        End Sub

        Private Sub CM_cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

            ClearCustomerMarkupFields()
            'Dim valCustomerMarkup As Integer = GetCustomerMarkupID()
            'GetCustomerMarkup(valCustomerMarkup)

        End Sub

#End Region

#Region " Data Specific Customer Markup "


#End Region

#End Region


        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            Dim strError
            Dim pkParentCo As Integer = 0

            '//Make sure all sections have ID values
            For xCount = 0 To dsParentCo.Tables("lparentco").Rows.Count - 1
                r = dsParentCo.Tables("lparentco").Rows(xCount)
                If r("PCo_Name") = PC_cboName.Text Then
                    pkParentCo = r("PCo_ID")
                    Exit For
                End If
            Next
            If pkParentCo < 1 Then
                strError += "There is no primary key for Parent Company." & vbCrLf
            End If

            'MsgBox("ParentCo  :  " & pkParentCo)

            If Len(strError) > 0 Then
                MsgBox(strError, MsgBoxStyle.OKOnly, "Error")
                Exit Sub
            End If

        End Sub

        Private Function VerifyCustWrty_beforeInsert() As String

            VerifyCustWrty_beforeInsert = ""

            If Len(CW_cboCustomer.Text) < 1 Then VerifyCustWrty_beforeInsert += "No customer selected." & vbCrLf
            If Len(CW_cboProduct.Text) < 1 Then VerifyCustWrty_beforeInsert += "No product selected." & vbCrLf
            If Len(CW_txtDaysInWrty.Text) < 1 Then VerifyCustWrty_beforeInsert += "Days in Warranty value not defined." & vbCrLf
            If Len(CW_cboWrtyParts.Text) < 1 Then VerifyCustWrty_beforeInsert += "Warranty Parts value not defined." & vbCrLf
            If Len(CW_cboWrtyLabor.Text) < 1 Then VerifyCustWrty_beforeInsert += "Warranty Labor value not defined." & vbCrLf

        End Function

        Private Function GenerateCustWrtySQL_INSERT() As String

            Dim tmpCustomer As Integer
            Dim tmpProduct As Integer
            Dim tmpPSSWrtyParts As Integer
            Dim tmpPSSWrtyLabor As Integer

            GenerateCustWrtySQL_INSERT = ""

            '//Convert over combo box values to id
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CW_cboCustomer.Text Then
                    tmpCustomer = r("CUST_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                r = dsProduct.Tables("lproduct").Rows(xCount)
                If r("Prod_Desc") = CW_cboProduct.Text Then
                    tmpProduct = r("Prod_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsPSSWrtyParts.Tables("lpsswrtyparts").Rows.Count - 1
                r = dsPSSWrtyParts.Tables("lpsswrtyparts").Rows(xCount)
                If r("PSSWrtyParts_Desc") = CW_cboWrtyParts.Text Then
                    tmpPSSWrtyParts = r("PSSWrtyParts_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows.Count - 1
                r = dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows(xCount)
                If r("PSSWrtylabor_Desc") = CW_cboWrtyLabor.Text Then
                    tmpPSSWrtyLabor = r("PSSWrtyLabor_ID")
                    Exit For
                End If
            Next

            '//Verify all replies have values
            If tmpCustomer < 1 Or tmpProduct < 1 Or tmpPSSWrtyParts < 1 Or tmpPSSWrtyLabor < 1 Then
                '//Throw error message and exit
                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
                GenerateCustWrtySQL_INSERT = ""
                Exit Function
            End If

            '//Create SQL for return
            Dim sqlFieldList As String
            Dim sqlValueList As String

            sqlFieldList = "(CustWrty_DaysinWrty, PSSWrtyParts_ID, PSSWrtyLabor_ID, Prod_ID, Cust_ID)"

            sqlValueList = "( " & CW_txtDaysInWrty.Text & ", " & _
            tmpPSSWrtyParts & ", " & _
            tmpPSSWrtyLabor & ", " & _
            tmpProduct & ", " & _
            tmpCustomer & ")"


            GenerateCustWrtySQL_INSERT = "INSERT INTO tcustwrty " & sqlFieldList & " VALUES " & sqlValueList
        End Function

        Private Function GenerateCustWrtySQL_UPDATE() As String

            Dim tmpCustomer As Integer
            Dim tmpProduct As Integer
            Dim tmpPSSWrtyParts As Integer
            Dim tmpPSSWrtyLabor As Integer

            GenerateCustWrtySQL_UPDATE = ""

            '//Convert over combo box values to id
            For xCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                r = dsCustomer.Tables("tcustomer").Rows(xCount)
                If r("CUST_Name1") = CW_cboCustomer.Text Then
                    tmpCustomer = r("CUST_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                r = dsProduct.Tables("lproduct").Rows(xCount)
                If r("Prod_Desc") = CW_cboProduct.Text Then
                    tmpProduct = r("Prod_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsPSSWrtyParts.Tables("lpsswrtyparts").Rows.Count - 1
                r = dsPSSWrtyParts.Tables("lpsswrtyparts").Rows(xCount)
                If r("PSSWrtyParts_Desc") = CW_cboWrtyParts.Text Then
                    tmpPSSWrtyParts = r("PSSWrtyParts_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows.Count - 1
                r = dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows(xCount)
                If r("PSSWrtylabor_Desc") = CW_cboWrtyLabor.Text Then
                    tmpPSSWrtyLabor = r("PSSWrtyLabor_ID")
                    Exit For
                End If
            Next

            '//Verify all replies have values
            If tmpCustomer < 1 Or tmpProduct < 1 Or tmpPSSWrtyParts < 1 Or tmpPSSWrtyLabor < 1 Then
                '//Throw error message and exit
                MsgBox("The combo boxes could not be converted. Contact IT.", MsgBoxStyle.OKOnly)
                GenerateCustWrtySQL_UPDATE = ""
                Exit Function
            End If

            '//Create SQL for return
            Dim strSQL As String

            strSQL = "UPDATE tcustwrty SET " & _
            "CustWrty_DaysinWrty = " & CW_txtDaysInWrty.Text & ", " & _
            "PSSWrtyParts_ID = " & tmpPSSWrtyParts & ", " & _
            "PSSWrtyLabor_ID = " & tmpPSSWrtyLabor & _
            " WHERE Cust_ID = " & tmpCustomer & " AND Prod_ID = " & tmpProduct

            GenerateCustWrtySQL_UPDATE = strSQL

        End Function

        Private Sub GetCustMarkup(ByVal valCust As Int32, ByVal valProd As Int32)

            Try
                Dim tmpCount As Integer = 0
                Dim zCount As Integer
                Dim rNew As DataRow
                Dim tmpTable As New PSS.Data.Production.tcustmarkup()
                r = tmpTable.GetRowByCustProd(valCust, valProd)

                If r("CUST_ID") = valCust Then
                    '//Get values for page
                    If IsDBNull(r("MarkUp_RUR")) = False Then CM_txtRUR.Text = r("Markup_RUR")
                    If IsDBNull(r("MarkUp_NER")) = False Then CM_txtNER.Text = r("Markup_NER")
                    If IsDBNull(r("MarkUp_NTF")) = False Then CM_txtNTF.Text = r("Markup_NTF")
                    If IsDBNull(r("MarkUp_Cust")) = False Then CM_txtCustomer.Text = r("Markup_Cust")

                    '//Inventory Method
                    For tmpCount = 0 To dsInvMthd.Tables("linvtrymethod").Rows.Count - 1
                        rNew = dsInvMthd.Tables("linvtrymethod").Rows(tmpCount)
                        If IsDBNull(r("Invtrymthd_ID")) = False Then
                            If rNew("Invtrymdth_id") = r("Invtrymthd_ID") Then
                                CM_cboInvMthdID.SelectedItem = tmpCount
                                For zCount = 0 To CM_cboInvMthdID.Items.Count - 1
                                    If CM_cboInvMthdID.Items(zCount) = rNew("Invtrymdth_Desc") Then
                                        CM_cboInvMthdID.SelectedIndex = zCount
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Next
                    '//Product
                    Dim zCount1 As Integer
                    For tmpCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                        rNew = dsProduct.Tables("lproduct").Rows(tmpCount)
                        If IsDBNull(r("Prod_ID")) = False Then
                            If rNew("PROD_id") = r("PROD_id") Then
                                CM_cboProduct.SelectedItem = tmpCount
                                For zCount1 = 0 To CM_cboProduct.Items.Count - 1
                                    If CM_cboProduct.Items(zCount1) = rNew("PROD_Desc") Then
                                        CM_cboProduct.SelectedIndex = zCount1
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Next
                    '//Customer
                    For tmpCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                        rNew = dsCustomer.Tables("tcustomer").Rows(tmpCount)
                        If IsDBNull(valCust) = False Then
                            If rNew("CUST_id") = valCust Then
                                CM_cboCustomer.SelectedItem = tmpCount
                                For zCount = 0 To CM_cboCustomer.Items.Count - 1
                                    If CM_cboCustomer.Items(zCount) = rNew("CUST_Name1") Then
                                        CM_cboCustomer.SelectedIndex = zCount
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If
                '//Plus Parts
                For tmpCount = 0 To dsYesNo.Tables("Generic").Rows.Count - 1
                    rNew = dsYesNo.Tables("Generic").Rows(tmpCount)
                    If IsDBNull(r("Markup_PlusParts")) = False Then
                        If rNew("Value") = r("Markup_PlusParts") Then
                            CM_cboplusparts.SelectedItem = tmpCount
                            For zCount = 0 To CM_cboplusparts.Items.Count - 1
                                If CM_cboplusparts.Items(zCount) = rNew("Desc") Then
                                    CM_cboplusparts.SelectedIndex = zCount
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                Next
                '//Hide the new elements
                btnCustomerMarkup_Save.Visible = False
                btnCustomerMarkup_Cancel.Visible = False
                lblMarkupStatus.Text = "LOADED"
                btnCustomerMarkup_NEW.Visible = False
                btnCustomerMarkup_Cancel.Visible = False
                btnCustomerMarkup_Save.Visible = False
                btnCustomerMarkup_UPDATE.Visible = True
            Catch exp As Exception
                MsgBox(exp.ToString)

                lblMarkupStatus.Text = "Not Present"
                btnCustomerMarkup_NEW.Visible = True
                btnCustomerMarkup_Cancel.Visible = True
                btnCustomerMarkup_Save.Visible = True
                btnCustomerMarkup_UPDATE.Visible = False
            End Try
        End Sub


        Private Sub GetCustWrty(ByVal valCust As Int32, ByVal valProd As Int32)

            Try
                Dim tmpCount As Integer = 0

                Dim tmpTable As New PSS.Data.Production.tcustwrty()
                r = tmpTable.GetRowByCustProd(valCust, valProd)

                If r("CUST_ID") = valCust Then
                    '//Get values for page
                    If IsDBNull(r("CustWrty_DaysInWrty")) = False Then CW_txtDaysInWrty.Text = r("CustWrty_DaysInWrty")

                    '//PSS Warranty Parts
                    Dim rNew As DataRow
                    Dim zCount As Integer = 0
                    For tmpCount = 0 To dsPSSWrtyParts.Tables("lpsswrtyparts").Rows.Count - 1
                        rNew = dsPSSWrtyParts.Tables("lpsswrtyparts").Rows(tmpCount)
                        If rNew("PSSWrtyParts_ID") = r("PSSWrtyParts_ID") Then
                            CW_cboWrtyParts.SelectedIndex = tmpCount
                            Exit For
                        End If
                    Next
                    '//PSS Warranty Labor
                    For tmpCount = 0 To dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows.Count - 1
                        rNew = dsPSSWrtyLabor.Tables("lpsswrtylabor").Rows(tmpCount)
                        If rNew("PSSWrtyLabor_ID") = r("PSSWrtyLabor_ID") Then
                            CW_cboWrtyLabor.SelectedIndex = tmpCount
                            Exit For
                        End If
                    Next
                    '//Product
                    Dim zCount1 As Integer
                    For tmpCount = 0 To dsProduct.Tables("lproduct").Rows.Count - 1
                        rNew = dsProduct.Tables("lproduct").Rows(tmpCount)
                        If IsDBNull(r("Prod_ID")) = False Then
                            If rNew("PROD_id") = r("PROD_id") Then
                                CW_cboProduct.SelectedItem = tmpCount
                                For zCount1 = 0 To CW_cboProduct.Items.Count - 1
                                    If CW_cboProduct.Items(zCount1) = rNew("PROD_Desc") Then
                                        CW_cboProduct.SelectedIndex = zCount1
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Next
                    '//Customer
                    For tmpCount = 0 To dsCustomer.Tables("tcustomer").Rows.Count - 1
                        rNew = dsCustomer.Tables("tcustomer").Rows(tmpCount)


                        If IsDBNull(valCust) = False Then
                            If rNew("CUST_id") = valCust Then
                                CW_cboCustomer.SelectedItem = tmpCount
                                For zCount = 0 To CW_cboCustomer.Items.Count - 1
                                    If CW_cboCustomer.Items(zCount) = rNew("CUST_Name1") Then
                                        CW_cboCustomer.SelectedIndex = zCount
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If

                '//Hide the new elements
                btnCustomer_Save.Visible = False
                btnCustomer_Cancel.Visible = False
                lblWarrantyStatus.Text = "LOADED"
                btnCustWrty_NEW.Visible = False
                btnCustWrty_CANCEL.Visible = False
                btnCustWrty_SAVE.Visible = False
                btnCustWrty_UPDATE.Visible = True
            Catch exp As Exception
                lblWarrantyStatus.Text = "Not Present"
                btnCustWrty_NEW.Visible = True
                btnCustWrty_CANCEL.Visible = True
                btnCustWrty_SAVE.Visible = True
                btnCustWrty_UPDATE.Visible = False
            End Try
        End Sub

        Private Sub PC_txtName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
            PC_cboName.Focus()
        End Sub

        Private Sub btnParentCo_NEW_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParentCo_NEW.Click
            ClearParentCoFields()
            PC_txtName.Visible = True
            PC_cboName.Visible = False
            btnParentCo_SAVE.Visible = True
            btnParentCo_CANCEL.Visible = True
            btnParentCo_UPDATE.Visible = False
            PC_txtName.Focus()
        End Sub

        Private Sub btnParentCo_CANCEL_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParentCo_CANCEL.Click
            ClearParentCoFields()
            PC_cboName.Visible = True
            PC_txtName.Visible = False
            PC_cboName.Focus()
            refreshParentCoList()
        End Sub

        Private Sub btnParentCo_SAVE_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParentCo_SAVE.Click

            Dim tmpName As String = Trim(PC_txtName.Text)
            For xCount = 0 To PC_cboName.Items.Count - 1
                If UCase(Trim(PC_cboName.Items(xCount))) = UCase(tmpName) Then
                    MsgBox("A record already uses this description. Plesae try again or cancel.", MsgBoxStyle.OKOnly, "Error")
                    Exit Sub
                End If
            Next

            Dim strError As String = VerifyParentCo_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim strSQL As String = GeneratePCoSQL_Insert()
                Dim actInsert As New PSS.Data.Production.lparentco()
                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                If tmpID < 1 Then 'FAILED
                    MsgBox("Error Insert Parent Company Information", MsgBoxStyle.OKOnly)
                Else
                    PC_txtName.Visible = False
                    PC_cboName.Visible = True
                    GetParentCo(tmpID)
                    btnParentCo_SAVE.Visible = False
                    btnParentCo_CANCEL.Visible = False
                    refreshParentCoList()
                    ClearParentCoFields()
                    PC_cboName.Text = ""
                    btnParentCo_UPDATE.Visible = True

                    clearComboBoxesALL()
                    clearDatasets()
                    populateComboBoxesALL()
                    System.Windows.Forms.Application.DoEvents()

                    '//repopulate the page with the saved parent company
                    For xCount = 0 To PC_cboName.Items.Count - 1
                        If Trim(PC_cboName.Items(xCount)) = tmpName Then
                            PC_cboName.SelectedIndex = xCount
                            Exit For
                        End If
                    Next

                End If
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub btnParentCo_UPDATE_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParentCo_UPDATE.Click

            Dim strError As String = VerifyParentCo_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim tmpName As String = Trim(PC_cboName.Text)
                Dim strSQL As String = GeneratePCoSQL_Update()
                Gui.Receiving.General.AuditCall("CustMaint_ParentCo_UPDATE", Trim(PC_valPCOID.Text), Controls)
                'Exit Sub
                Dim actInsert As New PSS.Data.Production.lparentco()

                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                '                If tmpID > 0 Then 'FAILED
                '               MsgBox("Error Insert Parent Company Information", MsgBoxStyle.OKOnly)
                '              Else
                PC_txtName.Visible = False
                PC_cboName.Visible = True
                GetParentCo(tmpID)
                btnParentCo_SAVE.Visible = False
                btnParentCo_CANCEL.Visible = False
                refreshParentCoList()
                ClearParentCoFields()
                PC_cboName.Text = ""
                btnParentCo_UPDATE.Visible = True

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()

                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page with the saved parent company
                For xCount = 0 To PC_cboName.Items.Count - 1
                    If Trim(PC_cboName.Items(xCount)) = Trim(tmpName) Then
                        PC_cboName.SelectedIndex = xCount
                        Exit For
                    End If
                Next

                '             End If
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub


        Private Sub PC_cboName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PC_cboName.SelectedIndexChanged

            ClearParentCoFields()
            Dim tmpVal As Int32 = GetParentCoID()
            GetParentCoData(tmpVal)

            '            Dim valPCoID As Int32 = GetParentCoID()
            '            GetParentCoData(valPCoID)
            '            Me.btnParentCo_NEW.Visible = False
            '            Me.btnParentCo_SAVE.Visible = False

        End Sub

        Private Sub CUST_cboName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUST_cboName.SelectedIndexChanged

            ClearCustomerFields()
            Dim tmpVal As Int32 = GetCustomerID()
            GetCustomer(tmpVal)

        End Sub

        Private Sub btnCustomer_NEW_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer_NEW.Click

            ClearCustomerFields()
            CUST_txtFName.Visible = True
            CUST_cboName.Visible = False
            btnCustomer_Save.Visible = True
            btnCustomer_Cancel.Visible = True
            btnCustomer_UPDATE.Visible = False
            CUST_txtFName.Focus()

        End Sub

        Private Sub btnCustomer_Save_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer_Save.Click

            Dim tmpName As String = Trim(CUST_txtFName.Text)
            For xCount = 0 To CUST_cboName.Items.Count - 1
                If UCase(Trim(CUST_cboName.Items(xCount))) = UCase(tmpName) Then
                    'MsgBox("A record already uses this description. Plesae try again or cancel.", MsgBoxStyle.OKOnly, "Error")
                    'Exit Sub
                End If
            Next

            Dim strError As String = VerifyCustomer_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim strSQL As String = GenerateCustomerSQL_Insert()
                Dim actInsert As New PSS.Data.Production.tcustomer()
                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                If tmpID < 1 Then 'FAILED
                    MsgBox("Error Insert Customer Information", MsgBoxStyle.OKOnly)
                Else
                    CUST_txtFName.Visible = False
                    CUST_cboName.Visible = True
                    GetCustomer(tmpID)
                    btnCustomer_Save.Visible = False
                    btnCustomer_Cancel.Visible = False
                    refreshCustomerList()


                    '                    ClearCustomerFields()
                    CUST_cboName.Text = ""
                    '                    btncustomer_UPDATE.Visible = True

                    ClearCustomerFields()

                End If

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                cboSelectCustomer.Text = ""
                cboSelectCustomer.Items.Clear()
                populateCustomerSelect()

                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page with the saved parent company
                For xCount = 0 To CUST_cboName.Items.Count - 1
                    If Trim(CUST_cboName.Items(xCount)) = tmpName Then
                        CUST_cboName.SelectedIndex = xCount
                        Exit For
                    End If
                Next

                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub btnCustomer_Cancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer_Cancel.Click

            ClearCustomerFields()
            CUST_cboName.Visible = True
            CUST_txtFName.Visible = False
            CUST_cboName.Focus()
            refreshCustomerList()

        End Sub

        Private Sub CC_cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_cboCustomer.SelectedIndexChanged

            CC_txtCCNumber.Text = ""
            CC_txtAuthCode.Text = ""
            CC_txtExpDate.Text = ""
            CC_cboCCType.Text = ""
            CC_cboCCType.Items.Clear()
            assignDataSet2cbControl(CC_cboCCType, dsCCType, "lcctype", "CCType_Desc")

            btnCreditCard_NEW.Visible = False
            btnCreditCard_SAVE.Visible = False
            btnCreditCard_CANCEL.Visible = False
            btnCreditCard_UPDATE.Visible = False

            Dim ccID As Int32 = GetCustomerIDCC()
            System.Windows.Forms.Application.DoEvents()
            GetCreditCard(ccID)

        End Sub

        Private Sub btnCreditCard_SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreditCard_SAVE.Click

            Dim strError As String = VerifyCreditCard_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim tmpName As String = Trim(CC_cboCustomer.Text)

                Dim strSQL As String = GenerateCreditCardSQL_Insert()
                Dim ccInsert As New PSS.Data.Production.tcreditcard()
                Dim tmpID As Int32 = ccInsert.idTransaction(strSQL)
                'If tmpID < 1 Then 'FAILED
                'MsgBox("Error Insert Credit Card Information", MsgBoxStyle.OKOnly)
                'Else
                ClearCreditCardFields()

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page
                For xCount = 0 To CC_cboCustomer.Items.Count - 1
                    If Trim(CC_cboCustomer.Items(xCount)) = tmpName Then
                        CC_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                enableLinkFields()

                'End If
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub btnCustWrty_NEW_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustWrty_NEW.Click

            '//Disable the Customer and Product boxes. This will identify the unique record
            CW_cboCustomer.Enabled = False
            CW_cboProduct.Enabled = False

            btnCustWrty_CANCEL.Visible = True
            btnCustWrty_SAVE.Visible = True

        End Sub

        Private Sub btnCustWrty_CANCEL_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustWrty_CANCEL.Click

            '//Enable the Customer and Product boxes.
            CW_cboCustomer.Enabled = True
            CW_cboProduct.Enabled = True
            btnCustWrty_CANCEL.Visible = False
            btnCustWrty_SAVE.Visible = False
            CW_cboCustomer.Focus()

        End Sub

        Private Sub btnCustWrty_SAVE_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustWrty_SAVE.Click

            Dim strError As String = VerifyCustWrty_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim strSQL As String = GenerateCustWrtySQL_INSERT()
                Dim actInsert As New PSS.Data.Production.tcustwrty()
                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                If tmpID < 1 Then 'FAILED
                    MsgBox("Error Insert Customer Warranty Information", MsgBoxStyle.OKOnly)
                Else
                    CW_cboCustomer.Enabled = True
                    btnCustWrty_SAVE.Visible = False
                    btnCustWrty_CANCEL.Visible = False
                End If

                Dim tmpName As String = Trim(CW_cboCustomer.Text)
                Dim tmpProduct As String = Trim(CW_cboProduct.Text)

                CW_txtDaysInWrty.Text = ""
                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page
                For xCount = 0 To CW_cboCustomer.Items.Count - 1
                    If Trim(CW_cboCustomer.Items(xCount)) = tmpName Then
                        CW_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                'For xCount = 0 To CW_cboProduct.Items.Count - 1
                'If Trim(CW_cboProduct.Items(xCount)) = tmpProduct Then
                '    CW_cboProduct.SelectedIndex = xCount
                'End If
                'Next
                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Sub

        Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustWrty_UPDATE.Click

            Dim strError As String = VerifyCustWrty_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim strSQL As String = GenerateCustWrtySQL_UPDATE()
                Dim actInsert As New PSS.Data.Production.tcustwrty()
                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                '    If tmpID < 1 Then 'FAILED
                '    MsgBox("Error Insert Customer Warranty Information", MsgBoxStyle.OKOnly)
                '    Else
                CW_cboCustomer.Enabled = True
                btnCustWrty_SAVE.Visible = False
                btnCustWrty_CANCEL.Visible = False
                '    End If

                Dim tmpName As String = Trim(CW_cboCustomer.Text)
                Dim tmpProduct As String = Trim(CW_cboProduct.Text)

                CW_txtDaysInWrty.Text = ""
                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page
                For xCount = 0 To CW_cboCustomer.Items.Count - 1
                    If Trim(CW_cboCustomer.Items(xCount)) = tmpName Then
                        CW_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                'For xCount = 0 To CW_cboProduct.Items.Count - 1
                'If Trim(CW_cboProduct.Items(xCount)) = tmpProduct Then
                'CW_cboProduct.SelectedIndex = xCount
                'End If
                'Next
                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub clearCWtextFields()
            CW_txtDaysInWrty.Text = ""
        End Sub

        Private Sub CW_cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CW_cboCustomer.SelectedIndexChanged

            CW_txtDaysInWrty.Text = ""
            CW_cboWrtyParts.Text = ""
            CW_cboWrtyLabor.Text = ""
            CW_cboWrtyParts.Items.Clear()
            CW_cboWrtyLabor.Items.Clear()
            assignDataSet2cbControl(CW_cboWrtyParts, dsPSSWrtyParts, "lpsswrtyparts", "PSSWrtyParts_Desc")
            assignDataSet2cbControl(CW_cboWrtyLabor, dsPSSWrtyLabor, "lpsswrtylabor", "PSSWrtyLabor_Desc")

            Dim tmpCustomer As Int32 = GetCustomerCWID()
            Dim tmpProduct As Int32 = GetProductCWID()
            System.Windows.Forms.Application.DoEvents()

            If tmpCustomer > 0 And tmpProduct > 0 Then
                GetCustomerWarranty(tmpCustomer, tmpProduct)
            End If
        End Sub

        Private Sub CW_cboProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CW_cboProduct.SelectedIndexChanged

            CW_txtDaysInWrty.Text = ""
            CW_cboWrtyParts.Text = ""
            CW_cboWrtyLabor.Text = ""
            CW_cboWrtyParts.Items.Clear()
            CW_cboWrtyLabor.Items.Clear()
            assignDataSet2cbControl(CW_cboWrtyParts, dsPSSWrtyParts, "lpsswrtyparts", "PSSWrtyParts_Desc")
            assignDataSet2cbControl(CW_cboWrtyLabor, dsPSSWrtyLabor, "lpsswrtylabor", "PSSWrtyLabor_Desc")

            Dim tmpCustomer As Int32 = GetCustomerCWID()
            Dim tmpProduct As Int32 = GetProductCWID()
            System.Windows.Forms.Application.DoEvents()

            If tmpCustomer > 0 And tmpProduct > 0 Then
                GetCustomerWarranty(tmpCustomer, tmpProduct)
            End If
        End Sub

        Private Sub reloadSelectCustomer()

            If Len(Trim(cboSelectCustomer.Text)) < 1 Then Exit Sub

            GetSelectCustomer()
            Dim valProductText As String = "Messaging"

            '//Reset labels
            lblParentCoStatus.Text = "Not Defined"
            lblCustomerStatus.Text = "Not Defined"
            lblMarkupStatus.Text = "Not Defined"
            lblWarrantyStatus.Text = "Not Defined"
            lblCCStatus.Text = "Not Defined"
            lblCustPriceStatus.Text = "Not Defined"
            lblLocationStatus.Text = "Not Defined"


            If CustomerSelect > 0 Then
                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()


                'ctrlTab.SelectedTab = tbParent
                For xCount = 0 To PC_cboName.Items.Count - 1
                    If PC_cboName.Items(xCount) = ParentCoSelectText Then
                        PC_cboName.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetParentCoData(ParentCoSelect)
                ctrlTab.SelectedTab = tbCustomer
                For xCount = 0 To CUST_cboName.Items.Count - 1
                    If CUST_cboName.Items(xCount) = CustomerSelectText Then
                        CUST_cboName.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetLocation(customerSelect)
                'ctrlTab.SelectedTab = tbLocation
                For xCount = 0 To LOC_cboCustomer.Items.Count - 1
                    If LOC_cboCustomer.Items(xCount) = CustomerSelectText Then
                        LOC_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetCustomer(customerSelect)
                'ctrlTab.SelectedTab = tbCreditCard
                For xCount = 0 To CC_cboCustomer.Items.Count - 1
                    If CC_cboCustomer.Items(xCount) = CustomerSelectText Then
                        CC_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetCreditCard(customerSelect)
                'ctrlTab.SelectedTab = tbCustWrty
                For xCount = 0 To CW_cboCustomer.Items.Count - 1
                    If CW_cboCustomer.Items(xCount) = CustomerSelectText Then
                        CW_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                For xCount = 0 To CW_cboProduct.Items.Count - 1
                    If CW_cboProduct.Items(xCount) = valProductText Then
                        CW_cboProduct.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetCustWrty(customerSelect, 1)
                'ctrlTab.SelectedTab = tbCustMarkup
                For xCount = 0 To CM_cboCustomer.Items.Count - 1
                    If CM_cboCustomer.Items(xCount) = CustomerSelectText Then
                        CM_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                For xCount = 0 To CM_cboProduct.Items.Count - 1
                    If CM_cboProduct.Items(xCount) = valProductText Then
                        CM_cboProduct.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '              GetCustMarkup(customerSelect, 1)
                'ctrlTab.SelectedTab = tbCust2Price
                For xCount = 0 To CP_cboCustomer.Items.Count - 1
                    If CP_cboCustomer.Items(xCount) = CustomerSelectText Then
                        CP_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                For xCount = 0 To CP_cboProduct.Items.Count - 1
                    If CP_cboProduct.Items(xCount) = valProductText Then
                        CP_cboProduct.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetCustomerPrice(CustomerSelect, 1)

            End If

            '//Select cboSelectCustomer again
            'cboSelectCustomer.Text = CustomerSelectText

            'btnLocation_New.Visible = True

            disableLinkFields()

        End Sub


        Private Sub cboSelectCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSelectCustomer.SelectedIndexChanged

            GetSelectCustomer()
            Dim valProductText As String = "Messaging"

            '//Reset labels
            lblParentCoStatus.Text = "Not Defined"
            lblCustomerStatus.Text = "Not Defined"
            lblMarkupStatus.Text = "Not Defined"
            lblWarrantyStatus.Text = "Not Defined"
            lblCCStatus.Text = "Not Defined"
            lblCustPriceStatus.Text = "Not Defined"
            lblLocationStatus.Text = "Not Defined"


            If CustomerSelect > 0 Then
                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()


                'ctrlTab.SelectedTab = tbParent
                For xCount = 0 To PC_cboName.Items.Count - 1
                    If PC_cboName.Items(xCount) = ParentCoSelectText Then
                        PC_cboName.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetParentCoData(ParentCoSelect)
                ctrlTab.SelectedTab = tbCustomer
                For xCount = 0 To CUST_cboName.Items.Count - 1
                    If CUST_cboName.Items(xCount) = CustomerSelectText Then
                        CUST_cboName.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetLocation(customerSelect)
                'ctrlTab.SelectedTab = tbLocation
                For xCount = 0 To LOC_cboCustomer.Items.Count - 1
                    If LOC_cboCustomer.Items(xCount) = CustomerSelectText Then
                        LOC_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetCustomer(customerSelect)
                'ctrlTab.SelectedTab = tbCreditCard
                For xCount = 0 To CC_cboCustomer.Items.Count - 1
                    If CC_cboCustomer.Items(xCount) = CustomerSelectText Then
                        CC_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetCreditCard(customerSelect)
                'ctrlTab.SelectedTab = tbCustWrty
                For xCount = 0 To CW_cboCustomer.Items.Count - 1
                    If CW_cboCustomer.Items(xCount) = CustomerSelectText Then
                        CW_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                For xCount = 0 To CW_cboProduct.Items.Count - 1
                    If CW_cboProduct.Items(xCount) = valProductText Then
                        CW_cboProduct.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetCustWrty(customerSelect, 1)
                'ctrlTab.SelectedTab = tbCustMarkup
                For xCount = 0 To CM_cboCustomer.Items.Count - 1
                    If CM_cboCustomer.Items(xCount) = CustomerSelectText Then
                        CM_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                For xCount = 0 To CM_cboProduct.Items.Count - 1
                    If CM_cboProduct.Items(xCount) = valProductText Then
                        CM_cboProduct.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '              GetCustMarkup(customerSelect, 1)
                'ctrlTab.SelectedTab = tbCust2Price
                For xCount = 0 To CP_cboCustomer.Items.Count - 1
                    If CP_cboCustomer.Items(xCount) = CustomerSelectText Then
                        CP_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                For xCount = 0 To CP_cboProduct.Items.Count - 1
                    If CP_cboProduct.Items(xCount) = valProductText Then
                        CP_cboProduct.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                '                GetCustomerPrice(CustomerSelect, 1)

            End If

            System.Windows.Forms.Application.DoEvents()
            If Len(Trim(cboSelectCustomer.Text)) > 0 Then
                Dim aIndex As Integer
                With cboCustomerPreLoad
                    For aIndex = 0 To .Items.Count - 1
                        If CType(.Items(aIndex)(1), String).Trim = cboSelectCustomer.Text.Trim Then
                            .SelectedIndex = aIndex
                            Exit For
                        End If
                    Next
                    If aIndex >= .Items.Count Then .SelectedIndex = -1
                End With
            End If

            '//Select cboSelectCustomer again
            'cboSelectCustomer.Text = CustomerSelectText

            'btnLocation_New.Visible = True

            disableLinkFields()

            '//Aggregate Billing
            Me.loadAggCodes()
            Me.loadDefinedAggCodes()
        End Sub


        Private Sub btnNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNEW.Click

            HideAllButtons()

            '//Reset labels
            lblParentCoStatus.Text = "Not Defined"
            lblCustomerStatus.Text = "Not Defined"
            lblMarkupStatus.Text = "Not Defined"
            lblWarrantyStatus.Text = "Not Defined"
            lblCCStatus.Text = "Not Defined"
            lblCustPriceStatus.Text = "Not Defined"
            lblLocationStatus.Text = "Not Defined"

            CustomerSelect = 0
            cboSelectCustomer.Text = ""

            btnParentCo_NEW.Visible = True
            ClearParentCoFields()
            PC_cboName.Text = ""

            btnCustomer_NEW.Visible = True
            ClearCustomerFields()
            Me.CUST_cboName.Text = ""

            'btnCustomerMarkup_NEW.Visible = True
            ClearCustomerMarkupFields()

            'btnCustWrty_NEW.Visible = True
            ClearCustWrtyFields()
            Me.CW_cboCustomer.Text = ""
            Me.CW_cboWrtyLabor.Text = ""
            Me.CW_cboWrtyParts.Text = ""

            'btnCreditCard_NEW.Visible = True
            ClearCreditCardFields()
            Me.CC_cboCustomer.Text = ""
            Me.CC_cboCCType.Text = ""

            'btnCustPrice_NEW.Visible = True
            ClearCustPriceFields()
            Me.CP_cboCustomer.Text = ""
            Me.CP_cboPricingGroup.Text = ""
            Try
                Me.dtGrid.Clear()
                Me.dtGridExcpt.Clear()
            Catch exp As Exception
            End Try
            'btnLocation_New.Visible = True
            ClearLocationFields()
            LOC_cboCustomer.Text = ""
            LOC_ListBox.Items.Clear()

            enableLinkFields()

        End Sub
        Private Sub ClearCustWrtyFields()
            Me.CW_cboCustomer.Text = ""
            Me.CW_cboProduct.Text = ""
            Me.CW_cboWrtyLabor.Text = ""
            Me.CW_cboWrtyParts.Text = ""
            Me.CW_txtDaysInWrty.Text = ""
        End Sub
        Private Sub ClearCreditCardFields()
            Me.CC_cboCCType.Text = ""
            '            Me.CC_cboCustomer.Text = ""
            Me.CC_txtCCNumber.Text = ""
            Me.CC_txtAuthCode.Text = ""
            Me.CC_txtExpDate.Text = ""
        End Sub
        Private Sub ClearCustPriceFields()
            Me.CP_cboCustomer.Text = ""
            Me.CP_cboProduct.Text = ""
            Me.CP_cboPricingGroup.Text = ""
        End Sub


        Private Sub btnPricingGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPricingGroup.Click

            Dim frmPG As New OrderEntry.mtnPricingGroup()
            frmPG.ShowDialog()

        End Sub

        Private Sub disableLinkFields()

            PC_cboName.Enabled = False
            CUST_cboName.Enabled = False
            CUST_cboParentCo.Enabled = False
            CM_cboCustomer.Enabled = False
            CM_cboProduct.Enabled = False
            CC_cboCustomer.Enabled = False
            LOC_cboCustomer.Enabled = False
            CW_cboCustomer.Enabled = False
            CW_cboProduct.Enabled = False
            CP_cboCustomer.Enabled = False
            CP_cboProduct.Enabled = False

            If Len(Trim(CC_cboCustomer.Text)) < 1 Then
                CC_cboCustomer.Enabled = True
            End If

        End Sub

        Private Sub enableLinkFields()
            PC_cboName.Enabled = True
            CUST_cboName.Enabled = True
            CUST_cboParentCo.Enabled = True
            CM_cboCustomer.Enabled = True
            CM_cboProduct.Enabled = True
            CC_cboCustomer.Enabled = True
            LOC_cboCustomer.Enabled = True
            CW_cboCustomer.Enabled = True
            CW_cboProduct.Enabled = True
            CP_cboCustomer.Enabled = True
            CP_cboProduct.Enabled = True
        End Sub

        Private Sub btnCustomer_UPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer_UPDATE.Click

            Dim strError As String = VerifyCustomer_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim tmpName As String = Trim(CUST_cboName.Text)
                Dim strSQL As String = GenerateCustomerSQL_Update()
                Gui.Receiving.General.AuditCall("CustMaint_Customer_UPDATE", Trim(CUST_valCustID.Text), Controls)
                'Exit Sub
                Dim actInsert As New PSS.Data.Production.tcustomer()

                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                '                If tmpID > 0 Then 'FAILED
                '               MsgBox("Error Insert Parent Company Information", MsgBoxStyle.OKOnly)
                '              Else

                CUST_txtFName.Visible = False
                CUST_cboName.Visible = True
                GetCustomer(tmpID)
                btnCustomer_Save.Visible = False
                btnCustomer_Cancel.Visible = False
                refreshCustomerList()
                ClearCustomerFields()
                CUST_cboName.Text = ""
                btnCustomer_UPDATE.Visible = True
                '             End If

                ClearCustomerFields()

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()

                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page with the saved parent company
                For xCount = 0 To CUST_cboName.Items.Count - 1
                    If Trim(CUST_cboName.Items(xCount)) = tmpName Then
                        CUST_cboName.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub btnCustomerMarkup_NEW_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerMarkup_NEW.Click
            ClearCustomerFields()
            CUST_txtFName.Visible = True
            CUST_cboName.Visible = False
            btnCustomer_Save.Visible = True
            btnCustomer_Cancel.Visible = True
            btnCustomer_UPDATE.Visible = False
            CUST_txtFName.Focus()
        End Sub

        Private Sub btnCustomerMarkup_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerMarkup_Save.Click

            Dim strError As String = VerifyCustomerMarkup_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim tmpName As String = Trim(CM_cboCustomer.Text)
                Dim tmpProduct As String = Trim(CM_cboProduct.Text)

                Dim strSQL As String = GenerateCustMarkupSQL_Insert()
                Dim actInsert As New PSS.Data.Production.linvtrymethod()
                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                If tmpID < 1 Then 'FAILED
                    MsgBox("Error Insert Customer Markup Information", MsgBoxStyle.OKOnly)
                Else
                    btnCustomerMarkup_Save.Visible = False
                    btnCustomerMarkup_Cancel.Visible = False
                    'refreshcustomermarkupList()
                    ClearCustomerMarkupFields()
                    btnCustomerMarkup_UPDATE.Visible = True
                End If

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page
                For xCount = 0 To CM_cboCustomer.Items.Count - 1
                    If Trim(CM_cboCustomer.Items(xCount)) = tmpName Then
                        CM_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub btnCreditCard_UPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreditCard_UPDATE.Click

            Dim strError As String = VerifyCreditCard_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim tmpName As String = Trim(CC_cboCustomer.Text)

                Dim strSQL As String = GenerateCreditCardSQL_Update()
                Dim ccInsert As New PSS.Data.Production.tcreditcard()
                Dim tmpID As Int32 = ccInsert.idTransaction(strSQL)
                'If tmpID < 1 Then 'FAILED
                'MsgBox("Error Insert Credit Card Information", MsgBoxStyle.OKOnly)
                'Else
                ClearCreditCardFields()

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page
                For xCount = 0 To CC_cboCustomer.Items.Count - 1
                    If Trim(CC_cboCustomer.Items(xCount)) = tmpName Then
                        CC_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                enableLinkFields()

                'End If
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub CM_cboCustomer_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CM_cboCustomer.SelectedIndexChanged
            CM_txtRUR.Text = ""
            CM_txtNER.Text = ""
            CM_txtNTF.Text = ""
            CM_txtRTM.Text = ""
            CM_txtCustomer.Text = ""
            CM_txtMarkupInvt.Text = ""
            CM_cboInvMthdID.Text = ""
            CM_cboInvMthdID.Items.Clear()
            assignDataSet2cbControl(CM_cboInvMthdID, dsInvMthd, "linvtrymethod", "InvtryMdth_Desc")

            Dim tmpCustomer As Int32 = GetCustomerCMID()
            Dim tmpProduct As Int32 = GetProductCMID()
            System.Windows.Forms.Application.DoEvents()

            If tmpCustomer > 0 And tmpProduct > 0 Then
                GetCustomerMarkup(tmpCustomer, tmpProduct)
            End If
        End Sub

        Private Sub clearCMtextFields()
            CM_txtRUR.Text = ""
            CM_txtNER.Text = ""
            CM_txtNTF.Text = ""
            CM_txtCustomer.Text = ""
            CM_txtMarkupInvt.Text = ""
            CM_cboInvMthdID.Text = ""
        End Sub

        Private Sub CM_cboProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CM_cboProduct.SelectedIndexChanged
            CM_txtRUR.Text = ""
            CM_txtNER.Text = ""
            CM_txtNTF.Text = ""
            CM_txtRTM.Text = ""
            CM_txtCustomer.Text = ""
            CM_txtMarkupInvt.Text = ""
            CM_cboInvMthdID.Text = ""
            CM_cboInvMthdID.Items.Clear()
            assignDataSet2cbControl(CM_cboInvMthdID, dsInvMthd, "linvtrymethod", "InvtryMdth_Desc")

            Dim tmpCustomer As Int32 = GetCustomerCMID()
            Dim tmpProduct As Int32 = GetProductCMID()
            System.Windows.Forms.Application.DoEvents()

            If tmpCustomer > 0 And tmpProduct > 0 Then
                GetCustomerMarkup(tmpCustomer, tmpProduct)
            End If
        End Sub

        Private Sub btnCustomerMarkup_UPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerMarkup_UPDATE.Click
            Dim strError As String = VerifyCustomerMarkup_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try

                Dim tmpName As String = Trim(CM_cboCustomer.Text)
                Dim tmpProduct As String = Trim(CM_cboProduct.Text)

                Dim strSQL As String = GenerateCustMarkupSQL_Update()
                Dim actInsert As New PSS.Data.Production.linvtrymethod()
                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                'If tmpID < 1 Then 'FAILED
                'MsgBox("Error Updating Customer Markup Information", MsgBoxStyle.OKOnly)
                'Else
                btnCustomerMarkup_Save.Visible = False
                btnCustomerMarkup_Cancel.Visible = False
                'refreshcustomermarkupList()
                ClearCustomerMarkupFields()
                btnCustomerMarkup_UPDATE.Visible = True
                'End If


                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page
                For xCount = 0 To CM_cboCustomer.Items.Count - 1
                    If Trim(CM_cboCustomer.Items(xCount)) = tmpName Then
                        CM_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub CP_cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CP_cboCustomer.SelectedIndexChanged
            Try
                dtGrid.Clear()
                dtGridExcpt.Clear()

            Catch exp As Exception
            End Try
            CP_cboPricingGroup.Text = ""
            CP_cboPricingGroup.Items.Clear()
            assignDataSet2cbControl(CP_cboPricingGroup, dsPrcGroup, "lpricinggroup", "PrcGroup_LDesc")

            Dim tmpCustomer As Int32 = GetCustomerCPID()
            Dim tmpProduct As Int32 = GetProductCPID()
            System.Windows.Forms.Application.DoEvents()

            If tmpCustomer > 0 And tmpProduct > 0 Then
                GetCustomerPrice(tmpCustomer, tmpProduct)
            End If
        End Sub

        Private Sub CP_cboProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CP_cboProduct.SelectedIndexChanged
            Try
                dtGrid.Clear()
                dtGridExcpt.Clear()

            Catch exp As Exception
            End Try
            CP_cboPricingGroup.Text = ""
            CP_cboPricingGroup.Items.Clear()
            assignDataSet2cbControl(CP_cboPricingGroup, dsPrcGroup, "lpricinggroup", "PrcGroup_LDesc")

            Dim tmpCustomer As Int32 = GetCustomerCPID()
            Dim tmpProduct As Int32 = GetProductCPID()
            System.Windows.Forms.Application.DoEvents()

            If tmpCustomer > 0 And tmpProduct > 0 Then
                GetCustomerPrice(tmpCustomer, tmpProduct)
            End If
        End Sub

        Private Sub btnCustPrice_SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustPrice_SAVE.Click
            Dim strError As String = VerifyCustomer2Price_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim tmpName As String = Trim(CP_cboCustomer.Text)

                Dim strSQL As String = GenerateCustPriceSQL_Insert()
                Dim actInsert As New PSS.Data.Production.tcusttoprice()
                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                If tmpID < 1 Then 'FAILED
                    MsgBox("Error Insert Customer to Pricing Information", MsgBoxStyle.OKOnly)
                Else
                    btnCustPrice_SAVE.Visible = False
                    btnCustPrice_CANCEL.Visible = False
                    'refreshcustomermarkupList()
                    CP_cboCustomer.Text = ""
                    CP_cboProduct.Text = ""
                    CP_cboPricingGroup.Text = ""
                    btnCustPrice_UPDATE.Visible = True
                End If

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page
                For xCount = 0 To CP_cboCustomer.Items.Count - 1
                    If Trim(CP_cboCustomer.Items(xCount)) = tmpName Then
                        CP_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub btnCustPrice_UPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustPrice_UPDATE.Click
            Dim strError As String = VerifyCustomer2Price_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim tmpName As String = Trim(CP_cboCustomer.Text)

                Dim strSQL As String = GenerateCustPriceSQL_Update()
                Dim actInsert As New PSS.Data.Production.tcusttoprice()
                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                'If tmpID < 1 Then 'FAILED
                'MsgBox("Error Updating Customer to Pricing Information", MsgBoxStyle.OKOnly)
                'Else
                btnCustPrice_SAVE.Visible = False
                btnCustPrice_CANCEL.Visible = False
                'refreshcustomermarkupList()
                CP_cboCustomer.Text = ""
                CP_cboProduct.Text = ""
                CP_cboPricingGroup.Text = ""
                btnCustPrice_UPDATE.Visible = True
                'End If

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page
                For xCount = 0 To CP_cboCustomer.Items.Count - 1
                    If Trim(CP_cboCustomer.Items(xCount)) = tmpName Then
                        CP_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub LOC_cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOC_cboCustomer.SelectedIndexChanged
            ClearLocationFields()
            LOC_ListBox.Items.Clear()
            Dim tmpVal As Int32 = GetCustomerIDLoc()
            createLocationDataSet(tmpVal)
            GetCustomerLocation(tmpVal)
        End Sub

        Private Sub LOC_ListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOC_ListBox.SelectedIndexChanged
            Dim tmpVal As Int32 = GetCustomerIDLoc()
            GetLocation(tmpVal, LOC_ListBox.SelectedItem)
            LOC_txtAddress1.Focus()
            LOC_txtName.Enabled = False
        End Sub

        Private Sub btnLocation_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation_New.Click
            ClearLocationFields()
            LOC_cboCustomer.Enabled = False
            btnLocation_Cancel.Visible = True
            btnLocation_Save.Visible = True
            btnLocation_Update.Visible = False
            LOC_txtName.Enabled = True
            LOC_txtName.Focus()
        End Sub

        Private Sub btnLocation_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation_Cancel.Click
            ClearLocationFields()
            LOC_cboCustomer.Enabled = True
            btnLocation_Cancel.Visible = False
            btnLocation_Save.Visible = False
            btnLocation_Update.Visible = True
            'btnLocation_New.Visible = True
            LOC_cboCustomer.Focus()
        End Sub


        Private Sub btnLocation_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation_Update.Click
            Dim tmpName As String = Trim(LOC_cboCustomer.Text)
            Dim tmpLocation As String = Trim(LOC_ListBox.SelectedItem)

            Dim strError As String = VerifyLocation_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim strSQL As String = GenerateLocationSQL_Update()
                Dim actInsert As New PSS.Data.Production.tlocation()

                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                '                If tmpID > 0 Then 'FAILED
                '               MsgBox("Error Insert Parent Company Information", MsgBoxStyle.OKOnly)
                '              Else


                Dim tmpCustomer As Int32 = GetCustomerIDLoc()
                GetLocation(tmpCustomer, tmpLocation)
                GetLocation(tmpCustomer, tmpLocation)
                btnLocation_Save.Visible = False
                btnLocation_Cancel.Visible = False
                refreshLocationList()
                ClearLocationFields()
                'CUST_cboName.Text = ""
                btnLocation_Update.Visible = True
                '             End If


                Dim tmpCustName As String = Trim(LOC_cboCustomer.Text)

                ClearLocationFields()

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                LOC_txtName.Enabled = True
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page with the saved parent company
                For xCount = 0 To PC_cboName.Items.Count - 1
                    If Trim(LOC_cboCustomer.Items(xCount)) = tmpCustName Then
                        LOC_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub btnLocation_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation_Save.Click
            Dim tmpName As String = UCase(Trim(LOC_txtName.Text))
            Dim tmpCustName As String = Trim(LOC_cboCustomer.Text)

            Dim tmpLocation As String = Trim(LOC_ListBox.SelectedItem)
            For xCount = 0 To LOC_ListBox.Items.Count - 1
                If UCase(Trim(LOC_ListBox.Items(xCount))) = UCase(tmpName) Then
                    MsgBox("A record already uses this description. Plesae try again or cancel.", MsgBoxStyle.OKOnly, "Error")
                    Exit Sub
                End If
            Next

            Dim tmpLocationCheck As New PSS.Data.Production.tlocation()
            Dim dtLocationCheck As DataSet = tmpLocationCheck.GetData
            Dim rLocCheck As DataRow
            For xCount = 0 To dtLocationCheck.Tables("tlocation").Rows.Count - 1
                rLocCheck = dtLocationCheck.Tables("tlocation").Rows(xCount)
                If IsDBNull(rLocCheck("Loc_Name")) = False Then
                    If Trim(rLocCheck("Loc_Name")) = tmpName Then
                        MsgBox("A record already uses this description. Plesae try again or cancel.", MsgBoxStyle.OKOnly, "Error")
                        Exit Sub
                    End If
                End If
            Next


            Dim strError As String = VerifyLocation_beforeInsert()

            If Len(strError) > 0 Then
                '//Throw error
                MsgBox(strError, MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            '//Generate sql and execute
            Try
                Dim strSQL As String = GenerateLocationSQL_Insert()
                Dim actInsert As New PSS.Data.Production.tlocation()
                Dim tmpID As Int32 = actInsert.idTransaction(strSQL)
                If tmpID < 1 Then 'FAILED
                    MsgBox("Error Insert Customer Information", MsgBoxStyle.OKOnly)
                Else
                    'loc_txtFName.Visible = False
                    'CUST_cboName.Visible = True
                    Dim tmpCustomer As Int32 = GetCustomerIDLoc()
                    GetLocation(tmpCustomer, tmpName)
                    btnLocation_Save.Visible = False
                    btnLocation_Cancel.Visible = False
                    refreshLocationList()


                    '                    ClearCustomerFields()
                    'CUST_cboName.Text = ""
                    '                    btncustomer_UPDATE.Visible = True

                    ClearLocationFields()

                End If

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()
                System.Windows.Forms.Application.DoEvents()

                '//repopulate the page with the saved parent company
                For xCount = 0 To LOC_cboCustomer.Items.Count - 1
                    If Trim(LOC_cboCustomer.Items(xCount)) = tmpCustName Then
                        LOC_cboCustomer.SelectedIndex = xCount
                        Exit For
                    End If
                Next
                enableLinkFields()

            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            reloadSelectCustomer()
        End Sub

        Private Sub btnPrcGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrcGroup.Click
            Dim frmPG As New OrderEntry.mtnPricingGroup()
            frmPG.ShowDialog()
        End Sub

        Private Sub CP_cboPricingGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CP_cboPricingGroup.SelectedIndexChanged
            Try
                Me.dtGrid.Clear()
                Me.dtGridExcpt.Clear()
            Catch exp As Exception
            End Try

            Dim dsPricingGroup As DataSet
            Dim pricingGroupID As Int32

            Dim r As DataRow
            Dim valProd As Integer = convertProduct(r)
            Dim tblPG As New PSS.Data.Production.lpricinggroup()
            dsPricingGroup = tblPG.GetRowsByProdID(valProd)
            tblPG = Nothing

            '//get the ID for Pricing Group
            For xCount = 0 To dsPricingGroup.Tables("lpricinggroup").Rows.Count - 1
                r = dsPricingGroup.Tables("lpricinggroup").Rows(xCount)
                If r("PrcGroup_LDesc") = CP_cboPricingGroup.Text Then
                    pricingGroupID = r("PrcGroup_ID")
                    Exit For
                End If
            Next

            '//get data from tlaborprc
            Dim tblLaborPrc As New PSS.Data.Production.Joins()
            Dim dtLaborPrc As DataTable = tblLaborPrc.GetLaborPricingByPrcGroupProdID(valProd, pricingGroupID)

            Dim tblBillExcpt As New PSS.Data.Production.Joins()
            Dim dtBillExcpt As DataTable = tblBillExcpt.OrderEntrySelect("SELECT lpricinggroup.PrcGroup_LDesc," & _
            " lprodgrp.ProdGrp_LDesc, lbillcodes.BillCode_Desc, tbillexcpttype.BillExcptType_Desc from" & _
            " ((((tbillexcpt INNER JOIN lpricinggroup ON tbillexcpt.PrcGroup_ID = lpricinggroup.PrcGroup_ID)" & _
            " INNER JOIN lprodgrp ON tbillexcpt.ProdGrp_ID = lprodgrp.ProdGrp_ID)" & _
            " INNER JOIN lbillcodes ON tbillexcpt.BillCode_ID = lbillcodes.BillCode_ID)" & _
            " INNER JOIN tbillexcpttype ON tbillexcpt.BillExcptType_ID = tbillexcpttype.BillExcptType_ID)" & _
            " WHERE tbillexcpt.PrcGroup_ID = " & pricingGroupID & " ORDER BY ProdGrp_LDesc, BillCode_Desc")

            '//Populate the grid
            dtGrid.Clear() '//Empty before refilling
            For xCount = 0 To dtLaborPrc.Rows.Count - 1
                r = dtLaborPrc.Rows(xCount)
                Dim dr1 As DataRow = dtGrid.NewRow
                dr1("Product Group") = Trim(r("ProdGrp_LDesc"))
                If IsDBNull(r("LaborLvl_ID")) = False Then
                    dr1("Labor Level") = Trim(r("LaborLvl_ID"))
                End If
                If IsDBNull(r("LaborPrc_RegPrc")) = False Then
                    dr1("Regular Pricing") = Trim(r("LaborPrc_RegPrc"))
                End If
                If IsDBNull(r("LaborPrc_WrtyPrc")) = False Then
                    dr1("Warranty Pricing") = Trim(r("LaborPrc_WrtyPrc"))
                End If
                dtGrid.Rows.Add(dr1)
            Next

            tdbGrid.DataSource = dtGrid

            '//Populate the grid
            dtGridExcpt.Clear() '//Empty before refilling
            For xCount = 0 To dtBillExcpt.Rows.Count - 1
                r = dtBillExcpt.Rows(xCount)
                Dim dr2 As DataRow = dtGridExcpt.NewRow
                If IsDBNull(r("ProdGrp_LDesc")) = False Then
                    dr2("Product Group") = Trim(r("ProdGrp_LDesc"))
                End If
                If IsDBNull(r("BillCode_Desc")) = False Then
                    dr2("Bill Code") = Trim(r("BillCode_Desc"))
                End If
                If IsDBNull(r("BillExcptType_Desc")) = False Then
                    dr2("Exception Type") = Trim(r("BillExcptType_Desc"))
                End If
                dtGridExcpt.Rows.Add(dr2)
            Next

            tdbGridExcpt.DataSource = dtGridExcpt
        End Sub

        Private Sub create_dtGrid()
            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim colProdGrp As New DataColumn("Product Group")
            dtGrid.Columns.Add(colProdGrp)
            Dim colLaborLevel As New DataColumn("Labor Level")
            dtGrid.Columns.Add(colLaborLevel)
            Dim colRegPrc As New DataColumn("Regular Pricing")
            dtGrid.Columns.Add(colRegPrc)
            Dim colWrtyPrc As New DataColumn("Warranty Pricing")
            dtGrid.Columns.Add(colWrtyPrc)
        End Sub

        Private Sub create_dtGridExcpt()
            dtGridExcpt.MinimumCapacity = 500
            dtGridExcpt.CaseSensitive = False
            Dim colProductGroup As New DataColumn("Product Group")
            dtGridExcpt.Columns.Add(colProductGroup)
            Dim colBillCode As New DataColumn("Bill Code")
            dtGridExcpt.Columns.Add(colBillCode)
            Dim colBillCodeExcpt As New DataColumn("Exception Type")
            dtGridExcpt.Columns.Add(colBillCodeExcpt)
        End Sub

        Private Function convertProduct(ByVal ar As DataRow) As Int32
            Dim tblProd As New PSS.Data.Production.lproduct()
            Dim dsprod As DataSet

            dsprod = tblProd.GetData

            For xCount = 0 To dsprod.Tables("lproduct").Rows.Count - 1
                ar = dsprod.Tables("lproduct").Rows(xCount)
                If ar("Prod_Desc") = CP_cboProduct.Text Then
                    convertProduct = ar("Prod_ID")
                    Exit For
                End If
            Next
        End Function

        Private Sub disableButtons()
            btnParentCo_NEW.Enabled = False
            btnParentCo_SAVE.Enabled = False
            btnParentCo_UPDATE.Enabled = False

            btnCustomer_NEW.Enabled = False
            btnCustomer_Save.Enabled = False
            btnCustomer_UPDATE.Enabled = False

            btnLocation_New.Enabled = False
            btnLocation_Save.Enabled = False
            btnLocation_Update.Enabled = False

            btnCustWrty_NEW.Enabled = False
            btnCustWrty_SAVE.Enabled = False
            btnCustWrty_UPDATE.Enabled = False

            btnCustomerMarkup_NEW.Enabled = False
            btnCustomerMarkup_Save.Enabled = False
            btnCustomerMarkup_UPDATE.Enabled = False

            btnCustPrice_NEW.Enabled = False
            btnCustPrice_SAVE.Enabled = False
            btnCustPrice_UPDATE.Enabled = False

            btnCreditCard_NEW.Enabled = False
            btnCreditCard_SAVE.Enabled = False
            btnCreditCard_UPDATE.Enabled = False
        End Sub

        Private Sub btnChangeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeName.Click
            Dim custID As Int32 = 0
            custID = GetCustomerID()
            If custID > 0 Then

                Dim response As String
                response = InputBox("Enter new name for customer: " & CUST_cboName.Text, "New Name", "", , )
                If Len(Trim(response)) > 0 Then
                    Dim updVal As New PSS.Data.Production.Joins()
                    Dim blnUPD As Boolean = updVal.OrderEntryUpdateDelete("UPDATE tcustomer SET cust_name1 = '" & response & "' WHERE cust_id = " & custID)
                End If

                CUST_txtFName.Visible = False
                CUST_cboName.Visible = True
                GetCustomer(custID)
                btnCustomer_Save.Visible = False
                btnCustomer_Cancel.Visible = False
                refreshCustomerList()
                ClearCustomerFields()
                CUST_cboName.Text = ""
                btnCustomer_UPDATE.Visible = True
                '             End If

                ClearCustomerFields()

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()

                System.Windows.Forms.Application.DoEvents()

                ''//repopulate the page with the saved parent company
                'For xCount = 0 To CUST_cboName.Items.Count - 1
                'If Trim(CUST_cboName.Items(xCount)) = tmpName Then
                '    CUST_cboName.SelectedIndex = xCount
                '    Exit For
                'End If
                'Next
                enableLinkFields()
                populateCustomerSelect()
            Else
                MsgBox("The customer name could not be updated contact IT.", MsgBoxStyle.OKOnly, "ERROR")
            End If
        End Sub

        Private Sub btnChangeParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeParent.Click
            Dim PcoID As Int32 = 0
            PcoID = Me.GetParentCoID
            If PcoID > 0 Then

                Dim response As String
                response = InputBox("Enter new name for parent: " & PC_cboName.Text, "New Name", "", , )
                If Len(Trim(response)) > 0 Then
                    Dim updVal As New PSS.Data.Production.Joins()
                    Dim blnUPD As Boolean = updVal.OrderEntryUpdateDelete("UPDATE lparentco SET PCo_name = '" & response & "' WHERE pco_id = " & PcoID)
                End If

                PC_txtName.Visible = False
                PC_cboName.Visible = True
                '                GetParentCo(tmpID)
                btnParentCo_SAVE.Visible = False
                btnParentCo_CANCEL.Visible = False
                refreshParentCoList()
                ClearParentCoFields()
                PC_cboName.Text = ""
                btnParentCo_UPDATE.Visible = True

                clearComboBoxesALL()
                clearDatasets()
                populateComboBoxesALL()

                System.Windows.Forms.Application.DoEvents()

                ''//repopulate the page with the saved parent company
                'For xCount = 0 To PC_cboName.Items.Count - 1
                'If Trim(PC_cboName.Items(xCount)) = Trim(tmpName) Then
                '    PC_cboName.SelectedIndex = xCount
                '    Exit For
                'End If
                'Next

                populateCustomerSelect()
            Else
                MsgBox("The customer name could not be updated contact IT.", MsgBoxStyle.OKOnly, "ERROR")
            End If
        End Sub

        Private Sub clearPreloadCustomer()
            chkPLCarrier.Checked = False
            chkPLShipTo.Checked = False
            chkPLquantity.Checked = False
            chkPLPRL.Checked = False
            chkPLIP.Checked = False
            chkPLRAQuantity.Checked = False
            chkPLSKU.Checked = False
            chkPLWarranty.Checked = False
            chkPLDockDate.Checked = False
            chkPLDateCode.Checked = False
            chkPLPOP.Checked = False
            chkPLAPC.Checked = False
            chkPLIncIMEI.Checked = False
            chkPLCourierTrackIN.Checked = False
            chkPLAirTimeCarrier.Checked = False
            chkPLTransaction.Checked = False
            chkPLTransceiver.Checked = False
            chkPLCarrierModel.Checked = False
            chkPLMIN.Checked = False
            chkPLProduct.Checked = False
            chkPLComplaint.Checked = False
            chkPLReturn.Checked = False
        End Sub


        Private Sub loadPreloadCustomer(ByVal mCustID As Int32)
            Dim tchk As PSS.Data.Production.Joins
            Dim dtchk As DataTable = tchk.OrderEntrySelect("SELECT * from tpreloadcust WHERE Cust_ID = " & mCustID)
            If dtchk.Rows.Count < 1 Then
                '//No Information to Display
            Else
                chkPLCarrier.Checked = False
                chkPLShipTo.Checked = False
                chkPLquantity.Checked = False
                chkPLPRL.Checked = False
                chkPLIP.Checked = False
                chkPLRAQuantity.Checked = False
                chkPLSKU.Checked = False
                chkPLWarranty.Checked = False
                chkPLDockDate.Checked = False
                chkPLDateCode.Checked = False
                chkPLPOP.Checked = False
                chkPLAPC.Checked = False
                chkPLIncIMEI.Checked = False
                chkPLCourierTrackIN.Checked = False
                chkPLAirTimeCarrier.Checked = False
                chkPLTransaction.Checked = False
                chkPLTransceiver.Checked = False
                chkPLCarrierModel.Checked = False
                chkPLMIN.Checked = False
                chkPLProduct.Checked = False
                chkPLComplaint.Checked = False
                chkPLReturn.Checked = False

                Dim r As DataRow
                r = dtchk.Rows(0)
                If r("plcust_Carrier") = 1 Then chkPLCarrier.Checked = True
                If r("plcust_ShipTo") = 1 Then chkPLShipTo.Checked = True
                If r("plcust_Quantity") = 1 Then chkPLquantity.Checked = True
                If r("plcust_PRL") = 1 Then chkPLPRL.Checked = True
                If r("plcust_IP") = 1 Then chkPLIP.Checked = True
                If r("plcust_WOQuantity") = 1 Then chkPLRAQuantity.Checked = True
                If r("plcust_SKU") = 1 Then chkPLSKU.Checked = True
                If r("plcust_Warranty") = 1 Then chkPLWarranty.Checked = True
                If r("plcust_DockDate") = 1 Then chkPLDockDate.Checked = True
                If r("plcust_DateCode") = 1 Then chkPLDateCode.Checked = True
                If r("plcust_POP") = 1 Then chkPLPOP.Checked = True
                If r("plcust_APC") = 1 Then chkPLAPC.Checked = True
                If r("plcust_IncIMEI") = 1 Then chkPLIncIMEI.Checked = True
                If r("plcust_CourierTrackIN") = 1 Then chkPLCourierTrackIN.Checked = True
                If r("plcust_AirTimeCode") = 1 Then chkPLAirTimeCarrier.Checked = True
                If r("plcust_Transaction") = 1 Then chkPLTransaction.Checked = True
                If r("plcust_Transceiver") = 1 Then chkPLTransceiver.Checked = True
                If r("plcust_CarrierCode") = 1 Then chkPLCarrierModel.Checked = True
                If r("plcust_MIN") = 1 Then chkPLMIN.Checked = True
                If r("plcust_Product") = 1 Then chkPLProduct.Checked = True
                If r("plcust_Complaint") = 1 Then chkPLComplaint.Checked = True
                If r("plcust_Return") = 1 Then chkPLReturn.Checked = True
            End If
        End Sub


        Private Sub PopulateCustomerPreLoad()
            Dim tblCust As New PSS.Data.Production.tcustomer()
            Dim dtCustPL As DataTable = tblCust.GetCustomersOrdered

            cboCustomerPreLoad.DataSource = dtCustPL
            cboCustomerPreLoad.DisplayMember = dtCustPL.Columns("Cust_Name1").ToString
            cboCustomerPreLoad.ValueMember = dtCustPL.Columns("Cust_ID").ToString
        End Sub

        Private Sub btnPLSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPLSave.Click
            If cboCustomerPreLoad.SelectedValue > 0 Then

                '//Verify if customer already has a record for this table
                Dim tchk As PSS.Data.Production.Joins
                Dim dtchk As DataTable = tchk.OrderEntrySelect("SELECT * from tpreloadcust WHERE Cust_ID = " & cboCustomerPreLoad.SelectedValue)

                If dtchk.Rows.Count < 1 Then
                    Dim blnchk As Boolean = tchk.OrderEntryUpdateDelete("INSERT INTO tpreloadcust(Cust_ID) VALUES (" & cboCustomerPreLoad.SelectedValue & ")")
                End If

                Dim strSQL As String = "UPDATE tpreloadcust SET "

                If chkPLCarrier.Checked = True Then
                    strSQL += "plcust_Carrier = 1,"
                Else
                    strSQL += "plcust_Carrier = 0,"
                End If

                If chkPLShipTo.Checked = True Then
                    strSQL += "plcust_ShipTo = 1,"
                Else
                    strSQL += "plcust_ShipTo = 0,"
                End If

                If chkPLquantity.Checked = True Then
                    strSQL += "plcust_quantity = 1,"
                Else
                    strSQL += "plcust_quantity = 0,"
                End If

                If chkPLPRL.Checked = True Then
                    strSQL += "plcust_PRL = 1,"
                Else
                    strSQL += "plcust_PRL = 0,"
                End If

                If chkPLIP.Checked = True Then
                    strSQL += "plcust_IP = 1,"
                Else
                    strSQL += "plcust_IP = 0,"
                End If

                If chkPLRAQuantity.Checked = True Then
                    strSQL += "plcust_WOQuantity = 1,"
                Else
                    strSQL += "plcust_WOQuantity = 0,"
                End If

                If chkPLSKU.Checked = True Then
                    strSQL += "plcust_SKU = 1,"
                Else
                    strSQL += "plcust_SKU = 0,"
                End If

                If chkPLDefaultSku.Checked = True Then
                    strSQL += "plcust_DefaultSKU = 1,"
                Else
                    strSQL += "plcust_DefaultSKU = 0,"
                End If

                If chkPLWarranty.Checked = True Then
                    strSQL += "plcust_Warranty = 1,"
                Else
                    strSQL += "plcust_Warranty = 0,"
                End If

                If chkPLDockDate.Checked = True Then
                    strSQL += "plcust_DockDate = 1,"
                Else
                    strSQL += "plcust_DockDate = 0,"
                End If

                If chkPLDateCode.Checked = True Then
                    strSQL += "plcust_DateCode = 1,"
                Else
                    strSQL += "plcust_DateCode = 0,"
                End If

                If chkPLPOP.Checked = True Then
                    strSQL += "plcust_POP = 1,"
                Else
                    strSQL += "plcust_POP = 0,"
                End If

                If chkPLAPC.Checked = True Then
                    strSQL += "plcust_APC = 1,"
                Else
                    strSQL += "plcust_APC = 0,"
                End If

                If chkPLIncIMEI.Checked = True Then
                    strSQL += "plcust_IncIMEI = 1,"
                Else
                    strSQL += "plcust_IncIMEI = 0,"
                End If

                If chkPLCourierTrackIN.Checked = True Then
                    strSQL += "plcust_CourierTrackIN = 1,"
                Else
                    strSQL += "plcust_CourierTrackIN = 0,"
                End If

                If chkPLAirTimeCarrier.Checked = True Then
                    strSQL += "plcust_AirTimeCode = 1,"
                Else
                    strSQL += "plcust_AirTimeCode = 0,"
                End If

                If chkPLTransaction.Checked = True Then
                    strSQL += "plcust_Transaction = 1,"
                Else
                    strSQL += "plcust_Transaction = 0,"
                End If

                If chkPLTransceiver.Checked = True Then
                    strSQL += "plcust_Transceiver = 1,"
                Else
                    strSQL += "plcust_Transceiver = 0,"
                End If

                If chkPLCarrierModel.Checked = True Then
                    strSQL += "plcust_CarrierCode = 1,"
                Else
                    strSQL += "plcust_CarrierCode = 0,"
                End If

                If chkPLMIN.Checked = True Then
                    strSQL += "plcust_MIN = 1,"
                Else
                    strSQL += "plcust_MIN = 0,"
                End If

                If chkPLProduct.Checked = True Then
                    strSQL += "plcust_Product = 1,"
                Else
                    strSQL += "plcust_Product = 0,"
                End If

                If chkPLComplaint.Checked = True Then
                    strSQL += "plcust_Complaint = 1,"
                Else
                    strSQL += "plcust_Complaint = 0,"
                End If

                If chkPLReturn.Checked = True Then
                    strSQL += "plcust_Return = 1,"
                Else
                    strSQL += "plcust_Return = 0,"
                End If

                If chkUPC.Checked = True Then
                    strSQL += "plcust_UPC = 1,"
                Else
                    strSQL += "plcust_UPC = 0,"
                End If

                If chkPO.Checked = True Then
                    strSQL += "plcust_PO = 1"
                Else
                    strSQL += "plcust_PO = 0"
                End If


                strSQL += " WHERE Cust_ID = " & cboCustomerPreLoad.SelectedValue
                Dim tUpdate As New PSS.Data.Production.Joins()

                If cboCustomerPreLoad.SelectedValue > 0 Then
                    Dim blnUpdateSuccess As Boolean = tUpdate.OrderEntryUpdateDelete(strSQL)
                End If

                clearPreloadCustomer()

            End If

            clearPreloadCustomer()

            System.Windows.Forms.Application.DoEvents()
            cboCustomerPreLoad.Text = ""

            If Len(Trim(cboSelectCustomer.Text)) > 0 Then
                Dim aIndex As Integer
                With cboCustomerPreLoad
                    For aIndex = 0 To .Items.Count - 1
                        If CType(.Items(aIndex)(1), String).Trim = cboSelectCustomer.Text.Trim Then
                            .SelectedIndex = aIndex
                            Exit For
                        End If
                    Next
                    If aIndex >= .Items.Count Then .SelectedIndex = -1
                End With
            End If

        End Sub

        Private Sub cboCustomerPreLoad_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomerPreLoad.SelectedValueChanged
            Try
                clearPreloadCustomer()
                loadPreloadCustomer(cboCustomerPreLoad.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click

            If Len(Trim(LOC_txtName.Text)) > 0 Then

                Dim dtOpt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tlocation WHERE Loc_Name = '" & LOC_txtName.Text & "'")
                Dim vLocID As Int32
                Dim strLocName As String
                Dim r As DataRow
                Dim x As Integer = 0

                Dim frmOptions As New frmLocOptInfo()
                For x = 0 To dtOpt.Rows.Count - 1
                    r = dtOpt.Rows(x)
                    vLocID = r("Loc_ID")
                    strLocName = r("Loc_Name")
                    Exit For
                Next

                frmOptions.intLocOptions = vLocID
                frmOptions.strLocOptions = strLocName
                frmOptions.lblMain.Text = strLocName
                frmOptions.ShowDialog()

            End If
        End Sub

        Private Sub loadAggCodes()
            Dim ds As PSS.Data.Production.Joins
            dtAggCodes = ds.OrderEntrySelect("SELECT Billcode_ID, Billcode_Desc FROM lbillcodes WHERE AggBill = 1")

            lstAggCodes.DataSource = dtAggCodes
            lstAggCodes.DisplayMember = dtAggCodes.Columns(1).ToString
            lstAggCodes.ValueMember = dtAggCodes.Columns(0).ToString

            ds = Nothing
        End Sub


        Private Sub loadDefinedAggCodes()
            txtBillCode.Text = ""
            txtAmount.Text = ""

            Dim ds As PSS.Data.Production.Joins
            dtDefinedAggCodes = ds.OrderEntrySelect("SELECT Billcode_Desc, tcustaggregatebilling.BillCode_ID, tcab_Amount FROM tcustaggregatebilling inner join lbillcodes on tcustaggregatebilling.billcode_id = lbillcodes.billcode_id WHERE Cust_ID = " & CustomerSelect)

            gridAggregate.DataSource = dtDefinedAggCodes
            ds = Nothing
        End Sub


        Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim ds As PSS.Data.Production.Joins

            Dim valID As Integer = Me.lstAggCodes.SelectedValue
            Dim valAmount As Double = Me.txtAmount.Text
            Dim valCustomer As Integer = CustomerSelect

            Dim blnInsert As Boolean


            If blnAggInsert = False Then
                blnInsert = ds.OrderEntryUpdateDelete("INSERT INTO tcustaggregatebilling (cust_id, billcode_id, tcab_amount) VALUES (" & valCustomer & ", " & valID & ", " & valAmount & ")")
            Else
                blnInsert = ds.OrderEntryUpdateDelete("UPDATE tcustaggregatebilling set tcab_amount = " & valAmount & " WHERE Cust_ID = " & valCustomer & " AND billcode_ID =  " & valID)
            End If

            blnAggInsert = False

            Me.loadDefinedAggCodes()
        End Sub


        Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim ds As PSS.Data.Production.Joins

            Dim valID As Integer = Me.lstAggCodes.SelectedValue
            Dim valAmount As Double = Me.txtAmount.Text
            Dim valCustomer As Integer = CustomerSelect

            Dim blnInsert As Boolean

            If valID > 0 And valCustomer > 0 And valAmount <> 0 Then
                blnInsert = ds.OrderEntryUpdateDelete("DELETE FROM tcustaggregatebilling WHERE Cust_ID = " & valCustomer & " AND billcode_ID =  " & valID)
            End If

            Me.loadDefinedAggCodes()
        End Sub


        Private Sub btnInsert_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
            Dim ds As PSS.Data.Production.Joins

            Dim valID As Integer = Me.lstAggCodes.SelectedValue
            Dim valAmount As Double = Me.txtAmount.Text
            Dim valCustomer As Integer = CustomerSelect

            Dim blnInsert As Boolean


            If blnAggInsert = False Then
                blnInsert = ds.OrderEntryUpdateDelete("INSERT INTO tcustaggregatebilling (cust_id, billcode_id, tcab_amount) VALUES (" & valCustomer & ", " & valID & ", " & valAmount & ")")
            Else
                blnInsert = ds.OrderEntryUpdateDelete("UPDATE tcustaggregatebilling set tcab_amount = " & valAmount & " WHERE Cust_ID = " & valCustomer & " AND billcode_ID =  " & valID)
            End If

            blnAggInsert = False

            Me.loadDefinedAggCodes()
        End Sub

        Private Sub btnRemove_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
            Dim ds As PSS.Data.Production.Joins

            Dim valID As Integer = Me.lstAggCodes.SelectedValue
            Dim valAmount As Double = Me.txtAmount.Text
            Dim valCustomer As Integer = CustomerSelect

            Dim blnInsert As Boolean

            If valID > 0 And valCustomer > 0 And valAmount <> 0 Then
                blnInsert = ds.OrderEntryUpdateDelete("DELETE FROM tcustaggregatebilling WHERE Cust_ID = " & valCustomer & " AND billcode_ID =  " & valID)
            End If

            Me.loadDefinedAggCodes()
        End Sub

        Private Sub lstAggCodes_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAggCodes.MouseUp
            blnAggInsert = False

            txtBillCode.Text = ""
            txtAmount.Text = ""


            Dim xCount As Integer
            Dim r As DataRow
            For xCount = 0 To dtAggCodes.Rows.Count - 1
                r = dtAggCodes.Rows(xCount)
                If r(0) = lstAggCodes.SelectedValue Then
                    Me.txtBillCode.Text = r(1)
                    Exit For
                End If
            Next

            blnAggInsert = False

            '//Verify that the data is not already in the table - if so then use values form that
            'MsgBox(CustomerSelect)

            For xCount = 0 To Me.dtDefinedAggCodes.Rows.Count - 1
                r = dtDefinedAggCodes.Rows(xCount)
                If r("Billcode_ID") = lstAggCodes.SelectedValue Then
                    txtBillCode.Text = r("BillCode_Desc")
                    txtAmount.Text = r("tcab_Amount")

                    blnAggInsert = True

                    Exit For
                End If
            Next
        End Sub

#Region "Update Labor"

        '************************************************************************************
        Private Sub tpgUpdLabor_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgUpdLabor.VisibleChanged
            Dim dt As DataTable
            Try
                If Me.pnlUpdateLabor.Visible = True AndAlso Me.tpgUpdLabor.Visible = True Then
                    If Me.cboULCustomers.DataSource = Nothing Then
                        Me.cboULCustomers.DataSource = Nothing
                        dt = PSS.Data.Buisness.Generic.GetCustomers(True, )
                        Misc.PopulateC1DropDownList(Me.cboULCustomers, dt, "Cust_Name1", "Cust_ID")
                        Me.cboULCustomers.SelectedValue = 0
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpgUpdLabor_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '************************************************************************************
        Private Sub cboULCustomers_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboULCustomers.Leave
            Dim dt As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc
            Try
                If Me.pnlUpdateLabor.Visible = True AndAlso Me.tpgUpdLabor.Visible = True Then
                    If Me.cboULCustomers.SelectedValue > 0 Then
                        Me.cboULModels.DataSource = Nothing
                        objMisc = New PSS.Data.Buisness.Misc()
                        dt = objMisc.GetModelsByCustID(Me.cboULCustomers.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboULModels, dt, "Model_Desc", "Model_ID")
                        Me.cboULModels.SelectedValue = 0
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboULCustomers_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                objMisc = Nothing
            End Try
        End Sub

        '************************************************************************************
        Private Sub btnUpdateLabor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateLabor.Click
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objDevice As PSS.Rules.Device
            Dim strShipStartDate, strShipEndDate As String
            Dim booInWipDevices As Boolean = False

            Try
                If Me.cboULCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboULCustomers.Focus()
                ElseIf IsNothing(Me.cboULModels.DataSource) Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboULCustomers.Focus()
                ElseIf Me.chkInWip.Checked = False And Me.chkULProdShipDate.Checked = False Then
                    MessageBox.Show("Please either select In WIP devices or Production Ship Date devices.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Me.Cursor.Current = Cursors.WaitCursor

                    'Select device by production ship date
                    strShipStartDate = "" : strShipEndDate = ""
                    If Me.chkULProdShipDate.Checked = True Then
                        strShipStartDate = CStr(Format(Me.dtULShipStartDate.Value, "yyyy-MM-dd")) : strShipEndDate = CStr(Format(Me.dtpULShipEndDate.Value, "yyyy-MM-dd"))
                    End If

                    'select device by ship date is null
                    If Me.chkInWip.Checked = True Then
                        booInWipDevices = True
                    End If

                    objMisc = New PSS.Data.Buisness.Misc()
                    dt = objMisc.GetDeviceIDs(Me.cboULCustomers.SelectedValue, Me.cboULModels.SelectedValue, booInWipDevices, strShipStartDate, strShipEndDate)
                    If Not IsNothing(dt) Then
                        For Each R1 In dt.Rows
                            objDevice = New PSS.Rules.Device(R1("Device_ID"))
                            objDevice.Update()
                            objDevice.Dispose()
                            objDevice = Nothing
                        Next R1

                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboULCustomers_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '************************************************************************************
        Private Sub chkProdShipDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkULProdShipDate.CheckedChanged
            If Me.chkULProdShipDate.Checked = True Then
                Me.pnlULShipDate.Visible = True
                Me.chkInWip.Checked = False
            Else
                Me.pnlULShipDate.Visible = False
            End If
        End Sub

        '************************************************************************************
        Private Sub chkInWip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInWip.CheckedChanged
            If Me.chkInWip.Checked = True Then
                Me.chkULProdShipDate.Checked = False
            End If
        End Sub

        '************************************************************************************
#End Region

        
    End Class

End Namespace
