Imports PSS.Core.Global
Imports PSS.Data.Buisness

Namespace Gui.CustomerMaint

    Public Class frmCustMaint
        Inherits System.Windows.Forms.Form

        Private _objCustMaintain As CustMaintNew
        Private _booLoadData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objCustMaintain = New CustMaintNew()
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
        Friend WithEvents ctrlTab As System.Windows.Forms.TabControl
        Friend WithEvents Label55 As System.Windows.Forms.Label
        Friend WithEvents CP_cboPricingGroup As System.Windows.Forms.ComboBox
        Friend WithEvents CP_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents Label54 As System.Windows.Forms.Label
        Friend WithEvents CC_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents CC_txtCCNumber As System.Windows.Forms.TextBox
        Friend WithEvents CC_cboCCType As System.Windows.Forms.ComboBox
        Friend WithEvents Label24 As System.Windows.Forms.Label
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents CC_txtName As System.Windows.Forms.TextBox
        Friend WithEvents CM_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents CM_cboInvMthdID As System.Windows.Forms.ComboBox
        Friend WithEvents CM_txtNER As System.Windows.Forms.TextBox
        Friend WithEvents CM_txtRUR As System.Windows.Forms.TextBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents CM_cboProduct As System.Windows.Forms.ComboBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
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
        Friend WithEvents lblPCname As System.Windows.Forms.Label
        Friend WithEvents PC_txtName As System.Windows.Forms.TextBox
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
        Friend WithEvents lblLocationStatus As System.Windows.Forms.Label
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents CP_cboProduct As System.Windows.Forms.ComboBox
        Friend WithEvents Label56 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblHighlight As System.Windows.Forms.Label
        Friend WithEvents Label57 As System.Windows.Forms.Label
        Friend WithEvents Label58 As System.Windows.Forms.Label
        Friend WithEvents Label59 As System.Windows.Forms.Label
        Friend WithEvents Label60 As System.Windows.Forms.Label
        Friend WithEvents Label61 As System.Windows.Forms.Label
        Friend WithEvents tbParent As System.Windows.Forms.TabPage
        Friend WithEvents tbCustWrty As System.Windows.Forms.TabPage
        Friend WithEvents tbCreditCard As System.Windows.Forms.TabPage
        Friend WithEvents tbLocation As System.Windows.Forms.TabPage
        Friend WithEvents tbCustMarkup As System.Windows.Forms.TabPage
        Friend WithEvents tbCustomer As System.Windows.Forms.TabPage
        Friend WithEvents tbCust2Price As System.Windows.Forms.TabPage
        Friend WithEvents Label62 As System.Windows.Forms.Label
        Friend WithEvents tbSearch As System.Windows.Forms.TabPage
        Friend WithEvents searchGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblException As System.Windows.Forms.Label
        Friend WithEvents CUST_cboInvoiceDetail As System.Windows.Forms.ComboBox
        Friend WithEvents Label63 As System.Windows.Forms.Label
        Friend WithEvents CC_txtAuthCode As System.Windows.Forms.TextBox
        Friend WithEvents lblAuthCode As System.Windows.Forms.Label
        Friend WithEvents CUST_valCustID As System.Windows.Forms.TextBox
        Friend WithEvents lblCMplusParts As System.Windows.Forms.Label
        Friend WithEvents CUST_chkINACTIVE As System.Windows.Forms.CheckBox
        Friend WithEvents CUST_txtMemo As System.Windows.Forms.TextBox
        Friend WithEvents CM_txtNTF As System.Windows.Forms.TextBox
        Friend WithEvents Label67 As System.Windows.Forms.Label
        Friend WithEvents tbAggBilling As System.Windows.Forms.TabPage
        Friend WithEvents Label70 As System.Windows.Forms.Label
        Friend WithEvents Label69 As System.Windows.Forms.Label
        Friend WithEvents Label68 As System.Windows.Forms.Label
        Friend WithEvents CM_txtRTM As System.Windows.Forms.TextBox
        Friend WithEvents Label71 As System.Windows.Forms.Label
        Friend WithEvents tpgUpdLabor As System.Windows.Forms.TabPage
        Friend WithEvents Label72 As System.Windows.Forms.Label
        Friend WithEvents Label73 As System.Windows.Forms.Label
        Friend WithEvents Label74 As System.Windows.Forms.Label
        Friend WithEvents Label75 As System.Windows.Forms.Label
        Friend WithEvents CUST_chkReqAQLOnAllUnits As System.Windows.Forms.CheckBox
        Friend WithEvents CUST_chkAggBill As System.Windows.Forms.CheckBox
        Friend WithEvents CUST_cboInvDateType As System.Windows.Forms.ComboBox
        Friend WithEvents Label76 As System.Windows.Forms.Label
        Friend WithEvents CUST_chkPartNeed As System.Windows.Forms.CheckBox
        Friend WithEvents CUST_cboDept As System.Windows.Forms.ComboBox
        Friend WithEvents Label77 As System.Windows.Forms.Label
        Friend WithEvents AB_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents AB_gbAggregates As System.Windows.Forms.GroupBox
        Friend WithEvents AB_lstBillcodeCodes As System.Windows.Forms.ListBox
        Friend WithEvents AB_gridAggCharge As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents AB_txtAmount As System.Windows.Forms.TextBox
        Friend WithEvents AB_btnRemove As System.Windows.Forms.Button
        Friend WithEvents UL_cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents UL_cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents UL_pnlUpdateLabor As System.Windows.Forms.Panel
        Friend WithEvents UL_pnlShipDate As System.Windows.Forms.Panel
        Friend WithEvents UL_dtpShipEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents UL_dtShipStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents UL_chkProdShipDate As System.Windows.Forms.CheckBox
        Friend WithEvents UL_btnUpdateLabor As System.Windows.Forms.Button
        Friend WithEvents UL_chkInWip As System.Windows.Forms.CheckBox
        Friend WithEvents AB_btnInsertUpd As System.Windows.Forms.Button
        Friend WithEvents CUST_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_btnSave As System.Windows.Forms.Button
        Friend WithEvents CUST_btnCancel As System.Windows.Forms.Button
        Friend WithEvents CUST_btnNEW As System.Windows.Forms.Button
        Friend WithEvents PC_cboParentCo As System.Windows.Forms.ComboBox
        Friend WithEvents CP_dgLaborPrice As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents CP_dgLaborPriceExcpt As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents PC_btnNEW As System.Windows.Forms.Button
        Friend WithEvents PC_txtPCoID As System.Windows.Forms.TextBox
        Friend WithEvents PC_txtEndUserValue As System.Windows.Forms.TextBox
        Friend WithEvents PC_txtPrcGroupID As System.Windows.Forms.TextBox
        Friend WithEvents PC_chkEndUser As System.Windows.Forms.CheckBox
        Friend WithEvents PC_txtWrtyLaborID As System.Windows.Forms.TextBox
        Friend WithEvents PC_txtWrtyPartsID As System.Windows.Forms.TextBox
        Friend WithEvents PC_btnChangeName As System.Windows.Forms.Button
        Friend WithEvents PC_btnCANCEL As System.Windows.Forms.Button
        Friend WithEvents PC_btnSAVE As System.Windows.Forms.Button
        Friend WithEvents PC_chkInactive As System.Windows.Forms.CheckBox
        Friend WithEvents Label64 As System.Windows.Forms.Label
        Friend WithEvents PC_cboPlusParts As System.Windows.Forms.ComboBox
        Friend WithEvents CUST_btnChangeName As System.Windows.Forms.Button
        Friend WithEvents CW_btnSAVE As System.Windows.Forms.Button
        Friend WithEvents CW_btnCANCEL As System.Windows.Forms.Button
        Friend WithEvents LOC_btnOptions As System.Windows.Forms.Button
        Friend WithEvents LOC_btnSave As System.Windows.Forms.Button
        Friend WithEvents LOC_btnCancel As System.Windows.Forms.Button
        Friend WithEvents LOC_btnNew As System.Windows.Forms.Button
        Friend WithEvents LOC_ListBox As System.Windows.Forms.ListBox
        Friend WithEvents LOC_cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents CC_btnSAVE As System.Windows.Forms.Button
        Friend WithEvents CC_btnCANCEL As System.Windows.Forms.Button
        Friend WithEvents Label65 As System.Windows.Forms.Label
        Friend WithEvents Label66 As System.Windows.Forms.Label
        Friend WithEvents CC_cboExpMonth As System.Windows.Forms.ComboBox
        Friend WithEvents CC_cboExpYear As System.Windows.Forms.ComboBox
        Friend WithEvents CP_btnPrcGroup As System.Windows.Forms.Button
        Friend WithEvents CP_btnSAVE As System.Windows.Forms.Button
        Friend WithEvents CP_btnCANCEL As System.Windows.Forms.Button
        Friend WithEvents CP_lblExistingOfPrcGrp As System.Windows.Forms.Label
        Friend WithEvents CM_btnSave As System.Windows.Forms.Button
        Friend WithEvents CM_btnCancel As System.Windows.Forms.Button
        Friend WithEvents CM_txtInventoryMarkup As System.Windows.Forms.TextBox
        Friend WithEvents CM_txtCustMarkup As System.Windows.Forms.TextBox
        Friend WithEvents CM_cboPlusparts As System.Windows.Forms.ComboBox
        Friend WithEvents AB_lblBillCode As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCustMaint))
            Me.lblSelectCustomer = New System.Windows.Forms.Label()
            Me.AB_cboCustomer = New System.Windows.Forms.ComboBox()
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
            Me.ctrlTab = New System.Windows.Forms.TabControl()
            Me.tbParent = New System.Windows.Forms.TabPage()
            Me.PC_cboPlusParts = New System.Windows.Forms.ComboBox()
            Me.Label64 = New System.Windows.Forms.Label()
            Me.PC_chkInactive = New System.Windows.Forms.CheckBox()
            Me.PC_txtPCoID = New System.Windows.Forms.TextBox()
            Me.PC_txtEndUserValue = New System.Windows.Forms.TextBox()
            Me.PC_txtPrcGroupID = New System.Windows.Forms.TextBox()
            Me.PC_btnChangeName = New System.Windows.Forms.Button()
            Me.PC_chkEndUser = New System.Windows.Forms.CheckBox()
            Me.PC_btnCANCEL = New System.Windows.Forms.Button()
            Me.PC_btnSAVE = New System.Windows.Forms.Button()
            Me.PC_btnNEW = New System.Windows.Forms.Button()
            Me.PC_txtMotoCode = New System.Windows.Forms.TextBox()
            Me.PC_cboPrcGroup = New System.Windows.Forms.ComboBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.PC_txtWrtyLaborID = New System.Windows.Forms.TextBox()
            Me.PC_cboWrtyLabor = New System.Windows.Forms.ComboBox()
            Me.PC_cboWrtyParts = New System.Windows.Forms.ComboBox()
            Me.PC_txtWrtyDays = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.PC_txtWrtyPartsID = New System.Windows.Forms.TextBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.PC_txtNER = New System.Windows.Forms.TextBox()
            Me.PC_txtRUR = New System.Windows.Forms.TextBox()
            Me.PC_txtMarkUp = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PC_cboParentCo = New System.Windows.Forms.ComboBox()
            Me.lblPCname = New System.Windows.Forms.Label()
            Me.PC_txtName = New System.Windows.Forms.TextBox()
            Me.lblHighlight = New System.Windows.Forms.Label()
            Me.tbCust2Price = New System.Windows.Forms.TabPage()
            Me.CP_lblExistingOfPrcGrp = New System.Windows.Forms.Label()
            Me.lblException = New System.Windows.Forms.Label()
            Me.CP_dgLaborPriceExcpt = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.CP_dgLaborPrice = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.CP_btnPrcGroup = New System.Windows.Forms.Button()
            Me.CP_cboProduct = New System.Windows.Forms.ComboBox()
            Me.Label56 = New System.Windows.Forms.Label()
            Me.CP_btnSAVE = New System.Windows.Forms.Button()
            Me.CP_btnCANCEL = New System.Windows.Forms.Button()
            Me.Label55 = New System.Windows.Forms.Label()
            Me.CP_cboPricingGroup = New System.Windows.Forms.ComboBox()
            Me.CP_cboCustomer = New System.Windows.Forms.ComboBox()
            Me.Label54 = New System.Windows.Forms.Label()
            Me.Label61 = New System.Windows.Forms.Label()
            Me.tbCreditCard = New System.Windows.Forms.TabPage()
            Me.CC_cboExpYear = New System.Windows.Forms.ComboBox()
            Me.CC_cboExpMonth = New System.Windows.Forms.ComboBox()
            Me.Label66 = New System.Windows.Forms.Label()
            Me.Label65 = New System.Windows.Forms.Label()
            Me.CC_txtAuthCode = New System.Windows.Forms.TextBox()
            Me.lblAuthCode = New System.Windows.Forms.Label()
            Me.CC_btnSAVE = New System.Windows.Forms.Button()
            Me.CC_btnCANCEL = New System.Windows.Forms.Button()
            Me.CC_cboCustomer = New System.Windows.Forms.ComboBox()
            Me.CC_txtCCNumber = New System.Windows.Forms.TextBox()
            Me.CC_cboCCType = New System.Windows.Forms.ComboBox()
            Me.Label24 = New System.Windows.Forms.Label()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.CC_txtName = New System.Windows.Forms.TextBox()
            Me.Label59 = New System.Windows.Forms.Label()
            Me.tbLocation = New System.Windows.Forms.TabPage()
            Me.LOC_btnOptions = New System.Windows.Forms.Button()
            Me.LOC_btnSave = New System.Windows.Forms.Button()
            Me.LOC_btnCancel = New System.Windows.Forms.Button()
            Me.LOC_btnNew = New System.Windows.Forms.Button()
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
            Me.Label62 = New System.Windows.Forms.Label()
            Me.tbCustWrty = New System.Windows.Forms.TabPage()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.CW_btnSAVE = New System.Windows.Forms.Button()
            Me.CW_btnCANCEL = New System.Windows.Forms.Button()
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
            Me.AB_gbAggregates = New System.Windows.Forms.GroupBox()
            Me.AB_btnRemove = New System.Windows.Forms.Button()
            Me.AB_btnInsertUpd = New System.Windows.Forms.Button()
            Me.AB_txtAmount = New System.Windows.Forms.TextBox()
            Me.Label70 = New System.Windows.Forms.Label()
            Me.Label69 = New System.Windows.Forms.Label()
            Me.AB_gridAggCharge = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label68 = New System.Windows.Forms.Label()
            Me.AB_lstBillcodeCodes = New System.Windows.Forms.ListBox()
            Me.tbCustomer = New System.Windows.Forms.TabPage()
            Me.CUST_cboDept = New System.Windows.Forms.ComboBox()
            Me.Label77 = New System.Windows.Forms.Label()
            Me.CUST_chkPartNeed = New System.Windows.Forms.CheckBox()
            Me.CUST_cboInvDateType = New System.Windows.Forms.ComboBox()
            Me.Label76 = New System.Windows.Forms.Label()
            Me.CUST_chkReqAQLOnAllUnits = New System.Windows.Forms.CheckBox()
            Me.CUST_chkAggBill = New System.Windows.Forms.CheckBox()
            Me.CUST_txtMemo = New System.Windows.Forms.TextBox()
            Me.CUST_chkINACTIVE = New System.Windows.Forms.CheckBox()
            Me.CUST_valCustID = New System.Windows.Forms.TextBox()
            Me.CUST_cboInvoiceDetail = New System.Windows.Forms.ComboBox()
            Me.Label63 = New System.Windows.Forms.Label()
            Me.CUST_btnChangeName = New System.Windows.Forms.Button()
            Me.CUST_btnNEW = New System.Windows.Forms.Button()
            Me.CUST_cboCustomer = New System.Windows.Forms.ComboBox()
            Me.CUST_btnSave = New System.Windows.Forms.Button()
            Me.CUST_btnCancel = New System.Windows.Forms.Button()
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
            Me.tbCustMarkup = New System.Windows.Forms.TabPage()
            Me.CM_cboCustomer = New System.Windows.Forms.ComboBox()
            Me.CM_btnSave = New System.Windows.Forms.Button()
            Me.CM_btnCancel = New System.Windows.Forms.Button()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.CM_txtRTM = New System.Windows.Forms.TextBox()
            Me.Label71 = New System.Windows.Forms.Label()
            Me.CM_txtNTF = New System.Windows.Forms.TextBox()
            Me.Label67 = New System.Windows.Forms.Label()
            Me.CM_cboPlusparts = New System.Windows.Forms.ComboBox()
            Me.lblCMplusParts = New System.Windows.Forms.Label()
            Me.CM_txtInventoryMarkup = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.CM_cboInvMthdID = New System.Windows.Forms.ComboBox()
            Me.CM_txtCustMarkup = New System.Windows.Forms.TextBox()
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
            Me.tpgUpdLabor = New System.Windows.Forms.TabPage()
            Me.UL_pnlUpdateLabor = New System.Windows.Forms.Panel()
            Me.UL_pnlShipDate = New System.Windows.Forms.Panel()
            Me.UL_dtpShipEndDate = New System.Windows.Forms.DateTimePicker()
            Me.UL_dtShipStartDate = New System.Windows.Forms.DateTimePicker()
            Me.Label75 = New System.Windows.Forms.Label()
            Me.Label74 = New System.Windows.Forms.Label()
            Me.UL_chkProdShipDate = New System.Windows.Forms.CheckBox()
            Me.UL_btnUpdateLabor = New System.Windows.Forms.Button()
            Me.UL_chkInWip = New System.Windows.Forms.CheckBox()
            Me.UL_cboModels = New C1.Win.C1List.C1Combo()
            Me.Label72 = New System.Windows.Forms.Label()
            Me.UL_cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label73 = New System.Windows.Forms.Label()
            Me.AB_lblBillCode = New System.Windows.Forms.Label()
            Me.grpSection.SuspendLayout()
            Me.ctrlTab.SuspendLayout()
            Me.tbParent.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.tbCust2Price.SuspendLayout()
            CType(Me.CP_dgLaborPriceExcpt, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CP_dgLaborPrice, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbCreditCard.SuspendLayout()
            Me.tbLocation.SuspendLayout()
            Me.tbCustWrty.SuspendLayout()
            Me.tbAggBilling.SuspendLayout()
            Me.AB_gbAggregates.SuspendLayout()
            CType(Me.AB_gridAggCharge, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbCustomer.SuspendLayout()
            Me.tbSearch.SuspendLayout()
            CType(Me.searchGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tbCustMarkup.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.tpgUpdLabor.SuspendLayout()
            Me.UL_pnlUpdateLabor.SuspendLayout()
            Me.UL_pnlShipDate.SuspendLayout()
            CType(Me.UL_cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.UL_cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblSelectCustomer
            '
            Me.lblSelectCustomer.Location = New System.Drawing.Point(8, 30)
            Me.lblSelectCustomer.Name = "lblSelectCustomer"
            Me.lblSelectCustomer.Size = New System.Drawing.Size(96, 21)
            Me.lblSelectCustomer.TabIndex = 0
            Me.lblSelectCustomer.Text = "Select Customer:"
            Me.lblSelectCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'AB_cboCustomer
            '
            Me.AB_cboCustomer.Location = New System.Drawing.Point(104, 32)
            Me.AB_cboCustomer.Name = "AB_cboCustomer"
            Me.AB_cboCustomer.Size = New System.Drawing.Size(496, 21)
            Me.AB_cboCustomer.TabIndex = 0
            Me.AB_cboCustomer.TabStop = False
            '
            'grpSection
            '
            Me.grpSection.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.grpSection.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLocationStatus, Me.lblLocation, Me.lblCustPriceStatus, Me.lblCustPrice, Me.lblCCStatus, Me.lblCC, Me.lblWarrantyStatus, Me.lblWarranty, Me.lblMarkupStatus, Me.lblMarkup, Me.lblCustomerStatus, Me.lblCustomer, Me.lblParentCoStatus, Me.lblParentCo})
            Me.grpSection.Location = New System.Drawing.Point(720, 32)
            Me.grpSection.Name = "grpSection"
            Me.grpSection.Size = New System.Drawing.Size(104, 456)
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
            'ctrlTab
            '
            Me.ctrlTab.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.ctrlTab.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbParent, Me.tbCust2Price, Me.tbCreditCard, Me.tbLocation, Me.tbCustWrty, Me.tbAggBilling, Me.tbCustomer, Me.tbSearch, Me.tbCustMarkup, Me.tpgUpdLabor})
            Me.ctrlTab.Location = New System.Drawing.Point(8, 16)
            Me.ctrlTab.Name = "ctrlTab"
            Me.ctrlTab.SelectedIndex = 0
            Me.ctrlTab.Size = New System.Drawing.Size(704, 480)
            Me.ctrlTab.TabIndex = 21
            '
            'tbParent
            '
            Me.tbParent.Controls.AddRange(New System.Windows.Forms.Control() {Me.PC_cboPlusParts, Me.Label64, Me.PC_chkInactive, Me.PC_txtPCoID, Me.PC_txtEndUserValue, Me.PC_txtPrcGroupID, Me.PC_btnChangeName, Me.PC_chkEndUser, Me.PC_btnCANCEL, Me.PC_btnSAVE, Me.PC_btnNEW, Me.PC_txtMotoCode, Me.PC_cboPrcGroup, Me.Label8, Me.GroupBox2, Me.GroupBox1, Me.Label1, Me.PC_cboParentCo, Me.lblPCname, Me.PC_txtName, Me.lblHighlight})
            Me.tbParent.Location = New System.Drawing.Point(4, 22)
            Me.tbParent.Name = "tbParent"
            Me.tbParent.Size = New System.Drawing.Size(696, 454)
            Me.tbParent.TabIndex = 0
            Me.tbParent.Text = "Parent"
            '
            'PC_cboPlusParts
            '
            Me.PC_cboPlusParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PC_cboPlusParts.Location = New System.Drawing.Point(112, 168)
            Me.PC_cboPlusParts.Name = "PC_cboPlusParts"
            Me.PC_cboPlusParts.Size = New System.Drawing.Size(96, 21)
            Me.PC_cboPlusParts.TabIndex = 4
            '
            'Label64
            '
            Me.Label64.Location = New System.Drawing.Point(32, 168)
            Me.Label64.Name = "Label64"
            Me.Label64.Size = New System.Drawing.Size(80, 16)
            Me.Label64.TabIndex = 105
            Me.Label64.Text = "Plus Parts:"
            Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'PC_chkInactive
            '
            Me.PC_chkInactive.Location = New System.Drawing.Point(40, 352)
            Me.PC_chkInactive.Name = "PC_chkInactive"
            Me.PC_chkInactive.Size = New System.Drawing.Size(184, 24)
            Me.PC_chkInactive.TabIndex = 8
            Me.PC_chkInactive.Text = "Inactive"
            '
            'PC_txtPCoID
            '
            Me.PC_txtPCoID.Location = New System.Drawing.Point(200, 320)
            Me.PC_txtPCoID.Name = "PC_txtPCoID"
            Me.PC_txtPCoID.Size = New System.Drawing.Size(24, 20)
            Me.PC_txtPCoID.TabIndex = 102
            Me.PC_txtPCoID.Text = ""
            Me.PC_txtPCoID.Visible = False
            '
            'PC_txtEndUserValue
            '
            Me.PC_txtEndUserValue.Location = New System.Drawing.Point(168, 320)
            Me.PC_txtEndUserValue.Name = "PC_txtEndUserValue"
            Me.PC_txtEndUserValue.Size = New System.Drawing.Size(24, 20)
            Me.PC_txtEndUserValue.TabIndex = 101
            Me.PC_txtEndUserValue.Text = ""
            Me.PC_txtEndUserValue.Visible = False
            '
            'PC_txtPrcGroupID
            '
            Me.PC_txtPrcGroupID.Location = New System.Drawing.Point(112, 144)
            Me.PC_txtPrcGroupID.Name = "PC_txtPrcGroupID"
            Me.PC_txtPrcGroupID.Size = New System.Drawing.Size(96, 20)
            Me.PC_txtPrcGroupID.TabIndex = 100
            Me.PC_txtPrcGroupID.Text = ""
            Me.PC_txtPrcGroupID.Visible = False
            '
            'PC_btnChangeName
            '
            Me.PC_btnChangeName.Location = New System.Drawing.Point(520, 48)
            Me.PC_btnChangeName.Name = "PC_btnChangeName"
            Me.PC_btnChangeName.Size = New System.Drawing.Size(88, 16)
            Me.PC_btnChangeName.TabIndex = 14
            Me.PC_btnChangeName.Text = "Change Name"
            '
            'PC_chkEndUser
            '
            Me.PC_chkEndUser.Location = New System.Drawing.Point(40, 320)
            Me.PC_chkEndUser.Name = "PC_chkEndUser"
            Me.PC_chkEndUser.Size = New System.Drawing.Size(100, 24)
            Me.PC_chkEndUser.TabIndex = 7
            Me.PC_chkEndUser.Text = "End User"
            '
            'PC_btnCANCEL
            '
            Me.PC_btnCANCEL.Location = New System.Drawing.Point(288, 8)
            Me.PC_btnCANCEL.Name = "PC_btnCANCEL"
            Me.PC_btnCANCEL.Size = New System.Drawing.Size(80, 24)
            Me.PC_btnCANCEL.TabIndex = 11
            Me.PC_btnCANCEL.Text = "Cancel"
            '
            'PC_btnSAVE
            '
            Me.PC_btnSAVE.Location = New System.Drawing.Point(376, 8)
            Me.PC_btnSAVE.Name = "PC_btnSAVE"
            Me.PC_btnSAVE.Size = New System.Drawing.Size(80, 24)
            Me.PC_btnSAVE.TabIndex = 12
            Me.PC_btnSAVE.Text = "Save"
            '
            'PC_btnNEW
            '
            Me.PC_btnNEW.Location = New System.Drawing.Point(8, 8)
            Me.PC_btnNEW.Name = "PC_btnNEW"
            Me.PC_btnNEW.Size = New System.Drawing.Size(40, 24)
            Me.PC_btnNEW.TabIndex = 15
            Me.PC_btnNEW.Text = "New"
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
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.PC_txtWrtyLaborID, Me.PC_cboWrtyLabor, Me.PC_cboWrtyParts, Me.PC_txtWrtyDays, Me.Label7, Me.Label6, Me.Label5, Me.PC_txtWrtyPartsID})
            Me.GroupBox2.Location = New System.Drawing.Point(40, 200)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(416, 104)
            Me.GroupBox2.TabIndex = 6
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Warranty"
            '
            'PC_txtWrtyLaborID
            '
            Me.PC_txtWrtyLaborID.Location = New System.Drawing.Point(384, 72)
            Me.PC_txtWrtyLaborID.Name = "PC_txtWrtyLaborID"
            Me.PC_txtWrtyLaborID.Size = New System.Drawing.Size(24, 20)
            Me.PC_txtWrtyLaborID.TabIndex = 102
            Me.PC_txtWrtyLaborID.Text = ""
            Me.PC_txtWrtyLaborID.Visible = False
            '
            'PC_cboWrtyLabor
            '
            Me.PC_cboWrtyLabor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PC_cboWrtyLabor.Location = New System.Drawing.Point(128, 72)
            Me.PC_cboWrtyLabor.Name = "PC_cboWrtyLabor"
            Me.PC_cboWrtyLabor.Size = New System.Drawing.Size(256, 21)
            Me.PC_cboWrtyLabor.TabIndex = 3
            '
            'PC_cboWrtyParts
            '
            Me.PC_cboWrtyParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PC_cboWrtyParts.Location = New System.Drawing.Point(128, 48)
            Me.PC_cboWrtyParts.Name = "PC_cboWrtyParts"
            Me.PC_cboWrtyParts.Size = New System.Drawing.Size(256, 21)
            Me.PC_cboWrtyParts.TabIndex = 2
            '
            'PC_txtWrtyDays
            '
            Me.PC_txtWrtyDays.Location = New System.Drawing.Point(128, 24)
            Me.PC_txtWrtyDays.Name = "PC_txtWrtyDays"
            Me.PC_txtWrtyDays.Size = New System.Drawing.Size(40, 20)
            Me.PC_txtWrtyDays.TabIndex = 1
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
            'PC_txtWrtyPartsID
            '
            Me.PC_txtWrtyPartsID.Location = New System.Drawing.Point(384, 48)
            Me.PC_txtWrtyPartsID.Name = "PC_txtWrtyPartsID"
            Me.PC_txtWrtyPartsID.Size = New System.Drawing.Size(24, 20)
            Me.PC_txtWrtyPartsID.TabIndex = 3
            Me.PC_txtWrtyPartsID.Text = ""
            Me.PC_txtWrtyPartsID.Visible = False
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
            Me.PC_txtNER.TabIndex = 3
            Me.PC_txtNER.Text = ""
            '
            'PC_txtRUR
            '
            Me.PC_txtRUR.Location = New System.Drawing.Point(72, 48)
            Me.PC_txtRUR.Name = "PC_txtRUR"
            Me.PC_txtRUR.Size = New System.Drawing.Size(72, 20)
            Me.PC_txtRUR.TabIndex = 2
            Me.PC_txtRUR.Text = ""
            '
            'PC_txtMarkUp
            '
            Me.PC_txtMarkUp.Location = New System.Drawing.Point(72, 24)
            Me.PC_txtMarkUp.Name = "PC_txtMarkUp"
            Me.PC_txtMarkUp.Size = New System.Drawing.Size(72, 20)
            Me.PC_txtMarkUp.TabIndex = 1
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
            'PC_cboParentCo
            '
            Me.PC_cboParentCo.Location = New System.Drawing.Point(112, 48)
            Me.PC_cboParentCo.Name = "PC_cboParentCo"
            Me.PC_cboParentCo.Size = New System.Drawing.Size(344, 21)
            Me.PC_cboParentCo.TabIndex = 1
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
            Me.lblHighlight.Size = New System.Drawing.Size(696, 32)
            Me.lblHighlight.TabIndex = 24
            '
            'tbCust2Price
            '
            Me.tbCust2Price.Controls.AddRange(New System.Windows.Forms.Control() {Me.CP_lblExistingOfPrcGrp, Me.lblException, Me.CP_dgLaborPriceExcpt, Me.CP_dgLaborPrice, Me.CP_btnPrcGroup, Me.CP_cboProduct, Me.Label56, Me.CP_btnSAVE, Me.CP_btnCANCEL, Me.Label55, Me.CP_cboPricingGroup, Me.CP_cboCustomer, Me.Label54, Me.Label61})
            Me.tbCust2Price.Location = New System.Drawing.Point(4, 22)
            Me.tbCust2Price.Name = "tbCust2Price"
            Me.tbCust2Price.Size = New System.Drawing.Size(696, 454)
            Me.tbCust2Price.TabIndex = 6
            Me.tbCust2Price.Text = "Cust to Price"
            '
            'CP_lblExistingOfPrcGrp
            '
            Me.CP_lblExistingOfPrcGrp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CP_lblExistingOfPrcGrp.ForeColor = System.Drawing.Color.Blue
            Me.CP_lblExistingOfPrcGrp.Location = New System.Drawing.Point(168, 119)
            Me.CP_lblExistingOfPrcGrp.Name = "CP_lblExistingOfPrcGrp"
            Me.CP_lblExistingOfPrcGrp.Size = New System.Drawing.Size(368, 16)
            Me.CP_lblExistingOfPrcGrp.TabIndex = 77
            Me.CP_lblExistingOfPrcGrp.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblException
            '
            Me.lblException.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblException.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
            Me.lblException.ForeColor = System.Drawing.Color.White
            Me.lblException.Location = New System.Drawing.Point(392, 176)
            Me.lblException.Name = "lblException"
            Me.lblException.Size = New System.Drawing.Size(296, 16)
            Me.lblException.TabIndex = 75
            Me.lblException.Text = "Exception"
            Me.lblException.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'CP_dgLaborPriceExcpt
            '
            Me.CP_dgLaborPriceExcpt.AlternatingRows = True
            Me.CP_dgLaborPriceExcpt.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.CP_dgLaborPriceExcpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CP_dgLaborPriceExcpt.GroupByCaption = "Drag a column header here to group by that column"
            Me.CP_dgLaborPriceExcpt.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.CP_dgLaborPriceExcpt.Location = New System.Drawing.Point(392, 192)
            Me.CP_dgLaborPriceExcpt.Name = "CP_dgLaborPriceExcpt"
            Me.CP_dgLaborPriceExcpt.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.CP_dgLaborPriceExcpt.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.CP_dgLaborPriceExcpt.PreviewInfo.ZoomFactor = 75
            Me.CP_dgLaborPriceExcpt.Size = New System.Drawing.Size(296, 224)
            Me.CP_dgLaborPriceExcpt.TabIndex = 76
            Me.CP_dgLaborPriceExcpt.TabStop = False
            Me.CP_dgLaborPriceExcpt.Text = "C1TrueDBGrid1"
            Me.CP_dgLaborPriceExcpt.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "ottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGrou" & _
            "p=""1"" HorizontalScrollGroup=""1""><Height>222</Height><CaptionStyle parent=""Style2" & _
            """ me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent" & _
            "=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Foot" & _
            "erStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" />" & _
            "<HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highligh" & _
            "tRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle " & _
            "parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""S" & _
            "tyle11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" " & _
            "me=""Style1"" /><ClientRect>0, 0, 294, 222</ClientRect><BorderSide>0</BorderSide><" & _
            "BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedS" & _
            "tyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Styl" & _
            "e parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style p" & _
            "arent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pa" & _
            "rent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pa" & _
            "rent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=" & _
            """Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style p" & _
            "arent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits" & _
            ">1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><" & _
            "ClientArea>0, 0, 294, 222</ClientArea><PrintPageHeaderStyle parent="""" me=""Style1" & _
            "4"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'CP_dgLaborPrice
            '
            Me.CP_dgLaborPrice.AlternatingRows = True
            Me.CP_dgLaborPrice.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.CP_dgLaborPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CP_dgLaborPrice.FilterBar = True
            Me.CP_dgLaborPrice.GroupByCaption = "Drag a column header here to group by that column"
            Me.CP_dgLaborPrice.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.CP_dgLaborPrice.Location = New System.Drawing.Point(8, 176)
            Me.CP_dgLaborPrice.Name = "CP_dgLaborPrice"
            Me.CP_dgLaborPrice.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.CP_dgLaborPrice.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.CP_dgLaborPrice.PreviewInfo.ZoomFactor = 75
            Me.CP_dgLaborPrice.Size = New System.Drawing.Size(376, 240)
            Me.CP_dgLaborPrice.TabIndex = 75
            Me.CP_dgLaborPrice.TabStop = False
            Me.CP_dgLaborPrice.Text = "C1TrueDBGrid1"
            Me.CP_dgLaborPrice.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            """ MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" V" & _
            "erticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>238</Height><CaptionSty" & _
            "le parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Ev" & _
            "enRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=" & _
            """Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group" & _
            """ me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle" & _
            " parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4" & _
            """ /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Reco" & _
            "rdSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style" & _
            " parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 374, 238</ClientRect><BorderSid" & _
            "e>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView" & _
            "></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=" & _
            """Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Ca" & _
            "ption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Sele" & _
            "cted"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highligh" & _
            "tRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow""" & _
            " /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filt" & _
            "erBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertS" & _
            "plits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Def" & _
            "aultRecSelWidth><ClientArea>0, 0, 374, 238</ClientArea><PrintPageHeaderStyle par" & _
            "ent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'CP_btnPrcGroup
            '
            Me.CP_btnPrcGroup.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.CP_btnPrcGroup.Location = New System.Drawing.Point(576, 424)
            Me.CP_btnPrcGroup.Name = "CP_btnPrcGroup"
            Me.CP_btnPrcGroup.Size = New System.Drawing.Size(112, 23)
            Me.CP_btnPrcGroup.TabIndex = 4
            Me.CP_btnPrcGroup.Text = "Pricing Group"
            '
            'CP_cboProduct
            '
            Me.CP_cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CP_cboProduct.Location = New System.Drawing.Point(168, 80)
            Me.CP_cboProduct.Name = "CP_cboProduct"
            Me.CP_cboProduct.Size = New System.Drawing.Size(368, 21)
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
            'CP_btnSAVE
            '
            Me.CP_btnSAVE.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.CP_btnSAVE.Location = New System.Drawing.Point(448, 8)
            Me.CP_btnSAVE.Name = "CP_btnSAVE"
            Me.CP_btnSAVE.Size = New System.Drawing.Size(80, 24)
            Me.CP_btnSAVE.TabIndex = 6
            Me.CP_btnSAVE.Text = "Save"
            '
            'CP_btnCANCEL
            '
            Me.CP_btnCANCEL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.CP_btnCANCEL.Location = New System.Drawing.Point(360, 8)
            Me.CP_btnCANCEL.Name = "CP_btnCANCEL"
            Me.CP_btnCANCEL.Size = New System.Drawing.Size(80, 24)
            Me.CP_btnCANCEL.TabIndex = 5
            Me.CP_btnCANCEL.Text = "Cancel"
            '
            'Label55
            '
            Me.Label55.Location = New System.Drawing.Point(88, 144)
            Me.Label55.Name = "Label55"
            Me.Label55.Size = New System.Drawing.Size(80, 16)
            Me.Label55.TabIndex = 24
            Me.Label55.Text = "Pricing Group:"
            Me.Label55.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'CP_cboPricingGroup
            '
            Me.CP_cboPricingGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CP_cboPricingGroup.Location = New System.Drawing.Point(168, 144)
            Me.CP_cboPricingGroup.Name = "CP_cboPricingGroup"
            Me.CP_cboPricingGroup.Size = New System.Drawing.Size(368, 21)
            Me.CP_cboPricingGroup.TabIndex = 3
            '
            'CP_cboCustomer
            '
            Me.CP_cboCustomer.Location = New System.Drawing.Point(168, 56)
            Me.CP_cboCustomer.Name = "CP_cboCustomer"
            Me.CP_cboCustomer.Size = New System.Drawing.Size(368, 21)
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
            Me.Label61.Size = New System.Drawing.Size(696, 72)
            Me.Label61.TabIndex = 71
            '
            'tbCreditCard
            '
            Me.tbCreditCard.Controls.AddRange(New System.Windows.Forms.Control() {Me.CC_cboExpYear, Me.CC_cboExpMonth, Me.Label66, Me.Label65, Me.CC_txtAuthCode, Me.lblAuthCode, Me.CC_btnSAVE, Me.CC_btnCANCEL, Me.CC_cboCustomer, Me.CC_txtCCNumber, Me.CC_cboCCType, Me.Label24, Me.Label23, Me.Label22, Me.Label21, Me.CC_txtName, Me.Label59})
            Me.tbCreditCard.Location = New System.Drawing.Point(4, 22)
            Me.tbCreditCard.Name = "tbCreditCard"
            Me.tbCreditCard.Size = New System.Drawing.Size(696, 454)
            Me.tbCreditCard.TabIndex = 5
            Me.tbCreditCard.Text = "Credit Card"
            '
            'CC_cboExpYear
            '
            Me.CC_cboExpYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CC_cboExpYear.Location = New System.Drawing.Point(216, 180)
            Me.CC_cboExpYear.Name = "CC_cboExpYear"
            Me.CC_cboExpYear.Size = New System.Drawing.Size(63, 21)
            Me.CC_cboExpYear.TabIndex = 6
            '
            'CC_cboExpMonth
            '
            Me.CC_cboExpMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CC_cboExpMonth.Location = New System.Drawing.Point(135, 180)
            Me.CC_cboExpMonth.Name = "CC_cboExpMonth"
            Me.CC_cboExpMonth.Size = New System.Drawing.Size(63, 21)
            Me.CC_cboExpMonth.TabIndex = 5
            '
            'Label66
            '
            Me.Label66.Location = New System.Drawing.Point(225, 162)
            Me.Label66.Name = "Label66"
            Me.Label66.Size = New System.Drawing.Size(45, 16)
            Me.Label66.TabIndex = 76
            Me.Label66.Text = "Year:"
            Me.Label66.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label65
            '
            Me.Label65.Location = New System.Drawing.Point(144, 162)
            Me.Label65.Name = "Label65"
            Me.Label65.Size = New System.Drawing.Size(45, 16)
            Me.Label65.TabIndex = 74
            Me.Label65.Text = "Month:"
            Me.Label65.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'CC_txtAuthCode
            '
            Me.CC_txtAuthCode.Location = New System.Drawing.Point(136, 128)
            Me.CC_txtAuthCode.Name = "CC_txtAuthCode"
            Me.CC_txtAuthCode.Size = New System.Drawing.Size(63, 20)
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
            'CC_btnSAVE
            '
            Me.CC_btnSAVE.Location = New System.Drawing.Point(405, 8)
            Me.CC_btnSAVE.Name = "CC_btnSAVE"
            Me.CC_btnSAVE.Size = New System.Drawing.Size(80, 24)
            Me.CC_btnSAVE.TabIndex = 7
            Me.CC_btnSAVE.Text = "Save"
            '
            'CC_btnCANCEL
            '
            Me.CC_btnCANCEL.Location = New System.Drawing.Point(315, 8)
            Me.CC_btnCANCEL.Name = "CC_btnCANCEL"
            Me.CC_btnCANCEL.Size = New System.Drawing.Size(80, 24)
            Me.CC_btnCANCEL.TabIndex = 6
            Me.CC_btnCANCEL.Text = "Cancel"
            '
            'CC_cboCustomer
            '
            Me.CC_cboCustomer.Location = New System.Drawing.Point(136, 48)
            Me.CC_cboCustomer.Name = "CC_cboCustomer"
            Me.CC_cboCustomer.Size = New System.Drawing.Size(352, 21)
            Me.CC_cboCustomer.TabIndex = 1
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
            Me.Label23.Location = New System.Drawing.Point(32, 180)
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
            Me.Label59.Size = New System.Drawing.Size(696, 32)
            Me.Label59.TabIndex = 71
            '
            'tbLocation
            '
            Me.tbLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.LOC_btnOptions, Me.LOC_btnSave, Me.LOC_btnCancel, Me.LOC_btnNew, Me.LOC_ListBox, Me.LOC_cboCustomer, Me.LOC_txtShippingMemo, Me.LOC_txtMemo, Me.LOC_cboManifestDetail, Me.LOC_cboAfterMarket, Me.LOC_cboCountry, Me.LOC_cboState, Me.LOC_txtEmail, Me.LOC_txtFax, Me.LOC_txtPhone, Me.LOC_txtContact, Me.LOC_txtZip, Me.LOC_txtCity, Me.LOC_txtAddress2, Me.LOC_txtAddress1, Me.LOC_txtName, Me.Label53, Me.Label52, Me.Label51, Me.Label50, Me.Label49, Me.Label48, Me.Label47, Me.Label46, Me.Label45, Me.Label44, Me.Label43, Me.Label42, Me.Label41, Me.Label40, Me.Label39, Me.Label38, Me.Label62})
            Me.tbLocation.Location = New System.Drawing.Point(4, 22)
            Me.tbLocation.Name = "tbLocation"
            Me.tbLocation.Size = New System.Drawing.Size(696, 454)
            Me.tbLocation.TabIndex = 2
            Me.tbLocation.Text = "Location"
            '
            'LOC_btnOptions
            '
            Me.LOC_btnOptions.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_btnOptions.Location = New System.Drawing.Point(480, 8)
            Me.LOC_btnOptions.Name = "LOC_btnOptions"
            Me.LOC_btnOptions.Size = New System.Drawing.Size(64, 23)
            Me.LOC_btnOptions.TabIndex = 18
            Me.LOC_btnOptions.TabStop = False
            Me.LOC_btnOptions.Text = "Options"
            '
            'LOC_btnSave
            '
            Me.LOC_btnSave.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_btnSave.Location = New System.Drawing.Point(376, 8)
            Me.LOC_btnSave.Name = "LOC_btnSave"
            Me.LOC_btnSave.Size = New System.Drawing.Size(72, 24)
            Me.LOC_btnSave.TabIndex = 20
            Me.LOC_btnSave.Text = "Save"
            '
            'LOC_btnCancel
            '
            Me.LOC_btnCancel.Location = New System.Drawing.Point(280, 8)
            Me.LOC_btnCancel.Name = "LOC_btnCancel"
            Me.LOC_btnCancel.Size = New System.Drawing.Size(64, 24)
            Me.LOC_btnCancel.TabIndex = 19
            Me.LOC_btnCancel.Text = "Cancel"
            '
            'LOC_btnNew
            '
            Me.LOC_btnNew.Location = New System.Drawing.Point(8, 8)
            Me.LOC_btnNew.Name = "LOC_btnNew"
            Me.LOC_btnNew.Size = New System.Drawing.Size(40, 24)
            Me.LOC_btnNew.TabIndex = 21
            Me.LOC_btnNew.Text = "New"
            '
            'LOC_ListBox
            '
            Me.LOC_ListBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_ListBox.Location = New System.Drawing.Point(8, 80)
            Me.LOC_ListBox.Name = "LOC_ListBox"
            Me.LOC_ListBox.Size = New System.Drawing.Size(192, 238)
            Me.LOC_ListBox.TabIndex = 2
            Me.LOC_ListBox.TabStop = False
            '
            'LOC_cboCustomer
            '
            Me.LOC_cboCustomer.Location = New System.Drawing.Point(96, 46)
            Me.LOC_cboCustomer.Name = "LOC_cboCustomer"
            Me.LOC_cboCustomer.Size = New System.Drawing.Size(448, 21)
            Me.LOC_cboCustomer.TabIndex = 1
            '
            'LOC_txtShippingMemo
            '
            Me.LOC_txtShippingMemo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtShippingMemo.Location = New System.Drawing.Point(552, 232)
            Me.LOC_txtShippingMemo.Multiline = True
            Me.LOC_txtShippingMemo.Name = "LOC_txtShippingMemo"
            Me.LOC_txtShippingMemo.Size = New System.Drawing.Size(136, 80)
            Me.LOC_txtShippingMemo.TabIndex = 17
            Me.LOC_txtShippingMemo.Text = ""
            '
            'LOC_txtMemo
            '
            Me.LOC_txtMemo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtMemo.Location = New System.Drawing.Point(552, 96)
            Me.LOC_txtMemo.Multiline = True
            Me.LOC_txtMemo.Name = "LOC_txtMemo"
            Me.LOC_txtMemo.Size = New System.Drawing.Size(136, 96)
            Me.LOC_txtMemo.TabIndex = 16
            Me.LOC_txtMemo.Text = ""
            '
            'LOC_cboManifestDetail
            '
            Me.LOC_cboManifestDetail.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_cboManifestDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.LOC_cboManifestDetail.Location = New System.Drawing.Point(496, 272)
            Me.LOC_cboManifestDetail.Name = "LOC_cboManifestDetail"
            Me.LOC_cboManifestDetail.Size = New System.Drawing.Size(48, 20)
            Me.LOC_cboManifestDetail.TabIndex = 14
            '
            'LOC_cboAfterMarket
            '
            Me.LOC_cboAfterMarket.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_cboAfterMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.LOC_cboAfterMarket.Location = New System.Drawing.Point(496, 248)
            Me.LOC_cboAfterMarket.Name = "LOC_cboAfterMarket"
            Me.LOC_cboAfterMarket.Size = New System.Drawing.Size(48, 20)
            Me.LOC_cboAfterMarket.TabIndex = 13
            '
            'LOC_cboCountry
            '
            Me.LOC_cboCountry.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.LOC_cboCountry.Location = New System.Drawing.Point(280, 200)
            Me.LOC_cboCountry.Name = "LOC_cboCountry"
            Me.LOC_cboCountry.Size = New System.Drawing.Size(264, 20)
            Me.LOC_cboCountry.TabIndex = 9
            '
            'LOC_cboState
            '
            Me.LOC_cboState.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_cboState.Location = New System.Drawing.Point(280, 176)
            Me.LOC_cboState.Name = "LOC_cboState"
            Me.LOC_cboState.Size = New System.Drawing.Size(176, 20)
            Me.LOC_cboState.TabIndex = 7
            '
            'LOC_txtEmail
            '
            Me.LOC_txtEmail.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtEmail.Location = New System.Drawing.Point(280, 296)
            Me.LOC_txtEmail.Name = "LOC_txtEmail"
            Me.LOC_txtEmail.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtEmail.TabIndex = 15
            Me.LOC_txtEmail.Text = ""
            '
            'LOC_txtFax
            '
            Me.LOC_txtFax.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtFax.Location = New System.Drawing.Point(280, 272)
            Me.LOC_txtFax.Name = "LOC_txtFax"
            Me.LOC_txtFax.Size = New System.Drawing.Size(120, 20)
            Me.LOC_txtFax.TabIndex = 12
            Me.LOC_txtFax.Text = ""
            '
            'LOC_txtPhone
            '
            Me.LOC_txtPhone.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtPhone.Location = New System.Drawing.Point(280, 248)
            Me.LOC_txtPhone.Name = "LOC_txtPhone"
            Me.LOC_txtPhone.Size = New System.Drawing.Size(120, 20)
            Me.LOC_txtPhone.TabIndex = 11
            Me.LOC_txtPhone.Text = ""
            '
            'LOC_txtContact
            '
            Me.LOC_txtContact.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtContact.Location = New System.Drawing.Point(280, 224)
            Me.LOC_txtContact.Name = "LOC_txtContact"
            Me.LOC_txtContact.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtContact.TabIndex = 10
            Me.LOC_txtContact.Text = ""
            '
            'LOC_txtZip
            '
            Me.LOC_txtZip.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtZip.Location = New System.Drawing.Point(480, 176)
            Me.LOC_txtZip.Name = "LOC_txtZip"
            Me.LOC_txtZip.Size = New System.Drawing.Size(62, 20)
            Me.LOC_txtZip.TabIndex = 8
            Me.LOC_txtZip.Text = ""
            '
            'LOC_txtCity
            '
            Me.LOC_txtCity.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtCity.Location = New System.Drawing.Point(280, 152)
            Me.LOC_txtCity.Name = "LOC_txtCity"
            Me.LOC_txtCity.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtCity.TabIndex = 6
            Me.LOC_txtCity.Text = ""
            '
            'LOC_txtAddress2
            '
            Me.LOC_txtAddress2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtAddress2.Location = New System.Drawing.Point(280, 128)
            Me.LOC_txtAddress2.Name = "LOC_txtAddress2"
            Me.LOC_txtAddress2.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtAddress2.TabIndex = 5
            Me.LOC_txtAddress2.Text = ""
            '
            'LOC_txtAddress1
            '
            Me.LOC_txtAddress1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtAddress1.Location = New System.Drawing.Point(280, 104)
            Me.LOC_txtAddress1.Name = "LOC_txtAddress1"
            Me.LOC_txtAddress1.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtAddress1.TabIndex = 4
            Me.LOC_txtAddress1.Text = ""
            '
            'LOC_txtName
            '
            Me.LOC_txtName.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.LOC_txtName.Location = New System.Drawing.Point(280, 80)
            Me.LOC_txtName.Name = "LOC_txtName"
            Me.LOC_txtName.Size = New System.Drawing.Size(264, 20)
            Me.LOC_txtName.TabIndex = 3
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
            Me.Label52.Location = New System.Drawing.Point(552, 208)
            Me.Label52.Name = "Label52"
            Me.Label52.Size = New System.Drawing.Size(88, 24)
            Me.Label52.TabIndex = 55
            Me.Label52.Text = "Shipping Memo:"
            Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label51
            '
            Me.Label51.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label51.Location = New System.Drawing.Point(552, 80)
            Me.Label51.Name = "Label51"
            Me.Label51.Size = New System.Drawing.Size(40, 16)
            Me.Label51.TabIndex = 54
            Me.Label51.Text = "Memo:"
            Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label50
            '
            Me.Label50.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label50.Location = New System.Drawing.Point(408, 272)
            Me.Label50.Name = "Label50"
            Me.Label50.Size = New System.Drawing.Size(88, 16)
            Me.Label50.TabIndex = 53
            Me.Label50.Text = "Manifest Detail:"
            Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label49
            '
            Me.Label49.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label49.Location = New System.Drawing.Point(424, 248)
            Me.Label49.Name = "Label49"
            Me.Label49.Size = New System.Drawing.Size(72, 16)
            Me.Label49.TabIndex = 52
            Me.Label49.Text = "After Market:"
            Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label48
            '
            Me.Label48.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label48.Location = New System.Drawing.Point(224, 296)
            Me.Label48.Name = "Label48"
            Me.Label48.Size = New System.Drawing.Size(48, 16)
            Me.Label48.TabIndex = 51
            Me.Label48.Text = "E-Mail:"
            Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label47
            '
            Me.Label47.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label47.Location = New System.Drawing.Point(224, 272)
            Me.Label47.Name = "Label47"
            Me.Label47.Size = New System.Drawing.Size(48, 16)
            Me.Label47.TabIndex = 50
            Me.Label47.Text = "Fax:"
            Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label46
            '
            Me.Label46.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label46.Location = New System.Drawing.Point(224, 248)
            Me.Label46.Name = "Label46"
            Me.Label46.Size = New System.Drawing.Size(48, 16)
            Me.Label46.TabIndex = 49
            Me.Label46.Text = "Phone:"
            Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label45
            '
            Me.Label45.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label45.Location = New System.Drawing.Point(224, 224)
            Me.Label45.Name = "Label45"
            Me.Label45.Size = New System.Drawing.Size(48, 16)
            Me.Label45.TabIndex = 48
            Me.Label45.Text = "Contact:"
            Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label44
            '
            Me.Label44.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label44.Location = New System.Drawing.Point(208, 200)
            Me.Label44.Name = "Label44"
            Me.Label44.Size = New System.Drawing.Size(64, 16)
            Me.Label44.TabIndex = 47
            Me.Label44.Text = "Country:"
            Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label43
            '
            Me.Label43.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label43.Location = New System.Drawing.Point(456, 176)
            Me.Label43.Name = "Label43"
            Me.Label43.Size = New System.Drawing.Size(24, 16)
            Me.Label43.TabIndex = 46
            Me.Label43.Text = "Zip:"
            Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label42
            '
            Me.Label42.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label42.Location = New System.Drawing.Point(240, 176)
            Me.Label42.Name = "Label42"
            Me.Label42.Size = New System.Drawing.Size(40, 16)
            Me.Label42.TabIndex = 45
            Me.Label42.Text = "State:"
            Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label41
            '
            Me.Label41.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label41.Location = New System.Drawing.Point(208, 152)
            Me.Label41.Name = "Label41"
            Me.Label41.Size = New System.Drawing.Size(64, 16)
            Me.Label41.TabIndex = 44
            Me.Label41.Text = "City:"
            Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label40
            '
            Me.Label40.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label40.Location = New System.Drawing.Point(208, 128)
            Me.Label40.Name = "Label40"
            Me.Label40.Size = New System.Drawing.Size(64, 16)
            Me.Label40.TabIndex = 43
            Me.Label40.Text = "Address(2):"
            Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label39
            '
            Me.Label39.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label39.Location = New System.Drawing.Point(208, 104)
            Me.Label39.Name = "Label39"
            Me.Label39.Size = New System.Drawing.Size(64, 16)
            Me.Label39.TabIndex = 42
            Me.Label39.Text = "Address(1):"
            Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label38
            '
            Me.Label38.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label38.Location = New System.Drawing.Point(208, 80)
            Me.Label38.Name = "Label38"
            Me.Label38.Size = New System.Drawing.Size(64, 16)
            Me.Label38.TabIndex = 41
            Me.Label38.Text = "Account #:"
            Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label62
            '
            Me.Label62.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label62.BackColor = System.Drawing.Color.SkyBlue
            Me.Label62.Location = New System.Drawing.Point(0, 40)
            Me.Label62.Name = "Label62"
            Me.Label62.Size = New System.Drawing.Size(696, 32)
            Me.Label62.TabIndex = 78
            '
            'tbCustWrty
            '
            Me.tbCustWrty.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label19, Me.CW_btnSAVE, Me.CW_btnCANCEL, Me.CW_cboProduct, Me.CW_cboCustomer, Me.CW_cboWrtyLabor, Me.CW_cboWrtyParts, Me.CW_txtDaysInWrty, Me.Label20, Me.Label18, Me.Label17, Me.Label16, Me.Label60})
            Me.tbCustWrty.Location = New System.Drawing.Point(4, 22)
            Me.tbCustWrty.Name = "tbCustWrty"
            Me.tbCustWrty.Size = New System.Drawing.Size(696, 454)
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
            'CW_btnSAVE
            '
            Me.CW_btnSAVE.Location = New System.Drawing.Point(456, 8)
            Me.CW_btnSAVE.Name = "CW_btnSAVE"
            Me.CW_btnSAVE.Size = New System.Drawing.Size(80, 24)
            Me.CW_btnSAVE.TabIndex = 7
            Me.CW_btnSAVE.Text = "Save"
            '
            'CW_btnCANCEL
            '
            Me.CW_btnCANCEL.Location = New System.Drawing.Point(368, 8)
            Me.CW_btnCANCEL.Name = "CW_btnCANCEL"
            Me.CW_btnCANCEL.Size = New System.Drawing.Size(80, 24)
            Me.CW_btnCANCEL.TabIndex = 6
            Me.CW_btnCANCEL.Text = "Cancel"
            '
            'CW_cboProduct
            '
            Me.CW_cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CW_cboProduct.Location = New System.Drawing.Point(168, 80)
            Me.CW_cboProduct.Name = "CW_cboProduct"
            Me.CW_cboProduct.Size = New System.Drawing.Size(368, 21)
            Me.CW_cboProduct.TabIndex = 2
            '
            'CW_cboCustomer
            '
            Me.CW_cboCustomer.Location = New System.Drawing.Point(168, 56)
            Me.CW_cboCustomer.Name = "CW_cboCustomer"
            Me.CW_cboCustomer.Size = New System.Drawing.Size(368, 21)
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
            Me.Label18.Text = "PSS Warranty Labor:"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label17
            '
            Me.Label17.Location = New System.Drawing.Point(120, 160)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(112, 16)
            Me.Label17.TabIndex = 57
            Me.Label17.Text = "PSS Warranty Parts:"
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
            Me.Label60.Size = New System.Drawing.Size(696, 72)
            Me.Label60.TabIndex = 70
            '
            'tbAggBilling
            '
            Me.tbAggBilling.Controls.AddRange(New System.Windows.Forms.Control() {Me.AB_gbAggregates, Me.AB_cboCustomer, Me.lblSelectCustomer})
            Me.tbAggBilling.Location = New System.Drawing.Point(4, 22)
            Me.tbAggBilling.Name = "tbAggBilling"
            Me.tbAggBilling.Size = New System.Drawing.Size(696, 454)
            Me.tbAggBilling.TabIndex = 9
            Me.tbAggBilling.Text = "Aggregate Billing"
            '
            'AB_gbAggregates
            '
            Me.AB_gbAggregates.Controls.AddRange(New System.Windows.Forms.Control() {Me.AB_lblBillCode, Me.AB_btnRemove, Me.AB_btnInsertUpd, Me.AB_txtAmount, Me.Label70, Me.Label69, Me.AB_gridAggCharge, Me.Label68, Me.AB_lstBillcodeCodes})
            Me.AB_gbAggregates.Location = New System.Drawing.Point(16, 72)
            Me.AB_gbAggregates.Name = "AB_gbAggregates"
            Me.AB_gbAggregates.Size = New System.Drawing.Size(656, 328)
            Me.AB_gbAggregates.TabIndex = 1
            Me.AB_gbAggregates.TabStop = False
            Me.AB_gbAggregates.Text = "Aggregate Billing"
            '
            'AB_btnRemove
            '
            Me.AB_btnRemove.Location = New System.Drawing.Point(544, 256)
            Me.AB_btnRemove.Name = "AB_btnRemove"
            Me.AB_btnRemove.Size = New System.Drawing.Size(96, 48)
            Me.AB_btnRemove.TabIndex = 5
            Me.AB_btnRemove.Text = "Remove"
            '
            'AB_btnInsertUpd
            '
            Me.AB_btnInsertUpd.Location = New System.Drawing.Point(416, 256)
            Me.AB_btnInsertUpd.Name = "AB_btnInsertUpd"
            Me.AB_btnInsertUpd.Size = New System.Drawing.Size(96, 48)
            Me.AB_btnInsertUpd.TabIndex = 4
            Me.AB_btnInsertUpd.Text = "Insert/Update"
            '
            'AB_txtAmount
            '
            Me.AB_txtAmount.Location = New System.Drawing.Point(248, 280)
            Me.AB_txtAmount.Name = "AB_txtAmount"
            Me.AB_txtAmount.TabIndex = 3
            Me.AB_txtAmount.Text = ""
            '
            'Label70
            '
            Me.Label70.Location = New System.Drawing.Point(176, 280)
            Me.Label70.Name = "Label70"
            Me.Label70.Size = New System.Drawing.Size(64, 16)
            Me.Label70.TabIndex = 48
            Me.Label70.Text = "Amount:"
            Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label69
            '
            Me.Label69.Location = New System.Drawing.Point(176, 256)
            Me.Label69.Name = "Label69"
            Me.Label69.Size = New System.Drawing.Size(64, 16)
            Me.Label69.TabIndex = 47
            Me.Label69.Text = "BillCode:"
            Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'AB_gridAggCharge
            '
            Me.AB_gridAggCharge.AllowColMove = False
            Me.AB_gridAggCharge.AllowColSelect = False
            Me.AB_gridAggCharge.AllowDelete = True
            Me.AB_gridAggCharge.AllowFilter = False
            Me.AB_gridAggCharge.AllowSort = False
            Me.AB_gridAggCharge.AllowUpdate = False
            Me.AB_gridAggCharge.AlternatingRows = True
            Me.AB_gridAggCharge.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.AB_gridAggCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.AB_gridAggCharge.CaptionHeight = 17
            Me.AB_gridAggCharge.GroupByCaption = "Drag a column header here to group by that column"
            Me.AB_gridAggCharge.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.AB_gridAggCharge.Location = New System.Drawing.Point(200, 24)
            Me.AB_gridAggCharge.Name = "AB_gridAggCharge"
            Me.AB_gridAggCharge.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.AB_gridAggCharge.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.AB_gridAggCharge.PreviewInfo.ZoomFactor = 75
            Me.AB_gridAggCharge.RowHeight = 15
            Me.AB_gridAggCharge.Size = New System.Drawing.Size(440, 200)
            Me.AB_gridAggCharge.TabIndex = 46
            Me.AB_gridAggCharge.Text = "C1TrueDBGrid1"
            Me.AB_gridAggCharge.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Caption=""BillCode"" DataField=""" & _
            """><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""ID"" DataField" & _
            "=""""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""Amount"" Dat" & _
            "aField=""""><ValueItems /><GroupInfo /></C1DataColumn></DataCols><Styles type=""C1." & _
            "Win.C1TrueDBGrid.Design.ContextWrapper""><Data>RecordSelector{AlignImage:Center;}" & _
            "Style31{}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}Selected{ForeCol" & _
            "or:HighlightText;BackColor:Highlight;}Editor{}Style18{AlignHorz:Near;}Style19{Al" & _
            "ignHorz:Near;}Style14{AlignHorz:Near;}Style15{AlignHorz:Near;}Style16{}Style17{}" & _
            "Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style32{}Style33{}OddRow{}Foo" & _
            "ter{}Style29{}Style28{}Style27{}Style26{}Style25{}Style24{}Style23{AlignHorz:Nea" & _
            "r;}Style22{AlignHorz:Near;}Style21{}Style20{}Inactive{ForeColor:InactiveCaptionT" & _
            "ext;BackColor:InactiveCaption;}EvenRow{BackColor:Aqua;}Heading{Wrap:True;BackCol" & _
            "or:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Sty" & _
            "le2{}FilterBar{}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:No" & _
            "ne,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style30{}Style3{}H" & _
            "ighlightRow{ForeColor:HighlightText;BackColor:Highlight;}</Data></Styles><Splits" & _
            "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefR" & _
            "ecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>198</H" & _
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
            "olumn></internalCols><ClientRect>0, 0, 438, 198</ClientRect><BorderSide>0</Borde" & _
            "rSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits>" & _
            "<NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" " & _
            "/><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><" & _
            "Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><S" & _
            "tyle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><S" & _
            "tyle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style " & _
            "parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><" & _
            "Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><hor" & _
            "zSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRe" & _
            "cSelWidth><ClientArea>0, 0, 438, 198</ClientArea><PrintPageHeaderStyle parent=""""" & _
            " me=""Style26"" /><PrintPageFooterStyle parent="""" me=""Style27"" /></Blob>"
            '
            'Label68
            '
            Me.Label68.Location = New System.Drawing.Point(40, 32)
            Me.Label68.Name = "Label68"
            Me.Label68.Size = New System.Drawing.Size(120, 32)
            Me.Label68.TabIndex = 45
            Me.Label68.Text = "Available Aggregate Bill Codes"
            Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'AB_lstBillcodeCodes
            '
            Me.AB_lstBillcodeCodes.Location = New System.Drawing.Point(8, 64)
            Me.AB_lstBillcodeCodes.Name = "AB_lstBillcodeCodes"
            Me.AB_lstBillcodeCodes.Size = New System.Drawing.Size(176, 160)
            Me.AB_lstBillcodeCodes.TabIndex = 1
            '
            'tbCustomer
            '
            Me.tbCustomer.Controls.AddRange(New System.Windows.Forms.Control() {Me.CUST_cboDept, Me.Label77, Me.CUST_chkPartNeed, Me.CUST_cboInvDateType, Me.Label76, Me.CUST_chkReqAQLOnAllUnits, Me.CUST_chkAggBill, Me.CUST_txtMemo, Me.CUST_chkINACTIVE, Me.CUST_valCustID, Me.CUST_cboInvoiceDetail, Me.Label63, Me.CUST_btnChangeName, Me.CUST_btnNEW, Me.CUST_cboCustomer, Me.CUST_btnSave, Me.CUST_btnCancel, Me.CUST_cboSalesPerson, Me.CUST_cboParentCo, Me.CUST_cboPayID, Me.CUST_cboCollSalesTax, Me.CUST_cboCrAppShip, Me.CUST_cboCrAppRec, Me.CUST_cboRepLCD, Me.CUST_cboRepNonWrty, Me.CUST_txtRejectTimes, Me.CUST_txtRejectDays, Me.CUST_cboPlusParts, Me.CUST_txtLName, Me.CUST_txtFName, Me.Label37, Me.Label36, Me.Label35, Me.Label34, Me.Label33, Me.Label32, Me.Label31, Me.Label30, Me.Label29, Me.Label28, Me.Label27, Me.Label26, Me.Label25, Me.Label57})
            Me.tbCustomer.Location = New System.Drawing.Point(4, 22)
            Me.tbCustomer.Name = "tbCustomer"
            Me.tbCustomer.Size = New System.Drawing.Size(696, 454)
            Me.tbCustomer.TabIndex = 1
            Me.tbCustomer.Text = "Customer"
            '
            'CUST_cboDept
            '
            Me.CUST_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboDept.Location = New System.Drawing.Point(464, 272)
            Me.CUST_cboDept.Name = "CUST_cboDept"
            Me.CUST_cboDept.Size = New System.Drawing.Size(192, 21)
            Me.CUST_cboDept.TabIndex = 18
            '
            'Label77
            '
            Me.Label77.Location = New System.Drawing.Point(360, 272)
            Me.Label77.Name = "Label77"
            Me.Label77.Size = New System.Drawing.Size(100, 16)
            Me.Label77.TabIndex = 110
            Me.Label77.Text = "Department:"
            Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CUST_chkPartNeed
            '
            Me.CUST_chkPartNeed.Location = New System.Drawing.Point(326, 344)
            Me.CUST_chkPartNeed.Name = "CUST_chkPartNeed"
            Me.CUST_chkPartNeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.CUST_chkPartNeed.Size = New System.Drawing.Size(152, 24)
            Me.CUST_chkPartNeed.TabIndex = 21
            Me.CUST_chkPartNeed.Text = "Predetermine Part Need"
            '
            'CUST_cboInvDateType
            '
            Me.CUST_cboInvDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboInvDateType.Location = New System.Drawing.Point(464, 248)
            Me.CUST_cboInvDateType.Name = "CUST_cboInvDateType"
            Me.CUST_cboInvDateType.Size = New System.Drawing.Size(192, 21)
            Me.CUST_cboInvDateType.TabIndex = 17
            '
            'Label76
            '
            Me.Label76.Location = New System.Drawing.Point(360, 248)
            Me.Label76.Name = "Label76"
            Me.Label76.Size = New System.Drawing.Size(100, 16)
            Me.Label76.TabIndex = 108
            Me.Label76.Text = "Invoice Date By:"
            Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CUST_chkReqAQLOnAllUnits
            '
            Me.CUST_chkReqAQLOnAllUnits.Location = New System.Drawing.Point(342, 320)
            Me.CUST_chkReqAQLOnAllUnits.Name = "CUST_chkReqAQLOnAllUnits"
            Me.CUST_chkReqAQLOnAllUnits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.CUST_chkReqAQLOnAllUnits.Size = New System.Drawing.Size(136, 24)
            Me.CUST_chkReqAQLOnAllUnits.TabIndex = 20
            Me.CUST_chkReqAQLOnAllUnits.Text = "Require 100 % AQL"
            '
            'CUST_chkAggBill
            '
            Me.CUST_chkAggBill.Location = New System.Drawing.Point(366, 296)
            Me.CUST_chkAggBill.Name = "CUST_chkAggBill"
            Me.CUST_chkAggBill.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.CUST_chkAggBill.Size = New System.Drawing.Size(112, 24)
            Me.CUST_chkAggBill.TabIndex = 19
            Me.CUST_chkAggBill.Text = "Aggregate Billing"
            '
            'CUST_txtMemo
            '
            Me.CUST_txtMemo.Location = New System.Drawing.Point(8, 264)
            Me.CUST_txtMemo.Multiline = True
            Me.CUST_txtMemo.Name = "CUST_txtMemo"
            Me.CUST_txtMemo.Size = New System.Drawing.Size(280, 80)
            Me.CUST_txtMemo.TabIndex = 9
            Me.CUST_txtMemo.Text = ""
            '
            'CUST_chkINACTIVE
            '
            Me.CUST_chkINACTIVE.Location = New System.Drawing.Point(374, 368)
            Me.CUST_chkINACTIVE.Name = "CUST_chkINACTIVE"
            Me.CUST_chkINACTIVE.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.CUST_chkINACTIVE.TabIndex = 22
            Me.CUST_chkINACTIVE.Text = "INACTIVATE"
            '
            'CUST_valCustID
            '
            Me.CUST_valCustID.Location = New System.Drawing.Point(160, 360)
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
            Me.CUST_cboInvoiceDetail.TabIndex = 16
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
            'CUST_btnChangeName
            '
            Me.CUST_btnChangeName.Location = New System.Drawing.Point(552, 48)
            Me.CUST_btnChangeName.Name = "CUST_btnChangeName"
            Me.CUST_btnChangeName.Size = New System.Drawing.Size(88, 20)
            Me.CUST_btnChangeName.TabIndex = 25
            Me.CUST_btnChangeName.Text = "Change Name"
            '
            'CUST_btnNEW
            '
            Me.CUST_btnNEW.Location = New System.Drawing.Point(8, 8)
            Me.CUST_btnNEW.Name = "CUST_btnNEW"
            Me.CUST_btnNEW.Size = New System.Drawing.Size(40, 24)
            Me.CUST_btnNEW.TabIndex = 0
            Me.CUST_btnNEW.Text = "New"
            '
            'CUST_cboCustomer
            '
            Me.CUST_cboCustomer.Location = New System.Drawing.Point(112, 48)
            Me.CUST_cboCustomer.Name = "CUST_cboCustomer"
            Me.CUST_cboCustomer.Size = New System.Drawing.Size(400, 21)
            Me.CUST_cboCustomer.TabIndex = 1
            '
            'CUST_btnSave
            '
            Me.CUST_btnSave.Location = New System.Drawing.Point(432, 8)
            Me.CUST_btnSave.Name = "CUST_btnSave"
            Me.CUST_btnSave.Size = New System.Drawing.Size(80, 24)
            Me.CUST_btnSave.TabIndex = 24
            Me.CUST_btnSave.Text = "Save"
            '
            'CUST_btnCancel
            '
            Me.CUST_btnCancel.Location = New System.Drawing.Point(344, 8)
            Me.CUST_btnCancel.Name = "CUST_btnCancel"
            Me.CUST_btnCancel.Size = New System.Drawing.Size(80, 24)
            Me.CUST_btnCancel.TabIndex = 23
            Me.CUST_btnCancel.Text = "Cancel"
            '
            'CUST_cboSalesPerson
            '
            Me.CUST_cboSalesPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboSalesPerson.Location = New System.Drawing.Point(112, 200)
            Me.CUST_cboSalesPerson.Name = "CUST_cboSalesPerson"
            Me.CUST_cboSalesPerson.Size = New System.Drawing.Size(176, 21)
            Me.CUST_cboSalesPerson.TabIndex = 8
            '
            'CUST_cboParentCo
            '
            Me.CUST_cboParentCo.Location = New System.Drawing.Point(112, 176)
            Me.CUST_cboParentCo.Name = "CUST_cboParentCo"
            Me.CUST_cboParentCo.Size = New System.Drawing.Size(176, 21)
            Me.CUST_cboParentCo.TabIndex = 7
            '
            'CUST_cboPayID
            '
            Me.CUST_cboPayID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboPayID.Location = New System.Drawing.Point(112, 152)
            Me.CUST_cboPayID.Name = "CUST_cboPayID"
            Me.CUST_cboPayID.Size = New System.Drawing.Size(176, 21)
            Me.CUST_cboPayID.TabIndex = 6
            '
            'CUST_cboCollSalesTax
            '
            Me.CUST_cboCollSalesTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboCollSalesTax.Location = New System.Drawing.Point(464, 200)
            Me.CUST_cboCollSalesTax.Name = "CUST_cboCollSalesTax"
            Me.CUST_cboCollSalesTax.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboCollSalesTax.TabIndex = 15
            '
            'CUST_cboCrAppShip
            '
            Me.CUST_cboCrAppShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboCrAppShip.Location = New System.Drawing.Point(464, 176)
            Me.CUST_cboCrAppShip.Name = "CUST_cboCrAppShip"
            Me.CUST_cboCrAppShip.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboCrAppShip.TabIndex = 14
            '
            'CUST_cboCrAppRec
            '
            Me.CUST_cboCrAppRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboCrAppRec.Location = New System.Drawing.Point(464, 152)
            Me.CUST_cboCrAppRec.Name = "CUST_cboCrAppRec"
            Me.CUST_cboCrAppRec.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboCrAppRec.TabIndex = 13
            '
            'CUST_cboRepLCD
            '
            Me.CUST_cboRepLCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboRepLCD.Location = New System.Drawing.Point(464, 128)
            Me.CUST_cboRepLCD.Name = "CUST_cboRepLCD"
            Me.CUST_cboRepLCD.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboRepLCD.TabIndex = 12
            '
            'CUST_cboRepNonWrty
            '
            Me.CUST_cboRepNonWrty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboRepNonWrty.Location = New System.Drawing.Point(464, 104)
            Me.CUST_cboRepNonWrty.Name = "CUST_cboRepNonWrty"
            Me.CUST_cboRepNonWrty.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboRepNonWrty.TabIndex = 11
            '
            'CUST_txtRejectTimes
            '
            Me.CUST_txtRejectTimes.Location = New System.Drawing.Point(112, 128)
            Me.CUST_txtRejectTimes.Name = "CUST_txtRejectTimes"
            Me.CUST_txtRejectTimes.TabIndex = 5
            Me.CUST_txtRejectTimes.Text = ""
            '
            'CUST_txtRejectDays
            '
            Me.CUST_txtRejectDays.Location = New System.Drawing.Point(112, 104)
            Me.CUST_txtRejectDays.Name = "CUST_txtRejectDays"
            Me.CUST_txtRejectDays.TabIndex = 4
            Me.CUST_txtRejectDays.Text = ""
            '
            'CUST_cboPlusParts
            '
            Me.CUST_cboPlusParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CUST_cboPlusParts.Location = New System.Drawing.Point(464, 80)
            Me.CUST_cboPlusParts.Name = "CUST_cboPlusParts"
            Me.CUST_cboPlusParts.Size = New System.Drawing.Size(48, 21)
            Me.CUST_cboPlusParts.TabIndex = 10
            Me.CUST_cboPlusParts.Visible = False
            '
            'CUST_txtLName
            '
            Me.CUST_txtLName.Location = New System.Drawing.Point(112, 80)
            Me.CUST_txtLName.Name = "CUST_txtLName"
            Me.CUST_txtLName.Size = New System.Drawing.Size(176, 20)
            Me.CUST_txtLName.TabIndex = 3
            Me.CUST_txtLName.Text = ""
            '
            'CUST_txtFName
            '
            Me.CUST_txtFName.Location = New System.Drawing.Point(112, 48)
            Me.CUST_txtFName.Name = "CUST_txtFName"
            Me.CUST_txtFName.Size = New System.Drawing.Size(352, 20)
            Me.CUST_txtFName.TabIndex = 2
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
            Me.Label57.Size = New System.Drawing.Size(696, 32)
            Me.Label57.TabIndex = 59
            '
            'tbSearch
            '
            Me.tbSearch.Controls.AddRange(New System.Windows.Forms.Control() {Me.searchGrid})
            Me.tbSearch.Location = New System.Drawing.Point(4, 22)
            Me.tbSearch.Name = "tbSearch"
            Me.tbSearch.Size = New System.Drawing.Size(696, 454)
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
            Me.searchGrid.Size = New System.Drawing.Size(664, 440)
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
            "7"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" Def" & _
            "RecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>409</" & _
            "Height><CaptionStyle parent=""Heading"" me=""Style23"" /><EditorStyle parent=""Editor" & _
            """ me=""Style15"" /><EvenRowStyle parent=""EvenRow"" me=""Style21"" /><FilterBarStyle p" & _
            "arent=""FilterBar"" me=""Style26"" /><FooterStyle parent=""Footer"" me=""Style17"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style25"" /><HeadingStyle parent=""Heading"" me=""Style1" & _
            "6"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style20"" /><InactiveStyle pare" & _
            "nt=""Inactive"" me=""Style19"" /><OddRowStyle parent=""OddRow"" me=""Style22"" /><Record" & _
            "SelectorStyle parent=""RecordSelector"" me=""Style24"" /><SelectedStyle parent=""Sele" & _
            "cted"" me=""Style18"" /><Style parent=""Normal"" me=""Style14"" /><ClientRect>0, 29, 66" & _
            "2, 409</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></" & _
            "C1.Win.C1TrueDBGrid.GroupByView></Splits><NamedStyles><Style parent="""" me=""Norma" & _
            "l"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /" & _
            "><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" />" & _
            "<Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Sty" & _
            "le parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><St" & _
            "yle parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" />" & _
            "<Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></N" & _
            "amedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Lay" & _
            "out><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 662, 438</Clien" & _
            "tArea><PrintPageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent" & _
            "="""" me=""Style2"" /></Blob>"
            '
            'tbCustMarkup
            '
            Me.tbCustMarkup.Controls.AddRange(New System.Windows.Forms.Control() {Me.CM_cboCustomer, Me.CM_btnSave, Me.CM_btnCancel, Me.GroupBox4, Me.CM_cboProduct, Me.Label10, Me.Label9, Me.Label58})
            Me.tbCustMarkup.Location = New System.Drawing.Point(4, 22)
            Me.tbCustMarkup.Name = "tbCustMarkup"
            Me.tbCustMarkup.Size = New System.Drawing.Size(696, 454)
            Me.tbCustMarkup.TabIndex = 4
            Me.tbCustMarkup.Text = "Cust Markup"
            '
            'CM_cboCustomer
            '
            Me.CM_cboCustomer.Location = New System.Drawing.Point(168, 56)
            Me.CM_cboCustomer.Name = "CM_cboCustomer"
            Me.CM_cboCustomer.Size = New System.Drawing.Size(400, 21)
            Me.CM_cboCustomer.TabIndex = 1
            '
            'CM_btnSave
            '
            Me.CM_btnSave.Location = New System.Drawing.Point(488, 8)
            Me.CM_btnSave.Name = "CM_btnSave"
            Me.CM_btnSave.Size = New System.Drawing.Size(80, 24)
            Me.CM_btnSave.TabIndex = 10
            Me.CM_btnSave.Text = "Save"
            '
            'CM_btnCancel
            '
            Me.CM_btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.CM_btnCancel.Location = New System.Drawing.Point(376, 8)
            Me.CM_btnCancel.Name = "CM_btnCancel"
            Me.CM_btnCancel.Size = New System.Drawing.Size(80, 24)
            Me.CM_btnCancel.TabIndex = 9
            Me.CM_btnCancel.Text = "Cancel"
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.CM_txtRTM, Me.Label71, Me.CM_txtNTF, Me.Label67, Me.CM_cboPlusparts, Me.lblCMplusParts, Me.CM_txtInventoryMarkup, Me.Label11, Me.CM_cboInvMthdID, Me.CM_txtCustMarkup, Me.CM_txtNER, Me.CM_txtRUR, Me.Label15, Me.Label14, Me.Label13, Me.Label12})
            Me.GroupBox4.Location = New System.Drawing.Point(32, 128)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(560, 152)
            Me.GroupBox4.TabIndex = 3
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Markups"
            '
            'CM_txtRTM
            '
            Me.CM_txtRTM.Location = New System.Drawing.Point(464, 24)
            Me.CM_txtRTM.Name = "CM_txtRTM"
            Me.CM_txtRTM.Size = New System.Drawing.Size(72, 20)
            Me.CM_txtRTM.TabIndex = 4
            Me.CM_txtRTM.Text = ""
            '
            'Label71
            '
            Me.Label71.Location = New System.Drawing.Point(432, 24)
            Me.Label71.Name = "Label71"
            Me.Label71.Size = New System.Drawing.Size(32, 16)
            Me.Label71.TabIndex = 62
            Me.Label71.Text = "RTM:"
            Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_txtNTF
            '
            Me.CM_txtNTF.Location = New System.Drawing.Point(248, 24)
            Me.CM_txtNTF.Name = "CM_txtNTF"
            Me.CM_txtNTF.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtNTF.TabIndex = 2
            Me.CM_txtNTF.Text = ""
            '
            'Label67
            '
            Me.Label67.Location = New System.Drawing.Point(208, 24)
            Me.Label67.Name = "Label67"
            Me.Label67.Size = New System.Drawing.Size(38, 16)
            Me.Label67.TabIndex = 61
            Me.Label67.Text = "NTF:"
            Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_cboPlusparts
            '
            Me.CM_cboPlusparts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CM_cboPlusparts.Location = New System.Drawing.Point(376, 112)
            Me.CM_cboPlusparts.Name = "CM_cboPlusparts"
            Me.CM_cboPlusparts.Size = New System.Drawing.Size(48, 21)
            Me.CM_cboPlusparts.TabIndex = 8
            '
            'lblCMplusParts
            '
            Me.lblCMplusParts.Location = New System.Drawing.Point(312, 114)
            Me.lblCMplusParts.Name = "lblCMplusParts"
            Me.lblCMplusParts.Size = New System.Drawing.Size(64, 16)
            Me.lblCMplusParts.TabIndex = 59
            Me.lblCMplusParts.Text = "Plus Parts:"
            Me.lblCMplusParts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_txtInventoryMarkup
            '
            Me.CM_txtInventoryMarkup.Location = New System.Drawing.Point(360, 48)
            Me.CM_txtInventoryMarkup.Name = "CM_txtInventoryMarkup"
            Me.CM_txtInventoryMarkup.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtInventoryMarkup.TabIndex = 6
            Me.CM_txtInventoryMarkup.Text = ""
            '
            'Label11
            '
            Me.Label11.Location = New System.Drawing.Point(256, 48)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(100, 16)
            Me.Label11.TabIndex = 57
            Me.Label11.Text = "Inventory Markup:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_cboInvMthdID
            '
            Me.CM_cboInvMthdID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CM_cboInvMthdID.Location = New System.Drawing.Point(136, 72)
            Me.CM_cboInvMthdID.Name = "CM_cboInvMthdID"
            Me.CM_cboInvMthdID.Size = New System.Drawing.Size(288, 21)
            Me.CM_cboInvMthdID.TabIndex = 7
            '
            'CM_txtCustMarkup
            '
            Me.CM_txtCustMarkup.Location = New System.Drawing.Point(136, 48)
            Me.CM_txtCustMarkup.Name = "CM_txtCustMarkup"
            Me.CM_txtCustMarkup.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtCustMarkup.TabIndex = 5
            Me.CM_txtCustMarkup.Text = ""
            '
            'CM_txtNER
            '
            Me.CM_txtNER.Location = New System.Drawing.Point(360, 24)
            Me.CM_txtNER.Name = "CM_txtNER"
            Me.CM_txtNER.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtNER.TabIndex = 3
            Me.CM_txtNER.Text = ""
            '
            'CM_txtRUR
            '
            Me.CM_txtRUR.Location = New System.Drawing.Point(136, 24)
            Me.CM_txtRUR.Name = "CM_txtRUR"
            Me.CM_txtRUR.Size = New System.Drawing.Size(64, 20)
            Me.CM_txtRUR.TabIndex = 1
            Me.CM_txtRUR.Text = ""
            '
            'Label15
            '
            Me.Label15.Location = New System.Drawing.Point(32, 72)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(104, 16)
            Me.Label15.TabIndex = 12
            Me.Label15.Text = "Inventory Method:"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(24, 48)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(112, 16)
            Me.Label14.TabIndex = 11
            Me.Label14.Text = "Customer Markup:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(320, 24)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(40, 16)
            Me.Label13.TabIndex = 10
            Me.Label13.Text = "NER:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label12
            '
            Me.Label12.Location = New System.Drawing.Point(96, 24)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(38, 16)
            Me.Label12.TabIndex = 9
            Me.Label12.Text = "RUR:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CM_cboProduct
            '
            Me.CM_cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CM_cboProduct.Location = New System.Drawing.Point(168, 80)
            Me.CM_cboProduct.Name = "CM_cboProduct"
            Me.CM_cboProduct.Size = New System.Drawing.Size(400, 21)
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
            Me.Label58.Size = New System.Drawing.Size(696, 72)
            Me.Label58.TabIndex = 62
            '
            'tpgUpdLabor
            '
            Me.tpgUpdLabor.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgUpdLabor.Controls.AddRange(New System.Windows.Forms.Control() {Me.UL_pnlUpdateLabor})
            Me.tpgUpdLabor.Location = New System.Drawing.Point(4, 22)
            Me.tpgUpdLabor.Name = "tpgUpdLabor"
            Me.tpgUpdLabor.Size = New System.Drawing.Size(696, 454)
            Me.tpgUpdLabor.TabIndex = 10
            Me.tpgUpdLabor.Text = "Update Labor"
            '
            'UL_pnlUpdateLabor
            '
            Me.UL_pnlUpdateLabor.Controls.AddRange(New System.Windows.Forms.Control() {Me.UL_pnlShipDate, Me.UL_chkProdShipDate, Me.UL_btnUpdateLabor, Me.UL_chkInWip, Me.UL_cboModels, Me.Label72, Me.UL_cboCustomers, Me.Label73})
            Me.UL_pnlUpdateLabor.Location = New System.Drawing.Point(8, 8)
            Me.UL_pnlUpdateLabor.Name = "UL_pnlUpdateLabor"
            Me.UL_pnlUpdateLabor.Size = New System.Drawing.Size(656, 272)
            Me.UL_pnlUpdateLabor.TabIndex = 0
            '
            'UL_pnlShipDate
            '
            Me.UL_pnlShipDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.UL_dtpShipEndDate, Me.UL_dtShipStartDate, Me.Label75, Me.Label74})
            Me.UL_pnlShipDate.Location = New System.Drawing.Point(24, 120)
            Me.UL_pnlShipDate.Name = "UL_pnlShipDate"
            Me.UL_pnlShipDate.Size = New System.Drawing.Size(288, 72)
            Me.UL_pnlShipDate.TabIndex = 99
            Me.UL_pnlShipDate.Visible = False
            '
            'UL_dtpShipEndDate
            '
            Me.UL_dtpShipEndDate.CustomFormat = "yyyy-MM-dd"
            Me.UL_dtpShipEndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UL_dtpShipEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.UL_dtpShipEndDate.Location = New System.Drawing.Point(144, 40)
            Me.UL_dtpShipEndDate.Name = "UL_dtpShipEndDate"
            Me.UL_dtpShipEndDate.Size = New System.Drawing.Size(136, 21)
            Me.UL_dtpShipEndDate.TabIndex = 98
            Me.UL_dtpShipEndDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
            '
            'UL_dtShipStartDate
            '
            Me.UL_dtShipStartDate.CustomFormat = "yyyy-MM-dd"
            Me.UL_dtShipStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UL_dtShipStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.UL_dtShipStartDate.Location = New System.Drawing.Point(144, 8)
            Me.UL_dtShipStartDate.Name = "UL_dtShipStartDate"
            Me.UL_dtShipStartDate.Size = New System.Drawing.Size(136, 21)
            Me.UL_dtShipStartDate.TabIndex = 95
            Me.UL_dtShipStartDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
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
            'UL_chkProdShipDate
            '
            Me.UL_chkProdShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UL_chkProdShipDate.ForeColor = System.Drawing.Color.White
            Me.UL_chkProdShipDate.Location = New System.Drawing.Point(128, 88)
            Me.UL_chkProdShipDate.Name = "UL_chkProdShipDate"
            Me.UL_chkProdShipDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.UL_chkProdShipDate.Size = New System.Drawing.Size(176, 24)
            Me.UL_chkProdShipDate.TabIndex = 94
            Me.UL_chkProdShipDate.Text = "Production Ship Date"
            '
            'UL_btnUpdateLabor
            '
            Me.UL_btnUpdateLabor.BackColor = System.Drawing.Color.Green
            Me.UL_btnUpdateLabor.Location = New System.Drawing.Point(88, 200)
            Me.UL_btnUpdateLabor.Name = "UL_btnUpdateLabor"
            Me.UL_btnUpdateLabor.Size = New System.Drawing.Size(216, 23)
            Me.UL_btnUpdateLabor.TabIndex = 93
            Me.UL_btnUpdateLabor.Text = "Update Labor"
            '
            'UL_chkInWip
            '
            Me.UL_chkInWip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UL_chkInWip.ForeColor = System.Drawing.Color.White
            Me.UL_chkInWip.Location = New System.Drawing.Point(17, 88)
            Me.UL_chkInWip.Name = "UL_chkInWip"
            Me.UL_chkInWip.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.UL_chkInWip.Size = New System.Drawing.Size(84, 24)
            Me.UL_chkInWip.TabIndex = 92
            Me.UL_chkInWip.Text = "In WIP"
            '
            'UL_cboModels
            '
            Me.UL_cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.UL_cboModels.Caption = ""
            Me.UL_cboModels.CaptionHeight = 17
            Me.UL_cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.UL_cboModels.ColumnCaptionHeight = 17
            Me.UL_cboModels.ColumnFooterHeight = 17
            Me.UL_cboModels.ContentHeight = 15
            Me.UL_cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.UL_cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.UL_cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UL_cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.UL_cboModels.EditorHeight = 15
            Me.UL_cboModels.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.UL_cboModels.ItemHeight = 15
            Me.UL_cboModels.Location = New System.Drawing.Point(88, 56)
            Me.UL_cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.UL_cboModels.MaxDropDownItems = CType(5, Short)
            Me.UL_cboModels.MaxLength = 32767
            Me.UL_cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.UL_cboModels.Name = "UL_cboModels"
            Me.UL_cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.UL_cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.UL_cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.UL_cboModels.Size = New System.Drawing.Size(216, 21)
            Me.UL_cboModels.TabIndex = 89
            Me.UL_cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
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
            'UL_cboCustomers
            '
            Me.UL_cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.UL_cboCustomers.Caption = ""
            Me.UL_cboCustomers.CaptionHeight = 17
            Me.UL_cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.UL_cboCustomers.ColumnCaptionHeight = 17
            Me.UL_cboCustomers.ColumnFooterHeight = 17
            Me.UL_cboCustomers.ContentHeight = 15
            Me.UL_cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.UL_cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.UL_cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UL_cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.UL_cboCustomers.EditorHeight = 15
            Me.UL_cboCustomers.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.UL_cboCustomers.ItemHeight = 15
            Me.UL_cboCustomers.Location = New System.Drawing.Point(88, 24)
            Me.UL_cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.UL_cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.UL_cboCustomers.MaxLength = 32767
            Me.UL_cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.UL_cboCustomers.Name = "UL_cboCustomers"
            Me.UL_cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.UL_cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.UL_cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.UL_cboCustomers.Size = New System.Drawing.Size(216, 21)
            Me.UL_cboCustomers.TabIndex = 88
            Me.UL_cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'AB_lblBillCode
            '
            Me.AB_lblBillCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AB_lblBillCode.Location = New System.Drawing.Point(248, 256)
            Me.AB_lblBillCode.Name = "AB_lblBillCode"
            Me.AB_lblBillCode.Size = New System.Drawing.Size(136, 23)
            Me.AB_lblBillCode.TabIndex = 49
            Me.AB_lblBillCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmCustMaint
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(832, 558)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ctrlTab, Me.grpSection})
            Me.Name = "frmCustMaint"
            Me.Text = "frmCustMaint"
            Me.grpSection.ResumeLayout(False)
            Me.ctrlTab.ResumeLayout(False)
            Me.tbParent.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.tbCust2Price.ResumeLayout(False)
            CType(Me.CP_dgLaborPriceExcpt, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CP_dgLaborPrice, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbCreditCard.ResumeLayout(False)
            Me.tbLocation.ResumeLayout(False)
            Me.tbCustWrty.ResumeLayout(False)
            Me.tbAggBilling.ResumeLayout(False)
            Me.AB_gbAggregates.ResumeLayout(False)
            CType(Me.AB_gridAggCharge, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbCustomer.ResumeLayout(False)
            Me.tbSearch.ResumeLayout(False)
            CType(Me.searchGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tbCustMarkup.ResumeLayout(False)
            Me.GroupBox4.ResumeLayout(False)
            Me.tpgUpdLabor.ResumeLayout(False)
            Me.UL_pnlUpdateLabor.ResumeLayout(False)
            Me.UL_pnlShipDate.ResumeLayout(False)
            CType(Me.UL_cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.UL_cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Shared function"

        '*******************************************************************************
        Private Sub LoadCustomers(ByVal booReSelectVal As Boolean)
            Dim dt, dt2 As DataTable
            Dim iAB, iCUST, iCW, iLOC, iCC, iCP, iCM As Integer

            Try
                If Not IsNothing(AB_cboCustomer.SelectedValue) Then iAB = AB_cboCustomer.SelectedValue
                If Not IsNothing(CUST_cboCustomer.SelectedValue) Then iCUST = CUST_cboCustomer.SelectedValue
                If Not IsNothing(CW_cboCustomer.SelectedValue) Then iCW = CW_cboCustomer.SelectedValue
                If Not IsNothing(LOC_cboCustomer.SelectedValue) Then iLOC = LOC_cboCustomer.SelectedValue
                If Not IsNothing(CC_cboCustomer.SelectedValue) Then iCC = CC_cboCustomer.SelectedValue
                If Not IsNothing(CP_cboCustomer.SelectedValue) Then iCP = CP_cboCustomer.SelectedValue
                If Not IsNothing(CM_cboCustomer.SelectedValue) Then iCM = CM_cboCustomer.SelectedValue
                _booLoadData = True
                dt = Me._objCustMaintain.GetCustomersHasName1Only(True)
                BindDataToComboBox(AB_cboCustomer, dt, "Cust_ID", "Cust_Name1")
                dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(CUST_cboCustomer, dt2, "Cust_ID", "Cust_Name1")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(CW_cboCustomer, dt2, "Cust_ID", "Cust_Name1")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(LOC_cboCustomer, dt2, "Cust_ID", "Cust_Name1")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(CC_cboCustomer, dt2, "Cust_ID", "Cust_Name1")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(CP_cboCustomer, dt2, "Cust_ID", "Cust_Name1")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(CM_cboCustomer, dt2, "Cust_ID", "Cust_Name1")

                Me._booLoadData = False
                Me.AB_cboCustomer.SelectedValue = 0
                Me.CUST_cboCustomer.SelectedValue = 0
                Me.CW_cboCustomer.SelectedValue = 0
                Me.LOC_cboCustomer.SelectedValue = 0
                Me.CC_cboCustomer.SelectedValue = 0
                Me.CP_cboCustomer.SelectedValue = 0
                Me.CM_cboCustomer.SelectedValue = 0

                If booReSelectVal Then
                    Me.AB_cboCustomer.SelectedValue = iAB
                    Me.CUST_cboCustomer.SelectedValue = iCUST
                    Me.CW_cboCustomer.SelectedValue = iCW
                    Me.LOC_cboCustomer.SelectedValue = iLOC
                    Me.CC_cboCustomer.SelectedValue = iCC
                    Me.CP_cboCustomer.SelectedValue = iCP
                    Me.CM_cboCustomer.SelectedValue = iCM
                End If
            Catch ex As Exception
                Throw ex
            Finally
                : _booLoadData = False : Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LoadProducts(ByVal booReSelectVal As Boolean)
            Dim dt, dt2 As DataTable
            Dim iCW, iCP, iCM As Integer

            Try
                If booReSelectVal Then
                    iCW = CW_cboProduct.SelectedValue
                    iCP = CP_cboProduct.SelectedValue
                    iCM = CM_cboProduct.SelectedValue
                End If
                _booLoadData = True
                dt = Generic.GetProducts(True)
                BindDataToComboBox(CW_cboProduct, dt, "Prod_ID", "Prod_Desc")
                dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(CP_cboProduct, dt2, "Prod_ID", "Prod_Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(CM_cboProduct, dt2, "Prod_ID", "Prod_Desc")

                Me._booLoadData = False
                Me.CW_cboProduct.SelectedValue = 0
                Me.CP_cboProduct.SelectedValue = 0
                Me.CM_cboProduct.SelectedValue = 0
                If booReSelectVal Then
                    CW_cboProduct.SelectedValue = iCW
                    CP_cboProduct.SelectedValue = iCP
                    CM_cboProduct.SelectedValue = iCM
                End If

            Catch ex As Exception
                Throw ex
            Finally
                : _booLoadData = False : Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LoadParentCompany(ByVal booReSelectVal As Boolean)
            Dim dt, dt2 As DataTable
            Dim iPC_PCoID, iCUST_PCoID As Integer

            Try
                If booReSelectVal Then
                    iPC_PCoID = Me.PC_cboParentCo.SelectedValue
                    iCUST_PCoID = CUST_cboParentCo.SelectedValue
                End If

                _booLoadData = True
                'Load Parent Company for Parent Company & Customer tab
                dt = _objCustMaintain.GetParentCompany(True)
                BindDataToComboBox(Me.PC_cboParentCo, dt, "PCo_ID", "PCo_Name")
                dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.CUST_cboParentCo, dt2, "PCo_ID", "PCo_Name")

                Me._booLoadData = False
                'must set selected value to zero first so it will triger the selected event
                Me.PC_cboParentCo.SelectedValue = 0
                Me.CUST_cboParentCo.SelectedValue = 0
                If booReSelectVal Then
                    Me.PC_cboParentCo.SelectedValue = iPC_PCoID
                    Me.CUST_cboParentCo.SelectedValue = iCUST_PCoID
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booLoadData = False : Generic.DisposeDT(dt) : Generic.DisposeDT(dt2)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LoadPCPricingGroup(ByVal booReSelectVal As Boolean)
            Dim dt As DataTable
            Dim iPC As Integer

            Try
                If booReSelectVal Then iPC = PC_cboPrcGroup.SelectedValue

                _booLoadData = True
                'Load pricing group for Parent Company & Customer to price tab
                dt = _objCustMaintain.GetPricingGroup(True)
                BindDataToComboBox(Me.PC_cboPrcGroup, dt, "PrcGroup_ID", "PrcGroup_LDesc")

                Me._booLoadData = False
                Me.PC_cboPrcGroup.SelectedValue = 0

                If booReSelectVal Then PC_cboPrcGroup.SelectedValue = iPC
            Catch ex As Exception
                Throw ex
            Finally
                _booLoadData = False : Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LoadCustToPricePricingGroup(ByVal booReSelectVal As Boolean, ByVal iProdID As Integer)
            Dim dt As DataTable
            Dim iCP As Integer

            Try
                If booReSelectVal Then iCP = CP_cboPricingGroup.SelectedValue

                _booLoadData = True
                'Load pricing group for Customer to price tab
                dt = _objCustMaintain.GetPricingGroup(True, iProdID)
                BindDataToComboBox(Me.CP_cboPricingGroup, dt, "PrcGroup_ID", "PrcGroup_LDesc")

                Me._booLoadData = False
                Me.CP_cboPricingGroup.SelectedValue = 0

                If booReSelectVal Then CP_cboPricingGroup.SelectedValue = iCP
            Catch ex As Exception
                Throw ex
            Finally
                _booLoadData = False : Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LoadYesNoCombo()
            Dim dt, dt2 As DataTable

            Try
                _booLoadData = True
                'Load pricing group for Parent Company & Customer to price tab
                dt = Nothing
                dt = _objCustMaintain.CreateYesNoTable()
                BindDataToComboBox(Me.PC_cboPlusParts, dt, "ID", "Desc")
                dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.CUST_cboPlusParts, dt2, "ID", "Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.CUST_cboRepNonWrty, dt2, "ID", "Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.CUST_cboRepLCD, dt2, "ID", "Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.CUST_cboCrAppRec, dt2, "ID", "Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.CUST_cboCrAppShip, dt2, "ID", "Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.CUST_cboCollSalesTax, dt2, "ID", "Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.CUST_cboInvoiceDetail, dt2, "ID", "Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.CM_cboPlusparts, dt2, "ID", "Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.LOC_cboAfterMarket, dt2, "ID", "Desc")
                dt2 = Nothing : dt2 = New DataTable() : dt2 = dt.Copy
                BindDataToComboBox(Me.LOC_cboManifestDetail, dt2, "ID", "Desc")

                Me._booLoadData = False
                PC_cboPlusParts.SelectedValue = 0

                Me.CUST_cboPlusParts.SelectedValue = 0
                Me.CUST_cboRepNonWrty.SelectedValue = 0
                Me.CUST_cboRepLCD.SelectedValue = 0
                Me.CUST_cboCrAppRec.SelectedValue = 0
                Me.CUST_cboCrAppShip.SelectedValue = 0
                Me.CUST_cboCollSalesTax.SelectedValue = 0
                Me.CUST_cboInvoiceDetail.SelectedValue = 0

                Me.CM_cboPlusparts.SelectedValue = 0

                Me.LOC_cboAfterMarket.SelectedValue = 0
                Me.LOC_cboManifestDetail.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : _booLoadData = False
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LoadCreditCardExpDateCombo()
            Dim dt As DataTable
            Dim objDC As New Data.Buisness.DriveCam()

            Try
                Generic.DisposeDT(dt)
                dt = objDC.GetCCExpMonths()
                dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Me.CC_cboExpMonth.ValueMember = "ID"
                Me.CC_cboExpMonth.DisplayMember = "Month"
                Me.CC_cboExpMonth.SelectedValue = 0

                Generic.DisposeDT(dt)
                dt = objDC.GetCCExpYears()
                dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Me.CC_cboExpYear.ValueMember = "ID"
                Me.CC_cboExpYear.DisplayMember = "Year"
                Me.CC_cboExpYear.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub BindDataToComboBox(ByRef ctrl As ComboBox, ByVal dt As DataTable, _
                                       ByVal strValMember As String, ByVal strDispMember As String)
            Try
                ctrl.DataSource = dt.DefaultView
                ctrl.ValueMember = strValMember
                ctrl.DisplayMember = strDispMember
            Catch ex As Exception : Throw ex
            Finally : Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub frmCustMaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                LoadCustomers(False)
                LoadProducts(False)
                LoadParentCompany(False)
                LoadPCPricingGroup(False)
                LoadYesNoCombo()

                'Load PSS Part Warranty in Parent company & customer warranty tab
                dt = _objCustMaintain.GetPSSPartWarranty(True)
                BindDataToComboBox(Me.PC_cboWrtyParts, dt, "PSSWrtyParts_ID", "PSSWrtyParts_Desc")
                Me.PC_cboWrtyParts.SelectedValue = 0
                BindDataToComboBox(Me.CW_cboWrtyParts, dt, "PSSWrtyParts_ID", "PSSWrtyParts_Desc")
                Me.CW_cboWrtyParts.SelectedValue = 0

                'Load PSS Labor Warranty in Parent company & customer warranty tab
                dt = _objCustMaintain.GetPSSLaborWarranty(True)
                BindDataToComboBox(Me.PC_cboWrtyLabor, dt, "PSSWrtyLabor_ID", "PSSWrtyLabor_Desc")
                Me.PC_cboWrtyLabor.SelectedValue = 0
                BindDataToComboBox(Me.CW_cboWrtyLabor, dt, "PSSWrtyLabor_ID", "PSSWrtyLabor_Desc")
                Me.CW_cboWrtyLabor.SelectedValue = 0

                'Load Invoice Types in customer tab
                dt = _objCustMaintain.GetInvoiceDateTypes(True)
                BindDataToComboBox(CUST_cboInvDateType, dt, "InvDateType_ID", "InvDateType_Desc")
                Me.CUST_cboInvDateType.SelectedValue = 0
                'load department in customer tab
                dt = Nothing
                dt = _objCustMaintain.GetActiveDepts(True)
                BindDataToComboBox(CUST_cboDept, dt, "DepartmentID", "DepartmentDesc")
                Me.CUST_cboDept.SelectedValue = 0

                'load Pay Type in customer tab
                dt = Nothing
                dt = _objCustMaintain.GetPayMethod(True)
                BindDataToComboBox(Me.CUST_cboPayID, dt, "Pay_ID", "Pay_Desc")
                Me.CUST_cboPayID.SelectedValue = 0

                'load Sale person in customer tab
                dt = Nothing
                dt = _objCustMaintain.GetSalePerson(True)
                BindDataToComboBox(Me.CUST_cboSalesPerson, dt, "SlsP_ID", "Name")
                Me.CUST_cboSalesPerson.SelectedValue = 0

                'load state in location tab
                dt = Nothing
                dt = _objCustMaintain.GetStates(True)
                BindDataToComboBox(Me.LOC_cboState, dt, "State_ID", "State_Short")
                Me.LOC_cboState.SelectedValue = 0

                'load country in location tab
                dt = Nothing
                dt = _objCustMaintain.GetCountries(True)
                BindDataToComboBox(Me.LOC_cboCountry, dt, "Cntry_ID", "Cntry_ShortName")
                Me.LOC_cboCountry.SelectedValue = 0

                'load inventory method in customer markup tab
                dt = Nothing
                dt = _objCustMaintain.GetPartInventoryMethoid(True)
                BindDataToComboBox(Me.CM_cboInvMthdID, dt, "Invtrymdth_ID", "Invtrymdth_Desc")
                Me.CM_cboInvMthdID.SelectedValue = 0

                'load GetCredit Card Types in credit card tab
                dt = Nothing
                dt = _objCustMaintain.GetCreditCardTypes(True)
                BindDataToComboBox(Me.CC_cboCCType, dt, "CCType_ID", "CCType_Desc")
                Me.CC_cboCCType.SelectedValue = 0

                LoadCreditCardExpDateCombo()

                'Set Special permissions
                If ApplicationUser.GetPermission("UpdateLabor") > 0 Then Me.UL_pnlUpdateLabor.Visible = True Else Me.UL_pnlUpdateLabor.Visible = False
                Me.UL_dtShipStartDate.Value = Now()
                Me.UL_dtpShipEndDate.Value = Now

                populateSearchGrid()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
#End Region

#Region "Parent Company"

        '*******************************************************************************
        Private Sub PC_btnNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PC_btnNEW.Click
            Try
                Me.PC_cboParentCo.SelectedValue = 0
                ClearParentCoFields()
                PC_txtName.Visible = True
                PC_cboParentCo.Visible = False
                PC_txtName.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub PC_btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PC_btnCANCEL.Click
            Try
                ClearParentCoFields()
                PC_cboParentCo.Visible = True
                PC_cboParentCo.SelectedValue = 0
                PC_cboParentCo.SelectAll()
                PC_cboParentCo.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "PC_btnCANCEL_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub ClearParentCoFields()
            Try
                PC_txtName.Text = "" : PC_txtName.Visible = False
                PC_txtMotoCode.Text = ""
                PC_cboPrcGroup.SelectedValue = 0
                PC_txtPrcGroupID.Text = ""

                PC_cboPlusParts.SelectedValue = 0

                PC_txtMarkUp.Text = ""
                PC_txtRUR.Text = ""
                PC_txtNER.Text = ""

                PC_txtWrtyDays.Text = ""
                PC_cboWrtyParts.SelectedValue = 0
                PC_txtWrtyPartsID.Text = ""
                PC_cboWrtyLabor.SelectedValue = 0
                PC_txtWrtyLaborID.Text = ""

                Me.PC_chkEndUser.Checked = False
                PC_txtEndUserValue.Text = ""
                PC_txtPCoID.Text = ""

                Me.PC_chkInactive.Checked = False
                System.Windows.Forms.Application.DoEvents()

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub PC_cboParentCo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PC_cboParentCo.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                ClearParentCoFields()
                If Me.PC_cboParentCo.SelectedValue > 0 Then GetParentCoData(Me.PC_cboParentCo.SelectedValue)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "PC_cboParentCo_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Function GetParentCoData(ByVal iPCoID As Integer) As Boolean
            Dim dr As DataRow

            Try
                If Me.PC_cboParentCo.DataSource.Table.Select("PCo_ID = " & iPCoID).length = 0 Then
                    MessageBox.Show("Can not define Parent company in data source.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                Else
                    dr = Me.PC_cboParentCo.DataSource.Table.Select("PCo_ID = " & iPCoID)(0)

                    If IsDBNull(dr("PCo_Name")) = False Then PC_txtName.Text = dr("PCo_Name").ToString.Trim
                    If IsDBNull(dr("PCo_MotoCode")) = False Then PC_txtMotoCode.Text = dr("PCo_MotoCode")
                    PC_cboPrcGroup.SelectedValue = Convert.ToInt32(dr("PrcGroup_ID"))
                    Me.PC_txtPrcGroupID.Text = PC_cboPrcGroup.SelectedValue

                    If Convert.ToInt16(dr("PCo_FlatRateParts")) = 1 Then
                        PC_cboPlusParts.SelectedValue = 0
                    Else
                        PC_cboPlusParts.SelectedValue = 1
                    End If

                    If IsDBNull(dr("PCo_DefMarkUp")) = False Then PC_txtMarkUp.Text = dr("PCo_DefMarkUp")
                    If IsDBNull(dr("PCo_DefRUR")) = False Then PC_txtRUR.Text = dr("PCo_DefRUR")
                    If IsDBNull(dr("PCo_DefNER")) = False Then PC_txtNER.Text = dr("PCo_DefNER")

                    If IsDBNull(dr("PCo_DefWrtyDays")) = False Then PC_txtWrtyDays.Text = dr("PCo_DefWrtyDays")

                    PC_cboWrtyParts.SelectedValue = Convert.ToInt32(dr("PSSWrtyParts_ID"))
                    PC_txtWrtyPartsID.Text = PC_cboWrtyParts.SelectedValue
                    PC_cboWrtyLabor.SelectedValue = Convert.ToInt32(dr("PSSWrtyLabor_ID"))
                    PC_txtWrtyLaborID.Text = PC_cboWrtyLabor.SelectedValue

                    If IsDBNull(dr("PCo_EndUser")) = False Then
                        If Convert.ToInt16(dr("Pco_EndUser")) = 1 Then
                            PC_chkEndUser.Checked = True
                        Else
                            PC_chkEndUser.Checked = False
                        End If
                    End If

                    If Convert.ToInt16(dr("PCo_Active")) = 1 Then
                        PC_chkInactive.Checked = False
                    Else
                        PC_chkInactive.Checked = True
                    End If

                    PC_txtEndUserValue.Text = dr("Pco_EndUser")
                    PC_txtPCoID.Text = Me.PC_cboParentCo.SelectedValue
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************
        Private Sub PC_btnChangeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PC_btnChangeName.Click
            Dim strPCoNewName As String = ""
            Dim i As Integer = 0

            Try
                If Me.PC_cboParentCo.SelectedValue = 0 Then
                    MessageBox.Show("Please select Parent Company.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strPCoNewName = InputBox("Enter new name for parent: " & PC_cboParentCo.Text, "New Name", "", , ).Trim
                    If strPCoNewName.Trim.Length = 0 Then
                        MessageBox.Show("You must enter new name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf strPCoNewName.Trim.ToLower = Me.PC_cboParentCo.Text.Trim.ToLower Then
                        MessageBox.Show("New name is the same with old name. No change needed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._objCustMaintain.GetParentCompanyByName(strPCoNewName.Replace("'", "\'")).Rows.Count > 0 Then
                        MessageBox.Show("New name exists. Please choose a different name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        strPCoNewName = strPCoNewName.Replace("'", "\'")
                        i = Me._objCustMaintain.UpdateParentCompanyName(Me.PC_cboParentCo.SelectedValue, strPCoNewName)

                        If i > 0 Then
                            Me.LoadParentCompany(True)
                            Me.PC_cboParentCo.SelectAll() : Me.PC_cboParentCo.Focus()
                        Else
                            MessageBox.Show("System has failed to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "PC_btnChangeName_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub PC_btnSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PC_btnSAVE.Click
            Dim iPCoID, iPrcGroupID, iWrtyDays, iWrtyPartsID, iWrtyLaborID, iEndUser, iActive, iFlatRatePart, i As Integer
            Dim dbMarkUp, dbRUR, dbNER As Double

            Try
                iPCoID = 0 : iPrcGroupID = 0 : iWrtyDays = 0 : iWrtyPartsID = 0 : iActive = 0 : iFlatRatePart = 0
                iWrtyLaborID = 0 : iEndUser = 0 : i = 0 : dbMarkUp = 0 : dbRUR = 0 : dbNER = 0

                If Me.PC_txtName.Visible = False Then iPCoID = Me.PC_cboParentCo.SelectedValue

                If Me.PC_txtName.Visible = True AndAlso Me.PC_txtName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter company name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.PC_txtName.Focus()
                ElseIf Me.PC_txtName.Visible = True AndAlso Me._objCustMaintain.GetParentCompanyByName(Me.PC_txtName.Text.Trim).Rows.Count > 0 Then
                    MessageBox.Show("Name existed. Please enter a different name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.PC_txtName.SelectAll() : Me.PC_txtName.Focus()
                ElseIf PC_cboPrcGroup.SelectedValue = 0 Then
                    MessageBox.Show("Please select pricing group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.PC_cboPrcGroup.SelectAll() : Me.PC_cboPrcGroup.Focus()
                ElseIf PC_txtMarkUp.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter markup.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.PC_txtMarkUp.SelectAll() : Me.PC_txtMarkUp.Focus()
                ElseIf PC_txtRUR.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter RUR charge.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.PC_txtRUR.SelectAll() : Me.PC_txtRUR.Focus()
                ElseIf PC_txtNER.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter NER charge.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.PC_txtNER.SelectAll() : Me.PC_txtNER.Focus()
                ElseIf PC_txtWrtyDays.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter warranty days.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.PC_txtWrtyDays.SelectAll() : Me.PC_txtWrtyDays.Focus()
                ElseIf PC_cboWrtyParts.SelectedValue = 0 Then
                    MessageBox.Show("Please select warranty part option.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.PC_cboWrtyParts.SelectAll() : Me.PC_cboWrtyParts.Focus()
                ElseIf PC_cboWrtyLabor.SelectedValue = 0 Then
                    MessageBox.Show("Please select warranty labor option.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.PC_cboWrtyLabor.SelectAll() : Me.PC_cboWrtyLabor.Focus()
                Else
                    iPrcGroupID = Me.PC_cboPrcGroup.SelectedValue

                    Try : iWrtyDays = Convert.ToInt32(Me.PC_txtWrtyDays.Text)
                    Catch ex As Exception
                        MessageBox.Show("Warranty days must be integer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.PC_txtWrtyDays.SelectAll() : PC_txtWrtyDays.Focus() : Exit Sub
                    End Try

                    iWrtyPartsID = Me.PC_cboWrtyParts.SelectedValue
                    iWrtyLaborID = Me.PC_cboWrtyLabor.SelectedValue

                    If Me.PC_chkEndUser.Checked = True Then iEndUser = 1
                    If Me.PC_chkInactive.Checked = False Then iActive = 1
                    If Me.PC_cboPlusParts.SelectedValue = 0 Then iFlatRatePart = 1

                    Try : dbMarkUp = Convert.ToDouble(Me.PC_txtMarkUp.Text)
                    Catch ex As Exception
                        MessageBox.Show("Mark up value must be decimal.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.PC_txtMarkUp.SelectAll() : PC_txtMarkUp.Focus() : Exit Sub
                    End Try

                    Try : dbRUR = Convert.ToDouble(Me.PC_txtRUR.Text)
                    Catch ex As Exception
                        MessageBox.Show("RUR value must be decimal.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.PC_txtRUR.SelectAll() : PC_txtRUR.Focus() : Exit Sub
                    End Try

                    Try : dbNER = Convert.ToDouble(Me.PC_txtNER.Text)
                    Catch ex As Exception
                        MessageBox.Show("NER value must be decimal.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.PC_txtNER.SelectAll() : PC_txtNER.Focus() : Exit Sub
                    End Try

                    i = Me._objCustMaintain.SaveParentCompany(iPCoID, Me.PC_txtName.Text.Trim, Me.PC_txtMotoCode.Text.Trim, iPrcGroupID, _
                        dbMarkUp, dbRUR, dbNER, iWrtyDays, iWrtyPartsID, iWrtyLaborID, iEndUser, iActive, iFlatRatePart)

                    If i > 0 Then
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.LoadParentCompany(True)
                        Me.PC_cboParentCo.SelectedValue = iPCoID
                        GetParentCoData(iPCoID)
                        Me.PC_cboParentCo.Visible = True
                        Me.PC_txtName.Visible = False
                    Else
                        MessageBox.Show("System has failed to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        '*******************************************************************************

#End Region

#Region "Customer"
        '*******************************************************************************
        Private Sub ClearCustomerFields()
            Try
                CUST_txtFName.Text = "" : Me.CUST_txtFName.Visible = False
                CUST_txtLName.Text = ""
                CUST_txtRejectDays.Text = ""
                CUST_txtRejectTimes.Text = ""

                CUST_cboPayID.SelectedValue = 0
                CUST_cboParentCo.SelectedValue = 0
                CUST_cboSalesPerson.SelectedValue = 0

                CUST_cboPlusParts.SelectedValue = 0
                CUST_cboRepNonWrty.SelectedValue = 0
                CUST_cboRepLCD.SelectedValue = 0
                CUST_cboCrAppRec.SelectedValue = 0

                CUST_cboCrAppShip.SelectedValue = 0
                CUST_cboCollSalesTax.SelectedValue = 0
                Me.CUST_cboInvoiceDetail.SelectedValue = 0
                CUST_cboInvDateType.SelectedValue = 0
                Me.CUST_cboDept.SelectedValue = 0

                Me.CUST_chkAggBill.Checked = False
                Me.CUST_chkINACTIVE.Checked = False
                Me.CUST_chkPartNeed.Checked = False
                Me.CUST_chkReqAQLOnAllUnits.Checked = False

                CUST_txtMemo.Text = ""

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CUST_cboCustomer_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUST_cboCustomer.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub
                ClearCustomerFields()
                If Me.CUST_cboCustomer.SelectedValue > 0 Then GetCustomerData()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CUST_cboCustomer_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CUST_btnNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUST_btnNEW.Click
            Try
                Me.CUST_cboCustomer.SelectedValue = 0
                ClearCustomerFields()
                CUST_txtFName.Visible = True
                CUST_cboCustomer.Visible = False
                CUST_txtFName.SelectAll()
                CUST_txtFName.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CUST_btnNEW_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CUST_btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUST_btnCancel.Click
            Try
                ClearCustomerFields()
                Me.CUST_cboCustomer.SelectedValue = 0
                CUST_cboCustomer.Visible = True
                CUST_txtFName.Visible = False
                CUST_cboCustomer.SelectAll() : CUST_cboCustomer.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CUST_btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub GetCustomerData()
            Dim dr As DataRow

            Try
                If Me.CUST_cboCustomer.SelectedValue = 0 Then Exit Sub
                dr = Me.CUST_cboCustomer.DataSource.Table.select("Cust_ID = " & Me.CUST_cboCustomer.SelectedValue)(0)

                '//Get values for page
                If IsDBNull(dr("CUST_Name1")) = False Then CUST_txtFName.Text = dr("CUST_Name1")
                If IsDBNull(dr("CUST_Name2")) = False Then CUST_txtLName.Text = dr("CUST_Name2")
                If IsDBNull(dr("CUST_RejectDays")) = False Then CUST_txtRejectDays.Text = dr("CUST_RejectDays")
                If IsDBNull(dr("CUST_RejectTimes")) = False Then CUST_txtRejectTimes.Text = dr("CUST_RejectTimes")
                '//Pay ID
                CUST_cboPayID.SelectedValue = Convert.ToInt32(dr("Pay_ID"))
                '//Parent Company
                CUST_cboParentCo.SelectedValue = dr("PCo_ID")
                '//Sales Person
                CUST_cboSalesPerson.SelectedValue = dr("SlsP_ID")
                '//Plus Parts
                CUST_cboPlusParts.SelectedValue = dr("PlusParts")
                '//Repair Non Warranty
                CUST_cboRepNonWrty.SelectedValue = dr("Cust_RepairNonWrty")
                '//Replace LCD
                CUST_cboRepLCD.SelectedValue = dr("Cust_ReplaceLCD")
                '//Credit Approve Receive
                CUST_cboCrAppRec.SelectedValue = dr("Cust_CrApproveRec")
                '//Credit Approve Ship
                CUST_cboCrAppShip.SelectedValue = dr("Cust_CrApproveShip")
                '//Collect Sales Tax
                CUST_cboCollSalesTax.SelectedValue = dr("Cust_CollSalesTax")
                '//InvoiceDetail
                CUST_cboInvoiceDetail.SelectedValue = dr("Cust_InvoiceDetail")
                Me.CUST_cboInvDateType.SelectedValue = Convert.ToInt16(dr("InvDateType_ID"))
                Me.CUST_cboDept.SelectedValue = Convert.ToInt16(dr("DepartmentID"))

                '//Aggregate Billing
                If dr("CUST_AggBilling") = 1 Then
                    CUST_chkAggBill.Checked = True
                Else
                    CUST_chkAggBill.Checked = False
                End If
                '//Inactive
                If dr("CUST_Inactive") = 1 Then
                    CUST_chkINACTIVE.Checked = True
                Else
                    CUST_chkINACTIVE.Checked = False
                End If
                'Predetermine part need.
                If dr("PredeterminePartNeed") = 1 Then Me.CUST_chkPartNeed.Checked = True Else CUST_chkPartNeed.Checked = False
                '//Require 100% AQL Check
                If dr("ReqAQLCheckOnAllUnit") = 1 Then Me.CUST_chkReqAQLOnAllUnits.Checked = True Else CUST_chkReqAQLOnAllUnits.Checked = False

                If Not IsDBNull(dr("CUST_Memo")) Then Me.CUST_txtMemo.Text = dr("CUST_Memo").ToString
            Catch ex As Exception
                Throw ex
            Finally : dr = Nothing
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CUST_btnChangeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUST_btnChangeName.Click
            Dim strNewCustFName As String = ""
            Dim i As Integer = 0

            Try
                If Me.CUST_cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.CUST_cboCustomer.SelectAll() : Me.CUST_cboCustomer.Focus()
                Else
                    strNewCustFName = InputBox("Enter customer first name: ", "New Name", "").Trim
                    If strNewCustFName.Trim.Length = 0 Then
                        MessageBox.Show("You must enter first name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf strNewCustFName.Trim.ToLower = Me.CUST_cboCustomer.Text Then
                        MessageBox.Show("New name is the same with old name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me._objCustMaintain.GetCustByFirstName(strNewCustFName.Replace("'", "\'")).Rows.Count > 0 Then
                        MessageBox.Show("Name exists. Please choose a different name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        i = Me._objCustMaintain.UpdateCustFirstName(Me.CUST_cboCustomer.SelectedValue, strNewCustFName.Replace("'", "\'"))

                        If i > 0 Then
                            LoadCustomers(True) : Me.CUST_cboCustomer.SelectAll() : Me.CUST_cboCustomer.Focus()
                        Else
                            MessageBox.Show("System has failed to update customer's first name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CUST_btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CUST_btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUST_btnSave.Click
            Dim strError, strMemo, strFName, strLName As String
            Dim iCustID, i, iPayID, iPCoID, iSalesPerson, iPlusParts, iRepNonWrty, iRepLCD, iCrAppRec, iCrAppShip As String
            Dim iCollSalesTax, iInvoiceDetail, iAggBill, iReq100PerAQL, iPredeterminePartNeed, iInactive As Integer
            Dim iRejDays, iRejTime, iInvDateTypeID, iDeptID As Integer

            Try
                strError = "" : strMemo = "" : strFName = "" : strLName = ""

                strFName = Me.CUST_txtFName.Text.Replace("'", "\'")
                strLName = Me.CUST_txtLName.Text.Replace("'", "\'")

                If CUST_txtFName.Text.Trim.Length < 1 Then strError += "No First Name Defined." & vbCrLf
                If CUST_txtRejectDays.Text.Trim.Length < 1 Then strError += "No Reject Days Defined." & vbCrLf
                If CUST_txtRejectTimes.Text.Trim.Length < 1 Then strError += "No Reject Times Defined." & vbCrLf

                If CUST_cboPayID.SelectedValue = 0 Then strError += "No Pay ID Defined." & vbCrLf
                If CUST_cboParentCo.SelectedValue = 0 Then strError += "No Parent Company Defined." & vbCrLf
                If CUST_cboSalesPerson.SelectedValue = 0 Then strError += "No Sales Person Defined." & vbCrLf

                If Me.CUST_cboInvDateType.SelectedValue = 0 Then strError += "No invoice date type Defined." & vbCrLf
                If Me.CUST_cboDept.SelectedValue = 0 Then strError += "Please select department Defined." & vbCrLf
                If Me.CUST_cboInvDateType.SelectedValue = 0 Then strError &= "Please select invoice date type Defined." & vbCrLf
                If Me.CUST_cboDept.SelectedValue = 0 Then strError &= "Please select department." & vbCrLf

                If strError.Trim.Length > 0 Then
                    MessageBox.Show(strError, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf (Me.CUST_txtFName.Visible = True AndAlso Me.CUST_cboCustomer.SelectedValue = 0) AndAlso Me._objCustMaintain.GetCustByFirstName(strFName).Rows.Count > 0 Then
                    MessageBox.Show("Name existed. Please enter a different name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.CUST_txtFName.SelectAll() : Me.CUST_txtFName.Focus()
                Else
                    iCustID = Me.CUST_cboCustomer.SelectedValue

                    Try : iRejDays = Convert.ToInt32(Me.CUST_txtRejectDays.Text)
                    Catch : MessageBox.Show("Invalid Reject Days.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End Try
                    Try : iRejTime = Convert.ToInt32(Me.CUST_txtRejectTimes.Text)
                    Catch : MessageBox.Show("Invalid Reject Times.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End Try

                    iPayID = CUST_cboPayID.SelectedValue
                    iPCoID = Me.CUST_cboParentCo.SelectedValue
                    iSalesPerson = Me.CUST_cboSalesPerson.SelectedValue

                    iPlusParts = Me.CUST_cboPlusParts.SelectedValue
                    iRepNonWrty = Me.CUST_cboRepNonWrty.SelectedValue
                    iRepLCD = Me.CUST_cboRepLCD.SelectedValue
                    iCrAppRec = CUST_cboCrAppRec.SelectedValue
                    iCrAppShip = CUST_cboCrAppShip.SelectedValue

                    iCollSalesTax = CUST_cboCollSalesTax.SelectedValue
                    iInvoiceDetail = CUST_cboInvoiceDetail.SelectedValue
                    iInvDateTypeID = Me.CUST_cboInvDateType.SelectedValue
                    iDeptID = Me.CUST_cboDept.SelectedValue
                    If CUST_chkAggBill.Checked = True Then iAggBill = 1 Else iAggBill = 0
                    If Me.CUST_chkReqAQLOnAllUnits.Checked = True Then iReq100PerAQL = 1 Else iReq100PerAQL = 0
                    If Me.CUST_chkPartNeed.Checked = True Then iPredeterminePartNeed = 1 Else iPredeterminePartNeed = 0
                    If CUST_chkINACTIVE.Checked = True Then iInactive = 1 Else iInactive = 0

                    strMemo = CUST_txtMemo.Text.Trim.Replace("'", "\'")

                    i = Me._objCustMaintain.SaveCustomer(iCustID, strFName, strLName, iRejDays, iRejTime, _
                        iRepNonWrty, iRepLCD, iCrAppRec, iCrAppShip, iCollSalesTax, iInactive, iPayID, iPCoID, _
                        iSalesPerson, iInvoiceDetail, iAggBill, iReq100PerAQL, iInvDateTypeID, iPredeterminePartNeed, _
                        iDeptID, strMemo, Core.ApplicationUser.IDuser)
                    If i = 0 Then 'FAILED
                        MessageBox.Show("System has failed to save customer data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        LoadCustomers(True)
                        Me.CUST_cboCustomer.SelectedValue = iCustID
                        Me.CUST_txtFName.Visible = False
                        Me.CUST_cboCustomer.Visible = True
                        GetCustomerData()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************

#End Region

#Region "Customer Warranty"
        '*******************************************************************************
        Private Sub CW_btnCANCEL_CANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CW_btnCANCEL.Click
            Try
                Me.CW_cboCustomer.SelectedValue = 0
                Me.CW_cboProduct.SelectedValue = 0
                Me.CW_txtDaysInWrty.Text = ""
                Me.CW_cboWrtyParts.SelectedValue = 0
                Me.CW_cboWrtyLabor.SelectedValue = 0

                CW_cboCustomer.SelectAll() : CW_cboCustomer.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CW_btnCANCEL_CANCEL_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CW_btnSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CW_btnSAVE.Click
            Dim i, iCustID, iProdID, iWrtyDays, iPSSWrtyPartsID, iPSSWrtyLaborID As Integer
            Dim strError As String = ""

            Try
                If CW_cboCustomer.SelectedValue = 0 Then strError += "No customer selected." & vbCrLf
                If CW_cboProduct.SelectedValue = 0 Then strError += "No product selected." & vbCrLf
                If CW_txtDaysInWrty.Text.Trim.Length = 0 Then strError += "Days in Warranty value not defined." & vbCrLf
                If CW_cboWrtyParts.SelectedValue = 0 Then strError += "Warranty Parts value not defined." & vbCrLf
                If CW_cboWrtyLabor.SelectedValue = 0 Then strError += "Warranty Labor value not defined." & vbCrLf
                If strError.Trim.Length > 0 Then
                    MessageBox.Show(strError, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Try : iWrtyDays = Convert.ToInt32(Me.CW_txtDaysInWrty.Text)
                    Catch ex As Exception
                        MessageBox.Show("Invalid Days in Warranty value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.CW_txtDaysInWrty.SelectAll() : Me.CW_txtDaysInWrty.Focus() : Exit Sub
                    End Try

                    iCustID = CW_cboCustomer.SelectedValue
                    iProdID = CW_cboProduct.SelectedValue
                    iPSSWrtyPartsID = CW_cboWrtyParts.SelectedValue
                    iPSSWrtyLaborID = CW_cboWrtyLabor.SelectedValue
                    i = Me._objCustMaintain.SaveCustomerWarranty(iCustID, iProdID, iWrtyDays, iPSSWrtyPartsID, iPSSWrtyLaborID)
                    If i > 0 Then
                        MessageBox.Show("Save completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("System has failed to save data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Me.CW_cboCustomer.SelectAll() : Me.CW_cboCustomer.Focus()
                End If
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CW_cboCustomer_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CW_cboCustomer.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                CW_txtDaysInWrty.Text = ""
                CW_cboWrtyParts.SelectedValue = 0
                CW_cboWrtyLabor.SelectedValue = 0

                If Me.CW_cboCustomer.SelectedValue > 0 And Me.CW_cboProduct.SelectedValue > 0 Then
                    GetCustomerWarranty(Me.CW_cboCustomer.SelectedValue, Me.CW_cboProduct.SelectedValue)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CW_cboCustomer_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CW_cboProduct_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CW_cboProduct.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                CW_txtDaysInWrty.Text = ""
                CW_cboWrtyParts.SelectedValue = 0
                CW_cboWrtyLabor.SelectedValue = 0

                If Me.CW_cboCustomer.SelectedValue > 0 And Me.CW_cboProduct.SelectedValue > 0 Then
                    GetCustomerWarranty(Me.CW_cboCustomer.SelectedValue, Me.CW_cboProduct.SelectedValue)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CW_cboProduct_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub GetCustomerWarranty(ByVal iCustID As Integer, ByVal iProdID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objCustMaintain.GetCustomerPssWrty(iCustID, iProdID)
                If dt.Rows.Count > 0 Then
                    Me.CW_txtDaysInWrty.Text = dt.Rows(0)("CustWrty_DaysinWrty").ToString
                    '//Warranty Parts
                    CW_cboWrtyParts.SelectedValue = Convert.ToInt32(dt.Rows(0)("PSSWrtyParts_ID"))
                    '//Warranty labor
                    CW_cboWrtyLabor.SelectedValue = Convert.ToInt32(dt.Rows(0)("PSSWrtyLabor_ID"))
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************

#End Region

#Region "Location"
        '*******************************************************************************
        Private Sub ClearLocationFields()
            Try
                LOC_txtName.Text = ""
                LOC_txtAddress1.Text = ""
                LOC_txtAddress2.Text = ""
                LOC_txtCity.Text = ""
                LOC_cboState.SelectedValue = 0
                LOC_txtZip.Text = ""
                LOC_cboCountry.SelectedValue = 161
                LOC_txtContact.Text = ""
                LOC_txtPhone.Text = ""
                LOC_txtFax.Text = ""
                LOC_cboAfterMarket.SelectedValue = 0
                LOC_cboManifestDetail.SelectedValue = 0
                LOC_txtEmail.Text = ""
                LOC_txtMemo.Text = ""
                LOC_txtShippingMemo.Text = ""
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LoadLocations(ByVal iCustID As Integer)
            Dim dt As DataTable

            Try
                Me._booLoadData = True
                dt = Me._objCustMaintain.GetCustomerLocations(False, iCustID)
                With Me.LOC_ListBox
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .ValueMember = "Loc_ID"
                    .DisplayMember = "Loc_Name"
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._booLoadData = False : Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub GetLocationData(ByVal iLocID As Integer)
            Dim r As DataRow

            Try
                r = Me.LOC_ListBox.DataSource.Table.Select("Loc_ID = " & iLocID)(0)
                If IsDBNull(r("Loc_Name")) = False Then LOC_txtName.Text = r("Loc_Name")
                If IsDBNull(r("Loc_Address1")) = False Then LOC_txtAddress1.Text = r("Loc_Address1")
                If IsDBNull(r("Loc_Address2")) = False Then LOC_txtAddress2.Text = r("Loc_Address2")
                If IsDBNull(r("Loc_City")) = False Then LOC_txtCity.Text = r("Loc_City")
                LOC_cboState.SelectedValue = r("State_ID")
                If IsDBNull(r("Loc_Zip")) = False Then LOC_txtZip.Text = r("Loc_Zip")
                Me.LOC_cboCountry.SelectedValue = r("Cntry_ID")
                If IsDBNull(r("Loc_Contact")) = False Then LOC_txtContact.Text = r("Loc_Contact")
                If IsDBNull(r("Loc_Phone")) = False Then LOC_txtPhone.Text = r("Loc_Phone")
                If IsDBNull(r("Loc_Fax")) = False Then LOC_txtFax.Text = r("Loc_Fax")

                If IsDBNull(r("Loc_Email")) = False Then LOC_txtEmail.Text = r("Loc_Email")
                If IsDBNull(r("Loc_Memo")) = False Then LOC_txtMemo.Text = r("Loc_Memo")
                If IsDBNull(r("Loc_ShipMemo")) = False Then LOC_txtShippingMemo.Text = r("Loc_ShipMemo")

                '//After Market
                LOC_cboAfterMarket.SelectedValue = Convert.ToInt16(r("Loc_AfterMarket"))
                '//Manifest Detail
                LOC_cboManifestDetail.SelectedValue = Convert.ToInt16(r("Loc_ManifestDetail"))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LOC_cboCustomer_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOC_cboCustomer.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub
                ClearLocationFields()
                LOC_ListBox.DataSource = Nothing
                If Me.LOC_cboCustomer.SelectedValue > 0 Then
                    Me.LoadLocations(Me.LOC_cboCustomer.SelectedValue)
                    If Not IsNothing(Me.LOC_ListBox.DataSource) AndAlso Me.LOC_ListBox.Items.Count > 0 AndAlso Me.LOC_ListBox.SelectedValue > 0 Then
                        GetLocationData(LOC_ListBox.SelectedValue)
                        Me.LOC_txtName.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LOC_ListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOC_ListBox.SelectedIndexChanged
            Try
                If Me._booLoadData = True Then Exit Sub
                If Not IsNothing(Me.LOC_ListBox.DataSource) AndAlso Me.LOC_ListBox.Items.Count > 0 AndAlso Me.LOC_ListBox.SelectedValue > 0 Then
                    GetLocationData(LOC_ListBox.SelectedValue)
                    Me.LOC_txtName.SelectAll() : Me.LOC_txtName.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "LOC_ListBox_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LOC_btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOC_btnNew.Click
            Try
                ClearLocationFields()
                LOC_txtName.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "LOC_btnNew_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LOC_btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOC_btnCancel.Click
            Try
                ClearLocationFields()
                Me.LOC_ListBox.DataSource = Nothing
                Me.LOC_cboCustomer.SelectedValue = 0
                Me.LOC_cboCustomer.SelectAll()
                LOC_cboCustomer.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "LOC_btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LOC_btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOC_btnSave.Click
            Dim i, iCustID, iLocID, iStateID, iCountryID, iManifestDetail, iAfterMarket As Integer
            Dim strError, strLocName, strAddr1, strAddr2, strCity, strZip, strContact, strPhone, strFax, strEmail, strMemo, strShipMemo As String
            Dim dt As DataTable

            Try
                strError = ""
                If LOC_cboCustomer.SelectedValue = 0 Then strError += "No Customer Selected." & vbCrLf
                If LOC_txtName.Text.Trim.Length = 0 Then strError += "No Location Name Defined." & vbCrLf
                If LOC_txtAddress1.Text.Trim.Length = 0 Then strError += "No Location Address Line 1 Defined." & vbCrLf
                If LOC_txtCity.Text.Trim.Length = 0 Then strError += "No City Defined." & vbCrLf
                If LOC_cboState.SelectedValue = 0 Then strError += "No State Defined." & vbCrLf
                If LOC_txtZip.Text.Trim.Length = 0 Then strError += "No Zip Code Defined." & vbCrLf
                If LOC_cboCountry.SelectedValue = 0 Then strError += "No Country Defined." & vbCrLf
                If LOC_txtContact.Text.Trim.Length = 0 Then strError += "No Contact Name Defined." & vbCrLf
                If LOC_txtPhone.Text.Trim.Length = 0 Then strError += "No Telephone Number Defined." & vbCrLf

                'If LOC_cboAfterMarket.SelectedValue = 0 Then strError += "No After Market Value Selected." & vbCrLf
                'If LOC_cboManifestDetail.SelectedValue = 0 Then strError += "No Manifest Detail Value Selected." & vbCrLf

                If strError.Trim.Length > 0 Then
                    MessageBox.Show(strError, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iCustID = Me.LOC_cboCustomer.SelectedValue
                    strLocName = Me.LOC_txtName.Text.Trim.Replace("'", "\'")
                    dt = Me._objCustMaintain.GetCustomerLocByLocName(iCustID, strLocName)

                    If dt.Rows.Count > 0 Then iLocID = Convert.ToInt32(dt.Rows(0)("Loc_ID"))

                    iStateID = Me.LOC_cboState.SelectedValue
                    iCountryID = LOC_cboCountry.SelectedValue
                    iManifestDetail = LOC_cboManifestDetail.SelectedValue
                    iAfterMarket = LOC_cboAfterMarket.SelectedValue

                    strAddr1 = Me.LOC_txtAddress1.Text.Trim.Replace("'", "\'")
                    strAddr2 = Me.LOC_txtAddress2.Text.Trim.Replace("'", "\'")
                    strCity = Me.LOC_txtCity.Text.Trim.Replace("'", "\'")
                    strZip = Me.LOC_txtZip.Text.Trim.Replace("'", "\'")
                    strContact = Me.LOC_txtContact.Text.Trim("'", "\'")
                    strPhone = Me.LOC_txtPhone.Text.Trim.Replace("'", "\'")
                    strFax = Me.LOC_txtFax.Text.Trim.Replace("'", "\'")
                    strEmail = Me.LOC_txtEmail.Text.Trim.Replace("'", "\'")
                    strMemo = Me.LOC_txtMemo.Text.Trim.Replace("'", "\'")
                    strShipMemo = Me.LOC_txtShippingMemo.Text.Trim.Replace("'", "\'")

                    i = Me._objCustMaintain.SaveCustomerLocation(iLocID, strLocName, strAddr1, _
                    strAddr2, strCity, strZip, strContact, strPhone, strFax, strEmail, iAfterMarket, _
                    iManifestDetail, strMemo, strShipMemo, iStateID, iCountryID, iCustID)
                    If i > 0 Then
                        Me.LoadLocations(iCustID)
                        ClearLocationFields()
                    Else
                        MessageBox.Show("System has failed to save location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "LOC_btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LOC_btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOC_btnOptions.Click

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

        '*******************************************************************************
#End Region

#Region "Credit Card"
        '*******************************************************************************
        Private Sub ClearCreditCardFields()
            Try
                Me.CC_cboCCType.SelectedValue = 0
                Me.CC_txtCCNumber.Text = ""
                Me.CC_txtAuthCode.Text = ""
                Me.CC_cboExpMonth.SelectedValue = 0
                Me.CC_cboExpYear.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CC_btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_btnCANCEL.Click
            Try
                Me.CC_cboCustomer.SelectedValue = 0
                Me.CC_cboCCType.SelectedValue = 0
                Me.CC_txtCCNumber.Text = ""
                Me.CC_txtAuthCode.Text = ""
                Me.CC_cboExpMonth.SelectedValue = 0 : Me.CC_cboExpYear.SelectedValue = 0
                Me.CC_cboCustomer.SelectAll() : Me.CC_cboCustomer.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CC_btnCANCEL_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CC_btnSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_btnSAVE.Click
            Dim i, iCustID, iCreditCardTypeID As Integer
            Dim strError, strCreditCarNo, strAuthCode, strExpDate As String

            Try
                strError = ""
                If CC_cboCustomer.SelectedValue = 0 Then strError += "No Customer Selected." & vbCrLf
                If CC_cboCCType.SelectedValue = 0 Then strError += "No Credit Card Type Selected." & vbCrLf
                If CC_txtCCNumber.Text.Trim.Length = 0 Then strError += "No Credit Card Number Defined." & vbCrLf
                If CC_txtCCNumber.Text.Trim.Length > 16 Or CC_txtCCNumber.Text.Trim.Length < 13 Then strError += "Length of Credit Card Number is Invalid."
                If CC_txtAuthCode.Text.Trim.Length = 0 Then strError += "No Credit Card Authorization Defined." & vbCrLf
                If CC_txtAuthCode.Text.Trim.Length > 4 Then strError += "Card Authorization Invalid Defined." & vbCrLf
                If Me.CC_cboExpMonth.SelectedValue = 0 Then strError += "No Expiration Month Defined." & vbCrLf
                If Me.CC_cboExpYear.SelectedValue = 0 Then strError += "No Expiration Year Defined." & vbCrLf
                If strError.Trim.Length > 0 Then
                    MessageBox.Show(strError, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iCustID = CC_cboCustomer.SelectedValue
                    iCreditCardTypeID = CC_cboCCType.SelectedValue
                    strCreditCarNo = CC_txtCCNumber.Text.Trim
                    strAuthCode = CC_txtAuthCode.Text.Trim
                    strExpDate = Format(Me.CC_cboExpMonth.SelectedValue, "00") & "/" & Format(Me.CC_cboExpYear.SelectedValue, "00")
                    i = Me._objCustMaintain.SaveCreditCard(iCustID, strCreditCarNo, strAuthCode, strExpDate, iCreditCardTypeID)
                    If i > 0 Then
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.CC_cboCustomer.SelectAll() : Me.CC_cboCustomer.Focus()
                    Else
                        MessageBox.Show("System has failed to save credit card information.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CC_btnSAVE_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CC_cboCustomer_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_cboCustomer.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                ClearCreditCardFields()

                If Me.CC_cboCustomer.SelectedValue > 0 Then GetCreditCardData(Me.CC_cboCustomer.SelectedValue)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CC_cboCustomer_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub GetCreditCardData(ByVal iCustID As Int32)
            Dim dt As DataTable
            Dim strDecpErrMsg As String = ""

            Try
                strDecpErrMsg = ""
                dt = Me._objCustMaintain.GetCreditCard(iCustID)

                If dt.Rows.Count > 0 Then
                    If IsDBNull(Trim(dt.Rows(0)("CreditCard_Num"))) = False Then
                        Me.CC_txtCCNumber.Text = EncDec.Rijndael.Decrypt(dt.Rows(0)("CreditCard_Num"), strDecpErrMsg)
                    End If

                    If IsDBNull(dt.Rows(0)("CreditCard_AuthCode")) = False Then
                        Me.CC_txtAuthCode.Text = EncDec.Rijndael.Decrypt(dt.Rows(0)("CreditCard_AuthCode"), strDecpErrMsg)
                    End If

                    If IsDBNull(Trim(dt.Rows(0)("CreditCard_ExpDate"))) = False AndAlso dt.Rows(0)("CreditCard_ExpDate").ToString.Trim.Length > 0 Then
                        Me.CC_cboExpMonth.SelectedValue = Microsoft.VisualBasic.Left(dt.Rows(0)("CreditCard_ExpDate").ToString.Trim, 2)
                        Me.CC_cboExpYear.SelectedValue = Microsoft.VisualBasic.Right(dt.Rows(0)("CreditCard_ExpDate").ToString.Trim, 2)
                    End If

                    CC_cboCCType.SelectedValue = Convert.ToInt32(dt.Rows(0)("ccardtype_ID"))

                    If strDecpErrMsg.Trim.Length > 0 Then
                        MessageBox.Show(strDecpErrMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************

#End Region

#Region "Cust To Price"

        '*******************************************************************************
        Private Sub CP_btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CP_btnCANCEL.Click
            Try
                Me.CP_cboCustomer.SelectedValue = 0
                Me.CP_cboProduct.SelectedValue = 0
                Me.CP_cboPricingGroup.SelectedValue = 0
                Me.CP_dgLaborPrice.DataSource = Nothing
                Me.CP_dgLaborPriceExcpt.DataSource = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CP_btnCANCEL_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CP_cboCustomer_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CP_cboCustomer.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                Me.CP_cboProduct.SelectedValue = 0
                Me.CP_cboPricingGroup.SelectedValue = 0
                CP_dgLaborPriceExcpt.DataSource = Nothing
                Me.CP_dgLaborPrice.DataSource = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CP_cboCustomer_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CP_cboProduct_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CP_cboProduct.SelectedValueChanged
            Dim dt As DataTable

            Try
                If Me._booLoadData = True Then Exit Sub

                CP_cboPricingGroup.SelectedValue = 0
                CP_dgLaborPriceExcpt.DataSource = Nothing
                Me.CP_dgLaborPrice.DataSource = Nothing
                Me.CP_lblExistingOfPrcGrp.Text = ""

                If Me.CP_cboCustomer.SelectedValue > 0 AndAlso Me.CP_cboProduct.SelectedValue > 0 Then
                    Me.LoadCustToPricePricingGroup(False, Me.CP_cboProduct.SelectedValue)
                    dt = Me._objCustMaintain.GetCustomerToPrice(Me.CP_cboCustomer.SelectedValue, Me.CP_cboProduct.SelectedValue)

                    If dt.Rows.Count > 0 Then
                        If Not IsNothing(Me.CP_cboPricingGroup.DataSource) AndAlso Me.CP_cboPricingGroup.DataSource.Table.Select("PrcGroup_ID = " & dt.Rows(0)("PrcGroup_ID").ToString).length > 0 Then
                            Me.CP_cboPricingGroup.SelectedValue = dt.Rows(0)("PrcGroup_ID")
                        End If
                        CP_lblExistingOfPrcGrp.Text = "Defined - " & dt.Rows(0)("PrcGroup_LDesc")
                    Else
                        CP_lblExistingOfPrcGrp.Text = "Pricing Group is not defined."
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CP_cboProduct_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CP_cboPricingGroup_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CP_cboPricingGroup.SelectedValueChanged
            Dim iSelPrcGrpID, iProdID, iCustID As Integer
            Dim dt As DataTable

            Try
                If Me._booLoadData = True Then Exit Sub

                '//get the ID for Pricing Group
                iSelPrcGrpID = CP_cboPricingGroup.SelectedValue
                iProdID = CP_cboProduct.SelectedValue
                iCustID = Me.CP_cboCustomer.SelectedValue

                Me.CP_dgLaborPrice.DataSource = Nothing
                Me.CP_dgLaborPriceExcpt.DataSource = Nothing

                If iSelPrcGrpID > 0 AndAlso iProdID > 0 AndAlso iCustID > 0 Then
                    GetCustomerPriceData(iCustID, iProdID, iSelPrcGrpID)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CP_cboPricingGroup_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub GetCustomerPriceData(ByVal iCustID As Integer, ByVal iProdID As Integer, ByVal iPrcGrp As Integer)
            Dim objPricing As New PSS.Data.Buisness.Pricing()
            Dim dtLaborPrc, dtLaborPrcExcpt As DataTable

            Try
                If iCustID > 0 AndAlso iPrcGrp > 0 AndAlso iProdID > 0 Then
                    dtLaborPrcExcpt = objPricing.GetLaborPriceExcpt(iPrcGrp)
                    CP_dgLaborPriceExcpt.DataSource = dtLaborPrcExcpt.DefaultView

                    '//get data from tlaborprc
                    dtLaborPrc = objPricing.GetLaborPrice(iPrcGrp, iProdID, , )
                    Me.CP_dgLaborPrice.DataSource = dtLaborPrc.DefaultView
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtLaborPrc) : Generic.DisposeDT(dtLaborPrcExcpt)
                objPricing = Nothing
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CP_btnSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CP_btnSAVE.Click
            Dim dt As DataTable
            Dim i, iCustID, iPrcGrp, iProdID As Integer

            Try
                iCustID = Me.CP_cboCustomer.SelectedValue
                iPrcGrp = Me.CP_cboPricingGroup.SelectedValue
                iProdID = Me.CP_cboProduct.SelectedValue
                If iCustID = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.CP_cboCustomer.SelectAll() : Me.CP_cboCustomer.Focus()
                ElseIf iProdID = 0 Then
                    MessageBox.Show("Please select product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.CP_cboProduct.SelectAll() : Me.CP_cboProduct.Focus()
                ElseIf iPrcGrp = 0 Then
                    MessageBox.Show("Please select pricing group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.CP_cboPricingGroup.SelectAll() : Me.CP_cboPricingGroup.Focus()
                Else
                    dt = Me._objCustMaintain.GetCustomerToPrice(iCustID, iProdID)
                    If dt.Rows.Count > 0 Then
                        If iPrcGrp = Convert.ToInt32(dt.Rows(0)("PrcGroup_ID")) Then
                            MessageBox.Show("Pricing group exists. No update needed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If MessageBox.Show("Are you sure you want to replace Pricing group """ & dt.Rows(0)("PrcGroup_LDesc").ToString & " with new pricing group """ & Me.CP_cboPricingGroup.Text & ".", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                i = Me._objCustMaintain.SaveCustomerToPrice(iCustID, iProdID, iPrcGrp, Core.ApplicationUser.IDuser)
                                GetCustomerPriceData(iCustID, iProdID, iPrcGrp)
                                CP_lblExistingOfPrcGrp.Text = "Defined - " & Me.CP_cboPricingGroup.Text
                            End If
                        End If
                    Else
                        i = Me._objCustMaintain.SaveCustomerToPrice(iCustID, iProdID, iPrcGrp, Core.ApplicationUser.IDuser)
                        GetCustomerPriceData(iCustID, iProdID, iPrcGrp)
                        CP_lblExistingOfPrcGrp.Text = "Defined - " & Me.CP_cboPricingGroup.Text
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************

#End Region

#Region "Pricing Group"
        '*******************************************************************************
        Private Sub PG_btnPrcGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CP_btnPrcGroup.Click
            Dim frmPG As New OrderEntry.mtnPricingGroup()

            Try
                frmPG.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "PG_btnPrcGroup_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Not IsNothing(frmPG) Then
                    frmPG.Dispose() : frmPG = Nothing
                End If
            End Try
        End Sub

        '*******************************************************************************

#End Region

#Region "Customer Markup Section"

        '*******************************************************************************
        Private Sub ClearCustomerMarkupFields()
            Try
                CM_txtRUR.Text = ""
                CM_txtNER.Text = ""
                CM_txtNTF.Text = ""
                CM_txtRTM.Text = ""
                CM_txtCustMarkup.Text = ""
                Me.CM_txtInventoryMarkup.Text = ""

                CM_cboInvMthdID.SelectedValue = 0
                Me.CM_cboplusparts.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CM_cboCustomer_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CM_cboCustomer.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                ClearCustomerMarkupFields()
                Me.CM_cboProduct.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.Message, "CM_cboCustomer_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CM_cboProduct_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CM_cboProduct.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub
                ClearCustomerMarkupFields()

                If Me.CM_cboCustomer.SelectedValue > 0 And Me.CM_cboProduct.SelectedValue > 0 Then
                    GetCustomerMarkupData(Me.CM_cboCustomer.SelectedValue, Me.CM_cboProduct.SelectedValue)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CM_cboProduct_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub GetCustomerMarkupData(ByVal iCustID As Integer, ByVal iProdID As Integer)
            Dim dt As DataTable
            Dim dr As DataRow

            Try
                dt = Me._objCustMaintain.GetCustomerMarkup(iCustID, iProdID)
                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate record. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)
                    '//Get values for page
                    If IsDBNull(dr("MarkUp_RUR")) = False Then CM_txtRUR.Text = dr("MarkUp_RUR")
                    If IsDBNull(dr("MarkUp_NER")) = False Then CM_txtNER.Text = dr("MarkUp_NER")
                    If IsDBNull(dr("MarkUp_NTF")) = False Then CM_txtNTF.Text = dr("MarkUp_NTF")
                    If IsDBNull(dr("MarkUp_RTM")) = False Then CM_txtRTM.Text = dr("MarkUp_RTM")
                    If IsDBNull(dr("MarkUp_Cust")) = False Then CM_txtCustMarkup.Text = dr("MarkUp_Cust")
                    If IsDBNull(dr("MarkUp_Invt")) = False Then CM_txtInventoryMarkup.Text = dr("MarkUp_Invt")
                    '//Inventory Method
                    CM_cboInvMthdID.SelectedValue = Convert.ToInt32(dr("InvtryMthd_ID"))
                    '//Plus Parts
                    CM_cboPlusparts.SelectedValue = Convert.ToInt32(dr("Markup_PlusParts"))
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub CM_btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CM_btnSave.Click
            Dim i, iCustID, iProdID, iInvMthdID, iPlusPart As Integer
            Dim dbRUR, dbNER, dbNTF, dbRTM, dbCustMarkup, dbInvtyMarkup As Double
            Dim strError As String

            '//Generate sql and execute
            Try
                strError = ""
                If CM_cboCustomer.SelectedValue = 0 Then strError += "No Customer Defined." & vbCrLf
                If CM_cboProduct.SelectedValue = 0 Then strError += "No Product Defined." & vbCrLf
                If CM_txtRUR.Text.Trim.Length = 0 Then strError += "No RUR Defined." & vbCrLf
                If CM_txtNER.Text.Trim.Length = 0 Then strError += "No NER Defined." & vbCrLf
                If CM_txtNTF.Text.Trim.Length = 0 Then strError += "No NTF Defined." & vbCrLf
                If CM_txtRTM.Text.Trim.Length = 0 Then strError += "No RTM Defined." & vbCrLf
                If CM_txtCustMarkup.Text.Trim.Length = 0 Then strError += "No Customer Markup Defined." & vbCrLf
                If CM_txtInventoryMarkup.Text.Trim.Length = 0 Then strError += "No Inventory Markup Defined." & vbCrLf
                If CM_cboInvMthdID.SelectedValue = 0 Then strError += "No Inventory Method Defined." & vbCrLf
                'If CM_cboPlusparts.SelectedValue = 0 Then strError += "No Plus Part Defined." & vbCrLf

                If strError.Trim.Length > 0 Then
                    MessageBox.Show(strError, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iCustID = Me.CM_cboCustomer.SelectedValue
                    iProdID = Me.CM_cboProduct.SelectedValue
                    iInvMthdID = Me.CM_cboInvMthdID.SelectedValue
                    iPlusPart = Me.CM_cboPlusparts.SelectedValue

                    Try : dbRUR = Convert.ToDouble(Me.CM_txtRUR.Text)
                    Catch ex As Exception
                        MessageBox.Show("Invalid RUR value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End Try
                    Try : dbNER = Convert.ToDouble(Me.CM_txtNER.Text)
                    Catch ex As Exception
                        MessageBox.Show("Invalid NER value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End Try
                    Try : dbNTF = Convert.ToDouble(Me.CM_txtNTF.Text)
                    Catch ex As Exception
                        MessageBox.Show("Invalid NTF value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End Try
                    Try : dbRTM = Convert.ToDouble(Me.CM_txtRTM.Text)
                    Catch ex As Exception
                        MessageBox.Show("Invalid RTM value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End Try
                    Try : dbCustMarkup = Convert.ToDouble(Me.CM_txtCustMarkup.Text)
                    Catch ex As Exception
                        MessageBox.Show("Invalid customer markup value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End Try
                    Try : dbInvtyMarkup = Convert.ToDouble(Me.CM_txtInventoryMarkup.Text)
                    Catch ex As Exception
                        MessageBox.Show("Invalid inventory markup value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End Try

                    i = Me._objCustMaintain.SaveCustomerMarkup(iCustID, iProdID, dbRUR, dbNER, dbNTF, _
                    dbRTM, dbCustMarkup, dbInvtyMarkup, iPlusPart, iInvMthdID, Core.ApplicationUser.IDuser)

                    If i > 0 Then
                        MessageBox.Show("Information Saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearCustomerMarkupFields()
                        Me.GetCustomerMarkupData(iCustID, iProdID)
                    Else
                        MessageBox.Show("System has failed to save data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "CM_btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************

#End Region

#Region "Aggregate Billing"
        '*******************************************************************************
        Private Sub LoadAggCodes(ByVal iCustID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objCustMaintain.GetAggBillcodesByCustID(iCustID)

                AB_lstBillcodeCodes.DataSource = dt.DefaultView
                AB_lstBillcodeCodes.DisplayMember = "Billcode_Desc"
                AB_lstBillcodeCodes.ValueMember = "Billcode_ID"

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub LoadDefinedAggCodes(ByVal iCustID As Integer)
            Dim dt As DataTable
            Try
                AB_lblBillCode.Text = ""
                AB_txtAmount.Text = ""

                dt = Me._objCustMaintain.GetAggChargeByCustomer(iCustID)
                AB_gridAggCharge.DataSource = dt.DefaultView

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub AB_btnInsertUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AB_btnInsertUpd.Click
            Dim iBillcodeID, iCustID, i As Integer
            Dim dbAmount As Double = 0.0
            Dim strBillcodeDesc As String = ""

            Try
                If Me.AB_lstBillcodeCodes.Items.Count = 0 Then Exit Sub
                If Me.AB_cboCustomer.SelectedValue = 0 Then Exit Sub
                If Me.AB_lstBillcodeCodes.SelectedValue = 0 Then
                    MessageBox.Show("Please select billcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.AB_txtAmount.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter service charge.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strBillcodeDesc = Me.AB_lstBillcodeCodes.Items.Item(Me.AB_lstBillcodeCodes.SelectedIndex)("Billcode_Desc")
                    iBillcodeID = Me.AB_lstBillcodeCodes.SelectedValue
                    dbAmount = Convert.ToDouble(Me.AB_txtAmount.Text)
                    iCustID = Me.AB_cboCustomer.SelectedValue

                    i = Me._objCustMaintain.InsertUpdateAggChargeByCustomer(iCustID, iBillcodeID, dbAmount, Core.ApplicationUser.IDuser)

                    Me.LoadDefinedAggCodes(iCustID)
                    AB_lblBillCode.Text = ""
                    AB_txtAmount.Text = ""
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Insert/Update Agg Billing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub AB_btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AB_btnRemove.Click
            Dim iBillcodeID, iCustID, i As Integer
            Dim strBillcodeDesc As String = ""

            Try
                If Me.AB_lstBillcodeCodes.Items.Count = 0 Then Exit Sub
                If Me.AB_cboCustomer.SelectedValue = 0 Then Exit Sub
                If Me.AB_lstBillcodeCodes.SelectedValue = 0 Then
                    MessageBox.Show("Please select billcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strBillcodeDesc = Me.AB_lstBillcodeCodes.Items.Item(Me.AB_lstBillcodeCodes.SelectedIndex)("Billcode_Desc")
                    iBillcodeID = Me.AB_lstBillcodeCodes.SelectedValue
                    iCustID = Me.AB_cboCustomer.SelectedValue
                    If MessageBox.Show("Are you sure you want to delete aggregate charge of billcode """ & strBillcodeDesc & """.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                    i = Me._objCustMaintain.DeleteAggChargeByCustomer(iCustID, iBillcodeID, Core.ApplicationUser.IDuser)

                    Me.LoadDefinedAggCodes(iCustID)
                    AB_lblBillCode.Text = ""
                    AB_txtAmount.Text = ""
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Delete Agg Billing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub AB_lstBillcodeCodes_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AB_lstBillcodeCodes.MouseUp
            Dim dr As DataRow

            Try
                AB_lblBillCode.Text = ""
                AB_txtAmount.Text = ""

                If Me.AB_lstBillcodeCodes.Items.Count > 0 AndAlso Me.AB_lstBillcodeCodes.SelectedValue > 0 Then
                    If Me.AB_gridAggCharge.RowCount > 0 Then
                        If Me.AB_gridAggCharge.DataSource.Table.Select("Billcode_ID = " & Me.AB_lstBillcodeCodes.SelectedValue).length > 0 Then
                            dr = Me.AB_gridAggCharge.DataSource.Table.Select("Billcode_ID = " & Me.AB_lstBillcodeCodes.SelectedValue)(0)
                            If Not IsNothing(dr) Then
                                Me.AB_lblBillCode.Text = dr("Billcode")
                                Me.AB_txtAmount.Text = dr("Charge")
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "AB_lstBillcodeCodes_MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************
        Private Sub AB_cboCustomer_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AB_cboCustomer.SelectedValueChanged
            Try
                If Me._booLoadData = True Then Exit Sub

                If Me.AB_cboCustomer.SelectedValue > 0 Then
                    '//Aggregate Billing
                    Me.LoadAggCodes(Me.AB_cboCustomer.SelectedValue)
                    Me.LoadDefinedAggCodes(Me.AB_cboCustomer.SelectedValue)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "AB_cboCustomer_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*******************************************************************************


#End Region

#Region "Update Labor"

        '************************************************************************************
        Private Sub tpgUpdLabor_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgUpdLabor.VisibleChanged
            Dim dt As DataTable
            Try
                If Me.UL_pnlUpdateLabor.Visible = True AndAlso Me.tpgUpdLabor.Visible = True Then
                    If Me.UL_cboCustomers.DataSource = Nothing Then
                        Me.UL_cboCustomers.DataSource = Nothing
                        dt = PSS.Data.Buisness.Generic.GetCustomers(True, )
                        Misc.PopulateC1DropDownList(Me.UL_cboCustomers, dt, "Cust_Name1", "Cust_ID")
                        Me.UL_cboCustomers.SelectedValue = 0
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpgUpdLabor_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '************************************************************************************
        Private Sub UL_cboCustomers_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UL_cboCustomers.Leave
            Dim dt As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc
            Try
                If Me.UL_pnlUpdateLabor.Visible = True AndAlso Me.tpgUpdLabor.Visible = True Then
                    If Me.UL_cboCustomers.SelectedValue > 0 Then
                        Me.UL_cboModels.DataSource = Nothing
                        objMisc = New PSS.Data.Buisness.Misc()
                        dt = objMisc.GetModelsByCustID(Me.UL_cboCustomers.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.UL_cboModels, dt, "Model_Desc", "Model_ID")
                        Me.UL_cboModels.SelectedValue = 0
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "UL_cboCustomers_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                objMisc = Nothing
            End Try
        End Sub

        '************************************************************************************
        Private Sub btnUpdateLabor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UL_btnUpdateLabor.Click
            Dim objMisc As PSS.Data.Buisness.Misc
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objDevice As PSS.Rules.Device
            Dim strShipStartDate, strShipEndDate As String
            Dim booInWipDevices As Boolean = False

            Try
                If Me.UL_cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.UL_cboCustomers.Focus()
                ElseIf IsNothing(Me.UL_cboModels.DataSource) Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.UL_cboCustomers.Focus()
                ElseIf Me.UL_chkInWip.Checked = False And Me.UL_chkProdShipDate.Checked = False Then
                    MessageBox.Show("Please either select In WIP devices or Production Ship Date devices.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Me.Cursor.Current = Cursors.WaitCursor

                    'Select device by production ship date
                    strShipStartDate = "" : strShipEndDate = ""
                    If Me.UL_chkProdShipDate.Checked = True Then
                        strShipStartDate = CStr(Format(Me.UL_dtShipStartDate.Value, "yyyy-MM-dd")) : strShipEndDate = CStr(Format(Me.UL_dtpShipEndDate.Value, "yyyy-MM-dd"))
                    End If

                    'select device by ship date is null
                    If Me.UL_chkInWip.Checked = True Then
                        booInWipDevices = True
                    End If

                    objMisc = New PSS.Data.Buisness.Misc()
                    dt = objMisc.GetDeviceIDs(Me.UL_cboCustomers.SelectedValue, Me.UL_cboModels.SelectedValue, booInWipDevices, strShipStartDate, strShipEndDate)
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
                MessageBox.Show(ex.ToString, "UL_cboCustomers_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '************************************************************************************
        Private Sub chkProdShipDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UL_chkProdShipDate.CheckedChanged
            If Me.UL_chkProdShipDate.Checked = True Then
                Me.UL_pnlShipDate.Visible = True
                Me.UL_chkInWip.Checked = False
            Else
                Me.UL_pnlShipDate.Visible = False
            End If
        End Sub

        '************************************************************************************
        Private Sub chkInWip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UL_chkInWip.CheckedChanged
            If Me.UL_chkInWip.Checked = True Then
                Me.UL_chkProdShipDate.Checked = False
            End If
        End Sub

        '************************************************************************************
#End Region

#Region "Search"

        '*******************************************************************************
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

        '*******************************************************************************
#End Region

    End Class

End Namespace
